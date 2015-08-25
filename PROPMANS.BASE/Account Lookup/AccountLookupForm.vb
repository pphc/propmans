'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 04-16-2012
'
' Last Modified By : 
' Last Modified On : 
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports System.Windows.Forms
Imports ComponentFactory.Krypton.Toolkit
Imports BCL.Common


Public Class AccountLookupForm

    Private gridDisplay As GridDisplayType
    Private customerTypeSearch As CustomerType
    Private displayInactiveCheckBox As Boolean = False

    Private _bloaded As Boolean

    Private _accountID As String
    Public Property AccountID() As String
        Get
            Return grid.CurrentRow.Cells("account_id").Value.ToString
        End Get
        Private Set(value As String)
            _accountID = value
        End Set
    End Property

    Private _customerID As String
    Public Property CustomerID() As String
        Get
            Return grid.CurrentRow.Cells("cust_id").Value.ToString
        End Get
        Private Set(value As String)
            _customerID = value
        End Set
    End Property

    Public ReadOnly Property LeaseID() As String
        Get
            Return grid.CurrentRow.Cells("lease_id").Value.ToString
        End Get
    End Property


    Public ReadOnly Property UnitNumber() As String
        Get
            Return grid.CurrentRow.Cells("unit_number").Value.ToString
        End Get
    End Property

    Public ReadOnly Property UnitClass() As FeeUnitClass
        Get
            Try
                If grid.CurrentRow.Cells("unit_class").Value.ToString = "PARKING SLOT" Then
                    Return FeeUnitClass.ParkingUnit
                Else
                    Return FeeUnitClass.CondoUnit
                End If
            Catch ex As Exception
                Return FeeUnitClass.CondoUnit
            End Try

        End Get
    End Property

    Public ReadOnly Property CustomerType As String
        Get
            Return grid.CurrentRow.Cells("cust_type").Value.ToString
        End Get
    End Property

    Public ReadOnly Property CustomerFirstName() As String
        Get
            Return grid.CurrentRow.Cells("first_name").Value.ToString
        End Get
    End Property
    Public ReadOnly Property CustomerMiddleName() As String
        Get
            Return grid.CurrentRow.Cells("middle_name").Value.ToString
        End Get
    End Property
    Public ReadOnly Property CustomerLastName() As String
        Get
            Return grid.CurrentRow.Cells("last_name").Value.ToString
        End Get
    End Property
    Public ReadOnly Property CustomerFullName() As String
        Get
            Return String.Format("{0}, {1} {2}", CustomerLastName, CustomerFirstName, CustomerMiddleName)
        End Get
    End Property

    Private SearchType As SearchAccountType

    Public Sub New(Optional displayType As GridDisplayType = GridDisplayType.Full,
                   Optional custType As CustomerType = BCL.Common.CustomerType.Both,
                   Optional displayInactiveChkBox As Boolean = True)
        Me.gridDisplay = displayType
        Me.customerTypeSearch = custType
        Me.displayInactiveCheckBox = displayInactiveChkBox
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub CustomerLookupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUIDefaults()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        btnSelect.Visible = False
        If Common.HasValue(SearchValueTextBox) Then
            Dim searchvalue As String = SearchValueTextBox.Text.Trim
            _bloaded = False

            If Me.gridDisplay = GridDisplayType.Full Then
                grid.DataSource = GlobalReference.CustomerAccount.LoadAccounts(SearchType, searchvalue, Me.customerTypeSearch, DisplayInactiveAccountsCheckBox.Checked)
            Else
                grid.DataSource = GlobalReference.CustomerAccount.LoadCustomers(SearchType, searchvalue)
            End If

            _bloaded = True

            If grid.RowCount > 0 Then
                ResultCountLabel.Text = grid.RowCount & " RECORD(S) FOUND"
                btnSelect.Visible = True
            Else
                SearchValueTextBox.SelectAll()
                SearchValueTextBox.Focus()
                ResultCountLabel.Text = "NO RECORD(S) FOUND"
            End If
        Else
            If Me.gridDisplay = GridDisplayType.Full Then
                grid.DataSource = GlobalReference.CustomerAccount.LoadAccounts(Me.customerTypeSearch, DisplayInactiveAccountsCheckBox.Checked)
            Else
                grid.DataSource = GlobalReference.CustomerAccount.LoadCustomers()
            End If

            btnSelect.Visible = True
            ResultCountLabel.Text = grid.RowCount & " RECORD(S) FOUND"
            SearchValueTextBox.Focus()
        End If

    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSearchValueButton.Click
        SearchValueTextBox.Text = String.Empty
        SearchValueTextBox.Focus()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GlobalReference.CustomerAccount.Refresh()
        btnSearch_Click(Nothing, Nothing)
    End Sub


    Private Sub Grid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If grid.Columns(e.ColumnIndex).Name = "customername" Then
            ' e.FormattingApplied
            Dim row As DataGridViewRow = grid.Rows(e.RowIndex)
            e.Value = String.Format("{0}, {1} {2}", row.Cells("last_name").Value, row.Cells("first_name").Value, row.Cells("middle_name").Value)
        End If
    End Sub

    Private Sub SetUIDefaults()
        Me.CancelButton = btnCancel
        Me.AcceptButton = btnSearch


        If Me.gridDisplay = GridDisplayType.Full Then
            GridHelper.SetGridDisplay(grid, New AccountLookupGridDisplay)
            ByUnitNumberRadioButton.Checked = True
        Else
            GridHelper.SetGridDisplay(grid, New CustomerOnlyLookupGridDisplay)
            Me.ByUnitNumberRadioButton.Enabled = False
            Me.ByLastNameRadioButton.Checked = True
        End If

        Me.DisplayInactiveAccountsCheckBox.Visible = IIf(displayInactiveCheckBox = False, False, (Me.gridDisplay = GridDisplayType.Full))


        AddHandler grid.CellFormatting, AddressOf Grid_CellFormatting

        btnSelect.Visible = False
        'btnRefresh.Visible = False


        SearchValueTextBox.Focus()
    End Sub


    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByUnitNumberRadioButton.CheckedChanged, ByLastNameRadioButton.CheckedChanged, ByFirstNameRadioButton.CheckedChanged

        Select Case DirectCast(sender, KryptonRadioButton).Tag
            Case "ByUnitNumber" ' search by Unit No
                SearchType = SearchAccountType.UnitNumber
            Case "ByLastName" ' search by Last Name
                SearchType = SearchAccountType.LastName
            Case "ByFirstName" ' search by First Name
                SearchType = SearchAccountType.Firstname
        End Select

        SearchValueTextBox.SelectAll()
        SearchValueTextBox.Focus()
    End Sub


End Class