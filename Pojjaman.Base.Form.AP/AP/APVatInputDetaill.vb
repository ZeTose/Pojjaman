Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class APVatInputDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable
    'Inherits UserControl

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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents grbSupplier As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnUpDateVat As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(APVatInputDetail))
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.grbSupplier = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnUpDateVat = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbSupplier.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(16, 16)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(72, 18)
      Me.lblSupplier.TabIndex = 2
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(64, 20)
      Me.txtSupplierCode.TabIndex = 0
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 64)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 9
      Me.lblItem.Text = "รายการชำระหนี้:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(336, 56)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(416, 20)
      Me.txtNote.TabIndex = 3
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(240, 56)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 12
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSupplier
      '
      Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplier.Image = CType(resources.GetObject("ibtnShowSupplier.Image"), System.Drawing.Image)
      Me.ibtnShowSupplier.Location = New System.Drawing.Point(344, 16)
      Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
      Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplier.TabIndex = 8
      Me.ibtnShowSupplier.TabStop = False
      Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(152, 16)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(168, 20)
      Me.txtSupplierName.TabIndex = 4
      Me.txtSupplierName.TabStop = False
      '
      'ibtnShowSupplierDialog
      '
      Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSupplierDialog.Image = CType(resources.GetObject("ibtnShowSupplierDialog.Image"), System.Drawing.Image)
      Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(320, 16)
      Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
      Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplierDialog.TabIndex = 7
      Me.ibtnShowSupplierDialog.TabStop = False
      Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(240, 15)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
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
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(184, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 6
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(240, 15)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 8
      Me.dtpDocDate.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(3, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(62, 18)
      Me.lblCode.TabIndex = 5
      Me.lblCode.Text = "เลขที่:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(200, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 7
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSupplier
      '
      Me.grbSupplier.Controls.Add(Me.ibtnShowSupplier)
      Me.grbSupplier.Controls.Add(Me.txtSupplierName)
      Me.grbSupplier.Controls.Add(Me.txtSupplierCode)
      Me.grbSupplier.Controls.Add(Me.ibtnShowSupplierDialog)
      Me.grbSupplier.Controls.Add(Me.lblSupplier)
      Me.grbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSupplier.Location = New System.Drawing.Point(376, 0)
      Me.grbSupplier.Name = "grbSupplier"
      Me.grbSupplier.Size = New System.Drawing.Size(384, 48)
      Me.grbSupplier.TabIndex = 2
      Me.grbSupplier.TabStop = False
      Me.grbSupplier.Text = "ผู้ขาย"
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(120, 56)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 10
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(144, 56)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 11
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 80)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(784, 280)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 15
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnUpDateVat
      '
      Me.ibtnUpDateVat.Image = CType(resources.GetObject("ibtnUpDateVat.Image"), System.Drawing.Image)
      Me.ibtnUpDateVat.Location = New System.Drawing.Point(200, 56)
      Me.ibtnUpDateVat.Name = "ibtnUpDateVat"
      Me.ibtnUpDateVat.Size = New System.Drawing.Size(24, 24)
      Me.ibtnUpDateVat.TabIndex = 11
      Me.ibtnUpDateVat.TabStop = False
      Me.ibtnUpDateVat.ThemedImage = CType(resources.GetObject("ibtnUpDateVat.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnUpDateVat, "Update Vat")
      Me.ibtnUpDateVat.Visible = False
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(63, 15)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 214
      '
      'APVatInputDetail
      '
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbSupplier)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.ibtnUpDateVat)
      Me.Name = "APVatInputDetail"
      Me.Size = New System.Drawing.Size(808, 376)
      Me.grbSupplier.ResumeLayout(False)
      Me.grbSupplier.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As APVatInput
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      Dim dt As TreeTable = APVatInput.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbSupplier.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "APVatInput"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "paysi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "paysi_linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("paysi_entityType", CodeDescription.GetCodeList("PayableItemType", "code_value not in (47,46,199,60)"), "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty
      csType.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"
      csCode.ReadOnly = True

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf ItemButtonClick

      Dim csDocDate As New DataGridTimePickerColumn
      csDocDate.MappingName = "DocDate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      csDocDate.ReadOnly = True

      Dim csDueDate As New DataGridTimePickerColumn
      csDueDate.MappingName = "DueDate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.RemainHeaderText}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Left
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Width = 100
      csAmount.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "paysi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "paysi_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csDocDate)
      dst.GridColumnStyles.Add(csDueDate)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As BillAcceptanceItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is BillAcceptanceItem Then
          Return Nothing
        End If
        Return CType(row.Tag, BillAcceptanceItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If ValidateRow(CType(e.Row, TreeRow)) Then
        UpdateAmount()
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If Me.CurrentItem Is Nothing Then
        Dim doc As New BillAcceptanceItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "paysi_entitytype"
            SetEntityType(e)
          Case "duedate"
            SetDueDate(e)
          Case "docdate"
            SetDate(e)
          Case "amount"
            SetAmount(e)
          Case "paysi_note"
            SetNote(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim paysi_entitytype As Object = e.Row("paysi_entitytype")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "paysi_entitytype"
          paysi_entitytype = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(paysi_entitytype) Then
        isBlankRow = True
      End If
      If Not isBlankRow Then
        Select Case CInt(paysi_entitytype)
          Case 45 'รับของ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsReceiptCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 46 'ลดหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.PurchaseCNCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 47 'เพิ่มหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 15 'เจ้าหนี้ยกมา
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.APOpeningBalanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 50 'ซ่อมบำรุง
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.EqMaintenanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.Tag Is Nothing Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      m_updating = True
      Dim amt As Decimal = 0
      Dim unpad As Decimal = 0

      If IsNumeric(e.ProposedValue) Then
        If CDec(e.ProposedValue) <> 0 Then
          amt = CDec(e.ProposedValue)
        End If
      End If
      If doc.UnpaidAmount < amt Then

        Return
      End If

      doc.Amount = amt
      m_updating = False
    End Sub
    Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      m_updating = True
      doc.Note = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDueDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull(e.Column) Then
        m_updating = False
        Return
      End If

      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        'ผ่านโลด
        m_updating = False
        Return
      End If
      If msgServ.AskQuestion("${res:Global.Question.ChangeAPVatInputEntityType}") Then
        e.Row("paysi_entity") = DBNull.Value
        e.Row("code") = DBNull.Value
        e.Row("RealAmount") = DBNull.Value
        e.Row("paysi_amt") = DBNull.Value
        e.Row("UnpaidAmount") = DBNull.Value
        e.Row("DueDate") = Date.MinValue
        e.Row("DocDate") = Date.MinValue
        doc.Clear()
      Else
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("paysi_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
        If Not doc Is item Then
          If item.EntityId = CInt(e.Row("paysi_entityType")) Then
            If e.ProposedValue.ToString.ToLower = item.Code.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("paysi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoAPVatInputEntityType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {BusinessLogic.Entity.GetFullClassName(doc.EntityId), e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("paysi_entityType"))
        Case 45 'รับของ
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsReceiptDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim gr As New GoodsReceipt(e.ProposedValue.ToString)
          If Not gr.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If gr.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.GoodsReceiptIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            doc.Id = gr.Id
            doc.Code = gr.Code
            doc.Date = gr.DocDate
            doc.CreditPeriod = gr.CreditPeriod
            doc.SetType(45)
          End If
        Case 50 'ซ่อมบำรุง
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteEqMaintenanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim eqm As New EqMaintenance(e.ProposedValue.ToString)
          If Not eqm.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoEqMaintenance}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If eqm.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.EqMaintenanceIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            doc.Id = eqm.Id
            doc.Code = eqm.Code
            doc.Date = eqm.DocDate
            doc.CreditPeriod = eqm.CreditPeriod
            doc.SetType(50)
          End If
        Case 46 'ลดหนี้
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeletePurchaseCNDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim pcn As New PurchaseCN(e.ProposedValue.ToString)
          If Not pcn.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseCN}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If pcn.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseCNIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            doc.Id = pcn.Id
            doc.Code = pcn.Code
            doc.Date = pcn.DocDate
            doc.CreditPeriod = pcn.CreditPeriod
            doc.SetType(46)
          End If
        Case 47 'เพิ่มหนี้
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteBillAcceptanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim pdn As New PurchaseDN(e.ProposedValue.ToString)
          If Not pdn.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseDN}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If pdn.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseDNIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            doc.Id = pdn.Id
            doc.Code = pdn.Code
            doc.Date = pdn.DocDate
            doc.CreditPeriod = pdn.CreditPeriod
            doc.SetType(46)
          End If
        Case 15 'เจ้าหนี้ยกมา
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAPOpeningBalanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim apo As New APOpeningBalance(e.ProposedValue.ToString)
          If Not apo.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAPOpeningBalance}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If apo.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.APOpeningBalanceIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            doc.Id = apo.Id
            doc.Code = apo.Code
            doc.Date = apo.DocDate
            doc.CreditPeriod = apo.CreditPeriod
            doc.SetType(46)
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoAPVatInputEntityType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 Or Me.m_entity.Status.Value >= 3 Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In grbSupplier.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.txtDocDateAlert}"))

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.txtCodeAlert}"))

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblItem}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.grbSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.grbSupplier}")

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblSupplier}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.txtSupplierCodeAlert}"))
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
    End Sub
    Private supplierCodeChanged As Boolean = False
    Private txtCreditPeriodChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtsuppliercode"
          supplierCodeChanged = True
        Case "txtcreditperiod"
          txtCreditPeriodChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldSupId = Me.m_entity.Supplier.Id
      txtNote.Text = m_entity.Note
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      RefreshDocs()

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub ibtnUpDateVat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnUpDateVat.Click
      UpdateVat()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub UpdateVat()
      Me.m_entity.GenVatItems()
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.PopulateAPVatInputItem(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Private oldSupId As Integer
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
              Me.m_entity.OnGlChanged()
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsuppliercode"
          If supplierCodeChanged Then
            supplierCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.txtSupplierCode.TextLength <> 0 Then
              Dim oldSupplier As Supplier = Me.m_entity.Supplier
              Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
              Try
                If oldSupId <> Me.m_entity.Supplier.Id Then
                  If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Caption.ChangeSupplier}") Then
                    oldSupId = Me.m_entity.Supplier.Id
                    dirtyFlag = True
                    ChangeSupplier()
                  Else
                    dirtyFlag = False
                    Me.m_entity.Supplier = oldSupplier
                    Me.txtSupplierCode.Text = oldSupplier.Code
                    Me.txtSupplierName.Text = oldSupplier.Name
                    supplierCodeChanged = False
                  End If
                End If
              Catch ex As Exception

              End Try
            End If
          End If
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub ChangeSupplier()
      oldSupId = Me.m_entity.Supplier.Id
      Me.m_entity.ItemCollection.Clear()
      RefreshDocs()
      UpdateAmount()
      supplierCodeChanged = False
      Me.m_entity.CreditPeriod = Me.m_entity.Supplier.CreditPeriod
      txtCreditPeriodChanged = False
    End Sub
    Private Sub UpdateAmount()
      m_isInitialized = False
      m_isInitialized = True
    End Sub
    Public Sub SetStatus()
      If m_entity.Canceled Then
        Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name)
      ElseIf m_entity.Edited Then
        Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name)
      ElseIf m_entity.Originated Then
        Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name)
      Else
        Me.StatusBarService.SetMessage("")
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, APVatInput)
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub


#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filterEntities(3) As ArrayList
      For i As Integer = 0 To 3
        filterEntities(i) = New ArrayList
        filterEntities(i).Add(Me.m_entity.Supplier)
      Next
      Dim filters(3)() As Filter
      'Dim grNeedsApproval As Boolean = False
      'grNeedsApproval = CBool(Configuration.GetConfig("ApproveDO"))
      filters(0) = New Filter() {New Filter("IDList", GetItemIDList(45))} _
      ', New Filter("grNeedsApproval", grNeedsApproval)}

      filters(1) = New Filter() {New Filter("IDList", GetItemIDList(15))}

      'filters(2) = New Filter() {New Filter("ExcludeIdList", GetBAExcludeList), _
      'New Filter("grNeedsApproval", grNeedsApproval), _
      'New Filter("Id", Me.m_entity.Id)} 'Hack: filter อันสุดท้ายไม่เอาไป Query

      filters(2) = New Filter() {New Filter("IDList", GetItemIDList(50))}

      filters(3) = New Filter() {New Filter("IDList", GetItemIDList(59))}

      'filters(4) = New Filter() {New Filter("IDList", GetItemIDList(46)), _
      'New Filter("pays_id", Me.m_entity.Id)}

      'filters(5) = New Filter() {New Filter("IDList", GetItemIDList(199)), _
      'New Filter("nocancel", True) _
      ', New Filter("grNeedsApproval", grNeedsApproval)}

      'filters(5) = New Filter() {New Filter("IDList", GetItemIDList(47))}

      Dim entities(3) As ISimpleEntity
      'entities(0) = New GoodsReceipt
      'entities(1) = New APOpeningBalance
      'entities(2) = New EqMaintenance
      'entities(3) = New AdvancePay
      entities(0) = New GoodsReceiptForVat
      entities(1) = New APOpeningBalanceForVat
      entities(2) = New EqMaintenanceForVat
      entities(3) = New AdvancePayForVat
      myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities, 0)
    End Sub
    Private Function GetItemIDList(ByVal type As Integer) As String
      Dim ret As String = ""
      For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
        If item.Originated AndAlso item.EntityId = type AndAlso item.ParentType = 0 Then
          ret &= item.Id.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, ret.Length - 1)
      End If
      Return ret
    End Function
    Private Function GetBAExcludeList() As String
      Dim ret As String = ""
      For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
        If item.ParentId <> 0 Then
          ret &= "|" & item.ParentId.ToString & ":" & item.Linenumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If items.Count = 0 Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim insertIndex As Integer
      Dim newItem As BillAcceptanceItem
      For i As Integer = items.Count - 1 To 0 Step -1
        If TypeOf items(i) Is StockBasketItem Then
          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.billacceptanceitem"
              newItem = CType(item.Tag, BillAcceptanceItem)
              'Case "Longkong.Pojjaman.BusinessLogic.GoodsReceipt"
              '    If Not IsDBNull(item.Tag) Then
              '        newItem = New BillAcceptanceItem(New GoodsReceipt(CInt(item.Tag)), Me.m_entity)
              '    End If
              'Case "Longkong.Pojjaman.BusinessLogic.PurchaseCN"
              '    If Not IsDBNull(item.Tag) Then
              '        newItem = New BillAcceptanceItem(New PurchaseCN(CInt(item.Tag)), Me.m_entity)
              '    End If
              'Case "Longkong.Pojjaman.BusinessLogic.PurchaseDN"
              '    If Not IsDBNull(item.Tag) Then
              '        newItem = New BillAcceptanceItem(New PurchaseDN(CInt(item.Tag)), Me.m_entity)
              '    End If
              'Case "Longkong.Pojjaman.BusinessLogic.APOpeningBalance"
              '    If Not IsDBNull(item.Tag) Then
              '        newItem = New BillAcceptanceItem(New APOpeningBalance(CInt(item.Tag)), Me.m_entity)
              '    End If
          End Select
        Else
          Dim item As BasketItem = CType(items(i), BasketItem)
          If TypeOf item.Tag Is DataRow Then
            If item.FullClassName.ToLower = "longkong.pojjaman.businesslogic.advancepayforvat" Then
              'เฉพาะสำหรับเอามัดจำจ่ายมากรอกใบกำกับภาษีซื้อ
              newItem = New BillAcceptanceItem(New AdvancePay(CType(item.Tag, DataRow), ""), Me.m_entity)
            Else
              newItem = New BillAcceptanceItem(CType(item.Tag, DataRow), "", Me.m_entity)
            End If
          Else
            Select Case item.FullClassName.ToLower
              Case "longkong.pojjaman.businesslogic.goodsreceipt"
                newItem = New BillAcceptanceItem(New GoodsReceipt(item.Id), Me.m_entity)
              Case "longkong.pojjaman.businesslogic.purchasecn"
                newItem = New BillAcceptanceItem(New PurchaseCN(item.Id), Me.m_entity)
              Case "longkong.pojjaman.businesslogic.purchasedn"
                newItem = New BillAcceptanceItem(New PurchaseDN(item.Id), Me.m_entity)
              Case "longkong.pojjaman.businesslogic.apopeningbalance"
                newItem = New BillAcceptanceItem(New APOpeningBalance(item.Id), Me.m_entity)
              Case "longkong.pojjaman.businesslogic.eqmaintenance"
                newItem = New BillAcceptanceItem(New EqMaintenance(item.Id), Me.m_entity)
            End Select
          End If
        End If
        If Not newItem Is Nothing Then
          newItem.Amount = Math.Min(newItem.UnpaidAmount, newItem.BilledAmount)
          If i = items.Count - 1 Then
            'ตัวแรก -- update old item
            If Me.m_entity.ItemCollection.Count = 0 Then
              Me.m_entity.ItemCollection.Add(newItem)
            Else
              Dim theDoc As BillAcceptanceItem = Me.CurrentItem
              If theDoc Is Nothing Then
                If index > Me.m_entity.ItemCollection.Count - 1 Then
                  Me.m_entity.ItemCollection.Add(newItem)
                  theDoc = newItem
                  insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
                Else
                  Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                  theDoc = Me.m_entity.ItemCollection(insertIndex)
                End If
              End If
              theDoc.Id = newItem.Id
              theDoc.Code = newItem.Code
              theDoc.AfterTax = newItem.AfterTax
              theDoc.RealAmount = newItem.BilledAmount
              theDoc.Amount = newItem.Amount
              theDoc.UnpaidAmount = newItem.UnpaidAmount
              theDoc.SetType(newItem.EntityId)
              theDoc.CreditPeriod = newItem.CreditPeriod
              theDoc.Date = newItem.Date

              'bai.UnpaidAmount = APVatInput.GetRemainingVatAmount(bai.Id, bai.EntityId)
              'bai.Amount = bai.UnpaidAmount
              'theDoc.Amount = APVatInput.GetRemainingVatAmount(newItem.Id, newItem.EntityId)
          
            End If
          Else
            Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
          End If
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      UpdateAmount()
      UpdateVat()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_entity.ItemCollection.Insert(index, New BillAcceptanceItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
  , Me.m_treeManager.Treetable.Columns("paysi_amt") _
  , Me.CurrentItem.Amount)
      Me.ValidateRow(re)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("paysi_linenumber") = i + 1
        i += 1
      Next
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '    If Not successful Then
    '        Return
    '    End If
    '    Me.Entity = New PR(Me.Entity.Id)
    '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
    '    listPanel.SelectedEntity = Me.Entity
    'End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PR).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.ChangeProperty(txtSupplierCode, Nothing)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercode", "txtsuppliername"
              Me.SetSupplier(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.BlankParentText}")
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '        parRow.Childs.Add()
      '    End If
      'End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class

 End Namespace