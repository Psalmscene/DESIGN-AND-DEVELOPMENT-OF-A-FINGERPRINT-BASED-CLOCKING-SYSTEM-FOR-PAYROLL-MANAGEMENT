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
    public partial class StaffSalarySetUp : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        public string ConString;
        private string DeptID;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;

        private int NetSalary;
        private int BasicSalary;
        private int Sum;
        private int StaffSalaryID;
        private int dOaCTION;
        public StaffSalarySetUp()
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

        private void btnLoadUserProfile_Click(object sender, EventArgs e)
        {
            TxtBasicSalary.Text = "0";
            txtNetSalary.Text = "0";
            dgvDepartment.Rows.Clear();
            txtUserId.Clear();
            txtfullName.Clear();
            txtDepartment.Text = "";
            //  cmbPosition.Items.Clear();
          

            UserTable john = new UserTable();
            john.ConString = conn;
            if (john.ShowDialog() == DialogResult.OK)
            {
                txtUserId.Text = john.gridValueSelected;
                txtfullName.Text = john.gridValueSelected2;
                txtDepartment.Text = john.gridValueSelected4;
            }

            if (txtUserId.Text !="")
            {
                cmd = new SqlCommand("select * from Department where DeptName ='" + txtDepartment.Text + "'", con);
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
                LoadPositionList();
                try
                {
                    int UsingStatus = 0;
                    dOaCTION = 1;
                    cmd = new SqlCommand("select * from Salary where StaffID = '" + txtUserId.Text + "' "
                         + " and UsingStatus = '" + UsingStatus + "' ", con);
                    SqlDataAdapter adb1 = new SqlDataAdapter(cmd);
                    DataTable ds1 = new DataTable();
                    adb1.Fill(ds1);
                    if (ds1.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds1.Rows)
                        {
                            StaffSalaryID = Convert.ToInt32(item["SalaryID"].ToString());
                            TxtBasicSalary.Text = item["BasicSalary"].ToString();
                            txtNetSalary.Text = item["NetSalary"].ToString();
                            cmbPosition.SelectedItem = item["Pname"].ToString();

                            button1.Text = "Update Record";
                        }
                        LoadSalarySetUpSavedList();
                      
                    }
                    else
                    {
                        dOaCTION = 0;
                        LoadPositionList();
                        button1.Text = "Save Record";
                    }
                }
                catch (Exception ce)
                {
                    MessageBox.Show(ce.Message.ToString());
                }
            }                      
        }

        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StaffSalarySetUp_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            dOaCTION = 0;
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dOaCTION ==0)
            {
                cmd = new SqlCommand("select * from Position where PName = '" + cmbPosition.Text + "'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        TxtBasicSalary.Text = item["SalaryAmount"].ToString();
                        LoadSalarySetUplistList();
                        BasicSalary = Convert.ToInt32(TxtBasicSalary.Text);


                        Sum = BasicSalary;
                        foreach (DataGridViewRow I in dgvDepartment.Rows)
                        {

                            if (I.Cells[0].Value != null)
                            {
                                Sum = Sum + Convert.ToInt32(I.Cells[2].Value);
                            }
                        }

                        txtNetSalary.Text = Sum.ToString();

                    }
                }
            }
            
        }

        private void TxtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            BasicSalary = Convert.ToInt32(TxtBasicSalary.Text);
         

            Sum = BasicSalary;
            foreach (DataGridViewRow item in dgvDepartment.Rows)
            {

                if (item.Cells[0].Value != null)
                {
                    Sum = Sum + Convert.ToInt32(item.Cells[2].Value);
                }
            }

            txtNetSalary.Text = Sum.ToString();

        }

        private void dgvDepartment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Sum = BasicSalary;
                int Row = dgvDepartment.CurrentRow.Index;
                if (dgvDepartment[2, Row].Value.ToString() == "" )
                {
                    dgvDepartment[2, Row].Value = 0;
                   
                    foreach (DataGridViewRow item in dgvDepartment.Rows)
                    {

                        if (item.Cells[0].Value != null)
                        {
                            Sum = Sum + Convert.ToInt32(item.Cells[2].Value);
                        }
                    }

                    txtNetSalary.Text = Sum.ToString();
                }
                else
                {
                    foreach (DataGridViewRow item in dgvDepartment.Rows)
                    {

                        if (item.Cells[0].Value != null)
                        {
                            Sum = Sum + Convert.ToInt32(item.Cells[2].Value);
                        }
                    }

                    txtNetSalary.Text = Sum.ToString();
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string STaffSalary = "";
            cmd = new SqlCommand("select count (*) from Salary", con);
            int b = Convert.ToInt32(cmd.ExecuteScalar());
            if (b == 0)
            {
                STaffSalary = "1001";
            }
            else
            {
                cmd = new SqlCommand("select max(SalaryID) from Salary", con);
                int a = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                STaffSalary = a.ToString();
            }

            int UsingStatus = 0;
            if (Convert.ToInt32(txtNetSalary.Text) > 0 && Convert.ToInt32(TxtBasicSalary.Text) > 0
                && txtUserId.Text !="")
            {
                using (SqlConnection con1 = new SqlConnection(conn))
                {
                    con1.Open();
                    using (SqlTransaction tran = con1.BeginTransaction())
                    {
                        int RowExec = 0;

                        SqlCommand cmd1 = new SqlCommand("insert into Salary (SalaryID,StaffID,BasicSalary,NetSalary,Pname)"
                                    + " values (@SalaryID,@StaffID,@BasicSalary,@Health,@Pname)", con1, tran);
                        cmd1.Parameters.AddWithValue("@SalaryID", STaffSalary);
                        cmd1.Parameters.AddWithValue("@StaffID", txtUserId.Text);
                        cmd1.Parameters.AddWithValue("@BasicSalary", TxtBasicSalary.Text);
                        cmd1.Parameters.AddWithValue("@Health", txtNetSalary.Text);
                        cmd1.Parameters.AddWithValue("@Pname", cmbPosition.Text);
                        RowExec = cmd1.ExecuteNonQuery();

                        RowExec = 0;
                        int RegStat = 1;

                        SqlCommand cmd = new SqlCommand("Update  UserProfile Set RegStatus = @RS where "
                            + " UserID = @StaffName", con);
                        cmd.Parameters.AddWithValue("@StaffName", txtUserId.Text);
                        cmd.Parameters.AddWithValue("@RS", RegStat);
                        RowExec = cmd.ExecuteNonQuery();
              


                        foreach (DataGridViewRow item in dgvDepartment.Rows)
                        {
                            if (item.Cells[0].Value != null)
                            {
                                RowExec = 0;
                                cmd = new SqlCommand("Insert into StaffSalaryMakeup ( StaffSalaryID,Sname,Amount) "
                                + "values (@StaffSalaryID,@Sname,@Amount)", con1, tran);
                                cmd.Parameters.AddWithValue("@StaffSalaryID", STaffSalary);
                                cmd.Parameters.AddWithValue("@Sname", item.Cells[0].Value.ToString());
                                cmd.Parameters.AddWithValue("@Amount", item.Cells[2].Value.ToString());
                                RowExec = cmd.ExecuteNonQuery();
                            }
                        }

                        if (button1.Text.ToLower() == "update record")
                        {
                            RowExec = 0;
                            int RegStatus = 1;
                            SqlCommand cmd4 = new SqlCommand("Update Salary Set UsingStatus = @RS where "
                                + " SalaryID = @StaffName", con1, tran);
                            cmd4.Parameters.AddWithValue("@StaffName", StaffSalaryID);
                            cmd4.Parameters.AddWithValue("@RS", RegStatus);
                            RowExec = cmd4.ExecuteNonQuery();
                        }

                        if (RowExec > 0)
                        {
                            DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                            if (Convert.ToBoolean(rs.ToString() == "Yes"))
                            {
                                tran.Commit();
                                MessageBox.Show("Data Sucessfully Saved", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TxtBasicSalary.Text = "0";
                                txtNetSalary.Text = "0";
                                dgvDepartment.Rows.Clear();
                                txtUserId.Clear();
                                txtfullName.Clear();
                                txtDepartment.Text = "";
                                cmbPosition.Items.Clear();
                            }
                            else
                            {
                                tran.Rollback();
                                MessageBox.Show("Operation Cancel");
                            }
                        }
                        else
                        {
                            tran.Rollback();
                            MessageBox.Show("transaction error");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Salary Connot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
        public void LoadSalarySetUpSavedList()
        {
            try
            {
                dgvDepartment.Rows.Clear();
                cmd = new SqlCommand("select s.ID I , m.Sname U , s.Amount from StaffSalaryMakeup s inner join salarymakeup m on m.id = s.sname  "
                    +"  where  s.StaffSalaryID ='"+StaffSalaryID+"'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string id = item["I"].ToString();
                        string Name = item["U"].ToString();
                        string Amount = item["Amount"].ToString();

                        dgvDepartment.Rows.Add(id, Name, Amount);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDepartment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtfullName_TextChanged(object sender, EventArgs e)
        {

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

                        dgvDepartment.Rows.Add(id, Name, Amount);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        public void LoadPositionList()
        {
            try
            {
                cmbPosition.Items.Clear();
                cmd = new SqlCommand("select * from Position where DeptID = '" + DeptID + "'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string Pos = item["PName"].ToString();
                        cmbPosition.Items.Add(Pos);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

    }
}
