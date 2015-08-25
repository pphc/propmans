Imports System.Data
Imports DALC
Imports AmountInWords
Imports CrystalDecisions.CrystalReports.Engine


Public Class ContractOfLeaseReport
    Inherits ReportBase


#Region "PROPERTIES"

    Private _unitNumber As String

    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(ByVal Value As String)
            _unitNumber = Value
        End Set
    End Property

    Private _leaseName As String

    Public Property LeaseName() As String
        Get
            Return _leaseName
        End Get
        Set(ByVal Value As String)
            _leaseName = Value
        End Set
    End Property

    Private _leaseeAddress As String

    Public Property LeaseeAddress() As String
        Get
            Return _leaseeAddress
        End Get
        Set(ByVal Value As String)
            _leaseeAddress = Value
        End Set
    End Property



    Private _contractNumber As String

    Public Property ContractNumber() As String
        Get
            Return _contractNumber
        End Get
        Set(ByVal Value As String)
            _contractNumber = Value
        End Set
    End Property
    Public Property AppicationDate As Date

    Private _contractStart As Date
    Public Property ContractStart() As Date
        Get
            Return _contractStart
        End Get
        Set(ByVal value As Date)
            _contractStart = value
        End Set
    End Property


    Private _contractEnd As Date
    Public Property ContractEnd() As Date
        Get
            Return _contractEnd
        End Get
        Set(ByVal value As Date)
            _contractEnd = value
        End Set
    End Property


    Private _numberOfMonths As String

    Public Property NumberOfMonths() As String
        Get
            Return _numberOfMonths
        End Get
        Set(ByVal value As String)
            _numberOfMonths = value
        End Set
    End Property

    Private _leesePurpose As String

    Public Property LeasePurpose() As String
        Get
            Return _leesePurpose
        End Get
        Set(ByVal value As String)
            _leesePurpose = value
        End Set
    End Property

    Private _maxOccupants As String

    Public Property MaxOccupants() As String
        Get
            Return _maxOccupants
        End Get
        Set(ByVal Value As String)
            _maxOccupants = Value
        End Set
    End Property

    Private _cashBond As String

    Public Property CashBond() As String
        Get
            Return _cashBond
        End Get
        Set(ByVal Value As String)
            _cashBond = Value
        End Set
    End Property

    Private _rentAmount As Decimal

    Public Property RentAmount() As Decimal
        Get
            Return _rentAmount
        End Get
        Set(ByVal Value As Decimal)
            _rentAmount = Value
        End Set
    End Property

    Private _advanceAmount As Decimal

    Public Property AdvanceAmount() As Decimal
        Get
            Return _advanceAmount
        End Get
        Set(ByVal Value As Decimal)
            _advanceAmount = Value
        End Set
    End Property

    Private _totalAmount As Decimal



    Public ReadOnly Property TotalAmount() As Decimal
        Get
            Return AdvanceAmount + SecurityDeposit + CashBond
        End Get
    End Property

    Private _securityDeposit As Decimal

    Public Property SecurityDeposit() As Decimal
        Get
            Return _securityDeposit
        End Get
        Set(ByVal Value As Decimal)
            _securityDeposit = Value
        End Set
    End Property

    Private _leaseId As String
    Public Sub New(ByVal LeaseId As String)
        _leaseId = LeaseId
    End Sub

#End Region


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CONTRACT OF LEASE"
        End Get
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()
        ReportDoc = New rptContractOfLeaseForm
        Dim ConvertWord As New AmountInWords.AmountInWords
        Dim strRentAmount As String
        Dim StrAdvanceAmount As String
        Dim StrSecurityDeposit As String
        Dim StrTotalAmount As String

        strRentAmount = ConvertWord.GetInWords(RentAmount)
        StrAdvanceAmount = ConvertWord.GetInWords(AdvanceAmount)
        StrSecurityDeposit = ConvertWord.GetInWords(SecurityDeposit)
        StrTotalAmount = ConvertWord.GetInWords(TotalAmount)

        strRentAmount = strRentAmount.Substring(0, strRentAmount.LastIndexOf(" And")).ToString()
        StrAdvanceAmount = StrAdvanceAmount.Substring(0, StrAdvanceAmount.LastIndexOf(" And")).ToString()
        StrSecurityDeposit = StrSecurityDeposit.Substring(0, StrSecurityDeposit.LastIndexOf(" And")).ToString()
        StrTotalAmount = StrTotalAmount.Substring(0, StrTotalAmount.LastIndexOf(" And")).ToString()


        With ReportDoc.DataDefinition


            Dim blank As String = "__________________________________________________________________"


            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"

            .FormulaFields("ContractNumber").Text = "'" & ContractNumber & "'"

            .FormulaFields("UnitNumber").Text = "'" & UnitNumber & "'"

            .FormulaFields("LesseeName").Text = "'" & LeaseName & "'"

            If String.IsNullOrEmpty(LeaseeAddress) Then
                .FormulaFields("LesseeAddress").Text = "'" & blank & "'"
            Else
                .FormulaFields("LesseeAddress").Text = "'" & LeaseeAddress & "'"
            End If

            .FormulaFields("LeasePurpose").Text = "'" & LeasePurpose & "'"

            .FormulaFields("Term").Text = "'" & NumberOfMonths & "'"

            .FormulaFields("MaxOccupant").Text = "'" & MaxOccupants & "'"
            .FormulaFields("ApplicationDate").Text = "'" & AppicationDate.ToString("MMMM d, yyyy") & "'"
            .FormulaFields("ContractStart").Text = "'" & ContractStart.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("ContractEnd").Text = "'" & ContractEnd.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("RentAmount").Text = "'" & RentAmount.ToString("#,###.00") & "'"

            .FormulaFields("RentAmountInWord").Text = "'" & strRentAmount & "'"

            .FormulaFields("AdvanceAmount").Text = "'" & AdvanceAmount.ToString("#,###.00") & "'"

            .FormulaFields("AdvanceAmountInWord").Text = "'" & StrAdvanceAmount & "'"

            .FormulaFields("SecurityDeposit").Text = "'" & SecurityDeposit.ToString("#,###.00") & "'"

            .FormulaFields("SecurityDepositInWord").Text = "'" & StrSecurityDeposit & "'"

            .FormulaFields("TotalAmount").Text = "'" & TotalAmount.ToString("#,###.00") & "'"

            .FormulaFields("TotalAmountInWord").Text = "'" & StrTotalAmount & "'"
            If CashBond = 0 Then
                .FormulaFields("CashBond1").Text = " "

                .FormulaFields("CashBond2").Text = "'.'"
            Else
                .FormulaFields("CashBond1").Text = "'" & ", as well as Php " + CashBond + " as cash bond" & "'"

                .FormulaFields("CashBond2").Text = "'" & ", as well as Php " + CashBond + " as cash bond" & "'"
            End If






        End With

    End Sub

    Public Sub LoadData()


        ''fetch record by id

        Using params As New OraParameter
            params.AddItem("leaseId", _leaseId, Oracle.DataAccess.Client.OracleDbType.Int32)

            Dim query As String = "SELECT lease_id,                                                               " & _
                                   "(SELECT DETAILS " & _
                                  "FROM AM_CUSTOMER_CONTACT " & _
                                  " where cust_id = lc.cust_id " & _
                                  " and contact_type = 'ADDRESS' " & _
                                  " AND preffered ='Y') ADDRESS," & _
                                "       (SELECT parameter_value || '-' || LPAD (lease_id, 6, '0')               " & _
                                "          FROM project_parameter                                               " & _
                                "         WHERE parameter_name = 'SITE_CODE') contract_no,                      " & _
                                "       (SELECT cust_unit_no                                                    " & _
                                "          FROM customer_accounts                                               " & _
                                "         WHERE account_id =                                                    " & _
                                "                          (SELECT account_id                                   " & _
                                "                             FROM rm_agreement                                 " & _
                                "                            WHERE agreement_id = lc.agreement_id))             " & _
                                "                                                                  unit_number, " & _
                                "       accounts.getcustomerfullname_fml (cust_id) lessee_name, months_term,    " & _
                                "       (SELECT max_occupants                                                   " & _
                                "          FROM rm_agreement                                                    " & _
                                "         WHERE agreement_id = lc.agreement_id) max_occupants,application_date,lease_purpose, contract_start,  " & _
                                "       contract_end, rent_amt, prepaid_rent, security_deposit, cash_bond        " & _
                                "  FROM rm_lease_contract lc                                                    " & _
                                " WHERE lease_id = :leaseid                                                     "

            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

                LeaseeAddress = .Rows(0)("ADDRESS").ToString
                ContractNumber = .Rows(0)("CONTRACT_NO").ToString

                UnitNumber = .Rows(0)("UNIT_NUMBER").ToString

                LeaseName = .Rows(0)("LESSEE_NAME").ToString

                NumberOfMonths = .Rows(0)("MONTHS_TERM").ToString

                MaxOccupants = .Rows(0)("MAX_OCCUPANTS").ToString

                AppicationDate = Date.Parse(.Rows(0)("APPLICATION_DATE"))
                ContractStart = Date.Parse(.Rows(0)("CONTRACT_START"))

                ContractEnd = Date.Parse(.Rows(0)("CONTRACT_END"))

                RentAmount = .Rows(0)("RENT_AMT").ToString

                AdvanceAmount = .Rows(0)("PREPAID_RENT").ToString

                SecurityDeposit = .Rows(0)("SECURITY_DEPOSIT").ToString

                CashBond = .Rows(0)("CASH_BOND").ToString

                If .Rows(0)("LEASE_PURPOSE").ToString = "RES" Then
                    LeasePurpose = "RESIDENTIAL"
                Else
                    LeasePurpose = "COMMERCIAL"
                End If

            End With

        End Using
    End Sub


End Class
