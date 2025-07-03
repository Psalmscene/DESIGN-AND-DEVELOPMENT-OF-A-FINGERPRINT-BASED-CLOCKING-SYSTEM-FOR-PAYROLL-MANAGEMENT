namespace PayrollSystemwithFingerprint
{
    partial class StaffSalarySetUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffSalarySetUp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.TxtBasicSalary = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadUserProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtfullName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNetSalary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.BackgroundImage = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbPosition);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.TxtBasicSalary);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLoadUserProfile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.txtfullName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label5.Location = new System.Drawing.Point(28, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 102;
            this.label5.Text = "Basic Salary";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label6.Location = new System.Drawing.Point(46, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "Position";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4"});
            this.cmbPosition.Location = new System.Drawing.Point(99, 113);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(181, 23);
            this.cmbPosition.TabIndex = 99;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(99, 86);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(116, 23);
            this.txtDepartment.TabIndex = 98;
            this.txtDepartment.TextChanged += new System.EventHandler(this.txtDepartment_TextChanged);
            // 
            // TxtBasicSalary
            // 
            this.TxtBasicSalary.Enabled = false;
            this.TxtBasicSalary.Location = new System.Drawing.Point(99, 140);
            this.TxtBasicSalary.Name = "TxtBasicSalary";
            this.TxtBasicSalary.Size = new System.Drawing.Size(116, 23);
            this.TxtBasicSalary.TabIndex = 97;
            this.TxtBasicSalary.TextChanged += new System.EventHandler(this.TxtBasicSalary_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 96;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label8.Location = new System.Drawing.Point(20, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 73;
            this.label8.Text = "Department :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label7.Location = new System.Drawing.Point(32, 62);
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
            this.btnLoadUserProfile.Location = new System.Drawing.Point(186, 36);
            this.btnLoadUserProfile.Name = "btnLoadUserProfile";
            this.btnLoadUserProfile.Size = new System.Drawing.Size(28, 22);
            this.btnLoadUserProfile.TabIndex = 66;
            this.btnLoadUserProfile.Text = "......";
            this.btnLoadUserProfile.UseVisualStyleBackColor = false;
            this.btnLoadUserProfile.Click += new System.EventHandler(this.btnLoadUserProfile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label3.Location = new System.Drawing.Point(46, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 65;
            this.label3.Text = "User ID :";
            // 
            // txtUserId
            // 
            this.txtUserId.Enabled = false;
            this.txtUserId.Location = new System.Drawing.Point(99, 35);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(85, 23);
            this.txtUserId.TabIndex = 56;
            // 
            // txtfullName
            // 
            this.txtfullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfullName.Enabled = false;
            this.txtfullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullName.Location = new System.Drawing.Point(99, 60);
            this.txtfullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfullName.Name = "txtfullName";
            this.txtfullName.Size = new System.Drawing.Size(247, 23);
            this.txtfullName.TabIndex = 57;
            this.txtfullName.TextChanged += new System.EventHandler(this.txtfullName_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(344, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 50);
            this.button1.TabIndex = 29;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNetSalary
            // 
            this.txtNetSalary.Enabled = false;
            this.txtNetSalary.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetSalary.Location = new System.Drawing.Point(348, 317);
            this.txtNetSalary.Name = "txtNetSalary";
            this.txtNetSalary.Size = new System.Drawing.Size(111, 33);
            this.txtNetSalary.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 98;
            this.label1.Text = "Net Salary";
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToDeleteRows = false;
            this.dgvDepartment.AllowUserToOrderColumns = true;
            this.dgvDepartment.AllowUserToResizeColumns = false;
            this.dgvDepartment.AllowUserToResizeRows = false;
            this.dgvDepartment.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDepartment.Location = new System.Drawing.Point(3, 183);
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.RowHeadersVisible = false;
            this.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartment.Size = new System.Drawing.Size(336, 223);
            this.dgvDepartment.TabIndex = 100;
            this.dgvDepartment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellContentClick_1);
            this.dgvDepartment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellEndEdit);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Other Benefits";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 220;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            // 
            // StaffSalarySetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.ClientSize = new System.Drawing.Size(469, 412);
            this.Controls.Add(this.dgvDepartment);
            this.Controls.Add(this.txtNetSalary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StaffSalarySetUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALARY BREAKDOWN";
            this.Load += new System.EventHandler(this.StaffSalarySetUp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtfullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtBasicSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.DataGridView dgvDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}