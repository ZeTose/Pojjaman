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
  Public Class RptMatTransfer
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
      Dim indent As String = Space(3)
      m_grid.RowCount = 1
      m_grid.ColCount = 9

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 0
      m_grid.ColWidths(9) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DocDate}") '"วันที่เอกสาร"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DocCode}") '"เลขที่เอกสาร"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.FromCCname}") '"Cost Center ให้เบิก"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.ToCCname}") '"Cost Center ขอเบิก"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatTransfer.ReceviedQty}") '"ยอดรวมจำนวนรับแล้ว"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatTransfer.WaitingQty}") '"ยอดรวมจำนวนยังไม่ได้รับ"
      'm_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.SumCostUnit}") '"ยอดรวมต้นทุน/หน่วย"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.SumEntityamt}") '"ยอดรวมจำนวนเงิน"

      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityCode}")  '"รหัสวัสดุ"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityName}")  '"ชื่อวัสดุ"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityUnitName}")  '"หน่วย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatTransfer.ReceviedQty}")  '"จำนวน"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatTransfer.WaitingQty}")  '"จำนวน"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.UnitCost}")  '"เฉลี่ยต้นทุน/หน่วย"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.Entityamt}")  '"จำนวนเงิน"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentDocCode As String = ""
      Dim currentEntityCode As String = ""
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumReceivedQty As Decimal
      Dim sumWaitingQty As Decimal
      'Dim sumCostUnit As Decimal = 0
      Dim sumEntityamt As Decimal = 0
      Dim countReceivedDoc As Decimal = 0
      Dim countWaitingDoc As Decimal = 0
      Dim sumAmount As Decimal = 0

      Dim ReceiptComment As String = ""
      Dim ReceiptPerson As String = ""
      Dim ReceiptDate As String = ""

      Dim isReceived As Boolean = False

      For Each row As DataRow In dt.Rows

        If row("DocCode").ToString <> currentDocCode Then
          If m_grid.RowCount > 1 AndAlso ReceiptComment.Length > 0 Then
            m_grid.RowCount += 1
            currCostCenterIndex = m_grid.RowCount
            If isReceived Then
              m_grid(currCostCenterIndex, 2).CellValue = "รับแล้วโดย"
              m_grid(currCostCenterIndex, 3).CellValue = ReceiptPerson + " " + ReceiptDate
              m_grid(currCostCenterIndex, 4).CellValue = ReceiptComment
            End If
            m_grid(currCostCenterIndex, 3).CellValue = ReceiptPerson + " " + ReceiptDate
            m_grid(currCostCenterIndex, 4).CellValue = ReceiptComment
          End If

          m_grid.RowCount += 1
          currCostCenterIndex = m_grid.RowCount

          If Not row.IsNull("ApproveType") AndAlso row("ApproveType").ToString = "1" Then
            isReceived = True
          End If

          If Not row.IsNull("ApproveType") AndAlso row("ApproveType").ToString = "-1" Then
            isReceived = False
          End If

          If row.IsNull("ApproveType") Then
            isReceived = False
          End If

          If isReceived Then
            m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
          Else
            m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(250, 250, 100)
          End If

          m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
          m_grid.RowStyles(currCostCenterIndex).ReadOnly = True

          m_grid(currCostCenterIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
          m_grid(currCostCenterIndex, 2).CellValue = row("DocCode")
          m_grid(currCostCenterIndex, 3).CellValue = row("FromCCname")
          m_grid(currCostCenterIndex, 4).CellValue = row("ToCCname")
          m_grid(currCostCenterIndex, 1).Tag = "Groupping"

          '----- เก็บ Comment----
          If Not row.IsNull("Comment") Then
            ReceiptComment = row("Comment").ToString
          Else
            ReceiptComment = ""
          End If
          '----- เก็บวันที่และเวลา ----
          If Not row.IsNull("lastEditDate") Then
            ReceiptDate = row("lastEditDate").ToString
          ElseIf row.IsNull("lastEditDate") And Not row.IsNull("originDate") Then
            ReceiptDate = row("originDate").ToString
          Else
            ReceiptDate = ""
          End If
          '---------เก็บชื่อคน-------------
          If Not row.IsNull("nameLastEditor") Then
            ReceiptPerson = row("nameLastEditor").ToString
          ElseIf row.IsNull("nameLastEditor") And Not row.IsNull("nameOriginator") Then
            ReceiptPerson = row("nameOriginator").ToString
          Else
            ReceiptPerson = ""
          End If
          '-----------------------
          currentDocCode = row("DocCode").ToString
          currentEntityCode = ""
          sumReceivedQty = 0
          sumWaitingQty = 0
          'sumCostUnit = 0
          sumEntityamt = 0
          countReceivedDoc += 1
        End If
        'If row("EntityCode").ToString <> currentEntityCode Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True

        m_grid(currItemIndex, 1).CellValue = DBNull.Value
        If Not row.IsNull("EntityCode") Then
          m_grid(currItemIndex, 2).CellValue = indent & row("EntityCode").ToString
        End If
        If Not row.IsNull("EntityName") Then
          m_grid(currItemIndex, 3).CellValue = indent & row("EntityName").ToString
        End If
        m_grid(currItemIndex, 4).CellValue = DBNull.Value
        If Not row.IsNull("EntityUnitName") Then
          m_grid(currItemIndex, 5).CellValue = indent & row("EntityUnitName").ToString
        End If

        If IsNumeric(row("Qty")) Then
          If isReceived Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
            sumReceivedQty += CDec(row("Qty"))
            countReceivedDoc += 1

          Else
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
            sumWaitingQty += CDec(row("Qty"))
            countWaitingDoc += 1

          End If

        End If
        If IsNumeric(row("UnitCost")) Then
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("UnitCost")), DigitConfig.Price)
          'sumCostUnit += CDec(row("UnitCost"))
        End If
        If IsNumeric(row("Amount")) Then
          m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          sumEntityamt += CDec(row("Amount"))
          sumAmount += CDec(row("Amount"))
        End If
        'currentEntityCode = row("EntityCode").ToString
        'End If
        If sumReceivedQty <> 0 Then
          m_grid(currCostCenterIndex, 6).CellValue = Configuration.FormatToString(sumReceivedQty, DigitConfig.Price)
        End If
        If sumWaitingQty <> 0 Then
          m_grid(currCostCenterIndex, 7).CellValue = Configuration.FormatToString(sumWaitingQty, DigitConfig.Price)
        End If
        'If sumCostUnit <> 0 Then
        '  m_grid(currCostCenterIndex, 7).CellValue = Configuration.FormatToString(sumCostUnit, DigitConfig.Price)
        'End If
        If sumEntityamt <> 0 Then
          m_grid(currCostCenterIndex, 9).CellValue = Configuration.FormatToString(sumEntityamt, DigitConfig.Price)
        End If
      Next

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 1).CellValue = DBNull.Value
      m_grid(currItemIndex, 5).CellValue = "รวมทั้งสิ้น"
      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(countReceivedDoc, DigitConfig.Int) & " รายการ"
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(countWaitingDoc, DigitConfig.Int) & " รายการ"
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(sumAmount, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptMatTransfer"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatTransfer.ListLabel}"
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
        Select Case fixDpi.Mapping.ToLower
          Case "month", "year", "type"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "fromccstart", "fromccend"
            dpiColl.Add(fixDpi)
          Case "toccstart", "toccend"
            dpiColl.Add(fixDpi)
        End Select
      Next
      If Not Me.Filters(2).Value Is DBNull.Value Then
        'FromCCStart
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCStart"
        dpi.Value = CStr(Me.Filters(2).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(3).Value Is DBNull.Value Then
        'FromCCEnd
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCEnd"
        dpi.Value = CStr(Me.Filters(3).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(4).Value Is DBNull.Value Then
        'ToCCStart
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCStart"
        dpi.Value = CStr(Me.Filters(4).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(5).Value Is DBNull.Value Then
        'ToCCEnd
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCEnd"
        dpi.Value = CStr(Me.Filters(5).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      Dim countDoc As Decimal = 0
      Dim sumAmount As Decimal = 0
      For rowIndex As Integer = 2 To m_grid.RowCount - 1
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.DateTime"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          countDoc += 1
          If IsNumeric(m_grid(rowIndex, 8).CellValue) Then
            sumAmount += CDec(m_grid(rowIndex, 8).CellValue)
          End If
        Else
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

        End If
        n += 1
      Next

      'SumCol5
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol5"
      dpi.Value = Configuration.FormatToString(countDoc, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol7
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol7"
      dpi.Value = Configuration.FormatToString(sumAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

