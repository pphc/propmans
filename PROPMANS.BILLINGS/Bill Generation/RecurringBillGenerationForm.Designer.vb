<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecurringBillGenerationForm
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.RecurringBillTabControl = New System.Windows.Forms.TabControl()
        Me.IndividualGenerationTabPage = New System.Windows.Forms.TabPage()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.InvoiceDetailsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.gbAdminOption = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonCheckBox1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txPenalty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.chkEnableOverrideDefaults = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.pnlIndividualBillingamount = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtPenalty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel20 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtAmountDue = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpGracePeriodDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.nudBillingYear = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.dtpDueDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpStatementDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lblAccountName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtBillingNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnGenerateBill = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.SelectCustomerGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.pnlGridContainer = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblCustomerType = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel22 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblCustomerName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblUnitNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearchAccount = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BatchGenerationTabPage = New System.Windows.Forms.TabPage()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.BillingOptionsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dtpBatchGracePeriodDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel21 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnBatchGenerate = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dtpBatchStatementDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpBatchDueDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GenerationPreviewGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblActiveAccounts = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblBatchUnitstoGenerate = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblBatchUnits = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dgBuildingList = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.nudBatchBillingYear = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.cboBatchFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboBatchBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.RecurringBillTabControl.SuspendLayout()
        Me.IndividualGenerationTabPage.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.InvoiceDetailsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceDetailsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InvoiceDetailsGroupBox.Panel.SuspendLayout()
        Me.InvoiceDetailsGroupBox.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.gbAdminOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbAdminOption.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAdminOption.Panel.SuspendLayout()
        Me.gbAdminOption.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.pnlIndividualBillingamount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIndividualBillingamount.SuspendLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectCustomerGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SelectCustomerGroupBox.Panel.SuspendLayout()
        Me.SelectCustomerGroupBox.SuspendLayout()
        CType(Me.pnlGridContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGridContainer.SuspendLayout()
        Me.BatchGenerationTabPage.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.BillingOptionsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillingOptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BillingOptionsGroupBox.Panel.SuspendLayout()
        Me.BillingOptionsGroupBox.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.GenerationPreviewGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenerationPreviewGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GenerationPreviewGroupBox.Panel.SuspendLayout()
        Me.GenerationPreviewGroupBox.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dgBuildingList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.cboBatchFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBatchBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.RecurringBillTabControl)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(15)
        Me.KryptonPanel.Size = New System.Drawing.Size(1027, 746)
        Me.KryptonPanel.TabIndex = 1
        '
        'RecurringBillTabControl
        '
        Me.RecurringBillTabControl.Controls.Add(Me.BatchGenerationTabPage)
        Me.RecurringBillTabControl.Controls.Add(Me.IndividualGenerationTabPage)
        Me.RecurringBillTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecurringBillTabControl.Location = New System.Drawing.Point(15, 77)
        Me.RecurringBillTabControl.Name = "RecurringBillTabControl"
        Me.RecurringBillTabControl.SelectedIndex = 0
        Me.RecurringBillTabControl.Size = New System.Drawing.Size(997, 654)
        Me.RecurringBillTabControl.TabIndex = 25
        '
        'IndividualGenerationTabPage
        '
        Me.IndividualGenerationTabPage.Controls.Add(Me.KryptonPanel2)
        Me.IndividualGenerationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.IndividualGenerationTabPage.Name = "IndividualGenerationTabPage"
        Me.IndividualGenerationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.IndividualGenerationTabPage.Size = New System.Drawing.Size(989, 628)
        Me.IndividualGenerationTabPage.TabIndex = 0
        Me.IndividualGenerationTabPage.Text = "INDIVIDUAL GENERATION"
        Me.IndividualGenerationTabPage.UseVisualStyleBackColor = True
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.InvoiceDetailsGroupBox)
        Me.KryptonPanel2.Controls.Add(Me.SelectCustomerGroupBox)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(983, 622)
        Me.KryptonPanel2.TabIndex = 0
        '
        'InvoiceDetailsGroupBox
        '
        Me.InvoiceDetailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceDetailsGroupBox.Location = New System.Drawing.Point(0, 119)
        Me.InvoiceDetailsGroupBox.Name = "InvoiceDetailsGroupBox"
        '
        'InvoiceDetailsGroupBox.Panel
        '
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonPanel3)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.txtBillingNotes)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel4)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.btnGenerateBill)
        Me.InvoiceDetailsGroupBox.Size = New System.Drawing.Size(983, 503)
        Me.InvoiceDetailsGroupBox.TabIndex = 31
        Me.InvoiceDetailsGroupBox.Text = "INVOICE DETAILS"
        Me.InvoiceDetailsGroupBox.Values.Heading = "INVOICE DETAILS"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.gbAdminOption)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel3.Controls.Add(Me.lblAccountName)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(503, 479)
        Me.KryptonPanel3.TabIndex = 44
        '
        'gbAdminOption
        '
        Me.gbAdminOption.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbAdminOption.Location = New System.Drawing.Point(0, 257)
        Me.gbAdminOption.Name = "gbAdminOption"
        '
        'gbAdminOption.Panel
        '
        Me.gbAdminOption.Panel.Controls.Add(Me.KryptonCheckBox1)
        Me.gbAdminOption.Panel.Controls.Add(Me.txPenalty)
        Me.gbAdminOption.Panel.Controls.Add(Me.chkEnableOverrideDefaults)
        Me.gbAdminOption.Size = New System.Drawing.Size(503, 98)
        Me.gbAdminOption.TabIndex = 66
        Me.gbAdminOption.Text = "ADMIN OPTION"
        Me.gbAdminOption.Values.Heading = "ADMIN OPTION"
        '
        'KryptonCheckBox1
        '
        Me.KryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonCheckBox1.Location = New System.Drawing.Point(25, 38)
        Me.KryptonCheckBox1.Name = "KryptonCheckBox1"
        Me.KryptonCheckBox1.Size = New System.Drawing.Size(135, 20)
        Me.KryptonCheckBox1.TabIndex = 61
        Me.KryptonCheckBox1.Text = "OVERRIDE PENALTY:"
        Me.KryptonCheckBox1.Values.Text = "OVERRIDE PENALTY:"
        '
        'txPenalty
        '
        Me.txPenalty.Location = New System.Drawing.Point(157, 38)
        Me.txPenalty.Name = "txPenalty"
        Me.txPenalty.Size = New System.Drawing.Size(330, 20)
        Me.txPenalty.TabIndex = 60
        Me.txPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkEnableOverrideDefaults
        '
        Me.chkEnableOverrideDefaults.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkEnableOverrideDefaults.Location = New System.Drawing.Point(25, 13)
        Me.chkEnableOverrideDefaults.Name = "chkEnableOverrideDefaults"
        Me.chkEnableOverrideDefaults.Size = New System.Drawing.Size(139, 20)
        Me.chkEnableOverrideDefaults.TabIndex = 0
        Me.chkEnableOverrideDefaults.Text = "OVERRIDE DEFAULTS"
        Me.chkEnableOverrideDefaults.Values.Text = "OVERRIDE DEFAULTS"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.Controls.Add(Me.pnlIndividualBillingamount)
        Me.KryptonPanel8.Controls.Add(Me.dtpGracePeriodDate)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel8.Controls.Add(Me.nudBillingYear)
        Me.KryptonPanel8.Controls.Add(Me.dtpDueDate)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel8.Controls.Add(Me.cboBillingMonth)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel8.Controls.Add(Me.dtpStatementDate)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel8.Controls.Add(Me.cboFeeType)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(503, 257)
        Me.KryptonPanel8.TabIndex = 64
        '
        'pnlIndividualBillingamount
        '
        Me.pnlIndividualBillingamount.Controls.Add(Me.txtPenalty)
        Me.pnlIndividualBillingamount.Controls.Add(Me.KryptonLabel20)
        Me.pnlIndividualBillingamount.Controls.Add(Me.txtAmountDue)
        Me.pnlIndividualBillingamount.Controls.Add(Me.KryptonLabel2)
        Me.pnlIndividualBillingamount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlIndividualBillingamount.Location = New System.Drawing.Point(0, 184)
        Me.pnlIndividualBillingamount.Name = "pnlIndividualBillingamount"
        Me.pnlIndividualBillingamount.Size = New System.Drawing.Size(503, 73)
        Me.pnlIndividualBillingamount.TabIndex = 80
        '
        'txtPenalty
        '
        Me.txtPenalty.Location = New System.Drawing.Point(119, 38)
        Me.txtPenalty.Name = "txtPenalty"
        Me.txtPenalty.Size = New System.Drawing.Size(360, 20)
        Me.txtPenalty.TabIndex = 85
        Me.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Location = New System.Drawing.Point(50, 41)
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Size = New System.Drawing.Size(63, 20)
        Me.KryptonLabel20.TabIndex = 84
        Me.KryptonLabel20.Values.Text = "PENALTY:"
        '
        'txtAmountDue
        '
        Me.txtAmountDue.Location = New System.Drawing.Point(119, 13)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.Size = New System.Drawing.Size(360, 20)
        Me.txtAmountDue.TabIndex = 82
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(26, 16)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel2.TabIndex = 83
        Me.KryptonLabel2.Values.Text = "AMOUNT DUE:"
        '
        'dtpGracePeriodDate
        '
        Me.dtpGracePeriodDate.AlwaysActive = False
        Me.dtpGracePeriodDate.CustomNullText = "NOT APPLICABLE"
        Me.dtpGracePeriodDate.Location = New System.Drawing.Point(119, 158)
        Me.dtpGracePeriodDate.Name = "dtpGracePeriodDate"
        Me.dtpGracePeriodDate.ShowCheckBox = True
        Me.dtpGracePeriodDate.Size = New System.Drawing.Size(360, 21)
        Me.dtpGracePeriodDate.TabIndex = 79
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(21, 158)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(96, 20)
        Me.KryptonLabel12.TabIndex = 78
        Me.KryptonLabel12.Values.Text = "GRACE PERIOD:"
        '
        'nudBillingYear
        '
        Me.nudBillingYear.Location = New System.Drawing.Point(382, 62)
        Me.nudBillingYear.Name = "nudBillingYear"
        Me.nudBillingYear.Size = New System.Drawing.Size(97, 22)
        Me.nudBillingYear.TabIndex = 77
        '
        'dtpDueDate
        '
        Me.dtpDueDate.AlwaysActive = False
        Me.dtpDueDate.Location = New System.Drawing.Point(119, 132)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(360, 21)
        Me.dtpDueDate.TabIndex = 76
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(46, 133)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(69, 20)
        Me.KryptonLabel7.TabIndex = 75
        Me.KryptonLabel7.Values.Text = "DUE DATE:"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(337, 62)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(42, 20)
        Me.KryptonLabel6.TabIndex = 74
        Me.KryptonLabel6.Values.Text = "YEAR:"
        '
        'cboBillingMonth
        '
        Me.cboBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingMonth.DropDownWidth = 195
        Me.cboBillingMonth.Location = New System.Drawing.Point(119, 61)
        Me.cboBillingMonth.Name = "cboBillingMonth"
        Me.cboBillingMonth.Size = New System.Drawing.Size(212, 21)
        Me.cboBillingMonth.TabIndex = 73
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(59, 61)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(58, 20)
        Me.KryptonLabel5.TabIndex = 72
        Me.KryptonLabel5.Values.Text = "MONTH:"
        '
        'dtpStatementDate
        '
        Me.dtpStatementDate.AlwaysActive = False
        Me.dtpStatementDate.Location = New System.Drawing.Point(119, 106)
        Me.dtpStatementDate.Name = "dtpStatementDate"
        Me.dtpStatementDate.Size = New System.Drawing.Size(360, 21)
        Me.dtpStatementDate.TabIndex = 66
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(6, 107)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(113, 20)
        Me.KryptonLabel3.TabIndex = 68
        Me.KryptonLabel3.Values.Text = "STATEMENT DATE:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(56, 24)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel1.TabIndex = 65
        Me.KryptonLabel1.Values.Text = "FEE TYPE:"
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 195
        Me.cboFeeType.Location = New System.Drawing.Point(119, 21)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(360, 21)
        Me.cboFeeType.TabIndex = 64
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(16, 5)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(220, 23)
        Me.lblAccountName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.TabIndex = 50
        Me.lblAccountName.Values.Text = "Unit Number-AccountName"
        '
        'txtBillingNotes
        '
        Me.txtBillingNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBillingNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillingNotes.Location = New System.Drawing.Point(509, 132)
        Me.txtBillingNotes.MaxLength = 100
        Me.txtBillingNotes.Multiline = True
        Me.txtBillingNotes.Name = "txtBillingNotes"
        Me.txtBillingNotes.Size = New System.Drawing.Size(459, 84)
        Me.txtBillingNotes.TabIndex = 3
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(509, 107)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel4.TabIndex = 32
        Me.KryptonLabel4.Values.Text = "BILLING REMARKS"
        '
        'btnGenerateBill
        '
        Me.btnGenerateBill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateBill.Location = New System.Drawing.Point(854, 229)
        Me.btnGenerateBill.Name = "btnGenerateBill"
        Me.btnGenerateBill.Size = New System.Drawing.Size(114, 44)
        Me.btnGenerateBill.TabIndex = 4
        Me.btnGenerateBill.Values.Text = "GENERATE BILL"
        '
        'SelectCustomerGroupBox
        '
        Me.SelectCustomerGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.SelectCustomerGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.SelectCustomerGroupBox.Name = "SelectCustomerGroupBox"
        '
        'SelectCustomerGroupBox.Panel
        '
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.pnlGridContainer)
        Me.SelectCustomerGroupBox.Size = New System.Drawing.Size(983, 119)
        Me.SelectCustomerGroupBox.TabIndex = 30
        Me.SelectCustomerGroupBox.Text = "SELECT UNIT OWNER"
        Me.SelectCustomerGroupBox.Values.Heading = "SELECT UNIT OWNER"
        '
        'pnlGridContainer
        '
        Me.pnlGridContainer.Controls.Add(Me.lblCustomerType)
        Me.pnlGridContainer.Controls.Add(Me.KryptonLabel22)
        Me.pnlGridContainer.Controls.Add(Me.lblCustomerName)
        Me.pnlGridContainer.Controls.Add(Me.KryptonLabel19)
        Me.pnlGridContainer.Controls.Add(Me.KryptonLabel13)
        Me.pnlGridContainer.Controls.Add(Me.lblUnitNumber)
        Me.pnlGridContainer.Controls.Add(Me.btnSearchAccount)
        Me.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlGridContainer.Name = "pnlGridContainer"
        Me.pnlGridContainer.Padding = New System.Windows.Forms.Padding(20, 10, 10, 10)
        Me.pnlGridContainer.Size = New System.Drawing.Size(979, 95)
        Me.pnlGridContainer.TabIndex = 26
        '
        'lblCustomerType
        '
        Me.lblCustomerType.AutoSize = False
        Me.lblCustomerType.Location = New System.Drawing.Point(159, 68)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(518, 19)
        Me.lblCustomerType.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerType.TabIndex = 71
        Me.lblCustomerType.Values.Text = "CUSTOMER TYPE"
        '
        'KryptonLabel22
        '
        Me.KryptonLabel22.Location = New System.Drawing.Point(55, 68)
        Me.KryptonLabel22.Name = "KryptonLabel22"
        Me.KryptonLabel22.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel22.TabIndex = 70
        Me.KryptonLabel22.Values.Text = "CUSTOMER TYPE:"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = False
        Me.lblCustomerName.Location = New System.Drawing.Point(159, 42)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(518, 19)
        Me.lblCustomerName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerName.TabIndex = 69
        Me.lblCustomerName.Values.Text = "CUSTOMER NAME"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Location = New System.Drawing.Point(48, 42)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Size = New System.Drawing.Size(114, 20)
        Me.KryptonLabel19.TabIndex = 68
        Me.KryptonLabel19.Values.Text = "CUSTOMER NAME:"
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(67, 17)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(94, 20)
        Me.KryptonLabel13.TabIndex = 67
        Me.KryptonLabel13.Values.Text = "UNIT NUMBER:"
        '
        'lblUnitNumber
        '
        Me.lblUnitNumber.Location = New System.Drawing.Point(159, 17)
        Me.lblUnitNumber.Name = "lblUnitNumber"
        Me.lblUnitNumber.Size = New System.Drawing.Size(106, 19)
        Me.lblUnitNumber.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitNumber.TabIndex = 66
        Me.lblUnitNumber.Values.Text = "UNIT NUMBER"
        '
        'btnSearchAccount
        '
        Me.btnSearchAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchAccount.Location = New System.Drawing.Point(869, 17)
        Me.btnSearchAccount.Name = "btnSearchAccount"
        Me.btnSearchAccount.Size = New System.Drawing.Size(100, 44)
        Me.btnSearchAccount.TabIndex = 5
        Me.btnSearchAccount.Values.Text = "SEARCH"
        '
        'BatchGenerationTabPage
        '
        Me.BatchGenerationTabPage.Controls.Add(Me.KryptonPanel4)
        Me.BatchGenerationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.BatchGenerationTabPage.Name = "BatchGenerationTabPage"
        Me.BatchGenerationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.BatchGenerationTabPage.Size = New System.Drawing.Size(989, 628)
        Me.BatchGenerationTabPage.TabIndex = 1
        Me.BatchGenerationTabPage.Text = "BATCH GENERATION"
        Me.BatchGenerationTabPage.UseVisualStyleBackColor = True
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel4.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(983, 622)
        Me.KryptonPanel4.TabIndex = 0
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.Controls.Add(Me.BillingOptionsGroupBox)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel7.Location = New System.Drawing.Point(500, 99)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel7.Size = New System.Drawing.Size(483, 523)
        Me.KryptonPanel7.TabIndex = 73
        '
        'BillingOptionsGroupBox
        '
        Me.BillingOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.BillingOptionsGroupBox.Location = New System.Drawing.Point(10, 10)
        Me.BillingOptionsGroupBox.Name = "BillingOptionsGroupBox"
        '
        'BillingOptionsGroupBox.Panel
        '
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.dtpBatchGracePeriodDate)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel21)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.btnBatchGenerate)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.dtpBatchStatementDate)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel17)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.dtpBatchDueDate)
        Me.BillingOptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel18)
        Me.BillingOptionsGroupBox.Size = New System.Drawing.Size(463, 225)
        Me.BillingOptionsGroupBox.TabIndex = 70
        Me.BillingOptionsGroupBox.Text = "BILLING OPTIONS"
        Me.BillingOptionsGroupBox.Values.Heading = "BILLING OPTIONS"
        '
        'dtpBatchGracePeriodDate
        '
        Me.dtpBatchGracePeriodDate.AlwaysActive = False
        Me.dtpBatchGracePeriodDate.CustomNullText = "NOT APPLICABLE"
        Me.dtpBatchGracePeriodDate.Location = New System.Drawing.Point(153, 94)
        Me.dtpBatchGracePeriodDate.Name = "dtpBatchGracePeriodDate"
        Me.dtpBatchGracePeriodDate.ShowCheckBox = True
        Me.dtpBatchGracePeriodDate.Size = New System.Drawing.Size(290, 21)
        Me.dtpBatchGracePeriodDate.TabIndex = 74
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Location = New System.Drawing.Point(58, 95)
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Size = New System.Drawing.Size(96, 20)
        Me.KryptonLabel21.TabIndex = 73
        Me.KryptonLabel21.Values.Text = "GRACE PERIOD:"
        '
        'btnBatchGenerate
        '
        Me.btnBatchGenerate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBatchGenerate.Location = New System.Drawing.Point(232, 144)
        Me.btnBatchGenerate.Name = "btnBatchGenerate"
        Me.btnBatchGenerate.Size = New System.Drawing.Size(211, 36)
        Me.btnBatchGenerate.TabIndex = 71
        Me.btnBatchGenerate.Values.Text = "START BATCH GENERATION"
        '
        'dtpBatchStatementDate
        '
        Me.dtpBatchStatementDate.AlwaysActive = False
        Me.dtpBatchStatementDate.Location = New System.Drawing.Point(153, 41)
        Me.dtpBatchStatementDate.Name = "dtpBatchStatementDate"
        Me.dtpBatchStatementDate.Size = New System.Drawing.Size(290, 21)
        Me.dtpBatchStatementDate.TabIndex = 65
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.Location = New System.Drawing.Point(83, 70)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(69, 20)
        Me.KryptonLabel17.TabIndex = 67
        Me.KryptonLabel17.Values.Text = "DUE DATE:"
        '
        'dtpBatchDueDate
        '
        Me.dtpBatchDueDate.AlwaysActive = False
        Me.dtpBatchDueDate.Location = New System.Drawing.Point(153, 67)
        Me.dtpBatchDueDate.Name = "dtpBatchDueDate"
        Me.dtpBatchDueDate.Size = New System.Drawing.Size(290, 21)
        Me.dtpBatchDueDate.TabIndex = 68
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Location = New System.Drawing.Point(43, 42)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(113, 20)
        Me.KryptonLabel18.TabIndex = 66
        Me.KryptonLabel18.Values.Text = "STATEMENT DATE:"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.Controls.Add(Me.GenerationPreviewGroupBox)
        Me.KryptonPanel6.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel6.Location = New System.Drawing.Point(0, 99)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel6.Size = New System.Drawing.Size(500, 523)
        Me.KryptonPanel6.TabIndex = 72
        '
        'GenerationPreviewGroupBox
        '
        Me.GenerationPreviewGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.GenerationPreviewGroupBox.Location = New System.Drawing.Point(10, 235)
        Me.GenerationPreviewGroupBox.Name = "GenerationPreviewGroupBox"
        '
        'GenerationPreviewGroupBox.Panel
        '
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.lblActiveAccounts)
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.KryptonLabel11)
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.lblBatchUnitstoGenerate)
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.KryptonLabel14)
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.KryptonLabel15)
        Me.GenerationPreviewGroupBox.Panel.Controls.Add(Me.lblBatchUnits)
        Me.GenerationPreviewGroupBox.Size = New System.Drawing.Size(480, 188)
        Me.GenerationPreviewGroupBox.TabIndex = 71
        Me.GenerationPreviewGroupBox.Text = "SELECTION PREVIEW"
        Me.GenerationPreviewGroupBox.Values.Heading = "SELECTION PREVIEW"
        '
        'lblActiveAccounts
        '
        Me.lblActiveAccounts.Location = New System.Drawing.Point(142, 66)
        Me.lblActiveAccounts.Name = "lblActiveAccounts"
        Me.lblActiveAccounts.Size = New System.Drawing.Size(51, 19)
        Me.lblActiveAccounts.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveAccounts.TabIndex = 57
        Me.lblActiveAccounts.Values.Text = "UNITS"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(26, 66)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel11.TabIndex = 56
        Me.KryptonLabel11.Values.Text = "ACTIVE ACCOUNTS:"
        '
        'lblBatchUnitstoGenerate
        '
        Me.lblBatchUnitstoGenerate.Location = New System.Drawing.Point(142, 102)
        Me.lblBatchUnitstoGenerate.Name = "lblBatchUnitstoGenerate"
        Me.lblBatchUnitstoGenerate.Size = New System.Drawing.Size(51, 19)
        Me.lblBatchUnitstoGenerate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchUnitstoGenerate.TabIndex = 55
        Me.lblBatchUnitstoGenerate.Values.Text = "UNITS"
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Location = New System.Drawing.Point(52, 31)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel14.TabIndex = 52
        Me.KryptonLabel14.Values.Text = "NO. OF UNITS:"
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.Location = New System.Drawing.Point(12, 102)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Size = New System.Drawing.Size(135, 20)
        Me.KryptonLabel15.TabIndex = 54
        Me.KryptonLabel15.Values.Text = "UNBILLED ACCOUNTS:"
        '
        'lblBatchUnits
        '
        Me.lblBatchUnits.Location = New System.Drawing.Point(142, 31)
        Me.lblBatchUnits.Name = "lblBatchUnits"
        Me.lblBatchUnits.Size = New System.Drawing.Size(51, 19)
        Me.lblBatchUnits.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchUnits.TabIndex = 53
        Me.lblBatchUnits.Values.Text = "UNITS"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(10, 10)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dgBuildingList)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(2)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(480, 225)
        Me.KryptonGroupBox2.TabIndex = 70
        Me.KryptonGroupBox2.Text = "SELECT BUILDING"
        Me.KryptonGroupBox2.Values.Heading = "SELECT BUILDING"
        '
        'dgBuildingList
        '
        Me.dgBuildingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBuildingList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBuildingList.Location = New System.Drawing.Point(2, 2)
        Me.dgBuildingList.Name = "dgBuildingList"
        Me.dgBuildingList.Size = New System.Drawing.Size(472, 197)
        Me.dgBuildingList.TabIndex = 0
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.nudBatchBillingYear)
        Me.KryptonPanel5.Controls.Add(Me.cboBatchFeeType)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel5.Controls.Add(Me.cboBatchBillingMonth)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(983, 99)
        Me.KryptonPanel5.TabIndex = 71
        '
        'nudBatchBillingYear
        '
        Me.nudBatchBillingYear.Location = New System.Drawing.Point(345, 51)
        Me.nudBatchBillingYear.Name = "nudBatchBillingYear"
        Me.nudBatchBillingYear.Size = New System.Drawing.Size(97, 22)
        Me.nudBatchBillingYear.TabIndex = 62
        '
        'cboBatchFeeType
        '
        Me.cboBatchFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBatchFeeType.DropDownWidth = 195
        Me.cboBatchFeeType.Location = New System.Drawing.Point(82, 22)
        Me.cboBatchFeeType.Name = "cboBatchFeeType"
        Me.cboBatchFeeType.Size = New System.Drawing.Size(360, 21)
        Me.cboBatchFeeType.TabIndex = 56
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(19, 25)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel10.TabIndex = 57
        Me.KryptonLabel10.Values.Text = "FEE TYPE:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(22, 50)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(58, 20)
        Me.KryptonLabel9.TabIndex = 58
        Me.KryptonLabel9.Values.Text = "MONTH:"
        '
        'cboBatchBillingMonth
        '
        Me.cboBatchBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBatchBillingMonth.DropDownWidth = 195
        Me.cboBatchBillingMonth.Location = New System.Drawing.Point(82, 50)
        Me.cboBatchBillingMonth.Name = "cboBatchBillingMonth"
        Me.cboBatchBillingMonth.Size = New System.Drawing.Size(212, 21)
        Me.cboBatchBillingMonth.TabIndex = 59
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(300, 50)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(42, 20)
        Me.KryptonLabel8.TabIndex = 60
        Me.KryptonLabel8.Values.Text = "YEAR:"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(15, 54)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(997, 23)
        Me.KryptonPanel1.TabIndex = 24
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(15, 15)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(997, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 23
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "RECURRING BILL GENERATION"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'RecurringBillGenerationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 746)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "RecurringBillGenerationForm"
        Me.Text = "Recurring Bill Generation"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.RecurringBillTabControl.ResumeLayout(False)
        Me.IndividualGenerationTabPage.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.InvoiceDetailsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoiceDetailsGroupBox.Panel.ResumeLayout(False)
        Me.InvoiceDetailsGroupBox.Panel.PerformLayout()
        CType(Me.InvoiceDetailsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoiceDetailsGroupBox.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.gbAdminOption.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAdminOption.Panel.ResumeLayout(False)
        Me.gbAdminOption.Panel.PerformLayout()
        CType(Me.gbAdminOption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAdminOption.ResumeLayout(False)
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.pnlIndividualBillingamount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIndividualBillingamount.ResumeLayout(False)
        Me.pnlIndividualBillingamount.PerformLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectCustomerGroupBox.Panel.ResumeLayout(False)
        CType(Me.SelectCustomerGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectCustomerGroupBox.ResumeLayout(False)
        CType(Me.pnlGridContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGridContainer.ResumeLayout(False)
        Me.pnlGridContainer.PerformLayout()
        Me.BatchGenerationTabPage.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        CType(Me.BillingOptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BillingOptionsGroupBox.Panel.ResumeLayout(False)
        Me.BillingOptionsGroupBox.Panel.PerformLayout()
        CType(Me.BillingOptionsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BillingOptionsGroupBox.ResumeLayout(False)
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        CType(Me.GenerationPreviewGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GenerationPreviewGroupBox.Panel.ResumeLayout(False)
        Me.GenerationPreviewGroupBox.Panel.PerformLayout()
        CType(Me.GenerationPreviewGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GenerationPreviewGroupBox.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dgBuildingList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.cboBatchFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBatchBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents RecurringBillTabControl As System.Windows.Forms.TabControl
    Friend WithEvents IndividualGenerationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents InvoiceDetailsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents gbAdminOption As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonCheckBox1 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txPenalty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents chkEnableOverrideDefaults As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents nudBillingYear As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents dtpDueDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpStatementDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lblAccountName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtBillingNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnGenerateBill As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents SelectCustomerGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents pnlGridContainer As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblCustomerName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblUnitNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearchAccount As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BatchGenerationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents BillingOptionsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnBatchGenerate As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpBatchStatementDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpBatchDueDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents GenerationPreviewGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblBatchUnitstoGenerate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblBatchUnits As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents nudBatchBillingYear As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents cboBatchFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboBatchBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dtpGracePeriodDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlIndividualBillingamount As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtPenalty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel20 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAmountDue As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dgBuildingList As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents dtpBatchGracePeriodDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel21 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblActiveAccounts As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblCustomerType As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel22 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
