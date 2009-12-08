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
    Public Class RptGLPaper
        Inherits Report

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
            tr("col0") = "√À— º—ß∫—≠™’"
            tr("col1") = "™◊ËÕº—ß∫—≠™’"
            tr("col2") = "ß∫∑¥≈Õß"
            tr("col4") = "ß∫°”‰√¢“¥∑ÿπ"
            tr("col6") = "ß∫¥ÿ≈"

            ' Level 2.
            tr = Me.m_treemanager.Treetable.Childs.Add
            tr("col2") = "‡¥∫‘µ"
            tr("col3") = "‡§√¥‘µ"
            tr("col4") = "‡¥∫‘µ"
            tr("col5") = "‡§√¥‘µ"
            tr("col6") = "‡¥∫‘µ"
            tr("col7") = "‡§√¥‘µ"
        End Sub
        Private Sub PopulateData()
            If Me.m_treemanager Is Nothing Then
                Return
            End If
            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)
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

                Dim b4debit As Decimal = 0
                Dim b4credit As Decimal = 0
                Dim debit As Decimal = 0
                Dim credit As Decimal = 0
                Dim afterdebit As Decimal = 0
                Dim aftercredit As Decimal = 0
                For Each myRow As DataRow In Me.DataSet.Tables(0).Select("acct_id = " & CInt(row("acct_id")))
                    If Not myRow.IsNull("debit_glsheetamt") Then b4debit += CDec(myRow("debit_glsheetamt"))
                    If Not myRow.IsNull("credit_glsheetamt") Then b4credit += CDec(myRow("credit_glsheetamt"))

                    If Not myRow.IsNull("debit_glbudgetamt") Then debit += CDec(myRow("debit_glbudgetamt"))
                    If Not myRow.IsNull("credit_glbudgetamt") Then credit += CDec(myRow("credit_glbudgetamt"))

                    If Not myRow.IsNull("debit_glbalanceamt") Then afterdebit += CDec(myRow("debit_glbalanceamt"))
                    If Not myRow.IsNull("credit_glbalanceamt") Then aftercredit += CDec(myRow("credit_glbalanceamt"))
                Next

                Dim theRow As TreeRow = parentNodes.Childs.Add
                theRow("col0") = rowCode
                theRow("col1") = Space(rowLevel * 3) & rowName

                theRow("acct_id") = rowTag
                theRow("acct_parid") = row("acct_parid")
                theRow.Tag = rowTag

                Dim debitString As String = ""
                Dim creditString As String = ""
                If b4debit > b4credit Then
                    debitString = Configuration.FormatToString(b4debit - b4credit, DigitConfig.Price)
                ElseIf b4credit > b4debit Then
                    creditString = Configuration.FormatToString(b4credit - b4debit, DigitConfig.Price)
                End If
                theRow("col2") = debitString
                theRow("col3") = creditString

                debitString = ""
                creditString = ""
                If debit > credit Then
                    debitString = Configuration.FormatToString(debit - credit, DigitConfig.Price)
                ElseIf credit > debit Then
                    creditString = Configuration.FormatToString(credit - debit, DigitConfig.Price)
                End If
                theRow("col4") = debitString
                theRow("col5") = creditString

                debitString = ""
                creditString = ""
                If afterdebit > aftercredit Then
                    debitString = Configuration.FormatToString(afterdebit - aftercredit, DigitConfig.Price)
                ElseIf aftercredit > afterdebit Then
                    creditString = Configuration.FormatToString(aftercredit - afterdebit, DigitConfig.Price)
                End If
                theRow("col6") = debitString
                theRow("col7") = creditString

                theRow.Tag = rowTag

                theRow.EnsureVisible()

                '' ß∫∑¥≈Õß
                'Dim debit_glsheetamt As Decimal = 0
                'Dim credit_glsheetamt As Decimal = 0
                'If Not row.IsNull("debit_glsheetamt") Then debit_glsheetamt = CDec(row("debit_glsheetamt"))
                'If Not row.IsNull("credit_glsheetamt") Then credit_glsheetamt = CDec(row("credit_glsheetamt"))
                'theRow("col2") = Configuration.FormatToString(debit_glsheetamt, DigitConfig.Price)
                'theRow("col3") = Configuration.FormatToString(credit_glsheetamt, DigitConfig.Price)


                '' ß∫°”‰√¢“¥∑ÿπ
                'Dim debit_glbudgetamt As Decimal = 0
                'Dim credit_glbudgetamt As Decimal = 0
                'If Not row.IsNull("debit_glbudgetamt") Then debit_glbudgetamt = CDec(row("debit_glbudgetamt"))
                'If Not row.IsNull("credit_glbudgetamt") Then credit_glbudgetamt = CDec(row("credit_glbudgetamt"))
                'theRow("col4") = Configuration.FormatToString(debit_glbudgetamt, DigitConfig.Price)
                'theRow("col5") = Configuration.FormatToString(credit_glbudgetamt, DigitConfig.Price)
                '' ß∫¥ÿ≈ · ¥ßº≈µË“ß¢Õß DR. & CR.
                'Dim debit_glbalanceamt As Decimal = 0
                'Dim credit_glbalanceamt As Decimal = 0
                'If Not row.IsNull("debit_glbalanceamt") Then debit_glbalanceamt = CDec(row("debit_glbalanceamt"))
                'If Not row.IsNull("credit_glbalanceamt") Then credit_glbalanceamt = CDec(row("credit_glbalanceamt"))
                'Dim glbalanceamt As Decimal = debit_glbalanceamt - credit_glbalanceamt
                'If glbalanceamt > 0 Then
                '    theRow("col6") = Configuration.FormatToString(glbalanceamt, DigitConfig.Price)
                '    theRow("col7") = Configuration.FormatToString(0, DigitConfig.Price)
                'ElseIf glbalanceamt < 0 Then
                '    theRow("col6") = Configuration.FormatToString(0, DigitConfig.Price)
                '    theRow("col7") = Configuration.FormatToString(glbalanceamt * -1, DigitConfig.Price)
                'Else
                '    theRow("col6") = Configuration.FormatToString(0, DigitConfig.Price)
                '    theRow("col7") = Configuration.FormatToString(0, DigitConfig.Price)
                'End If
                'theRow.Tag = rowTag
            Next
            Me.m_treemanager.Treetable.AcceptChanges()

            ' Summary Zone
            For Each row As DataRow In dt.Rows
                Dim parnode As TreeRow = SearchTag(CInt(row("acct_id")))
                If Not parnode Is Nothing AndAlso parnode.Childs.Count > 0 Then
                    Dim b4debit As Decimal = 0
                    Dim b4credit As Decimal = 0
                    Dim debit As Decimal = 0
                    Dim credit As Decimal = 0
                    Dim afterdebit As Decimal = 0
                    Dim aftercredit As Decimal = 0

                    Dim theRow As TreeRow = parnode.Childs.Add
                    therow("col1") = "√«¡¬Õ¥:" & Trim(CStr(parnode("col1")))

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
                End If
            Next
            Me.m_treemanager.Treetable.AcceptChanges()

        End Sub
        Private Function SumChilds(ByRef result As Decimal, ByVal parent As TreeRow, ByVal columnName As String) As Decimal
            If parent.Childs.Count > 0 Then
                For Each childs As TreeRow In parent.Childs
                    If IsNumeric(childs(columnName)) Then
                        result += CDec(childs(columnName))
                    End If
                    If childs.Childs.Count > 0 Then
                        SumChilds(result, childs, columnName)
                    End If
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
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptGLPaper"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPaper.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptGLPaper"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptGLPaper"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPaper.ListLabel}"
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
                    '™◊ËÕºŸÈ¡’¿“…’‡ß‘π‰¥È
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col0")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.Invoice
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col1")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col3")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col4")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col5"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col5")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col6"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col6")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col7"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col7")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    i += 1
                End If
            Next
            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

