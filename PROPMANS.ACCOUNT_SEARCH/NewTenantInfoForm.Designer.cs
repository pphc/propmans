namespace PROPMANS.ACCOUNT_SEARCH
{
    partial class NewTenantInfoForm
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gboxSelectUnitOwner = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.DisplayMiddleNameCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtpBirthDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblBirtDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtFirstName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLastName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).BeginInit();
            this.MainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gboxSelectUnitOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gboxSelectUnitOwner.Panel)).BeginInit();
            this.gboxSelectUnitOwner.Panel.SuspendLayout();
            this.gboxSelectUnitOwner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanael
            // 
            this.MainPanael.Controls.Add(this.btnCancel);
            this.MainPanael.Controls.Add(this.btnSave);
            this.MainPanael.Controls.Add(this.gboxSelectUnitOwner);
            this.MainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanael.Location = new System.Drawing.Point(0, 0);
            this.MainPanael.Name = "MainPanael";
            this.MainPanael.Padding = new System.Windows.Forms.Padding(2);
            this.MainPanael.Size = new System.Drawing.Size(496, 198);
            this.MainPanael.TabIndex = 76;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(382, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(276, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 19;
            this.btnSave.Values.Text = "&SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gboxSelectUnitOwner
            // 
            this.gboxSelectUnitOwner.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxSelectUnitOwner.Location = new System.Drawing.Point(2, 2);
            this.gboxSelectUnitOwner.Name = "gboxSelectUnitOwner";
            // 
            // gboxSelectUnitOwner.Panel
            // 
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.DisplayMiddleNameCheckBox);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.dtpBirthDate);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.lblBirtDate);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.txtMiddleName);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.txtFirstName);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.KryptonLabel3);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.KryptonLabel2);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.txtLastName);
            this.gboxSelectUnitOwner.Panel.Controls.Add(this.KryptonLabel1);
            this.gboxSelectUnitOwner.Size = new System.Drawing.Size(492, 143);
            this.gboxSelectUnitOwner.TabIndex = 3;
            this.gboxSelectUnitOwner.Text = "TENANT INFORMATION";
            this.gboxSelectUnitOwner.Values.Heading = "TENANT INFORMATION";
            // 
            // DisplayMiddleNameCheckBox
            // 
            this.DisplayMiddleNameCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.DisplayMiddleNameCheckBox.Location = new System.Drawing.Point(135, 92);
            this.DisplayMiddleNameCheckBox.Name = "DisplayMiddleNameCheckBox";
            this.DisplayMiddleNameCheckBox.Size = new System.Drawing.Size(127, 20);
            this.DisplayMiddleNameCheckBox.TabIndex = 105;
            this.DisplayMiddleNameCheckBox.Text = "NO MIDDLE NAME";
            this.DisplayMiddleNameCheckBox.Values.Text = "NO MIDDLE NAME";
            this.DisplayMiddleNameCheckBox.CheckedChanged += new System.EventHandler(this.DisplayInactiveAccountsCheckBox_CheckedChanged);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarTodayDate = new System.DateTime(2013, 7, 18, 0, 0, 0, 0);
            this.dtpBirthDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(134, 120);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(345, 21);
            this.dtpBirthDate.TabIndex = 104;
            this.dtpBirthDate.Visible = false;
            // 
            // lblBirtDate
            // 
            this.lblBirtDate.Location = new System.Drawing.Point(47, 123);
            this.lblBirtDate.Name = "lblBirtDate";
            this.lblBirtDate.Size = new System.Drawing.Size(79, 20);
            this.lblBirtDate.TabIndex = 23;
            this.lblBirtDate.Values.Text = "BIRTH DATE:";
            this.lblBirtDate.Visible = false;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleName.Location = new System.Drawing.Point(134, 68);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(344, 20);
            this.txtMiddleName.TabIndex = 6;
            // 
            // txtFirstName
            // 
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(134, 40);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(344, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // KryptonLabel3
            // 
            this.KryptonLabel3.Location = new System.Drawing.Point(33, 71);
            this.KryptonLabel3.Name = "KryptonLabel3";
            this.KryptonLabel3.Size = new System.Drawing.Size(95, 20);
            this.KryptonLabel3.TabIndex = 4;
            this.KryptonLabel3.Values.Text = "MIDDLE NAME:";
            // 
            // KryptonLabel2
            // 
            this.KryptonLabel2.Location = new System.Drawing.Point(47, 40);
            this.KryptonLabel2.Name = "KryptonLabel2";
            this.KryptonLabel2.Size = new System.Drawing.Size(81, 20);
            this.KryptonLabel2.TabIndex = 3;
            this.KryptonLabel2.Values.Text = "FIRST NAME:";
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(134, 12);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(344, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // KryptonLabel1
            // 
            this.KryptonLabel1.Location = new System.Drawing.Point(50, 14);
            this.KryptonLabel1.Name = "KryptonLabel1";
            this.KryptonLabel1.Size = new System.Drawing.Size(78, 20);
            this.KryptonLabel1.TabIndex = 0;
            this.KryptonLabel1.Values.Text = "LAST NAME:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NewTenantInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 198);
            this.Controls.Add(this.MainPanael);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewTenantInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEW TENANT INFORMATION";
            this.Load += new System.EventHandler(this.NewLeaseAgreementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).EndInit();
            this.MainPanael.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gboxSelectUnitOwner.Panel)).EndInit();
            this.gboxSelectUnitOwner.Panel.ResumeLayout(false);
            this.gboxSelectUnitOwner.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gboxSelectUnitOwner)).EndInit();
            this.gboxSelectUnitOwner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanael;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox gboxSelectUnitOwner;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMiddleName;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFirstName;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLastName;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblBirtDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpBirthDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox DisplayMiddleNameCheckBox;
    }
}