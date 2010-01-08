Option Strict On
Option Explicit On 

Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptAR
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
      m_grid.RowCount = 1
      m_grid.ColCount = 13

      Dim GridRangeStyle1 As GridRangeStyle = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(0, 10, 0, 12)})

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 180
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 120
      m_grid.ColWidths(5) = 120
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 120
      m_grid.ColWidths(11) = 120
      m_grid.ColWidths(12) = 120
      m_grid.ColWidths(13) = 200


      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrID}")      '"รหัสลูกหนี้"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrName}")    '"ชื่อลูกหนี้"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.CreditAmount}") '"วงเงินเครดิต"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.ReminningCraditAmount}") '"วงเงินเครดิตคงเหลือ"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrStatus}")  '"สถานะลูกหนี้"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.DocDate}")  '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.DocNumber}") '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.InVoid}")   '"เลขที่ใบกำกับ"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.DocType}")  '"ประเภทเอกสาร"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrCode}")   '"เลขที่ใบสำคัญจ่าย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Debit}")    '"เดบิต"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Credit}")    '"เครดิต"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")    '"คงเหลือ"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Term}")     '"เทอม"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Debit}")     '"เดบิต"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Credit}")    '"เครดิต"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")   '"คงเหลือ"
      m_grid(1, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}")   '"หมายเหตุ"

      GridRangeStyle1.Range = GridRangeInfo.Cell(0, 10)
      GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Retention}")  '"Retention"
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Center
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)
      Dim currentCustomerCode As String = ""
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)
      Dim tmpRemain As Decimal = 0
      Dim tmpDebit As Decimal = 0
      Dim tmpCredit As Decimal = 0
      Dim tmpDebit2 As Decimal = 0
      Dim tmpCredit2 As Decimal = 0
      Dim SumCustomer As Int32 = 0
      Dim SumOpnBalance As Decimal = 0
      Dim SumDebit As Decimal = 0
      Dim SumCredit As Decimal = 0
      Dim LastCustomerCrAmtRecord As Decimal = 0
      Dim tmpRetDebit As Decimal = 0
      Dim tmpRetCredit As Decimal = 0
      Dim tmpRetRemain As Decimal = 0
      Dim sumRetDebit As Decimal = 0
      Dim sumRetCredit As Decimal = 0
      Dim SumRetOpnBalance As Decimal = 0

      Dim currentCustomerIndex As Integer = -1
      Dim currentDocIndex As Integer = -1

      For Each row As DataRow In dt2.Rows
        If row("CustomerCode").ToString <> currentCustomerCode Then
          SumCustomer += 1

          If SumCustomer > 1 Then
            'วงเงินเครดิตคงเหลือ
            m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")) - tmpRemain, DigitConfig.Price)
            m_grid(currentCustomerIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.RowCount += 1
            currentDocIndex = m_grid.RowCount
            m_grid.RowStyles(currentDocIndex).ReadOnly = True
            m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Total}") '"รวมเงิน"
            m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(tmpDebit, DigitConfig.Price)
            m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(tmpCredit, DigitConfig.Price)
            m_grid(currentDocIndex, 10).CellValue = Configuration.FormatToString(tmpRetDebit, DigitConfig.Price)
            m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(tmpRetCredit, DigitConfig.Price)
            tmpDebit = 0
            tmpCredit = 0
            tmpRemain = 0

            tmpRetDebit = 0
            tmpRetCredit = 0
            tmpRetRemain = 0
          End If
          m_grid.RowCount += 1
          currentCustomerIndex = m_grid.RowCount
          m_grid.RowStyles(currentCustomerIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currentCustomerIndex).Font.Bold = True
          m_grid.RowStyles(currentCustomerIndex).ReadOnly = True

          m_grid(currentCustomerIndex, 1).CellValue = row("CustomerCode")
          m_grid(currentCustomerIndex, 2).CellValue = row("CustomerName")
          m_grid(currentCustomerIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
          m_grid(currentCustomerIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

          m_grid(currentCustomerIndex, 5).CellValue = row("Status")
          currentCustomerCode = row("CustomerCode").ToString
          LastCustomerCrAmtRecord = CDec(row("CreditAmount"))
          Dim supRows As DataRow() = Me.DataSet.Tables(0).Select("CustomerCode ='" & currentCustomerCode & "'")
          If supRows.Length = 1 Then
            m_grid.RowCount += 1
            currentDocIndex = m_grid.RowCount
            m_grid.RowStyles(currentDocIndex).ReadOnly = True
            m_grid(currentDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.OpeningBalance}") '"ยอดยกมา"
            m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(CDec(supRows(0)("OpenningBalance")), DigitConfig.Price)
            SumOpnBalance += CDec(supRows(0)("OpenningBalance"))
            tmpRemain = CDec(supRows(0)("OpenningBalance"))
            SumRetOpnBalance += CDec(supRows(0)("RetentionOpenningBalance"))
            tmpRetRemain = CDec(supRows(0)("RetentionOpenningBalance"))
          End If
          currentDocCode = ""
        End If
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currentDocIndex = m_grid.RowCount
          m_grid.RowStyles(currentDocIndex).ReadOnly = True
          If IsDate(row("DocDate")) Then
            m_grid(currentDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("DocCode") Then
            m_grid(currentDocIndex, 2).CellValue = indent & row("DocCode").ToString
          End If
          If Not row.IsNull("RefCode") Then
            m_grid(currentDocIndex, 3).CellValue = indent & row("RefCode").ToString
          End If
          If Not row.IsNull("Type") Then
            m_grid(currentDocIndex, 4).CellValue = indent & row("Type").ToString
          End If
          If Not row.IsNull("GlCode") Then
            m_grid(currentDocIndex, 5).CellValue = indent & row("GlCode").ToString
          End If
          If IsNumeric(row("Debit")) Then
            m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Debit")), DigitConfig.Price)
            tmpRemain += CDec(row("Debit"))
            tmpDebit += CDec(row("Debit"))
            SumDebit += CDec(row("Debit"))
          End If
          If IsNumeric(row("Credit")) Then
            m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Credit")), DigitConfig.Price)
            tmpRemain -= CDec(row("Credit"))
            tmpCredit += CDec(row("Credit"))
            SumCredit += CDec(row("Credit"))
          End If
          m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
          If Not row.IsNull("CreditTerm") Then
            m_grid(currentDocIndex, 9).CellValue = Configuration.FormatToString(CInt(row("CreditTerm")), DigitConfig.Int)
          End If
          If Not row.IsNull("DebitRetention") Then
            m_grid(currentDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("DebitRetention")), DigitConfig.Price)
            tmpRetRemain += CDec(row("DebitRetention"))
            tmpRetDebit += CDec(row("DebitRetention"))
            sumRetDebit += CDec(row("DebitRetention"))
          End If
          If Not row.IsNull("CreditRetention") Then
            m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("CreditRetention")), DigitConfig.Price)
            tmpRetRemain -= CDec(row("CreditRetention"))
            tmpRetCredit += CDec(row("CreditRetention"))
            sumRetCredit += CDec(row("CreditRetention"))
          End If
          m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(tmpRetRemain, DigitConfig.Price)
          currentDocCode = row("DocCode").ToString
          If Not row.IsNull("GlNote") Then
            m_grid(currentDocIndex, 13).CellValue = indent & row("GlNote").ToString
          End If
        End If
      Next

      If dt2.Rows.Count > 0 Then
        'วงเงินเครดิตคงเหลือ
        m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(LastCustomerCrAmtRecord - tmpRemain, DigitConfig.Price)
        m_grid(currentCustomerIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid.RowCount += 1
        currentDocIndex = m_grid.RowCount
        m_grid.RowStyles(currentDocIndex).ReadOnly = True
        m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Total}")    '"รวมเงิน"
        m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(tmpDebit, DigitConfig.Price)
        m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(tmpCredit, DigitConfig.Price)
        m_grid(currentDocIndex, 10).CellValue = Configuration.FormatToString(tmpRetDebit, DigitConfig.Price)
        m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(tmpRetCredit, DigitConfig.Price)

        m_grid.RowCount += 1
        currentDocIndex = m_grid.RowCount
        m_grid.RowStyles(currentDocIndex).BackColor = Color.FromArgb(128, 255, 128)
        m_grid.RowStyles(currentDocIndex).Font.Bold = True
        m_grid.RowStyles(currentDocIndex).ReadOnly = True
        m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrTotal}")    '"รวมลูกหนี้(ราย)"
        m_grid(currentDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.OpeningBalance}") '"ยอดยกมา"
        m_grid(currentDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Debit}")    '"เดบิต"
        m_grid(currentDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Credit}")     '"เครดิต"
        m_grid(currentDocIndex, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")     '"คงเหลือ"
        m_grid(currentDocIndex, 10).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Debit}")    '"เดบิต"
        m_grid(currentDocIndex, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Credit}")     '"เครดิต"
        m_grid(currentDocIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")     '"คงเหลือ"
        m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currentDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        m_grid.RowCount += 1
        currentDocIndex = m_grid.RowCount
        m_grid.RowStyles(currentDocIndex).BackColor = Color.FromArgb(128, 255, 128)
        m_grid.RowStyles(currentDocIndex).Font.Bold = True
        m_grid.RowStyles(currentDocIndex).ReadOnly = True
        m_grid(currentDocIndex, 3).CellValue = SumCustomer
        m_grid(currentDocIndex, 5).CellValue = Configuration.FormatToString(SumOpnBalance, DigitConfig.Price)
        m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(SumDebit, DigitConfig.Price)
        m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(SumCredit, DigitConfig.Price)
        m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(SumOpnBalance + SumDebit - SumCredit, DigitConfig.Price)

        m_grid(currentDocIndex, 10).CellValue = Configuration.FormatToString(sumRetDebit, DigitConfig.Price)
        m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(sumRetCredit, DigitConfig.Price)
        m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(SumRetOpnBalance + sumRetDebit - sumRetCredit, DigitConfig.Price)

        m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        m_grid(currentDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAR"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAR.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAR.ListLabel}"
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
      Return "RptAR"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAR"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        For colIndex As Integer = 1 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (colIndex - 1).ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

