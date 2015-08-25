<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickbooksTransUploaderForm1
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.btnVerify = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnExportAccounts = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.btnStartQBUpload = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.pnlInitialSetup = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.dtpPaymentsToDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.dtpInvoiceToDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.dtpPaymentsFromDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.dtpInvoiceFromDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.chkInitialSetup = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.lblFileName = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.chkLauchFile = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox
        Me.btnBrowseFileLocation = New ComponentFactory.Krypton.Toolkit.KryptonButton
        Me.txtDirectoryPath = New ComponentFactory.Krypton.Toolkit.KryptonTextBox
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox
        Me.dgQuickBooksUpload = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.pnlInitialSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInitialSetup.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dgQuickBooksUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet
        Me.KryptonPanel.Size = New System.Drawing.Size(1012, 748)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.pnlInitialSetup)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel1.Location = New System.Drawing.Point(27, 35)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(20)
        Me.KryptonPanel1.Size = New System.Drawing.Size(973, 620)
        Me.KryptonPanel1.TabIndex = 2
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.btnVerify)
        Me.KryptonPanel3.Controls.Add(Me.btnExportAccounts)
        Me.KryptonPanel3.Controls.Add(Me.btnStartQBUpload)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(20, 474)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(933, 109)
        Me.KryptonPanel3.TabIndex = 7
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(12, 16)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(157, 40)
        Me.btnVerify.TabIndex = 3
        Me.btnVerify.Values.Text = "VERIFY TRANSACTIONS"
        '
        'btnExportAccounts
        '
        Me.btnExportAccounts.Location = New System.Drawing.Point(175, 16)
        Me.btnExportAccounts.Name = "btnExportAccounts"
        Me.btnExportAccounts.Size = New System.Drawing.Size(167, 40)
        Me.btnExportAccounts.TabIndex = 2
        Me.btnExportAccounts.Values.Text = "EXPORT MAPPING ACCOUNTS"
        '
        'btnStartQBUpload
        '
        Me.btnStartQBUpload.Location = New System.Drawing.Point(12, 62)
        Me.btnStartQBUpload.Name = "btnStartQBUpload"
        Me.btnStartQBUpload.Size = New System.Drawing.Size(330, 40)
        Me.btnStartQBUpload.TabIndex = 1
        Me.btnStartQBUpload.Values.Text = "START UPLOAD TO QUICKBOOKS"
        '
        'pnlInitialSetup
        '
        Me.pnlInitialSetup.Controls.Add(Me.KryptonLabel6)
        Me.pnlInitialSetup.Controls.Add(Me.KryptonLabel5)
        Me.pnlInitialSetup.Controls.Add(Me.dtpPaymentsToDate)
        Me.pnlInitialSetup.Controls.Add(Me.dtpInvoiceToDate)
        Me.pnlInitialSetup.Controls.Add(Me.dtpPaymentsFromDate)
        Me.pnlInitialSetup.Controls.Add(Me.dtpInvoiceFromDate)
        Me.pnlInitialSetup.Controls.Add(Me.KryptonLabel4)
        Me.pnlInitialSetup.Controls.Add(Me.KryptonLabel2)
        Me.pnlInitialSetup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInitialSetup.Location = New System.Drawing.Point(20, 388)
        Me.pnlInitialSetup.Name = "pnlInitialSetup"
        Me.pnlInitialSetup.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile
        Me.pnlInitialSetup.Size = New System.Drawing.Size(933, 86)
        Me.pnlInitialSetup.TabIndex = 6
        Me.pnlInitialSetup.Visible = False
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(383, 47)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(25, 19)
        Me.KryptonLabel6.TabIndex = 10
        Me.KryptonLabel6.Values.Text = "TO"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(384, 22)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(25, 19)
        Me.KryptonLabel5.TabIndex = 9
        Me.KryptonLabel5.Values.Text = "TO"
        '
        'dtpPaymentsToDate
        '
        Me.dtpPaymentsToDate.Location = New System.Drawing.Point(413, 46)
        Me.dtpPaymentsToDate.Name = "dtpPaymentsToDate"
        Me.dtpPaymentsToDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpPaymentsToDate.TabIndex = 8
        '
        'dtpInvoiceToDate
        '
        Me.dtpInvoiceToDate.Location = New System.Drawing.Point(413, 21)
        Me.dtpInvoiceToDate.Name = "dtpInvoiceToDate"
        Me.dtpInvoiceToDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpInvoiceToDate.TabIndex = 7
        '
        'dtpPaymentsFromDate
        '
        Me.dtpPaymentsFromDate.Location = New System.Drawing.Point(185, 46)
        Me.dtpPaymentsFromDate.Name = "dtpPaymentsFromDate"
        Me.dtpPaymentsFromDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpPaymentsFromDate.TabIndex = 6
        '
        'dtpInvoiceFromDate
        '
        Me.dtpInvoiceFromDate.Location = New System.Drawing.Point(185, 20)
        Me.dtpInvoiceFromDate.Name = "dtpInvoiceFromDate"
        Me.dtpInvoiceFromDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpInvoiceFromDate.TabIndex = 5
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(75, 46)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(104, 19)
        Me.KryptonLabel4.TabIndex = 4
        Me.KryptonLabel4.Values.Text = "PAYMENT PERIOD:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(38, 21)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(97, 19)
        Me.KryptonLabel2.TabIndex = 3
        Me.KryptonLabel2.Values.Text = "INVOICE PERIOD:"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(20, 263)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkInitialSetup)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblFileName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkLauchFile)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnBrowseFileLocation)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDirectoryPath)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(933, 125)
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Text = "SELECT LOG FILES  FOLDER LOCATION"
        Me.KryptonGroupBox1.Values.Heading = "SELECT LOG FILES  FOLDER LOCATION"
        '
        'chkInitialSetup
        '
        Me.chkInitialSetup.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkInitialSetup.Location = New System.Drawing.Point(11, 79)
        Me.chkInitialSetup.Name = "chkInitialSetup"
        Me.chkInitialSetup.Size = New System.Drawing.Size(139, 19)
        Me.chkInitialSetup.TabIndex = 7
        Me.chkInitialSetup.Text = "DATE RANGE OPTIONS"
        Me.chkInitialSetup.Values.Text = "DATE RANGE OPTIONS"
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(73, 47)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(6, 2)
        Me.lblFileName.TabIndex = 6
        Me.lblFileName.Values.Text = ""
        '
        'chkLauchFile
        '
        Me.chkLauchFile.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkLauchFile.Location = New System.Drawing.Point(126, 47)
        Me.chkLauchFile.Name = "chkLauchFile"
        Me.chkLauchFile.Size = New System.Drawing.Size(254, 19)
        Me.chkLauchFile.TabIndex = 4
        Me.chkLauchFile.Text = "LAUNCH FOLDER LOCATION WHEN FINISHED"
        Me.chkLauchFile.Values.Text = "LAUNCH FOLDER LOCATION WHEN FINISHED"
        '
        'btnBrowseFileLocation
        '
        Me.btnBrowseFileLocation.Location = New System.Drawing.Point(625, 17)
        Me.btnBrowseFileLocation.Name = "btnBrowseFileLocation"
        Me.btnBrowseFileLocation.Size = New System.Drawing.Size(27, 26)
        Me.btnBrowseFileLocation.TabIndex = 3
        Me.btnBrowseFileLocation.Values.Text = ". . ."
        '
        'txtDirectoryPath
        '
        Me.txtDirectoryPath.Location = New System.Drawing.Point(126, 19)
        Me.txtDirectoryPath.Name = "txtDirectoryPath"
        Me.txtDirectoryPath.ReadOnly = True
        Me.txtDirectoryPath.Size = New System.Drawing.Size(501, 22)
        Me.txtDirectoryPath.TabIndex = 2
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(10, 22)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(110, 19)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "FOLDER LOCATION:"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(20, 246)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(933, 17)
        Me.KryptonPanel2.TabIndex = 1
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(20, 20)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dgQuickBooksUpload)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(933, 226)
        Me.KryptonGroupBox2.TabIndex = 0
        Me.KryptonGroupBox2.Text = "QUICKBOOKS UPLOAD RESULTS"
        Me.KryptonGroupBox2.Values.Heading = "QUICKBOOKS UPLOAD RESULTS"
        '
        'dgQuickBooksUpload
        '
        Me.dgQuickBooksUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgQuickBooksUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgQuickBooksUpload.Location = New System.Drawing.Point(10, 10)
        Me.dgQuickBooksUpload.Name = "dgQuickBooksUpload"
        Me.dgQuickBooksUpload.Size = New System.Drawing.Size(909, 183)
        Me.dgQuickBooksUpload.TabIndex = 0
        '
        'QuickbooksTransUploaderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 748)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "QuickbooksTransUploaderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quick Books Transaction Uploader"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.pnlInitialSetup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInitialSetup.ResumeLayout(False)
        Me.pnlInitialSetup.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dgQuickBooksUpload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnBrowseFileLocation As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtDirectoryPath As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkLauchFile As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblFileName As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dgQuickBooksUpload As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnExportAccounts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnStartQBUpload As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlInitialSetup As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpPaymentsToDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpInvoiceToDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpPaymentsFromDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpInvoiceFromDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents chkInitialSetup As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents btnVerify As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
