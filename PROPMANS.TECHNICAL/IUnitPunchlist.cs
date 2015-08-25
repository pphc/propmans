using BCL.Technical;
using System;
using System.Collections.Generic;

namespace PROPMANS.TECHNICAL
{
    public interface IUnitPunchlist
    {

        bool newCMDEntry  { get;set; }
        bool newOwnerEntry { get; set; }
        string punchlistType { get; set; }

        BCL.Accounts.UnitInventory SelectedAccount { get;set; }
        UnitPunchlist SelectedCMDPunchlist { get; }
        UnitPunchlist SelectedOwnerPunchlist { get;}
        string SelectedParentCatID { get; }
        string SelectedChildCatID { get; }
        string SelectedGrandChildID { get; }
        string SelectedDefectID { get; }

        void SetAccountInfo(); 
        void LoadDefaults();
        void FormatDataGrid();
        void SetUnitTurnOverInfo(UnitPunchlistInfo punchlistInfo);
        void LoadCMDPunchList(List<UnitPunchlist> cmdPunchList);
        void LoadOwnerPunchList(List<UnitPunchlist> ownerPunchList);

        void NewEntryCMDPunchlist();
        void NewEntryOwnerPunchlist();

        void SetCMDPunchlistInfo(UnitPunchlist cmdPunchList);
        void SetOwnerPunchlistInfo(UnitPunchlist ownerPunchList);

        void SetDefectAreaComboboxList(List<KeyValuePair<string, string>> list);
        void SetParentComboboxList(List<KeyValuePair<string, string>> list);
        void SetChildComboboxList(List<KeyValuePair<string, string>> list);
        void SetGrandChildComboboxList(List<KeyValuePair<string, string>> list);

        void SetGridSource(List<UnitPunchlstDetailsInfo> defaultTemplate, string punchlistType);
        void SetGridViewDisplay(string punchlistType);
        void LoadPunchlistDetails(List<UnitPunchlstDetailsInfo> defaultTemplate, UnitPunchlist punchlist,string punchlistType);

        void DisplayPunchlistReport(List<UnitPunchlistDetailReportInfo> rep);

        UnitPunchlist GetPunchlistDetails();

        event EventHandler<EventArgs> LoadAccountDetails;
        event EventHandler<EventArgs> CMDPunchlistChanged;
        event EventHandler<EventArgs> OwnerPunchlistChanged;
        event EventHandler<EventArgs> NewCMDPunchlist;
        event EventHandler<EventArgs> NewOwnerPunchlist;
        event EventHandler<EventArgs> CancelNewCMDPunchlist;
        event EventHandler<EventArgs> CancelNewOwnerPunchlist;
        event EventHandler<EventArgs> SavePunchlist;
        event EventHandler<EventArgs> PrintPunchlist;

        event EventHandler<EventArgs> ParentCategoryChanged;
        event EventHandler<EventArgs> ChildCategoryChanged;
        event EventHandler<EventArgs> GrandChildCategoryChanged;
        event EventHandler<EventArgs> DefectsCategoryChanged;
    
    }
}
