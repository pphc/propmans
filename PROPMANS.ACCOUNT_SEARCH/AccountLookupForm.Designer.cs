namespace PROPMANS.ACCOUNT_SEARCH
{
    partial class AccountLookupForm 
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
            this.KryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnNewCustomer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSelect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.KryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ResultCountLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.CustAccountsResultsPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.CustomerAccountsGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.SearchAccountKryptonGroupBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnViewAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SearchValueTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ClearSearchValueButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.DisplayInactiveAccountsCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.ByFirstNameRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.ByUnitNumberRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.ByLastNameRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel4)).BeginInit();
            this.KryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel3)).BeginInit();
            this.KryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustAccountsResultsPanel)).BeginInit();
            this.CustAccountsResultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAccountsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchAccountKryptonGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchAccountKryptonGroupBox.Panel)).BeginInit();
            this.SearchAccountKryptonGroupBox.Panel.SuspendLayout();
            this.SearchAccountKryptonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.KryptonPanel4);
            this.MainPanel.Controls.Add(this.KryptonPanel3);
            this.MainPanel.Controls.Add(this.CustAccountsResultsPanel);
            this.MainPanel.Controls.Add(this.KryptonPanel2);
            this.MainPanel.Controls.Add(this.SearchAccountKryptonGroupBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.MainPanel.Size = new System.Drawing.Size(769, 471);
            this.MainPanel.TabIndex = 77;
            // 
            // KryptonPanel4
            // 
            this.KryptonPanel4.Controls.Add(this.btnNewCustomer);
            this.KryptonPanel4.Controls.Add(this.btnCancel);
            this.KryptonPanel4.Controls.Add(this.btnRefresh);
            this.KryptonPanel4.Controls.Add(this.btnSelect);
            this.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel4.Location = new System.Drawing.Point(10, 409);
            this.KryptonPanel4.Name = "KryptonPanel4";
            this.KryptonPanel4.Size = new System.Drawing.Size(749, 47);
            this.KryptonPanel4.TabIndex = 100;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(100, 3);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(80, 35);
            this.btnNewCustomer.TabIndex = 3;
            this.btnNewCustomer.Values.Text = "NEW";
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(662, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "C&ANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(14, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Values.Text = "REFRESH";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(575, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 35);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Values.Text = "S&ELECT";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // KryptonPanel3
            // 
            this.KryptonPanel3.Controls.Add(this.ResultCountLabel);
            this.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel3.Location = new System.Drawing.Point(10, 377);
            this.KryptonPanel3.Name = "KryptonPanel3";
            this.KryptonPanel3.Size = new System.Drawing.Size(749, 32);
            this.KryptonPanel3.TabIndex = 99;
            // 
            // ResultCountLabel
            // 
            this.ResultCountLabel.AutoSize = false;
            this.ResultCountLabel.Location = new System.Drawing.Point(511, 3);
            this.ResultCountLabel.Name = "ResultCountLabel";
            this.ResultCountLabel.Size = new System.Drawing.Size(225, 25);
            this.ResultCountLabel.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.ResultCountLabel.TabIndex = 13;
            this.ResultCountLabel.Values.Text = "";
            // 
            // CustAccountsResultsPanel
            // 
            this.CustAccountsResultsPanel.Controls.Add(this.CustomerAccountsGridView);
            this.CustAccountsResultsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustAccountsResultsPanel.Location = new System.Drawing.Point(10, 130);
            this.CustAccountsResultsPanel.Name = "CustAccountsResultsPanel";
            this.CustAccountsResultsPanel.Padding = new System.Windows.Forms.Padding(1);
            this.CustAccountsResultsPanel.Size = new System.Drawing.Size(749, 247);
            this.CustAccountsResultsPanel.StateCommon.Color1 = System.Drawing.Color.SteelBlue;
            this.CustAccountsResultsPanel.TabIndex = 98;
            // 
            // CustomerAccountsGridView
            // 
            this.CustomerAccountsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerAccountsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.CustomerAccountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerAccountsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerAccountsGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.CustomerAccountsGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.CustomerAccountsGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.CustomerAccountsGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.CustomerAccountsGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.CustomerAccountsGridView.Location = new System.Drawing.Point(1, 1);
            this.CustomerAccountsGridView.Name = "CustomerAccountsGridView";
            this.CustomerAccountsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerAccountsGridView.Size = new System.Drawing.Size(747, 245);
            this.CustomerAccountsGridView.TabIndex = 1;
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel2.Location = new System.Drawing.Point(10, 120);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.KryptonPanel2.Size = new System.Drawing.Size(749, 10);
            this.KryptonPanel2.TabIndex = 97;
            // 
            // SearchAccountKryptonGroupBox
            // 
            this.SearchAccountKryptonGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchAccountKryptonGroupBox.Location = new System.Drawing.Point(10, 20);
            this.SearchAccountKryptonGroupBox.Name = "SearchAccountKryptonGroupBox";
            // 
            // SearchAccountKryptonGroupBox.Panel
            // 
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.btnViewAll);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.SearchValueTextBox);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.btnSearch);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.DisplayInactiveAccountsCheckBox);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.ByFirstNameRadioButton);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.ByUnitNumberRadioButton);
            this.SearchAccountKryptonGroupBox.Panel.Controls.Add(this.ByLastNameRadioButton);
            this.SearchAccountKryptonGroupBox.Size = new System.Drawing.Size(749, 100);
            this.SearchAccountKryptonGroupBox.TabIndex = 96;
            this.SearchAccountKryptonGroupBox.Text = "SEARCH ACCOUNT BY";
            this.SearchAccountKryptonGroupBox.Values.Heading = "SEARCH ACCOUNT BY";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAll.Location = new System.Drawing.Point(660, 19);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(81, 39);
            this.btnViewAll.TabIndex = 6;
            this.btnViewAll.Values.Text = "&VIEW ALL";
            this.btnViewAll.Click += new System.EventHandler(this.txtViewAll_Click);
            // 
            // SearchValueTextBox
            // 
            this.SearchValueTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.ClearSearchValueButton});
            this.SearchValueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SearchValueTextBox.Location = new System.Drawing.Point(12, 45);
            this.SearchValueTextBox.Name = "SearchValueTextBox";
            this.SearchValueTextBox.Size = new System.Drawing.Size(289, 20);
            this.SearchValueTextBox.TabIndex = 0;
            this.SearchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SearchValueTextBox.TextChanged += new System.EventHandler(this.SearchValueTextBox_TextChanged);
            // 
            // ClearSearchValueButton
            // 
            this.ClearSearchValueButton.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.ClearSearchValueButton.UniqueName = "98EFC43EAFBD4ADEEB92E71BE322ED2C";
            this.ClearSearchValueButton.Click += new System.EventHandler(this.ClearSearchValueButton_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(573, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 39);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Values.Text = "&SEARCH";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DisplayInactiveAccountsCheckBox
            // 
            this.DisplayInactiveAccountsCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.DisplayInactiveAccountsCheckBox.Location = new System.Drawing.Point(307, 45);
            this.DisplayInactiveAccountsCheckBox.Name = "DisplayInactiveAccountsCheckBox";
            this.DisplayInactiveAccountsCheckBox.Size = new System.Drawing.Size(192, 20);
            this.DisplayInactiveAccountsCheckBox.TabIndex = 4;
            this.DisplayInactiveAccountsCheckBox.Text = "DISPLAY INACTIVE ACCOUNTS";
            this.DisplayInactiveAccountsCheckBox.Values.Text = "DISPLAY INACTIVE ACCOUNTS";
            // 
            // ByFirstNameRadioButton
            // 
            this.ByFirstNameRadioButton.Location = new System.Drawing.Point(214, 20);
            this.ByFirstNameRadioButton.Name = "ByFirstNameRadioButton";
            this.ByFirstNameRadioButton.Size = new System.Drawing.Size(90, 20);
            this.ByFirstNameRadioButton.TabIndex = 3;
            this.ByFirstNameRadioButton.Tag = "ByFirstName";
            this.ByFirstNameRadioButton.Values.Text = "FIRST NAME";
            this.ByFirstNameRadioButton.CheckedChanged += new System.EventHandler(this.SearchOptionRadioButton_CheckedChanged);
            // 
            // ByUnitNumberRadioButton
            // 
            this.ByUnitNumberRadioButton.Location = new System.Drawing.Point(12, 19);
            this.ByUnitNumberRadioButton.Name = "ByUnitNumberRadioButton";
            this.ByUnitNumberRadioButton.Size = new System.Drawing.Size(103, 20);
            this.ByUnitNumberRadioButton.TabIndex = 1;
            this.ByUnitNumberRadioButton.Tag = "ByUnitNumber";
            this.ByUnitNumberRadioButton.Values.Text = "UNIT NUMBER";
            this.ByUnitNumberRadioButton.CheckedChanged += new System.EventHandler(this.SearchOptionRadioButton_CheckedChanged);
            // 
            // ByLastNameRadioButton
            // 
            this.ByLastNameRadioButton.Location = new System.Drawing.Point(121, 20);
            this.ByLastNameRadioButton.Name = "ByLastNameRadioButton";
            this.ByLastNameRadioButton.Size = new System.Drawing.Size(87, 20);
            this.ByLastNameRadioButton.TabIndex = 2;
            this.ByLastNameRadioButton.Tag = "ByLastName";
            this.ByLastNameRadioButton.Values.Text = "LAST NAME";
            this.ByLastNameRadioButton.CheckedChanged += new System.EventHandler(this.SearchOptionRadioButton_CheckedChanged);
            // 
            // AccountLookupForm
            // 
            this.AcceptButton = this.btnViewAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 471);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(775, 500);
            this.Name = "AccountLookupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER ACCOUNT LOOKUP";
            this.Load += new System.EventHandler(this.AccountLookupForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel4)).EndInit();
            this.KryptonPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel3)).EndInit();
            this.KryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustAccountsResultsPanel)).EndInit();
            this.CustAccountsResultsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAccountsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchAccountKryptonGroupBox.Panel)).EndInit();
            this.SearchAccountKryptonGroupBox.Panel.ResumeLayout(false);
            this.SearchAccountKryptonGroupBox.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchAccountKryptonGroupBox)).EndInit();
            this.SearchAccountKryptonGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox SearchAccountKryptonGroupBox;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox SearchValueTextBox;
        internal ComponentFactory.Krypton.Toolkit.ButtonSpecAny ClearSearchValueButton;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox DisplayInactiveAccountsCheckBox;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton ByFirstNameRadioButton;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton ByUnitNumberRadioButton;
        internal ComponentFactory.Krypton.Toolkit.KryptonRadioButton ByLastNameRadioButton;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel CustAccountsResultsPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView CustomerAccountsGridView;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel3;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel ResultCountLabel;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel4;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnRefresh;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSelect;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnViewAll;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnNewCustomer;

    }
}

