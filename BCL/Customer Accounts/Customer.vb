Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common


Namespace CustomerAccounts

    Public Class Customer

#Region "PROPERTIES"

        Private _customerId As String

        Public Property CustomerId() As String
            Get
                Return _customerId
            End Get
            Set(ByVal Value As String)
                _customerId = Value
            End Set
        End Property

        Private _lastName As String

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal Value As String)
                _lastName = Value
            End Set
        End Property

        Private _firstName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal Value As String)
                _firstName = Value
            End Set
        End Property

        Private _middleName As String

        Public Property MiddleName() As String
            Get
                Return _middleName
            End Get
            Set(ByVal Value As String)
                _middleName = Value
            End Set
        End Property

        Private _gender As GenderList

        Public Property Gender() As GenderList
            Get
                Return _gender
            End Get
            Set(ByVal Value As GenderList)
                _gender = Value
            End Set
        End Property


        Private _maritalStatus As CivilStatus

        Public Property MaritalStatus() As CivilStatus
            Get
                Return _maritalStatus
            End Get
            Set(ByVal Value As CivilStatus)
                _maritalStatus = Value
            End Set
        End Property

        Private _BirthDate As Nullable(Of Date)

        Public Property Birthdate() As Nullable(Of Date)
            Get
                Return _BirthDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _BirthDate = Value
            End Set
        End Property

        Private _citizenship As String

        Public Property Citizenship() As String
            Get
                Return _citizenship
            End Get
            Set(ByVal Value As String)
                _citizenship = Value
            End Set
        End Property

        Private _religion As String

        Public Property Religion() As String
            Get
                Return _religion
            End Get
            Set(ByVal Value As String)
                _religion = Value
            End Set
        End Property

        Private _company As String

        Public Property Company() As String
            Get
                Return _company
            End Get
            Set(ByVal Value As String)
                _company = Value
            End Set
        End Property

        Private _occupation As String

        Public Property Occupation() As String
            Get
                Return _occupation
            End Get
            Set(ByVal Value As String)
                _occupation = Value
            End Set
        End Property

        Private _nameSake As NameSake

        Public Property NameSake() As NameSake
            Get
                Return _nameSake
            End Get
            Set(ByVal Value As NameSake)
                _nameSake = Value
            End Set
        End Property

        Private _customerCode As String

        Public Property CustomerCode() As String
            Get
                Return _customerCode
            End Get
            Set(ByVal Value As String)
                _customerCode = Value
            End Set
        End Property


#End Region

        Public Shared Function GetCustomerInfoByCustomerID(ByVal customerID As String) As Customer

            Dim query As String = "SELECT CUST_ID                 " & _
                                  "     , CUST_LNAME              " & _
                                  "     , CUST_FNAME              " & _
                                  "     , CUST_MNAME              " & _
                                  "     , CUST_CONTACT_NO         " & _
                                  "     , CUST_SEX                " & _
                                  "     , CUST_MARITAL_STATUS     " & _
                                  "     , EMAIL_ADDRESS           " & _
                                  "     , MOBILE_NOS              " & _
                                  "     , LANDLINE_NOS            " & _
                                  "     , BIRTH_DATE              " & _
                                  "     , CITIZENSHIP             " & _
                                  "     , RELIGION                " & _
                                  "     , COMPANY                 " & _
                                  "     , OCCUPATION              " & _
                                  "     , NAME_SAKE              " & _
                                  "     , CUSTOMER_CODE              " & _
                                  "FROM CUSTOMERS                 " & _
                                  "WHERE CUST_ID = :customerID    "


            Dim customerinfo As New Customer
            customerinfo.CustomerID = customerID

            Using param As New OraParameter

                param.AddItem(":customerID", customerID, OracleDbType.BinaryDouble)
                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

                    customerinfo.CustomerId = .Rows(0)("CUST_ID").ToString

                    customerinfo.LastName = .Rows(0)("CUST_LNAME").ToString

                    customerinfo.FirstName = .Rows(0)("CUST_FNAME").ToString

                    customerinfo.MiddleName = .Rows(0)("CUST_MNAME").ToString

                    If Not Convert.IsDBNull(.Rows(0)("CUST_SEX")) Then

                        customerinfo.Gender = EnumHelper.GetEnumValueFromDBValue(Of GenderList)(.Rows(0)("CUST_SEX").ToString)

                    End If


                    If Not Convert.IsDBNull(.Rows(0)("CUST_MARITAL_STATUS")) Then

                        customerinfo.MaritalStatus = EnumHelper.GetEnumValueFromDBValue(Of CivilStatus)(.Rows(0)("CUST_MARITAL_STATUS").ToString)

                    End If


                    If Not Convert.IsDBNull(.Rows(0)("BIRTH_DATE")) Then

                        customerinfo.Birthdate = Date.Parse(.Rows(0)("BIRTH_DATE"))

                    End If

                    customerinfo.Citizenship = .Rows(0)("CITIZENSHIP").ToString

                    customerinfo.Religion = .Rows(0)("RELIGION").ToString

                    customerinfo.Company = .Rows(0)("COMPANY").ToString

                    customerinfo.Occupation = .Rows(0)("OCCUPATION").ToString

                    If Not Convert.IsDBNull(.Rows(0)("NAME_SAKE")) Then

                        customerinfo.NameSake = EnumHelper.GetEnumValueFromDBValue(Of NameSake)(.Rows(0)("NAME_SAKE").ToString)

                    End If

                    customerinfo.CustomerCode = .Rows(0)("CUSTOMER_CODE").ToString

                End With

            End Using

            Return customerinfo

        End Function

        Public Shared Function GetCustomerAddressByCustomerID(ByVal customerID As String) As DataTable 'Customerinformation

            Dim query As String = "SELECT CONTACT_ID               " & _
                                  "     , CONTACT_TYPE             " & _
                                  "     , CONTACT_LOC              " & _
                                  "     , DETAILS                  " & _
                                  "     , ACTIVE                   " & _
                                  "     , CUST_ID                  " & _
                                  "     , PREFFERED                " & _
                                  "FROM AM_CUSTOMER_CONTACT        " & _
                                  "WHERE CUST_ID = :customerID     " & _
                                  "AND CONTACT_TYPE = 'ADDRESS'    " & _
                                  "ORDER BY CONTACT_ID ASC         "


            Using param As New OraParameter

                param.AddItem("customerID", customerID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

        Public Shared Function GetCustomerContactsByCustomerID(ByVal customerID As String) As DataTable

            Dim query As String = "SELECT CONTACT_ID               " & _
                                  "     , CONTACT_TYPE             " & _
                                  "     , CONTACT_LOC              " & _
                                  "     , DETAILS                  " & _
                                  "     , ACTIVE                   " & _
                                  "     , CUST_ID                  " & _
                                  "     , PREFFERED                " & _
                                  "FROM AM_CUSTOMER_CONTACT        " & _
                                  "WHERE CUST_ID = :customerID     " & _
                                  "AND CONTACT_TYPE <> 'ADDRESS'    " & _
                                  "ORDER BY CONTACT_ID ASC         "


            Using param As New OraParameter

                param.AddItem("customerID", customerID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

        Public Shared Function UpdatePersonalDetail(ByVal updateRecord As Customer) As String

            With updateRecord

                Dim query As String = "UPDATE CUSTOMERS                               " & _
                                      "SET CUST_SEX            = :CustSex             " & _
                                      "  , CUST_MARITAL_STATUS = :CustMaritalStatus   " & _
                                      "  , BIRTH_DATE          = :custBirthdate       " & _
                                      "  , CITIZENSHIP         = :CustCitizenship     " & _
                                      "  , RELIGION            = :CustReligion        " & _
                                      "  , COMPANY             = :CustCompany         " & _
                                      "  , OCCUPATION          = :CustOccupation      " & _
                                      "WHERE CUST_ID           = :customerID          "



                Using params As New OraParameter

                    params.AddParameter("customerID", .CustomerId, OracleDbType.Varchar2)
                    params.AddParameter("CustSex", EnumHelper.GetDBValue(.Gender), OracleDbType.Varchar2)
                    params.AddParameter("CustMaritalStatus", EnumHelper.GetDBValue(.MaritalStatus), OracleDbType.Varchar2)
                    params.AddParameter("custBirthdate", .Birthdate, OracleDbType.Date)
                    params.AddParameter("CustCitizenship", .Citizenship, OracleDbType.Varchar2)
                    params.AddParameter("CustReligion", .Religion, OracleDbType.Varchar2)
                    params.AddParameter("CustCompany", .Company, OracleDbType.Varchar2)
                    params.AddParameter("CustOccupation", .Occupation, OracleDbType.Varchar2)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

    End Class

End Namespace