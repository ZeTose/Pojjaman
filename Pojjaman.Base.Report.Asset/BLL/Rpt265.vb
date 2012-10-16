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
  Public Class Rpt265
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
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
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    'Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)

    '    m_grid = grid
    '    m_grid.BeginUpdate()
    '    m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
    '    m_grid.Model.Options.NumberedColHeaders = False
    '    m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
    '    CreateHeader()
    '    PopulateData()
    '    m_grid.EndUpdate()
    'End Sub
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid
      'RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      'AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      'If m_showDetailInGrid = 0 Then
      '  lkg.Rows.HeaderCount = 1
      '  lkg.Rows.FrozenCount = 1
      'Else
            lkg.HideRows(0) = False
            lkg.RowHeights(0) = 5

      lkg.Rows.HeaderCount = 2
      lkg.Rows.FrozenCount = 2
      'End If

      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      'm_showDetailInGrid = CInt(Me.Filters(7).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)
      Dim tr As TreeRow = Nothing

      tr = m_treemanager.Treetable.Childs.Add
      tr(0) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeID}") '"รหัสประเภท"
      tr(1) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeName}") '"ชื่อประเภทสินทรัพย์"
      'tr(2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CostCenter}") ' CC สังกัด

      tr(4) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.SumRent}") ' รวมค่าเช่า

      tr = m_treemanager.Treetable.Childs.Add
      tr(0) = indent & "Cost Center ที่ให้เบิก" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Project}") '"CC เจ้าของ"
      tr(1) = indent & "Cost Center ที่ขอเบิก" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CategoryWBS}") '"ใช้ในโครงการ"
      tr(2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateStrat}")
      tr(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateEnd}")  '"จากวันที่"
      tr(4) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Rent}") '"วันที่"
      tr(5) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQW}")  '"ค่าเช่า"
      tr(6) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQR}")   '"เบิกเอกสาร"

      'Return

      'm_grid.RowCount = 1
      'm_grid.ColCount = 7

      'm_grid.ColWidths(1) = 100
      'm_grid.ColWidths(2) = 300
      'm_grid.ColWidths(3) = 100
      'm_grid.ColWidths(4) = 100
      'm_grid.ColWidths(5) = 100
      'm_grid.ColWidths(6) = 100
      'm_grid.ColWidths(7) = 100


      'm_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      'm_grid.Rows.HeaderCount = 1
      'm_grid.Rows.FrozenCount = 1

      'm_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeID}") '"รหัสประเภท"
      'm_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeName}") '"ชื่อประเภทสินทรัพย์"
      'm_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CostCenter}") ' CC สังกัด

      'm_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.SumRent}") ' รวมค่าเช่า

      'Dim indent As String = Space(3)
      'm_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Project}") '"No."
      'm_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CategoryWBS}") '"ใช้ในโครงการ"
      'm_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateStrat}") '"หมวดงาน(WBS)"
      'm_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateEnd}")  '"จากวันที่"
      'm_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Rent}") '"วันที่"
      'm_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQW}")  '"ค่าเช่า"
      'm_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQR}")   '"เบิกเอกสาร"

      'm_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


      'm_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt0 As DataTable = Me.DataSet.Tables(0)

      Dim hsAsset As New Hashtable
      Dim trAsset As TreeRow = Nothing
      Dim trTrans As TreeRow = Nothing
      Dim indent As String = Space(3)
      Dim totalAmount As Decimal = 0
      Dim isShowOpeningBalance As Boolean = CBool(Me.Filters(10).Value)

      For Each row As DataRow In dt0.Rows
        Dim drh As New DataRowHelper(row)

        If Not hsAsset.ContainsKey(drh.GetValue(Of Integer)("asset_id")) Then
          trAsset = Me.Treemanager.Treetable.Childs.Add
          trAsset.State = RowExpandState.Expanded
          trAsset(0) = drh.GetValue(Of String)("asset_code")
          trAsset(1) = drh.GetValue(Of String)("asset_name")
          trAsset(4) = 0

          '--ถ้าให้แสดงยอดยกมาด้วย--========================================
          If isShowOpeningBalance Then
            Dim opbAmount As Decimal = 0
            For Each opbrow As DataRow In dt0.Select("asset_id=" & drh.GetValue(Of Integer)("asset_id"))
              Dim opbdrh As New DataRowHelper(opbrow)
              opbAmount += opbdrh.GetValue(Of Decimal)("OpeningBalance")
              totalAmount += drh.GetValue(Of Decimal)("OpeningBalance")
            Next
            trTrans = trAsset.Childs.Add
            trTrans(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.RptAcc}")
            trTrans(4) = Configuration.FormatToString(opbAmount, DigitConfig.Price)
          End If
          '--ถ้าให้แสดงยอดยกมาด้วย--========================================

          hsAsset(drh.GetValue(Of Integer)("asset_id")) = trAsset
        Else
          trAsset = CType(hsAsset(drh.GetValue(Of Integer)("asset_id")), TreeRow)
        End If

        If Not trAsset Is Nothing Then
          trTrans = trAsset.Childs.Add
          trTrans(0) = indent & drh.GetValue(Of String)("cc_code") & " : " & drh.GetValue(Of String)("cc_name")
          trTrans(1) = indent & drh.GetValue(Of String)("ccrequest_code") & " : " & drh.GetValue(Of String)("ccrequest_name")
          If Not row.IsNull("withdtawDate") Then
            trTrans(2) = drh.GetValue(Of Date)("withdtawDate").ToShortDateString
          End If
          If Not row.IsNull("returnDate") Then
            trTrans(3) = drh.GetValue(Of Date)("returnDate").ToShortDateString
          End If
          trTrans(4) = Configuration.FormatToString(drh.GetValue(Of Decimal)("Amount"), DigitConfig.Price)
          trTrans(5) = drh.GetValue(Of String)("assetwithdrawCode")
          trTrans(6) = drh.GetValue(Of String)("assetreturnCode")

          trAsset(4) = Configuration.FormatToString(CDec(trAsset(4)) + drh.GetValue(Of Decimal)("Amount"), DigitConfig.Price)
          totalAmount += drh.GetValue(Of Decimal)("Amount")
        End If

      Next

      Dim trSummary As TreeRow = Me.Treemanager.Treetable.Childs.Add
      trSummary.State = RowExpandState.Expanded
      trSummary(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Total}")
      trSummary(4) = Configuration.FormatToString(totalAmount, DigitConfig.Price)

      Return

      Dim currAssetTypeIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currentAssetTypeCode As String = ""
      Dim strAssetcode As String = ""
      Dim sumOpeningBalance As Decimal
      Dim sumAmount As Decimal

      For Each row As DataRow In dt0.Rows
        If (CStr(row("asset_code")) <> strAssetcode) Then
          If sumOpeningBalance <> 0 Then
            If Me.Filters(8).Value <> 0 Then
              m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
            End If
          Else
            If (strAssetcode <> "") Then
              If Me.Filters(8).Value <> 0 Then
                m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
              End If
            End If
          End If

          sumOpeningBalance = 0
          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          If Not row.IsNull("asset_code") Then
            m_grid(currAssetTypeIndex, 1).CellValue = row("asset_code")
          End If
          If Not row.IsNull("asset_name") Then
            m_grid(currAssetTypeIndex, 2).CellValue = row("asset_name")
          End If
          If Not row.IsNull("cc_code") Then
            m_grid(currAssetTypeIndex, 3).CellValue = row("cc_code")
          End If
          strAssetcode = CStr(row("asset_code"))

          If Me.Filters(8).Value <> 0 Then
            m_grid.RowCount += 1
            currAssetTypeIndex = m_grid.RowCount
            m_grid(currAssetTypeIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.RptAcc}")
            m_grid(currAssetTypeIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
          End If
        End If
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True

        If Not row.IsNull("project_code") Then
          m_grid(currItemIndex, 1).CellValue = "  " & row("project_code")
        End If

        If Not row.IsNull("wbs_name") Then
          m_grid(currItemIndex, 2).CellValue = "  " & row("wbs_name")
        End If

        If Not row.IsNull("withdtawDate") Then
          If IsDate(row("withdtawDate")) Then
            m_grid(currItemIndex, 3).CellValue = "  " & CDate(row("withdtawDate")).ToShortDateString
          End If
        End If
        If Not row.IsNull("returnDate") Then

          If IsDate(row("returnDate")) Then
            m_grid(currItemIndex, 4).CellValue = "  " & CDate(row("returnDate")).ToShortDateString
          End If
        End If

        If Not row.IsNull("assetwithdrawCode") Then
          m_grid(currItemIndex, 6).CellValue = "  " & row("assetwithdrawCode")
        End If

        If Not row.IsNull("assetreturnCode") Then
          m_grid(currItemIndex, 7).CellValue = "  " & row("assetreturnCode")
        End If

        'sumOpeningBalance += CDec(row("OpeningBalance"))
        sumAmount += CDec(row("stockiAmt"))
        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("stockiAmt")), DigitConfig.Price)

      Next


      'If sumOpeningBalance <> 0 Then
      '  If Me.Filters(8).Value <> 0 Then
      '    m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
      '  End If
      'Else
      '  If (strAssetcode <> "") Then
      '    If Me.Filters(8).Value <> 0 Then
      '      m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
      '    End If
      '  End If
      'End If


      m_grid.RowCount += 1
      currAssetTypeIndex = m_grid.RowCount
      m_grid(currAssetTypeIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Total}")
      m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumAmount, DigitConfig.Price)




    End Sub

    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
    End Function
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 6

      widths.Add(290)
      widths.Add(290)
      widths.Add(100)
      widths.Add(100)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)

      For i As Integer = 0 To iCol
        If i = 1 Then
          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "s"
          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.ReadOnly = True

          If i = 4 Then
            cs.Alignment = HorizontalAlignment.Right
            cs.DataAlignment = HorizontalAlignment.Right
            cs.Format = "d"
          Else
            cs.Alignment = HorizontalAlignment.Left
            cs.DataAlignment = HorizontalAlignment.Left
            cs.Format = "s"
          End If

          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If

      Next

      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt265"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt265"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt265"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt265.ListLabel}"
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
      Return "Rpt265"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt265"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

