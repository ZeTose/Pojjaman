Option Explicit On 
Option Strict On
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
  Public Class RptOutgoingCheckEnumerate
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

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 4
      lkg.Rows.FrozenCount = 4
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      'ShowDetailInGrid = CInt(Me.DataSet.Tables(0).Rows(0)("ShowDetail"))
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String
      indent = Space(3)

      'Level 0
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.BankBranchCode}")  '"รหัสธนาคาร"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.BankBranchName}")  '"ธนาคาร : สาขา"

      'Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.BookNumber}")   '"เลขที่สมุดบัญชี"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.BookName}")   '"ชื่อบัญชี"
      tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.BankAccountType}") '"ประเภทสมุดบัญชี"

      'Level 2
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.CheckDueDate}")  '"วันที่บนเช็ค"
      tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.DocDate}")  '"วันที่เอกสาร"
      tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.DocNumber}")  '"เลขที่เอกสาร"
      tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.CheckNumber}")  '"เลขที่เช็ค"
      tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.Supplier}")  '"ผู้ขาย"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.Cost}")   '"จำนวนเงิน"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.PayAmt}")    '"ยอดตัดจ่าย"
      tr("col7") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.Status}")  '"สถานะ"
      tr("col8") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.CheckPassDate}")  '"วันที่เช็คผ่าน"

      'Level 3
      tr = Me.m_treemanager.Treetable.Childs.Add
      'tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.PVDate}")   '"วันที่เอกสารจ่ายชำระ"
      tr("col1") = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.PVCode}")   '"เลขที่เอกสารจ่ายชำระ"
      tr("col2") = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.DocCode}")   '"เลขที่เอกสาร"
      tr("col6") = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.PayAmt}")   '"ยอดตัดจ่าย"
      tr("col8") = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.PVNote}")   '"หมายเหตุ pv"

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      If dt.Rows.Count = 0 Then
        Return
      End If

      'Dim SumAmount As Decimal = 0
      'Dim SumBankAmt As Decimal = 0
      Dim TotalCostAmt As Decimal = 0
      Dim SumBankCostAmt As Decimal = 0
      Dim SumAccountCostAmt As Decimal = 0

      Dim TotalPaidAmt As Decimal = 0
      Dim SumBankPaidAmt As Decimal = 0
      Dim SumAccountPaidAmt As Decimal = 0
      Dim SumDocPaidAmt As Decimal = 0

      Dim currAccountCode As String = ""
      Dim currAccIndex As Integer = -1
      Dim currBankCode As String = ""
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)

      Dim TrBank As TreeRow
      Dim TrAcc As TreeRow
      Dim TrCheq As TreeRow
      Dim TrDoc As TreeRow
      Dim currDocCode As String = ""

      For Each row As DataRow In dt.Rows
        If Not currBankCode.Equals(CStr(row("BankBranchCode"))) Then
          If Not TrBank Is Nothing Then
            If Not SumBankCostAmt.Equals(0) Then
              TrBank("col5") = Configuration.FormatToString(SumBankCostAmt, DigitConfig.Price)
              SumBankCostAmt = 0
            End If
            If Not SumBankPaidAmt.Equals(0) Then
              TrBank("col6") = Configuration.FormatToString(SumBankPaidAmt, DigitConfig.Price)
              SumBankPaidAmt = 0
            End If
          End If

          TrBank = Me.m_treemanager.Treetable.Childs.Add
          TrBank.Tag = "Font.Bold"
          If Not row.IsNull("BankCode") Then
            TrBank("col0") = row("BankCode").ToString
          End If
          If Not row.IsNull("BankBranchName") Then
            TrBank("col1") = row("BankName").ToString & " : " & row("BankBranchName").ToString
          End If

          currBankCode = CStr(row("BankBranchCode"))
          TrBank.State = RowExpandState.Expanded
        End If

        If Not TrBank Is Nothing Then
          If Not currAccountCode.Equals(CStr(row("BankACBankCode"))) Then
            If Not TrAcc Is Nothing Then
              If Not SumAccountCostAmt.Equals(0) Then
                TrAcc("col5") = Configuration.FormatToString(SumAccountCostAmt, DigitConfig.Price)
                SumAccountCostAmt = 0
              End If
              If Not SumAccountPaidAmt.Equals(0) Then
                TrAcc("col6") = Configuration.FormatToString(SumAccountPaidAmt, DigitConfig.Price)
                SumAccountPaidAmt = 0
              End If
            End If

            TrAcc = TrBank.Childs.Add
            TrAcc.Tag = "Font.Bold"
            If Not row.IsNull("BankACBankCode") Then
              TrAcc("col0") = indent & row("BankACBankCode").ToString
            End If
            If Not row.IsNull("BankacctName") Then
              TrAcc("col1") = row("BankacctName").ToString
            End If
            If Not row.IsNull("BankAccountType") Then
              TrAcc("col2") = indent & row("BankAccountType").ToString
            End If
          End If

          currAccountCode = CStr(row("BankACBankCode"))
          TrAcc.State = RowExpandState.Expanded
        End If

        If Not TrAcc Is Nothing Then
          If Not currDocCode.Equals(CStr(row("DocCode"))) Then
            If Not TrCheq Is Nothing Then
              If Not SumDocPaidAmt.Equals(0) Then
                TrCheq("col6") = Configuration.FormatToString(SumDocPaidAmt, DigitConfig.Price)
                SumDocPaidAmt = 0
              End If
            End If

            TrCheq = TrAcc.Childs.Add
            If IsDate(row("CheckDueDate")) Then
              TrCheq("col0") = indent & indent & CDate(row("CheckDueDate")).ToShortDateString
            End If
            If IsDate(row("DocDate")) Then
              TrCheq("col1") = CDate(row("DocDate")).ToShortDateString
            End If
            If Not row.IsNull("DocCode") Then
              TrCheq("col2") = indent & indent & row("DocCode").ToString
            End If
            If Not row.IsNull("CqCode") Then
              TrCheq("col3") = indent & indent & row("CqCode").ToString
            End If
            If Not row.IsNull("SupplierCode") Then
              TrCheq("col4") = indent & indent & row("SupplierCode").ToString & ":" & row("SupplierName").ToString
            End If
            If IsNumeric(row("Amount")) Then
              TrCheq("col5") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
              SumBankCostAmt += CDec(row("Amount"))
              SumAccountCostAmt += CDec(row("Amount"))
              TotalCostAmt += CDec(row("Amount"))
            End If
            If Not row.IsNull("CheckStatus") Then
              TrCheq("col7") = indent & indent & row("CheckStatus").ToString
            End If
            If Not row.IsNull("CheckPassDate") Then
              TrCheq("col8") = indent & indent & CDate(row("CheckPassDate")).ToShortDateString
            End If

            currDocCode = CStr(row("DocCode"))
            TrCheq.State = RowExpandState.Expanded
          End If

          If Not TrCheq Is Nothing Then
            If Not row.IsNull("payment_code") AndAlso Not row.IsNull("paymenti_amt") Then
              TrDoc = TrCheq.Childs.Add

              If Not row.IsNull("payment_code") Then
                TrDoc("col1") = row("payment_code").ToString
              End If
              If Not row.IsNull("payment_refdoccode") Then
                TrDoc("col2") = indent & indent & indent & row("payment_refdoccode").ToString
              End If
              If IsNumeric(row("paymenti_amt")) Then
                TrDoc("col6") = indent & indent & indent & Configuration.FormatToString(CDec(row("paymenti_amt")), DigitConfig.Price)
                SumBankPaidAmt += CDec(row("paymenti_amt"))
                SumAccountPaidAmt += CDec(row("paymenti_amt"))
                SumDocPaidAmt += CDec(row("paymenti_amt"))
                TotalPaidAmt += CDec(row("paymenti_amt"))
              End If
              If Not row.IsNull("note") Then
                TrDoc("col8") = indent & indent & indent & row("note").ToString
              End If
            End If
          End If
        End If
      Next

      'Bank สุดท้าย
      If Not TrBank Is Nothing Then
        If Not SumBankCostAmt.Equals(0) Then
          TrBank("col5") = Configuration.FormatToString(SumBankCostAmt, DigitConfig.Price)
        End If
        If Not SumBankPaidAmt.Equals(0) Then
          TrBank("col6") = Configuration.FormatToString(SumBankPaidAmt, DigitConfig.Price)
        End If
      End If
      'สำหรับ Accout สุดท้าย
      If Not TrAcc Is Nothing Then
        If Not SumAccountCostAmt.Equals(0) Then
          TrAcc("col5") = Configuration.FormatToString(SumAccountCostAmt, DigitConfig.Price)
        End If
        If Not SumAccountPaidAmt.Equals(0) Then
          TrAcc("col6") = Configuration.FormatToString(SumAccountPaidAmt, DigitConfig.Price)
        End If
      End If
      'สำหรับ Cheqe ใบสุดท้าย
      If Not TrCheq Is Nothing Then
        If Not SumDocPaidAmt.Equals(0) Then
          TrCheq("col6") = Configuration.FormatToString(SumDocPaidAmt, DigitConfig.Price)
        End If
      End If

      TrBank = Me.m_treemanager.Treetable.Childs.Add
      TrBank.Tag = "Font.Bold"
      TrBank("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Total}") '"รวม"
      TrBank("col5") = Configuration.FormatToString(TotalCostAmt, DigitConfig.Price)
      TrBank("col6") = Configuration.FormatToString(TotalPaidAmt, DigitConfig.Price)

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

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList

      widths.Add(120)
      widths.Add(200)
      widths.Add(120)
      widths.Add(120)
      widths.Add(150)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)
      widths.Add(200)

      For i As Integer = 0 To 8
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
          cs.Alignment = HorizontalAlignment.Left
          cs.DataAlignment = HorizontalAlignment.Left
          cs.Format = "s"
          If i = 5 OrElse i = 6 Then
            cs.Alignment = HorizontalAlignment.Right
            cs.DataAlignment = HorizontalAlignment.Right
            cs.Format = "d"
          End If
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
        Return "RptOutgoingCheckEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptOutgoingCheckEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptOutgoingCheckEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerate.ListLabel}"
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
      Return "RptOutgoingCheckEnumerate"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptOutgoingCheckEnumerate"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim fn As Font
      For rowIndex As Integer = 5 To m_grid.RowCount

        If Not CType(Me.m_treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

        For colIndex As Integer = 0 To m_grid.ColCount - 1
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

