<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingsDataChangeForm
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
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblCustomerType = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblUnitOwner = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pnlActions = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboActions = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.btnDoAction = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgBillings = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblUnpaidBillingPrompt = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
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
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.pnlActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        CType(Me.cboActions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dgBillings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.ContractOfLeaseHeader)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(1122, 650)
        Me.KryptonPanel.TabIndex = 0
        '
        'ContractOfLeaseHeader
        '
        Me.ContractOfLeaseHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.ContractOfLeaseHeader.Location = New System.Drawing.Point(0, 0)
        Me.ContractOfLeaseHeader.Name = "ContractOfLeaseHeader"
        Me.ContractOfLeaseHeader.Size = New System.Drawing.Size(1122, 31)
        Me.ContractOfLeaseHeader.TabIndex = 7
        Me.ContractOfLeaseHeader.Values.Description = ""
        Me.ContractOfLeaseHeader.Values.Heading = "BILLINGS DATA CHANGE"
        Me.ContractOfLeaseHeader.Values.Image = Nothing
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.pnlActions)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.cboFeeType)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.lblUnpaidBillingPrompt)
        Me.KryptonPanel1.Location = New System.Drawing.Point(135, 57)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(878, 531)
        Me.KryptonPanel1.TabIndex = 5
        Me.KryptonPanel1.Tag = "CENTERED"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(59, 0)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblCustomerType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnSearch)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblUnitOwner)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(776, 111)
        Me.KryptonGroupBox1.StateCommon.Border.Color1 = System.Drawing.Color.Black
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.TabIndex = 28
        Me.KryptonGroupBox1.Text = "SELECT CUSTOMER ACCOUNT"
        Me.KryptonGroupBox1.Values.Heading = "SELECT CUSTOMER ACCOUNT"
        '
        'lblCustomerType
        '
        Me.lblCustomerType.AutoSize = False
        Me.lblCustomerType.Location = New System.Drawing.Point(13, 49)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(670, 26)
        Me.lblCustomerType.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerType.TabIndex = 4
        Me.lblCustomerType.Values.Text = ""
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(689, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 40)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Values.Text = "SEARCH"
        '
        'lblUnitOwner
        '
        Me.lblUnitOwner.AutoSize = False
        Me.lblUnitOwner.Location = New System.Drawing.Point(13, 3)
        Me.lblUnitOwner.Name = "lblUnitOwner"
        Me.lblUnitOwner.Size = New System.Drawing.Size(670, 40)
        Me.lblUnitOwner.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOwner.TabIndex = 2
        Me.lblUnitOwner.Values.Text = ""
        '
        'pnlActions
        '
        Me.pnlActions.Controls.Add(Me.cboActions)
        Me.pnlActions.Controls.Add(Me.btnDoAction)
        Me.pnlActions.Controls.Add(Me.KryptonLabel14)
        Me.pnlActions.Location = New System.Drawing.Point(454, 424)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(382, 43)
        Me.pnlActions.TabIndex = 27
        '
        'cboActions
        '
        Me.cboActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActions.DropDownWidth = 151
        Me.cboActions.Location = New System.Drawing.Point(114, 12)
        Me.cboActions.Name = "cboActions"
        Me.cboActions.Size = New System.Drawing.Size(188, 21)
        Me.cboActions.TabIndex = 0
        '
        'btnDoAction
        '
        Me.btnDoAction.Location = New System.Drawing.Point(308, 2)
        Me.btnDoAction.Name = "btnDoAction"
        Me.btnDoAction.Size = New System.Drawing.Size(69, 31)
        Me.btnDoAction.TabIndex = 1
        Me.btnDoAction.Values.Text = "GO"
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Location = New System.Drawing.Point(17, 15)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(100, 20)
        Me.KryptonLabel14.TabIndex = 24
        Me.KryptonLabel14.Values.Text = "SELECT ACTION:"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dgBillings)
        Me.KryptonPanel2.Location = New System.Drawing.Point(60, 155)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.KryptonPanel2.Size = New System.Drawing.Size(776, 254)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Navy
        Me.KryptonPanel2.TabIndex = 23
        '
        'dgBillings
        '
        Me.dgBillings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBillings.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed
        Me.dgBillings.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile
        Me.dgBillings.Location = New System.Drawing.Point(1, 1)
        Me.dgBillings.Name = "dgBillings"
        Me.dgBillings.Size = New System.Drawing.Size(774, 252)
        Me.dgBillings.StateCommon.Background.Color1 = System.Drawing.Color.Gray
        Me.dgBillings.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile
        Me.dgBillings.TabIndex = 0
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 145
        Me.cboFeeType.Location = New System.Drawing.Point(123, 126)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(310, 21)
        Me.cboFeeType.TabIndex = 2
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(60, 129)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel2.TabIndex = 18
        Me.KryptonLabel2.Values.Text = "FEE TYPE:"
        '
        'lblUnpaidBillingPrompt
        '
        Me.lblUnpaidBillingPrompt.Location = New System.Drawing.Point(60, 415)
        Me.lblUnpaidBillingPrompt.Name = "lblUnpaidBillingPrompt"
        Me.lblUnpaidBillingPrompt.Size = New System.Drawing.Size(153, 19)
        Me.lblUnpaidBillingPrompt.StateCommon.ShortText.Color1 = System.Drawing.Color.Black
        Me.lblUnpaidBillingPrompt.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidBillingPrompt.TabIndex = 14
        Me.lblUnpaidBillingPrompt.Values.Text = "NO UNPAID BILLINGS"
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
        'BillingsDataChangeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 650)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BillingsDataChangeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Billings Data Change"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.pnlActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlActions.PerformLayout()
        CType(Me.cboActions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.dgBillings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblUnpaidBillingPrompt As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgBillings As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnDoAction As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboActions As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlActions As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents ContractOfLeaseHeader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblUnitOwner As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblCustomerType As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
