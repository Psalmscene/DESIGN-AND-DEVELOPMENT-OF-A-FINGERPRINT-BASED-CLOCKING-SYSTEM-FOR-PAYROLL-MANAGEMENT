using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class Position : Form
    {
        public Position()
        {
            InitializeComponent();
            mtbStartTime.Mask = "00:00 >LL";
            mtbStartTime.ValidatingType = typeof(DateTime);

            mtbEndTime.Mask = "00:00 >LL";
            mtbEndTime.ValidatingType = typeof(DateTime);
        }
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;
        private string DeptID;
        private string PositionID;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtDept.Text != "" && txtTittle.Text != "" )
            {
                cmd = new SqlCommand(" Select * from Position where DeptID = @U and Position = @A "
                    + " and PName = @B", con);
                cmd.Parameters.AddWithValue("@U", DeptID);
                cmd.Parameters.AddWithValue("@A", cmbPosition.Text);
                cmd.Parameters.AddWithValue("@B", txtTittle.Text);
                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Record already Exist");
                }
                else
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        cmd = new SqlCommand("Insert into Position (DeptID,Position,SalaryAmount,PName,Rtime,Ctime) values "
                                   + "(@U,@A,@B,@C,@E,@F)", con);
                        cmd.Parameters.AddWithValue("@U", DeptID);
                        cmd.Parameters.AddWithValue("@A", cmbPosition.Text);
                        cmd.Parameters.AddWithValue("@B", TxtBasicSalary.Text);
                        cmd.Parameters.AddWithValue("@C", txtTittle.Text);
                        cmd.Parameters.AddWithValue("@E", mtbStartTime.Text);
                        cmd.Parameters.AddWithValue("@F", mtbEndTime.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Save");
                        LoadPositionList();
                    }
                    else
                    {
                        MessageBox.Show("Operation Cancel");
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing Information");
            }      
        }
        public void LoadPositionList()
        {
            try
            {
                dgvPosition.Rows.Clear();
                cmd = new SqlCommand("select * from Position where DeptID = '"+DeptID+"'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string ID = item["PositionID"].ToString();
                        string Name = item["PName"].ToString();
                        string Position = item["Position"].ToString();
                        string SalaryAmount = item["SalaryAmount"].ToString();
                        string Resume = item["Rtime"].ToString();
                        string Closing = item["Ctime"].ToString();

                        dgvPosition.Rows.Add(ID,Name, Position, SalaryAmount,Resume,Closing);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        public void LoadDepartmentList()
        {
            try
            {
                dgvDepartment.Rows.Clear();
                cmd = new SqlCommand("select * from Department", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string ProductID = item["DeptID"].ToString();
                        string ProductName = item["DeptName"].ToString();

                        dgvDepartment.Rows.Add(ProductID, ProductName);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
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
        private void Position_Load(object sender, EventArgs e)
        {

            DatabaseConnection();
            LoadDepartmentList();
            button2.Enabled = false;
            button1.Enabled = false;
        }

        private void mtbStartTime_Enter(object sender, EventArgs e)
        {
            mtbStartTime.Clear();
            mtbStartTime.ValidatingType = typeof(DateTime);
            mtbStartTime.SelectionStart = 0;
        }

        private void mtbEndTime_Enter(object sender, EventArgs e)
        {

            mtbEndTime.Clear();
            mtbEndTime.ValidatingType = typeof(DateTime);
            mtbEndTime.SelectionStart = 0;
        }

        private void mtbStartTime_Leave(object sender, EventArgs e)
        {
         //   txtHours.Clear();
            DateTime userimput;

            if (DateTime.TryParse(mtbStartTime.Text, out userimput))
            {

            }
            else
            {
                MessageBox.Show("Invalid Time format");
                mtbStartTime.Focus();
            }
        }

        private void mtbEndTime_Leave(object sender, EventArgs e)
        {
            DateTime userimput;

            if (DateTime.TryParse(mtbEndTime.Text, out userimput))
            {
              
            }
            else
            {
                MessageBox.Show("Invalid Time format");
                mtbStartTime.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDept.Text != "" && txtTittle.Text != "")
            {
                DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                if (Convert.ToBoolean(rs.ToString() == "Yes"))
                {

                    cmd = new SqlCommand("Update Position set SalaryAmount = '" + TxtBasicSalary.Text + "', "
                   + "RTime = '" + mtbStartTime.Text + "', Ctime = '" + mtbEndTime.Text + "' "
                   + "Where PositionID = '" + PositionID + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    LoadPositionList();
                }
                else
                {
                    MessageBox.Show("Operation Cancel");
                }
            }
            else
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("select * from Department where DeptName = '"+txtDept.Text+"' ", con);
            //SqlDataAdapter adb = new SqlDataAdapter(cmd);
            //DataTable ds = new DataTable();
            //adb.Fill(ds);
            //if (ds.Rows.Count > 0)
            //{
            //    foreach (DataRow item in ds.Rows)
            //    {
            //        DeptID= item["DeptID"].ToString();
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtBasicSalary.Text = "0";
            mtbEndTime.Clear();
            mtbStartTime.Clear();
            txtTittle.Clear();
            cmbPosition.SelectedIndex = -1;
            DeptID = dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDept.Text = dgvDepartment.Rows[e.RowIndex].Cells[1].Value.ToString();
            LoadPositionList();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void dgvPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtBasicSalary.Text = "0";
            mtbEndTime.Clear();
            mtbStartTime.Clear();
            txtTittle.Clear();
            cmbPosition.SelectedIndex = -1;

            PositionID = dgvPosition.Rows[e.RowIndex].Cells[0].Value.ToString();

            cmd = new SqlCommand("select * from Department where deptID = '"+DeptID+"'", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    txtDept.Text = item["DeptName"].ToString();
                }
            }
            cmd = new SqlCommand("select * from Position where PositionID = '" + PositionID + "'", con);
            SqlDataAdapter adb1 = new SqlDataAdapter(cmd);
            DataTable ds1 = new DataTable();
            adb1.Fill(ds1);
            if (ds1.Rows.Count > 0)
            {
                foreach (DataRow item in ds1.Rows)
                {
                    mtbStartTime.Text = item["Rtime"].ToString();
                    mtbEndTime.Text = item["Ctime"].ToString();
                }
            }
            txtTittle.Text = dgvPosition.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbPosition.Text = dgvPosition.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtBasicSalary.Text = dgvPosition.Rows[e.RowIndex].Cells[3].Value.ToString();
            button2.Enabled = true;
            button1.Enabled = false;
        }
    }
}
