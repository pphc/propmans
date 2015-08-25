using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{    
    public class UpdatePersonalDetailsPresenter
    {
        private IUpdatePersonalDetails view;
        private CustomerAccountDA da = new CustomerAccountDA();
        protected Boolean Status = false;

        public UpdatePersonalDetailsPresenter(IUpdatePersonalDetails view)
        {
            this.view = view;
            view.LoadGender(Gender.FEMALE.ItemList(false, false));
            view.LoadCivilStatus(CivilStatus.DIVORCED.ItemList(false, false));
        }
    }
}
