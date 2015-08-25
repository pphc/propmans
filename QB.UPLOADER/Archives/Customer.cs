using System;
using System.Collections.Generic;
using System.Text;
using Interop.QBFC12;
using System.Data;
using DALC;
using Oracle.DataAccess.Client;
using System.IO;


namespace QBooksUploader
    {
    public class Customer  

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

        public string UploadResultHeader {
            get {
                return String.Format("{0},{1},{2}",
                                        "UNIT_NO","QB_ACCT_NAME");
                }
            }

        public Customer() { }

        public void UploadCustomer() { 
            
                 using (DataTable dt = GetCustomers())
                    {
                     if (dt.Rows.Count == 0) {
                         UploadCount = 0;
                         return;
                         }
                     using (QBConnection qbc = new QBConnection()) {
                        foreach (DataRow dr in  dt.Rows)
                            {
                                 ICustomerAdd custAdd = qbc.RequestSet.AppendCustomerAddRq();

                                 string accountID = dr["account_id"].ToString();
                                 string unitnumber = dr["cust_unit_no"].ToString().Trim();
                                 string lastname = dr["last_name"].ToString().Trim();
                                 string firstname = dr["first_name"].ToString().Trim();
                                 string middlename = dr["middle_name"].ToString().Trim();
                                 string accountname = unitnumber + "-" + lastname + ", " + firstname;
                                 bool  isActive =  dr["account_status"].ToString() == "ACT" ? true : false;

                                 if (!(string.IsNullOrEmpty(middlename))) {
                                     custAdd.MiddleName.SetValue(middlename.Substring(0, 1));
                                     accountname = accountname + " "+ middlename.Substring(0, 1) + ".";
                                     }
                                 //custAdd.CompanyName.SetValue(
                                 
                                 //concat accountname if length exceeds 41
                                 if (accountname.Length > 41) { 
                                       custAdd.Name.SetValue(accountname.Remove(41,accountname.Length-41));
                                     }
                                     else {
                                       custAdd.Name.SetValue(accountname);
                                     }
                                 if (lastname.Length > 25) {
                                     custAdd.LastName.SetValue(lastname.Remove(25, lastname.Length - 25));
                                     }
                                 else {
                                     custAdd.LastName.SetValue(lastname);
                                     }

                                 if (firstname.Length > 25) {
                                     custAdd.FirstName.SetValue(firstname.Remove(25, firstname.Length - 25));
                                     }
                                 else {
                                     custAdd.FirstName.SetValue(firstname);
                                     }

                                 custAdd.IsActive.SetValue(isActive);
                             }
                         qbc.PerformRequest();

                         for (int i = 0; i < qbc.ResponseList.Count; i++) {
                             IResponse response = qbc.ResponseList.GetAt(i);
                             //check the status code of the response, 0=ok, >0 is warning
                             if (response.StatusCode == 0) {
                                 ICustomerRet CustomerRet = (ICustomerRet)response.Detail;
                                 string listID = (string)CustomerRet.ListID.GetValue();
                                 UpdateListID(dt.Rows[i]["account_id"].ToString(), listID);
                                 }
                             }
                          }
                 }
            }



        public void LogUploadtoFile(IResponseList responseList, DataTable dt) {
            using (StreamWriter txt = new StreamWriter(FolderPath + "\\account_upload.csv")) {
                txt.WriteLine(UploadResultHeader);
                for (int i = 0; i < responseList.Count; i++) {
                    IResponse response = responseList.GetAt(i);
                     //check the status code of the response, 0=ok, >0 is warning
                     if (response.StatusCode == 0) {
                         ICustomerRet CustomerRet = (ICustomerRet)response.Detail;
                         string accntName = CustomerRet.Name.GetValue();
                         txt.WriteLine(String.Format("{0},\"{1}\"",dt.Rows[i]["cust_unit_no"].ToString(),
                                                accntName));     
                         }
                     else {
                         txt.WriteLine(String.Format("{0},{1},{2}", dt.Rows[i]["cust_unit_no"].ToString(),
                                               response.StatusCode.ToString(), response.StatusMessage));  
                         
                         }
                     }

                }
            
            }

        private DataTable GetCustomers() {

            string query;

            //query = "SELECT  ACCOUNT_ID, cust_unit_no, (SELECT cust_lname                           " +
            //    "                          FROM customers                            " +
            //    "                         WHERE cust_id = cs.acct_cust_id) last_name," +
            //    "         (SELECT cust_fname                                         " +
            //    "            FROM customers                                          " +
            //    "           WHERE cust_id = cs.acct_cust_id) first_name,             " +
            //    "         (SELECT cust_mname                                         " +
            //    "            FROM customers                                          " +
            //    "           WHERE cust_id = cs.acct_cust_id) middle_name             " +
            //    "    FROM customer_accounts cs                                       " +
            //    "   WHERE account_class = 'CONDO' AND account_status = 'ACT'         " +
            //    "         AND qb_listid is null                                      " +
            //    "ORDER BY cust_unit_sort                                             ";

            query = "SELECT  ACCOUNT_ID, cust_unit_no, (SELECT cust_lname                           " +
              "                          FROM customers                            " +
              "                         WHERE cust_id = cs.acct_cust_id) last_name," +
              "         (SELECT cust_fname                                         " +
              "            FROM customers                                          " +
              "           WHERE cust_id = cs.acct_cust_id) first_name,             " +
              "         (SELECT cust_mname                                         " +
              "            FROM customers                                          " +
              "           WHERE cust_id = cs.acct_cust_id) middle_name,account_status " +
              "    FROM customer_accounts cs                                       " +
              "   WHERE  qb_listid is null                                      " +
              "ORDER BY cust_unit_sort                                             ";


            return OraDBHelper2.GetResultSet(query);
            
            }

        private void UpdateListID(string accountID,string listID) {
            string query;

            query = "UPDATE customer_accounts       " +
                    "   SET qb_listid = :listid     " +
                    " WHERE account_id = :accountid ";
            using (OraParameter param = new OraParameter()){
                param.AddParameter("listid",listID,OracleDbType.Varchar2,ParameterDirection.Input,false);
                param.AddParameter("accountID", accountID, OracleDbType.Int32, ParameterDirection.Input, false);

               UploadCount += OraDBHelper2.SqlExecute(query, param.GetParameterCollection());
                }
         
            }
        }
    }
