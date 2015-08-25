<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserManagementForm
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
        Me.tabUserMgmt = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnCreateNewUser = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.pnlUsers = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.dgUsers = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnApplyAccessChanges = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.pnlRoles = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.dgUserRoles = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.pnlSelectedUserRole = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.lblUserID = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.tabUserMgmt.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pnlUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUsers.SuspendLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.pnlRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRoles.SuspendLayout()
        CType(Me.dgUserRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSelectedUserRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectedUserRole.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.tabUserMgmt)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(978, 708)
        Me.KryptonPanel.TabIndex = 0
        '
        'tabUserMgmt
        '
        Me.tabUserMgmt.Controls.Add(Me.TabPage1)
        Me.tabUserMgmt.Controls.Add(Me.TabPage2)
        Me.tabUserMgmt.Location = New System.Drawing.Point(223, 92)
        Me.tabUserMgmt.Name = "tabUserMgmt"
        Me.tabUserMgmt.SelectedIndex = 0
        Me.tabUserMgmt.Size = New System.Drawing.Size(728, 456)
        Me.tabUserMgmt.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCreateNewUser)
        Me.TabPage1.Controls.Add(Me.pnlUsers)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(720, 430)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "USER LIST"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCreateNewUser
        '
        Me.btnCreateNewUser.Location = New System.Drawing.Point(6, 382)
        Me.btnCreateNewUser.Name = "btnCreateNewUser"
        Me.btnCreateNewUser.Size = New System.Drawing.Size(114, 32)
        Me.btnCreateNewUser.TabIndex = 4
        Me.btnCreateNewUser.Values.Text = "CREATE NEW USER"
        '
        'pnlUsers
        '
        Me.pnlUsers.Controls.Add(Me.dgUsers)
        Me.pnlUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUsers.Location = New System.Drawing.Point(3, 3)
        Me.pnlUsers.Name = "pnlUsers"
        Me.pnlUsers.Size = New System.Drawing.Size(714, 373)
        Me.pnlUsers.TabIndex = 3
        '
        'dgUsers
        '
        Me.dgUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUsers.Location = New System.Drawing.Point(0, 0)
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.Size = New System.Drawing.Size(714, 373)
        Me.dgUsers.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnApplyAccessChanges)
        Me.TabPage2.Controls.Add(Me.pnlRoles)
        Me.TabPage2.Controls.Add(Me.pnlSelectedUserRole)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(720, 430)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "USER ACCESS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnApplyAccessChanges
        '
        Me.btnApplyAccessChanges.Location = New System.Drawing.Point(574, 390)
        Me.btnApplyAccessChanges.Name = "btnApplyAccessChanges"
        Me.btnApplyAccessChanges.Size = New System.Drawing.Size(140, 34)
        Me.btnApplyAccessChanges.TabIndex = 3
        Me.btnApplyAccessChanges.Values.Text = "APPLY CHANGES"
        '
        'pnlRoles
        '
        Me.pnlRoles.Controls.Add(Me.dgUserRoles)
        Me.pnlRoles.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRoles.Location = New System.Drawing.Point(3, 49)
        Me.pnlRoles.Name = "pnlRoles"
        Me.pnlRoles.Size = New System.Drawing.Size(714, 335)
        Me.pnlRoles.TabIndex = 2
        '
        'dgUserRoles
        '
        Me.dgUserRoles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUserRoles.Location = New System.Drawing.Point(0, 0)
        Me.dgUserRoles.Name = "dgUserRoles"
        Me.dgUserRoles.Size = New System.Drawing.Size(714, 335)
        Me.dgUserRoles.TabIndex = 1
        '
        'pnlSelectedUserRole
        '
        Me.pnlSelectedUserRole.Controls.Add(Me.lblUserID)
        Me.pnlSelectedUserRole.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSelectedUserRole.Location = New System.Drawing.Point(3, 3)
        Me.pnlSelectedUserRole.Name = "pnlSelectedUserRole"
        Me.pnlSelectedUserRole.Size = New System.Drawing.Size(714, 46)
        Me.pnlSelectedUserRole.TabIndex = 1
        '
        'lblUserID
        '
        Me.lblUserID.Location = New System.Drawing.Point(15, 11)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(62, 18)
        Me.lblUserID.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Values.Text = "USER ID"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'UserManagementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 708)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserManagementForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USER MANAGEMENT"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.tabUserMgmt.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.pnlUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUsers.ResumeLayout(False)
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.pnlRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRoles.ResumeLayout(False)
        CType(Me.dgUserRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSelectedUserRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectedUserRole.ResumeLayout(False)
        Me.pnlSelectedUserRole.PerformLayout()
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
    Friend WithEvents tabUserMgmt As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnApplyAccessChanges As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlRoles As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents pnlSelectedUserRole As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents pnlUsers As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCreateNewUser As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblUserID As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dgUserRoles As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents dgUsers As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
End Class
