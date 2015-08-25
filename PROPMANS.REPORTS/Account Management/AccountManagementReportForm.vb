Imports ComponentFactory.Krypton.Toolkit
Imports BCL
Imports System.Windows.Forms
Imports BCL.Utils
Imports BCL.Payments
Imports BCL.Common
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports System.Data
Imports PROPMANS.BASE_MOD

Public Class AccountManagementReportForm

    Private _bloaded As Boolean ' = False

#Region "PROPERTIES"

   
    Private _reportType As ReportBase

#End Region

#Region "Form Instance"

    Private Shared aForm As AccountManagementReportForm

    Public Shared Function Instance() As AccountManagementReportForm

        If aForm Is Nothing Then
            aForm = New AccountManagementReportForm
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

    Private Sub TransactionAuditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UISetup()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            LoadReport()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ErrorToString)
        End Try
    End Sub
#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        Common.BindCheckListBoxtoList(chklistBox, New LoadBuildingNameSpace.LoadBuildingListSource)

    End Sub

#End Region

    Private Sub LoadReport()
        Try
            Dim Id As String

            Dim IdMerge As String

            For Each item As Object In chklistBox.CheckedItems


                Id = item.DisplayValue



                If chklistBox.CheckedItems.Count = 1 Then

                    IdMerge = Id

                Else

                    If IdMerge = String.Empty Then

                        IdMerge = "'" + Id + "'"

                    Else
                        IdMerge = IdMerge + "," + "'" + Id + "'"
                    End If


                End If
            Next

            Dim rep As New UnitInventoryReport(IdMerge)
            rep.LoadReport()
            Me.CrystalReportViewer.ReportSource = rep.ReportDoc

        Catch ex As Exception
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged

        If chkSelectAll.Checked = True Then
            For idx As Integer = 0 To Me.chklistBox.Items.Count - 1
                Me.chklistBox.SetItemCheckState(idx, CheckState.Checked)
            Next
        Else
            For idx As Integer = 0 To Me.chklistBox.Items.Count - 1
                Me.chklistBox.SetItemCheckState(idx, CheckState.Unchecked)
            Next
        End If

    End Sub

End Class
