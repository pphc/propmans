Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine


Public Class RentRollReport

    Inherits ReportBase


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "RENT ROLL"
        End Get
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"
            .FormulaFields("AsOfDate").Text = "'" & Now.Date.ToString("M/d/yyyy").ToUpper & "'"

        End With

        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With

    End Sub

    Public Sub LoadData()
        Dim query As String = "SELECT   (SELECT cust_unit_no                                                       " & _
                              "            FROM customer_accounts                                                  " & _
                              "           WHERE account_id IN (                                                    " & _
                              "                            SELECT account_id                                       " & _
                              "                              FROM rm_agreement                                     " & _
                              "                             WHERE agreement_id =                                   " & _
                              "                                                 rlc.agreement_id))                 " & _
                              "                                                                  unit_number,      " & _
                              "         (SELECT unit_class                                                         " & _
                              "            FROM rm_agreement                                                       " & _
                              "           WHERE agreement_id = rlc.agreement_id) unit_type,                        " & _
                              "         accounts.getcustomerfullname_fml (cust_id) tenant_name,                    " & _
                              "         TO_CHAR (contract_start, 'MM/DD/YYYY') contract_start,                     " & _
                              "         TO_CHAR (contract_end, 'MM/DD/YYYY') contract_end,                         " & _
                              "         rent_amt rent_amount,                                                      " & _
                              "         TO_NUMBER(TO_CHAR (NVL (security_deposit, 0) + NVL (cash_bond, 0)))        " & _
                              "                                                                 deposit_held       " & _
                              "    FROM (SELECT cust_id, agreement_id, contract_start, contract_end,               " & _
                              "                 rent_amt, security_deposit, cash_bond                              " & _
                              "            FROM rm_lease_contract                                                  " & _
                              "           WHERE contract_status IN ('ACT', 'FAP')) rlc                             " & _
                              "UNION ALL                                                                           " & _
                              "SELECT   (SELECT cust_unit_no                                                       " & _
                              "            FROM customer_accounts                                                  " & _
                              "           WHERE account_id = ra.account_id) unit_number,                           " & _
                              "         ra.unit_class unit_type,                                                   " & _
                              "         NVL2                                                                       " & _
                              "            (accounts.getcustomerfullname_fml ((SELECT cust_unit_no                 " & _
                              "                                                  FROM customer_accounts            " & _
                              "                                                 WHERE account_id =                 " & _
                              "                                                                 ra.account_id)     " & _
                              "                                              ),                                    " & _
                              "             '',                                                                    " & _
                              "             'VACANT'                                                               " & _
                              "            ) tenant_name,                                                          " & _
                              "         NVL2 (ra.contract_start, '-', '') contract_start,                          " & _
                              "         NVL2 (ra.contract_end, '-', '') contract_end,                              " & _
                              "         NVL2 (ra.rent_amt, TO_NUMBER('0'), '') rent_amount,                        " & _
                              "         NVL2 (NVL (security_deposit, 0) + NVL (cash_bond, 0),                      " & _
                              "               TO_NUMBER('0'),                                                      " & _
                              "               ''                                                                   " & _
                              "              ) deposit_held                                                        " & _
                              "    FROM (SELECT account_id, unit_class, contract_start, contract_end,              " & _
                              "                 rent_amt, security_deposit, cash_bond                              " & _
                              "            FROM rm_agreement                                                       " & _
                              "           WHERE contract_status IN ('ACT', 'FAP')                                  " & _
                              "             AND agreement_id NOT IN (SELECT agreement_id                           " & _
                              "                                        FROM rm_lease_contract                      " & _
                              "                                       WHERE contract_status IN                     " & _
                              "                                                               ('ACT', 'FAP'))) ra  " & _
                              "ORDER BY unit_number ASC                                                            "


        Dim SubReport As String = "SELECT   x.unit_type, TO_CHAR (x.no_of_occupants) no_of_occupants,                              " & _
                                  "         TO_CHAR (SUM ((x.no_of_occupants - x.vacants))) vacants                                " & _
                                  "    FROM (SELECT   x.unit_type, TO_CHAR (x.max_occupants) no_of_occupants,                      " & _
                                  "                   TO_CHAR (SUM (x.no_of_units)) vacants                                        " & _
                                  "              FROM (SELECT   (SELECT unit_class                                                 " & _
                                  "                                FROM rm_agreement                                               " & _
                                  "                               WHERE agreement_id =                                             " & _
                                  "                                                   rlc.agreement_id)                            " & _
                                  "                                                                    unit_type,                  " & _
                                  "                             (SELECT CASE unit_class                                            " & _
                                  "                                        WHEN 'DORM'                                             " & _
                                  "                                           THEN max_occupants                                   " & _
                                  "                                        WHEN 'BARE'                                             " & _
                                  "                                           THEN (SELECT COUNT                                   " & _
                                  "                                                           (x.unit_number                       " & _
                                  "                                                           )                                    " & _
                                  "                                                           no_of_occupants                      " & _
                                  "                                                   FROM (SELECT (SELECT cust_unit_no            " & _
                                  "                                                                   FROM customer_accounts       " & _
                                  "                                                                  WHERE account_id =            " & _
                                  "                                                                           ra.account_id)       " & _
                                  "                                                                   unit_number                  " & _
                                  "                                                           FROM rm_agreement ra                 " & _
                                  "                                                          WHERE contract_status IN              " & _
                                  "                                                                   ('ACT',                      " & _
                                  "                                                                    'FAP'                       " & _
                                  "                                                                   )                            " & _
                                  "                                                            AND unit_class =                    " & _
                                  "                                                                        'BARE') x)              " & _
                                  "                                        WHEN 'FURNISHED'                                        " & _
                                  "                                           THEN (SELECT COUNT                                   " & _
                                  "                                                           (x.unit_number                       " & _
                                  "                                                           ) no_of_occupants                    " & _
                                  "                                                   FROM (SELECT (SELECT cust_unit_no            " & _
                                  "                                                                   FROM customer_accounts       " & _
                                  "                                                                  WHERE account_id =            " & _
                                  "                                                                           ra.account_id)       " & _
                                  "                                                                   unit_number                  " & _
                                  "                                                           FROM rm_agreement ra                 " & _
                                  "                                                          WHERE contract_status IN              " & _
                                  "                                                                   ('ACT',                      " & _
                                  "                                                                    'FAP'                       " & _
                                  "                                                                   )                            " & _
                                  "                                                            AND unit_class =                    " & _
                                  "                                                                   'FURNISHED') x)              " & _
                                  "                                        WHEN 'SEMI-FURNISHED'                                   " & _
                                  "                                           THEN (SELECT COUNT                                   " & _
                                  "                                                           (x.unit_number                       " & _
                                  "                                                           ) no_of_occupants                    " & _
                                  "                                                   FROM (SELECT (SELECT cust_unit_no            " & _
                                  "                                                                   FROM customer_accounts       " & _
                                  "                                                                  WHERE account_id =            " & _
                                  "                                                                           ra.account_id)       " & _
                                  "                                                                   unit_number                  " & _
                                  "                                                           FROM rm_agreement ra                 " & _
                                  "                                                          WHERE contract_status IN              " & _
                                  "                                                                   ('ACT',                      " & _
                                  "                                                                    'FAP'                       " & _
                                  "                                                                   )                            " & _
                                  "                                                            AND unit_class =                    " & _
                                  "                                                                   'SEMI-FURNISHED') x)         " & _
                                  "                                        WHEN 'PARKING'                                          " & _
                                  "                                           THEN (SELECT COUNT                                   " & _
                                  "                                                           (x.unit_number                       " & _
                                  "                                                           ) no_of_occupants                    " & _
                                  "                                                   FROM (SELECT (SELECT cust_unit_no            " & _
                                  "                                                                   FROM customer_accounts       " & _
                                  "                                                                  WHERE account_id =            " & _
                                  "                                                                           ra.account_id)       " & _
                                  "                                                                   unit_number                  " & _
                                  "                                                           FROM rm_agreement ra                 " & _
                                  "                                                          WHERE contract_status IN              " & _
                                  "                                                                   ('ACT',                      " & _
                                  "                                                                    'FAP'                       " & _
                                  "                                                                   )                            " & _
                                  "                                                            AND unit_class =                    " & _
                                  "                                                                     'PARKING') x)              " & _
                                  "                                     END max_occupants                                          " & _
                                  "                                FROM rm_agreement                                               " & _
                                  "                               WHERE agreement_id =                                             " & _
                                  "                                               rlc.agreement_id)                                " & _
                                  "                                                                max_occupants,                  " & _
                                  "                             COUNT (agreement_id) no_of_units                                   " & _
                                  "                        FROM rm_lease_contract rlc                                              " & _
                                  "                       WHERE contract_status IN ('ACT', 'FAP')                                  " & _
                                  "                    GROUP BY agreement_id) x                                                    " & _
                                  "          GROUP BY x.unit_type, x.max_occupants) x                                              " & _
                                  "GROUP BY x.unit_type, x.no_of_occupants                                                         " & _
                                  "UNION ALL                                                                                       " & _
                                  "SELECT   x.unit_class unit_type,                                                                " & _
                                  "         TO_CHAR (COUNT (x.unit_number)) no_of_occupants,                                       " & _
                                  "         TO_CHAR (COUNT (x.agreement_id)) vacants                                               " & _
                                  "    FROM (SELECT account_id, agreement_id, unit_class,                                          " & _
                                  "                 (SELECT cust_unit_no                                                           " & _
                                  "                    FROM customer_accounts                                                      " & _
                                  "                   WHERE account_id = ra.account_id) unit_number                                " & _
                                  "            FROM rm_agreement ra                                                                " & _
                                  "           WHERE contract_status IN ('ACT', 'FAP')                                              " & _
                                  "             AND agreement_id NOT IN (SELECT agreement_id                                       " & _
                                  "                                        FROM rm_lease_contract                                  " & _
                                  "                                       WHERE contract_status IN                                 " & _
                                  "                                                               ('ACT', 'FAP'))) x               " & _
                                  "GROUP BY x.unit_class                                                                           "

       

        Using dt As DataTable = OraDBHelper2.GetResultSet(query), _
           dtSub As DataTable = OraDBHelper2.GetResultSet(SubReport)

            ReportDoc = New rptRentRollForm
            ReportDoc.SetDataSource(DirectCast(dt, DataTable))
            ReportDoc.OpenSubreport("rptSummaryByUnitClassificationForm.rpt").SetDataSource(DirectCast(dtSub, DataTable))

        End Using




    End Sub

End Class
