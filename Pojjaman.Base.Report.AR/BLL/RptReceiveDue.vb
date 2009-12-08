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
    Public Class RptReceiveDue
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
            m_grid.RowCount = 0
            m_grid.ColCount = 9

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 169
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 0
            m_grid.Rows.FrozenCount = 0

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.ArID}")         '"รหัสลูกหนี้"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.ArName}")       '"ชื่อลูกหนี้"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.NotInRange}")   '"ไม่อยู่ในช่วง"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Range1_7}")     '"ช่วง 0-7 วัน"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Range8_14}")     '"ช่วง 8-14 วัน"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Range15_21}")   '"ช่วง 15-21 วัน"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Range22_28}")   '"ช่วง 22-28 วัน"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Exceed_28}")    '"เกิน 28 วัน"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Total}")        '"รวม"            

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim indent As String = Space(3)
            Dim currentCustomerIndex As Integer = -1

            Dim summaryAmount(7) As Decimal
            For i As Integer = 0 To 6
                summaryAmount(i) = 0
            Next

            Dim n As Int32 = 0
            For Each row As DataRow In dt.Rows

                m_grid.RowCount += 1
                currentCustomerIndex = m_grid.RowCount
                m_grid.RowStyles(currentCustomerIndex).ReadOnly = True
                m_grid(currentCustomerIndex, 1).CellValue = row("CustomerCode")
                m_grid(currentCustomerIndex, 2).CellValue = row("CustomerName")
                m_grid(currentCustomerIndex, 3).CellValue = Configuration.FormatToString(CDec(row("OutBound")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Intv1to7")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Intv8to14")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Intv15to21")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Intv22to28")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Over28")), DigitConfig.Price)
                m_grid(currentCustomerIndex, 9).CellValue = Configuration.FormatToString(CDec(row("OutBound")) + CDec(row("Intv1to7")) + CDec(row("Intv8to14")) + CDec(row("Intv15to21")) + CDec(row("Intv22to28")) + CDec(row("Over28")), DigitConfig.Price)

                summaryAmount(0) += CDec(row("OutBound"))
                summaryAmount(1) += CDec(row("Intv1to7"))
                summaryAmount(2) += CDec(row("Intv8to14"))
                summaryAmount(3) += CDec(row("Intv15to21"))
                summaryAmount(4) += CDec(row("Intv22to28"))
                summaryAmount(5) += CDec(row("Over28"))
                summaryAmount(6) += (CDec(row("OutBound")) + CDec(row("Intv1to7")) + CDec(row("Intv8to14")) + CDec(row("Intv15to21")) + CDec(row("Intv22to28")) + CDec(row("Over28")))
            Next

            m_grid.RowCount += 1
            currentCustomerIndex = m_grid.RowCount
            m_grid.RowStyles(currentCustomerIndex).Font.Bold = True
            m_grid.RowStyles(currentCustomerIndex).ReadOnly = True
            m_grid(currentCustomerIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.Total}") '"รวม
            m_grid(currentCustomerIndex, 3).CellValue = Configuration.FormatToString(summaryAmount(0), DigitConfig.Price)
            m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(summaryAmount(1), DigitConfig.Price)
            m_grid(currentCustomerIndex, 5).CellValue = Configuration.FormatToString(summaryAmount(2), DigitConfig.Price)
            m_grid(currentCustomerIndex, 6).CellValue = Configuration.FormatToString(summaryAmount(3), DigitConfig.Price)
            m_grid(currentCustomerIndex, 7).CellValue = Configuration.FormatToString(summaryAmount(4), DigitConfig.Price)
            m_grid(currentCustomerIndex, 8).CellValue = Configuration.FormatToString(summaryAmount(5), DigitConfig.Price)
            m_grid(currentCustomerIndex, 9).CellValue = Configuration.FormatToString(summaryAmount(6), DigitConfig.Price)

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptReceiveDue"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptReceiveDue"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptReceiveDue"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.ListLabel}"
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
            Return "RptReceiveDue"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptReceiveDue"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim fn As Font

            Dim n As Integer = 0
            For rowIndex As Integer = 1 To m_grid.RowCount
                If Not rowIndex.Equals(m_grid.RowCount) Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
                ''If i > 0 Then
                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = m_grid(rowIndex, 1).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col1"
                dpi.Value = m_grid(rowIndex, 2).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col2"
                dpi.Value = m_grid(rowIndex, 3).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col3"
                dpi.Value = m_grid(rowIndex, 4).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col4"
                dpi.Value = m_grid(rowIndex, 5).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col5"
                dpi.Value = m_grid(rowIndex, 6).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col6"
                dpi.Value = m_grid(rowIndex, 7).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col7"
                dpi.Value = m_grid(rowIndex, 8).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col8"
                dpi.Value = m_grid(rowIndex, 9).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)
                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

