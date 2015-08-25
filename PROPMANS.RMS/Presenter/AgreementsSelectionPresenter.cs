using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PROPMANS.RMS
{

	public abstract class AgreementsSelectionPresenter
	{
		public IAgreementSelection view;
		protected RMSDA da = new RMSDA();

		public abstract string DialogueTitle();
		public AgreementsSelectionPresenter(){
		}
		public void Initialize()
		{
			view.LoadLeaseType(LeaseType.Bare.ItemList(false, true));
			LeaseTypeChanged();
			view.DialogueTitleCaption = this.DialogueTitle();
		}

		public abstract void LeaseTypeChanged();
	
	}

	public class AvailableRentalUnitsPresenter : AgreementsSelectionPresenter
	{
		public override string DialogueTitle()
		{
			return "AVAILABLE UNITS FOR RENT";
		}
		public AvailableRentalUnitsPresenter():base()
		{
		}
		private List<AvailableUnitsForRentGridDisplay> GetAvailableUnits()
		{
			var rmalist = (from RM in da.LoadActiveRentalAgreementsByLeaseType (view.SelectedLeaseType)
					   where RM.Available > 0 & !RM.ContractStatus.Equals(ContractStatus.Expired) 
					   select RM).ToList();

			List<AvailableUnitsForRentGridDisplay> display = new List<AvailableUnitsForRentGridDisplay>();

			foreach (RentalAgreement rma in rmalist)
			{
				display.Add(new AvailableUnitsForRentGridDisplay(rma));
			}

			return display;
		}
		public override void LeaseTypeChanged()
		{
			var agreements = this.GetAvailableUnits();
			view.LoadAvailableRentalUnits(agreements);
			view.AvailableUnitsCount = agreements.Count;
		}

	}

	public class ActiveRentalAgreementsPresenter : AgreementsSelectionPresenter
	{
		public override string DialogueTitle()
		{
			return "SELECT RENTAL AGREEMENT TO AMEND";
		}
		public ActiveRentalAgreementsPresenter()
			: base()
		{
		}

		private List<ActiveRentalAgreementsGridDisplay> GetActiveRentalAgreements()
		{

			var agreements = (from rm in da.LoadRentalAgreementByStatus(ContractStatus.Active)
							  where rm.LeaseType == view.SelectedLeaseType
							  select rm).ToList();

			List<ActiveRentalAgreementsGridDisplay> display = new List<ActiveRentalAgreementsGridDisplay>();

			foreach (RentalAgreement rma in agreements)
			{
				display.Add(new ActiveRentalAgreementsGridDisplay(rma));
			}

			return display;
		}
		public override void LeaseTypeChanged()
		{
			var agreements = this.GetActiveRentalAgreements();
			view.LoadActiveRentalAgreements(agreements);
			view.AvailableUnitsCount = agreements.Count;
		}
	}

	public class ActiveLeaseAgreementsPresenter : AgreementsSelectionPresenter
	{
		public override string DialogueTitle()
		{
			return "SELECT LEASE AGREEMENT TO AMEND";
		}
		public ActiveLeaseAgreementsPresenter()
			: base()
		{
		}

		private List<ActiveLeaseAgreementsGridDisplay> GetActiveRentalAgreements()
		{

			var agreements = (from col in da.LoadLeaseAgreementsByStatus(ContractStatus.Active)
							  where col.LeaseType == view.SelectedLeaseType
							  select col).ToList();

			List<ActiveLeaseAgreementsGridDisplay> display = new List<ActiveLeaseAgreementsGridDisplay>();

			foreach (LeaseAgreement col in agreements)
			{
				display.Add(new ActiveLeaseAgreementsGridDisplay(col));
			}

			return display;
		}
		public override void LeaseTypeChanged()
		{
			var agreements = this.GetActiveRentalAgreements();
			view.LoadActiveLeaseAgreements(agreements);
			view.AvailableUnitsCount = agreements.Count;
		}
	}



	public  class AgreementsSelectionGridDisplay
	{ 
		public  RentalServiceAgreement agreement;

	}
	
	public class AvailableUnitsForRentGridDisplay : AgreementsSelectionGridDisplay
		{
		public AvailableUnitsForRentGridDisplay(RentalAgreement rentalAgreement)
		{
			agreement = rentalAgreement;
		}
		[DisplayName("CONTRACT NUMBER")]
		public string ContractNumber {
			get { return this.agreement.ContractNo; }
		}
		[DisplayName("UNIT NUMBER")]
		public string CustUnitNumber {
			get { return ((RentalAgreement)this.agreement).OwnerAccount.UnitNumber; }
		}
		[DisplayName("START")]
		public System.DateTime ContractStart {
			get { return this.agreement.ContractStartDate; }
		}
		[DisplayName("END")]
		public System.DateTime ContractEnd {
			get { return this.agreement.ContractEndDate; }
		}
		[DisplayName("RENT AMOUNT")]
		public decimal RentAmount {
			get {
				if (this.agreement.LeaseType == LeaseType.DormType) {
					return this.agreement.RentAmount / ((RentalAgreement)this.agreement).MaxOccupant;
				} else {
					return this.agreement.RentAmount;
				}
			}
		}
		[DisplayName("DEPOSIT")]
		public decimal SecurityDeposit {
			get {
				if (this.agreement.LeaseType == LeaseType.DormType) {
					return this.agreement.SecurityDeposit / ((RentalAgreement)this.agreement).MaxOccupant;
				} else {
					return this.agreement.SecurityDeposit;
				}
			}
		}
		[DisplayName("CASH BOND")]
		public decimal CashBond {
			get { return this.agreement.CashBond; }
		}
		[DisplayName("AVAILABLE")]
		public int Available {
			get { return ((RentalAgreement)this.agreement).Available; }
		}

		}

	public class ActiveRentalAgreementsGridDisplay : AgreementsSelectionGridDisplay
	{
		public ActiveRentalAgreementsGridDisplay(RentalAgreement rentalAgreement)
		{
			agreement = rentalAgreement;
		}
		[DisplayName("CONTRACT NUMBER")]
		public string ContractNumber
		{
			get { return this.agreement.ContractNo; }
		}
		[DisplayName("UNIT NUMBER")]
		public string CustUnitNumber
		{
			get { return ((RentalAgreement)this.agreement).OwnerAccount.UnitNumber; }
		}

		[DisplayName("UNIT OWNER")]
		public string UnitOwner
		{
			get { return ((RentalAgreement)this.agreement).OwnerAccount.Owner.FullNameLastNameFirst; }
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
		public decimal Rentmount
		{

			get { return this.agreement.RentAmount; }
		}
		[DisplayName("DEPOSIT")]
		public decimal SecurityDeposit
		{

			get { return this.agreement.SecurityDeposit; }
		}
		[DisplayName("CASH BOND")]
		public decimal CashBond
		{
			get { return this.agreement.CashBond; }
		}
	}

	public class ActiveLeaseAgreementsGridDisplay : AgreementsSelectionGridDisplay
	{
		public ActiveLeaseAgreementsGridDisplay(LeaseAgreement lease)
		{
			agreement = lease;
		}
		[DisplayName("CONTRACT NUMBER")]
		public string ContractNumber
		{
			get { return this.agreement.ContractNo; }
		}
		[DisplayName("UNIT NUMBER")]
		public string CustUnitNumber
		{
			get { return ((LeaseAgreement)this.agreement).RentalAgreement.OwnerAccount.UnitNumber; }
		}

		[DisplayName("TENANT NAME")]
		public string Tenant
		{
			get { return ((LeaseAgreement)this.agreement).Tenant.FullNameLastNameFirst; }
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
		public decimal Rentmount
		{

			get { return this.agreement.RentAmount; }
		}
		[DisplayName("DEPOSIT")]
		public decimal SecurityDeposit
		{

			get { return this.agreement.SecurityDeposit; }
		}
		[DisplayName("CASH BOND")]
		public decimal CashBond
		{
			get { return this.agreement.CashBond; }
		}
	}

}
