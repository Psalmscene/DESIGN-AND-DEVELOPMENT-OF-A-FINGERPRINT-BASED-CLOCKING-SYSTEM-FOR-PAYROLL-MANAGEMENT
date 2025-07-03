namespace PayrollSystemwithFingerprint
{
    partial class AdminLogin
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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransportation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadUserProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtfullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHealth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFeeding = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNetSalary = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Location = new System.Drawing.Point(140, 165);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(138, 46);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Create Salary";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Location = new System.Drawing.Point(140, 10);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(138, 25);
            this.txtBasicSalary.TabIndex = 2;
            this.txtBasicSalary.Text = "0";
            this.txtBasicSalary.TextChanged += new System.EventHandler(this.txtBasicSalary_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Basic Salary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Transportation";
            // 
            // txtTransportation
            // 
            this.txtTransportation.Location = new System.Drawing.Point(140, 41);
            this.txtTransportation.Name = "txtTransportation";
            this.txtTransportation.Size = new System.Drawing.Size(138, 25);
            this.txtTransportation.TabIndex = 4;
            this.txtTransportation.Text = "0";
            this.txtTransportation.TextChanged += new System.EventHandler(this.txtTransportation_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLoadUserProfile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.txtfullName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 97);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label7.Location = new System.Drawing.Point(20, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 67;
            this.label7.Text = "FullName :";
            // 
            // btnLoadUserProfile
            // 
            this.btnLoadUserProfile.BackColor = System.Drawing.Color.White;
            this.btnLoadUserProfile.FlatAppearance.BorderSize = 0;
            this.btnLoadUserProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLoadUserProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadUserProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadUserProfile.Location = new System.Drawing.Point(176, 24);
            this.btnLoadUserProfile.Name = "btnLoadUserProfile";
            this.btnLoadUserProfile.Size = new System.Drawing.Size(28, 23);
            this.btnLoadUserProfile.TabIndex = 66;
            this.btnLoadUserProfile.Text = "......";
            this.btnLoadUserProfile.UseVisualStyleBackColor = false;
            this.btnLoadUserProfile.Click += new System.EventHandler(this.btnLoadUserProfile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label3.Location = new System.Drawing.Point(34, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 65;
            this.label3.Text = "User ID :";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(87, 24);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(85, 23);
            this.txtUserId.TabIndex = 56;
            // 
            // txtfullName
            // 
            this.txtfullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullName.Location = new System.Drawing.Point(87, 48);
            this.txtfullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfullName.Name = "txtfullName";
            this.txtfullName.ReadOnly = true;
            this.txtfullName.Size = new System.Drawing.Size(247, 23);
            this.txtfullName.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Health";
            // 
            // txtHealth
            // 
            this.txtHealth.Location = new System.Drawing.Point(140, 103);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(138, 25);
            this.txtHealth.TabIndex = 10;
            this.txtHealth.Text = "0";
            this.txtHealth.TextChanged += new System.EventHandler(this.txtHealth_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Feeding";
            // 
            // txtFeeding
            // 
            this.txtFeeding.Location = new System.Drawing.Point(140, 72);
            this.txtFeeding.Name = "txtFeeding";
            this.txtFeeding.Size = new System.Drawing.Size(138, 25);
            this.txtFeeding.TabIndex = 8;
            this.txtFeeding.Text = "0";
            this.txtFeeding.TextChanged += new System.EventHandler(this.txtFeeding_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Net Salary";
            // 
            // txtNetSalary
            // 
            this.txtNetSalary.Location = new System.Drawing.Point(140, 134);
            this.txtNetSalary.Name = "txtNetSalary";
            this.txtNetSalary.ReadOnly = true;
            this.txtNetSalary.Size = new System.Drawing.Size(138, 25);
            this.txtNetSalary.TabIndex = 12;
            this.txtNetSalary.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.BtnLogin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtBasicSalary);
            this.panel1.Controls.Add(this.txtNetSalary);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTransportation);
            this.panel1.Controls.Add(this.txtHealth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFeeding);
            this.panel1.Location = new System.Drawing.Point(117, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 232);
            this.panel1.TabIndex = 14;
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(411, 350);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTransportation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtfullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHealth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFeeding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNetSalary;
        private System.Windows.Forms.Panel panel1;
    }
}

