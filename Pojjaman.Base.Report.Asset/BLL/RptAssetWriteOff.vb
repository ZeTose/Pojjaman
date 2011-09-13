Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptAssetWriteOff
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
      If Not TypeOf m_grid(e.RowIndex, 1).Tag Is DataRow Then
        Return
      End If

      Dim dr As DataRow = CType(m_grid(e.RowIndex, 1).Tag, DataRow)
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
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 17

      m_grid.ColWidths(1) = 90
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 200
      'Asset Amount
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      'WriteOff Amount
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      'Cost Amount
      m_grid.ColWidths(9) = 100

      'Sell
      m_grid.ColWidths(10) = 60
      m_grid.ColWidths(11) = 50
      m_grid.ColWidths(12) = 100
      m_grid.ColWidths(13) = 100
      'Profit/Loss
      m_grid.ColWidths(14) = 100
      'Vat
      m_grid.ColWidths(15) = 100
      m_grid.ColWidths(16) = 100
      m_grid.ColWidths(17) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetByType.SellDate}")              '"วันที่ write off"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.Doccode}")              '"เลขที่เอกสาร"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WriteOffView.lblPerson}")            '"ชื่อลูกค้า"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AssetAmountHeaderText}")              '"มูลค่าสินทรัพย์"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.DepreAmountHeaderText}")            '"ค่าเสื่อมสะสม"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.RemainingAmountHeaderText}")            '"มูลค่าคงเหลือ"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffAmountHeaderText}")            '"มูลค่า write off"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffDepreAmountHeaderText}")            '"ค่าเสื่อมสะสม write off"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.CostAmountHeaderText}")            '"ต้นทุนขาย"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.SellAmount}")            '"มูลค่าขาย"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.PLHeaderText}")            '"กำไร/ขาดทุน"
      m_grid(0, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.beforetax}")            '"before tax"
      m_grid(0, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.taxamount}")            '"tax amount"
      m_grid(0, 17).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.aftertax}")            '"after tax"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblAssetTypeStart}")  '"ประเภท."
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetCode}")  '"รหัสสินทรัพย์"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetName}")  '"ชื่อสินทรัพย์"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AssetAmountHeaderText}")   '"มูลค่าสินทรัพย์"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.DepreAmountHeaderText}")   '"ค่าเสื่อมสะสม"
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.RemainingAmountHeaderText}")   '"มูลค่าคงเหลือ"
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffAmountHeaderText}")   '"มูลค่า write off"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffDepreAmountHeaderText}")  '"ค่าเสื่อมสะสม write off"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.CostAmountHeaderText}")  '"ต้นทุนขาย"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitHeaderText}")  '"หน่วย"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.QtyHeaderText}")   '"qty"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitpriceHeaderText}")   '"ราคาขาย/หน่วย"*
      m_grid(1, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteoff.SellAmount}")    '"ต้นทุนขาย"
      m_grid(1, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.PLHeaderText}")   '"กำไร ขาดทุน"*
      'm_grid(1, 15).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AccDepreWriteOff}")   '"WriteOff สะสม"*
      'm_grid(1, 16).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AccDp}")   '"ค่าเสื่อมราคาสะสมคงเหลือ"*
      'm_grid(1, 17).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetValueRemain}")   '"มูลค่าคงเหลือ"*

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dtDoc As DataTable = Me.DataSet.Tables(0)
      Dim dtItem As DataTable = Me.DataSet.Tables(1)

      Dim indent As String = Space(3)





      Dim currDocIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim ChildIndex As Integer = -1
      Dim DocId As Decimal = -1

      'grandtotal
      Dim TotalAsAmt As Decimal
      Dim TotalAccDepre As Decimal
      Dim TotalAsRemain As Decimal
      Dim TotalAsWf As Decimal
      Dim TotalAccDepreWf As Decimal
      Dim TotalCostAmt As Decimal
      Dim TotalSellAmt As Decimal
      Dim TotalPL As Decimal
      Dim TotalBFTax As Decimal
      Dim TotalVat As Decimal
      Dim TotalAftax As Decimal

      'DocSum
      Dim DocAsAmt As Decimal
      Dim DocAccDepre As Decimal
      Dim DocAsRemain As Decimal
      Dim DocAsWf As Decimal
      Dim DocAccDepreWf As Decimal
      Dim DocCostAmt As Decimal
      Dim DocSellAmt As Decimal
      Dim DocPL As Decimal
      Dim DocBFTax As Decimal
      Dim DocVat As Decimal
      Dim DocAftax As Decimal

      'ParItem
      Dim piAsAmt As Decimal
      Dim piAccDepre As Decimal
      Dim piAsRemain As Decimal
      Dim piAsWf As Decimal
      Dim piAccDepreWf As Decimal
      Dim piCostAmt As Decimal
      Dim piSellAmt As Decimal
      Dim piPL As Decimal


      'Item
      Dim iAsAmt As Decimal
      Dim iAccDepre As Decimal
      Dim iAsRemain As Decimal
      Dim iAsWf As Decimal
      Dim iAccDepreWf As Decimal
      Dim iCostAmt As Decimal
      Dim iSellAmt As Decimal
      Dim iPL As Decimal

      For Each DocRow As DataRow In dtDoc.Rows
        Dim DocH As New DataRowHelper(DocRow)
        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(0, 204, 0)
        m_grid.RowStyles(currDocIndex).Font.Bold = True
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 1).CellValue = DocH.GetValue(Of Date)("eqtstock_docdate").ToShortDateString
        m_grid(currDocIndex, 2).CellValue = DocH.GetValue(Of String)("eqtstock_code")
        m_grid(currDocIndex, 3).CellValue = DocH.GetValue(Of String)("cust")


        m_grid(currDocIndex, 1).Tag = DocRow
        DocId = DocH.GetValue(Of Decimal)("DocId")

        For Each itemRow As DataRow In dtItem.Select("eqtstocki_eqtstock =" & DocId & " and eqtstocki_entityType = 28")
          Dim IH As New DataRowHelper(itemRow)
          Dim HasChilds As Boolean = IH.GetValue(Of Boolean)("haschilds")

          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount


          m_grid(currItemIndex, 1).CellValue = indent & IH.GetValue(Of String)("TyName")
          m_grid(currItemIndex, 2).CellValue = indent & IH.GetValue(Of String)("eqtcode")
          m_grid(currItemIndex, 3).CellValue = indent & IH.GetValue(Of String)("eqtName")

          DocAsAmt = 0
          DocAccDepre = 0
          DocAsRemain = 0
          DocAsWf = 0
          DocAccDepreWf = 0
          DocCostAmt = 0
          DocSellAmt = 0
          DocPL = 0

          Dim astID As Decimal = IH.GetValue(Of Decimal)("eqtstocki_entity")

          piAsAmt = IH.GetValue(Of Decimal)("eqtstocki_AssetAmount")
          piAccDepre = IH.GetValue(Of Decimal)("eqtstocki_accdepre")
          piAsRemain = IH.GetValue(Of Decimal)("eqtstocki_assetremainamount")
          piAsWf = IH.GetValue(Of Decimal)("eqtstocki_writeoffAmt")
          piAccDepreWf = IH.GetValue(Of Decimal)("eqtstocki_writeoffaccdepre")
          piCostAmt = IH.GetValue(Of Decimal)("eqtstocki_costamount")
          piSellAmt = IH.GetValue(Of Decimal)("eqtstocki_amount")
          piPL = IH.GetValue(Of Decimal)("eqtstocki_profitloss")

          If HasChilds Then
            'ย้อมสีให้ แม่
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(211, 255, 132)
            'm_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True

            m_grid.RowCount += 1
            ChildIndex = m_grid.RowCount


            piAsAmt = 0
            piAccDepre = 0
            piAsRemain = 0
            piAsWf = 0
            piAccDepreWf = 0
            piCostAmt = 0
            piSellAmt = 0
            piPL = 0

            For Each childRow As DataRow In dtItem.Select("eqtstocki_eqtstock =" & DocId.ToString & " and eqtstocki_entityType = 19 and eqtstocki_parent = " & astID.ToString)
              Dim ch As New DataRowHelper(childRow)
              m_grid(ChildIndex, 1).CellValue = indent & indent & ch.GetValue(Of String)("TyName")
              m_grid(ChildIndex, 2).CellValue = indent & indent & ch.GetValue(Of String)("eqtcode")
              m_grid(ChildIndex, 3).CellValue = indent & indent & ch.GetValue(Of String)("eqtName")

              iAsAmt = ch.GetValue(Of Decimal)("eqtstocki_AssetAmount")
              iAccDepre = ch.GetValue(Of Decimal)("eqtstocki_accdepre")
              iAsRemain = ch.GetValue(Of Decimal)("eqtstocki_assetremainamount")
              iAsWf = ch.GetValue(Of Decimal)("eqtstocki_writeoffAmt")
              iAccDepreWf = ch.GetValue(Of Decimal)("eqtstocki_writeoffaccdepre")
              iCostAmt = ch.GetValue(Of Decimal)("eqtstocki_costamount")
              iSellAmt = ch.GetValue(Of Decimal)("eqtstocki_amount")
              iPL = ch.GetValue(Of Decimal)("eqtstocki_profitloss")

              m_grid(ChildIndex, 4).CellValue = Configuration.FormatToString(iAsAmt, DigitConfig.Price)
              m_grid(ChildIndex, 5).CellValue = Configuration.FormatToString(iAccDepre, DigitConfig.Price)
              m_grid(ChildIndex, 6).CellValue = Configuration.FormatToString(iAsRemain, DigitConfig.Price)
              m_grid(ChildIndex, 7).CellValue = Configuration.FormatToString(iAsWf, DigitConfig.Price)
              m_grid(ChildIndex, 8).CellValue = Configuration.FormatToString(iAccDepreWf, DigitConfig.Price)
              m_grid(ChildIndex, 9).CellValue = Configuration.FormatToString(iCostAmt, DigitConfig.Price)
              m_grid(ChildIndex, 10).CellValue = ch.GetValue(Of String)("unit_name")
              m_grid(ChildIndex, 11).CellValue = Configuration.FormatToString(ch.GetValue(Of Decimal)("eqtstocki_qty"), DigitConfig.Qty)
              m_grid(ChildIndex, 12).CellValue = Configuration.FormatToString(ch.GetValue(Of Decimal)("eqtstocki_unitprice"), DigitConfig.Price)
              m_grid(ChildIndex, 13).CellValue = Configuration.FormatToString(iSellAmt, DigitConfig.Price)
              m_grid(ChildIndex, 14).CellValue = Configuration.FormatToString(iPL, DigitConfig.Price)

              piAsAmt += iAsAmt
              piAccDepre += iAccDepre
              piAsRemain += iAsRemain
              piAsWf += iAsWf
              piAccDepreWf += iAccDepreWf
              piCostAmt += iCostAmt
              piSellAmt += iSellAmt
              piPL += iPL

              ChildIndex += 1
            Next
          Else
            'ถึงไม่มีลูก แต่ก็ต้องเก็บ index ไว้
            ChildIndex = currItemIndex + 1
          End If

          DocAsAmt += piAsAmt
          DocAccDepre += piAccDepre
          DocAsRemain += piAsRemain
          DocAsWf += piAsWf
          DocAccDepreWf += piAccDepreWf
          DocCostAmt += piCostAmt
          DocSellAmt += piSellAmt
          DocPL += piPL

          m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(piAsAmt, DigitConfig.Price)
          m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(piAccDepre, DigitConfig.Price)
          m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(piAsRemain, DigitConfig.Price)
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(piAsWf, DigitConfig.Price)
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(piAccDepreWf, DigitConfig.Price)
          m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(piCostAmt, DigitConfig.Price)
          m_grid(currItemIndex, 13).CellValue = Configuration.FormatToString(piSellAmt, DigitConfig.Price)
          m_grid(currItemIndex, 14).CellValue = Configuration.FormatToString(piPL, DigitConfig.Price)

          currItemIndex = ChildIndex
        Next


        DocBFTax = DocH.GetValue(Of Decimal)("eqtstock_beforetax")
        DocVat = DocH.GetValue(Of Decimal)("eqtstock_taxamt")
        DocAftax = DocH.GetValue(Of Decimal)("eqtstock_aftertax")

        TotalAsAmt += DocAsAmt
        TotalAccDepre += DocAccDepre
        TotalAsRemain += DocAsRemain
        TotalAsWf += DocAsWf
        TotalAccDepreWf += DocAccDepreWf
        TotalCostAmt += DocCostAmt
        TotalSellAmt += DocSellAmt
        TotalPL += DocPL
        TotalBFTax += DocBFTax
        TotalVat += DocVat
        TotalAftax += DocAftax


        m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(DocAsAmt, DigitConfig.Price)
        m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(DocAccDepre, DigitConfig.Price)
        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(DocAsRemain, DigitConfig.Price)
        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(DocAsWf, DigitConfig.Price)
        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(DocAccDepreWf, DigitConfig.Price)
        m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(DocCostAmt, DigitConfig.Price)
        m_grid(currDocIndex, 13).CellValue = Configuration.FormatToString(DocSellAmt, DigitConfig.Price)
        m_grid(currDocIndex, 14).CellValue = Configuration.FormatToString(DocPL, DigitConfig.Price)
        m_grid(currDocIndex, 15).CellValue = Configuration.FormatToString(DocBFTax, DigitConfig.Price)
        m_grid(currDocIndex, 16).CellValue = Configuration.FormatToString(DocVat, DigitConfig.Price)
        m_grid(currDocIndex, 17).CellValue = Configuration.FormatToString(DocAftax, DigitConfig.Price)

        currDocIndex = currItemIndex + 1
      Next

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 3).CellValue = "รวมทั้งสิ้น"
      m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(TotalAsAmt, DigitConfig.Price)
      m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(TotalAccDepre, DigitConfig.Price)
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(TotalAsRemain, DigitConfig.Price)
      m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(TotalAsWf, DigitConfig.Price)
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(TotalAccDepreWf, DigitConfig.Price)
      m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(TotalCostAmt, DigitConfig.Price)
      m_grid(currDocIndex, 13).CellValue = Configuration.FormatToString(TotalSellAmt, DigitConfig.Price)
      m_grid(currDocIndex, 14).CellValue = Configuration.FormatToString(TotalPL, DigitConfig.Price)
      m_grid(currDocIndex, 15).CellValue = Configuration.FormatToString(TotalBFTax, DigitConfig.Price)
      m_grid(currDocIndex, 16).CellValue = Configuration.FormatToString(TotalVat, DigitConfig.Price)
      m_grid(currDocIndex, 17).CellValue = Configuration.FormatToString(TotalAftax, DigitConfig.Price)
      m_grid(currDocIndex, 1).Tag = "Font.Bold"





    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAssetWriteOff"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteOff.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAssetWriteOff"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAssetWriteOff"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAssetWriteOff.ListLabel}"
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
      Return "RptAssetDepreciationFromDoc"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAssetDepreciationFromDoc"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim fn As Font
      For rowIndex As Integer = 2 To m_grid.RowCount
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)


        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        For colIndex As Integer = 12 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex + 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

