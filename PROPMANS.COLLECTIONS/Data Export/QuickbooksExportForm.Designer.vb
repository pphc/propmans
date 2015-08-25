<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickbooksExportForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.lblFileName = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.chkLauchFile = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.btnBrowseFileLocation = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.txtDirectoryPath = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.OptionsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dtpToDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.dtpFromDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.OptionsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OptionsGroupBox.Panel.SuspendLayout()
        Me.OptionsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnClose)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(425, 334)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.OptionsGroupBox)
        Me.KryptonPanel1.Location = New System.Drawing.Point(3, 12)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(419, 274)
        Me.KryptonPanel1.TabIndex = 2
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(3, 134)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblFileName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkLauchFile)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnBrowseFileLocation)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDirectoryPath)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(416, 137)
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Text = "SAVE TO"
        Me.KryptonGroupBox1.Values.Heading = "SAVE TO"
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(73, 47)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(6, 2)
        Me.lblFileName.TabIndex = 6
        Me.lblFileName.Values.Text = ""
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 47)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(67, 19)
        Me.KryptonLabel4.TabIndex = 5
        Me.KryptonLabel4.Values.Text = "FILE NAME:"
        '
        'chkLauchFile
        '
        Me.chkLauchFile.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkLauchFile.Location = New System.Drawing.Point(71, 72)
        Me.chkLauchFile.Name = "chkLauchFile"
        Me.chkLauchFile.Size = New System.Drawing.Size(152, 19)
        Me.chkLauchFile.TabIndex = 4
        Me.chkLauchFile.Text = "Launch File After Creation"
        Me.chkLauchFile.Values.Text = "Launch File After Creation"
        '
        'btnBrowseFileLocation
        '
        Me.btnBrowseFileLocation.Location = New System.Drawing.Point(337, 19)
        Me.btnBrowseFileLocation.Name = "btnBrowseFileLocation"
        Me.btnBrowseFileLocation.Size = New System.Drawing.Size(27, 24)
        Me.btnBrowseFileLocation.TabIndex = 3
        Me.btnBrowseFileLocation.Values.Text = ". . ."
        '
        'txtDirectoryPath
        '
        Me.txtDirectoryPath.Location = New System.Drawing.Point(71, 19)
        Me.txtDirectoryPath.Name = "txtDirectoryPath"
        Me.txtDirectoryPath.Size = New System.Drawing.Size(260, 22)
        Me.txtDirectoryPath.TabIndex = 2
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(4, 22)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(63, 19)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "FILE PATH:"
        '
        'OptionsGroupBox
        '
        Me.OptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.OptionsGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.OptionsGroupBox.Name = "OptionsGroupBox"
        '
        'OptionsGroupBox.Panel
        '
        Me.OptionsGroupBox.Panel.Controls.Add(Me.dtpToDate)
        Me.OptionsGroupBox.Panel.Controls.Add(Me.dtpFromDate)
        Me.OptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel2)
        Me.OptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel1)
        Me.OptionsGroupBox.Size = New System.Drawing.Size(419, 129)
        Me.OptionsGroupBox.TabIndex = 3
        Me.OptionsGroupBox.Text = "OPTIONS"
        Me.OptionsGroupBox.Values.Heading = "OPTIONS"
        '
        'dtpToDate
        '
        Me.dtpToDate.Location = New System.Drawing.Point(74, 59)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(260, 20)
        Me.dtpToDate.TabIndex = 3
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Location = New System.Drawing.Point(74, 23)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(260, 20)
        Me.dtpFromDate.TabIndex = 2
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(43, 60)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(27, 19)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "TO:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(26, 24)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(44, 19)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "FROM:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(271, 292)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(68, 30)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(345, 292)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 30)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Values.Text = "Close"
        '
        'QuickbooksExportForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 334)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "QuickbooksExportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dialogue Name"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.OptionsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OptionsGroupBox.Panel.ResumeLayout(False)
        Me.OptionsGroupBox.Panel.PerformLayout()
        CType(Me.OptionsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OptionsGroupBox.ResumeLayout(False)
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
    Friend WithEvents btnClose As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents OptionsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dtpToDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpFromDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnBrowseFileLocation As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtDirectoryPath As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkLauchFile As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblFileName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
