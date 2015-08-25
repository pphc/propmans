<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewContact
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
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.ComboBoxContactSubType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.RbContactNo = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.RbContactYes = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.ComboBoxContactType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.txtContact = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.ComboBoxContactSubType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxContactType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(450, 237)
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(376, 203)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 29)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(300, 203)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 29)
        Me.btnSave.TabIndex = 44
        Me.btnSave.Values.Text = "&SAVE"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.ComboBoxContactSubType)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.RbContactNo)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.RbContactYes)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.ComboBoxContactType)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.txtContact)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(440, 185)
        Me.KryptonGroupBox2.TabIndex = 43
        Me.KryptonGroupBox2.Text = "CONTACT INFORMATION"
        Me.KryptonGroupBox2.Values.Heading = "CONTACT INFORMATION"
        '
        'ComboBoxContactSubType
        '
        Me.ComboBoxContactSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxContactSubType.DropDownWidth = 121
        Me.ComboBoxContactSubType.Location = New System.Drawing.Point(167, 47)
        Me.ComboBoxContactSubType.Name = "ComboBoxContactSubType"
        Me.ComboBoxContactSubType.Size = New System.Drawing.Size(194, 21)
        Me.ComboBoxContactSubType.TabIndex = 45
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(101, 107)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel6.TabIndex = 54
        Me.KryptonLabel6.Values.Text = "ACTIVE :"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(5, 78)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(157, 20)
        Me.KryptonLabel3.TabIndex = 53
        Me.KryptonLabel3.Values.Text = "CONTACT INFORMATION :"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(27, 48)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(134, 20)
        Me.KryptonLabel4.TabIndex = 52
        Me.KryptonLabel4.Values.Text = "CONTACT LOCATION :"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(56, 20)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel5.TabIndex = 51
        Me.KryptonLabel5.Values.Text = "CONTACT TYPE :"
        '
        'RbContactNo
        '
        Me.RbContactNo.Location = New System.Drawing.Point(213, 107)
        Me.RbContactNo.Name = "RbContactNo"
        Me.RbContactNo.Size = New System.Drawing.Size(41, 20)
        Me.RbContactNo.TabIndex = 45
        Me.RbContactNo.Values.Text = "NO"
        '
        'RbContactYes
        '
        Me.RbContactYes.Checked = True
        Me.RbContactYes.Location = New System.Drawing.Point(167, 107)
        Me.RbContactYes.Name = "RbContactYes"
        Me.RbContactYes.Size = New System.Drawing.Size(42, 20)
        Me.RbContactYes.TabIndex = 44
        Me.RbContactYes.Values.Text = "YES"
        '
        'ComboBoxContactType
        '
        Me.ComboBoxContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxContactType.DropDownWidth = 121
        Me.ComboBoxContactType.Location = New System.Drawing.Point(167, 18)
        Me.ComboBoxContactType.Name = "ComboBoxContactType"
        Me.ComboBoxContactType.Size = New System.Drawing.Size(194, 21)
        Me.ComboBoxContactType.TabIndex = 43
        '
        'txtContact
        '
        Me.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContact.Location = New System.Drawing.Point(167, 76)
        Me.txtContact.MaxLength = 200
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(194, 20)
        Me.txtContact.TabIndex = 41
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'NewContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 237)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewContact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Contact"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        Me.KryptonGroupBox2.Panel.PerformLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.ComboBoxContactSubType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxContactType, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents RbContactNo As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents RbContactYes As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents ComboBoxContactType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtContact As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ComboBoxContactSubType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
