using DPUruNet;
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
    public partial class Frm_MainMenu : Form
    {
        public Reader _CurrentReader;
        public string conn;

        public Frm_MainMenu()
        {
            InitializeComponent();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile ur = new UserProfile();
            ur.MdiParent = this;
            ur.Show();
        }

        private void salarySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryMakeup pos = new SalaryMakeup();
            pos.MdiParent = this;
            pos.Show();
        }

        private void registerStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_Reg R = new Frm_Reg();
            R._CurrentReader = _CurrentReader;
            R.MdiParent = this;
           
            R.Show();
        }

        private void createSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffSalarySetUp sss = new StaffSalarySetUp();
            sss.MdiParent = this;
            sss.Show();

            //AdminLogin Al = new AdminLogin();
            //Al.Show();
        }

        private void setupTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CheckFingerPrintAavailable CpA = new Frm_CheckFingerPrintAavailable();
            CpA.MdiParent = this;
            CpA.Show();
        }

        private void createPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePayroll cp = new CreatePayroll();
            cp.MdiParent = this;
            cp.Show();
        }

        private void departmentSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.MdiParent = this;
            d.Show();
        }

        private void positionSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Position pos = new Position();
            pos.MdiParent = this;
            pos.Show();
        }

        private void adminstrativeLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Leave l = new Frm_Leave();
            l.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_moduleSetting ms = new Frm_moduleSetting();
            ms.MdiParent = this;
            ms.Show();
        }

        private void Frm_MainMenu_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordAttendance meun = new RecordAttendance();
            meun.Show();
            Hide();
        }
    }
}
