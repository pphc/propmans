<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrinventoryForm
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
        Me.components = New System.ComponentModel.Container()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.ContractOfLeaseHeader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnNewBatch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgORSeries = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.cboCompanyDivision = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dgORSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCompanyDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.ContractOfLeaseHeader)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(976, 598)
        Me.KryptonPanel.TabIndex = 0
        '
        'ContractOfLeaseHeader
        '
        Me.ContractOfLeaseHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.ContractOfLeaseHeader.Location = New System.Drawing.Point(0, 0)
        Me.ContractOfLeaseHeader.Name = "ContractOfLeaseHeader"
        Me.ContractOfLeaseHeader.Size = New System.Drawing.Size(976, 31)
        Me.ContractOfLeaseHeader.TabIndex = 7
        Me.ContractOfLeaseHeader.Values.Description = ""
        Me.ContractOfLeaseHeader.Values.Heading = "OFFICIAL RECEIPTS INVENTORY"
        Me.ContractOfLeaseHeader.Values.Image = Nothing
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnNewBatch)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.cboCompanyDivision)
        Me.KryptonPanel1.Location = New System.Drawing.Point(167, 85)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(690, 435)
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnNewBatch
        '
        Me.btnNewBatch.Location = New System.Drawing.Point(23, 312)
        Me.btnNewBatch.Name = "btnNewBatch"
        Me.btnNewBatch.Size = New System.Drawing.Size(90, 37)
        Me.btnNewBatch.TabIndex = 2
        Me.btnNewBatch.Values.Text = "NEW SERIES"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dgORSeries)
        Me.KryptonPanel2.Location = New System.Drawing.Point(22, 47)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.KryptonPanel2.Size = New System.Drawing.Size(627, 259)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.KryptonPanel2.TabIndex = 1
        '
        'dgORSeries
        '
        Me.dgORSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgORSeries.Location = New System.Drawing.Point(1, 1)
        Me.dgORSeries.Name = "dgORSeries"
        Me.dgORSeries.Size = New System.Drawing.Size(625, 257)
        Me.dgORSeries.TabIndex = 0
        '
        'cboCompanyDivision
        '
        Me.cboCompanyDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompanyDivision.DropDownWidth = 280
        Me.cboCompanyDivision.Location = New System.Drawing.Point(22, 19)
        Me.cboCompanyDivision.Name = "cboCompanyDivision"
        Me.cboCompanyDivision.Size = New System.Drawing.Size(280, 21)
        Me.cboCompanyDivision.TabIndex = 0
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'OrinventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 598)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "OrinventoryForm"
        Me.Text = "O.R Inventory"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.dgORSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCompanyDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnNewBatch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgORSeries As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents cboCompanyDivision As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents ContractOfLeaseHeader As ComponentFactory.Krypton.Toolkit.KryptonHeader
End Class
