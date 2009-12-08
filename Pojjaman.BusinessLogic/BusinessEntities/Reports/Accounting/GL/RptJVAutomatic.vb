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
    Public Class RptJVAutomatic
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
            Dim indent As String = Space(3)
            Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.GLCode}") '"เลขที่เอกสารแก้ไข"
            tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.Remark}") '"หมายเหตุการแก้ไข"
            tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.refCode}") '"เลขที่เอกสารอ้างอิง"
            tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.refDocType}") '"ประเภทเอกสาร"
            tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.HeaderText1}") '"ก่อนปรับปรุง"
            tr("col5") = DBNull.Value
            tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.HeaderText2}") '"ปรับปรุง"
            tr("col7") = DBNull.Value
            tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.HeaderText3}") '"หลังปรับปรุง"
            tr("col9") = DBNull.Value
            tr("col10") = DBNull.Value
            tr("col11") = DBNull.Value
            tr("col12") = DBNull.Value

            tr = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.acct_code}") '"รหัสผังบัญชี"
            tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.acct_name}") '"ชื่อผังบัญชี"
            tr("col2") = DBNull.Value
            tr("col3") = DBNull.Value
            tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.before_debit}") '"เดบิต"
            tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.before_credit}") '"เครดิต"
            tr("col6") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.modify_debit}") '"เดบิต"
            tr("col7") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.modify_credit}") '"เครดิต"
            tr("col8") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.after_Debit}") '"เดบิต"
            tr("col9") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.after_Credit}") '"เครดิต"
            tr("col10") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.ccCode}") '"CC"
            tr("col11") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.user_code}") '"Log In"
            tr("col12") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.editdate}") '"วันที่แก้ไข"

        End Sub
        Private m_maxDataLevel As Integer = 1
        Private m_maxLevel As Integer = 1
        Private Sub PopulateData()
            If Me.m_treemanager Is Nothing Then
                Return
            End If
            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentGLCode As String = ""
            Dim currentacct_code As String = ""

            Dim CostCenterTr As TreeRow
            Dim ItemTr As TreeRow
            Dim indent As String = Space(3)

            For Each row As DataRow In dt.Rows
                If row("GLCode").ToString <> currentGLCode Then
                    CostCenterTr = Me.m_treemanager.Treetable.Childs.Add
                    CostCenterTr("col0") = row("GLCode")
                    CostCenterTr("col1") = row("Remark")
                    CostCenterTr("col2") = row("refCode")
                    CostCenterTr("col3") = row("refDocType")
                    CostCenterTr("col4") = row("HeaderText1")
                    CostCenterTr("col5") = DBNull.Value
                    CostCenterTr("col6") = row("HeaderText2")
                    CostCenterTr("col7") = DBNull.Value
                    CostCenterTr("col8") = row("HeaderText3")
                    CostCenterTr("col9") = DBNull.Value
                    CostCenterTr("col10") = DBNull.Value
                    CostCenterTr("col11") = DBNull.Value
                    CostCenterTr("col12") = DBNull.Value

                    currentGLCode = row("GLCode").ToString
                    currentacct_code = ""
                    CostCenterTr.State = RowExpandState.Expanded
                End If
                If row("acct_code").ToString <> currentacct_code Then
                    ItemTr = CostCenterTr.Childs.Add
                    If Not row.IsNull("acct_code") Then
                        ItemTr("col0") = indent & row("acct_code").ToString
                    End If
                    If Not row.IsNull("acct_name") Then
                        ItemTr("col1") = indent & row("acct_name").ToString
                    End If
                    ItemTr("col2") = DBNull.Value
                    ItemTr("col3") = DBNull.Value
                    If IsNumeric(row("before_debit")) Then
                        ItemTr("col4") = Configuration.FormatToString(CDec(row("before_debit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("before_credit")) Then
                        ItemTr("col5") = Configuration.FormatToString(CDec(row("before_credit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("modify_debit")) Then
                        ItemTr("col6") = Configuration.FormatToString(CDec(row("modify_debit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("modify_credit")) Then
                        ItemTr("col7") = Configuration.FormatToString(CDec(row("modify_credit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("after_Debit")) Then
                        ItemTr("col8") = Configuration.FormatToString(CDec(row("after_Debit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("after_Credit")) Then
                        ItemTr("col9") = Configuration.FormatToString(CDec(row("after_Credit")), DigitConfig.Price)
                    End If
                    If Not row.IsNull("ccCode") Then
                        ItemTr("col10") = indent & row("ccCode").ToString
                    End If
                    If Not row.IsNull("user_code") Then
                        ItemTr("col11") = indent & row("user_code").ToString
                    End If
                    If Not row.IsNull("editdate") Then
                        ItemTr("col12") = indent & row("editdate").ToString
                    End If
                    currentacct_code = row("acct_code").ToString
                End If
            Next
        End Sub
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
            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            widths.Add(120)
            widths.Add(120)
            widths.Add(200)
            widths.Add(200)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)

            Dim alignments As New ArrayList
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)

            For i As Integer = 0 To 12
                Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                cs.MappingName = "col" & i
                cs.HeaderText = ""
                cs.Width = CInt(widths(i))
                cs.NullText = ""
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = CType(alignments(i), HorizontalAlignment)
                cs.ReadOnly = True
                cs.Format = "d"
                AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                dst.GridColumnStyles.Add(cs)
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
                Return "RptJVAutomatic"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptJVAutomatic"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptJVAutomatic"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptJVAutomatic.ListLabel}"
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
                    'ชื่อผู้มีภาษีเงินได้
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    If itemRow.Level = 0 Then
                        dpi.Value = itemRow("col0")
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    Else
                        If Not itemRow.IsNull("col0") Then
                            dpi.Value = "    " & CStr(itemRow("col0"))
                        Else
                            dpi.Value = itemRow("col0")
                        End If
                    End If
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.Invoice
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    If itemRow.Level = 0 Then
                        dpi.Value = itemRow("col1")
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    Else
                        If Not itemRow.IsNull("col1") Then
                            dpi.Value = "    " & CStr(itemRow("col1"))
                        Else
                            dpi.Value = itemRow("col1")
                        End If
                    End If
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.doccode
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.String"
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
                    dpi.DataType = "System.String"
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

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col8"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col8")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col9"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col9")
                    dpi.DataType = "System.Decimal"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col10"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col10")
                    dpi.DataType = "System.string"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col11"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col11")
                    dpi.DataType = "System.string"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col12"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col12")
                    dpi.DataType = "System.DateTime"
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

