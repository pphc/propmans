
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports DALC
Imports BCL.Common

Public Class BillingStatementSource
    Public Const VATMultiplier As Decimal = 1.12
    Public Const VATRate As Decimal = 0.12

    Public Property BillID As String

    Public Property UnitNumber As String

    Public Property CustomerName As String
    Public Property RateClass As String
    Public Property BillDate As Date
    Public Property StatemenDate As Date
    Public Property DueDate As Date
    Public Property PreviousBalance As Decimal
    Public Property PreviousDiscount As Decimal
    Public Property PreviousPayment As Decimal
    Public ReadOnly Property RateClassDesc As String
        Get
            If RateClass.Equals("RES", StringComparison.InvariantCultureIgnoreCase) Then
                Return "RESIDENTIAL"
            Else
                Return "COMMERCIAL"
            End If
        End Get
    End Property

    Public ReadOnly Property PreviousStatementBalance As Decimal
        Get
            Return PreviousBalance - (PreviousDiscount + PreviousPayment)
        End Get
    End Property
 
    Public Property CurrentCharges As Decimal

    Public ReadOnly Property CurrentChargesExclusiveofVAT As Decimal
        Get
            Return CurrentCharges / VATMultiplier
        End Get
    End Property

    Public Property CurrentPenalty As Decimal

    Public ReadOnly Property CurrentPenaltyExclusiveofVAT As Decimal
        Get
            If CurrentPenalty > 0 Then
                Return CurrentPenalty / VATMultiplier
            Else
                Return CurrentPenalty
            End If
        End Get
    End Property

    Public Property CurrentDiscount As Decimal
    Public Property RemainingAdvance As Decimal

    Public ReadOnly Property CurrentSubtotal As Decimal
        Get
            Return (CurrentChargesExclusiveofVAT + CurrentPenaltyExclusiveofVAT) - CurrentDiscount - RemainingAdvance
        End Get
    End Property

    Public ReadOnly Property VATAmount As Decimal
        Get
            Return ((CurrentChargesExclusiveofVAT + CurrentPenaltyExclusiveofVAT) - CurrentDiscount) * VATRate
        End Get
    End Property

    Public ReadOnly Property TotalAmountDue As Decimal
        Get
            Dim previousBalance As Decimal = 0

            If PreviousStatementBalance > 0 Then
                previousBalance = PreviousStatementBalance
            End If

            Return previousBalance + CurrentSubtotal + VATAmount
        End Get
    End Property

    Public ReadOnly Property BillAmountDue As Decimal
        Get
            Dim due As Decimal = 0

            If TotalAmountDue > 0 Then
                due = TotalAmountDue
            End If

            Return due
        End Get
    End Property

End Class

Public Class LastPaymentInfo
    Public Property BillID As String
    Public Property PaymentDate As Date
    Public Property PaymentAmount As Decimal
    Public Property PaymentRef As String
    Private TotalPaymentAmount As Decimal = 0
    Private Sub New()

    End Sub
    Public Sub New(billid As String)
        Me.BillID = billid
        Dim query As String = "SELECT *                                                           " & _
                            "  FROM (SELECT payment_type, or_number, paid_amount, payment_date, " & _
                            "               DENSE_RANK () OVER (ORDER BY payment_date DESC) rn  " & _
                            "          FROM payments                                            " & _
                            "         WHERE or_status = 'ISSD'                                  " & _
                            "           AND pay_fee_type = (SELECT bill_fee_type                " & _
                            "                                 FROM billing_charges              " & _
                            "                                WHERE bill_id = :billid)           " & _
                            "           AND pay_acct_id = (SELECT bill_cust_id                  " & _
                            "                                FROM billing_charges               " & _
                            "                               WHERE bill_id = :billid)            " & _
                            "           AND payment_date < (SELECT bill_date                    " & _
                            "                                 FROM billing_charges              " & _
                            "                                WHERE bill_id = :billid))          " & _
                            " WHERE rn = 1                                                      "

        Using param As New OraParameter
            param.AddParameter("billid", billid)

            For Each dr As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                TotalPaymentAmount += Decimal.Parse(dr("paid_amount"))
                PaymentDate = Date.Parse(dr("payment_date"))
                PaymentRef = String.Format("{0}/", dr("or_number").ToString)
            Next
            If Not String.IsNullOrEmpty(PaymentRef) Then
                PaymentRef = PaymentRef.TrimEnd("/")
            End If

            PaymentAmount = TotalPaymentAmount
        End Using
    End Sub

End Class

Public MustInherit Class BillingStatement

    Private Const CustomerCopy As String = "Customer Copy"
    Private Const AdminCopy As String = "Admin Copy"
    Private Const PropertyManagement As String = "PHINMA PROPERTIES"

    Public Property ReportDoc() As ReportDocument

    Public ReadOnly Property ProjectName() As String
        Get
            Return GlobalReference.ProjectParameters.SiteName
        End Get

    End Property

    Public ReadOnly Property ProjectLocation() As String
        Get
            Return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(GlobalReference.ProjectParameters.SiteAddress.ToLower)
        End Get
    End Property

    Public ReadOnly Property UserFullName() As String
        Get
            Return GlobalReference.CurrentUser.UserFullName
        End Get
    End Property

    Public ReadOnly Property PropertyAdministrator() As String
        Get
            Return GlobalReference.ProjectParameters.SitePropertyAdmin
        End Get
    End Property

    Public ReadOnly Property OfficeLocation() As String
        Get
            Return GlobalReference.ProjectParameters.SiteOfficeLocation
        End Get
    End Property

    Public ReadOnly Property OfficeCOntact() As String
        Get
            Return GlobalReference.ProjectParameters.SiteContactNos
        End Get
    End Property

    Public Property FeeID As String

    Public MustOverride ReadOnly Property StatementHeader() As String

    Public MustOverride ReadOnly Property WaterMarkText() As String

    Public Sub New()

    End Sub

    Public Sub LoadReport()
        BindItems()
    End Sub

    Protected MustOverride Sub SetDatasource(ByRef reportdoc As ReportDocument)

    Protected Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & ProjectName & "'"
            .FormulaFields("ProjectLocation").Text = "'" & ProjectLocation & "'"
            .FormulaFields("PropertyManagedBy").Text = "'" & PropertyManagement & "'"

            .FormulaFields("BillingStatementName").Text = "'" & StatementHeader & "'"
            .FormulaFields("CustomerCopyName").Text = "'" & CustomerCopy & "'"
            .FormulaFields("AdminCopyName").Text = "'" & AdminCopy & "'"

            .FormulaFields("PreparedBy").Text = "'" & UserFullName & "'"
            .FormulaFields("NotedBy").Text = "'" & PropertyAdministrator & "'"

            .FormulaFields("ProjectOffice").Text = "'" & OfficeLocation & "'"
            .FormulaFields("ProjectContactNo").Text = "'" & OfficeCOntact & "'"
            .FormulaFields("CorporationName").Text = "'" & GetFeeCompanyDivision() & "'"

        End With

        SetDatasource(ReportDoc)

    End Sub

    Private Function GetFeeCompanyDivision() As String

        If GlobalReference.Fee.GetFeeInfobyFeeID(FeeID).FeeCompany = SiteDivision.CondoCorp Then
            Return GlobalReference.ProjectParameters.SiteLegalName
        Else
            Return GlobalReference.ProjectParameters.SiteDeveloperName
        End If
    End Function

End Class
