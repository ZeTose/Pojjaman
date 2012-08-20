Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ProjectReceivePaymentDetailPrintPreview
    Inherits AbstractEntityDetailPanelView
    'Inherits UserControl
    Implements IValidatable ', IAuxTab, IAuxTabItem

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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'Panel1
      '
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(672, 512)
      Me.Panel1.TabIndex = 0
      '
      'ProjectReceivePaymentDetailPrintPreview
      '
      Me.Controls.Add(Me.Panel1)
      Me.Name = "ProjectReceivePaymentDetailPrintPreview"
      Me.Size = New System.Drawing.Size(672, 512)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    'Private m_treeManager As TreeManager
    'Private m_vat As Vat

    'Private m_tableStyleEnable As Hashtable

    'Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      'm_tableStyleEnable = New Hashtable

      'Dim dt As TreeTable = Vat.GetSchemaTable()
      'Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      'm_treeManager = New TreeManager(dt, tgItem)
      'm_treeManager.SetTableStyle(dst)
      'm_treeManager.AllowSorting = False
      'm_treeManager.AllowDelete = False
      'tgItem.AllowNew = False

      'AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      'AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      'AddHandler dt.RowDeleted, AddressOf VatItemDelete

      'EventWiring()

    End Sub
    Private Sub SaveEnableState()
      'm_enableState = New Hashtable
      'For Each ctrl As Control In Me.grbDetail.Controls
      '  m_enableState.Add(ctrl, ctrl.Enabled)
      'Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      'Dim dst As New DataGridTableStyle
      'dst.MappingName = "Vat"
      'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Dim csSelected As New DataGridCheckBoxColumn
      'csSelected.MappingName = "Selected"
      'csSelected.HeaderText = ""
      ''AddHandler csSelected.Click, AddressOf RowIcon_Click

      'Dim csLineNumber As New TreeTextColumn
      'csLineNumber.MappingName = "vati_linenumber"
      'csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.LineNumberHeaderText}")
      'csLineNumber.NullText = ""
      'csLineNumber.Width = 30
      'csLineNumber.DataAlignment = HorizontalAlignment.Center
      'csLineNumber.ReadOnly = True
      'csLineNumber.TextBox.Name = "vati_linenumber"

      'Dim csRunNumber As New TreeTextColumn
      'csRunNumber.MappingName = "vati_runnumber"
      'csRunNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.RunHeaderText}")
      'csRunNumber.NullText = ""
      'csRunNumber.Width = 60
      'csRunNumber.TextBox.Name = "vati_runnumber"
      ''csRunNumber.ReadOnly = True

      'Dim csCode As New TreeTextColumn
      'csCode.MappingName = "vati_code"
      'csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.CodeHeaderText}")
      'csCode.NullText = ""
      'csCode.Width = 60
      'csCode.TextBox.Name = "vati_code"

      'Dim csDocDate As New DataGridTimePickerColumn
      'csDocDate.MappingName = "vati_docdate"
      'csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.DocDateHeaderText}")
      'csDocDate.NullText = ""
      'csDocDate.Width = 100

      'Dim csSupplierButton As New DataGridButtonColumn
      'csSupplierButton.MappingName = "SupplierButton"
      'csSupplierButton.HeaderText = ""
      'csSupplierButton.NullText = ""
      'AddHandler csSupplierButton.Click, AddressOf SupplierButtonClick

      'Dim csPrintName As New TreeTextColumn
      'csPrintName.MappingName = "vati_printname"
      'csPrintName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.PrintNameHeaderText}")
      'csPrintName.NullText = ""
      'csPrintName.Width = 100
      'csPrintName.TextBox.Name = "vati_printname"

      'Dim csPrintAddress As New TreeTextColumn
      'csPrintAddress.MappingName = "vati_printaddress"
      'csPrintAddress.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.PrintAddressHeaderText}")
      'csPrintAddress.NullText = ""
      'csPrintAddress.Width = 180
      'csPrintAddress.TextBox.Name = "vati_printaddress"

      'Dim csTaxBase As New TreeTextColumn
      'csTaxBase.MappingName = "vati_taxbase"
      'csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.TaxBaseHeaderText}")
      'csTaxBase.NullText = ""
      'csTaxBase.DataAlignment = HorizontalAlignment.Right
      'csTaxBase.Format = "#,###.##"
      'csTaxBase.TextBox.Name = "vati_taxbase"
      'csTaxBase.Width = 60

      'Dim csTaxRate As New TreeTextColumn
      'csTaxRate.MappingName = "vati_taxrate"
      'csTaxRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.TaxRateHeaderText}")
      'csTaxRate.NullText = ""
      'csTaxRate.DataAlignment = HorizontalAlignment.Right
      'csTaxRate.Format = "#,###.##"
      'csTaxRate.TextBox.Name = "vati_taxrate"
      'csTaxRate.Width = 60
      'csTaxRate.ReadOnly = True


      'Dim csAmount As New TreeTextColumn
      'csAmount.MappingName = "Amount"
      'csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.AmountHeaderText}")
      'csAmount.NullText = ""
      'csAmount.DataAlignment = HorizontalAlignment.Right
      'csAmount.Format = "#,###.##"
      'csAmount.TextBox.Name = "Amount"
      'csAmount.Width = 60

      'Dim csNote As New TreeTextColumn
      'csNote.MappingName = "vati_note"
      'csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.NoteHeaderText}")
      'csNote.NullText = ""
      'csNote.Width = 100
      'csNote.TextBox.Name = "vati_note"

      'dst.GridColumnStyles.Add(csLineNumber)
      'dst.GridColumnStyles.Add(csSelected)
      'dst.GridColumnStyles.Add(csRunNumber)
      'dst.GridColumnStyles.Add(csCode)
      'dst.GridColumnStyles.Add(csDocDate)
      'dst.GridColumnStyles.Add(csSupplierButton)
      'dst.GridColumnStyles.Add(csPrintName)
      'dst.GridColumnStyles.Add(csPrintAddress)
      'dst.GridColumnStyles.Add(csTaxBase)
      'dst.GridColumnStyles.Add(csTaxRate)
      'dst.GridColumnStyles.Add(csAmount)
      'dst.GridColumnStyles.Add(csNote)

      'For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
      '  m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      'Next
      'Return dst
    End Function
    Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
      'Dim myTable As TreeTable = Me.m_treeManager.Treetable
      ''******************************************************************************
      'Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
      'If CBool(clickedRow("Selected")) Then
      '  TreeRow.TraverseRow(clickedRow, AddressOf CheckRow)
      'Else
      '  TreeRow.TraverseRow(clickedRow, AddressOf UnCheckRow)
      'End If
      ''***************ถ้าไม่ AccepChanges จะเพี้ยน*************
      'Me.m_treeManager.Treetable.AcceptChanges()
      ''Me.tgItem.RefreshHeights()
      ''******************************************************************************
    End Sub
    Private Sub CheckRow(ByVal tr As TreeRow)
      'tr("Selected") = True
    End Sub
    Private Sub UnCheckRow(ByVal tr As TreeRow)
      'tr("Selected") = False
    End Sub
    Private m_allSelected As Boolean = False
    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'm_allSelected = Not m_allSelected
      'For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
      '  m_treeManager.Treetable.Rows(i)("Selected") = m_allSelected
      'Next
    End Sub

#End Region

#Region "Properties"
    'Private ReadOnly Property CurrentItem() As VatItem
    'Get
    '  Dim row As TreeRow = Me.m_treeManager.SelectedRow
    '  If row Is Nothing Then
    '    Return Nothing
    '  End If
    '  If Not TypeOf row.Tag Is VatItem Then
    '    Return Nothing
    '  End If
    '  Return CType(row.Tag, VatItem)
    'End Get
    'End Property
#End Region

#Region "ItemTreeTable Handlers"
    'Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '  If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
    '    Return
    '  End If
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  Dim index As Integer = Me.tgItem.CurrentRowIndex
    '  RefreshDocs()
    '  tgItem.CurrentRowIndex = index
    'End Sub
    'Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '  If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
    '    Return
    '  End If
    '  If Me.m_treeManager.SelectedRow Is Nothing Then
    '    Return
    '  End If
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If



    '  Dim doc As VatItem = Me.CurrentItem

    '  If TypeOf m_entity Is ReceiveSelection Then

    '    If doc Is Nothing Then
    '      doc = New VatItem

    '      If Me.m_vat.ItemCollection.Count.Equals(0) Then
    '        If Me.m_vat.RefDoc.GetMaximumTaxBase - Me.m_vat.RefDoc.TaxBase > 0 Then
    '          doc.TaxBase = Me.m_vat.RefDoc.GetMaximumTaxBase - Me.m_vat.RefDoc.TaxBase
    '          Me.m_vat.ItemCollection.Add(doc)
    '        Else
    '          msgServ.ShowMessage("${res:Global.Error.MaximumTaxBase}")
    '          Return
    '        End If
    '      Else
    '        Dim mVat As Decimal = 0
    '        For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
    '          If IsNumeric(row("vati_taxbase")) Then
    '            mVat += CDec(row("vati_taxbase"))
    '          End If
    '        Next
    '        If Me.m_vat.VatTaxBase - mVat > 0 Then
    '          doc.TaxBase = Me.m_vat.VatTaxBase - mVat
    '          Me.m_vat.ItemCollection.Add(doc)
    '        Else
    '          msgServ.ShowMessageFormatted("${res:Global.Error.OverTaxBase}", New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)})
    '          Return
    '        End If

    '      End If

    '      Me.m_treeManager.SelectedRow.Tag = doc
    '    End If
    '    'ElseIf TypeOf m_entity Is APVatInput Then
    '    '  If doc Is Nothing Then

    '    '    'Dim myCC As CostCenter = CType(m_entity, APVatInput).GetCCFromItem()
    '    '    'If myCC Is Nothing OrElse Not myCC.Originated Then
    '    '    '  myCC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
    '    '    'End If

    '    '    doc = New VatItem

    '    '    'doc.CcId = myCC.Id

    '    '    Me.m_vat.ItemCollection.Add(doc)
    '    '    Me.m_treeManager.SelectedRow.Tag = doc

    '    '  End If
    '  Else
    '    If doc Is Nothing Then
    '      doc = New VatItem
    '      Me.m_vat.ItemCollection.Add(doc)
    '      Me.m_treeManager.SelectedRow.Tag = doc
    '    End If
    '  End If

    '  Try
    '    Select Case e.Column.ColumnName.ToLower
    '      Case "vati_runnumber"
    '        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
    '          e.ProposedValue = ""
    '        End If
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        doc.Runnumber = CStr(e.ProposedValue)
    '      Case "vati_code"
    '        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
    '          e.ProposedValue = ""
    '        End If
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        Dim oldcode As String = doc.Code
    '        doc.Code = CStr(e.ProposedValue)
    '        If (oldcode Is Nothing OrElse oldcode.Length = 0) AndAlso doc.Amount = 0 Then
    '          doc.SetVatAmount()
    '        End If
    '      Case "vati_printname"
    '        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
    '          e.ProposedValue = ""
    '        End If
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        doc.PrintName = CStr(e.ProposedValue)
    '      Case "vati_docdate"
    '        If IsDate(e.ProposedValue) Then
    '          doc.DocDate = CDate(e.ProposedValue)
    '        Else
    '          doc.DocDate = Date.MinValue
    '        End If
    '      Case "vati_printaddress"
    '        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
    '          e.ProposedValue = ""
    '        End If
    '        doc.PrintAddress = CStr(e.ProposedValue)
    '      Case "vati_taxbase"
    '        If IsDBNull(e.ProposedValue) Then
    '          e.ProposedValue = ""
    '          Return
    '        End If
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        Dim value As Decimal = 0
    '        If IsNumeric(e.ProposedValue) Then
    '          value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
    '        End If

    '        If TypeOf m_entity Is ReceiveSelection Then
    '          Dim oldvalue As Decimal = 0
    '          If Not e.Row.IsNull(e.Column) Then
    '            If IsNumeric(e.Row(e.Column)) Then
    '              oldvalue = CDec(e.Row(e.Column))
    '            End If
    '          End If
    '          Dim viTaxBase2 As Decimal = 0
    '          For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
    '            If IsNumeric(row("vati_taxbase")) Then
    '              viTaxBase2 += CDec(row("vati_taxbase"))
    '            End If
    '          Next
    '          Dim obj As Object = Configuration.GetConfig("VatAcceptDiffAmount")
    '          Dim tmpTaxbase As Decimal = (viTaxBase2 - oldvalue + value)
    '          If tmpTaxbase > Me.m_vat.VatTaxBase Then
    '            If tmpTaxbase - Me.m_vat.VatTaxBase < CDec(obj) Then
    '              If Not msgServ.AskQuestionFormatted(StringParserService.Parse("${res:Global.Error.ReceiveSelectionDiffTaxBaseAndVatTaxBase}"), _
    '                                     New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price), _
    '                                                   Configuration.FormatToString(tmpTaxbase, DigitConfig.Price)}) Then
    '                Return
    '              End If
    '            Else
    '              msgServ.ShowMessageFormatted("${res:Global.Error.OverTaxBase}", _
    '                            New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)})
    '              e.ProposedValue = e.Row(e.Column)
    '              Return
    '            End If
    '          End If
    '        End If

    '        doc.TaxBase = value
    '      Case "vati_taxrate"
    '        If IsDBNull(e.ProposedValue) Then
    '          e.ProposedValue = ""
    '        End If
    '        Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        doc.TaxRate = value
    '      Case "amount"
    '        If IsDBNull(e.ProposedValue) Then
    '          e.ProposedValue = ""
    '        End If
    '        If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
    '          CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
    '        End If
    '        Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
    '        doc.Amount = value
    '      Case "vati_note"
    '        If IsDBNull(e.ProposedValue) Then
    '          e.ProposedValue = ""
    '        End If
    '        doc.Note = e.ProposedValue.ToString
    '    End Select
    '    doc.AutoGen = True
    '  Catch ex As Exception
    '    MessageBox.Show(ex.ToString)
    '  End Try
    'End Sub
    'Private Sub VatItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    'End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      'Dim enableForm As Boolean = False
      'If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) _
      'OrElse (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value = 0) _
      'Then
      '  enableForm = False
      'Else
      '  enableForm = True
      'End If
      'If TypeOf Me.m_entity Is IVatable AndAlso CType(Me.m_entity, IVatable).NoVat Then
      '  enableForm = False
      'End If
      'If Not enableForm Then
      '  For Each ctrl As Control In grbDetail.Controls
      '    ctrl.Enabled = False
      '  Next
      '  tgItem.Enabled = True
      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    If colStyle.MappingName.ToLower <> "selected" Then
      '      colStyle.ReadOnly = True
      '    End If
      '  Next
      'Else
      '  For Each ctrl As Control In Me.grbDetail.Controls
      '    ctrl.Enabled = CBool(m_enableState(ctrl))
      '  Next
      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '  Next
      'End If
    End Sub

    Public Overrides Sub ClearDetail()
      'lblStatus.Text = ""
      'For Each crlt As Control In grbDetail.Controls
      '  If crlt.Name.StartsWith("txt") Then
      '    crlt.Text = ""
      '  End If
      'Next
    End Sub
    Public Overrides Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.grbDetail}")
      'Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblNote}")
      'Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblAmount}")
      'Me.lblBaht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblBaht}")
      'Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblBaht1}")
      'Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblRefDocDate}")
      'Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblRefDoc}")
      'Me.lblRefVAT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblRefVAT}")
      'Me.lblDirection.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblVATType}")
      'Me.Label2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.Label2}")
      'Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.grbRefDoc}")
      'Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblBase}")
      'Me.lblRefTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblRefTaxBase}")

      'Me.grbSubmit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.grbSubmit}")
      'Me.lblVatGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblVatGroup}")
      'Me.lblSubmitalDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailPrintPreview.lblSubmitalDate}")

    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtVatGroupCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtSubmitalDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpSubmitalDate.ValueChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Private m_tmpsubmitalDate As Date = Now
    Public Overrides Sub UpdateEntityProperties()

      Dim xtform As New XtraForm(CType(Me.Entity, INewPrintableEntity), "", Me.Entity)
      xtform.Dock = DockStyle.Fill
      Me.Panel1.Controls.Add(xtform)

      'm_isInitialized = False
      'ClearDetail()
      'If m_vat Is Nothing Then
      '  Return
      'End If

      'RefreshDocs()

      'If Not Me.m_vat.Originated Then
      '  Dim Config As Object = Configuration.GetConfig("TabDetailNoteToOtherTab")
      '  If CBool(Config) Then
      '    If Me.m_vat.Note Is Nothing OrElse Me.m_vat.Note.Length = 0 Then
      '      If TypeOf Me.m_vat.RefDoc Is IPayable Then
      '        Me.m_vat.Note = CType(m_vat.RefDoc, IPayable).Note
      '      End If
      '      If TypeOf Me.m_vat.RefDoc Is IReceivable Then
      '        Me.m_vat.Note = CType(m_vat.RefDoc, IReceivable).Note
      '      End If
      '    End If
      '  End If
      'End If

      'Me.txtNote.Text = Me.m_vat.Note

      ''Me.m_vat.RefDoc.Date
      'm_tmpsubmitalDate = Me.m_vat.SubmitalDate
      'txtSubmitalDate.Text = MinDateToNull(m_tmpsubmitalDate, "")
      'dtpSubmitalDate.Value = MinDateToNow(m_tmpsubmitalDate)

      'txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
      'txtVatGroupName.Text = Me.m_vat.VatGroup.Name

      'Me.m_vat.RefreshVatTaxBase()

      'UpdateRefDoc()

      'SetStatus()
      'SetLabelText()
      'CheckFormEnable()
      'm_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      'Dim ini As Boolean
      'If Me.m_isInitialized Then
      '  Me.m_isInitialized = False
      '  ini = True
      'Else
      '  ini = False
      'End If
      'Me.m_vat.ItemCollection.Populate(m_treeManager.Treetable)
      'RefreshBlankGrid()
      'ReIndex()
      'Me.m_treeManager.Treetable.AcceptChanges()
      'Me.UpdateAmount()
      'Me.m_isInitialized = ini
    End Sub
    Private Sub UpdateRefDoc()
      'Me.txtRefDocCode.Text = Me.m_vat.RefDoc.Code
      'Me.txtRefDocDate.Text = MinDateToNull(Me.m_vat.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'Me.dtpRefDocDate.Value = MinDateToNow(Me.m_vat.RefDoc.Date)
      ''Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_vat.RefDoc.GetMaximumTaxBase, DigitConfig.Price)
      'Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)

      'For Each item As IdValuePair In Me.cmbDirection.Items
      '  If Me.m_vat.Direction.Value = item.Id Then
      '    Me.cmbDirection.SelectedItem = item
      '  End If
      'Next
    End Sub
    Private Sub UpdateAmount()
      'Dim viTaxBase As Decimal = 0
      'For Each vi As VatItem In Me.m_vat.ItemCollection
      '  viTaxBase += vi.TaxBase
      'Next
      'Me.txtAmount.Text = Configuration.FormatToString(Me.m_vat.Amount, DigitConfig.Price)
      ''Me.txtTaxBase.Text = Configuration.FormatToString(Me.m_vat.TaxBase, DigitConfig.Price)
      'Me.txtTaxBase.Text = Configuration.FormatToString(viTaxBase, DigitConfig.Price)
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If e.Name = "ItemChanged" Then
      '  UpdateAmount()
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      'If Me.m_vat Is Nothing Or Not m_isInitialized Then
      '  Return
      'End If
      'Dim dirtyFlag As Boolean = False
      'Select Case CType(sender, Control).Name.ToLower
      '  Case "txtnote"
      '    Me.m_vat.Note = Me.txtNote.Text
      '    dirtyFlag = True
      '  Case "txtvatgroupcode"
      '    dirtyFlag = VatGroup.GetVatGroup(txtVatGroupCode, txtVatGroupName, Me.m_vat.VatGroup)
      '    txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
      '  Case "dtpsubmitaldate"
      '    If Not Me.m_tmpsubmitalDate.Date.Equals(dtpSubmitalDate.Value.Date) Then
      '      If Not m_dateSetting Then
      '        Me.txtSubmitalDate.Text = MinDateToNull(dtpSubmitalDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      '        m_tmpsubmitalDate = dtpSubmitalDate.Value
      '        Me.m_vat.SubmitalDate = m_tmpsubmitalDate
      '      End If
      '      dirtyFlag = True
      '    End If
      '  Case "txtsubmitaldate"
      '    m_dateSetting = True
      '    If Not Me.txtSubmitalDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDate) = "" Then
      '      Dim theDate As Date = CDate(Me.txtSubmitalDate.Text)
      '      If Not Me.m_tmpsubmitalDate.Date.Equals(theDate.Date) Then
      '        dtpSubmitalDate.Value = theDate
      '        m_tmpsubmitalDate = dtpSubmitalDate.Value
      '        Me.m_vat.SubmitalDate = m_tmpsubmitalDate
      '        dirtyFlag = True
      '      End If
      '    Else
      '      Me.dtpSubmitalDate.Value = Date.Now
      '      m_tmpsubmitalDate = Date.MinValue
      '      Me.m_vat.SubmitalDate = m_tmpsubmitalDate
      '      dirtyFlag = True
      '    End If
      '    m_dateSetting = False
      'End Select
      'Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      'CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '	lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '	" " & m_entity.CancelDate.ToShortTimeString & _
      '	"  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '	lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '	" " & m_entity.LastEditDate.ToShortTimeString & _
      '	"  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '	lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '	" " & m_entity.OriginDate.ToShortTimeString & _
      '	"  โดย:" & m_entity.Originator.Name
      'Else
      '	lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = Value
          'If Not m_vat Is Nothing Then
          '  RemoveHandler Me.m_vat.PropertyChanged, AddressOf PropChanged
          '  Me.m_vat = Nothing
          'End If
          'If TypeOf m_entity Is IVatable Then
          '  Dim vatRefDoc As IVatable = CType(m_entity, IVatable)
          '  m_vat = vatRefDoc.Vat
          '  If m_vat Is Nothing Then
          '    m_vat = New Vat
          '    m_vat.RefDoc.Vat = m_vat
          '  End If
          '  m_vat.RefDoc = vatRefDoc
          '  m_vat.Entity = vatRefDoc.Person
          'End If
        End If
        'If Not Me.m_vat Is Nothing Then
        '  Me.m_vat.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        'End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDirection, "vat_direction")
    End Sub
#End Region

#Region "Buttons Event"
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim index As Integer = tgItem.CurrentRowIndex
      'If index > Me.m_vat.ItemCollection.Count - 1 Then
      '  Return
      'End If
      'Dim vItem As New VatItem
      'vItem.AutoGen = True
      'Me.m_vat.ItemCollection.Insert(index, vItem)
      'RefreshDocs()
      'tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'If index > Me.m_vat.ItemCollection.Count - 1 Then
      '  Return
      'End If
      'Me.m_vat.ItemCollection.Remove(index)
      'Me.tgItem.CurrentRowIndex = index
      'RefreshDocs()
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      'Dim i As Integer = 0
      'For Each row As DataRow In Me.m_treeManager.Treetable.Rows
      '  row("vati_linenumber") = i + 1
      '  If row.IsNull("Selected") Then
      '    row("Selected") = False
      '  End If
      '  i += 1
      'Next
    End Sub

    ' VatGroup
    Private Sub btnVatGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'myEntityPanelService.OpenPanel(New VatGroup)
    End Sub
    Private Sub btnVatGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim myEntityPanelService As IEntityPanelService = _
      'CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatGroupDialog)
    End Sub
    Private Sub SetVatGroupDialog(ByVal e As ISimpleEntity)
      'Me.txtVatGroupCode.Text = e.Code
      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      ' Me.WorkbenchWindow.ViewContent.IsDirty _
      ' Or VatGroup.GetVatGroup(txtVatGroupCode, txtVatGroupName, Me.m_vat.VatGroup)
    End Sub
    'SupplierButton
    Public Sub SupplierButtonClick(ByVal e As ButtonColumnEventArgs)
      'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'If Not m_vat.Entity Is Nothing Then
      '  If TypeOf m_vat.Entity Is Supplier Then
      '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
      '  Else
      '    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
      '  End If
      'End If

    End Sub
    Private Sub SetSupplier(ByVal supplier As ISimpleEntity)
      'Me.m_treeManager.SelectedRow("vati_printname") = CType(supplier, Supplier).Name
      'Me.m_treeManager.SelectedRow("vati_printaddress") = CType(supplier, Supplier).BillingAddress
    End Sub
    Private Sub SetCustomer(ByVal customer As ISimpleEntity)
      'Me.m_treeManager.SelectedRow("vati_printname") = CType(customer, Customer).Name
      'Me.m_treeManager.SelectedRow("vati_printaddress") = CType(customer, Customer).BillingAddress
    End Sub
    Private Sub btnAutorun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ''m_allSelected = Not m_allSelected
      'Dim i As Integer = 0
      'For Each item As VatItem In Me.m_vat.ItemCollection
      '  i = i + 1
      '  If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
      '    If item.AutoGen Then
      '      item.AutoGen = False
      '    Else
      '      item.AutoGen = True
      '    End If
      '  End If
      'Next
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New Vat).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "IPrintable"

    Public Overrides ReadOnly Property PrintDocuments() As ArrayList
      Get
        '  Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        '  Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        '  Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        '  Dim PrintingReportType As ReportExtentionType = ReportExtentionType.XMLReport
        '  Dim thePath As String = ""
        '  Dim fileName As String = (New VatItem).GetDefaultForm
        '  If fileName Is Nothing OrElse fileName.Length = 0 Then
        '    fileName = m_vat.ClassName
        '  End If
        '  thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

        '  Dim paths As FormPaths
        '  Dim nameForPath As String
        '  nameForPath = m_vat.FullClassName & ".Documents"
        '  Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        '  paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_vat.ClassName, thePath)), FormPaths)
        '  Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
        '  If dlg.ShowDialog() = DialogResult.OK Then
        '    thePath = dlg.KeyValuePair.Value
        '  Else
        '    Return Nothing
        '  End If
        '  If thePath.EndsWith(".rpt") Then
        '    PrintingReportType = ReportExtentionType.CrystalReport
        '  ElseIf thePath.EndsWith(".repx") Then
        '    PrintingReportType = ReportExtentionType.XtraReport
        '  End If
        '  If Not Me.m_vat Is Nothing Then
        '    '--Report form แบบใหม่--
        '    If PrintingReportType = ReportExtentionType.CrystalReport Then
        '      Dim crform As New CrystalForm(Me.Entity, thePath)
        '      crform.ShowDialog()
        '      Return Nothing
        '    ElseIf PrintingReportType = ReportExtentionType.XtraReport Then
        '      If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
        '        '--เฉพาะรายงานเท่านั้นที่จะเข้าส่วนนี้--
        '        '--เพราะว่า Entity เป็นรายงานจริง แต่ว่า Schema และ Data อยากได้ข้อมูลที่มาจาก Grid ที่ Preview อยู่--
        '        '--ยัดค่ามาจาก GridReportPanelView เรียบร้อยแล้ว--
        '        If Not m_vat.NewPrintableEntities Is Nothing AndAlso
        '          TypeOf m_vat.NewPrintableEntities Is GridReportPanelView Then
        '          Dim xtform As New XtraForm(m_vat.NewPrintableEntities, thePath, m_vat)
        '          xtform.ShowDialog()
        '          Return Nothing
        '        End If
        '      End If

        '      If TypeOf m_vat Is INewPrintableEntity Then
        '        Dim xtform As New XtraForm(CType(m_vat, INewPrintableEntity), thePath, m_vat)
        '        xtform.ShowDialog()
        '      End If

        '      'Dim xtform As New XtraForm(Me.Entity, thePath, New SuperPrintableEntity)

        '      Return Nothing
        '    End If

        '    '--Report form แบบเดิม--
        '    Dim arr As New ArrayList
        '    For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
        '      If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
        '        If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
        '          Dim item As VatItem = Me.m_vat.ItemCollection(i)
        '          If File.Exists(thePath) Then
        '            Dim newItem As New VatItemWithCustomNote(item)
        '            Dim df As New DesignerForm(thePath, newItem)
        '            arr.Add(df.PrintDocument)
        '          End If
        '        End If
        '      End If
        '    Next
        '    Return arr
        '  End If
      End Get
    End Property
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Return Nothing
      End Get
    End Property
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If Me.m_vat Is Nothing Then
      '  Return
      'End If
      'RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '  Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
      '  'เพิ่มแถวจนเต็ม
      '  Me.m_treeManager.Treetable.Childs.Add()
      'Loop

      'If Me.m_vat.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '  Me.m_treeManager.Treetable.Childs.Add()
      'End If

      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
      'MyBase.NotifyAfterSave(flag)
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "IAuxTab"
    'Public ReadOnly Property AuxEntity() As IDirtyAble Implements IAuxTab.AuxEntity
    '  Get
    '    If Me.m_vat Is Nothing OrElse Me.m_vat.ItemCollection Is Nothing Then
    '      Return Nothing
    '    End If
    '    For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
    '      If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
    '        If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
    '          Dim item As VatItem = Me.m_vat.ItemCollection(i)
    '          Return Nothing
    '        End If
    '      End If
    '    Next
    '    Return m_vat
    '  End Get
    'End Property
#End Region
#Region "IAuxTabItem"
    'Public ReadOnly Property AuxEntityItem() As Object Implements IAuxTabItem.AuxEntityItem
    '  Get
    '    For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
    '      If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
    '        If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
    '          Dim item As VatItem = Me.m_vat.ItemCollection(i)
    '          Return item
    '        End If
    '      End If
    '    Next
    '    Return m_vat
    '  End Get
    'End Property
#End Region

    Public Overrides Sub ShowSelectSchemaDataDialog()
      If Not Me.Entity Is Nothing Then
        If TypeOf Me.Entity Is ISimpleEntity Then
          If TypeOf Me.Entity Is IVatable Then
            If Not CType(Me.Entity, IVatable).Vat Is Nothing Then
              Dim m_newvat As Vat = CType(Me.Entity, IVatable).Vat

              'If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              'If TypeOf Me.Entity Is INewPrintableEntity Then
              m_newvat.NewPrintableEntities = CType(m_newvat, INewPrintableEntity)
              Dim dialog As New SchemaDataExportDialog(CType(m_newvat, INewPrintableEntity), m_newvat) ', New SuperPrintableEntity)
              dialog.StartPosition = FormStartPosition.CenterParent
              dialog.ShowDialog()
              'End If
              'End If
            End If
          End If
        End If
      End If
    End Sub

  End Class
End Namespace