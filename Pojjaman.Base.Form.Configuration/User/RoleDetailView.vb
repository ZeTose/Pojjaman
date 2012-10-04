Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RoleDetailView
    'Inherits UserControl
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "

    'RoleControl overrides dispose to clean up the component list.
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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ibtnBlankUser As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelUser As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgUser As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents chkAllCC As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbApproveLevel As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents nudLevelApprovePA As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPA As System.Windows.Forms.Label
    Friend WithEvents lblLevelPA As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtPA As System.Windows.Forms.Label
    Friend WithEvents lblBaht7 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAmtPA As System.Windows.Forms.TextBox
    Friend WithEvents nudLevelApproveDR As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDR As System.Windows.Forms.Label
    Friend WithEvents lblLevelDR As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtDR As System.Windows.Forms.Label
    Friend WithEvents lblBaht6 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAmtDR As System.Windows.Forms.TextBox
    Friend WithEvents nudLevelApproveSC As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSC As System.Windows.Forms.Label
    Friend WithEvents lblLevelSC As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtSC As System.Windows.Forms.Label
    Friend WithEvents lblBaht5 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAmtSC As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxAmtWR As System.Windows.Forms.TextBox
    Friend WithEvents nudLevelApproveWR As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWR As System.Windows.Forms.Label
    Friend WithEvents lblLevelWR As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtWR As System.Windows.Forms.Label
    Friend WithEvents lblBaht4 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAmtPR As System.Windows.Forms.TextBox
    Friend WithEvents nudLevelApprovePR As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLevelApprovePO As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLevelApproveDO As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPR As System.Windows.Forms.Label
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents lblDO As System.Windows.Forms.Label
    Friend WithEvents lblLevelPR As System.Windows.Forms.Label
    Friend WithEvents lblLevelPO As System.Windows.Forms.Label
    Friend WithEvents lblLevelDO As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtPR As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtPO As System.Windows.Forms.Label
    Friend WithEvents lblMaxAmtDO As System.Windows.Forms.Label
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents lblBaht2 As System.Windows.Forms.Label
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAmtPO As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxAmtDO As System.Windows.Forms.TextBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RoleDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ibtnBlankUser = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelUser = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgUser = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblUser = New System.Windows.Forms.Label()
      Me.chkAllCC = New System.Windows.Forms.CheckBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbApproveLevel = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.nudLevelApprovePA = New System.Windows.Forms.NumericUpDown()
      Me.lblPA = New System.Windows.Forms.Label()
      Me.lblLevelPA = New System.Windows.Forms.Label()
      Me.lblMaxAmtPA = New System.Windows.Forms.Label()
      Me.lblBaht7 = New System.Windows.Forms.Label()
      Me.txtMaxAmtPA = New System.Windows.Forms.TextBox()
      Me.nudLevelApproveDR = New System.Windows.Forms.NumericUpDown()
      Me.lblDR = New System.Windows.Forms.Label()
      Me.lblLevelDR = New System.Windows.Forms.Label()
      Me.lblMaxAmtDR = New System.Windows.Forms.Label()
      Me.lblBaht6 = New System.Windows.Forms.Label()
      Me.txtMaxAmtDR = New System.Windows.Forms.TextBox()
      Me.nudLevelApproveSC = New System.Windows.Forms.NumericUpDown()
      Me.lblSC = New System.Windows.Forms.Label()
      Me.lblLevelSC = New System.Windows.Forms.Label()
      Me.lblMaxAmtSC = New System.Windows.Forms.Label()
      Me.lblBaht5 = New System.Windows.Forms.Label()
      Me.txtMaxAmtSC = New System.Windows.Forms.TextBox()
      Me.txtMaxAmtWR = New System.Windows.Forms.TextBox()
      Me.nudLevelApproveWR = New System.Windows.Forms.NumericUpDown()
      Me.lblWR = New System.Windows.Forms.Label()
      Me.lblLevelWR = New System.Windows.Forms.Label()
      Me.lblMaxAmtWR = New System.Windows.Forms.Label()
      Me.lblBaht4 = New System.Windows.Forms.Label()
      Me.txtMaxAmtPR = New System.Windows.Forms.TextBox()
      Me.nudLevelApprovePR = New System.Windows.Forms.NumericUpDown()
      Me.nudLevelApprovePO = New System.Windows.Forms.NumericUpDown()
      Me.nudLevelApproveDO = New System.Windows.Forms.NumericUpDown()
      Me.lblPR = New System.Windows.Forms.Label()
      Me.lblPO = New System.Windows.Forms.Label()
      Me.lblDO = New System.Windows.Forms.Label()
      Me.lblLevelPR = New System.Windows.Forms.Label()
      Me.lblLevelPO = New System.Windows.Forms.Label()
      Me.lblLevelDO = New System.Windows.Forms.Label()
      Me.lblMaxAmtPR = New System.Windows.Forms.Label()
      Me.lblMaxAmtPO = New System.Windows.Forms.Label()
      Me.lblMaxAmtDO = New System.Windows.Forms.Label()
      Me.lblBaht1 = New System.Windows.Forms.Label()
      Me.lblBaht2 = New System.Windows.Forms.Label()
      Me.lblBaht3 = New System.Windows.Forms.Label()
      Me.txtMaxAmtPO = New System.Windows.Forms.TextBox()
      Me.txtMaxAmtDO = New System.Windows.Forms.TextBox()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgUser, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbApproveLevel.SuspendLayout()
      CType(Me.nudLevelApprovePA, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApproveDR, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApproveSC, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApproveWR, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApprovePR, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApprovePO, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudLevelApproveDO, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbApproveLevel)
      Me.grbDetail.Controls.Add(Me.chkAllCC)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.ibtnBlankUser)
      Me.grbDetail.Controls.Add(Me.ibtnDelUser)
      Me.grbDetail.Controls.Add(Me.tgUser)
      Me.grbDetail.Controls.Add(Me.lblUser)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(614, 616)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "grbDetail: "
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(88, 45)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(288, 21)
      Me.txtName.TabIndex = 1
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 46)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(80, 18)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "lblName"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "lblCode"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(88, 24)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(96, 21)
      Me.txtCode.TabIndex = 0
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ibtnBlankUser
      '
      Me.ibtnBlankUser.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlankUser.Location = New System.Drawing.Point(544, 88)
      Me.ibtnBlankUser.Name = "ibtnBlankUser"
      Me.ibtnBlankUser.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankUser.TabIndex = 220
      Me.ibtnBlankUser.TabStop = False
      Me.ibtnBlankUser.ThemedImage = CType(resources.GetObject("ibtnBlankUser.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelUser
      '
      Me.ibtnDelUser.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelUser.Location = New System.Drawing.Point(544, 112)
      Me.ibtnDelUser.Name = "ibtnDelUser"
      Me.ibtnDelUser.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelUser.TabIndex = 219
      Me.ibtnDelUser.TabStop = False
      Me.ibtnDelUser.ThemedImage = CType(resources.GetObject("ibtnDelUser.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgUser
      '
      Me.tgUser.AllowNew = False
      Me.tgUser.AllowSorting = False
      Me.tgUser.AutoColumnResize = True
      Me.tgUser.CaptionVisible = False
      Me.tgUser.Cellchanged = False
      Me.tgUser.DataMember = ""
      Me.tgUser.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgUser.Location = New System.Drawing.Point(8, 88)
      Me.tgUser.Name = "tgUser"
      Me.tgUser.Size = New System.Drawing.Size(536, 147)
      Me.tgUser.SortingArrowColor = System.Drawing.Color.Red
      Me.tgUser.TabIndex = 217
      Me.tgUser.TreeManager = Nothing
      '
      'lblUser
      '
      Me.lblUser.BackColor = System.Drawing.Color.Transparent
      Me.lblUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUser.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblUser.Location = New System.Drawing.Point(8, 72)
      Me.lblUser.Name = "lblUser"
      Me.lblUser.Size = New System.Drawing.Size(208, 18)
      Me.lblUser.TabIndex = 218
      Me.lblUser.Text = "ผู้ใช้โปรแกรม:"
      Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAllCC
      '
      Me.chkAllCC.ForeColor = System.Drawing.SystemColors.ControlText
      Me.chkAllCC.Location = New System.Drawing.Point(360, 240)
      Me.chkAllCC.Name = "chkAllCC"
      Me.chkAllCC.Size = New System.Drawing.Size(184, 16)
      Me.chkAllCC.TabIndex = 225
      Me.chkAllCC.Text = "สามารถใช้งานได้ทุก Cost Center"
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(544, 256)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 224
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(544, 280)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 223
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
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
      Me.tgItem.Location = New System.Drawing.Point(8, 256)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(536, 133)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 221
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblItem.Location = New System.Drawing.Point(8, 240)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(208, 18)
      Me.lblItem.TabIndex = 222
      Me.lblItem.Text = "Cost Center ที่มีสิทธิ์ใช้งาน:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbApproveLevel
      '
      Me.grbApproveLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApprovePA)
      Me.grbApproveLevel.Controls.Add(Me.lblPA)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelPA)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtPA)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht7)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtPA)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApproveDR)
      Me.grbApproveLevel.Controls.Add(Me.lblDR)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelDR)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtDR)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht6)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtDR)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApproveSC)
      Me.grbApproveLevel.Controls.Add(Me.lblSC)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelSC)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtSC)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht5)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtSC)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtWR)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApproveWR)
      Me.grbApproveLevel.Controls.Add(Me.lblWR)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelWR)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtWR)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht4)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtPR)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApprovePR)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApprovePO)
      Me.grbApproveLevel.Controls.Add(Me.nudLevelApproveDO)
      Me.grbApproveLevel.Controls.Add(Me.lblPR)
      Me.grbApproveLevel.Controls.Add(Me.lblPO)
      Me.grbApproveLevel.Controls.Add(Me.lblDO)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelPR)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelPO)
      Me.grbApproveLevel.Controls.Add(Me.lblLevelDO)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtPR)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtPO)
      Me.grbApproveLevel.Controls.Add(Me.lblMaxAmtDO)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht1)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht2)
      Me.grbApproveLevel.Controls.Add(Me.lblBaht3)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtPO)
      Me.grbApproveLevel.Controls.Add(Me.txtMaxAmtDO)
      Me.grbApproveLevel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbApproveLevel.Location = New System.Drawing.Point(8, 404)
      Me.grbApproveLevel.Name = "grbApproveLevel"
      Me.grbApproveLevel.Size = New System.Drawing.Size(536, 203)
      Me.grbApproveLevel.TabIndex = 226
      Me.grbApproveLevel.TabStop = False
      Me.grbApproveLevel.Text = "ระดับสิทธิการอนุมัติเอกสาร"
      '
      'nudLevelApprovePA
      '
      Me.nudLevelApprovePA.Location = New System.Drawing.Point(208, 170)
      Me.nudLevelApprovePA.Name = "nudLevelApprovePA"
      Me.nudLevelApprovePA.Size = New System.Drawing.Size(48, 21)
      Me.nudLevelApprovePA.TabIndex = 28
      Me.nudLevelApprovePA.Tag = "NotGigaSite"
      '
      'lblPA
      '
      Me.lblPA.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblPA.Location = New System.Drawing.Point(24, 168)
      Me.lblPA.Name = "lblPA"
      Me.lblPA.Size = New System.Drawing.Size(104, 24)
      Me.lblPA.TabIndex = 27
      Me.lblPA.Tag = "NotGigaSite"
      Me.lblPA.Text = "ใบรับงาน (PA)"
      Me.lblPA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLevelPA
      '
      Me.lblLevelPA.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblLevelPA.Location = New System.Drawing.Point(120, 168)
      Me.lblLevelPA.Name = "lblLevelPA"
      Me.lblLevelPA.Size = New System.Drawing.Size(80, 24)
      Me.lblLevelPA.TabIndex = 26
      Me.lblLevelPA.Tag = "NotGigaSite"
            Me.lblLevelPA.Text = "ระดับสิทธิ์:"
      Me.lblLevelPA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMaxAmtPA
      '
      Me.lblMaxAmtPA.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblMaxAmtPA.Location = New System.Drawing.Point(264, 168)
      Me.lblMaxAmtPA.Name = "lblMaxAmtPA"
      Me.lblMaxAmtPA.Size = New System.Drawing.Size(128, 24)
      Me.lblMaxAmtPA.TabIndex = 25
      Me.lblMaxAmtPA.Tag = "NotGigaSite"
      Me.lblMaxAmtPA.Text = "วงเงินสูงสุดที่อนุมัติได้"
      Me.lblMaxAmtPA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht7
      '
      Me.lblBaht7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBaht7.Location = New System.Drawing.Point(488, 168)
      Me.lblBaht7.Name = "lblBaht7"
      Me.lblBaht7.Size = New System.Drawing.Size(40, 24)
      Me.lblBaht7.TabIndex = 24
      Me.lblBaht7.Tag = "NotGigaSite"
      Me.lblBaht7.Text = "บาท"
      Me.lblBaht7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtMaxAmtPA
      '
      Me.Validator.SetDataType(Me.txtMaxAmtPA, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMaxAmtPA, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtPA, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMaxAmtPA, System.Drawing.Color.Empty)
      Me.txtMaxAmtPA.Location = New System.Drawing.Point(400, 170)
      Me.Validator.SetMinValue(Me.txtMaxAmtPA, "")
      Me.txtMaxAmtPA.Name = "txtMaxAmtPA"
      Me.Validator.SetRegularExpression(Me.txtMaxAmtPA, "")
      Me.Validator.SetRequired(Me.txtMaxAmtPA, False)
      Me.txtMaxAmtPA.Size = New System.Drawing.Size(80, 21)
      Me.txtMaxAmtPA.TabIndex = 29
      Me.txtMaxAmtPA.Tag = "NotGigaSite"
      Me.txtMaxAmtPA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'nudLevelApproveDR
      '
      Me.nudLevelApproveDR.Location = New System.Drawing.Point(208, 122)
      Me.nudLevelApproveDR.Name = "nudLevelApproveDR"
      Me.nudLevelApproveDR.Size = New System.Drawing.Size(48, 21)
      Me.nudLevelApproveDR.TabIndex = 22
      Me.nudLevelApproveDR.Tag = "NotGigaSite"
      '
      'lblDR
      '
      Me.lblDR.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblDR.Location = New System.Drawing.Point(24, 120)
      Me.lblDR.Name = "lblDR"
      Me.lblDR.Size = New System.Drawing.Size(104, 24)
      Me.lblDR.TabIndex = 21
      Me.lblDR.Tag = "NotGigaSite"
      Me.lblDR.Text = "ใบหัก (DR)"
      Me.lblDR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLevelDR
      '
      Me.lblLevelDR.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblLevelDR.Location = New System.Drawing.Point(120, 120)
      Me.lblLevelDR.Name = "lblLevelDR"
      Me.lblLevelDR.Size = New System.Drawing.Size(80, 24)
      Me.lblLevelDR.TabIndex = 20
      Me.lblLevelDR.Tag = "NotGigaSite"
            Me.lblLevelDR.Text = "ระดับสิทธิ์:"
            Me.lblLevelDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxAmtDR
            '
            Me.lblMaxAmtDR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblMaxAmtDR.Location = New System.Drawing.Point(264, 120)
            Me.lblMaxAmtDR.Name = "lblMaxAmtDR"
            Me.lblMaxAmtDR.Size = New System.Drawing.Size(128, 24)
            Me.lblMaxAmtDR.TabIndex = 19
            Me.lblMaxAmtDR.Tag = "NotGigaSite"
            Me.lblMaxAmtDR.Text = "วงเงินสูงสุดที่อนุมัติได้"
            Me.lblMaxAmtDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht6
            '
            Me.lblBaht6.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblBaht6.Location = New System.Drawing.Point(488, 120)
            Me.lblBaht6.Name = "lblBaht6"
            Me.lblBaht6.Size = New System.Drawing.Size(40, 24)
            Me.lblBaht6.TabIndex = 18
            Me.lblBaht6.Tag = "NotGigaSite"
            Me.lblBaht6.Text = "บาท"
            Me.lblBaht6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMaxAmtDR
            '
            Me.Validator.SetDataType(Me.txtMaxAmtDR, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaxAmtDR, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtDR, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaxAmtDR, System.Drawing.Color.Empty)
            Me.txtMaxAmtDR.Location = New System.Drawing.Point(400, 122)
            Me.Validator.SetMinValue(Me.txtMaxAmtDR, "")
            Me.txtMaxAmtDR.Name = "txtMaxAmtDR"
            Me.Validator.SetRegularExpression(Me.txtMaxAmtDR, "")
            Me.Validator.SetRequired(Me.txtMaxAmtDR, False)
            Me.txtMaxAmtDR.Size = New System.Drawing.Size(80, 21)
            Me.txtMaxAmtDR.TabIndex = 23
            Me.txtMaxAmtDR.Tag = "NotGigaSite"
            Me.txtMaxAmtDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'nudLevelApproveSC
            '
            Me.nudLevelApproveSC.Location = New System.Drawing.Point(208, 98)
            Me.nudLevelApproveSC.Name = "nudLevelApproveSC"
            Me.nudLevelApproveSC.Size = New System.Drawing.Size(48, 21)
            Me.nudLevelApproveSC.TabIndex = 16
            Me.nudLevelApproveSC.Tag = "NotGigaSite"
            '
            'lblSC
            '
            Me.lblSC.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblSC.Location = New System.Drawing.Point(24, 96)
            Me.lblSC.Name = "lblSC"
            Me.lblSC.Size = New System.Drawing.Size(104, 24)
            Me.lblSC.TabIndex = 15
            Me.lblSC.Tag = "NotGigaSite"
            Me.lblSC.Text = "ใบสั่งจ้าง (SC,VO)"
            Me.lblSC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLevelSC
            '
            Me.lblLevelSC.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblLevelSC.Location = New System.Drawing.Point(120, 96)
            Me.lblLevelSC.Name = "lblLevelSC"
            Me.lblLevelSC.Size = New System.Drawing.Size(80, 24)
            Me.lblLevelSC.TabIndex = 14
            Me.lblLevelSC.Tag = "NotGigaSite"
            Me.lblLevelSC.Text = "ระดับสิทธิ์:"
            Me.lblLevelSC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxAmtSC
            '
            Me.lblMaxAmtSC.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblMaxAmtSC.Location = New System.Drawing.Point(264, 96)
            Me.lblMaxAmtSC.Name = "lblMaxAmtSC"
            Me.lblMaxAmtSC.Size = New System.Drawing.Size(128, 24)
            Me.lblMaxAmtSC.TabIndex = 13
            Me.lblMaxAmtSC.Tag = "NotGigaSite"
            Me.lblMaxAmtSC.Text = "วงเงินสูงสุดที่อนุมัติได้"
            Me.lblMaxAmtSC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht5
            '
            Me.lblBaht5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblBaht5.Location = New System.Drawing.Point(488, 96)
            Me.lblBaht5.Name = "lblBaht5"
            Me.lblBaht5.Size = New System.Drawing.Size(40, 24)
            Me.lblBaht5.TabIndex = 12
            Me.lblBaht5.Tag = "NotGigaSite"
            Me.lblBaht5.Text = "บาท"
            Me.lblBaht5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMaxAmtSC
            '
            Me.Validator.SetDataType(Me.txtMaxAmtSC, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaxAmtSC, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtSC, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaxAmtSC, System.Drawing.Color.Empty)
            Me.txtMaxAmtSC.Location = New System.Drawing.Point(400, 98)
            Me.Validator.SetMinValue(Me.txtMaxAmtSC, "")
            Me.txtMaxAmtSC.Name = "txtMaxAmtSC"
            Me.Validator.SetRegularExpression(Me.txtMaxAmtSC, "")
            Me.Validator.SetRequired(Me.txtMaxAmtSC, False)
            Me.txtMaxAmtSC.Size = New System.Drawing.Size(80, 21)
            Me.txtMaxAmtSC.TabIndex = 17
            Me.txtMaxAmtSC.Tag = "NotGigaSite"
            Me.txtMaxAmtSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtMaxAmtWR
            '
            Me.Validator.SetDataType(Me.txtMaxAmtWR, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaxAmtWR, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtWR, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaxAmtWR, System.Drawing.Color.Empty)
            Me.txtMaxAmtWR.Location = New System.Drawing.Point(400, 50)
            Me.Validator.SetMinValue(Me.txtMaxAmtWR, "")
            Me.txtMaxAmtWR.Name = "txtMaxAmtWR"
            Me.Validator.SetRegularExpression(Me.txtMaxAmtWR, "")
            Me.Validator.SetRequired(Me.txtMaxAmtWR, False)
            Me.txtMaxAmtWR.Size = New System.Drawing.Size(80, 21)
            Me.txtMaxAmtWR.TabIndex = 11
            Me.txtMaxAmtWR.Tag = "NotGigaSite"
            Me.txtMaxAmtWR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'nudLevelApproveWR
            '
            Me.nudLevelApproveWR.Location = New System.Drawing.Point(208, 50)
            Me.nudLevelApproveWR.Name = "nudLevelApproveWR"
            Me.nudLevelApproveWR.Size = New System.Drawing.Size(48, 21)
            Me.nudLevelApproveWR.TabIndex = 10
            Me.nudLevelApproveWR.Tag = "NotGigaSite"
            '
            'lblWR
            '
            Me.lblWR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblWR.Location = New System.Drawing.Point(24, 48)
            Me.lblWR.Name = "lblWR"
            Me.lblWR.Size = New System.Drawing.Size(104, 24)
            Me.lblWR.TabIndex = 9
            Me.lblWR.Tag = "NotGigaSite"
            Me.lblWR.Text = "ใบขอจ้าง (WR)"
            Me.lblWR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLevelWR
            '
            Me.lblLevelWR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblLevelWR.Location = New System.Drawing.Point(120, 48)
            Me.lblLevelWR.Name = "lblLevelWR"
            Me.lblLevelWR.Size = New System.Drawing.Size(80, 24)
            Me.lblLevelWR.TabIndex = 6
            Me.lblLevelWR.Tag = "NotGigaSite"
            Me.lblLevelWR.Text = "ระดับสิทธิ์:"
            Me.lblLevelWR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxAmtWR
            '
            Me.lblMaxAmtWR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblMaxAmtWR.Location = New System.Drawing.Point(264, 48)
            Me.lblMaxAmtWR.Name = "lblMaxAmtWR"
            Me.lblMaxAmtWR.Size = New System.Drawing.Size(128, 24)
            Me.lblMaxAmtWR.TabIndex = 7
            Me.lblMaxAmtWR.Tag = "NotGigaSite"
            Me.lblMaxAmtWR.Text = "วงเงินสูงสุดที่อนุมัติได้"
            Me.lblMaxAmtWR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht4
            '
            Me.lblBaht4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblBaht4.Location = New System.Drawing.Point(488, 48)
            Me.lblBaht4.Name = "lblBaht4"
            Me.lblBaht4.Size = New System.Drawing.Size(40, 24)
            Me.lblBaht4.TabIndex = 8
            Me.lblBaht4.Tag = "NotGigaSite"
            Me.lblBaht4.Text = "บาท"
            Me.lblBaht4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMaxAmtPR
            '
            Me.Validator.SetDataType(Me.txtMaxAmtPR, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaxAmtPR, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtPR, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaxAmtPR, System.Drawing.Color.Empty)
            Me.txtMaxAmtPR.Location = New System.Drawing.Point(400, 26)
            Me.Validator.SetMinValue(Me.txtMaxAmtPR, "")
            Me.txtMaxAmtPR.Name = "txtMaxAmtPR"
            Me.Validator.SetRegularExpression(Me.txtMaxAmtPR, "")
            Me.Validator.SetRequired(Me.txtMaxAmtPR, False)
            Me.txtMaxAmtPR.Size = New System.Drawing.Size(80, 21)
            Me.txtMaxAmtPR.TabIndex = 1
            Me.txtMaxAmtPR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'nudLevelApprovePR
            '
            Me.nudLevelApprovePR.Location = New System.Drawing.Point(208, 26)
            Me.nudLevelApprovePR.Name = "nudLevelApprovePR"
            Me.nudLevelApprovePR.Size = New System.Drawing.Size(48, 21)
            Me.nudLevelApprovePR.TabIndex = 0
            '
            'nudLevelApprovePO
            '
            Me.nudLevelApprovePO.Location = New System.Drawing.Point(208, 74)
            Me.nudLevelApprovePO.Name = "nudLevelApprovePO"
            Me.nudLevelApprovePO.Size = New System.Drawing.Size(48, 21)
            Me.nudLevelApprovePO.TabIndex = 2
            '
            'nudLevelApproveDO
            '
            Me.nudLevelApproveDO.Location = New System.Drawing.Point(208, 146)
            Me.nudLevelApproveDO.Name = "nudLevelApproveDO"
            Me.nudLevelApproveDO.Size = New System.Drawing.Size(48, 21)
            Me.nudLevelApproveDO.TabIndex = 4
            '
            'lblPR
            '
            Me.lblPR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblPR.Location = New System.Drawing.Point(24, 24)
            Me.lblPR.Name = "lblPR"
            Me.lblPR.Size = New System.Drawing.Size(104, 24)
            Me.lblPR.TabIndex = 0
            Me.lblPR.Text = "ใบขอซื้อ (PR)"
            Me.lblPR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPO
            '
            Me.lblPO.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblPO.Location = New System.Drawing.Point(24, 72)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(104, 24)
            Me.lblPO.TabIndex = 0
            Me.lblPO.Text = "ใบสั้งซื้อ (PO)"
            Me.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDO
            '
            Me.lblDO.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDO.Location = New System.Drawing.Point(24, 144)
            Me.lblDO.Name = "lblDO"
            Me.lblDO.Size = New System.Drawing.Size(104, 24)
            Me.lblDO.TabIndex = 0
            Me.lblDO.Text = "ใบรับของ (DO)"
            Me.lblDO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLevelPR
            '
            Me.lblLevelPR.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblLevelPR.Location = New System.Drawing.Point(120, 24)
            Me.lblLevelPR.Name = "lblLevelPR"
            Me.lblLevelPR.Size = New System.Drawing.Size(80, 24)
            Me.lblLevelPR.TabIndex = 0
            Me.lblLevelPR.Text = "ระดับสิทธิ์:"
            Me.lblLevelPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLevelPO
            '
            Me.lblLevelPO.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblLevelPO.Location = New System.Drawing.Point(120, 72)
            Me.lblLevelPO.Name = "lblLevelPO"
            Me.lblLevelPO.Size = New System.Drawing.Size(80, 24)
            Me.lblLevelPO.TabIndex = 0
            Me.lblLevelPO.Text = "ระดับสิทธิ์:"
            Me.lblLevelPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLevelDO
            '
            Me.lblLevelDO.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblLevelDO.Location = New System.Drawing.Point(120, 144)
            Me.lblLevelDO.Name = "lblLevelDO"
            Me.lblLevelDO.Size = New System.Drawing.Size(80, 24)
            Me.lblLevelDO.TabIndex = 0
            Me.lblLevelDO.Text = "ระดับสิทธิ์:"
      Me.lblLevelDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMaxAmtPR
      '
      Me.lblMaxAmtPR.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblMaxAmtPR.Location = New System.Drawing.Point(264, 24)
      Me.lblMaxAmtPR.Name = "lblMaxAmtPR"
      Me.lblMaxAmtPR.Size = New System.Drawing.Size(128, 24)
      Me.lblMaxAmtPR.TabIndex = 0
      Me.lblMaxAmtPR.Text = "วงเงินสูงสุดที่อนุมัติได้"
      Me.lblMaxAmtPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMaxAmtPO
      '
      Me.lblMaxAmtPO.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblMaxAmtPO.Location = New System.Drawing.Point(264, 72)
      Me.lblMaxAmtPO.Name = "lblMaxAmtPO"
      Me.lblMaxAmtPO.Size = New System.Drawing.Size(128, 24)
      Me.lblMaxAmtPO.TabIndex = 0
      Me.lblMaxAmtPO.Text = "วงเงินสูงสุดที่อนุมัติได้"
      Me.lblMaxAmtPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMaxAmtDO
      '
      Me.lblMaxAmtDO.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblMaxAmtDO.Location = New System.Drawing.Point(264, 144)
      Me.lblMaxAmtDO.Name = "lblMaxAmtDO"
      Me.lblMaxAmtDO.Size = New System.Drawing.Size(128, 24)
      Me.lblMaxAmtDO.TabIndex = 0
      Me.lblMaxAmtDO.Text = "วงเงินสูงสุดที่อนุมัติได้"
      Me.lblMaxAmtDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht1
      '
      Me.lblBaht1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBaht1.Location = New System.Drawing.Point(488, 24)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(40, 24)
      Me.lblBaht1.TabIndex = 0
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht2
      '
      Me.lblBaht2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBaht2.Location = New System.Drawing.Point(488, 72)
      Me.lblBaht2.Name = "lblBaht2"
      Me.lblBaht2.Size = New System.Drawing.Size(40, 24)
      Me.lblBaht2.TabIndex = 0
      Me.lblBaht2.Text = "บาท"
      Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht3
      '
      Me.lblBaht3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBaht3.Location = New System.Drawing.Point(488, 144)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(40, 24)
      Me.lblBaht3.TabIndex = 0
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtMaxAmtPO
      '
      Me.Validator.SetDataType(Me.txtMaxAmtPO, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMaxAmtPO, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtPO, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMaxAmtPO, System.Drawing.Color.Empty)
      Me.txtMaxAmtPO.Location = New System.Drawing.Point(400, 74)
      Me.Validator.SetMinValue(Me.txtMaxAmtPO, "")
      Me.txtMaxAmtPO.Name = "txtMaxAmtPO"
      Me.Validator.SetRegularExpression(Me.txtMaxAmtPO, "")
      Me.Validator.SetRequired(Me.txtMaxAmtPO, False)
      Me.txtMaxAmtPO.Size = New System.Drawing.Size(80, 21)
      Me.txtMaxAmtPO.TabIndex = 3
      Me.txtMaxAmtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtMaxAmtDO
      '
      Me.Validator.SetDataType(Me.txtMaxAmtDO, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMaxAmtDO, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMaxAmtDO, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMaxAmtDO, System.Drawing.Color.Empty)
      Me.txtMaxAmtDO.Location = New System.Drawing.Point(400, 146)
      Me.Validator.SetMinValue(Me.txtMaxAmtDO, "")
      Me.txtMaxAmtDO.Name = "txtMaxAmtDO"
      Me.Validator.SetRegularExpression(Me.txtMaxAmtDO, "")
      Me.Validator.SetRequired(Me.txtMaxAmtDO, False)
      Me.txtMaxAmtDO.Size = New System.Drawing.Size(80, 21)
      Me.txtMaxAmtDO.TabIndex = 5
      Me.txtMaxAmtDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'RoleDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RoleDetailView"
      Me.Size = New System.Drawing.Size(630, 632)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgUser, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbApproveLevel.ResumeLayout(False)
      Me.grbApproveLevel.PerformLayout()
      CType(Me.nudLevelApprovePA, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApproveDR, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApproveSC, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApproveWR, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApprovePR, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApprovePO, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudLevelApproveDO, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_role As Role
    Private m_isInitialized As Boolean = False
    Private m_UsertreeManager As TreeManager
    Private m_treeManager As TreeManager
#End Region

#Region "Property"

#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      'Check Module
      CheckModuleActivation()

      Dim dtu As TreeTable = Me.GetUserSchemaTable
      Dim dstu As DataGridTableStyle = Me.CreateUserTableStyle
      m_UsertreeManager = New TreeManager(dtu, tgUser)
      m_UsertreeManager.SetTableStyle(dstu)
      m_UsertreeManager.AllowSorting = False
      m_UsertreeManager.AllowDelete = False

      Dim dt As TreeTable = Me.GetSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      EventWiring()
    End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
    ReadOnly Property Activated() As Boolean
      Get
        Return m_ApproveDocModule.Activated
      End Get
    End Property
    Public Sub CheckModuleActivation()
      If Not Me.Activated Then
        Me.grbApproveLevel.Visible = False
      End If
    End Sub
#End Region

#Region "Users"
    Public Shared Function GetUserSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("user")
      myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ownermodified", GetType(String)))
      Return myDatatable
    End Function

    Public Function CreateUserTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "user"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 50
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.ReadOnly = True
      csCode.TextBox.Name = "code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.name}")
      csName.NullText = ""
      csName.Width = 200
      csName.TextBox.Name = "name"
      csName.ReadOnly = True

      Dim csOwnerModified As New TreeTextColumn
      csOwnerModified.MappingName = "ownermodified"
            csOwnerModified.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.ownermodified}")
      csOwnerModified.NullText = ""
      csOwnerModified.Width = 80
      csOwnerModified.TextBox.Name = "ownermodified"
      csOwnerModified.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csOwnerModified)
      Return dst
    End Function
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
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 50
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "ccua_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UserDetailView.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 250
      csName.TextBox.Name = "Name"
      csName.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      Return dst
    End Function

    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      'If index < 0 Then
      '  index = 0
      'End If

      'Dim filters() As Filter
      'filters = New Filter() {New Filter("IDList", GetItemIDList())}

      'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetItems, filters)

      'Me.RefreshUserAccess(index)
    End Sub
#End Region

#Region "Method"

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return "Icons.16x16.Role"
      End Get
    End Property
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()

    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtName.Text = ""
    End Sub
    Public Overrides Sub SetLabelText()
      If Not Me.m_role Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_role.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text.TrimEnd(":".ToCharArray))
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text.TrimEnd(":".ToCharArray))
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.grbDetail}")

            Me.lblUser.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblUser}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblItem}")
            Me.chkAllCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.chkAllCC}")
            Me.grbApproveLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.grbApproveLevel}")
            Me.lblPR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblPR}")
            Me.lblWR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblWR}")
            Me.lblSC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblSC}")
            Me.lblDR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblDR}")
            Me.lblPA.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblPA}")
            Me.lblDO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RoleDetailView.lblDO}")

            'Global ระดับสิทธิ์
            Me.lblLevelPR.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelWR.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelPO.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelSC.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelDR.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelDO.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")
            Me.lblLevelPA.Text = Me.StringParserService.Parse("${res:Global.LevelPA}")

            'Global วงเงินสูงสุดที่อนุมัติได้
            Me.lblMaxAmtPR.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtWR.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtPO.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtSC.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtDR.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtDO.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")
            Me.lblMaxAmtPA.Text = Me.StringParserService.Parse("${res:Global.MaxAmt}")

            'Global Baht
            Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht3.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht4.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht5.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht6.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht7.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_role Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_role.Code = txtCode.Text
        Case "txtname"
          Me.m_role.Name = txtName.Text
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      CheckFormEnable()
    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_role Is Nothing Then
        Return
      End If
      txtCode.Text = m_role.Code
      txtName.Text = m_role.Name
      SetLabelText()
      'SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_role
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_role = Nothing
        Me.m_role = CType(Value, Role)
        'Hack:
        Me.m_role.OnTabPageTextChanged(m_role, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()

    End Sub

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

    Private Sub RoleDetailView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
  End Class

End Namespace
