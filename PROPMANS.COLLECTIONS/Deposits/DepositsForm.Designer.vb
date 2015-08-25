<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepositsForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtDepositRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblDepositoryBank = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboDepositType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboAccountNumber = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.btnViewReceipts = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pnlBottom = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblReceiptCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblUndepositedAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSaveDeposits = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpDepositDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.searchCustomerGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.pnlDateRange = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dtpEndDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpStartDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboSearchvalue = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblRecordCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pnlgridContainer = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgDeposits = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnViewDetails = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSearchDeposit = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cboSearchType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboDepositType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAccountNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        CType(Me.searchCustomerGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.searchCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.searchCustomerGroupBox.Panel.SuspendLayout()
        Me.searchCustomerGroupBox.SuspendLayout()
        CType(Me.pnlDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDateRange.SuspendLayout()
        CType(Me.cboSearchvalue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.pnlgridContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlgridContainer.SuspendLayout()
        CType(Me.dgDeposits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.cboSearchType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.searchCustomerGroupBox)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(819, 667)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 370)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDepositRemarks)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDepositoryBank)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDepositType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboAccountNumber)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnViewReceipts)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.pnlBottom)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpDepositDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel8)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(722, 289)
        Me.KryptonGroupBox1.TabIndex = 26
        Me.KryptonGroupBox1.Text = "New Deposit"
        Me.KryptonGroupBox1.Values.Heading = "New Deposit"
        '
        'txtDepositRemarks
        '
        Me.txtDepositRemarks.Location = New System.Drawing.Point(120, 122)
        Me.txtDepositRemarks.Multiline = True
        Me.txtDepositRemarks.Name = "txtDepositRemarks"
        Me.txtDepositRemarks.Size = New System.Drawing.Size(286, 70)
        Me.txtDepositRemarks.TabIndex = 48
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(17, 122)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(105, 20)
        Me.KryptonLabel6.TabIndex = 47
        Me.KryptonLabel6.Values.Text = "Deposit Remarks:"
        '
        'lblDepositoryBank
        '
        Me.lblDepositoryBank.Location = New System.Drawing.Point(120, 69)
        Me.lblDepositoryBank.Name = "lblDepositoryBank"
        Me.lblDepositoryBank.Size = New System.Drawing.Size(73, 20)
        Me.lblDepositoryBank.TabIndex = 46
        Me.lblDepositoryBank.Values.Text = "Bank Name"
        '
        'cboDepositType
        '
        Me.cboDepositType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepositType.DropDownWidth = 135
        Me.cboDepositType.Items.AddRange(New Object() {"CASH", "CHECKS"})
        Me.cboDepositType.Location = New System.Drawing.Point(120, 94)
        Me.cboDepositType.Name = "cboDepositType"
        Me.cboDepositType.Size = New System.Drawing.Size(286, 21)
        Me.cboDepositType.TabIndex = 45
        '
        'cboAccountNumber
        '
        Me.cboAccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountNumber.DropDownWidth = 135
        Me.cboAccountNumber.Location = New System.Drawing.Point(120, 38)
        Me.cboAccountNumber.Name = "cboAccountNumber"
        Me.cboAccountNumber.Size = New System.Drawing.Size(286, 21)
        Me.cboAccountNumber.TabIndex = 43
        '
        'btnViewReceipts
        '
        Me.btnViewReceipts.Location = New System.Drawing.Point(429, 12)
        Me.btnViewReceipts.Name = "btnViewReceipts"
        Me.btnViewReceipts.Size = New System.Drawing.Size(271, 31)
        Me.btnViewReceipts.TabIndex = 29
        Me.btnViewReceipts.Values.Text = "UNDEPOSITED RECEIPTS"
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblReceiptCount)
        Me.pnlBottom.Controls.Add(Me.lblUndepositedAmount)
        Me.pnlBottom.Controls.Add(Me.btnSaveDeposits)
        Me.pnlBottom.Controls.Add(Me.KryptonLabel5)
        Me.pnlBottom.Controls.Add(Me.KryptonLabel4)
        Me.pnlBottom.Location = New System.Drawing.Point(429, 60)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(286, 132)
        Me.pnlBottom.TabIndex = 24
        '
        'lblReceiptCount
        '
        Me.lblReceiptCount.Location = New System.Drawing.Point(104, 37)
        Me.lblReceiptCount.Name = "lblReceiptCount"
        Me.lblReceiptCount.Size = New System.Drawing.Size(33, 16)
        Me.lblReceiptCount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptCount.TabIndex = 48
        Me.lblReceiptCount.Values.Text = "0.00"
        '
        'lblUndepositedAmount
        '
        Me.lblUndepositedAmount.AutoSize = False
        Me.lblUndepositedAmount.Location = New System.Drawing.Point(104, 12)
        Me.lblUndepositedAmount.Name = "lblUndepositedAmount"
        Me.lblUndepositedAmount.Size = New System.Drawing.Size(98, 16)
        Me.lblUndepositedAmount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUndepositedAmount.TabIndex = 47
        Me.lblUndepositedAmount.Values.Text = "0.00"
        '
        'btnSaveDeposits
        '
        Me.btnSaveDeposits.Location = New System.Drawing.Point(172, 62)
        Me.btnSaveDeposits.Name = "btnSaveDeposits"
        Me.btnSaveDeposits.Size = New System.Drawing.Size(99, 31)
        Me.btnSaveDeposits.TabIndex = 28
        Me.btnSaveDeposits.Values.Text = "SAVE"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(10, 37)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(95, 20)
        Me.KryptonLabel5.TabIndex = 25
        Me.KryptonLabel5.Values.Text = "Receipts Count:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(3, 9)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(103, 20)
        Me.KryptonLabel4.TabIndex = 24
        Me.KryptonLabel4.Values.Text = "Deposit Amount:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(36, 97)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(85, 20)
        Me.KryptonLabel3.TabIndex = 23
        Me.KryptonLabel3.Values.Text = "Deposit Type:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(44, 69)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel2.TabIndex = 22
        Me.KryptonLabel2.Values.Text = "Bank Name:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(16, 41)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(98, 16)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 21
        Me.KryptonLabel1.Values.Text = "Account Number:"
        '
        'dtpDepositDate
        '
        Me.dtpDepositDate.AlwaysActive = False
        Me.dtpDepositDate.Location = New System.Drawing.Point(120, 12)
        Me.dtpDepositDate.Name = "dtpDepositDate"
        Me.dtpDepositDate.Size = New System.Drawing.Size(286, 21)
        Me.dtpDepositDate.TabIndex = 19
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(36, 13)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(84, 20)
        Me.KryptonLabel8.TabIndex = 20
        Me.KryptonLabel8.Values.Text = "Deposit Date:"
        '
        'searchCustomerGroupBox
        '
        Me.searchCustomerGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchCustomerGroupBox.Location = New System.Drawing.Point(12, 48)
        Me.searchCustomerGroupBox.Name = "searchCustomerGroupBox"
        '
        'searchCustomerGroupBox.Panel
        '
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.pnlDateRange)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.cboSearchvalue)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.KryptonPanel3)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.pnlgridContainer)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.KryptonPanel4)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.btnSearchDeposit)
        Me.searchCustomerGroupBox.Panel.Controls.Add(Me.cboSearchType)
        Me.searchCustomerGroupBox.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.searchCustomerGroupBox.Size = New System.Drawing.Size(795, 316)
        Me.searchCustomerGroupBox.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.searchCustomerGroupBox.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.MidnightBlue
        Me.searchCustomerGroupBox.TabIndex = 25
        Me.searchCustomerGroupBox.Text = "Search Deposits"
        Me.searchCustomerGroupBox.Values.Heading = "Search Deposits"
        '
        'pnlDateRange
        '
        Me.pnlDateRange.Controls.Add(Me.dtpEndDate)
        Me.pnlDateRange.Controls.Add(Me.KryptonLabel9)
        Me.pnlDateRange.Controls.Add(Me.dtpStartDate)
        Me.pnlDateRange.Controls.Add(Me.KryptonLabel7)
        Me.pnlDateRange.Location = New System.Drawing.Point(153, 13)
        Me.pnlDateRange.Name = "pnlDateRange"
        Me.pnlDateRange.Size = New System.Drawing.Size(425, 23)
        Me.pnlDateRange.TabIndex = 11
        '
        'dtpEndDate
        '
        Me.dtpEndDate.AlwaysActive = False
        Me.dtpEndDate.Location = New System.Drawing.Point(230, 2)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(156, 21)
        Me.dtpEndDate.TabIndex = 23
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(199, 2)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(27, 20)
        Me.KryptonLabel9.TabIndex = 22
        Me.KryptonLabel9.Values.Text = "To:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.AlwaysActive = False
        Me.dtpStartDate.Location = New System.Drawing.Point(37, 1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(156, 21)
        Me.dtpStartDate.TabIndex = 20
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(2, 2)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(41, 20)
        Me.KryptonLabel7.TabIndex = 21
        Me.KryptonLabel7.Values.Text = "From:"
        '
        'cboSearchvalue
        '
        Me.cboSearchvalue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchvalue.DropDownWidth = 135
        Me.cboSearchvalue.Location = New System.Drawing.Point(153, 14)
        Me.cboSearchvalue.Name = "cboSearchvalue"
        Me.cboSearchvalue.Size = New System.Drawing.Size(232, 21)
        Me.cboSearchvalue.TabIndex = 46
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.lblRecordCount)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel3.Location = New System.Drawing.Point(10, 212)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(771, 35)
        Me.KryptonPanel3.TabIndex = 10
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.Location = New System.Drawing.Point(670, 9)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(83, 16)
        Me.lblRecordCount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.TabIndex = 3
        Me.lblRecordCount.Values.Text = "KryptonLabel1"
        '
        'pnlgridContainer
        '
        Me.pnlgridContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlgridContainer.Controls.Add(Me.dgDeposits)
        Me.pnlgridContainer.Location = New System.Drawing.Point(10, 45)
        Me.pnlgridContainer.Name = "pnlgridContainer"
        Me.pnlgridContainer.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlgridContainer.Size = New System.Drawing.Size(771, 178)
        Me.pnlgridContainer.TabIndex = 9
        '
        'dgDeposits
        '
        Me.dgDeposits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDeposits.Location = New System.Drawing.Point(1, 1)
        Me.dgDeposits.Name = "dgDeposits"
        Me.dgDeposits.Size = New System.Drawing.Size(769, 176)
        Me.dgDeposits.TabIndex = 0
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.btnViewDetails)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel4.Location = New System.Drawing.Point(10, 247)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(771, 35)
        Me.KryptonPanel4.TabIndex = 8
        '
        'btnViewDetails
        '
        Me.btnViewDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDetails.Location = New System.Drawing.Point(639, 1)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(129, 31)
        Me.btnViewDetails.TabIndex = 30
        Me.btnViewDetails.Values.Text = "View Deposit Details"
        '
        'btnSearchDeposit
        '
        Me.btnSearchDeposit.Location = New System.Drawing.Point(584, 13)
        Me.btnSearchDeposit.Name = "btnSearchDeposit"
        Me.btnSearchDeposit.Size = New System.Drawing.Size(70, 25)
        Me.btnSearchDeposit.TabIndex = 1
        Me.btnSearchDeposit.Values.Text = "Search"
        '
        'cboSearchType
        '
        Me.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchType.DropDownWidth = 135
        Me.cboSearchType.Items.AddRange(New Object() {"Deposit Date", "Deposit Type", "Account Number"})
        Me.cboSearchType.Location = New System.Drawing.Point(12, 14)
        Me.cboSearchType.Name = "cboSearchType"
        Me.cboSearchType.Size = New System.Drawing.Size(135, 21)
        Me.cboSearchType.TabIndex = 0
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(5, 5)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(809, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 24
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "Deposits"
        '
        'DepositsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 667)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "DepositsForm"
        Me.Tag = "deposits"
        Me.Text = "Payments Deposits"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboDepositType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAccountNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        CType(Me.searchCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.searchCustomerGroupBox.Panel.ResumeLayout(False)
        CType(Me.searchCustomerGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.searchCustomerGroupBox.ResumeLayout(False)
        CType(Me.pnlDateRange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDateRange.ResumeLayout(False)
        Me.pnlDateRange.PerformLayout()
        CType(Me.cboSearchvalue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.pnlgridContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlgridContainer.ResumeLayout(False)
        CType(Me.dgDeposits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.cboSearchType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents searchCustomerGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSearchDeposit As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboSearchType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents pnlBottom As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpDepositDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnViewReceipts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSaveDeposits As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboAccountNumber As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboDepositType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblRecordCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlgridContainer As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnViewDetails As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblDepositoryBank As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblReceiptCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblUndepositedAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dgDeposits As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents pnlDateRange As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpStartDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpEndDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents cboSearchvalue As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtDepositRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
