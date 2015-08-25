using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Interop.QBFC12;
using DALC;
using Oracle.DataAccess.Client;
using System.IO;
using BCL.Common;


namespace QBooksUploader
    {
    public class Payment
        {
        private string _folderPath;
        public string FolderPath {
            get { return _folderPath; }
            set { _folderPath = value; }
            }

        private int _uploadCount;
        public int UploadCount {
            get {
                return _uploadCount;
                }
            private set {
                _uploadCount = value;
                }
            }

        private DateTime _fromDate;
        public DateTime FromDate {
            get { return _fromDate; }
            set { _fromDate = value; }
            }

        private DateTime _toDate;
        public DateTime ToDate {
            get { return _toDate; }
            set { _toDate = value; }
        }

        private int _nextDepositID;
        public int NextDepositID {
            get {
                if (_nextDepositID == -1) {
                    return StartingDepositID;
                    }
                else {
                    return _nextDepositID + 1; 
                    }
                }
            private set { _nextDepositID = value; }
            }

        private int _lastDepositID;
        public int LastDepositID {
            get {
                return _lastDepositID;
                }
            private set { _lastDepositID = value; }
            }

        private int StartingDepositID = 2187;

        public string DepositAccount {
            get { return GlobalReference.ProjectParameters.QBDepositoryAccount; }
            }

        public string UploadResultHeader {
            get {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                     "OR_NO","FEE_TYPE","QB_ACCT_NAME","REF_NO", "TXN_DATE", "MEMO", "PAY_METHOD",
                                        "PAY_AMT", "UNUSED_PAYMENT");
                }
            }

        public string DetailsResultHeader {
            get {
                return String.Format("{0},{1},{2},{3},{4}",
                                        "OR_NO", "INV_NO", "INV_DATE", "INV_AMT", "INV_BAL");
                }
            }

        public Payment() { 
            }

        public void UploadPayments() {

            NextDepositID  = GetNextPaymentDepositID();

            using (DataTable dt = GetPayments2()) {
                if (dt.Rows.Count == 0) {
                    UploadCount = 0;
                    return;
                    }

                LastDepositID = int.Parse(dt.Compute("MAX(pay_deposit_id)", "").ToString());

                using (QBConnection qbc = new QBConnection()) {
              
                    foreach (DataRow dr in dt.Rows) {

                        string paymentID = dr["payment_id"].ToString();

                        IReceivePaymentAdd paymentAdd = qbc.RequestSet.AppendReceivePaymentAddRq();

                        paymentAdd.CustomerRef.ListID.SetValue(dr["account_id"].ToString());

                        paymentAdd.ARAccountRef.ListID.SetValue(dr["ar_account"].ToString());
                        paymentAdd.DepositToAccountRef.ListID.SetValue(DepositAccount);

                        paymentAdd.RefNumber.SetValue("OR#"+dr["or_number"].ToString());
                        paymentAdd.TxnDate.SetValue(DateTime.Parse(dr["payment_date"].ToString()));
                        paymentAdd.TotalAmount.SetValue(Convert.ToDouble(dr["paid_amount"].ToString()));

                        string paytype =(dr["payment_type"].ToString() == "CSH") ? "Cash" : "Check";
                        paymentAdd.PaymentMethodRef.FullName.SetValue(paytype);

                        string paycat = (dr["pay_category"].ToString() == "REG") ? "Regular Payment" : "Advance Payment";
                        paymentAdd.Memo.SetValue(paycat);
                       
                        
                        using (DataTable dtApplication = GetPaymentApplication(paymentID)) {
                            int applied=0;
                            foreach (DataRow drApp in dtApplication.Rows) {
                                string txnID;

                                if (drApp["qb_txn_id"].ToString().Split(',').Length > 1) {
                                   txnID = drApp["qb_txn_id"].ToString().Split(',')[0];
                                    }
                                else {
                                    txnID = drApp["qb_txn_id"].ToString();
                                    }

                                if ((!string.IsNullOrEmpty(txnID))&&(txnID != "EXCLUDE")) {
                                    IAppliedToTxnAdd payapplication = paymentAdd.ORApplyPayment.AppliedToTxnAddList.Append();

                                    payapplication.TxnID.SetValue(txnID);

                                    decimal appliedamt =decimal.Round(decimal.Parse(drApp["applied_amt"].ToString()) + decimal.Parse(drApp["penalty_amt"].ToString()),2);

                                    payapplication.PaymentAmount.SetValue(double.Parse(appliedamt.ToString()));
                                    applied += 1;
                                    }
                                }

                            if (applied == 0) {
                                paymentAdd.ORApplyPayment.IsAutoApply.SetValue(false);
                                }

                            }
                        }

                    qbc.PerformRequest();

                    LogUploadtoFile(qbc.ResponseList, dt);
                    }
                }
            }

        public void LogUploadtoFile(IResponseList responseList, DataTable dt) {
            using (StreamWriter txt = new StreamWriter(FolderPath  + "\\payments_upload.csv")) {
                using (StreamWriter txtDetails = new StreamWriter(FolderPath + "\\payments_details_upload.csv")) {
                    txt.WriteLine(UploadResultHeader);
                    txtDetails.WriteLine(DetailsResultHeader);
                    for (int i = 0; i < responseList.Count; i++) {
                        IResponse response = responseList.GetAt(i);
                        //check the status code of the response, 0=ok, >0 is warning
                        string paymentID = dt.Rows[i]["payment_id"].ToString();
                        string ornum = dt.Rows[i]["or_number"].ToString();
                        string feetype = dt.Rows[i]["fee_name"].ToString();
                        string unitnumber = dt.Rows[i]["unit_no"].ToString();
                        if (response.StatusCode == 0) {
                            UploadCount += 1;
                            IReceivePaymentRet paymentRet = response.Detail as IReceivePaymentRet;

                            string txnID = paymentRet.TxnID.GetValue();
                            string custRef = paymentRet.CustomerRef.FullName.GetValue();
                            string arAccount = paymentRet.ARAccountRef.FullName.GetValue();
                            string txnDate = paymentRet.TxnDate.GetValue().ToShortDateString();
                            string refNum = paymentRet.RefNumber.GetValue();
                            string memo = paymentRet.Memo.GetValue();
                            string payMethod = paymentRet.PaymentMethodRef.FullName.GetValue();
                            string totalAmount = paymentRet.TotalAmount.GetValue().ToString();
                            string unusedPayment = paymentRet.UnusedPayment.GetValue().ToString();
                            string unusedCredit = paymentRet.UnusedCredits.GetValue().ToString();

                            txt.WriteLine(String.Format("\"{0}\",{1},\"{2}\",{3},{4},{5},{6},{7},{8}",
                                      ornum,feetype, custRef, refNum, txnDate, memo, payMethod, totalAmount, unusedPayment));

                            if (paymentRet.AppliedToTxnRetList != null) {
                                for (int idx = 0; idx < paymentRet.AppliedToTxnRetList.Count; idx++) {
                                    IAppliedToTxnRet AppliedToTxnRet = paymentRet.AppliedToTxnRetList.GetAt(idx);

                                    string invoiceNum = AppliedToTxnRet.RefNumber.GetValue();
                                    string invoiceTxnDate = AppliedToTxnRet.TxnDate.GetValue().ToShortDateString();
                                    string invoiceAmt = AppliedToTxnRet.Amount.GetValue().ToString();
                                    string invoicebalance = AppliedToTxnRet.BalanceRemaining.GetValue().ToString();

                                    txtDetails.WriteLine(String.Format("{0},{1},{2},{3},{4}",
                                      refNum, invoiceNum, invoiceTxnDate, invoiceAmt, invoicebalance));
                                    }
                                }
                            else {
                                 using (DataTable dtApplication = GetPaymentApplication(paymentID)) {
                                    foreach (DataRow drApp in dtApplication.Rows) {
                                        string invoiceDate = DateTime.Parse(drApp["statement_date"].ToString()).ToShortDateString();
                                        string invoiceprincipal = drApp["applied_amt"].ToString();
                                        string invoicepenalty = drApp["penalty_amt"].ToString();

                                         txtDetails.WriteLine(String.Format("{0},{1},{2},{3},{4}",
                                      refNum, "NOT APPLIED", invoiceDate, invoiceprincipal, invoicepenalty));
                                        } 
                                     }
                                }
                            }
                        else {
                            txt.WriteLine(String.Format("\"{0}\",{1},\"{2}\",{3},{4},{5}",
                                    ornum, feetype, unitnumber, "NOT UPLOADED", response.StatusCode.ToString(),response.StatusMessage));

                            using (DataTable dtApplication = GetPaymentApplication(paymentID)) {
                                    foreach (DataRow drApp in dtApplication.Rows) {
                                        string invoiceDate = DateTime.Parse(drApp["statement_date"].ToString()).ToShortDateString();
                                        string invoiceprincipal = drApp["applied_amt"].ToString();
                                        string invoicepenalty = drApp["penalty_amt"].ToString();

                                         txtDetails.WriteLine(String.Format("{0},{1},{2},{3},{4}",
                                      ornum, "NOT UPLOADED", invoiceDate, invoiceprincipal, invoicepenalty));
                                        } 
                                     }
                            }
                        }
                    }
                }
            }

        private int GetNextPaymentDepositID() {
            string query;

            query = "SELECT NVL(pay_dep_to,-1)                 " +
                    "  FROM qb_upload                          " +
                    " WHERE upload_id = (SELECT MAX (upload_id)" +
                    "                      FROM qb_upload)     ";

            return int.Parse(OraDBHelper2.SqlExecute(query).ToString());

            }

        private DataTable GetPayments() {
           
            string query;

            query = "SELECT (SELECT cust_unit_no                                           " +
                    "          FROM customer_accounts                                      " +
                    "         WHERE account_id = ps.pay_acct_id) unit_no, payment_id, pay_deposit_id," +
                    "payment_type, paid_amount, discount_amt, " +
                    "       check_number, check_date, pay_category, or_number, payment_date,     " +
                    "       (SELECT qb_listid                                                    " +
                    "          FROM customer_accounts                                            " +
                    "         WHERE account_id = ps.pay_acct_id) account_id,                     " +
                    "       (SELECT fee_description                                              " +
                    "          FROM ref_fee_types                                                " +
                    "         WHERE fee_type_id = ps.pay_fee_type) fee_name,                     " +
                    "       (SELECT qb_ar_account                                                " +
                    "          FROM ref_fee_types                                                " +
                    "         WHERE fee_type_id = ps.pay_fee_type) ar_account                    " +
                    "  FROM payments ps                                                          " +
                    " WHERE pay_company = 'C' AND OR_STATUS = 'ISSD' AND PAYMENT_TYPE <> 'CM' " +
                    " AND pay_deposit_id >= :nextdepositid  ORDER BY or_number";

            using (OraParameter param = new OraParameter()) {
                param.AddParameter("nextdepositid", NextDepositID, OracleDbType.Int32, ParameterDirection.Input, false);

                return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
                }

            }


        private DataTable GetPayments2() {

        string query;

        query = "SELECT (SELECT cust_unit_no                                           " +
                "          FROM customer_accounts                                      " +
                "         WHERE account_id = ps.pay_acct_id) unit_no, payment_id, pay_deposit_id," +
                "payment_type, paid_amount, discount_amt, " +
                "       check_number, check_date, pay_category, or_number, payment_date,     " +
                "       (SELECT qb_listid                                                    " +
                "          FROM customer_accounts                                            " +
                "         WHERE account_id = ps.pay_acct_id) account_id,                     " +
                "       (SELECT fee_description                                              " +
                "          FROM ref_fee_types                                                " +
                "         WHERE fee_type_id = ps.pay_fee_type) fee_name,                     " +
                "       (SELECT qb_ar_account                                                " +
                "          FROM ref_fee_types                                                " +
                "         WHERE fee_type_id = ps.pay_fee_type) ar_account                    " +
                "  FROM payments ps                                                          " +
                " WHERE pay_company = 'C' AND OR_STATUS = 'ISSD' AND PAYMENT_TYPE <> 'CM' " +
                " AND PAYMENT_DATE BETWEEN :fromdate AND :todate AND PAY_DEPOSIT_ID IS NOT NULL ORDER BY or_number";

        using (OraParameter param = new OraParameter()) {
            param.AddParameter("fromdate", FromDate, OracleDbType.Date, ParameterDirection.Input, false);
            param.AddParameter("todate", ToDate, OracleDbType.Date, ParameterDirection.Input, false);

            return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
            }

        }

        private DataTable GetPaymentApplication(string paymentID) {
        
            string query;

            query = "SELECT bill_id,(SELECT bill_generate_date from billing_charges " +
                    "where bill_id = ps.bill_id) statement_date, (SELECT qb_txn_id   " +                           
                    "                   FROM billing_charges                               " +
                    "                  WHERE bill_id = ps.bill_id) qb_txn_id, applied_amt, " +
                    "       penalty_amt                                                    " +
                    "  FROM pay_transactions ps                                            " +
                    " WHERE payment_id = :paymentid                                        ";

             using (OraParameter param = new OraParameter()) {
                 param.AddParameter("paymentid", paymentID,OracleDbType.Varchar2 , ParameterDirection.Input, false);

                 return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
                }

            }
           
        }
    }
