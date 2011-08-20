Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Globalization
Imports Longkong.Core.AddIns
Imports Syncfusion.Windows.Forms.Grid
Imports System.Text
Imports System.Net

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ExportPaymentTrackDetail
    Inherits AbstractEntityDetailPanelView
    'Inherits UserControl
    'Implements IValidatable

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    'Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    'Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents chkSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents m_grid As Longkong.Pojjaman.Gui.Components.LKGrid
    Friend WithEvents btnExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.m_grid = New Longkong.Pojjaman.Gui.Components.LKGrid()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbFilter = New System.Windows.Forms.GroupBox()
      Me.chkSupplier = New System.Windows.Forms.CheckBox()
      Me.btnExport = New System.Windows.Forms.Button()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.m_grid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbMaster.SuspendLayout()
      Me.grbFilter.SuspendLayout()
      Me.SuspendLayout()
      '
      'm_grid
      '
      Me.m_grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.m_grid.AutoColumnResize = False
      Me.m_grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.m_grid.ColCount = 0
      Me.m_grid.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.Khaki, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))})
      Me.m_grid.DefaultBehavior = True
      Me.m_grid.DefaultColWidth = 100
      Me.m_grid.ForeColor = System.Drawing.SystemColors.ControlText
      Me.m_grid.HideHead = False
      Me.m_grid.HilightGroupParentText = False
      Me.m_grid.HilightWhenMinus = False
      Me.m_grid.Location = New System.Drawing.Point(6, 63)
      Me.m_grid.Name = "m_grid"
      Me.m_grid.PlusMinusColumnIndex = 0
      Me.m_grid.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.m_grid.RowCount = 0
      Me.m_grid.Size = New System.Drawing.Size(702, 427)
      Me.m_grid.SmartSizeBox = False
      Me.m_grid.TabIndex = 7
      Me.m_grid.ThemesEnabled = True
      Me.m_grid.TreeTable = Nothing
      Me.m_grid.TreeTableStyle = Nothing
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbFilter)
      Me.grbMaster.Controls.Add(Me.btnExport)
      Me.grbMaster.Controls.Add(Me.m_grid)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(714, 496)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "Export Text File : "
      '
      'grbFilter
      '
      Me.grbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFilter.Controls.Add(Me.chkSupplier)
      Me.grbFilter.Location = New System.Drawing.Point(471, 10)
      Me.grbFilter.Name = "grbFilter"
      Me.grbFilter.Size = New System.Drawing.Size(237, 47)
      Me.grbFilter.TabIndex = 7
      Me.grbFilter.TabStop = False
      Me.grbFilter.Text = "รายละเอียดการค้นหา"
      '
      'chkSupplier
      '
      Me.chkSupplier.AutoSize = True
      Me.chkSupplier.Checked = True
      Me.chkSupplier.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkSupplier.Location = New System.Drawing.Point(7, 20)
      Me.chkSupplier.Name = "chkSupplier"
      Me.chkSupplier.Size = New System.Drawing.Size(168, 17)
      Me.chkSupplier.TabIndex = 0
      Me.chkSupplier.Text = "แสดงเฉพาะ ที่ยืนยันผู้ขายแล้ว"
      Me.chkSupplier.UseVisualStyleBackColor = True
      '
      'btnExport
      '
      Me.btnExport.Location = New System.Drawing.Point(6, 19)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(135, 38)
      Me.btnExport.TabIndex = 6
      Me.btnExport.Text = "Export to Builk.com"
      '
      'ExportPaymentTrackDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "ExportPaymentTrackDetail"
      Me.Size = New System.Drawing.Size(728, 512)
      CType(Me.m_grid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbMaster.ResumeLayout(False)
      Me.grbFilter.ResumeLayout(False)
      Me.grbFilter.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.grbMaster}")

    End Sub

#End Region

#Region "Member"
    Private m_entity As ExportOutgoingCheck

    Private m_treeManager As TreeManager
    Private m_dataSet As DataSet
    Private m_dataPreviewHs As Hashtable
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.SetLabelText()

      EventWiring()
    End Sub
    Public Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treeManager = tm
      Me.m_treeManager.Treetable.Clear()
      CreateHeader()
      If Not Me.m_entity Is Nothing Then
        PopulateData()
      End If
      Me.m_entity.TreeManager = Me.m_treeManager
    End Sub
    Private Sub InitialGridControl()
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      m_grid.DefaultBehavior = False
      m_grid.HilightWhenMinus = True
      m_grid.Init()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      m_grid.TreeTableStyle = CreateSimpleTableStyle()
      m_grid.TreeTable = tm.Treetable

      m_grid.Rows.HeaderCount = 3
      m_grid.Rows.FrozenCount = 3

      m_grid.Refresh()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      '--LEVEL 0--
      Dim tr As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.DocType}") ' "ประเภทเอกสาร"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.CheckCode}") ' "เลขที่เอกสารเช็ค"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Supplier}") ' "ผู้ขาย"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Detail}") ' "รายละเอียด"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.IssueDate}") ' "วันบนที่เช็ค"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Amount}") ' "มูลค่าบนเช็ค"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.WitholdingTax}") ' "หัก ณ ที่จ่าย"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Deduct}") ' "ยอดหักเพิ่ม"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Added}") ' "ยอดจ่ายเพิ่ม"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.PickUpDoc}") ' "เอกสารเพื่อแลกเช็ค"
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.PickUpLocation}") ' "สถานที่รับเช็ค"
      tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.ReceiveMethod}") ' "วิธีรับเช็ค"
      tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Note}") ' "หมายเหตุเช็ค"

      tr = Me.m_treeManager.Treetable.Childs.Add
      tr("col0") = ""
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.BillCode}") ' "เลขที่ใบวางบิล"
      tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.BillDocDate}") ' "วันที่วางบิล"
      tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.BillIssueCode}") ' "เลขที่ใบรับวางบิล"
      tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.BillIssueDate}") ' "วันรับวางบิล"

      tr = Me.m_treeManager.Treetable.Childs.Add
      tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.DocCode}") ' "เลขที่เอกสาร"
      tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.DocDate}") ' "วันที่เอกสาร"
      tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.OtherDocCode}") ' "เลขที่ใบส่งของ/ส่งงาน"
      tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.OtherDocDate}") ' "วันที่ใบส่งของ/ส่งงาน"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.BeforeTax}") ' "ยอดก่อนภาษี"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Tax}") ' "ยอดภาษี"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.AfterTax}") ' "ยอดรวมภาษี"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.AdvancePay}") ' "ยอดมัดจำ"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.Retention}") ' "ยอด Retention"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ExportPaymentTrackDetail.POSC}") ' "เลขที่ PO/SC"
    
    End Sub
    Private Function SetKeyValuePair(ByVal doctype As String, ByVal docId As String) As KeyValuePair
      Return New KeyValuePair(doctype, docId)
    End Function
    Private Function DataRowsFilter(ByVal dt As DataTable) As DataRowCollection
      If Me.chkSupplier.Checked Then
        Dim rows As DataRow() = dt.Select("supplier_builkid is not null")
        Dim newdt As New DataTable
        For Each col As DataColumn In dt.Columns
          newdt.Columns.Add(New DataColumn(col.ColumnName))
        Next
        For Each row As DataRow In rows
          Dim drh As New Longkong.Pojjaman.DataAccessLayer.DataRowHelper(row)
          If drh.GetValue(Of Integer)("supplier_builkid") > 0 Then '--กันไว้อีกรอบ--
            Dim newrow As DataRow = newdt.NewRow
            For Each col As DataColumn In dt.Columns
              newrow(col.ColumnName) = row(col.ColumnName)
            Next
            newdt.Rows.Add(newrow)
          End If
        Next
        Return newdt.Rows
      End If
      Return dt.Rows
    End Function
    Private Sub PopulateData()
      If Me.m_entity.PaymentTrackDataSet Is Nothing _
        OrElse Me.m_entity.PaymentTrackDataSet.Tables.Count <= 0 _
        OrElse Me.m_entity.PaymentTrackDataSet.Tables(0).Rows.Count <= 0 Then
        Return
      End If

      Dim dt As DataTable = Me.m_entity.PaymentTrackDataSet.Tables(0)
      Dim dt1 As DataTable = Me.m_entity.PaymentTrackDataSet.Tables(1)
      m_dataPreviewHs = New Hashtable

      If dt.Rows.Count = 0 Then
        Return
      End If
      Dim indent As String = Space(3)
      Dim indent2 As String = ""

      Dim checkHs As New Hashtable
      Dim billHs As New Hashtable
      Dim checkTr As TreeRow = Nothing
      Dim billTr As TreeRow = Nothing
      Dim docTr As TreeRow = Nothing

      For Each eoci As ExportOutgoingCheckItem In Me.m_entity.ItemCollection

        checkTr = Nothing
        If Not Me.chkSupplier.Checked Then
          If Not checkHs.ContainsKey(eoci.Entity.Id) Then
            checkTr = Me.m_treeManager.Treetable.Childs.Add
            checkTr.State = RowExpandState.Expanded
            checkTr.Tag = Me.SetKeyValuePair(22, eoci.Entity.Id)
            checkTr("col0") = "เช็คจ่าย" 'drh.GetValue(Of String)("entity_description")
            checkTr("col1") = eoci.Entity.Code
            checkTr("col2") = eoci.Entity.Supplier.Code & " : " & eoci.Entity.Supplier.Name
            checkTr("col3") = eoci.Detail 'drh.GetValue(Of String)("eochecki_detail")
            'If IsDate(drh.GetValue(Of String)("check_issuedate")) Then
            checkTr("col4") = eoci.Entity.IssueDate.ToShortDateString
            'End If
            checkTr("col5") = Configuration.FormatToString(eoci.Entity.Amount, DigitConfig.Price)
            checkTr("col6") = Configuration.FormatToString(eoci.WHTCollection.Amount, DigitConfig.Price)
            checkTr("col7") = Configuration.FormatToString(0, DigitConfig.Price)
            checkTr("col8") = Configuration.FormatToString(0, DigitConfig.Price)
            checkTr("col10") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.DocumentForPickup, "DocumentForPickup")
            checkTr("col11") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.PickupCode, "PickupLocationCode", True)
            checkTr("col12") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.DeliveryMethod, "DeliveryMethod", True)
            checkTr("col13") = eoci.Entity.Note

            checkHs(eoci.Entity.Id) = checkTr
          Else
            checkTr = CType(checkHs(eoci.Entity.Id), TreeRow)
          End If
        Else
          If eoci.Entity.Supplier.BuilkID IsNot Nothing AndAlso eoci.Entity.Supplier.BuilkID.Length > 0 Then
            If Not checkHs.ContainsKey(eoci.Entity.Id) Then
              checkTr = Me.m_treeManager.Treetable.Childs.Add
              checkTr.State = RowExpandState.Expanded
              checkTr.Tag = Me.SetKeyValuePair(22, eoci.Entity.Id)
              checkTr("col0") = "เช็คจ่าย" 'drh.GetValue(Of String)("entity_description")
              checkTr("col1") = eoci.Entity.Code
              checkTr("col2") = eoci.Entity.Supplier.Code & " : " & eoci.Entity.Supplier.Name
              checkTr("col3") = eoci.Detail 'drh.GetValue(Of String)("eochecki_detail")
              'If IsDate(drh.GetValue(Of String)("check_issuedate")) Then
              checkTr("col4") = eoci.Entity.IssueDate.ToShortDateString
              'End If
              checkTr("col5") = Configuration.FormatToString(eoci.Entity.Amount, DigitConfig.Price)
              checkTr("col6") = Configuration.FormatToString(eoci.WHTCollection.Amount, DigitConfig.Price)
              'checkTr("col7") = Configuration.FormatToString(0, DigitConfig.Price)
              'checkTr("col8") = Configuration.FormatToString(0, DigitConfig.Price)
              checkTr("col10") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.DocumentForPickup, "DocumentForPickup")
              checkTr("col11") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.PickupCode, "PickupLocationCode", True)
              checkTr("col12") = ExportOutgoingCheck.GetDescriptionFromCodeTag(eoci.DeliveryMethod, "DeliveryMethod", True)
              checkTr("col13") = eoci.Entity.Note

              checkHs(eoci.Entity.Id) = checkTr
            Else
              checkTr = CType(checkHs(eoci.Entity.Id), TreeRow)
            End If
          End If
        End If

        If Not checkTr Is Nothing Then
          For Each row As DataRow In Me.m_entity.PaymentTrackDataSet.Tables(0).Select("eochecki_entity=" & eoci.Entity.Id.ToString)
            Dim drh As New Longkong.Pojjaman.DataAccessLayer.DataRowHelper(row)
            billTr = Nothing
            If drh.GetValue(Of Integer)("billa_id") > 0 Then
              If Not billHs.ContainsKey(drh.GetValue(Of String)("billa_id")) Then
                billTr = checkTr.Childs.Add
                billTr.State = RowExpandState.Expanded
                billTr.Tag = Me.SetKeyValuePair(60, drh.GetValue(Of String)("billa_id"))

                billTr("col0") = indent & "ใบรับวางบิล" 'drh.GetValue(Of String)("entity_description")
                billTr("col1") = drh.GetValue(Of String)("billa_code")
                If IsDate(drh.GetValue(Of String)("billa_docdate")) Then
                  billTr("col2") = indent & CDate(drh.GetValue(Of String)("billa_docdate")).ToShortDateString
                End If
                billTr("col3") = indent & drh.GetValue(Of String)("billa_billissueCode")
                If IsDate(drh.GetValue(Of String)("billa_billissueDate")) Then
                  billTr("col4") = indent & CDate(drh.GetValue(Of String)("billa_billissueDate")).ToShortDateString
                End If

                billHs(drh.GetValue(Of String)("billa_id")) = billTr
              Else
                billTr = CType(billHs(drh.GetValue(Of String)("billa_id")), TreeRow)
              End If
            End If
            If drh.GetValue(Of Integer)("stockid") > 0 Then
              If Not billTr Is Nothing Then
                docTr = billTr.Childs.Add
                indent2 = indent & indent
              Else
                docTr = checkTr.Childs.Add
                indent2 = indent
              End If
              docTr.Tag = Me.SetKeyValuePair(drh.GetValue(Of String)("stocktype"), drh.GetValue(Of String)("stockid"))
              docTr("col0") = indent2 & drh.GetValue(Of String)("entity_description")
              docTr("col1") = drh.GetValue(Of String)("stockcode")
              If IsDate(drh.GetValue(Of String)("stockdocdate")) Then
                docTr("col2") = indent2 & CDate(drh.GetValue(Of String)("stockdocdate")).ToShortDateString
              End If
              docTr("col3") = indent2 & drh.GetValue(Of String)("stockotherDocCode")
              If IsDate(drh.GetValue(Of String)("stockotherDocDate")) Then
                docTr("col4") = indent2 & CDate(drh.GetValue(Of String)("stockotherDocDate")).ToShortDateString
              End If
              docTr("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_beforetax"), DigitConfig.Price)
              docTr("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_taxamt"), DigitConfig.Price)
              docTr("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_aftertax"), DigitConfig.Price)
              docTr("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_advance"), DigitConfig.Price)
              docTr("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stockretention"), DigitConfig.Price)
              docTr("col10") = drh.GetValue(Of String)("posc")
            End If
          Next
        End If

      Next

      For Each eociId As Integer In checkHs.Keys
        checkTr = CType(checkHs(eociId), TreeRow)

        Dim deductpayment As Decimal = 0
        Dim addedpayment As Decimal = 0
        For Each row As DataRow In dt1.Select("eochecki_entity=" & eociId.ToString)
          Dim drh As New Longkong.Pojjaman.DataAccessLayer.DataRowHelper(row)

          deductpayment += drh.GetValue(Of Decimal)("deductpayment")
          addedpayment += drh.GetValue(Of Decimal)("addedpayment")
        Next

        checkTr("col7") = Configuration.FormatToString(deductpayment, DigitConfig.Price)
        checkTr("col8") = Configuration.FormatToString(addedpayment, DigitConfig.Price)
      Next

      'For Each row As DataRow In DataRowsFilter(dt)
      '  Dim drh As New Longkong.Pojjaman.DataAccessLayer.DataRowHelper(row)

      '  If Not checkHs.ContainsKey(drh.GetValue(Of String)("check_id")) Then
      '    checkTr = Me.m_treeManager.Treetable.Childs.Add
      '    checkTr.State = RowExpandState.Expanded
      '    checkTr.Tag = Me.SetKeyValuePair(22, drh.GetValue(Of String)("check_id"))
      '    checkTr("col0") = "เช็คจ่าย" 'drh.GetValue(Of String)("entity_description")
      '    checkTr("col1") = drh.GetValue(Of String)("check_code")
      '    checkTr("col2") = drh.GetValue(Of String)("supplier_code") & " : " & drh.GetValue(Of String)("supplier_name")
      '    checkTr("col3") = drh.GetValue(Of String)("eochecki_detail")
      '    If IsDate(drh.GetValue(Of String)("check_issuedate")) Then
      '      checkTr("col4") = CDate(drh.GetValue(Of String)("check_issuedate")).ToShortDateString
      '    End If
      '    checkTr("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("check_amt"), DigitConfig.Price)
      '    checkTr("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("whtamt"), DigitConfig.Price)
      '    checkTr("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("deductpayment"), DigitConfig.Price)
      '    checkTr("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("addedpayment"), DigitConfig.Price)
      '    checkTr("col10") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_documentForPickup"), "DocumentForPickup")
      '    checkTr("col11") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_pickupCode"), "PickupLocationCode")
      '    checkTr("col12") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_deliveryMethod"), "DeliveryMethod")
      '    checkTr("col13") = drh.GetValue(Of String)("check_note")

      '    checkHs(drh.GetValue(Of String)("check_id")) = checkTr
      '  Else
      '    checkTr = CType(checkHs(drh.GetValue(Of String)("check_id")), TreeRow)
      '  End If

      '  billTr = Nothing
      '  If drh.GetValue(Of Integer)("billa_id") > 0 Then
      '    If Not billHs.ContainsKey(drh.GetValue(Of String)("billa_id")) Then
      '      billTr = checkTr.Childs.Add
      '      billTr.State = RowExpandState.Expanded
      '      billTr.Tag = Me.SetKeyValuePair(60, drh.GetValue(Of String)("billa_id"))

      '      billTr("col0") = indent & "ใบรับวางบิล" 'drh.GetValue(Of String)("entity_description")
      '      billTr("col1") = drh.GetValue(Of String)("billa_code")
      '      If IsDate(drh.GetValue(Of String)("billa_docdate")) Then
      '        billTr("col2") = indent & CDate(drh.GetValue(Of String)("billa_docdate")).ToShortDateString
      '      End If
      '      billTr("col3") = indent & drh.GetValue(Of String)("billa_billissueCode")
      '      If IsDate(drh.GetValue(Of String)("billa_billissueDate")) Then
      '        billTr("col4") = indent & CDate(drh.GetValue(Of String)("billa_billissueDate")).ToShortDateString
      '      End If

      '      billHs(drh.GetValue(Of String)("billa_id")) = billTr
      '    Else
      '      billTr = CType(billHs(drh.GetValue(Of String)("billa_id")), TreeRow)
      '    End If
      '  End If
      '  If drh.GetValue(Of Integer)("stockid") > 0 Then
      '    If Not billTr Is Nothing Then
      '      docTr = billTr.Childs.Add
      '      indent2 = indent & indent
      '    Else
      '      docTr = checkTr.Childs.Add
      '      indent2 = indent
      '    End If
      '    docTr.Tag = Me.SetKeyValuePair(drh.GetValue(Of String)("stocktype"), drh.GetValue(Of String)("stockid"))
      '    docTr("col0") = indent2 & drh.GetValue(Of String)("entity_description")
      '    docTr("col1") = drh.GetValue(Of String)("stockcode")
      '    If IsDate(drh.GetValue(Of String)("stockdocdate")) Then
      '      docTr("col2") = indent2 & CDate(drh.GetValue(Of String)("stockdocdate")).ToShortDateString
      '    End If
      '    docTr("col3") = indent2 & drh.GetValue(Of String)("stockotherDocCode")
      '    If IsDate(drh.GetValue(Of String)("stockotherDocDate")) Then
      '      docTr("col4") = indent2 & CDate(drh.GetValue(Of String)("stockotherDocDate")).ToShortDateString
      '    End If
      '    docTr("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_beforetax"), DigitConfig.Price)
      '    docTr("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_taxamt"), DigitConfig.Price)
      '    docTr("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_aftertax"), DigitConfig.Price)
      '    docTr("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_advance"), DigitConfig.Price)
      '    docTr("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("stockretention"), DigitConfig.Price)
      '    docTr("col10") = drh.GetValue(Of String)("posc")
      '  End If
      'Next
      dt.AcceptChanges()

      Dim lineNumber As Integer = 1
      For Each tr As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not tr.Tag Is Nothing AndAlso TypeOf tr.Tag Is KeyValuePair Then
          m_dataPreviewHs(lineNumber) = CType(tr.Tag, KeyValuePair)
        End If

        lineNumber += 1
      Next
    End Sub
    Public Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"

      Dim cs As TreeTextColumn

      cs = New TreeTextColumn(1, True, Color.White)
      cs.MappingName = "col0"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      Dim csp As New PlusMinusTreeTextColumn
      csp.MappingName = "col1"
      csp.HeaderText = ""
      csp.Width = 120
      csp.NullText = ""
      csp.Alignment = HorizontalAlignment.Left
      csp.DataAlignment = HorizontalAlignment.Left
      csp.ReadOnly = True
      csp.Format = "s"
      AddHandler csp.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(csp)

      cs = New TreeTextColumn(3, True, Color.White)
      cs.MappingName = "col2"
      cs.HeaderText = ""
      cs.Width = 180
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(4, True, Color.White)
      cs.MappingName = "col3"
      cs.HeaderText = ""
      cs.Width = 165
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(5, True, Color.White)
      cs.MappingName = "col4"
      cs.HeaderText = ""
      cs.Width = 135
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(6, True, Color.White)
      cs.MappingName = "col5"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Right
      cs.DataAlignment = HorizontalAlignment.Right
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(7, True, Color.White)
      cs.MappingName = "col6"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Right
      cs.DataAlignment = HorizontalAlignment.Right
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(8, True, Color.White)
      cs.MappingName = "col7"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Right
      cs.DataAlignment = HorizontalAlignment.Right
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(9, True, Color.White)
      cs.MappingName = "col8"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Right
      cs.DataAlignment = HorizontalAlignment.Right
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(10, True, Color.White)
      cs.MappingName = "col9"
      cs.HeaderText = ""
      cs.Width = 100
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Right
      cs.DataAlignment = HorizontalAlignment.Right
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(11, True, Color.White)
      cs.MappingName = "col10"
      cs.HeaderText = ""
      cs.Width = 150
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(12, True, Color.White)
      cs.MappingName = "col11"
      cs.HeaderText = ""
      cs.Width = 150
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(13, True, Color.White)
      cs.MappingName = "col12"
      cs.HeaderText = ""
      cs.Width = 150
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      cs = New TreeTextColumn(14, True, Color.White)
      cs.MappingName = "col13"
      cs.HeaderText = ""
      cs.Width = 150
      cs.NullText = ""
      cs.Alignment = HorizontalAlignment.Left
      cs.DataAlignment = HorizontalAlignment.Left
      cs.ReadOnly = True
      cs.Format = "s"
      AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
      dst.GridColumnStyles.Add(cs)

      Return dst
    End Function
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
    Public Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Method"
    'Private Sub SetBankBranch(Optional ByVal changedBank As Boolean = False)
    '  'Dim oldstatus As Boolean = Me.m_isInitialized
    '  'Me.m_isInitialized = False
    '  'If m_entity.BankAccount Is Nothing _
    '  'OrElse Not Me.m_entity.BankAccount.Originated Then
    '  '  txtbankbranch.Text = ""
    '  'Else
    '  '  txtbankbranch.Text = Me.m_entity.BankAccount.BankBranch.Bank.Name & " : " & Me.m_entity.BankAccount.BankBranch.Name
    '  'End If
    '  'Me.m_isInitialized = oldstatus

    '  ''ถ้าเปลี่ยนบัญชีธนาคาร ให้ล้างรายการออกให้หมด
    '  'If changedBank Then
    '  '  Me.m_entity.ItemCollection.Clear()
    '  '  RefreshDocs()
    '  'End If
    'End Sub
#End Region

    '#Region " Style "
    '    'Private DeliveryDataTable As DataTable
    '    'Private PickUpDataTable As DataTable
    '    'Public Function CreateTableStyle() As DataGridTableStyle
    '    '  Dim dst As New DataGridTableStyle
    '    '  dst.MappingName = "ExportOutGoingCheck"
    '    '  Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    '    '  ' line number ...
    '    '  Dim csLineNumber As New TreeTextColumn
    '    '  csLineNumber.MappingName = "eocheck_linenumber"
    '    '  csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.LineNumberHeaderText}")
    '    '  csLineNumber.NullText = ""
    '    '  csLineNumber.Width = 30
    '    '  csLineNumber.Alignment = HorizontalAlignment.Center
    '    '  csLineNumber.DataAlignment = HorizontalAlignment.Center
    '    '  csLineNumber.ReadOnly = True
    '    '  csLineNumber.TextBox.Name = "eocheck_linenumber"
    '    '  ' document code ...
    '    '  Dim csCode As New TreeTextColumn
    '    '  csCode.MappingName = "code"
    '    '  csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.CodeHeaderText}")
    '    '  csCode.NullText = ""
    '    '  csCode.Width = 80
    '    '  csCode.Alignment = HorizontalAlignment.Center
    '    '  csCode.DataAlignment = HorizontalAlignment.Left
    '    '  csCode.ReadOnly = False
    '    '  csCode.TextBox.Name = "code"
    '    '  ' Check Find button ...
    '    '  Dim csButton As New DataGridButtonColumn
    '    '  csButton.MappingName = "button"
    '    '  csButton.HeaderText = ""
    '    '  csButton.NullText = ""
    '    '  AddHandler csButton.Click, AddressOf CheckButtonClick
    '    '  ' SupplierCode ...
    '    '  Dim csSuppliercode As New TreeTextColumn
    '    '  csSuppliercode.MappingName = "suppliercode"
    '    '  csSuppliercode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.SupplierCodeHeaderText}")
    '    '  csSuppliercode.NullText = ""
    '    '  csSuppliercode.Width = 80
    '    '  csSuppliercode.Alignment = HorizontalAlignment.Center
    '    '  csSuppliercode.DataAlignment = HorizontalAlignment.Left
    '    '  csSuppliercode.ReadOnly = True
    '    '  csSuppliercode.TextBox.Name = "suppliercode"
    '    '  ' SupplierName ...
    '    '  Dim csSupplierName As New TreeTextColumn
    '    '  csSupplierName.MappingName = "suppliername"
    '    '  csSupplierName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.SupplierNameHeaderText}")
    '    '  csSupplierName.NullText = ""
    '    '  csSupplierName.Alignment = HorizontalAlignment.Center
    '    '  csSupplierName.DataAlignment = HorizontalAlignment.Left
    '    '  csSupplierName.Width = 150
    '    '  csSupplierName.ReadOnly = True
    '    '  csSupplierName.TextBox.Name = "suppliername"
    '    '  ' Receiver ...
    '    '  Dim csReceiver As New TreeTextColumn
    '    '  csReceiver.MappingName = "receiver"
    '    '  csReceiver.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ReceiverHeaderText}")
    '    '  csReceiver.NullText = ""
    '    '  csReceiver.Alignment = HorizontalAlignment.Center
    '    '  csReceiver.DataAlignment = HorizontalAlignment.Left
    '    '  csReceiver.Width = 150
    '    '  csReceiver.ReadOnly = True
    '    '  csReceiver.TextBox.Name = "receiver"
    '    '  ' Detail ...
    '    '  Dim csDetail As New TreeTextColumn
    '    '  csDetail.MappingName = "detail"
    '    '  csDetail.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DetailHeaderText}")
    '    '  csDetail.NullText = ""
    '    '  csDetail.Alignment = HorizontalAlignment.Center
    '    '  csDetail.DataAlignment = HorizontalAlignment.Left
    '    '  csDetail.Width = 180
    '    '  csDetail.ReadOnly = False
    '    '  csDetail.TextBox.Name = "detail"

    '    '  ' DeliveryMethod
    '    '  Dim csDelivery As DataGridComboColumn
    '    '  csDelivery = New DataGridComboColumn("deliverymethod", DeliveryDataTable, "code_description", "code_tag")
    '    '  csDelivery.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DeliveryMethodHeaderText}")
    '    '  csDelivery.NullText = String.Empty
    '    '  csDelivery.Width = 180
    '    '  csDelivery.ReadOnly = False
    '    '  ' PickupCode ...
    '    '  Dim csPickupCode As DataGridComboColumn
    '    '  csPickupCode = New DataGridComboColumn("pickuplocationcode", PickUpDataTable, "code_description", "code_tag")
    '    '  csPickupCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.PickupCodeHeaderText}")
    '    '  csPickupCode.NullText = String.Empty
    '    '  csPickupCode.Width = 120
    '    '  csPickupCode.ReadOnly = False
    '    '  ' DocumentForPickup ...
    '    '  Dim csDocumentForPickup As New TreeTextColumn
    '    '  csDocumentForPickup.MappingName = "documentforpickup"
    '    '  csDocumentForPickup.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DocumentForPickupHeaderText}")
    '    '  csDocumentForPickup.NullText = ""
    '    '  csDocumentForPickup.Alignment = HorizontalAlignment.Center
    '    '  csDocumentForPickup.DataAlignment = HorizontalAlignment.Left
    '    '  csDocumentForPickup.Width = 100
    '    '  csDocumentForPickup.ReadOnly = True
    '    '  csDocumentForPickup.TextBox.Name = "documentforpickup"
    '    '  'Doc Button
    '    '  Dim csDocumentForPickupButton As New DataGridButtonColumn
    '    '  csDocumentForPickupButton.MappingName = "docbutton"
    '    '  csDocumentForPickupButton.HeaderText = ""
    '    '  csDocumentForPickupButton.NullText = ""
    '    '  ' PVCode ...
    '    '  Dim csPVCode As New TreeTextColumn
    '    '  csPVCode.MappingName = "pvcode"
    '    '  csPVCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.PVCodeHeaderText}")
    '    '  csPVCode.NullText = ""
    '    '  csPVCode.Alignment = HorizontalAlignment.Center
    '    '  csPVCode.DataAlignment = HorizontalAlignment.Left
    '    '  csPVCode.Width = 120
    '    '  csPVCode.ReadOnly = True
    '    '  csPVCode.TextBox.Name = "pvcode"
    '    '  ' AmountOnCheck ...
    '    '  Dim csAmountOnCheck As New TreeTextColumn
    '    '  csAmountOnCheck.MappingName = "amountoncheck"
    '    '  csAmountOnCheck.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.AmountOnCheckHeaderText}")
    '    '  csAmountOnCheck.NullText = ""
    '    '  csAmountOnCheck.Width = 100
    '    '  csAmountOnCheck.Alignment = HorizontalAlignment.Center
    '    '  csAmountOnCheck.DataAlignment = HorizontalAlignment.Right
    '    '  csAmountOnCheck.ReadOnly = True
    '    '  csAmountOnCheck.Format = "#,##0.00"
    '    '  csAmountOnCheck.TextBox.Name = "amountoncheck"
    '    '  ' AmountBeforeVat ...
    '    '  Dim csAmountBeforeVat As New TreeTextColumn
    '    '  csAmountBeforeVat.MappingName = "amountbeforevat"
    '    '  csAmountBeforeVat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.AmountBeforeVatHeaderText}")
    '    '  csAmountBeforeVat.NullText = ""
    '    '  csAmountBeforeVat.Width = 100
    '    '  csAmountBeforeVat.Alignment = HorizontalAlignment.Center
    '    '  csAmountBeforeVat.DataAlignment = HorizontalAlignment.Right
    '    '  csAmountBeforeVat.ReadOnly = True
    '    '  csAmountBeforeVat.Format = "#,##0.00"
    '    '  csAmountBeforeVat.TextBox.Name = "amountbeforevat"
    '    '  ' AmountWHT ...
    '    '  Dim csWht As New TreeTextColumn
    '    '  csWht.MappingName = "amountwht"
    '    '  csWht.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.AmountWHTHeaderText}")
    '    '  csWht.NullText = ""
    '    '  csWht.Width = 80
    '    '  csWht.Alignment = HorizontalAlignment.Center
    '    '  csWht.DataAlignment = HorizontalAlignment.Right
    '    '  csWht.ReadOnly = True
    '    '  csWht.Format = "#,##0.00"
    '    '  csWht.TextBox.Name = "amountwht"
    '    '  ' AmountAfterVat ...
    '    '  Dim csAmountAfterVat As New TreeTextColumn
    '    '  csAmountAfterVat.MappingName = "amountaftervat"
    '    '  csAmountAfterVat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.AmountAfterVatHeaderText}")
    '    '  csAmountAfterVat.NullText = ""
    '    '  csAmountAfterVat.Width = 100
    '    '  csAmountAfterVat.Alignment = HorizontalAlignment.Center
    '    '  csAmountAfterVat.DataAlignment = HorizontalAlignment.Right
    '    '  csAmountAfterVat.ReadOnly = True
    '    '  csAmountAfterVat.Format = "#,##0.00"
    '    '  csAmountAfterVat.TextBox.Name = "amountaftervat"
    '    '  ' TaxCount ...
    '    '  Dim csTaxCount As New TreeTextColumn
    '    '  csTaxCount.MappingName = "taxcount"
    '    '  csTaxCount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.TaxCountHeaderText}")
    '    '  csTaxCount.NullText = ""
    '    '  csTaxCount.Alignment = HorizontalAlignment.Center
    '    '  csTaxCount.DataAlignment = HorizontalAlignment.Left
    '    '  csTaxCount.Width = 100
    '    '  csTaxCount.ReadOnly = True
    '    '  csTaxCount.TextBox.Name = "taxcount"


    '    '  ' Add column style ...
    '    '  dst.GridColumnStyles.Add(csLineNumber)
    '    '  dst.GridColumnStyles.Add(csCode)
    '    '  dst.GridColumnStyles.Add(csButton)
    '    '  dst.GridColumnStyles.Add(csSuppliercode)
    '    '  dst.GridColumnStyles.Add(csSupplierName)
    '    '  dst.GridColumnStyles.Add(csReceiver)
    '    '  dst.GridColumnStyles.Add(csDetail)
    '    '  dst.GridColumnStyles.Add(csDelivery)
    '    '  dst.GridColumnStyles.Add(csPickupCode)
    '    '  dst.GridColumnStyles.Add(csDocumentForPickup)
    '    '  dst.GridColumnStyles.Add(csDocumentForPickupButton)
    '    '  dst.GridColumnStyles.Add(csPVCode)
    '    '  dst.GridColumnStyles.Add(csAmountOnCheck)
    '    '  dst.GridColumnStyles.Add(csAmountBeforeVat)
    '    '  dst.GridColumnStyles.Add(csWht)
    '    '  dst.GridColumnStyles.Add(csAmountAfterVat)
    '    '  dst.GridColumnStyles.Add(csTaxCount)

    '    '  Return dst
    '    'End Function

    '    Public Sub CreateComboColumnMember()
    '      Dim dt0 As DataTable = CodeDescription.GetCodeList("DeliveryMethod")
    '      Dim dt1 As DataTable = CodeDescription.GetCodeList("PickupLocationCode")

    '      DeliveryDataTable = New DataTable
    '      PickUpDataTable = New DataTable
    '      For Each col As DataColumn In dt0.Columns
    '        DeliveryDataTable.Columns.Add(New DataColumn(col.ColumnName))
    '      Next
    '      For Each col As DataColumn In dt1.Columns
    '        PickUpDataTable.Columns.Add(New DataColumn(col.ColumnName))
    '      Next

    '      For Each row As DataRow In dt0.Select("", "code_tag")
    '        Dim dr As DataRow = DeliveryDataTable.NewRow()
    '        For Each col As DataColumn In dt0.Columns
    '          dr(col.ColumnName) = row(col.ColumnName)
    '        Next
    '        DeliveryDataTable.Rows.Add(dr)
    '      Next
    '      For Each row As DataRow In dt1.Select("", "code_tag")
    '        Dim dr As DataRow = PickUpDataTable.NewRow()
    '        For Each col As DataColumn In dt1.Columns
    '          dr(col.ColumnName) = row(col.ColumnName)
    '        Next
    '        PickUpDataTable.Rows.Add(dr)
    '      Next
    '      'DeliveryDataTable = CodeDescription.GetCodeList("DeliveryMethod")
    '      'PickUpDataTable = CodeDescription.GetCodeList("PickupLocationCode")

    '      ''Delivery
    '      'Dim myList1 As New SortedList
    '      'myList1.Add("CC", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DMCC}")) 'จ่ายเช็คที่เคาน์เตอร์โดยไม่มีการเก็บหลักฐานทางการเงิน
    '      'myList1.Add("CR", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DMCR}")) 'จ่ายเช็คที่เคาน์เตอร์โดยมีการเก็บหลักฐานทางการเงิน
    '      'myList1.Add("MR", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DMMR}")) 'ส่งไปรษณีย์ลงทะเบียนให้กับผู้รับเช็ค
    '      'myList1.Add("RC", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.DMRC}")) 'ส่งคืนบริษัทเพื่อแจกจ่ายให้คู่ค้า

    '      'DeliveryDataTable = New DataTable
    '      'DeliveryDataTable.Columns.Add(New DataColumn("display"))
    '      'DeliveryDataTable.Columns.Add(New DataColumn("value"))
    '      'Dim MyDataRow As DataRow
    '      'For Each myKey As DictionaryEntry In myList1
    '      '  MyDataRow = DeliveryDataTable.NewRow
    '      '  MyDataRow.Item("display") = myKey.Value
    '      '  MyDataRow.Item("value") = myKey.Key
    '      '  DeliveryDataTable.Rows.Add(MyDataRow)
    '      'Next

    '      ''Pickup
    '      'myList1.Clear()
    '      'myList1.Add("01", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick01}")) 'Phaholyothin
    '      'myList1.Add("02", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick02}")) 'Navanakorn
    '      'myList1.Add("03", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick03}")) 'Lamchabang (CL Chonburi)
    '      'myList1.Add("04", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick04}")) 'Lamchabang (Express)
    '      'myList1.Add("05", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick05}")) 'Mabtapud (CL Rayong)
    '      'myList1.Add("06", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick06}")) 'Klongtoey (Express)
    '      'myList1.Add("07", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.Pick07}")) 'Donmuang (Express)
    '      'myList1.Add("EXP1", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.PickEXP1}")) 'Silom (Express)
    '      'myList1.Add("M", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.PickM}")) 'Mail
    '      'myList1.Add("RET", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.PickRET}")) 'Return

    '      'PickUpDataTable = New DataTable
    '      'PickUpDataTable.Columns.Add(New DataColumn("display"))
    '      'PickUpDataTable.Columns.Add(New DataColumn("value"))
    '      'For Each myKey As DictionaryEntry In myList1
    '      '  MyDataRow = PickUpDataTable.NewRow
    '      '  MyDataRow.Item("display") = myKey.Value
    '      '  MyDataRow.Item("value") = myKey.Key
    '      '  PickUpDataTable.Rows.Add(MyDataRow)
    '      'Next
    '    End Sub
    '#End Region

#Region "Properties"
    Public ReadOnly Property Treemanager() As TreeManager      Get        Return m_treeManager      End Get    End Property
    Private ReadOnly Property CurrentItem() As KeyValuePair
      Get
        Dim row As TreeRow = Me.m_entity.TreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is KeyValuePair Then
          Return Nothing
        End If
        Return CType(row.Tag, KeyValuePair)
      End Get
    End Property
#End Region

#Region "IListDetail"
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      RefreshDocs()
      'CheckFormEnable()
      'SetStatus()
      SetLabelText()

      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.InitialGridControl()
      'Me.m_entity.PopulatePaymentTrack(m_treeManager.Treetable)
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Me.m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          'If Not Me.m_entity Is Nothing Then
          '  Me.m_entity.ClearReference()
          'End If
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, ExportOutgoingCheck)
        End If

        'Me.m_entity = CType(Value, ExportOutgoingCheck)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region "Event Handlers"
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim doc As KeyValuePair = CType(m_dataPreviewHs(e.RowIndex), KeyValuePair)
      If doc Is Nothing Then
        Return
      End If

      Dim docId As Integer = CInt(doc.Value)
      Dim docType As Integer = CInt(doc.Key)

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If

    End Sub
#End Region

#Region " Event of Button controls "
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      If Me.m_entity.Originated Then
        Dim CurrentUserId As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id
        Dim newStatus As String = Me.m_entity.CheckExportPaymentTrackStatus
        If newStatus.Trim.ToLower = "" Then
          Me.m_entity.SaveExportPaymentTrackStatus("N", CurrentUserId)
          Me.m_entity.PaymentTrackStatus = "N"
        Else
          Me.m_entity.SaveExportPaymentTrackStatus("U", CurrentUserId)
          Me.m_entity.PaymentTrackStatus = newStatus
        End If
        'Me.m_entity.ExportPaymentTrackFile()
        'Me.m_entity.ExportPaymentTrackOnLine()
        Dim saveerr As SaveErrorException = Me.m_entity.ExportPaymentTrack
        If Not IsNumeric(saveerr.Message) Then
          MessageBox.Show("Failed to export. " & vbCrLf & saveerr.Message)
        Else
          If CInt(saveerr.Message) = -2 Then
            Return
          End If
          If CInt(saveerr.Message) = 0 Then
            MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ExportCompleted}"))
          End If
        End If
      End If

    End Sub

    'Private Sub ExportPaymentTrackFile()
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  'If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
    '  '  msgServ.ShowMessage(Validator.ValidationSummary)
    '  '  Return
    '  'End If

    '  'Dim culture As New CultureInfo("en-US", True)
    '  Dim myOpb As New SaveFileDialog
    '  myOpb.Filter = "All Files|*.*|Text File (*.txt)|*.txt"
    '  myOpb.FilterIndex = 2
    '  myOpb.FileName = "PaymentTrack_" & Me.m_entity.PayerBuilkID & "_" & Me.m_entity.Id.ToString & ".txt"
    '  If myOpb.ShowDialog() = DialogResult.OK Then
    '    Dim fileName As String = Path.GetDirectoryName(myOpb.FileName) & Path.DirectorySeparatorChar & Path.GetFileName(myOpb.FileName)
    '    Dim writer As New IO.StreamWriter(fileName, False, System.Text.Encoding.Default)

    '    Try
    '      Exporter.ExportPaymentTrack(m_entity, writer)
    '      MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ExportCompleted}"))
    '    Catch ex As Exception
    '      MessageBox.Show("Error:" & ex.ToString)
    '    Finally
    '      writer.Close()
    '    End Try

    '  End If
    'End Sub

    'Private Sub ExportPaymentTrackOnLine()

    '  Dim BuilkID As String = Configuration.GetConfig("BuilkID").ToString

    '  If BuilkID = "" Then
    '    Return
    '  End If

    '  'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/approvebuilksupplier/?bid=12")
    '  Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/Transaction/?bid=" & BuilkID)
    '  request.Method = "POST"




    '  Dim postData As String = ""
    '  'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    '  Dim dataStream As Stream = request.GetRequestStream()

    '  Dim writer As New IO.StreamWriter(dataStream, System.Text.Encoding.UTF8)

    '  Try
    '    Exporter.ExportPaymentTrack(m_entity, writer)
    '    'MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ExportCompleted}"))
    '  Catch ex As Exception
    '    MessageBox.Show("Error:" & ex.ToString)
    '  Finally
    '    writer.Close()

    '  End Try

    '  request.ContentType = "text/plain"
    '  request.ContentLength = dataStream.Length 'byteArray.Length
    '  'dataStream.Write(byteArray, 0, byteArray.Length)

    '  dataStream.Close()

    '  Dim response As WebResponse = request.GetResponse()
    '  'dataStream = response.GetResponseStream()
    '  'Dim reader As New StreamReader(dataStream)
    '  'Dim responseFromServer As String = reader.ReadToEnd()
    '  'reader.Close()
    '  'dataStream.Close()
    '  response.Close()

    'End Sub

#End Region

#Region "IValidatable"
    'Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
    '  Get
    '    Return Me.Validator
    '  End Get
    'End Property
#End Region

    Private Sub chkSupplier_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSupplier.CheckedChanged
      If m_entity Is Nothing Then
        Return
      End If

      RefreshDocs()
    End Sub

  End Class

End Namespace
