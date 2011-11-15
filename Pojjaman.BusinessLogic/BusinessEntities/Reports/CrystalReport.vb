Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Telerik.WinControls.UI

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CrystalReport
    Inherits SimpleBusinessEntityBase
    'Implements IPrintableEntity

#Region "Members"
    'Private m_reportColumns As ReportColumnCollection
    'Private m_dataSet As DataSet

    'Private m_fixValueCollection As DocPrintingItemCollection
    Private m_filters() As Filter

    'Protected m_treemanager As TreeManager

    Private m_reportName As String
    Private m_reportPath As String
    'Private m_report As CrystalDecisions.CrystalReports.Engine.ReportDocument
#End Region

#Region "Constructors"
    Public Sub New()
      'm_reportColumns = New ReportColumnCollection(Me.ClassName)
    End Sub
    Public Sub New(ByVal filters As Filter())
      Me.New()
      m_filters = filters
      'm_fixValueCollection = fixValueCollection
    End Sub
#End Region

#Region "Methods"
    Public Function GetSelectedFullReportName(ByVal combo As ComboBox) As String      Dim key As IdValuePair = CType(combo.SelectedItem, IdValuePair)      If Not key Is Nothing Then        Dim drh As New DataRowHelper(CType(hashAllReport(key.Id), DataRow))        'Return Me.ReportPath & key.Value & ".rpt"
        Return Me.ReportPath & drh.GetValue(Of String)("report_name") & ".rpt"
      End If
    End Function
    Public Sub PopupAvailableReport(ByVal combo As ComboBox)

      'Dim entityName As String = Me.GetTypeNameFromDocType(Me.EntityId)
      ''Dim def As New IdValuePair(0, Me.ReportName)
      'Dim def As New IdValuePair(0, entityName)
      'combo.Items.Add(def)

      Dim myReport As String = ""
      For Each key As IdValuePair In GetReportList(Me.EntityId)
        Dim drh As New DataRowHelper(CType(hashAllReport(key.Id), DataRow))
        myReport = Me.ReportPath & drh.GetValue(Of String)("report_name") & ".rpt"
        If IO.File.Exists(myReport) Then
          combo.Items.Add(key)
        End If
      Next

      If combo.Items.Count > 0 Then
        combo.SelectedIndex = 0
      End If
    End Sub
    Private Shared hashAllReport As Hashtable
    Private Shared dataAllReport As DataTable
    Private Function GetAllReport() As DataTable
      If hashAllReport Is Nothing Then
        hashAllReport = New Hashtable
        Dim cmd As String = "select * from dbo.reportentity where report_unvisible is null order by report_entity, report_ordinal"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, cmd, Nothing)
        dataAllReport = ds.Tables(0)
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          Dim id As Integer = drh.GetValue(Of Integer)("report_number")
          hashAllReport(id) = row
        Next
      End If

      Return dataAllReport
    End Function
    Private Function GetReportList(ByVal entityId As Integer) As ArrayList
      Dim arr As New ArrayList
      Trace.WriteLine(entityId)
      'Dim cmd As String = "select * from dbo.reportentity where report_unvisible is null order by report_ordinal"
      Dim dt As DataTable = GetAllReport() ' SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, cmd, Nothing)
      Dim rptAliasName As String = ""
      For Each row As DataRow In dt.Select("report_entity=" & entityId)
        Dim drh As New DataRowHelper(row)
        rptAliasName = drh.GetValue(Of String)("report_aliasname") & "  <" & drh.GetValue(Of String)("report_name") & ">"
        Dim key As New IdValuePair(drh.GetValue(Of Integer)("report_number"), rptAliasName)
        arr.Add(key)
      Next
      Return arr
    End Function
    Public Overridable Sub Load()

    End Sub
    'Public Overridable Sub RefreshDataSet()
    '  Dim params() As SqlParameter
    '  If Not Filters Is Nothing AndAlso Filters.Length > 0 Then
    '    ReDim params(Filters.Length - 1)
    '    For i As Integer = 0 To Filters.Length - 1
    '      params(i) = New SqlParameter("@" & Filters(i).Name, Filters(i).Value)
    '    Next
    '  End If
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, Me.GetListSprocName, params)
    '  ds.Tables(0).TableName = Me.ClassName
    '  If Filter.BlankFilterArray(Filters) Then
    '    If ds.Tables.Count > 1 Then
    '      ds.Tables(1).Rows.Clear()
    '    End If
    '  End If
    '  Me.m_dataSet = ds
    'End Sub
    'Public Overridable Sub ListInGrid(ByVal tm As TreeManager)
    '  m_treemanager = tm
    '  ListInTable(tm.Treetable)
    'End Sub
    'Public Overridable Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)

    'End Sub
    'Public Overridable Sub ListInNewGrid(ByVal grid As RadGridView)

    'End Sub
    'Private m_maxLevel As Integer = 0
    'Private m_maxDataLevel As Integer = 0
    'Public Sub ListInTable(ByVal tt As TreeTable)
    '  tt.Clear()
    '  m_maxLevel = Me.ReportColumns.GetMaxLevel
    '  m_maxDataLevel = Me.ReportColumns.GetMaxDataLevel
    '  If m_maxLevel > 0 Then
    '    For i As Integer = 0 To m_maxLevel
    '      Dim header As TreeRow = tt.Childs.Add
    '      For Each col As ReportColumn In Me.ReportColumns.GetCollectionForLevel(i)
    '        header(col.Oridnal) = col.Alias
    '      Next
    '    Next
    '  End If
    '  ListInNodes(tt, 0, New ReportColumnCollection)
    'End Sub
    'Public Sub ListInNodes(ByVal parent As ITreeParent, ByVal level As Integer, ByVal parentColumns As ReportColumnCollection)
    '  If level > m_maxDataLevel Then
    '    Return
    '  End If
    '  Dim dsh As New DataSetHelper
    '  'Dim columns As ReportColumnCollection = Me.ReportColumns.GetCollectionForLevel(level)
    '  Dim columns As ReportColumnCollection = Me.ReportColumns.GetDataCollectionForLevel(level)
    '  Dim groupingColsList As String = columns.GetGroupingColumnList
    '  Dim sortingCols As String = columns.GetSortingList
    '  Dim filterCols As String = ""
    '  If TypeOf parent Is TreeRow Then
    '    filterCols = parentColumns.GetFilterList(CType(parent, DataRow))
    '  End If
    '  Dim newRow As TreeRow
    '  Dim groupTable As DataTable
    '  groupTable = dsh.SelectDistinct("Group", Me.m_dataSet.Tables(0), groupingColsList, filterCols, sortingCols)
    '  Dim levelAggHT As New Hashtable
    '  For Each col As ReportColumn In columns
    '    If col.LevelAggregate <> Aggregate.None Then
    '      levelAggHT(col) = 0
    '    End If
    '  Next
    '  Dim cnt As Integer = groupTable.Rows.Count
    '  For Each row As DataRow In groupTable.Rows
    '    newRow = parent.Childs.Add
    '    If level < m_maxLevel Then
    '      newRow.State = RowExpandState.Expanded
    '    End If
    '    For Each col As ReportColumn In columns
    '      Dim value As Object
    '      If Not col.DigitConfig = Nothing Then
    '        If Not row.IsNull(col.Name) AndAlso IsNumeric(row(col.Name)) Then
    '          value = Configuration.FormatToString(CDec(row(col.Name)), col.DigitConfig)
    '        ElseIf Not row.IsNull(col.Name) AndAlso col.DataType Is GetType(DateTime) Then
    '          value = CDate(row(col.Name)).ToShortDateString
    '        Else
    '          value = row(col.Name)
    '        End If
    '      ElseIf col.DataType Is GetType(DateTime) Then
    '        If Not row.IsNull(col.Name) Then
    '          value = CDate(row(col.Name)).ToShortDateString
    '        End If
    '      Else
    '        value = row(col.Name)
    '      End If
    '      newRow(col.Oridnal) = value

    '      Select Case col.LevelAggregate
    '        Case Aggregate.Sum
    '          levelAggHT(col) = CDec(levelAggHT(col)) + CDec(value)
    '        Case Aggregate.Avg
    '          levelAggHT(col) = CDec(levelAggHT(col)) + (CDec(value) / cnt)
    '        Case Aggregate.Min
    '          levelAggHT(col) = Math.Min(CDec(levelAggHT(col)), CDec(value))
    '        Case Aggregate.Max
    '          levelAggHT(col) = Math.Max(CDec(levelAggHT(col)), CDec(value))
    '        Case Aggregate.Count
    '          levelAggHT(col) = CDec(levelAggHT(col)) + 1
    '        Case Aggregate.Remain
    '          ' ToDo : บวกเพิ่มสะสม
    '          Dim index As Integer
    '          Dim bfValue As Object = 0
    '          For i As Integer = 0 To groupTable.Rows.Count - 1
    '            If groupTable.Rows(i) Is row Then
    '              index = i
    '              Exit For
    '            End If
    '          Next
    '          If index > 0 Then
    '            Dim bfTR As TreeRow = CType(parent, TreeRow).Childs(index - 1)
    '            bfValue = bfTR(col.Oridnal)
    '          End If
    '          Dim val As Decimal = CDec(value) + CDec(bfValue)
    '          newRow(col.Oridnal) = val
    '          levelAggHT(col) = ""
    '        Case Aggregate.None
    '          '*****
    '      End Select
    '    Next 'col
    '    ListInNodes(newRow, level + 1, columns)
    '  Next 'row
    '  If levelAggHT.Count > 0 And groupTable.Rows.Count > 0 Then
    '    Dim newAggRow As TreeRow
    '    If TypeOf newRow.Parent Is TreeTable Then
    '      newAggRow = parent.Childs.Add
    '    Else
    '      newAggRow = CType(newRow.Parent, TreeRow)
    '    End If
    '    If level < m_maxLevel Then
    '      newAggRow.State = RowExpandState.Expanded
    '    End If
    '    For Each col As ReportColumn In levelAggHT.Keys
    '      Dim value As Object
    '      If Not col.DigitConfig = Nothing Then
    '        If Not levelAggHT(col) Is Nothing AndAlso IsNumeric(levelAggHT(col)) Then
    '          If col.LevelAggregate = Aggregate.Count Then
    '            value = Configuration.FormatToString(CDec(levelAggHT(col)), DigitConfig.Int)
    '          Else
    '            value = Configuration.FormatToString(CDec(levelAggHT(col)), col.DigitConfig)
    '          End If
    '        Else
    '          value = levelAggHT(col)
    '        End If
    '      Else
    '        value = levelAggHT(col)
    '      End If
    '      newAggRow(col.Oridnal) = value
    '    Next
    '  End If
    'End Sub
    'Public Overridable Function GetSimpleSchemaTable() As TreeTable
    '  Dim myDatatable As New TreeTable(Me.ClassName)
    '  Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
    '  If maxLevel > 0 Then
    '    Dim maxOrdinal As Integer = Me.ReportColumns.GetMaxOrdinal
    '    For i As Integer = 0 To maxOrdinal
    '      myDatatable.Columns.Add(New DataColumn("col" & i, GetType(String)))
    '    Next
    '  Else
    '    For Each col As ReportColumn In Me.ReportColumns
    '      'myDatatable.Columns.Add(New DataColumn(col.Name, col.DataType))
    '      myDatatable.Columns.Add(New DataColumn(col.Name, GetType(String)))
    '    Next
    '  End If

    '  Return myDatatable
    'End Function
    'Public Overridable Function CreateSimpleTableStyle() As DataGridTableStyle
    '  Dim dst As New DataGridTableStyle
    '  dst.MappingName = Me.ClassName
    '  Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
    '  If maxLevel > 0 Then
    '    Dim maxOrdinal As Integer = Me.ReportColumns.GetMaxOrdinal
    '    For i As Integer = 0 To maxOrdinal
    '      Dim cs As New TreeTextColumn(i, True, Color.Khaki)
    '      cs.MappingName = "col" & i
    '      cs.HeaderText = ""
    '      cs.Width = Me.ReportColumns.GetMaxWidth(i)
    '      cs.NullText = ""
    '      cs.Alignment = HorizontalAlignment.Left
    '      cs.DataAlignment = Me.ReportColumns.GetEffectiveAlignment(i)
    '      cs.ReadOnly = True
    '      cs.Format = "d"
    '      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
    '      dst.GridColumnStyles.Add(cs)
    '    Next
    '  Else
    '    Dim i As Integer = 0
    '    For Each col As ReportColumn In Me.ReportColumns
    '      Dim cs As New TreeTextColumn(i, True, Color.Aqua)
    '      cs.MappingName = col.Name
    '      cs.HeaderText = StringParserService.Parse(col.Alias)
    '      cs.Width = col.Width
    '      cs.NullText = ""
    '      cs.Alignment = HorizontalAlignment.Left
    '      cs.DataAlignment = col.Alignment
    '      cs.ReadOnly = True
    '      Select Case col.DataType.FullName.ToLower
    '        Case "system.datetime"
    '          cs.Format = "d"
    '        Case Else
    '          cs.Format = ""
    '      End Select
    '      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
    '      dst.GridColumnStyles.Add(cs)
    '      i += 1
    '    Next
    '  End If
    '  Return dst
    'End Function
    'Public Overridable Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
    '  e.HilightValue = False
    '  Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
    '  If maxLevel > 0 AndAlso e.Row <= maxLevel Then
    '    e.HilightValue = True
    '  End If
    'End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    'Public ReadOnly Property Treemanager() As TreeManager    '  Get    '    Return m_treemanager    '  End Get    'End Property    'Public Property FixValueCollection() As DocPrintingItemCollection    '  Get    '    Return m_fixValueCollection    '  End Get    '  Set(ByVal Value As DocPrintingItemCollection)    '    m_fixValueCollection = Value    '  End Set    'End Property    'Public Property Report As CrystalDecisions.CrystalReports.Engine.ReportDocument    '  Get
    '    Return m_report
    '  End Get
    '  Set(ByVal value As CrystalDecisions.CrystalReports.Engine.ReportDocument)
    '    m_report = value
    '  End Set
    'End Property    Public Property Filters() As Filter()      Get        Return m_filters      End Get      Set(ByVal Value As Filter())        m_filters = Value      End Set    End Property    Public ReadOnly Property DefaultReportName As String      Get
        Return "DefaultReport"
      End Get
    End Property    Public Overridable Property ReportName As String      Get
        If m_reportName Is Nothing OrElse m_reportName.Length = 0 Then
          Return Me.DefaultReportName
        Else
          Return m_reportName
        End If
      End Get
      Set(ByVal value As String)
        m_reportName = value
      End Set
    End Property    Public ReadOnly Property DefaultReportPath As String      Get
        Dim newDirectoty As String = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) &
                                     Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "data" &
                                     Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Crystal" & Path.DirectorySeparatorChar
        Return IO.Path.GetFullPath(newDirectoty)
      End Get
    End Property    Public Overridable Property ReportPath As String      Get
        If m_reportPath Is Nothing OrElse m_reportPath.Length = 0 Then
          Return Me.DefaultReportPath
        Else
          Return m_reportPath
        End If
      End Get
      Set(ByVal value As String)
        m_reportPath = value
      End Set
    End Property    Public ReadOnly Property FullReportName As String      Get
        Return Me.ReportPath & Me.ReportName & ".rpt"
      End Get
    End Property    'Public Property DataSet() As DataSet    '  Get    '    Return m_dataSet    '  End Get    '  Set(ByVal Value As DataSet)    '    m_dataSet = Value    '  End Set    'End Property    'Public ReadOnly Property ReportColumns() As ReportColumnCollection    '  Get    '    Return m_reportColumns    '  End Get    'End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CrystalReport"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CrystalReport.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CrystalReport"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CrystalReport"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CrystalReport.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region
    '#Region "IPrintableEntity"
    '    Public Overridable Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    '    End Function
    '    Public Overridable Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath

    '    End Function
    '    Public Overridable Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries

    '    End Function
    '#End Region

  End Class
End Namespace

