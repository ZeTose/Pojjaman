Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface INewReport

    End Interface
    Public Class Report
        Inherits SimpleBusinessEntityBase
        Implements IPrintableEntity

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private m_dataSet As DataSet

        Private m_fixValueCollection As DocPrintingItemCollection
        Private m_filters() As Filter

        Protected m_treemanager As Treemanager
#End Region

#Region "Constructors"
        Public Sub New()
            m_reportColumns = New ReportColumnCollection(Me.ClassName)
        End Sub
        Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
            Me.New()
            m_filters = filters
            m_fixValueCollection = fixValueCollection
        End Sub
#End Region

#Region "Methods"
        Public Overridable Sub RefreshDataSet()
            Dim params() As SqlParameter
            If Not Filters Is Nothing AndAlso Filters.Length > 0 Then
                ReDim params(Filters.Length - 1)
                For i As Integer = 0 To Filters.Length - 1
                    params(i) = New SqlParameter("@" & Filters(i).Name, Filters(i).Value)
                Next
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, Me.GetListSprocName, params)
            ds.Tables(0).TableName = Me.ClassName
            If Filter.BlankFilterArray(Filters) Then
                If ds.Tables.Count > 1 Then
                    ds.Tables(1).Rows.Clear()
                End If
            End If
            Me.m_dataSet = ds
        End Sub
        Public Overridable Sub ListInGrid(ByVal tm As Treemanager)
            m_treemanager = tm
            ListInTable(tm.Treetable)
        End Sub
        Public Overridable Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)

        End Sub
        Private m_maxLevel As Integer = 0
        Private m_maxDataLevel As Integer = 0
        Public Sub ListInTable(ByVal tt As TreeTable)
            tt.Clear()
            m_maxLevel = Me.ReportColumns.GetMaxLevel
            m_maxDataLevel = Me.ReportColumns.GetMaxDataLevel
            If m_maxLevel > 0 Then
                For i As Integer = 0 To m_maxLevel
                    Dim header As TreeRow = tt.Childs.Add
                    For Each col As ReportColumn In Me.ReportColumns.GetCollectionForLevel(i)
                        header(col.Oridnal) = col.Alias
                    Next
                Next
            End If
            ListInNodes(tt, 0, New ReportColumnCollection)
        End Sub
        Public Sub ListInNodes(ByVal parent As ITreeParent, ByVal level As Integer, ByVal parentColumns As ReportColumnCollection)
            If level > m_maxDataLevel Then
                Return
            End If
            Dim dsh As New DataSetHelper
            'Dim columns As ReportColumnCollection = Me.ReportColumns.GetCollectionForLevel(level)
            Dim columns As ReportColumnCollection = Me.ReportColumns.GetDataCollectionForLevel(level)
            Dim groupingColsList As String = columns.GetGroupingColumnList
            Dim sortingCols As String = columns.GetSortingList
            Dim filterCols As String = ""
            If TypeOf parent Is TreeRow Then
                filterCols = parentColumns.GetFilterList(CType(parent, DataRow))
            End If
            Dim newRow As TreeRow
            Dim groupTable As DataTable
            groupTable = dsh.SelectDistinct("Group", Me.m_dataSet.Tables(0), groupingColsList, filterCols, sortingCols)
            Dim levelAggHT As New Hashtable
            For Each col As ReportColumn In columns
                If col.LevelAggregate <> Aggregate.None Then
                    levelAggHT(col) = 0
                End If
            Next
            Dim cnt As Integer = groupTable.Rows.Count
            For Each row As DataRow In groupTable.Rows
                newRow = parent.Childs.Add
                If level < m_maxLevel Then
                    newRow.State = RowExpandState.Expanded
                End If
                For Each col As ReportColumn In columns
                    Dim value As Object
                    If Not col.DigitConfig = Nothing Then
                        If Not row.IsNull(col.Name) AndAlso IsNumeric(row(col.Name)) Then
                            value = Configuration.FormatToString(CDec(row(col.Name)), col.DigitConfig)
                        ElseIf Not row.IsNull(col.Name) AndAlso col.DataType Is GetType(DateTime) Then
                            value = CDate(row(col.Name)).ToShortDateString
                        Else
                            value = row(col.Name)
                        End If
                    ElseIf col.DataType Is GetType(DateTime) Then
                        If Not row.IsNull(col.Name) Then
                            value = CDate(row(col.Name)).ToShortDateString
                        End If
                    Else
                        value = row(col.Name)
                    End If
                    newRow(col.Oridnal) = value

                    Select Case col.LevelAggregate
                        Case Aggregate.Sum
                            levelAggHT(col) = CDec(levelAggHT(col)) + CDec(value)
                        Case Aggregate.Avg
                            levelAggHT(col) = CDec(levelAggHT(col)) + (CDec(value) / cnt)
                        Case Aggregate.Min
                            levelAggHT(col) = Math.Min(CDec(levelAggHT(col)), CDec(value))
                        Case Aggregate.Max
                            levelAggHT(col) = Math.Max(CDec(levelAggHT(col)), CDec(value))
                        Case Aggregate.Count
                            levelAggHT(col) = CDec(levelAggHT(col)) + 1
                        Case Aggregate.Remain
                            ' ToDo : บวกเพิ่มสะสม
                            Dim index As Integer
                            Dim bfValue As Object = 0
                            For i As Integer = 0 To groupTable.Rows.Count - 1
                                If groupTable.Rows(i) Is row Then
                                    index = i
                                    Exit For
                                End If
                            Next
                            If index > 0 Then
                                Dim bfTR As TreeRow = CType(parent, TreeRow).Childs(index - 1)
                                bfValue = bfTR(col.Oridnal)
                            End If
                            Dim val As Decimal = CDec(value) + CDec(bfValue)
                            newRow(col.Oridnal) = val
                            levelAggHT(col) = ""
                        Case Aggregate.None
                            '*****
                    End Select
                Next 'col
                ListInNodes(newRow, level + 1, columns)
            Next 'row
            If levelAggHT.Count > 0 And groupTable.Rows.Count > 0 Then
                Dim newAggRow As TreeRow
                If TypeOf newRow.Parent Is TreeTable Then
                    newAggRow = parent.Childs.Add
                Else
                    newAggRow = CType(newRow.Parent, TreeRow)
                End If
                If level < m_maxLevel Then
                    newAggRow.State = RowExpandState.Expanded
                End If
                For Each col As ReportColumn In levelAggHT.Keys
                    Dim value As Object
                    If Not col.DigitConfig = Nothing Then
                        If Not levelAggHT(col) Is Nothing AndAlso IsNumeric(levelAggHT(col)) Then
                            If col.LevelAggregate = Aggregate.Count Then
                                value = Configuration.FormatToString(CDec(levelAggHT(col)), DigitConfig.Int)
                            Else
                                value = Configuration.FormatToString(CDec(levelAggHT(col)), col.DigitConfig)
                            End If
                        Else
                            value = levelAggHT(col)
                        End If
                    Else
                        value = levelAggHT(col)
                    End If
                    newAggRow(col.Oridnal) = value
                Next
            End If
        End Sub
        Public Overridable Function GetSimpleSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable(Me.ClassName)
            Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
            If maxLevel > 0 Then
                Dim maxOrdinal As Integer = Me.ReportColumns.GetMaxOrdinal
                For i As Integer = 0 To maxOrdinal
                    myDatatable.Columns.Add(New DataColumn("col" & i, GetType(String)))
                Next
            Else
                For Each col As ReportColumn In Me.ReportColumns
                    'myDatatable.Columns.Add(New DataColumn(col.Name, col.DataType))
                    myDatatable.Columns.Add(New DataColumn(col.Name, GetType(String)))
                Next
            End If

            Return myDatatable
        End Function
        Public Overridable Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = Me.ClassName
            Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
            If maxLevel > 0 Then
                Dim maxOrdinal As Integer = Me.ReportColumns.GetMaxOrdinal
                For i As Integer = 0 To maxOrdinal
                    Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = Me.ReportColumns.GetMaxWidth(i)
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    cs.DataAlignment = Me.ReportColumns.GetEffectiveAlignment(i)
                    cs.ReadOnly = True
                    cs.Format = "d"
                    AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                    dst.GridColumnStyles.Add(cs)
                Next
            Else
                Dim i As Integer = 0
                For Each col As ReportColumn In Me.ReportColumns
                    Dim cs As New TreeTextColumn(i, True, Color.Aqua)
                    cs.MappingName = col.Name
                    cs.HeaderText = StringParserService.Parse(col.Alias)
                    cs.Width = col.Width
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    cs.DataAlignment = col.Alignment
                    cs.ReadOnly = True
                    Select Case col.DataType.FullName.ToLower
                        Case "system.datetime"
                            cs.Format = "d"
                        Case Else
                            cs.Format = ""
                    End Select
                    AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                    dst.GridColumnStyles.Add(cs)
                    i += 1
                Next
            End If
            Return dst
        End Function
        Public Overridable Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
            e.HilightValue = False
            Dim maxLevel As Integer = Me.ReportColumns.GetMaxLevel
            If maxLevel > 0 AndAlso e.Row <= maxLevel Then
                e.HilightValue = True
            End If
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public ReadOnly Property Treemanager() As Treemanager            Get                Return m_treemanager            End Get        End Property        Public Property FixValueCollection() As DocPrintingItemCollection            Get                Return m_fixValueCollection            End Get            Set(ByVal Value As DocPrintingItemCollection)                m_fixValueCollection = Value            End Set        End Property        Public Property Filters() As Filter()            Get                Return m_filters            End Get            Set(ByVal Value As Filter())                m_filters = Value            End Set        End Property        Public Property DataSet() As DataSet            Get                Return m_dataSet            End Get            Set(ByVal Value As DataSet)                m_dataSet = Value            End Set        End Property        Public ReadOnly Property ReportColumns() As ReportColumnCollection            Get                Return m_reportColumns            End Get        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Report"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Report.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Report"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Report"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Report.ListLabel}"
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
#Region "IPrintableEntity"
        Public Overridable Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

        End Function
        Public Overridable Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath

        End Function
        Public Overridable Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries

        End Function
#End Region

    End Class
End Namespace

