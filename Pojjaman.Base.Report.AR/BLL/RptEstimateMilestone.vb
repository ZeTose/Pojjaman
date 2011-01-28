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
  Public Class RptEstimateMilestone
    Inherits Report
    Implements IUseTelerikGridReportStyle 'IUseTelerikGridReport

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
    Private m_DataType As DataType
    Private m_Period As DateInterval
    Private m_ValueType As ValueType
    Private m_StartDate As Date
    Private m_EndDate As Date
  

    Private m_NumWeek As Long
    Private m_NumMonth As Long
    Private m_NumQuarter As Long
    Private m_number As Long
    Private m_periodname As String

    Private Enum DataType
      MileStoneDocdate
      HandedDate
      BillDate
    End Enum

    Private Enum ValueType
      WOAdvRet
      Gross
    End Enum



    Public Overrides Sub ListInNewGrid(ByVal grid As RadGridView)
      'm_grid = New RadGridView

      m_grid = grid
      m_grid.GridElement.BeginUpdate()
      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      m_grid.MasterGridViewTemplate.AllowAddNewRow = False
      m_grid.MasterGridViewTemplate.AllowDeleteRow = False
      m_grid.MasterGridViewTemplate.AllowCellContextMenu = False


      m_DataType = CType(Me.Filters(2).Value, DataType)
      m_Period = CType(Me.Filters(3).Value, DateInterval)
      m_ValueType = CType(Me.Filters(4).Value, ValueType)
      m_StartDate = CDate(Me.Filters(0).Value)
      m_EndDate = CDate(Me.Filters(1).Value)

    

  

      m_NumWeek = DateDiff(DateInterval.WeekOfYear, m_StartDate, m_EndDate)
      m_NumMonth = DateDiff(DateInterval.Month, m_StartDate, m_EndDate)
      m_NumQuarter = DateDiff(DateInterval.Quarter, m_StartDate, m_EndDate)

      template = New GridViewTemplate
      CreateHeader()
      'AddHandler m_grid.GridElement.HScrollBar.ValueChanged ,
      Me.SetFrozenColumn(m_grid, 3)

      Setdatasource()
   
      ExpandAllRows(m_grid, True)
      m_grid.GridElement.EndUpdate()
    End Sub
    Private Sub SetFrozenColumn(ByVal grid As RadGridView, ByVal ColumnIndex As Integer)
      For i As Integer = 0 To ColumnIndex
        grid.Columns(i).IsPinned = True
      Next
    End Sub
    

    Private Sub SetTheme()
      m_grid.ThemeName = CStr(Theme)

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




      m_grid.Columns.Clear()
      viewDef = New ColumnGroupsViewDefinition



      Dim gridColumn As New GridViewTextBoxColumn("lineNumber")
      gridColumn.Width = 35
      gridColumn.TextAlignment = ContentAlignment.MiddleCenter
      gridColumn.HeaderText = "#"
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("cc_code")
      gridColumn.Width = 60
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountCode}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("cc_name")
      gridColumn.Width = 150
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.CostCenterName}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("cust_name")
      gridColumn.Width = 150
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.CustomerName}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      
      gridColumn = New GridViewTextBoxColumn("BalanceForward")
      gridColumn.Width = 100
      gridColumn.TextAlignment = ContentAlignment.MiddleRight
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.OpenningBalance}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      Select Case m_Period
        Case DateInterval.WeekOfYear
          m_number = m_NumWeek
          m_periodname = "week"
        Case DateInterval.Month
          m_number = m_NumMonth
          m_periodname = "month"
        Case DateInterval.Quarter
          m_number = m_NumQuarter
          m_periodname = "Quarter"
      End Select

      Dim colIndex As Integer = 1
      For i As Long = 0 To m_number Step 1
        Dim tdate As Date = DateAdd(m_Period, i, m_StartDate)
        Dim tweek As New Week(tdate)

        gridColumn = New GridViewTextBoxColumn(m_periodname & i.ToString)
        gridColumn.Width = 100
        gridColumn.TextAlignment = ContentAlignment.MiddleRight
        Select Case m_Period
          Case DateInterval.WeekOfYear
            gridColumn.HeaderText = tweek.StartWeekDate(Microsoft.VisualBasic.FirstDayOfWeek.Sunday).ToString("d/M") & "-" & tweek.EndWeekDate(Microsoft.VisualBasic.FirstDayOfWeek.Sunday).ToString("d/M") & "/" & tdate.ToString("yy")
          Case DateInterval.Month
            gridColumn.HeaderText = tdate.ToString("MMM yy")
          Case DateInterval.Quarter
            gridColumn.HeaderText = "Q" & tweek.Quarter.ToString & " " & tdate.ToString("yy")
        End Select
        gridColumn.ReadOnly = True
        m_grid.Columns.Add(gridColumn)

        colIndex += 1
      Next

      gridColumn = New GridViewTextBoxColumn("Total")
      gridColumn.Width = 100
      gridColumn.TextAlignment = ContentAlignment.MiddleRight
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Total}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

    End Sub
    Private Function SetDataSourceFiltered(ByVal dt As DataTable, ByVal columnSource As String, ByVal codestart As String, ByVal codeend As String) As DataTable
      Dim newdt As New DataTable
      Dim filterString As String = ""

      If codestart.Length = 0 AndAlso codeend.Length = 0 Then
        Return dt
      ElseIf codestart.Length > 0 AndAlso codeend.Length = 0 Then
        filterString = columnSource & " >= '" & codestart & "'"
      ElseIf codestart.Length = 0 AndAlso codeend.Length < 0 Then
        filterString = columnSource & " <= '" & codeend & "'"
      Else
        filterString = columnSource & " >= '" & codestart & "' and " & columnSource & " <='" & codeend & "'"
      End If

      For Each dcol As DataColumn In dt.Columns
        newdt.Columns.Add(New DataColumn(dcol.ColumnName))
      Next

      For Each drow As DataRow In dt.Select(filterString)
        Dim newDrow As DataRow = newdt.NewRow

        For Each dcol As DataColumn In dt.Columns
          newDrow(dcol.ColumnName) = drow(dcol.ColumnName)
        Next
        newdt.Rows.Add(newDrow)
      Next

      Return newdt
    End Function

    Private Sub Setdatasource()
      Dim dt As DataTable = SetDataSet(DataSet)


      m_grid.DataSource = dt
   

    End Sub

    Public Function SetDataSet(ByVal sourceDataSet As DataSet) As DataTable
      Dim dtcc As DataTable = sourceDataSet.Tables(0)
      Dim dtmi As DataTable = sourceDataSet.Tables(1)

      

      Dim newDt As New DataTable
      Dim lineNumber As Integer = 1

      newDt.Columns.Add(New DataColumn("LineNumber"))

     

      newDt.Columns.Add(New DataColumn("cc_code"))
      newDt.Columns.Add(New DataColumn("cc_name"))
      newDt.Columns.Add(New DataColumn("cust_name"))
      newDt.Columns.Add(New DataColumn("balanceforward"))
      newDt.Columns.Add(New DataColumn("total"))

     

      For i As Long = 0 To m_number Step 1
        newDt.Columns.Add(New DataColumn(m_periodname & i.ToString))
      Next

      Dim dif As Long

      Dim SumColumn As New Dictionary(Of String, Decimal)


      For Each ccrow As DataRow In dtcc.Rows
        Dim cch As New DataRowHelper(ccrow)

        Dim dr As DataRow = newDt.NewRow
        Dim ccid As Integer = cch.GetValue(Of Integer)("cc_id")
        dr("LineNumber") = lineNumber
        dr("cc_code") = cch.GetValue(Of String)("cc_code")
        dr("cc_name") = cch.GetValue(Of String)("cc_name")
        dr("cust_name") = cch.GetValue(Of String)("cust_name")


        
        Dim ccamt As New Dictionary(Of String, Decimal)
        Dim ccSumAmt As Decimal = 0
        Dim ccbf As Decimal = 0

        For Each mir As DataRow In dtmi.Select("milestone_cc =" & ccid.ToString)
          Dim mrh As New DataRowHelper(mir)
          Dim d As Date
          Dim value As Decimal
          Select Case m_DataType
            Case DataType.MileStoneDocdate
              d = mrh.GetValue(Of Date)("milestone_docdate")
            Case DataType.HandedDate
              d = mrh.GetValue(Of Date)("milestone_handeddate")
            Case DataType.BillDate
              d = mrh.GetValue(Of Date)("milestone_billIssueDate")
          End Select
          Select Case m_Period
            Case DateInterval.WeekOfYear
              dif = DateDiff(DateInterval.WeekOfYear, m_StartDate, d)
            Case DateInterval.Month
              dif = DateDiff(DateInterval.Month, m_StartDate, d)
            Case DateInterval.Quarter
              dif = DateDiff(DateInterval.Quarter, m_StartDate, d)
          End Select
          Select Case m_ValueType
            Case ValueType.WOAdvRet
              value = mrh.GetValue(Of Decimal)("milestone_aftertax")
            Case ValueType.Gross
              value = mrh.GetValue(Of Decimal)("milestone_aftertax") + mrh.GetValue(Of Decimal)("milestone_advrRetention")
          End Select

          If dif >= 0 AndAlso dif <= m_number Then
            If Not ccamt.ContainsKey(m_periodname & dif.ToString) Then
              ccamt.Add(m_periodname & dif.ToString, value)
              ccSumAmt = value + ccSumAmt
            End If
            ccamt.Item(m_periodname & dif.ToString) = value + ccamt.Item(m_periodname & dif.ToString)
            If ccamt.Item(m_periodname & dif.ToString) <> 0 Then
              dr(m_periodname & dif.ToString) = Configuration.FormatToString(ccamt.Item(m_periodname & dif.ToString), DigitConfig.Price)
            End If
          ElseIf dif < 0 Then
            ccbf = ccbf + value

          End If


        Next

        ccSumAmt = ccSumAmt + ccbf
        dr("BalanceForward") = Configuration.FormatToString(ccbf, DigitConfig.Price)
        dr("Total") = Configuration.FormatToString(ccSumAmt, DigitConfig.Price)

        If SumColumn.ContainsKey("BalanceForward") Then
          SumColumn.Item("BalanceForward") = ccbf + SumColumn.Item("BalanceForward")
        Else
          SumColumn.Add("BalanceForward", ccbf)
        End If

        If SumColumn.ContainsKey("Total") Then
          SumColumn.Item("Total") = ccSumAmt + SumColumn.Item("Total")
        Else
          SumColumn.Add("Total", ccSumAmt)
        End If

        For Each cckv As KeyValuePair(Of String, Decimal) In ccamt
          If SumColumn.ContainsKey(cckv.Key) Then
            SumColumn.Item(cckv.Key) = cckv.Value + SumColumn.Item(cckv.Key)
          Else
            SumColumn.Add(cckv.Key, cckv.Value)
          End If
        Next

        newDt.Rows.Add(dr)

        lineNumber += 1
      Next

      Dim Sumdr As DataRow = newDt.NewRow
      Sumdr("cust_name") = "รวม"
      For Each ckv As KeyValuePair(Of String, Decimal) In SumColumn
        Sumdr(ckv.Key) = Configuration.FormatToString(ckv.Value, DigitConfig.Price)
      Next

      newDt.Rows.Add(Sumdr)

      Return newDt
    End Function


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
        Return "RptEstimateMilestone"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptEstimateMilestone.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptEstimateMilestone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptEstimateMilestone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptEstimateMilestone.ListLabel}"
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
      Return "RptEstimateMilestone"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptEstimateMilestone"
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

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col2"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(3).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

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

        'Dim childRowInfo As GridViewRowInfo = m_grid.Rows(rowIndex)
        'Dim childRows As GridViewRowInfo() = childRowInfo.ViewTemplate.ChildGridViewTemplates(0).GetChildRows(childRowInfo)

        'For i As Integer = 0 To childRows.Length - 1

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col0"
        '  dpi.Value = childRows(i).Cells(1).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col1"
        '  dpi.Value = childRows(i).Cells(2).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col2"
        '  dpi.Value = childRows(i).Cells(3).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col3"
        '  dpi.Value = childRows(i).Cells(4).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col4"
        '  dpi.Value = childRows(i).Cells(5).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col5"
        '  dpi.Value = childRows(i).Cells(6).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        n += 1
        'cRow += 1
      Next
      ' Next
      Return dpiColl
    End Function
#End Region
    Private Function radGroupHierarchyOptions() As Object
      Throw New NotImplementedException
    End Function



  End Class
End Namespace

