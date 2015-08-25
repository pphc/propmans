using BCL.Accounts;

namespace PROPMANS.ACCOUNT_SEARCH
{
    public class NewTenantInfoPresenter
    {
        private INewTenantInfo view;
        private AccountsDA accounts = new AccountsDA();

        public NewTenantInfoPresenter(INewTenantInfo view)
        {
            this.view = view;
        
        }

        public void SaveNewTenant()
        {
            Customer cust = new Customer();

            cust.LastName = view.CustomerLastName;
            cust.FirstName = view.CustomerFirstName;
            cust.MiddleName = view.CustomerMiddleName;

            cust.CustomerID = accounts.SaveCustomer(cust).ToString();

            view.Tenant = cust;


        }

        public bool IsCustomerExists()
        {
            Customer cust = new Customer();

            cust.LastName = view.CustomerLastName;
            cust.FirstName = view.CustomerFirstName;
            cust.MiddleName = view.CustomerMiddleName;

            return accounts.IsCustomerExisting(cust);
        
        }

       

    }
}
