'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 06-23-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 06-24-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports BCL.Utils
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD

Public Class ctlUnitInventoryOption

#Region "Public Properties"
    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property BldgList As String
        Get
            Dim Id As String

            Dim IdMerge As String

            For Each item As Object In chklistBox.CheckedItems
                Id = item.DisplayValue
                If chklistBox.CheckedItems.Count = 1 Then
                    IdMerge = Id
                Else
                    If IdMerge = String.Empty Then
                        IdMerge = Id
                    Else
                        IdMerge = IdMerge + "," + Id
                    End If
                End If
            Next

            Return IdMerge
        End Get
    End Property
#End Region

#Region "User Control Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Common.BindCheckListBoxtoList(chklistBox, New LoadBuildingNameSpace.LoadBuildingListSource)
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then
            For idx As Integer = 0 To Me.chklistBox.Items.Count - 1
                Me.chklistBox.SetItemCheckState(idx, CheckState.Checked)
            Next
        Else
            For idx As Integer = 0 To Me.chklistBox.Items.Count - 1
                Me.chklistBox.SetItemCheckState(idx, CheckState.Unchecked)
            Next
        End If
    End Sub


#End Region

#Region "Local Procedures"



#End Region

  
End Class
