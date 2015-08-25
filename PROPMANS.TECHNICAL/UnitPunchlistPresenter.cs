using BCL.Technical;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROPMANS.TECHNICAL
{
    public class UnitPunchlistPresenter
    {
        private IUnitPunchlist view; 
 
        private UnitPunchlistDA unitpunchlistda;

        private UnitPunchlistInfo punchlistInfo;

        private List<UnitPunchlstDetailsInfo> defaultPunchlistTemplate;

        public UnitPunchlistPresenter(IUnitPunchlist view)
        {
            this.view = view;
            view.LoadAccountDetails += LoadAccountDetails;
            view.CMDPunchlistChanged += CMDPunchlistChanged;
            view.OwnerPunchlistChanged += OwnerPunchlistChanged;
            view.NewCMDPunchlist += NewCMDPunchlist;
            view.NewOwnerPunchlist += NewOwnerPunchlist;
            view.CancelNewCMDPunchlist += CancelNewCMDPunchlist;
            view.CancelNewOwnerPunchlist += CancelNewOwnerPunchlist;
            view.ParentCategoryChanged += ParentCategoryChanged;
            view.ChildCategoryChanged += ChildCategoryChanged;
            view.GrandChildCategoryChanged += GrandChildCategoryChanged;
            view.DefectsCategoryChanged += DefectsCategoryChanged;
            view.SavePunchlist += SavePunchlist;
            view.PrintPunchlist += PrintPunchlist;

            unitpunchlistda= new UnitPunchlistDA();

            defaultPunchlistTemplate = unitpunchlistda.GetPunchlistTemplate();

            view.FormatDataGrid(); 
            view.LoadDefaults();
        }

        private void LoadAccountDetails(object sender, EventArgs e)
        {
            view.SetAccountInfo();
            ReloadPunchlist();

            view.SetUnitTurnOverInfo(punchlistInfo);

            //Set Lookup List for Combobox
            view.punchlistType = "BYR";
            view.SetDefectAreaComboboxList(unitpunchlistda.GetFindingsAreaCategory());
            view.SetParentComboboxList(unitpunchlistda.GetTopParentTemplate());
            view.SetChildComboboxList (unitpunchlistda.GetChildTemplate(view.SelectedParentCatID));
            view.SetGrandChildComboboxList(unitpunchlistda.GetChildTemplate(view.SelectedChildCatID));

            view.punchlistType = "CMD";
            view.SetDefectAreaComboboxList(unitpunchlistda.GetFindingsAreaCategory());
            view.SetParentComboboxList(unitpunchlistda.GetTopParentTemplate());
            view.SetChildComboboxList(unitpunchlistda.GetChildTemplate(view.SelectedParentCatID));
            view.SetGrandChildComboboxList(unitpunchlistda.GetChildTemplate(view.SelectedChildCatID));
        }

        private void CMDPunchlistChanged(object sender, EventArgs e)
        {
            view.SetCMDPunchlistInfo(view.SelectedCMDPunchlist);

            var x = unitpunchlistda.GetPunchlistByID(view.SelectedCMDPunchlist.PunchlistID);

            view.LoadPunchlistDetails(defaultPunchlistTemplate, x,"CMD");
            view.SetGridViewDisplay("CMD");
        }

        private void OwnerPunchlistChanged(object sender, EventArgs e)
        {
            view.SetOwnerPunchlistInfo(view.SelectedOwnerPunchlist);

            var x = unitpunchlistda.GetPunchlistByID(view.SelectedOwnerPunchlist.PunchlistID);

            view.LoadPunchlistDetails(defaultPunchlistTemplate, x,"BYR");
            view.SetGridViewDisplay("BYR");
        }
 
        private void NewCMDPunchlist(object sender, EventArgs e)
        {
            view.newCMDEntry = true;
            view.NewEntryCMDPunchlist();
            view.SetGridSource(unitpunchlistda.GetPunchlistTemplate(),"CMD");
            view.SetGridViewDisplay("CMD");
        }

        private void NewOwnerPunchlist(object sender, EventArgs e)
        {
            view.newOwnerEntry = true;
            view.NewEntryOwnerPunchlist();
            view.SetGridSource(unitpunchlistda.GetPunchlistTemplate(),"BYR");
            view.SetGridViewDisplay("BYR");
        }
     
        private void CancelNewCMDPunchlist(object sender, EventArgs e)
        {
            view.LoadCMDPunchList(punchlistInfo.Punchlist.Where(p => p.PunchlistType.Equals("CMD")).ToList());
        }

        private void CancelNewOwnerPunchlist(object sender, EventArgs e)
        {
            view.LoadOwnerPunchList(punchlistInfo.Punchlist.Where(p => p.PunchlistType.Equals("BYR")).ToList());
        }

        public void ParentCategoryChanged(object sender, EventArgs e)
        {
            var items = unitpunchlistda.GetChildTemplate(view.SelectedParentCatID);

            view.SetChildComboboxList(items);

            if (items.Count == 0)
            {
                view.SetGridViewDisplay(view.punchlistType);
            }
        }
       
        public void ChildCategoryChanged(object sender, EventArgs e)
        {
            var items = unitpunchlistda.GetChildTemplate(view.SelectedChildCatID);

            view.SetGrandChildComboboxList(items);
           
            if (items.Count == 0)
            {
                view.SetGridViewDisplay(view.punchlistType);
            }
        }
       
        public void GrandChildCategoryChanged(object sender, EventArgs e)
        {
            view.SetGridViewDisplay(view.punchlistType);
        }

        public void DefectsCategoryChanged(object sender, EventArgs e)
        {
            view.SetGridViewDisplay(view.punchlistType);
        }

        public void SavePunchlist(object sender, EventArgs e)
        {
            if (view.newCMDEntry || view.newOwnerEntry )
            {
                string punchlistid;

                punchlistid = unitpunchlistda.SavePunchlist(view.SelectedAccount.UnitID, view.SelectedAccount.OwnerAccount.AccountID, view.GetPunchlistDetails());
                }
            else {
                string rowsaffected;

                rowsaffected = unitpunchlistda.UpdatePunchlist(view.GetPunchlistDetails());
            }

            ReloadPunchlist();
      
        }

        public void PrintPunchlist(object sender, EventArgs e)
        {
            List<UnitPunchlistDetailReportInfo> x = GetPunchlistReport();

            view.DisplayPunchlistReport(x);
        }
        
        private void ReloadPunchlist()
        {
            punchlistInfo = unitpunchlistda.LoadPunchlistDetails(view.SelectedAccount);      
            view.LoadCMDPunchList(punchlistInfo.Punchlist.Where(p => p.PunchlistType.Equals("CMD")).OrderByDescending(p=> p.InspectionDate ).ToList());
            view.LoadOwnerPunchList(punchlistInfo.Punchlist.Where(p => p.PunchlistType.Equals("BYR")).OrderByDescending(p => p.InspectionDate).ToList());
        }

        private  List<UnitPunchlistDetailReportInfo> GetPunchlistReport()
        {
            UnitPunchlist plistInfo = view.GetPunchlistDetails();

            List<PunchlistDetail> punchlist = plistInfo.PunchlistDetails;

            List<UnitPunchlistDetailReportInfo> x = unitpunchlistda.GetPunchlistReportData(punchlist);
           
           List<UnitPunchlistDetailReportInfo> z = x.Where(p => p.ClassType.Equals("PARENT")).ToList();

           return x;
        }

    }
}
