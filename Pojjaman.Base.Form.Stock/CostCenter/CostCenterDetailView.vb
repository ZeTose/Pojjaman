Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CostCenterDetailView
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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblManager As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblAdmin As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents lblFax As System.Windows.Forms.Label
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents txtManager As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents txtAdmin As System.Windows.Forms.TextBox
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtFax As System.Windows.Forms.TextBox
        Friend WithEvents txtAdminName As System.Windows.Forms.TextBox
        Friend WithEvents txtManagerName As System.Windows.Forms.TextBox
        Friend WithEvents lblParent As System.Windows.Forms.Label
        Friend WithEvents txtParent As System.Windows.Forms.TextBox
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents ImagebtnProjectSetUp As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImagebtnWBSSetUp As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnShowManager As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowManagerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowAdmin As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowAdminDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtWipAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblStoreAcct As System.Windows.Forms.Label
        Friend WithEvents txtStoreAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblWipAcct As System.Windows.Forms.Label
        Friend WithEvents ibtnShowWipAcct As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowStoreAcct As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowStoreAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowWipAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtWipAcctName As System.Windows.Forms.TextBox
        Friend WithEvents txtStoreAcctName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowExpenseAcct As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowExpenseAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtExpenseAcctName As System.Windows.Forms.TextBox
        Friend WithEvents lblExpenseAcct As System.Windows.Forms.Label
        Friend WithEvents txtExpenseAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents cmbCCType As System.Windows.Forms.ComboBox
        Friend WithEvents lblCCType As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblBOQ As System.Windows.Forms.Label
        Friend WithEvents ibnShowBOQDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
        Friend WithEvents chkcancle As System.Windows.Forms.CheckBox
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLoadMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnShowMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblPicSize As System.Windows.Forms.Label
        Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnCashFlow As System.Windows.Forms.Button
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostCenterDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.picImage = New System.Windows.Forms.PictureBox()
      Me.chkActive = New System.Windows.Forms.CheckBox()
      Me.lblPicSize = New System.Windows.Forms.Label()
      Me.btnLoadMap = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearMap = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkcancle = New System.Windows.Forms.CheckBox()
      Me.lblBOQ = New System.Windows.Forms.Label()
      Me.ibnShowBOQDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBOQCode = New System.Windows.Forms.TextBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.cmbCCType = New System.Windows.Forms.ComboBox()
      Me.ibtnShowManager = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowManagerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblParent = New System.Windows.Forms.Label()
      Me.txtParent = New System.Windows.Forms.TextBox()
      Me.lblPhone = New System.Windows.Forms.Label()
      Me.txtAdmin = New System.Windows.Forms.TextBox()
      Me.lblManager = New System.Windows.Forms.Label()
      Me.txtManager = New System.Windows.Forms.TextBox()
      Me.lblAdmin = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtPhone = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.lblFax = New System.Windows.Forms.Label()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.txtAdminName = New System.Windows.Forms.TextBox()
      Me.txtManagerName = New System.Windows.Forms.TextBox()
      Me.lblCCType = New System.Windows.Forms.Label()
      Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.pnlPicHolder = New System.Windows.Forms.Panel()
      Me.picMap = New System.Windows.Forms.PictureBox()
      Me.ibtnShowAdmin = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowAdminDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWipAcctCode = New System.Windows.Forms.TextBox()
      Me.lblStoreAcct = New System.Windows.Forms.Label()
      Me.txtStoreAcctCode = New System.Windows.Forms.TextBox()
      Me.lblWipAcct = New System.Windows.Forms.Label()
      Me.ibtnShowWipAcct = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowStoreAcct = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowStoreAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowWipAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWipAcctName = New System.Windows.Forms.TextBox()
      Me.txtStoreAcctName = New System.Windows.Forms.TextBox()
      Me.ibtnShowExpenseAcct = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowExpenseAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtExpenseAcctName = New System.Windows.Forms.TextBox()
      Me.lblExpenseAcct = New System.Windows.Forms.Label()
      Me.txtExpenseAcctCode = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.btnShowMap = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.btnCashFlow = New System.Windows.Forms.Button()
      Me.grbDetail.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbMap.SuspendLayout()
      Me.pnlPicHolder.SuspendLayout()
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(848, 536)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลหลัก :"
      Me.ToolTip1.SetToolTip(Me.grbDetail, "ข้อมูลไซต์งาน:")
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(520, 448)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 212
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(520, 472)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 211
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.btnCashFlow)
      Me.grbMainDetail.Controls.Add(Me.picImage)
      Me.grbMainDetail.Controls.Add(Me.chkActive)
      Me.grbMainDetail.Controls.Add(Me.lblPicSize)
      Me.grbMainDetail.Controls.Add(Me.btnLoadMap)
      Me.grbMainDetail.Controls.Add(Me.btnClearMap)
      Me.grbMainDetail.Controls.Add(Me.btnLoadImage)
      Me.grbMainDetail.Controls.Add(Me.btnClearImage)
      Me.grbMainDetail.Controls.Add(Me.chkcancle)
      Me.grbMainDetail.Controls.Add(Me.lblBOQ)
      Me.grbMainDetail.Controls.Add(Me.ibnShowBOQDialog)
      Me.grbMainDetail.Controls.Add(Me.txtBOQCode)
      Me.grbMainDetail.Controls.Add(Me.lblCustomer)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerName)
      Me.grbMainDetail.Controls.Add(Me.cmbCCType)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowManager)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowManagerDialog)
      Me.grbMainDetail.Controls.Add(Me.lblParent)
      Me.grbMainDetail.Controls.Add(Me.txtParent)
      Me.grbMainDetail.Controls.Add(Me.lblPhone)
      Me.grbMainDetail.Controls.Add(Me.txtAdmin)
      Me.grbMainDetail.Controls.Add(Me.lblManager)
      Me.grbMainDetail.Controls.Add(Me.txtManager)
      Me.grbMainDetail.Controls.Add(Me.lblAdmin)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtPhone)
      Me.grbMainDetail.Controls.Add(Me.txtAddress)
      Me.grbMainDetail.Controls.Add(Me.lblFax)
      Me.grbMainDetail.Controls.Add(Me.txtFax)
      Me.grbMainDetail.Controls.Add(Me.lblAddress)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.lblName)
      Me.grbMainDetail.Controls.Add(Me.txtName)
      Me.grbMainDetail.Controls.Add(Me.txtAdminName)
      Me.grbMainDetail.Controls.Add(Me.txtManagerName)
      Me.grbMainDetail.Controls.Add(Me.lblCCType)
      Me.grbMainDetail.Controls.Add(Me.grbMap)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowAdmin)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowAdminDialog)
      Me.grbMainDetail.Controls.Add(Me.txtWipAcctCode)
      Me.grbMainDetail.Controls.Add(Me.lblStoreAcct)
      Me.grbMainDetail.Controls.Add(Me.txtStoreAcctCode)
      Me.grbMainDetail.Controls.Add(Me.lblWipAcct)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowWipAcct)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowStoreAcct)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowStoreAcctDialog)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowWipAcctDialog)
      Me.grbMainDetail.Controls.Add(Me.txtWipAcctName)
      Me.grbMainDetail.Controls.Add(Me.txtStoreAcctName)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowExpenseAcct)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowExpenseAcctDialog)
      Me.grbMainDetail.Controls.Add(Me.txtExpenseAcctName)
      Me.grbMainDetail.Controls.Add(Me.lblExpenseAcct)
      Me.grbMainDetail.Controls.Add(Me.txtExpenseAcctCode)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerCode)
      Me.grbMainDetail.Controls.Add(Me.btnShowMap)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowCustomer)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowCustomerDialog)
      Me.grbMainDetail.Controls.Add(Me.chkAutorun)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(832, 400)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียด Cost Center:"
      Me.ToolTip1.SetToolTip(Me.grbMainDetail, "ข้อมูลทั่วไป:")
      '
      'picImage
      '
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImage.Location = New System.Drawing.Point(288, 152)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(232, 174)
      Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picImage.TabIndex = 12
      Me.picImage.TabStop = False
      '
      'chkActive
      '
      Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkActive.Location = New System.Drawing.Point(104, 267)
      Me.chkActive.Name = "chkActive"
      Me.chkActive.Size = New System.Drawing.Size(223, 24)
      Me.chkActive.TabIndex = 325
      Me.chkActive.Text = "โครงการอยู่ระหว่างก่อสร้าง(Active Project)"
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.Location = New System.Drawing.Point(355, 226)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.Size = New System.Drawing.Size(100, 23)
      Me.lblPicSize.TabIndex = 200
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLoadMap
      '
      Me.btnLoadMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadMap.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadMap.Location = New System.Drawing.Point(752, 368)
      Me.btnLoadMap.Name = "btnLoadMap"
      Me.btnLoadMap.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadMap.TabIndex = 52
      Me.btnLoadMap.TabStop = False
      Me.btnLoadMap.ThemedImage = CType(resources.GetObject("btnLoadMap.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearMap
      '
      Me.btnClearMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearMap.Location = New System.Drawing.Point(800, 368)
      Me.btnClearMap.Name = "btnClearMap"
      Me.btnClearMap.Size = New System.Drawing.Size(24, 23)
      Me.btnClearMap.TabIndex = 53
      Me.btnClearMap.TabStop = False
      Me.btnClearMap.ThemedImage = CType(resources.GetObject("btnClearMap.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnLoadImage
      '
      Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Location = New System.Drawing.Point(472, 328)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 50
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Location = New System.Drawing.Point(496, 328)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 51
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkcancle
      '
      Me.chkcancle.Enabled = False
      Me.chkcancle.ForeColor = System.Drawing.Color.Black
      Me.chkcancle.Location = New System.Drawing.Point(104, 293)
      Me.chkcancle.Name = "chkcancle"
      Me.chkcancle.Size = New System.Drawing.Size(104, 24)
      Me.chkcancle.TabIndex = 49
      Me.chkcancle.Text = "ยกเลิกโครงการ"
      '
      'lblBOQ
      '
      Me.lblBOQ.BackColor = System.Drawing.Color.Transparent
      Me.lblBOQ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBOQ.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBOQ.Location = New System.Drawing.Point(24, 240)
      Me.lblBOQ.Name = "lblBOQ"
      Me.lblBOQ.Size = New System.Drawing.Size(96, 18)
      Me.lblBOQ.TabIndex = 48
      Me.lblBOQ.Text = "Ref BOQ:"
      Me.lblBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibnShowBOQDialog
      '
      Me.ibnShowBOQDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibnShowBOQDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibnShowBOQDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibnShowBOQDialog.Location = New System.Drawing.Point(256, 240)
      Me.ibnShowBOQDialog.Name = "ibnShowBOQDialog"
      Me.ibnShowBOQDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibnShowBOQDialog.TabIndex = 46
      Me.ibnShowBOQDialog.TabStop = False
      Me.ibnShowBOQDialog.ThemedImage = CType(resources.GetObject("ibnShowBOQDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBOQCode
      '
      Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBOQCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.txtBOQCode.Location = New System.Drawing.Point(120, 240)
      Me.Validator.SetMinValue(Me.txtBOQCode, "")
      Me.txtBOQCode.Name = "txtBOQCode"
      Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
      Me.Validator.SetRequired(Me.txtBOQCode, False)
      Me.txtBOQCode.Size = New System.Drawing.Size(136, 21)
      Me.txtBOQCode.TabIndex = 47
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCustomer.Location = New System.Drawing.Point(264, 25)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(48, 20)
      Me.lblCustomer.TabIndex = 25
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(392, 24)
      Me.txtCustomerName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(384, 21)
      Me.txtCustomerName.TabIndex = 27
      Me.txtCustomerName.TabStop = False
      '
      'cmbCCType
      '
      Me.cmbCCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCCType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCCType.ItemHeight = 13
      Me.cmbCCType.Location = New System.Drawing.Point(120, 216)
      Me.cmbCCType.Name = "cmbCCType"
      Me.cmbCCType.Size = New System.Drawing.Size(160, 21)
      Me.cmbCCType.TabIndex = 11
      '
      'ibtnShowManager
      '
      Me.ibtnShowManager.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowManager.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowManager.Location = New System.Drawing.Point(416, 72)
      Me.ibtnShowManager.Name = "ibtnShowManager"
      Me.ibtnShowManager.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowManager.TabIndex = 33
      Me.ibtnShowManager.TabStop = False
      Me.ibtnShowManager.ThemedImage = CType(resources.GetObject("ibtnShowManager.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowManagerDialog
      '
      Me.ibtnShowManagerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowManagerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowManagerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowManagerDialog.Location = New System.Drawing.Point(392, 72)
      Me.ibtnShowManagerDialog.Name = "ibtnShowManagerDialog"
      Me.ibtnShowManagerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowManagerDialog.TabIndex = 30
      Me.ibtnShowManagerDialog.TabStop = False
      Me.ibtnShowManagerDialog.ThemedImage = CType(resources.GetObject("ibtnShowManagerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblParent
      '
      Me.lblParent.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblParent.Location = New System.Drawing.Point(16, 192)
      Me.lblParent.Name = "lblParent"
      Me.lblParent.Size = New System.Drawing.Size(104, 20)
      Me.lblParent.TabIndex = 23
      Me.lblParent.Text = "Cost Center แม่:"
      Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtParent
      '
      Me.txtParent.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtParent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtParent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.txtParent.Location = New System.Drawing.Point(120, 192)
      Me.Validator.SetMinValue(Me.txtParent, "")
      Me.txtParent.Name = "txtParent"
      Me.txtParent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtParent, "")
      Me.Validator.SetRequired(Me.txtParent, False)
      Me.txtParent.Size = New System.Drawing.Size(160, 21)
      Me.txtParent.TabIndex = 10
      Me.txtParent.TabStop = False
      '
      'lblPhone
      '
      Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPhone.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblPhone.Location = New System.Drawing.Point(16, 144)
      Me.lblPhone.Name = "lblPhone"
      Me.lblPhone.Size = New System.Drawing.Size(104, 18)
      Me.lblPhone.TabIndex = 21
      Me.lblPhone.Text = "โทรศัพท์:"
      Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblPhone, "โทรศัพท์:")
      '
      'txtAdmin
      '
      Me.Validator.SetDataType(Me.txtAdmin, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdmin, "")
      Me.txtAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAdmin, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdmin, System.Drawing.Color.Empty)
      Me.txtAdmin.Location = New System.Drawing.Point(120, 96)
      Me.Validator.SetMinValue(Me.txtAdmin, "")
      Me.txtAdmin.Name = "txtAdmin"
      Me.Validator.SetRegularExpression(Me.txtAdmin, "")
      Me.Validator.SetRequired(Me.txtAdmin, False)
      Me.txtAdmin.Size = New System.Drawing.Size(64, 22)
      Me.txtAdmin.TabIndex = 3
      '
      'lblManager
      '
      Me.lblManager.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblManager.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblManager.Location = New System.Drawing.Point(16, 72)
      Me.lblManager.Name = "lblManager"
      Me.lblManager.Size = New System.Drawing.Size(104, 18)
      Me.lblManager.TabIndex = 18
      Me.lblManager.Text = "ผู้จัดการ:"
      Me.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblManager, "ผู้จัดการ:")
      '
      'txtManager
      '
      Me.Validator.SetDataType(Me.txtManager, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtManager, "")
      Me.txtManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtManager, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtManager, System.Drawing.Color.Empty)
      Me.txtManager.Location = New System.Drawing.Point(120, 72)
      Me.Validator.SetMinValue(Me.txtManager, "")
      Me.txtManager.Name = "txtManager"
      Me.Validator.SetRegularExpression(Me.txtManager, "")
      Me.Validator.SetRequired(Me.txtManager, False)
      Me.txtManager.Size = New System.Drawing.Size(64, 22)
      Me.txtManager.TabIndex = 2
      '
      'lblAdmin
      '
      Me.lblAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdmin.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblAdmin.Location = New System.Drawing.Point(16, 96)
      Me.lblAdmin.Name = "lblAdmin"
      Me.lblAdmin.Size = New System.Drawing.Size(104, 18)
      Me.lblAdmin.TabIndex = 19
      Me.lblAdmin.Text = "ธุรการ:"
      Me.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(96, 21)
      Me.txtCode.TabIndex = 0
      '
      'txtPhone
      '
      Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPhone, "")
      Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
      Me.txtPhone.Location = New System.Drawing.Point(120, 144)
      Me.txtPhone.MaxLength = 25
      Me.Validator.SetMinValue(Me.txtPhone, "")
      Me.txtPhone.Name = "txtPhone"
      Me.Validator.SetRegularExpression(Me.txtPhone, "")
      Me.Validator.SetRequired(Me.txtPhone, False)
      Me.txtPhone.Size = New System.Drawing.Size(160, 22)
      Me.txtPhone.TabIndex = 8
      '
      'txtAddress
      '
      Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddress, "")
      Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.txtAddress.Location = New System.Drawing.Point(120, 120)
      Me.txtAddress.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtAddress, "")
      Me.txtAddress.Name = "txtAddress"
      Me.Validator.SetRegularExpression(Me.txtAddress, "")
      Me.Validator.SetRequired(Me.txtAddress, False)
      Me.txtAddress.Size = New System.Drawing.Size(704, 22)
      Me.txtAddress.TabIndex = 7
      '
      'lblFax
      '
      Me.lblFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFax.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblFax.Location = New System.Drawing.Point(16, 168)
      Me.lblFax.Name = "lblFax"
      Me.lblFax.Size = New System.Drawing.Size(104, 18)
      Me.lblFax.TabIndex = 22
      Me.lblFax.Text = "แฟกซ์:"
      Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblFax, "แฟกซ์:")
      '
      'txtFax
      '
      Me.Validator.SetDataType(Me.txtFax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFax, "")
      Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFax, System.Drawing.Color.Empty)
      Me.txtFax.Location = New System.Drawing.Point(120, 168)
      Me.txtFax.MaxLength = 25
      Me.Validator.SetMinValue(Me.txtFax, "")
      Me.txtFax.Name = "txtFax"
      Me.Validator.SetRegularExpression(Me.txtFax, "")
      Me.Validator.SetRequired(Me.txtFax, False)
      Me.txtFax.Size = New System.Drawing.Size(160, 22)
      Me.txtFax.TabIndex = 9
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblAddress.Location = New System.Drawing.Point(16, 120)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(104, 18)
      Me.lblAddress.TabIndex = 20
      Me.lblAddress.Text = "ที่อยู่:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblAddress, "ที่อยู:")
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCode.Location = New System.Drawing.Point(16, 26)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 16
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblCode, "รหัส:")
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblName.Location = New System.Drawing.Point(16, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(104, 18)
      Me.lblName.TabIndex = 17
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblName, "ชื่อ :")
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(120, 48)
      Me.txtName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(320, 22)
      Me.txtName.TabIndex = 1
      '
      'txtAdminName
      '
      Me.Validator.SetDataType(Me.txtAdminName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdminName, "")
      Me.txtAdminName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAdminName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdminName, System.Drawing.Color.Empty)
      Me.txtAdminName.Location = New System.Drawing.Point(184, 96)
      Me.Validator.SetMinValue(Me.txtAdminName, "")
      Me.txtAdminName.Name = "txtAdminName"
      Me.txtAdminName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdminName, "")
      Me.Validator.SetRequired(Me.txtAdminName, False)
      Me.txtAdminName.Size = New System.Drawing.Size(208, 22)
      Me.txtAdminName.TabIndex = 29
      Me.txtAdminName.TabStop = False
      '
      'txtManagerName
      '
      Me.Validator.SetDataType(Me.txtManagerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtManagerName, "")
      Me.txtManagerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtManagerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtManagerName, System.Drawing.Color.Empty)
      Me.txtManagerName.Location = New System.Drawing.Point(184, 72)
      Me.Validator.SetMinValue(Me.txtManagerName, "")
      Me.txtManagerName.Name = "txtManagerName"
      Me.txtManagerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtManagerName, "")
      Me.Validator.SetRequired(Me.txtManagerName, False)
      Me.txtManagerName.Size = New System.Drawing.Size(208, 22)
      Me.txtManagerName.TabIndex = 28
      Me.txtManagerName.TabStop = False
      '
      'lblCCType
      '
      Me.lblCCType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCType.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCCType.Location = New System.Drawing.Point(16, 216)
      Me.lblCCType.Name = "lblCCType"
      Me.lblCCType.Size = New System.Drawing.Size(104, 18)
      Me.lblCCType.TabIndex = 24
      Me.lblCCType.Text = "ประเภทCostCenter:"
      Me.lblCCType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblCCType, "แฟกซ์:")
      '
      'grbMap
      '
      Me.grbMap.Controls.Add(Me.pnlPicHolder)
      Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMap.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grbMap.Location = New System.Drawing.Point(528, 144)
      Me.grbMap.Name = "grbMap"
      Me.grbMap.Size = New System.Drawing.Size(296, 224)
      Me.grbMap.TabIndex = 12
      Me.grbMap.TabStop = False
      Me.grbMap.Text = "แผนที่"
      '
      'pnlPicHolder
      '
      Me.pnlPicHolder.AutoScroll = True
      Me.pnlPicHolder.Controls.Add(Me.picMap)
      Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
      Me.pnlPicHolder.Name = "pnlPicHolder"
      Me.pnlPicHolder.Size = New System.Drawing.Size(290, 204)
      Me.pnlPicHolder.TabIndex = 0
      '
      'picMap
      '
      Me.picMap.Location = New System.Drawing.Point(0, 0)
      Me.picMap.Name = "picMap"
      Me.picMap.Size = New System.Drawing.Size(320, 160)
      Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picMap.TabIndex = 6
      Me.picMap.TabStop = False
      '
      'ibtnShowAdmin
      '
      Me.ibtnShowAdmin.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdmin.Location = New System.Drawing.Point(416, 96)
      Me.ibtnShowAdmin.Name = "ibtnShowAdmin"
      Me.ibtnShowAdmin.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdmin.TabIndex = 32
      Me.ibtnShowAdmin.TabStop = False
      Me.ibtnShowAdmin.ThemedImage = CType(resources.GetObject("ibtnShowAdmin.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowAdminDialog
      '
      Me.ibtnShowAdminDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAdminDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdminDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAdminDialog.Location = New System.Drawing.Point(392, 96)
      Me.ibtnShowAdminDialog.Name = "ibtnShowAdminDialog"
      Me.ibtnShowAdminDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdminDialog.TabIndex = 31
      Me.ibtnShowAdminDialog.TabStop = False
      Me.ibtnShowAdminDialog.ThemedImage = CType(resources.GetObject("ibtnShowAdminDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWipAcctCode
      '
      Me.Validator.SetDataType(Me.txtWipAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWipAcctCode, "")
      Me.txtWipAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWipAcctCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWipAcctCode, System.Drawing.Color.Empty)
      Me.txtWipAcctCode.Location = New System.Drawing.Point(536, 94)
      Me.Validator.SetMinValue(Me.txtWipAcctCode, "")
      Me.txtWipAcctCode.Name = "txtWipAcctCode"
      Me.Validator.SetRegularExpression(Me.txtWipAcctCode, "")
      Me.Validator.SetRequired(Me.txtWipAcctCode, False)
      Me.txtWipAcctCode.Size = New System.Drawing.Size(64, 22)
      Me.txtWipAcctCode.TabIndex = 6
      '
      'lblStoreAcct
      '
      Me.lblStoreAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreAcct.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStoreAcct.Location = New System.Drawing.Point(448, 72)
      Me.lblStoreAcct.Name = "lblStoreAcct"
      Me.lblStoreAcct.Size = New System.Drawing.Size(88, 18)
      Me.lblStoreAcct.TabIndex = 35
      Me.lblStoreAcct.Text = "ผังบัญชี Store:"
      Me.lblStoreAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblStoreAcct, "ผู้จัดการ:")
      '
      'txtStoreAcctCode
      '
      Me.Validator.SetDataType(Me.txtStoreAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreAcctCode, "")
      Me.txtStoreAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStoreAcctCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreAcctCode, System.Drawing.Color.Empty)
      Me.txtStoreAcctCode.Location = New System.Drawing.Point(536, 70)
      Me.Validator.SetMinValue(Me.txtStoreAcctCode, "")
      Me.txtStoreAcctCode.Name = "txtStoreAcctCode"
      Me.Validator.SetRegularExpression(Me.txtStoreAcctCode, "")
      Me.Validator.SetRequired(Me.txtStoreAcctCode, True)
      Me.txtStoreAcctCode.Size = New System.Drawing.Size(64, 22)
      Me.txtStoreAcctCode.TabIndex = 5
      '
      'lblWipAcct
      '
      Me.lblWipAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWipAcct.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblWipAcct.Location = New System.Drawing.Point(448, 96)
      Me.lblWipAcct.Name = "lblWipAcct"
      Me.lblWipAcct.Size = New System.Drawing.Size(88, 18)
      Me.lblWipAcct.TabIndex = 36
      Me.lblWipAcct.Text = "ผังบัญชี WIP:"
      Me.lblWipAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowWipAcct
      '
      Me.ibtnShowWipAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowWipAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowWipAcct.Location = New System.Drawing.Point(800, 94)
      Me.ibtnShowWipAcct.Name = "ibtnShowWipAcct"
      Me.ibtnShowWipAcct.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowWipAcct.TabIndex = 45
      Me.ibtnShowWipAcct.TabStop = False
      Me.ibtnShowWipAcct.ThemedImage = CType(resources.GetObject("ibtnShowWipAcct.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowStoreAcct
      '
      Me.ibtnShowStoreAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowStoreAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowStoreAcct.Location = New System.Drawing.Point(800, 70)
      Me.ibtnShowStoreAcct.Name = "ibtnShowStoreAcct"
      Me.ibtnShowStoreAcct.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowStoreAcct.TabIndex = 44
      Me.ibtnShowStoreAcct.TabStop = False
      Me.ibtnShowStoreAcct.ThemedImage = CType(resources.GetObject("ibtnShowStoreAcct.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowStoreAcctDialog
      '
      Me.ibtnShowStoreAcctDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowStoreAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowStoreAcctDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowStoreAcctDialog.Location = New System.Drawing.Point(776, 70)
      Me.ibtnShowStoreAcctDialog.Name = "ibtnShowStoreAcctDialog"
      Me.ibtnShowStoreAcctDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowStoreAcctDialog.TabIndex = 41
      Me.ibtnShowStoreAcctDialog.TabStop = False
      Me.ibtnShowStoreAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowStoreAcctDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowWipAcctDialog
      '
      Me.ibtnShowWipAcctDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowWipAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowWipAcctDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowWipAcctDialog.Location = New System.Drawing.Point(776, 94)
      Me.ibtnShowWipAcctDialog.Name = "ibtnShowWipAcctDialog"
      Me.ibtnShowWipAcctDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowWipAcctDialog.TabIndex = 42
      Me.ibtnShowWipAcctDialog.TabStop = False
      Me.ibtnShowWipAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowWipAcctDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWipAcctName
      '
      Me.Validator.SetDataType(Me.txtWipAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWipAcctName, "")
      Me.txtWipAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWipAcctName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWipAcctName, System.Drawing.Color.Empty)
      Me.txtWipAcctName.Location = New System.Drawing.Point(600, 94)
      Me.Validator.SetMinValue(Me.txtWipAcctName, "")
      Me.txtWipAcctName.Name = "txtWipAcctName"
      Me.txtWipAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWipAcctName, "")
      Me.Validator.SetRequired(Me.txtWipAcctName, False)
      Me.txtWipAcctName.Size = New System.Drawing.Size(176, 22)
      Me.txtWipAcctName.TabIndex = 39
      Me.txtWipAcctName.TabStop = False
      '
      'txtStoreAcctName
      '
      Me.Validator.SetDataType(Me.txtStoreAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreAcctName, "")
      Me.txtStoreAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStoreAcctName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreAcctName, System.Drawing.Color.Empty)
      Me.txtStoreAcctName.Location = New System.Drawing.Point(600, 70)
      Me.Validator.SetMinValue(Me.txtStoreAcctName, "")
      Me.txtStoreAcctName.Name = "txtStoreAcctName"
      Me.txtStoreAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreAcctName, "")
      Me.Validator.SetRequired(Me.txtStoreAcctName, False)
      Me.txtStoreAcctName.Size = New System.Drawing.Size(176, 22)
      Me.txtStoreAcctName.TabIndex = 38
      Me.txtStoreAcctName.TabStop = False
      '
      'ibtnShowExpenseAcct
      '
      Me.ibtnShowExpenseAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowExpenseAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowExpenseAcct.Location = New System.Drawing.Point(800, 48)
      Me.ibtnShowExpenseAcct.Name = "ibtnShowExpenseAcct"
      Me.ibtnShowExpenseAcct.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowExpenseAcct.TabIndex = 43
      Me.ibtnShowExpenseAcct.TabStop = False
      Me.ibtnShowExpenseAcct.ThemedImage = CType(resources.GetObject("ibtnShowExpenseAcct.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowExpenseAcctDialog
      '
      Me.ibtnShowExpenseAcctDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowExpenseAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowExpenseAcctDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowExpenseAcctDialog.Location = New System.Drawing.Point(776, 48)
      Me.ibtnShowExpenseAcctDialog.Name = "ibtnShowExpenseAcctDialog"
      Me.ibtnShowExpenseAcctDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowExpenseAcctDialog.TabIndex = 40
      Me.ibtnShowExpenseAcctDialog.TabStop = False
      Me.ibtnShowExpenseAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowExpenseAcctDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtExpenseAcctName
      '
      Me.Validator.SetDataType(Me.txtExpenseAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtExpenseAcctName, "")
      Me.txtExpenseAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtExpenseAcctName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtExpenseAcctName, System.Drawing.Color.Empty)
      Me.txtExpenseAcctName.Location = New System.Drawing.Point(600, 48)
      Me.Validator.SetMinValue(Me.txtExpenseAcctName, "")
      Me.txtExpenseAcctName.Name = "txtExpenseAcctName"
      Me.txtExpenseAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtExpenseAcctName, "")
      Me.Validator.SetRequired(Me.txtExpenseAcctName, False)
      Me.txtExpenseAcctName.Size = New System.Drawing.Size(176, 22)
      Me.txtExpenseAcctName.TabIndex = 37
      Me.txtExpenseAcctName.TabStop = False
      '
      'lblExpenseAcct
      '
      Me.lblExpenseAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblExpenseAcct.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblExpenseAcct.Location = New System.Drawing.Point(448, 48)
      Me.lblExpenseAcct.Name = "lblExpenseAcct"
      Me.lblExpenseAcct.Size = New System.Drawing.Size(88, 18)
      Me.lblExpenseAcct.TabIndex = 34
      Me.lblExpenseAcct.Text = "ผังบัญชีค่าใช้จ่าย:"
      Me.lblExpenseAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblExpenseAcct, "ผู้จัดการ:")
      '
      'txtExpenseAcctCode
      '
      Me.Validator.SetDataType(Me.txtExpenseAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtExpenseAcctCode, "")
      Me.txtExpenseAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtExpenseAcctCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtExpenseAcctCode, System.Drawing.Color.Empty)
      Me.txtExpenseAcctCode.Location = New System.Drawing.Point(536, 48)
      Me.Validator.SetMinValue(Me.txtExpenseAcctCode, "")
      Me.txtExpenseAcctCode.Name = "txtExpenseAcctCode"
      Me.Validator.SetRegularExpression(Me.txtExpenseAcctCode, "")
      Me.Validator.SetRequired(Me.txtExpenseAcctCode, True)
      Me.txtExpenseAcctCode.Size = New System.Drawing.Size(64, 22)
      Me.txtExpenseAcctCode.TabIndex = 4
      '
      'txtCustomerCode
      '
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(312, 24)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(80, 22)
      Me.txtCustomerCode.TabIndex = 26
      '
      'btnShowMap
      '
      Me.btnShowMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowMap.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowMap.Location = New System.Drawing.Point(776, 368)
      Me.btnShowMap.Name = "btnShowMap"
      Me.btnShowMap.Size = New System.Drawing.Size(24, 23)
      Me.btnShowMap.TabIndex = 52
      Me.btnShowMap.TabStop = False
      Me.btnShowMap.ThemedImage = CType(resources.GetObject("btnShowMap.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCustomer
      '
      Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomer.Location = New System.Drawing.Point(800, 24)
      Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
      Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomer.TabIndex = 43
      Me.ibtnShowCustomer.TabStop = False
      Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCustomerDialog
      '
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(776, 24)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 40
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(216, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 324
      Me.chkAutorun.TabStop = False
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 448)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(512, 80)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 167
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblItem.Location = New System.Drawing.Point(8, 432)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 168
      Me.lblItem.Text = "ผู้มีสิทธิ์ใช้งาน:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'btnCashFlow
      '
      Me.btnCashFlow.Location = New System.Drawing.Point(104, 324)
      Me.btnCashFlow.Name = "btnCashFlow"
      Me.btnCashFlow.Size = New System.Drawing.Size(75, 23)
      Me.btnCashFlow.TabIndex = 326
      Me.btnCashFlow.Text = "Cash Flow"
      Me.btnCashFlow.UseVisualStyleBackColor = True
      '
      'CostCenterDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CostCenterDetailView"
      Me.Size = New System.Drawing.Size(864, 544)
      Me.grbDetail.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbMap.ResumeLayout(False)
      Me.pnlPicHolder.ResumeLayout(False)
      Me.pnlPicHolder.PerformLayout()
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As New CostCenter
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = CostCenterDetailView.GetSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      UpdateEntityProperties()
      EventWiring()
      LoopControl(Me)
    End Sub
#End Region

#Region "Methods"
    Public Sub ScrollToMapPosition()
      Dim topLeftPoint As Point = Me.m_entity.MapPosition
      topLeftPoint.X -= CInt(Me.pnlPicHolder.Width / 2)
      topLeftPoint.Y -= CInt(Me.pnlPicHolder.Height / 2)
      Me.pnlPicHolder.AutoScrollPosition = topLeftPoint
    End Sub
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Originated Then
        If Me.m_entity.HaveAccess(CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
          Me.grbDetail.Enabled = True
        Else
          If Me.m_entity.Originator.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            Me.grbDetail.Enabled = True
          Else
            Me.grbDetail.Enabled = False
          End If
        End If
      Else
        Me.grbDetail.Enabled = True
      End If
    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      With Me
        .txtCode.Text = ""
        .txtName.Text = ""
        .txtAddress.Text = ""
        .txtPhone.Text = ""
        .txtFax.Text = ""

        .txtManager.Text = ""
        .txtManagerName.Text = ""
        .txtAdmin.Text = ""
        .txtAdminName.Text = ""

        .txtWipAcctCode.Text = ""
        .txtWipAcctName.Text = ""
        .txtStoreAcctCode.Text = ""
        .txtStoreAcctName.Text = ""
        .txtExpenseAcctCode.Text = ""
        .txtExpenseAcctName.Text = ""

        .m_treeManager.Treetable.Clear()

      End With

    End Sub
    'ดูประเภทของ CC แล้ว enable หรือ disable control ที่ต้องการ
    Public Sub CheckCCTypeEnable()
      If Me.m_entity.Type.Value <> 2 Then
        Me.txtBOQCode.Enabled = False
        Me.ibnShowBOQDialog.Enabled = False
        'customer
        Me.txtCustomerCode.ReadOnly = True
        Me.ibtnShowCustomer.Enabled = False
        Me.ibtnShowCustomerDialog.Enabled = False
      Else
        Me.txtBOQCode.Enabled = True
        Me.ibnShowBOQDialog.Enabled = True
        'customer
        Me.txtCustomerCode.ReadOnly = False
        Me.ibtnShowCustomer.Enabled = True
        Me.ibtnShowCustomerDialog.Enabled = True
      End If
    End Sub

    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostcenterDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))
      Me.lblManager.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblManager}")
      Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblAddress}")
      Me.lblAdmin.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblAdmin}")
      Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblPhone}")
      Me.lblFax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblFax}")
      Me.lblParent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblParent}")
      Me.lblBOQ.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblBOQ}")

      Me.lblStoreAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblStoreAcct}")
      Me.Validator.SetDisplayName(Me.txtStoreAcctCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblStoreAcct.Text, ":"))

      Me.lblWipAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblWipAcct}")
      Me.Validator.SetDisplayName(Me.txtWipAcctCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblWipAcct.Text, ":"))

      Me.lblExpenseAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblExpenseAcct}")
      Me.Validator.SetDisplayName(Me.txtExpenseAcctCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblExpenseAcct.Text, ":"))

      Me.lblCCType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblCCType}")
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblCustomer}")
      Me.chkActive.Text = "โครงการอยู่ระหว่างก่อสร้าง(Active)"
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBOQCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtManager.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAdmin.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtWipAcctCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtExpenseAcctCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtStoreAcctCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPhone.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtFax.TextChanged, AddressOf Me.ChangeProperty
      AddHandler chkActive.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler cmbCCType.SelectedIndexChanged, AddressOf Me.ChangeProperty

    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      Application.DoEvents()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      '.......................................
      'แทนการโหลดใน Class
      m_entity.LoadImage()
      '.......................................

      ' ทำการผูก Property ต่าง ๆ เข้ากับ control
      With Me
        .txtCode.Text = .m_entity.Code
        .txtName.Text = .m_entity.Name

        ' Autogencode
        m_oldCode = m_entity.Code
        Me.chkAutorun.Checked = Me.m_entity.AutoGen
        Me.UpdateAutogenStatus()

        If Not .m_entity.Manager Is Nothing Then
          .txtManager.Text = .m_entity.Manager.Code
          .txtManagerName.Text = .m_entity.Manager.Name
        End If

        If Not .m_entity.Admin Is Nothing Then
          .txtAdmin.Text = .m_entity.Admin.Code
          .txtAdminName.Text = .m_entity.Admin.Name
        End If

        If Not .m_entity.StoreAccount Is Nothing Then
          .txtStoreAcctCode.Text = .m_entity.StoreAccount.Code
          .txtStoreAcctName.Text = .m_entity.StoreAccount.Name
        End If

        If Not .m_entity.ExpenseAccount Is Nothing Then
          .txtExpenseAcctCode.Text = .m_entity.ExpenseAccount.Code
          .txtExpenseAcctName.Text = .m_entity.ExpenseAccount.Name
        End If

        If Not .m_entity.WipAccount Is Nothing Then
          .txtWipAcctCode.Text = .m_entity.WipAccount.Code
          .txtWipAcctName.Text = .m_entity.WipAccount.Name
        End If

        .txtAddress.Text = .m_entity.Address
        .txtPhone.Text = .m_entity.Phone
        .txtFax.Text = .m_entity.Fax
        .picImage.Image = .m_entity.Image
        CheckLabelImgSize()
        .picMap.Image = .m_entity.Map
        ScrollToMapPosition()

        If Not m_entity.Parent Is Nothing AndAlso m_entity.Parent.Originated Then
          Me.txtParent.Text = m_entity.Parent.Name
        Else
          Me.txtParent.Text = "Root" 'Todo
        End If

        Dim cust As Customer = .m_entity.Customer
        If Not cust Is Nothing Then
          Me.txtCustomerCode.Text = cust.Code
          Me.txtCustomerName.Text = cust.Name
        Else
          Me.txtCustomerCode.Text = ""
          Me.txtCustomerName.Text = ""
        End If

        Me.chkActive.Checked = Me.m_entity.IsActive 'โครงการยัง Active อยู่ ช่วย Filter

        Try
          If Not .m_entity.Boq Is Nothing Then
            Me.txtBOQCode.Text = Me.m_entity.Boq.Code
          End If
        Catch ex As Exception
          MessageBox.Show(ex.ToString)
        End Try


        CodeDescription.ComboSelect(Me.cmbCCType, Me.m_entity.Type)
        CheckCCTypeEnable()
      End With

      Me.RefreshUserAccess(0)

      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, CostCenter)

        'Me.m_entity.CostCenterUserAccessCollection = New CostCenterUserAccessCollection(Me.m_entity)

        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbCCType, "cc_type")
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
        Case "txtboqcode"
          dirtyFlag = BOQ.GetBOQ(txtBOQCode, Me.m_entity.Boq)
        Case "txtmanager"
          dirtyFlag = Employee.GetEmployee(txtManager, txtManagerName, Me.m_entity.Manager)
        Case "txtadmin"
          dirtyFlag = Employee.GetEmployee(txtAdmin, txtAdminName, Me.m_entity.Admin)
        Case "txtcustomercode"
          dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)

        Case "txtexpenseacctcode"
          dirtyFlag = Account.GetAccount(txtExpenseAcctCode, txtExpenseAcctName, Me.m_entity.ExpenseAccount)
        Case "txtstoreacctcode"
          dirtyFlag = Account.GetAccount(txtStoreAcctCode, txtStoreAcctName, Me.m_entity.StoreAccount)
        Case "txtwipacctcode"
          dirtyFlag = Account.GetAccount(txtWipAcctCode, txtWipAcctName, Me.m_entity.WipAccount)

        Case "txtaddress"
          Me.m_entity.Address = Me.txtAddress.Text
          dirtyFlag = True
        Case "txtphone"
          Me.m_entity.Phone = Me.txtPhone.Text
          dirtyFlag = True
        Case "txtfax"
          Me.m_entity.Fax = Me.txtFax.Text
          dirtyFlag = True
        Case "cmbcctype"
          Dim item As IdValuePair = CType(Me.cmbCCType.SelectedItem, IdValuePair)
          If Me.m_entity.CanChangeType(item.Id) Then
            Me.m_entity.Type.Value = item.Id
            CheckCCTypeEnable()
          Else
            CodeDescription.ComboSelect(Me.cmbCCType, Me.m_entity.Type)
          End If
          dirtyFlag = True
        Case "chkactive"
          Me.m_entity.IsActive = Me.chkActive.Checked
          dirtyFlag = True
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

    End Sub

#End Region

#Region "Event of control"
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
        'Hack
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

    Private Sub btnLoadMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadMap.Click
      Dim dlg As New OpenFileDialog
      Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
      dlg.Filter = String.Join("|", fileFilters)
      If dlg.ShowDialog = DialogResult.OK Then
        Dim img As Image = Image.FromFile(dlg.FileName)
        Me.picMap.Image = img
        ScrollToMapPosition()
        m_entity.Map = img
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
        myDialog.ShowDialog()
      End If
    End Sub

    Private Sub btnShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMap.Click
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
      myDialog.ShowDialog()
      ScrollToMapPosition()
    End Sub

    Private Sub picMap_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMap.Paint
      Dim g As Graphics = e.Graphics
      Dim pn As New Pen(Color.Red, 3)
      Dim top As Integer = Me.m_entity.MapPosition.Y - 10
      If top < 0 Then top = 0
      Dim left As Integer = Me.m_entity.MapPosition.X - 10
      If left < 0 Then left = 0
      Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
      If bottom > picMap.Height Then bottom = picMap.Height
      Dim right As Integer = Me.m_entity.MapPosition.X + 10
      If right > picMap.Width Then right = picMap.Width
      g.DrawLine(pn, left, top, right, bottom)
      g.DrawLine(pn, right, top, left, bottom)
      pn.Dispose()
    End Sub
    Private Sub btnClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMap.Click
      m_entity.Map = Nothing
      Me.picMap.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
    End Sub
    Private Sub CheckLabelImgSize()
      Me.lblPicSize.Text = "232 X 174 pixel"
      If Me.m_entity.Image Is Nothing Then
        Me.lblPicSize.Visible = True
      Else
        Me.lblPicSize.Visible = False
      End If
    End Sub
    Private m_Ticks As Long
    Private m_canDrag As Boolean = False
    Const TICKS_OFFSET As Long = 0
    Private Sub picMap_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove
      If Me.m_entity.Map Is Nothing Then
        Return
      End If
      Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
      If m_canDrag And e.Button = MouseButtons.Left And ts.TotalMilliseconds > TICKS_OFFSET Then
        Dim bounds As New Rectangle(New Point(0, 0), Me.m_entity.Map.Size)
        If bounds.Contains(New Point(e.X, e.Y)) Then
          Me.m_entity.MapPosition = New Point(e.X, e.Y)
          'Dim pt As Point = pnlPicHolder.PointToClient(picMap.PointToScreen(Me.m_entity.MapPosition))
          'Dim panelRect As Rectangle = pnlPicHolder.Bounds
          'panelRect.Inflate(-2 - SystemInformation.VerticalScrollBarWidth, -2 - SystemInformation.HorizontalScrollBarHeight)

          'Dim VerticalScrollBarWidth As Integer = SystemInformation.VerticalScrollBarWidth
          'Dim HorizontalScrollBarHeight As Integer = SystemInformation.HorizontalScrollBarHeight
          'Dim newScrollPos As Point = pnlPicHolder.AutoScrollPosition
          'If pt.X >= panelRect.Right - VerticalScrollBarWidth Then
          '    newScrollPos.X -= 1
          '    pnlPicHolder.AutoScrollPosition = newScrollPos
          'End If
          'If pt.Y >= panelRect.Bottom - HorizontalScrollBarHeight Then
          '    newScrollPos.Y -= 1
          '    pnlPicHolder.AutoScrollPosition = newScrollPos
          'End If
          'If pt.X <= panelRect.Right Then
          '    newScrollPos.X += 1
          '    pnlPicHolder.AutoScrollPosition = newScrollPos
          'End If
          'If pt.Y <= panelRect.Bottom Then
          '    newScrollPos.Y += 1
          '    pnlPicHolder.AutoScrollPosition = newScrollPos
          'End If

          picMap.Invalidate()
          m_Ticks = Now.Ticks
        End If
      End If
    End Sub
    Private Sub picMap_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
      'Dim top As Integer = Me.m_entity.MapPosition.Y - 10
      'If top < 0 Then top = 0
      'Dim left As Integer = Me.m_entity.MapPosition.X - 10
      'If left < 0 Then left = 0
      'Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
      'If bottom > picMap.Height Then bottom = picMap.Height
      'Dim right As Integer = Me.m_entity.MapPosition.X + 10
      'If right > picMap.Width Then right = picMap.Width

      'Dim xBounds As New Rectangle(left, top, 20, 20)
      'If xBounds.Contains(New Point(e.X, e.Y)) Then
      '    m_canDrag = True
      'End If
      If Me.m_entity.Map Is Nothing Then
        Return
      End If
      m_canDrag = True
      Dim bounds As New Rectangle(New Point(0, 0), Me.m_entity.Map.Size)
      If bounds.Contains(New Point(e.X, e.Y)) Then
        Me.m_entity.MapPosition = New Point(e.X, e.Y)
        picMap.Invalidate()
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub picMap_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
      If Me.m_entity.Map Is Nothing Then
        Return
      End If
      Dim bounds As New Rectangle(New Point(0, 0), Me.m_entity.Map.Size)
      If bounds.Contains(New Point(e.X, e.Y)) Then
        Me.m_entity.MapPosition = New Point(e.X, e.Y)
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
      m_canDrag = False
      ScrollToMapPosition()
    End Sub
#End Region

#Region "CostCenterUserAccess"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("CostCenterUserAccess")
      myDatatable.Columns.Add(New DataColumn("ccua_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      Return myDatatable
    End Function

    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CostCenterUserAccess"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "ccua_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "ccua_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Name"
      csName.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      Return dst
    End Function
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index < 0 Then
        index = 0
      End If

      Dim filters() As Filter
      filters = New Filter() {New Filter("IDList", GetItemIDList())}

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New User, AddressOf SetItems, filters)

      Me.RefreshUserAccess(index)
    End Sub
    Private Function GetItemIDList() As String
      Dim ret As String = ""
      For Each item As CostCenterUserAccess In Me.m_entity.CostCenterUserAccessCollection
        ret &= item.UserId.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, ret.Length - 1)
      End If
      Return ret
    End Function
    Private Sub RefreshUserAccess(ByVal index As Integer)
      If Not Me.m_entity.CostCenterUserAccessCollection Is Nothing Then
        Me.m_entity.CostCenterUserAccessCollection.PopulateUser4CostCenter(m_treeManager.Treetable)
      End If
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)

        Dim doc As New CostCenterUserAccess
        Dim myuser As New User(item.Id)
        doc.CostCenterId = Me.m_entity.Id
        doc.CostCenterCode = Me.m_entity.Code
        doc.CostCenterName = Me.m_entity.Name
        doc.UserId = myuser.Id
        doc.UserCode = myuser.Code
        doc.UserName = myuser.Name
        doc.AccessValue = 1

        'If Me.m_entity.CostCenterUserAccessCollection.Count > 0 Then
        '    Me.m_entity.CostCenterUserAccessCollection.Insert(index, doc)
        'Else
        Me.m_entity.CostCenterUserAccessCollection.Add(doc)
        'End If
      Next
      'Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      If Me.m_entity.CostCenterUserAccessCollection.Count <= 0 Then
        Return
      End If
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.CostCenterUserAccessCollection.Remove(index)
      Me.RefreshUserAccess(index)

      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "Function"

#End Region

#Region "Getting Properties from dialog"
    Private Sub ShowEmployee(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAdmin.Click, ibtnShowManager.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowManagerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowManagerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetManager)
    End Sub
    Private Sub ibtnShowAdminDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAdminDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetAdmin)
    End Sub
    Private Sub SetManager(ByVal e As ISimpleEntity)
      Me.txtManager.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Employee.GetEmployee(txtManager, txtManagerName, Me.m_entity.Manager)
    End Sub
    Private Sub SetAdmin(ByVal e As ISimpleEntity)
      Me.txtAdmin.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Employee.GetEmployee(txtAdmin, txtAdminName, Me.m_entity.Admin)
    End Sub
    Private Sub ibtnShowExpenseAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowExpenseAcct.Click
      ShowAccount()
    End Sub
    Private Sub ibtnShowStoreAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowStoreAcct.Click
      ShowAccount()
    End Sub
    Private Sub ibtnShowWipAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowWipAcct.Click
      ShowAccount()
    End Sub
    Private Sub ShowAccount()
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub
    Private Sub ibtnShowExpenseAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowExpenseAcctDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim dummy As New Account
      dummy.Type = New AccountType(5)
      entities.Add(dummy)
      myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetExpenseAcct, Nothing, entities)
    End Sub
    Private Sub ibtnShowStoreAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowStoreAcctDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim dummy As New Account
      dummy.Type = New AccountType(1)
      entities.Add(dummy)
      myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetStoreAcct, Nothing, entities)
    End Sub
    Private Sub ibtnShowWipAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowWipAcctDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim dummy As New Account
      dummy.Type = New AccountType(1)
      entities.Add(dummy)
      myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetWipAcct, Nothing, entities)
    End Sub
    Private Sub SetStoreAcct(ByVal e As ISimpleEntity)
      Me.txtStoreAcctCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty Or _
      Account.GetAccount(txtStoreAcctCode, txtStoreAcctName, Me.m_entity.StoreAccount)
    End Sub
    Private Sub SetWipAcct(ByVal e As ISimpleEntity)
      Me.txtWipAcctCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty Or _
      Account.GetAccount(txtWipAcctCode, txtWipAcctName, Me.m_entity.WipAccount)
    End Sub
    Private Sub SetExpenseAcct(ByVal e As ISimpleEntity)
      Me.txtExpenseAcctCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty Or _
      Account.GetAccount(txtExpenseAcctCode, txtExpenseAcctName, Me.m_entity.ExpenseAccount)
    End Sub
    Private Sub ibnShowBOQDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibnShowBOQDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQ, AddressOf SetBoq, New Filter() {New Filter("checkright", False)})
    End Sub
    Private Sub SetBoq(ByVal e As ISimpleEntity)
      Me.txtBOQCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty Or _
      BOQ.GetBOQ(txtBOQCode, Me.m_entity.Boq)
    End Sub
    Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
    End Sub
    Private Sub ibtnShowCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub SetCustomer(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtmanager", "txtmanagername", "txtadmin", "txtadminname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtstoreacctcode", "txtstoreacctname" _
                  , "txtwipacctcode", "txtwipacctname" _
                  , "txtexpenseacctcode", "txtexpenseacctname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtmanager", "txtmanagername"
              Me.SetManager(entity)
            Case "txtadmin", "txtadminname"
              Me.SetAdmin(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtstoreacctcode", "txtstoreacctname"
              Me.SetStoreAcct(entity)
            Case "txtwipacctcode", "txtwipacctname"
              Me.SetWipAcct(entity)
            Case "txtexpenseacctcode", "txtexpenseacctname"
              Me.SetExpenseAcct(entity)
          End Select
        End If
      End If
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

    Private Sub btnCashFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashFlow.Click
      Dim cf As New CashFlowForm
      cf.CostCenter = m_entity
      cf.Show()
    End Sub
  End Class

End Namespace
