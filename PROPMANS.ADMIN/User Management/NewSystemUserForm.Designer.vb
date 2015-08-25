<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewSystemUserForm
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
        Me.btnChangePassword = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.cboCompany = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.cboUserGroup = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.txtUserPassword = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtUserPosition = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtUserFullName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtUserID = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.chkActivateUser = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.cboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUserGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnChangePassword)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel.Controls.Add(Me.cboCompany)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOk)
        Me.KryptonPanel.Controls.Add(Me.cboUserGroup)
        Me.KryptonPanel.Controls.Add(Me.txtUserPassword)
        Me.KryptonPanel.Controls.Add(Me.txtUserPosition)
        Me.KryptonPanel.Controls.Add(Me.txtUserFullName)
        Me.KryptonPanel.Controls.Add(Me.txtUserID)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.chkActivateUser)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(348, 329)
        Me.KryptonPanel.TabIndex = 0
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(121, 126)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(211, 25)
        Me.btnChangePassword.TabIndex = 10
        Me.btnChangePassword.Values.Text = "CHANGE PASSWORD"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(55, 157)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(60, 19)
        Me.KryptonLabel6.TabIndex = 9
        Me.KryptonLabel6.Values.Text = "DIVISION:"
        '
        'cboCompany
        '
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.DropDownWidth = 211
        Me.cboCompany.Location = New System.Drawing.Point(121, 154)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(211, 22)
        Me.cboCompany.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(260, 286)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 31)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(184, 286)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 31)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Values.Text = "OK"
        '
        'cboUserGroup
        '
        Me.cboUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserGroup.DropDownWidth = 211
        Me.cboUserGroup.Location = New System.Drawing.Point(121, 182)
        Me.cboUserGroup.Name = "cboUserGroup"
        Me.cboUserGroup.Size = New System.Drawing.Size(211, 22)
        Me.cboUserGroup.TabIndex = 4
        '
        'txtUserPassword
        '
        Me.txtUserPassword.Location = New System.Drawing.Point(121, 126)
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUserPassword.Size = New System.Drawing.Size(211, 22)
        Me.txtUserPassword.TabIndex = 3
        '
        'txtUserPosition
        '
        Me.txtUserPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserPosition.Location = New System.Drawing.Point(121, 98)
        Me.txtUserPosition.Name = "txtUserPosition"
        Me.txtUserPosition.Size = New System.Drawing.Size(211, 22)
        Me.txtUserPosition.TabIndex = 2
        '
        'txtUserFullName
        '
        Me.txtUserFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserFullName.Location = New System.Drawing.Point(121, 70)
        Me.txtUserFullName.Name = "txtUserFullName"
        Me.txtUserFullName.Size = New System.Drawing.Size(211, 22)
        Me.txtUserFullName.TabIndex = 1
        '
        'txtUserID
        '
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(121, 42)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(211, 22)
        Me.txtUserID.TabIndex = 0
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(36, 185)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(79, 19)
        Me.KryptonLabel5.TabIndex = 5
        Me.KryptonLabel5.Values.Text = "USER GROUP:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(23, 101)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(92, 19)
        Me.KryptonLabel4.TabIndex = 4
        Me.KryptonLabel4.Values.Text = "USER POSITION:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(14, 73)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(101, 19)
        Me.KryptonLabel3.TabIndex = 3
        Me.KryptonLabel3.Values.Text = "USER FULL NAME:"
        '
        'chkActivateUser
        '
        Me.chkActivateUser.Location = New System.Drawing.Point(121, 233)
        Me.chkActivateUser.Name = "chkActivateUser"
        Me.chkActivateUser.Size = New System.Drawing.Size(102, 19)
        Me.chkActivateUser.TabIndex = 5
        Me.chkActivateUser.Values.Text = "ACTIVATE USER"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(43, 129)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(72, 19)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "PASSWORD:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(62, 45)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(53, 19)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "USER ID:"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewSystemUserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 329)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewSystemUserForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New System User"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.cboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUserGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents txtUserPassword As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtUserPosition As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtUserFullName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtUserID As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkActivateUser As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboUserGroup As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCompany As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnChangePassword As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
