Imports System.ComponentModel
Imports System.Globalization
Imports BCL.Common
Imports BCL.Utils
Imports DALC
Imports Oracle.DataAccess.Client
Imports System.ComponentModel.DataAnnotations

Namespace Checks

    <CLSCompliant(True)>
    Public Enum CheckClearing
        <EnumDescription("LOCAL")> _
        <EnumDBValue("LCL")> _
         Local
        <EnumDescription("REGIONAL")> _
        <EnumDBValue("REG")> _
         Regional
    End Enum

    <CLSCompliant(True)>
    Public Enum CheckCustodian
        <EnumDescription("HEAD OFFICE")> _
        <EnumDBValue("P")> _
         HeadOffice
        <EnumDescription("CONDO CORP")> _
        <EnumDBValue("C")> _
         CondoCorp
    End Enum

    <CLSCompliant(True)>
    Public Enum CheckStatus
        <EnumDescription("ACTIVE/REDEPOSIT")> _
        <EnumDBValue("ACT")> _
        Active
        <EnumDescription("APPLIED")> _
        <EnumDBValue("APP")> _
        Applied
        <EnumDescription("PARTIALLY APPLIED")> _
        <EnumDBValue("PAR")> _
        PartiallyApplied
        <EnumDescription("HOLD")> _
        <EnumDBValue("HLD")> _
        Hold
        <EnumDescription("REPLACED/PULLOUT")> _
        <EnumDBValue("REP")> _
        ReplacedPullOut
        <EnumDescription("BOUNCED")> _
        <EnumDBValue("BOU")> _
        Bounced
    End Enum

    Public Enum NotificationType
        <EnumDescription("PHONE CALL")> _
        <EnumDBValue("PC")> _
        PhoneCall
        <EnumDescription("EMAIL")> _
        <EnumDBValue("EM")> _
        Email
        <EnumDescription("FAX")> _
        <EnumDBValue("FX")> _
        Fax
        <EnumDescription("PERSONAL APPEARANCE")> _
        <EnumDBValue("PA")> _
        PersonalAppearance
    End Enum


    Public Class NotificationListSrc
        Inherits ListSource
        Public Sub New()
            Me.AddItem("-1", "SELECT NOTIFICATION TYPE")
            Me.AddItem(EnumHelper.GetDBValue(NotificationType.PhoneCall), EnumHelper.GetDescription(NotificationType.PhoneCall))
            Me.AddItem(EnumHelper.GetDBValue(NotificationType.Email), EnumHelper.GetDescription(NotificationType.Email))
            Me.AddItem(EnumHelper.GetDBValue(NotificationType.Fax), EnumHelper.GetDescription(NotificationType.Fax))
            Me.AddItem(EnumHelper.GetDBValue(NotificationType.PersonalAppearance), EnumHelper.GetDescription(NotificationType.PersonalAppearance))

        End Sub
    End Class

    Public Class CheckStatusListSrc
        Inherits ListSource

        Public Sub New(checkStatus As CheckStatus)
            Me.AddItem("-1", "SELECT STATUS")
            Select Case checkStatus
                Case Checks.CheckStatus.Active
                    Me.AddItem(EnumHelper.GetDBValue(checkStatus.Hold), EnumHelper.GetDescription(checkStatus.Hold))
                    Me.AddItem(EnumHelper.GetDBValue(checkStatus.ReplacedPullOut), EnumHelper.GetDescription(checkStatus.ReplacedPullOut))
                Case Checks.CheckStatus.Hold
                    Me.AddItem(EnumHelper.GetDBValue(checkStatus.Active), EnumHelper.GetDescription(checkStatus.Active))
                Case Checks.CheckStatus.Bounced
                    Me.AddItem(EnumHelper.GetDBValue(checkStatus.Active), EnumHelper.GetDescription(checkStatus.Active))
                Case Checks.CheckStatus.Applied
                    Me.AddItem(EnumHelper.GetDBValue(checkStatus.Bounced), EnumHelper.GetDescription(checkStatus.Bounced))
                    'Case Checks.CheckStatus.PartiallyApplied
                    '    Me.AddItem(EnumHelper.GetDBValue(checkStatus.Bounced), EnumHelper.GetDescription(checkStatus.Bounced))
            End Select
        End Sub
        Public Sub New()
            Me.AddItem("-1", "SELECT STATUS")
            Me.AddItem(EnumHelper.GetDBValue(CheckStatus.Hold), EnumHelper.GetDescription(CheckStatus.Hold))
            Me.AddItem(EnumHelper.GetDBValue(CheckStatus.ReplacedPullOut), EnumHelper.GetDescription(CheckStatus.ReplacedPullOut))
            Me.AddItem(EnumHelper.GetDBValue(CheckStatus.Bounced), EnumHelper.GetDescription(CheckStatus.Bounced))
        End Sub

    End Class

    <ComponentModel.TypeConverter(GetType(CheckBankConverter))>
    Public Class CheckBank
        Inherits ListSource
        Public Property BankID As String
        Public Property BankName As String
        Public Sub New()
            Dim query As String = "SELECT BANK_ID   " & _
                                  "      ,BANK_NAME      " & _
                                  "FROM REF_BANKS  ORDER BY BANK_NAME  "

            For Each row As DataRow In OraDBHelper2.GetResultSet(query).Rows
                Me.AddItem(row("BANK_ID").ToString, row("BANK_NAME").ToString)
            Next
        End Sub

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString(culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter([GetType]()).ConvertToString(Nothing, culture, Me)
        End Function


    End Class

    Friend Class CheckBankConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is CheckBank) Then
                    Throw New ArgumentException("Invalid CheckBank", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return [String].Empty
                End If

                Dim ck As CheckBank = DirectCast(value, CheckBank)

                Return ck.BankName

            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class

    Friend Class BankBranchConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is BankBranch) Then
                    Throw New ArgumentException("Invalid CheckBank", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return [String].Empty
                End If

                Dim br As BankBranch = DirectCast(value, BankBranch)

                Return br.BranchName

            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class

    <ComponentModel.TypeConverter(GetType(BankBranchConverter))>
    Public Class BankBranch
        Inherits ListSource

        Public Property BranchID As String
        Public Property BranchName As String

        Public Sub New()
            Dim query As String = "SELECT BRANCH_ID   " & _
                                  "      ,BRANCH_NAME      " & _
                                  "FROM CK_BANK_BRANCH  ORDER BY BRANCH_NAME  "

            For Each row As DataRow In OraDBHelper2.GetResultSet(query).Rows
                Me.AddItem(row("BRANCH_ID").ToString, row("BRANCH_NAME").ToString)
            Next

        End Sub

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString(culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter([GetType]()).ConvertToString(Nothing, culture, Me)
        End Function

    End Class

    <CLSCompliant(True)>
    <ComponentModel.TypeConverter(GetType(CheckConverter))>
    Public Class Check
        <ComponentModel.Browsable(False)>
        Public Property CheckID As String
        <ComponentModel.DisplayName("CHECK NUMBER")>
        Public Property CheckNumber As String
        <ComponentModel.DisplayName("CHECK DATE")>
        Public Property CheckDate As Nullable(Of Date)
        <ComponentModel.DisplayName("CHECK AMOUNT")>
        Public Property CheckAmount As Decimal
        <ComponentModel.DisplayName("RT NUMBER")>
        Public Property RTNumber As String
        <ComponentModel.DisplayName("CHECK CLEARING")>
        Public Property Clearing As CheckClearing
        <ComponentModel.DisplayName("PAYEE")>
        Public Property Payee As CheckCustodian
        <ComponentModel.DisplayName("CHECK STATUS")>
        Public Property Status As CheckStatus
        <ComponentModel.DisplayName("STATUS DATE")>
        Public Property StatusDate As Nullable(Of Date)
        <ComponentModel.Browsable(False)>
        Public Property ARID As String
        <ComponentModel.DisplayName("CHECK BANK")>
        Public Property Bank As CheckBank
        <ComponentModel.DisplayName("CHECK BRANCH")>
        Public Property Branch As BankBranch
        <ComponentModel.DisplayName("STATUS REMARKS")>
        Public Property StatusRemarks As String

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString(culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter([GetType]()).ConvertToString(Nothing, culture, Me)
        End Function

    End Class

    Friend Class CheckConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is Check) Then
                    Throw New ArgumentException("Invalid Check", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return [String].Empty
                End If

                Dim ck As Check = DirectCast(value, Check)

                Return ck.CheckNumber & " " & ck.Bank.ToString

            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

    Public Class CheckAmountDistribution
        <ComponentModel.DisplayName("CHECK INFO")>
        Public Property CheckInfo As Check
        <ComponentModel.DisplayName("AMOUNT DISTRIBUTION")>
        Public Property AmountDistribution As Decimal
        <ComponentModel.DisplayName("ACCOUNT NAME")>
        Public Property AccountName As Account
        <ComponentModel.DisplayName("FEE TYPE")>
        Public Property FeeType As FeeType


    End Class

    Public Class NewCheckAmountDistribution
        <ComponentModel.DisplayName(" ")>
        Public Property Selected As Boolean = False
        <ComponentModel.ReadOnly(True)>
        <ComponentModel.DisplayName("CHECK INFO")>
        Public Property Check As Check
        <ComponentModel.ReadOnly(True)>
        <ComponentModel.DisplayName("REMAINING AMOUNT")>
        Public Property RemainingAmount As Decimal
        <ComponentModel.DisplayName("AMOUNT DISTRIBUTION")>
        Public Property AmountDistribution As Decimal
    End Class

    <CLSCompliant(True)>
    <TypeConverter(GetType(FeeTypeConverter))>
    Public Class FeeType
        Public Property FeeTypeID As String
        Public Property FeeName As String

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString(culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter([GetType]()).ConvertToString(Nothing, culture, Me)
        End Function


    End Class

    Friend Class FeeTypeConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is FeeType) Then
                    Throw New ArgumentException("Invalid FeeType", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return [String].Empty
                End If

                Dim ft As FeeType = DirectCast(value, FeeType)

                Return ft.FeeName

            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class

    <TypeConverter(GetType(AccountConverter))>
    Public Class Account
        Public Property AccountID As String
        Public Property UnitNumber As String
        Public Property LeaseID As String
        Public Property AccountName As String

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString(culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter([GetType]()).ConvertToString(Nothing, culture, Me)
        End Function

    End Class

    Friend Class AccountConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is Account) Then
                    Throw New ArgumentException("Invalid Account", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return [String].Empty
                End If

                Dim ac As Account = DirectCast(value, Account)

                Return ac.UnitNumber & "-" & ac.AccountName

            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class

    Public Class AcknowlegementReceipt

        Public Property ARID As String
        <ComponentModel.DisplayName("A.R. NUMBER")>
        Public Property ARNumber As String
        <ComponentModel.DisplayName("A.R DATE")>
        Public Property ARDAte As Date
        <ComponentModel.DisplayName("A.R. CUSTODIAN")>
        Public Property ARcustodian As CheckCustodian
        <ComponentModel.DisplayName("REMARKS")>
        Public Property Remarks As String
        <ComponentModel.DisplayName("NOTES")>
        Public Property Notes As String


    End Class

    Public Class ChecksDTC

        <ComponentModel.Browsable(False)>
        Public Property CheckInfo As Check

        <ComponentModel.Browsable(False)>
        Public Property ARInfo As AcknowlegementReceipt

        <ComponentModel.Browsable(False)>
        Public ReadOnly Property CheckID As String
            Get
                Return CheckInfo.CheckID
            End Get
        End Property


        Public ReadOnly Property CheckNumber As String
            Get
                Return CheckInfo.CheckNumber
            End Get
        End Property

        Public ReadOnly Property BankName As String
            Get
                Return CheckInfo.Bank.BankName
            End Get
        End Property

        Public ReadOnly Property BankBranch As String
            Get
                Return CheckInfo.Branch.BranchName
            End Get
        End Property

        Public ReadOnly Property CheckDate As Date
            Get
                Return CheckInfo.CheckDate
            End Get
        End Property

        Public Property CheckAmount As Decimal

        Public ReadOnly Property CheckStatus As CheckStatus
            Get
                Return CheckInfo.Status
            End Get
        End Property

        Public ReadOnly Property StatusDate As Nullable(Of Date)
            Get
                Return CheckInfo.StatusDate
            End Get
        End Property

        Public ReadOnly Property StatusRemarks As String
            Get
                Return CheckInfo.StatusRemarks
            End Get
        End Property

        Public ReadOnly Property RTNUmber As String
            Get
                Return CheckInfo.RTNumber
            End Get
        End Property

        Public ReadOnly Property CheckClearing As CheckClearing
            Get
                Return CheckInfo.Clearing
            End Get
        End Property

        Public ReadOnly Property ARNumber As String
            Get
                Return ARInfo.ARNumber
            End Get
        End Property

        Public ReadOnly Property ARDate As Date
            Get
                Return ARInfo.ARDAte
            End Get
        End Property

        Public ReadOnly Property ARRemarks As String
            Get
                Return ARInfo.Remarks
            End Get
        End Property

    End Class

    Public Class ChecksDueDTC
        <ComponentModel.Browsable(False)>
        Public Property CheckInfo As Check


        Public ReadOnly Property CheckNumber As String
            Get
                Return CheckInfo.CheckNumber
            End Get
        End Property

        Public ReadOnly Property BankName As String
            Get
                Return CheckInfo.Bank.BankName
            End Get
        End Property

        Public ReadOnly Property BankBranch As String
            Get
                Return CheckInfo.Branch.BranchName
            End Get
        End Property

        Public ReadOnly Property CheckDate As Date
            Get
                Return CheckInfo.CheckDate
            End Get
        End Property

        Public Property CheckAmount As Decimal

        Public ReadOnly Property CheckStatus As String
            Get
                Return EnumHelper.GetDescription(CheckInfo.Status)
            End Get
        End Property
    End Class

    Public Class ChecksStatusHistoryDTC

        Private CheckInfo As Check
        Public Sub New(checkinfo As Check)
            Me.CheckInfo = checkinfo
        End Sub
        <DisplayName("CHECK STATUS")>
        Public ReadOnly Property CheckStatus As String
            Get
                Return EnumHelper.GetDescription(CheckInfo.Status)
            End Get
        End Property
        <DisplayName("STATUS DATE")>
        <DisplayFormat(DataFormatString:="ddMMMyy")>
        Public ReadOnly Property StatusDate As Date
            Get
                Return CheckInfo.StatusDate
            End Get
        End Property

        <DisplayName("STATUS REMARKS")>
        Public ReadOnly Property StatusRemarks As String
            Get
                Return CheckInfo.StatusRemarks
            End Get
        End Property

        <DisplayName("NOTIFIED THRU")>
        Public Property NotificationType As String

        <DisplayName("UPDATED BY")>
        Public Property UpdatedBy As String

        <DisplayName("UPDATED ON")>
        Public Property UpdatedOn As Date


    End Class

    Public Class ChecksDAL

        Public Shared Function SaveNewAR(ARCustodian As CheckCustodian, ARDate As Date, Remarks As String, notes As String, Checks As List(Of Check), CheckDistribution As List(Of CheckAmountDistribution)) As String

            Dim checksID As New ArrayList
            Dim checksNumber As New ArrayList
            Dim checkDate As New ArrayList
            Dim checkAmount As New ArrayList
            Dim checkRTNumber As New ArrayList
            Dim checksClearing As New ArrayList
            Dim checksBank As New ArrayList
            Dim checksBankBranch As New ArrayList
            Dim checksDistributeID As New ArrayList
            Dim checksAccount As New ArrayList
            Dim checksFee As New ArrayList
            Dim checksAmountDistribute As New ArrayList

            For Each ck As Check In Checks
                checksID.Add(ck.CheckID)
                checksNumber.Add(ck.CheckNumber)
                checkDate.Add(ck.CheckDate)
                checkAmount.Add(ck.CheckAmount)
                checkRTNumber.Add(ck.RTNumber)
                checksClearing.Add(EnumHelper.GetDBValue(ck.Clearing))
                checksBank.Add(ck.Bank.BankID)
                checksBankBranch.Add(ck.Branch.BranchID)
                For Each cd As CheckAmountDistribution In CheckDistribution.FindAll(Function(x As CheckAmountDistribution)
                                                                                        Return x.CheckInfo.CheckID = ck.CheckID
                                                                                    End Function)
                    checksDistributeID.Add(ck.CheckID)
                    checksAccount.Add(cd.AccountName.AccountID)
                    checksFee.Add(cd.FeeType.FeeTypeID)
                    checksAmountDistribute.Add(cd.AmountDistribution)
                Next
            Next


            Using param As New OraParameter
                param.AddParameter("checkcustodian", EnumHelper.GetDBValue(ARCustodian))
                param.AddParameter("ardate", ARDate, OracleDbType.Date)
                param.AddParameter("remarks", Remarks)
                If Not String.IsNullOrEmpty(notes) Then
                    param.AddParameter("notes", notes)
                End If

                param.AddParameter("checksID", DirectCast(checksID.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksNumber", DirectCast(checksNumber.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checkDate", DirectCast(checkDate.ToArray(GetType(Date)), Date()), OracleDbType.Date, ParameterDirection.Input, True)
                param.AddParameter("checkAmount", DirectCast(checkAmount.ToArray(GetType(Decimal)), Decimal()), OracleDbType.Decimal, ParameterDirection.Input, True)
                param.AddParameter("checkRTNumber", DirectCast(checkRTNumber.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksClearing", DirectCast(checksClearing.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksBank", DirectCast(checksBank.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksBankBranch", DirectCast(checksBankBranch.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksDistributeID", DirectCast(checksDistributeID.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksAccount", DirectCast(checksAccount.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksFee", DirectCast(checksFee.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checksAmountDistribute", DirectCast(checksAmountDistribute.ToArray(GetType(Decimal)), Decimal()), OracleDbType.Decimal, ParameterDirection.Input, True)

                param.AddParameter("arnumber", "", OracleDbType.Varchar2, ParameterDirection.ReturnValue)

                Return OraDBHelper2.ExecuteFunction("checks.insertnewar", param.GetParameterCollection).ToString
            End Using

        End Function

        Public Shared Function GetARDetails() As List(Of AcknowlegementReceipt)
            Dim query As String = "select ar_id,ar_number,ar_date,ar_custodian,ar_remarks,ar_notes from ck_check_ar " & _
                                  "order by ar_number                                           "

            Dim ar As New List(Of AcknowlegementReceipt)

            For Each dr As DataRow In OraDBHelper2.GetResultSet(query).Rows
                ar.Add(New AcknowlegementReceipt With {.ARID = dr.Item("ar_id").ToString,
                                                         .ARNumber = dr.Item("ar_number").ToString,
                                                         .ARDAte = Date.Parse(dr.Item("ar_date").ToString),
                                                         .ARcustodian = EnumHelper.GetEnumValueFromDBValue(Of CheckCustodian)(dr.Item("ar_custodian").ToString),
                                                         .Remarks = dr.Item("ar_remarks").ToString,
                                                         .Notes = dr.Item("ar_notes").ToString}
                                                     )
            Next

            Return ar

        End Function

        Public Shared Function GetARDetailsByARNumber(arnumber As String) As List(Of AcknowlegementReceipt)
            Dim query As String = "select ar_id,ar_number,ar_date,ar_custodian,ar_remarks,ar_notes from ck_check_ar " & _
                            "where ar_number = LPAD(:arnumber,5,'0') order by ar_number                                           "

            Dim ar As New List(Of AcknowlegementReceipt)

            Using param As New OraParameter
                param.AddParameter("arnumber", arnumber)

                For Each dr As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                    ar.Add(New AcknowlegementReceipt With {.ARID = dr.Item("ar_id").ToString,
                                                             .ARNumber = dr.Item("ar_number").ToString,
                                                             .ARDAte = Date.Parse(dr.Item("ar_date").ToString),
                                                             .ARcustodian = EnumHelper.GetEnumValueFromDBValue(Of CheckCustodian)(dr.Item("ar_custodian").ToString),
                                                             .Remarks = dr.Item("ar_remarks").ToString,
                                                             .Notes = dr.Item("ar_notes").ToString}
                                                         )
                Next
            End Using


            Return ar
        End Function

        Public Shared Function GetCheckDetailsByARID(arID As String) As List(Of Check)
            Dim query As String = "SELECT check_id, check_number, check_date, check_amount, rt_number," & _
                                "       check_clearing, check_status, bank_id,                      " & _
                                "       (SELECT bank_name                                           " & _
                                "          FROM ref_banks                                           " & _
                                "         WHERE bank_id = cc.bank_id) bank_name, branch_id,         " & _
                                "       (SELECT branch_name                                         " & _
                                "          FROM ck_bank_branch                                      " & _
                                "         WHERE branch_id = cc.branch_id) branch_name ,check_custodian          " & _
                                "  FROM ck_check cc                                                 " & _
                                " WHERE ar_id = :arid                                               "


            Using param As New OraParameter
                param.AddParameter("arid", arID)

                Dim ck As New List(Of Check)
                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                    ck.Add(New Check With {.CheckID = rw.Item("check_id").ToString,
                                           .CheckNumber = rw.Item("check_number").ToString,
                                           .CheckAmount = Decimal.Parse(rw.Item("check_amount").ToString),
                                           .CheckDate = Date.Parse(rw.Item("check_date").ToString),
                                           .Bank = New CheckBank With {.BankID = rw.Item("bank_id").ToString,
                                                                             .BankName = rw.Item("bank_name").ToString},
                                           .Branch = New BankBranch With {.BranchID = rw.Item("branch_id").ToString,
                                                                              .BranchName = rw.Item("branch_name").ToString},
                                            .Payee = EnumHelper.GetEnumValueFromDBValue(Of CheckCustodian)(rw.Item("check_custodian").ToString),
                                           .Status = EnumHelper.GetEnumValueFromDBValue(Of CheckStatus)(rw.Item("check_status").ToString),
                                           .Clearing = EnumHelper.GetEnumValueFromDBValue(Of CheckClearing)(rw.Item("check_clearing").ToString),
                                           .RTNumber = rw.Item("rt_number").ToString})
                Next

                Return ck
            End Using
        End Function

        Public Shared Function GetCheckDetailsByAccountID(accountID As String) As List(Of ChecksDTC)
            Dim query As String = "SELECT   *                                                                     " & _
                                        "    FROM (SELECT check_id, check_number,                                       " & _
                                        "                 (SELECT SUM (amount)                                          " & _
                                        "                    FROM ck_check_application                                  " & _
                                        "                   WHERE account_id = :accountid                               " & _
                                        "                     AND check_id = cc.check_id) check_amount,                 " & _
                                        "                 check_date, bank_id, (SELECT bank_name                        " & _
                                        "                                         FROM ref_banks                        " & _
                                        "                                        WHERE bank_id = cc.bank_id) bank_name, " & _
                                        "                 branch_id, (SELECT branch_name                                " & _
                                        "                               FROM ck_bank_branch                             " & _
                                        "                              WHERE branch_id = cc.branch_id) branch_name,     " & _
                                        "                 rt_number, check_clearing, check_status, status_date,         " & _
                                        "                 status_remarks, check_custodian, ar_number, ar_date,     " & _
                                        "                 ar_remarks                                                    " & _
                                        "            FROM ck_check cc JOIN ck_check_ar ca ON (cc.ar_id = ca.ar_id)      " & _
                                        "           WHERE check_id IN (SELECT check_id                                  " & _
                                        "                                FROM ck_check_application                      " & _
                                        "                               WHERE account_id = :accountid)                  " & _
                                        "          UNION                                                                " & _
                                        "          SELECT cc.check_id, cc.check_number, paid_amount, cc.check_date,     " & _
                                        "                 bank_id, (SELECT bank_name                                    " & _
                                        "                             FROM ref_banks                                    " & _
                                        "                            WHERE bank_id = cc.bank_id) bank_name, branch_id,  " & _
                                        "                 (SELECT branch_name                                           " & _
                                        "                    FROM ck_bank_branch                                        " & _
                                        "                   WHERE branch_id = cc.branch_id) branch_name, rt_number,     " & _
                                        "                 check_clearing, check_status, status_date,                    " & _
                                        "                 status_remarks, check_custodian, NULL, NULL, NULL        " & _
                                        "            FROM ck_check cc LEFT JOIN payments ps                             " & _
                                        "                 ON (cc.check_id = ps.check_id)                                " & _
                                        "           WHERE ar_id IS NULL AND pay_acct_id = :accountid)                   " & _
                                        "ORDER BY check_date                                                            "
            Using param As New OraParameter
                param.AddParameter("accountid", accountID)

                Dim ck As New List(Of ChecksDTC)
                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                    Dim statusDate As New Nullable(Of Date)

                    If Not Convert.IsDBNull(rw.Item("status_date")) Then
                        statusDate = Date.Parse(rw.Item("status_date").ToString)
                    End If

                    Dim ackr As New AcknowlegementReceipt
                    If Not Convert.IsDBNull(rw.Item("ar_date")) Then

                        ackr = New AcknowlegementReceipt With {.ARNumber = rw.Item("ar_number").ToString,
                                                                                         .ARDAte = Date.Parse(rw.Item("ar_date").ToString),
                                                                                         .Remarks = rw.Item("ar_remarks").ToString}
                    End If

                    ck.Add(New ChecksDTC With {.CheckInfo = New Check With {.CheckID = rw.Item("check_id").ToString,
                                                            .CheckNumber = rw.Item("check_number").ToString,
                                                            .CheckDate = Date.Parse(rw.Item("check_date").ToString),
                                                            .Bank = New CheckBank With {.BankID = rw.Item("bank_id").ToString,
                                                                                            .BankName = rw.Item("bank_name").ToString},
                                                            .Branch = New BankBranch With {.BranchID = rw.Item("branch_id").ToString,
                                                                                            .BranchName = rw.Item("branch_name").ToString},
                                                            .Clearing = EnumHelper.GetEnumValueFromDBValue(Of CheckClearing)(rw.Item("check_clearing").ToString),
                                                            .RTNumber = rw.Item("rt_number").ToString,
                                                            .Status = EnumHelper.GetEnumValueFromDBValue(Of CheckStatus)(rw.Item("check_status").ToString),
                                                            .StatusRemarks = rw.Item("status_remarks").ToString,
                                                            .StatusDate = statusDate,
                                                            .Payee = EnumHelper.GetEnumValueFromDBValue(Of CheckCustodian)(rw.Item("check_custodian").ToString)},
                                               .ARInfo = ackr,
                    .CheckAmount = Decimal.Parse(rw.Item("check_amount").ToString)
                                              })
                Next
                Return ck
            End Using

        End Function

        Public Shared Function GetCheckAmountDistributionByARID(arID As String) As List(Of CheckAmountDistribution)
            Dim query As String = "SELECT check_id, (SELECT check_number                                     " & _
                                "                    FROM ck_check                                         " & _
                                "                   WHERE check_id = ca.check_id) check_number,            " & _
                                "       (SELECT (SELECT bank_name                                          " & _
                                "                  FROM ref_banks                                          " & _
                                "                 WHERE bank_id = cc.bank_id)                              " & _
                                "          FROM ck_check cc                                                " & _
                                "         WHERE check_id = ca.check_id) check_bank,                        " & _
                                "       (SELECT (SELECT branch_name                                        " & _
                                "                  FROM ck_bank_branch                                     " & _
                                "                 WHERE branch_id = cc.branch_id)                          " & _
                                "          FROM ck_check cc                                                " & _
                                "         WHERE check_id = ca.check_id) check_branch, amount, account_id,  " & _
                                "       (SELECT accounts.getcustomerfullname_fml (acct_cust_id)            " & _
                                "          FROM customer_accounts                                          " & _
                                "         WHERE account_id = ca.account_id) account_name,                  " & _
                                "       accounts.getunitnumber (ca.account_id) unit_number, fee_type_id,   " & _
                                "       (SELECT fee_description                                            " & _
                                "          FROM ref_fee_types                                              " & _
                                "         WHERE fee_type_id = ca.fee_type_id) fee_name                     " & _
                                "  FROM ck_check_application ca                                            " & _
                                " WHERE check_id IN (SELECT check_id                                       " & _
                                "                      FROM ck_check                                       " & _
                                "                     WHERE ar_id = :arid)                                 "


            Using param As New OraParameter
                param.AddParameter("arid", arID)

                Dim ck As New List(Of CheckAmountDistribution)
                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                    ck.Add(New CheckAmountDistribution With {.CheckInfo = New Check With {.CheckNumber = rw.Item("check_number").ToString,
                                                                                      .Bank = New CheckBank With {.BankName = rw.Item("check_bank").ToString},
                                                                                      .Branch = New BankBranch With {.BranchName = rw.Item("check_branch").ToString}
                                                                                     },
                                                             .AmountDistribution = Decimal.Parse(rw.Item("amount").ToString),
                                                             .AccountName = New Account With {.AccountID = rw.Item("account_id").ToString,
                                                                                              .AccountName = rw.Item("account_name").ToString,
                                                                                              .UnitNumber = rw.Item("unit_number").ToString},
                                                             .FeeType = New FeeType With {.FeeName = rw.Item("fee_name").ToString}})
                Next

                Return ck
            End Using
        End Function

        Public Shared Function GetChecksDueByAccountID(accountID As String, feeTypeID As String, Optional cutOffDate As Nullable(Of Date) = Nothing) As List(Of ChecksDueDTC)
            Dim query As String = "SELECT ca.check_id, amount, check_number, check_date, bank_id,                 " & _
                                "       (SELECT bank_name                                                       " & _
                                "          FROM ref_banks                                                       " & _
                                "         WHERE bank_id = cc.bank_id) bank_name, branch_id,                     " & _
                                "       (SELECT branch_name                                                     " & _
                                "          FROM ck_bank_branch                                                  " & _
                                "         WHERE branch_id = cc.branch_id) branch_name                           " & _
                                "  FROM ck_check_application ca JOIN ck_check cc ON (ca.check_id = cc.check_id  " & _
                                "                                                   )                           " & _
                                " WHERE account_id = :accountid AND fee_type_id = :feetypeid AND status = 'NAP' " & _
                                " AND check_status in ('ACT','PAR') ORDER BY check_date "

            Using param As New OraParameter
                param.AddParameter("accountid", accountID)
                param.AddParameter("feetypeid", feeTypeID)
                If cutOffDate.HasValue Then
                    param.AddParameter("cutOffDate", cutOffDate, OracleDbType.Date)
                End If

                Dim ck As New List(Of ChecksDueDTC)
                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows

                    ck.Add(New ChecksDueDTC With {.CheckInfo = New Check With {.CheckID = rw.Item("check_id").ToString,
                                                            .CheckNumber = rw.Item("check_number").ToString,
                                                            .CheckDate = Date.Parse(rw.Item("check_date").ToString),
                                                            .Bank = New CheckBank With {.BankID = rw.Item("bank_id").ToString,
                                                                                            .BankName = rw.Item("bank_name").ToString},
                                                            .Branch = New BankBranch With {.BranchID = rw.Item("branch_id").ToString,
                                                                                            .BranchName = rw.Item("branch_name").ToString}},
                    .CheckAmount = Decimal.Parse(rw.Item("amount").ToString)
                                              })
                Next
                Return ck
            End Using
        End Function

        Public Shared Function GetCheckStatusHistory(checkID As String) As List(Of ChecksStatusHistoryDTC)
            Dim query As String = "SELECT check_status, status_date, status_remarks, notification_type," & _
                        "       created_by, created_on                                       " & _
                        "  FROM ck_check_status_history                                      " & _
                        "  where check_id = :checkid                                         "

            Using param As New OraParameter

                param.AddParameter("checkid", checkID)

                Dim checkStatus As New List(Of ChecksStatusHistoryDTC)

                For Each rw As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows

                    Dim notifyType As String = String.Empty
                    If Not String.IsNullOrEmpty(rw.Item("notification_type").ToString) Then
                        notifyType = EnumHelper.GetDescription(EnumHelper.GetEnumValueFromDBValue(Of NotificationType)(rw.Item("notification_type").ToString))
                    End If
                    checkStatus.Add(New ChecksStatusHistoryDTC(checkinfo:=New Check With {.Status = EnumHelper.GetEnumValueFromDBValue(Of CheckStatus)(rw.Item("check_status").ToString),
                                                                                        .StatusDate = Date.Parse(rw.Item("status_date").ToString),
                                                                                        .StatusRemarks = rw.Item("status_remarks").ToString
                                                                                          }) With {.NotificationType = notifyType,
                                                                                                   .UpdatedBy = rw.Item("created_by").ToString,
                                                                                                   .UpdatedOn = Date.Parse(rw.Item("created_on").ToString)})

                Next

                Return checkStatus

            End Using

        End Function

        Public Shared Function UpdateCheckStatus(checkID As String, checkStatus As String, statusdate As Date, notificationType As String, remarks As String) As Integer
            Using param As New OraParameter
                param.AddParameter("checkid", checkID)
                param.AddParameter("checkstatus", checkStatus)
                param.AddParameter("statusdate", statusdate, OracleDbType.Date)
                param.AddParameter("notificationtype", notificationType)
                If Not String.IsNullOrEmpty(remarks) Then
                    param.AddParameter("remarks", remarks)
                End If
                param.AddParameter("rowaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                Return DirectCast(OraDBHelper2.ExecuteFunction("checks.updatestatus", param.GetParameterCollection), Oracle.DataAccess.Types.OracleDecimal).ToInt32()
            End Using

        End Function

        Public Shared Function UpdateCheckStatus(checkids As ArrayList, checkStatus As String, statusdate As Date, notificationType As String, remarks As String) As Integer
            Using param As New OraParameter
                param.AddParameter("checkids", DirectCast(checkids.ToArray(GetType(String)), String()), OracleDbType.Varchar2, ParameterDirection.Input, True)
                param.AddParameter("checkstatus", checkStatus)
                param.AddParameter("statusdate", statusdate, OracleDbType.Date)
                param.AddParameter("notificationtype", notificationType)
                If Not String.IsNullOrEmpty(remarks) Then
                    param.AddParameter("remarks", remarks)
                End If
                param.AddParameter("rowaffected", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                Return DirectCast(OraDBHelper2.ExecuteFunction("checks.updatestatus", param.GetParameterCollection), Oracle.DataAccess.Types.OracleDecimal).ToInt32()
            End Using

        End Function
    End Class

End Namespace



