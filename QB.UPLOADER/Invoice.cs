using BCL.Common;
using Interop.QBFC12;
using System;
using System.Collections.Generic;
using System.Data;

namespace QBooksUploader
    {
    public class Invoice
        {

        public Int32 UploadID; //TODO. later convert to long
        public DataTable InvoicesDT;

        public string OutputVATSalesTaxItem 
        {
            get { return GlobalReference.ProjectParameters.QBDefferedOutputVAT; }
        }

        public int UploadCount;

        public List<QBUploadResult> UploadResult;

        public void UploadInvoices() {
                using (QBConnection qbc = new QBConnection()) {
                    foreach (DataRow dr in  InvoicesDT.Rows)
                        {

                       IInvoiceAdd invoiceAdd = qbc.RequestSet.AppendInvoiceAddRq();
                       string invoiceMOnth = DateTime.Parse(dr["bill_date"].ToString()).ToString("MMMM yyyy");

                       invoiceAdd.CustomerRef.ListID.SetValue(dr["list_id"].ToString());

                       invoiceAdd.TxnDate.SetValue(DateTime.Parse(dr["bill_generate_date"].ToString()));
                       invoiceAdd.DueDate.SetValue(DateTime.Parse(dr["bill_due_date"].ToString()));

                       string invoiceNumber = GetInvoiceNumber(dr["bill_id"].ToString());
                       invoiceAdd.RefNumber.SetValue(invoiceNumber);

                       invoiceAdd.ARAccountRef.ListID.SetValue(dr["ar_item"].ToString());

                       invoiceAdd.Memo.SetValue(dr["fee_name"].ToString() + " " + invoiceMOnth);

                       invoiceAdd.ItemSalesTaxRef.ListID.SetValue(OutputVATSalesTaxItem);
                       invoiceAdd.IsToBePrinted.SetValue(false);
                       Boolean withVat = dr["w_vat"].ToString().Trim() == "Y" ? true : false;

                       string className = dr["class_name"].ToString();

                       if (! string.IsNullOrEmpty(className)){
                           invoiceAdd.ClassRef.ListID.SetValue(className);
                       }
                        

                       decimal amountdue = decimal.Parse(dr["amount_due"].ToString());

                        IInvoiceLineAdd invoiceLineAdd;

                        invoiceLineAdd = invoiceAdd.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                        invoiceLineAdd.ItemRef.ListID.SetValue(dr["list_item"].ToString()); 

                        invoiceLineAdd.Desc.SetValue(dr["fee_name"].ToString() + " " + invoiceMOnth);

                        if (withVat) {
                            decimal vat = 1.12M;
                            invoiceLineAdd.Amount.SetValue(Convert.ToDouble(decimal.Round(amountdue / vat, 2)));
                            }
                        else {
                            invoiceLineAdd.Amount.SetValue(Convert.ToDouble(amountdue));
                            invoiceLineAdd.IsTaxable.SetValue(false);
                            }

                        if (!string.IsNullOrEmpty(className))
                        {
                            invoiceLineAdd.ClassRef.ListID.SetValue(className);
                        }
                      }

                      //System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                      //s.Start();
                      qbc.PerformRequest();
                      //s.Stop();
                      //long x = s.ElapsedMilliseconds;

                      GetUploadResults(qbc.ResponseList, InvoicesDT);
                    }
                }

        private void GetUploadResults(IResponseList qbResponse, DataTable  Invoices)
        {
            UploadResult  = new List<QBUploadResult>();

            //Update propmans txnid  from quickbooks.
            for (int i = 0; i < qbResponse.Count; i++)
            {
                IResponse response = qbResponse.GetAt(i);

                string txnID = string.Empty;
                bool uploaded =false;
                string Error = String.Empty;
                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode == 0){
                    IInvoiceRet invoiceRet = (IInvoiceRet)response.Detail;
                    txnID = (string)invoiceRet.TxnID.GetValue();
                    uploaded = true;
                    UploadCount += 1;
                }
                else {
                    uploaded = false;
                    Error = response.StatusMessage;
                }

                UploadResult.Add(new QBUploadResult
                {
                    RefID = Invoices.Rows[i]["bill_id"].ToString().ToString(),
                    RefType = ReferenceType.Invoice,
                    QBListID = txnID,
                    Uploaded = uploaded , ItemRemarks ="",UploadError=Error});
            }

           
        }

        public string GetInvoiceTxnID(string billid) {
            string invoiceNumber = GetInvoiceNumber(billid);
            string transID = String.Empty;

            using (QBConnection qbc = new QBConnection()) {
                IInvoiceQuery invoiceQuery = qbc.RequestSet.AppendInvoiceQueryRq();

                invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(invoiceNumber);

                qbc.PerformRequest();

                qbc.Response = qbc.ResponseList.GetAt(0);
                    if (qbc.Response.StatusCode == 0) {
                        if (qbc.Response.Detail != null) {
                            //make sure the response is the type we're expecting
                            ENResponseType responseType = (ENResponseType)qbc.Response.Type.GetValue();
                            if (responseType == ENResponseType.rtInvoiceQueryRs) {
                                //upcast to more specific type here, this is safe because we checked with response.Type check above
                                IInvoiceRetList InvoiceRet = (IInvoiceRetList)qbc.Response.Detail;

                                 transID= (string)InvoiceRet.GetAt(0).TxnID.GetValue();
                                }
                            }
                        }
                }
            return transID;
            }

        public string GetInvoiceNumber(string billID){
            string id;
            int yearPart = int.Parse(billID.Substring(2, 2));
            int monthPart = int.Parse(billID.Substring(4, 2));
            int datePart = int.Parse(billID.Substring(6, 2));
            int hourPart = int.Parse(billID.Substring(8, 2));
            string lastPart = billID.Substring(10).ToString();

            id = GetCharRep(yearPart) + GetCharRep(monthPart) + GetCharRep(datePart) + GetCharRep(hourPart) + lastPart;
            if (id.Length > 11) {
                id = id.Substring(0, 8) + id.Substring(11, 3);
                }

            
            return id;
          }

        private char GetCharRep(int code) { 
            int cbase =64;
            char result;
            if ((cbase + code)< 91){
                result = Convert.ToChar(cbase + code);
                }
                else{
                result = Convert.ToChar(cbase + code+6);
                }
            return result;
            }

        }
    }

  