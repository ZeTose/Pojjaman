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
  Public Class RptStockCardMat
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
    Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      Try
        m_grid = grid
        m_grid.BeginUpdate()
        m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
        m_grid.Model.Options.NumberedColHeaders = False
        m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
        CreateHeader()
        PopulateData()
      Catch ex As Exception
        Throw ex
      Finally
        m_grid.EndUpdate()
      End Try
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 9

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 150
      m_grid.ColWidths(9) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.lci_code}") '"รหัสวัสดุ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.lci_name}") '"ชื่อวัสดุ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.docdate}")   '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.stock_code}")  '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.entity_description}")  '"ประเภทเอกสาร"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.defaultunitname}")  '"หน่วยนับมาตรฐาน"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.receipt}")  '"รับ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.withdraw}")  '"จ่าย"
      'm_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.return}")  '"คืน"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.balance}")  '"คงเหลือ"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.note}")  '"หมายเหตุ"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.ccname}")  '"Cost Center"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dtCore As DataTable = Me.DataSet.Tables(0)
      Dim dtRaw As DataTable = Me.DataSet.Tables(2)
      Dim dtOpenBal As DataTable = Me.DataSet.Tables(3)
      Dim CurrentLciId As String = ""
      Dim CurrentStockId As String = ""
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currOpenIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim tmpBalance As Decimal = 0
      Dim DocRows As DataRow()
      Dim OpenBalRow As DataRow()

      For Each LciRow As DataRow In dtCore.Rows
        Dim CountRow As Integer = 0
        Dim CountOpen As Decimal = 0
        Dim isCheckNOTransaction As Boolean = True
        OpenBalRow = dtOpenBal.Select("lci_id=" & CStr(LciRow("lci_id")))
        DocRows = dtRaw.Select("lci_id=" & CStr(LciRow("lci_id")), "lci_id, docdate")
        For Each Openrow As DataRow In OpenBalRow
          CountOpen = CDec(Openrow("OpenningBalance"))
        Next
        For Each ItemRow As DataRow In DocRows
          CountRow += 1
        Next
        If CInt(Me.Filters(7).Value) = 1 Then
          isCheckNOTransaction = True
        Else
          If CountOpen = 0 AndAlso CountRow = 0 Then
            isCheckNOTransaction = False
          Else
            isCheckNOTransaction = True
          End If
        End If
        If isCheckNOTransaction Then
          If LciRow("lci_id").ToString <> CurrentLciId Then
            tmpBalance = 0
            m_grid.RowCount += 1
            currCostCenterIndex = m_grid.RowCount
            m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
            m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
            m_grid(currCostCenterIndex, 1).CellValue = LciRow("lci_code")
            m_grid(currCostCenterIndex, 2).CellValue = LciRow("lci_name")
            CurrentLciId = LciRow("lci_id").ToString
            CurrentStockId = ""

            m_grid.RowCount += 1
            currOpenIndex = m_grid.RowCount
            m_grid.RowStyles(currOpenIndex).ReadOnly = True
            m_grid(currOpenIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.Openingbalance}") '"ยอดยกมา"
            If OpenBalRow.Length > 0 Then
              If IsNumeric(OpenBalRow(0)("openningbalance")) Then
                m_grid(currOpenIndex, 7).CellValue = Configuration.FormatToString(CDec(OpenBalRow(0)("openningbalance")), DigitConfig.Qty)
                tmpBalance = CDec(OpenBalRow(0)("openningbalance"))
              End If
            Else
              m_grid(currOpenIndex, 7).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
              tmpBalance = 0
            End If
          End If

          For Each ItemRow As DataRow In DocRows
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            '-------------การกำหนดสีต้องเอามาไว้ก่อน
            If IsNumeric(ItemRow("hilight")) Then
              If CInt(ItemRow("hilight")) = 1 Then
                m_grid.RowStyles(currItemIndex).BackColor = Color.OrangeRed
                m_grid.RowStyles(currItemIndex).TextColor = Color.White
              End If
            End If
            '-------------END การกำหนดสีต้องเอามาไว้ก่อน
            m_grid.RowStyles(currItemIndex).ReadOnly = True

            Dim currentIn As Decimal = 0
            Dim currentOut As Decimal = 0

            If Not ItemRow.IsNull("docdate") Then
              m_grid(currItemIndex, 1).CellValue = indent & CDate(ItemRow("docdate")).ToShortDateString
            End If
            If Not ItemRow.IsNull("stock_code") Then
              m_grid(currItemIndex, 2).CellValue = indent & ItemRow("stock_code").ToString
            End If
            If Not ItemRow.IsNull("entity_description") Then
              m_grid(currItemIndex, 3).CellValue = indent & ItemRow("entity_description").ToString
            End If
            If Not ItemRow.IsNull("defaultunitname") Then
              m_grid(currItemIndex, 4).CellValue = indent & ItemRow("defaultunitname").ToString
            End If
            If IsNumeric(ItemRow("receipt")) Then
              m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(ItemRow("receipt")), DigitConfig.Qty)
              currentIn = Configuration.Format(CDec(ItemRow("receipt")), DigitConfig.Qty)
            End If
            If IsNumeric(ItemRow("withdraw")) Then
              m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(ItemRow("withdraw")), DigitConfig.Qty)
              currentOut = Configuration.Format(CDec(ItemRow("withdraw")), DigitConfig.Qty)
            End If

            tmpBalance += (currentIn - currentOut)

            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpBalance, DigitConfig.Qty)

            If Not ItemRow.IsNull("note") Then
              m_grid(currItemIndex, 8).CellValue = indent & ItemRow("note").ToString
            End If
            If Not ItemRow.IsNull("ccname") Then
              m_grid(currItemIndex, 9).CellValue = indent & ItemRow("ccname").ToString
            End If

          Next
        End If
      Next

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptStockCardMat"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptStockCardMat"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptStockCardMat"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptStockCardMat.ListLabel}"
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

      Dim i As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        If IsDBNull(m_grid(rowIndex, 3).CellValue) Or m_grid(rowIndex, 3).CellValue.ToString() = "" Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        Else
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col8"
          dpi.Value = m_grid(rowIndex, 9).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        End If

        i += 1
      Next
      Return dpiColl
    End Function
#End Region

  End Class
End Namespace