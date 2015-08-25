using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PROPMANS.RMS
{
    public partial class AgreementsPendingApprovalForm : ComponentFactory.Krypton.Toolkit.KryptonForm ,
        IAgreementPendingApproval
    {
        #region "Form Instance"
        private static AgreementsPendingApprovalForm aForm;
        public static AgreementsPendingApprovalForm Instance()
        {
            if (aForm == null)
            {
                aForm = new AgreementsPendingApprovalForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        private AgreementPendingApprovalPresenter presenter;

        public AmendmentType RentalRequestType
        {
            get { return (AmendmentType)cboRentalApprovalType.SelectedValue; }
        }
        public AmendmentType LeaseRequestType
        {
            get { return (AmendmentType)cboLeaseApprovalType.SelectedValue; }
        }
   
        public int PendingRentalAgreementCount
        {
            set { 
                if (value > 0 ){
                    lblPendingRentalAgreement.Text = String.Format("{0} Pending Approval/s",value);
                }
                else
                {
                    lblPendingRentalAgreement.Text = "No Pending Approvals";
                }
                }
        }
        public int PendingLeaseAgreementCount
        {
            set
            {
                if (value > 0)
                {
                    lblPendingLeaseAgreement.Text = String.Format("{0} Pending Approval/s", value);
                }
                else
                {
                    lblPendingLeaseAgreement.Text = "No Pending Approvals";
                }
            }
        }

        public AgreementsPendingApprovalForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new AgreementPendingApprovalPresenter(this);
        }

        public void LoadAmendTypeList(List<EnumItem> src)
        {
            cboRentalApprovalType.DisplayMember = "Name";
            cboRentalApprovalType.ValueMember  = "Value";
            cboRentalApprovalType.DataSource = src;

            cboLeaseApprovalType.DisplayMember = "Name";
            cboLeaseApprovalType.ValueMember = "Value";
            cboLeaseApprovalType.DataSource = src;
        }

        public void DisplayRentalAgreements(List<PendingRentalAgreementGridDisplay> agreements)
        {
            dgRentalAgreements.DataSource = agreements;
        }

        public void DisplayLeaseAgreements(List<PendingLeaseAgreementGridDisplay> contracts)
        {
            dgLeaseAgreements.DataSource = contracts;
        }

        private void btnUpdateRentalAgreement_Click(object sender, EventArgs e)
        {
            if (GetSelectedRentalAgreements().Count > 0)
            {
                using (UpdateAgreementApprovalForm frm = new UpdateAgreementApprovalForm())
                {
                    frm.ContractAmendment = GetSelectedRentalAgreements();
                    frm.isRentalAmendment = true;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        presenter.LoadPendingRentalAgreements();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else {
                MessageBox.Show("Select Agreements to update", "No Agreements Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<ContractAmendment> GetSelectedRentalAgreements()
        {
            List<ContractAmendment> aggrements = new List<ContractAmendment>();
            foreach (DataGridViewRow row in dgRentalAgreements.Rows)
            {
                if (((PendingRentalAgreementGridDisplay)row.DataBoundItem).Selected)
                {
                    aggrements.Add(((PendingRentalAgreementGridDisplay)row.DataBoundItem).amendment );
                }
            }
            return aggrements;
        }

        private void btnUpdateLeaseAgreement_Click(object sender, EventArgs e)
        {
            if (GetSelectedLeaseAgreements().Count > 0)
            {
                using (UpdateAgreementApprovalForm frm = new UpdateAgreementApprovalForm())
                {
                    frm.ContractAmendment = GetSelectedLeaseAgreements();
                    frm.isRentalAmendment = false;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        presenter.LoadPendingLeaseAgreements();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Agreements to update", "No Agreements Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<ContractAmendment> GetSelectedLeaseAgreements()
        {
            List<ContractAmendment> aggrements = new List<ContractAmendment>();
            foreach (DataGridViewRow row in dgLeaseAgreements.Rows)
            {
                if (((PendingLeaseAgreementGridDisplay)row.DataBoundItem).Selected)
                {
                    aggrements.Add(((PendingLeaseAgreementGridDisplay)row.DataBoundItem).amendment);
                }
            }
            return aggrements;
        }

        private void cboRentalApprovalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRentalApprovalType.SelectedValue != null && presenter != null)
            {
                presenter.LoadPendingRentalAgreements();
            }
        }

        private void cboLeaseApprovalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeaseApprovalType.SelectedValue != null && presenter != null)
            {
                presenter.LoadPendingLeaseAgreements();
            }
        }

    }
}
