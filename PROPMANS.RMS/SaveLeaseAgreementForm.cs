using BCL.Common;
using BCL.RMS;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace PROPMANS.RMS
{
    public enum SaveLeaseOption
    { 
      NewAgreement,UpdateAgreement
    }

    public partial class SaveLeaseAgreementForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        ISaveLeaseAgreement
    {
        private SaveLeaseAgreementPresenter presenter;

        private BCL.Accounts.Customer _tenant;
        public BCL.Accounts.Customer Tenant
        {
            get {
                return _tenant;
            }
            set {
                _tenant = value;
                txtFirstName.Text = _tenant.FirstName;
                txtMiddleName.Text = _tenant.MiddleName;
                txtLastName.Text = _tenant.LastName;
            }
        }

        private LeaseAgreement _leaseAgreement;
        public LeaseAgreement LeaseAgreement
        {
            get {
                if (_leaseAgreement == null)
                {
                  _leaseAgreement = new LeaseAgreement();
                }

                _leaseAgreement.AgreementDate = dtpApplicationDate.Value.Date;
                _leaseAgreement.LeasePurpose = (LeasePurpose)cboLeasePurpose.SelectedValue;
                _leaseAgreement.RentalAgreement = this.RentalAgreement;
                _leaseAgreement.ContractStartDate = dtpContractStart.Value.Date;
                _leaseAgreement.ContractEndDate = dtpContractEnd.Value.Date;
                _leaseAgreement.MonthsTerm = Int32.Parse(nudMonthsTerm.Value.ToString());

                _leaseAgreement.RentAmount = Decimal.Parse(txtRentAmount.Text);
                _leaseAgreement.PrepaidRent = Decimal.Parse(txtPrepaidRent.Text);
                _leaseAgreement.SecurityDeposit = Decimal.Parse(txtSecurityDeposit.Text);

                if (!String.IsNullOrEmpty(txtCashBond.Text))
                {
                    _leaseAgreement.CashBond = Decimal.Parse(txtCashBond.Text);
                }

                return _leaseAgreement;
            }
            set {
                _leaseAgreement = value;
                lblContractNUmber.Text = _leaseAgreement.ContractNo;

                dtpApplicationDate.Value = _leaseAgreement.AgreementDate;
             
                nudMonthsTerm.Value = _leaseAgreement.MonthsTerm;
                dtpContractStart.Value = _leaseAgreement.ContractStartDate;
                dtpContractEnd.Value = _leaseAgreement.ContractEndDate;
                cboLeasePurpose.SelectedValue = (Int32)_leaseAgreement.LeasePurpose;

                this.RentalAgreement = _leaseAgreement.RentalAgreement;
            }
        }

        private RentalAgreement _rentalAgreement;
        public RentalAgreement RentalAgreement
        {
            get
            {
                return _rentalAgreement;
            }
            set {
                _rentalAgreement = value;

                lblLeaseType.Text = _rentalAgreement.LeaseType.DisplayName();
              
                lblDateAvailable.Text = _rentalAgreement.ContractPeriod;
                lblUnitNumber.Text = _rentalAgreement.OwnerAccount.UnitNumber;

                if (_rentalAgreement.LeaseType == LeaseType.DormType)
                {
                    txtRentAmount.Text = (_rentalAgreement.RentAmount / _rentalAgreement.MaxOccupant).ToString();
                    txtPrepaidRent.Text = (_rentalAgreement.PrepaidRent / _rentalAgreement.MaxOccupant).ToString();
                    txtSecurityDeposit.Text = (_rentalAgreement.SecurityDeposit / _rentalAgreement.MaxOccupant).ToString();
                }
                else
                {
                    txtRentAmount.Text = _rentalAgreement.RentAmount.ToString();
                    txtPrepaidRent.Text = _rentalAgreement.PrepaidRent.ToString();
                    txtSecurityDeposit.Text = _rentalAgreement.SecurityDeposit.ToString();
                }

                txtCashBond.Text = _rentalAgreement.CashBond.ToString();
                dtpApplicationDate.MinDate = _rentalAgreement.ContractStartDate;
                dtpContractStart.MaxDate = _rentalAgreement.ContractEndDate;
            }
        }

        public void LoadLeasePurpose(List<EnumItem> src)
        {
            cboLeasePurpose.DisplayMember = "Name";
            cboLeasePurpose.ValueMember = "Value";
            cboLeasePurpose.DataSource = src;
        }
        public SaveLeaseAgreementForm(SaveLeaseOption saveOption)
        {
            InitializeComponent();

            if (saveOption  == SaveLeaseOption.NewAgreement)
            {
                presenter = new NewLeaseAgreementPresenter(this);
            }
            else
            {
                presenter = new UpdateLeaseAgreementPresenter(this);
            }

        }

        private void NewLeaseAgreementForm_Load(object sender, EventArgs e)
        {
            txtRentAmount.KeyPress += Common.Decimal_KeyPress;
            txtPrepaidRent.KeyPress += Common.Decimal_KeyPress;
            txtSecurityDeposit.KeyPress += Common.Decimal_KeyPress;
            txtCashBond.KeyPress += Common.Decimal_KeyPress;

            dtpApplicationDate.MaxDate = DateTime.Now;
        }

        private void dtpApplicationDate_ValueChanged(object sender, EventArgs e)
        {
            dtpContractStart.MinDate = dtpApplicationDate.Value;
            dtpContractStart.Value = dtpApplicationDate.Value;
            dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Int32.Parse(nudMonthsTerm.Value.ToString())).AddDays(-1);
        }

        private void dtpContractStart_ValueChanged(object sender, EventArgs e)
        {
            dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Int32.Parse(nudMonthsTerm.Value.ToString())).AddDays(-1);
        }

        private void nudMonthsTerm_ValueChanged(object sender, EventArgs e)
        {
            dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Int32.Parse(nudMonthsTerm.Value.ToString())).AddDays(-1);
        }
   
        private void btnSelectRentalAgreement_Click(object sender, EventArgs e)
        {
            using (AgreementsSelectionForm frm = new AgreementsSelectionForm(new AvailableRentalUnitsPresenter() ))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RentalAgreement =  frm.Agreement as RentalAgreement;
                }
            }
        }  
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEntryValid()) { 
                 if (MessageBox.Show("Save Lease Agreement?", "Lease Agreement Save Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        presenter.SaveLeaseAgrement();
                    }           
            }
        }

        public void DisplayNewAgreementSaveStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Lease Agreement succesfully saved");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lease Agreement not succesfully saved");
            }
        }

        public void DisplayUpdateAgreementSaveStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Lease Agreement succesfully updated");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lease Agreement not succesfully updated");
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

            if ( this.RentalAgreement == null )
            {
                errorProvider1.SetError(btnSelectRentalAgreement, "Select Rental Agreement");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(btnSelectRentalAgreement, string.Empty);
            }
            return bValid;
        }
 
    }
}
