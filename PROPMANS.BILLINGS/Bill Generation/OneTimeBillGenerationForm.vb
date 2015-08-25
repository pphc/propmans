Imports ComponentFactory.Krypton.Toolkit


Imports BCL.Billings
Imports BCL.Common
Imports PROPMANS.BASE_MOD

Public Class OneTimeBillGenerationForm

#Region "Properties"
    Private _bLoaded As Boolean


    Private _unitNumber As String
    Private ReadOnly Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
    End Property

    Private _unitOwnerName As String
    Private ReadOnly Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
    End Property


    Private _accountID As String
    Private ReadOnly Property AccountID() As String
        Get
            Return _accountID
        End Get
    End Property

    Private _leaseID As String
    Private ReadOnly Property LeaseID As String
        Get
            Return _leaseID
        End Get
    End Property

    Private _unitFeeClass As FeeUnitClass
    Private ReadOnly Property UnitFeeClass() As String
        Get
            Return _unitFeeClass
        End Get
    End Property

    Private BillHelper As New BillGenerationHelper
#End Region

#Region "Form Instance"
    Private Shared aForm As OneTimeBillGenerationForm
    Public Shared Function Instance() As OneTimeBillGenerationForm
        If aForm Is Nothing Then
            aForm = New OneTimeBillGenerationForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub
#End Region

#Region " Form and Control Events"

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click

        Using frm As AccountLookupForm = New AccountLookupForm
            frm.ShowDialog()
            Try
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    _unitNumber = frm.UnitNumber
                    _unitOwnerName = frm.CustomerFullName
                    _accountID = frm.AccountID
                    _unitFeeClass = frm.UnitClass
                    _leaseID = frm.LeaseID

                    lblUnitNumber.Text = _unitNumber
                    lblCustomerName.Text = _unitOwnerName

                    Me.lblCustomerType.Text = frm.CustomerType

                    InvoiceDetailsGroupBox.Visible = True
                    PopulateOneTimeFeeList()
                Else
                    lblUnitNumber.Text = String.Empty
                    lblCustomerName.Text = String.Empty


                    InvoiceDetailsGroupBox.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ErrorToString)
            End Try
        End Using
    End Sub

    Private Sub btnGenerateBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateBill.Click
        If ValidateEntry() Then
            If MessageBox.Show("Generate Bill?", "Generation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GenerateBill()
                txtAmountDue.Text = String.Empty
                MessageBox.Show("Billing was generated")
            End If
        End If

    End Sub

    Private Sub cboFeeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeeType.SelectedIndexChanged
        If _bLoaded Then
            Dim feeAmount As Decimal = GlobalReference.Fee.GetFeeTypeDefaultAmount(cboFeeType.SelectedValue.ToString)
            If feeAmount = 0 Then
                lblDefaultAmount.Text = String.Empty
                txtAmountDue.Text = String.Empty
            Else
                lblDefaultAmount.Text = feeAmount
                txtAmountDue.Text = feeAmount
            End If

            txtAmountDue.SelectAll()
            txtAmountDue.Focus()
        End If
    End Sub
#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        AddHandler txtAmountDue.KeyPress, AddressOf Common.Decimal_KeyPress

        InvoiceDetailsGroupBox.Visible = False
        dtpStatementDate.Value = Now.Date

        lblUnitNumber.Text = String.Empty
        lblCustomerName.Text = String.Empty
        lblDefaultAmount.Text = String.Empty
        lblCustomerType.Text = String.Empty
    End Sub

    Private Sub PopulateOneTimeFeeList()
        _bLoaded = False
        Common.BindComboBoxtoList(cboFeeType, New OneTimeFees(GlobalReference.CurrentUser.CompanyAccess, Me.UnitFeeClass))
        _bLoaded = True

        cboFeeType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Function ValidateEntry() As Boolean
        Dim bValid As Boolean = True
        ErrorProvider1.Clear()

        If Not Common.HasValue(txtAmountDue) Then
            ErrorProvider1.SetError(txtAmountDue, "Enter value for amount due")
            txtAmountDue.Focus()
            bValid = False
        End If

        Return bValid
    End Function

    Private Sub GenerateBill()

        Dim billInfo As New OneTimeBill

        With billInfo
            .StatementDate = dtpStatementDate.Value.Date
            .AmountDue = Decimal.Parse(txtAmountDue.Text)
            .FeeTypeID = cboFeeType.SelectedValue.ToString
            .AccountID = Me.AccountID
            .LeasedID = Me.LeaseID
        End With

        BillHelper.GenerateBill(billInfo)

        SetDefault()
    End Sub

    Private Sub LoadAccountInfo()
        'AccountInfo.Instance.LoadUnitInfoByID(AccountID)

        '_unitNumber = AccountInfo.Instance.AccountInfo.UnitNumber

        '_unitOwnerName = AccountInfo.Instance.AccountInfo.CustomerFullName(CustInfo.CustomerNameOrder.FirstNameFirst)
    End Sub

    Private Sub SetDefault()
        cboFeeType.SelectedIndex = 0
        dtpStatementDate.Value = Date.Now
        txtBillingNotes.Text = String.Empty
    End Sub

#End Region

End Class
