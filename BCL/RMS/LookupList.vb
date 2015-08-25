Imports BCL.Common


Namespace RMS

    Public Enum ContractStatus

        <EnumDisplayName("FOR APPROVAL")> _
        <EnumDBValue("FAP")> _
        ForApproval
        <EnumDisplayName("ACTIVE")> _
        <EnumDBValue("ACT")> _
        Active
        <EnumDisplayName("DISAPPROVED")> _
        <EnumDBValue("DIS")> _
        Disapproved
        <EnumDisplayName("VOID")> _
        <EnumDBValue("VOID")> _
        Void
        <EnumDisplayName("WITH AMENDMENT")> _
        <EnumDBValue("CHT")> _
        ChangeTerms
        <EnumDisplayName("EXPIRED")> _
        <EnumDBValue("EXP")> _
        Expired
        <EnumDisplayName("INACTIVE")> _
        <EnumDBValue("INACT")> _
        Inactive
    End Enum

    Public Enum LeaseType
        <EnumDisplayName("BARE")> _
        <EnumDBValue("BARE")> _
        Bare
        <EnumDisplayName("SEMI-FURNISHED")> _
        <EnumDBValue("SEMI-FURNISHED")> _
        SemiFurnished
        <EnumDisplayName("FURNISHED")> _
        <EnumDBValue("FURNISHED")> _
        Furnished
        <EnumDisplayName("DORM")> _
        <EnumDBValue("DORM")> _
        DormType
        <EnumDisplayName("PARKING")> _
        <EnumDBValue("PARKING")> _
        ParkingSlot
    End Enum

    Public Enum LeasePurpose
        <EnumDisplayName("RESIDENTIAL")> _
        <EnumDBValue("RES")> _
        Residential
        <EnumDisplayName("COMMERCIAL")> _
        <EnumDBValue("COMM")> _
        Commercial
    End Enum

    Public Enum RemitType
        <EnumDisplayName("ATM")> _
        <EnumDBValue("ATM")> _
        ATM
        <EnumDisplayName("CHECK")> _
        <EnumDBValue("CHECK")> _
        Check
    End Enum

    Public Enum ApprovalStatus
        <EnumDisplayName("PENDING")> _
        <EnumDBValue("PND")> _
        Pending
        <EnumDisplayName("APPROVED")> _
        <EnumDBValue("APP")> _
        Approved
        <EnumDisplayName("DISAPPROVED")> _
        <EnumDBValue("DPP")> _
        Disapproved
        '<DisplayName("VOID")> _
        '<DBValue("VOID")> _
        Void
    End Enum

    Public Enum AmendmentType
        <EnumDisplayName("NEW CONTRACT")> _
        <EnumDBValue("NEW")> _
        NewContract
        <EnumDisplayName("CHANGE OF RENTAL AMOUNT")> _
        <EnumDBValue("RCH")> _
        RentalAmount
        <EnumDisplayName("EXTENSION OF CONTRACT")> _
        <EnumDBValue("EXT")> _
        RentalExtension
        <EnumDisplayName("PRE-TERMINATION")> _
        <EnumDBValue("PTR")> _
        Preterminatation
    End Enum

    Public Enum RequesterType
        <EnumDisplayName("UNIT OWNER")> _
        <EnumDBValue("OWNER")> _
        UnitOwner
        <EnumDisplayName("TENANT")> _
        <EnumDBValue("TENANT")> _
        Tenant
    End Enum

    Public Enum RentalBillingType
        <EnumDisplayName("RENTAL BILLINGS")> _
        <EnumDBValue("RENT")> _
        Rentals
        <EnumDisplayName("DEPOSITS")> _
        <EnumDBValue("DEPOSIT")> _
        Deposits
    End Enum

End Namespace

