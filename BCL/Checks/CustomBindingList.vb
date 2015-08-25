Imports System.Text
Imports System.ComponentModel
Imports System.Collections.Generic

Public Interface ISortComparer(Of T)
    Inherits IComparer(Of T)
    Property SortProperty() As PropertyDescriptor
    Property SortDirection() As ListSortDirection
End Interface

Public Class GenericSortComparer(Of T)
    Implements ISortComparer(Of T)

    Public Sub New()
    End Sub

    Public Sub New(sortProperty As String, sortDirection As ListSortDirection)
        Me.New(TypeDescriptor.GetProperties(GetType(T)).Find(sortProperty, True), sortDirection)
    End Sub

    Public Sub New(sortProperty As PropertyDescriptor, sortDirection As ListSortDirection)
        Me.SortDirection = sortDirection
        Me.SortProperty = sortProperty
    End Sub

    Public Property SortProperty() As PropertyDescriptor Implements ISortComparer(Of T).SortProperty
        Get
            Return m_SortProperty
        End Get
        Set(value As PropertyDescriptor)
            m_SortProperty = value
        End Set
    End Property
    Private m_SortProperty As PropertyDescriptor
    Public Property SortDirection() As ListSortDirection Implements ISortComparer(Of T).SortDirection
        Get
            Return m_SortDirection
        End Get
        Set(value As ListSortDirection)
            m_SortDirection = value
        End Set
    End Property
    Private m_SortDirection As ListSortDirection

    Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare
        If Me.SortProperty Is Nothing Then
            Return 0
        End If

        Dim obj1 As IComparable = TryCast(Me.SortProperty.GetValue(x), IComparable)
        Dim obj2 As IComparable = TryCast(Me.SortProperty.GetValue(y), IComparable)
        If obj1 Is Nothing OrElse obj2 Is Nothing Then
            Return 0
        End If

        If Me.SortDirection = ListSortDirection.Ascending Then
            Return (obj1.CompareTo(obj2))
        Else
            Return (obj2.CompareTo(obj1))
        End If
    End Function

End Class

Public Class CustomBindingList(Of T)
    Inherits BindingList(Of T)
    Private isSorting As Boolean

    ''' <summary>
    ''' Raised when the list is sorted.
    ''' </summary>
    Public Event Sorted As EventHandler

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(contents As IEnumerable(Of T))
        Me.New(contents, Nothing)
    End Sub

    Public Sub New(contents As IEnumerable(Of T), comparer As ISortComparer(Of T))
        If contents IsNot Nothing Then
            AddRange(contents)
        End If

        If comparer Is Nothing Then
            SortComparer = New GenericSortComparer(Of T)()
        Else
            SortComparer = comparer
        End If
    End Sub

#Region "Properties"
    Private m_sortComparer As ISortComparer(Of T)
    Public Property SortComparer() As ISortComparer(Of T)
        Get
            Return m_sortComparer
        End Get
        Set(value As ISortComparer(Of T))
            If value Is Nothing Then
                Throw New ArgumentNullException("SortComparer", "Value cannot be null.")
            End If
            m_sortComparer = value
        End Set
    End Property

    Private isSorted As Boolean
    Protected Overrides ReadOnly Property IsSortedCore() As Boolean
        Get
            Return isSorted
        End Get
    End Property

    Protected Overrides ReadOnly Property SupportsSortingCore() As Boolean
        Get
            Return True
        End Get
    End Property

    Private sortDirection As ListSortDirection
    Protected Overrides ReadOnly Property SortDirectionCore() As ListSortDirection
        Get
            Return sortDirection
        End Get
    End Property

    Private sortProperty As PropertyDescriptor
    Protected Overrides ReadOnly Property SortPropertyCore() As PropertyDescriptor
        Get
            Return sortProperty
        End Get
    End Property
#End Region

    Protected Overrides Sub ApplySortCore(prop As PropertyDescriptor, direction As ListSortDirection)
        If prop Is Nothing Then
            Return
        End If

        isSorting = True
        sortDirection = direction
        sortProperty = prop
        Me.SortComparer.SortProperty = prop
        Me.SortComparer.SortDirection = direction
        DirectCast(Me.Items, List(Of T)).Sort(Me.SortComparer)
        isSorted = True
        isSorting = False
        Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, 0))
        OnSorted(Nothing, New EventArgs())
    End Sub

    Protected Overrides Sub RemoveSortCore()
        Throw New NotSupportedException()
    End Sub

    Protected Overrides Sub OnListChanged(e As ListChangedEventArgs)
        If Not isSorting Then
            MyBase.OnListChanged(e)
        End If
    End Sub

    Protected Overridable Sub OnSorted(sender As Object, e As EventArgs)
        RaiseEvent Sorted(sender, e)
    End Sub

    Protected Overrides Sub InsertItem(index As Integer, item As T)
        MyBase.InsertItem(index, item)
        If Not isSorting Then
            Me.ApplySortCore(Me.SortPropertyCore, Me.SortDirectionCore)
        End If
    End Sub

    Protected Overrides Sub SetItem(index As Integer, item As T)
        MyBase.SetItem(index, item)
        If Not isSorting Then
            Me.ApplySortCore(Me.SortPropertyCore, Me.SortDirectionCore)
        End If
    End Sub

    Protected Overrides Sub RemoveItem(index As Integer)
        MyBase.RemoveItem(index)
        If Not isSorting Then
            Me.ApplySortCore(Me.SortPropertyCore, Me.SortDirectionCore)
        End If
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
    End Sub

    Public Sub AddRange(items As IEnumerable(Of T))
        If items IsNot Nothing Then
            For Each item As T In items
                Me.Items.Add(item)
            Next
        End If
    End Sub
End Class





