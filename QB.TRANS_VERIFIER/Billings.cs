using DALC;
using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.IO;

namespace TransactionsVerifier
    {
    public class Billings
        {
        private string _folderPath;
        public string FolderPath {
            get { return _folderPath; }
            set { _folderPath = value; }
            }

        private DateTime _invoiceFromDate;
        public DateTime InvoiceFromDate {
            get { return _invoiceFromDate; }
            set { _invoiceFromDate = value; }
            }

        private DateTime _invoiceToDate;
        public DateTime InvoiceToDate {
            get { return _invoiceToDate; }
            set { _invoiceToDate = value; }
            }

        public string FileName {
            get { return "InvoicesCheck_" + InvoiceFromDate.ToString("yyyyMMdd") + "-" + InvoiceToDate.ToString("yyyyMMdd"); }
            }
     
        public string FP {
            get {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                       "FP", "UNIT_NO", "FEE_NAME", "BILL_ID", "BILL_DATE", "PRINCIPAL",
                                       "PENALTY", "AMOUNT_PAID", "BALANCE", "APP_PR", "APP_PEN", "F1", "F2", "F3", "F4");
                }
            }

        public string UP {
            get {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                       "UP", "UNIT_NO", "FEE_NAME", "BILL_ID", "BILL_DATE", "PRINCIPAL",
                                       "PENALTY", "AMOUNT_PAID", "BALANCE", "APP_PR", "APP_PEN", "U1", "U2", "U3", "U4");
                }
            }
        public string PP {
            get {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                                       "PP", "UNIT_NO", "FEE_NAME", "BILL_ID", "BILL_DATE", "PRINCIPAL",
                                       "PENALTY", "AMOUNT_PAID", "BALANCE", "APP_PR", "APP_PEN", "P1");
                }
            }

        public Billings() { }


        public void StartCheck() {

         

                using (DataTable dt = GetBillings())    {
                    if (dt.Rows.Count == 0) {
                        return;
                        }
                    using (StreamWriter txt = new StreamWriter(FolderPath + "\\" + FileName + ".csv")) {
                        txt.WriteLine(FP);
                        txt.WriteLine(UP);
                        txt.WriteLine(PP);
                       
                    foreach (DataRow dr in dt.Select("", "unit_sort,fee_name,bill_date")) {

                        string billid = dr["bill_id"].ToString();
                        DateTime billdate = Convert.ToDateTime(dr["bill_date"]);
                        string feename = dr["fee_name"].ToString();
                        decimal principal = Convert.ToDecimal(dr["amount_due"]);
                        decimal penalty = Convert.ToDecimal(dr["penalty_amt"]);
                        decimal balance = Convert.ToDecimal(dr["balance"]);
                        decimal amountpaid = Convert.ToDecimal(dr["amount_paid"]);
                        string billstatus = dr["bill_status"].ToString();
                        string unitno = dr["unit_no"].ToString();
                        bool withvat = dr["w_vat"].ToString() == "Y" ? true : false;
                        decimal prApplied = Convert.ToDecimal(dr["principalapplied"]);
                        decimal pnApplied = Convert.ToDecimal(dr["penaltyapplied"]);

                        switch (billstatus) {

                            case "F":
                                //Check if amount_due + penalty_amt = amount_paid
                                bool f1 = ((principal + penalty) != amountpaid) ? true : false;
                                //Balance must be zero for Paid Invoices
                                bool f2 = (balance != 0) ? true : false;
                                //Principal amount due must be equal to applied payment for principal
                                bool f3 = (principal != prApplied) ? true : false;
                                //Penalty due must be equal to applied payment for penalty
                                bool f4 = (penalty != pnApplied) ? true : false;

                                if (f1||f2||f3||f4) {
                                    txt.WriteLine(String.Format("{0},{1},{2},\'{3},{4:MM/dd/yy},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                    "FP", unitno, feename, billid, billdate.Date , principal, penalty,
                                    amountpaid,balance,prApplied, pnApplied,f1,f2,f3,f4));
                                    }

                                    break;
                            case "U":
                                //Check if amount_due + penalty_amt = balance
                                bool u1 = ((principal + penalty) != balance) ? true : false;
                                //Amount paid must be zero for Unpaid Invoices
                                bool u2 = (amountpaid != 0) ? true : false;
                                //There must be no application on principal, must be zero
                                bool u3 = (prApplied != 0) ? true : false;
                                //There must be no application on penalty, must be zero
                                bool u4 = (pnApplied != 0) ? true : false;

                                if (u1 || u2 || u3 || u4) {
                                    txt.WriteLine(String.Format("{0},{1},{2},\'{3},{4:MM/dd/yy},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                    "UP", unitno, feename, billid, billdate, principal, penalty,
                                    amountpaid, balance, prApplied, pnApplied, u1, u2, u3, u4));
                                    }

                                    break;
                            case "P":
                                //Check if (amount_due + penalty_amt) less amount paid is equal to balance
                                bool p1 = (((principal + penalty) - amountpaid) != balance) ? true : false;

                                if (p1) {
                                    txt.WriteLine(String.Format("{0},{1},{2},\'{3},{4:MM/dd/yy},{5},{6},{7},{8},{9},{10},{11}",
                                    "PP", unitno, feename, billid, billdate, principal, penalty,
                                    amountpaid, balance, prApplied, pnApplied, p1));
                                    }

                                    break;
                                        
                            default : continue;
 
                            }
                                    
                          
                        }
                    }
                
                
                }
          
            
            }

        private DataTable GetBillings() {

            string query;

            query = "SELECT bill_id, bill_date, bill_fee_type,                                      " +
                    "       (SELECT fee_description                                                 " +
                    "          FROM ref_fee_types                                                   " +
                    "         WHERE fee_type_id = bc.bill_fee_type) fee_name, amount_due,           " +
                    "       penalty_amt, amount_paid, balance, bill_status, bill_cust_id,           " +
                    "       (SELECT cust_unit_no                                                    " +
                    "          FROM customer_accounts                                               " +
                    "         WHERE account_id = bc.bill_cust_id) unit_no,                          " +
                    "       (SELECT cust_unit_sort                                                  " +
                    "          FROM customer_accounts                                               " +
                    "         WHERE account_id = bc.bill_cust_id) unit_sort, w_vat,                 " +
                    "       (SELECT NVL (SUM (applied_amt), 0)                                      " +
                    "          FROM pay_transactions ps                                             " +
                    "         WHERE bill_id = bc.bill_id                                            " +
                    "           AND (SELECT or_status                                               " +
                    "                  FROM payments                                                " +
                    "                 WHERE payment_id = ps.payment_id) = 'ISSD') principalapplied, " +
                    "       (SELECT NVL (SUM (penalty_amt), 0)                                      " +
                    "          FROM pay_transactions ps                                             " +
                    "         WHERE bill_id = bc.bill_id                                            " +
                    "           AND (SELECT or_status                                               " +
                    "                  FROM payments                                                " +
                    "                 WHERE payment_id = ps.payment_id) = 'ISSD') penaltyapplied    " +
                    "  FROM billing_charges bc                                                      " +
                    " WHERE bill_date BETWEEN :fromdate AND :todate                                 ";


            using (OraParameter param = new OraParameter()) {
                param.AddParameter("fromdate", InvoiceFromDate, OracleDbType.Date, ParameterDirection.Input, false);
                param.AddParameter("todate", InvoiceToDate, OracleDbType.Date, ParameterDirection.Input, false);

                return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
                }

            }

        }
    }
