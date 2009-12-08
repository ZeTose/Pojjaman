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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptSCMovement
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
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      Try
        m_grid = grid
        'm_grid.BeginUpdate()
        'm_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
        'm_grid.Model.Options.NumberedColHeaders = False
        'm_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
        'CreateHeader()
        'PopulateData()

        Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
        lkg.DefaultBehavior = False
        lkg.HilightWhenMinus = True
        lkg.Init()
        lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
        Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
        ListInGrid(tm)
        lkg.TreeTableStyle = CreateSimpleTableStyle()
        lkg.TreeTable = tm.Treetable

        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2

      Catch ex As Exception
        Throw ex
      Finally
        m_grid.EndUpdate()
      End Try
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      'm_showDetailInGrid = CInt(Me.Filters(9).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DocNumber}")       '"เลขที่เอกสาร"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.scBudget}")       '"SC Budget"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DR}")     '"ยอดหัก DR"  '""  
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retention}")     '"มัดจำ"      
      tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retentionn}")       '"Retention"

      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.docCode}")       '"เลขที่เอกสาร"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.supplierinfo}")     '"ผู้รับเหมา"    
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ccinfo}")           '"Cost Center "

      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.sc_docDate}")        '"วันที่เอกสาร"
      tr("col4") = Me.StringParserService.Parse("ตั้ง")              '"ตั้ง"
      tr("col5") = Me.StringParserService.Parse("เบิก")              '"เบิก"
      tr("col6") = Me.StringParserService.Parse("คงเหลือ")        '"คงเหลือ"
      tr("col7") = Me.StringParserService.Parse("ตั้ง")       '"หมายเหตุ"
      tr("col8") = Me.StringParserService.Parse("เบิก")     '"สถานะการเปิด SC"
      tr("col9") = Me.StringParserService.Parse("คงเหลือ")       '"อ้างอิง"
      tr("col10") = Me.StringParserService.Parse("ตั้ง")     '"ตั้ง"
      tr("col11") = Me.StringParserService.Parse("เบิก")       '"เบิก"
      tr("col12") = Me.StringParserService.Parse("คงเหลือ")              '"คงเหลือ"
      tr("col13") = Me.StringParserService.Parse("ตั้ง")     '"ตั้ง"
      tr("col14") = Me.StringParserService.Parse("เบิก")       '"เบิก"
      tr("col15") = Me.StringParserService.Parse("คงเหลือ")              '"คงเหลือ"    
      tr("col16") = Me.StringParserService.Parse("ยอดหนี้")     '"ยอดหนี้"
      tr("col17") = Me.StringParserService.Parse("ยอดหนึ้ Retention")       '"ยอดหนึ้"
      tr("col18") = Me.StringParserService.Parse("รวมทั้งสิ้น")              '"รวมทั้งสิ้น"  
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 0, 1), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 2, 2), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 2, 3), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 4, 2, 4), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 5, 1, 7), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 8, 1, 10), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 11, 1, 13), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 14, 0, 16), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 17, 2, 17), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 18, 2, 18), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 19, 2, 19)})
    End Sub

    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      'Dim dt1 As DataTable = Me.DataSet.Tables(1)
      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim trSubContranct As TreeRow
      Dim trDetail As TreeRow
      Dim trItem As TreeRow
      'Dim indent As String = Space(3)
      Dim scRemain As Decimal = 0
      Dim drRemain As Decimal = 0
      Dim advRemain As Decimal = 0
      Dim retRemain As Decimal = 0

      Dim summarrySCDebt As Decimal = 0
      Dim summarryRetDebt As Decimal = 0
      Dim summarryAdvDebt As Decimal = 0
      Dim currSubContract As String = ""
      Dim currSC As String = ""
      Dim isFirstAdvance As Boolean = False
      For Each subcontractRow As DataRow In dt.Rows
        If currSubContract <> subcontractRow("SubcontractorInfo").ToString Then
          currSubContract = subcontractRow("SubcontractorInfo").ToString

          trSubContranct = Me.Treemanager.Treetable.Childs.Add
          trSubContranct.Tag = "Font.Bold"
          If Not subcontractRow.IsNull("SubcontractorInfo") AndAlso Not subcontractRow.IsNull("Date") Then
            trSubContranct("col0") = subcontractRow("SubcontractorInfo").ToString
          End If

          trSubContranct.State = RowExpandState.Expanded
          summarrySCDebt = 0
          summarryRetDebt = 0
          summarryAdvDebt = 0
          isFirstAdvance = False

          If currSC <> subcontractRow("SubcontractorInfo").ToString & ":" & subcontractRow("sc_id").ToString Then
            currSC = subcontractRow("SubcontractorInfo").ToString & ":" & subcontractRow("sc_id").ToString
            scRemain = 0
            drRemain = 0
            advRemain = 0
            retRemain = 0
          End If

          For Each detailRow As DataRow In dt.Select("supplier_id=" & subcontractRow("Supplier_ID").ToString)
            If Not trSubContranct Is Nothing Then
              'ถ้ามี AdvancePay Balance มากกว่าศูนย์ก็ให้แสดงยอด ไว้รายการแรก
              If Not isFirstAdvance Then
                isFirstAdvance = True
                If Not detailRow.IsNull("ADVBalance") AndAlso CDec(detailRow("ADVBalance")) > 0 Then
                  trDetail = trSubContranct.Childs.Add
                  trDetail("col2") = "ยอดมัดจำจ่ายยกมา"
                  trDetail("col10") = Configuration.FormatToString(CDec(detailRow("ADVBalance")), DigitConfig.Price)
                  trDetail("col12") = Configuration.FormatToString((CDec(detailRow("ADVBalance")) - CDec(detailRow("advance_debit"))), DigitConfig.Price)
                  summarryAdvDebt += CDec(detailRow("ADVBalance"))
                  trDetail.State = RowExpandState.Expanded
                End If
              End If

              trDetail = trSubContranct.Childs.Add
              If Not detailRow.IsNull("Date") Then
                trDetail("col0") = CDate(subcontractRow("Date")).ToShortDateString
              End If
              If Not detailRow.IsNull("Code") Then
                trDetail("col1") = detailRow("Code").ToString
              End If
              If Not detailRow.IsNull("Type") Then
                trDetail("col2") = detailRow("Type").ToString
              End If
              If Not detailRow.IsNull("ccinfo") Then
                trDetail("col3") = detailRow("ccinfo").ToString
              End If
              If Not detailRow.IsNull("sc") Then
                trDetail("col4") = Configuration.FormatToString(CDec(detailRow("sc")), DigitConfig.Price)
                scRemain += CDec(detailRow("sc"))
              End If
              If Not detailRow.IsNull("sc_debit") Then
                trDetail("col5") = Configuration.FormatToString(CDec(detailRow("sc_debit")), DigitConfig.Price)
                scRemain -= CDec(detailRow("sc_debit"))
              End If
              If scRemain > 0 Then
                trDetail("col6") = Configuration.FormatToString(scRemain, DigitConfig.Price)
              End If
              If Not detailRow.IsNull("dr") Then
                trDetail("col7") = Configuration.FormatToString(CDec(detailRow("dr")), DigitConfig.Price)
                drRemain += CDec(detailRow("dr"))
              End If
              If Not detailRow.IsNull("dr_debit") Then
                trDetail("col8") = Configuration.FormatToString(CDec(detailRow("dr_debit")), DigitConfig.Price)
                drRemain -= CDec(detailRow("dr_debit"))
              End If
              If drRemain > 0 Then
                trDetail("col9") = Configuration.FormatToString(drRemain, DigitConfig.Price)
              End If
              If Not detailRow.IsNull("advance") Then
                trDetail("col10") = Configuration.FormatToString(CDec(detailRow("advance")), DigitConfig.Price)
                advRemain += CDec(detailRow("advance"))
              End If
              If Not detailRow.IsNull("advance_debit") Then
                trDetail("col11") = Configuration.FormatToString(CDec(detailRow("advance_debit")), DigitConfig.Price)
                advRemain -= CDec(detailRow("advance_debit"))
              End If
              If advRemain > 0 Then
                trDetail("col12") = Configuration.FormatToString(advRemain, DigitConfig.Price)
              End If
              If Not detailRow.IsNull("retention") Then
                trDetail("col13") = Configuration.FormatToString(CDec(detailRow("retention")), DigitConfig.Price)
                retRemain += CDec(detailRow("retention"))
              End If

              If Not detailRow.IsNull("retention_debit") Then
                trDetail("col14") = Configuration.FormatToString(CDec(detailRow("retention_debit")), DigitConfig.Price)
                retRemain -= CDec(detailRow("retention_debit"))
              End If


              If retRemain > 0 Then
                trDetail("col15") = Configuration.FormatToString(retRemain, DigitConfig.Price)
              End If

              summarrySCDebt = scRemain - drRemain - advRemain
              summarryRetDebt = retRemain
              summarryAdvDebt = summarrySCDebt + summarryRetDebt

              If summarrySCDebt > 0 Then
                trDetail("col16") = Configuration.FormatToString(summarrySCDebt, DigitConfig.Price)
              End If
              If summarryRetDebt > 0 Then
                trDetail("col17") = Configuration.FormatToString(summarryRetDebt, DigitConfig.Price)
              End If
              If summarryAdvDebt > 0 Then
                trDetail("col18") = Configuration.FormatToString(summarryAdvDebt, DigitConfig.Price)
              End If
            End If
            trDetail.State = RowExpandState.Expanded
          Next

        End If
      Next
      Return


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
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col17", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col18", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList

      widths.Add(150)
      widths.Add(120)
      widths.Add(120)
      widths.Add(160)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)


      For i As Integer = 0 To 18
        If i = 0 Then

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
          cs.Alignment = HorizontalAlignment.Left

          'Select Case i
          '    Case 0, 1
          '        cs.Alignment = HorizontalAlignment.Left
          '        cs.DataAlignment = HorizontalAlignment.Left
          '        cs.Format = "s"
          '    Case Else
          '        cs.Alignment = HorizontalAlignment.Right
          '        cs.DataAlignment = HorizontalAlignment.Right
          '        cs.Format = "d"
          'End Select


          cs.ReadOnly = True

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
        Return "RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ListLabel}"
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
      Return "RptSCMovement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptSCMovement"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim LineNumber As Integer = 0

      Dim n As Integer = 0
      Dim i As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        i += 1
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = i
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

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

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col12"
        dpi.Value = m_grid(rowIndex, 13).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col13"
        dpi.Value = m_grid(rowIndex, 14).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col14"
        dpi.Value = m_grid(rowIndex, 15).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col15"
        dpi.Value = m_grid(rowIndex, 16).CellValue
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
