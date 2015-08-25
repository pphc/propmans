Namespace Common

    Public Class ItemLIst
        Private _key As String
        Private _value As String


        Public Sub New(ByVal key As String, ByVal value As String)
            _key = key
            _value = value

        End Sub

        Public ReadOnly Property DisplayValue() As String
            Get
                Return _key
            End Get
        End Property

        Public ReadOnly Property DisplayName() As String
            Get
                Return _value
            End Get
        End Property


    End Class

    Public MustInherit Class ListSource
        Private _list As New List(Of ItemLIst)

        Public Property List() As List(Of ItemLIst)
            Get
                Return _list
            End Get
            Private Set(ByVal Value As List(Of ItemLIst))
                _list = Value
            End Set
        End Property

        Public Sub AddItem(ByVal displayValue As String, ByVal displayName As String)
            Me.List.Add(New ItemLIst(displayValue, displayName))
        End Sub


    End Class

    Public Class ListHelper

        Public Shared Function CreateList(ByVal listType As ListSource) As List(Of ItemLIst)
            Return listType.List
        End Function
    End Class



End Namespace

