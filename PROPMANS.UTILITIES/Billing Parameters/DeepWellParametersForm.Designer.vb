<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeepWellParameterForm
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
        Me.txtFlatRateSetting = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtFlatRateCost = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.txtWaterRate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblApplicableMonth = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblPrompt = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.lblPrompt)
        Me.KryptonPanel.Controls.Add(Me.txtFlatRateSetting)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.txtFlatRateCost)
        Me.KryptonPanel.Controls.Add(Me.txtWaterRate)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel.Controls.Add(Me.lblApplicableMonth)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(290, 236)
        Me.KryptonPanel.TabIndex = 0
        '
        'txtFlatRateSetting
        '
        Me.txtFlatRateSetting.Location = New System.Drawing.Point(133, 80)
        Me.txtFlatRateSetting.Name = "txtFlatRateSetting"
        Me.txtFlatRateSetting.Size = New System.Drawing.Size(123, 22)
        Me.txtFlatRateSetting.TabIndex = 1
        Me.txtFlatRateSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(15, 83)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(112, 19)
        Me.KryptonLabel2.TabIndex = 66
        Me.KryptonLabel2.Values.Text = "FLAT RATE SETTING:"
        '
        'txtFlatRateCost
        '
        Me.txtFlatRateCost.Location = New System.Drawing.Point(133, 108)
        Me.txtFlatRateCost.Name = "txtFlatRateCost"
        Me.txtFlatRateCost.Size = New System.Drawing.Size(123, 22)
        Me.txtFlatRateCost.TabIndex = 2
        Me.txtFlatRateCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWaterRate
        '
        Me.txtWaterRate.Location = New System.Drawing.Point(133, 52)
        Me.txtWaterRate.Name = "txtWaterRate"
        Me.txtWaterRate.Size = New System.Drawing.Size(123, 22)
        Me.txtWaterRate.TabIndex = 0
        Me.txtWaterRate.Tag = " "
        Me.txtWaterRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(31, 111)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(96, 19)
        Me.KryptonLabel7.TabIndex = 56
        Me.KryptonLabel7.Values.Text = "FLAT RATE COST:"
        '
        'lblApplicableMonth
        '
        Me.lblApplicableMonth.Location = New System.Drawing.Point(114, 12)
        Me.lblApplicableMonth.Name = "lblApplicableMonth"
        Me.lblApplicableMonth.Size = New System.Drawing.Size(74, 16)
        Me.lblApplicableMonth.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicableMonth.TabIndex = 55
        Me.lblApplicableMonth.Values.Text = "Month, Year"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(49, 55)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(78, 19)
        Me.KryptonLabel5.TabIndex = 54
        Me.KryptonLabel5.Values.Text = "WATER RATE:"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(12, 12)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(96, 19)
        Me.KryptonLabel6.TabIndex = 53
        Me.KryptonLabel6.Values.Text = "BILLING MONTH:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(94, 158)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 30)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Values.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(188, 158)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Text = "Cancel"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblPrompt
        '
        Me.lblPrompt.Location = New System.Drawing.Point(15, 194)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(270, 19)
        Me.lblPrompt.TabIndex = 67
        Me.lblPrompt.Values.Text = "Cannot Update. Bill Parameter is already referenced."
        Me.lblPrompt.Visible = False
        '
        'DeepWellParameterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DeepWellParameterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WATER BILL PARAMETER SETTING"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents txtFlatRateCost As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtWaterRate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblApplicableMonth As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtFlatRateSetting As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblPrompt As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
