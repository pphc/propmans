using BCL.Checks;
using BCL.Common;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class ChecksAmountDistributionForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        private string AccountID { get; set; }
        private string AccountName { get; set; }
        private string LeaseID { get; set; }
        private string UnitNumber { get; set; }
        public SiteDivision FeeDivision { get; set; }
        public List<CheckAmountDistribution> AmountDistribution { get; set; }
        public List<NewCheckAmountDistribution> RemainingAmountDistribution { get; set; }
        public ChecksAmountDistributionForm(SiteDivision division, List<NewCheckAmountDistribution>  remainingDistribution)
        {
            this.FeeDivision = division;
            this.RemainingAmountDistribution = remainingDistribution;

            InitializeComponent();
            InitializeReferences();
        }

        private void InitializeReferences()
        {
            Common.BindComboBoxtoList(ref cboFeeType, new RecurringBillFees(this.FeeDivision));
            //btnSaveDistribution.Visible = false;

           // dgChecksDistribution.Columns.Add(new DataGridViewCheckBoxColumn { Name = "selected", ReadOnly =false });
            dgChecksDistribution.DataSource = RemainingAmountDistribution;

            btnSaveDistribution.Visible = RemainingAmountDistribution.Count > 0;

            txtDistributionAmount.KeyPress += Common.Decimal_KeyPress;
        }


        private void btnSelectAccount_Click(object sender, EventArgs e)
        {
            using (AccountLookupForm frm = new AccountLookupForm()) {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
                    this.AccountID = frm.AccountID;
                    this.UnitNumber = frm.UnitNumber;
                    this.AccountName = frm.CustomerFullName;
                    txtAccountName.Text = this.UnitNumber +"-"+ this.AccountName;   

                    Common.BindComboBoxtoList(ref cboFeeType, new RecurringBillFees(this.FeeDivision,frm.UnitClass));
                
                }
            }
        }
        private void btnDistributeAmount_Click(object sender, EventArgs e)
        {
            if (Common.HasValue(txtDistributionAmount))
            {
                chkSelectAll.Checked = true;
           
                foreach (DataGridViewRow dr in dgChecksDistribution.Rows)
                {
                    dr.Cells[3].Value = Decimal.Parse(txtDistributionAmount.Text.Trim());

                }

                txtDistributionAmount.SelectAll();
                txtDistributionAmount.Focus();
            
            }

        }


        private void btnSaveDistribution_Click(object sender, EventArgs e)
        {
            GetSelection();
            if (IsEntryValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void dgChecksDistribution_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dgChecksDistribution.CurrentCell.ColumnIndex == 3)
            {
                TextBox txtEdit = (TextBox)e.Control;

                txtEdit.KeyPress += txtEdit_KeyPress;

            }
        }

        void txtEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.IsNumeric(((TextBox)sender).Text , e.KeyChar, true);
        }

        private void dgChecksDistribution_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3) {
                if (dgChecksDistribution[3,e.RowIndex].Value != null) {
                    decimal maxvalue = decimal.Parse(dgChecksDistribution[2, e.RowIndex].Value.ToString());
                    decimal changedvalue = decimal.Parse(dgChecksDistribution[3, e.RowIndex].Value.ToString());
                    if ((changedvalue != 0) && (changedvalue <=maxvalue))
                    {

                    }
                    else
                    {
                        dgChecksDistribution[3, e.RowIndex].Value = maxvalue;
                    }
                }
              
            }

            //if (e.ColumnIndex == 0)
            //{
            //     if (bool.Parse(dgChecksDistribution[0,e.RowIndex].Value.ToString()))
            //     {
            //         dgChecksDistribution[3, e.RowIndex].Style.BackColor  = Color.Yellow;
            //     }
            //     else
            //     {
            //         dgChecksDistribution[3, e.RowIndex].Style.BackColor = Color.Empty;
            //     }

            //}
        }


        private void dgChecksDistribution_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgChecksDistribution.IsCurrentCellDirty)
                {
                    dgChecksDistribution.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgChecksDistribution_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (e.ColumnIndex == 3)
            {
                if (dgChecksDistribution[0, e.RowIndex].Value != null) { 
                      if (bool.Parse(dgChecksDistribution[0,e.RowIndex].Value.ToString()) == false)
                    {
                        e.Cancel = true;
                    }
                }
            }
       
        }

        private bool IsEntryValid() {

            bool valid = true;

            if (string.IsNullOrEmpty(this.AccountID)) {
                btnSelectAccount_Click(null,null);
                valid = false;
            }

            if (this.AmountDistribution.Count == 0) {
                MessageBox.Show("Check Amount is not distrubuted", "No Check Amount Distribution");
                valid = false;
            }

            return valid;
        
        }

        private void GetSelection() {
            this.AmountDistribution = new List<CheckAmountDistribution>();

            string feeTypeid = cboFeeType.SelectedValue.ToString();
            string feeName = cboFeeType.Text;
            foreach (NewCheckAmountDistribution cd in (List<NewCheckAmountDistribution>)dgChecksDistribution.DataSource)
            {
                if (cd.Selected) {
                    AmountDistribution.Add(new CheckAmountDistribution
                    {
                         CheckInfo = cd.Check,
                        AmountDistribution = cd.AmountDistribution,
                        FeeType = new FeeType { FeeTypeID = feeTypeid, FeeName = feeName },
                        AccountName = new Account { AccountID = this.AccountID, LeaseID = this.LeaseID, AccountName = this.AccountName,UnitNumber=this.UnitNumber  }
                    });
                }
            }


        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool Isselected = chkSelectAll.Checked;

            foreach (DataGridViewRow dr in dgChecksDistribution.Rows){
                dr.Cells[0].Value = Isselected;
            }

        }

        private void dgChecksDistribution_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

   
   

  
 

   

     
    }
}
