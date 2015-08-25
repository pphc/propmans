Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common


Namespace CustomerAccounts

#Region "Public Enum"

    Public Enum ContactType
        <EnumDescription("CELLPHONE")> _
        <EnumDBValue("CELLPHONE")> _
        Cellphone
        <EnumDescription("EMAIL")> _
        <EnumDBValue("EMAIL")> _
        Email
        <EnumDescription("TELEPHONE")> _
        <EnumDBValue("TELEPHONE")> _
        Telephone

    End Enum

    Public Enum AddressContactLocation
        <EnumDescription("COMPANY")> _
        <EnumDBValue("COMPANY")> _
        Company
        <EnumDescription("PROVINCIAL")> _
        <EnumDBValue("PROVINCIAL")> _
        Provincial
        <EnumDescription("RESIDENTIAL")> _
       <EnumDBValue("RESIDENTIAL")> _
       Residential

    End Enum

    Public Enum ContactLocation
        <EnumDescription("COMPANY")> _
        <EnumDBValue("COMPANY")> _
        Company
        <EnumDescription("PERSONAL")> _
        <EnumDBValue("PERSONAL")> _
        Personal
        <EnumDescription("RESIDENTIAL")> _
       <EnumDBValue("RESIDENTIAL")> _
       Residential

    End Enum

    Public Enum NameSake

        <EnumDescription("- N/A -")> _
         <EnumDBValue("NA")> _
         NotAvailable
        <EnumDescription("JR")> _
        <EnumDBValue("JR")> _
        Jr
        <EnumDescription("SR")> _
        <EnumDBValue("SR")> _
        Sr
        <EnumDescription("II")> _
        <EnumDBValue("II")> _
        II
        <EnumDescription("III")> _
        <EnumDBValue("III")> _
        III
        <EnumDescription("IV")> _
        <EnumDBValue("IV")> _
        IV
        <EnumDescription("V")> _
        <EnumDBValue("V")> _
        V

    End Enum

    Public Enum CivilStatus

        <EnumDescription("- NOT AVAILABLE -")> _
        <EnumDBValue("NA")> _
        NotAvailable
        <EnumDescription("SINGLE")> _
        <EnumDBValue("SINGLE")> _
        [Single]
        <EnumDescription("MARRIED")> _
        <EnumDBValue("MARRIED")> _
        Married
        <EnumDescription("SEPARATED")> _
        <EnumDBValue("SEPARATED")> _
        Separated
        <EnumDescription("WIDOWED")> _
        <EnumDBValue("WIDOWED")> _
        Widowed
        <EnumDescription("DIVORCED")> _
        <EnumDBValue("DIVORCED")> _
        Divorced

    End Enum

    Public Enum GenderList

        <EnumDescription("- NOT AVAILABLE -")> _
        <EnumDBValue("NA")> _
        NotAvailable
        <EnumDescription("MALE")> _
        <EnumDBValue("M")> _
        Male
        <EnumDescription("FEMALE")> _
        <EnumDBValue("F")> _
        Female
    End Enum

    Public Enum Active

        <EnumDescription("Y")> _
        <EnumDBValue("Y")> _
        Yes
        <EnumDescription("N")> _
        <EnumDBValue("N")> _
        No
    End Enum

    Public Enum OwnerRelation

        <EnumDescription("- SELECT -")> _
        <EnumDBValue("SELECT")> _
        [Select]
        <EnumDescription("SPOUSE")> _
        <EnumDBValue("SPOUSE")> _
        Spouse
        <EnumDescription("CHILDREN")> _
        <EnumDBValue("CHILDREN")> _
        Children
        <EnumDescription("SIBLLING")> _
        <EnumDBValue("SIBLLING")> _
        Siblling
        <EnumDescription("RELATIVE")> _
        <EnumDBValue("RELATIVE")> _
        Relative
        <EnumDescription("HOUSE HELP")> _
        <EnumDBValue("HOUSE HELP")> _
        Househelp
        <EnumDescription("OTHER")> _
        <EnumDBValue("OTHER")> _
        Other


    End Enum

#End Region

End Namespace