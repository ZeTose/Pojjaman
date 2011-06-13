Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ToolLotDetailView
    'Inherits UserControl
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblToollotCode As System.Windows.Forms.Label
    Friend WithEvents TxtToollotBuycost As System.Windows.Forms.TextBox
    Friend WithEvents Grbeqi As System.Windows.Forms.GroupBox
    Friend WithEvents TxtToollotbrand As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents txtToollotbuydoccode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Public WithEvents lv As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblRefDocAmount As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblToolCode As System.Windows.Forms.Label
    Friend WithEvents lblToolName As System.Windows.Forms.Label
    Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
    Friend WithEvents lblAsset As System.Windows.Forms.Label
    Friend WithEvents btnAssetFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToollotBuyQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotRemainQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotRemainCost As System.Windows.Forms.TextBox
    Friend WithEvents lblRemianQTY As System.Windows.Forms.Label
    Friend WithEvents lblRefDocUnitCost As System.Windows.Forms.Label
    Friend WithEvents lblRefDocQty As System.Windows.Forms.Label
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents txtToollotWriteOff As System.Windows.Forms.TextBox
    Friend WithEvents lblWriteOff As System.Windows.Forms.Label
    Friend WithEvents txtToollotBuyDate As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtToollotName As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents lblReference As System.Windows.Forms.Label
    Friend WithEvents btnPurchaseFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnNewLot As System.Windows.Forms.Button
    Friend WithEvents ibtnSave As System.Windows.Forms.Button
    Friend WithEvents ibtnDel As System.Windows.Forms.Button
    Friend WithEvents btnLotRef As System.Windows.Forms.Button
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolLotDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtToollotCode = New System.Windows.Forms.TextBox()
      Me.TxtToollotName = New System.Windows.Forms.TextBox()
      Me.lblToolCode = New System.Windows.Forms.Label()
      Me.lblToolName = New System.Windows.Forms.Label()
      Me.lv = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.Grbeqi = New System.Windows.Forms.GroupBox()
      Me.ibtnDel = New System.Windows.Forms.Button()
      Me.ibtnNewLot = New System.Windows.Forms.Button()
      Me.ibtnSave = New System.Windows.Forms.Button()
      Me.btnPurchaseFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToollotBuyQTY = New System.Windows.Forms.TextBox()
      Me.txtToollotBuyDate = New System.Windows.Forms.TextBox()
      Me.txtToollotWriteOff = New System.Windows.Forms.TextBox()
      Me.txtToollotRemainQTY = New System.Windows.Forms.TextBox()
      Me.txtReference = New System.Windows.Forms.TextBox()
      Me.txtToollotUnitCost = New System.Windows.Forms.TextBox()
      Me.txtToollotRemainCost = New System.Windows.Forms.TextBox()
      Me.txtDescription = New System.Windows.Forms.TextBox()
      Me.lblBrand = New System.Windows.Forms.Label()
      Me.lblWriteOff = New System.Windows.Forms.Label()
      Me.lblReference = New System.Windows.Forms.Label()
      Me.lblRemianQTY = New System.Windows.Forms.Label()
      Me.lblRefDocUnitCost = New System.Windows.Forms.Label()
      Me.lblRefDocQty = New System.Windows.Forms.Label()
      Me.lblUnitCost = New System.Windows.Forms.Label()
      Me.lblDescription = New System.Windows.Forms.Label()
      Me.TxtToollotbrand = New System.Windows.Forms.TextBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblToollotCode = New System.Windows.Forms.Label()
      Me.lblRefDocAmount = New System.Windows.Forms.Label()
      Me.lblRefDocDate = New System.Windows.Forms.Label()
      Me.txtToollotbuydoccode = New System.Windows.Forms.TextBox()
      Me.lblAsset = New System.Windows.Forms.Label()
      Me.lblRefDoc = New System.Windows.Forms.Label()
      Me.btnAssetFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAssetName = New System.Windows.Forms.TextBox()
      Me.txtAssetCode = New System.Windows.Forms.TextBox()
      Me.TxtToollotBuycost = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnLotRef = New System.Windows.Forms.Button()
      Me.grbDetail.SuspendLayout()
      Me.Grbeqi.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.txtToollotCode)
      Me.grbDetail.Controls.Add(Me.TxtToollotName)
      Me.grbDetail.Controls.Add(Me.lblToolCode)
      Me.grbDetail.Controls.Add(Me.lblToolName)
      Me.grbDetail.Controls.Add(Me.lv)
      Me.grbDetail.Controls.Add(Me.Grbeqi)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(995, 634)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ชื่อเครื่องจักร :"
      '
      'txtToollotCode
      '
      Me.Validator.SetDataType(Me.txtToollotCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotCode, "")
      Me.txtToollotCode.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtToollotCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotCode, System.Drawing.Color.Empty)
      Me.txtToollotCode.Location = New System.Drawing.Point(130, 28)
      Me.Validator.SetMinValue(Me.txtToollotCode, "")
      Me.txtToollotCode.Name = "txtToollotCode"
      Me.txtToollotCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotCode, "")
      Me.Validator.SetRequired(Me.txtToollotCode, False)
      Me.txtToollotCode.Size = New System.Drawing.Size(139, 21)
      Me.txtToollotCode.TabIndex = 0
      '
      'TxtToollotName
      '
      Me.Validator.SetDataType(Me.TxtToollotName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotName, "")
      Me.TxtToollotName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotName, System.Drawing.Color.Empty)
      Me.TxtToollotName.Location = New System.Drawing.Point(130, 51)
      Me.Validator.SetMinValue(Me.TxtToollotName, "")
      Me.TxtToollotName.Name = "TxtToollotName"
      Me.TxtToollotName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.TxtToollotName, "")
      Me.Validator.SetRequired(Me.TxtToollotName, False)
      Me.TxtToollotName.Size = New System.Drawing.Size(301, 21)
      Me.TxtToollotName.TabIndex = 1
      '
      'lblToolCode
      '
      Me.lblToolCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolCode.ForeColor = System.Drawing.Color.Black
      Me.lblToolCode.Location = New System.Drawing.Point(20, 30)
      Me.lblToolCode.Name = "lblToolCode"
      Me.lblToolCode.Size = New System.Drawing.Size(107, 18)
      Me.lblToolCode.TabIndex = 334
      Me.lblToolCode.Text = "รหัสชนิดเครื่องมือ :"
      Me.lblToolCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblToolName
      '
      Me.lblToolName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolName.ForeColor = System.Drawing.Color.Black
      Me.lblToolName.Location = New System.Drawing.Point(20, 53)
      Me.lblToolName.Name = "lblToolName"
      Me.lblToolName.Size = New System.Drawing.Size(107, 18)
      Me.lblToolName.TabIndex = 337
      Me.lblToolName.Text = "ชื่อชนิดเครื่องมือ :"
      Me.lblToolName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lv
      '
      Me.lv.Alignment = System.Windows.Forms.ListViewAlignment.Left
      Me.lv.AllowSort = True
      Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lv.FullRowSelect = True
      Me.lv.GridLines = True
      Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lv.HideSelection = False
      Me.lv.Location = New System.Drawing.Point(437, 101)
      Me.lv.Name = "lv"
      Me.lv.Size = New System.Drawing.Size(552, 516)
      Me.lv.SortIndex = -1
      Me.lv.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lv.TabIndex = 323
      Me.lv.UseCompatibleStateImageBehavior = False
      Me.lv.View = System.Windows.Forms.View.Details
      '
      'Grbeqi
      '
      Me.Grbeqi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Grbeqi.Controls.Add(Me.btnLotRef)
      Me.Grbeqi.Controls.Add(Me.ibtnDel)
      Me.Grbeqi.Controls.Add(Me.ibtnNewLot)
      Me.Grbeqi.Controls.Add(Me.ibtnSave)
      Me.Grbeqi.Controls.Add(Me.btnPurchaseFind)
      Me.Grbeqi.Controls.Add(Me.txtToollotBuyQTY)
      Me.Grbeqi.Controls.Add(Me.txtToollotBuyDate)
      Me.Grbeqi.Controls.Add(Me.txtToollotWriteOff)
      Me.Grbeqi.Controls.Add(Me.txtToollotRemainQTY)
      Me.Grbeqi.Controls.Add(Me.txtReference)
      Me.Grbeqi.Controls.Add(Me.txtToollotUnitCost)
      Me.Grbeqi.Controls.Add(Me.txtToollotRemainCost)
      Me.Grbeqi.Controls.Add(Me.txtDescription)
      Me.Grbeqi.Controls.Add(Me.lblBrand)
      Me.Grbeqi.Controls.Add(Me.lblWriteOff)
      Me.Grbeqi.Controls.Add(Me.lblReference)
      Me.Grbeqi.Controls.Add(Me.lblRemianQTY)
      Me.Grbeqi.Controls.Add(Me.lblRefDocUnitCost)
      Me.Grbeqi.Controls.Add(Me.lblRefDocQty)
      Me.Grbeqi.Controls.Add(Me.lblUnitCost)
      Me.Grbeqi.Controls.Add(Me.lblDescription)
      Me.Grbeqi.Controls.Add(Me.TxtToollotbrand)
      Me.Grbeqi.Controls.Add(Me.cmbCode)
      Me.Grbeqi.Controls.Add(Me.chkAutorun)
      Me.Grbeqi.Controls.Add(Me.lblToollotCode)
      Me.Grbeqi.Controls.Add(Me.lblRefDocAmount)
      Me.Grbeqi.Controls.Add(Me.lblRefDocDate)
      Me.Grbeqi.Controls.Add(Me.txtToollotbuydoccode)
      Me.Grbeqi.Controls.Add(Me.lblAsset)
      Me.Grbeqi.Controls.Add(Me.lblRefDoc)
      Me.Grbeqi.Controls.Add(Me.btnAssetFind)
      Me.Grbeqi.Controls.Add(Me.txtAssetName)
      Me.Grbeqi.Controls.Add(Me.txtAssetCode)
      Me.Grbeqi.Controls.Add(Me.TxtToollotBuycost)
      Me.Grbeqi.Location = New System.Drawing.Point(9, 95)
      Me.Grbeqi.Name = "Grbeqi"
      Me.Grbeqi.Size = New System.Drawing.Size(422, 522)
      Me.Grbeqi.TabIndex = 0
      Me.Grbeqi.TabStop = False
      Me.Grbeqi.Text = "รายละเอียดเครื่องจักรรายตัว"
      '
      'ibtnDel
      '
      Me.ibtnDel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.ibtnDel.Location = New System.Drawing.Point(285, 389)
      Me.ibtnDel.Name = "ibtnDel"
      Me.ibtnDel.Size = New System.Drawing.Size(80, 29)
      Me.ibtnDel.TabIndex = 16
      Me.ibtnDel.Text = "ลบ Lot "
      Me.ibtnDel.UseVisualStyleBackColor = True
      '
      'ibtnNewLot
      '
      Me.ibtnNewLot.ForeColor = System.Drawing.SystemColors.WindowText
      Me.ibtnNewLot.Location = New System.Drawing.Point(121, 389)
      Me.ibtnNewLot.Name = "ibtnNewLot"
      Me.ibtnNewLot.Size = New System.Drawing.Size(80, 29)
      Me.ibtnNewLot.TabIndex = 16
      Me.ibtnNewLot.Text = "เพิ่ม Lot ใหม่"
      Me.ibtnNewLot.UseVisualStyleBackColor = True
      '
      'ibtnSave
      '
      Me.ibtnSave.ForeColor = System.Drawing.SystemColors.WindowText
      Me.ibtnSave.Location = New System.Drawing.Point(203, 389)
      Me.ibtnSave.Name = "ibtnSave"
      Me.ibtnSave.Size = New System.Drawing.Size(80, 29)
      Me.ibtnSave.TabIndex = 15
      Me.ibtnSave.Text = "บันทึก Lot"
      Me.ibtnSave.UseVisualStyleBackColor = True
      '
      'btnPurchaseFind
      '
      Me.btnPurchaseFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPurchaseFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPurchaseFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPurchaseFind.Location = New System.Drawing.Point(233, 77)
      Me.btnPurchaseFind.Name = "btnPurchaseFind"
      Me.btnPurchaseFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPurchaseFind.TabIndex = 341
      Me.btnPurchaseFind.TabStop = False
      Me.btnPurchaseFind.ThemedImage = CType(resources.GetObject("btnPurchaseFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToollotBuyQTY
      '
      Me.Validator.SetDataType(Me.txtToollotBuyQTY, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotBuyQTY, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotBuyQTY, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotBuyQTY, System.Drawing.Color.Empty)
      Me.txtToollotBuyQTY.Location = New System.Drawing.Point(121, 125)
      Me.Validator.SetMinValue(Me.txtToollotBuyQTY, "")
      Me.txtToollotBuyQTY.Name = "txtToollotBuyQTY"
      Me.Validator.SetRegularExpression(Me.txtToollotBuyQTY, "")
      Me.Validator.SetRequired(Me.txtToollotBuyQTY, False)
      Me.txtToollotBuyQTY.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotBuyQTY.TabIndex = 5
      Me.txtToollotBuyQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotBuyDate
      '
      Me.Validator.SetDataType(Me.txtToollotBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotBuyDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotBuyDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotBuyDate, System.Drawing.Color.Empty)
      Me.txtToollotBuyDate.Location = New System.Drawing.Point(121, 101)
      Me.Validator.SetMinValue(Me.txtToollotBuyDate, "")
      Me.txtToollotBuyDate.Name = "txtToollotBuyDate"
      Me.txtToollotBuyDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotBuyDate, "")
      Me.Validator.SetRequired(Me.txtToollotBuyDate, False)
      Me.txtToollotBuyDate.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotBuyDate.TabIndex = 4
      '
      'txtToollotWriteOff
      '
      Me.Validator.SetDataType(Me.txtToollotWriteOff, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotWriteOff, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotWriteOff, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotWriteOff, System.Drawing.Color.Empty)
      Me.txtToollotWriteOff.Location = New System.Drawing.Point(121, 275)
      Me.Validator.SetMinValue(Me.txtToollotWriteOff, "")
      Me.txtToollotWriteOff.Name = "txtToollotWriteOff"
      Me.txtToollotWriteOff.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotWriteOff, "")
      Me.Validator.SetRequired(Me.txtToollotWriteOff, False)
      Me.txtToollotWriteOff.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotWriteOff.TabIndex = 10
      Me.txtToollotWriteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotRemainQTY
      '
      Me.Validator.SetDataType(Me.txtToollotRemainQTY, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotRemainQTY, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotRemainQTY, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotRemainQTY, System.Drawing.Color.Empty)
      Me.txtToollotRemainQTY.Location = New System.Drawing.Point(121, 300)
      Me.Validator.SetMinValue(Me.txtToollotRemainQTY, "")
      Me.txtToollotRemainQTY.Name = "txtToollotRemainQTY"
      Me.txtToollotRemainQTY.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotRemainQTY, "")
      Me.Validator.SetRequired(Me.txtToollotRemainQTY, False)
      Me.txtToollotRemainQTY.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotRemainQTY.TabIndex = 11
      Me.txtToollotRemainQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtReference
      '
      Me.Validator.SetDataType(Me.txtReference, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReference, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReference, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReference, System.Drawing.Color.Empty)
      Me.txtReference.Location = New System.Drawing.Point(121, 351)
      Me.Validator.SetMinValue(Me.txtReference, "")
      Me.txtReference.Name = "txtReference"
      Me.txtReference.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtReference, "")
      Me.Validator.SetRequired(Me.txtReference, False)
      Me.txtReference.Size = New System.Drawing.Size(254, 21)
      Me.txtReference.TabIndex = 13
      '
      'txtToollotUnitCost
      '
      Me.Validator.SetDataType(Me.txtToollotUnitCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotUnitCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotUnitCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotUnitCost, System.Drawing.Color.Empty)
      Me.txtToollotUnitCost.Location = New System.Drawing.Point(121, 150)
      Me.Validator.SetMinValue(Me.txtToollotUnitCost, "")
      Me.txtToollotUnitCost.Name = "txtToollotUnitCost"
      Me.Validator.SetRegularExpression(Me.txtToollotUnitCost, "")
      Me.Validator.SetRequired(Me.txtToollotUnitCost, False)
      Me.txtToollotUnitCost.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotUnitCost.TabIndex = 6
      Me.txtToollotUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotRemainCost
      '
      Me.Validator.SetDataType(Me.txtToollotRemainCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotRemainCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotRemainCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotRemainCost, System.Drawing.Color.Empty)
      Me.txtToollotRemainCost.Location = New System.Drawing.Point(121, 325)
      Me.Validator.SetMinValue(Me.txtToollotRemainCost, "")
      Me.txtToollotRemainCost.Name = "txtToollotRemainCost"
      Me.txtToollotRemainCost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotRemainCost, "")
      Me.Validator.SetRequired(Me.txtToollotRemainCost, False)
      Me.txtToollotRemainCost.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotRemainCost.TabIndex = 12
      Me.txtToollotRemainCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDescription
      '
      Me.Validator.SetDataType(Me.txtDescription, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDescription, "")
      Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDescription, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDescription, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDescription, System.Drawing.Color.Empty)
      Me.txtDescription.Location = New System.Drawing.Point(121, 225)
      Me.txtDescription.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtDescription, "")
      Me.txtDescription.Multiline = True
      Me.txtDescription.Name = "txtDescription"
      Me.Validator.SetRegularExpression(Me.txtDescription, "")
      Me.Validator.SetRequired(Me.txtDescription, False)
      Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDescription.Size = New System.Drawing.Size(254, 47)
      Me.txtDescription.TabIndex = 9
      '
      'lblBrand
      '
      Me.lblBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBrand.ForeColor = System.Drawing.Color.Black
      Me.lblBrand.Location = New System.Drawing.Point(6, 201)
      Me.lblBrand.Name = "lblBrand"
      Me.lblBrand.Size = New System.Drawing.Size(112, 18)
      Me.lblBrand.TabIndex = 4
      Me.lblBrand.Text = "Brand :"
      Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWriteOff
      '
      Me.lblWriteOff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWriteOff.ForeColor = System.Drawing.Color.Black
      Me.lblWriteOff.Location = New System.Drawing.Point(6, 275)
      Me.lblWriteOff.Name = "lblWriteOff"
      Me.lblWriteOff.Size = New System.Drawing.Size(112, 18)
      Me.lblWriteOff.TabIndex = 5
      Me.lblWriteOff.Text = "Wirte Off  :"
      Me.lblWriteOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblReference
      '
      Me.lblReference.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReference.ForeColor = System.Drawing.Color.Black
      Me.lblReference.Location = New System.Drawing.Point(6, 352)
      Me.lblReference.Name = "lblReference"
      Me.lblReference.Size = New System.Drawing.Size(112, 18)
      Me.lblReference.TabIndex = 5
      Me.lblReference.Text = "Reference :"
      Me.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemianQTY
      '
      Me.lblRemianQTY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemianQTY.ForeColor = System.Drawing.Color.Black
      Me.lblRemianQTY.Location = New System.Drawing.Point(6, 300)
      Me.lblRemianQTY.Name = "lblRemianQTY"
      Me.lblRemianQTY.Size = New System.Drawing.Size(112, 18)
      Me.lblRemianQTY.TabIndex = 5
      Me.lblRemianQTY.Text = "จำนวนคงเหลือ  :"
      Me.lblRemianQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocUnitCost
      '
      Me.lblRefDocUnitCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocUnitCost.ForeColor = System.Drawing.Color.Black
      Me.lblRefDocUnitCost.Location = New System.Drawing.Point(6, 325)
      Me.lblRefDocUnitCost.Name = "lblRefDocUnitCost"
      Me.lblRefDocUnitCost.Size = New System.Drawing.Size(112, 18)
      Me.lblRefDocUnitCost.TabIndex = 5
      Me.lblRefDocUnitCost.Text = "ต้นทุนคงเหลือ :"
      Me.lblRefDocUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocQty
      '
      Me.lblRefDocQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocQty.ForeColor = System.Drawing.Color.Black
      Me.lblRefDocQty.Location = New System.Drawing.Point(6, 128)
      Me.lblRefDocQty.Name = "lblRefDocQty"
      Me.lblRefDocQty.Size = New System.Drawing.Size(112, 18)
      Me.lblRefDocQty.TabIndex = 5
      Me.lblRefDocQty.Text = "จำนวนซื้อ :"
      Me.lblRefDocQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblUnitCost
      '
      Me.lblUnitCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnitCost.ForeColor = System.Drawing.Color.Black
      Me.lblUnitCost.Location = New System.Drawing.Point(6, 153)
      Me.lblUnitCost.Name = "lblUnitCost"
      Me.lblUnitCost.Size = New System.Drawing.Size(112, 18)
      Me.lblUnitCost.TabIndex = 5
      Me.lblUnitCost.Text = "ต้นทุน/หน่วย :"
      Me.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDescription
      '
      Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDescription.ForeColor = System.Drawing.Color.Black
      Me.lblDescription.Location = New System.Drawing.Point(6, 236)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(112, 18)
      Me.lblDescription.TabIndex = 5
      Me.lblDescription.Text = "Description :"
      Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'TxtToollotbrand
      '
      Me.Validator.SetDataType(Me.TxtToollotbrand, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotbrand, "")
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotbrand, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotbrand, System.Drawing.Color.Empty)
      Me.TxtToollotbrand.Location = New System.Drawing.Point(121, 201)
      Me.Validator.SetMinValue(Me.TxtToollotbrand, "")
      Me.TxtToollotbrand.Name = "TxtToollotbrand"
      Me.Validator.SetRegularExpression(Me.TxtToollotbrand, "")
      Me.Validator.SetRequired(Me.TxtToollotbrand, False)
      Me.TxtToollotbrand.Size = New System.Drawing.Size(112, 21)
      Me.TxtToollotbrand.TabIndex = 8
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(121, 29)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(145, 21)
      Me.cmbCode.TabIndex = 1
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(266, 29)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 334
      Me.chkAutorun.TabStop = False
      '
      'lblToollotCode
      '
      Me.lblToollotCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToollotCode.ForeColor = System.Drawing.Color.Black
      Me.lblToollotCode.Location = New System.Drawing.Point(9, 31)
      Me.lblToollotCode.Name = "lblToollotCode"
      Me.lblToollotCode.Size = New System.Drawing.Size(111, 18)
      Me.lblToollotCode.TabIndex = 0
      Me.lblToollotCode.Text = "รหัส :"
      Me.lblToollotCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocAmount
      '
      Me.lblRefDocAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocAmount.ForeColor = System.Drawing.Color.Black
      Me.lblRefDocAmount.Location = New System.Drawing.Point(6, 175)
      Me.lblRefDocAmount.Name = "lblRefDocAmount"
      Me.lblRefDocAmount.Size = New System.Drawing.Size(112, 18)
      Me.lblRefDocAmount.TabIndex = 4
      Me.lblRefDocAmount.Text = "มูลค่าซื้อ :"
      Me.lblRefDocAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblRefDocDate.Location = New System.Drawing.Point(6, 103)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(114, 18)
      Me.lblRefDocDate.TabIndex = 5
      Me.lblRefDocDate.Text = "วันที่ซื้อในเอกสาร :"
      Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToollotbuydoccode
      '
      Me.Validator.SetDataType(Me.txtToollotbuydoccode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotbuydoccode, "")
      Me.txtToollotbuydoccode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToollotbuydoccode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotbuydoccode, System.Drawing.Color.Empty)
      Me.txtToollotbuydoccode.Location = New System.Drawing.Point(121, 77)
      Me.Validator.SetMinValue(Me.txtToollotbuydoccode, "")
      Me.txtToollotbuydoccode.Name = "txtToollotbuydoccode"
      Me.txtToollotbuydoccode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotbuydoccode, "")
      Me.Validator.SetRequired(Me.txtToollotbuydoccode, False)
      Me.txtToollotbuydoccode.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotbuydoccode.TabIndex = 3
      '
      'lblAsset
      '
      Me.lblAsset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAsset.ForeColor = System.Drawing.Color.Black
      Me.lblAsset.Location = New System.Drawing.Point(6, 55)
      Me.lblAsset.Name = "lblAsset"
      Me.lblAsset.Size = New System.Drawing.Size(114, 18)
      Me.lblAsset.TabIndex = 0
      Me.lblAsset.Text = "สินทรัพย์ :"
      Me.lblAsset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.ForeColor = System.Drawing.Color.Black
      Me.lblRefDoc.Location = New System.Drawing.Point(6, 79)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(114, 18)
      Me.lblRefDoc.TabIndex = 3
      Me.lblRefDoc.Text = "เลขที่เอกสารซื้อ :"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAssetFind
      '
      Me.btnAssetFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetFind.Location = New System.Drawing.Point(389, 52)
      Me.btnAssetFind.Name = "btnAssetFind"
      Me.btnAssetFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAssetFind.TabIndex = 340
      Me.btnAssetFind.TabStop = False
      Me.btnAssetFind.ThemedImage = CType(resources.GetObject("btnAssetFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAssetName
      '
      Me.Validator.SetDataType(Me.txtAssetName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetName, "")
      Me.txtAssetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.txtAssetName.Location = New System.Drawing.Point(233, 53)
      Me.Validator.SetMinValue(Me.txtAssetName, "")
      Me.txtAssetName.Name = "txtAssetName"
      Me.txtAssetName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetName, "")
      Me.Validator.SetRequired(Me.txtAssetName, False)
      Me.txtAssetName.Size = New System.Drawing.Size(155, 21)
      Me.txtAssetName.TabIndex = 14
      Me.txtAssetName.TabStop = False
      '
      'txtAssetCode
      '
      Me.Validator.SetDataType(Me.txtAssetCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCode, "")
      Me.txtAssetCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.txtAssetCode.Location = New System.Drawing.Point(121, 53)
      Me.Validator.SetMinValue(Me.txtAssetCode, "")
      Me.txtAssetCode.Name = "txtAssetCode"
      Me.Validator.SetRegularExpression(Me.txtAssetCode, "")
      Me.Validator.SetRequired(Me.txtAssetCode, False)
      Me.txtAssetCode.Size = New System.Drawing.Size(112, 21)
      Me.txtAssetCode.TabIndex = 2
      '
      'TxtToollotBuycost
      '
      Me.Validator.SetDataType(Me.TxtToollotBuycost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotBuycost, "")
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotBuycost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotBuycost, System.Drawing.Color.Empty)
      Me.TxtToollotBuycost.Location = New System.Drawing.Point(121, 175)
      Me.Validator.SetMinValue(Me.TxtToollotBuycost, "")
      Me.TxtToollotBuycost.Name = "TxtToollotBuycost"
      Me.TxtToollotBuycost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.TxtToollotBuycost, "")
      Me.Validator.SetRequired(Me.TxtToollotBuycost, False)
      Me.TxtToollotBuycost.Size = New System.Drawing.Size(112, 21)
      Me.TxtToollotBuycost.TabIndex = 7
      Me.TxtToollotBuycost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'btnLotRef
      '
      Me.btnLotRef.ForeColor = System.Drawing.SystemColors.WindowText
      Me.btnLotRef.Location = New System.Drawing.Point(35, 389)
      Me.btnLotRef.Name = "btnLotRef"
      Me.btnLotRef.Size = New System.Drawing.Size(80, 29)
      Me.btnLotRef.TabIndex = 342
      Me.btnLotRef.Text = "Reference"
      Me.btnLotRef.UseVisualStyleBackColor = True
      '
      'ToolLotDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ToolLotDetailView"
      Me.Size = New System.Drawing.Size(1010, 650)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.Grbeqi.ResumeLayout(False)
      Me.Grbeqi.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblAssetStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAssetStatus}")

      'Me.grbStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbStatus}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.grbDetail}") 'ข้อมูลเครื่องมือ

      lblToolCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblToolCode}") 'รหัสเครื่องมือ :
      Me.Validator.SetDisplayName(cmbCode, lblToolCode.Text)
      lblToolName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblToolName}") 'ชื่อเครื่องมือ :
      Grbeqi.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.Grbeqi}") 'รายละเอียด Lot เครื่องมือ
      lblToollotCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblToollotCode}") 'Lot No. :

      lblAsset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblAsset}") 'สินทรัพย์ :
      lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRefDoc}") 'เลขที่เอกสารซื้อ :
      lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRefDocDate}") 'วันที่เอกสารซื้อ :
      lblRefDocQty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRefDocQty}") 'จำนวนซื้อ : :
      lblUnitCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRefDocUnitCost}") 'ต้นทุน/หน่วย :
      lblRefDocAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRefDocAmount}") 'มูลค่า :

      lblRemianQTY.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblRemianQTY}") 'จำนวนคงเหลือ : :
      lblRefDocUnitCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblUnitCost}") 'ต้นทุนคงเหลือ :
      lblBrand.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblBrand}") 'Brand :

      lblDescription.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblDescription}") 'รายละเอียด :
      lblWriteOff.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblWriteOff}") 'Write Off :
      lblReference.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.lblReference}") 'สถานะถูกอ้างอิง :


    End Sub
#End Region

#Region "Member"
    Private m_entity As Tool  'IHasEquipmentItemCollection 'EquipmentItem
    'Private m_refDoc As IHasEquipment
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_StringParserService As StringParserService

#End Region

#Region "Constructor"

    Public Sub New()
      MyBase.New()
      Try
        Me.InitializeComponent()
      Catch ex As Exception
        MessageBox.Show(ex.InnerException.ToString)
      End Try
      Me.Initialize()
      Me.EventWiring()
      Me.SetLabelText()
      Me.UpdateEntityProperties()

    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As ToolLot
      Get
        'If lv.SelectedItems.Count = 0 Then
        '  Return Nothing
        'End If
        'Return CType(lv.SelectedItems(0).Tag, EquipmentItem)

        'If lv.Items.Count > 0 Then
        '  Dim lvi As ListViewItem = lv.SelectedItems.
        '  If Not lvi.Tag Is Nothing Then
        '    If TypeOf lvi.Tag Is EquipmentItem Then
        '      Return CType(lvi.Tag, EquipmentItem)
        '    End If
        '  End If
        'End If
        If Me.m_entity Is Nothing Then
          Return Nothing
        End If

        'Return Nothing
        If Not Me.m_entity Is Nothing AndAlso Not Me.m_entity.ToolLot Is Nothing Then
          Return Me.m_entity.ToolLot
        Else
          If Me.m_entity.ItemCollection.Count > 0 Then
            Me.m_entity.ToolLot = Me.m_entity.ItemCollection(0)
            Return Me.m_entity.ToolLot
          End If
        End If
        Return Nothing
      End Get
      'Get
      '  Dim row As TreeRow = Me.m_treeManager.SelectedRow
      '  If row Is Nothing Then
      '    Return Nothing
      '  End If
      '  If Not TypeOf row.Tag Is EquipmentItem Then
      '    Return Nothing
      '  End If
      '  Return CType(row.Tag, EquipmentItem)
      'End Get
    End Property
#End Region

#Region "Method"
#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region
    Public Overrides Sub Initialize()
      SetLVHeader()
      ' กำหนดการคำนวณค่าเสื่อมราคา
      'AssetCalcType.ListCodeDescriptionInComboBox(cmbCalcType, "asset_calctype")
      ' กำหนดอัตราค่าเช่าพื้นฐาน
    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overloads Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString 'พี่ดำมาแก้คืนว่ะ
      'Return dt.ToString("dd/MM/yyyy")  ' เหน่งมาแก้นะครับ
    End Function
    Public Overloads Function MinDateToNow(ByVal dt As Date) As Date
      If dt.Equals(Date.MinValue) Then
        dt = Now
      End If
      Return dt
    End Function
    Public Overloads ReadOnly Property StringParserService() As StringParserService
      Get
        If m_StringParserService Is Nothing Then
          m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_StringParserService
      End Get
    End Property
    Public Overrides Sub UpdateEntityProperties()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Me.m_isInitialized = False

      'If Me.m_entity.ToolLot Is Nothing Then
      '  Me.m_entity.ToolLot = New ToolLot
      '  Me.m_entity.ToolLot.Autogen = True
      'End If

      'ClearDetail()
      Me.ClearAllText()

      'm_chkAutorunCheckChanged = True
      'Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
      'UpdateAutogenStatus()
      Me.m_entity.ToolLot.Autogen = True
      'm_chkAutorunCheckChanged = False

      'Dim doc As ToolLot = Me.CurrentTagItem
      'If doc Is Nothing Then
      '  doc = New ToolLot
      '  Me.m_entity.ItemCollection.Add(doc)
      '  doc.Autogen = True
      'End If

      ''autogencode
      'CmbToolCode.Text = m_entity.Code
      'Me.m_oldEqCode = Me.m_entity.Code
      'Me.chkEqAutoRun.Checked = Me.m_entity.AutoGen
      'Me.UpdateEqAutogenStatus()

      'cmbCode.Text = doc.Code
      'Me.m_oldCode = doc.Code
      'Me.chkAutorun.Checked = doc.Autogen
      'Me.UpdateAutogenStatus()

      'Dim row As TreeRow = Nothing
      'Dim eqitem As ToolLot = Nothing


      Me.RefreshTextData()
      Me.RefreshListViewData()
      TxtToollotName.Text = m_entity.Name
      txtToollotCode.Text = m_entity.Code

      SetLabelText()
      CheckFormEnable()
      Me.m_isInitialized = True
    End Sub
    'Private Sub RefreshTextData()
    '  Me.m_isInitialized = False
    '  Dim toollotitem As ToolLot = Me.CurrentTagItem
    '  'Me.ClearItemOnly()
    '  If Not toollotitem Is Nothing Then
    '    cmbCode.Text = toollotitem.Code
    '    Me.m_oldCode = toollotitem.Code
    '    Me.chkAutorun.Checked = toollotitem.Autogen
    '    Me.UpdateAutogenStatus()

    '    Me.TxtToollotbrand.Text = toollotitem.Brand

    '    Me.RefreshCost(toollotitem)

    '    'dtpLastEditDate.Value = MinDateToNow(Me.m_entity.LastEditDate)
    '    'Me.txtCostcenterCode.Text = toollotitem.Costcenter.Code
    '    'Me.txtCostCenterName.Text = toollotitem.Costcenter.Name

    '    Me.txtAssetCode.Text = toollotitem.Asset.Code
    '    Me.txtAssetName.Text = toollotitem.Asset.Name

    '    'Me.txtUnitCode.Text = toollotitem.Unit.Code
    '    'Me.txtUnit.Text = toollotitem.Unit.Name
    '    'Me.txtRentalUnitCode.Text = eqitem.Rentalunit.Code
    '    'Me.txtRentalunit.Text = eqitem.Rentalunit.Name

    '    If toollotitem.Buydoc Is Nothing Then
    '      Me.txtToollotbuydoccode.Text = ""
    '    Else
    '      Me.txtToollotbuydoccode.Text = toollotitem.Buydoc.Code
    '      If Not MinDateToNull(toollotitem.Buydate, "") = "" Then
    '        Me.txtToollotBuyDate.Text = toollotitem.Buydate.ToShortDateString
    '      Else
    '        Me.txtToollotBuyDate.Text = ""
    '      End If
    '      If toollotitem.Buycost <> 0 Then
    '        Me.TxtToollotBuycost.Text = Configuration.FormatToString(toollotitem.Buycost, DigitConfig.Cost)
    '      Else
    '        Me.TxtToollotBuycost.Text = ""
    '      End If
    '    End If

    '    'TxtBuyDocDate.Text = MinDateToNull(eqitem.Buydate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
    '    'dtpBuyDocDate.Value = MinDateToNow(eqitem.Buydate)
    '    'If toollotitem.Rentalrate <> 0 Then
    '    '  Me.txtRentalRate.Text = toollotitem.Rentalrate
    '    'Else
    '    '  Me.txtRentalRate.Text = ""
    '    'End If

    '    Me.txtDescription.Text = toollotitem.Description
    '    If toollotitem.Buydoc IsNot Nothing AndAlso toollotitem.Buydoc.Originated Then
    '      Me.txtToollotBuyQTY.ReadOnly = True
    '    Else
    '      Me.txtToollotBuyQTY.ReadOnly = False
    '    End If

    '    If toollotitem.IsReferenced Then
    '      Me.txtReference.Text = Me.StringParserService.Parse("${res:Global.IsReferenced}")
    '    End If

    '    'Dim lastEdited As String = ""
    '    'If Not toollotitem.LastEditor Is Nothing Then
    '    '  lastEdited = "รหัสผู้แก้ไขล่าสุด : " & toollotitem.LastEditor.Name
    '    'End If
    '    'lastEdited &= " วันที่แก้ไขล่าสุด : " & toollotitem.LastEditDate
    '    'Me.lblLasteditdate.Text = lastEdited.Trim
    '  End If

    '  Me.m_isInitialized = True
    'End Sub
    'Public Sub RefreshCost(ByVal toollotitem As ToolLot)
    '  ' Me.m_isInitialized = False

    '  If toollotitem Is Nothing Then
    '    toollotitem = Me.CurrentTagItem
    '  End If

    '  If Not toollotitem Is Nothing Then
    '    Me.txtToollotUnitCost.Text = toollotitem.UnitCost
    '    Me.txtToollotBuyQTY.Text = toollotitem.Buyqty
    '    Me.txtToollotWriteOff.Text = toollotitem.WriteOff
    '    'Me.txtToollotRemainQTY.Text = toollotitem.RemainQTY
    '    Me.txtToollotRemainCost.Text = toollotitem.RemainCost
    '    Me.TxtToollotBuycost.Text = toollotitem.Buycost

    '    'If toollotitem.Buyqty <> 0 Then
    '    Me.txtToollotBuyQTY.Text = Configuration.FormatToString(toollotitem.Buyqty, DigitConfig.Price)
    '    'Else
    '    '  Me.txtToollotBuyQTY.Text = ""
    '    'End If

    '    Me.txtToollotUnitCost.Text = Configuration.FormatToString(toollotitem.UnitCost, DigitConfig.Price)

    '    'If toollotitem.Buycost <> 0 Then
    '    Me.TxtToollotBuycost.Text = Configuration.FormatToString(toollotitem.Buycost, DigitConfig.Price)
    '    'Else
    '    '  Me.TxtToollotBuycost.Text = ""
    '    'End If

    '    Me.txtToollotRemainQTY.Text = Configuration.FormatToString(toollotitem.Buyqty - toollotitem.WriteOff, DigitConfig.Price)

    '    'If toollotitem.WriteOff <> 0 Then
    '    Me.txtToollotWriteOff.Text = Configuration.FormatToString(toollotitem.WriteOff, DigitConfig.Price)
    '    'Else
    '    '  Me.txtToollotWriteOff.Text = ""
    '    'End If

    '    'If (toollotitem.Buyqty - toollotitem.WriteOff) = 0 AndAlso toollotitem.UnitCost = 0 Then
    '    '  Me.txtToollotRemainCost.Text = ""
    '    'ElseIf (toollotitem.Buyqty - toollotitem.WriteOff) = 0 AndAlso toollotitem.UnitCost > 0 Then
    '    '  Me.txtToollotRemainCost.Text = Configuration.FormatToString(toollotitem.UnitCost, DigitConfig.Price)
    '    'Else
    '    Me.txtToollotRemainCost.Text = Configuration.FormatToString((toollotitem.Buyqty - toollotitem.WriteOff) * toollotitem.UnitCost, DigitConfig.Price)
    '    'End If
    '  End If

    '  'Me.m_isInitialized = True
    'End Sub
    Private Sub RefreshListViewData()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Me.m_isInitialized = False
      'Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      'Me.m_treeManager.Treetable.AcceptChanges()
      'Me.m_isInitialized = True

      Dim sequence As Integer = 0
      Dim sumReqty As Decimal = 0
      Dim sumbuqty As Decimal = 0
      Dim sumwfqty As Decimal = 0
      lv.Items.Clear()
      For Each lot As ToolLot In Me.m_entity.ItemCollection

        sequence += 1

        Dim lvItem As New ListViewItem(sequence)
        lvItem.SubItems.Add(lot.Code)
        If Not lot.Asset Is Nothing Then
          Dim asset As String = lot.Asset.Code & ":" & lot.Asset.Name
          lvItem.SubItems.Add(asset)
        Else
          lvItem.SubItems.Add("")
        End If
        lvItem.SubItems.Add(Configuration.FormatToString(lot.Buyqty, DigitConfig.Qty))
        lvItem.SubItems.Add(Configuration.FormatToString(lot.WriteOff, DigitConfig.Price))
        lvItem.SubItems.Add(Configuration.FormatToString(lot.RemainQTY, DigitConfig.Qty))
        sumReqty += lot.RemainQTY
        sumbuqty += lot.Buyqty
        sumwfqty += lot.WriteOff
        If lot.IsReferenced Then
          lvItem.SubItems.Add(Me.StringParserService.Parse("${res:Global.Referenced}"))
        Else
          lvItem.SubItems.Add("")
        End If

        'If Not eqi.CurrentStatus Is Nothing Then
        '  lvItem.SubItems.Add(eqi.CurrentStatus.Description)
        'Else
        '  lvItem.SubItems.Add("")
        'End If
        'If Not eqi.Costcenter Is Nothing Then
        'lvItem.SubItems.Add(lot.Costcenter.Code & ":" & lot.Costcenter.Name)
        'End If
        lvItem.Tag = lot
        lv.Items.Add(lvItem).Tag = lot 'มีปัญหาตอนปิด
      Next
      'sum
      If m_entity.ItemCollection.Count > 0 Then
        sequence += 1
        Dim lvItem As New ListViewItem(sequence)
        lvItem.SubItems.Add("")
        lvItem.SubItems.Add("รวม")
        lvItem.SubItems.Add(Configuration.FormatToString(sumbuqty, DigitConfig.Qty))
        lvItem.SubItems.Add(Configuration.FormatToString(sumwfqty, DigitConfig.Price))
        lvItem.SubItems.Add(Configuration.FormatToString(sumReqty, DigitConfig.Qty))

        lv.Items.Add(lvItem) 'มีปัญหาตอนปิด
      End If

      Me.m_isInitialized = True
    End Sub
    Private Sub RefreshTextData()
      If Not Me.m_entity.ToolLot Is Nothing Then
        Me.txtToollotbuydoccode.Text = ""
        Me.txtToollotBuyDate.Text = ""

        m_chkAutorunCheckChanged = True
        Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
        Me.UpdateAutogenStatus()
        m_chkAutorunCheckChanged = False

        If Not Me.m_entity.ToolLot.Asset Is Nothing Then
          Me.txtAssetCode.Text = Me.m_entity.ToolLot.Asset.Code
          Me.txtAssetName.Text = Me.m_entity.ToolLot.Asset.Name
        End If

        If Me.m_entity.ToolLot.Buydoc IsNot Nothing AndAlso Me.m_entity.ToolLot.Buydoc.Code.Trim.Length > 0 Then
          Me.txtToollotbuydoccode.Text = Me.m_entity.ToolLot.Buydoc.Code
          Me.txtToollotBuyDate.Text = Me.m_entity.ToolLot.Buydate.ToShortDateString
        End If

        Me.txtToollotBuyQTY.Text = Configuration.FormatToString(Me.m_entity.ToolLot.Buyqty, DigitConfig.Price)
        Me.txtToollotUnitCost.Text = Configuration.FormatToString(Me.m_entity.ToolLot.UnitCost, DigitConfig.Price)
        Me.TxtToollotBuycost.Text = Configuration.FormatToString(Me.m_entity.ToolLot.Buycost, DigitConfig.Price)
        Me.txtToollotWriteOff.Text = Configuration.FormatToString(Me.m_entity.ToolLot.WriteOff, DigitConfig.Price)

        Me.txtToollotRemainQTY.Text = Configuration.FormatToString(Me.m_entity.ToolLot.RemainQTY, DigitConfig.Price)
        Me.txtToollotRemainCost.Text = Configuration.FormatToString(Me.m_entity.ToolLot.RemainCost, DigitConfig.Price)

        Me.TxtToollotbrand.Text = Me.m_entity.ToolLot.Brand
        Me.txtDescription.Text = Me.m_entity.ToolLot.Description

        If Me.m_entity.ToolLot.IsReferenced Then
          Me.txtReference.Text = Me.StringParserService.Parse("${res:Global.Referenced}")
        Else
          Me.txtReference.Text = ""
        End If

        If m_entity.ToolLot.Buydoc.Originated Then
          Me.txtToollotUnitCost.ReadOnly = True
        Else
          Me.txtToollotUnitCost.ReadOnly = False
        End If
      End If

    End Sub
    Protected Overrides Sub EventWiring()
      ' สถานะสินทรัพย์
      'AddHandler chkCancel.CheckedChanged, AddressOf Me.ChangeStatus
      'AddHandler chkDecay.CheckedChanged, AddressOf Me.ChangeStatus

      ' AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtToollotName.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler TxtToollotserailnumber.TextChanged, AddressOf Me.ChangeProperty
      AddHandler TxtToollotbrand.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtlToollotlicense.TextChanged, AddressOf Me.ChangeProperty

      AddHandler TxtToollotName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtToollotCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler CmbToolCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler TxtStatus.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler TxtCostcenterAddress.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler TxtStatus.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotbuydoccode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler TxtBuyDocDate.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler dtpBuyDocDate.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler TxtlastDateEdit.Validated, AddressOf Me.ChangeProperty 
      'AddHandler dtpLastEditDate.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler txtRentalRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDescription.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtCostcenterCode.TextChanged, AddressOf Me.TextHandler
      'AddHandler txtCostcenterCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAssetCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtAssetCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtUnitCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtRentalUnitCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler TxtCostcenterAddress.TextChanged, AddressOf Me.TextHandler
      'AddHandler TxtCostcenterAddress.Validated, AddressOf Me.ChangeProperty

      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler TxtToollotBuycost.TextChanged, AddressOf Me.ChangeProperty
      ''AddHandler TxtToollotBuycost.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtToollotUnitCost.TextChanged, AddressOf Me.ChangeProperty
      ''AddHandler txtToollotUnitCost.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtToollotBuyQTY.TextChanged, AddressOf Me.ChangeProperty
      ''AddHandler txtToollotBuyQTY.Validated, AddressOf Me.ChangeProperty

      AddHandler TxtToollotBuycost.Validated, AddressOf Me.ChangeProperty
      AddHandler TxtToollotBuycost.TextChanged, AddressOf Me.TextHandler


      AddHandler txtToollotRemainCost.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotRemainCost.TextChanged, AddressOf Me.TextHandler


      AddHandler txtToollotBuyQTY.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotBuyQTY.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToollotRemainQTY.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotRemainQTY.TextChanged, AddressOf Me.TextHandler


      AddHandler txtToollotWriteOff.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotWriteOff.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToollotUnitCost.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotUnitCost.TextChanged, AddressOf Me.TextHandler

    End Sub
    'Private Sub ItemTreetable_RowChanging(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    '  Me.UpdateEntityProperties()
    'End Sub
    'Public Sub ChangeStatus(ByVal sender As Object, ByVal e As EventArgs)
    '    If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '        Return
    '    End If
    '    Dim dirtyFlag As Boolean = False
    '    Select Case CType(sender, Control).Name.ToLower
    '        Case "chkcancel"
    '            Me.m_entity.Canceled = chkCancel.Checked
    '            dirtyFlag = True
    '        Case "chkdecay"
    '            If chkDecay.Checked Then
    '                Me.m_entity.Status.Value = 4
    '            Else
    '                Me.m_entity.Status.Value = 2
    '            End If
    '            dirtyFlag = True
    '    End Select
    '    Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
    '    CheckFormEnable()
    'End Sub
    'Public Sub SetValueFromAssetType()
    'If Not Me.m_entity.Type Is Nothing _
    'AndAlso Not Me.m_entity.Type.DepreAble Then
    '  'txtUnitCode.Enabled = False
    '  'txtUnitName.Enabled = False
    '  'btnUnitEdit.Enabled = False
    '  'btnUnitFind.Enabled = False
    '  'txtUnitCode.Text = Me.m_entity.Type.Unit.Code
    '  'txtUnitName.Text = Me.m_entity.Type.Unit.Name
    'Else
    '  ''txtUnitCode.Text = ""
    '  ''txtUnitName.Text = ""
    '  'txtUnitCode.Enabled = True
    '  'txtUnitName.Enabled = True
    '  'btnUnitEdit.Enabled = True
    '  'btnUnitFind.Enabled = True
    'End If
    'Dim flag As Boolean = Me.m_isInitialized
    'Me.m_isInitialized = False
    'If Not Me.m_entity.Account Is Nothing Then
    '  txtGLCode.Text = Me.m_entity.Account.Code
    '  txtGLName.Text = Me.m_entity.Account.Name
    'End If
    'If Not Me.m_entity.DepreOpeningAccount Is Nothing Then
    '  txtDepreOpeningAcctCode.Text = Me.m_entity.DepreOpeningAccount.Code
    '  txtDepreOpeningAcctName.Text = Me.m_entity.DepreOpeningAccount.Name
    'End If
    'If Not Me.m_entity.DepreAccount Is Nothing Then
    '  txtDepreAcctCode.Text = Me.m_entity.DepreAccount.Code
    '  txtDepreAcctName.Text = Me.m_entity.DepreAccount.Name
    'End If
    'Me.m_isInitialized = flag
    'End Sub
    'Public Sub NumerberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
    'If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '  Return
    'End If
    'Select Case CType(sender, Control).Name.ToLower
    '  'Case "txtrent"
    '  '    txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Price)
    '  Case "txtage"
    '    txtAge.Text = Configuration.FormatToString(Me.m_entity.Age, DigitConfig.Int)
    '  Case "txtcalcrate"
    '    txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
    '  Case "txtstartcalcamt"
    '    txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
    '  Case "txtsalvage"
    '    txtSalvage.Text = Configuration.FormatToString(Me.m_entity.Salvage, DigitConfig.Price)
    '  Case "txtdepreopenning"
    '    txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
    '  Case "txtremainingvalue"
    '    txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)

    '  Case "txtbuyprice"
    '    txtBuyPrice.Text = Configuration.FormatToString(Me.m_entity.BuyPrice, DigitConfig.Price)
    'End Select
    'End Sub
    'Private m_dateSetting As Boolean = False
    'Dim m_cmbCodeChanged As Boolean = False
    'Dim m_txtToollotNameChanged As Boolean = False
    'Dim m_TxtToollotBuycostChanged As Boolean = False
    'Dim m_TxtToollotserailnumberChanged As Boolean = False
    'Dim m_TxtToollotbrandChanged As Boolean = False
    'Dim m_txtlToollotlicenseChanged As Boolean = False
    'Dim m_TxtStatusChanged As Boolean = False
    'Dim m_TxtlastDateEditChanged As Boolean = False

    'Dim m_txtCostcenterCodeChanged As Boolean = False

    Dim m_txtAssetCodeChanged As Boolean = False
    Dim m_TxtToollotBuycostchanged As Boolean = False
    Dim m_txtToollotUnitCostchanged As Boolean = False
    Dim m_txtToollotBuyQTYchanged As Boolean = False
    Dim m_txtToollotbuydoccodechanged As Boolean = False
    Dim m_txtToollotWriteOffchanged As Boolean = False
    Dim m_txtToollotRemainQTYchanged As Boolean = False
    Dim m_txtToollotRemainCostchanged As Boolean = False

    'Dim m_TxtCostcenterAddressChanged As Boolean = False


    'Dim m_txtToollotbuydoccodeChanged As Boolean = False
    'Dim m_TxtBuyDateChanged As Boolean = False
    'Dim m_txtRentalRateChanged As Boolean = False
    'Dim m_txtDescriptionChanegd As Boolean = False
    'Dim m_txtUnitCode1Change As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        'Case "cmbcode"
        '  m_cmbCodeChanged = True
        'Case "txtToollotName"
        '  m_txtToollotNameChanged = True
        'Case "TxtToollotBuycost"
        '  m_TxtToollotBuycostChanged = True
        'Case "texteqiserialnumber"
        '  m_TxtToollotserailnumberChanged = True
        'Case "TxtToollotbrand"
        '  m_TxtToollotbrandChanged = True
        'Case "texteqilicense"
        '  m_txtlToollotlicenseChanged = True
        'Case "TxtStatus"
        '  m_TxtStatusChanged = True
        'Case "textlastdateedit"
        '  m_TxtlastDateEditChanged = True
        'Case "txtcostcentercode"
        '  m_txtCostcenterCodeChanged = True

        Case "txtassetcode"
          m_txtAssetCodeChanged = True
        Case "txttoollotbuydoccode"
          m_txtToollotbuydoccodechanged = True
        Case "txttoollotbuycost"
          m_TxtToollotBuycostchanged = True
        Case "txttoollotunitcost"
          m_txtToollotUnitCostchanged = True
        Case "txttoollotbuyqty"
          m_txtToollotBuyQTYchanged = True
        Case "txttoollotwriteoff"
          m_txtToollotWriteOffchanged = True
        Case "txttoollotremainqty"
          m_txtToollotRemainQTYchanged = True
        Case "txttoollotremaincost"
          m_txtToollotRemainCostchanged = True

          'Case "txtcostcenteraddress" ************************************************
          '  m_TxtCostcenterAddressChanged = True *************************************
          'Case "txtToollotbuydoccode"
          '  m_txtToollotbuydoccodeChanged = True
          'Case "txtbuydocdate"
          '  m_TxtBuyDateChanged = True
          '  'Case "txtUnitCode1"
          '  '  m_txtUnitCode1Change = True
          'Case "txtdescription"
          '  m_txtDescriptionChanegd = True
          'Case "txtrentalrate"
          '  If m_txtRentalRateChanged Then
          '    Dim txt As String = txtRentalRate.Text
          '    txt = txt.Replace(",", "")
          '    If txt.Length = 0 Then
          '      Me.CurrentTagItem.Rentalrate = 0
          '    Else
          '      Try
          '        Me.CurrentTagItem.Rentalrate = CDec(TextHelper.TextParser.Evaluate(txt))
          '      Catch ex As Exception
          '        Me.CurrentTagItem.Rentalrate = 0
          '      End Try
          '    End If
          '    txtRentalRate.Text = Configuration.FormatToString(Me.m_entity.Rentalrate, DigitConfig.UnitPrice)
          '    m_txtRentalRateChanged = True
          'End If

      End Select
    End Sub
    Dim m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      If Me.m_entity Is Nothing OrElse Not Me.m_isInitialized Then
        Return
      End If
      Dim doc As ToolLot = Me.m_entity.ToolLot  'Me.CurrentTagItem
      If Me.m_entity.ToolLot Is Nothing Then
        '  doc = New EquipmentItem
        '  Me.m_entity.ItemCollection.Add(Doc)
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Dim tmpFlag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Select Case CType(sender, Control).Name.ToLower

        Case "cmbcode"
          doc.Code = cmbCode.Text
          dirtyFlag = True
          'Case "txtToollotCode"
          '  Me.m_entity.Code = txtToollotCode.Text
          '  dirtyFlag = True
          'Case "txttoolname"
          '  Me.m_entity.Name = txtToolName.Text
          '  dirtyFlag = True
          'Case "txttoollotname"
          '  doc.Name = txtToollotName.Text
          '  dirtyFlag = True

        Case "txttoollotbrand"
          doc.Brand = TxtToollotbrand.Text
          doc.IsDirty = True
          dirtyFlag = True
          Me.RefreshTextData()

          'Case "txtlastdateedit"
          '  If Not TxtlastDateEdit.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(TxtlastDateEdit) = "" Then
          '    Dim thedate As Date = CDate(TxtlastDateEdit.Text)
          '    If Not doc.LastEditDate.Equals(thedate) Then
          '      doc.LastEditDate = thedate
          '      dtpLastEditDate.Value = doc.LastEditDate
          '      dirtyFlag = True
          '    End If

          '  End If
          'Case "dtplasteditdate"
          '  If Not doc.LastEditDate.Equals(dtpLastEditDate.Value) Then
          '    Me.TxtlastDateEdit.Text = MinDateToNull(dtpLastEditDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '    doc.LastEditDate = dtpLastEditDate.Value
          '    dirtyFlag = True
          '    'Me.RefreshListViewData()
          '  End If

        Case "txtassetcode"
          If m_txtAssetCodeChanged Then
            dirtyFlag = Asset.GetAsset(Me.txtAssetCode, Me.txtAssetName, doc.Asset) 'doc.Costcenter
            Me.SetTextFromAsset()
            doc.IsDirty = dirtyFlag
            m_txtAssetCodeChanged = False
            Me.RefreshTextData()
            'Me.RefreshListViewData()
          End If

        Case "txttoollotbuydoccode"
          'If m_txtToollotbuydoccodechanged Then
          '  dirtyFlag = SimpleBusinessEntityBase.GetEntity(Me.txtToollotbuydoccode, Me.CurrentTagItem.Buydoc)
          '  m_txtToollotbuydoccodechanged = False
          'End If
          'If txtToollotbuydoccode.Text > 0 Then
          '  doc.Buydoc = txtToollotbuydoccode.Text
          'End If
          ''doc.SetCurrentBuydoc(doc.Buydoc)
          ''Me.txtToollotbuydoccode.Text = doc.Buydoc.Id
          'doc.Buydoc = txtToollotbuydoccode.Text
          'dirtyFlag = True
          'Case "txtbuydocdate"
          '  m_dateSetting = True
          '  'If Not Me.TxtBuyDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.TxtBuyDocDate) = "" Then
          '  '  Dim theDate As DateTime = CDate(Me.TxtBuyDocDate.Text)
          '  '  If Not doc.Buydate.Equals(theDate) Then
          '  '    dtpBuyDocDate.Value = theDate
          '  '    doc.Buydate = dtpBuyDocDate.Value
          '  '    dirtyFlag = True
          '  '  End If
          '  Else
          '  doc.Buydate = Date.Now
          '  doc.Buydate = Date.MinValue
          '  dirtyFlag = True
          '  End If
          '  m_dateSetting = False
          'Case "dtpbuydocdate"
          '  If Not doc.Buydate.Equals(dtpBuyDocDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.TxtBuyDocDate.Text = MinDateToNull(dtpBuyDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      doc.Buydate = dtpBuyDocDate.Value.ToShortDateString
          '    End If
          '    dirtyFlag = True
          '  End If
        Case "txtdescription"
          doc.Description = txtDescription.Text
          doc.IsDirty = True
          dirtyFlag = True
          Me.RefreshTextData()

        Case "txttoollotbuycost"
          If m_TxtToollotBuycostchanged Then
            If TxtToollotBuycost.TextLength > 0 Then
              Dim val As Decimal = 0
              If IsNumeric(TxtToollotBuycost.Text) Then
                val = CDec(TxtToollotBuycost.Text)
              End If
              doc.Buycost = val
            End If
            m_TxtToollotBuycostchanged = False
            'RefreshCost(doc)
            dirtyFlag = True
            doc.IsDirty = True
          End If

        Case "txttoollotunitcost"
          If m_txtToollotUnitCostchanged Then
            If txtToollotUnitCost.TextLength > 0 AndAlso IsNumeric(txtToollotUnitCost.Text) Then
              doc.UnitCost = CDec(txtToollotUnitCost.Text)
            Else
              doc.UnitCost = 0
            End If
            m_txtToollotUnitCostchanged = False
            dirtyFlag = True
            doc.IsDirty = True
            'RefreshCost(doc)
            Me.RefreshTextData()
          End If

        Case "txttoollotbuyqty"
          If m_txtToollotBuyQTYchanged Then
            If txtToollotBuyQTY.TextLength > 0 AndAlso IsNumeric(txtToollotBuyQTY.Text) Then
              doc.Buyqty = CDec(txtToollotBuyQTY.Text)
            Else
              doc.Buyqty = 0
            End If
            m_txtToollotBuyQTYchanged = False
            'RefreshCost(doc)
            dirtyFlag = True
            doc.IsDirty = True
            Me.RefreshTextData()
          End If


          'Case "txttoollotwriteoff"
          '  If m_txtToollotWriteOffchanged Then
          '    If txtToollotWriteOff.TextLength > 0 Then
          '      doc.WriteOff = CDec(txtToollotWriteOff.Text)
          '    Else
          '      doc.WriteOff = doc.WriteOff
          '    End If
          '    m_txtToollotWriteOffchanged = False
          '    'RefreshCost(doc)
          '    dirtyFlag = True
          '    doc.IsDirty = True
          '  End If

          'Case "txttoollotremainqty"
          '  If m_txtToollotRemainQTYchanged Then
          '    If txtToollotRemainQTY.TextLength > 0 AndAlso IsNumeric(txtToollotRemainQTY.Text) Then
          '      doc.RemainQTY = CDec(txtToollotRemainQTY.Text)
          '    Else
          '      doc.RemainQTY = 0
          '    End If
          '    m_txtToollotRemainQTYchanged = False
          '    'RefreshCost(doc)
          '    dirtyFlag = True
          '    doc.IsDirty = True
          '  End If

          'Case "txttoollotremaincost"
          '  If m_txtToollotRemainCostchanged Then
          '    If txtToollotUnitCost.TextLength > 0 Then
          '      doc.RemainCost = CDec(txtToollotUnitCost.Text)
          '    Else
          '      doc.RemainCost = 0
          '    End If
          '    m_txtToollotRemainCostchanged = False
          '    'RefreshCost(doc)
          '    dirtyFlag = True
          '    doc.IsDirty = True
          '  End If

      End Select

      Me.m_isInitialized = tmpFlag
      'Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      'Me.RefreshListViewData()
      'Me.RefreshTextData()
      CheckFormEnable()
    End Sub
    'Private Sub CalcDepreEndCalcDate()
    '  txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
    'End Sub
    'Private Sub CalcDepreCalcRate()
    '  txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
    'End Sub
    '    Private Sub SetValue(ByVal sender As Object, ByVal e As EventArgs)
    '      'If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '      '  Return
    '      'End If
    '      ' คำนวณค่าเริ่มต้นที่สำคัญ
    '      'Select Case CType(sender, Control).Name.ToLower
    '      '  ' คำนวณเกี่ยวกับวันที่เริ่มต้น
    '      '  Case "cmbcalctype"
    '      '    CalcDepreEndCalcDate()
    '      '    CalcDepreCalcRate()
    '      '  Case "txtage"
    '      '    CalcDepreEndCalcDate()
    '      '    CalcDepreCalcRate()

    '      '  Case "txtstartcalcdate"
    '      '    CalcDepreEndCalcDate()

    '      '  Case "dtpstartcalcdate"
    '      '    CalcDepreEndCalcDate()

    '      'Case "txtsalvage", "txtbuyprice", "txtdepreopenning", "txtstartcalcamt"
    '      '  txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)
    '      'End Select
    '    End Sub
#End Region

#Region "Style"
    Private Sub SetLVHeader()
      lv.MultiSelect = False
      'lv.CheckBoxes = True

      Dim lvColumn As ColumnHeader
      lvColumn = New ColumnHeader
      lvColumn.Name = "linenumber"
      lvColumn.Text = "ลำดับ"
      lvColumn.TextAlign = HorizontalAlignment.Left
      lvColumn.Width = 80
      lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "lotno"
      lvColumn.Text = "Lot No."
      lvColumn.TextAlign = HorizontalAlignment.Left
      lvColumn.Width = 120
      lv.Columns.Add(lvColumn)

      'lvColumn = New ColumnHeader
      'lvColumn.Name = "lotdate"
      'lvColumn.Text = "วันที่ Lot No."
      'lvColumn.TextAlign = HorizontalAlignment.Left
      'lvColumn.Width = 80
      'lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "assetcode"
      lvColumn.Text = "สินทรัพย์"
      lvColumn.TextAlign = HorizontalAlignment.Left
      lvColumn.Width = 150
      lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "buyqty"
      lvColumn.Text = "จำนวน"
      lvColumn.TextAlign = HorizontalAlignment.Right
      lvColumn.Width = 100
      lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "writeoffqty"
      lvColumn.Text = "จำนวน Write off"
      lvColumn.TextAlign = HorizontalAlignment.Right
      lvColumn.Width = 100
      lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "remainqty"
      lvColumn.Text = "คงเหลือจาก write off"
      lvColumn.TextAlign = HorizontalAlignment.Right
      lvColumn.Width = 100
      lv.Columns.Add(lvColumn)

      lvColumn = New ColumnHeader
      lvColumn.Name = "refstatus"
      lvColumn.Text = "สถานะการอ้างอิง"
      lvColumn.TextAlign = HorizontalAlignment.Left
      lvColumn.Width = 100
      lv.Columns.Add(lvColumn)

      'lvColumn = New ColumnHeader
      'lvColumn.Name = "status"
      'lvColumn.Text = "status"
      'lvColumn.TextAlign = HorizontalAlignment.Left
      'lvColumn.Width = 80
      'lv.Columns.Add(lvColumn)

    End Sub
    'Public Function CreateTableStyle() As DataGridTableStyle
    '  Dim dst As New DataGridTableStyle
    '  dst.MappingName = "Equipment"
    '  Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

    '  Dim csCode As New TreeTextColumn
    '  csCode.MappingName = "code"
    '  csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.CodeHeaderText}")
    '  csCode.NullText = ""
    '  csCode.Width = 100
    '  csCode.DataAlignment = HorizontalAlignment.Center
    '  csCode.ReadOnly = True
    '  csCode.TextBox.Name = "code"

    '  Dim csName As New TreeTextColumn
    '  csName.MappingName = "name"
    '  csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.NameHeaderText}")
    '  csName.NullText = ""
    '  csName.Width = 100
    '  csName.ReadOnly = True
    '  csName.TextBox.Name = "name"

    '  Dim csStatus As New TreeTextColumn
    '  csStatus.MappingName = "status"
    '  csStatus.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.StatusHeaderText}")
    '  csStatus.NullText = ""
    '  csStatus.Width = 100
    '  csStatus.ReadOnly = True
    '  csStatus.TextBox.Name = "status"

    '  Dim csCostCenter As New TreeTextColumn
    '  csCostCenter.MappingName = "costcenter"
    '  csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.CostCenterHeaderText}")
    '  csCostCenter.NullText = ""
    '  csCostCenter.Width = 100
    '  csCostCenter.ReadOnly = True
    '  csCostCenter.TextBox.Name = "costcenter"

    '  dst.GridColumnStyles.Add(csCode)
    '  dst.GridColumnStyles.Add(csName)
    '  dst.GridColumnStyles.Add(csStatus)
    '  dst.GridColumnStyles.Add(csCostCenter)

    '  Return dst
    'End Function
#End Region
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled Then
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = False
        Next
      Else
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = True
        Next
      End If
      If Not Me.m_entity.Originated Then
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = False
        Next
      End If
      'Check Reference ปกติไม่ได้ ต้องทำแยก

    End Sub
    'Public Sub CheckToolLotEnable()
    '  If Me.m_entity.ToolLot.IsReferenced Then
    '    'For Each crlt As Control In grbDetail.Controls
    '    '  crlt.Enabled = False
    '    'Next
    '    Grbeqi.Enabled = False
    '    'btnDel.Enabled = False
    '  Else
    '    Grbeqi.Enabled = True
    '    'btnDel.Enabled = True
    '  End If
    'End Sub
    'Public Sub ClearItemOnly()
    '  For Each ctrl As Control In Grbeqi.Controls
    '    If TypeOf ctrl Is TextBox Then
    '      ctrl.Text = ""
    '    End If
    '  Next

    '  '  For Each ctrl As Control In TabPage1.Controls
    '  '    If TypeOf ctrl Is TextBox Then
    '  '      ctrl.Text = ""
    '  '    End If
    '  '  Next
    '  '  For Each ctrl As Control In TabPage2.Controls
    '  '    If TypeOf ctrl Is TextBox Then
    '  '      ctrl.Text = ""
    '  '    End If
    '  '  Next
    'End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()

      'For Each ctrl As Control In grbDetail.Controls
      '  If TypeOf ctrl Is FixedGroupBox OrElse TypeOf ctrl Is GroupBox Then
      '    For Each child As Control In ctrl.Controls
      '      If TypeOf child Is TextBox Then
      '        child.Text = ""
      '      End If
      '      If TypeOf child Is TabPage Then
      '        For Each ctrltab As Control In child.Controls
      '          If TypeOf ctrltab Is TextBox Then
      '            child.Text = ""
      '          End If
      '        Next
      '      End If
      '    Next
      '  ElseIf TypeOf ctrl Is TextBox Then
      '    ctrl.Text = ""
      '  End If
      'Next

      'For Each ctrl As Control In grbDetail.Controls
      '  If TypeOf ctrl Is TextBox Then
      '    ctrl.Text = ""
      '  End If
      'Next

      'For Each ctrl As Control In Grbeqi.Controls
      '  If TypeOf ctrl Is TextBox Then
      '    ctrl.Text = ""
      '  End If
      'Next

      'For Each ctrl As Control In TabPage1.Controls
      '  If TypeOf ctrl Is TextBox Then
      '    ctrl.Text = ""
      '  End If
      'Next
      'For Each ctrl As Control In TabPage2.Controls
      '  If TypeOf ctrl Is TextBox Then
      '    ctrl.Text = ""
      '  End If
      'Next

      'cmbCalcType.SelectedIndex = 0

      'cmbCode.Text = ""
      'TxtlastDateEdit.Text = ""
      'dtpLastEditDate.Value = Date.Now

      'txtEndCalcDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      'TxtBuyDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'DateTimePicker2.Value = Date.Now

      'dtpBuyDocDate.Value = Date.Now
      'TxtBuyDocDate.Text = "" 'Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'lblLasteditdate.Text = "รหัสผู้แก้ไขล่าสุด" & " : " & " .... " & " วันที่แก้ไขล่าสุด : " & Date.Now.ToString("dd/MM/yyyy")

      'Me.picImage.Image = Nothing

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)


        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          If TypeOf Value Is Tool Then
            Me.m_entity = CType(Value, Tool)
          End If

          'Me.m_entity.LoadImage()
        End If

        If Me.m_entity.ToolLot Is Nothing Then
          Me.m_entity.ToolLot = New ToolLot(Me.m_entity)
          Me.m_entity.ToolLot.Autogen = True
        End If

        Me.m_entity.ToolLot.Tool = Me.m_entity

        'Hack:
        'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        'Me.m_isInitialized = False
        'RefreshListViewData()
        'Me.m_entity.EquipmentItem = Me.m_entity.ItemCollection(0)
        'Me.RefreshTextData(Me.m_entity.EquipmentItem)
        'Me.m_isInitialized = True

        UpdateEntityProperties()
      End Set
    End Property



    '#End Region

#Region " IValidatable "
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region


#Region "Image button"
    'Private Sub btnLoadImage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  'Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim doc As ToolLot = Me.CurrentTagItem
    '  If doc Is Nothing Then
    '    Return
    '  End If
    '  Dim dlg As New OpenFileDialog

    '  Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
    '  dlg.Filter = String.Join("|", fileFilters)
    '  If dlg.ShowDialog = DialogResult.OK Then
    '    Dim img As Image = Image.FromFile(dlg.FileName)
    '    If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
    '      Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
    '      img = ImageHelper.Resize(img, percent)
    '    End If
    '    'Me.picImage.Image = img
    '    m_entity.ToolLot.Image = img
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '    'CheckLabelImgSize()
    '  End If
    'End Sub
    'Private Sub btnClearImage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  'Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  m_entity.ToolLot.Image = Nothing
    '  'Me.picImage.Image = Nothing
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  myContent.IsDirty = True
    '  'CheckLabelImgSize()
    'End Sub
    'Private Sub CheckLabelImgSize()
    '  Me.lblPicSize.Text = "120 X 120 pixel"
    '  If Me.m_entity.ToolLot.Image Is Nothing Then
    '    Me.lblPicSize.Visible = True
    '  Else
    '    Me.lblPicSize.Visible = False
    '  End If
    'End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      'Get
      '  Dim data As IDataObject = Clipboard.GetDataObject
      '  If data.GetDataPresent((New Account).FullClassName) Then
      '    If Not Me.ActiveControl Is Nothing Then
      '      Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtglcode", "txtglname"
      '          Return True
      '        Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
      '          Return True
      '        Case "txtdepreacctcode", "txtdepreacctname"
      '          Return True
      '      End Select
      '    End If
      '  End If
      '  If data.GetDataPresent((New Unit).FullClassName) Then
      '    If Not Me.ActiveControl Is Nothing Then
      '      Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtunitcode", "txtunitname"
      '          Return True
      '      End Select
      '    End If
      '  End If
      '  If data.GetDataPresent((New AssetType).FullClassName) Then
      '    If Not Me.ActiveControl Is Nothing Then
      '      Select Case Me.ActiveControl.Name.ToLower
      '        Case "txttypecode", "txttypename"
      '          Return True
      '      End Select
      '    End If
      '  End If
      '  If data.GetDataPresent((New CostCenter).FullClassName) Then
      '    If Not Me.ActiveControl Is Nothing Then
      '      Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtcostcentercode", "txtcostcentername"
      '          Return True
      '      End Select
      '    End If
      '  End If
      '  Return False
      'End Get
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Unit).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtdefaultunitcode", "txtdefaultunit" _
               , "txtunitcode", "txtunit" _
               , "txtrentalunitcode", "txtrentalunit"

                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtaccountcode", "txtaccount"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      'Dim data As IDataObject = Clipboard.GetDataObject
      'If data.GetDataPresent((New Account).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
      '  Dim entity As New Account(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txtglcode", "txtglname"
      '        Me.SetAccountDialog(entity)
      '      Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
      '        Me.SetDepreOpeningAccountDialog(entity)
      '      Case "txtdepreacctcode", "txtdepreacctname"
      '        Me.SetDepreAccountDialog(entity)
      '    End Select
      '  End If
      'End If
      'If data.GetDataPresent((New AssetType).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New AssetType).FullClassName))
      '  Dim entity As New AssetType(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txttypecode", "txttypename"
      '        Me.SetAssetTypeDialog(entity)
      '    End Select
      '  End If
      'End If
      'If data.GetDataPresent((New CostCenter).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
      '  Dim entity As New CostCenter(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txtcostcentercode", "txtcostcentername"
      '        Me.SetCostCenterDialog(entity)
      '    End Select
      '  End If
      'End If
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Unit).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Unit).FullClassName))
        Dim entity As New Unit(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtdefaultunit", "txtdefaultunitcode"
            '  Me.SetDefaultUnit(entity)
            Case "txtunitcode1", "txtunit1"
              'Me.SetUnit1(entity)
              'Case "txtunitcode2", "txtunit2"
              'Me.SetUnit2(entity)

          End Select
        End If
      End If
      'If data.GetDataPresent((New Account).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
      '  Dim entity As New Account(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txtaccountcode", "txtaccount"
      '        Me.SetAccount(entity)
      '    End Select
      '  End If
      'End If
    End Sub
    'End Sub
#End Region

#Region "Event of Button controls"
    ' Account button
    'Private Sub btnGLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Account)
    'End Sub
    'Private Sub btnGLFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnglfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    '    Case "btndepreopeningacctfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreOpeningAccountDialog)
    '    Case "btndepreacctfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreAccountDialog)
    '  End Select
    'End Sub
    'Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtGLCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      'Or Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
    'End Sub
    'Private Sub SetDepreOpeningAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtDepreOpeningAcctCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      'Or Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
    'End Sub
    'Private Sub SetDepreAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtDepreAcctCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      'Or Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
    'End Sub
    ' Type button
    'Private Sub btnTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New AssetType)
    'End Sub
    'Private Sub btnTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeDialog)
    'End Sub
    'Private Sub SetAssetTypeDialog(ByVal e As ISimpleEntity)
    '  Me.txtTypeCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      'Or AssetType.GetAssetType(txtTypeCode, txtTypeName, Me.m_entity.Type)
    '  'SetValueFromAssetType()
    'End Sub

    ' Costcenter button
    'Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New CostCenter)
    'End Sub
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog)
    'End Sub
    'Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '  Dim eqi As ToolLot = Me.CurrentTagItem
    '  If eqi Is Nothing Then
    '    Return
    '  End If
    '  Me.txtCostcenterCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or CostCenter.GetCostCenter(txtCostcenterCode, txtCostCenterName, eqi.Costcenter)

    '  RefreshListViewData()

    '  'eqi.SetCurrentCostCenter(eqi.Costcenter)
    '  'Me.TxtCostcenterAddress.Text = eqi.CurrentCostCenter.Code & " : " & eqi.CurrentCostCenter.Name

    'End Sub
    Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      'Dim filters(0) As Filter
      'filters(0) = New Filter("OnlyAssetNotRelateObject", True)

      myEntityPanelService.OpenListDialog(New AssetForToollotSelection, AddressOf SetAssetDialog)
    End Sub
    Private Sub SetAssetDialog(ByVal e As ISimpleEntity)
      Dim doc As ToolLot = Me.m_entity.ToolLot 'Me.CurrentTagItem
      If doc Is Nothing Then
        Return
      End If
      Me.txtAssetCode.Text = e.Code
      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      '    Me.WorkbenchWindow.ViewContent.IsDirty _
      '    Or Asset.GetAsset(txtAssetCode, txtAssetName, doc.Asset)
      'doc.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty

      doc.IsDirty = Asset.GetAsset(txtAssetCode, txtAssetName, doc.Asset)
      Me.SetTextFromAsset()
      'Me.RefreshListViewData()
    End Sub
    Private Sub SetTextFromAsset()
      Dim doc As ToolLot = Me.m_entity.ToolLot
      Me.txtAssetCode.Text = doc.Asset.Code
      Me.txtAssetName.Text = doc.Asset.Name
      Me.TxtToollotBuycost.Text = Configuration.FormatToString(doc.Buycost, DigitConfig.Price)
      Me.txtToollotbuydoccode.Text = doc.Buydoc.Code
      Me.txtToollotBuyDate.Text = doc.Buydate.ToShortDateString
    End Sub
    ' More detail
    'Private Sub btnAssetAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.AssetAuxDetail
    '  'myAuxPanel.Entity = Me.m_entity
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
    '  If myDialog.ShowDialog() = DialogResult.Cancel Then
    '    Me.WorkbenchWindow.ViewContent.IsDirty = False
    '  End If
    'End Sub
#End Region

#Region " Autogencode "
    Private m_oldCode As String = ""
    Private m_oldEqCode As String = ""

    Private Sub UpdateAutogenStatus()
      If Me.m_entity Is Nothing Then
        Return
      End If

      Dim lot As ToolLot = Me.m_entity.ToolLot
      If lot Is Nothing Then
        Return
      End If

      If Me.chkAutorun.Checked Then
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, lot.EntityId, currentUserId)
        'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, lot.EntityId)
        If lot.Code Is Nothing OrElse lot.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            lot.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            lot.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(lot.Code)
          If Me.cmbCode.Items.Count > 0 Then
            cmbCode.SelectedIndex = 0
          End If
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            lot.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        lot.Autogen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        'If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
        '  Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
        'End If
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = lot.Code
        lot.Autogen = False
      End If
    End Sub
    'Private Sub UpdateEqAutogenStatus()
    '  If Me.chkEqAutoRun.Checked Then
    '    'Me.Validator.SetRequired(Me.txtCode, False)
    '    'Me.ErrorProvider1.SetError(Me.txtCode, "")
    '    Me.CmbToolCode.DropDownStyle = ComboBoxStyle.DropDownList
    '    Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
    '    BusinessLogic.Entity.NewPopulateCodeCombo(Me.CmbToolCode, Me.m_entity.EntityId, currentUserId)
    '    If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
    '      If Me.CmbToolCode.Items.Count > 0 Then
    '        Me.m_entity.Code = CType(Me.CmbToolCode.Items(0), AutoCodeFormat).Format
    '        Me.CmbToolCode.SelectedIndex = 0
    '        Me.m_entity.AutoCodeFormat = CType(Me.CmbToolCode.Items(0), AutoCodeFormat)
    '      End If
    '    Else
    '      Me.CmbToolCode.SelectedIndex = Me.CmbToolCode.FindStringExact(Me.m_entity.Code)
    '      If TypeOf Me.CmbToolCode.SelectedItem Is AutoCodeFormat Then
    '        Me.m_entity.AutoCodeFormat = CType(Me.CmbToolCode.SelectedItem, AutoCodeFormat)
    '      End If
    '    End If
    '    m_oldEqCode = Me.CmbToolCode.Text
    '    Me.m_entity.Code = m_oldEqCode
    '    Me.m_entity.AutoGen = True
    '  Else
    '    'Me.Validator.SetRequired(Me.txtCode, True)
    '    Me.CmbToolCode.DropDownStyle = ComboBoxStyle.Simple
    '    Me.CmbToolCode.Items.Clear()
    '    'Me.CmbToolCode.Text = m_oldCode '*******************************************************
    '    Me.m_entity.Code = m_oldEqCode
    '    Me.m_entity.AutoGen = False
    '  End If
    'End Sub
#End Region

    Private Sub lv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv.DoubleClick
      Try
        Dim index As Integer = lv.SelectedItems(0).Index

        Me.SetLVItemRegular()

        If Not Me.m_entity.ToolLot Is Nothing Then
          Me.m_entity.ToolLot = New ToolLot(Me.m_entity)

          Me.m_entity.ToolLot = CType(lv.SelectedItems(0).Tag, ToolLot)
          Me.RefreshTextData()
        End If

        lv.Items(index).Font = New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0) '.SubItems(6).Text = "กำลังปรับปรุง"
        Me.ToggleReferenced(Me.m_entity.ToolLot)
      Catch ex As Exception

      End Try
    End Sub
    Private Sub ToggleReferenced(ByVal lot As ToolLot)
      Dim isEnable As Boolean = Not lot.IsReferenced

      ibtnSave.Enabled = isEnable
      ibtnDel.Enabled = isEnable

      cmbCode.Enabled = isEnable
      chkAutorun.Enabled = isEnable
      txtAssetCode.Enabled = isEnable
      btnAssetFind.Enabled = isEnable
      btnPurchaseFind.Enabled = isEnable
      txtToollotBuyQTY.Enabled = isEnable
      txtToollotUnitCost.Enabled = isEnable
      TxtToollotBuycost.Enabled = isEnable
      TxtToollotbrand.Enabled = isEnable
      txtDescription.Enabled = isEnable
      btnLotRef.Enabled = Not isEnable
    End Sub
    Private Sub SetLVItemRegular()
      For Each item As ListViewItem In lv.Items
        item.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
      Next
    End Sub
    'Private Sub CheckLabelImgSize()
    '  Me.lblPicSize.Text = "272 X 204 pixel"
    '  If Me.m_entity.Image Is Nothing Then
    '    Me.lblPicSize.Visible = True
    '  Else
    '    Me.lblPicSize.Visible = False
    '  End If
    'End Sub

    'Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged

    '  Me.m_isInitialized = False
    '  'Me.RemoveEvent()
    '  If lv.SelectedItems.Count > 0 Then
    '    'If Me.m_entity.ToolLot.Id <> CType(lv.SelectedItems(0).Tag, ToolLot).Id Then
    '    Me.m_entity.ToolLot = CType(lv.SelectedItems(0).Tag, ToolLot)
    '    'Dim eqi As ToolLot = Me.CurrentTagItem
    '    'Me.RefreshTextData()
    '    'Me.CheckToolLotEnable()
    '    'End If
    '  End If
    '  Me.m_isInitialized = True
    '  'Me.EventWiring()
    'End Sub

    'Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim eqi As ToolLot = Me.CurrentTagItem
    '  'Dim index As Integer = lv.SelectedItems.Count
    '  Dim neweqi As New ToolLot
    'cmbCode.Text = eqitem.Code
    'Me.m_oldCode = eqitem.Code
    'Me.chkAutorun.Checked = eqitem.Autogen
    'Me.UpdateAutogenStatus()
    'neweqi.LastEditDate = Now
    'neweqi.Costcenter = New CostCenter
    'neweqi.Buydate = Now

    'If Not eqi Is Nothing Then
    '  Me.m_entity.ItemCollection.Add(neweqi)
    'Else
    '  Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(eqi) + 1, neweqi)
    'End If
    'Me.RefreshTextData()



    'If Me.m_entity.ItemCollection.Count > -1 Then
    '  Return
    'End If
    'Dim newItem As New BlankItem("")
    'Dim prItem As New PRItem
    'lv.Items.Add = newItem
    'prItem.ItemType = New ItemType(0)
    'prItem.Qty = 0
    'Me.m_entity.ItemCollection.Insert(index, eqitem)
    'RefreshListViewData()
    'eqitem.CurrentRowIndex = index



    'Dim lvItem As New ListViewItem(eqi.Code)

    'Dim AAA As EquipmentItem = m_entity.ItemCollection.CurrentItem

    'lvItem.SubItems.Add("")
    'lvItem.SubItems.Add("")
    'lvItem.SubItems.Add("")
    'lvItem.Tag = eqi
    'lv.Items.Add(lvItem).Tag = eqi

    'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    'If Me.m_entity Is Nothing Then
    '  Return
    'End If
    'Dim doc As EquipmentItem = Me.m_entity.ItemCollection.CurrentItem
    'If doc Is Nothing Then
    '  Return
    'End If
    'Dim dt As TreeTable = Me.m_treeManager.Treetable
    'dt.Clear()
    'Dim view As Integer = 7
    'Dim wsdColl As EquipmentItemCollection = doc.Equipment.ItemCollection
    'If wsdColl.GetSumPercent >= 100 Then
    '  msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    'ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
    '  msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
    'Else
    'Dim eqid As New equi
    'Dim wbsd As New WBSDistribute
    'wbsd.CostCenter = Me.m_entity.CostCenter
    'wbsd.Percent = 100 - wsdColl.GetSumPercent
    'wsdColl.Add(wbsd)
    'End If
    'm_wbsdInitialized = False
    'wsdColl.Populate(dt, doc, view)
    'm_wbsdInitialized = True
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
#Region "Event of Control"
    'Private Sub SetUnit1(ByVal e As ISimpleEntity)
    '  Me.txtUnitCode.Text = e.Code
    '  Dim flag As Boolean = Unit.GetUnit(txtUnitCode, txtUnit, Me.CurrentTagItem.Unit)
    '  Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
    'End Sub
    'Private Sub SetUnit2(ByVal e As ISimpleEntity)
    '  Me.txtRentalUnitCode.Text = e.Code
    '  Dim flag As Boolean = Unit.GetUnit(txtRentalUnitCode, txtRentalunit, Me.CurrentTagItem.Rentalunit)
    '  Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
    'End Sub


    'Private Sub ShowNewPanels(ByVal entity As ISimpleEntity)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(entity)
    'End Sub
#End Region

    'Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim eqi As New ToolLot
    '  If Not Me.m_entity.ItemCollection.Contains(eqi) Then
    '    Me.m_entity.ItemCollection.Add(eqi)
    '  End If
    '  Me.m_entity.ToolLot = eqi
    '  Me.ClearItemOnly()
    '  Me.RefreshListViewData()
    '  'Me.ClearDetail()
    '  Me.chkAutorun.Checked = True
    '  Me.UpdateAutogenStatus()

    'End Sub
    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If
    '  If Me.m_entity.EquipmentItem Is Nothing Then
    '    Return
    '  End If

    '  Dim eqi As EquipmentItem = Me.m_entity.EquipmentItem
    '  If Not Me.m_entity.ItemCollection.Contains(eqi) Then
    '    Me.m_entity.ItemCollection.Add(eqi)
    '  End If
    '  Me.RefreshListViewData()
    'End Sub

    'Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  If Me.m_entity.ToolLot Is Nothing Then
    '    Return
    '  End If
    '  If Me.m_entity.ItemCollection.Contains(Me.m_entity.ToolLot) Then
    '    Me.m_entity.ItemCollection.Remove(Me.m_entity.ItemCollection.IndexOf(Me.m_entity.ToolLot))
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  End If
    '  If Me.m_entity.ItemCollection.Count > 0 Then
    '    Me.m_entity.ToolLot = Me.m_entity.ItemCollection(0)
    '    Me.RefreshListViewData()
    '    Me.RefreshTextData()
    '  End If
    'End Sub

    'Private Sub ibtnShowUnitDialog1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit1) '******
    'End Sub

    'Private Sub ibtnShowUnit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  ShowNewPanels(New Unit)
    'End Sub

    'Private Sub ibtnShowUnitDialog2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowRentalUnitDialog2.Click
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit2)
    'End Sub
    'Private Sub ibtnShowUnit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  ShowNewPanels(New Unit)
    'End Sub
    Dim m_chkAutorunCheckChanged As Boolean
    Private Sub chkAutorun_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      If Not m_chkAutorunCheckChanged Then
        UpdateAutogenStatus()
      End If
    End Sub

    'Private Sub chkEqAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  UpdateEqAutogenStatus()
    'End Sub

    'Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

    '  Dim filters(0) As Filter
    '  filters(0) = New Filter("id", 0)

    '  'myEntityPanelService.OpenDetailPanel(New GoodsReceipt)

    '  Dim dlg As New BasketDialog
    '  AddHandler dlg.EmptyBasket, AddressOf SetItems


    '  Dim Entities As New ArrayList

    '  Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
    '  dlg.Lists.Add(view)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '  myDialog.ShowDialog()

    '  Me.RefreshListViewData()
    '  Me.RefreshTextData()

    '  Me.UpdateAutogenStatus()

    'End Sub
    'Private Sub SetItems(ByVal items As BasketItemCollection)

    '  Dim newCode As String = ""
    '  Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

    '  Me.m_entity.ItemCollection.SetItems(items, newCode, currentUserId)
    '  If Me.m_entity.ItemCollection.Contains(Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)) Then
    '    Me.m_entity.ToolLot = Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)
    '  End If
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub

    'Private Sub btnDel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  If Me.m_entity.ToolLot Is Nothing Then
    '    Return
    '  End If
    '  If Me.m_entity.ItemCollection.Contains(Me.m_entity.ToolLot) Then
    '    Dim newToolLot As ToolLot = Nothing
    '    If Me.m_entity.ItemCollection.IndexOf(Me.m_entity.ToolLot) - 1 >= 0 Then
    '      newToolLot = Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.IndexOf(Me.m_entity.ToolLot) - 1)
    '    End If
    '    Me.m_entity.ItemCollection.Remove(Me.m_entity.ItemCollection.IndexOf(Me.m_entity.ToolLot))
    '    If Not newToolLot Is Nothing Then
    '      Me.m_entity.ToolLot = newToolLot
    '    End If
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  End If
    '  If Me.m_entity.ItemCollection.Count <= 0 Then
    '    Me.m_entity.ToolLot = New ToolLot
    '  End If

    '  Me.RefreshListViewData()
    '  Me.RefreshTextData()
    '  '  Me.ClearDetail()
    '  'End If

    'End Sub

    'Private Sub TxtToollotName_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtToollotName.EnabledChanged

    'End Sub

    'Private Sub IbtnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '  Dim doc As ToolLot '= Me.CurrentTagItem
    '  'If doc Is Nothing Then
    '  doc = New ToolLot
    '  Me.m_entity.ItemCollection.Add(doc)
    '  doc.Autogen = True
    '  Me.m_entity.ToolLot = doc
    '  'End If

    '  Me.RefreshTextData()
    '  Me.RefreshListViewData()
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
    'Private Sub btnAddNew_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
    '  Dim filters(0) As Filter
    '  filters(0) = New Filter("id", 0)
    '  Dim dlg As New BasketDialog

    '  AddHandler dlg.EmptyBasket, AddressOf SetItems

    '  Dim Entities As New ArrayList
    '  Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
    '  dlg.Lists.Add(view)

    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '  myDialog.ShowDialog()
    '  Me.RefreshListViewData()
    '  Me.RefreshTextData()
    '  Me.UpdateAutogenStatus()
    'End Sub

    'Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
    '  Dim filters(0) As Filter
    '  filters(0) = New Filter("id", 0)
    '  Dim dlg As New BasketDialog

    '  AddHandler dlg.EmptyBasket, AddressOf SetItems

    '  Dim Entities As New ArrayList
    '  Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
    '  dlg.Lists.Add(view)

    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '  myDialog.ShowDialog()
    '  Me.RefreshListViewData()
    '  Me.RefreshTextData()
    '  Me.UpdateAutogenStatus()
    'End Sub

    Private Sub ClearAllText()
      For Each ctl As Control In Me.Grbeqi.Controls
        If TypeOf ctl Is TextBox Then
          ctl.Text = ""
        End If
      Next
    End Sub

    Private Function SaveValidate() As Boolean
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      If Me.txtToollotBuyQTY.Text.Trim.Length = 0 OrElse CDec(Me.txtToollotBuyQTY.Text) <= 0 Then
        msgServ.ShowMessage("${res:Global.Error.ValidQty}")
        Return False
      End If

      If Me.cmbCode.Text.Trim.Length = 0 Then
        msgServ.ShowMessage("${res:Global.Error.ValidCode}")
        Return False
      End If

      Return True
    End Function
    Private Sub ibtnNewLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnNewLot.Click
      ClearAllText()
      Me.m_entity.ToolLot = New ToolLot(Me.m_entity)
      Me.ToggleReferenced(Me.m_entity.ToolLot)

      m_chkAutorunCheckChanged = True
      Me.m_entity.ToolLot.Autogen = True
      Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
      'Me.UpdateAutogenStatus()
      Me.RefreshTextData()
      Me.SetLVItemRegular()
      m_chkAutorunCheckChanged = False
    End Sub

    Private Sub ibtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSave.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing OrElse Me.m_entity.ToolLot Is Nothing Then
        Return
      End If

      If Not SaveValidate() Then
        'msgServ.ShowMessage("${res:Global.Error.ValidQty}")
        'txtToollotBuyQTY.Focus()
        Return
      End If
      If Me.m_entity.SaveLot(SecurityService.CurrentUser.Id) Then
        'Save Success

        m_chkAutorunCheckChanged = True
        Me.m_entity.ToolLot = New ToolLot(Me.m_entity)
        'Me.UpdateAutogenStatus()
        Me.RefreshTextData()
        Me.m_entity.ToolLot.Autogen = True
        Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
        Me.RefreshListViewData()
        Me.SetLVItemRegular()
        m_chkAutorunCheckChanged = False
      End If
    End Sub

    Private Sub ibtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDel.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing OrElse Me.m_entity.ToolLot Is Nothing OrElse Not Me.m_entity.ToolLot.Originated Then
        Return
      End If

      If Not msgServ.AskQuestionFormatted("${res:Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.ConfirmDelete}", New String() {Me.m_entity.ToolLot.Code}) Then
        'If Not msgServ.AskQuestionFormatted("Longkong.Pojjaman.Gui.Panels.ToolLotDetailView.ConfirmDelete", Me.m_entity.ToolLot.Code) Then
        Return
      End If

      If Me.m_entity.DeleteLot() Then
        'Delete Success

        'Me.ClearAllText()
        Me.m_entity.ToolLot = New ToolLot(Me.m_entity)
        Me.RefreshListViewData()

        m_chkAutorunCheckChanged = True
        Me.m_entity.ToolLot.Autogen = True
        Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
        Me.UpdateAutogenStatus()
        Me.RefreshTextData()
        Me.SetLVItemRegular()
        m_chkAutorunCheckChanged = False
      End If

    End Sub

    Private Sub btnPurchaseFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchaseFind.Click

      Dim filters(0) As Filter
      filters(0) = New Filter("id", 0)
      Dim dlg As New BasketDialog

      AddHandler dlg.EmptyBasket, AddressOf SetItems

      Dim Entities As New ArrayList
      If Not Me.m_entity.Costcenter Is Nothing AndAlso Me.m_entity.Costcenter.Originated Then
        Dim tocc As New CostCenter
        tocc.Id = m_entity.Costcenter.Id
        tocc.Code = m_entity.Costcenter.Code
        tocc.Name = m_entity.Costcenter.Name
        Entities.Add(tocc)
      End If
      Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
      dlg.Lists.Add(view)

      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)

      If Not Me.m_entity.ToolLot Is Nothing Then
        Me.m_entity.ToolLot.SetDocCode(items)
        Me.RefreshTextData()
      End If

      'Dim newCode As String = ""
      'Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

      'Me.m_entity.ItemCollection.SetItems(items, newCode, currentUserId)
      'If Me.m_entity.ItemCollection.Contains(Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)) Then
      '  Me.m_entity.ToolLot = Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)
      'End If
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub btnLotRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLotRef.Click
      If Not Me.m_entity.Originated OrElse Not m_entity.ToolLot.Originated Then
        Return
      End If
      Dim rd As RefDialog
      Dim ds As DataSet = m_entity.ToolLot.GetLotReference
      Dim dt As DataTable
      Dim dt2 As DataTable
      dt = ds.Tables(0)
      dt2 = ds.Tables(1)
      rd = New RefDialog
      rd.dt1 = dt
      rd.dt2 = dt2
      rd.ShowDialog()
    End Sub
  End Class

End Namespace
