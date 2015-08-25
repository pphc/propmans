
Imports BCL.Common
Imports DALC
Imports Oracle.DataAccess.Types
Namespace Billings

    Public Class BillGenerationHelper

        Private _billingInfo As BillingBase
        Public Property BillingInfo() As BillingBase
            Get
                Return _billingInfo
            End Get
            Private Set(ByVal value As BillingBase)
                _billingInfo = value
            End Set
        End Property

        Public Sub GenerateBill(ByVal billInfo As BillingBase)
            _billingInfo = billInfo
            _billingInfo.GenerateBill()
        End Sub

        Public Function BatchGenerateBill(ByVal billdate As Date, ByVal statementdate As Date, ByVal dueDate As Date, ByVal feetypeid As String, ByVal bldgNumber As Integer()) As Decimal


            Using param As New OraParameter
                param.AddParameter("billdate", billdate, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("statementdate", statementdate, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("duedate", dueDate, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("feetypeid", feetypeid, Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.Input)
                param.AddParameter("bldgid", bldgNumber, Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.Input, True)
                param.AddParameter("acctaffected", "", Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.ReturnValue)


                Return DirectCast(OraDBHelper2.ExecuteFunction("billings.generaterecurringbillbybatch", param.GetParameterCollection), OracleDecimal).ToInt32
            End Using

        End Function

        Public Function GetBillingSchedule(ByVal feeTypeID As String, ByVal billDate As Date) As BillingSchedule

            Dim sched As New BillingSchedule
            With GlobalReference.FeeSchedule.GetBillingSchedule(feeTypeID, billDate)
                If .StatementDay.HasValue Then
                    sched.StatementDate = New Date(billDate.Year, billDate.Month, .StatementDay.Value)
                End If

                If .DueDay.HasValue Then
                    If .DueDay.Value = -1 Then
                        sched.DueDate = New Date(billDate.Year, billDate.Month, Date.DaysInMonth(billDate.Year, billDate.Month))
                    Else
                        sched.DueDate = New Date(billDate.Year, billDate.Month, .StatementDay.Value).AddDays(.DueDay.Value)
                    End If
                End If

                If .GracePeriodDay.HasValue Then
                    If .GracePeriodDay.Value = -1 Then
                        sched.GracePeriodDate = New Date(billDate.Year, billDate.Month, Date.DaysInMonth(billDate.Year, billDate.Month))
                    Else
                        Dim duedays As Integer
                        If .DueDay.Value = -1 Then
                            duedays = Date.DaysInMonth(billDate.Year, billDate.Month) - .StatementDay.Value
                        Else
                            duedays = .DueDay.Value
                        End If
                        sched.GracePeriodDate = New Date(billDate.Year, billDate.Month, .StatementDay.Value).AddDays(duedays + .GracePeriodDay.Value)
                    End If
                End If

            End With

            Return sched
        End Function

        Public Function IsBillingMonthExist(ByVal feetypeID As String, ByVal accountId As String, ByVal billdate As Date) As Boolean
            Using params As New OraParameter
                params.AddParameter("feeid", feetypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
                params.AddParameter("accountid", accountId, Oracle.DataAccess.Client.OracleDbType.Int32)
                params.AddParameter("billdate", billdate, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddParameter("exist", "", Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.ReturnValue)


                Dim recCount As Integer = DirectCast(OraDBHelper2.ExecuteFunction("BILLINGS.isbillingmonthexist", params.GetParameterCollection), OracleDecimal).ToInt32

                Return recCount > 0

            End Using

        End Function

        Public Function IsAccountAllowed(ByVal feetypeID As String, ByVal accountId As String, ByVal billdate As Date) As Boolean
            Using params As New OraParameter
                params.AddParameter("feetypeid", feetypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
                params.AddParameter("accountid", accountId, Oracle.DataAccess.Client.OracleDbType.Int32)
                params.AddParameter("billdate", billdate, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddParameter("valid", "", Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.ReturnValue)


                Dim recCount As Integer = DirectCast(OraDBHelper2.ExecuteFunction("BILLINGS.isaccountallowedtogeneratefee", params.GetParameterCollection), OracleDecimal).ToInt32

                Return recCount > 0

            End Using

        End Function
    End Class

End Namespace
