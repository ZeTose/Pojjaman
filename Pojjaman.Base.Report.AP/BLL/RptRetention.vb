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
  Public Class RptRetention
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
      m_grid.RowCount = 2
      m_grid.ColCount = 10

      m_grid.ColWidths(1) = 150
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 150
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 200
      m_grid.ColWidths(8) = 200
      m_grid.ColWidths(9) = 200
      m_grid.ColWidths(10) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierCode}")  '"รหัสผู้รับเหมา"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SupplierName}") '"ชื่อผู้รับเหมา"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}") '"มูลค่าตามเอกสาร"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}") '"รวม Retention"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}") '"รวมมูลค่าชำระ"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}") '"รวมมูลค่าค้างชำระ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCCode}")  '"รหัสโครงการ"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.CCName}")  '"ชื่อโครงการ"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGrossAmount}")   '"รวมมูลค่าตามเอกสาร"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumGRRetention}")  '"รวม Retention"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysAmount}")  '"รวมมูลค่าชำระ"           
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.SumPaysBalance}")  '"รวมมูลค่าค้างชำระ"

      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocDate}")  '"วันที่ซื้อสินค้า/บริการ"
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DocCode}")  '"เลขที่เอกสาร"
      m_grid(2, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"
      m_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GrossAmount}")   '"มูลค่าตามเอกสาร"
      m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.GRRetention}")  '"มูลค่า Retention"
      m_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysAmount}")  '"มูลค่าชำระ"
      m_grid(2, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDate}")  '"วันที่จ่ายคืน Retention"
      m_grid(2, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysDocCode}")  '"เลขที่เอกสารจ่าย"
      m_grid(2, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaymentDocCode}")  '"เลขที่ PV"
      m_grid(2, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptRetention.PaysBalance}")  '"มูลค่าค้างชำระ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)

      Dim currSupplierCode As String = ""
      Dim currCostCenterCode As String = ""
      Dim currentItemCode As String = ""
      Dim currSupplierIndex As Integer = -1
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumGrossAmt_Supplier As Decimal = 0
      Dim sumGrossAmt_Costcenter As Decimal = 0
      Dim sumRetention_Supplier As Decimal = 0
      Dim sumRetention_Costcenter As Decimal = 0
      Dim sumRetentionPays_Supplier As Decimal = 0
      Dim sumRetentionPays_Costcenter As Decimal = 0
      Dim sumPaysBalance_Supplier As Decimal = 0
      Dim sumPaysBalance_Costcenter As Decimal = 0

      Dim tmpRetention As Decimal
      Dim tmpPaysBalance As Decimal
      Dim sumPaysBalance As Decimal = 0
      For Each row As DataRow In dt.Rows
        Try
          'New Supplier
          If Not currSupplierCode.Equals(row("Supplier_Code").ToString) Then
            currSupplierCode = row("Supplier_Code").ToString
            m_grid.RowCount += 1
            currSupplierIndex = m_grid.RowCount
            m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currSupplierIndex).Font.Bold = True
            m_grid.RowStyles(currSupplierIndex).ReadOnly = True
            m_grid(currSupplierIndex, 1).CellValue = row("Supplier_Code")
            m_grid(currSupplierIndex, 2).CellValue = row("Supplier_Name")
            m_grid(currSupplierIndex, 1).Tag = "Supplier"

            'First New CostCenter
            currCostCenterCode = row("CC_Code").ToString
            m_grid.RowCount += 1
            currCostCenterIndex = m_grid.RowCount
            m_grid.RowStyles(currCostCenterIndex).BackColor = Color.AntiqueWhite
            m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
            m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
            m_grid(currCostCenterIndex, 1).CellValue = indent & row("CC_Code").ToString
            m_grid(currCostCenterIndex, 2).CellValue = indent & row("CC_Name").ToString
            m_grid(currCostCenterIndex, 1).Tag = "CostCenter"

            sumGrossAmt_Supplier = 0
            sumGrossAmt_Costcenter = 0
            sumRetention_Supplier = 0
            sumRetention_Costcenter = 0
            sumRetentionPays_Supplier = 0
            sumRetentionPays_Costcenter = 0
            sumPaysBalance_Supplier = 0
            sumPaysBalance_Costcenter = 0
            
          Else
            If Not currCostCenterCode.Equals(row("CC_Code").ToString) Then
              currCostCenterCode = row("CC_Code").ToString

              'New CostCenter
              m_grid.RowCount += 1
              currCostCenterIndex = m_grid.RowCount
              m_grid.RowStyles(currCostCenterIndex).BackColor = Color.AntiqueWhite
              m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
              m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
              m_grid(currCostCenterIndex, 1).CellValue = indent & row("CC_Code").ToString
              m_grid(currCostCenterIndex, 2).CellValue = indent & row("CC_Name").ToString
              m_grid(currCostCenterIndex, 1).Tag = "CostCenter"

              sumGrossAmt_Costcenter = 0
              sumRetention_Costcenter = 0
              sumRetentionPays_Costcenter = 0
              sumPaysBalance_Costcenter = 0
            End If
          End If

          'PUR Items
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("Stock_DocDate") Then
            m_grid(currItemIndex, 1).CellValue = indent & indent & CDate(row("Stock_DocDate")).ToShortDateString
          End If
          If Not row.IsNull("Stock_Code") Then
            m_grid(currItemIndex, 2).CellValue = indent & indent & row("Stock_Code").ToString
          End If
          If Not row.IsNull("Stock_pvrv") Then
            m_grid(currItemIndex, 3).CellValue = indent & indent & row("Stock_pvrv").ToString
          End If
          If IsNumeric(row("Stock_Aftertax")) Then
            m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Stock_Aftertax")), DigitConfig.Price)
            sumGrossAmt_Supplier += CDec(row("Stock_Aftertax"))
            sumGrossAmt_Costcenter += CDec(row("Stock_Aftertax"))
          End If
          If IsNumeric(row("Stock_Retention")) Then
            tmpRetention = CDec(row("Stock_Retention"))
            sumRetention_Supplier += tmpRetention
            sumRetention_Costcenter += tmpRetention
          End If
          If tmpRetention <> 0 Then
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(tmpRetention, DigitConfig.Price)
          End If

          Dim tmpSumPaysItem As Decimal = 0
          Dim tmpPaysDate As String = ""
          Dim tmpPaysCode As String = ""
          Dim tmpPaymentCode As String = ""
          For Each row2 As DataRow In dt2.Select("Supplier_Code='" & row("Supplier_Code").ToString & _
                                                  "' And Stock_Code='" & row("Stock_Code").ToString & "'")
            If IsNumeric(row2("Pays_Gross")) Then
              tmpSumPaysItem += CDec(row2("Pays_Gross"))
            End If
            If Not row2.IsNull("Pays_DocDate") Then
              tmpPaysDate &= "," & CDate(row2("Pays_DocDate")).ToShortDateString
            End If
            If Not row2.IsNull("Pays_Code") Then
              tmpPaysCode &= "," & row2("Pays_Code").ToString
            End If
            If Not row2.IsNull("Payment_Code") Then
              tmpPaymentCode &= "," & row2("Payment_Code").ToString
            End If
          Next

          If tmpSumPaysItem > 0 Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpSumPaysItem, DigitConfig.Price)
            sumRetentionPays_Supplier += tmpSumPaysItem
            sumRetentionPays_Costcenter += tmpSumPaysItem

          End If

          If tmpPaysDate.Length > 1 Then
            m_grid(currItemIndex, 7).CellValue = tmpPaysDate.Substring(1)
          End If
          If tmpPaysCode.Length > 1 Then
            m_grid(currItemIndex, 8).CellValue = tmpPaysCode.Substring(1)
          End If
          If tmpPaymentCode.Length > 1 Then
            m_grid(currItemIndex, 9).CellValue = tmpPaymentCode.Substring(1)
          End If

          tmpPaysBalance = tmpRetention - tmpSumPaysItem
          If tmpPaysBalance <> 0 Then
            m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(tmpPaysBalance, DigitConfig.Price)
            sumPaysBalance_Supplier += tmpPaysBalance
            sumPaysBalance_Costcenter += tmpPaysBalance
            sumPaysBalance += tmpPaysBalance
          End If

          If sumGrossAmt_Supplier <> 0 Then
            m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(sumGrossAmt_Supplier, DigitConfig.Price)
          End If
          If sumGrossAmt_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 4).CellValue = Configuration.FormatToString(sumGrossAmt_Costcenter, DigitConfig.Price)
          End If

          If sumRetention_Supplier <> 0 Then
            m_grid(currSupplierIndex, 5).CellValue = Configuration.FormatToString(sumRetention_Supplier, DigitConfig.Price)
          End If
          If sumRetention_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 5).CellValue = Configuration.FormatToString(sumRetention_Costcenter, DigitConfig.Price)
          End If

          If sumRetentionPays_Supplier <> 0 Then
            m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(sumRetentionPays_Supplier, DigitConfig.Price)
          End If
          If sumRetentionPays_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 6).CellValue = Configuration.FormatToString(sumRetentionPays_Costcenter, DigitConfig.Price)
          End If

          If sumPaysBalance_Supplier <> 0 Then
            m_grid(currSupplierIndex, 10).CellValue = Configuration.FormatToString(sumPaysBalance_Supplier, DigitConfig.Price)
          End If
          If sumPaysBalance_Costcenter <> 0 Then
            m_grid(currCostCenterIndex, 10).CellValue = Configuration.FormatToString(sumPaysBalance_Costcenter, DigitConfig.Price)
          End If
        Catch ex As Exception
          MessageBox.Show(ex.ToString & vbCrLf & ex.StackTrace)
        End Try
      Next
      'sumPaysBalance
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(143, 197, 185)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 9).CellValue = "รวม"
      m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(sumPaysBalance, DigitConfig.Price)

    End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptRetention.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptRetention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptRetention.ListLabel}"
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
      Return "RptRetention"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptRetention"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
        Dim fn As System.Drawing.Font
        If m_grid(rowIndex, 1).Tag = "Supplier" OrElse m_grid(rowIndex, 1).Tag = "CostCenter" Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

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

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

