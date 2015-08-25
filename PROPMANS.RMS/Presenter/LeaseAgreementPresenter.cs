using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PROPMANS.RMS
{
    public class LeaseAgreementPresenter
    {
        private ILeaseAgreement view;
        private RMSDA da = new RMSDA();

        public LeaseAgreementPresenter(ILeaseAgreement view)
        { 
            this.view = view;
            view.LoadDefaults();
            view.LoadBillingType(RentalBillingType.Rentals.ItemList(false,true));
           
        }

        public void LoadAccountDetails()
        {
            view.LoadLeaseAgreements(this.GetLeaseAgreements());
            view.LoadLeaseActivities(this.GetLeaseActivities());
        }

        private List<LeaseAgreementGridDisplay> GetLeaseAgreements()
        {
            List<LeaseAgreementGridDisplay> display = new List<LeaseAgreementGridDisplay>();

            foreach (LeaseAgreement la in da.LoadLeaseAgreementsByCustID(view.TenantAccount.CustomerID))
            {
                display.Add(new LeaseAgreementGridDisplay(la));
            }

            return display;
        }

        private List<LeaseBillingGridDisplay> GetLeaseBillings()
        {
            List<LeaseBillingGridDisplay> display = new List<LeaseBillingGridDisplay>();

            foreach (Billing la in da.LoadRentalBillings( view.SelectedLeaseAgreement.ID))
            {
                display.Add(new LeaseBillingGridDisplay(la));
            }

            return display;
        }

        private List<LeaseBillingGridDisplay> GetLeaseDeposits()
        {
            List<LeaseBillingGridDisplay> display = new List<LeaseBillingGridDisplay>();

            foreach (Billing la in da.LoadLeaseDeposits(view.SelectedLeaseAgreement.ID))
            {
                display.Add(new LeaseBillingGridDisplay(la));
            }

            return display;
        }

        private List<RentalActivityGridDisplay> GetLeaseActivities()
        {
            List<RentalActivityGridDisplay> display = new List<RentalActivityGridDisplay>();

            foreach (RentalActivity act in da.LoadLeaseContractActivities(view.TenantAccount.CustomerID))
            {
                display.Add(new RentalActivityGridDisplay(act));
            }

            return display;
        }

        public void DisplaySelectedLeaseAgreement()
        {
            view.SelectedLeaseAgreement = view.SelectedLeaseAgreement;
            ShowBillings();
        }

        public void ShowBillings() {

            if (view.SelectedBillingType == RentalBillingType.Rentals) {

                view.LoadRentalBillings(this.GetLeaseBillings());
            }
            else {
                view.LoadRentalBillings(this.GetLeaseDeposits());
            }
        
        }

        public bool WithPendingorActiveAgreement()
        {
            var count = (from ag in da.LeaseAgreements
                         where ag.ContractStatus == ContractStatus.ForApproval || ag.ContractStatus == ContractStatus.Active || ag.ContractStatus == ContractStatus.ChangeTerms 
                         select ag).Count();
            return count > 0;
        }
    }

    public class LeaseAgreementGridDisplay
    {
        public readonly LeaseAgreement agreement;
        public LeaseAgreementGridDisplay(LeaseAgreement agreement)
        {
            this.agreement = agreement;
        }
        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.agreement.ContractNo; }
        }
        [DisplayName("UNIT NUMBER")]
        public string CustUnitNumber
        {
            get
            {
                return this.agreement.RentalAgreement.OwnerAccount.UnitNumber;
            }
        }

        [DisplayName("LEASE TYPE")]
        public string LeaseType
        {
            get { return this.agreement.LeaseType.DisplayName(); }
        }

        [DisplayName("APPLICATION DATE")]
        public DateTime ApplicationDate
        {
            get { return this.agreement.AgreementDate; }
        }

        [DisplayName("START")]
        public System.DateTime ContractStart
        {
            get { return this.agreement.ContractStartDate; }
        }
        [DisplayName("END")]
        public DateTime ContractEnd
        {
            get { return this.agreement.ContractEndDate; }
        }
        [DisplayName("RENT AMOUNT")]
        public decimal RentAmount
        {
            get { return this.agreement.RentAmount; }
        }
        [DisplayName("DEPOSIT")]
        public decimal Deposit
        {
            get { return this.agreement.SecurityDeposit; }
        }
        [DisplayName("CASH BOND")]
        public decimal CashBond
        {
            get { return this.agreement.CashBond; }
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
        public DateTime CreatedOn
        {
            get { return this.agreement.CreatedOn; }
        }
        [DisplayName("UPDATED BY")]
        public string UpdatedBy
        {
            get { return this.agreement.UpdatedBy; }
        }
        [DisplayName("UPDATED ON")]
        public DateTime? UpdatedOn
        {
            get { return this.agreement.UpdatedOn; }
        }

    }

    public class LeaseBillingGridDisplay
    {
        public readonly Billing bill;
        public LeaseBillingGridDisplay(Billing bill)
        {
            this.bill = bill;
        }

        [DisplayName("FEE NAME")]
        public string FeeName
        {
            get { return bill.FeeName; }
        }

        [DisplayName("BILLING MONTH")]
        public string BillingMonth
        {
            get { return bill.BillDate.ToString("MMMM yyyy").ToUpper(); }
        }
        [DisplayName("COVERED PERIOD")]
        public string CoveredPeriod
        {
            get { return bill.CoveredPeriod; }
        }

        [DisplayName("STATEMENT DATE")]
        public string StatementDate
        {
            get { return bill.BillStatementDate.ToString("MM/dd/yyyy"); }
        }
        [DisplayName("DUE DATE")]
        public string DueDate
        {
            get { return bill.BillDueDate.ToString("MM/dd/yyyy"); }
        }
        [DisplayName("AMOUNT DUE")]
        public string AmountDue
        {
            get { return bill.AmountDue.ToString("#,##0.00"); }
        }

        [DisplayName("PENALTY AMOUNT")]
        public string PenaltyAmt
        {
            get { return bill.PenaltyAmount.ToString("#,##0.00"); }
        }
        [DisplayName("TOTAL DUE")]
        public string TotalDue
        {
            get { return bill.AmountDue.ToString("#,##0.00"); }
        }
        [DisplayName("AMOUNT PAID")]
        public string AmountPaid
        {
            get { return bill.AmountPaid.ToString("#,##0.00"); }
        }
        [DisplayName("BALANCE")]
        public string BALANCE
        {
            get { return bill.Balance.ToString("#,##0.00"); }
        }
        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return bill.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return bill.CreatedOn; }
        }
    }
}
