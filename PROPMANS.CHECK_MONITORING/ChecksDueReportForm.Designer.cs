namespace PROPMANS.CHECK_MONITORING
{
    partial class ChecksDueReportForm
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
            this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dtpEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.KryptonLabel19 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddtoAR = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.dtpEndDate);
            this.MainPanel.Controls.Add(this.kryptonLabel1);
            this.MainPanel.Controls.Add(this.dtpStartDate);
            this.MainPanel.Controls.Add(this.KryptonLabel19);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnAddtoAR);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(330, 165);
            this.MainPanel.TabIndex = 76;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AlwaysActive = false;
            this.dtpEndDate.CalendarTodayDate = new System.DateTime(2013, 12, 6, 0, 0, 0, 0);
            this.dtpEndDate.Location = new System.Drawing.Point(86, 62);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(232, 21);
            this.dtpEndDate.TabIndex = 96;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(51, 62);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(29, 20);
            this.kryptonLabel1.TabIndex = 95;
            this.kryptonLabel1.Values.Text = "TO:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AlwaysActive = false;
            this.dtpStartDate.CalendarTodayDate = new System.DateTime(2013, 12, 6, 0, 0, 0, 0);
            this.dtpStartDate.Location = new System.Drawing.Point(86, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(232, 21);
            this.dtpStartDate.TabIndex = 94;
            // 
            // KryptonLabel19
            // 
            this.KryptonLabel19.Location = new System.Drawing.Point(37, 22);
            this.KryptonLabel19.Name = "KryptonLabel19";
            this.KryptonLabel19.Size = new System.Drawing.Size(47, 20);
            this.KryptonLabel19.TabIndex = 93;
            this.KryptonLabel19.Values.Text = "FROM:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(232, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 35);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddtoAR
            // 
            this.btnAddtoAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddtoAR.Location = new System.Drawing.Point(130, 117);
            this.btnAddtoAR.Name = "btnAddtoAR";
            this.btnAddtoAR.Size = new System.Drawing.Size(87, 35);
            this.btnAddtoAR.TabIndex = 91;
            this.btnAddtoAR.Values.Text = "OK";
            this.btnAddtoAR.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // ChecksDueReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 165);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChecksDueReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIST OF CHECKS DUE REPORT";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnAddtoAR;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpEndDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpStartDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel19;
    }
}