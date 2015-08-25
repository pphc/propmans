'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 06-16-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 06-16-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports BCL.Utils

Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class OrinventoryForm

#Region "Form Instance"
    Private Shared aForm As OrinventoryForm
    Public Shared Function Instance() As OrinventoryForm
        If aForm Is Nothing Then
            aForm = New OrinventoryForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Controls Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

    Private Sub cboCompanyDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyDivision.SelectedIndexChanged
        DisplayORSeriesByCompany()
    End Sub

    Private Sub btnNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewBatch.Click
        Using frm As New NewORSeriesForm(cboCompanyDivision.SelectedValue)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("OR Series Saved", "SAVED")
                DisplayORSeriesByCompany()
            End If
        End Using
    End Sub

#End Region

#Region "Local Procedures"
    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgORSeries, New ORInventoryGridDisplay)

        cboCompanyDivision.DisplayMember = "Value"
        cboCompanyDivision.ValueMember = "Key"
        cboCompanyDivision.DataSource = EnumHelper.ToEnumValueList(GetType(CompanyDivision))

    End Sub

    Private Sub DisplayORSeriesByCompany()

        dgORSeries.DataSource = ORInventory.GetInventoryByDivision(cboCompanyDivision.SelectedValue)

    End Sub



#End Region

End Class
