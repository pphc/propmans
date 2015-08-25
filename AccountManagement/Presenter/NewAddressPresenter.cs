using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public class NewAddressPresenter
    {
        private INewAddress view;
        private CustomerAccountDA da = new CustomerAccountDA();
        protected Boolean SaveStatus = false;

        public NewAddressPresenter(INewAddress view)
        {
            this.view = view;
            view.LoadAddressLocation(ContactLocation.COMPANY.ItemList(false, false).Where(loc => !loc.Name.Equals("PERSONAL")).ToList());
        }

        public void SaveAddress(string _customerID)
        {            
            var ID = da.InsertNewContact(_customerID, view.CustomerAddress);
            //var ID = da.InsertNewContact(view.CustomerAddress);
            SaveStatus = ID > 0;
            view.DisplaySaveStatus(SaveStatus);
        }

        public void UpdateContact()
        {
            var ID = da.UpdateContact(view.CustomerAddress);
            SaveStatus = ID > 0;
            view.DisplayUpdateStatus(SaveStatus);
        }
    }
}
