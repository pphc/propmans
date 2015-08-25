'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 05-06-2010
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports DALC
Imports BCL.Statements
Imports Oracle.DataAccess.Types
Imports Oracle.DataAccess.Client
Imports BCL.Common

Namespace Payments


    Public Enum DepositType
        Cash
        Check
    End Enum

    Public NotInheritable Class DepositTypeSource
        Inherits ListSource
        Public Sub New()
            List.Add(New ItemLIst("CSH", "CASH"))
            List.Add(New ItemLIst("CHK", "CHECK"))
        End Sub
        Public Shared Function GetDepositType(ByVal id As String) As DepositType
            If id = "CSH" Then
                Return DepositType.Cash
            Else
                Return DepositType.Check
            End If
        End Function

        Public Shared Function GetDepositTypeName(ByVal type As DepositType) As String
            If type = DepositType.Cash Then
                Return "CASH"
            Else
                Return "CHECK"
            End If
        End Function

        Public Shared Function GetDepositTypeValue(ByVal type As DepositType) As String
            If type = DepositType.Cash Then
                Return "CSH"
            Else
                Return "CHK"
            End If
        End Function
    End Class

    Public NotInheritable Class DepositoryAccountsSource
        Inherits ListSource
        Public Sub New()
            For Each dr As DataRow In OraDBHelper2.GetResultSet(SelectStatement.GetDepositoryAccounts).Rows
                List.Add(New ItemLIst(dr("proj_bank_id").ToString, dr("bank_account_no").ToString))
            Next
        End Sub

        Public Shared Function GetBankName(ByVal bankID As String) As String
            Using params As New OraParameter
                params.AddItem(":bankid", bankID, OracleDbType.Int32)
                Return OraDBHelper2.SqlExecuteScalar(SelectStatement.GetBankNamebyID, params.GetParameterCollection)
            End Using
        End Function


    End Class

    Public Class Deposits

        Private _depositID As Integer ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositID() As Integer
            Get
                Return _depositID
            End Get
            Set(ByVal Value As Integer)
                _depositID = Value
            End Set
        End Property
        Private _depositDate As Date ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositDate() As Date
            Get
                Return _depositDate
            End Get
            Set(ByVal Value As Date)
                _depositDate = Value
            End Set
        End Property
        Private _depositType As DepositType ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositType() As DepositType
            Get
                Return _depositType
            End Get
            Set(ByVal Value As DepositType)
                _depositType = Value
            End Set
        End Property
        Private _depositBankID As Integer ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositBankID() As Integer
            Get
                Return _depositBankID
            End Get
            Set(ByVal Value As Integer)
                _depositBankID = Value
            End Set
        End Property

        Private _depositoryBankName As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositoryBankName() As String
            Get
                Return _depositoryBankName
            End Get
            Set(ByVal Value As String)
                _depositoryBankName = Value
            End Set
        End Property
        Private _depositoryAccountNumber As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositoryAccountNumber() As String
            Get
                Return _depositoryAccountNumber
            End Get
            Set(ByVal Value As String)
                _depositoryAccountNumber = Value
            End Set
        End Property

        Private _depositRemarks As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositRemarks() As String
            Get
                Return _depositRemarks
            End Get
            Set(ByVal Value As String)
                _depositRemarks = Value
            End Set
        End Property

        Private _depositDetails As List(Of DepositDetails) ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DepositDetails() As List(Of DepositDetails)
            Get
                Return _depositDetails
            End Get
            Set(ByVal Value As List(Of DepositDetails))
                _depositDetails = Value
            End Set
        End Property

        Private _depositAmount As Decimal

        Public Property DepositAmount() As Decimal
            Get
                If _depositAmount > 0 Then
                    Return _depositAmount
                Else
                    Dim amount As Decimal
                    For Each rec As DepositDetails In Me.DepositDetails
                        amount += rec.PaymentAmount
                    Next

                    Return amount
                End If

            End Get
            Set(ByVal value As Decimal)
                _depositAmount = value
            End Set
        End Property


        Public Shared Sub SaveDeposit(ByVal dep As Deposits)

            'Save main deposits
            Dim depositid As String

            Using params As New OraParameter

                params.AddItem("deposittotalamount", dep.DepositAmount, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Decimal)
                params.AddItem("depositdate", dep.DepositDate, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddItem("deposittype", DepositTypeSource.GetDepositTypeValue(dep.DepositType), ParameterDirection.Input)
                If String.IsNullOrEmpty(dep.DepositRemarks) Then
                    params.AddItem("depositremarks", dep.DepositRemarks, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Varchar2, True)
                Else
                    params.AddItem("depositremarks", dep.DepositRemarks, ParameterDirection.Input)
                End If
                params.AddItem("depositbank", dep.DepositBankID, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Int32)

                params.AddItem("depositid", "", ParameterDirection.ReturnValue, Oracle.DataAccess.Client.OracleDbType.Int32)

                depositid = DirectCast(OraDBHelper2.ExecuteFunction("INSERTDEPOSIT", params.GetParameterCollection), OracleDecimal).ToString
            End Using


            'Update deposit Details
            For Each rec As DepositDetails In dep.DepositDetails
                Using params As New OraParameter
                    params.AddItem(":depositid", depositid, Oracle.DataAccess.Client.OracleDbType.Int32)
                    params.AddItem(":paymentid", rec.PaymentID, )
                    OraDBHelper2.SqlExecute(UpdateStatement.UpdatePaymentDepositID, params.GetParameterCollection)
                End Using
            Next

        End Sub


        Public Shared Sub CancelDeposit(ByVal id As String)

            Using params As New OraParameter
                params.AddItem(":depositid", id, Oracle.DataAccess.Client.OracleDbType.Int32)

                OraDBHelper2.SqlExecute(UpdateStatement.UpdateDepositHeader, params.GetParameterCollection)
            End Using

        End Sub

        Public Shared Function GetDepositsbyDateRange(ByVal startDate As Date, ByVal endDate As Date) As DataTable
            Using params As New OraParameter
                params.AddItem(":startDate", startDate, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddItem(":endDate", endDate, Oracle.DataAccess.Client.OracleDbType.Date)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositsByDateRange, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function GetDepositsbyDepositType(ByVal depositType As DepositType) As DataTable
            Dim type As String

            If depositType = depositType.Cash Then
                type = "CSH"
            Else
                type = "CHK"
            End If

            Using params As New OraParameter
                params.AddItem(":deposittype", type)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositsByType, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function GetDepositsbyDepositoryBank(ByVal bankid As String) As DataTable

            Using params As New OraParameter
                params.AddItem(":bankid", bankid)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositsByBank, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function GetUndepositedReceipts(ByVal paymentType As DepositType, ByVal startDate As Date, ByVal endDate As Date) As DataTable
            Dim type As String

            If paymentType = DepositType.Cash Then
                type = "CSH"
            Else
                type = "CHK"
            End If

            Using params As New OraParameter
                params.AddItem(":paytype", type)
                params.AddItem(":startdate", startDate, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddItem(":enddate", endDate, Oracle.DataAccess.Client.OracleDbType.Date)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetUndepositedReceipts, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetDepositedReceipts(ByVal id As String) As DataTable

            Using params As New OraParameter
                params.AddItem(":depositid", id, Oracle.DataAccess.Client.OracleDbType.Int32)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositedReceipts, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetDepositDetails(ByVal id As String) As Deposits

            Using params As New OraParameter
                params.AddItem(":depositid", id, Oracle.DataAccess.Client.OracleDbType.Int32)

                Dim deposits As New Deposits
                With OraDBHelper2.GetResultSet(SelectStatement.GetDepositDetails, params.GetParameterCollection)
                    deposits.DepositID = .Rows(0)("deposit_id").ToString
                    deposits.DepositDate = .Rows(0)("deposit_date")
                    deposits.DepositoryAccountNumber = .Rows(0)("bank_account_no").ToString
                    deposits.DepositoryBankName = .Rows(0)("proj_bank_name").ToString
                    deposits.DepositType = DepositTypeSource.GetDepositType(.Rows(0)("deposit_type").ToString)
                    deposits.DepositAmount = Decimal.Parse(.Rows(0)("deposit_total_amt"))
                    deposits.DepositRemarks = .Rows(0)("deposit_remarks").ToString
                End With

                Return deposits
            End Using

        End Function


    End Class

    Public Class DepositDetails
        Private _paymentID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property PaymentID() As String
            Get
                Return _paymentID
            End Get
            Set(ByVal Value As String)
                _paymentID = Value
            End Set
        End Property
        Private _paymentAmount As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property PaymentAmount() As Decimal
            Get
                Return _paymentAmount
            End Get
            Set(ByVal Value As Decimal)
                _paymentAmount = Value
            End Set
        End Property
    End Class

End Namespace

