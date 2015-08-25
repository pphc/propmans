<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewLeaseContractForm
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
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.nudNoOfMonths = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.dtpApplicationDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpContractEnd = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.dtpContractStart = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.gboxLesseeInformation = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.rdbNewLessse = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdbExistingLessee = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.txtMiddleName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtFirstName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtLastName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.gboxSelectUnitUnderRMS = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtCashBond = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtSecurityDeposit = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtPrepaidRent = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtRentAmount = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboUnitInfo = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboUnitClass = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.NewRentalManagementAgreementPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NewRentalManagementAgreementPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.gboxLesseeInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gboxLesseeInformation.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxLesseeInformation.Panel.SuspendLayout()
        Me.gboxLesseeInformation.SuspendLayout()
        CType(Me.gboxSelectUnitUnderRMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gboxSelectUnitUnderRMS.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSelectUnitUnderRMS.Panel.SuspendLayout()
        Me.gboxSelectUnitUnderRMS.SuspendLayout()
        CType(Me.cboUnitInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnitClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NewRentalManagementAgreementPanel
        '
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.btnCancel)
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.btnSave)
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.gboxLesseeInformation)
        Me.NewRentalManagementAgreementPanel.Controls.Add(Me.gboxSelectUnitUnderRMS)
        Me.NewRentalManagementAgreementPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NewRentalManagementAgreementPanel.Location = New System.Drawing.Point(0, 0)
        Me.NewRentalManagementAgreementPanel.Name = "NewRentalManagementAgreementPanel"
        Me.NewRentalManagementAgreementPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.NewRentalManagementAgreementPanel.Size = New System.Drawing.Size(518, 699)
        Me.NewRentalManagementAgreementPanel.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(398, 640)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 41)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(298, 640)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 41)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Values.Text = "SAVE"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(5, 465)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.nudNoOfMonths)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpApplicationDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel7)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpContractEnd)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpContractStart)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(508, 156)
        Me.KryptonGroupBox1.TabIndex = 7
        Me.KryptonGroupBox1.Text = "LEASE CONTRACT INFORMATION"
        Me.KryptonGroupBox1.Values.Heading = "LEASE CONTRACT INFORMATION"
        '
        'nudNoOfMonths
        '
        Me.nudNoOfMonths.Location = New System.Drawing.Point(136, 44)
        Me.nudNoOfMonths.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudNoOfMonths.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNoOfMonths.Name = "nudNoOfMonths"
        Me.nudNoOfMonths.Size = New System.Drawing.Size(344, 22)
        Me.nudNoOfMonths.TabIndex = 81
        Me.nudNoOfMonths.UpDownButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
        Me.nudNoOfMonths.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpApplicationDate
        '
        Me.dtpApplicationDate.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpApplicationDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpApplicationDate.Location = New System.Drawing.Point(136, 18)
        Me.dtpApplicationDate.Name = "dtpApplicationDate"
        Me.dtpApplicationDate.Size = New System.Drawing.Size(344, 21)
        Me.dtpApplicationDate.TabIndex = 80
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(103, 98)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(29, 20)
        Me.KryptonLabel7.TabIndex = 87
        Me.KryptonLabel7.Values.Text = "TO:"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(86, 73)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(47, 20)
        Me.KryptonLabel6.TabIndex = 86
        Me.KryptonLabel6.Values.Text = "FROM:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(30, 48)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(109, 20)
        Me.KryptonLabel4.TabIndex = 85
        Me.KryptonLabel4.Values.Text = "NO OF MONTHS :"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(16, 21)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(124, 20)
        Me.KryptonLabel5.TabIndex = 84
        Me.KryptonLabel5.Values.Text = "APPLICATION DATE :"
        '
        'dtpContractEnd
        '
        Me.dtpContractEnd.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpContractEnd.CustomFormat = "MMMM dd, yyyy"
        Me.dtpContractEnd.Enabled = False
        Me.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpContractEnd.Location = New System.Drawing.Point(136, 97)
        Me.dtpContractEnd.Name = "dtpContractEnd"
        Me.dtpContractEnd.Size = New System.Drawing.Size(344, 21)
        Me.dtpContractEnd.TabIndex = 83
        '
        'dtpContractStart
        '
        Me.dtpContractStart.CalendarTodayDate = New Date(2013, 7, 18, 0, 0, 0, 0)
        Me.dtpContractStart.CustomFormat = "MMMM dd, yyyy"
        Me.dtpContractStart.Enabled = False
        Me.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpContractStart.Location = New System.Drawing.Point(136, 71)
        Me.dtpContractStart.Name = "dtpContractStart"
        Me.dtpContractStart.Size = New System.Drawing.Size(344, 21)
        Me.dtpContractStart.TabIndex = 82
        '
        'gboxLesseeInformation
        '
        Me.gboxLesseeInformation.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxLesseeInformation.Location = New System.Drawing.Point(5, 249)
        Me.gboxLesseeInformation.Name = "gboxLesseeInformation"
        '
        'gboxLesseeInformation.Panel
        '
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.rdbNewLessse)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.rdbExistingLessee)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.txtMiddleName)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.txtFirstName)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.KryptonLabel16)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.KryptonLabel17)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.btnSearch)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.txtLastName)
        Me.gboxLesseeInformation.Panel.Controls.Add(Me.KryptonLabel18)
        Me.gboxLesseeInformation.Size = New System.Drawing.Size(508, 216)
        Me.gboxLesseeInformation.TabIndex = 6
        Me.gboxLesseeInformation.Text = "LESSEE INFORMATION"
        Me.gboxLesseeInformation.Values.Heading = "LESSEE INFORMATION"
        '
        'rdbNewLessse
        '
        Me.rdbNewLessse.Location = New System.Drawing.Point(401, 105)
        Me.rdbNewLessse.Name = "rdbNewLessse"
        Me.rdbNewLessse.Size = New System.Drawing.Size(84, 20)
        Me.rdbNewLessse.TabIndex = 8
        Me.rdbNewLessse.Values.Text = "NEW LESEE"
        '
        'rdbExistingLessee
        '
        Me.rdbExistingLessee.Checked = True
        Me.rdbExistingLessee.Location = New System.Drawing.Point(295, 105)
        Me.rdbExistingLessee.Name = "rdbExistingLessee"
        Me.rdbExistingLessee.Size = New System.Drawing.Size(108, 20)
        Me.rdbExistingLessee.TabIndex = 7
        Me.rdbExistingLessee.Values.Text = "EXISTING LESEE"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMiddleName.Location = New System.Drawing.Point(136, 67)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(344, 20)
        Me.txtMiddleName.TabIndex = 6
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(136, 39)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(344, 20)
        Me.txtFirstName.TabIndex = 5
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Location = New System.Drawing.Point(39, 70)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(98, 20)
        Me.KryptonLabel16.TabIndex = 4
        Me.KryptonLabel16.Values.Text = "MIDDLE NAME :"
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.Location = New System.Drawing.Point(52, 42)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(84, 20)
        Me.KryptonLabel17.TabIndex = 3
        Me.KryptonLabel17.Values.Text = "FIRST NAME :"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(391, 139)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(89, 38)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Values.Text = "SELECT"
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(136, 11)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(344, 20)
        Me.txtLastName.TabIndex = 1
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Location = New System.Drawing.Point(55, 14)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(81, 20)
        Me.KryptonLabel18.TabIndex = 0
        Me.KryptonLabel18.Values.Text = "LAST NAME :"
        '
        'gboxSelectUnitUnderRMS
        '
        Me.gboxSelectUnitUnderRMS.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxSelectUnitUnderRMS.Location = New System.Drawing.Point(5, 5)
        Me.gboxSelectUnitUnderRMS.Name = "gboxSelectUnitUnderRMS"
        '
        'gboxSelectUnitUnderRMS.Panel
        '
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.txtCashBond)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.txtSecurityDeposit)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.txtPrepaidRent)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.txtRentAmount)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel13)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel12)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel11)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel10)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.cboUnitInfo)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel3)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.cboUnitClass)
        Me.gboxSelectUnitUnderRMS.Panel.Controls.Add(Me.KryptonLabel1)
        Me.gboxSelectUnitUnderRMS.Size = New System.Drawing.Size(508, 244)
        Me.gboxSelectUnitUnderRMS.TabIndex = 5
        Me.gboxSelectUnitUnderRMS.Text = "SELECT UNIT UNDER RMS"
        Me.gboxSelectUnitUnderRMS.Values.Heading = "SELECT UNIT UNDER RMS"
        '
        'txtCashBond
        '
        Me.txtCashBond.Enabled = False
        Me.txtCashBond.Location = New System.Drawing.Point(136, 181)
        Me.txtCashBond.Name = "txtCashBond"
        Me.txtCashBond.Size = New System.Drawing.Size(344, 20)
        Me.txtCashBond.TabIndex = 89
        Me.txtCashBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSecurityDeposit
        '
        Me.txtSecurityDeposit.Enabled = False
        Me.txtSecurityDeposit.Location = New System.Drawing.Point(136, 152)
        Me.txtSecurityDeposit.Name = "txtSecurityDeposit"
        Me.txtSecurityDeposit.Size = New System.Drawing.Size(344, 20)
        Me.txtSecurityDeposit.TabIndex = 88
        Me.txtSecurityDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrepaidRent
        '
        Me.txtPrepaidRent.Enabled = False
        Me.txtPrepaidRent.Location = New System.Drawing.Point(136, 124)
        Me.txtPrepaidRent.Name = "txtPrepaidRent"
        Me.txtPrepaidRent.Size = New System.Drawing.Size(344, 20)
        Me.txtPrepaidRent.TabIndex = 87
        Me.txtPrepaidRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRentAmount
        '
        Me.txtRentAmount.Enabled = False
        Me.txtRentAmount.Location = New System.Drawing.Point(136, 96)
        Me.txtRentAmount.Name = "txtRentAmount"
        Me.txtRentAmount.Size = New System.Drawing.Size(344, 20)
        Me.txtRentAmount.TabIndex = 86
        Me.txtRentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(51, 184)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(85, 20)
        Me.KryptonLabel13.TabIndex = 93
        Me.KryptonLabel13.Values.Text = "CASH BOND :"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(19, 155)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(120, 20)
        Me.KryptonLabel12.TabIndex = 92
        Me.KryptonLabel12.Values.Text = "SECURITY DEPOSIT :"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(41, 127)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(97, 20)
        Me.KryptonLabel11.TabIndex = 91
        Me.KryptonLabel11.Values.Text = "PREPAID RENT :"
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(36, 99)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel10.TabIndex = 90
        Me.KryptonLabel10.Values.Text = "RENT AMOUNT :"
        '
        'cboUnitInfo
        '
        Me.cboUnitInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitInfo.DropDownWidth = 121
        Me.cboUnitInfo.Location = New System.Drawing.Point(136, 58)
        Me.cboUnitInfo.Name = "cboUnitInfo"
        Me.cboUnitInfo.Size = New System.Drawing.Size(344, 21)
        Me.cboUnitInfo.TabIndex = 10
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(23, 59)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(110, 20)
        Me.KryptonLabel3.TabIndex = 9
        Me.KryptonLabel3.Values.Text = "AVAILABLE UNITS:"
        '
        'cboUnitClass
        '
        Me.cboUnitClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitClass.DropDownWidth = 121
        Me.cboUnitClass.Location = New System.Drawing.Point(136, 30)
        Me.cboUnitClass.Name = "cboUnitClass"
        Me.cboUnitClass.Size = New System.Drawing.Size(344, 21)
        Me.cboUnitClass.TabIndex = 8
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(62, 33)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(74, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "UNIT TYPE :"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewLeaseContractForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 699)
        Me.Controls.Add(Me.NewRentalManagementAgreementPanel)
        Me.Name = "NewLeaseContractForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW CONTRACT OF LEASE"
        CType(Me.NewRentalManagementAgreementPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NewRentalManagementAgreementPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.gboxLesseeInformation.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxLesseeInformation.Panel.ResumeLayout(False)
        Me.gboxLesseeInformation.Panel.PerformLayout()
        CType(Me.gboxLesseeInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxLesseeInformation.ResumeLayout(False)
        CType(Me.gboxSelectUnitUnderRMS.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSelectUnitUnderRMS.Panel.ResumeLayout(False)
        Me.gboxSelectUnitUnderRMS.Panel.PerformLayout()
        CType(Me.gboxSelectUnitUnderRMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSelectUnitUnderRMS.ResumeLayout(False)
        CType(Me.cboUnitInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnitClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents NewRentalManagementAgreementPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gboxSelectUnitUnderRMS As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents cboUnitInfo As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboUnitClass As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents gboxLesseeInformation As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtMiddleName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtFirstName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtLastName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCashBond As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtSecurityDeposit As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPrepaidRent As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtRentAmount As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents nudNoOfMonths As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents dtpApplicationDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpContractEnd As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpContractStart As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents rdbNewLessse As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdbExistingLessee As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
End Class
