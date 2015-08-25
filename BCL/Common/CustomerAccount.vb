Imports DALC
Imports System.Linq
Imports BCL.RMS
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types


Namespace Common

    Public Enum SearchAccountType
        UnitNumber
        LastName
        Firstname
    End Enum

    Public Enum GridDisplayType
        Full
        NameOnly
    End Enum

    Public Enum CustomerType
        Both
        UnitOwner
        Tenant
    End Enum

    Public Class CustomerAccount

        Private _custAccountDatatable As DataTable
        Public ReadOnly Property CustAccountDatatable() As DataTable
            Get
                Return _custAccountDatatable
            End Get
        End Property

        Private _customersDataTable As DataTable
        Public ReadOnly Property CustomersDataTable() As DataTable
            Get
                Return _customersDataTable
            End Get
        End Property

        Public Sub New()
            LoadCustomerOnly()
            LoadCustomerAccounts()
        End Sub

        Private Sub LoadCustomerOnly()
            Dim query As String = "SELECT cust_id, cust_lname last_name, cust_fname first_name, cust_mname middle_name" & _
                                "  FROM customers                                       " & _
                                "  ORDER BY 2"

            _customersDataTable = OraDBHelper2.GetResultSet(query)
        End Sub

        Public Function LoadCustomers() As DataTable
            Return _customersDataTable
        End Function

        Public Function LoadCustomers(ByVal searchType As SearchAccountType, ByVal searchValue As String) As DataTable
            Dim rowfilter As String = String.Empty

            Select Case searchType
                Case SearchAccountType.Firstname
                    rowfilter = "first_name like '%" & searchValue & "%'"
                Case SearchAccountType.LastName
                    rowfilter = "last_name like '%" & searchValue & "%'"
            End Select

            Using dv As New DataView(_customersDataTable)
                dv.RowFilter = rowfilter
                Return dv.ToTable()
            End Using

        End Function

        Private Sub LoadCustomerAccounts()
            'Dim query As String = "SELECT account_id, acct_cust_id cust_id, unit_id, cust_unit_no unit_number,  " & _
            '                        "       CASE (SELECT unit_subclass                                            " & _
            '                        "               FROM am_unit                                                  " & _
            '                        "              WHERE unit_id = cs.unit_id)                                    " & _
            '                        "          WHEN 'RES'                                                         " & _
            '                        "             THEN 'CONDO UNIT'                                               " & _
            '                        "          WHEN 'COMM'                                                        " & _
            '                        "             THEN 'CONDO UNIT'                                               " & _
            '                        "          WHEN 'PARK'                                                        " & _
            '                        "             THEN 'PARKING SLOT'                                             " & _
            '                        "       END unit_class,                                                       " & _
            '                        "       DECODE (account_status, 'ACT', 'ACTIVE', 'INACTIVE') account_status,  " & _
            '                        "       (SELECT cust_lname                                                    " & _
            '                        "          FROM customers                                                     " & _
            '                        "         WHERE cust_id = cs.acct_cust_id) last_name,                         " & _
            '                        "       (SELECT cust_fname                                                    " & _
            '                        "          FROM customers                                                     " & _
            '                        "         WHERE cust_id = cs.acct_cust_id) first_name,                        " & _
            '                        "       (SELECT cust_mname                                                    " & _
            '                        "          FROM customers                                                     " & _
            '                        "         WHERE cust_id = cs.acct_cust_id) middle_name                        " & _
            '                        "  FROM customer_accounts cs                                                  " & _
            '                        " ORDER BY cust_unit_sort "
            Dim query As String = "SELECT * FROM (SELECT account_id, acct_cust_id cust_id, NULL lease_id, unit_id,                                " & _
                                "                                        cust_unit_no unit_number,                                              " & _
                                "                                        CASE (SELECT unit_subclass                                             " & _
                                "                                                FROM am_unit                                                   " & _
                                "                                               WHERE unit_id = cs.unit_id)                                     " & _
                                "                                           WHEN 'RES'                                                          " & _
                                "                                              THEN 'CONDO UNIT'                                                " & _
                                "                                           WHEN 'COMM'                                                         " & _
                                "                                              THEN 'CONDO UNIT'                                                " & _
                                "                                           WHEN 'PARK'                                                         " & _
                                "                                              THEN 'PARKING SLOT'                                              " & _
                                "                                        END unit_class,                                                        " & _
                                "                                        cust_unit_sort,                                                        " & _
                                "                                        DECODE (account_status, 'ACT', 'ACTIVE', 'INACTIVE') account_status,   " & _
                                "                                        (SELECT cust_lname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cs.acct_cust_id) last_name,                          " & _
                                "                                        (SELECT cust_fname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cs.acct_cust_id) first_name,                         " & _
                                "                                        (SELECT cust_mname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cs.acct_cust_id) middle_name, 'UNIT OWNER' cust_type " & _
                                "                                   FROM customer_accounts cs                                                   " & _
                                "                                 UNION                                                                         " & _
                                "                                 SELECT account_id, cust_id, lease_id,                                         " & _
                                "                                        (SELECT unit_id                                                        " & _
                                "                                           FROM customer_accounts                                              " & _
                                "                                          WHERE account_id = cc.account_id) unit_id,                           " & _
                                "                                        accounts.getunitnumber (account_id) unit_number,                       " & _
                                "                                        CASE (SELECT unit_subclass                                             " & _
                                "                                                FROM am_unit                                                   " & _
                                "                                               WHERE unit_id = (SELECT unit_id                                 " & _
                                "                                                                  FROM customer_accounts                       " & _
                                "                                                                 WHERE account_id = cc.account_id))            " & _
                                "                                           WHEN 'RES'                                                          " & _
                                "                                              THEN 'CONDO UNIT'                                                " & _
                                "                                           WHEN 'COMM'                                                         " & _
                                "                                              THEN 'CONDO UNIT'                                                " & _
                                "                                           WHEN 'PARK'                                                         " & _
                                "                                              THEN 'PARKING SLOT'                                              " & _
                                "                                        END unit_class,                                                        " & _
                                "                                        (SELECT cust_unit_sort                                                 " & _
                                "                                           FROM customer_accounts                                              " & _
                                "                                          WHERE account_id = cc.account_id) cust_unit_sort, account_status,    " & _
                                "                                        (SELECT cust_lname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cc.cust_id) last_name,                               " & _
                                "                                        (SELECT cust_fname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cc.cust_id) first_name,                              " & _
                                "                                        (SELECT cust_mname                                                     " & _
                                "                                           FROM customers                                                      " & _
                                "                                          WHERE cust_id = cc.cust_id) middle_name, 'TENANT' cust_type          " & _
                                "                                   FROM (SELECT lease_id, (SELECT account_id                                   " & _
                                "                                                             FROM rm_agreement                                 " & _
                                "                                                            WHERE agreement_id = lc.agreement_id) account_id,  " & _
                                "                                                cust_id,                                                       " & _
                                "                                                CASE contract_status                                           " & _
                                "                                                   WHEN 'FAP'                                                  " & _
                                "                                                      THEN 'ACTIVE'                                            " & _
                                "                                                   WHEN 'ACT'                                                  " & _
                                "                                                      THEN 'ACTIVE'                                            " & _
                                "                                                   WHEN 'EXP'                                                  " & _
                                "                                                      THEN 'INACTIVE'                                          " & _
                                "                                                END account_status                                             " & _
                                "                                           FROM rm_lease_contract lc                                           " & _
                                "                                          WHERE contract_status NOT IN ('VOID')) cc)                           " & _
                                "                                          ORDER BY 7                                                           "

            _custAccountDatatable = OraDBHelper2.GetResultSet(query)
        End Sub

        Public Function LoadAccounts(Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable

            Dim rowfilter As String
            If custType = CustomerType.Both Then
                If showInactiveAccounts Then
                    Return _custAccountDatatable
                Else
                    rowfilter = "account_status = 'ACTIVE'"
                End If

            Else
                If custType = CustomerType.UnitOwner Then
                    rowfilter = "cust_type = 'UNIT OWNER'"
                Else
                    rowfilter = "cust_type = 'TENANT'"
                End If

                If Not showInactiveAccounts Then
                    rowfilter &= " AND account_status = 'ACTIVE'"
                End If
            End If


            Using dv As New DataView(_custAccountDatatable)
                dv.RowFilter = rowfilter
                Return dv.ToTable()
            End Using

        End Function

        Public Function LoadAccounts(ByVal searchType As SearchAccountType, ByVal searchValue As String, Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable
            Dim rowfilter As String = String.Empty

            Select Case searchType
                Case SearchAccountType.UnitNumber
                    rowfilter = "unit_number ='" & searchValue & "'"
                Case SearchAccountType.Firstname
                    rowfilter = "first_name like '%" & searchValue & "%'"
                Case SearchAccountType.LastName
                    rowfilter = "last_name like '%" & searchValue & "%'"
            End Select

            If custType <> CustomerType.Both Then
                If custType = CustomerType.UnitOwner Then
                    rowfilter &= " AND cust_type = 'UNIT OWNER'"
                Else
                    rowfilter &= " AND cust_type = 'TENANT'"
                End If
            End If

            If Not showInactiveAccounts Then
                rowfilter &= " AND account_status = 'ACTIVE'"
            End If

            Using dv As New DataView(_custAccountDatatable)
                dv.RowFilter = rowfilter
                Return dv.ToTable()
            End Using

        End Function

        Public Sub Refresh()
            LoadCustomerAccounts()
            LoadCustomerOnly()
        End Sub

    End Class


    Public Class Customer
        Public CustID As String

        Public Property LastName As String
        Public Property FirstName As String
        Public Property MiddleName As String

        Public ReadOnly Property FullNameLastNameFirst As String
            Get
                Return String.Format("{0}, {1} {2}", LastName, FirstName, MiddleName)
            End Get
        End Property

        Public ReadOnly Property FullNameFirstNameFirst As String
            Get
                If String.IsNullOrEmpty(MiddleName) Then
                    Return String.Format("{0} {1}", FirstName, LastName)
                Else
                    Return String.Format("{0} {1}. {2}", FirstName, MiddleName.Substring(0, 1), LastName)
                End If
            End Get
        End Property
    End Class

    Public Class CustAccountDTO
        Public AccountID As String
        Private CustID As String
        ''Private ID As 
        Public UnitID As String
        Public Property UnitNumber As String
        Public Property UnitType As String
        Public Property AccountStatus As String
        Public Property LastName As String
        Public Property FirstName As String
        Public Property MiddleName As String
        Public ReadOnly Property FullName As String
            Get
                Return String.Format("{0}, {1} {2}", LastName, FirstName, MiddleName)
            End Get
        End Property


    End Class

    Public Class CustomerAccountDataAccess

        Private _custAccountList As List(Of CustAccountDTO)
        Public ReadOnly Property CustAccountList() As List(Of CustAccountDTO)
            Get
                Return _custAccountList
            End Get
        End Property

        'Private _customersDataTable As DataTable
        'Public ReadOnly Property CustomersDataTable() As DataTable
        '    Get
        '        Return _customersDataTable
        '    End Get
        'End Property

        Public Sub New()
            'LoadCustomerOnly()
            LoadCustomerAccounts()
        End Sub

        'Private Sub LoadCustomerOnly()
        '    Dim query As String = "SELECT cust_id, cust_lname last_name, cust_fname first_name, cust_mname middle_name" & _
        '                        "  FROM customers                                       " & _
        '                        "  ORDER BY 2"

        '    _customersDataTable = OraDBHelper2.GetResultSet(query)
        'End Sub

        'Public Function LoadCustomers() As DataTable
        '    Return _customersDataTable
        'End Function

        'Public Function LoadCustomers(ByVal searchType As SearchAccountType, ByVal searchValue As String) As DataTable
        '    Dim rowfilter As String = String.Empty

        '    Select Case searchType
        '        Case SearchAccountType.Firstname
        '            rowfilter = "first_name like '%" & searchValue & "%'"
        '        Case SearchAccountType.LastName
        '            rowfilter = "last_name like '%" & searchValue & "%'"
        '    End Select

        '    Using dv As New DataView(_customersDataTable)
        '        dv.RowFilter = rowfilter
        '        Return dv.ToTable()
        '    End Using

        'End Function

        Private Sub LoadCustomerAccounts()

            Dim query As String = "SELECT   *                                                                   " & _
                                "    FROM (SELECT account_id, acct_cust_id cust_id, NULL lease_id, unit_id,   " & _
                                "                 cust_unit_no unit_number,                                   " & _
                                "                 CASE (SELECT unit_subclass                                  " & _
                                "                         FROM am_unit                                        " & _
                                "                        WHERE unit_id = cs.unit_id)                          " & _
                                "                    WHEN 'RES'                                               " & _
                                "                       THEN 'CONDO UNIT'                                     " & _
                                "                    WHEN 'COMM'                                              " & _
                                "                       THEN 'CONDO UNIT'                                     " & _
                                "                    WHEN 'PARK'                                              " & _
                                "                       THEN 'PARKING SLOT'                                   " & _
                                "                 END unit_class,                                             " & _
                                "                 cust_unit_sort,                                             " & _
                                "                 DECODE (account_status,                                     " & _
                                "                         'ACT', 'ACTIVE',                                    " & _
                                "                         'INACTIVE'                                          " & _
                                "                        ) account_status,                                    " & _
                                "                 (SELECT cust_lname                                          " & _
                                "                    FROM customers                                           " & _
                                "                   WHERE cust_id = cs.acct_cust_id) last_name,               " & _
                                "                 (SELECT cust_fname                                          " & _
                                "                    FROM customers                                           " & _
                                "                   WHERE cust_id = cs.acct_cust_id) first_name,              " & _
                                "                 (SELECT cust_mname                                          " & _
                                "                    FROM customers                                           " & _
                                "                   WHERE cust_id = cs.acct_cust_id) middle_name,             " & _
                                "                 'UNIT OWNER' cust_type                                      " & _
                                "            FROM customer_accounts cs                                        " & _
                                "          UNION                                                              " & _
                                "          SELECT NULL, NULL, NULL, unit_id, unit_number, unit_subclass,      " & _
                                "                    LPAD (bldg_no, 2, '0')                                   " & _
                                "                 || '-'                                                      " & _
                                "                 || LPAD (cluster_no, 2, '0')                                " & _
                                "                 || '-'                                                      " & _
                                "                 || LPAD (floor_no, 2, '0')                                  " & _
                                "                 || '-'                                                      " & _
                                "                 || LPAD (unit_no, 2, '0') cust_unit_sort,                   " & _
                                "                 NULL, NULL, NULL, NULL, NULL                                " & _
                                "            FROM am_unit                                                     " & _
                                "           WHERE unit_id NOT IN (SELECT unit_id                              " & _
                                "                                   FROM customer_accounts                    " & _
                                "                                  WHERE account_status = 'ACT')              " & _
                                "          UNION                                                              " & _
                                "          SELECT account_id, cust_id, lease_id,                              " & _
                                "                 (SELECT unit_id                                             " & _
                                "                    FROM customer_accounts                                   " & _
                                "                   WHERE account_id = cc.account_id) unit_id,                " & _
                                "                 accounts.getunitnumber (account_id) unit_number,            " & _
                                "                 CASE (SELECT unit_subclass                                  " & _
                                "                         FROM am_unit                                        " & _
                                "                        WHERE unit_id =                                      " & _
                                "                                 (SELECT unit_id                             " & _
                                "                                    FROM customer_accounts                   " & _
                                "                                   WHERE account_id =                        " & _
                                "                                                     cc.account_id))         " & _
                                "                    WHEN 'RES'                                               " & _
                                "                       THEN 'CONDO UNIT'                                     " & _
                                "                    WHEN 'COMM'                                              " & _
                                "                       THEN 'CONDO UNIT'                                     " & _
                                "                    WHEN 'PARK'                                              " & _
                                "                       THEN 'PARKING SLOT'                                   " & _
                                "                 END unit_class,                                             " & _
                                "                 (SELECT cust_unit_sort                                      " & _
                                "                    FROM customer_accounts                                   " & _
                                "                   WHERE account_id = cc.account_id) cust_unit_sort,         " & _
                                "                 account_status, (SELECT cust_lname                          " & _
                                "                                    FROM customers                           " & _
                                "                                   WHERE cust_id = cc.cust_id) last_name,    " & _
                                "                 (SELECT cust_fname                                          " & _
                                "                    FROM customers                                           " & _
                                "                   WHERE cust_id = cc.cust_id) first_name,                   " & _
                                "                 (SELECT cust_mname                                          " & _
                                "                    FROM customers                                           " & _
                                "                   WHERE cust_id = cc.cust_id) middle_name,                  " & _
                                "                 'TENANT' cust_type                                          " & _
                                "            FROM (SELECT lease_id,                                           " & _
                                "                         (SELECT account_id                                  " & _
                                "                            FROM rm_agreement                                " & _
                                "                           WHERE agreement_id = lc.agreement_id) account_id, " & _
                                "                         cust_id,                                            " & _
                                "                         CASE contract_status                                " & _
                                "                            WHEN 'FAP'                                       " & _
                                "                               THEN 'ACTIVE'                                 " & _
                                "                            WHEN 'ACT'                                       " & _
                                "                               THEN 'ACTIVE'                                 " & _
                                "                            WHEN 'EXP'                                       " & _
                                "                               THEN 'INACTIVE'                               " & _
                                "                         END account_status                                  " & _
                                "                    FROM rm_lease_contract lc                                " & _
                                "                   WHERE contract_status NOT IN ('VOID')) cc)                " & _
                                "ORDER BY 7                                                                   "

            ''_custAccountDatatable = OraDBHelper2.GetResultSet(query)
            _custAccountList = New List(Of CustAccountDTO)
            For Each row As DataRow In OraDBHelper2.GetResultSet(query).Rows
                _custAccountList.Add(New CustAccountDTO With {.AccountID = row("account_id").ToString,
                                                              .UnitID = row("unit_id").ToString,
                                                              .FirstName = row("first_name").ToString,
                                                              .LastName = row("last_name").ToString,
                                                              .UnitNumber = row("unit_number").ToString,
                                                              .UnitType = row("unit_class").ToString,
                                                              .AccountStatus = row("account_status").ToString})
            Next
            ''.MiddleName = row("middle_name").ToString,
        End Sub

        Public Function GetAllAccounts(includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
            If includeInactiveAccounts Then
                Return CustAccountList
            Else
                Return (From accounts In CustAccountList
                         Where accounts.AccountStatus.Equals("ACTIVE")
                         Select accounts).ToList
            End If
        End Function

        Public Function GetAccountsByUnitNumber(unitNumber As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
            If includeInactiveAccounts Then
                Return (From accounts In CustAccountList
                        Where accounts.UnitNumber.Equals(unitNumber)
                        Select accounts).ToList
            Else
                Return (From accounts In CustAccountList
                    Where accounts.UnitNumber.Equals(unitNumber) And accounts.AccountStatus.Equals("ACTIVE")
                    Select accounts).ToList
            End If
        End Function

        Public Function GetAccountsByCustFirstName(firstName As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
            If includeInactiveAccounts Then
                Return (From accounts In CustAccountList
                        Where accounts.FirstName.Contains(firstName)
                        Select accounts).ToList
            Else
                Return (From accounts In CustAccountList
                    Where accounts.FirstName.Contains(firstName) And accounts.AccountStatus.Equals("ACTIVE")
                    Select accounts).ToList
            End If
        End Function

        Public Function GetAccountsByCustLastName(lastName As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
            If includeInactiveAccounts Then
                Return (From accounts In CustAccountList
                        Where accounts.LastName.Contains(lastName)
                        Select accounts).ToList
            Else
                Return (From accounts In CustAccountList
                    Where accounts.LastName.Contains(lastName) And accounts.AccountStatus.Equals("ACTIVE")
                    Select accounts).ToList
            End If
        End Function


        'Public Function LoadAccounts(Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable

        '    Dim rowfilter As String
        '    If custType = CustomerType.Both Then
        '        If showInactiveAccounts Then
        '            Return _custAccountDatatable
        '        Else
        '            rowfilter = "account_status = 'ACTIVE'"
        '        End If

        '    Else
        '        If custType = CustomerType.UnitOwner Then
        '            rowfilter = "cust_type = 'UNIT OWNER'"
        '        Else
        '            rowfilter = "cust_type = 'TENANT'"
        '        End If

        '        If Not showInactiveAccounts Then
        '            rowfilter &= " AND account_status = 'ACTIVE'"
        '        End If
        '    End If


        '    Using dv As New DataView(_custAccountDatatable)
        '        dv.RowFilter = rowfilter
        '        Return dv.ToTable()
        '    End Using

        'End Function

        'Public Function LoadAccounts(ByVal searchType As SearchAccountType, ByVal searchValue As String, Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable
        '    Dim rowfilter As String = String.Empty

        '    Select Case searchType
        '        Case SearchAccountType.UnitNumber
        '            rowfilter = "unit_number ='" & searchValue & "'"
        '        Case SearchAccountType.Firstname
        '            rowfilter = "first_name like '%" & searchValue & "%'"
        '        Case SearchAccountType.LastName
        '            rowfilter = "last_name like '%" & searchValue & "%'"
        '    End Select

        '    If custType <> CustomerType.Both Then
        '        If custType = CustomerType.UnitOwner Then
        '            rowfilter &= " AND cust_type = 'UNIT OWNER'"
        '        Else
        '            rowfilter &= " AND cust_type = 'TENANT'"
        '        End If
        '    End If

        '    If Not showInactiveAccounts Then
        '        rowfilter &= " AND account_status = 'ACTIVE'"
        '    End If

        '    Using dv As New DataView(_custAccountDatatable)
        '        dv.RowFilter = rowfilter
        '        Return dv.ToTable()
        '    End Using

        'End Function

        Public Sub Refresh()
            LoadCustomerAccounts()
            ''LoadCustomerOnly()
        End Sub

    End Class

End Namespace

'Namespace Common.New


'    Public Enum AccountStatus
'        <DisplayName("ACTIVE")> _
'        <DBValue("ACT")> _
'        Active
'        <DisplayName("INACTIVE")> _
'        <DBValue("INACT")> _
'        Inactive
'    End Enum

'    Public Enum UnitType
'        <DisplayName("CONDO UNIT")> _
'        <DBValue("CONDO")> _
'        Active
'        <DisplayName("PARKING SLOT")> _
'        <DBValue("PARK")> _
'        Inactive
'    End Enum


'    Public Class Customer
'        Public Property CustomerID As String

'        Public Property LastName As String
'        Public Property FirstName As String
'        Public Property MiddleName As String

'        Public Property BuyerCode As String

'        Public ReadOnly Property FullNameLastNameFirst As String
'            Get
'                Return String.Format("{0}, {1} {2}", LastName, FirstName, MiddleName)
'            End Get
'        End Property

'        Public ReadOnly Property FullNameFirstNameFirst As String
'            Get
'                If String.IsNullOrEmpty(MiddleName) Then
'                    Return String.Format("{0} {1}", FirstName, LastName)
'                Else
'                    Return String.Format("{0} {1}. {2}", FirstName, MiddleName.Substring(0, 1), LastName)
'                End If
'            End Get
'        End Property
'    End Class

'    Public Class CustomerAccount
'        Public Property AccountID As String
'        Public Property UnitOwner As Customer
'        Public Property Tenant As Customer

'        Public Property UnitNumber As String

'        Public Property UnitType As UnitType

'        Public Property AccountStatus As AccountStatus

'        Public Property UnitOrder As String
'    End Class

'    Public Class AccountsDA
'        Private _customerAccounts As List(Of CustomerAccount)
'        Public ReadOnly Property CustomerAccounts() As List(Of CustomerAccount)
'            Get
'                Return _customerAccounts
'            End Get
'        End Property

'        Private _customers As List(Of Customer)
'        Public ReadOnly Property Customers() As List(Of Customer)
'            Get
'                Return _customers
'            End Get
'        End Property

'        Public Sub New()
'            LoadCustomers()
'            LoadCustomerAccounts()
'        End Sub

'        Private Sub LoadCustomers()

'            _customers = New List(Of Customer)

'            Using param As New OraParameter


'                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

'                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("accounts.getcustomers", param.GetParameterCollection).Rows
'                    _customers.Add(New Customer With {.CustomerID = row("cust_id").ToString,
'                                                      .LastName = row("cust_lname").ToString,
'                                                      .FirstName = row("cust_fname").ToString,
'                                                      .MiddleName = row("cust_mname").ToString})
'                Next
'            End Using
'        End Sub

'        Private Sub LoadCustomerAccounts()

'            _customerAccounts = New List(Of CustomerAccount)

'            Using param As New OraParameter


'                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

'                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("accounts.getcustomeraccounts", param.GetParameterCollection).Rows
'                    _customerAccounts.Add(New CustomerAccount With {.AccountID = row("account_id").ToString,
'                                                      .UnitNumber = row("cust_unit_no").ToString,
'                                                      .UnitOrder = row("cust_unit_sort").ToString,
'                                                      .AccountStatus = EnumExtensions.Entry(Of AccountStatus)(row("account_status").ToString),
'                                                      .UnitType = EnumExtensions.Entry(Of UnitType)(row("account_class").ToString),
'                                                      .UnitOwner = GetCustomerByID(row("acct_cust_id").ToString)})

'                Next
'            End Using
'        End Sub

'        Public Function GetCustomerByID(custID As String) As Customer

'            Return (From cust In Customers
'                   Where cust.CustomerID = custID
'                   Select cust).SingleOrDefault

'        End Function

'        Public Function GetUnitOwnerAccountByID(accountID As String) As CustomerAccount

'            Return (From account In CustomerAccounts
'                   Where account.AccountID = accountID
'                   Select account).SingleOrDefault

'        End Function

'        Public Function GetUnitOwnerAcccounts(Optional includeInactive As Boolean = False) As List(Of CustomerAccount)
'            If includeInactive Then
'                Return _customerAccounts
'            Else
'                Return (From accounts In _customerAccounts
'                         Where accounts.AccountStatus = AccountStatus.Active
'                         Select accounts).ToList
'            End If

'        End Function

'        Public Function GetUnitOwnerByUnitNumber(unitNumber As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
'            If includeInactiveAccounts Then
'                Return (From accounts In _customerAccounts
'                        Where accounts.UnitNumber.Equals(unitNumber)
'                        Select accounts).ToList
'            Else
'                Return (From accounts In _customerAccounts
'                    Where accounts.UnitNumber.Equals(unitNumber) And accounts.AccountStatus = AccountStatus.Active
'                    Select accounts).ToList
'            End If
'        End Function

'        Public Function GetUnitOwnerByCustFirstName(firstName As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
'            If includeInactiveAccounts Then
'                Return (From accounts In _customerAccounts
'                        Where accounts.UnitOwner.FirstName.Contains(firstName)
'                        Select accounts).ToList
'            Else
'                Return (From accounts In _customerAccounts
'                    Where accounts.UnitOwner.FirstName.Contains(firstName) And accounts.AccountStatus = AccountStatus.Active
'                    Select accounts).ToList
'            End If
'        End Function

'        Public Function GetUnitOwnerByCustLastName(lastName As String, includeInactiveAccounts As Boolean) As List(Of CustomerAccount)
'            If includeInactiveAccounts Then
'                Return (From accounts In _customerAccounts
'                        Where accounts.UnitOwner.LastName.Contains(lastName)
'                        Select accounts).ToList
'            Else
'                Return (From accounts In _customerAccounts
'                    Where accounts.UnitOwner.LastName.Contains(lastName) And accounts.AccountStatus = AccountStatus.Active
'                    Select accounts).ToList
'            End If
'        End Function

'        Public Function GetTenantAcccounts(Optional includeInactive As Boolean = False) As List(Of CustomerAccount)
'            If includeInactive Then
'                Return _customerAccounts
'            Else
'                Return (From accounts In _customerAccounts
'                         Where accounts.AccountStatus = AccountStatus.Active
'                         Select accounts).ToList
'            End If

'        End Function

'        Public Sub ReloadData()
'            LoadCustomers()
'            LoadCustomerAccounts()
'        End Sub

'        Public Function SaveCustomer(cust As Customer) As Integer
'            Using param As New OraParameter

'                param.AddParameter("customerlastname", cust.LastName)
'                param.AddParameter("customerfirstname", cust.FirstName)
'                param.AddParameter("customermiddlename", cust.MiddleName)
'                param.AddParameter("custid", Nothing, OracleDbType.Int32, ParameterDirection.ReturnValue)

'                Return DirectCast(OraDBHelper2.ExecuteFunction("accounts.insertcustomer", param.GetParameterCollection), OracleDecimal).ToInt32

'                LoadCustomers()
'            End Using
'        End Function
'    End Class

'    'Public Class CustAccountDTO
'    '    Public AccountID As String
'    '    Private CustID As String
'    '    ''Private ID As 
'    '    Public UnitID As String
'    '    Public Property UnitNumber As String
'    '    Public Property UnitType As String
'    '    Public Property AccountStatus As String
'    '    Public Property LastName As String
'    '    Public Property FirstName As String
'    '    Public Property MiddleName As String
'    '    Public ReadOnly Property FullName As String
'    '        Get
'    '            Return String.Format("{0}, {1} {2}", LastName, FirstName, MiddleName)
'    '        End Get
'    '    End Property


'    'End Class

'    'Public Class CustomerAccountDataAccess

'    '    Private _custAccountList As List(Of CustAccountDTO)
'    '    Public ReadOnly Property CustAccountList() As List(Of CustAccountDTO)
'    '        Get
'    '            Return _custAccountList
'    '        End Get
'    '    End Property

'    '    'Private _customersDataTable As DataTable
'    '    'Public ReadOnly Property CustomersDataTable() As DataTable
'    '    '    Get
'    '    '        Return _customersDataTable
'    '    '    End Get
'    '    'End Property

'    '    Public Sub New()
'    '        'LoadCustomerOnly()
'    '        LoadCustomerAccounts()
'    '    End Sub

'    '    'Private Sub LoadCustomerOnly()
'    '    '    Dim query As String = "SELECT cust_id, cust_lname last_name, cust_fname first_name, cust_mname middle_name" & _
'    '    '                        "  FROM customers                                       " & _
'    '    '                        "  ORDER BY 2"

'    '    '    _customersDataTable = OraDBHelper2.GetResultSet(query)
'    '    'End Sub

'    '    'Public Function LoadCustomers() As DataTable
'    '    '    Return _customersDataTable
'    '    'End Function

'    '    'Public Function LoadCustomers(ByVal searchType As SearchAccountType, ByVal searchValue As String) As DataTable
'    '    '    Dim rowfilter As String = String.Empty

'    '    '    Select Case searchType
'    '    '        Case SearchAccountType.Firstname
'    '    '            rowfilter = "first_name like '%" & searchValue & "%'"
'    '    '        Case SearchAccountType.LastName
'    '    '            rowfilter = "last_name like '%" & searchValue & "%'"
'    '    '    End Select

'    '    '    Using dv As New DataView(_customersDataTable)
'    '    '        dv.RowFilter = rowfilter
'    '    '        Return dv.ToTable()
'    '    '    End Using

'    '    'End Function

'    '    Private Sub LoadCustomerAccounts()

'    '        Dim query As String = "SELECT   *                                                                   " & _
'    '                            "    FROM (SELECT account_id, acct_cust_id cust_id, NULL lease_id, unit_id,   " & _
'    '                            "                 cust_unit_no unit_number,                                   " & _
'    '                            "                 CASE (SELECT unit_subclass                                  " & _
'    '                            "                         FROM am_unit                                        " & _
'    '                            "                        WHERE unit_id = cs.unit_id)                          " & _
'    '                            "                    WHEN 'RES'                                               " & _
'    '                            "                       THEN 'CONDO UNIT'                                     " & _
'    '                            "                    WHEN 'COMM'                                              " & _
'    '                            "                       THEN 'CONDO UNIT'                                     " & _
'    '                            "                    WHEN 'PARK'                                              " & _
'    '                            "                       THEN 'PARKING SLOT'                                   " & _
'    '                            "                 END unit_class,                                             " & _
'    '                            "                 cust_unit_sort,                                             " & _
'    '                            "                 DECODE (account_status,                                     " & _
'    '                            "                         'ACT', 'ACTIVE',                                    " & _
'    '                            "                         'INACTIVE'                                          " & _
'    '                            "                        ) account_status,                                    " & _
'    '                            "                 (SELECT cust_lname                                          " & _
'    '                            "                    FROM customers                                           " & _
'    '                            "                   WHERE cust_id = cs.acct_cust_id) last_name,               " & _
'    '                            "                 (SELECT cust_fname                                          " & _
'    '                            "                    FROM customers                                           " & _
'    '                            "                   WHERE cust_id = cs.acct_cust_id) first_name,              " & _
'    '                            "                 (SELECT cust_mname                                          " & _
'    '                            "                    FROM customers                                           " & _
'    '                            "                   WHERE cust_id = cs.acct_cust_id) middle_name,             " & _
'    '                            "                 'UNIT OWNER' cust_type                                      " & _
'    '                            "            FROM customer_accounts cs                                        " & _
'    '                            "          UNION                                                              " & _
'    '                            "          SELECT NULL, NULL, NULL, unit_id, unit_number, unit_subclass,      " & _
'    '                            "                    LPAD (bldg_no, 2, '0')                                   " & _
'    '                            "                 || '-'                                                      " & _
'    '                            "                 || LPAD (cluster_no, 2, '0')                                " & _
'    '                            "                 || '-'                                                      " & _
'    '                            "                 || LPAD (floor_no, 2, '0')                                  " & _
'    '                            "                 || '-'                                                      " & _
'    '                            "                 || LPAD (unit_no, 2, '0') cust_unit_sort,                   " & _
'    '                            "                 NULL, NULL, NULL, NULL, NULL                                " & _
'    '                            "            FROM am_unit                                                     " & _
'    '                            "           WHERE unit_id NOT IN (SELECT unit_id                              " & _
'    '                            "                                   FROM customer_accounts                    " & _
'    '                            "                                  WHERE account_status = 'ACT')              " & _
'    '                            "          UNION                                                              " & _
'    '                            "          SELECT account_id, cust_id, lease_id,                              " & _
'    '                            "                 (SELECT unit_id                                             " & _
'    '                            "                    FROM customer_accounts                                   " & _
'    '                            "                   WHERE account_id = cc.account_id) unit_id,                " & _
'    '                            "                 accounts.getunitnumber (account_id) unit_number,            " & _
'    '                            "                 CASE (SELECT unit_subclass                                  " & _
'    '                            "                         FROM am_unit                                        " & _
'    '                            "                        WHERE unit_id =                                      " & _
'    '                            "                                 (SELECT unit_id                             " & _
'    '                            "                                    FROM customer_accounts                   " & _
'    '                            "                                   WHERE account_id =                        " & _
'    '                            "                                                     cc.account_id))         " & _
'    '                            "                    WHEN 'RES'                                               " & _
'    '                            "                       THEN 'CONDO UNIT'                                     " & _
'    '                            "                    WHEN 'COMM'                                              " & _
'    '                            "                       THEN 'CONDO UNIT'                                     " & _
'    '                            "                    WHEN 'PARK'                                              " & _
'    '                            "                       THEN 'PARKING SLOT'                                   " & _
'    '                            "                 END unit_class,                                             " & _
'    '                            "                 (SELECT cust_unit_sort                                      " & _
'    '                            "                    FROM customer_accounts                                   " & _
'    '                            "                   WHERE account_id = cc.account_id) cust_unit_sort,         " & _
'    '                            "                 account_status, (SELECT cust_lname                          " & _
'    '                            "                                    FROM customers                           " & _
'    '                            "                                   WHERE cust_id = cc.cust_id) last_name,    " & _
'    '                            "                 (SELECT cust_fname                                          " & _
'    '                            "                    FROM customers                                           " & _
'    '                            "                   WHERE cust_id = cc.cust_id) first_name,                   " & _
'    '                            "                 (SELECT cust_mname                                          " & _
'    '                            "                    FROM customers                                           " & _
'    '                            "                   WHERE cust_id = cc.cust_id) middle_name,                  " & _
'    '                            "                 'TENANT' cust_type                                          " & _
'    '                            "            FROM (SELECT lease_id,                                           " & _
'    '                            "                         (SELECT account_id                                  " & _
'    '                            "                            FROM rm_agreement                                " & _
'    '                            "                           WHERE agreement_id = lc.agreement_id) account_id, " & _
'    '                            "                         cust_id,                                            " & _
'    '                            "                         CASE contract_status                                " & _
'    '                            "                            WHEN 'FAP'                                       " & _
'    '                            "                               THEN 'ACTIVE'                                 " & _
'    '                            "                            WHEN 'ACT'                                       " & _
'    '                            "                               THEN 'ACTIVE'                                 " & _
'    '                            "                            WHEN 'EXP'                                       " & _
'    '                            "                               THEN 'INACTIVE'                               " & _
'    '                            "                         END account_status                                  " & _
'    '                            "                    FROM rm_lease_contract lc                                " & _
'    '                            "                   WHERE contract_status NOT IN ('VOID')) cc)                " & _
'    '                            "ORDER BY 7                                                                   "

'    '        ''_custAccountDatatable = OraDBHelper2.GetResultSet(query)
'    '        _custAccountList = New List(Of CustAccountDTO)
'    '        For Each row As DataRow In OraDBHelper2.GetResultSet(query).Rows
'    '            _custAccountList.Add(New CustAccountDTO With {.AccountID = row("account_id").ToString,
'    '                                                          .UnitID = row("unit_id").ToString,
'    '                                                          .FirstName = row("first_name").ToString,
'    '                                                          .LastName = row("last_name").ToString,
'    '                                                          .UnitNumber = row("unit_number").ToString,
'    '                                                          .UnitType = row("unit_class").ToString,
'    '                                                          .AccountStatus = row("account_status").ToString})
'    '        Next
'    '        ''.MiddleName = row("middle_name").ToString,
'    '    End Sub

'    '    Public Function GetAllAccounts(includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
'    '        If includeInactiveAccounts Then
'    '            Return CustAccountList
'    '        Else
'    '            Return (From accounts In CustAccountList
'    '                     Where accounts.AccountStatus.Equals("ACTIVE")
'    '                     Select accounts).ToList
'    '        End If
'    '    End Function

'    '    Public Function GetAccountsByUnitNumber(unitNumber As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
'    '        If includeInactiveAccounts Then
'    '            Return (From accounts In CustAccountList
'    '                    Where accounts.UnitNumber.Equals(unitNumber)
'    '                    Select accounts).ToList
'    '        Else
'    '            Return (From accounts In CustAccountList
'    '                Where accounts.UnitNumber.Equals(unitNumber) And accounts.AccountStatus.Equals("ACTIVE")
'    '                Select accounts).ToList
'    '        End If
'    '    End Function

'    '    Public Function GetAccountsByCustFirstName(firstName As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
'    '        If includeInactiveAccounts Then
'    '            Return (From accounts In CustAccountList
'    '                    Where accounts.FirstName.Contains(firstName)
'    '                    Select accounts).ToList
'    '        Else
'    '            Return (From accounts In CustAccountList
'    '                Where accounts.FirstName.Contains(firstName) And accounts.AccountStatus.Equals("ACTIVE")
'    '                Select accounts).ToList
'    '        End If
'    '    End Function

'    '    Public Function GetAccountsByCustLastName(lastName As String, includeInactiveAccounts As Boolean) As List(Of CustAccountDTO)
'    '        If includeInactiveAccounts Then
'    '            Return (From accounts In CustAccountList
'    '                    Where accounts.LastName.Contains(lastName)
'    '                    Select accounts).ToList
'    '        Else
'    '            Return (From accounts In CustAccountList
'    '                Where accounts.LastName.Contains(lastName) And accounts.AccountStatus.Equals("ACTIVE")
'    '                Select accounts).ToList
'    '        End If
'    '    End Function


'    '    'Public Function LoadAccounts(Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable

'    '    '    Dim rowfilter As String
'    '    '    If custType = CustomerType.Both Then
'    '    '        If showInactiveAccounts Then
'    '    '            Return _custAccountDatatable
'    '    '        Else
'    '    '            rowfilter = "account_status = 'ACTIVE'"
'    '    '        End If

'    '    '    Else
'    '    '        If custType = CustomerType.UnitOwner Then
'    '    '            rowfilter = "cust_type = 'UNIT OWNER'"
'    '    '        Else
'    '    '            rowfilter = "cust_type = 'TENANT'"
'    '    '        End If

'    '    '        If Not showInactiveAccounts Then
'    '    '            rowfilter &= " AND account_status = 'ACTIVE'"
'    '    '        End If
'    '    '    End If


'    '    '    Using dv As New DataView(_custAccountDatatable)
'    '    '        dv.RowFilter = rowfilter
'    '    '        Return dv.ToTable()
'    '    '    End Using

'    '    'End Function

'    '    'Public Function LoadAccounts(ByVal searchType As SearchAccountType, ByVal searchValue As String, Optional custType As CustomerType = CustomerType.Both, Optional ByVal showInactiveAccounts As Boolean = False) As DataTable
'    '    '    Dim rowfilter As String = String.Empty

'    '    '    Select Case searchType
'    '    '        Case SearchAccountType.UnitNumber
'    '    '            rowfilter = "unit_number ='" & searchValue & "'"
'    '    '        Case SearchAccountType.Firstname
'    '    '            rowfilter = "first_name like '%" & searchValue & "%'"
'    '    '        Case SearchAccountType.LastName
'    '    '            rowfilter = "last_name like '%" & searchValue & "%'"
'    '    '    End Select

'    '    '    If custType <> CustomerType.Both Then
'    '    '        If custType = CustomerType.UnitOwner Then
'    '    '            rowfilter &= " AND cust_type = 'UNIT OWNER'"
'    '    '        Else
'    '    '            rowfilter &= " AND cust_type = 'TENANT'"
'    '    '        End If
'    '    '    End If

'    '    '    If Not showInactiveAccounts Then
'    '    '        rowfilter &= " AND account_status = 'ACTIVE'"
'    '    '    End If

'    '    '    Using dv As New DataView(_custAccountDatatable)
'    '    '        dv.RowFilter = rowfilter
'    '    '        Return dv.ToTable()
'    '    '    End Using

'    '    'End Function

'    '    Public Sub Refresh()
'    '        LoadCustomerAccounts()
'    '        ''LoadCustomerOnly()
'    '    End Sub

'    'End Class
'End Namespace

