namespace PROPMANS.CHECK_MONITORING
{
    partial class NewChecksForm
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
            this.MainPanael = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cboCheckPayee = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCheckEndNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPreviewChecks = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtRTNNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCheckClearing = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCheckBranch = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboCheckBank = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCheckAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpCheckDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCheckStartNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).BeginInit();
            this.MainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckClearing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanael
            // 
            this.MainPanael.Controls.Add(this.cboCheckPayee);
            this.MainPanael.Controls.Add(this.kryptonLabel8);
            this.MainPanael.Controls.Add(this.txtCheckEndNumber);
            this.MainPanael.Controls.Add(this.btnCancel);
            this.MainPanael.Controls.Add(this.btnPreviewChecks);
            this.MainPanael.Controls.Add(this.txtRTNNumber);
            this.MainPanael.Controls.Add(this.kryptonLabel7);
            this.MainPanael.Controls.Add(this.cboCheckClearing);
            this.MainPanael.Controls.Add(this.kryptonLabel6);
            this.MainPanael.Controls.Add(this.cboCheckBranch);
            this.MainPanael.Controls.Add(this.cboCheckBank);
            this.MainPanael.Controls.Add(this.kryptonLabel5);
            this.MainPanael.Controls.Add(this.kryptonLabel4);
            this.MainPanael.Controls.Add(this.txtCheckAmount);
            this.MainPanael.Controls.Add(this.kryptonLabel3);
            this.MainPanael.Controls.Add(this.dtpCheckDate);
            this.MainPanael.Controls.Add(this.kryptonLabel2);
            this.MainPanael.Controls.Add(this.kryptonLabel1);
            this.MainPanael.Controls.Add(this.txtCheckStartNumber);
            this.MainPanael.Controls.Add(this.KryptonLabel13);
            this.MainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanael.Location = new System.Drawing.Point(0, 0);
            this.MainPanael.Name = "MainPanael";
            this.MainPanael.Padding = new System.Windows.Forms.Padding(2);
            this.MainPanael.Size = new System.Drawing.Size(619, 299);
            this.MainPanael.TabIndex = 76;
            // 
            // cboCheckPayee
            // 
            this.cboCheckPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckPayee.DropDownWidth = 121;
            this.cboCheckPayee.Location = new System.Drawing.Point(137, 157);
            this.cboCheckPayee.Name = "cboCheckPayee";
            this.cboCheckPayee.Size = new System.Drawing.Size(201, 21);
            this.cboCheckPayee.TabIndex = 6;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(84, 159);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel8.TabIndex = 92;
            this.kryptonLabel8.Values.Text = "PAYEE:";
            // 
            // txtCheckEndNumber
            // 
            this.txtCheckEndNumber.Location = new System.Drawing.Point(387, 24);
            this.txtCheckEndNumber.MaxLength = 20;
            this.txtCheckEndNumber.Name = "txtCheckEndNumber";
            this.txtCheckEndNumber.Size = new System.Drawing.Size(201, 20);
            this.txtCheckEndNumber.TabIndex = 1;
            this.txtCheckEndNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(479, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreviewChecks
            // 
            this.btnPreviewChecks.Location = new System.Drawing.Point(354, 252);
            this.btnPreviewChecks.Name = "btnPreviewChecks";
            this.btnPreviewChecks.Size = new System.Drawing.Size(109, 35);
            this.btnPreviewChecks.TabIndex = 9;
            this.btnPreviewChecks.Values.Text = "PREVIEW";
            this.btnPreviewChecks.Click += new System.EventHandler(this.btnPreviewChecks_Click);
            // 
            // txtRTNNumber
            // 
            this.txtRTNNumber.Location = new System.Drawing.Point(137, 211);
            this.txtRTNNumber.Name = "txtRTNNumber";
            this.txtRTNNumber.Size = new System.Drawing.Size(201, 20);
            this.txtRTNNumber.TabIndex = 8;
            this.txtRTNNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(51, 211);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(80, 20);
            this.kryptonLabel7.TabIndex = 87;
            this.kryptonLabel7.Values.Text = "RT NUMBER:";
            // 
            // cboCheckClearing
            // 
            this.cboCheckClearing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckClearing.DropDownWidth = 121;
            this.cboCheckClearing.Location = new System.Drawing.Point(137, 184);
            this.cboCheckClearing.Name = "cboCheckClearing";
            this.cboCheckClearing.Size = new System.Drawing.Size(201, 21);
            this.cboCheckClearing.TabIndex = 7;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(62, 185);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel6.TabIndex = 85;
            this.kryptonLabel6.Values.Text = "CLEARING:";
            // 
            // cboCheckBranch
            // 
            this.cboCheckBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckBranch.DropDownWidth = 121;
            this.cboCheckBranch.Location = new System.Drawing.Point(137, 130);
            this.cboCheckBranch.Name = "cboCheckBranch";
            this.cboCheckBranch.Size = new System.Drawing.Size(201, 21);
            this.cboCheckBranch.TabIndex = 5;
            // 
            // cboCheckBank
            // 
            this.cboCheckBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckBank.DropDownWidth = 121;
            this.cboCheckBank.Location = new System.Drawing.Point(137, 103);
            this.cboCheckBank.Name = "cboCheckBank";
            this.cboCheckBank.Size = new System.Drawing.Size(201, 21);
            this.cboCheckBank.TabIndex = 4;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(70, 131);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel5.TabIndex = 82;
            this.kryptonLabel5.Values.Text = "BRANCH:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(86, 104);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel4.TabIndex = 81;
            this.kryptonLabel4.Values.Text = "BANK:";
            // 
            // txtCheckAmount
            // 
            this.txtCheckAmount.Location = new System.Drawing.Point(137, 77);
            this.txtCheckAmount.MaxLength = 12;
            this.txtCheckAmount.Name = "txtCheckAmount";
            this.txtCheckAmount.Size = new System.Drawing.Size(201, 20);
            this.txtCheckAmount.TabIndex = 3;
            this.txtCheckAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(24, 77);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel3.TabIndex = 79;
            this.kryptonLabel3.Values.Text = "CHECK AMOUNT:";
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.AlwaysActive = false;
            this.dtpCheckDate.Location = new System.Drawing.Point(137, 50);
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.Size = new System.Drawing.Size(201, 21);
            this.dtpCheckDate.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(88, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(43, 20);
            this.kryptonLabel2.TabIndex = 77;
            this.kryptonLabel2.Values.Text = "DATE:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(352, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(29, 20);
            this.kryptonLabel1.TabIndex = 75;
            this.kryptonLabel1.Values.Text = "TO:";
            // 
            // txtCheckStartNumber
            // 
            this.txtCheckStartNumber.Location = new System.Drawing.Point(137, 24);
            this.txtCheckStartNumber.MaxLength = 20;
            this.txtCheckStartNumber.Name = "txtCheckStartNumber";
            this.txtCheckStartNumber.Size = new System.Drawing.Size(201, 20);
            this.txtCheckStartNumber.TabIndex = 0;
            this.txtCheckStartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // KryptonLabel13
            // 
            this.KryptonLabel13.Location = new System.Drawing.Point(27, 24);
            this.KryptonLabel13.Name = "KryptonLabel13";
            this.KryptonLabel13.Size = new System.Drawing.Size(104, 20);
            this.KryptonLabel13.TabIndex = 73;
            this.KryptonLabel13.Values.Text = "CHECK NUMBER:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NewChecksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 299);
            this.Controls.Add(this.MainPanael);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewChecksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK DETAILS";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).EndInit();
            this.MainPanael.ResumeLayout(false);
            this.MainPanael.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckClearing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanael;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCheckStartNumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel13;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCheckAmount;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpCheckDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRTNNumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCheckClearing;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCheckBranch;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCheckBank;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCheckEndNumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnPreviewChecks;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCheckPayee;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}