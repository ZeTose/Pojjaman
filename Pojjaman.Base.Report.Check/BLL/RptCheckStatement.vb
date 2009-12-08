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
  Public Class RptCheckStatement
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
    Public Overrides Sub RefreshDataSet()
      Dim params() As SqlParameter
      If Not Filters Is Nothing AndAlso Filters.Length > 0 Then
        ReDim params(Filters.Length - 1)
        For i As Integer = 0 To Filters.Length - 1
          params(i) = New SqlParameter("@" & Filters(i).Name, Filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, Me.GetListSprocName, params)
      Me.DataSet = ds
    End Sub
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

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 150
      m_grid.ColWidths(5) = 140
      m_grid.ColWidths(6) = 140
      m_grid.ColWidths(7) = 150
      m_grid.ColWidths(8) = 140
      m_grid.ColWidths(9) = 140
      m_grid.ColWidths(10) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Pay}") '"จ่าย"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Recive}") '"รับ"

      m_grid(1, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Date}") '"วันที่"
      m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.CheckNumber}") '"เลขที่เช็ค"
      m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.ReciveCheckDate}") '"วันที่รับเช็ค"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.PayTo}") '"จ่ายให้กับ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.CheckPayBalance}") '"ยอดจ่ายเช็ค"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.ReciveCheckFrom}") '"รายรับเช็คจากบริษัท"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Cost}") '"จำนวนเงิน"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Balance}") '"คงเหลือ"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Note}") '"หมายเหตุ"

      m_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Vat}")  '"ใบกำกับภาษี"
      m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Cost}")  '"จำนวนเงิน"

      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dtPay As DataTable = Me.DataSet.Tables(0)
      Dim dtReceive As DataTable = Me.DataSet.Tables(1)
      Dim dtOpen As DataTable = Me.DataSet.Tables(2)
      Dim dtDate As DataTable = Me.DataSet.Tables(3)

      Dim currentCheckId As String = ""
      Dim currentVatCode As String = ""
      Dim tmpRemain As Decimal = 0
      Dim tmpShowDate As Boolean = False

      Dim currCheckIndex As Integer = -1
      Dim currVatIndex As Integer = -1
      Dim indent As String = Space(3)

      If dtOpen.Rows.Count <> 0 Then
        Dim row As DataRow = dtOpen.Rows(0)
        tmpRemain = CDec(row("Openingbalance"))
      Else
        tmpRemain = 0
      End If
      m_grid.RowCount += 1
      currCheckIndex = m_grid.RowCount
      m_grid.RowStyles(currCheckIndex).ReadOnly = True
      m_grid(currCheckIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.OpeningBalance}") '"ยอดยกมา"
      m_grid(currCheckIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
      For Each row As DataRow In dtDate.Rows
        If Not Row.IsNull("DocDate") Then
          If IsDate(row("DocDate")) Then

            Dim filteredReceiveRows As DataRow() = dtReceive.Select("DocDate =" & "'" & DateTimeService.ConvertToString(CDate(Row("DocDate"))) & "'")
            For Each Myrow As DataRow In filteredReceiveRows
              m_grid.RowCount += 1
              currCheckIndex = m_grid.RowCount
              m_grid.RowStyles(currCheckIndex).BackColor = Color.FromArgb(128, 255, 128)
              m_grid.RowStyles(currCheckIndex).Font.Bold = True
              m_grid.RowStyles(currCheckIndex).ReadOnly = True
              If tmpShowDate = False Then
                If Not MyRow.IsNull("DocDate") Then
                  If IsDate(MyRow("DocDate")) Then
                    m_grid(currCheckIndex, 1).CellValue = CDate(MyRow("DocDate")).ToShortDateString
                    tmpShowDate = True
                  End If
                End If
              End If
              If Not Myrow.IsNull("CheckPayer") Then
                m_grid(currCheckIndex, 7).CellValue = Myrow("CheckPayer").ToString
              End If
              If IsNumeric(Myrow("Amt")) Then
                m_grid(currCheckIndex, 8).CellValue = Configuration.FormatToString(CDec(Myrow("Amt")), DigitConfig.Price)
              End If
              If Not myrow.IsNull("Note") Then
                m_grid(currCheckIndex, 10).CellValue = MyRow("Note").tostring
              End If
              tmpRemain += CDec(Myrow("Amt"))
              m_grid(currCheckIndex, 9).CellValue = Configuration.FormatToString(CDec(tmpRemain), DigitConfig.Price)
              currentCheckId = ""
            Next
            Dim fileteredPayRows As DataRow() = dtPay.Select("DocDate =" & "'" & DateTimeService.ConvertToString(CDate(Row("DocDate"))) & "'")
            For Each MyRow As DataRow In fileteredPayRows
              m_grid.RowCount += 1
              currCheckIndex = m_grid.RowCount
              m_grid.RowStyles(currCheckIndex).BackColor = Color.FromArgb(128, 255, 128)
              m_grid.RowStyles(currCheckIndex).Font.Bold = True
              m_grid.RowStyles(currCheckIndex).ReadOnly = True
              If MyRow("CheckId").ToString & MyRow("BankingType").tostring <> currentCheckId Then
                If tmpShowDate = False Then
                  If Not MyRow.IsNull("DocDate") Then
                    If IsDate(MyRow("DocDate")) Then
                      m_grid(currCheckIndex, 1).CellValue = CDate(MyRow("DocDate")).ToShortDateString
                      tmpShowDate = True
                    End If
                  End If
                End If
                If Not MyRow.IsNull("CheckCode") Then
                  m_grid(currCheckIndex, 2).CellValue = MyRow("CheckCode").tostring
                End If
                If IsDate(MyRow("DueDate")) Then
                  m_grid(currCheckIndex, 3).CellValue = CDate(MyRow("DueDate")).ToShortDateString
                End If
                If Not MyRow.IsNull("Recipient") Then
                  m_grid(currCheckIndex, 4).CellValue = MyRow("Recipient").tostring
                End If
                If IsNumeric(MyRow("CheckAmt")) Then
                  m_grid(currCheckIndex, 6).CellValue = Configuration.FormatToString(CDec(Myrow("CheckAmt")), DigitConfig.Price)
                End If
                If Not myrow.IsNull("Note") Then
                  m_grid(currCheckIndex, 10).CellValue = MyRow("Note").tostring
                End If
                tmpRemain -= CDec(Myrow("CheckAmt"))
                m_grid(currCheckIndex, 9).CellValue = Configuration.FormatToString(CDec(tmpRemain), DigitConfig.Price)
                currentCheckId = MyRow("CheckId").ToString & MyRow("BankingType").tostring
                currentVatCode = ""
              End If
              If MyRow("VatCode").ToString <> currentVatCode And Not MyRow.IsNull("VatCode") Then
                m_grid.RowCount += 1
                currVatIndex = m_grid.RowCount
                m_grid.RowStyles(currVatIndex).ReadOnly = True
                m_grid(currVatIndex, 4).CellValue = indent & MyRow("VatCode").tostring
                If IsNumeric(MyRow("VatAmount")) Then
                  m_grid(currVatIndex, 5).CellValue = indent & Configuration.FormatToString(CDec(MyRow("VatAmount")), DigitConfig.Price)
                End If
                m_grid(currVatIndex, 9).CellValue = Configuration.FormatToString(CDec(tmpRemain), DigitConfig.Price)
                currentVatCode = MyRow("VatCode").tostring
              End If
            Next
            tmpShowDate = False

          End If
        End If
      Next

      m_grid.RowCount += 1
      currCheckIndex = m_grid.RowCount
      m_grid.RowStyles(currCheckIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currCheckIndex).Font.Bold = True
      m_grid.RowStyles(currCheckIndex).ReadOnly = True
      m_grid(currCheckIndex, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.Balance}") '"คงเหลือ"
      m_grid(currCheckIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(currCheckIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptCheckStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptCheckStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptCheckStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCheckStatement.ListLabel}"
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
      Return "RptCheckStatement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptCheckStatement"
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

