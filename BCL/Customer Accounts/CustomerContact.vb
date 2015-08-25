Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common

Namespace CustomerAccounts

    Public Class CustomerContact

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

        Private _contactId As String

        Public Property ContactId() As String
            Get
                Return _contactId
            End Get
            Set(ByVal Value As String)
                _contactId = Value
            End Set
        End Property

        Private _addressContactLoc As AddressContactLocation

        Public Property AddressContactLoc() As AddressContactLocation
            Get
                Return _addressContactLoc
            End Get
            Set(ByVal Value As AddressContactLocation)
                _addressContactLoc = Value
            End Set
        End Property

        Private _contactLoc As ContactLocation

        Public Property ContactLoc() As ContactLocation
            Get
                Return _contactLoc
            End Get
            Set(ByVal Value As ContactLocation)
                _contactLoc = Value
            End Set
        End Property
        Private _contactType As ContactType

        Public Property ContactType() As ContactType
            Get
                Return _contactType
            End Get
            Set(ByVal Value As ContactType)
                _contactType = Value
            End Set
        End Property

        Private _details As String

        Public Property Details() As String
            Get
                Return _details
            End Get
            Set(ByVal Value As String)
                _details = Value
            End Set
        End Property

        Private _active As Active

        Public Property Active() As Active
            Get
                Return _active
            End Get
            Set(ByVal Value As Active)
                _active = Value
            End Set
        End Property

        Public Property IsPreffered As Boolean


#End Region

        Public Shared Function UpdateContact(ByVal updateRecord As CustomerContact) As String

            With updateRecord

                Dim query As String = "UPDATE AM_CUSTOMER_CONTACT                " & _
                                       "SET CONTACT_TYPE     = :CustContactType  " & _
                                       "  , CONTACT_LOC      = :CustContactLoc   " & _
                                       "  , DETAILS          = :CustDetails      " & _
                                       "  , ACTIVE           = :custActive       " & _
                                       "WHERE CONTACT_ID       = :contactID      "

                Using params As New OraParameter

                    params.AddParameter("CustContactType", EnumHelper.GetDBValue(.ContactType), OracleDbType.Varchar2)
                    params.AddParameter("CustContactLoc", EnumHelper.GetDBValue(.ContactLoc), OracleDbType.Varchar2)
                    params.AddParameter("CustDetails", .Details, OracleDbType.Varchar2)
                    params.AddParameter("custActive", EnumHelper.GetDBValue(.Active), OracleDbType.Varchar2)
                    params.AddParameter("contactID", .ContactId, OracleDbType.Varchar2)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

        Public Shared Function MakeDefaultAddress(custid As String, contactID As String) As String

            Dim query As String = "update am_customer_contact         " & _
                                " set preffered = 'N'               " & _
                                " where contact_type ='ADDRESS' " & _
                                " And cust_id = :custid             " & _
                                " and active = 'Y'   AND contact_id <> :contactid              "
            Using params As New OraParameter
                params.AddParameter("custid", custid, OracleDbType.Int32)
                params.AddParameter("contactid", contactID, OracleDbType.Varchar2)
                Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using


        End Function


        Public Shared Function InsertContact(ByVal InsertRecord As CustomerContact) As String

            With InsertRecord


                Dim query As String = "INSERT INTO AM_CUSTOMER_CONTACT (CUST_ID ,CONTACT_TYPE ,CONTACT_LOC ,DETAILS ,ACTIVE,PREFFERED) " & _
                                      "VALUES (:customerID ,:CustContactType ,:CustContactLoc  ,:CustDetails ,:custActive,'N')       "

                Using params As New OraParameter

                    params.AddParameter("customerID", .CustomerId, OracleDbType.Varchar2)
                    params.AddParameter("CustContactType", EnumHelper.GetDBValue(.ContactType), OracleDbType.Varchar2)
                    params.AddParameter("CustContactLoc", EnumHelper.GetDBValue(.ContactLoc), OracleDbType.Varchar2)
                    params.AddParameter("CustDetails", .Details, OracleDbType.Varchar2)
                    params.AddParameter("custActive", EnumHelper.GetDBValue(.Active), OracleDbType.Varchar2)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

        Public Shared Function UpdateAddress(ByVal updateRecord As CustomerContact) As String

            With updateRecord

                Dim query As String = "UPDATE AM_CUSTOMER_CONTACT              " & _
                                      "SET CONTACT_LOC     = :CustContactLoc   " & _
                                      "  , DETAILS         = :CustDetails      " & _
                                      "  , ACTIVE          = :custActive       " & _
                                      "  , PREFFERED          = :preffered       " & _
                                      "WHERE CONTACT_ID      = :contactID      "

                Using params As New OraParameter

                    params.AddParameter("CustContactLoc", EnumHelper.GetDBValue(.ContactLoc), OracleDbType.Varchar2)
                    params.AddParameter("CustDetails", .Details, OracleDbType.Varchar2)
                    params.AddParameter("custActive", EnumHelper.GetDBValue(.Active), OracleDbType.Varchar2)
                    params.AddParameter("contactID", .ContactId, OracleDbType.Varchar2)
                    params.AddParameter("preffered", IIf(.IsPreffered, "Y", "N"))

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

        Public Shared Function InsertAddress(ByVal InsertRecord As CustomerContact) As String

            With InsertRecord

                Dim query As String = "INSERT INTO AM_CUSTOMER_CONTACT (CUST_ID ,CONTACT_LOC ,CONTACT_TYPE ,DETAILS ,ACTIVE,PREFFERED) " & _
                                      "VALUES (:customerID ,:CustContactLoc ,'ADDRESS' ,:CustDetails ,:custActive,:preffered)           "

                Using params As New OraParameter

                    params.AddParameter("customerID", .CustomerId, OracleDbType.Varchar2)
                    params.AddParameter("CustContactLoc", EnumHelper.GetDBValue(.ContactLoc), OracleDbType.Varchar2)
                    params.AddParameter("CustDetails", .Details, OracleDbType.Varchar2)
                    params.AddParameter("custActive", EnumHelper.GetDBValue(.Active), OracleDbType.Varchar2)
                    params.AddParameter("preffered", IIf(.IsPreffered, "Y", "N"))

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

    End Class

End Namespace