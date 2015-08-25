using Interop.QBFC12;
using System;
using System.IO;

namespace QBooksUploader
    {
    public class QBReferences
        {

        private string _folderPath;
        public string FolderPath {
            get { return _folderPath; }
            set { _folderPath = value; }
            }

        public QBReferences() { }

        public void ExportChartAccounts(){

            using (QBConnection qbc = new QBConnection()) {

                IAccountQuery actQuery = qbc.RequestSet.AppendAccountQueryRq();
                
                actQuery.ORAccountListQuery.AccountListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                qbc.PerformRequest();

                using (StreamWriter txt = new StreamWriter(FolderPath + "\\chart_of_accts.csv"))
                    {
                        IResponse response = qbc.ResponseList.GetAt(0);
                        txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6}", "QB_LISTID", "ACCT_NUMBER","ACCT_FULLNAME", "ACCT_NAME", "ACCT_DESC", "ACCT_TYPE","IS_ACTIVE"));
                        //check the status code of the response, 0=ok, >0 is warning
                        if (response.StatusCode == 0) {
                            IAccountRetList AccountRetList = response.Detail as IAccountRetList;
                            if (!(AccountRetList.Count == 0)) {
                                for (int ndx = 0; ndx <= (AccountRetList.Count - 1); ndx++) {
                                    IAccountRet AccountRet = AccountRetList.GetAt(ndx);
                                    txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6}", 
                                        AccountRet.ListID.GetValue().ToString(),
                                        AccountRet.AccountNumber != null ? AccountRet.AccountNumber.GetValue().ToString() : String.Empty ,
                                        AccountRet.FullName.GetValue().ToString(),
                                        AccountRet.Name.GetValue().ToString(),
                                        AccountRet.Desc != null ?  AccountRet.Desc.GetValue().ToString(): String.Empty,
                                        AccountRet.AccountType.GetValue().ToString(),
                                        AccountRet.IsActive.GetValue().ToString()));
                                    } // for
                                } 
                            }
                    
                    }
              
                }
            
            }

        public void ExportClass()
        {

            using (QBConnection qbc = new QBConnection())
            {

                IClassQuery classQuery = qbc.RequestSet.AppendClassQueryRq();

                qbc.PerformRequest();

                using (StreamWriter txt = new StreamWriter(FolderPath + "\\qb_class.csv"))
                {
                    IResponse response = qbc.ResponseList.GetAt(0);
                    txt.WriteLine(String.Format("{0},{1}", "QB_LISTID", "CLAS_NAME"));
                    //check the status code of the response, 0=ok, >0 is warning
                    if (response.StatusCode == 0)
                    {
                        IClassRetList ClassRetList = response.Detail as IClassRetList;
                        if (!(ClassRetList.Count == 0))
                        {
                            for (int ndx = 0; ndx <= (ClassRetList.Count - 1); ndx++)
                            {
                                IClassRet ClasRet = ClassRetList.GetAt(ndx);
                                txt.WriteLine(String.Format("{0},{1}",
                                    ClasRet.ListID.GetValue().ToString(),
                                    ClasRet.Name.GetValue().ToString()));
                            } // for
                        }
                    }

                }

            }

        }

        public void ExportItemLists() {

            using (QBConnection qbc = new QBConnection()) {

                IItemQuery lstQuery = qbc.RequestSet.AppendItemQueryRq();

                qbc.PerformRequest();


                using (StreamWriter txt = new StreamWriter(FolderPath + "\\item_list.csv")) {
                    IResponse response = qbc.ResponseList.GetAt(0);
                    txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", "QB_LISTID", "ITEM_FULLNAME", "ITEM_NAME", "ITEM_DESC", "TAX_CODE","IS_ACTIVE"));
                    //check the status code of the response, 0=ok, >0 is warning
                    if (response.StatusCode == 0) {
                        IORItemRetList itemRetList = response.Detail as IORItemRetList;
                        if (!(itemRetList.Count == 0)) {
                            for (int ndx = 0; ndx <= (itemRetList.Count - 1); ndx++) {
                                IORItemRet itemRet = itemRetList.GetAt(ndx);

                                string listID;
                                string fullname;
                                string name;
                                string description;
                                string isactive;
                               // string rate;
                                string taxcode;
                            
                                switch (itemRet.ortype) {
                                        
                                    case ENORItemRet.orirItemServiceRet: {
                                            // orir prefix comes from OR + Item + Ret
                                            IItemServiceRet ItemServiceRet = itemRet.ItemServiceRet;
                                            listID = ItemServiceRet.ListID.GetValue();
                                            fullname = ItemServiceRet.FullName.GetValue();
                                            name = ItemServiceRet.Name.GetValue();
                                            description = ItemServiceRet.IsTaxIncluded != null ? ItemServiceRet.IsTaxIncluded.GetValue().ToString() : string.Empty ;
                                            taxcode = ItemServiceRet.SalesTaxCodeRef.FullName.GetValue().ToString();
                                            isactive = ItemServiceRet.IsActive.GetValue().ToString();
                                           

                                            txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name, description,taxcode,isactive));
                                            }
                                        break;
                                    case ENORItemRet.orirItemInventoryRet: {
                                            IItemInventoryRet ItemInventoryRet = itemRet.ItemInventoryRet;
                                            listID = ItemInventoryRet.ListID.GetValue();
                                            fullname = ItemInventoryRet.FullName.GetValue();
                                            name = ItemInventoryRet.Name.GetValue();
                                            description = ItemInventoryRet.IsTaxIncluded != null ? ItemInventoryRet.IsTaxIncluded.GetValue().ToString() : string.Empty;
                                            taxcode = ItemInventoryRet.SalesTaxCodeRef.FullName.GetValue().ToString();
                                            isactive = ItemInventoryRet.IsActive.GetValue().ToString();
                                           

                                           txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name, description,taxcode,isactive));
                                            }
                                        break;
                                    case ENORItemRet.orirItemNonInventoryRet: {
                                            IItemNonInventoryRet ItemNonInventoryRet = itemRet.ItemNonInventoryRet;
                                            listID = ItemNonInventoryRet.ListID.GetValue();
                                            fullname = ItemNonInventoryRet.FullName.GetValue();
                                            name = ItemNonInventoryRet.Name.GetValue();
                                            description = ItemNonInventoryRet.IsTaxIncluded != null ? ItemNonInventoryRet.IsTaxIncluded.GetValue().ToString() : string.Empty;
                                            taxcode = ItemNonInventoryRet.SalesTaxCodeRef.FullName.GetValue().ToString();
                                            isactive = ItemNonInventoryRet.IsActive.GetValue().ToString();
                                           
                                            txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name, description,taxcode,isactive));
                                            }
                                        break;
                                    case ENORItemRet.orirItemOtherChargeRet: { 
                                            IItemOtherChargeRet ItemOtherChargeRet = itemRet.ItemOtherChargeRet;
                                            listID = ItemOtherChargeRet.ListID.GetValue();
                                            fullname = ItemOtherChargeRet.FullName.GetValue();
                                            name = ItemOtherChargeRet.Name.GetValue();
                                            description = ItemOtherChargeRet.IsTaxIncluded != null ? ItemOtherChargeRet.IsTaxIncluded.GetValue().ToString() : string.Empty;
                                            taxcode = ItemOtherChargeRet.SalesTaxCodeRef.FullName.GetValue().ToString();
                                            isactive = ItemOtherChargeRet.IsActive.GetValue().ToString();
                                           

                                            txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name, description,taxcode,isactive));
                                            }
                                        break;
                                   case ENORItemRet.orirItemSalesTaxRet: { 
                                            IItemSalesTaxRet salesTaxCodeRet = itemRet.ItemSalesTaxRet;
                                            listID = salesTaxCodeRet.ListID.GetValue();
                                            fullname = salesTaxCodeRet.Name.GetValue();
                                            name = salesTaxCodeRet.Name.GetValue();
                                            isactive = salesTaxCodeRet.IsActive.GetValue().ToString();
                                           

                                            txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name,"","",isactive));
                                            }
                                        break;
                                    case ENORItemRet.orirItemDiscountRet: { 
                                        IItemDiscountRet discountTaxCodeRet = itemRet.ItemDiscountRet;
                                        listID = discountTaxCodeRet.ListID.GetValue();
                                        fullname = discountTaxCodeRet.Name.GetValue();
                                        name = discountTaxCodeRet.Name.GetValue();
                                        isactive = discountTaxCodeRet.IsActive.GetValue().ToString();
                                           

                                        txt.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", listID, fullname, name,"","",isactive));
                                        }
                                    break;
                                    }
                                    }

                                } // for
                            }
                        }

                    }

                }

        public void ExportCustomerAccounts() {

            using (QBConnection qbc = new QBConnection()) {

                ICustomerQuery custQuery = qbc.RequestSet.AppendCustomerQueryRq();

                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                custQuery.IncludeRetElementList.Add("ListID");
                custQuery.IncludeRetElementList.Add("FullName");


                qbc.PerformRequest();

                using (StreamWriter txt = new StreamWriter(FolderPath + "\\cust_acct.csv")) {
                    IResponse response = qbc.ResponseList.GetAt(0);
                    txt.WriteLine(String.Format("{0},{1}", "QB_LISTID", "ACCT_NAME"));
                    //check the status code of the response, 0=ok, >0 is warning
                    if (response.StatusCode == 0) {
                        ICustomerRetList CustRetList = response.Detail as ICustomerRetList;
                        if (!(CustRetList.Count == 0)) {
                            for (int ndx = 0; ndx <= (CustRetList.Count - 1); ndx++) {
                                ICustomerRet CustRet = CustRetList.GetAt(ndx);
                                txt.WriteLine(String.Format("{0},{1}", CustRet.ListID.GetValue().ToString(), CustRet.FullName.GetValue().ToString()));
                                } // for
                            }
                        }

                    }

                }
            
            }
        }
    }
