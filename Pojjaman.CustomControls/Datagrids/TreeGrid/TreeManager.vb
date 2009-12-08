Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Xml
Imports Longkong.Core.Services
Imports Longkong.Core
Namespace Longkong.Pojjaman.Gui.Components
  Public Enum SortingDirection
    None
    Asc
    Desc
  End Enum
  Public Class SortedColumn

#Region "Members"
    Private m_colName As String
    Private m_sortingDirection As SortingDirection
#End Region

#Region "Constructors"
    Public Sub New(ByVal colName As String)
      Me.m_colName = colName
      Me.m_sortingDirection = SortingDirection.None
    End Sub
    Public Sub New(ByVal colName As String, ByVal direction As SortingDirection)
      Me.m_colName = colName
      Me.m_sortingDirection = direction
    End Sub
#End Region

#Region "Properties"
    Public Property ColName() As String      Get        Return m_colName      End Get      Set(ByVal Value As String)        m_colName = Value      End Set    End Property    Public Property SortingDirection() As SortingDirection      Get        Return m_sortingDirection      End Get      Set(ByVal Value As SortingDirection)        m_sortingDirection = Value      End Set    End Property
#End Region

  End Class
  Public Class TreeManager

#Region "Members"
    Private m_treetable As Treetable
    Private m_treegrid As Treegrid
    Private dsHelper As New DataSetHelper
    Private m_allowSorting As Boolean = True
    Private m_sortFieldCount As Integer = 3
    Private m_importStyleConfigFromGrid As Boolean = True

    Private m_showGroupPrefix As Boolean = False

    Private m_groupbyFieldList As ArrayList
    Private m_fieldList As ArrayList
    Private m_sortStack As Stack
    Private m_allowDelete As Boolean = False

    Private m_descField As String
    Private m_rollup As Boolean

    Private m_gridTableStyle As DataGridTableStyle

    Public Const NULL_ALIAS As String = "None"

#End Region

#Region "Constructors"
    Public Sub New(ByVal table As Treetable, ByVal grid As Treegrid)
      Me.m_treegrid = grid
      Me.m_treegrid.TreeManager = Me
      Me.m_treetable = table

      Me.m_fieldList = New ArrayList
      Me.m_groupbyFieldList = New ArrayList
      Me.m_sortStack = New Stack(Me.m_sortFieldCount)

      PoplateGridWithTable()
      AddHandler m_treegrid.ColumnHeaderClicked, AddressOf Grid_ColumnHeaderClicked
    End Sub
    Public Sub New(ByVal table As DataTable, ByVal grid As Treegrid)
      Me.m_treegrid = grid
      Me.m_treegrid.TreeManager = Me

      PoplateGridWithTable(table)
      'AddHandler m_treegrid.ColumnHeaderClicked, AddressOf Grid_ColumnHeaderClicked
      'AddHandler Me.m_treegrid.CurrentCellChanged, Nothing
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub Grid_ColumnHeaderClicked(ByVal sender As Object, ByVal e As TreeColumnHeaderClickEventArgs)
      ChangeSortingDirection(e.Column)
    End Sub
    Private Sub ChangeSortingDirection(ByVal colId As Integer)
      If Not Me.m_gridTableStyle Is Nothing Then
        Dim myCol As SortedColumn = New SortedColumn(m_gridTableStyle.GridColumnStyles(colId).MappingName, SortingDirection.Asc)
        If Not m_sortStack.Count = 0 AndAlso CType(m_sortStack.Peek, SortedColumn).ColName = myCol.ColName Then
          'เป็นคอลัมน์เดิม
          Dim lastCol As SortedColumn = CType(m_sortStack.Peek, SortedColumn)
          If lastCol.SortingDirection = SortingDirection.None Then
            lastCol.SortingDirection = SortingDirection.Asc
          ElseIf myCol.SortingDirection = SortingDirection.Desc Then
            lastCol.SortingDirection = SortingDirection.Asc
          Else
            lastCol.SortingDirection = SortingDirection.Desc
          End If
        Else
          If m_sortStack.Count = m_sortFieldCount Then
            m_sortStack.Pop()
          End If
          m_sortStack.Push(myCol)
        End If
      End If
      Me.m_treegrid.Refresh()
    End Sub
#End Region

#Region "Grouping Properties"
    Public Property AllowDelete() As Boolean      Get        Return m_allowDelete      End Get      Set(ByVal Value As Boolean)        m_allowDelete = Value      End Set    End Property
    Public Property GroupbyFieldList() As ArrayList      Get        Return m_groupbyFieldList      End Get      Set(ByVal Value As ArrayList)        m_groupbyFieldList = Value      End Set    End Property    Public Property DescField() As String      Get        Return m_descField      End Get      Set(ByVal Value As String)        m_descField = Value      End Set    End Property    Public Property SortFieldCount() As Integer      Get        Return m_sortFieldCount      End Get      Set(ByVal Value As Integer)        m_sortFieldCount = Value      End Set    End Property
    Public Property SortStack() As Stack      Get        Return m_sortStack      End Get      Set(ByVal Value As Stack)        m_sortStack = Value      End Set    End Property    Public Property FieldList() As ArrayList      Get        Return m_fieldList      End Get      Set(ByVal Value As ArrayList)        m_fieldList = Value      End Set    End Property    Public Property Rollup() As Boolean      Get        Return m_rollup      End Get      Set(ByVal Value As Boolean)        m_rollup = Value      End Set    End Property
#End Region

#Region "Properties"
    Public Property Treetable() As Treetable      Get        Return m_treetable      End Get      Set(ByVal Value As Treetable)        m_treetable = Value        PoplateGridWithTable()      End Set    End Property    Public Property Treegrid() As Treegrid      Get        Return m_treegrid      End Get      Set(ByVal Value As Treegrid)        m_treegrid = Value      End Set    End Property
    Public Property ShowGroupPrefix() As Boolean      Get        Return m_showGroupPrefix      End Get      Set(ByVal Value As Boolean)        m_showGroupPrefix = Value      End Set    End Property
    Public Property ImportStyleConfigFromGrid() As Boolean      Get        Return m_importStyleConfigFromGrid      End Get      Set(ByVal Value As Boolean)        m_importStyleConfigFromGrid = Value      End Set    End Property
    Public Property AllowSorting() As Boolean      Get        Return m_allowSorting      End Get      Set(ByVal Value As Boolean)        m_allowSorting = Value      End Set    End Property
    Public Property GridTableStyle() As DataGridTableStyle      Get        Return m_gridTableStyle      End Get      Set(ByVal Value As DataGridTableStyle)        m_gridTableStyle = Value      End Set    End Property
    Public Property SelectedRow() As TreeRow
      Get
        Dim indx As Integer = Me.m_treegrid.CurrentRowIndex
        If indx < 0 Or indx > Me.m_treetable.Rows.Count - 1 Then
          Return Nothing
        End If
        Dim row As TreeRow = CType(Me.m_treetable.Rows(indx), TreeRow)
        Return row
      End Get
      Set(ByVal Value As TreeRow)
        If Value Is Nothing Then
          Return
        End If
        Me.m_treegrid.CurrentRowIndex = Value.Index
      End Set
    End Property
    Public ReadOnly Property SelectedRows() As ArrayList
      Get
        Dim arr As New ArrayList
        If Me.Treegrid Is Nothing Then
          Return arr
        End If
        If Me.Treetable Is Nothing Then
          Return arr
        End If
        For i As Integer = 0 To Me.Treetable.Rows.Count - 1
          If Me.Treegrid.IsSelected(i) OrElse Me.Treegrid.CurrentRowIndex = i Then
            arr.Add(Me.Treetable.Rows(i))
          End If
        Next
        Return arr
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function [Select](ByVal table As DataTable, ByVal filter As String, ByVal sort As String) As TreeRow()
      If table Is Nothing Then
        Return Nothing
      End If
      Dim filteredData As New DataView(table)
      Try
        If Not sort Is Nothing AndAlso sort <> String.Empty Then
          filteredData.Sort = sort
        End If
        If Not filter Is Nothing AndAlso filter <> String.Empty Then
          filteredData.RowFilter = filter
        End If

        Dim resultSet As TreeRow() = New TreeRow(filteredData.Count - 1) {}
        Dim i As Integer = 0
        For Each rowView As DataRowView In filteredData
          resultSet(i) = CType(rowView.Row, TreeRow)
          i += 1
        Next
        Return resultSet
      Finally
        filteredData.Dispose()
      End Try
    End Function
#End Region

#Region "Methods"
    Public Sub DisableStyle()
      'For Each col As DataGridColumnStyle In Me.GridTableStyle.GridColumnStyles
      '    If TypeOf col Is DataGridButtonColumn Then
      '        For Each row As DataRow In Me.Treetable.Rows
      '            row(col.MappingName) = "invisible"
      '        Next
      '    Else
      '        col.ReadOnly = True
      '    End If
      'Next
    End Sub
    Public Sub EnableStyle()
      'If m_columnReadOnly Is Nothing Then
      '    Return
      'End If
      'Dim i As Integer = 0
      'For Each col As DataGridColumnStyle In Me.GridTableStyle.GridColumnStyles
      '    If TypeOf col Is DataGridButtonColumn Then
      '        For Each row As DataRow In Me.Treetable.Rows
      '            row(col.MappingName) = m_columnReadOnly(i)
      '        Next
      '    Else
      '        col.ReadOnly = CBool(m_columnReadOnly(i))
      '    End If
      '    i += 1
      'Next
    End Sub
    Private m_columnReadOnly As ArrayList
    Public Sub SetTableStyle(ByVal style As DataGridTableStyle)
      If m_treegrid.TableStyles.Contains(style.MappingName) Then
        Dim dst As DataGridTableStyle = m_treegrid.TableStyles(style.MappingName)
        For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
          If TypeOf colStyle Is PJMColumnStyle Then
            CType(colStyle, PJMColumnStyle).RemoveHandlers()
          End If
        Next
        m_treegrid.TableStyles.Remove(m_treegrid.TableStyles(style.MappingName))
        For Each ctrl As Control In m_treegrid.Controls
          If TypeOf ctrl Is ComboBox Then
            m_treegrid.Controls.Remove(ctrl)
          End If
        Next
      End If
      If m_importStyleConfigFromGrid Then
        ApplyStyleConfig(style)
      End If
      'Hack:
      style.AllowSorting = False

      m_treegrid.TableStyles.Add(style)
      Me.m_gridTableStyle = style

      m_columnReadOnly = New ArrayList
      For Each col As DataGridColumnStyle In Me.m_gridTableStyle.GridColumnStyles
        If TypeOf col Is DataGridButtonColumn Then
          If Me.Treetable.Childs.Count > 0 Then
            m_columnReadOnly.Add(Me.Treetable.Childs(0)(col.MappingName))
          End If
        Else
          m_columnReadOnly.Add(col.ReadOnly)
        End If
      Next
    End Sub
    Private Sub ApplyStyleConfig(ByVal style As DataGridTableStyle)
      style.AllowSorting = m_treegrid.AllowSorting
      style.AlternatingBackColor = m_treegrid.AlternatingBackColor
      style.BackColor = m_treegrid.BackColor
      style.ColumnHeadersVisible = m_treegrid.ColumnHeadersVisible
      style.ForeColor = m_treegrid.ForeColor
      style.GridLineColor = m_treegrid.GridLineColor
      style.GridLineStyle = m_treegrid.GridLineStyle
      style.HeaderBackColor = m_treegrid.HeaderBackColor
      style.HeaderFont = m_treegrid.HeaderFont
      style.HeaderForeColor = m_treegrid.HeaderForeColor
      style.LinkColor = m_treegrid.LinkColor
      style.PreferredColumnWidth = m_treegrid.PreferredColumnWidth
      style.PreferredRowHeight = m_treegrid.PreferredRowHeight
      style.ReadOnly = m_treegrid.ReadOnly
      style.RowHeadersVisible = m_treegrid.RowHeadersVisible
      style.RowHeaderWidth = m_treegrid.RowHeaderWidth
      style.SelectionBackColor = m_treegrid.SelectionBackColor
      style.SelectionForeColor = m_treegrid.SelectionForeColor
    End Sub
    Public Sub ClearTable()
      If Me.m_treetable Is Nothing Then
        Return
      End If
      Dim dt As Treetable = CType(Me.m_treetable.Clone, Treetable)
      dt.Clear()
      Me.Treetable = dt
    End Sub
    Public Sub RemoveSelectedRow()
      Dim row As TreeRow = Me.SelectedRow
      If row Is Nothing Then
        Return
      End If
      row.Parent.Childs.Remove(row)
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
    End Sub
    Public Function InsertBlankFriendOfSelectedRow() As TreeRow
      Dim friendRow As TreeRow = Me.SelectedRow
      If friendRow Is Nothing Then
        Return Nothing
      End If
      Dim row As TreeRow = CType(friendRow.Clone, TreeRow)
      For Each col As DataColumn In Me.m_treetable.Columns
        row(col) = DBNull.Value
      Next
      Return InsertFriendOfSelectedRow(row)
    End Function
    Public Function InsertFriendOfSelectedRow() As TreeRow
      Return InsertFriendOfSelectedRow(RowExpandState.None)
    End Function
    Public Function InsertFriendOfSelectedRow(ByVal state As RowExpandState) As TreeRow
      If Me.SelectedRow Is Nothing Then
        Return Nothing
      End If
      Dim friendRow As TreeRow = Me.SelectedRow
      Dim row As TreeRow = CType(friendRow.Clone, TreeRow)
      row.State = state
      Return InsertFriendOfSelectedRow(row)
    End Function
    Public Function InsertFriendOfSelectedRow(ByVal row As TreeRow) As TreeRow
      Dim friendRow As TreeRow = Me.SelectedRow
      friendRow.Parent.Childs.InsertAt(friendRow.Parent.Childs.IndexOf(friendRow), row)
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
      Return row
    End Function
    Public Function AddChildOfSelectedRow() As TreeRow
      Return AddChildOfSelectedRow(RowExpandState.None)
    End Function
    Public Function AddChildOfSelectedRow(ByVal state As RowExpandState) As TreeRow
      If Me.SelectedRow Is Nothing Then
        Return Nothing
      End If
      Dim parentRow As TreeRow = Me.SelectedRow
      Dim row As TreeRow = CType(parentRow.Clone, TreeRow)
      For Each col As DataColumn In Me.m_treetable.Columns
        row(col) = DBNull.Value
      Next
      row.State = state
      Return AddChildOfSelectedRow(row)
    End Function
    Public Function AddChildOfSelectedRow(ByVal row As TreeRow) As TreeRow
      Dim parentRow As TreeRow = Me.SelectedRow
      parentRow.Childs.Add(row)
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
      Return row
    End Function
    Public Sub PoplateGridWithTable()
      Me.m_treegrid.DataSource = Nothing
      Me.m_treegrid.DataSource = Me.m_treetable
    End Sub
    Public Sub PoplateGridWithTable(ByVal dt As DataTable)
      Me.m_treegrid.DataSource = dt
    End Sub
    Public Sub UnGroupTree()
      Me.m_treetable = Me.ChildTable
      Me.m_treegrid.DataSource = Nothing
      Me.m_treegrid.DataSource = Me.m_treetable
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
    End Sub
    Public Sub SortBy()
      If Not Me.m_allowSorting Then
        Return
      End If
      Me.m_treetable = Me.ChildTable
      Me.m_treetable = Me.UpdateGroup()
      Me.m_treegrid.DataSource = Nothing
      Me.m_treegrid.DataSource = Me.m_treetable
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
    End Sub
    Public Sub GroupTree(ByVal groupList As ArrayList, ByVal fieldList As ArrayList, ByVal descFieldName As String, ByVal ROLLUP As Boolean)
      Me.m_treetable = Me.ChildTable
      Me.m_treetable = Me.UpdateGroup(groupList, fieldList, descFieldName, ROLLUP)
      Me.m_treegrid.DataSource = Nothing
      Me.m_treegrid.DataSource = Me.m_treetable
      Me.m_treetable.AcceptChanges()
      Me.m_treegrid.RefreshHeights()
    End Sub
    Public Function SelectDistinct(ByVal cnames As String, Optional ByVal filter As String = "", Optional ByVal sortString As String = "") As DataTable
      Dim dt As DataTable = dsHelper.SelectDistinct("DistinctTable", Me.m_treetable, cnames, filter, sortString)
      Return dt
    End Function
    Public Function UpdateGroup(ByVal groupList As ArrayList, ByVal fieldList As ArrayList, ByVal descFieldName As String, ByVal ROLLUP As Boolean) As Treetable
      Me.GroupbyFieldList = groupList
      Me.FieldList = fieldList
      Me.DescField = descFieldName
      Me.Rollup = ROLLUP
      Return GroupBy()
    End Function
    Public Function UpdateGroup() As Treetable
      Return GroupBy()
    End Function
    Private GroupTable As Treetable
    Public Function ChildTable() As Treetable
      Dim retTable As Treetable = CType(Me.m_treetable.Clone, Treetable)
      For i As Integer = 0 To Me.m_treetable.Rows.Count - 1
        Dim row As TreeRow = CType(Me.m_treetable.Rows(i), TreeRow)
        If row.Level = Me.m_treetable.MaxLevel Then
          Dim values() As Object = row.ItemArray
          Dim theRow As TreeRow = retTable.Childs.Add
          For j As Integer = 0 To Me.m_treetable.Columns.Count - 1
            theRow(j) = row(j)
          Next
          theRow.State = RowExpandState.Collapsed
        End If
      Next
      Return retTable
    End Function
    Private Function GroupBy() As Treetable
      Dim tmpTables(m_groupbyFieldList.Count) As DataTable
      For level As Integer = 0 To m_groupbyFieldList.Count - 1
        Dim fieldString As String = GetFieldList(m_groupbyFieldList, level)
        tmpTables(level) = SelectDistinct(fieldString, "", fieldString)
      Next
      GroupTable = CType(Me.m_treetable.Clone, Treetable)
      GroupTable.Initialized = False
      FillGroupTable(tmpTables, 0)
      GroupTable.Initialized = True
      Return GroupTable
    End Function
    Private Function FillGroupTable(ByVal tmpTables() As DataTable, ByVal level As Integer) As DataTable
      Dim tmpTable As DataTable = dsHelper.SelectGroupByInto("test", Me.m_treetable, GetFieldList(m_groupbyFieldList, m_groupbyFieldList.Count - 1) & "," & GetFieldList(Me.m_fieldList, m_fieldList.Count - 1), , CStr(m_groupbyFieldList(level)))
      For i As Integer = 0 To tmpTable.Rows.Count - 1
        Dim parentRow As TreeRow = GroupTable.Childs.Add
        For Each col As DataColumn In Me.m_treetable.Columns
          Dim groupColMatch As Boolean = False
          For lv As Integer = 0 To m_groupbyFieldList.Count - 1
            If CStr(m_groupbyFieldList(lv)).ToLower = col.ColumnName.ToLower Then
              groupColMatch = True
              Exit For
            End If
          Next
          If tmpTable.Columns.IndexOf(col.ColumnName) >= 0 And Not groupColMatch And GroupTable.Columns(col.ColumnName).ReadOnly = False Then
            parentRow(col.ColumnName) = tmpTable.Rows(i)(col.ColumnName)
          End If
          If i = tmpTable.Rows.Count - 1 And m_rollup Then
            parentRow(m_descField) = "Total"
          Else
            Dim prefix As String = ""
            If m_showGroupPrefix Then
              prefix = CStr(m_groupbyFieldList(level)) & ":"
            Else
              prefix = ""
            End If
            If IsDBNull(tmpTable.Rows(i)(CStr(m_groupbyFieldList(level)))) Then
              parentRow(m_descField) = prefix & NULL_ALIAS
            Else
              parentRow(m_descField) = prefix & tmpTable.Rows(i)(CStr(m_groupbyFieldList(level))).ToString
            End If
          End If
        Next
        If i = tmpTable.Rows.Count - 1 And m_rollup Then
          parentRow.State = RowExpandState.Collapsed
        Else
          parentRow.State = RowExpandState.Collapsed
        End If
        RecurFillGroupTable(parentRow, tmpTables(level).Rows(i), tmpTables, level + 1)
      Next
    End Function
    Private Sub RecurFillGroupTable(ByVal parent As TreeRow, ByVal row As DataRow, ByVal tmpTables() As DataTable, ByVal level As Integer)
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
      Dim filter As String = String.Format(BuildFilter(m_groupbyFieldList, level - 1), arr.ToArray)
      filter = Replace(filter, "=null", " is null")
      If level = m_groupbyFieldList.Count Then
        Dim s As String = ""
        If Not Me.m_sortStack Is Nothing Then
          For Each col As SortedColumn In Me.m_sortStack
            If col.SortingDirection <> SortingDirection.None Then
              s &= col.ColName & " " & col.SortingDirection.ToString & ","
            End If
          Next
          s = s.TrimEnd(","c)
        End If
        Dim tmpChildRows As TreeRow() = CType(Me.Select(Me.m_treetable, filter, s), TreeRow())
        For Each tmpChildRow As TreeRow In tmpChildRows
          Dim theRow As TreeRow = parent.Childs.Add
          For i As Integer = 0 To GroupTable.Columns.Count - 1
            theRow(i) = tmpChildRow(i)
          Next
        Next
        'For indx As Integer = 0 To tmpChildRows.GetUpperBound(0)
        '    Dim theRow As TreeRow = parent.Childs.Add
        '    For i As Integer = 0 To GroupTable.Columns.Count - 1
        '        theRow(i) = tmpChildRows(indx)(i)
        '    Next
        'Next
        Return
      End If
      Dim tmpTable As DataTable = dsHelper.SelectGroupByInto("test", Me.m_treetable, GetFieldList(m_groupbyFieldList, m_groupbyFieldList.Count - 1) & "," & GetFieldList(Me.m_fieldList, m_fieldList.Count - 1), filter, CStr(m_groupbyFieldList(level)))
      Dim j As Integer = 0
      For i As Integer = 0 To tmpTable.Rows.Count - 1
        Dim parentRow As TreeRow = parent.Childs.Add
        For Each col As DataColumn In Me.m_treetable.Columns
          Dim groupColMatch As Boolean = False
          For lv As Integer = 0 To m_groupbyFieldList.Count - 1
            If CStr(m_groupbyFieldList(lv)).ToLower = col.ColumnName.ToLower Then
              groupColMatch = True
              Exit For
            End If
          Next
          If tmpTable.Columns.IndexOf(col.ColumnName) >= 0 And Not groupColMatch And GroupTable.Columns(col.ColumnName).ReadOnly = False Then
            parentRow(col.ColumnName) = tmpTable.Rows(i)(col.ColumnName)
          End If
          If j = tmpTable.Rows.Count - 1 And m_rollup Then
            parentRow(m_descField) = "Total"
          Else
            Dim prefix As String = ""
            If m_showGroupPrefix Then
              prefix = CStr(m_groupbyFieldList(level)) & ":"
            Else
              prefix = ""
            End If
            If IsDBNull(tmpTable.Rows(i)(CStr(m_groupbyFieldList(level)))) Then
              parentRow(m_descField) = prefix & NULL_ALIAS
            Else
              parentRow(m_descField) = prefix & tmpTable.Rows(i)(CStr(m_groupbyFieldList(level))).ToString
            End If
          End If
        Next
        If j = tmpTable.Rows.Count - 1 And m_rollup Then
          parentRow.State = RowExpandState.Collapsed
        Else
          parentRow.State = RowExpandState.Collapsed
        End If
        Dim myRow As DataRow = Me.Select(tmpTables(level), filter, "")(i)
        RecurFillGroupTable(parentRow, myRow, tmpTables, level + 1)
        j += 1
      Next
    End Sub
    Private Function GetFieldList(ByVal groupList As ArrayList, ByVal level As Integer) As String
      Dim ret As String = ""
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
#End Region

#Region "XML"
    Private Function ToXML(ByVal doc As XmlDocument) As XmlElement
      Dim workSheet As XmlElement = doc.CreateElement("Worksheet")
      For Each row As TreeRow In Me.Treetable.Rows
        Dim el As XmlElement = doc.CreateElement("Row")
        For Each col As DataGridColumnStyle In Me.GridTableStyle.GridColumnStyles

          Dim childEl As XmlElement = doc.CreateElement(col.HeaderText.Replace("@", "UnitPrice"))
          Dim indent As String = ""
          If TypeOf col Is PlusMinusTreeTextColumn Then
            For i As Integer = 0 To row.Level
              indent &= "__"
            Next
          End If
          childEl.InnerText = indent & row(col.MappingName).ToString()
          el.AppendChild(childEl)
        Next
        workSheet.AppendChild(el)
      Next
      Return workSheet
    End Function
    Public Sub WriteToXMLFile(ByVal fileName As String)
      Dim doc As New XmlDocument
      doc.LoadXml("<?xml version=""1.0""?>" & ChrW(10) & "<?mso-application progid=""Excel.Sheet""?><Workbook/>")
      doc.DocumentElement.AppendChild(Me.ToXML(doc))
      Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
      myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), fileName, FileErrorPolicy.ProvideAlternative)
    End Sub
#End Region

  End Class
End Namespace
