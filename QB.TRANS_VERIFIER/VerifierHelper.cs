using System;

namespace TransactionsVerifier
    {
    public static class VerifierHelper
        {
       
        public static bool  StartVerify(string folderPath,DateTime fromDate, DateTime toDate) {
            Billings bs = new Billings();

            bs.FolderPath =folderPath;
            bs.InvoiceFromDate = fromDate;
            bs.InvoiceToDate = toDate;
            bs.StartCheck();

            return true;
            }
        }
    }
