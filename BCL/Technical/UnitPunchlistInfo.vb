Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common
Imports System.Linq
Imports System.Text

Namespace Technical

    Public Class UnitPunchlistInfo
        Public UnitID As String
        Public AccountID As String

        Public CMDTurnOverDate As Nullable(Of Date)
        Public LatestOwnerInspectionDate As Nullable(Of Date)
        Public UnitOwnerAcceptanceDate As Nullable(Of Date)

        Public Punchlist As List(Of UnitPunchlist)
    End Class

    Public Class UnitPunchlstDetailsInfo

        Public punchlistdetailsid As String
        Public punchlistCriteria As PunchlistTemplate
        Public ReadOnly Property Criteria As String
            Get
                Return punchlistCriteria.Description
            End Get
        End Property

        Public Property InGoodCondition As List(Of KeyValuePair(Of String, String))

        Public Property FunctionalityDefects As DefectsCategoryInfo
        Public Property InstallationDefects As DefectsCategoryInfo
        Public Property FInishingDefects As DefectsCategoryInfo
    End Class

    Public Class UnitPunchlistDetailReportInfo
        Public Property ParticularName As String
        Public Property ClassType As String
        Public Property InAcceptableCondition As String
        Public Property Remarks As String
    End Class

#Region "Main Table Class"

    Public Class DefectsCategoryInfo
        Public Property AffectedItem As List(Of KeyValuePair(Of String, String))

        Public Property ItemDefect As List(Of KeyValuePair(Of String, String))

        Public Property Remarks
    End Class

    Public Class PunchlistTemplate
        Public Property ID As String
        Public Property Description As String
        Public Property Rank As Integer
        Public Property IsCriteria As Boolean
        Public Property IsActive As Boolean
        Public Property Parent As PunchlistTemplate
        Public ReadOnly Property ParentID As String
            Get
                If IsNothing(Me.Parent) Then
                    Return String.Empty
                Else
                    Return Me.Parent.ID
                End If
            End Get
        End Property
    End Class

    Public Class PunchlistItem
        Public Property ID As String
        Public Property Description As String
        Public Property Rank As Integer
        Public Property IsActive As Boolean
        Public Property Parent As PunchlistTemplate
    End Class

    Public Class PunchlistDefect
        Public Property ID As String
        Public Property Description As String
        Public Property FindingsCategory As String
        Public Property IsActive As Boolean
    End Class

    Public Class UnitPunchlist
        Public Property PunchlistID As String
        Public Property PunchlistType As String
        Public Property InspectionDate As Date
        Public ReadOnly Property InspectionInstance As String
            Get
                Return InspectionDate.ToString("MM/dd/yyyy")
            End Get
        End Property

        Public Property InspectedBy As String
        Public Property Remarks As String
        Public Property PunchlistDetails As New List(Of PunchlistDetail)
    End Class

    Public Class PunchlistDetail
        Public Property DetailsID As String
        Public Property PunchlistInfo As UnitPunchlist
        Public Property Criteria As PunchlistTemplate
        Public Property ItemStatus As String
        Public Property Remarks As String
        Public Property Findings As New List(Of PunchlistFinding)
    End Class

    Public Class PunchlistFinding
        Public Property FindingID As String
        Public Property FindingsCategory As String
        Public Property Item As PunchlistItem
        Public Property Defect As PunchlistDefect
        Public Property Remarks As String
    End Class

#End Region

    Public Class UnitPunchlistDA

        Private punchlistTemplate As List(Of PunchlistTemplate)
        Private punchlistItem As List(Of PunchlistItem)
        Private punchlistDefect As List(Of PunchlistDefect)

        Public Sub New()
            LoadPunchlistTemplate()
            LoadPunchlistItem()
            LoadPunchlistDefect()
        End Sub

        Private Sub LoadPunchlistTemplate()
            punchlistTemplate = New List(Of PunchlistTemplate)
            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getpunchlisttemplate", param.GetParameterCollection).Rows
                    punchlistTemplate.Add(New PunchlistTemplate With {.ID = row("particular_id").ToString,
                                                                       .Description = row("particular_description").ToString,
                                                                       .Rank = Integer.Parse(row("rank").ToString),
                                                                       .IsCriteria = IIf(row("is_criteria").ToString = "Y", True, False),
                                                                       .IsActive = IIf(row("is_active").ToString = "Y", True, False),
                    .Parent = IIf(IsDBNull(row("parent_id")), Nothing, New PunchlistTemplate With {.ID = row("parent_id").ToString})})
                Next
                For Each template As PunchlistTemplate In punchlistTemplate
                    If Not IsNothing(template.Parent) Then
                        template.Parent = GetTemplateItemByID(template.Parent.ID)
                    End If
                Next
            End Using
        End Sub

        Private Sub LoadPunchlistItem()
            punchlistItem = New List(Of PunchlistItem)
            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getpunchlistitem", param.GetParameterCollection).Rows
                    punchlistItem.Add(New PunchlistItem With {.ID = row("item_id").ToString,
                                                                .Description = row("item_description").ToString,
                                                                .IsActive = IIf(row("is_active").ToString = "Y", True, False),
                                                                .Parent = IIf(IsDBNull(row("particular_id")), Nothing, GetTemplateItemByID(row("particular_id").ToString))
                                                             })
                Next
            End Using
        End Sub

        Private Sub LoadPunchlistDefect()
            punchlistDefect = New List(Of PunchlistDefect)
            Using param As New OraParameter
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getpunchlistdefect", param.GetParameterCollection).Rows
                    punchlistDefect.Add(New PunchlistDefect With {.ID = row("defect_id").ToString,
                                                                .Description = row("description").ToString,
                                                                .FindingsCategory = row("findings_category").ToString,
                                                                .IsActive = IIf(row("is_active").ToString = "Y", True, False)})
                Next
            End Using
        End Sub

        Private Function GetTemplateItemByID(templateid As String) As PunchlistTemplate
            Return (From temp In punchlistTemplate
                    Where temp.ID = templateid
                    Select temp).Single
        End Function

        Public Function GetTopParentTemplate() As List(Of KeyValuePair(Of String, String))
            Return (From list In punchlistTemplate
                   Where list.Parent Is Nothing And list.IsActive = True
                   Order By list.Rank
                   Select list).Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList

        End Function

        Public Function GetChildTemplate(templateID As String) As List(Of KeyValuePair(Of String, String))
            Return (From list In punchlistTemplate
            Where list.ParentID.Equals(templateID) And list.IsCriteria = False And list.IsActive = True
             Order By list.Rank
             Select list).Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList
        End Function


        Public Function GetTemplateCriteria() As List(Of PunchlistTemplate)
            Return (From list In punchlistTemplate
                Where list.IsCriteria = True And list.IsActive = True
                Order By list.Parent.Rank, list.Rank
                Select list).ToList
        End Function

        Public Function GetFindingsAreaCategory() As List(Of KeyValuePair(Of String, String))
            Dim list As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            list.Add(New KeyValuePair(Of String, String)("FUN", "FUNCTIONALITY"))
            list.Add(New KeyValuePair(Of String, String)("INS", "INSTALLATION"))
            list.Add(New KeyValuePair(Of String, String)("FIN", "FINISHING"))

            Return list
        End Function

        Public Function GetConditionalChoices() As List(Of KeyValuePair(Of String, String))
            Dim list As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            list.Add(New KeyValuePair(Of String, String)("NA", "NOT APPLICABLE"))
            list.Add(New KeyValuePair(Of String, String)("Y", "YES"))
            list.Add(New KeyValuePair(Of String, String)("N", "NO"))

            Return list
        End Function

        Private Function GetAffectedItemByCriteriaID(criteriaID As String) As List(Of PunchlistItem)
            Return (From item In punchlistItem
                   Where item.Parent.ID = GetTopParentID(criteriaID).ID
                   Select item).ToList
        End Function

        Private Function GetTopParentID(criteriaID As String) As PunchlistTemplate
            Dim temp As PunchlistTemplate = (From template In punchlistTemplate
                                                Where template.ID.Equals(criteriaID)
                                                Select template).Single
            If Not IsNothing(temp.Parent) Then
                temp = GetTopParentID(temp.Parent.ID)
            End If

            Return temp
        End Function

        Private Function GetItemDefectsByDefectCat(defectCategory As String) As List(Of PunchlistDefect)

            Return (From defect In punchlistDefect
                   Where defect.FindingsCategory.Equals(defectCategory)
                   Select defect).ToList
        End Function

        Public Function GetPunchlistByID(punchlistID As String) As UnitPunchlist
            Dim punchlist As New UnitPunchlist
            Dim punchlistfinding As New List(Of PunchlistFinding)

            Using param As New OraParameter
                param.AddParameter("punchlistid", punchlistID, OracleDbType.Int32)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)
                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getpunchlistfinding", param.GetParameterCollection).Rows
                    punchlistfinding.Add(New PunchlistFinding With {.Item = New PunchlistItem With {.ID = row("item_id").ToString},
                                                                    .Defect = New PunchlistDefect With {.ID = row("defect_id").ToString},
                                                                    .Remarks = row("remarks").ToString,
                                                                    .FindingsCategory = row("finding_cat").ToString,
                                                                    .FindingID = row("punchlist_details_id").ToString})
                Next
            End Using

            Using param As New OraParameter
                param.AddParameter("punchlistid", punchlistID, OracleDbType.Int32)
                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)
                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getpunchlistdetail", param.GetParameterCollection).Rows

                    Dim fd As New List(Of PunchlistFinding)

                    fd = (From d In punchlistfinding
                         Where d.FindingID.Equals(row("punchlist_details_id").ToString)
                         Select d).ToList

                    'Dim pd As New PunchlistDetail

                    'pd.DetailsID = row("punchlist_details_id").ToString
                    'pd.Criteria = New PunchlistTemplate With {.ID = row("particular_id").ToString}
                    'pd.ItemStatus = row("item_status").ToString
                    'pd.Findings = New List(Of PunchlistFinding)
                    'pd.Findings = fd


                    'punchlist.PunchlistDetails.Add(pd)

                    punchlist.PunchlistDetails.Add(New PunchlistDetail With {.DetailsID = row("punchlist_details_id").ToString,
                                                                              .Criteria = New PunchlistTemplate With {.ID = row("particular_id").ToString},
                                                                              .ItemStatus = row("item_status").ToString,
                                                                              .Findings = fd}
                                                                              )
                Next
            End Using

            Return punchlist
        End Function

        Public Function GetPunchlistTemplate() As List(Of UnitPunchlstDetailsInfo)
            Dim itemCriteria As New List(Of UnitPunchlstDetailsInfo)

            Dim kvr As New KeyValuePair(Of String, String)("-1", "NOT APPLICABLE")

            For Each template As PunchlistTemplate In GetTemplateCriteria()
                Dim kvrAffectedItem As List(Of KeyValuePair(Of String, String)) = Me.GetAffectedItemByCriteriaID(template.ParentID).Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList
                kvrAffectedItem.Insert(0, kvr)

                Dim kvrFunctionalityDefects As List(Of KeyValuePair(Of String, String)) = Me.GetItemDefectsByDefectCat("FUN").Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList
                kvrFunctionalityDefects.Insert(0, kvr)

                Dim kvrInstallationDefects As List(Of KeyValuePair(Of String, String)) = Me.GetItemDefectsByDefectCat("INS").Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList
                kvrInstallationDefects.Insert(0, kvr)

                Dim kvrFInishingDefects As List(Of KeyValuePair(Of String, String)) = Me.GetItemDefectsByDefectCat("FIN").Select(Function(x) New KeyValuePair(Of String, String)(x.ID, x.Description)).ToList
                kvrFInishingDefects.Insert(0, kvr)

                itemCriteria.Add(New UnitPunchlstDetailsInfo With {.punchlistCriteria = template,
                                                                    .InGoodCondition = Me.GetConditionalChoices,
                                                                    .FunctionalityDefects = New DefectsCategoryInfo With {.AffectedItem = kvrAffectedItem,
                                                                                                                         .ItemDefect = kvrFunctionalityDefects,
                                                                                                                         .Remarks = String.Empty},
                                                                    .InstallationDefects = New DefectsCategoryInfo With {.AffectedItem = kvrAffectedItem,
                                                                                                                         .ItemDefect = kvrInstallationDefects,
                                                                                                                         .Remarks = String.Empty},
                                                                    .FInishingDefects = New DefectsCategoryInfo With {.AffectedItem = kvrAffectedItem,
                                                                                                                         .ItemDefect = kvrFInishingDefects,
                                                                                                                         .Remarks = String.Empty}
                                                                    })
            Next

            Return itemCriteria
        End Function

        Public Function LoadPunchlistDetails(unit As BCL.Accounts.UnitInventory) As UnitPunchlistInfo
            Dim unitpunchlist As New UnitPunchlistInfo

            GetCMDTurnOverDAte(unit.UnitID)
            unitpunchlist.CMDTurnOverDate = GetCMDTurnOverDAte(unit.UnitID)

            If Not unit.OwnerAccount Is Nothing Then
                unitpunchlist.UnitOwnerAcceptanceDate = GetUnitAcceptanceDate(unit.OwnerAccount.AccountID)
                unitpunchlist.LatestOwnerInspectionDate = GetLatestUOInspectionDate(unit.OwnerAccount.AccountID)
            End If


            unitpunchlist.Punchlist = New List(Of UnitPunchlist)

            Using param As New OraParameter
                param.AddParameter("unitid", unit.UnitID)
                If Not unit.OwnerAccount Is Nothing Then
                    param.AddParameter("accountid", unit.OwnerAccount.AccountID)
                End If

                param.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                For Each row As DataRow In OraDBHelper2.ExecuteProcedureRefCursor("unit_punchlist.getunitpunchlist", param.GetParameterCollection).Rows
                    unitpunchlist.Punchlist.Add(New UnitPunchlist With {.PunchlistID = row("punchlist_id").ToString,
                                                                .InspectionDate = Date.Parse(row("inspection_date").ToString),
                                                                .InspectedBy = row("inspected_by").ToString,
                                                                .PunchlistType = row("inspection_type").ToString,
                                                                .Remarks = row("remarks").ToString}
                                                            )
                Next
            End Using

            Return unitpunchlist
        End Function

        Private Function GetCMDTurnOverDAte(unitID As String) As Nullable(Of Date)

            Dim query As String = "select cmd_turnover from am_unit where unit_id = :unitid "
            Using param As New OraParameter
                param.AddParameter("unitid", unitID)

                Dim x As String = OraDBHelper2.SqlExecuteScalar(query, param.GetParameterCollection).ToString

                If String.IsNullOrEmpty(x) Then
                    Return Nothing
                Else
                    Return Date.Parse(x)
                End If

            End Using

        End Function

        Private Function GetUnitAcceptanceDate(accountID As String) As Nullable(Of Date)

            Dim query As String = "select acceptance_date from customer_accounts where account_id = :accountid"
            Using param As New OraParameter
                param.AddParameter("accountid", accountID)
                Dim x As String = OraDBHelper2.SqlExecuteScalar(query, param.GetParameterCollection).ToString

                If String.IsNullOrEmpty(x) Then
                    Return Nothing
                Else
                    Return Date.Parse(x)
                End If

            End Using

        End Function

        Private Function GetLatestUOInspectionDate(accountID As String) As Nullable(Of Date)

            Dim query As String = "select max(inspection_date) from up_punchlist where account_id = :accountid"
            Using param As New OraParameter
                param.AddParameter("accountid", accountID)
                Dim x As String = OraDBHelper2.SqlExecuteScalar(query, param.GetParameterCollection).ToString

                If String.IsNullOrEmpty(x) Then
                    Return Nothing
                Else
                    Return Date.Parse(x)
                End If

            End Using

        End Function

        Public Function SavePunchlist(unitid As String, accountid As String, punchlist As UnitPunchlist) As String

            Using param As New OraParameter

                param.AddParameter("unitid", unitid)
                If Not String.IsNullOrEmpty(accountid) Then
                    param.AddParameter("accountid", accountid, OracleDbType.Int32)
                End If

                param.AddParameter("punchlisttype", punchlist.PunchlistType)
                param.AddParameter("inspectiondate", punchlist.InspectionDate, OracleDbType.Date)
                param.AddParameter("inspectedby", punchlist.InspectedBy)
                param.AddParameter("remarks", punchlist.Remarks)

                param.AddParameter("particularid", (From cri In punchlist.PunchlistDetails
                                                    Select cri.Criteria.ID).ToArray,
                                    OracleDbType.Int32, ParameterDirection.Input,
                                    True, 500)
                param.AddParameter("itemstatus", (From cri In punchlist.PunchlistDetails
                                                Select cri.ItemStatus).ToArray,
                                OracleDbType.Varchar2, ParameterDirection.Input,
                                True, 500)

                param.AddParameter("fun_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fun_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fun_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("ins_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("ins_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("ins_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("fin_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fin_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fin_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("punchlistid", Nothing, OracleDbType.Int32, ParameterDirection.ReturnValue)

                Return OraDBHelper2.ExecuteFunction("unit_punchlist.insertnewpunchlist", param.GetParameterCollection).ToString()
            End Using

        End Function

        Public Function UpdatePunchlist(punchlist As UnitPunchlist) As String

            Using param As New OraParameter

                param.AddParameter("punchlistid", punchlist.PunchlistID, OracleDbType.Int32)

                param.AddParameter("inspectiondate", punchlist.InspectionDate, OracleDbType.Date)
                param.AddParameter("inspectedby", punchlist.InspectedBy)
                param.AddParameter("remarks", punchlist.Remarks)

                param.AddParameter("punchlistdetailsid", (From cri In punchlist.PunchlistDetails
                                                    Select cri.DetailsID).ToArray,
                                    OracleDbType.Int32, ParameterDirection.Input,
                                    True, 500)
                param.AddParameter("itemstatus", (From cri In punchlist.PunchlistDetails
                                                Select cri.ItemStatus).ToArray,
                                OracleDbType.Varchar2, ParameterDirection.Input,
                                True, 500)

                param.AddParameter("fun_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fun_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fun_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FUN")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("ins_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("ins_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("ins_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("INS")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("fin_itemid", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Item.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fin_defect", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Defect.ID).ToArray,
                    OracleDbType.Int32, ParameterDirection.Input,
                    True, 500)
                param.AddParameter("fin_remarks", punchlist.PunchlistDetails.SelectMany(Function(z) z.Findings).Where(Function(y) y.FindingsCategory.Equals("FIN")).Select(Function(c) c.Remarks).ToArray,
                    OracleDbType.Varchar2, ParameterDirection.Input,
                    True, 500)

                param.AddParameter("rowsaffected", Nothing, OracleDbType.Int32, ParameterDirection.ReturnValue)

                Return OraDBHelper2.ExecuteFunction("unit_punchlist.updatepunchlist", param.GetParameterCollection).ToString()
            End Using
        End Function

        Public Function GetPunchlistReportData(punchlistdetails As List(Of PunchlistDetail)) As List(Of UnitPunchlistDetailReportInfo)
            Dim rep As New List(Of UnitPunchlistDetailReportInfo)
            Dim idx As Integer = 65
            For Each temp As PunchlistTemplate In punchlistTemplate.Where(Function(p) p.Parent Is Nothing).OrderBy(Function(x) x.Rank).ToList()



                rep.Add(New UnitPunchlistDetailReportInfo With {.ParticularName = String.Format("{0}. {1}", Convert.ToChar(idx), temp.Description),
                                                                  .ClassType = "PARENT",
                                                                  .InAcceptableCondition = "",
                                                                  .Remarks = ""})

                GetChild(temp.ID, rep, Convert.ToChar(idx), 2, punchlistdetails)
                idx += 1
            Next

            Return rep
        End Function

        Private Sub GetChild(parentid As String, ByRef rep As List(Of UnitPunchlistDetailReportInfo), idx As String, depth As Integer, punchlistdetails As List(Of PunchlistDetail))

            Dim subidx As Integer = 1
            For Each temp As PunchlistTemplate In punchlistTemplate.Where(Function(p) p.ParentID = parentid).OrderBy(Function(x) x.Rank).ToList()
                If temp.IsCriteria Then
                    Dim detail As PunchlistDetail = punchlistdetails.Where(Function(p) p.Criteria.ID.Equals(temp.ID)).Single()
                    Dim acceptablecondition As String

                    Select Case detail.ItemStatus
                        Case "Y"
                            acceptablecondition = "YES"
                        Case "N"
                            acceptablecondition = "NO"
                        Case Else
                            acceptablecondition = "N/A"
                    End Select

                    rep.Add(New UnitPunchlistDetailReportInfo With {.ParticularName = temp.Description.PadLeft(temp.Description.Length + (depth * 2), " "),
                                                             .ClassType = "CRITERIA",
                                                             .InAcceptableCondition = acceptablecondition,
                                                             .Remarks = GetRemarks(detail.Findings)})
                Else
                    Dim x As String = String.Format("{0}.{1} {2}", idx, subidx, temp.Description)
                    rep.Add(New UnitPunchlistDetailReportInfo With {.ParticularName = x.PadLeft(x.Length + depth, " "),
                                                             .ClassType = "SUBPARENT",
                                                             .InAcceptableCondition = "",
                                                             .Remarks = ""})
                    GetChild(temp.ID, rep, String.Format("{0}.{1}", idx, subidx), depth + 1, punchlistdetails)
                End If
                subidx += 1
            Next

        End Sub

        Private Function GetRemarks(findings As List(Of PunchlistFinding)) As String
            Dim remarks As New StringBuilder

            For Each finding As PunchlistFinding In findings
                remarks.Append(finding.Remarks)
                remarks.Append(";")
            Next


            Return remarks.ToString.TrimEnd(";")
        End Function

    End Class

End Namespace