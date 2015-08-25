<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewMeterReadingForm
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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.MeterReadingGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtPresentReading = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnClearPresentReading = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.txtPreviousRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblPreviousReadingFlag = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboPresentReadingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lblPresentReadingFlag = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtPresentRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtPresentAdjustments = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnClearAdjustments = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnSubtractAdjustments = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnAddAdjustments = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.lblPresentConsumption = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboPresentStatus = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblPreviousConsumption = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblPreviousStatus = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblPreviousAdjustments = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblPreviousReading = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblPreviousReadingDate = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.AccountInfoGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblAccountName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblMeterNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblAverageConsumption = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.MeterReadingGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeterReadingGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MeterReadingGroupBox.Panel.SuspendLayout()
        Me.MeterReadingGroupBox.SuspendLayout()
        CType(Me.cboPresentReadingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPresentStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountInfoGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountInfoGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccountInfoGroupBox.Panel.SuspendLayout()
        Me.AccountInfoGroupBox.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.MeterReadingGroupBox)
        Me.KryptonPanel.Controls.Add(Me.AccountInfoGroupBox)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel.Size = New System.Drawing.Size(708, 622)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnSave)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 555)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(688, 57)
        Me.KryptonPanel1.TabIndex = 61
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(480, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 36)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Values.Text = "SAVE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(576, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'MeterReadingGroupBox
        '
        Me.MeterReadingGroupBox.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel
        Me.MeterReadingGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.MeterReadingGroupBox.Location = New System.Drawing.Point(10, 151)
        Me.MeterReadingGroupBox.Name = "MeterReadingGroupBox"
        '
        'MeterReadingGroupBox.Panel
        '
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.txtPresentReading)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.txtPreviousRemarks)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousReadingFlag)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.cboPresentReadingMonth)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPresentReadingFlag)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel3)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.txtPresentRemarks)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.txtPresentAdjustments)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPresentConsumption)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.cboPresentStatus)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel14)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel13)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousConsumption)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousStatus)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousAdjustments)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel12)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousReading)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel11)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel10)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel9)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.lblPreviousReadingDate)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel8)
        Me.MeterReadingGroupBox.Panel.Controls.Add(Me.KryptonLabel2)
        Me.MeterReadingGroupBox.Size = New System.Drawing.Size(688, 404)
        Me.MeterReadingGroupBox.TabIndex = 2
        Me.MeterReadingGroupBox.Text = "METER READING INFORMATION"
        Me.MeterReadingGroupBox.Values.Heading = "METER READING INFORMATION"
        '
        'txtPresentReading
        '
        Me.txtPresentReading.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnClearPresentReading})
        Me.txtPresentReading.Location = New System.Drawing.Point(438, 131)
        Me.txtPresentReading.Name = "txtPresentReading"
        Me.txtPresentReading.Size = New System.Drawing.Size(227, 23)
        Me.txtPresentReading.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresentReading.TabIndex = 0
        Me.txtPresentReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClearPresentReading
        '
        Me.btnClearPresentReading.AllowInheritExtraText = False
        Me.btnClearPresentReading.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnClearPresentReading.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close
        Me.btnClearPresentReading.UniqueName = "930EA0083AFA4ABC36A9E537268D762E"
        '
        'txtPreviousRemarks
        '
        Me.txtPreviousRemarks.AcceptsReturn = True
        Me.txtPreviousRemarks.Location = New System.Drawing.Point(191, 290)
        Me.txtPreviousRemarks.Multiline = True
        Me.txtPreviousRemarks.Name = "txtPreviousRemarks"
        Me.txtPreviousRemarks.Size = New System.Drawing.Size(227, 64)
        Me.txtPreviousRemarks.TabIndex = 83
        '
        'lblPreviousReadingFlag
        '
        Me.lblPreviousReadingFlag.AutoSize = False
        Me.lblPreviousReadingFlag.Location = New System.Drawing.Point(191, 252)
        Me.lblPreviousReadingFlag.Name = "lblPreviousReadingFlag"
        Me.lblPreviousReadingFlag.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousReadingFlag.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousReadingFlag.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousReadingFlag.TabIndex = 4
        Me.lblPreviousReadingFlag.Values.Text = "FLAG:"
        '
        'cboPresentReadingMonth
        '
        Me.cboPresentReadingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPresentReadingMonth.DropDownWidth = 121
        Me.cboPresentReadingMonth.Location = New System.Drawing.Point(438, 59)
        Me.cboPresentReadingMonth.Name = "cboPresentReadingMonth"
        Me.cboPresentReadingMonth.Size = New System.Drawing.Size(227, 20)
        Me.cboPresentReadingMonth.StateCommon.ComboBox.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPresentReadingMonth.StateCommon.Item.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPresentReadingMonth.TabIndex = 0
        '
        'lblPresentReadingFlag
        '
        Me.lblPresentReadingFlag.AutoSize = False
        Me.lblPresentReadingFlag.Location = New System.Drawing.Point(438, 247)
        Me.lblPresentReadingFlag.Name = "lblPresentReadingFlag"
        Me.lblPresentReadingFlag.Size = New System.Drawing.Size(227, 27)
        Me.lblPresentReadingFlag.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentReadingFlag.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPresentReadingFlag.TabIndex = 62
        Me.lblPresentReadingFlag.Values.Text = "FLAG"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(119, 252)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(51, 19)
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 80
        Me.KryptonLabel3.Values.Text = "FLAG:"
        '
        'txtPresentRemarks
        '
        Me.txtPresentRemarks.AcceptsReturn = True
        Me.txtPresentRemarks.Location = New System.Drawing.Point(438, 290)
        Me.txtPresentRemarks.Multiline = True
        Me.txtPresentRemarks.Name = "txtPresentRemarks"
        Me.txtPresentRemarks.Size = New System.Drawing.Size(227, 64)
        Me.txtPresentRemarks.TabIndex = 3
        '
        'txtPresentAdjustments
        '
        Me.txtPresentAdjustments.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnClearAdjustments, Me.btnSubtractAdjustments, Me.btnAddAdjustments})
        Me.txtPresentAdjustments.Location = New System.Drawing.Point(437, 168)
        Me.txtPresentAdjustments.Name = "txtPresentAdjustments"
        Me.txtPresentAdjustments.Size = New System.Drawing.Size(227, 28)
        Me.txtPresentAdjustments.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresentAdjustments.TabIndex = 1
        Me.txtPresentAdjustments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClearAdjustments
        '
        Me.btnClearAdjustments.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnClearAdjustments.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close
        Me.btnClearAdjustments.UniqueName = "930EA0083AFA4ABC36A9E537268D762E"
        '
        'btnSubtractAdjustments
        '
        Me.btnSubtractAdjustments.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked
        Me.btnSubtractAdjustments.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near
        Me.btnSubtractAdjustments.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnSubtractAdjustments.Text = "-"
        Me.btnSubtractAdjustments.UniqueName = "804E24FF0E124AB7B490D125E930D0FF"
        '
        'btnAddAdjustments
        '
        Me.btnAddAdjustments.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Checked
        Me.btnAddAdjustments.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near
        Me.btnAddAdjustments.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnAddAdjustments.Text = "+"
        Me.btnAddAdjustments.UniqueName = "8463D8C5EF2640C196B1114E54968876"
        '
        'lblPresentConsumption
        '
        Me.lblPresentConsumption.AutoSize = False
        Me.lblPresentConsumption.Location = New System.Drawing.Point(438, 214)
        Me.lblPresentConsumption.Name = "lblPresentConsumption"
        Me.lblPresentConsumption.Size = New System.Drawing.Size(227, 24)
        Me.lblPresentConsumption.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentConsumption.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPresentConsumption.TabIndex = 60
        Me.lblPresentConsumption.Values.Text = "CONSUMPTION:"
        '
        'cboPresentStatus
        '
        Me.cboPresentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPresentStatus.DropDownWidth = 121
        Me.cboPresentStatus.Location = New System.Drawing.Point(438, 97)
        Me.cboPresentStatus.Name = "cboPresentStatus"
        Me.cboPresentStatus.Size = New System.Drawing.Size(227, 20)
        Me.cboPresentStatus.StateCommon.ComboBox.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPresentStatus.TabIndex = 0
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.AutoSize = False
        Me.KryptonLabel14.Location = New System.Drawing.Point(438, 17)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(227, 19)
        Me.KryptonLabel14.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel14.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonLabel14.TabIndex = 77
        Me.KryptonLabel14.Values.Text = "PRESENT / CURRENT"
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.AutoSize = False
        Me.KryptonLabel13.Location = New System.Drawing.Point(191, 17)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(227, 19)
        Me.KryptonLabel13.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel13.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonLabel13.TabIndex = 76
        Me.KryptonLabel13.Values.Text = "LAST / PREVIOUS"
        '
        'lblPreviousConsumption
        '
        Me.lblPreviousConsumption.AutoSize = False
        Me.lblPreviousConsumption.Location = New System.Drawing.Point(191, 214)
        Me.lblPreviousConsumption.Name = "lblPreviousConsumption"
        Me.lblPreviousConsumption.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousConsumption.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousConsumption.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousConsumption.TabIndex = 66
        Me.lblPreviousConsumption.Values.Text = "CONSUMPTION:"
        '
        'lblPreviousStatus
        '
        Me.lblPreviousStatus.AutoSize = False
        Me.lblPreviousStatus.Location = New System.Drawing.Point(191, 100)
        Me.lblPreviousStatus.Name = "lblPreviousStatus"
        Me.lblPreviousStatus.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousStatus.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousStatus.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousStatus.TabIndex = 67
        Me.lblPreviousStatus.Values.Text = "STATUS:"
        '
        'lblPreviousAdjustments
        '
        Me.lblPreviousAdjustments.AutoSize = False
        Me.lblPreviousAdjustments.Location = New System.Drawing.Point(191, 176)
        Me.lblPreviousAdjustments.Name = "lblPreviousAdjustments"
        Me.lblPreviousAdjustments.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousAdjustments.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousAdjustments.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousAdjustments.TabIndex = 65
        Me.lblPreviousAdjustments.Values.Text = "ADJUSTMENTS:"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(87, 290)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(83, 19)
        Me.KryptonLabel12.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel12.TabIndex = 75
        Me.KryptonLabel12.Values.Text = "REMARKS:"
        '
        'lblPreviousReading
        '
        Me.lblPreviousReading.AutoSize = False
        Me.lblPreviousReading.Location = New System.Drawing.Point(191, 138)
        Me.lblPreviousReading.Name = "lblPreviousReading"
        Me.lblPreviousReading.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousReading.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousReading.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousReading.TabIndex = 64
        Me.lblPreviousReading.Values.Text = "READING:"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(9, 214)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(161, 19)
        Me.KryptonLabel11.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel11.TabIndex = 74
        Me.KryptonLabel11.Values.Text = "CONSUMPTION (cu.m):"
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(23, 176)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(147, 19)
        Me.KryptonLabel10.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel10.TabIndex = 73
        Me.KryptonLabel10.Values.Text = "ADJUSTMENT(cu.m):"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(92, 138)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(78, 19)
        Me.KryptonLabel9.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel9.TabIndex = 72
        Me.KryptonLabel9.Values.Text = "READING:"
        '
        'lblPreviousReadingDate
        '
        Me.lblPreviousReadingDate.AutoSize = False
        Me.lblPreviousReadingDate.Location = New System.Drawing.Point(191, 62)
        Me.lblPreviousReadingDate.Name = "lblPreviousReadingDate"
        Me.lblPreviousReadingDate.Size = New System.Drawing.Size(227, 19)
        Me.lblPreviousReadingDate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousReadingDate.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblPreviousReadingDate.TabIndex = 63
        Me.lblPreviousReadingDate.Values.Text = "READING DATE:"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(78, 100)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(92, 19)
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 71
        Me.KryptonLabel8.Values.Text = "CATEGORY:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(39, 62)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(131, 19)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.TabIndex = 70
        Me.KryptonLabel2.Values.Text = "PERIOD (MONTH):"
        '
        'AccountInfoGroupBox
        '
        Me.AccountInfoGroupBox.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel
        Me.AccountInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.AccountInfoGroupBox.Location = New System.Drawing.Point(10, 10)
        Me.AccountInfoGroupBox.Name = "AccountInfoGroupBox"
        '
        'AccountInfoGroupBox.Panel
        '
        Me.AccountInfoGroupBox.Panel.Controls.Add(Me.lblAccountName)
        Me.AccountInfoGroupBox.Panel.Controls.Add(Me.lblMeterNumber)
        Me.AccountInfoGroupBox.Panel.Controls.Add(Me.lblAverageConsumption)
        Me.AccountInfoGroupBox.Size = New System.Drawing.Size(688, 141)
        Me.AccountInfoGroupBox.TabIndex = 59
        Me.AccountInfoGroupBox.Text = "WATER METER ACCOUNT INFORMATION"
        Me.AccountInfoGroupBox.Values.Heading = "WATER METER ACCOUNT INFORMATION"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(10, 16)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(306, 23)
        Me.lblAccountName.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.TabIndex = 36
        Me.lblAccountName.Values.Text = "UNIT NUMBER - UNIT OWNER NAME"
        '
        'lblMeterNumber
        '
        Me.lblMeterNumber.Location = New System.Drawing.Point(10, 49)
        Me.lblMeterNumber.Name = "lblMeterNumber"
        Me.lblMeterNumber.Size = New System.Drawing.Size(119, 19)
        Me.lblMeterNumber.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeterNumber.TabIndex = 37
        Me.lblMeterNumber.Values.Text = "METER NUMBER"
        '
        'lblAverageConsumption
        '
        Me.lblAverageConsumption.Location = New System.Drawing.Point(10, 74)
        Me.lblAverageConsumption.Name = "lblAverageConsumption"
        Me.lblAverageConsumption.Size = New System.Drawing.Size(259, 19)
        Me.lblAverageConsumption.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAverageConsumption.TabIndex = 47
        Me.lblAverageConsumption.Values.Text = "AVERAGE READING - LAST X MONTHS"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewMeterReadingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 622)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewMeterReadingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NEW METER READING"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.MeterReadingGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MeterReadingGroupBox.Panel.ResumeLayout(False)
        Me.MeterReadingGroupBox.Panel.PerformLayout()
        CType(Me.MeterReadingGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MeterReadingGroupBox.ResumeLayout(False)
        CType(Me.cboPresentReadingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPresentStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountInfoGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccountInfoGroupBox.Panel.ResumeLayout(False)
        Me.AccountInfoGroupBox.Panel.PerformLayout()
        CType(Me.AccountInfoGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccountInfoGroupBox.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblMeterNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblAccountName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblAverageConsumption As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents MeterReadingGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents AccountInfoGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblPresentReadingFlag As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtPresentRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPresentAdjustments As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnClearAdjustments As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents lblPresentConsumption As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboPresentStatus As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPreviousConsumption As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPreviousStatus As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPreviousAdjustments As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPreviousReading As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPreviousReadingDate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboPresentReadingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lblPreviousReadingFlag As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtPreviousRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPresentReading As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnClearPresentReading As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents btnAddAdjustments As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents btnSubtractAdjustments As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
End Class
