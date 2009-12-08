Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MarkupDetailView
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
        Friend WithEvents grbMarkup As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbSetting As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblMat As System.Windows.Forms.Label
        Friend WithEvents lblLabor As System.Windows.Forms.Label
        Friend WithEvents lblEquip As System.Windows.Forms.Label
        Friend WithEvents txtDirectTarget As System.Windows.Forms.TextBox
        Friend WithEvents lblProfit As System.Windows.Forms.Label
        Friend WithEvents txtProfitTarget As System.Windows.Forms.TextBox
        Friend WithEvents txtBidTarget As System.Windows.Forms.TextBox
        Friend WithEvents lblBidPrice As System.Windows.Forms.Label
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents txtMatTarget As System.Windows.Forms.TextBox
        Friend WithEvents lblTarget As System.Windows.Forms.Label
        Friend WithEvents txtLaborTarget As System.Windows.Forms.TextBox
        Friend WithEvents lblDirectCost As System.Windows.Forms.Label
        Friend WithEvents txtTotalTarget As System.Windows.Forms.TextBox
        Friend WithEvents lblBOQCode As System.Windows.Forms.Label
        Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
        Friend WithEvents lblTotalOverhead As System.Windows.Forms.Label
        Friend WithEvents txtMatBase As System.Windows.Forms.TextBox
        Friend WithEvents txtLaborBase As System.Windows.Forms.TextBox
        Friend WithEvents txtDirectBase As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalBase As System.Windows.Forms.TextBox
        Friend WithEvents txtProfitBase As System.Windows.Forms.TextBox
        Friend WithEvents txtMatAdjust As System.Windows.Forms.TextBox
        Friend WithEvents lblAdjust As System.Windows.Forms.Label
        Friend WithEvents txtLaborAdjust As System.Windows.Forms.TextBox
        Friend WithEvents txtDirectAdjust As System.Windows.Forms.TextBox
        Friend WithEvents txtBidBase As System.Windows.Forms.TextBox
        Friend WithEvents txtBidAdjust As System.Windows.Forms.TextBox
        Friend WithEvents txtEquipAdjust As System.Windows.Forms.TextBox
        Friend WithEvents txtEquipTarget As System.Windows.Forms.TextBox
        Friend WithEvents txtEquipBase As System.Windows.Forms.TextBox
        Friend WithEvents lblBase As System.Windows.Forms.Label
        Friend WithEvents grbCondition As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents tvMarkup As System.Windows.Forms.TreeView
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgCondition As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtSpecificValue As System.Windows.Forms.TextBox
        Friend WithEvents rdCondition As System.Windows.Forms.RadioButton
        Friend WithEvents rdSpecific As System.Windows.Forms.RadioButton
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbSpecificValueUnit As System.Windows.Forms.ComboBox
        Friend WithEvents ibtnAddCondition As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelCondition As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MarkupDetailView))
            Me.tvMarkup = New System.Windows.Forms.TreeView
            Me.tgCondition = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbMarkup = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbSetting = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.grbCondition = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnAddCondition = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelCondition = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.cmbCondition = New System.Windows.Forms.ComboBox
            Me.txtSpecificValue = New System.Windows.Forms.TextBox
            Me.rdCondition = New System.Windows.Forms.RadioButton
            Me.txtAmount = New System.Windows.Forms.TextBox
            Me.lblBaht = New System.Windows.Forms.Label
            Me.rdSpecific = New System.Windows.Forms.RadioButton
            Me.cmbSpecificValueUnit = New System.Windows.Forms.ComboBox
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblMat = New System.Windows.Forms.Label
            Me.txtMatBase = New System.Windows.Forms.TextBox
            Me.txtMatAdjust = New System.Windows.Forms.TextBox
            Me.txtMatTarget = New System.Windows.Forms.TextBox
            Me.lblAdjust = New System.Windows.Forms.Label
            Me.lblTarget = New System.Windows.Forms.Label
            Me.txtLaborAdjust = New System.Windows.Forms.TextBox
            Me.lblLabor = New System.Windows.Forms.Label
            Me.txtLaborBase = New System.Windows.Forms.TextBox
            Me.txtLaborTarget = New System.Windows.Forms.TextBox
            Me.txtDirectAdjust = New System.Windows.Forms.TextBox
            Me.lblDirectCost = New System.Windows.Forms.Label
            Me.txtDirectBase = New System.Windows.Forms.TextBox
            Me.txtDirectTarget = New System.Windows.Forms.TextBox
            Me.lblTotalOverhead = New System.Windows.Forms.Label
            Me.txtTotalBase = New System.Windows.Forms.TextBox
            Me.txtTotalTarget = New System.Windows.Forms.TextBox
            Me.lblProfit = New System.Windows.Forms.Label
            Me.txtProfitBase = New System.Windows.Forms.TextBox
            Me.txtProfitTarget = New System.Windows.Forms.TextBox
            Me.txtBidTarget = New System.Windows.Forms.TextBox
            Me.txtBidBase = New System.Windows.Forms.TextBox
            Me.lblBidPrice = New System.Windows.Forms.Label
            Me.txtBidAdjust = New System.Windows.Forms.TextBox
            Me.lblEquip = New System.Windows.Forms.Label
            Me.txtEquipAdjust = New System.Windows.Forms.TextBox
            Me.txtEquipTarget = New System.Windows.Forms.TextBox
            Me.txtEquipBase = New System.Windows.Forms.TextBox
            Me.lblBase = New System.Windows.Forms.Label
            Me.lblBOQCode = New System.Windows.Forms.Label
            Me.txtBOQCode = New System.Windows.Forms.TextBox
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.lblProject = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            CType(Me.tgCondition, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbMarkup.SuspendLayout()
            Me.grbSetting.SuspendLayout()
            Me.grbCondition.SuspendLayout()
            Me.grbSummary.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvMarkup
            '
            Me.tvMarkup.FullRowSelect = True
            Me.tvMarkup.HideSelection = False
            Me.tvMarkup.ImageIndex = -1
            Me.tvMarkup.Location = New System.Drawing.Point(0, 40)
            Me.tvMarkup.Name = "tvMarkup"
            Me.tvMarkup.SelectedImageIndex = -1
            Me.tvMarkup.Size = New System.Drawing.Size(248, 408)
            Me.tvMarkup.TabIndex = 0
            '
            'tgCondition
            '
            Me.tgCondition.AllowNew = False
            Me.tgCondition.AllowSorting = False
            Me.tgCondition.AutoColumnResize = True
            Me.tgCondition.CaptionVisible = False
            Me.tgCondition.Cellchanged = False
            Me.tgCondition.DataMember = ""
            Me.tgCondition.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgCondition.Location = New System.Drawing.Point(8, 72)
            Me.tgCondition.Name = "tgCondition"
            Me.tgCondition.Size = New System.Drawing.Size(408, 80)
            Me.tgCondition.SortingArrowColor = System.Drawing.Color.Red
            Me.tgCondition.TabIndex = 3
            Me.tgCondition.TreeManager = Nothing
            '
            'grbMarkup
            '
            Me.grbMarkup.Controls.Add(Me.ibtnBlank)
            Me.grbMarkup.Controls.Add(Me.ibtnDelRow)
            Me.grbMarkup.Controls.Add(Me.grbSetting)
            Me.grbMarkup.Controls.Add(Me.grbSummary)
            Me.grbMarkup.Controls.Add(Me.tvMarkup)
            Me.grbMarkup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMarkup.Location = New System.Drawing.Point(8, 32)
            Me.grbMarkup.Name = "grbMarkup"
            Me.grbMarkup.Size = New System.Drawing.Size(720, 456)
            Me.grbMarkup.TabIndex = 0
            Me.grbMarkup.TabStop = False
            Me.grbMarkup.Text = "Mark up Setting"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 16)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 3
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(32, 16)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 4
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbSetting
            '
            Me.grbSetting.Controls.Add(Me.txtName)
            Me.grbSetting.Controls.Add(Me.lblName)
            Me.grbSetting.Controls.Add(Me.lblNote)
            Me.grbSetting.Controls.Add(Me.txtNote)
            Me.grbSetting.Controls.Add(Me.grbCondition)
            Me.grbSetting.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSetting.Location = New System.Drawing.Point(248, 8)
            Me.grbSetting.Name = "grbSetting"
            Me.grbSetting.Size = New System.Drawing.Size(464, 232)
            Me.grbSetting.TabIndex = 1
            Me.grbSetting.TabStop = False
            Me.grbSetting.Text = "กำหนดค่า"
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(64, 16)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(376, 22)
            Me.txtName.TabIndex = 0
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 16)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(48, 18)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 40)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(56, 18)
            Me.lblNote.TabIndex = 3
            Me.lblNote.Text = "Remark:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(64, 40)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(376, 22)
            Me.txtNote.TabIndex = 1
            Me.txtNote.Text = ""
            '
            'grbCondition
            '
            Me.grbCondition.Controls.Add(Me.ibtnAddCondition)
            Me.grbCondition.Controls.Add(Me.ibtnDelCondition)
            Me.grbCondition.Controls.Add(Me.cmbCondition)
            Me.grbCondition.Controls.Add(Me.txtSpecificValue)
            Me.grbCondition.Controls.Add(Me.rdCondition)
            Me.grbCondition.Controls.Add(Me.txtAmount)
            Me.grbCondition.Controls.Add(Me.lblBaht)
            Me.grbCondition.Controls.Add(Me.tgCondition)
            Me.grbCondition.Controls.Add(Me.rdSpecific)
            Me.grbCondition.Controls.Add(Me.cmbSpecificValueUnit)
            Me.grbCondition.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCondition.Location = New System.Drawing.Point(8, 64)
            Me.grbCondition.Name = "grbCondition"
            Me.grbCondition.Size = New System.Drawing.Size(448, 160)
            Me.grbCondition.TabIndex = 2
            Me.grbCondition.TabStop = False
            Me.grbCondition.Text = "กำหนดเงื่อนไข"
            '
            'ibtnAddCondition
            '
            Me.ibtnAddCondition.Image = CType(resources.GetObject("ibtnAddCondition.Image"), System.Drawing.Image)
            Me.ibtnAddCondition.Location = New System.Drawing.Point(416, 72)
            Me.ibtnAddCondition.Name = "ibtnAddCondition"
            Me.ibtnAddCondition.Size = New System.Drawing.Size(24, 24)
            Me.ibtnAddCondition.TabIndex = 8
            Me.ibtnAddCondition.TabStop = False
            Me.ibtnAddCondition.ThemedImage = CType(resources.GetObject("ibtnAddCondition.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelCondition
            '
            Me.ibtnDelCondition.Image = CType(resources.GetObject("ibtnDelCondition.Image"), System.Drawing.Image)
            Me.ibtnDelCondition.Location = New System.Drawing.Point(416, 96)
            Me.ibtnDelCondition.Name = "ibtnDelCondition"
            Me.ibtnDelCondition.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelCondition.TabIndex = 9
            Me.ibtnDelCondition.TabStop = False
            Me.ibtnDelCondition.ThemedImage = CType(resources.GetObject("ibtnDelCondition.ThemedImage"), System.Drawing.Bitmap)
            '
            'cmbCondition
            '
            Me.cmbCondition.Location = New System.Drawing.Point(144, 48)
            Me.cmbCondition.Name = "cmbCondition"
            Me.cmbCondition.Size = New System.Drawing.Size(136, 21)
            Me.cmbCondition.TabIndex = 2
            '
            'txtSpecificValue
            '
            Me.Validator.SetDataType(Me.txtSpecificValue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSpecificValue, "")
            Me.txtSpecificValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSpecificValue, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSpecificValue, System.Drawing.Color.Empty)
            Me.txtSpecificValue.Location = New System.Drawing.Point(88, 23)
            Me.Validator.SetMaxValue(Me.txtSpecificValue, "")
            Me.Validator.SetMinValue(Me.txtSpecificValue, "")
            Me.txtSpecificValue.Name = "txtSpecificValue"
            Me.Validator.SetRegularExpression(Me.txtSpecificValue, "")
            Me.Validator.SetRequired(Me.txtSpecificValue, False)
            Me.txtSpecificValue.Size = New System.Drawing.Size(144, 22)
            Me.txtSpecificValue.TabIndex = 0
            Me.txtSpecificValue.Text = ""
            Me.txtSpecificValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'rdCondition
            '
            Me.rdCondition.Location = New System.Drawing.Point(16, 48)
            Me.rdCondition.Name = "rdCondition"
            Me.rdCondition.Size = New System.Drawing.Size(128, 24)
            Me.rdCondition.TabIndex = 5
            Me.rdCondition.Text = "Markup by Condition"
            '
            'txtAmount
            '
            Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAmount, "")
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.txtAmount.Location = New System.Drawing.Point(288, 38)
            Me.Validator.SetMaxValue(Me.txtAmount, "")
            Me.Validator.SetMinValue(Me.txtAmount, "")
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAmount, "")
            Me.Validator.SetRequired(Me.txtAmount, False)
            Me.txtAmount.Size = New System.Drawing.Size(120, 31)
            Me.txtAmount.TabIndex = 6
            Me.txtAmount.TabStop = False
            Me.txtAmount.Text = ""
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(408, 38)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(32, 20)
            Me.lblBaht.TabIndex = 7
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdSpecific
            '
            Me.rdSpecific.Location = New System.Drawing.Point(16, 18)
            Me.rdSpecific.Name = "rdSpecific"
            Me.rdSpecific.Size = New System.Drawing.Size(64, 32)
            Me.rdSpecific.TabIndex = 4
            Me.rdSpecific.Text = "Specify Amount"
            '
            'cmbSpecificValueUnit
            '
            Me.cmbSpecificValueUnit.Location = New System.Drawing.Point(232, 24)
            Me.cmbSpecificValueUnit.Name = "cmbSpecificValueUnit"
            Me.cmbSpecificValueUnit.Size = New System.Drawing.Size(48, 21)
            Me.cmbSpecificValueUnit.TabIndex = 1
            '
            'grbSummary
            '
            Me.grbSummary.Controls.Add(Me.lblTotalOverhead)
            Me.grbSummary.Controls.Add(Me.txtTotalBase)
            Me.grbSummary.Controls.Add(Me.lblMat)
            Me.grbSummary.Controls.Add(Me.txtMatBase)
            Me.grbSummary.Controls.Add(Me.txtMatAdjust)
            Me.grbSummary.Controls.Add(Me.txtMatTarget)
            Me.grbSummary.Controls.Add(Me.lblAdjust)
            Me.grbSummary.Controls.Add(Me.lblTarget)
            Me.grbSummary.Controls.Add(Me.txtLaborAdjust)
            Me.grbSummary.Controls.Add(Me.lblLabor)
            Me.grbSummary.Controls.Add(Me.txtLaborBase)
            Me.grbSummary.Controls.Add(Me.txtLaborTarget)
            Me.grbSummary.Controls.Add(Me.txtDirectAdjust)
            Me.grbSummary.Controls.Add(Me.lblDirectCost)
            Me.grbSummary.Controls.Add(Me.txtDirectBase)
            Me.grbSummary.Controls.Add(Me.txtDirectTarget)
            Me.grbSummary.Controls.Add(Me.txtTotalTarget)
            Me.grbSummary.Controls.Add(Me.lblProfit)
            Me.grbSummary.Controls.Add(Me.txtProfitBase)
            Me.grbSummary.Controls.Add(Me.txtProfitTarget)
            Me.grbSummary.Controls.Add(Me.txtBidTarget)
            Me.grbSummary.Controls.Add(Me.txtBidBase)
            Me.grbSummary.Controls.Add(Me.lblBidPrice)
            Me.grbSummary.Controls.Add(Me.txtBidAdjust)
            Me.grbSummary.Controls.Add(Me.lblEquip)
            Me.grbSummary.Controls.Add(Me.txtEquipAdjust)
            Me.grbSummary.Controls.Add(Me.txtEquipTarget)
            Me.grbSummary.Controls.Add(Me.txtEquipBase)
            Me.grbSummary.Controls.Add(Me.lblBase)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(248, 240)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(464, 208)
            Me.grbSummary.TabIndex = 2
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปราคาประมูล(หน่วย:บาท)"
            '
            'lblMat
            '
            Me.lblMat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMat.ForeColor = System.Drawing.Color.Black
            Me.lblMat.Location = New System.Drawing.Point(8, 32)
            Me.lblMat.Name = "lblMat"
            Me.lblMat.Size = New System.Drawing.Size(96, 18)
            Me.lblMat.TabIndex = 9
            Me.lblMat.Text = "Materials Cost:"
            Me.lblMat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMatBase
            '
            Me.txtMatBase.BackColor = System.Drawing.SystemColors.Info
            Me.txtMatBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtMatBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatBase, "")
            Me.txtMatBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtMatBase.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtMatBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMatBase, System.Drawing.Color.Empty)
            Me.txtMatBase.Location = New System.Drawing.Point(104, 32)
            Me.Validator.SetMaxValue(Me.txtMatBase, "")
            Me.Validator.SetMinValue(Me.txtMatBase, "")
            Me.txtMatBase.Name = "txtMatBase"
            Me.txtMatBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatBase, "")
            Me.Validator.SetRequired(Me.txtMatBase, False)
            Me.txtMatBase.Size = New System.Drawing.Size(120, 22)
            Me.txtMatBase.TabIndex = 16
            Me.txtMatBase.TabStop = False
            Me.txtMatBase.Text = ""
            Me.txtMatBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtMatAdjust
            '
            Me.txtMatAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtMatAdjust, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatAdjust, "")
            Me.txtMatAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMatAdjust, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMatAdjust, System.Drawing.Color.Empty)
            Me.txtMatAdjust.Location = New System.Drawing.Point(224, 32)
            Me.Validator.SetMaxValue(Me.txtMatAdjust, "")
            Me.Validator.SetMinValue(Me.txtMatAdjust, "")
            Me.txtMatAdjust.Name = "txtMatAdjust"
            Me.Validator.SetRegularExpression(Me.txtMatAdjust, "")
            Me.Validator.SetRequired(Me.txtMatAdjust, False)
            Me.txtMatAdjust.Size = New System.Drawing.Size(112, 22)
            Me.txtMatAdjust.TabIndex = 0
            Me.txtMatAdjust.Text = ""
            Me.txtMatAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtMatTarget
            '
            Me.txtMatTarget.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtMatTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtMatTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatTarget, "")
            Me.txtMatTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMatTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMatTarget, System.Drawing.Color.Empty)
            Me.txtMatTarget.Location = New System.Drawing.Point(336, 32)
            Me.Validator.SetMaxValue(Me.txtMatTarget, "")
            Me.Validator.SetMinValue(Me.txtMatTarget, "")
            Me.txtMatTarget.Name = "txtMatTarget"
            Me.Validator.SetRegularExpression(Me.txtMatTarget, "")
            Me.Validator.SetRequired(Me.txtMatTarget, False)
            Me.txtMatTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtMatTarget.TabIndex = 1
            Me.txtMatTarget.Text = ""
            Me.txtMatTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblAdjust
            '
            Me.lblAdjust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdjust.ForeColor = System.Drawing.Color.Black
            Me.lblAdjust.Location = New System.Drawing.Point(240, 16)
            Me.lblAdjust.Name = "lblAdjust"
            Me.lblAdjust.Size = New System.Drawing.Size(72, 18)
            Me.lblAdjust.TabIndex = 7
            Me.lblAdjust.Text = "เพิ่ม/ลด"
            Me.lblAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblTarget
            '
            Me.lblTarget.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTarget.ForeColor = System.Drawing.Color.Black
            Me.lblTarget.Location = New System.Drawing.Point(352, 16)
            Me.lblTarget.Name = "lblTarget"
            Me.lblTarget.Size = New System.Drawing.Size(88, 18)
            Me.lblTarget.TabIndex = 8
            Me.lblTarget.Text = "ราคาเป้าหมาย"
            Me.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtLaborAdjust
            '
            Me.txtLaborAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtLaborAdjust, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLaborAdjust, "")
            Me.txtLaborAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLaborAdjust, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLaborAdjust, System.Drawing.Color.Empty)
            Me.txtLaborAdjust.Location = New System.Drawing.Point(224, 56)
            Me.Validator.SetMaxValue(Me.txtLaborAdjust, "")
            Me.Validator.SetMinValue(Me.txtLaborAdjust, "")
            Me.txtLaborAdjust.Name = "txtLaborAdjust"
            Me.Validator.SetRegularExpression(Me.txtLaborAdjust, "")
            Me.Validator.SetRequired(Me.txtLaborAdjust, False)
            Me.txtLaborAdjust.Size = New System.Drawing.Size(112, 22)
            Me.txtLaborAdjust.TabIndex = 2
            Me.txtLaborAdjust.Text = ""
            Me.txtLaborAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblLabor
            '
            Me.lblLabor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLabor.ForeColor = System.Drawing.Color.Black
            Me.lblLabor.Location = New System.Drawing.Point(8, 56)
            Me.lblLabor.Name = "lblLabor"
            Me.lblLabor.Size = New System.Drawing.Size(96, 18)
            Me.lblLabor.TabIndex = 10
            Me.lblLabor.Text = "Labor:"
            Me.lblLabor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLaborBase
            '
            Me.txtLaborBase.BackColor = System.Drawing.SystemColors.Info
            Me.txtLaborBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtLaborBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLaborBase, "")
            Me.txtLaborBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtLaborBase.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtLaborBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLaborBase, System.Drawing.Color.Empty)
            Me.txtLaborBase.Location = New System.Drawing.Point(104, 56)
            Me.Validator.SetMaxValue(Me.txtLaborBase, "")
            Me.Validator.SetMinValue(Me.txtLaborBase, "")
            Me.txtLaborBase.Name = "txtLaborBase"
            Me.txtLaborBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLaborBase, "")
            Me.Validator.SetRequired(Me.txtLaborBase, False)
            Me.txtLaborBase.Size = New System.Drawing.Size(120, 22)
            Me.txtLaborBase.TabIndex = 17
            Me.txtLaborBase.TabStop = False
            Me.txtLaborBase.Text = ""
            Me.txtLaborBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtLaborTarget
            '
            Me.txtLaborTarget.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtLaborTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtLaborTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLaborTarget, "")
            Me.txtLaborTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLaborTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLaborTarget, System.Drawing.Color.Empty)
            Me.txtLaborTarget.Location = New System.Drawing.Point(336, 56)
            Me.Validator.SetMaxValue(Me.txtLaborTarget, "")
            Me.Validator.SetMinValue(Me.txtLaborTarget, "")
            Me.txtLaborTarget.Name = "txtLaborTarget"
            Me.Validator.SetRegularExpression(Me.txtLaborTarget, "")
            Me.Validator.SetRequired(Me.txtLaborTarget, False)
            Me.txtLaborTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtLaborTarget.TabIndex = 3
            Me.txtLaborTarget.Text = ""
            Me.txtLaborTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDirectAdjust
            '
            Me.txtDirectAdjust.BackColor = System.Drawing.Color.DimGray
            Me.txtDirectAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtDirectAdjust, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDirectAdjust, "")
            Me.txtDirectAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtDirectAdjust.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtDirectAdjust, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDirectAdjust, System.Drawing.Color.Empty)
            Me.txtDirectAdjust.Location = New System.Drawing.Point(224, 104)
            Me.Validator.SetMaxValue(Me.txtDirectAdjust, "")
            Me.Validator.SetMinValue(Me.txtDirectAdjust, "")
            Me.txtDirectAdjust.Name = "txtDirectAdjust"
            Me.txtDirectAdjust.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDirectAdjust, "")
            Me.Validator.SetRequired(Me.txtDirectAdjust, False)
            Me.txtDirectAdjust.Size = New System.Drawing.Size(112, 22)
            Me.txtDirectAdjust.TabIndex = 20
            Me.txtDirectAdjust.TabStop = False
            Me.txtDirectAdjust.Text = ""
            Me.txtDirectAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDirectCost
            '
            Me.lblDirectCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDirectCost.ForeColor = System.Drawing.Color.Black
            Me.lblDirectCost.Location = New System.Drawing.Point(8, 104)
            Me.lblDirectCost.Name = "lblDirectCost"
            Me.lblDirectCost.Size = New System.Drawing.Size(96, 18)
            Me.lblDirectCost.TabIndex = 12
            Me.lblDirectCost.Text = "Total Direct Cost:"
            Me.lblDirectCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDirectBase
            '
            Me.txtDirectBase.BackColor = System.Drawing.Color.DimGray
            Me.txtDirectBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtDirectBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDirectBase, "")
            Me.txtDirectBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtDirectBase.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtDirectBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDirectBase, System.Drawing.Color.Empty)
            Me.txtDirectBase.Location = New System.Drawing.Point(104, 104)
            Me.Validator.SetMaxValue(Me.txtDirectBase, "")
            Me.Validator.SetMinValue(Me.txtDirectBase, "")
            Me.txtDirectBase.Name = "txtDirectBase"
            Me.txtDirectBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDirectBase, "")
            Me.Validator.SetRequired(Me.txtDirectBase, False)
            Me.txtDirectBase.Size = New System.Drawing.Size(120, 22)
            Me.txtDirectBase.TabIndex = 19
            Me.txtDirectBase.TabStop = False
            Me.txtDirectBase.Text = ""
            Me.txtDirectBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDirectTarget
            '
            Me.txtDirectTarget.BackColor = System.Drawing.Color.DimGray
            Me.txtDirectTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtDirectTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDirectTarget, "")
            Me.txtDirectTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtDirectTarget.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtDirectTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDirectTarget, System.Drawing.Color.Empty)
            Me.txtDirectTarget.Location = New System.Drawing.Point(336, 104)
            Me.Validator.SetMaxValue(Me.txtDirectTarget, "")
            Me.Validator.SetMinValue(Me.txtDirectTarget, "")
            Me.txtDirectTarget.Name = "txtDirectTarget"
            Me.txtDirectTarget.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDirectTarget, "")
            Me.Validator.SetRequired(Me.txtDirectTarget, False)
            Me.txtDirectTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtDirectTarget.TabIndex = 21
            Me.txtDirectTarget.TabStop = False
            Me.txtDirectTarget.Text = ""
            Me.txtDirectTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTotalOverhead
            '
            Me.lblTotalOverhead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalOverhead.ForeColor = System.Drawing.Color.Black
            Me.lblTotalOverhead.Location = New System.Drawing.Point(8, 127)
            Me.lblTotalOverhead.Name = "lblTotalOverhead"
            Me.lblTotalOverhead.Size = New System.Drawing.Size(96, 24)
            Me.lblTotalOverhead.TabIndex = 13
            Me.lblTotalOverhead.Text = "Include Overhead Amout:"
            Me.lblTotalOverhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalBase
            '
            Me.txtTotalBase.BackColor = System.Drawing.SystemColors.Info
            Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtTotalBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalBase, "")
            Me.txtTotalBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtTotalBase.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtTotalBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalBase, System.Drawing.Color.Empty)
            Me.txtTotalBase.Location = New System.Drawing.Point(104, 128)
            Me.Validator.SetMaxValue(Me.txtTotalBase, "")
            Me.Validator.SetMinValue(Me.txtTotalBase, "")
            Me.txtTotalBase.Name = "txtTotalBase"
            Me.txtTotalBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalBase, "")
            Me.Validator.SetRequired(Me.txtTotalBase, False)
            Me.txtTotalBase.Size = New System.Drawing.Size(120, 22)
            Me.txtTotalBase.TabIndex = 22
            Me.txtTotalBase.TabStop = False
            Me.txtTotalBase.Text = ""
            Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTotalTarget
            '
            Me.txtTotalTarget.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtTotalTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtTotalTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalTarget, "")
            Me.txtTotalTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtTotalTarget.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtTotalTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalTarget, System.Drawing.Color.Empty)
            Me.txtTotalTarget.Location = New System.Drawing.Point(336, 128)
            Me.Validator.SetMaxValue(Me.txtTotalTarget, "")
            Me.Validator.SetMinValue(Me.txtTotalTarget, "")
            Me.txtTotalTarget.Name = "txtTotalTarget"
            Me.txtTotalTarget.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalTarget, "")
            Me.Validator.SetRequired(Me.txtTotalTarget, False)
            Me.txtTotalTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtTotalTarget.TabIndex = 23
            Me.txtTotalTarget.TabStop = False
            Me.txtTotalTarget.Text = ""
            Me.txtTotalTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblProfit
            '
            Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProfit.ForeColor = System.Drawing.Color.Black
            Me.lblProfit.Location = New System.Drawing.Point(8, 152)
            Me.lblProfit.Name = "lblProfit"
            Me.lblProfit.Size = New System.Drawing.Size(96, 18)
            Me.lblProfit.TabIndex = 14
            Me.lblProfit.Text = "Profit:"
            Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProfitBase
            '
            Me.txtProfitBase.BackColor = System.Drawing.SystemColors.Info
            Me.txtProfitBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtProfitBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProfitBase, "")
            Me.txtProfitBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtProfitBase.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtProfitBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProfitBase, System.Drawing.Color.Empty)
            Me.txtProfitBase.Location = New System.Drawing.Point(104, 152)
            Me.Validator.SetMaxValue(Me.txtProfitBase, "")
            Me.Validator.SetMinValue(Me.txtProfitBase, "")
            Me.txtProfitBase.Name = "txtProfitBase"
            Me.txtProfitBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProfitBase, "")
            Me.Validator.SetRequired(Me.txtProfitBase, False)
            Me.txtProfitBase.Size = New System.Drawing.Size(120, 22)
            Me.txtProfitBase.TabIndex = 24
            Me.txtProfitBase.TabStop = False
            Me.txtProfitBase.Text = ""
            Me.txtProfitBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtProfitTarget
            '
            Me.txtProfitTarget.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtProfitTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtProfitTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProfitTarget, "")
            Me.txtProfitTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtProfitTarget.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtProfitTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProfitTarget, System.Drawing.Color.Empty)
            Me.txtProfitTarget.Location = New System.Drawing.Point(336, 152)
            Me.Validator.SetMaxValue(Me.txtProfitTarget, "")
            Me.Validator.SetMinValue(Me.txtProfitTarget, "")
            Me.txtProfitTarget.Name = "txtProfitTarget"
            Me.txtProfitTarget.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProfitTarget, "")
            Me.Validator.SetRequired(Me.txtProfitTarget, False)
            Me.txtProfitTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtProfitTarget.TabIndex = 25
            Me.txtProfitTarget.TabStop = False
            Me.txtProfitTarget.Text = ""
            Me.txtProfitTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtBidTarget
            '
            Me.txtBidTarget.BackColor = System.Drawing.Color.DimGray
            Me.txtBidTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtBidTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBidTarget, "")
            Me.txtBidTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBidTarget.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtBidTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBidTarget, System.Drawing.Color.Empty)
            Me.txtBidTarget.Location = New System.Drawing.Point(336, 176)
            Me.Validator.SetMaxValue(Me.txtBidTarget, "")
            Me.Validator.SetMinValue(Me.txtBidTarget, "")
            Me.txtBidTarget.Name = "txtBidTarget"
            Me.txtBidTarget.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBidTarget, "")
            Me.Validator.SetRequired(Me.txtBidTarget, False)
            Me.txtBidTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtBidTarget.TabIndex = 26
            Me.txtBidTarget.TabStop = False
            Me.txtBidTarget.Text = ""
            Me.txtBidTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtBidBase
            '
            Me.txtBidBase.BackColor = System.Drawing.Color.DimGray
            Me.txtBidBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtBidBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBidBase, "")
            Me.txtBidBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBidBase.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtBidBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBidBase, System.Drawing.Color.Empty)
            Me.txtBidBase.Location = New System.Drawing.Point(104, 176)
            Me.Validator.SetMaxValue(Me.txtBidBase, "")
            Me.Validator.SetMinValue(Me.txtBidBase, "")
            Me.txtBidBase.Name = "txtBidBase"
            Me.txtBidBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBidBase, "")
            Me.Validator.SetRequired(Me.txtBidBase, False)
            Me.txtBidBase.Size = New System.Drawing.Size(120, 22)
            Me.txtBidBase.TabIndex = 28
            Me.txtBidBase.TabStop = False
            Me.txtBidBase.Text = ""
            Me.txtBidBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblBidPrice
            '
            Me.lblBidPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidPrice.ForeColor = System.Drawing.Color.Black
            Me.lblBidPrice.Location = New System.Drawing.Point(8, 176)
            Me.lblBidPrice.Name = "lblBidPrice"
            Me.lblBidPrice.Size = New System.Drawing.Size(96, 18)
            Me.lblBidPrice.TabIndex = 15
            Me.lblBidPrice.Text = "Bid Price:"
            Me.lblBidPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBidAdjust
            '
            Me.txtBidAdjust.BackColor = System.Drawing.Color.DimGray
            Me.txtBidAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtBidAdjust, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBidAdjust, "")
            Me.txtBidAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBidAdjust.ForeColor = System.Drawing.Color.White
            Me.Validator.SetGotFocusBackColor(Me.txtBidAdjust, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBidAdjust, System.Drawing.Color.Empty)
            Me.txtBidAdjust.Location = New System.Drawing.Point(224, 176)
            Me.Validator.SetMaxValue(Me.txtBidAdjust, "")
            Me.Validator.SetMinValue(Me.txtBidAdjust, "")
            Me.txtBidAdjust.Name = "txtBidAdjust"
            Me.txtBidAdjust.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBidAdjust, "")
            Me.Validator.SetRequired(Me.txtBidAdjust, False)
            Me.txtBidAdjust.Size = New System.Drawing.Size(112, 22)
            Me.txtBidAdjust.TabIndex = 27
            Me.txtBidAdjust.TabStop = False
            Me.txtBidAdjust.Text = ""
            Me.txtBidAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblEquip
            '
            Me.lblEquip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEquip.ForeColor = System.Drawing.Color.Black
            Me.lblEquip.Location = New System.Drawing.Point(8, 80)
            Me.lblEquip.Name = "lblEquip"
            Me.lblEquip.Size = New System.Drawing.Size(96, 18)
            Me.lblEquip.TabIndex = 11
            Me.lblEquip.Text = "Equipment Cost:"
            Me.lblEquip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEquipAdjust
            '
            Me.txtEquipAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtEquipAdjust, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEquipAdjust, "")
            Me.txtEquipAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEquipAdjust, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEquipAdjust, System.Drawing.Color.Empty)
            Me.txtEquipAdjust.Location = New System.Drawing.Point(224, 80)
            Me.Validator.SetMaxValue(Me.txtEquipAdjust, "")
            Me.Validator.SetMinValue(Me.txtEquipAdjust, "")
            Me.txtEquipAdjust.Name = "txtEquipAdjust"
            Me.Validator.SetRegularExpression(Me.txtEquipAdjust, "")
            Me.Validator.SetRequired(Me.txtEquipAdjust, False)
            Me.txtEquipAdjust.Size = New System.Drawing.Size(112, 22)
            Me.txtEquipAdjust.TabIndex = 4
            Me.txtEquipAdjust.Text = ""
            Me.txtEquipAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtEquipTarget
            '
            Me.txtEquipTarget.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtEquipTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtEquipTarget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEquipTarget, "")
            Me.txtEquipTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEquipTarget, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEquipTarget, System.Drawing.Color.Empty)
            Me.txtEquipTarget.Location = New System.Drawing.Point(336, 80)
            Me.Validator.SetMaxValue(Me.txtEquipTarget, "")
            Me.Validator.SetMinValue(Me.txtEquipTarget, "")
            Me.txtEquipTarget.Name = "txtEquipTarget"
            Me.Validator.SetRegularExpression(Me.txtEquipTarget, "")
            Me.Validator.SetRequired(Me.txtEquipTarget, False)
            Me.txtEquipTarget.Size = New System.Drawing.Size(120, 22)
            Me.txtEquipTarget.TabIndex = 5
            Me.txtEquipTarget.Text = ""
            Me.txtEquipTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtEquipBase
            '
            Me.txtEquipBase.BackColor = System.Drawing.SystemColors.Info
            Me.txtEquipBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtEquipBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEquipBase, "")
            Me.txtEquipBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtEquipBase.ForeColor = System.Drawing.SystemColors.GrayText
            Me.Validator.SetGotFocusBackColor(Me.txtEquipBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEquipBase, System.Drawing.Color.Empty)
            Me.txtEquipBase.Location = New System.Drawing.Point(104, 80)
            Me.Validator.SetMaxValue(Me.txtEquipBase, "")
            Me.Validator.SetMinValue(Me.txtEquipBase, "")
            Me.txtEquipBase.Name = "txtEquipBase"
            Me.txtEquipBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEquipBase, "")
            Me.Validator.SetRequired(Me.txtEquipBase, False)
            Me.txtEquipBase.Size = New System.Drawing.Size(120, 22)
            Me.txtEquipBase.TabIndex = 18
            Me.txtEquipBase.TabStop = False
            Me.txtEquipBase.Text = ""
            Me.txtEquipBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblBase
            '
            Me.lblBase.BackColor = System.Drawing.Color.Transparent
            Me.lblBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBase.ForeColor = System.Drawing.Color.Black
            Me.lblBase.Location = New System.Drawing.Point(120, 16)
            Me.lblBase.Name = "lblBase"
            Me.lblBase.Size = New System.Drawing.Size(72, 18)
            Me.lblBase.TabIndex = 6
            Me.lblBase.Text = "ราคาตั้งต้น"
            Me.lblBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBOQCode
            '
            Me.lblBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBOQCode.ForeColor = System.Drawing.Color.Black
            Me.lblBOQCode.Location = New System.Drawing.Point(8, 8)
            Me.lblBOQCode.Name = "lblBOQCode"
            Me.lblBOQCode.Size = New System.Drawing.Size(56, 18)
            Me.lblBOQCode.TabIndex = 1
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
            Me.txtBOQCode.Location = New System.Drawing.Point(64, 6)
            Me.Validator.SetMaxValue(Me.txtBOQCode, "")
            Me.Validator.SetMinValue(Me.txtBOQCode, "")
            Me.txtBOQCode.Name = "txtBOQCode"
            Me.txtBOQCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
            Me.Validator.SetRequired(Me.txtBOQCode, False)
            Me.txtBOQCode.Size = New System.Drawing.Size(96, 22)
            Me.txtBOQCode.TabIndex = 2
            Me.txtBOQCode.TabStop = False
            Me.txtBOQCode.Text = ""
            '
            'txtProjectName
            '
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.txtProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(344, 6)
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.txtProjectName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, False)
            Me.txtProjectName.Size = New System.Drawing.Size(352, 22)
            Me.txtProjectName.TabIndex = 5
            Me.txtProjectName.TabStop = False
            Me.txtProjectName.Text = ""
            '
            'lblProject
            '
            Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProject.ForeColor = System.Drawing.Color.Black
            Me.lblProject.Location = New System.Drawing.Point(168, 8)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(80, 18)
            Me.lblProject.TabIndex = 3
            Me.lblProject.Text = "โครงการประมูล:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'txtProjectCode
            '
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.txtProjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(248, 6)
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.txtProjectCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, False)
            Me.txtProjectCode.Size = New System.Drawing.Size(96, 22)
            Me.txtProjectCode.TabIndex = 4
            Me.txtProjectCode.TabStop = False
            Me.txtProjectCode.Text = ""
            '
            'MarkupDetailView
            '
            Me.Controls.Add(Me.lblBOQCode)
            Me.Controls.Add(Me.txtBOQCode)
            Me.Controls.Add(Me.txtProjectName)
            Me.Controls.Add(Me.lblProject)
            Me.Controls.Add(Me.grbMarkup)
            Me.Controls.Add(Me.txtProjectCode)
            Me.Name = "MarkupDetailView"
            Me.Size = New System.Drawing.Size(736, 496)
            CType(Me.tgCondition, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbMarkup.ResumeLayout(False)
            Me.grbSetting.ResumeLayout(False)
            Me.grbCondition.ResumeLayout(False)
            Me.grbSummary.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_markupConditionItem As MarkupConditionItem
        Private m_markup As Markup
        Private m_entity As BOQ
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_oldRow As TreeRow = Nothing
        Private m_item As MarkupConditionItem
        Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dst As DataGridTableStyle = Me.CreateConditionStyle()
            Dim dt As TreeTable = Me.GetConditionSchemaTable()
            m_treeManager = New TreeManager(dt, tgCondition)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            'WrapperArrayList.AddItemAddedHandler(dt, AddressOf ItemAdded)
            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            Me.Validator.DataTable = dt

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Private Function GetConditionSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("Condition")
            myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Min", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Max", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
            Return myDatatable
        End Function
        Private Function CreateConditionStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Condition"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "LineNumber"

            Dim csMin As New TreeTextColumn
            csMin.MappingName = "Min"
            csMin.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.MinHeaderText}")
            csMin.NullText = ""
            csMin.DataAlignment = HorizontalAlignment.Right
            csMin.Format = "#,###.##"
            csMin.TextBox.Name = "Min"
            csMin.ReadOnly = True

            Dim csMax As New TreeTextColumn
            csMax.MappingName = "Max"
            csMax.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.MaxHeaderText}")
            csMax.NullText = ""
            csMax.DataAlignment = HorizontalAlignment.Right
            csMax.Format = "#,###.##"
            csMax.TextBox.Name = "Max"

            Dim csPercent As New TreeTextColumn
            csPercent.MappingName = "Percent"
            csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.PercentHeaderText}")
            csPercent.NullText = ""
            csPercent.DataAlignment = HorizontalAlignment.Right
            csPercent.Format = "#,###.##"
            csPercent.TextBox.Name = "Percent"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csMin)
            dst.GridColumnStyles.Add(csMax)
            dst.GridColumnStyles.Add(csPercent)

            Return dst
        End Function
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
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Dim pe As New PropertyChangedEventArgs
                UpdateAmount(e)
            End If
            Me.m_treeManager.Treetable.AcceptChanges()
        End Sub
        Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
            If m_markupConditionItem Is Nothing Then
                Return
            End If
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_tableInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Tag Is Nothing Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "max"
                        SetMax(e)
                    Case "percent"
                        SetPercent(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), 2)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Me.m_markupConditionItem.Percent = value
            m_updating = False
        End Sub
        Public Sub SetMax(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
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
            Me.m_markupConditionItem.UpperBound = value
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

        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            Me.cmbCondition.SelectedIndex = 0
            Me.cmbSpecificValueUnit.SelectedIndex = 0
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbMarkup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.grbMarkup}")
            Me.grbSetting.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.grbSetting}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblName}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblNote}")
            Me.lblMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblMat}")
            Me.lblLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblLabor}")
            Me.lblEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblEquip}")
            Me.lblProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblProfit}")
            Me.lblBidPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblBidPrice}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblTarget.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblTarget}")
            Me.lblDirectCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblDirectCost}")
            Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblBOQCode}")
            Me.lblTotalOverhead.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblTotalOverhead}")
            Me.lblAdjust.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblAdjust}")
            Me.lblBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblBase}")
            Me.grbCondition.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.grbCondition}")
            Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.lblProject}")
            Me.rdCondition.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.rdCondition}")
            Me.rdSpecific.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.rdSpecific}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDetailView.grbSummary}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler rdCondition.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler rdSpecific.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtSpecificValue.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSpecificValue.Validated, AddressOf Me.TextHandler

            AddHandler cmbCondition.SelectedIndexChanged, AddressOf Me.ChangeProperty
            AddHandler cmbSpecificValueUnit.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtMatAdjust.Validated, AddressOf Me.TextHandler
            AddHandler txtLaborAdjust.Validated, AddressOf Me.TextHandler
            AddHandler txtEquipAdjust.Validated, AddressOf Me.TextHandler

            AddHandler txtMatAdjust.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtLaborAdjust.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtEquipAdjust.TextChanged, AddressOf Me.ChangeProperty


            AddHandler txtMatTarget.Validated, AddressOf Me.TextHandler
            AddHandler txtLaborTarget.Validated, AddressOf Me.TextHandler
            AddHandler txtEquipTarget.Validated, AddressOf Me.TextHandler

            AddHandler txtMatTarget.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtLaborTarget.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtEquipTarget.TextChanged, AddressOf Me.ChangeProperty
        End Sub

        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtspecificvalue"
                    If Not Me.m_markup Is Nothing Then
                        Dim txt As String = Me.txtSpecificValue.Text
                        txt = txt.Replace(",", "")
                        If txt.Length = 0 Then
                            Me.m_markup.Amount = 0
                        Else
                            Try
                                Me.m_markup.Amount = CDec(TextParser.Evaluate(txt))
                            Catch ex As Exception
                                Me.m_markup.Amount = 0
                            End Try
                        End If
                        Me.txtSpecificValue.Text = Configuration.FormatToString(Me.m_markup.Amount, DigitConfig.Price)
                        Me.m_markup.DistributedAmount = Me.m_markup.TotalAmount
                        UpdateMarkupAmount()
                    End If
                Case "txtmatadjust"
                    Dim txt As String = Me.txtMatAdjust.Text
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        Me.m_entity.MaterialMarkup = 0
                    Else
                        Try
                            Me.m_entity.MaterialMarkup = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            Me.m_entity.MaterialMarkup = 0
                        End Try
                    End If
                    Me.UpdateAmount()
                Case "txtlaboradjust"
                    Dim txt As String = Me.txtLaborAdjust.Text
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        Me.m_entity.LaborMarkup = 0
                    Else
                        Try
                            Me.m_entity.LaborMarkup = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            Me.m_entity.LaborMarkup = 0
                        End Try
                    End If
                    Me.UpdateAmount()
                Case "txtequipadjust"
                    Dim txt As String = Me.txtEquipAdjust.Text
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        Me.m_entity.EquipmentMarkup = 0
                    Else
                        Try
                            Me.m_entity.EquipmentMarkup = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            Me.m_entity.EquipmentMarkup = 0
                        End Try
                    End If
                    Me.UpdateAmount()

                Case "txtmattarget"
                    Dim txt As String = Me.txtMatTarget.Text
                    Dim afterAdjust As Decimal
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        afterAdjust = Me.m_entity.TargetMaterialCost
                    Else
                        Try
                            afterAdjust = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            afterAdjust = Me.m_entity.TargetMaterialCost
                        End Try
                    End If
                    Me.m_entity.MaterialMarkup = afterAdjust - Me.m_entity.MaterialCost
                    Me.UpdateAmount()
                Case "txtlabortarget"
                    Dim txt As String = Me.txtLaborTarget.Text
                    Dim afterAdjust As Decimal
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        afterAdjust = Me.m_entity.TargetLaborCost
                    Else
                        Try
                            afterAdjust = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            afterAdjust = Me.m_entity.TargetLaborCost
                        End Try
                    End If
                    Me.m_entity.LaborMarkup = afterAdjust - Me.m_entity.LaborCost
                    Me.UpdateAmount()
                Case "txtequiptarget"
                    Dim txt As String = Me.txtEquipTarget.Text
                    Dim afterAdjust As Decimal
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        afterAdjust = Me.m_entity.TargetEquipmentCost
                    Else
                        Try
                            afterAdjust = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            afterAdjust = Me.m_entity.TargetEquipmentCost
                        End Try
                    End If
                    Me.m_entity.EquipmentMarkup = afterAdjust - Me.m_entity.EquipmentCost
                    Me.UpdateAmount()
            End Select
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtBOQCode.Text = m_entity.Code
            txtProjectCode.Text = m_entity.Project.Code
            txtProjectName.Text = m_entity.Project.Name

            m_entity.MarkupCollection.PopulateAll(Me.tvMarkup)
            Me.tvMarkup.ExpandAll()

            UpdateAmount()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub UpdateAmount()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Me.txtMatBase.Text = Configuration.FormatToString(Me.m_entity.MaterialCost, DigitConfig.Price)
            Me.txtLaborBase.Text = Configuration.FormatToString(Me.m_entity.LaborCost, DigitConfig.Price)
            Me.txtEquipBase.Text = Configuration.FormatToString(Me.m_entity.EquipmentCost, DigitConfig.Price)
            Me.txtDirectBase.Text = Configuration.FormatToString(Me.m_entity.DirectCost, DigitConfig.Price)
            Me.txtProfitBase.Text = Configuration.FormatToString(Me.m_entity.Profit, DigitConfig.Price)
            Me.txtTotalBase.Text = Configuration.FormatToString(Me.m_entity.Overhead, DigitConfig.Price)
            Me.txtBidBase.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)

            Me.txtDirectAdjust.Text = Configuration.FormatToString(Me.m_entity.DirectCostMarkup, DigitConfig.Price)
            Me.txtBidAdjust.Text = Configuration.FormatToString(Me.m_entity.DirectCostMarkup, DigitConfig.Price)

            Me.txtMatAdjust.Text = Configuration.FormatToString(Me.m_entity.MaterialMarkup, DigitConfig.Price)
            Me.txtLaborAdjust.Text = Configuration.FormatToString(Me.m_entity.LaborMarkup, DigitConfig.Price)
            Me.txtEquipAdjust.Text = Configuration.FormatToString(Me.m_entity.EquipmentMarkup, DigitConfig.Price)

            Me.txtMatTarget.Text = Configuration.FormatToString(Me.m_entity.TargetMaterialCost, DigitConfig.Price)
            Me.txtLaborTarget.Text = Configuration.FormatToString(Me.m_entity.TargetLaborCost, DigitConfig.Price)
            Me.txtEquipTarget.Text = Configuration.FormatToString(Me.m_entity.TargetEquipmentCost, DigitConfig.Price)

            Me.txtDirectTarget.Text = Configuration.FormatToString(Me.m_entity.TargetDirectCost, DigitConfig.Price)
            Me.txtTotalTarget.Text = Configuration.FormatToString(Me.m_entity.Overhead, DigitConfig.Price)
            Me.txtProfitTarget.Text = Configuration.FormatToString(Me.m_entity.Profit, DigitConfig.Price)
            Me.txtBidTarget.Text = Configuration.FormatToString(Me.m_entity.TargetBidPrice, DigitConfig.Price)
            Me.m_isInitialized = flag
        End Sub
        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtname"
                    If Not Me.m_markup Is Nothing Then
                        Me.m_markup.Name = txtName.Text
                        UpdateNode()
                        dirtyFlag = True
                    End If
                Case "txtnote"
                    If Not Me.m_markup Is Nothing Then
                        Me.m_markup.Note = txtNote.Text
                        UpdateNode()
                        dirtyFlag = True
                    End If
                Case "rdcondition", "rdspecific"
                    If Not Me.m_markup Is Nothing Then
                        If rdCondition.Checked Then
                            ToggleCondition(False)
                            Me.m_markup.Condition.Value = 1
                            Me.txtSpecificValue.Text = ""
                            CodeDescription.ComboSelect(Me.cmbCondition, Me.m_markup.Condition)
                        Else
                            ToggleCondition(True)
                            Me.m_markup.Condition.Value = 0
                            Me.txtSpecificValue.Text = Configuration.FormatToString(Me.m_markup.Amount, DigitConfig.Price)
                            CodeDescription.ComboSelect(Me.cmbSpecificValueUnit, Me.m_markup.Unit)
                            Me.cmbCondition.SelectedIndex = -1
                        End If
                        UpdateMarkupCondition()
                        Me.m_markup.DistributedAmount = Me.m_markup.TotalAmount
                        UpdateMarkupAmount()
                        dirtyFlag = True
                    End If
                Case "txtspecificvalue"
                    If Not Me.m_markup Is Nothing Then
                        dirtyFlag = True
                    End If
                Case "cmbcondition"
                    If Not Me.m_markup Is Nothing Then
                        If Me.cmbCondition.SelectedItem Is Nothing Then
                            Return
                        End If
                        If TypeOf Me.cmbCondition.SelectedItem Is IdValuePair Then
                            Me.m_markup.Condition.Value = CType(Me.cmbCondition.SelectedItem, IdValuePair).Id
                        End If
                        UpdateMarkupCondition()
                        Me.m_markup.DistributedAmount = Me.m_markup.TotalAmount
                        UpdateMarkupAmount()
                        dirtyFlag = True
                    End If
                Case "cmbspecificvalueunit"
                    If Not Me.m_markup Is Nothing Then
                        Dim item As IdValuePair = CType(Me.cmbSpecificValueUnit.SelectedItem, IdValuePair)
                        Me.m_markup.Unit.Value = item.Id
                        Me.m_markup.DistributedAmount = Me.m_markup.TotalAmount
                        UpdateMarkupAmount()
                        dirtyFlag = True
                    End If
                Case "txtmatadjust"
                    dirtyFlag = True
                Case "txtlaboradjust"
                    dirtyFlag = True
                Case "txtequipadjust"
                    dirtyFlag = True
                Case "txtmattarget"
                    dirtyFlag = True
                Case "txtlabortarget"
                    dirtyFlag = True
                Case "txtequiptarget"
                    dirtyFlag = True
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub UpdateMarkupAmount()
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
            Me.UpdateAmount()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
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
                    UpdateEntityProperties()
                End If
            End Set
        End Property

        Public Overrides Sub Initialize()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbSpecificValueUnit, "CurrencyOrPercent")
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbCondition, "markup_condition", "code_value <> 0")
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub tgCondition_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgCondition.CurrentCellChanged
            Dim theRow As TreeRow = m_treeManager.SelectedRow
            If m_oldRow Is theRow Then
                Return
            End If
            If TypeOf theRow.Tag Is MarkupConditionItem Then
                m_markupConditionItem = CType(theRow.Tag, MarkupConditionItem)
            Else
                m_markupConditionItem = Nothing
            End If
            m_oldRow = m_treeManager.SelectedRow
        End Sub
        Private Sub tvMarkup_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMarkup.AfterSelect
            If TypeOf e.Node.Tag Is Markup Then
                Me.grbSetting.Enabled = True
                Dim myMarkup As Markup = CType(e.Node.Tag, Markup)
                Me.m_markup = myMarkup
                UpdateMarkup()
            ElseIf IsNumeric(e.Node.Tag) Then
                Me.m_markup = Nothing
                Me.grbSetting.Enabled = False
                UpdateType(CInt(e.Node.Tag))
            End If
        End Sub
        Private Sub ToggleCondition(ByVal specific As Boolean)
            Me.cmbSpecificValueUnit.Enabled = specific
            Me.txtSpecificValue.ReadOnly = Not specific
            Me.cmbCondition.Enabled = Not specific
            Me.tgCondition.Enabled = Not specific
            Me.ibtnAddCondition.Enabled = Not specific
            Me.ibtnDelCondition.Enabled = Not specific
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            If specific Then
                Me.cmbCondition.SelectedIndex = -1
                Me.cmbSpecificValueUnit.SelectedIndex = 0
            Else
                Me.cmbSpecificValueUnit.SelectedIndex = -1
                Me.cmbCondition.SelectedIndex = 0
            End If
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateMarkup()
            If m_markup Is Nothing Then
                Return
            End If
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtName.Text = m_markup.Name
            txtNote.Text = m_markup.Note
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
            Select Case Me.m_markup.Condition.Value
                Case 0
                    ToggleCondition(True)
                    Me.txtSpecificValue.Text = Configuration.FormatToString(Me.m_markup.Amount, DigitConfig.Price)
                    Me.rdSpecific.Checked = True
                    CodeDescription.ComboSelect(Me.cmbSpecificValueUnit, Me.m_markup.Unit)
                    Me.cmbCondition.SelectedIndex = -1
                Case Else
                    ToggleCondition(False)
                    Me.txtSpecificValue.Text = ""
                    Me.rdCondition.Checked = True
                    Me.cmbSpecificValueUnit.SelectedIndex = -1
                    CodeDescription.ComboSelect(Me.cmbCondition, Me.m_markup.Condition)
            End Select
            UpdateMarkupCondition()
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateMarkupCondition()
            If m_markup Is Nothing Then
                Return
            End If
            Me.m_tableInitialized = False
            If m_markup.Condition.Value = 0 Then
                m_treeManager.Treetable.Clear()
            Else
                Me.m_markup.PopulateCondition(m_treeManager.Treetable)
            End If
            Me.m_tableInitialized = True
        End Sub
        Private Sub UpdateType(ByVal id As Integer)
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Dim mt As New MarkupType(id)
            txtName.Text = mt.Description
            txtNote.Text = ""
            Me.cmbSpecificValueUnit.SelectedIndex = -1
            Me.cmbCondition.SelectedIndex = -1
            Me.txtSpecificValue.Text = ""
            Me.rdCondition.Checked = False
            Me.rdSpecific.Checked = False
            m_treeManager.Treetable.Clear()
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_entity.MarkupCollection.GetAmountForType(id), DigitConfig.Price)
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateNode()
            Me.tvMarkup.SelectedNode.Text = m_markup.ToString
        End Sub
        Private Sub ClearMarkup()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtName.Text = ""
            txtNote.Text = ""
            Me.m_isInitialized = flag
        End Sub

        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim node As TreeNode = Me.tvMarkup.SelectedNode
            If node Is Nothing Then
                Return
            End If
            Dim parentTypeId As Integer
            Dim parentNode As TreeNode
            If TypeOf node.Tag Is Markup Then
                parentTypeId = CType(node.Tag, Markup).Type.Value
                parentNode = node.Parent
            ElseIf IsNumeric(node.Tag) Then
                parentTypeId = CInt(node.Tag)
                parentNode = node
            End If
            Dim newMarkup As New Markup
            newMarkup.Type.Value = parentTypeId
            Dim newNode As TreeNode = parentNode.Nodes.Add("<NEW>")
            newNode.Tag = newMarkup
            Me.m_markup = newMarkup
            Me.m_entity.MarkupCollection.Add(newMarkup)
            Me.tvMarkup.SelectedNode = newNode
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            If m_markup Is Nothing Then
                Return
            End If
            If m_markup.Status.Value >= 3 Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                msgServ.ShowMessageFormatted("${res:Global.Error.MarkupWasRefCannotDelete}", New String() {m_markup.ToString})
                Return
            End If
            Dim node As TreeNode = Me.tvMarkup.SelectedNode
            If node Is Nothing OrElse node Is Me.tvMarkup.Nodes(0) Then
                Return
            End If
            Me.m_entity.MarkupCollection.Remove(m_markup)
            Me.tvMarkup.SelectedNode.Remove()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
        End Sub
        Private Sub ibtnAddCondition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnAddCondition.Click
            If m_markup Is Nothing Then
                Return
            End If
            If m_markup.Condition.Value = 0 Then
                Return
            End If
            Dim msgSvc As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
            Dim newItem As New MarkupConditionItem
            If m_markup.ConditionItems.Count = 0 Then
                'ไม่มี Condition
                newItem.LowerBound = 0
                newItem.UpperBound = 0
            Else
                Dim lastCond As MarkupConditionItem = m_markup.ConditionItems(m_markup.ConditionItems.Count - 1)
                If lastCond.UpperBound <= 0 Then
                    msgSvc.ShowMessage("${res:Global.Error.LastMarkupConitionUpperBoundEqualsTOOrLessThanZero}")
                    Return
                End If
                If lastCond.UpperBound = lastCond.LowerBound Then
                    msgSvc.ShowMessage("${res:Global.Error.LastMarkupConitionUpperBoundEqualsLowerBound}")
                    Return
                End If
                newItem.LowerBound = lastCond.UpperBound
                newItem.UpperBound = lastCond.UpperBound
            End If
            m_markup.ConditionItems.Add(newItem)
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
            UpdateMarkupCondition()
            UpdateAmount()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelCondition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnDelCondition.Click
            If m_markup Is Nothing Then
                Return
            End If
            Dim msgSvc As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
            If m_markup.ConditionItems.Count = 0 Then
                'ไม่มี Condition
                Return
            Else
                Dim lastCond As MarkupConditionItem = m_markup.ConditionItems(m_markup.ConditionItems.Count - 1)
                m_markup.ConditionItems.Remove(lastCond)
            End If
            UpdateMarkupCondition()
            UpdateAmount()
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Event of Button controls"

#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "IKeyReceiver"
        Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
            Select Case keyPressed
                Case Keys.Insert
                    If Me.tvMarkup.Focused Then
                        ibtnBlank_Click(Nothing, Nothing)
                        Return True
                    ElseIf Me.tgCondition.Focused Then
                        ibtnAddCondition_Click(Nothing, Nothing)
                        Return True
                    End If
                Case Keys.Delete
                    If Me.tvMarkup.Focused Then
                        ibtnDelRow_Click(Nothing, Nothing)
                        Return True
                    ElseIf Me.tgCondition.Focused Then
                        ibtnDelCondition_Click(Nothing, Nothing)
                        Return True
                    End If
                Case Else
                    Return False
            End Select
            Return False
        End Function
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

    End Class
End Namespace