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
  Public Class RptBankStatement
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
      m_grid.ColCount = 11

      m_grid.ColWidths(1) = 150
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 150
      m_grid.ColWidths(4) = 150
      m_grid.ColWidths(5) = 200
      m_grid.ColWidths(6) = 150
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120
      m_grid.ColWidths(9) = 120
      m_grid.ColWidths(10) = 120
      m_grid.ColWidths(11) = 120

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Bank}") '"ธนาคาร/สาขา"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookID}") '"เลขที่สมุดเงินฝาก"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookName}") '"ชื่อบัญชี"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookType}") '"ประเภทสมุดบัญชี"

      m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Date}")  '"วันที่"
      m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.DocDate}")  '"เลขที่เอกสาร"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.ChequeNumber}")  '"เลขที่เช็ค"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.List}")  '"รายการ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.RefCode}")  '"ใบสำคัญ"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Deposit}")  '"ฝาก"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Withdraw}")  '"ถอน"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BalanceAmount}")  '"ยอดคงเหลือ"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Note}")  '"หมายเหตุ"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.RefPVRV}")  '"เอกสารอ้างอิง"

    End Sub
    Private Sub PopulateData()
      Dim dtdoc As DataTable = Me.DataSet.Tables(0)
      Dim dtOpen As DataTable = Me.DataSet.Tables(1)
      Dim dtba As DataTable = Me.DataSet.Tables(2)
      Dim dtRef As DataTable = Me.DataSet.Tables(3)
      Dim currentItemCode As String = ""
      Dim currentDocCode As String = ""

      Dim currItemIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currBAIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim tmpSum As Decimal = 0

      Dim key As String = ""
      Dim hashRef As New Hashtable
      For Each row As DataRow In dtRef.Rows
        key = String.Format("{0}-{1}", row("refid"), row("reftype"))
        If Not hashRef.ContainsKey(key) Then
          hashRef.Add(key, row("refpvrv").ToString)
        Else
          hashRef(key) = CType(hashRef(key), String) + "," + row("refpvrv").ToString
        End If
      Next

      For Each bar As DataRow In dtba.Rows
        Dim brh As New DataRowHelper(bar)
        tmpSum = 0
        m_grid.RowCount += 1
        currBAIndex = m_grid.RowCount
        m_grid.RowStyles(currBAIndex).BackColor = Color.FromArgb(128, 255, 128)
        m_grid.RowStyles(currBAIndex).Font.Bold = True
        m_grid.RowStyles(currBAIndex).ReadOnly = True
        m_grid(currBAIndex, 1).CellValue = brh.GetValue(Of String)("BankBranchName")
        m_grid(currBAIndex, 2).CellValue = brh.GetValue(Of String)("BankacctBankCode")
        m_grid(currBAIndex, 3).CellValue = brh.GetValue(Of String)("BankacctName")
        m_grid(currBAIndex, 4).CellValue = brh.GetValue(Of String)("BankacctType")

        Dim OpenRows As DataRow() = dtOpen.Select("BankAccountId =" & brh.GetValue(Of Decimal)("bankacct_id").ToString)
        If OpenRows.Length <> 0 Then
          For Each Myrow As DataRow In OpenRows
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            Dim myrh As New DataRowHelper(Myrow)

            If IsNumeric(Myrow("Balanceamt")) Then
              m_grid(currItemIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.OpeningBalance}") '"ยอดยกมา"
              m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(myrh.GetValue(Of Decimal)("Balanceamt"), DigitConfig.Price)
              tmpSum = myrh.GetValue(Of Decimal)("Balanceamt")
            End If
          Next
        Else
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          m_grid(currItemIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.OpeningBalance}") '"ยอดยกมา"
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(0), DigitConfig.Price)
        End If

        For Each row As DataRow In dtdoc.Select("BankAccountId =" & brh.GetValue(Of Decimal)("bankacct_id").ToString)
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True

          Dim drh As New DataRowHelper(row)

          key = String.Format("{0}-{1}", drh.GetValue(Of String)("refid"), drh.GetValue(Of String)("reftype"))

          m_grid(currItemIndex, 2).CellValue = indent & drh.GetValue(Of Date)("DocDate").ToShortDateString
          m_grid(currItemIndex, 3).CellValue = indent & drh.GetValue(Of String)("DocCode")
          m_grid(currItemIndex, 4).CellValue = indent & drh.GetValue(Of String)("CqCode")
          m_grid(currItemIndex, 5).CellValue = indent & drh.GetValue(Of String)("Detail")
          m_grid(currItemIndex, 6).CellValue = indent & drh.GetValue(Of String)("Refcode").ToString
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("Deprositamt"), DigitConfig.Price)
          tmpSum += drh.GetValue(Of Decimal)("Deprositamt")
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("Withdrawamt"), DigitConfig.Price)
          tmpSum -= drh.GetValue(Of Decimal)("Withdrawamt")
          m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(tmpSum), DigitConfig.Price)
          m_grid(currItemIndex, 10).CellValue = indent & drh.GetValue(Of String)("Note")
          If drh.GetValue(Of Integer)("reftype") = 22 OrElse drh.GetValue(Of Integer)("reftype") = 27 Then
            If hashRef.ContainsKey(key) Then
              m_grid(currItemIndex, 11).CellValue = indent & CType(hashRef(key), String)
            Else
              m_grid(currItemIndex, 11).CellValue = indent & drh.GetValue(Of String)("pvrv")
            End If
          Else
            m_grid(currItemIndex, 11).CellValue = indent & drh.GetValue(Of String)("pvrv")
          End If

          currentItemCode = drh.GetValue(Of String)("DocCode")
        Next
      Next
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptBankStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptBankStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptBankStatement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.ListLabel}"
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
#End Region
#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptBankStatement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptBankStatement"
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

        n += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

