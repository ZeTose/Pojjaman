Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class LaborDetailView
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
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents tgSelectedMat As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblCost As System.Windows.Forms.Label
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblSelectMat As System.Windows.Forms.Label
        Friend WithEvents txtUnitCode As System.Windows.Forms.TextBox
        Friend WithEvents txtUnitName As System.Windows.Forms.TextBox
        Friend WithEvents txtCost As System.Windows.Forms.TextBox
        Friend WithEvents btnUnitFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnUnitEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents lblCostDate As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtCostDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpCostDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaborDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.txtCostDate = New System.Windows.Forms.TextBox
            Me.dtpCostDate = New System.Windows.Forms.DateTimePicker
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnUnitFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnUnitEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.tgSelectedMat = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblAltName = New System.Windows.Forms.Label
            Me.txtAltName = New System.Windows.Forms.TextBox
            Me.lblSelectMat = New System.Windows.Forms.Label
            Me.lblCost = New System.Windows.Forms.Label
            Me.lblUnit = New System.Windows.Forms.Label
            Me.lblBaht = New System.Windows.Forms.Label
            Me.txtUnitCode = New System.Windows.Forms.TextBox
            Me.txtUnitName = New System.Windows.Forms.TextBox
            Me.txtCost = New System.Windows.Forms.TextBox
            Me.lblCostDate = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.lblGroup = New System.Windows.Forms.Label
            Me.txtGroupCode = New System.Windows.Forms.TextBox
            Me.txtGroupName = New System.Windows.Forms.TextBox
            Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDetail.SuspendLayout()
            CType(Me.tgSelectedMat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.txtCostDate)
            Me.grbDetail.Controls.Add(Me.dtpCostDate)
            Me.grbDetail.Controls.Add(Me.lblStatus)
            Me.grbDetail.Controls.Add(Me.btnUnitFind)
            Me.grbDetail.Controls.Add(Me.btnUnitEdit)
            Me.grbDetail.Controls.Add(Me.tgSelectedMat)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblAltName)
            Me.grbDetail.Controls.Add(Me.txtAltName)
            Me.grbDetail.Controls.Add(Me.lblSelectMat)
            Me.grbDetail.Controls.Add(Me.lblCost)
            Me.grbDetail.Controls.Add(Me.lblUnit)
            Me.grbDetail.Controls.Add(Me.lblBaht)
            Me.grbDetail.Controls.Add(Me.txtUnitCode)
            Me.grbDetail.Controls.Add(Me.txtUnitName)
            Me.grbDetail.Controls.Add(Me.txtCost)
            Me.grbDetail.Controls.Add(Me.lblCostDate)
            Me.grbDetail.Controls.Add(Me.lblGroup)
            Me.grbDetail.Controls.Add(Me.txtGroupCode)
            Me.grbDetail.Controls.Add(Me.txtGroupName)
            Me.grbDetail.Controls.Add(Me.btnGroupEdit)
            Me.grbDetail.Controls.Add(Me.btnGroupFind)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(656, 464)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลค่าแรง:"
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(192, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 324
            Me.chkAutorun.TabStop = False
            '
            'txtCostDate
            '
            Me.Validator.SetDataType(Me.txtCostDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtCostDate, "")
            Me.ErrorProvider1.SetError(Me.txtCostDate, "กำหนดวันที่ของราคา")
            Me.Validator.SetGotFocusBackColor(Me.txtCostDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostDate, System.Drawing.Color.Empty)
            Me.txtCostDate.Location = New System.Drawing.Point(312, 144)
            Me.Validator.SetMaxValue(Me.txtCostDate, "")
            Me.Validator.SetMinValue(Me.txtCostDate, "")
            Me.txtCostDate.Name = "txtCostDate"
            Me.Validator.SetRegularExpression(Me.txtCostDate, "")
            Me.Validator.SetRequired(Me.txtCostDate, False)
            Me.txtCostDate.Size = New System.Drawing.Size(107, 21)
            Me.txtCostDate.TabIndex = 15
            Me.txtCostDate.Text = ""
            '
            'dtpCostDate
            '
            Me.dtpCostDate.Location = New System.Drawing.Point(312, 144)
            Me.dtpCostDate.Name = "dtpCostDate"
            Me.dtpCostDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpCostDate.TabIndex = 16
            Me.dtpCostDate.TabStop = False
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Enabled = False
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblStatus.Location = New System.Drawing.Point(3, 444)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 21
            Me.lblStatus.Text = "lblStatus"
            '
            'btnUnitFind
            '
            Me.btnUnitFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnUnitFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnUnitFind.Image = CType(resources.GetObject("btnUnitFind.Image"), System.Drawing.Image)
            Me.btnUnitFind.Location = New System.Drawing.Point(392, 96)
            Me.btnUnitFind.Name = "btnUnitFind"
            Me.btnUnitFind.Size = New System.Drawing.Size(24, 23)
            Me.btnUnitFind.TabIndex = 9
            Me.btnUnitFind.TabStop = False
            Me.btnUnitFind.ThemedImage = CType(resources.GetObject("btnUnitFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnUnitEdit
            '
            Me.btnUnitEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnUnitEdit.Image = CType(resources.GetObject("btnUnitEdit.Image"), System.Drawing.Image)
            Me.btnUnitEdit.Location = New System.Drawing.Point(416, 96)
            Me.btnUnitEdit.Name = "btnUnitEdit"
            Me.btnUnitEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnUnitEdit.TabIndex = 10
            Me.btnUnitEdit.TabStop = False
            Me.btnUnitEdit.ThemedImage = CType(resources.GetObject("btnUnitEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'tgSelectedMat
            '
            Me.tgSelectedMat.AllowNew = True
            Me.tgSelectedMat.AllowSorting = False
            Me.tgSelectedMat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgSelectedMat.AutoColumnResize = True
            Me.tgSelectedMat.CaptionVisible = False
            Me.tgSelectedMat.Cellchanged = False
            Me.tgSelectedMat.DataMember = ""
            Me.tgSelectedMat.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgSelectedMat.Location = New System.Drawing.Point(8, 208)
            Me.tgSelectedMat.Name = "tgSelectedMat"
            Me.tgSelectedMat.Size = New System.Drawing.Size(640, 216)
            Me.tgSelectedMat.SortingArrowColor = System.Drawing.Color.Red
            Me.tgSelectedMat.TabIndex = 19
            Me.tgSelectedMat.TreeManager = Nothing
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(80, 48)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(504, 21)
            Me.txtName.TabIndex = 3
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(64, 18)
            Me.lblName.TabIndex = 2
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(64, 18)
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
            Me.txtCode.Location = New System.Drawing.Point(80, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(112, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.ForeColor = System.Drawing.Color.Black
            Me.lblAltName.Location = New System.Drawing.Point(8, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(64, 18)
            Me.lblAltName.TabIndex = 4
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAltName
            '
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAltName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(80, 72)
            Me.txtAltName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(504, 21)
            Me.txtAltName.TabIndex = 5
            Me.txtAltName.Text = ""
            '
            'lblSelectMat
            '
            Me.lblSelectMat.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSelectMat.ForeColor = System.Drawing.Color.Black
            Me.lblSelectMat.Location = New System.Drawing.Point(8, 192)
            Me.lblSelectMat.Name = "lblSelectMat"
            Me.lblSelectMat.Size = New System.Drawing.Size(216, 18)
            Me.lblSelectMat.TabIndex = 17
            Me.lblSelectMat.Text = "รายการ/หมวดวัสดุที่ใช้ค่าแรงนี้"
            Me.lblSelectMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCost
            '
            Me.lblCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCost.ForeColor = System.Drawing.Color.Black
            Me.lblCost.Location = New System.Drawing.Point(8, 144)
            Me.lblCost.Name = "lblCost"
            Me.lblCost.Size = New System.Drawing.Size(64, 18)
            Me.lblCost.TabIndex = 11
            Me.lblCost.Text = "ราคา:"
            Me.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnit
            '
            Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit.ForeColor = System.Drawing.Color.Black
            Me.lblUnit.Location = New System.Drawing.Point(8, 96)
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Size = New System.Drawing.Size(64, 18)
            Me.lblUnit.TabIndex = 6
            Me.lblUnit.Text = "หน่วย:"
            Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht
            '
            Me.lblBaht.AutoSize = True
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.ForeColor = System.Drawing.Color.Black
            Me.lblBaht.Location = New System.Drawing.Point(200, 144)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(25, 17)
            Me.lblBaht.TabIndex = 13
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUnitCode
            '
            Me.Validator.SetDataType(Me.txtUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnitCode, "")
            Me.txtUnitCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtUnitCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
            Me.txtUnitCode.Location = New System.Drawing.Point(80, 96)
            Me.txtUnitCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtUnitCode, "")
            Me.Validator.SetMinValue(Me.txtUnitCode, "")
            Me.txtUnitCode.Name = "txtUnitCode"
            Me.Validator.SetRegularExpression(Me.txtUnitCode, "")
            Me.Validator.SetRequired(Me.txtUnitCode, True)
            Me.txtUnitCode.Size = New System.Drawing.Size(112, 21)
            Me.txtUnitCode.TabIndex = 7
            Me.txtUnitCode.Text = ""
            '
            'txtUnitName
            '
            Me.txtUnitName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtUnitName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnitName, "")
            Me.txtUnitName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
            Me.txtUnitName.Location = New System.Drawing.Point(192, 96)
            Me.Validator.SetMaxValue(Me.txtUnitName, "")
            Me.Validator.SetMinValue(Me.txtUnitName, "")
            Me.txtUnitName.Name = "txtUnitName"
            Me.txtUnitName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtUnitName, "")
            Me.Validator.SetRequired(Me.txtUnitName, False)
            Me.txtUnitName.Size = New System.Drawing.Size(200, 21)
            Me.txtUnitName.TabIndex = 8
            Me.txtUnitName.TabStop = False
            Me.txtUnitName.Text = ""
            '
            'txtCost
            '
            Me.Validator.SetDataType(Me.txtCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtCost, "")
            Me.txtCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCost, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCost, System.Drawing.Color.Empty)
            Me.txtCost.Location = New System.Drawing.Point(80, 144)
            Me.Validator.SetMaxValue(Me.txtCost, "")
            Me.Validator.SetMinValue(Me.txtCost, "")
            Me.txtCost.Name = "txtCost"
            Me.Validator.SetRegularExpression(Me.txtCost, "")
            Me.Validator.SetRequired(Me.txtCost, False)
            Me.txtCost.Size = New System.Drawing.Size(112, 21)
            Me.txtCost.TabIndex = 12
            Me.txtCost.Text = ""
            Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCostDate
            '
            Me.lblCostDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCostDate.ForeColor = System.Drawing.Color.Black
            Me.lblCostDate.Location = New System.Drawing.Point(232, 144)
            Me.lblCostDate.Name = "lblCostDate"
            Me.lblCostDate.Size = New System.Drawing.Size(72, 18)
            Me.lblCostDate.TabIndex = 14
            Me.lblCostDate.Text = "ราคา ณ วันที่ :"
            Me.lblCostDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'lblGroup
            '
            Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Black
            Me.lblGroup.Location = New System.Drawing.Point(8, 120)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(64, 18)
            Me.lblGroup.TabIndex = 6
            Me.lblGroup.Text = "กลุ่ม:"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGroupCode
            '
            Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupCode, "")
            Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGroupCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.txtGroupCode.Location = New System.Drawing.Point(80, 120)
            Me.txtGroupCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtGroupCode, "")
            Me.Validator.SetMinValue(Me.txtGroupCode, "")
            Me.txtGroupCode.Name = "txtGroupCode"
            Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
            Me.Validator.SetRequired(Me.txtGroupCode, True)
            Me.txtGroupCode.Size = New System.Drawing.Size(112, 21)
            Me.txtGroupCode.TabIndex = 7
            Me.txtGroupCode.Text = ""
            '
            'txtGroupName
            '
            Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupName, "")
            Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.txtGroupName.Location = New System.Drawing.Point(192, 120)
            Me.Validator.SetMaxValue(Me.txtGroupName, "")
            Me.Validator.SetMinValue(Me.txtGroupName, "")
            Me.txtGroupName.Name = "txtGroupName"
            Me.txtGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupName, "")
            Me.Validator.SetRequired(Me.txtGroupName, False)
            Me.txtGroupName.Size = New System.Drawing.Size(200, 21)
            Me.txtGroupName.TabIndex = 8
            Me.txtGroupName.TabStop = False
            Me.txtGroupName.Text = ""
            '
            'btnGroupEdit
            '
            Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupEdit.Image = CType(resources.GetObject("btnGroupEdit.Image"), System.Drawing.Image)
            Me.btnGroupEdit.Location = New System.Drawing.Point(416, 120)
            Me.btnGroupEdit.Name = "btnGroupEdit"
            Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupEdit.TabIndex = 10
            Me.btnGroupEdit.TabStop = False
            Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnGroupFind
            '
            Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnGroupFind.Image = CType(resources.GetObject("btnGroupFind.Image"), System.Drawing.Image)
            Me.btnGroupFind.Location = New System.Drawing.Point(392, 120)
            Me.btnGroupFind.Name = "btnGroupFind"
            Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupFind.TabIndex = 9
            Me.btnGroupFind.TabStop = False
            Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'LaborDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "LaborDetailView"
            Me.Size = New System.Drawing.Size(672, 480)
            Me.grbDetail.ResumeLayout(False)
            CType(Me.tgSelectedMat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.txtNameAlert}"))

            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblAltName}")
            Me.Validator.SetDisplayName(txtAltName, lblAltName.Text)

            Me.lblCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblCost}")
            Me.Validator.SetDisplayName(txtCost, lblCost.Text)

            Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblUnit}")
            Me.Validator.SetDisplayName(Me.txtUnitCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.txtUnitCodeAlert}"))

            Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblGroup}")
            Me.Validator.SetDisplayName(Me.txtGroupCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.txtGroupCodeAlert}"))

            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblSelectMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblSelectMat}")
            Me.lblCostDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.lblCostDate}")
            Me.Validator.SetDisplayName(Me.txtCostDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LaborDetailView.txtCostDateAlert}"))
        End Sub
#End Region

#Region "Member"
        Private m_entity As New Labor
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = Labor.GetLCISchemaTable
            Dim dst As DataGridTableStyle = Me.CreateTableStyle
            m_treeManager = New TreeManager(dt, Me.tgSelectedMat)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            Me.tgSelectedMat.AllowNew = False

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "LciList"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "lcil_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatLabDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "lcil_linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatLabDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatLabDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Name"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csName.ReadOnly = True

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csName)
            Return dst
        End Function
#End Region

#Region "Method"
    Public Sub SetStatus()
     MyBase.SetStatusBarMessage()
    End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtCost.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtUnitCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtGroupCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtCostDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpCostDate.ValueChanged, AddressOf Me.ChangeProperty

        End Sub
#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled Then
                For Each ctrl As Control In grbDetail.Controls
                    ctrl.Enabled = False
                Next
            Else
                For Each ctrl As Control In grbDetail.Controls
                    ctrl.Enabled = True
                Next
            End If

        End Sub

        ' เคลียร์ข้อมูลแรงงานใน control
        Public Overrides Sub ClearDetail()
            lblStatus.Text = ""
            For Each ctrl As Control In grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            txtCostDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpCostDate.Value = Date.Now
        End Sub

        ' แสดงค่าข้อมูลของแรงงานลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()

            If m_entity Is Nothing Then
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ ของแรงงานเข้ากับ control
            With Me
                .txtCode.Text = .m_entity.Code
                .txtName.Text = .m_entity.Name
                ' Auto gen code
                m_oldCode = m_entity.Code
                Me.chkAutorun.Checked = Me.m_entity.AutoGen
                Me.UpdateAutogenStatus()

                .txtAltName.Text = .m_entity.AlternateName

                .txtCost.Text = Configuration.FormatToString(Me.m_entity.Cost, DigitConfig.Cost)

                Me.m_treeManager.Treetable = Me.m_entity.GetLCIListTable

                ' ToolGroup ...
                If Not .m_entity.Group Is Nothing Then
                    .txtGroupCode.Text = .m_entity.Group.Code
                    .txtGroupName.Text = .m_entity.Group.Name
                End If

                If Not .m_entity.MemoryUnit Is Nothing Then
                    .txtUnitCode.Text = .m_entity.MemoryUnit.Code
                    .txtUnitName.Text = .m_entity.MemoryUnit.Name
                End If
            End With

            dtpCostDate.Value = MinDateToNow(Me.m_entity.CostDate)
            txtCostDate.Text = MinDateToNull(Me.m_entity.CostDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

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
                Me.m_entity = CType(Value, Labor)
                Me.m_entity.Type = "1"
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property

        Public Overrides Sub Initialize()

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
                Case "txtaltname"
                    Me.m_entity.AlternateName = Me.txtAltName.Text
                    dirtyFlag = True
                Case "txtcost"
                    If txtCost.TextLength > 0 Then
                        Me.m_entity.Cost = CDec(Me.txtCost.Text)
                    Else
                        Me.m_entity.Cost = Nothing
                    End If
                    dirtyFlag = True
                Case "txtunitcode"
                    dirtyFlag = Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.MemoryUnit)
                Case "txtgroupcode"
                    dirtyFlag = LaborGroup.GetLaborGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)
                Case "dtpcostdate"
                    txtCostDate.Text = MinDateToNull(dtpCostDate.Value, "")
                    Me.m_entity.CostDate = Me.dtpCostDate.Value
                    dirtyFlag = True
                Case "txtcostdate"
                    Dim dt As DateTime = StringToDate(txtCostDate, dtpCostDate)
                    Me.m_entity.CostDate = dt
                    dirtyFlag = True
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            SetStatus()
            CheckFormEnable()
        End Sub
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


        End Sub
#End Region

#Region "Event of Button Controls"
        Private Sub btnUnitEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Unit)
        End Sub

        Private Sub btnUnitFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
        End Sub

        Private Sub SetUnit(ByVal e As ISimpleEntity)
            Me.txtUnitCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty Or _
                Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.MemoryUnit)
        End Sub

        Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New LaborGroup)
        End Sub

        Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New LaborGroup, AddressOf SetLaborGroup)
        End Sub

        Private Sub SetLaborGroup(ByVal e As ISimpleEntity)
            Me.txtGroupCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or _
            LaborGroup.GetLaborGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
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

    End Class

End Namespace
