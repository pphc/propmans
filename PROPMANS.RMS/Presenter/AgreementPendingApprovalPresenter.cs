using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PROPMANS.RMS
{
    public class AgreementPendingApprovalPresenter
    {
        private IAgreementPendingApproval view;
        private RMSDA da = new RMSDA();

        public AgreementPendingApprovalPresenter(IAgreementPendingApproval view)
        { 
            this.view = view;
            view.LoadAmendTypeList(AmendmentType.RentalAmount.ItemList(false, true));
            LoadPendingRentalAgreements();
            LoadPendingLeaseAgreements();
            
        }

        public  void LoadPendingRentalAgreements()
        {
            List<PendingRentalAgreementGridDisplay> agreements = this.GetPendingRentalAgreements();
            view.DisplayRentalAgreements(agreements);
            view.PendingRentalAgreementCount = agreements.Count;
        }
        public  void LoadPendingLeaseAgreements()
        {
            List<PendingLeaseAgreementGridDisplay> leases = this.GetPendingLeaseAgreements();
            view.DisplayLeaseAgreements(leases);
            view.PendingLeaseAgreementCount = leases.Count;
        }

        private List<PendingLeaseAgreementGridDisplay> GetPendingLeaseAgreements()
        {
            var display = new List<PendingLeaseAgreementGridDisplay>();

            List<ContractAmendment> contracts = (from loc in da.LoadLeaseAmendments()
                                                 where loc.AmendmentRequestType == view.LeaseRequestType & loc.ApprovalStatus == ApprovalStatus.Pending
                                                 select loc).ToList();

            foreach (ContractAmendment loc in contracts) {
                display.Add(new PendingLeaseAgreementGridDisplay(loc));
            }

            return display; 
        }
        private List<PendingRentalAgreementGridDisplay> GetPendingRentalAgreements()
        {
            var display = new List<PendingRentalAgreementGridDisplay>();

            List<ContractAmendment> contracts = (from rma in da.LoadRentalAgreementAmendments()
                                                 where rma.AmendmentRequestType == view.RentalRequestType & rma.ApprovalStatus == ApprovalStatus.Pending
                                                 select rma).ToList();

            foreach (ContractAmendment rma in contracts)
            {
                display.Add(new PendingRentalAgreementGridDisplay(rma));
            }

            return display;
        }

    }

    public class PendingRentalAgreementGridDisplay
    {
        public readonly ContractAmendment amendment;
        public PendingRentalAgreementGridDisplay(ContractAmendment amendment)
        {
            this.amendment = amendment;
        }

        [DisplayName(" + ")]
        public bool Selected { get; set; }


        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return amendment.Agreement.ContractNo; }
        }
        [DisplayName("UNIT NUMBER")]
        public string CustUnitNumber
        {
            get { return amendment.Agreement.UnitNumber; }
        }

        [DisplayName("UNIT OWNER")]
        public string UnitOwner
        {
            get { return amendment.Agreement.CustomerName; }
        }

        [DisplayName("LEASE TYPE")]
        public string LeaseType
        {
            get { return amendment.Agreement.LeaseType.DisplayName(); }
        }

        [DisplayName("START")]
        public System.DateTime ContractStart
        {
            get { return amendment.Agreement.ContractStartDate; }
        }
        [DisplayName("END")]
        public System.DateTime ContractEnd
        {
            get { return amendment.Agreement.ContractEndDate; }
        }
        [DisplayName("RENT AMOUNT")]
        public decimal RentAmount
        {
            get { return amendment.Agreement.RentAmount; }
        }
        [DisplayName("APPROVAL REQUEST")]
        public string ContractStatus
        {
            get { return amendment.ApprovalStatus.DisplayName(); }
        }
        [DisplayName("REQUEST DETAILS")]
        public string RequestDetails
        {
            get { return amendment.AmendmentDetails; }
        }
        [DisplayName("REQUEST NOTES")]
        public string RequestNotes
        {
            get { return amendment.RequestNotes; }
        }
        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return amendment.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return amendment.CreatedOn; }
        }
    }

    public class PendingLeaseAgreementGridDisplay
    {
        public readonly ContractAmendment amendment;
        public PendingLeaseAgreementGridDisplay(ContractAmendment amendment)
        {
            this.amendment = amendment;
        }
        [DisplayName(" + ")]
        public bool Selected { get; set; }

        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.amendment.Agreement.ContractNo; }
        }
        [DisplayName("UNIT NUMBER")]
        public string CustUnitNumber
        {
            get { return this.amendment.Agreement.UnitNumber; }
        }
        [DisplayName("TENANT NAME")]
        public string TenantName
        {
            get { return this.amendment.Agreement.CustomerName; }
        }
        [DisplayName("LEASE TYPE")]
        public string LeaseType
        {
            get { return this.amendment.Agreement.LeaseType.DisplayName(); }
        }
        [DisplayName("APPLICATION DATE")]
        public System.DateTime ApplicationDate
        {
            get { return amendment.Agreement.AgreementDate; }
        }
        [DisplayName("START")]
        public System.DateTime ContractStart
        {
            get { return this.amendment.Agreement.ContractStartDate; }
        }
        [DisplayName("END")]
        public System.DateTime ContractEnd
        {
            get { return this.amendment.Agreement.ContractEndDate; }
        }
        [DisplayName("RENT AMOUNT")]
        public decimal RentAmount
        {
            get { return this.amendment.Agreement.RentAmount; }
        }

        [DisplayName("APPROVAL REQUEST")]
        public string ContractStatus
        {
            get { return amendment.ApprovalStatus.DisplayName(); }
        }

        [DisplayName("REQUEST DETAILS")]
        public string RequestDetails
        {
            get { return amendment.AmendmentDetails; }
        }
        [DisplayName("REQUEST NOTES")]
        public string RequestNotes
        {
            get { return amendment.RequestNotes; }
        }

        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return amendment.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return amendment.CreatedOn; }
        }
    }
}
