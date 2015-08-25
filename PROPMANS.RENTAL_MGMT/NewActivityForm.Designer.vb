<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewActivityForm
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
        Me.ActivitiesInformationGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dtpActivityDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.cboActivityType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.KryptonLabel22 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel21 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel20 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.ActivitiesInformationGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivitiesInformationGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActivitiesInformationGroupBox.Panel.SuspendLayout()
        Me.ActivitiesInformationGroupBox.SuspendLayout()
        CType(Me.cboActivityType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.ActivitiesInformationGroupBox)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Margin = New System.Windows.Forms.Padding(25)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(528, 290)
        Me.KryptonPanel.TabIndex = 0
        '
        'ActivitiesInformationGroupBox
        '
        Me.ActivitiesInformationGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.ActivitiesInformationGroupBox.Location = New System.Drawing.Point(5, 5)
        Me.ActivitiesInformationGroupBox.Name = "ActivitiesInformationGroupBox"
        '
        'ActivitiesInformationGroupBox.Panel
        '
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.dtpActivityDate)
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.cboActivityType)
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.KryptonLabel22)
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.KryptonLabel21)
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.KryptonLabel20)
        Me.ActivitiesInformationGroupBox.Panel.Controls.Add(Me.txtNotes)
        Me.ActivitiesInformationGroupBox.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.ActivitiesInformationGroupBox.Size = New System.Drawing.Size(518, 232)
        Me.ActivitiesInformationGroupBox.TabIndex = 47
        Me.ActivitiesInformationGroupBox.Text = "ACTIVITY INFORMATION"
        Me.ActivitiesInformationGroupBox.Values.Heading = "ACTIVITY INFORMATION"
        '
        'dtpActivityDate
        '
        Me.dtpActivityDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpActivityDate.Location = New System.Drawing.Point(101, 9)
        Me.dtpActivityDate.Name = "dtpActivityDate"
        Me.dtpActivityDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpActivityDate.TabIndex = 19
        '
        'cboActivityType
        '
        Me.cboActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivityType.DropDownWidth = 121
        Me.cboActivityType.Location = New System.Drawing.Point(101, 40)
        Me.cboActivityType.Name = "cboActivityType"
        Me.cboActivityType.Size = New System.Drawing.Size(175, 22)
        Me.cboActivityType.TabIndex = 20
        '
        'KryptonLabel22
        '
        Me.KryptonLabel22.Location = New System.Drawing.Point(43, 72)
        Me.KryptonLabel22.Name = "KryptonLabel22"
        Me.KryptonLabel22.Size = New System.Drawing.Size(50, 19)
        Me.KryptonLabel22.TabIndex = 14
        Me.KryptonLabel22.Values.Text = "NOTES :"
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Location = New System.Drawing.Point(6, 42)
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Size = New System.Drawing.Size(89, 19)
        Me.KryptonLabel21.TabIndex = 13
        Me.KryptonLabel21.Values.Text = "ACTIVITY TYPE :"
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Location = New System.Drawing.Point(52, 10)
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Size = New System.Drawing.Size(43, 19)
        Me.KryptonLabel20.TabIndex = 10
        Me.KryptonLabel20.Values.Text = "DATE :"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(99, 71)
        Me.txtNotes.MaxLength = 100
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(396, 65)
        Me.txtNotes.TabIndex = 21
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(447, 242)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 36)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Values.Text = "&CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(365, 242)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 36)
        Me.btnSave.TabIndex = 44
        Me.btnSave.Values.Text = "&SAVE"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'NewActivityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 290)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewActivityForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Activity"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.ActivitiesInformationGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActivitiesInformationGroupBox.Panel.ResumeLayout(False)
        Me.ActivitiesInformationGroupBox.Panel.PerformLayout()
        CType(Me.ActivitiesInformationGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActivitiesInformationGroupBox.ResumeLayout(False)
        CType(Me.cboActivityType, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ActivitiesInformationGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dtpActivityDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents cboActivityType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel22 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel21 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel20 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
End Class
