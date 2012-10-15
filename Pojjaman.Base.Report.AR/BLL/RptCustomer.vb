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
    Public Class RptCustomer
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
            m_grid.ColCount = 11

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 80
            m_grid.ColWidths(5) = 80
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 150
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 100
            m_grid.ColWidths(11) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 0
            m_grid.Rows.FrozenCount = 0

            m_grid(0, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.PrID}")    '"รหัสลูกค้า"
            m_grid(0, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.PrName}")  '"ชื่อลูกค้า"
            m_grid(0, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.Address}")  '"ที่อยู่ลูกค้า"
            m_grid(0, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.CreditPeriod}")  '"ระยะเวลาเครดิต"
            m_grid(0, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.CreditAmount}")  '"วงเงินเครดิต"
            m_grid(0, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.PrGroup}") '"กลุ่มลูกค้า"
            m_grid(0, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.CommunicationName}")        '"ชื่อผู้ติดต่อ"
            m_grid(0, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.ConditionReceiveAblution}") '"เงื่อนไขการรับชำระ"
            m_grid(0, 9).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.Tel}")     '"โทรศัพท์"
            m_grid(0, 10).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.Fax}")     '"โทรสาร"
            m_grid(0, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.Mobile}")

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim cindent As String = Space(3)

            Dim n As Int32 = 0
            Dim currRow As Integer = -1

            For Each row As DataRow In dt.Rows
                n += 1
                m_grid.RowCount += 1
                currRow = m_grid.RowCount
                m_grid.RowStyles(currRow).ReadOnly = True

                m_grid(n, 1).CellValue = row("Code")
                m_grid(n, 2).CellValue = row("Name")
                m_grid(n, 3).CellValue = row("Address")
                m_grid(n, 4).CellValue = row("CreditPeriod")
                'm_grid(n, 5).CellValue = Configuration.FormatToString(row("CreditAmount"), DigitConfig.Price)

                If row.IsNull("CreditAmount") Then
                    m_grid(n, 5).CellValue = Configuration.FormatToString(0, DigitConfig.Price)
                Else
                    m_grid(n, 5).CellValue = Configuration.FormatToString(row("CreditAmount"), DigitConfig.Price)
                End If

                m_grid(n, 6).CellValue = row("GroupName")
                m_grid(n, 7).CellValue = row("ContactPerson")
                m_grid(n, 8).CellValue = row("Note")
                m_grid(n, 9).CellValue = row("Phone")
                m_grid(n, 10).CellValue = row("Fax")
                m_grid(n, 11).CellValue = row("Mobile")
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptCustomer"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptCustomer"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptCustomer"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCustomer.ListLabel}"
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
            Return "RptCustomer"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptCustomer"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim LineNumber As Integer = 0

            Dim n As Integer = 0
            Dim i As Integer = 0
            For rowIndex As Integer = 1 To m_grid.RowCount
                i += 1

                dpi = New DocPrintingItem
                dpi.Mapping = "Item.LineNumber"
                dpi.Value = i
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

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

                dpi = New DocPrintingItem
                dpi.Mapping = "col7"
                dpi.Value = m_grid(rowIndex, 8).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col8"
                dpi.Value = m_grid(rowIndex, 9).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col9"
                dpi.Value = m_grid(rowIndex, 10).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col10"
                dpi.Value = m_grid(rowIndex, 11).CellValue
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

