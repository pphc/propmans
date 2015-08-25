using PROPMANS.REPORTS;
using System;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class ChecksDueReportForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        public ChecksDueReportForm()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
        //        Using( rps As New REPORTS.ReportStore
        //    Dim rep As New RentalManagementAgreementReport(CurrentAgreementID)
        //    rps.LoadReport(rep)
        //End Using

           
            using (ReportStore rps = new ReportStore() ){
                try {
                    this.Hide();
                    ChecksDueReport rep = new ChecksDueReport();
                    rep.StartDate = dtpStartDate.Value.Date;
                    rep.EnDate = dtpEndDate.Value.Date;

                    rps.LoadReport(rep);

                    this.Close();
                }
                catch (Exception ex) {
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
