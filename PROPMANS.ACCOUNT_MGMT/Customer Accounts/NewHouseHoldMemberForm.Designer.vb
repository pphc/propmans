<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewHouseHoldMemberForm
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
        Me.KryptonGroupBox5 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.txtOccupation = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtHouseHoldName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.MoveInDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.MoveOutDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.ComboBoxRelation = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.BirthDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel20 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel21 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel22 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox5.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox5.Panel.SuspendLayout()
        Me.KryptonGroupBox5.SuspendLayout()
        CType(Me.ComboBoxRelation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox5)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(644, 218)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonGroupBox5
        '
        Me.KryptonGroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox5.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox5.Name = "KryptonGroupBox5"
        '
        'KryptonGroupBox5.Panel
        '
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.txtOccupation)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.txtHouseHoldName)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.MoveInDate)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.MoveOutDate)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel16)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.ComboBoxRelation)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.BirthDate)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel18)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel19)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel20)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel21)
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.KryptonLabel22)
        Me.KryptonGroupBox5.Size = New System.Drawing.Size(634, 171)
        Me.KryptonGroupBox5.TabIndex = 8
        Me.KryptonGroupBox5.Values.Heading = ""
        '
        'txtOccupation
        '
        Me.txtOccupation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOccupation.Location = New System.Drawing.Point(112, 121)
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.Size = New System.Drawing.Size(194, 22)
        Me.txtOccupation.TabIndex = 62
        '
        'txtHouseHoldName
        '
        Me.txtHouseHoldName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHouseHoldName.Location = New System.Drawing.Point(112, 22)
        Me.txtHouseHoldName.Name = "txtHouseHoldName"
        Me.txtHouseHoldName.Size = New System.Drawing.Size(511, 22)
        Me.txtHouseHoldName.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtHouseHoldName.TabIndex = 60
        '
        'MoveInDate
        '
        Me.MoveInDate.CustomNullText = "NOT AVAILABLE"
        Me.MoveInDate.Location = New System.Drawing.Point(429, 88)
        Me.MoveInDate.Name = "MoveInDate"
        Me.MoveInDate.ShowCheckBox = True
        Me.MoveInDate.Size = New System.Drawing.Size(194, 20)
        Me.MoveInDate.TabIndex = 64
        '
        'MoveOutDate
        '
        Me.MoveOutDate.CustomNullText = "NOT AVAILABLE"
        Me.MoveOutDate.Location = New System.Drawing.Point(429, 123)
        Me.MoveOutDate.Name = "MoveOutDate"
        Me.MoveOutDate.ShowCheckBox = True
        Me.MoveOutDate.Size = New System.Drawing.Size(194, 20)
        Me.MoveOutDate.TabIndex = 65
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Location = New System.Drawing.Point(317, 122)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(103, 19)
        Me.KryptonLabel16.TabIndex = 57
        Me.KryptonLabel16.Values.Text = "MOVE OUT DATE :"
        '
        'ComboBoxRelation
        '
        Me.ComboBoxRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRelation.DropDownWidth = 121
        Me.ComboBoxRelation.Items.AddRange(New Object() {"- SELECT -", "Sample 1", "Sample 2", "Sample 3", "Sample 4", "Sample 5"})
        Me.ComboBoxRelation.Location = New System.Drawing.Point(112, 56)
        Me.ComboBoxRelation.Name = "ComboBoxRelation"
        Me.ComboBoxRelation.Size = New System.Drawing.Size(194, 22)
        Me.ComboBoxRelation.TabIndex = 63
        '
        'BirthDate
        '
        Me.BirthDate.CustomNullText = "NOT AVAILABLE"
        Me.BirthDate.Location = New System.Drawing.Point(112, 88)
        Me.BirthDate.Name = "BirthDate"
        Me.BirthDate.ShowCheckBox = True
        Me.BirthDate.Size = New System.Drawing.Size(194, 20)
        Me.BirthDate.TabIndex = 61
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Location = New System.Drawing.Point(328, 88)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(92, 19)
        Me.KryptonLabel18.TabIndex = 54
        Me.KryptonLabel18.Values.Text = "MOVE IN DATE :"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Location = New System.Drawing.Point(36, 56)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Size = New System.Drawing.Size(67, 19)
        Me.KryptonLabel19.TabIndex = 53
        Me.KryptonLabel19.Values.Text = "RELATION :"
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Location = New System.Drawing.Point(18, 122)
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Size = New System.Drawing.Size(86, 19)
        Me.KryptonLabel20.TabIndex = 52
        Me.KryptonLabel20.Values.Text = "OCCUPATION :"
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Location = New System.Drawing.Point(26, 88)
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Size = New System.Drawing.Size(76, 19)
        Me.KryptonLabel21.TabIndex = 51
        Me.KryptonLabel21.Values.Text = "BIRTH DATE :"
        '
        'KryptonLabel22
        '
        Me.KryptonLabel22.Location = New System.Drawing.Point(55, 22)
        Me.KryptonLabel22.Name = "KryptonLabel22"
        Me.KryptonLabel22.Size = New System.Drawing.Size(47, 19)
        Me.KryptonLabel22.TabIndex = 50
        Me.KryptonLabel22.Values.Text = "NAME :"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(493, 182)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 29)
        Me.btnSave.TabIndex = 66
        Me.btnSave.Values.Text = "&SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(568, 182)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 29)
        Me.btnCancel.TabIndex = 67
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'NewHouseHoldMemberForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 218)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewHouseHoldMemberForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW HOUSE HOLD MEMBER"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox5.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox5.Panel.ResumeLayout(False)
        Me.KryptonGroupBox5.Panel.PerformLayout()
        CType(Me.KryptonGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox5.ResumeLayout(False)
        CType(Me.ComboBoxRelation, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonGroupBox5 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtOccupation As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtHouseHoldName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents MoveInDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents MoveOutDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ComboBoxRelation As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents BirthDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel20 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel21 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel22 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
