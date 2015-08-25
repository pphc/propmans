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


Imports DALC
Imports BCL.Common

Namespace Payments
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
        Public Enum PayType
            Cash
            Check
        End Enum

        Public ReadOnly Property TempFolderPath() As String
            Get
                Return My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End Get

        End Property

        Public ReadOnly Property PrintPath() As String
            Get
                Return TempFolderPath & "\OfficialReceiptText.txt"
            End Get
        End Property

#Region " Class Properties "

        Private _feeCompany As Common.SiteDivision
        Public Property FeeCompany() As Common.SiteDivision
            Get
                Return _feeCompany
            End Get
            Private Set(ByVal value As Common.SiteDivision)
                _feeCompany = value
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
            Private Set(ByVal value As List(Of String))
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


        Public ReadOnly Property ProjectSiteName() As String
            Get
                Return GlobalReference.ProjectParameters.SiteName
            End Get
        End Property

        Public ReadOnly Property UserID() As String
            Get
                Return OraConnection.Instance.UserID
            End Get
        End Property

        Private _vatableSale As Decimal
        Public Property VatableSale() As Decimal
            Get
                Return _vatableSale
            End Get
            Private Set(ByVal value As Decimal)
                _vatableSale = value
            End Set
        End Property

        Private _vatExempt As Decimal
        Public Property VATExemptAmt() As Decimal
            Get
                Return _vatExempt
            End Get
            Private Set(ByVal value As Decimal)
                _vatExempt = value
            End Set
        End Property

        Private _totalSales As Decimal
        Public Property TotalSalesAmt() As Decimal
            Get
                Return _totalSales
            End Get
            Private Set(ByVal value As Decimal)
                _totalSales = value
            End Set
        End Property

        Private _vat As Decimal
        Public Property VATAmt() As Decimal
            Get
                Return _vat
            End Get
            Private Set(ByVal value As Decimal)
                _vat = value
            End Set
        End Property

#End Region

        Public Sub New(ByVal particulars As Payments.ReceiptParticulars)
            FeeCompany = particulars.FeeInfo.FeeCompany

            TotalSalesAmt = particulars.TotalSales
            VATExemptAmt = particulars.VATExemptSale
            VATAmt = particulars.VATAmount
            VatableSale = particulars.VATableSales

            _particulars = particulars.Items

        End Sub

        Public Sub PrintReceipt()
            Try
                Using sw As New StreamWriter(PrintPath, False)
                    With sw
                        .WriteLine()
                        .WriteLine(ReceiptNumber.PadLeft(55, " "))
                        .WriteLine()
                        .WriteLine()
                        .WriteLine("           " & CustomerName)
                        .WriteLine()
                        .WriteLine()
                        .WriteLine("           " & UnitNumber & " [ " & ProjectSiteName & " ]")
                        .WriteLine(_receiptDate.ToString("dd-MMM-yyyy").ToUpper.PadLeft(80, " "))
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
                                    paytypedesc = "   CASH"
                                Else
                                    paytypedesc = String.Format("    {0}*{1}*{2}", CheckBank, CheckNumber, CheckDate.ToString("dd-MMM-yy"))
                                End If
                                .WriteLine(item.PadRight(50, " ") & paytypedesc)
                            Else
                                .WriteLine(item)
                            End If
                            paytypeprinted = True
                        Next

                        Dim linetoPRint As Integer = 5 - Particulars.Count
                        While linetoPRint <> 0
                            .WriteLine()
                            linetoPRint -= 1
                        End While


                        If FeeCompany = Common.SiteDivision.CondoCorp Then
                            .WriteLine(("NET of VAT" & TotalSalesAmt.ToString("#,##0.00").PadLeft(15, " ")).PadLeft(85, " "))
                            .WriteLine(("       VAT" & VATAmt.ToString("#,##0.00").PadLeft(15, " ")).PadLeft(85, " "))
                            .WriteLine()
                            .WriteLine()
                            .WriteLine(("     TOTAL" & ReceiptAmount.ToString("#,##0.00").PadLeft(15, " ")).PadLeft(85, " "))
                        Else
                            .WriteLine()
                            .WriteLine(TotalSalesAmt.ToString("#,##0.00").PadLeft(15, " ").PadLeft(85, " "))
                            .WriteLine(VATAmt.ToString("#,##0.00").PadLeft(15, " ").PadLeft(85, " "))
                            .WriteLine(ReceiptAmount.ToString("#,##0.00").PadLeft(15, " ").PadLeft(85, " "))
                            .WriteLine()
                        End If


                        .WriteLine()
                        .WriteLine()
                        .WriteLine("UserId:" & UserID)
                        .WriteLine("DateTimePrinted:" & Now.ToString("dd-MMM-yyyy HH:mm").ToUpper)
                        .WriteLine()
                        .WriteLine()

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
                    tp.DefaultPageSettings.Margins.Bottom = 0

                    tp.DocumentName = "OR_" & ReceiptNumber.PadLeft(7, "0")

                    tp.Print()
                End Using


            Catch ex As Exception
                Throw ex
            Finally
                FileSystem.Kill(PrintPath)
            End Try
        End Sub

        Public Sub PrintReceipt2()
            Try
                Dim UnitProject As String = UnitNumber & " [ " & ProjectSiteName & " ]"
                Dim receiptDate As String = _receiptDate.ToString("dd-MMM-yyyy").ToUpper
                Dim payType As String = "CASH"
                Dim receiptAmt As String = ReceiptAmount.ToString("#,##0.00")
                Dim rcptNum As String = "* " & ReceiptNumber & " *"
                Dim particularsline As String = String.Empty

                If PaymentType = ReceiptDoc.PayType.Check Then
                    payType = CheckBank
                End If


                Using sw As New StreamWriter(PrintPath, False)
                    With sw
                        .WriteLine(rcptNum.PadLeft(72 + rcptNum.Length, " ")) 'Line0
                        .WriteLine() 'Line1
                        .WriteLine() 'Line2
                        .WriteLine() 'Line3
                        .WriteLine() 'Line4
                        .WriteLine(CustomerName.PadLeft(9 + CustomerName.Length, " ")) 'Line5
                        .WriteLine() 'Line6
                        .WriteLine(UnitProject.PadLeft(9 + UnitProject.Length, " ")) 'Line7
                        .WriteLine() 'Line8
                        .WriteLine(receiptDate.PadLeft(75 + receiptDate.Length, " ")) 'Line9
                        .WriteLine() 'Line10
                        .WriteLine(AmountInWords.PadLeft(9 + AmountInWords.Length, " ")) 'Line11
                        .WriteLine() 'Line12
                        .WriteLine() 'Line13
                        .WriteLine() 'Line14
                        .WriteLine() 'Line15

                        .WriteLine(payType.PadLeft(54 + payType.Length, " ")) 'Line16

                        If PaymentType = ReceiptDoc.PayType.Cash Then
                            .WriteLine(Particulars(0).PadLeft(1 + Particulars(0).Length, " ")) 'Line17
                        Else
                            particularsline = Particulars(0).PadLeft(1 + Particulars(0).Length, " ")
                            .WriteLine(particularsline.PadRight((54 - particularsline.Length) + particularsline.Length, " ") & "CHK NO. " & CheckNumber) 'Line17
                        End If

                        If Particulars.Count >= 2 Then
                            particularsline = Particulars(1).PadLeft(3 + Particulars(1).Length, " ")
                            .WriteLine(particularsline) 'Line18
                        Else
                            .WriteLine() 'Line18
                        End If

                        If Particulars.Count >= 3 Then
                            particularsline = Particulars(2).PadLeft(3 + Particulars(2).Length, " ")
                            .WriteLine(particularsline.PadRight((77 - particularsline.Length) + particularsline.Length, " ") & TotalSalesAmt.ToString("#,##0.00").PadLeft(10, " ")) 'Line19
                        Else
                            .WriteLine(TotalSalesAmt.ToString("#,##0.00").PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line19
                        End If

                        If Particulars.Count >= 4 Then
                            particularsline = Particulars(3).PadLeft(3 + Particulars(3).Length, " ")
                            .WriteLine(particularsline.PadRight((77 - particularsline.Length) + particularsline.Length, " ") & VATExemptAmt.ToString("#,##0.00").PadLeft(10, " ")) 'Line20
                        Else
                            .WriteLine(VATExemptAmt.ToString("#,##0.00").PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line20
                        End If


                        If Particulars.Count >= 5 Then
                            particularsline = Particulars(4).PadLeft(3 + Particulars(4).Length, " ")
                            .WriteLine(particularsline.PadRight((77 - particularsline.Length) + particularsline.Length, " ")) 'Line21
                        Else
                            .WriteLine("***".PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line21
                        End If

                        .WriteLine("***".PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line22

                        If TotalSalesAmt = 0 Then
                            .WriteLine(VATExemptAmt.ToString("#,##0.00").PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line23
                        Else
                            .WriteLine(TotalSalesAmt.ToString("#,##0.00").PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line23
                        End If

                        .WriteLine(VATAmt.ToString("#,##0.00").PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line24
                        .WriteLine(receiptAmt.PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line25

                        .WriteLine("***".PadLeft(10, " ").PadLeft(77 + 10, " ")) 'Line26
                        .WriteLine(receiptAmt.PadLeft(87, " ")) 'Line27



                        .WriteLine() 'Line28
                        .WriteLine("Date Time Printed:".PadLeft(19 + "Date Time Printed:".Length)) 'Line29

                        particularsline = Now.ToString("dd-MMM-yyyy HH:mm").ToUpper.PadLeft(36, " ")
                        .WriteLine(particularsline.PadRight((70 - particularsline.Length) + particularsline.Length, " ") & UserID) 'Line30

                        .WriteLine() 'Line31
                        .WriteLine() 'Line32

                    End With
                End Using

                Using sr As New StreamReader(PrintPath)
                    Dim strOutput As String = sr.ReadToEnd()

                    Dim tp As New TextPrint(strOutput)

                    tp.Font = New Font("Lucida Console", 10)
                    tp.DefaultPageSettings.PaperSize = New PaperSize("HalfShort", 850, 550)

                    tp.DefaultPageSettings.Margins.Top = 40
                    tp.DefaultPageSettings.Margins.Left = 10
                    tp.DefaultPageSettings.Margins.Right = 0
                    tp.DefaultPageSettings.Margins.Bottom = 0

                    tp.DocumentName = "OR_" & ReceiptNumber.PadLeft(7, "0")

                    tp.Print()
                End Using


            Catch ex As Exception
                Throw ex
            Finally
                FileSystem.Kill(PrintPath)
            End Try
        End Sub

        Public Function GetChars() As String
            Dim str As String = "+"
            Dim stroutput As String = String.Empty
            For x As Integer = 0 To 90
                stroutput &= str
            Next
            Return stroutput
        End Function
     
    End Class

    Public MustInherit Class ReceiptParticulars

        Private __items As New List(Of String)
        Protected Property _items() As List(Of String)
            Get
                Return __items
            End Get
            Set(ByVal Value As List(Of String))
                __items = Value
            End Set
        End Property

        Public ReadOnly Property Items() As List(Of String)
            Get
                Return _items
            End Get
        End Property

        Private _feeInfo As Common.Fees

        Public Property FeeInfo() As Common.Fees
            Get
                Return _feeInfo
            End Get
            Set(ByVal value As Common.Fees)
                _feeInfo = value
            End Set
        End Property

        Private _vatSales As Decimal
        Public Property VATableSales() As Decimal
            Get
                Return _vatSales
            End Get
            Set(ByVal value As Decimal)
                _vatSales = value
            End Set
        End Property


        Private _vatExemptSale As Decimal
        Public Property VATExemptSale() As Decimal
            Get
                Return _vatExemptSale
            End Get
            Set(ByVal value As Decimal)
                _vatExemptSale = value
            End Set
        End Property

        Private _totalSales As Decimal
        Public Property TotalSales() As Decimal
            Get
                Return _totalSales
            End Get
            Set(ByVal value As Decimal)
                _totalSales = value
            End Set
        End Property

        Private _vatAmt As Decimal
        Public Property VATAmount() As Decimal
            Get
                Return _vatAmt
            End Get
            Set(ByVal value As Decimal)
                _vatAmt = value
            End Set
        End Property

        Private _remarks As String
        Public Property Remarks() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Sub New(ByVal feeID As String)
            FeeInfo = GlobalReference.Fee.GetFeeInfobyFeeID(feeID)
        End Sub

        Public Sub New()

        End Sub

        MustOverride Sub Process()

    End Class

    Public Class AdvanceParticulars
        Inherits ReceiptParticulars

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


        Public Sub New(ByVal feeID As String, ByVal amountPaid As Decimal, Optional ByVal discountRate As Decimal = 0)
            MyBase.New(feeID)
            Me.AmountPaid = amountPaid
            Me.Discountrate = discountRate
        End Sub


        Public Overrides Sub Process()
            If Discountrate > 0 Then
                _items.Add(FeeInfo.FeeDescription & " ADVANCES - " & OriginalAmount.ToString("#,###.00"))
                _items.Add("   Less " & Discountrate & "% Discount - (" & DiscountAmount.ToString("#,###.00") & ")")
            Else
                _items.Add(FeeInfo.FeeDescription & " ADVANCES - " & AmountPaid.ToString("#,###.00"))
            End If

            If Not String.IsNullOrEmpty(Remarks) Then
                _items.Add("  " & Remarks)
            End If

            ComputeVat()
        End Sub

        Private Sub ComputeVat()

            If FeeInfo.FeeVatable Then
                If Discountrate > 0 Then
                    TotalSales += (OriginalAmount - DiscountAmount) / 1.12
                    VATAmount += TotalSales * 0.12
                Else
                    TotalSales += OriginalAmount / 1.12
                    VATAmount += TotalSales * 0.12
                End If

                VATableSales += TotalSales + VATAmount
            End If

        End Sub
    End Class

    Public Class RegularParticulars
        Inherits ReceiptParticulars
        Private _invoices As List(Of PaymentBilling)

        Public Sub New(ByVal feeID As String, ByVal invoices As List(Of PaymentBilling))
            MyBase.New(feeID)
            _invoices = invoices
        End Sub

        Public Overrides Sub Process()

            If _invoices.Count = 1 Then
                With _invoices(0)
                    If FeeInfo.BillType = BillingType.OneTime Then
                        If .Balance = .Appliedamount Then
                            'Full payment
                            _items.Add(FeeInfo.FeeDescription)
                        Else
                            'Partial payment
                            _items.Add(FeeInfo.FeeDescription)
                            _items.Add(" PARTIAL PAYMENT of Php " & .Appliedamount.ToString("#,###.00"))
                            _items.Add(" BALANCE: Php " & .Newbalance.ToString("#,###.00"))
                        End If

                    Else
                        Dim principalAmt As Decimal
                        Dim penalty As Decimal = GetPenaltyAmt(principalAmt)

                        If .Balance = .Appliedamount Then
                            'Full payment
                            If penalty = 0 Then
                                _items.Add(FeeInfo.FeeDescription & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                            Else
                                If principalAmt = 0 Then
                                    _items.Add(FeeInfo.FeeDescription & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                                Else
                                    _items.Add(FeeInfo.FeeDescription & " " & .BillPeriodDate.Value.ToString("MMM \'yy") & " - " & principalAmt.ToString("#,###.00"))
                                End If

                                _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                            End If

                        Else
                            'Partial payment
                            If penalty = 0 Then
                                _items.Add(FeeInfo.FeeDescription & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                                _items.Add(" PARTIAL PAYMENT of Php " & .Appliedamount.ToString("#,###.00"))
                                _items.Add(" BALANCE: Php " & .Newbalance.ToString("#,###.00"))
                            Else
                                If principalAmt = 0 Then
                                    ' _items.Add(FeeName & " " & .billPeriodDate.Value.ToString("MMM \'yy"))
                                Else
                                    _items.Add(FeeInfo.FeeDescription & " " & .BillPeriodDate.Value.ToString("MMM \'yy"))
                                    _items.Add(" PARTIAL PAYMENT of Php " & principalAmt.ToString("#,###.00"))
                                    _items.Add(" BALANCE: Php " & GetPartialBalance.ToString("#,###.00"))
                                End If
                                _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                            End If

                        End If
                    End If


                End With

            Else
                If FeeInfo.BillType = BillingType.OneTime Then
                    If HaspartialPayment() Then
                        'Invoices w/ some partial invoice payment
                        _items.Add(FeeInfo.FeeDescription)
                        _items.Add("  PARTIAL PAYMENT of Php " & GetPartialInvoicePayment().ToString("#,###.00"))
                        _items.Add("  BALANCE: Php " & GetPartialInvoiceBalance().ToString("#,###.00"))

                    Else
                        'Invoices w/ full payment
                        _items.Add(FeeInfo.FeeDescription)
                    End If
                Else
                    Dim principalAmt As Decimal
                    Dim penalty As Decimal = GetTotalPenaltyAmt(principalAmt)

                    If penalty = 0 Then
                        If HaspartialPayment() Then
                            'Invoices w/ some partial invoice payment
                            _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & GetFullInvoicePayment().ToString("#,###.00"))
                            _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetPartialInvoiceDate))
                            _items.Add("  PARTIAL PAYMENT of Php " & GetPartialInvoicePayment().ToString("#,###.00"))
                            _items.Add("  BALANCE: Php " & GetPartialInvoiceBalance().ToString("#,###.00"))
                        Else
                            'Invoices w/ full payment
                            _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate))
                        End If
                    Else
                        If HaspartialPayment() Then
                            'Invoices w/ some partial invoice payment
                            If principalAmt = 0 Then
                                _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate))
                            Else
                                _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & GetPenalizedFullInvoicePayment().ToString("#,###.00"))
                                Dim principal As Decimal = GetPenalizedPartialInvoicePayment()
                                If principal > 0 Then
                                    _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetPartialInvoiceDate))
                                    _items.Add("  PARTIAL PAYMENT of Php " & GetPenalizedPartialInvoicePayment().ToString("#,###.00"))
                                    _items.Add("  BALANCE: Php " & GetPenalizedPartialInvoiceBalance().ToString("#,###.00"))
                                End If
                            End If
                            _items.Add("Penalty - " & penalty.ToString("#,###.00"))
                        Else
                            'Invoices w/ full payment
                            If principalAmt = 0 Then
                                _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate))
                            Else
                                _items.Add(FeeInfo.FeeDescription & " " & GetStatementRange(GetRegularInvoiceDate) & " - " & principalAmt.ToString("#,###.00"))
                            End If

                            _items.Add("Penalty - " & penalty.ToString("#,###.00"))

                        End If
                    End If

                End If

            End If

            If Not String.IsNullOrEmpty(Remarks) Then
                _items.Add("  " & Remarks)
            End If

            ComputeVat()
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

        Private Function GetStatementRange(ByVal invoicesDate As List(Of Date)) As String
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
                            periodRange &= currentDate.ToString("MMM \'yy")
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
                            periodRange &= currentDate.ToString("MMM \'yy")
                        End If

                    End If
                End If
                idx += 1
            Next

            If invoicesDate.Count = 1 Then
                statementRange = periodRange & " (" & invoicesDate.Count & " month)"
            Else
                statementRange = periodRange & " (" & invoicesDate.Count & " months)"
            End If


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

        Private Sub ComputeVat()

            For Each item As PaymentBilling In _invoices
                If item.Vatable Then
                    Dim _totalSale As Decimal = item.Appliedamount / 1.12
                    Dim _vatAmt As Decimal = _totalSale * 0.12
                    TotalSales += _totalSale
                    VATAmount += _vatAmt

                    VATableSales += _totalSale + _vatAmt
                Else
                    VATExemptSale += item.Appliedamount
                End If
            Next
        End Sub

    End Class

End Namespace

