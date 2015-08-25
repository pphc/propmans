Imports DALC
Imports System.Linq
Imports BCL.Common
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Namespace Accounts

    Public Enum AccountStatus
        <EnumDisplayName("ACTIVE")> _
        <EnumDBValue("ACT")> _
        Active
        <EnumDisplayName("INACTIVE")> _
        <EnumDBValue("INACT")> _
        Inactive
    End Enum

    Public Enum UnitType
        <EnumDisplayName("CONDO UNIT")> _
        <EnumDBValue("CONDO")> _
        Active
        <EnumDisplayName("PARKING SLOT")> _
        <EnumDBValue("PARK")> _
        Inactive
    End Enum

    Public Class Customer
        Public Property CustomerID As String

        Public Property LastName As String
        Public Property FirstName As String
        Public Property MiddleName As String
        'TODO mus be enum
        Public Property NameSuffix As String

        Public Property BuyerCode As String

        Public ReadOnly Property FullNameLastNameFirst As String
            Get
                If String.IsNullOrWhiteSpace(MiddleName) Then
                    Return String.Format("{0}, {1}", LastName, FirstName)
                Else
                    Return String.Format("{0}, {1} {2}", LastName, FirstName, MiddleName)
                End If


            End Get
        End Property

        Public ReadOnly Property FullNameFirstNameFirst As String
            Get
                If String.IsNullOrWhiteSpace(MiddleName) Then
                    Return String.Format("{0} {1}", FirstName, LastName)
                Else
                    Return String.Format("{0} {1}. {2}", FirstName, MiddleName.Substring(0, 1), LastName)
                End If
            End Get
        End Property
    End Class

    Public Class CustomerAccount
        Public Property AccountID As String
        Public Property Owner As Customer
        Public Property Tenant As Customer

        Public Property UnitID As String
        Public Property UnitNumber As String

        Public Property UnitType As UnitType

        Public Property AccountStatus As AccountStatus

        Public Property UnitOrder As String
    End Class

    Public Class AccountsDA

        Private _unitInventory As List(Of UnitInventory)
        Public ReadOnly Property UnitInventory() As List(Of UnitInventory)
            Get
                Return _unitInventory
            End Get
        End Property

        Private _customerAccounts As List(Of CustomerAccount)
        Public ReadOnly Property CustomerAccounts() As List(Of CustomerAccount)
            Get
                Return _customerAccounts
            End Get
        End Property

        Private _customers As List(Of Customer)
        Public ReadOnly Property Customers() As List(Of Customer)
            Get
                Return _customers
            End Get
        End Property

        Public Sub New()
            LoadCustomers()
            LoadCustomerAccounts()
            LoadUnitInventory()
        End Sub

        Private Sub LoadCustomers()

            _customers = New List(Of Customer)

            Using param As New OraParameter


                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("accounts.getcustomers", param.GetParameterCollection).Rows
                    _customers.Add(New Customer With {.CustomerID = row("cust_id").ToString,
                                                      .LastName = row("cust_lname").ToString,
                                                      .FirstName = row("cust_fname").ToString,
                                                      .MiddleName = row("cust_mname").ToString,
                                                      .NameSuffix = row("name_sake").ToString})
                Next
            End Using
        End Sub

        Private Sub LoadCustomerAccounts()

            _customerAccounts = New List(Of CustomerAccount)

            Using param As New OraParameter


                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("accounts.getcustomeraccounts", param.GetParameterCollection).Rows
                    _customerAccounts.Add(New CustomerAccount With {.AccountID = row("account_id").ToString,
                                                      .UnitID = row("unit_id").ToString,
                                                      .UnitNumber = row("cust_unit_no").ToString,
                                                      .UnitOrder = row("cust_unit_sort").ToString,
                                                      .AccountStatus = EnumExtensions.Entry(Of AccountStatus)(row("account_status").ToString),
                                                      .UnitType = EnumExtensions.Entry(Of UnitType)(row("account_class").ToString),
                                                      .Owner = GetCustomerByID(row("acct_cust_id").ToString)})

                Next
            End Using
        End Sub

        Private Sub LoadUnitInventory()

            _unitInventory = New List(Of UnitInventory)

            Using param As New OraParameter


                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("accounts.getunitinventory", param.GetParameterCollection).Rows
                    _unitInventory.Add(New UnitInventory With {.UnitID = row("unit_id").ToString,
                                                      .UnitNumber = row("unit_number").ToString,
                                                      .UnitArea = Decimal.Parse(row("unit_area").ToString),
                                                      .OwnerAccount = GetCurrentOwnerAccountbyUnitID(row("unit_id").ToString),
                                                      .PhaseNo = row("phase_no").ToString,
                                                      .BldgNo = row("bldg_no").ToString,
                                                      .ClusterNo = row("cluster_no").ToString,
                                                      .FloorNo = row("floor_no").ToString,
                                                      .UnitNo = row("unit_no").ToString})

                Next
            End Using
        End Sub

        Public Function GetCustomerByID(custID As String) As Customer

            Return (From cust In Customers
                   Where cust.CustomerID = custID
                   Select cust).SingleOrDefault

        End Function

        Public Function GetUnitOwnerAccountByID(accountID As String) As CustomerAccount

            Return (From account In CustomerAccounts
                   Where account.AccountID = accountID
                   Select account).SingleOrDefault

        End Function

        Public Function GetUnitOwnerAcccounts(Optional includeInactive As Boolean = False) As List(Of CustomerAccount)
            If includeInactive Then
                Return _customerAccounts
            Else
                Return (From accounts In _customerAccounts
                         Where accounts.AccountStatus = AccountStatus.Active
                         Select accounts).ToList
            End If

        End Function

        Public Function GetUnitOwnerByUnitNumber(unitNumber As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
            If includeInactiveAccounts Then
                Return (From accounts In _customerAccounts
                        Where accounts.UnitNumber.Equals(unitNumber)
                        Select accounts).ToList
            Else
                Return (From accounts In _customerAccounts
                    Where accounts.UnitNumber.Equals(unitNumber) And accounts.AccountStatus = AccountStatus.Active
                    Select accounts).ToList
            End If
        End Function

        Public Function GetUnitOwnerByCustFirstName(firstName As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
            If includeInactiveAccounts Then
                Return (From accounts In _customerAccounts
                        Where accounts.Owner.FirstName.Contains(firstName)
                        Select accounts
                        Order By accounts.Owner.FirstName).ToList
            Else
                Return (From accounts In _customerAccounts
                    Where accounts.Owner.FirstName.Contains(firstName) And accounts.AccountStatus = AccountStatus.Active
                    Select accounts
                    Order By accounts.Owner.FirstName).ToList
            End If
        End Function

        Public Function GetUnitOwnerByCustLastName(lastName As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
            If includeInactiveAccounts Then
                Return (From accounts In _customerAccounts
                        Where accounts.Owner.LastName.Contains(lastName)
                        Select accounts
                        Order By accounts.Owner.LastName).ToList
            Else
                Return (From accounts In _customerAccounts
                    Where accounts.Owner.LastName.Contains(lastName) And accounts.AccountStatus = AccountStatus.Active
                    Select accounts
                    Order By accounts.Owner.LastName).ToList
            End If
        End Function

        Public Function GetTenantAcccounts(Optional includeInactive As Boolean = False) As List(Of CustomerAccount)
            If includeInactive Then
                Return _customerAccounts
            Else
                Return (From accounts In _customerAccounts
                         Where accounts.AccountStatus = AccountStatus.Active
                         Select accounts).ToList
            End If

        End Function

        Public Function GetCustomers() As List(Of Customer)
            Return _customers
        End Function

        Public Function GetCustomerByLastName(lastName As String) As List(Of Customer)
            Return (From cust In _customers
                     Where cust.LastName.Contains(lastName)
                     Select cust).ToList
        End Function

        Public Function GetCustomerByFirstName(firstName As String) As List(Of Customer)
            Return (From cust In _customers
                    Where cust.FirstName.Contains(firstName)
                    Select cust).ToList
        End Function

        Public Function GetUnitsInventory() As List(Of UnitInventory)
            Return (From unit In _unitInventory
                    Order By unit.UnitSort
                    Select unit).ToList()
        End Function

        Public Function GetUnitsInventoryByUnitNumber(unitNumber As String) As List(Of UnitInventory)
            Return (From unit In _unitInventory
                    Where unit.UnitNumber.Equals(unitNumber)
                    Order By unit.UnitSort
                    Select unit).ToList()
        End Function

        Public Function GetUnitsInventoryByLastName(lastName As String) As List(Of UnitInventory)
            Return (From unit In _unitInventory
                    Where Not unit.OwnerAccount Is Nothing
                    Order By unit.UnitSort
                    Select unit).Where(Function(x) x.OwnerAccount.Owner.LastName.Contains(lastName)).ToList
        End Function
        Public Function GetUnitsInventoryByFirstName(firstName As String) As List(Of UnitInventory)
            Return (From unit In _unitInventory
                    Where Not unit.OwnerAccount Is Nothing
                    Order By unit.UnitSort
                    Select unit).Where(Function(x) x.OwnerAccount.Owner.FirstName.Contains(firstName)).ToList
        End Function

        Public Function GetAssociatedUnit(ID As String) As String

            Dim rm As New RMS.RMSDA

            Dim custID As String =  rm.LoadLeaseByID(ID).Tenant.CustomerID

            Try
                Return (From act In _customerAccounts
                                  Where act.Owner.CustomerID = custID).FirstOrDefault.UnitNumber
            Catch ex As Exception
                Return String.Empty
            End Try
          

        End Function

        Private Function GetCurrentOwnerAccountbyUnitID(unitID As String) As CustomerAccount

            If (From act As CustomerAccount In _customerAccounts
                  Where act.UnitID.Equals(unitID) And act.AccountStatus = AccountStatus.Active
                  Select act).SingleOrDefault() Is Nothing Then
                Return Nothing
            Else

                Return (From act As CustomerAccount In _customerAccounts
                      Where act.UnitID.Equals(unitID) And act.AccountStatus = AccountStatus.Active
                      Select act).Single
            End If

        End Function



        Public Sub ReloadData()
            LoadCustomers()
            LoadCustomerAccounts()
            LoadUnitInventory()
        End Sub

        Public Function SaveCustomer(cust As Customer) As Integer
            Using param As New OraParameter

                param.AddParameter("customerlastname", cust.LastName)
                param.AddParameter("customerfirstname", cust.FirstName)
                param.AddParameter("customermiddlename", cust.MiddleName)
                param.AddParameter("custid", Nothing, OracleDbType.Int32, ParameterDirection.ReturnValue)

                Return DirectCast(OraDBHelper2.ExecuteFunction("accounts.insertcustomer", param.GetParameterCollection), OracleDecimal).ToInt32

                LoadCustomers()
            End Using
        End Function

        Public Function IsCustomerExisting(cust As Customer) As Boolean
            Using param As New OraParameter

                param.AddParameter("customerlastname", cust.LastName)
                param.AddParameter("customerfirstname", cust.FirstName)
                If String.IsNullOrWhiteSpace(cust.MiddleName) Then
                    param.AddParameter("customermiddlename", cust.MiddleName)
                End If

                param.AddParameter("recordcount", Nothing, OracleDbType.Int32, ParameterDirection.ReturnValue)

                Dim count As Integer = DirectCast(OraDBHelper2.ExecuteFunction("accounts.iscustomerexists", param.GetParameterCollection), OracleDecimal).ToInt32

                Return count > 0


            End Using
        End Function

    End Class

End Namespace

