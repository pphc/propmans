Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class DisplayReceipts

    Public Property Payments As List(Of Payment)
    Public Sub New(pay As List(Of Payment))
        Me.Payments = pay
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private indx As Integer
    Public ReadOnly Property SelectedReceiptIdx As Integer
        Get
            Return indx
        End Get
    End Property



#Region "Form & Control Events"
    Private Sub ReceiptsLookupForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgReceipts.DataSource = Payments
    End Sub


    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If IsEntryValid() Then

    '        Dim success As Boolean
    '        If String.IsNullOrEmpty(VehicleID) Then
    '            If MessageBox.Show("Save New Vehicle", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
    '                success = SaveVehicle()
    '            End If
    '        Else
    '            If MessageBox.Show("Update Vehicle", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
    '                success = UpdateVehicle()
    '            End If
    '        End If

    '        If success Then
    '            Me.DialogResult = Windows.Forms.DialogResult.OK
    '            Me.Close()
    '        End If
    '    End If

    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.indx = dgReceipts.CurrentRow.Index
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

End Class
