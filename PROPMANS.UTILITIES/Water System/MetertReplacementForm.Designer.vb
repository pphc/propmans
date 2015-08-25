<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MetertReplacementForm
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
        Me.components = New System.ComponentModel.Container
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.txtMeterRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtInstalledBy = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtStartReading = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.dtpInstallationDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.txtMeterNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.AccountInfoGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.lblAccountName = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.AccountInfoGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountInfoGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccountInfoGroupBox.Panel.SuspendLayout()
        Me.AccountInfoGroupBox.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.AccountInfoGroupBox)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(707, 342)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnSave)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 277)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(687, 55)
        Me.KryptonPanel1.TabIndex = 65
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(486, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 36)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Values.Text = "SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(582, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(10, 107)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMeterRemarks)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtInstalledBy)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtStartReading)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpInstallationDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMeterNumber)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel8)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel9)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(687, 170)
        Me.KryptonGroupBox1.TabIndex = 61
        Me.KryptonGroupBox1.Text = "NEW METER INFORMATION"
        Me.KryptonGroupBox1.Values.Heading = "NEW METER INFORMATION"
        '
        'txtMeterRemarks
        '
        Me.txtMeterRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMeterRemarks.Location = New System.Drawing.Point(382, 55)
        Me.txtMeterRemarks.MaxLength = 100
        Me.txtMeterRemarks.Multiline = True
        Me.txtMeterRemarks.Name = "txtMeterRemarks"
        Me.txtMeterRemarks.Size = New System.Drawing.Size(288, 77)
        Me.txtMeterRemarks.TabIndex = 86
        Me.txtMeterRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(382, 29)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(97, 19)
        Me.KryptonLabel1.TabIndex = 85
        Me.KryptonLabel1.Values.Text = "METER REMARKS"
        '
        'txtInstalledBy
        '
        Me.txtInstalledBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInstalledBy.Location = New System.Drawing.Point(119, 109)
        Me.txtInstalledBy.MaxLength = 50
        Me.txtInstalledBy.Name = "txtInstalledBy"
        Me.txtInstalledBy.Size = New System.Drawing.Size(245, 22)
        Me.txtInstalledBy.TabIndex = 84
        Me.txtInstalledBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStartReading
        '
        Me.txtStartReading.Location = New System.Drawing.Point(119, 81)
        Me.txtStartReading.Name = "txtStartReading"
        Me.txtStartReading.Size = New System.Drawing.Size(245, 22)
        Me.txtStartReading.TabIndex = 83
        Me.txtStartReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpInstallationDate
        '
        Me.dtpInstallationDate.Location = New System.Drawing.Point(119, 54)
        Me.dtpInstallationDate.Name = "dtpInstallationDate"
        Me.dtpInstallationDate.Size = New System.Drawing.Size(245, 20)
        Me.dtpInstallationDate.TabIndex = 82
        '
        'txtMeterNumber
        '
        Me.txtMeterNumber.Location = New System.Drawing.Point(119, 26)
        Me.txtMeterNumber.Name = "txtMeterNumber"
        Me.txtMeterNumber.Size = New System.Drawing.Size(245, 22)
        Me.txtMeterNumber.TabIndex = 81
        Me.txtMeterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(24, 112)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(84, 19)
        Me.KryptonLabel3.TabIndex = 80
        Me.KryptonLabel3.Values.Text = "INSTALLED BY:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(13, 87)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(95, 19)
        Me.KryptonLabel2.TabIndex = 79
        Me.KryptonLabel2.Values.Text = "START READING:"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(10, 55)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(98, 19)
        Me.KryptonLabel8.TabIndex = 78
        Me.KryptonLabel8.Values.Text = "INSTALLED DATE:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(45, 29)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(67, 19)
        Me.KryptonLabel9.TabIndex = 77
        Me.KryptonLabel9.Values.Text = "METER NO:"
        '
        'AccountInfoGroupBox
        '
        Me.AccountInfoGroupBox.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.AccountInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.AccountInfoGroupBox.Location = New System.Drawing.Point(10, 10)
        Me.AccountInfoGroupBox.Name = "AccountInfoGroupBox"
        '
        'AccountInfoGroupBox.Panel
        '
        Me.AccountInfoGroupBox.Panel.Controls.Add(Me.lblAccountName)
        Me.AccountInfoGroupBox.Size = New System.Drawing.Size(687, 97)
        Me.AccountInfoGroupBox.TabIndex = 60
        Me.AccountInfoGroupBox.Text = "OWNER ACCOUNT INFORMATION"
        Me.AccountInfoGroupBox.Values.Heading = "OWNER ACCOUNT INFORMATION"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(10, 22)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(308, 23)
        Me.lblAccountName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.TabIndex = 36
        Me.lblAccountName.Values.Text = "UNIT NUMBER - UNIT OWNER NAME"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(10, 16)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(308, 23)
        Me.KryptonLabel4.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel4.TabIndex = 36
        Me.KryptonLabel4.Values.Text = "UNIT NUMBER - UNIT OWNER NAME"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(10, 49)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(119, 19)
        Me.KryptonLabel5.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel5.TabIndex = 37
        Me.KryptonLabel5.Values.Text = "METER NUMBER"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(10, 74)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(259, 19)
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 47
        Me.KryptonLabel6.Values.Text = "AVERAGE READING - LAST X MONTHS"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'MetertReplacementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 342)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MetertReplacementForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "METER REPLACEMENT"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.AccountInfoGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccountInfoGroupBox.Panel.ResumeLayout(False)
        Me.AccountInfoGroupBox.Panel.PerformLayout()
        CType(Me.AccountInfoGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccountInfoGroupBox.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents AccountInfoGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblAccountName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMeterRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtInstalledBy As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtStartReading As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dtpInstallationDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents txtMeterNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
