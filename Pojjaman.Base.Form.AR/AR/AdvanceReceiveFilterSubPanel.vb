Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AdvanceReceiveFilterSubPanel
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
        Friend WithEvents btnCustomerEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustomerFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCCName As System.Windows.Forms.TextBox
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtRVCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblRVEnd As System.Windows.Forms.Label
        Friend WithEvents txtRVCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblRVStart As System.Windows.Forms.Label
        Friend WithEvents btnRVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdvanceReceiveFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtRVCodeEnd = New System.Windows.Forms.TextBox
            Me.lblRVEnd = New System.Windows.Forms.Label
            Me.txtRVCodeStart = New System.Windows.Forms.TextBox
            Me.lblRVStart = New System.Windows.Forms.Label
            Me.btnRVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustomerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustomerFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.txtCCCode = New System.Windows.Forms.TextBox
            Me.txtCCName = New System.Windows.Forms.TextBox
            Me.lblCC = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
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
            Me.grbDetail.Size = New System.Drawing.Size(648, 144)
            Me.grbDetail.TabIndex = 9
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "มัดจำรับ (ล่วงหน้า)"
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
            Me.grbDocDate.Location = New System.Drawing.Point(440, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(200, 64)
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
            Me.txtDocDateStart.Location = New System.Drawing.Point(56, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
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
            Me.txtDocDateEnd.Location = New System.Drawing.Point(56, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
            Me.txtDocDateEnd.TabIndex = 7
            Me.txtDocDateEnd.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(40, 18)
            Me.lblDocDateStart.TabIndex = 8
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 36)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(40, 24)
            Me.lblDocDateEnd.TabIndex = 9
            Me.lblDocDateEnd.Text = "End Date"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(56, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateStart.TabIndex = 10
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(56, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateEnd.TabIndex = 11
            Me.dtpDocDateEnd.TabStop = False
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.txtRVCodeEnd)
            Me.grbGeneral.Controls.Add(Me.lblRVEnd)
            Me.grbGeneral.Controls.Add(Me.txtRVCodeStart)
            Me.grbGeneral.Controls.Add(Me.lblRVStart)
            Me.grbGeneral.Controls.Add(Me.btnRVStartFind)
            Me.grbGeneral.Controls.Add(Me.btnRVEndFind)
            Me.grbGeneral.Controls.Add(Me.btnCustomerEdit)
            Me.grbGeneral.Controls.Add(Me.btnCustomerFind)
            Me.grbGeneral.Controls.Add(Me.txtCustomerCode)
            Me.grbGeneral.Controls.Add(Me.lblCustomer)
            Me.grbGeneral.Controls.Add(Me.txtCustomerName)
            Me.grbGeneral.Controls.Add(Me.txtCCCode)
            Me.grbGeneral.Controls.Add(Me.txtCCName)
            Me.grbGeneral.Controls.Add(Me.lblCC)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.Controls.Add(Me.btnCCFind)
            Me.grbGeneral.Controls.Add(Me.btnCCEdit)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(424, 120)
            Me.grbGeneral.TabIndex = 181
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "รายละเอียดทั่วไป"
            '
            'txtRVCodeEnd
            '
            Me.Validator.SetDataType(Me.txtRVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRVCodeEnd, "")
            Me.txtRVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
            Me.txtRVCodeEnd.Location = New System.Drawing.Point(264, 88)
            Me.Validator.SetMaxValue(Me.txtRVCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtRVCodeEnd, "")
            Me.txtRVCodeEnd.Name = "txtRVCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtRVCodeEnd, "")
            Me.Validator.SetRequired(Me.txtRVCodeEnd, False)
            Me.txtRVCodeEnd.Size = New System.Drawing.Size(104, 21)
            Me.txtRVCodeEnd.TabIndex = 219
            Me.txtRVCodeEnd.Text = ""
            '
            'lblRVEnd
            '
            Me.lblRVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRVEnd.ForeColor = System.Drawing.Color.Black
            Me.lblRVEnd.Location = New System.Drawing.Point(240, 88)
            Me.lblRVEnd.Name = "lblRVEnd"
            Me.lblRVEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblRVEnd.TabIndex = 223
            Me.lblRVEnd.Text = "ถึง:"
            Me.lblRVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtRVCodeStart
            '
            Me.Validator.SetDataType(Me.txtRVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRVCodeStart, "")
            Me.txtRVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
            Me.txtRVCodeStart.Location = New System.Drawing.Point(104, 88)
            Me.Validator.SetMaxValue(Me.txtRVCodeStart, "")
            Me.Validator.SetMinValue(Me.txtRVCodeStart, "")
            Me.txtRVCodeStart.Name = "txtRVCodeStart"
            Me.Validator.SetRegularExpression(Me.txtRVCodeStart, "")
            Me.Validator.SetRequired(Me.txtRVCodeStart, False)
            Me.txtRVCodeStart.Size = New System.Drawing.Size(104, 21)
            Me.txtRVCodeStart.TabIndex = 218
            Me.txtRVCodeStart.Text = ""
            '
            'lblRVStart
            '
            Me.lblRVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRVStart.ForeColor = System.Drawing.Color.Black
            Me.lblRVStart.Location = New System.Drawing.Point(8, 88)
            Me.lblRVStart.Name = "lblRVStart"
            Me.lblRVStart.Size = New System.Drawing.Size(88, 18)
            Me.lblRVStart.TabIndex = 222
            Me.lblRVStart.Text = "ตั้งแต่ใบสำคัญรับ:"
            Me.lblRVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRVStartFind
            '
            Me.btnRVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRVStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRVStartFind.Image = CType(resources.GetObject("btnRVStartFind.Image"), System.Drawing.Image)
            Me.btnRVStartFind.Location = New System.Drawing.Point(208, 88)
            Me.btnRVStartFind.Name = "btnRVStartFind"
            Me.btnRVStartFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRVStartFind.TabIndex = 220
            Me.btnRVStartFind.TabStop = False
            Me.btnRVStartFind.ThemedImage = CType(resources.GetObject("btnRVStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRVEndFind
            '
            Me.btnRVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRVEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRVEndFind.Image = CType(resources.GetObject("btnRVEndFind.Image"), System.Drawing.Image)
            Me.btnRVEndFind.Location = New System.Drawing.Point(368, 88)
            Me.btnRVEndFind.Name = "btnRVEndFind"
            Me.btnRVEndFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRVEndFind.TabIndex = 221
            Me.btnRVEndFind.TabStop = False
            Me.btnRVEndFind.ThemedImage = CType(resources.GetObject("btnRVEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustomerEdit
            '
            Me.btnCustomerEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerEdit.Image = CType(resources.GetObject("btnCustomerEdit.Image"), System.Drawing.Image)
            Me.btnCustomerEdit.Location = New System.Drawing.Point(392, 40)
            Me.btnCustomerEdit.Name = "btnCustomerEdit"
            Me.btnCustomerEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerEdit.TabIndex = 189
            Me.btnCustomerEdit.TabStop = False
            Me.btnCustomerEdit.ThemedImage = CType(resources.GetObject("btnCustomerEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustomerFind
            '
            Me.btnCustomerFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerFind.Image = CType(resources.GetObject("btnCustomerFind.Image"), System.Drawing.Image)
            Me.btnCustomerFind.Location = New System.Drawing.Point(368, 40)
            Me.btnCustomerFind.Name = "btnCustomerFind"
            Me.btnCustomerFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerFind.TabIndex = 192
            Me.btnCustomerFind.TabStop = False
            Me.btnCustomerFind.ThemedImage = CType(resources.GetObject("btnCustomerFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerCode
            '
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(104, 40)
            Me.txtCustomerCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, False)
            Me.txtCustomerCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCustomerCode.TabIndex = 188
            Me.txtCustomerCode.Text = ""
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(16, 40)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(80, 18)
            Me.lblCustomer.TabIndex = 181
            Me.lblCustomer.Text = "ลูกค้า"
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
            Me.txtCustomerName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(176, 21)
            Me.txtCustomerName.TabIndex = 186
            Me.txtCustomerName.Text = ""
            '
            'txtCCCode
            '
            Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCode, "")
            Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.txtCCCode.Location = New System.Drawing.Point(104, 64)
            Me.txtCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCCCode, "")
            Me.Validator.SetMinValue(Me.txtCCCode, "")
            Me.txtCCCode.Name = "txtCCCode"
            Me.Validator.SetRegularExpression(Me.txtCCCode, "")
            Me.Validator.SetRequired(Me.txtCCCode, False)
            Me.txtCCCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCCCode.TabIndex = 185
            Me.txtCCCode.Text = ""
            '
            'txtCCName
            '
            Me.txtCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCName, "")
            Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.txtCCName.Location = New System.Drawing.Point(192, 64)
            Me.Validator.SetMaxValue(Me.txtCCName, "")
            Me.Validator.SetMinValue(Me.txtCCName, "")
            Me.txtCCName.Name = "txtCCName"
            Me.txtCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCName, "")
            Me.Validator.SetRequired(Me.txtCCName, False)
            Me.txtCCName.Size = New System.Drawing.Size(176, 21)
            Me.txtCCName.TabIndex = 184
            Me.txtCCName.Text = ""
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.Color.Black
            Me.lblCC.Location = New System.Drawing.Point(16, 64)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(80, 18)
            Me.lblCC.TabIndex = 182
            Me.lblCC.Text = "Cost Center"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.lblCode.Text = "เลขที่"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCFind
            '
            Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCFind.Image = CType(resources.GetObject("btnCCFind.Image"), System.Drawing.Image)
            Me.btnCCFind.Location = New System.Drawing.Point(368, 64)
            Me.btnCCFind.Name = "btnCCFind"
            Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCCFind.TabIndex = 192
            Me.btnCCFind.TabStop = False
            Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCCEdit
            '
            Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCEdit.Image = CType(resources.GetObject("btnCCEdit.Image"), System.Drawing.Image)
            Me.btnCCEdit.Location = New System.Drawing.Point(392, 64)
            Me.btnCCEdit.Name = "btnCCEdit"
            Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCCEdit.TabIndex = 189
            Me.btnCCEdit.TabStop = False
            Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(560, 112)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(80, 23)
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(472, 112)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(80, 23)
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
            'AdvanceReceiveFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "AdvanceReceiveFilterSubPanel"
            Me.Size = New System.Drawing.Size(664, 160)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.grbDetail}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.grbGeneral}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.grbDocDate}")

            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblCode}")

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblCustomer}")
            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblCC}")

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocdateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblDocDateEnd}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblRVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblRVStart}")
            Me.lblRVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveFilterSubPanel.lblRVEnd}")
        End Sub
#End Region

#Region "Member"
        Private m_cc As New CostCenter
        Private m_cust As New Customer
        Private m_docdatestart As Date
        Private m_docdateend As Date
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
        Private Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
        Private Property Customer() As Customer
            Get
                Return m_cust
            End Get
            Set(ByVal Value As Customer)
                m_cust = Value
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
#End Region

#Region "Methods"
        Private Sub Initialize()
            AddHandler txtDocdateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocdateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            ' Clear item
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
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            For Each ctrl As Control In grbGeneral.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.CostCenter = New CostCenter
            Me.Customer = New Customer

            Me.dtpDocDateStart.Value = Now.Date
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = ""
            Me.txtDocDateEnd.Text = ""

            Me.DocdateStart = Date.MinValue
            Me.DocdateEnd = Date.MinValue

            Me.txtRVCodeStart.Text = ""
            Me.txtRVCodeEnd.Text = ""

            EntityRefresh()
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(7) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.TextLength = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("cust_id", Me.ValidIdOrDBNull(Me.Customer))
            arr(2) = New Filter("cc_id", Me.ValidIdOrDBNull(Me.CostCenter))
            arr(3) = New Filter("docdatestart", Me.ValidDateOrDBNull(Me.DocdateStart))
            arr(4) = New Filter("docdateend", Me.ValidDateOrDBNull(Me.DocdateEnd))
            arr(5) = New Filter("RVCodeStart", IIf(txtRVCodeStart.TextLength > 0, txtRVCodeStart.Text, DBNull.Value))
            arr(6) = New Filter("RVCodeEnd", IIf(txtRVCodeEnd.TextLength > 0, txtRVCodeEnd.Text, DBNull.Value))
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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
        Private Sub txtCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCCode.Validated
            CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.Customer)
        End Sub
#End Region

#Region "Event of Button Handlers"
        ' Cost Center
        Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
        End Sub
        Private Sub SetCostCenter(ByVal e As ISimpleEntity)
            Me.txtCCCode.Text = e.Code
            CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' Customer
        Private Sub btnCustomerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub btnCustomerFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.Customer)
        End Sub
        Private Sub btnRVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRVStartFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVStartDialog)
        End Sub
        Private Sub btnRVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRVEndFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVEndDialog)
        End Sub
        Private Sub SetRVStartDialog(ByVal e As ISimpleEntity)
            Me.txtRVCodeStart.Text = e.Code
        End Sub
        Private Sub SetRVEndDialog(ByVal e As ISimpleEntity)
            Me.txtRVCodeEnd.Text = e.Code
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Cost Center
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccode", "txtccname"
                                Return True
                        End Select
                    End If
                End If
                ' ลูกค้า
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcustomercode", "txtcustomername"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcccode", "txtccname"
                            Me.SetCostCenter(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustomercode", "txtcustomername"
                            Me.SetCustomer(entity)
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
                If TypeOf entity Is AdvanceReceive Then
                    Dim obj As AdvanceReceive = CType(entity, AdvanceReceive)
                    ' recieve person
                    If obj.CostCenter.Originated Then
                        Me.SetCostCenter(obj.CostCenter)
                        Me.txtCCCode.Enabled = False
                        Me.txtCCName.Enabled = False
                        Me.btnCCEdit.Enabled = False
                        Me.btnCCFind.Enabled = False
                    End If
                    ' customer 
                    If obj.Customer.Originated Then
                        Me.SetCustomer(obj.Customer)
                        Me.txtCustomerCode.Enabled = False
                        Me.txtCustomerName.Enabled = False
                        Me.btnCustomerEdit.Enabled = False
                        Me.btnCustomerFind.Enabled = False
                    End If
                End If
                If TypeOf entity Is Customer Then
                    Me.SetCustomer(CType(entity, Customer))
                    Me.txtCustomerCode.Enabled = False
                    Me.txtCustomerName.Enabled = False
                    Me.btnCustomerEdit.Enabled = False
                    Me.btnCustomerFind.Enabled = False
                End If
                If TypeOf entity Is CostCenter Then
                    Me.SetCostCenter(CType(entity, CostCenter))
                    Me.txtCCCode.Enabled = False
                    Me.txtCCName.Enabled = False
                    Me.btnCCEdit.Enabled = False
                    Me.btnCCFind.Enabled = False
                End If
            Next
        End Sub

    End Class
End Namespace

