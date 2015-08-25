'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 05-30-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports DALC
Imports Oracle.DataAccess.Client
Imports BCL.Utils
Imports BCL.Common


Namespace Utils


    Public NotInheritable Class UserAccess

        Private Shared _err As String
        Public Shared ReadOnly Property Err() As String
            Get
                Return _err
            End Get
        End Property

        Private Shared _errNumber As String
        Public Shared ReadOnly Property ErrNumber() As Integer
            Get
                Return _errNumber
            End Get
        End Property

        Public Shared Function ChangeExpiredPassword(password As String) As Boolean
            Dim bSuccesfull As Boolean = False
            Try
                OraConnection.Instance.OracleConnection.OpenWithNewPassword(password)
                bSuccesfull = True
                OraConnection.Release()
            Catch ex As Exception
                _err = ex.Message
            End Try

            Return bSuccesfull

        End Function

        Public Shared Function IsUserValid(ByVal user As SystemUser) As Boolean
            Dim bvalid As Boolean = False

            Try
                OraConnection.InitializeInstance(user.UserID, user.UserPassword)

                OraConnection.Instance.OracleConnection.Open()

                OraDBHelper2.SetCurrentWorkingSchema()
                '' AddHandler OraConnection.Instance.OracleConnection.Failover, AddressOf OraConnection.OnFailOver
                bvalid = True
            Catch ex As ArgumentNullException
                _err = "Enter value for username and password"
            Catch ex As OracleException
                _errNumber = ex.Number
                Select Case ex.Number
                    Case 1017
                        _err = "Invalid Login Details"
                    Case 28001
                        _err = "The password has expired"
                    Case Else
                        _err = ex.Message

                End Select
            Catch ex As Exception
                _err = ex.Message
            End Try

            Return bvalid
        End Function

        Public Shared Sub LogOff()
            OraConnection.Release()
        End Sub

        Public Shared Function GetUsers(ByVal userID As String) As DataTable

            Dim query As String = "SELECT user_id,user_fullname,user_position,active,company,user_group" & _
                                "  FROM user_info                                            " & _
                                "    where user_id <> upper(:currentuser)                    " & _
                                "  order by 1                                                "


            Using params As New OraParameter

                params.AddParameter("currentuser", userID)

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetModuleAccess(ByVal userID As String) As DataTable


            Dim query As String = "SELECT DISTINCT SUBSTR (granted_role, 5,LENGTH (granted_role)-6) module_name, " & _
                                    "       SUBSTR (granted_role, LENGTH (granted_role)) access_type               " & _
                                    "  FROM user_role_privs                                                        " & _
                                    " WHERE username = :currentuser AND granted_role LIKE 'PMS%'                      "

            Using params As New OraParameter
                params.AddParameter("currentuser", userID)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Sub UpdateModuleAccess(ByVal moduleid As String(), ByVal accesstype As String(), ByVal userid As String)

            Using params As New OraParameter
                params.AddParameter("moduleid", moduleid, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("accesstype", accesstype, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("userid", userid, OracleDbType.Varchar2, ParameterDirection.Input)
                OraDBHelper2.ExecuteProcedureforInput("PROPMANS.proc_updateuseraccess", params.GetParameterCollection)
            End Using
        End Sub

        Public Shared Sub SaveNewUser(ByVal user As SystemUser)
            With user
                Using params As New OraParameter
                    params.AddParameter("userid", .UserID, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("userfullname", .UserFullName, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("userpos", .UserPosition, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("activeaccount", IIf(.IsActive, "Y", "N"), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("usercompany", EnumHelper.GetDBValue(.CompanyAccess), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("usergroup", EnumHelper.GetDBValue(.UserGroup), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("pass", .UserPassword, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("schemaowner", BCL.Common.GlobalReference.ProjectParameters.MainSchema, OracleDbType.Varchar2, ParameterDirection.Input)

                    OraDBHelper2.ExecuteProcedureforInput("PROPMANS.createuser", params.GetParameterCollection)
                End Using
            End With
        End Sub

        Public Shared Sub UpdateUserInfo(ByVal user As SystemUser)
            With user
                Using params As New OraParameter
                    params.AddParameter("userid", .UserID, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("pass", .UserPassword, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("userfullname", .UserFullName, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("userpos", .UserPosition, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("activeaccount", IIf(.IsActive, "Y", "N"), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("usercompany", EnumHelper.GetDBValue(.CompanyAccess), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("usergroup", EnumHelper.GetDBValue(.UserGroup), OracleDbType.Varchar2, ParameterDirection.Input)

                    OraDBHelper2.ExecuteProcedureforInput("PROPMANS.updateuser", params.GetParameterCollection)
                End Using
            End With
        End Sub

        ''' <
        ' ''' summary>
        ' ''' Gets the fee access.	
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetFeeAccess() As SiteDivision
        '    Dim query As String = "SELECT company           " & _
        '            "  FROM user_info         " & _
        '            " WHERE user_id = :userid "

        '    Using params As New OraParameter
        '        params.AddParameter("userid", BCL.Common.GlobalReference.CurrentUser.UserID)
        '        Return EnumHelper.GetEnumValueFromDBValue(Of Common.SiteDivision)(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection).ToString())
        '    End Using

        'End Function

        ''' <summary>
        ''' Gets the userGroupType.	
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public Shared Function GetUserGroupType() As UserGroupType
        '    Dim query As String = "SELECT user_group           " & _
        '            "  FROM user_info         " & _
        '            " WHERE user_id = :userid "

        '    Using params As New OraParameter
        '        params.AddParameter("userid", GlobalReference.CurrentUser.UserID)
        '        Return EnumHelper.GetEnumValueFromDBValue(Of UserGroupType)(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection).ToString())
        '    End Using

        'End Function
    End Class

End Namespace


