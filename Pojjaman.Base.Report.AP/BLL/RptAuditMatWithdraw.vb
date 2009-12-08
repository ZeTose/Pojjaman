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
    Public Class RptAuditMatWithdraw
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
            m_grid.BeginUpdate()
            m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            m_grid.Model.Options.NumberedColHeaders = False
            m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 2
            m_grid.ColCount = 7

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 120
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 130
            m_grid.ColWidths(6) = 130
            m_grid.ColWidths(7) = 120
       
            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.EmployeeId}") '"รหัสพนักงาน"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.EmployeeName}") '"ชื่อพนักงาน"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.ProjName}")    '"ชื่อโครงการ"

            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.ItemId}")  '"รหัสสินค้า"
            m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.ItemName}")   '"ชื่อสินค้า"
            m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.Unit}")   '"หน่วย"
            m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.NumOutPr}")  '"จำนวนออก PR(ทั้งหมด)"
            m_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.NumWithdraw}")  '"จำนวนเบิกแล้ว(ทั้งหมด)"
            m_grid(2, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.NumWithdrawAble}")  '"จำนวนเบิกได้"

            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.PRCode}") '"PR Code"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub

        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentEmpCode As String = ""
            Dim currentDocCode As String = ""
            Dim currentItemCode As String = ""

            Dim currEmpIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim indent As String = Space(3)

            Dim dontCarePR As Boolean

            dontCarePR = CBool(Me.Filters(6).Value)
            For Each row As DataRow In dt.Rows
                If row("EmployeeId").ToString & row("CCId").ToString <> currentEmpCode Then
                    m_grid.RowCount += 1
                    currEmpIndex = m_grid.RowCount
                    m_grid.RowStyles(currEmpIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currEmpIndex).Font.Bold = True
                    m_grid.RowStyles(currEmpIndex).ReadOnly = True

                    m_grid(currEmpIndex, 1).CellValue = row("EmployeeCode")
                    m_grid(currEmpIndex, 2).CellValue = row("EmployeeName")
                    m_grid(currEmpIndex, 3).CellValue = row("CCCode")
                    currentEmpCode = row("EmployeeId").ToString & row("CCId").ToString
                    currentDocCode = ""
                    If dontCarePR Then
                        currentItemCode = ""
                    End If
                End If
                If Not dontCarePR AndAlso row("PRCODE").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If Not row.IsNull("PRCODE") Then
                        m_grid(currDocIndex, 2).CellValue = indent & row("PRCODE").ToString
                    End If
                    currentDocCode = row("PRCODE").ToString
                    currentItemCode = ""
                End If
                If row("ItemType").ToString & row("ItemCode").ToString <> currentItemCode Then
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    If Not row.IsNull("ItemCode") Then
                        m_grid(currItemIndex, 2).CellValue = indent & indent & row("ItemCode").ToString
                    End If
                    If Not row.IsNull("ItemName") Then
                        m_grid(currItemIndex, 3).CellValue = indent & indent & row("ItemName").ToString
                    End If
                    If Not row.IsNull("UnitName") Then
                        m_grid(currItemIndex, 4).CellValue = indent & indent & row("UnitName").ToString
                    End If
                    If IsNumeric(row("PRQty")) Then
                        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("PRQty")), DigitConfig.Qty)
                    End If
                    If IsNumeric(row("WithdrawQty")) Then
                        m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("WithdrawQty")), DigitConfig.Qty)
                    End If
                    If IsNumeric(row("Diff")) Then
                        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Diff")), DigitConfig.Qty)
                    End If
                    currentItemCode = row("ItemType").ToString & row("ItemCode").ToString
                End If
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptAuditMatWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptAuditMatWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptAuditMatWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAuditMatWithdraw.ListLabel}"
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
            Return "RptAuditMatWithdraw"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptAuditMatWithdraw"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            For rowIndex As Integer = 3 To m_grid.RowCount
                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = m_grid(rowIndex, 1).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

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
                dpi.Mapping = "col3"
                dpi.Value = m_grid(rowIndex, 4).CellValue
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
                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

