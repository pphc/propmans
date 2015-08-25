
Namespace Accounts

    Public Class UnitInventory


        Public Property UnitID As String
        Public Property UnitNumber As String

        Public Property UnitArea As Decimal
        Public Property UnitType As String


        Public Property OwnerAccount As CustomerAccount

        Friend Property PhaseNo As String
        Friend Property BldgNo As String
        Friend Property ClusterNo As String
        Friend Property FloorNo As String
        Friend Property UnitNo As String

        Public ReadOnly Property UnitSort As String
            Get
                Return String.Format("{0}-{1}-{2}-{3}-{4}", PhaseNo.PadLeft(2, "0"), BldgNo.PadLeft(2, "0"), ClusterNo.PadLeft(2, "0"), FloorNo.PadLeft(2, "0"), UnitNo.PadLeft(3, "0"))
            End Get
        End Property


    End Class




End Namespace

