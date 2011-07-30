Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
	Public Class MaterialDetailView
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
		Friend WithEvents txtName As System.Windows.Forms.TextBox
		Friend WithEvents lblName As System.Windows.Forms.Label
		Friend WithEvents txtCode As System.Windows.Forms.TextBox
		Friend WithEvents lblCode As System.Windows.Forms.Label
		Friend WithEvents lblAltName As System.Windows.Forms.Label
		Friend WithEvents txtAltName As System.Windows.Forms.TextBox
		Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents picImage As System.Windows.Forms.PictureBox
		Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
		Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
		Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
		Friend WithEvents lblNote As System.Windows.Forms.Label
		Friend WithEvents txtNote As System.Windows.Forms.TextBox
		Friend WithEvents lblShelfLife As System.Windows.Forms.Label
		Friend WithEvents txtShelfLife As System.Windows.Forms.TextBox
		Friend WithEvents lblFairPrice As System.Windows.Forms.Label
		Friend WithEvents txtFairPrice As System.Windows.Forms.TextBox
		Friend WithEvents lblDefaultUnit As System.Windows.Forms.Label
		Friend WithEvents txtDefaultUnitCode As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitConversion3 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitConversion1 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitConversion2 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitCode1 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitCode3 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnitCode2 As System.Windows.Forms.TextBox
		Friend WithEvents lblDefaultUnit1 As System.Windows.Forms.Label
		Friend WithEvents lblDefaultUnit2 As System.Windows.Forms.Label
		Friend WithEvents lblDefaultUnit3 As System.Windows.Forms.Label
		Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
		Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
		Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
		Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
		Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
		Friend WithEvents lblLCI As System.Windows.Forms.Label
		Friend WithEvents grbOtherUnit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents lblUnit2 As System.Windows.Forms.Label
		Friend WithEvents lblUnit3 As System.Windows.Forms.Label
		Friend WithEvents lblUnit1 As System.Windows.Forms.Label
		Friend WithEvents ibtnShowUnit1 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowUnit3 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowUnit2 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblEqualSign1 As System.Windows.Forms.Label
		Friend WithEvents lblEqualSign2 As System.Windows.Forms.Label
		Friend WithEvents lblEqualSign3 As System.Windows.Forms.Label
		Friend WithEvents lblFairPriceUnit As System.Windows.Forms.Label
		Friend WithEvents ibtnShowDefaultUnit As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents grbLCI As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents lblStatus As System.Windows.Forms.Label
		Friend WithEvents grbMatDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents ibtnShowAccount As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblAccount As System.Windows.Forms.Label
		Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
		Friend WithEvents txtDefaultUnit As System.Windows.Forms.TextBox
		Friend WithEvents lblShelfLieUnit As System.Windows.Forms.Label
		Friend WithEvents txtAccount As System.Windows.Forms.TextBox
		Friend WithEvents txtUnit1 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnit2 As System.Windows.Forms.TextBox
		Friend WithEvents txtUnit3 As System.Windows.Forms.TextBox
		Friend WithEvents ibtnShowAccountDialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowDefaultUnitDialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowUnitDialog3 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowUnitDialog1 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowUnitDialog2 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents chkUnvatable As System.Windows.Forms.CheckBox
		Friend WithEvents lblMVCostUnit As System.Windows.Forms.Label
		Friend WithEvents lblMVCost As System.Windows.Forms.Label
		Friend WithEvents txtMVCost As System.Windows.Forms.TextBox
		Friend WithEvents lblLevel As System.Windows.Forms.Label
		Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLock As System.Windows.Forms.Button
    Friend WithEvents lblPicSize As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnLock = New System.Windows.Forms.Button()
      Me.grbMatDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblPicSize = New System.Windows.Forms.Label()
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccount = New System.Windows.Forms.TextBox()
      Me.txtDefaultUnit = New System.Windows.Forms.TextBox()
      Me.lblShelfLife = New System.Windows.Forms.Label()
      Me.txtShelfLife = New System.Windows.Forms.TextBox()
      Me.lblShelfLieUnit = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.chkCancel = New System.Windows.Forms.CheckBox()
      Me.ibtnShowDefaultUnit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDefaultUnit = New System.Windows.Forms.Label()
      Me.lblFairPriceUnit = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.picImage = New System.Windows.Forms.PictureBox()
      Me.txtDefaultUnitCode = New System.Windows.Forms.TextBox()
      Me.txtFairPrice = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblFairPrice = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.ibtnShowAccount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.ibtnShowAccountDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowDefaultUnitDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkUnvatable = New System.Windows.Forms.CheckBox()
      Me.lblMVCostUnit = New System.Windows.Forms.Label()
      Me.lblMVCost = New System.Windows.Forms.Label()
      Me.txtMVCost = New System.Windows.Forms.TextBox()
      Me.grbLCI = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblAltName = New System.Windows.Forms.Label()
      Me.txtAltName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtlv1 = New System.Windows.Forms.TextBox()
      Me.lblLCI = New System.Windows.Forms.Label()
      Me.txtlv5 = New System.Windows.Forms.TextBox()
      Me.txtlv4 = New System.Windows.Forms.TextBox()
      Me.txtlv3 = New System.Windows.Forms.TextBox()
      Me.txtlv2 = New System.Windows.Forms.TextBox()
      Me.lblLevel = New System.Windows.Forms.Label()
      Me.grbOtherUnit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowUnitDialog3 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtUnit3 = New System.Windows.Forms.TextBox()
      Me.txtUnit2 = New System.Windows.Forms.TextBox()
      Me.txtUnit1 = New System.Windows.Forms.TextBox()
      Me.txtUnitConversion3 = New System.Windows.Forms.TextBox()
      Me.txtUnitConversion1 = New System.Windows.Forms.TextBox()
      Me.lblUnit2 = New System.Windows.Forms.Label()
      Me.lblUnit3 = New System.Windows.Forms.Label()
      Me.txtUnitConversion2 = New System.Windows.Forms.TextBox()
      Me.lblUnit1 = New System.Windows.Forms.Label()
      Me.ibtnShowUnit1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtUnitCode1 = New System.Windows.Forms.TextBox()
      Me.txtUnitCode3 = New System.Windows.Forms.TextBox()
      Me.ibtnShowUnit3 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtUnitCode2 = New System.Windows.Forms.TextBox()
      Me.ibtnShowUnit2 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDefaultUnit1 = New System.Windows.Forms.Label()
      Me.lblDefaultUnit2 = New System.Windows.Forms.Label()
      Me.lblDefaultUnit3 = New System.Windows.Forms.Label()
      Me.lblEqualSign1 = New System.Windows.Forms.Label()
      Me.lblEqualSign2 = New System.Windows.Forms.Label()
      Me.lblEqualSign3 = New System.Windows.Forms.Label()
      Me.ibtnShowUnitDialog1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowUnitDialog2 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbMatDetail.SuspendLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbLCI.SuspendLayout()
      Me.grbOtherUnit.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnLock)
      Me.grbDetail.Controls.Add(Me.grbMatDetail)
      Me.grbDetail.Controls.Add(Me.grbLCI)
      Me.grbDetail.Controls.Add(Me.grbOtherUnit)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(528, 488)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'btnLock
      '
      Me.btnLock.Image = Global.My.Resources.Resources.padlock_locked
      Me.btnLock.Location = New System.Drawing.Point(384, 27)
      Me.btnLock.Name = "btnLock"
      Me.btnLock.Size = New System.Drawing.Size(39, 44)
      Me.btnLock.TabIndex = 18
      Me.btnLock.UseVisualStyleBackColor = True
      '
      'grbMatDetail
      '
      Me.grbMatDetail.Controls.Add(Me.lblPicSize)
      Me.grbMatDetail.Controls.Add(Me.btnLoadImage)
      Me.grbMatDetail.Controls.Add(Me.btnClearImage)
      Me.grbMatDetail.Controls.Add(Me.txtAccount)
      Me.grbMatDetail.Controls.Add(Me.txtDefaultUnit)
      Me.grbMatDetail.Controls.Add(Me.lblShelfLife)
      Me.grbMatDetail.Controls.Add(Me.txtShelfLife)
      Me.grbMatDetail.Controls.Add(Me.lblShelfLieUnit)
      Me.grbMatDetail.Controls.Add(Me.txtNote)
      Me.grbMatDetail.Controls.Add(Me.chkCancel)
      Me.grbMatDetail.Controls.Add(Me.ibtnShowDefaultUnit)
      Me.grbMatDetail.Controls.Add(Me.lblDefaultUnit)
      Me.grbMatDetail.Controls.Add(Me.lblFairPriceUnit)
      Me.grbMatDetail.Controls.Add(Me.lblCode)
      Me.grbMatDetail.Controls.Add(Me.picImage)
      Me.grbMatDetail.Controls.Add(Me.txtDefaultUnitCode)
      Me.grbMatDetail.Controls.Add(Me.txtFairPrice)
      Me.grbMatDetail.Controls.Add(Me.lblNote)
      Me.grbMatDetail.Controls.Add(Me.lblFairPrice)
      Me.grbMatDetail.Controls.Add(Me.txtCode)
      Me.grbMatDetail.Controls.Add(Me.ibtnShowAccount)
      Me.grbMatDetail.Controls.Add(Me.lblAccount)
      Me.grbMatDetail.Controls.Add(Me.txtAccountCode)
      Me.grbMatDetail.Controls.Add(Me.ibtnShowAccountDialog)
      Me.grbMatDetail.Controls.Add(Me.ibtnShowDefaultUnitDialog)
      Me.grbMatDetail.Controls.Add(Me.chkUnvatable)
      Me.grbMatDetail.Controls.Add(Me.lblMVCostUnit)
      Me.grbMatDetail.Controls.Add(Me.lblMVCost)
      Me.grbMatDetail.Controls.Add(Me.txtMVCost)
      Me.grbMatDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMatDetail.Location = New System.Drawing.Point(8, 128)
      Me.grbMatDetail.Name = "grbMatDetail"
      Me.grbMatDetail.Size = New System.Drawing.Size(509, 224)
      Me.grbMatDetail.TabIndex = 1
      Me.grbMatDetail.TabStop = False
      Me.grbMatDetail.Text = "รายละเอียด material"
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.Location = New System.Drawing.Point(386, 72)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.Size = New System.Drawing.Size(100, 23)
      Me.lblPicSize.TabIndex = 60
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLoadImage
      '
      Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Location = New System.Drawing.Point(448, 152)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 31
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Location = New System.Drawing.Point(472, 152)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 32
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccount
      '
      Me.Validator.SetDataType(Me.txtAccount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccount, "")
      Me.txtAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.txtAccount.Location = New System.Drawing.Point(168, 72)
      Me.Validator.SetMinValue(Me.txtAccount, "")
      Me.txtAccount.Name = "txtAccount"
      Me.txtAccount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccount, "")
      Me.Validator.SetRequired(Me.txtAccount, False)
      Me.txtAccount.Size = New System.Drawing.Size(120, 21)
      Me.txtAccount.TabIndex = 16
      Me.txtAccount.TabStop = False
      Me.txtAccount.Tag = "NotGigaSite"
      '
      'txtDefaultUnit
      '
      Me.Validator.SetDataType(Me.txtDefaultUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDefaultUnit, "")
      Me.txtDefaultUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDefaultUnit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDefaultUnit, System.Drawing.Color.Empty)
      Me.txtDefaultUnit.Location = New System.Drawing.Point(168, 192)
      Me.Validator.SetMinValue(Me.txtDefaultUnit, "")
      Me.txtDefaultUnit.Name = "txtDefaultUnit"
      Me.txtDefaultUnit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDefaultUnit, "")
      Me.Validator.SetRequired(Me.txtDefaultUnit, False)
      Me.txtDefaultUnit.Size = New System.Drawing.Size(120, 21)
      Me.txtDefaultUnit.TabIndex = 23
      Me.txtDefaultUnit.TabStop = False
      '
      'lblShelfLife
      '
      Me.lblShelfLife.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblShelfLife.ForeColor = System.Drawing.Color.Black
      Me.lblShelfLife.Location = New System.Drawing.Point(16, 48)
      Me.lblShelfLife.Name = "lblShelfLife"
      Me.lblShelfLife.Size = New System.Drawing.Size(96, 18)
      Me.lblShelfLife.TabIndex = 8
      Me.lblShelfLife.Text = "อายุการเก็บ:"
      Me.lblShelfLife.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtShelfLife
      '
      Me.Validator.SetDataType(Me.txtShelfLife, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int64Type)
      Me.Validator.SetDisplayName(Me.txtShelfLife, "")
      Me.txtShelfLife.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtShelfLife, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtShelfLife, System.Drawing.Color.Empty)
      Me.txtShelfLife.Location = New System.Drawing.Point(112, 48)
      Me.Validator.SetMinValue(Me.txtShelfLife, "0")
      Me.txtShelfLife.Name = "txtShelfLife"
      Me.Validator.SetRegularExpression(Me.txtShelfLife, "")
      Me.Validator.SetRequired(Me.txtShelfLife, False)
      Me.txtShelfLife.Size = New System.Drawing.Size(224, 21)
      Me.txtShelfLife.TabIndex = 1
      '
      'lblShelfLieUnit
      '
      Me.lblShelfLieUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblShelfLieUnit.ForeColor = System.Drawing.Color.Black
      Me.lblShelfLieUnit.Location = New System.Drawing.Point(336, 49)
      Me.lblShelfLieUnit.Name = "lblShelfLieUnit"
      Me.lblShelfLieUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblShelfLieUnit.TabIndex = 15
      Me.lblShelfLieUnit.Text = "วัน"
      Me.lblShelfLieUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(112, 120)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(224, 21)
      Me.txtNote.TabIndex = 3
      '
      'chkCancel
      '
      Me.chkCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.chkCancel.ForeColor = System.Drawing.Color.Black
      Me.chkCancel.Location = New System.Drawing.Point(240, 24)
      Me.chkCancel.Name = "chkCancel"
      Me.chkCancel.Size = New System.Drawing.Size(80, 20)
      Me.chkCancel.TabIndex = 14
      Me.chkCancel.TabStop = False
      Me.chkCancel.Text = "ยกเลิก"
      '
      'ibtnShowDefaultUnit
      '
      Me.ibtnShowDefaultUnit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowDefaultUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowDefaultUnit.Location = New System.Drawing.Point(312, 192)
      Me.ibtnShowDefaultUnit.Name = "ibtnShowDefaultUnit"
      Me.ibtnShowDefaultUnit.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowDefaultUnit.TabIndex = 25
      Me.ibtnShowDefaultUnit.TabStop = False
      Me.ibtnShowDefaultUnit.ThemedImage = CType(resources.GetObject("ibtnShowDefaultUnit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDefaultUnit
      '
      Me.lblDefaultUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDefaultUnit.ForeColor = System.Drawing.Color.Black
      Me.lblDefaultUnit.Location = New System.Drawing.Point(16, 192)
      Me.lblDefaultUnit.Name = "lblDefaultUnit"
      Me.lblDefaultUnit.Size = New System.Drawing.Size(96, 18)
      Me.lblDefaultUnit.TabIndex = 13
      Me.lblDefaultUnit.Text = "หน่วยนับหลัก:"
      Me.lblDefaultUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFairPriceUnit
      '
      Me.lblFairPriceUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFairPriceUnit.ForeColor = System.Drawing.Color.Black
      Me.lblFairPriceUnit.Location = New System.Drawing.Point(336, 144)
      Me.lblFairPriceUnit.Name = "lblFairPriceUnit"
      Me.lblFairPriceUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblFairPriceUnit.TabIndex = 20
      Me.lblFairPriceUnit.Text = "บาท"
      Me.lblFairPriceUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'picImage
      '
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImage.Location = New System.Drawing.Point(376, 24)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(120, 120)
      Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picImage.TabIndex = 14
      Me.picImage.TabStop = False
      '
      'txtDefaultUnitCode
      '
      Me.Validator.SetDataType(Me.txtDefaultUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDefaultUnitCode, "")
      Me.txtDefaultUnitCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDefaultUnitCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDefaultUnitCode, System.Drawing.Color.Empty)
      Me.txtDefaultUnitCode.Location = New System.Drawing.Point(112, 192)
      Me.Validator.SetMinValue(Me.txtDefaultUnitCode, "")
      Me.txtDefaultUnitCode.Name = "txtDefaultUnitCode"
      Me.Validator.SetRegularExpression(Me.txtDefaultUnitCode, "")
      Me.Validator.SetRequired(Me.txtDefaultUnitCode, True)
      Me.txtDefaultUnitCode.Size = New System.Drawing.Size(56, 21)
      Me.txtDefaultUnitCode.TabIndex = 6
      '
      'txtFairPrice
      '
      Me.Validator.SetDataType(Me.txtFairPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtFairPrice, "")
      Me.txtFairPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFairPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFairPrice, System.Drawing.Color.Empty)
      Me.txtFairPrice.Location = New System.Drawing.Point(112, 144)
      Me.Validator.SetMinValue(Me.txtFairPrice, "0")
      Me.txtFairPrice.Name = "txtFairPrice"
      Me.Validator.SetRegularExpression(Me.txtFairPrice, "")
      Me.Validator.SetRequired(Me.txtFairPrice, False)
      Me.txtFairPrice.Size = New System.Drawing.Size(224, 21)
      Me.txtFairPrice.TabIndex = 4
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(16, 120)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 10
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFairPrice
      '
      Me.lblFairPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFairPrice.ForeColor = System.Drawing.Color.Black
      Me.lblFairPrice.Location = New System.Drawing.Point(16, 144)
      Me.lblFairPrice.Name = "lblFairPrice"
      Me.lblFairPrice.Size = New System.Drawing.Size(96, 18)
      Me.lblFairPrice.TabIndex = 11
      Me.lblFairPrice.Text = "ราคากลาง:"
      Me.lblFairPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Enabled = False
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 24)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'ibtnShowAccount
      '
      Me.ibtnShowAccount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccount.Location = New System.Drawing.Point(312, 72)
      Me.ibtnShowAccount.Name = "ibtnShowAccount"
      Me.ibtnShowAccount.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccount.TabIndex = 18
      Me.ibtnShowAccount.TabStop = False
      Me.ibtnShowAccount.Tag = "NotGigaSite"
      Me.ibtnShowAccount.ThemedImage = CType(resources.GetObject("ibtnShowAccount.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(16, 72)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(96, 18)
      Me.lblAccount.TabIndex = 9
      Me.lblAccount.Tag = "NotGigaSite"
      Me.lblAccount.Text = "ผังบัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(112, 72)
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, True)
      Me.txtAccountCode.Size = New System.Drawing.Size(56, 21)
      Me.txtAccountCode.TabIndex = 2
      Me.txtAccountCode.Tag = "NotGigaSite"
      '
      'ibtnShowAccountDialog
      '
      Me.ibtnShowAccountDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAccountDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountDialog.Location = New System.Drawing.Point(288, 72)
      Me.ibtnShowAccountDialog.Name = "ibtnShowAccountDialog"
      Me.ibtnShowAccountDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountDialog.TabIndex = 17
      Me.ibtnShowAccountDialog.TabStop = False
      Me.ibtnShowAccountDialog.Tag = "NotGigaSite"
      Me.ibtnShowAccountDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowDefaultUnitDialog
      '
      Me.ibtnShowDefaultUnitDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowDefaultUnitDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowDefaultUnitDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowDefaultUnitDialog.Location = New System.Drawing.Point(288, 192)
      Me.ibtnShowDefaultUnitDialog.Name = "ibtnShowDefaultUnitDialog"
      Me.ibtnShowDefaultUnitDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowDefaultUnitDialog.TabIndex = 24
      Me.ibtnShowDefaultUnitDialog.TabStop = False
      Me.ibtnShowDefaultUnitDialog.ThemedImage = CType(resources.GetObject("ibtnShowDefaultUnitDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkUnvatable
      '
      Me.chkUnvatable.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkUnvatable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.chkUnvatable.ForeColor = System.Drawing.Color.Black
      Me.chkUnvatable.Location = New System.Drawing.Point(112, 96)
      Me.chkUnvatable.Name = "chkUnvatable"
      Me.chkUnvatable.Size = New System.Drawing.Size(80, 20)
      Me.chkUnvatable.TabIndex = 19
      Me.chkUnvatable.TabStop = False
      Me.chkUnvatable.Text = "ไม่คิดภาษี"
      '
      'lblMVCostUnit
      '
      Me.lblMVCostUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMVCostUnit.ForeColor = System.Drawing.Color.Black
      Me.lblMVCostUnit.Location = New System.Drawing.Point(336, 168)
      Me.lblMVCostUnit.Name = "lblMVCostUnit"
      Me.lblMVCostUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblMVCostUnit.TabIndex = 21
      Me.lblMVCostUnit.Text = "บาท"
      Me.lblMVCostUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMVCost
      '
      Me.lblMVCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMVCost.ForeColor = System.Drawing.Color.Black
      Me.lblMVCost.Location = New System.Drawing.Point(16, 168)
      Me.lblMVCost.Name = "lblMVCost"
      Me.lblMVCost.Size = New System.Drawing.Size(96, 18)
      Me.lblMVCost.TabIndex = 12
      Me.lblMVCost.Text = "ต้นทุนปัจจุบัน:"
      Me.lblMVCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMVCost
      '
      Me.Validator.SetDataType(Me.txtMVCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtMVCost, "")
      Me.txtMVCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtMVCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMVCost, System.Drawing.Color.Empty)
      Me.txtMVCost.Location = New System.Drawing.Point(112, 168)
      Me.Validator.SetMinValue(Me.txtMVCost, "0")
      Me.txtMVCost.Name = "txtMVCost"
      Me.txtMVCost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMVCost, "")
      Me.Validator.SetRequired(Me.txtMVCost, False)
      Me.txtMVCost.Size = New System.Drawing.Size(224, 21)
      Me.txtMVCost.TabIndex = 5
      '
      'grbLCI
      '
      Me.grbLCI.Controls.Add(Me.txtName)
      Me.grbLCI.Controls.Add(Me.lblAltName)
      Me.grbLCI.Controls.Add(Me.txtAltName)
      Me.grbLCI.Controls.Add(Me.lblName)
      Me.grbLCI.Controls.Add(Me.txtlv1)
      Me.grbLCI.Controls.Add(Me.lblLCI)
      Me.grbLCI.Controls.Add(Me.txtlv5)
      Me.grbLCI.Controls.Add(Me.txtlv4)
      Me.grbLCI.Controls.Add(Me.txtlv3)
      Me.grbLCI.Controls.Add(Me.txtlv2)
      Me.grbLCI.Controls.Add(Me.lblLevel)
      Me.grbLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLCI.Location = New System.Drawing.Point(8, 24)
      Me.grbLCI.Name = "grbLCI"
      Me.grbLCI.Size = New System.Drawing.Size(368, 104)
      Me.grbLCI.TabIndex = 0
      Me.grbLCI.TabStop = False
      Me.grbLCI.Text = "LCI"
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(104, 48)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(248, 21)
      Me.txtName.TabIndex = 5
      '
      'lblAltName
      '
      Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAltName.ForeColor = System.Drawing.Color.Black
      Me.lblAltName.Location = New System.Drawing.Point(8, 72)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(96, 18)
      Me.lblAltName.TabIndex = 9
      Me.lblAltName.Text = "ชื่ออื่น:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAltName
      '
      Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAltName, "")
      Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.txtAltName.Location = New System.Drawing.Point(104, 72)
      Me.Validator.SetMinValue(Me.txtAltName, "")
      Me.txtAltName.Name = "txtAltName"
      Me.Validator.SetRegularExpression(Me.txtAltName, "")
      Me.Validator.SetRequired(Me.txtAltName, False)
      Me.txtAltName.Size = New System.Drawing.Size(248, 21)
      Me.txtAltName.TabIndex = 6
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(96, 18)
      Me.lblName.TabIndex = 8
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtlv1
      '
      Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
      Me.Validator.SetDataType(Me.txtlv1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlv1, "")
      Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlv1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtlv1, System.Drawing.Color.Empty)
      Me.txtlv1.Location = New System.Drawing.Point(104, 24)
      Me.txtlv1.MaxLength = 2
      Me.Validator.SetMinValue(Me.txtlv1, "")
      Me.txtlv1.Name = "txtlv1"
      Me.txtlv1.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtlv1, "")
      Me.Validator.SetRequired(Me.txtlv1, False)
      Me.txtlv1.Size = New System.Drawing.Size(24, 23)
      Me.txtlv1.TabIndex = 0
      '
      'lblLCI
      '
      Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLCI.ForeColor = System.Drawing.Color.Black
      Me.lblLCI.Location = New System.Drawing.Point(16, 24)
      Me.lblLCI.Name = "lblLCI"
      Me.lblLCI.Size = New System.Drawing.Size(88, 20)
      Me.lblLCI.TabIndex = 7
      Me.lblLCI.Text = "LCI Code:"
      Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtlv5
      '
      Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtlv5, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlv5, "")
      Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlv5, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtlv5, System.Drawing.Color.Empty)
      Me.txtlv5.Location = New System.Drawing.Point(200, 24)
      Me.txtlv5.MaxLength = 7
      Me.Validator.SetMinValue(Me.txtlv5, "")
      Me.txtlv5.Name = "txtlv5"
      Me.Validator.SetRegularExpression(Me.txtlv5, "")
      Me.Validator.SetRequired(Me.txtlv5, False)
      Me.txtlv5.Size = New System.Drawing.Size(64, 23)
      Me.txtlv5.TabIndex = 4
      '
      'txtlv4
      '
      Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtlv4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlv4, "")
      Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlv4, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtlv4, System.Drawing.Color.Empty)
      Me.txtlv4.Location = New System.Drawing.Point(176, 24)
      Me.txtlv4.MaxLength = 2
      Me.Validator.SetMinValue(Me.txtlv4, "")
      Me.txtlv4.Name = "txtlv4"
      Me.txtlv4.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtlv4, "")
      Me.Validator.SetRequired(Me.txtlv4, False)
      Me.txtlv4.Size = New System.Drawing.Size(24, 23)
      Me.txtlv4.TabIndex = 3
      '
      'txtlv3
      '
      Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
      Me.Validator.SetDataType(Me.txtlv3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlv3, "")
      Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlv3, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtlv3, System.Drawing.Color.Empty)
      Me.txtlv3.Location = New System.Drawing.Point(152, 24)
      Me.txtlv3.MaxLength = 2
      Me.Validator.SetMinValue(Me.txtlv3, "")
      Me.txtlv3.Name = "txtlv3"
      Me.txtlv3.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtlv3, "")
      Me.Validator.SetRequired(Me.txtlv3, False)
      Me.txtlv3.Size = New System.Drawing.Size(24, 23)
      Me.txtlv3.TabIndex = 2
      '
      'txtlv2
      '
      Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
      Me.Validator.SetDataType(Me.txtlv2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlv2, "")
      Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlv2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtlv2, System.Drawing.Color.Empty)
      Me.txtlv2.Location = New System.Drawing.Point(128, 24)
      Me.txtlv2.MaxLength = 2
      Me.Validator.SetMinValue(Me.txtlv2, "")
      Me.txtlv2.Name = "txtlv2"
      Me.txtlv2.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtlv2, "")
      Me.Validator.SetRequired(Me.txtlv2, False)
      Me.txtlv2.Size = New System.Drawing.Size(24, 23)
      Me.txtlv2.TabIndex = 1
      '
      'lblLevel
      '
      Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel.ForeColor = System.Drawing.Color.Black
      Me.lblLevel.Location = New System.Drawing.Point(280, 24)
      Me.lblLevel.Name = "lblLevel"
      Me.lblLevel.Size = New System.Drawing.Size(72, 20)
      Me.lblLevel.TabIndex = 7
      Me.lblLevel.Text = "Level"
      Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbOtherUnit
      '
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnitDialog3)
      Me.grbOtherUnit.Controls.Add(Me.txtUnit3)
      Me.grbOtherUnit.Controls.Add(Me.txtUnit2)
      Me.grbOtherUnit.Controls.Add(Me.txtUnit1)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitConversion3)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitConversion1)
      Me.grbOtherUnit.Controls.Add(Me.lblUnit2)
      Me.grbOtherUnit.Controls.Add(Me.lblUnit3)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitConversion2)
      Me.grbOtherUnit.Controls.Add(Me.lblUnit1)
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnit1)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitCode1)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitCode3)
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnit3)
      Me.grbOtherUnit.Controls.Add(Me.txtUnitCode2)
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnit2)
      Me.grbOtherUnit.Controls.Add(Me.lblDefaultUnit1)
      Me.grbOtherUnit.Controls.Add(Me.lblDefaultUnit2)
      Me.grbOtherUnit.Controls.Add(Me.lblDefaultUnit3)
      Me.grbOtherUnit.Controls.Add(Me.lblEqualSign1)
      Me.grbOtherUnit.Controls.Add(Me.lblEqualSign2)
      Me.grbOtherUnit.Controls.Add(Me.lblEqualSign3)
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnitDialog1)
      Me.grbOtherUnit.Controls.Add(Me.ibtnShowUnitDialog2)
      Me.grbOtherUnit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbOtherUnit.Location = New System.Drawing.Point(8, 360)
      Me.grbOtherUnit.Name = "grbOtherUnit"
      Me.grbOtherUnit.Size = New System.Drawing.Size(512, 104)
      Me.grbOtherUnit.TabIndex = 2
      Me.grbOtherUnit.TabStop = False
      Me.grbOtherUnit.Text = "หน่วยนับอื่น"
      '
      'ibtnShowUnitDialog3
      '
      Me.ibtnShowUnitDialog3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnitDialog3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnitDialog3.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowUnitDialog3.Location = New System.Drawing.Point(248, 72)
      Me.ibtnShowUnitDialog3.Name = "ibtnShowUnitDialog3"
      Me.ibtnShowUnitDialog3.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnitDialog3.TabIndex = 14
      Me.ibtnShowUnitDialog3.TabStop = False
      Me.ibtnShowUnitDialog3.ThemedImage = CType(resources.GetObject("ibtnShowUnitDialog3.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtUnit3
      '
      Me.Validator.SetDataType(Me.txtUnit3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnit3, "")
      Me.txtUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnit3, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnit3, System.Drawing.Color.Empty)
      Me.txtUnit3.Location = New System.Drawing.Point(128, 72)
      Me.Validator.SetMinValue(Me.txtUnit3, "")
      Me.txtUnit3.Name = "txtUnit3"
      Me.txtUnit3.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtUnit3, "")
      Me.Validator.SetRequired(Me.txtUnit3, False)
      Me.txtUnit3.Size = New System.Drawing.Size(120, 21)
      Me.txtUnit3.TabIndex = 11
      Me.txtUnit3.TabStop = False
      '
      'txtUnit2
      '
      Me.Validator.SetDataType(Me.txtUnit2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnit2, "")
      Me.txtUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
      Me.txtUnit2.Location = New System.Drawing.Point(128, 48)
      Me.Validator.SetMinValue(Me.txtUnit2, "")
      Me.txtUnit2.Name = "txtUnit2"
      Me.txtUnit2.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtUnit2, "")
      Me.Validator.SetRequired(Me.txtUnit2, False)
      Me.txtUnit2.Size = New System.Drawing.Size(120, 21)
      Me.txtUnit2.TabIndex = 10
      Me.txtUnit2.TabStop = False
      '
      'txtUnit1
      '
      Me.Validator.SetDataType(Me.txtUnit1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnit1, "")
      Me.txtUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
      Me.txtUnit1.Location = New System.Drawing.Point(128, 24)
      Me.Validator.SetMinValue(Me.txtUnit1, "")
      Me.txtUnit1.Name = "txtUnit1"
      Me.txtUnit1.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtUnit1, "")
      Me.Validator.SetRequired(Me.txtUnit1, False)
      Me.txtUnit1.Size = New System.Drawing.Size(120, 21)
      Me.txtUnit1.TabIndex = 9
      Me.txtUnit1.TabStop = False
      '
      'txtUnitConversion3
      '
      Me.Validator.SetDataType(Me.txtUnitConversion3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtUnitConversion3, "")
      Me.txtUnitConversion3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitConversion3, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitConversion3, System.Drawing.Color.Empty)
      Me.txtUnitConversion3.Location = New System.Drawing.Point(320, 72)
      Me.Validator.SetMinValue(Me.txtUnitConversion3, "")
      Me.txtUnitConversion3.Name = "txtUnitConversion3"
      Me.Validator.SetRegularExpression(Me.txtUnitConversion3, "")
      Me.Validator.SetRequired(Me.txtUnitConversion3, False)
      Me.txtUnitConversion3.Size = New System.Drawing.Size(120, 21)
      Me.txtUnitConversion3.TabIndex = 5
      '
      'txtUnitConversion1
      '
      Me.Validator.SetDataType(Me.txtUnitConversion1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtUnitConversion1, "")
      Me.txtUnitConversion1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitConversion1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitConversion1, System.Drawing.Color.Empty)
      Me.txtUnitConversion1.Location = New System.Drawing.Point(320, 24)
      Me.Validator.SetMinValue(Me.txtUnitConversion1, "")
      Me.txtUnitConversion1.Name = "txtUnitConversion1"
      Me.Validator.SetRegularExpression(Me.txtUnitConversion1, "")
      Me.Validator.SetRequired(Me.txtUnitConversion1, False)
      Me.txtUnitConversion1.Size = New System.Drawing.Size(120, 21)
      Me.txtUnitConversion1.TabIndex = 1
      '
      'lblUnit2
      '
      Me.lblUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnit2.ForeColor = System.Drawing.Color.Black
      Me.lblUnit2.Location = New System.Drawing.Point(8, 48)
      Me.lblUnit2.Name = "lblUnit2"
      Me.lblUnit2.Size = New System.Drawing.Size(64, 18)
      Me.lblUnit2.TabIndex = 7
      Me.lblUnit2.Text = "หน่วย 2:"
      Me.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblUnit3
      '
      Me.lblUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnit3.ForeColor = System.Drawing.Color.Black
      Me.lblUnit3.Location = New System.Drawing.Point(8, 72)
      Me.lblUnit3.Name = "lblUnit3"
      Me.lblUnit3.Size = New System.Drawing.Size(64, 18)
      Me.lblUnit3.TabIndex = 8
      Me.lblUnit3.Text = "หน่วย 3:"
      Me.lblUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtUnitConversion2
      '
      Me.Validator.SetDataType(Me.txtUnitConversion2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtUnitConversion2, "")
      Me.txtUnitConversion2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitConversion2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitConversion2, System.Drawing.Color.Empty)
      Me.txtUnitConversion2.Location = New System.Drawing.Point(320, 48)
      Me.Validator.SetMinValue(Me.txtUnitConversion2, "")
      Me.txtUnitConversion2.Name = "txtUnitConversion2"
      Me.Validator.SetRegularExpression(Me.txtUnitConversion2, "")
      Me.Validator.SetRequired(Me.txtUnitConversion2, False)
      Me.txtUnitConversion2.Size = New System.Drawing.Size(120, 21)
      Me.txtUnitConversion2.TabIndex = 3
      '
      'lblUnit1
      '
      Me.lblUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblUnit1.Location = New System.Drawing.Point(8, 24)
      Me.lblUnit1.Name = "lblUnit1"
      Me.lblUnit1.Size = New System.Drawing.Size(64, 18)
      Me.lblUnit1.TabIndex = 6
      Me.lblUnit1.Text = "หน่วย 1:"
      Me.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowUnit1
      '
      Me.ibtnShowUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnit1.Location = New System.Drawing.Point(272, 24)
      Me.ibtnShowUnit1.Name = "ibtnShowUnit1"
      Me.ibtnShowUnit1.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnit1.TabIndex = 15
      Me.ibtnShowUnit1.TabStop = False
      Me.ibtnShowUnit1.ThemedImage = CType(resources.GetObject("ibtnShowUnit1.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtUnitCode1
      '
      Me.Validator.SetDataType(Me.txtUnitCode1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitCode1, "")
      Me.txtUnitCode1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitCode1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitCode1, System.Drawing.Color.Empty)
      Me.txtUnitCode1.Location = New System.Drawing.Point(72, 24)
      Me.Validator.SetMinValue(Me.txtUnitCode1, "")
      Me.txtUnitCode1.Name = "txtUnitCode1"
      Me.Validator.SetRegularExpression(Me.txtUnitCode1, "")
      Me.Validator.SetRequired(Me.txtUnitCode1, False)
      Me.txtUnitCode1.Size = New System.Drawing.Size(56, 21)
      Me.txtUnitCode1.TabIndex = 0
      '
      'txtUnitCode3
      '
      Me.Validator.SetDataType(Me.txtUnitCode3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitCode3, "")
      Me.txtUnitCode3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitCode3, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitCode3, System.Drawing.Color.Empty)
      Me.txtUnitCode3.Location = New System.Drawing.Point(72, 72)
      Me.Validator.SetMinValue(Me.txtUnitCode3, "")
      Me.txtUnitCode3.Name = "txtUnitCode3"
      Me.Validator.SetRegularExpression(Me.txtUnitCode3, "")
      Me.Validator.SetRequired(Me.txtUnitCode3, False)
      Me.txtUnitCode3.Size = New System.Drawing.Size(56, 21)
      Me.txtUnitCode3.TabIndex = 4
      '
      'ibtnShowUnit3
      '
      Me.ibtnShowUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnit3.Location = New System.Drawing.Point(272, 72)
      Me.ibtnShowUnit3.Name = "ibtnShowUnit3"
      Me.ibtnShowUnit3.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnit3.TabIndex = 17
      Me.ibtnShowUnit3.TabStop = False
      Me.ibtnShowUnit3.ThemedImage = CType(resources.GetObject("ibtnShowUnit3.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtUnitCode2
      '
      Me.Validator.SetDataType(Me.txtUnitCode2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitCode2, "")
      Me.txtUnitCode2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtUnitCode2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitCode2, System.Drawing.Color.Empty)
      Me.txtUnitCode2.Location = New System.Drawing.Point(72, 48)
      Me.Validator.SetMinValue(Me.txtUnitCode2, "")
      Me.txtUnitCode2.Name = "txtUnitCode2"
      Me.Validator.SetRegularExpression(Me.txtUnitCode2, "")
      Me.Validator.SetRequired(Me.txtUnitCode2, False)
      Me.txtUnitCode2.Size = New System.Drawing.Size(56, 21)
      Me.txtUnitCode2.TabIndex = 2
      '
      'ibtnShowUnit2
      '
      Me.ibtnShowUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnit2.Location = New System.Drawing.Point(272, 48)
      Me.ibtnShowUnit2.Name = "ibtnShowUnit2"
      Me.ibtnShowUnit2.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnit2.TabIndex = 16
      Me.ibtnShowUnit2.TabStop = False
      Me.ibtnShowUnit2.ThemedImage = CType(resources.GetObject("ibtnShowUnit2.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDefaultUnit1
      '
      Me.lblDefaultUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDefaultUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblDefaultUnit1.Location = New System.Drawing.Point(448, 24)
      Me.lblDefaultUnit1.Name = "lblDefaultUnit1"
      Me.lblDefaultUnit1.Size = New System.Drawing.Size(48, 18)
      Me.lblDefaultUnit1.TabIndex = 18
      Me.lblDefaultUnit1.Text = "กิโลกรัม"
      Me.lblDefaultUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDefaultUnit2
      '
      Me.lblDefaultUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDefaultUnit2.ForeColor = System.Drawing.Color.Black
      Me.lblDefaultUnit2.Location = New System.Drawing.Point(448, 48)
      Me.lblDefaultUnit2.Name = "lblDefaultUnit2"
      Me.lblDefaultUnit2.Size = New System.Drawing.Size(48, 18)
      Me.lblDefaultUnit2.TabIndex = 19
      Me.lblDefaultUnit2.Text = "กิโลกรัม"
      Me.lblDefaultUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDefaultUnit3
      '
      Me.lblDefaultUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDefaultUnit3.ForeColor = System.Drawing.Color.Black
      Me.lblDefaultUnit3.Location = New System.Drawing.Point(448, 72)
      Me.lblDefaultUnit3.Name = "lblDefaultUnit3"
      Me.lblDefaultUnit3.Size = New System.Drawing.Size(48, 18)
      Me.lblDefaultUnit3.TabIndex = 20
      Me.lblDefaultUnit3.Text = "กิโลกรัม"
      Me.lblDefaultUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblEqualSign1
      '
      Me.lblEqualSign1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEqualSign1.ForeColor = System.Drawing.Color.Black
      Me.lblEqualSign1.Location = New System.Drawing.Point(296, 24)
      Me.lblEqualSign1.Name = "lblEqualSign1"
      Me.lblEqualSign1.Size = New System.Drawing.Size(24, 18)
      Me.lblEqualSign1.TabIndex = 21
      Me.lblEqualSign1.Text = "="
      Me.lblEqualSign1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblEqualSign2
      '
      Me.lblEqualSign2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEqualSign2.ForeColor = System.Drawing.Color.Black
      Me.lblEqualSign2.Location = New System.Drawing.Point(296, 48)
      Me.lblEqualSign2.Name = "lblEqualSign2"
      Me.lblEqualSign2.Size = New System.Drawing.Size(24, 18)
      Me.lblEqualSign2.TabIndex = 22
      Me.lblEqualSign2.Text = "="
      Me.lblEqualSign2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblEqualSign3
      '
      Me.lblEqualSign3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEqualSign3.ForeColor = System.Drawing.Color.Black
      Me.lblEqualSign3.Location = New System.Drawing.Point(296, 72)
      Me.lblEqualSign3.Name = "lblEqualSign3"
      Me.lblEqualSign3.Size = New System.Drawing.Size(24, 18)
      Me.lblEqualSign3.TabIndex = 23
      Me.lblEqualSign3.Text = "="
      Me.lblEqualSign3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnShowUnitDialog1
      '
      Me.ibtnShowUnitDialog1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnitDialog1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnitDialog1.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowUnitDialog1.Location = New System.Drawing.Point(248, 24)
      Me.ibtnShowUnitDialog1.Name = "ibtnShowUnitDialog1"
      Me.ibtnShowUnitDialog1.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnitDialog1.TabIndex = 12
      Me.ibtnShowUnitDialog1.TabStop = False
      Me.ibtnShowUnitDialog1.ThemedImage = CType(resources.GetObject("ibtnShowUnitDialog1.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowUnitDialog2
      '
      Me.ibtnShowUnitDialog2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowUnitDialog2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowUnitDialog2.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowUnitDialog2.Location = New System.Drawing.Point(248, 48)
      Me.ibtnShowUnitDialog2.Name = "ibtnShowUnitDialog2"
      Me.ibtnShowUnitDialog2.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowUnitDialog2.TabIndex = 13
      Me.ibtnShowUnitDialog2.TabStop = False
      Me.ibtnShowUnitDialog2.ThemedImage = CType(resources.GetObject("ibtnShowUnitDialog2.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.lblStatus.Enabled = False
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(3, 472)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(38, 13)
      Me.lblStatus.TabIndex = 3
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'MaterialDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "MaterialDetailView"
      Me.Size = New System.Drawing.Size(544, 504)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbMatDetail.ResumeLayout(False)
      Me.grbMatDetail.PerformLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbLCI.ResumeLayout(False)
      Me.grbLCI.PerformLayout()
      Me.grbOtherUnit.ResumeLayout(False)
      Me.grbOtherUnit.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As LCIItem
    Private m_isInitialized As Boolean = False
    Private m_locked As Boolean = True
    Private m_lockedInit As Boolean = True
#End Region

#Region "Property"

#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
      DisableGigaSiteControl()
    End Sub
    Private Sub DisableGigaSiteControl()
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.txtAccount.Enabled = False
        Me.ibtnShowAccount.Enabled = False
        Me.lblAccount.Enabled = False
        Me.txtAccountCode.Enabled = False
        Me.ibtnShowAccountDialog.Enabled = False
      End If
    End Sub
#End Region

#Region "Image button"
    Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
      Dim dlg As New OpenFileDialog
      dlg.AddExtension = True
      Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
      dlg.Filter = String.Join("|", fileFilters)
      If dlg.ShowDialog = DialogResult.OK Then
        Dim img As Image = Image.FromFile(dlg.FileName)
        If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
          Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
          img = ImageHelper.Resize(img, percent)
        End If
        Me.picImage.Image = img
        m_entity.Image = img
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        CheckLabelImgSize()
      End If
    End Sub
    Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
      m_entity.Image = Nothing
      Me.picImage.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
      CheckLabelImgSize()
    End Sub
#End Region

#Region "IListDetail"
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(339)       'ตรวจสอบ สิทธิปลดล๊อคใบรับของ
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)      'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      btnLock.Visible = False
      If Me.m_entity.Canceled Then
        For Each ctrl As Control In grbMatDetail.Controls
          ctrl.Enabled = False
        Next
        Me.chkCancel.Enabled = True
        grbOtherUnit.Enabled = False
        grbLCI.Enabled = False
      Else
        If m_entity.Level <> 5 OrElse Not m_locked Then
          For Each ctrl As Control In grbMatDetail.Controls
            ctrl.Enabled = True
          Next
          'grbOtherUnit.Enabled = True
          For Each ctrl As Control In grbOtherUnit.Controls
            ctrl.Enabled = True
          Next
          Me.SetDisabledForUnitReferenced()
          grbLCI.Enabled = True
        ElseIf m_entity.IsReferenced AndAlso m_locked Then
          For Each ctrl As Control In grbMatDetail.Controls
            ctrl.Enabled = False
          Next
          For Each ctrl As Control In grbOtherUnit.Controls
            ctrl.Enabled = True
          Next
          Me.SetDisabledForUnitReferenced()

          'If m_entity.ConversionUnit1 = 0 Then
          '  txtUnit1.Enabled = True
          '  txtUnitCode1.Enabled = True
          '  txtUnitConversion1.Enabled = True
          '  ibtnShowUnit1.Enabled = True
          '  ibtnShowUnitDialog1.Enabled = True
          'End If
          'If m_entity.ConversionUnit2 = 0 Then
          '  txtUnit2.Enabled = True
          '  txtUnitCode2.Enabled = True
          '  txtUnitConversion2.Enabled = True
          '  ibtnShowUnit2.Enabled = True
          '  ibtnShowUnitDialog2.Enabled = True
          'End If
          'If m_entity.ConversionUnit3 = 0 Then
          '  txtUnit3.Enabled = True
          '  txtUnitCode3.Enabled = True
          '  txtUnitConversion3.Enabled = True
          '  ibtnShowUnit3.Enabled = True
          '  ibtnShowUnitDialog3.Enabled = True
          'End If

          grbLCI.Enabled = False
        End If

        If CBool(checkString.Substring(0, 1)) AndAlso m_entity.Originated AndAlso m_entity.Level = 5 Then
          btnLock.Enabled = True
          btnLock.Visible = True
        End If

        If Me.m_entity.Level < 5 Then
          If Me.m_entity.GetChildCount > 0 Then
            Me.txtlv1.Enabled = False
            Me.txtlv2.Enabled = False
            Me.txtlv3.Enabled = False
            Me.txtlv4.Enabled = False
            Me.txtlv5.Enabled = False
          End If
        End If
      End If
    End Sub
    Private Sub SetDisabledForUnitReferenced()
      Dim hasOtherUnit As Boolean = False
      If Not m_entity.CompareUnit1 Is Nothing AndAlso m_entity.CompareUnit1.Originated Then
        If m_entity.IsThisUnitReferenced(m_entity.CompareUnit1) Then
          hasOtherUnit = True
          txtUnit1.Enabled = False
          txtUnitCode1.Enabled = False
          txtUnitConversion1.Enabled = False
          ibtnShowUnit1.Enabled = False
          ibtnShowUnitDialog1.Enabled = False
        End If
      End If
      If Not m_entity.CompareUnit2 Is Nothing AndAlso m_entity.CompareUnit2.Originated Then
        If m_entity.IsThisUnitReferenced(m_entity.CompareUnit2) Then
          hasOtherUnit = True
          txtUnit2.Enabled = False
          txtUnitCode2.Enabled = False
          txtUnitConversion2.Enabled = False
          ibtnShowUnit2.Enabled = False
          ibtnShowUnitDialog2.Enabled = False
        End If
      End If
      If Not m_entity.CompareUnit3 Is Nothing AndAlso m_entity.CompareUnit3.Originated Then
        If m_entity.IsThisUnitReferenced(m_entity.CompareUnit3) Then
          hasOtherUnit = True
          txtUnit3.Enabled = False
          txtUnitCode3.Enabled = False
          txtUnitConversion3.Enabled = False
          ibtnShowUnit3.Enabled = False
          ibtnShowUnitDialog3.Enabled = False
        End If
      End If
      If Not m_entity.DefaultUnit Is Nothing AndAlso m_entity.DefaultUnit.Originated Then
        If m_entity.IsThisUnitReferenced(m_entity.DefaultUnit) OrElse hasOtherUnit Then
          txtDefaultUnit.Enabled = False
          txtDefaultUnitCode.Enabled = False
          ibtnShowDefaultUnit.Enabled = False
          ibtnShowDefaultUnitDialog.Enabled = False
        End If
      End If
    End Sub
    ' เคลียร์ข้อมูลวัสดุภัณฑ์ใน control
    Public Overrides Sub ClearDetail()
      Me.lblStatus.Text = ""
      Me.txtlv1.Text = ""
      Me.txtlv2.Text = ""
      Me.txtlv3.Text = ""
      Me.txtlv4.Text = ""
      Me.txtlv5.Text = ""
      Me.txtCode.Text = ""
      Me.txtName.Text = ""
      Me.txtAltName.Text = ""
      Me.txtShelfLife.Text = ""
      Me.txtNote.Text = ""
      Me.txtFairPrice.Text = ""
      Me.txtUnitCode1.Text = ""
      Me.txtUnitCode2.Text = ""
      Me.txtUnitCode3.Text = ""
      Me.txtUnitConversion1.Text = ""
      Me.txtUnitConversion2.Text = ""
      Me.txtUnitConversion3.Text = ""
      Me.lblDefaultUnit1.Text = ""
      Me.lblDefaultUnit2.Text = ""
      Me.lblDefaultUnit3.Text = ""
    End Sub

    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.btnLoadImage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.btnLoadImage}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.txtNameAlert}"))
      Me.Validator.SetDisplayName(Me.txtlv1, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.txtlv1Alert}"))

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblCode}")
      Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MateriaDetailView.lblAltName}")
      Me.chkCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.chkCancel}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblShelfLife.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblShelfLife}")
      Me.lblFairPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblFairPrice}")
      Me.lblDefaultUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblDefaultUnit}")
      Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblLCI}")
      Me.grbOtherUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.grbOtherUnit}")
      Me.lblUnit2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblUnit2}")
      Me.lblUnit3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblUnit3}")
      Me.lblUnit1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblUnit1}")
      Me.lblEqualSign1.Text = Me.StringParserService.Parse("${res:Global.EqualSignText}")
      Me.lblEqualSign2.Text = Me.StringParserService.Parse("${res:Global.EqualSignText}")
      Me.lblEqualSign3.Text = Me.StringParserService.Parse("${res:Global.EqualSignText}")
      Me.lblFairPriceUnit.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.grbLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.grbLCI}")
      Me.grbMatDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.grbMatDetail}")
      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblAccount}")
      Me.lblShelfLieUnit.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      Me.chkUnvatable.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.chkUnvatable}")
      Me.lblMVCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblMVCost}")
      Me.lblMVCostUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialDetailView.lblMVCostUnit}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler chkCancel.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkUnvatable.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler txtShelfLife.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtlv1.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtlv2.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtlv3.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtlv4.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtlv5.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtFairPrice.Validated, AddressOf Me.TextHandler
      AddHandler txtFairPrice.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDefaultUnitCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtUnitCode1.Validated, AddressOf Me.ChangeProperty
      AddHandler txtUnitCode2.Validated, AddressOf Me.ChangeProperty
      AddHandler txtUnitCode3.Validated, AddressOf Me.ChangeProperty

      AddHandler txtUnitConversion1.Validated, AddressOf Me.TextHandler
      AddHandler txtUnitConversion2.Validated, AddressOf Me.TextHandler
      AddHandler txtUnitConversion3.Validated, AddressOf Me.TextHandler

      AddHandler txtUnitConversion1.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtUnitConversion2.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtUnitConversion3.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    Private fairPriceTextChanged As Boolean = False
    Private txtUnitConversion1TextChanged As Boolean = False
    Private txtUnitConversion2TextChanged As Boolean = False
    Private txtUnitConversion3TextChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      Select Case CType(sender, Control).Name.ToLower
        Case "txtfairprice"
          If fairPriceTextChanged Then
            Dim txt As String = txtFairPrice.Text
            txt = txt.Replace(",", "")
            If txt.Length = 0 Then
              Me.m_entity.FairPrice = 0
            Else
              Try
                Me.m_entity.FairPrice = CDec(TextHelper.TextParser.Evaluate(txt))
              Catch ex As Exception
                Me.m_entity.FairPrice = 0
              End Try
            End If
            txtFairPrice.Text = Configuration.FormatToString(Me.m_entity.FairPrice, DigitConfig.UnitPrice)
            fairPriceTextChanged = False
          End If
        Case "txtunitconversion1"
          If txtUnitConversion1TextChanged Then
            Dim txt As String = txtUnitConversion1.Text
            txt = txt.Replace(",", "")
            If txt.Length = 0 Then
              Me.m_entity.MemoryConversionUnit1 = 0
            Else
              Try
                Me.m_entity.MemoryConversionUnit1 = CDec(TextHelper.TextParser.Evaluate(txt))
              Catch ex As Exception
                Me.m_entity.MemoryConversionUnit1 = 0
              End Try
            End If
            txtUnitConversion1.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit1, 8)
            txtUnitConversion1TextChanged = False
          End If
        Case "txtunitconversion2"
          If txtUnitConversion2TextChanged Then
            Dim txt As String = txtUnitConversion2.Text
            txt = txt.Replace(",", "")
            If txt.Length = 0 Then
              Me.m_entity.MemoryConversionUnit2 = 0
            Else
              Try
                Me.m_entity.MemoryConversionUnit2 = CDec(TextHelper.TextParser.Evaluate(txt))
              Catch ex As Exception
                Me.m_entity.MemoryConversionUnit2 = 0
              End Try
            End If
            txtUnitConversion2.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit2, 8)
            txtUnitConversion2TextChanged = False
          End If
        Case "txtunitconversion3"
          If txtUnitConversion3TextChanged Then
            Dim txt As String = txtUnitConversion3.Text
            txt = txt.Replace(",", "")
            If txt.Length = 0 Then
              Me.m_entity.MemoryConversionUnit3 = 0
            Else
              Try
                Me.m_entity.MemoryConversionUnit3 = CDec(TextHelper.TextParser.Evaluate(txt))
              Catch ex As Exception
                Me.m_entity.MemoryConversionUnit3 = 0
              End Try
            End If
            txtUnitConversion3.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit3, 8)
            txtUnitConversion3TextChanged = False
          End If
      End Select
    End Sub
    ' แสดงค่าข้อมูลของวัสดุลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtlv1.Enabled = True
      txtlv2.Enabled = True
      txtlv3.Enabled = True
      txtlv4.Enabled = True
      txtlv5.Enabled = True

      m_entity.LoadImage()

      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name
      txtAltName.Text = m_entity.AlternateName
      txtlv1.Text = m_entity.Lv1
      txtlv2.Text = m_entity.Lv2
      txtlv3.Text = m_entity.Lv3
      txtlv4.Text = m_entity.Lv4
      txtlv5.Text = m_entity.Lv5

      If Me.m_entity.Canceled Then
        chkCancel.Checked = True
      Else
        chkCancel.Checked = False
      End If

      If (Me.m_entity.IsReferenced OrElse Me.m_entity.Canceled) AndAlso m_lockedInit = True Then
        m_locked = True
      ElseIf m_lockedInit = True Then
        m_locked = False
      End If

      If Me.m_entity.Unvatable Then
        chkUnvatable.Checked = True
      Else
        chkUnvatable.Checked = False
      End If

      Select Case m_entity.Level
        Case 1
          Me.Validator.SetRequired(Me.txtAccountCode, False)      '*****
          Me.Validator.SetRequired(Me.txtDefaultUnitCode, False)      '*****
          Me.Validator.SetRequired(Me.txtUnitCode1, False)
          Me.Validator.SetRequired(Me.txtUnitCode2, False)
          Me.Validator.SetRequired(Me.txtUnitCode3, False)
          Me.ErrorProvider1.SetError(Me.txtAccountCode, "")
          Me.ErrorProvider1.SetError(Me.txtDefaultUnitCode, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode1, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode2, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode3, "")
        Case 2, 3, 4
          Me.Validator.SetRequired(Me.txtAccountCode, True)     '*****
          Me.Validator.SetRequired(Me.txtDefaultUnitCode, False)      '*****
          Me.Validator.SetRequired(Me.txtUnitCode1, False)
          Me.Validator.SetRequired(Me.txtUnitCode2, False)
          Me.Validator.SetRequired(Me.txtUnitCode3, False)
          Me.ErrorProvider1.SetError(Me.txtDefaultUnitCode, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode1, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode2, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode3, "")
        Case 5
          Me.Validator.SetRequired(Me.txtAccountCode, True)     '*****
          Me.Validator.SetRequired(Me.txtDefaultUnitCode, True)     '*****
          Me.Validator.SetRequired(Me.txtUnitCode1, False)
          Me.Validator.SetRequired(Me.txtUnitCode2, False)
          Me.Validator.SetRequired(Me.txtUnitCode3, False)
          Me.ErrorProvider1.SetError(Me.txtUnitCode1, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode2, "")
          Me.ErrorProvider1.SetError(Me.txtUnitCode3, "")
      End Select
      Select Case m_entity.Level
        Case 0
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = False
          Me.txtlv2.ReadOnly = True
          Me.txtlv3.ReadOnly = True

          Me.Validator.SetRequired(Me.txtlv4, False)
          Me.Validator.SetRequired(Me.txtlv5, False)
          Me.txtlv4.ReadOnly = True
          Me.txtlv5.ReadOnly = True

          Me.ErrorProvider1.SetError(Me.txtlv4, "")
          Me.ErrorProvider1.SetError(Me.txtlv5, "")
        Case 1
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = False
          Me.txtlv2.ReadOnly = True
          Me.txtlv3.ReadOnly = True

          Me.Validator.SetRequired(Me.txtlv4, False)
          Me.Validator.SetRequired(Me.txtlv5, False)
          Me.txtlv4.ReadOnly = True
          Me.txtlv5.ReadOnly = True

          Me.ErrorProvider1.SetError(Me.txtlv4, "")
          Me.ErrorProvider1.SetError(Me.txtlv5, "")
        Case 2
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = True
          Me.txtlv2.ReadOnly = False
          Me.txtlv3.ReadOnly = True

          Me.Validator.SetRequired(Me.txtlv4, False)
          Me.Validator.SetRequired(Me.txtlv5, False)
          Me.txtlv4.ReadOnly = True
          Me.txtlv5.ReadOnly = True

          Me.ErrorProvider1.SetError(Me.txtlv4, "")
          Me.ErrorProvider1.SetError(Me.txtlv5, "")

          'ให้ cursor อยู่ใน level ที่ต้องการเพิ่ม
          Me.txtlv2.Focus()
        Case 3
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = True
          Me.txtlv2.ReadOnly = True
          Me.txtlv3.ReadOnly = False

          Me.Validator.SetRequired(Me.txtlv4, False)
          Me.Validator.SetRequired(Me.txtlv5, False)
          Me.txtlv4.ReadOnly = True
          Me.txtlv5.ReadOnly = True

          Me.ErrorProvider1.SetError(Me.txtlv4, "")
          Me.ErrorProvider1.SetError(Me.txtlv5, "")

          'ให้ cursor อยู่ใน level ที่ต้องการเพิ่ม
          Me.txtlv3.Focus()
        Case 4
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = True
          Me.txtlv2.ReadOnly = True
          Me.txtlv3.ReadOnly = True

          Me.Validator.SetRequired(Me.txtlv4, True)
          Me.Validator.SetRequired(Me.txtlv5, False)
          Me.txtlv4.ReadOnly = False
          Me.txtlv5.ReadOnly = True

          Me.ErrorProvider1.SetError(Me.txtlv5, "")

          'ให้ cursor อยู่ใน level ที่ต้องการเพิ่ม
          Me.txtlv4.Focus()
        Case 5
          Me.Validator.SetRequired(Me.txtlv1, True)
          Me.Validator.SetRequired(Me.txtlv2, True)
          Me.Validator.SetRequired(Me.txtlv3, True)
          Me.txtlv1.ReadOnly = True
          Me.txtlv2.ReadOnly = True
          Me.txtlv3.ReadOnly = True

          Me.Validator.SetRequired(Me.txtlv4, True)
          Me.Validator.SetRequired(Me.txtlv5, True)
          Me.txtlv4.ReadOnly = True
          Me.txtlv5.ReadOnly = False

          'ให้ cursor อยู่ใน level ที่ต้องการเพิ่ม
          Me.txtlv5.Focus()

          If Not m_entity.Originated Then
            btnLock.Visible = False

          ElseIf m_locked Then
            Me.btnLock.Image = Global.My.Resources.Resources.padlock_unlocked

          Else
            Me.btnLock.Image = Global.My.Resources.Resources.padlock_locked

          End If

      End Select
      picImage.Image = Me.m_entity.Image
      CheckLabelImgSize()
      txtNote.Text = m_entity.Note
      txtShelfLife.Text = Configuration.FormatToString(m_entity.ShelfLife, DigitConfig.Int)
      txtFairPrice.Text = Configuration.FormatToString(m_entity.FairPrice, DigitConfig.Cost)
      txtMVCost.Text = Configuration.FormatToString(m_entity.MovingCost, DigitConfig.Cost)
      Me.lblDefaultUnit1.Text = m_entity.MemoryUnit.Name
      Me.lblDefaultUnit2.Text = m_entity.MemoryUnit.Name
      Me.lblDefaultUnit3.Text = m_entity.MemoryUnit.Name

      Me.lblLevel.Text = "Level " & Me.m_entity.Level.ToString

      txtFairPrice.Text = Configuration.FormatToString(Me.m_entity.FairPrice, DigitConfig.UnitPrice)
      ' ผังบัญชี
      txtAccountCode.Text = Me.m_entity.Account.Code
      txtAccount.Text = Me.m_entity.Account.Name
      ' หน่วยนับอื่น ๆ
      txtDefaultUnitCode.Text = Me.m_entity.MemoryUnit.Code
      txtDefaultUnit.Text = Me.m_entity.MemoryUnit.Name
      SetUnitLabel()

      txtUnitCode1.Text = Me.m_entity.MemoryCompareUnit1.Code
      txtUnit1.Text = Me.m_entity.MemoryCompareUnit1.Name

      txtUnitCode2.Text = Me.m_entity.MemoryCompareUnit2.Code
      txtUnit2.Text = Me.m_entity.MemoryCompareUnit2.Name

      txtUnitCode3.Text = Me.m_entity.MemoryCompareUnit3.Code
      txtUnit3.Text = Me.m_entity.MemoryCompareUnit3.Name

      ' อัตราส่วนต่อหน่วยนับหลัก
      txtUnitConversion1.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit1, 8)
      txtUnitConversion2.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit2, 8)
      txtUnitConversion3.Text = Configuration.FormatToString(Me.m_entity.MemoryConversionUnit3, 8)

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub

    Private Sub btnLockBoq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click
      If m_locked Then
        m_locked = False
      Else
        m_locked = True
      End If
      m_lockedInit = False
      UpdateEntityProperties()
    End Sub

    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      'If Me.m_entity.Parent.Level < 4 Then
      '    Return
      'End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtlv1"
          Me.m_entity.Lv1 = txtlv1.Text
          Me.txtCode.Text = Me.m_entity.Code
          dirtyFlag = True
        Case "txtlv2"
          Me.m_entity.Lv2 = txtlv2.Text
          Me.txtCode.Text = Me.m_entity.Code
          dirtyFlag = True
        Case "txtlv3"
          Me.m_entity.Lv3 = txtlv3.Text
          Me.txtCode.Text = Me.m_entity.Code
          dirtyFlag = True
        Case "txtlv4"
          Me.m_entity.Lv4 = txtlv4.Text
          Me.txtCode.Text = Me.m_entity.Code
          dirtyFlag = True
        Case "txtlv5"
          Me.m_entity.Lv5 = txtlv5.Text
          Me.txtCode.Text = Me.m_entity.Code
          dirtyFlag = True
        Case "chkcancel"
          'Me.m_entity.Canceled = chkCancel.Checked
          Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          Me.m_entity.SetCancel(chkCancel.Checked, secSrv.CurrentUser.Id)
          CheckFormEnable()
          dirtyFlag = True
        Case "chkunvatable"
          Me.m_entity.Unvatable = chkUnvatable.Checked
          dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True
        Case "txtaltname"
          Me.m_entity.AlternateName = txtAltName.Text
          dirtyFlag = True
        Case "txtshelflife"
          Me.m_entity.ShelfLife = CInt(txtShelfLife.Text)
          dirtyFlag = True
        Case "txtfairprice"
          fairPriceTextChanged = True
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtunitconversion1"
          Me.txtUnitConversion1TextChanged = True
          dirtyFlag = True
        Case "txtunitconversion2"
          Me.txtUnitConversion2TextChanged = True
          dirtyFlag = True
        Case "txtunitconversion3"
          Me.txtUnitConversion3TextChanged = True
          dirtyFlag = True
        Case "txtunitcode1"
          dirtyFlag = Unit.GetUnit(txtUnitCode1, txtUnit1, Me.m_entity.MemoryCompareUnit1)
        Case "txtunitcode2"
          dirtyFlag = Unit.GetUnit(txtUnitCode2, txtUnit2, Me.m_entity.MemoryCompareUnit2)
        Case "txtunitcode3"
          dirtyFlag = Unit.GetUnit(txtUnitCode3, txtUnit3, Me.m_entity.MemoryCompareUnit3)
        Case "txtdefaultunitcode"
          dirtyFlag = Unit.GetUnit(txtDefaultUnitCode, txtDefaultUnit, Me.m_entity.MemoryUnit)
          SetUnitLabel()
        Case "txtaccountcode"
          dirtyFlag = Account.GetAccount(txtAccountCode, txtAccount, Me.m_entity.Account)
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      SetStatus()
      'CheckFormEnable()
    End Sub
    Public Sub SetUnitLabel()
      lblDefaultUnit1.Text = m_entity.MemoryUnit.Name
      lblDefaultUnit2.Text = m_entity.MemoryUnit.Name
      lblDefaultUnit3.Text = m_entity.MemoryUnit.Name
    End Sub
    Public Sub SetStatus()
   MyBase.SetStatusBarMessage()
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Value Is Nothing Then
            CType(Value, LCIItem).LoadCostLink()
          End If
        End If
        Me.m_entity = Nothing

        'Hack: pui
        Me.m_entity = CType(Value, LCIItem)
        m_locked = True
        m_lockedInit = True
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()

    End Sub

#End Region

#Region "IClipboardHandler Overrides"
		Public Overrides ReadOnly Property EnablePaste() As Boolean
			Get
				Dim data As IDataObject = Clipboard.GetDataObject
				If data.GetDataPresent((New Unit).FullClassName) Then
					If Not Me.ActiveControl Is Nothing Then
						Select Case Me.ActiveControl.Name.ToLower
							Case "txtdefaultunitcode", "txtdefaultunit" _
								, "txtunitcode1", "txtunit1" _
								, "txtunitcode2", "txtunit2" _
								, "txtunitcode3", "txtunit3"
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
			Dim data As IDataObject = Clipboard.GetDataObject
			If data.GetDataPresent((New Unit).FullClassName) Then
				Dim id As Integer = CInt(data.GetData((New Unit).FullClassName))
				Dim entity As New Unit(id)
				If Not Me.ActiveControl Is Nothing Then
					Select Case Me.ActiveControl.Name.ToLower
						Case "txtdefaultunit", "txtdefaultunitcode"
							Me.SetDefaultUnit(entity)
						Case "txtunitcode1", "txtunit1"
							Me.SetUnit1(entity)
						Case "txtunitcode2", "txtunit2"
							Me.SetUnit2(entity)
						Case "txtunitcode3", "txtunit3"
							Me.SetUnit3(entity)
					End Select
				End If
			End If
			If data.GetDataPresent((New Account).FullClassName) Then
				Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
				Dim entity As New Account(id)
				If Not Me.ActiveControl Is Nothing Then
					Select Case Me.ActiveControl.Name.ToLower
						Case "txtaccountcode", "txtaccount"
							Me.SetAccount(entity)
					End Select
				End If
			End If
		End Sub
#End Region

#Region "IValidatable"
		Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
			Get
				Return Me.Validator
			End Get
		End Property
#End Region

#Region "Event of Control"
		Private Sub ibtnShowDefaultUnitDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowDefaultUnitDialog.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenListDialog(New Unit, AddressOf SetDefaultUnit)
		End Sub
		Private Sub SetDefaultUnit(ByVal e As ISimpleEntity)
			Me.txtDefaultUnitCode.Text = e.Code
			Dim flag As Boolean = Unit.GetUnit(txtDefaultUnitCode, txtDefaultUnit, Me.m_entity.MemoryUnit)
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
			SetUnitLabel()
		End Sub

		Private Sub ibtnShowUnitDialog1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowUnitDialog1.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit1)
		End Sub
		Private Sub SetUnit1(ByVal e As ISimpleEntity)
			Me.txtUnitCode1.Text = e.Code
			Dim flag As Boolean = Unit.GetUnit(txtUnitCode1, txtUnit1, Me.m_entity.MemoryCompareUnit1)
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
		End Sub

		Private Sub ibtnShowUnitDialog2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowUnitDialog2.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit2)
		End Sub
		Private Sub SetUnit2(ByVal e As ISimpleEntity)
			Me.txtUnitCode2.Text = e.Code
			Dim flag As Boolean = Unit.GetUnit(txtUnitCode2, txtUnit2, Me.m_entity.MemoryCompareUnit2)
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
		End Sub

		Private Sub ibtnShowUnitDialog3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowUnitDialog3.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit3)
		End Sub
		Private Sub SetUnit3(ByVal e As ISimpleEntity)
			Me.txtUnitCode3.Text = e.Code
			Dim flag As Boolean = Unit.GetUnit(txtUnitCode3, txtUnit3, Me.m_entity.MemoryCompareUnit3)
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
		End Sub

		Private Sub ibtnShowAccountDialog_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountDialog.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccount)
		End Sub
		Private Sub SetAccount(ByVal e As ISimpleEntity)
			Me.txtAccountCode.Text = e.Code
			Dim flag As Boolean = Account.GetAccount(txtAccountCode, txtAccount, Me.m_entity.Account)
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or flag
		End Sub
#End Region

		Private Sub ShowNewPanels(ByVal entity As ISimpleEntity)
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(entity)
		End Sub
		Private Sub ibtnShowAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccount.Click
			ShowNewPanels(New Account)
		End Sub

		Private Sub ibtnShowDefaultUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowDefaultUnit.Click, ibtnShowUnit1.Click, ibtnShowUnit2.Click, ibtnShowUnit3.Click
			ShowNewPanels(New Unit)
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
