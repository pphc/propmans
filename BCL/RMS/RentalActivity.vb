

Namespace RMS

    Public Class ActivityType
        Public Property ID As String
        Public Property ActivityName As String
        Public Property IsActive As Boolean
        Public Property IsSystemEvent As Boolean
    End Class

    Public Class RentalActivity
        Public Property ActivityId As String
        Public Property Type As ActivityType
        Public Property ActivityDate As Date
        Public Property Notes As String
        Public Property Agreement As RentalServiceAgreement

        Public Property CreatedBy As String
        Public Property CreatedOn As Date
        Public Property UpdatedBy As String
        Public Property UpdatedOn As Nullable(Of Date)
    End Class

End Namespace

