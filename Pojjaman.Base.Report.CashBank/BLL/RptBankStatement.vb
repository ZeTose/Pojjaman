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
    Public Class RptBankStatement
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
            m_grid.ColCount = 9

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 150
            m_grid.ColWidths(5) = 200
            m_grid.ColWidths(6) = 150
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 120
            m_grid.ColWidths(9) = 120

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Bank}") '"ธนาคาร/สาขา"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookID}") '"เลขที่สมุดเงินฝาก"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookName}") '"ชื่อบัญชี"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BookType}") '"ประเภทสมุดบัญชี"

            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Date}")  '"วันที่"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.DocDate}")  '"เลขที่เอกสาร"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.ChequeNumber}")  '"เลขที่เช็ค"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.List}")  '"รายการ"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.RefCode}")  '"ใบสำคัญ"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Deposit}")  '"ฝาก"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.Withdraw}")  '"ถอน"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.BalanceAmount}")  '"ยอดคงเหลือ"

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dtOpen As DataTable = Me.DataSet.Tables(1)
            Dim currentItemCode As String = ""
            Dim currentDocCode As String = ""

            Dim currItemIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim tmpSum As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("BankBranchCode").ToString & row("BankacctBankCode").ToString <> currentDocCode Then
                    tmpSum = 0
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    Dim OpenRows As DataRow() = dtOpen.Select("BankBranchCode =" & "'" & row("BankBranchCode").ToString & "'" & " and " & "BankacctBankCode =" & "'" & row("BankacctBankCode").ToString & "'")
                    If OpenRows.Length <> 0 Then
                        For Each Myrow As DataRow In OpenRows
                            m_grid.RowCount += 1
                            currItemIndex = m_grid.RowCount
                            m_grid.RowStyles(currItemIndex).ReadOnly = True
                            If IsNumeric(Myrow("Balanceamt")) Then
                                m_grid(currItemIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.OpeningBalance}") '"ยอดยกมา"
                                m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(Myrow("Balanceamt")), DigitConfig.Price)
                                tmpSum = CDec(Myrow("Balanceamt"))
                            End If
                        Next
                    Else
                        m_grid.RowCount += 1
                        currItemIndex = m_grid.RowCount
                        m_grid.RowStyles(currItemIndex).ReadOnly = True
                        m_grid(currItemIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.OpeningBalance}") '"ยอดยกมา"
                        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(0), DigitConfig.Price)
                    End If
                    m_grid(currDocIndex, 1).CellValue = row("BankBranchName")
                    m_grid(currDocIndex, 2).CellValue = row("BankacctBankCode")
                    m_grid(currDocIndex, 3).CellValue = row("BankacctName")
                    m_grid(currDocIndex, 4).CellValue = row("BankacctType")
                    currentDocCode = row("BankBranchCode").ToString & row("BankacctBankCode").ToString
                    currentItemCode = ""
                End If
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                If IsDate(row("DocDate")) Then
                    m_grid(currItemIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                End If
                If Not row.IsNull("DocCode") Then
                    m_grid(currItemIndex, 3).CellValue = indent & row("DocCode").ToString
                End If
                If Not row.IsNull("CqCode") Then
                    m_grid(currItemIndex, 4).CellValue = indent & row("CqCode").ToString
                End If
                If Not row.IsNull("Detail") Then
                    m_grid(currItemIndex, 5).CellValue = indent & row("Detail").ToString
                End If
                If Not row.IsNull("RefCode") Then
                    m_grid(currItemIndex, 6).CellValue = indent & row("Refcode").ToString
                End If
                If IsNumeric(row("Deprositamt")) Then
                    m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Deprositamt")), DigitConfig.Price)
                    tmpSum += CDec(row("Deprositamt"))
                End If
                If IsNumeric(row("Withdrawamt")) Then
                    m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Withdrawamt")), DigitConfig.Price)
                    tmpSum -= CDec(row("Withdrawamt"))
                End If
                If IsNumeric(row("Balanceamt")) Then
                    m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(tmpSum), DigitConfig.Price)
                End If
                currentItemCode = row("DocCode").ToString
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptBankStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptBankStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptBankStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankStatement.ListLabel}"
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
            Return "RptBankStatement"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptBankStatement"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
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

                dpi = New DocPrintingItem
                dpi.Mapping = "col8"
                dpi.Value = m_grid(rowIndex, 9).CellValue
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

