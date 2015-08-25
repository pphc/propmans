Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common

Namespace UnitInventory

#Region "Public Enum"

    Public Enum PaymentSchemeList
        <EnumDescription("HDMF")> _
        <EnumDBValue("HDMF")> _
        HDMF
        <EnumDescription("CASH")> _
        <EnumDBValue("CASH")> _
        CASH
        <EnumDescription("IN HOUSE")> _
        <EnumDBValue("INH")> _
        INHOUSE
        <EnumDescription("BANK")> _
        <EnumDBValue("BANK")> _
        BANK
    End Enum


    Public Enum OccupancyStatuslist
        <EnumDescription("VACANT")> _
        <EnumDBValue("VAC")> _
        Vacant
        <EnumDescription("OCCUPIED")> _
        <EnumDBValue("OCC")> _
        Occupied
    End Enum

    Public Enum OccupantList
        <EnumDescription("OWNER")> _
        <EnumDBValue("OWNER")> _
        Owner
        <EnumDescription("RELATIVES")> _
        <EnumDBValue("RELATIVES")> _
        Relatives
        <EnumDescription("TENANT")> _
        <EnumDBValue("TENANT")> _
        Tenant
        '<EnumDescription("VACANT")> _
        '<EnumDBValue("VACANT")> _
        'Vacant
    End Enum

    Public Enum UnitSubClass
        <EnumDescription("- SELECT -")> _
        <EnumDBValue("S")> _
        [Select]
        <EnumDescription("RESIDENTIAL")> _
        <EnumDBValue("RES")> _
        Residential
        <EnumDescription("COMMERCIAL")> _
        <EnumDBValue("COMM")> _
        Commercial
        <EnumDescription("PARKING")> _
       <EnumDBValue("PARK")> _
        Parking
    End Enum

    Public Enum SaleStatusList
        <EnumDescription("- SELECT -")> _
        <EnumDBValue("S")> _
        [Select]
        <EnumDescription("RESERVED")> _
        <EnumDBValue("RESERVED")> _
        Reserved
        <EnumDescription("FOR SALE")> _
        <EnumDBValue("FOR SALE")> _
        ForSale
    End Enum

#End Region

#Region "Dynamic"

    Public Class PhaseListSource
        Inherits ListSource
        Public Sub New()
            Using dt As DataTable = Phase.GetPhase
                For Each dr As DataRow In dt.Rows
                    Me.AddItem(dr("PHASE_ID").ToString, dr("PHASE_NAME").ToString)
                Next

            End Using
        End Sub
    End Class

    Public Class BuildingListSource

        Inherits ListSource

        Public Sub New(ByVal phaseID As String)

            Using dt As DataTable = Building.GetBuildingByPhaseID(phaseID)
                For Each dr As DataRow In dt.Rows
                    Me.AddItem(dr("BLDG_ID").ToString, dr("BLDG_NAME").ToString)
                Next

            End Using

        End Sub

    End Class

    Public Class ClusterListSource

        Inherits ListSource

        Public Sub New(ByVal buildingID As String)

            Using dt As DataTable = Cluster.GetClusterByBuildingID(buildingID)
                For Each dr As DataRow In dt.Rows
                    Me.AddItem(dr("CLUSTER_ID").ToString, dr("CLUSTER_NAME".ToString))
                Next

            End Using

        End Sub

    End Class

    Public Class FloorListSource

        Inherits ListSource

        Public Sub New(ByVal clusterID As String)

            Using dt As DataTable = Floor.GetFloorByClusterID(clusterID)
                For Each dr As DataRow In dt.Rows
                    Me.AddItem(dr("FLOOR_ID").ToString, dr("FLOOR_NAME").ToString)
                Next

            End Using

        End Sub

    End Class

#End Region

End Namespace