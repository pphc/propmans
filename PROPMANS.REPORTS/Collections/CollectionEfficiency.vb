Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class CollectionEfficiency
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "COLLECTION EFFICIENCY"
        End Get
    End Property


    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property



    Private _startDate As Date
    Public Property StartDAte() As Date
        Get
            Return _startDate
        End Get
        Set(ByVal value As Date)
            _startDate = value
        End Set
    End Property

    Private _endDate As Date
    Public Property EndDate() As Date
        Get
            Return _endDate
        End Get
        Set(ByVal value As Date)
            _endDate = value
        End Set
    End Property

    Private _billingDate As Date
    Public Property BillingDate() As Date
        Get
            Return _billingDate
        End Get
        Set(ByVal value As Date)
            _billingDate = value
        End Set
    End Property


    Private _feeName As String
    Public Property FeeName() As String
        Get
            Return _feeName
        End Get
        Set(ByVal value As String)
            _feeName = value
        End Set
    End Property

    Private _feeID As String
    Public Property FeeID() As String
        Get
            Return _feeID
        End Get
        Set(ByVal value As String)
            _feeID = value
        End Set
    End Property

    Private _currentPrincipal As Decimal
    Public Property CurrentPrincipal() As Decimal
        Get
            Return _currentPrincipal
        End Get
        Private Set(ByVal value As Decimal)
            _currentPrincipal = value
        End Set
    End Property

    Private _currentPenalty As Decimal
    Public Property CurrentPenalty() As Decimal
        Get
            Return _currentPenalty
        End Get
        Private Set(ByVal value As Decimal)
            _currentPenalty = value
        End Set
    End Property

    Private _advances As Decimal
    Public Property Advances() As Decimal
        Get
            Return _advances
        End Get
        Private Set(ByVal value As Decimal)
            _advances = value
        End Set
    End Property

    Private _creditMemoPrincipal As Decimal
    Public Property CreditMemoPrincipal() As Decimal
        Get
            Return _creditMemoPrincipal
        End Get
        Set(ByVal value As Decimal)
            _creditMemoPrincipal = value
        End Set
    End Property

    Private _creditMemoPenalty As Decimal
    Public Property CreditMemoPenalty() As Decimal
        Get
            Return _creditMemoPenalty
        End Get
        Set(ByVal value As Decimal)
            _creditMemoPenalty = value
        End Set
    End Property


    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()

        Using params As New OraParameter
            params.AddItem("feetype", FeeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("billdate", BillingDate, Oracle.DataAccess.Client.OracleDbType.Date)
            Dim query As String = "SELECT SUM (amount_due) currentprincipal, SUM (penalty_amt) currentpenalty," & _
                        "       COUNT (bill_id) billcount                                           " & _
                        "  FROM billing_charges bc                                                  " & _
                        " WHERE bill_fee_type = :feetype AND bill_status <> 'C'                     " & _
                        "       AND bill_date = :billdate                                           "

            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                CurrentPrincipal = Decimal.Parse(.Rows(0)("currentprincipal"))
                CurrentPenalty = Decimal.Parse(.Rows(0)("currentpenalty"))
            End With

        End Using

        Using params As New OraParameter
            params.AddItem("feetype", FeeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("billdate", BillingDate, Oracle.DataAccess.Client.OracleDbType.Date)
            Dim query As String = "SELECT NVL (SUM (applied_amt), 0) principal " & _
                        "  FROM pay_transactions                     " & _
                        " WHERE payment_id IN (                      " & _
                        "          SELECT payment_id                 " & _
                        "            FROM payments                   " & _
                        "           WHERE pay_category = 'ADV'       " & _
                        "             AND or_status = 'ISSD'         " & _
                        "             AND pay_fee_type = :feetype)   " & _
                        "   AND bill_id IN (                         " & _
                        "          SELECT bill_id                    " & _
                        "            FROM billing_charges            " & _
                        "           WHERE bill_fee_type = :feetype   " & _
                        "             AND bill_date = :billdate      " & _
                        "             AND bill_status <> 'C')        "
            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                Advances = Decimal.Parse(.Rows(0)("principal"))
            End With
        End Using


        Using params As New OraParameter
            params.AddItem("feetype", FeeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("billdate", BillingDate, Oracle.DataAccess.Client.OracleDbType.Date)
            Dim query As String = "SELECT NVL(SUM (applied_amt),0) principal, NVL( SUM (penalty_amt),0) penalty" & _
                        "  FROM pay_transactions                                      " & _
                        " WHERE payment_id IN (                                       " & _
                        "          SELECT payment_id                                  " & _
                        "            FROM payments                                    " & _
                        "           WHERE pay_category = 'REG'                        " & _
                        "             AND payment_type = 'CM'                         " & _
                        "             AND or_status = 'ISSD'                          " & _
                        "             AND pay_fee_type = :feetype)                    " & _
                        "   AND bill_id IN (                                          " & _
                        "          SELECT bill_id                                     " & _
                        "            FROM billing_charges                             " & _
                        "           WHERE bill_fee_type = :feetype                    " & _
                        "             AND bill_date = :billdate                       " & _
                        "             AND bill_status <> 'C')                         "
            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                CreditMemoPrincipal = Decimal.Parse(.Rows(0)("principal"))
                CreditMemoPenalty = Decimal.Parse(.Rows(0)("penalty"))
            End With

        End Using


        Using params As New OraParameter
            params.AddItem("feetype", FeeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("billdate", BillingDate, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("startdate", StartDAte, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("enddate", EndDate, Oracle.DataAccess.Client.OracleDbType.Date)
            Dim query As String = "SELECT   (SELECT cust_unit_no                                                  " & _
                        "            FROM customer_accounts                                             " & _
                        "           WHERE account_id = pv.pay_acct_id) unit_no,                         " & _
                        "         accounts.getcustomerfullname_fml ((SELECT acct_cust_id                             " & _
                        "                                 FROM customer_accounts                        " & _
                        "                                WHERE account_id = pv.pay_acct_id)             " & _
                        "                             ) customer_name,                                  " & _
                        "         currentprincipal, currentpenalty,                       " & _
                        "         previousprincipal, previouspenalty                      " & _
                        "    FROM (SELECT   pay_acct_id,                                                " & _
                        "                   SUM                                                         " & _
                        "                      (NVL ((SELECT applied_amt                                " & _
                        "                               FROM pay_transactions                           " & _
                        "                              WHERE payment_id = ps.payment_id                 " & _
                        "                                AND bill_id =                                  " & _
                        "                                       (SELECT bill_id                         " & _
                        "                                          FROM billing_charges                 " & _
                        "                                         WHERE bill_fee_type = ps.pay_fee_type " & _
                        "                                           AND bill_status <> 'C'              " & _
                        "                                           AND bill_date = :billdate           " & _
                        "                                           AND bill_cust_id = ps.pay_acct_id))," & _
                        "                            0                                                  " & _
                        "                           )                                                   " & _
                        "                      ) currentprincipal,                               " & _
                        "                   SUM                                                         " & _
                        "                      (NVL ((SELECT penalty_amt                                " & _
                        "                               FROM pay_transactions                           " & _
                        "                              WHERE payment_id = ps.payment_id                 " & _
                        "                                AND bill_id =                                  " & _
                        "                                       (SELECT bill_id                         " & _
                        "                                          FROM billing_charges                 " & _
                        "                                         WHERE bill_fee_type = ps.pay_fee_type " & _
                        "                                           AND bill_status <> 'C'              " & _
                        "                                           AND bill_date = :billdate           " & _
                        "                                           AND bill_cust_id = ps.pay_acct_id))," & _
                        "                            0                                                  " & _
                        "                           )                                                   " & _
                        "                      ) currentpenalty,                                 " & _
                        "                   SUM                                                         " & _
                        "                      (NVL ((SELECT SUM (applied_amt)                          " & _
                        "                               FROM pay_transactions                           " & _
                        "                              WHERE payment_id = ps.payment_id                 " & _
                        "                                AND bill_id <>                                 " & _
                        "                                       (SELECT bill_id                         " & _
                        "                                          FROM billing_charges                 " & _
                        "                                         WHERE bill_fee_type = ps.pay_fee_type " & _
                        "                                           AND bill_status <> 'C'              " & _
                        "                                           AND bill_date = :billdate           " & _
                        "                                           AND bill_cust_id = ps.pay_acct_id))," & _
                        "                            0                                                  " & _
                        "                           )                                                   " & _
                        "                      ) previousprincipal,                              " & _
                        "                   SUM                                                         " & _
                        "                      (NVL ((SELECT SUM (penalty_amt)                          " & _
                        "                               FROM pay_transactions                           " & _
                        "                              WHERE payment_id = ps.payment_id                 " & _
                        "                                AND bill_id <>                                 " & _
                        "                                       (SELECT bill_id                         " & _
                        "                                          FROM billing_charges                 " & _
                        "                                         WHERE bill_fee_type = ps.pay_fee_type " & _
                        "                                           AND bill_status <> 'C'              " & _
                        "                                           AND bill_date = :billdate           " & _
                        "                                           AND bill_cust_id = ps.pay_acct_id))," & _
                        "                            0                                                  " & _
                        "                           )                                                   " & _
                        "                      ) previouspenalty                                " & _
                        "              FROM payments ps                                                 " & _
                        "             WHERE pay_fee_type = :feetype                                     " & _
                        "               AND or_status = 'ISSD'                                          " & _
                        "               AND pay_category = 'REG'                                        " & _
                        "               AND payment_date BETWEEN :startdate AND :enddate                " & _
                        "          GROUP BY pay_acct_id) pv                                             " & _
                        "ORDER BY (SELECT cust_unit_sort                                                " & _
                        "            FROM customer_accounts                                             " & _
                        "           WHERE account_id = pv.pay_acct_id)                                  "
            Using dtBill As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                ReportDoc = New rptCollectionEfficiency
                With ReportDoc.DataDefinition
                    .FormulaFields("TotalCurrentPrincipalBill").Text = CurrentPrincipal
                    .FormulaFields("TotalCurrentPenaltyBill").Text = CurrentPenalty
                    .FormulaFields("AdvancesApplied").Text = Advances
                    .FormulaFields("CreditMemoPrincipalApplied").Text = CreditMemoPrincipal
                    .FormulaFields("CreditMemoPenaltyApplied").Text = CreditMemoPenalty

                End With
                ReportDoc.SetDataSource(DirectCast(dtBill, DataTable))
            End Using

        End Using

    End Sub

    Public Overrides Sub BindItems()
        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtReportTitle"), TextObject).Text = FeeName & " COLLECTION EFFICIENCY REPORT"
            DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName & " PROJECT"

            DirectCast(.ReportObjects("txtBillingMonth"), TextObject).Text = "FOR THE MONTH OF " & BillingDate.ToString("MMMM yyyy").ToUpper
            DirectCast(.ReportObjects("txtPaymentPeriod"), TextObject).Text = "PAYMENT PERIOD " & StartDAte.ToShortDateString & " - " & EndDate.ToShortDateString

            DirectCast(.ReportObjects("txtBillMonth"), TextObject).Text &= " (" & BillingDate.ToString("MMM yyyy").ToUpper & ")"
            ' DirectCast(.ReportObjects("txtPaymentMonth"), TextObject).Text = BillingDate.ToString("MMMM yyyy").ToUpper

            DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
            DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
            'TODO move to other class OraConnection.Instance.UserID
            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With


    End Sub
End Class
