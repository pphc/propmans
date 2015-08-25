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


Public Class NewORSeriesForm


#Region "Form and Controls Events"

    Private _division As CompanyDivision
    Public Sub New(ByVal division As CompanyDivision)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _division = division
    End Sub
    Private Sub NewORSeriesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If IsEntryValid() Then
            If SaveEntry() > 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
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

        AddHandler txtStartOR.KeyPress, AddressOf Common.Numeric_KeyPress
        AddHandler txtEndingOR.KeyPress, AddressOf Common.Numeric_KeyPress


        lblDivisionOR.Text = EnumHelper.GetDescription(_division) & " OR SERIES"
    End Sub

    Private Function IsEntryValid() As Boolean
        Dim valid As Boolean = True



        Return valid
    End Function

    Private Function SaveEntry() As Integer
        Return ORInventory.SaveSeries(txtStartOR.Text.Trim, _
                               txtEndingOR.Text.Trim, _
                               dtpDateReceived.Value.Date, _
                               _division, _
                               txtRemarks.Text.Trim)

    End Function
#End Region


End Class
