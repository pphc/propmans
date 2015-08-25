using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public interface ICustomerAccount
    {
        Customer SelectedCustomer { get; set; }
        CustomerAccount SelectedAccount { get; set; }
        CustomerContact SelectedContact { get; }

        void LoadCustomerContacts(List<CustomerContactGridDisplay> customercontacts);
        void LoadCustomerAddress(List<CustomerContactGridDisplay> customeraddress); 

        void LoadCustomerAccounts(List<CustAccountGridDisplay> customeraccounts);
       // void LoadOwnerHousehold(List<UnitHouseHoldGridDisplay> unithouseholds);   

        //Gender Gender { get; }
        //void LoadGender(List<BCL.Common.EnumItem> src);
        //void LoadCustomerUnits(List<UnitGridDisplay> units);
    }
}
