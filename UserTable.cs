using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class UserTable : Form
    {
        public UserTable()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;
        public string gridValueSelected = "";
        public string gridValueSelected2 = "";
        public string gridValueSelected3 = "";
        public string gridValueSelected4 = "";
        public int TypeOfT = 0;


        private void UserTable_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConString);
            con.Open();
            if (TypeOfT == 0)
            {
                gridveiwUser();
            }
            else
            {
                gridveiwUser2();
            }
           
        }
        public void gridveiwUser()
        {
            try
            {
                cmd = new SqlCommand("select u.UserID,u.FullName,u.Usertype, d.DeptName from Userprofile u inner join "
                    +" Department d on d.deptID = u.DeptID ", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adb.Fill(ds, "Userprofile");
                dataGridView1.DataSource = ds.Tables["Userprofile"].DefaultView;
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        public void gridveiwUser2()
        {
            try
            {
                cmd = new SqlCommand("select u.UserID,u.FullName,u.Usertype, d.DeptName  from Userprofile u inner join  "
                    + " Salary s on s.StaffID = u.UserID inner join Department d on d.deptID = u.DeptID ", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adb.Fill(ds, "Userprofile");
                dataGridView1.DataSource = ds.Tables["Userprofile"].DefaultView;
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int Row = dataGridView1.CurrentRow.Index;
                gridValueSelected = Convert.ToString(dataGridView1[0, Row].Value);
                gridValueSelected2 = Convert.ToString(dataGridView1[1, Row].Value);
                gridValueSelected3 = Convert.ToString(dataGridView1[2, Row].Value);
                gridValueSelected4 = Convert.ToString(dataGridView1[3, Row].Value);
            }
            else
            {
                MessageBox.Show("No Staff Record Select");
            }        
        }
    }
}
