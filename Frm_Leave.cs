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
    public partial class Frm_Leave : Form
    {

        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        public Frm_Leave()
        {
            InitializeComponent();
        }

        private void Frm_Leave_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            LoadSTaffList();
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

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStaffId.Text = dtgList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStaffName.Text = dtgList.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertToLeaveTable();
        }

        private void InsertToLeaveTable()
        {
            cmd = new SqlCommand("Insert into Leave  "
                    + "(StaffID, Cat, Ty,FrDate,Tdate,Reason)"
                    + " values (@StaffID, @Cat, "
                    + "@Ty,@FrDate,@Tdate,@Reason)", con);

            cmd.Parameters.AddWithValue("@StaffID", txtStaffId.Text);
            cmd.Parameters.AddWithValue("@Cat", CmbCategory.Text);
            cmd.Parameters.AddWithValue("@Ty", CmbType.Text);
            cmd.Parameters.AddWithValue("@FrDate", DateFrom.Value);
            cmd.Parameters.AddWithValue("@Tdate", dtpTo.Value);
            cmd.Parameters.AddWithValue("@Reason", txtReason.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show(" Leave  has been Approve ");
        }
        private void LoadSTaffList()
        {
            cmd = new SqlCommand("Select UserID,FullName From UserProfile", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
              int  UserID = item.Field<int>("UserID");
              string  Fullname = item.Field<string>("FullName");

                dtgList.Rows.Add(UserID, Fullname);
            }
        }
    }
}
