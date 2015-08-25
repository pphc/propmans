<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingPrintingForm
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
        Me.BillingGridPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgBillingStatements = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblRecordCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.FeeTypeSelectionGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnViewBilling = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cboBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrintCommand.SuspendLayout()
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatementsGroupBox.Panel.SuspendLayout()
        Me.StatementsGroupBox.SuspendLayout()
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BillingGridPanel.SuspendLayout()
        CType(Me.dgBillingStatements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.FeeTypeSelectionGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FeeTypeSelectionGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FeeTypeSelectionGroupBox.Panel.SuspendLayout()
        Me.FeeTypeSelectionGroupBox.SuspendLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(732, 658)
        Me.KryptonPanel.TabIndex = 0
        Me.KryptonPanel.Tag = "billprint"
        '
        'pnlPrintCommand
        '
        Me.pnlPrintCommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintCommand.Controls.Add(Me.txtBillingNotes)
        Me.pnlPrintCommand.Controls.Add(Me.chkPrintNotes)
        Me.pnlPrintCommand.Controls.Add(Me.btnPrintPreview)
        Me.pnlPrintCommand.Location = New System.Drawing.Point(19, 528)
        Me.pnlPrintCommand.Name = "pnlPrintCommand"
        Me.pnlPrintCommand.Size = New System.Drawing.Size(698, 87)
        Me.pnlPrintCommand.TabIndex = 30
        '
        'txtBillingNotes
        '
        Me.txtBillingNotes.Location = New System.Drawing.Point(14, 29)
        Me.txtBillingNotes.Multiline = True
        Me.txtBillingNotes.Name = "txtBillingNotes"
        Me.txtBillingNotes.Size = New System.Drawing.Size(451, 44)
        Me.txtBillingNotes.TabIndex = 33
        '
        'chkPrintNotes
        '
        Me.chkPrintNotes.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkPrintNotes.Location = New System.Drawing.Point(14, 3)
        Me.chkPrintNotes.Name = "chkPrintNotes"
        Me.chkPrintNotes.Size = New System.Drawing.Size(144, 20)
        Me.chkPrintNotes.TabIndex = 32
        Me.chkPrintNotes.Text = "Print Additional Notes"
        Me.chkPrintNotes.Values.Text = "Print Additional Notes"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Location = New System.Drawing.Point(557, 13)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(129, 44)
        Me.btnPrintPreview.TabIndex = 29
        Me.btnPrintPreview.Values.Text = "PRINT PREVIEW"
        '
        'StatementsGroupBox
        '
        Me.StatementsGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatementsGroupBox.Location = New System.Drawing.Point(19, 179)
        Me.StatementsGroupBox.Name = "StatementsGroupBox"
        '
        'StatementsGroupBox.Panel
        '
        Me.StatementsGroupBox.Panel.Controls.Add(Me.BillingGridPanel)
        Me.StatementsGroupBox.Panel.Controls.Add(Me.KryptonPanel1)
        Me.StatementsGroupBox.Panel.Controls.Add(Me.lblRecordCount)
        Me.StatementsGroupBox.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.StatementsGroupBox.Size = New System.Drawing.Size(698, 343)
        Me.StatementsGroupBox.TabIndex = 26
        Me.StatementsGroupBox.Text = "BILLING STATEMENTS"
        Me.StatementsGroupBox.Values.Heading = "BILLING STATEMENTS"
        '
        'BillingGridPanel
        '
        Me.BillingGridPanel.Controls.Add(Me.dgBillingStatements)
        Me.BillingGridPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.BillingGridPanel.Location = New System.Drawing.Point(10, 29)
        Me.BillingGridPanel.Name = "BillingGridPanel"
        Me.BillingGridPanel.Size = New System.Drawing.Size(674, 245)
        Me.BillingGridPanel.TabIndex = 6
        '
        'dgBillingStatements
        '
        Me.dgBillingStatements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBillingStatements.Location = New System.Drawing.Point(0, 0)
        Me.dgBillingStatements.Name = "dgBillingStatements"
        Me.dgBillingStatements.Size = New System.Drawing.Size(674, 245)
        Me.dgBillingStatements.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.chkSelectAll)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 10)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(674, 19)
        Me.KryptonPanel1.TabIndex = 5
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(5, 0)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 3
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(3, 280)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(89, 20)
        Me.lblRecordCount.TabIndex = 4
        Me.lblRecordCount.Values.Text = "KryptonLabel1"
        '
        'FeeTypeSelectionGroupBox
        '
        Me.FeeTypeSelectionGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FeeTypeSelectionGroupBox.Location = New System.Drawing.Point(19, 50)
        Me.FeeTypeSelectionGroupBox.Name = "FeeTypeSelectionGroupBox"
        '
        'FeeTypeSelectionGroupBox.Panel
        '
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.btnViewBilling)
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.cboBillingMonth)
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.KryptonLabel2)
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.KryptonLabel1)
        Me.FeeTypeSelectionGroupBox.Panel.Controls.Add(Me.cboFeeType)
        Me.FeeTypeSelectionGroupBox.Size = New System.Drawing.Size(698, 123)
        Me.FeeTypeSelectionGroupBox.TabIndex = 25
        Me.FeeTypeSelectionGroupBox.Text = "FEE TYPE SELECTION"
        Me.FeeTypeSelectionGroupBox.Values.Heading = "FEE TYPE SELECTION"
        '
        'btnViewBilling
        '
        Me.btnViewBilling.Location = New System.Drawing.Point(352, 31)
        Me.btnViewBilling.Name = "btnViewBilling"
        Me.btnViewBilling.Size = New System.Drawing.Size(114, 38)
        Me.btnViewBilling.TabIndex = 4
        Me.btnViewBilling.Values.Text = "View Statements"
        '
        'cboBillingMonth
        '
        Me.cboBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingMonth.DropDownWidth = 182
        Me.cboBillingMonth.Items.AddRange(New Object() {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.cboBillingMonth.Location = New System.Drawing.Point(151, 50)
        Me.cboBillingMonth.Name = "cboBillingMonth"
        Me.cboBillingMonth.Size = New System.Drawing.Size(195, 21)
        Me.cboBillingMonth.TabIndex = 3
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(43, 51)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel2.TabIndex = 2
        Me.KryptonLabel2.Values.Text = "BILLING MONTH"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(86, 24)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(59, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "FEE TYPE"
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 195
        Me.cboFeeType.Location = New System.Drawing.Point(151, 21)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(195, 21)
        Me.cboFeeType.TabIndex = 0
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(5, 5)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(722, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 24
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "Billing Statements"
        '
        'BillingPrintingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 658)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "BillingPrintingForm"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrintCommand.ResumeLayout(False)
        Me.pnlPrintCommand.PerformLayout()
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.Panel.ResumeLayout(False)
        Me.StatementsGroupBox.Panel.PerformLayout()
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.ResumeLayout(False)
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BillingGridPanel.ResumeLayout(False)
        CType(Me.dgBillingStatements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.FeeTypeSelectionGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FeeTypeSelectionGroupBox.Panel.ResumeLayout(False)
        Me.FeeTypeSelectionGroupBox.Panel.PerformLayout()
        CType(Me.FeeTypeSelectionGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FeeTypeSelectionGroupBox.ResumeLayout(False)
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnViewBilling As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents StatementsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblRecordCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlPrintCommand As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnPrintPreview As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkPrintNotes As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtBillingNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents BillingGridPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgBillingStatements As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class
