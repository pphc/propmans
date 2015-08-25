<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlMeterListingReportOption
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
        Me.pnlMeterListingParams = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonCheckBox1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkReconnected = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkInactiveAccounts = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkVoultaryDisconnected = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkTemporaryDisconnected = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkActive = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.chkNew = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        CType(Me.pnlMeterListingParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMeterListingParams.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMeterListingParams
        '
        Me.pnlMeterListingParams.Controls.Add(Me.KryptonLabel6)
        Me.pnlMeterListingParams.Controls.Add(Me.KryptonCheckBox1)
        Me.pnlMeterListingParams.Controls.Add(Me.chkReconnected)
        Me.pnlMeterListingParams.Controls.Add(Me.chkInactiveAccounts)
        Me.pnlMeterListingParams.Controls.Add(Me.chkVoultaryDisconnected)
        Me.pnlMeterListingParams.Controls.Add(Me.chkTemporaryDisconnected)
        Me.pnlMeterListingParams.Controls.Add(Me.chkActive)
        Me.pnlMeterListingParams.Controls.Add(Me.chkNew)
        Me.pnlMeterListingParams.Location = New System.Drawing.Point(0, 0)
        Me.pnlMeterListingParams.Name = "pnlMeterListingParams"
        Me.pnlMeterListingParams.Size = New System.Drawing.Size(681, 172)
        Me.pnlMeterListingParams.TabIndex = 11
        '
        'KryptonCheckBox1
        '
        Me.KryptonCheckBox1.Location = New System.Drawing.Point(209, 81)
        Me.KryptonCheckBox1.Name = "KryptonCheckBox1"
        Me.KryptonCheckBox1.Size = New System.Drawing.Size(168, 19)
        Me.KryptonCheckBox1.TabIndex = 7
        Me.KryptonCheckBox1.Tag = "TEMC"
        Me.KryptonCheckBox1.Values.Text = "TEMPORARY (CONDO DUES)"
        '
        'chkReconnected
        '
        Me.chkReconnected.Location = New System.Drawing.Point(45, 106)
        Me.chkReconnected.Name = "chkReconnected"
        Me.chkReconnected.Size = New System.Drawing.Size(101, 19)
        Me.chkReconnected.TabIndex = 6
        Me.chkReconnected.Tag = "REC"
        Me.chkReconnected.Values.Text = "RECONNECTED"
        '
        'chkInactiveAccounts
        '
        Me.chkInactiveAccounts.Location = New System.Drawing.Point(407, 56)
        Me.chkInactiveAccounts.Name = "chkInactiveAccounts"
        Me.chkInactiveAccounts.Size = New System.Drawing.Size(108, 19)
        Me.chkInactiveAccounts.TabIndex = 5
        Me.chkInactiveAccounts.Tag = "PERM"
        Me.chkInactiveAccounts.Values.Text = "INACTIVE METER"
        '
        'chkVoultaryDisconnected
        '
        Me.chkVoultaryDisconnected.Location = New System.Drawing.Point(209, 106)
        Me.chkVoultaryDisconnected.Name = "chkVoultaryDisconnected"
        Me.chkVoultaryDisconnected.Size = New System.Drawing.Size(172, 19)
        Me.chkVoultaryDisconnected.TabIndex = 4
        Me.chkVoultaryDisconnected.Tag = "VOLM"
        Me.chkVoultaryDisconnected.Values.Text = "VOLUNTARY DISCONNECTED"
        '
        'chkTemporaryDisconnected
        '
        Me.chkTemporaryDisconnected.Location = New System.Drawing.Point(209, 56)
        Me.chkTemporaryDisconnected.Name = "chkTemporaryDisconnected"
        Me.chkTemporaryDisconnected.Size = New System.Drawing.Size(133, 19)
        Me.chkTemporaryDisconnected.TabIndex = 3
        Me.chkTemporaryDisconnected.Tag = "TEMW"
        Me.chkTemporaryDisconnected.Values.Text = "TEMPORARY (WATER)"
        '
        'chkActive
        '
        Me.chkActive.Location = New System.Drawing.Point(45, 56)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(59, 19)
        Me.chkActive.TabIndex = 2
        Me.chkActive.Tag = "ACT"
        Me.chkActive.Values.Text = "ACTIVE"
        '
        'chkNew
        '
        Me.chkNew.Location = New System.Drawing.Point(45, 81)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(48, 19)
        Me.chkNew.TabIndex = 1
        Me.chkNew.Tag = "NEW"
        Me.chkNew.Values.Text = "NEW"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(32, 22)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(228, 19)
        Me.KryptonLabel6.TabIndex = 8
        Me.KryptonLabel6.Values.Text = "SELECT CONNECTION STATUS TO DISPLAY."
        '
        'MeterListingReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlMeterListingParams)
        Me.Name = "MeterListingReportOption"
        CType(Me.pnlMeterListingParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMeterListingParams.ResumeLayout(False)
        Me.pnlMeterListingParams.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMeterListingParams As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonCheckBox1 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkReconnected As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkInactiveAccounts As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkVoultaryDisconnected As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkTemporaryDisconnected As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkActive As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkNew As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
