using System;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using DALC;
using Oracle.DataAccess.Client;
using ZetaCompressionLibrary;
using BCL.Common;
using Interop.QBFC12;

namespace QBooksUploader
    {
    public static class QBUploadHelper
        {

        
        private static string FolderPath;

        private static string UploadFileName {
            get { return "QBUPLOAD_"+DateTime.Now.ToString("yyMMdd24hhmm"); }
            }
        private static string TempFolderPath {
            get { return FolderPath + "\\" + "TEMP"; }
            }
        

        private static Boolean UploadSuccess;

        public static Boolean StartUpload(string folderPath) {
            UploadSuccess = false;

            FolderPath =folderPath;

            Directory.CreateDirectory(TempFolderPath);

            int cust_cnt;
            int inv_cnt;
            int pay_cnt;
            int pay_deposit_start=0;
            int pay_deposit_end=0;


            //Upload New Customer Accounts to Quickbooks
            Customer cust = new Customer();
            cust.FolderPath = TempFolderPath;
            cust.UploadCustomer();
            cust_cnt = cust.UploadCount;

            //Upload New Customer Invoices to Quickbooks
            //Invoice inv = new Invoice();
            //inv.FolderPath = TempFolderPath;
            //inv.UploadInvoices();
            //inv_cnt = inv.UploadCount;

            ////Upload New Customer Payments to Quickbooks
            //Payment pay = new Payment();
            //pay.FolderPath = TempFolderPath;
            //pay.UploadPayments();
            //pay_cnt = pay.UploadCount;
            //if (pay_cnt > 0) { 
            //    pay_deposit_start = pay.NextDepositID;
            //    pay_deposit_end = pay.LastDepositID;
            //    }

            //if (!((cust_cnt == 0) && (inv_cnt == 0) && (pay_cnt == 0))) {
            //    UploadSuccess = true;
            //    SaveUploadLog(cust_cnt, inv_cnt, pay_cnt, pay_deposit_start, pay_deposit_end);
            //    CompressFiles();
            //    }

            Directory.Delete(TempFolderPath,true);

            return UploadSuccess;

        }

        public static Boolean StartUpload(string folderPath, DateTime invoiceFromdate, DateTime invoiceTodate, DateTime payFromdate, DateTime payTodate) {
            UploadSuccess = false;

            FolderPath = folderPath;

            int cust_cnt;
            int inv_cnt;
            int pay_cnt;
            int pay_deposit_start = 0;
            int pay_deposit_end = 0;

            Directory.CreateDirectory(TempFolderPath);

            //Upload New Customer Accounts to Quickbooks
            Customer cust = new Customer();
            cust.FolderPath = TempFolderPath;
            cust.UploadCustomer();
            cust_cnt = cust.UploadCount;

            //Upload New Customer Invoices to Quickbooks
            Invoice inv = new Invoice();
            inv.FolderPath = TempFolderPath;
            inv.InvoiceFromDate = new DateTime(invoiceFromdate.Year ,invoiceFromdate.Month ,1).Date;
            inv.InvoiceToDate = new DateTime(invoiceTodate.Year, invoiceTodate.Month, DateTime.DaysInMonth(invoiceTodate.Year, invoiceTodate.Month)).Date;
            inv.UploadInvoices();
            inv_cnt = inv.UploadCount;

            //Upload New Customer Payments to Quickbooks
            Payment pay = new Payment();
            pay.UploadPayments();
            pay_cnt = pay.UploadCount;
            if (pay_cnt > 0) {
                }

            if (!((cust_cnt == 0) && (inv_cnt == 0) && (pay_cnt == 0))) {
                UploadSuccess = true;
                SaveUploadLog(cust_cnt, inv_cnt, pay_cnt, pay_deposit_start, pay_deposit_end);
                CompressFiles();
                }

            Directory.Delete(TempFolderPath, true);
            return UploadSuccess;

            }
        
        public static Boolean ExportAccounts(string folderPath) {
            UploadSuccess = false;

            FolderPath = folderPath;

            ChartAccounts ch = new ChartAccounts();
            ch.FolderPath = FolderPath;

            ch.ExportChartAccounts();
            ch.ExportItemLists();
            ch.ExportCustomerAccounts();


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
        
        private static int SaveUploadLog(int cust_cnt,
                                        int inv_cnt,
                                        int pay_cnt,
                                        int pay_deposit_start,
                                        int pay_deposit_end) {
            string query;

            query = "INSERT INTO qb_upload                                               " +
                  "            (cust_acct_update_cnt, inv_update_cnt, pay_update_cnt,  " +
                  "             pay_dep_from, pay_dep_to                               " +
                  "            )                                                       " +
                  "     VALUES (:cust_cnt, :inv_cnt, :pay_cnt,                         " +
                  "             :pay_dep_frm, :pay_dep_to                              " +
                  "            )                                                       ";

            using (OraParameter param = new OraParameter()) {
                param.AddParameter("cust_cnt", cust_cnt, OracleDbType.Int32, ParameterDirection.Input, false);
                param.AddParameter("inv_cnt", inv_cnt, OracleDbType.Int32, ParameterDirection.Input, false);
                param.AddParameter("pay_cnt", pay_cnt, OracleDbType.Int32, ParameterDirection.Input, false);
                param.AddParameter("pay_dep_frm", pay_deposit_start, OracleDbType.Int32, ParameterDirection.Input, false);
                param.AddParameter("pay_dep_to", pay_deposit_end, OracleDbType.Int32, ParameterDirection.Input, false);

                return OraDBHelper2.SqlExecute(query, param.GetParameterCollection());
                }
          
            }

        private static void CompressFiles(){
             List<string> filepaths = new List<string>();

             foreach (string filepath in Directory.GetFiles(TempFolderPath)) {
                 filepaths.Add(filepath);
                 }
             byte[] buffer = CompressionHelper.CompressFiles(filepaths.ToArray());

             using (FileStream fs = File.Create(string.Format("{0}\\{1}.zip", FolderPath, UploadFileName))) {
                 fs.Write(buffer,0,buffer.Length);
                 }


             }

        }

    }
