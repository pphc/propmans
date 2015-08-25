using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class CustomerAccount
    {
        #region PROPERTIES

        public Customer Customer { get; set; }
        public Unit Unit { get; set; }

        public string AccountID { get; set; }
        public DateTime? MoveInDate { get; set; }
        public DateTime? TakeOutDate { get; set; }
        public DateTime? CDStartDate { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public string AccountFinanceCode { get; set; }
        public string CustomerUnitSort { get; set; }
        public string PaymentScheme { get; set; }
        public string CondoDuesRate { get; set; }
        public DateTime? OrientationDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public DateTime? KeyTurnOverDate { get; set; }
        public DateTime? PowerApplicationDate { get; set; }
        public DateTime? WaterApplicationDate { get; set; }
        public string LivingPrequency { get; set; }
        public string Notes { get; set; }
        public DateTime? ATMDate { get; set; }
        public string AccountClass { get; set; }
        public DateTime? MoveInFeePaymentDate { get; set; }
        public DateTime? EarlyMoveInRequestDate { get; set; }

       // public List<UnitHousehold> Householdmembers { get; set; }
        #endregion

    }
}
