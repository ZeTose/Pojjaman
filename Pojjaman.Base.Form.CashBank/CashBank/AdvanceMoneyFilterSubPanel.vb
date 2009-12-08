Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AdvanceMoneyFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnEmployeeEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnEmployeeFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
        Friend WithEvents cmbAdvmStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblAdvmStatus As System.Windows.Forms.Label
        Friend WithEvents cmbIsClosed As System.Windows.Forms.ComboBox
        Friend WithEvents lblIsClosed As System.Windows.Forms.Label
        Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblPVEnd As System.Windows.Forms.Label
        Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPVStart As System.Windows.Forms.Label
        Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdvanceMoneyFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtPVCodeEnd = New System.Windows.Forms.TextBox
            Me.lblPVEnd = New System.Windows.Forms.Label
            Me.txtPVCodeStart = New System.Windows.Forms.TextBox
            Me.lblPVStart = New System.Windows.Forms.Label
            Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.cmbIsClosed = New System.Windows.Forms.ComboBox
            Me.lblIsClosed = New System.Windows.Forms.Label
            Me.cmbAdvmStatus = New System.Windows.Forms.ComboBox
            Me.lblAdvmStatus = New System.Windows.Forms.Label
            Me.btnEmployeeEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnEmployeeFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtEmployeeCode = New System.Windows.Forms.TextBox
            Me.lblEmployee = New System.Windows.Forms.Label
            Me.txtEmployeeName = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.grbGeneral)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(648, 168)
            Me.grbDetail.TabIndex = 9
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "มัดจำจ่าย"
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
            Me.grbDocDate.Location = New System.Drawing.Point(432, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(200, 72)
            Me.grbDocDate.TabIndex = 182
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(80, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(88, 20)
            Me.txtDocDateStart.TabIndex = 6
            Me.txtDocDateStart.Text = ""
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(88, 20)
            Me.txtDocDateEnd.TabIndex = 7
            Me.txtDocDateEnd.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(64, 18)
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
            Me.lblDocDateEnd.Size = New System.Drawing.Size(64, 18)
            Me.lblDocDateEnd.TabIndex = 9
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(80, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(112, 20)
            Me.dtpDocDateStart.TabIndex = 10
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(112, 20)
            Me.dtpDocDateEnd.TabIndex = 11
            Me.dtpDocDateEnd.TabStop = False
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.txtPVCodeEnd)
            Me.grbGeneral.Controls.Add(Me.lblPVEnd)
            Me.grbGeneral.Controls.Add(Me.txtPVCodeStart)
            Me.grbGeneral.Controls.Add(Me.lblPVStart)
            Me.grbGeneral.Controls.Add(Me.btnPVStartFind)
            Me.grbGeneral.Controls.Add(Me.btnPVEndFind)
            Me.grbGeneral.Controls.Add(Me.cmbIsClosed)
            Me.grbGeneral.Controls.Add(Me.lblIsClosed)
            Me.grbGeneral.Controls.Add(Me.cmbAdvmStatus)
            Me.grbGeneral.Controls.Add(Me.lblAdvmStatus)
            Me.grbGeneral.Controls.Add(Me.btnEmployeeEdit)
            Me.grbGeneral.Controls.Add(Me.btnEmployeeFind)
            Me.grbGeneral.Controls.Add(Me.txtEmployeeCode)
            Me.grbGeneral.Controls.Add(Me.lblEmployee)
            Me.grbGeneral.Controls.Add(Me.txtEmployeeName)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(416, 144)
            Me.grbGeneral.TabIndex = 181
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "รายละเอียดทั่วไป"
            '
            'txtPVCodeEnd
            '
            Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.txtPVCodeEnd.Location = New System.Drawing.Point(266, 63)
            Me.Validator.SetMaxValue(Me.txtPVCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
            Me.txtPVCodeEnd.Size = New System.Drawing.Size(92, 21)
            Me.txtPVCodeEnd.TabIndex = 224
            Me.txtPVCodeEnd.Text = ""
            '
            'lblPVEnd
            '
            Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPVEnd.Location = New System.Drawing.Point(243, 63)
            Me.lblPVEnd.Name = "lblPVEnd"
            Me.lblPVEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPVEnd.TabIndex = 225
            Me.lblPVEnd.Text = "ถึง:"
            Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtPVCodeStart
            '
            Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.txtPVCodeStart.Location = New System.Drawing.Point(104, 63)
            Me.Validator.SetMaxValue(Me.txtPVCodeStart, "")
            Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Name = "txtPVCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
            Me.Validator.SetRequired(Me.txtPVCodeStart, False)
            Me.txtPVCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPVCodeStart.TabIndex = 222
            Me.txtPVCodeStart.Text = ""
            '
            'lblPVStart
            '
            Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVStart.ForeColor = System.Drawing.Color.Black
            Me.lblPVStart.Location = New System.Drawing.Point(8, 63)
            Me.lblPVStart.Name = "lblPVStart"
            Me.lblPVStart.Size = New System.Drawing.Size(94, 18)
            Me.lblPVStart.TabIndex = 223
            Me.lblPVStart.Text = "ตั้งแต่ใบสำคัญจ่าย:"
            Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPVStartFind
            '
            Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVStartFind.Image = CType(resources.GetObject("btnPVStartFind.Image"), System.Drawing.Image)
            Me.btnPVStartFind.Location = New System.Drawing.Point(200, 63)
            Me.btnPVStartFind.Name = "btnPVStartFind"
            Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVStartFind.TabIndex = 220
            Me.btnPVStartFind.TabStop = False
            Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnPVEndFind
            '
            Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVEndFind.Image = CType(resources.GetObject("btnPVEndFind.Image"), System.Drawing.Image)
            Me.btnPVEndFind.Location = New System.Drawing.Point(360, 63)
            Me.btnPVEndFind.Name = "btnPVEndFind"
            Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVEndFind.TabIndex = 221
            Me.btnPVEndFind.TabStop = False
            Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'cmbIsClosed
            '
            Me.cmbIsClosed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIsClosed.Location = New System.Drawing.Point(104, 111)
            Me.cmbIsClosed.Name = "cmbIsClosed"
            Me.cmbIsClosed.Size = New System.Drawing.Size(121, 21)
            Me.cmbIsClosed.TabIndex = 196
            '
            'lblIsClosed
            '
            Me.lblIsClosed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIsClosed.ForeColor = System.Drawing.Color.Black
            Me.lblIsClosed.Location = New System.Drawing.Point(40, 111)
            Me.lblIsClosed.Name = "lblIsClosed"
            Me.lblIsClosed.Size = New System.Drawing.Size(56, 18)
            Me.lblIsClosed.TabIndex = 195
            Me.lblIsClosed.Text = "ปิดวงเงิน"
            Me.lblIsClosed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbAdvmStatus
            '
            Me.cmbAdvmStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbAdvmStatus.Location = New System.Drawing.Point(104, 87)
            Me.cmbAdvmStatus.Name = "cmbAdvmStatus"
            Me.cmbAdvmStatus.Size = New System.Drawing.Size(121, 21)
            Me.cmbAdvmStatus.TabIndex = 194
            '
            'lblAdvmStatus
            '
            Me.lblAdvmStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdvmStatus.ForeColor = System.Drawing.Color.Black
            Me.lblAdvmStatus.Location = New System.Drawing.Point(16, 87)
            Me.lblAdvmStatus.Name = "lblAdvmStatus"
            Me.lblAdvmStatus.Size = New System.Drawing.Size(80, 18)
            Me.lblAdvmStatus.TabIndex = 193
            Me.lblAdvmStatus.Text = "สถานะเอกสาร"
            Me.lblAdvmStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnEmployeeEdit
            '
            Me.btnEmployeeEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmployeeEdit.Image = CType(resources.GetObject("btnEmployeeEdit.Image"), System.Drawing.Image)
            Me.btnEmployeeEdit.Location = New System.Drawing.Point(384, 40)
            Me.btnEmployeeEdit.Name = "btnEmployeeEdit"
            Me.btnEmployeeEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnEmployeeEdit.TabIndex = 189
            Me.btnEmployeeEdit.TabStop = False
            Me.btnEmployeeEdit.ThemedImage = CType(resources.GetObject("btnEmployeeEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnEmployeeFind
            '
            Me.btnEmployeeFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmployeeFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEmployeeFind.Image = CType(resources.GetObject("btnEmployeeFind.Image"), System.Drawing.Image)
            Me.btnEmployeeFind.Location = New System.Drawing.Point(360, 40)
            Me.btnEmployeeFind.Name = "btnEmployeeFind"
            Me.btnEmployeeFind.Size = New System.Drawing.Size(24, 23)
            Me.btnEmployeeFind.TabIndex = 192
            Me.btnEmployeeFind.TabStop = False
            Me.btnEmployeeFind.ThemedImage = CType(resources.GetObject("btnEmployeeFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEmployeeCode
            '
            Me.Validator.SetDataType(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeCode, "")
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
            Me.txtEmployeeCode.Location = New System.Drawing.Point(104, 40)
            Me.txtEmployeeCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
            Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
            Me.Validator.SetRequired(Me.txtEmployeeCode, False)
            Me.txtEmployeeCode.Size = New System.Drawing.Size(88, 21)
            Me.txtEmployeeCode.TabIndex = 188
            Me.txtEmployeeCode.Text = ""
            '
            'lblEmployee
            '
            Me.lblEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(16, 40)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(80, 18)
            Me.lblEmployee.TabIndex = 181
            Me.lblEmployee.Text = "พนักงาน:"
            Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmployeeName
            '
            Me.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.txtEmployeeName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
            Me.Validator.SetMinValue(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
            Me.Validator.SetRequired(Me.txtEmployeeName, False)
            Me.txtEmployeeName.Size = New System.Drawing.Size(168, 21)
            Me.txtEmployeeName.TabIndex = 186
            Me.txtEmployeeName.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(152, 21)
            Me.txtCode.TabIndex = 7
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 13
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(552, 136)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(472, 136)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 7
            Me.btnReset.Text = "เคลียร์"
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
            'AdvanceMoneyFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "AdvanceMoneyFilterSubPanel"
            Me.Size = New System.Drawing.Size(664, 184)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.grbDetail}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.grbGeneral}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.grbDocDate}")

            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblCode}")

            Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblEmployee}")

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocdateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblDocDateEnd}")
            Me.lblAdvmStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblAdvmStatus}")

            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.cmbAdvmStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.cmbAdvmStatus}")
            Me.cmbIsClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.cmbIsClosed}")

            Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblPVStart}")
            Me.Validator.SetDisplayName(txtPVCodeStart, lblPVStart.Text)

            Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.lblPVEnd}")
            Me.Validator.SetDisplayName(txtPVCodeEnd, lblPVEnd.Text)
        End Sub
#End Region

#Region "Member"
        Private m_employee As New Employee
        Private m_docdatestart As Date
        Private m_docdateend As Date
        Private m_status As AdvanceMoneyStatus
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Private Property Employee() As Employee
            Get
                Return m_employee
            End Get
            Set(ByVal Value As Employee)
                m_employee = Value
            End Set
        End Property
        Private Property DocdateStart() As Date
            Get
                Return m_docdatestart
            End Get
            Set(ByVal Value As Date)
                m_docdatestart = Value
            End Set
        End Property
        Private Property DocdateEnd() As Date
            Get
                Return m_docdateend
            End Get
            Set(ByVal Value As Date)
                m_docdateend = Value
            End Set
        End Property
        Private Property Status() As CodeDescription
            Get
                Return m_status
            End Get
            Set(ByVal Value As CodeDescription)
                m_status = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            AddHandler txtDocdateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocdateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            RegisterDropdown()
            ClearCriterias()

        End Sub
        Private Sub RegisterDropdown()
            ' รูปแบบ
            AdvanceMoneyStatus.ListCodeDescriptionInComboBox(Me.cmbAdvmStatus, "advm_status", True)

            With cmbIsClosed.Items
                .Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.cmbIsClosedNothing}"))
                .Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.cmbIsClosedYes}"))
                .Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyFilterSubPanel.cmbIsClosedNo}"))
            End With

        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.DocdateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocdateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocdateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocdateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.DocdateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocdateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocdateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocdateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            For Each ctrl As Control In grbGeneral.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.Employee = New Employee

            Me.dtpDocDateStart.Value = Now.Date
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = ""
            Me.txtDocDateEnd.Text = ""

            Me.DocdateStart = Date.MinValue
            Me.DocdateEnd = Date.MinValue

            Me.cmbAdvmStatus.SelectedIndex = 0
            Me.cmbIsClosed.SelectedIndex = 0

            EntityRefresh()
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim isclosed As Object
            Dim status As Object

            Dim arr(7) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.TextLength = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("employee_id", Me.ValidIdOrDBNull(Me.Employee))
            arr(2) = New Filter("docdatestart", Me.ValidDateOrDBNull(Me.DocdateStart))
            arr(3) = New Filter("docdateend", Me.ValidDateOrDBNull(Me.DocdateEnd))
            If cmbAdvmStatus.SelectedItem Is Nothing Then
                status = DBNull.Value
            Else
                status = CType(cmbAdvmStatus.SelectedItem, IdValuePair).Id
            End If
            arr(4) = New Filter("status", status)
            Select Case cmbIsClosed.SelectedIndex
                Case 0
                    isclosed = DBNull.Value
                Case 1
                    isclosed = True
                Case 2
                    isclosed = False
            End Select
            arr(5) = New Filter("advm_closed", isclosed)
            arr(6) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
            Return arr
        End Function

        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "TextBox Validated"
        Private Sub txtEmployeeCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeCode.Validated
            Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.Employee)
        End Sub
#End Region

#Region "Event of Button Handlers"
        ' Employee
        Private Sub btnEmployeeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnEmployeeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
        End Sub
        Private Sub SetEmployee(ByVal e As ISimpleEntity)
            Me.txtEmployeeCode.Text = e.Code
            Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.Employee)
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

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Employee
                If data.GetDataPresent((New Employee).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtemployeecode", "txtemployeename"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtemployeecode", "txtemployeename"
                            Me.SetEmployee(entity)
                    End Select
                End If
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
                If TypeOf entity Is AdvanceMoney Then
                    Dim obj As AdvanceMoney = CType(entity, AdvanceMoney)
                    ' Employee
                    If obj.Employee.Originated Then
                        Me.SetEmployee(obj.Employee)
                        Me.txtEmployeeCode.Enabled = False
                        Me.txtEmployeeName.Enabled = False
                        Me.btnEmployeeEdit.Enabled = False
                        Me.btnEmployeeFind.Enabled = False
                    End If
                    If obj.Closed Then
                        Me.cmbIsClosed.Enabled = False
                        Me.cmbIsClosed.SelectedIndex = 1
                    Else
                        Me.cmbIsClosed.Enabled = False
                        Me.cmbIsClosed.SelectedIndex = 2
                    End If
                End If
                If TypeOf entity Is Employee Then
                    Me.SetEmployee(CType(entity, Employee))
                    Me.txtEmployeeCode.Enabled = False
                    Me.txtEmployeeName.Enabled = False
                    Me.btnEmployeeEdit.Enabled = False
                    Me.btnEmployeeFind.Enabled = False
                End If
            Next
        End Sub

    End Class
End Namespace

