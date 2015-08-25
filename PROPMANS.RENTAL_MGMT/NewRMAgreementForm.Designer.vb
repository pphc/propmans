<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewRentalManagementAgrreementFrom
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
        Me.NewRentalManagementAgreementPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.CenterPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.nudNoOfMonths = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCondoDuesPayment = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.dtpAgreementDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.txtMgmtRate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtRentUp = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtCashBond = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtSecurityDeposit = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtPrepaidRent = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtRentAmount = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboRemittanceRelease = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboUnitClassification = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtMaxOccupant = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.dtpContractEnd = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.dtpContractStart = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.TopPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.gboxSelectUnitOwner = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtunitType = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtunitOwner = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtUnitNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.NewRentalManagementAgreementPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NewRentalManagementAgreementPanel.SuspendLayout()
        CType(Me.CenterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CenterPanel.SuspendLayout()
        CType(Me.cboCondoDuesPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRemittanceRelease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnitClassification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopPanel.SuspendLayout()
        CType(Me.gboxSelectUnitOwner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gboxSelectUnitOwner.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSelectUnitOwner.Panel.SuspendLayout()
        Me.gboxSelectUnitOwner.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NewRentalManagementAgreementPanel
        '
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.CenterPanel)
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.TopPanel)
        Me.NewRentalManagementAgreementPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NewRentalManagementAgreementPanel.Location = New System.Drawing.Point(0, 0)
        Me.NewRentalManagementAgreementPanel.Name = "NewRentalManagementAgreementPanel"
        Me.NewRentalManagementAgreementPanel.Size = New System.Drawing.Size(689, 514)
        Me.NewRentalManagementAgreementPanel.TabIndex = 0
        '
        'CenterPanel
        '
        Me.CenterPanel.Controls.Add(Me.nudNoOfMonths)
        Me.CenterPanel.Controls.Add(Me.btnCancel)
        Me.CenterPanel.Controls.Add(Me.btnSave)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel19)
        Me.CenterPanel.Controls.Add(Me.cboCondoDuesPayment)
        Me.CenterPanel.Controls.Add(Me.dtpAgreementDate)
        Me.CenterPanel.Controls.Add(Me.txtMgmtRate)
        Me.CenterPanel.Controls.Add(Me.txtRentUp)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel16)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel17)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel18)
        Me.CenterPanel.Controls.Add(Me.txtCashBond)
        Me.CenterPanel.Controls.Add(Me.txtSecurityDeposit)
        Me.CenterPanel.Controls.Add(Me.txtPrepaidRent)
        Me.CenterPanel.Controls.Add(Me.txtRentAmount)
        Me.CenterPanel.Controls.Add(Me.cboRemittanceRelease)
        Me.CenterPanel.Controls.Add(Me.cboUnitClassification)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel13)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel12)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel11)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel10)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel9)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel8)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel7)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel6)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel4)
        Me.CenterPanel.Controls.Add(Me.KryptonLabel5)
        Me.CenterPanel.Controls.Add(Me.txtMaxOccupant)
        Me.CenterPanel.Controls.Add(Me.dtpContractEnd)
        Me.CenterPanel.Controls.Add(Me.dtpContractStart)
        Me.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CenterPanel.Location = New System.Drawing.Point(0, 157)
        Me.CenterPanel.Name = "CenterPanel"
        Me.CenterPanel.Size = New System.Drawing.Size(689, 357)
        Me.CenterPanel.TabIndex = 1
        '
        'nudNoOfMonths
        '
        Me.nudNoOfMonths.Location = New System.Drawing.Point(147, 47)
        Me.nudNoOfMonths.Maximum = New Decimal(New Integer() {-1304428545, 434162106, 542, 0})
        Me.nudNoOfMonths.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNoOfMonths.Name = "nudNoOfMonths"
        Me.nudNoOfMonths.Size = New System.Drawing.Size(175, 22)
        Me.nudNoOfMonths.TabIndex = 4
        Me.nudNoOfMonths.UpDownButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
        Me.nudNoOfMonths.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(562, 295)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 46)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(444, 295)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 46)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Values.Text = "&SAVE"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel19.Location = New System.Drawing.Point(337, 244)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Size = New System.Drawing.Size(152, 20)
        Me.KryptonLabel19.TabIndex = 102
        Me.KryptonLabel19.Values.Text = "CONDO DUES PAYMENT :"
        Me.KryptonLabel19.Visible = False
        '
        'cboCondoDuesPayment
        '
        Me.cboCondoDuesPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCondoDuesPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondoDuesPayment.DropDownWidth = 121
        Me.cboCondoDuesPayment.Location = New System.Drawing.Point(495, 241)
        Me.cboCondoDuesPayment.Name = "cboCondoDuesPayment"
        Me.cboCondoDuesPayment.Size = New System.Drawing.Size(175, 21)
        Me.cboCondoDuesPayment.TabIndex = 16
        Me.cboCondoDuesPayment.Visible = False
        '
        'dtpAgreementDate
        '
        Me.dtpAgreementDate.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpAgreementDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpAgreementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAgreementDate.Location = New System.Drawing.Point(147, 21)
        Me.dtpAgreementDate.Name = "dtpAgreementDate"
        Me.dtpAgreementDate.Size = New System.Drawing.Size(175, 21)
        Me.dtpAgreementDate.TabIndex = 3
        '
        'txtMgmtRate
        '
        Me.txtMgmtRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMgmtRate.Enabled = False
        Me.txtMgmtRate.Location = New System.Drawing.Point(495, 185)
        Me.txtMgmtRate.Name = "txtMgmtRate"
        Me.txtMgmtRate.Size = New System.Drawing.Size(175, 20)
        Me.txtMgmtRate.TabIndex = 14
        Me.txtMgmtRate.Text = "10"
        Me.txtMgmtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRentUp
        '
        Me.txtRentUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRentUp.Enabled = False
        Me.txtRentUp.Location = New System.Drawing.Point(495, 157)
        Me.txtRentUp.Name = "txtRentUp"
        Me.txtRentUp.Size = New System.Drawing.Size(175, 20)
        Me.txtRentUp.TabIndex = 13
        Me.txtRentUp.Text = "100"
        Me.txtRentUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRentUp.Visible = False
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel16.Location = New System.Drawing.Point(411, 160)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(78, 20)
        Me.KryptonLabel16.TabIndex = 96
        Me.KryptonLabel16.Values.Text = "RENT UP % :"
        Me.KryptonLabel16.Visible = False
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel17.Location = New System.Drawing.Point(350, 216)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(139, 20)
        Me.KryptonLabel17.TabIndex = 95
        Me.KryptonLabel17.Values.Text = "REMITTANCE RELEASE :"
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel18.Location = New System.Drawing.Point(390, 188)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel18.TabIndex = 94
        Me.KryptonLabel18.Values.Text = "MGMT RATE % :"
        '
        'txtCashBond
        '
        Me.txtCashBond.Location = New System.Drawing.Point(147, 242)
        Me.txtCashBond.Name = "txtCashBond"
        Me.txtCashBond.Size = New System.Drawing.Size(175, 20)
        Me.txtCashBond.TabIndex = 12
        Me.txtCashBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSecurityDeposit
        '
        Me.txtSecurityDeposit.Enabled = False
        Me.txtSecurityDeposit.Location = New System.Drawing.Point(147, 213)
        Me.txtSecurityDeposit.Name = "txtSecurityDeposit"
        Me.txtSecurityDeposit.Size = New System.Drawing.Size(175, 20)
        Me.txtSecurityDeposit.TabIndex = 11
        Me.txtSecurityDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrepaidRent
        '
        Me.txtPrepaidRent.Enabled = False
        Me.txtPrepaidRent.Location = New System.Drawing.Point(147, 185)
        Me.txtPrepaidRent.Name = "txtPrepaidRent"
        Me.txtPrepaidRent.Size = New System.Drawing.Size(175, 20)
        Me.txtPrepaidRent.TabIndex = 10
        Me.txtPrepaidRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRentAmount
        '
        Me.txtRentAmount.Location = New System.Drawing.Point(147, 157)
        Me.txtRentAmount.MaxLength = 14
        Me.txtRentAmount.Name = "txtRentAmount"
        Me.txtRentAmount.Size = New System.Drawing.Size(175, 20)
        Me.txtRentAmount.TabIndex = 9
        Me.txtRentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRemittanceRelease
        '
        Me.cboRemittanceRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRemittanceRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRemittanceRelease.DropDownWidth = 121
        Me.cboRemittanceRelease.Location = New System.Drawing.Point(495, 213)
        Me.cboRemittanceRelease.Name = "cboRemittanceRelease"
        Me.cboRemittanceRelease.Size = New System.Drawing.Size(175, 21)
        Me.cboRemittanceRelease.TabIndex = 15
        '
        'cboUnitClassification
        '
        Me.cboUnitClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitClassification.DropDownWidth = 121
        Me.cboUnitClassification.Location = New System.Drawing.Point(147, 101)
        Me.cboUnitClassification.Name = "cboUnitClassification"
        Me.cboUnitClassification.Size = New System.Drawing.Size(175, 21)
        Me.cboUnitClassification.TabIndex = 7
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(58, 245)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(85, 20)
        Me.KryptonLabel13.TabIndex = 85
        Me.KryptonLabel13.Values.Text = "CASH BOND :"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(26, 216)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(120, 20)
        Me.KryptonLabel12.TabIndex = 84
        Me.KryptonLabel12.Values.Text = "SECURITY DEPOSIT :"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(48, 188)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(97, 20)
        Me.KryptonLabel11.TabIndex = 83
        Me.KryptonLabel11.Values.Text = "PREPAID RENT :"
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(43, 160)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel10.TabIndex = 82
        Me.KryptonLabel10.Values.Text = "RENT AMOUNT :"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(30, 132)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(117, 20)
        Me.KryptonLabel9.TabIndex = 81
        Me.KryptonLabel9.Values.Text = "MAX OCCUPANTS :"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(12, 104)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(139, 20)
        Me.KryptonLabel8.TabIndex = 80
        Me.KryptonLabel8.Values.Text = "UNIT CLASSIFICATION :"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(328, 76)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(26, 20)
        Me.KryptonLabel7.TabIndex = 79
        Me.KryptonLabel7.Values.Text = "TO"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(37, 76)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(109, 20)
        Me.KryptonLabel6.TabIndex = 78
        Me.KryptonLabel6.Values.Text = "DATE AVAILABLE :"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(40, 49)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(109, 20)
        Me.KryptonLabel4.TabIndex = 77
        Me.KryptonLabel4.Values.Text = "NO OF MONTHS :"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(28, 21)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel5.TabIndex = 76
        Me.KryptonLabel5.Values.Text = "AGREEMENT DATE :"
        '
        'txtMaxOccupant
        '
        Me.txtMaxOccupant.Location = New System.Drawing.Point(147, 129)
        Me.txtMaxOccupant.MaxLength = 2
        Me.txtMaxOccupant.Name = "txtMaxOccupant"
        Me.txtMaxOccupant.Size = New System.Drawing.Size(175, 20)
        Me.txtMaxOccupant.TabIndex = 8
        Me.txtMaxOccupant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpContractEnd
        '
        Me.dtpContractEnd.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpContractEnd.CustomFormat = "MMMM dd, yyyy"
        Me.dtpContractEnd.Enabled = False
        Me.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpContractEnd.Location = New System.Drawing.Point(359, 75)
        Me.dtpContractEnd.Name = "dtpContractEnd"
        Me.dtpContractEnd.Size = New System.Drawing.Size(175, 21)
        Me.dtpContractEnd.TabIndex = 6
        '
        'dtpContractStart
        '
        Me.dtpContractStart.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpContractStart.CustomFormat = "MMMM dd, yyyy"
        Me.dtpContractStart.Enabled = False
        Me.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpContractStart.Location = New System.Drawing.Point(147, 75)
        Me.dtpContractStart.Name = "dtpContractStart"
        Me.dtpContractStart.Size = New System.Drawing.Size(175, 21)
        Me.dtpContractStart.TabIndex = 5
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.gboxSelectUnitOwner)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(689, 157)
        Me.TopPanel.TabIndex = 0
        '
        'gboxSelectUnitOwner
        '
        Me.gboxSelectUnitOwner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxSelectUnitOwner.Location = New System.Drawing.Point(0, 0)
        Me.gboxSelectUnitOwner.Name = "gboxSelectUnitOwner"
        '
        'gboxSelectUnitOwner.Panel
        '
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.txtunitType)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.txtunitOwner)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.KryptonLabel3)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.KryptonLabel2)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.btnSearch)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.txtUnitNumber)
        Me.gboxSelectUnitOwner.Panel.Controls.Add(Me.KryptonLabel1)
        Me.gboxSelectUnitOwner.Size = New System.Drawing.Size(689, 157)
        Me.gboxSelectUnitOwner.TabIndex = 2
        Me.gboxSelectUnitOwner.Text = "SELECT UNIT / PARKING SLOT TO MANAGE"
        Me.gboxSelectUnitOwner.Values.Heading = "SELECT UNIT / PARKING SLOT TO MANAGE"
        '
        'txtunitType
        '
        Me.txtunitType.Enabled = False
        Me.txtunitType.Location = New System.Drawing.Point(115, 76)
        Me.txtunitType.Name = "txtunitType"
        Me.txtunitType.Size = New System.Drawing.Size(487, 20)
        Me.txtunitType.TabIndex = 6
        '
        'txtunitOwner
        '
        Me.txtunitOwner.Enabled = False
        Me.txtunitOwner.Location = New System.Drawing.Point(115, 48)
        Me.txtunitOwner.Name = "txtunitOwner"
        Me.txtunitOwner.Size = New System.Drawing.Size(487, 20)
        Me.txtunitOwner.TabIndex = 5
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(41, 79)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(74, 20)
        Me.KryptonLabel3.TabIndex = 4
        Me.KryptonLabel3.Values.Text = "UNIT TYPE :"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(25, 51)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel2.TabIndex = 3
        Me.KryptonLabel2.Values.Text = "UNIT OWNER :"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(608, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(50, 38)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Values.Text = "V"
        '
        'txtUnitNumber
        '
        Me.txtUnitNumber.Enabled = False
        Me.txtUnitNumber.Location = New System.Drawing.Point(115, 20)
        Me.txtUnitNumber.Name = "txtUnitNumber"
        Me.txtUnitNumber.Size = New System.Drawing.Size(487, 20)
        Me.txtUnitNumber.TabIndex = 1
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(20, 20)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(97, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "UNIT NUMBER :"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewRentalManagementAgrreementFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 514)
        Me.Controls.Add(Me.NewRentalManagementAgreementPanel)
        Me.Name = "NewRentalManagementAgrreementFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW RENTAL MANAGEMENT AGREEMENT"
        CType(Me.NewRentalManagementAgreementPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NewRentalManagementAgreementPanel.ResumeLayout(False)
        CType(Me.CenterPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CenterPanel.ResumeLayout(False)
        Me.CenterPanel.PerformLayout()
        CType(Me.cboCondoDuesPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRemittanceRelease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnitClassification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopPanel.ResumeLayout(False)
        CType(Me.gboxSelectUnitOwner.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSelectUnitOwner.Panel.ResumeLayout(False)
        Me.gboxSelectUnitOwner.Panel.PerformLayout()
        CType(Me.gboxSelectUnitOwner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSelectUnitOwner.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewRentalManagementAgreementPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents CenterPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TopPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents gboxSelectUnitOwner As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtunitType As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtunitOwner As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtUnitNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpAgreementDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents txtMgmtRate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtRentUp As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCashBond As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtSecurityDeposit As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPrepaidRent As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtRentAmount As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboRemittanceRelease As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboUnitClassification As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMaxOccupant As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dtpContractEnd As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpContractStart As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCondoDuesPayment As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents nudNoOfMonths As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
