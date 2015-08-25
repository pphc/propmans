<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewORSeriesForm
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
        Me.lblDivisionOR = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.dtpDateReceived = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.txtRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtEndingOR = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtStartOR = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.lblDivisionOR)
        Me.KryptonPanel.Controls.Add(Me.dtpDateReceived)
        Me.KryptonPanel.Controls.Add(Me.txtRemarks)
        Me.KryptonPanel.Controls.Add(Me.txtEndingOR)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.txtStartOR)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOk)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(302, 298)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblDivisionOR
        '
        Me.lblDivisionOR.Location = New System.Drawing.Point(12, 12)
        Me.lblDivisionOR.Name = "lblDivisionOR"
        Me.lblDivisionOR.Size = New System.Drawing.Size(74, 19)
        Me.lblDivisionOR.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivisionOR.TabIndex = 11
        Me.lblDivisionOR.Values.Text = "PPHC OR"
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateReceived.Location = New System.Drawing.Point(137, 123)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(153, 20)
        Me.dtpDateReceived.TabIndex = 2
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(137, 158)
        Me.txtRemarks.MaxLength = 50
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(153, 60)
        Me.txtRemarks.TabIndex = 3
        '
        'txtEndingOR
        '
        Me.txtEndingOR.Location = New System.Drawing.Point(137, 85)
        Me.txtEndingOR.MaxLength = 6
        Me.txtEndingOR.Name = "txtEndingOR"
        Me.txtEndingOR.Size = New System.Drawing.Size(153, 22)
        Me.txtEndingOR.TabIndex = 1
        Me.txtEndingOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(69, 158)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(62, 19)
        Me.KryptonLabel4.TabIndex = 6
        Me.KryptonLabel4.Values.Text = "REMARKS:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(39, 123)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(92, 19)
        Me.KryptonLabel3.TabIndex = 5
        Me.KryptonLabel3.Values.Text = "DATE RECEIVED:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(52, 88)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(79, 19)
        Me.KryptonLabel2.TabIndex = 4
        Me.KryptonLabel2.Values.Text = "ENDING OR#:"
        '
        'txtStartOR
        '
        Me.txtStartOR.Location = New System.Drawing.Point(137, 50)
        Me.txtStartOR.MaxLength = 6
        Me.txtStartOR.Name = "txtStartOR"
        Me.txtStartOR.Size = New System.Drawing.Size(153, 22)
        Me.txtStartOR.TabIndex = 0
        Me.txtStartOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(42, 53)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(89, 19)
        Me.KryptonLabel1.TabIndex = 2
        Me.KryptonLabel1.Values.Text = "STARTING OR#:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(220, 247)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 37)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(137, 247)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 37)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Values.Text = "SAVE"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'NewORSeriesForm
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 298)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewORSeriesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New OR Series"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
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
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtStartOR As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtEndingOR As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dtpDateReceived As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents lblDivisionOR As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
