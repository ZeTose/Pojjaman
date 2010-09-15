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
  Public Class RptAPOpeningBalance
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
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim dr As DataRow = Me.m_grid(e.RowIndex, 0).Tag
      If dr Is Nothing Then
        Return
      End If
      Dim drh As New DataRowHelper(dr)
      Dim docId As Integer = drh.GetValue(Of Integer)("stock_id")
      Dim docType As Integer = 15

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub

    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 5

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.APID}")        '"รหัสลูกหนี้"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.APName}")         '"ชื่อลูกหนี้"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.DocDate}")    '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.DocID}")      '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.CreditPeroid}")   '"เครดิต(วัน)"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.DueDate}")    '"วันที่ครบกำหนด"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.Amount}")     '"รวมทั้งสิ้น"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentSupplierCode As String = ""
      Dim currentDocCode As String = ""
      Dim tmpTotalAmount As Decimal = 0

      Dim currentSupplierIndex As Integer = -1
      Dim currentDocIndex As Integer = -1
      Dim indent As String = Space(3)
      For Each row As DataRow In dt.Rows
        If row("SupplierCode").ToString <> currentSupplierCode Then
          If Not currentSupplierCode = "" Then
            If currentSupplierIndex <> -1 Then
              m_grid(currentSupplierIndex, 5).Text = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)
            End If
          End If
          m_grid.RowCount += 1
          currentSupplierIndex = m_grid.RowCount
          m_grid.RowStyles(currentSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currentSupplierIndex).Font.Bold = True
          m_grid.RowStyles(currentSupplierIndex).ReadOnly = True

          m_grid(currentSupplierIndex, 1).CellValue = row("SupplierCode")
          m_grid(currentSupplierIndex, 2).CellValue = row("SupplierName")
          currentSupplierCode = row("SupplierCode").ToString
          currentDocCode = ""
          tmpTotalAmount = 0
          'SupplierTr.State = RowExpandState.Expanded
        End If
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currentDocIndex = m_grid.RowCount
          m_grid.RowStyles(currentDocIndex).ReadOnly = True
          m_grid(currentDocIndex, 0).Tag = row

          m_grid(currentDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          If Not row.IsNull("DocCode") Then
            m_grid(currentDocIndex, 2).CellValue = indent & row("DocCode").ToString
          End If
          If IsNumeric(row("creditPeriod")) Then
            m_grid(currentDocIndex, 3).CellValue = indent & CDec(row("CreditPeriod"))
          End If
          If IsDate(row("DueDate")) Then
            m_grid(currentDocIndex, 4).CellValue = indent & CDate(row("DueDate")).ToShortDateString
          End If
          If IsNumeric(row("APOpeningBalance")) Then
            m_grid(currentDocIndex, 5).Text = indent & Configuration.FormatToString(CDec(row("APOpeningBalance")), DigitConfig.Price)
            tmpTotalAmount += CDec(row("APOpeningBalance"))
          End If
          currentDocCode = row("DocCode").ToString
        End If
      Next

      If currentSupplierIndex <> -1 Then
        m_grid(currentSupplierIndex, 5).Text = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPOpeningBalance.ListLabel}"
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

      Dim i As Integer = 0
      Dim SumTotal As Decimal = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        Dim level As Integer = 0
        'ชื่อผู้มีภาษีเงินได้
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          dpi.Value = m_grid(rowIndex, 1).Text
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          level = 0
        Else
          dpi.Value = "     " & m_grid(rowIndex, 1).Text
          level = 1
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpi.Level = level
        dpiColl.Add(dpi)

        'Item.Invoice
        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          dpi.Value = m_grid(rowIndex, 2).Text
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          level = 0
        Else
          dpi.Value = "     " & m_grid(rowIndex, 2).Text
          level = 1
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpi.Level = level
        dpiColl.Add(dpi)

        'Item.doccode
        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          level = 0
        Else
          level = 1
        End If
        dpi.Value = m_grid(rowIndex, 3).Text
        dpi.DataType = "System.Integer"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpi.Level = level
        dpiColl.Add(dpi)

        'Item.printname
        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          level = 0
        Else
          level = 1
        End If
        dpi.Value = m_grid(rowIndex, 4).Text
        dpi.DataType = "System.Integer"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpi.Level = level
        dpiColl.Add(dpi)

        'Item.suppliercode
        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        If m_grid.RowStyles(rowIndex).Font.Bold Then
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          level = 0
        Else
          level = 1
          If IsNumeric(m_grid(rowIndex, 5).CellValue) Then
            SumTotal += CDec(m_grid(rowIndex, 5).CellValue)
          End If
        End If
        dpi.Value = m_grid(rowIndex, 5).Text
        dpi.DataType = "System.Integer"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpi.Level = level
        dpiColl.Add(dpi)
        i += 1
      Next

      'SumText
      dpi = New DocPrintingItem
      dpi.Mapping = "SumText"
      dpi.Value = "รวม"
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol4
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol4"
      dpi.Value = Configuration.FormatToString(SumTotal, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

