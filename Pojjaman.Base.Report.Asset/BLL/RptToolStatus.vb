Option Explicit On
Option Strict On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptToolStatus
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
      m_grid.ColCount = 13

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 100
      m_grid.ColWidths(13) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolCode}") '"รหัสเครื่องมือ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolName}") '"ชื่อเครื่องมือ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.OwnerCC}") '"CCเจ้าของ"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.Rentalrate}") '"ค่าเช่าต่อวัน"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Unit}") '"หน่วย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Active}") '"Active"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Available}") '"ว่าง"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Withdraw}") '"เบิก"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Rent}") '"ให้เช่า"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.WaitingForRepair}") '"รอซ่อม"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.SendRepair}") '"ส่งซ่อม"
      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Damaged}") '"ชำรุดพัง"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.Lost}") '"หาย"
      'm_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.currentCC}") '"CCที่อยู่"

      Dim indent As String = Space(1)
      'm_grid.RowStyles().ReadOnly = True
      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dtqty As DataTable = Me.DataSet.Tables(1)

      Dim qtystaus As New Dictionary(Of String, Integer)

      For Each r As DataRow In dtqty.Rows
        Dim rh As New DataRowHelper(r)
        Dim key As String = rh.GetValue(Of Integer)("toolid").ToString & "|" & rh.GetValue(Of Integer)("tostatus")

        qtystaus.Add(key, rh.GetValue(Of Integer)("Qty"))
      Next

      Dim ccCode As String = ""
      Dim assetCode As String = ""
      Dim currentAssetTypeCode As String = ""
      Dim sumAssetTypeWithdtaw As Decimal = 0
      Dim sumAssetTypeReturn As Decimal = 0
      Dim currentAssetCode As String = ""
      Dim sumAssetWithdtaw As Decimal = 0
      Dim sumAssetReturn As Decimal = 0
      Dim sentAsset As Decimal = 0
      Dim currentDocCode As String = ""
      Dim currentCC As String = ""
      Dim bReturn As Decimal = 0
      Dim currentSum As String = ""
      Dim currAssetTypeIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currCcIndex As Integer = -1
      Dim sumWithdtaw As Decimal = 0
      Dim sumReturn As Decimal = 0
      Dim sum1 As Decimal = 0
      Dim sum2 As Decimal = 0
      'Dim indent As String = Space(3)
      Dim no As Integer = 0
      Dim no1 As Integer = 0

      Dim ct As DataTable = CodeDescription.GetCodeList("eqtstatus", "code_value not in (0,1,9,10)")

      For Each row As DataRow In dt.Rows
        Dim drh As New DataRowHelper(row)

        If drh.GetValue(Of String)("toolg_code") <> currentAssetTypeCode Then
          If Not (currentAssetTypeCode = "") Then
            no = 1
          End If
          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          m_grid(currAssetTypeIndex, 1).CellValue = drh.GetValue(Of String)("toolg_code")
          m_grid(currAssetTypeIndex, 2).CellValue = drh.GetValue(Of String)("toolg_Name")
          currentAssetTypeCode = drh.GetValue(Of String)("toolg_code")

        End If
        If drh.GetValue(Of String)("tool_code") <> currentAssetCode Then

          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).CellValue = "  " & drh.GetValue(Of String)("tool_code")
          m_grid(currDocIndex, 2).CellValue = "  " & drh.GetValue(Of String)("tool_name")
          currentAssetCode = drh.GetValue(Of String)("tool_code")
        End If

        'sumAssetWithdtaw += Withdtaw
        sumAssetReturn = bReturn
        'sumAssetTypeWithdtaw += Withdtaw
        sumAssetTypeReturn = bReturn
        currCcIndex = m_grid.RowCount
        'sum1 += Withdtaw
        'sum2 += bReturn
        m_grid.RowStyles(currCcIndex).ReadOnly = True
        m_grid(currCcIndex, 3).CellValue = drh.GetValue(Of String)("Costcenter")
        m_grid(currCcIndex, 4).CellValue = "  " & Configuration.FormatToString(drh.GetValue(Of Decimal)("tool_rentalrate"), DigitConfig.Price)
        m_grid(currCcIndex, 5).CellValue = drh.GetValue(Of String)("unit_name")

        Dim active As Integer = 0
        Dim id As String = drh.GetValue(Of Integer)("tool_id").ToString

        Dim i As Integer = 7
        For Each sr As DataRow In ct.Rows
          Dim key As String = id & "|" & CInt(sr("code_value")).ToString
          Dim val As Integer = 0
          If qtystaus.ContainsKey(key) Then
            val = qtystaus.Item(key)
          End If
          m_grid(currCcIndex, i).CellValue = Configuration.FormatToString(val, DigitConfig.Qty)
          active += val
          i += 1
        Next

        

        m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(active, DigitConfig.Qty)

      Next

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptToolStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptToolStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptToolStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ListLabel}"
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
      Return "RptToolStatus"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptToolStatus"
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

        For i As Integer = 8 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (i - 1).ToString
          dpi.Value = m_grid(rowIndex, i).CellValue
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

