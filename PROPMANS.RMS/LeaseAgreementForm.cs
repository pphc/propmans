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
    public partial class LeaseAgreementForm : ComponentFactory.Krypton.Toolkit.KryptonForm ,
        ILeaseAgreement
    {
        #region "Form Instance"
        private static LeaseAgreementForm aForm;
        public static LeaseAgreementForm Instance()
        {
            if (aForm == null)
            {
                aForm = new LeaseAgreementForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        private LeaseAgreementPresenter presenter;

        private BCL.Accounts.Customer _tenantAccount;
        public BCL.Accounts.Customer TenantAccount
        {
            get {
                return _tenantAccount;
            }
            set {

                _tenantAccount = value;
                txtLastName.Text = value.LastName;
                txtFirstName.Text = value.FirstName;
                txtMiddleName.Text = value.MiddleName; 
            }
        }

        private LeaseAgreement _selectedLeaseAgreement;
        public LeaseAgreement SelectedLeaseAgreement
        {
            get { 
                _selectedLeaseAgreement =  (dgLeaseAgreements.CurrentRow.DataBoundItem as LeaseAgreementGridDisplay).agreement;            
                return  _selectedLeaseAgreement; 
            }
            set {
                _selectedLeaseAgreement = value;

                lblContractNumber.Text = value.ContractNo;

                lblUnitNumber.Text = value.RentalAgreement.OwnerAccount.UnitNumber;
                lblLeaseType.Text = value.LeaseType.DisplayName();
                lblLeasePurpose.Text = value.LeasePurpose.DisplayName();

                dtpAgreementDate.Value = value.AgreementDate;
                nudNoOfMonths.Value = value.MonthsTerm;
                dtpContractStart.Value = value.ContractStartDate;
                dtpContractEnd.Value = value.ContractEndDate;

                txtRentAmount.Text = value.RentAmount.ToString();
                txtPrepaidRent.Text = value.PrepaidRent.ToString();
                txtSecurityDeposit.Text = value.SecurityDeposit.ToString();
                txtCashBond.Text = value.CashBond.ToString();

                lblContractStatus.Text = value.ContractStatus.DisplayName();

                btnUpdateLeaseAgreement.Enabled = value.ContractStatus == ContractStatus.ForApproval;
            }
        }
        
        public RentalActivity SelectedActivity
        {
            get { return (dgLeaseActivities.CurrentRow.DataBoundItem as RentalActivityGridDisplay).activity; }
        }

        public RentalBillingType SelectedBillingType
        {
            get { return (RentalBillingType)cboBillinType.SelectedValue; }
        }

        public LeaseAgreementForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new LeaseAgreementPresenter(this);
            kryptonGroupBox1.Enabled = false;
        }

        public void LoadDefaults()
        {
          txtLastName.Text = string.Empty;
          txtFirstName.Text = string.Empty;
          txtMiddleName.Text = string.Empty;
          txtNameSuffix.Text = string.Empty;
        }

        public void LoadLeaseAgreements(List<LeaseAgreementGridDisplay> agreements)
        {
            dgLeaseAgreements.DataSource = agreements;
            kryptonGroupBox2.Visible =agreements.Count > 0;
            btnPreviewForm.Enabled = agreements.Count > 0;
            btnNewActivity.Enabled = agreements.Count > 0;
        }

        public void LoadLeaseActivities(List<RentalActivityGridDisplay> activities)
        {
            dgLeaseActivities.DataSource = activities;
            btnUpdateActivity.Enabled = activities.Count > 0;
        }

        private void dgLeaseAgreements_SelectionChanged(object sender, EventArgs e)
        {
            var dg = sender as KryptonDataGridView;

            if (dg.CurrentRow.DataBoundItem != null)
            {
                presenter.DisplaySelectedLeaseAgreement();
            }
        }

        private void dgLeaseActivities_SelectionChanged(object sender, EventArgs e)
        {
            var dg = sender as KryptonDataGridView;

            if (dg.CurrentRow.DataBoundItem != null)
            {
                btnUpdateActivity.Enabled = !((RentalActivityGridDisplay)dg.CurrentRow.DataBoundItem).activity.Type.IsSystemEvent;
            }
        }

        public void LoadBillingType(List<EnumItem> src)
        {
            cboBillinType.DisplayMember = "Name";
            cboBillinType.ValueMember  = "Value";
            cboBillinType.DataSource = src;
        }

        private void cboBillinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBillinType.SelectedValue != null && presenter != null)
            {
                presenter.ShowBillings();
            }
        }
        public void LoadRentalBillings(List<LeaseBillingGridDisplay> billings)
        {
            dgLeaseBillings.DataSource = billings;
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (AccountLookupForm frm = new AccountLookupForm(AccountLookupDisplay.CUstomerOnly))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.TenantAccount = frm.SelectedCustomer;

                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                    kryptonGroupBox1.Enabled = true;
                }
            }
        }
        private void btnNewAgreement_Click(object sender, EventArgs e)
        {
            if (presenter.WithPendingorActiveAgreement())
            {
                MessageBox.Show("Tenant has pending or active agreement", "Can't create new agreement", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            using (SaveLeaseAgreementForm frm = new SaveLeaseAgreementForm(SaveLeaseOption.NewAgreement))
            {
               frm.Tenant = this.TenantAccount;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    presenter.LoadAccountDetails();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnUpdateLeaseAgreement_Click_1(object sender, EventArgs e)
        {
            using (SaveLeaseAgreementForm frm = new SaveLeaseAgreementForm(SaveLeaseOption.UpdateAgreement))
            {
                frm.Tenant = this.TenantAccount;
                frm.LeaseAgreement = this.SelectedLeaseAgreement;
            //    frm.RentalAgreement = this.SelectedLeaseAgreement.RentalAgreement;
                frm.Text = "UPDATE LEASE AGREEMENT";
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

        private void PreviewLeaseContract_Click(object sender, EventArgs e)
        {
             using ( var rps  = new REPORTS.ReportStore()){
                 var rep = new ContractOfLeaseReport(SelectedLeaseAgreement.ID);
                rps.LoadReport(rep);
             }
        }

        private void PreviewKeyTurnOver_Click_1(object sender, EventArgs e)
        {
             using ( var rps  = new REPORTS.ReportStore()){
                 var rep = new KeyTenantTurnOverReport(SelectedLeaseAgreement.ID);
                rps.LoadReport(rep);
             }
        }

        private void btnNewActivity_Click(object sender, EventArgs e)
        {
            using (SaveActivityForm frm = new SaveActivityForm(new NewLeaseActivityPresenter(), this.TenantAccount))
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
            using (SaveActivityForm frm = new SaveActivityForm(new UpdateLeaseActivityPresenter(), this.TenantAccount))
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
