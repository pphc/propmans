Public Class UnitRentalBillingReport
    Inherits RecurringBillReportBase


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "UNIT RENTAL BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property StatementHeader() As String
        Get
            Return "UNIT RENTAL BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property WaterMarkText() As String
        Get
            Return "Unit Rental"
        End Get
    End Property
End Class
