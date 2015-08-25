using BCL.Technical;
using ComponentFactory.Krypton.Toolkit;
using PROPMANS.ACCOUNT_SEARCH;
using PROPMANS.REPORTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PROPMANS.TECHNICAL
{
    public partial class UnitPunchlistingForm : ComponentFactory.Krypton.Toolkit.KryptonForm ,
        IUnitPunchlist
    {
        #region "Form Instance"
        private static UnitPunchlistingForm aForm;
        public static UnitPunchlistingForm Instance()
        {
            if (aForm == null)
            {
                aForm = new UnitPunchlistingForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        private UnitPunchlistPresenter presenter;

        public bool newOwnerEntry
        {
            get;set;
        }

        public bool newCMDEntry
        {
            get;
            set;
        }

        public string punchlistType
        {
            get;set;
        }

        public BCL.Accounts.UnitInventory SelectedAccount
        {
            get;
            set;
        }

        public UnitPunchlist SelectedCMDPunchlist
        {
            get
            {
                return cboCMDInspectionInstance.SelectedItem as UnitPunchlist;
            }
        }

        public UnitPunchlist SelectedOwnerPunchlist
        {
            get
            {
                return cboOwnerInspectionInstance.SelectedItem as UnitPunchlist;
            }
        }

        public string SelectedDefectID
        {
            get {
                if (punchlistType == "CMD") {
                    return cboDefectsCategory.SelectedValue as string; 
                }
                else {
                    return cboDefectsCategory2.SelectedValue as string; 
                }
            }
        }

        public string SelectedCriteriaParentID
        {
            get {
                string id = String.Empty;

                if (! string.IsNullOrEmpty(this.SelectedParentCatID)) {
                    id = this.SelectedParentCatID;
                }

                if (!string.IsNullOrEmpty(this.SelectedChildCatID))
                {
                    id = this.SelectedChildCatID;
                }

                if (!string.IsNullOrEmpty(this.SelectedGrandChildID))
                {
                    id = SelectedGrandChildID;
                }
                return id;
            }
        }

        public string SelectedParentCatID
        {
            get {
                if (punchlistType == "CMD")
                {
                    return cboMainCategory.SelectedValue as string;
                }
                else
                {
                    return cboMainCategory2.SelectedValue as string;
                }
            }
        }

        public string SelectedChildCatID
        {
            get {
                if (punchlistType == "CMD")
                {
                    return cboChildCategory.SelectedValue as string;
                }
                else
                {
                    return cboChildCategory2.SelectedValue as string;
                }
            }
        }

        public string SelectedGrandChildID
        {
            get {
                if (punchlistType == "CMD")
                {
                    return cboGrandChildCategory.SelectedValue as string;
                }
                else
                {
                    return cboGrandChildCategory2.SelectedValue as string;
                }
            }
        }

        public UnitPunchlistingForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new UnitPunchlistPresenter(this);

            cboMainCategory.Tag = "CMD";
            cboMainCategory2.Tag = "BYR";
            cboChildCategory.Tag = "CMD";
            cboChildCategory2.Tag = "BYR";
            cboGrandChildCategory.Tag = "CMD";
            cboGrandChildCategory2.Tag = "BYR";
            cboDefectsCategory.Tag = "CMD";
            cboDefectsCategory2.Tag = "BYR";

            CMDUnitPunchlistTabPage.Tag = "CMD";
            UnitOwnerTabPage.Tag = "BYR";
            kryptonGroupBox1.Enabled = false;

           // btnSearchAccount_Click(this, EventArgs.Empty);
        }

        public void LoadDefaults()
        {
          txtUnitNumber.Text = string.Empty;
          txtLastName.Text = string.Empty;
          txtFirstName.Text = string.Empty;
          txtMiddleName.Text = string.Empty;
          txtNameSuffix.Text = string.Empty;
        }
      
        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (AccountLookupForm  frm = new AccountLookupForm(AccountLookupDisplay.AllUnits))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    kryptonGroupBox1.Enabled = true;
                    this.Cursor = Cursors.WaitCursor;
                    this.SelectedAccount = frm.SelectedUnit;

                    LoadAccountDetails(this, EventArgs.Empty);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        public void SetAccountInfo()
        {
            txtUnitNumber.Text = this.SelectedAccount.UnitNumber;
            if (this.SelectedAccount.OwnerAccount != null) {
                txtLastName.Text = this.SelectedAccount.OwnerAccount.Owner.LastName;
                txtFirstName.Text = this.SelectedAccount.OwnerAccount.Owner.FirstName;
                txtMiddleName.Text = this.SelectedAccount.OwnerAccount.Owner.MiddleName;
            }
            else {
                txtLastName.Text = String.Empty;
                txtFirstName.Text = String.Empty;
                txtMiddleName.Text = String.Empty;
            }
          
        }

        public void SetUnitTurnOverInfo(UnitPunchlistInfo punchlistInfo)
        {
            //Show Unit Punchlist Summary
            if (punchlistInfo.CMDTurnOverDate.HasValue)
            {
                lblCMDTurnOverDate.Text = punchlistInfo.CMDTurnOverDate.Value.ToString("MMMM dd, yyyy");
            }
            else
            {
                lblCMDTurnOverDate.Text = "NOT AVAILABLE";
            }
            if (punchlistInfo.LatestOwnerInspectionDate.HasValue)
            {
                lblLatestOwnerInspectionDate.Text = punchlistInfo.LatestOwnerInspectionDate.Value.ToString("MMMM dd, yyyy");
            }
            else {
                lblLatestOwnerInspectionDate.Text = "NOT AVAILABLE";
            }
            if (punchlistInfo.UnitOwnerAcceptanceDate.HasValue)
            {
                lblUnitOwnerAcceptanceDate.Text = punchlistInfo.UnitOwnerAcceptanceDate.Value.ToString("MMMM dd, yyyy");
            }
            else {
                lblUnitOwnerAcceptanceDate.Text = "NOT AVAILABLE";
            }
        }

        public void LoadCMDPunchList(List<UnitPunchlist> cmdPunchList)
        {
            bool withPunchlist = cmdPunchList.Count > 0;
            newCMDEntry = false;
            CMDPunchlistPanel.Visible = withPunchlist;
            CMDPunchlistDetailsPanel.Visible = withPunchlist;
            btnSaveCMDPunchlist.Enabled = withPunchlist;
            btnPrintCMDPunchlist.Enabled = withPunchlist;

            if (withPunchlist)
            {
                cboCMDInspectionInstance.DisplayMember = "InspectionInstance";
                cboCMDInspectionInstance.ValueMember = "PunchlistID";
                cboCMDInspectionInstance.DataSource = cmdPunchList;
                lblNewCMDPunchList.Visible = false;
            }
            

        }

        public void LoadOwnerPunchList(List<UnitPunchlist> ownerPunchList)
        {
            bool withPunchlist = ownerPunchList.Count > 0;
            newOwnerEntry = false;
            OwnerPunchlistPanel.Visible = withPunchlist;
            OwnerPunchlistDetailsPanel.Visible = withPunchlist;
            btnSaveOwnerPunchlist.Enabled = withPunchlist;
            btnPrintOwnerPunchlist.Enabled = withPunchlist;

            if (withPunchlist)
            {
                cboOwnerInspectionInstance.DisplayMember = "InspectionInstance";
                cboOwnerInspectionInstance.ValueMember = "PunchlistID";
                cboOwnerInspectionInstance.DataSource = ownerPunchList;
                lblNewOwnerPunchlist.Visible = false;
            }

        }

        public void SetCMDPunchlistInfo(UnitPunchlist cmdPunchList)
        {
            dtpCMDInspectionDate.Value = cmdPunchList.InspectionDate;
            txtCMDInspectedBy.Text = cmdPunchList.InspectedBy;
            txtCMDInspectionRemarks.Text = cmdPunchList.Remarks;
        }

        public void SetOwnerPunchlistInfo(UnitPunchlist ownerPunchList)
        {
            dtpOwnerInspectionDate.Value = ownerPunchList.InspectionDate;
            txtOwnerInspectedBy.Text = ownerPunchList.InspectedBy;
            txtOwnerInspectionRemarks.Text = ownerPunchList.Remarks;
        }

        private void cboCMDInspectionInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCMDInspectionInstance.SelectedItem != null) {
                this.CMDPunchlistChanged(this,EventArgs.Empty);
            }
        }

        private void cboOwnerInspectionInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOwnerInspectionInstance.SelectedItem != null)
            {
                this.OwnerPunchlistChanged(this, EventArgs.Empty);
            }
        }

        private void btnNewCMDPunchlist_Click(object sender, EventArgs e)
        {
            if (btnNewCMDPunchlist.Text == "NEW")
            {
                this.NewCMDPunchlist(this, EventArgs.Empty);
            }
            else
            {
                if (MessageBox.Show("Save Punchlist?", "CMD Punchlist Save Confirmation",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.SavePunchlist(this, EventArgs.Empty);
                    lblNewCMDPunchList.Visible = false;

                    btnNewCMDPunchlist.Text = "NEW";
                    btnSaveCMDPunchlist.Text = "SAVE";
                    MessageBox.Show("CMD Punchlist succesfully saved");
                }

            }
        }
       
        private void btnNewOwnerPunchlist_Click(object sender, EventArgs e)
        {
           
            if (btnNewOwnerPunchlist.Text == "NEW")
            {
                if (this.SelectedAccount.OwnerAccount==null)
                {
                    MessageBox.Show("Unit has no owner yet", "Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { 
                  this.NewOwnerPunchlist(this, EventArgs.Empty);
                }
            }
            else {
                if (MessageBox.Show("Save Punchlist?", "Unit Owner Punchlist Save Confirmation",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.SavePunchlist(this, EventArgs.Empty);
                    lblNewOwnerPunchlist.Visible = false;

                    btnNewOwnerPunchlist.Text = "NEW";
                    btnSaveOwnerPunchlist.Text = "SAVE";
                    MessageBox.Show("Unit Owner Punchlist succesfully saved");

      
                }
            
            }
       
        }

        public void NewEntryCMDPunchlist()
        {
            lblNewCMDPunchList.Visible = true;

            btnNewCMDPunchlist.Enabled = true;
            btnSaveCMDPunchlist.Enabled = true;
            btnPrintCMDPunchlist.Enabled = false;

            btnNewCMDPunchlist.Text = "SAVE";
            btnSaveCMDPunchlist.Text = "CANCEL";

            dtpCMDInspectionDate.Value = DateTime.Today;
            txtCMDInspectedBy.Text = string.Empty;
            txtCMDInspectionRemarks.Text = string.Empty;

            CMDPunchlistPanel.Visible = true;
            CMDPunchlistDetailsPanel.Visible = true;

            CMDPunchlistPanel.Visible = true;
        }

        public void NewEntryOwnerPunchlist()
        {
            lblNewOwnerPunchlist.Visible = true;

            btnNewOwnerPunchlist.Enabled = true;
            btnSaveOwnerPunchlist.Enabled = true;
            btnPrintOwnerPunchlist.Enabled  = false;

            btnNewOwnerPunchlist.Text = "SAVE";
            btnSaveOwnerPunchlist.Text = "CANCEL";

            dtpOwnerInspectionDate.Value = DateTime.Today;
            txtOwnerInspectedBy.Text = string.Empty;
            txtOwnerInspectionRemarks.Text = string.Empty;

            OwnerPunchlistPanel.Visible = true;
            OwnerPunchlistDetailsPanel.Visible = true;

            OwnerPunchlistPanel.Visible = true;
        }

        private void btnPrintCMDPunchlist_Click(object sender, EventArgs e)
        {
            this.PrintPunchlist(this, EventArgs.Empty);
        }
        
        private void btnPrintOwnerPunchlist_Click(object sender, EventArgs e)
        {
            this.PrintPunchlist(this, EventArgs.Empty);
        }
        
        private void btnSaveCMDPunchlist_Click(object sender, EventArgs e)
        {
            if (btnSaveCMDPunchlist.Text == "CANCEL")
            {
                if (MessageBox.Show("Cancel Punchlist?", "CMD Punchlist Cancel Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lblNewCMDPunchList.Visible = false;

                    btnNewCMDPunchlist.Text = "NEW";
                    btnSaveCMDPunchlist.Text = "SAVE";

                    this.CancelNewCMDPunchlist(this, EventArgs.Empty);
                }
            }
            else
            {
                if (MessageBox.Show("Save Punchlist?", "CMD Punchlist Save Confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.SavePunchlist(this, EventArgs.Empty);
                    lblNewCMDPunchList.Visible = false;
                    MessageBox.Show("CMD Punchlist succesfully saved");
                }
            }
        }
      
        private void btnSaveOwnerPunchlist_Click(object sender, EventArgs e)
        {
            if (btnSaveOwnerPunchlist.Text == "CANCEL")
            {
                if (MessageBox.Show("Cancel Punchlist?", "Unit Owner Punchlist Cancel Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lblNewOwnerPunchlist.Visible = false;

                    btnNewOwnerPunchlist.Text = "NEW";
                    btnSaveOwnerPunchlist.Text  = "SAVE";

                    this.CancelNewOwnerPunchlist(this, EventArgs.Empty);
                }


            }
            else
            {
                if (MessageBox.Show("Save Punchlist?", "Unit Owner Punchlist Save Confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.SavePunchlist(this, EventArgs.Empty);
                    lblNewOwnerPunchlist.Visible = false;
                    MessageBox.Show("Unit Owner Punchlist succesfully saved");
                }
            }
        }
       
        private void cboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as KryptonComboBox;

            punchlistType = cbo.Tag.ToString();

            if (cbo.SelectedItem != null)
            {
                this.ParentCategoryChanged(this, EventArgs.Empty);
               
            }
        }

        private void cboChildCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as KryptonComboBox;

            punchlistType = cbo.Tag.ToString();

            if (cbo.SelectedItem != null)
            {
                this.ChildCategoryChanged(this, EventArgs.Empty);
                
            }
        }
        
        private void cboGrandChildCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as KryptonComboBox;

            punchlistType = cbo.Tag.ToString();

            if (cbo.SelectedItem != null)
            {
                this.GrandChildCategoryChanged (this, EventArgs.Empty );
            
            }  
        }
     
        private void cboDefectsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as KryptonComboBox;

            punchlistType = cbo.Tag.ToString();

            if (cbo.SelectedItem != null)
            {
                this.DefectsCategoryChanged(this, EventArgs.Empty);
            }  
        }
        
        public void SetParentComboboxList(List<KeyValuePair<string, string>> list)
        {
            if (punchlistType.Equals("CMD"))
            {
                cboMainCategory.ValueMember = "Key";
                cboMainCategory.DisplayMember = "Value";
                cboMainCategory.DataSource = list;

                if (list.Count == 0)
                {
                    cboGrandChildCategory.DataSource = null;
                }
            }
            else {
                cboMainCategory2.ValueMember = "Key";
                cboMainCategory2.DisplayMember = "Value";
                cboMainCategory2.DataSource = list;

                if (list.Count == 0)
                {
                    cboGrandChildCategory2.DataSource = null;
                }
            }
        }  
        
        public void SetChildComboboxList(List<KeyValuePair<string, string>> list)
        {
            if (punchlistType.Equals("CMD"))
            { 
                cboChildCategory.ValueMember = "Key";
                cboChildCategory.DisplayMember = "Value"; 
                cboChildCategory.DataSource = list;  
            }
            else { 
                cboChildCategory2.ValueMember = "Key";
                cboChildCategory2.DisplayMember = "Value";
                cboChildCategory2.DataSource = list;  
            }
        }
       
        public void SetGrandChildComboboxList(List<KeyValuePair<string, string>> list)
        {
            if (punchlistType.Equals("CMD"))
            {
                cboGrandChildCategory.ValueMember = "Key";
                cboGrandChildCategory.DisplayMember = "Value";   
                cboGrandChildCategory.DataSource = list;
            }
            else {
                cboGrandChildCategory2.ValueMember = "Key";
                cboGrandChildCategory2.DisplayMember = "Value";
                cboGrandChildCategory2.DataSource = list;            
            }

        }

        public void SetDefectAreaComboboxList(List<KeyValuePair<string, string>> list)
        {
            if (punchlistType.Equals("CMD"))
            {
                cboDefectsCategory.ValueMember = "Key";
                cboDefectsCategory.DisplayMember = "Value";
                cboDefectsCategory.DataSource = list;
            }
            else { 
                cboDefectsCategory2.ValueMember = "Key";
                cboDefectsCategory2.DisplayMember = "Value";
                cboDefectsCategory2.DataSource = list;            
            }
        }
       
        public void FormatDataGrid()
        {
            SetDatagridView(ref dgCMDPunchlistDetails);
            SetDatagridView(ref dgOwnerPunchlistDetails);
        }

        private void SetDatagridView(ref KryptonDataGridView dg)
        {

            dg.AutoGenerateColumns = false;

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DetailsID",
                HeaderText = "ID",
                Visible = false

            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CriteriaID",
                HeaderText = "ID",
                Visible = false
                
            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ParentID",
                HeaderText = "Parent ID",
                Visible = false
            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CriteriaName",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "CRITERIA NAME",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "InGoodCondition",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "IN GOOD CONDITION",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "FunAffectedItem",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "AFFECTED ITEM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag ="FUN"
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "FunDefect",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "FINDINGS",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag ="FUN"
            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FunRemarks",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "REMARKS",
                Tag ="FUN"
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "InsAffectedItem",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "AFFECTED ITEM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag = "INS"
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "InsDefect",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "FINDINGS",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag = "INS"
               
            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InsRemarks",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "REMARKS",
                Tag = "INS"
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "FinAffectedItem",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "AFFECTED ITEM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag = "FIN"
            });

            dg.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "FinDefect",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                HeaderText = "FINDINGS",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                Tag = "FIN"
            });

            dg.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FinRemarks",
                HeaderCell = new DataGridViewColumnHeaderCell { Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "REMARKS",
                Tag = "FIN"
            });
        }

        public void SetGridSource(List<UnitPunchlstDetailsInfo> defaultTemplate, string punchlistType)
        {

            KryptonDataGridView dg;

            if (punchlistType.Equals("CMD"))
            {
                dg = dgCMDPunchlistDetails;
            }
            else
            {
                dg = dgOwnerPunchlistDetails;
            }


            dg.Rows.Clear();
            foreach (UnitPunchlstDetailsInfo tmpt in defaultTemplate)
            {

                var dr = new DataGridViewRow();

                dr.Cells.Add(new DataGridViewTextBoxCell { Value = String.Empty });
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = tmpt.punchlistCriteria.ID });
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = tmpt.punchlistCriteria.ParentID});
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = tmpt.Criteria });

                var dcb = new DataGridViewComboBoxCell();

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.InGoodCondition,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value ="NA"                   

                });

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.FunctionalityDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1" ,
                });

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.FunctionalityDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1",
                });

                dr.Cells.Add(new DataGridViewTextBoxCell 
                {
                    Value = "",
                    Tag = "Remarks"
                }); 

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.InstallationDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1",
                });

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.InstallationDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1",
                });

                dr.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = "",
                    Tag ="Remarks"
                });

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.FInishingDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1",
                    
                });

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = tmpt.FInishingDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = "-1",
                });

                dr.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = "",
                    Tag ="Remarks"
                });

                dg.Rows.Add(dr);
            }

            for (int i = 0; i <= dg.RowCount - 1; i++)
            {
                //TODO: iterate through the column list starting at idx 5
                ManipulateCell(ref dg, 5, i, true);
                ManipulateCell(ref dg, 6, i, true);
                ManipulateCell(ref dg, 7, i, true);
                ManipulateCell(ref dg, 8, i, true);
                ManipulateCell(ref dg, 9, i, true);
                ManipulateCell(ref dg, 10, i, true);
                ManipulateCell(ref dg, 11, i, true);
                ManipulateCell(ref dg, 12, i, true);
                ManipulateCell(ref dg, 13, i, true);
            }
        }

        public void SetGridViewDisplay(string punchlistType)
        {
            KryptonDataGridView dg;

            if (punchlistType.Equals("CMD"))
            {
                dg = dgCMDPunchlistDetails;
            }
            else
            {
                dg = dgOwnerPunchlistDetails;
            }

            //Hide rows based on category
            foreach (DataGridViewRow rw in dg.Rows)
            {
                try
                {
                    rw.Visible = string.Equals(rw.Cells[2].Value.ToString(), this.SelectedCriteriaParentID);
                }
                catch (Exception)
                {
                    continue;
                }
               
            }

            foreach (DataGridViewColumn dc in dg.Columns)
            {
                try
                {

                    if (!String.IsNullOrEmpty(dc.Tag.ToString()))
                    {
                        dc.Visible = dc.Tag.ToString().Equals(SelectedDefectID);
                    }
                    
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private void dgCMDPunchlistDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgCMDPunchlistDetails.IsCurrentCellDirty)
            {
                dgCMDPunchlistDetails.CommitEdit( DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgOwnerPunchlistDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgOwnerPunchlistDetails.IsCurrentCellDirty)
            {
                dgOwnerPunchlistDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgCMDPunchlistDetails_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
             int refColumIndex = 4;
             if (e.ColumnIndex == refColumIndex)
            {
                if (e != null)
                {
                    bool disabled = !e.Value.Equals("NO");
                  
                    for (int i = refColumIndex + 1; i <= dgCMDPunchlistDetails.ColumnCount -1; i++)
                    {
                        ManipulateCell(ref dgCMDPunchlistDetails, i, e.RowIndex, disabled);
                    }
                }
            }
        }

        private void dgOwnerPunchlistDetails_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int refColumIndex = 4;
            if (e.ColumnIndex == refColumIndex)
            {
                if (e != null)
                {
                    bool disabled = !e.Value.Equals("NO");

                    for (int i = refColumIndex + 1; i <= dgOwnerPunchlistDetails.ColumnCount - 1; i++)
                    {
                        ManipulateCell(ref dgOwnerPunchlistDetails, i, e.RowIndex, disabled);
                    }
                }
            }
        }

        private void ManipulateCell(ref KryptonDataGridView dv, int columnIdx, int rowidx,bool disabled) {
            var affectedcell = dv[columnIdx, rowidx];

            if (disabled)
            {
                //TODO: must get type of datagriviewcell to properly set default to combo box or textbox
                if (affectedcell.Tag =="Remarks")
                {
                    affectedcell.Value = String.Empty;
                }
                else {
                    affectedcell.Value = "-1";
                }
               // affectedcell.Style.BackColor = Color;
            }
            else
            {
              //  affectedcell.Style.BackColor = Color.White;

            }
            affectedcell.ReadOnly = disabled;
        }

        public UnitPunchlist GetPunchlistDetails()
        {
            KryptonDataGridView dg; 
            UnitPunchlist punchlistdetails = new UnitPunchlist();

            punchlistdetails.PunchlistType = punchlistType;


            if (punchlistType.Equals("CMD")) {
                try
                {
                    punchlistdetails.PunchlistID = this.SelectedCMDPunchlist.PunchlistID;
                }
                catch (Exception)
                {
                }
                dg = dgCMDPunchlistDetails;        
                punchlistdetails.InspectionDate = dtpCMDInspectionDate.Value;
                punchlistdetails.InspectedBy = txtCMDInspectedBy.Text;
                punchlistdetails.Remarks = txtCMDInspectionRemarks.Text;
            }
            else {
                try
                {
                    punchlistdetails.PunchlistID = this.SelectedOwnerPunchlist.PunchlistID;
                }
                catch (Exception)
                {
                }
                dg = dgOwnerPunchlistDetails;
                punchlistdetails.InspectionDate = dtpOwnerInspectionDate.Value;
                punchlistdetails.InspectedBy = txtOwnerInspectedBy.Text;
                punchlistdetails.Remarks = txtOwnerInspectionRemarks.Text;
            }
          
            punchlistdetails.PunchlistDetails = new List<PunchlistDetail>();
            foreach (DataGridViewRow dr in dg.Rows)
            {
                punchlistdetails.PunchlistDetails.Add(new PunchlistDetail()
                {
                    DetailsID = dr.Cells["DetailsID"].Value as string,
                    Criteria = new PunchlistTemplate() { ID = dr.Cells["CriteriaID"].Value as string },
                    ItemStatus = dr.Cells["InGoodCondition"].Value as string,
                    Findings = GetFindings(dr)
                });
            }

            return punchlistdetails;
        }

        private List<PunchlistFinding> GetFindings(DataGridViewRow dr)
        {
            List<PunchlistFinding> fd = new List<PunchlistFinding>();

            fd.Add(new PunchlistFinding()
            {
                FindingsCategory = "FUN",
                Item = new PunchlistItem() { ID = dr.Cells["FunAffectedItem"].Value as string },
                Defect = new PunchlistDefect() { ID = dr.Cells["FunDefect"].Value as string },
                Remarks = dr.Cells["FunRemarks"].Value as string
            });

            fd.Add(new PunchlistFinding()
            {
                FindingsCategory = "INS",
                Item = new PunchlistItem() { ID = dr.Cells["InsAffectedItem"].Value as string },
                Defect = new PunchlistDefect() { ID = dr.Cells["InsDefect"].Value as string },
                Remarks = dr.Cells["InsRemarks"].Value as string
            });

            fd.Add(new PunchlistFinding()
            {
                FindingsCategory = "FIN",
                Item = new PunchlistItem() { ID = dr.Cells["FinAffectedItem"].Value as string },
                Defect = new PunchlistDefect() { ID = dr.Cells["FinDefect"].Value as string },
                Remarks = dr.Cells["FinRemarks"].Value as string
            });

            return fd;
        }

        public void LoadPunchlistDetails(List<UnitPunchlstDetailsInfo> defaultTemplate,UnitPunchlist punchlist,string punchlistType)
        {
            KryptonDataGridView dg;

            if (punchlistType.Equals("CMD"))
            {
                dg = dgCMDPunchlistDetails;
            }
            else {
                dg = dgOwnerPunchlistDetails;
            }


            dg.Rows.Clear();
            foreach (UnitPunchlstDetailsInfo criteria in defaultTemplate)
            {

                var dr = new DataGridViewRow();
                string detailsid = punchlist.PunchlistDetails.Where(p => p.Criteria.ID.Equals(criteria.punchlistCriteria.ID)).Select(p => p.DetailsID).SingleOrDefault();

                dr.Cells.Add(new DataGridViewTextBoxCell { Value = detailsid });
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = criteria.punchlistCriteria.ID });
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = criteria.punchlistCriteria.ParentID });
                dr.Cells.Add(new DataGridViewTextBoxCell { Value = criteria.Criteria });

              
                bool isExist =punchlist.PunchlistDetails.Exists(p => p.Criteria.ID.Equals(criteria.punchlistCriteria.ID));
                bool isFUNExist = punchlist.PunchlistDetails.Where(p=>p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).ToList().Exists(p => p.FindingsCategory.Equals ("FUN"));
                bool isINSExist = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).ToList().Exists(p => p.FindingsCategory.Equals("INS"));
                bool isFINExist = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).ToList().Exists(p => p.FindingsCategory.Equals("FIN"));


                string itemStatus = "NA";
                if (isExist)
                {
                  itemStatus = punchlist.PunchlistDetails.Where(p => p.Criteria.ID.Equals(criteria.punchlistCriteria.ID)).Select(p => p.ItemStatus).SingleOrDefault();
                }
                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                   DataSource = criteria.InGoodCondition,
                   DisplayMember = "Value",
                   ValueMember = "Key",
                   DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                   Value = itemStatus
                });


                string funItem = "-1";
                if (isExist)
                {
                    if (isFUNExist) {
                        funItem = punchlist.PunchlistDetails.Where(p=>p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FUN")).Select(p => p.Item.ID).SingleOrDefault();
                    }
                }

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.FunctionalityDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = funItem,
                });


                string funDefect = "-1";
                if (isExist)
                {
                    if (isFUNExist)
                    {
                        funDefect = punchlist.PunchlistDetails.Where(p=>p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FUN")).Select(p => p.Defect.ID).SingleOrDefault();
                    }
                }

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.FunctionalityDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = funDefect,
                });

                string funRemarks = String.Empty;
                if (isExist)
                {
                    if (isFUNExist)
                    {
                        funRemarks = punchlist.PunchlistDetails.Where(p=>p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FUN")).Select(p => p.Remarks).SingleOrDefault();
                    }
                }

                dr.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = funRemarks,
                    Tag = "Remarks"
                });


                string insItem = "-1";
                if (isExist)
                {
                    if (isINSExist)
                    {
                        insItem = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("INS")).Select(p => p.Item.ID).SingleOrDefault();
                    }
                }

                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.InstallationDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = insItem,
                });


                string insDefect = "-1";
                if (isExist)
                {
                    if (isINSExist)
                    {
                        insDefect = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("INS")).Select(p => p.Defect.ID).SingleOrDefault();
                    }
                }
                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.InstallationDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = insDefect,
                });

                string insRemarks = String.Empty;
                if (isExist)
                {
                    if (isINSExist)
                    {
                        insRemarks = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("INS")).Select(p => p.Remarks).SingleOrDefault();
                    }
                }

                dr.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = insRemarks,
                    Tag = "Remarks"
                });



                string finItem = "-1";
                if (isExist)
                {
                    if (isFINExist)
                    {
                        finItem = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FIN")).Select(p => p.Item.ID).SingleOrDefault();
                    }
                }
                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.FInishingDefects.AffectedItem,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = finItem,

                });


                string finDefect = "-1";
                if (isExist)
                {
                    if (isFINExist)
                    {
                        finDefect = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FIN")).Select(p => p.Defect.ID).SingleOrDefault();
                    }
                }
                dr.Cells.Add(new DataGridViewComboBoxCell
                {
                    DataSource = criteria.FInishingDefects.ItemDefect,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    Value = finDefect,
                });


                string finRemarks = String.Empty;
                if (isExist)
                {
                    if (isFINExist)
                    {
                        finRemarks = punchlist.PunchlistDetails.Where(p => p.DetailsID.Equals(detailsid)).SelectMany(p => p.Findings).Where(p => p.FindingsCategory.Equals("FIN")).Select(p => p.Remarks).SingleOrDefault();
                    }
                }
                dr.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = finRemarks,
                    Tag = "Remarks"
                });

                dg.Rows.Add(dr);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.punchlistType = (sender as TabControl).SelectedTab.Tag.ToString();
        }


        public void DisplayPunchlistReport(List<UnitPunchlistDetailReportInfo> rep)
        {

            using (ReportStore rps = new ReportStore())
            {
                try
                {
                    UnitPunchlistReport frm = new UnitPunchlistReport(rep);
                    frm.PunchlistType = this.punchlistType;
                    if (this.punchlistType == "CMD")
                    { 
                      frm.UnitNumber = this.SelectedAccount.UnitNumber;  
                      frm.InspectionDate = dtpCMDInspectionDate.Value.Date;
                    }
                    else {
                        frm.UnitNumber = String.Format("{0} - {1} {2} {3}", this.SelectedAccount.UnitNumber, this.SelectedAccount.OwnerAccount.Owner.FirstName, this.SelectedAccount.OwnerAccount.Owner.MiddleName, this.SelectedAccount.OwnerAccount.Owner.LastName);
                        frm.InspectionDate = dtpOwnerInspectionDate.Value.Date;
                    }
                 
                    rps.LoadReport(frm);
                }
                catch (Exception ex)
                {
                    this.Show();
                    MessageBox.Show(ex.Message, "Unable to load report", MessageBoxButtons.OK);
                }
            }
        }
        public event EventHandler<EventArgs> LoadAccountDetails;
        public event EventHandler<EventArgs> CMDPunchlistChanged;
        public event EventHandler<EventArgs> OwnerPunchlistChanged;
        public event EventHandler<EventArgs> NewCMDPunchlist;
        public event EventHandler<EventArgs> NewOwnerPunchlist;
        public event EventHandler<EventArgs> CancelNewCMDPunchlist;
        public event EventHandler<EventArgs> CancelNewOwnerPunchlist;
        public event EventHandler<EventArgs> GrandChildCategoryChanged;
        public event EventHandler<EventArgs> ParentCategoryChanged;
        public event EventHandler<EventArgs> ChildCategoryChanged;
        public event EventHandler<EventArgs> DefectsCategoryChanged;
        public event EventHandler<EventArgs> SavePunchlist;
        public event EventHandler<EventArgs> PrintPunchlist;

        private void dtpCMDAcceptanceDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
