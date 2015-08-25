<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ACCPACBillingExportForm
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
        Me.chkLauchFile = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.txtDirectoryPath = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.btnBrowseFile = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.OptionsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dudBillingYear = New ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown
        Me.cboBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton
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
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(975, 680)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.OptionsGroupBox)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Location = New System.Drawing.Point(145, 59)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(725, 548)
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(125, 192)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblFileName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkLauchFile)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDirectoryPath)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(396, 142)
        Me.KryptonGroupBox1.TabIndex = 10
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
        'chkLauchFile
        '
        Me.chkLauchFile.Location = New System.Drawing.Point(104, 55)
        Me.chkLauchFile.Name = "chkLauchFile"
        Me.chkLauchFile.Size = New System.Drawing.Size(152, 19)
        Me.chkLauchFile.TabIndex = 4
        Me.chkLauchFile.Values.Text = "Launch File After Creation"
        '
        'txtDirectoryPath
        '
        Me.txtDirectoryPath.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnBrowseFile})
        Me.txtDirectoryPath.Location = New System.Drawing.Point(104, 22)
        Me.txtDirectoryPath.Name = "txtDirectoryPath"
        Me.txtDirectoryPath.Size = New System.Drawing.Size(260, 27)
        Me.txtDirectoryPath.TabIndex = 2
        '
        'btnBrowseFile
        '
        Me.btnBrowseFile.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnBrowseFile.Text = ". . ."
        Me.btnBrowseFile.UniqueName = "A23C846CF8B041B453BF7CA3D9DB55D6"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(15, 22)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(83, 19)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "FOLDER PATH:"
        '
        'OptionsGroupBox
        '
        Me.OptionsGroupBox.Location = New System.Drawing.Point(125, 61)
        Me.OptionsGroupBox.Name = "OptionsGroupBox"
        '
        'OptionsGroupBox.Panel
        '
        Me.OptionsGroupBox.Panel.Controls.Add(Me.dudBillingYear)
        Me.OptionsGroupBox.Panel.Controls.Add(Me.cboBillingMonth)
        Me.OptionsGroupBox.Panel.Controls.Add(Me.KryptonLabel5)
        Me.OptionsGroupBox.Size = New System.Drawing.Size(396, 125)
        Me.OptionsGroupBox.TabIndex = 9
        Me.OptionsGroupBox.Values.Heading = "BILLING MONTH"
        '
        'dudBillingYear
        '
        Me.dudBillingYear.Location = New System.Drawing.Point(263, 31)
        Me.dudBillingYear.Name = "dudBillingYear"
        Me.dudBillingYear.Size = New System.Drawing.Size(70, 21)
        Me.dudBillingYear.TabIndex = 6
        '
        'cboBillingMonth
        '
        Me.cboBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingMonth.DropDownWidth = 139
        Me.cboBillingMonth.Location = New System.Drawing.Point(117, 31)
        Me.cboBillingMonth.Name = "cboBillingMonth"
        Me.cboBillingMonth.Size = New System.Drawing.Size(139, 22)
        Me.cboBillingMonth.TabIndex = 5
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(15, 34)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(96, 19)
        Me.KryptonLabel5.TabIndex = 4
        Me.KryptonLabel5.Values.Text = "BILLING MONTH:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(125, 350)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(142, 35)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Values.Text = "GENERATE EXPORT FILE"
        '
        'ACCPACBillingExportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 680)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "ACCPACBillingExportForm"
        Me.Text = "Billings Export for ACCPAC"
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
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblFileName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkLauchFile As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtDirectoryPath As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnBrowseFile As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents OptionsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dudBillingYear As ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown
    Friend WithEvents cboBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
End Class
