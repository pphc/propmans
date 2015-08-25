<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingStatementsForm
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
        Me.pnlPrintCommand = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtBillingNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.chkPrintNotes = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.btnPrintPreview = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.StatementsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblRecordCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.BillingGridPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgBillingStatements = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.FeeTypeSelectionGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.btnViewStatementsAllAccounts = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.nudBillingYear = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtAccountName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnSelectAccount = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnViewStatementsByAccount = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeTypeIndividual = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrintCommand.SuspendLayout()
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatementsGroupBox.Panel.SuspendLayout()
        Me.StatementsGroupBox.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BillingGridPanel.SuspendLayout()
        CType(Me.dgBillingStatements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FeeTypeSelectionGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FeeTypeSelectionGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FeeTypeSelectionGroupBox.Panel.SuspendLayout()
        Me.FeeTypeSelectionGroupBox.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboFeeTypeIndividual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlPrintCommand)
        Me.KryptonPanel.Controls.Add(Me.StatementsGroupBox)
        Me.KryptonPanel.Controls.Add(Me.FeeTypeSelectionGroupBox)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(781, 535)
        Me.KryptonPanel.TabIndex = 0
        Me.KryptonPanel.Tag = "billprint"
        '
        'pnlPrintCommand
        '
        Me.pnlPrintCommand.Controls.Add(Me.txtBillingNotes)
        Me.pnlPrintCommand.Controls.Add(Me.chkPrintNotes)
        Me.pnlPrintCommand.Controls.Add(Me.btnPrintPreview)
        Me.pnlPrintCommand.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPrintCommand.Location = New System.Drawing.Point(10, 451)
        Me.pnlPrintCommand.Name = "pnlPrintCommand"
        Me.pnlPrintCommand.Size = New System.Drawing.Size(761, 74)
        Me.pnlPrintCommand.TabIndex = 31
        '
        'txtBillingNotes
        '
        Me.txtBillingNotes.Location = New System.Drawing.Point(16, 26)
        Me.txtBillingNotes.Multiline = True
        Me.txtBillingNotes.Name = "txtBillingNotes"
        Me.txtBillingNotes.Size = New System.Drawing.Size(532, 41)
        Me.txtBillingNotes.TabIndex = 33
        Me.txtBillingNotes.Visible = False
        '
        'chkPrintNotes
        '
        Me.chkPrintNotes.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkPrintNotes.Location = New System.Drawing.Point(15, 4)
        Me.chkPrintNotes.Name = "chkPrintNotes"
        Me.chkPrintNotes.Size = New System.Drawing.Size(144, 20)
        Me.chkPrintNotes.TabIndex = 32
        Me.chkPrintNotes.Text = "Print Additional Notes"
        Me.chkPrintNotes.Values.Text = "Print Additional Notes"
        Me.chkPrintNotes.Visible = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Location = New System.Drawing.Point(633, 4)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(119, 44)
        Me.btnPrintPreview.TabIndex = 29
        Me.btnPrintPreview.Values.Text = "PRINT PREVIEW"
        '
        'StatementsGroupBox
        '
        Me.StatementsGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatementsGroupBox.Location = New System.Drawing.Point(10, 196)
        Me.StatementsGroupBox.Name = "StatementsGroupBox"
        '
        'StatementsGroupBox.Panel
        '
        Me.StatementsGroupBox.Panel.Controls.Add(Me.KryptonPanel4)
        Me.StatementsGroupBox.Panel.Controls.Add(Me.BillingGridPanel)
        Me.StatementsGroupBox.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.StatementsGroupBox.Size = New System.Drawing.Size(761, 249)
        Me.StatementsGroupBox.TabIndex = 26
        Me.StatementsGroupBox.Text = "BILLING STATEMENTS"
        Me.StatementsGroupBox.Values.Heading = "BILLING STATEMENTS"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.chkSelectAll)
        Me.KryptonPanel4.Controls.Add(Me.lblRecordCount)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel4.Location = New System.Drawing.Point(10, 186)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(737, 29)
        Me.KryptonPanel4.TabIndex = 35
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(3, 5)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 3
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.Location = New System.Drawing.Point(645, 2)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(89, 20)
        Me.lblRecordCount.TabIndex = 4
        Me.lblRecordCount.Values.Text = "KryptonLabel1"
        '
        'BillingGridPanel
        '
        Me.BillingGridPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillingGridPanel.Controls.Add(Me.dgBillingStatements)
        Me.BillingGridPanel.Location = New System.Drawing.Point(10, 10)
        Me.BillingGridPanel.Name = "BillingGridPanel"
        Me.BillingGridPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.BillingGridPanel.Size = New System.Drawing.Size(737, 173)
        Me.BillingGridPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BillingGridPanel.TabIndex = 6
        '
        'dgBillingStatements
        '
        Me.dgBillingStatements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBillingStatements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgBillingStatements.Location = New System.Drawing.Point(1, 1)
        Me.dgBillingStatements.Name = "dgBillingStatements"
        Me.dgBillingStatements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBillingStatements.Size = New System.Drawing.Size(735, 171)
        Me.dgBillingStatements.TabIndex = 0
        '
        'FeeTypeSelectionGroupBox
        '
        Me.FeeTypeSelectionGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.FeeTypeSelectionGroupBox.Location = New System.Drawing.Point(10, 49)
        Me.FeeTypeSelectionGroupBox.Name = "FeeTypeSelectionGroupBox"
        '
        'FeeTypeSelectionGroupBox.Panel
        '
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.TabControl1)
        Me.FeeTypeSelectionGroupBox.Panel.Padding = New System.Windows.Forms.Padding(3)
        Me.FeeTypeSelectionGroupBox.Size = New System.Drawing.Size(761, 140)
        Me.FeeTypeSelectionGroupBox.TabIndex = 25
        Me.FeeTypeSelectionGroupBox.Text = "VIEWING OPTIONS"
        Me.FeeTypeSelectionGroupBox.Values.Heading = "VIEWING OPTIONS"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(751, 110)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.KryptonPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(694, 84)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ALL ACCOUNTS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.cboBillingMonth)
        Me.KryptonPanel2.Controls.Add(Me.btnViewStatementsAllAccounts)
        Me.KryptonPanel2.Controls.Add(Me.nudBillingYear)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.cboFeeType)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(688, 78)
        Me.KryptonPanel2.TabIndex = 7
        '
        'cboBillingMonth
        '
        Me.cboBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingMonth.DropDownWidth = 195
        Me.cboBillingMonth.Items.AddRange(New Object() {"-SELECT MONTH-", "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.cboBillingMonth.Location = New System.Drawing.Point(138, 39)
        Me.cboBillingMonth.Name = "cboBillingMonth"
        Me.cboBillingMonth.Size = New System.Drawing.Size(146, 21)
        Me.cboBillingMonth.TabIndex = 10
        '
        'btnViewStatementsAllAccounts
        '
        Me.btnViewStatementsAllAccounts.Location = New System.Drawing.Point(353, 19)
        Me.btnViewStatementsAllAccounts.Name = "btnViewStatementsAllAccounts"
        Me.btnViewStatementsAllAccounts.Size = New System.Drawing.Size(121, 32)
        Me.btnViewStatementsAllAccounts.TabIndex = 9
        Me.btnViewStatementsAllAccounts.Values.Text = "VIEW STATEMENTS"
        '
        'nudBillingYear
        '
        Me.nudBillingYear.Location = New System.Drawing.Point(290, 38)
        Me.nudBillingYear.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.nudBillingYear.Name = "nudBillingYear"
        Me.nudBillingYear.Size = New System.Drawing.Size(57, 22)
        Me.nudBillingYear.TabIndex = 6
        Me.nudBillingYear.UpDownButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
        Me.nudBillingYear.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(28, 40)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(104, 20)
        Me.KryptonLabel2.TabIndex = 4
        Me.KryptonLabel2.Values.Text = "BILLING MONTH:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(71, 13)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel1.TabIndex = 3
        Me.KryptonLabel1.Values.Text = "FEE TYPE:"
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 195
        Me.cboFeeType.Location = New System.Drawing.Point(139, 12)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(208, 21)
        Me.cboFeeType.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.KryptonPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(743, 84)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "INDIVIDUAL ACCOUNT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.txtAccountName)
        Me.KryptonPanel3.Controls.Add(Me.btnViewStatementsByAccount)
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel3.Controls.Add(Me.cboFeeTypeIndividual)
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel3.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(737, 78)
        Me.KryptonPanel3.TabIndex = 8
        '
        'txtAccountName
        '
        Me.txtAccountName.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnSelectAccount})
        Me.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountName.Location = New System.Drawing.Point(135, 10)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(401, 21)
        Me.txtAccountName.TabIndex = 9
        '
        'btnSelectAccount
        '
        Me.btnSelectAccount.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnSelectAccount.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip
        Me.btnSelectAccount.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Context
        Me.btnSelectAccount.UniqueName = "98EFC43EAFBD4ADEEB92E71BE322ED2C"
        '
        'btnViewStatementsByAccount
        '
        Me.btnViewStatementsByAccount.Location = New System.Drawing.Point(410, 34)
        Me.btnViewStatementsByAccount.Name = "btnViewStatementsByAccount"
        Me.btnViewStatementsByAccount.Size = New System.Drawing.Size(126, 32)
        Me.btnViewStatementsByAccount.TabIndex = 8
        Me.btnViewStatementsByAccount.Values.Text = "VIEW STATEMENTS"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(67, 36)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel4.TabIndex = 6
        Me.KryptonLabel4.Values.Text = "FEE TYPE:"
        '
        'cboFeeTypeIndividual
        '
        Me.cboFeeTypeIndividual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeTypeIndividual.DropDownWidth = 195
        Me.cboFeeTypeIndividual.Location = New System.Drawing.Point(135, 36)
        Me.cboFeeTypeIndividual.Name = "cboFeeTypeIndividual"
        Me.cboFeeTypeIndividual.Size = New System.Drawing.Size(269, 21)
        Me.cboFeeTypeIndividual.TabIndex = 5
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(21, 10)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(108, 20)
        Me.KryptonLabel3.TabIndex = 4
        Me.KryptonLabel3.Values.Text = "ACCOUNT NAME:"
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(10, 10)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(761, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 24
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "Billing Statements"
        '
        'BillingStatementsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 535)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "BillingStatementsForm"
        Me.Text = "Billing Statements"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrintCommand.ResumeLayout(False)
        Me.pnlPrintCommand.PerformLayout()
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.Panel.ResumeLayout(False)
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BillingGridPanel.ResumeLayout(False)
        CType(Me.dgBillingStatements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FeeTypeSelectionGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FeeTypeSelectionGroupBox.Panel.ResumeLayout(False)
        CType(Me.FeeTypeSelectionGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FeeTypeSelectionGroupBox.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboFeeTypeIndividual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    'Public Sub New()

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents FeeTypeSelectionGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents StatementsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents BillingGridPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgBillingStatements As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents selectedYear As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents nudBillingYear As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeTypeIndividual As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnViewStatementsAllAccounts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnViewStatementsByAccount As ComponentFactory.Krypton.Toolkit.KryptonButton

    Friend WithEvents cboBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents pnlPrintCommand As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtBillingNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents chkPrintNotes As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents btnPrintPreview As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents lblRecordCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAccountName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSelectAccount As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
End Class
