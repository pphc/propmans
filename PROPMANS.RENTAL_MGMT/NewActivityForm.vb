Imports ComponentFactory.Krypton.Toolkit
Imports BCL.RentalMgmt
Imports PROPMANS.BASE_MOD

Public Class NewActivityForm

    Private _activityID As String
    Public Property ActivityID() As String
        Get
            Return _activityID
        End Get
        Set(ByVal value As String)
            _activityID = value
        End Set
    End Property
    Private _agreementID As String
    Public Property AgreementID() As String
        Get
            Return _agreementID
        End Get
        Set(ByVal value As String)
            _agreementID = value
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
        Dim success As Boolean

        If String.IsNullOrEmpty(ActivityID) Then
            If MessageBox.Show("Save New Activity", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                success = SaveActivity()
            End If
        Else
            If MessageBox.Show("Update Activity", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                success = UpdateActivity()
            End If
        End If

        If success Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        Common.BindComboBoxtoList(cboActivityType, New ActivityType)

        If Not String.IsNullOrEmpty(ActivityID) Then
            DisplayActivityInformation()
        End If
    End Sub


    Private Sub DisplayActivityInformation()

        With RentalActivityDAL.GetActivityByID(ActivityID)
            dtpActivityDate.Value = .ActivityDate
            cboActivityType.SelectedValue = .ActivityTypeID
            txtNotes.Text = .ActivityNote.ToString
        End With

    End Sub

    Private Function SaveActivity() As Boolean

        Dim activity As New RentalActivity

        With activity
            .AgreementId = AgreementID
            .LeaseID = LeaseID
            .ActivityTypeID = cboActivityType.SelectedValue
            .ActivityDate = dtpActivityDate.Value.Date
            .ActivityNote = txtNotes.Text
        End With
        If Not String.IsNullOrEmpty(AgreementID) Then
            Return RentalActivityDAL.InsertRMActivity(activity) > 0
        Else
            Return RentalActivityDAL.InsertLeaseActivity(activity) > 0
        End If

    End Function

    Private Function UpdateActivity() As Boolean

        Dim activity As New RentalActivity

        With activity
            .ActivityId = ActivityID
            .ActivityDate = dtpActivityDate.Value.Date
            .ActivityTypeID = cboActivityType.SelectedValue
            .ActivityNote = txtNotes.Text
        End With

        Return RentalActivityDAL.UpdateActivity(activity) > 0
    End Function

#End Region

End Class
