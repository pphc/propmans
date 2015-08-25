namespace PROPMANS.RMS
{
    partial class AgreementsSelectionForm
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
            this.lblAvailableUnitforRent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.RentalAgreementsDetailsPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgRentalAgreements = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSelect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cboLeaseType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).BeginInit();
            this.MainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RentalAgreementsDetailsPanel)).BeginInit();
            this.RentalAgreementsDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRentalAgreements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanael
            // 
            this.MainPanael.Controls.Add(this.lblAvailableUnitforRent);
            this.MainPanael.Controls.Add(this.kryptonGroupBox2);
            this.MainPanael.Controls.Add(this.btnCancel);
            this.MainPanael.Controls.Add(this.btnSelect);
            this.MainPanael.Controls.Add(this.cboLeaseType);
            this.MainPanael.Controls.Add(this.kryptonLabel7);
            this.MainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanael.Location = new System.Drawing.Point(0, 0);
            this.MainPanael.Name = "MainPanael";
            this.MainPanael.Padding = new System.Windows.Forms.Padding(2);
            this.MainPanael.Size = new System.Drawing.Size(1168, 408);
            this.MainPanael.TabIndex = 76;
            // 
            // lblAvailableUnitforRent
            // 
            this.lblAvailableUnitforRent.AutoSize = false;
            this.lblAvailableUnitforRent.Location = new System.Drawing.Point(1003, 325);
            this.lblAvailableUnitforRent.Name = "lblAvailableUnitforRent";
            this.lblAvailableUnitforRent.Size = new System.Drawing.Size(153, 20);
            this.lblAvailableUnitforRent.TabIndex = 96;
            this.lblAvailableUnitforRent.Values.Text = "No Records Found";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 48);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.RentalAgreementsDetailsPanel);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(1144, 273);
            this.kryptonGroupBox2.TabIndex = 21;
            this.kryptonGroupBox2.Values.Heading = "";
            // 
            // RentalAgreementsDetailsPanel
            // 
            this.RentalAgreementsDetailsPanel.Controls.Add(this.dgRentalAgreements);
            this.RentalAgreementsDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RentalAgreementsDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.RentalAgreementsDetailsPanel.Name = "RentalAgreementsDetailsPanel";
            this.RentalAgreementsDetailsPanel.Padding = new System.Windows.Forms.Padding(1);
            this.RentalAgreementsDetailsPanel.Size = new System.Drawing.Size(1140, 267);
            this.RentalAgreementsDetailsPanel.StateCommon.Color1 = System.Drawing.Color.Blue;
            this.RentalAgreementsDetailsPanel.TabIndex = 83;
            // 
            // dgRentalAgreements
            // 
            this.dgRentalAgreements.AllowUserToAddRows = false;
            this.dgRentalAgreements.AllowUserToDeleteRows = false;
            this.dgRentalAgreements.AllowUserToResizeRows = false;
            this.dgRentalAgreements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgRentalAgreements.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgRentalAgreements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRentalAgreements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgRentalAgreements.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgRentalAgreements.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgRentalAgreements.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgRentalAgreements.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgRentalAgreements.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgRentalAgreements.Location = new System.Drawing.Point(1, 1);
            this.dgRentalAgreements.Name = "dgRentalAgreements";
            this.dgRentalAgreements.RowHeadersWidth = 20;
            this.dgRentalAgreements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgRentalAgreements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRentalAgreements.Size = new System.Drawing.Size(1138, 265);
            this.dgRentalAgreements.TabIndex = 96;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1056, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Values.Text = "&CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(950, 353);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 39);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.Values.Text = "&SELECT";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboLeaseType
            // 
            this.cboLeaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaseType.DropDownWidth = 121;
            this.cboLeaseType.Location = new System.Drawing.Point(94, 21);
            this.cboLeaseType.Name = "cboLeaseType";
            this.cboLeaseType.Size = new System.Drawing.Size(344, 21);
            this.cboLeaseType.TabIndex = 95;
            this.cboLeaseType.SelectedIndexChanged += new System.EventHandler(this.cboLeaseType_SelectedIndexChanged);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(9, 21);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(79, 20);
            this.kryptonLabel7.TabIndex = 94;
            this.kryptonLabel7.Values.Text = "LEASE TYPE :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AgreementsSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 408);
            this.Controls.Add(this.MainPanael);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AgreementsSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECT RENTAL AGREEMENT";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanael)).EndInit();
            this.MainPanael.ResumeLayout(false);
            this.MainPanael.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RentalAgreementsDetailsPanel)).EndInit();
            this.RentalAgreementsDetailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRentalAgreements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanael;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSelect;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeaseType;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel RentalAgreementsDetailsPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgRentalAgreements;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblAvailableUnitforRent;
    }
}