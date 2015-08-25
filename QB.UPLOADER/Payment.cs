using BCL.Common;
using Interop.QBFC12;
using System;
using System.Collections.Generic;
using System.Data;


namespace QBooksUploader
    {
    public class Payment
        {

        public Int32 UploadID; //TODO. later convert to long
        public DataTable PaymentsDT;

        public int UploadCount;

        public List<QBUploadResult> UploadResult;

        public string DepositAccount {
            get { return GlobalReference.ProjectParameters.QBDepositoryAccount; }
            }

        public string OutputVATSalesTaxItem ///TODO get  output vat
        {
            get { return GlobalReference.ProjectParameters.QBOutputVAT; }
        }

        public Payment() { 
            }

        public void UploadPayments() {
              
            using (QBConnection qbc = new QBConnection()) {

                foreach (DataRow rowItem in PaymentsDT.Rows)
                { 
                    string payCategory = rowItem["pay_category"].ToString();
                    string uploadType = rowItem["upload_type"].ToString();

                    if (payCategory == "ADV")
                    {
                        AddAdvances(qbc.RequestSet.AppendSalesReceiptAddRq(), rowItem);
                    }
                    else{
                        if (uploadType == "ONE TIME"){
                            AddOneTimePayments(qbc.RequestSet.AppendSalesReceiptAddRq(), rowItem);
                        }
                        else{
                            AddInvoicePayments(qbc.RequestSet.AppendReceivePaymentAddRq(), rowItem);
                        }
                    }
                }
               
                qbc.PerformRequest();

                GetUploadResults(qbc.ResponseList, PaymentsDT);
             }

            }

        public void AddOneTimePayments(ISalesReceiptAdd paymentAdd,DataRow rowItem){


                string className = rowItem["class_name"].ToString();

                if (!string.IsNullOrEmpty(className))
                {
                    paymentAdd.ClassRef.ListID.SetValue(className);
                }
                        
                string paymentMonth = DateTime.Parse(rowItem["payment_date"].ToString()).ToString("MMMM yyyy");
                paymentAdd.CustomerRef.ListID.SetValue(rowItem["list_id"].ToString());

                paymentAdd.DepositToAccountRef.ListID.SetValue(DepositAccount);

                paymentAdd.RefNumber.SetValue("OR#" + rowItem["or_number"].ToString());
                paymentAdd.TxnDate.SetValue(DateTime.Parse(rowItem["payment_date"].ToString()));
                paymentAdd.ItemSalesTaxRef.ListID.SetValue(OutputVATSalesTaxItem); 

                string paytype = (rowItem["payment_type"].ToString() == "CSH") ? "Cash" : "Check";
                paymentAdd.PaymentMethodRef.FullName.SetValue(paytype);
                //paymentAdd.CheckNumber.SetValue(""); //add for check only

                paymentAdd.Memo.SetValue(rowItem["fee_name"].ToString() + " " + paymentMonth);
                paymentAdd.IsToBePrinted.SetValue(false);

                ISalesReceiptLineAdd salesLineAdd = paymentAdd.ORSalesReceiptLineAddList.Append().SalesReceiptLineAdd;

                decimal payment = decimal.Parse(rowItem["paid_amount"].ToString());
                decimal vatable;
                decimal vat = 1.12M;

                vatable = decimal.Round(payment / vat, 2);

                salesLineAdd.ItemRef.ListID.SetValue(rowItem["list_item"].ToString());
                salesLineAdd.Desc.SetValue(rowItem["fee_name"].ToString() + " " + paymentMonth);
                salesLineAdd.Amount.SetValue((double)vatable);
                
                if (!string.IsNullOrEmpty(className))
                {
                    salesLineAdd.ClassRef.ListID.SetValue(className);
                }

        }
        public void AddAdvances(ISalesReceiptAdd paymentAdd, DataRow rowItem)
        {
                string className = rowItem["class_name"].ToString();

                if (!string.IsNullOrEmpty(className))
                {
                    paymentAdd.ClassRef.ListID.SetValue(className);
                }
                string salesMemo = rowItem["fee_name"].ToString() + " Advances";//TODO. To include covered months
                paymentAdd.CustomerRef.ListID.SetValue(rowItem["list_id"].ToString());

                paymentAdd.DepositToAccountRef.ListID.SetValue(DepositAccount);

                paymentAdd.RefNumber.SetValue("OR#" + rowItem["or_number"].ToString());
                paymentAdd.TxnDate.SetValue(DateTime.Parse(rowItem["payment_date"].ToString()));
                paymentAdd.ItemSalesTaxRef.ListID.SetValue(OutputVATSalesTaxItem); 

                string paytype = (rowItem["payment_type"].ToString() == "CSH") ? "Cash" : "Check";
                paymentAdd.PaymentMethodRef.FullName.SetValue(paytype);
                //TODO. add check datails, bank and check number
                //paymentAdd.CheckNumber.SetValue("");

                paymentAdd.Memo.SetValue(salesMemo);
                paymentAdd.IsToBePrinted.SetValue(false);

                ISalesReceiptLineAdd salesLineAdd = paymentAdd.ORSalesReceiptLineAddList.Append().SalesReceiptLineAdd;

                decimal payment = decimal.Parse(rowItem["paid_amount"].ToString());
                decimal vatable;
                decimal vat = 1.12M;

                vatable = decimal.Round(payment / vat, 2);

                salesLineAdd.ItemRef.ListID.SetValue(rowItem["list_item"].ToString());
                salesLineAdd.Amount.SetValue((double)vatable);

                if (!string.IsNullOrEmpty(className))
                {
                    salesLineAdd.ClassRef.ListID.SetValue(className);
                }
        }

        public void AddInvoicePayments(IReceivePaymentAdd paymentAdd, DataRow rowItem)
        {

                string payMemo = rowItem["fee_name"].ToString() + " Payments"; //TODO. To include invoice period covered by payments and if with or w/ou penalty

                paymentAdd.CustomerRef.ListID.SetValue(rowItem["list_id"].ToString());

                paymentAdd.ARAccountRef.ListID.SetValue(rowItem["ar_item"].ToString()); 
                paymentAdd.DepositToAccountRef.ListID.SetValue(DepositAccount);

                paymentAdd.RefNumber.SetValue("OR#" + rowItem["or_number"].ToString());
                paymentAdd.TxnDate.SetValue(DateTime.Parse(rowItem["payment_date"].ToString()));
                paymentAdd.TotalAmount.SetValue(Convert.ToDouble(rowItem["paid_amount"].ToString()));

                string paytype = (rowItem["payment_type"].ToString() == "CSH") ? "Cash" : "Check";
                paymentAdd.PaymentMethodRef.FullName.SetValue(paytype);

                paymentAdd.Memo.SetValue(payMemo);

                paymentAdd.ORApplyPayment.IsAutoApply.SetValue(false);

        }

        private void GetUploadResults(IResponseList qbResponse, DataTable Invoices)
        {
            UploadResult = new List<QBUploadResult>();

            //Update propmans txnid  from quickbooks.
            for (int i = 0; i < qbResponse.Count; i++)
            {
                IResponse response = qbResponse.GetAt(i);

                string txnID = string.Empty;
                bool uploaded = false;
                string Error = String.Empty;
                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode == 0)
                {
                    ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                    if (responseType == ENResponseType.rtSalesReceiptAddRs)
                    {
                        //upcast to more specific type here, this is safe because we checked with response.Type check above
                        ISalesReceiptRet SalesReceiptRet = (ISalesReceiptRet)response.Detail;
                        txnID = (string)SalesReceiptRet.TxnID.GetValue();
                    }
                    else
                    {
                        IReceivePaymentRet ReceivePaymentRet = (IReceivePaymentRet)response.Detail;
                        txnID = (string)ReceivePaymentRet.TxnID.GetValue();
                    }
                    uploaded = true;
                    UploadCount += 1;
                }
                else
                {
                    uploaded = false;
                    Error = response.StatusMessage;
                }

                UploadResult.Add(new QBUploadResult
                {
                    RefID = Invoices.Rows[i]["payment_id"].ToString().ToString(),
                    RefType = ReferenceType.Invoice,
                    QBListID = txnID,
                    Uploaded = uploaded,
                    ItemRemarks = "",
                    UploadError = Error
                });
            }


        }
           
        }
    }
