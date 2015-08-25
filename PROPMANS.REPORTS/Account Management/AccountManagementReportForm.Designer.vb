<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountManagementReportForm
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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chklistBox = New System.Windows.Forms.CheckedListBox()
        Me.btnView = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CAPanelTop = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.HeaderTransactionAudit = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.CAPanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.CAPanelTop)
        Me.KryptonPanel.Controls.Add(Me.HeaderTransactionAudit)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(1040, 679)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 62)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(1020, 607)
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(3, -1)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.chkSelectAll)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.chklistBox)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.btnView)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(1014, 90)
        Me.KryptonGroupBox2.TabIndex = 9
        Me.KryptonGroupBox2.Values.Heading = ""
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(7, 29)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 6
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'chklistBox
        '
        Me.chklistBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chklistBox.CheckOnClick = True
        Me.chklistBox.ColumnWidth = 150
        Me.chklistBox.FormattingEnabled = True
        Me.chklistBox.Location = New System.Drawing.Point(98, 2)
        Me.chklistBox.MultiColumn = True
        Me.chklistBox.Name = "chklistBox"
        Me.chklistBox.Size = New System.Drawing.Size(813, 79)
        Me.chklistBox.TabIndex = 5
        Me.chklistBox.ThreeDCheckBoxes = True
        Me.chklistBox.UseCompatibleTextRendering = True
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(926, 24)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(71, 37)
        Me.btnView.TabIndex = 4
        Me.btnView.Values.Text = "&VIEW"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonPanel2.Controls.Add(Me.CrystalReportViewer)
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 92)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(1020, 515)
        Me.KryptonPanel2.TabIndex = 0
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.EnableDrillDown = False
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowLogo = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(1020, 515)
        Me.CrystalReportViewer.TabIndex = 5
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'CAPanelTop
        '
        Me.CAPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CAPanelTop.Location = New System.Drawing.Point(10, 41)
        Me.CAPanelTop.Name = "CAPanelTop"
        Me.CAPanelTop.Size = New System.Drawing.Size(1020, 21)
        Me.CAPanelTop.TabIndex = 0
        '
        'HeaderTransactionAudit
        '
        Me.HeaderTransactionAudit.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderTransactionAudit.Location = New System.Drawing.Point(10, 10)
        Me.HeaderTransactionAudit.Name = "HeaderTransactionAudit"
        Me.HeaderTransactionAudit.Size = New System.Drawing.Size(1020, 31)
        Me.HeaderTransactionAudit.TabIndex = 0
        Me.HeaderTransactionAudit.Values.Description = ""
        Me.HeaderTransactionAudit.Values.Heading = "UNIT INVENTORY"
        Me.HeaderTransactionAudit.Values.Image = Nothing
        '
        'AccountManagementReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 679)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "AccountManagementReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Management Report Form"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        Me.KryptonGroupBox2.Panel.PerformLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.CAPanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents CAPanelTop As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnView As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Public WithEvents HeaderTransactionAudit As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chklistBox As System.Windows.Forms.CheckedListBox
End Class
