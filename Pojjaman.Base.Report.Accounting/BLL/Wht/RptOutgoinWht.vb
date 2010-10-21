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
    Public Class RptOutgoinWht
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

            Dim docId As Integer = drh.GetValue(Of Integer)("docId")
            Dim docType As Integer = drh.GetValue(Of Integer)("docType")

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 1
            m_grid.ColCount = 9
            m_grid.Model.Cols.Hidden(9) = True
            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 120
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 150
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.Date}") '"วันที่"
            m_grid(0, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.DocNumber}") '"เลขที่เอกสาร"
            m_grid(0, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.Invoice}") '"เลขที่ใบกำกับ"
            m_grid(0, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.PrintName}") '"ผู้ถูกหัก ณ ที่จ่าย"
            m_grid(0, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.WHTType}") '"ประเภท"

            m_grid(1, 5).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.Description}") '"รายการ"
            m_grid(1, 6).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.BeforeTax}") '"จำนวนเงิน"
            m_grid(1, 7).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.TaxRate}") '"อัตรา"
            m_grid(1, 8).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.WHTAmt}") '"ถูกหัก ณ ที่จ่าย"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentCustomerCode As String = ""
            Dim currentDocCode As String = ""
            Dim tmpAmount As Decimal = 0
            Dim tmpWHT As Decimal = 0
            Dim SumAmount As Decimal = 0
            Dim SumWHT As Decimal = 0

            Dim currCustomerIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim indent As String = Space(3)
            For Each row As DataRow In dt.Rows
                If row("DocCode").ToString <> currentCustomerCode Then
                    If currentCustomerCode <> "" Then
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount
                        m_grid.RowStyles(currDocIndex).ReadOnly = True
                        m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.Total}")
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
                        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpWHT, DigitConfig.Price)
                        tmpAmount = 0
                        tmpWHT = 0
                    End If
                    m_grid.RowCount += 1
                    currCustomerIndex = m_grid.RowCount
                    m_grid(currCustomerIndex, 0).Tag = row
                    m_grid.RowStyles(currCustomerIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currCustomerIndex).Font.Bold = True
                    m_grid.RowStyles(currCustomerIndex).ReadOnly = True
                    m_grid(currCustomerIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
                    m_grid(currCustomerIndex, 2).CellValue = row("DocCode").ToString
                    m_grid(currCustomerIndex, 3).CellValue = row("Invoice").ToString
                    m_grid(currCustomerIndex, 4).CellValue = row("PrintName").ToString
                    m_grid(currCustomerIndex, 5).CellValue = row("WHTType").ToString
                    currentCustomerCode = row("DocCode").ToString
                End If
                m_grid.RowCount += 1
                currDocIndex = m_grid.RowCount
                m_grid.RowStyles(currDocIndex).ReadOnly = True
                If Not row.IsNull("Description") Then
                    m_grid(currDocIndex, 5).CellValue = indent & row("Description").ToString
                End If
                If IsNumeric(row("BeforeTax")) Then
                    m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("BeforeTax")), DigitConfig.Price)
                    tmpAmount += CDec(row("BeforeTax"))
                    SumAmount += CDec(row("BeforeTax"))
                End If
                If IsNumeric(row("TaxRate")) Then
                    m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TaxRate")), DigitConfig.Price)
                End If
                If IsNumeric(row("WHTAmt")) Then
                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("WHTAmt")), DigitConfig.Price)
                    tmpWHT += CDec(row("WHTAmt"))
                    SumWHT += CDec(row("WHTAmt"))
                End If
                m_grid(currDocIndex, 9).CellValue = 0
            Next
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.Total}")
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpWHT, DigitConfig.Price)

            'm_grid.RowCount += 1
            'currDocIndex = m_grid.RowCount
            'm_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            'm_grid.RowStyles(currDocIndex).Font.Bold = True
            'm_grid.RowStyles(currDocIndex).ReadOnly = True
            'm_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.SumAll}")		'"รวมทั้งหมด"
            'm_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
            'm_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(SumWHT, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptOutgoinWht"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoinWht"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoinWht"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinWht.ListLabel}"
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

            Dim n As Integer = 0
            Dim SumAmt As Decimal = 0
            Dim SumWHT As Decimal = 0
            For rowIndex As Integer = 2 To m_grid.RowCount
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

                'เอาไว้ดูว่า Row ไหนมาจากการ Sum
                dpi = New DocPrintingItem
                dpi.Mapping = "Group Level"
                dpi.Value = m_grid(rowIndex, 9).CellValue
                dpi.DataType = "System.Integer"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                n += 1
                If IsNumeric(m_grid(rowIndex, 9).CellValue) AndAlso CInt(m_grid(rowIndex, 9).CellValue) = 0 Then
                    If IsNumeric(m_grid(rowIndex, 6).CellValue) Then
                        SumAmt += CDec(m_grid(rowIndex, 6).CellValue)
                    End If
                    If IsNumeric(m_grid(rowIndex, 8).CellValue) Then
                        SumWHT += CDec(m_grid(rowIndex, 8).CellValue)
                    End If
                End If
            Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol5
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol5"
            dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol7
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol7"
            dpi.Value = Configuration.FormatToString(SumWHT, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)
            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

