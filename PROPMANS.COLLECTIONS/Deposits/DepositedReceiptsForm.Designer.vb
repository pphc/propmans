<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepositedReceiptsForm
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
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.lblRemarks = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblAccountNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDepositDate = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDepositType = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDepositoryBank = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dgDepositedReceipts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.pnlBottom = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.lblRecordCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblDepositAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dgDepositedReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnClose)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(470, 539)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblRemarks)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblAccountNumber)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDepositDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDepositType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDepositoryBank)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel8)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(447, 209)
        Me.KryptonGroupBox1.TabIndex = 23
        Me.KryptonGroupBox1.Values.Heading = "Deposit Details"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = False
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblRemarks.Location = New System.Drawing.Point(130, 124)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(291, 50)
        Me.lblRemarks.Text = "KryptonWrapLabel1"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(69, 124)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(55, 19)
        Me.KryptonLabel4.TabIndex = 58
        Me.KryptonLabel4.Values.Text = "Remarks:"
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.Location = New System.Drawing.Point(130, 40)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(67, 19)
        Me.lblAccountNumber.TabIndex = 57
        Me.lblAccountNumber.Values.Text = "Bank Name"
        '
        'lblDepositDate
        '
        Me.lblDepositDate.Location = New System.Drawing.Point(130, 15)
        Me.lblDepositDate.Name = "lblDepositDate"
        Me.lblDepositDate.Size = New System.Drawing.Size(67, 19)
        Me.lblDepositDate.TabIndex = 56
        Me.lblDepositDate.Values.Text = "Bank Name"
        '
        'lblDepositType
        '
        Me.lblDepositType.Location = New System.Drawing.Point(130, 99)
        Me.lblDepositType.Name = "lblDepositType"
        Me.lblDepositType.Size = New System.Drawing.Size(67, 19)
        Me.lblDepositType.TabIndex = 55
        Me.lblDepositType.Values.Text = "Bank Name"
        '
        'lblDepositoryBank
        '
        Me.lblDepositoryBank.Location = New System.Drawing.Point(130, 71)
        Me.lblDepositoryBank.Name = "lblDepositoryBank"
        Me.lblDepositoryBank.Size = New System.Drawing.Size(67, 19)
        Me.lblDepositoryBank.TabIndex = 54
        Me.lblDepositoryBank.Values.Text = "Bank Name"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(46, 99)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(78, 19)
        Me.KryptonLabel3.TabIndex = 51
        Me.KryptonLabel3.Values.Text = "Deposit Type:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(54, 71)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(70, 19)
        Me.KryptonLabel2.TabIndex = 50
        Me.KryptonLabel2.Values.Text = "Bank Name:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(26, 43)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(98, 16)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 49
        Me.KryptonLabel1.Values.Text = "Account Number:"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(46, 15)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(78, 19)
        Me.KryptonLabel8.TabIndex = 48
        Me.KryptonLabel8.Values.Text = "Deposit Date:"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(10, 227)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dgDepositedReceipts)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.pnlBottom)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(447, 264)
        Me.KryptonGroupBox2.TabIndex = 22
        Me.KryptonGroupBox2.Values.Heading = "RECEIPTS"
        '
        'dgDepositedReceipts
        '
        Me.dgDepositedReceipts.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgDepositedReceipts.Location = New System.Drawing.Point(5, 5)
        Me.dgDepositedReceipts.Name = "dgDepositedReceipts"
        Me.dgDepositedReceipts.Size = New System.Drawing.Size(433, 195)
        Me.dgDepositedReceipts.TabIndex = 1
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblRecordCount)
        Me.pnlBottom.Controls.Add(Me.lblDepositAmount)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(5, 207)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(433, 29)
        Me.pnlBottom.TabIndex = 0
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(335, 7)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(82, 19)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Values.Text = "KryptonLabel2"
        '
        'lblDepositAmount
        '
        Me.lblDepositAmount.Location = New System.Drawing.Point(3, 7)
        Me.lblDepositAmount.Name = "lblDepositAmount"
        Me.lblDepositAmount.Size = New System.Drawing.Size(82, 19)
        Me.lblDepositAmount.TabIndex = 0
        Me.lblDepositAmount.Values.Text = "KryptonLabel2"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(250, 497)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(122, 30)
        Me.btnOK.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "CANCEL DEPOSIT"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(378, 497)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 30)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Values.Text = "CLOSE"
        '
        'DepositedReceiptsForm
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 539)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DepositedReceiptsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposited Receipts"
        Me.TextExtra = ""
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dgDepositedReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
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
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents pnlBottom As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgDepositedReceipts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents lblDepositAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblDepositoryBank As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblAccountNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblDepositDate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblDepositType As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblRecordCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblRemarks As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
