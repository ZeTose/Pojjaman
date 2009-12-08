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
    Public Class RptARRemainDetail
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
            m_grid.RowCount = 1
            m_grid.ColCount = 6

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left 
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.ArID}") '"รหัสลูกหนี้"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.ArName}") '"ชื่อลูกหนี้"
         
            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.RemainingLimitDate}") '"วันที่ครบกำหนดรับชำระ"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.DocNumber}") '"เลขที่เอกสาร"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.DocDate}") '"วันที่เอกสาร"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.DocType}") '"ประเภทเอกสาร"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.DocCtrlNumber}") '"เลขที่ใบกำกับ"
            m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.Cost}") '"มูลค่า"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub

        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentCustomerCode As String = ""
            Dim currentDocCode As String = ""
            Dim currentCustomerIndex As Integer = -1
            Dim currentDocIndex As Integer = -1

            Dim CustomerTr As TreeRow
            Dim indent As String = Space(3)
            Dim tmpSum As Decimal = 0

            SumAmt = 0

            For Each row As DataRow In dt.Rows
                If row("CustomerCode").ToString <> currentCustomerCode Then
                    If Not currentCustomerCode = "" Then
                        If currentCustomerIndex <> -1 Then
                            m_grid.RowCount += 1
                            currentCustomerIndex = m_grid.RowCount
                            m_grid.RowStyles(currentCustomerIndex).ReadOnly = True
                            m_grid(currentCustomerIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.Total}") '"รวม"
                            m_grid(currentCustomerIndex, 6).CellValue = Configuration.FormatToString(tmpSum, DigitConfig.Price)
                            m_grid(currentCustomerIndex, 1).Tag = "Font.Bold"
                            tmpSum = 0
                        End If
                    End If

                    m_grid.RowCount += 1
                    currentCustomerIndex = m_grid.RowCount
                    m_grid.RowStyles(currentCustomerIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currentCustomerIndex).Font.Bold = True
                    m_grid.RowStyles(currentCustomerIndex).ReadOnly = True

                    m_grid(currentCustomerIndex, 1).CellValue = row("CustomerCode")
                    m_grid(currentCustomerIndex, 2).CellValue = row("CustomerName")
                    m_grid(currentCustomerIndex, 1).Tag = "Font.Bold"
                    currentCustomerCode = row("CustomerCode").ToString
                    currentDocCode = ""
                End If
                If row("DocCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currentDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currentDocIndex).ReadOnly = True

                    If IsDate(row("DueDate")) Then
                        m_grid(currentDocIndex, 1).CellValue = indent & CDate(row("DueDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocCode") Then
                        m_grid(currentDocIndex, 2).CellValue = indent & row("DocCode").ToString
                    End If
                    If Not row.IsNull("DocDate") Then
                        m_grid(currentDocIndex, 3).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocType") Then
                        m_grid(currentDocIndex, 4).CellValue = indent & row("DocType").ToString
                    End If
                    If Not row.IsNull("VatCode") Then
                        m_grid(currentDocIndex, 5).CellValue = indent & row("VatCode").ToString
                    End If
                    If IsNumeric(row("Amt")) Then
                        m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Amt")), DigitConfig.Price)
                        tmpSum += CDec(row("Amt"))
                        SumAmt += CDec(row("Amt"))
                    End If
                    currentDocCode = row("DocCode").ToString
                End If
            Next

            If currentCustomerIndex <> -1 Then
                m_grid.RowCount += 1
                currentDocIndex = m_grid.RowCount
                m_grid.RowStyles(currentDocIndex).ReadOnly = True
                m_grid(currentDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.Total}") '"รวม"
                m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(tmpSum, DigitConfig.Price)
                m_grid(currentDocIndex, 1).Tag = "Font.Bold"
                tmpSum = 0
            End If

            m_grid.RowCount += 1
            currentDocIndex = m_grid.RowCount
            m_grid.RowStyles(currentDocIndex).Font.Bold = True
            m_grid.RowStyles(currentDocIndex).ReadOnly = True
            m_grid(currentDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.Total}") '"รวม"
            m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            m_grid(currentDocIndex, 1).Tag = "Font.Bold"

        End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptARRemainDetail"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemainDetail"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemainDetail"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemainDetail.ListLabel}"
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
            Return "RptARRemainDetail"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptARRemainDetail"
        End Function
        Private SumAmt As Decimal = 0
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim i As Integer = 0
            ''For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
            For rowIndex As Integer = 0 To m_grid.RowCount
                Dim fn As Font

                If m_grid(rowIndex, 1).Tag Is Nothing Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If

                If i > 1 Then
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
                    n += 1
                End If
                i += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

