Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolDetailView
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
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        Friend WithEvents ibtnShowDefaultUnitDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtUnitName As System.Windows.Forms.TextBox
        Friend WithEvents txtfairprice As System.Windows.Forms.TextBox
        Friend WithEvents lblfairprice As System.Windows.Forms.Label
        Friend WithEvents lblbath As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents txtUnitCode As System.Windows.Forms.TextBox
        Friend WithEvents btnUnitEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblRent As System.Windows.Forms.Label
        Friend WithEvents txtRent As System.Windows.Forms.TextBox
        Friend WithEvents lblDateInval As System.Windows.Forms.Label
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostCentername As System.Windows.Forms.Label
    Friend WithEvents txtCostcenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowcostcenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCostcenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblPicSize As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCostCentername = New System.Windows.Forms.Label()
      Me.txtCostcenterCode = New System.Windows.Forms.TextBox()
      Me.lblPicSize = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowcostcenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnCostcenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblRent = New System.Windows.Forms.Label()
      Me.txtRent = New System.Windows.Forms.TextBox()
      Me.lblDateInval = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.btnUnitEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ibtnShowDefaultUnitDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.picImage = New System.Windows.Forms.PictureBox()
      Me.txtGroupCode = New System.Windows.Forms.TextBox()
      Me.lblGroup = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtGroupName = New System.Windows.Forms.TextBox()
      Me.txtUnitCode = New System.Windows.Forms.TextBox()
      Me.lblUnit = New System.Windows.Forms.Label()
      Me.txtfairprice = New System.Windows.Forms.TextBox()
      Me.lblfairprice = New System.Windows.Forms.Label()
      Me.lblbath = New System.Windows.Forms.Label()
      Me.txtUnitName = New System.Windows.Forms.TextBox()
      Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCostCentername)
            Me.grbDetail.Controls.Add(Me.txtCostcenterCode)
      Me.grbDetail.Controls.Add(Me.lblPicSize)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnLoadImage)
      Me.grbDetail.Controls.Add(Me.ibtnShowcostcenter)
      Me.grbDetail.Controls.Add(Me.btnClearImage)
      Me.grbDetail.Controls.Add(Me.ibtnCostcenterDialog)
      Me.grbDetail.Controls.Add(Me.lblRent)
      Me.grbDetail.Controls.Add(Me.txtRent)
      Me.grbDetail.Controls.Add(Me.lblDateInval)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.btnUnitEdit)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.ibtnShowDefaultUnitDialog)
      Me.grbDetail.Controls.Add(Me.picImage)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.Controls.Add(Me.txtUnitCode)
      Me.grbDetail.Controls.Add(Me.lblUnit)
      Me.grbDetail.Controls.Add(Me.txtfairprice)
      Me.grbDetail.Controls.Add(Me.lblfairprice)
      Me.grbDetail.Controls.Add(Me.lblbath)
      Me.grbDetail.Controls.Add(Me.txtUnitName)
      Me.grbDetail.Controls.Add(Me.btnGroupEdit)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(563, 447)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูล Tool : "
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(11, 240)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(523, 180)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 347
      Me.tgItem.TreeManager = Nothing
      '
      'lblCostCentername
      '
      Me.lblCostCentername.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCentername.ForeColor = System.Drawing.Color.Black
      Me.lblCostCentername.Location = New System.Drawing.Point(11, 171)
      Me.lblCostCentername.Name = "lblCostCentername"
      Me.lblCostCentername.Size = New System.Drawing.Size(77, 18)
      Me.lblCostCentername.TabIndex = 27
      Me.lblCostCentername.Text = "Cost center:"
      Me.lblCostCentername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostcenterCode
      '
      Me.Validator.SetDataType(Me.txtCostcenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostcenterCode, "")
      Me.txtCostcenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.txtCostcenterCode.Location = New System.Drawing.Point(96, 171)
      Me.txtCostcenterCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCostcenterCode, "")
      Me.txtCostcenterCode.Name = "txtCostcenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostcenterCode, "")
      Me.Validator.SetRequired(Me.txtCostcenterCode, False)
      Me.txtCostcenterCode.Size = New System.Drawing.Size(109, 21)
      Me.txtCostcenterCode.TabIndex = 24
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.Location = New System.Drawing.Point(434, 72)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.Size = New System.Drawing.Size(100, 23)
      Me.lblPicSize.TabIndex = 199
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(207, 171)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(153, 21)
      Me.txtCostCenterName.TabIndex = 28
      Me.txtCostCenterName.TabStop = False
      '
      'btnLoadImage
      '
      Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Location = New System.Drawing.Point(496, 152)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 197
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowcostcenter
      '
      Me.ibtnShowcostcenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowcostcenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowcostcenter.Location = New System.Drawing.Point(383, 169)
      Me.ibtnShowcostcenter.Name = "ibtnShowcostcenter"
      Me.ibtnShowcostcenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowcostcenter.TabIndex = 26
      Me.ibtnShowcostcenter.TabStop = False
      Me.ibtnShowcostcenter.ThemedImage = CType(resources.GetObject("ibtnShowcostcenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Location = New System.Drawing.Point(520, 152)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 198
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnCostcenterDialog
      '
      Me.ibtnCostcenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCostcenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCostcenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCostcenterDialog.Location = New System.Drawing.Point(360, 169)
      Me.ibtnCostcenterDialog.Name = "ibtnCostcenterDialog"
      Me.ibtnCostcenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCostcenterDialog.TabIndex = 25
      Me.ibtnCostcenterDialog.TabStop = False
      Me.ibtnCostcenterDialog.ThemedImage = CType(resources.GetObject("ibtnCostcenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblRent
      '
      Me.lblRent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRent.ForeColor = System.Drawing.Color.Black
      Me.lblRent.Location = New System.Drawing.Point(8, 144)
      Me.lblRent.Name = "lblRent"
      Me.lblRent.Size = New System.Drawing.Size(80, 18)
      Me.lblRent.TabIndex = 11
      Me.lblRent.Text = "ค่าเช่าพื้นฐาน:"
      Me.lblRent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRent
      '
      Me.Validator.SetDataType(Me.txtRent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtRent, "")
      Me.txtRent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRent, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRent, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRent, System.Drawing.Color.Empty)
      Me.txtRent.Location = New System.Drawing.Point(96, 144)
      Me.Validator.SetMinValue(Me.txtRent, "")
      Me.txtRent.Name = "txtRent"
      Me.Validator.SetRegularExpression(Me.txtRent, "")
      Me.Validator.SetRequired(Me.txtRent, False)
      Me.txtRent.Size = New System.Drawing.Size(112, 21)
      Me.txtRent.TabIndex = 6
      Me.txtRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDateInval
      '
      Me.lblDateInval.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDateInval.ForeColor = System.Drawing.Color.Black
      Me.lblDateInval.Location = New System.Drawing.Point(216, 144)
      Me.lblDateInval.Name = "lblDateInval"
      Me.lblDateInval.Size = New System.Drawing.Size(96, 18)
      Me.lblDateInval.TabIndex = 21
      Me.lblDateInval.Text = "บาทต่อหน่วยต่อวัน"
      Me.lblDateInval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(208, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 13
      '
      'btnUnitEdit
      '
      Me.btnUnitEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnUnitEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnUnitEdit.Location = New System.Drawing.Point(384, 72)
      Me.btnUnitEdit.Name = "btnUnitEdit"
      Me.btnUnitEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnUnitEdit.TabIndex = 16
      Me.btnUnitEdit.TabStop = False
      Me.btnUnitEdit.ThemedImage = CType(resources.GetObject("btnUnitEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStatus.Location = New System.Drawing.Point(8, 423)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 12
      Me.lblStatus.Text = "lblStatus"
      '
      'ibtnShowDefaultUnitDialog
      '
      Me.ibtnShowDefaultUnitDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowDefaultUnitDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowDefaultUnitDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowDefaultUnitDialog.Location = New System.Drawing.Point(360, 72)
      Me.ibtnShowDefaultUnitDialog.Name = "ibtnShowDefaultUnitDialog"
      Me.ibtnShowDefaultUnitDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowDefaultUnitDialog.TabIndex = 15
      Me.ibtnShowDefaultUnitDialog.TabStop = False
      Me.ibtnShowDefaultUnitDialog.ThemedImage = CType(resources.GetObject("ibtnShowDefaultUnitDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'picImage
      '
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImage.Location = New System.Drawing.Point(424, 24)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(120, 120)
      Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picImage.TabIndex = 196
      Me.picImage.TabStop = False
      '
      'txtGroupCode
      '
      Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupCode, "")
      Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtGroupCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.txtGroupCode.Location = New System.Drawing.Point(96, 96)
      Me.txtGroupCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtGroupCode, "")
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
      Me.Validator.SetRequired(Me.txtGroupCode, False)
      Me.txtGroupCode.Size = New System.Drawing.Size(112, 21)
      Me.txtGroupCode.TabIndex = 4
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(8, 96)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(80, 18)
      Me.lblGroup.TabIndex = 9
      Me.lblGroup.Text = "กลุ่ม:"
      Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(96, 48)
      Me.txtName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, False)
      Me.txtName.Size = New System.Drawing.Size(312, 21)
      Me.txtName.TabIndex = 2
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(80, 18)
      Me.lblName.TabIndex = 7
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCode.TabIndex = 1
      '
      'txtGroupName
      '
      Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupName, "")
      Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.txtGroupName.Location = New System.Drawing.Point(208, 96)
      Me.Validator.SetMinValue(Me.txtGroupName, "")
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGroupName, "")
      Me.Validator.SetRequired(Me.txtGroupName, False)
      Me.txtGroupName.Size = New System.Drawing.Size(152, 21)
      Me.txtGroupName.TabIndex = 17
      Me.txtGroupName.TabStop = False
      '
      'txtUnitCode
      '
      Me.Validator.SetDataType(Me.txtUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitCode, "")
      Me.txtUnitCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtUnitCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
      Me.txtUnitCode.Location = New System.Drawing.Point(96, 72)
      Me.txtUnitCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtUnitCode, "")
      Me.txtUnitCode.Name = "txtUnitCode"
      Me.Validator.SetRegularExpression(Me.txtUnitCode, "")
      Me.Validator.SetRequired(Me.txtUnitCode, False)
      Me.txtUnitCode.Size = New System.Drawing.Size(112, 21)
      Me.txtUnitCode.TabIndex = 3
      '
      'lblUnit
      '
      Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnit.ForeColor = System.Drawing.Color.Black
      Me.lblUnit.Location = New System.Drawing.Point(8, 72)
      Me.lblUnit.Name = "lblUnit"
      Me.lblUnit.Size = New System.Drawing.Size(80, 18)
      Me.lblUnit.TabIndex = 8
      Me.lblUnit.Text = "หน่วย:"
      Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtfairprice
      '
      Me.Validator.SetDataType(Me.txtfairprice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtfairprice, "")
      Me.txtfairprice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtfairprice, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtfairprice, -15)
      Me.Validator.SetInvalidBackColor(Me.txtfairprice, System.Drawing.Color.Empty)
      Me.txtfairprice.Location = New System.Drawing.Point(96, 120)
      Me.Validator.SetMinValue(Me.txtfairprice, "")
      Me.txtfairprice.Name = "txtfairprice"
      Me.Validator.SetRegularExpression(Me.txtfairprice, "")
      Me.Validator.SetRequired(Me.txtfairprice, False)
      Me.txtfairprice.Size = New System.Drawing.Size(112, 21)
      Me.txtfairprice.TabIndex = 5
      Me.txtfairprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblfairprice
      '
      Me.lblfairprice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblfairprice.ForeColor = System.Drawing.Color.Black
      Me.lblfairprice.Location = New System.Drawing.Point(8, 120)
      Me.lblfairprice.Name = "lblfairprice"
      Me.lblfairprice.Size = New System.Drawing.Size(80, 18)
      Me.lblfairprice.TabIndex = 10
      Me.lblfairprice.Text = "ราคากลาง:"
      Me.lblfairprice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblbath
      '
      Me.lblbath.AutoSize = True
      Me.lblbath.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblbath.ForeColor = System.Drawing.Color.Black
      Me.lblbath.Location = New System.Drawing.Point(216, 122)
      Me.lblbath.Name = "lblbath"
      Me.lblbath.Size = New System.Drawing.Size(27, 13)
      Me.lblbath.TabIndex = 20
      Me.lblbath.Text = "บาท"
      Me.lblbath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtUnitName
      '
      Me.Validator.SetDataType(Me.txtUnitName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitName, "")
      Me.txtUnitName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
      Me.txtUnitName.Location = New System.Drawing.Point(208, 72)
      Me.Validator.SetMinValue(Me.txtUnitName, "")
      Me.txtUnitName.Name = "txtUnitName"
      Me.txtUnitName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtUnitName, "")
      Me.Validator.SetRequired(Me.txtUnitName, False)
      Me.txtUnitName.Size = New System.Drawing.Size(152, 21)
      Me.txtUnitName.TabIndex = 14
      Me.txtUnitName.TabStop = False
      '
      'btnGroupEdit
      '
      Me.btnGroupEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupEdit.Location = New System.Drawing.Point(384, 96)
      Me.btnGroupEdit.Name = "btnGroupEdit"
      Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupEdit.TabIndex = 19
      Me.btnGroupEdit.TabStop = False
      Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnGroupFind
      '
      Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Location = New System.Drawing.Point(360, 96)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 18
      Me.btnGroupFind.TabStop = False
      Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ToolDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ToolDetailView"
      Me.Size = New System.Drawing.Size(579, 471)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    ' กำหนด Text ให้ Label controls 
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.lblName}")
      Me.Validator.SetDisplayName(txtName, lblName.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.lblGroup}")
      Me.Validator.SetDisplayName(txtGroupCode, lblGroup.Text)

      Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.lblUnit}")
      Me.Validator.SetDisplayName(txtUnitCode, lblUnit.Text)

      Me.lblfairprice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.lblfairprice}")
      Me.Validator.SetDisplayName(txtfairprice, lblfairprice.Text)

      Me.lblRent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRent}")
      Me.Validator.SetDisplayName(txtRent, lblRent.Text)
      Me.lblDateInval.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDateInval}")

      'Me.btnLoadImage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.btnLoadImage}")
      Me.lblbath.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolDetailView.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_entity As New Tool
    Private m_isInitialized As Boolean = False
#End Region

#Region "Properties"
    'Private ReadOnly Property CurrentTagItem() As EquipmentItem
    '  Get

    '    If Not Me.m_entity Is Nothing AndAlso Not Me.m_entity Is Nothing Then
    '      Return Me.m_entity
    '    Else
    '      If Me.m_entity.ItemCollection.Count > 0 Then
    '        Me.m_entity.EquipmentItem = Me.m_entity.ItemCollection(0)
    '        Return Me.m_entity.EquipmentItem
    '      End If
    '    End If
    '    Return Nothing
    '  End Get

    'End Property
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      UpdateEntityProperties()
      Me.EventWiring()

    End Sub
#End Region

#Region "Method"

#End Region

#Region "IListDetail"
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        'Me.chkcancel.Enabled = True
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
      End If
    End Sub
    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next
    End Sub

    ' กำหนดการทำงานของ Event Controls 
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtGroupCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtUnitCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtfairprice.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtfairprice.Validated, AddressOf Me.NumerberTextBoxChange

      AddHandler txtRent.Validated, AddressOf Me.NumerberTextBoxChange
      AddHandler txtRent.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCostcenterCode.Validated, AddressOf Me.ChangeProperty
    End Sub
    Dim m_txtCostcenterCodeChanged As Boolean = False
    'Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
    '  If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
    '    Return
    '  End If
    '  Select Case CType(sender, Control).Name.ToLower

    '    Case "txtcostcentercode"
    '      m_txtCostcenterCodeChanged = True

    '  End Select
    'End Sub

    Public Sub NumerberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrent"
          txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Price)
        Case "txtfairprice"
          txtfairprice.Text = Configuration.FormatToString(Me.m_entity.FairPrice, DigitConfig.Price)
      End Select
    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      ' ทำการผูก Property ต่าง ๆ เข้ากับ control
      With Me
        .txtCode.Text = .m_entity.Code
        .txtName.Text = .m_entity.Name
        ' Autogencode 
        Me.m_oldCode = Me.m_entity.Code
        Me.chkAutorun.Checked = Me.m_entity.AutoGen
        Me.UpdateAutogenStatus()

        .txtfairprice.Text = Configuration.FormatToString(.m_entity.FairPrice, DigitConfig.Price)
        txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Qty)
        .picImage.Image = Me.m_entity.Image
        CheckLabelImgSize()
        ' ToolGroup ...
        If Not .m_entity.Group Is Nothing Then
          .txtGroupCode.Text = .m_entity.Group.Code
          .txtGroupName.Text = .m_entity.Group.Name
        End If
        ' ToolUnit ...
        If Not .m_entity.MemoryUnit Is Nothing Then
          .txtUnitCode.Text = .m_entity.MemoryUnit.Code
          .txtUnitName.Text = .m_entity.MemoryUnit.Name
        End If

        If Not .m_entity.Costcenter Is Nothing Then
          .txtCostcenterCode.Text = .m_entity.Costcenter.Code
          .txtCostCenterName.Text = .m_entity.Costcenter.Name
        End If

      End With
      SetStatus()
      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Tool)
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      PopulateToolUnit()
      PopulateToolGroup()
    End Sub

    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = Me.txtCode.Text
          dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = Me.txtName.Text
          dirtyFlag = True
        Case "txtgroupcode"
          dirtyFlag = ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)
        Case "txtfairprice"
          If txtfairprice.TextLength > 0 Then
            Me.m_entity.FairPrice = CDec(Me.txtfairprice.Text)
          Else
            Me.m_entity.FairPrice = Nothing
          End If
          dirtyFlag = True
        Case "txtrent"
          If txtRent.TextLength > 0 Then
            Me.m_entity.RentalRate = CDec(txtRent.Text)
          Else
            Me.m_entity.RentalRate = Nothing
          End If
          dirtyFlag = True
        Case "txtunitcode"
          dirtyFlag = Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.MemoryUnit)
        Case "txtcostcentercode"
                    dirtyFlag = CostCenter.GetCostCenter(Me.txtCostcenterCode, Me.txtCostCenterName, Me.m_entity.Costcenter)
                    'doc.Costcenter
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      SetStatus()
    End Sub

    Public Sub SetStatus()
      If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = "ยังไม่ได้บันทึก"
      End If
    End Sub

    Private Sub PopulateToolUnit()
      Dim tunit As New Unit
      'acct.PopulateTree(ddtAccount.treeView, Nothing)
    End Sub

    Private Sub PopulateToolGroup()
      Dim tgroup As New ToolGroup
      'acct.PopulateTree(ddtAccount.treeView, Nothing)
    End Sub

    Private Sub PopulateToolCostcenter()
      Dim tcostcenter As New CostCenter
      'acct.PopulateTree(ddtAccount.treeView, Nothing)
    End Sub
#End Region

#Region "Event of Control"

#End Region

#Region "IReversibleEntityProperty"
    '#Region "Members"
    '        Private m_oldCode As String
    '        Private m_oldName As String
    '#End Region
    '        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties

    '        End Sub

    '        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties

    '        End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Unit).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtunitcode", "txtunitname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New ToolGroup).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtgroupcode", "txtgroupname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcostcentercode", "txtcostcentername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Unit).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Unit).FullClassName))
        Dim entity As New Unit(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtunitcode", "txtunitname"
              Me.SetUnit(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New ToolGroup).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New ToolGroup).FullClassName))
        Dim entity As New ToolGroup(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtgroupcode", "txtgroupname"
              Me.SetToolGroup(entity)
          End Select
        End If
      End If

      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercode", "txtcostcentername"
              Me.SetToolGroup(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Event of Buttons "
    Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
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
        Me.m_entity.Image = img
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        CheckLabelImgSize()
      End If
    End Sub

    Private Sub btnUnitEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Unit)
    End Sub

    Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New ToolGroup)
    End Sub
    Private Sub ibtnShowDefaultUnitDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowDefaultUnitDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
    End Sub
    Private Sub SetUnit(ByVal e As ISimpleEntity)
      Me.txtUnitCode.Text = e.Code
      Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.MemoryUnit)
    End Sub
    Private Sub SetCostcenter(ByVal e As ISimpleEntity)
      If m_entity Is Nothing Then
        Return
      End If
      Me.txtCostcenterCode.Text = e.Code
      If m_entity.Costcenter Is Nothing Then
        m_entity.Costcenter = New CostCenter
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtCostcenterCode, txtCostCenterName, m_entity.Costcenter)
      'Me.txtCostcenterCode.Text = e.Code
      'CostCenter.GetCostCenter(txtCostcenterCode, txtCostCenterName, Me.m_entity.Costcenter)
    End Sub
    Private Sub SetToolGroup(ByVal e As ISimpleEntity)
      Me.txtGroupCode.Text = e.Code
      ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)
    End Sub
    Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroup)
    End Sub
    Private Sub ibtnCostcenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCostcenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenter)
    End Sub

    Private Sub ibtnShowcostcenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowcostcenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub



#End Region

#Region " AutoGenCode "
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

    Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
      m_entity.Image = Nothing
      Me.picImage.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
      CheckLabelImgSize()
    End Sub
    Private Sub CheckLabelImgSize()
      Me.lblPicSize.Text = "120 X 120 pixel"
      If Me.m_entity.Image Is Nothing Then
        Me.lblPicSize.Visible = True
      Else
        Me.lblPicSize.Visible = False
      End If
    End Sub

    
  End Class

End Namespace
