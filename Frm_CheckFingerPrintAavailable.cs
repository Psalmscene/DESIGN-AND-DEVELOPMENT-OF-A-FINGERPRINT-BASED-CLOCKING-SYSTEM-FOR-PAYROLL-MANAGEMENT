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
using System.Drawing.Imaging;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace PayrollSystemwithFingerprint
{
    public partial class Frm_CheckFingerPrintAavailable : Form
    {
        private ReaderCollection _readers;
        public Reader _CurrentReader;


        public Frm_CheckFingerPrintAavailable()
        {
            InitializeComponent();
        }
        // code for capturing

        private void Frm_CheckFingerPrintAavailable_Load(object sender, EventArgs e)
        {
  
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboReaders.Text = string.Empty;
            cboReaders.Items.Clear();
            cboReaders.SelectedIndex = -1;

            try
            {

                _readers = ReaderCollection.GetReaders();
                foreach (Reader Reader in _readers)
                {
                    cboReaders.Items.Add(Reader.Description.Name);
                }

                if (cboReaders.Items.Count > 0)
                {
                    cboReaders.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No Reader found check to see if reader is connected");
                }
            }
            catch (Exception ex)
            {
                //message box:
                String text = ex.Message;
                text += "\r\n\r\nPlease check if DigitalPersona service has been started";
                String caption = "Cannot access readers";
                MessageBox.Show(text, caption);
            }
        }

        private void BtnCheckCapability_Click(object sender, EventArgs e)
        {
            lstCaps.BeginUpdate();
            lstCaps.Items.Clear();
            lstCaps.EndUpdate();

            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            result = _CurrentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                if (_CurrentReader != null)
                {
                    _CurrentReader.Dispose();
                    _CurrentReader = null;
                }
                return;
            }

            // Update display.

            txtName.Text = _CurrentReader.Description.Name;
            txtReaderSelected.Text = _CurrentReader.Description.Name;

            lstCaps.BeginUpdate();

            lstCaps.Items.Add("Can Capture:  " + _CurrentReader.Capabilities.CanCapture.ToString());
            lstCaps.Items.Add("Can Stream:  " + _CurrentReader.Capabilities.CanStream.ToString());
            lstCaps.Items.Add("Extract Features:  " + _CurrentReader.Capabilities.ExtractFeatures.ToString());
            lstCaps.Items.Add("Can Match:  " + _CurrentReader.Capabilities.CanMatch.ToString());
            lstCaps.Items.Add("Can Identify:  " + _CurrentReader.Capabilities.CanIdentify.ToString());
            lstCaps.Items.Add("Has Fingerprint Storage:  " + _CurrentReader.Capabilities.HasFingerprintStorage.ToString());
            lstCaps.Items.Add("Has Power Management:  " + _CurrentReader.Capabilities.HasPowerManagement.ToString());
            lstCaps.Items.Add("PIV Compliant:  " + _CurrentReader.Capabilities.PIVCompliant.ToString());
            lstCaps.Items.Add("Indicator Type: 0x" + _CurrentReader.Capabilities.IndicatorType.ToString("X"));

            foreach (int resolution in _CurrentReader.Capabilities.Resolutions)
            {
                if (!(resolution == 0))
                {
                    lstCaps.Items.Add("Resolution:  " + resolution.ToString());
                }
            }

            lstCaps.EndUpdate();

            _CurrentReader.Dispose();
        }

        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        public bool OpenReader()
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
        private void BtnSelectreader_Click(object sender, EventArgs e)
        {
            if (_CurrentReader != null)
            {
                _CurrentReader.Dispose();
                _CurrentReader = null;
            }
            _CurrentReader = _readers[cboReaders.SelectedIndex];

            if (!OpenReader())
            {
                this.Close();
            }
        }
    }
}
