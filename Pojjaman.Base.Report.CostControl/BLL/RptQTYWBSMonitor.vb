Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptQTYWBSMonitor
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
    Private m_hashData As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Style"
    Public Shared Function CreateWBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 40
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 390
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csTotalQty As New TreeTextColumn
      csTotalQty.MappingName = "TotalQuantity"
      csTotalQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalQuantityHeaderText}")
      csTotalQty.NullText = ""
      csTotalQty.DataAlignment = HorizontalAlignment.Right
      csTotalQty.Width = 120
      csTotalQty.Format = "#,###.##"
      csTotalQty.TextBox.Name = "TotalQuantity"
      csTotalQty.ReadOnly = True

      Dim csActualQty As New TreeTextColumn
      csActualQty.MappingName = "ActualQuantity"
      csActualQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualQuantityHeaderText}")
      csActualQty.NullText = ""
      csActualQty.DataAlignment = HorizontalAlignment.Right
      csActualQty.Width = 120
      csActualQty.Format = "#,###.##"
      csActualQty.TextBox.Name = "ActualQuantity"
      csActualQty.ReadOnly = True

      Dim csQtyDiff As New TreeTextColumn
      csQtyDiff.MappingName = "QuantityDiff"
      csQtyDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csQtyDiff.NullText = ""
      csQtyDiff.DataAlignment = HorizontalAlignment.Right
      csQtyDiff.Width = 120
      csQtyDiff.Format = "#,###.##"
      csQtyDiff.TextBox.Name = "QuantityDiff"
      csQtyDiff.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True


      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csBarrier0)
      dst.GridColumnStyles.Add(csTotalQty)
      dst.GridColumnStyles.Add(csActualQty)
      dst.GridColumnStyles.Add(csQtyDiff)
      dst.GridColumnStyles.Add(csUnit)

      Return dst
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QuantityDiff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSMonitorSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSMonitorTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 3
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      If m_cc Is Nothing OrElse Not m_cc.Originated Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If m_cc.BoqId = 0 Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If TypeOf Me.Filters(1).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(5).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(5).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, CDate(Me.Filters(1).Value), nodigit)
      End If
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If


      'If IsNumeric(m_grid(e.RowIndex, m_grid.ColCount).CellValue) Then
      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docType = 6
      '  docId = CInt(m_grid(e.RowIndex, m_grid.ColCount).CellValue)
      '  If docId <> 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()
      Dim dtwbs As DataTable = Me.DataSet.Tables(0)
      Dim dtMarkUp As DataTable = Me.DataSet.Tables(1)
      Dim dtDoc As DataTable = Me.DataSet.Tables(2)
      dtwbs.TableName = "Table0"
      dtMarkUp.TableName = "Table1"
      dtDoc.TableName = "Table2"
      If dtwbs.Rows.Count <= 0 Then
        Return
      End If

      Dim detail As Integer = CInt(Me.Filters(4).Value)

      Dim ValueFilter As String = ""

      If Not Me.Filters(8).Value Is Nothing AndAlso CStr(Me.Filters(8).Value).Length > 0 Then
        ValueFilter = "wbs_level = 0 Or " & CStr(Me.Filters(8).Value)
      End If

      ' WBS ##################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0
      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'แบบไม่เลือก Option WBS 
        For Each wbsrow As DataRow In dtwbs.Rows 'dtwbs.Select(ValueFilter)
          If CInt(wbsrow("wbs_level")) = 0 Then
            parentNode = dt.Childs.Add
          Else
            myParent = wbsrow("Parent")
            Try
              parentNode = Nodes(myParent).Childs.Add
            Catch ex As Exception
              'Do nothing
            End Try
          End If

          If Not parentNode Is Nothing Then
            Nodes(CStr(wbsrow("wbs_path"))) = parentNode

            'แสดงแต่ละ wbs
            tr = parentNode
            tr.Tag = wbsrow
            tr("boqi_itemname") = wbsrow("wbs_code") & "-" & wbsrow("wbs_name")
            tr.State = RowExpandState.Expanded
          End If

          If detail > 0 Then
            Dim myDoc As String = ""
            Dim Doctr As TreeRow = Nothing
            Dim DocItemTr As TreeRow = Nothing
            For Each wbsDoc As DataRow In dtDoc.Select("wbsid = " & wbsrow("wbs_id") & " and ismarkup = 0")

              If Not myDoc = CStr(wbsDoc("Doc")) Then
                'แสดงเอกสารแต่ละตัว
                tr.State = RowExpandState.Expanded
                Doctr = tr.Childs.Add
                Doctr.Tag = wbsDoc
                Doctr("boqi_itemname") = "(เอกสาร) " & CStr(wbsDoc("DocCode"))
                Doctr.State = RowExpandState.None
                myDoc = CStr(wbsDoc("Doc"))
              End If

              If detail > 1 Then
                'แสดงรายการในแต่ละเอกสาร
                If Not Doctr Is Nothing Then
                  Doctr.State = RowExpandState.Expanded
                  DocItemTr = Doctr.Childs.Add
                  DocItemTr("boqi_itemname") = wbsDoc("itemName")
                  DocItemTr("TotalQuantity") = Configuration.FormatToString(CDec(wbsDoc("QtyBudget")), dgt)
                  DocItemTr("ActualQuantity") = Configuration.FormatToString(CDec(wbsDoc("Qty")), dgt)
                  DocItemTr("QuantityDiff") = Configuration.FormatToString(CDec(wbsDoc("QtyBudget")) - CDec(wbsDoc("Qty")), dgt)
                  DocItemTr("Unit") = wbsDoc("UnitName")

                  DocItemTr.State = RowExpandState.None
                End If
              End If
             
            Next
          End If
        Next

        ' OVER HEAD ############################################################################################
        Dim overheadTemp As String = ""
        Dim overheadedtr As TreeRow = Nothing
        Dim overheadtr As TreeRow = Nothing
        Dim markuptr As TreeRow = Nothing
        overheadedtr = dt.Childs.Add
        overheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
        If dtMarkUp.Rows.Count > 0 Then
          For Each markuprow As DataRow In dtMarkUp.Select("code_tag = 0")
            'แต่ละ Over Head
            If Not overheadTemp = CStr(markuprow("code_order")) Then
              overheadtr = overheadedtr.Childs.Add
              overheadtr.Tag = markuprow
              overheadtr("boqi_itemName") = markuprow("code_description")
              overheadtr.State = RowExpandState.Expanded
              overheadTemp = CStr(markuprow("code_order"))
            End If

            'แต่ละรายการ Markup
            If Not overheadtr Is Nothing Then
              markuptr = overheadtr.Childs.Add
              markuptr.Tag = markuprow
              markuptr("boqi_itemName") = markuprow("markup_name")
              markuptr.State = RowExpandState.Expanded
            End If

            'รายการแต่ละเอกสารในแต่ละ Markup
            If detail > 0 Then
              Dim myTempDoc As String = ""
              Dim DocMarkuptr As TreeRow = Nothing
              Dim DocMarkupItemTr As TreeRow = Nothing

              For Each markupdocrow As DataRow In dtDoc.Select("wbsid = " & markuprow("markup_id") & " and ismarkup = 1")
                If Not myTempDoc = CStr(markupdocrow("DocId")) Then
                  'แสดงเอกสารแต่ละตัว
                  DocMarkuptr = markuptr.Childs.Add
                  DocMarkuptr.Tag = markupdocrow
                  DocMarkuptr("boqi_itemname") = markupdocrow("DocCode")
                  DocMarkuptr.State = RowExpandState.Expanded
                  myTempDoc = CStr(markupdocrow("DocId"))
                End If

                If detail > 1 Then
                  If Not DocMarkuptr Is Nothing Then
                    'แสดงรายการในแต่ละเอกสาร
                    DocMarkupItemTr = DocMarkuptr.Childs.Add
                    DocMarkupItemTr("boqi_itemname") = markupdocrow("itemName")
                    DocMarkupItemTr("Unit") = markupdocrow.IsNull("UnitName")
                    DocMarkupItemTr("TotalQuantity") = Configuration.FormatToString(CDec(markupdocrow("QtyBudget")), dgt)
                    DocMarkupItemTr("ActualQuantity") = Configuration.FormatToString(CDec(markupdocrow("Qty")), dgt)
                    DocMarkupItemTr("QuantityDiff") = Configuration.FormatToString(CDec(markupdocrow("QtyBudget")) - CDec(markupdocrow("Qty")), dgt)

                    DocMarkupItemTr.State = RowExpandState.None
                  End If
                End If
              Next
            End If
          Next

        End If

        overheadedtr.State = RowExpandState.Expanded

        'TOTAL #################################################################################################
        Dim totalNode As TreeRow = dt.Childs.Add
        totalNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Total}")
        totalNode.State = RowExpandState.Expanded

        'PROFIT ################################################################################################
        Dim profitheadedtr As TreeRow = Nothing
        Dim profitheadtr As TreeRow = Nothing
        Dim itemtr As TreeRow = Nothing

        profitheadedtr = dt.Childs.Add
        profitheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Profit}" & "<ประเมิน>")

        If dtMarkUp.Rows.Count > 0 Then
          For Each profitrow As DataRow In dtMarkUp.Select("code_tag = 1")
            profitheadtr = profitheadedtr.Childs.Add
            profitheadtr("boqi_itemName") = profitrow("markup_name")
            profitheadtr.State = RowExpandState.Expanded
          Next
        End If

        profitheadedtr.State = RowExpandState.Expanded

        'NET PROFIT ############################################################################################
        Dim netNode As TreeRow = dt.Childs.Add
        netNode("boqi_itemName") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ")
        netNode.State = RowExpandState.Expanded


        Dim i As Integer = 0
        m_hashData = New Hashtable
        For Each row As TreeRow In dt.Rows
          i += 1
          row("boqi_linenumber") = i
          If Not row.Tag Is Nothing Then
            m_hashData(i) = row.Tag
          End If
        Next
        If i > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(stage & vbCrLf & ex.Message)
      End Try

    End Sub
    Public Overrides Sub RefreshDataSet()
      m_cc = New CostCenter
      If TypeOf Me.Filters(0).Value Is CostCenter Then
        m_cc = CType(Me.Filters(0).Value, CostCenter)
      End If
      'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
      If Not Me.Filters(0).Value Is DBNull.Value Then
        Me.Filters(0).Value = m_cc.Id
      End If
      If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
        Me.Filters(6).Value = Me.Filters(6).Value.Id
      End If
      '
      If Not m_cc Is Nothing AndAlso m_cc.Originated Then
        MyBase.RefreshDataSet()
      End If
    End Sub
#End Region

#Region "Select Distinct From DataTable"
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
      Dim areEqual As Boolean = True

      For i As Integer = 0 To fieldNames.Length - 1
        If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
          areEqual = False
          Exit For
        End If
      Next

      Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
      For Each field As String In fieldNames
        newRow(field) = sourceRow(field)
      Next

      Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
      For i As Integer = 0 To fieldNames.Length - 1
        lastValues(i) = sourceRow(fieldNames(i))
      Next
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptQTYWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptQTYWBSMonitor.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptQTYWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptQTYWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptQTYWBSMonitor.ListLabel}"
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
    Public Property AdvanceFindCollection() As AdvanceFindCollection

#End Region

#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCode"
      dpi.Value = m_cc.Code  'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = m_cc.Name 'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If Not IsDBNull(Me.Filters(1).Value) Then
        dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim typeString As String = ""
      Dim type As BOQ.WBSReportType
      If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
        type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
      End If
      Select Case type
        Case BOQ.WBSReportType.PR
          typeString = "ขอซื้อ"
        Case BOQ.WBSReportType.PO
          typeString = "สั่งซื้อ"
        Case BOQ.WBSReportType.GoodsReceipt
          typeString = "รับของ"
        Case BOQ.WBSReportType.MatWithdraw
          typeString = "เบิกของ"
      End Select
      dpi = New DocPrintingItem
      dpi.Mapping = "Type"
      dpi.Value = typeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "Requester"
      If Not IsDBNull(Me.Filters(6).Value) Then
        dpi.Value = New Employee(CInt(Me.Filters(6).Value)).Name
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim i As Integer = 0
      Dim r As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        For j As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & j
          dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        r = i + 1
        Dim dr As Object = m_hashData(r)
        If Not dr Is Nothing Then
          If TypeOf dr Is DataRow Then
            Dim row As DataRow = CType(dr, DataRow)
            If row.Table.TableName = "Table0" Then
              Dim drh As New DataRowHelper(row)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.1"
              dpi.Value = drh.GetValue(Of String)("wbs_code")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.2"
              dpi.Value = drh.GetValue(Of String)("wbs_name")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            End If
          End If
        End If

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

