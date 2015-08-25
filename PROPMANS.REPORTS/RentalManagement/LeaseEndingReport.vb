Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine


Public Class LeaseEndingReport

    Inherits ReportBase

    Public Overrides Sub BindItems()

    End Sub

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "LEASE ENDING"
        End Get
    End Property
End Class
