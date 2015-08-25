

Namespace RMS

   
    Public Class ContractAmendment

        Public Property ApprovalID As String
        Public Property Agreement As RentalServiceAgreement
        Public Property RequestDate As Date
        Public Property AmendmentRequestType As AmendmentType
        Public Property RequestingParty As RequesterType

        Public Property OldRate As Decimal
        Public Property OldEndDate As Nullable(Of Date)
        Public Property NewRate As Decimal
        Public Property NewEndDate As Nullable(Of Date)
        Public Property EffectiveDate As Nullable(Of Date)


        Public Property RequestNotes As String
        Public Property ApprovalNotes As String
        Public Property ApprovalStatus As ApprovalStatus

        Public Property CreatedBy As String
        Public Property CreatedOn As Date
        Public Property UpdatedBy As String
        Public Property UpdatedOn As Nullable(Of Date)

        Public ReadOnly Property AmendmentDetails As String
            Get
                If Me.AmendmentRequestType = AmendmentType.NewContract Then
                    Return String.Format("Contract Period from {0:MMM dd,yyyy} to {1:MMM dd,yyyy}", Agreement.ContractStartDate, Agreement.ContractEndDate)
                ElseIf Me.AmendmentRequestType = AmendmentType.RentalAmount Then
                    Return String.Format("Change Rental Amount from {0:c} to {1:c}", OldRate, NewRate)
                ElseIf Me.AmendmentRequestType = AmendmentType.RentalExtension Then
                    Return String.Format("Extend Contract from {0:MMM dd,yyyy} to {1:MMM dd,yyyy}", OldEndDate, NewEndDate)
                Else
                    Return String.Format("Pre-terminate contract on {0:MMM dd,yyyy}", EffectiveDate)
                End If
            End Get
        End Property

    End Class

End Namespace


