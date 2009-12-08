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
  Public Class RptMatWithdrawByCC
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
    Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
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

      m_grid.ColWidths(1) = 200
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 80
      m_grid.ColWidths(5) = 200
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 80
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.FromCostCenter}") '"Cost Center ผู้ให้เบิก"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Name}") '"ชื่อวัสดุ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.AmountInCC}") '"จำนวนรับทั้งหมด"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Unit}")   '"หน่วย"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.ToCostCenter}") '"Cost Center ผู้ขอเบิก"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.DocCode}") '"เลขที่ใบเบิก"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.DocDate}") '"วันที่เบิก"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Amount}")  '"จำนวน"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Unit}")  '"หน่วย"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.RemainingAmount}") '"จำนวนคงเหลือ"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Note}") '"หมายเหตุ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim indent As String = Space(3)

      Dim sumRemaining As Decimal = 0
      Dim sumGrossToCC As Decimal = 0
      Dim sumGrossWithdraw As Decimal = 0

      Dim currentFromCC As String = ""
      Dim currFromCCIndex As Integer = -1
      For Each row As DataRow In dt.Rows
        If row("FromCCCode").ToString & row("FromCCName").ToString <> currentFromCC Then

          m_grid.RowCount += 1
          currFromCCIndex = m_grid.RowCount
          m_grid.RowStyles(currFromCCIndex).ReadOnly = True
          m_grid(currFromCCIndex, 1).CellValue = row("FromCCCode").ToString & " : " & row("FromCCName").ToString
          currentFromCC = row("FromCCCode").ToString & row("FromCCName").ToString

          Dim currLciIndex As Integer = -1
          Dim currentLCI As String = ""
          For Each lcirow As DataRow In dt.Select("FromCCCode='" & row("FromCCCode").ToString & "'")
            If lcirow("lci").ToString <> currentLCI Then
              If currLciIndex <> -1 Then
                m_grid.RowCount += 1
              End If
              currLciIndex = m_grid.RowCount
              m_grid.RowStyles(currLciIndex).ReadOnly = True
              m_grid(currLciIndex, 2).CellValue = lcirow("lcicode").ToString & " : " & lcirow("lciname").ToString
              m_grid(currLciIndex, 3).CellValue = Configuration.FormatToString(CDec(lcirow("qtyincc")), DigitConfig.Qty)
              m_grid(currLciIndex, 4).CellValue = lcirow("defaultunit").ToString
              currentLCI = lcirow("lci").ToString

              sumRemaining = CDec(lcirow("qtyincc"))
              sumGrossWithdraw = 0

              Dim currToCCIndex As Integer = -1
              Dim currentToCC As String = ""
              For Each cctorow As DataRow In dt.Select("FromCCCode='" & row("FromCCCode").ToString & "' and lci='" & lcirow("lci").ToString & "'")
                If cctorow("ToCCCode").ToString & cctorow("ToCCName").ToString <> currentToCC Then
                  If currToCCIndex <> -1 Then
                    m_grid.RowCount += 1
                  End If
                  currToCCIndex = m_grid.RowCount
                  m_grid.RowStyles(currToCCIndex).ReadOnly = True
                  m_grid(currToCCIndex, 5).CellValue = cctorow("ToCCCode").ToString & " : " & cctorow("ToCCName").ToString
                  currentToCC = cctorow("ToCCCode").ToString & cctorow("ToCCName").ToString

                  Dim currDocIndex As Integer = -1
                  Dim currentDoc As String = ""
                  For Each docitem As DataRow In dt.Select("FromCCCode='" & row("FromCCCode").ToString & "' and lci='" & lcirow("lci").ToString & "' " & _
                                                          " and tocccode = '" & cctorow("ToCCCode").ToString & "'")
                    If currentDoc <> docitem("doccode").ToString Then
                      If currDocIndex <> -1 Then
                        m_grid.RowCount += 1
                      End If
                      currDocIndex = m_grid.RowCount
                      m_grid.RowStyles(currDocIndex).ReadOnly = True
                      m_grid(currDocIndex, 6).CellValue = docitem("doccode").ToString
                      If Not docitem.IsNull("docdate") Then
                        m_grid(currDocIndex, 7).CellValue = CDate(docitem("docdate")).ToShortDateString
                      End If
                      currentDoc = docitem("doccode").ToString

                    End If

                    sumRemaining -= CDec(docitem("withdrawqty"))
                    sumGrossWithdraw += CDec(docitem("withdrawqty"))

                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(docitem("withdrawqty")), DigitConfig.Price)
                    m_grid(currDocIndex, 9).CellValue = docitem("unitname").ToString
                    m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumRemaining, DigitConfig.Price)
                    m_grid(currDocIndex, 11).CellValue = docitem("itemnote").ToString
                  Next
                End If
              Next

              m_grid.RowCount += 1
              currLciIndex = m_grid.RowCount
              m_grid.RowStyles(currLciIndex).Font.Bold = True
              m_grid.RowStyles(currLciIndex).ReadOnly = True
              m_grid(currLciIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.Total}")
              m_grid(currLciIndex, 8).CellValue = Configuration.FormatToString(sumGrossWithdraw, DigitConfig.Price)
              m_grid(currLciIndex, 10).CellValue = Configuration.FormatToString(sumRemaining, DigitConfig.Price)

            End If
          Next

        End If
      Next
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptMatWithdrawByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdrawByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdrawByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdrawByCC.ListLabel}"
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
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        Dim font As font
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If
        For colIndex As Integer = 1 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (colIndex - 1).ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.Font = font
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        n += 1
      Next
      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

