Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class EqMaintenanceDetailFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblBlank As System.Windows.Forms.Label
        Friend WithEvents txtBlank As System.Windows.Forms.TextBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents btnToCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
        Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnToCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblToCC As System.Windows.Forms.Label
        Friend WithEvents btnToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowEquipment As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEquipmentName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowEquipmentDiaog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEquipmentCode As System.Windows.Forms.TextBox
        Friend WithEvents lblEquipment As System.Windows.Forms.Label
        Friend WithEvents grbDueDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents grbPV As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPVStart As System.Windows.Forms.Label
        Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblPVEnd As System.Windows.Forms.Label
        Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EqMaintenanceDetailFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblBlank = New System.Windows.Forms.Label
            Me.txtBlank = New System.Windows.Forms.TextBox
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowEquipment = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtEquipmentName = New System.Windows.Forms.TextBox
            Me.ibtnShowEquipmentDiaog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtEquipmentCode = New System.Windows.Forms.TextBox
            Me.lblEquipment = New System.Windows.Forms.Label
            Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSupplierCode = New System.Windows.Forms.TextBox
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
            Me.btnToCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtToCCPersonName = New System.Windows.Forms.TextBox
            Me.lblToCCPerson = New System.Windows.Forms.Label
            Me.txtToCostCenterName = New System.Windows.Forms.TextBox
            Me.btnToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnToCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblToCC = New System.Windows.Forms.Label
            Me.btnToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDueDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDueDateStart = New System.Windows.Forms.TextBox
            Me.txtDueDateEnd = New System.Windows.Forms.TextBox
            Me.lblDueDateStart = New System.Windows.Forms.Label
            Me.lblDueDateEnd = New System.Windows.Forms.Label
            Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbPV = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtPVCodeEnd = New System.Windows.Forms.TextBox
            Me.lblPVEnd = New System.Windows.Forms.Label
            Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPVCodeStart = New System.Windows.Forms.TextBox
            Me.lblPVStart = New System.Windows.Forms.Label
            Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.grbDueDate.SuspendLayout()
            Me.grbPV.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(224, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbItem)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.Controls.Add(Me.grbDueDate)
            Me.grbDetail.Controls.Add(Me.grbPV)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 0)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(712, 248)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ค้นหา"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(8, 120)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(230, 72)
            Me.grbDocDate.TabIndex = 2
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
            Me.txtDocDateStart.TabIndex = 0
            Me.txtDocDateStart.Text = ""
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
            Me.txtDocDateEnd.TabIndex = 1
            Me.txtDocDateEnd.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 8
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 39)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateEnd.TabIndex = 9
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateStart.TabIndex = 10
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateEnd.TabIndex = 11
            Me.dtpDocDateEnd.TabStop = False
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(624, 216)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(544, 216)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.lblBlank)
            Me.grbItem.Controls.Add(Me.txtBlank)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(8, 192)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(528, 48)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "สิ่งที่ซื้อ"
            '
            'lblBlank
            '
            Me.lblBlank.BackColor = System.Drawing.Color.Transparent
            Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblBlank.Location = New System.Drawing.Point(8, 16)
            Me.lblBlank.Name = "lblBlank"
            Me.lblBlank.Size = New System.Drawing.Size(96, 18)
            Me.lblBlank.TabIndex = 208
            Me.lblBlank.Text = "Blank:"
            Me.lblBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBlank
            '
            Me.Validator.SetDataType(Me.txtBlank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBlank, "")
            Me.Validator.SetGotFocusBackColor(Me.txtBlank, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBlank, System.Drawing.Color.Empty)
            Me.txtBlank.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtBlank, "")
            Me.Validator.SetMinValue(Me.txtBlank, "")
            Me.txtBlank.Name = "txtBlank"
            Me.Validator.SetRegularExpression(Me.txtBlank, "")
            Me.Validator.SetRequired(Me.txtBlank, False)
            Me.txtBlank.Size = New System.Drawing.Size(392, 20)
            Me.txtBlank.TabIndex = 0
            Me.txtBlank.Text = ""
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.ibtnShowEquipment)
            Me.grbMainDetail.Controls.Add(Me.txtEquipmentName)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowEquipmentDiaog)
            Me.grbMainDetail.Controls.Add(Me.txtEquipmentCode)
            Me.grbMainDetail.Controls.Add(Me.lblEquipment)
            Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
            Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
            Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
            Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
            Me.grbMainDetail.Controls.Add(Me.lblSupplier)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.txtToCCPersonCode)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtToCCPersonName)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblToCCPerson)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.btnToCCPersonPanel)
            Me.grbMainDetail.Controls.Add(Me.lblToCC)
            Me.grbMainDetail.Controls.Add(Me.btnToCCPersonDialog)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(696, 104)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'ibtnShowEquipment
            '
            Me.ibtnShowEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowEquipment.Image = CType(resources.GetObject("ibtnShowEquipment.Image"), System.Drawing.Image)
            Me.ibtnShowEquipment.Location = New System.Drawing.Point(314, 40)
            Me.ibtnShowEquipment.Name = "ibtnShowEquipment"
            Me.ibtnShowEquipment.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowEquipment.TabIndex = 279
            Me.ibtnShowEquipment.TabStop = False
            Me.ibtnShowEquipment.ThemedImage = CType(resources.GetObject("ibtnShowEquipment.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEquipmentName
            '
            Me.txtEquipmentName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtEquipmentName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEquipmentName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
            Me.txtEquipmentName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtEquipmentName, "")
            Me.Validator.SetMinValue(Me.txtEquipmentName, "")
            Me.txtEquipmentName.Name = "txtEquipmentName"
            Me.txtEquipmentName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEquipmentName, "")
            Me.Validator.SetRequired(Me.txtEquipmentName, False)
            Me.txtEquipmentName.Size = New System.Drawing.Size(96, 20)
            Me.txtEquipmentName.TabIndex = 280
            Me.txtEquipmentName.TabStop = False
            Me.txtEquipmentName.Text = ""
            '
            'ibtnShowEquipmentDiaog
            '
            Me.ibtnShowEquipmentDiaog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowEquipmentDiaog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowEquipmentDiaog.Image = CType(resources.GetObject("ibtnShowEquipmentDiaog.Image"), System.Drawing.Image)
            Me.ibtnShowEquipmentDiaog.Location = New System.Drawing.Point(288, 40)
            Me.ibtnShowEquipmentDiaog.Name = "ibtnShowEquipmentDiaog"
            Me.ibtnShowEquipmentDiaog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowEquipmentDiaog.TabIndex = 278
            Me.ibtnShowEquipmentDiaog.TabStop = False
            Me.ibtnShowEquipmentDiaog.ThemedImage = CType(resources.GetObject("ibtnShowEquipmentDiaog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEquipmentCode
            '
            Me.txtEquipmentCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtEquipmentCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEquipmentCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
            Me.txtEquipmentCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtEquipmentCode, "")
            Me.Validator.SetMinValue(Me.txtEquipmentCode, "")
            Me.txtEquipmentCode.Name = "txtEquipmentCode"
            Me.Validator.SetRegularExpression(Me.txtEquipmentCode, "")
            Me.Validator.SetRequired(Me.txtEquipmentCode, False)
            Me.txtEquipmentCode.Size = New System.Drawing.Size(80, 20)
            Me.txtEquipmentCode.TabIndex = 1
            Me.txtEquipmentCode.Text = ""
            '
            'lblEquipment
            '
            Me.lblEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEquipment.Location = New System.Drawing.Point(8, 40)
            Me.lblEquipment.Name = "lblEquipment"
            Me.lblEquipment.Size = New System.Drawing.Size(104, 18)
            Me.lblEquipment.TabIndex = 277
            Me.lblEquipment.Text = "เครื่องจักร:"
            Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSupplierPanel
            '
            Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierPanel.Image = CType(resources.GetObject("btnSupplierPanel.Image"), System.Drawing.Image)
            Me.btnSupplierPanel.Location = New System.Drawing.Point(640, 64)
            Me.btnSupplierPanel.Name = "btnSupplierPanel"
            Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierPanel.TabIndex = 206
            Me.btnSupplierPanel.TabStop = False
            Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(440, 64)
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, False)
            Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
            Me.txtSupplierCode.TabIndex = 5
            Me.txtSupplierCode.Text = ""
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(520, 64)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(96, 20)
            Me.txtSupplierName.TabIndex = 205
            Me.txtSupplierName.TabStop = False
            Me.txtSupplierName.Text = ""
            '
            'btnSupplierDialog
            '
            Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierDialog.Image = CType(resources.GetObject("btnSupplierDialog.Image"), System.Drawing.Image)
            Me.btnSupplierDialog.Location = New System.Drawing.Point(616, 64)
            Me.btnSupplierDialog.Name = "btnSupplierDialog"
            Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierDialog.TabIndex = 207
            Me.btnSupplierDialog.TabStop = False
            Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSupplier
            '
            Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblSupplier.Location = New System.Drawing.Point(344, 64)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(88, 18)
            Me.lblSupplier.TabIndex = 204
            Me.lblSupplier.Text = "ผู้ขาย:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(440, 40)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(226, 21)
            Me.cmbStatus.TabIndex = 4
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(344, 40)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(88, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtToCCPersonCode
            '
            Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
            Me.txtToCCPersonCode.Location = New System.Drawing.Point(440, 16)
            Me.Validator.SetMaxValue(Me.txtToCCPersonCode, "")
            Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
            Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
            Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
            Me.Validator.SetRequired(Me.txtToCCPersonCode, False)
            Me.txtToCCPersonCode.Size = New System.Drawing.Size(80, 20)
            Me.txtToCCPersonCode.TabIndex = 3
            Me.txtToCCPersonCode.Text = ""
            '
            'btnToCostCenterPanel
            '
            Me.btnToCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterPanel.Image = CType(resources.GetObject("btnToCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnToCostCenterPanel.Location = New System.Drawing.Point(314, 64)
            Me.btnToCostCenterPanel.Name = "btnToCostCenterPanel"
            Me.btnToCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterPanel.TabIndex = 199
            Me.btnToCostCenterPanel.TabStop = False
            Me.btnToCostCenterPanel.ThemedImage = CType(resources.GetObject("btnToCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.txtToCostCenterCode.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
            Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
            Me.txtToCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtToCostCenterCode.TabIndex = 2
            Me.txtToCostCenterCode.Text = ""
            '
            'txtToCCPersonName
            '
            Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
            Me.txtToCCPersonName.Location = New System.Drawing.Point(520, 16)
            Me.Validator.SetMaxValue(Me.txtToCCPersonName, "")
            Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
            Me.txtToCCPersonName.Name = "txtToCCPersonName"
            Me.txtToCCPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
            Me.Validator.SetRequired(Me.txtToCCPersonName, False)
            Me.txtToCCPersonName.Size = New System.Drawing.Size(96, 20)
            Me.txtToCCPersonName.TabIndex = 196
            Me.txtToCCPersonName.TabStop = False
            Me.txtToCCPersonName.Text = ""
            '
            'lblToCCPerson
            '
            Me.lblToCCPerson.BackColor = System.Drawing.Color.Transparent
            Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblToCCPerson.Location = New System.Drawing.Point(344, 16)
            Me.lblToCCPerson.Name = "lblToCCPerson"
            Me.lblToCCPerson.Size = New System.Drawing.Size(88, 18)
            Me.lblToCCPerson.TabIndex = 191
            Me.lblToCCPerson.Text = "ผู้รับ:"
            Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtToCostCenterName
            '
            Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.txtToCostCenterName.Location = New System.Drawing.Point(192, 64)
            Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
            Me.txtToCostCenterName.Name = "txtToCostCenterName"
            Me.txtToCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
            Me.Validator.SetRequired(Me.txtToCostCenterName, False)
            Me.txtToCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtToCostCenterName.TabIndex = 196
            Me.txtToCostCenterName.TabStop = False
            Me.txtToCostCenterName.Text = ""
            '
            'btnToCostCenterDialog
            '
            Me.btnToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCostCenterDialog.Image = CType(resources.GetObject("btnToCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnToCostCenterDialog.Location = New System.Drawing.Point(288, 64)
            Me.btnToCostCenterDialog.Name = "btnToCostCenterDialog"
            Me.btnToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterDialog.TabIndex = 201
            Me.btnToCostCenterDialog.TabStop = False
            Me.btnToCostCenterDialog.ThemedImage = CType(resources.GetObject("btnToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnToCCPersonPanel
            '
            Me.btnToCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCPersonPanel.Image = CType(resources.GetObject("btnToCCPersonPanel.Image"), System.Drawing.Image)
            Me.btnToCCPersonPanel.Location = New System.Drawing.Point(640, 16)
            Me.btnToCCPersonPanel.Name = "btnToCCPersonPanel"
            Me.btnToCCPersonPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnToCCPersonPanel.TabIndex = 200
            Me.btnToCCPersonPanel.TabStop = False
            Me.btnToCCPersonPanel.ThemedImage = CType(resources.GetObject("btnToCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblToCC
            '
            Me.lblToCC.BackColor = System.Drawing.Color.Transparent
            Me.lblToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblToCC.Location = New System.Drawing.Point(8, 64)
            Me.lblToCC.Name = "lblToCC"
            Me.lblToCC.Size = New System.Drawing.Size(104, 18)
            Me.lblToCC.TabIndex = 192
            Me.lblToCC.Text = "CostCenter:"
            Me.lblToCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnToCCPersonDialog
            '
            Me.btnToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCPersonDialog.Image = CType(resources.GetObject("btnToCCPersonDialog.Image"), System.Drawing.Image)
            Me.btnToCCPersonDialog.Location = New System.Drawing.Point(616, 16)
            Me.btnToCCPersonDialog.Name = "btnToCCPersonDialog"
            Me.btnToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnToCCPersonDialog.TabIndex = 202
            Me.btnToCCPersonDialog.TabStop = False
            Me.btnToCCPersonDialog.ThemedImage = CType(resources.GetObject("btnToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbDueDate
            '
            Me.grbDueDate.Controls.Add(Me.txtDueDateStart)
            Me.grbDueDate.Controls.Add(Me.txtDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.lblDueDateStart)
            Me.grbDueDate.Controls.Add(Me.lblDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateStart)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateEnd)
            Me.grbDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDueDate.Location = New System.Drawing.Point(241, 120)
            Me.grbDueDate.Name = "grbDueDate"
            Me.grbDueDate.Size = New System.Drawing.Size(230, 72)
            Me.grbDueDate.TabIndex = 2
            Me.grbDueDate.TabStop = False
            Me.grbDueDate.Text = "วันที่ครบกำหนด"
            '
            'txtDueDateStart
            '
            Me.txtDueDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.txtDueDateStart.Location = New System.Drawing.Point(80, 14)
            Me.Validator.SetMaxValue(Me.txtDueDateStart, "")
            Me.Validator.SetMinValue(Me.txtDueDateStart, "")
            Me.txtDueDateStart.Name = "txtDueDateStart"
            Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
            Me.Validator.SetRequired(Me.txtDueDateStart, False)
            Me.txtDueDateStart.Size = New System.Drawing.Size(118, 20)
            Me.txtDueDateStart.TabIndex = 0
            Me.txtDueDateStart.Text = ""
            '
            'txtDueDateEnd
            '
            Me.txtDueDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.txtDueDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.Validator.SetMaxValue(Me.txtDueDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
            Me.txtDueDateEnd.Name = "txtDueDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
            Me.Validator.SetRequired(Me.txtDueDateEnd, False)
            Me.txtDueDateEnd.Size = New System.Drawing.Size(118, 20)
            Me.txtDueDateEnd.TabIndex = 1
            Me.txtDueDateEnd.Text = ""
            '
            'lblDueDateStart
            '
            Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDueDateStart.Name = "lblDueDateStart"
            Me.lblDueDateStart.Size = New System.Drawing.Size(64, 18)
            Me.lblDueDateStart.TabIndex = 8
            Me.lblDueDateStart.Text = "ตั้งแต่"
            Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDateEnd
            '
            Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateEnd.Location = New System.Drawing.Point(8, 39)
            Me.lblDueDateEnd.Name = "lblDueDateEnd"
            Me.lblDueDateEnd.Size = New System.Drawing.Size(64, 18)
            Me.lblDueDateEnd.TabIndex = 9
            Me.lblDueDateEnd.Text = "ถึง"
            Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDueDateStart
            '
            Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateStart.Location = New System.Drawing.Point(80, 14)
            Me.dtpDueDateStart.Name = "dtpDueDateStart"
            Me.dtpDueDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpDueDateStart.TabIndex = 10
            Me.dtpDueDateStart.TabStop = False
            '
            'dtpDueDateEnd
            '
            Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
            Me.dtpDueDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDueDateEnd.TabIndex = 11
            Me.dtpDueDateEnd.TabStop = False
            '
            'grbPV
            '
            Me.grbPV.Controls.Add(Me.txtPVCodeEnd)
            Me.grbPV.Controls.Add(Me.lblPVEnd)
            Me.grbPV.Controls.Add(Me.btnPVEndFind)
            Me.grbPV.Controls.Add(Me.txtPVCodeStart)
            Me.grbPV.Controls.Add(Me.lblPVStart)
            Me.grbPV.Controls.Add(Me.btnPVStartFind)
            Me.grbPV.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbPV.Location = New System.Drawing.Point(474, 120)
            Me.grbPV.Name = "grbPV"
            Me.grbPV.Size = New System.Drawing.Size(230, 72)
            Me.grbPV.TabIndex = 2
            Me.grbPV.TabStop = False
            Me.grbPV.Text = "ใบสำคัญจ่าย"
            '
            'txtPVCodeEnd
            '
            Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.txtPVCodeEnd.Location = New System.Drawing.Point(56, 40)
            Me.Validator.SetMaxValue(Me.txtPVCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
            Me.txtPVCodeEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtPVCodeEnd.TabIndex = 212
            Me.txtPVCodeEnd.Text = ""
            '
            'lblPVEnd
            '
            Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPVEnd.Location = New System.Drawing.Point(8, 40)
            Me.lblPVEnd.Name = "lblPVEnd"
            Me.lblPVEnd.Size = New System.Drawing.Size(48, 18)
            Me.lblPVEnd.TabIndex = 213
            Me.lblPVEnd.Text = "ถึง:"
            Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPVEndFind
            '
            Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVEndFind.Image = CType(resources.GetObject("btnPVEndFind.Image"), System.Drawing.Image)
            Me.btnPVEndFind.Location = New System.Drawing.Point(200, 40)
            Me.btnPVEndFind.Name = "btnPVEndFind"
            Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVEndFind.TabIndex = 211
            Me.btnPVEndFind.TabStop = False
            Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPVCodeStart
            '
            Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.txtPVCodeStart.Location = New System.Drawing.Point(56, 16)
            Me.Validator.SetMaxValue(Me.txtPVCodeStart, "")
            Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Name = "txtPVCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
            Me.Validator.SetRequired(Me.txtPVCodeStart, False)
            Me.txtPVCodeStart.Size = New System.Drawing.Size(144, 21)
            Me.txtPVCodeStart.TabIndex = 208
            Me.txtPVCodeStart.Text = ""
            '
            'lblPVStart
            '
            Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVStart.ForeColor = System.Drawing.Color.Black
            Me.lblPVStart.Location = New System.Drawing.Point(16, 16)
            Me.lblPVStart.Name = "lblPVStart"
            Me.lblPVStart.Size = New System.Drawing.Size(40, 18)
            Me.lblPVStart.TabIndex = 209
            Me.lblPVStart.Text = "ตั้งแต่:"
            Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPVStartFind
            '
            Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVStartFind.Image = CType(resources.GetObject("btnPVStartFind.Image"), System.Drawing.Image)
            Me.btnPVStartFind.Location = New System.Drawing.Point(200, 16)
            Me.btnPVStartFind.Name = "btnPVStartFind"
            Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVStartFind.TabIndex = 210
            Me.btnPVStartFind.TabStop = False
            Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'EqMaintenanceDetailFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "EqMaintenanceDetailFilterSubPanel"
            Me.Size = New System.Drawing.Size(728, 256)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbDueDate.ResumeLayout(False)
            Me.grbPV.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region "Members"
        Private m_toccperson As Employee
        Private m_tocc As CostCenter
        Private m_supplier As Supplier
        Private docDateStart As Date
        Private docDateEnd As Date
        Private dueDateStart As Date
        Private dueDateEnd As Date
        Private receivingDateStart As Date
        Private receivingDateEnd As Date
        Private m_eq As Asset
#End Region

#Region "Methods"
        Public Sub Initialize()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            PopulateStatus()
            ClearCriterias()
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.docDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.docDateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.docDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.docDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.docDateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.docDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "dtpduedatestart"
                    If Not Me.dueDateStart.Equals(dtpDueDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateStart = dtpDueDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedatestart"
                    m_dateSetting = True
                    If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
                        If Not Me.dueDateStart.Equals(theDate) Then
                            dtpDueDateStart.Value = theDate
                            Me.dueDateStart = dtpDueDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateStart.Value = Date.Now
                        Me.dueDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpduedateend"
                    If Not Me.dueDateEnd.Equals(dtpDueDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateEnd = dtpDueDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedateend"
                    m_dateSetting = True
                    If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateEnd.Text)
                        If Not Me.dueDateEnd.Equals(theDate) Then
                            dtpDueDateEnd.Value = theDate
                            Me.dueDateEnd = dtpDueDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateEnd.Value = Date.Now
                        Me.dueDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtToCostCenterCode.Text = ""
            Me.txtToCostCenterName.Text = ""
            Me.m_tocc = New CostCenter

            Me.txtEquipmentCode.Text = ""
            Me.txtEquipmentName.Text = ""
            Me.m_eq = New Asset

            Me.txtToCCPersonCode.Text = ""
            Me.txtToCCPersonName.Text = ""
            Me.m_toccperson = New Employee

            Me.txtSupplierCode.Text = ""
            Me.txtSupplierName.Text = ""
            Me.m_supplier = New Supplier

            Me.txtBlank.Text = ""

            Me.dtpDocDateStart.Value = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

            Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.docDateEnd = Now.Date

            Me.dtpDueDateStart.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.dtpDueDateEnd.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, 1, Now.Date), "")

            Me.txtDueDateStart.Text = ""
            Me.txtDueDateEnd.Text = ""

            Me.dueDateStart = Date.MinValue
            Me.dueDateEnd = Date.MinValue

            Me.txtPVCodeStart.Text = ""
            Me.txtPVCodeEnd.Text = ""

            cmbStatus.SelectedIndex = 0
            EntityRefresh()
        End Sub
        Private Sub PopulateStatus()
            CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "EqMaintenance_status", True)
        End Sub
        Public Sub SetLabelText()
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblDocDateEnd}")
            Me.grbDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbdueDate}")
            Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lbldueDateStart}")
            Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lbldueDateEnd}")
            Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblToCCPerson}")
            Me.lblToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblToCC}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblStatus}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbItem}")
            Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblBlank}")
            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblSupplier}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbMainDetail}")
            Me.lblEquipment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblEquipment}")
            Me.grbPV.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbPV}")
            Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblPVStart}")
            Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.lblPVEnd}")

            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Pojjaman.Gui.Panels.EqMaintenanceDetailFilterSubPanel.grbDetail}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(12) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("toccperson_id", IIf(Me.m_toccperson.Originated, Me.m_toccperson.Id, DBNull.Value))
            arr(2) = New Filter("tocc_id", IIf(Me.m_tocc.Originated, Me.m_tocc.Id, DBNull.Value))
            arr(3) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
            arr(4) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
            arr(5) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
            arr(6) = New Filter("stocki_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
            arr(7) = New Filter("supplier_id", IIf(Me.m_supplier.Originated, Me.m_supplier.Id, DBNull.Value))
            arr(8) = New Filter("equipment", IIf(Me.m_eq.Originated, Me.m_eq.Id, DBNull.Value))
            arr(9) = New Filter("duedatestart", ValidDateOrDBNull(dueDateStart))
            arr(10) = New Filter("duedateend", ValidDateOrDBNull(dueDateEnd))
            arr(11) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
            arr(12) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub ibtnShowEquipentDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipmentDiaog.Click
            Dim myEntityPanelService As IEntityPanelService = _
                         CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim eq As New Asset
            entities.Add(eq)
            myEntityPanelService.OpenListDialog(New Asset, AddressOf SetEquipment, entities)
        End Sub
        Private Sub SetEquipment(ByVal e As ISimpleEntity)
            Me.txtEquipmentCode.Text = e.Code
            Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_eq)
        End Sub
        Private Sub txtEquipmentCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEquipmentCode.Validated
            Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_eq)
        End Sub
        Private Sub ibtShowEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipment.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Asset)
        End Sub
        Private Sub txtToCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCCPersonCode.Validated
            Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toccperson)
        End Sub
        Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCostCenterCode.Validated
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
        End Sub
        Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
            Me.txtToCCPersonCode.Text = e.Code
            Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toccperson)
        End Sub
        Private Sub btnToCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
        End Sub
        Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
            Me.txtToCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc)
        End Sub
        Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
        End Sub
        Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
        End Sub
        Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub
        Private Sub SetSupplier(ByVal e As ISimpleEntity)
            Me.txtSupplierCode.Text = e.Code
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
        End Sub
        Private Sub btnPVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVStartFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVStartDialog)
        End Sub
        Private Sub btnPVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVEndFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVEndDialog)
        End Sub
        Private Sub SetPVStartDialog(ByVal e As ISimpleEntity)
            Me.txtPVCodeStart.Text = e.Code
        End Sub
        Private Sub SetPVEndDialog(ByVal e As ISimpleEntity)
            Me.txtPVCodeEnd.Text = e.Code
        End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject

                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txttocostcentercode", "txttocostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txttoccpersoncode", "txttoccpersonname"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Asset).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtequipmentcode", "txtequipmentname"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txttocostcentercode", "txttocostcentername"
                        Me.SetToCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txttoccpersoncode", "txttoccpersonname"
                        Me.SetToCCPerson(entity)
                End Select
            End If
            If data.GetDataPresent((New Asset).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Asset).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtequipmentcode", "txtequipmentname"
                        Me.SetEquipment(entity)
                End Select
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            If Entities Is Nothing Then
                Return
            End If
            For Each entity As ISimpleEntity In Entities

                If TypeOf entity Is EqMaintenance Then
                    Dim obj As EqMaintenance
                    obj = CType(entity, EqMaintenance)
                    ' Supplier ...
                    If obj.Supplier.Originated Then
                        Me.SetSupplier(obj.Supplier)
                        Me.txtSupplierCode.Enabled = False
                        Me.txtSupplierName.Enabled = False
                        Me.btnSupplierDialog.Enabled = False
                        Me.btnSupplierPanel.Enabled = False
                    End If
                End If
                If TypeOf entity Is Supplier Then
                    Me.SetSupplier(entity)
                    Me.txtSupplierCode.Enabled = False
                    Me.txtSupplierName.Enabled = False
                    Me.btnSupplierDialog.Enabled = False
                    Me.btnSupplierPanel.Enabled = False
                End If
            Next
        End Sub

        Private Sub grbDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbDetail.Enter

        End Sub
    End Class
End Namespace

