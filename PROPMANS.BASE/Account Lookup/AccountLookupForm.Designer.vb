<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountLookupForm
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
        Me.btnRefresh = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSelect = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.ResultCountLabel = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SearchResultsPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.SearchValueTextBox = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.ClearSearchValueButton = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.DisplayInactiveAccountsCheckBox = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.ByFirstNameRadioButton = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.ByUnitNumberRadioButton = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.ByLastNameRadioButton = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
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
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(748, 456)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.btnCancel)
        Me.KryptonPanel4.Controls.Add(Me.btnRefresh)
        Me.KryptonPanel4.Controls.Add(Me.btnSelect)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.Location = New System.Drawing.Point(10, 399)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(728, 47)
        Me.KryptonPanel4.TabIndex = 22
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(641, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(14, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 35)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Values.Text = "REFRESH"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(554, 3)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(81, 35)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Values.Text = "&OK"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.ResultCountLabel)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(10, 366)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(728, 33)
        Me.KryptonPanel3.TabIndex = 21
        '
        'ResultCountLabel
        '
        Me.ResultCountLabel.AutoSize = False
        Me.ResultCountLabel.Location = New System.Drawing.Point(571, 2)
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
        Me.KryptonPanel2.Location = New System.Drawing.Point(10, 121)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel2.Size = New System.Drawing.Size(728, 245)
        Me.KryptonPanel2.TabIndex = 20
        '
        'SearchResultsPanel
        '
        Me.SearchResultsPanel.Controls.Add(Me.grid)
        Me.SearchResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchResultsPanel.Location = New System.Drawing.Point(5, 5)
        Me.SearchResultsPanel.Name = "SearchResultsPanel"
        Me.SearchResultsPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.SearchResultsPanel.Size = New System.Drawing.Size(718, 235)
        Me.SearchResultsPanel.TabIndex = 15
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(1, 1)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(716, 233)
        Me.grid.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(10, 21)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.SearchValueTextBox)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnSearch)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.DisplayInactiveAccountsCheckBox)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.ByFirstNameRadioButton)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.ByUnitNumberRadioButton)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.ByLastNameRadioButton)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(728, 100)
        Me.KryptonGroupBox1.TabIndex = 19
        Me.KryptonGroupBox1.Text = "SEARCH ACCOUNT BY"
        Me.KryptonGroupBox1.Values.Heading = "SEARCH ACCOUNT BY"
        '
        'SearchValueTextBox
        '
        Me.SearchValueTextBox.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.ClearSearchValueButton})
        Me.SearchValueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SearchValueTextBox.Location = New System.Drawing.Point(12, 45)
        Me.SearchValueTextBox.Name = "SearchValueTextBox"
        Me.SearchValueTextBox.Size = New System.Drawing.Size(274, 20)
        Me.SearchValueTextBox.TabIndex = 0
        Me.SearchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ClearSearchValueButton
        '
        Me.ClearSearchValueButton.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close
        Me.ClearSearchValueButton.UniqueName = "98EFC43EAFBD4ADEEB92E71BE322ED2C"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(639, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(81, 39)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Values.Text = "&SEARCH"
        '
        'DisplayInactiveAccountsCheckBox
        '
        Me.DisplayInactiveAccountsCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.DisplayInactiveAccountsCheckBox.Location = New System.Drawing.Point(292, 45)
        Me.DisplayInactiveAccountsCheckBox.Name = "DisplayInactiveAccountsCheckBox"
        Me.DisplayInactiveAccountsCheckBox.Size = New System.Drawing.Size(192, 20)
        Me.DisplayInactiveAccountsCheckBox.TabIndex = 1
        Me.DisplayInactiveAccountsCheckBox.Text = "DISPLAY INACTIVE ACCOUNTS"
        Me.DisplayInactiveAccountsCheckBox.Values.Text = "DISPLAY INACTIVE ACCOUNTS"
        '
        'ByFirstNameRadioButton
        '
        Me.ByFirstNameRadioButton.Location = New System.Drawing.Point(202, 20)
        Me.ByFirstNameRadioButton.Name = "ByFirstNameRadioButton"
        Me.ByFirstNameRadioButton.Size = New System.Drawing.Size(90, 20)
        Me.ByFirstNameRadioButton.TabIndex = 2
        Me.ByFirstNameRadioButton.Tag = "ByFirstName"
        Me.ByFirstNameRadioButton.Values.Text = "FIRST NAME"
        '
        'ByUnitNumberRadioButton
        '
        Me.ByUnitNumberRadioButton.Location = New System.Drawing.Point(12, 20)
        Me.ByUnitNumberRadioButton.Name = "ByUnitNumberRadioButton"
        Me.ByUnitNumberRadioButton.Size = New System.Drawing.Size(103, 20)
        Me.ByUnitNumberRadioButton.TabIndex = 0
        Me.ByUnitNumberRadioButton.Tag = "ByUnitNumber"
        Me.ByUnitNumberRadioButton.Values.Text = "UNIT NUMBER"
        '
        'ByLastNameRadioButton
        '
        Me.ByLastNameRadioButton.Location = New System.Drawing.Point(114, 20)
        Me.ByLastNameRadioButton.Name = "ByLastNameRadioButton"
        Me.ByLastNameRadioButton.Size = New System.Drawing.Size(87, 20)
        Me.ByLastNameRadioButton.TabIndex = 1
        Me.ByLastNameRadioButton.Tag = "ByLastName"
        Me.ByLastNameRadioButton.Values.Text = "LAST NAME"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 10)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(728, 11)
        Me.KryptonPanel1.TabIndex = 15
        '
        'AccountLookupForm
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 456)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccountLookupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUSTOMER ACCOUNT LOOKUP"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.SearchResultsPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchResultsPanel.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnRefresh As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ResultCountLabel As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents SearchValueTextBox As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents ClearSearchValueButton As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents DisplayInactiveAccountsCheckBox As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents ByFirstNameRadioButton As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents ByUnitNumberRadioButton As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents ByLastNameRadioButton As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents SearchResultsPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
End Class
