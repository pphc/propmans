'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 01-19-2010
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 06-24-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Namespace Statements

    Public NotInheritable Class SelectStatement

        Private Shared query As String


#Region "Billings Querries"

        Public Shared ReadOnly Property GetBillingMonths() As String
            Get
                query = "SELECT DISTINCT bill_date                                   " & _
                        "           FROM billing_charges                               " & _
                        "          WHERE bill_fee_type = :typeid AND bill_status <> 'C'" & _
                        "       ORDER BY 1 DESC                                        "
                Return query
            End Get
        End Property




        Public Shared ReadOnly Property GetUnpaidBillingsByFeeType() As String
            Get
                query = "SELECT   bill_id, (SELECT fee_description                                     " & _
                        "                     FROM ref_fee_types                                       " & _
                        "                    WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date," & _
                        "         bill_generate_date, amount_due, penalty_amt, bill_status             " & _
                        "    FROM billing_charges bc                                                   " & _
                        "   WHERE bill_cust_id = :acctid                                               " & _
                        "     AND bill_status IN ('U', 'H')                                            " & _
                        "     AND bill_fee_type = :feetypeid                                           " & _
                        "ORDER BY bill_generate_date DESC                                              "
                Return query
            End Get
        End Property

#End Region

#Region "Payments"

        Public Shared ReadOnly Property GetPayments() As String
            Get
                query = "SELECT payment_id, or_number, (SELECT fee_description                         " & _
                        "                                 FROM ref_fee_types                           " & _
                        "                                WHERE fee_type_id = ps.pay_fee_type) fee_name," & _
                        "       payment_date, paid_amount,                                             " & _
                        "       DECODE (payment_type,                                                  " & _
                        "               'CSH', 'CASH',                                                 " & _
                        "               'CHK', 'CHECK',                                                " & _
                        "               'CM', 'CREDIT MEMO',                                           " & _
                        "               'N/A'                                                          " & _
                        "              ) payment_mode,                                                 " & _
                        "       discount_rate, discount_amt, check_number, check_date,                 " & _
                        "       (SELECT bank_name                                                      " & _
                        "          FROM ref_banks                                                      " & _
                        "         WHERE bank_id = ps.pay_bank_id) bank_name,                           " & _
                        "       DECODE (pay_category,                                                  " & _
                        "               'REG', 'REGULAR',                                              " & _
                        "               'ADV', 'ADVANCES',                                             " & _
                        "               'CM', 'CREDIT MEMO',                                           " & _
                        "               'N/A'                                                          " & _
                        "              ) payment_type,                                                 " & _
                        "       pay_balance                                                            " & _
                        "  FROM payments ps                                                            " & _
                        " WHERE pay_acct_id = :acctid AND or_status <> 'CAN'"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetBanks() As String
            Get
                query = "SELECT bank_id, bank_name" & _
                        "  FROM ref_banks         " & _
                        "ORDER by bank_name"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetbankInfo() As String
            Get
                query = "SELECT bank_code, bank_name" & _
                        "  FROM ref_banks           " & _
                        " WHERE bank_id = :bankid   "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetReceiptDetails() As String
            Get
                query = "SELECT payment_id, or_number, payment_date, paid_amount, created_by,          " & _
                        "       created_date, pay_issue_type, payment_type, pay_category, check_number," & _
                        "       check_date, (SELECT bank_name                                          " & _
                        "                      FROM ref_banks                                          " & _
                        "                     WHERE bank_id = ps.pay_bank_id) check_bank,              " & _
                        "       (SELECT fee_description                                                " & _
                        "          FROM ref_fee_types                                                  " & _
                        "         WHERE fee_type_id = ps.pay_fee_type) fee_name, discount_rate,        " & _
                        "       discount_amt, (SELECT cust_unit_no                                     " & _
                        "                        FROM customer_accounts                                " & _
                        "                       WHERE account_id = ps.pay_acct_id) unit_no,            " & _
                        "       accounts.getcustomerfullname_lfm ((SELECT acct_cust_id                              " & _
                        "                               FROM customer_accounts                         " & _
                        "                              WHERE account_id = ps.pay_acct_id)) owner,      " & _
                        "       pay_remarks, or_status,                                                " & _
                        "       (SELECT deposit_date                                                   " & _
                        "          FROM deposits                                                       " & _
                        "         WHERE deposit_id = ps.pay_deposit_id) deposit_date,                  " & _
                        "       (SELECT (SELECT bank_account_no                                        " & _
                        "                  FROM depository_banks                                       " & _
                        "                 WHERE proj_bank_id = ds.depository_bank_id)                  " & _
                        "          FROM deposits ds                                                    " & _
                        "         WHERE deposit_id = ps.pay_deposit_id) deposit_bank                   " & _
                        "  FROM payments ps                                                            " & _
                        " WHERE or_number = LPAD (:receiptnumber, 7, '0')                              " & _
                        "   AND (SELECT fee_company                                                    " & _
                        "          FROM ref_fee_types                                                  " & _
                        "         WHERE fee_type_id = ps.pay_fee_type) = :corporation                  "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetReceiptInvoces() As String
            Get
                query = "SELECT bill_generate_date, penalty_amt, amount_due,amount_paid " & _
                                "  FROM billing_charges                        " & _
                                " WHERE bill_id IN (SELECT bill_id             " & _
                                "                     FROM pay_transactions    " & _
                                "                    WHERE payment_id = :payid)"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetFeeVatInfo() As String
            Get
                query = "SELECT fee_company, vatable  " & _
                        "FROM(ref_fee_types) " & _
                        " WHERE fee_type_id = :feeid "
                Return query
            End Get
        End Property


#End Region

#Region "Deposits"

        Public Shared ReadOnly Property GetBankNamebyID() As String
            Get
                query = "SELECT proj_bank_name        " & _
                        "  FROM depository_banks      " & _
                        " WHERE proj_bank_id = :bankid"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetDepositoryAccounts() As String
            Get
                query = "SELECT proj_bank_id, bank_account_no" & _
                        "  FROM depository_banks             " & _
                        " WHERE status = 'ACT'               "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetDepositsByDateRange() As String
            Get
                query = "SELECT deposit_id, deposit_date, bank_account_no, proj_bank_name, " & _
                        "       deposit_type, deposit_total_amt,                           " & _
                        "       (SELECT COUNT (payment_id)                                 " & _
                        "          FROM payments                                           " & _
                        "         WHERE pay_deposit_id = ds.deposit_id) trans_count        " & _
                        "  FROM deposits ds JOIN depository_banks db                       " & _
                        "       ON (ds.depository_bank_id = db.proj_bank_id)               " & _
                        " WHERE deposit_date BETWEEN :startdate AND :enddate               " & _
                        "   AND deposit_status = 'P' ORDER BY deposit_date "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetDepositsByType() As String
            Get
                query = " SELECT deposit_id, deposit_date, bank_account_no, proj_bank_name," & _
                        "        deposit_type, deposit_total_amt,                          " & _
                        "        (SELECT COUNT (payment_id)                                " & _
                        "           FROM payments                                          " & _
                        "          WHERE pay_deposit_id = ds.deposit_id) trans_count       " & _
                        "   FROM deposits ds JOIN depository_banks db                      " & _
                        "        ON (ds.depository_bank_id = db.proj_bank_id)              " & _
                        "  WHERE deposit_type = :deposittype                               " & _
                        "   AND deposit_status = 'P'"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetDepositsByBank() As String
            Get
                query = " SELECT deposit_id, deposit_date, bank_account_no, proj_bank_name, " & _
                        "        deposit_type, deposit_total_amt,                           " & _
                        "        (SELECT COUNT (payment_id)                                 " & _
                        "           FROM payments                                           " & _
                        "          WHERE pay_deposit_id = ds.deposit_id) trans_count        " & _
                        "   FROM deposits ds JOIN depository_banks db                       " & _
                        "        ON (ds.depository_bank_id = db.proj_bank_id)               " & _
                        "   WHERE ds.depository_bank_id = :bankid                           " & _
                        "   AND deposit_status = 'P'"
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetUndepositedReceipts() As String
            Get
                query = "SELECT   payment_id, or_number, payment_date, paid_amount " & _
                        "    FROM payments                                         " & _
                        "   WHERE payment_type = :paytype                          " & _
                        "     AND payment_date BETWEEN :startdate AND :enddate     " & _
                        "     AND or_status = 'ISSD'                               " & _
                        "     AND pay_deposit_id IS NULL                           " & _
                        "ORDER BY or_number                                        "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property GetDepositedReceipts() As String
            Get
                query = "SELECT   payment_id, or_number, payment_date, paid_amount " & _
                        "    FROM payments                                         " & _
                        "   WHERE pay_deposit_id = :depositid                      " & _
                        "ORDER BY or_number                                        "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetDepositDetails() As String
            Get
                query = "SELECT deposit_id, deposit_date, bank_account_no, proj_bank_name," & _
                        "       deposit_type, deposit_total_amt,deposit_remarks           " & _
                        "  FROM deposits ds JOIN depository_banks db                      " & _
                        "       ON (ds.depository_bank_id = db.proj_bank_id)              " & _
                        " WHERE deposit_id = :depositid                                   "

                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetDepositEntries() As String
            Get
                query = "SELECT bankcode, payment_date, or_number, paid_amount, feeid, feedescription," & _
                        "       byrcode, byrname                                                      " & _
                        "  FROM deposit_accpac_export                                                 " & _
                        " WHERE deposit_id = :depositid                                               "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetDepositSummary() As String
            Get
                query = "SELECT   deposit_id,                                                " & _
                        "         (SELECT proj_bank_branch                                   " & _
                        "            FROM depository_banks                                   " & _
                        "           WHERE proj_bank_id = ds.depository_bank_id) companytype, " & _
                        "         deposit_status, deposit_remarks                            " & _
                        "    FROM deposits ds                                                " & _
                        "   WHERE deposit_id >= :depositid                                   " & _
                        "ORDER BY deposit_id                                                 "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetDepositSummaryByRange() As String
            Get
                query = "SELECT   deposit_id,                                                " & _
                        "         (SELECT proj_bank_branch                                   " & _
                        "            FROM depository_banks                                   " & _
                        "           WHERE proj_bank_id = ds.depository_bank_id) companytype, " & _
                        "         deposit_status, deposit_remarks                            " & _
                        "    FROM deposits ds                                                " & _
                        "   WHERE deposit_id between :startid AND :endid                                     " & _
                        "ORDER BY deposit_id                                                 "
                Return query
            End Get

        End Property
        Public Shared ReadOnly Property GetDepositHeader() As String
            Get
                query = "SELECT   deposit_id, deposit_date,                             " & _
                        "         (SELECT bank_id                                       " & _
                        "            FROM depository_banks                              " & _
                        "           WHERE proj_bank_id = ds.depository_bank_id) bankcode" & _
                        "    FROM deposits ds                                           " & _
                        "   WHERE depository_bank_id IN (SELECT proj_bank_id            " & _
                        "                                  FROM depository_banks        " & _
                        "                                 WHERE proj_bank_branch = 'P') " & _
                        "     AND deposit_status = 'P'                                  " & _
                        "     AND deposit_id >= :depositid                              " & _
                        "ORDER BY deposit_id                                            "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetDepositHeaderByRange() As String
            Get
                query = "SELECT   deposit_id, deposit_date,                             " & _
                        "         (SELECT bank_id                                       " & _
                        "            FROM depository_banks                              " & _
                        "           WHERE proj_bank_id = ds.depository_bank_id) bankcode" & _
                        "    FROM deposits ds                                           " & _
                        "   WHERE depository_bank_id IN (SELECT proj_bank_id            " & _
                        "                                  FROM depository_banks        " & _
                        "                                 WHERE proj_bank_branch = 'P') " & _
                        "     AND deposit_status = 'P'                                  " & _
                        "     AND deposit_id between :startid AND :endid                " & _
                        "ORDER BY deposit_id                                            "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetACDepositDetails() As String
            Get
                query = "SELECT   deposit_id, payment_date, or_number, paid_amount,     " & _
                        "         (SELECT finance_code                                  " & _
                        "            FROM ref_fee_types                                 " & _
                        "           WHERE fee_type_id = ps.pay_fee_type) feeid,         " & _
                        "         (SELECT INITCAP (fee_description)                     " & _
                        "            FROM ref_fee_types                                 " & _
                        "           WHERE fee_type_id = ps.pay_fee_type) feedescription," & _
                        "         (SELECT cust_finance_code                             " & _
                        "            FROM customer_accounts                             " & _
                        "           WHERE account_id = ps.pay_acct_id) byrcode,         " & _
                        "         (SELECT accounts.getcustomerfullname_fml (acct_cust_id)            " & _
                        "            FROM customer_accounts cs                          " & _
                        "           WHERE account_id = ps.pay_acct_id) byrname,         " & _
                        "         (SELECT cust_unit_no                                  " & _
                        "            FROM customer_accounts cs                          " & _
                        "           WHERE account_id = ps.pay_acct_id) unitnumber       " & _
                        "    FROM deposits ds LEFT JOIN payments ps                     " & _
                        "         ON (ds.deposit_id = ps.pay_deposit_id)                " & _
                        "   WHERE depository_bank_id IN (SELECT proj_bank_id            " & _
                        "                                  FROM depository_banks        " & _
                        "                                 WHERE proj_bank_branch = 'P') " & _
                        "     AND deposit_status = 'P'                                  " & _
                        "     AND deposit_id >= :depositid                              " & _
                        "ORDER BY deposit_id                                            "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetACDepositDetailsbyRange() As String
            Get
                query = "SELECT   deposit_id, payment_date, or_number, paid_amount,     " & _
                        "         (SELECT finance_code                                  " & _
                        "            FROM ref_fee_types                                 " & _
                        "           WHERE fee_type_id = ps.pay_fee_type) feeid,         " & _
                        "         (SELECT INITCAP (fee_description)                     " & _
                        "            FROM ref_fee_types                                 " & _
                        "           WHERE fee_type_id = ps.pay_fee_type) feedescription," & _
                        "         (SELECT cust_finance_code                             " & _
                        "            FROM customer_accounts                             " & _
                        "           WHERE account_id = ps.pay_acct_id) byrcode,         " & _
                        "         (SELECT accounts.getcustomerfullname_fml (acct_cust_id)            " & _
                        "            FROM customer_accounts cs                          " & _
                        "           WHERE account_id = ps.pay_acct_id) byrname,         " & _
                        "         (SELECT cust_unit_no                                  " & _
                        "            FROM customer_accounts cs                          " & _
                        "           WHERE account_id = ps.pay_acct_id) unitnumber       " & _
                        "    FROM deposits ds LEFT JOIN payments ps                     " & _
                        "         ON (ds.deposit_id = ps.pay_deposit_id)                " & _
                        "   WHERE depository_bank_id IN (SELECT proj_bank_id            " & _
                        "                                  FROM depository_banks        " & _
                        "                                 WHERE proj_bank_branch = 'P') " & _
                        "     AND deposit_status = 'P'                                  " & _
                        "     AND deposit_id between :startid and :endid                " & _
                        "ORDER BY deposit_id                                            "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetGlapsPayor2() As String
            Get
                query = "SELECT DISTINCT byrcode, byrname                                         " & _
                        "           FROM (SELECT   (SELECT cust_finance_code                      " & _
                        "                             FROM customer_accounts                      " & _
                        "                            WHERE account_id = ps.pay_acct_id) byrcode,  " & _
                        "                          (SELECT (SELECT    cust_lname                  " & _
                        "                                          || ', '                        " & _
                        "                                          || cust_fname                  " & _
                        "                                          || ' '                         " & _
                        "                                          || NVL (cust_mname, '')        " & _
                        "                                     FROM customers                      " & _
                        "                                    WHERE cust_id = cs.acct_cust_id)     " & _
                        "                             FROM customer_accounts cs                   " & _
                        "                            WHERE account_id = ps.pay_acct_id) byrname   " & _
                        "                     FROM payments ps                                    " & _
                        "                    WHERE payment_date BETWEEN :startdate AND :enddate   " & _
                        "                      AND or_status = 'ISSD'                             " & _
                        "                      AND payment_type <> 'CM'                           " & _
                        "                 ORDER BY payment_date, or_number)                       "
                Return query
            End Get

        End Property

        Public Shared ReadOnly Property GetGlapsDepositEntries2() As String
            Get
                query = "SELECT   '01-DEC-2010' deposit_date, 1 bank_code, payment_date, or_number,   " & _
                        "         paid_amount, (SELECT fee_description                                " & _
                        "                         FROM ref_fee_types                                  " & _
                        "                        WHERE fee_type_id = ps.pay_fee_type) feedescription, " & _
                        "         (SELECT cust_finance_code                                           " & _
                        "            FROM customer_accounts                                           " & _
                        "           WHERE account_id = ps.pay_acct_id) byrcode,                       " & _
                        "         (SELECT cust_unit_no                                                " & _
                        "            FROM customer_accounts                                           " & _
                        "           WHERE account_id = ps.pay_acct_id) unit_number,                   " & _
                        "         (SELECT (SELECT    cust_lname                                       " & _
                        "                         || ', '                                             " & _
                        "                         || cust_fname                                       " & _
                        "                         || ' '                                              " & _
                        "                         || NVL (cust_mname, '')                             " & _
                        "                    FROM customers                                           " & _
                        "                   WHERE cust_id = cs.acct_cust_id)                          " & _
                        "            FROM customer_accounts cs                                        " & _
                        "           WHERE account_id = ps.pay_acct_id) byrname,                       " & _
                        "         (SELECT bank_code                                                   " & _
                        "            FROM ref_banks                                                   " & _
                        "           WHERE bank_id = ps.pay_bank_id) check_bank, check_number,         " & _
                        "         check_date                                                          " & _
                        "    FROM payments ps                                                         " & _
                        "   WHERE payment_date BETWEEN :startdate AND :enddate                        " & _
                        "     AND or_status = 'ISSD'                                                  " & _
                        "     AND payment_type <> 'CM'                                                " & _
                        "ORDER BY payment_date, or_number                                             "
                Return query
            End Get

        End Property

#End Region

#Region "Quickbooks"

        Public Shared ReadOnly Property GetIssuedPayments() As String
            Get
                query = "SELECT   payment_id, (SELECT cust_unit_sort                                    " & _
                        "                        FROM customer_accounts                                 " & _
                        "                       WHERE account_id = ps.pay_acct_id) unit_sort,           " & _
                        "            (SELECT cust_unit_no                                               " & _
                        "               FROM customer_accounts                                          " & _
                        "              WHERE account_id = ps.pay_acct_id)                               " & _
                        "         || ' '                                                                " & _
                        "         || (SELECT    cust_fname                                              " & _
                        "                    || ' '                                                     " & _
                        "                    || NVL2 (cust_mname, SUBSTR (cust_mname, 1, 1) || '.', '') " & _
                        "                    || ' '                                                     " & _
                        "                    || cust_lname                                              " & _
                        "               FROM customers                                                  " & _
                        "              WHERE cust_id = (SELECT acct_cust_id                             " & _
                        "                                 FROM customer_accounts                        " & _
                        "                                WHERE account_id = ps.pay_acct_id)) cust_name, " & _
                        "         or_number, check_number, payment_date,                                " & _
                        "         DECODE (payment_type,                                                 " & _
                        "                 'CHK', 'CHECK',                                               " & _
                        "                 'CSH', 'CASH',                                                " & _
                        "                 'CREDIT MEMO'                                                 " & _
                        "                ) payment_type,                                                " & _
                        "         DECODE                                                                " & _
                        "            (pay_category,                                                     " & _
                        "             'REG', (SELECT SUM (getamountduepayment (pt.bill_id,              " & _
                        "                                                      pt.applied_amt           " & _
                        "                                                     )                         " & _
                        "                                )                                              " & _
                        "                       FROM pay_transactions pt                                " & _
                        "                      WHERE payment_id = ps.payment_id),                       " & _
                        "             paid_amount                                                       " & _
                        "            ) principal_amt,                                                   " & _
                        "         paid_amount,                                                          " & _
                        "         (SELECT unit_parking_tag                                              " & _
                        "            FROM unit_types                                                    " & _
                        "           WHERE unit_type_id = (SELECT cust_unit_type                         " & _
                        "                                   FROM customer_accounts                      " & _
                        "                                  WHERE account_id = ps.pay_acct_id))          " & _
                        "                                                                     unit_tag, " & _
                        "         pay_remarks                                                           " & _
                        "    FROM payments ps                                                           " & _
                        "   WHERE pay_fee_type IN (13, 14)                                              " & _
                        "     AND or_status = 'ISSD'                                                    " & _
                        "     AND payment_date BETWEEN :startdate AND :enddate                          " & _
                        "ORDER BY 2                                                                     "

                Return query
            End Get

        End Property
#End Region

#Region "ACCPAC"

        Public Shared ReadOnly Property GetInvoicesMonthPeriod() As String
            Get
                query = "SELECT   bill_id,                                                             " & _
                        "            (SELECT cust_finance_code                                         " & _
                        "               FROM customer_accounts                                         " & _
                        "              WHERE account_id = bc.bill_cust_id)                             " & _
                        "         || '-'                                                               " & _
                        "         || getcustfullname_fml ((SELECT acct_cust_id                         " & _
                        "                                    FROM customer_accounts                    " & _
                        "                                   WHERE account_id = bc.bill_cust_id))       " & _
                        "                                                                 account_name," & _
                        "         bill_fee_type feeid, amount_due + penalty_amt amount,                  " & _
                        "         bill_generate_date bill_date                                         " & _
                        "    FROM billing_charges bc                                                   " & _
                        "   WHERE bill_fee_type IN (SELECT fee_type_id                                 " & _
                        "                             FROM ref_fee_types                               " & _
                        "                            WHERE fee_type_id = 25)                          " & _
                        "     AND bill_date BETWEEN :startdate AND :enddate                   " & _
                        "     AND bill_status <> 'C'                                                   " & _
                        "ORDER BY (SELECT cust_unit_sort from customer_accounts where account_id = bc.bill_cust_id) "
                Return query
            End Get
        End Property

#End Region

    End Class

    Public NotInheritable Class InsertStatement
        Private Shared query As String


        Public Shared ReadOnly Property NewBillingCharges() As String
            Get
                query = "INSERT INTO billing_charges                      " & _
                        "            (bill_date,bill_generate_date,bill_due_date,bill_fee_type,penalty_amt, amount_due,bill_reading_id,bill_cust_id" & _
                        "            )                                    " & _
                        "     VALUES (:billdate,:billgeneratedate,:billduedate, :billfeetype,:penalty, :amountDue,:billreadID,:acctID " & _
                        "            )                                    "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property NewPayTransaction()
            Get
                query = "INSERT INTO pay_transactions                     " & _
                        "            (bill_id, payment_id,applied_amt,penalty_amt" & _
                        "            )                                    " & _
                        "     VALUES (:billid,:paymentid,:appliedamt,:penaltyamt" & _
                        "            )                                    "
                Return query
            End Get
        End Property


    End Class

    Public NotInheritable Class UpdateStatement

        Private Shared query As String


        Public Shared ReadOnly Property UpdatebillAmountPaid() As String
            Get
                query = "UPDATE billing_charges          " & _
                        "   SET amount_paid = :amountpaid" & _
                        " WHERE bill_id = :billid        "
                Return query
            End Get
        End Property


        Public Shared ReadOnly Property UpdatePaymentDepositID() As String
            Get
                query = "UPDATE payments                    " & _
                        "   SET pay_deposit_id = :depositid " & _
                        " WHERE payment_id = :paymentid   "
                Return query
            End Get
        End Property

        Public Shared ReadOnly Property UpdateDepositHeader() As String
            Get
                query = "UPDATE deposits                " & _
                        "   SET deposit_status = 'C'    " & _
                        " WHERE deposit_id = :depositid "
                Return query
            End Get
        End Property
    End Class
End Namespace
