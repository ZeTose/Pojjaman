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
Imports System.Text.RegularExpressions
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptWBSMonitor2
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
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

      Dim csCol1 As New PlusMinusTreeTextColumn
      csCol1.MappingName = "Col1"
      csCol1.HeaderText = "PCA Code"
      csCol1.NullText = ""
      csCol1.Width = 150
      csCol1.ReadOnly = True
      dst.GridColumnStyles.Add(csCol1)

      Dim csCol2 As New TreeTextColumn
      csCol2.MappingName = "Col2"
      csCol2.HeaderText = "PCA Description"
      csCol2.NullText = ""
      csCol2.DataAlignment = HorizontalAlignment.Left
      csCol2.Width = 250
      csCol2.ReadOnly = True
      dst.GridColumnStyles.Add(csCol2)

      Dim arr As New ArrayList
      arr.Add("Expense up to last period")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("Expense up to last period")
      arr.Add("Expense this period")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("Expense this period")
      arr.Add("Total Expense")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      arr.Add("Total Expense")
      arr.Add("Budget Remain")
      arr.Add("Document")

      For i As Integer = 3 To 26
        Dim cs As New TreeTextColumn
        cs.MappingName = "Col" & i.ToString
        cs.HeaderText = arr(i - 3)
        cs.NullText = ""
        cs.DataAlignment = HorizontalAlignment.Right
        cs.Format = "#,###.##"
        cs.Width = 150
        cs.ReadOnly = True
        dst.GridColumnStyles.Add(cs)
      Next

      Return dst
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      For i As Integer = 1 To 26
        myDatatable.Columns.Add(New DataColumn("Col" & i.ToString, GetType(String)))
      Next
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
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() { _
      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 1, 1) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 2, 1, 2) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 3, 0, 9) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 10, 1, 10) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 11, 0, 16) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 17, 1, 17) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 18, 0, 23) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 24, 1, 24) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 25, 1, 25) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 26, 1, 26) _
      })
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 2
      lkg.Rows.HeaderCount = 1
      lkg.Rows.FrozenCount = 1
      lkg.HilightGroupParentText = True
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
      If TypeOf Me.Filters(2).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(4).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(4).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, CDate(Me.Filters(2).Value), nodigit)
      End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()

      Dim arr As New ArrayList
      arr.Add("")
      arr.Add("")
      arr.Add("budget")
      arr.Add("material")
      arr.Add("labour")
      arr.Add("equipment")
      arr.Add("sub contract")
      arr.Add("hire service")
      arr.Add("others")
      arr.Add("")
      arr.Add("material")
      arr.Add("labour")
      arr.Add("equipment")
      arr.Add("sub contract")
      arr.Add("hire service")
      arr.Add("others")
      arr.Add("")
      arr.Add("material")
      arr.Add("labour")
      arr.Add("equipment")
      arr.Add("sub contract")
      arr.Add("hire service")
      arr.Add("others")
      arr.Add("")
      arr.Add("")
      arr.Add("")
      Dim headNode As TreeRow = dt.Childs.Add
      For i As Integer = 0 To 25
        headNode(i) = arr(i)
      Next

      Dim dt_0 As DataTable = Me.DataSet.Tables(0)
      Dim dt_2 As DataTable = Me.DataSet.Tables(2)
      If dt_0.Rows.Count <= 0 Then
        Return
      End If

      ' WBS ##################################################################################################
      '#######################################################################################################
      Dim ParentNodes As New Hashtable
      Dim myParent As String
      Dim myTempId As Integer = 0
      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'แบบไม่เลือก Option WBS 
        Dim sys As String = ""

        Dim ccRow As TreeRow
        Dim mepRow As TreeRow
        Dim civilRow As TreeRow

        If Me.Filters(1).Name.ToLower = "system" Then
          sys = CStr(Me.Filters(1).Value)
          If sys.ToLower = "all" Then
            ccRow = dt.Childs.Add ' MCQ
            ccRow("Col1") = m_cc.Code
            ccRow("Col2") = m_cc.Name
            ccRow.State = RowExpandState.Expanded
            ParentNodes(m_cc.Code) = ccRow

            mepRow = ccRow.Childs.Add ' MEP
            mepRow("Col1") = "MEP"
            mepRow("Col2") = "MEP SYSTEM"
            mepRow.State = RowExpandState.Expanded
            ParentNodes("MEP") = mepRow

            civilRow = ccRow.Childs.Add ' CIVIL
            civilRow("Col1") = "CIVIL"
            civilRow("Col2") = "CIVIL SYSTEM"
            civilRow.State = RowExpandState.Expanded
            ParentNodes("CIVIL") = civilRow
          End If
        End If
        Dim reg As New Regex("6000")
        For Each wbsrow As DataRow In dt_0.Rows 'Table 0
          If CInt(wbsrow("wbs_level")) > 1 OrElse (CInt(wbsrow("wbs_level")) = 1 AndAlso reg.IsMatch(CStr(wbsrow("wbs_code")))) Then
            Dim theNode As TreeRow = Nothing
            If CInt(wbsrow("wbs_level")) = 2 OrElse _
             (CInt(wbsrow("wbs_level")) = 1 AndAlso reg.IsMatch(CStr(wbsrow("wbs_code")))) Then
              theNode = dt.Childs.Add
            Else
              myParent = wbsrow("parent_code")
              Try
                theNode = ParentNodes(myParent).Childs.Add
              Catch ex As Exception

              End Try
            End If

            If Not theNode Is Nothing Then
              ParentNodes(CStr(wbsrow("wbs_code"))) = theNode

              'แสดงแต่ละ wbs
              tr = theNode
              tr("Col1") = wbsrow("wbs_code")
              tr("Col2") = wbsrow("wbs_name")

              Dim budget As Decimal = CDec(wbsrow("wbs_budget"))
              Dim matactual As Decimal = CDec(wbsrow("matactual"))
              Dim labactual As Decimal = CDec(wbsrow("labactual"))
              Dim eqactual As Decimal = CDec(wbsrow("eqactual"))
              Dim subcon As Decimal = CDec(wbsrow("sub"))
              Dim other As Decimal = CDec(wbsrow("other"))
              Dim hire As Decimal = CDec(wbsrow("hire"))
              Dim total As Decimal = 0
              If Not wbsrow.IsNull("totalactual") Then
                total += wbsrow("totalactual")
              End If
              If Not wbsrow.IsNull("totalactual2") Then
                total += wbsrow("totalactual2")
              End If

              Dim currmatactual As Decimal = CDec(wbsrow("currmatactual"))
              Dim currlabactual As Decimal = CDec(wbsrow("currlabactual"))
              Dim curreqactual As Decimal = CDec(wbsrow("curreqactual"))
              Dim currsubcon As Decimal = CDec(wbsrow("currsub"))
              Dim currother As Decimal = CDec(wbsrow("currother"))
              Dim currhire As Decimal = CDec(wbsrow("currhire"))
              Dim currtotal As Decimal = 0
              If Not wbsrow.IsNull("currtotalactual") Then
                currtotal += wbsrow("currtotalactual")
              End If
              If Not wbsrow.IsNull("currtotalactual2") Then
                currtotal += wbsrow("currtotalactual2")
              End If

              tr("Col3") = Configuration.FormatToString(budget, dgt)

              '-----------------------
              tr("Col4") = Configuration.FormatToString(matactual, dgt)
              tr("Col5") = Configuration.FormatToString(labactual, dgt)
              tr("Col6") = Configuration.FormatToString(eqactual, dgt)
              tr("Col7") = Configuration.FormatToString(subcon, dgt)
              tr("Col8") = Configuration.FormatToString(hire, dgt)
              tr("Col9") = Configuration.FormatToString(currhire, dgt)
              tr("Col10") = Configuration.FormatToString(total, dgt)
              '-----------------------
              tr("Col11") = Configuration.FormatToString(currmatactual, dgt)
              tr("Col12") = Configuration.FormatToString(currlabactual, dgt)
              tr("Col13") = Configuration.FormatToString(curreqactual, dgt)
              tr("Col14") = Configuration.FormatToString(currsubcon, dgt)
              tr("Col15") = Configuration.FormatToString(currhire, dgt)
              tr("Col16") = Configuration.FormatToString(currother, dgt)
              tr("Col17") = Configuration.FormatToString(currtotal, dgt)
              '-----------------------

              '-----------------------
              tr("Col18") = Configuration.FormatToString(matactual + currmatactual, dgt)
              tr("Col19") = Configuration.FormatToString(labactual + currlabactual, dgt)
              tr("Col20") = Configuration.FormatToString(eqactual + curreqactual, dgt)
              tr("Col21") = Configuration.FormatToString(subcon + currsubcon, dgt)
              tr("Col22") = Configuration.FormatToString(hire + currhire, dgt)
              tr("Col23") = Configuration.FormatToString(other + currother, dgt)
              tr("Col24") = Configuration.FormatToString(total + currtotal, dgt)
              '-----------------------

              tr("Col25") = Configuration.FormatToString(budget - total - currtotal, dgt)


              stage = "2"
              tr.State = RowExpandState.Expanded
            End If

            If CInt(Me.Filters(3).Value) > 0 Then
              Dim myDocId As String = ""
              Dim Doctr As TreeRow = Nothing

              For Each wbsDoc As DataRow In dt_2.Select("wbscode = '" & wbsrow("wbs_code") & "' and ismarkup = 0") 'Table 2

                Dim docmatactual As Decimal = CDec(wbsDoc("matactual"))
                Dim doclabactual As Decimal = CDec(wbsDoc("labactual"))
                Dim doceqactual As Decimal = CDec(wbsDoc("eqactual"))
                Dim docsubcon As Decimal = CDec(wbsDoc("sub"))
                Dim docother As Decimal = CDec(wbsDoc("other"))
                Dim dochire As Decimal = CDec(wbsDoc("hire"))
                Dim doctotal As Decimal = 0
                If Not wbsDoc.IsNull("totalactual") Then
                  doctotal += wbsDoc("totalactual")
                End If

                Dim doccurrmatactual As Decimal = CDec(wbsDoc("currmatactual"))
                Dim doccurrlabactual As Decimal = CDec(wbsDoc("currlabactual"))
                Dim doccurreqactual As Decimal = CDec(wbsDoc("curreqactual"))
                Dim doccurrsubcon As Decimal = CDec(wbsDoc("currsub"))
                Dim doccurrother As Decimal = CDec(wbsDoc("currother"))
                Dim doccurrhire As Decimal = CDec(wbsDoc("currhire"))
                Dim doccurrtotal As Decimal = 0
                If Not wbsDoc.IsNull("totalactual2") Then
                  doccurrtotal += wbsDoc("totalactual2")
                End If

                Doctr = tr.Childs.Add
                Doctr("Col2") = wbsDoc("ItemName")
                Doctr("Col26") = wbsDoc("DocCode")
                Doctr.State = RowExpandState.Expanded
                myDocId = CStr(wbsDoc("DocId"))

                '-----------------------
                Doctr("Col4") = Configuration.FormatToString(docmatactual, dgt)
                Doctr("Col5") = Configuration.FormatToString(doclabactual, dgt)
                Doctr("Col6") = Configuration.FormatToString(doceqactual, dgt)
                Doctr("Col7") = Configuration.FormatToString(docsubcon, dgt)
                Doctr("Col8") = Configuration.FormatToString(dochire, dgt)
                Doctr("Col9") = Configuration.FormatToString(doccurrhire, dgt)
                Doctr("Col10") = Configuration.FormatToString(doctotal, dgt)
                '-----------------------
                Doctr("Col11") = Configuration.FormatToString(doccurrmatactual, dgt)
                Doctr("Col12") = Configuration.FormatToString(doccurrlabactual, dgt)
                Doctr("Col13") = Configuration.FormatToString(doccurreqactual, dgt)
                Doctr("Col14") = Configuration.FormatToString(doccurrsubcon, dgt)
                Doctr("Col15") = Configuration.FormatToString(doccurrhire, dgt)
                Doctr("Col16") = Configuration.FormatToString(doccurrother, dgt)
                Doctr("Col17") = Configuration.FormatToString(doccurrtotal, dgt)
                '-----------------------

                '-----------------------
                Doctr("Col18") = Configuration.FormatToString(docmatactual + doccurrmatactual, dgt)
                Doctr("Col19") = Configuration.FormatToString(doclabactual + doccurrlabactual, dgt)
                Doctr("Col20") = Configuration.FormatToString(doceqactual + doccurreqactual, dgt)
                Doctr("Col21") = Configuration.FormatToString(docsubcon + doccurrsubcon, dgt)
                Doctr("Col22") = Configuration.FormatToString(dochire + doccurrhire, dgt)
                Doctr("Col23") = Configuration.FormatToString(docother + doccurrother, dgt)
                Doctr("Col24") = Configuration.FormatToString(doctotal + doccurrtotal, dgt)
                '-----------------------

              Next
            End If
          End If
        Next

        If Not civilRow Is Nothing Then
          Dim summArr(22) As Decimal
          For Each child As TreeRow In civilRow.Childs
            For colNum As Integer = 3 To 25
              summArr(colNum - 3) += CDec(child("Col" & colNum.ToString))
            Next
          Next
          For colNum As Integer = 3 To 25
            civilRow("Col" & colNum.ToString) = Configuration.FormatToString(summArr(colNum - 3), dgt)
          Next
        End If
        If Not mepRow Is Nothing Then
          Dim summArr(22) As Decimal
          For Each child As TreeRow In mepRow.Childs
            For colNum As Integer = 3 To 25
              summArr(colNum - 3) += CDec(child("Col" & colNum.ToString))
            Next
          Next
          For colNum As Integer = 3 To 25
            mepRow("Col" & colNum.ToString) = Configuration.FormatToString(summArr(colNum - 3), dgt)
          Next
        End If
        If Not ccRow Is Nothing Then
          Dim summArr(22) As Decimal
          For Each child As TreeRow In ccRow.Childs
            For colNum As Integer = 3 To 25
              summArr(colNum - 3) += CDec(child("Col" & colNum.ToString))
            Next
          Next
          For colNum As Integer = 3 To 25
            ccRow("Col" & colNum.ToString) = Configuration.FormatToString(summArr(colNum - 3), dgt)
          Next
        End If
        '#######################################################################################################

        If dt.Rows.Count > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try

    End Sub
    'Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each drtmp As DataRow In dr
    '        If Not drtmp.IsNull(field) Then
    '            ret += CDec(drtmp(field))
    '        End If
    '    Next
    '    Return ret
    'End Function
    Private m_system As String = ""
    Public Overrides Sub RefreshDataSet()
      m_cc = New CostCenter
      If TypeOf Me.Filters(0).Value Is CostCenter Then
        m_cc = CType(Me.Filters(0).Value, CostCenter)
      End If
      'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
      If Not Me.Filters(0).Value Is DBNull.Value Then
        Me.Filters(0).Value = m_cc.Id
      End If
      If Not Me.Filters(5).Value Is Nothing AndAlso TypeOf Me.Filters(5).Value Is Employee Then
        Me.Filters(5).Value = Me.Filters(6).Value.Id
      End If
      If Not Me.Filters(1).Value Is DBNull.Value Then
        Dim code As String = Me.Filters(1).Value.ToString
        Dim reg As New Regex("\d+")
        If reg.IsMatch(code) Then
          code = reg.Match(code).Value
        End If
        Select Case code.Substring(0, 1)
          Case "1"
            code = "1000 - ELECTRICAL SYSTEM"
          Case "2"
            code = "2000 - PLUMBLING SYSTEM"
          Case "3"
            code = "3000 - HVAC SYSTEM"
          Case "4"
            code = "4000 - CIVIL SYSTEM"
          Case "9"
            code = "9000 - INDIRECT COST"
        End Select
        m_system = code
      End If
      MyBase.RefreshDataSet()
    End Sub
#End Region

#Region "Select Distinct From DataTable"
    'Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
    '    Dim lastValues() As Object
    '    Dim newTable As DataTable

    '    If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
    '        Throw New ArgumentNullException("FieldNames")
    '    End If

    '    lastValues = New Object(FieldNames.Length - 1) {}
    '    newTable = New DataTable

    '    For Each field As String In FieldNames
    '        newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
    '    Next

    '    For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
    '        If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
    '            newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

    '            setLastValues(lastValues, Row, FieldNames)
    '        End If
    '    Next

    '    Return newTable
    'End Function
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
        Return "RptWBSMonitor2"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor2.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor2"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor2"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor2.ListLabel}"
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
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'dpi = New DocPrintingItem
      'dpi.Mapping = "CostCode"
      'dpi.Value = m_cc.Code  'Me.Filters(0).Value
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      If Not m_cc Is Nothing AndAlso m_cc.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "Project"
        dpi.Value = m_cc.Code & " - " & m_cc.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      dpi = New DocPrintingItem
      dpi.Mapping = "System"
      dpi.Value = m_system
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If IsDate(Me.Filters(2).Value) Then
        dpi.Value = CDate(Me.Filters(2).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Dim typeString As String = ""
      'Dim type As BOQ.WBSReportType
      'If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
      '  type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
      'End If
      'Select Case type
      '  Case BOQ.WBSReportType.PR
      '    typeString = "ขอซื้อ"
      '  Case BOQ.WBSReportType.PO
      '    typeString = "สั่งซื้อ"
      '  Case BOQ.WBSReportType.GoodsReceipt
      '    typeString = "รับของ"
      '  Case BOQ.WBSReportType.MatWithdraw
      '    typeString = "เบิกของ"
      'End Select
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Type"
      'dpi.Value = typeString
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'dpi = New DocPrintingItem
      'dpi.Mapping = "Requester"
      'If Not IsDBNull(Me.Filters(6).Value) Then
      '  dpi.Value = New Employee(CInt(Me.Filters(6).Value)).Name
      'End If
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Dim i As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        If i > 0 Then
          For j As Integer = 0 To Me.Treemanager.Treetable.Columns.Count - 1
            dpi = New DocPrintingItem
            dpi.Mapping = "col" & j
            dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
            dpi.DataType = "System.String"
            dpi.Row = i
            dpi.Table = "Item"
            dpiColl.Add(dpi)
            If i = Me.Treemanager.Treetable.Rows.Count - 2 Then
              dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            End If
          Next
        End If
        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

