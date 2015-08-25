namespace PROPMANS.VIEW.AccountManagement
{
    partial class HouseHoldForm
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
            this.KryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtOccupation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtHouseHoldName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.MoveInDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.MoveOutDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.KryptonLabel16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ComboBoxRelation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.BirthDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.KryptonLabel18 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel19 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel20 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonLabel21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblFirstName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.KryptonGroupBox5 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.KryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox5.Panel)).BeginInit();
            this.KryptonGroupBox5.Panel.SuspendLayout();
            this.KryptonGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).BeginInit();
            this.KryptonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonManager
            // 
            this.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(493, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "&SAVE";
            // 
            // txtOccupation
            // 
            this.txtOccupation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOccupation.Location = new System.Drawing.Point(112, 121);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(194, 20);
            this.txtOccupation.TabIndex = 4;
            // 
            // txtHouseHoldName
            // 
            this.txtHouseHoldName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHouseHoldName.Location = new System.Drawing.Point(112, 21);
            this.txtHouseHoldName.Name = "txtHouseHoldName";
            this.txtHouseHoldName.Size = new System.Drawing.Size(194, 19);
            this.txtHouseHoldName.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtHouseHoldName.TabIndex = 1;
            // 
            // MoveInDate
            // 
            this.MoveInDate.CustomNullText = "NOT AVAILABLE";
            this.MoveInDate.Location = new System.Drawing.Point(429, 88);
            this.MoveInDate.Name = "MoveInDate";
            this.MoveInDate.ShowCheckBox = true;
            this.MoveInDate.Size = new System.Drawing.Size(194, 21);
            this.MoveInDate.TabIndex = 7;
            // 
            // MoveOutDate
            // 
            this.MoveOutDate.CustomNullText = "NOT AVAILABLE";
            this.MoveOutDate.Location = new System.Drawing.Point(429, 123);
            this.MoveOutDate.Name = "MoveOutDate";
            this.MoveOutDate.ShowCheckBox = true;
            this.MoveOutDate.Size = new System.Drawing.Size(194, 21);
            this.MoveOutDate.TabIndex = 8;
            // 
            // KryptonLabel16
            // 
            this.KryptonLabel16.Location = new System.Drawing.Point(317, 122);
            this.KryptonLabel16.Name = "KryptonLabel16";
            this.KryptonLabel16.Size = new System.Drawing.Size(111, 20);
            this.KryptonLabel16.TabIndex = 57;
            this.KryptonLabel16.Values.Text = "MOVE OUT DATE :";
            // 
            // ComboBoxRelation
            // 
            this.ComboBoxRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRelation.DropDownWidth = 121;
            this.ComboBoxRelation.Items.AddRange(new object[] {
            "- SELECT -",
            "Sample 1",
            "Sample 2",
            "Sample 3",
            "Sample 4",
            "Sample 5"});
            this.ComboBoxRelation.Location = new System.Drawing.Point(429, 22);
            this.ComboBoxRelation.Name = "ComboBoxRelation";
            this.ComboBoxRelation.Size = new System.Drawing.Size(194, 21);
            this.ComboBoxRelation.TabIndex = 5;
            // 
            // BirthDate
            // 
            this.BirthDate.CustomNullText = "NOT AVAILABLE";
            this.BirthDate.Location = new System.Drawing.Point(429, 54);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ShowCheckBox = true;
            this.BirthDate.Size = new System.Drawing.Size(194, 21);
            this.BirthDate.TabIndex = 6;
            // 
            // KryptonLabel18
            // 
            this.KryptonLabel18.Location = new System.Drawing.Point(328, 88);
            this.KryptonLabel18.Name = "KryptonLabel18";
            this.KryptonLabel18.Size = new System.Drawing.Size(100, 20);
            this.KryptonLabel18.TabIndex = 54;
            this.KryptonLabel18.Values.Text = "MOVE IN DATE :";
            // 
            // KryptonLabel19
            // 
            this.KryptonLabel19.Location = new System.Drawing.Point(353, 22);
            this.KryptonLabel19.Name = "KryptonLabel19";
            this.KryptonLabel19.Size = new System.Drawing.Size(72, 20);
            this.KryptonLabel19.TabIndex = 53;
            this.KryptonLabel19.Values.Text = "RELATION :";
            // 
            // KryptonLabel20
            // 
            this.KryptonLabel20.Location = new System.Drawing.Point(18, 122);
            this.KryptonLabel20.Name = "KryptonLabel20";
            this.KryptonLabel20.Size = new System.Drawing.Size(93, 20);
            this.KryptonLabel20.TabIndex = 52;
            this.KryptonLabel20.Values.Text = "OCCUPATION :";
            // 
            // KryptonLabel21
            // 
            this.KryptonLabel21.Location = new System.Drawing.Point(343, 54);
            this.KryptonLabel21.Name = "KryptonLabel21";
            this.KryptonLabel21.Size = new System.Drawing.Size(82, 20);
            this.KryptonLabel21.TabIndex = 51;
            this.KryptonLabel21.Values.Text = "BIRTH DATE :";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(30, 21);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(81, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Values.Text = "FIRST NAME:";
            // 
            // KryptonGroupBox5
            // 
            this.KryptonGroupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonGroupBox5.Location = new System.Drawing.Point(5, 5);
            this.KryptonGroupBox5.Name = "KryptonGroupBox5";
            // 
            // KryptonGroupBox5.Panel
            // 
            this.KryptonGroupBox5.Panel.Controls.Add(this.kryptonTextBox2);
            this.KryptonGroupBox5.Panel.Controls.Add(this.kryptonLabel2);
            this.KryptonGroupBox5.Panel.Controls.Add(this.txtMiddleName);
            this.KryptonGroupBox5.Panel.Controls.Add(this.lblMiddleName);
            this.KryptonGroupBox5.Panel.Controls.Add(this.txtOccupation);
            this.KryptonGroupBox5.Panel.Controls.Add(this.txtHouseHoldName);
            this.KryptonGroupBox5.Panel.Controls.Add(this.MoveInDate);
            this.KryptonGroupBox5.Panel.Controls.Add(this.MoveOutDate);
            this.KryptonGroupBox5.Panel.Controls.Add(this.KryptonLabel16);
            this.KryptonGroupBox5.Panel.Controls.Add(this.ComboBoxRelation);
            this.KryptonGroupBox5.Panel.Controls.Add(this.BirthDate);
            this.KryptonGroupBox5.Panel.Controls.Add(this.KryptonLabel18);
            this.KryptonGroupBox5.Panel.Controls.Add(this.KryptonLabel19);
            this.KryptonGroupBox5.Panel.Controls.Add(this.KryptonLabel20);
            this.KryptonGroupBox5.Panel.Controls.Add(this.KryptonLabel21);
            this.KryptonGroupBox5.Panel.Controls.Add(this.lblFirstName);
            this.KryptonGroupBox5.Size = new System.Drawing.Size(634, 171);
            this.KryptonGroupBox5.TabIndex = 8;
            this.KryptonGroupBox5.Values.Heading = "";
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kryptonTextBox2.Location = new System.Drawing.Point(112, 88);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(194, 19);
            this.kryptonTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.kryptonTextBox2.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(35, 88);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel2.TabIndex = 68;
            this.kryptonLabel2.Values.Text = "LAST NAME:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleName.Location = new System.Drawing.Point(112, 54);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(194, 19);
            this.txtMiddleName.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMiddleName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.Location = new System.Drawing.Point(18, 53);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(95, 20);
            this.lblMiddleName.TabIndex = 66;
            this.lblMiddleName.Values.Text = "MIDDLE NAME:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(568, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "&CANCEL";
            // 
            // KryptonPanel
            // 
            this.KryptonPanel.Controls.Add(this.KryptonGroupBox5);
            this.KryptonPanel.Controls.Add(this.btnSave);
            this.KryptonPanel.Controls.Add(this.btnCancel);
            this.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel.Name = "KryptonPanel";
            this.KryptonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.KryptonPanel.Size = new System.Drawing.Size(644, 218);
            this.KryptonPanel.TabIndex = 1;
            // 
            // NewAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 218);
            this.Controls.Add(this.KryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewAddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOUSEHOLD FORM";
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox5.Panel)).EndInit();
            this.KryptonGroupBox5.Panel.ResumeLayout(false);
            this.KryptonGroupBox5.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonGroupBox5)).EndInit();
            this.KryptonGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel)).EndInit();
            this.KryptonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOccupation;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtHouseHoldName;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker MoveInDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker MoveOutDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel16;
        internal ComponentFactory.Krypton.Toolkit.KryptonComboBox ComboBoxRelation;
        internal ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker BirthDate;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel18;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel19;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel20;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel21;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblFirstName;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox KryptonGroupBox5;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMiddleName;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblMiddleName;



    }
}