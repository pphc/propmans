Imports ComponentFactory.Krypton.Toolkit
Imports BCL.RentalMgmt
Imports PROPMANS.BASE_MOD

Public Class NewVehicleForm

    Private _vehicleID As String
    Public Property VehicleID() As String
        Get
            Return _vehicleID
        End Get
        Set(ByVal value As String)
            _vehicleID = value
        End Set
    End Property

    Private _leaseID As String
    Public Property LeaseID() As String
        Get
            Return _leaseID
        End Get
        Set(ByVal value As String)
            _leaseID = value
        End Set
    End Property

#Region "Form & Control Events"

    Private Sub NewContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UISetup()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If IsEntryValid() Then

            Dim success As Boolean
            If String.IsNullOrEmpty(VehicleID) Then
                If MessageBox.Show("Save New Vehicle", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    success = SaveVehicle()
                End If
            Else
                If MessageBox.Show("Update Vehicle", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    success = UpdateVehicle()
                End If
            End If

            If success Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        If Not String.IsNullOrEmpty(VehicleID) Then
            DisplayVehicleInformation()
        Else
            chkActive.Visible = False
        End If
    End Sub


    Private Sub DisplayVehicleInformation()

        With VehicleDAL.GetVehicleByID(VehicleID)
            txtPlateNumber.Text = .PlateNumber
            txtMake.Text = .Make
            txtModel.Text = .Model
            txtColor.Text = .Color
            chkActive.Checked = .Active
        End With

    End Sub

    Private Function SaveVehicle() As Boolean

        Dim vh As New Vehicle

        With vh
            .LeaseID = Me.LeaseID
            .PlateNumber = txtPlateNumber.Text.Trim
            .Make = txtMake.Text.Trim
            .Model = txtModel.Text.Trim
            .Color = txtColor.Text.Trim
        End With
        Return VehicleDAL.InsertVehicle(vh) > 0

    End Function

    Private Function UpdateVehicle() As Boolean

        Dim vh As New Vehicle

        With vh
            .ID = Me.VehicleID
            .PlateNumber = txtPlateNumber.Text.Trim
            .Make = txtMake.Text.Trim
            .Model = txtModel.Text.Trim
            .Color = txtColor.Text.Trim
            .Active = chkActive.Checked
        End With

        Return VehicleDAL.UpdateVehicle(vh) > 0
    End Function

    Private Function IsEntryValid() As Boolean
        Dim bValid As Boolean = True

        ErrorProvider1.Clear()
 
        If Not Common.HasValue(txtPlateNumber) Then
            ErrorProvider1.SetError(txtPlateNumber, "Enter value for Plate Number")
            bValid = False
        Else
            ErrorProvider1.SetError(txtPlateNumber, "")
        End If

        If Not Common.HasValue(txtColor) Then
            ErrorProvider1.SetError(txtColor, "Enter value for Car Color")
            bValid = False
        Else
            ErrorProvider1.SetError(txtColor, "")
        End If

        If Not Common.HasValue(txtModel) Then
            ErrorProvider1.SetError(txtModel, "Enter value for Car Model")
            bValid = False
        Else
            ErrorProvider1.SetError(txtModel, "")
        End If


        Return bValid

    End Function

#End Region


End Class
