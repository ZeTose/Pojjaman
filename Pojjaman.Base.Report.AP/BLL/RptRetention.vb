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
  Public Class RptRetention
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
    '  m_grid = grid
    '  m_grid.BeginUpdate()
    '  m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
    '  m_grid.Model.Options.NumberedColHeaders = False
    '  m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
    '  CreateHeader()
    '  PopulateData()
    '  m_grid.EndUpdate()
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
      lkg.Rows.Hidden(0) = True
      lkg.Rows.HeaderCount = 3
      lkg.Rows.FrozenCount = 3
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

      'Level 0
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr(0) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierCode}")  '"รหัสผู้รับเหมา"
      tr(1) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierName}") '"ชื่อผู้รับเหมา"
      'm_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}") '"มูลค่าตามเอกสาร"
      'm_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}") '"รวม Retention"
      'm_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}") '"Retentionยกมา"
      'm_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}") '"รวมมูลค่าชำระ"
      'm_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}") '"รวมมูลค่าค้างชำระ"

      'Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr(0) = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCCode}")  '"รหัสโครงการ"
      tr(1) = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCName}")  '"ชื่อโครงการ"
      'm_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}")   '"รวมมูลค่าตามเอกสาร"
      'm_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}")  '"รวม Retention"
      'm_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}")  '"Retentionยกมา"           
      'm_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}")  '"รวมมูลค่าชำระ"           
      'm_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}")  '"รวมมูลค่าค้างชำระ"

      'Level 2
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr(0) = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocDate}")  '"วันที่ซื้อสินค้า/บริการ"
      tr(1) = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocCode}")  '"เลขที่เอกสาร"
      tr(2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DueDate}")  '"วันที่ครบกำหนด"
      tr(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"
      tr(4) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GrossAmount}")   '"มูลค่าตามเอกสาร"
      tr(5) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GRRetention}")  '"มูลค่า Retention"
      tr(6) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}")  '"Retentionยกมา"
      tr(7) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysAmount}")  '"มูลค่าชำระ"
      tr(8) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysBalance}")  '"มูลค่าค้างชำระ"
      tr(9) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDate}")  '"วันที่จ่ายคืน Retention"
      tr(10) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDocCode}")  '"เลขที่เอกสารจ่าย"
      tr(11) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"

      'm_grid.RowCount = 2
      'm_grid.ColCount = 12

      'm_grid.ColWidths(1) = 150
      'm_grid.ColWidths(2) = 200
      'm_grid.ColWidths(3) = 100
      'm_grid.ColWidths(4) = 100
      'm_grid.ColWidths(5) = 120 'ยอดเอกสาร
      'm_grid.ColWidths(6) = 100 ' ยอดหัก retention
      'm_grid.ColWidths(7) = 100 ' retention ยกมา
      'm_grid.ColWidths(8) = 100 ' ยอดชำระ retention
      'm_grid.ColWidths(9) = 100 ' retentionคงเหลือ
      'm_grid.ColWidths(10) = 150
      'm_grid.ColWidths(11) = 150
      'm_grid.ColWidths(12) = 150

      'm_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      'm_grid.Rows.HeaderCount = 2
      'm_grid.Rows.FrozenCount = 2
      'm_grid.HorizontalThumbTrack = True
      'm_grid.VerticalThumbTrack = True

      'Dim indent As String = Space(3)
      'm_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierCode}")  '"รหัสผู้รับเหมา"
      'm_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierName}") '"ชื่อผู้รับเหมา"
      'm_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}") '"มูลค่าตามเอกสาร"
      'm_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}") '"รวม Retention"
      'm_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}") '"Retentionยกมา"
      'm_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}") '"รวมมูลค่าชำระ"
      'm_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}") '"รวมมูลค่าค้างชำระ"

      'm_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCCode}")  '"รหัสโครงการ"
      'm_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCName}")  '"ชื่อโครงการ"
      'm_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}")   '"รวมมูลค่าตามเอกสาร"
      'm_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}")  '"รวม Retention"
      'm_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}")  '"Retentionยกมา"           
      'm_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}")  '"รวมมูลค่าชำระ"           
      'm_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}")  '"รวมมูลค่าค้างชำระ"

      'm_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocDate}")  '"วันที่ซื้อสินค้า/บริการ"
      'm_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocCode}")  '"เลขที่เอกสาร"
      'm_grid(2, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DueDate}")  '"วันที่ครบกำหนด"
      'm_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"
      'm_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GrossAmount}")   '"มูลค่าตามเอกสาร"
      'm_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GRRetention}")  '"มูลค่า Retention"
      'm_grid(2, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.Opbretention}")  '"Retentionยกมา"
      'm_grid(2, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysAmount}")  '"มูลค่าชำระ"
      'm_grid(2, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysBalance}")  '"มูลค่าค้างชำระ"
      'm_grid(2, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDate}")  '"วันที่จ่ายคืน Retention"
      'm_grid(2, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDocCode}")  '"เลขที่เอกสารจ่าย"
      'm_grid(2, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"

      'm_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      'm_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      'm_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'm_grid(2, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dtOnRet As DataTable = Me.DataSet.Tables(0)  'Table ที่หัก Retention ไว้
      Dim dtRelRet As DataTable = Me.DataSet.Tables(1) 'Table ที่จ่าย Retention 

      Dim currSupplierCode As String = ""
      Dim currCostCenterCode As String = ""
      Dim currentItemCode As String = ""
      Dim currSupplierIndex As Integer = -1
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumGrossAmt_Supplier As Decimal = 0
      Dim sumGrossAmt_Costcenter As Decimal = 0
      Dim sumRetention_Supplier As Decimal = 0
      Dim sumRetention_Costcenter As Decimal = 0

      Dim sumOpbRetention_Supplier As Decimal = 0
      Dim sumOpbRetention_Costcenter As Decimal = 0

      Dim sumRetentionPays_Supplier As Decimal = 0
      Dim sumRetentionPays_Costcenter As Decimal = 0
      Dim sumPaysBalance_Supplier As Decimal = 0
      Dim sumPaysBalance_Costcenter As Decimal = 0

      Dim tmpRetention As Decimal
      Dim tmpOpbRetention As Decimal
      Dim tmpPaysBalance As Decimal

      Dim sumRetention As Decimal = 0
      Dim sumOpbRetention As Decimal = 0
      Dim sumRetentionPays As Decimal = 0
      Dim sumPaysBalance As Decimal = 0

      Dim trSupplier As TreeRow = Nothing
      Dim trCostCenter As TreeRow = Nothing
      Dim trDoc As TreeRow = Nothing

      For Each drowOnRet As DataRow In dtOnRet.Rows
        Try
          'New Supplier
          If Not currSupplierCode.Equals(drowOnRet("Supplier_Code").ToString) Then
            currSupplierCode = drowOnRet("Supplier_Code").ToString
            trSupplier = Me.Treemanager.Treetable.Childs.Add
            trSupplier.State = RowExpandState.Expanded
            trSupplier(0) = drowOnRet("Supplier_Code")
            trSupplier(1) = drowOnRet("Supplier_Name")

            'First New CostCenter
            currCostCenterCode = drowOnRet("CC_Code").ToString
            trCostCenter = trSupplier.Childs.Add
            trCostCenter.State = RowExpandState.Expanded
            trCostCenter(0) = indent & drowOnRet("CC_Code").ToString
            trCostCenter(1) = indent & drowOnRet("CC_Name").ToString

            sumGrossAmt_Supplier = 0
            sumGrossAmt_Costcenter = 0
            sumRetention_Supplier = 0
            sumRetention_Costcenter = 0
            sumOpbRetention_Supplier = 0
            sumOpbRetention_Costcenter = 0
            sumRetentionPays_Supplier = 0
            sumRetentionPays_Costcenter = 0
            sumPaysBalance_Supplier = 0
            sumPaysBalance_Costcenter = 0
          Else

            If Not currCostCenterCode.Equals(drowOnRet("CC_Code").ToString) Then
              currCostCenterCode = drowOnRet("CC_Code").ToString

              'New CostCenter
              trCostCenter = trSupplier.Childs.Add
              trCostCenter.State = RowExpandState.Expanded
              trCostCenter(0) = indent & drowOnRet("CC_Code").ToString
              trCostCenter(1) = indent & drowOnRet("CC_Name").ToString

              sumGrossAmt_Costcenter = 0
              sumRetention_Costcenter = 0
              sumOpbRetention_Costcenter = 0
              sumRetentionPays_Costcenter = 0
              sumPaysBalance_Costcenter = 0
            End If
          End If

          'PUR Items
          trDoc = trCostCenter.Childs.Add
          'trDoc.State = RowExpandState.Expanded
          If Not drowOnRet.IsNull("Stock_DocDate") Then
            trDoc(0) = indent & indent & CDate(drowOnRet("Stock_DocDate")).ToShortDateString
          End If
          If Not drowOnRet.IsNull("Retention_Code") Then
            trDoc(1) = indent & indent & drowOnRet("Retention_Code").ToString
          End If
          If Not drowOnRet.IsNull("DueDate") Then
            trDoc(2) = indent & indent & CDate(drowOnRet("DueDate")).ToShortDateString
          End If
          If Not drowOnRet.IsNull("Stock_pvrv") Then
            trDoc(3) = indent & indent & drowOnRet("Stock_pvrv").ToString
          End If
          If IsNumeric(drowOnRet("Stock_Aftertax")) Then
            trDoc(4) = Configuration.FormatToString(CDec(drowOnRet("Stock_Aftertax")), DigitConfig.Price)
            sumGrossAmt_Supplier += CDec(drowOnRet("Stock_Aftertax"))
            sumGrossAmt_Costcenter += CDec(drowOnRet("Stock_Aftertax"))
          End If
          If IsNumeric(drowOnRet("Stock_Retention")) Then
            tmpRetention = CDec(drowOnRet("Stock_Retention"))
            sumRetention_Supplier += tmpRetention
            sumRetention_Costcenter += tmpRetention
            sumRetention += tmpRetention
          End If
          If tmpRetention <> 0 Then
            trDoc(5) = Configuration.FormatToString(tmpRetention, DigitConfig.Price)
          End If
          If IsNumeric(drowOnRet("opbRet")) Then
            tmpOpbRetention = CDec(drowOnRet("opbRet"))
            sumOpbRetention_Supplier += tmpOpbRetention
            sumOpbRetention_Costcenter += tmpOpbRetention
            sumOpbRetention += tmpOpbRetention
          End If
          If tmpOpbRetention <> 0 Then
            trDoc(5) = Configuration.FormatToString(tmpOpbRetention, DigitConfig.Price)
          End If

          Dim tmpSumPaysItem As Decimal = 0
          Dim tmpPaysDate As String = ""
          Dim tmpPaysCode As String = ""
          Dim tmpPaymentCode As String = ""
          For Each drowRelRet As DataRow In dtRelRet.Select("Supplier_Code='" & drowOnRet("Supplier_Code").ToString & _
                                                  "' And Stock_id='" & drowOnRet("Stock_id").ToString & "'")
            If IsNumeric(drowRelRet("Pays_Gross")) Then
              tmpSumPaysItem += CDec(drowRelRet("Pays_Gross"))
            End If
            If Not drowRelRet.IsNull("Pays_DocDate") Then
              tmpPaysDate &= "," & CDate(drowRelRet("Pays_DocDate")).ToShortDateString
            End If
            If Not drowRelRet.IsNull("Pays_Code") Then
              tmpPaysCode &= "," & drowRelRet("Pays_Code").ToString
            End If
            If Not drowRelRet.IsNull("Payment_Code") Then
              tmpPaymentCode &= "," & drowRelRet("Payment_Code").ToString
            End If
          Next

          If tmpSumPaysItem > 0 Then
            trDoc(7) = Configuration.FormatToString(tmpSumPaysItem, DigitConfig.Price)
            sumRetentionPays_Supplier += tmpSumPaysItem
            sumRetentionPays_Costcenter += tmpSumPaysItem
            sumRetentionPays += tmpSumPaysItem
          End If

          If tmpPaysDate.Length > 1 Then
            trDoc(9) = tmpPaysDate.Substring(1)
          End If
          If tmpPaysCode.Length > 1 Then
            trDoc(10) = tmpPaysCode.Substring(1)
          End If
          If tmpPaymentCode.Length > 1 Then
            trDoc(11) = tmpPaymentCode.Substring(1)
          End If

          tmpPaysBalance = tmpOpbRetention - tmpSumPaysItem
          If tmpPaysBalance <> 0 Then
            trDoc(8) = Configuration.FormatToString(tmpPaysBalance, DigitConfig.Price)
            sumPaysBalance_Supplier += tmpPaysBalance
            sumPaysBalance_Costcenter += tmpPaysBalance
            sumPaysBalance += tmpPaysBalance
          End If

          If sumGrossAmt_Supplier <> 0 Then
            trSupplier(4) = Configuration.FormatToString(sumGrossAmt_Supplier, DigitConfig.Price)
          End If
          If sumGrossAmt_Costcenter <> 0 Then
            trCostCenter(4) = Configuration.FormatToString(sumGrossAmt_Costcenter, DigitConfig.Price)
          End If

          If sumRetention_Supplier <> 0 Then
            trSupplier(5) = Configuration.FormatToString(sumRetention_Supplier, DigitConfig.Price)
          End If
          If sumRetention_Costcenter <> 0 Then
            trCostCenter(5) = Configuration.FormatToString(sumRetention_Costcenter, DigitConfig.Price)
          End If

          If sumOpbRetention_Supplier <> 0 Then
            trSupplier(6) = Configuration.FormatToString(sumOpbRetention_Supplier, DigitConfig.Price)
          End If
          If sumOpbRetention_Costcenter <> 0 Then
            trCostCenter(6) = Configuration.FormatToString(sumOpbRetention_Costcenter, DigitConfig.Price)
          End If

          If sumRetentionPays_Supplier <> 0 Then
            trSupplier(7) = Configuration.FormatToString(sumRetentionPays_Supplier, DigitConfig.Price)
          End If
          If sumRetentionPays_Costcenter <> 0 Then
            trCostCenter(7) = Configuration.FormatToString(sumRetentionPays_Costcenter, DigitConfig.Price)
          End If

          If sumPaysBalance_Supplier <> 0 Then
            trSupplier(8) = Configuration.FormatToString(sumPaysBalance_Supplier, DigitConfig.Price)
          End If
          If sumPaysBalance_Costcenter <> 0 Then
            trCostCenter(8) = Configuration.FormatToString(sumPaysBalance_Costcenter, DigitConfig.Price)
          End If
        Catch ex As Exception
          MessageBox.Show(ex.ToString & vbCrLf & ex.StackTrace)
        End Try
      Next
      'sumPaysBalance
      trSupplier = Me.Treemanager.Treetable.Childs.Add
      trSupplier.State = RowExpandState.Expanded
      trSupplier(3) = "รวม"
      trSupplier(5) = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      trSupplier(6) = Configuration.FormatToString(sumOpbRetention, DigitConfig.Price)
      trSupplier(7) = Configuration.FormatToString(sumRetentionPays, DigitConfig.Price)
      trSupplier(8) = Configuration.FormatToString(sumPaysBalance, DigitConfig.Price)

    End Sub
    Private Sub PopulateData1()
      Dim dtOnRet As DataTable = Me.DataSet.Tables(0)  'Table ที่หัก Retention ไว้
      Dim dtRelRet As DataTable = Me.DataSet.Tables(1) 'Table ที่จ่าย Retention 

      Dim currSupplierCode As String = ""
      Dim currCostCenterCode As String = ""
      Dim currentItemCode As String = ""
      Dim currSupplierIndex As Integer = -1
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumGrossAmt_Supplier As Decimal = 0
      Dim sumGrossAmt_Costcenter As Decimal = 0
      Dim sumRetention_Supplier As Decimal = 0
      Dim sumRetention_Costcenter As Decimal = 0

      Dim sumOpbRetention_Supplier As Decimal = 0
      Dim sumOpbRetention_Costcenter As Decimal = 0

      Dim sumRetentionPays_Supplier As Decimal = 0
      Dim sumRetentionPays_Costcenter As Decimal = 0
      Dim sumPaysBalance_Supplier As Decimal = 0
      Dim sumPaysBalance_Costcenter As Decimal = 0

      Dim tmpRetention As Decimal
      Dim tmpOpbRetention As Decimal
      Dim tmpPaysBalance As Decimal

      Dim sumRetention As Decimal = 0
      Dim sumOpbRetention As Decimal = 0
      Dim sumRetentionPays As Decimal = 0
      Dim sumPaysBalance As Decimal = 0

      For Each drowOnRet As DataRow In dtOnRet.Rows
        Try
          'New Supplier
          If Not currSupplierCode.Equals(drowOnRet("Supplier_Code").ToString) Then
            currSupplierCode = drowOnRet("Supplier_Code").ToString
            m_grid.RowCount += 1
            currSupplierIndex = m_grid.RowCount
            m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currSupplierIndex).Font.Bold = True
            m_grid.RowStyles(currSupplierIndex).ReadOnly = True
            m_grid(currSupplierIndex, 1).CellValue = drowOnRet("Supplier_Code")
            m_grid(currSupplierIndex, 2).CellValue = drowOnRet("Supplier_Name")
            m_grid(currSupplierIndex, 1).Tag = "Supplier"

            'First New CostCenter
            currCostCenterCode = drowOnRet("CC_Code").ToString
            m_grid.RowCount += 1
            currCostCenterIndex = m_grid.RowCount
            m_grid.RowStyles(currCostCenterIndex).BackColor = Color.AntiqueWhite
            m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
            m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
            m_grid(currCostCenterIndex, 1).CellValue = indent & drowOnRet("CC_Code").ToString
            m_grid(currCostCenterIndex, 2).CellValue = indent & drowOnRet("CC_Name").ToString
            m_grid(currCostCenterIndex, 1).Tag = "CostCenter"

            sumGrossAmt_Supplier = 0
            sumGrossAmt_Costcenter = 0
            sumRetention_Supplier = 0
            sumRetention_Costcenter = 0
            sumOpbRetention_Supplier = 0
            sumOpbRetention_Costcenter = 0
            sumRetentionPays_Supplier = 0
            sumRetentionPays_Costcenter = 0
            sumPaysBalance_Supplier = 0
            sumPaysBalance_Costcenter = 0

          Else
            If Not currCostCenterCode.Equals(drowOnRet("CC_Code").ToString) Then
              currCostCenterCode = drowOnRet("CC_Code").ToString

              'New CostCenter
              m_grid.RowCount += 1
              currCostCenterIndex = m_grid.RowCount
              m_grid.RowStyles(currCostCenterIndex).BackColor = Color.AntiqueWhite
              m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
              m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
              m_grid(currCostCenterIndex, 1).CellValue = indent & drowOnRet("CC_Code").ToString
              m_grid(currCostCenterIndex, 2).CellValue = indent & drowOnRet("CC_Name").ToString
              m_grid(currCostCenterIndex, 1).Tag = "CostCenter"

              sumGrossAmt_Costcenter = 0
              sumRetention_Costcenter = 0
              sumOpbRetention_Costcenter = 0
              sumRetentionPays_Costcenter = 0
              sumPaysBalance_Costcenter = 0
            End If
          End If

          'PUR Items
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not drowOnRet.IsNull("Stock_DocDate") Then
            m_grid(currItemIndex, 1).CellValue = indent & indent & CDate(drowOnRet("Stock_DocDate")).ToShortDateString
          End If
          If Not drowOnRet.IsNull("Retention_Code") Then
            m_grid(currItemIndex, 2).CellValue = indent & indent & drowOnRet("Retention_Code").ToString
          End If
          If Not drowOnRet.IsNull("DueDate") Then
            m_grid(currItemIndex, 3).CellValue = indent & indent & CDate(drowOnRet("DueDate")).ToShortDateString
          End If
          If Not drowOnRet.IsNull("Stock_pvrv") Then
            m_grid(currItemIndex, 4).CellValue = indent & indent & drowOnRet("Stock_pvrv").ToString
          End If
          If IsNumeric(drowOnRet("Stock_Aftertax")) Then
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(drowOnRet("Stock_Aftertax")), DigitConfig.Price)
            sumGrossAmt_Supplier += CDec(drowOnRet("Stock_Aftertax"))
            sumGrossAmt_Costcenter += CDec(drowOnRet("Stock_Aftertax"))
          End If
          If IsNumeric(drowOnRet("Stock_Retention")) Then
            tmpRetention = CDec(drowOnRet("Stock_Retention"))
            sumRetention_Supplier += tmpRetention
            sumRetention_Costcenter += tmpRetention
            sumRetention += tmpRetention
          End If
          If tmpRetention <> 0 Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpRetention, DigitConfig.Price)
          End If
          If IsNumeric(drowOnRet("opbRet")) Then
            tmpOpbRetention = CDec(drowOnRet("opbRet"))
            sumOpbRetention_Supplier += tmpOpbRetention
            sumOpbRetention_Costcenter += tmpOpbRetention
            sumOpbRetention += tmpOpbRetention
          End If
          If tmpOpbRetention <> 0 Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpOpbRetention, DigitConfig.Price)
          End If

          Dim tmpSumPaysItem As Decimal = 0
          Dim tmpPaysDate As String = ""
          Dim tmpPaysCode As String = ""
          Dim tmpPaymentCode As String = ""
          For Each drowRelRet As DataRow In dtRelRet.Select("Supplier_Code='" & drowOnRet("Supplier_Code").ToString & _
                                                  "' And Stock_id='" & drowOnRet("Stock_id").ToString & "'")
            If IsNumeric(drowRelRet("Pays_Gross")) Then
              tmpSumPaysItem += CDec(drowRelRet("Pays_Gross"))
            End If
            If Not drowRelRet.IsNull("Pays_DocDate") Then
              tmpPaysDate &= "," & CDate(drowRelRet("Pays_DocDate")).ToShortDateString
            End If
            If Not drowRelRet.IsNull("Pays_Code") Then
              tmpPaysCode &= "," & drowRelRet("Pays_Code").ToString
            End If
            If Not drowRelRet.IsNull("Payment_Code") Then
              tmpPaymentCode &= "," & drowRelRet("Payment_Code").ToString
            End If
          Next

          If tmpSumPaysItem > 0 Then
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpSumPaysItem, DigitConfig.Price)
            sumRetentionPays_Supplier += tmpSumPaysItem
            sumRetentionPays_Costcenter += tmpSumPaysItem
            sumRetentionPays += tmpSumPaysItem
          End If

          If tmpPaysDate.Length > 1 Then
            m_grid(currItemIndex, 10).CellValue = tmpPaysDate.Substring(1)
          End If
          If tmpPaysCode.Length > 1 Then
            m_grid(currItemIndex, 11).CellValue = tmpPaysCode.Substring(1)
          End If
          If tmpPaymentCode.Length > 1 Then
            m_grid(currItemIndex, 12).CellValue = tmpPaymentCode.Substring(1)
          End If

          tmpPaysBalance = tmpOpbRetention - tmpSumPaysItem
          If tmpPaysBalance <> 0 Then
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpPaysBalance, DigitConfig.Price)
            sumPaysBalance_Supplier += tmpPaysBalance
            sumPaysBalance_Costcenter += tmpPaysBalance
            sumPaysBalance += tmpPaysBalance
          End If

          If sumGrossAmt_Supplier <> 0 Then
            m_grid(currSupplierIndex, 5).CellValue = Configuration.FormatToString(sumGrossAmt_Supplier, DigitConfig.Price)
          End If
          If sumGrossAmt_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 5).CellValue = Configuration.FormatToString(sumGrossAmt_Costcenter, DigitConfig.Price)
          End If

          If sumRetention_Supplier <> 0 Then
            m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(sumRetention_Supplier, DigitConfig.Price)
          End If
          If sumRetention_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 6).CellValue = Configuration.FormatToString(sumRetention_Costcenter, DigitConfig.Price)
          End If

          If sumOpbRetention_Supplier <> 0 Then
            m_grid(currSupplierIndex, 7).CellValue = Configuration.FormatToString(sumOpbRetention_Supplier, DigitConfig.Price)
          End If
          If sumOpbRetention_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 7).CellValue = Configuration.FormatToString(sumOpbRetention_Costcenter, DigitConfig.Price)
          End If

          If sumRetentionPays_Supplier <> 0 Then
            m_grid(currSupplierIndex, 8).CellValue = Configuration.FormatToString(sumRetentionPays_Supplier, DigitConfig.Price)
          End If
          If sumRetentionPays_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 8).CellValue = Configuration.FormatToString(sumRetentionPays_Costcenter, DigitConfig.Price)
          End If

          If sumPaysBalance_Supplier <> 0 Then
            m_grid(currSupplierIndex, 9).CellValue = Configuration.FormatToString(sumPaysBalance_Supplier, DigitConfig.Price)
          End If
          If sumPaysBalance_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 9).CellValue = Configuration.FormatToString(sumPaysBalance_Costcenter, DigitConfig.Price)
          End If
        Catch ex As Exception
          MessageBox.Show(ex.ToString & vbCrLf & ex.StackTrace)
        End Try
      Next
      'sumPaysBalance
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(143, 197, 185)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 4).CellValue = "รวม"
      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(sumOpbRetention, DigitConfig.Price)
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(sumRetentionPays, DigitConfig.Price)
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(sumPaysBalance, DigitConfig.Price)

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
      'myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col17", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col18", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 11

      widths.Add(150)
      widths.Add(200)
      widths.Add(100)
      widths.Add(100)
      widths.Add(120) 'ยอดเอกสาร
      widths.Add(100) ' ยอดหัก retention
      widths.Add(100) ' retention ยกมา
      widths.Add(100) ' ยอดชำระ retention
      widths.Add(100) ' retentionคงเหลือ
      widths.Add(150)
      widths.Add(150)
      widths.Add(150)

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

          Select Case i
            Case 0, 1, 2, 3, 9, 10, 11
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
              cs.Format = "s"
            Case Else
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
              cs.Format = "d"
          End Select

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
        Return "RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptRetention.ListLabel}"
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
      Return "RptRetention"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptRetention"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 4 To m_grid.RowCount
        Dim fn As System.Drawing.Font
        If m_grid(rowIndex, 1).Tag = "Supplier" OrElse m_grid(rowIndex, 1).Tag = "CostCenter" Then
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
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

