<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MeterReconnectionForm
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
        Me.KryptonGroupBox4 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dtpReconnectionDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.lblDisconnectionDate = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDisconnectionReason = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDisconnectionType = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.AccountInfoGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.lblAccountName = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblMeterNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox4.Panel.SuspendLayout()
        Me.KryptonGroupBox4.SuspendLayout()
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
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox4)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.AccountInfoGroupBox)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(653, 351)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnSave)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 284)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(633, 57)
        Me.KryptonPanel1.TabIndex = 65
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(438, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 36)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Values.Text = "SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(534, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'KryptonGroupBox4
        '
        Me.KryptonGroupBox4.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonGroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox4.Location = New System.Drawing.Point(10, 220)
        Me.KryptonGroupBox4.Name = "KryptonGroupBox4"
        '
        'KryptonGroupBox4.Panel
        '
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.dtpReconnectionDate)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.KryptonLabel7)
        Me.KryptonGroupBox4.Size = New System.Drawing.Size(633, 64)
        Me.KryptonGroupBox4.TabIndex = 64
        Me.KryptonGroupBox4.Text = "RECONNECTION INFORMATION"
        Me.KryptonGroupBox4.Values.Heading = "RECONNECTION INFORMATION"
        '
        'dtpReconnectionDate
        '
        Me.dtpReconnectionDate.Location = New System.Drawing.Point(175, 12)
        Me.dtpReconnectionDate.Name = "dtpReconnectionDate"
        Me.dtpReconnectionDate.Size = New System.Drawing.Size(224, 20)
        Me.dtpReconnectionDate.TabIndex = 85
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(43, 13)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(126, 19)
        Me.KryptonLabel7.TabIndex = 84
        Me.KryptonLabel7.Values.Text = "RECONNECTION DATE:"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(10, 113)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDisconnectionDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDisconnectionReason)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDisconnectionType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(633, 107)
        Me.KryptonGroupBox1.TabIndex = 61
        Me.KryptonGroupBox1.Text = "DISCONNECTION INFORMATION"
        Me.KryptonGroupBox1.Values.Heading = "DISCONNECTION INFORMATION"
        '
        'lblDisconnectionDate
        '
        Me.lblDisconnectionDate.Location = New System.Drawing.Point(491, 12)
        Me.lblDisconnectionDate.Name = "lblDisconnectionDate"
        Me.lblDisconnectionDate.Size = New System.Drawing.Size(131, 19)
        Me.lblDisconnectionDate.TabIndex = 88
        Me.lblDisconnectionDate.Values.Text = "DISCONNECTION DATE:"
        '
        'lblDisconnectionReason
        '
        Me.lblDisconnectionReason.AutoSize = False
        Me.lblDisconnectionReason.Location = New System.Drawing.Point(175, 37)
        Me.lblDisconnectionReason.Name = "lblDisconnectionReason"
        Me.lblDisconnectionReason.Size = New System.Drawing.Size(351, 19)
        Me.lblDisconnectionReason.TabIndex = 87
        Me.lblDisconnectionReason.Values.Text = "REASON FOR DISCONNECTION:"
        '
        'lblDisconnectionType
        '
        Me.lblDisconnectionType.Location = New System.Drawing.Point(175, 12)
        Me.lblDisconnectionType.Name = "lblDisconnectionType"
        Me.lblDisconnectionType.Size = New System.Drawing.Size(145, 19)
        Me.lblDisconnectionType.TabIndex = 86
        Me.lblDisconnectionType.Values.Text = "TYPE OF DISCONNECTION:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(354, 12)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(131, 19)
        Me.KryptonLabel1.TabIndex = 84
        Me.KryptonLabel1.Values.Text = "DISCONNECTION DATE:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(10, 37)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(171, 19)
        Me.KryptonLabel3.TabIndex = 83
        Me.KryptonLabel3.Values.Text = "REASON FOR DISCONNECTION:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(36, 12)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(145, 19)
        Me.KryptonLabel2.TabIndex = 71
        Me.KryptonLabel2.Values.Text = "TYPE OF DISCONNECTION:"
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
        Me.AccountInfoGroupBox.Panel.Controls.Add(Me.lblMeterNumber)
        Me.AccountInfoGroupBox.Size = New System.Drawing.Size(633, 103)
        Me.AccountInfoGroupBox.TabIndex = 60
        Me.AccountInfoGroupBox.Text = "WATER METER ACCOUNT INFORMATION"
        Me.AccountInfoGroupBox.Values.Heading = "WATER METER ACCOUNT INFORMATION"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(10, 16)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(308, 23)
        Me.lblAccountName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.TabIndex = 36
        Me.lblAccountName.Values.Text = "UNIT NUMBER - UNIT OWNER NAME"
        '
        'lblMeterNumber
        '
        Me.lblMeterNumber.Location = New System.Drawing.Point(10, 49)
        Me.lblMeterNumber.Name = "lblMeterNumber"
        Me.lblMeterNumber.Size = New System.Drawing.Size(119, 19)
        Me.lblMeterNumber.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeterNumber.TabIndex = 37
        Me.lblMeterNumber.Values.Text = "METER NUMBER"
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
        'MeterReconnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 351)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MeterReconnectionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "METER RECONNECTION"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.Panel.ResumeLayout(False)
        Me.KryptonGroupBox4.Panel.PerformLayout()
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.ResumeLayout(False)
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
    Friend WithEvents lblMeterNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox4 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpReconnectionDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents lblDisconnectionDate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblDisconnectionReason As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblDisconnectionType As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
