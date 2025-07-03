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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        public string ConString;
        private string DeptID;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDept.Clear();
            DeptID = "";
            button1.Text = "Create";
        }
        public void LoadDepartmentList()
        {
            try
            {
                dgvNewProduct.Rows.Clear();
                cmd = new SqlCommand("select * from Department where mfd = 0 ", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string ProductID = item["DeptID"].ToString();
                        string ProductName = item["DeptName"].ToString();

                        dgvNewProduct.Rows.Add(ProductID, ProductName);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDept.Text != "")
            {

                cmd = new SqlCommand(" Select * from Department where DeptName = @U", con);
                cmd.Parameters.AddWithValue("@U", txtDept.Text);
                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Deptment already Exist");
                }
                else
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        if (button1.Text == "Update")
                        {
                            cmd = new SqlCommand("Update Department set DeptName = "
                          + "(@U) where DeptID = @A", con);
                            cmd.Parameters.AddWithValue("@U", txtDept.Text);
                            cmd.Parameters.AddWithValue("@A", DeptID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Department Updated", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDept.Clear();
                            LoadDepartmentList();
                            button1.Text = "Create";
                        }
                        else
                        {

                            cmd = new SqlCommand("Insert into Department (DeptName) values "
                                   + "(@U)", con);
                            cmd.Parameters.AddWithValue("@U", txtDept.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Department Created", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDept.Clear();
                            LoadDepartmentList();
                            button1.Text = "Create";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operation Cancel");
                    }
                }

            }
            else
            {
                MessageBox.Show("Empty Field");
                txtDept.Clear();
                txtDept.Focus();
            }
        }

        private void dgvNewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeptID = dgvNewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDept.Text = dgvNewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (DeptID !="")
            {
                button1.Text = "Update";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // when delete check to see if staff are associated with department;
            if (txtDept.Text != "" && DeptID !="")
            {

                cmd = new SqlCommand(" Select * from Department where DeptID = @U", con);
                cmd.Parameters.AddWithValue("@U", DeptID);
                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        cmd = new SqlCommand(" Select * from UserProfile where DeptID = @U", con);
                        cmd.Parameters.AddWithValue("@U", DeptID);
                        SqlDataAdapter Adp1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Adp1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            MessageBox.Show("Staffs Are Still Operational in Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            cmd = new SqlCommand("Update  Department set mfd = 1 where DeptID = @U", con);
                            cmd.Parameters.AddWithValue("@U", DeptID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Department Deleted", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDept.Clear();
                            LoadDepartmentList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operation Cancel");
                    }
                }
                else
                {
                    MessageBox.Show("Department Does Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        private void Department_Load(object sender, EventArgs e)
        {
            DeptID = "";
            DatabaseConnection();
            LoadDepartmentList();
        }
    }
}
