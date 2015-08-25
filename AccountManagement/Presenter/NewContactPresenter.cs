using System;
using System.Collections.Generic;
using System.Linq;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public class NewContactPresenter
    {
       public INewContact view;
       private CustomerAccountDA da = new CustomerAccountDA();
       protected Boolean SaveStatus = false;
       public NewContactPresenter(INewContact view)
        {
            this.view = view;
            view.LoadContactType(ContactType.ADDRESS.ItemList(false, false).Where(add => !add.Name.Equals("ADDRESS")).ToList());
            view.LoadContactLocation(ContactLocation.COMPANY.ItemList(false, false).Where(loc => !loc.Name.Equals("PROVINCIAL")).ToList());
        }

       public void SaveContact(string _customerID)
       //public void SaveContact()
       {
           var ID = da.InsertNewContact(_customerID, view.CustomerContact);
           //var ID = da.InsertNewContact(view.CustomerContact);
           SaveStatus = ID > 0;
           view.DisplaySaveStatus(SaveStatus);
       }

       public void UpdateContact()
       {
           var ID = da.UpdateContact(view.CustomerContact);
           SaveStatus = ID > 0;
           view.DisplayUpdateStatus(SaveStatus);
       }
    }
}
