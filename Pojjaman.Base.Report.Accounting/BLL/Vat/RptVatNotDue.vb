Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptVatNotDue
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_showDetailInGrid As Integer
    Private m_hashData As Hashtable
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
      m_grid = grid
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
            m_showDetailInGrid = CInt(Me.Filters(6).Value)

      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
            lkg.TreeTable = tm.Treetable
            AdjustGrid()
      If m_showDetailInGrid = 0 Then
                lkg.Rows.HeaderCount = 2
                lkg.Rows.FrozenCount = 2
      Else
                lkg.Rows.HeaderCount = 3
                lkg.Rows.FrozenCount = 3
      End If

      lkg.Refresh()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim dr As DataRow = CType(m_hashData(e.RowIndex), DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("DocID")
      Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

      Trace.WriteLine(docId.ToString & ":" & docType.ToString)

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()

      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)



            If m_showDetailInGrid = 0 Then

                ' Level 0
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlCode}") '"เลขที่ใบสำคัญ"
                tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.EntityDescription}") '"ประเภทเอกสาร"
                tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierCode}") '"รหัสผู้ขาย"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierName}") '"รายชื่อผู้ขาย"

                'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxbase}") '"มูลค่าสินค้าและบริการ"
                'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxAmt}") '"จำนวนเงินภาษี"

                'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbase}") '"ฐานภาษียังไม่ถึงกำหนดยกมา"
                'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbAmt}") '"ภาษียังไม่ถึงกำหนดยกมา"

                'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatBase}") '"มูลค่าสินค้าและบริการดึงไปกรอกใบกำกับ"
                'tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatAmt}") '"จำนวนเงินภาษีดึงไปกรอกใบกำกับ"

                'tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockRemain}") '"ฐานภาษียังไม่ถึงกำหนดยกไป"
                'tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VAtRemain}") '"ภาษียังไม่ถึงกำหนดยกไป"

                tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlNote}") ' "หมายเหตุ"


                ' Level 1
                tr = Me.m_treemanager.Treetable.Childs.Add
                'tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                'tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlCode}") '"เลขที่ใบสำคัญ"
                'tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.EntityDescription}") '"ประเภทเอกสาร"
                'tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierCode}") '"รหัสผู้ขาย"
                'tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierName}") '"รายชื่อผู้ขาย"



                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbase}") '"ฐานภาษียังไม่ถึงกำหนดยกมา"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbAmt}") '"ภาษียังไม่ถึงกำหนดยกมา"

                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxbase}") '"มูลค่าสินค้าและบริการ"
                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxAmt}") '"จำนวนเงินภาษี"

                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatBase}") '"มูลค่าสินค้าและบริการดึงไปกรอกใบกำกับ"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatAmt}") '"จำนวนเงินภาษีดึงไปกรอกใบกำกับ"

                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockRemain}") '"ฐานภาษียังไม่ถึงกำหนดยกไป"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VAtRemain}") '"ภาษียังไม่ถึงกำหนดยกไป"

                'tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlNote}") ' "หมายเหตุ"
            Else
                ' Level 0
                Dim tr As TreeRow
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlCode}") '"เลขที่ใบสำคัญ"
                tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.EntityDescription}") '"ประเภทเอกสาร"
                tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierCode}") '"รหัสผู้ขาย"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierName}") '"รายชื่อผู้ขาย"

                'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxbase}") '"มูลค่าสินค้าและบริการ"
                'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxAmt}") '"จำนวนเงินภาษี"

                'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbase}") '"ฐานภาษียังไม่ถึงกำหนดยกมา"
                'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbAmt}") '"ภาษียังไม่ถึงกำหนดยกมา"

                'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatBase}") '"มูลค่าสินค้าและบริการดึงไปกรอกใบกำกับ"
                'tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatAmt}") '"จำนวนเงินภาษีดึงไปกรอกใบกำกับ"

                'tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockRemain}") '"ฐานภาษียังไม่ถึงกำหนดยกไป"
                'tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VAtRemain}") '"ภาษียังไม่ถึงกำหนดยกไป"

                tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlNote}") ' "หมายเหตุ"


                ' Level 1
                tr = Me.m_treemanager.Treetable.Childs.Add
                'tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                'tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlCode}") '"เลขที่ใบสำคัญ"
                'tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.EntityDescription}") '"ประเภทเอกสาร"
                'tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierCode}") '"รหัสผู้ขาย"
                'tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierName}") '"รายชื่อผู้ขาย"



                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbase}") '"ฐานภาษียังไม่ถึงกำหนดยกมา"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.bfdeferTaxbAmt}") '"ภาษียังไม่ถึงกำหนดยกมา"

                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxbase}") '"มูลค่าสินค้า/บริการ"
                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxAmt}") '"ภาษีมูลค่าเพิ่ม"

                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatBase}") '"มูลค่าสินค้าและบริการดึงไปกรอกใบกำกับ"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatAmt}") '"จำนวนเงินภาษีดึงไปกรอกใบกำกับ"

                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockRemain}") '"ฐานภาษียังไม่ถึงกำหนดยกไป"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VAtRemain}") '"ภาษียังไม่ถึงกำหนดยกไป"

                'tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.GlNote}") ' "หมายเหตุ"

                ' Level 2
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.RefDocCode}") '"เลขที่เอกสารอ้างอิงดึงไปทำกรอกใบกำกับ"
                tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.RefDocDate}") ' "วันที่เอกสารอ้างอิงดึงไปทำกรอกฯ"
                tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.EntityDescription}") '"ประเภทเอกสาร"
                tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierCode}") '"รหัสผู้ขาย"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.SupplierName}") '"รายชื่อผู้ขาย"
                'tr("col6") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxbase}") '"มูลค่าเอกสาร"
                ' tr("col7") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockTaxAmt}") '"ภาษีซื้อเอกสาร"
                tr("col10") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatBase}") '"มูลค่าซื้อถึงกำหนด"
                tr("col11") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVatAmt}") '"ภาษีซื้อ(ถึงกำหนด)"
                'tr("col10") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.StockRemain}") '"มูลค่าสินค้าและบริการ(คงเหลือ)"
                'tr("col11") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VAtRemain}") '"จำนวนเงินภาษีคงเหลือ"
            End If
        End Sub
        Private Sub AdjustGrid()

            Dim RangeStyle As GridRangeStyle = New GridRangeStyle

            'm_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(row1, col1, row2, col2)})



            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 1, 2, 1)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 2, 2, 2)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 3, 2, 3)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 4, 2, 4)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 5, 2, 5)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 6, 2, 6)})

            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 7, 1, 8)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 9, 1, 10)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 11, 1, 12)})
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 13, 1, 14)})

            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(1, 15, 2, 15)})


            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DeferTaxOpen}") '"ยอดยกมา"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DeferTax}") '"ยอดตั้งภาษีซื้อไม่ถึงกำหนด"
            m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DueVAT}") '"กลับรายการภาษีซื้อไม่ถึงกำหนด"
            m_grid(1, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DeferTaxRemain}") '"ภาษีซื้อไม่ถึงกำหนด(คงเหลือ)"

        End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)

      Dim trStockCode As TreeRow
      Dim trPaysDoc As TreeRow
      'Dim trbfDefer As TreeRow

      Dim currentStockCode As String = ""
      Dim currStockId As String = ""
      'Dim tmpDueVatBaseRemain As Decimal
      'Dim tmpDueVatAmtRemain As Decimal
      Dim tmpdueTaxBase As Decimal
      Dim tmpdueTaxAmt As Decimal
      Dim tmpDueVatBase As Decimal
      Dim tmpDueVatAmt As Decimal
      Dim tmpbfdeferTaxBase As Decimal
      Dim tmpbfdeferTaxAmt As Decimal

      Dim tmpStockTaxBase As Decimal = 0
      Dim tmpStockTaxAmt As Decimal = 0
      Dim sumStockTaxBase As Decimal = 0
      Dim sumStockTaxAmt As Decimal = 0
      Dim sumDeferTaxBase As Decimal = 0
      Dim sumDeferTaxAmt As Decimal = 0
      Dim sumDueVatBase As Decimal = 0
      Dim sumDueVatAmt As Decimal = 0
      Dim sumbfdeferTaxBase As Decimal = 0
      Dim sumbfdeferTaxAmt As Decimal = 0

      Dim rowIndex As Integer = 0
      m_hashData = New Hashtable

      For Each stockRow As DataRow In dt.Rows
        Dim dhstockrow As New DataRowHelper(stockRow)

        trStockCode = Me.Treemanager.Treetable.Childs.Add
                'trStockCode.Tag = "Font.Bold"

        trStockCode.Tag = stockRow

      
        trStockCode("col0") = dhstockrow.GetValue(Of String)("stock_code")
        trStockCode("col1") = dhstockrow.GetValue(Of Date)("stock_docdate").ToShortDateString
        trStockCode("col2") = dhstockrow.GetValue(Of String)("gl_code")
        trStockCode("col3") = dhstockrow.GetValue(Of String)("entity_description")
        trStockCode("col4") = dhstockrow.GetValue(Of String)("supplier_code")
                trStockCode("col5") = dhstockrow.GetValue(Of String)("supplier_name")

                trStockCode("col6") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("bfdeferTaxBase"), DigitConfig.Price)
                trStockCode("col7") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("bfdeferTaxAmt"), DigitConfig.Price)

                trStockCode("col8") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("deferTaxBase"), DigitConfig.Price)
                trStockCode("col9") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("deferTaxAmt"), DigitConfig.Price)

        trStockCode("col10") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxBase"), DigitConfig.Price)
        trStockCode("col11") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxAmt"), DigitConfig.Price)
        trStockCode("col12") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("baldeferTaxBase"), DigitConfig.Price)
        trStockCode("col13") = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("baldeferTaxAmt"), DigitConfig.Price)
        trStockCode("col14") = dhstockrow.GetValue(Of String)("gl_note")

                tmpStockTaxBase = dhstockrow.GetValue(Of Decimal)("deferTaxBase")
                tmpStockTaxAmt = dhstockrow.GetValue(Of Decimal)("deferTaxAmt")
        tmpbfdeferTaxBase = dhstockrow.GetValue(Of Decimal)("bfdeferTaxBase")
        tmpbfdeferTaxAmt = dhstockrow.GetValue(Of Decimal)("bfdeferTaxAmt")
        tmpdueTaxBase = dhstockrow.GetValue(Of Decimal)("duetaxBase")
        tmpdueTaxAmt = dhstockrow.GetValue(Of Decimal)("duetaxAmt")

        sumStockTaxBase += tmpStockTaxBase
        sumStockTaxAmt += tmpStockTaxAmt
        sumDeferTaxBase += tmpdueTaxBase
        sumDeferTaxAmt += tmpdueTaxAmt
        sumbfdeferTaxBase += tmpbfdeferTaxBase
        sumbfdeferTaxAmt += tmpbfdeferTaxAmt

        If m_showDetailInGrid <> 0 Then
          Dim dt1 As DataTable = Me.DataSet.Tables(1)
          trStockCode.State = RowExpandState.Expanded
          For Each paysRow As DataRow In dt1.Select("stock_id=" & stockRow("stock_id").ToString & " and stock_type=" & stockRow("stock_type").ToString)
            Dim deh As New DataRowHelper(paysRow)

            If Not trStockCode Is Nothing Then
              trPaysDoc = trStockCode.Childs.Add
              trPaysDoc.Tag = paysRow
              trPaysDoc("col0") = indent & deh.GetValue(Of String)("pays_code")
              trPaysDoc("col1") = indent & deh.GetValue(Of Date)("pays_docdate").ToShortDateString
              trPaysDoc("col3") = indent & deh.GetValue(Of String)("entity_description")
              trPaysDoc("col4") = deh.GetValue(Of String)("supplier_code")
              trPaysDoc("col5") = deh.GetValue(Of String)("supplier_name")
              trPaysDoc("col10") = indent & Configuration.FormatToString(deh.GetValue(Of Decimal)("dueVat_base"), DigitConfig.Price)
              trPaysDoc("col11") = indent & Configuration.FormatToString(deh.GetValue(Of Decimal)("dueVat_amt"), DigitConfig.Price)
              tmpDueVatBase = deh.GetValue(Of Decimal)("dueVat_base")
              tmpDueVatAmt = deh.GetValue(Of Decimal)("dueVat_amt")

              'ไม่ต้องมี remain ในบรรทัด duevat แล้ว
              'If CDec(stockRow("bfdeferTaxBase")) = 0 Then
              '  If currStockId <> stockRow("stock_id").ToString Then
              '    tmpDueVatBaseRemain = tmpdueTaxBase - tmpDueVatBase
              '    trPaysDoc("col10") = indent & Configuration.FormatToString(tmpDueVatBaseRemain, DigitConfig.Price)

              '    tmpDueVatAmtRemain = tmpdueTaxAmt - tmpDueVatAmt
              '    trPaysDoc("col11") = indent & Configuration.FormatToString(tmpDueVatAmtRemain, DigitConfig.Price)
              '  Else
              '    tmpDueVatBaseRemain = tmpDueVatBaseRemain - tmpDueVatBase
              '    trPaysDoc("col10") = indent & Configuration.FormatToString(tmpDueVatBaseRemain, DigitConfig.Price)

              '    tmpDueVatAmtRemain = tmpDueVatAmtRemain - tmpDueVatAmt
              '    trPaysDoc("col11") = indent & Configuration.FormatToString(tmpDueVatAmtRemain, DigitConfig.Price)
              '  End If
              'Else
              '  If currStockId <> stockRow("stock_id").ToString Then
              '    tmpDueVatBaseRemain = tmpbfdeferTaxBase - tmpDueVatBase
              '    trPaysDoc("col10") = indent & Configuration.FormatToString(tmpDueVatBaseRemain, DigitConfig.Price)

              '    tmpDueVatAmtRemain = tmpbfdeferTaxAmt - tmpDueVatAmt
              '    trPaysDoc("col11") = indent & Configuration.FormatToString(tmpDueVatAmtRemain, DigitConfig.Price)
              '  Else
              '    tmpDueVatBaseRemain = tmpDueVatBaseRemain - tmpDueVatBase
              '    trPaysDoc("col10") = indent & Configuration.FormatToString(tmpDueVatBaseRemain, DigitConfig.Price)

              '    tmpDueVatAmtRemain = tmpDueVatAmtRemain - tmpDueVatAmt
              '    trPaysDoc("col11") = indent & Configuration.FormatToString(tmpDueVatAmtRemain, DigitConfig.Price)
              '  End If
              'End If

              trPaysDoc("col14") = deh.GetValue(Of String)("gl_note")
              sumDueVatBase += tmpDueVatBase
              sumDueVatAmt += tmpDueVatAmt
              currStockId = stockRow("stock_id").ToString
            End If
          Next

        End If
      Next

      'trbfDefer = Me.Treemanager.Treetable.Childs.Add
      'trbfDefer.Tag = "Fornt.Bold"
      'trbfDefer("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Total}") '"รวม"
      'trbfDefer("col10") = Configuration.FormatToString(sumbfdeferTaxBase, DigitConfig.Price)
      'trbfDefer("col11") = Configuration.FormatToString(sumbfdeferTaxAmt, DigitConfig.Price)

      trStockCode = Me.m_treemanager.Treetable.Childs.Add
      trStockCode.Tag = "Font.Bold"
      trStockCode("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Total}") '"รวม"
            trStockCode("col6") = Configuration.FormatToString(sumbfdeferTaxBase, DigitConfig.Price)
            trStockCode("col7") = Configuration.FormatToString(sumbfdeferTaxAmt, DigitConfig.Price)
            trStockCode("col8") = Configuration.FormatToString(sumStockTaxBase, DigitConfig.Price)
            trStockCode("col9") = Configuration.FormatToString(sumStockTaxAmt, DigitConfig.Price)
      trStockCode("col10") = Configuration.FormatToString(sumDueVatBase, DigitConfig.Price)
      trStockCode("col11") = Configuration.FormatToString(sumDueVatAmt, DigitConfig.Price)
            trStockCode("col12") = Configuration.FormatToString((sumbfdeferTaxBase + sumStockTaxBase) - sumDueVatBase, DigitConfig.Price)
            trStockCode("col13") = Configuration.FormatToString((sumbfdeferTaxAmt + sumStockTaxAmt) - sumDueVatAmt, DigitConfig.Price)

      Dim lineNumber As Integer = 1
      For Each tr As TreeRow In Me.m_treemanager.Treetable.Rows
        If Not tr.Tag Is Nothing AndAlso TypeOf tr.Tag Is DataRow Then
          m_hashData(lineNumber) = CType(tr.Tag, DataRow)
        End If

        lineNumber += 1
      Next
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

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 14 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(80)
      widths.Add(70)
      widths.Add(150)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
      widths.Add(100)

      For i As Integer = 0 To iCol
        If i = 1 Then
          'If m_showDetailInGrid <> 0 Then
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
          'If Me.m_showDetailInGrid <> 0 Then
          Select Case i
            Case 0, 1, 2, 3, 4, 5, 14
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
              cs.Format = "s"
            Case Else
                            cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
              cs.Format = "d"
          End Select

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
        Return "RptVatNotDue"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptVatNotDue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptVatNotDue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.ListLabel}"
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
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next
      'Dim i As Integer = 0
      Dim indent As String = Space(3)

      Dim line As Decimal = 0

      'For Each itemrow As TreeRow In Me.Treemanager.Treetable.Childs
      For i As Decimal = 0 To Me.Treemanager.Treetable.Childs.Count - 2
        Dim itemrow As TreeRow = Me.Treemanager.Treetable.Childs.Item(i + 2)
        Dim dhstockrow As New DataRowHelper(CType(itemrow, DataRow))

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "linenumber"
        dpi.Value = line + 1
        dpi.DataType = "System.Sting"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'stock.DocCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Stock.DocCode"
        dpi.Value = dhstockrow.GetValue(Of String)("Col0")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Stock.DocDate"
        dpi.Value = dhstockrow.GetValue(Of String)("Col1")
        'dpi.Value = dhstockrow.GetValue(Of Date)("Col1").ToShortDateString
        dpi.DataType = "System.DateTime"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'GL.DocCode
        dpi = New DocPrintingItem
        dpi.Mapping = "GL.DocCode"
        dpi.Value = dhstockrow.GetValue(Of String)("Col2")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Type
        dpi = New DocPrintingItem
        dpi.Mapping = "DocType"
        dpi.Value = dhstockrow.GetValue(Of String)("col3")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'SupplierCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCode"
        dpi.Value = dhstockrow.GetValue(Of String)("col4")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'SupplierName
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = dhstockrow.GetValue(Of String)("col5")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'StockTaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "StockTaxBase"
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("col6"), DigitConfig.Price)
        dpi.Value = dhstockrow.GetValue(Of String)("col6")
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'StockTaxAmt
        dpi = New DocPrintingItem
        dpi.Mapping = "StockTaxAmt"
        dpi.Value = dhstockrow.GetValue(Of String)("col7")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("stock_taxAmt"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'StockTaxAmt
        dpi = New DocPrintingItem
        dpi.Mapping = "bfdeferTaxBase"
        dpi.Value = dhstockrow.GetValue(Of String)("col8")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("bfdeferTaxBase"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'bfdeferTaxAmt
        dpi = New DocPrintingItem
        dpi.Mapping = "bfdeferTaxAmt"
        dpi.Value = dhstockrow.GetValue(Of String)("col9")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("bfdeferTaxAmt"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'duetaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "duetaxBase"
        dpi.Value = dhstockrow.GetValue(Of String)("col10")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxBase"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'duetaxAmt
        dpi = New DocPrintingItem
        dpi.Mapping = "duetaxAmt"
        dpi.Value = dhstockrow.GetValue(Of String)("col11")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxAmt"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'baldeferTaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "baldeferTaxBase"
        dpi.Value = dhstockrow.GetValue(Of String)("col12")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("baldeferTaxBase"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'baldeferTaxAmt
        dpi = New DocPrintingItem
        dpi.Mapping = "baldeferTaxAmt"
        dpi.Value = dhstockrow.GetValue(Of String)("col13")
        'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("baldeferTaxAmt"), DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'GlNote
        dpi = New DocPrintingItem
        dpi.Mapping = "GlNote"
        dpi.Value = dhstockrow.GetValue(Of String)("col14")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        line += 1
        'add childs
        If itemrow IsNot Nothing AndAlso Not itemrow.IsLeafRow Then
          For Each paysrow As TreeRow In itemrow.Childs
            i += 1
            Dim prh As New DataRowHelper(paysrow)


            'stock.DocCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Stock.DocCode"
            dpi.Value = indent & prh.GetValue(Of String)("Col0")
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'stock.DocCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Stock.DocDate"
            dpi.Value = indent & prh.GetValue(Of String)("Col1")
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'stock.DocCode
            dpi = New DocPrintingItem
            dpi.Mapping = "DocType"
            dpi.Value = indent & prh.GetValue(Of String)("Col3")
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'SupplierCode
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierCode"
            dpi.Value = indent & prh.GetValue(Of String)("col4")
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'SupplierName
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierName"
            dpi.Value = indent & prh.GetValue(Of String)("col5")
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'duetaxBase
            dpi = New DocPrintingItem
            dpi.Mapping = "duetaxBase"
            dpi.Value = prh.GetValue(Of String)("col10")
            'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxBase"), DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'duetaxAmt
            dpi = New DocPrintingItem
            dpi.Mapping = "duetaxAmt"
            dpi.Value = prh.GetValue(Of String)("col11")
            'dpi.Value = Configuration.FormatToString(dhstockrow.GetValue(Of Decimal)("duetaxAmt"), DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

          Next
        End If
      Next


      'Dim SumTaxAmount As Decimal = 0
      'Dim SumBeforeTax As Decimal = 0
      'Dim SumAfterTax As Decimal = 0
      'For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
      '  'Item.LineNumber
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "linenumber"
      '  dpi.Value = i + 1
      '  dpi.DataType = "System.Sting"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.DocDate
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.DocDate"
      '  dpi.Value = itemRow("docdate")
      '  dpi.DataType = "System.DateTime"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.Invoice
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Invoice"
      '  dpi.Value = itemRow("invoice")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.DocCode
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.DocCode"
      '  dpi.Value = itemRow("docCode")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.VatRunNumber
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.vatrunnumber"
      '  dpi.Value = itemRow("vatrunnumber")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.RelatedDoc
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.RelatedDoc"
      '  dpi.Value = itemRow("RelatedDoc")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.SubmitalDate
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.SubmitalDate"
      '  dpi.Value = itemRow("SubmitalDate")
      '  dpi.DataType = "System.DateTime"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.Supplier
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Supplier"
      '  dpi.Value = itemRow("supplier")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.BeforeTax
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.BeforeTax"
      '  dpi.Value = itemRow("beforetax")
      '  dpi.DataType = "System.Decimal"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)
      '  If IsNumeric(itemRow("beforetax")) Then
      '    SumBeforeTax += Configuration.Format(CDec(itemRow("beforetax")), DigitConfig.Price)
      '  End If

      '  'Item.TaxAmount
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.TaxAmount"
      '  dpi.Value = itemRow("taxamt")
      '  dpi.DataType = "System.Decimal"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)
      '  If IsNumeric(itemRow("taxamt")) Then
      '    SumTaxAmount += Configuration.Format(CDec(itemRow("taxamt")), DigitConfig.Price)
      '  End If

      '  'Item.AfterTax
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.AfterTax"
      '  dpi.Value = itemRow("aftertax")
      '  dpi.DataType = "System.Decimal"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)
      '  If IsNumeric(itemRow("aftertax")) Then
      '    SumAfterTax += CDec(itemRow("aftertax"))
      '  End If

      '  'Item.Invoice
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Invoice"
      '  dpi.Value = itemRow("Invoice")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.GroupName
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.GroupName"
      '  dpi.Value = itemRow("GroupName")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.CostcenterName
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.CostcenterName"
      '  dpi.Value = itemRow("CostcenterName")
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  i += 1
      'Next

      ''SumText
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumText"
      'dpi.Value = "รวม"
      'dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpiColl.Add(dpi)

      ''SumCol5
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumCol5"
      'dpi.Value = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpiColl.Add(dpi)

      ''SumCol6
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumCol6"
      'dpi.Value = Configuration.FormatToString(SumTaxAmount, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpiColl.Add(dpi)

      ''SumBeforeTax
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumAfterTax"
      'dpi.Value = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

