using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPUruNet;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Threading;

namespace PayrollSystemwithFingerprint
{
    public partial class Frm_Reg : Form 
    {
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        private ReaderCollection _readers;
        public Reader _CurrentReader;

        private Fmd MainFinger;
        int count = 0;
        DataResult<Fmd> resultEnrollment;
        List<Fmd> preenrollmentFmds;
        byte[] fingerprintadta;
        private Fmd val;

        public Frm_Reg()
        {
            InitializeComponent();
        }
        private void Frm_Reg_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
                     
        }

        private void resetData()
        {          
                txtUserId.Clear();
                txtfullName.Clear();           
        }
        public void DatabaseConnection()
        {
            try
            {
                Sr = new StreamReader(Dpath);
                while ((Sqline = Sr.ReadLine()) != null)
                {
                    Sqline = Sqline.Replace(@"""", "");
                    Lines.Add(Sqline);
                }
                strArray[0] = Lines[0];
                strArray[1] = Lines[1];
                strArray[2] = Lines[2];
                strArray[3] = Lines[3];
                strArray[4] = Lines[4];

                conn = "server = " + strArray[0].ToString() + "uid = " + strArray[1].ToString() + "pwd = " + strArray[2].ToString() + "Database =" + strArray[3].ToString();
                con = new SqlConnection(conn);
                con.Open();
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        private void LoadScanners()
        {
            CmbReader.Text = string.Empty;
            CmbReader.Items.Clear();
            CmbReader.SelectedIndex = -1;

            try
            {
                _readers = ReaderCollection.GetReaders();

                foreach (Reader Reader in _readers)
                {
                    CmbReader.Items.Add(Reader.Description.Name);
                }

                if (CmbReader.Items.Count > 0)
                {
                    CmbReader.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No Device Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnLoadUserProfile_Click(object sender, EventArgs e)
        {
            UserTable john = new UserTable();
            john.ConString = conn;
            john.TypeOfT = 1;
            if (john.ShowDialog() == DialogResult.OK)
            {
                txtUserId.Text = john.gridValueSelected;
                txtfullName.Text = john.gridValueSelected2;

                pbFingerprint.Image = null;
                if (_CurrentReader != null)
                {
                    _CurrentReader.Dispose();
                    _CurrentReader = null;
                }
                ReaderCollection reader = ReaderCollection.GetReaders();
                if (reader.Count > 0)
                {
                    _CurrentReader = reader[0];
                }
                else
                {
                    MessageBox.Show("No reader");
                }


                if (!OpenReader())
                {
                    this.Close();
                }

                if (!StartCaptureAsync(this.OnCaptured))
                {
                    this.Close();
                }
            }

        }
        public void GetStatus()
        {
            Constants.ResultCode result = _CurrentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                reset = true;
                throw new Exception("" + result);
            }

            if ((_CurrentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((_CurrentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                _CurrentReader.Calibrate();
            }
            else if ((_CurrentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                MessageBox.Show("Reader Status - " + _CurrentReader.Status.Status);
            }
        }
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    pbFingerprint.Image = (Bitmap)CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height);
                    fingerprintadta = captureResult.Data.Bytes;
                }
           //     MessageBox.Show("A finger was captured.");

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                count++;
                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    Reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }
                if (resultConversion.Data != null)
                {
                    if (preenrollmentFmds == null)
                    {
                        preenrollmentFmds = new List<Fmd>();
                    }
                    MainFinger = resultConversion.Data;
                    preenrollmentFmds.Add(resultConversion.Data);
                    if (count >= 4)
                    {
                        resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                        if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {                           
                            MessageBox.Show("Staff Finger Print was Recorded.");

                            int NoOFFingerRegister = 0;
                            SqlDataAdapter cmd = new SqlDataAdapter("Select * from  Userprofile", conn);
                            DataTable dt = new DataTable();
                            cmd.Fill(dt);
                            List<string> lstledgerIds = new List<string>();
                            count = 0;
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    string FingerPrint = dt.Rows[i]["FingerPrint"].ToString();
                                    if (FingerPrint !="")
                                    {
                                        val = Fmd.DeserializeXml(FingerPrint);

                                        CompareResult compare = Comparison.Compare(MainFinger, 0, val, 0);
                                        if (compare.ResultCode != Constants.ResultCode.DP_SUCCESS)
                                        {
                                            Reset = true;
                                            MessageBox.Show(compare.ResultCode.ToString());
                                        }
                                        if (Convert.ToDouble(compare.Score.ToString()) == 0)
                                        {
                                            NoOFFingerRegister++;
                                        }
                                    }
                                   
                                }
                            }

                            if (NoOFFingerRegister == 0)
                            {
                                DialogResult rs = MessageBox.Show("Do you want to upload finger print", "Uploading fingerprint", MessageBoxButtons.YesNo);
                                if (Convert.ToBoolean(rs.ToString() == "Yes"))
                                {
                                    uploadFingerPrint();
                                    resultEnrollment = null;
                                    preenrollmentFmds = new List<Fmd>();
                                    preenrollmentFmds.Clear();
                                    count = 0;
                                    ckReset.BeginInvoke(new Action(() =>
                                    {
                                        pbFingerprint.Image = null;
                                        ckReset.Checked = true;
                                    }));
                                }
                                else
                                {
                                    resultEnrollment = null;
                                    preenrollmentFmds = new List<Fmd>();
                                    preenrollmentFmds.Clear();
                                    count = 0;
                                    ckReset.BeginInvoke(new Action(() =>
                                    {
                                        pbFingerprint.Image = null;
                                        ckReset.Checked = true;
                                    }));
                                }
                            }
                            else
                            {
                                resultEnrollment = null;
                                preenrollmentFmds = new List<Fmd>();
                                preenrollmentFmds.Clear();
                                count = 0;
                                CKMessage.BeginInvoke(new Action(() =>
                                {
                                    pbFingerprint.Image = null;
                                    CKMessage.Checked = true;
                                }));
                            }                         
                            return;
                        }
                        else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                        {
                            MessageBox.Show("Enrollment was unsuccessful.  Please try again.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                    }
                    MessageBox.Show("Now place the same finger on the reader.");
                }
                else
                {
                    MessageBox.Show("Data Empty","Error");
                }
            }
            catch(Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = _CurrentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, _CurrentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                   MessageBox.Show("" + captureResult);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {

            // Activate capture handler
            _CurrentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            // Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }

            return true;
        }
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        public bool OpenReader()
        {
            try
            {
                reset = false;
                Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

                // O  vpen reader
                result = _CurrentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error:  " + result);
                    reset = true;
                    return false;
                }

                return true;

            }
            catch (Exception ce)
            {
                
                MessageBox.Show(ce.Message.ToString());
                return false;
            }
        }

        private void uploadFingerPrint()
        {
            try
            {
                int RegStatus = 1; 
                SqlCommand cmd = new SqlCommand("Update  UserProfile Set FingerPrint = @FPPV , RegStatus =@RS where "
                    + " UserID = @StaffName", con);
                cmd.Parameters.AddWithValue("@StaffName", txtUserId.Text);
                cmd.Parameters.AddWithValue("@FPPV", Fmd.SerializeXml(resultEnrollment.Data));
                cmd.Parameters.AddWithValue("@RS", RegStatus);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succefully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ckReset_CheckedChanged(object sender, EventArgs e)
        {
            if (ckReset.Checked)
            {
                resetData();
            }
        }

        private void CKMessage_CheckedChanged(object sender, EventArgs e)
        {
            if (CKMessage.Checked)
            {
                resetData();
                MessageBox.Show("Fingerprint Already Exist");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null || captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    MessageBox.Show("Quality - " + captureResult.Quality);
                }
                return false;
            }

            return true;
        }
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }
    }
}
