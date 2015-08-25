<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnpaidInvoicessForm
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
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.pnl2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblAmountPrompt = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtAmountGiven = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgUnpaidInvoices = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.pnl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.dgUnpaidInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonAlternate
        Me.KryptonPanel.Size = New System.Drawing.Size(1006, 266)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.pnl2)
        Me.KryptonPanel2.Controls.Add(Me.btnCancel)
        Me.KryptonPanel2.Controls.Add(Me.btnSave)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(5, 190)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(996, 67)
        Me.KryptonPanel2.TabIndex = 31
        '
        'pnl2
        '
        Me.pnl2.Controls.Add(Me.lblAmount)
        Me.pnl2.Controls.Add(Me.lblAmountPrompt)
        Me.pnl2.Controls.Add(Me.KryptonLabel9)
        Me.pnl2.Controls.Add(Me.txtAmountGiven)
        Me.pnl2.Location = New System.Drawing.Point(0, 0)
        Me.pnl2.Name = "pnl2"
        Me.pnl2.Size = New System.Drawing.Size(662, 67)
        Me.pnl2.TabIndex = 1
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(472, 29)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(82, 29)
        Me.lblAmount.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAmount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.TabIndex = 49
        Me.lblAmount.Values.Text = "500.00"
        '
        'lblAmountPrompt
        '
        Me.lblAmountPrompt.Location = New System.Drawing.Point(331, 29)
        Me.lblAmountPrompt.Name = "lblAmountPrompt"
        Me.lblAmountPrompt.Size = New System.Drawing.Size(135, 20)
        Me.lblAmountPrompt.TabIndex = 50
        Me.lblAmountPrompt.Values.Text = "REMAINING BALANCE:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(22, 28)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(117, 20)
        Me.KryptonLabel9.TabIndex = 48
        Me.KryptonLabel9.Values.Text = "PARTIAL PAYMENT:"
        '
        'txtAmountGiven
        '
        Me.txtAmountGiven.Location = New System.Drawing.Point(145, 29)
        Me.txtAmountGiven.Name = "txtAmountGiven"
        Me.txtAmountGiven.Size = New System.Drawing.Size(154, 20)
        Me.txtAmountGiven.TabIndex = 47
        Me.txtAmountGiven.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel.Location = New System.Drawing.Point(897, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 44)
        Me.btnCancel.TabIndex = 33
        Me.btnCancel.Values.Text = "CANCEL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSave.Location = New System.Drawing.Point(785, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(106, 44)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Values.Text = "APPLY PAYMENT"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(5, 157)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(996, 33)
        Me.KryptonPanel1.TabIndex = 30
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.dgUnpaidInvoices)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(5, 5)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel3.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonGallery
        Me.KryptonPanel3.Size = New System.Drawing.Size(996, 152)
        Me.KryptonPanel3.TabIndex = 28
        '
        'dgUnpaidInvoices
        '
        Me.dgUnpaidInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUnpaidInvoices.Location = New System.Drawing.Point(10, 10)
        Me.dgUnpaidInvoices.Name = "dgUnpaidInvoices"
        Me.dgUnpaidInvoices.Size = New System.Drawing.Size(976, 132)
        Me.dgUnpaidInvoices.TabIndex = 0
        '
        'UnpaidInvoicessForm
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 266)
        Me.Controls.Add(Me.KryptonPanel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnpaidInvoicessForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Unpaid Invoices"
        Me.TextExtra = ""
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.pnl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl2.ResumeLayout(False)
        Me.pnl2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.dgUnpaidInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgUnpaidInvoices As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents pnl2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblAmountPrompt As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAmountGiven As ComponentFactory.Krypton.Toolkit.KryptonTextBox
End Class
