
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BCL.Billings
Imports DALC
Imports System.Data

Public Class MeterReadingInfo
    Public Property BillID As String
    Public Property MeterID As String
    Public Property MeterNumber As String
    Public Property ReadingID As String
    Public Property PresentReading As Decimal
    Public Property PreviousReading As Decimal
    Public Property PresentReadingDate As Date
    Public Property ParamID As String
    Public ReadOnly Property ReadingPeriod As String
        Get
            Return String.Format("{0:MM/dd/yy} - {1:MM/dd/yy}", PreviousReadingDate, PresentReadingDate)
        End Get
    End Property
    Public Property PreviousReadingDate As Date
    Public Property ReadingStatus As String
    Public Property ReadingAdjustment As Decimal
    Public Property ReadingRemarks As String
    Public Property TotalConsumption As Decimal
End Class

Public Class WaterConsumption
    Public Property MeterID As String
    Public Property BillingMonth As String
    Public Property Consumption As Decimal
End Class

Public Class ConsumptionBlock
    Public Property MeterID As String
    Public ReadOnly Property ConsumptionBlock1Decription
        Get
            If withConsumptionTable Then
                Return String.Format("{0} - {1}", MinConsumption, MinConsumptionMaxRange)
            Else

                Return String.Format("{0} cu.m or less", MinConsumption)
            End If

        End Get
    End Property
    Public ReadOnly Property ConsumptionBlock2Decription
        Get
            If withConsumptionTable Then
                If ConsumptionUpperRange = 0 Then
                    Return String.Format("Over {0}", ConsumptionLowerRange)
                Else
                    Return String.Format("{0} - {1}", ConsumptionLowerRange, ConsumptionUpperRange)
                End If

            Else

                Return String.Format("more than {0} cu.m", MinConsumption)
            End If
        End Get
    End Property
    Public ReadOnly Property ConsumptionBlock1Cost
        Get
            If withConsumptionTable Then
                Return String.Format("{0} flat rate", MinCharge)
            Else

                Return String.Format("{0} flat rate", MinCharge)
            End If
        End Get
    End Property

    Public ReadOnly Property ConsumptionBlock2Cost
        Get
            If withConsumptionTable Then
                Return String.Format("{0} per cu.m", Rate)
            Else
                Return String.Format("{0} per cu.m", Rate)
            End If
        End Get
    End Property

    Private MinConsumption As Decimal
    Private MinConsumptionMaxRange As Decimal
    Private MinCharge As Decimal
    Private Rate As Decimal

    Private ConsumptionUpperRange As Decimal
    Private ConsumptionLowerRange As Decimal

    Private RateClass As String
    Private Consumption As Decimal
    Private withConsumptionTable As Boolean = False
    Private paramID As String
    Private Sub New()

    End Sub
    Public Sub New(billparamid As String, rateclass As String, consumption As Decimal)
        paramID = billparamid
        Me.RateClass = rateclass
        Me.Consumption = consumption
        CheckIfwithConsumptionblock()
        GetConsumptionBlockRates()

    End Sub

    Private Sub CheckIfwithConsumptionblock()
        Dim query As String = "SELECT w_cons_table             " & _
        "  FROM utl_water_bill_parameter " & _
            " WHERE bill_param_id = :paramid "
        Using param As New OraParameter
            param.AddParameter("paramid", paramID)
            withConsumptionTable = OraDBHelper2.SqlExecuteScalar(query, param.GetParameterCollection).ToString() = "Y"
        End Using
    End Sub

    Private Sub GetConsumptionBlockRates()

        If withConsumptionTable Then
            Dim query As String = "SELECT *                                                                " & _
                        "  FROM (SELECT from_cons, to_cons, rate, min_rate                       " & _
                        "          FROM utl_water_rate                                           " & _
                        "         WHERE bill_param_id = :paramid AND rate_class = :res           " & _
                        "               AND min_rate = 'Y'                                       " & _
                        "        UNION                                                           " & _
                        "        SELECT from_cons, to_cons, rate, min_rate                       " & _
                        "          FROM utl_water_rate                                           " & _
                        "         WHERE bill_param_id = :paramid                                 " & _
                        "           AND rate_class = :res                                        " & _
                        "           AND :consumption BETWEEN from_cons AND to_cons               " & _
                        "        UNION                                                           " & _
                        "        SELECT *                                                        " & _
                        "          FROM (SELECT   from_cons, to_cons, rate, min_rate             " & _
                        "                    FROM utl_water_rate                                 " & _
                        "                   WHERE bill_param_id = :paramid AND rate_class = :res " & _
                        "                ORDER BY from_cons DESC)                                " & _
                        "         WHERE ROWNUM = 1)                                              " & _
                        " WHERE ROWNUM <= 2                                                      "
            Using param As New OraParameter
                param.AddParameter("paramid", paramID)
                param.AddParameter("res", RateClass)
                param.AddParameter("consumption", Consumption)
                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)
                    MinConsumption = Decimal.Parse(.Rows(0)("from_cons"))
                    MinConsumptionMaxRange = Decimal.Parse(.Rows(0)("to_cons"))
                    MinCharge = Decimal.Parse(.Rows(0)("rate"))


                    ConsumptionLowerRange = Decimal.Parse(.Rows(1)("from_cons"))
                    If Not Convert.IsDBNull(.Rows(1)("to_cons")) Then
                        ConsumptionUpperRange = Decimal.Parse(.Rows(1)("to_cons"))
                    End If

                    Rate = Decimal.Parse(.Rows(1)("rate"))

                End With
            End Using
        Else
            Dim query As String = "SELECT min_consumption, min_charge, rate" & _
                             "  FROM utl_water_bill_parameter         " & _
                             " WHERE bill_param_id = :paramid         "
            Using param As New OraParameter
                param.AddParameter("paramid", paramID)
                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)
                    MinConsumption = Decimal.Parse(.Rows(0)("min_consumption"))
                    MinCharge = Decimal.Parse(.Rows(0)("min_charge"))
                    Rate = Decimal.Parse(.Rows(0)("rate"))
                End With
            End Using

        End If

    End Sub

End Class

Public Class WaterBillingStatement
    Inherits BillingStatement
    Private BillSource As New List(Of BillingStatementSource)
    Private LastPaymentInfo As New List(Of LastPaymentInfo)
    Private MeterReadingInfo As New List(Of MeterReadingInfo)

    Private WaterCons As New List(Of WaterConsumption)
    Private ConsumptionBlock As New List(Of ConsumptionBlock)

    Public Sub New(bills As List(Of AccountBilling))

        For Each bill As AccountBilling In bills
            AddBills(bill)
            LastPaymentInfo.Add(New LastPaymentInfo(bill.BillID))
            AddMeterReadings(bill.BillID, bill.RateClass)
        Next

        ReportDoc = New WaterBillingStatementReport
    End Sub

    Private Sub AddBills(bill As AccountBilling)

        BillSource.Add(New BillingStatementSource With {
                                                  .BillID = bill.BillID,
                                                    .UnitNumber = bill.UnitNumber,
                                                    .CustomerName = bill.CustomerName,
                                                    .RateClass = bill.RateClass,
                                                    .BillDate = bill.BillDate,
                                                    .StatemenDate = bill.StatemenDate,
                                                    .DueDate = bill.DueDate,
                                                    .PreviousBalance = bill.PreviousBalance,
                                                    .PreviousDiscount = bill.PreviousDiscount,
                                                    .PreviousPayment = bill.PreviousPayment,
                                                    .CurrentCharges = bill.CurrentCharges,
                                                    .CurrentPenalty = bill.CurrentPenalty,
                                                    .CurrentDiscount = bill.CurrentDiscount,
                                                    .RemainingAdvance = bill.RemainingAdvance})
    End Sub
    Private Sub AddMeterReadings(billid As String, rateClass As String)

        Dim query As String = "SELECT meter_id, (SELECT meter_number                                                                     " & _
                    "                    FROM utl_meter_detail                                                                 " & _
                    "                   WHERE meter_id = mr.meter_id) meter_number,reading_id,                                 " & _
                    "       reading present_read, reading_date, reading_status, reading_cu,                                    " & _
                    "       reading_adjustment adjustments, reading_remarks,                                                   " & _
                    "       (SELECT DISTINCT FIRST_VALUE (reading) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)     " & _
                    "                   FROM utl_meter_reading                                                                 " & _
                    "                  WHERE reading_date < mr.reading_date                                                    " & _
                    "                    AND meter_id = mr.meter_id) previous_read,                                            " & _
                    "       (SELECT DISTINCT FIRST_VALUE (reading_date) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)" & _
                    "                   FROM utl_meter_reading                                                                 " & _
                    "                  WHERE reading_date < mr.reading_date                                                    " & _
                    "                    AND meter_id = mr.meter_id) previous_read_date,                                       " & _
                    "       bill_param_id                                                                                      " & _
                    "  FROM utl_meter_reading mr                                                                               " & _
                    " WHERE reading_id = (SELECT bill_reading_id                                                               " & _
                    "                       FROM billing_charges                                                               " & _
                    "                      WHERE bill_id = :billid)                                                            "

        Using param As New OraParameter
            param.AddParameter("billid", billid)
            With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)
                Dim mr As New MeterReadingInfo
                mr.BillID = billid
                mr.MeterID = .Rows(0)("meter_id").ToString()
                mr.ReadingID = .Rows(0)("reading_id").ToString()
                mr.MeterNumber = .Rows(0)("meter_number").ToString()
                mr.PresentReading = Decimal.Parse(.Rows(0)("present_read"))
                mr.PreviousReading = Decimal.Parse(.Rows(0)("previous_read"))
                mr.PresentReadingDate = Date.Parse(.Rows(0)("reading_date"))
                mr.PreviousReadingDate = Date.Parse(.Rows(0)("previous_read_date"))
                mr.ReadingAdjustment = Decimal.Parse(.Rows(0)("adjustments"))
                mr.ReadingRemarks = IIf(Convert.IsDBNull(.Rows(0)("reading_remarks")), String.Empty, .Rows(0)("reading_remarks").ToString)
                mr.ReadingStatus = .Rows(0)("reading_status").ToString()
                mr.TotalConsumption = Decimal.Parse(.Rows(0)("reading_cu"))
                mr.ParamID = .Rows(0)("bill_param_id").ToString()
                MeterReadingInfo.Add(mr)

                AddConsumptionBlock(mr.MeterID, mr.ParamID, rateClass, mr.TotalConsumption)
                AddWaterConsumption(mr.MeterID, mr.ReadingID)
            End With
        End Using

    End Sub
    Private Sub AddConsumptionBlock(meterid As String, paramid As String, rateclass As String, consumption As Decimal)
        ConsumptionBlock.Add(New ConsumptionBlock(paramid, rateclass, consumption) With {.MeterID = meterid})
    End Sub
    Private Sub AddWaterConsumption(meterid As String, readingid As String)
        Dim query As String = "SELECT *                                                        " & _
                            "  FROM (SELECT  reading_id, reading_date, reading_cu            " & _
                            "            FROM utl_meter_reading                              " & _
                            "           WHERE meter_id = :meterid                            " & _
                            "             AND reading_date < (SELECT reading_date            " & _
                            "                                   FROM utl_meter_reading       " & _
                            "                                  WHERE reading_id = :readingid)" & _
                            "             AND reading_status NOT IN ('DISC', 'START')        " & _
                            "        ORDER BY reading_date desc)                             " & _
                            " WHERE ROWNUM <= 3 ORDER BY READING_DATE                                              "

        Using param As New OraParameter
            param.AddParameter("meterid", meterid, Oracle.DataAccess.Client.OracleDbType.Int32)
            param.AddParameter("readingid", readingid, Oracle.DataAccess.Client.OracleDbType.Int32)

            For Each dr As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                WaterCons.Add(New WaterConsumption With {.MeterID = meterid,
                                                         .BillingMonth = Date.Parse(dr("reading_date")).ToString("MMM"),
                                                         .Consumption = Decimal.Parse(dr("reading_cu"))})
            Next

        End Using



    End Sub

    Protected Overrides Sub SetDatasource(ByRef reportdoc As ReportDocument)

        reportdoc.Database.Tables(0).SetDataSource(BillSource)
        reportdoc.Database.Tables(1).SetDataSource(MeterReadingInfo)
        reportdoc.Database.Tables(2).SetDataSource(ConsumptionBlock)
        reportdoc.Database.Tables(3).SetDataSource(LastPaymentInfo)

        reportdoc.OpenSubreport("WaterConsumptionGraph").SetDataSource(WaterCons)
        reportdoc.OpenSubreport("WaterConsumptionGraph2").SetDataSource(WaterCons)
    End Sub

    Public Overrides ReadOnly Property StatementHeader As String
        Get
            Return "WATER BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property WaterMarkText As String
        Get
            Return String.Empty
        End Get
    End Property
End Class
