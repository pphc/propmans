<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayReceipts
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
        Me.VehiclesInformationgbox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dgReceipts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.btnSelect = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.VehiclesInformationgbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VehiclesInformationgbox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VehiclesInformationgbox.Panel.SuspendLayout()
        Me.VehiclesInformationgbox.SuspendLayout()
        CType(Me.dgReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.VehiclesInformationgbox)
        Me.KryptonPanel.Controls.Add(Me.btnSelect)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Margin = New System.Windows.Forms.Padding(25)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel.Size = New System.Drawing.Size(1064, 240)
        Me.KryptonPanel.TabIndex = 0
        '
        'VehiclesInformationgbox
        '
        Me.VehiclesInformationgbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.VehiclesInformationgbox.Location = New System.Drawing.Point(5, 5)
        Me.VehiclesInformationgbox.Name = "VehiclesInformationgbox"
        '
        'VehiclesInformationgbox.Panel
        '
        Me.VehiclesInformationgbox.Panel.Controls.Add(Me.dgReceipts)
        Me.VehiclesInformationgbox.Panel.Padding = New System.Windows.Forms.Padding(5)
        Me.VehiclesInformationgbox.Size = New System.Drawing.Size(1054, 178)
        Me.VehiclesInformationgbox.TabIndex = 46
        Me.VehiclesInformationgbox.Text = "SELECT OFFICIAL RECEIPT"
        Me.VehiclesInformationgbox.Values.Heading = "SELECT OFFICIAL RECEIPT"
        '
        'dgReceipts
        '
        Me.dgReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReceipts.Location = New System.Drawing.Point(5, 5)
        Me.dgReceipts.MultiSelect = False
        Me.dgReceipts.Name = "dgReceipts"
        Me.dgReceipts.ReadOnly = True
        Me.dgReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReceipts.Size = New System.Drawing.Size(1040, 144)
        Me.dgReceipts.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(983, 192)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(76, 36)
        Me.btnSelect.TabIndex = 45
        Me.btnSelect.Values.Text = "&SELECT"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DisplayReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 240)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DisplayReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MULTIPLE RECEIPTS DISPLAY"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.VehiclesInformationgbox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VehiclesInformationgbox.Panel.ResumeLayout(False)
        CType(Me.VehiclesInformationgbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VehiclesInformationgbox.ResumeLayout(False)
        CType(Me.dgReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents btnSelect As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents VehiclesInformationgbox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgReceipts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
End Class
