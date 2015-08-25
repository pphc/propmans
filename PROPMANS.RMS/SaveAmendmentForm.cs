using BCL.Common;
using BCL.RMS;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.RMS
{


    public partial class SaveAmendmentForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        ISaveAmendment
    {
        private SaveAmendmentPresenter presenter;

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
                lblContractNo.Text = value.ContractNo;
                lblUnitNumber.Text = value.UnitNumber;
                lblUnitOwner.Text = value.CustomerName;
                lblLeaseType.Text = value.LeaseType.DisplayName();
                lblCOntractPeriod.Text = value.ContractPeriod;
                lblRentAmount.Text = value.RentAmount.ToString();
            }
        }

        private ContractAmendment _contractAmendment;
        public ContractAmendment Amendment
        {
            get {

                if (_contractAmendment == null) {
                    _contractAmendment = new ContractAmendment();
                }

                _contractAmendment.RequestDate = dtpRequestDate.Value;
                _contractAmendment.RequestingParty = (RequesterType)cboRequestBy.SelectedValue;
                _contractAmendment.AmendmentRequestType = (AmendmentType)cboRequestType.SelectedValue;
                _contractAmendment.RequestNotes = txtNotes.Text.Trim();

                var requestTYpe = (AmendmentType)cboRequestType.SelectedValue;

                if (requestTYpe == AmendmentType.RentalAmount)
                {
                    _contractAmendment.NewRate = Decimal.Parse(txtNewRentamount.Text);
                }
                else if (requestTYpe == AmendmentType.RentalExtension)
                {
                    _contractAmendment.NewEndDate = dtpNewContractEnd.Value.Date;
                }
                else
                {
                    _contractAmendment.EffectiveDate = dtpEffectiveDate.Value.Date;
                }

                _contractAmendment.Agreement = this.Agreement;

                return _contractAmendment;
            }
            set {
                _contractAmendment = value;


                this.Agreement = _contractAmendment.Agreement;

                dtpRequestDate.Value = value.RequestDate;
                cboRequestBy.SelectedValue = (int) value.RequestingParty;
                cboRequestType.SelectedValue = (int)value.AmendmentRequestType;
                txtNotes.Text = value.RequestNotes;

                var requestTYpe = (AmendmentType)cboRequestType.SelectedValue;
                if (requestTYpe == AmendmentType.RentalAmount)
                {
                    txtNewRentamount.Text = _contractAmendment.NewRate.ToString();
                }
                else if (requestTYpe == AmendmentType.RentalExtension)
                {
                    //TODO. get no fo months
                   // nudExtendMonths.Value = _contractAmendment.NewEndDate 
                    dtpNewContractEnd.Value = _contractAmendment.NewEndDate.Value;
                }
                else
                {
                    dtpEffectiveDate.Value = _contractAmendment.EffectiveDate.Value;
                }
            
            }
        }
       
        public SaveAmendmentForm(SaveAmendmentPresenter presenter)
        {
            InitializeComponent();
           
            txtNewRentamount.KeyPress += Common.Numeric_KeyPress;
            this.presenter = presenter;
            presenter.view = this;
            presenter.InitializeView();
        }
        
        public void SetViewTitleText()
        {
            this.Text = presenter.GetDialogueTitle();
            
        }
        
        public void LoadAmendmentRequestType(List<EnumItem> src)
        {
            cboRequestType.DisplayMember = "Name";
            cboRequestType.ValueMember = "Value";
            cboRequestType.DataSource = src;

        }
        
        public void LoadRequestingParty(List<EnumItem> src)
        {
            cboRequestBy.DisplayMember = "Name";
            cboRequestBy.ValueMember = "Value";
            cboRequestBy.DataSource = src;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEntryValid())
            {
                if (MessageBox.Show("Save Contract Amendment?", "Contract Ammendment Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    presenter.SaveAmendment();
                }      
            }
        }
      
        public void DisplayUpdateAmendmentStatus(bool success)
        {
            if (success)
            {
                MessageBox.Show("Contract Amendment succesfully updated");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contract Amendment not succesfully updated");
            }
        }

        public void DisplaySaveNewAmendmentStatus(bool success)
        {
            if (success)
            {
                MessageBox.Show("New Contract Amendment succesfully saved");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("New Contract Amendment not succesfully saved");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectAgreement_Click(object sender, EventArgs e)
        {
            if (presenter.ServiceType() == RentalServiceType.RentalAgreement)
            {
                using (AgreementsSelectionForm frm = new AgreementsSelectionForm(new ActiveRentalAgreementsPresenter()))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                            this.Agreement = frm.Agreement  as RentalAgreement;
                            dtpEffectiveDate.MaxDate = this.Agreement.ContractEndDate;
                    }
                }
            }
            else
            {
                using (AgreementsSelectionForm frm = new AgreementsSelectionForm(new ActiveLeaseAgreementsPresenter()))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Agreement = frm.Agreement as LeaseAgreement;
                    }
                }
            }
        }

        private void cboRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequestType.SelectedValue != null && presenter !=null)
            {
                var requestTYpe = (AmendmentType)cboRequestType.SelectedValue;

                NewRentAmtkryptonPanel.Visible = false;
                ExtendContractkryptonPanel.Visible = false;
                TerminateContractkryptonPanel.Visible = false;

                if (requestTYpe == AmendmentType.RentalAmount)
                {
                    NewRentAmtkryptonPanel.Visible = true;
                    txtNewRentamount.SelectAll();
                    txtNewRentamount.Focus();
                }

                if (requestTYpe == AmendmentType.RentalExtension)
                {
                    ExtendContractkryptonPanel.Visible = true;
                    nudExtendMonths.Focus();
                }

                if (requestTYpe == AmendmentType.Preterminatation)
                {
                    TerminateContractkryptonPanel.Visible = true;
                  //  dtpEffectiveDate.MaxDate = this.Amendment.Agreement.ContractEndDate;
                }
            }
    
        }
        private bool IsEntryValid()
        {
            bool bValid = true;

            errorProvider1.Clear();


            if (this.Agreement == null)
            {
                errorProvider1.SetError(lblContractNo, "Select Agreement");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(lblContractNo, string.Empty);
            }

            if ((AmendmentType)cboRequestType.SelectedValue == AmendmentType.RentalAmount)
            {
                if (String.IsNullOrWhiteSpace(txtNewRentamount.Text))
                {
                    errorProvider1.SetError(txtNewRentamount, "Enter New Rental Amount");
                    bValid = false;
                }
                else
                {
                    if (Decimal.Parse(txtNewRentamount.Text) <= 0)
                    {
                        errorProvider1.SetError(txtNewRentamount, "Enter Valid Rental Amount");
                        bValid = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txtNewRentamount, string.Empty);
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(txtNotes.Text))
            {
                errorProvider1.SetError(txtNotes, "Enter Request Notes");
                bValid = false;
            }
            else
            {
                errorProvider1.SetError(txtNotes, string.Empty);
            }

            return bValid;

        }
        private void nudExtendMonths_ValueChanged(object sender, EventArgs e)
        {
            int increment = Int32.Parse(nudExtendMonths.Value.ToString());

            dtpNewContractEnd.Value = this.Amendment.Agreement.ContractEndDate.AddMonths(increment);

        }

    
    }
}
