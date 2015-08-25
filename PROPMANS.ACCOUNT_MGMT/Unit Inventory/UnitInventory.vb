Imports ComponentFactory.Krypton.Toolkit
Imports BCL
Imports BCL.UnitInventory

Imports PROPMANS.BASE_MOD

Public Class UnitInventory

    Private _bloaded As Boolean ' = False

#Region "PROPERTIES"

    Private ReadOnly Property UnitID() As String
        Get
            Return UIGridView.CurrentRow.Cells("unit_id").Value.ToString
        End Get
    End Property

    Private _unitNumber As String
    Private ReadOnly Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
    End Property

    Private _unitDESCRIPTION As String
    Private ReadOnly Property UnitDescription() As String
        Get
            Return _unitDESCRIPTION
        End Get
    End Property

    Private _unitAREA As String
    Private ReadOnly Property UnitArea() As String
        Get
            Return _unitAREA
        End Get
    End Property

    Private _unitSUBCLASS As String
    Private ReadOnly Property UnitSubClass() As String
        Get
            Return _unitSUBCLASS
        End Get
    End Property

    Private _unitSALESTATUS As String
    Private ReadOnly Property UnitSaleStatus() As String
        Get
            Return _unitSALESTATUS
        End Get
    End Property

    Private _unitOCCUPANT As String
    Private ReadOnly Property UnitOccupant() As String
        Get
            Return _unitOCCUPANT
        End Get
    End Property

#End Region

#Region "Form Instance"

    Private Shared aForm As UnitInventory

    Public Shared Function Instance() As UnitInventory

        If aForm Is Nothing Then
            aForm = New UnitInventory

        End If
        Return aForm

    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        aForm = Nothing

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

#End Region

#Region "Form & Control Events"



    Private Sub ComboBoxPhase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPhase.SelectedIndexChanged

        If _bloaded Then
            _bloaded = False
            Common.BindComboBoxtoList(ComboBoxBuilding, New BuildingListSource(ComboBoxPhase.SelectedValue.ToString))
            _bloaded = True
            ComboBoxBuilding_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub ComboBoxBuilding_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxBuilding.SelectedIndexChanged

        If _bloaded Then
            _bloaded = False
            Common.BindComboBoxtoList(ComboBoxCluster, New ClusterListSource(ComboBoxBuilding.SelectedValue.ToString))
            _bloaded = True
            ComboBoxCluster_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub ComboBoxCluster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCluster.SelectedIndexChanged

        If _bloaded Then
            _bloaded = False
            Common.BindComboBoxtoList(ComboBoxFloor, New FloorListSource(ComboBoxCluster.SelectedValue.ToString))
            _bloaded = True
            ComboBoxFloor_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub ComboBoxFloor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFloor.SelectedIndexChanged

        If _bloaded Then
            UIGridView.DataSource = Unit.GetUnitsByFloorID(ComboBoxFloor.SelectedValue.ToString)
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim result = MessageBox.Show("Update Unit Occupancy Status?", "UPDATE CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            UpdateUnitInventory()
            MessageBox.Show("Successfully Update", "UPDATE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        ComboBoxFloor_SelectedIndexChanged(Nothing, Nothing)

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        GridHelper.SetGridDisplay(UIGridView, New InventoryListGridDisplay)

        Common.BindComboBoxtoList(ComboBoxPhase, New PhaseListSource)
        Common.BindComboBoxtoList(ComboBoxOccupancyStatus, GetType(OccupancyStatuslist))
        Common.BindComboBoxtoList(ComboBoxOccupant, GetType(OccupantList))
        _bloaded = True
        ComboBoxPhase_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub UIGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UIGridView.SelectionChanged

        If UIGridView.RowCount > 0 Then

            lblUnitNumber.Text = UIGridView.CurrentRow.Cells(1).Value.ToString
            lblUnitType.Text = UIGridView.CurrentRow.Cells(2).Value.ToString
            lblUnitSQMArea.Text = UIGridView.CurrentRow.Cells(3).Value.ToString


            If UIGridView.CurrentRow.Cells(5).Value.ToString = String.Empty Then

                lblUnitOwner.Text = "NOT AVAILABLE"
                btnUpdate.Enabled = False
            Else

                lblUnitOwner.Text = UIGridView.CurrentRow.Cells(5).Value.ToString
                btnUpdate.Enabled = True
            End If

            DisplayUnitDetails()
        Else

        End If

    End Sub

    Private Sub DisplayUnitDetails()

        With Unit.GetUnitsByUnitID(UnitID)

            If .RfoDate.HasValue Then
                RfoDate.Value = .RfoDate.Value.ToString("MMMM dd, yyyy")
            Else
                RfoDate.Checked = False
            End If

            If .OccupancyDate.HasValue Then
                OccupancyDate.Value = .OccupancyDate.Value.ToString("MMMM dd, yyyy")
            Else
                OccupancyDate.Checked = False
            End If

            ComboBoxOccupancyStatus.SelectedValue = .OccupancyStatus
            ComboBoxOccupant.SelectedValue = .Occupant


            lblUnitClass.Text = .SubClass.ToString.ToUpper

            lblSaleStatus.Text = .SaleStatus.ToString.ToUpper

        End With

    End Sub

    Private Sub UpdateUnitInventory()

        Dim updateRecord As New Unit

        With updateRecord

            .UnitId = Me.UnitID
            If RfoDate.Checked Then
                .RfoDate = RfoDate.Value
            End If

            If OccupancyDate.Checked Then
                .OccupancyDate = OccupancyDate.Value
            End If

            .OccupancyStatus = ComboBoxOccupancyStatus.SelectedValue

            .Occupant = ComboBoxOccupant.SelectedValue

        End With

        Unit.UpdateUnitInventory(updateRecord)

    End Sub

#End Region

End Class
