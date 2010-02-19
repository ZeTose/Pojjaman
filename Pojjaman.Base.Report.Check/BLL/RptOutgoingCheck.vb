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
  Public Class RptOutgoingCheck
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
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.BankBranchCode}")  '"รหัสธนาคาร"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.BankBranchName}")  '"ธนาคาร : สาขา"

      'Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.BookNumber}")  '"เลขที่สมุดบัญชี"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.BookName}") '"ชื่อบัญชี"
      tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.BankAccountType}") '"ประเภทสมุดบัญชี"

      'Level 2
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.DocDate}") '"วันที่เอกสาร"
      tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.CheckDueDate}") '"วันที่บนเช็ค"
      tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.CheckPassDate}") '"วันที่เช็คผ่าน"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.DocNumber}") '"เลขที่เอกสาร"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.CheckNumber}")  '"เลขที่เช็ค"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Supplier}") '"ผู้ขาย"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.PV}")  '"PV ใบสำคัญ"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.GL}")  '"GL"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.PVRef}")  '"เอกสารอ้างอิง"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Cost}") '"จำนวนเงินบนเช็ค"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Pay}") '"จำนวนเงินที่จ่ายไป"
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Amt}") '"จำนวนเงินคงเหลือ"
      tr("col12") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Status}") '"สถานะ"
      tr("col13") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.cc}") '"รหัส Cost center"
      tr("col14") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.CheckRecipient}") '"ผู้รับเช็ค"
      tr("col15") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.CheckNote}") '"หมายเหตุ"
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim SumAmount As Decimal = 0
      Dim SumBankAmt As Decimal = 0
      Dim SumPay As Decimal = 0
      Dim SumBankPay As Decimal = 0
      Dim SumRemain As Decimal = 0
      Dim SumBankRemain As Decimal = 0
      Dim TotalAmount As Decimal = 0
      Dim TotalPay As Decimal = 0
      Dim TotalRemain As Decimal = 0
      Dim currAccountCode As String = ""
      Dim currAccIndex As Integer = -1
      Dim currBankCode As String = ""
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)

      Dim TrBank As TreeRow = Nothing
      Dim TrAcc As TreeRow = Nothing
      Dim TrCheq As TreeRow = Nothing

      'Dim PVCode As String = ""
      'Dim PVRefCode As String = ""

      For Each row As DataRow In dt.Rows
        If Not currBankCode.Equals(CStr(row("BankBranchCode"))) Then
          If Not TrBank Is Nothing Then
            If Not SumBankAmt.Equals(0) Then
              TrBank("col9") = Configuration.FormatToString(SumBankAmt, DigitConfig.Price)
              TrBank("col10") = Configuration.FormatToString(SumBankPay, DigitConfig.Price)
              TrBank("col11") = Configuration.FormatToString(SumBankRemain, DigitConfig.Price)
              SumBankAmt = 0
              SumBankPay = 0
              SumBankRemain = 0
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
              If Not SumAmount.Equals(0) Then
                TrAcc("col9") = Configuration.FormatToString(SumAmount, DigitConfig.Price)
                TrAcc("col10") = Configuration.FormatToString(SumPay, DigitConfig.Price)
                TrAcc("col11") = Configuration.FormatToString(SumRemain, DigitConfig.Price)
                SumAmount = 0
                SumPay = 0
                SumRemain = 0
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
          If row("DocCode").ToString <> currentDocCode Then
            'If currentDocCode.Length <> 0 Then
            '    TrCheq("col6") = indent & indent & PVCode
            '    TrCheq("col8") = indent & indent & PVRefCode
            '    PVCode = ""
            '    PVRefCode = ""
            'End If

            TrCheq = TrAcc.Childs.Add
            If Not row.IsNull("DocDate") Then
              If IsDate(row("DocDate")) Then
                TrCheq("col0") = indent & indent & CDate(row("DocDate")).ToShortDateString
              End If
            End If
            If Not row.IsNull("CheckDueDate") Then
              If IsDate(row("CheckDueDate")) Then
                TrCheq("col1") = indent & indent & CDate(row("CheckDueDate")).ToShortDateString
              Else
                TrCheq("col1") = indent & indent & ""
              End If

            End If
            If Not row.IsNull("CheckPassDate") Then
              If IsDate(row("CheckPassDate")) Then
                TrCheq("col2") = indent & indent & CDate(row("CheckPassDate")).ToShortDateString
              End If
            End If
            If Not row.IsNull("DocCode") Then
              TrCheq("col3") = row("DocCode").ToString
            End If
            If Not row.IsNull("CqCode") Then
              TrCheq("col4") = indent & indent & row("CqCode").ToString
            End If
            If Not row.IsNull("SupplierCode") Then
              TrCheq("col5") = row("SupplierCode").ToString & ":" & row("SupplierName").ToString
            End If
            If Not row.IsNull("PV") Then
              TrCheq("col6") = row("PV").ToString
            End If
            If Not row.IsNull("PVRef") Then
              TrCheq("col7") = row("GL").ToString
            End If
            If Not row.IsNull("GL") Then
              TrCheq("col8") = row("PVRef").ToString
            End If
            If IsNumeric(row("Amount")) Then
              TrCheq("col9") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
            End If
            If IsNumeric(row("Pay")) Then
              TrCheq("col10") = Configuration.FormatToString(CDec(row("Pay")), DigitConfig.Price)
            End If
            If IsNumeric(row("Remain")) Then
              TrCheq("col11") = Configuration.FormatToString(CDec(row("Remain")), DigitConfig.Price)
            End If
            If Not row.IsNull("CheckStatus") Then
              TrCheq("col12") = indent & indent & row("CheckStatus").ToString
            End If
            If Not row.IsNull("cc_code") Then
              TrCheq("col13") = row("cc_code").ToString
            End If
            If Not row.IsNull("CqRecipient") Then
              TrCheq("col14") = row("CqRecipient").ToString
            End If
            If Not row.IsNull("CqNote") Then
              TrCheq("col15") = row("CqNote").ToString
            End If
            If IsNumeric(row("Amount")) Then
              SumAmount += CDec(row("Amount"))
              SumBankAmt += CDec(row("Amount"))
              TotalAmount += CDec(row("Amount"))
            End If
            If IsNumeric(row("Pay")) Then
              SumPay += CDec(row("Pay"))
              SumBankPay += CDec(row("Pay"))
              TotalPay += CDec(row("Pay"))
            End If
            If IsNumeric(row("Remain")) Then
              SumRemain += CDec(row("Remain"))
              SumBankRemain += CDec(row("Remain"))
              TotalRemain += CDec(row("Remain"))
            End If

            currentDocCode = row("DocCode").ToString
          End If

          'If Not row.IsNull("PV") Then
          '    If row("PV").ToString.Length > 0 Then
          '        If PVCode.Length > 0 Then
          '            PVCode &= "," & row("PV").ToString
          '        Else
          '            PVCode = row("PV").ToString
          '        End If
          '    End If
          'End If
          'If Not row.IsNull("PVRef") Then
          '    If row("PVRef").ToString.Length > 0 Then
          '        If PVRefCode.Length > 0 Then
          '            PVRefCode &= "," & row("PVRef").ToString
          '        Else
          '            PVRefCode = row("PVRef").ToString
          '        End If
          '    End If
          'End If

        End If

      Next

      ''PV Ref PV สุดท้าย
      'If Not TrCheq Is Nothing Then
      '    TrCheq("col6") = indent & indent & PVCode
      '    TrCheq("col8") = indent & indent & PVRefCode
      'End If

      'Account สุดท้าย
      If Not TrAcc Is Nothing Then
        If Not SumAmount.Equals(0) Then
          TrAcc("col9") = Configuration.FormatToString(SumAmount, DigitConfig.Price)
          SumAmount = 0
        End If
        If Not SumPay.Equals(0) Then
          TrAcc("col10") = Configuration.FormatToString(SumPay, DigitConfig.Price)
          SumPay = 0
        End If
        If Not SumRemain.Equals(0) Then
          TrAcc("col11") = Configuration.FormatToString(SumRemain, DigitConfig.Price)
          SumRemain = 0
        End If
      End If
      'Bank สุดท้าย
      If Not TrBank Is Nothing Then
        If Not SumBankAmt.Equals(0) Then
          TrBank("col9") = Configuration.FormatToString(SumBankAmt, DigitConfig.Price)
          SumBankAmt = 0
        End If
        If Not SumBankPay.Equals(0) Then
          TrBank("col10") = Configuration.FormatToString(SumBankPay, DigitConfig.Price)
          SumBankPay = 0
        End If
        If Not SumBankRemain.Equals(0) Then
          TrBank("col11") = Configuration.FormatToString(SumBankRemain, DigitConfig.Price)
          SumBankRemain = 0
        End If
      End If

      TrBank = Me.m_treemanager.Treetable.Childs.Add
      TrBank.Tag = "Font.Bold"
      TrBank("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.Total}") '"รวม"
      TrBank("col9") = Configuration.FormatToString(TotalAmount, DigitConfig.Price)
      TrBank("col10") = Configuration.FormatToString(TotalPay, DigitConfig.Price)
      TrBank("col11") = Configuration.FormatToString(TotalRemain, DigitConfig.Price)

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
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList

      widths.Add(120) '0
      widths.Add(200) '1
      widths.Add(120) '2
      widths.Add(100) '3
      widths.Add(100) '4
      widths.Add(200) '5
      widths.Add(180) '6
      widths.Add(0) '7 GLCode จะซ้ำเลยเอาออก
      widths.Add(180) '8
      widths.Add(100) '9
      widths.Add(120) '10
      widths.Add(120) '11
      widths.Add(120) '12
      widths.Add(220) '13
      widths.Add(220) '14
      widths.Add(220) '15
      For i As Integer = 0 To 15
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
          If i >= 9 And i <= 11 Then
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
        Return "RptOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheck.ListLabel}"
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
      Return "RptOutgoingCheck"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptOutgoingCheck"
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

