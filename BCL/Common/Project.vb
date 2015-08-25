Imports DALC
Namespace Common

    Public Class Project

        Private _projCode As String
        Public ReadOnly Property ProjCode() As String
            Get
                Return _projCode
            End Get
        End Property

        Private _schemaOwner As String
        Public ReadOnly Property SchemaOwner() As String
            Get
                Return _schemaOwner
            End Get
        End Property

        Private _projID As String
        Public ReadOnly Property ProjID() As String
            Get
                Return _projID
            End Get
        End Property

        Private _projName As String
        Public ReadOnly Property ProjName() As String
            Get
                Return _projName
            End Get
        End Property

        Private _projAddress As String
        Public ReadOnly Property ProjAddress() As String
            Get
                Return _projAddress
            End Get
        End Property

        Private _propertyAdminName As String
        Public ReadOnly Property PropertyAdminName() As String
            Get
                Return _propertyAdminName
            End Get
        End Property

        Private _projContactNumber As String
        Public ReadOnly Property ProjContactNumber() As String
            Get
                Return _projContactNumber
            End Get
        End Property

        Private _projOfficeLocation As String
        Public ReadOnly Property ProjOfficeLocation() As String
            Get
                Return _projOfficeLocation
            End Get
        End Property

        Private _userFullName As String
        Public ReadOnly Property UserFullName() As String
            Get
                Return _userFullName
            End Get
        End Property

        Public Sub New()
            Dim query As String = "SELECT proj_code, proj_name, proj_address, proj_administrator," & _
                            "       proj_contact_nos, proj_office_location                 " & _
                            "  FROM projects "

            With OraDBHelper2.GetResultSet(query)
                Dim projid As String() = .Rows(0)("proj_code").ToString.Split(CChar(","))
                _projCode = projid(0)
                _projID = projid(1)
                _projName = .Rows(0)("proj_name").ToString
                _projAddress = .Rows(0)("proj_address").ToString
                _propertyAdminName = .Rows(0)("proj_administrator").ToString
                _projContactNumber = .Rows(0)("proj_contact_nos").ToString
                _projOfficeLocation = .Rows(0)("proj_office_location").ToString
            End With

            'Using params As New OraParameter
            '    params.AddItem("userid", GlobalReference.CurrentUser.UserID)
            '    _userFullName = OraDBHelper2.SqlExecuteScalar(SelectStatement.GetUserInfo, params.GetParameterCollection)
            'End Using

            'Try
            '    Using params As New OraParameter
            '        params.AddItem("paramname", "SCHEMA_OWNER")
            '        _schemaOwner = OraDBHelper2.SqlExecuteScalar(SelectStatement.GetParamValue, params.GetParameterCollection).ToString
            '    End Using
            'Catch ex As Exception

            'End Try

        End Sub

    End Class


End Namespace

