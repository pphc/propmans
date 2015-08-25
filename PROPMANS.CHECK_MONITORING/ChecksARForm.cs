using BCL;
using BCL.Checks;
using PROPMANS.BASE_MOD;
using PROPMANS.REPORTS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class ChecksARForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        #region "Form Instance"
        private static ChecksARForm aForm;
        public static ChecksARForm Instance()
        {
            if (aForm == null)
            {
                aForm = new ChecksARForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        public List<Check> Checks
        { get; set; }

        public List<CheckAmountDistribution> CheckDistribution
        { get; set; }

        private string ARID;
        private string ARNumber;
        public ChecksARForm()
        {
            this.Disposed += Form_Disposed;
            this.Checks = new List<Check>();
            this.CheckDistribution = new List<CheckAmountDistribution>();
            InitializeComponent();
            InitializeScreen();
        }

        private void btnSearchARClick(object sender, EventArgs e)
        {
            using (SearchARForm frm = new SearchARForm())
            {
                if (frm.ShowDialog() == DialogResult.OK) {

                    if (btnSaveAR.Visible == true) {
                        if (this.Checks.Count > 0)
                        {

                            if (MessageBox.Show("Cancel Checks A.R?", "Cancel Current Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        SetUIforCancelEntry();
                    }

                    ARInfo1Panel.Enabled = false;
                    ARInfo2Panel.Enabled = false;
                    this.ARID = frm.ARID;
                    txtARNumber.Text  = frm.ARNumber;
                    dtpARDate.Value = frm.ARDate;
                    cboCheckPayee.SelectedValue = frm.ARCUstodian;
                    txtRemarks.Text = frm.Remarks;
                    txtNotes.Text = frm.Notes;
                    ShowARDetails();
                }
            }
            btnPrintAR.Enabled = !string.IsNullOrEmpty(ARID);
        }

        private void btnAddChecks_Click(object sender, EventArgs e)
        {
            if (cboCheckPayee.SelectedIndex != 0)
            {
                using (NewChecksForm frm = new NewChecksForm((CheckCustodian)cboCheckPayee.SelectedValue))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Checks.AddRange(frm.Checks);

                        dgCheckDetails.DataSource = null;
                        dgCheckDetails.DataSource = this.Checks;

                        lblRecordCount.Text = this.Checks.Count + " records";
                    }
                }
            }
            else {
                cboCheckPayee.Focus();
            }
        } 

        private void btnDistributeCheckAmount_Click(object sender, EventArgs e)
        {
            if (this.Checks.Count > 0)
            {
                BCL.Common.SiteDivision sitediv;
                if ((CheckCustodian)cboCheckPayee.SelectedValue == CheckCustodian.CondoCorp){
                        sitediv = BCL.Common.SiteDivision.CondoCorp;
                }
                else{
                        sitediv = BCL.Common.SiteDivision.Utlities;
                }

                using (ChecksAmountDistributionForm frm = new ChecksAmountDistributionForm(sitediv, GetRemainingDistribution()))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.CheckDistribution.AddRange(frm.AmountDistribution);

                        dgCheckApplication.DataSource = null;
                        dgCheckApplication.DataSource = this.CheckDistribution;

                        lblRecordCount2.Text = this.CheckDistribution.Count + " records";
                    }
                }
            }
            else {
                MessageBox.Show("Please Add Check Details First", "No Check added yet");
            }
            
        }

        private void btnNewAR_Click(object sender, EventArgs e)
        {
            if (btnNewAR.Text == "NEW A.R")
            {
                SetUIforNewEntry();
            }
            else {
                if (this.Checks.Count > 0) {
                    if (MessageBox.Show("Cancel Checks A.R?", "Cancel Current Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }

                SetUIforCancelEntry();

            }
        }

        private void btnSaveAR_Click(object sender, EventArgs e)
        {
            
            if (IsEntryValid()) {
                if (MessageBox.Show("Save New Checks Acknowledgement Receipt?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
               
                    if (SaveARDetails()){
                        MessageBox.Show("New AR Saved", "Checks A.R Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                ARInfo1Panel.Enabled = false;
                ARInfo2Panel.Enabled = false;
                btnSaveAR.Visible = false;
                btnAddChecks.Visible = false;
                btnResetDistribution.Visible = false;
                btnDistributeCheckAmount.Visible = false;
                btnPrintAR.Enabled = ! string.IsNullOrEmpty(ARNumber) && txtARNumber.Text !="NEW ENTRY";

                btnSearchAR.Enabled = true;
                btnNewAR.Text = "NEW A.R";
                }
            }
        }

        private void InitializeScreen()
        {

            Common.BindComboBoxtoList(ref cboCheckPayee, typeof(CheckCustodian),true);

            btnSaveAR.Visible = false;
            btnAddChecks.Visible = false;
            btnResetDistribution.Visible = false;
            btnDistributeCheckAmount.Visible = false;
            btnPrintAR.Enabled  = false;
            ARInfo1Panel.Enabled = false;
            ARInfo2Panel.Enabled = false;


        }

        private void SetUIforNewEntry() {
                ARInfo1Panel.Enabled = true;
                ARInfo2Panel.Enabled = true;
                btnSaveAR.Visible = true;
                btnAddChecks.Visible = true;
                btnResetDistribution.Visible = true;
                btnDistributeCheckAmount.Visible = true;
                btnSearchAR.Enabled = false;
                btnPrintAR.Enabled = false;

                cboCheckPayee.SelectedIndex = 0;
                txtARNumber.Text = "NEW ENTRY";
                dtpARDate.Value = DateTime.Now;
                txtRemarks.Text = string.Empty;
                txtNotes.Text = string.Empty;
                btnNewAR.Text = "CANCEL";

                if (this.Checks.Count > 0) {
                    dgCheckDetails.DataSource = null;
                    lblRecordCount.Text = "No records found";
                    this.Checks.Clear();
                }

                if (this.CheckDistribution .Count > 0)
                {
                    dgCheckApplication.DataSource = null;
                    lblRecordCount2.Text = "No records found";
                    this.CheckDistribution.Clear();
                }
        }

        private void SetUIforCancelEntry() {
            ARInfo1Panel.Enabled = false;
            ARInfo2Panel.Enabled = false;
            btnSaveAR.Visible = false;
            btnAddChecks.Visible = false;
            btnResetDistribution.Visible = false;
            btnDistributeCheckAmount.Visible = false;
            btnSearchAR.Enabled = true;
            btnPrintAR.Enabled = !string.IsNullOrEmpty(ARNumber);

            txtARNumber.Text = string.Empty;
            dtpARDate.Value = DateTime.Now;
            txtRemarks.Text = string.Empty;
            txtNotes.Text = string.Empty;
            btnNewAR.Text = "NEW A.R";

            if (this.Checks.Count > 0)
            {
                dgCheckDetails.DataSource = null;
                lblRecordCount.Text = "No records found";
                this.Checks.Clear();
            }

            if (this.CheckDistribution.Count > 0)
            {
                dgCheckApplication.DataSource = null;
                lblRecordCount2.Text = "No records found";
                this.CheckDistribution.Clear();
            }

        }
        private Boolean  IsEntryValid(){
            errorProvider1.Clear();

            bool valid = true;

            if (!(Common.HasValue(txtRemarks)))
            {
                errorProvider1.SetError(txtRemarks, "Enter Value for A.R Remarks");
                txtRemarks.Focus();
                valid = false;
            }
            else { 
                  if (this.Checks.Count > 0)
                    {
                        if (this.Checks.Count > 36)
                        {
                            MessageBox.Show("No of Checks exceeded the maximum allowed number of checks", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnDistributeCheckAmount.Focus();
                            valid = false;
                        }
                        else
                        {
                            if (GetRemainingDistribution().Count > 0)
                            {
                                MessageBox.Show("Please assign customer account/s for generated check/s.", "Check amount not fully assigned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnDistributeCheckAmount.Focus();
                                valid = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Checks Details found", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnAddChecks.Focus();
                        valid = false;
                    }
            }
      
            return valid; 
        }

        private void ShowARDetails() {

            this.Checks = ChecksDAL.GetCheckDetailsByARID(this.ARID);
            CustomBindingList<Check> csb1 = new CustomBindingList<Check>(this.Checks);
            dgCheckDetails.DataSource = null;
            dgCheckDetails.DataSource = csb1;

            lblRecordCount.Text = this.Checks.Count + " records";

            this.CheckDistribution = ChecksDAL.GetCheckAmountDistributionByARID(this.ARID);
            CustomBindingList<CheckAmountDistribution> csb2 = new CustomBindingList<CheckAmountDistribution>(this.CheckDistribution);
            dgCheckApplication.DataSource = null;
            dgCheckApplication.DataSource = csb2;

            lblRecordCount2.Text = this.CheckDistribution.Count + " records";

        
        }
    

        private Boolean SaveARDetails() {
            this.ARNumber = ChecksDAL.SaveNewAR((CheckCustodian) cboCheckPayee.SelectedValue ,dtpARDate.Value.Date ,txtRemarks.Text.Trim() ,txtNotes.Text.Trim(),  this.Checks ,this.CheckDistribution);

            txtARNumber.Text = this.ARNumber;

            return !(string.IsNullOrEmpty (this.ARNumber)); 
        
        }

        private List<NewCheckAmountDistribution> GetRemainingDistribution() {

            List<NewCheckAmountDistribution> remainingDistribution = new List<NewCheckAmountDistribution>();
            foreach( Check ck in this.Checks )
            {
                decimal remainingAmount = GetRemainingCheckAmount(ck);
                if (remainingAmount > 0) { 
                NewCheckAmountDistribution nd = new NewCheckAmountDistribution();

                nd.Check = ck;
                nd.RemainingAmount = GetRemainingCheckAmount(ck);
                nd.AmountDistribution = nd.RemainingAmount;
                remainingDistribution.Add(nd);
                }
                
            }
            return remainingDistribution;
        
        }

        private decimal GetRemainingCheckAmount(Check check) {
            decimal amount = 0;

            if (CheckDistribution == null) {
                return check.CheckAmount;
            }

            foreach (CheckAmountDistribution amt in CheckDistribution.FindAll(x => x.CheckInfo.CheckID == check.CheckID))
            {
                amount += amt.AmountDistribution;
            }

            return check.CheckAmount - amount;
                
        }

        private void btnResetDistribution_Click(object sender, EventArgs e)
        {
            if (this.CheckDistribution != null){
                if (this.CheckDistribution.Count > 0)
                {

                    if (MessageBox.Show("Reset Check Amount Distribution?", "Reset Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        dgCheckApplication.DataSource = null;
                        this.CheckDistribution.Clear();
                        lblRecordCount2.Text = "No records found";

                    }
                }
            }

        }

        private void btnPrintAR_Click(object sender, EventArgs e)
        { 
            using ( ReportStore rps = new ReportStore()){
                 CheckARReport rep = new CheckARReport();
                 rep.CheckDetails = this.Checks;
                 rep.CheckDistribution = this.CheckDistribution;
                 rep.Custodian = (CheckCustodian)cboCheckPayee.SelectedValue;
                 rep.ARNumber =txtARNumber.Text;
                 rep.ARDate = dtpARDate.Value.Date;
                 rep.PaymentFor = txtRemarks.Text;
                 rps.LoadReport(rep);
             }
        }

 
    


    }
}
