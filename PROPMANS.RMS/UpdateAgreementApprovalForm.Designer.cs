namespace PROPMANS.RMS
{
    partial class UpdateAgreementApprovalForm
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
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtNotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboApprovalStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).BeginInit();
            this.MainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboApprovalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanael
            // 
            this.MainPanael.Controls.Add(this.kryptonGroupBox2);
            this.MainPanael.Controls.Add(this.btnCancel);
            this.MainPanael.Controls.Add(this.btnSave);
            this.MainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanael.Location = new System.Drawing.Point(0, 0);
            this.MainPanael.Name = "MainPanael";
            this.MainPanael.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.MainPanael.Size = new System.Drawing.Size(497, 191);
            this.MainPanael.TabIndex = 76;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(2, 10);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtNotes);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cboApprovalStatus);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel11);
            this.kryptonGroupBox2.Panel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(493, 127);
            this.kryptonGroupBox2.TabIndex = 21;
            this.kryptonGroupBox2.Text = "SELECT APPROVAL STATUS";
            this.kryptonGroupBox2.Values.Heading = "SELECT APPROVAL STATUS";
            // 
            // txtNotes
            // 
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotes.Location = new System.Drawing.Point(138, 38);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(340, 54);
            this.txtNotes.TabIndex = 126;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(76, 37);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(51, 20);
            this.kryptonLabel4.TabIndex = 125;
            this.kryptonLabel4.Values.Text = "NOTES:";
            // 
            // cboApprovalStatus
            // 
            this.cboApprovalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApprovalStatus.DropDownWidth = 121;
            this.cboApprovalStatus.Location = new System.Drawing.Point(138, 11);
            this.cboApprovalStatus.Name = "cboApprovalStatus";
            this.cboApprovalStatus.Size = new System.Drawing.Size(340, 21);
            this.cboApprovalStatus.TabIndex = 124;
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(8, 11);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(119, 20);
            this.kryptonLabel11.TabIndex = 117;
            this.kryptonLabel11.Values.Text = "APPROVAL STATUS:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(382, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(276, 145);
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
            // UpdateAgreementApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 191);
            this.Controls.Add(this.MainPanael);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateAgreementApprovalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE APPROVAL STATUS";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).EndInit();
            this.MainPanael.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboApprovalStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanael;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboApprovalStatus;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNotes;
    }
}