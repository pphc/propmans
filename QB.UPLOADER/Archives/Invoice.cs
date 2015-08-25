using System;
using System.Collections.Generic;
using System.Text;
using DALC;
using System.Data;
using System.IO;
using Oracle.DataAccess.Client;
using BCL.Common;
using Interop.QBFC12;

namespace QBooksUploader
    {
    public class Invoice 
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

        public string UploadResultHeader {
            get { return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                          "UNIT_NO","BILL_REF", "FEE_TYPE", "QB_ACCT_NAME", "INV_NO",
                                          "INV_DATE", "INV_DUE", "AR_ACCOUNT", "LINE_MATCH"); }
            }

        public string DetailsResultHeader {
            get {
                return String.Format("{0},{1},{2},{3},{4},{5}",
                                        "UNIT_NO", "INV_NO", "FEE_TYPE", "ITEM_NAME", "ITEM_DESC","LINE_AMT");
                }
            }

        public Invoice() {
        }

        public void UploadInvoices() {

            using (DataTable dt = GetInvoices2()) {
                 if (dt.Rows.Count == 0) {
                    UploadCount = 0;
                    return;
                    }
                using (QBConnection qbc = new QBConnection()) {
                    foreach (DataRow dr in  dt.Rows)
                        {

                       IInvoiceAdd invoiceAdd = qbc.RequestSet.AppendInvoiceAddRq();

                       invoiceAdd.CustomerRef.ListID.SetValue(dr["account_id"].ToString());

                       invoiceAdd.TxnDate.SetValue(DateTime.Parse(dr["bill_generate_date"].ToString()));

                       if (!Convert.IsDBNull(dr["bill_due_date"])) {
                           invoiceAdd.DueDate.SetValue(DateTime.Parse(dr["bill_due_date"].ToString()));
                           }

                       string invoiceNumber = GetInvoiceNumber(dr["bill_id"].ToString());
                       invoiceAdd.RefNumber.SetValue(invoiceNumber);

                       invoiceAdd.ARAccountRef.ListID.SetValue(dr["ar_account"].ToString());

                       string  invoiceMonth = DateTime.Parse(dr["bill_date"].ToString()).ToString("MMMM yyyy");
                       invoiceAdd.Memo.SetValue(dr["fee_type_name"].ToString() + " " + invoiceMonth);
                     
                       Boolean withVat = dr["w_vat"].ToString().Trim() == "Y" ? true : false;

                       decimal amountdue = decimal.Parse(dr["amount_due"].ToString());
                       decimal penalty = decimal.Parse(dr["penalty_amt"].ToString());

                           IInvoiceLineAdd invoiceLineAdd;

                           if (withVat) {
                               decimal vatable;
                               decimal vat = 1.12M;

                               vatable = decimal.Round(amountdue / vat, 2);

                               invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                               invoiceLineAdd.ItemRef.ListID.SetValue(dr["item_list"].ToString());

                               if (Convert.IsDBNull(dr["desc_format"])) {
                                   invoiceLineAdd.Desc.SetValue(dr["fee_type_name"].ToString());
                                   }
                               else {
                                   string billMonth = DateTime.Parse(dr["bill_date"].ToString()).ToString("MMMM yyyy");
                                   invoiceLineAdd.Desc.SetValue(dr["desc_format"].ToString().Replace("X", billMonth));
                                   }
                               invoiceLineAdd.Amount.SetValue(Convert.ToDouble(vatable));

                               invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                               invoiceLineAdd.ItemRef.ListID.SetValue(dr["vat_account"].ToString());
                               invoiceLineAdd.Desc.SetValue("Output Vat " + dr["fee_type_name"].ToString());
                               invoiceLineAdd.Amount.SetValue(Convert.ToDouble(amountdue - vatable));
                               }
                           else {

                               invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                               invoiceLineAdd.ItemRef.ListID.SetValue(dr["item_list"].ToString());
                               if (Convert.IsDBNull(dr["desc_format"])) {
                                   invoiceLineAdd.Desc.SetValue(dr["fee_type_name"].ToString());
                                   }
                               else {
                                   string billMonth = DateTime.Parse(dr["bill_date"].ToString()).ToString("MMMM yyyy");
                                   invoiceLineAdd.Desc.SetValue(dr["desc_format"].ToString().Replace("X", billMonth));
                                   }
                               invoiceLineAdd.Amount.SetValue(Convert.ToDouble(amountdue));
                               }
                   

                           if (penalty > 0) {
                               Boolean UploadPenalty = dr["bill_status"].ToString() != "U" ? true : false;
                               if (UploadPenalty) {
                                   string billMonth = DateTime.Parse(dr["bill_date"].ToString()).ToString("MMMM yyyy");
                                   invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                                   invoiceLineAdd.ItemRef.ListID.SetValue("");
                                   invoiceLineAdd.Desc.SetValue(dr["fee_type_name"].ToString() + " Penalty " + billMonth);
                                   invoiceLineAdd.Amount.SetValue(Convert.ToDouble(penalty)); 
                                   }
                               }
                          }
                      System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                      s.Start();
                     
                      qbc.PerformRequest();

                      s.Stop();

                      long x = s.ElapsedMilliseconds;
                
                      //Update propmans txnid  from quickbooks.
                      for (int i = 0; i < qbc.ResponseList.Count; i++) {
                          IResponse response = qbc.ResponseList.GetAt(i);
                          //check the status code of the response, 0=ok, >0 is warning
                          if (response.StatusCode == 0) {
                              IInvoiceRet invoiceRet = (IInvoiceRet)response.Detail;
                              string txnTrail;
                              if (Decimal.Parse(dt.Rows[i]["penalty_amt"].ToString()) > 0) {
                                  txnTrail = dt.Rows[i]["bill_status"].ToString() != "U" ? "Y" : "N";
                                  }
                              else {
                                  txnTrail = "NA";
                                  }
                             
                              string txnID = (string)invoiceRet.TxnID.GetValue() + "," + txnTrail;

                              UpdateListID(dt.Rows[i]["bill_id"].ToString(), txnID);
                              }
                          }

                      LogUploadtoFile(qbc.ResponseList, dt);
                    }
                    
                   }
               
                }

        //public void UploadBeginningBalance() {

        //    using (DataTable dt = GetBeginningBalance()) {
        //        if (dt.Rows.Count == 0) {
        //            UploadCount = 0;
        //            return;
        //            }
        //        using (QBConnection qbc = new QBConnection()) {
        //            foreach (DataRow dr in dt.Rows) {

        //                IInvoiceAdd invoiceAdd = qbc.RequestSet.AppendInvoiceAddRq();

        //                invoiceAdd.CustomerRef.ListID.SetValue(dr["account_id"].ToString());

        //                invoiceAdd.TxnDate.SetValue(BeginingBalanceCutOff);


        //                //string invoiceNumber = GetInvoiceNumber(dr["bill_id"].ToString());
        //               // invoiceAdd.RefNumber.SetValue(invoiceNumber);

        //                invoiceAdd.ARAccountRef.ListID.SetValue(dr["ar_account"].ToString());

        //                string balancememo = "Condo Dues as of " + BeginingBalanceCutOff.ToString("MMM dd, yyyy");
        //                invoiceAdd.Memo.SetValue(balancememo);


        //                decimal amountdue = decimal.Parse(dr["amount_due"].ToString());

        //                IInvoiceLineAdd invoiceLineAdd;

        //                invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
        //                invoiceLineAdd.ItemRef.ListID.SetValue(dr["item_list"].ToString());

        //                invoiceLineAdd.Desc.SetValue(balancememo);

        //                invoiceLineAdd.Amount.SetValue(Convert.ToDouble(amountdue));

        //                }
        //            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
        //            s.Start();

        //            qbc.PerformRequest();

        //            s.Stop();

        //            long x = s.ElapsedMilliseconds;

        //            //LogUploadtoFile(qbc.ResponseList, dt);
        //            }

        //        }

        //    }

        private void UpdateListID(string billID, string txnID) {

            string query;

            query = "UPDATE BILLING_CHARGES      " +
                    "   SET qb_txn_id = :txnid    " +
                    " WHERE bill_id = :billid ";
            using (OraParameter param = new OraParameter()) {
                param.AddParameter("txnid", txnID, OracleDbType.Varchar2, ParameterDirection.Input, false);
                param.AddParameter("billid", billID, OracleDbType.Varchar2, ParameterDirection.Input, false);

                UploadCount += OraDBHelper2.SqlExecute(query, param.GetParameterCollection());
                }
            }

        public void LogUploadtoFile(IResponseList responseList,DataTable dt) {
            using (StreamWriter txt = new StreamWriter(FolderPath + "\\invoice_upload.csv")) {
                using (StreamWriter txtDetails = new StreamWriter(FolderPath + "\\invoice_details_upload.csv")) {
                    txt.WriteLine(UploadResultHeader);
                    txtDetails.WriteLine(DetailsResultHeader);

                    for (int i = 0; i < responseList.Count; i++) {
                        DataRow dr = dt.Rows[i];
                        string billid = dr["bill_id"].ToString();
                        string billdate = DateTime.Parse(dr["bill_date"].ToString()).ToShortDateString();
                        string billgeneratedate = DateTime.Parse(dr["bill_generate_date"].ToString()).ToShortDateString();
                        string billduedate = String.Empty;
                        if (!(Convert.IsDBNull(dr["bill_due_date"]))) {
                            billduedate = DateTime.Parse(dr["bill_due_date"].ToString()).ToShortDateString();
                            }


                        double totalAmountdue = Double.Parse(dr["amount_due"].ToString()) + Double.Parse(dr["penalty_amt"].ToString());
                        if (dr["bill_status"].ToString() == "U") {
                            totalAmountdue = Double.Parse(dr["amount_due"].ToString());
                            }
                        else {
                            totalAmountdue = Double.Parse(dr["amount_due"].ToString()) + Double.Parse(dr["penalty_amt"].ToString());
                            }
                        string feetype = dr["fee_type_name"].ToString();
                        string custUnitNo = dr["unit_no"].ToString();

                        IResponse response = responseList.GetAt(i);
                        //check the status code of the response, 0=ok, >0 is warning
                        if (response.StatusCode == 0) {
                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                            IInvoiceRet InvoiceRet = response.Detail as IInvoiceRet;
                            string txnID = InvoiceRet.TxnID.GetValue();
                            string custname = InvoiceRet.CustomerRef.FullName.GetValue();
                            string refnum = InvoiceRet.RefNumber.GetValue();
                            string txnDate = InvoiceRet.TxnDate.GetValue().ToShortDateString();
                            string dueDate = InvoiceRet.DueDate.GetValue().ToShortDateString();
                            string araccount = InvoiceRet.ARAccountRef.FullName.GetValue();

                            IORInvoiceLineRetList InvoiceLineRetList = InvoiceRet.ORInvoiceLineRetList;
                            double uploadAmount=0;
                            for (int idx = 0; idx < InvoiceLineRetList.Count; idx++) {
                                string lineid = InvoiceRet.ORInvoiceLineRetList.GetAt(idx).InvoiceLineRet.TxnLineID.GetValue();
                                string itemname = InvoiceRet.ORInvoiceLineRetList.GetAt(idx).InvoiceLineRet.ItemRef.FullName.GetValue();
                                string itemdesc = InvoiceRet.ORInvoiceLineRetList.GetAt(idx).InvoiceLineRet.Desc.GetValue();
                                double amount = InvoiceRet.ORInvoiceLineRetList.GetAt(idx).InvoiceLineRet.Amount.GetValue();

                                uploadAmount += amount;

                                txtDetails.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",{3},{4},{5}",
                                            custUnitNo, refnum,feetype, itemname, itemdesc, amount));
                                }

                            Boolean amountTally = (totalAmountdue == uploadAmount);

                            txt.WriteLine(String.Format("{0},\"{1}\",\"{2}\",\"{3}\",{4},{5},{6},{7},{8}",custUnitNo, billid, feetype,
                                           custname, refnum, txnDate,dueDate,araccount,amountTally.ToString()));
                            }
                        else {
                            txt.WriteLine(String.Format("{0},{1},{2},{3},{4}",custUnitNo, billid, feetype,
                                                         response.StatusCode.ToString(), response.StatusMessage));
                            }
                      }
                   }
                 }
              }

        public DataTable GetInvoices() { 
            
            //using (OraParameter param = new OraParameter())
            //    {
               
                
            //    }

            string query;

            query = "SELECT (SELECT cust_unit_no                                           " +
                    "          FROM customer_accounts                                      " +
                    "         WHERE account_id = bc.bill_cust_id) unit_no, bill_id, bill_date," +
                    "       bill_generate_date, bill_due_date, amount_due, penalty_amt,bill_status,    " +
                    "       (SELECT qb_listid                                              " +
                    "          FROM customer_accounts                                      " +
                    "         WHERE account_id = bc.bill_cust_id) account_id, w_vat,       " +
                    "       (SELECT fee_description                                        " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) fee_type_name,         " +
                    "       (SELECT qb_ar_account                                          " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) ar_account,            " +
                    "       (SELECT qb_item_list_name                                      " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) item_list,             " +
                    "       (SELECT qb_desc_format                                         " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) desc_format,            " +
                    "       (SELECT qb_vat_account                                         " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) vat_account            " +
                    "  FROM billing_charges bc                                             " +
                    " WHERE qb_txn_id IS NULL                                              " +
                    "   AND bill_status <> 'C'                                             " +
                    "   AND bill_fee_type IN (SELECT fee_type_id                           " +
                    "                           FROM ref_fee_types                         " +
                    "                          WHERE qb_ar_account IS NOT NULL and fee_company ='C')            ";

            return OraDBHelper2.GetResultSet(query);

            }
        
        public DataTable GetInvoices2() {

            //using (OraParameter param = new OraParameter())
            //    {


            //    }

            string query;

            query = "SELECT (SELECT cust_unit_no                                           " +
                    "          FROM customer_accounts                                      " +
                    "         WHERE account_id = bc.bill_cust_id) unit_no, bill_id, bill_date," +
                    "       bill_generate_date, bill_due_date, amount_due, penalty_amt,bill_status,    " +
                    "       (SELECT qb_listid                                              " +
                    "          FROM customer_accounts                                      " +
                    "         WHERE account_id = bc.bill_cust_id) account_id, w_vat,       " +
                    "       (SELECT fee_description                                        " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) fee_type_name,         " +
                    "       (SELECT qb_ar_account                                          " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) ar_account,            " +
                    "       (SELECT qb_item_list_name                                      " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) item_list,             " +
                    "       (SELECT qb_desc_format                                         " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) desc_format,           " +
                    "       (SELECT qb_vat_account                                         " +
                    "          FROM ref_fee_types                                          " +
                    "         WHERE fee_type_id = bc.bill_fee_type) vat_account            " +
                    "  FROM billing_charges bc                                             " +
                    " WHERE qb_txn_id IS NULL                                              " +
                    "   AND bill_status <> 'C'                                             " +
                    "   AND bill_fee_type IN (SELECT fee_type_id                           " +
                    "                           FROM ref_fee_types                         " +
                    "                          WHERE qb_ar_account IS NOT NULL and fee_company ='C')            " +
                    "AND BILL_DATE between  :fromdate AND :todate ";

            using (OraParameter param = new OraParameter()) {
                param.AddParameter("fromdate", InvoiceFromDate, OracleDbType.Date, ParameterDirection.Input, false);
                param.AddParameter("todate", InvoiceToDate, OracleDbType.Date, ParameterDirection.Input, false);

                return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
                }


            }

        //public DataTable GetBeginningBalance() {
        //    string query;

        //    query = "";

        //    return OraDBHelper2.GetResultSet(query);
        //    }

        public string GetInvoiceTxnID(string billid) {
            string invoiceNumber = GetInvoiceNumber(billid);
            string transID = String.Empty;

            using (QBConnection qbc = new QBConnection()) {
                IInvoiceQuery invoiceQuery = qbc.RequestSet.AppendInvoiceQueryRq();

                invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(invoiceNumber);

                qbc.PerformRequest();

                qbc.Response = qbc.ResponseList.GetAt(0);
                    if (qbc.Response.StatusCode == 0) {
                        if (qbc.Response.Detail != null) {
                            //make sure the response is the type we're expecting
                            ENResponseType responseType = (ENResponseType)qbc.Response.Type.GetValue();
                            if (responseType == ENResponseType.rtInvoiceQueryRs) {
                                //upcast to more specific type here, this is safe because we checked with response.Type check above
                                IInvoiceRetList InvoiceRet = (IInvoiceRetList)qbc.Response.Detail;

                                 transID= (string)InvoiceRet.GetAt(0).TxnID.GetValue();
                                }
                            }
                        }
                }
            return transID;
            }

        public string GetInvoiceNumber(string billID){
            string id;
            int yearPart = int.Parse(billID.Substring(2, 2));
            int monthPart = int.Parse(billID.Substring(4, 2));
            int datePart = int.Parse(billID.Substring(6, 2));
            int hourPart = int.Parse(billID.Substring(8, 2));
            string lastPart = billID.Substring(10).ToString();

            id = GetCharRep(yearPart) + GetCharRep(monthPart) + GetCharRep(datePart) + GetCharRep(hourPart) + lastPart;
            if (id.Length > 11) {
                id = id.Substring(0, 8) + id.Substring(11, 3);
                }

            
            return id;
          }

        private char GetCharRep(int code) { 
            int cbase =64;
            char result;
            if ((cbase + code)< 91){
                result = Convert.ToChar(cbase + code);
                }
                else{
                result = Convert.ToChar(cbase + code+6);
                }
            return result;
            }

        }
    }

  