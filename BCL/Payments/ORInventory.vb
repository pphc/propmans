'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 06-16-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports DALC
Imports BCL.Utils

Namespace Payments



    Public NotInheritable Class ORInventory


        Public Shared Function GetInventoryByDivision(ByVal division As CompanyDivision) As DataTable
            Dim query As String = "SELECT batch_id, start_number, end_number, date_received " & _
                                    "  FROM or_inventory                                      " & _
                                    " WHERE company = :division                               "

            Using params As New OraParameter

                params.AddParameter("division", EnumHelper.GetDBValue(division))

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function SaveSeries(ByVal startOR As String, ByVal endOR As String, ByVal dateReceived As Date, ByVal division As CompanyDivision, ByVal remarks As String) As Integer

            Dim query As String = "INSERT INTO or_inventory                                              " & _
                                    "            (start_number, end_number, date_received, company, remarks" & _
                                    "            )                                                         " & _
                                    "     VALUES (:startor, :endor, :datereceived, :division, :remarks      " & _
                                    "            )                                                         "
            Using params As New OraParameter

                params.AddParameter("startor", startOR)
                params.AddParameter("endor", endOR)
                params.AddParameter("datereceived", dateReceived, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddParameter("division", EnumHelper.GetDBValue(division))
                params.AddParameter("remarks", remarks)

                Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

            End Using
        End Function
    End Class
End Namespace


