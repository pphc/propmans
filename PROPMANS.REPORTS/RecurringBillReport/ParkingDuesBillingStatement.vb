Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BCL.Billings

Public Class ParkingDuesBillingStatement
    Inherits BillingStatement

    Private BillSource As New List(Of BillingStatementSource)
    Private LastPaymentInfo As New List(Of LastPaymentInfo)

    Public Sub New(bills As List(Of AccountBilling))

        For Each bill As AccountBilling In bills
            BillSource.Add(New BillingStatementSource With {
                                                      .BillID = bill.BillID,
                                                      .UnitNumber = bill.UnitNumber,
                                                      .CustomerName = bill.CustomerName,
                                                      .RateClass = bill.RateClass,
                                                      .BillDate = bill.BillDate,
                                                      .StatemenDate = bill.StatemenDate,
                                                      .DueDate = bill.DueDate,
                                                      .PreviousBalance = bill.PreviousBalance,
                                                      .PreviousDiscount = bill.PreviousDiscount,
                                                      .PreviousPayment = bill.PreviousPayment,
                                                      .CurrentCharges = bill.CurrentCharges,
                                                      .CurrentPenalty = bill.CurrentPenalty,
                                                      .CurrentDiscount = bill.CurrentDiscount,
                                                      .RemainingAdvance = bill.RemainingAdvance})

            LastPaymentInfo.Add(New LastPaymentInfo(bill.BillID))
        Next

        ReportDoc = New ParkingDuesBillingStatementReport
    End Sub

    Protected Overrides Sub SetDataSource(ByRef reportdoc As ReportDocument)
        reportdoc.Database.Tables(0).SetDataSource(BillSource)
        reportdoc.Database.Tables(1).SetDataSource(LastPaymentInfo)
    End Sub


    Public Overrides ReadOnly Property StatementHeader As String
        Get
            Return "PARKING DUES BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property WaterMarkText As String
        Get
            Return String.Empty
        End Get
    End Property
End Class
