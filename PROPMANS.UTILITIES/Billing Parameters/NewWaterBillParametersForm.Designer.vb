<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewWaterBillParametersForm
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
        Me.dtpEffectiveOn = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.StandardPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtMinimumConsumption = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtMinimumCost = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtRate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chkWithConsumptionBlock = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.dtpEfffectiveUntil = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblEffectiveMonth = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.StandardPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StandardPanel.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.dtpEffectiveOn)
        Me.KryptonPanel.Controls.Add(Me.StandardPanel)
        Me.KryptonPanel.Controls.Add(Me.chkWithConsumptionBlock)
        Me.KryptonPanel.Controls.Add(Me.dtpEfffectiveUntil)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.lblEffectiveMonth)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone
        Me.KryptonPanel.Size = New System.Drawing.Size(295, 286)
        Me.KryptonPanel.TabIndex = 0
        '
        'dtpEffectiveOn
        '
        Me.dtpEffectiveOn.Checked = False
        Me.dtpEffectiveOn.CustomFormat = "MMMM yyyy"
        Me.dtpEffectiveOn.CustomNullText = "NOT APPLICABLE"
        Me.dtpEffectiveOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffectiveOn.Location = New System.Drawing.Point(121, 23)
        Me.dtpEffectiveOn.Name = "dtpEffectiveOn"
        Me.dtpEffectiveOn.ShowCheckBox = True
        Me.dtpEffectiveOn.Size = New System.Drawing.Size(164, 21)
        Me.dtpEffectiveOn.TabIndex = 84
        Me.dtpEffectiveOn.Visible = False
        '
        'StandardPanel
        '
        Me.StandardPanel.Controls.Add(Me.txtMinimumConsumption)
        Me.StandardPanel.Controls.Add(Me.KryptonLabel2)
        Me.StandardPanel.Controls.Add(Me.txtMinimumCost)
        Me.StandardPanel.Controls.Add(Me.txtRate)
        Me.StandardPanel.Controls.Add(Me.KryptonLabel7)
        Me.StandardPanel.Controls.Add(Me.KryptonLabel5)
        Me.StandardPanel.Location = New System.Drawing.Point(0, 111)
        Me.StandardPanel.Name = "StandardPanel"
        Me.StandardPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone
        Me.StandardPanel.Size = New System.Drawing.Size(293, 100)
        Me.StandardPanel.TabIndex = 83
        '
        'txtMinimumConsumption
        '
        Me.txtMinimumConsumption.Location = New System.Drawing.Point(158, 11)
        Me.txtMinimumConsumption.MaxLength = 10
        Me.txtMinimumConsumption.Name = "txtMinimumConsumption"
        Me.txtMinimumConsumption.Size = New System.Drawing.Size(123, 20)
        Me.txtMinimumConsumption.TabIndex = 68
        Me.txtMinimumConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(6, 14)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(162, 20)
        Me.KryptonLabel2.TabIndex = 72
        Me.KryptonLabel2.Values.Text = "MINIMUM CONSUMPTION:"
        '
        'txtMinimumCost
        '
        Me.txtMinimumCost.Location = New System.Drawing.Point(158, 39)
        Me.txtMinimumCost.MaxLength = 10
        Me.txtMinimumCost.Name = "txtMinimumCost"
        Me.txtMinimumCost.Size = New System.Drawing.Size(123, 20)
        Me.txtMinimumCost.TabIndex = 69
        Me.txtMinimumCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(158, 67)
        Me.txtRate.MaxLength = 10
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(123, 20)
        Me.txtRate.TabIndex = 67
        Me.txtRate.Tag = " "
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(41, 42)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(121, 20)
        Me.KryptonLabel7.TabIndex = 71
        Me.KryptonLabel7.Values.Text = "MINIMUM CHARGE:"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(58, 70)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel5.TabIndex = 70
        Me.KryptonLabel5.Values.Text = "RATE PER CU.M.:"
        '
        'chkWithConsumptionBlock
        '
        Me.chkWithConsumptionBlock.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkWithConsumptionBlock.Location = New System.Drawing.Point(31, 86)
        Me.chkWithConsumptionBlock.Name = "chkWithConsumptionBlock"
        Me.chkWithConsumptionBlock.Size = New System.Drawing.Size(228, 20)
        Me.chkWithConsumptionBlock.TabIndex = 82
        Me.chkWithConsumptionBlock.Text = "WITH WATER CONSUMPTION BLOCK"
        Me.chkWithConsumptionBlock.Values.Text = "WITH WATER CONSUMPTION BLOCK"
        '
        'dtpEfffectiveUntil
        '
        Me.dtpEfffectiveUntil.Checked = False
        Me.dtpEfffectiveUntil.CustomFormat = "MMMM yyyy"
        Me.dtpEfffectiveUntil.CustomNullText = "NOT APPLICABLE"
        Me.dtpEfffectiveUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEfffectiveUntil.Location = New System.Drawing.Point(121, 50)
        Me.dtpEfffectiveUntil.Name = "dtpEfffectiveUntil"
        Me.dtpEfffectiveUntil.ShowCheckBox = True
        Me.dtpEfffectiveUntil.Size = New System.Drawing.Size(164, 21)
        Me.dtpEfffectiveUntil.TabIndex = 68
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(17, 51)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel1.TabIndex = 67
        Me.KryptonLabel1.Values.Text = "EFFECTIVE UNTIL:"
        '
        'lblEffectiveMonth
        '
        Me.lblEffectiveMonth.Location = New System.Drawing.Point(121, 28)
        Me.lblEffectiveMonth.Name = "lblEffectiveMonth"
        Me.lblEffectiveMonth.Size = New System.Drawing.Size(74, 16)
        Me.lblEffectiveMonth.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveMonth.TabIndex = 55
        Me.lblEffectiveMonth.Values.Text = "Month, Year"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(31, 26)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel6.TabIndex = 53
        Me.KryptonLabel6.Values.Text = "EFFECTIVE ON:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(143, 231)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 38)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Values.Text = "SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(217, 231)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 38)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewWaterBillParametersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "NewWaterBillParametersForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW WATER BILL PARAMETERS"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.StandardPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StandardPanel.ResumeLayout(False)
        Me.StandardPanel.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents lblEffectiveMonth As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dtpEfffectiveUntil As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkWithConsumptionBlock As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents StandardPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtMinimumConsumption As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMinimumCost As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtRate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpEffectiveOn As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
End Class
