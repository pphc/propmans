Imports BCL.Utils
Imports DALC
Imports Oracle.DataAccess.Client
Namespace Common

    Public Enum ModuleAccessType
        <EnumDescription("VIEW ONLY")> _
        <EnumDBValue("V")> _
        VIEWONLY
        <EnumDescription("FULL ACCESS")> _
        <EnumDBValue("F")> _
        FULLACCESS
    End Enum

    Public Enum UserGroupType
        <EnumDescription("NORMAL USER")> _
        <EnumDBValue("USER")> _
        USER
        <EnumDescription("ADMINISTRATOR")> _
        <EnumDBValue("ADMIN")> _
        ADMINISTARTOR
    End Enum

    Public Class SystemUser
        Public Property UserID As String
        Public Property UserPassword As String
        Public Property UserFullName As String
        Public Property UserPosition As String
        Public Property IsActive As Boolean
        Public Property UserGroup As UserGroupType
        Public Property CompanyAccess As SiteDivision
        Private _moduleAccess As New Dictionary(Of String, ModuleAccessType)
        Public ReadOnly Property ModuleAccess As Dictionary(Of String, ModuleAccessType)
            Get
                Return _moduleAccess
            End Get
        End Property

        Public Sub New()

        End Sub

        Public Sub New(userID As String)
            Me.UserID = userID
            GetUserInfo()
            GetModuleAccess()
        End Sub
        Private Sub GetUserInfo()
            Dim query As String = "SELECT user_id, user_fullname, user_position, active, user_group, " & _
                                "        company                                      " & _
                                "  FROM user_info                                                  " & _
                                " WHERE user_id = :userid                                          "

            Using params As New OraParameter
                params.AddParameter("userid", UserID)
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    UserFullName = .Rows(0)("user_fullname").ToString
                    UserPosition = .Rows(0)("user_position").ToString
                    IsActive = CBool(IIf(.Rows(0)("user_position").ToString = "Y", True, False))
                    UserGroup = EnumHelper.GetEnumValueFromDBValue(Of UserGroupType)(.Rows(0)("user_group").ToString)
                    CompanyAccess = EnumHelper.GetEnumValueFromDBValue(Of SiteDivision)(.Rows(0)("company").ToString)
                End With

            End Using
        End Sub


        Private Sub GetModuleAccess()
            Dim query As String = "SELECT DISTINCT SUBSTR (granted_role, 5,LENGTH (granted_role)-6) module_name, " & _
                                    "       SUBSTR (granted_role, LENGTH (granted_role)) access_type               " & _
                                    "  FROM user_role_privs                                                        " & _
                                    " WHERE username = :currentuser AND granted_role LIKE 'PMS%'                      " & _
                                    " ORDER BY 2 "


            Using params As New OraParameter
                params.AddParameter("currentuser", UserID)
                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, params.GetParameterCollection).Rows
                    Dim modName As String = rw("module_name").ToString
                    Dim modAccess As ModuleAccessType = EnumHelper.GetEnumValueFromDBValue(Of ModuleAccessType)(rw("access_type").ToString)
                    If Not _moduleAccess.ContainsKey(modName) Then
                        _moduleAccess.Add(rw("module_name").ToString, modAccess)
                    End If
                Next

            End Using
        End Sub
    End Class

End Namespace


