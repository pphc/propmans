namespace PROPMANS.CHECK_MONITORING
{
    partial class ChecksUpdateForm
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
            this.kryptonPanel6 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnViewCheckStatusHistory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUpdateChecks = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblRecordCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.CheckDetailsGridPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgCheckDetails = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ARInformationGroupBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pnlGridContainer = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblCustomerType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAccountName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSearchAccount = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.HeaderPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.moduleheader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).BeginInit();
            this.kryptonPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).BeginInit();
            this.CheckDetailsGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARInformationGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARInformationGroupBox.Panel)).BeginInit();
            this.ARInformationGroupBox.Panel.SuspendLayout();
            this.ARInformationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridContainer)).BeginInit();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.kryptonPanel6);
            this.MainPanel.Controls.Add(this.HeaderPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(1060, 734);
            this.MainPanel.TabIndex = 76;
            // 
            // kryptonPanel6
            // 
            this.kryptonPanel6.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel6.Controls.Add(this.ARInformationGroupBox);
            this.kryptonPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel6.Location = new System.Drawing.Point(5, 54);
            this.kryptonPanel6.Name = "kryptonPanel6";
            this.kryptonPanel6.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.kryptonPanel6.Size = new System.Drawing.Size(1050, 675);
            this.kryptonPanel6.TabIndex = 94;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(20, 117);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonPanel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1010, 484);
            this.kryptonGroupBox1.TabIndex = 33;
            this.kryptonGroupBox1.Text = "ISSUED CHECKS DETAIL";
            this.kryptonGroupBox1.Values.Heading = "ISSUED CHECKS DETAIL";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnViewCheckStatusHistory);
            this.kryptonPanel1.Controls.Add(this.btnUpdateChecks);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.CheckDetailsGridPanel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.kryptonPanel1.Size = new System.Drawing.Size(1006, 460);
            this.kryptonPanel1.TabIndex = 26;
            // 
            // btnViewCheckStatusHistory
            // 
            this.btnViewCheckStatusHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewCheckStatusHistory.Location = new System.Drawing.Point(20, 418);
            this.btnViewCheckStatusHistory.Name = "btnViewCheckStatusHistory";
            this.btnViewCheckStatusHistory.Size = new System.Drawing.Size(171, 35);
            this.btnViewCheckStatusHistory.TabIndex = 79;
            this.btnViewCheckStatusHistory.Values.Text = "VIEW STATUS HISTORY";
            this.btnViewCheckStatusHistory.Click += new System.EventHandler(this.btnViewCheckStatusHistory_Click);
            // 
            // btnUpdateChecks
            // 
            this.btnUpdateChecks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateChecks.Location = new System.Drawing.Point(887, 418);
            this.btnUpdateChecks.Name = "btnUpdateChecks";
            this.btnUpdateChecks.Size = new System.Drawing.Size(109, 35);
            this.btnUpdateChecks.TabIndex = 78;
            this.btnUpdateChecks.Values.Text = "UPDATE";
            this.btnUpdateChecks.Click += new System.EventHandler(this.btnUpdateChecks_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.lblRecordCount);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(20, 371);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.kryptonPanel2.Size = new System.Drawing.Size(976, 41);
            this.kryptonPanel2.TabIndex = 77;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRecordCount.Location = new System.Drawing.Point(866, 2);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(108, 37);
            this.lblRecordCount.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.TabIndex = 65;
            this.lblRecordCount.Values.Text = "No Record/s Found";
            // 
            // CheckDetailsGridPanel
            // 
            this.CheckDetailsGridPanel.Controls.Add(this.dgCheckDetails);
            this.CheckDetailsGridPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckDetailsGridPanel.Location = new System.Drawing.Point(20, 10);
            this.CheckDetailsGridPanel.Name = "CheckDetailsGridPanel";
            this.CheckDetailsGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.CheckDetailsGridPanel.Size = new System.Drawing.Size(976, 361);
            this.CheckDetailsGridPanel.StateCommon.Color1 = System.Drawing.Color.RoyalBlue;
            this.CheckDetailsGridPanel.TabIndex = 76;
            // 
            // dgCheckDetails
            // 
            this.dgCheckDetails.AllowUserToAddRows = false;
            this.dgCheckDetails.AllowUserToDeleteRows = false;
            this.dgCheckDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCheckDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCheckDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheckDetails.Location = new System.Drawing.Point(1, 1);
            this.dgCheckDetails.Name = "dgCheckDetails";
            this.dgCheckDetails.ReadOnly = true;
            this.dgCheckDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCheckDetails.Size = new System.Drawing.Size(974, 359);
            this.dgCheckDetails.TabIndex = 3;
            // 
            // ARInformationGroupBox
            // 
            this.ARInformationGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ARInformationGroupBox.Location = new System.Drawing.Point(20, 10);
            this.ARInformationGroupBox.Name = "ARInformationGroupBox";
            // 
            // ARInformationGroupBox.Panel
            // 
            this.ARInformationGroupBox.Panel.Controls.Add(this.pnlGridContainer);
            this.ARInformationGroupBox.Size = new System.Drawing.Size(1010, 107);
            this.ARInformationGroupBox.TabIndex = 32;
            this.ARInformationGroupBox.Text = "SELECT CUSTOMER ACCOUNT";
            this.ARInformationGroupBox.Values.Heading = "SELECT CUSTOMER ACCOUNT";
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.btnRefresh);
            this.pnlGridContainer.Controls.Add(this.lblCustomerType);
            this.pnlGridContainer.Controls.Add(this.kryptonLabel1);
            this.pnlGridContainer.Controls.Add(this.txtAccountName);
            this.pnlGridContainer.Controls.Add(this.KryptonLabel13);
            this.pnlGridContainer.Controls.Add(this.btnSearchAccount);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.pnlGridContainer.Size = new System.Drawing.Size(1006, 83);
            this.pnlGridContainer.TabIndex = 26;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(724, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 35);
            this.btnRefresh.TabIndex = 75;
            this.btnRefresh.Values.Text = "REFRESH";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.Location = new System.Drawing.Point(163, 43);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(106, 20);
            this.lblCustomerType.TabIndex = 74;
            this.lblCustomerType.Values.Text = "CUSTOMER TYPE:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(51, 43);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel1.TabIndex = 73;
            this.kryptonLabel1.Values.Text = "CUSTOMER TYPE:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(163, 17);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(468, 20);
            this.txtAccountName.TabIndex = 72;
            // 
            // KryptonLabel13
            // 
            this.KryptonLabel13.Location = new System.Drawing.Point(23, 17);
            this.KryptonLabel13.Name = "KryptonLabel13";
            this.KryptonLabel13.Size = new System.Drawing.Size(137, 20);
            this.KryptonLabel13.TabIndex = 67;
            this.KryptonLabel13.Values.Text = "CUSTOMER ACCOUNT:";
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.Location = new System.Drawing.Point(637, 13);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(81, 35);
            this.btnSearchAccount.TabIndex = 5;
            this.btnSearchAccount.Values.Text = "SEARCH";
            this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchAccount_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.moduleheader);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(5, 5);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Padding = new System.Windows.Forms.Padding(5);
            this.HeaderPanel.Size = new System.Drawing.Size(1050, 49);
            this.HeaderPanel.TabIndex = 93;
            // 
            // moduleheader
            // 
            this.moduleheader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleheader.Location = new System.Drawing.Point(5, 5);
            this.moduleheader.Name = "moduleheader";
            this.moduleheader.Size = new System.Drawing.Size(1040, 39);
            this.moduleheader.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5);
            this.moduleheader.TabIndex = 24;
            this.moduleheader.Values.Description = "";
            this.moduleheader.Values.Heading = "CHECKS STATUS UPDATE";
            // 
            // ChecksUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 734);
            this.Controls.Add(this.MainPanel);
            this.Name = "ChecksUpdateForm";
            this.Text = "Check Status Update";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).EndInit();
            this.kryptonPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).EndInit();
            this.CheckDetailsGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARInformationGroupBox.Panel)).EndInit();
            this.ARInformationGroupBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ARInformationGroupBox)).EndInit();
            this.ARInformationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridContainer)).EndInit();
            this.pnlGridContainer.ResumeLayout(false);
            this.pnlGridContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel HeaderPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonHeader moduleheader;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel6;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox ARInformationGroupBox;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel pnlGridContainer;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountName;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel13;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSearchAccount;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblRecordCount;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel CheckDetailsGridPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgCheckDetails;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnViewCheckStatusHistory;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdateChecks;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblCustomerType;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnRefresh;
    }
}