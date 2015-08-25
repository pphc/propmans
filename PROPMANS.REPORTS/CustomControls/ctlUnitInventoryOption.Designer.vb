<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlUnitInventoryOption
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
        Me.pnlMeterListingParams = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chklistBox = New System.Windows.Forms.CheckedListBox()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.pnlMeterListingParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMeterListingParams.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMeterListingParams
        '
        Me.pnlMeterListingParams.Controls.Add(Me.KryptonLabel12)
        Me.pnlMeterListingParams.Controls.Add(Me.chkSelectAll)
        Me.pnlMeterListingParams.Controls.Add(Me.chklistBox)
        Me.pnlMeterListingParams.Location = New System.Drawing.Point(0, 0)
        Me.pnlMeterListingParams.Name = "pnlMeterListingParams"
        Me.pnlMeterListingParams.Size = New System.Drawing.Size(681, 172)
        Me.pnlMeterListingParams.TabIndex = 11
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(14, 120)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 7
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'chklistBox
        '
        Me.chklistBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chklistBox.CheckOnClick = True
        Me.chklistBox.ColumnWidth = 150
        Me.chklistBox.FormattingEnabled = True
        Me.chklistBox.Location = New System.Drawing.Point(14, 35)
        Me.chklistBox.MultiColumn = True
        Me.chklistBox.Name = "chklistBox"
        Me.chklistBox.Size = New System.Drawing.Size(649, 79)
        Me.chklistBox.TabIndex = 6
        Me.chklistBox.ThreeDCheckBoxes = True
        Me.chklistBox.UseCompatibleTextRendering = True
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(14, 11)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(110, 20)
        Me.KryptonLabel12.TabIndex = 29
        Me.KryptonLabel12.Values.Text = "SELECT BUILDING:"
        '
        'ctlUnitInventoryOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlMeterListingParams)
        Me.Name = "ctlUnitInventoryOption"
        CType(Me.pnlMeterListingParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMeterListingParams.ResumeLayout(False)
        Me.pnlMeterListingParams.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMeterListingParams As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chklistBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
