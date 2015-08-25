using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;


namespace PROPMANS.RMS
{
    public partial class ContractAmendmentForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IContractAmendment
    {
        #region "Form Instance"
        private static ContractAmendmentForm aForm;
        public static ContractAmendmentForm Instance()
        {
            if (aForm == null)
            {
                aForm = new ContractAmendmentForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        private ContractAmendmentPresenter presenter;

        private ContractAmendment _rentalAmendment;
        public ContractAmendment RentalAmendment
        {
            get
            {
                return ((RentalAgreementAmendmentGridDisplay)dgRentalAgreements.CurrentRow.DataBoundItem).amendment;
            }
            set
            {
                _rentalAmendment = value;

                lblContractNo.Text = value.Agreement.ContractNo;
                lblUnitNumber.Text = value.Agreement.UnitNumber;
                lblUnitOwner.Text = value.Agreement.CustomerName;
                lblRequestDate.Text = value.RequestDate.ToString();
                lblAmendmentType.Text = value.AmendmentRequestType.DisplayName();
                lblRequestedBy.Text = value.RequestingParty.DisplayName();
                lblAmendmentDetails.Text = value.AmendmentDetails;
                lblEffectiveDate.Text = value.EffectiveDate.ToString();
                lblApprovalStatus.Text = value.ApprovalStatus.DisplayName();
                lblRequestNotes.Text = value.RequestNotes;
                lblApprovalNotes.Text = value.ApprovalNotes;

                btnUpdateRentalAmendment.Enabled = value.ApprovalStatus == ApprovalStatus.Pending;
               
               
            }
        }
       
        private ContractAmendment _leaseamendment;
        public ContractAmendment LeaseAmendment
        {
            get
            {
                return ((LeaseAmendmentGridDisplay)dgLeaseAgreements.CurrentRow.DataBoundItem).amendment;
            }
            set
            {
                _leaseamendment =value;
                lblLContractNo.Text = value.Agreement.ContractNo;
                lblLCUnitNumber.Text = value.Agreement.UnitNumber;
                lblLCTenant.Text = value.Agreement.CustomerName;
                lblLCRequestDate.Text = value.RequestDate.ToString();
                lblLCAmendmentType.Text = value.AmendmentRequestType.DisplayName();
                lblLCRequestedBy.Text = value.RequestingParty.DisplayName();
                lblLCAmendmentDetails.Text =value.AmendmentDetails;
                lblLCEffectiveDate.Text = value.EffectiveDate.ToString();
                lblLCApprovalStatus.Text = value.ApprovalStatus.DisplayName();
                lblLCRequestNotes.Text = value.RequestNotes;
                lblLCApprovalNotes.Text = value.ApprovalNotes;

                btnUpdateLeaseAmendment.Enabled = value.ApprovalStatus == ApprovalStatus.Pending;

            }
        }

        public void SetLeaseAmendmentDefaults()
        {
            lblLContractNo.Text = "NOT AVAILABLE";
            lblLCUnitNumber.Text = "NOT AVAILABLE";
            lblLCTenant.Text = "NOT AVAILABLE";
            lblLCRequestDate.Text = "NOT AVAILABLE";
            lblLCAmendmentType.Text = "NOT AVAILABLE";
            lblLCRequestedBy.Text = "NOT AVAILABLE";
            lblLCAmendmentDetails.Text = "NOT AVAILABLE";
            lblLCEffectiveDate.Text = "NOT AVAILABLE";
            lblLCApprovalStatus.Text = "NOT AVAILABLE";
            lblLCRequestNotes.Text = "NOT AVAILABLE";
            lblLCApprovalNotes.Text = "NOT AVAILABLE";
        }

        public void SetRentalAmendmentDefaults()
        {
            lblContractNo.Text = "NOT AVAILABLE";
            lblUnitNumber.Text = "NOT AVAILABLE";
            lblUnitOwner.Text = "NOT AVAILABLE";
            lblRequestDate.Text = "NOT AVAILABLE";
            lblAmendmentType.Text = "NOT AVAILABLE";
            lblRequestedBy.Text = "NOT AVAILABLE";
            lblAmendmentDetails.Text = "NOT AVAILABLE";
            lblEffectiveDate.Text = "NOT AVAILABLE";
            lblApprovalStatus.Text = "NOT AVAILABLE";
            lblRequestNotes.Text = "NOT AVAILABLE";
            lblApprovalNotes.Text = "NOT AVAILABLE";
        }

        public AmendmentType SelectedRentalAmendmentType
        {
            get { return (AmendmentType) cboRentalAmendmentType.SelectedValue; }
        }

        public AmendmentType SelectedLeaseAmendmentType
        {
            get { return (AmendmentType)cboLeaseAmendmentType.SelectedValue; }
        }
    
        public void LoadAmendTypeList(List<EnumItem> src)
        {
            cboRentalAmendmentType.DisplayMember = "Name";
            cboRentalAmendmentType.ValueMember = "Value";
            cboRentalAmendmentType.DataSource = src;

            cboLeaseAmendmentType.DisplayMember = "Name";
            cboLeaseAmendmentType.ValueMember = "Value";
            cboLeaseAmendmentType.DataSource = src;
        }

        public bool DisableRentalUpdate
        {
            set { btnUpdateRentalAmendment.Enabled = value; }
        }

        public bool DisableLeaseUpdate
        {
            set { btnUpdateLeaseAmendment.Enabled = value; }
        }

        public void LoadRentalAgreements(List<RentalAgreementAmendmentGridDisplay> rentalAgreements)
        {
            dgRentalAgreements.DataSource = rentalAgreements;
            RentalAmendmentCount = rentalAgreements.Count;
            DisableRentalUpdate = rentalAgreements.Count > 0;
        }

        public void LoadLeaseAgreements(List<LeaseAmendmentGridDisplay> leases)
        {
            dgLeaseAgreements.DataSource = leases;
            LeaseAmendmentCount = leases.Count;
            DisableLeaseUpdate = leases.Count > 0;
        }


        public int RentalAmendmentCount
        {
            set
            {
                if (value > 0)
                {
                    lblPendingRentalAgreement.Text = String.Format("{0} Contract Amendment/s", value);
                }
                else
                {
                    lblPendingRentalAgreement.Text = "No Contract Amendments";
                }
            }
        }

        public int LeaseAmendmentCount
        {
            set
            {
                if (value > 0)
                {
                    lblPendingLeaseAgreement.Text = String.Format("{0} Contract Amendment/s", value);
                }
                else
                {
                    lblPendingLeaseAgreement.Text = "No Contract Amendments";
                }
            }
        }


        public ContractAmendmentForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new ContractAmendmentPresenter(this);
            presenter.LoadRentalAmendments();
            presenter.LoadLeaseAmendments();
         
        }

        private void dgRentalAgreements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRentalAgreements.CurrentRow.DataBoundItem != null)
            {
                presenter.DisplaySelectedRentalAmendment();
            }
        }

        private void btnNewAmendment_Click(object sender, EventArgs e)
        {
            using (SaveAmendmentForm frm = new SaveAmendmentForm(new NewRentalAmendmentPresenter()))
            {

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    presenter.LoadRentalAmendments();
                }
            }
        }

        private void btnUpdateRentalAgreement_Click(object sender, EventArgs e)
        {
            using (SaveAmendmentForm frm = new SaveAmendmentForm(new UpdateRentalAmendmentPresenter()))
            {
                frm.Amendment = this.RentalAmendment;
                frm.btnSelectAgreement.Enabled = false;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    presenter.LoadRentalAmendments();
                }
            }

        }

        private void dgLeaseAgreements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgLeaseAgreements.CurrentRow.DataBoundItem != null)
            {
                presenter.DisplaySelectedLeaseAmendment();
            }
        }

        private void btnNewLeaseAmendment_Click(object sender, EventArgs e)
        {
            using (SaveAmendmentForm frm = new SaveAmendmentForm(new NewLeaseAmendmentPresenter()))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    presenter.LoadLeaseAmendments();
                }
            }
        }

        private void btnUpdateLeaseAmendment_Click(object sender, EventArgs e)
        {
            using (SaveAmendmentForm frm = new SaveAmendmentForm(new UpdateLeaseAmendmentPresenter()))
            {
                frm.Amendment = this.LeaseAmendment;
                frm.btnSelectAgreement.Enabled = false;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    presenter.LoadLeaseAmendments();
                }
            }
        }

        private void cboRentalAmendmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRentalAmendmentType.SelectedValue != null && presenter != null) {
                presenter.LoadRentalAmendments();
            }
        }

        private void cboLeaseAmendmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeaseAmendmentType.SelectedValue != null && presenter != null)
            {
                presenter.LoadLeaseAmendments();
            }
        }





       
    }

}
