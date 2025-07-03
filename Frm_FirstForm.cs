using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class Frm_FirstForm : Form
    {
        public Frm_FirstForm()
        {
            InitializeComponent();
        }

        private void Frm_FirstForm_Load(object sender, EventArgs e)
        {
            CLearDataAfterdelay();
        }
        private async void CLearDataAfterdelay()
        {
            await Task.Delay(2000);
            resetData();
        }
        private void resetData()
        {
            RecordAttendance meun = new RecordAttendance();
            meun.Show();
            Hide();
        }
    }
}
