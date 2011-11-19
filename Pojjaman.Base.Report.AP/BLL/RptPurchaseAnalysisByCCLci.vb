Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptPurchaseAnalysisByCCLci
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
      m_grid = grid
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("stock_id")
      Dim docType As Integer = 45

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 17
      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 150
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 120
      m_grid.ColWidths(12) = 150
      m_grid.ColWidths(13) = 150
      m_grid.ColWidths(14) = 150
      m_grid.ColWidths(15) = 150
      m_grid.ColWidths(16) = 150
      m_grid.ColWidths(17) = 150

      'm_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.CCCode}") '"รหัสโครงการ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.CCName}") '"ชื่อโครงการ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DocDate}")  '"วันที่"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ItemName}")  '"รายละเอียด"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ItemNote}")  '"หมายเหตุ"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Qty}")  '"จำนวน"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.UnitName}") '"หน่วย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.UnitPrice}")  '"ราคาต่อหน่วย"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Amt}")  '"ต้นทุน"

      m_grid(1, 8).Text = "ส่วนลด" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DiscAmt}")  '"ส่วนลด"

      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.TaxAmt}")  '"มูลค่าภาษี"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Amount}")  '"จำนวนงิน"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.AfterTax}")  '"จำนวนงิน รวมภาษี"

      m_grid(1, 12).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Supplier}")  '"ชื่อผู้ขาย"
      m_grid(1, 13).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ToCCPerson}")  '"พนักงานผู้รับผิดชอบ"
      m_grid(1, 14).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.PVCode}")  '"รหัสใบสำคัญจ่าย"
      m_grid(1, 15).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DocRef}")  '"เอกสารอ้างอิง"
      m_grid(1, 16).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.POCODE}")  '"เอกสารPO"
      m_grid(1, 17).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.PRCODE}")  '"เอกสารPR"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        Return
      End If
      Dim currentCCId As String = ""
      Dim currentItemId As String = ""
      Dim tmpAmount As Decimal = 0
      Dim tmpEachAmount As Decimal = 0
      Dim SumAmount As Decimal = 0
      Dim tmpTaxAmt As Decimal = 0
      Dim tmpEachTaxAmt As Decimal = 0
      Dim SumTaxAmt As Decimal = 0

      Dim tmpItemAmount2 As Decimal = 0
      Dim tmpItemAmount As Decimal = 0
      Dim tmpItemAfterTax2 As Decimal = 0
      Dim tmpItemAfterTax As Decimal = 0

      Dim SumItemAfterTax As Decimal = 0
      Dim SumItemAmount As Decimal = 0
      Dim SumCC As Decimal = 0
      Dim SumItem As Decimal = 0

      Dim tmpDisc As Decimal = 0
      Dim tmpEachDisc As Decimal = 0
      Dim SumDisc As Decimal = 0

      Dim currCCTIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)

      For Each row As DataRow In dt.Rows
        If row("CCId").ToString <> currentCCId Then
          If SumCC > 0 Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachDisc, DigitConfig.Price)
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
            m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpItemAmount, DigitConfig.Price)
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(tmpItemAfterTax, DigitConfig.Price)

            m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            tmpEachAmount = 0
            tmpEachTaxAmt = 0
            tmpItemAmount = 0
            tmpItemAfterTax = 0
            tmpEachDisc = 0
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Sum}") 'รวม
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpDisc, DigitConfig.Price)
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpTaxAmt, DigitConfig.Price)
            m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpItemAmount2, DigitConfig.Price)
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(tmpItemAfterTax2, DigitConfig.Price)

            m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            tmpAmount = 0
            tmpTaxAmt = 0
            tmpItemAmount2 = 0
            tmpItemAfterTax2 = 0
            tmpDisc = 0
          End If

          m_grid.RowCount += 1
          currCCTIndex = m_grid.RowCount
          m_grid.RowStyles(currCCTIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCCTIndex).Font.Bold = True
          m_grid.RowStyles(currCCTIndex).ReadOnly = True
          m_grid(currCCTIndex, 1).CellValue = row("CCCode")
          m_grid(currCCTIndex, 2).CellValue = row("CCName")
          currentCCId = row("CCId").ToString
          currentItemId = ""
          SumCC += 1
          SumItem = 0


          'If Not row.IsNull("ccid") Then
          Dim rowitem As DataRow
          For Each rowitem In dt.Select("ccid=" & row("ccid").ToString)
            If SumItem > 0 Then
              If currentItemId <> rowitem("ItemId").ToString & rowitem("ItemCode").ToString & rowitem("ItemName").ToString & rowitem("UnitName").ToString Then
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).Font.Bold = True
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
                m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
                m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachDisc, DigitConfig.Price)
                m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
                m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpItemAmount, DigitConfig.Price)
                m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(tmpItemAfterTax, DigitConfig.Price)

                m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

                tmpEachAmount = 0
                tmpEachTaxAmt = 0
                tmpItemAmount = 0
                tmpItemAfterTax = 0
                tmpEachDisc = 0
              End If
            End If

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid(currItemIndex, 0).Tag = rowitem
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            If IsDate(rowitem("DocDate")) Then
              m_grid(currItemIndex, 1).CellValue = indent & CDate(rowitem("DocDate")).ToShortDateString
            End If
            If Not rowitem.IsNull("ItemName") Then
              m_grid(currItemIndex, 2).CellValue = indent & rowitem("ItemName").ToString
            End If
            If Not rowitem.IsNull("ItemNote") Then
              m_grid(currItemIndex, 3).CellValue = indent & rowitem("ItemNote").ToString
              m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            End If
            If IsNumeric(rowitem("Qty")) Then
              m_grid(currItemIndex, 4).CellValue = indent & Configuration.FormatToString(CDec(rowitem("Qty")), DigitConfig.Qty)
            End If
            If Not rowitem.IsNull("UnitName") Then
              m_grid(currItemIndex, 5).CellValue = indent & rowitem("UnitName").ToString
            End If
            If IsNumeric(rowitem("UnitPrice")) Then
              m_grid(currItemIndex, 6).CellValue = indent & Configuration.FormatToString(CDec(rowitem("UnitPrice")), DigitConfig.Price)
              m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            End If
            If IsNumeric(rowitem("Amount")) Then
              m_grid(currItemIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(rowitem("Amount")), DigitConfig.Price)
              m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
              tmpEachAmount += CDec(rowitem("Amount"))
              tmpAmount += CDec(rowitem("Amount"))
              SumAmount += CDec(rowitem("Amount"))
            End If

            If IsNumeric(rowitem("discount")) Then
              m_grid(currItemIndex, 8).CellValue = indent & Configuration.FormatToString(CDec(rowitem("discount")), DigitConfig.Price)
              m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
              tmpEachDisc += CDec(rowitem("discount"))
              tmpDisc += CDec(rowitem("discount"))
              SumDisc += CDec(rowitem("discount"))
            End If

            If IsNumeric(rowitem("TaxAmt")) Then
              m_grid(currItemIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(rowitem("TaxAmt")), DigitConfig.Price)
              m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
              tmpEachTaxAmt += CDec(rowitem("TaxAmt"))
              tmpTaxAmt += CDec(rowitem("TaxAmt"))
              SumTaxAmt += CDec(rowitem("TaxAmt"))
            End If
            If IsNumeric(rowitem("AfterTax")) Then
              m_grid(currItemIndex, 10).CellValue = indent & Configuration.FormatToString(CDec(rowitem("AfterTax")), DigitConfig.Price)
              m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
              tmpItemAmount += CDec(rowitem("AfterTax"))
              tmpItemAmount2 += CDec(rowitem("AfterTax"))
              SumItemAmount += CDec(rowitem("AfterTax"))
            End If

            Dim m_afterTax As Decimal = 0
            If Not rowitem.IsNull("Amount") Then
              m_afterTax = CDec(rowitem("Amount"))
            End If
            If Not rowitem.IsNull("TaxAmt") Then
              m_afterTax += CDec(rowitem("TaxAmt"))
            End If
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(m_afterTax, DigitConfig.Price)
            m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            tmpItemAfterTax += m_afterTax
            tmpItemAfterTax2 += m_afterTax
            SumItemAfterTax += m_afterTax

            If Not rowitem.IsNull("SupplierInfo") Then
              m_grid(currItemIndex, 12).CellValue = indent & rowitem("SupplierInfo").ToString
            End If
            If Not rowitem.IsNull("EmployeeName") Then
              m_grid(currItemIndex, 13).CellValue = indent & rowitem("EmployeeName").ToString
            End If
            If Not rowitem.IsNull("PVCode") Then
              m_grid(currItemIndex, 14).CellValue = indent & rowitem("PVCode").ToString
            End If
            If Not rowitem.IsNull("stock_code") Then
              m_grid(currItemIndex, 15).CellValue = indent & rowitem("stock_code").ToString
            End If
            If Not rowitem.IsNull("po_code") Then
              m_grid(currItemIndex, 16).CellValue = indent & rowitem("po_code").ToString
            End If
            If Not rowitem.IsNull("pr_code") Then
              m_grid(currItemIndex, 17).CellValue = indent & rowitem("pr_code").ToString
            End If
            currentItemId = rowitem("ItemId").ToString & rowitem("ItemCode").ToString & rowitem("ItemName").ToString & rowitem("UnitName").ToString
            SumItem += 1
          Next

        End If
      Next
      If SumItem > 0 Then
        'If currentItemId <> rowitem("ItemId").ToString & rowitem("ItemCode").ToString & rowitem("ItemName").ToString & rowitem("UnitName").ToString Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).Font.Bold = True
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
        m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachDisc, DigitConfig.Price)
        m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
        m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpItemAmount, DigitConfig.Price)
        m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(tmpItemAfterTax, DigitConfig.Price)

        m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        tmpEachAmount = 0
        tmpEachTaxAmt = 0
        tmpItemAmount = 0
        tmpItemAfterTax = 0
        tmpEachDisc = 0
        'End If
      End If
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Sum}") 'รวม
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpDisc, DigitConfig.Price)
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpTaxAmt, DigitConfig.Price)
      m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpItemAmount2, DigitConfig.Price)
      m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(tmpItemAfterTax2, DigitConfig.Price)

      m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumAll}") 'รวมทั้งหมด
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumDisc, DigitConfig.Price)
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price)
      m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(SumItemAmount, DigitConfig.Price)
      m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(SumItemAfterTax, DigitConfig.Price)

      m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currItemIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ListLabel}"
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
      Return "RptPurchaseAnalysisByCCLci"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPurchaseAnalysisByCCLci"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        'If i > 1 Then
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

        dpi = New DocPrintingItem
        dpi.Mapping = "col16"
        dpi.Value = m_grid(rowIndex, 17).CellValue
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

