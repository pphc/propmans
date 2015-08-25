Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Namespace UnitInventory


    Public Class Building

#Region "PROPERTIES"

        Private _bldgId As String

        Public Property BldgId() As String
            Get
                Return _bldgId
            End Get
            Set(ByVal Value As String)
                _bldgId = Value
            End Set
        End Property

        Private _bldgName As String

        Public Property BldgName() As String
            Get
                Return _bldgName
            End Get
            Set(ByVal Value As String)
                _bldgName = Value
            End Set
        End Property

        Private _bldgNumber As String

        Public Property BldgNumber() As String
            Get
                Return _bldgNumber
            End Get
            Set(ByVal Value As String)
                _bldgNumber = Value
            End Set
        End Property

        Private _bldgTypeId As String

        Public Property BldgTypeId() As String
            Get
                Return _bldgTypeId
            End Get
            Set(ByVal Value As String)
                _bldgTypeId = Value
            End Set
        End Property

        '/---------AM_Building_Type---------/

        Private _bldgTypeDesc As String

        Public Property BldgTypeDesc() As String
            Get
                Return _bldgTypeDesc
            End Get
            Set(ByVal Value As String)
                _bldgTypeDesc = Value
            End Set
        End Property

#End Region

        Public Shared Function GetBuildingByPhaseID(ByVal phaseID As String) As DataTable

            Dim query As String = "SELECT a.BLDG_ID                        " & _
                                  "     , a.BLDG_NAME                      " & _
                                  "     , a.BLDG_NUMBER                    " & _
                                  "     , a.BLDG_TYPE_ID                   " & _
                                  "     , a.PHASE_ID                       " & _
                                  "     , b.BLDG_TYPE_DESC                 " & _
                                  "FROM AM_BUILDING a, AM_BUILDING_TYPE b  " & _
                                  "WHERE a.BLDG_TYPE_ID = b.BLDG_TYPE_ID   " & _
                                  "AND a.PHASE_ID = :phaseID               " & _
                                  "ORDER BY TO_NUMBER(BLDG_NUMBER) ASC     "

            Using param As New OraParameter

                param.AddItem("phaseID", phaseID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

    End Class

End Namespace