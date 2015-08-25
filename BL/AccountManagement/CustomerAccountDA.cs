using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALC;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using EnumLib;

namespace PROPMANS.BL.AccountManagement
{
    public class CustomerAccountDA
    {
        //TODO combine CustAcctDA and UIDA to one class using singleton pattern
        //Reference to UnitInventoryDA
        UnitInventoryDA unitda = new UnitInventoryDA();

        #region LIST
        private List<Customer> _Customer = new List<Customer>();
        private List<Customer> Customers
        {
            get
            {
                return _Customer;
            }
        }

        private List<CustomerAccount> _CustomerAccounts = new List<CustomerAccount>();
        private List<CustomerAccount> CustomerAccounts
        {
            get
            {
                return _CustomerAccounts;
            }
        }

        private List<CustomerContact> _CustomerContacts = new List<CustomerContact>();
        private List<CustomerContact> CustomerContacts
        {
            get
            {
                return _CustomerContacts;
            }
        }

        //private List<UnitHousehold> _UnitHouseholds = new List<UnitHousehold>();
        //private List<UnitHousehold> UnitHouseholds
        //{
        //    get
        //    {
        //        return _UnitHouseholds;
        //    }
        //}

        #endregion

        public CustomerAccountDA()
        {
            LoadCustomers();
            LoadCustomersAccounts();
        }

        #region DA_FUNCTIONS

        // TODO. use *
        public Int32 InsertNewContact(string customerID, CustomerContact contactInfo)
        //* public Int32 InsertNewContact(CustomerContact _customerContact)
        {
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("custid", customerID, OracleDbType.Int32);
                //param.AddParameter("custid", _customerContact.Customer.CustomerID, OracleDbType.Int32);
                param.AddParameter("contacttype", contactInfo.ContactType.DBVAlue());
                param.AddParameter("contactlocation", contactInfo.ContactLocation.DBVAlue());
                param.AddParameter("contactdetails", contactInfo.Details);
                param.AddParameter("isactive", contactInfo.Active.DBVAlue());
                param.AddParameter("ispreferred", contactInfo.Preffered.DBVAlue());
                param.AddParameter("contactid", null, OracleDbType.Int32, ParameterDirection.ReturnValue);
                return (Int32)((OracleDecimal)OraDBHelper2.ExecuteFunction("ACCOUNTS.insertcustomercontact", param.GetParameterCollection()));
            }
        }

        public Int32 UpdateContact(CustomerContact _customerContact)
        {
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("custid", _customerContact.Customer.CustomerID, OracleDbType.Int32);
                param.AddParameter("contactid", _customerContact.ContactID, OracleDbType.Int32);
                param.AddParameter("contacttype", _customerContact.ContactType.DBVAlue());
                param.AddParameter("contactlocation", _customerContact.ContactLocation.DBVAlue());
                param.AddParameter("contactdetails", _customerContact.Details);
                param.AddParameter("isactive", _customerContact.Active.DBVAlue());
                param.AddParameter("ispreferred", _customerContact.Preffered.DBVAlue());
                param.AddParameter("retnumber", null, OracleDbType.Int32, ParameterDirection.ReturnValue);
                return (Int32)((OracleDecimal)OraDBHelper2.ExecuteFunction("ACCOUNTS.updatecustomercontact", param.GetParameterCollection()));
            }
        }

        public Int32 UpdateUnitMonitoring(CustomerAccount _customerAccount)
        {
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("accountid", _customerAccount.AccountID, OracleDbType.Int32);
                param.AddParameter("takeoutdate", _customerAccount.TakeOutDate, OracleDbType.Date);
                param.AddParameter("condoduesdate", _customerAccount.CDStartDate, OracleDbType.Date);
                param.AddParameter("atmdate", _customerAccount.ATMDate, OracleDbType.Date);
                param.AddParameter("acceptancedate", _customerAccount.AcceptanceDate, OracleDbType.Date);
                param.AddParameter("orientationdate", _customerAccount.OrientationDate, OracleDbType.Date);
                param.AddParameter("pwrapplicationdate", _customerAccount.PowerApplicationDate, OracleDbType.Date);
                param.AddParameter("wtrapplicationdate", _customerAccount.WaterApplicationDate, OracleDbType.Date);
                param.AddParameter("earlymoveindate", _customerAccount.EarlyMoveInRequestDate, OracleDbType.Date);
                param.AddParameter("moveinfeepymtdate", _customerAccount.MoveInFeePaymentDate, OracleDbType.Date);
                param.AddParameter("lastinspectiondate", _customerAccount.InspectionDate, OracleDbType.Date);
                param.AddParameter("keyturnoverdate", _customerAccount.KeyTurnOverDate, OracleDbType.Date);
                param.AddParameter("retnumber", null, OracleDbType.Int32, ParameterDirection.ReturnValue);
                return (Int32)((OracleDecimal)OraDBHelper2.ExecuteFunction("ACCOUNTS.updateaccountmonitoring", param.GetParameterCollection()));
            }
        }

        //public bool InsertHousehold(UnitHousehold _newHousehold)
        //{
        //    return true;
        //}

        private void LoadCustomers()
        {
            _Customer = new List<Customer>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("ACCOUNTS.getcustomers", param.GetParameterCollection()).Rows)
                {
                    _Customer.Add(new Customer
                    {
                        CustomerID = row["CUST_ID"].ToString(),
                        DisplayName = row["DISPLAY_NAME"].ToString(),
                        FirstName = row["CUST_FNAME"].ToString(),
                        LastName = row["CUST_LNAME"].ToString(),
                        MiddleName = row["CUST_MNAME"].ToString(),
                        NameSake = GetNameSake(row["NAME_SAKE"]),
                        Gender = GetGender(row["CUST_SEX"]),
                        Notes = row["NOTES"].ToString(),
                        Religion = row["RELIGION"].ToString(),
                        Occupation = row["OCCUPATION"].ToString(),
                        Birthdate = GetDate(row["BIRTH_DATE"]),
                        Citizenship = row["CITIZENSHIP"].ToString(),
                        CivilStatus = GetCivilStatus(row["CUST_MARITAL_STATUS"]),
                        Company = row["COMPANY"].ToString(),
                        CustomerContacts = LoadCustomersContacts(row["CUST_ID"].ToString()),
                        Customers = GetCustomerAccountByCustomerID(row["CUST_ID"].ToString())
                    });
                }
            }
        }

        private void LoadCustomersAccounts()
        {
            _CustomerAccounts = new List<CustomerAccount>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("ACCOUNTS.getcustomeraccounts", param.GetParameterCollection()).Rows)
                {
                    _CustomerAccounts.Add(new CustomerAccount
                    {
                        AccountID = row["ACCOUNT_ID"].ToString(),
                        MoveInDate = GetDate(row["MOVE_IN_DATE"]),
                        TakeOutDate = GetDate(row["TAKEOUT_DATE"]),
                        CDStartDate = GetDate(row["CD_START_DATE"]),
                        AccountStatus = EnumExtensions.Entry<AccountStatus>(row["ACCOUNT_STATUS"].ToString()),
                        AccountFinanceCode = row["CUST_FINANCE_CODE"].ToString(),
                        CustomerUnitSort = row["CUST_UNIT_SORT"].ToString(),
                        PaymentScheme = row["PAYMENT_SCHEME"].ToString(),
                        CondoDuesRate = row["CONDO_DUES_RATE"].ToString(),
                        OrientationDate = GetDate(row["ORIENTATION_DATE"]),
                        InspectionDate = GetDate(row["INSPECTION_DATE"]),
                        AcceptanceDate = GetDate(row["ACCEPTANCE_DATE"]),
                        KeyTurnOverDate = GetDate(row["KEY_TURN_OVER_DATE"]),
                        PowerApplicationDate = GetDate(row["POWER_APPLICATION_DATE"]),
                        WaterApplicationDate = GetDate(row["WATER_APPLICATION_DATE"]),
                        LivingPrequency = row["LIVING_FREQUENCY"].ToString(),
                        Notes = row["NOTES"].ToString(),
                        ATMDate = GetDate(row["ATM_DATE"]),
                        AccountClass = row["ACCOUNT_CLASS"].ToString(),
                        MoveInFeePaymentDate = GetDate(row["MOVE_IN_FEE_PAYMENT_DATE"]),
                        EarlyMoveInRequestDate = GetDate(row["EARLY_MOVE_IN_REQUEST_DATE"]),
                        Customer = GetCustomer(row["ACCT_CUST_ID"].ToString()),
                        Unit = unitda.GetUnitByUnitID(row["UNIT_ID"].ToString())
                    });
                }
            }
        }

        public List<CustomerContact> LoadCustomersContacts(string customerID)
        {
            _CustomerContacts = new List<CustomerContact>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("customerid", customerID);
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("ACCOUNTS.getcustomercontacts", param.GetParameterCollection()).Rows)
                {
                    _CustomerContacts.Add(new CustomerContact
                    {
                        ContactID = row["CONTACT_ID"].ToString(),
                        ContactType = EnumExtensions.Entry<ContactType>(row["CONTACT_TYPE"].ToString()),
                        ContactLocation = EnumExtensions.Entry<ContactLocation>(row["CONTACT_LOC"].ToString()),
                        Details = row["DETAILS"].ToString(),
                        Active = EnumExtensions.Entry<ActiveStatus>(row["ACTIVE"].ToString()),
                        Preffered = EnumExtensions.Entry<ActiveStatus>(row["PREFFERED"].ToString()),
                        Customer = this.GetCustomer(customerID)
                    });
                }
            }
            return _CustomerContacts;
        }

        //public List<UnitHousehold> LoadUnitHouseHold(string accountID)
        //{
        //    _UnitHouseholds = new List<UnitHousehold>();
        //    using (OraParameter param = new OraParameter())
        //    {
        //        param.AddParameter("accountid", accountID);
        //        param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
        //        foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("ACCOUNTS.getunithouseholds", param.GetParameterCollection()).Rows)
        //        {
        //            _UnitHouseholds.Add(new UnitHousehold
        //            {
        //                AccountID = row["ACCOUNT_ID"].ToString(),
        //                HouseholdName = row["HOUSEHOLD_NAME"].ToString(),
        //                BirthDate = GetDate(row["BIRTH_DATE"]),
        //                Occupation = row["OCCUPATION"].ToString(),
        //                OwnerRelation = row["OWNER_RELATION"].ToString(),
        //                MoveInDate = GetDate(row["MOVE_IN_DATE"]),
        //                MoveOutDate = GetDate(row["MOVE_OUT_DATE"]),
        //                CustAccount = GetCustomerAccountByAccountID(row["ACCOUNT_ID"].ToString())
        //            });
        //        }
        //    }
        //    return _UnitHouseholds;
        //}

        //private void LoadUnitHouseHolds() 
        //{
        //    _UnitHouseholds = new List<UnitHousehold>();
        //    using (OraParameter param = new OraParameter())
        //    {
        //        param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
        //        foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("ACCOUNTS.getunithouseholds", param.GetParameterCollection()).Rows)
        //        {
        //            _UnitHouseholds.Add(new UnitHousehold
        //            {                        
        //                MemberID = row["MEMBER_ID"].ToString(),
        //                HouseholdName = row["HOUSEHOLD_NAME"].ToString(),
        //                BirthDate = GetDate(row["BIRTH_DATE"]),
        //                Occupation = row["OCCUPATION"].ToString(),
        //                OwnerRelation = row["OWNER_RELATION"].ToString(),
        //                AccountID = row["ACCOUNT_ID"].ToString(),
        //                MoveInDate = GetDate(row["MOVE_IN_DATE"]),
        //                MoveOutDate = GetDate(row["MOVE_OUT_DATE"])                         
        //            });
        //        }
        //    }
        //}


        private Gender? GetGender(object obj)
        {
            Gender? gender = null;
            if (!Convert.IsDBNull(obj))
            {
                gender = EnumExtensions.Entry<Gender>(obj.ToString());
            }
            return gender;
        }

        private NameSake? GetNameSake(object obj)
        {
            NameSake? namesake = null;
            if (!Convert.IsDBNull(obj))
            {
                namesake = EnumExtensions.Entry<NameSake>(obj.ToString());
            }
            return namesake;
        }

        private CivilStatus? GetCivilStatus(object obj)
        {
            CivilStatus? civilstatus = null;
            if (!Convert.IsDBNull(obj))
            {
                civilstatus = EnumExtensions.Entry<CivilStatus>(obj.ToString());
            }
            return civilstatus;
        }

        private DateTime? GetDate(object obj)
        {
            DateTime? datevalue = null;
            if (!Convert.IsDBNull(obj))
            {
                datevalue = DateTime.Parse(obj.ToString());
            }
            return datevalue;
        }

        private bool GetValue(object obj)
        {
            bool val = false;
            if (!Convert.IsDBNull(obj))
            {
                val = true;
            }
            return val;
        }
        #endregion

        #region (LINQ)
        public Customer GetCustomer(string customerID)
        {
            return (from Customer cust in Customers
                    where cust.CustomerID.Equals(customerID)
                    select cust).SingleOrDefault();
        }

        public List<CustomerAccount> GetCustomerAccountByCustomerID(string customerID)
        {
            return (from CustomerAccount custAccount in _CustomerAccounts
                    where custAccount.Customer.CustomerID.Equals(customerID)
                    select custAccount).ToList();
        }

        private CustomerAccount GetCustomerAccountByAccountID(string accountID)
        {
            return (from CustomerAccount custAccount in _CustomerAccounts
                    where custAccount.AccountID.Equals(accountID)
                    select custAccount).SingleOrDefault();
        }

        private List<CustomerContact> GetCustomerContact(string customerID)
        {
            return (from CustomerContact custcontact in _CustomerContacts
                    where
                        ((custcontact.ContactType.Equals("TELEPHONE")) ||
                        (custcontact.ContactType.Equals("CELLPHONE")) ||
                        (custcontact.ContactType.Equals("EMAIL")) &&
                        custcontact.ContactType.Equals(customerID))
                    select custcontact).ToList();
        }

        public List<CustomerContact> GetCustomerAddress(string customerID)
        {
            return (from CustomerContact custcontact in _CustomerContacts
                    where
                        ((custcontact.ContactType.Equals("ADDRESS")) &&
                        custcontact.ContactType.Equals(customerID))
                    select custcontact).ToList();
        }
      
        #endregion

    

    }
}
