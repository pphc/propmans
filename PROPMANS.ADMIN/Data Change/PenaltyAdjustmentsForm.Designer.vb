<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PenaltyAdjustmentsForm
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
        Me.ContractOfLeaseHeader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.AdjustmentPanel = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblAdjustments = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblbeforeAdjustments = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSaveAdjustment = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dtpAdjustmentDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtRemarks = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.InvoicePanel = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.gridPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeTypes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblCustomerType = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblUnitOwner = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ctxActions1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuItems2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.cmdCancel = New ComponentFactory.Krypton.Toolkit.KryptonCommand()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.ctxActions2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuItems3 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem4 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.cmdHold = New ComponentFactory.Krypton.Toolkit.KryptonCommand()
        Me.ctxActions3 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuItems4 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem5 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem7 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.cmdUnhold = New ComponentFactory.Krypton.Toolkit.KryptonCommand()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.AdjustmentPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentPanel.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdjustmentPanel.Panel.SuspendLayout()
        Me.AdjustmentPanel.SuspendLayout()
        CType(Me.InvoicePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoicePanel.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InvoicePanel.Panel.SuspendLayout()
        Me.InvoicePanel.SuspendLayout()
        CType(Me.gridPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridPanel.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeeTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.ContractOfLeaseHeader)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(1154, 697)
        Me.KryptonPanel.TabIndex = 0
        '
        'ContractOfLeaseHeader
        '
        Me.ContractOfLeaseHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.ContractOfLeaseHeader.Location = New System.Drawing.Point(0, 0)
        Me.ContractOfLeaseHeader.Name = "ContractOfLeaseHeader"
        Me.ContractOfLeaseHeader.Size = New System.Drawing.Size(1154, 31)
        Me.ContractOfLeaseHeader.TabIndex = 6
        Me.ContractOfLeaseHeader.Values.Description = ""
        Me.ContractOfLeaseHeader.Values.Heading = "PENALTY ADJUSTMENTS"
        Me.ContractOfLeaseHeader.Values.Image = Nothing
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.AdjustmentPanel)
        Me.KryptonPanel1.Controls.Add(Me.InvoicePanel)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Location = New System.Drawing.Point(105, 59)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(987, 626)
        Me.KryptonPanel1.TabIndex = 5
        Me.KryptonPanel1.Tag = "CENTERED"
        '
        'AdjustmentPanel
        '
        Me.AdjustmentPanel.Location = New System.Drawing.Point(49, 365)
        Me.AdjustmentPanel.Name = "AdjustmentPanel"
        '
        'AdjustmentPanel.Panel
        '
        Me.AdjustmentPanel.Panel.Controls.Add(Me.lblAdjustments)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.lblbeforeAdjustments)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.btnSaveAdjustment)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.dtpAdjustmentDate)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.KryptonLabel6)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.txtRemarks)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.KryptonLabel5)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.KryptonLabel4)
        Me.AdjustmentPanel.Panel.Controls.Add(Me.KryptonLabel2)
        Me.AdjustmentPanel.Size = New System.Drawing.Size(850, 232)
        Me.AdjustmentPanel.StateCommon.Border.Color1 = System.Drawing.Color.Black
        Me.AdjustmentPanel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.AdjustmentPanel.TabIndex = 2
        Me.AdjustmentPanel.Text = "PENALTY ADJUSTMENTS"
        Me.AdjustmentPanel.Values.Heading = "PENALTY ADJUSTMENTS"
        '
        'lblAdjustments
        '
        Me.lblAdjustments.AutoSize = False
        Me.lblAdjustments.Location = New System.Drawing.Point(239, 31)
        Me.lblAdjustments.Name = "lblAdjustments"
        Me.lblAdjustments.Size = New System.Drawing.Size(161, 19)
        Me.lblAdjustments.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustments.TabIndex = 10
        Me.lblAdjustments.Values.Text = ""
        '
        'lblbeforeAdjustments
        '
        Me.lblbeforeAdjustments.AutoSize = False
        Me.lblbeforeAdjustments.Location = New System.Drawing.Point(239, 6)
        Me.lblbeforeAdjustments.Name = "lblbeforeAdjustments"
        Me.lblbeforeAdjustments.Size = New System.Drawing.Size(161, 19)
        Me.lblbeforeAdjustments.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbeforeAdjustments.TabIndex = 9
        Me.lblbeforeAdjustments.Values.Text = ""
        '
        'btnSaveAdjustment
        '
        Me.btnSaveAdjustment.Location = New System.Drawing.Point(703, 165)
        Me.btnSaveAdjustment.Name = "btnSaveAdjustment"
        Me.btnSaveAdjustment.Size = New System.Drawing.Size(127, 40)
        Me.btnSaveAdjustment.TabIndex = 8
        Me.btnSaveAdjustment.Values.Text = "SAVE ADJUSTMENT"
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(136, 156)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(263, 21)
        Me.dtpAdjustmentDate.TabIndex = 7
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(18, 157)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(122, 20)
        Me.KryptonLabel6.TabIndex = 6
        Me.KryptonLabel6.Values.Text = "ADJUSTMENT DATE:"
        '
        'txtRemarks
        '
        Me.txtRemarks.AcceptsReturn = True
        Me.txtRemarks.Location = New System.Drawing.Point(18, 81)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(811, 70)
        Me.txtRemarks.TabIndex = 5
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(18, 56)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(67, 20)
        Me.KryptonLabel5.TabIndex = 4
        Me.KryptonLabel5.Values.Text = "REMARKS:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(140, 31)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(95, 20)
        Me.KryptonLabel4.TabIndex = 3
        Me.KryptonLabel4.Values.Text = "ADJUSTMENTS:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(18, 6)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(233, 20)
        Me.KryptonLabel2.TabIndex = 2
        Me.KryptonLabel2.Values.Text = "TOTAL PENALTY BEFORE ADJUSTMENTS:"
        '
        'InvoicePanel
        '
        Me.InvoicePanel.Location = New System.Drawing.Point(49, 127)
        Me.InvoicePanel.Name = "InvoicePanel"
        '
        'InvoicePanel.Panel
        '
        Me.InvoicePanel.Panel.Controls.Add(Me.gridPanel)
        Me.InvoicePanel.Panel.Controls.Add(Me.KryptonLabel1)
        Me.InvoicePanel.Panel.Controls.Add(Me.cboFeeTypes)
        Me.InvoicePanel.Size = New System.Drawing.Size(850, 232)
        Me.InvoicePanel.StateCommon.Border.Color1 = System.Drawing.Color.Black
        Me.InvoicePanel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.InvoicePanel.TabIndex = 1
        Me.InvoicePanel.Text = "INVOICES"
        Me.InvoicePanel.Values.Heading = "INVOICES"
        '
        'gridPanel
        '
        Me.gridPanel.Controls.Add(Me.grid)
        Me.gridPanel.Location = New System.Drawing.Point(18, 34)
        Me.gridPanel.Name = "gridPanel"
        Me.gridPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.gridPanel.Size = New System.Drawing.Size(812, 161)
        Me.gridPanel.StateCommon.Color1 = System.Drawing.Color.Gray
        Me.gridPanel.TabIndex = 15
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(1, 1)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(810, 159)
        Me.grid.TabIndex = 0
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(18, 6)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel1.TabIndex = 2
        Me.KryptonLabel1.Values.Text = "FEE TYPE:"
        '
        'cboFeeTypes
        '
        Me.cboFeeTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboFeeTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFeeTypes.DropDownWidth = 183
        Me.cboFeeTypes.Location = New System.Drawing.Point(81, 6)
        Me.cboFeeTypes.Name = "cboFeeTypes"
        Me.cboFeeTypes.Size = New System.Drawing.Size(205, 21)
        Me.cboFeeTypes.TabIndex = 1
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(49, 14)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblCustomerType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnSearch)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblUnitOwner)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(850, 107)
        Me.KryptonGroupBox1.StateCommon.Border.Color1 = System.Drawing.Color.Black
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "SELECT CUSTOMER ACCOUNT"
        Me.KryptonGroupBox1.Values.Heading = "SELECT CUSTOMER ACCOUNT"
        '
        'lblCustomerType
        '
        Me.lblCustomerType.AutoSize = False
        Me.lblCustomerType.Location = New System.Drawing.Point(18, 49)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(726, 31)
        Me.lblCustomerType.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerType.TabIndex = 4
        Me.lblCustomerType.Values.Text = ""
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(750, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 40)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Values.Text = "SEARCH"
        '
        'lblUnitOwner
        '
        Me.lblUnitOwner.AutoSize = False
        Me.lblUnitOwner.Location = New System.Drawing.Point(18, 3)
        Me.lblUnitOwner.Name = "lblUnitOwner"
        Me.lblUnitOwner.Size = New System.Drawing.Size(726, 40)
        Me.lblUnitOwner.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOwner.TabIndex = 2
        Me.lblUnitOwner.Values.Text = ""
        '
        'ctxActions1
        '
        Me.ctxActions1.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItems2})
        '
        'KryptonContextMenuItems2
        '
        Me.KryptonContextMenuItems2.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem1})
        '
        'KryptonContextMenuItem1
        '
        Me.KryptonContextMenuItem1.KryptonCommand = Me.cmdCancel
        Me.KryptonContextMenuItem1.Tag = "cancel"
        Me.KryptonContextMenuItem1.Text = "CANCEL BILLING/S"
        '
        'cmdCancel
        '
        Me.cmdCancel.Tag = "cancel"
        Me.cmdCancel.Text = "CANCEL BILLING/S"
        '
        'ctxActions2
        '
        Me.ctxActions2.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItems3})
        '
        'KryptonContextMenuItems3
        '
        Me.KryptonContextMenuItems3.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem4, Me.KryptonContextMenuItem2})
        '
        'KryptonContextMenuItem4
        '
        Me.KryptonContextMenuItem4.KryptonCommand = Me.cmdCancel
        Me.KryptonContextMenuItem4.Tag = "cancel"
        Me.KryptonContextMenuItem4.Text = "CANCEL BILLING/S"
        '
        'KryptonContextMenuItem2
        '
        Me.KryptonContextMenuItem2.KryptonCommand = Me.cmdHold
        Me.KryptonContextMenuItem2.Tag = "hold"
        Me.KryptonContextMenuItem2.Text = "HOLD BILLING/S"
        '
        'cmdHold
        '
        Me.cmdHold.Tag = "hold"
        Me.cmdHold.Text = "HOLD BILLING/S"
        '
        'ctxActions3
        '
        Me.ctxActions3.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItems4})
        '
        'KryptonContextMenuItems4
        '
        Me.KryptonContextMenuItems4.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem5, Me.KryptonContextMenuItem7})
        '
        'KryptonContextMenuItem5
        '
        Me.KryptonContextMenuItem5.KryptonCommand = Me.cmdCancel
        Me.KryptonContextMenuItem5.Tag = "cancel"
        Me.KryptonContextMenuItem5.Text = "CANCEL BILLING/S"
        '
        'KryptonContextMenuItem7
        '
        Me.KryptonContextMenuItem7.KryptonCommand = Me.cmdUnhold
        Me.KryptonContextMenuItem7.Tag = "unhold"
        Me.KryptonContextMenuItem7.Text = "UNHOLD BILLINGS"
        '
        'cmdUnhold
        '
        Me.cmdUnhold.Tag = "unhold"
        Me.cmdUnhold.Text = "UNHOLD BILLING/S"
        '
        'PenaltyAdjustmentsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 697)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PenaltyAdjustmentsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Penalty Adjustments"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.AdjustmentPanel.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdjustmentPanel.Panel.ResumeLayout(False)
        Me.AdjustmentPanel.Panel.PerformLayout()
        CType(Me.AdjustmentPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdjustmentPanel.ResumeLayout(False)
        CType(Me.InvoicePanel.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoicePanel.Panel.ResumeLayout(False)
        Me.InvoicePanel.Panel.PerformLayout()
        CType(Me.InvoicePanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvoicePanel.ResumeLayout(False)
        CType(Me.gridPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridPanel.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeeTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents ctxActions1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonContextMenuItems2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents ctxActions2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonContextMenuItems3 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem4 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents ctxActions3 As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonContextMenuItems4 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem5 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonContextMenuItem7 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonContextMenuItem2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents cmdCancel As ComponentFactory.Krypton.Toolkit.KryptonCommand
    Friend WithEvents cmdHold As ComponentFactory.Krypton.Toolkit.KryptonCommand
    Friend WithEvents cmdUnhold As ComponentFactory.Krypton.Toolkit.KryptonCommand
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblUnitOwner As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents InvoicePanel As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents cboFeeTypes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gridPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents AdjustmentPanel As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtRemarks As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSaveAdjustment As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpAdjustmentDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents lblAdjustments As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblbeforeAdjustments As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents ContractOfLeaseHeader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents lblCustomerType As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
