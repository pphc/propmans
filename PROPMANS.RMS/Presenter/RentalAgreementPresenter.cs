using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PROPMANS.RMS
{
    public class RentalAgreementPresenter
    {
        private IRentalAgreement view; 
        private RMSDA da = new RMSDA();

        public RentalAgreementPresenter(IRentalAgreement view)
        { 
            this.view = view;

            view.LoadDefaults();

            view.LoadLeaseType(LeaseType.Bare.ItemList(false, true));
            view.LoadRemitType(RemitType.ATM.ItemList(false, true));
        }

        public void LoadAccountDetails()
        {
            view.LoadRentalAgreements(this.GetRentalAgreements());
            view.LoadLeases(this.GetLeases());
            view.LoadRentalActivities(this.GetRentalActivities());
        }

        private List<RentalAgreementsGridDisplay> GetRentalAgreements() {
            var display = new List<RentalAgreementsGridDisplay>();

            foreach (RentalAgreement rma in da.LoadRentalAgreementsByAccountID(view.SelectedAccount.AccountID))
            {
                display.Add(new RentalAgreementsGridDisplay(rma));
            }

            return display;
        }

        private List<UnitLeasesGridDisplay> GetLeases()
        {
            var display = new List<UnitLeasesGridDisplay>();

            foreach (LeaseAgreement col in da.LoadLeasesByAccountID(view.SelectedAccount.AccountID))
            {
                display.Add(new UnitLeasesGridDisplay(col));
            }

            return display;
        }

        private List<RentalActivityGridDisplay> GetRentalActivities()
        {
            var display = new List<RentalActivityGridDisplay>();

            foreach (RentalActivity act in da.LoadRentalAgreementActivities(view.SelectedAccount.AccountID))
            {
                display.Add(new RentalActivityGridDisplay(act));
            }

            return display;
        }



        public void DisplaySelectedRentalAgreement()
        {
            view.SelectedRentalAgreement = view.SelectedRentalAgreement;
        }

        public bool WithPendingorActiveAgreement()
        {
            var count = (from ag in da.RentalAgreements
                         where ag.ContractStatus == ContractStatus.ForApproval || ag.ContractStatus == ContractStatus.Active || ag.ContractStatus == ContractStatus.ChangeTerms 
                         select ag).Count();

            return count > 0;
        }

    }

    public class RentalAgreementsGridDisplay
    {
        public readonly RentalAgreement agreement;
        public RentalAgreementsGridDisplay(RentalAgreement rentalAgreement)
        {
            agreement = rentalAgreement;
        }

        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.agreement.ContractNo; }
        }
        [DisplayName("LEASE TYPE")]
        public string LeaseType
        {
            get { return this.agreement.LeaseType.DisplayName(); }
        }
        [DisplayName("START")]
        public System.DateTime ContractStart
        {
            get { return this.agreement.ContractStartDate; }
        }

        [DisplayName("END")]
        public System.DateTime ContractEnd
        {
            get { return this.agreement.ContractEndDate; }
        }
        [DisplayName("RENT AMOUNT")]
        public decimal RentAmount
        {
            get { return this.agreement.RentAmount; }
        }
        [DisplayName("STATUS")]
        public string ContractStatus
        {
            get { return this.agreement.ContractStatus.DisplayName(); }
        }
        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return this.agreement.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return this.agreement.CreatedOn; }
        }
        [DisplayName("UPDATED BY")]
        public string UpdatedBy
        {
            get { return this.agreement.UpdatedBy; }
        }
        [DisplayName("UPDATED ON")]
        public Nullable<System.DateTime> UpdatedOn
        {
            get { return this.agreement.UpdatedOn; }
        }
    }

    public class UnitLeasesGridDisplay
    {
        public readonly LeaseAgreement lease;
        public UnitLeasesGridDisplay(LeaseAgreement leaseagreement)
        {
            lease = leaseagreement;
        }

        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.lease.ContractNo; }
        }
        [DisplayName("TENANT NAME")]
        public string TenantName
        {
            get { return this.lease.Tenant.FullNameLastNameFirst; }
        }
        [DisplayName("LEASE TYPE")]
        public string LeaseType
        {
            get { return this.lease.LeaseType.DisplayName(); }
        }
        [DisplayName("START")]
        public System.DateTime ContractStart
        {
            get { return this.lease.ContractStartDate; }
        }

        [DisplayName("END")]
        public System.DateTime ContractEnd
        {
            get { return this.lease.ContractEndDate; }
        }
        [DisplayName("RENT AMOUNT")]
        public decimal RentAmount
        {
            get { return this.lease.RentAmount; }
        }
        [DisplayName("DEPOSIT AMOUNT")]
        public decimal DepositAmount
        {
            get { return this.lease.SecurityDeposit; }
        }
        [DisplayName("CASH BOND")]
        public decimal CashBond
        {
            get { return this.lease.CashBond; }
        }
        [DisplayName("STATUS")]
        public string ContractStatus
        {
            get { return this.lease.ContractStatus.DisplayName(); }
        }
        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return this.lease.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return this.lease.CreatedOn; }
        }
        [DisplayName("UPDATED BY")]
        public string UpdatedBy
        {
            get { return this.lease.UpdatedBy; }
        }
        [DisplayName("UPDATED ON")]
        public Nullable<System.DateTime> UpdatedOn
        {
            get { return this.lease.UpdatedOn; }
        }
    }

    public class RentalActivityGridDisplay
    {
        public readonly RentalActivity activity;
        public RentalActivityGridDisplay(RentalActivity activity)
        {
            this.activity = activity;
        }

        [DisplayName("AGREEMENT/CONTRACT")]
        public string ContractNo
        {
            get { return this.activity.Agreement.ContractNo; }
        }


        [DisplayName("ACTIVITY DATE")]
        public DateTime ActivityDate
        {
            get { return this.activity.ActivityDate; }
        }
        [DisplayName("ACTIVITY TYPE")]
        public string ActivityType
        {
            get { return this.activity.Type.ActivityName; }
        }
        [DisplayName("DETAILS")]
        public string ActivityDetails
        {
            get { return this.activity.Notes; }
        }
        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return this.activity.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public DateTime CreatedOn
        {
            get { return this.activity.CreatedOn; }
        }

        [DisplayName("UPDATED BY")]
        public string UpdatedBy
        {
            get { return this.activity.UpdatedBy; }
        }
        [DisplayName("UPDATED ON")]
        public DateTime? UpdatedOn
        {
            get { return this.activity.UpdatedOn; }
        }
    }
}
