<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlAccountReceivableReportOption
    Inherits ReportOptionBaseControl

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
        Me.pnlBillingSummary = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboBillingFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel23 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboBillMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel24 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpPaymentCutOff = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        CType(Me.pnlBillingSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBillingSummary.SuspendLayout()
        CType(Me.cboBillingFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBillMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBillingSummary
        '
        Me.pnlBillingSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBillingSummary.Controls.Add(Me.dtpPaymentCutOff)
        Me.pnlBillingSummary.Controls.Add(Me.KryptonLabel1)
        Me.pnlBillingSummary.Controls.Add(Me.cboBillingFeeType)
        Me.pnlBillingSummary.Controls.Add(Me.KryptonLabel23)
        Me.pnlBillingSummary.Controls.Add(Me.cboBillMonth)
        Me.pnlBillingSummary.Controls.Add(Me.KryptonLabel24)
        Me.pnlBillingSummary.Location = New System.Drawing.Point(0, 0)
        Me.pnlBillingSummary.Name = "pnlBillingSummary"
        Me.pnlBillingSummary.Size = New System.Drawing.Size(670, 169)
        Me.pnlBillingSummary.TabIndex = 29
        '
        'cboBillingFeeType
        '
        Me.cboBillingFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingFeeType.DropDownWidth = 121
        Me.cboBillingFeeType.Location = New System.Drawing.Point(135, 13)
        Me.cboBillingFeeType.Name = "cboBillingFeeType"
        Me.cboBillingFeeType.Size = New System.Drawing.Size(265, 21)
        Me.cboBillingFeeType.TabIndex = 21
        '
        'KryptonLabel23
        '
        Me.KryptonLabel23.Location = New System.Drawing.Point(33, 41)
        Me.KryptonLabel23.Name = "KryptonLabel23"
        Me.KryptonLabel23.Size = New System.Drawing.Size(104, 20)
        Me.KryptonLabel23.TabIndex = 19
        Me.KryptonLabel23.Values.Text = "BILLING MONTH:"
        '
        'cboBillMonth
        '
        Me.cboBillMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillMonth.DropDownWidth = 121
        Me.cboBillMonth.Location = New System.Drawing.Point(135, 41)
        Me.cboBillMonth.Name = "cboBillMonth"
        Me.cboBillMonth.Size = New System.Drawing.Size(265, 21)
        Me.cboBillMonth.TabIndex = 18
        '
        'KryptonLabel24
        '
        Me.KryptonLabel24.Location = New System.Drawing.Point(72, 16)
        Me.KryptonLabel24.Name = "KryptonLabel24"
        Me.KryptonLabel24.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel24.TabIndex = 16
        Me.KryptonLabel24.Values.Text = "FEE TYPE:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(19, 69)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(120, 20)
        Me.KryptonLabel1.TabIndex = 22
        Me.KryptonLabel1.Values.Text = "PAYMENT CUT-OFF:"
        '
        'dtpPaymentCutOff
        '
        Me.dtpPaymentCutOff.Location = New System.Drawing.Point(135, 68)
        Me.dtpPaymentCutOff.Name = "dtpPaymentCutOff"
        Me.dtpPaymentCutOff.Size = New System.Drawing.Size(265, 21)
        Me.dtpPaymentCutOff.TabIndex = 23
        '
        'CtlAccountReceivableReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlBillingSummary)
        Me.Name = "CtlAccountReceivableReportOption"
        Me.Size = New System.Drawing.Size(670, 159)
        CType(Me.pnlBillingSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBillingSummary.ResumeLayout(False)
        Me.pnlBillingSummary.PerformLayout()
        CType(Me.cboBillingFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBillMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBillingSummary As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents cboBillingFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel23 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboBillMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel24 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpPaymentCutOff As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker

End Class
