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
    Public Class RptBankAccount
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
            m_grid.ColCount = 4

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 290
            m_grid.ColWidths(4) = 150

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.BankBrhCode}") '"รหัสธนาคาร/สาขา"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.BankBrhName}") '"ชื่อธนาคาร/สาขา"

            m_grid(1, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.BankacctType}")  '"ชื่อประเภทบัญชี"
            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.BankacctCode}")   '"เลขที่สมุดเงินฝาก"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.BankacctName}")  '"ชื่อบัญชี"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.Balanceamt}")   '"ยอดคงเหลือ"

        End Sub
        Private Sub PopulateData()

            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currentItemCode As String = ""
            Dim currentBankacctCode As String = ""

            Dim currItemIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim indent As String = Space(3)

            For Each row As DataRow In dt.Rows
                If row("BankBrhCode").ToString <> currentItemCode Then
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currItemIndex).Font.Bold = True
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    m_grid(currItemIndex, 1).CellValue = row("BankBrhCode").ToString
                    m_grid(currItemIndex, 2).CellValue = row("BankBrhName").ToString

                    currentItemCode = row("BankBrhCode").ToString
                    currentBankacctCode = ""
                End If
                If row("BankacctCode").ToString <> currentBankacctCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If Not row.IsNull("BankacctType") Then
                        m_grid(currDocIndex, 1).CellValue = indent & row("BankacctType").ToString
                    End If
                    If Not row.IsNull("BankacctBankCode") Then
                        m_grid(currDocIndex, 2).CellValue = indent & row("BankacctBankCode").ToString
                    End If
                    If Not row.IsNull("BankacctName") Then
                        m_grid(currDocIndex, 3).CellValue = indent & row("BankacctName").ToString
                    End If
                    If IsNumeric(row("Balanceamt")) Then
                        m_grid(currDocIndex, 4).CellValue = indent & Configuration.FormatToString(CDec(row("Balanceamt")), DigitConfig.Price)
                    End If
                    currentBankacctCode = row("BankacctCode").ToString
                End If
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptBankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptBankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptBankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptBankAccount.ListLabel}"
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
                Select Case fixDpi.Mapping.ToLower
                    Case "month", "year", "type"
                        dpiColl.Add(fixDpi)
                    Case "bankacctstart", "bankacctend"
                        dpiColl.Add(fixDpi)
                End Select
            Next

            Dim n As Integer = 0
            For rowIndex As Integer = 2 To m_grid.RowCount
                If IsDBNull(m_grid(rowIndex, 3).CellValue) Then
                    'ชื่อผู้มีภาษีเงินได้
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = m_grid(rowIndex, 1).CellValue
                    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Invoice
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = m_grid(rowIndex, 2).CellValue
                    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                Else
                    'ชื่อผู้มีภาษีเงินได้
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = m_grid(rowIndex, 1).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Invoice
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = m_grid(rowIndex, 2).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.BankBrhCode
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    dpi.Value = m_grid(rowIndex, 3).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.printname
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    dpi.Value = m_grid(rowIndex, 4).CellValue
                    dpi.DataType = "System.Decimal"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                End If

                n += 1
            Next

            Return dpiColl
        End Function
#End Region

    End Class
End Namespace

