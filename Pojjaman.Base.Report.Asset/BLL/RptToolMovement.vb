Option Explicit On
Option Strict On
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
Imports System.Collections.Generic
Imports Telerik.WinControls

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptToolMovement
    Inherits Report
    Implements IUseTelerikGridReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private columnGroupsView As ColumnGroupsViewDefinition
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Methods"
    Dim viewDef As ColumnGroupsViewDefinition
    Private m_grid As RadGridView
    Dim template As GridViewTemplate
    Private rowInfo As GridViewDataRowInfo
    Private Property radRadioHierarchyFromDataSet As Object

    Private Property Theme As Object

    Public Overrides Sub ListInNewGrid(ByVal grid As RadGridView)
      'm_grid = New RadGridView
      m_grid = grid
      m_grid.GridElement.BeginUpdate()
      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      m_grid.MasterGridViewTemplate.AllowAddNewRow = False
      m_grid.MasterGridViewTemplate.AllowDeleteRow = False
      m_grid.MasterGridViewTemplate.AllowCellContextMenu = False
      'm_grid.MasterGridViewTemplate.AllowColumnReorder = False
      template = New GridViewTemplate
      CreateHeader()
      CreateDocHeader()
      setdatasource()
      'PopulateData()
      'PopulateMasterData()
      'PopulateDocData()
      SetRelation()
      ExpandAllRows(m_grid, True)
      'SetColumnProperties()
      m_grid.GridElement.EndUpdate()
    End Sub
    Private Sub SetTheme()
      'Me.radRadioHierarchyFromDataSet.ThemeName = Theme
      'Me.radRadioButton2.ThemeName = Theme
      'Me.radRadioManuallyUnbound.ThemeName = Theme
      m_grid.ThemeName = CStr(Theme)
      'Me.radGroupHierarchyOptions.ThemeName = Theme

    End Sub

    Private Sub Configure(ByVal template As GridViewTemplate, ByVal enableFiltering As Boolean)
      template.EnableFiltering = enableFiltering

      For i As Integer = 0 To template.ChildGridViewTemplates.Count - 1
        Configure(template.ChildGridViewTemplates(i), enableFiltering)
      Next i
    End Sub

    Private Sub ResetGridView()
      m_grid.GridElement.RowHeight = 20
      m_grid.AutoGenerateHierarchy = False

      m_grid.CurrentRow = Nothing
      m_grid.Relations.Clear()
      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      m_grid.MasterGridViewTemplate.Columns.Clear()
      m_grid.DataSource = Nothing

      m_grid.MasterGridViewTemplate.AllowAddNewRow = False
      m_grid.MasterGridViewTemplate.AllowEditRow = False
      m_grid.MasterGridViewTemplate.AllowDeleteRow = False
      m_grid.MasterGridViewTemplate.ShowFilteringRow = False
    End Sub

    Private Sub CreateHeader()
      viewDef = New ColumnGroupsViewDefinition

      Dim headerTextList As New List(Of String)
      Dim FieldNameList As New List(Of String)
      headerTextList.Add("")
      FieldNameList.Add("tool_id")
      'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.EquipmentTypeCode}")) '"รหัส"
      'FieldNameList.Add("toolg_code")
      'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentMovement.Name}")) '"ชื่อ"
      'FieldNameList.Add("toolg_name")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolCode}")) '"รหัส"
      FieldNameList.Add("tool_code")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolName}")) '"ชื่อ"
      FieldNameList.Add("tool_name")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.OwnerCC}")) '"CCเจ้าของ"
      FieldNameList.Add("CC")

      m_grid.Columns.Clear()
      For i As Integer = 0 To 3
        Dim gridColumn As New GridViewTextBoxColumn("Col" & i.ToString)
        If i = 0 Then
          gridColumn.Width = 0
        Else
          gridColumn.Width = 100
        End If
        gridColumn.TextAlignment = ContentAlignment.MiddleLeft
        gridColumn.HeaderText = headerTextList(i)
        gridColumn.FieldName = FieldNameList(i)
        gridColumn.ReadOnly = True
        m_grid.Columns.Add(gridColumn)
      Next

    End Sub
    Private Sub CreateDocHeader()
      viewDef = New ColumnGroupsViewDefinition

      Dim headerTextList As New List(Of String)
      Dim FieldNameList As New List(Of String)
      headerTextList.Add("")
      FieldNameList.Add("tool_id")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTIncome.DocCode}")) '"รหัสเอกสาร"
      FieldNameList.Add("eqtstock_code")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.DocDate}")) '"วันที่"
      FieldNameList.Add("eqtstock_docdate")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTIncome.DocType}")) '"ประเภทเอกสาร"
      FieldNameList.Add("Doctype")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTIncome.ToCC}")) '"CCรับ"
      FieldNameList.Add("tocc")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolMovement.Qty}")) '"จำนวน"
      FieldNameList.Add("eqtstocki_qty")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Unit}")) '"หน่วย"
      FieldNameList.Add("unit_name")
      headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentMovement.RentalAmount}")) '"ค่าเช่า/ค่าใช้จ่าย"
      FieldNameList.Add("eqtstocki_Amount")

      template.Columns.Clear()
      For i As Integer = 0 To 7
        Dim gridColumn As New GridViewTextBoxColumn("Col" & i.ToString)
        If i = 0 Then
          gridColumn.Width = 0
        Else
          gridColumn.Width = 100
        End If
        If i = 5 OrElse i = 7 Then
          gridColumn.TextAlignment = ContentAlignment.MiddleRight
        Else
          gridColumn.TextAlignment = ContentAlignment.MiddleLeft
        End If
        gridColumn.HeaderText = headerTextList(i)
        gridColumn.FieldName = FieldNameList(i)
        gridColumn.ReadOnly = True
        template.Columns.Add(gridColumn)
      Next

    End Sub

    Private Sub setdatasource()
      Dim dt As DataTable = DataSet.Tables(0)
      Dim dtchilds As DataTable = DataSet.Tables(1)

      m_grid.DataSource = dt
      template.DataSource = dtchilds
      template.AllowDeleteRow = True
      template.AllowAddNewRow = False

      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

    End Sub

    Private Sub PopulateMasterData()
      Dim dt As DataTable = DataSet.Tables(0)
      For Each row As DataRow In dt.Rows
        Dim deh As New DataRowHelper(row)
        Dim currentGridRow As GridViewDataRowInfo = m_grid.Rows.AddNew()
        currentGridRow.Cells(0).Value = deh.GetValue(Of Integer)("")
        'currentGridRow.Cells(1).Value = deh.GetValue(Of String)("toolg_code")
        'currentGridRow.Cells(2).Value = deh.GetValue(Of String)("toolg_name")
        currentGridRow.Cells(1).Value = deh.GetValue(Of String)("tool_code")
        currentGridRow.Cells(2).Value = deh.GetValue(Of String)("tool_name")
        currentGridRow.Cells(3).Value = deh.GetValue(Of String)("CC")
      Next

    End Sub
    Private Sub PopulateDocData()
      Dim dt As DataTable = DataSet.Tables(1)

      For Each row As DataRow In dt.Rows
        Dim deh As New DataRowHelper(row)
        Dim currentGridRow As GridViewDataRowInfo = template.Rows.AddNew()
        currentGridRow.Cells(0).Value = deh.GetValue(Of String)("")
        currentGridRow.Cells(1).Value = deh.GetValue(Of String)("eqtstock_code")
        currentGridRow.Cells(2).Value = deh.GetValue(Of DateTime)("eqtstock_docdate").ToShortDateString
        currentGridRow.Cells(3).Value = deh.GetValue(Of String)("Doctype")
        currentGridRow.Cells(4).Value = deh.GetValue(Of String)("tocc")
        currentGridRow.Cells(5).Value = deh.GetValue(Of String)("eqtstocki_qty")
        currentGridRow.Cells(6).Value = deh.GetValue(Of String)("unit_name")
        currentGridRow.Cells(7).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("eqtstocki_Amount"), DigitConfig.Price)
      Next

      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

    End Sub
    Private Sub SetRelation()
      Dim relation As GridViewRelation = New GridViewRelation(m_grid.MasterGridViewTemplate)
      relation.ChildTemplate = template
      relation.RelationName = "Toolid"
      relation.ParentColumnNames.Add("tool_id")
      relation.ChildColumnNames.Add("tool_id")
      m_grid.Relations.Add(relation)
    End Sub
    Private Sub ExpandAllRows(ByVal grid As RadGridView, ByVal expand As Boolean)
      grid.GridElement.BeginUpdate()
      For Each row As GridViewRowInfo In grid.Rows
        row.IsExpanded = expand
      Next
      grid.GridElement.EndUpdate()
    End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptToolMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptToolMovement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptToolMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptToolMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptToolMovement.ListLabel}"
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
#End Region#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptToolMovement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptToolMovement"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim cRow As Integer = 0
      For rowIndex As Integer = 0 To m_grid.RowCount - 1
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid.Rows(rowIndex).Cells(1).Value
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid.Rows(rowIndex).Cells(2).Value
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid.Rows(rowIndex).Cells(3).Value
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col3"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(4).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col4"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(5).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col5"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(6).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        Dim childRowInfo As GridViewRowInfo = m_grid.Rows(rowIndex)
        Dim childRows As GridViewRowInfo() = childRowInfo.ViewTemplate.ChildGridViewTemplates(0).GetChildRows(childRowInfo)

        For i As Integer = 0 To childRows.Length - 1

          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = childRows(i).Cells(1).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = childRows(i).Cells(2).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = childRows(i).Cells(3).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = childRows(i).Cells(4).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = childRows(i).Cells(5).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = childRows(i).Cells(6).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = childRows(i).Cells(7).Value
          dpi.DataType = "System.String"
          dpi.Row = cRow + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          n += 1
          cRow += 1
        Next
      Next
      Return dpiColl
    End Function
#End Region
    Private Function radGroupHierarchyOptions() As Object
      Throw New NotImplementedException
    End Function



  End Class
End Namespace

