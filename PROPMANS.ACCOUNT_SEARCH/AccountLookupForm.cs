using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PROPMANS.ACCOUNT_SEARCH
{
    public enum AccountLookupDisplay
    {
        ActiveUnitOwnerOnly,
        CUstomerOnly,
        AllUnits
    }
    public partial class AccountLookupForm : ComponentFactory.Krypton.Toolkit.KryptonForm , IAccountLookUp
    {
        private AccountLookUpPresenter presenter;

        public BCL.Accounts.Customer SelectedCustomer
        {
            get { return (this.CustomerAccountsGridView.SelectedRows[0].DataBoundItem as CustomerDisplay).Customer; }
        }
        public BCL.Accounts.CustomerAccount SelectedAccount
        {
            get { return (this.CustomerAccountsGridView.SelectedRows[0].DataBoundItem as CustomerAccountDisplay).CustAccount; }
        }

        public BCL.Accounts.UnitInventory SelectedUnit
        {
            get { return (this.CustomerAccountsGridView.SelectedRows[0].DataBoundItem as AllUnitsDisplay).Unit; }
        }

        public bool DisplayInactiveCheckBox
        {
            set { DisplayInactiveAccountsCheckBox.Visible = value; }
        }
        public bool DisplayNewButton
        {
            set { btnNewCustomer.Visible = value; }
        }
        public bool DisplayUnitNumberTextbox
        {
            set { ByUnitNumberRadioButton.Enabled = value; }
        }

        public SearchAccountCriteria SetSearchCriteria
        {
            set
            {
                switch (value)
                {
                    case SearchAccountCriteria.UnitNumber:
                        ByUnitNumberRadioButton.Checked = true;
                        break;
                    case SearchAccountCriteria.LastName:
                        ByLastNameRadioButton.Checked = true;
                        break;
                    case SearchAccountCriteria.FirstName:
                        ByFirstNameRadioButton.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public SearchAccountCriteria SearchByOption
        {
            get
            {
                SearchAccountCriteria criteria = SearchAccountCriteria.UnitNumber;
                if (ByUnitNumberRadioButton.Checked)
                {
                    criteria = SearchAccountCriteria.UnitNumber;
                }
                if (ByLastNameRadioButton.Checked)
                {
                    criteria = SearchAccountCriteria.LastName;
                }
                if (ByFirstNameRadioButton.Checked)
                {
                    criteria = SearchAccountCriteria.FirstName;
                }

                return criteria;
            }

        }
       
        public string SearchValue
        {
            get
            {
                return SearchValueTextBox.Text.Trim();
            }
        }
       
        public bool DisplayInactiveAccounts
        {
            get { return DisplayInactiveAccountsCheckBox.Checked; }
        }

        public string StatusChange
        {
            set { ResultCountLabel.Text = value; }
        }


        public void LoadUnits(List<AllUnitsDisplay> units)
        {
            btnSelect.Enabled = units.Count > 0;
            this.CustomerAccountsGridView.DataSource = units;
        }

        public void LoadCustomers(List<CustomerDisplay> customers)
        {
            btnSelect.Enabled = customers.Count > 0;
            this.CustomerAccountsGridView.DataSource = customers;
        }
        
        public void LoadCustomerAccounts(List<CustomerAccountDisplay> accounts)
        {
            btnSelect.Enabled = accounts.Count > 0;
            this.CustomerAccountsGridView.DataSource = accounts;
        }

        public AccountLookupForm(AccountLookupDisplay displayType)
        {
            InitializeComponent();

            if (displayType == AccountLookupDisplay.ActiveUnitOwnerOnly)
            {
                presenter = new UnitOwnerOnlyAccountLookupPresenter(this);
            }
            else if (displayType == AccountLookupDisplay.AllUnits) {
                presenter = new AllUnitsAccountLookupPresenter(this);
            }
            else
            {
                presenter = new CustomerOnlyAccountLookUpPresenter(this);
            }
           
        }

        private void AccountLookupForm_Load_1(object sender, EventArgs e)
        {
            CustomerAccountsGridView.ReadOnly = true;
            btnSelect.Enabled = false;
        }
        
        private void SearchOptionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            HighlightField();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchValueTextBox.Text))
            {
                HighlightField();
            }
            else
            {
                presenter.Search();
            }
        }

        private void txtViewAll_Click(object sender, EventArgs e)
        {
            SearchValueTextBox.Text = string.Empty;
            HighlightField();
            presenter.ViewAll();
        }
       
        private void HighlightField(){
            SearchValueTextBox.SelectAll();
            SearchValueTextBox.Focus();
        }

        private void ClearSearchValueButton_Click(object sender, EventArgs e)
        {
            SearchValueTextBox.Text = string.Empty;
            HighlightField();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            presenter.RefreshLookup();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Have you search the name of the tenant before we proceed?","New Tenant Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                using (NewTenantInfoForm frm = new NewTenantInfoForm())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        presenter.RefreshLookup();
                        this.SetSearchCriteria = SearchAccountCriteria.LastName;
                        this.SearchValueTextBox.Text = frm.CustomerLastName;
                        presenter.Search();
                    }
                }
            }
            else
            {
                SearchValueTextBox.Focus();
            }
           
        }

        private void SearchValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchValueTextBox.Text))
            {
                this.AcceptButton = btnViewAll;
            }
            else
            {

                this.AcceptButton = btnSearch;
              
            }
        }
    }
}
