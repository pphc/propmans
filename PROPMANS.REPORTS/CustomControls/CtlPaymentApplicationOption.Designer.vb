<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlPaymentApplicationOption
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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblUnitNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblCustomerName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboFeeType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearchCustomer = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dtpCutOffDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.lblUnitNumber)
        Me.KryptonPanel1.Controls.Add(Me.lblCustomerName)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel1.Controls.Add(Me.cboFeeType)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel1.Controls.Add(Me.btnSearchCustomer)
        Me.KryptonPanel1.Controls.Add(Me.dtpCutOffDate)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(681, 172)
        Me.KryptonPanel1.TabIndex = 1
        '
        'lblUnitNumber
        '
        Me.lblUnitNumber.AutoSize = False
        Me.lblUnitNumber.Location = New System.Drawing.Point(128, 8)
        Me.lblUnitNumber.Name = "lblUnitNumber"
        Me.lblUnitNumber.Size = New System.Drawing.Size(357, 32)
        Me.lblUnitNumber.TabIndex = 33
        Me.lblUnitNumber.Values.Text = ""
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = False
        Me.lblCustomerName.Location = New System.Drawing.Point(128, 41)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(381, 28)
        Me.lblCustomerName.TabIndex = 32
        Me.lblCustomerName.Values.Text = ""
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(65, 71)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel13.TabIndex = 31
        Me.KryptonLabel13.Values.Text = "FEE TYPE:"
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 121
        Me.cboFeeType.Location = New System.Drawing.Point(128, 71)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(265, 21)
        Me.cboFeeType.TabIndex = 30
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(36, 16)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(94, 20)
        Me.KryptonLabel12.TabIndex = 28
        Me.KryptonLabel12.Values.Text = "UNIT NUMBER:"
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.Location = New System.Drawing.Point(515, 16)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(80, 35)
        Me.btnSearchCustomer.TabIndex = 27
        Me.btnSearchCustomer.Values.Text = "SEARCH"
        '
        'dtpCutOffDate
        '
        Me.dtpCutOffDate.Location = New System.Drawing.Point(128, 110)
        Me.dtpCutOffDate.Name = "dtpCutOffDate"
        Me.dtpCutOffDate.Size = New System.Drawing.Size(265, 21)
        Me.dtpCutOffDate.TabIndex = 24
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(34, 111)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel11.TabIndex = 23
        Me.KryptonLabel11.Values.Text = "CUT OFF DATE:"
        '
        'CtlPaymentApplicationOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Name = "CtlPaymentApplicationOption"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.cboFeeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblCustomerName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboFeeType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearchCustomer As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpCutOffDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblUnitNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
