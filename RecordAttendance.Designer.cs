namespace PayrollSystemwithFingerprint
{
    partial class RecordAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordAttendance));
            this.ckTimetime = new System.Windows.Forms.CheckBox();
            this.CkSendTime = new System.Windows.Forms.CheckBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckSendData = new System.Windows.Forms.CheckBox();
            this.ckReset = new System.Windows.Forms.CheckBox();
            this.CmbReader = new System.Windows.Forms.ComboBox();
            this.tmmmm = new System.Windows.Forms.Label();
            this.TodayDay = new System.Windows.Forms.Label();
            this.AmOrPm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ckTimetime
            // 
            this.ckTimetime.AutoSize = true;
            this.ckTimetime.Location = new System.Drawing.Point(35, 479);
            this.ckTimetime.Name = "ckTimetime";
            this.ckTimetime.Size = new System.Drawing.Size(87, 21);
            this.ckTimetime.TabIndex = 79;
            this.ckTimetime.Text = "checkBox1";
            this.ckTimetime.UseVisualStyleBackColor = true;
            this.ckTimetime.Visible = false;
            this.ckTimetime.CheckedChanged += new System.EventHandler(this.ckTimetime_CheckedChanged);
            // 
            // CkSendTime
            // 
            this.CkSendTime.AutoSize = true;
            this.CkSendTime.Location = new System.Drawing.Point(35, 455);
            this.CkSendTime.Name = "CkSendTime";
            this.CkSendTime.Size = new System.Drawing.Size(87, 21);
            this.CkSendTime.TabIndex = 77;
            this.CkSendTime.Text = "checkBox1";
            this.CkSendTime.UseVisualStyleBackColor = true;
            this.CkSendTime.Visible = false;
            this.CkSendTime.CheckedChanged += new System.EventHandler(this.CkSendTime_CheckedChanged);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(431, 396);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(146, 19);
            this.lblWelcome.TabIndex = 32;
            this.lblWelcome.Text = "Welcome";
            // 
            // lblStaffID
            // 
            this.lblStaffID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffID.Location = new System.Drawing.Point(432, 425);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(146, 19);
            this.lblStaffID.TabIndex = 31;
            this.lblStaffID.Text = "..";
            // 
            // lblStaffName
            // 
            this.lblStaffName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(432, 457);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(146, 19);
            this.lblStaffName.TabIndex = 30;
            this.lblStaffName.Text = "..";
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.Location = new System.Drawing.Point(678, 267);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(184, 209);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFingerprint.TabIndex = 29;
            this.pbFingerprint.TabStop = false;
            this.pbFingerprint.Click += new System.EventHandler(this.pbFingerprint_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(528, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Put your Finger On The Scanner";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckSendData
            // 
            this.ckSendData.AutoSize = true;
            this.ckSendData.Location = new System.Drawing.Point(36, 433);
            this.ckSendData.Name = "ckSendData";
            this.ckSendData.Size = new System.Drawing.Size(87, 21);
            this.ckSendData.TabIndex = 76;
            this.ckSendData.Text = "checkBox1";
            this.ckSendData.UseVisualStyleBackColor = true;
            this.ckSendData.Visible = false;
            this.ckSendData.CheckedChanged += new System.EventHandler(this.ckSendData_CheckedChanged);
            // 
            // ckReset
            // 
            this.ckReset.AutoSize = true;
            this.ckReset.Location = new System.Drawing.Point(36, 413);
            this.ckReset.Name = "ckReset";
            this.ckReset.Size = new System.Drawing.Size(87, 21);
            this.ckReset.TabIndex = 75;
            this.ckReset.Text = "checkBox1";
            this.ckReset.UseVisualStyleBackColor = true;
            this.ckReset.Visible = false;
            this.ckReset.CheckedChanged += new System.EventHandler(this.ckReset_CheckedChanged);
            // 
            // CmbReader
            // 
            this.CmbReader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CmbReader.Location = new System.Drawing.Point(128, 479);
            this.CmbReader.Name = "CmbReader";
            this.CmbReader.Size = new System.Drawing.Size(14, 21);
            this.CmbReader.TabIndex = 34;
            this.CmbReader.Visible = false;
            // 
            // tmmmm
            // 
            this.tmmmm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tmmmm.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmmmm.Location = new System.Drawing.Point(447, 68);
            this.tmmmm.Name = "tmmmm";
            this.tmmmm.Size = new System.Drawing.Size(378, 95);
            this.tmmmm.TabIndex = 80;
            this.tmmmm.Text = "12 : 01: 14";
            this.tmmmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TodayDay
            // 
            this.TodayDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TodayDay.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodayDay.Location = new System.Drawing.Point(457, 9);
            this.TodayDay.Name = "TodayDay";
            this.TodayDay.Size = new System.Drawing.Size(442, 35);
            this.TodayDay.TabIndex = 82;
            this.TodayDay.Text = "monday";
            this.TodayDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TodayDay.UseCompatibleTextRendering = true;
            // 
            // AmOrPm
            // 
            this.AmOrPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmOrPm.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmOrPm.Location = new System.Drawing.Point(790, 69);
            this.AmOrPm.Name = "AmOrPm";
            this.AmOrPm.Size = new System.Drawing.Size(167, 95);
            this.AmOrPm.TabIndex = 84;
            this.AmOrPm.Text = "PM";
            this.AmOrPm.Click += new System.EventHandler(this.label9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(54, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(968, 237);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(305, 324);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 86;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CDate
            // 
            this.CDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CDate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CDate.Location = new System.Drawing.Point(457, 44);
            this.CDate.Name = "CDate";
            this.CDate.Size = new System.Drawing.Size(442, 35);
            this.CDate.TabIndex = 87;
            this.CDate.Text = "APril,11, 25";
            this.CDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CDate.UseCompatibleTextRendering = true;
            // 
            // RecordAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1266, 566);
            this.Controls.Add(this.CDate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbFingerprint);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.ckTimetime);
            this.Controls.Add(this.lblStaffID);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.AmOrPm);
            this.Controls.Add(this.CkSendTime);
            this.Controls.Add(this.TodayDay);
            this.Controls.Add(this.tmmmm);
            this.Controls.Add(this.ckSendData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbReader);
            this.Controls.Add(this.ckReset);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RecordAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordAttendance_FormClosing);
            this.Load += new System.EventHandler(this.RecordAttendance_Load);
            this.VisibleChanged += new System.EventHandler(this.RecordAttendance_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.PictureBox pbFingerprint;
        internal System.Windows.Forms.Label lblStaffID;
        internal System.Windows.Forms.Label lblStaffName;
        internal System.Windows.Forms.ComboBox CmbReader;
        private System.Windows.Forms.CheckBox ckReset;
        private System.Windows.Forms.CheckBox ckSendData;
        private System.Windows.Forms.CheckBox CkSendTime;
        private System.Windows.Forms.CheckBox ckTimetime;
        internal System.Windows.Forms.Label lblWelcome;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label tmmmm;
        internal System.Windows.Forms.Label TodayDay;
        internal System.Windows.Forms.Label AmOrPm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label CDate;
    }
}