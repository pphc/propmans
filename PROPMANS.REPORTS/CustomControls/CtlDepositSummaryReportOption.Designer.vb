<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlDepositSummaryReportOption
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
        Me.pnlDepositDetail = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.dgDepositList = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.btnViewDeposits = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.dtpDepositEndDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.dtpDepositStartDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        CType(Me.pnlDepositDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDepositDetail.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dgDepositList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDepositDetail
        '
        Me.pnlDepositDetail.Controls.Add(Me.KryptonPanel1)
        Me.pnlDepositDetail.Controls.Add(Me.btnViewDeposits)
        Me.pnlDepositDetail.Controls.Add(Me.dtpDepositEndDate)
        Me.pnlDepositDetail.Controls.Add(Me.KryptonLabel8)
        Me.pnlDepositDetail.Controls.Add(Me.dtpDepositStartDate)
        Me.pnlDepositDetail.Controls.Add(Me.KryptonLabel9)
        Me.pnlDepositDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDepositDetail.Location = New System.Drawing.Point(0, 0)
        Me.pnlDepositDetail.Name = "pnlDepositDetail"
        Me.pnlDepositDetail.Size = New System.Drawing.Size(755, 162)
        Me.pnlDepositDetail.TabIndex = 13
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dgDepositList)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 64)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonPanel1.Size = New System.Drawing.Size(755, 98)
        Me.KryptonPanel1.TabIndex = 16
        '
        'dgDepositList
        '
        Me.dgDepositList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDepositList.Location = New System.Drawing.Point(10, 10)
        Me.dgDepositList.Name = "dgDepositList"
        Me.dgDepositList.Size = New System.Drawing.Size(735, 78)
        Me.dgDepositList.TabIndex = 16
        '
        'btnViewDeposits
        '
        Me.btnViewDeposits.Location = New System.Drawing.Point(360, 11)
        Me.btnViewDeposits.Name = "btnViewDeposits"
        Me.btnViewDeposits.Size = New System.Drawing.Size(104, 35)
        Me.btnViewDeposits.TabIndex = 15
        Me.btnViewDeposits.Values.Text = "VIEW DEPOSITS"
        '
        'dtpDepositEndDate
        '
        Me.dtpDepositEndDate.Location = New System.Drawing.Point(143, 36)
        Me.dtpDepositEndDate.Name = "dtpDepositEndDate"
        Me.dtpDepositEndDate.Size = New System.Drawing.Size(211, 20)
        Me.dtpDepositEndDate.TabIndex = 13
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(110, 36)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(27, 19)
        Me.KryptonLabel8.TabIndex = 12
        Me.KryptonLabel8.Values.Text = "TO:"
        '
        'dtpDepositStartDate
        '
        Me.dtpDepositStartDate.Location = New System.Drawing.Point(143, 10)
        Me.dtpDepositStartDate.Name = "dtpDepositStartDate"
        Me.dtpDepositStartDate.Size = New System.Drawing.Size(211, 20)
        Me.dtpDepositStartDate.TabIndex = 11
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(17, 11)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(120, 19)
        Me.KryptonLabel9.TabIndex = 10
        Me.KryptonLabel9.Values.Text = "DEPOSIT DATE FROM:"
        '
        'CtlDepositSummaryReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlDepositDetail)
        Me.Name = "CtlDepositSummaryReportOption"
        Me.Size = New System.Drawing.Size(755, 162)
        CType(Me.pnlDepositDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDepositDetail.ResumeLayout(False)
        Me.pnlDepositDetail.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.dgDepositList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDepositDetail As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnViewDeposits As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpDepositEndDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpDepositStartDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgDepositList As ComponentFactory.Krypton.Toolkit.KryptonDataGridView

End Class
