using BCL.Accounts;
using System;
using System.Windows.Forms;



namespace PROPMANS.ACCOUNT_SEARCH
{
    public partial class NewTenantInfoForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        INewTenantInfo
    {
        private NewTenantInfoPresenter presenter;
        public Customer Tenant
        {
            get;set;
        }

        public string CustomerLastName
        {
            get
            {
                return txtLastName.Text.Trim();
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        public string CustomerFirstName
        {
            get
            {
                return txtFirstName.Text.Trim();
            }
            set
            {
                txtFirstName.Text = value;
            }
        }

        public string CustomerMiddleName
        {
            get
            {
                return txtMiddleName.Text.Trim();
            }
            set
            {
                txtMiddleName.Text = value;
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                return dtpBirthDate.Value.Date;
            }
            set
            {
                if (value != null) {
                    dtpBirthDate.Value = value.Value;
                }
            }
        }

        public bool WithoutMiddleName
        {
            get { return DisplayMiddleNameCheckBox.Checked; }
        }


        public NewTenantInfoForm()
        {
            InitializeComponent();
            presenter = new NewTenantInfoPresenter(this);

        }

        private void NewLeaseAgreementForm_Load(object sender, EventArgs e)
        {
  

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "SELECT") {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (IsEntryValid()) {

                if (presenter.IsCustomerExists())
                {
                    MessageBox.Show("Customer already exists?", "Customer Exists",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Save New Tenant?", "New Tenant Save Confirmation",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        presenter.SaveNewTenant();

                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }       
                }
            }

        }

     
       private void btnCancel_Click(object sender, EventArgs e)
       {
           this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.Close();
       }

        private bool IsEntryValid()
        {
            bool bValid = true;

            errorProvider1.Clear();


            if (String.IsNullOrWhiteSpace(this.CustomerLastName))
            {
                errorProvider1.SetError(txtLastName, "Enter value for Last Name");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtLastName, string.Empty);
            }

            if (String.IsNullOrWhiteSpace(this.CustomerFirstName))
            {
                errorProvider1.SetError(txtFirstName, "Enter value for First Name");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, string.Empty);
            }

            if (!WithoutMiddleName) { 
                 if (String.IsNullOrWhiteSpace(this.CustomerMiddleName))
                    {
                        errorProvider1.SetError(txtMiddleName, "Enter value for Middle Name");
                        bValid = false;
                    }
                else
                    {
                        errorProvider1.SetError(txtMiddleName, string.Empty);
                    }
            }
           


            return bValid;

        }

        private void DisplayInactiveAccountsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtMiddleName.Enabled = ! WithoutMiddleName;

            if (WithoutMiddleName) {
               this.CustomerMiddleName  = String.Empty;
            }
        }


      
    }
}
