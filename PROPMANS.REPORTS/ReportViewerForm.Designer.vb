<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewerForm
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
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ReportOptionsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnPreviewReport = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pnlReportOptions = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.rptCommonBilling1 = New PROPMANS.REPORTS.rptCommonBilling()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.ReportOptionsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportOptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReportOptionsGroupBox.Panel.SuspendLayout()
        Me.ReportOptionsGroupBox.SuspendLayout()
        CType(Me.pnlReportOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(936, 658)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.CrystalReportViewer)
        Me.KryptonPanel2.Controls.Add(Me.ReportOptionsGroupBox)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel2.Size = New System.Drawing.Size(936, 658)
        Me.KryptonPanel2.TabIndex = 25
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(5, 181)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowLogo = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(926, 472)
        Me.CrystalReportViewer.TabIndex = 28
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportOptionsGroupBox
        '
        Me.ReportOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportOptionsGroupBox.Location = New System.Drawing.Point(5, 5)
        Me.ReportOptionsGroupBox.Name = "ReportOptionsGroupBox"
        '
        'ReportOptionsGroupBox.Panel
        '
        Me.ReportOptionsGroupBox.Panel.Controls.Add(Me.btnPreviewReport)
        Me.ReportOptionsGroupBox.Panel.Controls.Add(Me.pnlReportOptions)
        Me.ReportOptionsGroupBox.Size = New System.Drawing.Size(926, 176)
        Me.ReportOptionsGroupBox.TabIndex = 27
        Me.ReportOptionsGroupBox.Values.Heading = ""
        '
        'btnPreviewReport
        '
        Me.btnPreviewReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreviewReport.Location = New System.Drawing.Point(795, 68)
        Me.btnPreviewReport.Name = "btnPreviewReport"
        Me.btnPreviewReport.Size = New System.Drawing.Size(122, 48)
        Me.btnPreviewReport.TabIndex = 10
        Me.btnPreviewReport.Values.Text = "PREVIEW REPORT"
        '
        'pnlReportOptions
        '
        Me.pnlReportOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReportOptions.Location = New System.Drawing.Point(0, 0)
        Me.pnlReportOptions.Name = "pnlReportOptions"
        Me.pnlReportOptions.Size = New System.Drawing.Size(795, 169)
        Me.pnlReportOptions.TabIndex = 9
        '
        'ReportViewerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 658)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportViewerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT VIEWER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.ReportOptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReportOptionsGroupBox.Panel.ResumeLayout(False)
        CType(Me.ReportOptionsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReportOptionsGroupBox.ResumeLayout(False)
        CType(Me.pnlReportOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents ReportOptionsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnPreviewReport As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlReportOptions As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents rptCommonBilling1 As PROPMANS.REPORTS.rptCommonBilling
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
