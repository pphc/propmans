<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewVehicleForm
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
        Me.components = New System.ComponentModel.Container()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.VehiclesInformationgbox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkActive = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel43 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtColor = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtModel = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtMake = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtPlateNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel40 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel41 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel42 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.VehiclesInformationgbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VehiclesInformationgbox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VehiclesInformationgbox.Panel.SuspendLayout()
        Me.VehiclesInformationgbox.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.VehiclesInformationgbox)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Margin = New System.Windows.Forms.Padding(25)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(388, 237)
        Me.KryptonPanel.TabIndex = 0
        '
        'VehiclesInformationgbox
        '
        Me.VehiclesInformationgbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.VehiclesInformationgbox.Location = New System.Drawing.Point(5, 5)
        Me.VehiclesInformationgbox.Name = "VehiclesInformationgbox"
        '
        'VehiclesInformationgbox.Panel
        '
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.chkActive)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.KryptonLabel43)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.txtColor)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.txtModel)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.txtMake)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.txtPlateNumber)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.KryptonLabel40)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.KryptonLabel41)
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.KryptonLabel42)
        Me.VehiclesInformationgbox.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.VehiclesInformationgbox.Size = New System.Drawing.Size(378, 178)
        Me.VehiclesInformationgbox.TabIndex = 46
        Me.VehiclesInformationgbox.Text = "VEHICLE INFORMATION"
        Me.VehiclesInformationgbox.Values.Heading = "VEHICLE INFORMATION"
        '
        'chkActive
        '
        Me.chkActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkActive.Location = New System.Drawing.Point(111, 125)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(63, 20)
        Me.chkActive.TabIndex = 30
        Me.chkActive.Text = "ACTIVE"
        Me.chkActive.Values.Text = "ACTIVE"
        '
        'KryptonLabel43
        '
        Me.KryptonLabel43.Location = New System.Drawing.Point(54, 99)
        Me.KryptonLabel43.Name = "KryptonLabel43"
        Me.KryptonLabel43.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel43.TabIndex = 29
        Me.KryptonLabel43.Values.Text = "COLOR :"
        '
        'txtColor
        '
        Me.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColor.Location = New System.Drawing.Point(111, 96)
        Me.txtColor.MaxLength = 20
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(225, 20)
        Me.txtColor.TabIndex = 28
        Me.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtModel
        '
        Me.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModel.Location = New System.Drawing.Point(111, 70)
        Me.txtModel.MaxLength = 20
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(225, 20)
        Me.txtModel.TabIndex = 27
        Me.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMake
        '
        Me.txtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMake.Location = New System.Drawing.Point(111, 44)
        Me.txtMake.MaxLength = 20
        Me.txtMake.Name = "txtMake"
        Me.txtMake.Size = New System.Drawing.Size(225, 20)
        Me.txtMake.TabIndex = 26
        Me.txtMake.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPlateNumber
        '
        Me.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlateNumber.Location = New System.Drawing.Point(111, 18)
        Me.txtPlateNumber.MaxLength = 15
        Me.txtPlateNumber.Name = "txtPlateNumber"
        Me.txtPlateNumber.Size = New System.Drawing.Size(225, 20)
        Me.txtPlateNumber.TabIndex = 25
        Me.txtPlateNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel40
        '
        Me.KryptonLabel40.Location = New System.Drawing.Point(11, 70)
        Me.KryptonLabel40.Name = "KryptonLabel40"
        Me.KryptonLabel40.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel40.TabIndex = 14
        Me.KryptonLabel40.Values.Text = "MODEL /SERIES:"
        '
        'KryptonLabel41
        '
        Me.KryptonLabel41.Location = New System.Drawing.Point(60, 47)
        Me.KryptonLabel41.Name = "KryptonLabel41"
        Me.KryptonLabel41.Size = New System.Drawing.Size(49, 20)
        Me.KryptonLabel41.TabIndex = 13
        Me.KryptonLabel41.Values.Text = "MAKE :"
        '
        'KryptonLabel42
        '
        Me.KryptonLabel42.Location = New System.Drawing.Point(40, 19)
        Me.KryptonLabel42.Name = "KryptonLabel42"
        Me.KryptonLabel42.Size = New System.Drawing.Size(72, 20)
        Me.KryptonLabel42.TabIndex = 10
        Me.KryptonLabel42.Values.Text = "PLATE NO :"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(307, 189)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 36)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(225, 189)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 36)
        Me.btnSave.TabIndex = 44
        Me.btnSave.Values.Text = "&SAVE"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewVehicleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 237)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewVehicleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Vehicle"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.VehiclesInformationgbox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VehiclesInformationgbox.Panel.ResumeLayout(False)
        Me.VehiclesInformationgbox.Panel.PerformLayout()
        CType(Me.VehiclesInformationgbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VehiclesInformationgbox.ResumeLayout(False)
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
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents VehiclesInformationgbox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents chkActive As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel43 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtColor As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtModel As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtMake As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPlateNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel40 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel41 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel42 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
