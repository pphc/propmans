Imports DALC
Imports BCL.Utils

Namespace Common

    Public Enum BillingType
        <EnumDescription("ONE TIME BILL")> _
        <EnumDBValue("I")> _
        OneTime
        <EnumDescription("RECURRING BILL")> _
        <EnumDBValue("B")> _
        Recurring

    End Enum

    Public Enum SiteDivision
        <EnumDescription("All")> _
        <EnumDBValue("A")> _
        All
        <EnumDescription("Utilities")> _
        <EnumDBValue("P")> _
        Utlities
        <EnumDescription("Condo Corp")> _
        <EnumDBValue("C")> _
        CondoCorp

    End Enum

    Public Enum FeeStatus
        <EnumDescription("Active")> _
         <EnumDBValue("ACT")> _
         Active
        <EnumDescription("Inactive")> _
         <EnumDBValue("INACT")> _
         Inactive
    End Enum

    Public Enum FeeUnitClass
        <EnumDescription("CONDO UNIT")> _
        <EnumDBValue("CONDO")> _
        CondoUnit
        <EnumDescription("PARKING SLOT")> _
        <EnumDBValue("PARK")> _
        ParkingUnit
    End Enum

    Public Class OneTimeFees
        Inherits ListSource

        Public Sub New(ByVal division As SiteDivision, ByVal feeUnitClass As FeeUnitClass)

            Dim billType As BillingType = BillingType.OneTime
            Dim feeStatus As FeeStatus = feeStatus.Active

            Using dv As New DataView(GlobalReference.Fee.FeeTypeDataTable)

                Dim rowFilter As String = "billtype='{0}' AND status = '{1}' AND unit_class = '{2}'"

                rowFilter = String.Format(rowFilter, EnumHelper.GetDBValue(billType), _
                                                        EnumHelper.GetDBValue(feeStatus), _
                                                         EnumHelper.GetDBValue(feeUnitClass))


                If division <> SiteDivision.All Then
                    rowFilter &= String.Format(" AND company ='{0}'", EnumHelper.GetDBValue(division))
                End If

                dv.RowFilter = rowFilter
                dv.Sort = "description"
                For i As Integer = 0 To dv.Count - 1
                    Me.AddItem(dv.Item(i)("feeid").ToString, dv.Item(i)("description").ToString)
                Next
            End Using
        End Sub

    End Class

    Public Class RecurringBillFees
        Inherits ListSource

        Public Sub New(ByVal division As SiteDivision, ByVal feeUnitClass As FeeUnitClass)

            Dim billType As BillingType = BillingType.Recurring
            Dim feeStatus As FeeStatus = feeStatus.Active

            Using dv As New DataView(GlobalReference.Fee.FeeTypeDataTable)

                Dim rowFilter As String = "billtype='{0}' AND status = '{1}' AND unit_class = '{2}'"

                rowFilter = String.Format(rowFilter, EnumHelper.GetDBValue(billType), _
                                                        EnumHelper.GetDBValue(feeStatus), _
                                                         EnumHelper.GetDBValue(feeUnitClass))


                If division <> SiteDivision.All Then
                    rowFilter &= String.Format(" AND company ='{0}'", EnumHelper.GetDBValue(division))
                End If

                dv.RowFilter = rowFilter
                dv.Sort = "description"
                For i As Integer = 0 To dv.Count - 1
                    Me.AddItem(dv.Item(i)("feeid").ToString, dv.Item(i)("description").ToString)
                Next
            End Using
        End Sub

        Public Sub New(ByVal division As SiteDivision)

            Dim billType As BillingType = BillingType.Recurring
            Dim feeStatus As FeeStatus = feeStatus.Active

            Using dv As New DataView(GlobalReference.Fee.FeeTypeDataTable)

                Dim rowFilter As String = "billtype='{0}' AND status = '{1}'"

                rowFilter = String.Format(rowFilter, EnumHelper.GetDBValue(billType), _
                                                        EnumHelper.GetDBValue(feeStatus))


                If division <> SiteDivision.All Then
                    rowFilter &= String.Format(" AND company ='{0}'", EnumHelper.GetDBValue(division))
                End If

                dv.RowFilter = rowFilter
                dv.Sort = "description"
                For i As Integer = 0 To dv.Count - 1
                    Me.AddItem(dv.Item(i)("feeid").ToString, dv.Item(i)("description").ToString)
                Next
            End Using
        End Sub

    End Class
    'TODO. eleminate literals
    Public Class ActiveFeeTypes
        Inherits ListSource

        Public Sub New(ByVal division As SiteDivision)

            Using dv As New DataView(GlobalReference.Fee.FeeTypeDataTable)
                Dim rowFilter As String = "status='ACT'"
                If division <> SiteDivision.All Then
                    If division = SiteDivision.CondoCorp Then
                        rowFilter &= " AND company ='C'"
                    Else
                        rowFilter &= " AND company ='P'"
                    End If
                End If

                dv.RowFilter = rowFilter
                dv.Sort = "description"
                For i As Integer = 0 To dv.Count - 1
                    List.Add(New ItemLIst(dv.Item(i)("feeid").ToString, dv.Item(i)("description").ToString))
                Next
            End Using
        End Sub

    End Class
    'TODO. eleminate literals
    Public Class BillableFeeTypes
        Inherits ListSource

        Public Sub New(ByVal division As SiteDivision)

            Using dv As New DataView(GlobalReference.Fee.FeeTypeDataTable)
                Dim rowFilter As String = "billtype = 'B' AND status = 'ACT'"
                If division <> SiteDivision.All Then
                    If division = SiteDivision.CondoCorp Then
                        rowFilter &= " AND company ='C'"
                    Else
                        rowFilter &= " AND company ='P'"
                    End If
                End If

                dv.RowFilter = rowFilter
                dv.Sort = "description"
                For i As Integer = 0 To dv.Count - 1
                    List.Add(New ItemLIst(dv.Item(i)("feeid").ToString, dv.Item(i)("description").ToString))
                Next
            End Using
        End Sub

    End Class

    Public Class UnpaidFeeTypes
        Inherits ListSource
        Public Sub New(ByVal accountID As String, ByVal division As SiteDivision)

            Dim query As String

            query = "SELECT DISTINCT bill_fee_type feeid                                    " & _
                    "           FROM billing_charges                                        " & _
                    "          WHERE bill_cust_id = :accountid AND lease_id is null AND bill_status IN ('U', 'P')"


            Using params As New OraParameter
                params.AddItem(":accountid", accountID)
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    If .Rows.Count = 0 Then
                        List.Add(New ItemLIst(-1, "NOT AVAILABLE"))
                    Else
                        For Each row As DataRow In .Rows
                            Dim feeid As Integer = row("feeid")
                            With GlobalReference.Fee.GetFeeInfobyFeeID(feeid)
                                Select Case division
                                    Case SiteDivision.All
                                        List.Add(New ItemLIst(feeid, .FeeDescription))
                                    Case SiteDivision.CondoCorp
                                        If .FeeCompany = SiteDivision.CondoCorp Then
                                            List.Add(New ItemLIst(feeid, .FeeDescription))
                                        End If
                                    Case SiteDivision.Utlities
                                        If .FeeCompany = SiteDivision.Utlities Then
                                            List.Add(New ItemLIst(feeid, .FeeDescription))
                                        End If
                                End Select
                            End With
                        Next
                    End If
                End With
            End Using

        End Sub
        Public Sub New(ByVal accountID As String, ID As String, ByVal division As SiteDivision)

            Dim query As String

            query = "SELECT DISTINCT bill_fee_type feeid                                    " & _
                    "           FROM billing_charges                                        " & _
                    "          WHERE (bill_cust_id = :accountid AND lease_id = :ID) AND bill_status IN ('U', 'P')"


            Using params As New OraParameter
                params.AddItem(":accountid", accountID)
                params.AddItem("ID", ID)
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    If .Rows.Count = 0 Then
                        List.Add(New ItemLIst(-1, "NO UNPAID INVOICES"))
                    Else
                        For Each row As DataRow In .Rows
                            Dim feeid As Integer = row("feeid")
                            With GlobalReference.Fee.GetFeeInfobyFeeID(feeid)
                                Select Case division
                                    Case SiteDivision.All
                                        List.Add(New ItemLIst(feeid, .FeeDescription))
                                    Case SiteDivision.CondoCorp
                                        If .FeeCompany = SiteDivision.CondoCorp Then
                                            List.Add(New ItemLIst(feeid, .FeeDescription))
                                        End If
                                    Case SiteDivision.Utlities
                                        If .FeeCompany = SiteDivision.Utlities Then
                                            List.Add(New ItemLIst(feeid, .FeeDescription))
                                        End If
                                End Select
                            End With
                        Next
                    End If
                End With
            End Using

        End Sub
    End Class

    Public Class Fees

        Private _feeTypeID As Integer
        Public Property FeeTypeID() As Integer
            Get
                Return _feeTypeID
            End Get
            Set(ByVal value As Integer)
                _feeTypeID = value
            End Set
        End Property

        Private _feeDescription As String
        Public Property FeeDescription() As String
            Get
                Return _feeDescription
            End Get
            Set(ByVal value As String)
                _feeDescription = value
            End Set
        End Property


        Private _defaultAmount As Decimal
        Public Property DefaultAmount() As Decimal
            Get
                Return _defaultAmount
            End Get
            Set(ByVal value As Decimal)
                _defaultAmount = value
            End Set
        End Property

        Private _billType As BillingType
        Public Property BillType() As BillingType
            Get
                Return _billType
            End Get
            Set(ByVal value As BillingType)
                _billType = value
            End Set
        End Property

        Private _feeCompany As SiteDivision
        Public Property FeeCompany() As SiteDivision
            Get
                Return _feeCompany
            End Get
            Set(ByVal value As SiteDivision)
                _feeCompany = value
            End Set
        End Property

        Private _feeVatable As Boolean
        Public Property FeeVatable() As Boolean
            Get
                Return _feeVatable
            End Get
            Set(ByVal value As Boolean)
                _feeVatable = value
            End Set
        End Property

        Private _feeTypeDatatable As DataTable
        Public ReadOnly Property FeeTypeDataTable() As DataTable
            Get
                Return _feeTypeDatatable
            End Get
        End Property


        Public Sub New()
            LoadFeeTypes()
        End Sub

        Private Sub LoadFeeTypes()
            Dim query As String

            query = "SELECT fee_type_id feeid, fee_description description, default_amount amount," & _
                    "       fee_status status, finance_code fincode, billing_type billtype,       " & _
                    "       fee_company company, fee_remarks remarks,      " & _
                    "       vatable vatable,unit_class " & _
                    "  FROM ref_fee_types  "

            _feeTypeDatatable = OraDBHelper2.GetResultSet(query)

        End Sub

        Public Function GetFeeInfobyFeeID(ByVal feeID As String) As Fees

            Dim dv As New DataView(FeeTypeDataTable)

            dv.RowFilter = "feeid =" & feeID

            If dv.Count = 0 Then
                Return Nothing
            Else
                Dim fee As New Fees

                With fee
                    .FeeTypeID = feeID
                    .FeeDescription = dv.Item(0).Item("description").ToString

                    If Not Convert.IsDBNull(dv.Item(0).Item("amount")) Then
                        .DefaultAmount = Decimal.Parse(dv.Item(0).Item("amount"))
                    End If

                    .BillType = EnumHelper.GetEnumValueFromDBValue(Of BillingType)(dv.Item(0).Item("billtype"))
                    .FeeCompany = EnumHelper.GetEnumValueFromDBValue(Of SiteDivision)(dv.Item(0).Item("company"))

                    .FeeVatable = IIf(dv.Item(0).Item("vatable").ToString.Trim = "Y", True, False)

                End With

                Return fee
            End If

        End Function

        Public Function GetFeeTypeDefaultAmount(ByVal feeTypeID As String) As Decimal

            Dim dv As New DataView(FeeTypeDataTable)

            dv.RowFilter = "feeid =" & FeeTypeID

            If dv.Count = 0 Then
                Return 0
            Else
                If Not Convert.IsDBNull(dv.Item(0).Item("amount")) Then
                    Return Decimal.Parse(dv.Item(0).Item("amount"))
                Else
                    Return 0
                End If
            End If
        End Function

        Public Function GetFeeUnitClass(ByVal feeTypeId As String) As FeeUnitClass

            Dim dv As New DataView(FeeTypeDataTable)

            dv.RowFilter = "feeid =" & feeTypeId

            If dv.Count = 0 Then
                Return Nothing
            Else
                Return EnumHelper.GetEnumValueFromDBValue(Of FeeUnitClass)(dv.Item(0).Item("unit_class"))
            End If
        End Function

        Public Function GetFeeCompany(ByVal feeTypeId As String) As String

            Dim dv As New DataView(FeeTypeDataTable)

            dv.RowFilter = "feeid =" & feeTypeId

            If dv.Count = 0 Then
                Return Nothing
            Else
                Return dv.Item(0).Item("company").ToString
            End If
        End Function

        Public Function GetFeeVatable(ByVal feeTypeId As String) As Boolean

            Dim dv As New DataView(FeeTypeDataTable)

            dv.RowFilter = "feeid =" & feeTypeId

            If dv.Count = 0 Then
                Return False
            Else
                Return dv.Item(0).Item("vatable").ToString.Equals("Y")
            End If

        End Function

    End Class

End Namespace

