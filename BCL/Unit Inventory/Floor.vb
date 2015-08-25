Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Namespace UnitInventory


    Public Class Floor

#Region "PROPERTIES"

        Private _floorId As String

        Public Property FloorId() As String
            Get
                Return _floorId
            End Get
            Set(ByVal Value As String)
                _floorId = Value
            End Set
        End Property

        Private _floorName As String

        Public Property FloorName() As String
            Get
                Return _floorName
            End Get
            Set(ByVal Value As String)
                _floorName = Value
            End Set
        End Property

        Private _floorNumber As String

        Public Property FloorNumber() As String
            Get
                Return _floorNumber
            End Get
            Set(ByVal Value As String)
                _floorNumber = Value
            End Set
        End Property

#End Region

        Public Shared Function GetFloorByClusterID(ByVal clusterID As String) As DataTable

            Dim query As String = "SELECT FLOOR_ID                            " & _
                                  "     , FLOOR_NAME                          " & _
                                  "     , FLOOR_NUMBER                        " & _
                                  "     , CLUSTER_ID                          " & _
                                  "FROM AM_FLOOR                              " & _
                                  "WHERE CLUSTER_ID = :clusterID              " & _
                                  "ORDER BY TO_NUMBER(FLOOR_NUMBER) ASC       "

            Using param As New OraParameter

                param.AddItem(":clusterID", clusterID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

    End Class
End Namespace