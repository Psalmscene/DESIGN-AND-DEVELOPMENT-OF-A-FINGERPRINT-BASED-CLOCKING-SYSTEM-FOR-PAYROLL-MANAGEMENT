namespace PayrollSystemwithFingerprint
{
    partial class Frm_CheckFingerPrintAavailable
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
            this.cboReaders = new System.Windows.Forms.ComboBox();
            this.lblSelectReader = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.BtnCheckCapability = new System.Windows.Forms.Button();
            this.BtnSelectreader = new System.Windows.Forms.Button();
            this.txtReaderSelected = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstCaps = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cboReaders
            // 
            this.cboReaders.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cboReaders.Location = new System.Drawing.Point(15, 44);
            this.cboReaders.Name = "cboReaders";
            this.cboReaders.Size = new System.Drawing.Size(256, 21);
            this.cboReaders.TabIndex = 16;
            // 
            // lblSelectReader
            // 
            this.lblSelectReader.Location = new System.Drawing.Point(12, 24);
            this.lblSelectReader.Name = "lblSelectReader";
            this.lblSelectReader.Size = new System.Drawing.Size(296, 25);
            this.lblSelectReader.TabIndex = 15;
            this.lblSelectReader.Text = "Select Reader:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(156, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 23);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Load List";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // BtnCheckCapability
            // 
            this.BtnCheckCapability.Location = new System.Drawing.Point(15, 71);
            this.BtnCheckCapability.Name = "BtnCheckCapability";
            this.BtnCheckCapability.Size = new System.Drawing.Size(123, 23);
            this.BtnCheckCapability.TabIndex = 18;
            this.BtnCheckCapability.Text = "Capabiltiy";
            this.BtnCheckCapability.Click += new System.EventHandler(this.BtnCheckCapability_Click);
            // 
            // BtnSelectreader
            // 
            this.BtnSelectreader.Location = new System.Drawing.Point(144, 71);
            this.BtnSelectreader.Name = "BtnSelectreader";
            this.BtnSelectreader.Size = new System.Drawing.Size(127, 23);
            this.BtnSelectreader.TabIndex = 19;
            this.BtnSelectreader.Text = "Select Reader";
            this.BtnSelectreader.Click += new System.EventHandler(this.BtnSelectreader_Click);
            // 
            // txtReaderSelected
            // 
            this.txtReaderSelected.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtReaderSelected.Location = new System.Drawing.Point(12, 172);
            this.txtReaderSelected.Name = "txtReaderSelected";
            this.txtReaderSelected.Size = new System.Drawing.Size(260, 20);
            this.txtReaderSelected.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Selected Reader:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtName.Location = new System.Drawing.Point(13, 130);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.TabIndex = 23;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(11, 112);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(236, 15);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Name:";
            // 
            // lstCaps
            // 
            this.lstCaps.ItemHeight = 17;
            this.lstCaps.Location = new System.Drawing.Point(12, 198);
            this.lstCaps.Name = "lstCaps";
            this.lstCaps.Size = new System.Drawing.Size(260, 157);
            this.lstCaps.TabIndex = 22;
            // 
            // Frm_CheckFingerPrintAavailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 368);
            this.Controls.Add(this.txtReaderSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstCaps);
            this.Controls.Add(this.BtnSelectreader);
            this.Controls.Add(this.BtnCheckCapability);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboReaders);
            this.Controls.Add(this.lblSelectReader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_CheckFingerPrintAavailable";
            this.Text = "Frm_CheckFingerPrintAavailable";
            this.Load += new System.EventHandler(this.Frm_CheckFingerPrintAavailable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboReaders;
        internal System.Windows.Forms.Label lblSelectReader;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button BtnCheckCapability;
        internal System.Windows.Forms.Button BtnSelectreader;
        internal System.Windows.Forms.TextBox txtReaderSelected;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstCaps;
    }
}