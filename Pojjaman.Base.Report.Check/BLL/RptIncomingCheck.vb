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
  Public Class RptIncomingCheck
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
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 3
      lkg.Rows.FrozenCount = 3
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
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
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.BankBranchCode}")  '"รหัสธนาคาร"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.BankBranchName}")  '"ธนาคาร : สาขา"

      'Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.BookNumber}")  '"เลขที่สมุดบัญชี"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.BookName}") '"ชื่อบัญชี"
      tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.BankAccountType}") '"ประเภทสมุดบัญชี"

      'Level 2
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.DocDate}") '"วันที่เอกสาร"
      tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.CheckDueDate}") '"วันที่บนเช็ค"
      tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.CheckPassDate}") '"วันที่เช็คผ่าน"
      tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.DocNumber}") '"เลขที่เอกสาร"
      tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.CheckNumber}")  '"เลขที่เช็ค"
      tr("col5") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.Customer}") '"ลูกค้า"
      tr("col6") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.ReceiveDoc}")  '"เลขที่เอกสารรับชำระ"
      tr("col7") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.ReceiveRefDoc}")  '"เอกสารอ้างอิง"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.Cost}") '"จำนวนเงิน"
      tr("col9") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.Status}") '"สถานะ"

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim sumAmount As Decimal = 0
      Dim sumBankAmt As Decimal = 0
      Dim totalAmount As Decimal = 0
      Dim currAccountCode As String = ":::::::::::::::::::"
      Dim currAccIndex As Integer = -1
      Dim currBankCode As String = ":::::::::::::::::::"
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)

      Dim trBank As TreeRow
      Dim trAcc As TreeRow
      Dim trCheq As TreeRow

      Dim rvCode As String = ""
      Dim rvRefCode As String = ""

      For Each row As DataRow In dt.Rows
        If Not currBankCode.Equals(CStr(row("BankBranchCode"))) Then
          If Not TrBank Is Nothing Then
            If Not SumBankAmt.Equals(0) Then
              TrBank("col8") = Configuration.FormatToString(SumBankAmt, DigitConfig.Price)
              SumBankAmt = 0
            End If
          End If

          TrBank = Me.m_treemanager.Treetable.Childs.Add
          TrBank.Tag = "Font.Bold"
          If Not row.IsNull("BankCode") Then
            trBank("col0") = row("BankCode").ToString
          Else
            trBank("col0") = ""
          End If
          If Not row.IsNull("BankBranchName") Then
            TrBank("col1") = row("BankName").ToString & " : " & row("BankBranchName").ToString
          End If

          If Not row.IsNull("BankBranchCode") Then
          currBankCode = CStr(row("BankBranchCode"))
          Else
            currBankCode = ""
          End If


          TrBank.State = RowExpandState.Expanded
        End If

        If Not TrBank Is Nothing Then
          If Not currAccountCode.Equals(CStr(row("BankACBankCode"))) Then
            If Not TrAcc Is Nothing Then
              If Not SumAmount.Equals(0) Then
                TrAcc("col8") = Configuration.FormatToString(SumAmount, DigitConfig.Price)
                SumAmount = 0
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

          If Not row.IsNull("BankACBankCode") Then
          currAccountCode = CStr(row("BankACBankCode"))
          Else
            currAccountCode = ""
        End If


          trAcc.State = RowExpandState.Expanded
        End If

        If Not trAcc Is Nothing Then
          If row("DocCode").ToString <> currentDocCode Then
            If currentDocCode.Length <> 0 Then
              TrCheq("col6") = indent & indent & rvCode
              trCheq("col7") = indent & indent & rvRefCode
              rvCode = ""
              rvRefCode = ""
            End If

            TrCheq = TrAcc.Childs.Add
            If Not row.IsNull("DocDate") Then
              If IsDate(row("DocDate")) Then
                trCheq("col0") = indent & indent & CDate(row("DocDate")).ToShortDateString
              End If
            End If
            If Not row.IsNull("CheckDueDate") Then
              If IsDate(row("CheckDueDate")) Then
                trCheq("col1") = indent & indent & CDate(row("CheckDueDate")).ToShortDateString
              End If
            End If
            If Not row.IsNull("CheckPassDate") Then
              If IsDate(row("CheckPassDate")) Then
                trCheq("col2") = indent & indent & CDate(row("CheckPassDate")).ToShortDateString
              End If
            End If
            If Not row.IsNull("DocCode") Then
              trCheq("col3") = indent & indent & row("DocCode").ToString
            End If
            If Not row.IsNull("CqCode") Then
              trCheq("col4") = indent & indent & row("CqCode").ToString
            End If
            If Not row.IsNull("SupplierCode") Then
              trCheq("col5") = indent & indent & row("SupplierCode").ToString & ":" & row("SupplierName").ToString
            End If
            If IsNumeric(row("Amount")) Then
              trCheq("col8") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
            End If
            If Not row.IsNull("CheckStatus") Then
              trCheq("col9") = indent & indent & row("CheckStatus").ToString
            End If

            If IsNumeric(row("Amount")) Then
              sumAmount += CDec(row("Amount"))
              sumBankAmt += CDec(row("Amount"))
              totalAmount += CDec(row("Amount"))
            End If
            If Not row.IsNull("DocCode") Then
            currentDocCode = row("DocCode").ToString
            Else
              currentDocCode = ""
            End If

          End If

          If Not row.IsNull("RV") Then
            If row("RV").ToString.Length > 0 Then
              If rvCode.Length > 0 Then
                rvCode &= "," & row("RV").ToString
              Else
                rvCode = row("RV").ToString
              End If
            End If
          End If
          If Not row.IsNull("RVRef") Then
            If row("RVRef").ToString.Length > 0 Then
              If rvRefCode.Length > 0 Then
                rvRefCode &= "," & row("RVRef").ToString
              Else
                rvRefCode = row("RVRef").ToString
              End If
            End If
          End If

        End If

      Next

      trCheq("col6") = indent & indent & rvCode
      trCheq("col7") = indent & indent & rvRefCode

      'Account สุดท้าย
      If Not TrAcc Is Nothing Then
        If Not SumAmount.Equals(0) Then
          TrAcc("col8") = Configuration.FormatToString(SumAmount, DigitConfig.Price)
          SumAmount = 0
        End If
      End If
      'Bank สุดท้าย
      If Not TrBank Is Nothing Then
        If Not SumBankAmt.Equals(0) Then
          TrBank("col8") = Configuration.FormatToString(SumBankAmt, DigitConfig.Price)
          SumBankAmt = 0
        End If
      End If

      TrBank = Me.m_treemanager.Treetable.Childs.Add
      TrBank.Tag = "Font.Bold"
      TrBank("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.Total}") '"รวม"
      TrBank("col8") = Configuration.FormatToString(TotalAmount, DigitConfig.Price)

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

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList

      widths.Add(120)
      widths.Add(200)
      widths.Add(120)
      widths.Add(100)
      widths.Add(100)
      widths.Add(200)
      widths.Add(220)
      widths.Add(220)
      widths.Add(100)
      widths.Add(100)

      For i As Integer = 0 To 9
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
          If i = 8 Then
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
        Return "RptIncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptIncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptIncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptIncomingCheck.ListLabel}"
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
      Return "RptIncomingCheck"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptIncomingCheck"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim fn As Font
      For rowIndex As Integer = 4 To m_grid.RowCount
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

