Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports DALC
Imports Oracle.DataAccess.Client
Imports BCL.Utilities
Imports BCL

Public Class WaterBillingReport
    Inherits RecurringBillReportBase


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "WATER BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property StatementHeader() As String
        Get
            Return "WATER BILLING STATEMENT"
        End Get
    End Property

    Public Overrides ReadOnly Property WaterMarkText() As String
        Get
            Return "Water System"
        End Get
    End Property


    Private _currentparamid As String

    Private _dtSource As DataTable
    Public Property dtConsumptionTable() As DataTable
        Get
            Return _dtSource
        End Get
        Set(ByVal value As DataTable)
            _dtSource = value
        End Set
    End Property

    Public Overrides Sub LoadReport()
        LoadMeterReadings()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()

        ReportDoc = New rptCommonBilling
        'reportDoc.ReportDefinition.Sections("SecCommon").SectionFormat.EnableSuppress = True

        With ReportDoc.DataDefinition
            .FormulaFields("Supress").Text = "'" & "Common" & "'"

            .FormulaFields("Watermark").Text = "'" & WaterMarkText & "'"

            .FormulaFields("ProjectName").Text = "'" & ProjectName & "'"
            .FormulaFields("ProjectLocation").Text = "'" & ProjectLocation & "'"
            .FormulaFields("ProjectOffice").Text = "'" & OfficeLocation & "'"
            .FormulaFields("ProjectContactNo").Text = "'" & OfficeCOntact & "'"

            .FormulaFields("CorporationName").Text = "'" & CorporationName & "'"
            .FormulaFields("StatementName").Text = "'" & StatementHeader & "'"

            .FormulaFields("PropertyAdminName").Text = "'" & PropertyAdministrator & "'"
            .FormulaFields("UserFullName").Text = "'" & UserFullName & "'"

            '.FormulaFields("Remarks").Text = "'" & Remarks & "'"

            '.FormulaFields("FlatRateSetting").Text = "'" & FlatRateSetting.ToString("##0.00") & "'"
            '.FormulaFields("FlatRateCost").Text = "'" & FlatRateCost.ToString("##0.00") & "'"
            '.FormulaFields("Waterrate").Text = "'" & WaterRate.ToString("##0.00") & "'"
        End With

        ReportDoc.Database.Tables("COMMONBILLING").SetDataSource(dtAccounts)
        ReportDoc.Database.Tables("WATERACCOUNT").SetDataSource(DirectCast(dtMeterReading, DataTable))

    End Sub

    Private Sub LoadMeterReadings()
        dtMeterReading = New BillingsDataSet.WATERACCOUNTDataTable
        Dim rw As BillingsDataSet.WATERACCOUNTRow

        For Each row As DataRow In GetMeterReadingsByBillingDate(StatementDate).Rows
            rw = dtMeterReading.NewRow

            rw.ACCOUNT_ID = row("cust_acct_id").ToString
            rw.METER_NO = row("meter_number").ToString
            rw.INSTALLATION_DATE = Date.Parse(row("installed_date"))
            rw.PARAMID = row("bill_param_id").ToString
            If row("rate_class").ToString = "RES" Then
                rw.RATE_CLASS = "RESIDENTIAL"
            Else
                rw.RATE_CLASS = "COMMERCIAL"
            End If


            If Not Convert.IsDBNull(row("previous_read")) Or Convert.IsDBNull(row("present_read")) Then
                rw.PRESENT_READING = Decimal.Parse(row("present_read"))
                rw.PREVIOUS_READING = Decimal.Parse(row("previous_read"))

                Dim adjustments As Decimal
                Decimal.TryParse(row("adjustments"), adjustments)

                rw.ADJUSTMENTS = adjustments

                rw.CONSUMPTION = Decimal.Parse(row("reading_cu"))

                'If row("reading_status").ToString = "NORMAL" Then
                '    rw.CONSUMPTION = (rw.PRESENT_READING - rw.PREVIOUS_READING).ToString("###0.0000")
                'Else

                'End If

                If adjustments <> 0 Or row("reading_status").ToString = "AVERAGE" Then
                    rw.REMARKS = row("reading_remarks").ToString
                End If

                rw.READING_PERIOD = Date.Parse(row("previous_read_date")).ToString("dd-MMM-yyyy") & _
                                                    " to " & Date.Parse(row("reading_date")).ToString("dd-MMM-yyyy")

                GetConsumptionBlock(rw.CONSUMPTION, rw.PARAMID, rw.RATE_CLASS, rw.CONS_BLOCK1, rw.CONS_BLOCK2, rw.CONS_RATE1, rw.CONS_RATE2)

                dtMeterReading.Rows.Add(rw)
            End If
        Next
        dtMeterReading.AcceptChanges()

    End Sub

    Private Sub GetConsumptionBlock(ByVal consumption As Decimal, ByVal paramID As String, ByVal rateClass As String, ByRef cons_block1 As String, ByRef cons_block2 As String, ByRef cons_rate1 As String, ByRef cons_rate2 As String)

        Dim query As String

        query = "SELECT w_cons_table    " & _
                "  FROM utl_water_bill_parameter             " & _
                " WHERE bill_param_id = :paramid              "

        Dim withConsumptionBlock As Boolean

        Using params As New OraParameter
            params.AddItem(":paramid", paramID)
            withConsumptionBlock = IIf(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection).ToString = "Y", True, False)
        End Using

        Dim from_cons As Decimal
        Dim to_cons As Decimal
        Dim min_consumption As Decimal
        Dim max_consumption As Decimal
        Dim min_charge As Decimal
        Dim rate As Decimal


        If withConsumptionBlock Then
            If _currentparamid <> paramID Then
                dtConsumptionTable = WaterConsumptionBlock.GetConsumptionTables(paramID)
            End If

            Dim rClass As String = IIf(rateClass.ToUpper = "RESIDENTIAL", "RES", "COMM")

            Using dv As DataView = dtConsumptionTable.DefaultView
                'get min consumption
                dv.RowFilter = "min_rate ='Y' AND rate_class ='" & rClass & "'"
                With dv.Item(0)
                    min_consumption = Decimal.Parse(.Item("to_cons"))
                    from_cons = Decimal.Parse(.Item("from_cons"))
                    to_cons = Decimal.Parse(.Item("to_cons"))
                    min_charge = Decimal.Parse(.Item("rate"))
                End With
            End Using

            If consumption <= min_consumption Then
                cons_block1 = String.Format("{0:###0.00} - {1:###0.0000} cu.m.", from_cons, to_cons)
                cons_rate1 = String.Format("{0:###0.00} flat rate", min_charge)
            Else

                Using dv As New DataView(dtConsumptionTable)
                    'get min consumption
                    dv.RowFilter = "ISNULL(to_cons,0)=0 AND (rate_class ='" & rClass & "')"
                    With dv.Item(0)
                        max_consumption = Decimal.Parse(.Item("from_cons"))
                        rate = Decimal.Parse(.Item("rate"))
                    End With
                End Using

                If consumption >= max_consumption Then
                    cons_block1 = String.Format("Over {0:###0.0000} cu.m.", max_consumption)
                    cons_rate1 = String.Format("{0:###0.00} per cu.m.", rate)
                Else
                    Using dv As New DataView(dtConsumptionTable)
                        'get min consumption
                        dv.RowFilter = "from_cons <= " & consumption & " and to_cons>= " & consumption & " AND rate_class ='" & rClass & "'"
                        With dv.Item(0)
                            from_cons = Decimal.Parse(.Item("from_cons"))
                            to_cons = Decimal.Parse(.Item("to_cons"))
                            rate = Decimal.Parse(.Item("rate"))
                        End With
                    End Using

                    cons_block1 = String.Format("{0:#,##0.0000} - {1:#,##0.0000} cu.m.", from_cons, to_cons)
                    cons_rate1 = String.Format("{0:#,##0.00} per cu.m.", rate)
                End If
            End If



        Else
            query = "SELECT min_consumption, min_charge, rate" & _
                                   "  FROM utl_water_bill_parameter         " & _
                                   " WHERE bill_param_id = :paramid         "


            Using params As New OraParameter
                params.AddItem(":paramid", paramID)
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    min_consumption = Decimal.Parse(.Rows(0)("min_consumption"))
                    min_charge = Decimal.Parse(.Rows(0)("min_charge"))
                    rate = Decimal.Parse(.Rows(0)("rate"))

                End With
            End Using

            cons_block1 = String.Format("{0:#,###.00} cu.m. or less", min_consumption)
            cons_rate1 = String.Format("{0:#,###.00} flat rate", min_charge)

            cons_block2 = String.Format("more than {0:#,###.00} cu.m.", min_consumption)
            cons_rate2 = String.Format("{0:#,###.00} per cu.m.", rate)

        End If



    End Sub

    Private Function GetMeterReadingsByBillingDate(ByVal billingdate As Date) As DataTable
        Dim query As String
        'query = "SELECT cust_acct_id, md.meter_id, meter_number, installed_date, present_read,                                     " & _
        '        "       reading_date, previous_read, previous_read_date, adjustments,                                              " & _
        '        "       reading_remarks                                                                                            " & _
        '        "  FROM meter_details md                                                                                           " & _
        '        "       JOIN                                                                                                       " & _
        '        "       (SELECT meter_id, reading present_read, reading_date,                                                      " & _
        '        "               reading_adjustment adjustments, reading_remarks,                                                   " & _
        '        "               (SELECT DISTINCT FIRST_VALUE (reading) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)     " & _
        '        "                           FROM meter_readings                                                                    " & _
        '        "                          WHERE reading_date < mr.reading_date                                                    " & _
        '        "                            AND meter_id = mr.meter_id) previous_read,                                            " & _
        '        "               (SELECT DISTINCT FIRST_VALUE (reading_date) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)" & _
        '        "                           FROM meter_readings                                                                    " & _
        '        "                          WHERE reading_date <                                                                    " & _
        '        "                                           mr.reading_date                                                        " & _
        '        "                            AND meter_id = mr.meter_id) previous_read_date                                        " & _
        '        "          FROM meter_readings mr                                                                                  " & _
        '        "         WHERE reading_date BETWEEN fday_ofmonth (:billingdate)                                                   " & _
        '        "                                AND LAST_DAY (:billingdate)                                                       " & _
        '        "           AND reading_status <> 'DISC') ms ON (md.meter_id = ms.meter_id)                                        " & _
        '        " WHERE connection_status <> 'NEW'                                                                                 "

        query = "SELECT (SELECT account_id                                                                                         " & _
                "          FROM customer_accounts                                                                                  " & _
                "         WHERE account_status = 'ACT'                                                                             " & _
                "           AND unit_id IN (SELECT unit_id                                                                         " & _
                "                             FROM utl_meter_detail                                                                " & _
                "                            WHERE meter_id = md.meter_id)) cust_acct_id,                                          " & _
                "       (SELECT unit_subclass                                                                                      " & _
                "          FROM am_unit                                                                                            " & _
                "         WHERE unit_id IN (SELECT unit_id                                                                         " & _
                "                             FROM utl_meter_detail                                                                " & _
                "                            WHERE meter_id = md.meter_id)) rate_class,                                            " & _
                "       md.meter_id, md.meter_number, md.installed_date, ms.present_read,                                          " & _
                "       ms.reading_date, ms.previous_read, ms.previous_read_date,                                                  " & _
                "       ms.adjustments, ms.reading_remarks,ms.bill_param_id,ms.reading_status ,ms.reading_cu                                                                       " & _
                "  FROM utl_meter_detail md                                                                                        " & _
                "       JOIN                                                                                                       " & _
                "       (SELECT meter_id, reading present_read, reading_date, reading_status, reading_cu,                                                    " & _
                "               reading_adjustment adjustments, reading_remarks,                                                   " & _
                "               (SELECT DISTINCT FIRST_VALUE (reading) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)     " & _
                "                           FROM utl_meter_reading                                                                 " & _
                "                          WHERE reading_date < mr.reading_date                                                    " & _
                "                            AND meter_id = mr.meter_id) previous_read,                                            " & _
                "               (SELECT DISTINCT FIRST_VALUE (reading_date) OVER (PARTITION BY meter_id ORDER BY reading_date DESC)" & _
                "                           FROM utl_meter_reading                                                                 " & _
                "                          WHERE reading_date <                                                                    " & _
                "                                           mr.reading_date                                                        " & _
                "                            AND meter_id = mr.meter_id) previous_read_date ,bill_param_id                                       " & _
                "          FROM utl_meter_reading mr                                                                               " & _
                "         WHERE reading_date BETWEEN fday_ofmonth (:billdate)                                                      " & _
                "                                AND LAST_DAY (:billdate)                                                          " & _
                "           AND reading_status IN ('NORMAL', 'AVERAGE') AND BILLED ='Y') ms                                                        " & _
                "       ON (md.meter_id = ms.meter_id)                                                                             " & _
                " WHERE connection_status <> 'INACT'                                                                               "

        Using params As New OraParameter
            params.AddItem(":billdate", billingdate, OracleDbType.Date)
            Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

        End Using

    End Function

End Class
