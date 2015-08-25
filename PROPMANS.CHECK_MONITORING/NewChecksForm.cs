using BCL.Checks;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PROPMANS.CHECK_MONITORING
{
    public partial class NewChecksForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        private List<Check> _checks;
        public List<Check> Checks { 
             get{
                return _checks;
               }
             set {
                _checks = value;
            }
        }

        public CheckCustodian CheckPayee{get;set;}
        public NewChecksForm(CheckCustodian checkPayee)
        {
            this.CheckPayee = checkPayee;
            InitializeComponent();
            InitializeReferences();
        }

        private void InitializeReferences()
        {
            Common.BindComboBoxtoList(ref cboCheckBank, new CheckBank());
            Common.BindComboBoxtoList(ref cboCheckBranch, new BankBranch());
            Common.BindComboBoxtoList(ref cboCheckClearing, typeof(CheckClearing));
            Common.BindComboBoxtoList(ref cboCheckPayee, typeof(CheckCustodian));

            cboCheckPayee.SelectedValue = CheckPayee;
            cboCheckPayee.Enabled = false;

            txtCheckStartNumber.KeyPress += Common.Numeric_KeyPress;
            txtCheckEndNumber.KeyPress += Common.Numeric_KeyPress;
            
            txtCheckAmount.KeyPress += Common.Decimal_KeyPress;
        }

        private void btnPreviewChecks_Click(object sender, EventArgs e)
        {
            if (IsEntryValid()) {
                AddChecks();
                using (Form frm = new NewChecksPreviewForm(this.Checks))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Boolean IsEntryValid() {
            errorProvider1.Clear();

            bool valid = true;

            if (!(Common.HasValue(txtCheckStartNumber)))
            {
                errorProvider1.SetError(txtCheckStartNumber, "Enter Value for Starting Check Number");
                valid = false;
            }

            if (!(Common.HasValue(txtCheckEndNumber)))
            {
                errorProvider1.SetError(txtCheckEndNumber, "Enter Value for Ending Check Number");
                valid = false;
            }

            if (!(Common.HasValue(txtCheckAmount)))
            {
                errorProvider1.SetError(txtCheckAmount, "Enter Value for Check Amount");
                valid = false;
            }

            if (Common.HasValue(txtCheckStartNumber) && Common.HasValue(txtCheckEndNumber)) {
                if (Decimal.Parse(txtCheckStartNumber.Text) > Decimal.Parse(txtCheckEndNumber.Text))
                {
                    errorProvider1.SetError(txtCheckStartNumber, "Enter Valid Check Number range");
                    errorProvider1.SetError(txtCheckEndNumber, "Enter Valid Check Number range");
                    valid = false;
                }
            
            }

            return valid; 
        }

        private void AddChecks() { 
        
            this.Checks = new List<Check>();

            Int32 endNumber = Int32.Parse(txtCheckEndNumber.Text);
            Int32 startNumber = Int32.Parse(txtCheckStartNumber.Text);
            DateTime chkDate = dtpCheckDate.Value.Date;
            int day = dtpCheckDate.Value.Date.Day;
            bool isEndofMonth = day == (DateTime.DaysInMonth(chkDate.Year, chkDate.Month));
            for (Int32 i = startNumber;  i<= endNumber ;i++) {
                Check chk = new Check
                {
                    CheckID =i.ToString() + cboCheckBank.SelectedValue.ToString(),
                    CheckNumber = i.ToString(),
                    CheckAmount = Decimal.Parse(txtCheckAmount.Text),
                    CheckDate = chkDate,
                    Bank  = new CheckBank{ BankID =  cboCheckBank.SelectedValue.ToString(),  BankName = cboCheckBank.Text },
                    Branch = new BankBranch { BranchID =  cboCheckBranch.SelectedValue.ToString(), BranchName = cboCheckBranch.Text },
                    Clearing = (CheckClearing)cboCheckClearing.SelectedValue,
                    Payee = (CheckCustodian)cboCheckPayee.SelectedValue,
                    RTNumber = txtRTNNumber.Text
                };

                DateTime nextmonth = chkDate.AddMonths(1);
                if (isEndofMonth)
                {
                    chkDate = new DateTime(nextmonth.Year, nextmonth.Month, DateTime.DaysInMonth(nextmonth.Year, nextmonth.Month));
                }
                else {
                    if (DateTime.DaysInMonth(nextmonth.Year, nextmonth.Month) < day)
                    {
                        chkDate = new DateTime(nextmonth.Year, nextmonth.Month, DateTime.DaysInMonth(nextmonth.Year, nextmonth.Month));
                    }
                    else
                    {
                        chkDate = new DateTime(nextmonth.Year, nextmonth.Month, day);
                    }
                }
              
             

                this.Checks.Add(chk);
            }
        }

    }
}
