Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Namespace UnitInventory

    Public Class Cluster

#Region "PROPERTIES"

        Private _clusterId As String

        Public Property ClusterId() As String
            Get
                Return _clusterId
            End Get
            Set(ByVal Value As String)
                _clusterId = Value
            End Set
        End Property

        Private _clusterName As String

        Public Property ClusterName() As String
            Get
                Return _clusterName
            End Get
            Set(ByVal Value As String)
                _clusterName = Value
            End Set
        End Property

        Private _clusterNumber As String

        Public Property ClusterNumber() As String
            Get
                Return _clusterNumber
            End Get
            Set(ByVal Value As String)
                _clusterNumber = Value
            End Set
        End Property

#End Region

        Public Shared Function GetClusterByBuildingID(ByVal buildingID As String) As DataTable

            Dim query As String = "SELECT CLUSTER_ID                           " & _
                                  "     , CLUSTER_NAME                         " & _
                                  "     , CLUSTER_NUMBER                       " & _
                                  "     , BLDG_ID                              " & _
                                  "FROM AM_CLUSTER                             " & _
                                  "WHERE BLDG_ID = :buildingID                 " & _
                                  "ORDER BY  TO_NUMBER(CLUSTER_NUMBER) ASC     "

            Using param As New OraParameter

                param.AddItem(":buildingID", buildingID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

    End Class

End Namespace