Public Class ParkingRentalBillingReport
    Inherits RecurringBillReportBase


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "PARKING RENTAL BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property StatementHeader() As String
        Get
            Return "PARKING RENTAL BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property WaterMarkText() As String
        Get
            Return "Parking Rental"
        End Get
    End Property
End Class
