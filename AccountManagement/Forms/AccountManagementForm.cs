using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

using EnumLib;
using PROPMANS.BL.AccountManagement;
using PROPMANS.ACCOUNT_SEARCH;



namespace PROPMANS.VIEW.AccountManagement
{
    public partial class AccountManagementForm : ComponentFactory.Krypton.Toolkit.KryptonForm, 
    ICustomerAccount
    {
        CustomerAccountPresenter presenter;
        #region "Form Instance"
        private static AccountManagementForm aForm;
        public static AccountManagementForm Instance()
        {
            if (aForm == null)
            {
                aForm = new AccountManagementForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public AccountManagementForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new CustomerAccountPresenter(this);
            grpMain.Enabled = false;
        }        

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (ACCOUNT_SEARCH.AccountLookupForm frm = new ACCOUNT_SEARCH.AccountLookupForm(AccountLookupDisplay.ActiveUnitOwnerOnly))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var sel = frm.SelectedAccount;                    
                    presenter.LoadAccountDetails(sel.Owner.CustomerID);                    
                    this.Cursor = Cursors.Default;
                    grpMain.Enabled = true;
                }
            }
        }

        #region INTERFACE
        private Customer _selectedCustomer;
        public  Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                txtFirstName.Text = value.FirstName;
                txtMiddleName.Text = value.MiddleName;
                txtLastName.Text = value.LastName;
                txtNameSuffix.Text = value.NameSake.ToString();

                if (value.Birthdate.HasValue) 
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - value.Birthdate.Value.Year;
                    if (now < value.Birthdate.Value.AddYears(age)) age--;
                    dtpBirthDate.Value = DateTime.Parse(value.Birthdate.Value.ToString("MMMM dd, yyyy"));
                    lblAge.Text = age.ToString();
                }
                else
                {
                    dtpBirthDate.Checked = false;
                    lblAge.Text = "";
                }

                if (_selectedCustomer.Gender.HasValue) { txtGender.Text = _selectedCustomer.Gender.DisplayName(); }
                if (_selectedCustomer.CivilStatus.HasValue) { txtCivilStatus.Text = _selectedCustomer.CivilStatus.DisplayName(); }                
                txtCitizenShip.Text = _selectedCustomer.Citizenship;
                txtReligion.Text = _selectedCustomer.Religion;
                txtCompanyOrSchool.Text = _selectedCustomer.Company;
                txtOccupation.Text = _selectedCustomer.Occupation;
            }
        }       

        //public void LoadGender(List<EnumItem> src)
        //{
        //    cboGender.DisplayMember = "Name";
        //    cboGender.ValueMember = "Value";
        //    cboGender.DataSource = src;      
        //}

        //public Gender Gender
        //{
        //    get { return (Gender) cboGender.SelectedValue; }
        //}        

        public void LoadCustomerContacts(List<CustomerContactGridDisplay> customercontacts)
        {
            btnUpdateContact.Enabled = true;
            dtgContacts.DataSource = customercontacts;
            if (dtgContacts.RowCount <= 0) btnUpdateContact.Enabled = false;
        }

        public void LoadCustomerAddress(List<CustomerContactGridDisplay> customeraddress)
        {
            btnUpdateContact.Enabled = true;
            dtgAddresses.DataSource = customeraddress;
            if (dtgAddresses.RowCount <= 0) btnUpdateContact.Enabled = false;
        }

        CustomerAccount _selectedAccount;
        CustomerAccount ICustomerAccount.SelectedAccount
        {
            get
            {
                _selectedAccount = (dtgCustomerAccounts.CurrentRow.DataBoundItem as CustAccountGridDisplay).account;
                return _selectedAccount;
            }
            set
            {
                lblUnitNumber.Text = _selectedAccount.Unit.UnitNumber;
                lblUnitType.Text = _selectedAccount.Unit.UnitType.UnitDescription;
                lblUnitArea.Text = _selectedAccount.Unit.UnitArea;
                lblDuesRate.Text = _selectedAccount.CondoDuesRate;

                if (_selectedAccount.TakeOutDate.HasValue){
                    dtpTakeOutdate.Value = DateTime.Parse(_selectedAccount.TakeOutDate.Value.ToString("MMMM dd, yyyy"));         
                }
                else
                { dtpTakeOutdate.Checked = false; }

                if (_selectedAccount.CDStartDate.HasValue){
                    dtpDuesBillingDate.Value = DateTime.Parse(_selectedAccount.CDStartDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpDuesBillingDate.Checked = false; }

                if (_selectedAccount.PowerApplicationDate.HasValue) {
                    dtpPowerConnectionDate.Value = DateTime.Parse(_selectedAccount.PowerApplicationDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpPowerConnectionDate.Checked = false; }

                if (_selectedAccount.WaterApplicationDate.HasValue)
                {
                    dtpWaterConnectionDate.Value = DateTime.Parse(_selectedAccount.WaterApplicationDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpWaterConnectionDate.Checked = false; }

                if (_selectedAccount.EarlyMoveInRequestDate.HasValue) {
                    dtpEarlyMoveInRequest.Value = DateTime.Parse(_selectedAccount.EarlyMoveInRequestDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpEarlyMoveInRequest.Checked = false; }

                if (_selectedAccount.MoveInFeePaymentDate.HasValue) {
                    dtpMoveInFeePaymentDate.Value = DateTime.Parse(_selectedAccount.MoveInFeePaymentDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpMoveInFeePaymentDate.Checked = false; }

                if (_selectedAccount.ATMDate.HasValue) {
                    dtpATMDate.Value = DateTime.Parse(_selectedAccount.ATMDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpATMDate.Checked = false; }

                if (_selectedAccount.InspectionDate.HasValue) {
                    dtpLastInspectionDate.Value = DateTime.Parse(_selectedAccount.InspectionDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpLastInspectionDate.Checked = false; }

                if (_selectedAccount.OrientationDate.HasValue) {
                    dtpOrientationDate.Value =  DateTime.Parse(_selectedAccount.OrientationDate.Value.ToString("MMMM dd, yyyy"));
                } else { dtpOrientationDate.Checked=false;}

                if (_selectedAccount.AcceptanceDate.HasValue) {
                    dtpAcceptanceDate.Value = DateTime.Parse(_selectedAccount.AcceptanceDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpAcceptanceDate.Checked = false; }

                if (_selectedAccount.KeyTurnOverDate.HasValue) {
                    dtpKeyTurnOverDate.Value = DateTime.Parse(_selectedAccount.KeyTurnOverDate.Value.ToString("MMMM dd, yyyy"));
                }
                else { dtpKeyTurnOverDate.Checked = false; }
            }
        }        

        public void LoadCustomerAccounts(List<CustAccountGridDisplay> customeraccounts)
        {
            dtgCustomerAccounts.DataSource = customeraccounts;
        }

        //public void LoadOwnerHousehold(List<UnitHouseHoldGridDisplay> unithouseholds)
        //{
        //    dtgHouseHold.DataSource = unithouseholds;                        
        //}

        CustomerContact _selectedContact;
        public CustomerContact SelectedContact
        {
            get {
                _selectedAccount = null;                
                if (tabContacts.SelectedTab == tabAddress)
                {
                    if (dtgAddresses.RowCount > 0)
                    {                        
                        _selectedContact = (dtgAddresses.CurrentRow.DataBoundItem as CustomerContactGridDisplay).customercontact;
                    }
                }
                else
                {  
                    if (dtgContacts.RowCount > 0)
                    {                        
                        _selectedContact = (dtgContacts.CurrentRow.DataBoundItem as CustomerContactGridDisplay).customercontact;
                    }
                    
                }
                
                return _selectedContact;
            }
        }

        #endregion

        #region EVENTS

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBirthDate.Checked)
            {
                DateTime now = DateTime.Today;
                int age = now.Year - dtpBirthDate.Value.Year;
                if (now < dtpBirthDate.Value.AddYears(age)) age--;
                if (age < 1)
                {
                    lblAge.Text = string.Empty; 
                }
                else
                {
                    lblAge.Text = age.ToString();
                }                 
            }
            else
            {
                lblAge.Text = string.Empty;
            }
            
        }

        private void dtgUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (presenter != null)
            {
                presenter.DisplaySelectedUnit();                
            }
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            if (tabContacts.SelectedTab == tabAddress)
            {
                using (NewAddressForm frm = new NewAddressForm())
                {
                    frm.btnSave.Text = "&SAVE";
                    frm.CustomerID = this.SelectedCustomer.CustomerID;                    
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Cursor = Cursors.Default;
                        presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                    }
                }

            }
            else
            {
                using (NewContactForm frm = new NewContactForm())
                {
                    frm.btnSave.Text = "&SAVE";
                    frm.CustomerID = this.SelectedCustomer.CustomerID;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Cursor = Cursors.Default;
                        presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                    }
                }
            }
            
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            if (tabContacts.SelectedTab == tabAddress)
            {
                using (NewAddressForm frm = new NewAddressForm())
                {
                    frm.btnSave.Text = "&UPDATE";                    
                    frm.CustomerAddress = this.SelectedContact;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Cursor = Cursors.Default;
                        presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                    }
                }

            }
            else
            {
                using (NewContactForm frm = new NewContactForm())
                {
                    frm.btnSave.Text = "&UPDATE";
                    frm.CustomerContact = this.SelectedContact;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Cursor = Cursors.Default;
                        presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                    }
                }
            }
        }

        private void btnUpdateMonitoring_Click(object sender, EventArgs e)
        {
            using (UpdateUnitMonitoringForm frm = new UpdateUnitMonitoringForm())
            {
                frm.SelectedAccount = this._selectedAccount;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {                    
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.Default;
                    presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                }
            }
        }

        private void tabContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateContact.Enabled= false;
            if (tabContacts.SelectedTab == tabAddress)
            {
                if (dtgAddresses.RowCount > 0) btnUpdateContact.Enabled = true;
            }
            else
            {
                if (dtgContacts.RowCount > 0) btnUpdateContact.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (UpdatePersonalDetails frm = new UpdatePersonalDetails())
            {
                frm.SelectedCustomer = this.SelectedCustomer;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.Default;
                    //presenter.LoadAccountDetails(this.SelectedCustomer.CustomerID);
                }
            }
        }
        #endregion                                               

        

        

        

        

        
    }
}
