Imports DALC
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports BCL.Common
Imports System.Linq

Namespace RMS

    Public Class RMSDA

        Public _rentalAgreements As New List(Of RentalAgreement)
        Public ReadOnly Property RentalAgreements As List(Of RentalAgreement)
            Get
                Return _rentalAgreements
            End Get
        End Property

        Public _leaseAgreements As New List(Of LeaseAgreement)
        Public ReadOnly Property LeaseAgreements As List(Of LeaseAgreement)
            Get
                Return _leaseAgreements
            End Get
        End Property


        Private _activityTypes As New List(Of ActivityType)
        Public ReadOnly Property ActivityType As List(Of ActivityType)
            Get
                Return _activityTypes
            End Get
        End Property

        Public Sub New()
            LoadActivityTypes()
        End Sub

        Public Function LoadRentalAgreementByID(ID As String) As RentalAgreement
            Dim rma As New RentalAgreement

            Using param As New OraParameter
                param.AddParameter("agreementid", ID)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalagreementbyid", param.GetParameterCollection).Rows
                    rma.ID = row("agreement_id").ToString
                    rma.OwnerAccount = GlobalReference.AccountDataAccess.GetUnitOwnerAccountByID(row("account_id").ToString)
                    rma.AgreementDate = Date.Parse(row("application_date").ToString)
                    rma.MonthsTerm = Integer.Parse(row("months_term").ToString)
                    rma.ContractStartDate = Date.Parse(row("contract_start").ToString)
                    rma.ContractEndDate = Date.Parse(row("contract_end").ToString)
                    rma.LeaseType = EnumExtensions.Entry(Of LeaseType)(row("unit_class").ToString)
                    rma.MaxOccupant = Integer.Parse(row("max_occupants").ToString)
                    rma.PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString)
                    rma.RentAmount = Decimal.Parse(row("rent_amt").ToString)
                    rma.SecurityDeposit = Decimal.Parse(row("security_deposit").ToString)
                    rma.CashBond = Decimal.Parse(row("cash_bond").ToString)
                    rma.MgmtRate = Decimal.Parse(row("mgmt_rate").ToString)
                    rma.RemitType = EnumExtensions.Entry(Of RemitType)(row("remit_release").ToString)
                    rma.ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString)
                    rma.CreatedBy = row("created_by").ToString
                    rma.CreatedOn = Date.Parse(row("created_on").ToString)
                    rma.UpdatedBy = row("updated_by").ToString
                    rma.UpdatedOn = GetDate(row("updated_on"))
                Next
            End Using

            Return rma
        End Function

        Public Function LoadRentalAgreementsByAccountID(accountid As String) As List(Of RentalAgreement)
            Dim rma As New List(Of RentalAgreement)

            Using param As New OraParameter
                param.AddParameter("accountid", accountid)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalagreementbyaccountid", param.GetParameterCollection).Rows
                    rma.Add(New RentalAgreement With {.ID = row("agreement_id").ToString,
                                                      .OwnerAccount = GlobalReference.AccountDataAccess.GetUnitOwnerAccountByID(row("account_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("unit_class").ToString),
                                                      .MaxOccupant = Integer.Parse(row("max_occupants").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .MgmtRate = Decimal.Parse(row("mgmt_rate").ToString),
                                                      .RemitType = EnumExtensions.Entry(Of RemitType)(row("remit_release").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))})
                Next
            End Using
            Me._rentalAgreements = rma
            Return rma
        End Function

        Public Function LoadActiveRentalAgreementsByLeaseType(leaseType As LeaseType) As List(Of RentalAgreement)
            Dim rma As New List(Of RentalAgreement)

            Using param As New OraParameter
                param.AddParameter("leasetype", leaseType.DBVAlue)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getactiverentalagreement", param.GetParameterCollection).Rows
                    rma.Add(New RentalAgreement With {.ID = row("agreement_id").ToString,
                                                      .OwnerAccount = GlobalReference.AccountDataAccess.GetUnitOwnerAccountByID(row("account_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("unit_class").ToString),
                                                      .MaxOccupant = Integer.Parse(row("max_occupants").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .MgmtRate = Decimal.Parse(row("mgmt_rate").ToString),
                                                      .RemitType = EnumExtensions.Entry(Of RemitType)(row("remit_release").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on")),
                                                      .Available = Integer.Parse(row("available").ToString)})
                Next
            End Using

            Return rma
        End Function

        Public Function LoadRentalAgreementByStatus(status As ContractStatus) As List(Of RentalAgreement)
            Dim rma As New List(Of RentalAgreement)

            Using param As New OraParameter
                param.AddParameter("status", status.DBVAlue)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalagreementsbystatus", param.GetParameterCollection).Rows
                    rma.Add(New RentalAgreement With {.ID = row("agreement_id").ToString,
                                                      .OwnerAccount = GlobalReference.AccountDataAccess.GetUnitOwnerAccountByID(row("account_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("unit_class").ToString),
                                                      .MaxOccupant = Integer.Parse(row("max_occupants").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .MgmtRate = Decimal.Parse(row("mgmt_rate").ToString),
                                                      .RemitType = EnumExtensions.Entry(Of RemitType)(row("remit_release").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))})
                Next
            End Using

            Return rma
        End Function

        Public Function LoadRentalAgreementAmendments() As List(Of ContractAmendment)
            Dim rma As New List(Of ContractAmendment)

            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalgreementamendments", param.GetParameterCollection).Rows
                    rma.Add(New ContractAmendment With {.ApprovalID = row("approval_id").ToString,
                                                        .Agreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString),
                                                        .RequestDate = Date.Parse(row("created_on").ToString).Date,
                                                        .AmendmentRequestType = EnumExtensions.Entry(Of AmendmentType)(row("request_type").ToString),
                                                        .RequestingParty = EnumExtensions.Entry(Of RequesterType)(row("requested_by").ToString),
                                                        .EffectiveDate = GetDate(row("effective_date")),
                                                        .ApprovalStatus = EnumExtensions.Entry(Of ApprovalStatus)(row("approval_status").ToString),
                                                        .OldRate = GetDecimal(row("old_rental_amt")),
                                                        .OldEndDate = GetDate(row("old_end_date")),
                                                        .NewEndDate = GetDate(row("new_end_date")),
                                                        .NewRate = GetDecimal(row("new_rental_amt")),
                                                        .RequestNotes = row("request_notes").ToString,
                                                        .ApprovalNotes = row("approval_notes").ToString,
                                                        .CreatedBy = row("created_by").ToString,
                                                        .CreatedOn = Date.Parse(row("created_on").ToString),
                                                        .UpdatedBy = row("updated_by").ToString,
                                                        .UpdatedOn = GetDate(row("updated_on"))
                                                        })
                Next
            End Using

            Return rma
        End Function

        Public Function InsertRentalAgreement(accountID As String, ByVal agreement As RentalAgreement) As Integer
            Using params As New OraParameter
                With agreement
                    params.AddParameter("accountid", accountID, OracleDbType.Int32)
                    params.AddParameter("applicationdate", .AgreementDate, OracleDbType.Date)
                    params.AddParameter("monthsterm", .MonthsTerm, OracleDbType.Int32)
                    params.AddParameter("contractstartdate", .ContractStartDate, OracleDbType.Date)
                    params.AddParameter("contractenddate", .ContractEndDate, OracleDbType.Date)
                    params.AddParameter("leasetype", .LeaseType.DBVAlue)
                    params.AddParameter("maxoccupant", .MaxOccupant, OracleDbType.Int32)
                    params.AddParameter("prepaidrent", .PrepaidRent, OracleDbType.Decimal)
                    params.AddParameter("rentamount", .RentAmount, OracleDbType.Decimal)
                    params.AddParameter("securitydeposit", .SecurityDeposit, OracleDbType.Decimal)
                    params.AddParameter("cashbond", .CashBond, OracleDbType.Decimal)
                    params.AddParameter("mgmtrate", .MgmtRate, OracleDbType.Decimal)
                    params.AddParameter("remitrelease", .RemitType.DBVAlue)
                    params.AddParameter("agreementid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertrentalagreement", params.GetParameterCollection), OracleDecimal).ToInt32

            End Using
        End Function

        Public Function UpdateRentalAgreement(agreement As RentalAgreement) As Integer
            Using params As New OraParameter
                With agreement
                    params.AddParameter("agreementid", .ID, OracleDbType.Int32)
                    params.AddParameter("applicationdate", .AgreementDate, OracleDbType.Date)
                    params.AddParameter("monthsterm", .MonthsTerm, OracleDbType.Int32)
                    params.AddParameter("contractstartdate", .ContractStartDate, OracleDbType.Date)
                    params.AddParameter("contractenddate", .ContractEndDate, OracleDbType.Date)
                    params.AddParameter("leasetype", .LeaseType.DBVAlue)
                    params.AddParameter("maxoccupant", .MaxOccupant, OracleDbType.Int32)
                    params.AddParameter("prepaidrent", .PrepaidRent, OracleDbType.Decimal)
                    params.AddParameter("rentamount", .RentAmount, OracleDbType.Decimal)
                    params.AddParameter("securitydeposit", .SecurityDeposit, OracleDbType.Decimal)
                    params.AddParameter("cashbond", .CashBond, OracleDbType.Decimal)
                    params.AddParameter("remitrelease", .RemitType.DBVAlue)
                    params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updaterentalagreement", params.GetParameterCollection), OracleDecimal).ToInt32
            End Using

        End Function

        Public Function UpdateRentalAgreementContractStatus(agreements As List(Of ContractAmendment), approvalStatus As ApprovalStatus, approvalNotes As String) As Integer
            Using params As New OraParameter

                params.AddParameter("approvalid", (From rma In agreements
                                               Select rma.ApprovalID).ToArray,
                               OracleDbType.Int32, ParameterDirection.Input,
                               True, 500)

                params.AddParameter("approvalstatus", approvalStatus.DBVAlue)
                params.AddParameter("approvalnotes", approvalNotes)
                params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)


                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updaterentalapprovalstatus", params.GetParameterCollection), OracleDecimal).ToInt32
            End Using
        End Function

        Public Function InsertRentalAmmendment(ByVal agreement As ContractAmendment) As Integer
            Using params As New OraParameter
                With agreement
                    params.AddParameter("agreementid", .Agreement.ID, OracleDbType.Int32)
                    params.AddParameter("requestdate", .RequestDate, OracleDbType.Date)
                    params.AddParameter("requesttype", .AmendmentRequestType.DBVAlue)
                    params.AddParameter("requestedby", .RequestingParty.DBVAlue)
                    params.AddParameter("requestnotes", .RequestNotes)

                    If .AmendmentRequestType = AmendmentType.RentalAmount Then
                        params.AddParameter("newrate", .NewRate, OracleDbType.Decimal)
                    End If

                    If .AmendmentRequestType = AmendmentType.RentalExtension Then
                        params.AddParameter("newenddate", .NewEndDate, OracleDbType.Date)
                    End If

                    If .AmendmentRequestType = AmendmentType.Preterminatation Then
                        params.AddParameter("effectivedate", .EffectiveDate, OracleDbType.Date)
                    End If

                    params.AddParameter("approvalid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertrentalamendment", params.GetParameterCollection), OracleDecimal).ToInt32

            End Using
        End Function

        Public Function UpdateRentalAmmendment(ByVal agreement As ContractAmendment) As Integer
            Using params As New OraParameter
                With agreement
                    params.AddParameter("approvalid", .ApprovalID, OracleDbType.Int32)
                    params.AddParameter("agreementid", .Agreement.ID, OracleDbType.Int32)
                    params.AddParameter("requestdate", .RequestDate, OracleDbType.Date)
                    params.AddParameter("requesttype", .AmendmentRequestType.DBVAlue)
                    params.AddParameter("requestedby", .RequestingParty.DBVAlue)
                    params.AddParameter("requestnotes", .RequestNotes)

                    If .AmendmentRequestType = AmendmentType.RentalAmount Then
                        params.AddParameter("newrate", .NewRate, OracleDbType.Decimal)
                    End If

                    If .AmendmentRequestType = AmendmentType.RentalExtension Then
                        params.AddParameter("newenddate", .NewEndDate, OracleDbType.Date)
                    End If

                    If .AmendmentRequestType = AmendmentType.Preterminatation Then
                        params.AddParameter("effectivedate", .EffectiveDate, OracleDbType.Date)
                    End If


                    params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updaterentalamendment", params.GetParameterCollection), OracleDecimal).ToInt32

            End Using
        End Function


        Public Function LoadLeaseAgreementsByCustID(custID As String) As List(Of LeaseAgreement)
            Dim loc As New List(Of LeaseAgreement)

            Using param As New OraParameter
                param.AddParameter("customerid", custID)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleasesbytenant", param.GetParameterCollection).Rows
                    loc.Add(New LeaseAgreement With {.ID = row("lease_id").ToString,
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("lease_type").ToString),
                                                      .LeasePurpose = EnumExtensions.Entry(Of LeasePurpose)(row("lease_purpose").ToString),
                                                      .RentalAgreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))
                                                     })
                Next
            End Using
            Me._leaseAgreements = loc
            Return loc
        End Function

        Public Function LoadLeaseAgreementsByStatus(status As ContractStatus) As List(Of LeaseAgreement)
            Dim loc As New List(Of LeaseAgreement)


            Using param As New OraParameter

                param.AddParameter("status", status.DBVAlue)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleasesbystatus", param.GetParameterCollection).Rows
                    loc.Add(New LeaseAgreement With {.ID = row("lease_id").ToString,
                                                     .Tenant = GlobalReference.AccountDataAccess.GetCustomerByID(row("cust_id").ToString),
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("lease_type").ToString),
                                                      .LeasePurpose = EnumExtensions.Entry(Of LeasePurpose)(row("lease_purpose").ToString),
                                                      .RentalAgreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))})
                Next
            End Using

            Return loc
        End Function

        Public Function LoadLeasesByAccountID(accountid As String) As List(Of LeaseAgreement)
            Dim loc As New List(Of LeaseAgreement)


            Using param As New OraParameter
                param.AddParameter("accountid", accountid)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleasesbyowner", param.GetParameterCollection).Rows
                    loc.Add(New LeaseAgreement With {.ID = row("lease_id").ToString,
                                                     .Tenant = GlobalReference.AccountDataAccess.GetCustomerByID(row("cust_id").ToString),
                                                      .LeaseType = EnumExtensions.Entry(Of LeaseType)(row("lease_type").ToString),
                                                      .LeasePurpose = EnumExtensions.Entry(Of LeasePurpose)(row("lease_purpose").ToString),
                                                      .RentalAgreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString),
                                                      .AgreementDate = Date.Parse(row("application_date").ToString),
                                                      .MonthsTerm = Integer.Parse(row("months_term").ToString),
                                                      .ContractStartDate = Date.Parse(row("contract_start").ToString),
                                                      .ContractEndDate = Date.Parse(row("contract_end").ToString),
                                                      .PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString),
                                                      .RentAmount = Decimal.Parse(row("rent_amt").ToString),
                                                      .SecurityDeposit = Decimal.Parse(row("security_deposit").ToString),
                                                      .CashBond = Decimal.Parse(row("cash_bond").ToString),
                                                      .ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString),
                                                      .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = Date.Parse(row("created_on").ToString),
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))})
                Next
            End Using

            Return loc
        End Function

        Public Function LoadLeaseByID(ID As String) As LeaseAgreement
            Dim loc As New LeaseAgreement

            Using param As New OraParameter
                param.AddParameter("leaseid", ID)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleasesbyleaseid", param.GetParameterCollection).Rows
                    loc.ID = row("lease_id").ToString
                    loc.Tenant = GlobalReference.AccountDataAccess.GetCustomerByID(row("cust_id").ToString)
                    loc.LeaseType = EnumExtensions.Entry(Of LeaseType)(row("lease_type").ToString)
                    loc.LeasePurpose = EnumExtensions.Entry(Of LeasePurpose)(row("lease_purpose").ToString)
                    loc.RentalAgreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString)
                    loc.AgreementDate = Date.Parse(row("application_date").ToString)
                    loc.MonthsTerm = Integer.Parse(row("months_term").ToString)
                    loc.ContractStartDate = Date.Parse(row("contract_start").ToString)
                    loc.ContractEndDate = Date.Parse(row("contract_end").ToString)
                    loc.PrepaidRent = Decimal.Parse(row("prepaid_rent").ToString)
                    loc.RentAmount = Decimal.Parse(row("rent_amt").ToString)
                    loc.SecurityDeposit = Decimal.Parse(row("security_deposit").ToString)
                    loc.CashBond = Integer.Parse(row("cash_bond").ToString)
                    loc.ContractStatus = EnumExtensions.Entry(Of ContractStatus)(row("contract_status").ToString)
                    loc.CreatedBy = row("created_by").ToString
                    loc.CreatedOn = Date.Parse(row("created_on").ToString)
                    loc.UpdatedBy = row("updated_by").ToString
                    loc.UpdatedOn = GetDate(row("updated_on"))
                Next
            End Using

            Return loc
        End Function

        Public Function InsertLeaseAgreement(customerID As String, ByVal agreement As LeaseAgreement) As Integer

            Using params As New OraParameter
                With agreement
                    params.AddParameter("agreementid", .RentalAgreement.ID, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("applicationdate", .AgreementDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("leasepurpose", .LeasePurpose.DBVAlue)
                    params.AddParameter("monthsterm", .MonthsTerm, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("contractstartdate", .ContractStartDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("contractenddate", .ContractEndDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("prepaidrent", .PrepaidRent, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("rentamount", .RentAmount, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("securitydeposit", .SecurityDeposit, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("cashbond", .CashBond, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("customerid", customerID, OracleDbType.Int32, ParameterDirection.Input)

                    params.AddParameter("leaseid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertleasecontract", params.GetParameterCollection), OracleDecimal).ToInt32

                End With
            End Using

        End Function

        Public Function UpdateLeaseAgreement(ByVal agreement As LeaseAgreement) As Integer

            Using param As New OraParameter
                With agreement
                    param.AddParameter("leaseid", .ID, OracleDbType.Int32)
                    param.AddParameter("agreementid", .RentalAgreement.ID, OracleDbType.Int32)
                    param.AddParameter("applicationdate", .AgreementDate, OracleDbType.Date)
                    param.AddParameter("leasepurpose", .LeasePurpose.DBVAlue)
                    param.AddParameter("monthsterm", .MonthsTerm, OracleDbType.Int32)
                    param.AddParameter("contractstartdate", .ContractStartDate, OracleDbType.Date)
                    param.AddParameter("contractenddate", .ContractEndDate, OracleDbType.Date)
                    param.AddParameter("prepaidrent", .PrepaidRent, OracleDbType.Decimal)
                    param.AddParameter("rentamount", .RentAmount, OracleDbType.Decimal)
                    param.AddParameter("securitydeposit", .SecurityDeposit, OracleDbType.Decimal)
                    param.AddParameter("cashbond", .CashBond, OracleDbType.Decimal)
                    param.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updateleasecontract", param.GetParameterCollection), OracleDecimal).ToInt32
            End Using
        End Function

        Public Function UpdateLeaseAgreementContractStatus(contracts As List(Of ContractAmendment), approvalStatus As ApprovalStatus, approvalNotes As String) As Integer
            Using params As New OraParameter

                params.AddParameter("approvalid", (From col In contracts
                                               Select col.ApprovalID).ToArray,
                               OracleDbType.Int32, ParameterDirection.Input,
                               True, 500)

                params.AddParameter("approvalstatus", approvalStatus.DBVAlue)
                params.AddParameter("approvalnotes", approvalNotes)
                params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)


                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updateleaseapprovalstatus", params.GetParameterCollection), OracleDecimal).ToInt32
            End Using
        End Function

        Public Function LoadLeaseAmendments() As List(Of ContractAmendment)
            Dim rma As New List(Of ContractAmendment)

            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleaseagreementamendments", param.GetParameterCollection).Rows

                    rma.Add(New ContractAmendment With {.ApprovalID = row("approval_id").ToString,
                                                        .Agreement = Me.LoadLeaseByID(row("lease_id").ToString),
                                                        .RequestDate = Date.Parse(row("created_on").ToString).Date,
                                                        .AmendmentRequestType = EnumExtensions.Entry(Of AmendmentType)(row("request_type").ToString),
                                                        .RequestingParty = EnumExtensions.Entry(Of RequesterType)(row("requested_by").ToString),
                                                        .EffectiveDate = GetDate(row("effective_date")),
                                                        .ApprovalStatus = EnumExtensions.Entry(Of ApprovalStatus)(row("approval_status").ToString),
                                                        .OldRate = GetDecimal(row("old_rental_amt")),
                                                        .OldEndDate = GetDate(row("old_end_date")),
                                                        .NewEndDate = GetDate(row("new_end_date")),
                                                        .NewRate = GetDecimal(row("new_rental_amt")),
                                                        .RequestNotes = row("request_notes").ToString,
                                                        .ApprovalNotes = row("approval_notes").ToString,
                                                        .CreatedBy = row("created_by").ToString,
                                                        .CreatedOn = Date.Parse(row("created_on").ToString),
                                                        .UpdatedBy = row("created_by").ToString,
                                                        .UpdatedOn = GetDate(row("new_end_date"))
                                                        })
                Next

            End Using

            Return rma

        End Function

        Public Function InsertLeaseAmmendment(ByVal ammendment As ContractAmendment) As Integer
            Using params As New OraParameter
                With ammendment
                    params.AddParameter("leaseid", .Agreement.ID, OracleDbType.Int32)
                    params.AddParameter("requestdate", .RequestDate, OracleDbType.Date)
                    params.AddParameter("requesttype", .AmendmentRequestType.DBVAlue)
                    params.AddParameter("requestedby", .RequestingParty.DBVAlue)
                    params.AddParameter("requestnotes", .RequestNotes)

                    If .AmendmentRequestType = AmendmentType.RentalAmount Then
                        params.AddParameter("newrate", .NewRate, OracleDbType.Decimal)
                    End If

                    If .AmendmentRequestType = AmendmentType.RentalExtension Then
                        params.AddParameter("newenddate", .NewEndDate, OracleDbType.Date)
                    End If

                    If .AmendmentRequestType = AmendmentType.Preterminatation Then
                        params.AddParameter("effectivedate", .EffectiveDate, OracleDbType.Date)
                    End If

                    params.AddParameter("approvalid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertleaseamendment", params.GetParameterCollection), OracleDecimal).ToInt32

            End Using
        End Function

        Public Function UpdateLeaseAmmendment(ByVal amendment As ContractAmendment) As Integer
            Using params As New OraParameter
                With amendment
                    params.AddParameter("approvalid", .ApprovalID, OracleDbType.Int32)
                    params.AddParameter("leaseid", .Agreement.ID, OracleDbType.Int32)
                    params.AddParameter("requestdate", .RequestDate, OracleDbType.Date)
                    params.AddParameter("requesttype", .AmendmentRequestType.DBVAlue)
                    params.AddParameter("requestedby", .RequestingParty.DBVAlue)
                    params.AddParameter("requestnotes", .RequestNotes)

                    If .AmendmentRequestType = AmendmentType.RentalAmount Then
                        params.AddParameter("newrate", .NewRate, OracleDbType.Decimal)
                    End If

                    If .AmendmentRequestType = AmendmentType.RentalExtension Then
                        params.AddParameter("newenddate", .NewEndDate, OracleDbType.Date)
                    End If

                    If .AmendmentRequestType = AmendmentType.Preterminatation Then
                        params.AddParameter("effectivedate", .EffectiveDate, OracleDbType.Date)
                    End If

                    params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)
                End With

                Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updateleaseamendment", params.GetParameterCollection), OracleDecimal).ToInt32

            End Using
        End Function

        Public Function LoadRentalBillings(leaseID As String) As List(Of Billing)
            Dim bills As New List(Of Billing)

            Using param As New OraParameter
                param.AddParameter("leaseid", leaseID, OracleDbType.Int32)

                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalbillings", param.GetParameterCollection).Rows
                    Dim bill As New Billing
                    bill.BillID = row("bill_id").ToString
                    bill.BillDate = Date.Parse(row("bill_date").ToString)
                    bill.FeeName = row("fee_name").ToString
                    bill.CoveredPeriod = row("period").ToString
                    bill.BillStatementDate = Date.Parse(row("bill_generate_date").ToString)
                    bill.BillDueDate = Date.Parse(row("bill_due_date").ToString)
                    bill.AmountDue = Decimal.Parse(row("amount_due").ToString)
                    bill.PenaltyAmount = Decimal.Parse(row("penalty_amt").ToString)
                    bill.AmountPaid = Decimal.Parse(row("amount_paid").ToString)
                    bill.CreatedBy = row("created_by").ToString
                    bill.CreatedOn = Date.Parse(row("created_date").ToString)
                    bills.Add(bill)
                Next
            End Using

            Return bills
        End Function

        Public Function LoadLeaseDeposits(leaseID As String) As List(Of Billing)
            Dim bills As New List(Of Billing)

            Using param As New OraParameter
                param.AddParameter("leaseid", leaseID, OracleDbType.Int32)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleasedeposits", param.GetParameterCollection).Rows
                    Dim bill As New Billing
                    bill.BillID = row("bill_id").ToString
                    bill.BillDate = Date.Parse(row("bill_date").ToString)
                    bill.FeeName = row("fee_name").ToString
                    bill.CoveredPeriod = row("period").ToString
                    bill.BillStatementDate = Date.Parse(row("bill_generate_date").ToString)
                    bill.BillDueDate = Date.Parse(row("bill_due_date").ToString)
                    bill.AmountDue = Decimal.Parse(row("amount_due").ToString)
                    bill.PenaltyAmount = Decimal.Parse(row("penalty_amt").ToString)
                    bill.AmountPaid = Decimal.Parse(row("amount_paid").ToString)
                    bill.CreatedBy = row("created_by").ToString
                    bill.CreatedOn = Date.Parse(row("created_date").ToString)
                    bills.Add(bill)
                Next
            End Using

            Return bills
        End Function


        Public Function LoadRentalAgreementActivities(accountid As String) As List(Of RentalActivity)
            Dim act As New List(Of RentalActivity)

            Using param As New OraParameter
                param.AddParameter("accountid", accountid)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getrentalactivities", param.GetParameterCollection).Rows
                    act.Add(New RentalActivity With {.ActivityId = row("activity_id").ToString,
                                                     .ActivityDate = Date.Parse(row("activity_date").ToString),
                                                     .Type = Me.GetActivityType(row("activity_type_id").ToString),
                                                     .Notes = row("notes").ToString,
                                                     .Agreement = Me.LoadRentalAgreementByID(row("agreement_id").ToString),
                                                     .CreatedBy = row("created_by").ToString,
                                                      .CreatedOn = row("created_on").ToString,
                                                      .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))
                                                    })
                Next
            End Using
            Return act
        End Function

        Public Function LoadLeaseContractActivities(customerID As String) As List(Of RentalActivity)
            Dim act As New List(Of RentalActivity)
            Using param As New OraParameter
                param.AddParameter("customerid", customerID)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getleaseactivities", param.GetParameterCollection).Rows
                    act.Add(New RentalActivity With {.ActivityId = row("activity_id").ToString,
                                                     .ActivityDate = Date.Parse(row("activity_date").ToString),
                                                     .Type = Me.GetActivityType(row("activity_type_id").ToString),
                                                     .Agreement = Me.LoadLeaseByID(row("lease_id").ToString),
                                                     .Notes = row("notes").ToString,
                                                     .CreatedBy = row("created_by").ToString,
                                                     .CreatedOn = row("created_on").ToString,
                                                     .UpdatedBy = row("updated_by").ToString,
                                                      .UpdatedOn = GetDate(row("updated_on"))
                                                    })
                Next
            End Using
            Return act
        End Function

        Public Function InsertRMActivity(agreementID As String, ByVal activity As RentalActivity) As Integer
            With activity
                Using params As New OraParameter
                    params.AddParameter("activitytypeid", .Type.ID, OracleDbType.Int32)
                    params.AddParameter("activitydate", .ActivityDate, OracleDbType.Date)
                    params.AddParameter("activitynotes", .Notes)
                    params.AddParameter("agreementid", agreementID, OracleDbType.Int32)
                    params.AddParameter("activityid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertrmactivity", params.GetParameterCollection), OracleDecimal).ToInt32
                End Using
            End With
        End Function

        Public Function InsertLeaseActivity(leaseID As String, ByVal activity As RentalActivity) As Integer
            With activity
                Using params As New OraParameter
                    params.AddParameter("activitytypeid", .Type.ID, OracleDbType.Int32)
                    params.AddParameter("activitydate", .ActivityDate, OracleDbType.Date)
                    params.AddParameter("activitynotes", .Notes)
                    params.AddParameter("leaseid", leaseID, OracleDbType.Int32)
                    params.AddParameter("activityid", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.insertlcactivity", params.GetParameterCollection), OracleDecimal).ToInt32
                End Using
            End With
        End Function

        Public Function UpdateActivity(ByVal activity As RentalActivity) As Integer
            With activity
                Using params As New OraParameter
                    params.AddParameter("activityid", .ActivityId, OracleDbType.Int32)
                    params.AddParameter("activitytypeid", .Type.ID, OracleDbType.Int32)
                    params.AddParameter("activitydate", .ActivityDate, OracleDbType.Date)
                    params.AddParameter("activitynotes", .Notes)
                    params.AddParameter("rowsaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("RMS2.updateactivity", params.GetParameterCollection), OracleDecimal).ToInt32
                End Using
            End With
        End Function

        Public Function LoadActivityType() As List(Of ActivityType)
            Return (From act In _activityTypes
                    Where act.IsActive = True And act.IsSystemEvent = False
                    Select act).ToList
        End Function


        Private Sub LoadActivityTypes()
            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("rms2.getactivitytypes", param.GetParameterCollection).Rows
                    _activityTypes.Add(New ActivityType With {.ID = row("activity_type_id").ToString,
                                                     .ActivityName = row("activity_name").ToString,
                                                     .IsActive = row("active").ToString.Equals("Y"),
                                                     .IsSystemEvent = row("system_event").ToString.Equals("Y")
                                                    })
                Next
            End Using
        End Sub

        Private Function GetActivityType(typeID As String) As ActivityType

            Return (From type As ActivityType In _activityTypes
                    Where type.ID.Equals(typeID)
                    Select type).Single
        End Function

        Private Function GetDate(obj As Object) As Nullable(Of Date)
            Dim datevalue As Nullable(Of Date)
            If Not Convert.IsDBNull(obj) Then
                datevalue = Date.Parse(obj.ToString)
            End If

            Return datevalue
        End Function

        Private Function GetDecimal(obj As Object) As Decimal
            If Convert.IsDBNull(obj) Then
                Return Decimal.Zero
            Else
                Return Decimal.Parse(obj.ToString)
            End If
        End Function

    End Class
  
End Namespace

