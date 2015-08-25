using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using EnumLib;
using PROPMANS.BL.AccountManagement;



namespace PROPMANS.VIEW.AccountManagement
{
    public partial class UnitInventoryForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IUnitInventory
    {
        UnitInventoryPresenter presenter;
        #region "Form Instance"
        private static UnitInventoryForm aForm;
        public static UnitInventoryForm Instance()
        {
            if (aForm == null)
            {
                aForm = new UnitInventoryForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        public UnitInventoryForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new UnitInventoryPresenter(this);                       
        }

        public Phase SelectedPhase
        {
            get { return cboPhase.SelectedItem as Phase; }
        }

        public Building SelectedBuilding
        {         
            get { return cboBuilding.SelectedItem as Building; }
        }
        
        public Cluster SelectedCluster
        {
            get { return cboCluster.SelectedItem as Cluster; }
        }        

        public Floor SelectedFloor
        {
            get { return cboFloor.SelectedItem as Floor; } 
        }

        
        public void LoadPhases(List<Phase> phases)
        {
            cboPhase.DisplayMember = "PhaseName";
            cboPhase.ValueMember = "PhaseID";
            cboPhase.DataSource = phases;           
        }

        public void LoadBuildings(List<Building> buildings)
        {
            cboBuilding.DisplayMember = "BuildingName";
            cboBuilding.ValueMember = "BuildingID";
            cboBuilding.DataSource = buildings;
        }

        public void LoadClusters(List<Cluster> clusters)
        {
            cboCluster.DisplayMember = "ClusterName";
            cboCluster.ValueMember = "ClusterID";
            cboCluster.DataSource = clusters;
        }

        public void LoadFloors(List<Floor> floors)
        {
            cboFloor.DisplayMember = "FloorName";
            cboFloor.ValueMember = "FloorID";
            cboFloor.DataSource = floors;
        }

        public void LoadOccupancyStatus(List<EnumItem> src)
        {
            cboOccupancyStatus.DisplayMember = "Name";
            cboOccupancyStatus.ValueMember = "Value";
            cboOccupancyStatus.DataSource = src;
        }

        public void LoadOccupantStatus(List<EnumItem> src)
        {
            cboOccupant.DisplayMember = "Name";
            cboOccupant.ValueMember = "Value";
            cboOccupant.DataSource = src;            
        }

        Unit _selectedUnit;
        Unit IUnitInventory.SelectedUnit
        {
            get {
                _selectedUnit = (dtgUnits.CurrentRow.DataBoundItem as UnitsGridDisplay).unit;               
                return _selectedUnit;            
            }
            set {

                lblUnitNumber.Text = _selectedUnit.UnitNumber;               
                lblUnitType.Text = _selectedUnit.UnitType.UnitDescription;
                lblUnitSQMArea.Text = _selectedUnit.UnitArea;
                lblUnitClass.Text = _selectedUnit.SubClass.DisplayName();
                lblSaleStatus.Text = _selectedUnit.SaleStatus.DisplayName();
                lblUnitOwner.Text = "";

                if (_selectedUnit.CMDTurnOverDate == null) {
                    RfoDate.Checked = false;
                }else{
                    RfoDate.Value = DateTime.Parse(_selectedUnit.RFODate.ToString());
                }
                
                cboOccupancyStatus.SelectedValue = (Int32) _selectedUnit.OccupancyStatus;
                this.SetOccupantVisibility = _selectedUnit.OccupancyStatus == OccupancyStatus.OCCUPIED;
                cboOccupant.SelectedValue = (Int32) _selectedUnit.Occupant;

               
                
            }
        }

        public void LoadUnits(List<UnitsGridDisplay> units)
        {
            dtgUnits.DataSource = units;
        }

        public OccupancyStatus OccupancyStatus
        {
            get { return (OccupancyStatus)cboOccupancyStatus.SelectedValue; } 
        }

        public Occupant Occupant
        {
            get { return (Occupant) cboOccupant.SelectedValue; } 
        }       

        public void DisplayUpdateStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Unit Information successfully Updated");
                presenter.ReloadUnits();
            }
            else
            {
                MessageBox.Show("Unit Information not successfully Updated");
            }
        }

        public bool SetOccupantVisibility
        {
            set
            {

                cboOccupant.Visible = value;
                lblOccupant.Visible = value;
            }
        }

        #region "EVENTS"

        private void cboPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhase.SelectedValue != null && presenter != null)
            {
                presenter.LoadBuildings();
                presenter.LoadCluster();
                presenter.LoadFloors();
                presenter.LoadUnits();
            }
        }

        private void cboBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuilding.SelectedValue != null && presenter != null)
            {
                presenter.LoadCluster();
                presenter.LoadFloors();
                presenter.LoadUnits();
            }
        }

        private void cboCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCluster.SelectedValue != null && presenter != null)
            {                
                presenter.LoadFloors();
                presenter.LoadUnits();
            }
        }

        private void cboFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFloor.SelectedValue != null && presenter != null)
            {
                presenter.LoadUnits();
            }
        }

        private void dtgUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (presenter != null)
            {
                presenter.DisplaySelectedUnit();             
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Unit Information?", "Confirmation",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                presenter.UpdateUnit();
            }
        }

        private void cboOccupancyStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFloor.SelectedValue != null && presenter != null)
            {
                this.SetOccupantVisibility = cboOccupancyStatus.SelectedValue.ToString().Equals(((Int32)OccupancyStatus.OCCUPIED).ToString());
            }
        }
        #endregion        
    
    }
}
