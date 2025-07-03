namespace PayrollSystemwithFingerprint
{
    partial class Frm_Reg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CKMessage = new System.Windows.Forms.CheckBox();
            this.ckReset = new System.Windows.Forms.CheckBox();
            this.CmbReader = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadUserProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtfullName = new System.Windows.Forms.TextBox();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.CKMessage);
            this.groupBox1.Controls.Add(this.ckReset);
            this.groupBox1.Controls.Add(this.CmbReader);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLoadUserProfile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.txtfullName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CKMessage
            // 
            this.CKMessage.AutoSize = true;
            this.CKMessage.Location = new System.Drawing.Point(365, 72);
            this.CKMessage.Name = "CKMessage";
            this.CKMessage.Size = new System.Drawing.Size(83, 19);
            this.CKMessage.TabIndex = 75;
            this.CKMessage.Text = "checkBox1";
            this.CKMessage.UseVisualStyleBackColor = true;
            this.CKMessage.Visible = false;
            this.CKMessage.CheckedChanged += new System.EventHandler(this.CKMessage_CheckedChanged);
            // 
            // ckReset
            // 
            this.ckReset.AutoSize = true;
            this.ckReset.Location = new System.Drawing.Point(365, 22);
            this.ckReset.Name = "ckReset";
            this.ckReset.Size = new System.Drawing.Size(83, 19);
            this.ckReset.TabIndex = 74;
            this.ckReset.Text = "checkBox1";
            this.ckReset.UseVisualStyleBackColor = true;
            this.ckReset.Visible = false;
            this.ckReset.CheckedChanged += new System.EventHandler(this.ckReset_CheckedChanged);
            // 
            // CmbReader
            // 
            this.CmbReader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CmbReader.Location = new System.Drawing.Point(365, 47);
            this.CmbReader.Name = "CmbReader";
            this.CmbReader.Size = new System.Drawing.Size(99, 21);
            this.CmbReader.TabIndex = 31;
            this.CmbReader.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(695, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 29);
            this.button1.TabIndex = 29;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label7.Location = new System.Drawing.Point(9, 59);
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
            this.btnLoadUserProfile.Location = new System.Drawing.Point(165, 29);
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
            this.label3.Location = new System.Drawing.Point(23, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 65;
            this.label3.Text = "User ID :";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(76, 30);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(85, 23);
            this.txtUserId.TabIndex = 56;
            // 
            // txtfullName
            // 
            this.txtfullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullName.Location = new System.Drawing.Point(76, 56);
            this.txtfullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfullName.Name = "txtfullName";
            this.txtfullName.Size = new System.Drawing.Size(264, 23);
            this.txtfullName.TabIndex = 57;
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.Location = new System.Drawing.Point(351, 109);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(185, 214);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFingerprint.TabIndex = 30;
            this.pbFingerprint.TabStop = false;
            // 
            // Frm_Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PayrollSystemwithFingerprint.Properties.Resources.IMG_20250421_WA0018_removebg_preview;
            this.ClientSize = new System.Drawing.Size(548, 335);
            this.Controls.Add(this.pbFingerprint);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Reg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reg";
            this.Load += new System.EventHandler(this.Frm_Reg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtfullName;
        internal System.Windows.Forms.PictureBox pbFingerprint;
        internal System.Windows.Forms.ComboBox CmbReader;
        private System.Windows.Forms.CheckBox ckReset;
        private System.Windows.Forms.CheckBox CKMessage;
    }
}