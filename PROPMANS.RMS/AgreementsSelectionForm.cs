using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public partial class AgreementsSelectionForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IAgreementSelection
    {
        private AgreementsSelectionPresenter presenter;

        public string DialogueTitleCaption
        {
            set { this.Text = value; }
        }

        public int AvailableUnitsCount
        {
            set
            {
                if (value > 0)
                {
                    lblAvailableUnitforRent.Text = String.Format("{0} Agreement/s Found", value);
                }
                else { 
                 lblAvailableUnitforRent.Text = "No Records Found";
                }
            }
        }

        public RentalServiceAgreement Agreement
        {
            get { return (dgRentalAgreements.CurrentRow.DataBoundItem as AgreementsSelectionGridDisplay).agreement; }
        }

        public LeaseType SelectedLeaseType
        {
            get { return (LeaseType)cboLeaseType.SelectedValue; }
        }

        public AgreementsSelectionForm(AgreementsSelectionPresenter presenter) {
            InitializeComponent();

            this.presenter = presenter;
            this.presenter.view = this;
            this.presenter.Initialize();
        }

        public void LoadLeaseType(List<EnumItem> src)
        {
            cboLeaseType.DisplayMember ="Name";
            cboLeaseType.ValueMember = "Value";
            cboLeaseType.DataSource = src;
        }

        private void cboLeaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeaseType.SelectedItem != null && presenter !=null)
            {
                presenter.LeaseTypeChanged();
            }
        }

        public void LoadAvailableRentalUnits(List<AvailableUnitsForRentGridDisplay> agreements)
        {
            dgRentalAgreements.DataSource = agreements;
            btnSelect.Enabled = agreements.Count > 0;
        }

        public void LoadActiveRentalAgreements(List<ActiveRentalAgreementsGridDisplay> agreements)
        {
            dgRentalAgreements.DataSource = agreements;
            btnSelect.Enabled = agreements.Count > 0;
        }

        public void LoadActiveLeaseAgreements(List<ActiveLeaseAgreementsGridDisplay> agreements)
        {
            dgRentalAgreements.DataSource = agreements;
            btnSelect.Enabled = agreements.Count > 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }    
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.Close();
        }
       
    }
}
