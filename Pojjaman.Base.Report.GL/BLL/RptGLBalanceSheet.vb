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
  Public Class RptGLBalanceSheet
    Inherits Report

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_treecollection As TreeBaseEntityCollection
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
      Dim indent As String = Space(5)
      ' Level 1.
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = "ÃËÑÊºÑ­ªÕ"
      tr("col1") = "ª×èÍºÑ­ªÕ"
      tr("col2") = "ÂÍ´Â¡ÁÒ"
      tr("col4") = "ÂÍ´»ÃÐ¨Ó§Ç´"
      tr("col6") = "ÂÍ´ÊÐÊÁ"

      ' Level 2.
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col2") = "à´ºÔµ"
      tr("col3") = "à¤Ã´Ôµ"
      tr("col4") = "à´ºÔµ"
      tr("col5") = "à¤Ã´Ôµ"
      tr("col6") = "à´ºÔµ"
      tr("col7") = "à¤Ã´Ôµ"
    End Sub
    Private Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dsh As New DataSetHelper
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim ShowSumEachAcct As Boolean = CBool(Me.DataSet.Tables(2).Rows(0).Item("ShowSumEachAcct"))
      Dim ComputeDrCr As Boolean = CBool(Me.DataSet.Tables(3).Rows(0).Item("ComputeDrCr"))
      Dim currentAccountCode As String = ""
      Dim currentDoc As String = ""
      Dim currentLine As String = ""

      Dim accountTr As TreeRow
      Dim docTr As TreeRow
      Dim totalBalance As Decimal

      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        Dim rowTag As Integer = CInt(row("acct_id"))
        Dim rowCode As String = CStr(row("acct_code"))
        Dim rowName As String = CStr(row("acct_name"))
        Dim rowLevel As Integer = CInt(row("acct_level"))
        Dim parentNodes As ITreeParent
        If IsDBNull(row("acct_parid")) OrElse CInt(row("acct_parid")) = CInt(row("acct_id")) Then
          parentNodes = Me.m_treemanager.Treetable
        Else
          Dim parnode As TreeRow = SearchTag(CInt(row("acct_parid")))
          If parnode Is Nothing Then
            parentNodes = Me.m_treemanager.Treetable
          Else
            parentNodes = parnode
          End If
        End If
        If Me.DataSet.Tables.Count > 1 Then
          Dim b4debit As Decimal = 0
          Dim b4credit As Decimal = 0
          Dim debit As Decimal = 0
          Dim credit As Decimal = 0
          Dim afterdebit As Decimal = 0
          Dim aftercredit As Decimal = 0
          For Each myRow As DataRow In Me.DataSet.Tables(1).Select("acct_id = " & CInt(row("acct_id")))
            If Not myRow.IsNull("b4debit") Then b4debit += CDec(myRow("b4debit"))
            If Not myRow.IsNull("b4credit") Then b4credit += CDec(myRow("b4credit"))

            If Not myRow.IsNull("debit") Then debit += CDec(myRow("debit"))
            If Not myRow.IsNull("credit") Then credit += CDec(myRow("credit"))

            If Not myRow.IsNull("afterdebit") Then afterdebit += CDec(myRow("afterdebit"))
            If Not myRow.IsNull("aftercredit") Then aftercredit += CDec(myRow("aftercredit"))
          Next

          Dim theRow As TreeRow = parentNodes.Childs.Add
          theRow("col0") = rowCode
          theRow("col1") = Space(rowLevel * 3) & rowName

          theRow("acct_id") = rowTag
          theRow("acct_parid") = row("acct_parid")
          theRow.Tag = rowTag

          Dim debitString As String = ""
          Dim creditString As String = ""
          If ComputeDrCr Then
            If b4debit > b4credit Then
              debitString = Configuration.FormatToString(b4debit - b4credit, DigitConfig.Price)
            ElseIf b4credit > b4debit Then
              creditString = Configuration.FormatToString(b4credit - b4debit, DigitConfig.Price)
            End If
          Else
            debitString = CStr(IIf(b4debit > 0, Configuration.FormatToString(b4debit, DigitConfig.Price), ""))
            creditString = CStr(IIf(b4credit > 0, Configuration.FormatToString(b4credit, DigitConfig.Price), ""))
          End If
          theRow("col2") = debitString
          theRow("col3") = creditString

          debitString = ""
          creditString = ""
          If ComputeDrCr Then
            If debit > credit Then
              debitString = Configuration.FormatToString(debit - credit, DigitConfig.Price)
            ElseIf credit > debit Then
              creditString = Configuration.FormatToString(credit - debit, DigitConfig.Price)
            End If
          Else
            debitString = CStr(IIf(debit > 0, Configuration.FormatToString(debit, DigitConfig.Price), ""))
            creditString = CStr(IIf(credit > 0, Configuration.FormatToString(credit, DigitConfig.Price), ""))
          End If
          theRow("col4") = debitString
          theRow("col5") = creditString

          debitString = ""
          creditString = ""
          If ComputeDrCr Then
            If afterdebit > aftercredit Then
              debitString = Configuration.FormatToString(afterdebit - aftercredit, DigitConfig.Price)
            ElseIf aftercredit > afterdebit Then
              creditString = Configuration.FormatToString(aftercredit - afterdebit, DigitConfig.Price)
            End If
          Else
            debitString = CStr(IIf(afterdebit > 0, Configuration.FormatToString(afterdebit, DigitConfig.Price), ""))
            creditString = CStr(IIf(aftercredit > 0, Configuration.FormatToString(aftercredit, DigitConfig.Price), ""))
          End If
          theRow("col6") = debitString
          theRow("col7") = creditString
          theRow.EnsureVisible()
        End If
      Next

      ' Summary Zone
      For Each row As DataRow In dt.Rows
        Dim parnode As TreeRow = SearchTag(CInt(row("acct_id")))
        If Not parnode Is Nothing AndAlso parnode.Childs.Count > 0 AndAlso (ShowSumEachAcct OrElse CInt(row("acct_id")) = 0) Then
          Dim b4debit As Decimal = 0
          Dim b4credit As Decimal = 0
          Dim debit As Decimal = 0
          Dim credit As Decimal = 0
          Dim afterdebit As Decimal = 0
          Dim aftercredit As Decimal = 0

          Dim theRow As TreeRow = parnode.Childs.Add
          therow("col1") = "ÃÇÁÂÍ´:" & Trim(CStr(parnode("col1")))

          b4debit = SumChilds(b4debit, parnode, "col2")
          b4credit = SumChilds(b4credit, parnode, "col3")
          theRow("col2") = Configuration.FormatToString(b4debit, DigitConfig.Price)
          theRow("col3") = Configuration.FormatToString(b4credit, DigitConfig.Price)

          debit = SumChilds(debit, parnode, "col4")
          credit = SumChilds(credit, parnode, "col5")
          theRow("col4") = Configuration.FormatToString(debit, DigitConfig.Price)
          theRow("col5") = Configuration.FormatToString(credit, DigitConfig.Price)

          afterdebit = SumChilds(afterdebit, parnode, "col6")
          aftercredit = SumChilds(aftercredit, parnode, "col7")
          theRow("col6") = Configuration.FormatToString(afterdebit, DigitConfig.Price)
          theRow("col7") = Configuration.FormatToString(aftercredit, DigitConfig.Price)

          therow.Tag = "summary"
        End If
      Next
      Me.m_treemanager.Treetable.AcceptChanges()
    End Sub
    Private Function SumChilds(ByRef result As Decimal, ByVal parent As TreeRow, ByVal columnName As String) As Decimal
      If parent.Childs.Count > 0 Then
        For Each child As TreeRow In parent.Childs
          If IsNumeric(child(columnName)) Then
            result += Configuration.Format(CDec(child(columnName)), DigitConfig.Price)
          End If
          If child.Childs.Count > 0 Then SumChilds(result, child, columnName)
        Next
      End If
      Return result
    End Function
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
      myDatatable.Columns.Add(New DataColumn("IsSummary", GetType(Boolean)))

      myDatatable.Columns.Add(New DataColumn("acct_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("acct_parid", GetType(Integer)))
      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      widths.Add(100)
      widths.Add(250)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      For i As Integer = 0 To 7
        If i = 1 Then
          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "d"
          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          Select Case i
            Case 0, 1
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
            Case Else
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
          End Select
          cs.ReadOnly = True
          cs.Format = "d"
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
        Return "RptGLBalanceSheet"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLBalanceSheet.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptGLBalanceSheet"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptGLBalanceSheet"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLBalanceSheet.ListLabel}"
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
      For Each itemRow As TreeRow In Me.Treemanager.Treetable.Rows
        If itemRow.Index > 1 Then
          'ÃËÑÊ¼Ñ§ºÑ­ªÕ
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          'If itemRow.Level = 0 Then
          '    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col0")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          dpiColl.Add(dpi)

          'ª×èÍ¼Ñ§ºÑ­ªÕ
          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col1")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          dpiColl.Add(dpi)

          'à´ºÔµ ÂÍ´Â¡ÁÒ
          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          'If itemRow.Level = 0 Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col2")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'à¤Ã´Ôµ ÂÍ´Â¡ÁÒ
          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col3")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'à´ºÔµ ÂÍ´»ÃÐ¨Ó§Ç´
          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col4")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'à¤Ã´Ôµ ÂÍ´»ÃÐ¨Ó§Ç´
          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col5")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'à´ºÔµ ÂÍ´ÊÐÊÁ
          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col6")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'à¤Ã´Ôµ ÂÍ´ÊÐÊÁ
          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          'If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
          '  dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'End If
          dpi.Value = itemRow("col7")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Level = itemRow.Level
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

