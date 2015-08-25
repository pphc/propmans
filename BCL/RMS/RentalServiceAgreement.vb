
Imports BCL.Common

Namespace RMS


    Public Interface IRentalServiceAgreement
        Property ID As String
        ReadOnly Property ContractNo() As String
        Property AgreementDate As Date
        Property ContractStartDate As Date
        Property ContractEndDate As Date
        ReadOnly Property ContractPeriod As String
        Property LeaseType As LeaseType
        Property MonthsTerm As Integer
        Property RentAmount As Decimal
        Property PrepaidRent As Decimal
        Property SecurityDeposit As Decimal
        Property CashBond As Decimal
        ReadOnly Property TotalDeposit As Decimal
        Property ContractStatus As ContractStatus
        Property CreatedBy As String
        Property CreatedOn As Date
        Property UpdatedBy As String
        Property UpdatedOn As Nullable(Of Date)
    End Interface

    Public MustInherit Class RentalServiceAgreement
        Implements IRentalServiceAgreement

        Public Property ID As String Implements IRentalServiceAgreement.ID
        Public ReadOnly Property ContractNo As String Implements IRentalServiceAgreement.ContractNo
            Get
                Return GlobalReference.ProjectParameters.SiteCode & "-" & ID.PadLeft(6, "0")
            End Get
        End Property

        Public Property AgreementDate As Date Implements IRentalServiceAgreement.AgreementDate
        Public Property MonthsTerm As Integer Implements IRentalServiceAgreement.MonthsTerm
        Public Property ContractStartDate As Date Implements IRentalServiceAgreement.ContractStartDate
        Public Property ContractEndDate As Date Implements IRentalServiceAgreement.ContractEndDate

        Private _contractStatus As ContractStatus
        Public Property ContractStatus As ContractStatus Implements IRentalServiceAgreement.ContractStatus
            Get
                If _contractStatus = RMS.ContractStatus.Active And Me.ContractEndDate <= Date.Today Then
                    Return RMS.ContractStatus.Expired
                Else
                    Return _contractStatus
                End If
            End Get
            Set(value As ContractStatus)
                _contractStatus = value
            End Set
        End Property

        Public Property LeaseType As LeaseType Implements IRentalServiceAgreement.LeaseType
        Public Property PrepaidRent As Decimal Implements IRentalServiceAgreement.PrepaidRent
        Public Property SecurityDeposit As Decimal Implements IRentalServiceAgreement.SecurityDeposit
        Public ReadOnly Property TotalDeposit As Decimal Implements IRentalServiceAgreement.TotalDeposit
            Get
                Return SecurityDeposit + CashBond
            End Get
        End Property
        Public Property RentAmount As Decimal Implements IRentalServiceAgreement.RentAmount
        Public Property CashBond As Decimal Implements IRentalServiceAgreement.CashBond

        Public Property CreatedBy As String Implements IRentalServiceAgreement.CreatedBy
        Public Property CreatedOn As Date Implements IRentalServiceAgreement.CreatedOn
        Public Property UpdatedBy As String Implements IRentalServiceAgreement.UpdatedBy
        Public Property UpdatedOn As Date? Implements IRentalServiceAgreement.UpdatedOn


        Public ReadOnly Property ContractPeriod As String Implements IRentalServiceAgreement.ContractPeriod
            Get
                Return String.Format("{0:MMM dd,yyyy} to {1:MMM dd,yyyy}", ContractStartDate, ContractEndDate)
            End Get
        End Property

        Public MustOverride ReadOnly Property UnitNumber As String
        Public MustOverride ReadOnly Property CustomerName As String
    End Class

    Public Class RentalAgreement
        Inherits RentalServiceAgreement

        Public Property OwnerAccount As Accounts.CustomerAccount
        Public Property RemitType As RemitType
        Public Property MaxOccupant As Integer
        Public Property MgmtRate As Decimal
        Public Property Available As Integer

        Public Overrides ReadOnly Property CustomerName As String
            Get
                Return Me.OwnerAccount.Owner.FullNameLastNameFirst
            End Get
        End Property

        Public Overrides ReadOnly Property UnitNumber As String
            Get
                Return Me.OwnerAccount.UnitNumber
            End Get
        End Property
    End Class

    Public Class LeaseAgreement
        Inherits RentalServiceAgreement

        Public Property Tenant As Accounts.Customer
        Public Property RentalAgreement As RentalAgreement
        Public Property LeasePurpose As LeasePurpose

        Public Overrides ReadOnly Property CustomerName As String
            Get
                Return Me.Tenant.FullNameLastNameFirst
            End Get
        End Property

        Public Overrides ReadOnly Property UnitNumber As String
            Get
                Return Me.RentalAgreement.OwnerAccount.UnitNumber
            End Get
        End Property
    End Class


End Namespace
