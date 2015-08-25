<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionLookUpForm
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
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSelect = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.ResultCountLabel = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SearchResultsPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgTransactions = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.FilterGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkShowUndepositedPayments = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpTransactionEndDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.dtpTransactionStartDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.SearchResultsPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchResultsPanel.SuspendLayout()
        CType(Me.dgTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterGroupBox.Panel.SuspendLayout()
        Me.FilterGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.FilterGroupBox)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(748, 432)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.btnCancel)
        Me.KryptonPanel4.Controls.Add(Me.btnSelect)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.Location = New System.Drawing.Point(10, 373)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(728, 54)
        Me.KryptonPanel4.TabIndex = 22
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(641, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(554, 6)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(81, 35)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Values.Text = "&OK"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.chkSelectAll)
        Me.KryptonPanel3.Controls.Add(Me.ResultCountLabel)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(10, 340)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(728, 33)
        Me.KryptonPanel3.TabIndex = 21
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(6, 6)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 70
        Me.chkSelectAll.Tag = "OR"
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'ResultCountLabel
        '
        Me.ResultCountLabel.AutoSize = False
        Me.ResultCountLabel.Location = New System.Drawing.Point(571, 5)
        Me.ResultCountLabel.Name = "ResultCountLabel"
        Me.ResultCountLabel.Size = New System.Drawing.Size(151, 25)
        Me.ResultCountLabel.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.ResultCountLabel.TabIndex = 13
        Me.ResultCountLabel.Values.Text = ""
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.SearchResultsPanel)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(10, 95)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel2.Size = New System.Drawing.Size(728, 245)
        Me.KryptonPanel2.TabIndex = 20
        '
        'SearchResultsPanel
        '
        Me.SearchResultsPanel.Controls.Add(Me.dgTransactions)
        Me.SearchResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchResultsPanel.Location = New System.Drawing.Point(5, 5)
        Me.SearchResultsPanel.Name = "SearchResultsPanel"
        Me.SearchResultsPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.SearchResultsPanel.Size = New System.Drawing.Size(718, 235)
        Me.SearchResultsPanel.TabIndex = 15
        '
        'dgTransactions
        '
        Me.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransactions.Location = New System.Drawing.Point(1, 1)
        Me.dgTransactions.Name = "dgTransactions"
        Me.dgTransactions.Size = New System.Drawing.Size(716, 233)
        Me.dgTransactions.TabIndex = 0
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.FilterGroupBox.Location = New System.Drawing.Point(10, 10)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        '
        'FilterGroupBox.Panel
        '
        Me.FilterGroupBox.Panel.Controls.Add(Me.chkShowUndepositedPayments)
        Me.FilterGroupBox.Panel.Controls.Add(Me.KryptonLabel11)
        Me.FilterGroupBox.Panel.Controls.Add(Me.KryptonLabel12)
        Me.FilterGroupBox.Panel.Controls.Add(Me.dtpTransactionEndDate)
        Me.FilterGroupBox.Panel.Controls.Add(Me.dtpTransactionStartDate)
        Me.FilterGroupBox.Panel.Controls.Add(Me.btnSearch)
        Me.FilterGroupBox.Size = New System.Drawing.Size(728, 85)
        Me.FilterGroupBox.TabIndex = 19
        Me.FilterGroupBox.Values.Heading = ""
        '
        'chkShowUndepositedPayments
        '
        Me.chkShowUndepositedPayments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkShowUndepositedPayments.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkShowUndepositedPayments.Location = New System.Drawing.Point(18, 46)
        Me.chkShowUndepositedPayments.Name = "chkShowUndepositedPayments"
        Me.chkShowUndepositedPayments.Size = New System.Drawing.Size(208, 20)
        Me.chkShowUndepositedPayments.TabIndex = 71
        Me.chkShowUndepositedPayments.Tag = "OR"
        Me.chkShowUndepositedPayments.Text = "SHOW UNDEPOSITED PAYMENTS"
        Me.chkShowUndepositedPayments.Values.Text = "SHOW UNDEPOSITED PAYMENTS"
        Me.chkShowUndepositedPayments.Visible = False
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(255, 21)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(26, 20)
        Me.KryptonLabel11.TabIndex = 47
        Me.KryptonLabel11.Values.Text = "TO"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(18, 20)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(44, 20)
        Me.KryptonLabel12.TabIndex = 46
        Me.KryptonLabel12.Values.Text = "FROM"
        '
        'dtpTransactionEndDate
        '
        Me.dtpTransactionEndDate.AlwaysActive = False
        Me.dtpTransactionEndDate.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ButtonSpec
        Me.dtpTransactionEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionEndDate.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1
        Me.dtpTransactionEndDate.Location = New System.Drawing.Point(287, 20)
        Me.dtpTransactionEndDate.Name = "dtpTransactionEndDate"
        Me.dtpTransactionEndDate.Size = New System.Drawing.Size(176, 21)
        Me.dtpTransactionEndDate.TabIndex = 45
        '
        'dtpTransactionStartDate
        '
        Me.dtpTransactionStartDate.AlwaysActive = False
        Me.dtpTransactionStartDate.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ButtonSpec
        Me.dtpTransactionStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionStartDate.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1
        Me.dtpTransactionStartDate.Location = New System.Drawing.Point(68, 20)
        Me.dtpTransactionStartDate.Name = "dtpTransactionStartDate"
        Me.dtpTransactionStartDate.Size = New System.Drawing.Size(181, 21)
        Me.dtpTransactionStartDate.TabIndex = 44
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(639, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(81, 36)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Values.Text = "&SEARCH"
        '
        'TransactionLookUpForm
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 432)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransactionLookUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRANSACTION LOOKUP"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.SearchResultsPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchResultsPanel.ResumeLayout(False)
        CType(Me.dgTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilterGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterGroupBox.Panel.ResumeLayout(False)
        Me.FilterGroupBox.Panel.PerformLayout()
        CType(Me.FilterGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSelect As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ResultCountLabel As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents FilterGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents SearchResultsPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgTransactions As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpTransactionEndDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpTransactionStartDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkShowUndepositedPayments As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class
