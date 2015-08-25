'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 05-17-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 06-02-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Globalization




Namespace Utils


    <AttributeUsage(AttributeTargets.Enum Or AttributeTargets.Field, AllowMultiple:=False)> _
    Public NotInheritable Class EnumDescriptionAttribute
        Inherits Attribute
        Private _description As String
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property
        Public Sub New(ByVal description As String)
            MyBase.New()
            _description = description
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.Enum Or AttributeTargets.Field, AllowMultiple:=False)> _
    Public NotInheritable Class EnumDBValueAttribute
        Inherits Attribute
        Private _value As String
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
        Public Sub New(ByVal dbvalue As String)
            MyBase.New()
            _value = dbvalue
        End Sub
    End Class

    Public NotInheritable Class EnumHelper

        Public Shared Function GetDescription(ByVal value As [Enum]) As String
            If IsNothing(value) Then
                Throw New ArgumentNullException("value")
            End If

            Dim description As String = value.ToString()
            Dim fieldInfo As FieldInfo = value.GetType().GetField(description)

            Dim attr As EnumDescriptionAttribute = CType(Attribute.GetCustomAttribute(fieldInfo, GetType(EnumDescriptionAttribute)), EnumDescriptionAttribute)

            If Not attr Is Nothing Then
                Return attr.Description
            Else
                Return description
            End If

        End Function

        Public Shared Function GetDBValue(ByVal value As [Enum]) As String
            If IsNothing(value) Then
                Throw New ArgumentNullException("value")
            End If
            Dim description As String = value.ToString()
            Dim fieldInfo As FieldInfo = value.GetType().GetField(description)


            Dim attr As EnumDBValueAttribute = CType(Attribute.GetCustomAttribute(fieldInfo, GetType(EnumDBValueAttribute)), EnumDBValueAttribute)

            If Not attr Is Nothing Then
                Return attr.Value
            Else
                Return description
            End If

        End Function

        Public Shared Function GetEnumValueFromDBValue(Of T)(ByVal description As String) As T
            Dim fis As MemberInfo() = GetType(T).GetFields()

            For Each fi As FieldInfo In fis
                Dim attr As Attribute = Attribute.GetCustomAttribute(fi, GetType(EnumDBValueAttribute))
                If Not attr Is Nothing And TypeOf attr Is EnumDBValueAttribute Then
                    If DirectCast(attr, EnumDBValueAttribute).Value = description Then
                        Return DirectCast([Enum].Parse(GetType(T), fi.Name), T)
                    End If
                End If
            Next

            Throw New Exception("Not found")

        End Function

        Public Shared Function GetEnumValueFromDescription(Of T)(ByVal description As String) As T
            Dim fis As MemberInfo() = GetType(T).GetFields()

            For Each fi As FieldInfo In fis
                Dim attr As Attribute = Attribute.GetCustomAttribute(fi, GetType(EnumDescriptionAttribute))
                If Not attr Is Nothing And TypeOf attr Is EnumDescriptionAttribute Then
                    If DirectCast(attr, EnumDescriptionAttribute).Description = description Then
                        Return DirectCast([Enum].Parse(GetType(T), fi.Name), T)
                    End If
                End If
            Next

            Throw New Exception("Not found")

        End Function

        Public Shared Function ToEnumValueList(ByVal type As Type) As IList
            If IsNothing(type) Then
                Throw New ArgumentNullException("type")
            End If
            Dim list As New ArrayList
            Dim enumValues As Array = [Enum].GetValues(type)
            For Each value As [Enum] In enumValues
                list.Add(New KeyValuePair(Of [Enum], String)(value, GetDescription(value)))
            Next
            Return list
        End Function

        Private Sub AddItem(ByVal list As IList, ByVal type As Type, ByVal valueMember As String, ByVal displayMember As String, _
        ByVal displayText As String)

            Dim obj As Object = Activator.CreateInstance(type)

            Dim displayProperty As PropertyInfo = type.GetProperty(displayMember)

            displayProperty.SetValue(obj, displayText, Nothing)

            Dim valueProperty As PropertyInfo = type.GetProperty(valueMember)

            valueProperty.SetValue(obj, -1, Nothing)

            list.Insert(0, obj)
        End Sub

       
    End Class

    Namespace Extension

        Public Class EnumDescriptionTypeConverter
            Inherits EnumConverter
            Public Sub New(ByVal type As Type)
                MyBase.New(type)
            End Sub

            Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
                Return sourceType Is GetType(String) OrElse TypeDescriptor.GetConverter(GetType([Enum])).CanConvertFrom(context, sourceType)
            End Function

            Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
                If TypeOf value Is String Then
                    Return GetEnumValue(EnumType, DirectCast(value, String))
                End If
                If TypeOf value Is [Enum] Then
                    Return GetEnumDescription(DirectCast(value, [Enum]))
                End If
                Return MyBase.ConvertFrom(context, culture, value)
            End Function

            Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
                Return IIf(CBool(IIf(TypeOf value Is [Enum] AndAlso destinationType Is GetType(String), _
                            GetEnumDescription(DirectCast(value, [Enum])), _
                            TypeOf value Is String AndAlso destinationType Is GetType(String))), _
                            GetEnumDescription(EnumType, DirectCast(value, String)), _
                            MyBase.ConvertTo(context, culture, value, destinationType))

            End Function

            Public Shared Function GetEnumDescription(ByVal value As [Enum]) As String
                Dim FieldInfo As FieldInfo = value.GetType().GetField(value.ToString)
                Dim attributes As DescriptionAttribute() = DirectCast(FieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
                Return IIf(attributes.Length > 0, _
                            attributes(0).Description, _
                            value.ToString).ToString
            End Function

            Public Shared Function GetEnumDescription(ByVal value As Type, ByVal name As String) As String
                Dim fieldInfo As FieldInfo = value.GetField(name)
                Dim attributes As DescriptionAttribute() = DirectCast(fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
                Return IIf(attributes.Length > 0, _
                            attributes(0).Description, _
                            name).ToString
            End Function

            Public Shared Function GetEnumValue(ByVal value As Type, ByVal description As String) As Object
                Dim fields As FieldInfo() = value.GetFields()
                For Each fieldInfo As FieldInfo In fields
                    Dim attributes As DescriptionAttribute() = DirectCast(fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
                    If attributes.Length > 0 AndAlso attributes(0).Description = description Then
                        Return fieldInfo.GetValue(fieldInfo.Name)
                    End If
                    If fieldInfo.Name = description Then
                        Return fieldInfo.GetValue(fieldInfo.Name)
                    End If
                Next
                Return description
            End Function
        End Class

        Public Class CustomEnumTypeConverter(Of T As Structure)
            Inherits TypeConverter
            Private Shared ReadOnly s_toString As New Dictionary(Of T, String)()

            Private Shared ReadOnly s_toValue As New Dictionary(Of String, T)()

            Private Shared s_isInitialized As Boolean

            Shared Sub New()
                System.Diagnostics.Debug.Assert(GetType(T).IsEnum, "The custom enum class must be used with an enum type.")
            End Sub

            Public Sub New()
                MyBase.New()
                'MyBase.New(GetType(T))
                If Not s_isInitialized Then
                    Initialize()
                    s_isInitialized = True
                End If
            End Sub

            Protected Sub Initialize()
                For Each item As T In [Enum].GetValues(GetType(T))
                    Dim description As String = GetDescription(item)
                    s_toString(item) = description
                    s_toValue(description) = item
                Next
            End Sub

            Private Shared Function GetDescription(ByVal optionValue As T) As String
                Dim optionDescription As String = optionValue.ToString()
                Dim optionInfo As FieldInfo = GetType(T).GetField(optionDescription)
                If Attribute.IsDefined(optionInfo, GetType(DescriptionAttribute)) Then
                    Dim attribute__1 As DescriptionAttribute = DirectCast(Attribute.GetCustomAttribute(optionInfo, GetType(DescriptionAttribute)), DescriptionAttribute)
                    Return attribute__1.Description
                End If
                Return optionDescription
            End Function

            Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
                Dim optionValue As T = DirectCast(value, T)

                If destinationType Is GetType(String) AndAlso s_toString.ContainsKey(optionValue) Then
                    Return s_toString(optionValue)
                End If

                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End Function

            Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
                Dim stringValue As String = TryCast(value, String)

                If Not String.IsNullOrEmpty(stringValue) AndAlso s_toValue.ContainsKey(stringValue) Then
                    Return s_toValue(stringValue)
                End If

                Return MyBase.ConvertFrom(context, culture, value)
            End Function



        End Class

    End Namespace

  
End Namespace


