Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Components
    Public Class ExpandableRowDataTable
        Inherits DataTable

#Region "Events"
        Delegate Sub ExpandHandler(ByVal e As ExpandCollapseEventArgs)
        Delegate Sub CollapseHandler(ByVal e As ExpandCollapseEventArgs)
        Public Event Expand As ExpandHandler
        Public Event Collapse As CollapseHandler
        Private Sub ExpandCollapseHandler(ByVal e As ExpandCollapseEventArgs)
            'If m_init Then
            '    ExpandCollapseRow(e.Row, e.Row.State)
            'End If
            ExpandCollapseRow(e.Row, e.Row.State)

            dg.PerformLayout()
            dg.UpdateScrollBar()
            'ส่ง event ต่อไปข้างบน
            If e.Row.State = PlusMinusState.Collapsed Then
                RaiseEvent Collapse(e)
            ElseIf e.Row.State = PlusMinusState.Expanded Then
                RaiseEvent Expand(e)
            End If
        End Sub
        Private Sub Grid_ColumnHeaderClicked(ByVal sender As Object, ByVal e As ColumnHeaderClickEventArgs)            If Me.m_groupbyFieldList.Count > 0 Then                Dim newSortCol As String = Grid.TableStyles(0).GridColumnStyles(e.Column).MappingName
                Select Case m_sortColumn
                    Case newSortCol
                        m_sortColumn = newSortCol & " desc"
                    Case Else
                        m_sortColumn = newSortCol
                End Select
                'Grid.DataSource = UpdateGroup()
            Else
                For i As Integer = 0 To Me.Rows.Count - 1
                    Dim theRow As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                    theRow.Index = i
                    theRow("SortIndex") = theRow.Index
                Next
            End If
        End Sub
#End Region

#Region "Members"
        Private dsHelper As New DataSetHelper
        Private m_rowIndex As Integer
        Private m_childIndex As Integer
        Private dg As PJMDataGrid
        Public m_allowNew As Boolean = False
        Private m_childs As ExpandableDataRow.ExpandableDatarowCollection
        Public m_rowStates As ArrayList
        Private m_init As Boolean

        Private m_groupbyFieldList As ArrayList
        Private m_fieldNames As String
        Private m_descField As String
        Private m_sortColumn As String
        Private m_rollup As Boolean
        Private m_aggregateFieldInfo As ArrayList

        'ByVal groupList As ArrayList, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean) As DataTable

        Private Const NULL_ALIAS As String = "None"

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New("ExpandableRowDataTable")
            m_childs = New ExpandableDataRow.ExpandableDatarowCollection
            m_rowStates = New ArrayList
            m_init = False
            m_groupbyFieldList = New ArrayList
        End Sub
        Public Sub New(ByVal name As String)
            MyBase.New(name)
            m_childs = New ExpandableDataRow.ExpandableDatarowCollection
            m_rowStates = New ArrayList
            m_init = False
            m_groupbyFieldList = New ArrayList
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property AggregateFieldInfo() As ArrayList            Get                Return m_aggregateFieldInfo            End Get        End Property        Public Property GroupbyFieldList() As ArrayList            Get
                Return m_groupbyFieldList
            End Get
            Set(ByVal Value As ArrayList)
                m_groupbyFieldList = Value
            End Set
        End Property        Public Property FieldNames() As String            Get                Return m_fieldNames            End Get            Set(ByVal Value As String)                m_fieldNames = Value                ParseFieldList()            End Set        End Property        Public Property DescField() As String            Get                Return m_descField            End Get            Set(ByVal Value As String)                m_descField = Value            End Set        End Property        Public Property SortColumn() As String            Get                Return m_sortColumn            End Get            Set(ByVal Value As String)                m_sortColumn = Value            End Set        End Property        Public Property Rollup() As Boolean            Get                Return m_rollup            End Get            Set(ByVal Value As Boolean)                m_rollup = Value            End Set        End Property        Public ReadOnly Property LastChild() As ExpandableDataRow
            Get
                If Childs.Count > 0 Then
                    Return Childs(Childs.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property
        Public Property Childs() As ExpandableDataRow.ExpandableDatarowCollection            Get                Return m_childs            End Get            Set(ByVal Value As ExpandableDataRow.ExpandableDatarowCollection)                m_childs = Value            End Set        End Property
        Public Property Grid() As PJMDataGrid
            Get
                Return dg
            End Get
            Set(ByVal Value As PJMDataGrid)
                dg = Value
                For Each row As ExpandableDataRow In Me.Childs
                    Me.ExpandCollapseRow(row, row.State)
                Next
                dg.UpdateScrollBar()
                'AddHandler dg.ColumnHeaderClicked, AddressOf Grid_ColumnHeaderClicked
            End Set
        End Property        Public Sub ToggleRowState(ByVal row As ExpandableDataRow)
            Select Case row.State
                Case PlusMinusState.Collapsed
                    row.State = PlusMinusState.Expanded
                Case PlusMinusState.Expanded
                    row.State = PlusMinusState.Collapsed
            End Select
        End Sub#End Region

#Region "Methods"
        Private Sub ExpandCollapseRow(ByVal row As ExpandableDataRow, ByVal state As PlusMinusState)
            For Each myrow As ExpandableDataRow In row.Childs
                If state = PlusMinusState.Collapsed Then
                    ExpandCollapseRow(myrow, state)
                    dg.RowHeights(myrow.Index) = 0
                ElseIf state = PlusMinusState.Expanded And (row.Parent Is Nothing OrElse row.Parent.State = PlusMinusState.Expanded) Then
                    ExpandCollapseRow(myrow, myrow.State)
                    dg.RowHeights(myrow.Index) = 17
                End If
            Next
        End Sub
        Public Sub MoveRow1(ByVal fromIndex As Integer, ByVal toIndex As Integer)
            If fromIndex = toIndex Or toIndex < 0 Or toIndex >= Me.Rows.Count Then
                Return
            End If
            Dim fromRow As ExpandableDataRow = CType(Me.Rows(fromIndex), ExpandableDataRow)
            Dim toRow As ExpandableDataRow = CType(Me.Rows(toIndex), ExpandableDataRow)
            If fromRow.State <> PlusMinusState.UnderParent Or toRow.State <> PlusMinusState.UnderParent Then
                Return
            End If
            If fromIndex < toIndex Then
                Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
                tmprow.Index = toIndex - 1
                SetRow(fromRow, tmprow, Me.Columns.Count, True)
                Me.Rows.Remove(fromRow)
                For i As Integer = fromIndex To toIndex - 2
                    Dim row As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                    row.Index = i
                    row("SortIndex") = row.Index
                Next
                Me.Rows.InsertAt(tmprow, toIndex - 1)
                tmprow("SortIndex") = tmprow.Index
                tmprow.Parent = toRow.Parent
                If Not tmprow.Parent Is Nothing Then
                    tmprow.Parent.Childs.InsertAt(tmprow.Parent.Childs.IndexOf(toRow), tmprow)
                Else
                    Me.Childs.InsertAt(Me.Childs.IndexOf(toRow), tmprow)
                End If
                tmprow.Level = toRow.Level
                tmprow.State = toRow.State
                dg.SelectRow(tmprow.Index)
            ElseIf fromIndex > toIndex Then
                Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
                tmprow.Index = toIndex
                SetRow(fromRow, tmprow, Me.Columns.Count, True)
                Me.Rows.Remove(fromRow)
                Me.Rows.InsertAt(tmprow, toIndex)
                For i As Integer = toIndex + 1 To fromIndex
                    Dim row As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                    row.Index = i
                    row("SortIndex") = row.Index
                Next
                tmprow.Parent = toRow.Parent
                If Not tmprow.Parent Is Nothing Then
                    tmprow.Parent.Childs.InsertAt(tmprow.Parent.Childs.IndexOf(toRow), tmprow)
                Else
                    Me.Childs.InsertAt(Me.Childs.IndexOf(toRow), tmprow)
                End If
                tmprow.Level = toRow.Level
                tmprow.State = toRow.State
                tmprow("SortIndex") = tmprow.Index
                dg.SelectRow(tmprow.Index)
            End If
            Me.DefaultView.Sort = "SortIndex"
            dg.DataSource = New DataTable
            dg.DataSource = Me
        End Sub
        Public Function InsertRow(ByVal row As ExpandableDataRow, ByVal parentRow As ExpandableDataRow, ByVal childIndex As Integer, Optional ByVal state As PlusMinusState = PlusMinusState.UnderParent) As ExpandableDataRow
            Dim toIndex As Integer
            If parentRow Is Nothing Then
                If childIndex < 0 Then
                    Return Nothing
                ElseIf childIndex < Me.Childs.Count Then
                    toIndex = Me.Childs(childIndex).Index
                Else
                    'toIndex = Me.Childs(Me.Childs.Count - 1).Index + 1
                    If Me.Childs.Count > 0 Then
                        If Not Me.LastChild.LastChild Is Nothing Then
                            toIndex = Me.LastChild.LastChild.Index + 1
                        Else
                            toIndex = Me.LastChild.Index + 1
                        End If
                    Else
                        toIndex = 0
                    End If
                End If
            Else
                If parentRow.Childs.Count = 0 Then
                    toIndex = parentRow.Index + 1
                ElseIf childIndex < 0 Then
                    Return Nothing
                ElseIf childIndex < parentRow.Childs.Count Then
                    toIndex = parentRow.Childs(childIndex).Index
                Else
                    If Not parentRow.LastChild.LastChild Is Nothing Then
                        toIndex = parentRow.LastChild.LastChild.Index + 1
                    Else
                        toIndex = parentRow.LastChild.Index + 1
                    End If
                End If
            End If
            Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            SetRow(row, tmprow, Me.Columns.Count, True)
            If toIndex >= Me.Rows.Count Then
                Me.Rows.Add(tmprow)
            Else
                Me.Rows.InsertAt(tmprow, toIndex)
            End If

            tmprow.Parent = parentRow
            If Not tmprow.Parent Is Nothing Then
                If childIndex >= tmprow.Parent.Childs.Count Then
                    tmprow.Parent.Childs.Add(tmprow)
                Else
                    tmprow.Parent.Childs.InsertAt(childIndex, tmprow)
                End If
            Else
                If childIndex >= Me.Childs.Count Then
                    Me.Childs.Add(tmprow)
                Else
                    Me.Childs.InsertAt(childIndex, tmprow)
                End If
            End If
            If parentRow Is Nothing Then
                tmprow.Level = 0
            Else
                tmprow.Level = parentRow.Level + 1
            End If
            tmprow.State = state
            For i As Integer = 0 To Me.Rows.Count - 1
                Dim theRow As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                theRow.Index = i
                theRow("SortIndex") = theRow.Index
            Next
            If Not m_aggregateFieldInfo Is Nothing Then
                UpdateAggregate(tmprow)
            End If
            dg.SelectRow(tmprow.Index)
            Me.DefaultView.Sort = "SortIndex"
            dg.DataSource = New DataTable
            dg.DataSource = Me
            AddHandler tmprow.Expand, AddressOf Me.ExpandCollapseHandler
            AddHandler tmprow.Collapse, AddressOf Me.ExpandCollapseHandler
            Return tmprow
        End Function
        Public Function MoveRow(ByVal row As ExpandableDataRow, ByVal parentRow As ExpandableDataRow, ByVal childIndex As Integer) As ExpandableDataRow
            If row.State <> PlusMinusState.UnderParent Then
                Return Nothing
            End If
            Dim toIndex As Integer
            If parentRow Is Nothing Then
                If childIndex < 0 Then
                    Return Nothing
                ElseIf childIndex < Me.Childs.Count Then
                    toIndex = Me.Childs(childIndex).Index
                Else
                    toIndex = Me.Childs(Me.Childs.Count - 1).Index + 1
                End If
            Else
                If parentRow.Childs.Count = 0 Then
                    toIndex = parentRow.Index + 1
                ElseIf childIndex < 0 Then
                    Return Nothing
                ElseIf childIndex < parentRow.Childs.Count Then
                    toIndex = parentRow.Childs(childIndex).Index
                Else
                    toIndex = parentRow.Childs(parentRow.Childs.Count - 1).Index + 1
                End If
            End If
            Dim fromIndex As Integer = row.Index
            Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            SetRow(row, tmprow, Me.Columns.Count, True)
            Dim rowsRemoved As Integer = RecurRemoveFromParent(row)
            If fromIndex < toIndex Then
                Me.Rows.InsertAt(tmprow, toIndex - 1 - (rowsRemoved - 1))
            ElseIf fromIndex >= toIndex Then
                Me.Rows.InsertAt(tmprow, toIndex)
            End If
            tmprow.Parent = parentRow
            If Not tmprow.Parent Is Nothing Then
                If tmprow.Parent.Childs.Count > 0 Then
                    tmprow.Parent.Childs.InsertAt(childIndex, tmprow)
                Else
                    tmprow.Parent.Childs.Add(tmprow)
                End If
            Else
                If Me.Childs.Count > 0 Then
                    Me.Childs.InsertAt(childIndex, tmprow)
                Else
                    Me.Childs.Add(tmprow)
                End If

            End If
            tmprow.Level = row.Level
            tmprow.State = PlusMinusState.UnderParent
            For i As Integer = 0 To Me.Rows.Count - 1
                Dim theRow As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                theRow.Index = i
                theRow("SortIndex") = theRow.Index
            Next
            If Not m_aggregateFieldInfo Is Nothing Then
                UpdateAggregate(tmprow.Parent)
            End If
            tmprow.EnsureVisible()
            dg.SelectRow(tmprow.Index)
            Me.DefaultView.Sort = "SortIndex"
            dg.DataSource = New DataTable
            dg.DataSource = Me
            Return tmprow
        End Function
        Public Function MoveRow(ByVal fromIndex As Integer, ByVal toIndex As Integer) As ExpandableDataRow
            If fromIndex = toIndex Or toIndex < 0 Or toIndex >= Me.Rows.Count Then
                Return Nothing
            End If
            Dim fromRow As ExpandableDataRow = CType(Me.Rows(fromIndex), ExpandableDataRow)
            Dim toRow As ExpandableDataRow = CType(Me.Rows(toIndex), ExpandableDataRow)
            If fromRow.State <> PlusMinusState.UnderParent Or toRow.State <> PlusMinusState.UnderParent Then
                Return Nothing
            End If
            Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            SetRow(fromRow, tmprow, Me.Columns.Count, True)
            Dim rowsRemoved As Integer = RecurRemoveFromParent(fromRow)
            If fromIndex < toIndex Then
                Me.Rows.InsertAt(tmprow, toIndex - 1 - (rowsRemoved - 1))
            ElseIf fromIndex > toIndex Then
                Me.Rows.InsertAt(tmprow, toIndex)
            End If
            tmprow.Parent = toRow.Parent
            If Not tmprow.Parent Is Nothing Then
                tmprow.Parent.Childs.InsertAt(tmprow.Parent.Childs.IndexOf(toRow), tmprow)
            Else
                Me.Childs.InsertAt(Me.Childs.IndexOf(toRow), tmprow)
            End If
            tmprow.Level = toRow.Level
            tmprow.State = toRow.State
            For i As Integer = 0 To Me.Rows.Count - 1
                Dim row As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                row.Index = i
                row("SortIndex") = row.Index
            Next
            If Not m_aggregateFieldInfo Is Nothing Then
                UpdateAggregate(tmprow.Parent)
            End If
            dg.SelectRow(tmprow.Index)
            Me.DefaultView.Sort = "SortIndex"
            dg.DataSource = New DataTable
            dg.DataSource = Me
            Return tmprow
        End Function
        Public Function RecurRemoveFromParent(ByVal row As ExpandableDataRow) As Integer
            Dim i As Integer = 0 'Numbers of row removed
            If Not row.Parent Is Nothing Then
                row.Parent.Childs.Remove(row)
                i += 1
                If row.Parent.Childs.Count = 0 Then
                    i += RecurRemoveFromParent(row.Parent)
                ElseIf Not m_aggregateFieldInfo Is Nothing Then
                    Me.UpdateAggregate(row.Parent)
                End If
                Me.Rows.Remove(row)
                Me.AcceptChanges()
            Else
                Me.Childs.Remove(row)
                Me.Rows.Remove(row)
                i += 1
            End If
            Return i
        End Function
        Public Sub Remove(ByVal index As Integer)
            Remove(CType(Me.Rows(index), ExpandableDataRow))
        End Sub
        Public Sub Remove(ByVal row As ExpandableDataRow)
            If Not row.State = PlusMinusState.UnderParent Then
                Return
            End If
            row.Parent.Childs.Remove(row)
            Me.Rows.Remove(row)
            Me.AcceptChanges()
            For i As Integer = row.Index To Me.Rows.Count - 1
                CType(Me.Rows(i), ExpandableDataRow).Index = i
                Me.Rows(i)("SortIndex") = i
            Next
            Me.DefaultView.Sort = "SortIndex"
            dg.DataSource = New DataTable
            dg.DataSource = Me
        End Sub
        Public Function Insert(ByVal index As Integer, ByVal row As ExpandableDataRow) As ExpandableDataRow

        End Function
        Public Function Add(ByVal index As Integer, ByVal row As ExpandableDataRow) As ExpandableDataRow
            Dim rowAtIndex As ExpandableDataRow = CType(Me.Rows(index), ExpandableDataRow)
            If Not rowAtIndex.State = PlusMinusState.UnderParent Then
                Return Nothing
            End If
            Dim expRow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            SetRow(row, expRow, Me.Columns.Count, True)
            expRow.Parent = rowAtIndex.Parent
            If Not expRow.Parent Is Nothing Then
                expRow.Parent.Childs.InsertAt(expRow.Parent.Childs.IndexOf(rowAtIndex), expRow)
            Else
                Dim dt As ExpandableRowDataTable = CType(rowAtIndex.Table, ExpandableRowDataTable)
                dt.Childs.InsertAt(dt.Childs.IndexOf(rowAtIndex), expRow)
            End If
            expRow.Level = rowAtIndex.Level
            expRow.State = rowAtIndex.State
            For i As Integer = index To Me.Rows.Count - 1
                CType(Me.Rows(i), ExpandableDataRow).Index = i + 1
                Me.Rows(i)("SortIndex") = i + 1
            Next
            expRow.Index = index
            Me.Rows.InsertAt(expRow, index)
            Me.AcceptChanges()
            Me.DefaultView.Sort = "SortIndex"

            dg.DataSource = New DataTable
            dg.DataSource = Me
            dg.SelectRow(index)
            'วิธีเก่า
            'Dim dt As ExpandableRowDataTable
            'dt = CType(Me.Copy, ExpandableRowDataTable)
            'CloneEx(dt)
            'dg.DataSource = dt
            'dg.m_dataTable = dt
        End Function
        Public Function Add(ByVal index As Integer) As ExpandableDataRow
            Dim rowAtIndex As ExpandableDataRow = CType(Me.Rows(index), ExpandableDataRow)
            If Not rowAtIndex.State = PlusMinusState.UnderParent Then
                Return Nothing
            End If
            Dim expRow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            SetRow(rowAtIndex, expRow, Me.Columns.Count, False)
            expRow.Parent = rowAtIndex.Parent
            If Not expRow.Parent Is Nothing Then
                expRow.Parent.Childs.InsertAt(expRow.Parent.Childs.IndexOf(rowAtIndex), expRow)
            Else
                Dim dt As ExpandableRowDataTable = CType(rowAtIndex.Table, ExpandableRowDataTable)
                dt.Childs.InsertAt(dt.Childs.IndexOf(rowAtIndex), expRow)
            End If
            expRow.Level = rowAtIndex.Level
            expRow.State = rowAtIndex.State
            For i As Integer = index To Me.Rows.Count - 1
                CType(Me.Rows(i), ExpandableDataRow).Index = i + 1
                Me.Rows(i)("SortIndex") = i + 1
            Next
            expRow.Index = index
            Me.Rows.InsertAt(expRow, index)
            Me.AcceptChanges()
            Me.DefaultView.Sort = "SortIndex"

            dg.DataSource = New DataTable
            dg.DataSource = Me
            dg.SelectRow(index)
        End Function
        Private Sub SetRow(ByVal fromRow As DataRow, ByVal toRow As DataRow, ByVal numCols As Integer, ByVal AllRow As Boolean)
            Dim i As Integer
            i = 0
            Do While (i < numCols)
                If i <> 0 Or AllRow Then
                    toRow(i) = fromRow(i)
                End If
                i = (i + 1)
            Loop
        End Sub
        Public Function Add(ByVal pName As String) As ExpandableDataRow
            Dim expRow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            expRow.State = PlusMinusState.UnderParent
            Me.Rows.Add(expRow)
            Return expRow
        End Function
        Public Function Add(ByVal pName As String, ByVal state As PlusMinusState) As ExpandableDataRow
            Dim expRow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
            expRow.State = state
            Me.Rows.Add(expRow)
            Return expRow
        End Function

        Private GroupTable As ExpandableRowDataTable
        Public Function ChildTable() As ExpandableRowDataTable
            Dim childIndex As Integer = 0
            Dim retTable As ExpandableRowDataTable = CType(Me.Clone, ExpandableRowDataTable)
            For i As Integer = 0 To Me.Rows.Count - 1
                Dim row As ExpandableDataRow = CType(Me.Rows(i), ExpandableDataRow)
                If row.State = PlusMinusState.UnderParent Then
                    Dim values() As Object = row.ItemArray
                    Dim theRow As ExpandableDataRow = CType(retTable.LoadDataRow(values, True), ExpandableDataRow)
                    theRow.State = PlusMinusState.UnderParent
                    retTable.m_rowStates.Add(theRow.State)
                    theRow.Level = 0
                    theRow.Index = childIndex
                    theRow("SortIndex") = theRow.Index
                    childIndex += 1
                    retTable.Childs.Add(theRow)
                End If
            Next
            Return retTable
        End Function
        Public Function UpdateGroup(ByVal groupList As ArrayList, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean) As ExpandableRowDataTable
            Me.GroupbyFieldList = groupList
            Me.FieldNames = fieldNames
            Me.DescField = descFieldName
            Me.SortColumn = sortCols
            Me.Rollup = ROLLUP
            Return GroupBy()
        End Function
        Public Function UpdateGroup() As ExpandableRowDataTable
            Try
                Return GroupBy()
            Catch ex As Exception

            End Try
        End Function
        Private Function GroupBy() As ExpandableRowDataTable
            m_fieldNames = GetFieldList(m_groupbyFieldList, m_groupbyFieldList.Count - 1) & "," & m_fieldNames
            Dim tmpTables(m_groupbyFieldList.Count) As DataTable
            For level As Integer = 0 To m_groupbyFieldList.Count - 1
                Dim fieldString As String = GetFieldList(m_groupbyFieldList, level)
                tmpTables(level) = SelectDistinct(fieldString, "", fieldString)
            Next
            GroupTable = CType(Me.Clone, ExpandableRowDataTable)
            GroupTable.m_init = False
            m_rowIndex = 0
            FillGroupTable(m_groupbyFieldList, tmpTables, 0, m_fieldNames, m_descField, m_sortColumn, m_rollup)
            GroupTable.m_init = True
            GroupTable.GroupbyFieldList = Me.m_groupbyFieldList
            GroupTable.FieldNames = Me.m_fieldNames
            GroupTable.DescField = Me.m_descField
            GroupTable.SortColumn = Me.SortColumn
            GroupTable.Rollup = Me.m_rollup
            Return GroupTable
        End Function
        Private Function FillGroupTable(ByVal groupList As ArrayList, ByVal tmpTables() As DataTable, ByVal level As Integer, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean) As DataTable
            If level = 0 Then
                Dim tmpTable As DataTable = dsHelper.SelectGroupByInto("test", Me, fieldNames, , CStr(groupList(level)))
                Dim j As Integer = 0
                For i As Integer = 0 To tmpTable.Rows.Count - 1
                    Dim parentRow As ExpandableDataRow = GroupTable.Add("")
                    parentRow.Index = m_rowIndex
                    m_rowIndex += 1
                    For Each col As DataColumn In Me.Columns
                        Dim groupColMatch As Boolean = False
                        For lv As Integer = 0 To groupList.Count - 1
                            If CStr(groupList(lv)).ToLower = col.ColumnName.ToLower Then
                                groupColMatch = True
                                Exit For
                            End If
                        Next
                        If tmpTable.Columns.IndexOf(col.ColumnName) >= 0 And Not groupColMatch And GroupTable.Columns(col.ColumnName).ReadOnly = False Then
                            parentRow(col.ColumnName) = tmpTable.Rows(i)(col.ColumnName)
                        End If
                        If j = tmpTable.Rows.Count - 1 And ROLLUP Then
                            parentRow(descFieldName) = "Total"
                        Else
                            If IsDBNull(tmpTable.Rows(i)(CStr(groupList(level)))) Then
                                parentRow(descFieldName) = NULL_ALIAS
                            Else
                                parentRow(descFieldName) = tmpTable.Rows(i)(CStr(groupList(level)))
                            End If
                        End If
                    Next
                    parentRow("SortIndex") = parentRow.Index
                    If j = tmpTable.Rows.Count - 1 And ROLLUP Then
                        parentRow.State = PlusMinusState.Total
                    Else
                        parentRow.State = PlusMinusState.Collapsed
                    End If
                    GroupTable.m_rowStates.Add(parentRow.State)
                    parentRow.Level = level
                    parentRow.Parent = Nothing
                    GroupTable.Childs.Add(parentRow)
                    RecurFillGroupTable(parentRow, tmpTables(level).Rows(i), groupList, tmpTables, level + 1, fieldNames, descFieldName, sortCols, ROLLUP)
                    AddHandler parentRow.Expand, AddressOf GroupTable.ExpandCollapseHandler
                    AddHandler parentRow.Collapse, AddressOf GroupTable.ExpandCollapseHandler
                    j += 1
                Next
            End If
        End Function
        Private Sub RecurFillGroupTable(ByVal parent As ExpandableDataRow, ByVal row As DataRow, ByVal groupList As ArrayList, ByVal tmpTables() As DataTable, ByVal level As Integer, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean)
            Dim arr As New ArrayList
            For Each col As DataColumn In tmpTables(level - 1).Columns
                Dim value As String
                If IsDBNull(row(col)) Then
                    value = "null"
                Else
                    value = "'" & CStr(row(col)) & "'"
                End If
                arr.Add(value)
            Next
            Dim filter As String = String.Format(BuildFilter(groupList, level - 1), arr.ToArray)
            filter = Replace(filter, "=null", " is null")
            If level = groupList.Count Then
                Dim tmpChildRows As ExpandableDataRow() = CType(Me.Select(filter, sortCols), ExpandableDataRow())
                For Each tmpChildRow As ExpandableDataRow In tmpChildRows
                    Dim values() As Object = tmpChildRow.ItemArray
                    Dim theRow As ExpandableDataRow = CType(GroupTable.LoadDataRow(values, True), ExpandableDataRow)
                    GroupTable.m_rowStates.Add(theRow.State)
                    theRow.Level = level
                    theRow.Index = m_rowIndex
                    theRow("SortIndex") = theRow.Index
                    m_rowIndex += 1
                    theRow.Parent = parent
                    parent.Childs.Add(theRow)
                Next
                Return
            End If
            Dim tmpTable As DataTable = dsHelper.SelectGroupByInto("test", Me, fieldNames, filter, CStr(groupList(level)))
            Dim j As Integer = 0
            For i As Integer = 0 To tmpTable.Rows.Count - 1
                Dim parentRow As ExpandableDataRow = GroupTable.Add("")
                parentRow.Index = m_rowIndex
                m_rowIndex += 1
                For Each col As DataColumn In Me.Columns
                    Dim groupColMatch As Boolean = False
                    For lv As Integer = 0 To groupList.Count - 1
                        If CStr(groupList(lv)).ToLower = col.ColumnName.ToLower Then
                            groupColMatch = True
                            Exit For
                        End If
                    Next
                    If tmpTable.Columns.IndexOf(col.ColumnName) >= 0 And Not groupColMatch And GroupTable.Columns(col.ColumnName).ReadOnly = False Then
                        parentRow(col.ColumnName) = tmpTable.Rows(i)(col.ColumnName)
                    End If
                    If j = tmpTable.Rows.Count - 1 And ROLLUP Then
                        parentRow(descFieldName) = "Total"
                    Else
                        If IsDBNull(tmpTable.Rows(i)(CStr(groupList(level)))) Then
                            parentRow(descFieldName) = NULL_ALIAS
                        Else
                            parentRow(descFieldName) = tmpTable.Rows(i)(CStr(groupList(level)))
                        End If
                    End If
                Next
                parentRow("SortIndex") = parentRow.Index
                If j = tmpTable.Rows.Count - 1 And ROLLUP Then
                    parentRow.State = PlusMinusState.Total
                Else
                    parentRow.State = PlusMinusState.Collapsed
                End If
                GroupTable.m_rowStates.Add(parentRow.State)
                parentRow.Level = level
                parentRow.Parent = parent
                parent.Childs.Add(parentRow)
                Dim myRow As DataRow = tmpTables(level).Select(filter)(i)
                RecurFillGroupTable(parentRow, myRow, groupList, tmpTables, level + 1, fieldNames, descFieldName, sortCols, ROLLUP)
                AddHandler parentRow.Expand, AddressOf GroupTable.ExpandCollapseHandler
                AddHandler parentRow.Collapse, AddressOf GroupTable.ExpandCollapseHandler
                j += 1
            Next
        End Sub
        Public Sub ApplyRowState()
            If m_rowStates Is Nothing Then
                Return
            End If
            For Each row As ExpandableDataRow In Me.Childs
                RecurApplyRowState(row)
            Next
        End Sub
        Private Sub RecurApplyRowState(ByVal row As ExpandableDataRow)
            For Each myRow As ExpandableDataRow In row.Childs
                RecurApplyRowState(myRow)
                myRow.State = CType(Me.m_rowStates(myRow.Index), PlusMinusState)
            Next
        End Sub
        Private Function GetFieldList(ByVal groupList As ArrayList, ByVal level As Integer) As String
            Dim ret As String
            For i As Integer = 0 To level
                If CStr(groupList(i)) <> "" Then
                    ret &= CStr(groupList(i)) & ","
                End If
            Next
            Return ret.TrimEnd(","c)
        End Function
        Private Function BuildFilter(ByVal groupList As ArrayList, ByVal level As Integer) As String
            Dim ret As String
            For i As Integer = 0 To level
                ret &= CStr(groupList(i)) & "={" & CStr(i) & "} and "
            Next
            ret = Left(ret, ret.LastIndexOf(" and "))
            Return ret
        End Function
        Public Sub UpdateGroupChild(ByVal row As ExpandableDataRow)
            Dim arr As New ArrayList
            For i As Integer = 0 To Me.m_groupbyFieldList.Count - 1
                Dim value As Object = row(CStr(m_groupbyFieldList(i)))
                If IsDBNull(value) Then
                    value = NULL_ALIAS
                End If
                arr.Add(value)
            Next
            If arr.Count = 0 Then
                Return
            End If
            Dim newParentRow As ExpandableDataRow = GetNewParentRow(Nothing, arr, 0)
            If Not newParentRow Is Nothing Then
                Dim insertIndex As Integer = GetChildIndexInOrder(row, newParentRow)
                MoveRow(row, newParentRow, insertIndex)
            Else
                Debug.WriteLine("None")
            End If
        End Sub
        Private Function GetNewParentRow(ByVal row As ExpandableDataRow, ByVal arr As ArrayList, ByVal level As Integer) As ExpandableDataRow
            If level = arr.Count Then
                Return row
            End If
            If level = 0 Then
                For Each child As ExpandableDataRow In Me.Childs
                    If CStr(child(Me.m_descField)).ToLower = CStr((arr(level))).ToLower Then
                        'found Level 0 Group
                        Return GetNewParentRow(child, arr, level + 1)
                    End If
                Next
                'not found >> Add a new Level 0 Group
                'for now Add it at the first position
                Dim firstRow As ExpandableDataRow = Me.Childs(level)
                Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
                tmprow(Me.m_descField) = arr(level)
                tmprow.Level = level
                tmprow.State = PlusMinusState.Expanded
                Dim insertIndex As Integer = GetChildIndexInOrder(tmprow, row)
                Dim myRow As ExpandableDataRow = Me.InsertRow(tmprow, row, insertIndex, PlusMinusState.Expanded)
                AddHandler myRow.Collapse, AddressOf Me.ExpandCollapseHandler
                AddHandler myRow.Expand, AddressOf Me.ExpandCollapseHandler
                Return GetNewParentRow(myRow, arr, level + 1)
            Else
                For Each child As ExpandableDataRow In row.Childs
                    If CStr(child(Me.m_descField)).ToLower = CStr((arr(level))).ToLower Then
                        'found this level group
                        Return GetNewParentRow(child, arr, level + 1)
                    End If
                Next
                'not found >> Add a group of this level
                Dim tmprow As ExpandableDataRow = CType(Me.NewRow, ExpandableDataRow)
                tmprow(Me.m_descField) = arr(level)
                tmprow.Level = level
                tmprow.State = PlusMinusState.Expanded
                Dim insertIndex As Integer = GetChildIndexInOrder(tmprow, row)
                Dim myRow As ExpandableDataRow = Me.InsertRow(tmprow, row, insertIndex, PlusMinusState.Expanded)
                AddHandler myRow.Collapse, AddressOf Me.ExpandCollapseHandler
                AddHandler myRow.Expand, AddressOf Me.ExpandCollapseHandler
                Return GetNewParentRow(myRow, arr, level + 1)
            End If
        End Function
        Private Function GetChildIndexInOrder(ByVal childRow As ExpandableDataRow, ByVal parentRow As ExpandableDataRow) As Integer
            Dim sortColName As String
            If childRow.State = PlusMinusState.UnderParent Then
                If Me.m_sortColumn Is Nothing Or Me.m_sortColumn = "" Then
                    sortColName = Me.m_descField
                Else
                    sortColName = Me.m_sortColumn
                End If
            Else
                sortColName = Me.m_descField
            End If
            If parentRow Is Nothing Then
                For i As Integer = 0 To Me.Childs.Count - 1
                    If CStr(Me.Childs(i)(sortColName)).CompareTo(childRow(sortColName)) > 0 Then
                        Return i
                    End If
                Next
                Return Me.Childs.Count
            Else
                For i As Integer = 0 To parentRow.Childs.Count - 1
                    If CStr(parentRow.Childs(i)(sortColName)).CompareTo(childRow(sortColName)) > 0 Then
                        Return i
                    End If
                Next
                Return parentRow.Childs.Count
            End If
        End Function
        Public Sub UpdateGroupChild(ByVal row As ExpandableDataRow, ByVal colName As String, ByVal value As Object)
            'If row.Parent Is Nothing OrElse row.Parent.Parent Is Nothing Then
            '    Exit Sub
            'End If

            If GroupbyFieldList.IndexOf(colName.ToLower) >= 0 Then
                Dim newParentRow As ExpandableDataRow
                Dim oldParent As ExpandableDataRow
                If Not row.Parent Is Nothing AndAlso Not row.Parent.Parent Is Nothing Then
                    oldParent = row.Parent
                    For Each myRow As ExpandableDataRow In row.Parent.Parent.Childs ' ปู่คือ row
                        If CStr(myRow(Me.DescField)).ToLower = CStr(row(colName)).ToLower Then
                            newParentRow = myRow
                            Exit For
                        End If
                    Next
                ElseIf Not row.Parent Is Nothing Then
                    oldParent = row.Parent
                    For Each myRow As ExpandableDataRow In Me.Childs ' ปู่คือ table
                        If CStr(myRow(Me.DescField)).ToLower = CStr(row(colName)).ToLower Then
                            newParentRow = myRow
                            Exit For
                        End If
                    Next
                End If

                If Not newParentRow Is Nothing Then
                    MoveRow(row.Index, newParentRow.Childs(0).Index)
                End If
            End If
        End Sub
        Public Sub UpdateAggregate(ByVal parentRow As ExpandableDataRow)
            If parentRow.State <> PlusMinusState.Collapsed And parentRow.State <> PlusMinusState.Expanded Then
                Return
            End If
            For Each column As DataColumn In parentRow.Table.Columns
                Dim colName As String = column.ColumnName
                For Each fldNfo As FieldInfo In m_aggregateFieldInfo
                    Dim agg As String = fldNfo.Aggregate
                    If agg <> "" AndAlso fldNfo.FieldName.ToLower = colName.ToLower Then
                        UpdateAggregate(parentRow, agg, colName)
                    End If
                Next
            Next
        End Sub
        Public Sub UpdateAggregate(ByVal parentRow As ExpandableDataRow, ByVal colName As String)
            Dim agg As String
            For Each fldNfo As FieldInfo In m_aggregateFieldInfo
                If fldNfo.Aggregate <> "" AndAlso fldNfo.FieldName.ToLower = colName.ToLower Then
                    agg = fldNfo.Aggregate
                    'Exit For
                End If
            Next
            If agg = "" Then
                Exit Sub
            End If
            UpdateAggregate(parentRow, agg, colName)
        End Sub
        Public Sub UpdateAggregate(ByVal parentRow As ExpandableDataRow, ByVal agg As String, ByVal colName As String)
            Dim myRow As ExpandableDataRow = parentRow
            While Not myRow Is Nothing
                Dim aggValue As Double = 0
                For Each childRow As ExpandableDataRow In myRow.Childs
                    Select Case agg.ToLower  'count,sum,max,min,first,last,avg
                        Case "count"
                            aggValue += 1
                        Case "sum", "avg"
                            aggValue += CDbl(childRow(colName))
                        Case "max"
                            aggValue = Math.Max(aggValue, CDbl(childRow(colName)))
                        Case "min"
                            aggValue = Math.Min(aggValue, CDbl(childRow(colName)))
                    End Select
                Next
                If agg.ToLower = "avg" Then
                    aggValue = aggValue / parentRow.Childs.Count
                ElseIf agg.ToLower = "first" Then
                    If myRow.Childs.Count > 0 Then
                        aggValue = CDbl(myRow.Childs(0)(colName))
                    End If
                ElseIf agg.ToLower = "last" Then
                    If myRow.Childs.Count > 0 Then
                        aggValue = CDbl(myRow.Childs(0)(parentRow.Childs.Count - 1))
                    End If
                End If
                Debug.WriteLine(aggValue)
                myRow(colName) = aggValue
                myRow = myRow.Parent
            End While
        End Sub
        Public Function SelectDistinct(ByVal cnames As String, Optional ByVal filter As String = "", Optional ByVal sortString As String = "") As DataTable
            Dim dt As DataTable = dsHelper.SelectDistinct("test", Me, cnames, filter, sortString)
            Return dt
        End Function
        Private Function FieldList() As String
            Dim fl As String
            For Each col As DataColumn In Me.Columns
                fl &= col.ColumnName & ","
            Next
            If fl.EndsWith(",") Then
                fl = Left(fl, Len(fl) - 1)
            End If
            Return fl
        End Function
        Private Sub ParseFieldList()
            Const OperatorList As String = ",count,sum,max,min,first,last,avg"
            Me.m_aggregateFieldInfo = New ArrayList
            Dim Field As FieldInfo, FieldParts() As String, Fields() As String = m_fieldNames.Split(","c)
            Dim I As Integer
            For I = 0 To Fields.Length - 1
                Field = New FieldInfo
                '
                ' Parse FieldAlias
                '
                FieldParts = Fields(I).Trim().Split(" "c)
                Select Case FieldParts.Length
                    Case 1
                        ' To be set at the end of the loop
                    Case 2
                        Field.FieldAlias = FieldParts(1)
                    Case Else
                        Throw New ArgumentException("Too many spaces in field definition: '" & Fields(I) & "'.")
                End Select
                '
                ' Parse FieldName and Aggregate
                '
                FieldParts = FieldParts(0).Split("("c)
                Select Case FieldParts.Length
                    Case 1
                        Field.FieldName = FieldParts(0)
                    Case 2
                        Field.Aggregate = FieldParts(0).Trim().ToLower() ' You will do a case-sensitive comparison later.
                        Field.FieldName = FieldParts(1).Trim(" "c, ")"c)
                    Case Else
                        Throw New ArgumentException("Invalid field definition: '" & Fields(I) & "'.")
                End Select
                If Field.FieldAlias = "" Then
                    If Field.Aggregate = "" Then
                        Field.FieldAlias = Field.FieldName
                    Else
                        Field.FieldAlias = Field.Aggregate & "Of" & Field.FieldName
                    End If
                End If
                m_aggregateFieldInfo.Add(Field)
            Next
        End Sub
        Private Class FieldInfo
            Public RelationName As String
            Public FieldName As String      ' source table field name
            Public FieldAlias As String     ' destination table field name
            Public Aggregate As String
        End Class
#End Region

#Region "Overrides"
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New ExpandableDataRow(builder)
        End Function

        Protected Overrides Function GetRowType() As System.Type
            Return GetType(ExpandableDataRow)
        End Function
#End Region

    End Class
End Namespace
