
Imports BCL.Common

Namespace RMS

    Public Class Billing

        Public Property BillID As String
        Public Property FeeName As String
        Public Property CoveredPeriod As String

        Public Property BillDate As Date
        Public Property BillStatementDate As Date
        Public Property BillDueDate As Date
        Public Property AmountDue As Decimal
        Public Property PenaltyAmount As Decimal
        Public ReadOnly Property TotalDue As Decimal
            Get
                Return AmountDue + PenaltyAmount
            End Get
        End Property
        Public Property AmountPaid As Decimal
        Public ReadOnly Property Balance As Decimal
            Get
                Return AmountDue + PenaltyAmount - AmountPaid
            End Get
        End Property

        Public Property CreatedBy As String
        Public Property CreatedOn As Date

    End Class

End Namespace

