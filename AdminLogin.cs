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
using System.Data.SqlClient;
using System.IO;

namespace PayrollSystemwithFingerprint
{

    public partial class AdminLogin : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        
        public AdminLogin()
        {
            InitializeComponent();
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
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            DatabaseConnection();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNetSalary.Text) > 0 && Convert.ToInt32(txtBasicSalary.Text) > 0)
            {
                cmd = new SqlCommand("select * from Salary where StaffID = '" + txtUserId.Text + "' ", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adb.Fill(ds, "Salary");
                if (ds.Tables["Salary"].Rows.Count > 0)
                {
                    MessageBox.Show("Salary Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Text = "0";
                    txtFeeding.Text = "0";
                    txtHealth.Text = "0";
                    txtTransportation.Text = "0";
                    txtUserId.Clear();
                    txtfullName.Clear();
                }
                else
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Salary (StaffID,BasicSalary,Health,feeding,Transportation )"
                                 + " values (@StaffID,@BasicSalary,@Health,@feeding,@Transportation)", con);
                        cmd1.Parameters.AddWithValue("@StaffID", txtUserId.Text);
                        cmd1.Parameters.AddWithValue("@BasicSalary", txtBasicSalary.Text);
                        cmd1.Parameters.AddWithValue("@Health", txtHealth.Text);
                        cmd1.Parameters.AddWithValue("@feeding", txtFeeding.Text);
                        cmd1.Parameters.AddWithValue("@Transportation", txtTransportation.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Data Sucessfully Created", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panel1.Enabled = true;
                        txtBasicSalary.Text = "0";
                        txtFeeding.Text = "0";
                        txtHealth.Text = "0";
                        txtTransportation.Text = "0";
                        txtUserId.Clear();
                        txtfullName.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Operation Cancel");
                    }
                }
            }
            else
            {
                MessageBox.Show("Salary Connot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            if (txtBasicSalary.Text == "")
            {
                txtBasicSalary.Text = "0";
            }
            CalculateNetSalary();
        }

        private void txtTransportation_TextChanged(object sender, EventArgs e)
        {
            if (txtTransportation.Text == "")
            {
                txtTransportation.Text = "0";
            }
            CalculateNetSalary();
        }

        private void txtFeeding_TextChanged(object sender, EventArgs e)
        {
            if (txtFeeding.Text == "")
            {
                txtFeeding.Text = "0";
            }
            CalculateNetSalary();
        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {
            if (txtHealth.Text == "")
            {
                txtHealth.Text = "0";
            }
            CalculateNetSalary();
        }

        private void CalculateNetSalary()
        {
            int BasicSalary = Convert.ToInt32(txtBasicSalary.Text);
            int Feeding = Convert.ToInt32(txtFeeding.Text);
            int Health = Convert.ToInt32(txtHealth.Text);
            int transportation = Convert.ToInt32(txtTransportation.Text);

            int NetSalary = BasicSalary + Feeding + Health + transportation;

            txtNetSalary.Text = NetSalary.ToString();

        }
      

        private void btnLoadUserProfile_Click(object sender, EventArgs e)
        {
            UserTable john = new UserTable();
            john.ConString = conn;
            if (john.ShowDialog() == DialogResult.OK)
            {
                txtUserId.Text = john.gridValueSelected;
                txtfullName.Text = john.gridValueSelected2;
                panel1.Enabled = true;
            }
        }
    }
}
