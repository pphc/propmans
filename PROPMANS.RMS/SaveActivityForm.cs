using BCL.RMS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace PROPMANS.RMS
{
    public partial class SaveActivityForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        ISaveActvity
    {


        private SaveActivityPresenter presenter;
        public BCL.Accounts.CustomerAccount UnitOwnerAccount
        {
            get; set;
        }
        public BCL.Accounts.Customer Tenant
        {
            get;
            set;
        }
        private RentalServiceAgreement _agreement;
        public RentalServiceAgreement Agreement
        {
            get
            {
                return _agreement; 
            }
            set
            {
                _agreement = value;
                lblCurrentAgreement.Text = _agreement.ContractNo;
                lblContractPeriod.Text = _agreement.ContractPeriod;
            }
        }

        private RentalActivity _activity;
        public RentalActivity Activity
        {
            get
            {
                if (_activity == null) {
                    _activity = new RentalActivity();
                }

                _activity.ActivityDate = dtpActivityDate.Value.Date;
                _activity.Notes = txtNotes.Text;
                _activity.Type = (ActivityType) cboActivityType.SelectedItem;
     

                return _activity;
            }
            set
            {
                _activity = value;
                cboActivityType.SelectedValue = value.Type.ID;
                dtpActivityDate.Value = value.ActivityDate;
                txtNotes.Text = value.Notes;
                this.Agreement = value.Agreement;
                
            }
        }

        public string WindowTitle
        {
            set { this.Text = value; }
        }
      
        public SaveActivityForm(SaveActivityPresenter presenter,BCL.Accounts.CustomerAccount unitOwner)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.presenter.view = this;
            this.UnitOwnerAccount = unitOwner;
            this.presenter.Intialize();
            dtpActivityDate.MaxDate = DateTime.Today.Date;
        }

        public SaveActivityForm(SaveActivityPresenter presenter, BCL.Accounts.Customer tenant)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.presenter.view = this;
            this.Tenant = tenant;
            this.presenter.Intialize();
            dtpActivityDate.MaxDate = DateTime.Today.Date;
        }

        public void LoadActivityType(List<ActivityType> src)
        {
           cboActivityType.DisplayMember = "ActivityName";
           cboActivityType.ValueMember = "ID";
           cboActivityType.DataSource = src;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Save Activity?", "Save Activity Confirmation",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    presenter.SaveActivity();
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public void DisplayContractUpdateStatus(bool successful)
        {
            throw new NotImplementedException();
        }

        public void DisplayNewActivitySaveStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("New Activity was added");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Activity was not added");
            }
        }

        public void DisplayUpdateAgreementSaveStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Activity was updated");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Activity was not updated");
            }
        }

               
    }
}
