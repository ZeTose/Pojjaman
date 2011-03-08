Namespace Longkong.Pojjaman.Gui.Components

#Region "Enum"
    Public Enum RowExpandState
        None
        Expanded
        Collapsed
        UnderParent
    End Enum
#End Region

#Region "EventArgs"
    Public Class RowExpandCollapseEventArgs
        Inherits EventArgs

        Private m_row As TreeRow

        Public ReadOnly Property Row() As TreeRow
            Get
                Return m_row
            End Get
        End Property

        Public Sub New(ByVal myRow As TreeRow)
            m_row = myRow
        End Sub
    End Class
#End Region

    Public Delegate Sub TreeRowAction(ByVal r As TreeRow)
    'Todo: ทำให้ Add row ที่มีลูกอยู่แล้วได้
    Public Class TreeRow
        Inherits DataRow
        Implements ITreeParent, ICloneable

#Region "Events"
        Delegate Sub ExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
        Public Event Expand As ExpandCollapseHandler
        Public Event Collapse As ExpandCollapseHandler
#End Region

#Region "Members"

		Private m_rowExpandState As RowExpandState
		Private m_childs As TreeRowCollection
		Private m_parent As ITreeParent
		Private m_readonly As Boolean = False

		Private m_tag As Object
		Private m_fixLevel As Integer = -1

		Private m_customBackColor As Color = Color.Empty
		Private m_customForeColor As Color = Color.Empty
		Private m_customFontStyle As FontStyle = Nothing


#End Region

#Region "Constructors"
		Public Sub New(ByVal rb As DataRowBuilder)
			MyBase.New(rb)
			Me.m_rowExpandState = RowExpandState.None
			m_childs = New TreeRowCollection(Me)
		End Sub
#End Region

#Region "Properties"
		Public Property Tag() As Object			Get				Return m_tag			End Get			Set(ByVal Value As Object)				m_tag = Value			End Set		End Property
		Public Property [Readonly]() As Boolean			Get				Return m_readonly			End Get			Set(ByVal Value As Boolean)				m_readonly = Value			End Set		End Property
		Public Property Parent() As ITreeParent			Get				Return m_parent			End Get			Set(ByVal Value As ITreeParent)				m_parent = Value			End Set		End Property
		Public ReadOnly Property Index() As Integer			Get				If Me.Table Is Nothing Then
					Return -1
				End If
        'For i As Integer = 0 To Me.Table.Rows.Count - 1
        '	If Me.Table.Rows(i) Is Me Then
        '		Return i
        '	End If
        'Next
        'Return -1
        Return Me.Table.Rows.IndexOf(Me)
			End Get		End Property		Public Property FixLevel() As Integer			Get				Return m_fixLevel			End Get			Set(ByVal Value As Integer)				m_fixLevel = Value			End Set		End Property		Public ReadOnly Property Level() As Integer			Get
				If m_fixLevel >= 0 Then
					Return m_fixLevel
				Else
					Return GetLevel(Me)
				End If
			End Get		End Property
		Public Shared Function GetLevel(ByVal row As TreeRow) As Integer
			If row.Parent Is Nothing OrElse TypeOf row.Parent Is TreeTable Then
				Return 0
			End If
			Dim parentRow As TreeRow = CType(row.Parent, TreeRow)
			Return GetLevel(parentRow) + 1
		End Function
		Public Property State() As RowExpandState
			Get
				Return m_rowExpandState
			End Get
			Set(ByVal Value As RowExpandState)
				m_rowExpandState = Value
				If m_rowExpandState = RowExpandState.Expanded Then
					RaiseEvent Expand(New RowExpandCollapseEventArgs(Me))
				ElseIf m_rowExpandState = RowExpandState.Collapsed Then
					RaiseEvent Collapse(New RowExpandCollapseEventArgs(Me))
				End If
			End Set
		End Property
		Public Property Childs() As TreeRowCollection Implements ITreeParent.Childs			Get				Return m_childs			End Get			Set(ByVal Value As TreeRowCollection)				m_childs = Value			End Set		End Property		Public ReadOnly Property PreviousSibling() As TreeRow
			Get
				If Me.m_parent Is Nothing Then
					Return Nothing
				End If
				If m_parent.Childs.IndexOf(Me) = 0 Then
					Return Nothing
				End If
				Return m_parent.Childs(m_parent.Childs.IndexOf(Me) - 1)
			End Get
		End Property		Public ReadOnly Property NextSibling() As TreeRow
			Get
				If Me.m_parent Is Nothing Then
					Return Nothing
				End If
				If m_parent.Childs.IndexOf(Me) = m_parent.Childs.Count - 1 Then
					Return Nothing
				End If
				Return m_parent.Childs(m_parent.Childs.IndexOf(Me) + 1)
			End Get
		End Property		Public ReadOnly Property NextRow() As TreeRow
			Get
				If Me.Table Is Nothing Then
					Return Nothing
				End If
				If Me.Index = Me.Table.Rows.Count - 1 Then
					Return Nothing
				End If
				Return CType(Me.Table.Rows(Me.Index + 1), TreeRow)
			End Get
		End Property		Public ReadOnly Property PreviousRow() As TreeRow
			Get
				If Me.Table Is Nothing Then
					Return Nothing
				End If
				If Me.Index = 0 Then
					Return Nothing
				End If
				Return CType(Me.Table.Rows(Me.Index - 1), TreeRow)
			End Get
		End Property		Public ReadOnly Property FirstChild() As TreeRow Implements ITreeParent.FirstChild
			Get
				If m_childs.Count = 0 Then
					Return Nothing
				End If
				Return m_childs(0)
			End Get
		End Property		Public ReadOnly Property LastChild() As TreeRow Implements ITreeParent.LastChild
			Get
				If m_childs.Count = 0 Then
					Return Nothing
				End If
				Return m_childs(Childs.Count - 1)
			End Get
		End Property		Public ReadOnly Property IsVisible() As Boolean
			Get
				Return GetVisibleState(Me)
			End Get
		End Property
    Public Property CustomBackColor() As Color      Get
        Return m_customBackColor
      End Get
      Set(ByVal Value As Color)
        m_customBackColor = Value
      End Set
    End Property
		Public Property CustomForeColor() As Color			Get
				Return m_customForeColor
			End Get
			Set(ByVal Value As Color)
				m_customForeColor = Value
			End Set
		End Property    Public Property CustomFontStyle() As FontStyle      Get
        Return m_customFontStyle
      End Get
      Set(ByVal Value As FontStyle)
        m_customFontStyle = Value
      End Set
    End Property#End Region

#Region "Methods"
		Public Shared Sub TraverseRow(ByVal r As TreeRow, ByVal ta As TreeRowAction)
			ta(r)
			For Each aRow As TreeRow In r.Childs
				TraverseRow(aRow, ta)
			Next
		End Sub
		Public Shared Sub TraverseRowBackward(ByVal r As TreeRow, ByVal ta As TreeRowAction)
			For Each aRow As TreeRow In r.Childs
				TraverseRowBackward(aRow, ta)
			Next
			ta(r)
		End Sub
		Public Shared Function GetVisibleState(ByVal row As TreeRow) As Boolean
			While Not row.Parent Is Nothing AndAlso Not TypeOf row.Parent Is TreeTable
				row = CType(row.Parent, TreeRow)
				If row.State = RowExpandState.Collapsed Then
					Return False
				End If
			End While
			Return True
		End Function
		Public Sub EnsureVisible()
			If Not TypeOf Me.m_parent Is TreeTable Then
				ExpandAllParent(CType(Me.m_parent, TreeRow))
			End If
		End Sub
		Private Sub ExpandAllParent(ByVal parent As TreeRow)
			If parent.State <> RowExpandState.Expanded Then
				parent.State = RowExpandState.Expanded
			End If
			If TypeOf parent.Parent Is TreeTable Then
				Return
			End If
			Dim parentRow As TreeRow = CType(parent.Parent, TreeRow)
			ExpandAllParent(parentRow)
		End Sub
		Public Overrides Function ToString() As String
			Dim ret As String
			For Each obj As Object In ItemArray
				ret &= obj.ToString & ":"
			Next
			Dim prefix As String = "".PadLeft(Me.Level * 6, "-"c)
			Return ret
		End Function
		Public ReadOnly Property IsLeafRow() As Boolean
			Get
				If m_childs Is Nothing OrElse m_childs.Count = 0 Then
					Return True
				End If
				Return False
			End Get
		End Property
#End Region

#Region "ICloneable"
		Public Function Clone() As Object Implements System.ICloneable.Clone
			Dim newRow As TreeRow = CType(Me.Table.NewRow, TreeRow)
			newRow.State = Me.State
			newRow.ItemArray = Me.ItemArray
			Return newRow
		End Function
#End Region

		Public Class TreeRowCollection
			Inherits CollectionBase

#Region "Members"
			Private m_parent As ITreeParent
#End Region

#Region "Constructors"
			Public Sub New()
			End Sub
			Public Sub New(ByVal parent As ITreeParent)
				MyBase.New()
				Me.m_parent = parent
			End Sub
#End Region

#Region "Methods"
			Public Shadows Function Add() As TreeRow
				If Me.m_parent Is Nothing Then
					Return Nothing
				End If
				Dim parentTable As DataTable
				Dim row As TreeRow
				If TypeOf Me.m_parent Is TreeTable Then
					parentTable = CType(Me.m_parent, DataTable)
				Else
					parentTable = CType(Me.m_parent, TreeRow).Table
				End If
				row = CType(parentTable.NewRow, TreeRow)
				Return Add(row)
			End Function

			'Methods to plainly add a child to the collection
			Public Function AddChild(ByVal row As TreeRow) As TreeRow
				If Not row Is Nothing Then
					MyBase.List.Add(row)
				End If
				Return row
			End Function
			Public Shadows Function Add(ByVal row As TreeRow) As TreeRow
				Dim parentTable As DataTable
				If TypeOf Me.m_parent Is TreeTable Then
					'แม่เป็น Table
					parentTable = CType(Me.m_parent, DataTable)
					row.Parent = Me.m_parent
					'ยังไงก็ Add เลยโลด
					parentTable.Rows.Add(row)
				Else
					'แม่เป็น row
					Dim parentRow As TreeRow = CType(Me.m_parent, TreeRow)
					parentTable = parentRow.Table
					row.Parent = Me.m_parent
					Dim nextNeighbour As TreeRow = GetNextNeighbour(parentRow)
					If nextNeighbour Is Nothing Then
						parentTable.Rows.Add(row)
					Else
						parentTable.Rows.InsertAt(row, nextNeighbour.Index)
					End If
					If parentRow.State = RowExpandState.None Then
						parentRow.State = RowExpandState.Collapsed
					End If
				End If
				If Not row Is Nothing Then
					MyBase.List.Add(row)
				End If
				Return row
			End Function
			Private Function GetNextNeighbour(ByVal row As TreeRow) As TreeRow
				If TypeOf row.Parent Is TreeTable Then
					Return row.NextSibling
				End If
				If Not row.NextSibling Is Nothing Then
					Return row.NextSibling
				End If
				'Fail จากข้างบน >> recur
				Return GetNextNeighbour(CType(row.Parent, TreeRow))
			End Function
			Public Shadows Sub Remove(ByVal row As TreeRow)
				Dim rowsToBeRemove As New ArrayList
				For Each myRow As TreeRow In row.Childs
					rowsToBeRemove.Add(myRow)
				Next
				For Each myRow As TreeRow In rowsToBeRemove
					row.Childs.Remove(myrow)
				Next
				row.Table.Rows.Remove(row)
				MyBase.List.Remove(row)
				row.Tag = Nothing
				row.Parent = Nothing
			End Sub
			Public Function IndexOf(ByVal row As TreeRow) As Integer
				Return InnerList.IndexOf(row)
			End Function
			Public Function InsertAt(ByVal index As Integer) As TreeRow
				Dim parentTable As DataTable
				If TypeOf Me.m_parent Is TreeTable Then
					parentTable = CType(Me.m_parent, DataTable)
				Else
					parentTable = CType(Me.m_parent, TreeRow).Table
				End If
				Dim row As TreeRow = CType(parentTable.NewRow, TreeRow)
				Return InsertAt(index, row)
			End Function
			Public Function InsertAt(ByVal index As Integer, ByVal row As TreeRow) As TreeRow
				If Me.m_parent Is Nothing Then
					Return Nothing
				End If
				Dim parentTable As DataTable
				If TypeOf Me.m_parent Is TreeTable Then
					parentTable = CType(Me.m_parent, DataTable)
				Else
					parentTable = CType(Me.m_parent, TreeRow).Table
				End If
				parentTable.Rows.InsertAt(row, Me.Item(index).Index)
				MyBase.List.Insert(index, row)
				row.Parent = Me.m_parent
				Return row
			End Function
#End Region

#Region "Properties"
			Default Public Property Item(ByVal index As Integer) As TreeRow
				Get
					Try
						If InnerList.Count > 0 Then
							Return CType(InnerList(index), TreeRow)
						Else
							Return Nothing
						End If
					Catch ex As Exception

					End Try
				End Get
				Set(ByVal Value As TreeRow)
					InnerList(index) = Value
				End Set
			End Property
#End Region

		End Class

	End Class
End Namespace

