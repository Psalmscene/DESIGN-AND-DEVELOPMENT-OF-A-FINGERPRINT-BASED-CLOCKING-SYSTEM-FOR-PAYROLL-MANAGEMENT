using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        public string insertLoginDetail;
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;
        public string StaffID;
        public int Exc;
        private string DeptID;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;


        private void btnNewUser_Click(object sender, EventArgs e)
        {
           // clearAccess();
            //txtPassword.Clear();
           // txtRePassword.Clear();
            txtUserId.Clear();
          //  txtUsername.Clear();
            cmbUserType.SelectedIndex = 0;
            txtfullName.Clear();
        //    txtUsername.Enabled = true;
            cmbUserType.Enabled = true;
          //  txtPassword.Enabled = true;
            //txtRePassword.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSubmit.Enabled = true;
            LoadDepartmentList();
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
        public void LoadDepartmentList()
        {
            try
            {
                CmbDepartment.Items.Clear();
                cmd = new SqlCommand("select * from Department", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string DepartmentName = item["DeptName"].ToString();
                        CmbDepartment.Items.Add(DepartmentName);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            LoadDepartmentList();
        }
        public void gridveiwStaff()
        {
            try
            {
                cmd = new SqlCommand("select * from UserProfile where UserID = '" + txtUserId.Text + "'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adb.Fill(ds, "UserProfile");
                if (ds.Tables["UserProfile"].Rows.Count > 0)
                {
                    txtfullName.Text = ds.Tables["UserProfile"].Rows[0]["FullName"].ToString();
                //    txtUsername.Text = ds.Tables["UserProfile"].Rows[0]["UserName"].ToString();
                  //  txtPassword.Text = ds.Tables["UserProfile"].Rows[0]["Passwords"].ToString();
                    //txtRePassword.Text = ds.Tables["UserProfile"].Rows[0]["Passwords"].ToString();
                    DeptID = ds.Tables["UserProfile"].Rows[0]["DeptID"].ToString();
                    cmbUserType.SelectedItem = ds.Tables["UserProfile"].Rows[0]["Usertype"].ToString();

                    cmd = new SqlCommand("select * from Department where DeptID ='" + DeptID + "'", con);
                    SqlDataAdapter adb1 = new SqlDataAdapter(cmd);
                    DataTable ds1 = new DataTable();
                    adb1.Fill(ds1);
                    if (ds1.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds1.Rows)
                        {
                            CmbDepartment.SelectedItem = item["DeptName"].ToString();
                        }
                    }

                    //bool val1ggg = Convert.ToBoolean(ds.Tables["UserProfile"].Rows[0]["InStaff"].ToString());
                    //if (val1ggg == true)
                    //{
                    //    CkSuper.Checked = true;
                    //}
                    //else
                    //{
                    //    CkSuper.Checked = false;
                    //}
                 
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfullName.Text != "" && cmbUserType.SelectedIndex != -1 && CmbDepartment.SelectedIndex != -1 && DeptID !="")
                {

                    cmd = new SqlCommand("select * from UserProfile where FullName = '" + txtfullName.Text + "' ", con);
                    SqlDataAdapter adb = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adb.Fill(ds, "UserProfile");
                    if (ds.Tables["UserProfile"].Rows.Count > 0)
                    {
                        MessageBox.Show("User Already Exist", "Error");
                    }
                    else
                    {
                        DialogResult rs = MessageBox.Show(" Are you Sure?", "Saving Record", MessageBoxButtons.YesNo);
                        if (Convert.ToBoolean(rs.ToString() == "Yes"))
                        {
                            Exc = 0;
                            cmd = new SqlCommand("Insert into UserProfile (FullName , "
                        + "usertype,DeptID ) values "
                        + "(@F,@AJ,@AK)", con);
                            
                            cmd.Parameters.AddWithValue("@F", txtfullName.Text);
                         
                            cmd.Parameters.AddWithValue("@AJ", cmbUserType.Text);
                            cmd.Parameters.AddWithValue("@AK", DeptID);
                            Exc = cmd.ExecuteNonQuery();
                            MessageBox.Show("User Sucessfully Created.....");
                            txtfullName.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Operation Cancel");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Missing Field");
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (StaffID != "")
            {
              //  bool CbStaff = Convert.ToBoolean(CkSuper.CheckState);
              
                try
                {
                    if (  txtfullName.Text != "" && DeptID !="")
                    {

                        DialogResult rs = MessageBox.Show(" Are you Sure?", "Updating Record", MessageBoxButtons.YesNo);
                        if (Convert.ToBoolean(rs.ToString() == "Yes"))
                        {
                            Exc = 0;
                            cmd = new SqlCommand("Update UserProfile  Set "
                           // + "Passwords = '" + txtPassword.Text + "',"
                            + "UserType = '" + cmbUserType.Text + "',"
                            + "DeptID = '" + DeptID + "',"
                         //   + "Instaff = '" + Convert.ToInt32(CbStaff) + "' "
                            + "where UserID = '" + txtUserId.Text + "'", con);
                            Exc = cmd.ExecuteNonQuery();
                            MessageBox.Show("User Successfully Updated.....");
                            txtfullName.Text = "";
                            //txtPassword.Text = "";
                            //txtRePassword.Text = "";
                            //txtUsername.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Operation Cancel");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Missing Field");
                    }
                }
                catch (Exception ce)
                {
                    MessageBox.Show(ce.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Invalid Request");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int Uuu = 1;
                cmd = new SqlCommand("Select * From UserProfile where UserID = '" + txtUserId.Text + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "UserProfile");
                if (ds.Tables["UserProfile"].Rows.Count < 1)
                {
                    MessageBox.Show(" Invalid key press");

                }
                else
                {
                    DialogResult rs = MessageBox.Show("  Are you Sure? ", "Deleting Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {

                        cmd = new SqlCommand("Update UserProfile Set DeletedProfile = '" + Uuu + "' where UserID = '" + txtUserId.Text + "' ", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("deleted");
                        cmbUserType.Enabled = false;
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnSubmit.Enabled = false;
                        cmbUserType.SelectedIndex = -1;
                    }

                    else
                    {
                        MessageBox.Show("Operation Cancel");
                    }
                }

            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptID = "";
            cmd = new SqlCommand("select * from Department where DeptName ='" + CmbDepartment.Text + "'", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    DeptID = item["DeptID"].ToString();
                }
            }
        }

        private void CmbDepartment_TextChanged(object sender, EventArgs e)
        {
            DeptID = "";
        }

        private void btnLoadUserProfile_Click(object sender, EventArgs e)
        {
            UserTable john = new UserTable();
            john.ConString = conn;
            if (john.ShowDialog() == DialogResult.OK)
            {
                txtUserId.Text = john.gridValueSelected;
                txtfullName.Text = john.gridValueSelected2;
                gridveiwStaff();
            }
           
        }
        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
