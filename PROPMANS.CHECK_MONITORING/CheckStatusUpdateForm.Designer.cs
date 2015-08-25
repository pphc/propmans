namespace PROPMANS.CHECK_MONITORING
{
    partial class CheckStatusUpdateForm
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
            this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel6 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtpStatusDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblCheckNumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCheckStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSaveStatus = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboNotificationType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).BeginInit();
            this.kryptonPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNotificationType)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.kryptonPanel6);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnSaveStatus);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(514, 334);
            this.MainPanel.TabIndex = 76;
            // 
            // kryptonPanel6
            // 
            this.kryptonPanel6.Controls.Add(this.cboNotificationType);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel6.Controls.Add(this.txtRemarks);
            this.kryptonPanel6.Controls.Add(this.dtpStatusDate);
            this.kryptonPanel6.Controls.Add(this.lblCheckNumber);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel6.Controls.Add(this.cboCheckStatus);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel6.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel6.Location = new System.Drawing.Point(5, 5);
            this.kryptonPanel6.Name = "kryptonPanel6";
            this.kryptonPanel6.Padding = new System.Windows.Forms.Padding(2);
            this.kryptonPanel6.Size = new System.Drawing.Size(504, 257);
            this.kryptonPanel6.TabIndex = 93;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 101);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(125, 20);
            this.kryptonLabel5.TabIndex = 93;
            this.kryptonLabel5.Values.Text = "NOTIFICATION TYPE:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Location = new System.Drawing.Point(146, 127);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(335, 85);
            this.txtRemarks.TabIndex = 92;
            // 
            // dtpStatusDate
            // 
            this.dtpStatusDate.AlwaysActive = false;
            this.dtpStatusDate.CalendarTodayDate = new System.DateTime(2013, 12, 6, 0, 0, 0, 0);
            this.dtpStatusDate.Location = new System.Drawing.Point(146, 68);
            this.dtpStatusDate.Name = "dtpStatusDate";
            this.dtpStatusDate.Size = new System.Drawing.Size(196, 21);
            this.dtpStatusDate.TabIndex = 91;
            // 
            // lblCheckNumber
            // 
            this.lblCheckNumber.Location = new System.Drawing.Point(146, 16);
            this.lblCheckNumber.Name = "lblCheckNumber";
            this.lblCheckNumber.Size = new System.Drawing.Size(104, 20);
            this.lblCheckNumber.TabIndex = 90;
            this.lblCheckNumber.Values.Text = "CHECK NUMBER:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(70, 127);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel2.TabIndex = 89;
            this.kryptonLabel2.Values.Text = "REMARKS:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(49, 69);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 88;
            this.kryptonLabel1.Values.Text = "STATUS DATE:";
            // 
            // cboCheckStatus
            // 
            this.cboCheckStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckStatus.DropDownWidth = 121;
            this.cboCheckStatus.Location = new System.Drawing.Point(146, 42);
            this.cboCheckStatus.Name = "cboCheckStatus";
            this.cboCheckStatus.Size = new System.Drawing.Size(196, 21);
            this.cboCheckStatus.TabIndex = 87;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(43, 42);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel4.TabIndex = 86;
            this.kryptonLabel4.Values.Text = "CHECK STATUS:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(36, 16);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel3.TabIndex = 84;
            this.kryptonLabel3.Values.Text = "CHECK NUMBER:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(395, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 35);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveStatus
            // 
            this.btnSaveStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveStatus.Location = new System.Drawing.Point(298, 287);
            this.btnSaveStatus.Name = "btnSaveStatus";
            this.btnSaveStatus.Size = new System.Drawing.Size(91, 35);
            this.btnSaveStatus.TabIndex = 91;
            this.btnSaveStatus.Values.Text = "SAVE";
            this.btnSaveStatus.Click += new System.EventHandler(this.btnSaveStatus_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboNotificationType
            // 
            this.cboNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotificationType.DropDownWidth = 121;
            this.cboNotificationType.Location = new System.Drawing.Point(146, 100);
            this.cboNotificationType.Name = "cboNotificationType";
            this.cboNotificationType.Size = new System.Drawing.Size(196, 21);
            this.cboNotificationType.TabIndex = 94;
            // 
            // CheckStatusUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 334);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckStatusUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK STATUS UPDATE";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel6)).EndInit();
            this.kryptonPanel6.ResumeLayout(false);
            this.kryptonPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNotificationType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveStatus;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel6;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCheckStatus;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblCheckNumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpStatusDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboNotificationType;
    }
}