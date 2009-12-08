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
    Public Class RptWBSExpenseIncomeMonitor
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private m_cc As CostCenter
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
            MyBase.New(filters, fixValueCollection)
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
            Return BOQ.GetExpenseIncomeSchemaTable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
            Return BOQ.CreateExpenseIncomeTableStyle
        End Function
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
            lkg.Refresh()
        End Sub
        Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
            Me.m_treemanager = tm
            If m_cc Is Nothing OrElse Not m_cc.Originated Then
                Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
                dt.Clear()
                tm.Treetable = dt
                Return
            End If
            If m_cc.BoqId = 0 Then
                Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
                dt.Clear()
                tm.Treetable = dt
                Return
            End If
            If TypeOf Me.Filters(1).Value Is Date Then
                Dim nodigit As Boolean = False
                If Me.Filters(5).Name.ToLower = "nodigit" Then
                    nodigit = CBool(Me.Filters(5).Value)
                End If
                PopulateExpenseIncomeListing(tm.Treetable, CDate(Me.Filters(1).Value), nodigit)
            End If
        End Sub
        Public Sub PopulateExpenseIncomeListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
            Dim dgt As DigitConfig = DigitConfig.Price
            If noDigit Then
                dgt = DigitConfig.Int
            End If
            dt.Clear()

            Dim dt2 As DataTable = Me.DataSet.Tables(0)
            Dim Nodes As New Hashtable
            Dim myParent As String
            Dim parentNode As TreeRow = Nothing

            For Each myDr As DataRow In dt2.Rows
                If CInt(myDr("wbs_level")) = 0 Then
                    parentNode = dt.Childs.Add
                Else
                    myParent = CStr(myDr("wbs_path")).Replace("|" & CInt(myDr("wbs_id")).ToString & "|", "")
                    parentNode = Nodes(myParent).Childs.Add
                End If
                Nodes(CStr(myDr("wbs_path"))) = parentNode

                Dim tr As TreeRow = parentNode
                tr("boqi_itemname") = myDr("wbs_code") & "-" & myDr("wbs_name")
                Dim totalExpense As Decimal = SumValueInDataTable(dt2.Select("wbs_path like '" & myDr("wbs_path") & "%'"), "expense")
                Dim totalIncome As Decimal = SumValueInDataTable(dt2.Select("wbs_path like '" & myDr("wbs_path") & "%'"), "income")
                Dim totalDiff As Decimal = totalIncome - totalExpense
                tr("Expense") = Configuration.FormatToString(totalExpense, dgt)
                tr("Income") = Configuration.FormatToString(totalIncome, dgt)
                tr("Diff") = Configuration.FormatToString(totalDiff, dgt)
                If totalExpense = 0 Then
                    tr("PerCentDiff") = Configuration.FormatToString(0, dgt) & " %"
                Else
                    tr("PerCentDiff") = Configuration.FormatToString((totalDiff / totalExpense) * 100, dgt) & " %"
                End If

                tr.State = RowExpandState.Expanded
            Next

            Dim i As Integer = 0
            For Each row As DataRow In dt.Rows
                i += 1
                row("boqi_linenumber") = i
            Next
            If i > 0 Then
                dt.AcceptChanges()
            End If
        End Sub
        Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
            Dim ret As Decimal = 0
            For Each drtmp As DataRow In dr
                If Not drtmp.IsNull(field) Then
                    ret += CDec(drtmp(field))
                End If
            Next
            Return ret
        End Function

        Public Overrides Sub RefreshDataSet()
            m_cc = New CostCenter
            If TypeOf Me.Filters(0).Value Is CostCenter Then
                m_cc = CType(Me.Filters(0).Value, CostCenter)
            End If

            'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
            Me.Filters(0).Value = m_cc.Id
            If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
                Me.Filters(6).Value = Me.Filters(6).Value.Id
            End If
            '
            If Not m_cc Is Nothing AndAlso m_cc.Originated Then
                MyBase.RefreshDataSet()
            End If
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptWBSExpenseIncomeMonitor"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSExpenseIncomeMonitor.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptWBSExpenseIncomeMonitor"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptWBSExpenseIncomeMonitor"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSExpenseIncomeMonitor.ListLabel}"
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
            Return "RptWBSExpenseIncomeMonitor"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = m_cc.Name 'Me.Filters(0).Value
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateEnd"
            If Not IsDBNull(Me.Filters(1).Value) Then
                dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            dpi = New DocPrintingItem
            dpi.Mapping = "WBSReportType"
            If Not IsDBNull(Me.Filters(3).Value) Then
                dpi.Value = Me.Filters(3).Value
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            dpi = New DocPrintingItem
            dpi.Mapping = "Requester"
            If Not IsDBNull(Me.Filters(6).Value) Then
                dpi.Value = New Employee(CInt(Me.Filters(6).Value)).Name
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Dim i As Integer = 0
            For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
                For j As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & j
                    dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                Next
                i += 1
            Next

            Return dpiColl
        End Function
#End Region

    End Class
End Namespace

