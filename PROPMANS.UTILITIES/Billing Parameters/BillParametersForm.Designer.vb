<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillParametersForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TopPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.WaterConsumptionBlockKryptonGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgConsumptionBlocks = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboRateClass = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnUpdateRates = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNewRates = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkWithConsumptionBlock = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.btnUpdateParameter = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtMinimumCharge = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtMinimumConsumption = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnNewParameter = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtRate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ParameterListGroupbox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dgBillParameterRates = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonContextMenuItems2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.TopPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.WaterConsumptionBlockKryptonGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaterConsumptionBlockKryptonGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.SuspendLayout()
        Me.WaterConsumptionBlockKryptonGroupBox.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.dgConsumptionBlocks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboRateClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.ParameterListGroupbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParameterListGroupbox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ParameterListGroupbox.Panel.SuspendLayout()
        Me.ParameterListGroupbox.SuspendLayout()
        CType(Me.dgBillParameterRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.TopPanel)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(980, 739)
        Me.KryptonPanel.TabIndex = 0
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.KryptonPanel2)
        Me.TopPanel.Controls.Add(Me.ParameterListGroupbox)
        Me.TopPanel.Controls.Add(Me.KryptonPanel1)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(5, 44)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.TopPanel.Size = New System.Drawing.Size(970, 692)
        Me.TopPanel.TabIndex = 28
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.WaterConsumptionBlockKryptonGroupBox)
        Me.KryptonPanel2.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(10, 291)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel2.Size = New System.Drawing.Size(950, 329)
        Me.KryptonPanel2.TabIndex = 40
        '
        'WaterConsumptionBlockKryptonGroupBox
        '
        Me.WaterConsumptionBlockKryptonGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WaterConsumptionBlockKryptonGroupBox.Location = New System.Drawing.Point(418, 5)
        Me.WaterConsumptionBlockKryptonGroupBox.Name = "WaterConsumptionBlockKryptonGroupBox"
        '
        'WaterConsumptionBlockKryptonGroupBox.Panel
        '
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.Controls.Add(Me.KryptonPanel4)
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.Controls.Add(Me.KryptonPanel3)
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.Controls.Add(Me.btnUpdateRates)
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.Controls.Add(Me.btnNewRates)
        Me.WaterConsumptionBlockKryptonGroupBox.Size = New System.Drawing.Size(527, 319)
        Me.WaterConsumptionBlockKryptonGroupBox.TabIndex = 40
        Me.WaterConsumptionBlockKryptonGroupBox.Text = "WATER CONSUMPTION TABLE"
        Me.WaterConsumptionBlockKryptonGroupBox.Values.Heading = "WATER CONSUMPTION TABLE"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.dgConsumptionBlocks)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 44)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel4.Size = New System.Drawing.Size(523, 174)
        Me.KryptonPanel4.TabIndex = 83
        '
        'dgConsumptionBlocks
        '
        Me.dgConsumptionBlocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConsumptionBlocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConsumptionBlocks.Location = New System.Drawing.Point(5, 5)
        Me.dgConsumptionBlocks.Name = "dgConsumptionBlocks"
        Me.dgConsumptionBlocks.Size = New System.Drawing.Size(513, 164)
        Me.dgConsumptionBlocks.TabIndex = 0
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.cboRateClass)
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(523, 44)
        Me.KryptonPanel3.TabIndex = 82
        '
        'cboRateClass
        '
        Me.cboRateClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRateClass.DropDownWidth = 232
        Me.cboRateClass.Location = New System.Drawing.Point(94, 14)
        Me.cboRateClass.Name = "cboRateClass"
        Me.cboRateClass.Size = New System.Drawing.Size(232, 21)
        Me.cboRateClass.TabIndex = 83
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(15, 17)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(79, 20)
        Me.KryptonLabel7.TabIndex = 82
        Me.KryptonLabel7.Values.Text = "RATE CLASS:"
        '
        'btnUpdateRates
        '
        Me.btnUpdateRates.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUpdateRates.Location = New System.Drawing.Point(389, 234)
        Me.btnUpdateRates.Name = "btnUpdateRates"
        Me.btnUpdateRates.Size = New System.Drawing.Size(115, 43)
        Me.btnUpdateRates.TabIndex = 80
        Me.btnUpdateRates.Values.Text = "UPDATE"
        Me.btnUpdateRates.Visible = False
        '
        'btnNewRates
        '
        Me.btnNewRates.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNewRates.Location = New System.Drawing.Point(15, 234)
        Me.btnNewRates.Name = "btnNewRates"
        Me.btnNewRates.Size = New System.Drawing.Size(115, 43)
        Me.btnNewRates.TabIndex = 38
        Me.btnNewRates.Values.Text = "NEW RATE"
        Me.btnNewRates.Visible = False
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkWithConsumptionBlock)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnUpdateParameter)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblBillingMonth)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMinimumCharge)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMinimumConsumption)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnNewParameter)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(413, 319)
        Me.KryptonGroupBox1.TabIndex = 39
        Me.KryptonGroupBox1.Text = "BILL PARAMETER INFORMATION"
        Me.KryptonGroupBox1.Values.Heading = "BILL PARAMETER INFORMATION"
        '
        'chkWithConsumptionBlock
        '
        Me.chkWithConsumptionBlock.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkWithConsumptionBlock.Location = New System.Drawing.Point(166, 161)
        Me.chkWithConsumptionBlock.Name = "chkWithConsumptionBlock"
        Me.chkWithConsumptionBlock.Size = New System.Drawing.Size(228, 20)
        Me.chkWithConsumptionBlock.TabIndex = 81
        Me.chkWithConsumptionBlock.Text = "WITH WATER CONSUMPTION BLOCK"
        Me.chkWithConsumptionBlock.Values.Text = "WITH WATER CONSUMPTION BLOCK"
        '
        'btnUpdateParameter
        '
        Me.btnUpdateParameter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUpdateParameter.Location = New System.Drawing.Point(270, 234)
        Me.btnUpdateParameter.Name = "btnUpdateParameter"
        Me.btnUpdateParameter.Size = New System.Drawing.Size(115, 43)
        Me.btnUpdateParameter.TabIndex = 80
        Me.btnUpdateParameter.Values.Text = "UPDATE"
        '
        'lblBillingMonth
        '
        Me.lblBillingMonth.Location = New System.Drawing.Point(140, 17)
        Me.lblBillingMonth.Name = "lblBillingMonth"
        Me.lblBillingMonth.Size = New System.Drawing.Size(122, 19)
        Me.lblBillingMonth.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillingMonth.TabIndex = 79
        Me.lblBillingMonth.Values.Text = "BILLING MONTH:"
        '
        'txtMinimumCharge
        '
        Me.txtMinimumCharge.Location = New System.Drawing.Point(166, 96)
        Me.txtMinimumCharge.MaxLength = 10
        Me.txtMinimumCharge.Name = "txtMinimumCharge"
        Me.txtMinimumCharge.Size = New System.Drawing.Size(219, 20)
        Me.txtMinimumCharge.TabIndex = 78
        Me.txtMinimumCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(45, 99)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(129, 20)
        Me.KryptonLabel3.TabIndex = 77
        Me.KryptonLabel3.Values.Text = "MINIUMUM CHARGE:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(15, 17)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(129, 20)
        Me.KryptonLabel1.TabIndex = 76
        Me.KryptonLabel1.Values.Text = "COVERED MONTH(S):"
        '
        'txtMinimumConsumption
        '
        Me.txtMinimumConsumption.Location = New System.Drawing.Point(166, 68)
        Me.txtMinimumConsumption.MaxLength = 10
        Me.txtMinimumConsumption.Name = "txtMinimumConsumption"
        Me.txtMinimumConsumption.Size = New System.Drawing.Size(219, 20)
        Me.txtMinimumConsumption.TabIndex = 73
        Me.txtMinimumConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNewParameter
        '
        Me.btnNewParameter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNewParameter.Location = New System.Drawing.Point(15, 234)
        Me.btnNewParameter.Name = "btnNewParameter"
        Me.btnNewParameter.Size = New System.Drawing.Size(115, 43)
        Me.btnNewParameter.TabIndex = 38
        Me.btnNewParameter.Values.Text = "NEW PARAMETER"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(15, 71)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(162, 20)
        Me.KryptonLabel2.TabIndex = 75
        Me.KryptonLabel2.Values.Text = "MINIMUN COMSUMPTION:"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(166, 124)
        Me.txtRate.MaxLength = 10
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(219, 20)
        Me.txtRate.TabIndex = 72
        Me.txtRate.Tag = " "
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(67, 127)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel5.TabIndex = 74
        Me.KryptonLabel5.Values.Text = "RATE PER CU.M.:"
        '
        'ParameterListGroupbox
        '
        Me.ParameterListGroupbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.ParameterListGroupbox.Location = New System.Drawing.Point(10, 32)
        Me.ParameterListGroupbox.Name = "ParameterListGroupbox"
        '
        'ParameterListGroupbox.Panel
        '
        Me.ParameterListGroupbox.Panel.Controls.Add(Me.dgBillParameterRates)
        Me.ParameterListGroupbox.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.ParameterListGroupbox.Size = New System.Drawing.Size(950, 259)
        Me.ParameterListGroupbox.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.ParameterListGroupbox.StateCommon.Border.Rounding = 2
        Me.ParameterListGroupbox.TabIndex = 39
        Me.ParameterListGroupbox.Text = "BILLING PARAMETER RATES"
        Me.ParameterListGroupbox.Values.Heading = "BILLING PARAMETER RATES"
        '
        'dgBillParameterRates
        '
        Me.dgBillParameterRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBillParameterRates.Location = New System.Drawing.Point(10, 10)
        Me.dgBillParameterRates.Name = "dgBillParameterRates"
        Me.dgBillParameterRates.Size = New System.Drawing.Size(926, 215)
        Me.dgBillParameterRates.TabIndex = 1
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 10)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(950, 22)
        Me.KryptonPanel1.TabIndex = 38
        '
        'moduleheader
        '
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(5, 5)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(970, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 24
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "BILLING PARAMETERS"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BillParametersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 739)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "BillParametersForm"
        Me.Tag = "billparams"
        Me.Text = "Billing Parameters"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.TopPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopPanel.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.WaterConsumptionBlockKryptonGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WaterConsumptionBlockKryptonGroupBox.Panel.ResumeLayout(False)
        CType(Me.WaterConsumptionBlockKryptonGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WaterConsumptionBlockKryptonGroupBox.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.dgConsumptionBlocks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboRateClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.ParameterListGroupbox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ParameterListGroupbox.Panel.ResumeLayout(False)
        CType(Me.ParameterListGroupbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ParameterListGroupbox.ResumeLayout(False)
        CType(Me.dgBillParameterRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents TopPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonContextMenuItems2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnNewParameter As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ParameterListGroupbox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dgBillParameterRates As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMinimumConsumption As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtRate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnUpdateParameter As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtMinimumCharge As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents WaterConsumptionBlockKryptonGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnUpdateRates As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNewRates As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgConsumptionBlocks As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents cboRateClass As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkWithConsumptionBlock As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class
