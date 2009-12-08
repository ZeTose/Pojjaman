Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolManagementView
        Inherits AbstractEntityDetailPanelView
#Region "Members"
        Private m_entity As ToolManagement
#End Region
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtTool As System.Windows.Forms.TextBox
        Friend WithEvents lblTool As System.Windows.Forms.Label
        Friend WithEvents btnReturn As System.Windows.Forms.Button
        Friend WithEvents txtTool1 As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblTotal As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        Friend WithEvents lblUnit1 As System.Windows.Forms.Label
        Friend WithEvents txtTotalUse As System.Windows.Forms.TextBox
        Friend WithEvents lblTotalUse As System.Windows.Forms.Label
        Friend WithEvents txtTotalAvailable As System.Windows.Forms.TextBox
        Friend WithEvents lblUnit2 As System.Windows.Forms.Label
        Friend WithEvents lblTotalAvailable As System.Windows.Forms.Label
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbSerch As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents txtCostCenter As System.Windows.Forms.TextBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnSerch As System.Windows.Forms.Button
        Friend WithEvents ibtnShowDefaultUnitDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolManagementView))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.txtTool = New System.Windows.Forms.TextBox
            Me.lblTool = New System.Windows.Forms.Label
            Me.btnReturn = New System.Windows.Forms.Button
            Me.txtTool1 = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblTotal = New System.Windows.Forms.Label
            Me.txtTotal = New System.Windows.Forms.TextBox
            Me.lblUnit = New System.Windows.Forms.Label
            Me.lblUnit1 = New System.Windows.Forms.Label
            Me.txtTotalUse = New System.Windows.Forms.TextBox
            Me.lblTotalUse = New System.Windows.Forms.Label
            Me.txtTotalAvailable = New System.Windows.Forms.TextBox
            Me.lblUnit2 = New System.Windows.Forms.Label
            Me.lblTotalAvailable = New System.Windows.Forms.Label
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbSerch = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblCostCenter = New System.Windows.Forms.Label
            Me.txtCostCenter = New System.Windows.Forms.TextBox
            Me.btnClear = New System.Windows.Forms.Button
            Me.btnSerch = New System.Windows.Forms.Button
            Me.ibtnShowDefaultUnitDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbSerch.SuspendLayout()
            Me.SuspendLayout()
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(16, 96)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(584, 200)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 165
            Me.tgItem.TreeManager = Nothing
            '
            'txtTool
            '
            Me.Validator.SetDataType(Me.txtTool, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTool, "")
            Me.txtTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTool, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTool, System.Drawing.Color.Empty)
            Me.txtTool.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtTool, "")
            Me.Validator.SetMinValue(Me.txtTool, "")
            Me.txtTool.Name = "txtTool"
            Me.txtTool.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTool, "")
            Me.Validator.SetRequired(Me.txtTool, False)
            Me.txtTool.Size = New System.Drawing.Size(96, 22)
            Me.txtTool.TabIndex = 199
            Me.txtTool.Text = ""
            '
            'lblTool
            '
            Me.lblTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTool.ForeColor = System.Drawing.Color.Black
            Me.lblTool.Location = New System.Drawing.Point(32, 16)
            Me.lblTool.Name = "lblTool"
            Me.lblTool.Size = New System.Drawing.Size(56, 18)
            Me.lblTool.TabIndex = 200
            Me.lblTool.Text = "เครื่องมือ:"
            Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReturn
            '
            Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReturn.Location = New System.Drawing.Point(536, 400)
            Me.btnReturn.Name = "btnReturn"
            Me.btnReturn.TabIndex = 203
            Me.btnReturn.Text = "คืน"
            '
            'txtTool1
            '
            Me.Validator.SetDataType(Me.txtTool1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTool1, "")
            Me.txtTool1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTool1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTool1, System.Drawing.Color.Empty)
            Me.txtTool1.Location = New System.Drawing.Point(184, 16)
            Me.Validator.SetMaxValue(Me.txtTool1, "")
            Me.Validator.SetMinValue(Me.txtTool1, "")
            Me.txtTool1.Name = "txtTool1"
            Me.txtTool1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTool1, "")
            Me.Validator.SetRequired(Me.txtTool1, False)
            Me.txtTool1.Size = New System.Drawing.Size(264, 22)
            Me.txtTool1.TabIndex = 199
            Me.txtTool1.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblTool)
            Me.grbDetail.Controls.Add(Me.txtTool)
            Me.grbDetail.Controls.Add(Me.txtTool1)
            Me.grbDetail.Controls.Add(Me.lblTotal)
            Me.grbDetail.Controls.Add(Me.txtTotal)
            Me.grbDetail.Controls.Add(Me.lblUnit)
            Me.grbDetail.Controls.Add(Me.lblUnit1)
            Me.grbDetail.Controls.Add(Me.txtTotalUse)
            Me.grbDetail.Controls.Add(Me.lblTotalUse)
            Me.grbDetail.Controls.Add(Me.txtTotalAvailable)
            Me.grbDetail.Controls.Add(Me.lblUnit2)
            Me.grbDetail.Controls.Add(Me.lblTotalAvailable)
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(600, 80)
            Me.grbDetail.TabIndex = 204
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลเครื่องมือ"
            '
            'lblTotal
            '
            Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotal.ForeColor = System.Drawing.Color.Black
            Me.lblTotal.Location = New System.Drawing.Point(8, 42)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(80, 18)
            Me.lblTotal.TabIndex = 200
            Me.lblTotal.Text = "จำนวนทั้งหมด:"
            Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotal
            '
            Me.Validator.SetDataType(Me.txtTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotal, "")
            Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotal, System.Drawing.Color.Empty)
            Me.txtTotal.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtTotal, "")
            Me.Validator.SetMinValue(Me.txtTotal, "")
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotal, "")
            Me.Validator.SetRequired(Me.txtTotal, False)
            Me.txtTotal.Size = New System.Drawing.Size(80, 22)
            Me.txtTotal.TabIndex = 199
            Me.txtTotal.Text = ""
            '
            'lblUnit
            '
            Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit.ForeColor = System.Drawing.Color.Black
            Me.lblUnit.Location = New System.Drawing.Point(168, 42)
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblUnit.TabIndex = 200
            Me.lblUnit.Text = "หน่วย"
            Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUnit1
            '
            Me.lblUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit1.ForeColor = System.Drawing.Color.Black
            Me.lblUnit1.Location = New System.Drawing.Point(368, 42)
            Me.lblUnit1.Name = "lblUnit1"
            Me.lblUnit1.Size = New System.Drawing.Size(32, 18)
            Me.lblUnit1.TabIndex = 200
            Me.lblUnit1.Text = "หน่วย"
            Me.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtTotalUse
            '
            Me.Validator.SetDataType(Me.txtTotalUse, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalUse, "")
            Me.txtTotalUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalUse, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalUse, System.Drawing.Color.Empty)
            Me.txtTotalUse.Location = New System.Drawing.Point(288, 40)
            Me.Validator.SetMaxValue(Me.txtTotalUse, "")
            Me.Validator.SetMinValue(Me.txtTotalUse, "")
            Me.txtTotalUse.Name = "txtTotalUse"
            Me.txtTotalUse.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalUse, "")
            Me.Validator.SetRequired(Me.txtTotalUse, False)
            Me.txtTotalUse.Size = New System.Drawing.Size(80, 22)
            Me.txtTotalUse.TabIndex = 199
            Me.txtTotalUse.Text = ""
            '
            'lblTotalUse
            '
            Me.lblTotalUse.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalUse.ForeColor = System.Drawing.Color.Black
            Me.lblTotalUse.Location = New System.Drawing.Point(208, 42)
            Me.lblTotalUse.Name = "lblTotalUse"
            Me.lblTotalUse.Size = New System.Drawing.Size(80, 18)
            Me.lblTotalUse.TabIndex = 200
            Me.lblTotalUse.Text = "จำนวนที่ใช้งาน:"
            Me.lblTotalUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalAvailable
            '
            Me.Validator.SetDataType(Me.txtTotalAvailable, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalAvailable, "")
            Me.txtTotalAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalAvailable, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalAvailable, System.Drawing.Color.Empty)
            Me.txtTotalAvailable.Location = New System.Drawing.Point(480, 40)
            Me.Validator.SetMaxValue(Me.txtTotalAvailable, "")
            Me.Validator.SetMinValue(Me.txtTotalAvailable, "")
            Me.txtTotalAvailable.Name = "txtTotalAvailable"
            Me.txtTotalAvailable.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalAvailable, "")
            Me.Validator.SetRequired(Me.txtTotalAvailable, False)
            Me.txtTotalAvailable.Size = New System.Drawing.Size(80, 22)
            Me.txtTotalAvailable.TabIndex = 199
            Me.txtTotalAvailable.Text = ""
            '
            'lblUnit2
            '
            Me.lblUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit2.ForeColor = System.Drawing.Color.Black
            Me.lblUnit2.Location = New System.Drawing.Point(560, 42)
            Me.lblUnit2.Name = "lblUnit2"
            Me.lblUnit2.Size = New System.Drawing.Size(32, 18)
            Me.lblUnit2.TabIndex = 200
            Me.lblUnit2.Text = "หน่วย"
            Me.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTotalAvailable
            '
            Me.lblTotalAvailable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalAvailable.ForeColor = System.Drawing.Color.Black
            Me.lblTotalAvailable.Location = New System.Drawing.Point(400, 42)
            Me.lblTotalAvailable.Name = "lblTotalAvailable"
            Me.lblTotalAvailable.Size = New System.Drawing.Size(80, 18)
            Me.lblTotalAvailable.TabIndex = 200
            Me.lblTotalAvailable.Text = "จำนวนที่ว่าง:"
            Me.lblTotalAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.grbSerch)
            Me.grbItem.Controls.Add(Me.tgItem)
            Me.grbItem.Controls.Add(Me.btnClear)
            Me.grbItem.Controls.Add(Me.btnSerch)
            Me.grbItem.Location = New System.Drawing.Point(8, 96)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(608, 304)
            Me.grbItem.TabIndex = 205
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายการใช้งานเครื่องมือ"
            '
            'grbSerch
            '
            Me.grbSerch.Controls.Add(Me.lblCostCenter)
            Me.grbSerch.Controls.Add(Me.txtCostCenter)
            Me.grbSerch.Controls.Add(Me.txtCostCenterName)
            Me.grbSerch.Controls.Add(Me.ImageButton1)
            Me.grbSerch.Controls.Add(Me.ibtnShowDefaultUnitDialog)
            Me.grbSerch.Location = New System.Drawing.Point(16, 16)
            Me.grbSerch.Name = "grbSerch"
            Me.grbSerch.Size = New System.Drawing.Size(432, 72)
            Me.grbSerch.TabIndex = 205
            Me.grbSerch.TabStop = False
            Me.grbSerch.Text = "ค้นหา"
            '
            'lblCostCenter
            '
            Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
            Me.lblCostCenter.Location = New System.Drawing.Point(8, 16)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(72, 18)
            Me.lblCostCenter.TabIndex = 200
            Me.lblCostCenter.Text = "Cost Center:"
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenter
            '
            Me.Validator.SetDataType(Me.txtCostCenter, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenter, "")
            Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenter, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenter, System.Drawing.Color.Empty)
            Me.txtCostCenter.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtCostCenter, "")
            Me.Validator.SetMinValue(Me.txtCostCenter, "")
            Me.txtCostCenter.Name = "txtCostCenter"
            Me.Validator.SetRegularExpression(Me.txtCostCenter, "")
            Me.Validator.SetRequired(Me.txtCostCenter, False)
            Me.txtCostCenter.Size = New System.Drawing.Size(96, 22)
            Me.txtCostCenter.TabIndex = 199
            Me.txtCostCenter.Text = ""
            '
            'btnClear
            '
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnClear.Location = New System.Drawing.Point(456, 40)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.TabIndex = 203
            Me.btnClear.Text = "เคลียร์"
            '
            'btnSerch
            '
            Me.btnSerch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSerch.Location = New System.Drawing.Point(456, 64)
            Me.btnSerch.Name = "btnSerch"
            Me.btnSerch.TabIndex = 203
            Me.btnSerch.Text = "ค้นหา"
            '
            'ibtnShowDefaultUnitDialog
            '
            Me.ibtnShowDefaultUnitDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowDefaultUnitDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowDefaultUnitDialog.Image = CType(resources.GetObject("ibtnShowDefaultUnitDialog.Image"), System.Drawing.Image)
            Me.ibtnShowDefaultUnitDialog.Location = New System.Drawing.Point(376, 16)
            Me.ibtnShowDefaultUnitDialog.Name = "ibtnShowDefaultUnitDialog"
            Me.ibtnShowDefaultUnitDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowDefaultUnitDialog.TabIndex = 207
            Me.ibtnShowDefaultUnitDialog.TabStop = False
            Me.ibtnShowDefaultUnitDialog.ThemedImage = CType(resources.GetObject("ibtnShowDefaultUnitDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton1
            '
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(400, 16)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton1.TabIndex = 206
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(184, 16)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(192, 22)
            Me.txtCostCenterName.TabIndex = 199
            Me.txtCostCenterName.Text = ""
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
            'ToolManagementView
            '
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.btnReturn)
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "ToolManagementView"
            Me.Size = New System.Drawing.Size(624, 440)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDetail.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbSerch.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub cmbCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblTool}")
            Me.btnReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.btnReturn}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.grbDetail}")
            Me.lblTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblTotal}")
            Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblUnit}")
            Me.lblUnit1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblUnit1}")
            Me.lblTotalUse.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblTotalUse}")
            Me.lblUnit2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblUnit2}")
            Me.lblTotalAvailable.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblTotalAvailable}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.grbItem}")
            Me.grbSerch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.grbSerch}")
            Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.lblCostCenter}")
            Me.btnClear.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.btnSerch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolManagementView.btnSerch}")


        End Sub
    End Class
End Namespace