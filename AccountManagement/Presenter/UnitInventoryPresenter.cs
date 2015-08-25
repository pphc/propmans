using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;



namespace PROPMANS.VIEW.AccountManagement
{
    public class UnitInventoryPresenter
    {
        private IUnitInventory view;
        private UnitInventoryDA da = new UnitInventoryDA();

        public UnitInventoryPresenter(IUnitInventory view)
        {
            this.view = view;

            LoadPhases();
            LoadBuildings();
            LoadCluster();
            LoadFloors();
            LoadUnits();

            view.LoadOccupancyStatus(OccupancyStatus.OCCUPIED.ItemList(false, false));      
            view.LoadOccupantStatus(Occupant.OWNER.ItemList(false,false));
        }        

        public void LoadPhases(){
            view.LoadPhases(da.GetPhases());
        }

        public void LoadBuildings()
        {
            view.LoadBuildings(da.GetBuildings(view.SelectedPhase.PhaseID));
        }

        public void LoadCluster()
        {
            view.LoadClusters(da.GetClusters(view.SelectedBuilding.BuildingID));
        }

        public void LoadFloors()
        {
            view.LoadFloors(da.GetFloors(view.SelectedCluster.ClusterID));
        }

        public void LoadUnits()
        {
            view.LoadUnits(GetUnits());
        }

        public void DisplaySelectedUnit()
        {
            view.SelectedUnit = this.view.SelectedUnit;  
        }

        public void UpdateUnit()
        {
            int status = 0;           
            status = da.UpdateUnit(view.SelectedUnit, view.OccupancyStatus, view.Occupant);
            view.DisplayUpdateStatus(status>0);            
        }

        public void ReloadUnits()
        {
            da.ReloadUnits();
            this.LoadUnits();
        }

        private List<UnitsGridDisplay> GetUnits()
        {
            var display = new List<UnitsGridDisplay>();

            foreach (Unit unit in da.GetUnits(view.SelectedFloor.FloorID))
            {
                display.Add(new UnitsGridDisplay(unit));
            }

            return display;
        }
    }

    public class UnitsGridDisplay
    {
        public readonly Unit  unit;
        public UnitsGridDisplay(Unit unit)
        {
            this.unit = unit;
        }

        [DisplayName("UNIT NUMBER")]
        public string UnitNumber
        {
            get { return this.unit.UnitNumber; }
        }

        [DisplayName("UNIT DESCRIPTION")]
        public string UnitType
        {
            get { return this.unit.UnitType.UnitDescription; }
        }

        [DisplayName("UNIT AREA")]
        public string UnitArea
        {
            get { return this.unit.UnitArea; }
        }

        [DisplayName("UNIT CLASS")]
        public string UnitClass
        {
            get { return this.unit.SubClass.DisplayName(); }
        }        

        [DisplayName("UNIT OWNER")]
        public string UnitOwner
        {
            get { return string.Empty; }
        }

        [DisplayName("SALES STATUS")]
        public string SaleStatus
        {
            get { return this.unit.SaleStatus.DisplayName(); }
        }

        [DisplayName("OCCUPANCY STATUS")]
        public string OccupancyStatus
        {
            get { return this.unit.OccupancyStatus.DisplayName(); }
        }

        [DisplayName("OCCUPANT")]
        public string Occupant
        {
            get { return this.unit.Occupant.DisplayName(); }
        }
    }
}
