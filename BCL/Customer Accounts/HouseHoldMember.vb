Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common

Namespace CustomerAccounts

    Public Class HouseHoldMember

#Region "PROPERTIES"

        Private _accountId As String

        Public Property AccountId() As String
            Get
                Return _accountId
            End Get
            Set(ByVal Value As String)
                _accountId = Value
            End Set
        End Property

        Private _memberId As String

        Public Property MemberId() As String
            Get
                Return _memberId
            End Get
            Set(ByVal Value As String)
                _memberId = Value
            End Set
        End Property

        Private _houseHoldName As String

        Public Property HouseHoldName() As String
            Get
                Return _houseHoldName
            End Get
            Set(ByVal Value As String)
                _houseHoldName = Value
            End Set
        End Property

        Private _birthDate As Nullable(Of Date)

        Public Property BirthDate() As Nullable(Of Date)
            Get
                Return _birthDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _birthDate = Value
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

        Private _ownerRelation As OwnerRelation

        Public Property OwnerRelation() As OwnerRelation
            Get
                Return _ownerRelation
            End Get
            Set(ByVal Value As OwnerRelation)
                _ownerRelation = Value
            End Set
        End Property

        Private _accountClass As String

        Public Property AccountClass() As String
            Get
                Return _accountClass
            End Get
            Set(ByVal Value As String)
                _accountClass = Value
            End Set
        End Property

        Private _moveInDate As Nullable(Of Date)

        Public Property MoveInDate() As Nullable(Of Date)
            Get
                Return _moveInDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _moveInDate = Value
            End Set
        End Property
        Private _moveOutDate As Nullable(Of Date)

        Public Property MoveOutDate() As Nullable(Of Date)
            Get
                Return _moveOutDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _moveOutDate = Value
            End Set
        End Property

#End Region

        Public Shared Function InsertHouseHoldMember(ByVal InsertRecord As HouseHoldMember) As String

            With InsertRecord


                Dim query As String = "INSERT INTO AM_HOUSEHOLD_MEMBER (HOUSEHOLD_NAME ,BIRTH_DATE ,OCCUPATION ,OWNER_RELATION ,ACCOUNT_ID,MOVE_IN_DATE,MOVE_OUT_DATE) " & _
                                      "VALUES (:houseHoldName ,:birthDate ,:occupation  ,:ownerRelation ,:accountId,:moveinDate,:moveoutDate)                      "

                Using params As New OraParameter

                    params.AddParameter("houseHoldName", .HouseHoldName, OracleDbType.Varchar2)
                    params.AddParameter("birthDate", .BirthDate, OracleDbType.Date)
                    params.AddParameter("occupation", .Occupation, OracleDbType.Varchar2)
                    params.AddParameter("ownerRelation", EnumHelper.GetDBValue(.OwnerRelation), OracleDbType.Varchar2)
                    params.AddParameter("accountId", .AccountId, OracleDbType.Varchar2)
                    params.AddParameter("moveinDate", .MoveInDate, OracleDbType.Date)
                    params.AddParameter("moveoutDate", .MoveOutDate, OracleDbType.Date)
                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

        Public Shared Function UpdateHouseHoldMember(ByVal UpdateRecord As HouseHoldMember) As String

            With UpdateRecord

                Dim query As String = "UPDATE AM_HOUSEHOLD_MEMBER                 " & _
                                      "SET HOUSEHOLD_NAME     = :houseHoldName    " & _
                                      "    , BIRTH_DATE         = :birthDate      " & _
                                      "    , OCCUPATION         = :occupation     " & _
                                      "    , OWNER_RELATION     = :ownerRelation  " & _
                                      "    , MOVE_IN_DATE         = :moveinDate     " & _
                                      "    , MOVE_OUT_DATE     = :moveoutDate  " & _
                                      "WHERE MEMBER_ID          = :memberId       "



                Using params As New OraParameter

                    params.AddParameter("memberId", .MemberId, OracleDbType.Varchar2)
                    params.AddParameter("houseHoldName", .HouseHoldName, OracleDbType.Varchar2)
                    params.AddParameter("birthDate", .BirthDate, OracleDbType.Date)
                    params.AddParameter("occupation", .Occupation, OracleDbType.Varchar2)
                    params.AddParameter("ownerRelation", EnumHelper.GetDBValue(.OwnerRelation), OracleDbType.Varchar2)
                    params.AddParameter("moveinDate", .MoveInDate, OracleDbType.Date)
                    params.AddParameter("moveoutDate", .MoveOutDate, OracleDbType.Date)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

    End Class

End Namespace