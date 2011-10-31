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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptGLPayType
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
    Private m_hashData As Hashtable
    Public Shared m_hashDescription As Hashtable
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
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "GLPayType"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csAcctCode As New TreeTextColumn
      csAcctCode.MappingName = "acct_code"
      csAcctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.AcctCodeHeaderText}")
      csAcctCode.NullText = ""
      csAcctCode.Width = 90
      csAcctCode.DataAlignment = HorizontalAlignment.Left
      csAcctCode.ReadOnly = True
      csAcctCode.TextBox.Name = "acct_code"

      Dim csAcctName As New PlusMinusTreeTextColumn
      csAcctName.MappingName = "acct_Name"
      csAcctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.AcctNameHeaderText}")
      csAcctName.NullText = ""
      csAcctName.Width = 290
      csAcctName.TextBox.Name = "acct_name"
      csAcctName.DataAlignment = HorizontalAlignment.Left
      csAcctName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csGlCode As New TreeTextColumn
      csGlCode.MappingName = "gl_code"
      csGlCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.GLCodeHeaderText}")
      csGlCode.NullText = ""
      csGlCode.Width = 100
      csGlCode.TextBox.Name = "gl_code"
      csGlCode.DataAlignment = HorizontalAlignment.Left
      csGlCode.ReadOnly = True

      Dim csGlNote As New TreeTextColumn
      csGlNote.MappingName = "gli_note"
      csGlNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.GLNoteHeaderText}")
      csGlNote.NullText = ""
      csGlNote.Width = 150
      csGlNote.TextBox.Name = "gli_note"
      csGlNote.DataAlignment = HorizontalAlignment.Left
      csGlNote.ReadOnly = True

      Dim csDebit As New TreeTextColumn
      csDebit.MappingName = "Debit"
      csDebit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.DebitHeaderText}")
      csDebit.NullText = ""
      csDebit.DataAlignment = HorizontalAlignment.Right
      csDebit.TextBox.Name = "Debit"
      csDebit.Width = 80
      csDebit.ReadOnly = True

      Dim csCredit As New TreeTextColumn
      csCredit.MappingName = "Credit"
      csCredit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.CreditHeaderText}")
      csCredit.NullText = ""
      csCredit.DataAlignment = HorizontalAlignment.Right
      csCredit.TextBox.Name = "Credit"
      csCredit.Width = 80
      csCredit.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPayType.BalanceHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      csAmount.Width = 90
      csAmount.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csCash As New TreeTextColumn
      csCash.MappingName = "Cash"
      csCash.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CashHeaderText}")
      csCash.NullText = ""
      csCash.DataAlignment = HorizontalAlignment.Right
      csCash.Format = "#,###.##"
      csCash.TextBox.Name = "Cash"
      csCash.Width = 80
      csCash.ReadOnly = True

      Dim csBank As New TreeTextColumn
      csBank.MappingName = "Bank"
      csBank.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BankHeaderText}")
      csBank.NullText = ""
      csBank.DataAlignment = HorizontalAlignment.Right
      csBank.Format = "#,###.##"
      csBank.TextBox.Name = "Bank"
      csBank.Width = 80
      csBank.ReadOnly = True

      Dim csRemain As New TreeTextColumn
      csRemain.MappingName = "Remain"
      csRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.RemainHeaderText}")
      csRemain.NullText = ""
      csRemain.DataAlignment = HorizontalAlignment.Right
      csRemain.Format = "#,###.##"
      csRemain.TextBox.Name = "Remain"
      csRemain.Width = 80
      csRemain.ReadOnly = True

      Dim csAdjust As New TreeTextColumn
      csAdjust.MappingName = "Adjust"
      csAdjust.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.AdjustHeaderText}")
      csAdjust.NullText = ""
      csAdjust.DataAlignment = HorizontalAlignment.Right
      csAdjust.Format = "#,###.##"
      csAdjust.TextBox.Name = "Adjust"
      csAdjust.Width = 80
      csAdjust.ReadOnly = True

      Dim csOther As New TreeTextColumn
      csOther.MappingName = "Other"
      csOther.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.OtherHeaderText}")
      csOther.NullText = ""
      csOther.DataAlignment = HorizontalAlignment.Right
      csOther.Format = "#,###.##"
      csOther.TextBox.Name = "Other"
      csOther.Width = 80
      csOther.ReadOnly = True

      Dim csSum As New TreeTextColumn
      csSum.MappingName = "Sum"
      csSum.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.SumHeaderText}")
      csSum.NullText = ""
      csSum.DataAlignment = HorizontalAlignment.Right
      csSum.Format = "#,###.##"
      csSum.TextBox.Name = "Sum"
      csSum.Width = 80
      csSum.ReadOnly = True

      dst.GridColumnStyles.Add(csAcctCode)
      dst.GridColumnStyles.Add(csAcctName)
      dst.GridColumnStyles.Add(csBarrier0)
      dst.GridColumnStyles.Add(csGlCode)
      dst.GridColumnStyles.Add(csGlNote)
      dst.GridColumnStyles.Add(csDebit)
      dst.GridColumnStyles.Add(csCredit)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csCash)
      dst.GridColumnStyles.Add(csBank)
      dst.GridColumnStyles.Add(csRemain)
      dst.GridColumnStyles.Add(csAdjust)
      dst.GridColumnStyles.Add(csOther)
      'dst.GridColumnStyles.Add(csSum)

      Return dst
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("GLPayType")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("acct_id", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("acct_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("acct_name", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("gl_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("gli_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("gli_cc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Debit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Credit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Cash", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bank", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Remain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Adjust", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Other", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocId", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Sum", GetType(String)))


      Return myDatatable
    End Function

    Private Sub CreateHeader(ByVal dt As TreeTable)
      If dt Is Nothing Then
        Return
      End If

      dt.Clear()

      Dim tracct As TreeRow = dt.Childs.Add
      tracct("acct_code") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctCode}")       '"CBS Code"
      tracct("acct_name") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctName}")       '"CBS NAME"

      'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                              {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 2, 2), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 2, 3)}) ' _

      Dim trDetail As TreeRow = dt.Childs.Add
      Dim i As Integer = 5
      ' 10 Col per cc
      Dim GridRangeStyle1 As GridRangeStyle = New GridRangeStyle




      'Dim cc As String = crh.GetValue(Of Integer)("ccid").ToString
      ''trcc("BudgetCost" & cc) = crh.GetValue(Of String)("cc_code") & ":" & crh.GetValue(Of String)("cc_name")
      'tracct("CostCenter" & cc) = crh.GetValue(Of String)("cc_code") & ":" & crh.GetValue(Of String)("cc_name")

      trDetail("gl_code") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocCode}")
      trDetail("gli_note") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.ItemNote}")
      trDetail("Debit") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Debit}")
      trDetail("Credit") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Credit}")
      trDetail("Amount") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Balance}")
      trDetail("Cash") = Me.StringParserService.Parse("${res:Cash}")
      trDetail("Bank") = Me.StringParserService.Parse("${res:Bank}")
      trDetail("Remain") = Me.StringParserService.Parse("${res:Remain}")
      trDetail("Adjust") = Me.StringParserService.Parse("${res:Adjust}")
      trDetail("Other") = Me.StringParserService.Parse("${res:Other}")




      'For r As Integer = 0 To m_grid.ColCount - 1
      '  m_grid(2, r).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'Next


      'trcc("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.scBudget}")       '"SC Budget"
      'trcc("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retention}")     '"มัดจำ"      
      'trcc("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retentionn}")       '"Retention"
      'trcc("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DR}")     '"ยอดหัก DR"  '""  

      'trcc = Me.m_treemanager.Treetable.Childs.Add
      'trcc("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.sc_docDate}")        '"วันที่เอกสาร"

      'trcc("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.docCode}")       '"เลขที่เอกสาร"
      'trcc("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.supplierinfo}")      '"ผู้รับเหมา"    
      'trcc("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ccinfo}")      '"Cost Center "

      'trcc("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmount}") '"เบิก"
      'trcc("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountMJ}") '"เบิก"
      'trcc("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountRT}") '"หักไว้" 
      'trcc("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountDR}") '"เบิก"
      'trcc("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"  

      'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                              {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 0, 1), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 1, 1, 1), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 4, 1, 4), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 1, 8), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 9, 1, 11), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 12, 1, 14), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 15, 1, 17)}) ' _
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptGLPayType.GetSchemaTable() 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptGLPayType.CreateTableStyle() 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick

      RemoveHandler m_grid.CellClick, AddressOf CellClick
      AddHandler m_grid.CellClick, AddressOf CellClick


      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSchemaTable(), New TreeGrid)
      ListInGrid(tm)


      lkg.TreeTableStyle = CreateTableStyle()
      'lkg.Model.Rows.Hidden(0) = True
      'lkg.Model.ColWidths(5) = 0
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 0
      lkg.Rows.FrozenCount = 0
      lkg.Cols.FrozenCount = 3
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub

    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      'If m_cc Is Nothing OrElse Not m_cc.Originated Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If m_cc.BoqId = 0 Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If TypeOf Me.Filters(1).Value Is Date Then

      'End If
      Dim detailed As Integer = 0
      If Me.Filters(2).Name.ToLower = "detailed" Then
        detailed = CInt(Me.Filters(2).Value)
      End If
      'CreateHeader(tm.Treetable)
      PopulateListing(detailed)
    End Sub
    Dim dlgDetailForm As RptGLPayTypeDetailForm
    Private Sub CellClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim amount As Decimal = 0
      Select Case e.ColIndex
        Case 7, 8, 9, 10, 11, 12, 13, 14
          If IsNumeric(m_grid(e.RowIndex, e.ColIndex).CellValue) Then
            amount = CDec(m_grid(e.RowIndex, e.ColIndex).CellValue)
          Else
            If Not dlgDetailForm Is Nothing Then
              dlgDetailForm.Close()
            End If
            Return
          End If
        Case Else
          If Not dlgDetailForm Is Nothing Then
            dlgDetailForm.Close()
          End If
          Return
      End Select
      If Not dlgDetailForm Is Nothing Then
        dlgDetailForm.Close()
      End If
      dlgDetailForm = New RptGLPayTypeDetailForm
      dlgDetailForm.StartPosition = FormStartPosition.Manual

      Dim wpX As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
      Dim wpY As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
      'Dim wpY As Integer System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y

      Dim mpX As Integer = System.Windows.Forms.Control.MousePosition.X
      Dim mpY As Integer = System.Windows.Forms.Control.MousePosition.Y

      If mpX + dlgDetailForm.Width > wpX Then
        mpX -= dlgDetailForm.Width
      End If
      If mpY + dlgDetailForm.Height > wpY Then
        mpY -= dlgDetailForm.Height
      End If

      Dim colName As String = Me.m_treemanager.Treetable.Columns(e.ColIndex - 1).ColumnName.ToLower
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Rows(e.RowIndex - 1)
      If tr Is Nothing Then
        Return
      End If
      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId", 0)
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType", 0)
        Dim glAccountId As Integer = drh.GetValue(Of Integer)("acct_id", 0)
        Dim costcenterId As Integer = drh.GetValue(Of Integer)("gli_cc", 0)
        Trace.WriteLine(glAccountId)

        If docId > 0 AndAlso docType > 0 Then
          dlgDetailForm.ColumnName = colName
          dlgDetailForm.DocId = docId
          dlgDetailForm.DocType = docType
          dlgDetailForm.Amount = amount
          dlgDetailForm.GLAcountId = glAccountId
          dlgDetailForm.CostCenterId = costcenterId
        Else
          Return
        End If
      End If


      'Dim x As Integer = m_grid.CurrentCellInfo.CellView.
      ''Dim y As Integer = m_grid.CurrentCellInfo.GridView.Top
      'dlg.Location = New Point(e.MouseEventArgs.X + 40, e.MouseEventArgs.Y - 55)
      dlgDetailForm.Location = New Point(mpX, mpY)

      'dlg.Location = New Point(x, y)
      dlgDetailForm.Show()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim rowIndex As Integer = e.RowIndex
      'm_grid(rowIndex,10).CellValue

      Dim tr As TreeRow = Me.m_treemanager.Treetable.Rows(e.RowIndex - 1)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId", 0)
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType", 0)
        'Trace.WriteLine(docId.ToString)
        'Trace.WriteLine(docType.ToString)

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
   
    Public Sub PopulateListing(ByVal detailed As Integer)
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dtacct As DataTable = Me.DataSet.Tables(0)
      Dim currentAccountCode As String = ""
      Dim currentDoc As String = ""
      Dim currentLine As String = ""

      '--Clear All Detail--===========
      m_hashDescription = New Hashtable

      Dim i As Integer = 0
      For Each row As DataRow In dtacct.Rows
        Dim rowTag As Integer = CInt(row("acct_id"))
        Dim rowCode As String = CStr(row("acct_code"))
        Dim rowName As String = CStr(row("acct_name"))
        Dim rowLevel As Integer = CInt(row("acct_level"))
        Dim parentNodes As ITreeParent

        If IsDBNull(row("acct_parid")) OrElse CInt(row("acct_parid")) = CInt(row("acct_id")) Then
          parentNodes = Me.m_treemanager.Treetable
        Else
          Dim parnode As TreeRow = SearchTag(CInt(row("acct_parid")))
          If parnode Is Nothing Then
            parentNodes = Me.m_treemanager.Treetable
          Else
            parentNodes = parnode
          End If
        End If
        Dim theRow As TreeRow = parentNodes.Childs.Add
        theRow("acct_id") = CInt(row("acct_id"))
        theRow("acct_code") = rowCode
        theRow("acct_name") = Space(rowLevel) & rowName 'Space(rowLevel * 3) & rowName
        theRow.Tag = rowTag

        'Dim nr As TreeRow = theRow.Childs.Add
        'nr("acct_code") = "acct_code"

        Me.SetTransaction(rowTag, theRow)
        theRow.State = RowExpandState.Expanded
        If theRow.Childs.Count > 0 Then
          If detailed Then
            theRow.State = RowExpandState.Expanded
          Else
            theRow.State = RowExpandState.Collapsed
          End If
        End If

      Next

      For Each row As TreeRow In Me.m_treemanager.Treetable.Childs
        SumParentRow(row)
      Next

      '--Total Summary-- ========================================================
      Dim debit As Decimal = 0
      Dim credit As Decimal = 0
      Dim Amount As Decimal = 0
      Dim Cash As Decimal = 0
      Dim Bank As Decimal = 0
      Dim Remain As Decimal = 0
      Dim Adjust As Decimal = 0
      Dim Other As Decimal = 0
      For Each childrow As TreeRow In Me.m_treemanager.Treetable.Childs
        Dim dr As DataRow = CType(childrow, DataRow)
        Dim drh As New DataRowHelper(dr)
        debit += drh.GetValue(Of Decimal)("Debit", 0)
        credit += drh.GetValue(Of Decimal)("Credit", 0)
        Amount += drh.GetValue(Of Decimal)("amount", 0)
        Cash += drh.GetValue(Of Decimal)("cash", 0)
        Bank += drh.GetValue(Of Decimal)("bank", 0)
        Remain += drh.GetValue(Of Decimal)("remain", 0)
        Adjust += drh.GetValue(Of Decimal)("adjust", 0)
        Other += drh.GetValue(Of Decimal)("other", 0)
      Next
      Dim parrow As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      parrow.State = RowExpandState.Expanded

      parrow("gl_code") = "รวมทั้งสิ้น"
      parrow("Debit") = Configuration.FormatToString(debit, DigitConfig.Price)
      parrow("Credit") = Configuration.FormatToString(credit, DigitConfig.Price)
      parrow("amount") = Configuration.FormatToString(Amount, DigitConfig.Price)
      parrow("cash") = Configuration.FormatToString(Cash, DigitConfig.Price)
      parrow("bank") = Configuration.FormatToString(Bank, DigitConfig.Price)
      parrow("remain") = Configuration.FormatToString(Remain, DigitConfig.Price)
      parrow("adjust") = Configuration.FormatToString(Adjust, DigitConfig.Price)
      parrow("other") = Configuration.FormatToString(Other, DigitConfig.Price)
      '--Total Summary-- ========================================================


      'Dim debit As Decimal = 0
      'Dim credit As Decimal = 0
      'Dim Amount As Decimal = 0
      'Dim Cash As Decimal = 0
      'Dim Bank As Decimal = 0
      'Dim Remain As Decimal = 0
      'Dim Adjust As Decimal = 0
      'Dim Other As Decimal = 0

      'For Each row As TreeRow In Me.m_treemanager.Treetable.Childs
      '  debit = 0
      '  credit = 0
      '  Amount = 0
      '  Cash = 0
      '  Bank = 0
      '  Remain = 0
      '  Adjust = 0
      '  Other = 0
      '  Trace.WriteLine(row("acct_code").ToString)
      '  For Each childrow As TreeRow In row.Childs
      '    Dim dr As DataRow = CType(childrow, DataRow)
      '    Dim drh As New DataRowHelper(dr)
      '    debit += drh.GetValue(Of Decimal)("Debit", 0)
      '    credit += drh.GetValue(Of Decimal)("Credit", 0)
      '    Amount += drh.GetValue(Of Decimal)("amount", 0)
      '    Cash += drh.GetValue(Of Decimal)("cash", 0)
      '    Bank += drh.GetValue(Of Decimal)("bank", 0)
      '    Remain += drh.GetValue(Of Decimal)("remain", 0)
      '    Adjust += drh.GetValue(Of Decimal)("adjust", 0)
      '    Other += drh.GetValue(Of Decimal)("other", 0)
      '  Next
      '  row("Debit") = Configuration.FormatToString(debit, DigitConfig.Price)
      '  row("Credit") = Configuration.FormatToString(credit, DigitConfig.Price)
      '  row("amount") = Configuration.FormatToString(Amount, DigitConfig.Price)
      '  row("cash") = Configuration.FormatToString(Cash, DigitConfig.Price)
      '  row("bank") = Configuration.FormatToString(Bank, DigitConfig.Price)
      '  row("remain") = Configuration.FormatToString(Remain, DigitConfig.Price)
      '  row("adjust") = Configuration.FormatToString(Adjust, DigitConfig.Price)
      '  row("other") = Configuration.FormatToString(Other, DigitConfig.Price)
      'Next

      Me.m_treemanager.Treetable.AcceptChanges()
      Return










      '' ItemZone Zone
      'For Each row As DataRow In dtacct.Rows
      '  Dim parnode As TreeRow = SearchTag(CInt(row("acct_id")))
      '  If Not parnode Is Nothing AndAlso parnode.Childs.Count > 0 Then
      '    'Dim debit As Decimal = 0
      '    'Dim credit As Decimal = 0
      '    'Dim Amount As Decimal = 0
      '    'Dim Cash As Decimal = 0
      '    'Dim Bank As Decimal = 0
      '    'Dim Remain As Decimal = 0
      '    'Dim Adjust As Decimal = 0
      '    'Dim Other As Decimal = 0

      '    debit = 0
      '    credit = 0
      '    Amount = 0
      '    Cash = 0
      '    Bank = 0
      '    Remain = 0
      '    Adjust = 0
      '    Other = 0

      '    Dim theRow As TreeRow = parnode.Childs.Add
      '    theRow("gl_code") = "รวมยอด:" & Trim(CStr(parnode("acct_code")))

      '    debit = SumChilds(debit, parnode, "Debit")
      '    credit = SumChilds(credit, parnode, "Credit")
      '    Amount = SumChilds(Amount, parnode, "Amount")
      '    Cash = SumChilds(Cash, parnode, "cash")
      '    Bank = SumChilds(Bank, parnode, "bank")
      '    Remain = SumChilds(Remain, parnode, "Remain")
      '    Adjust = SumChilds(Adjust, parnode, "adjust")
      '    Other = SumChilds(Other, parnode, "other")

      '    theRow("Debit") = Configuration.FormatToString(debit, DigitConfig.Price)
      '    theRow("Credit") = Configuration.FormatToString(credit, DigitConfig.Price)
      '    theRow("amount") = Configuration.FormatToString(Amount, DigitConfig.Price)
      '    theRow("cash") = Configuration.FormatToString(Cash, DigitConfig.Price, True)
      '    theRow("bank") = Configuration.FormatToString(Bank, DigitConfig.Price, True)
      '    theRow("remain") = Configuration.FormatToString(Remain, DigitConfig.Price, True)
      '    theRow("adjust") = Configuration.FormatToString(Adjust, DigitConfig.Price, True)
      '    theRow("other") = Configuration.FormatToString(Other, DigitConfig.Price, True)
      '    'theRow.Tag = "summary"
      '  End If
      'Next
      'Me.m_treemanager.Treetable.AcceptChanges()

      ''Dim m As Integer = 0
      ''m_hashData = New Hashtable
      ''For Each row As TreeRow In Me.m_treemanager.Treetable.Rows
      ''  m += 1
      ''  If Not row.Tag Is Nothing Then
      ''    m_hashData(m) = row.Tag
      ''  End If
      ''Next

    End Sub
    Private Sub SumParentRow(ByVal parrow As TreeRow)
      Dim debit As Decimal = 0
      Dim credit As Decimal = 0
      Dim Amount As Decimal = 0
      Dim Cash As Decimal = 0
      Dim Bank As Decimal = 0
      Dim Remain As Decimal = 0
      Dim Adjust As Decimal = 0
      Dim Other As Decimal = 0

      'Trace.WriteLine(parrow("acct_code").ToString)

      For Each childrow As TreeRow In parrow.Childs

        SumParentRow(childrow)

        Dim dr As DataRow = CType(childrow, DataRow)
        Dim drh As New DataRowHelper(dr)
        debit += drh.GetValue(Of Decimal)("Debit", 0)
        credit += drh.GetValue(Of Decimal)("Credit", 0)
        Amount += drh.GetValue(Of Decimal)("amount", 0)
        Cash += drh.GetValue(Of Decimal)("cash", 0)
        Bank += drh.GetValue(Of Decimal)("bank", 0)
        Remain += drh.GetValue(Of Decimal)("remain", 0)
        Adjust += drh.GetValue(Of Decimal)("adjust", 0)
        Other += drh.GetValue(Of Decimal)("other", 0)
      Next
      If parrow.Childs.Count > 0 Then
        parrow("Debit") = Configuration.FormatToString(debit, DigitConfig.Price)
        parrow("Credit") = Configuration.FormatToString(credit, DigitConfig.Price)
        parrow("amount") = Configuration.FormatToString(Amount, DigitConfig.Price)
        parrow("cash") = Configuration.FormatToString(Cash, DigitConfig.Price)
        parrow("bank") = Configuration.FormatToString(Bank, DigitConfig.Price)
        parrow("remain") = Configuration.FormatToString(Remain, DigitConfig.Price)
        parrow("adjust") = Configuration.FormatToString(Adjust, DigitConfig.Price)
        parrow("other") = Configuration.FormatToString(Other, DigitConfig.Price)
      End If
    End Sub
    'Private Sub SumTotalRow(ByVal parrow As TreeRow)
    '  Dim debit As Decimal = 0
    '  Dim credit As Decimal = 0
    '  Dim Amount As Decimal = 0
    '  Dim Cash As Decimal = 0
    '  Dim Bank As Decimal = 0
    '  Dim Remain As Decimal = 0
    '  Dim Adjust As Decimal = 0
    '  Dim Other As Decimal = 0

    '  For Each childrow As TreeRow In parrow.Childs

    '    Dim dr As DataRow = CType(childrow, DataRow)
    '    Dim drh As New DataRowHelper(dr)
    '    debit += drh.GetValue(Of Decimal)("Debit", 0)
    '    credit += drh.GetValue(Of Decimal)("Credit", 0)
    '    Amount += drh.GetValue(Of Decimal)("amount", 0)
    '    Cash += drh.GetValue(Of Decimal)("cash", 0)
    '    Bank += drh.GetValue(Of Decimal)("bank", 0)
    '    Remain += drh.GetValue(Of Decimal)("remain", 0)
    '    Adjust += drh.GetValue(Of Decimal)("adjust", 0)
    '    Other += drh.GetValue(Of Decimal)("other", 0)
    '  Next
    '  If parrow.Childs.Count > 0 Then
    '    parrow("Debit") = Configuration.FormatToString(debit, DigitConfig.Price)
    '    parrow("Credit") = Configuration.FormatToString(credit, DigitConfig.Price)
    '    parrow("amount") = Configuration.FormatToString(Amount, DigitConfig.Price)
    '    parrow("cash") = Configuration.FormatToString(Cash, DigitConfig.Price)
    '    parrow("bank") = Configuration.FormatToString(Bank, DigitConfig.Price)
    '    parrow("remain") = Configuration.FormatToString(Remain, DigitConfig.Price)
    '    parrow("adjust") = Configuration.FormatToString(Adjust, DigitConfig.Price)
    '    parrow("other") = Configuration.FormatToString(Other, DigitConfig.Price)
    '  End If
    'End Sub
    Private Function SumChilds(ByRef result As Decimal, ByVal parent As TreeRow, ByVal columnName As String) As Decimal
      If parent.Childs.Count > 0 Then
        For Each childs As TreeRow In parent.Childs
          If Not childs.IsNull(columnName) Then
            Dim value As Decimal = 0
            If childs(columnName).ToString.Length > 0 Then
              value = CDec(childs(columnName))
            End If
            result += Configuration.Format(value, DigitConfig.Price)
          End If
          If childs.Childs.Count > 0 Then SumChilds(result, childs, columnName)
        Next
      End If
      Return result
    End Function
    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
    End Function
    Private Sub SetTransaction(ByVal id As Integer, ByVal tr As TreeRow)
      If Me.DataSet.Tables.Count > 1 Then
        Dim dt As DataTable = Me.DataSet.Tables(1)
        'Dim ComputeDrCr As Boolean = CBool(Me.DataSet.Tables(2).Rows(0).Item("ComputeDrCr"))
        Dim totalbalance As Decimal = 0
        Dim totalCash As Decimal = 0
        Dim totalBank As Decimal = 0
        Dim totalRemain As Decimal = 0
        Dim totalAdjust As Decimal = 0
        Dim totalOther As Decimal = 0

        For Each row As DataRow In dt.Select("gli_acct = " & id.ToString)
          Dim drh As New DataRowHelper(row)
          If Not row.IsNull("gl_id") Then
            Dim theRow2 As TreeRow = tr.Childs.Add

            'Dim m As Integer = m_treemanager.Treetable.Rows.IndexOf(theRow2)
            'If m_hashData Is Nothing Then
            '  m_hashData = New Hashtable
            'End If
            'm_hashData(m) = row("gl_refid") & "|" & row("gl_refDocType")
            'MessageBox.Show(m.ToString)


            Dim isdebit As Boolean = CBool(row("gli_isdebit"))
            Dim gli_balanceamt As Decimal = CDec(IIf(row.IsNull("gli_balanceamt"), 0, row("gli_balanceamt")))
            Dim gli_debitamt As Decimal = CDec(IIf(row.IsNull("gli_debitamt"), 0, row("gli_debitamt")))
            Dim gli_creditamt As Decimal = CDec(IIf(row.IsNull("gli_creditamt"), 0, row("gli_creditamt")))

            'If ComputeDrCr Then
            '  If gli_debitamt < gli_creditamt Then
            '    gli_creditamt -= gli_debitamt
            '    gli_debitamt = 0
            '  Else
            '    gli_debitamt -= gli_creditamt
            '    gli_creditamt = 0
            '  End If
            'End If

            'If Not row.IsNull("gl_docdate") Then
            '  theRow("col0") = Space(2) & CDate(row("gl_docdate")).ToString("dd/MM/yyyy")
            'End If
            theRow2("acct_id") = drh.GetValue(Of Integer)("gli_acct")
            theRow2("gli_cc") = drh.GetValue(Of Integer)("gli_cc")

            If Not row.IsNull("gl_code") Then
              theRow2("gl_code") = CStr(row("gl_code")) 'Space(6) & CStr(row("gl_code"))
            End If
            'If Not row.IsNull("gl_refcode") Then
            '  theRow("col2") = CStr(row("gl_refcode")) 'Space(6) & CStr(row("gl_refcode"))
            'End If


            'theRow("col3") = row("stock_pvrv")      ' ใบสำคัญรับ/จ่าย
            'theRow("col4") = row("accountbook_name")      ' สมุดรายวัน
            theRow2("gli_note") = drh.GetValue(Of String)("gli_note")       ' รายการ/คำอธิบาย

            theRow2("Debit") = Configuration.FormatToString(gli_debitamt, DigitConfig.Price)      ' เดบิต
            theRow2("Credit") = Configuration.FormatToString(gli_creditamt, DigitConfig.Price)      ' เครบิต

            totalbalance += gli_balanceamt

            theRow2("Amount") = Configuration.FormatToString(totalbalance, DigitConfig.Price)      ' ยอดคงเหลือ

            Dim cash As Decimal = drh.GetValue(Of Decimal)("Cash")
            totalCash += cash
            Dim bank As Decimal = drh.GetValue(Of Decimal)("bank")
            totalBank += bank
            Dim remain As Decimal = drh.GetValue(Of Decimal)("remain")
            totalRemain += remain
            Dim adjust As Decimal = drh.GetValue(Of Decimal)("adjust")
            totalAdjust += adjust
            Dim Other As Decimal = drh.GetValue(Of Decimal)("Other")
            totalOther += Other
            theRow2("Cash") = Configuration.FormatToString(cash, DigitConfig.Price, True)      ' ยอดคงเหลือ
            theRow2("Bank") = Configuration.FormatToString(bank, DigitConfig.Price, True)      ' ยอดคงเหลือ
            theRow2("Remain") = Configuration.FormatToString(remain, DigitConfig.Price, True)      ' ยอดคงเหลือ
            theRow2("Adjust") = Configuration.FormatToString(adjust, DigitConfig.Price, True)      ' ยอดคงเหลือ
            theRow2("Other") = Configuration.FormatToString(Other, DigitConfig.Price, True)      ' ยอดคงเหลือ


            'theRow("col9") = row("cc_code")       ' Costcenter
            theRow2("Docid") = drh.GetValue(Of Integer)("gl_refid", 0)
            theRow2("DocType") = drh.GetValue(Of Integer)("gl_refDocType", 0)

            'theRow2.Tag = "glitem"
          End If
        Next

        'tr.AcceptChanges()
      End If
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
        Return "RptGLPayType"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPayType.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptGLPayType"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptGLPayType"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPayType.ListLabel}"
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

        'r = i + 1
        'Dim dr As Object = m_hashData(r)
        'If Not dr Is Nothing Then
        '  If TypeOf dr Is DataRow Then
        '    Dim row As DataRow = CType(dr, DataRow)
        '    If row.Table.TableName = "Table0" Then
        '      Dim drh As New DataRowHelper(row)

        '      dpi = New DocPrintingItem
        '      dpi.Mapping = "col1.1"
        '      dpi.Value = drh.GetValue(Of String)("wbs_code")
        '      dpi.DataType = "System.String"
        '      dpi.Row = i + 1
        '      dpi.Table = "Item"
        '      dpiColl.Add(dpi)

        '      dpi = New DocPrintingItem
        '      dpi.Mapping = "col1.2"
        '      dpi.Value = drh.GetValue(Of String)("wbs_name")
        '      dpi.DataType = "System.String"
        '      dpi.Row = i + 1
        '      dpi.Table = "Item"
        '      dpiColl.Add(dpi)
        '    End If
        '  End If
        'End If

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

