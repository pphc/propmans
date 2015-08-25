using BCL.Common;
using System.Collections.Generic;



namespace PROPMANS.ACCOUNT_SEARCH
{

	public enum SearchAccountCriteria
	{ 
		UnitNumber,
		LastName,
		FirstName
	}

	public interface IAccountLookUp
	{
		BCL.Accounts.Customer SelectedCustomer { get; }
		BCL.Accounts.CustomerAccount SelectedAccount { get; }
		BCL.Accounts.UnitInventory SelectedUnit { get;}

		bool DisplayInactiveCheckBox { set; }
		bool DisplayUnitNumberTextbox { set; }
		bool DisplayNewButton { set; }
		SearchAccountCriteria SetSearchCriteria { set; }

		SearchAccountCriteria SearchByOption { get; }
		string SearchValue { get; }

		bool DisplayInactiveAccounts { get; }

		string StatusChange { set; }

		void LoadCustomerAccounts(List<CustomerAccountDisplay> accounts);
		void LoadCustomers(List<CustomerDisplay> customers);
		void LoadUnits(List<AllUnitsDisplay> units);
	}
	
	public class AllUnitsDisplay {
		public BCL.Accounts.UnitInventory Unit;

		public AllUnitsDisplay(BCL.Accounts.UnitInventory unit)
		{
			this.Unit = unit;
		}
		[System.ComponentModel.DisplayName("UNIT NUMBER")]
		public string UnitNumber
		{
			get { return Unit.UnitNumber; }

		}


		[System.ComponentModel.DisplayName("LAST NAME")]
		public string CustomerLastName
		{
			get
			{

				if (Unit.OwnerAccount != null)
				{
					return Unit.OwnerAccount.Owner.LastName;
				}
				else
				{ return string.Empty; }
			}

		}
		[System.ComponentModel.DisplayName("FIRST NAME")]
		public string CustomerFirstName
		{
			get {

				if (Unit.OwnerAccount != null)
				{
					return Unit.OwnerAccount.Owner.FirstName;
				}
				else
				{ return string.Empty; }
			}

		}
		[System.ComponentModel.DisplayName("MIDDLE NAME")]
		public string CustomerMidlleName
		{
			get
			{
				if (Unit.OwnerAccount != null)
				{
					return Unit.OwnerAccount.Owner.MiddleName;
				}
				else
				{ return string.Empty; }
			}

		}

		[System.ComponentModel.DisplayName("NAME SUFFIX")]
		public string CustomerNameSuffix
		{
			get
			{
				if (Unit.OwnerAccount != null)
				{
					return Unit.OwnerAccount.Owner.NameSuffix;
				}
				else
				{ return string.Empty; }
			}

		}
	
	}

	public class CustomerAccountDisplay {

		 public BCL.Accounts.CustomerAccount CustAccount;

		 public CustomerAccountDisplay(BCL.Accounts.CustomerAccount account)
		 {
			 this.CustAccount = account;
		 }
		 [System.ComponentModel.DisplayName("UNIT NUMBER")]
		 public string UnitNumber
		 {
			 get { return CustAccount.UnitNumber; }
		 
		 }
		 [System.ComponentModel.DisplayName("UNIT OWNER NAME")]
		 public string CustomerName
		 {
			 get { return CustAccount.Owner.FullNameLastNameFirst; }

		 }
		 [System.ComponentModel.DisplayName("UNIT TYPE")]
		 public string UnitType
		 {
			 get { return CustAccount.UnitType.DisplayName(); }

		 }
		 [System.ComponentModel.DisplayName("ACCOUNT STATUS")]
		 public string AccountStatus
		 {
			 get { return CustAccount.AccountStatus.DisplayName(); }

		 }
	 }

	public class CustomerDisplay {

		 public BCL.Accounts.Customer Customer;

		 public CustomerDisplay(BCL.Accounts.Customer account)
		 {
			 this.Customer = account;
		 }
		 [System.ComponentModel.DisplayName("LAST NAME")]
		 public string CustomerLastName
		 {
			 get { return Customer.LastName; }

		 }
		 [System.ComponentModel.DisplayName("FIRST NAME")]
		 public string CustomerFirstName
		 {
			 get { return Customer.FirstName; }

		 }
		 [System.ComponentModel.DisplayName("MIDDLE NAME")]
		 public string CustomerMidlleName
		 {
			 get { return Customer.MiddleName; }

		 }
		 [System.ComponentModel.DisplayName("NAME SUFFIX")]
		 public string CustomerNameSuffix
		 {
			 get { return Customer.NameSuffix; }

		 }
	 }

}
