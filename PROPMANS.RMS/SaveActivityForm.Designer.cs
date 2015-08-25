namespace PROPMANS.RMS
{
    partial class SaveActivityForm
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
            this.dtpActivityDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboActivityType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblContractPeriod = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCurrentAgreement = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).BeginInit();
            this.MainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivityType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanael
            // 
            this.MainPanael.Controls.Add(this.lblCurrentAgreement);
            this.MainPanael.Controls.Add(this.lblContractPeriod);
            this.MainPanael.Controls.Add(this.kryptonLabel5);
            this.MainPanael.Controls.Add(this.kryptonLabel3);
            this.MainPanael.Controls.Add(this.dtpActivityDate);
            this.MainPanael.Controls.Add(this.kryptonLabel2);
            this.MainPanael.Controls.Add(this.cboActivityType);
            this.MainPanael.Controls.Add(this.kryptonLabel1);
            this.MainPanael.Controls.Add(this.txtNotes);
            this.MainPanael.Controls.Add(this.kryptonLabel4);
            this.MainPanael.Controls.Add(this.btnCancel);
            this.MainPanael.Controls.Add(this.btnSave);
            this.MainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanael.Location = new System.Drawing.Point(0, 0);
            this.MainPanael.Name = "MainPanael";
            this.MainPanael.Padding = new System.Windows.Forms.Padding(2);
            this.MainPanael.Size = new System.Drawing.Size(502, 250);
            this.MainPanael.TabIndex = 76;
            // 
            // dtpActivityDate
            // 
            this.dtpActivityDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActivityDate.Location = new System.Drawing.Point(143, 77);
            this.dtpActivityDate.Name = "dtpActivityDate";
            this.dtpActivityDate.Size = new System.Drawing.Size(340, 21);
            this.dtpActivityDate.TabIndex = 134;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(37, 78);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel2.TabIndex = 133;
            this.kryptonLabel2.Values.Text = "ACTIVITY DATE:";
            // 
            // cboActivityType
            // 
            this.cboActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActivityType.DropDownWidth = 121;
            this.cboActivityType.Location = new System.Drawing.Point(143, 104);
            this.cboActivityType.Name = "cboActivityType";
            this.cboActivityType.Size = new System.Drawing.Size(342, 21);
            this.cboActivityType.TabIndex = 132;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(93, 104);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel1.TabIndex = 131;
            this.kryptonLabel1.Values.Text = "TYPE:";
            // 
            // txtNotes
            // 
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotes.Location = new System.Drawing.Point(143, 131);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(340, 54);
            this.txtNotes.TabIndex = 130;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(82, 130);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(51, 20);
            this.kryptonLabel4.TabIndex = 129;
            this.kryptonLabel4.Values.Text = "NOTES:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(383, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(277, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 19;
            this.btnSave.Values.Text = "&SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(50, 26);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel3.TabIndex = 135;
            this.kryptonLabel3.Values.Text = "AGREEMENT:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 52);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(121, 20);
            this.kryptonLabel5.TabIndex = 136;
            this.kryptonLabel5.Values.Text = "CONTRACT PERIOD:";
            // 
            // lblContractPeriod
            // 
            this.lblContractPeriod.Location = new System.Drawing.Point(143, 53);
            this.lblContractPeriod.Name = "lblContractPeriod";
            this.lblContractPeriod.Size = new System.Drawing.Size(99, 20);
            this.lblContractPeriod.TabIndex = 137;
            this.lblContractPeriod.Values.Text = "NOT AVAILABLE";
            // 
            // lblCurrentAgreement
            // 
            this.lblCurrentAgreement.Location = new System.Drawing.Point(143, 26);
            this.lblCurrentAgreement.Name = "lblCurrentAgreement";
            this.lblCurrentAgreement.Size = new System.Drawing.Size(99, 20);
            this.lblCurrentAgreement.TabIndex = 138;
            this.lblCurrentAgreement.Values.Text = "NOT AVAILABLE";
            // 
            // SaveActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 250);
            this.Controls.Add(this.MainPanael);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SaveActivityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAVE ACTIVITY";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).EndInit();
            this.MainPanael.ResumeLayout(false);
            this.MainPanael.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivityType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanael;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboActivityType;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNotes;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpActivityDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblCurrentAgreement;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblContractPeriod;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}