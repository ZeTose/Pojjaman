Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Components
    Public Class TreeTable
        Inherits DataTable
        Implements ITreeParent

#Region "Events"
        Delegate Sub ExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
        Public Event RowExpandStateChanged As ExpandCollapseHandler
#End Region

#Region "Members"

        Private m_initialized As Boolean = True
        Private m_childs As TreeRow.TreeRowCollection
        Private m_virtualRow As TreeRow 'Todo: .... уЊщ VirtualRoot ДефЫС
        Private Const NULL_ALIAS As String = "None"

#End Region

#Region "Constructors"
        Public Sub New()
            Me.New("TreeTable")
        End Sub
        Public Sub New(ByVal name As String)
            MyBase.New(name)
            m_childs = New TreeRow.TreeRowCollection(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property Initialized() As Boolean            Get                Return m_initialized            End Get            Set(ByVal Value As Boolean)                m_initialized = Value            End Set        End Property
        Public ReadOnly Property MaxLevel() As Integer            Get                Dim level As Integer = 0                For Each row As TreeRow In Me.Rows
                    If row.Level > level Then
                        level = row.Level
                    End If
                Next                Return level            End Get        End Property
        Public Property Childs() As TreeRow.TreeRowCollection Implements ITreeParent.Childs            Get                Return m_childs            End Get            Set(ByVal Value As TreeRow.TreeRowCollection)                m_childs = Value            End Set        End Property        Public ReadOnly Property FirstChild() As TreeRow Implements ITreeParent.FirstChild
            Get
                If m_childs.Count = 0 Then
                    Return Nothing
                End If
                Return m_childs(0)
            End Get
        End Property        Public ReadOnly Property LastChild() As TreeRow Implements ITreeParent.LastChild
            Get
                If m_childs.Count = 0 Then
                    Return Nothing
                End If
                Return m_childs(Childs.Count - 1)
            End Get
        End Property#End Region

#Region "Methods"
        Public Function CountItem(ByVal level As Integer) As Integer
            Dim cnt As Integer = 0
            For Each row As TreeRow In Me.Rows
                If row.Level = level Then
                    cnt += 1
                End If
            Next
            Return cnt
        End Function
        Public Sub Summarize(ByVal userLevel As Integer)
            For Each row As TreeRow In Me.Rows
                If row.Level < userLevel - 1 Then
                    row.State = RowExpandState.Expanded
                End If
                If row.Level = userLevel - 1 Then
                    row.State = RowExpandState.Collapsed
                End If
            Next
        End Sub
        Private Sub OnRowExpandStateChanged(ByVal e As RowExpandCollapseEventArgs)
            If m_initialized Then
                RaiseEvent RowExpandStateChanged(e)
            End If
        End Sub
        Public Sub ToggleRowState(ByVal row As TreeRow)
            Select Case row.State
                Case RowExpandState.Collapsed
                    row.State = RowExpandState.Expanded
                Case RowExpandState.Expanded
                    row.State = RowExpandState.Collapsed
            End Select
        End Sub
        Public Shadows Sub Clear()
            Dim rowsToBeRemove As New ArrayList
            For Each row As TreeRow In Me.Childs
                rowsToBeRemove.Add(row)
            Next
            For Each row As TreeRow In rowsToBeRemove
                Me.Childs.Remove(row)
            Next
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub TreeTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles MyBase.RowChanged
            Dim row As TreeRow = CType(e.Row, TreeRow)
            Select Case e.Action
                Case DataRowAction.Add
                    AddHandler row.Expand, AddressOf OnRowExpandStateChanged
                    AddHandler row.Collapse, AddressOf OnRowExpandStateChanged
                Case DataRowAction.Delete
                    RemoveHandler row.Expand, AddressOf OnRowExpandStateChanged
                    RemoveHandler row.Collapse, AddressOf OnRowExpandStateChanged
                Case DataRowAction.Change
                    'If m_initialized Then
                    '    If WrongParent(row) Then
                    '        Try
                    '            UpdateGroupChild(row)
                    '        Catch ex As Exception
                    '            MessageBox.Show(ex.Message & ":" & ex.StackTrace)
                    '        End Try
                    '    End If
                    'End If
            End Select
        End Sub
        'Private Function WrongParent(ByVal row As TreeRow) As Boolean
        '    Dim parent As ITreeParent = row.Parent
        '    While TypeOf parent Is TreeRow
        '        Dim parentRow As TreeRow = CType(parent, TreeRow)
        '        If IsDBNull(row(CStr(Me.m_groupbyFieldList(parentRow.Level)))) And Not IsDBNull(parentRow(Me.m_descField)) Then
        '            Return True
        '        End If
        '        If IsDBNull(parentRow(Me.m_descField)) And Not IsDBNull(row(CStr(Me.m_groupbyFieldList(parentRow.Level)))) Then
        '            Return True
        '        End If
        '        If Not IsDBNull(parentRow(Me.m_descField)) _
        '        AndAlso Not IsDBNull(row(Me.m_descField)) _
        '        AndAlso (CStr(row(CStr(Me.m_groupbyFieldList(parentRow.Level)))).ToLower <> CStr(parentRow(Me.m_descField)).ToLower) Then
        '            Return True
        '        End If
        '        parent = CType(parent, TreeRow).Parent
        '    End While
        '    Return False
        'End Function
        'Public Sub UpdateGroupChild(ByVal row As TreeRow)
        '    Dim arr As New ArrayList
        '    For i As Integer = 0 To Me.m_groupbyFieldList.Count - 1
        '        Dim value As Object = row(CStr(m_groupbyFieldList(i)))
        '        If IsDBNull(value) Then
        '            value = NULL_ALIAS
        '        End If
        '        arr.Add(value)
        '    Next
        '    If arr.Count = 0 Then
        '        Return
        '    End If
        '    Dim newParentRow As TreeRow = GetNewParentRow(Nothing, arr, 0)
        '    If Not newParentRow Is Nothing Then
        '        Dim insertIndex As Integer = GetChildIndexInOrder(row, newParentRow)
        '        Dim newRow As TreeRow = CType(row.Clone, TreeRow)
        '        row.Parent.Childs.RemoveTree(row)
        '        If insertIndex < newParentRow.Childs.Count Then
        '            newParentRow.Childs.InsertAt(insertIndex, newRow)
        '        Else
        '            newParentRow.Childs.Add(newRow)
        '        End If
        '    Else
        '        Debug.WriteLine("None")
        '    End If
        'End Sub
        'Private Function GetNewParentRow(ByVal row As TreeRow, ByVal arr As ArrayList, ByVal level As Integer) As TreeRow
        '    If level = arr.Count Then
        '        Return row
        '    End If
        '    If level = 0 Then
        '        For Each child As TreeRow In Me.Childs
        '            If CStr(child(Me.m_descField)).ToLower = CStr((arr(level))).ToLower Then
        '                'found Level 0 Group
        '                Return GetNewParentRow(child, arr, level + 1)
        '            End If
        '        Next
        '        'not found >> Add a new Level 0 Group
        '        'for now Add it at the first position
        '        Dim firstRow As TreeRow = Me.Childs(level)
        '        Dim tmprow As TreeRow = CType(Me.NewRow, TreeRow)
        '        tmprow(Me.m_descField) = arr(level)
        '        tmprow.State = RowExpandState.Expanded
        '        Dim insertIndex As Integer = GetChildIndexInOrder(tmprow, row)
        '        Dim newRow As TreeRow
        '        If insertIndex < row.Childs.Count Then
        '            newrow = row.Childs.InsertAt(insertindex, tmprow)
        '        Else
        '            newrow = row.Childs.Add(tmprow)
        '        End If
        '        Return GetNewParentRow(newRow, arr, level + 1)
        '    Else
        '        For Each child As TreeRow In row.Childs
        '            If CStr(child(Me.m_descField)).ToLower = CStr((arr(level))).ToLower Then
        '                'found this level group
        '                Return GetNewParentRow(child, arr, level + 1)
        '            End If
        '        Next
        '        'not found >> Add a group of this level
        '        Dim tmprow As TreeRow = CType(Me.NewRow, TreeRow)
        '        tmprow(Me.m_descField) = arr(level)
        '        tmprow.State = RowExpandState.Expanded
        '        Dim insertIndex As Integer = GetChildIndexInOrder(tmprow, row)
        '        Dim newRow As TreeRow
        '        If insertIndex < row.Childs.Count Then
        '            newrow = row.Childs.InsertAt(insertindex, tmprow)
        '        Else
        '            newrow = row.Childs.Add(tmprow)
        '        End If
        '        Return GetNewParentRow(newRow, arr, level + 1)
        '    End If
        'End Function
        'Private Function GetChildIndexInOrder(ByVal childRow As TreeRow, ByVal parent As ITreeParent) As Integer
        '    Dim sortColName As String
        '    If childRow.Level = Me.MaxLevel Then
        '        If Me.m_sortColumn Is Nothing Or Me.m_sortColumn = "" Then
        '            sortColName = Me.m_descField
        '        Else
        '            sortColName = Me.m_sortColumn
        '        End If
        '    Else
        '        sortColName = Me.m_descField
        '    End If
        '    If TypeOf parent Is TreeTable Then
        '        For i As Integer = 0 To Me.Childs.Count - 1
        '            If CStr(Me.Childs(i)(sortColName)).CompareTo(childRow(sortColName)) > 0 Then
        '                Return i
        '            End If
        '        Next
        '        Return Me.Childs.Count
        '    Else
        '        For i As Integer = 0 To parent.Childs.Count - 1
        '            If CStr(parent.Childs(i)(sortColName)).CompareTo(childRow(sortColName)) > 0 Then
        '                Return i
        '            End If
        '        Next
        '        Return parent.Childs.Count
        '    End If
        'End Function
#End Region

#Region "Overrides"
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New TreeRow(builder)
        End Function

        Protected Overrides Function GetRowType() As System.Type
            Return GetType(TreeRow)
        End Function
#End Region


    End Class
End Namespace
