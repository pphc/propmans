namespace PROPMANS.VIEW.AccountManagement
{
    partial class NewAddressForm
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
            this.KryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.chkMakeDefault = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cboAddressType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.KryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RbAddressNo = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.RbAddressYes = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtAddressInformation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.errMsg = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).BeginInit();
            this.KryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox1.Panel)).BeginInit();
            this.KryptonGroupBox1.Panel.SuspendLayout();
            this.KryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAddressType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel
            // 
            this.KryptonPanel.Controls.Add(this.btnCancel);
            this.KryptonPanel.Controls.Add(this.btnSave);
            this.KryptonPanel.Controls.Add(this.KryptonGroupBox1);
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
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(300, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 29);
            this.btnSave.TabIndex = 42;
            this.btnSave.Values.Text = "&SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // KryptonGroupBox1
            // 
            this.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.KryptonGroupBox1.Name = "KryptonGroupBox1";
            // 
            // KryptonGroupBox1.Panel
            // 
            this.KryptonGroupBox1.Panel.Controls.Add(this.chkMakeDefault);
            this.KryptonGroupBox1.Panel.Controls.Add(this.cboAddressType);
            this.KryptonGroupBox1.Panel.Controls.Add(this.KryptonLabel2);
            this.KryptonGroupBox1.Panel.Controls.Add(this.KryptonLabel1);
            this.KryptonGroupBox1.Panel.Controls.Add(this.lblType);
            this.KryptonGroupBox1.Panel.Controls.Add(this.RbAddressNo);
            this.KryptonGroupBox1.Panel.Controls.Add(this.RbAddressYes);
            this.KryptonGroupBox1.Panel.Controls.Add(this.txtAddressInformation);
            this.KryptonGroupBox1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.KryptonGroupBox1.Size = new System.Drawing.Size(440, 194);
            this.KryptonGroupBox1.TabIndex = 41;
            this.KryptonGroupBox1.Text = "ADDRESS INFORMATION";
            this.KryptonGroupBox1.Values.Heading = "ADDRESS INFORMATION";
            // 
            // chkMakeDefault
            // 
            this.chkMakeDefault.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.chkMakeDefault.Location = new System.Drawing.Point(168, 139);
            this.chkMakeDefault.Name = "chkMakeDefault";
            this.chkMakeDefault.Size = new System.Drawing.Size(144, 20);
            this.chkMakeDefault.TabIndex = 52;
            this.chkMakeDefault.Text = "Make Default Address";
            this.chkMakeDefault.Values.Text = "Make Default Address";
            // 
            // cboAddressType
            // 
            this.cboAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddressType.DropDownWidth = 121;
            this.cboAddressType.Location = new System.Drawing.Point(168, 18);
            this.cboAddressType.Name = "cboAddressType";
            this.cboAddressType.Size = new System.Drawing.Size(251, 21);
            this.cboAddressType.TabIndex = 51;
            // 
            // KryptonLabel2
            // 
            this.KryptonLabel2.Location = new System.Drawing.Point(106, 113);
            this.KryptonLabel2.Name = "KryptonLabel2";
            this.KryptonLabel2.Size = new System.Drawing.Size(56, 20);
            this.KryptonLabel2.TabIndex = 50;
            this.KryptonLabel2.Values.Text = "ACTIVE :";
            // 
            // KryptonLabel1
            // 
            this.KryptonLabel1.Location = new System.Drawing.Point(4, 47);
            this.KryptonLabel1.Name = "KryptonLabel1";
            this.KryptonLabel1.Size = new System.Drawing.Size(158, 20);
            this.KryptonLabel1.TabIndex = 49;
            this.KryptonLabel1.Values.Text = "ADDRESS  INFORMATION :";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(63, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(99, 20);
            this.lblType.TabIndex = 48;
            this.lblType.Values.Text = "ADDRESS TYPE :";
            // 
            // RbAddressNo
            // 
            this.RbAddressNo.Location = new System.Drawing.Point(216, 113);
            this.RbAddressNo.Name = "RbAddressNo";
            this.RbAddressNo.Size = new System.Drawing.Size(41, 20);
            this.RbAddressNo.TabIndex = 47;
            this.RbAddressNo.Values.Text = "NO";
            // 
            // RbAddressYes
            // 
            this.RbAddressYes.Checked = true;
            this.RbAddressYes.Location = new System.Drawing.Point(168, 113);
            this.RbAddressYes.Name = "RbAddressYes";
            this.RbAddressYes.Size = new System.Drawing.Size(42, 20);
            this.RbAddressYes.TabIndex = 46;
            this.RbAddressYes.Values.Text = "YES";
            // 
            // txtAddressInformation
            // 
            this.txtAddressInformation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddressInformation.Location = new System.Drawing.Point(168, 45);
            this.txtAddressInformation.MaxLength = 200;
            this.txtAddressInformation.Multiline = true;
            this.txtAddressInformation.Name = "txtAddressInformation";
            this.txtAddressInformation.Size = new System.Drawing.Size(251, 62);
            this.txtAddressInformation.TabIndex = 38;
            // 
            // KryptonManager
            // 
            this.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue;
            // 
            // errMsg
            // 
            this.errMsg.ContainerControl = this;
            // 
            // NewAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 237);
            this.Controls.Add(this.KryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewAddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEW ADDRESS FORM";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).EndInit();
            this.KryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox1.Panel)).EndInit();
            this.KryptonGroupBox1.Panel.ResumeLayout(false);
            this.KryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox1)).EndInit();
            this.KryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAddressType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMsg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox KryptonGroupBox1;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkMakeDefault;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboAddressType;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblType;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton RbAddressNo;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton RbAddressYes;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAddressInformation;
        internal ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager;
        private System.Windows.Forms.ErrorProvider errMsg;


    }
}