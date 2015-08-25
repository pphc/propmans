Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class ReportStore
    Implements IDisposable

    Private rptTYpe As ReportBase
    Public Sub New()

    End Sub
    Public Sub LoadReport(ByVal reportType As ReportBase)
        rptTYpe = reportType
        If Not rptTYpe.InputNeeded Then
            rptTYpe.LoadReport()
        End If

        ShowReport()
    End Sub
    Public Shared Sub LoadBillingStatement(statementtype As BillingStatement)


    End Sub

    Private Sub ShowReport()

        If rptTYpe.InputNeeded Then
            Using frm As New ReportViewerForm(rptTYpe)
                frm.ShowDialog()
            End Using
        Else
            Using frm As New ReportViewerForm(rptTYpe.ReportDoc)
                frm.ShowDialog()
            End Using
        End If

    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                rptTYpe.Dispose()
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class



