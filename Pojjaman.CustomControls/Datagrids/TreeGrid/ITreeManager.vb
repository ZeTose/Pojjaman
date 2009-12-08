Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Components
    Public Interface ITreeManager

#Region "Grouping Properties"
        Property GroupbyFieldList() As ArrayList        Property FieldNames() As String        Property DescField() As String        Property SortColumn() As String        Property Rollup() As Boolean        Property AggregateFieldInfo() As ArrayList
#End Region

#Region "Properties"
        Property Treetable() As TreeTable        Property Treegrid() As TreeGrid
        Property SortColumnList() As ArrayList        Property FieldList() As ArrayList
        Property GridTableStyle() As DataGridTableStyle
        Property SelectedRow() As TreeRow
#End Region

#Region "Methods"
        Sub SetTableStyle(ByVal style As DataGridTableStyle)
        Sub RemoveSelectedRow()
        Sub InsertBlankFriendOfSelectedRow()
        Sub InsertFriendOfSelectedRow()
        Sub InsertFriendOfSelectedRow(ByVal row As TreeRow)
        Sub AddChildOfSelectedRow()
        Sub AddChildOfSelectedRow(ByVal row As TreeRow)
        Sub PoplateGridWithTable()
        Sub SortBy(ByVal fieldNames As String, ByVal sortCols As String)
        Sub SortBy(ByVal fieldNames As String)
        Sub GroupTree(ByVal groupList As ArrayList, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean)
        Function UpdateGroup(ByVal groupList As ArrayList, ByVal fieldNames As String, ByVal descFieldName As String, ByVal sortCols As String, ByVal ROLLUP As Boolean) As TreeTable
        Function UpdateGroup(ByVal fieldNames As String) As TreeTable
        Function ChildTable() As TreeTable
#End Region

    End Interface
End Namespace
