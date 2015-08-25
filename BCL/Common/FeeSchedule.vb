Imports DALC
Namespace Common

    Public Class FeeSchedule
        Private _effectiveDate As Date
        Public Property EffectiveDate() As Date
            Get
                Return _effectiveDate
            End Get
            Set(ByVal value As Date)
                _effectiveDate = value
            End Set
        End Property

        Private _statementDay As Nullable(Of Integer)
        Public Property StatementDay() As Nullable(Of Integer)
            Get
                Return _statementDay
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _statementDay = value
            End Set
        End Property

        Private _dueDay As Nullable(Of Integer)
        Public Property DueDay() As Nullable(Of Integer)
            Get
                Return _dueDay
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _dueDay = value
            End Set
        End Property


        Private _gracePeriodDay As Nullable(Of Integer)
        Public Property GracePeriodDay() As Nullable(Of Integer)
            Get
                Return _gracePeriodDay
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _gracePeriodDay = value
            End Set
        End Property

        Private _penalty As Nullable(Of Decimal)
        Public Property Penalty() As Nullable(Of Decimal)
            Get
                Return _penalty
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _penalty = value
            End Set
        End Property


        Private _feeBillingSchedule As DataTable
        Public ReadOnly Property FeeBillingSchedule() As DataTable
            Get
                Return _feeBillingSchedule
            End Get
        End Property


        Public Sub New(Optional ByVal Reload As Boolean = True)
            If Reload Then
                LoadFeeBillingSchedules()
            End If

        End Sub

        Private Sub LoadFeeBillingSchedules()
            Dim query As String

            query = "SELECT schedule_id, effective_date, statement_day, due_day, grace_period," & _
                    "       penalty_rate, remarks, fee_type_id                                " & _
                    "  FROM bc_billing_sched_history                                          "


            _feeBillingSchedule = OraDBHelper2.GetResultSet(query)
        End Sub

        Public Function GetBillingSchedule(ByVal feeTypeID As String, ByVal billDate As Date) As FeeSchedule
            Dim feeSched As New FeeSchedule(False)
            Dim effDate As Nullable(Of Date)

            If Not Convert.IsDBNull(_feeBillingSchedule.Compute("MAX(effective_date)", _
                                     "fee_type_id =" & feeTypeID & " AND effective_date <= #" & billDate & "#")) Then
                effDate = _feeBillingSchedule.Compute("MAX(effective_date)", _
                                                     "fee_type_id =" & feeTypeID & " AND effective_date <= #" & billDate & "#")
            End If

            If effDate.HasValue Then
                Me.EffectiveDate = effDate.Value

                Dim dv As New DataView(_feeBillingSchedule)
                dv.RowFilter = "fee_type_id =" & feeTypeID & " AND effective_date = #" & Me.EffectiveDate & "#"

                If dv.Count = 0 Then
                    Return feeSched
                Else
                    With dv.Item(0)
                        If Not String.IsNullOrEmpty(.Item("statement_day")) Then
                            If .Item("statement_day").ToString = "EOM" Then
                                feeSched.StatementDay = -1
                            Else
                                feeSched.StatementDay = Integer.Parse(.Item("statement_day").ToString)
                            End If


                        End If

                        If Not Convert.IsDBNull(.Item("due_day")) Then
                            If .Item("due_day").ToString = "EOM" Then
                                feeSched.DueDay = -1
                            Else
                                feeSched.DueDay = Integer.Parse(.Item("due_day").ToString)
                            End If


                        End If

                        If Not Convert.IsDBNull(.Item("grace_period")) Then
                            If .Item("grace_period").ToString = "EOM" Then
                                feeSched.GracePeriodDay = -1
                            Else
                                feeSched.GracePeriodDay = Integer.Parse(.Item("grace_period").ToString)
                            End If

                        End If

                        If Not Convert.IsDBNull(.Item("penalty_rate")) Then
                            feeSched.Penalty = Decimal.Parse(.Item("penalty_rate"))
                        End If

                    End With
                    Return feeSched
                End If

            Else
                Return feeSched
            End If

        End Function
    End Class
End Namespace

