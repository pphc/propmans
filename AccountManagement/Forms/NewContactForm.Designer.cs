namespace PROPMANS.VIEW.AccountManagement
{
    partial class NewContactForm
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
            this.KryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.KryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.cboContactLocation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.KryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RbContactNo = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.RbContactYes = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.cboContactType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtContact = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.errMsg = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkPreferred = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).BeginInit();
            this.KryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox2.Panel)).BeginInit();
            this.KryptonGroupBox2.Panel.SuspendLayout();
            this.KryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboContactLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContactType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel
            // 
            this.KryptonPanel.Controls.Add(this.btnCancel);
            this.KryptonPanel.Controls.Add(this.btnSave);
            this.KryptonPanel.Controls.Add(this.KryptonGroupBox2);
            this.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel.Name = "KryptonPanel";
            this.KryptonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.KryptonPanel.Size = new System.Drawing.Size(450, 237);
            this.KryptonPanel.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(376, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 29);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(300, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 29);
            this.btnSave.TabIndex = 44;
            this.btnSave.Values.Text = "&SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // KryptonGroupBox2
            // 
            this.KryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonGroupBox2.Location = new System.Drawing.Point(5, 5);
            this.KryptonGroupBox2.Name = "KryptonGroupBox2";
            // 
            // KryptonGroupBox2.Panel
            // 
            this.KryptonGroupBox2.Panel.Controls.Add(this.chkPreferred);
            this.KryptonGroupBox2.Panel.Controls.Add(this.cboContactLocation);
            this.KryptonGroupBox2.Panel.Controls.Add(this.KryptonLabel6);
            this.KryptonGroupBox2.Panel.Controls.Add(this.KryptonLabel3);
            this.KryptonGroupBox2.Panel.Controls.Add(this.KryptonLabel4);
            this.KryptonGroupBox2.Panel.Controls.Add(this.KryptonLabel5);
            this.KryptonGroupBox2.Panel.Controls.Add(this.RbContactNo);
            this.KryptonGroupBox2.Panel.Controls.Add(this.RbContactYes);
            this.KryptonGroupBox2.Panel.Controls.Add(this.cboContactType);
            this.KryptonGroupBox2.Panel.Controls.Add(this.txtContact);
            this.KryptonGroupBox2.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.KryptonGroupBox2.Size = new System.Drawing.Size(440, 185);
            this.KryptonGroupBox2.TabIndex = 43;
            this.KryptonGroupBox2.Text = "CONTACT INFORMATION";
            this.KryptonGroupBox2.Values.Heading = "CONTACT INFORMATION";
            // 
            // cboContactLocation
            // 
            this.cboContactLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactLocation.DropDownWidth = 121;
            this.cboContactLocation.Location = new System.Drawing.Point(167, 47);
            this.cboContactLocation.Name = "cboContactLocation";
            this.cboContactLocation.Size = new System.Drawing.Size(194, 21);
            this.cboContactLocation.TabIndex = 45;
            // 
            // KryptonLabel6
            // 
            this.KryptonLabel6.Location = new System.Drawing.Point(101, 107);
            this.KryptonLabel6.Name = "KryptonLabel6";
            this.KryptonLabel6.Size = new System.Drawing.Size(56, 20);
            this.KryptonLabel6.TabIndex = 54;
            this.KryptonLabel6.Values.Text = "ACTIVE :";
            // 
            // KryptonLabel3
            // 
            this.KryptonLabel3.Location = new System.Drawing.Point(5, 78);
            this.KryptonLabel3.Name = "KryptonLabel3";
            this.KryptonLabel3.Size = new System.Drawing.Size(157, 20);
            this.KryptonLabel3.TabIndex = 53;
            this.KryptonLabel3.Values.Text = "CONTACT INFORMATION :";
            // 
            // KryptonLabel4
            // 
            this.KryptonLabel4.Location = new System.Drawing.Point(27, 48);
            this.KryptonLabel4.Name = "KryptonLabel4";
            this.KryptonLabel4.Size = new System.Drawing.Size(134, 20);
            this.KryptonLabel4.TabIndex = 52;
            this.KryptonLabel4.Values.Text = "CONTACT LOCATION :";
            // 
            // KryptonLabel5
            // 
            this.KryptonLabel5.Location = new System.Drawing.Point(56, 20);
            this.KryptonLabel5.Name = "KryptonLabel5";
            this.KryptonLabel5.Size = new System.Drawing.Size(101, 20);
            this.KryptonLabel5.TabIndex = 51;
            this.KryptonLabel5.Values.Text = "CONTACT TYPE :";
            // 
            // RbContactNo
            // 
            this.RbContactNo.Location = new System.Drawing.Point(213, 107);
            this.RbContactNo.Name = "RbContactNo";
            this.RbContactNo.Size = new System.Drawing.Size(41, 20);
            this.RbContactNo.TabIndex = 45;
            this.RbContactNo.Values.Text = "NO";
            // 
            // RbContactYes
            // 
            this.RbContactYes.Checked = true;
            this.RbContactYes.Location = new System.Drawing.Point(167, 107);
            this.RbContactYes.Name = "RbContactYes";
            this.RbContactYes.Size = new System.Drawing.Size(42, 20);
            this.RbContactYes.TabIndex = 44;
            this.RbContactYes.Values.Text = "YES";
            // 
            // cboContactType
            // 
            this.cboContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactType.DropDownWidth = 121;
            this.cboContactType.Location = new System.Drawing.Point(167, 18);
            this.cboContactType.Name = "cboContactType";
            this.cboContactType.Size = new System.Drawing.Size(194, 21);
            this.cboContactType.TabIndex = 43;
            // 
            // txtContact
            // 
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.Location = new System.Drawing.Point(167, 76);
            this.txtContact.MaxLength = 200;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(194, 20);
            this.txtContact.TabIndex = 41;
            // 
            // KryptonManager
            // 
            this.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue;
            // 
            // errMsg
            // 
            this.errMsg.ContainerControl = this;
            // 
            // chkPreferred
            // 
            this.chkPreferred.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkPreferred.Location = new System.Drawing.Point(167, 132);
            this.chkPreferred.Name = "chkPreferred";
            this.chkPreferred.Size = new System.Drawing.Size(119, 20);
            this.chkPreferred.TabIndex = 55;
            this.chkPreferred.Text = "Preferred Contact";
            this.chkPreferred.Values.Text = "Preferred Contact";
            // 
            // NewContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 237);
            this.Controls.Add(this.KryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEW CONTACT FORM";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).EndInit();
            this.KryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox2.Panel)).EndInit();
            this.KryptonGroupBox2.Panel.ResumeLayout(false);
            this.KryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox2)).EndInit();
            this.KryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboContactLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContactType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMsg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox KryptonGroupBox2;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboContactLocation;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel6;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel5;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton RbContactNo;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton RbContactYes;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboContactType;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtContact;
        internal ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager;
        private System.Windows.Forms.ErrorProvider errMsg;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkPreferred;

    }
}