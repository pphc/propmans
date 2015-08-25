using BCL.Checks;
using PROPMANS.BASE_MOD;
using PROPMANS.REPORTS;
using System;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class CheckStatusReportForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        public CheckStatusReportForm()
        {
            InitializeComponent();
            Common.BindComboBoxtoList(ref cboCheckStatus, new CheckStatusListSrc());
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (cboCheckStatus.SelectedIndex == 0)
            {
                cboCheckStatus.Focus();
                return;
            }

            using (ReportStore rps = new ReportStore() ){
                try
                {
                    this.Hide();
                    CheckByStatusReport rep = new CheckByStatusReport();
                    rep.StartDate = dtpStartDate.Value.Date;
                    rep.EnDate = dtpEndDate.Value.Date;
                    rep.CheckStatus = Common.ConvertDBValueToEnum<CheckStatus>(cboCheckStatus.SelectedValue.ToString());
                    rps.LoadReport(rep);
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Show();
                    MessageBox.Show(ex.Message, "Unable to load report", MessageBoxButtons.OK);
                }

            }
       }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
