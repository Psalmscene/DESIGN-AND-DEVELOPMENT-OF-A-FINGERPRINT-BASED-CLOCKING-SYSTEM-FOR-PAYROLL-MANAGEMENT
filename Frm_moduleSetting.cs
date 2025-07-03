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
    public partial class Frm_moduleSetting : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;
        string Id;

        public Frm_moduleSetting()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void Frm_moduleSetting_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            GridviewProduct();
        }

        public void GridviewProduct()
        {
            try
            {
                cmd = new SqlCommand("select * from ModuleSetting ", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                 
                    foreach (DataRow item in ds.Rows)
                    {
                       Id = item["ID"].ToString();
                       txtLateFee.Text = item["LateFee"].ToString();
                        txtGracePeriod.Text = item["GracePeriod"].ToString();
                        txtOverAmount.Text = item["OverAMount"].ToString();
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
            int St = 1;
            if (txtGracePeriod.Text != "" && txtLateFee.Text != "" && txtOverAmount.Text != "")
            {
                cmd = new SqlCommand("Update ModuleSetting Set "
                    +" GracePeriodValue = '" + St + "', "
                    + " GracePeriod = '" + txtGracePeriod.Text + "', "
                     + " OverAMount = '" + txtOverAmount.Text + "' ,"
                      + " LateFee = '" + txtLateFee.Text + "' "
                    + " where ID = '" + Id + "' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucessfully Updated");

            }

        }
    }
}
