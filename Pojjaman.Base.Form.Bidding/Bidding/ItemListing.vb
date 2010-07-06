Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Longkong.Core.Properties
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ItemListing
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
    Friend WithEvents grbPrice As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents lblMat As System.Windows.Forms.Label
    Friend WithEvents lblLabor As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblWorkBreakdown As System.Windows.Forms.Label
    Friend WithEvents grbUnitPrice As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBaht2 As System.Windows.Forms.Label
    Friend WithEvents grbSupplier As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblEquip As System.Windows.Forms.Label
    Friend WithEvents grbEquip As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbLabor As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBOQCode As System.Windows.Forms.Label
    Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblItemQTY As System.Windows.Forms.Label
    Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowUnit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowUnitDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtItemUnitName As System.Windows.Forms.TextBox
    Friend WithEvents lblItemUnit As System.Windows.Forms.Label
    Friend WithEvents txtItemUnitCode As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblItemDes As System.Windows.Forms.Label
    Friend WithEvents txtItemNote As System.Windows.Forms.TextBox
    Friend WithEvents lblItemNote As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemTotalPrice As System.Windows.Forms.Label
    Friend WithEvents lblItemUnitPrice As System.Windows.Forms.Label
    Friend WithEvents txtItemMatUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTotalLaborPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTotalUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTotalEqPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTotalMatPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemEqUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtItemLaborUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tpItemDetail As System.Windows.Forms.TabPage
    Friend WithEvents lblCurrentPrice As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnApplyLCIUnitPrice As System.Windows.Forms.Button
    Friend WithEvents tgLCIUnitPrice As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents tgLCISupplier As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents btnSupplierDetail As System.Windows.Forms.Button
    Friend WithEvents tgLCIEqCost As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents btnApplyEqCost As System.Windows.Forms.Button
    Friend WithEvents btnApplyLaborUnitPrice As System.Windows.Forms.Button
    Friend WithEvents tgLCILabor As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents tbDetail As System.Windows.Forms.TabControl
    Friend WithEvents tpUnitPrice As System.Windows.Forms.TabPage
    Friend WithEvents tpLaborEq As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbBOQType As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkMat As System.Windows.Forms.CheckBox
    Friend WithEvents chkLabor As System.Windows.Forms.CheckBox
    Friend WithEvents chkEquip As System.Windows.Forms.CheckBox
    Friend WithEvents cmbEntityType As System.Windows.Forms.ComboBox
    Friend WithEvents lblEntityType As System.Windows.Forms.Label
    Friend WithEvents lblCurrentLabor As System.Windows.Forms.Label
    Friend WithEvents txtCurrentLabor As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentLaborUnit As System.Windows.Forms.Label
    Friend WithEvents lblCurrentEq As System.Windows.Forms.Label
    Friend WithEvents txtCurrentEq As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrenEqUnit As System.Windows.Forms.Label
    Friend WithEvents ibtnZoomChart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSummarize As System.Windows.Forms.GroupBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblMonthPeriod As System.Windows.Forms.Label
    Friend WithEvents txtMonthPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnLockBoq As System.Windows.Forms.Button
    Friend WithEvents ibtnSaveAsExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemListing))
      Me.lblItemQTY = New System.Windows.Forms.Label()
      Me.txtItemQty = New System.Windows.Forms.TextBox()
      Me.ibtnShowUnit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowUnitDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtItemUnitName = New System.Windows.Forms.TextBox()
      Me.lblItemUnit = New System.Windows.Forms.Label()
      Me.txtItemUnitCode = New System.Windows.Forms.TextBox()
      Me.txtItemDescription = New System.Windows.Forms.TextBox()
      Me.lblItemDes = New System.Windows.Forms.Label()
      Me.txtItemNote = New System.Windows.Forms.TextBox()
      Me.lblItemNote = New System.Windows.Forms.Label()
      Me.txtItemName = New System.Windows.Forms.TextBox()
      Me.lblItemCode = New System.Windows.Forms.Label()
      Me.txtItemCode = New System.Windows.Forms.TextBox()
      Me.grbPrice = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblItemTotalPrice = New System.Windows.Forms.Label()
      Me.lblItemUnitPrice = New System.Windows.Forms.Label()
      Me.txtItemMatUnitPrice = New System.Windows.Forms.TextBox()
      Me.txtItemTotalLaborPrice = New System.Windows.Forms.TextBox()
      Me.txtItemTotalUnitPrice = New System.Windows.Forms.TextBox()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblBaht1 = New System.Windows.Forms.Label()
      Me.txtItemTotalPrice = New System.Windows.Forms.TextBox()
      Me.txtItemTotalEqPrice = New System.Windows.Forms.TextBox()
      Me.txtItemTotalMatPrice = New System.Windows.Forms.TextBox()
      Me.txtItemEqUnitPrice = New System.Windows.Forms.TextBox()
      Me.txtItemLaborUnitPrice = New System.Windows.Forms.TextBox()
      Me.lblMat = New System.Windows.Forms.Label()
      Me.lblLabor = New System.Windows.Forms.Label()
      Me.lblEquip = New System.Windows.Forms.Label()
      Me.lblTotal = New System.Windows.Forms.Label()
      Me.btnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWorkBreakdown = New System.Windows.Forms.Label()
      Me.tbDetail = New System.Windows.Forms.TabControl()
      Me.tpItemDetail = New System.Windows.Forms.TabPage()
      Me.cmbEntityType = New System.Windows.Forms.ComboBox()
      Me.lblEntityType = New System.Windows.Forms.Label()
      Me.tpUnitPrice = New System.Windows.Forms.TabPage()
      Me.grbUnitPrice = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtMonthPeriod = New System.Windows.Forms.NumericUpDown()
      Me.lblCurrentPrice = New System.Windows.Forms.Label()
      Me.txtCurrentPrice = New System.Windows.Forms.TextBox()
      Me.btnApplyLCIUnitPrice = New System.Windows.Forms.Button()
      Me.tgLCIUnitPrice = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblBaht2 = New System.Windows.Forms.Label()
      Me.lblMonth = New System.Windows.Forms.Label()
      Me.lblMonthPeriod = New System.Windows.Forms.Label()
      Me.grbSupplier = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.tgLCISupplier = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.btnSupplierDetail = New System.Windows.Forms.Button()
      Me.tpLaborEq = New System.Windows.Forms.TabPage()
      Me.grbEquip = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCurrentEq = New System.Windows.Forms.Label()
      Me.txtCurrentEq = New System.Windows.Forms.TextBox()
      Me.lblCurrenEqUnit = New System.Windows.Forms.Label()
      Me.tgLCIEqCost = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.btnApplyEqCost = New System.Windows.Forms.Button()
      Me.grbLabor = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCurrentLabor = New System.Windows.Forms.Label()
      Me.txtCurrentLabor = New System.Windows.Forms.TextBox()
      Me.lblCurrentLaborUnit = New System.Windows.Forms.Label()
      Me.btnApplyLaborUnitPrice = New System.Windows.Forms.Button()
      Me.tgLCILabor = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblBOQCode = New System.Windows.Forms.Label()
      Me.txtBOQCode = New System.Windows.Forms.TextBox()
      Me.txtProjectName = New System.Windows.Forms.TextBox()
      Me.lblProject = New System.Windows.Forms.Label()
      Me.txtProjectCode = New System.Windows.Forms.TextBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbBOQType = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkMat = New System.Windows.Forms.CheckBox()
      Me.chkLabor = New System.Windows.Forms.CheckBox()
      Me.chkEquip = New System.Windows.Forms.CheckBox()
      Me.ibtnZoomChart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbSummarize = New System.Windows.Forms.GroupBox()
      Me.lblLevel = New System.Windows.Forms.Label()
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnSaveAsExcel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLockBoq = New System.Windows.Forms.Button()
      Me.grbPrice.SuspendLayout()
      Me.tbDetail.SuspendLayout()
      Me.tpItemDetail.SuspendLayout()
      Me.tpUnitPrice.SuspendLayout()
      Me.grbUnitPrice.SuspendLayout()
      CType(Me.txtMonthPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgLCIUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSupplier.SuspendLayout()
      CType(Me.tgLCISupplier, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpLaborEq.SuspendLayout()
      Me.grbEquip.SuspendLayout()
      CType(Me.tgLCIEqCost, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbLabor.SuspendLayout()
      CType(Me.tgLCILabor, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbBOQType.SuspendLayout()
      Me.grbSummarize.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblItemQTY
      '
      Me.lblItemQTY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemQTY.ForeColor = System.Drawing.Color.Black
      Me.lblItemQTY.Location = New System.Drawing.Point(8, 56)
      Me.lblItemQTY.Name = "lblItemQTY"
      Me.lblItemQTY.Size = New System.Drawing.Size(96, 18)
      Me.lblItemQTY.TabIndex = 10
      Me.lblItemQTY.Text = "ปริมาณ:"
      Me.lblItemQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemQty
      '
      Me.Validator.SetDataType(Me.txtItemQty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemQty, "")
      Me.txtItemQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemQty, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemQty, System.Drawing.Color.Empty)
      Me.txtItemQty.Location = New System.Drawing.Point(104, 56)
      Me.Validator.SetMinValue(Me.txtItemQty, "")
      Me.txtItemQty.Name = "txtItemQty"
      Me.Validator.SetRegularExpression(Me.txtItemQty, "")
      Me.Validator.SetRequired(Me.txtItemQty, False)
      Me.txtItemQty.Size = New System.Drawing.Size(128, 22)
      Me.txtItemQty.TabIndex = 3
      Me.txtItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnShowUnit
      '
      Me.ibtnShowUnit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnit.Location = New System.Drawing.Point(480, 56)
      Me.ibtnShowUnit.Name = "ibtnShowUnit"
      Me.ibtnShowUnit.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnit.TabIndex = 17
      Me.ibtnShowUnit.TabStop = False
      Me.ibtnShowUnit.ThemedImage = CType(resources.GetObject("ibtnShowUnit.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowUnitDialog
      '
      Me.ibtnShowUnitDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnitDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnitDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowUnitDialog.Location = New System.Drawing.Point(456, 56)
      Me.ibtnShowUnitDialog.Name = "ibtnShowUnitDialog"
      Me.ibtnShowUnitDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnitDialog.TabIndex = 18
      Me.ibtnShowUnitDialog.TabStop = False
      Me.ibtnShowUnitDialog.ThemedImage = CType(resources.GetObject("ibtnShowUnitDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtItemUnitName
      '
      Me.Validator.SetDataType(Me.txtItemUnitName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemUnitName, "")
      Me.txtItemUnitName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemUnitName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemUnitName, System.Drawing.Color.Empty)
      Me.txtItemUnitName.Location = New System.Drawing.Point(336, 56)
      Me.Validator.SetMinValue(Me.txtItemUnitName, "")
      Me.txtItemUnitName.Name = "txtItemUnitName"
      Me.txtItemUnitName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemUnitName, "")
      Me.Validator.SetRequired(Me.txtItemUnitName, False)
      Me.txtItemUnitName.Size = New System.Drawing.Size(120, 21)
      Me.txtItemUnitName.TabIndex = 19
      Me.txtItemUnitName.TabStop = False
      '
      'lblItemUnit
      '
      Me.lblItemUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemUnit.ForeColor = System.Drawing.Color.Black
      Me.lblItemUnit.Location = New System.Drawing.Point(224, 56)
      Me.lblItemUnit.Name = "lblItemUnit"
      Me.lblItemUnit.Size = New System.Drawing.Size(56, 18)
      Me.lblItemUnit.TabIndex = 20
      Me.lblItemUnit.Text = "หน่วย:"
      Me.lblItemUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemUnitCode
      '
      Me.Validator.SetDataType(Me.txtItemUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemUnitCode, "")
      Me.txtItemUnitCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemUnitCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemUnitCode, System.Drawing.Color.Empty)
      Me.txtItemUnitCode.Location = New System.Drawing.Point(280, 56)
      Me.txtItemUnitCode.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtItemUnitCode, "")
      Me.txtItemUnitCode.Name = "txtItemUnitCode"
      Me.Validator.SetRegularExpression(Me.txtItemUnitCode, "")
      Me.Validator.SetRequired(Me.txtItemUnitCode, False)
      Me.txtItemUnitCode.Size = New System.Drawing.Size(56, 21)
      Me.txtItemUnitCode.TabIndex = 4
      '
      'txtItemDescription
      '
      Me.Validator.SetDataType(Me.txtItemDescription, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemDescription, "")
      Me.txtItemDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemDescription, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemDescription, System.Drawing.Color.Empty)
      Me.txtItemDescription.Location = New System.Drawing.Point(104, 32)
      Me.txtItemDescription.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtItemDescription, "")
      Me.txtItemDescription.Name = "txtItemDescription"
      Me.Validator.SetRegularExpression(Me.txtItemDescription, "")
      Me.Validator.SetRequired(Me.txtItemDescription, False)
      Me.txtItemDescription.Size = New System.Drawing.Size(536, 22)
      Me.txtItemDescription.TabIndex = 2
      '
      'lblItemDes
      '
      Me.lblItemDes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemDes.ForeColor = System.Drawing.Color.Black
      Me.lblItemDes.Location = New System.Drawing.Point(8, 32)
      Me.lblItemDes.Name = "lblItemDes"
      Me.lblItemDes.Size = New System.Drawing.Size(96, 18)
      Me.lblItemDes.TabIndex = 11
      Me.lblItemDes.Text = "Item Description:"
      Me.lblItemDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemNote
      '
      Me.Validator.SetDataType(Me.txtItemNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemNote, "")
      Me.txtItemNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemNote, System.Drawing.Color.Empty)
      Me.txtItemNote.Location = New System.Drawing.Point(104, 152)
      Me.txtItemNote.MaxLength = 2000
      Me.Validator.SetMinValue(Me.txtItemNote, "")
      Me.txtItemNote.Multiline = True
      Me.txtItemNote.Name = "txtItemNote"
      Me.Validator.SetRegularExpression(Me.txtItemNote, "")
      Me.Validator.SetRequired(Me.txtItemNote, False)
      Me.txtItemNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtItemNote.Size = New System.Drawing.Size(528, 42)
      Me.txtItemNote.TabIndex = 8
      '
      'lblItemNote
      '
      Me.lblItemNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemNote.ForeColor = System.Drawing.Color.Black
      Me.lblItemNote.Location = New System.Drawing.Point(8, 152)
      Me.lblItemNote.Name = "lblItemNote"
      Me.lblItemNote.Size = New System.Drawing.Size(96, 18)
      Me.lblItemNote.TabIndex = 9
      Me.lblItemNote.Text = "Remark:"
      Me.lblItemNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemName
      '
      Me.Validator.SetDataType(Me.txtItemName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemName, "")
      Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.txtItemName.Location = New System.Drawing.Point(320, 8)
      Me.Validator.SetMinValue(Me.txtItemName, "")
      Me.txtItemName.Name = "txtItemName"
      Me.txtItemName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemName, "")
      Me.Validator.SetRequired(Me.txtItemName, False)
      Me.txtItemName.Size = New System.Drawing.Size(272, 22)
      Me.txtItemName.TabIndex = 14
      Me.txtItemName.TabStop = False
      '
      'lblItemCode
      '
      Me.lblItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCode.ForeColor = System.Drawing.Color.Black
      Me.lblItemCode.Location = New System.Drawing.Point(176, 10)
      Me.lblItemCode.Name = "lblItemCode"
      Me.lblItemCode.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCode.TabIndex = 13
      Me.lblItemCode.Text = "Code:"
      Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemCode
      '
      Me.Validator.SetDataType(Me.txtItemCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCode, "")
      Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
      Me.txtItemCode.Location = New System.Drawing.Point(216, 8)
      Me.txtItemCode.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtItemCode, "")
      Me.txtItemCode.Name = "txtItemCode"
      Me.Validator.SetRegularExpression(Me.txtItemCode, "")
      Me.Validator.SetRequired(Me.txtItemCode, False)
      Me.txtItemCode.Size = New System.Drawing.Size(104, 22)
      Me.txtItemCode.TabIndex = 1
      '
      'grbPrice
      '
      Me.grbPrice.Controls.Add(Me.lblItemTotalPrice)
      Me.grbPrice.Controls.Add(Me.lblItemUnitPrice)
      Me.grbPrice.Controls.Add(Me.txtItemMatUnitPrice)
      Me.grbPrice.Controls.Add(Me.txtItemTotalLaborPrice)
      Me.grbPrice.Controls.Add(Me.txtItemTotalUnitPrice)
      Me.grbPrice.Controls.Add(Me.lblBaht)
      Me.grbPrice.Controls.Add(Me.lblBaht1)
      Me.grbPrice.Controls.Add(Me.txtItemTotalPrice)
      Me.grbPrice.Controls.Add(Me.txtItemTotalEqPrice)
      Me.grbPrice.Controls.Add(Me.txtItemTotalMatPrice)
      Me.grbPrice.Controls.Add(Me.txtItemEqUnitPrice)
      Me.grbPrice.Controls.Add(Me.txtItemLaborUnitPrice)
      Me.grbPrice.Controls.Add(Me.lblMat)
      Me.grbPrice.Controls.Add(Me.lblLabor)
      Me.grbPrice.Controls.Add(Me.lblEquip)
      Me.grbPrice.Controls.Add(Me.lblTotal)
      Me.grbPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPrice.Location = New System.Drawing.Point(16, 72)
      Me.grbPrice.Name = "grbPrice"
      Me.grbPrice.Size = New System.Drawing.Size(616, 80)
      Me.grbPrice.TabIndex = 5
      Me.grbPrice.TabStop = False
      Me.grbPrice.Text = "ราคา"
      '
      'lblItemTotalPrice
      '
      Me.lblItemTotalPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemTotalPrice.ForeColor = System.Drawing.Color.Black
      Me.lblItemTotalPrice.Location = New System.Drawing.Point(8, 48)
      Me.lblItemTotalPrice.Name = "lblItemTotalPrice"
      Me.lblItemTotalPrice.Size = New System.Drawing.Size(80, 18)
      Me.lblItemTotalPrice.TabIndex = 0
      Me.lblItemTotalPrice.Text = "Total Price:"
      Me.lblItemTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemUnitPrice
      '
      Me.lblItemUnitPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemUnitPrice.ForeColor = System.Drawing.Color.Black
      Me.lblItemUnitPrice.Location = New System.Drawing.Point(8, 24)
      Me.lblItemUnitPrice.Name = "lblItemUnitPrice"
      Me.lblItemUnitPrice.Size = New System.Drawing.Size(80, 18)
      Me.lblItemUnitPrice.TabIndex = 15
      Me.lblItemUnitPrice.Text = "Unit Price:"
      Me.lblItemUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemMatUnitPrice
      '
      Me.Validator.SetDataType(Me.txtItemMatUnitPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemMatUnitPrice, "")
      Me.txtItemMatUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemMatUnitPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemMatUnitPrice, System.Drawing.Color.Empty)
      Me.txtItemMatUnitPrice.Location = New System.Drawing.Point(88, 24)
      Me.Validator.SetMinValue(Me.txtItemMatUnitPrice, "")
      Me.txtItemMatUnitPrice.Name = "txtItemMatUnitPrice"
      Me.Validator.SetRegularExpression(Me.txtItemMatUnitPrice, "")
      Me.Validator.SetRequired(Me.txtItemMatUnitPrice, False)
      Me.txtItemMatUnitPrice.Size = New System.Drawing.Size(128, 22)
      Me.txtItemMatUnitPrice.TabIndex = 0
      Me.txtItemMatUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemTotalLaborPrice
      '
      Me.Validator.SetDataType(Me.txtItemTotalLaborPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemTotalLaborPrice, "")
      Me.txtItemTotalLaborPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemTotalLaborPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemTotalLaborPrice, System.Drawing.Color.Empty)
      Me.txtItemTotalLaborPrice.Location = New System.Drawing.Point(216, 48)
      Me.Validator.SetMinValue(Me.txtItemTotalLaborPrice, "")
      Me.txtItemTotalLaborPrice.Name = "txtItemTotalLaborPrice"
      Me.Validator.SetRegularExpression(Me.txtItemTotalLaborPrice, "")
      Me.Validator.SetRequired(Me.txtItemTotalLaborPrice, False)
      Me.txtItemTotalLaborPrice.Size = New System.Drawing.Size(112, 22)
      Me.txtItemTotalLaborPrice.TabIndex = 5
      Me.txtItemTotalLaborPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemTotalUnitPrice
      '
      Me.Validator.SetDataType(Me.txtItemTotalUnitPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemTotalUnitPrice, "")
      Me.txtItemTotalUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemTotalUnitPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemTotalUnitPrice, System.Drawing.Color.Empty)
      Me.txtItemTotalUnitPrice.Location = New System.Drawing.Point(440, 24)
      Me.Validator.SetMinValue(Me.txtItemTotalUnitPrice, "")
      Me.txtItemTotalUnitPrice.Name = "txtItemTotalUnitPrice"
      Me.txtItemTotalUnitPrice.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemTotalUnitPrice, "")
      Me.Validator.SetRequired(Me.txtItemTotalUnitPrice, False)
      Me.txtItemTotalUnitPrice.Size = New System.Drawing.Size(136, 22)
      Me.txtItemTotalUnitPrice.TabIndex = 10
      Me.txtItemTotalUnitPrice.TabStop = False
      Me.txtItemTotalUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(576, 24)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht.TabIndex = 9
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht1
      '
      Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht1.ForeColor = System.Drawing.Color.Black
      Me.lblBaht1.Location = New System.Drawing.Point(576, 48)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht1.TabIndex = 8
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtItemTotalPrice
      '
      Me.Validator.SetDataType(Me.txtItemTotalPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemTotalPrice, "")
      Me.txtItemTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemTotalPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemTotalPrice, System.Drawing.Color.Empty)
      Me.txtItemTotalPrice.Location = New System.Drawing.Point(440, 48)
      Me.Validator.SetMinValue(Me.txtItemTotalPrice, "")
      Me.txtItemTotalPrice.Name = "txtItemTotalPrice"
      Me.txtItemTotalPrice.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemTotalPrice, "")
      Me.Validator.SetRequired(Me.txtItemTotalPrice, False)
      Me.txtItemTotalPrice.Size = New System.Drawing.Size(136, 22)
      Me.txtItemTotalPrice.TabIndex = 7
      Me.txtItemTotalPrice.TabStop = False
      Me.txtItemTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemTotalEqPrice
      '
      Me.Validator.SetDataType(Me.txtItemTotalEqPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemTotalEqPrice, "")
      Me.txtItemTotalEqPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemTotalEqPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemTotalEqPrice, System.Drawing.Color.Empty)
      Me.txtItemTotalEqPrice.Location = New System.Drawing.Point(328, 48)
      Me.Validator.SetMinValue(Me.txtItemTotalEqPrice, "")
      Me.txtItemTotalEqPrice.Name = "txtItemTotalEqPrice"
      Me.Validator.SetRegularExpression(Me.txtItemTotalEqPrice, "")
      Me.Validator.SetRequired(Me.txtItemTotalEqPrice, False)
      Me.txtItemTotalEqPrice.Size = New System.Drawing.Size(112, 22)
      Me.txtItemTotalEqPrice.TabIndex = 6
      Me.txtItemTotalEqPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemTotalMatPrice
      '
      Me.Validator.SetDataType(Me.txtItemTotalMatPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemTotalMatPrice, "")
      Me.txtItemTotalMatPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemTotalMatPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemTotalMatPrice, System.Drawing.Color.Empty)
      Me.txtItemTotalMatPrice.Location = New System.Drawing.Point(88, 48)
      Me.Validator.SetMinValue(Me.txtItemTotalMatPrice, "")
      Me.txtItemTotalMatPrice.Name = "txtItemTotalMatPrice"
      Me.Validator.SetRegularExpression(Me.txtItemTotalMatPrice, "")
      Me.Validator.SetRequired(Me.txtItemTotalMatPrice, False)
      Me.txtItemTotalMatPrice.Size = New System.Drawing.Size(128, 22)
      Me.txtItemTotalMatPrice.TabIndex = 4
      Me.txtItemTotalMatPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemEqUnitPrice
      '
      Me.Validator.SetDataType(Me.txtItemEqUnitPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemEqUnitPrice, "")
      Me.txtItemEqUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemEqUnitPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemEqUnitPrice, System.Drawing.Color.Empty)
      Me.txtItemEqUnitPrice.Location = New System.Drawing.Point(328, 24)
      Me.Validator.SetMinValue(Me.txtItemEqUnitPrice, "")
      Me.txtItemEqUnitPrice.Name = "txtItemEqUnitPrice"
      Me.Validator.SetRegularExpression(Me.txtItemEqUnitPrice, "")
      Me.Validator.SetRequired(Me.txtItemEqUnitPrice, False)
      Me.txtItemEqUnitPrice.Size = New System.Drawing.Size(112, 22)
      Me.txtItemEqUnitPrice.TabIndex = 2
      Me.txtItemEqUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemLaborUnitPrice
      '
      Me.Validator.SetDataType(Me.txtItemLaborUnitPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemLaborUnitPrice, "")
      Me.txtItemLaborUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemLaborUnitPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemLaborUnitPrice, System.Drawing.Color.Empty)
      Me.txtItemLaborUnitPrice.Location = New System.Drawing.Point(216, 24)
      Me.Validator.SetMinValue(Me.txtItemLaborUnitPrice, "")
      Me.txtItemLaborUnitPrice.Name = "txtItemLaborUnitPrice"
      Me.Validator.SetRegularExpression(Me.txtItemLaborUnitPrice, "")
      Me.Validator.SetRequired(Me.txtItemLaborUnitPrice, False)
      Me.txtItemLaborUnitPrice.Size = New System.Drawing.Size(112, 22)
      Me.txtItemLaborUnitPrice.TabIndex = 1
      Me.txtItemLaborUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMat
      '
      Me.lblMat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMat.ForeColor = System.Drawing.Color.Black
      Me.lblMat.Location = New System.Drawing.Point(96, 8)
      Me.lblMat.Name = "lblMat"
      Me.lblMat.Size = New System.Drawing.Size(72, 18)
      Me.lblMat.TabIndex = 14
      Me.lblMat.Text = "ค่าวัสดุ"
      Me.lblMat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblLabor
      '
      Me.lblLabor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLabor.ForeColor = System.Drawing.Color.Black
      Me.lblLabor.Location = New System.Drawing.Point(224, 8)
      Me.lblLabor.Name = "lblLabor"
      Me.lblLabor.Size = New System.Drawing.Size(72, 18)
      Me.lblLabor.TabIndex = 13
      Me.lblLabor.Text = "ค่าแรง"
      Me.lblLabor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblEquip
      '
      Me.lblEquip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquip.ForeColor = System.Drawing.Color.Black
      Me.lblEquip.Location = New System.Drawing.Point(352, 8)
      Me.lblEquip.Name = "lblEquip"
      Me.lblEquip.Size = New System.Drawing.Size(72, 18)
      Me.lblEquip.TabIndex = 12
      Me.lblEquip.Text = "เครื่องจักร"
      Me.lblEquip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblTotal
      '
      Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotal.ForeColor = System.Drawing.Color.Black
      Me.lblTotal.Location = New System.Drawing.Point(480, 8)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(72, 18)
      Me.lblTotal.TabIndex = 11
      Me.lblTotal.Text = "รวม"
      Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnShowLCI
      '
      Me.btnShowLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowLCI.Location = New System.Drawing.Point(616, 8)
      Me.btnShowLCI.Name = "btnShowLCI"
      Me.btnShowLCI.Size = New System.Drawing.Size(24, 23)
      Me.btnShowLCI.TabIndex = 16
      Me.btnShowLCI.TabStop = False
      Me.btnShowLCI.ThemedImage = CType(resources.GetObject("btnShowLCI.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibnShowLCIDialog
      '
      Me.ibnShowLCIDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibnShowLCIDialog.Location = New System.Drawing.Point(592, 8)
      Me.ibnShowLCIDialog.Name = "ibnShowLCIDialog"
      Me.ibnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibnShowLCIDialog.TabIndex = 15
      Me.ibnShowLCIDialog.TabStop = False
      Me.ibnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWorkBreakdown
      '
      Me.lblWorkBreakdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWorkBreakdown.Location = New System.Drawing.Point(8, 72)
      Me.lblWorkBreakdown.Name = "lblWorkBreakdown"
      Me.lblWorkBreakdown.Size = New System.Drawing.Size(208, 23)
      Me.lblWorkBreakdown.TabIndex = 5
      Me.lblWorkBreakdown.Text = "BOQ Work Breakdown Structure"
      '
      'tbDetail
      '
      Me.tbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetail.Controls.Add(Me.tpItemDetail)
      Me.tbDetail.Controls.Add(Me.tpUnitPrice)
      Me.tbDetail.Controls.Add(Me.tpLaborEq)
      Me.tbDetail.Location = New System.Drawing.Point(8, 320)
      Me.tbDetail.Name = "tbDetail"
      Me.tbDetail.SelectedIndex = 0
      Me.tbDetail.Size = New System.Drawing.Size(712, 232)
      Me.tbDetail.TabIndex = 9
      '
      'tpItemDetail
      '
      Me.tpItemDetail.Controls.Add(Me.cmbEntityType)
      Me.tpItemDetail.Controls.Add(Me.lblItemQTY)
      Me.tpItemDetail.Controls.Add(Me.txtItemQty)
      Me.tpItemDetail.Controls.Add(Me.ibtnShowUnit)
      Me.tpItemDetail.Controls.Add(Me.ibtnShowUnitDialog)
      Me.tpItemDetail.Controls.Add(Me.txtItemUnitName)
      Me.tpItemDetail.Controls.Add(Me.lblItemUnit)
      Me.tpItemDetail.Controls.Add(Me.txtItemUnitCode)
      Me.tpItemDetail.Controls.Add(Me.txtItemDescription)
      Me.tpItemDetail.Controls.Add(Me.lblItemDes)
      Me.tpItemDetail.Controls.Add(Me.txtItemNote)
      Me.tpItemDetail.Controls.Add(Me.lblItemNote)
      Me.tpItemDetail.Controls.Add(Me.txtItemName)
      Me.tpItemDetail.Controls.Add(Me.btnShowLCI)
      Me.tpItemDetail.Controls.Add(Me.lblItemCode)
      Me.tpItemDetail.Controls.Add(Me.txtItemCode)
      Me.tpItemDetail.Controls.Add(Me.grbPrice)
      Me.tpItemDetail.Controls.Add(Me.ibnShowLCIDialog)
      Me.tpItemDetail.Controls.Add(Me.lblEntityType)
      Me.tpItemDetail.Location = New System.Drawing.Point(4, 22)
      Me.tpItemDetail.Name = "tpItemDetail"
      Me.tpItemDetail.Size = New System.Drawing.Size(704, 206)
      Me.tpItemDetail.TabIndex = 0
      Me.tpItemDetail.Text = "รายละเอียดรายการ"
      '
      'cmbEntityType
      '
      Me.cmbEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEntityType.Location = New System.Drawing.Point(104, 9)
      Me.cmbEntityType.Name = "cmbEntityType"
      Me.cmbEntityType.Size = New System.Drawing.Size(80, 21)
      Me.cmbEntityType.TabIndex = 0
      '
      'lblEntityType
      '
      Me.lblEntityType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEntityType.ForeColor = System.Drawing.Color.Black
      Me.lblEntityType.Location = New System.Drawing.Point(8, 10)
      Me.lblEntityType.Name = "lblEntityType"
      Me.lblEntityType.Size = New System.Drawing.Size(96, 18)
      Me.lblEntityType.TabIndex = 12
      Me.lblEntityType.Text = "Type:"
      Me.lblEntityType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tpUnitPrice
      '
      Me.tpUnitPrice.Controls.Add(Me.grbUnitPrice)
      Me.tpUnitPrice.Controls.Add(Me.grbSupplier)
      Me.tpUnitPrice.Location = New System.Drawing.Point(4, 22)
      Me.tpUnitPrice.Name = "tpUnitPrice"
      Me.tpUnitPrice.Size = New System.Drawing.Size(704, 206)
      Me.tpUnitPrice.TabIndex = 1
      Me.tpUnitPrice.Text = "ตัวช่วยค่าวัสดุ"
      '
      'grbUnitPrice
      '
      Me.grbUnitPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbUnitPrice.Controls.Add(Me.txtMonthPeriod)
      Me.grbUnitPrice.Controls.Add(Me.lblCurrentPrice)
      Me.grbUnitPrice.Controls.Add(Me.txtCurrentPrice)
      Me.grbUnitPrice.Controls.Add(Me.btnApplyLCIUnitPrice)
      Me.grbUnitPrice.Controls.Add(Me.tgLCIUnitPrice)
      Me.grbUnitPrice.Controls.Add(Me.lblBaht2)
      Me.grbUnitPrice.Controls.Add(Me.lblMonth)
      Me.grbUnitPrice.Controls.Add(Me.lblMonthPeriod)
      Me.grbUnitPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbUnitPrice.Location = New System.Drawing.Point(8, 0)
      Me.grbUnitPrice.Name = "grbUnitPrice"
      Me.grbUnitPrice.Size = New System.Drawing.Size(376, 200)
      Me.grbUnitPrice.TabIndex = 0
      Me.grbUnitPrice.TabStop = False
      Me.grbUnitPrice.Text = "Unit Price Advice"
      '
      'txtMonthPeriod
      '
      Me.txtMonthPeriod.Location = New System.Drawing.Point(288, 16)
      Me.txtMonthPeriod.Name = "txtMonthPeriod"
      Me.txtMonthPeriod.Size = New System.Drawing.Size(48, 20)
      Me.txtMonthPeriod.TabIndex = 5
      '
      'lblCurrentPrice
      '
      Me.lblCurrentPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrentPrice.ForeColor = System.Drawing.Color.Black
      Me.lblCurrentPrice.Location = New System.Drawing.Point(8, 16)
      Me.lblCurrentPrice.Name = "lblCurrentPrice"
      Me.lblCurrentPrice.Size = New System.Drawing.Size(80, 18)
      Me.lblCurrentPrice.TabIndex = 0
      Me.lblCurrentPrice.Text = "Current Price:"
      Me.lblCurrentPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCurrentPrice
      '
      Me.Validator.SetDataType(Me.txtCurrentPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCurrentPrice, "")
      Me.txtCurrentPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCurrentPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCurrentPrice, System.Drawing.Color.Empty)
      Me.txtCurrentPrice.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMinValue(Me.txtCurrentPrice, "")
      Me.txtCurrentPrice.Name = "txtCurrentPrice"
      Me.txtCurrentPrice.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCurrentPrice, "")
      Me.Validator.SetRequired(Me.txtCurrentPrice, False)
      Me.txtCurrentPrice.Size = New System.Drawing.Size(80, 22)
      Me.txtCurrentPrice.TabIndex = 1
      Me.txtCurrentPrice.TabStop = False
      Me.txtCurrentPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnApplyLCIUnitPrice
      '
      Me.btnApplyLCIUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApplyLCIUnitPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApplyLCIUnitPrice.Location = New System.Drawing.Point(296, 176)
      Me.btnApplyLCIUnitPrice.Name = "btnApplyLCIUnitPrice"
      Me.btnApplyLCIUnitPrice.Size = New System.Drawing.Size(72, 23)
      Me.btnApplyLCIUnitPrice.TabIndex = 0
      Me.btnApplyLCIUnitPrice.TabStop = False
      Me.btnApplyLCIUnitPrice.Text = "Replace"
      '
      'tgLCIUnitPrice
      '
      Me.tgLCIUnitPrice.AllowNew = False
      Me.tgLCIUnitPrice.AllowSorting = False
      Me.tgLCIUnitPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tgLCIUnitPrice.AutoColumnResize = True
      Me.tgLCIUnitPrice.CaptionVisible = False
      Me.tgLCIUnitPrice.Cellchanged = False
      Me.tgLCIUnitPrice.DataMember = ""
      Me.tgLCIUnitPrice.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgLCIUnitPrice.Location = New System.Drawing.Point(8, 48)
      Me.tgLCIUnitPrice.Name = "tgLCIUnitPrice"
      Me.tgLCIUnitPrice.Size = New System.Drawing.Size(360, 120)
      Me.tgLCIUnitPrice.SortingArrowColor = System.Drawing.Color.Red
      Me.tgLCIUnitPrice.TabIndex = 4
      Me.tgLCIUnitPrice.TreeManager = Nothing
      '
      'lblBaht2
      '
      Me.lblBaht2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht2.ForeColor = System.Drawing.Color.Black
      Me.lblBaht2.Location = New System.Drawing.Point(172, 16)
      Me.lblBaht2.Name = "lblBaht2"
      Me.lblBaht2.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht2.TabIndex = 2
      Me.lblBaht2.Text = "บาท"
      Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMonth
      '
      Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMonth.ForeColor = System.Drawing.Color.Black
      Me.lblMonth.Location = New System.Drawing.Point(336, 16)
      Me.lblMonth.Name = "lblMonth"
      Me.lblMonth.Size = New System.Drawing.Size(32, 18)
      Me.lblMonth.TabIndex = 2
      Me.lblMonth.Text = "เดือน"
      Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMonthPeriod
      '
      Me.lblMonthPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMonthPeriod.ForeColor = System.Drawing.Color.Black
      Me.lblMonthPeriod.Location = New System.Drawing.Point(216, 16)
      Me.lblMonthPeriod.Name = "lblMonthPeriod"
      Me.lblMonthPeriod.Size = New System.Drawing.Size(72, 18)
      Me.lblMonthPeriod.TabIndex = 2
      Me.lblMonthPeriod.Text = "ซื้อจริงในช่วง:"
      Me.lblMonthPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSupplier
      '
      Me.grbSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSupplier.Controls.Add(Me.tgLCISupplier)
      Me.grbSupplier.Controls.Add(Me.btnSupplierDetail)
      Me.grbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSupplier.Location = New System.Drawing.Point(384, 0)
      Me.grbSupplier.Name = "grbSupplier"
      Me.grbSupplier.Size = New System.Drawing.Size(320, 200)
      Me.grbSupplier.TabIndex = 1
      Me.grbSupplier.TabStop = False
      Me.grbSupplier.Text = "Supplier"
      '
      'tgLCISupplier
      '
      Me.tgLCISupplier.AllowNew = False
      Me.tgLCISupplier.AllowSorting = False
      Me.tgLCISupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgLCISupplier.AutoColumnResize = True
      Me.tgLCISupplier.CaptionVisible = False
      Me.tgLCISupplier.Cellchanged = False
      Me.tgLCISupplier.DataMember = ""
      Me.tgLCISupplier.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgLCISupplier.Location = New System.Drawing.Point(8, 16)
      Me.tgLCISupplier.Name = "tgLCISupplier"
      Me.tgLCISupplier.Size = New System.Drawing.Size(304, 160)
      Me.tgLCISupplier.SortingArrowColor = System.Drawing.Color.Red
      Me.tgLCISupplier.TabIndex = 0
      Me.tgLCISupplier.TreeManager = Nothing
      '
      'btnSupplierDetail
      '
      Me.btnSupplierDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSupplierDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDetail.Location = New System.Drawing.Point(240, 176)
      Me.btnSupplierDetail.Name = "btnSupplierDetail"
      Me.btnSupplierDetail.Size = New System.Drawing.Size(72, 23)
      Me.btnSupplierDetail.TabIndex = 2
      Me.btnSupplierDetail.TabStop = False
      Me.btnSupplierDetail.Text = "Detail"
      '
      'tpLaborEq
      '
      Me.tpLaborEq.Controls.Add(Me.grbEquip)
      Me.tpLaborEq.Controls.Add(Me.grbLabor)
      Me.tpLaborEq.Location = New System.Drawing.Point(4, 22)
      Me.tpLaborEq.Name = "tpLaborEq"
      Me.tpLaborEq.Size = New System.Drawing.Size(704, 206)
      Me.tpLaborEq.TabIndex = 2
      Me.tpLaborEq.Text = "ตัวช่วยค่าแรงและเครื่องจักร"
      '
      'grbEquip
      '
      Me.grbEquip.Controls.Add(Me.lblCurrentEq)
      Me.grbEquip.Controls.Add(Me.txtCurrentEq)
      Me.grbEquip.Controls.Add(Me.lblCurrenEqUnit)
      Me.grbEquip.Controls.Add(Me.tgLCIEqCost)
      Me.grbEquip.Controls.Add(Me.btnApplyEqCost)
      Me.grbEquip.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbEquip.Location = New System.Drawing.Point(352, 0)
      Me.grbEquip.Name = "grbEquip"
      Me.grbEquip.Size = New System.Drawing.Size(352, 200)
      Me.grbEquip.TabIndex = 2
      Me.grbEquip.TabStop = False
      Me.grbEquip.Text = "ค่าเครื่องจักร"
      '
      'lblCurrentEq
      '
      Me.lblCurrentEq.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrentEq.ForeColor = System.Drawing.Color.Black
      Me.lblCurrentEq.Location = New System.Drawing.Point(8, 18)
      Me.lblCurrentEq.Name = "lblCurrentEq"
      Me.lblCurrentEq.Size = New System.Drawing.Size(80, 18)
      Me.lblCurrentEq.TabIndex = 0
      Me.lblCurrentEq.Text = "Current Price:"
      Me.lblCurrentEq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCurrentEq
      '
      Me.Validator.SetDataType(Me.txtCurrentEq, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCurrentEq, "")
      Me.txtCurrentEq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCurrentEq, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCurrentEq, System.Drawing.Color.Empty)
      Me.txtCurrentEq.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMinValue(Me.txtCurrentEq, "")
      Me.txtCurrentEq.Name = "txtCurrentEq"
      Me.txtCurrentEq.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCurrentEq, "")
      Me.Validator.SetRequired(Me.txtCurrentEq, False)
      Me.txtCurrentEq.Size = New System.Drawing.Size(128, 22)
      Me.txtCurrentEq.TabIndex = 1
      Me.txtCurrentEq.TabStop = False
      Me.txtCurrentEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrenEqUnit
      '
      Me.lblCurrenEqUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrenEqUnit.ForeColor = System.Drawing.Color.Black
      Me.lblCurrenEqUnit.Location = New System.Drawing.Point(216, 18)
      Me.lblCurrenEqUnit.Name = "lblCurrenEqUnit"
      Me.lblCurrenEqUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblCurrenEqUnit.TabIndex = 2
      Me.lblCurrenEqUnit.Text = "บาท"
      Me.lblCurrenEqUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tgLCIEqCost
      '
      Me.tgLCIEqCost.AllowNew = False
      Me.tgLCIEqCost.AllowSorting = False
      Me.tgLCIEqCost.AutoColumnResize = True
      Me.tgLCIEqCost.CaptionVisible = False
      Me.tgLCIEqCost.Cellchanged = False
      Me.tgLCIEqCost.DataMember = ""
      Me.tgLCIEqCost.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgLCIEqCost.Location = New System.Drawing.Point(8, 40)
      Me.tgLCIEqCost.Name = "tgLCIEqCost"
      Me.tgLCIEqCost.Size = New System.Drawing.Size(336, 136)
      Me.tgLCIEqCost.SortingArrowColor = System.Drawing.Color.Red
      Me.tgLCIEqCost.TabIndex = 3
      Me.tgLCIEqCost.TreeManager = Nothing
      '
      'btnApplyEqCost
      '
      Me.btnApplyEqCost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApplyEqCost.Location = New System.Drawing.Point(272, 176)
      Me.btnApplyEqCost.Name = "btnApplyEqCost"
      Me.btnApplyEqCost.Size = New System.Drawing.Size(72, 23)
      Me.btnApplyEqCost.TabIndex = 4
      Me.btnApplyEqCost.TabStop = False
      Me.btnApplyEqCost.Text = "Replace"
      '
      'grbLabor
      '
      Me.grbLabor.Controls.Add(Me.lblCurrentLabor)
      Me.grbLabor.Controls.Add(Me.txtCurrentLabor)
      Me.grbLabor.Controls.Add(Me.lblCurrentLaborUnit)
      Me.grbLabor.Controls.Add(Me.btnApplyLaborUnitPrice)
      Me.grbLabor.Controls.Add(Me.tgLCILabor)
      Me.grbLabor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLabor.Location = New System.Drawing.Point(0, 0)
      Me.grbLabor.Name = "grbLabor"
      Me.grbLabor.Size = New System.Drawing.Size(352, 200)
      Me.grbLabor.TabIndex = 1
      Me.grbLabor.TabStop = False
      Me.grbLabor.Text = "ค่าแรง"
      '
      'lblCurrentLabor
      '
      Me.lblCurrentLabor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrentLabor.ForeColor = System.Drawing.Color.Black
      Me.lblCurrentLabor.Location = New System.Drawing.Point(16, 18)
      Me.lblCurrentLabor.Name = "lblCurrentLabor"
      Me.lblCurrentLabor.Size = New System.Drawing.Size(80, 18)
      Me.lblCurrentLabor.TabIndex = 0
      Me.lblCurrentLabor.Text = "Current Price:"
      Me.lblCurrentLabor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCurrentLabor
      '
      Me.Validator.SetDataType(Me.txtCurrentLabor, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCurrentLabor, "")
      Me.txtCurrentLabor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCurrentLabor, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCurrentLabor, System.Drawing.Color.Empty)
      Me.txtCurrentLabor.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtCurrentLabor, "")
      Me.txtCurrentLabor.Name = "txtCurrentLabor"
      Me.txtCurrentLabor.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCurrentLabor, "")
      Me.Validator.SetRequired(Me.txtCurrentLabor, False)
      Me.txtCurrentLabor.Size = New System.Drawing.Size(128, 22)
      Me.txtCurrentLabor.TabIndex = 1
      Me.txtCurrentLabor.TabStop = False
      Me.txtCurrentLabor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrentLaborUnit
      '
      Me.lblCurrentLaborUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrentLaborUnit.ForeColor = System.Drawing.Color.Black
      Me.lblCurrentLaborUnit.Location = New System.Drawing.Point(224, 18)
      Me.lblCurrentLaborUnit.Name = "lblCurrentLaborUnit"
      Me.lblCurrentLaborUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblCurrentLaborUnit.TabIndex = 2
      Me.lblCurrentLaborUnit.Text = "บาท"
      Me.lblCurrentLaborUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'btnApplyLaborUnitPrice
      '
      Me.btnApplyLaborUnitPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApplyLaborUnitPrice.Location = New System.Drawing.Point(272, 176)
      Me.btnApplyLaborUnitPrice.Name = "btnApplyLaborUnitPrice"
      Me.btnApplyLaborUnitPrice.Size = New System.Drawing.Size(72, 23)
      Me.btnApplyLaborUnitPrice.TabIndex = 4
      Me.btnApplyLaborUnitPrice.TabStop = False
      Me.btnApplyLaborUnitPrice.Text = "Replace"
      '
      'tgLCILabor
      '
      Me.tgLCILabor.AllowNew = False
      Me.tgLCILabor.AllowSorting = False
      Me.tgLCILabor.AutoColumnResize = True
      Me.tgLCILabor.CaptionVisible = False
      Me.tgLCILabor.Cellchanged = False
      Me.tgLCILabor.DataMember = ""
      Me.tgLCILabor.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgLCILabor.Location = New System.Drawing.Point(8, 40)
      Me.tgLCILabor.Name = "tgLCILabor"
      Me.tgLCILabor.Size = New System.Drawing.Size(336, 136)
      Me.tgLCILabor.SortingArrowColor = System.Drawing.Color.Red
      Me.tgLCILabor.TabIndex = 3
      Me.tgLCILabor.TreeManager = Nothing
      '
      'lblBOQCode
      '
      Me.lblBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBOQCode.ForeColor = System.Drawing.Color.Black
      Me.lblBOQCode.Location = New System.Drawing.Point(8, 0)
      Me.lblBOQCode.Name = "lblBOQCode"
      Me.lblBOQCode.Size = New System.Drawing.Size(88, 18)
      Me.lblBOQCode.TabIndex = 0
      Me.lblBOQCode.Text = "รหัสBOQ:"
      Me.lblBOQCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBOQCode
      '
      Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBOQCode, "")
      Me.txtBOQCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.txtBOQCode.Location = New System.Drawing.Point(96, 0)
      Me.Validator.SetMinValue(Me.txtBOQCode, "")
      Me.txtBOQCode.Name = "txtBOQCode"
      Me.txtBOQCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
      Me.Validator.SetRequired(Me.txtBOQCode, False)
      Me.txtBOQCode.Size = New System.Drawing.Size(96, 22)
      Me.txtBOQCode.TabIndex = 1
      Me.txtBOQCode.TabStop = False
      '
      'txtProjectName
      '
      Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectName, "")
      Me.txtProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.txtProjectName.Location = New System.Drawing.Point(192, 24)
      Me.Validator.SetMinValue(Me.txtProjectName, "")
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectName, "")
      Me.Validator.SetRequired(Me.txtProjectName, False)
      Me.txtProjectName.Size = New System.Drawing.Size(376, 22)
      Me.txtProjectName.TabIndex = 4
      Me.txtProjectName.TabStop = False
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.Color.Black
      Me.lblProject.Location = New System.Drawing.Point(16, 24)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(80, 18)
      Me.lblProject.TabIndex = 2
      Me.lblProject.Text = "โครงการประมูล:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProjectCode
      '
      Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectCode, "")
      Me.txtProjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.txtProjectCode.Location = New System.Drawing.Point(96, 24)
      Me.Validator.SetMinValue(Me.txtProjectCode, "")
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.txtProjectCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
      Me.Validator.SetRequired(Me.txtProjectCode, False)
      Me.txtProjectCode.Size = New System.Drawing.Size(96, 22)
      Me.txtProjectCode.TabIndex = 3
      Me.txtProjectCode.TabStop = False
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = False
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 88)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(704, 232)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(248, 64)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 6
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(272, 64)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 7
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
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
      'grbBOQType
      '
      Me.grbBOQType.Controls.Add(Me.chkMat)
      Me.grbBOQType.Controls.Add(Me.chkLabor)
      Me.grbBOQType.Controls.Add(Me.chkEquip)
      Me.grbBOQType.Enabled = False
      Me.grbBOQType.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBOQType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBOQType.Location = New System.Drawing.Point(576, 8)
      Me.grbBOQType.Name = "grbBOQType"
      Me.grbBOQType.Size = New System.Drawing.Size(128, 72)
      Me.grbBOQType.TabIndex = 13
      Me.grbBOQType.TabStop = False
      Me.grbBOQType.Text = "ข้อมูลรายการ BOQ"
      '
      'chkMat
      '
      Me.chkMat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkMat.Location = New System.Drawing.Point(8, 16)
      Me.chkMat.Name = "chkMat"
      Me.chkMat.Size = New System.Drawing.Size(104, 16)
      Me.chkMat.TabIndex = 0
      Me.chkMat.TabStop = False
      Me.chkMat.Text = "ค่าวัสดุ"
      '
      'chkLabor
      '
      Me.chkLabor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkLabor.Location = New System.Drawing.Point(8, 33)
      Me.chkLabor.Name = "chkLabor"
      Me.chkLabor.Size = New System.Drawing.Size(104, 16)
      Me.chkLabor.TabIndex = 1
      Me.chkLabor.TabStop = False
      Me.chkLabor.Text = "ค่าแรง"
      '
      'chkEquip
      '
      Me.chkEquip.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEquip.Location = New System.Drawing.Point(8, 46)
      Me.chkEquip.Name = "chkEquip"
      Me.chkEquip.Size = New System.Drawing.Size(104, 24)
      Me.chkEquip.TabIndex = 2
      Me.chkEquip.TabStop = False
      Me.chkEquip.Text = "ค่าเครื่องจักร"
      '
      'ibtnZoomChart
      '
      Me.ibtnZoomChart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomChart.Location = New System.Drawing.Point(312, 64)
      Me.ibtnZoomChart.Name = "ibtnZoomChart"
      Me.ibtnZoomChart.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomChart.TabIndex = 14
      Me.ibtnZoomChart.TabStop = False
      Me.ibtnZoomChart.ThemedImage = CType(resources.GetObject("ibtnZoomChart.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbSummarize
      '
      Me.grbSummarize.Controls.Add(Me.lblLevel)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomOut)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomIn)
      Me.grbSummarize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummarize.Location = New System.Drawing.Point(384, 48)
      Me.grbSummarize.Name = "grbSummarize"
      Me.grbSummarize.Size = New System.Drawing.Size(168, 40)
      Me.grbSummarize.TabIndex = 15
      Me.grbSummarize.TabStop = False
      Me.grbSummarize.Text = "Summarize"
      '
      'lblLevel
      '
      Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel.Location = New System.Drawing.Point(64, 16)
      Me.lblLevel.Name = "lblLevel"
      Me.lblLevel.Size = New System.Drawing.Size(40, 23)
      Me.lblLevel.TabIndex = 13
      Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomOut.Location = New System.Drawing.Point(16, 16)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 12
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomIn.Location = New System.Drawing.Point(40, 16)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 11
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnSaveAsExcel
      '
      Me.ibtnSaveAsExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSaveAsExcel.Location = New System.Drawing.Point(344, 64)
      Me.ibtnSaveAsExcel.Name = "ibtnSaveAsExcel"
      Me.ibtnSaveAsExcel.Size = New System.Drawing.Size(24, 24)
      Me.ibtnSaveAsExcel.TabIndex = 16
      Me.ibtnSaveAsExcel.TabStop = False
      Me.ibtnSaveAsExcel.ThemedImage = CType(resources.GetObject("ibtnSaveAsExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnLockBoq
      '
      Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
      Me.btnLockBoq.Location = New System.Drawing.Point(12, 24)
      Me.btnLockBoq.Name = "btnLockBoq"
      Me.btnLockBoq.Size = New System.Drawing.Size(39, 44)
      Me.btnLockBoq.TabIndex = 17
      Me.btnLockBoq.UseVisualStyleBackColor = True
      '
      'ItemListing
      '
      Me.Controls.Add(Me.btnLockBoq)
      Me.Controls.Add(Me.ibtnSaveAsExcel)
      Me.Controls.Add(Me.grbSummarize)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.ibtnZoomChart)
      Me.Controls.Add(Me.grbBOQType)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblBOQCode)
      Me.Controls.Add(Me.txtBOQCode)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.lblProject)
      Me.Controls.Add(Me.txtProjectCode)
      Me.Controls.Add(Me.tbDetail)
      Me.Controls.Add(Me.lblWorkBreakdown)
      Me.Name = "ItemListing"
      Me.Size = New System.Drawing.Size(720, 552)
      Me.grbPrice.ResumeLayout(False)
      Me.grbPrice.PerformLayout()
      Me.tbDetail.ResumeLayout(False)
      Me.tpItemDetail.ResumeLayout(False)
      Me.tpItemDetail.PerformLayout()
      Me.tpUnitPrice.ResumeLayout(False)
      Me.grbUnitPrice.ResumeLayout(False)
      Me.grbUnitPrice.PerformLayout()
      CType(Me.txtMonthPeriod, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgLCIUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSupplier.ResumeLayout(False)
      CType(Me.tgLCISupplier, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpLaborEq.ResumeLayout(False)
      Me.grbEquip.ResumeLayout(False)
      Me.grbEquip.PerformLayout()
      CType(Me.tgLCIEqCost, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbLabor.ResumeLayout(False)
      Me.grbLabor.PerformLayout()
      CType(Me.tgLCILabor, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbBOQType.ResumeLayout(False)
      Me.grbSummarize.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As BOQ
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_oldRow As TreeRow = Nothing
    Private m_wbs As WBS
    Private m_item As BoqItem

    Private m_tableInitialized As Boolean

    Private m_bestPriceManager As TreeManager
    Private m_selectedPrice As Object

    Private m_supplierManager As TreeManager
    Private m_selectedSupplier As Object

    Private m_eqCostManager As TreeManager
    Private m_selectedEqCost As Object

    Private m_laborCostManager As TreeManager
    Private m_seletedLaborCost As Object
#End Region

#Region "Constructors"
    Private Sub Unwire()
      Dim dt As TreeTable = m_treeManager.TreeTable
      RemoveHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      RemoveHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      RemoveHandler dt.RowDeleted, AddressOf ItemDelete
      RemoveHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
    End Sub
    Private Sub Wire()
      Dim dt As TreeTable = m_treeManager.TreeTable
      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
      Me.Validator.DataTable = dt
    End Sub
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
      If TypeOf e.Row.Tag Is WBS Then
        CType(e.Row.Tag, WBS).State = e.Row.State
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      ElseIf TypeOf e.Row.Tag Is Integer Then
        Me.m_entity.SetState(CInt(e.Row.Tag), e.Row.State)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = BOQ.GetSchemaTable()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      Wire()

      Dim bp As TreeTable = LCIItem.GetBestPriceSchema
      m_bestPriceManager = New TreeManager(bp, Me.tgLCIUnitPrice)
      m_bestPriceManager.AllowSorting = False
      m_bestPriceManager.AllowDelete = False

      Dim spt As TreeTable = LCISupplierCostLink.GetSchemaTable
      m_supplierManager = New TreeManager(spt, Me.tgLCISupplier)
      m_supplierManager.AllowDelete = False
      m_supplierManager.AllowSorting = False

      Dim eqt As TreeTable = LCIEquipmentCostLink.GetSchemaTable
      m_eqCostManager = New TreeManager(eqt, Me.tgLCIEqCost)
      m_eqCostManager.AllowDelete = False
      m_eqCostManager.AllowSorting = False

      Dim lbt As TreeTable = LCILaborCostLink.GetSchemaTable
      m_laborCostManager = New TreeManager(lbt, Me.tgLCILabor)
      m_laborCostManager.AllowDelete = False
      m_laborCostManager.AllowSorting = False

      EventWiring()
    End Sub
#End Region

#Region "Style"
    Private Function CreateLaborCostStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "LaborCost"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatLabDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Name"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csName.ReadOnly = True

      Dim csCost As New TreeTextColumn(1, False)
      csCost.MappingName = "Cost"
      csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatLabDetail.CostHeaderText}")
      csCost.NullText = ""
      csCost.DataAlignment = HorizontalAlignment.Right
      csCost.Format = "#,###.##"
      csCost.TextBox.Name = "Cost"
      csCost.ReadOnly = True
      AddHandler csCost.CheckCellHilighted, AddressOf SetLaborHilightValues

      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csCost)

      Return dst
    End Function
    Public Sub SetLaborHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If m_item Is Nothing Then
        Return
      End If
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_laborCostManager.Treetable.Rows
        If Not row.IsNull("Cost") AndAlso IsNumeric(row("Cost")) Then
          If m_item.ULC = CDec(row("Cost")) Then
            If e.Column = 1 And e.Row = i Then
              e.HilightValue = True
            End If
          End If
        End If
        i += 1
      Next
    End Sub
    Private Function CreateEqCostStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EquipmentCost"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Name"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csName.ReadOnly = True

      Dim csCost As New TreeTextColumn(1, False)
      csCost.MappingName = "Cost"
      csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.CostHeaderText}")
      csCost.NullText = ""
      csCost.DataAlignment = HorizontalAlignment.Right
      csCost.Format = "#,###.##"
      csCost.TextBox.Name = "Cost"
      csCost.ReadOnly = True
      AddHandler csCost.CheckCellHilighted, AddressOf SetEqHilightValues

      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csCost)

      Return dst
    End Function
    Public Sub SetEqHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If m_item Is Nothing Then
        Return
      End If
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_eqCostManager.Treetable.Rows
        If Not row.IsNull("Cost") AndAlso IsNumeric(row("Cost")) Then
          If m_item.UEC = CDec(row("Cost")) Then
            If e.Column = 1 And e.Row = i Then
              e.HilightValue = True
            End If
          End If
        End If
        i += 1
      Next
    End Sub
    Private Function CreateSupplierStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "SupplierCost"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Name"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csName.ReadOnly = True

      Dim csPhone As New TreeTextColumn
      csPhone.MappingName = "Phone"
      csPhone.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.PhoneHeaderText}")
      csPhone.NullText = ""
      csPhone.Width = 80
      csPhone.TextBox.Name = "Phone"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csPhone.ReadOnly = True

      Dim csCost As New TreeTextColumn
      csCost.MappingName = "lcis_cost"
      csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostHeaderText}")
      csCost.NullText = ""
      csCost.DataAlignment = HorizontalAlignment.Right
      csCost.Format = "#,###.##"
      csCost.TextBox.Name = "lcis_cost"
      csCost.ReadOnly = True

      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csPhone)
      dst.GridColumnStyles.Add(csCost)
      Return dst
    End Function
    Private Function CreateBestPriceStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BestPrice"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


      Dim csType As New TreeTextColumn
      csType.MappingName = "Type"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BestPrice.TypeHeaderText}")
      csType.NullText = ""
      csType.ReadOnly = True

      Dim csAVG As New TreeTextColumn(1, False)
      csAVG.MappingName = "AVG"
      csAVG.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BestPrice.AVGHeaderText}")
      csAVG.NullText = ""
      csAVG.DataAlignment = HorizontalAlignment.Right
      csAVG.Format = "#,###.##"
      csAVG.ReadOnly = True
      AddHandler csAVG.CheckCellHilighted, AddressOf SetHilightValues

      Dim csMax As New TreeTextColumn(2, False)
      csMax.MappingName = "Max"
      csMax.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BestPrice.MaxHeaderText}")
      csMax.NullText = ""
      csMax.DataAlignment = HorizontalAlignment.Right
      csMax.Format = "#,###.##"
      csMax.ReadOnly = True
      AddHandler csMax.CheckCellHilighted, AddressOf SetHilightValues

      Dim csMin As New TreeTextColumn(3, False)
      csMin.MappingName = "Min"
      csMin.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BestPrice.MinHeaderText}")
      csMin.NullText = ""
      csMin.DataAlignment = HorizontalAlignment.Right
      csMin.Format = "#,###.##"
      csMin.ReadOnly = True
      AddHandler csMin.CheckCellHilighted, AddressOf SetHilightValues

      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csAVG)
      dst.GridColumnStyles.Add(csMax)
      dst.GridColumnStyles.Add(csMin)

      Return dst
    End Function
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If m_item Is Nothing Then
        Return
      End If
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_bestPriceManager.Treetable.Rows
        For Each col As DataColumn In Me.m_bestPriceManager.Treetable.Columns
          If col.Ordinal > 0 Then
            If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
              If m_item.UMC = CDec(row(col)) Then
                If e.Column = col.Ordinal And e.Row = i Then
                  e.HilightValue = True
                End If
              End If
            End If
          End If
        Next
        i += 1
      Next
    End Sub
    Private Function GetExcludeString() As String
      If m_entity Is Nothing Then
        Return ""
      End If
      Dim ret As New ArrayList
      If Not m_entity.HasMaterialCost Then
        ret.Add("42")
      End If
      If Not m_entity.HasLaborCost Then
        ret.Add("18")
      End If
      If Not m_entity.HasEquipmentCost Then
        ret.Add("20")
      End If
      If ret.Count = 0 Then
        Return ""
      End If
      Dim retStr As String = ""
      For Each id As String In ret
        retStr &= id & ","
      Next
      If retStr.EndsWith(",") Then
        retStr = retStr.Substring(0, retStr.Length - 1)
      End If
      Return retStr
    End Function
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim includeQtyPerWBS As Boolean = False
      Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
      If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
        includeQtyPerWBS = CBool(icq)
      End If
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"


      Dim csType As DataGridComboColumn
      Dim excludeString As String = GetExcludeString()
      If excludeString.Length > 0 Then
        csType = New DataGridComboColumn("boqi_entityType" _
        , CodeDescription.GetCodeList("boqi_entityType" _
        , "code_value not in (" & excludeString & ")") _
        , "code_description", "code_value")
        csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TypeHeaderText}")
        csType.NullText = String.Empty
      Else
        csType = New DataGridComboColumn("boqi_entityType" _
        , CodeDescription.GetCodeList("boqi_entityType") _
        , "code_description", "code_value")
        csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TypeHeaderText}")
        csType.NullText = String.Empty
      End If
      csType.Width = 55

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"
      csCode.Width = 90

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 360
      csName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.Width = 50

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClick

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "boqi_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.Width = 55
      csQty.ReadOnly = includeQtyPerWBS


      Dim csUMC As New TreeTextColumn
      csUMC.MappingName = "boqi_umc"
      csUMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UMCHeaderText}")
      csUMC.NullText = ""
      csUMC.DataAlignment = HorizontalAlignment.Right
      csUMC.Format = "#,###.##"
      csUMC.TextBox.Name = "boqi_umc"
      csUMC.ReadOnly = Not Me.m_entity.HasMaterialCost
      csUMC.Width = 55

      Dim csTotalMC As New TreeTextColumn
      csTotalMC.MappingName = "TotalMaterialCost"
      csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalMaterialCostHeaderText}")
      csTotalMC.NullText = ""
      csTotalMC.DataAlignment = HorizontalAlignment.Right
      csTotalMC.Format = "#,###.##"
      csTotalMC.TextBox.Name = "TotalMaterialCost"
      csTotalMC.ReadOnly = Not Me.m_entity.HasMaterialCost
      csTotalMC.Width = 55

      Dim csULC As New TreeTextColumn
      csULC.MappingName = "boqi_ulc"
      csULC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.ULCHeaderText}")
      csULC.NullText = ""
      csULC.DataAlignment = HorizontalAlignment.Right
      csULC.Format = "#,###.##"
      csULC.TextBox.Name = "boqi_ulc"
      csULC.ReadOnly = Not Me.m_entity.HasLaborCost
      csULC.Width = 55

      Dim csTotalLC As New TreeTextColumn
      csTotalLC.MappingName = "TotalLaborCost"
      csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalLaborCostHeaderText}")
      csTotalLC.NullText = ""
      csTotalLC.DataAlignment = HorizontalAlignment.Right
      csTotalLC.Format = "#,###.##"
      csTotalLC.TextBox.Name = "TotalLaborCost"
      csTotalLC.ReadOnly = Not Me.m_entity.HasLaborCost
      csTotalLC.Width = 55

      Dim csUEC As New TreeTextColumn
      csUEC.MappingName = "boqi_uec"
      csUEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UECHeaderText}")
      csUEC.NullText = ""
      csUEC.DataAlignment = HorizontalAlignment.Right
      csUEC.Format = "#,###.##"
      csUEC.TextBox.Name = "boqi_uec"
      csUEC.ReadOnly = Not Me.m_entity.HasEquipmentCost
      csUEC.Width = 55

      Dim csTotalEC As New TreeTextColumn
      csTotalEC.MappingName = "TotalEquipmentCost"
      csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalEquipmentCostHeaderText}")
      csTotalEC.NullText = ""
      csTotalEC.DataAlignment = HorizontalAlignment.Right
      csTotalEC.Format = "#,###.##"
      csTotalEC.TextBox.Name = "TotalEquipmentCost"
      csTotalEC.ReadOnly = Not Me.m_entity.HasEquipmentCost
      csTotalEC.Width = 55

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "Total"
      csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.TextBox.Name = "Total"
      csTotal.ReadOnly = True
      csTotal.Width = 100

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "boqi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "boqi_note"

      '-------------------------------ธวัชชัย-----------------------------
      Dim csQtyPerWBS As New TreeTextColumn
      csQtyPerWBS.MappingName = "QtyPerWBS"
      csQtyPerWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyPerWBSHeaderText}")
      csQtyPerWBS.NullText = ""
      csQtyPerWBS.DataAlignment = HorizontalAlignment.Right
      csQtyPerWBS.Format = "#,###.##"
      csQtyPerWBS.TextBox.Name = "QtyPerWBS"
      csQtyPerWBS.Width = 100

      Dim csWBSQty As New TreeTextColumn
      csWBSQty.MappingName = "WBSQty"
      csWBSQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.WBSQtyHeaderText}")
      csWBSQty.NullText = ""
      csWBSQty.DataAlignment = HorizontalAlignment.Right
      csWBSQty.Format = "#,###.##"
      csWBSQty.TextBox.Name = "WBSQty"
      csWBSQty.Width = 100

      Dim csTotalPerWBS As New TreeTextColumn
      csTotalPerWBS.MappingName = "TotalPerWBS"
      csTotalPerWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalPerWBSHeaderText}")
      csTotalPerWBS.NullText = ""
      csTotalPerWBS.DataAlignment = HorizontalAlignment.Right
      csTotalPerWBS.Format = "#,###.##"
      csTotalPerWBS.TextBox.Name = "TotalPerWBS"
      csTotalPerWBS.ReadOnly = True
      csTotalPerWBS.Width = 100
      '-------------------------------End ธวัชชัย-----------------------------

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)

      If includeQtyPerWBS Then
        dst.GridColumnStyles.Add(csQtyPerWBS)
        'dst.GridColumnStyles.Add(csWBSQty)
      End If

      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUMC)
      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csULC)
      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csUEC)
      dst.GridColumnStyles.Add(csTotalEC)

      If includeQtyPerWBS Then
        dst.GridColumnStyles.Add(csTotalPerWBS)
      End If

      dst.GridColumnStyles.Add(csTotal)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        Me.ItemButtonClick(e)
      ElseIf e.Column = 5 Then
        Me.UnitButtonClick(e)
      End If
    End Sub
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      Me.m_treeManager.Treetable.AcceptChanges()
      If Not Me.m_tableInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Tag Is Nothing Then
        Return
      End If
      If TypeOf CType(e.Row, TreeRow).Tag Is WBS Then
        Me.m_treeManager.Treetable.AcceptChanges()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        Me.tgItem.RefreshHeights()
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        UpdateAmount(e)
        UpdateItem()
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.tgItem.RefreshHeights()
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      If m_item Is Nothing Then
        Return
      End If

    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.m_tableInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Tag Is Nothing Then
        Return
      End If
      
      If TypeOf CType(e.Row, TreeRow).Tag Is WBS Then
        If e.Column.ColumnName.ToLower <> "qtyperwbs" Then 'If e.Column.ColumnName.ToLower <> "wbsqty" Then
          If e.Column.ColumnName.ToLower <> "unit" Then
            If e.Column.ColumnName.ToLower <> "boqi_linenumber" Then
              e.ProposedValue = e.Row(e.Column)
            End If
            Return
          End If
        End If
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "boqi_itemname"
            SetName(e)
          Case "unit"
            SetUnitValue(e)
          Case "boqi_qty"
            SetQty(e)
          Case "qtyperwbs"
            SetQtyPerWBS(e)
          Case "wbsqty"
            SetWBSQty(e)
          Case "boqi_umc", "boqi_ulc", "boqi_uec"
            SetUnitPrice(e)
          Case "totalmaterialcost", "totallaborcost", "totalequipmentcost"
            SetTotalUnitPrice(e)
          Case "boqi_entitytype"
            SetEntityType(e)
          Case "boqi_note"
            SetNote(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      'Dim code As Object = e.Row("code")
      'Dim boqi_itemname As Object = e.Row("boqi_itemname")
      'Dim boqi_entitytype As Object = e.Row("boqi_entitytype")
      'Dim accountcode As Object = e.Row("accountcode")
      'Dim unit As Object = e.Row("unit")
      'Dim boqi_unitprice As Object = e.Row("boqi_unitprice")
      'Dim boqi_qty As Object = e.Row("boqi_qty")

      'Select Case e.Column.ColumnName.ToLower
      '    Case "code"
      '        code = e.ProposedValue
      '    Case "boqi_itemname"
      '        boqi_itemname = e.ProposedValue
      '    Case "boqi_entitytype"
      '        boqi_entitytype = e.ProposedValue
      '    Case "accountcode"
      '        accountcode = e.ProposedValue
      '    Case "unit"
      '        unit = e.ProposedValue
      '    Case "boqi_unitprice"
      '        boqi_unitprice = e.ProposedValue
      '    Case "boqi_qty"
      '        boqi_qty = e.ProposedValue
      '    Case Else
      '        Return
      'End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(boqi_entitytype) Then
      '    isBlankRow = True
      'End If

      'If Not isBlankRow Then
      '    Select Case CInt(boqi_entitytype)
      '        Case 0 'blank item
      '            If IsDBNull(boqi_itemname) OrElse boqi_itemname.ToString.Length = 0 Then
      '                e.Row.SetColumnError("boqi_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_itemname", "")
      '            End If
      '            If IsDBNull(boqi_qty) OrElse CDec(boqi_qty) <= 0 Then
      '                e.Row.SetColumnError("boqi_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_qty", "")
      '            End If
      '            If IsDBNull(boqi_unitprice) OrElse CDec(boqi_unitprice) <= 0 Then
      '                e.Row.SetColumnError("boqi_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_unitprice", "")
      '            End If
      '            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
      '                e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
      '            Else
      '                e.Row.SetColumnError("accountcode", "")
      '            End If
      '            e.Row.SetColumnError("code", "")
      '        Case 18 'Labor
      '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
      '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
      '            Else
      '                e.Row.SetColumnError("code", "")
      '            End If
      '            If IsDBNull(boqi_itemname) OrElse boqi_itemname.ToString.Length = 0 Then
      '                e.Row.SetColumnError("boqi_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_itemname", "")
      '            End If
      '            If IsDBNull(boqi_qty) OrElse CDec(boqi_qty) <= 0 Then
      '                e.Row.SetColumnError("boqi_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_qty", "")
      '            End If
      '            If IsDBNull(boqi_unitprice) OrElse CDec(boqi_unitprice) <= 0 Then
      '                e.Row.SetColumnError("boqi_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_unitprice", "")
      '            End If
      '            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
      '                e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
      '            Else
      '                e.Row.SetColumnError("accountcode", "")
      '            End If
      '        Case 20 'Equipment
      '            If IsDBNull(boqi_itemname) OrElse boqi_itemname.ToString.Length = 0 Then
      '                e.Row.SetColumnError("boqi_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_itemname", "")
      '            End If
      '            If IsDBNull(boqi_qty) OrElse CDec(boqi_qty) <= 0 Then
      '                e.Row.SetColumnError("boqi_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_qty", "")
      '            End If
      '            If IsDBNull(boqi_unitprice) OrElse CDec(boqi_unitprice) <= 0 Then
      '                e.Row.SetColumnError("boqi_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_unitprice", "")
      '            End If
      '            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
      '                e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
      '            Else
      '                e.Row.SetColumnError("accountcode", "")
      '            End If
      '            e.Row.SetColumnError("code", "")
      '        Case 42 'LCI
      '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
      '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
      '            Else
      '                e.Row.SetColumnError("code", "")
      '            End If
      '            If IsDBNull(boqi_itemname) OrElse boqi_itemname.ToString.Length = 0 Then
      '                e.Row.SetColumnError("boqi_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_itemname", "")
      '            End If
      '            If IsDBNull(boqi_qty) OrElse CDec(boqi_qty) <= 0 Then
      '                e.Row.SetColumnError("boqi_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_qty", "")
      '            End If
      '            If IsDBNull(boqi_unitprice) OrElse CDec(boqi_unitprice) <= 0 Then
      '                e.Row.SetColumnError("boqi_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
      '            Else
      '                e.Row.SetColumnError("boqi_unitprice", "")
      '            End If
      '            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
      '                e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
      '            Else
      '                e.Row.SetColumnError("accountcode", "")
      '            End If
      '        Case Else
      '            Return
      '    End Select
      'End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("boqi_entitytype") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetQtyPerWBS(ByVal e As DataColumnChangeEventArgs)
      If TypeOf CType(e.Row, TreeRow).Tag Is WBS Then
        SetWBSQty(e)
        Return
      End If
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0, 42, 18, 20 'Blank/LCI/Labor/EqCost
          'ผ่าน
          m_item.QtyPerWBS = value
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      e.Row("boqi_qty") = Configuration.FormatToString(m_item.Qty, DigitConfig.UnitPrice)
      e.Row("boqi_umc") = Configuration.FormatToString(m_item.UMC, DigitConfig.UnitPrice)
      e.Row("TotalMaterialCost") = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      e.Row("boqi_ulc") = Configuration.FormatToString(m_item.ULC, DigitConfig.UnitPrice)
      e.Row("TotalLaborCost") = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      e.Row("boqi_uec") = Configuration.FormatToString(m_item.UEC, DigitConfig.UnitPrice)
      e.Row("TotalEquipmentCost") = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      e.Row("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      e.Row("TotalPerWBS") = Configuration.FormatToString(m_item.TotalPerWBS, DigitConfig.Price)
      m_updating = False
    End Sub
    Public Sub SetWBSQty(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_wbs Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If

      m_wbs.Qty = value
      TreeRow.TraverseRow(CType(e.Row, TreeRow), AddressOf UpdateWBSRows)
      TreeRow.TraverseRowBackward(CType(e.Row, TreeRow), AddressOf UpdateWBSRows)
      m_updating = False
    End Sub
    Private Sub UpdateWBSRows(ByVal row As TreeRow)
      If TypeOf row.Tag Is BoqItem Then
        row("boqi_qty") = Configuration.FormatToString(CType(row.Tag, BoqItem).Qty, DigitConfig.UnitPrice)
        row("boqi_umc") = Configuration.FormatToString(CType(row.Tag, BoqItem).UMC, DigitConfig.UnitPrice)
        row("TotalMaterialCost") = Configuration.FormatToString(CType(row.Tag, BoqItem).TotalMaterialCost, DigitConfig.UnitPrice)
        row("boqi_ulc") = Configuration.FormatToString(CType(row.Tag, BoqItem).ULC, DigitConfig.UnitPrice)
        row("TotalLaborCost") = Configuration.FormatToString(CType(row.Tag, BoqItem).TotalLaborCost, DigitConfig.UnitPrice)
        row("boqi_uec") = Configuration.FormatToString(CType(row.Tag, BoqItem).UEC, DigitConfig.UnitPrice)
        row("TotalEquipmentCost") = Configuration.FormatToString(CType(row.Tag, BoqItem).TotalEquipmentCost, DigitConfig.UnitPrice)
        row("Total") = Configuration.FormatToString(CType(row.Tag, BoqItem).TotalCost, DigitConfig.UnitPrice)
        row("TotalPerWBS") = Configuration.FormatToString(CType(row.Tag, BoqItem).TotalPerWBS, DigitConfig.Price)
      End If
    End Sub
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0, 42, 18, 20 'Blank/LCI/Labor/EqCost
          'ผ่าน
          m_item.Qty = value
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      e.Row("boqi_umc") = Configuration.FormatToString(m_item.UMC, DigitConfig.UnitPrice)
      e.Row("TotalMaterialCost") = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      e.Row("boqi_ulc") = Configuration.FormatToString(m_item.ULC, DigitConfig.UnitPrice)
      e.Row("TotalLaborCost") = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      e.Row("boqi_uec") = Configuration.FormatToString(m_item.UEC, DigitConfig.UnitPrice)
      e.Row("TotalEquipmentCost") = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      e.Row("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      m_updating = False
    End Sub
    Public Sub SetUnitPrice(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0 'Blank
          'ผ่านตลอด
          Select Case e.Column.ColumnName.ToLower
            Case "boqi_umc"
              m_item.UMC = value
            Case "boqi_ulc"
              m_item.ULC = value
            Case "boqi_uec"
              m_item.UEC = value
          End Select
        Case 42 'Lci
          'ผ่านตลอด
          Select Case e.Column.ColumnName.ToLower
            Case "boqi_umc"
              m_item.UMC = value
            Case "boqi_ulc"
              m_item.ULC = value
            Case "boqi_uec"
              m_item.UEC = value
          End Select
        Case 18 'Labor
          Select Case e.Column.ColumnName.ToLower
            Case "boqi_umc"
              msgServ.ShowMessage("${res:Global.Error.LaborCannotHaveUMC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "boqi_ulc"
              m_item.ULC = value
            Case "boqi_uec"
              msgServ.ShowMessage("${res:Global.Error.LaborCannotHaveUEC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
          End Select
        Case 20 'EqCost
          Select Case e.Column.ColumnName.ToLower
            Case "boqi_umc"
              msgServ.ShowMessage("${res:Global.Error.EQCannotHaveUMC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "boqi_ulc"
              msgServ.ShowMessage("${res:Global.Error.EQCannotHaveULC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "boqi_uec"
              m_item.UEC = value
          End Select
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      e.Row("TotalMaterialCost") = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      e.Row("TotalLaborCost") = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      e.Row("TotalEquipmentCost") = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      e.Row("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      m_updating = False
    End Sub
    Public Sub SetTotalUnitPrice(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim qty As Decimal = 0
      If value <> 0 AndAlso (e.Row.IsNull("boqi_qty") OrElse Not IsNumeric(e.Row("boqi_qty")) OrElse CDec(e.Row("boqi_qty")) = 0) Then
        msgServ.ShowMessage("${res:Global.Error.QtyISZero}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      Else
        qty = CDec(e.Row("boqi_qty"))
      End If
      m_updating = True
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If

      Dim unitPrice As Decimal
      If value <> 0 And qty <> 0 Then
        unitPrice = value / qty
      End If
      Dim unitPriceAfterCalc As Decimal = Configuration.Format(unitPrice, DigitConfig.UnitPrice)
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0 'Blank
          'ผ่านตลอด
          Select Case e.Column.ColumnName.ToLower
            Case "totalmaterialcost", "totallaborcost", "totalequipmentcost"
              m_item.UMC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.Price)
              e.Row("boqi_umc") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
            Case "boqi_ulc"
              m_item.ULC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.Price)
              e.Row("boqi_ulc") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
            Case "boqi_uec"
              m_item.UEC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.Price)
              e.Row("boqi_uec") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
          End Select
        Case 42 'Lci
          'ผ่านตลอด
          Select Case e.Column.ColumnName.ToLower
            Case "totalmaterialcost"
              m_item.UMC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.Price)
              e.Row("boqi_umc") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
            Case "totallaborcost"
              m_item.ULC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.Price)
              e.Row("boqi_ulc") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
            Case "totalequipmentcost"
              m_item.UEC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.Price)
              e.Row("boqi_uec") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
          End Select
        Case 18 'Labor
          Select Case e.Column.ColumnName.ToLower
            Case "totalmaterialcost"
              msgServ.ShowMessage("${res:Global.Error.LaborCannotHaveUMC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "totallaborcost"
              m_item.ULC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.Price)
              e.Row("boqi_ulc") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
            Case "totalequipmentcost"
              msgServ.ShowMessage("${res:Global.Error.LaborCannotHaveUEC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
          End Select
        Case 20 'EqCost
          Select Case e.Column.ColumnName.ToLower
            Case "totalmaterialcost"
              msgServ.ShowMessage("${res:Global.Error.EQCannotHaveUMC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "totallaborcost"
              msgServ.ShowMessage("${res:Global.Error.EQCannotHaveULC}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            Case "totalequipmentcost"
              m_item.UEC = unitPriceAfterCalc
              e.ProposedValue = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.Price)
              e.Row("boqi_uec") = Configuration.FormatToString(unitPrice, DigitConfig.UnitPrice)
          End Select
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      e.Row("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      m_updating = False
    End Sub
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull(e.Column) Then
        m_item.ItemType.Value = CInt(e.ProposedValue)
        ClearRow(e)
        m_updating = False
        Return
      End If

      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        'ผ่านโลด
        m_updating = False
        Return
      End If

      '******************************************************************************
      m_item.ItemType.Value = CInt(e.ProposedValue)
      ClearRow(e)
      'If msgServ.AskQuestion("${res:Global.Question.ChangeBOQItemEntityType}") Then
      '    m_item.ItemType.Value = CInt(e.ProposedValue)
      '    ClearRow(e)
      'Else
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      '*******************************************************************************
      m_updating = False
    End Sub
    Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
      'e.Row("boqi_wbs") = DBNull.Value
      e.Row("boqi_entity") = DBNull.Value
      'e.Row("boqi_entityType") = DBNull.Value
      e.Row("code") = DBNull.Value
      e.Row("boqi_itemname") = DBNull.Value
      e.Row("boqi_unit") = DBNull.Value
      e.Row("Unit") = DBNull.Value
      e.Row("UnitButton") = DBNull.Value
      e.Row("boqi_qty") = DBNull.Value
      e.Row("boqi_umc") = DBNull.Value
      e.Row("TotalMaterialCost") = DBNull.Value
      e.Row("boqi_ulc") = DBNull.Value
      e.Row("boqi_uec") = DBNull.Value
      e.Row("TotalEquipmentCost") = DBNull.Value
      e.Row("boqi_note") = DBNull.Value
      e.Row("Total") = DBNull.Value
      If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 28) Then
        e.Row("Button") = "invisible"
      Else
        e.Row("Button") = ""
      End If
    End Sub
    Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0
          'ผ่าน
          m_item.Entity = New BlankItem(e.ProposedValue.ToString)
          m_item.EntityName = e.ProposedValue.ToString
        Case 42, 18, 20
          If e.ProposedValue.ToString.Length = 0 Then
            m_updating = False
            Return
          End If
          If Not e.Row.IsNull("Code") AndAlso e.Row("Code").ToString.Length > 0 Then
            'มี Code อยู่ ---> 
            If Not IsDBNull(e.ProposedValue) AndAlso Not e.ProposedValue.ToString.Length = 0 Then
              Dim suffix As String = "<" & m_item.Entity.Name & ">"
              If e.ProposedValue.ToString <> suffix Then
                If e.ProposedValue.ToString.EndsWith(suffix) Then
                  Dim s As String = e.ProposedValue.ToString
                  e.ProposedValue = s.Remove(s.Length - suffix.Length, suffix.Length)
                End If
              End If
              m_item.EntityName = e.ProposedValue.ToString
              If e.ProposedValue.ToString <> m_item.Entity.Name Then
                e.ProposedValue = e.ProposedValue.ToString & suffix
              End If
            End If
          Else
            msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("boqi_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is e.Row Then
          If Not row.IsNull("boqi_entityType") Then
            If CInt(row("boqi_entityType")) = CInt(e.Row("boqi_entityType")) Then
              If Not row.IsNull("code") Then
                If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
                  Return True
                End If
              End If
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      'If DupCode(e) Then
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {m_item.ItemType.Description, e.ProposedValue.ToString})
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      Select Case CInt(e.Row("boqi_entityType"))
        Case 0 'Blank
          If e.ProposedValue.ToString.Length > 0 Then
            msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          End If
        Case 18 'Labor
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLaborDetail}", New String() {e.Row(e.Column).ToString}) Then
                ClearRow(e)
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim myEntity As New Labor(e.ProposedValue.ToString)
          If Not myEntity.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLabor}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'Display
            Dim myUnit As Unit = myEntity.Unit
            e.Row("boqi_entity") = myEntity.Id
            e.ProposedValue = myEntity.Code
            e.Row("boqi_itemName") = myEntity.Name
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
              e.Row("boqi_unit") = myUnit.Id
              e.Row("Unit") = myUnit.Name
            Else
              e.Row("boqi_unit") = DBNull.Value
              e.Row("Unit") = DBNull.Value
            End If

            'Set Item Value
            m_item.Entity = myEntity
            m_item.ULC = myEntity.Cost
            m_item.Unit = myEntity.Unit

          End If
        Case 20 'Equipment
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLaborDetail}", New String() {e.Row(e.Column).ToString}) Then
                ClearRow(e)
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim myEntity As New EqCost(e.ProposedValue.ToString)
          If Not myEntity.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoEqCost}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'Display
            Dim myUnit As Unit = myEntity.Unit
            e.Row("boqi_entity") = myEntity.Id
            e.ProposedValue = myEntity.Code
            e.Row("boqi_itemName") = myEntity.Name
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
              e.Row("boqi_unit") = myUnit.Id
              e.Row("Unit") = myUnit.Name
            Else
              e.Row("boqi_unit") = DBNull.Value
              e.Row("Unit") = DBNull.Value
            End If

            'Set Item Value
            m_item.Entity = myEntity
            m_item.UEC = myEntity.Cost
            m_item.Unit = myEntity.Unit

          End If
        Case 42 'LCI
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
                ClearRow(e)
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim lci As New LCIItem(e.ProposedValue.ToString)
          If Not lci.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          ElseIf lci.Canceled Then
            msgServ.ShowMessageFormatted("${res:Global.Error.LCIIsCanceled}", New String() {e.ProposedValue.ToString})
            Return
          Else
            Dim myUnit As Unit = lci.DefaultUnit
            e.Row("boqi_entity") = lci.Id
            e.ProposedValue = lci.Code
            e.Row("boqi_itemName") = lci.Name
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
              e.Row("boqi_unit") = myUnit.Id
              e.Row("Unit") = myUnit.Name
            Else
              e.Row("boqi_unit") = DBNull.Value
              e.Row("Unit") = DBNull.Value
            End If

            'Set Item Value
            m_item.Entity = lci
            m_item.UMC = lci.FairPrice
            m_item.Unit = lci.DefaultUnit
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      e.Row("boqi_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      m_item.Qty = 1

      e.Row("boqi_umc") = Configuration.FormatToString(m_item.UMC, DigitConfig.UnitPrice)
      e.Row("TotalMaterialCost") = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      e.Row("boqi_ulc") = Configuration.FormatToString(m_item.ULC, DigitConfig.UnitPrice)
      e.Row("TotalLaborCost") = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      e.Row("boqi_uec") = Configuration.FormatToString(m_item.UEC, DigitConfig.UnitPrice)
      e.Row("TotalEquipmentCost") = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      e.Row("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      m_updating = False
    End Sub
    Public Sub SetUnitForWBS(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) Then
        e.ProposedValue = ""
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_wbs Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim myUnit As New Unit(e.ProposedValue.ToString)
      Dim err As String = ""
      If Not myUnit Is Nothing AndAlso myUnit.Originated Then
        
      Else
        err = "${res:Global.Error.InvalidUnit}"
      End If
      If err.Length = 0 Then
        e.Row("boqi_unit") = myUnit.Id
        e.ProposedValue = myUnit.Name
        m_wbs.Unit = myUnit
      Else
        e.ProposedValue = e.Row(e.Column)
        msgServ.ShowMessage(err)
      End If
      'TreeRow.TraverseRow(CType(e.Row, TreeRow), AddressOf UpdateWBSRows)
      'TreeRow.TraverseRowBackward(CType(e.Row, TreeRow), AddressOf UpdateWBSRows)
      m_updating = False
    End Sub
    Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      If TypeOf CType(e.Row, TreeRow).Tag Is WBS Then
        SetUnitForWBS(e)
        Return
      End If
      If m_entity.Locked Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If m_updating Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim oldConversion As Decimal = m_item.Conversion
      Dim newConversion As Decimal = 1
      Dim myUnit As New Unit(e.ProposedValue.ToString)
      Dim err As String = ""
      If Not myUnit Is Nothing AndAlso myUnit.Originated Then
        If TypeOf m_item.Entity Is LCIItem Then
          If Not CType(m_item.Entity, LCIItem).ValidUnit(myUnit) Then
            err = "${res:Global.Error.NoUnitConversion}"
          Else
            newConversion = CType(m_item.Entity, LCIItem).GetConversion(myUnit)
          End If
        ElseIf TypeOf m_item.Entity Is Labor Then
          If Not (Not CType(m_item.Entity, Labor).Unit Is Nothing AndAlso CType(m_item.Entity, Labor).Unit.Id = myUnit.Id) Then
            err = "${res:Global.Error.NoUnitConversion}"
          End If
        ElseIf TypeOf m_item.Entity Is EqCost Then
          If Not (Not CType(m_item.Entity, EqCost).Unit Is Nothing AndAlso CType(m_item.Entity, EqCost).Unit.Id = myUnit.Id) Then
            err = "${res:Global.Error.NoUnitConversion}"
          End If
        End If
      Else
        err = "${res:Global.Error.InvalidUnit}"
      End If
      If err.Length = 0 Then
        e.Row("boqi_unit") = myUnit.Id
        e.ProposedValue = myUnit.Name
        Me.m_item.Unit = myUnit
        If Not e.Row.IsNull("boqi_qty") AndAlso e.Row("boqi_qty").ToString.Length > 0 Then
          e.Row("boqi_qty") = (oldConversion / newConversion) * CDec(e.Row("boqi_qty"))
        End If
        If Not e.Row.IsNull("boqi_umc") AndAlso e.Row("boqi_umc").ToString.Length > 0 Then
          e.Row("boqi_umc") = (newConversion / oldConversion) * CDec(e.Row("boqi_umc"))
        End If
        If Not e.Row.IsNull("boqi_ulc") AndAlso e.Row("boqi_ulc").ToString.Length > 0 Then
          e.Row("boqi_ulc") = (newConversion / oldConversion) * CDec(e.Row("boqi_ulc"))
        End If
        If Not e.Row.IsNull("boqi_uec") AndAlso e.Row("boqi_uec").ToString.Length > 0 Then
          e.Row("boqi_uec") = (newConversion / oldConversion) * CDec(e.Row("boqi_uec"))
        End If
      Else
        e.ProposedValue = e.Row(e.Column)
        msgServ.ShowMessage(err)
      End If
    End Sub
    Public Sub SetNote(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("boqi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_item.Note = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_treeManager.Treetable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      '-------- ให้เห็น ปุ่ม lock
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(349)       'ตรวจสอบ สิทธิปลดล๊อคใบรับของ
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)      'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)

      btnLockBoq.Visible = True
      If Not CBool(checkString.Substring(0, 1)) Then
        btnLockBoq.Visible = False
      End If
      '----------
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.grbPrice}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblMat}")
      Me.lblLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblLabor}")
      Me.lblTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblTotal}")
      Me.lblWorkBreakdown.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblWorkBreakdown}")
      Me.grbUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.grbUnitPrice}")
      Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.grbSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.grbSupplier}")
      'Me.chkSubLab.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.chkSubLab}")
      'Me.chkSubEq.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.chkSubEq}")
      Me.lblEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblEquip}")
      Me.grbEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.grbEquip}")
      Me.grbLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.grbLabor}")
      Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblBOQCode}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblProject}")
      Me.lblItemQTY.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemQTY}")
      Me.lblItemUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemUnit}")
      Me.lblItemDes.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemDes}")
      Me.lblItemNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemNote}")
      Me.lblItemCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemCode}")
      Me.lblItemTotalPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemTotalPrice}")
      Me.lblItemUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblItemUnitPrice}")
      Me.lblCurrentPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblCurrentPrice}")
      Me.btnApplyLCIUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.btnApplyLCIUnitPrice}")
      Me.btnSupplierDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.btnSupplierDetail}")
      Me.btnApplyEqCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.btnApplyEqCost}")
      Me.btnApplyLaborUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.btnApplyLaborUnitPrice}")
      Me.tpItemDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.tpItemDetail}")
      Me.tpLaborEq.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.tpLaborEq}")
      Me.tpUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.tpUnitPrice}")
      Me.lblEntityType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblEntityType}")
      Me.lblMonthPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblRecentMonth}")
      Me.lblMonth.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.lblMonth}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtItemCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemDescription.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemUnitCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemQty.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemEqUnitPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemTotalEqPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemLaborUnitPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemTotalLaborPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemMatUnitPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemTotalMatPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler txtItemTotalMatPrice.Validated, AddressOf Me.ChangeProperty
      AddHandler cmbEntityType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtItemNote.Validated, AddressOf Me.ChangeProperty
      AddHandler txtMonthPeriod.Validated, AddressOf Me.ChangeProperty
      AddHandler txtMonthPeriod.Click, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtMonthPeriod.Text = Configuration.GetConfig("ActualPricePeriod")

      txtBOQCode.Text = m_entity.Code
      txtProjectCode.Text = m_entity.Project.Code
      txtProjectName.Text = m_entity.Project.Name

      chkEquip.Checked = m_entity.HasEquipmentCost
      chkLabor.Checked = m_entity.HasLaborCost
      chkMat.Checked = m_entity.HasMaterialCost

      If Not m_entity.Originated Then
        btnLockBoq.Visible = False
        ibtnDelRow.Enabled = True
        ibtnBlank.Enabled = True
      ElseIf m_entity.Locked Then
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_unlocked
        'btnLockBoq.Text = "UnLock"
        ibtnDelRow.Enabled = False
        ibtnBlank.Enabled = False
      Else
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
        ''btnLockBoq.Text = "Lock"
        ibtnDelRow.Enabled = True
        ibtnBlank.Enabled = True
      End If

      If Not Me.m_treeManager.GridTableStyle Is Nothing Then
        If Me.m_treeManager.GridTableStyle.GridColumnStyles.Contains("UnitButton") Then
          Dim btnCol As DataGridButtonColumn = CType(Me.m_treeManager.GridTableStyle.GridColumnStyles("UnitButton"), DataGridButtonColumn)
          RemoveHandler btnCol.Click, AddressOf ButtonClick
        End If
      End If
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager.SetTableStyle(dst)

      Dim excludeString As String = GetExcludeString()
      If excludeString.Length = 0 Then
        CodeDescription.ListCodeDescriptionInComboBox(Me.cmbEntityType, "boqi_entityType")
      Else
        CodeDescription.ListCodeDescriptionInComboBox(Me.cmbEntityType, "boqi_entityType", "code_value not in (" & excludeString & ")")
      End If

      RefreshItems()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      If Me.m_item Is Nothing Then
        Return
      End If
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtitemcode"
          row("code") = txtItemCode.Text
        Case "txtitemdescription"
          row("boqi_itemname") = txtItemDescription.Text
        Case "txtitemunitcode"
          row("unit") = txtItemUnitCode.Text
        Case "txtitemqty"
          row("boqi_qty") = txtItemQty.Text
        Case "txtitemequnitprice"
          row("boqi_uec") = txtItemEqUnitPrice.Text
        Case "txtitemtotaleqprice"
          row("totalequipmentcost") = txtItemTotalEqPrice.Text
        Case "txtitemlaborunitprice"
          row("boqi_ulc") = txtItemLaborUnitPrice.Text
        Case "txtitemtotallaborprice"
          row("totallaborcost") = txtItemTotalLaborPrice.Text
        Case "txtitemmatunitprice"
          row("boqi_umc") = txtItemMatUnitPrice.Text
        Case "txtitemtotalmatprice"
          row("totalmaterialcost") = txtItemTotalMatPrice.Text
        Case "cmbentitytype"
          If Me.cmbEntityType.Items.Count > 0 Then
            row("boqi_entitytype") = CType(cmbEntityType.SelectedItem, IdValuePair).Id
          End If
        Case "txtitemnote"
          row("boqi_note") = txtItemNote.Text
        Case "txtmonthperiod"
          If TypeOf Me.m_item.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.m_item.Entity, LCIItem)
            lci.MonthPeriod = txtMonthPeriod.Text
          End If
          UpdateItem()
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          m_level = 0
          Me.lblLevel.Text = m_level.ToString()
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.Dispose()
            Me.m_entity = Nothing
          End If
          Me.m_entity = CType(Value, BOQ)
        End If
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        If Me.WorkbenchWindow.ActiveViewContent Is Me Then
          Me.tgItem.Visible = False
          UpdateEntityProperties()
          Me.tgItem.Visible = True
        End If
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub
    Public Overrides Sub InitProgress()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim totalWork As Integer = Me.m_entity.WBSCollection.Count + Me.m_entity.ItemCollection.Count
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.BeginTask("${res:MainWindow.StatusBar.LoadingEntity}", totalWork)
    End Sub
    Public Sub WorkDone(ByVal i As Integer)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Worked(i)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub ibtnShowUnit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowUnit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Unit)
    End Sub
    Private Sub ibtnShowUnitDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowUnitDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetItemUnit)
    End Sub
    Private Sub SetItemUnit(ByVal e As ISimpleEntity)
      Me.txtItemUnitCode.Text = e.Code
    End Sub
    Private Sub UpdateItemRow()
      Dim itr As TreeRow = Me.m_treeManager.SelectedRow
      If itr Is Nothing Then
        Return
      End If
      If Me.m_item Is Nothing Then
        Return
      End If
      Me.m_tableInitialized = False
      itr("Code") = m_item.Entity.Code
      If m_item.EntityName Is Nothing OrElse m_item.EntityName.Length = 0 Then
        itr("boqi_itemName") = m_item.Entity.Name
      Else
        itr("boqi_itemName") = m_item.EntityName & "<" & m_item.Entity.Name & ">"
      End If
      itr("boqi_note") = m_item.Note
      itr("boqi_entity") = m_item.Entity.Id
      If Not m_item.ItemType Is Nothing Then
        itr("boqi_entityType") = m_item.ItemType.Value
        Select Case m_item.ItemType.Value
          Case 0
            itr("Button") = "invisible"
          Case Else
            itr("Button") = ""
        End Select
      Else
        itr("Button") = ""
      End If
      itr("boqi_unit") = m_item.Unit.Id
      itr("Unit") = m_item.Unit.Name
      itr("UnitButton") = ""
      itr("boqi_qty") = m_item.Qty
      itr("boqi_umc") = Configuration.FormatToString(m_item.UMC, DigitConfig.UnitPrice)
      itr("TotalMaterialCost") = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      itr("boqi_ulc") = Configuration.FormatToString(m_item.ULC, DigitConfig.UnitPrice)
      itr("TotalLaborCost") = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      itr("boqi_uec") = Configuration.FormatToString(m_item.UEC, DigitConfig.UnitPrice)
      itr("TotalEquipmentCost") = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      itr("Total") = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      itr("boqi_note") = m_item.Note
      Me.m_tableInitialized = True
    End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If m_oldRow Is theRow Then
        Return
      End If

      m_wbs = Nothing
      m_item = Nothing

      If TypeOf theRow.Tag Is WBS Then
        m_wbs = CType(theRow.Tag, WBS)
        UpdateWBS()
      ElseIf TypeOf theRow.Tag Is BoqItem Then
        m_item = CType(theRow.Tag, BoqItem)
        UpdateItem()
      End If
      m_oldRow = m_treeManager.SelectedRow
    End Sub
    Private Sub tgLCILabor_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgLCILabor.CurrentCellChanged
      Dim selectedValue As Object = Me.m_laborCostManager.Treetable.Rows(tgLCILabor.CurrentCell.RowNumber)("Cost")
      If Not IsDBNull(selectedValue) AndAlso IsNumeric(selectedValue) Then 'Todo: Revise
        Me.m_seletedLaborCost = selectedValue
        Me.btnApplyLaborUnitPrice.Enabled = True
      Else
        m_seletedLaborCost = DBNull.Value
        Me.btnApplyLaborUnitPrice.Enabled = False
      End If
    End Sub
    Private Sub tgLCIEqCost_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgLCIEqCost.CurrentCellChanged
      Dim selectedValue As Object = Me.m_eqCostManager.Treetable.Rows(tgLCIEqCost.CurrentCell.RowNumber)("Cost")
      If Not IsDBNull(selectedValue) AndAlso IsNumeric(selectedValue) Then 'Todo: Revise
        Me.m_selectedEqCost = selectedValue
        Me.btnApplyEqCost.Enabled = True
      Else
        m_selectedEqCost = DBNull.Value
        Me.btnApplyEqCost.Enabled = False
      End If
    End Sub
    Private Sub tgLCIUnitPrice_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgLCIUnitPrice.CurrentCellChanged
      Dim selectedValue As Object = Me.m_bestPriceManager.Treetable.Rows(tgLCIUnitPrice.CurrentCell.RowNumber)(tgLCIUnitPrice.CurrentCell.ColumnNumber)
      If Not IsDBNull(selectedValue) AndAlso IsNumeric(selectedValue) Then 'Todo: Revise
        m_selectedPrice = selectedValue
        Me.btnApplyLCIUnitPrice.Enabled = True
      Else
        m_selectedPrice = DBNull.Value
        Me.btnApplyLCIUnitPrice.Enabled = False
      End If
    End Sub
    Private Sub tgLCISupplier_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgLCISupplier.CurrentCellChanged
      Dim selectedValue As Object = Me.m_supplierManager.Treetable.Rows(tgLCISupplier.CurrentCell.RowNumber)("lcis_supplier")
      If Not IsDBNull(selectedValue) AndAlso IsNumeric(selectedValue) Then 'Todo: Revise
        Me.m_selectedSupplier = selectedValue
        Me.btnSupplierDetail.Enabled = True
      Else
        m_selectedSupplier = DBNull.Value
        Me.btnSupplierDetail.Enabled = False
      End If
    End Sub
    Private Sub btnApplyLCIUnitPrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyLCIUnitPrice.Click
      If m_item Is Nothing Then
        Return
      End If
      If IsDBNull(m_selectedPrice) OrElse Not IsNumeric(m_selectedPrice) Then
        Return
      End If
      Me.m_item.UMC = CDec(m_selectedPrice)
      Me.UpdateItem()
      Me.UpdateItemRow()
      Me.tgItem.RefreshHeights()
    End Sub
    Private Sub btnSupplierDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSupplierDetail.Click
      Dim id As Integer
      If Not IsDBNull(m_selectedSupplier) AndAlso IsNumeric(m_selectedSupplier) Then
        id = CInt(m_selectedSupplier)
      End If
      If id <> 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entity As New Supplier(id)
        myEntityPanelService.OpenDetailPanel(entity)
      End If
    End Sub
    Private Sub btnApplyEqCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyEqCost.Click
      If m_item Is Nothing Then
        Return
      End If
      If IsDBNull(m_selectedEqCost) OrElse Not IsNumeric(m_selectedEqCost) Then
        Return
      End If
      Me.m_item.UEC = CDec(m_selectedEqCost)
      Me.UpdateItem()
      Me.UpdateItemRow()
      Me.tgItem.RefreshHeights()
    End Sub
    Private Sub btnApplyLaborUnitPrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyLaborUnitPrice.Click
      If m_item Is Nothing Then
        Return
      End If
      If IsDBNull(m_seletedLaborCost) OrElse Not IsNumeric(m_seletedLaborCost) Then
        Return
      End If
      Me.m_item.ULC = CDec(m_seletedLaborCost)
      Me.UpdateItem()
      Me.UpdateItemRow()
      Me.tgItem.RefreshHeights()
    End Sub
    Private Sub UpdateWBS()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.txtItemCode.Text = m_wbs.Code
      Me.txtItemName.Text = m_wbs.Name
      Me.txtItemNote.Text = m_wbs.Note

      '***************************************************
      Me.tbDetail.SelectedTab = Me.tpItemDetail

      Me.txtItemDescription.Text = ""
      Me.txtItemEqUnitPrice.Text = ""
      Me.txtItemLaborUnitPrice.Text = ""
      Me.txtItemMatUnitPrice.Text = ""
      Me.txtItemQty.Text = ""
      Me.txtItemTotalEqPrice.Text = ""
      Me.txtItemTotalLaborPrice.Text = ""
      Me.txtItemTotalMatPrice.Text = ""
      Me.txtItemTotalUnitPrice.Text = ""
      Me.txtItemTotalPrice.Text = ""
      Me.txtItemUnitCode.Text = ""
      Me.txtItemUnitName.Text = ""
      Me.txtCurrentPrice.Text = ""
      Me.txtCurrentEq.Text = ""
      Me.txtCurrentLabor.Text = ""

      Me.tbDetail.Enabled = False
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateItem()
      If m_item Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.tbDetail.Enabled = True

      Me.txtItemCode.Text = m_item.Entity.Code
      Me.txtItemName.Text = m_item.Entity.Name
      Me.txtItemDescription.Text = m_item.EntityName
      Me.txtItemEqUnitPrice.Text = Configuration.FormatToString(m_item.UEC, DigitConfig.UnitPrice)
      Me.txtItemLaborUnitPrice.Text = Configuration.FormatToString(m_item.ULC, DigitConfig.UnitPrice)
      Me.txtItemMatUnitPrice.Text = Configuration.FormatToString(m_item.UMC, DigitConfig.UnitPrice)
      Me.txtItemQty.Text = Configuration.FormatToString(m_item.Qty, DigitConfig.UnitPrice)
      Me.txtItemTotalEqPrice.Text = Configuration.FormatToString(m_item.TotalEquipmentCost, DigitConfig.UnitPrice)
      Me.txtItemTotalLaborPrice.Text = Configuration.FormatToString(m_item.TotalLaborCost, DigitConfig.UnitPrice)
      Me.txtItemTotalMatPrice.Text = Configuration.FormatToString(m_item.TotalMaterialCost, DigitConfig.UnitPrice)
      Me.txtItemTotalUnitPrice.Text = Configuration.FormatToString(m_item.TotalUC, DigitConfig.UnitPrice)
      Me.txtItemTotalPrice.Text = Configuration.FormatToString(m_item.TotalCost, DigitConfig.UnitPrice)
      Me.txtItemUnitCode.Text = m_item.Unit.Code
      Me.txtItemUnitName.Text = m_item.Unit.Name
      Me.txtItemNote.Text = m_item.Note

      CodeDescription.ComboSelect(Me.cmbEntityType, m_item.ItemType)

      Me.txtCurrentPrice.Text = Me.txtItemMatUnitPrice.Text
      Me.txtCurrentEq.Text = Me.txtItemEqUnitPrice.Text
      Me.txtCurrentLabor.Text = Me.txtItemLaborUnitPrice.Text

      If Not Me.m_bestPriceManager.Treetable Is Nothing Then
        Me.m_bestPriceManager.Treetable.Clear()
      End If
      If Not Me.m_supplierManager.Treetable Is Nothing Then
        Me.m_supplierManager.Treetable.Clear()
      End If
      If Not Me.m_eqCostManager.Treetable Is Nothing Then
        Me.m_eqCostManager.Treetable.Clear()
      End If
      If Not Me.m_laborCostManager.Treetable Is Nothing Then
        Me.m_laborCostManager.Treetable.Clear()
      End If

      If TypeOf Me.m_item.Entity Is LCIItem Then
        Dim lci As LCIItem = CType(Me.m_item.Entity, LCIItem)
        Dim tt As TreeTable = lci.GetBestPriceTable(m_item.Unit)
        If Not tt Is Nothing Then
          Me.m_bestPriceManager.Treetable = tt
        End If
        If m_bestPriceManager.GridTableStyle Is Nothing Then
          Dim bpdst As DataGridTableStyle = Me.CreateBestPriceStyle
          m_bestPriceManager.SetTableStyle(bpdst)
        End If

        tt = lci.GetSupplierListTable
        If Not tt Is Nothing Then
          Me.m_supplierManager.Treetable = tt
        End If
        If m_supplierManager.GridTableStyle Is Nothing Then
          Dim spst As DataGridTableStyle = Me.CreateSupplierStyle
          m_supplierManager.SetTableStyle(spst)
        End If

        tt = lci.GetEqCostListTable(m_item.Unit)
        If Not tt Is Nothing Then
          Me.m_eqCostManager.Treetable = tt
        End If
        If m_eqCostManager.GridTableStyle Is Nothing Then
          Dim eqt As DataGridTableStyle = Me.CreateEqCostStyle
          m_eqCostManager.SetTableStyle(eqt)
        End If

        tt = lci.GetLaborListTable(m_item.Unit)
        If Not tt Is Nothing Then
          Me.m_laborCostManager.Treetable = tt
        End If
        If m_laborCostManager.GridTableStyle Is Nothing Then
          Dim lbt As DataGridTableStyle = Me.CreateLaborCostStyle
          m_laborCostManager.SetTableStyle(lbt)
        End If
      End If

      Me.m_isInitialized = flag
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Not m_wbs Is Nothing Then
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
        Return
      End If
      If m_item Is Nothing Then
        Return
      End If
      Dim filters(0) As Filter
      Dim includeFilter As Boolean = False
      If TypeOf m_item.Entity Is Labor Then
        Dim myEntity As Labor = CType(m_item.Entity, Labor)
        If Not myEntity.Unit Is Nothing AndAlso myEntity.Unit.Originated Then
          filters(0) = New Filter("includedId", myEntity.Unit.Id)
          includeFilter = True
        End If
      ElseIf TypeOf m_item.Entity Is EqCost Then
        Dim myEntity As EqCost = CType(m_item.Entity, EqCost)
        If Not myEntity.Unit Is Nothing AndAlso myEntity.Unit.Originated Then
          filters(0) = New Filter("includedId", myEntity.Unit.Id)
          includeFilter = True
        End If
      ElseIf TypeOf m_item.Entity Is LCIItem Then
        Dim idList As String = CType(m_item.Entity, LCIItem).GetUnitIdList
        includeFilter = True
        If idList.Length > 0 Then
          filters(0) = New Filter("includedId", idList)
        Else
          filters(0) = New Filter("includedId", "-1")
        End If
      End If
      If includeFilter Then
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
      Else
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private Sub btnShowLCI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowLCI.Click
      If m_item Is Nothing Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If m_item.ItemType Is Nothing Then
      Else
        Select Case m_item.ItemType.Value
          Case 0 'Blank
            Return
          Case 18 'Labor
            myEntityPanelService.OpenPanel(New Labor)
          Case 20 'EqCost
            myEntityPanelService.OpenPanel(New EqCost)
          Case 42 'LCI
            myEntityPanelService.OpenPanel(New LCIItem)
          Case Else
        End Select
      End If
    End Sub
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      ItemBtnClick()
    End Sub
    Private Sub ibnShowLCIDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibnShowLCIDialog.Click
      ItemBtnClick()
    End Sub
    Private Sub ItemBtnClick()
      If m_item Is Nothing Then
        Return
      End If
      If m_entity.Locked Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If m_item.ItemType Is Nothing Then
        Dim entities(2) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New Labor
        entities(3) = New EqCost
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems)
      Else
        Select Case m_item.ItemType.Value
          Case 0 'Blank
            Return
          Case 18 'Labor
            myEntityPanelService.OpenListDialog(New Labor, AddressOf SetItems)
          Case 20 'EqCost
            myEntityPanelService.OpenListDialog(New EqCost, AddressOf SetItems)
          Case 42 'LCI
            myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetItems)
          Case Else

        End Select
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
      If theRow Is Nothing Then
        Return
      End If
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim itemType As Integer
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            itemType = 42
          Case "longkong.pojjaman.businesslogic.labor"
            newItem = New Labor(item.Id)
            itemType = 18
          Case "longkong.pojjaman.businesslogic.eqcost"
            newItem = New EqCost(item.Id)
            itemType = 20
        End Select
        If i = 0 Then
          m_treeManager.SelectedRow("boqi_entitytype") = itemType
          m_treeManager.SelectedRow("Code") = newItem.Code
        Else
          Dim parentRow As ITreeParent
          Dim parentWBS As WBS
          parentRow = theRow.Parent
          parentWBS = CType(CType(parentRow, TreeRow).Tag, WBS)
          Dim newBOQItem As New BoqItem
          newBOQItem.WBS = parentWBS
          Dim nextItem As BoqItem = m_entity.ItemCollection.GetNextItem(m_item)
          If nextItem Is Nothing Then
            'just add a new one
            m_entity.ItemCollection.Add(newBOQItem)
          Else
            m_entity.ItemCollection.Insert(m_entity.ItemCollection.IndexOf(nextItem), newBOQItem)
          End If
          Dim newRow As TreeRow
          Dim nextItemRow As TreeRow = FindNextItemRow(parentRow, nextItem)
          If nextItemRow Is Nothing Then
            newRow = parentRow.Childs.Add
          Else
            newRow = parentRow.Childs.InsertAt(parentRow.Childs.IndexOf(nextItemRow))
          End If
          newRow.Tag = newBOQItem
          m_item = newBOQItem
          newRow("boqi_entitytype") = itemType
          newRow("Code") = newItem.Code
        End If
        Me.m_treeManager.Treetable.AcceptChanges()
      Next
      Me.tgItem.RefreshHeights()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
      If theRow Is Nothing Then
        Return
      End If
      Dim parentRow As ITreeParent
      Dim parentWBS As WBS
      If TypeOf theRow.Tag Is WBS Then
        parentRow = theRow
        parentWBS = CType(theRow.Tag, WBS)
      ElseIf TypeOf theRow.Tag Is BoqItem Then
        parentRow = theRow.Parent
        parentWBS = CType(CType(parentRow, TreeRow).Tag, WBS)
      End If
      Dim newItem As New BoqItem
      newItem.WBS = parentWBS
      Dim newRow As TreeRow
      If TypeOf theRow.Tag Is WBS Or parentRow.Childs.Count = 0 Then
        Dim nextWBSRow As TreeRow = FindWBSChildRow(parentRow)
        If nextWBSRow Is Nothing Then
          newRow = parentRow.Childs.Add
        Else
          newRow = parentRow.Childs.InsertAt(parentRow.Childs.IndexOf(nextWBSRow))
        End If
        Me.m_entity.ItemCollection.Add(newItem)
      ElseIf TypeOf theRow.Tag Is BoqItem Then
        newRow = parentRow.Childs.InsertAt(parentRow.Childs.IndexOf(theRow))
        Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(CType(theRow.Tag, BoqItem)), newItem)
      End If
      newRow("boqi_itemName") = "<NEW>"
      newRow.Tag = newItem
      Me.m_item = newItem
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.m_treeManager.SelectedRow = newRow
      UpdateItemRow()
      'RefreshItems()
      'ReIndex()
      Me.tgItem.RefreshHeights()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim theRow As TreeRow
      Dim rowsCount As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          theRow = CType(Obj, TreeRow)
          If Not theRow Is Nothing Then
            If TypeOf theRow.Tag Is BoqItem Then

              m_item = CType(theRow.Tag, BoqItem)
              If Not m_item Is Nothing Then

                Me.m_entity.ItemCollection.Remove(m_item)
                For Each mk As Markup In Me.m_entity.MarkupCollection
                  If mk.DistributedItems.Contains(m_item) Then
                    mk.DistributedItems.Remove(m_item)
                  End If
                Next
                If Me.m_entity.MaterialMarkupItems.Contains(m_item) Then
                  Me.m_entity.MaterialMarkupItems.Remove(m_item)
                End If
                If Me.m_entity.LaborMarkupItems.Contains(m_item) Then
                  Me.m_entity.LaborMarkupItems.Remove(m_item)
                End If
                If Me.m_entity.EquipmentMarkupItems.Contains(m_item) Then
                  Me.m_entity.EquipmentMarkupItems.Remove(m_item)
                End If

              End If
              theRow.Parent.Childs.Remove(theRow)

            End If
          End If
        End If
      Next


      'If rowsCount.Equals(0) Then
      '  theRow = Me.m_treeManager.SelectedRow
      '  If theRow Is Nothing Then
      '    Return
      '  End If
      '  If Not TypeOf theRow.Tag Is BoqItem Then
      '    Return
      '  End If
      '  If Me.m_item Is Nothing Then
      '    Return
      '  End If
      '  Me.m_entity.ItemCollection.Remove(m_item)
      '  For Each mk As Markup In Me.m_entity.MarkupCollection
      '    If mk.DistributedItems.Contains(m_item) Then
      '      mk.DistributedItems.Remove(m_item)
      '    End If
      '  Next
      '  If Me.m_entity.MaterialMarkupItems.Contains(m_item) Then
      '    Me.m_entity.MaterialMarkupItems.Remove(m_item)
      '  End If
      '  If Me.m_entity.LaborMarkupItems.Contains(m_item) Then
      '    Me.m_entity.LaborMarkupItems.Remove(m_item)
      '  End If
      '  If Me.m_entity.EquipmentMarkupItems.Contains(m_item) Then
      '    Me.m_entity.EquipmentMarkupItems.Remove(m_item)
      '  End If
      '  theRow.Parent.Childs.Remove(theRow)
      'End If

      Me.m_treeManager.Treetable.AcceptChanges()
      m_item = Nothing
      'RefreshItems()
      'ReIndex()
      Me.tgItem.RefreshHeights()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function FindWBSChildRow(ByVal parentRow As ITreeParent) As TreeRow
      For i As Integer = 0 To parentRow.Childs.Count - 1
        Dim row As TreeRow = parentRow.Childs(i)
        If TypeOf row.Tag Is WBS Then
          Return row
        End If
      Next
      Return Nothing
    End Function
    Private Function FindNextItemRow(ByVal parentRow As ITreeParent, ByVal nextitem As BoqItem) As TreeRow
      For i As Integer = 0 To parentRow.Childs.Count - 1
        Dim row As TreeRow = parentRow.Childs(i)
        If row.Tag Is Nothing OrElse Not TypeOf row.Tag Is BoqItem Then
          Return Nothing
        End If
        Dim boqi As BoqItem = CType(row.Tag, BoqItem)
        If boqi Is nextitem Then
          Return row
        End If
      Next
      Return Nothing
    End Function
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub ibtnShowEstimator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowEstimatorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      'Me.txtEstimatorCode.Text = e.Code
      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      '    Me.WorkbenchWindow.ViewContent.IsDirty _
      '    Or Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
    End Sub

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        Return GetSelectedItems.Count > 0
      End Get
    End Property
    Public Overrides ReadOnly Property EnableCut() As Boolean
      Get
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If m_copiedColl Is Nothing OrElse m_copiedColl.Count = 0 Then
          Return False
        End If
        Return True
      End Get
    End Property
    Private m_copiedColl As BoqItemCollection
    Public ReadOnly Property CopiedColl() As BoqItemCollection
      Get
        Return m_copiedColl
      End Get
    End Property

    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim coll As BoqItemCollection = GetSelectedItems()
      m_copiedColl = coll
      WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If m_copiedColl Is Nothing OrElse m_copiedColl.Count = 0 Then
        Return
      End If
      For Each item As BoqItem In m_copiedColl
        Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
        If theRow Is Nothing Then
          Return
        End If
        Dim parentRow As ITreeParent
        Dim parentWBS As WBS
        If TypeOf theRow.Tag Is WBS Then
          parentRow = theRow
          parentWBS = CType(theRow.Tag, WBS)
        ElseIf TypeOf theRow.Tag Is BoqItem Then
          parentRow = theRow.Parent
          parentWBS = CType(CType(parentRow, TreeRow).Tag, WBS)
        End If
        Dim newItem As New BoqItem
        newItem.WBS = parentWBS

        newItem.Entity = item.Entity
        newItem.EntityName = item.EntityName
        newItem.ItemType = item.ItemType
        newItem.Note = item.Note
        newItem.Qty = item.Qty
        newItem.UEC = item.UEC
        newItem.ULC = item.ULC
        newItem.UMC = item.UMC
        newItem.Unit = item.Unit

        Dim newRow As TreeRow
        If TypeOf theRow.Tag Is WBS Or parentRow.Childs.Count = 0 Then
          Dim nextWBSRow As TreeRow = FindWBSChildRow(parentRow)
          If nextWBSRow Is Nothing Then
            newRow = parentRow.Childs.Add
          Else
            newRow = parentRow.Childs.InsertAt(parentRow.Childs.IndexOf(nextWBSRow))
          End If
          Me.m_entity.ItemCollection.Add(newItem)
        ElseIf TypeOf theRow.Tag Is BoqItem Then
          Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(CType(theRow.Tag, BoqItem)), newItem)
          newRow = parentRow.Childs.InsertAt(parentRow.Childs.IndexOf(theRow))
        End If
        newRow.Tag = newItem
        Me.m_item = newItem
        Me.m_treeManager.Treetable.AcceptChanges()
        Me.m_treeManager.SelectedRow = newRow
        UpdateItemRow()
      Next
      'm_copiedColl = Nothing
      'RefreshItems()
      'ReIndex()
      Me.tgItem.RefreshHeights()
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function GetSelectedItems() As BoqItemCollection
      Dim coll As New BoqItemCollection
      coll.Boq = Me.m_entity
      For Each myRow As TreeRow In Me.m_treeManager.SelectedRows
        If TypeOf myRow.Tag Is BoqItem Then
          coll.Add(CType(myRow.Tag, BoqItem))
        End If
      Next
      Return coll
    End Function
    Private Sub tgItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Click
      WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Items"
    Private Sub RefreshItems()
      InitProgress()
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_tableInitialized = False
      Unwire()
      Me.m_entity.PopulateItemListing(m_treeManager, AddressOf WorkDone)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Done()
      Wire()
      Me.m_tableInitialized = True
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.tgItem.RefreshHeights()
      'ให้เลือกที่ cell ที่ต้องการ เพราะไปอยู่ col แรกมันจะเผลอ wheel ได้
      Me.tgItem.CurrentCell = New DataGridCell(Me.tgItem.CurrentRowIndex, 2)
    End Sub
    Dim myIndex As Integer
    Private Sub ReIndex()
      If Me.m_treeManager.Treetable.Childs.Count = 0 Then
        Return
      End If
      myIndex = 0
      TreeRow.TraverseRow(Me.m_treeManager.Treetable.Childs(0), AddressOf SetLine)
    End Sub
    Private Sub SetLine(ByVal row As TreeRow)
      myIndex += 1
      row("boqi_linenumber") = myIndex
      If TypeOf row.Parent Is TreeRow Then
        CType(row.Parent, TreeRow)("boqi_linenumber") = row.Index
      End If
    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

    Private Sub ibtnZoomChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomChart.Click
      If Me.tgItem.Size.Height = 232 Then
        Me.tgItem.Size = New Size(Me.tgItem.Width, Me.Height - Me.tgItem.Location.Y + 60)
      Else
        Me.tgItem.Size = New Size(Me.tgItem.Width, 232)
      End If
    End Sub

#Region "Sumarize"
    Private m_level As Integer
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      If m_level > 0 Then
        m_level -= 1
        Me.m_entity.WBSCollection.Sumarize(m_level)
        RefreshItems()
        'Me.m_treeManager.Treetable.Summarize(m_level)
        Me.lblLevel.Text = m_level.ToString()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      If m_level < Me.m_entity.WBSCollection.GetMaxLevel + 1 Then
        m_level += 1
        Me.m_entity.WBSCollection.Sumarize(m_level)
        RefreshItems()
        'Me.m_treeManager.Treetable.Summarize(m_level)
        Me.lblLevel.Text = m_level.ToString()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged

    End Sub

    Private Sub ibtnSaveAsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSaveAsExcel.Click
      Try
        Dim Excel As Object = CreateObject("Excel.Application")
        If Excel Is Nothing Then
          MessageBox.Show("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.")
          Return
        End If
        Dim locale As String = "en-US"
        Dim obj As Object = Configuration.GetConfig("ExcelLocale")
        If IsDBNull(obj) AndAlso obj <> Nothing Then
          locale = obj.ToString()
        End If
        Dim oldCI As System.Globalization.CultureInfo = _
        System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo(locale)

        Dim ext As String = ".xlsx"
        If CInt(Excel.Version) < 12 Then
          ext = ".xls"
        End If

        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim thePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQItems" & ext
        thePath = Microsoft.VisualBasic.InputBox("เลือก path", "เลือก path", thePath)
        If thePath.Length = 0 Then
          thePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQItems" & ext
        End If

        With Excel
          .SheetsInNewWorkbook = 1
          Dim oDoc As Object = .Workbooks.Add()
          .Worksheets(1).Select()

          Dim i As Integer = 1
          For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            .cells(1, i).value = col.HeaderText.Replace("@", "UnitPrice")
            .cells(1, i).EntireRow.Font.Bold = True
            i += 1
          Next
          i = 2
          For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
            Dim j As Integer = 1
            For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              If Not row.IsNull(col.MappingName) Then
                If TypeOf col Is DataGridComboColumn Then
                  .Cells(i, j).Value = New BOQItemType(row(col.MappingName)).Description
                Else
                  .Cells(i, j).Value = row(col.MappingName).ToString()
                End If
              End If
              j += 1
            Next
            i += 1
          Next
          .ActiveCell.Worksheet.SaveAs(thePath)

          oDoc.Close()
          .Quit()
          oDoc = Nothing
          Excel = Nothing
        End With


        MessageBox.Show("Items are exported to Excel Succesfully in '" & thePath & "'")
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

      '' The excel is created and opened for insert value. We most close this excel using this system
      'Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
      'For Each i As Process In pro
      '  i.Kill()
      'Next

    End Sub

    Private Sub btnLockBoq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockBoq.Click
      If m_entity.Locked Then
        m_entity.Locked = False
      Else
        m_entity.Locked = True
      End If

      UpdateEntityProperties()
    End Sub
  End Class
End Namespace