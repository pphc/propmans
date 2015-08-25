
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using EnumLib;
using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public partial class NewAddressForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        INewAddress
    {
        NewAddressPresenter presenter;
        #region "Form Instance"
        private static NewAddressForm aForm;
        public static NewAddressForm Instance()
        {
            if (aForm == null)
            {
                aForm = new NewAddressForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public NewAddressForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new NewAddressPresenter(this);  
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
        private CustomerContact _customerAddress;
        public CustomerContact CustomerAddress
        {
            get
            {
                if (_customerAddress == null) _customerAddress = new CustomerContact();
               
                _customerAddress.ContactType = ContactType.ADDRESS;
                _customerAddress.ContactLocation = (ContactLocation)cboAddressType.SelectedValue;
                _customerAddress.Details =  txtAddressInformation.Text.Trim();                
                if(RbAddressYes.Checked){
                    _customerAddress.Active = ActiveStatus.Yes;
                }
                else { _customerAddress.Active = ActiveStatus.No; }
                if (chkMakeDefault.Checked) {
                    _customerAddress.Preffered = ActiveStatus.Yes;
                }
                else { _customerAddress.Preffered = ActiveStatus.No; }
                
                return _customerAddress;
            }
            set
            {
                if (value != null)
                {
                    cboAddressType.SelectedValue = (Int32)value.ContactLocation;
                    txtAddressInformation.Text = value.Details;
                    if (value.Active.Equals("Yes"))
                    {
                        RbAddressYes.Checked = true;
                    }
                    else { RbAddressNo.Checked = false; }

                    if (value.Preffered.Equals("Yes"))
                    {
                        chkMakeDefault.Checked = true;
                    }
                    else { chkMakeDefault.Checked = false; }
                    _customerID = value.Customer.CustomerID;
                    _customerAddress = value;
                }                

            }
        }

        public void LoadAddressLocation(List<EnumItem> src)
        {
            cboAddressType.DisplayMember = "Name";
            cboAddressType.ValueMember = "Value";
            cboAddressType.DataSource = src;            
        }

        public void DisplaySaveStatus(bool status)
        {
            if (status)
            {
                MessageBox.Show("New Address Successfully Added!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add new Address!");
            }
        }

        public void DisplayUpdateStatus(bool status)
        {
            if (status)
            {
                MessageBox.Show("Address Successfully Updated!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Address!");
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
                if (MessageBox.Show("ADD NEW ADDRESS?", "CONFIRM SAVING",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (IsInputValid())
                    {
                        presenter.SaveAddress(_customerID);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("UPDATE ADDRESS?", "CONFIRM EDITING",
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
        private bool IsInputValid(){
            bool result = true;
            errMsg.Clear();
            errMsg.SetError(txtAddressInformation, "");
            if (String.IsNullOrWhiteSpace(txtAddressInformation.Text))
            {
                errMsg.SetError(txtAddressInformation, "Invalid Address!");
                result = false;
            }

            return result;
        }
        #endregion
    }
}
