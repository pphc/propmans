<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OneTimeBillGenerationForm
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
        Me.InvoiceDetailsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblDefaultAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtBillingNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtAmountDue = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnGenerateBill = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dtpStatementDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.SelectCustomerGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblCustomerType = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblCustomerName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblUnitNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearchCustomer = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.InvoiceDetailsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceDetailsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InvoiceDetailsGroupBox.Panel.SuspendLayout()
        Me.InvoiceDetailsGroupBox.SuspendLayout()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectCustomerGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SelectCustomerGroupBox.Panel.SuspendLayout()
        Me.SelectCustomerGroupBox.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.InvoiceDetailsGroupBox)
        Me.KryptonPanel.Controls.Add(Me.SelectCustomerGroupBox)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(15)
        Me.KryptonPanel.Size = New System.Drawing.Size(855, 746)
        Me.KryptonPanel.TabIndex = 1
        '
        'InvoiceDetailsGroupBox
        '
        Me.InvoiceDetailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceDetailsGroupBox.Location = New System.Drawing.Point(15, 202)
        Me.InvoiceDetailsGroupBox.Name = "InvoiceDetailsGroupBox"
        '
        'InvoiceDetailsGroupBox.Panel
        '
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.lblDefaultAmount)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.txtBillingNotes)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel4)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.txtAmountDue)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel2)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.btnGenerateBill)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.dtpStatementDate)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel3)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel1)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.KryptonLabel12)
        Me.InvoiceDetailsGroupBox.Panel.Controls.Add(Me.cboFeeType)
        Me.InvoiceDetailsGroupBox.Size = New System.Drawing.Size(825, 529)
        Me.InvoiceDetailsGroupBox.TabIndex = 30
        Me.InvoiceDetailsGroupBox.Text = "INVOICE DETAILS"
        Me.InvoiceDetailsGroupBox.Values.Heading = "INVOICE DETAILS"
        '
        'lblDefaultAmount
        '
        Me.lblDefaultAmount.Location = New System.Drawing.Point(133, 83)
        Me.lblDefaultAmount.Name = "lblDefaultAmount"
        Me.lblDefaultAmount.Size = New System.Drawing.Size(137, 19)
        Me.lblDefaultAmount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultAmount.TabIndex = 34
        Me.lblDefaultAmount.Values.Text = "DEFAULT AMOUNT:"
        '
        'txtBillingNotes
        '
        Me.txtBillingNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillingNotes.Location = New System.Drawing.Point(510, 142)
        Me.txtBillingNotes.MaxLength = 100
        Me.txtBillingNotes.Multiline = True
        Me.txtBillingNotes.Name = "txtBillingNotes"
        Me.txtBillingNotes.Size = New System.Drawing.Size(187, 88)
        Me.txtBillingNotes.TabIndex = 3
        Me.txtBillingNotes.Visible = False
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(510, 117)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(51, 20)
        Me.KryptonLabel4.TabIndex = 32
        Me.KryptonLabel4.Values.Text = "NOTES:"
        Me.KryptonLabel4.Visible = False
        '
        'txtAmountDue
        '
        Me.txtAmountDue.Location = New System.Drawing.Point(133, 168)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.Size = New System.Drawing.Size(360, 20)
        Me.txtAmountDue.TabIndex = 2
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(42, 171)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel2.TabIndex = 29
        Me.KryptonLabel2.Values.Text = "AMOUNT DUE:"
        '
        'btnGenerateBill
        '
        Me.btnGenerateBill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateBill.Location = New System.Drawing.Point(703, 180)
        Me.btnGenerateBill.Name = "btnGenerateBill"
        Me.btnGenerateBill.Size = New System.Drawing.Size(103, 50)
        Me.btnGenerateBill.TabIndex = 4
        Me.btnGenerateBill.Values.Text = "GENERATE BILL"
        '
        'dtpStatementDate
        '
        Me.dtpStatementDate.AlwaysActive = False
        Me.dtpStatementDate.Location = New System.Drawing.Point(133, 142)
        Me.dtpStatementDate.Name = "dtpStatementDate"
        Me.dtpStatementDate.Size = New System.Drawing.Size(360, 21)
        Me.dtpStatementDate.TabIndex = 1
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(23, 142)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(113, 20)
        Me.KryptonLabel3.TabIndex = 25
        Me.KryptonLabel3.Values.Text = "STATEMENT DATE:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(70, 55)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "FEE TYPE:"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(17, 83)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel12.TabIndex = 27
        Me.KryptonLabel12.Values.Text = "DEFAULT AMOUNT:"
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 195
        Me.cboFeeType.Location = New System.Drawing.Point(133, 52)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(360, 21)
        Me.cboFeeType.TabIndex = 0
        '
        'SelectCustomerGroupBox
        '
        Me.SelectCustomerGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.SelectCustomerGroupBox.Location = New System.Drawing.Point(15, 77)
        Me.SelectCustomerGroupBox.Name = "SelectCustomerGroupBox"
        '
        'SelectCustomerGroupBox.Panel
        '
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.lblCustomerType)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.KryptonLabel6)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.lblCustomerName)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.KryptonLabel19)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.KryptonLabel13)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.lblUnitNumber)
        Me.SelectCustomerGroupBox.Panel.Controls.Add(Me.btnSearchCustomer)
        Me.SelectCustomerGroupBox.Size = New System.Drawing.Size(825, 125)
        Me.SelectCustomerGroupBox.TabIndex = 29
        Me.SelectCustomerGroupBox.Text = "SELECT UNIT OWNER"
        Me.SelectCustomerGroupBox.Values.Heading = "SELECT UNIT OWNER"
        '
        'lblCustomerType
        '
        Me.lblCustomerType.AutoSize = False
        Me.lblCustomerType.Location = New System.Drawing.Point(134, 67)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(518, 19)
        Me.lblCustomerType.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerType.TabIndex = 75
        Me.lblCustomerType.Values.Text = "CUSTOMER TYPE"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(29, 68)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel6.TabIndex = 74
        Me.KryptonLabel6.Values.Text = "CUSTOMER TYPE:"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = False
        Me.lblCustomerName.Location = New System.Drawing.Point(134, 42)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(518, 19)
        Me.lblCustomerName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerName.TabIndex = 73
        Me.lblCustomerName.Values.Text = "CUSTOMER NAME"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Location = New System.Drawing.Point(23, 42)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Size = New System.Drawing.Size(114, 20)
        Me.KryptonLabel19.TabIndex = 72
        Me.KryptonLabel19.Values.Text = "CUSTOMER NAME:"
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(42, 17)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(94, 20)
        Me.KryptonLabel13.TabIndex = 71
        Me.KryptonLabel13.Values.Text = "UNIT NUMBER:"
        '
        'lblUnitNumber
        '
        Me.lblUnitNumber.Location = New System.Drawing.Point(134, 17)
        Me.lblUnitNumber.Name = "lblUnitNumber"
        Me.lblUnitNumber.Size = New System.Drawing.Size(106, 19)
        Me.lblUnitNumber.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitNumber.TabIndex = 70
        Me.lblUnitNumber.Values.Text = "UNIT NUMBER"
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchCustomer.Location = New System.Drawing.Point(703, 27)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(103, 45)
        Me.btnSearchCustomer.TabIndex = 4
        Me.btnSearchCustomer.Values.Text = "SEARCH"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(15, 54)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(825, 23)
        Me.KryptonPanel1.TabIndex = 28
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(15, 15)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(825, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 23
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "ONE TIME FEES BILLING GENERATION"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'OneTimeBillGenerationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 746)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "OneTimeBillGenerationForm"
        Me.Text = "One Time Fees Generation"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.InvoiceDetailsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoiceDetailsGroupBox.Panel.ResumeLayout(False)
        Me.InvoiceDetailsGroupBox.Panel.PerformLayout()
        CType(Me.InvoiceDetailsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoiceDetailsGroupBox.ResumeLayout(False)
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectCustomerGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectCustomerGroupBox.Panel.ResumeLayout(False)
        Me.SelectCustomerGroupBox.Panel.PerformLayout()
        CType(Me.SelectCustomerGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectCustomerGroupBox.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents InvoiceDetailsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblDefaultAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtBillingNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAmountDue As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnGenerateBill As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpStatementDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents SelectCustomerGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblCustomerName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblUnitNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearchCustomer As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblCustomerType As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
