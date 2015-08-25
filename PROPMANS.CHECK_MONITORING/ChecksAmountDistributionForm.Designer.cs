namespace PROPMANS.CHECK_MONITORING
{
    partial class ChecksAmountDistributionForm
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
            this.chkSelectAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.ChecksDistributionGridPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgChecksDistribution = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel6 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnDistributeAmount = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtDistributionAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSelectAccount = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cboFeeType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAccountName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSaveDistribution = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChecksDistributionGridPanel)).BeginInit();
            this.ChecksDistributionGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChecksDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).BeginInit();
            this.kryptonPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFeeType)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.chkSelectAll);
            this.MainPanel.Controls.Add(this.ChecksDistributionGridPanel);
            this.MainPanel.Controls.Add(this.kryptonPanel6);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnSaveDistribution);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(684, 450);
            this.MainPanel.TabIndex = 76;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkSelectAll.Location = new System.Drawing.Point(6, 418);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(86, 20);
            this.chkSelectAll.TabIndex = 95;
            this.chkSelectAll.Text = "SELECT ALL";
            this.chkSelectAll.Values.Text = "SELECT ALL";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // ChecksDistributionGridPanel
            // 
            this.ChecksDistributionGridPanel.Controls.Add(this.dgChecksDistribution);
            this.ChecksDistributionGridPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChecksDistributionGridPanel.Location = new System.Drawing.Point(5, 116);
            this.ChecksDistributionGridPanel.Name = "ChecksDistributionGridPanel";
            this.ChecksDistributionGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.ChecksDistributionGridPanel.Size = new System.Drawing.Size(674, 260);
            this.ChecksDistributionGridPanel.StateCommon.Color1 = System.Drawing.Color.RoyalBlue;
            this.ChecksDistributionGridPanel.TabIndex = 94;
            // 
            // dgChecksDistribution
            // 
            this.dgChecksDistribution.AllowUserToAddRows = false;
            this.dgChecksDistribution.AllowUserToDeleteRows = false;
            this.dgChecksDistribution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgChecksDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChecksDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgChecksDistribution.Location = new System.Drawing.Point(1, 1);
            this.dgChecksDistribution.Name = "dgChecksDistribution";
            this.dgChecksDistribution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChecksDistribution.Size = new System.Drawing.Size(672, 258);
            this.dgChecksDistribution.TabIndex = 3;
            this.dgChecksDistribution.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgChecksDistribution_CellBeginEdit);
            this.dgChecksDistribution.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChecksDistribution_CellLeave);
            this.dgChecksDistribution.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChecksDistribution_CellLeave);
            this.dgChecksDistribution.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgChecksDistribution_CurrentCellDirtyStateChanged);
            this.dgChecksDistribution.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgChecksDistribution_DataError);
            this.dgChecksDistribution.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgChecksDistribution_EditingControlShowing);
            // 
            // kryptonPanel6
            // 
            this.kryptonPanel6.Controls.Add(this.btnDistributeAmount);
            this.kryptonPanel6.Controls.Add(this.txtDistributionAmount);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel6.Controls.Add(this.btnSelectAccount);
            this.kryptonPanel6.Controls.Add(this.cboFeeType);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel6.Controls.Add(this.txtAccountName);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel6.Location = new System.Drawing.Point(5, 5);
            this.kryptonPanel6.Name = "kryptonPanel6";
            this.kryptonPanel6.Padding = new System.Windows.Forms.Padding(2);
            this.kryptonPanel6.Size = new System.Drawing.Size(674, 111);
            this.kryptonPanel6.TabIndex = 93;
            // 
            // btnDistributeAmount
            // 
            this.btnDistributeAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDistributeAmount.Location = new System.Drawing.Point(358, 70);
            this.btnDistributeAmount.Name = "btnDistributeAmount";
            this.btnDistributeAmount.Size = new System.Drawing.Size(109, 35);
            this.btnDistributeAmount.TabIndex = 95;
            this.btnDistributeAmount.Values.Text = "DISTRIBUTE";
            this.btnDistributeAmount.Click += new System.EventHandler(this.btnDistributeAmount_Click);
            // 
            // txtDistributionAmount
            // 
            this.txtDistributionAmount.Location = new System.Drawing.Point(145, 77);
            this.txtDistributionAmount.MaxLength = 12;
            this.txtDistributionAmount.Name = "txtDistributionAmount";
            this.txtDistributionAmount.Size = new System.Drawing.Size(207, 20);
            this.txtDistributionAmount.TabIndex = 94;
            this.txtDistributionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(73, 77);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel1.TabIndex = 93;
            this.kryptonLabel1.Values.Text = "AMOUNT:";
            // 
            // btnSelectAccount
            // 
            this.btnSelectAccount.Location = new System.Drawing.Point(556, 16);
            this.btnSelectAccount.Name = "btnSelectAccount";
            this.btnSelectAccount.Size = new System.Drawing.Size(109, 35);
            this.btnSelectAccount.TabIndex = 92;
            this.btnSelectAccount.Values.Text = "SELECT";
            this.btnSelectAccount.Click += new System.EventHandler(this.btnSelectAccount_Click);
            // 
            // cboFeeType
            // 
            this.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeType.DropDownWidth = 121;
            this.cboFeeType.Location = new System.Drawing.Point(145, 42);
            this.cboFeeType.Name = "cboFeeType";
            this.cboFeeType.Size = new System.Drawing.Size(207, 21);
            this.cboFeeType.TabIndex = 87;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(77, 42);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel4.TabIndex = 86;
            this.kryptonLabel4.Values.Text = "FEE TYPE:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(145, 16);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(400, 20);
            this.txtAccountName.TabIndex = 85;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(15, 16);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(137, 20);
            this.kryptonLabel3.TabIndex = 84;
            this.kryptonLabel3.Values.Text = "CUSTOMER ACCOUNT:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(561, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveDistribution
            // 
            this.btnSaveDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDistribution.Location = new System.Drawing.Point(441, 403);
            this.btnSaveDistribution.Name = "btnSaveDistribution";
            this.btnSaveDistribution.Size = new System.Drawing.Size(109, 35);
            this.btnSaveDistribution.TabIndex = 91;
            this.btnSaveDistribution.Values.Text = "SAVE";
            this.btnSaveDistribution.Click += new System.EventHandler(this.btnSaveDistribution_Click);
            // 
            // ChecksAmountDistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChecksAmountDistributionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECKS AMOUNT DISTRIBUTION";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChecksDistributionGridPanel)).EndInit();
            this.ChecksDistributionGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChecksDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).EndInit();
            this.kryptonPanel6.ResumeLayout(false);
            this.kryptonPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFeeType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveDistribution;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel6;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectAccount;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboFeeType;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountName;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel ChecksDistributionGridPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgChecksDistribution;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkSelectAll;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnDistributeAmount;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDistributionAmount;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}