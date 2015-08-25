Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class QuickbooksUploadGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("upload_id", "UPLOAD ID"))
        Me.AddColumn(New TextboxColumn("upload_date", "UPLOAD DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("cust_acct_update_cnt", "ACCOUNT UPDATES"))
        Me.AddColumn(New TextboxColumn("inv_update_cnt", "INVOICE UPDATES"))
        Me.AddColumn(New TextboxColumn("pay_update_cnt", "PAYMENT UPDATES"))
        Me.AddColumn(New TextboxColumn("pay_dep_from", "DEPOSIT FROM"))
        Me.AddColumn(New TextboxColumn("pay_dep_to", "DEPOSIT TO"))
        Me.AddColumn(New TextboxColumn("created_by", "CREATED BY"))
    End Sub
End Class
