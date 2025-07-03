using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystemwithFingerprint
{
    public partial class CreatePayroll : Form
    {
        private int StaffSalaryPaidID;
        private int PaySlipID;
        private int SalaryID;
        private int SalaryAmount;
        private int StaffId;

        SqlCommand cmd;
        SqlConnection con;
        public string ConString;

        public string Dpath = @"C:\windows\bolaji\Finger.txt";
        List<string> Lines = new List<string>();

        public string[] strArray = new string[5];
        public string Sqline, conn, Sqlconn;
        StreamReader Sr;
        DateTime CurrentPayrollDate;
        string ResumingTime;
        string ClosingTime;
        private int DeptID;

        List<AttendanceTiming> ListOFtime = new List<AttendanceTiming>();
        List<RecordAttendance.StaffAttendanceList> ListOfStaffAttendance = new List<RecordAttendance.StaffAttendanceList>();
        List<StaffLeave> ListOfStaffOnLeave = new List<StaffLeave>();

        public double LateAMount = 40;
        public double OverAMount =20;
        public int GraceAMount =15;
        public double FullDayDeduction;

        public CreatePayroll()
        {
            InitializeComponent();
        }

        public class AttendanceTiming
        {
            public int DeptID { get; set; }

            public string SResumeTime { get; set; }

            public string SCLosingTime { get; set; }
        }
        public List<AttendanceTiming> GetAttendingTime()
        {
            List<AttendanceTiming> E = new List<AttendanceTiming>();

            cmd = new SqlCommand("select * from Position ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    AttendanceTiming List = new AttendanceTiming();
                    List.DeptID = item.Field<int>("DeptID");
                    List.SResumeTime = item.Field<string>("Rtime");
                    List.SCLosingTime = item.Field<string>("Ctime");

                    E.Add(List);
                }
            }

            return E;
        }


        public class StaffLeave
        {
            public int ID { get; set; }
            public int StaffID { get; set; }

            public string Category { get; set; }

            public string TYpe { get; set; }

            public DateTime FrDate { get; set; }

            public string SFrDate { get; set; }

            public DateTime Tdate { get; set; }

            public string STdate { get; set; }

            public DateTime Dot { get; set; }

        }
        private List<StaffLeave> GetStaffLeaveRecord()
        {
            List<StaffLeave> E = new List<StaffLeave>();

            cmd = new SqlCommand("select * from Leave ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    DateTime dt = item.Field<DateTime>("FrDate");
                 //   string D2 = dt.ToString("dd/MMM/yyyy");

                    DateTime Ddt = item.Field<DateTime>("Tdate");
                 //   string DD2 = dt.ToString("dd/MMM/yyyy");

                  //  DateTime? Cdt = item.Field<DateTime?>("tc");
                   // string CD2 = dt.ToString("dd/MMM/yyyy");

                    StaffLeave List = new StaffLeave();
                    List.TYpe = item.Field<string>("ty");
                    List.Category = item.Field<string>("cat");
                    List.StaffID = item.Field<int>("STaffID");
                    List.ID = item.Field<int>("LeaveID");
                    List.FrDate = dt;
              //      List.SFrDate = D2;
                  //  List.ClosingTime = Cdt;
                  //  List.SCLosingTime = CD2;
                    List.Tdate = Ddt;
               //     List.STdate = DD2;
                    E.Add(List);
                }
            }

            return E;
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
        public List<RecordAttendance.StaffAttendanceList> GetInsertedAttendanceData()
        {
            List<RecordAttendance.StaffAttendanceList> E = new List<RecordAttendance.StaffAttendanceList>();

            cmd = new SqlCommand("select s.AttendanceID, s.StaffID UID,s.DOA, s.TR, s.tc, u.Usertype , u.FullName from StaffAttendance s inner Join UserProfile u on u.UserID = s.StaffID  ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    DateTime dt = item.Field<DateTime>("TR");
                    string D2 = dt.ToString("dd/MMM/yyyy");

                    DateTime Ddt = item.Field<DateTime>("DOA");
                    string DD2 = dt.ToString("dd/MMM/yyyy");

                    DateTime? Cdt = item.Field<DateTime?>("tc");
                    string CD2 = dt.ToString("dd/MMM/yyyy");

                    RecordAttendance.StaffAttendanceList List = new RecordAttendance.StaffAttendanceList();
                    List.StaffName = item.Field<string>("FullName");
                    List.UserTYpe = item.Field<string>("Usertype");
                    List.UserID = item.Field<int>("UID");
                    List.ID = item.Field<int>("AttendanceID");
                    List.ResumeTime = dt;
                    List.SResumeTime = D2;
                    List.ClosingTime = Cdt;
                    List.SCLosingTime = CD2;
                    List.ResumeDate = Ddt;
                    List.SResumeDate = DD2;
                    E.Add(List);
                }
            }

            return E;
        }

        private void CalculateSalary()
        {
           

            foreach (AttendanceTiming item in ListOFtime)
            {
                ClosingTime = item.SCLosingTime;
                ResumingTime = item.SResumeTime;
            }

            DateTime TimeToResume = DateTime.ParseExact(ResumingTime, "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan TTR = TimeToResume.TimeOfDay;
            DateTime TimeToClose = DateTime.ParseExact(ClosingTime, "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan TTC = TimeToClose.TimeOfDay;

            decimal DgVCount = DgvStaffAttendance.Rows.Count;
            getDailySalary = (Convert.ToInt32(txtStaffSalary.Text) / DgVCount);

            for (int i = 1; i < DgvStaffAttendance.Rows.Count; i++)
            {
                // lATENESS VALUE
                DgvStaffAttendance.Rows[i].Cells[4].Value = getDailySalary.ToString();
                string ResumeTimeValue = DgvStaffAttendance.Rows[i].Cells[2].Value.ToString();
                string ClosingTimeValue = DgvStaffAttendance.Rows[i].Cells[3].Value.ToString();

                if (DgvStaffAttendance.Rows[i].Cells[2].Value.ToString() != "" && DgvStaffAttendance.Rows[i].Cells[3].Value.ToString() != "")
                {
                    DateTime ResumeTimeValueDT = DateTime.Parse(ResumeTimeValue);
                    DateTime ClosingTimeValueDT = DateTime.Parse(ClosingTimeValue);

                    string ResumeTimeOnly = ResumeTimeValueDT.ToString("hh:mm tt");
                    string ClosingTimeOnly = ClosingTimeValueDT.ToString("hh:mm tt");

                    DateTime TimeResume = DateTime.ParseExact(ResumeTimeOnly, "hh:mm tt", CultureInfo.InvariantCulture);
                    TimeSpan TR = TimeToResume.TimeOfDay;

                    DateTime TimeClose = DateTime.ParseExact(ClosingTimeOnly, "hh:mm tt", CultureInfo.InvariantCulture);
                    TimeSpan TC = TimeToResume.TimeOfDay;

                    // TimeSpan TimeResume = DateTime.Parse().TimeOfDay;
                    //                    TimeSpan TimeClose = Convert.ToDateTime().TimeOfDay;

                    MessageBox.Show($"time to resume = {TTR.ToString()} , time Resume = {TR.ToString()}");

                    if (DgvStaffAttendance.Rows[i].Cells[2].Value.ToString().ToLower() != "off duty" && DgvStaffAttendance.Rows[i].Cells[3].Value.ToString().ToLower() != "off duty")
                    {
                        //if (TTR > TR)
                        //{
                        //    DgvStaffAttendance.Rows[i].Cells[5].Value = "Late";
                        //}
                        //else
                        //{
                        //    DgvStaffAttendance.Rows[i].Cells[5].Value = "Early";
                        //}
                    }
                }
                else if (DgvStaffAttendance.Rows[i].Cells[2].Value.ToString() == "" && DgvStaffAttendance.Rows[i].Cells[3].Value.ToString() == "")
                {
                    DgvStaffAttendance.Rows[i].Cells[5].Value = "Absent";
                }
                else if (DgvStaffAttendance.Rows[i].Cells[2].Value.ToString() != "" && DgvStaffAttendance.Rows[i].Cells[3].Value.ToString() == "")
                {
                    DgvStaffAttendance.Rows[i].Cells[5].Value = "No Log Out";
                }
            }
        }
        private void LoadAttendanceDataforPayrollcalculation()
        {
            DgvStaffAttendance.Rows.Clear();
            TimeSpan gracePeriod = TimeSpan.FromMinutes(GraceAMount); // Adjustable
            StaffId = Convert.ToInt32(txtStaffId.Text);
            DateTime SelectedMonth = DateFrom.Value;

            string deductionDetails = "No Deduction";
            double TotalDeduction = 0;
            double OvertimeEarnig = 0;
            

            int Year = SelectedMonth.Year;
            int Month = SelectedMonth.Month;
            int DaysInMonth = DateTime.DaysInMonth(Year, Month);

            DateTime StartDate = new DateTime(Year, Month, 1);
            DateTime EndDate = new DateTime(Year, Month, 25); // Stop on 25th

            // 1. Load all required data
            ListOfStaffOnLeave = GetStaffLeaveRecord();
            ListOfStaffAttendance = GetInsertedAttendanceData();
            ListOFtime = GetAttendingTime();

            // 2. Get staff DeptID
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT DeptID FROM UserProfile WHERE UserID = '" + StaffId + "'", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count > 0) DeptID = Convert.ToInt32(dt.Rows[0]["DeptID"]);

            var deptTime = ListOFtime.FirstOrDefault(x => x.DeptID == DeptID);

            DateTime TimeToResume = DateTime.ParseExact(deptTime.SResumeTime, "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan ExpectedStart = TimeToResume.TimeOfDay;
            DateTime TimeToClose = DateTime.ParseExact(deptTime.SCLosingTime, "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan ExpectedClose = TimeToClose.TimeOfDay;


            //TimeSpan ExpectedStart = TimeSpan.Parse(deptTime.SResumeTime);
            //TimeSpan ExpectedClose = TimeSpan.Parse(deptTime.SCLosingTime);

            FullDayDeduction = (Convert.ToDouble(txtStaffSalary.Text) / Convert.ToDouble(DaysInMonth));

            for (int day = 1; day <= DaysInMonth; day++)
            {
                DateTime CurrentDate = new DateTime(Year, Month, day);

                if (CurrentDate.DayOfWeek == DayOfWeek.Saturday || CurrentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    DgvStaffAttendance.Rows.Add("0", CurrentDate.ToString("dd/MMM/yyyy"), "Off Duty", "Off Duty", "Off Duty");
                    continue;
                }
                deductionDetails = "";

                // Check if on leave
                //var leave = ListOfStaffOnLeave.FirstOrDefault(x =>
                //    x.StaffID == StaffId &&
                //    CurrentDate.Date >= x.FrDate.Date &&
                //    CurrentDate.Date <= x.Tdate.Date);
                bool leave = ListOfStaffOnLeave.Any(
                             x => x.StaffID == StaffId &&
                             CurrentDate.Date >= x.FrDate.Date && CurrentDate.Date
                             <= x.Tdate.Date);
            
                if (leave)
                {
                    //string leaveType = leave.TYpe == "Paid" ? "Paid Leave" : "Unpaid Leave";
                    //string deduction = leave.TYpe == "Unpaid" ? "Full Day Deducted" : "No Deduction";

                    DgvStaffAttendance.Rows.Add("0", CurrentDate.ToString("dd/MMM/yyyy"), "On Leave", "On Leave", "On Leave");
                    continue;
                }
                //else
                //{
                //    MessageBox.Show("No Record");
                //}

                // Check if attendance exists
                var att = ListOfStaffAttendance.FirstOrDefault(x =>
                    x.UserID == StaffId && x.ResumeDate.Date == CurrentDate.Date);

                TimeSpan lateByOrEarlyBy;
                string lateByOrEarlyByValue ="";

                TimeSpan GoHome;
                string GoHomeValue = "";

                if (att != null)
                {
                    TimeSpan actualStart = att.ResumeTime.TimeOfDay;
                    TimeSpan actualClose = att.ClosingTime.HasValue ? att.ClosingTime.Value.TimeOfDay : TimeSpan.Zero;

                    //check for EarlyResumption
                    if (actualStart < ExpectedStart)
                    {
                        lateByOrEarlyBy = ExpectedStart - actualStart;
                        double EarlyOverTime = lateByOrEarlyBy.TotalMinutes * OverAMount; // Example rate: ₦2 per min late
                        OvertimeEarnig += EarlyOverTime;
                        int RoundUp = (int)lateByOrEarlyBy.TotalMinutes;
                        deductionDetails = $"Early by {RoundUp} mins ";
                        lateByOrEarlyByValue = $"{RoundUp} mins Early";
                    }
                   
                    //check for lateness
                    if (actualStart > ExpectedStart)
                    {
                        if (actualStart > ExpectedStart.Add(gracePeriod))
                        {
                            lateByOrEarlyBy = actualStart - ExpectedStart;
                            double deductionAmount = lateByOrEarlyBy.TotalMinutes * LateAMount; // Example rate: ₦2 per min late                       
                            TotalDeduction += deductionAmount;
                            int RoundUp = (int)lateByOrEarlyBy.TotalMinutes;
                          //  deductionDetails = $"Late by {RoundUp} mins ";
                            lateByOrEarlyByValue = $"{RoundUp} mins Late";

                      
                        }
                        else
                        {
                            lateByOrEarlyByValue = $"Safe";
                        }
                         
                    }

                    // check for Early closing
                    if (actualClose < ExpectedClose)
                    {
                        GoHome = ExpectedClose - actualClose;
                        double deductionAmount = GoHome.TotalMinutes * LateAMount;
                        TotalDeduction += deductionAmount;
                        // deductionDetails += $"Left Early by {earlyLeave.TotalMinutes:N0} mins - Deducted ₦{deductionAmount:N2}";
                        int RoundUp = (int)GoHome.TotalMinutes;
                     //   deductionDetails = $"Left {RoundUp} mins ";
                        GoHomeValue = $"Left {RoundUp} mins Early";

                    }

                    //check for late closing
                    if (actualClose > ExpectedClose)
                    {
                        GoHome =   actualClose - ExpectedClose;
                        double EarlyOverTime = GoHome.TotalMinutes *OverAMount;
                        OvertimeEarnig += EarlyOverTime;

                        int RoundUp = (int)GoHome.TotalMinutes;
                        //   deductionDetails = $"Left {RoundUp} mins ";
                        GoHomeValue = $"{RoundUp} mins Of overtime";
                        //deductionDetails += $", Overtime {Overtime.TotalMinutes:N0} mins - Over ₦{EarlyOverTime:N2}";
                    }

                  //  MessageBox.Show(TotalDeduction);

                    DgvStaffAttendance.Rows.Add(
                        att.ID,
                        CurrentDate.ToString("dd/MMM/yyyy"),
                        ExpectedStart,
                        att.ResumeTime.ToString("hh:mm tt"),
                        lateByOrEarlyByValue,
                        ExpectedClose,
                        att.ClosingTime?.ToString("hh:mm tt") ?? "Not Clocked Out",
                        GoHomeValue,
                        deductionDetails
                    );
                }
                else
                {
                    DgvStaffAttendance.Rows.Add("0", CurrentDate.ToString("dd/MMM/yyyy"), "Absent", "Absent", "Absent");
                    TotalDeduction += FullDayDeduction;
                }
                txtOverTime.Text = OvertimeEarnig.ToString("F2");
                TxtTotalLateness.Text = TotalDeduction.ToString("F2");
            }

            double Totalsalary = Convert.ToDouble(txtStaffSalary.Text);
            double Overtime = Convert.ToDouble(txtOverTime.Text);
            double LateFee = Convert.ToDouble(TxtTotalLateness.Text);
            double ReTotalsalary = (Totalsalary + Overtime) - LateFee;

            txtExpectedSalary.Text = ReTotalsalary.ToString("0.00");
        }

        //private void LoadAttendanceDataforPayrollcalculation()
        //{
        //    DgvStaffAttendance.Rows.Clear();
        //    TimeSpan gracePeriod = TimeSpan.FromMinutes(15);

        //    StaffId = Convert.ToInt32(txtStaffId.Text);
        //    DateTime SelectedMonth = DateFrom.Value;

        //    int Year = SelectedMonth.Year;
        //    int month = SelectedMonth.Month;
                
        //    int daysInaMonth = DateTime.DaysInMonth(Year, month);



        //    for (int day = 1; day <= daysInaMonth; day++)
        //    {
        //        DateTime CurrentDate = new DateTime(Year, month, day);

        //        if (CurrentDate.DayOfWeek == DayOfWeek.Saturday || CurrentDate.DayOfWeek == DayOfWeek.Sunday)
        //        {
        //            string ID = "0";
        //            string Resume = "Off Duty";
        //            DgvStaffAttendance.Rows.Add(
        //                     ID,
        //                     CurrentDate,
        //                     Resume,
        //                     Resume);                  
        //        }
        //        else
        //        {
        //            ListOfStaffOnLeave = GetStaffLeaveRecord();
        //            ListOfStaffAttendance = GetInsertedAttendanceData();
        //            bool hasAttendance = ListOfStaffAttendance.Any(x => x.UserID == StaffId &&
        //            x.ResumeDate == CurrentDate.Date);

        //            SqlDataAdapter cmd = new SqlDataAdapter("Select * from  Userprofile where UserID = "
        //             + " '" + txtStaffId.Text + "'", conn);
        //            DataTable dt = new DataTable();
        //            cmd.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    DeptID = Convert.ToInt32(dt.Rows[i]["DeptID"].ToString());
        //                }
        //            }

        //            ListOFtime = GetAttendingTime();
        //            ListOFtime = ListOFtime.Where(x => x.DeptID == DeptID).ToList();

        //            if (hasAttendance)
        //            {
        //                ListOfStaffAttendance = ListOfStaffAttendance.Where(x => x.UserID == StaffId &&
        //                x.ResumeDate == CurrentDate.Date).ToList();

        //                if (ListOfStaffAttendance.Count == 1)
        //                {
        //                    foreach (RecordAttendance.StaffAttendanceList item in ListOfStaffAttendance)
        //                    {
                              
                                
        //                        DgvStaffAttendance.Rows.Add(
        //                            item.ID,
        //                            item.ResumeDate,
        //                            item.ResumeTime,
        //                            item.ClosingTime);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //    MessageBox.Show("checking for leave");
        //                //CHECK TO SEE RECORD FROM THAT EXACT MONTH AND YEAR.
        //                bool LeaveForSelectedMonthExist = ListOfStaffOnLeave.Any(
        //                     x => x.StaffID == StaffId &&
        //                     CurrentDate.Date >= x.FrDate.Date && CurrentDate.Date
        //                     <= x.Tdate.Date);

        //                if (LeaveForSelectedMonthExist)
        //                {
        //                    string ID = "0";
        //                    string Resume = "On Leave";
        //                    DgvStaffAttendance.Rows.Add(
        //                             ID,
        //                             CurrentDate,
        //                             Resume,
        //                             Resume);
        //                }
        //                else
        //                {
        //                    string ID = "0";
        //                    string Resume = "";
        //                    DgvStaffAttendance.Rows.Add(
        //                             ID,
        //                             CurrentDate,
        //                             Resume,
        //                             Resume);
        //                }
        //            }
        //        }
        //    }
        //}
        private void CreatePayroll_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
            txtMonth.Text = DateFrom.Value.ToString("MMMM");
            textBox1.Text = DateFrom.Value.ToString("yyyy");

            gridveiwPaySlip();
            gridveiw();
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
                        LateAMount = Convert.ToDouble(item["LateFee"].ToString());
                        GraceAMount = Convert.ToInt32(item["GracePeriod"].ToString());
                        OverAMount = Convert.ToDouble(item["OverAMount"].ToString());
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        public void gridveiw()
        {
            try
            {
                dtgList.Rows.Clear();
                int mfd = 0;
                cmd = new SqlCommand("select s.StaffSalaryPaidID, s.SalaryID, s.StaffID ,p.FullName from StaffSalaryPaid_Record s"
                    + " inner join UserProfile p on s.StaffID = p.UserID "
                    + "where s.PaySlipID = '" + PaySlipID + "' and TransactionStatus = '" + mfd + "'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Rows)
                    {
                        string StaffID = item.Field<string>("StaffID");
                        string Staffname = item.Field<string>("FullName");
                        StaffSalaryPaidID = item.Field<int>("StaffSalaryPaidID");
                        int Amount = item.Field<int>("SalaryID");
                        dtgList.Rows.Add(StaffID, Staffname, StaffSalaryPaidID, Amount);
                    }
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        public void gridveiwPaySlip()
        {
            try
            {
                int Mfd = 0;
                cmd = new SqlCommand("select * from Paysip where Dyear = '" + textBox1.Text + "' and MFD = '" + Mfd + "' "
                  + "  and DStatus ='" + Mfd + "' and DMonth ='" + txtMonth.Text + "'", con);
                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adb.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    button1.Enabled = false;
                    foreach (DataRow item in ds.Rows)
                    {
                        PaySlipID = item.Field<int>("PaySlipID");
                        CurrentPayrollDate = item.Field<DateTime>("DateOfCreate");
                    }
                }
                else
                {
                    button1.Enabled = true;
                    PaySlipID = 0;
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            txtMonth.Text = DateFrom.Value.ToString("MMMM");
            textBox1.Text = DateFrom.Value.ToString("yyyy");

            gridveiwPaySlip();
            gridveiw();
        }
        private int STaffCount;
        private void GetcountOfStaff()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * from  Userprofile ", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            STaffCount = dt.Rows.Count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count (*) from PaySip", con);
                int b = Convert.ToInt32(cmd.ExecuteScalar());
                if (b == 0)
                {
                    PaySlipID = 1001;
                }
                else
                {
                    cmd = new SqlCommand("select max(PaySlipID) from PaySip", con);
                    int a = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    PaySlipID = a;
                }

                if (txtMonth.Text != "")
                {
                    GetcountOfStaff();
                    //if (SalaryCount  != STaffCount)
                    //{
                    //    MessageBox.Show("Some Staff Salary is Missing");
                    //}
                    //else
                    //{
                    cmd = new SqlCommand("Insert into PaySip  "
                          + "(PaySlipID, DMonth,DYear)"
                          + "values (@PaySlipID,"
                          + "@DMonth,@DYear)", con);

                    cmd.Parameters.AddWithValue("@PaySlipID", PaySlipID);
                    cmd.Parameters.AddWithValue("@DMonth", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@DYear", textBox1.Text);
                    cmd.ExecuteNonQuery();


                    int UsingStatus = 0;
                    cmd = new SqlCommand("Select SalaryID, StaffID,NetSalary From Salary "
                        + "where UsingStatus = '"+UsingStatus+"' ", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    int SalaryCount = dt.Rows.Count;

             
                        foreach (DataRow item in dt.Rows)
                        {
                            SalaryID = item.Field<int>("SalaryID");
                            StaffId = item.Field<int>("StaffID");
                            SalaryAmount = item.Field<int>("NetSalary");

                            cmd = new SqlCommand("Insert into StaffSalaryPaid_Record  "
                                 + "(StaffID, SalaryID, PaySlipID)"
                                 + "values (@StaffID, @SalaryID, "
                                 + "@PaySlipID)", con);

                            cmd.Parameters.AddWithValue("@StaffID", StaffId);
                            cmd.Parameters.AddWithValue("@SalaryID", SalaryID);

                            cmd.Parameters.AddWithValue("@PaySlipID", PaySlipID);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show(" Payslip List has been Generarted ");
                        gridveiwPaySlip();
                        gridveiw();
                   // }
                }
                else
                {
                    MessageBox.Show("  Missing Info  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message.ToString());
            }
        }
        private decimal getDailySalary;

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Salary = Convert.ToInt32(txtStaffSalary.Text);
            decimal TotalLateFee = Math.Truncate(Convert.ToDecimal(TxtTotalLateness.Text));
            decimal TotalOverTime = Math.Truncate(Convert.ToDecimal(txtOverTime.Text));
            decimal Bal = Math.Truncate(Convert.ToDecimal(txtExpectedSalary.Text));

            //try
            //{
            int RowExec = 0;
            if (txtStaffName.Text != "" && txtStaffId.Text != "")
            {
                if (Convert.ToInt32(txtStaffSalary.Text) != 0 && Convert.ToInt32(txtStaffSalary.Text) != 0)
                {
                    using (SqlConnection con1 = new SqlConnection(conn))
                    {
                        con1.Open();
                        using (SqlTransaction tran = con1.BeginTransaction())
                        {
                            DialogResult rs = MessageBox.Show(" Do you Still Want to continue", "Saving Record", MessageBoxButtons.YesNo);
                            if (Convert.ToBoolean(rs.ToString() == "Yes"))
                            {
                                int mfd = 1;
                                RowExec = 0;
                                cmd = new SqlCommand("Update StaffSalaryPaid_Record set "
                                    + " OverTime ='" + TotalOverTime + "', "
                                     + " LateFee ='" + TotalLateFee + "', "
                                     + " TransactionStatus ='" + mfd + "', "
                                     + " TotalAmountPaid ='" + Bal + "' "
                                    + "where StaffSalaryPaidID = '" + txtStaffPayID.Text + "' ", con1, tran);
                                RowExec = cmd.ExecuteNonQuery();

                                string Closed;
                                    RowExec = 0;
                                foreach (DataGridViewRow item in DgvStaffAttendance.Rows)
                                {
                                    if (item.Cells[0].Value != null)
                                    {
                                     //   MessageBox.Show(item.Cells[7].Value.ToString());
                                        if (item.Cells[7].Value == null)
                                        {
                                            Closed = "No Clock Out";
                                        }
                                        else
                                        {
                                            Closed = item.Cells[7].Value.ToString();
                                        }
                                       
                                        cmd = new SqlCommand("Insert into AttendanceBreakDown "
                                            + " (PayrollID,Tdate, Resumed,Closed,OverTime,LateFee) values "
                                        + " (@PayrollID, @Tdate, @Resumed,@Closed,@OverTime,@LateFee)", con);
                                        cmd.Parameters.AddWithValue("@PayrollID", txtStaffPayID.Text);
                                        cmd.Parameters.AddWithValue("@Tdate", item.Cells["Tdate"].Value.ToString());
                                        cmd.Parameters.AddWithValue("@Resumed", item.Cells["R"].Value.ToString());
                                        cmd.Parameters.AddWithValue("@Closed", Closed);
                                        cmd.Parameters.AddWithValue("@OverTime", OverAMount);
                                        cmd.Parameters.AddWithValue("@LateFee", LateAMount);
                                        RowExec = cmd.ExecuteNonQuery();
                                    }
                                }

                                if (RowExec > 0)
                                {
                                    tran.Commit();
                                    MessageBox.Show("Sucessfull......", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TxtTotalLateness.Text = "0";
                                    txtStaffSalary.Text = "0";
                                    txtStaffId.Clear();
                                    txtStaffName.Clear();
                                    txtOverTime.Text = "0";
                                    txtExpectedSalary.Text = "0";
                                    //  GridviewDeduction();
                                    gridveiw();
                                    DgvStaffAttendance.Rows.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("transaction error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else

                            {
                                MessageBox.Show("Operation Cancel", "Canceling", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Invalid Request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //}
            //catch (Exception ce)
            //{
            //    MessageBox.Show("Comint Excepction type :" + ce.GetType() + ce.Message.ToString());
            //}

        }

        private void getSalaryAmount()
        {
      
            cmd = new SqlCommand("select * from Salary where SalaryID = '" + txtSalaryID.Text + "' ", con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adb.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    txtStaffSalary.Text = item.Field<int>("NetSalary").ToString();
                }
            }
        }
   
        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStaffId.Text = dtgList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStaffName.Text = dtgList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStaffPayID.Text = dtgList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSalaryID.Text = dtgList.Rows[e.RowIndex].Cells[3].Value.ToString();
            getSalaryAmount();
            LoadAttendanceDataforPayrollcalculation();
          
        //   CalculateSalary();

        }
    }
}
