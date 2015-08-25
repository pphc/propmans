using System;
using System.Collections.Generic;
using System.Windows.Forms;

using EnumLib;
using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public partial class NewContactForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        INewContact
    {
        NewContactPresenter presenter;
        #region "Form Instance"
        private static NewContactForm aForm;
        public static NewContactForm Instance()
        {
            if (aForm == null)
            {
                aForm = new NewContactForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public NewContactForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new NewContactPresenter(this);
        }

        #region PROPERTIES
        private string _customerID;
        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        #endregion

        #region INTERFACE
        private CustomerContact _customerContact;
        public CustomerContact CustomerContact
        {
            get
            {                
                if (_customerContact == null) _customerContact = new CustomerContact();

                _customerContact.ContactType = (ContactType)cboContactType.SelectedValue;
                _customerContact.ContactLocation = (ContactLocation)cboContactLocation.SelectedValue;
                _customerContact.Details = txtContact.Text.Trim();                
                if (RbContactYes.Checked)
                {
                    _customerContact.Active = ActiveStatus.Yes;
                }
                else { _customerContact.Active = ActiveStatus.No; }
                if (chkPreferred.Checked) {
                    _customerContact.Preffered = ActiveStatus.Yes;
                }
                else { _customerContact.Preffered = ActiveStatus.No; }
                return _customerContact;
            }
            set
            {
                if (value != null)
                {
                    cboContactType.SelectedValue = (Int32)value.ContactType;
                    cboContactLocation.SelectedValue = (Int32)value.ContactLocation;
                    txtContact.Text = value.Details;
                    if (value.Active.Equals("Yes"))
                    {
                        RbContactYes.Checked = true;
                    }
                    else { RbContactNo.Checked = false; }
                    if (value.Preffered.Equals("Yes")) {
                        chkPreferred.Checked = true;
                    }
                    else { chkPreferred.Checked = false; }
                    _customerID = value.Customer.CustomerID;
                    _customerContact = value;
                }                
            }
        }

        public void LoadContactType(List<EnumItem> src)
        {
            cboContactType.DisplayMember = "Name";
            cboContactType.ValueMember = "Value";
            cboContactType.DataSource = src;
        }

        public void LoadContactLocation(List<EnumItem> src)
        {
            cboContactLocation.DisplayMember = "Name";
            cboContactLocation.ValueMember = "Value";
            cboContactLocation.DataSource = src;
        }

        public void DisplaySaveStatus(bool status)
        {
            if (status)
            {
                MessageBox.Show("New Contact Successfully Added!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add new Contact!");
            }
        }

        public void DisplayUpdateStatus(bool status)
        {
            if (status)
            {
                MessageBox.Show("Contact Successfully Updated!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Contact!");
            }
        }
        #endregion
        
        #region EVENTS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "&SAVE")
            {
                if (MessageBox.Show("ADD NEW CONTACT?", "CONFIRM SAVING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (IsInputValid())
                    {
                        presenter.SaveContact(_customerID);
                        //presenter.SaveContact();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("UPDATE CONTACT?", "CONFIRM SAVING",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (IsInputValid())
                    {
                        presenter.UpdateContact();
                    }
                }
            }
            
        }
        #endregion

        #region PRIVATE FUNCTION(S)
        private bool IsInputValid()
        {
            bool result = true;
            errMsg.Clear();
            errMsg.SetError(txtContact, "");
            if (String.IsNullOrWhiteSpace(txtContact.Text))
            {
                errMsg.SetError(txtContact, "Invalid Contact Details!");
                result = false;
            }

            return result;
        }
        #endregion



        
    }
}
