<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlMeterReadingReportOption
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
        Me.pnlMeterReadings = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.cboBillingMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.YesRadioButton = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton
        Me.NoRadioButton = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton
        CType(Me.pnlMeterReadings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMeterReadings.SuspendLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMeterReadings
        '
        Me.pnlMeterReadings.Controls.Add(Me.NoRadioButton)
        Me.pnlMeterReadings.Controls.Add(Me.YesRadioButton)
        Me.pnlMeterReadings.Controls.Add(Me.KryptonLabel1)
        Me.pnlMeterReadings.Controls.Add(Me.cboBillingMonth)
        Me.pnlMeterReadings.Controls.Add(Me.KryptonLabel7)
        Me.pnlMeterReadings.Location = New System.Drawing.Point(0, 0)
        Me.pnlMeterReadings.Name = "pnlMeterReadings"
        Me.pnlMeterReadings.Size = New System.Drawing.Size(681, 172)
        Me.pnlMeterReadings.TabIndex = 12
        '
        'cboBillingMonth
        '
        Me.cboBillingMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingMonth.DropDownWidth = 223
        Me.cboBillingMonth.Location = New System.Drawing.Point(136, 13)
        Me.cboBillingMonth.Name = "cboBillingMonth"
        Me.cboBillingMonth.Size = New System.Drawing.Size(223, 22)
        Me.cboBillingMonth.TabIndex = 6
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(34, 16)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(96, 19)
        Me.KryptonLabel7.TabIndex = 5
        Me.KryptonLabel7.Values.Text = "BILLING MONTH:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(34, 56)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(116, 19)
        Me.KryptonLabel1.TabIndex = 7
        Me.KryptonLabel1.Values.Text = "DISPLAY ALL UNITS ? "
        '
        'YesRadioButton
        '
        Me.YesRadioButton.Checked = True
        Me.YesRadioButton.Location = New System.Drawing.Point(156, 56)
        Me.YesRadioButton.Name = "YesRadioButton"
        Me.YesRadioButton.Size = New System.Drawing.Size(40, 19)
        Me.YesRadioButton.TabIndex = 8
        Me.YesRadioButton.Values.Text = "YES"
        '
        'NoRadioButton
        '
        Me.NoRadioButton.Location = New System.Drawing.Point(202, 56)
        Me.NoRadioButton.Name = "NoRadioButton"
        Me.NoRadioButton.Size = New System.Drawing.Size(39, 19)
        Me.NoRadioButton.TabIndex = 9
        Me.NoRadioButton.Values.Text = "NO"
        '
        'CtlMeterReadingReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlMeterReadings)
        Me.Name = "CtlMeterReadingReportOption"
        CType(Me.pnlMeterReadings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMeterReadings.ResumeLayout(False)
        Me.pnlMeterReadings.PerformLayout()
        CType(Me.cboBillingMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMeterReadings As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents cboBillingMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents NoRadioButton As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents YesRadioButton As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
