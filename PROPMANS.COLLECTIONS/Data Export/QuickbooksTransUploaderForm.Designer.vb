<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickbooksTransUploaderForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox3 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtUploadID = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnSearchUploads = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.txtUploadStatus = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtUploadedOn = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtUploadedBy = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnExportInterface = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNewUpload = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnViewUploadReport = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnTestConnection = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancelUpload = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblFileName = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnInvoices = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblTotalInvoiceAmount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgInvoices = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnPayments = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblTotalPayments = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ActivitiesPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgPayments = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.PaymentTypeFilterPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboTransactionType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.moduleheader = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox3.Panel.SuspendLayout()
        Me.KryptonGroupBox3.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.ActivitiesPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActivitiesPanel.SuspendLayout()
        CType(Me.dgPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTypeFilterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaymentTypeFilterPanel.SuspendLayout()
        CType(Me.cboTransactionType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.moduleheader)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(1009, 675)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 39)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(20)
        Me.KryptonPanel1.Size = New System.Drawing.Size(1009, 636)
        Me.KryptonPanel1.TabIndex = 26
        '
        'KryptonGroupBox3
        '
        Me.KryptonGroupBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.KryptonGroupBox3.Location = New System.Drawing.Point(23, 6)
        Me.KryptonGroupBox3.Name = "KryptonGroupBox3"
        '
        'KryptonGroupBox3.Panel
        '
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.txtUploadID)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.txtUploadStatus)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.txtUploadedOn)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.txtUploadedBy)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.KryptonLabel10)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.KryptonLabel9)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.KryptonLabel8)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox3.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonGroupBox3.Size = New System.Drawing.Size(954, 98)
        Me.KryptonGroupBox3.TabIndex = 8
        Me.KryptonGroupBox3.Text = "UPLOAD INFO"
        Me.KryptonGroupBox3.Values.Heading = "UPLOAD INFO"
        '
        'txtUploadID
        '
        Me.txtUploadID.AlwaysActive = False
        Me.txtUploadID.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnSearchUploads})
        Me.txtUploadID.Location = New System.Drawing.Point(127, 12)
        Me.txtUploadID.Name = "txtUploadID"
        Me.txtUploadID.ReadOnly = True
        Me.txtUploadID.Size = New System.Drawing.Size(188, 21)
        Me.txtUploadID.TabIndex = 41
        Me.txtUploadID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSearchUploads
        '
        Me.btnSearchUploads.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone
        Me.btnSearchUploads.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Context
        Me.btnSearchUploads.UniqueName = "F43B05A1570E401448A483FA095E2ED0"
        '
        'txtUploadStatus
        '
        Me.txtUploadStatus.AlwaysActive = False
        Me.txtUploadStatus.Location = New System.Drawing.Point(127, 39)
        Me.txtUploadStatus.Name = "txtUploadStatus"
        Me.txtUploadStatus.ReadOnly = True
        Me.txtUploadStatus.Size = New System.Drawing.Size(185, 20)
        Me.txtUploadStatus.TabIndex = 40
        '
        'txtUploadedOn
        '
        Me.txtUploadedOn.AlwaysActive = False
        Me.txtUploadedOn.Location = New System.Drawing.Point(755, 39)
        Me.txtUploadedOn.Name = "txtUploadedOn"
        Me.txtUploadedOn.ReadOnly = True
        Me.txtUploadedOn.Size = New System.Drawing.Size(185, 20)
        Me.txtUploadedOn.TabIndex = 39
        '
        'txtUploadedBy
        '
        Me.txtUploadedBy.AlwaysActive = False
        Me.txtUploadedBy.Location = New System.Drawing.Point(755, 13)
        Me.txtUploadedBy.Name = "txtUploadedBy"
        Me.txtUploadedBy.ReadOnly = True
        Me.txtUploadedBy.Size = New System.Drawing.Size(185, 20)
        Me.txtUploadedBy.TabIndex = 38
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(15, 39)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel10.TabIndex = 37
        Me.KryptonLabel10.Values.Text = "UPLOAD STATUS:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(652, 39)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(97, 20)
        Me.KryptonLabel9.TabIndex = 36
        Me.KryptonLabel9.Values.Text = "UPLOADED ON:"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(656, 13)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel8.TabIndex = 35
        Me.KryptonLabel8.Values.Text = "UPLOADED BY:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(45, 12)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel1.TabIndex = 2
        Me.KryptonLabel1.Values.Text = "UPLOAD ID:"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(23, 507)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnExportInterface)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnNewUpload)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnViewUploadReport)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnTestConnection)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnCancelUpload)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblFileName)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(954, 113)
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'btnExportInterface
        '
        Me.btnExportInterface.Location = New System.Drawing.Point(10, 55)
        Me.btnExportInterface.Name = "btnExportInterface"
        Me.btnExportInterface.Size = New System.Drawing.Size(187, 35)
        Me.btnExportInterface.TabIndex = 46
        Me.btnExportInterface.Values.Text = "EXPORT MAPPING INTERFACE"
        '
        'btnNewUpload
        '
        Me.btnNewUpload.Location = New System.Drawing.Point(820, 12)
        Me.btnNewUpload.Name = "btnNewUpload"
        Me.btnNewUpload.Size = New System.Drawing.Size(119, 37)
        Me.btnNewUpload.TabIndex = 45
        Me.btnNewUpload.Values.Text = "NEW UPLOAD"
        '
        'btnViewUploadReport
        '
        Me.btnViewUploadReport.Location = New System.Drawing.Point(10, 14)
        Me.btnViewUploadReport.Name = "btnViewUploadReport"
        Me.btnViewUploadReport.Size = New System.Drawing.Size(157, 35)
        Me.btnViewUploadReport.TabIndex = 44
        Me.btnViewUploadReport.Values.Text = "VIEW UPLOAD REPORT"
        Me.btnViewUploadReport.Visible = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(672, 55)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(142, 40)
        Me.btnTestConnection.TabIndex = 8
        Me.btnTestConnection.Values.Text = "TEST QB CONNECTION"
        Me.btnTestConnection.Visible = False
        '
        'btnCancelUpload
        '
        Me.btnCancelUpload.Location = New System.Drawing.Point(820, 55)
        Me.btnCancelUpload.Name = "btnCancelUpload"
        Me.btnCancelUpload.Size = New System.Drawing.Size(120, 40)
        Me.btnCancelUpload.TabIndex = 3
        Me.btnCancelUpload.Values.Text = "CANCEL"
        Me.btnCancelUpload.Visible = False
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(73, 47)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(6, 2)
        Me.lblFileName.TabIndex = 6
        Me.lblFileName.Values.Text = ""
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(23, 110)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.TabControl1)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(954, 391)
        Me.KryptonGroupBox2.TabIndex = 0
        Me.KryptonGroupBox2.Text = "UPLOAD DETAILS"
        Me.KryptonGroupBox2.Values.Heading = "UPLOAD DETAILS"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(10, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(930, 347)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.KryptonPanel5)
        Me.TabPage1.Controls.Add(Me.KryptonPanel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(922, 321)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "INVOICES"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.btnInvoices)
        Me.KryptonPanel5.Controls.Add(Me.lblTotalInvoiceAmount)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel5.Location = New System.Drawing.Point(3, 268)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(916, 50)
        Me.KryptonPanel5.TabIndex = 10
        '
        'btnInvoices
        '
        Me.btnInvoices.Location = New System.Drawing.Point(15, 5)
        Me.btnInvoices.Name = "btnInvoices"
        Me.btnInvoices.Size = New System.Drawing.Size(107, 35)
        Me.btnInvoices.TabIndex = 43
        Me.btnInvoices.Values.Text = "INVOICES"
        Me.btnInvoices.Visible = False
        '
        'lblTotalInvoiceAmount
        '
        Me.lblTotalInvoiceAmount.AutoSize = False
        Me.lblTotalInvoiceAmount.Location = New System.Drawing.Point(766, 19)
        Me.lblTotalInvoiceAmount.Name = "lblTotalInvoiceAmount"
        Me.lblTotalInvoiceAmount.Size = New System.Drawing.Size(147, 21)
        Me.lblTotalInvoiceAmount.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkBlue
        Me.lblTotalInvoiceAmount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalInvoiceAmount.TabIndex = 42
        Me.lblTotalInvoiceAmount.Values.Text = "0.00"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(655, 19)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(105, 20)
        Me.KryptonLabel3.TabIndex = 41
        Me.KryptonLabel3.Values.Text = "TOTAL AMOUNT:"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.dgInvoices)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.KryptonPanel3.Size = New System.Drawing.Size(916, 264)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.RoyalBlue
        Me.KryptonPanel3.TabIndex = 9
        '
        'dgInvoices
        '
        Me.dgInvoices.AllowUserToAddRows = False
        Me.dgInvoices.AllowUserToDeleteRows = False
        Me.dgInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgInvoices.Location = New System.Drawing.Point(1, 1)
        Me.dgInvoices.Name = "dgInvoices"
        Me.dgInvoices.ReadOnly = True
        Me.dgInvoices.Size = New System.Drawing.Size(914, 262)
        Me.dgInvoices.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.KryptonPanel4)
        Me.TabPage2.Controls.Add(Me.ActivitiesPanel)
        Me.TabPage2.Controls.Add(Me.PaymentTypeFilterPanel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(922, 321)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PAYMENTS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.btnPayments)
        Me.KryptonPanel4.Controls.Add(Me.lblTotalPayments)
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel4.Location = New System.Drawing.Point(3, 268)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(916, 50)
        Me.KryptonPanel4.TabIndex = 9
        '
        'btnPayments
        '
        Me.btnPayments.Location = New System.Drawing.Point(15, 6)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Size = New System.Drawing.Size(107, 35)
        Me.btnPayments.TabIndex = 43
        Me.btnPayments.Values.Text = "PAYMENTS"
        Me.btnPayments.Visible = False
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.AutoSize = False
        Me.lblTotalPayments.Location = New System.Drawing.Point(766, 20)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(147, 21)
        Me.lblTotalPayments.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkBlue
        Me.lblTotalPayments.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPayments.TabIndex = 42
        Me.lblTotalPayments.Values.Text = "0.00"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(655, 20)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(105, 20)
        Me.KryptonLabel12.TabIndex = 41
        Me.KryptonLabel12.Values.Text = "TOTAL AMOUNT:"
        '
        'ActivitiesPanel
        '
        Me.ActivitiesPanel.Controls.Add(Me.dgPayments)
        Me.ActivitiesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActivitiesPanel.Location = New System.Drawing.Point(3, 34)
        Me.ActivitiesPanel.Name = "ActivitiesPanel"
        Me.ActivitiesPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.ActivitiesPanel.Size = New System.Drawing.Size(916, 284)
        Me.ActivitiesPanel.StateCommon.Color1 = System.Drawing.Color.RoyalBlue
        Me.ActivitiesPanel.TabIndex = 8
        '
        'dgPayments
        '
        Me.dgPayments.AllowUserToAddRows = False
        Me.dgPayments.AllowUserToDeleteRows = False
        Me.dgPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPayments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPayments.Location = New System.Drawing.Point(1, 1)
        Me.dgPayments.Name = "dgPayments"
        Me.dgPayments.ReadOnly = True
        Me.dgPayments.Size = New System.Drawing.Size(914, 282)
        Me.dgPayments.TabIndex = 3
        '
        'PaymentTypeFilterPanel
        '
        Me.PaymentTypeFilterPanel.Controls.Add(Me.KryptonLabel11)
        Me.PaymentTypeFilterPanel.Controls.Add(Me.cboTransactionType)
        Me.PaymentTypeFilterPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.PaymentTypeFilterPanel.Location = New System.Drawing.Point(3, 3)
        Me.PaymentTypeFilterPanel.Name = "PaymentTypeFilterPanel"
        Me.PaymentTypeFilterPanel.Size = New System.Drawing.Size(916, 31)
        Me.PaymentTypeFilterPanel.TabIndex = 7
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(6, 6)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(98, 20)
        Me.KryptonLabel11.TabIndex = 41
        Me.KryptonLabel11.Values.Text = "PAYMENT TYPE:"
        '
        'cboTransactionType
        '
        Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionType.DropDownWidth = 139
        Me.cboTransactionType.Items.AddRange(New Object() {"ALL", "INVOICES", "PAYMENTS"})
        Me.cboTransactionType.Location = New System.Drawing.Point(110, 3)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(185, 21)
        Me.cboTransactionType.TabIndex = 41
        '
        'moduleheader
        '
        Me.moduleheader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.moduleheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.moduleheader.Location = New System.Drawing.Point(0, 0)
        Me.moduleheader.Name = "moduleheader"
        Me.moduleheader.Size = New System.Drawing.Size(1009, 39)
        Me.moduleheader.StateCommon.Content.Padding = New System.Windows.Forms.Padding(5)
        Me.moduleheader.TabIndex = 25
        Me.moduleheader.Values.Description = ""
        Me.moduleheader.Values.Heading = "QUICK BOOKS TRANSACTION UPLOADS"
        '
        'QuickbooksTransUploaderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 675)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "QuickbooksTransUploaderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quick Books Transaction Uploader"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox3.Panel.ResumeLayout(False)
        Me.KryptonGroupBox3.Panel.PerformLayout()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox3.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.ActivitiesPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActivitiesPanel.ResumeLayout(False)
        CType(Me.dgPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTypeFilterPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaymentTypeFilterPanel.ResumeLayout(False)
        Me.PaymentTypeFilterPanel.PerformLayout()
        CType(Me.cboTransactionType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents moduleheader As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox3 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnCancelUpload As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblFileName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtUploadStatus As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtUploadedOn As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtUploadedBy As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnTestConnection As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNewUpload As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnViewUploadReport As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtUploadID As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSearchUploads As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnInvoices As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblTotalInvoiceAmount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgInvoices As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnPayments As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblTotalPayments As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ActivitiesPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgPayments As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents PaymentTypeFilterPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboTransactionType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnExportInterface As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
