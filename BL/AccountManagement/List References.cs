using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnumLib;

namespace PROPMANS.BL.AccountManagement
{

    //Customer and Customer Accounts
    
    public enum Gender
    {
        [EnumDisplayName("MALE")]
        [EnumDBValue("M")]
        MALE,
        [EnumDisplayName("FEMALE")]
        [EnumDBValue("F")]
        FEMALE
    }

    public enum CivilStatus
    {
        [EnumDisplayName("SINGLE")]
        [EnumDBValue("SINGLE")]
        SINGLE,
        [EnumDisplayName("MARRIED")]
        [EnumDBValue("MARRIED")]
        MARRIED,
        [EnumDisplayName("SEPARATED")]
        [EnumDBValue("SEPARATED")]
        SEPARATED,
        [EnumDisplayName("WIDOWED")]
        [EnumDBValue("WIDOWED")]
        WIDOWED,
        [EnumDisplayName("DIVORCED")]
        [EnumDBValue("DIVORCED")]
        DIVORCED
    }

    public enum NameSake
    {
        [EnumDisplayName("JR")]
        [EnumDBValue("JR")]
        JR,
        [EnumDisplayName("SR")]
        [EnumDBValue("JR")]
        SR,
        [EnumDisplayName("II")]
        [EnumDBValue("II")]
        II,
        [EnumDisplayName("III")]
        [EnumDBValue("III")]
        III,
        [EnumDisplayName("IV")]
        [EnumDBValue("IV")]
        IV,
        [EnumDisplayName("V")]
        [EnumDBValue("V")]
        V,
        [EnumDisplayName("VI")]
        [EnumDBValue("VI")]
        VI,
        [EnumDisplayName("VII")]
        [EnumDBValue("VII")]
        VII
    }

    public enum ContactLocation
    {
        [EnumDisplayName("COMPANY")]
        [EnumDBValue("COMPANY")]
        COMPANY,
        [EnumDisplayName("PROVINCIAL")]
        [EnumDBValue("PROVINCIAL")]
        PROVINCIAL,
        [EnumDisplayName("PERSONAL")]
        [EnumDBValue("PERSONAL")]
        PERSONAL,
        [EnumDisplayName("RESIDENTIAL")]
        [EnumDBValue("RESIDENTIAL")]
        RESIDENTIAL
    }

    public enum ContactType
    {
        [EnumDisplayName("ADDRESS")]
        [EnumDBValue("ADDRESS")]
        ADDRESS,
        [EnumDisplayName("CELLPHONE")]
        [EnumDBValue("CELLPHONE")]
        CELLPHONE,
        [EnumDisplayName("EMAIL")]
        [EnumDBValue("EMAIL")]
        EMAIL,
        [EnumDisplayName("TELEPHONE")]
        [EnumDBValue("TELEPHONE")]
        TELEPHONE
    }

    public enum AccountStatus
    {
        [EnumDBValue("ACT")]
        [EnumDisplayName("ACTIVE")]
        Active = 0,
        [EnumDBValue("INACT")]
        [EnumDisplayName("INACTIVE")]
        Inactive = 1,
    }

    public enum ActiveStatus
    {
        [EnumDBValue("N")]
        [EnumDisplayName("NO")]
        No,
        [EnumDBValue("Y")]
        [EnumDisplayName("YES")]
        Yes,
    }

    //Unit Inventory

    public enum UnitSubClass
    {
        [EnumDisplayName("RESIDENTIAL")]
        [EnumDBValue("RES")]
        RESIDENTIAL,
        [EnumDisplayName("COMMERCIAL")]
        [EnumDBValue("COMM")]
        COMMERCIAL,
        [EnumDisplayName("PARKING")]
        [EnumDBValue("PARK")]
        PARKING
    }

    public enum SaleStatus
    {
        [EnumDisplayName("RESERVED")]
        [EnumDBValue("RESERVED")]
        RESERVED,
        [EnumDisplayName("FORSALE")]
        [EnumDBValue("FOR SALE")]
        FORSALE
    }

    public enum OccupancyStatus
    {
        [EnumDisplayName("VACANT")]
        [EnumDBValue("VAC")]
        VACANT,
        [EnumDisplayName("OCCUPIED")]
        [EnumDBValue("OCC")]
        OCCUPIED
    }

    public enum Occupant
    {
        [EnumDisplayName("OWNER")]
        [EnumDBValue("OWNER")]
        OWNER,
        [EnumDisplayName("RELATIVES")]
        [EnumDBValue("RELATIVES")]
        RELATIVES,
        [EnumDisplayName("TENANT")]
        [EnumDBValue("TENANT")]
        TENANT,
        [EnumDisplayName("VACANT")]
        [EnumDBValue("VACANT")]
        VACANT
    }

    public enum RelationCategory
    {
        HouseholdMember,
        AttorneyInFact,
        CoOwner,
        EmergencyContact
    }

    public enum RelationType
    {
        Child,
        Spouse,
        Parent,
        GrandPArent,
        Sibing,
        Cousin,
        AuntandUncle,
        HouseHelp,
        FamilyFriend,
        Other
    }
}
