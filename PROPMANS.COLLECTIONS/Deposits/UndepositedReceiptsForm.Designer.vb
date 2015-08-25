<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UndepositedReceiptsForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.pnlBottom = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.lblTotalAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblReceiptSelection = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dgUndepositedReceipts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.btnShowReceipts = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.dtpEndDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.dtpStartDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dgUndepositedReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlBottom)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnClose)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(491, 514)
        Me.KryptonPanel.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblTotalAmount)
        Me.pnlBottom.Controls.Add(Me.lblReceiptSelection)
        Me.pnlBottom.Location = New System.Drawing.Point(12, 430)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(465, 27)
        Me.pnlBottom.TabIndex = 23
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Location = New System.Drawing.Point(4, 3)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(82, 19)
        Me.lblTotalAmount.TabIndex = 1
        Me.lblTotalAmount.Values.Text = "KryptonLabel2"
        '
        'lblReceiptSelection
        '
        Me.lblReceiptSelection.Location = New System.Drawing.Point(283, 3)
        Me.lblReceiptSelection.Name = "lblReceiptSelection"
        Me.lblReceiptSelection.Size = New System.Drawing.Size(82, 19)
        Me.lblReceiptSelection.TabIndex = 0
        Me.lblReceiptSelection.Values.Text = "KryptonLabel2"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(12, 151)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dgUndepositedReceipts)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(468, 273)
        Me.KryptonGroupBox2.TabIndex = 22
        Me.KryptonGroupBox2.Text = "RECEIPTS"
        Me.KryptonGroupBox2.Values.Heading = "RECEIPTS"
        '
        'dgUndepositedReceipts
        '
        Me.dgUndepositedReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUndepositedReceipts.Location = New System.Drawing.Point(5, 5)
        Me.dgUndepositedReceipts.Name = "dgUndepositedReceipts"
        Me.dgUndepositedReceipts.Size = New System.Drawing.Size(454, 240)
        Me.dgUndepositedReceipts.TabIndex = 3
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnShowReceipts)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpEndDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpStartDate)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(468, 133)
        Me.KryptonGroupBox1.TabIndex = 21
        Me.KryptonGroupBox1.Text = "RECEIPT DATE RANGE"
        Me.KryptonGroupBox1.Values.Heading = "RECEIPT DATE RANGE"
        '
        'btnShowReceipts
        '
        Me.btnShowReceipts.Location = New System.Drawing.Point(334, 66)
        Me.btnShowReceipts.Name = "btnShowReceipts"
        Me.btnShowReceipts.Size = New System.Drawing.Size(82, 30)
        Me.btnShowReceipts.TabIndex = 22
        Me.btnShowReceipts.Values.Text = "LIST"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.AlwaysActive = False
        Me.dtpEndDate.Location = New System.Drawing.Point(59, 40)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(357, 20)
        Me.dtpEndDate.TabIndex = 26
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(26, 40)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(27, 19)
        Me.KryptonLabel1.TabIndex = 25
        Me.KryptonLabel1.Values.Text = "TO:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(9, 15)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(44, 19)
        Me.KryptonLabel3.TabIndex = 24
        Me.KryptonLabel3.Values.Text = "FROM:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.AlwaysActive = False
        Me.dtpStartDate.Location = New System.Drawing.Point(59, 14)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(357, 20)
        Me.dtpStartDate.TabIndex = 20
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(317, 472)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 30)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "OK"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(398, 472)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 30)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Values.Text = "Cancel"
        '
        'UndepositedReceiptsForm
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UndepositedReceiptsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Undeposited Receipts"
        Me.TextExtra = ""
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dgUndepositedReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents btnClose As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpStartDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnShowReceipts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpEndDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlBottom As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblTotalAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblReceiptSelection As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dgUndepositedReceipts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
End Class
