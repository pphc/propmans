Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common

Public Class UnitInventoryReport
    Inherits ReportBase

    Public Property BldgList As String


    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property ReportName As String
        Get
            Return "UNIT INVENTORY"
        End Get
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()

    End Sub

    Private Sub LoadData()
        Try

            Dim query As String = "SELECT ap.PHASE_NAME PHASE_NO                              " & _
                                  "     , ab.BLDG_NAME ||' - '||  ac.CLUSTER_NAME  B_C_NAME   " & _
                                  "     , au.UNIT_ID                                          " & _
                                  "     , au.UNIT_NUMBER                                      " & _
                                  "     , accounts.getcurrentunitowner (au.UNIT_ID) OWNER     " & _
                                  "     , CASE au.UNIT_SUBCLASS                               " & _
                                  "      WHEN 'PARK' THEN 'PARKING'                           " & _
                                  "      WHEN 'RES' THEN 'RESIDENTIAL'                        " & _
                                  "      END  UNIT_TYPE                                       " & _
                                  "     , au.UNIT_AREA                                        " & _
                                  "     , au.SALE_STATUS                                      " & _
                                  "     , CASE au.OCCUPANCY_STATUS                            " & _
                                  "       WHEN 'OCC' THEN 'OCCUPIED'                          " & _
                                  "       WHEN 'VAC' THEN 'VACANT'                            " & _
                                  "       END OCCUPANCY_STATUS                                " & _
                                  "     , au.OCCUPANT                                         " & _
                                  "FROM AM_PHASE ap                                           " & _
                                  "INNER JOIN AM_BUILDING ab ON ap.PHASE_ID=ab.PHASE_ID       " & _
                                  "INNER JOIN AM_CLUSTER ac ON ab.BLDG_ID=ac.BLDG_ID          " & _
                                  "INNER JOIN AM_FLOOR af ON ac.CLUSTER_ID=af.CLUSTER_ID      " & _
                                  "INNER JOIN AM_UNIT au ON af.FLOOR_ID=au.FLOOR_ID           " & _
                                  "WHERE ab.BLDG_ID IN (" & BldgList & ")                  " & _
                                  "ORDER BY TO_NUMBER(ap.PHASE_NUMBER)                        " & _
                                  "       , TO_NUMBER(ab.BLDG_NUMBER)                         " & _
                                  "       , TO_NUMBER(ac.CLUSTER_NUMBER)                      " & _
                                  "       , au.UNIT_NUMBER ASC                                "

            Dim SubReport As String = "SELECT c.BLDG_LIST                                                                                 " & _
                                     "     , c.CLUSTER_NUMBER                                                                            " & _
                                     "     , c.CONDO                                                                                     " & _
                                     "     , DECODE(c.PARKING,'0','-',c.PARKING )PARKING                                                 " & _
                                     "FROM (                                                                                             " & _
                                     "        SELECT b.PHASE_NO ||' - '||b.BLDG_NAME BLDG_LIST                                           " & _
                                     "             , b.CLUSTER_NUMBER                                                                    " & _
                                     "             , b.CONDO                                                                             " & _
                                     "             , b.PARKING                                                                           " & _
                                     "        FROM(                                                                                      " & _
                                     "              SELECT a.PHASE_NO                                                                    " & _
                                     "                   , a.BLDG_NAME                                                                   " & _
                                     "                   , DECODE(a.BLDG_NAME,'ON-GRADE PARKING',0                                       " & _
                                     "                                      , 'PARKING BUILDING',0,COUNT(a.CLUSTER_NAME))CLUSTER_NUMBER  " & _
                                     "                   , DECODE(a.BLDG_NAME,'ON-GRADE PARKING','-'                                     " & _
                                     "                                      , 'PARKING BUILDING','-',SUM(a.UNIT_AREA)) CONDO             " & _
                                     "                   , DECODE(a.BLDG_NAME,'ON-GRADE PARKING',SUM(a.UNIT_AREA)                        " & _
                                     "                                      , 'PARKING BUILDING',SUM(a.UNIT_AREA),0) PARKING             " & _
                                     "              FROM (                                                                               " & _
                                     "                    SELECT ap.PHASE_NAME PHASE_NO                                                  " & _
                                     "                         , ab.BLDG_NAME                                                            " & _
                                     "                         , ac.CLUSTER_NAME                                                         " & _
                                     "                         , count(au.UNIT_AREA) UNIT_AREA                                           " & _
                                     "                    FROM AM_PHASE ap                                                               " & _
                                     "                    INNER JOIN AM_BUILDING ab ON ap.PHASE_ID=ab.PHASE_ID                           " & _
                                     "                    INNER JOIN AM_CLUSTER ac ON ab.BLDG_ID=ac.BLDG_ID                              " & _
                                     "                    INNER JOIN AM_FLOOR af ON ac.CLUSTER_ID=af.CLUSTER_ID                          " & _
                                     "                    INNER JOIN AM_UNIT au ON af.FLOOR_ID=au.FLOOR_ID                               " & _
                                     "                    WHERE ab.BLDG_ID IN (" & BldgList & ")                                      " & _
                                     "                    group by ap.PHASE_NAME                                                         " & _
                                     "                           , ab.BLDG_NAME                                                          " & _
                                     "                           , ac.CLUSTER_NAME                                                       " & _
                                     "                    ORDER BY ap.PHASE_NAME ASC                                                     " & _
                                     "        ) a                                                                                        " & _
                                     "        GROUP BY a.PHASE_NO,a.BLDG_NAME                                                            " & _
                                     "        ORDER BY a.PHASE_NO ASC) b                                                                 " & _
                                     ")c                                                                                                 "


            Using params As New OraParameter

                Using dt As DataTable = OraDBHelper2.GetResultSet(query), _
                          dtSub As DataTable = OraDBHelper2.GetResultSet(SubReport)

                    ReportDoc = New rptLoadBuilding
                    ReportDoc.SetDataSource(DirectCast(dt, DataTable))
                    ReportDoc.OpenSubreport("rptLoadBuildingSubReport.rpt").SetDataSource(DirectCast(dtSub, DataTable))

                End Using

            End Using




        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

        End Try
    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"

        End With
    End Sub
End Class
