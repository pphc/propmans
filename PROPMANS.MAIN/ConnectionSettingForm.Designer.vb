<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionSettingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectionSettingForm))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtAppSchema = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnUpdate = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtServiceName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtHostPort = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtHostName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel,System.ComponentModel.ISupportInitialize).BeginInit
        Me.KryptonPanel.SuspendLayout
        Me.SuspendLayout
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.txtAppSchema)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.btnUpdate)
        Me.KryptonPanel.Controls.Add(Me.txtServiceName)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.txtHostPort)
        Me.KryptonPanel.Controls.Add(Me.txtHostName)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(315, 199)
        Me.KryptonPanel.TabIndex = 0
        '
        'txtAppSchema
        '
        Me.txtAppSchema.Location = New System.Drawing.Point(113, 105)
        Me.txtAppSchema.Name = "txtAppSchema"
        Me.txtAppSchema.Size = New System.Drawing.Size(188, 20)
        Me.txtAppSchema.TabIndex = 3
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(20, 105)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(87, 20)
        Me.KryptonLabel4.TabIndex = 10
        Me.KryptonLabel4.Values.Text = "APP SCHEMA:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(113, 154)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(91, 33)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Values.Text = "UPDATE"
        '
        'txtServiceName
        '
        Me.txtServiceName.Location = New System.Drawing.Point(113, 79)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(188, 20)
        Me.txtServiceName.TabIndex = 2
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(25, 27)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(82, 20)
        Me.KryptonLabel2.TabIndex = 7
        Me.KryptonLabel2.Values.Text = "HOST NAME:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(12, 79)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(96, 20)
        Me.KryptonLabel3.TabIndex = 6
        Me.KryptonLabel3.Values.Text = "SERVICE NAME:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(64, 53)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(43, 20)
        Me.KryptonLabel1.TabIndex = 4
        Me.KryptonLabel1.Values.Text = "PORT:"
        '
        'txtHostPort
        '
        Me.txtHostPort.Location = New System.Drawing.Point(113, 53)
        Me.txtHostPort.Name = "txtHostPort"
        Me.txtHostPort.Size = New System.Drawing.Size(188, 20)
        Me.txtHostPort.TabIndex = 1
        '
        'txtHostName
        '
        Me.txtHostName.Location = New System.Drawing.Point(113, 27)
        Me.txtHostName.MaxLength = 15
        Me.txtHostName.Name = "txtHostName"
        Me.txtHostName.Size = New System.Drawing.Size(188, 20)
        Me.txtHostName.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(210, 154)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 33)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ConnectionSettingForm
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 199)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = true
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "ConnectionSettingForm"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Connection Settings"
        CType(Me.KryptonPanel,System.ComponentModel.ISupportInitialize).EndInit
        Me.KryptonPanel.ResumeLayout(false)
        Me.KryptonPanel.PerformLayout
        Me.ResumeLayout(false)

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
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtHostPort As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtHostName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtServiceName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnUpdate As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtAppSchema As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
