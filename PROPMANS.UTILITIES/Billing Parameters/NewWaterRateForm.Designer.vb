<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewWaterRateForm
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
        Me.lblEffectiveMonth = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboRateClass = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.dgConsumptionBlocks = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.RateGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.txtMinimumCharge = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtMinimumConsumption = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.chkAndAbove = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkCharge = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRateClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dgConsumptionBlocks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RateGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RateGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RateGroupBox.Panel.SuspendLayout()
        Me.RateGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.RateGroupBox)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone
        Me.KryptonPanel.Size = New System.Drawing.Size(407, 539)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblEffectiveMonth
        '
        Me.lblEffectiveMonth.Location = New System.Drawing.Point(123, 24)
        Me.lblEffectiveMonth.Name = "lblEffectiveMonth"
        Me.lblEffectiveMonth.Size = New System.Drawing.Size(74, 16)
        Me.lblEffectiveMonth.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveMonth.TabIndex = 55
        Me.lblEffectiveMonth.Values.Text = "Month, Year"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(8, 21)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(119, 19)
        Me.KryptonLabel6.TabIndex = 53
        Me.KryptonLabel6.Values.Text = "COVERED MONTH(S):"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(260, 489)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 38)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Values.Text = "SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(334, 489)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 38)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboRateClass
        '
        Me.cboRateClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRateClass.DropDownWidth = 232
        Me.cboRateClass.Location = New System.Drawing.Point(126, 43)
        Me.cboRateClass.Name = "cboRateClass"
        Me.cboRateClass.Size = New System.Drawing.Size(232, 22)
        Me.cboRateClass.TabIndex = 84
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(54, 46)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel1.TabIndex = 85
        Me.KryptonLabel1.Values.Text = "RATE CLASS:"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.lblEffectiveMonth)
        Me.KryptonPanel1.Controls.Add(Me.cboRateClass)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(407, 78)
        Me.KryptonPanel1.TabIndex = 86
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dgConsumptionBlocks)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 78)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel2.Size = New System.Drawing.Size(407, 208)
        Me.KryptonPanel2.TabIndex = 87
        '
        'dgConsumptionBlocks
        '
        Me.dgConsumptionBlocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConsumptionBlocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConsumptionBlocks.Location = New System.Drawing.Point(5, 5)
        Me.dgConsumptionBlocks.Name = "dgConsumptionBlocks"
        Me.dgConsumptionBlocks.Size = New System.Drawing.Size(397, 198)
        Me.dgConsumptionBlocks.TabIndex = 1
        '
        'RateGroupBox
        '
        Me.RateGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.RateGroupBox.Location = New System.Drawing.Point(0, 286)
        Me.RateGroupBox.Name = "RateGroupBox"
        '
        'RateGroupBox.Panel
        '
        Me.RateGroupBox.Panel.Controls.Add(Me.chkCharge)
        Me.RateGroupBox.Panel.Controls.Add(Me.chkAndAbove)
        Me.RateGroupBox.Panel.Controls.Add(Me.KryptonTextBox1)
        Me.RateGroupBox.Panel.Controls.Add(Me.KryptonLabel4)
        Me.RateGroupBox.Panel.Controls.Add(Me.txtMinimumCharge)
        Me.RateGroupBox.Panel.Controls.Add(Me.KryptonLabel3)
        Me.RateGroupBox.Panel.Controls.Add(Me.txtMinimumConsumption)
        Me.RateGroupBox.Panel.Controls.Add(Me.KryptonLabel2)
        Me.RateGroupBox.Size = New System.Drawing.Size(407, 185)
        Me.RateGroupBox.TabIndex = 88
        Me.RateGroupBox.Text = "CONSUMPTION RATE"
        Me.RateGroupBox.Values.Heading = "CONSUMPTION RATE"
        '
        'txtMinimumCharge
        '
        Me.txtMinimumCharge.Location = New System.Drawing.Point(60, 41)
        Me.txtMinimumCharge.MaxLength = 10
        Me.txtMinimumCharge.Name = "txtMinimumCharge"
        Me.txtMinimumCharge.Size = New System.Drawing.Size(219, 22)
        Me.txtMinimumCharge.TabIndex = 82
        Me.txtMinimumCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(16, 72)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(38, 19)
        Me.KryptonLabel3.TabIndex = 81
        Me.KryptonLabel3.Values.Text = "RATE:"
        '
        'txtMinimumConsumption
        '
        Me.txtMinimumConsumption.Location = New System.Drawing.Point(60, 13)
        Me.txtMinimumConsumption.MaxLength = 10
        Me.txtMinimumConsumption.Name = "txtMinimumConsumption"
        Me.txtMinimumConsumption.Size = New System.Drawing.Size(219, 22)
        Me.txtMinimumConsumption.TabIndex = 79
        Me.txtMinimumConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(10, 16)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(44, 19)
        Me.KryptonLabel2.TabIndex = 80
        Me.KryptonLabel2.Values.Text = "FROM:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(27, 44)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(27, 19)
        Me.KryptonLabel4.TabIndex = 83
        Me.KryptonLabel4.Values.Text = "TO:"
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(60, 69)
        Me.KryptonTextBox1.MaxLength = 10
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(219, 22)
        Me.KryptonTextBox1.TabIndex = 84
        Me.KryptonTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkAndAbove
        '
        Me.chkAndAbove.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkAndAbove.Location = New System.Drawing.Point(285, 44)
        Me.chkAndAbove.Name = "chkAndAbove"
        Me.chkAndAbove.Size = New System.Drawing.Size(85, 19)
        Me.chkAndAbove.TabIndex = 85
        Me.chkAndAbove.Text = "AND ABOVE"
        Me.chkAndAbove.Values.Text = "AND ABOVE"
        '
        'chkCharge
        '
        Me.chkCharge.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkCharge.Location = New System.Drawing.Point(60, 97)
        Me.chkCharge.Name = "chkCharge"
        Me.chkCharge.Size = New System.Drawing.Size(183, 19)
        Me.chkCharge.TabIndex = 86
        Me.chkCharge.Text = "THIS IS THE MINIMUM CHARGE"
        Me.chkCharge.Values.Text = "THIS IS THE MINIMUM CHARGE"
        '
        'NewWaterRateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 539)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "NewWaterRateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW WATER RATE"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRateClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.dgConsumptionBlocks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RateGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RateGroupBox.Panel.ResumeLayout(False)
        Me.RateGroupBox.Panel.PerformLayout()
        CType(Me.RateGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RateGroupBox.ResumeLayout(False)
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
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboRateClass As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents dgConsumptionBlocks As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents RateGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents chkCharge As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkAndAbove As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMinimumCharge As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMinimumConsumption As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
