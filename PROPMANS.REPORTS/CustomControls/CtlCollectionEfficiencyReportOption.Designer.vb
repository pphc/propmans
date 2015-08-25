<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlCollectionEfficiencyReportOption
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
        Me.pnlCER = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpCERStartDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.cboCERFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel25 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCERBillMonth = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel26 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtpCEREndDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        CType(Me.pnlCER, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCER.SuspendLayout()
        CType(Me.cboCERFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCERBillMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCER
        '
        Me.pnlCER.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCER.Controls.Add(Me.KryptonLabel4)
        Me.pnlCER.Controls.Add(Me.KryptonLabel1)
        Me.pnlCER.Controls.Add(Me.KryptonLabel11)
        Me.pnlCER.Controls.Add(Me.dtpCERStartDate)
        Me.pnlCER.Controls.Add(Me.cboCERFeeType)
        Me.pnlCER.Controls.Add(Me.KryptonLabel25)
        Me.pnlCER.Controls.Add(Me.cboCERBillMonth)
        Me.pnlCER.Controls.Add(Me.KryptonLabel26)
        Me.pnlCER.Controls.Add(Me.dtpCEREndDate)
        Me.pnlCER.Location = New System.Drawing.Point(0, 0)
        Me.pnlCER.Name = "pnlCER"
        Me.pnlCER.Size = New System.Drawing.Size(681, 169)
        Me.pnlCER.TabIndex = 30
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(121, 123)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(29, 20)
        Me.KryptonLabel4.TabIndex = 37
        Me.KryptonLabel4.Values.Text = "TO:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(103, 97)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(47, 20)
        Me.KryptonLabel1.TabIndex = 36
        Me.KryptonLabel1.Values.Text = "FROM:"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(23, 71)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(127, 20)
        Me.KryptonLabel11.TabIndex = 35
        Me.KryptonLabel11.Values.Text = "COLLECTION PERIOD"
        '
        'dtpCERStartDate
        '
        Me.dtpCERStartDate.Location = New System.Drawing.Point(156, 95)
        Me.dtpCERStartDate.Name = "dtpCERStartDate"
        Me.dtpCERStartDate.Size = New System.Drawing.Size(307, 21)
        Me.dtpCERStartDate.TabIndex = 23
        '
        'cboCERFeeType
        '
        Me.cboCERFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCERFeeType.DropDownWidth = 121
        Me.cboCERFeeType.Location = New System.Drawing.Point(156, 13)
        Me.cboCERFeeType.Name = "cboCERFeeType"
        Me.cboCERFeeType.Size = New System.Drawing.Size(307, 21)
        Me.cboCERFeeType.TabIndex = 21
        Me.cboCERFeeType.Tag = "cer"
        '
        'KryptonLabel25
        '
        Me.KryptonLabel25.Location = New System.Drawing.Point(46, 43)
        Me.KryptonLabel25.Name = "KryptonLabel25"
        Me.KryptonLabel25.Size = New System.Drawing.Size(104, 20)
        Me.KryptonLabel25.TabIndex = 19
        Me.KryptonLabel25.Values.Text = "BILLING MONTH:"
        '
        'cboCERBillMonth
        '
        Me.cboCERBillMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCERBillMonth.DropDownWidth = 121
        Me.cboCERBillMonth.Location = New System.Drawing.Point(156, 41)
        Me.cboCERBillMonth.Name = "cboCERBillMonth"
        Me.cboCERBillMonth.Size = New System.Drawing.Size(307, 21)
        Me.cboCERBillMonth.TabIndex = 18
        '
        'KryptonLabel26
        '
        Me.KryptonLabel26.Location = New System.Drawing.Point(88, 13)
        Me.KryptonLabel26.Name = "KryptonLabel26"
        Me.KryptonLabel26.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel26.TabIndex = 16
        Me.KryptonLabel26.Values.Text = "FEE TYPE:"
        '
        'dtpCEREndDate
        '
        Me.dtpCEREndDate.Location = New System.Drawing.Point(156, 122)
        Me.dtpCEREndDate.Name = "dtpCEREndDate"
        Me.dtpCEREndDate.Size = New System.Drawing.Size(307, 21)
        Me.dtpCEREndDate.TabIndex = 11
        '
        'CtlCollectionEfficiencyReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlCER)
        Me.Name = "CtlCollectionEfficiencyReportOption"
        CType(Me.pnlCER, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCER.ResumeLayout(False)
        Me.pnlCER.PerformLayout()
        CType(Me.cboCERFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCERBillMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCER As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dtpCERStartDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents cboCERFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel25 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCERBillMonth As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel26 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpCEREndDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
