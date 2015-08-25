using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public class CustomerAccountPresenter
    {
        private ICustomerAccount view;
        private  CustomerAccountDA da = new CustomerAccountDA();

        public CustomerAccountPresenter(ICustomerAccount view)
        {
            this.view = view;
            //view.LoadGender(Gender.FEMALE.ItemList(false, true));
        }        

        public void LoadAccountDetails(string customerID)
        {
            view.SelectedCustomer = (da.GetCustomer(customerID));
            view.LoadCustomerContacts(this.GetCustomerContacts().Where(c => !c.AddressType.Equals("ADDRESS")).ToList());
            view.LoadCustomerAddress(this.GetCustomerContacts().Where(c => c.AddressType.Equals("ADDRESS")).ToList());
            view.LoadCustomerAccounts(this.GetCustomerAccounts());            
        }

        public void DisplaySelectedUnit()
        {
            view.SelectedAccount = this.view.SelectedAccount;            
           // view.LoadOwnerHousehold(this.GetUnitHouseholds());        
        }
      
        private List<CustomerContactGridDisplay> GetCustomerContacts()
        {
            List<CustomerContactGridDisplay> display = new List<CustomerContactGridDisplay>();
            foreach (CustomerContact _customercontact in da.LoadCustomersContacts(view.SelectedCustomer.CustomerID))
            {
                display.Add(new CustomerContactGridDisplay(_customercontact));
            }
            return display;
        }

        //private List<CustomerAddressGridDisplay> GetCustomerAddress()
        //{
        //    List<CustomerAddressGridDisplay> display = new List<CustomerAddressGridDisplay>();
        //    foreach (AccountManagementBL.CustAccount.CustomerContact _costumeraddress in da.LoadCustomersContacts(view.SelectedCustomer.CustomerID))
        //    {
        //        display.Add(new CustomerAddressGridDisplay(_costumeraddress));
        //    }
        //    return display;
        //}

        private List<CustAccountGridDisplay> GetCustomerAccounts()
        {
            List<CustAccountGridDisplay> display = new List<CustAccountGridDisplay>();
            foreach (CustomerAccount _costumeaccount in da.GetCustomerAccountByCustomerID(view.SelectedCustomer.CustomerID))
            {
                display.Add(new CustAccountGridDisplay(_costumeaccount));
            }
            return display;
        }

        //private List<UnitHouseHoldGridDisplay> GetUnitHouseholds()
        //{
        //    List<UnitHouseHoldGridDisplay> display = new List<UnitHouseHoldGridDisplay>();
        //    foreach (UnitHousehold _household in da.LoadUnitHouseHold(view.SelectedAccount.AccountID))
        //    {
        //        display.Add(new UnitHouseHoldGridDisplay(_household));
        //    }
        //    return display;
        //}
    }

    //public class CustomerContacts
    //{
    //    public readonly AccountManagementBL.CustAccount.CustomerContact customercontact;
    //    public CustomerContacts(AccountManagementBL.CustAccount.CustomerContact customercontact)
    //    {
    //        this.customercontact = customercontact;
    //    }

    //    [DisplayName("ACTIVE")]
    //    public bool Active
    //    {
    //        get { return this.customercontact.Active; }
    //    }        

    //    [DisplayName("PREFFERED")]
    //    public bool Preffered
    //    {
    //        get { return this.customercontact.Preffered; }
    //    }
    //}

    public class CustomerContactGridDisplay //: CustomerContact
    {
        public readonly CustomerContact customercontact;
        public CustomerContactGridDisplay(CustomerContact customercontact)
        {
            this.customercontact = customercontact;
        }

        [DisplayName("TYPE")]
        public string AddressType
        {
            get { return this.customercontact.ContactType.DisplayName(); }
        }

        [DisplayName("CONTACT TYPE/LOCATION")]
        public string ContactLocation
        {
            //get { return this.customercontact.ContactType.DBVAlue().Equals("ADDRESS") ? this.customercontact.CLocations.DBVAlue() : this.customercontact.CLocations.DisplayName(); }
            get { return this.customercontact.ContactLocation.DisplayName(); }
        }

        [DisplayName("DETAILS")]
        public string Address
        {
            get { return this.customercontact.Details; }
        }

        [DisplayName("ACTIVE")]
        public string Active
        {
            get { return this.customercontact.Active.DisplayName(); }
        }

        [DisplayName("PREFERRED")]
        public string Preffered
        {
            get { return this.customercontact.Preffered.DisplayName(); }
        }

        //[DisplayName("CONTACT TYPE")]
        //public string ContactType
        //{
        //    get { return this.customercontact.ContactType.DisplayName(); }
        //}

        //[DisplayName("CONTACT LOCATION")]
        //public string ContactLocation
        //{
        //    get { return this.customercontact.ContactLocation.DisplayName(); }
        //}

        //[DisplayName("CONTACT DETAILS")]
        //public string ContactDetails
        //{
        //    get { return this.customercontact.Details; }
        //}

        //[DisplayName("ACTIVE")]
        //public bool Active
        //{
        //    get { return this.customercontact.Active; }
        //}
   
    }

    //public class CustomerAddressGridDisplay : CustomerContact
    //{
    //    public readonly AccountManagementBL.CustAccount.CustomerContact customeraddress;
    //    public CustomerAddressGridDisplay(AccountManagementBL.CustAccount.CustomerContact customeraddress)
    //    {
    //        this.customeraddress = customeraddress;
    //    }

    //    [DisplayName("ADDRESS TYPE")]
    //    public string AddressType
    //    {
    //        get { return this.customeraddress.ContactType.DisplayName(); }
    //    }

    //    [DisplayName("ADDRESS")]
    //    public string Address
    //    {
    //        get { return this.customeraddress.Details; }
    //    }

    //    //[DisplayName("ACTIVE")]
    //    //public bool Active
    //    //{
    //    //    get { return this.customeraddress.Active; }
    //    //}

    //    //[DisplayName("PREFFERED")]
    //    //public bool Preffered
    //    //{
    //    //    get { return this.customeraddress.Preffered; }
    //    //}
    //}

    public class CustAccountGridDisplay
    {
        public readonly CustomerAccount account;
        public CustAccountGridDisplay(CustomerAccount account)
        {
            this.account = account;
        }

        //[DisplayName("ACCOUNT ID")]
        //public string AccountID
        //{
        //    get { return this.account.AccountID; }
        //}

        [DisplayName("UNIT NUMBER")]
        public string UnitNumber
        {
            get { return this.account.Unit.UnitNumber; }
        }

        [DisplayName("UNIT DESCRIPTION")]
        public string UnitType
        {
            get { return this.account.Unit.UnitType.UnitDescription; }
        }

        [DisplayName("UNIT AREA")]
        public string UnitArea
        {
            get { return this.account.Unit.UnitArea; }
        }

        [DisplayName("OWNERSHIP TYPE")]
        public string Occupant
        {
            get { return string.Empty; }
        }

        [DisplayName("ACCOUNT STATUS")]
        public string AccountStaus
        {
            get { return this.account.AccountStatus.DisplayName(); }
        }
        
    }

    //public class UnitHouseHoldGridDisplay{
    //public readonly UnitHousehold unithousehold;
    //public UnitHouseHoldGridDisplay(UnitHousehold unithousehold)
    //{
    //    this.unithousehold = unithousehold;
    //}

    //    [DisplayName("HOUSEHOLD NAME")]
    //    public string HouseholdName
    //    {
    //        get { return this.unithousehold.HouseholdName; }
    //    }

    //    [DisplayName("RELATION TO OWNER")]
    //    public string RelationToOwner
    //    {
    //        get { return this.unithousehold.OwnerRelation; }
    //    }

    //    [DisplayName("BIRTHDATE")]
    //    public DateTime? BirthDate
    //    {
    //        get { return this.unithousehold.BirthDate; }
    //    }

    //    [DisplayName("MOVE-IN DATE")]
    //    public DateTime? MoveInDate
    //    {
    //        get { return this.unithousehold.MoveInDate; }
    //    }

    //    [DisplayName("MOVE-OUT DATE")]
    //    public DateTime? MoveOutDate
    //    {
    //        get { return this.unithousehold.MoveOutDate; }
    //    }
    //}
}
