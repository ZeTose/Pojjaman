Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AssetDetailView
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
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents btnAssetAuxDetail As System.Windows.Forms.Button
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents grbCalcDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCalcRate As System.Windows.Forms.Label
        Friend WithEvents lblEndCalcDate As System.Windows.Forms.Label
        Friend WithEvents txtAge As System.Windows.Forms.TextBox
        Friend WithEvents txtCalcRate As System.Windows.Forms.TextBox
        Friend WithEvents lblAge As System.Windows.Forms.Label
        Friend WithEvents dtpStartCalcDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtStartCalcAmt As System.Windows.Forms.TextBox
        Friend WithEvents lblCalcType As System.Windows.Forms.Label
        Friend WithEvents lblStartCalcDate As System.Windows.Forms.Label
        Friend WithEvents txtBuyFrom As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyPrice As System.Windows.Forms.Label
        Friend WithEvents dtpBuyDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyFrom As System.Windows.Forms.Label
        Friend WithEvents lblBuyDocCode As System.Windows.Forms.Label
        Friend WithEvents txtBuyDocCode As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
        Friend WithEvents cmbCalcType As System.Windows.Forms.ComboBox
        Friend WithEvents lblYear As System.Windows.Forms.Label
        Friend WithEvents lblYear1 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
        Friend WithEvents lblSavage As System.Windows.Forms.Label
        Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
        Friend WithEvents txtSalvage As System.Windows.Forms.TextBox
        Friend WithEvents txtRemainingValue As System.Windows.Forms.TextBox
        Friend WithEvents lblCurrency4 As System.Windows.Forms.Label
        Friend WithEvents lblRemainingValue As System.Windows.Forms.Label
        Friend WithEvents lblDepreOpenning As System.Windows.Forms.Label
        Friend WithEvents lblCurrency5 As System.Windows.Forms.Label
        Friend WithEvents txtDepreOpenning As System.Windows.Forms.TextBox
        Friend WithEvents lblRent As System.Windows.Forms.Label
        Friend WithEvents txtRent As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblGl As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents grbBuyDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtGLCode As System.Windows.Forms.TextBox
        Friend WithEvents txtGLName As System.Windows.Forms.TextBox
        Friend WithEvents txtTypeCode As System.Windows.Forms.TextBox
        Friend WithEvents btnGLEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGLFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnTypeFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnTypeEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtTypeName As System.Windows.Forms.TextBox
        Friend WithEvents txtBuyDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtStartCalcDate As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtEndCalcDate As System.Windows.Forms.TextBox
        Friend WithEvents lblStartCalcAmnt As System.Windows.Forms.Label
        Friend WithEvents lblCostcenter As System.Windows.Forms.Label
        Friend WithEvents txtCostcenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCostcenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCostcenterEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCostcenterFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents btnDepreAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblDepreAcct As System.Windows.Forms.Label
        Friend WithEvents btnDepreAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreAcctName As System.Windows.Forms.TextBox
        Friend WithEvents lblDateInval As System.Windows.Forms.Label
        Friend WithEvents lblDepreOpeningAcct As System.Windows.Forms.Label
        Friend WithEvents btnDepreOpeningAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreOpeningAcctName As System.Windows.Forms.TextBox
        Friend WithEvents btnDepreOpeningAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreOpeningAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents grbStatus As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAssetStatus As System.Windows.Forms.Label
        Friend WithEvents lblCurrentStatus As System.Windows.Forms.Label
        Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
        Friend WithEvents chkDecay As System.Windows.Forms.CheckBox
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents txtTransferDate As System.Windows.Forms.TextBox
        Friend WithEvents lblTransferDate As System.Windows.Forms.Label
        Friend WithEvents dtpTransferDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtBuyDate As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyDate As System.Windows.Forms.Label
        Friend WithEvents dtpBuyDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtDetail As System.Windows.Forms.TextBox
        Friend WithEvents lblDetail As System.Windows.Forms.Label
        Friend WithEvents lblPicSize As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblPicSize = New System.Windows.Forms.Label
      Me.lblDepreOpeningAcct = New System.Windows.Forms.Label
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbStatus = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkDecay = New System.Windows.Forms.CheckBox
      Me.chkCancel = New System.Windows.Forms.CheckBox
      Me.lblCurrentStatus = New System.Windows.Forms.Label
      Me.lblAssetStatus = New System.Windows.Forms.Label
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.btnGLFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbBuyDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtBuyDate = New System.Windows.Forms.TextBox
      Me.lblBuyDate = New System.Windows.Forms.Label
      Me.dtpBuyDate = New System.Windows.Forms.DateTimePicker
      Me.txtBuyDocDate = New System.Windows.Forms.TextBox
      Me.txtBuyFrom = New System.Windows.Forms.TextBox
      Me.lblBuyPrice = New System.Windows.Forms.Label
      Me.dtpBuyDocDate = New System.Windows.Forms.DateTimePicker
      Me.txtBuyPrice = New System.Windows.Forms.TextBox
      Me.lblBuyFrom = New System.Windows.Forms.Label
      Me.lblBuyDocCode = New System.Windows.Forms.Label
      Me.txtBuyDocCode = New System.Windows.Forms.TextBox
      Me.lblBuyDocDate = New System.Windows.Forms.Label
      Me.lblCurrency1 = New System.Windows.Forms.Label
      Me.grbCalcDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtStartCalcDate = New System.Windows.Forms.TextBox
      Me.lblEndCalcDate = New System.Windows.Forms.Label
      Me.txtAge = New System.Windows.Forms.TextBox
      Me.txtCalcRate = New System.Windows.Forms.TextBox
      Me.lblAge = New System.Windows.Forms.Label
      Me.dtpStartCalcDate = New System.Windows.Forms.DateTimePicker
      Me.txtStartCalcAmt = New System.Windows.Forms.TextBox
      Me.lblCalcType = New System.Windows.Forms.Label
      Me.lblStartCalcDate = New System.Windows.Forms.Label
      Me.cmbCalcType = New System.Windows.Forms.ComboBox
      Me.lblYear = New System.Windows.Forms.Label
      Me.lblYear1 = New System.Windows.Forms.Label
      Me.lblCurrency2 = New System.Windows.Forms.Label
      Me.lblCurrency3 = New System.Windows.Forms.Label
      Me.txtSalvage = New System.Windows.Forms.TextBox
      Me.txtRemainingValue = New System.Windows.Forms.TextBox
      Me.lblCurrency4 = New System.Windows.Forms.Label
      Me.lblCurrency5 = New System.Windows.Forms.Label
      Me.txtDepreOpenning = New System.Windows.Forms.TextBox
      Me.txtEndCalcDate = New System.Windows.Forms.TextBox
      Me.lblCalcRate = New System.Windows.Forms.Label
      Me.lblStartCalcAmnt = New System.Windows.Forms.Label
      Me.lblSavage = New System.Windows.Forms.Label
      Me.lblRemainingValue = New System.Windows.Forms.Label
      Me.lblDepreOpenning = New System.Windows.Forms.Label
      Me.txtTransferDate = New System.Windows.Forms.TextBox
      Me.lblTransferDate = New System.Windows.Forms.Label
      Me.dtpTransferDate = New System.Windows.Forms.DateTimePicker
      Me.btnAssetAuxDetail = New System.Windows.Forms.Button
      Me.picImage = New System.Windows.Forms.PictureBox
      Me.lblCostcenter = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblName = New System.Windows.Forms.Label
      Me.txtCostcenterCode = New System.Windows.Forms.TextBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtTypeCode = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblType = New System.Windows.Forms.Label
      Me.lblLocation = New System.Windows.Forms.Label
      Me.txtLocation = New System.Windows.Forms.TextBox
      Me.lblRent = New System.Windows.Forms.Label
      Me.txtRent = New System.Windows.Forms.TextBox
      Me.lblDateInval = New System.Windows.Forms.Label
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.btnCostcenterEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtGLCode = New System.Windows.Forms.TextBox
      Me.lblGl = New System.Windows.Forms.Label
      Me.btnGLEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtGLName = New System.Windows.Forms.TextBox
      Me.btnTypeFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnCostcenterFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnTypeEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtTypeName = New System.Windows.Forms.TextBox
      Me.txtCostcenterName = New System.Windows.Forms.TextBox
      Me.btnDepreAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtDepreAcctCode = New System.Windows.Forms.TextBox
      Me.lblDepreAcct = New System.Windows.Forms.Label
      Me.btnDepreAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtDepreAcctName = New System.Windows.Forms.TextBox
      Me.btnDepreOpeningAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtDepreOpeningAcctName = New System.Windows.Forms.TextBox
      Me.btnDepreOpeningAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtDepreOpeningAcctCode = New System.Windows.Forms.TextBox
      Me.txtDetail = New System.Windows.Forms.TextBox
      Me.lblDetail = New System.Windows.Forms.Label
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbStatus.SuspendLayout()
      Me.grbBuyDetail.SuspendLayout()
      Me.grbCalcDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lblPicSize)
      Me.grbDetail.Controls.Add(Me.lblDepreOpeningAcct)
      Me.grbDetail.Controls.Add(Me.btnLoadImage)
      Me.grbDetail.Controls.Add(Me.btnClearImage)
      Me.grbDetail.Controls.Add(Me.grbStatus)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.btnGLFind)
      Me.grbDetail.Controls.Add(Me.grbBuyDetail)
      Me.grbDetail.Controls.Add(Me.grbCalcDetail)
      Me.grbDetail.Controls.Add(Me.btnAssetAuxDetail)
      Me.grbDetail.Controls.Add(Me.picImage)
      Me.grbDetail.Controls.Add(Me.lblCostcenter)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.txtCostcenterCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtTypeCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblType)
      Me.grbDetail.Controls.Add(Me.lblLocation)
      Me.grbDetail.Controls.Add(Me.txtLocation)
      Me.grbDetail.Controls.Add(Me.lblRent)
      Me.grbDetail.Controls.Add(Me.txtRent)
      Me.grbDetail.Controls.Add(Me.lblDateInval)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.btnCostcenterEdit)
      Me.grbDetail.Controls.Add(Me.txtGLCode)
      Me.grbDetail.Controls.Add(Me.lblGl)
      Me.grbDetail.Controls.Add(Me.btnGLEdit)
      Me.grbDetail.Controls.Add(Me.txtGLName)
      Me.grbDetail.Controls.Add(Me.btnTypeFind)
      Me.grbDetail.Controls.Add(Me.btnCostcenterFind)
      Me.grbDetail.Controls.Add(Me.btnTypeEdit)
      Me.grbDetail.Controls.Add(Me.txtTypeName)
      Me.grbDetail.Controls.Add(Me.txtCostcenterName)
      Me.grbDetail.Controls.Add(Me.btnDepreAcctFind)
      Me.grbDetail.Controls.Add(Me.txtDepreAcctCode)
      Me.grbDetail.Controls.Add(Me.lblDepreAcct)
      Me.grbDetail.Controls.Add(Me.btnDepreAcctEdit)
      Me.grbDetail.Controls.Add(Me.txtDepreAcctName)
      Me.grbDetail.Controls.Add(Me.btnDepreOpeningAcctEdit)
      Me.grbDetail.Controls.Add(Me.txtDepreOpeningAcctName)
      Me.grbDetail.Controls.Add(Me.btnDepreOpeningAcctFind)
      Me.grbDetail.Controls.Add(Me.txtDepreOpeningAcctCode)
      Me.grbDetail.Controls.Add(Me.txtDetail)
      Me.grbDetail.Controls.Add(Me.lblDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(792, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลสินทรัพย์ : "
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.Location = New System.Drawing.Point(600, 120)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.TabIndex = 202
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDepreOpeningAcct
      '
      Me.lblDepreOpeningAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDepreOpeningAcct.ForeColor = System.Drawing.Color.Black
      Me.lblDepreOpeningAcct.Location = New System.Drawing.Point(8, 208)
      Me.lblDepreOpeningAcct.Name = "lblDepreOpeningAcct"
      Me.lblDepreOpeningAcct.Size = New System.Drawing.Size(128, 32)
      Me.lblDepreOpeningAcct.TabIndex = 11
      Me.lblDepreOpeningAcct.Text = "Accumulated Depreciation Acc."
      Me.lblDepreOpeningAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnLoadImage
      '
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Image = CType(resources.GetObject("btnLoadImage.Image"), System.Drawing.Image)
      Me.btnLoadImage.Location = New System.Drawing.Point(736, 232)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 9
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Image = CType(resources.GetObject("btnClearImage.Image"), System.Drawing.Image)
      Me.btnClearImage.Location = New System.Drawing.Point(760, 232)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 10
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbStatus
      '
      Me.grbStatus.Controls.Add(Me.chkDecay)
      Me.grbStatus.Controls.Add(Me.chkCancel)
      Me.grbStatus.Controls.Add(Me.lblCurrentStatus)
      Me.grbStatus.Controls.Add(Me.lblAssetStatus)
      Me.grbStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbStatus.ForeColor = System.Drawing.Color.Black
      Me.grbStatus.Location = New System.Drawing.Point(8, 16)
      Me.grbStatus.Name = "grbStatus"
      Me.grbStatus.Size = New System.Drawing.Size(496, 48)
      Me.grbStatus.TabIndex = 48
      Me.grbStatus.TabStop = False
      Me.grbStatus.Text = "สถานะสินทรัพย์"
      '
      'chkDecay
      '
      Me.chkDecay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDecay.Location = New System.Drawing.Point(208, 15)
      Me.chkDecay.Name = "chkDecay"
      Me.chkDecay.Size = New System.Drawing.Size(72, 24)
      Me.chkDecay.TabIndex = 6
      Me.chkDecay.Text = "ชำรุด"
      '
      'chkCancel
      '
      Me.chkCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCancel.Location = New System.Drawing.Point(128, 15)
      Me.chkCancel.Name = "chkCancel"
      Me.chkCancel.Size = New System.Drawing.Size(72, 24)
      Me.chkCancel.TabIndex = 5
      Me.chkCancel.Text = "ยกเลิก"
      '
      'lblCurrentStatus
      '
      Me.lblCurrentStatus.Location = New System.Drawing.Point(368, 19)
      Me.lblCurrentStatus.Name = "lblCurrentStatus"
      Me.lblCurrentStatus.Size = New System.Drawing.Size(120, 20)
      Me.lblCurrentStatus.TabIndex = 4
      '
      'lblAssetStatus
      '
      Me.lblAssetStatus.Location = New System.Drawing.Point(288, 19)
      Me.lblAssetStatus.Name = "lblAssetStatus"
      Me.lblAssetStatus.Size = New System.Drawing.Size(80, 20)
      Me.lblAssetStatus.TabIndex = 0
      Me.lblAssetStatus.Text = "สถานะปัจจุบัน"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(248, 72)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 1
      Me.chkAutorun.TabStop = False
      '
      'btnGLFind
      '
      Me.btnGLFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGLFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGLFind.Image = CType(resources.GetObject("btnGLFind.Image"), System.Drawing.Image)
      Me.btnGLFind.Location = New System.Drawing.Point(456, 192)
      Me.btnGLFind.Name = "btnGLFind"
      Me.btnGLFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGLFind.TabIndex = 16
      Me.btnGLFind.TabStop = False
      Me.btnGLFind.ThemedImage = CType(resources.GetObject("btnGLFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbBuyDetail
      '
      Me.grbBuyDetail.Controls.Add(Me.txtBuyDate)
      Me.grbBuyDetail.Controls.Add(Me.lblBuyDate)
      Me.grbBuyDetail.Controls.Add(Me.dtpBuyDate)
      Me.grbBuyDetail.Controls.Add(Me.txtBuyDocDate)
      Me.grbBuyDetail.Controls.Add(Me.txtBuyFrom)
      Me.grbBuyDetail.Controls.Add(Me.lblBuyPrice)
      Me.grbBuyDetail.Controls.Add(Me.dtpBuyDocDate)
      Me.grbBuyDetail.Controls.Add(Me.txtBuyPrice)
      Me.grbBuyDetail.Controls.Add(Me.lblBuyFrom)
      Me.grbBuyDetail.Controls.Add(Me.lblBuyDocCode)
      Me.grbBuyDetail.Controls.Add(Me.txtBuyDocCode)
      Me.grbBuyDetail.Controls.Add(Me.lblBuyDocDate)
      Me.grbBuyDetail.Controls.Add(Me.lblCurrency1)
      Me.grbBuyDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBuyDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBuyDetail.Location = New System.Drawing.Point(520, 360)
      Me.grbBuyDetail.Name = "grbBuyDetail"
      Me.grbBuyDetail.Size = New System.Drawing.Size(264, 152)
      Me.grbBuyDetail.TabIndex = 45
      Me.grbBuyDetail.TabStop = False
      Me.grbBuyDetail.Text = "ข้อมูลการซื้อ : "
      '
      'txtBuyDate
      '
      Me.Validator.SetDataType(Me.txtBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBuyDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBuyDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.txtBuyDate.Location = New System.Drawing.Point(120, 48)
      Me.Validator.SetMaxValue(Me.txtBuyDate, "")
      Me.Validator.SetMinValue(Me.txtBuyDate, "")
      Me.txtBuyDate.Name = "txtBuyDate"
      Me.Validator.SetRegularExpression(Me.txtBuyDate, "")
      Me.Validator.SetRequired(Me.txtBuyDate, True)
      Me.txtBuyDate.Size = New System.Drawing.Size(91, 21)
      Me.txtBuyDate.TabIndex = 15
      Me.txtBuyDate.Text = ""
      '
      'lblBuyDate
      '
      Me.lblBuyDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyDate.ForeColor = System.Drawing.Color.Black
      Me.lblBuyDate.Location = New System.Drawing.Point(24, 48)
      Me.lblBuyDate.Name = "lblBuyDate"
      Me.lblBuyDate.Size = New System.Drawing.Size(96, 23)
      Me.lblBuyDate.TabIndex = 16
      Me.lblBuyDate.Text = "วันที่ซื้อ:"
      Me.lblBuyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBuyDate
      '
      Me.dtpBuyDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBuyDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBuyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBuyDate.Location = New System.Drawing.Point(120, 48)
      Me.dtpBuyDate.Name = "dtpBuyDate"
      Me.dtpBuyDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpBuyDate.TabIndex = 17
      Me.dtpBuyDate.TabStop = False
      '
      'txtBuyDocDate
      '
      Me.Validator.SetDataType(Me.txtBuyDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBuyDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBuyDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBuyDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBuyDocDate, System.Drawing.Color.Empty)
      Me.txtBuyDocDate.Location = New System.Drawing.Point(120, 96)
      Me.Validator.SetMaxValue(Me.txtBuyDocDate, "")
      Me.Validator.SetMinValue(Me.txtBuyDocDate, "")
      Me.txtBuyDocDate.Name = "txtBuyDocDate"
      Me.Validator.SetRegularExpression(Me.txtBuyDocDate, "")
      Me.Validator.SetRequired(Me.txtBuyDocDate, False)
      Me.txtBuyDocDate.Size = New System.Drawing.Size(91, 21)
      Me.txtBuyDocDate.TabIndex = 6
      Me.txtBuyDocDate.Text = ""
      '
      'txtBuyFrom
      '
      Me.Validator.SetDataType(Me.txtBuyFrom, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyFrom, "")
      Me.txtBuyFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyFrom, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBuyFrom, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBuyFrom, System.Drawing.Color.Empty)
      Me.txtBuyFrom.Location = New System.Drawing.Point(120, 120)
      Me.Validator.SetMaxValue(Me.txtBuyFrom, "")
      Me.Validator.SetMinValue(Me.txtBuyFrom, "")
      Me.txtBuyFrom.Name = "txtBuyFrom"
      Me.Validator.SetRegularExpression(Me.txtBuyFrom, "")
      Me.Validator.SetRequired(Me.txtBuyFrom, False)
      Me.txtBuyFrom.Size = New System.Drawing.Size(112, 21)
      Me.txtBuyFrom.TabIndex = 8
      Me.txtBuyFrom.Text = ""
      '
      'lblBuyPrice
      '
      Me.lblBuyPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyPrice.ForeColor = System.Drawing.Color.Black
      Me.lblBuyPrice.Location = New System.Drawing.Point(8, 23)
      Me.lblBuyPrice.Name = "lblBuyPrice"
      Me.lblBuyPrice.Size = New System.Drawing.Size(112, 23)
      Me.lblBuyPrice.TabIndex = 0
      Me.lblBuyPrice.Text = "ราคาซื้อ:"
      Me.lblBuyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBuyDocDate
      '
      Me.dtpBuyDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBuyDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBuyDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBuyDocDate.Location = New System.Drawing.Point(120, 96)
      Me.dtpBuyDocDate.Name = "dtpBuyDocDate"
      Me.dtpBuyDocDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpBuyDocDate.TabIndex = 9
      Me.dtpBuyDocDate.TabStop = False
      '
      'txtBuyPrice
      '
      Me.Validator.SetDataType(Me.txtBuyPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBuyPrice, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.txtBuyPrice.Location = New System.Drawing.Point(120, 24)
      Me.Validator.SetMaxValue(Me.txtBuyPrice, "")
      Me.Validator.SetMinValue(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Name = "txtBuyPrice"
      Me.Validator.SetRegularExpression(Me.txtBuyPrice, "")
      Me.Validator.SetRequired(Me.txtBuyPrice, True)
      Me.txtBuyPrice.Size = New System.Drawing.Size(112, 21)
      Me.txtBuyPrice.TabIndex = 1
      Me.txtBuyPrice.Text = ""
      Me.txtBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBuyFrom
      '
      Me.lblBuyFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyFrom.ForeColor = System.Drawing.Color.Black
      Me.lblBuyFrom.Location = New System.Drawing.Point(8, 120)
      Me.lblBuyFrom.Name = "lblBuyFrom"
      Me.lblBuyFrom.Size = New System.Drawing.Size(112, 23)
      Me.lblBuyFrom.TabIndex = 7
      Me.lblBuyFrom.Text = "ซื้อจาก:"
      Me.lblBuyFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuyDocCode
      '
      Me.lblBuyDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyDocCode.ForeColor = System.Drawing.Color.Black
      Me.lblBuyDocCode.Location = New System.Drawing.Point(8, 72)
      Me.lblBuyDocCode.Name = "lblBuyDocCode"
      Me.lblBuyDocCode.Size = New System.Drawing.Size(112, 23)
      Me.lblBuyDocCode.TabIndex = 3
      Me.lblBuyDocCode.Text = "เลขที่ซื้อในเอกสาร:"
      Me.lblBuyDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBuyDocCode
      '
      Me.Validator.SetDataType(Me.txtBuyDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyDocCode, "")
      Me.txtBuyDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyDocCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBuyDocCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBuyDocCode, System.Drawing.Color.Empty)
      Me.txtBuyDocCode.Location = New System.Drawing.Point(120, 72)
      Me.Validator.SetMaxValue(Me.txtBuyDocCode, "")
      Me.Validator.SetMinValue(Me.txtBuyDocCode, "")
      Me.txtBuyDocCode.Name = "txtBuyDocCode"
      Me.Validator.SetRegularExpression(Me.txtBuyDocCode, "")
      Me.Validator.SetRequired(Me.txtBuyDocCode, False)
      Me.txtBuyDocCode.Size = New System.Drawing.Size(112, 21)
      Me.txtBuyDocCode.TabIndex = 4
      Me.txtBuyDocCode.Text = ""
      '
      'lblBuyDocDate
      '
      Me.lblBuyDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblBuyDocDate.Location = New System.Drawing.Point(8, 96)
      Me.lblBuyDocDate.Name = "lblBuyDocDate"
      Me.lblBuyDocDate.Size = New System.Drawing.Size(112, 23)
      Me.lblBuyDocDate.TabIndex = 5
      Me.lblBuyDocDate.Text = "วันที่ซื้อในเอกสาร:"
      Me.lblBuyDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency1
      '
      Me.lblCurrency1.AutoSize = True
      Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency1.Location = New System.Drawing.Point(232, 26)
      Me.lblCurrency1.Name = "lblCurrency1"
      Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency1.TabIndex = 2
      Me.lblCurrency1.Text = "บาท"
      Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbCalcDetail
      '
      Me.grbCalcDetail.Controls.Add(Me.txtStartCalcDate)
      Me.grbCalcDetail.Controls.Add(Me.lblEndCalcDate)
      Me.grbCalcDetail.Controls.Add(Me.txtAge)
      Me.grbCalcDetail.Controls.Add(Me.txtCalcRate)
      Me.grbCalcDetail.Controls.Add(Me.lblAge)
      Me.grbCalcDetail.Controls.Add(Me.dtpStartCalcDate)
      Me.grbCalcDetail.Controls.Add(Me.txtStartCalcAmt)
      Me.grbCalcDetail.Controls.Add(Me.lblCalcType)
      Me.grbCalcDetail.Controls.Add(Me.lblStartCalcDate)
      Me.grbCalcDetail.Controls.Add(Me.cmbCalcType)
      Me.grbCalcDetail.Controls.Add(Me.lblYear)
      Me.grbCalcDetail.Controls.Add(Me.lblYear1)
      Me.grbCalcDetail.Controls.Add(Me.lblCurrency2)
      Me.grbCalcDetail.Controls.Add(Me.lblCurrency3)
      Me.grbCalcDetail.Controls.Add(Me.txtSalvage)
      Me.grbCalcDetail.Controls.Add(Me.txtRemainingValue)
      Me.grbCalcDetail.Controls.Add(Me.lblCurrency4)
      Me.grbCalcDetail.Controls.Add(Me.lblCurrency5)
      Me.grbCalcDetail.Controls.Add(Me.txtDepreOpenning)
      Me.grbCalcDetail.Controls.Add(Me.txtEndCalcDate)
      Me.grbCalcDetail.Controls.Add(Me.lblCalcRate)
      Me.grbCalcDetail.Controls.Add(Me.lblStartCalcAmnt)
      Me.grbCalcDetail.Controls.Add(Me.lblSavage)
      Me.grbCalcDetail.Controls.Add(Me.lblRemainingValue)
      Me.grbCalcDetail.Controls.Add(Me.lblDepreOpenning)
      Me.grbCalcDetail.Controls.Add(Me.txtTransferDate)
      Me.grbCalcDetail.Controls.Add(Me.lblTransferDate)
      Me.grbCalcDetail.Controls.Add(Me.dtpTransferDate)
      Me.grbCalcDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCalcDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbCalcDetail.Location = New System.Drawing.Point(8, 360)
      Me.grbCalcDetail.Name = "grbCalcDetail"
      Me.grbCalcDetail.Size = New System.Drawing.Size(504, 152)
      Me.grbCalcDetail.TabIndex = 44
      Me.grbCalcDetail.TabStop = False
      Me.grbCalcDetail.Text = "ข้อมูลการคิดค่าเสื่อมราคา : "
      '
      'txtStartCalcDate
      '
      Me.Validator.SetDataType(Me.txtStartCalcDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartCalcDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStartCalcDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartCalcDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtStartCalcDate, System.Drawing.Color.Empty)
      Me.txtStartCalcDate.Location = New System.Drawing.Point(128, 48)
      Me.Validator.SetMaxValue(Me.txtStartCalcDate, "")
      Me.Validator.SetMinValue(Me.txtStartCalcDate, "")
      Me.txtStartCalcDate.Name = "txtStartCalcDate"
      Me.Validator.SetRegularExpression(Me.txtStartCalcDate, "")
      Me.Validator.SetRequired(Me.txtStartCalcDate, True)
      Me.txtStartCalcDate.Size = New System.Drawing.Size(91, 21)
      Me.txtStartCalcDate.TabIndex = 1
      Me.txtStartCalcDate.Text = ""
      '
      'lblEndCalcDate
      '
      Me.lblEndCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEndCalcDate.ForeColor = System.Drawing.Color.Black
      Me.lblEndCalcDate.Location = New System.Drawing.Point(8, 121)
      Me.lblEndCalcDate.Name = "lblEndCalcDate"
      Me.lblEndCalcDate.Size = New System.Drawing.Size(120, 18)
      Me.lblEndCalcDate.TabIndex = 11
      Me.lblEndCalcDate.Text = "วันสิ้นสุดการคำนวณ:"
      Me.lblEndCalcDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAge
      '
      Me.Validator.SetDataType(Me.txtAge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtAge, "")
      Me.txtAge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAge, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAge, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAge, System.Drawing.Color.Empty)
      Me.txtAge.Location = New System.Drawing.Point(128, 72)
      Me.Validator.SetMaxValue(Me.txtAge, "999")
      Me.Validator.SetMinValue(Me.txtAge, "0")
      Me.txtAge.Name = "txtAge"
      Me.Validator.SetRegularExpression(Me.txtAge, "")
      Me.Validator.SetRequired(Me.txtAge, True)
      Me.txtAge.Size = New System.Drawing.Size(112, 21)
      Me.txtAge.TabIndex = 2
      Me.txtAge.Text = ""
      Me.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCalcRate
      '
      Me.Validator.SetDataType(Me.txtCalcRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtCalcRate, "")
      Me.txtCalcRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCalcRate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCalcRate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCalcRate, System.Drawing.Color.Empty)
      Me.txtCalcRate.Location = New System.Drawing.Point(360, 24)
      Me.Validator.SetMaxValue(Me.txtCalcRate, "100.00")
      Me.Validator.SetMinValue(Me.txtCalcRate, "0.00")
      Me.txtCalcRate.Name = "txtCalcRate"
      Me.txtCalcRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCalcRate, "")
      Me.Validator.SetRequired(Me.txtCalcRate, True)
      Me.txtCalcRate.Size = New System.Drawing.Size(96, 21)
      Me.txtCalcRate.TabIndex = 21
      Me.txtCalcRate.TabStop = False
      Me.txtCalcRate.Text = ""
      Me.txtCalcRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAge
      '
      Me.lblAge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAge.ForeColor = System.Drawing.Color.Black
      Me.lblAge.Location = New System.Drawing.Point(8, 72)
      Me.lblAge.Name = "lblAge"
      Me.lblAge.Size = New System.Drawing.Size(120, 18)
      Me.lblAge.TabIndex = 10
      Me.lblAge.Text = "อายุคิดค่าเสื่อม:"
      Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpStartCalcDate
      '
      Me.dtpStartCalcDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpStartCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpStartCalcDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpStartCalcDate.Location = New System.Drawing.Point(128, 48)
      Me.dtpStartCalcDate.Name = "dtpStartCalcDate"
      Me.dtpStartCalcDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpStartCalcDate.TabIndex = 13
      Me.dtpStartCalcDate.TabStop = False
      '
      'txtStartCalcAmt
      '
      Me.Validator.SetDataType(Me.txtStartCalcAmt, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtStartCalcAmt, "")
      Me.txtStartCalcAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStartCalcAmt, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartCalcAmt, -15)
      Me.Validator.SetInvalidBackColor(Me.txtStartCalcAmt, System.Drawing.Color.Empty)
      Me.txtStartCalcAmt.Location = New System.Drawing.Point(360, 48)
      Me.Validator.SetMaxValue(Me.txtStartCalcAmt, "")
      Me.Validator.SetMinValue(Me.txtStartCalcAmt, "0")
      Me.txtStartCalcAmt.Name = "txtStartCalcAmt"
      Me.Validator.SetRegularExpression(Me.txtStartCalcAmt, "")
      Me.Validator.SetRequired(Me.txtStartCalcAmt, False)
      Me.txtStartCalcAmt.Size = New System.Drawing.Size(96, 21)
      Me.txtStartCalcAmt.TabIndex = 4
      Me.txtStartCalcAmt.Text = ""
      Me.txtStartCalcAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCalcType
      '
      Me.lblCalcType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCalcType.ForeColor = System.Drawing.Color.Black
      Me.lblCalcType.Location = New System.Drawing.Point(8, 24)
      Me.lblCalcType.Name = "lblCalcType"
      Me.lblCalcType.Size = New System.Drawing.Size(120, 18)
      Me.lblCalcType.TabIndex = 7
      Me.lblCalcType.Text = "ประเภทการคำนวณ:"
      Me.lblCalcType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStartCalcDate
      '
      Me.lblStartCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartCalcDate.ForeColor = System.Drawing.Color.Black
      Me.lblStartCalcDate.Location = New System.Drawing.Point(8, 49)
      Me.lblStartCalcDate.Name = "lblStartCalcDate"
      Me.lblStartCalcDate.Size = New System.Drawing.Size(120, 18)
      Me.lblStartCalcDate.TabIndex = 8
      Me.lblStartCalcDate.Text = "วันที่เริ่มคำนวณ:"
      Me.lblStartCalcDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCalcType
      '
      Me.cmbCalcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCalcType, -15)
      Me.cmbCalcType.Location = New System.Drawing.Point(128, 24)
      Me.cmbCalcType.Name = "cmbCalcType"
      Me.cmbCalcType.Size = New System.Drawing.Size(112, 21)
      Me.cmbCalcType.TabIndex = 0
      '
      'lblYear
      '
      Me.lblYear.AutoSize = True
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.Color.Black
      Me.lblYear.Location = New System.Drawing.Point(248, 72)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(11, 17)
      Me.lblYear.TabIndex = 19
      Me.lblYear.Text = "ปี"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblYear1
      '
      Me.lblYear1.AutoSize = True
      Me.lblYear1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear1.ForeColor = System.Drawing.Color.Black
      Me.lblYear1.Location = New System.Drawing.Point(464, 26)
      Me.lblYear1.Name = "lblYear1"
      Me.lblYear1.Size = New System.Drawing.Size(36, 17)
      Me.lblYear1.TabIndex = 22
      Me.lblYear1.Text = "%ต่อปี"
      Me.lblYear1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCurrency2
      '
      Me.lblCurrency2.AutoSize = True
      Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency2.Location = New System.Drawing.Point(464, 50)
      Me.lblCurrency2.Name = "lblCurrency2"
      Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency2.TabIndex = 23
      Me.lblCurrency2.Text = "บาท"
      Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCurrency3
      '
      Me.lblCurrency3.AutoSize = True
      Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency3.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency3.Location = New System.Drawing.Point(464, 74)
      Me.lblCurrency3.Name = "lblCurrency3"
      Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency3.TabIndex = 24
      Me.lblCurrency3.Text = "บาท"
      Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtSalvage
      '
      Me.Validator.SetDataType(Me.txtSalvage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtSalvage, "")
      Me.txtSalvage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSalvage, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSalvage, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSalvage, System.Drawing.Color.Empty)
      Me.txtSalvage.Location = New System.Drawing.Point(360, 72)
      Me.Validator.SetMaxValue(Me.txtSalvage, "")
      Me.Validator.SetMinValue(Me.txtSalvage, "1")
      Me.txtSalvage.Name = "txtSalvage"
      Me.Validator.SetRegularExpression(Me.txtSalvage, "")
      Me.Validator.SetRequired(Me.txtSalvage, False)
      Me.txtSalvage.Size = New System.Drawing.Size(96, 21)
      Me.txtSalvage.TabIndex = 5
      Me.txtSalvage.Text = ""
      Me.txtSalvage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRemainingValue
      '
      Me.Validator.SetDataType(Me.txtRemainingValue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtRemainingValue, "")
      Me.txtRemainingValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRemainingValue, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRemainingValue, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRemainingValue, System.Drawing.Color.Empty)
      Me.txtRemainingValue.Location = New System.Drawing.Point(360, 120)
      Me.Validator.SetMaxValue(Me.txtRemainingValue, "")
      Me.Validator.SetMinValue(Me.txtRemainingValue, "")
      Me.txtRemainingValue.Name = "txtRemainingValue"
      Me.txtRemainingValue.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRemainingValue, "")
      Me.Validator.SetRequired(Me.txtRemainingValue, False)
      Me.txtRemainingValue.Size = New System.Drawing.Size(96, 21)
      Me.txtRemainingValue.TabIndex = 27
      Me.txtRemainingValue.TabStop = False
      Me.txtRemainingValue.Text = ""
      Me.txtRemainingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrency4
      '
      Me.lblCurrency4.AutoSize = True
      Me.lblCurrency4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency4.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency4.Location = New System.Drawing.Point(464, 122)
      Me.lblCurrency4.Name = "lblCurrency4"
      Me.lblCurrency4.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency4.TabIndex = 26
      Me.lblCurrency4.Text = "บาท"
      Me.lblCurrency4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCurrency5
      '
      Me.lblCurrency5.AutoSize = True
      Me.lblCurrency5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency5.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency5.Location = New System.Drawing.Point(464, 98)
      Me.lblCurrency5.Name = "lblCurrency5"
      Me.lblCurrency5.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency5.TabIndex = 25
      Me.lblCurrency5.Text = "บาท"
      Me.lblCurrency5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtDepreOpenning
      '
      Me.Validator.SetDataType(Me.txtDepreOpenning, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtDepreOpenning, "")
      Me.txtDepreOpenning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDepreOpenning, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreOpenning, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreOpenning, System.Drawing.Color.Empty)
      Me.txtDepreOpenning.Location = New System.Drawing.Point(360, 96)
      Me.Validator.SetMaxValue(Me.txtDepreOpenning, "")
      Me.Validator.SetMinValue(Me.txtDepreOpenning, "")
      Me.txtDepreOpenning.Name = "txtDepreOpenning"
      Me.Validator.SetRegularExpression(Me.txtDepreOpenning, "")
      Me.Validator.SetRequired(Me.txtDepreOpenning, False)
      Me.txtDepreOpenning.Size = New System.Drawing.Size(96, 21)
      Me.txtDepreOpenning.TabIndex = 6
      Me.txtDepreOpenning.TabStop = False
      Me.txtDepreOpenning.Text = ""
      Me.txtDepreOpenning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtEndCalcDate
      '
      Me.Validator.SetDataType(Me.txtEndCalcDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEndCalcDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEndCalcDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEndCalcDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEndCalcDate, System.Drawing.Color.Empty)
      Me.txtEndCalcDate.Location = New System.Drawing.Point(128, 120)
      Me.Validator.SetMaxValue(Me.txtEndCalcDate, "")
      Me.Validator.SetMinValue(Me.txtEndCalcDate, "")
      Me.txtEndCalcDate.Name = "txtEndCalcDate"
      Me.txtEndCalcDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEndCalcDate, "")
      Me.Validator.SetRequired(Me.txtEndCalcDate, False)
      Me.txtEndCalcDate.Size = New System.Drawing.Size(112, 21)
      Me.txtEndCalcDate.TabIndex = 12
      Me.txtEndCalcDate.TabStop = False
      Me.txtEndCalcDate.Text = ""
      '
      'lblCalcRate
      '
      Me.lblCalcRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCalcRate.ForeColor = System.Drawing.Color.Black
      Me.lblCalcRate.Location = New System.Drawing.Point(248, 25)
      Me.lblCalcRate.Name = "lblCalcRate"
      Me.lblCalcRate.Size = New System.Drawing.Size(112, 18)
      Me.lblCalcRate.TabIndex = 15
      Me.lblCalcRate.Text = "อัตราการคำนวณ:"
      Me.lblCalcRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStartCalcAmnt
      '
      Me.lblStartCalcAmnt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartCalcAmnt.ForeColor = System.Drawing.Color.Black
      Me.lblStartCalcAmnt.Location = New System.Drawing.Point(248, 49)
      Me.lblStartCalcAmnt.Name = "lblStartCalcAmnt"
      Me.lblStartCalcAmnt.Size = New System.Drawing.Size(112, 18)
      Me.lblStartCalcAmnt.TabIndex = 16
      Me.lblStartCalcAmnt.Text = "ค่าเสื่อมเบื้องต้น:"
      Me.lblStartCalcAmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSavage
      '
      Me.lblSavage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSavage.ForeColor = System.Drawing.Color.Black
      Me.lblSavage.Location = New System.Drawing.Point(272, 73)
      Me.lblSavage.Name = "lblSavage"
      Me.lblSavage.Size = New System.Drawing.Size(88, 18)
      Me.lblSavage.TabIndex = 17
      Me.lblSavage.Text = "ราคาซาก:"
      Me.lblSavage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemainingValue
      '
      Me.lblRemainingValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemainingValue.ForeColor = System.Drawing.Color.Black
      Me.lblRemainingValue.Location = New System.Drawing.Point(240, 121)
      Me.lblRemainingValue.Name = "lblRemainingValue"
      Me.lblRemainingValue.Size = New System.Drawing.Size(120, 18)
      Me.lblRemainingValue.TabIndex = 20
      Me.lblRemainingValue.Text = "มูลค่าคงเหลือยกมา:"
      Me.lblRemainingValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDepreOpenning
      '
      Me.lblDepreOpenning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDepreOpenning.ForeColor = System.Drawing.Color.Black
      Me.lblDepreOpenning.Location = New System.Drawing.Point(240, 97)
      Me.lblDepreOpenning.Name = "lblDepreOpenning"
      Me.lblDepreOpenning.Size = New System.Drawing.Size(120, 18)
      Me.lblDepreOpenning.TabIndex = 18
      Me.lblDepreOpenning.Text = "ค่าเสื่อมสะสมยกมา:"
      Me.lblDepreOpenning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTransferDate
      '
      Me.Validator.SetDataType(Me.txtTransferDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtTransferDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTransferDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTransferDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTransferDate, System.Drawing.Color.Empty)
      Me.txtTransferDate.Location = New System.Drawing.Point(128, 96)
      Me.Validator.SetMaxValue(Me.txtTransferDate, "")
      Me.Validator.SetMinValue(Me.txtTransferDate, "")
      Me.txtTransferDate.Name = "txtTransferDate"
      Me.Validator.SetRegularExpression(Me.txtTransferDate, "")
      Me.Validator.SetRequired(Me.txtTransferDate, True)
      Me.txtTransferDate.Size = New System.Drawing.Size(91, 21)
      Me.txtTransferDate.TabIndex = 3
      Me.txtTransferDate.Text = ""
      '
      'lblTransferDate
      '
      Me.lblTransferDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTransferDate.ForeColor = System.Drawing.Color.Black
      Me.lblTransferDate.Location = New System.Drawing.Point(8, 96)
      Me.lblTransferDate.Name = "lblTransferDate"
      Me.lblTransferDate.Size = New System.Drawing.Size(120, 23)
      Me.lblTransferDate.TabIndex = 9
      Me.lblTransferDate.Text = "วันที่ค่าเสื่อมยกมา:"
      Me.lblTransferDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpTransferDate
      '
      Me.dtpTransferDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpTransferDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpTransferDate.Location = New System.Drawing.Point(128, 96)
      Me.dtpTransferDate.Name = "dtpTransferDate"
      Me.dtpTransferDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpTransferDate.TabIndex = 14
      Me.dtpTransferDate.TabStop = False
      '
      'btnAssetAuxDetail
      '
      Me.btnAssetAuxDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetAuxDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetAuxDetail.ForeColor = System.Drawing.Color.Black
      Me.btnAssetAuxDetail.Location = New System.Drawing.Point(688, 512)
      Me.btnAssetAuxDetail.Name = "btnAssetAuxDetail"
      Me.btnAssetAuxDetail.Size = New System.Drawing.Size(96, 24)
      Me.btnAssetAuxDetail.TabIndex = 46
      Me.btnAssetAuxDetail.TabStop = False
      Me.btnAssetAuxDetail.Text = "ข้อมูลเพิ่มเติม"
      '
      'picImage
      '
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImage.Location = New System.Drawing.Point(512, 24)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(272, 204)
      Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picImage.TabIndex = 13
      Me.picImage.TabStop = False
      '
      'lblCostcenter
      '
      Me.lblCostcenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenter.Location = New System.Drawing.Point(8, 264)
      Me.lblCostcenter.Name = "lblCostcenter"
      Me.lblCostcenter.Size = New System.Drawing.Size(128, 18)
      Me.lblCostcenter.TabIndex = 21
      Me.lblCostcenter.Text = "Cost center :"
      Me.lblCostcenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(136, 96)
      Me.txtName.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(344, 21)
      Me.txtName.TabIndex = 3
      Me.txtName.Text = ""
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 96)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(128, 18)
      Me.lblName.TabIndex = 4
      Me.lblName.Text = "ชื่อ :"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostcenterCode
      '
      Me.Validator.SetDataType(Me.txtCostcenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostcenterCode, "")
      Me.txtCostcenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostcenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.txtCostcenterCode.Location = New System.Drawing.Point(136, 264)
      Me.txtCostcenterCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCostcenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostcenterCode, "")
      Me.txtCostcenterCode.Name = "txtCostcenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostcenterCode, "")
      Me.Validator.SetRequired(Me.txtCostcenterCode, True)
      Me.txtCostcenterCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCostcenterCode.TabIndex = 9
      Me.txtCostcenterCode.Text = ""
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 72)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส :"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTypeCode
      '
      Me.Validator.SetDataType(Me.txtTypeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTypeCode, "")
      Me.txtTypeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTypeCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTypeCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTypeCode, System.Drawing.Color.Empty)
      Me.txtTypeCode.Location = New System.Drawing.Point(136, 168)
      Me.txtTypeCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtTypeCode, "")
      Me.Validator.SetMinValue(Me.txtTypeCode, "")
      Me.txtTypeCode.Name = "txtTypeCode"
      Me.Validator.SetRegularExpression(Me.txtTypeCode, "")
      Me.Validator.SetRequired(Me.txtTypeCode, False)
      Me.txtTypeCode.Size = New System.Drawing.Size(112, 21)
      Me.txtTypeCode.TabIndex = 5
      Me.txtTypeCode.Text = ""
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(136, 72)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'lblType
      '
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.ForeColor = System.Drawing.Color.Black
      Me.lblType.Location = New System.Drawing.Point(8, 168)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(128, 18)
      Me.lblType.TabIndex = 31
      Me.lblType.Text = "ประเภท :"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLocation
      '
      Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLocation.ForeColor = System.Drawing.Color.Black
      Me.lblLocation.Location = New System.Drawing.Point(8, 332)
      Me.lblLocation.Name = "lblLocation"
      Me.lblLocation.Size = New System.Drawing.Size(128, 18)
      Me.lblLocation.TabIndex = 40
      Me.lblLocation.Text = "ที่ตั้ง :"
      Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLocation
      '
      Me.Validator.SetDataType(Me.txtLocation, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLocation, "")
      Me.txtLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLocation, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.txtLocation.Location = New System.Drawing.Point(136, 332)
      Me.txtLocation.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtLocation, "")
      Me.Validator.SetMinValue(Me.txtLocation, "")
      Me.txtLocation.Name = "txtLocation"
      Me.Validator.SetRegularExpression(Me.txtLocation, "")
      Me.Validator.SetRequired(Me.txtLocation, False)
      Me.txtLocation.Size = New System.Drawing.Size(344, 21)
      Me.txtLocation.TabIndex = 13
      Me.txtLocation.Text = ""
      '
      'lblRent
      '
      Me.lblRent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRent.ForeColor = System.Drawing.Color.Black
      Me.lblRent.Location = New System.Drawing.Point(8, 308)
      Me.lblRent.Name = "lblRent"
      Me.lblRent.Size = New System.Drawing.Size(128, 18)
      Me.lblRent.TabIndex = 36
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
      Me.txtRent.Location = New System.Drawing.Point(136, 308)
      Me.Validator.SetMaxValue(Me.txtRent, "")
      Me.Validator.SetMinValue(Me.txtRent, "")
      Me.txtRent.Name = "txtRent"
      Me.Validator.SetRegularExpression(Me.txtRent, "")
      Me.Validator.SetRequired(Me.txtRent, False)
      Me.txtRent.Size = New System.Drawing.Size(112, 21)
      Me.txtRent.TabIndex = 11
      Me.txtRent.Text = ""
      Me.txtRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDateInval
      '
      Me.lblDateInval.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDateInval.ForeColor = System.Drawing.Color.Black
      Me.lblDateInval.Location = New System.Drawing.Point(280, 308)
      Me.lblDateInval.Name = "lblDateInval"
      Me.lblDateInval.Size = New System.Drawing.Size(96, 18)
      Me.lblDateInval.TabIndex = 38
      Me.lblDateInval.Text = "บาทต่อวัน"
      Me.lblDateInval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(512, 264)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(272, 88)
      Me.txtNote.TabIndex = 43
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(512, 248)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(56, 18)
      Me.lblNote.TabIndex = 42
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCostcenterEdit
      '
      Me.btnCostcenterEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterEdit.Image = CType(resources.GetObject("btnCostcenterEdit.Image"), System.Drawing.Image)
      Me.btnCostcenterEdit.Location = New System.Drawing.Point(480, 264)
      Me.btnCostcenterEdit.Name = "btnCostcenterEdit"
      Me.btnCostcenterEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCostcenterEdit.TabIndex = 23
      Me.btnCostcenterEdit.TabStop = False
      Me.btnCostcenterEdit.ThemedImage = CType(resources.GetObject("btnCostcenterEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGLCode
      '
      Me.Validator.SetDataType(Me.txtGLCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLCode, "")
      Me.txtGLCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGLCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtGLCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtGLCode, System.Drawing.Color.Empty)
      Me.txtGLCode.Location = New System.Drawing.Point(136, 192)
      Me.txtGLCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtGLCode, "")
      Me.Validator.SetMinValue(Me.txtGLCode, "")
      Me.txtGLCode.Name = "txtGLCode"
      Me.Validator.SetRegularExpression(Me.txtGLCode, "")
      Me.Validator.SetRequired(Me.txtGLCode, True)
      Me.txtGLCode.Size = New System.Drawing.Size(112, 21)
      Me.txtGLCode.TabIndex = 6
      Me.txtGLCode.Text = ""
      '
      'lblGl
      '
      Me.lblGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGl.ForeColor = System.Drawing.Color.Black
      Me.lblGl.Location = New System.Drawing.Point(8, 192)
      Me.lblGl.Name = "lblGl"
      Me.lblGl.Size = New System.Drawing.Size(128, 18)
      Me.lblGl.TabIndex = 6
      Me.lblGl.Text = "ผังบัญชี :"
      Me.lblGl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnGLEdit
      '
      Me.btnGLEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGLEdit.Image = CType(resources.GetObject("btnGLEdit.Image"), System.Drawing.Image)
      Me.btnGLEdit.Location = New System.Drawing.Point(480, 192)
      Me.btnGLEdit.Name = "btnGLEdit"
      Me.btnGLEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnGLEdit.TabIndex = 17
      Me.btnGLEdit.TabStop = False
      Me.btnGLEdit.ThemedImage = CType(resources.GetObject("btnGLEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGLName
      '
      Me.Validator.SetDataType(Me.txtGLName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLName, "")
      Me.txtGLName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGLName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtGLName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtGLName, System.Drawing.Color.Empty)
      Me.txtGLName.Location = New System.Drawing.Point(248, 192)
      Me.Validator.SetMaxValue(Me.txtGLName, "")
      Me.Validator.SetMinValue(Me.txtGLName, "")
      Me.txtGLName.Name = "txtGLName"
      Me.txtGLName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGLName, "")
      Me.Validator.SetRequired(Me.txtGLName, False)
      Me.txtGLName.Size = New System.Drawing.Size(208, 21)
      Me.txtGLName.TabIndex = 8
      Me.txtGLName.TabStop = False
      Me.txtGLName.Text = ""
      '
      'btnTypeFind
      '
      Me.btnTypeFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnTypeFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnTypeFind.Image = CType(resources.GetObject("btnTypeFind.Image"), System.Drawing.Image)
      Me.btnTypeFind.Location = New System.Drawing.Point(456, 168)
      Me.btnTypeFind.Name = "btnTypeFind"
      Me.btnTypeFind.Size = New System.Drawing.Size(24, 23)
      Me.btnTypeFind.TabIndex = 14
      Me.btnTypeFind.TabStop = False
      Me.btnTypeFind.ThemedImage = CType(resources.GetObject("btnTypeFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCostcenterFind
      '
      Me.btnCostcenterFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterFind.Image = CType(resources.GetObject("btnCostcenterFind.Image"), System.Drawing.Image)
      Me.btnCostcenterFind.Location = New System.Drawing.Point(456, 264)
      Me.btnCostcenterFind.Name = "btnCostcenterFind"
      Me.btnCostcenterFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCostcenterFind.TabIndex = 22
      Me.btnCostcenterFind.TabStop = False
      Me.btnCostcenterFind.ThemedImage = CType(resources.GetObject("btnCostcenterFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnTypeEdit
      '
      Me.btnTypeEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnTypeEdit.Image = CType(resources.GetObject("btnTypeEdit.Image"), System.Drawing.Image)
      Me.btnTypeEdit.Location = New System.Drawing.Point(480, 168)
      Me.btnTypeEdit.Name = "btnTypeEdit"
      Me.btnTypeEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnTypeEdit.TabIndex = 15
      Me.btnTypeEdit.TabStop = False
      Me.btnTypeEdit.ThemedImage = CType(resources.GetObject("btnTypeEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTypeName
      '
      Me.Validator.SetDataType(Me.txtTypeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTypeName, "")
      Me.txtTypeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTypeName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTypeName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTypeName, System.Drawing.Color.Empty)
      Me.txtTypeName.Location = New System.Drawing.Point(248, 168)
      Me.Validator.SetMaxValue(Me.txtTypeName, "")
      Me.Validator.SetMinValue(Me.txtTypeName, "")
      Me.txtTypeName.Name = "txtTypeName"
      Me.txtTypeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTypeName, "")
      Me.Validator.SetRequired(Me.txtTypeName, False)
      Me.txtTypeName.Size = New System.Drawing.Size(208, 21)
      Me.txtTypeName.TabIndex = 33
      Me.txtTypeName.TabStop = False
      Me.txtTypeName.Text = ""
      '
      'txtCostcenterName
      '
      Me.Validator.SetDataType(Me.txtCostcenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostcenterName, "")
      Me.txtCostcenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostcenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostcenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostcenterName, System.Drawing.Color.Empty)
      Me.txtCostcenterName.Location = New System.Drawing.Point(248, 264)
      Me.Validator.SetMaxValue(Me.txtCostcenterName, "")
      Me.Validator.SetMinValue(Me.txtCostcenterName, "")
      Me.txtCostcenterName.Name = "txtCostcenterName"
      Me.txtCostcenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostcenterName, "")
      Me.Validator.SetRequired(Me.txtCostcenterName, False)
      Me.txtCostcenterName.Size = New System.Drawing.Size(208, 21)
      Me.txtCostcenterName.TabIndex = 23
      Me.txtCostcenterName.TabStop = False
      Me.txtCostcenterName.Text = ""
      '
      'btnDepreAcctFind
      '
      Me.btnDepreAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDepreAcctFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDepreAcctFind.Image = CType(resources.GetObject("btnDepreAcctFind.Image"), System.Drawing.Image)
      Me.btnDepreAcctFind.Location = New System.Drawing.Point(456, 240)
      Me.btnDepreAcctFind.Name = "btnDepreAcctFind"
      Me.btnDepreAcctFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDepreAcctFind.TabIndex = 20
      Me.btnDepreAcctFind.TabStop = False
      Me.btnDepreAcctFind.ThemedImage = CType(resources.GetObject("btnDepreAcctFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDepreAcctCode
      '
      Me.Validator.SetDataType(Me.txtDepreAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDepreAcctCode, "")
      Me.txtDepreAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDepreAcctCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreAcctCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreAcctCode, System.Drawing.Color.Empty)
      Me.txtDepreAcctCode.Location = New System.Drawing.Point(136, 240)
      Me.txtDepreAcctCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtDepreAcctCode, "")
      Me.Validator.SetMinValue(Me.txtDepreAcctCode, "")
      Me.txtDepreAcctCode.Name = "txtDepreAcctCode"
      Me.Validator.SetRegularExpression(Me.txtDepreAcctCode, "")
      Me.Validator.SetRequired(Me.txtDepreAcctCode, True)
      Me.txtDepreAcctCode.Size = New System.Drawing.Size(112, 21)
      Me.txtDepreAcctCode.TabIndex = 8
      Me.txtDepreAcctCode.Text = ""
      '
      'lblDepreAcct
      '
      Me.lblDepreAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDepreAcct.ForeColor = System.Drawing.Color.Black
      Me.lblDepreAcct.Location = New System.Drawing.Point(8, 232)
      Me.lblDepreAcct.Name = "lblDepreAcct"
      Me.lblDepreAcct.Size = New System.Drawing.Size(128, 32)
      Me.lblDepreAcct.TabIndex = 16
      Me.lblDepreAcct.Text = "ผังบัญชี ค่าเสื่อมราคา:"
      Me.lblDepreAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnDepreAcctEdit
      '
      Me.btnDepreAcctEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDepreAcctEdit.Image = CType(resources.GetObject("btnDepreAcctEdit.Image"), System.Drawing.Image)
      Me.btnDepreAcctEdit.Location = New System.Drawing.Point(480, 240)
      Me.btnDepreAcctEdit.Name = "btnDepreAcctEdit"
      Me.btnDepreAcctEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDepreAcctEdit.TabIndex = 21
      Me.btnDepreAcctEdit.TabStop = False
      Me.btnDepreAcctEdit.ThemedImage = CType(resources.GetObject("btnDepreAcctEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDepreAcctName
      '
      Me.Validator.SetDataType(Me.txtDepreAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDepreAcctName, "")
      Me.txtDepreAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDepreAcctName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreAcctName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreAcctName, System.Drawing.Color.Empty)
      Me.txtDepreAcctName.Location = New System.Drawing.Point(248, 240)
      Me.Validator.SetMaxValue(Me.txtDepreAcctName, "")
      Me.Validator.SetMinValue(Me.txtDepreAcctName, "")
      Me.txtDepreAcctName.Name = "txtDepreAcctName"
      Me.txtDepreAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDepreAcctName, "")
      Me.Validator.SetRequired(Me.txtDepreAcctName, False)
      Me.txtDepreAcctName.Size = New System.Drawing.Size(208, 21)
      Me.txtDepreAcctName.TabIndex = 18
      Me.txtDepreAcctName.TabStop = False
      Me.txtDepreAcctName.Text = ""
      '
      'btnDepreOpeningAcctEdit
      '
      Me.btnDepreOpeningAcctEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDepreOpeningAcctEdit.Image = CType(resources.GetObject("btnDepreOpeningAcctEdit.Image"), System.Drawing.Image)
      Me.btnDepreOpeningAcctEdit.Location = New System.Drawing.Point(480, 216)
      Me.btnDepreOpeningAcctEdit.Name = "btnDepreOpeningAcctEdit"
      Me.btnDepreOpeningAcctEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDepreOpeningAcctEdit.TabIndex = 19
      Me.btnDepreOpeningAcctEdit.TabStop = False
      Me.btnDepreOpeningAcctEdit.ThemedImage = CType(resources.GetObject("btnDepreOpeningAcctEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDepreOpeningAcctName
      '
      Me.Validator.SetDataType(Me.txtDepreOpeningAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctName, "")
      Me.txtDepreOpeningAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDepreOpeningAcctName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreOpeningAcctName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreOpeningAcctName, System.Drawing.Color.Empty)
      Me.txtDepreOpeningAcctName.Location = New System.Drawing.Point(248, 216)
      Me.Validator.SetMaxValue(Me.txtDepreOpeningAcctName, "")
      Me.Validator.SetMinValue(Me.txtDepreOpeningAcctName, "")
      Me.txtDepreOpeningAcctName.Name = "txtDepreOpeningAcctName"
      Me.txtDepreOpeningAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDepreOpeningAcctName, "")
      Me.Validator.SetRequired(Me.txtDepreOpeningAcctName, False)
      Me.txtDepreOpeningAcctName.Size = New System.Drawing.Size(208, 21)
      Me.txtDepreOpeningAcctName.TabIndex = 13
      Me.txtDepreOpeningAcctName.TabStop = False
      Me.txtDepreOpeningAcctName.Text = ""
      '
      'btnDepreOpeningAcctFind
      '
      Me.btnDepreOpeningAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDepreOpeningAcctFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDepreOpeningAcctFind.Image = CType(resources.GetObject("btnDepreOpeningAcctFind.Image"), System.Drawing.Image)
      Me.btnDepreOpeningAcctFind.Location = New System.Drawing.Point(456, 216)
      Me.btnDepreOpeningAcctFind.Name = "btnDepreOpeningAcctFind"
      Me.btnDepreOpeningAcctFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDepreOpeningAcctFind.TabIndex = 18
      Me.btnDepreOpeningAcctFind.TabStop = False
      Me.btnDepreOpeningAcctFind.ThemedImage = CType(resources.GetObject("btnDepreOpeningAcctFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDepreOpeningAcctCode
      '
      Me.Validator.SetDataType(Me.txtDepreOpeningAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctCode, "")
      Me.txtDepreOpeningAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDepreOpeningAcctCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreOpeningAcctCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreOpeningAcctCode, System.Drawing.Color.Empty)
      Me.txtDepreOpeningAcctCode.Location = New System.Drawing.Point(136, 216)
      Me.txtDepreOpeningAcctCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtDepreOpeningAcctCode, "")
      Me.Validator.SetMinValue(Me.txtDepreOpeningAcctCode, "")
      Me.txtDepreOpeningAcctCode.Name = "txtDepreOpeningAcctCode"
      Me.Validator.SetRegularExpression(Me.txtDepreOpeningAcctCode, "")
      Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, True)
      Me.txtDepreOpeningAcctCode.Size = New System.Drawing.Size(112, 21)
      Me.txtDepreOpeningAcctCode.TabIndex = 7
      Me.txtDepreOpeningAcctCode.Text = ""
      '
      'txtDetail
      '
      Me.Validator.SetDataType(Me.txtDetail, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDetail, "")
      Me.txtDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDetail, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDetail, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDetail, System.Drawing.Color.Empty)
      Me.txtDetail.Location = New System.Drawing.Point(136, 120)
      Me.txtDetail.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtDetail, "")
      Me.Validator.SetMinValue(Me.txtDetail, "")
      Me.txtDetail.Multiline = True
      Me.txtDetail.Name = "txtDetail"
      Me.Validator.SetRegularExpression(Me.txtDetail, "")
      Me.Validator.SetRequired(Me.txtDetail, False)
      Me.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDetail.Size = New System.Drawing.Size(344, 42)
      Me.txtDetail.TabIndex = 4
      Me.txtDetail.Text = ""
      '
      'lblDetail
      '
      Me.lblDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDetail.ForeColor = System.Drawing.Color.Black
      Me.lblDetail.Location = New System.Drawing.Point(8, 120)
      Me.lblDetail.Name = "lblDetail"
      Me.lblDetail.Size = New System.Drawing.Size(128, 18)
      Me.lblDetail.TabIndex = 42
      Me.lblDetail.Text = "รายละเอียด:"
      Me.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'AssetDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "AssetDetailView"
      Me.Size = New System.Drawing.Size(808, 560)
      Me.grbDetail.ResumeLayout(False)
      Me.grbStatus.ResumeLayout(False)
      Me.grbBuyDetail.ResumeLayout(False)
      Me.grbCalcDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))

            Me.lblDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDetail}")
            Me.Validator.SetDisplayName(Me.txtDetail, StringHelper.GetRidOfAtEnd(Me.lblDetail.Text, ":"))

            ' 
            Me.lblGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblGl}")
            Me.Validator.SetDisplayName(Me.txtGLCode, StringHelper.GetRidOfAtEnd(Me.lblGl.Text, ":"))


            Me.lblDepreOpeningAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreOpeningAcct}")
            Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreOpeningAcct.Text, ":"))

            Me.lblDepreAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreAcct}")
            Me.Validator.SetDisplayName(Me.txtDepreAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreAcct.Text, ":"))

            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblType}")
            Me.Validator.SetDisplayName(Me.txtTypeCode, StringHelper.GetRidOfAtEnd(Me.lblType.Text, ":"))

            Me.lblCostcenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCostcenter}")
            Me.Validator.SetDisplayName(Me.txtCostcenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostcenter.Text, ":"))

            Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblLocation}")
            Me.Validator.SetDisplayName(Me.txtLocation, StringHelper.GetRidOfAtEnd(Me.lblLocation.Text, ":"))

            Me.lblCalcRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCalcRate}")
            Me.Validator.SetDisplayName(Me.txtCalcRate, StringHelper.GetRidOfAtEnd(Me.lblCalcRate.Text, ":"))

            Me.lblEndCalcDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblEndCalcDate}")
            Me.Validator.SetDisplayName(Me.txtEndCalcDate, StringHelper.GetRidOfAtEnd(Me.lblEndCalcDate.Text, ":"))

            Me.lblAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAge}")
            Me.Validator.SetDisplayName(Me.txtAge, StringHelper.GetRidOfAtEnd(Me.lblAge.Text, ":"))

            Me.lblStartCalcAmnt.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblStartCalcAmnt}")
            Me.Validator.SetDisplayName(Me.txtStartCalcAmt, StringHelper.GetRidOfAtEnd(Me.lblStartCalcAmnt.Text, ":"))


            Me.lblCalcType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblCalcType}")
            Me.Validator.SetDisplayName(Me.txtCalcRate, StringHelper.GetRidOfAtEnd(Me.lblCalcType.Text, ":"))



            Me.lblAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAge}")
            Me.Validator.SetDisplayName(txtAge, lblAge.Text)

            Me.lblRent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRent}")
            Me.Validator.SetDisplayName(txtRent, lblRent.Text)
            Me.lblDateInval.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDateInval}")

            Me.lblStartCalcDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblStartCalcDate}")
            Me.Validator.SetDisplayName(txtStartCalcDate, lblStartCalcDate.Text)

            Me.lblBuyPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyPrice}")
            Me.Validator.SetDisplayName(txtBuyPrice, lblBuyPrice.Text)

            Me.lblBuyDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDate}")
            Me.Validator.SetDisplayName(txtBuyDate, lblBuyDate.Text)

            Me.lblTransferDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblTransferDate}")
            Me.Validator.SetDisplayName(txtTransferDate, lblTransferDate.Text)

            Me.lblBuyFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyFrom}")
            Me.Validator.SetDisplayName(txtBuyFrom, lblBuyFrom.Text)

            Me.lblBuyDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDocCode}")
            Me.Validator.SetDisplayName(txtBuyDocCode, lblBuyDocCode.Text)

            Me.lblBuyDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyDocDate}")
            Me.Validator.SetDisplayName(txtBuyDocDate, lblBuyDocDate.Text)

            Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblYear}")
            Me.lblYear1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblYear1}")

            Me.lblSavage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblSavage}")
            Me.Validator.SetDisplayName(txtSalvage, lblSavage.Text)

            Me.lblRemainingValue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRemainingValue}")
            Me.Validator.SetDisplayName(txtRemainingValue, lblRemainingValue.Text)

            Me.lblDepreOpenning.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreOpenning}")
            Me.Validator.SetDisplayName(txtDepreOpenning, lblDepreOpenning.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.ToolTip1.SetToolTip(Me.btnLoadImage, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnLoadImage}"))
            Me.ToolTip1.SetToolTip(Me.btnClearImage, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnClearImage}"))
            Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")
            Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")

            Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency4.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency5.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

            Me.lblAssetStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAssetStatus}")

            Me.grbStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbStatus}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbDetail}")
            Me.grbCalcDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbCalcDetail}")
            Me.grbBuyDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbBuyDetail}")

            Me.chkCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkCancel}")
            Me.chkDecay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkDecay}")


        End Sub
#End Region

#Region "Member"
        Private m_entity As Asset
        Private m_isInitialized As Boolean = False

#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.Initialize()

            Me.EventWiring()
            Me.SetLabelText()

            Me.UpdateEntityProperties()

        End Sub
#End Region

#Region "Method"
        Public Overrides Sub Initialize()
            ' กำหนดการคำนวณค่าเสื่อมราคา
            AssetCalcType.ListCodeDescriptionInComboBox(cmbCalcType, "asset_calctype")
            ' กำหนดอัตราค่าเช่าพื้นฐาน
        End Sub
        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            Me.m_isInitialized = False
            If m_entity Is Nothing Then
                ClearDetail()
                Return
            End If

            txtCode.Text = Me.m_entity.Code
            txtName.Text = Me.m_entity.Name
            txtDetail.Text = Me.m_entity.Detail
            ' autogencode
            Me.m_oldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            If Not Me.m_entity.Account Is Nothing Then
                txtGLCode.Text = Me.m_entity.Account.Code
                txtGLName.Text = Me.m_entity.Account.Name
            End If
            If Not Me.m_entity.DepreOpeningAccount Is Nothing Then
                txtDepreOpeningAcctCode.Text = Me.m_entity.DepreOpeningAccount.Code
                txtDepreOpeningAcctName.Text = Me.m_entity.DepreOpeningAccount.Name
            End If
            If Not Me.m_entity.DepreAccount Is Nothing Then
                txtDepreAcctCode.Text = Me.m_entity.DepreAccount.Code
                txtDepreAcctName.Text = Me.m_entity.DepreAccount.Name
            End If

            If Not Me.m_entity.Costcenter Is Nothing Then
                txtCostcenterCode.Text = Me.m_entity.Costcenter.Code
                txtCostcenterName.Text = Me.m_entity.Costcenter.Name
            End If
            If Not Me.m_entity.Type Is Nothing Then
                txtTypeCode.Text = Me.m_entity.Type.Code
                txtTypeName.Text = Me.m_entity.Type.Name
            End If

            txtLocation.Text = Me.m_entity.Location
            txtNote.Text = Me.m_entity.Note
            txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Qty)

            ' cmbCalcType.SelectedIndex = Me.m_entity.CalcType.Value
            For Each item As IdValuePair In Me.cmbCalcType.Items
                If Me.m_entity.CalcType Is item Then
                    Me.cmbCalcType.SelectedItem = item
                    Exit For
                End If
            Next

            Me.lblCurrentStatus.Text = Me.m_entity.Status.Description

            txtAge.Text = Configuration.FormatToString(Me.m_entity.Age, DigitConfig.Int)
            ' วันที่เริ่มคำนวณค่าเสื่อม
            txtStartCalcDate.Text = MinDateToNull(Me.m_entity.StartCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpStartCalcDate.Value = MinDateToNow(Me.m_entity.StartCalcDate)
            ' วันที่สิ้นสุดคำนวณค่าเสื่อม
            txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            ' ค่าการคำนวณ
            txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Price)
            txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
            txtSalvage.Text = Configuration.FormatToString(Me.m_entity.Salvage, DigitConfig.Price)
            ' ค่าอัตโนมัติ
            txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
            txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)
            ' วันที่ซื้อ
            txtBuyDate.Text = MinDateToNull(Me.m_entity.BuyDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpBuyDate.Value = MinDateToNow(Me.m_entity.BuyDate)
            ' วันที่ยกค่าเสื่อมมา
            txtTransferDate.Text = MinDateToNull(Me.m_entity.TransferDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpTransferDate.Value = MinDateToNow(Me.m_entity.TransferDate)

            txtBuyPrice.Text = Configuration.FormatToString(Me.m_entity.BuyPrice, DigitConfig.Price)
            txtBuyDocCode.Text = Me.m_entity.BuyDocCode
            ' วันที่ซื้อในเอกสาร
            txtBuyDocDate.Text = MinDateToNull(Me.m_entity.BuyDocDate, "")
            dtpBuyDocDate.Value = MinDateToNow(Me.m_entity.BuyDocDate)

            txtBuyFrom.Text = Me.m_entity.BuyFrom

            picImage.Image = Me.m_entity.Image
            CheckLabelImgSize()

            chkCancel.Checked = Me.m_entity.Canceled
            If Me.m_entity.Status.Value = 4 Then   ' ชำรุด
                chkDecay.Checked = True
            Else
                chkDecay.Checked = False
            End If

            SetLabelText()
            CheckFormEnable()
            Me.m_isInitialized = True
        End Sub

        Protected Overrides Sub EventWiring()
            ' สถานะสินทรัพย์
            AddHandler chkCancel.CheckedChanged, AddressOf Me.ChangeStatus
            AddHandler chkDecay.CheckedChanged, AddressOf Me.ChangeStatus

            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDetail.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtGLCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDepreOpeningAcctCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDepreAcctCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtCostcenterCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtTypeCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtLocation.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler cmbCalcType.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtAge.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtStartCalcDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpStartCalcDate.ValueChanged, AddressOf Me.ChangeProperty

            'AddHandler txtCalcRate.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtStartCalcAmt.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSalvage.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDepreOpenning.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtRemainingValue.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtTransferDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpTransferDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtBuyDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpBuyDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtBuyPrice.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBuyDocCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtBuyDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpBuyDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtBuyFrom.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtRent.TextChanged, AddressOf Me.ChangeProperty

            ' numeric format  
            AddHandler txtRent.Validated, AddressOf Me.NumerberTextBoxChange
            AddHandler txtAge.Validated, AddressOf Me.NumerberTextBoxChange
            AddHandler txtCalcRate.Validated, AddressOf Me.NumerberTextBoxChange

            AddHandler txtStartCalcAmt.Validated, AddressOf Me.NumerberTextBoxChange
            AddHandler txtDepreOpenning.Validated, AddressOf Me.NumerberTextBoxChange

            AddHandler txtSalvage.Validated, AddressOf Me.NumerberTextBoxChange
            AddHandler txtBuyPrice.Validated, AddressOf Me.NumerberTextBoxChange

            ' SetDefault value  
            AddHandler cmbCalcType.SelectedIndexChanged, AddressOf Me.SetValue
            AddHandler txtAge.Validated, AddressOf Me.SetValue
            AddHandler txtStartCalcAmt.Validated, AddressOf Me.SetValue
            AddHandler dtpStartCalcDate.Validated, AddressOf Me.SetValue

            AddHandler txtStartCalcAmt.Validated, AddressOf Me.SetValue
            AddHandler txtDepreOpenning.Validated, AddressOf Me.SetValue

            AddHandler txtSalvage.Validated, AddressOf Me.SetValue
            AddHandler txtBuyPrice.Validated, AddressOf Me.SetValue

        End Sub
        Public Sub ChangeStatus(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "chkcancel"
                    Me.m_entity.Canceled = chkCancel.Checked
                    dirtyFlag = True
                Case "chkdecay"
                    If chkDecay.Checked Then
                        Me.m_entity.Status.Value = 4
                    Else
                        Me.m_entity.Status.Value = 2
                    End If
                    dirtyFlag = True
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetValueFromAssetType()
            If Not Me.m_entity.Type Is Nothing _
            AndAlso Not Me.m_entity.Type.DepreAble Then
                'txtUnitCode.Enabled = False
                'txtUnitName.Enabled = False
                'btnUnitEdit.Enabled = False
                'btnUnitFind.Enabled = False
                'txtUnitCode.Text = Me.m_entity.Type.Unit.Code
                'txtUnitName.Text = Me.m_entity.Type.Unit.Name
            Else
                ''txtUnitCode.Text = ""
                ''txtUnitName.Text = ""
                'txtUnitCode.Enabled = True
                'txtUnitName.Enabled = True
                'btnUnitEdit.Enabled = True
                'btnUnitFind.Enabled = True
            End If
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            If Not Me.m_entity.Account Is Nothing Then
                txtGLCode.Text = Me.m_entity.Account.Code
                txtGLName.Text = Me.m_entity.Account.Name
            End If
            If Not Me.m_entity.DepreOpeningAccount Is Nothing Then
                txtDepreOpeningAcctCode.Text = Me.m_entity.DepreOpeningAccount.Code
                txtDepreOpeningAcctName.Text = Me.m_entity.DepreOpeningAccount.Name
            End If
            If Not Me.m_entity.DepreAccount Is Nothing Then
                txtDepreAcctCode.Text = Me.m_entity.DepreAccount.Code
                txtDepreAcctName.Text = Me.m_entity.DepreAccount.Name
            End If
            Me.m_isInitialized = flag
        End Sub
        Public Sub NumerberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtrent"
                    txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Price)
                Case "txtage"
                    txtAge.Text = Configuration.FormatToString(Me.m_entity.Age, DigitConfig.Int)
                Case "txtcalcrate"
                    txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
                Case "txtstartcalcamt"
                    txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
                Case "txtsalvage"
                    txtSalvage.Text = Configuration.FormatToString(Me.m_entity.Salvage, DigitConfig.Price)
                Case "txtdepreopenning"
                    txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
                Case "txtremainingvalue"
                    txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)

                Case "txtbuyprice"
                    txtBuyPrice.Text = Configuration.FormatToString(Me.m_entity.BuyPrice, DigitConfig.Price)
            End Select
        End Sub
        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Dim tmpFlag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True
                Case "txtdetail"
                    Me.m_entity.Detail = txtDetail.Text
                    dirtyFlag = True

                Case "txtglcode"
                    dirtyFlag = Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
                Case "txtdepreopeningacctcode"
                    dirtyFlag = Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
                Case "txtdepreacctcode"
                    dirtyFlag = Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
                Case "txtcostcentercode"
                    dirtyFlag = CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_entity.Costcenter)
                Case "txttypecode"
                    dirtyFlag = AssetType.GetAssetType(txtTypeCode, txtTypeName, Me.m_entity.Type)
                    Me.SetValueFromAssetType()
                Case "txtlocation"
                    Me.m_entity.Location = txtLocation.Text
                    dirtyFlag = True

                Case "txtrent"
                    If txtRent.TextLength > 0 Then
                        Me.m_entity.RentalRate = CDec(txtRent.Text)
                    Else
                        Me.m_entity.RentalRate = Nothing
                    End If
                    dirtyFlag = True

                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "cmbcalctype"
                    Dim idPair As IdValuePair = CType(Me.cmbCalcType.SelectedItem, IdValuePair)
                    Me.m_entity.CalcType.Value = idPair.Id
                    Me.m_entity.CalcType.Description = idPair.Value
                    dirtyFlag = True

                Case "txtage"
                    If txtAge.TextLength > 0 AndAlso Me.Validator.GetErrorMessage(txtAge).Length = 0 Then
                        Me.m_entity.Age = CInt(txtAge.Text)
                    Else
                        Me.m_entity.Age = Nothing
                    End If
                    dirtyFlag = True

                Case "dtpstartcalcdate"
                    If Not Me.m_entity.StartCalcDate.Equals(dtpStartCalcDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtStartCalcDate.Text = MinDateToNull(dtpStartCalcDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtstartcalcdate"
                    m_dateSetting = True
                    If Not Me.txtStartCalcDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartCalcDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtStartCalcDate.Text)
                        If Not Me.m_entity.StartCalcDate.Equals(theDate) Then
                            dtpStartCalcDate.Value = theDate
                            Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpStartCalcDate.Value = Date.Now
                        Me.m_entity.StartCalcDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "txtstartcalcamt"
                    If txtStartCalcAmt.TextLength > 0 Then
                        Me.m_entity.StartCalcAmt = CDec(txtStartCalcAmt.Text)
                    Else
                        Me.m_entity.StartCalcAmt = Nothing
                    End If
                    txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
                    dirtyFlag = True

                Case "txtdepreopenning"
                    If txtDepreOpenning.TextLength > 0 Then
                        Me.m_entity.DepreOpening = CDec(txtDepreOpenning.Text)
                    Else
                        Me.m_entity.DepreOpening = Nothing
                    End If
                    txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
                    dirtyFlag = True

                Case "dtptransferdate"
                    If Not Me.m_entity.TransferDate.Equals(dtpTransferDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtTransferDate.Text = MinDateToNull(dtpTransferDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.TransferDate = dtpTransferDate.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txttransferdate"
                    m_dateSetting = True
                    If Not Me.txtTransferDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtTransferDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtTransferDate.Text)
                        If Not Me.m_entity.TransferDate.Equals(theDate) Then
                            dtpTransferDate.Value = theDate
                            Me.m_entity.TransferDate = dtpTransferDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpTransferDate.Value = Date.Now
                        Me.m_entity.TransferDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "dtpbuydate"
                    If Not Me.m_entity.BuyDate.Equals(dtpBuyDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtBuyDate.Text = MinDateToNull(dtpBuyDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.BuyDate = dtpBuyDate.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtbuydate"
                    m_dateSetting = True
                    If Not Me.txtBuyDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBuyDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtBuyDate.Text)
                        If Not Me.m_entity.BuyDate.Equals(theDate) Then
                            dtpBuyDate.Value = theDate
                            Me.m_entity.BuyDate = dtpBuyDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpBuyDate.Value = Date.Now
                        Me.m_entity.BuyDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "txtbuyprice"
                    dirtyFlag = True
                    If txtBuyPrice.TextLength > 0 Then
                        Me.m_entity.BuyPrice = CDec(txtBuyPrice.Text)
                    Else
                        Me.m_entity.BuyPrice = Nothing
                    End If

                Case "txtbuydoccode"
                    Me.m_entity.BuyDocCode = txtBuyDocCode.Text
                    dirtyFlag = True

                Case "txtbuydocdate"
                    Dim dt As DateTime = StringToDate(txtBuyDocDate, dtpBuyDocDate)
                    Me.m_entity.BuyDocDate = dt
                    dirtyFlag = True

                Case "dtpbuydocdate"
                    txtBuyDocDate.Text = MinDateToNull(dtpBuyDocDate.Value, "")
                    Me.m_entity.BuyDocDate = dtpBuyDocDate.Value
                    dirtyFlag = True

                Case "txtbuyfrom"
                    Me.m_entity.BuyFrom = txtBuyFrom.Text
                    dirtyFlag = True

                Case "txtsalvage"
                    If txtSalvage.TextLength > 0 Then
                        Me.m_entity.Salvage = CDec(txtSalvage.Text)
                    Else
                        Me.m_entity.Salvage = Nothing
                    End If
                    dirtyFlag = True

            End Select
            Me.m_isInitialized = tmpFlag
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()
        End Sub
        Private Sub CalcDepreEndCalcDate()
            txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        End Sub
        Private Sub CalcDepreCalcRate()
            txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
        End Sub
        Private Sub SetValue(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
                Return
            End If
            ' คำนวณค่าเริ่มต้นที่สำคัญ
            Select Case CType(sender, Control).Name.ToLower
                ' คำนวณเกี่ยวกับวันที่เริ่มต้น
            Case "cmbcalctype"
                    CalcDepreEndCalcDate()
                    CalcDepreCalcRate()
                Case "txtage"
                    CalcDepreEndCalcDate()
                    CalcDepreCalcRate()

                Case "txtstartcalcdate"
                    CalcDepreEndCalcDate()

                Case "dtpstartcalcdate"
                    CalcDepreEndCalcDate()

                Case "txtsalvage", "txtbuyprice", "txtdepreopenning", "txtstartcalcamt"
                    txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)
            End Select
        End Sub
#End Region

#Region "IListDetail"
        Private Sub CheckIsDepreciated(ByVal flag As Boolean)
            ' ผังบัญชี
            txtGLCode.Enabled = Not flag
            txtGLName.Enabled = Not flag
            btnGLEdit.Enabled = Not flag
            btnGLFind.Enabled = Not flag
            ' ผังบัญชีค่าเสื่อมสะสม
            txtDepreOpeningAcctCode.Enabled = Not flag
            txtDepreOpeningAcctName.Enabled = Not flag
            btnDepreOpeningAcctEdit.Enabled = Not flag
            btnDepreOpeningAcctFind.Enabled = Not flag
            ' ผังบัญชีค่าเสื่อม
            txtDepreAcctCode.Enabled = Not flag
            txtDepreAcctName.Enabled = Not flag
            btnDepreAcctEdit.Enabled = Not flag
            btnDepreAcctFind.Enabled = Not flag
            ' cost center
            txtCostcenterCode.Enabled = Not flag
            txtCostcenterName.Enabled = Not flag
            btnCostcenterEdit.Enabled = Not flag
            btnCostcenterFind.Enabled = Not flag
            ' การคำนวณ
            grbCalcDetail.Enabled = Not flag
            ' การซื้อ 
            grbBuyDetail.Enabled = Not flag
        End Sub

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            ' Protected from ...
            If Me.m_entity.Canceled OrElse (Me.m_entity.Status.Value <> 1 AndAlso Me.m_entity.Status.Value <> -1) Then
                For Each crlt As Control In grbDetail.Controls
                    If Not TypeOf crlt Is FixedGroupBox Then
                        crlt.Enabled = False
                    End If
                Next
                For Each crlt As Control In grbStatus.Controls
                    crlt.Enabled = False
                Next
                grbCalcDetail.Enabled = False
                grbBuyDetail.Enabled = False
                chkCancel.Enabled = True
            Else
                For Each crlt As Control In grbDetail.Controls
                    crlt.Enabled = True
                Next
                For Each ctrl As Control In grbStatus.Controls
                    ctrl.Enabled = True
                Next
                grbCalcDetail.Enabled = True
                grbBuyDetail.Enabled = True
                ' กำหนด columns ที่ต้องการ protect เมื่อมีการคำนวณค่าเสื่อม
                CheckIsDepreciated(Me.m_entity.IsDepreciated)

            End If

            SetValueFromAssetType()
        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()
            For Each ctrl As Control In grbDetail.Controls
                If TypeOf ctrl Is FixedGroupBox OrElse TypeOf ctrl Is GroupBox Then
                    For Each child As Control In ctrl.Controls
                        If TypeOf child Is TextBox Then
                            child.Text = ""
                        End If
                    Next
                ElseIf TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            cmbCalcType.SelectedIndex = 0

            txtStartCalcDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpStartCalcDate.Value = Date.Now

            txtEndCalcDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            txtTransferDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpTransferDate.Value = Date.Now

            txtBuyDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpBuyDate.Value = Date.Now

            txtBuyDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpBuyDocDate.Value = Date.Now

            Me.picImage.Image = Nothing

        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)

                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, Asset)
                    Me.m_entity.LoadImage()
                End If

                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)


                UpdateEntityProperties()
            End Set
        End Property



#End Region

#Region " IValidatable "
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Image button"
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

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Account).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtglcode", "txtglname"
                                Return True
                            Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
                                Return True
                            Case "txtdepreacctcode", "txtdepreacctname"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New Unit).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtunitcode", "txtunitname"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New AssetType).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txttypecode", "txttypename"
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
            If data.GetDataPresent((New Account).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
                Dim entity As New Account(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtglcode", "txtglname"
                            Me.SetAccountDialog(entity)
                        Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
                            Me.SetDepreOpeningAccountDialog(entity)
                        Case "txtdepreacctcode", "txtdepreacctname"
                            Me.SetDepreAccountDialog(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New AssetType).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AssetType).FullClassName))
                Dim entity As New AssetType(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txttypecode", "txttypename"
                            Me.SetAssetTypeDialog(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercode", "txtcostcentername"
                            Me.SetCostCenterDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "Event of Button controls"
        ' Account button
        Private Sub btnGLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGLEdit.Click, btnDepreAcctEdit.Click, btnDepreOpeningAcctEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Account)
        End Sub
        Private Sub btnGLFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGLFind.Click, btnDepreAcctFind.Click, btnDepreOpeningAcctFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnglfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
                Case "btndepreopeningacctfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreOpeningAccountDialog)
                Case "btndepreacctfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreAccountDialog)
            End Select
        End Sub
        Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
            Me.txtGLCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
        End Sub
        Private Sub SetDepreOpeningAccountDialog(ByVal e As ISimpleEntity)
            Me.txtDepreOpeningAcctCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
        End Sub
        Private Sub SetDepreAccountDialog(ByVal e As ISimpleEntity)
            Me.txtDepreAcctCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
        End Sub
        ' Type button
        Private Sub btnTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTypeEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New AssetType)
        End Sub
        Private Sub btnTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTypeFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeDialog)
        End Sub
        Private Sub SetAssetTypeDialog(ByVal e As ISimpleEntity)
            Me.txtTypeCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or AssetType.GetAssetType(txtTypeCode, txtTypeName, Me.m_entity.Type)
            SetValueFromAssetType()
        End Sub

        ' Costcenter button
        Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostcenterEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostcenterFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog)
        End Sub
        Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtCostcenterCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_entity.Costcenter)
        End Sub

        ' More detail
        Private Sub btnAssetAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetAuxDetail.Click
            Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.AssetAuxDetail
            myAuxPanel.Entity = Me.m_entity
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
            If myDialog.ShowDialog() = DialogResult.Cancel Then
                Me.WorkbenchWindow.ViewContent.IsDirty = False
            End If
        End Sub
#End Region

#Region " Autogencode "
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

        Private Sub CheckLabelImgSize()
            Me.lblPicSize.Text = "272 X 204 pixel"
            If Me.m_entity.Image Is Nothing Then
                Me.lblPicSize.Visible = True
            Else
                Me.lblPicSize.Visible = False
            End If
        End Sub

    End Class

End Namespace
