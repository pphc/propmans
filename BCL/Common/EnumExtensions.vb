Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports System.Linq


Namespace Common


    <AttributeUsage(AttributeTargets.Enum Or AttributeTargets.Field)> _
    Public Class EnumDisplayName
        Inherits Attribute
        Dim m_DisplayName As String = String.Empty
        Public Sub New(ByVal DisplayName As String)
            m_DisplayName = DisplayName
        End Sub
        Public Overrides Function ToString() As String
            Return m_DisplayName
        End Function
    End Class

    <AttributeUsage(AttributeTargets.Enum Or AttributeTargets.Field)> _
    Public Class EnumDBValue
        Inherits Attribute
        Dim m_DBValue As String = String.Empty
        Public Sub New(ByVal DBValue As String)
            m_DBValue = DBValue
        End Sub
        Public Overrides Function ToString() As String
            Return m_DBValue
        End Function
    End Class

    Public Class EnumItem
        Public Property Name As String
        Public Property Value As Integer
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Module EnumExtensions

        'Return the Enum entry for the specified string
        'TryParse is case-sensitive, so use LINQ instead
        Public Function Entry(Of T)(ByVal dbvalue As String) As T
            Dim fis As MemberInfo() = GetType(T).GetFields()

            For Each fi As FieldInfo In fis
                Dim attr As Attribute = Attribute.GetCustomAttribute(fi, GetType(EnumDBValue))
                If Not attr Is Nothing And TypeOf attr Is EnumDBValue Then
                    If DirectCast(attr, EnumDBValue).ToString = dbvalue Then
                        Return DirectCast([Enum].Parse(GetType(T), fi.Name), T)
                    End If
                End If
            Next

            Throw New Exception("Not found")
        End Function


        Public Function StringAttribute(ByVal Value As [Enum], ByVal AttributeName As String) As String
            Dim Result = String.Empty
            Dim Field As FieldInfo = Value.GetType.GetField(Value.ToString, BindingFlags.GetField Or BindingFlags.Public Or BindingFlags.Static)
            '' Dim attribs = Field.GetCustomAttributes(True)
            Dim dn = (From item In Field.GetCustomAttributes(True) Where item.GetType().Name = AttributeName Select item).FirstOrDefault
            If (Not IsNothing(dn)) Then Result = dn.ToString
            Return Result
        End Function

        <Extension()> _
        Public Function DisplayName(ByVal Value As [Enum]) As String
            Dim Result = StringAttribute(Value, "EnumDisplayName")
            Return Result
        End Function

        <Extension()> _
        Public Function DBVAlue(ByVal Value As [Enum]) As String
            Dim Result = StringAttribute(Value, "EnumDBValue")
            Return Result
        End Function


        'Move to separate function to avoid issue with late binding when Option Strict On
        Public Function GetNames(s As [Enum]) As String()
            Return CType([Enum].GetNames(s.GetType), String())
        End Function

        ''Move to separate function to avoid issue with late binding when Option Strict On

        <Extension()> _
        Public Function ItemList(ByVal s As [Enum], ByVal IncludeUnknown As Boolean, ByVal UseDisplayName As Boolean) As List(Of EnumItem)
            Dim Result As New List(Of EnumItem)
            Dim names = GetNames(s)
            Dim values = [Enum].GetValues(s.GetType)
            For i As Integer = 0 To names.Length - 1
                If (IncludeUnknown OrElse names(i).ToLower <> "unknown") Then
                    If (UseDisplayName) Then
                        Dim itemName = DisplayName(CType(values(i), [Enum]))
                        Result.Add(New EnumItem With {.Name = itemName, .Value = values(i)})
                    Else
                        Result.Add(New EnumItem With {.Name = names(i), .Value = values(i)})
                    End If
                End If
            Next
            Return Result
        End Function
    End Module

End Namespace
