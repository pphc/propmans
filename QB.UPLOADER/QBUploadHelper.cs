using BCL.Common;
using DALC;
using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace QBooksUploader
    {

    public enum ReferenceType{
        Invoice,
        Payment
    }

    public class QBUploadResult
    {
       public String RefID;
       public ReferenceType RefType;
       public String QBListID;
       public String ItemRemarks;
       public Boolean Uploaded;
       public String UploadError;
    }
    public static class QBUploadHelper
        {

       // private static string FolderPath;

        private static string UploadFileName
        {
            get { return "QBUPLOAD_" + DateTime.Now.ToString("yyMMdd24hhmm"); }
        }
        private static string TempFolderPath
        {
            get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + "TEMP"; }
        }

        private static Boolean UploadSuccess;

        public static Boolean StartUpload(DataTable Invoices,DataTable Payments) {
            UploadSuccess = false;

            int cust_cnt;
            int inv_cnt=0;
            int pay_cnt=0;

            List<QBUploadResult> invres = null;
            List<QBUploadResult> payres = null; 

            //Upload New Customer Accounts to Quickbooks
            Customer cust = new Customer();
            cust.UploadCustomer();
            cust_cnt = cust.UploadCount;

            if (Invoices != null) {
                if (Invoices.Rows.Count > 0)
                {
                    //Upload Customer Invoices to Quickbooks
                    Invoice inv = new Invoice();
                    inv.InvoicesDT = Invoices;
                    inv.UploadInvoices();
                    invres = inv.UploadResult;
                    inv_cnt = inv.UploadCount;
                }          
            }

            if (Payments != null){
                if (Payments.Rows.Count > 0)
                {
                    //Upload Customer Payments to Quickbooks
                    Payment pay = new Payment();
                    pay.PaymentsDT = Payments;
                    pay.UploadPayments();
                    payres = pay.UploadResult;
                    pay_cnt = pay.UploadCount;
                }
            }

            SaveUploadResults(invres, payres);

            if (!( (inv_cnt == 0) && (pay_cnt == 0)))
            {
                UploadSuccess = true;
            }

            return UploadSuccess;
        }

        public static Boolean ExportQBReferences() {
            UploadSuccess = false;

            QBReferences qbRef = new QBReferences();
            qbRef.FolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            qbRef.ExportChartAccounts();
            qbRef.ExportClass();
            qbRef.ExportItemLists();
            qbRef.ExportCustomerAccounts();


            UploadSuccess = true;

            return UploadSuccess;
            }

        public static DataTable GetQBUploads() {
            string query;

            query = "SELECT upload_id, cust_acct_update_cnt, inv_update_cnt, pay_update_cnt, " +
                "       pay_dep_from, pay_dep_to, created_by, created_on upload_date                 " +
                "  FROM qb_upload                                                        ";




                return OraDBHelper2.GetResultSet(query);
                
            }

        public static DataTable GetInvoices(DateTime startDate, DateTime endDate) {
            string query;

            query = "SELECT bill_id,                                                        " +
                    "  (SELECT qb_list_id                                                   " +
                    "  FROM qb_account_references                                           " +
                    "  WHERE account_id =bc.bill_cust_id                                    " +
                    "  ) list_id,                                                           " +
                    "  ACCOUNTS.GETUNITNUMBER(bc.bill_cust_id) unit_number,                 " +
                    "  ACCOUNTS.GETCUSTOMERFULLNAME_LFM(                                    " +
                    "  (SELECT acct_cust_id                                                 " +
                    "  FROM customer_accounts                                               " +
                    "  WHERE account_id = bc.bill_cust_id                                   " +
                    "  )) customer_name,                                                    " +
                    "  (SELECT ref_value                                                    " +
                    "  FROM qb_references                                                   " +
                    "  WHERE fee_type_id = bc.bill_fee_type                                 " +
                    "  AND ref_type      = 'AR_ACCOUNT'                                     " +
                    "  ) ar_item,                                                           " +
                    "  (SELECT ref_value                                                    " +
                    "  FROM qb_references                                                   " +
                    "  WHERE fee_type_id = bc.bill_fee_type                                 " +
                    "  AND ref_type      = 'ITEM_LIST'                                      " +
                    "  ) list_item,                                                         " +
                    "  (SELECT ref_value                                                    " +
                    "  FROM qb_references                                                   " +
                    "  WHERE fee_type_id = bc.bill_fee_type                                 " +
                    "  AND ref_type      = 'CLASS'                                          " +
                    "  ) class_name,                                                        " +
                    "  (SELECT INITCAP(fee_description)                                     " +
                    "  FROM ref_fee_types                                                   " +
                    "  WHERE fee_type_id = bc.bill_fee_type                                 " +
                    "  ) fee_name,                                                          " +
                    "  bill_date,                                                           " +
                    "  bill_generate_date,                                                  " +
                    "  bill_due_date,                                                       " +
                    "  amount_due,                                                          " +
                    "  w_vat                                                                " +
                    "FROM billing_charges bc                                                " +
                    "WHERE bill_fee_type IN                                                 " +
                    "  (SELECT fee_type_id FROM qb_references WHERE ref_type = 'AR_ACCOUNT' " +
                    "  )                                                                    " +
                    "AND bill_date BETWEEN :startDate AND :endDate                          " +
                    "AND bill_id NOT IN                                                     " +
                    "  (SELECT NVL(bill_id,0) FROM qb_upload_details WHERE uploaded ='Y'    " +
                    "  )                                                                    " +
                    "ORDER BY bill_date,                                                    " +
                    "  bill_fee_type,                                                       " +
                    "  (SELECT cust_unit_sort                                               " +
                    "  FROM customer_accounts                                               " +
                    "  WHERE account_id = BC.BILL_CUST_ID                                   " +
                    "  )                                                                    ";

                                                                                                                                               

            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("startdate", startDate, OracleDbType.Date , ParameterDirection.Input, false);
                param.AddParameter("enddate", endDate, OracleDbType.Date, ParameterDirection.Input, false);

                return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
            }
        
        }

        public static DataTable GetPayments(DateTime startDate, DateTime endDate)
        {
            string query;

            query = "SELECT payment_id,                                                           " +
                    "  (SELECT qb_list_id                                                         " +
                    "  FROM qb_account_references                                                 " +
                    "  WHERE account_id =ps.pay_acct_id                                           " +
                    "  ) list_id,                                                                 " +
                    "  or_number,                                                                 " +
                    "  payment_date,                                                              " +
                    "  (SELECT ref_value                                                          " +
                    "  FROM qb_references                                                         " +
                    "  WHERE fee_type_id = ps.pay_fee_type                                        " +
                    "  AND ref_type      = 'AR_ACCOUNT'                                           " +
                    "  ) AR_item,                                                                 " +
                    "  DECODE(PAY_CATEGORY,'ADV',                                                 " +
                    "  (SELECT ref_value                                                          " +
                    "  FROM qb_references                                                         " +
                    "  WHERE fee_type_id = ps.pay_fee_type                                        " +
                    "  AND ref_type      = 'ADVANCES'                                             " +
                    "  ),                                                                         " +
                    "  (SELECT ref_value                                                          " +
                    "  FROM qb_references                                                         " +
                    "  WHERE fee_type_id = ps.pay_fee_type                                        " +
                    "  AND ref_type      = 'ITEM_LIST'                                            " +
                    "  )) LIST_item,                                                              " +
                    "  (SELECT ref_value                                                          " +
                    "  FROM qb_references                                                         " +
                    "  WHERE fee_type_id = ps.pay_fee_type                                        " +
                    "  AND ref_type      = 'CLASS'                                                " +
                    "  ) class_name,                                                              " +
                    "  DECODE(                                                                    " +
                    "  (SELECT billing_type FROM ref_fee_types WHERE fee_type_id = ps.pay_fee_type" +
                    "  ),'I','ONE TIME','RECURRING') UPLOAD_TYPE,                                 " +
                    "  (SELECT INITCAP(fee_description)                                           " +
                    "  FROM ref_fee_types                                                         " +
                    "  WHERE fee_type_id = ps.pay_fee_type                                        " +
                    "  ) fee_name ,                                                               " +
                    "  pay_category,                                                              " +
                    "  payment_type,                                                              " +
                    "  paid_amount                                                                " +
                    "FROM payments ps                                                             " +
                    "WHERE pay_fee_type IN                                                        " +
                    "  (SELECT fee_type_id FROM qb_references WHERE ref_type = 'ITEM_LIST'        " +
                    "  )                                                                          " +
                    "AND or_status     ='ISSD'                                                    " +
                    "AND PAYMENT_TYPE <>'CM'                                                      " +
                    "AND PAYMENT_DATE BETWEEN :STARTDATE AND :ENDDATE                             ";
                 
            if (GlobalReference.ProjectParameters.QBPaymentsTag) {

                query += "AND pay_deposit_id IS NOT NULL                                               ";
            }

            query += "AND payment_id NOT IN                                                        " +
                    "  (SELECT NVL(payment_id,0) FROM qb_upload_details WHERE uploaded='Y'        " +
                    "  )                                                                          " +
                    "ORDER BY payment_date,                                                       " +
                    "  or_number                                                                  ";

            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("startdate", startDate, OracleDbType.Date, ParameterDirection.Input, false);
                param.AddParameter("enddate", endDate, OracleDbType.Date, ParameterDirection.Input, false);

                return OraDBHelper2.GetResultSet(query, param.GetParameterCollection());
            }

        }


        private static void SaveUploadResults(List<QBUploadResult> Invoices, List<QBUploadResult> Payments ) {

        ArrayList billID = new ArrayList();
        ArrayList paymentID = new ArrayList();
        ArrayList qblistID = new ArrayList();
        ArrayList itemRemarks = new ArrayList();
        ArrayList uploaded = new ArrayList();
        ArrayList uploadError = new ArrayList();


        if (Invoices != null)
        {
            foreach (QBUploadResult res in Invoices)
            {
                billID.Add(res.RefID);
                paymentID.Add(String.Empty);
                qblistID.Add(res.QBListID);
                itemRemarks.Add(string.Empty);
                uploaded.Add(res.Uploaded == true ? "Y" : "N");
                uploadError.Add(res.UploadError);
            }
        }


        if (Payments != null){
            foreach (QBUploadResult res in Payments)
            {
                billID.Add(String.Empty);
                paymentID.Add(res.RefID);
                qblistID.Add(res.QBListID);
                itemRemarks.Add(string.Empty);
                uploaded.Add(res.Uploaded == true ? "Y" : "N");
                uploadError.Add(res.UploadError);
            }
        }

        using (OraParameter param = new OraParameter())
        {
            param.AddParameter("billid", (string[])billID.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);
            param.AddParameter("paymentid", (string[])paymentID.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);
            param.AddParameter("qblistid", (string[])qblistID.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);
            param.AddParameter("itemremarks", (string[])itemRemarks.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);
            param.AddParameter("uploaded", (string[])uploaded.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);
            param.AddParameter("uploaderror", (string[])uploadError.ToArray(typeof(string)), OracleDbType.Varchar2, ParameterDirection.Input, true, billID.Count);

            OraDBHelper2.ExecuteProcedureforInput("QB.insertuploadresults", param.GetParameterCollection());
        }

        }

        }

    }
