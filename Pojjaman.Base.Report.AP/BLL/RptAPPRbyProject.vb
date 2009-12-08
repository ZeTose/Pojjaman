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
    Public Class RptAPPRbyProject
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
        Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
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
            tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.PRCode}") '"เลขที่ PR"
            tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.Requester}") '"ผู้ขอซื้อ"
            tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.RequestDate}") '"วันที่ขอซื้อ"
            tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.ProjectName}") '"ชื่อโครงการ"
            tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.LastAccess}") '"ผู้เข้าสู่ระบบล่าสุด"

        End Sub
        Private m_maxDataLevel As Integer = 1
        Private m_maxLevel As Integer = 1
        Private Sub PopulateData()
            If Me.m_treemanager Is Nothing Then
                Return
            End If
            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentPRCode As String = ""

            Dim Tr As TreeRow
            Dim indent As String = Space(3)

            For Each row As DataRow In dt.Rows
                Tr = Me.m_treemanager.Treetable.Childs.Add
                Tr("col0") = row("PRCode")
                Tr("col1") = row("EmployeeName")
                Tr("col2") = CDate(row("PRDocDate")).ToShortDateString
                Tr("col3") = row("ProjectName")
                Tr("col4") = row("LastAccess")
                'Tr.State = RowExpandState.Expanded
            Next
        End Sub
        Public Overrides Function GetSimpleSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("Report")
            myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            widths.Add(150)
            widths.Add(200)
            widths.Add(100)
            widths.Add(200)
            widths.Add(150)

            Dim alignments As New ArrayList
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Center)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)

            For i As Integer = 0 To 4
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
            If e.Row <= 0 Then
                e.HilightValue = True
            End If
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptAPPRbyProject"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPPRbyProject"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPPRbyProject"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPRbyProject.ListLabel}"
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
            Return "RptAPPRbyProject"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptAPPRbyProject"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim i As Integer = 0
            For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
                If i > 1 Then
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = itemRow("col0")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = itemRow("col1")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    dpi.Value = itemRow("col3")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    dpi.Value = itemRow("col4")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                    n += 1
                End If
                i += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

