Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class DisconnectionNoticeGridDisplay
    Inherits GridColumnBase


    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("cust_unit_no", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("cust_unit_sort"))
        Me.AddColumn(New TextboxColumn("cust_name", "UNIT OWNER"))
        Me.AddColumn(New TextboxColumn("latest_bill_date", "LATEST BILL DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("latest_bill_amt", "LATEST BILL AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("previous_unpaid", "PREVIOUS AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("total", "TOTAL UNPAID", New DecimalCellStyle(2)))
    End Sub

End Class
