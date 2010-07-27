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
    Friend WithEvents lblDocnum As System.Windows.Forms.Label
    Friend WithEvents txtToollotbuydoccode As System.Windows.Forms.TextBox
    Friend WithEvents lblBuydocdate As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Public WithEvents lv As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblBuycost As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblToolCode As System.Windows.Forms.Label
    Friend WithEvents lblToolName As System.Windows.Forms.Label
    Friend WithEvents lblPicSize As System.Windows.Forms.Label
    Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAssetFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToollotBuyQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotRemainQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotRemainCost As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents lblRemianQTY As System.Windows.Forms.Label
    Friend WithEvents lblRemainCost As System.Windows.Forms.Label
    Friend WithEvents lblBuyQTY As System.Windows.Forms.Label
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents txtToollotWriteOff As System.Windows.Forms.TextBox
    Friend WithEvents lblWriteOff As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddNew As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnDel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToollotBuyDate As System.Windows.Forms.TextBox
    Friend WithEvents txtToollotCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtToollotName As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolLotDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtToollotCode = New System.Windows.Forms.TextBox()
      Me.TxtToollotName = New System.Windows.Forms.TextBox()
      Me.btnAddNew = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnDel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblToolCode = New System.Windows.Forms.Label()
      Me.lblToolName = New System.Windows.Forms.Label()
      Me.lv = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Grbeqi = New System.Windows.Forms.GroupBox()
      Me.txtToollotBuyQTY = New System.Windows.Forms.TextBox()
      Me.txtToollotBuyDate = New System.Windows.Forms.TextBox()
      Me.txtToollotWriteOff = New System.Windows.Forms.TextBox()
      Me.txtToollotRemainQTY = New System.Windows.Forms.TextBox()
      Me.txtToollotRemainCost = New System.Windows.Forms.TextBox()
      Me.txtToollotUnitCost = New System.Windows.Forms.TextBox()
      Me.txtDescription = New System.Windows.Forms.TextBox()
      Me.lblBrand = New System.Windows.Forms.Label()
      Me.lblWriteOff = New System.Windows.Forms.Label()
      Me.lblRemianQTY = New System.Windows.Forms.Label()
      Me.lblRemainCost = New System.Windows.Forms.Label()
      Me.lblBuyQTY = New System.Windows.Forms.Label()
      Me.lblUnitCost = New System.Windows.Forms.Label()
      Me.lblDescription = New System.Windows.Forms.Label()
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPicSize = New System.Windows.Forms.Label()
      Me.picImage = New System.Windows.Forms.PictureBox()
      Me.TxtToollotbrand = New System.Windows.Forms.TextBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblToollotCode = New System.Windows.Forms.Label()
      Me.lblBuycost = New System.Windows.Forms.Label()
      Me.lblBuydocdate = New System.Windows.Forms.Label()
      Me.txtToollotbuydoccode = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lblDocnum = New System.Windows.Forms.Label()
      Me.btnAssetFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAssetName = New System.Windows.Forms.TextBox()
      Me.txtAssetCode = New System.Windows.Forms.TextBox()
      Me.TxtToollotBuycost = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.Grbeqi.SuspendLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.grbDetail.Controls.Add(Me.btnAddNew)
      Me.grbDetail.Controls.Add(Me.btnDel)
      Me.grbDetail.Controls.Add(Me.lblToolCode)
      Me.grbDetail.Controls.Add(Me.lblToolName)
      Me.grbDetail.Controls.Add(Me.lv)
      Me.grbDetail.Controls.Add(Me.Grbeqi)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(1046, 746)
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
      Me.txtToollotCode.Location = New System.Drawing.Point(111, 22)
      Me.Validator.SetMinValue(Me.txtToollotCode, "")
      Me.txtToollotCode.Name = "txtToollotCode"
      Me.txtToollotCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToollotCode, "")
      Me.Validator.SetRequired(Me.txtToollotCode, False)
      Me.txtToollotCode.Size = New System.Drawing.Size(117, 21)
      Me.txtToollotCode.TabIndex = 341
      '
      'TxtToollotName
      '
      Me.Validator.SetDataType(Me.TxtToollotName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotName, "")
      Me.TxtToollotName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotName, System.Drawing.Color.Empty)
      Me.TxtToollotName.Location = New System.Drawing.Point(111, 53)
      Me.Validator.SetMinValue(Me.TxtToollotName, "")
      Me.TxtToollotName.Name = "TxtToollotName"
      Me.TxtToollotName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.TxtToollotName, "")
      Me.Validator.SetRequired(Me.TxtToollotName, False)
      Me.TxtToollotName.Size = New System.Drawing.Size(287, 21)
      Me.TxtToollotName.TabIndex = 343
      '
      'btnAddNew
      '
      Me.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAddNew.Location = New System.Drawing.Point(118, 81)
      Me.btnAddNew.Name = "btnAddNew"
      Me.btnAddNew.Size = New System.Drawing.Size(24, 24)
      Me.btnAddNew.TabIndex = 341
      Me.btnAddNew.TabStop = False
      Me.btnAddNew.ThemedImage = CType(resources.GetObject("btnAddNew.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnDel
      '
      Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDel.Location = New System.Drawing.Point(142, 81)
      Me.btnDel.Name = "btnDel"
      Me.btnDel.Size = New System.Drawing.Size(24, 24)
      Me.btnDel.TabIndex = 342
      Me.btnDel.TabStop = False
      Me.btnDel.ThemedImage = CType(resources.GetObject("btnDel.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblToolCode
      '
      Me.lblToolCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolCode.ForeColor = System.Drawing.Color.Black
      Me.lblToolCode.Location = New System.Drawing.Point(-1, 22)
      Me.lblToolCode.Name = "lblToolCode"
      Me.lblToolCode.Size = New System.Drawing.Size(106, 23)
      Me.lblToolCode.TabIndex = 334
      Me.lblToolCode.Text = "รหัสชนิดเครื่องมือ :"
      Me.lblToolCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblToolName
      '
      Me.lblToolName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolName.ForeColor = System.Drawing.Color.Black
      Me.lblToolName.Location = New System.Drawing.Point(6, 56)
      Me.lblToolName.Name = "lblToolName"
      Me.lblToolName.Size = New System.Drawing.Size(99, 18)
      Me.lblToolName.TabIndex = 337
      Me.lblToolName.Text = "ชื่อชนิดเครื่องมือ :"
      Me.lblToolName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lv
      '
      Me.lv.Alignment = System.Windows.Forms.ListViewAlignment.Left
      Me.lv.AllowSort = True
      Me.lv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
      Me.lv.FullRowSelect = True
      Me.lv.GridLines = True
      Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lv.HideSelection = False
      Me.lv.Location = New System.Drawing.Point(6, 108)
      Me.lv.Name = "lv"
      Me.lv.Size = New System.Drawing.Size(399, 624)
      Me.lv.SortIndex = -1
      Me.lv.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lv.TabIndex = 323
      Me.lv.UseCompatibleStateImageBehavior = False
      Me.lv.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Code"
      Me.ColumnHeader1.Width = 105
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "จำนวนซื้อ"
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 73
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "จำนวนWrite Off"
      Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader4.Width = 91
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "จำนวนคงเหลือ"
      Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader5.Width = 102
      '
      'Grbeqi
      '
      Me.Grbeqi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Grbeqi.Controls.Add(Me.txtToollotBuyQTY)
      Me.Grbeqi.Controls.Add(Me.txtToollotBuyDate)
      Me.Grbeqi.Controls.Add(Me.txtToollotWriteOff)
      Me.Grbeqi.Controls.Add(Me.txtToollotRemainQTY)
      Me.Grbeqi.Controls.Add(Me.txtToollotRemainCost)
      Me.Grbeqi.Controls.Add(Me.txtToollotUnitCost)
      Me.Grbeqi.Controls.Add(Me.txtDescription)
      Me.Grbeqi.Controls.Add(Me.lblBrand)
      Me.Grbeqi.Controls.Add(Me.lblWriteOff)
      Me.Grbeqi.Controls.Add(Me.lblRemianQTY)
      Me.Grbeqi.Controls.Add(Me.lblRemainCost)
      Me.Grbeqi.Controls.Add(Me.lblBuyQTY)
      Me.Grbeqi.Controls.Add(Me.lblUnitCost)
      Me.Grbeqi.Controls.Add(Me.lblDescription)
      Me.Grbeqi.Controls.Add(Me.btnLoadImage)
      Me.Grbeqi.Controls.Add(Me.btnClearImage)
      Me.Grbeqi.Controls.Add(Me.lblPicSize)
      Me.Grbeqi.Controls.Add(Me.picImage)
      Me.Grbeqi.Controls.Add(Me.TxtToollotbrand)
      Me.Grbeqi.Controls.Add(Me.cmbCode)
      Me.Grbeqi.Controls.Add(Me.chkAutorun)
      Me.Grbeqi.Controls.Add(Me.lblToollotCode)
      Me.Grbeqi.Controls.Add(Me.lblBuycost)
      Me.Grbeqi.Controls.Add(Me.lblBuydocdate)
      Me.Grbeqi.Controls.Add(Me.txtToollotbuydoccode)
      Me.Grbeqi.Controls.Add(Me.Label3)
      Me.Grbeqi.Controls.Add(Me.lblDocnum)
      Me.Grbeqi.Controls.Add(Me.btnAssetFind)
      Me.Grbeqi.Controls.Add(Me.txtAssetName)
      Me.Grbeqi.Controls.Add(Me.txtAssetCode)
      Me.Grbeqi.Controls.Add(Me.TxtToollotBuycost)
      Me.Grbeqi.Location = New System.Drawing.Point(412, 101)
      Me.Grbeqi.Name = "Grbeqi"
      Me.Grbeqi.Size = New System.Drawing.Size(628, 631)
      Me.Grbeqi.TabIndex = 0
      Me.Grbeqi.TabStop = False
      Me.Grbeqi.Text = "รายละเอียดเครื่องจักรรายตัว"
      '
      'txtToollotBuyQTY
      '
      Me.Validator.SetDataType(Me.txtToollotBuyQTY, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotBuyQTY, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotBuyQTY, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotBuyQTY, System.Drawing.Color.Empty)
      Me.txtToollotBuyQTY.Location = New System.Drawing.Point(134, 182)
      Me.Validator.SetMinValue(Me.txtToollotBuyQTY, "")
      Me.txtToollotBuyQTY.Name = "txtToollotBuyQTY"
      Me.Validator.SetRegularExpression(Me.txtToollotBuyQTY, "")
      Me.Validator.SetRequired(Me.txtToollotBuyQTY, False)
      Me.txtToollotBuyQTY.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotBuyQTY.TabIndex = 6
      Me.txtToollotBuyQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotBuyDate
      '
      Me.Validator.SetDataType(Me.txtToollotBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotBuyDate, "")
      Me.txtToollotBuyDate.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtToollotBuyDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotBuyDate, System.Drawing.Color.Empty)
      Me.txtToollotBuyDate.Location = New System.Drawing.Point(134, 101)
      Me.Validator.SetMinValue(Me.txtToollotBuyDate, "")
      Me.txtToollotBuyDate.Name = "txtToollotBuyDate"
      Me.Validator.SetRegularExpression(Me.txtToollotBuyDate, "")
      Me.Validator.SetRequired(Me.txtToollotBuyDate, False)
      Me.txtToollotBuyDate.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotBuyDate.TabIndex = 3
      Me.txtToollotBuyDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotWriteOff
      '
      Me.Validator.SetDataType(Me.txtToollotWriteOff, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotWriteOff, "")
      Me.txtToollotWriteOff.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtToollotWriteOff, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotWriteOff, System.Drawing.Color.Empty)
      Me.txtToollotWriteOff.Location = New System.Drawing.Point(134, 263)
      Me.Validator.SetMinValue(Me.txtToollotWriteOff, "")
      Me.txtToollotWriteOff.Name = "txtToollotWriteOff"
      Me.Validator.SetRegularExpression(Me.txtToollotWriteOff, "")
      Me.Validator.SetRequired(Me.txtToollotWriteOff, False)
      Me.txtToollotWriteOff.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotWriteOff.TabIndex = 9
      Me.txtToollotWriteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotRemainQTY
      '
      Me.Validator.SetDataType(Me.txtToollotRemainQTY, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotRemainQTY, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotRemainQTY, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotRemainQTY, System.Drawing.Color.Empty)
      Me.txtToollotRemainQTY.Location = New System.Drawing.Point(134, 209)
      Me.Validator.SetMinValue(Me.txtToollotRemainQTY, "")
      Me.txtToollotRemainQTY.Name = "txtToollotRemainQTY"
      Me.Validator.SetRegularExpression(Me.txtToollotRemainQTY, "")
      Me.Validator.SetRequired(Me.txtToollotRemainQTY, False)
      Me.txtToollotRemainQTY.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotRemainQTY.TabIndex = 7
      Me.txtToollotRemainQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotRemainCost
      '
      Me.Validator.SetDataType(Me.txtToollotRemainCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotRemainCost, "")
      Me.txtToollotRemainCost.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtToollotRemainCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotRemainCost, System.Drawing.Color.Empty)
      Me.txtToollotRemainCost.Location = New System.Drawing.Point(134, 290)
      Me.Validator.SetMinValue(Me.txtToollotRemainCost, "")
      Me.txtToollotRemainCost.Name = "txtToollotRemainCost"
      Me.Validator.SetRegularExpression(Me.txtToollotRemainCost, "")
      Me.Validator.SetRequired(Me.txtToollotRemainCost, False)
      Me.txtToollotRemainCost.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotRemainCost.TabIndex = 10
      Me.txtToollotRemainCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtToollotUnitCost
      '
      Me.Validator.SetDataType(Me.txtToollotUnitCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotUnitCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToollotUnitCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotUnitCost, System.Drawing.Color.Empty)
      Me.txtToollotUnitCost.Location = New System.Drawing.Point(134, 155)
      Me.Validator.SetMinValue(Me.txtToollotUnitCost, "")
      Me.txtToollotUnitCost.Name = "txtToollotUnitCost"
      Me.Validator.SetRegularExpression(Me.txtToollotUnitCost, "")
      Me.Validator.SetRequired(Me.txtToollotUnitCost, False)
      Me.txtToollotUnitCost.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotUnitCost.TabIndex = 5
      Me.txtToollotUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDescription
      '
      Me.Validator.SetDataType(Me.txtDescription, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDescription, "")
      Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDescription, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDescription, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDescription, System.Drawing.Color.Empty)
      Me.txtDescription.Location = New System.Drawing.Point(134, 317)
      Me.txtDescription.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtDescription, "")
      Me.txtDescription.Multiline = True
      Me.txtDescription.Name = "txtDescription"
      Me.Validator.SetRegularExpression(Me.txtDescription, "")
      Me.Validator.SetRequired(Me.txtDescription, False)
      Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDescription.Size = New System.Drawing.Size(248, 47)
      Me.txtDescription.TabIndex = 11
      Me.txtDescription.TabStop = False
      '
      'lblBrand
      '
      Me.lblBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBrand.ForeColor = System.Drawing.Color.Black
      Me.lblBrand.Location = New System.Drawing.Point(67, 128)
      Me.lblBrand.Name = "lblBrand"
      Me.lblBrand.Size = New System.Drawing.Size(64, 18)
      Me.lblBrand.TabIndex = 4
      Me.lblBrand.Text = "Brand :"
      Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWriteOff
      '
      Me.lblWriteOff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWriteOff.ForeColor = System.Drawing.Color.Black
      Me.lblWriteOff.Location = New System.Drawing.Point(68, 261)
      Me.lblWriteOff.Name = "lblWriteOff"
      Me.lblWriteOff.Size = New System.Drawing.Size(63, 23)
      Me.lblWriteOff.TabIndex = 5
      Me.lblWriteOff.Text = "Wirte Off  :"
      Me.lblWriteOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemianQTY
      '
      Me.lblRemianQTY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemianQTY.ForeColor = System.Drawing.Color.Black
      Me.lblRemianQTY.Location = New System.Drawing.Point(33, 207)
      Me.lblRemianQTY.Name = "lblRemianQTY"
      Me.lblRemianQTY.Size = New System.Drawing.Size(98, 23)
      Me.lblRemianQTY.TabIndex = 5
      Me.lblRemianQTY.Text = "Remain quantity  :"
      Me.lblRemianQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemainCost
      '
      Me.lblRemainCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemainCost.ForeColor = System.Drawing.Color.Black
      Me.lblRemainCost.Location = New System.Drawing.Point(52, 288)
      Me.lblRemainCost.Name = "lblRemainCost"
      Me.lblRemainCost.Size = New System.Drawing.Size(79, 23)
      Me.lblRemainCost.TabIndex = 5
      Me.lblRemainCost.Text = "Remain Cost :"
      Me.lblRemainCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuyQTY
      '
      Me.lblBuyQTY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyQTY.ForeColor = System.Drawing.Color.Black
      Me.lblBuyQTY.Location = New System.Drawing.Point(51, 180)
      Me.lblBuyQTY.Name = "lblBuyQTY"
      Me.lblBuyQTY.Size = New System.Drawing.Size(80, 23)
      Me.lblBuyQTY.TabIndex = 5
      Me.lblBuyQTY.Text = "Buy quantity :"
      Me.lblBuyQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblUnitCost
      '
      Me.lblUnitCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnitCost.ForeColor = System.Drawing.Color.Black
      Me.lblUnitCost.Location = New System.Drawing.Point(59, 153)
      Me.lblUnitCost.Name = "lblUnitCost"
      Me.lblUnitCost.Size = New System.Drawing.Size(72, 23)
      Me.lblUnitCost.TabIndex = 5
      Me.lblUnitCost.Text = "Unit Cost :"
      Me.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDescription
      '
      Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDescription.ForeColor = System.Drawing.Color.Black
      Me.lblDescription.Location = New System.Drawing.Point(59, 330)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(72, 23)
      Me.lblDescription.TabIndex = 5
      Me.lblDescription.Text = "Description :"
      Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnLoadImage
      '
      Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Location = New System.Drawing.Point(543, 15)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 204
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Location = New System.Drawing.Point(543, 41)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 205
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.Location = New System.Drawing.Point(422, 64)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.Size = New System.Drawing.Size(100, 23)
      Me.lblPicSize.TabIndex = 206
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'picImage
      '
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImage.Location = New System.Drawing.Point(396, 15)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(143, 129)
      Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picImage.TabIndex = 203
      Me.picImage.TabStop = False
      '
      'TxtToollotbrand
      '
      Me.Validator.SetDataType(Me.TxtToollotbrand, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotbrand, "")
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotbrand, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotbrand, System.Drawing.Color.Empty)
      Me.TxtToollotbrand.Location = New System.Drawing.Point(134, 128)
      Me.Validator.SetMinValue(Me.TxtToollotbrand, "")
      Me.TxtToollotbrand.Name = "TxtToollotbrand"
      Me.Validator.SetRegularExpression(Me.TxtToollotbrand, "")
      Me.Validator.SetRequired(Me.TxtToollotbrand, False)
      Me.TxtToollotbrand.Size = New System.Drawing.Size(112, 21)
      Me.TxtToollotbrand.TabIndex = 4
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(134, 20)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(145, 21)
      Me.cmbCode.TabIndex = 0
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(280, 20)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 334
      Me.chkAutorun.TabStop = False
      '
      'lblToollotCode
      '
      Me.lblToollotCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToollotCode.ForeColor = System.Drawing.Color.Black
      Me.lblToollotCode.Location = New System.Drawing.Point(97, 20)
      Me.lblToollotCode.Name = "lblToollotCode"
      Me.lblToollotCode.Size = New System.Drawing.Size(34, 23)
      Me.lblToollotCode.TabIndex = 0
      Me.lblToollotCode.Text = "รหัส :"
      Me.lblToollotCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuycost
      '
      Me.lblBuycost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuycost.ForeColor = System.Drawing.Color.Black
      Me.lblBuycost.Location = New System.Drawing.Point(67, 236)
      Me.lblBuycost.Name = "lblBuycost"
      Me.lblBuycost.Size = New System.Drawing.Size(64, 18)
      Me.lblBuycost.TabIndex = 4
      Me.lblBuycost.Text = "มูลค่าซื้อ :"
      Me.lblBuycost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuydocdate
      '
      Me.lblBuydocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuydocdate.ForeColor = System.Drawing.Color.Black
      Me.lblBuydocdate.Location = New System.Drawing.Point(19, 99)
      Me.lblBuydocdate.Name = "lblBuydocdate"
      Me.lblBuydocdate.Size = New System.Drawing.Size(112, 23)
      Me.lblBuydocdate.TabIndex = 5
      Me.lblBuydocdate.Text = "วันที่ซื้อในเอกสาร :"
      Me.lblBuydocdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToollotbuydoccode
      '
      Me.Validator.SetDataType(Me.txtToollotbuydoccode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToollotbuydoccode, "")
      Me.txtToollotbuydoccode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToollotbuydoccode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToollotbuydoccode, System.Drawing.Color.Empty)
      Me.txtToollotbuydoccode.Location = New System.Drawing.Point(134, 74)
      Me.Validator.SetMinValue(Me.txtToollotbuydoccode, "")
      Me.txtToollotbuydoccode.Name = "txtToollotbuydoccode"
      Me.Validator.SetRegularExpression(Me.txtToollotbuydoccode, "")
      Me.Validator.SetRequired(Me.txtToollotbuydoccode, False)
      Me.txtToollotbuydoccode.Size = New System.Drawing.Size(112, 21)
      Me.txtToollotbuydoccode.TabIndex = 2
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(76, 47)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(55, 23)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "สินทรัพย์ :"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocnum
      '
      Me.lblDocnum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocnum.ForeColor = System.Drawing.Color.Black
      Me.lblDocnum.Location = New System.Drawing.Point(19, 72)
      Me.lblDocnum.Name = "lblDocnum"
      Me.lblDocnum.Size = New System.Drawing.Size(112, 23)
      Me.lblDocnum.TabIndex = 3
      Me.lblDocnum.Text = "เลขที่เอกสารซื้อ :"
      Me.lblDocnum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAssetFind
      '
      Me.btnAssetFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetFind.Location = New System.Drawing.Point(343, 45)
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
      Me.txtAssetName.Location = New System.Drawing.Point(221, 47)
      Me.Validator.SetMinValue(Me.txtAssetName, "")
      Me.txtAssetName.Name = "txtAssetName"
      Me.txtAssetName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetName, "")
      Me.Validator.SetRequired(Me.txtAssetName, False)
      Me.txtAssetName.Size = New System.Drawing.Size(119, 21)
      Me.txtAssetName.TabIndex = 339
      Me.txtAssetName.TabStop = False
      '
      'txtAssetCode
      '
      Me.Validator.SetDataType(Me.txtAssetCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCode, "")
      Me.txtAssetCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.txtAssetCode.Location = New System.Drawing.Point(134, 47)
      Me.Validator.SetMinValue(Me.txtAssetCode, "")
      Me.txtAssetCode.Name = "txtAssetCode"
      Me.Validator.SetRegularExpression(Me.txtAssetCode, "")
      Me.Validator.SetRequired(Me.txtAssetCode, False)
      Me.txtAssetCode.Size = New System.Drawing.Size(86, 21)
      Me.txtAssetCode.TabIndex = 1
      '
      'TxtToollotBuycost
      '
      Me.Validator.SetDataType(Me.TxtToollotBuycost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtToollotBuycost, "")
      Me.Validator.SetGotFocusBackColor(Me.TxtToollotBuycost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.TxtToollotBuycost, System.Drawing.Color.Empty)
      Me.TxtToollotBuycost.Location = New System.Drawing.Point(134, 236)
      Me.Validator.SetMinValue(Me.TxtToollotBuycost, "")
      Me.TxtToollotBuycost.Name = "TxtToollotBuycost"
      Me.Validator.SetRegularExpression(Me.TxtToollotBuycost, "")
      Me.Validator.SetRequired(Me.TxtToollotBuycost, False)
      Me.TxtToollotBuycost.Size = New System.Drawing.Size(112, 21)
      Me.TxtToollotBuycost.TabIndex = 8
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
      'ToolLotDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ToolLotDetailView"
      Me.Size = New System.Drawing.Size(1062, 771)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.Grbeqi.ResumeLayout(False)
      Me.Grbeqi.PerformLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCode}")
      'Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      'Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblName}")
      'Me.Validator.SetDisplayName(Me.txtToollotName, StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))

      'Me.lblDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDetail}")
      'Me.Validator.SetDisplayName(Me.txtDetail, StringHelper.GetRidOfAtEnd(Me.lblDetail.Text, ":"))

      'Me.Validator.SetDisplayName(Me.txtToollotName, StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))
      'Me.Validator.SetDisplayName(Me.txtRentalRate, StringHelper.GetRidOfAtEnd(Me.lblRentalRate.Text, ":"))
      'Me.Validator.SetDisplayName(Me.txtCostcenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostCentername.Text, ":"))
      'Me.Validator.SetDisplayName(Me.txtRentalUnitCode, StringHelper.GetRidOfAtEnd(Me.lblRentalunit.Text, ":"))
      'Me.lblGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblGl}")
      'Me.Validator.SetDisplayName(Me.txtGLCode, StringHelper.GetRidOfAtEnd(Me.lblGl.Text, ":"))


      'Me.lblDepreOpeningAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreOpeningAcct}")
      'Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreOpeningAcct.Text, ":"))

      'Me.lblDepreAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreAcct}")
      'Me.Validator.SetDisplayName(Me.txtDepreAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreAcct.Text, ":"))

      'Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblType}")
      'Me.Validator.SetDisplayName(Me.txtTypeCode, StringHelper.GetRidOfAtEnd(Me.lblType.Text, ":"))

      'Me.lblCostcenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCostcenter}")
      'Me.Validator.SetDisplayName(Me.txtCostcenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostcenter.Text, ":"))

      'Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblLocation}")
      'Me.Validator.SetDisplayName(Me.txtLocation, StringHelper.GetRidOfAtEnd(Me.lblLocation.Text, ":"))

      'Me.lblCalcRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCalcRate}")
      'Me.Validator.SetDisplayName(Me.txtCalcRate, StringHelper.GetRidOfAtEnd(Me.lblCalcRate.Text, ":"))

      'Me.lblEndCalcDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblEndCalcDate}")
      'Me.Validator.SetDisplayName(Me.txtEndCalcDate, StringHelper.GetRidOfAtEnd(Me.lblEndCalcDate.Text, ":"))

      'Me.lblAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAge}")
      'Me.Validator.SetDisplayName(Me.txtAge, StringHelper.GetRidOfAtEnd(Me.lblAge.Text, ":"))

      'Me.lblStartCalcAmnt.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblStartCalcAmnt}")
      'Me.Validator.SetDisplayName(Me.txtStartCalcAmt, StringHelper.GetRidOfAtEnd(Me.lblStartCalcAmnt.Text, ":"))


      'Me.lblCalcType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCalcType}")
      'Me.Validator.SetDisplayName(Me.txtCalcRate, StringHelper.GetRidOfAtEnd(Me.lblCalcType.Text, ":"))



      'Me.lblAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAge}")
      'Me.Validator.SetDisplayName(txtAge, lblAge.Text)

      ''Me.lblRent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRent}")
      ''Me.Validator.SetDisplayName(txtRent, lblRent.Text)
      ''Me.lblDateInval.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDateInval}")

      'Me.lblStartCalcDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblStartCalcDate}")
      'Me.Validator.SetDisplayName(txtStartCalcDate, lblStartCalcDate.Text)

      'Me.lblBuyPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyPrice}")
      'Me.Validator.SetDisplayName(txtBuyPrice, lblBuyPrice.Text)

      'Me.lblBuyDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDate}")
      'Me.Validator.SetDisplayName(TxtBuyDocDate, "วันที่ไม่ถูกต้อง")

      'Me.lblTransferDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblTransferDate}")
      'Me.Validator.SetDisplayName(txtTransferDate, lblTransferDate.Text)

      'Me.lblBuyFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyFrom}")
      'Me.Validator.SetDisplayName(txtBuyFrom, lblBuyFrom.Text)

      'Me.lblBuyDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDocCode}")
      'Me.Validator.SetDisplayName(txtBuyDocCode, lblBuyDocCode.Text)

      'Me.lblBuyDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDocDate}")
      'Me.Validator.SetDisplayName(txtBuyDocDate, lblBuyDocDate.Text)

      'Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblYear}")
      'Me.lblYear1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblYear1}")

      'Me.lblSavage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblSavage}")
      'Me.Validator.SetDisplayName(txtSalvage, lblSavage.Text)

      'Me.lblRemainingValue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRemainingValue}")
      'Me.Validator.SetDisplayName(txtRemainingValue, lblRemainingValue.Text)

      'Me.lblDepreOpenning.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreOpenning}")
      'Me.Validator.SetDisplayName(txtDepreOpenning, lblDepreOpenning.Text)

      'Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblNote}")
      'Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      'Me.ToolTip1.SetToolTip(Me.btnLoadImage, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnLoadImage}"))
      'Me.ToolTip1.SetToolTip(Me.btnClearImage, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnClearImage}"))
      'Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")
      'Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")

      'Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCurrency4.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCurrency5.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

      'Me.lblAssetStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAssetStatus}")

      'Me.grbStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbStatus}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbDetail}")
      'Me.grbCalcDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbCalcDetail}")
      'Me.grbBuyDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbBuyDetail}")

      'Me.chkCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkCancel}")
      'Me.chkDecay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkDecay}")


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
      'If m_refDoc Is Nothing Then
      '  Return
      'End If
      'If TypeOf m_refDoc Is Equipment Then
      '  m_entity = CType(m_refDoc, Equipment)
      'Else
      '  Return
      'End If
      'If m_entity Is Nothing Then
      ClearDetail()
      'Return
      'End If

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

      Dim row As TreeRow = Nothing
      Dim eqitem As ToolLot = Nothing




      Me.RefreshData()
      Me.RefreshDocs()
      TxtToollotName.Text = m_entity.Name
      txtToollotCode.Text = m_entity.Code

      'TxtToollotBuycost.Text = m_entity.ToolLot.UnitCost * m_entity.ToolLot.Buyqty
      'CmbToolCode.Text = doc.Equipment.Code

      'If Me.CurrentTagItem Is Nothing AndAlso Me.lv.Items.Count > 0 Then
      '  eqitem = Me.m_entity.ItemCollection(0)

      '  'ElseIf Not Me.CurrentTagItem Is Nothing Then
      '  '  eqitem = Me.CurrentTagItem
      '  Me.RefreshData(eqitem)
      'End If



      'txtToollotName.Text = Me.m_entity.Name


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

      'If Not Me.m_entity.Costcenter Is Nothing Then
      '  'txtCostcenterName.Text = Me.m_entity.Costcenter.Code
      '  txtCostcenterName.Text = Me.m_entity.Costcenter.Name
      'End If
      'If Not Me.m_entity.Type Is Nothing Then
      '  txtTypeCode.Text = Me.m_entity.Type.Code
      '  txtTypeName.Text = Me.m_entity.Type.Name
      'End If

      'txtLocation.Text = Me.m_entity.Location
      'txtNote.Text = Me.m_entity.Note
      'txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Qty)

      'cmbCalcType.SelectedIndex = Me.m_entity.CalcType.Value
      'For Each item As IdValuePair In Me.cmbCalcType.Items
      '  If Me.m_entity.CalcType Is item Then
      '    Me.cmbCalcType.SelectedItem = item
      '    Exit For
      '  End If
      'Next

      'Me.lblCurrentStatus.Text = Me.m_entity.Status.Description

      'txtAge.Text = Configuration.FormatToString(Me.m_entity.Age, DigitConfig.Int)
      '' วันที่เริ่มคำนวณค่าเสื่อม
      'txtStartCalcDate.Text = MinDateToNull(Me.m_entity.StartCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'dtpStartCalcDate.Value = MinDateToNow(Me.m_entity.StartCalcDate)
      '' วันที่สิ้นสุดคำนวณค่าเสื่อม
      'txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      '' ค่าการคำนวณ
      'txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Price)
      'txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
      'txtSalvage.Text = Configuration.FormatToString(Me.m_entity.Salvage, DigitConfig.Price)
      '' ค่าอัตโนมัติ
      'txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
      'txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)
      '' วันที่ซื้อ
      'TxtlastDateEdit.Text = MinDateToNull(Me.m_entity.LastEditDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'dtpLastEditDate.Value = MinDateToNow(Me.m_entity.LastEditDate)

      'TxtBuyDocDate.Text = MinDateToNull(Me.m_entity.Buydate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'dtpBuyDocDate.Value = MinDateToNow(Me.m_entity.Buydate)

      'TxtBuyDate.Text = MinDateToNull(eqitem.Buydate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'DateTimePicker2.Value = MinDateToNow(eqitem.Buydate)

      '' วันที่ยกค่าเสื่อมมา
      'txtTransferDate.Text = MinDateToNull(Me.m_entity.TransferDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'dtpTransferDate.Value = MinDateToNow(Me.m_entity.TransferDate)

      'txtBuyPrice.Text = Configuration.FormatToString(Me.m_entity.BuyPrice, DigitConfig.Price)
      'txtBuyDocCode.Text = Me.m_entity.BuyDocCode
      ' วันที่ซื้อในเอกสาร
      'TxtBuyDate.Text = MinDateToNull(Me.m_entity, "")
      'dtpBuyDocDate.Value = MinDateToNow(Me.m_entity.BuyDocDate)

      'txtBuyFrom.Text = Me.m_entity.BuyFrom

      'picImage.Image = Me.m_entity.Image
      'CheckLabelImgSize()

      'chkCancel.Checked = Me.m_entity.Canceled
      'If Me.m_entity.Status.Value = 4 Then   ' ชำรุด
      '  chkDecay.Checked = True
      'Else
      '  chkDecay.Checked = False
      'End If
      'cmbCode.Text = m_entity.Code

      'txtUnitCode.Text = Me.CurrentTagItem.Unit.Code
      'txtUnit.Text = Me.CurrentTagItem.Unit.Name

      'txtRentalUnitCode.Text = Me.CurrentTagItem.Rentalunit.Code
      'txtRentalunit.Text = Me.CurrentTagItem.Rentalunit.Name

      'txtToollotName.Text = m_entity.Name
      'CmbToolCode.Text = m_entity.Code

      'lblLasteditdate.Text = "รหัสผู้แก้ไขล่าสุด : " + CurrentTagItem.LastEditor.Name + " วันที่แก้ไขล่าสุด : " + CurrentTagItem.LastEditDate
      'txtDescription.Text = Me.CurrentTagItem.Description
      'Dim lastEdited As String = ""
      'If Not eqitem.LastEditor Is Nothing Then
      '  lastEdited = "รหัสผู้แก้ไขล่าสุด : " & eqitem.LastEditor.Name
      'End If
      'lastEdited &= " วันที่แก้ไขล่าสุด : " & eqitem.LastEditDate
      'Me.lblLasteditdate.Text = lastEdited.Trim

      SetLabelText()
      CheckFormEnable()
      Me.m_isInitialized = True
    End Sub
    Private Sub RefreshData()
      Me.m_isInitialized = False
      Dim toollotitem As ToolLot = Me.CurrentTagItem
      If Not toollotitem Is Nothing Then
        cmbCode.Text = toollotitem.Code
        Me.m_oldCode = toollotitem.Code
        Me.chkAutorun.Checked = toollotitem.Autogen
        Me.UpdateAutogenStatus()

        'Me.txtToollotName.Text = eqitem.Equipment.Name
        'Me.CmbToolCode.Text = eqitem.Equipment.Code

        'Me.txtToollotName.Text = toollotitem.Name


        'If Not doc.Buydate.Equals(dtpBuyDocDate.Value) Then
        '  If Not m_dateSetting Then
        '    Me.TxtBuyDocDate.Text = MinDateToNull(dtpBuyDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        '    doc.Buydate = dtpBuyDocDate.Value.ToShortDateString
        '  End If


        'Me.TxtToollotserailnumber.Text = eqitem.Serailnumber
        Me.TxtToollotbrand.Text = toollotitem.Brand

        'Me.txtlToollotlicense.Text = eqitem.License

        'If Not eqitem.CurrentStatus Is Nothing Then
        '  Me.TxtStatus.Text = eqitem.CurrentStatus.Description
        'Else
        '  Me.TxtStatus.Text = ""
        'End If

        'If eqitem.CurrentCostCenter.Code <> "" Then
        '  Me.TxtCostcenterAddress.Text = eqitem.CurrentCostCenter.Code & " : " & eqitem.CurrentCostCenter.Name
        'Else
        '  Me.TxtCostcenterAddress.Text = ""
        'End If


        'Me.TxtlastDateEdit.Text = MinDateToNull(toollotitem.LastEditDate, Me.StringParserService.Parse(""))
        'Try
        '  Me.dtpLastEditDate.Value = toollotitem.LastEditDate
        'Catch ex As Exception
        '  Me.dtpLastEditDate.Value = Now
        'End Try

        'If TxtBuyDocDate.Text = Date.Now Then
        'Me.TxtBuyDocDate.Text = MinDateToNull(toollotitem.Buydate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        'Try
        '  Me.dtpBuyDocDate.Value = toollotitem.Buydate
        'Catch ex As Exception
        '  Me.dtpBuyDocDate.Value = Now
        'End Try
        'Else
        '  Me.TxtBuyDocDate.Text = "โปรดระบุ"
        'End If


        Me.RefreshCost(toollotitem)

        'dtpLastEditDate.Value = MinDateToNow(Me.m_entity.LastEditDate)
        'Me.txtCostcenterCode.Text = toollotitem.Costcenter.Code
        'Me.txtCostCenterName.Text = toollotitem.Costcenter.Name

        Me.txtAssetCode.Text = toollotitem.Asset.Code
        Me.txtAssetName.Text = toollotitem.Asset.Name

        'Me.txtUnitCode.Text = toollotitem.Unit.Code
        'Me.txtUnit.Text = toollotitem.Unit.Name
        'Me.txtRentalUnitCode.Text = eqitem.Rentalunit.Code
        'Me.txtRentalunit.Text = eqitem.Rentalunit.Name

        If toollotitem.Buydoc Is Nothing Then
          Me.txtToollotbuydoccode.Text = ""
        Else
          Me.txtToollotbuydoccode.Text = toollotitem.Buydoc.Id
        End If





        'TxtBuyDocDate.Text = MinDateToNull(eqitem.Buydate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        'dtpBuyDocDate.Value = MinDateToNow(eqitem.Buydate)
        'If toollotitem.Rentalrate <> 0 Then
        '  Me.txtRentalRate.Text = toollotitem.Rentalrate
        'Else
        '  Me.txtRentalRate.Text = ""
        'End If

        Me.txtDescription.Text = toollotitem.Description

        'Dim lastEdited As String = ""
        'If Not toollotitem.LastEditor Is Nothing Then
        '  lastEdited = "รหัสผู้แก้ไขล่าสุด : " & toollotitem.LastEditor.Name
        'End If
        'lastEdited &= " วันที่แก้ไขล่าสุด : " & toollotitem.LastEditDate
        'Me.lblLasteditdate.Text = lastEdited.Trim
      End If

      Me.m_isInitialized = True
    End Sub
    Public Sub RefreshCost(ByVal toollotitem As ToolLot)
      ' Me.m_isInitialized = False

      If toollotitem Is Nothing Then
        toollotitem = Me.CurrentTagItem
      End If

      If Not toollotitem Is Nothing Then
        Me.txtToollotUnitCost.Text = toollotitem.UnitCost
        Me.txtToollotBuyQTY.Text = toollotitem.Buyqty
        Me.txtToollotWriteOff.Text = toollotitem.WriteOff
        Me.txtToollotRemainQTY.Text = toollotitem.RemainQTY
        Me.txtToollotRemainCost.Text = toollotitem.RemainCost
        Me.TxtToollotBuycost.Text = toollotitem.Buycost

        If toollotitem.Buycost <> 0 Then
          Me.TxtToollotBuycost.Text = Configuration.FormatToString(toollotitem.Buycost, DigitConfig.Price)
        Else
          Me.TxtToollotBuycost.Text = ""
        End If

        If toollotitem.UnitCost <> 0 Then
          Me.txtToollotUnitCost.Text = Configuration.FormatToString(toollotitem.UnitCost, DigitConfig.Price)
        Else
          Me.txtToollotUnitCost.Text = ""
        End If

        If toollotitem.Buyqty <> 0 Then
          Me.txtToollotBuyQTY.Text = Configuration.FormatToString(toollotitem.Buyqty, DigitConfig.Price)
        Else
          Me.txtToollotBuyQTY.Text = ""
        End If

        If toollotitem.RemainQTY <> 0 Then
          Me.txtToollotRemainQTY.Text = Configuration.FormatToString(toollotitem.RemainQTY, DigitConfig.Price)
        Else
          Me.txtToollotRemainQTY.Text = ""
        End If

        If toollotitem.WriteOff <> 0 Then
          Me.txtToollotWriteOff.Text = Configuration.FormatToString(toollotitem.WriteOff, DigitConfig.Price)
        Else
          Me.txtToollotWriteOff.Text = Configuration.FormatToString(toollotitem.Buyqty - toollotitem.RemainQTY, DigitConfig.Price) '(txtToollotBuyQTY.Text - txtToollotRemainQTY.Text, DigitConfig.Price)
        End If

        If toollotitem.RemainCost <> 0 Then
          Me.txtToollotRemainCost.Text = Configuration.FormatToString(toollotitem.RemainCost, DigitConfig.Price)
        Else
          Me.txtToollotRemainCost.Text = Configuration.FormatToString(toollotitem.RemainQTY * toollotitem.UnitCost, DigitConfig.Price) '(txtToollotRemainQTY.Text * txtToollotUnitCost.Text, DigitConfig.Price)
        End If
      End If

      'Me.m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Me.m_isInitialized = False
      'Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      'Me.m_treeManager.Treetable.AcceptChanges()
      'Me.m_isInitialized = True

      lv.Items.Clear()
      For Each tl As ToolLot In Me.m_entity.ItemCollection

        Dim lvItem As New ListViewItem(tl.Code)
        'lvItem.SubItems.Add(tl.Code)
        'lvItem.SubItems.Add(tl.Name)
        lvItem.SubItems.Add(Configuration.FormatToString(tl.Buyqty, DigitConfig.Qty))
        lvItem.SubItems.Add(Configuration.FormatToString(tl.Buyqty - tl.RemainQTY, DigitConfig.Price)) 'WriteOff
        lvItem.SubItems.Add(Configuration.FormatToString(tl.RemainQTY, DigitConfig.Qty))

        'If Not eqi.CurrentStatus Is Nothing Then
        '  lvItem.SubItems.Add(eqi.CurrentStatus.Description)
        'Else
        '  lvItem.SubItems.Add("")
        'End If
        'If Not eqi.Costcenter Is Nothing Then
        'lvItem.SubItems.Add(tl.Costcenter.Code & ":" & tl.Costcenter.Name)
        'End If
        lvItem.Tag = tl
        lv.Items.Add(lvItem).Tag = tl 'มีปัญหาตอนปิด
      Next
      Me.m_isInitialized = True
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


      AddHandler txtToollotUnitCost.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotUnitCost.TextChanged, AddressOf Me.TextHandler


      AddHandler txtToollotBuyQTY.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotBuyQTY.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToollotRemainQTY.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotRemainQTY.TextChanged, AddressOf Me.TextHandler


      AddHandler txtToollotWriteOff.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotWriteOff.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToollotRemainCost.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToollotRemainCost.TextChanged, AddressOf Me.TextHandler

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
      Dim doc As ToolLot = Me.CurrentTagItem
      If Me.m_entity.ToolLot Is Nothing Then
        '  doc = New EquipmentItem
        '  Me.m_entity.ItemCollection.Add(Doc)
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Dim tmpFlag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False

      Select Case CType(sender, Control).Name.ToLower

        'Case "cmbcode"
        '  doc.Code = cmbCode.Text
        '  dirtyFlag = True
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
          dirtyFlag = True

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
          '    'Me.RefreshDocs()
          '  End If

        Case "txtassetcode"
          If m_txtAssetCodeChanged Then
            dirtyFlag = Asset.GetAsset(Me.txtAssetCode, Me.txtAssetName, Me.CurrentTagItem.Asset) 'doc.Costcenter
            m_txtAssetCodeChanged = False
            'Me.RefreshDocs()
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
          dirtyFlag = True

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
            RefreshCost(doc)
            dirtyFlag = True
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
            RefreshCost(doc)
          End If

        Case "txttoollotbuyqty"
          If m_txtToollotBuyQTYchanged Then
            If txtToollotBuyQTY.TextLength > 0 AndAlso IsNumeric(txtToollotBuyQTY.Text) Then
              doc.Buyqty = CDec(txtToollotBuyQTY.Text)
            Else
              doc.Buyqty = 0
            End If
            m_txtToollotBuyQTYchanged = False
            RefreshCost(doc)
            dirtyFlag = True
          End If


        Case "txttoollotwriteoff"
          If m_txtToollotWriteOffchanged Then
            If txtToollotWriteOff.TextLength > 0 Then
              doc.WriteOff = CDec(txtToollotWriteOff.Text)
            Else
              doc.WriteOff = doc.WriteOff
            End If
            m_txtToollotWriteOffchanged = False
            RefreshCost(doc)
            dirtyFlag = True
          End If

        Case "txttoollotremainqty"
          If m_txtToollotRemainQTYchanged Then
            If txtToollotRemainQTY.TextLength > 0 AndAlso IsNumeric(txtToollotRemainQTY.Text) Then
              doc.RemainQTY = CDec(txtToollotRemainQTY.Text)
            Else
              doc.RemainQTY = 0
            End If
            m_txtToollotRemainQTYchanged = False
            RefreshCost(doc)
            dirtyFlag = True
          End If

        Case "txttoollotremaincost"
          If m_txtToollotRemainCostchanged Then
            If txtToollotRemainCost.TextLength > 0 Then
              doc.RemainCost = CDec(txtToollotRemainCost.Text)
            Else
              doc.RemainCost = 0
            End If
            m_txtToollotRemainCostchanged = False
            RefreshCost(doc)
            dirtyFlag = True
          End If

      End Select

      Me.m_isInitialized = tmpFlag
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      Me.RefreshDocs()
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
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Equipment"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.DataAlignment = HorizontalAlignment.Center
      csCode.ReadOnly = True
      csCode.TextBox.Name = "code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 100
      csName.ReadOnly = True
      csName.TextBox.Name = "name"

      Dim csStatus As New TreeTextColumn
      csStatus.MappingName = "status"
      csStatus.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.StatusHeaderText}")
      csStatus.NullText = ""
      csStatus.Width = 100
      csStatus.ReadOnly = True
      csStatus.TextBox.Name = "status"

      Dim csCostCenter As New TreeTextColumn
      csCostCenter.MappingName = "costcenter"
      csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EquipmentDetailView.CostCenterHeaderText}")
      csCostCenter.NullText = ""
      csCostCenter.Width = 100
      csCostCenter.ReadOnly = True
      csCostCenter.TextBox.Name = "costcenter"

      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csStatus)
      dst.GridColumnStyles.Add(csCostCenter)

      Return dst
    End Function
#End Region
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      ' Protected from ...
      If Me.m_entity.Canceled Then
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = False
        Next
        'For Each crlt As Control In grbStatus.Controls
        '  crlt.Enabled = False
        'Next
        'grbCalcDetail.Enabled = False
        'grbBuyDetail.Enabled = False
        'chkCancel.Enabled = True
      Else
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = True
        Next
        ''For Each ctrl As Control In grbStatus.Controls
        ''    ctrl.Enabled = True
        ''Next
        'grbCalcDetail.Enabled = True
        'grbBuyDetail.Enabled = True
        '' กำหนด columns ที่ต้องการ protect เมื่อมีการคำนวณค่าเสื่อม
        'CheckIsDepreciated(Me.m_entity.IsDepreciated)

      End If

      'SetValueFromAssetType()
    End Sub

    Public Sub ClearItemOnly()
      For Each ctrl As Control In Grbeqi.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

      '  For Each ctrl As Control In TabPage1.Controls
      '    If TypeOf ctrl Is TextBox Then
      '      ctrl.Text = ""
      '    End If
      '  Next
      '  For Each ctrl As Control In TabPage2.Controls
      '    If TypeOf ctrl Is TextBox Then
      '      ctrl.Text = ""
      '    End If
      '  Next
    End Sub

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

      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

      For Each ctrl As Control In Grbeqi.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next
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

      cmbCode.Text = ""
      'TxtlastDateEdit.Text = ""
      'dtpLastEditDate.Value = Date.Now

      'txtEndCalcDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      'TxtBuyDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'DateTimePicker2.Value = Date.Now

      'dtpBuyDocDate.Value = Date.Now
      'TxtBuyDocDate.Text = "" 'Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'lblLasteditdate.Text = "รหัสผู้แก้ไขล่าสุด" & " : " & " .... " & " วันที่แก้ไขล่าสุด : " & Date.Now.ToString("dd/MM/yyyy")

      Me.picImage.Image = Nothing

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

        'Hack:
        'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        'Me.m_isInitialized = False
        'RefreshDocs()
        'Me.m_entity.EquipmentItem = Me.m_entity.ItemCollection(0)
        'Me.RefreshData(Me.m_entity.EquipmentItem)
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
    Private Sub btnLoadImage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
      'Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim doc As ToolLot = Me.CurrentTagItem
      If doc Is Nothing Then
        Return
      End If
      Dim dlg As New OpenFileDialog

      Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
      dlg.Filter = String.Join("|", fileFilters)
      If dlg.ShowDialog = DialogResult.OK Then
        Dim img As Image = Image.FromFile(dlg.FileName)
        If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
          Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
          img = ImageHelper.Resize(img, percent)
        End If
        Me.picImage.Image = img
        m_entity.ToolLot.Image = img
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        CheckLabelImgSize()
      End If
    End Sub
    Private Sub btnClearImage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
      'Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      m_entity.ToolLot.Image = Nothing
      Me.picImage.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
      CheckLabelImgSize()
    End Sub
    Private Sub CheckLabelImgSize()
      Me.lblPicSize.Text = "120 X 120 pixel"
      If Me.m_entity.ToolLot.Image Is Nothing Then
        Me.lblPicSize.Visible = True
      Else
        Me.lblPicSize.Visible = False
      End If
    End Sub
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
    Private Sub btnTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New AssetType)
    End Sub
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

    '  RefreshDocs()

    '  'eqi.SetCurrentCostCenter(eqi.Costcenter)
    '  'Me.TxtCostcenterAddress.Text = eqi.CurrentCostCenter.Code & " : " & eqi.CurrentCostCenter.Name

    'End Sub
    Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetDialog)
    End Sub
    Private Sub SetAssetDialog(ByVal e As ISimpleEntity)
      Dim eqi As ToolLot = Me.CurrentTagItem
      If eqi Is Nothing Then
        Return
      End If
      Me.txtAssetCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Asset.GetAsset(txtAssetCode, txtAssetName, eqi.Asset)
      Me.RefreshDocs()
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
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private m_oldEqCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.m_entity Is Nothing Then
        Return
      End If

      Dim doc As ToolLot = Me.CurrentTagItem
      If doc Is Nothing Then
        Return
        'doc = New ToolLot
        'Me.m_entity.ItemCollection.Add(doc)
      End If

      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.cmbCode, False)
        Me.ErrorProvider1.SetError(Me.cmbCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, doc.EntityId, currentUserId)

        If doc.Code Is Nothing OrElse doc.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            doc.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            doc.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(doc.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            doc.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        doc.Code = m_oldCode
        doc.Autogen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        doc.Code = m_oldCode
        doc.Autogen = False
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

    'Private Sub CheckLabelImgSize()
    '  Me.lblPicSize.Text = "272 X 204 pixel"
    '  If Me.m_entity.Image Is Nothing Then
    '    Me.lblPicSize.Visible = True
    '  Else
    '    Me.lblPicSize.Visible = False
    '  End If
    'End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged

      Me.m_isInitialized = False
      'Me.RemoveEvent()
      If lv.SelectedItems.Count > 0 Then
        If Me.m_entity.ToolLot.Id <> CType(lv.SelectedItems(0).Tag, ToolLot).Id Then
          Me.m_entity.ToolLot = CType(lv.SelectedItems(0).Tag, ToolLot)
          Dim eqi As ToolLot = Me.CurrentTagItem
          Me.RefreshData()
        End If
      End If
      Me.m_isInitialized = True
      Me.EventWiring()
    End Sub

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
    'Me.RefreshData()



    'If Me.m_entity.ItemCollection.Count > -1 Then
    '  Return
    'End If
    'Dim newItem As New BlankItem("")
    'Dim prItem As New PRItem
    'lv.Items.Add = newItem
    'prItem.ItemType = New ItemType(0)
    'prItem.Qty = 0
    'Me.m_entity.ItemCollection.Insert(index, eqitem)
    'RefreshDocs()
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


    Private Sub ShowNewPanels(ByVal entity As ISimpleEntity)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(entity)
    End Sub
#End Region

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim eqi As New ToolLot
      If Not Me.m_entity.ItemCollection.Contains(eqi) Then
        Me.m_entity.ItemCollection.Add(eqi)
      End If
      Me.m_entity.ToolLot = eqi
      Me.ClearItemOnly()
      Me.RefreshDocs()
      'Me.ClearDetail()
      Me.chkAutorun.Checked = True
      Me.UpdateAutogenStatus()

    End Sub
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
    '  Me.RefreshDocs()
    'End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.ToolLot Is Nothing Then
        Return
      End If
      If Me.m_entity.ItemCollection.Contains(Me.m_entity.ToolLot) Then
        Me.m_entity.ItemCollection.Remove(Me.m_entity.ItemCollection.IndexOf(Me.m_entity.ToolLot))
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      If Me.m_entity.ItemCollection.Count > 0 Then
        Me.m_entity.ToolLot = Me.m_entity.ItemCollection(0)
        Me.RefreshDocs()
        Me.RefreshData()
      End If
    End Sub

    'Private Sub ibtnShowUnitDialog1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit1) '******
    'End Sub

    Private Sub ibtnShowUnit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ShowNewPanels(New Unit)
    End Sub

    'Private Sub ibtnShowUnitDialog2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowRentalUnitDialog2.Click
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit2)
    'End Sub
    Private Sub ibtnShowUnit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ShowNewPanels(New Unit)
    End Sub
    Private Sub chkAutorun_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub

    'Private Sub chkEqAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  UpdateEqAutogenStatus()
    'End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
      'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      Dim filters(0) As Filter
      filters(0) = New Filter("id", 0)

      'myEntityPanelService.OpenDetailPanel(New GoodsReceipt)

      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems


      Dim Entities As New ArrayList

      Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()

      Me.RefreshDocs()

      Me.UpdateAutogenStatus()

    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)

      Dim newCode As String = ""
      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

      Me.m_entity.ItemCollection.SetItems(items, newCode, currentUserId)

    End Sub

    Private Sub btnDel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
      'If Me.m_entity.EquipmentItem Is Nothing Then
      '  Return
      'End If
      'If Me.m_entity.ItemCollection.Contains(Me.m_entity.EquipmentItem) Then
      '  Me.m_entity.ItemCollection.Remove(Me.m_entity.ItemCollection.IndexOf(Me.m_entity.EquipmentItem))
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
      'If Me.m_entity.ItemCollection.Count > 0 Then
      '  'Me.m_entity.EquipmentItem = Me.m_entity.ItemCollection(0)
      '  Me.RefreshDocs()
      '  Me.RefreshData()
      'End If
    End Sub

    Private Sub TxtToollotName_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtToollotName.EnabledChanged

    End Sub
  End Class

End Namespace
