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
  Public Class RptPettyCash
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
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 2
      m_grid.ColCount = 10

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(5) = 120
      m_grid.ColWidths(4) = 120
      m_grid.ColWidths(6) = 200
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.PCCode}") '"เลขที่เงินสดย่อย"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.PCName}") '"ชื่อเงินสดย่อย"
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.PCAmt}") '"วงเงินสดย่อย"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.DocDate}")  '"เลขที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.DocCode}") '"รหัสเอกสารอ้างอิง"
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.DocType}") '"ประเภทเอกสาร"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.PVcode}") '"ใบสำคัญจ่าย"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.CCCode}") '"รหัส Cost Cenetr"
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.CCName}") '"ชื่อ Cost Cenetr"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.PayAmt}") '"ยอดตัดจ่าย"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.ClaimAmt}") '"ยอดเบิก"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.Remain}") '"ยอดคงเหลือ"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.ClaimArrear}") '"ยอดค้างเบิก"

      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.ItemCode}") '"รหัสสินค้า"
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.ItemName}") '"รายละเอียด"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim PCDt As DataTable = Me.DataSet.Tables(0)
      'Dim PCOpeningBal As DataTable = Me.DataSet.Tables(1)
      Dim RefDocDt As DataTable = Me.DataSet.Tables(2)
      Dim ItemDt As DataTable = Me.DataSet.Tables(3)
      Dim currentPCCode As String = ""
      Dim currentRefDocCode As String = ""
      Dim currentItemCode As String = ""
      Dim tmpPCRemainAmt As Decimal = 0
      Dim tmpInitPCAmt As Decimal = 0
      Dim tmpInitPCRemain As Decimal = 0
      Dim tmpInitPCClaimArrear As Decimal = 0

      Dim tmpPayAmt As Decimal = 0
      Dim tmpClaimAmt As Decimal = 0
      Dim tmpCriteria As String = ""
      Dim sumPayAmt As Decimal = 0
      Dim sumClaimAmt As Decimal = 0
      Dim sumPayAmtItem As Decimal = 0
      Dim sumClaimAmtItem As Decimal = 0

      Dim allSumPayAmtItem As Decimal = 0
      Dim allSumClaimAmtItem As Decimal = 0

      Dim pcEndingBalance As Decimal = 0
      Dim allPcEndingBalance As Decimal = 0

      Dim pcAmt As Decimal = 0

      Dim currPCIndex As Integer = -1
      Dim currRefDocIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)

      For Each PCrow As DataRow In PCDt.Rows
        If PCrow("DocId").ToString <> currentPCCode Then
          If currentPCCode <> "" Then
            m_grid.RowCount += 1
            currPCIndex = m_grid.RowCount
            m_grid.RowStyles(currPCIndex).ReadOnly = True
            m_grid(currPCIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.Sum}") '"รวม"
            m_grid(currPCIndex, 7).CellValue = Configuration.FormatToString(sumPayAmtItem, DigitConfig.Price)
            m_grid(currPCIndex, 8).CellValue = Configuration.FormatToString(sumClaimAmtItem, DigitConfig.Price)
            m_grid(currPCIndex, 9).CellValue = Configuration.FormatToString(pcEndingBalance, DigitConfig.Price)
          End If
          allPcEndingBalance += pcEndingBalance
          allSumPayAmtItem += sumPayAmtItem
          allSumClaimAmtItem += sumClaimAmtItem

          tmpPCRemainAmt = 0
          tmpInitPCAmt = 0
          tmpInitPCRemain = 0
          tmpInitPCClaimArrear = 0

          tmpPayAmt = 0
          tmpClaimAmt = 0
          sumPayAmtItem = 0
          sumClaimAmtItem = 0
          
          pcEndingBalance = 0
          m_grid.RowCount += 1
          currPCIndex = m_grid.RowCount
          m_grid.RowStyles(currPCIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currPCIndex).Font.Bold = True
          m_grid.RowStyles(currPCIndex).ReadOnly = True
          m_grid(currPCIndex, 1).CellValue = PCrow("DocCode")
          m_grid(currPCIndex, 2).CellValue = PCrow("DocName")
          If IsNumeric(PCrow("PCAmt")) Then
            m_grid(currPCIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currPCIndex, 3).CellValue = Configuration.FormatToString(CDec(PCrow("PCAmt")), DigitConfig.Price)
            pcAmt = Configuration.FormatToString(CDec(PCrow("PCAmt")), DigitConfig.Price)
            'tmpPCRemainAmt = CDec(PCrow("PCAmt"))
            'tmpInitPCAmt = CDec(PCrow("PCAmt"))
          End If

          '  ใส่ Balance และคงเหลือ
          If IsNumeric(PCrow("PcRemain")) Then
            m_grid(currPCIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currPCIndex, 9).CellValue = Configuration.FormatToString(CDec(PCrow("PcRemain")), DigitConfig.Price)
            tmpPCRemainAmt = Configuration.FormatToString(CDec(PCrow("PcRemain")), DigitConfig.Price)
            'tmpPCRemainAmt = CDec(PCrow("PCAmt"))
            'tmpInitPCAmt = CDec(PCrow("PCAmt"))
          End If
          If IsNumeric(PCrow("PayAmt")) Then
            m_grid(currPCIndex, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currPCIndex, 10).CellValue = Configuration.FormatToString(CDec(PCrow("PayAmt")), DigitConfig.Price)
            sumClaimAmtItem = Configuration.FormatToString(CDec(PCrow("PayAmt")), DigitConfig.Price)
            'tmpPCRemainAmt = CDec(PCrow("PCAmt"))
            'tmpInitPCAmt = CDec(PCrow("PCAmt"))
          End If

          '

          currentPCCode = PCrow("DocId").ToString
          Dim myRefDocRow As DataRow() = Me.DataSet.Tables(2).Select("PCId=" & CInt(PCrow("DocId")))
          For Each RefDocRow As DataRow In myRefDocRow
            m_grid.RowCount += 1
            currRefDocIndex = m_grid.RowCount
            m_grid.RowStyles(currRefDocIndex).BackColor = Color.FromArgb(250, 227, 197)
            m_grid.RowStyles(currRefDocIndex).Font.Bold = True
            m_grid.RowStyles(currRefDocIndex).ReadOnly = True
            If IsDate(RefDocRow("RefDocDate")) Then
              m_grid(currRefDocIndex, 1).CellValue = indent & CDate(RefDocRow("RefDocDate")).ToShortDateString
            End If
            If Not RefDocRow.IsNull("RefDocCode") Then
              m_grid(currRefDocIndex, 2).CellValue = indent & RefDocRow("RefDocCode").ToString
            End If
            If Not RefDocRow.IsNull("RefDocType") Then
              m_grid(currRefDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
              m_grid(currRefDocIndex, 3).CellValue = indent & RefDocRow("RefDocType").ToString
            End If
            If Not RefDocRow.IsNull("PVcode") Then
              m_grid(currRefDocIndex, 4).CellValue = indent & RefDocRow("PVcode").ToString
            End If
            If Not RefDocRow.IsNull("CCCode") Then
              m_grid(currRefDocIndex, 5).CellValue = indent & RefDocRow("CCCode").ToString
            End If
            If Not RefDocRow.IsNull("CCName") Then
              If Not RefDocRow.IsNull("RefDocId") AndAlso CInt(RefDocRow("RefDocId")) = -1 Then
                m_grid(currRefDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                m_grid(currRefDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.OpeningBalance}") '"ยอดยกมา"
              Else
                m_grid(currRefDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                m_grid(currRefDocIndex, 6).CellValue = indent & RefDocRow("CCName").ToString
              End If
            End If
            If RefDocRow("RefDocType") = "ปิดวงเงินสดย่อย" Then
              If IsNumeric(RefDocRow("ClosedAmt")) Then
                If CInt(RefDocRow("RefDocId")) <> -1 Then
                  m_grid(currRefDocIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(RefDocRow("ClosedAmt")), DigitConfig.Price)
                End If
                sumPayAmtItem += CDec(RefDocRow("ClosedAmt"))
              End If
            Else
              If IsNumeric(RefDocRow("PayAmt")) Then
                If CInt(RefDocRow("RefDocId")) <> -1 Then
                  m_grid(currRefDocIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(RefDocRow("PayAmt")), DigitConfig.Price)
                End If
                sumPayAmtItem += CDec(RefDocRow("PayAmt"))
              End If
            End If

            If IsNumeric(RefDocRow("ClaimAmt")) Then
              If CInt(RefDocRow("RefDocId")) <> -1 Then
                m_grid(currRefDocIndex, 8).CellValue = indent & Configuration.FormatToString(CDec(RefDocRow("ClaimAmt")), DigitConfig.Price)
              End If
              sumClaimAmtItem += CDec(RefDocRow("ClaimAmt"))
            End If

            Dim m_closedAmt As Decimal = 0
            Dim m_claimAmt As Decimal = 0
            Dim m_Amt As Decimal = 0
            If IsNumeric(RefDocRow("ClosedAmt")) Then
              m_closedAmt = CDec(RefDocRow("ClosedAmt"))
            End If
            If IsNumeric(RefDocRow("ClaimAmt")) Then
              m_claimAmt = CDec(RefDocRow("ClaimAmt"))
            End If
            If IsNumeric(RefDocRow("PayAmt")) Then
              m_Amt = CDec(RefDocRow("PayAmt"))
            End If

            tmpPCRemainAmt = tmpPCRemainAmt + m_claimAmt - m_Amt - m_closedAmt
            tmpPayAmt = pcAmt - tmpPCRemainAmt
            pcEndingBalance = tmpPCRemainAmt
            'allPcEndingBalance += pcEndingBalance

            If RefDocRow("RefDocType") = "ปิดวงเงินสดย่อย" Then
              tmpPayAmt = 0
            End If
            m_grid(currRefDocIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(tmpPCRemainAmt), DigitConfig.Price)
            m_grid(currRefDocIndex, 10).CellValue = indent & Configuration.FormatToString(CDec(tmpPayAmt), DigitConfig.Price)


            Dim myItemRow As DataRow() = Me.DataSet.Tables(3).Select("StockId=" & CStr(RefDocRow("RefDocId")))
            For Each ItemRow As DataRow In myItemRow
              m_grid.RowCount += 1
              currItemIndex = m_grid.RowCount
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              If Not ItemRow.IsNull("ItemCode") Then
                m_grid(currItemIndex, 1).CellValue = indent & indent & ItemRow("ItemCode").ToString
              End If
              If Not ItemRow.IsNull("ItemName") Then
                m_grid(currItemIndex, 2).CellValue = indent & indent & ItemRow("ItemName").ToString
              End If
              If Not ItemRow.IsNull("Amount") Then
                m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(ItemRow("Amount")), DigitConfig.Price)
              End If
            Next
          Next
        End If
      Next

      m_grid.RowCount += 1
      currPCIndex = m_grid.RowCount
      m_grid.RowStyles(currPCIndex).ReadOnly = True
      m_grid(currPCIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.Sum}") '"รวม"
      m_grid(currPCIndex, 7).CellValue = Configuration.FormatToString(sumPayAmtItem, DigitConfig.Price)
      m_grid(currPCIndex, 8).CellValue = Configuration.FormatToString(sumClaimAmtItem, DigitConfig.Price)
      m_grid(currPCIndex, 9).CellValue = Configuration.FormatToString(pcEndingBalance, DigitConfig.Price)

      ''รวมกับวงเงินสุดท้ายด้วย
      allPcEndingBalance += pcEndingBalance
      allSumPayAmtItem += sumPayAmtItem
      allSumClaimAmtItem += sumClaimAmtItem
      ''รวมท้ายรายการ
      m_grid.RowCount += 1
      currPCIndex = m_grid.RowCount
      m_grid.RowStyles(currPCIndex).ReadOnly = True
      m_grid(currPCIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.TotalSum}") '"รวมทั้งสิ้น"
      m_grid(currPCIndex, 7).CellValue = Configuration.FormatToString(allSumPayAmtItem, DigitConfig.Price)
      m_grid(currPCIndex, 8).CellValue = Configuration.FormatToString(allSumClaimAmtItem, DigitConfig.Price)
      m_grid(currPCIndex, 9).CellValue = Configuration.FormatToString(allPcEndingBalance, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPettyCash.ListLabel}"
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
      Return "RptPettyCash"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPettyCash"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
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
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

