using BCL.Accounts;
using BCL.Common;
using System;
using System.Collections.Generic;

namespace PROPMANS.ACCOUNT_SEARCH
{
    public abstract class AccountLookUpPresenter
    {
        protected IAccountLookUp view;
        protected AccountsDA accountDA = GlobalReference.AccountDataAccess;

        public AccountLookUpPresenter(IAccountLookUp view)
        {
            this.view = view;
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void Search();

        public abstract void ViewAll();

        public abstract void RefreshLookup();

        protected void UpdateStatus(Int32 recordCount)
        {
            if (recordCount == 0)
            {
                view.StatusChange = "NO RECORD/S FOUND";
            }
            else
            {
                view.StatusChange = recordCount + " RECORD/S FOUND";
            }
        }
 
    }

    public class UnitOwnerOnlyAccountLookupPresenter : AccountLookUpPresenter
    {
        protected override void Initialize()
        {
            view.StatusChange = "No Records Found";
            view.DisplayInactiveCheckBox = false;
            view.DisplayNewButton = false;
            view.SetSearchCriteria = SearchAccountCriteria.UnitNumber;
        }
        public UnitOwnerOnlyAccountLookupPresenter(IAccountLookUp view):base(view)
        { 
 
        }

        public override void Search()
        {
            List<CustomerAccountDisplay> display = new List<CustomerAccountDisplay>();
            switch (view.SearchByOption)
            {
                case SearchAccountCriteria.UnitNumber:
                    display = ConvertToDisplay(accountDA.GetUnitOwnerByUnitNumber(view.SearchValue, view.DisplayInactiveAccounts));
                    break;
                case SearchAccountCriteria.LastName:
                    display = ConvertToDisplay(accountDA.GetUnitOwnerByCustLastName(view.SearchValue, view.DisplayInactiveAccounts));
                    break;
                case SearchAccountCriteria.FirstName:
                    display = ConvertToDisplay(accountDA.GetUnitOwnerByCustFirstName(view.SearchValue, view.DisplayInactiveAccounts));
                    break;
                default:
                    break;
            }
            view.LoadCustomerAccounts(display);
            UpdateStatus(display.Count);
        }

        public override void ViewAll()
        {
            var display = ConvertToDisplay(accountDA.GetUnitOwnerAcccounts(view.DisplayInactiveAccounts));
            view.LoadCustomerAccounts(display);
            UpdateStatus(display.Count);
        }

        public override void RefreshLookup()
        {
            accountDA.ReloadData();
        }

        private List<CustomerAccountDisplay> ConvertToDisplay(List<BCL.Accounts.CustomerAccount> accounts)
        {

            var display = new List<CustomerAccountDisplay>();

            foreach (BCL.Accounts.CustomerAccount act in accounts)
            {
                display.Add(new CustomerAccountDisplay(act));
            }
            return display;

        }
    }

    public class CustomerOnlyAccountLookUpPresenter : AccountLookUpPresenter
    {
        protected override void Initialize()
        {
            view.StatusChange = "No Records Found";
            view.DisplayInactiveCheckBox = false;
            view.DisplayNewButton = true;
            view.DisplayUnitNumberTextbox = false;
            view.SetSearchCriteria = SearchAccountCriteria.LastName;
        }

        public CustomerOnlyAccountLookUpPresenter(IAccountLookUp view)
            : base(view)
        { 
 
        }

        public override void Search()
        {
            List<CustomerDisplay> display = new List<CustomerDisplay>();
            switch (view.SearchByOption)
            {
                case SearchAccountCriteria.LastName:
                    display = ConvertToDisplay(accountDA.GetCustomerByLastName(view.SearchValue));
                    break;
                case SearchAccountCriteria.FirstName:
                    display = ConvertToDisplay(accountDA.GetCustomerByFirstName(view.SearchValue));
                    break;
                default:
                    break;
            }
            view.LoadCustomers(display);
            UpdateStatus(display.Count);
        }

        public override void ViewAll()
        {
            var display = ConvertToDisplay(accountDA.GetCustomers());
            view.LoadCustomers(display);
            UpdateStatus(display.Count);
        }

        public override void RefreshLookup()
        {
            accountDA.ReloadData();
        }

        private List<CustomerDisplay> ConvertToDisplay(List<BCL.Accounts.Customer> customer)
        {

            var display = new List<CustomerDisplay>();

            foreach (BCL.Accounts.Customer cust in customer)
            {
                display.Add(new CustomerDisplay(cust));
            }
            return display;

        }
    }

    public class AllUnitsAccountLookupPresenter : AccountLookUpPresenter
    {
        protected override void Initialize()
        {
            view.StatusChange = "No Records Found";
            view.DisplayInactiveCheckBox = false;
            view.DisplayNewButton = false;
            view.SetSearchCriteria = SearchAccountCriteria.UnitNumber;
        }
        public AllUnitsAccountLookupPresenter(IAccountLookUp view)
            : base(view)
        {

        }

        public override void Search()
        {
            List<AllUnitsDisplay> display = new List<AllUnitsDisplay>();
            switch (view.SearchByOption)
            {
                case SearchAccountCriteria.UnitNumber:
                    display = ConvertToDisplay(accountDA.GetUnitsInventoryByUnitNumber (view.SearchValue));
                    break;
                case SearchAccountCriteria.LastName:
                    display = ConvertToDisplay(accountDA.GetUnitsInventoryByLastName(view.SearchValue));
                    break;
                case SearchAccountCriteria.FirstName:
                    display = ConvertToDisplay(accountDA.GetUnitsInventoryByFirstName(view.SearchValue));
                    break;
                default:
                    break;
            }
            view.LoadUnits(display);
            UpdateStatus(display.Count);
        }

        public override void ViewAll()
        {
            var display = ConvertToDisplay(accountDA.GetUnitsInventory());
            view.LoadUnits(display);
            UpdateStatus(display.Count);
        }

        public override void RefreshLookup()
        {
            accountDA.ReloadData();
        }

        private List<AllUnitsDisplay> ConvertToDisplay(List<BCL.Accounts.UnitInventory> units)
        {

            var display = new List<AllUnitsDisplay>();

            foreach (BCL.Accounts.UnitInventory unit in units)
            {
                display.Add(new AllUnitsDisplay(unit));
            }
            return display;

        }
    }

}
