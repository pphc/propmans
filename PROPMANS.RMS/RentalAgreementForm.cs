using BCL.Common;
using BCL.RMS;
using ComponentFactory.Krypton.Toolkit;
using PROPMANS.ACCOUNT_SEARCH;
using PROPMANS.REPORTS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PROPMANS.RMS
{
    public partial class RentalAgreementForm : ComponentFactory.Krypton.Toolkit.KryptonForm ,
        IRentalAgreement
    {
        #region "Form Instance"
        private static RentalAgreementForm aForm;
        public static RentalAgreementForm Instance()
        {
            if (aForm == null)
            {
                aForm = new RentalAgreementForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        private RentalAgreementPresenter presenter;

        private BCL.Accounts.CustomerAccount _selectedAccount;
        public BCL.Accounts.CustomerAccount SelectedAccount
        {
            get {
                return _selectedAccount;
            }
            set {
                _selectedAccount = value;

                txtUnitNumber.Text = value.UnitNumber;
                txtLastName.Text = value.Owner.LastName;
                txtFirstName.Text = value.Owner.FirstName;
                txtMiddleName.Text = value.Owner.MiddleName; 
            }
        }

        private RentalAgreement _selectedRentalAgreement;
        public RentalAgreement SelectedRentalAgreement
        {
            get {
                _selectedRentalAgreement = (dgRentalAgreements.CurrentRow.DataBoundItem as RentalAgreementsGridDisplay).agreement;
                return _selectedRentalAgreement;
            }
            set {
                _selectedRentalAgreement = value;
                lblContractNumber.Text = value.ContractNo;

                dtpAgreementDate.Value = value.AgreementDate;
                nudNoOfMonths.Value = value.MonthsTerm;
                dtpContractStart.Value = value.ContractStartDate;
                dtpContractEnd.Value = value.ContractEndDate;

                cboUnitClassification.SelectedValue = (Int32)value.LeaseType;
                txtMaxOccupant.Text = value.MaxOccupant.ToString();

                txtRentAmount.Text = value.RentAmount.ToString();
                txtPrepaidRent.Text = value.PrepaidRent.ToString();
                txtSecurityDeposit.Text = value.SecurityDeposit.ToString();
                txtCashBond.Text = value.CashBond.ToString();

                txtMgmtRate.Text = value.MgmtRate.ToString();
                cboRemittanceRelease.SelectedValue = (Int32)value.RemitType;

                lblContractStatus.Text = value.ContractStatus.DisplayName();

                btnUpdateRentalAgreement.Enabled = value.ContractStatus == ContractStatus.ForApproval;
            }
        }

        public RentalActivity SelectedActivity
        {
            get { return (dgActivityHistory.CurrentRow.DataBoundItem as RentalActivityGridDisplay).activity; }
        }
        public RentalAgreementForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new RentalAgreementPresenter(this);
            kryptonGroupBox1.Enabled = false;
        }

        public void LoadDefaults()
        {
          txtUnitNumber.Text = string.Empty;
          txtLastName.Text = string.Empty;
          txtFirstName.Text = string.Empty;
          txtMiddleName.Text = string.Empty;
          txtNameSuffix.Text = string.Empty;
        }
      
        public void LoadLeaseType(List<EnumItem> src)
        {
            cboUnitClassification.DisplayMember = "Name";
            cboUnitClassification.ValueMember = "Value";
            cboUnitClassification.DataSource = src;
        }

        public void LoadRemitType(List<EnumItem> src)
        {
            cboRemittanceRelease.DisplayMember = "Name";
            cboRemittanceRelease.ValueMember = "Value";
            cboRemittanceRelease.DataSource = src;
        }

        public void LoadRentalAgreements(List<RentalAgreementsGridDisplay> rentalAgreements)
        {
            dgRentalAgreements.DataSource = rentalAgreements;
            kryptonGroupBox2.Visible = rentalAgreements.Count > 0;
            btnPreviewForm.Enabled = rentalAgreements.Count > 0;
            btnNewActivity.Enabled = rentalAgreements.Count > 0;
        }

        public void LoadLeases(List<UnitLeasesGridDisplay> leases)
        {
            dgLeases.DataSource = leases;
           
        }

        public void LoadRentalActivities(List<RentalActivityGridDisplay> activities)
        {
            dgActivityHistory.DataSource = activities;
            btnUpdateActivity.Enabled = activities.Count > 0;
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (AccountLookupForm frm = new AccountLookupForm(AccountLookupDisplay.ActiveUnitOwnerOnly))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.SelectedAccount = frm.SelectedAccount;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                    kryptonGroupBox1.Enabled = true;
                }
            }
        }

        private void dgRentalAgreements_SelectionChanged(object sender, EventArgs e)
        {
            var dg = sender as  KryptonDataGridView;

            if (dg.CurrentRow.DataBoundItem != null)
            {
                presenter.DisplaySelectedRentalAgreement();
            }
        }

        private void dgActivityHistory_SelectionChanged(object sender, EventArgs e)
        {
            var dg = sender as KryptonDataGridView;

            if (dg.CurrentRow.DataBoundItem != null)
            {
                btnUpdateActivity.Enabled = !((RentalActivityGridDisplay)dg.CurrentRow.DataBoundItem).activity.Type.IsSystemEvent;
            }
        }

        private void btnNewAgreement_Click(object sender, EventArgs e)
        {
            if (presenter.WithPendingorActiveAgreement()) {
                MessageBox.Show("Unit Owner has pending or active agreement", "Can't create new agreement", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            using (SaveRentalAgreementForm frm = new SaveRentalAgreementForm(SaveRentalOption.NewAgreement))
            {
                frm.UnitOwnerAccount = this.SelectedAccount;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                }
            }
        }  
        
        private void btnUpdateRentalAgreement_Click(object sender, EventArgs e)
        {
            using (SaveRentalAgreementForm frm = new SaveRentalAgreementForm(SaveRentalOption.UpdateAgreement))
            {
                frm.UnitOwnerAccount = this.SelectedAccount;
                frm.RentalAgreement = this.SelectedRentalAgreement;
                frm.Text = "UPDATE RENTAL AGREEMENT";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                }
            }
        } 
        
        private void btnPreviewForm_Click(object sender, EventArgs e)
        {
            KryptonContextMenu1.Show(sender);
        }

        private void PreviewRMA_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
             using ( var rps  = new REPORTS.ReportStore()){
                 var rep = new RentalManagementAgreementReport(SelectedRentalAgreement.ID);
                rps.LoadReport(rep);
             }
             this.UseWaitCursor = false;
        }

        private void PreviewSPA_Click(object sender, EventArgs e)
        {
              using ( var rps  = new REPORTS.ReportStore()){
                  var rep = new SpecialPowerOfAttorneyReport(SelectedRentalAgreement.ID);
                rps.LoadReport(rep);
              }
        }

        private void PreviewKeyTurnOver_Click(object sender, EventArgs e)
        {
              using ( var rps  = new REPORTS.ReportStore()){
                var rep = new KeyTurnOverReport(SelectedRentalAgreement.ID );
                rps.LoadReport(rep);
              }
        }

        private void btnNewActivity_Click(object sender, EventArgs e)
        {
            using (SaveActivityForm frm = new SaveActivityForm(new NewRentalActivityPresenter(),this.SelectedAccount))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnUpdateActivity_Click(object sender, EventArgs e)
        {
            using (SaveActivityForm frm = new SaveActivityForm(new UpdateRMAActivityPresenter(), this.SelectedAccount))
            {
                frm.Activity = this.SelectedActivity;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                }
            }
        }





        
    }
}
