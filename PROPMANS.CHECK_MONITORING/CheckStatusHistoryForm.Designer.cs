namespace PROPMANS.CHECK_MONITORING
{
    partial class CheckStatusHistoryForm
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgCheckStatusHistory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.lblRecordCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.CheckDetailsGridPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblCheckINumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCheckBank = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckStatusHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).BeginInit();
            this.CheckDetailsGridPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.kryptonPanel1);
            this.MainPanel.Controls.Add(this.lblRecordCount);
            this.MainPanel.Controls.Add(this.kryptonPanel2);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(1138, 383);
            this.MainPanel.TabIndex = 76;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(5, 74);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.Size = new System.Drawing.Size(1128, 257);
            this.kryptonPanel1.TabIndex = 95;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.dgCheckStatusHistory);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(5, 5);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.kryptonPanel3.Size = new System.Drawing.Size(1118, 247);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.Color.RoyalBlue;
            this.kryptonPanel3.TabIndex = 77;
            // 
            // dgCheckStatusHistory
            // 
            this.dgCheckStatusHistory.AllowUserToAddRows = false;
            this.dgCheckStatusHistory.AllowUserToDeleteRows = false;
            this.dgCheckStatusHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCheckStatusHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCheckStatusHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheckStatusHistory.Location = new System.Drawing.Point(1, 1);
            this.dgCheckStatusHistory.MultiSelect = false;
            this.dgCheckStatusHistory.Name = "dgCheckStatusHistory";
            this.dgCheckStatusHistory.ReadOnly = true;
            this.dgCheckStatusHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCheckStatusHistory.Size = new System.Drawing.Size(1116, 245);
            this.dgCheckStatusHistory.TabIndex = 3;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Location = new System.Drawing.Point(12, 339);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(108, 16);
            this.lblRecordCount.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.TabIndex = 94;
            this.lblRecordCount.Values.Text = "No Record/s Found";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.CheckDetailsGridPanel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(5, 5);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel2.Size = new System.Drawing.Size(1128, 69);
            this.kryptonPanel2.TabIndex = 93;
            // 
            // CheckDetailsGridPanel
            // 
            this.CheckDetailsGridPanel.Controls.Add(this.lblCheckBank);
            this.CheckDetailsGridPanel.Controls.Add(this.kryptonLabel1);
            this.CheckDetailsGridPanel.Controls.Add(this.lblCheckINumber);
            this.CheckDetailsGridPanel.Controls.Add(this.KryptonLabel13);
            this.CheckDetailsGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDetailsGridPanel.Location = new System.Drawing.Point(5, 5);
            this.CheckDetailsGridPanel.Name = "CheckDetailsGridPanel";
            this.CheckDetailsGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.CheckDetailsGridPanel.Size = new System.Drawing.Size(1118, 59);
            this.CheckDetailsGridPanel.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.CheckDetailsGridPanel.TabIndex = 77;
            // 
            // lblCheckINumber
            // 
            this.lblCheckINumber.Location = new System.Drawing.Point(104, 11);
            this.lblCheckINumber.Name = "lblCheckINumber";
            this.lblCheckINumber.Size = new System.Drawing.Size(79, 20);
            this.lblCheckINumber.TabIndex = 69;
            this.lblCheckINumber.Values.Text = "CHECK INFO";
            // 
            // KryptonLabel13
            // 
            this.KryptonLabel13.Location = new System.Drawing.Point(4, 11);
            this.KryptonLabel13.Name = "KryptonLabel13";
            this.KryptonLabel13.Size = new System.Drawing.Size(104, 20);
            this.KryptonLabel13.TabIndex = 68;
            this.KryptonLabel13.Values.Text = "CHECK NUMBER:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1018, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(22, 35);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(86, 20);
            this.kryptonLabel1.TabIndex = 70;
            this.kryptonLabel1.Values.Text = "CHECK BANK:";
            // 
            // lblCheckBank
            // 
            this.lblCheckBank.Location = new System.Drawing.Point(104, 35);
            this.lblCheckBank.Name = "lblCheckBank";
            this.lblCheckBank.Size = new System.Drawing.Size(83, 20);
            this.lblCheckBank.TabIndex = 71;
            this.lblCheckBank.Values.Text = "CHECK BANK";
            // 
            // CheckStatusHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 383);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckStatusHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK STATUS HISTORY";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckStatusHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).EndInit();
            this.CheckDetailsGridPanel.ResumeLayout(false);
            this.CheckDetailsGridPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblRecordCount;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgCheckStatusHistory;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel CheckDetailsGridPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblCheckINumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel13;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblCheckBank;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}