using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public interface IUnitInventory
    {
        Phase SelectedPhase { get; }
        void LoadPhases(List<Phase> phases);

        Building SelectedBuilding { get; }
        void LoadBuildings(List<Building> buildings);

        Cluster SelectedCluster { get; }
        void LoadClusters(List<Cluster> clusters);

        Floor SelectedFloor { get; }
        void LoadFloors(List<Floor> floors);

        Unit SelectedUnit { get; set; }
        void LoadUnits(List<UnitsGridDisplay> units);

        void LoadOccupancyStatus(List<EnumItem> src);
        void LoadOccupantStatus(List<EnumItem> src);

        OccupancyStatus OccupancyStatus { get; }
        Occupant Occupant { get; }

        Boolean SetOccupantVisibility { set; }

        void DisplayUpdateStatus(bool success);

    }
}
