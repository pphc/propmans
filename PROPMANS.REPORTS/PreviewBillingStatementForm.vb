'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Reports Viewewr
'Module Description: Previews Reports
'Date Created: 3/2/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BCL.Utils

Public Class PreviewBillingStatementForm

    Private rep As ReportDocument

#Region "Form and Control Events"

    Public Sub New(ByVal report As ReportDocument)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rep = report
    End Sub


    Private Sub BillingsPreviewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CrystalReportViewer.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message & "-" & ex.StackTrace, "CANNOT VIEW REPORT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub CrystalReportViewer_Error(source As Object, e As CrystalDecisions.Windows.Forms.ExceptionEventArgs) Handles CrystalReportViewer.Error
        e.Handled = False
    End Sub

#End Region
End Class
