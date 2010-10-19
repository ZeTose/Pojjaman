
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptWR
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
            RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            m_grid.BeginUpdate()
            m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            m_grid.Model.Options.NumberedColHeaders = False
            m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

            Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("wr_id")
            Dim docType As Integer = 324

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 0
            m_grid.ColCount = 9

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 120
            'm_grid.ColWidths(3) = 200
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 0
            m_grid.Rows.FrozenCount = 0

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.DocNumber}")       '"เลขที่เอกสาร"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.wr_docDate}")      '"วันที่"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.ccinfo}")          '"Cost Center "
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.Sum}")             '"ยอดรวม"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.note}")      '"หมายเหตุ"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.closestatus}")    '"สถานะการปิด WR"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.refstatus}")      '"อ้างอิง"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.wrstatusinfo}")    '"สถานะ"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.Director}")      '"ผู้ขอจ้าง"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currTrIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim indent As String = Space(3)

            Dim SumAmount As Decimal = 0

            'Dim n As Int32 = 0

            For Each row As DataRow In dt.Rows
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid(currItemIndex, 0).Tag = row
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                m_grid(currItemIndex, 1).CellValue = row("WRcode")
                If Not row.IsNull("WRdocdate") Then
                    m_grid(currItemIndex, 2).CellValue = CDate(row("WRdocdate")).ToShortDateString
                End If
                If Not row.IsNull("ccinfo") Then
                    m_grid(currItemIndex, 3).CellValue = row("ccinfo").ToString
                End If

                If Not row.IsNull("wr_gross") Then
                    m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("wr_gross")), DigitConfig.Price)
                    SumAmount += CDec(row("wr_gross"))
                End If
                m_grid(currItemIndex, 5).CellValue = row("WRnote").ToString
                m_grid(currItemIndex, 6).CellValue = row("closestatus").ToString
                m_grid(currItemIndex, 7).CellValue = row("refstatus").ToString

                m_grid(currItemIndex, 8).CellValue = row("WRstatusinfo").ToString

                m_grid(currItemIndex, 9).CellValue = row("Director").ToString

            Next
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currTrIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWR.SumAll}") 'รวม
            m_grid(currTrIndex, 4).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price) 'ยอดรวมภาษี 

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptWR"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptWR.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptWR"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptWR"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptWR.ListLabel}"
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
            Return "RptWR"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptWR"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            'Dim LineNumber As Integer = 0

            'Dim n As Integer = 0
            'Dim i As Integer = 0
            For rowIndex As Integer = 1 To m_grid.RowCount
                For colIndex As Integer = 1 To m_grid.ColCount
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & (colIndex - 1).ToString
                    dpi.Value = m_grid(rowIndex, colIndex).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = rowIndex
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                Next
                'i += 1
                'dpi = New DocPrintingItem
                'dpi.Mapping = "Item.LineNumber"
                'dpi.Value = i
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col0"
                'dpi.Value = m_grid(rowIndex, 1).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col1"
                'dpi.Value = m_grid(rowIndex, 2).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col2"
                'dpi.Value = m_grid(rowIndex, 3).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col3"
                'dpi.Value = m_grid(rowIndex, 4).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col4"
                'dpi.Value = m_grid(rowIndex, 5).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col5"
                'dpi.Value = m_grid(rowIndex, 6).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col6"
                'dpi.Value = m_grid(rowIndex, 7).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col7"
                'dpi.Value = m_grid(rowIndex, 8).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col8"
                'dpi.Value = m_grid(rowIndex, 9).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col9"
                'dpi.Value = m_grid(rowIndex, 10).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col10"
                'dpi.Value = m_grid(rowIndex, 11).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col11"
                'dpi.Value = m_grid(rowIndex, 12).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col12"
                'dpi.Value = m_grid(rowIndex, 13).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col13"
                'dpi.Value = m_grid(rowIndex, 14).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col14"
                'dpi.Value = m_grid(rowIndex, 15).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col15"
                'dpi.Value = m_grid(rowIndex, 16).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)


                'n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace
