using DPUruNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class RecordAttendance : Form
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

        private string AttendanceID;
        List<StaffAttendanceList> ListOfStaffAttendance = new List<StaffAttendanceList>();
        List<AttendanceTiming> ListOFtime = new List<AttendanceTiming>();

        public RecordAttendance()
        {
            InitializeComponent();
            
        }
        private async void CLearDataAfterdelay()
        {
            await Task.Delay(2000);
            resetData();
        }

        public class AttendanceTiming
        {
            public int DeptID { get; set; }

            public DateTime ResumeTime { get; set; }

            public string SResumeTime { get; set; }

            public DateTime ClosingTime { get; set; }

            public string SCLosingTime { get; set; }
        }
        public List<AttendanceTiming> GetAttendingTime()
        {
            List<AttendanceTiming> E = new List<AttendanceTiming>();

            cmd = new SqlCommand("select * from Position ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    //DateTime dt = item.Field<DateTime>("Rtime");
                    //string D2 = dt.ToString("dd/MMM/yyyy");

                    //DateTime Cdt = item.Field<DateTime>("Ctime");
                    //string CD2 = dt.ToString("dd/MMM/yyyy");

                    AttendanceTiming List = new AttendanceTiming();
                    //List.DeptID = item.Field<string>("FullName");
                    //List.UserTYpe = item.Field<string>("Usertype");
                    List.DeptID = item.Field<int>("DeptID");
                 //   List.UserID = item.Field<int>("AttendanceID");
                  //  List.ResumeTime = dt;
                    List.SResumeTime = item.Field<string>("Rtime");
                  //  List.ClosingTime = Cdt;
                    List.SCLosingTime = item.Field<string>("Ctime");

                    E.Add(List);
                }
            }

            return E;
        }

        public class StaffAttendanceList
        {
            public int ID { get; set; }
            public string StaffName { get; set; }

            public int UserID { get; set; }

            public DateTime ResumeDate { get; set; }

            public string SResumeDate { get; set; }

            public DateTime ResumeTime { get; set; }

            public string SResumeTime { get; set; }

            public DateTime? ClosingTime { get; set; }

            public string SCLosingTime { get; set; }

            public string UserTYpe { get; set; }

        }
        public List<StaffAttendanceList> GetInsertedAttendanceData()
        {
            List<StaffAttendanceList> E = new List<StaffAttendanceList>();

            cmd = new SqlCommand("select s.AttendanceID, s.StaffID UID,s.DOA, s.TR, s.tc, u.Usertype , u.FullName from StaffAttendance s inner Join UserProfile u on u.UserID = s.StaffID  ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    DateTime dt = item.Field<DateTime>("TR");
                    string D2 = dt.ToString("dd/MMM/yyyy");

                    DateTime Ddt = item.Field<DateTime>("DOA");
                    string DD2 = dt.ToString("dd/MMM/yyyy");

                    DateTime? Cdt = item.Field<DateTime?>("tc");
                    string CD2 = dt.ToString("dd/MMM/yyyy");

                    StaffAttendanceList List = new StaffAttendanceList();
                    List.StaffName = item.Field<string>("FullName");
                    List.UserTYpe = item.Field<string>("Usertype");
                    List.UserID = item.Field<int>("UID");
                    List.ID = item.Field<int>("AttendanceID");
                    List.ResumeTime = dt;
                    List.SResumeTime = D2;
                    List.ClosingTime = Cdt;
                    List.SCLosingTime = CD2;
                    List.ResumeDate = Ddt;
                    List.SResumeDate = DD2;
                    E.Add(List);
                }
            }

            return E;
        }

        // the entry point of the attendance recorder
        private void RecordAttendance_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Visible = false;
            lblStaffName.Visible = false;
            lblStaffID.Visible = false;

            //to open a new connection for the create instance of this form.
            DatabaseConnection();

            
            LoadScanners();
            pbFingerprint.Image = null;
            resetData();
            if (_CurrentReader != null)
            {
                _CurrentReader.Dispose();
                _CurrentReader = null;
            }
            _CurrentReader = _readers[CmbReader.SelectedIndex];
            if (!OpenReader())
            {
                MessageBox.Show("No Scanner Detected");
            }

            if (!StartCaptureAsync(this.OnCaptured))
            {
                
            }
        }
        private void resetData()
        {
            pbFingerprint.Image = null;
            ckReset.Checked = false;
            lblWelcome.Visible = false;
            lblStaffName.Visible = false;
            lblStaffID.Visible = false;

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
        private void UpdateUI()
        {
            lblStaffID.Text = userID;
            lblStaffName.Text = StaffName;
            lblStaffName.Visible = true;
            lblWelcome.Visible = true;
            lblStaffID.Visible = true;
            ckSendData.Checked = false;
        }

        private string userID;
        private string StaffName;
        private Fmd val;
        private int DeptID;
        private TimeSpan SHour;
        string UserType = "";
        public void comparefingerPrint()
        {
            int RS = 1;
            UserType = "";
            string X1 = DateTime.Now.ToString("dd/MMM/yyyy");
            // getting all User profile from the database.
            SqlDataAdapter cmd = new SqlDataAdapter("Select * from  Userprofile where RegStatus = '"+RS+"'", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            List<string> lstledgerIds = new List<string>();
           
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    count = 0;
                    userID = dt.Rows[i]["UserID"].ToString();
                    StaffName = dt.Rows[i]["FullName"].ToString();
                   // string UserType = dt.Rows[i]["UserType"].ToString();
                    DeptID = Convert.ToInt32( dt.Rows[i]["DeptID"].ToString());
                    val = Fmd.DeserializeXml(dt.Rows[i]["FingerPrint"].ToString());
                
                    // check during finger print 
                    CompareResult compare = Comparison.Compare(MainFinger, 0, val, 0);
                    if (compare.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        Reset = true;
                       MessageBox.Show("Error Matching Finger, Try Again");
                    }

                    if (Convert.ToDouble(compare.Score.ToString()) == 0)
                    {
                        count++;
                        ListOfStaffAttendance = GetInsertedAttendanceData();
                        ListOfStaffAttendance = ListOfStaffAttendance.Where(x => DateTime.Parse(x.SResumeDate) 
                        == DateTime.Parse(X1) && x.UserID.ToString() == userID).ToList();

                        //check if 
                        string Closing = "";
                        int hour = 1;
                        if (ListOfStaffAttendance.Count == 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("insert into StaffAttendance (StaffID )"
                           + " values (@StaffID)", con);
                            cmd2.Parameters.AddWithValue("@StaffID", userID);
                            cmd2.ExecuteNonQuery();

                            SqlDataAdapter cmd3 = new SqlDataAdapter("Select * from  Userprofile where UserID = '" + userID + "' ", conn);
                            DataTable dt3 = new DataTable();
                            cmd3.Fill(dt3);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow item in dt3.Rows)
                                {
                                    UserType = item["UserType"].ToString();
                                }
                            }

                            ckSendData.BeginInvoke(new Action(() =>
                            {
                                ckSendData.Checked = true;
                            }));

                            ckReset.BeginInvoke(new Action(() =>
                            {
                                ckReset.Checked = true;
                            }));
                            break;
                        }
                        else
                        {
                            ListOFtime = GetAttendingTime();
                            ListOFtime = ListOFtime.Where(x => x.DeptID == DeptID).ToList();


                            foreach (StaffAttendanceList item in ListOfStaffAttendance)
                            {
                                AttendanceID = item.ID.ToString();
                            }


                             foreach (AttendanceTiming item in ListOFtime)
                            {
                                Closing = item.SCLosingTime;
                            }

                            DateTime TimeNeeded = DateTime.ParseExact(Closing, "hh:mm tt", CultureInfo.InvariantCulture);

                            TimeSpan closingTime = TimeNeeded.TimeOfDay;

                            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
                            TimeSpan OnehourRule = CurrentTime + TimeSpan.FromHours(hour);

                            if (CurrentTime > closingTime)
                            {
                                UpdateSTaffAttendance();
                            }
                            else if (CurrentTime < closingTime)
                            {
                                if (OnehourRule > closingTime)
                                {
                                    UpdateSTaffAttendance();
                                }
                            }

                            SqlDataAdapter cmd1 = new SqlDataAdapter("Select * from  Userprofile where UserID = '" + userID + "' ", conn);
                            DataTable dt1 = new DataTable();
                            cmd1.Fill(dt1);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow item in dt1.Rows)
                                {
                                    UserType = item["UserType"].ToString();
                                }
                            }

                            ckSendData.BeginInvoke(new Action(() =>
                            {
                                ckSendData.Checked = true;
                            }));


                            ckReset.BeginInvoke(new Action(() =>
                            {
                                ckReset.Checked = true;
                            }));
                            break;
                        }                     
                    }
                }

                if (count == 0)
                {
                    ckReset.BeginInvoke(new Action(() =>
                    {
                        ckReset.Checked = true;
                    }));
                    MessageBox.Show("Fingerprint not registered.");
                }
            }
            else
            {
              
                int id = 1001;

               SqlCommand cmd1 = new SqlCommand("select * from ModuleSetting", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                adb.Fill(ds, "ModuleSetting");
                if (ds.Tables["ModuleSetting"].Rows.Count > 0)
                {
                    
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into ModuleSetting (ID )"
                + " values (@ID)", con);
                    cmd2.Parameters.AddWithValue("@ID", id);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("No Staff Record.......");
                    ckReset.BeginInvoke(new Action(() =>
                    {
                        ckReset.Checked = true;
                    }));
                    CkSendTime.BeginInvoke(new Action(() =>
                    {
                        CkSendTime.Checked = true;
                    }));
                }          
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

                    comparefingerPrint();
                }
                else
                {
                    MessageBox.Show("Data Empty", "Error");
                }
            }
            catch (Exception ce)
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
                    MessageBox.Show("No no");
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
            try
            {
                _CurrentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
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
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null || captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    MessageBox.Show(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    MessageBox.Show("low Quality Try Again ");
                }
                return false;
            }

            return true;
        }
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            // create a picture from the reader values
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

        private void ckReset_CheckedChanged(object sender, EventArgs e)
        {
            if (ckReset.Checked)
            {
                CLearDataAfterdelay();

                if (UserType.ToLower() == "admin")
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to Login?", "Admin Login", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        Frm_MainMenu meun = new Frm_MainMenu();
                        meun._CurrentReader = _CurrentReader;
                        _CurrentReader.Dispose();
                        _CurrentReader = null;
                        meun.conn = conn;
                        meun.Show();
                                         
                        Close();
                    }
                }
            }
        }

        private void ckSendData_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSendData.Checked)
            {
                UpdateUI();
            }
            
        }

        private void CkSendTime_CheckedChanged(object sender, EventArgs e)
        {
            if (CkSendTime.Checked)
            {
                CkSendTime.Checked = false;
                DialogResult rs = MessageBox.Show(" Do you Still Want to Login?", "Temporary Login", MessageBoxButtons.YesNo);
                if (Convert.ToBoolean(rs.ToString() == "Yes"))
                {
                    Frm_MainMenu meun = new Frm_MainMenu();
                    meun._CurrentReader = _CurrentReader;
                    _CurrentReader.Dispose();
                    _CurrentReader = null;
                    meun.conn = conn;
                    meun.Show();

                    Close();
                }
            }
          
        }

        private void ckTimetime_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTimetime.Checked)
            {
                MessageBox.Show("closing after");
            }
            else
            {
                MessageBox.Show("closing Before");
            }
        }

        public bool OpenReader()
        {
            try
            {
                reset = false;
                Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

                // Open reader
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(" Do you Still Want to Login?", "Admin Login", MessageBoxButtons.YesNo);
            if (Convert.ToBoolean(rs.ToString() == "Yes"))
            {
                Frm_MainMenu meun = new Frm_MainMenu();
                meun.Show();
                meun._CurrentReader = _CurrentReader;
                _CurrentReader.Dispose();
                _CurrentReader = null;
                meun.conn = conn;
                Close();
            }
        }

        private void pbFingerprint_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                tmmmm.Text = DateTime.Now.ToString("hh :mm :ss");
                TodayDay.Text = DateTime.Now.ToString("dddd");
                CDate.Text = DateTime.Now.ToString("dd -MMM -yyyy");
                AmOrPm.Text = DateTime.Now.ToString("tt");

            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void StopCapure()
        {
                if (_CurrentReader != null)
                {
                    _CurrentReader.CancelCapture();
                    _CurrentReader.On_Captured -= OnCaptured;
                }
        }
        private void RecordAttendance_VisibleChanged(object sender, EventArgs e)
        {
          
        
        }

        private void RecordAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateSTaffAttendance()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update  StaffAttendance Set TC = @TC where "
                    + " StaffID = @StaffID and AttendanceID = @ID", con);
                cmd.Parameters.AddWithValue("@StaffID", userID);
                cmd.Parameters.AddWithValue("@TC", DateTime.Now);
                cmd.Parameters.AddWithValue("@ID", AttendanceID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetStatus()
        {
            Constants.ResultCode result = _CurrentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                reset = true;
                MessageBox.Show("" + result);
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
    }
}
