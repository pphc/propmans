'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 05-13-2010
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports System.IO
Imports System.Text
Imports DALC
Imports BCL.Statements

Imports BCL.Common
Imports Oracle.DataAccess.Client
Imports ZetaCompressionLibrary


Namespace Export

    Public MustInherit Class DataExport
        Private _exportFolderPath As String
        Public Property ExportFolderPath() As String
            Get
                Return _exportFolderPath
            End Get
            Set(ByVal value As String)
                _exportFolderPath = value
            End Set
        End Property

        Private _tempExportFolderPath As String
        Public Property TemporaryFolderPath() As String
            Get
                Return _tempExportFolderPath
            End Get
            Set(ByVal value As String)
                _tempExportFolderPath = value
            End Set
        End Property


        Public ReadOnly Property FullExportPathName() As String
            Get
                Return _exportFolderPath & "\" & Filename
            End Get
        End Property

        Public ReadOnly Property ProjectID() As String
            Get
                Return GlobalReference.ProjectParameters.SiteFinanceCode
            End Get
        End Property

        Public ReadOnly Property ProjectCodeName() As String
            Get
                Return GlobalReference.ProjectParameters.SiteCode
            End Get
        End Property


        Public MustOverride ReadOnly Property Filename() As String

        Public MustOverride Sub Export()

        Protected Function FmtStr(ByVal str As String) As String

            Return String.Format("""{0}""", str)

        End Function

        Protected Sub CompressFiles()
            Dim filepaths As New ArrayList


            For Each filepath As String In Directory.GetFiles(TemporaryFolderPath)
                filepaths.Add(filepath)
            Next

            Dim buffer As Byte() = CompressionHelper.CompressFiles(filepaths.ToArray(GetType(String)))


            Dim fs As FileStream = File.Create(ExportFolderPath & "\" & Filename & ".zip")
            fs.Write(buffer, 0, buffer.Length)
            fs.Close()


        End Sub


    End Class

    Public Class BatchDepositExport
        Inherits DataExport

        Private _depositIDstart As String
        Public Property DepositIDStart() As String
            Get
                Return _depositIdstart
            End Get
            Set(ByVal value As String)
                _depositIdstart = value
            End Set
        End Property

        Private _depositIDend As String
        Public Property DepositIDend() As String
            Get
                Return _depositIDend
            End Get
            Set(ByVal value As String)
                _depositIDend = value
            End Set
        End Property

        Public Overrides ReadOnly Property Filename() As String
            Get
                Return ProjectCodeName & "-" & _
                       DepositIDStart.PadLeft(6, "0") & "-" & DepositIDend.PadLeft(6, "0") & " OR"
            End Get
        End Property

        'BATCHID	BTCHENTRY	SRCELEDGER	SRCETYPE	FSCSYR	FSCSPERD	DATEENTRY	JRNLDESC'

        Public Const Header1 As String = """" & "RECTYPE" & """" & "," & _
                                      """" & "BATCHID" & """" & "," & """" & "BTCHENTRY" & """" & "," & _
                                      """" & "SRCELEDGER" & """" & "," & """" & "SRCETYPE" & """" & "," & _
                                      """" & "FSCSYR" & """" & "," & """" & "FSCSPERD" & """" & "," & _
                                       """" & "JRNLDESC" & """" & "," & """" & "DATEENTRY" & """"

        'BATCHNBR	JOURNALID	TRANSNBR	ACCTID	TRANSAMT	TRANSDESC	TRANSREF	TRANSDATE	COMMENT	SRCELDGR	SRCETYPE
        Public Const Header2 As String = """" & "RECTYPE" & """" & "," & _
                                         """" & "BATCHNBR" & """" & "," & """" & "JOURNALID" & """" & "," & _
                                         """" & "TRANSNBR" & """" & "," & """" & "ACCTID" & """" & "," & _
                                         """" & "TRANSAMT" & """" & "," & """" & "TRANSDESC" & """" & "," & _
                                         """" & "TRANSREF" & """" & "," & """" & "TRANSDATE" & """" & "," & _
                                         """" & "SRCELDGR" & """" & "," & """" & "SRCETYPE" & """" & "," & _
                                         """" & "COMMENT" & """"

        Public Const Header3 As String = """" & "RECTYPE" & """" & "," & _
                                               """" & "BATCHNBR" & """" & "," & """" & "JOURNALID" & """" & "," & _
                                               """" & "TRANSNBR" & """" & "," & """" & "OPTFIELD" & """"

        Public Const Summaryheader As String = """" & "DEPOSIT_ID" & """" & "," & """" & "COMPANY" & """" & "," & _
                                       """" & "STATUS" & """" & "," & """" & "REMARKS" & """"

        Public Overrides Sub Export()
            Using dtHeader As DataTable = GetDepositHeader(), _
                    dtDetails As DataTable = GetDepositDetails(), _
                      dtDepositSummary As DataTable = GetDepositSummary()

                If String.IsNullOrEmpty(_depositIDend) Then
                    _depositIDend = dtDepositSummary.Compute("MAX(deposit_id)", "").ToString()
                End If

                'If CreateFolder Then
                IO.Directory.CreateDirectory(ExportFolderPath & "\" & Filename)
                TemporaryFolderPath = ExportFolderPath & "\" & Filename & "\"
                'End If

                Using sw As New StreamWriter(TemporaryFolderPath & " SUMMARY.csv")
                    sw.WriteLine(Summaryheader)
                    For Each dr As DataRow In dtDepositSummary.Rows
                        sw.WriteLine(String.Format("{0},{1},{2},{3}", dr("deposit_id").ToString.PadLeft(6, "0"), _
                                    IIf(dr("companytype").ToString() = "P", "PPHC", "CONDOCORP"), _
                                    IIf(dr("deposit_status").ToString() = "P", "POSTED", "CANCELLED"), _
                                    dr("deposit_remarks").ToString()))
                    Next
                End Using

                Using sw As New StreamWriter(TemporaryFolderPath & Filename & ".csv")
                    Dim cnt As Integer = 1
                    Dim entryno As Integer = 1
                    sw.WriteLine(Header1)
                    sw.WriteLine(Header2)
                    sw.WriteLine(Header3)
                    For Each dr As DataRow In dtHeader.Rows
                        Dim jrndesc As String = ProjectCodeName & "-" & _
                                                       dr("deposit_id").ToString.PadLeft(6, "0") & _
                                                       "-" & Date.Parse(dr("deposit_date")).ToString("yyyyMMdd") & _
                                                       "-" & dr("bankcode").ToString



                        Dim depositID As Integer = Integer.Parse(dr("deposit_id"))


                        For Each rw As DataRow In dtDetails.Select("deposit_id = " & depositID, "or_number")
                            Dim batchId As Integer = 20
                            Dim itemDesc As String
                            itemDesc = rw("feedescription").ToString.ToUpper & " [" & _
                                       ProjectCodeName & "] " & _
                                       rw("unitnumber").ToString

                            Dim acctID As String = rw("feeid").ToString.Split(",")(1).Replace("x", GlobalReference.ProjectParameters.SiteFinanceCode)

                            Dim costCenter As String = rw("feeid").ToString.Split("x")(1)

                            sw.WriteLine(String.Format("""1"",""666666"",{0},""GL"",""OR"",{1:yyyy},{2:MM},""{3}"",{4:yyyyMMdd}", _
                                        entryno.ToString.PadLeft(5, "0"), _
                                        Date.Parse(rw("payment_date")), _
                                        Date.Parse(rw("payment_date")), _
                                        jrndesc, _
                                        Date.Parse(rw("payment_date"))))


                            sw.WriteLine(String.Format("""2"",""666666"",{0},{1},""{2}"",-{3},""{4}"",""{5}"",{6:yyyyMMdd},""GL"",""OR"",""{7}""", _
                                                            entryno.ToString.PadLeft(5, "0"), _
                                                            batchId.ToString.PadLeft(10, "0"), _
                                                            acctID, _
                                                            Decimal.Parse(rw("paid_amount")), _
                                                            rw("or_number").ToString, _
                                                            rw("byrcode").ToString.Trim & "-" & rw("byrname").ToString.Trim, _
                                                            Date.Parse(rw("payment_date")), _
                                                            itemDesc))

                            batchId += 20

                            sw.WriteLine(String.Format("""2"",""666666"",{0},{1},""{2}"",{3},""{4}"",""{5}"",{6:yyyyMMdd},""GL"",""OR"",""{7}""", _
                                                                                       entryno.ToString.PadLeft(5, "0"), _
                                                                                       batchId.ToString.PadLeft(10, "0"), _
                                                                                       "1110011" & ProjectID & costCenter, _
                                                                                       Decimal.Parse(rw("paid_amount")), _
                                                                                       rw("or_number").ToString, _
                                                                                       rw("byrcode").ToString.Trim & "-" & rw("byrname").ToString.Trim, _
                                                                                       Date.Parse(rw("payment_date")), _
                                                                                       itemDesc))

                            entryno += 1
                        Next

                        Dim depDetails As New DepositDetailExport

                        With depDetails
                            .TemporaryFolderPath = TemporaryFolderPath

                            .CntItem = cnt

                            .BankCode = dr("bankcode").ToString.Split(",")(0)
                            .BankFinanceCode = dr("bankcode").ToString.Split(",")(1)
                            .DateRemit = Date.Parse(dr("deposit_date"))
                            .DepositID = dr("deposit_id").ToString.PadLeft(6, "0")
                            Using dv As New DataView(dtDetails)
                                dv.RowFilter = "deposit_id = " & depositID
                                dv.Sort = "or_number"
                                .DepositDetailsTables = dv.ToTable()
                            End Using

                            .Export()
                        End With

                        cnt += 1
                    Next



                End Using
            End Using

            ''Compress Files
            CompressFiles()
            ''Delete Temporary Directory
            IO.Directory.Delete(TemporaryFolderPath, True)
        End Sub

        Private Function GetDepositHeader() As DataTable
            Using params As New OraParameter
                If String.IsNullOrEmpty(DepositIDend) Then
                    params.AddItem("depositid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositHeader, params.GetParameterCollection)
                Else
                    params.AddItem("startid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)
                    params.AddItem("endid", DepositIDend, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositHeaderByRange, params.GetParameterCollection)
                End If

            End Using
        End Function

        Private Function GetDepositDetails() As DataTable
            Using params As New OraParameter
                If String.IsNullOrEmpty(DepositIDend) Then
                    params.AddItem(":depositid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetACDepositDetails, params.GetParameterCollection)
                Else
                    params.AddItem("startid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)
                    params.AddItem("endid", DepositIDend, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetACDepositDetailsbyRange, params.GetParameterCollection)
                End If

            End Using
        End Function

        Private Function GetDepositSummary() As DataTable
            Using params As New OraParameter
                If String.IsNullOrEmpty(DepositIDend) Then
                    params.AddItem(":depositid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositSummary, params.GetParameterCollection)
                Else
                    params.AddItem("startid", DepositIDStart, Oracle.DataAccess.Client.OracleDbType.Int64)
                    params.AddItem("endid", DepositIDend, Oracle.DataAccess.Client.OracleDbType.Int64)

                    Return OraDBHelper2.GetResultSet(SelectStatement.GetDepositSummaryByRange, params.GetParameterCollection)
                End If

            End Using
        End Function

    End Class

    Public Class DepositDetailExport
        Inherits DataExport

        Private _cntItem As String
        Public Property CntItem() As String
            Get
                Return _cntItem
            End Get
            Set(ByVal value As String)
                _cntItem = value
            End Set
        End Property

        Private _dateRemit As Date
        Public Property DateRemit() As Date
            Get
                Return _dateRemit
            End Get
            Set(ByVal value As Date)
                _dateRemit = value
            End Set
        End Property

        Public ReadOnly Property TextRemit() As String
            Get
                Return ProjectCodeName & "-" & DepositID & "-" & DateRemit.ToString("yyyyMMdd") & "-" & BankCode
            End Get
        End Property


        Public ReadOnly Property TextRemitRef() As String
            Get
                Return ProjectCodeName & "-" & DepositID
            End Get
        End Property


        Private _amtRemit As Decimal
        Public Property AmtRemit() As Decimal
            Get
                Return _amtRemit
            End Get
            Set(ByVal value As Decimal)
                _amtRemit = value
            End Set
        End Property


        Private _bankCode As String
        Public Property BankCode() As String
            Get
                Return _bankCode
            End Get
            Set(ByVal value As String)
                _bankCode = value
            End Set
        End Property

        Private _bankFinanceCode As String
        Public Property BankFinanceCode() As String
            Get
                Return _bankFinanceCode
            End Get
            Set(ByVal value As String)
                _bankFinanceCode = value
            End Set
        End Property


        Private _depositID As String
        Public Property DepositID() As String
            Get
                Return _depositID
            End Get
            Set(ByVal value As String)
                _depositID = value
            End Set
        End Property

        Private _depositDetailsTables As DataTable
        Public Property DepositDetailsTables() As DataTable
            Get
                Return _depositDetailsTables
            End Get
            Set(ByVal value As DataTable)
                _depositDetailsTables = value
            End Set
        End Property

        Public Overrides ReadOnly Property Filename() As String
            Get
                Return ProjectCodeName & "-" & DepositID.ToString.PadLeft(6, "0") & "-" & DateRemit.ToString("yyyyMMdd") & "-" & BankCode
            End Get
        End Property

        '"RECTYPE","CODEPYMTYP","CNTBTCH","CNTITEM","IDRMIT","IDCUST","DATERMIT","TEXTRMIT","TXTRMITREF","AMTRMIT","RMITTYPE","DOCTYPE","TEXTPAYOR","IDBANK","CODETAXGRP","IDGRP"
        Public Const Header1 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPYMTYP" & """" & "," & _
                                         """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                                         """" & "IDRMIT" & """" & "," & """" & "IDCUST" & """" & "," & _
                                         """" & "DATERMIT" & """" & "," & """" & "TEXTRMIT" & """" & "," & _
                                         """" & "TXTRMITREF" & """" & "," & """" & "AMTRMIT" & """" & "," & _
                                         """" & "RMITTYPE" & """" & "," & """" & "DOCTYPE" & """" & "," & _
                                         """" & "TEXTPAYOR" & """" & "," & """" & "IDBANK" & """" & "," & _
                                         """" & "CODETAXGRP" & """"

        '"RECTYPE","CODEPAYM","CNTBTCH","CNTITEM","CNTLINE"
        Public Const Header2 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPAYM" & """" & "," & _
                                        """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                                        """" & "CNTLINE" & """"

        '"RECTYPE","CODEPAYM","CNTBTCH","CNTITEM","CNTLINE","IDDISTCODE","GLREF","AMTDISTTC","GLDESC"
        Public Const Header3 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPAYM" & """" & "," & _
                                       """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                                       """" & "CNTLINE" & """" & "," & """" & "IDACCT" & """" & "," & _
                                       """" & "GLREF" & """" & "," & """" & "GLDESC" & """" & "," & _
                                       """" & "AMTDISTTC" & """"

        '"RECTYPE","CODEPAYM","CNTBTCH","CNTITEM","CNTLINE"
        Public Const Header4 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPAYM" & """" & "," & _
                                      """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                                      """" & "CNTLINE" & """"


        '"RECTYPE","CODEPAYM","CNTBTCH","CNTITEM","CNTLINE","CNTSEQ"
        Public Const Header5 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPAYM" & """" & "," & _
                                      """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                                      """" & "CNTLINE" & """" & "," & """" & "CNTSEQ" & """"

        '"RECTYPE","CODEPYMTYP","CNTBTCH","CNTITEM","OPTFIELD"
        Public Const Header6 As String = """" & "RECTYPE" & """" & "," & """" & "CODEPYMTYP" & """" & "," & _
                               """" & "CNTBTCH" & """" & "," & """" & "CNTITEM" & """" & "," & _
                               """" & "OPTFIELD" & """"

        Public Overrides Sub Export()

            Using sw As New StreamWriter(TemporaryFolderPath & Filename & ".csv")
                sw.WriteLine(Header1)
                sw.WriteLine(Header2)
                sw.WriteLine(Header3)
                sw.WriteLine(Header4)
                sw.WriteLine(Header5)
                sw.WriteLine(Header6)
                Using dtDetails As DataTable = DepositDetailsTables()
                    AmtRemit = Decimal.Parse(dtDetails.Compute("SUM(paid_amount)", ""))
                    sw.WriteLine(String.Format("""1"",""CA"",6666,{0},,""CASH1"",{1:yyyyMMdd},""{2}"",""{3}"",{4},5,1,""CASH"",""{5}"",""NV{6}00""", _
                                                                  CntItem.ToString.PadLeft(5, "0"), _
                                                                  DateRemit, _
                                                                  TextRemit, _
                                                                  TextRemitRef, _
                                                                  AmtRemit, _
                                                                  BankCode, _
                                                                  GlobalReference.ProjectParameters.SiteFinanceCode))

                    Dim batchId As Decimal = 20
                    For Each rw As DataRow In DepositDetailsTables.Rows


                        sw.WriteLine(String.Format("""3"",""CA"",6666,{0},{1},""{2}"",""{3}"",""{4}"",{5}", _
                                                                                         CntItem.ToString.PadLeft(5, "0"), _
                                                                                         batchId, _
                                                                                         BankFinanceCode, _
                                                                                         rw("byrcode").ToString.Trim & "-" & rw("byrname").ToString.Replace(",", "").Trim, _
                                                                                         rw("or_number").ToString.PadLeft(8, "0"), _
                                                                                         Decimal.Parse(rw("paid_amount"))))
                        batchId += 20


                        Dim costCenter As String = rw("feeid").ToString.Split("x")(1)

                        Dim dlCode As String
                        If BankFinanceCode.Length = 13 Then
                            dlCode = BankFinanceCode.Substring(0, 7) & ProjectID & BankFinanceCode.Substring(10, 3)
                        Else
                            dlCode = BankFinanceCode.Substring(0, 7) & ProjectID & costCenter & BankFinanceCode.Substring(13, 3)
                        End If



                        sw.WriteLine(String.Format("""3"",""CA"",6666,{0},{1},""{2}"",""{3}"",""{4}"",-{5}", _
                                                                 CntItem.ToString.PadLeft(5, "0"), _
                                                                 batchId, _
                                                                 dlCode, _
                                                                 rw("byrcode").ToString.Trim & "-" & rw("byrname").ToString.Replace(",", "").Trim, _
                                                                 rw("or_number").ToString.PadLeft(8, "0"), _
                                                                 Decimal.Parse(rw("paid_amount"))))
                        batchId += 20



                        sw.WriteLine(String.Format("""3"",""CA"",6666,{0},{1},""{2}"",""{3}"",""{4}"",{5}", _
                                                                 CntItem.ToString.PadLeft(5, "0"), _
                                                                 batchId, _
                                                                 "1110011" & ProjectID & costCenter, _
                                                                 rw("byrcode").ToString.Trim & "-" & rw("byrname").ToString.Replace(",", "").Trim, _
                                                                 rw("or_number").ToString.PadLeft(8, "0"), _
                                                                 Decimal.Parse(rw("paid_amount"))))

                        batchId += 20
                    Next
                End Using
            End Using

        End Sub

    End Class

    Public Class InvoicesExport
        Inherits DataExport

        Private _billStartDate As Date
        Public Property BillStartDate() As Date
            Get
                Return _billStartDate
            End Get
            Set(ByVal value As Date)
                _billStartDate = value
            End Set
        End Property

        Private _billEndDate As Date
        Public ReadOnly Property BillEndDate() As Date
            Get
                Return New Date(BillStartDate.Year, BillStartDate.Month, Date.DaysInMonth(BillStartDate.Year, BillStartDate.Month))
            End Get
        End Property

        Public Overrides ReadOnly Property Filename() As String
            Get
                Return ProjectCodeName & "_Invoices_" & BillStartDate.ToString("yyyyMMdd") & "-" & BillEndDate.ToString("yyyyMMdd") & ".csv"
            End Get
        End Property

        Public Const Header1 As String = """" & "RECTYPE" & """" & "," & """" & "BATCHID" & """" & "," & _
                                 """" & "BTCHENTRY" & """" & "," & """" & "SRCELEDGER" & """" & "," & _
                                 """" & "SRCETYPE" & """" & "," & """" & "JRNLDESC" & """" & "," & _
                                 """" & "DATEENTRY" & """"

        Public Const Header2 As String = """" & "RECTYPE" & """" & "," & """" & "BATCHNBR" & """" & "," & _
                                         """" & "JOURNALID" & """" & "," & """" & "TRANSNBR" & """" & "," & _
                                         """" & "ACCTID" & """" & "," & """" & "TRANSAMT" & """" & "," & _
                                         """" & "TRANSDESC" & """" & "," & """" & "TRANSREF" & """" & "," & _
                                         """" & "TRANSDATE" & """" & "," & """" & "SRCELDGR" & """" & "," & _
                                         """" & "SRCETYPE" & """"

        Public Const Header3 As String = """" & "RECTYPE" & """" & "," & """" & "BATCHNBR" & """" & "," & _
                                         """" & "JOURNALID" & """" & "," & """" & "TRANSNBR" & """" & "," & _
                                         """" & "OPTFIELD" & """"
        <Obsolete("Used the Export instead", True)> _
        Public Sub OldExport()
            Using sw As New StreamWriter(FullExportPathName)
                sw.WriteLine(Header1)
                sw.WriteLine(Header2)
                sw.WriteLine(Header3)

                Dim ctr As Integer = 1
                For Each dr As DataRow In GetInvoices.Rows

                    Dim receivable As Decimal = Decimal.Parse(dr("amount"))
                    Dim outputTax As Decimal = Decimal.Round(receivable / 1.12 * 0.12, 2, MidpointRounding.AwayFromZero)
                    Dim income As Decimal = Decimal.Round(receivable - outputTax, 2, MidpointRounding.AwayFromZero)



                    sw.WriteLine(FmtStr("1") & "," & FmtStr("000001") & "," & FmtStr(ctr.ToString.PadLeft(5, "0")) & "," _
                           & FmtStr("AR") & "," & FmtStr("BS") & "," & FmtStr("WATER BILL") _
                           & "," & Date.Parse(dr("bill_date")).ToString("yyyyMMdd"))

                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr(ctr.ToString.PadLeft(5, "0")) & "," _
                           & FmtStr("0000000020") & "," & FmtStr("1130027" & ProjectID & "002") & "," & receivable.ToString("#.##") & "," _
                           & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                           & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                           & FmtStr("AR") & "," & FmtStr("BS"))


                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr(ctr.ToString.PadLeft(5, "0")) & "," _
                            & FmtStr("0000000040") & "," & FmtStr("2140037000") & ",-" & outputTax.ToString("#.##") & "," _
                            & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                            & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                            & FmtStr("AR") & "," & FmtStr("BS"))


                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr(ctr.ToString.PadLeft(5, "0")) & "," _
                             & FmtStr("0000000060") & "," & FmtStr("4010050" & ProjectID & "002") & ",-" & income.ToString("#.##") & "," _
                             & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                             & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                             & FmtStr("AR") & "," & FmtStr("BS"))
                    ctr += 1
                Next
            End Using
        End Sub

        Public Overrides Sub Export()
            Using sw As New StreamWriter(FullExportPathName)
                sw.WriteLine(Header1)
                sw.WriteLine(Header2)
                sw.WriteLine(Header3)

                Dim ctr As Integer = 1
                Dim transnbr As Long = 20

                Dim printheader As Boolean = True

                For Each dr As DataRow In GetInvoices.Rows


                    Dim receivable As Decimal = Decimal.Parse(dr("amount"))
                    Dim outputTax As Decimal = Decimal.Round(receivable / 1.12 * 0.12, 2, MidpointRounding.AwayFromZero)
                    Dim income As Decimal = Decimal.Round(receivable - outputTax, 2, MidpointRounding.AwayFromZero)


                    If printheader Then
                        sw.WriteLine(FmtStr("1") & "," & FmtStr("000001") & "," & FmtStr(ctr.ToString.PadLeft(5, "0")) & "," _
                                              & FmtStr("GL") & "," & FmtStr("17") & "," & FmtStr("WATER BILL") _
                                              & "," & Date.Parse(dr("bill_date")).ToString("yyyyMMdd"))
                        printheader = False
                    End If


                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr("00001") & "," _
                           & FmtStr(transnbr.ToString.PadLeft(10, "0")) & "," & FmtStr("1130027" & ProjectID & "002") & "," & receivable.ToString("#.##") & "," _
                           & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                           & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                           & FmtStr("GL") & "," & FmtStr("17"))
                    transnbr += 20

                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr("00001") & "," _
                            & FmtStr(transnbr.ToString.PadLeft(10, "0")) & "," & FmtStr("2140037000") & ",-" & outputTax.ToString("#.##") & "," _
                            & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                            & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                            & FmtStr("GL") & "," & FmtStr("17"))
                    transnbr += 20

                    sw.WriteLine(FmtStr(2) & "," & FmtStr("000001") & "," & FmtStr("00001") & "," _
                             & FmtStr(transnbr.ToString.PadLeft(10, "0")) & "," & FmtStr("4010050" & ProjectID & "002") & ",-" & income.ToString("#.##") & "," _
                             & FmtStr(dr("bill_id").ToString) & "," & FmtStr(dr("account_name").ToString) & "," _
                             & Date.Parse(dr("bill_date")).ToString("yyyyMMdd") & "," _
                             & FmtStr("GL") & "," & FmtStr("17"))
                    transnbr += 20
                    ctr += 1
                Next
            End Using
        End Sub
        Private Function GetInvoices() As DataTable
            Using params As New OraParameter
                params.AddItem("startdate", BillStartDate, OracleDbType.Date)
                params.AddItem(":enddate", BillEndDate, OracleDbType.Date)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetInvoicesMonthPeriod, params.GetParameterCollection)
            End Using
        End Function

    End Class

End Namespace
