using BCL.Common;
using BCL.RMS;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.RMS
{
    public enum SaveRentalOption
    { 
      NewAgreement,UpdateAgreement
    }
    public partial class SaveRentalAgreementForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        ISaveRentalAgreement
    {
        private SaveRentalAgreementPresenter presenter;

        public string SetViewTitle
        {
            set { this.Text = value; }
        }

        private BCL.Accounts.CustomerAccount _unitOwnerAccount;
        public BCL.Accounts.CustomerAccount UnitOwnerAccount
        {
            get {
                return _unitOwnerAccount;
            }
            set {
                txtUnitNumber.Text = value.UnitNumber;
                txtunitOwner.Text = value.Owner.FullNameLastNameFirst;
                txtunitType.Text = value.UnitType.DisplayName();
                _unitOwnerAccount = value;
            }
        }
        private RentalAgreement _rentalAgreement;
        public RentalAgreement RentalAgreement
        {
            get{

                if (_rentalAgreement == null)
                {
                    _rentalAgreement = new RentalAgreement();
                }

                _rentalAgreement.AgreementDate = dtpAgreementDate.Value.Date;
                _rentalAgreement.LeaseType = (LeaseType)cboUnitClassification.SelectedValue;

                _rentalAgreement.ContractStartDate = dtpContractStart.Value.Date;
                _rentalAgreement.ContractEndDate = dtpContractEnd.Value.Date;
                _rentalAgreement.MonthsTerm = Int32.Parse(nudNoOfMonths.Value.ToString());

                _rentalAgreement.MaxOccupant = Int32.Parse(txtMaxOccupant.Text);
                _rentalAgreement.RentAmount = Decimal.Parse(txtRentAmount.Text);
                _rentalAgreement.PrepaidRent = Decimal.Parse(txtPrepaidRent.Text);
                _rentalAgreement.SecurityDeposit = Decimal.Parse(txtSecurityDeposit.Text);

                if (!String.IsNullOrEmpty(txtCashBond.Text))
                {
                    _rentalAgreement.CashBond = Decimal.Parse(txtCashBond.Text);
                }

                _rentalAgreement.MgmtRate = Decimal.Parse(txtMgmtRate.Text);
                _rentalAgreement.RemitType = (RemitType)cboRemittanceRelease.SelectedValue;

                return _rentalAgreement;
            }
            set {
                _rentalAgreement = value;
                //set values
                lblContractNumber.Text = _rentalAgreement.ContractNo;

                dtpAgreementDate.Value = _rentalAgreement.AgreementDate;
                nudNoOfMonths.Value = _rentalAgreement.MonthsTerm;
                dtpContractStart.Value = _rentalAgreement.ContractStartDate;
                dtpContractEnd.Value = _rentalAgreement.ContractEndDate;

                cboUnitClassification.SelectedValue = (Int32)_rentalAgreement.LeaseType;
                txtMaxOccupant.Text = _rentalAgreement.MaxOccupant.ToString();

                txtRentAmount.Text = _rentalAgreement.RentAmount.ToString();
                txtPrepaidRent.Text = _rentalAgreement.PrepaidRent.ToString();
                txtSecurityDeposit.Text = _rentalAgreement.SecurityDeposit.ToString();
                txtCashBond.Text = _rentalAgreement.CashBond.ToString();

                txtMgmtRate.Text = _rentalAgreement.MgmtRate.ToString();

                cboRemittanceRelease.SelectedValue = (Int32)_rentalAgreement.RemitType;
            }
        }
        public SaveRentalAgreementForm(SaveRentalOption saveoption)
        {
            InitializeComponent();
            if (saveoption == SaveRentalOption.NewAgreement)
            {
                presenter = new NewRentalAgreementPresenter(this);
            }
            else {
                presenter = new UpdateRentalAgreementPresenter(this);
            }
        }
 
        private void NewRentalAgreementForm_Load(object sender, EventArgs e)
        {
           txtMaxOccupant.KeyPress += Common.Numeric_KeyPress;
           txtRentAmount.KeyPress += Common.Decimal_KeyPress;
           txtPrepaidRent.KeyPress += Common.Decimal_KeyPress;
           txtSecurityDeposit.KeyPress += Common.Decimal_KeyPress;
           txtCashBond.KeyPress += Common.Decimal_KeyPress;
           txtMgmtRate.KeyPress += Common.Decimal_KeyPress;
           
           dtpAgreementDate_ValueChanged(this, null);
        }

        public void LoadLeaseType(List<EnumItem> src)
        {
            cboUnitClassification.DisplayMember = "Name";
            cboUnitClassification.ValueMember  = "Value";
            cboUnitClassification.DataSource = src;
        }

        public void LoadRemitType(List<EnumItem> src)
        {
            cboRemittanceRelease.DisplayMember = "Name";
            cboRemittanceRelease.ValueMember = "Value";
            cboRemittanceRelease.DataSource = src;
        }

        private void nudNoOfMonths_ValueChanged(object sender, EventArgs e)
        {
              dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Int32.Parse(nudNoOfMonths.Value.ToString())).AddDays(-1);
        }

        private void dtpAgreementDate_ValueChanged(object sender, EventArgs e)
        {
              dtpContractStart.Value = dtpAgreementDate.Value;
              dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Int32.Parse(nudNoOfMonths.Value.ToString())).AddDays(-1);
        }

        private void txtRentAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRentAmount.Text))
            {
                Decimal rentAmount = Decimal.Parse(txtRentAmount.Text);
                txtPrepaidRent.Text = rentAmount.ToString();
                txtSecurityDeposit.Text = (rentAmount * 2).ToString();
            }
            else
            {
                txtPrepaidRent.Text = String.Empty;
                txtSecurityDeposit.Text = String.Empty;
            }
        }
       
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEntryValid())
            {
             if (MessageBox.Show("Save Rental Agreement?", "Rental Agreement Save Confirmation",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    presenter.SaveRentalAgrement();
                }
            
            }
        }

        public void DisplayNewAgreementSaveStatus(bool successful)
        {
            if (successful) { 
              MessageBox.Show("Rental Agreement succesfully saved");
              this.DialogResult = System.Windows.Forms.DialogResult.OK;
              this.Close();
            }
            else
            {
              MessageBox.Show("Rental Agreement not succesfully saved");
            }
        }

        public void DisplayUpdateAgreementSaveStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Rental Agreement succesfully updated");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Rental Agreement not succesfully updated");
            }
        }
  
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cboUnitClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnitClassification.SelectedValue != null)
            {
                if ((LeaseType)cboUnitClassification.SelectedValue == LeaseType.DormType)
                {
                    txtCashBond.Enabled = true;
                }
                else
                {
                    txtCashBond.Enabled = false;
                    txtCashBond.Text = String.Empty;
                }
            }


        }

        private bool IsEntryValid()
        { 
          bool bValid = true;

            errorProvider1.Clear();

            if ( ! Common.HasValue(txtRentAmount)){
                errorProvider1.SetError(txtRentAmount, "Enter value for Rent");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtRentAmount, string.Empty);
            }
            
            
            if ( ! Common.HasValue(txtMaxOccupant)){
                errorProvider1.SetError(txtMaxOccupant, "Enter value for Max Occupant");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtMaxOccupant, string.Empty);
            }

            if ((LeaseType)cboUnitClassification.SelectedValue == LeaseType.DormType)
                {
                    if (!Common.HasValue(txtCashBond)  )
                    {
    
                             errorProvider1.SetError(txtCashBond, "Enter value for Cash Bond");
                             bValid = false;
                    }
                    else
                    {
                        if (Double.Parse(txtCashBond.Text) <= 0)
                        {
                            errorProvider1.SetError(txtCashBond, "Cash Bond cannot be zero");
                            bValid = false;
                        }
                        else
                        {
                            errorProvider1.SetError(txtCashBond, string.Empty);
                        }
                    }
                }

            if (!Common.HasValue(txtMgmtRate))
            {
                errorProvider1.SetError(txtMgmtRate, "Enter value for Management Rate");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtMgmtRate, string.Empty);
            }

            return bValid;
        
        }
    
    }
}
