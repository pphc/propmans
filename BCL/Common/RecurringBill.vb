Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC


Namespace Billings

    Public Class RecurringBill
        Inherits BillingBase


        Public Sub New()
        End Sub

        Public Overrides Sub GenerateBill()
            If Not InsertBill() Then
                Throw New Exception("Bill not succesfully generated")
            End If
        End Sub

        Public Overrides Function BatchGenerateBill() As Integer

        End Function

        Protected Overrides Function InsertBill() As Boolean

            Using param As New OraParameter
                param.AddParameter("billdate", Me.BillingMonthYear, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("statementdate", Me.StatementDate, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("duedate", Me.DueDate, Oracle.DataAccess.Client.OracleDbType.Date, ParameterDirection.Input)
                param.AddParameter("feetypeid", Me.FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.Input)
                param.AddParameter("amountdue", Me.AmountDue, Oracle.DataAccess.Client.OracleDbType.Decimal, ParameterDirection.Input)
                param.AddParameter("penalty", Me.Penalty, Oracle.DataAccess.Client.OracleDbType.Decimal, ParameterDirection.Input)
                param.AddParameter("accountid", Me.AccountID, Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.Input)
                If Not String.IsNullOrEmpty(Me.LeasedID) Then
                    param.AddParameter("leaseid", Me.LeasedID, Oracle.DataAccess.Client.OracleDbType.Int32, ParameterDirection.Input)
                End If
                param.AddParameter("billid", "", Oracle.DataAccess.Client.OracleDbType.Varchar2, ParameterDirection.ReturnValue)
        

                Return Not Convert.IsDBNull(OraDBHelper2.ExecuteFunction("billings.generaterecurringbill", param.GetParameterCollection))
            End Using
        End Function

    End Class

End Namespace
