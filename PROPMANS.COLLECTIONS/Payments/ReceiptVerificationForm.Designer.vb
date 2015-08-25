<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptVerificationForm
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
        Me.lblUnitOwnerName = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
        Me.KryptonWrapLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
        Me.lblAmountChange = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.txtAmountReceived = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.btnReset = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.lblReceiptDate = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
        Me.lblReceiptAmount = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.chkOverrideReceiptNumber = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.txtReceiptNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.AutoSize = True
        Me.KryptonPanel.Controls.Add(Me.lblUnitOwnerName)
        Me.KryptonPanel.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonPanel.Controls.Add(Me.lblAmountChange)
        Me.KryptonPanel.Controls.Add(Me.txtAmountReceived)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.lblReceiptDate)
        Me.KryptonPanel.Controls.Add(Me.lblReceiptAmount)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.txtReceiptNumber)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnClose)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(20)
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(435, 489)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblUnitOwnerName
        '
        Me.lblUnitOwnerName.AutoSize = False
        Me.lblUnitOwnerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOwnerName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblUnitOwnerName.Location = New System.Drawing.Point(20, 168)
        Me.lblUnitOwnerName.Name = "lblUnitOwnerName"
        Me.lblUnitOwnerName.Size = New System.Drawing.Size(402, 55)
        Me.lblUnitOwnerName.StateCommon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOwnerName.Text = "1111 - ARELLANO, TONI"
        Me.lblUnitOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.AutoSize = False
        Me.KryptonWrapLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonWrapLabel1.Location = New System.Drawing.Point(17, 140)
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.Size = New System.Drawing.Size(402, 28)
        Me.KryptonWrapLabel1.StateCommon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonWrapLabel1.Text = "TO BE ISSUED TO"
        Me.KryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAmountChange
        '
        Me.lblAmountChange.AutoSize = False
        Me.lblAmountChange.Location = New System.Drawing.Point(191, 450)
        Me.lblAmountChange.Name = "lblAmountChange"
        Me.lblAmountChange.Size = New System.Drawing.Size(163, 27)
        Me.lblAmountChange.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountChange.TabIndex = 17
        Me.lblAmountChange.Values.Text = ""
        '
        'txtAmountReceived
        '
        Me.txtAmountReceived.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnReset})
        Me.txtAmountReceived.Location = New System.Drawing.Point(191, 411)
        Me.txtAmountReceived.Name = "txtAmountReceived"
        Me.txtAmountReceived.Size = New System.Drawing.Size(163, 24)
        Me.txtAmountReceived.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountReceived.TabIndex = 0
        Me.txtAmountReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnReset
        '
        Me.btnReset.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnReset.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close
        Me.btnReset.UniqueName = "22C00C35832249F3C0AE885BFFA51275"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(122, 450)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(63, 16)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.TabIndex = 15
        Me.KryptonLabel2.Values.Text = "CHANGE:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(36, 416)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(149, 19)
        Me.KryptonLabel1.TabIndex = 12
        Me.KryptonLabel1.Values.Text = "ENTER AMOUNT RECEIVED:"
        '
        'lblReceiptDate
        '
        Me.lblReceiptDate.AutoSize = False
        Me.lblReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblReceiptDate.Location = New System.Drawing.Point(21, 223)
        Me.lblReceiptDate.Name = "lblReceiptDate"
        Me.lblReceiptDate.Size = New System.Drawing.Size(402, 55)
        Me.lblReceiptDate.StateCommon.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDate.Text = "January 5, 2010"
        Me.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReceiptAmount
        '
        Me.lblReceiptAmount.AutoSize = False
        Me.lblReceiptAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptAmount.ForeColor = System.Drawing.Color.Blue
        Me.lblReceiptAmount.Location = New System.Drawing.Point(17, 278)
        Me.lblReceiptAmount.Name = "lblReceiptAmount"
        Me.lblReceiptAmount.Size = New System.Drawing.Size(402, 55)
        Me.lblReceiptAmount.StateCommon.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptAmount.StateCommon.TextColor = System.Drawing.Color.Blue
        Me.lblReceiptAmount.Text = "100,000.00"
        Me.lblReceiptAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.chkOverrideReceiptNumber)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(20, 100)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnCustom1
        Me.KryptonPanel1.Size = New System.Drawing.Size(395, 37)
        Me.KryptonPanel1.TabIndex = 11
        '
        'chkOverrideReceiptNumber
        '
        Me.chkOverrideReceiptNumber.Location = New System.Drawing.Point(122, 6)
        Me.chkOverrideReceiptNumber.Name = "chkOverrideReceiptNumber"
        Me.chkOverrideReceiptNumber.Size = New System.Drawing.Size(167, 19)
        Me.chkOverrideReceiptNumber.TabIndex = 7
        Me.chkOverrideReceiptNumber.Values.Text = "OVERRIDE RECEIPT NUMBER"
        '
        'txtReceiptNumber
        '
        Me.txtReceiptNumber.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtReceiptNumber.Location = New System.Drawing.Point(20, 20)
        Me.txtReceiptNumber.MaxLength = 6
        Me.txtReceiptNumber.Name = "txtReceiptNumber"
        Me.txtReceiptNumber.Size = New System.Drawing.Size(395, 80)
        Me.txtReceiptNumber.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtReceiptNumber.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptNumber.TabIndex = 3
        Me.txtReceiptNumber.Text = "000564"
        Me.txtReceiptNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(124, 342)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 40)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "PRINT"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(258, 342)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(83, 40)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Values.Text = "CANCEL"
        '
        'ReceiptVerificationForm
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ReceiptVerificationForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECEIPT VERIFICATION"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents txtReceiptNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblReceiptDate As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents lblReceiptAmount As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkOverrideReceiptNumber As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblAmountChange As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtAmountReceived As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnReset As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents lblUnitOwnerName As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonWrapLabel1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
End Class
