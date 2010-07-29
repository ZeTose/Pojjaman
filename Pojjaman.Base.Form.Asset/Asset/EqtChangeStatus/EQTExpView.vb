Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class EQTExpView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtStorePersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgToCC As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAddStockitem As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnDelStockitem As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EQTExpView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.ibtnAddStockitem = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelStockitem = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgToCC = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtRefDocCode = New System.Windows.Forms.TextBox()
      Me.lblRefDoc = New System.Windows.Forms.Label()
      Me.txtStorePersonName = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.lblEmployee = New System.Windows.Forms.Label()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbRefDoc.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.ibtnAddStockitem)
      Me.grbDetail.Controls.Add(Me.ibtnDelStockitem)
      Me.grbDetail.Controls.Add(Me.tgToCC)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grbDetail.Location = New System.Drawing.Point(7, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(728, 520)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ลงรายการค่าใช้จ่าย"
      '
      'lblGross
      '
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(595, 66)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(104, 18)
      Me.lblGross.TabIndex = 32
      Me.lblGross.Text = "มูลค่าค่าใช้จ่ายรวม:"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtGross
      '
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(598, 87)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(122, 21)
      Me.txtGross.TabIndex = 32
      Me.txtGross.TabStop = False
      '
      'ibtnAddStockitem
      '
      Me.ibtnAddStockitem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnAddStockitem.Location = New System.Drawing.Point(144, 110)
      Me.ibtnAddStockitem.Name = "ibtnAddStockitem"
      Me.ibtnAddStockitem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddStockitem.TabIndex = 30
      Me.ibtnAddStockitem.TabStop = False
      Me.ibtnAddStockitem.ThemedImage = CType(resources.GetObject("ibtnAddStockitem.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelStockitem
      '
      Me.ibtnDelStockitem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelStockitem.Location = New System.Drawing.Point(168, 110)
      Me.ibtnDelStockitem.Name = "ibtnDelStockitem"
      Me.ibtnDelStockitem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelStockitem.TabIndex = 31
      Me.ibtnDelStockitem.TabStop = False
      Me.ibtnDelStockitem.ThemedImage = CType(resources.GetObject("ibtnDelStockitem.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgToCC
      '
      Me.tgToCC.AllowNew = False
      Me.tgToCC.AllowSorting = False
      Me.tgToCC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgToCC.AutoColumnResize = True
      Me.tgToCC.CaptionVisible = False
      Me.tgToCC.Cellchanged = False
      Me.tgToCC.DataMember = ""
      Me.tgToCC.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgToCC.Location = New System.Drawing.Point(10, 136)
      Me.tgToCC.Name = "tgToCC"
      Me.tgToCC.Size = New System.Drawing.Size(710, 376)
      Me.tgToCC.SortingArrowColor = System.Drawing.Color.Red
      Me.tgToCC.TabIndex = 28
      Me.tgToCC.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(7, 114)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(110, 16)
      Me.lblItem.TabIndex = 29
      Me.lblItem.Text = "รายการค่าใช้จ่าย"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
      Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
      Me.grbRefDoc.Controls.Add(Me.txtStorePersonName)
      Me.grbRefDoc.Controls.Add(Me.txtCostCenterName)
      Me.grbRefDoc.Controls.Add(Me.lblEmployee)
      Me.grbRefDoc.Controls.Add(Me.lblCostCenter)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(10, 12)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(512, 96)
      Me.grbRefDoc.TabIndex = 0
      Me.grbRefDoc.TabStop = False
      Me.grbRefDoc.Text = "ข้อมูลเอกสาร"
      '
      'txtRefDocCode
      '
      Me.txtRefDocCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.txtRefDocCode.Location = New System.Drawing.Point(134, 16)
      Me.Validator.SetMinValue(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Name = "txtRefDocCode"
      Me.txtRefDocCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
      Me.Validator.SetRequired(Me.txtRefDocCode, False)
      Me.txtRefDocCode.Size = New System.Drawing.Size(184, 21)
      Me.txtRefDocCode.TabIndex = 1
      Me.txtRefDocCode.TabStop = False
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.Location = New System.Drawing.Point(24, 16)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
      Me.lblRefDoc.TabIndex = 0
      Me.lblRefDoc.Text = "เลขที่เอกสาร:"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtStorePersonName
      '
      Me.txtStorePersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtStorePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.txtStorePersonName.Location = New System.Drawing.Point(134, 40)
      Me.Validator.SetMinValue(Me.txtStorePersonName, "")
      Me.txtStorePersonName.Name = "txtStorePersonName"
      Me.txtStorePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStorePersonName, "")
      Me.Validator.SetRequired(Me.txtStorePersonName, False)
      Me.txtStorePersonName.Size = New System.Drawing.Size(368, 21)
      Me.txtStorePersonName.TabIndex = 30
      Me.txtStorePersonName.TabStop = False
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(134, 64)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(368, 21)
      Me.txtCostCenterName.TabIndex = 31
      Me.txtCostCenterName.TabStop = False
      '
      'lblEmployee
      '
      Me.lblEmployee.BackColor = System.Drawing.Color.Transparent
      Me.lblEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmployee.Location = New System.Drawing.Point(40, 40)
      Me.lblEmployee.Name = "lblEmployee"
      Me.lblEmployee.Size = New System.Drawing.Size(88, 18)
      Me.lblEmployee.TabIndex = 28
      Me.lblEmployee.Text = "ผู้บันทึก:"
      Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(40, 64)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblCostCenter.TabIndex = 29
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'EQTExpView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "EQTExpView"
      Me.Size = New System.Drawing.Size(744, 528)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbRefDoc.ResumeLayout(False)
      Me.grbRefDoc.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_expTreeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
    Private m_combocodeindex As Integer
    Private m_refDoc As EquipmentToolChangeStatus

    Public StockItemlist As List(Of StockItem)
    Public MatActualHash As Hashtable
    Public LabActualHash As Hashtable
    Public EQActualHash As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dtExp As TreeTable = EquipmentToolChangeStatus.GetSchemaExpTable
      Dim dstExp As DataGridTableStyle = Me.CreateTableStyle()
      m_expTreeManager = New TreeManager(dtExp, tgToCC)
      m_expTreeManager.SetTableStyle(dstExp)
      m_expTreeManager.AllowSorting = False
      m_expTreeManager.AllowDelete = False

      AddHandler dtExp.ColumnChanging, AddressOf ExpTreetable_ColumnChanging
      AddHandler dtExp.ColumnChanged, AddressOf ExpTreetable_ColumnChanged
      AddHandler dtExp.RowDeleted, AddressOf WBSItemDelete

      EventWiring()

      StockItemlist = New List(Of StockItem)
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"       'add แค่ header เท่านั้น

    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EqtExpItem"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csType As New TreeTextColumn
      csType.MappingName = "TypeName"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EQTExpView.ItemTypeHeaderText}") '"ประเภท"
      csType.NullText = ""
      csType.Width = 80
      csType.ReadOnly = True
      csType.TextBox.Name = "TypeName"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.CodeHeaderText}") '"รายการ/Cost Center"
      csCode.NullText = ""
      csCode.Width = 100
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"



      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.DescriptionHeaderText}") '"รายการ/Cost Center"
      csDescription.NullText = ""
      csDescription.Width = 175
      csDescription.ReadOnly = True
      csDescription.TextBox.Name = "Description"



      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:StockQty}") 'CBS
      csStockQty.NullText = ""
      csStockQty.Width = 50
      csStockQty.Format = "#,###.##"
      'csStockQty.ReadOnly = True
      csStockQty.TextBox.Name = "StockQty"



      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Unit}") 'WBS
      csUnit.NullText = ""
      csUnit.Width = 175
      csUnit.ReadOnly = True
      csUnit.TextBox.Name = "Unit"



      Dim csUnitCost As New TreeTextColumn
      csUnitCost.MappingName = "UnitCost"
      csUnitCost.HeaderText = myStringParserService.Parse("${res:UnitCost}") '
      csUnitCost.NullText = ""
      csUnitCost.DataAlignment = HorizontalAlignment.Right
      csUnitCost.Format = "#,###.##"
      csUnitCost.ReadOnly = True
      csUnitCost.Width = 50
      csUnitCost.TextBox.Name = "UnitCost"

      Dim csAmount As New TreeTextColumn(10, True)
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.ACAmountHeaderText}") 'จำนวนเงิน/มูลค่าจัดสรร
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.Width = 100
      csAmount.TextBox.Name = "Amount"
      AddHandler csAmount.CheckCellHilighted, AddressOf SetHilightValues

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.NoteHeaderText}") '"รายการ/Cost Center"
      csNote.NullText = ""
      csNote.Width = 175
      csNote.ReadOnly = True
      csNote.TextBox.Name = "Note"

      Dim csBudgetRemain As New TreeTextColumn(11, True)
      csBudgetRemain.MappingName = "BudgetRemain"
      csBudgetRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.BudgetRemainHeaderText}") 'งบประมาณคงเหลือ
      csBudgetRemain.NullText = ""
      csBudgetRemain.Alignment = HorizontalAlignment.Right
      csBudgetRemain.DataAlignment = HorizontalAlignment.Right
      csBudgetRemain.Format = "#,###.##"
      csBudgetRemain.Width = 100
      csBudgetRemain.TextBox.Name = "BudgetRemain"
      csBudgetRemain.ReadOnly = True
      AddHandler csBudgetRemain.CheckCellHilighted, AddressOf SetHilightValues

      Dim csQtyRemain As New TreeTextColumn(12, True)
      csQtyRemain.MappingName = "QtyRemain"
      csQtyRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.QtyRemainHeaderText}") 'ปริมาณคงเหลือ
      csQtyRemain.NullText = ""
      csQtyRemain.Alignment = HorizontalAlignment.Right
      csQtyRemain.DataAlignment = HorizontalAlignment.Right
      csQtyRemain.Format = "#,###.##"
      csQtyRemain.Width = 100
      csQtyRemain.TextBox.Name = "QtyRemain"
      csQtyRemain.ReadOnly = True
      AddHandler csQtyRemain.CheckCellHilighted, AddressOf SetHilightValues
      '------------------------WBS----------------------------------

      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csStockQty)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitCost)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)
      'dst.GridColumnStyles.Add(csBudgetRemain)
      'dst.GridColumnStyles.Add(csQtyRemain)

      Return dst
    End Function
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      e.RedText = False
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_expTreeManager.Treetable.Rows
        For Each col As DataColumn In Me.m_expTreeManager.Treetable.Columns
          If col.Ordinal > 0 Then
            If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
              If CDec(row(col)) < 0 Then
                If e.Column = col.Ordinal And e.Row = i Then
                  'e.HilightValue = True
                  e.RedText = True
                End If
              End If
            End If
          End If
        Next
        i += 1
      Next
    End Sub
#End Region

#Region "Properties"
    'Public ReadOnly Property RefDocAllocationType As AllocationType
    '  Get
    '    If Me.m_refDoc Is Nothing Then
    '      Return AllocationType.Non
    '    End If
    '    If m_refDoc.AllowWBSAllocateFrom And Not m_refDoc.AllowWBSAllocateTo Then
    '      Return AllocationType.AllocationFromOnly
    '    ElseIf Not m_refDoc.AllowWBSAllocateFrom And m_refDoc.AllowWBSAllocateTo Then
    '      Return AllocationType.AllocationToOnly
    '    ElseIf m_refDoc.AllowWBSAllocateFrom And m_refDoc.AllowWBSAllocateTo Then
    '      Return AllocationType.AllocationFromAndTo
    '    Else
    '      Return AllocationType.Non
    '    End If
    '  End Get
    'End Property
    Public ReadOnly Property RefDoc() As EquipmentToolChangeStatus
      Get
        Return m_refDoc
      End Get
    End Property
    Private ReadOnly Property CurrentWsbsd() As StockItem
      Get
        Dim row As TreeRow = Me.m_expTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is StockItem Then
          Return Nothing
        End If
        Return CType(row.Tag, StockItem)
      End Get
    End Property
    Private ReadOnly Property CurrentItem() As EquipmentToolChangeStatusItem
      Get
        Dim row As TreeRow = Me.m_expTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is EquipmentToolChangeStatusItem Then
          Return Nothing
        End If
        Return CType(row.Tag, EquipmentToolChangeStatusItem)
      End Get
    End Property
    Private ReadOnly Property CurrentParItem() As EqtItem  ' WBSDistributeCollection
      Get
        Dim row As TreeRow = Me.m_expTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        'If Not TypeOf m_entity Is IEqtItem Then
        '  Return Nothing
        'End If
        If Not TypeOf row.Tag Is StockItem Then
          Return Nothing
        End If
        Dim eqt As EqtItem
        eqt = CType(row.Tag, StockItem).RefEqtItem
        'Dim wbsd As WBSDistribute = CType(row.Tag, WBSDistribute)
        'For Each itm As IWBSAllocatableItem In CType(m_entity, IWBSAllocatable).GetWBSAllocatableItemCollection
        '  If itm.WBSDistributeCollection.Contains(wbsd) Then
        '    Return itm 'itm.WBSDistributeCollection
        '  End If
        '  'For Each wbsitem As WBSDistribute In itm.WBSDistributeCollection
        '  '    If wbsd Is wbsitem Then
        '  '        Exit For
        '  '    End If
        '  'Next
        'Next
        Return eqt
      End Get
    End Property

    Dim m_wbsColl As WBSCollection = Nothing
    Dim m_mrkColl As MarkupCollection = Nothing



#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()

    End Sub

    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      'คาดว่าจะเป็นตรงนี้
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblBankCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblBankCharge}")
      'Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblWHT}")
      'Me.lblOtherExpense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherExpense}")
      'Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblNote}")
      'Me.txtDiscountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtWHTUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtBankChargeUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtOtherExpenseUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.grbDetail}")
      Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.grbRefDoc}")
      'Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefDocDate}")
      Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.lblRefDoc}")
      Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.lblSupplier}")
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.lblCostCenter}")

      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCode}")
      'Me.Validator.SetDisplayName(Me.cmbCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      'Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDocDate}")
      'Me.lblRefAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefAmount}")
      'Me.lblRefAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.grbDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbDebit}")
      'Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDiscountAmount}")
      'Me.lblOtherRev.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherRev}")
      'Me.txtOtherRevUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblDebitAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDebitAmount}")
      'Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblAmount}")
      'Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblGross}")
      'Me.grbCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbCredit}")
      'Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblInterest}")
      'Me.txtInterestUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCreditAmount}")
      'Me.txtGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtDiscountAmount.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtOtherRevenue.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtInterest.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtBankCharge.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtOtherExpense.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      If TypeOf Me.m_entity Is EquipmentToolChangeStatus Then
        m_refDoc = CType(Me.m_entity, EquipmentToolChangeStatus)

        Me.txtRefDocCode.Text = Me.m_entity.Code
        If Not RefDoc.Storeperson Is Nothing Then
          Me.txtStorePersonName.Text = RefDoc.Storeperson.Code & " : " & RefDoc.Storeperson.Name
        End If
        If Not RefDoc.StoreCostcenter Is Nothing Then
          Me.txtCostCenterName.Text = RefDoc.StoreCostcenter.Code & " : " & RefDoc.StoreCostcenter.Name
        End If


      End If

      RefreshDocs()

      UpdateAmount()
      UpdateRefDoc()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Function ItemCBS(ByVal ali As IWBSAllocatableItem) As String
      Dim myCBS As CBS = Nothing

      Dim isSingleCBS As Boolean = False
      For Each wbsditem As WBSDistribute In ali.WBSDistributeCollection
        If myCBS Is Nothing Then
          myCBS = wbsditem.CBS
          isSingleCBS = True
        End If
        If myCBS.Id <> wbsditem.CBS.Id Then
          isSingleCBS = False
        End If
      Next

      If isSingleCBS Then
        Return myCBS.Code & ":" & myCBS.Name
      End If

      Return ""

    End Function
    Private Sub RefreshDocs()
      Dim flag As Boolean = Me.m_isInitialized
      Dim hashWBS As New Hashtable
      Dim hashWBSItem As New Hashtable
      Dim key As String = ""
      Dim itemKey As String = ""
      Dim transferAmt As Decimal = 0

      Me.m_isInitialized = False
      If TypeOf m_entity Is EquipmentToolChangeStatus Then
        Dim al As EquipmentToolChangeStatus = CType(m_entity, EquipmentToolChangeStatus)
        Dim dt As TreeTable = m_expTreeManager.Treetable
        dt.Clear()
        Dim newRow As TreeRow = Nothing
        Dim currRow As TreeRow = Nothing
        For Each ali As EquipmentToolChangeStatusItem In al.ItemCollection
          If Not currRow Is Nothing Then
            newRow = currRow.Childs.Add
          Else
            newRow = dt.Childs.Add
          End If
          newRow.FixLevel = 1
          currRow = newRow
          newRow.State = RowExpandState.Expanded
          newRow("TypeName") = ali.ItemType.ToString
          newRow("Code") = ali.Entity.Code
          newRow("Description") = ali.Name

          'If Me.RefDocAllocationType = AllocationType.AllocationFromOnly Then
          '  transferAmt = ali.ItemAmount * (-1)
          'ElseIf Me.RefDocAllocationType = AllocationType.AllocationToOnly Then
          '  transferAmt = ali.ItemAmount * (1)
          'ElseIf Me.RefDocAllocationType = AllocationType.AllocationFromAndTo Then

          'End If



          'newRow("Button") = "invisible"

          newRow.Tag = ali
          If ali.ExpItemCollection IsNot Nothing Then
            For Each st As StockItem In ali.ExpItemCollection.GetStockCollection 'เอามาเฉพาะที่ ที่stock ต่างกัน
              'transferAmt = ali.ItemAmount

              'wbsd.BaseCost = transferAmt
              'wbsd.TransferBaseCost = transferAmt

              'Dim wbsRow As TreeRow = dt.Childs.Add()
              Dim StockRow As TreeRow = currRow.Childs.Add
              StockRow.FixLevel = -1

              StockRow.State = RowExpandState.Expanded
              StockRow("ItemType") = st.Type.Value
              StockRow("TypeName") = st.Type.Description
              StockRow("Code") = st.Stock.Code
              For Each si As StockItem In ali.ExpItemCollection.GetCollectionForStock(st.Stock)
                Dim stockitemRow As TreeRow = StockRow.Childs.Add
                stockitemRow.FixLevel = -2
                stockitemRow.State = RowExpandState.Expanded
                stockitemRow("ItemType") = si.ItemType.Value
                stockitemRow("TypeName") = si.ItemType.Description
                stockitemRow("Code") = si.Entity.Code
                stockitemRow("Description") = si.Itemname
                stockitemRow("UnitName") = si.DefaultUnit.Name
                stockitemRow("stockQty") = si.Stockqty
                stockitemRow("UnitCost") = si.UnitCost
                stockitemRow("Amount") = si.Amount
                stockitemRow.Tag = si
              Next



              'StockRow("BudgetRemain") = Configuration.FormatToString(wbsd.RemainSummary, DigitConfig.Price)
              'StockRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemainSummary, DigitConfig.Price)
              'wbsRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Qty)

              StockRow.Tag = st
            Next
          End If
          newRow("Amount") = Configuration.FormatToString(ali.Amount, DigitConfig.Price)

        Next
      End If
      RefreshBlankGrid()
      Me.UpdateAmount()
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateRefDoc()

    End Sub
    Private Sub UpdateAmount()
      For Each eci As EquipmentToolChangeStatusItem In RefDoc.ItemCollection
        Dim amount As Decimal = 0
        If eci.ExpItemCollection IsNot Nothing Then
          For Each si As StockItem In eci.ExpItemCollection
            amount += si.Amount
          Next
          eci.Amount = amount
        End If
      Next
      Me.txtGross.Text = Configuration.FormatToString(m_refDoc.Gross, DigitConfig.Price)
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    'Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
    '  myWbs = New WBS(myWbs.Id)
    '  Dim o_n As OldNew
    '  Dim theHash As Hashtable
    '  Select Case type
    '    Case 0, 19, 42
    '      theHash = MatActualHash
    '    Case 88
    '      theHash = LabActualHash
    '    Case 89
    '      theHash = EQActualHash
    '  End Select
    '  If Not theHash Is Nothing Then
    '    If theHash.Contains(myWbs.Id) Then
    '      o_n = CType(theHash(myWbs.Id), OldNew)
    '    Else
    '      o_n = New OldNew
    '      Select Case type
    '        Case 0, 19, 42
    '          o_n.OldValue = myWbs.GetActualMat(Me, 7)
    '        Case 88
    '          o_n.OldValue = myWbs.GetActualLab(Me, 7)
    '        Case 89
    '          o_n.OldValue = myWbs.GetActualEq(Me, 7)
    '      End Select
    '      o_n.NewValue = o_n.OldValue
    '      theHash(myWbs.Id) = o_n
    '    End If
    '    o_n.NewValue += (newVal - oldVal)

    '    'ส่งต่อไปยังแม่
    '    If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
    '      SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
    '    End If
    '  End If
    'End Sub
    'Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
    '    If Me.m_payment Is Nothing Or Not m_isInitialized Then
    '        Return
    '    End If
    '    Dim dirtyFlag As Boolean = False
    '    Select Case CType(sender, Control).Name.ToLower
    '        Case "cmbcode"
    '            Me.m_payment.Code = cmbCode.Text
    '            ComboCodeIndex = cmbCode.SelectedIndex
    '            m_oldCode = Me.cmbCode.Text
    '            dirtyFlag = True
    '        Case "txtnote"
    '            Me.m_payment.Note = txtNote.Text
    '            dirtyFlag = True
    '        Case "dtpdocdate"
    '            If Not Me.m_payment.DocDate.Equals(dtpDocDate.Value) Then
    '                If Not m_dateSetting Then
    '                    Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
    '                    Me.m_payment.DocDate = dtpDocDate.Value
    '                End If
    '                dirtyFlag = True
    '            End If
    '        Case "txtdocdate"
    '            m_dateSetting = True
    '            If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
    '                Dim theDate As Date = CDate(Me.txtDocDate.Text)
    '                If Not Me.m_payment.DocDate.Equals(theDate) Then
    '                    dtpDocDate.Value = theDate
    '                    Me.m_payment.DocDate = dtpDocDate.Value
    '                    dirtyFlag = True
    '                End If
    '            Else
    '                Me.m_payment.DocDate = Date.Now
    '                Me.m_payment.DocDate = Date.MinValue
    '                dirtyFlag = True
    '            End If
    '            m_dateSetting = False
    '        Case "txtdiscountamount"
    '            If IsNumeric(txtDiscountAmount.Text) Then
    '                Me.m_payment.DiscountAmount = CDec(txtDiscountAmount.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtotherrevenue"
    '            If IsNumeric(txtOtherRevenue.Text) Then
    '                Me.m_payment.OtherRevenue = CDec(txtOtherRevenue.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtinterest"
    '            If IsNumeric(txtInterest.Text) Then
    '                Me.m_payment.Interest = CDec(txtInterest.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtbankcharge"
    '            If IsNumeric(txtBankCharge.Text) Then
    '                Me.m_payment.BankCharge = CDec(txtBankCharge.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtotherexpense"
    '            If IsNumeric(txtOtherExpense.Text) Then
    '                Me.m_payment.OtherExpense = CDec(txtOtherExpense.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '    End Select
    '    Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
    '    CheckFormEnable()
    'End Sub
    Public Sub SetStatus()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = ""
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
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Buttons Event"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      'If Me.chkAutorun.Checked Then
      '    'Me.Validator.SetRequired(Me.txtCode, False)
      '    'Me.ErrorProvider1.SetError(Me.txtCode, "")  
      '    'cmbCode.Items.Clear()
      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
      '    'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_payment.EntityId)
      '    cmbCode.SelectedIndex = ComboCodeIndex
      '    m_oldCode = Me.cmbCode.Text
      '    Me.m_payment.Code = m_oldCode
      '    Me.m_payment.AutoGen = True
      'Else
      '    'Me.Validator.SetRequired(Me.txtCode, True)
      '    'cmbCode.SelectedIndex = ComboCodeIndex

      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
      '    'Me.cmbCode.Items.Clear()
      '    Me.cmbCode.Text = m_oldCode
      '    Me.m_payment.AutoGen = False
      'End If
    End Sub
    'Private Sub ibtnOtherDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnOtherDebit.Click
    '    Dim dlg As New OtherPayment(Me.m_payment, True)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
    '    If myDialog.ShowDialog() = DialogResult.OK Then
    '        UpdateAmount()
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    'End Sub
    'Private Sub ibtnTotalCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnTotalCredit.Click
    '    Dim dlg As New OtherPayment(Me.m_payment, False)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
    '    If myDialog.ShowDialog() = DialogResult.OK Then
    '        UpdateAmount()
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    'End Sub
#End Region
#Region "Event Handlers"
    Private Sub ibtnAddStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddStockitem.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If


      Dim filters(0) As Filter
      If RefDoc Is Nothing Then
       
        Return
      End If
      filters(0) = New Filter("stockisequence_list", GetStockitemAndQtyList)

      'myEntityPanelService.OpenDetailPanel(New GoodsReceipt)

      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems


      Dim Entities As New ArrayList
      Entities.Add(RefDoc.StoreCostcenter)

      Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()

      Dim myCostCenter As CostCenter = Nothing
      'If Me.RefDocAllocationType = AllocationType.AllocationFromOnly Then
      '  If Me.RefDoc.FromCostCenter Is Nothing Then
      '    msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
      '    Return
      '  End If
      '  myCostCenter = Me.RefDoc.FromCostCenter
      'ElseIf Me.RefDocAllocationType = AllocationType.AllocationToOnly Then
      '  If Me.RefDoc.ToCostCenter Is Nothing Then
      '    msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
      '    Return
      '  End If
      '  myCostCenter = Me.RefDoc.ToCostCenter
      'ElseIf Me.RefDocAllocationType = AllocationType.AllocationFromAndTo Then

      'End If
      'If Me.RefDoc.ToCostCenter.BoqId = 0 Then
      '  msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
      '  Return
      'End If
      Dim doc As EquipmentToolChangeStatusItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'dt.Clear()
      'Dim view As Integer = 7
      Dim sicoll As StockItemCollection = doc.ExpItemCollection
      'If wsdColl.GetSumPercent >= 100 Then
      '  'msgServ.ShowMessage(wsdColl.GetSumPercent)
      '  msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      '  Return
      'ElseIf doc.AllocationErrorMessage.Length > 0 Then
      '  msgServ.ShowMessage(doc.AllocationErrorMessage)
      '  Return
      'Else
      '  Dim wbsd As New WBSDistribute
      '  wbsd.CostCenter = myCostCenter 'Me.RefDoc.ToCostCenter
      '  wbsd.Percent = 100 - wsdColl.GetSumPercent
      '  wsdColl.Add(wbsd)
      'End If
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, view)
      Me.RefreshDocs() '---------------------**
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelStockitem.Click
      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'dt.Clear()
      Dim doc As StockItem = Me.CurrentWsbsd
      If doc Is Nothing Then
        Return
      End If
      'Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '    Return
      'End If
      Dim eci As EquipmentToolChangeStatusItem
      eci = doc.RefEqtItem

      If eci.ExpItemCollection.Contains(doc) Then
        eci.ExpItemCollection.Remove(doc)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      'If TypeOf m_entity Is IWBSAllocatable Then
      '  Dim al As IWBSAllocatable = CType(m_entity, IWBSAllocatable)
      '  'Dim dt As TreeTable = m_wbsTreeManager.Treetable
      '  'dt.Clear()
      '  For Each ali As IWBSAllocatableItem In al.GetWBSAllocatableItemCollection
      '    'Dim newRow As TreeRow = dt.Childs.Add()
      '    'newRow("ItemType") = ali.Type
      '    'newRow("Description") = ali.Description
      '    'newRow("ItemAmount") = Configuration.FormatToString(ali.ItemAmount, DigitConfig.Price)
      '    'newRow("CCButton") = "invisible"
      '    'newRow("Button") = "invisible"

      '    'newRow.Tag = ali
      '    If ali.WBSDistributeCollection.Contains(doc) Then
      '      ali.WBSDistributeCollection.Remove(doc)
      '      Me.WorkbenchWindow.ViewContent.IsDirty = True
      '    End If


      '    'For Each wbsd As WBSDistribute In ali.WBSDistributeCollection
      '    'Dim wbsRow As TreeRow = dt.Childs.Add()
      '    'wbsRow("CostCenter") = wbsd.CostCenter.Code & " : " & wbsd.CostCenter.Name
      '    'wbsRow("WBS") = wbsd.WBS.Code & " : " & wbsd.WBS.Name

      '    'wbsRow.Tag = wbsd

      '    'Next
      '  Next
      'End If

      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      'If wsdColl.Count > 0 Then
      '    wsdColl.Remove(wsdColl.Count - 1)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
      'Dim view As Integer = 7
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, View)
      Me.RefreshDocs()
      m_isInitialized = flag
    End Sub
    Private Function GetStockitemAndQtyList() As String
      Dim ret As String = ""
      For Each eci As EquipmentToolChangeStatusItem In RefDoc.ItemCollection
        If eci.ExpItemCollection IsNot Nothing Then
          For Each si As StockItem In eci.ExpItemCollection
            ret &= si.Sequence.ToString & ":" & si.Stockqty.ToString & ","
          Next
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      'If tgItem.CurrentRowIndex = 0 Then
      '  'Hack
      '  tgItem.CurrentRowIndex = 1
      'End If
      If Me.CurrentItem.ExpItemCollection Is Nothing Then
        Me.CurrentItem.ExpItemCollection = New StockItemCollection
      End If
      Me.CurrentItem.ExpItemCollection.SetItems(items)
      
      Me.CurrentItem.ExpItemCollection.RefEqtitem = Me.CurrentItem
      
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

    '#Region "Overrides"
    '        Public Overrides ReadOnly Property TabPageIcon() As String
    '            Get
    '                Return (New Payment).DetailPanelIcon
    '            End Get
    '        End Property
    '#End Region

    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
    '                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_payment.ClassName & ".xml"
    '                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "PaymentVoucher.xml"
    '                Dim df As New DesignerForm(thePath, CType(Me.m_payment, IPrintableEntity))
    '                Return df.PrintDocument
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property CanPrint() As Boolean
    '            Get
    '                Return False
    '            End Get
    '        End Property
    '#End Region
#Region "Exp TreeTable Handlers"
    Private Sub ExpTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_expTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      'If WBSValidateRow(CType(e.Row, TreeRow)) Then
      UpdateAmount()
      Me.m_expTreeManager.Treetable.AcceptChanges()
      'End If
      Me.RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub WBSUpdateAmount(ByVal e As DataColumnChangeEventArgs)
      'Dim item As WBSDistribute = Me.CurrentWsbsd
      'If item Is Nothing Then
      '    Return
      'End If
      'Dim currItem As PurchaseDNItem = Me.CurrentItem
      'If currItem Is Nothing Then
      '    Return
      'End If
      'e.Row("Amount") = Configuration.FormatToString(item.Percent * currItem.Amount / 100, DigitConfig.Price)
    End Sub
    Private Sub ExpTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          'Case "cbs"
          '  SetCBSCode(e)
          'Case "wbs"
          '  SetWBSCode(e)
          'Case "percent"
          '  SetWBSPercent(e)
          Case "amount"
            SetAmount(e)
          Case "stockqty"
            SetStockQty(e)
        End Select
        'WBSValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub WBSValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim wbs As Object = e.Row("wbs")
      Dim percent As Object = e.Row("percent")
      Dim amount As Object = e.Row("amount")

      Select Case e.Column.ColumnName.ToLower
        Case "wbs"
          wbs = e.ProposedValue
        Case "percent"
          percent = e.ProposedValue
        Case "amount"
          amount = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(wbs) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
          e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
        Else
          e.Row.SetColumnError("percent", "")
        End If
        If IsDBNull(wbs) OrElse wbs.ToString.Replace(":", "").Length = 0 Then
          e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
        Else
          e.Row.SetColumnError("wbs", "")
        End If
        If IsDBNull(amount) OrElse CDec(amount) <= 0 Then
          e.Row.SetColumnError("amount", Me.StringParserService.Parse("${res:Global.Error.RealAmountMissing}"))
        Else
          e.Row.SetColumnError("amount", "")
        End If
      End If

    End Sub
    Public Function WBSValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("WBS") Then
        Return False
      End If
      Return True
    End Function
    Private m_wbsUpdating As Boolean = False
    
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If m_wbsUpdating Then
      '  Return
      'End If
      Dim item As StockItem = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If

      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)

      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If
      Dim doc As IWBSAllocatableItem = Me.CurrentParItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = Me.CurrentParItem.WBSDistributeCollection
      Dim Amount As Decimal = wsdColl.GetSumAmount - oldvalue + value
      If Amount > doc.ItemAmount Then
        e.ProposedValue = e.Row(e.Column)
        msgServ.ShowMessageFormatted("${res:Global.Error.AmountOverCostAmount}", New String() {Configuration.FormatToString(Amount, DigitConfig.Price), Configuration.FormatToString(doc.ItemAmount, DigitConfig.Price)})
        Return
      End If

      m_wbsUpdating = True
      item.Amount = value
      m_wbsUpdating = False
    End Sub
    Public Sub SetStockQty(ByVal e As DataColumnChangeEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If m_wbsUpdating Then
      '  Return
      'End If
      Dim item As StockItem = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If

      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)

      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If
      Dim doc As EqtItem = Me.CurrentParItem
      If doc Is Nothing Then
        Return
      End If
      If value > item.oldstockqty Then
        value = oldvalue
      End If

      'Dim wsdColl As WBSDistributeCollection = Me.CurrentParItem.WBSDistributeCollection
      'Dim Amount As Decimal = wsdColl.GetSumAmount - oldvalue + value
      'If Amount > doc.ItemAmount Then
      '  e.ProposedValue = e.Row(e.Column)
      '  msgServ.ShowMessageFormatted("${res:Global.Error.AmountOverCostAmount}", New String() {Configuration.FormatToString(Amount, DigitConfig.Price), Configuration.FormatToString(doc.ItemAmount, DigitConfig.Price)})
      '  Return
      'End If

      m_wbsUpdating = True
      item.Stockqty = value
      m_wbsUpdating = False
    End Sub
    'Private Function DupWBSCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '    If e.Row.IsNull("stocki_entityType") Then
    '        Return False
    '    End If
    '    If IsDBNull(e.ProposedValue) Then
    '        Return False
    '    End If
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '        If Not row Is e.Row Then
    '            If Not row.IsNull("stocki_entityType") Then
    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '                    If Not row.IsNull("code") Then
    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '                            Return True
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    Return False
    'End Function
    Public Sub SetWBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_wbsUpdating Then
      '    Return
      'End If
      'm_wbsUpdating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'Dim currItem As PurchaseDNItem = Me.CurrentItem
      'If currItem Is Nothing Then
      '    Return
      'End If
      'If currItem.GoodsReceiptLine <> 0 Then
      '    msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
      '    e.ProposedValue = e.Row(e.Column)
      '    Return
      'End If
      'If e.Row.IsNull("stocki_entityType") Then
      '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '    e.ProposedValue = e.Row(e.Column)
      '    m_wbsUpdating = False
      '    Return
      'End If
      'If DupCode(e) Then
      '    Dim item As New GoodsReceiptItem
      '    item.CopyFromDataRow(CType(e.Row, TreeRow))
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
      '    e.ProposedValue = e.Row(e.Column)
      '    m_wbsUpdating = False
      '    Return
      'End If
      'Select Case CInt(e.Row("stocki_entityType"))
      '    Case 0 'Blank
      '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      '    Case 28 'F/A
      '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      '    Case 19 'Tool
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_wbsUpdating = False
      '            Return
      '        End If
      '        Dim myTool As New Tool(e.ProposedValue.ToString)
      '        If Not myTool.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_wbsUpdating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = myTool.Unit
      '            e.Row("stocki_entity") = myTool.Id
      '            e.ProposedValue = myTool.Code
      '            e.Row("stocki_itemName") = myTool.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
      '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
      '                e.Row("stocki_acct") = ga.Account.Id
      '                e.Row("AccountCode") = ga.Account.Code
      '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case 42 'LCI
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_wbsUpdating = False
      '            Return
      '        End If
      '        Dim lci As New LCIItem(e.ProposedValue.ToString)
      '        If Not lci.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_wbsUpdating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = lci.DefaultUnit
      '            e.Row("stocki_entity") = lci.Id
      '            e.ProposedValue = lci.Code
      '            e.Row("stocki_itemName") = lci.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
      '                e.Row("stocki_acct") = lci.Account.Id
      '                e.Row("AccountCode") = lci.Account.Code
      '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case Else
      '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      'End Select
      'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'm_wbsUpdating = False
    End Sub
   
    Private Function SplitCodeCBS(ByVal value As String) As String
      Dim spCodeName() As String
      spCodeName = value.Split(CChar(":"))
      If Not spCodeName Is Nothing AndAlso spCodeName(0).Length > 0 Then
        Return spCodeName(0)
      End If
      Return ""
    End Function
    Private Sub WBSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

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



  End Class

End Namespace
