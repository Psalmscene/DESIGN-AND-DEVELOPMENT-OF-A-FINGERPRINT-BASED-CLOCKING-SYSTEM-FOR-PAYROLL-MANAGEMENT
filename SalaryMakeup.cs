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
    public partial class SalaryMakeup : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;


        public SalaryMakeup()
        {
            InitializeComponent();
        }

        private void SalaryMakeup_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            LoadSalarySetUplistList();
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
        public void LoadSalarySetUplistList()
        {
            try
            {
                dgvDepartment.Rows.Clear();
                cmd = new SqlCommand("select * from SalaryMakeup", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string id = item["ID"].ToString();
                        string Name = item["Sname"].ToString();
                        string Amount = item["Amount"].ToString();

                        dgvDepartment.Rows.Add(id, Name,Amount);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtName.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text != "" && txtName.Text != "")
                {
                    DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(rs.ToString() == "Yes"))
                    {
                        cmd = new SqlCommand("Insert into SalaryMakeup (Sname , Amount ) values "
                                   + "(@U ,@A)", con);
                        cmd.Parameters.AddWithValue("@U", txtName.Text);
                        cmd.Parameters.AddWithValue("@A", txtAmount.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Save");
                        txtName.Clear();
                        txtAmount.Clear();
                        LoadSalarySetUplistList();
                    }
                    else
                    {
                        MessageBox.Show("Operation Cancel");
                        txtName.Clear();
                        txtAmount.Clear();
                        LoadSalarySetUplistList();
                    }
                }
            }
            catch (Exception ce)
            {

               MessageBox.Show("Error Inserting Record");
                txtName.Clear();
                txtAmount.Clear();
                LoadSalarySetUplistList();
            }
      
        }
    }
}
