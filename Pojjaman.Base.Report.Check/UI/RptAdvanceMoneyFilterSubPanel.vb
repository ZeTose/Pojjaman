Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAdvanceMoneyFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnAdvmEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAdvmCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvmEnd As System.Windows.Forms.Label
    Friend WithEvents btnAdvmStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAdvmCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvmStart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmpStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEmpCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCustEnd As System.Windows.Forms.Label
    Friend WithEvents txtEmpCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAccountStart As System.Windows.Forms.Label
        Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    Friend WithEvents lblCustStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAdvanceMoneyFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkShowDetail = New System.Windows.Forms.CheckBox()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblAccountEnd = New System.Windows.Forms.Label()
            Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAccountCodeStart = New System.Windows.Forms.TextBox()
            Me.lblAccountStart = New System.Windows.Forms.Label()
            Me.btnEmpEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnEmpStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtEmpCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblCustEnd = New System.Windows.Forms.Label()
            Me.txtEmpCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCustStart = New System.Windows.Forms.Label()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.btnAdvmEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAdvmCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblAdvmEnd = New System.Windows.Forms.Label()
            Me.btnAdvmStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAdvmCodeStart = New System.Windows.Forms.TextBox()
            Me.lblAdvmStart = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.chkShowDetail)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(520, 190)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'chkShowDetail
            '
            Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowDetail.Location = New System.Drawing.Point(184, 160)
            Me.chkShowDetail.Name = "chkShowDetail"
            Me.chkShowDetail.Size = New System.Drawing.Size(128, 21)
            Me.chkShowDetail.TabIndex = 61
            Me.chkShowDetail.Text = "แสดงรายละเอียด"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(532, 32)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 4
            Me.txtTemp.Visible = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
            Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblAccountEnd)
            Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
            Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAccountStart)
            Me.grbDetail.Controls.Add(Me.btnEmpEndFind)
            Me.grbDetail.Controls.Add(Me.btnEmpStartFind)
            Me.grbDetail.Controls.Add(Me.txtEmpCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblCustEnd)
            Me.grbDetail.Controls.Add(Me.txtEmpCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCustStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.btnAdvmEndFind)
            Me.grbDetail.Controls.Add(Me.txtAdvmCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblAdvmEnd)
            Me.grbDetail.Controls.Add(Me.btnAdvmStartFind)
            Me.grbDetail.Controls.Add(Me.txtAdvmCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAdvmStart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(488, 136)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnAccountEndFind
            '
            Me.btnAccountEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountEndFind.Location = New System.Drawing.Point(425, 97)
            Me.btnAccountEndFind.Name = "btnAccountEndFind"
            Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountEndFind.TabIndex = 52
            Me.btnAccountEndFind.TabStop = False
            Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
            Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
            Me.txtAccountCodeEnd.Location = New System.Drawing.Point(329, 97)
            Me.Validator.SetMaxValue(Me.txtAccountCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
            Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
            Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountCodeEnd.TabIndex = 50
            '
            'lblAccountEnd
            '
            Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAccountEnd.Location = New System.Drawing.Point(297, 97)
            Me.lblAccountEnd.Name = "lblAccountEnd"
            Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAccountEnd.TabIndex = 54
            Me.lblAccountEnd.Text = "ถึง"
            Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAccountStartFind
            '
            Me.btnAccountStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountStartFind.Location = New System.Drawing.Point(265, 97)
            Me.btnAccountStartFind.Name = "btnAccountStartFind"
            Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountStartFind.TabIndex = 51
            Me.btnAccountStartFind.TabStop = False
            Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCodeStart
            '
            Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
            Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
            Me.txtAccountCodeStart.Location = New System.Drawing.Point(169, 97)
            Me.Validator.SetMaxValue(Me.txtAccountCodeStart, "")
            Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
            Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
            Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
            Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountCodeStart.TabIndex = 49
            '
            'lblAccountStart
            '
            Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
            Me.lblAccountStart.Location = New System.Drawing.Point(73, 97)
            Me.lblAccountStart.Name = "lblAccountStart"
            Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAccountStart.TabIndex = 53
            Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
            Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnEmpEndFind
            '
            Me.btnEmpEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnEmpEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmpEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEmpEndFind.Location = New System.Drawing.Point(424, 72)
            Me.btnEmpEndFind.Name = "btnEmpEndFind"
            Me.btnEmpEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnEmpEndFind.TabIndex = 35
            Me.btnEmpEndFind.TabStop = False
            Me.btnEmpEndFind.ThemedImage = CType(resources.GetObject("btnEmpEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnEmpStartFind
            '
            Me.btnEmpStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnEmpStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmpStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEmpStartFind.Location = New System.Drawing.Point(264, 72)
            Me.btnEmpStartFind.Name = "btnEmpStartFind"
            Me.btnEmpStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnEmpStartFind.TabIndex = 34
            Me.btnEmpStartFind.TabStop = False
            Me.btnEmpStartFind.ThemedImage = CType(resources.GetObject("btnEmpStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEmpCodeEnd
            '
            Me.Validator.SetDataType(Me.txtEmpCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmpCodeEnd, "")
            Me.txtEmpCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
            Me.txtEmpCodeEnd.Location = New System.Drawing.Point(328, 72)
            Me.Validator.SetMaxValue(Me.txtEmpCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtEmpCodeEnd, "")
            Me.txtEmpCodeEnd.Name = "txtEmpCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtEmpCodeEnd, "")
            Me.Validator.SetRequired(Me.txtEmpCodeEnd, False)
            Me.txtEmpCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtEmpCodeEnd.TabIndex = 33
            '
            'lblCustEnd
            '
            Me.lblCustEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustEnd.ForeColor = System.Drawing.Color.Black
            Me.lblCustEnd.Location = New System.Drawing.Point(296, 72)
            Me.lblCustEnd.Name = "lblCustEnd"
            Me.lblCustEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblCustEnd.TabIndex = 32
            Me.lblCustEnd.Text = "ถึง"
            Me.lblCustEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtEmpCodeStart
            '
            Me.Validator.SetDataType(Me.txtEmpCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmpCodeStart, "")
            Me.txtEmpCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
            Me.txtEmpCodeStart.Location = New System.Drawing.Point(168, 72)
            Me.Validator.SetMaxValue(Me.txtEmpCodeStart, "")
            Me.Validator.SetMinValue(Me.txtEmpCodeStart, "")
            Me.txtEmpCodeStart.Name = "txtEmpCodeStart"
            Me.Validator.SetRegularExpression(Me.txtEmpCodeStart, "")
            Me.Validator.SetRequired(Me.txtEmpCodeStart, False)
            Me.txtEmpCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtEmpCodeStart.TabIndex = 31
            '
            'lblCustStart
            '
            Me.lblCustStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustStart.ForeColor = System.Drawing.Color.Black
            Me.lblCustStart.Location = New System.Drawing.Point(72, 72)
            Me.lblCustStart.Name = "lblCustStart"
            Me.lblCustStart.Size = New System.Drawing.Size(88, 18)
            Me.lblCustStart.TabIndex = 30
            Me.lblCustStart.Text = "ตั้งแต่พนักงาน:"
            Me.lblCustStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(328, 24)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtDocDateEnd.TabIndex = 1
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(168, 24)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
            Me.txtDocDateStart.TabIndex = 0
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(168, 24)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 27
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 24)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 29
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(64, 24)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 26
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(296, 24)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 28
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAdvmEndFind
            '
            Me.btnAdvmEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdvmEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdvmEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAdvmEndFind.Location = New System.Drawing.Point(424, 48)
            Me.btnAdvmEndFind.Name = "btnAdvmEndFind"
            Me.btnAdvmEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAdvmEndFind.TabIndex = 17
            Me.btnAdvmEndFind.TabStop = False
            Me.btnAdvmEndFind.ThemedImage = CType(resources.GetObject("btnAdvmEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAdvmCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAdvmCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAdvmCodeEnd, "")
            Me.txtAdvmCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAdvmCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAdvmCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAdvmCodeEnd, System.Drawing.Color.Empty)
            Me.txtAdvmCodeEnd.Location = New System.Drawing.Point(328, 48)
            Me.Validator.SetMaxValue(Me.txtAdvmCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtAdvmCodeEnd, "")
            Me.txtAdvmCodeEnd.Name = "txtAdvmCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAdvmCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAdvmCodeEnd, False)
            Me.txtAdvmCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAdvmCodeEnd.TabIndex = 3
            '
            'lblAdvmEnd
            '
            Me.lblAdvmEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdvmEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAdvmEnd.Location = New System.Drawing.Point(296, 48)
            Me.lblAdvmEnd.Name = "lblAdvmEnd"
            Me.lblAdvmEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAdvmEnd.TabIndex = 15
            Me.lblAdvmEnd.Text = "ถึง"
            Me.lblAdvmEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAdvmStartFind
            '
            Me.btnAdvmStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdvmStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdvmStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAdvmStartFind.Location = New System.Drawing.Point(264, 48)
            Me.btnAdvmStartFind.Name = "btnAdvmStartFind"
            Me.btnAdvmStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAdvmStartFind.TabIndex = 14
            Me.btnAdvmStartFind.TabStop = False
            Me.btnAdvmStartFind.ThemedImage = CType(resources.GetObject("btnAdvmStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAdvmCodeStart
            '
            Me.Validator.SetDataType(Me.txtAdvmCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAdvmCodeStart, "")
            Me.txtAdvmCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAdvmCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAdvmCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAdvmCodeStart, System.Drawing.Color.Empty)
            Me.txtAdvmCodeStart.Location = New System.Drawing.Point(168, 48)
            Me.Validator.SetMaxValue(Me.txtAdvmCodeStart, "")
            Me.Validator.SetMinValue(Me.txtAdvmCodeStart, "")
            Me.txtAdvmCodeStart.Name = "txtAdvmCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAdvmCodeStart, "")
            Me.Validator.SetRequired(Me.txtAdvmCodeStart, False)
            Me.txtAdvmCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAdvmCodeStart.TabIndex = 2
            '
            'lblAdvmStart
            '
            Me.lblAdvmStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdvmStart.ForeColor = System.Drawing.Color.Black
            Me.lblAdvmStart.Location = New System.Drawing.Point(32, 48)
            Me.lblAdvmStart.Name = "lblAdvmStart"
            Me.lblAdvmStart.Size = New System.Drawing.Size(120, 18)
            Me.lblAdvmStart.TabIndex = 12
            Me.lblAdvmStart.Text = "รหัสเงินทดรองจ่าย"
            Me.lblAdvmStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(432, 158)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(352, 158)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'RptAdvanceMoneyFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptAdvanceMoneyFilterSubPanel"
            Me.Size = New System.Drawing.Size(536, 214)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMaster.PerformLayout()
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblAdvmStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.lblAdvmStart}")
      Me.Validator.SetDisplayName(txtAdvmCodeStart, lblAdvmStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Global {ถึง}
      Me.lblAdvmEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAdvmCodeStart, lblAdvmStart.Text)

            Me.lblCustEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.grbDetail}")
            Me.lblCustStart.Text = Me.StringParserService.Parse("${res:Global.CustStart}")
            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Global.AccountBookStart}")
            Me.chkShowDetail.Text = Me.StringParserService.Parse("${res:Global.ShowDetail}")


    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_advm As AdvanceMoney
    Private m_EmployeeStart As Employee
    Private m_EmployeeEnd As Employee
    Private m_AccountBookStart As AccountBook
    Private m_AccountBookEnd As AccountBook
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
        Public Property DocDateEnd() As Date
            Get
                Return m_DocDateEnd
            End Get
            Set(ByVal Value As Date)
                m_DocDateEnd = Value
            End Set
        End Property
        Public Property DocDateStart() As Date
            Get
                Return m_DocDateStart
            End Get
            Set(ByVal Value As Date)
                m_DocDateStart = Value
            End Set
        End Property
    Public Property AdvanceMoney() As AdvanceMoney
      Get
        Return m_advm
      End Get
      Set(ByVal Value As AdvanceMoney)
        m_advm = Value
      End Set
    End Property
    Public Property EmployeeStart() As Employee
      Get
        Return m_EmployeeStart
      End Get
      Set(ByVal Value As Employee)
        m_EmployeeStart = Value
      End Set
    End Property
    Public Property EmployeeEnd() As Employee
      Get
        Return m_EmployeeEnd
      End Get
      Set(ByVal Value As Employee)
        m_EmployeeEnd = Value
      End Set
    End Property
    Public Property AccountBookStart() As AccountBook
      Get
        Return m_AccountBookStart
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookStart = Value
      End Set
    End Property
    Public Property AccountBookEnd() As AccountBook
      Get
        Return m_AccountBookEnd
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookEnd = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub Initialize()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next

      Me.AccountBookStart = New AccountBook
      Me.AccountBookEnd = New AccountBook
      Me.AdvanceMoney = New AdvanceMoney
      Me.EmployeeStart = New Employee
      Me.EmployeeEnd = New Employee
      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
            Dim arr(8) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("AdvmCodeStart", IIf(txtAdvmCodeStart.TextLength > 0, txtAdvmCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("AdvmCodeEnd", IIf(txtAdvmCodeEnd.TextLength > 0, txtAdvmCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("EmpCodeStart", IIf(txtEmpCodeStart.TextLength > 0, txtEmpCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("EmpCodeEnd", IIf(txtEmpCodeEnd.TextLength > 0, txtEmpCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("accountbookfrom", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("accountbookend", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
            arr(8) = New Filter("ShowDetail", Me.chkShowDetail.Checked)
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

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'AdvanceMoneyStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceMoneyStart"
      dpi.Value = Me.txtAdvmCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AdvanceMoneyEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceMoneyEnd"
      dpi.Value = Me.txtAdvmCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocdateStart
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocdateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnAdvmStartFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnAdvmEndFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnEmpStartFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnEmpEndFind.Click, AddressOf Me.btnAdvmFind_Click

      AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeEnd.Validated, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case "txtaccountcodestart"
          AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
        Case "txtaccountcodeend"
          AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' AdvanceMoney
        If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtadvmcodestart", "txtadvmcodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' AdvanceMoney
      If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AdvanceMoney).FullClassName))
        Dim entity As New AdvanceMoney(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtadvmcodestart"
              Me.SetAdvanceMoneyStartDialog(entity)

            Case "txtadvmcodeend"
              Me.SetAdvanceMoneyEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'AdvanceMoney
    Private Sub btnAdvmFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnadvmstartfind"
          myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetAdvanceMoneyStartDialog)
        Case "btnadvmendfind"
          myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetAdvanceMoneyEndDialog)
        Case "btnempstartfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpStartDialog)
        Case "btnempendfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpEndDialog)

      End Select
    End Sub
    Private Sub SetAdvanceMoneyStartDialog(ByVal e As ISimpleEntity)
      Me.txtAdvmCodeStart.Text = CType(e, AdvanceMoney).Code
    End Sub
    Private Sub SetAdvanceMoneyEndDialog(ByVal e As ISimpleEntity)
      Me.txtAdvmCodeEnd.Text = CType(e, AdvanceMoney).Code
    End Sub
    Private Sub SetEmpStartDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeStart.Text = e.Code
      Employee.GetEmployee(Me.txtEmpCodeStart, txtTemp, Me.EmployeeStart)
    End Sub
    Private Sub SetEmpEndDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeEnd.Text = e.Code
      Employee.GetEmployee(Me.txtEmpCodeEnd, txtTemp, Me.EmployeeEnd)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnaccountstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

        Case "btnaccountendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

      End Select
    End Sub
    Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeStart.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
    End Sub
    Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeEnd.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
    End Sub
#End Region

  End Class

End Namespace

