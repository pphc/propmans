Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Imports System.Data

Imports System.Windows.Forms

Namespace LoadBuildingNameSpace

    Public Class LoadBuildingClass

        Public Shared Function LoadBuilding() As DataTable


            Dim query As String = "SELECT BLDG_ID,                       " & _
                                  "BLDG_NAME                             " & _
                                  "FROM AM_BUILDING                      " & _
                                  "ORDER BY TO_NUMBER(BLDG_NUMBER) ASC   "

            Return OraDBHelper2.GetResultSet(query)

        End Function
    End Class

    Public Class LoadBuildingListSource

        Inherits ListSource
        Public Sub New()

            Using dt As DataTable = LoadBuildingClass.LoadBuilding
                For Each dr As DataRow In dt.Rows
                    Me.AddItem(dr("BLDG_ID").ToString, dr("BLDG_NAME").ToString)
                Next

            End Using

        End Sub


    End Class



End Namespace
