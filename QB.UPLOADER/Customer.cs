using DALC;
using Interop.QBFC12;
using Oracle.DataAccess.Client;
using System.Data;


namespace QBooksUploader
    {
    public class Customer  

        {
        public int UploadCount;

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
                                 string accountclass = dr["account_class"].ToString().Trim();
                            
                                 bool  isActive =  dr["account_status"].ToString() == "ACT" ? true : false;

                                 if (!(string.IsNullOrEmpty(middlename))) {
                                     custAdd.MiddleName.SetValue(middlename.Substring(0, 1));
                                     accountname = accountname + " "+ middlename.Substring(0, 1) + ".";
                                     }
                                 
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

                                 if (accountclass == "CONDO"){
                                     custAdd.BillAddress.Addr1.SetValue("UNIT " + unitnumber);
                                 }
                                 else{
                                     custAdd.BillAddress.Addr1.SetValue("PARKING SLOT " + unitnumber);
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
                                 UpdateListID(dt.Rows[i]["account_id"].ToString(), listID, dt.Rows[i]["account_status"].ToString());
                                 }
                             }
                          }
                 }
            }

        private DataTable GetCustomers() {

            string query;

            query = "select account_id,account_class,cust_unit_no,(SELECT cust_lname                                   " +
                        "                                        FROM customers                              " +
                        "                                      WHERE cust_id = cs.acct_cust_id) last_name,   " +
                        "(SELECT cust_fname                                                                  " +
                        "                                        FROM customers                              " +
                        "                                      WHERE cust_id = cs.acct_cust_id) first_name,  " +
                        "(SELECT cust_mname                                                                  " +
                        "                                        FROM customers                              " +
                        "                                      WHERE cust_id = cs.acct_cust_id) middle_name, " +
                        "                                      account_status                                " +
                        "                                                                                    " +
                        "from customer_accounts cs                                                           " +
                        "where account_id not in (select account_id                                          " +
                        "from qb_account_references)                                                         " +
                        "order by cust_unit_sort                                                             ";


            return OraDBHelper2.GetResultSet(query);
            
            }

        private void UpdateListID(string accountID,string listID,string accountStatus) {
            string query;

            query = "INSERT INTO QB_ACCOUNT_REFERENCES(ACCOUNT_ID,QB_LIST_ID,ACCOUNT_STATUS)   " +
                    "VALUES(:accountid,:listid,:accountstatus)";
            using (OraParameter param = new OraParameter()){
                param.AddParameter("listid",listID,OracleDbType.Varchar2,ParameterDirection.Input,false);
                param.AddParameter("accountID", accountID, OracleDbType.Int32, ParameterDirection.Input, false);
                param.AddParameter("accountstatus", accountStatus, OracleDbType.Varchar2 , ParameterDirection.Input, false);

               UploadCount += OraDBHelper2.SqlExecute(query, param.GetParameterCollection());
                }
         
            }
        }
    }
