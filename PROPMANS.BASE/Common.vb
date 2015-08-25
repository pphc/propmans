Imports ComponentFactory.Krypton.Toolkit
Imports System.Windows.Forms
Imports BCL.Common
Imports BCL.Utils

Public Class Common

    Public Shared Sub ClearFields(ByVal pnl As KryptonPanel)

        For Each ctrl As Control In pnl.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                DirectCast(ctrl, KryptonTextBox).Text = String.Empty
            ElseIf TypeOf ctrl Is KryptonLabel Then
                If DirectCast(ctrl, KryptonLabel).Tag = "variable" Then
                    DirectCast(ctrl, KryptonLabel).Text = String.Empty
                End If
            End If

        Next
    End Sub

    Public Shared Sub LockFields(ByVal pnl As KryptonPanel, ByVal lock As Boolean)

        For Each ctrl As Control In pnl.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                DirectCast(ctrl, KryptonTextBox).ReadOnly = lock
            End If

        Next
    End Sub

    Public Shared Sub Numeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = IsNumeric(e.KeyChar)
    End Sub

    Public Shared Sub Decimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = IsNumeric(DirectCast(sender, KryptonTextBox).Text, e.KeyChar, True)
    End Sub

    Public Shared Function IsNumeric(ByVal ch As Char) As Boolean

        If ch <> ChrW(Keys.Back) Then

            If Char.IsNumber(ch) Then
                Return False
            Else
                Return True
            End If

        End If
    End Function

    Public Shared Function IsNumeric(ByVal currentvalue As String, ByVal ch As Char, ByVal withDecimalpoint As Boolean) As Boolean
        If ch <> ChrW(Keys.Back) Then
            If withDecimalpoint Then
                If Char.IsNumber(ch) Or ch = "." Then
                    If ch = "." Then
                        If currentvalue.Length = 0 Then
                            Return True
                        Else
                            If currentvalue.Contains(".") Then
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    End If

                    Return False
                Else
                    Return True
                End If
            Else
                If Char.IsNumber(ch) Then
                    Return False
                Else
                    Return True
                End If
            End If
        End If

    End Function

    Public Shared Function HasValue(ByVal txtbox As KryptonTextBox) As Boolean
        Dim bhasValue As Boolean = False

        If txtbox.Text.Trim.Length > 0 Then
            bhasValue = True
        End If

        Return bhasValue
    End Function

    Public Shared Sub BindCheckListBoxtoList(ByRef CheckedListBox As Object, ByVal listType As ListSource, Optional insertSelect As Boolean = False)
        If insertSelect Then
            listType.List.Insert(0, New ItemLIst(-1, "SELECT"))
        End If
        CheckedListBox.DataSource = listType.List
        CheckedListBox.DisplayMember = "DisplayName"
        CheckedListBox.ValueMember = "DisplayValue"


    End Sub

    Public Shared Sub BindComboBoxtoList(ByRef comboBox As KryptonComboBox, ByVal listType As ListSource, Optional insertSelect As Boolean = False)
        If insertSelect Then
            listType.List.Insert(0, New ItemLIst(-1, "SELECT"))
        End If
        comboBox.DataSource = listType.List
        comboBox.DisplayMember = "DisplayName"
        comboBox.ValueMember = "DisplayValue"
    End Sub

    Public Shared Sub BindComboBoxtoList(ByRef comboBox As KryptonComboBox, ByVal enumType As Type, Optional insertSelect As Boolean = False)
        Dim list As ArrayList = EnumHelper.ToEnumValueList(enumType)

        If insertSelect Then
            list.Insert(0, New KeyValuePair(Of [Enum], String)(Nothing, "--SELECT--"))
        End If

        comboBox.DataSource = list
        comboBox.DisplayMember = "value"
        comboBox.ValueMember = "key"
    End Sub

    Public Shared Function ConvertDBValueToEnum(Of T)(ByVal dbValue As String) As T
        Try
            Return EnumHelper.GetEnumValueFromDBValue(Of T)(dbValue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function ConvertDescriptionValueToEnum(Of T)(ByVal description As String) As T
        Try
            Return EnumHelper.GetEnumValueFromDescription(Of T)(description)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function ConvertEnumtoDBValue(ByVal enumvalue As [Enum]) As String
        Try
            Return EnumHelper.GetDBValue(enumvalue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function ConvertEnumtoDescription(ByVal enumvalue As [Enum]) As String
        Try
            Return EnumHelper.GetDescription(enumvalue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
