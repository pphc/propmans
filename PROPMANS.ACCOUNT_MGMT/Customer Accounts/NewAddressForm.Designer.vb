<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAddressForm
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
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkMakeDefault = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.ComboBoxAddressType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.RbAddressNo = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.RbAddressYes = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.txtAddressInformation = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.ComboBoxAddressType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(445, 258)
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(371, 224)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 29)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(295, 224)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 29)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Values.Text = "&SAVE"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkMakeDefault)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.ComboBoxAddressType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel10)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.RbAddressNo)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.RbAddressYes)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAddressInformation)
        Me.KryptonGroupBox1.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(435, 194)
        Me.KryptonGroupBox1.TabIndex = 41
        Me.KryptonGroupBox1.Text = "ADDRESS INFORMATION"
        Me.KryptonGroupBox1.Values.Heading = "ADDRESS INFORMATION"
        '
        'chkMakeDefault
        '
        Me.chkMakeDefault.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkMakeDefault.Location = New System.Drawing.Point(172, 139)
        Me.chkMakeDefault.Name = "chkMakeDefault"
        Me.chkMakeDefault.Size = New System.Drawing.Size(144, 20)
        Me.chkMakeDefault.TabIndex = 52
        Me.chkMakeDefault.Text = "Make Default Address"
        Me.chkMakeDefault.Values.Text = "Make Default Address"
        '
        'ComboBoxAddressType
        '
        Me.ComboBoxAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAddressType.DropDownWidth = 121
        Me.ComboBoxAddressType.Location = New System.Drawing.Point(172, 18)
        Me.ComboBoxAddressType.Name = "ComboBoxAddressType"
        Me.ComboBoxAddressType.Size = New System.Drawing.Size(251, 21)
        Me.ComboBoxAddressType.TabIndex = 51
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(110, 113)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel2.TabIndex = 50
        Me.KryptonLabel2.Values.Text = "ACTIVE :"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(8, 47)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(158, 20)
        Me.KryptonLabel1.TabIndex = 49
        Me.KryptonLabel1.Values.Text = "ADDRESS  INFORMATION :"
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(67, 19)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel10.TabIndex = 48
        Me.KryptonLabel10.Values.Text = "ADDRESS TYPE :"
        '
        'RbAddressNo
        '
        Me.RbAddressNo.Location = New System.Drawing.Point(220, 113)
        Me.RbAddressNo.Name = "RbAddressNo"
        Me.RbAddressNo.Size = New System.Drawing.Size(41, 20)
        Me.RbAddressNo.TabIndex = 47
        Me.RbAddressNo.Values.Text = "NO"
        '
        'RbAddressYes
        '
        Me.RbAddressYes.Checked = True
        Me.RbAddressYes.Location = New System.Drawing.Point(172, 113)
        Me.RbAddressYes.Name = "RbAddressYes"
        Me.RbAddressYes.Size = New System.Drawing.Size(42, 20)
        Me.RbAddressYes.TabIndex = 46
        Me.RbAddressYes.Values.Text = "YES"
        '
        'txtAddressInformation
        '
        Me.txtAddressInformation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddressInformation.Location = New System.Drawing.Point(172, 45)
        Me.txtAddressInformation.MaxLength = 200
        Me.txtAddressInformation.Multiline = True
        Me.txtAddressInformation.Name = "txtAddressInformation"
        Me.txtAddressInformation.Size = New System.Drawing.Size(251, 62)
        Me.txtAddressInformation.TabIndex = 38
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'NewAddressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 258)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewAddressForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Address"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.ComboBoxAddressType, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents RbAddressNo As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents RbAddressYes As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAddressInformation As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ComboBoxAddressType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkMakeDefault As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class
