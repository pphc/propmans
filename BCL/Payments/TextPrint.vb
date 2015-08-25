'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 03-11-2010
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports am = AmountInWords
Imports BCL.Entities
Imports BCL.ReferenceList
Imports DALC
Imports BCL.Payments

Public Class TextPrint
    ' Inherits all the functionality of a PrintDocument
    Inherits Printing.PrintDocument
    ' Private variables to hold default font and text
    Private fntPrintFont As Font
    Private strText As String
    Public Sub New(ByVal text As String)
        ' Sets the file stream
        MyBase.New()
        strText = text
    End Sub
    Public Property Text() As String
        Get
            Return strText
        End Get
        Set(ByVal Value As String)
            strText = Value
        End Set
    End Property
    Protected Overrides Sub OnBeginPrint(ByVal ev _
                                As Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(ev)
        ' Sets the default font
        If fntPrintFont Is Nothing Then
            fntPrintFont = New Font("Times New Roman", 12)
        End If
    End Sub
    Public Property Font() As Font
        ' Allows the user to override the default font
        Get
            Return fntPrintFont
        End Get
        Set(ByVal Value As Font)
            fntPrintFont = Value
        End Set
    End Property
    Protected Overrides Sub OnPrintPage(ByVal ev _
       As Printing.PrintPageEventArgs)
        ' Provides the print logic for our document

        ' Run base code
        MyBase.OnPrintPage(ev)
        ' Variables
        Static intCurrentChar As Integer
        Dim intPrintAreaHeight, intPrintAreaWidth, _
            intMarginLeft, intMarginTop As Integer
        ' Set printing area boundaries and margin coordinates
        With MyBase.DefaultPageSettings
            intPrintAreaHeight = .PaperSize.Height - _
                               .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - _
                              .Margins.Left - .Margins.Right
            intMarginLeft = .Margins.Left 'X
            intMarginTop = .Margins.Top   'Y
        End With
        ' If Landscape set, swap printing height/width
        If MyBase.DefaultPageSettings.Landscape Then
            Dim intTemp As Integer
            intTemp = intPrintAreaHeight
            intPrintAreaHeight = intPrintAreaWidth
            intPrintAreaWidth = intTemp
        End If
        ' Calculate total number of lines
        Dim intLineCount As Int32 = _
                CInt(intPrintAreaHeight / Font.Height)
        ' Initialise rectangle printing area
        Dim rectPrintingArea As New RectangleF(intMarginLeft, _
            intMarginTop, intPrintAreaWidth, intPrintAreaHeight)
        ' Initialise StringFormat class, for text layout
        Using objSF As New StringFormat(StringFormatFlags.LineLimit)
            ' Figure out how many lines will fit into rectangle
            Dim intLinesFilled As Int32
            Dim intCharsFitted As Int32
            ev.Graphics.MeasureString(Mid(strText, UpgradeZeros(intCurrentChar)), Font, New SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, intCharsFitted, intLinesFilled)
            ' Print the text to the page
            ev.Graphics.DrawString(Mid(strText, UpgradeZeros(intCurrentChar)), Font, Brushes.Black, rectPrintingArea, objSF)
            ' Increase current char count
            intCurrentChar += intCharsFitted
            ' Check whether we need to print more
            If intCurrentChar < strText.Length Then
                ev.HasMorePages = True
            Else
                ev.HasMorePages = False
                intCurrentChar = 0
            End If
        End Using
    End Sub
    Public Function UpgradeZeros(ByVal input As Integer) As Integer
        ' Upgrades all zeros to ones
        ' - used as opposed to defunct IIF or messy If statements
        If input = 0 Then
            Return 1
        Else
            Return input
        End If
    End Function
End Class

Public Class ReceiptDoc
    Public Enum ReceiptType
        VAT
        NONVAT
    End Enum
    Public Enum PayType
        Cash
        Check
    End Enum

    Private _tempName As String = "PrintMe.txt"

    Private _tempFolderPath As String
    Public Property TempFolderPath() As String
        Private Get
            Return _tempFolderPath
        End Get
        Set(ByVal value As String)
            _tempFolderPath = value
        End Set
    End Property

    Public ReadOnly Property PrintPath() As String
        Get
            Return _tempFolderPath & _tempName
        End Get
    End Property

#Region " Class Properties "

    Private _feeCompany As String
    Public Property FeeCompany() As String
        Get
            Return _feeCompany
        End Get
        Set(ByVal value As String)
            _feeCompany = value
        End Set
    End Property


    Private _recType As ReceiptType

    Public Property RecType() As ReceiptType
        Get
            Return _recType
        End Get
        Set(ByVal value As ReceiptType)
            _recType = value
        End Set
    End Property
    Private _receiptNumber As String
    Public Property ReceiptNumber() As String
        Get
            Return _receiptNumber
        End Get
        Set(ByVal value As String)
            _receiptNumber = value
        End Set
    End Property

    Private _receiptDate As Date
    Public Property ReceiptDate() As Date
        Get
            Return _receiptDate
        End Get
        Set(ByVal value As Date)
            _receiptDate = value
        End Set
    End Property


    Private _receiptAmount As Decimal
    Public Property ReceiptAmount() As Decimal
        Get
            Return _receiptAmount
        End Get
        Set(ByVal value As Decimal)
            _receiptAmount = value
        End Set
    End Property


    Public ReadOnly Property AmountInWords() As String
        Get
            Dim amt As New am.AmountInWords
            Return amt.GetInWords(ReceiptAmount)
        End Get
    End Property

    Private _paymentType As PayType
    Public Property PaymentType() As PayType
        Get
            Return _paymentType
        End Get
        Set(ByVal value As PayType)
            _paymentType = value
        End Set
    End Property


    Private _checkNumber As String
    Public Property CheckNumber() As String
        Get
            Return _checkNumber
        End Get
        Set(ByVal value As String)
            _checkNumber = value
        End Set
    End Property

    Private _checkDate As Date
    Public Property CheckDate() As Date
        Get
            Return _checkDate
        End Get
        Set(ByVal value As Date)
            _checkDate = value
        End Set
    End Property

    Private _checkBank As String
    Public Property CheckBank() As String
        Get
            Return _checkBank
        End Get
        Set(ByVal value As String)
            _checkBank = value
        End Set
    End Property

    Private _particulars As List(Of String)
    Public Property Particulars() As List(Of String)
        Get
            Return _particulars
        End Get
        Set(ByVal value As List(Of String))
            _particulars = value
        End Set
    End Property


    Private _customerName As String
    Public Property CustomerName() As String
        Get
            Return _customerName
        End Get
        Set(ByVal value As String)
            _customerName = value
        End Set
    End Property

    Private _unitNumber As String
    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(ByVal value As String)
            _unitNumber = value
        End Set
    End Property

    Private _projectSiteName As String
    Public Property ProjectSiteName() As String
        Get
            Return _projectSiteName
        End Get
        Set(ByVal value As String)
            _projectSiteName = value
        End Set
    End Property



    Public ReadOnly Property Vatable() As Boolean
        Get
            If _recType = ReceiptType.VAT Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    Private _vatRate As Decimal = 12
    Public Property VatRate() As Decimal
        Get
            Return _vatRate
        End Get
        Set(ByVal value As Decimal)
            _vatRate = value
        End Set
    End Property

    Public ReadOnly Property TotalSale() As Decimal
        Get
            Return ReceiptAmount / (1 + (VatRate / 100))
        End Get
    End Property

    'Private _userID As String
    Public ReadOnly Property UserID() As String
        Get
            Return OraConnection.Instance.UserID
        End Get
    End Property

#End Region


    Public Sub Print()
        If RecType = ReceiptType.VAT Then
            PrintVatReceipt()
        Else
            PrintNonvatReceipt()
        End If
    End Sub
    'for VAT Receipt
    Private Sub PrintVatReceipt()
        Try
            Using sw As New StreamWriter(PrintPath, False)
                With sw
                    .WriteLine(ReceiptNumber.PadLeft(80, " "))
                    .WriteLine()
                    .WriteLine()
                    .WriteLine("      " & CustomerName)
                    .WriteLine()
                    .WriteLine()
                    .WriteLine("      " & UnitNumber & " [ " & ProjectSiteName & " ]")
                    .WriteLine(_receiptDate.ToString("dd-MMM-yyyy").PadLeft(75, " "))
                    .WriteLine()
                    .WriteLine()
                    .WriteLine("  " & AmountInWords)
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()

                    Dim paytypeprinted As Boolean = False

                    For Each item As String In Particulars
                        If Not paytypeprinted Then
                            Dim paytypedesc As String
                            If PaymentType = PayType.Cash Then
                                paytypedesc = "CASH"
                            Else
                                paytypedesc = "CHECK NO:" & CheckNumber & " | " & CheckBank & " " & CheckDate.ToShortDateString
                            End If
                            .WriteLine(item.PadRight(50, " ") & paytypedesc)
                        Else
                            .WriteLine(item)
                        End If

                        paytypeprinted = True
                    Next

                    Dim linetoPRint = 5 - Particulars.Count
                    While linetoPRint <> 0
                        .WriteLine()
                        linetoPRint -= 1
                    End While


                    If Vatable Then
                        .WriteLine(ReceiptAmount.ToString("#,###.00").PadLeft(15, "*").PadLeft(85, " ") & " VATSALE")
                        .WriteLine()
                        .WriteLine()
                        .WriteLine()
                        .WriteLine(TotalSale.ToString("#,###.00").PadLeft(15, "*").PadLeft(85, " ") & " TOTALSALE")
                        .WriteLine((ReceiptAmount - TotalSale).ToString("#,###.00").PadLeft(17, "*").PadLeft(85, " ") & " VAT")
                        .WriteLine(ReceiptAmount.ToString("#,###.00").PadLeft(15, "*").PadLeft(85, " "))
                    Else
                        .WriteLine()
                        .WriteLine(ReceiptAmount.ToString("#,###.00").PadLeft(15, "*").PadLeft(85, " ") & " VATEXMPT")
                        .WriteLine()
                        .WriteLine()
                        .WriteLine()
                        .WriteLine(ReceiptAmount.ToString("#,###.00").PadLeft(15, "*").PadLeft(85, " ") & " TOTALAMT")
                    End If

                    .WriteLine()
                    .WriteLine()
                    .WriteLine(UserID & " " & Now.ToString("MM/dd/yy HH:mm"))

                End With

            End Using

            Using sr As New StreamReader(PrintPath)
                Dim strOutput As String = sr.ReadToEnd()

                Dim tp As New TextPrint(strOutput)

                tp.Font = New Font("Lucida Console", 10)
                tp.DefaultPageSettings.PaperSize = New PaperSize("HalfShort", 850, 600)

                tp.DefaultPageSettings.Margins.Top = 65
                tp.DefaultPageSettings.Margins.Left = 10
                tp.DefaultPageSettings.Margins.Right = 0

                tp.DocumentName = "Official Receipt"

                tp.Print()
            End Using


        Catch ex As Exception
            Throw ex
        Finally
            FileSystem.Kill(PrintPath)
        End Try
    End Sub

    'for NONVAT Receipt
    Private Sub PrintNonvatReceipt()
        Try
            Using sw As New StreamWriter(PrintPath, False)
                With sw
                    .WriteLine("                                               " & ReceiptNumber)
                    .WriteLine()
                    .WriteLine()
                    .WriteLine("         " & CustomerName)
                    .WriteLine("")
                    .WriteLine("         " & UnitNumber & " [ " & ProjectSiteName & " ]")
                    .WriteLine("                                                                 " & _receiptDate.ToString("MMMM dd, yyyy"))
                    .WriteLine()
                    .WriteLine()
                    .WriteLine("   " & AmountInWords)
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    If PaymentType = PayType.Cash Then
                        .WriteLine("                                                             CASH" & ReceiptAmount.ToString("#,###.00").PadLeft(21, " "))
                    End If

                    For Each item As String In Particulars
                        .WriteLine(item)
                    Next

                    If PaymentType = PayType.Check Then
                        .WriteLine("                                                  CHECK NO:")
                        .WriteLine("                                                   " & CheckNumber.PadRight(15, " ") & ReceiptAmount.ToString("#,###.00").PadLeft(20, " "))
                        .WriteLine("                                                   " & CheckBank & " " & CheckDate.ToShortDateString)
                    End If

                    .WriteLine("                                                             EXEMPT" & ReceiptAmount.ToString("#,###.00").PadLeft(17, " "))
                    .WriteLine("                                                         ZERO RATED ")
                    .WriteLine("                                                                VAT ")
                    .WriteLine("                                                                CWT ")
                    .WriteLine()
                    .WriteLine()
                    .WriteLine(UserID & " " & Now.ToString("MM/dd/yy HH:mm"))

                End With

            End Using

            Using sr As New StreamReader(PrintPath)
                Dim strOutput As String = sr.ReadToEnd()

                Using tp As New TextPrint(strOutput)
                    tp.Font = New Font("Lucida Console", 10)
                    tp.DefaultPageSettings.PaperSize = New PaperSize("HalfShort", 850, 550)
                    tp.DefaultPageSettings.Margins.Top = 80
                    tp.DefaultPageSettings.Margins.Left = 10
                    tp.DefaultPageSettings.Margins.Right = 0
                    tp.DocumentName = "Official Receipt"
                    tp.Print()
                End Using
            End Using


        Catch ex As Exception
            Throw ex
        Finally
            FileSystem.Kill(PrintPath)
        End Try
    End Sub


End Class

Public MustInherit Class ReceiptParticulars

    Private __items As New List(Of String) ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Protected Property _items() As List(Of String)
        Get
            Return __items
        End Get
        Set(ByVal Value As List(Of String))
            __items = Value
        End Set
    End Property

    Private _feeName As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Protected Property FeeTypeName() As String
        Get
            Return _feeName
        End Get
        Set(ByVal Value As String)
            _feeName = Value
        End Set
    End Property
    Private _feeID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Protected Property FeeID() As String
        Get
            Return _feeID
        End Get
        Set(ByVal Value As String)
            _feeID = Value
        End Set
    End Property
    Private _remarks As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal Value As String)
            _remarks = Value
        End Set
    End Property


    Private _discountrate As Decimal
    Public Property Discountrate() As Decimal
        Get
            Return _discountrate
        End Get
        Set(ByVal value As Decimal)
            _discountrate = value
        End Set
    End Property

    Public ReadOnly Property DiscountAmount() As Decimal
        Get
            If Discountrate > 0 Then
                Return OriginalAmount * (Discountrate / 100)
            Else
                Return 0
            End If

        End Get
    End Property

    Private _amountpaid As Decimal
    Public Property AmountPaid() As Decimal
        Get
            Return _amountpaid
        End Get
        Protected Set(ByVal value As Decimal)
            _amountpaid = value
        End Set
    End Property

    Public ReadOnly Property OriginalAmount() As Decimal
        Get
            Return AmountPaid / ((100 - Discountrate) / 100)
        End Get
    End Property

    Private _feeTYpe As BillType
    Protected ReadOnly Property FeeType() As BillType
        Get
            Return _feeTYpe
        End Get
    End Property


    Public ReadOnly Property Items() As List(Of String)
        Get
            Return _items
        End Get
    End Property

    Public Sub New(ByVal feeID As String)
        Using params As New OraParameter
            params.AddItem(":feeID", feeID, Oracle.DataAccess.Client.OracleDbType.Int32)

            If OraDBHelper.SqlExecuteScalar(Statements.SelectStatement.GetFeeBillingTypeByFeeID, params.GetParameterCollection).ToString = "I" Then
                _feeTYpe = BillType.OnDemand
            Else
                _feeTYpe = BillType.SOAType
            End If
        End Using
    End Sub

    Public Sub New() '

    End Sub

    MustOverride Sub Process()

End Class

Public Class AdvanceParticulars
    Inherits ReceiptParticulars

    Public Sub New(ByVal feeName As String, ByVal amountPaid As Decimal, Optional ByVal discountRate As Decimal = 0)
        FeeTypeName = feeName
        Me.AmountPaid = amountPaid
        Me.Discountrate = discountRate
    End Sub

    Public Overrides Sub Process()
        If Discountrate > 0 Then
            _items.Add(FeeTypeName & " ADVANCE - " & OriginalAmount.ToString("#,###.00"))
            _items.Add("   Less " & Discountrate & "% Discount - (" & DiscountAmount.ToString("#,###.00") & ")")
        Else
            _items.Add(FeeTypeName & " ADVANCE - " & AmountPaid.ToString("#,###.00"))
        End If

        If Not String.IsNullOrEmpty(Remarks) Then
            _items.Add("  " & Remarks)
        End If
    End Sub
End Class

Public Class RegularParticulars
    Inherits ReceiptParticulars
    Private _invoices As List(Of PaymentBilling)

    Public Sub New(ByVal feeID As String, ByVal feeName As String, ByVal invoices As List(Of PaymentBilling))
        MyBase.New(feeID)
        FeeTypeName = feeName
        _invoices = invoices
    End Sub

    Public Overrides Sub Process()

        If _invoices.Count = 1 Then
            With _invoices(0)
                If FeeType = BillType.OnDemand Then
                    If .Balance = .Appliedamount Then
                        'Full payment
                        _items.Add(FeeTypeName)
                    Else
                        'Partial payment
                        _items.Add(FeeTypeName)
                        _items.Add(" PARTIAL PAYMENT of Php " & .Appliedamount.ToString("#,###.00"))
                        _items.Add(" BALANCE: Php " & .Newbalance.ToString("#,###.00"))
                    End If
                Else
                    Dim principalAmt As Decimal
                    Dim penalty As Decimal = GetPenaltyAmt(principalAmt)

                    If .Balance = .Appliedamount Then
                        'Full payment
                        If penalty = 0 Then
                            _items.Add(FeeTypeName & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                        Else
                            If principalAmt = 0 Then
                                _items.Add(FeeTypeName & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                            Else
                                _items.Add(FeeTypeName & " " & .BillPeriodDate.Value.ToString("MMM \'yy") & " - " & principalAmt.ToString("#,###.00"))
                            End If

                            _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                        End If

                    Else
                        'Partial payment
                        If penalty = 0 Then
                            _items.Add(FeeTypeName & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                            _items.Add(" PARTIAL PAYMENT of Php " & .Appliedamount.ToString("#,###.00"))
                            _items.Add(" BALANCE: Php " & .Newbalance.ToString("#,###.00"))
                        Else
                            If principalAmt = 0 Then
                                ' _items.Add(FeeName & " " & .billPeriodDate.Value.ToString("MMM \'yy"))
                            Else
                                _items.Add(FeeTypeName & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                                _items.Add(" PARTIAL PAYMENT of Php " & principalAmt.ToString("#,###.00"))
                                _items.Add(" BALANCE: Php " & GetPartialBalance.ToString("#,###.00"))
                            End If
                            _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                        End If

                    End If
                End If
            End With

        Else
            If FeeType = BillType.OnDemand Then
                If HaspartialPayment() Then
                    'Invoices w/ some partial invoice payment
                    _items.Add(FeeTypeName)
                    _items.Add("  PARTIAL PAYMENT of Php " & GetPartialInvoicePayment().ToString("#,###.00"))
                    _items.Add("  BALANCE: Php " & GetPartialInvoiceBalance().ToString("#,###.00"))

                Else
                    'Invoices w/ full payment
                    _items.Add(FeeTypeName)
                End If
            Else
                Dim principalAmt As Decimal
                Dim penalty As Decimal = GetTotalPenaltyAmt(principalAmt)

                If penalty = 0 Then
                    If HaspartialPayment() Then
                        'Invoices w/ some partial invoice payment
                        _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & GetFullInvoicePayment().ToString("#,###.00"))
                        _items.Add(FeeTypeName & " " & GetStatementRange(GetPartialInvoiceDate))
                        _items.Add("  PARTIAL PAYMENT of Php " & GetPartialInvoicePayment().ToString("#,###.00"))
                        _items.Add("  BALANCE: Php " & GetPartialInvoiceBalance().ToString("#,###.00"))
                    Else
                        'Invoices w/ full payment
                        _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate))
                    End If
                Else
                    If HaspartialPayment() Then
                        'Invoices w/ some partial invoice payment
                        If principalAmt = 0 Then
                            _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate))
                        Else
                            _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & GetPenalizedFullInvoicePayment().ToString("#,###.00"))
                            Dim principal As Decimal = GetPenalizedPartialInvoicePayment()
                            If principal > 0 Then
                                _items.Add(FeeTypeName & " " & GetStatementRange(GetPartialInvoiceDate))
                                _items.Add("  PARTIAL PAYMENT of Php " & GetPenalizedPartialInvoicePayment().ToString("#,###.00"))
                                _items.Add("  BALANCE: Php " & GetPenalizedPartialInvoiceBalance().ToString("#,###.00"))
                            End If
                        End If
                        _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                    Else
                        'Invoices w/ full payment
                        If principalAmt = 0 Then
                            _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate))
                        Else
                            _items.Add(FeeTypeName & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & principalAmt.ToString("#,###.00"))
                        End If

                        _items.Add("Penalty - " & penalty.ToString("#,###.00"))

                    End If
                End If

            End If

        End If

        If Not String.IsNullOrEmpty(Remarks) Then
            _items.Add("  " & Remarks)
        End If
    End Sub

    Private Function HaspartialPayment() As Boolean

        Dim bhaspartial As Boolean = False

        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                bhaspartial = True
                Exit For
            End If
        Next

        Return bhaspartial
    End Function

    Private Function GetRegularInvoiceDate() As List(Of Date)
        Dim invoicesDate As New List(Of Date)
        For Each item As PaymentBilling In _invoices
            If item.Balance = item.Appliedamount Then
                invoicesDate.Add(item.BillPeriodDate.Value)
            End If
        Next

        Return invoicesDate
    End Function

    Private Function GetPartialInvoiceDate() As List(Of Date)
        Dim invoicesDate As New List(Of Date)
        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                invoicesDate.Add(item.BillPeriodDate.Value)
            End If
        Next

        Return invoicesDate
    End Function

    Private Function GetFullInvoicePayment() As Decimal
        Dim totalAmount As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance = item.Appliedamount Then
                totalAmount += item.Appliedamount
            End If
        Next
        Return totalAmount

    End Function

    Private Function GetPenalizedFullInvoicePayment() As Decimal
        Dim totalAmount As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance = item.Appliedamount Then
                With item
                    If .Balance = (.AmountDue + .Penalty) Then
                        If .Balance = .Appliedamount Then
                            totalAmount += .AmountDue
                        Else
                            If .Penalty >= .Appliedamount Then
                            Else
                                totalAmount += .Appliedamount - .Penalty
                            End If
                        End If
                    Else
                        Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                        If paidAmount < .Penalty Then
                            If .Penalty >= .Appliedamount Then
                            Else
                                totalAmount += .Appliedamount - (.Penalty - paidAmount)
                            End If
                        Else
                            totalAmount += .Appliedamount
                        End If
                    End If
                End With
            End If
        Next
        Return totalAmount

    End Function

    Private Function GetPartialInvoicePayment() As Decimal
        Dim totalAmount As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                totalAmount += item.Appliedamount
            End If
        Next
        Return totalAmount
    End Function

    Private Function GetPenalizedPartialInvoicePayment() As Decimal
        Dim totalAmount As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                With item
                    If .Balance = (.AmountDue + .Penalty) Then
                        If .Balance = .Appliedamount Then
                            totalAmount += .AmountDue
                        Else
                            If .Penalty >= .Appliedamount Then
                            Else
                                totalAmount += .Appliedamount - .Penalty
                            End If
                        End If
                    Else
                        Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                        If paidAmount < .Penalty Then
                            If .Penalty >= .Appliedamount Then
                            Else
                                totalAmount += .Appliedamount - (.Penalty - paidAmount)
                            End If
                        Else
                            totalAmount += .Appliedamount
                        End If
                    End If
                End With
            End If
        Next
        Return totalAmount
    End Function



    Private Function GetPartialInvoiceBalance() As Decimal
        Dim balance As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                balance += item.Balance - item.Appliedamount
            End If
        Next
        Return balance
    End Function

    Private Function GetPenalizedPartialInvoiceBalance() As Decimal
        Dim balance As Decimal

        For Each item As PaymentBilling In _invoices
            If item.Balance <> item.Appliedamount Then
                'balance += item.balance - item.appliedamount
                With item
                    If .Balance = (.AmountDue + .Penalty) Then
                        If .Balance = .Appliedamount Then
                            balance += .Balance - .AmountDue
                        Else
                            If .Penalty >= .Appliedamount Then
                            Else
                                balance += .AmountDue - (.Appliedamount - .Penalty)
                            End If
                        End If
                    Else
                        Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                        If paidAmount < .Penalty Then
                            If .Penalty >= .Appliedamount Then
                            Else
                                balance += .AmountDue - (.Appliedamount - .Penalty)
                            End If
                        Else
                            balance += .Balance - .Appliedamount
                        End If
                    End If
                End With
            End If
        Next
        Return balance
    End Function

    Private Function GetStatementRange(ByVal invoicesDate) As String
        Dim statementRange As String = String.Empty

        Dim minDate As Date
        Dim maxDate As Date


        invoicesDate.Sort()

        minDate = invoicesDate(0)
        maxDate = invoicesDate(invoicesDate.Count - 1)

        Dim periodRange As String = String.Empty
        Dim idx As Integer = 0
        Dim newRange As Boolean = False
        Dim rangeAppended As Boolean = False
        Dim rangeStarted As Boolean = False


        For Each currentDate As Date In invoicesDate
            If idx = invoicesDate.Count - 1 Then
                If newRange Then
                    periodRange &= currentDate.ToString(" MMM \'yy")
                    rangeAppended = True
                    rangeStarted = False
                    newRange = False
                Else
                    periodRange &= currentDate.ToString(" MMM \'yy")
                End If
            Else
                If DateDiff(DateInterval.Month, currentDate, Convert.ToDateTime(invoicesDate(idx + 1))) > 1 Then
                    If newRange Then
                        periodRange &= currentDate.ToString(" MMM \'yy")
                        rangeAppended = True
                        rangeStarted = False
                        newRange = False
                    Else
                        periodRange &= currentDate.ToString(" MMM \'yy")
                    End If

                    If idx <> invoicesDate.Count - 1 Then
                        periodRange &= ", "
                    End If
                Else
                    If Not rangeStarted Then
                        periodRange &= currentDate.ToString(" MMM-")
                        newRange = True
                        rangeStarted = True
                        rangeAppended = False
                    ElseIf idx = invoicesDate.Count - 1 Then
                        periodRange &= currentDate.ToString(" MMM \'yy")
                    End If

                End If
            End If
            idx += 1
        Next

        statementRange = periodRange & " (" & invoicesDate.Count & " mo.)"

        Return statementRange
    End Function

    Private Function GetPenaltyAmt(ByRef principal As Decimal) As Decimal
        Dim penalty As Decimal
        With _invoices(0)
            If .Balance = (.AmountDue + .Penalty) Then
                If .Balance = .Appliedamount Then
                    principal = .AmountDue
                    penalty = .Penalty
                Else
                    If .Penalty >= .Appliedamount Then
                        principal = 0
                        penalty = .Appliedamount
                    Else
                        principal = .Appliedamount - .Penalty
                        penalty = .Penalty
                    End If
                End If
            Else
                Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                If paidAmount < .Penalty Then
                    If .Penalty >= .Appliedamount Then
                        principal = 0
                        penalty = .Appliedamount
                    Else
                        principal = .Appliedamount - (.Penalty - paidAmount)
                        penalty = .Penalty - paidAmount
                    End If
                Else
                    principal = .Appliedamount
                    penalty = 0
                End If
            End If
        End With

        Return penalty
    End Function

    Private Function GetTotalPenaltyAmt(ByRef principal As Decimal) As Decimal
        Dim penalty As Decimal

        For Each item As PaymentBilling In _invoices
            With item
                If .Balance = (.AmountDue + .Penalty) Then
                    If .Balance = .Appliedamount Then
                        principal += .AmountDue
                        penalty += .Penalty
                    Else
                        If .Penalty >= .Appliedamount Then
                            principal += 0
                            penalty += .Appliedamount
                        Else
                            principal += .Appliedamount - .Penalty
                            penalty += .Penalty
                        End If
                    End If
                Else
                    Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                    If paidAmount < .Penalty Then
                        If .Penalty >= .Appliedamount Then
                            principal += 0
                            penalty += .Appliedamount
                        Else
                            principal += .Appliedamount - (.Penalty - paidAmount)
                            penalty += .Penalty - paidAmount
                        End If
                    Else
                        principal += .Appliedamount
                        penalty += 0
                    End If
                End If
            End With

        Next

        Return penalty
    End Function

    Private Function GetPartialBalance() As Decimal
        Dim penalty As Decimal
        Dim principal As Decimal
        Dim balance As Decimal

        With _invoices(0)
            If .Balance = (.AmountDue + .Penalty) Then
                If .Balance <> .Appliedamount Then
                    principal = .Appliedamount - .Penalty
                    penalty = .Penalty
                    balance = .AmountDue - principal
                End If
            Else
                Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                If paidAmount < .Penalty Then
                    principal = .Appliedamount - (.Penalty - paidAmount)
                    penalty = .Penalty - paidAmount
                    balance = .AmountDue - principal
                End If
            End If
        End With

        Return balance
    End Function
End Class
