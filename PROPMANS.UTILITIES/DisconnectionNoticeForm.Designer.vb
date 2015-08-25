<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisconnectionNoticeForm
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
        Me.pnlPrintCommand = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dtpDueDate = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.rdbDisconnectionNotice = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdbDisconnectionList = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.btnPrintPreview = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.StatementsGroupBox = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.BillingGridPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgUnpaidAccounts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblRecordCount = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboJoiningOperator = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.pnlCondition2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtValue2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboOperator2 = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.pnlCondition1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtValue1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboOperator1 = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.btnListAccounts = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.chkFilter2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkFilter1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrintCommand.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatementsGroupBox.Panel.SuspendLayout()
        Me.StatementsGroupBox.SuspendLayout()
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BillingGridPanel.SuspendLayout()
        CType(Me.dgUnpaidAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboJoiningOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCondition2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCondition2.SuspendLayout()
        CType(Me.cboOperator2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCondition1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCondition1.SuspendLayout()
        CType(Me.cboOperator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlPrintCommand)
        Me.KryptonPanel.Controls.Add(Me.StatementsGroupBox)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(10, 40, 10, 10)
        Me.KryptonPanel.Size = New System.Drawing.Size(775, 629)
        Me.KryptonPanel.TabIndex = 0
        '
        'pnlPrintCommand
        '
        Me.pnlPrintCommand.Controls.Add(Me.dtpDueDate)
        Me.pnlPrintCommand.Controls.Add(Me.KryptonLabel1)
        Me.pnlPrintCommand.Controls.Add(Me.KryptonGroupBox2)
        Me.pnlPrintCommand.Controls.Add(Me.btnPrintPreview)
        Me.pnlPrintCommand.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrintCommand.Location = New System.Drawing.Point(10, 511)
        Me.pnlPrintCommand.Name = "pnlPrintCommand"
        Me.pnlPrintCommand.Size = New System.Drawing.Size(755, 102)
        Me.pnlPrintCommand.TabIndex = 30
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Location = New System.Drawing.Point(167, 15)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(209, 21)
        Me.dtpDueDate.TabIndex = 1
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(6, 16)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(169, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "DISCONNECTION DUE DATE:"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(413, 6)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.rdbDisconnectionNotice)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.rdbDisconnectionList)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(195, 80)
        Me.KryptonGroupBox2.TabIndex = 31
        Me.KryptonGroupBox2.Text = "PRINT PREVIEW OPTIONS"
        Me.KryptonGroupBox2.Values.Heading = "PRINT PREVIEW OPTIONS"
        '
        'rdbDisconnectionNotice
        '
        Me.rdbDisconnectionNotice.Checked = True
        Me.rdbDisconnectionNotice.Location = New System.Drawing.Point(21, 4)
        Me.rdbDisconnectionNotice.Name = "rdbDisconnectionNotice"
        Me.rdbDisconnectionNotice.Size = New System.Drawing.Size(164, 20)
        Me.rdbDisconnectionNotice.TabIndex = 1
        Me.rdbDisconnectionNotice.Values.Text = "DISCONNECTION NOTICE"
        '
        'rdbDisconnectionList
        '
        Me.rdbDisconnectionList.Location = New System.Drawing.Point(21, 29)
        Me.rdbDisconnectionList.Name = "rdbDisconnectionList"
        Me.rdbDisconnectionList.Size = New System.Drawing.Size(144, 20)
        Me.rdbDisconnectionList.TabIndex = 0
        Me.rdbDisconnectionList.Values.Text = "DISCONNECTION LIST"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Location = New System.Drawing.Point(614, 28)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(129, 47)
        Me.btnPrintPreview.TabIndex = 30
        Me.btnPrintPreview.Values.Text = "PRINT PREVIEW"
        '
        'StatementsGroupBox
        '
        Me.StatementsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatementsGroupBox.Location = New System.Drawing.Point(10, 159)
        Me.StatementsGroupBox.Name = "StatementsGroupBox"
        '
        'StatementsGroupBox.Panel
        '
        Me.StatementsGroupBox.Panel.Controls.Add(Me.BillingGridPanel)
        Me.StatementsGroupBox.Panel.Controls.Add(Me.KryptonPanel1)
        Me.StatementsGroupBox.Panel.Controls.Add(Me.lblRecordCount)
        Me.StatementsGroupBox.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.StatementsGroupBox.Size = New System.Drawing.Size(755, 352)
        Me.StatementsGroupBox.TabIndex = 29
        Me.StatementsGroupBox.Text = "UNPAID ACCOUNTS"
        Me.StatementsGroupBox.Values.Heading = "UNPAID ACCOUNTS"
        '
        'BillingGridPanel
        '
        Me.BillingGridPanel.Controls.Add(Me.dgUnpaidAccounts)
        Me.BillingGridPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.BillingGridPanel.Location = New System.Drawing.Point(10, 36)
        Me.BillingGridPanel.Name = "BillingGridPanel"
        Me.BillingGridPanel.Size = New System.Drawing.Size(731, 266)
        Me.BillingGridPanel.TabIndex = 6
        '
        'dgUnpaidAccounts
        '
        Me.dgUnpaidAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUnpaidAccounts.Location = New System.Drawing.Point(0, 0)
        Me.dgUnpaidAccounts.Name = "dgUnpaidAccounts"
        Me.dgUnpaidAccounts.Size = New System.Drawing.Size(731, 266)
        Me.dgUnpaidAccounts.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.chkSelectAll)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(10, 10)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(731, 26)
        Me.KryptonPanel1.TabIndex = 5
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(12, 1)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(86, 20)
        Me.chkSelectAll.TabIndex = 2
        Me.chkSelectAll.Text = "SELECT ALL"
        Me.chkSelectAll.Values.Text = "SELECT ALL"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(3, 308)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(89, 20)
        Me.lblRecordCount.TabIndex = 4
        Me.lblRecordCount.Values.Text = "KryptonLabel1"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(10, 40)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboJoiningOperator)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.pnlCondition2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.pnlCondition1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnListAccounts)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkFilter2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkFilter1)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(755, 119)
        Me.KryptonGroupBox1.TabIndex = 28
        Me.KryptonGroupBox1.Text = "ACCOUNT FILTER"
        Me.KryptonGroupBox1.Values.Heading = "ACCOUNT FILTER"
        '
        'cboJoiningOperator
        '
        Me.cboJoiningOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoiningOperator.DropDownWidth = 46
        Me.cboJoiningOperator.Items.AddRange(New Object() {"AND", "OR"})
        Me.cboJoiningOperator.Location = New System.Drawing.Point(331, 33)
        Me.cboJoiningOperator.Name = "cboJoiningOperator"
        Me.cboJoiningOperator.Size = New System.Drawing.Size(48, 21)
        Me.cboJoiningOperator.TabIndex = 37
        '
        'pnlCondition2
        '
        Me.pnlCondition2.Controls.Add(Me.txtValue2)
        Me.pnlCondition2.Controls.Add(Me.KryptonLabel3)
        Me.pnlCondition2.Controls.Add(Me.cboOperator2)
        Me.pnlCondition2.Location = New System.Drawing.Point(34, 46)
        Me.pnlCondition2.Name = "pnlCondition2"
        Me.pnlCondition2.Size = New System.Drawing.Size(288, 39)
        Me.pnlCondition2.TabIndex = 34
        '
        'txtValue2
        '
        Me.txtValue2.Location = New System.Drawing.Point(171, 3)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(108, 20)
        Me.txtValue2.TabIndex = 36
        Me.txtValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(3, 6)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(122, 20)
        Me.KryptonLabel3.TabIndex = 34
        Me.KryptonLabel3.Values.Text = "PREVIOUS AMOUNT"
        '
        'cboOperator2
        '
        Me.cboOperator2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperator2.DropDownWidth = 46
        Me.cboOperator2.Items.AddRange(New Object() {"=", "<", ">"})
        Me.cboOperator2.Location = New System.Drawing.Point(119, 3)
        Me.cboOperator2.Name = "cboOperator2"
        Me.cboOperator2.Size = New System.Drawing.Size(46, 21)
        Me.cboOperator2.TabIndex = 35
        '
        'pnlCondition1
        '
        Me.pnlCondition1.Controls.Add(Me.txtValue1)
        Me.pnlCondition1.Controls.Add(Me.KryptonLabel2)
        Me.pnlCondition1.Controls.Add(Me.cboOperator1)
        Me.pnlCondition1.Location = New System.Drawing.Point(34, 6)
        Me.pnlCondition1.Name = "pnlCondition1"
        Me.pnlCondition1.Size = New System.Drawing.Size(291, 34)
        Me.pnlCondition1.TabIndex = 33
        '
        'txtValue1
        '
        Me.txtValue1.Location = New System.Drawing.Point(171, 6)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(108, 20)
        Me.txtValue1.TabIndex = 36
        Me.txtValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(3, 9)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel2.TabIndex = 34
        Me.KryptonLabel2.Values.Text = "CURRENT AMOUNT"
        '
        'cboOperator1
        '
        Me.cboOperator1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperator1.DropDownWidth = 46
        Me.cboOperator1.Items.AddRange(New Object() {"=", "<", ">"})
        Me.cboOperator1.Location = New System.Drawing.Point(119, 6)
        Me.cboOperator1.Name = "cboOperator1"
        Me.cboOperator1.Size = New System.Drawing.Size(46, 21)
        Me.cboOperator1.TabIndex = 35
        '
        'btnListAccounts
        '
        Me.btnListAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListAccounts.Location = New System.Drawing.Point(612, 19)
        Me.btnListAccounts.Name = "btnListAccounts"
        Me.btnListAccounts.Size = New System.Drawing.Size(129, 47)
        Me.btnListAccounts.TabIndex = 32
        Me.btnListAccounts.Values.Text = "LIST ACCOUNTS"
        '
        'chkFilter2
        '
        Me.chkFilter2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkFilter2.Location = New System.Drawing.Point(22, 53)
        Me.chkFilter2.Name = "chkFilter2"
        Me.chkFilter2.Size = New System.Drawing.Size(19, 13)
        Me.chkFilter2.TabIndex = 1
        Me.chkFilter2.Values.Text = ""
        '
        'chkFilter1
        '
        Me.chkFilter1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkFilter1.Location = New System.Drawing.Point(22, 19)
        Me.chkFilter1.Name = "chkFilter1"
        Me.chkFilter1.Size = New System.Drawing.Size(19, 13)
        Me.chkFilter1.TabIndex = 0
        Me.chkFilter1.Values.Text = ""
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'DisconnectionNoticeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 629)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "DisconnectionNoticeForm"
        Me.Tag = "nod"
        Me.Text = "Water Disconnection Notice"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.pnlPrintCommand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrintCommand.ResumeLayout(False)
        Me.pnlPrintCommand.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        Me.KryptonGroupBox2.Panel.PerformLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.StatementsGroupBox.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.Panel.ResumeLayout(False)
        Me.StatementsGroupBox.Panel.PerformLayout()
        CType(Me.StatementsGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatementsGroupBox.ResumeLayout(False)
        CType(Me.BillingGridPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BillingGridPanel.ResumeLayout(False)
        CType(Me.dgUnpaidAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboJoiningOperator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCondition2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCondition2.ResumeLayout(False)
        Me.pnlCondition2.PerformLayout()
        CType(Me.cboOperator2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCondition1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCondition1.ResumeLayout(False)
        Me.pnlCondition1.PerformLayout()
        CType(Me.cboOperator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents StatementsGroupBox As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblRecordCount As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents pnlPrintCommand As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnPrintPreview As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtpDueDate As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents rdbDisconnectionNotice As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdbDisconnectionList As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents txtValue1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents pnlCondition1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboOperator1 As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnListAccounts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkFilter2 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkFilter1 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents pnlCondition2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtValue2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboOperator2 As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboJoiningOperator As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents BillingGridPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgUnpaidAccounts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox

End Class
