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
    Public Class RptUnorderPRItem
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
            m_grid.ColCount = 7

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 150
            m_grid.ColWidths(5) = 150
            m_grid.ColWidths(6) = 200
            m_grid.ColWidths(7) = 150

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.CCCode}") '"รหัสโครงการ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.CCName}") '"ชื่อโครงการ"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.PRAmont}") '"จำนวนเอกสาร PR"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.PRAmontUnorderAll}") '"จำนวน PR ค้างทั้งหมด"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.AmontUnapporve}") '"จำนวนค้างอนุมัติ"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.AmontStockApprove}") '"จำนวนค้างตรวจสอบโดยคลัง"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.AmontUnPo}") '"จำนวนค้างสั่ง (PO)"

            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.PRCode}")  '"เลขที่เอกสาร"
            

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currentCCId As String = ""

            Dim currCCIndex As Integer = -1
            Dim currItemIndex As Integer = -1

            Dim CountPR As Integer = 0
            Dim CountRemain As Integer = 0
            Dim CountUnApprove As Integer = 0
            Dim CountUnStockApprove As Integer = 0
            Dim CountUnPO As Integer = 0

            Dim CountAll_PR As Integer = 0
            Dim CountAll_UnRemain As Integer = 0
            Dim CountAll_UnApprove As Integer = 0
            Dim CountAll_UnStockApprove As Integer = 0
            Dim CountAll_UnPO As Integer = 0

            Dim tmpCountRemain As Integer = 0

            Dim indent As String = Space(3)

            Dim showDetail As Int16
            showDetail = CInt(Me.Filters(7).Value)

            For Each row As DataRow In dt.Rows
                If row("CCId").ToString <> currentCCId Then
          If currentCCId.Length > 0 And CountPR > 0 Then
            m_grid(currCCIndex, 3).CellValue = CountPR
            m_grid(currCCIndex, 4).CellValue = CountRemain
            m_grid(currCCIndex, 5).CellValue = CountUnApprove
            m_grid(currCCIndex, 6).CellValue = CountUnStockApprove
            m_grid(currCCIndex, 7).CellValue = CountUnPO

            CountPR += 1

            CountPR = 0
            CountRemain = 0
            CountUnApprove = 0
            CountUnStockApprove = 0
            CountUnPO = 0
          End If
          'If CInt(row("remain")) > 0 Then
          m_grid.RowCount += 1
          currCCIndex = m_grid.RowCount
          If showDetail <> 0 Then
            m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currCCIndex).Font.Bold = True
          End If
          m_grid.RowStyles(currCCIndex).ReadOnly = True
          m_grid(currCCIndex, 1).CellValue = row("CCCode")
          m_grid(currCCIndex, 2).CellValue = row("CCName")
          currentCCId = row("CCId").ToString
          'End If
        End If
        If CInt(row("remain")) > 0 Then
          CountRemain += 1
          CountAll_UnRemain += 1
          If showDetail <> 0 Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 3).CellValue = ""
            m_grid(currItemIndex, 4).CellValue = row("DocCode")
            m_grid(currItemIndex, 5).CellValue = ""
            m_grid(currItemIndex, 6).CellValue = ""
            m_grid(currItemIndex, 7).CellValue = ""
          End If
          If CInt(row("ApprovePersone")) = 0 Then
            If showDetail <> 0 Then
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 3).CellValue = ""
              m_grid(currItemIndex, 5).CellValue = row("DocCode")
              m_grid(currItemIndex, 6).CellValue = ""
              m_grid(currItemIndex, 7).CellValue = ""
            End If
            CountUnApprove += 1
            CountAll_UnApprove += 1
          End If
          If CInt(row("ApproveStorePersone")) = 0 And CInt(row("ApprovePersone")) > 0 Then
            If showDetail <> 0 Then
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 3).CellValue = ""
              m_grid(currItemIndex, 6).CellValue = row("DocCode")
              m_grid(currItemIndex, 7).CellValue = ""
            End If
            CountUnStockApprove += 1
            CountAll_UnStockApprove += 1
          End If
          If CInt(row("ApprovePersone")) > 0 And CInt(row("ApproveStorePersone")) > 0 Then
            If showDetail <> 0 Then
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 7).CellValue = row("DocCode")
            End If
            CountUnPO += 1
            CountAll_UnPO += 1
          End If
        End If
        CountPR += 1
        CountAll_PR += 1
      Next
      If CountPR > 0 Then
        m_grid(currCCIndex, 3).CellValue = CountPR
        m_grid(currCCIndex, 4).CellValue = CountRemain
        m_grid(currCCIndex, 5).CellValue = CountUnApprove
        m_grid(currCCIndex, 6).CellValue = CountUnStockApprove
        m_grid(currCCIndex, 7).CellValue = CountUnPO
      End If
            m_grid.RowCount += 1
            currCCIndex = m_grid.RowCount
            m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid(currCCIndex, 2).CellValue = "รวมทั้งสิ้น"
            m_grid(currCCIndex, 3).CellValue = CountAll_PR
            m_grid(currCCIndex, 4).CellValue = CountAll_UnRemain
            m_grid(currCCIndex, 5).CellValue = CountAll_UnApprove
            m_grid(currCCIndex, 6).CellValue = CountAll_UnStockApprove
            m_grid(currCCIndex, 7).CellValue = CountAll_UnPO
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptUnorderPRItem"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnorderPRItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnorderPRItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItem.ListLabel}"
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
            Return "RptUnorderPRItem"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptUnorderPRItem"
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
                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

