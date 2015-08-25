using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace PROPMANS.RMS
{
    public class ContractAmendmentPresenter
    {
        private IContractAmendment view;
        private RMSDA da = new RMSDA();

        public ContractAmendmentPresenter(IContractAmendment view) {
            this.view = view;
            view.LoadAmendTypeList(AmendmentType.RentalExtension.ItemList(false, true).Where(p => p.Name != "NEW CONTRACT").ToList());
        }

        public void LoadRentalAmendments()
        { 
            var agreement = this.GetRentalAmmendments().Where(p => p.amendment.AmendmentRequestType == view.SelectedRentalAmendmentType).ToList();
            view.SetRentalAmendmentDefaults();
            if (agreement.Count > 0)
            {
                view.LoadRentalAgreements(agreement);
                this.DisplaySelectedRentalAmendment();
            }
            else {
                view.LoadRentalAgreements(agreement);
            }
            view.RentalAmendmentCount = agreement.Count;
        }
     
        public void LoadLeaseAmendments()
        {
            var lease = this.GetLeaseAmmendments().Where(p => p.amendment.AmendmentRequestType == view.SelectedLeaseAmendmentType).ToList();

            view.SetLeaseAmendmentDefaults();
            if (lease.Count > 0)
            {
                view.LoadLeaseAgreements(lease);
                this.DisplaySelectedLeaseAmendment();
            }
            else {
                view.LoadLeaseAgreements(lease);
            }
            view.LeaseAmendmentCount = lease.Count;
        }
       
        private List<LeaseAmendmentGridDisplay> GetLeaseAmmendments()
        {
            List<LeaseAmendmentGridDisplay> display = new List<LeaseAmendmentGridDisplay>();

            foreach (ContractAmendment loc in da.LoadLeaseAmendments())
            {
                display.Add(new LeaseAmendmentGridDisplay(loc));
            }

            return display;
        }

        private List<RentalAgreementAmendmentGridDisplay> GetRentalAmmendments()
           {
               List<RentalAgreementAmendmentGridDisplay> display = new List<RentalAgreementAmendmentGridDisplay>();

               foreach (ContractAmendment rma in da.LoadRentalAgreementAmendments())
               {
                   display.Add(new RentalAgreementAmendmentGridDisplay(rma));
               }

               return display;
           }

        public void DisplaySelectedRentalAmendment() {
            view.RentalAmendment = view.RentalAmendment;
        }

        public void DisplaySelectedLeaseAmendment() {
            view.LeaseAmendment = view.LeaseAmendment;
        }
     }

    public class LeaseAmendmentGridDisplay
    {
        public readonly ContractAmendment amendment;
        public LeaseAmendmentGridDisplay(ContractAmendment amendment)
        {
            this.amendment = amendment;
        }
        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.amendment.Agreement.ContractNo; }
        }

        [DisplayName("UNIT NUMBER")]
        public string UnitNumber
        {
            get { return this.amendment.Agreement.UnitNumber; }
        }

        [DisplayName("TENANT")]
        public string Tenant
        {
            get { return this.amendment.Agreement.CustomerName; }
        }

        [DisplayName("REQUEST DATE")]
        public System.DateTime RequestDate
        {
            get { return this.amendment.RequestDate; }
        }
        [DisplayName("REQUEST TYPE")]
        public string RequestType
        {
            get { return this.amendment.AmendmentRequestType.DisplayName(); }
        }

        [DisplayName("REQUESTED BY")]
        public string RequestedBy
        {
            get { return this.amendment.RequestingParty.DisplayName(); }
        }
        [DisplayName("APPROVAL STATUS")]
        public string Status
        {
            get { return this.amendment.ApprovalStatus.DisplayName(); }
        }

        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return this.amendment.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public System.DateTime CreatedOn
        {
            get { return this.amendment.CreatedOn; }
        }
    }

    public class RentalAgreementAmendmentGridDisplay
    {
        public readonly ContractAmendment amendment;

        public RentalAgreementAmendmentGridDisplay(ContractAmendment amendment)
        {
            this.amendment = amendment;
        }

        [DisplayName("CONTRACT NUMBER")]
        public string ContractNumber
        {
            get { return this.amendment.Agreement.ContractNo; }
        }

        [DisplayName("UNIT NUMBER")]
        public string UnitNumber
        {
            get { return this.amendment.Agreement.UnitNumber; }
        }

        [DisplayName("UNIT OWNER")]
        public string Tenant
        {
            get { return this.amendment.Agreement.CustomerName; }
        }

        [DisplayName("REQUEST DATE")]
        public DateTime RequestDate
        {
            get { return this.amendment.RequestDate; }
        }
        [DisplayName("REQUEST TYPE")]
        public string RequestType
        {
            get { return this.amendment.AmendmentRequestType.DisplayName(); }
        }

        [DisplayName("REQUESTED BY")]
        public string RequestedBy
        {
            get { return this.amendment.RequestingParty.DisplayName(); }
        }
        [DisplayName("APPROVAL STATUS")]
        public string Status
        {
            get { return this.amendment.ApprovalStatus.DisplayName(); }
        }

        [DisplayName("CREATED BY")]
        public string CreatedBy
        {
            get { return this.amendment.CreatedBy; }
        }
        [DisplayName("CREATED ON")]
        public DateTime CreatedOn
        {
            get { return this.amendment.CreatedOn; }
        }
    }

    }

