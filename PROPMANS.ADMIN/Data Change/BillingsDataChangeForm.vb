'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 04-26-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************


Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL.Billings

Public Class BillingsDataChangeForm

#Region "Properties"
    Private FeeTypeLoaded As Boolean ' = False
    Private AccountID As String
    Private LeaseID As String
#End Region

#Region "Form Instance"
    Private Shared aForm As BillingsDataChangeForm
    Public Shared Function Instance() As BillingsDataChangeForm
        If aForm Is Nothing Then
            aForm = New BillingsDataChangeForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Forms and Controls Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Using frm As AccountLookupForm = New AccountLookupForm
            frm.ShowDialog()

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                lblUnitOwner.Text = String.Format("{0} - {1}", frm.UnitNumber, frm.CustomerFullName)
                lblCustomerType.Text = frm.CustomerType
                AccountID = frm.AccountID
                LeaseID = frm.LeaseID
                LoadUnpaidBillings()
            Else
                lblUnitOwner.Text = String.Empty
                AccountID = String.Empty
            End If
        End Using
    End Sub

    Private Sub cboFeeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeeType.SelectedIndexChanged
        If FeeTypeLoaded Then
            If cboFeeType.SelectedValue.ToString = "-1" Then

                If Not dgBillings.DataSource Is Nothing Then
                    DirectCast(dgBillings.DataSource, DataTable).Rows.Clear()
                End If

                pnlActions.Enabled = False
                lblUnpaidBillingPrompt.Visible = True


            Else
                dgBillings.DataSource = Billing.GetUnpaidBillingsByFeeType(cboFeeType.SelectedValue.ToString, _
                                            Me.AccountID, LeaseID)

                If dgBillings.Rows.Count = 0 Then
                    lblUnpaidBillingPrompt.Visible = True
                Else
                    lblUnpaidBillingPrompt.Visible = False
                End If
                pnlActions.Enabled = False
            End If
        End If
    End Sub

    Private Sub dgBillings_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBillings.CellValueChanged
        LoadAvailableActions()
    End Sub

    Private Sub dgBillings_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBillings.CurrentCellDirtyStateChanged
        If dgBillings.IsCurrentCellDirty Then
            dgBillings.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgBillings_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgBillings.CellFormatting
        With dgBillings.Columns(e.ColumnIndex)
            If .Name = "bill_status" Then
                If e.Value = "U" Then
                    e.Value = "UNPAID"
                Else
                    e.Value = "HOLD"
                End If
            End If
        End With
    End Sub

    Private Sub btnDoAcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoAction.Click
        '        Dim feetypeidx As Integer = cboFeeType.SelectedIndex ' COMMENTED BY CODEIT.RIGHT
        If MessageBox.Show("Proceed with selected action", cboActions.Text & " SELECTED BILLINGS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            SaveChanges()
            cboFeeType_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgBillings, New BillingsDataChangeGridDisplay)

        lblUnpaidBillingPrompt.Visible = False
        pnlActions.Enabled = False

    End Sub

    Private Sub LoadUnpaidBillings()
        FeeTypeLoaded = False

        If String.IsNullOrEmpty(LeaseID) Then
            Common.BindComboBoxtoList(cboFeeType, New UnpaidFeeTypes(Me.AccountID, GlobalReference.CurrentUser.CompanyAccess))
        Else
            Common.BindComboBoxtoList(cboFeeType, New UnpaidFeeTypes(Me.AccountID, Me.LeaseID, GlobalReference.CurrentUser.CompanyAccess))
        End If


        FeeTypeLoaded = True


        cboFeeType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub LoadAvailableActions()
        If dgBillings.Rows.Count = 0 Then
            Return
        End If

        Dim hasUnpaid As Boolean
        Dim hasHold As Boolean
        Dim noSelection As Boolean = True
        For Each dr As DataGridViewRow In dgBillings.Rows
            If dr.Cells(0).Value = "True" Then
                If dr.Cells("bill_status").Value.ToString = "U" Then
                    hasUnpaid = True
                Else
                    hasHold = True
                End If
                noSelection = False
            End If
        Next
        cboActions.Items.Clear()

        If noSelection Then
            pnlActions.Enabled = False
            Return
        Else
            pnlActions.Enabled = True
        End If

        If hasUnpaid And hasHold Then
            cboActions.Items.AddRange(New String() {"CANCEL"})
            cboActions.SelectedIndex = 0
        Else
            If hasUnpaid Then
                cboActions.Items.AddRange(New String() {"CANCEL", "HOLD"})
                cboActions.SelectedIndex = 0
            Else
                cboActions.Items.Add("UNHOLD")
                cboActions.SelectedIndex = 0
            End If
        End If


    End Sub

    Private Function SaveChanges() As Boolean
        Dim billID As String() = GetSelectedBillings()
        Dim status As BillingStatus
        Select Case cboActions.Text
            Case "CANCEL"
                status = BillingStatus.Cancelled
            Case "HOLD"
                status = BillingStatus.Hold
            Case "UNHOLD"
                status = BillingStatus.Unpaid
        End Select

        Billing.UpdateBillStatus(billID, status)

    End Function

    Private Function GetSelectedBillings() As String()
        Dim bills As New ArrayList
        For Each row As DataGridViewRow In dgBillings.Rows
            If row.Cells(0).Value = "True" Then
                bills.Add(row.Cells(1).Value.ToString)
            End If
        Next

        Return DirectCast(bills.ToArray(GetType(String)), String())
    End Function

#End Region



End Class
