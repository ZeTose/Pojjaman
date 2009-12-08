Option Explicit On 
Option Strict On

Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptMatWithdrawByCCFilterSubPanel
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
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnFromCCstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtFromCCstart As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCstart As System.Windows.Forms.Label
    Friend WithEvents txtnameCode As System.Windows.Forms.TextBox
    Friend WithEvents lblnameCode As System.Windows.Forms.Label
    Friend WithEvents btnLcistart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblToCCStart As System.Windows.Forms.Label
    Friend WithEvents txtToCCStart As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtToCCEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCEnd As System.Windows.Forms.Label
    Friend WithEvents lblToCCEnd As System.Windows.Forms.Label
    Friend WithEvents btnToCCStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFromCCEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnToCCEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptMatWithdrawByCCFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnLcistart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblnameCode = New System.Windows.Forms.Label
      Me.txtnameCode = New System.Windows.Forms.TextBox
      Me.btnToCCStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCCStart = New System.Windows.Forms.TextBox
      Me.lblToCCStart = New System.Windows.Forms.Label
      Me.btnFromCCstart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtFromCCstart = New System.Windows.Forms.TextBox
      Me.lblFromCCstart = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.txtFromCCEnd = New System.Windows.Forms.TextBox
      Me.btnFromCCEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCCEnd = New System.Windows.Forms.TextBox
      Me.btnToCCEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblFromCCEnd = New System.Windows.Forms.Label
      Me.lblToCCEnd = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(560, 176)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnLcistart)
      Me.grbDetail.Controls.Add(Me.lblnameCode)
      Me.grbDetail.Controls.Add(Me.txtnameCode)
      Me.grbDetail.Controls.Add(Me.btnToCCStart)
      Me.grbDetail.Controls.Add(Me.txtToCCStart)
      Me.grbDetail.Controls.Add(Me.lblToCCStart)
      Me.grbDetail.Controls.Add(Me.btnFromCCstart)
      Me.grbDetail.Controls.Add(Me.txtFromCCstart)
      Me.grbDetail.Controls.Add(Me.lblFromCCstart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtFromCCEnd)
      Me.grbDetail.Controls.Add(Me.btnFromCCEnd)
      Me.grbDetail.Controls.Add(Me.txtToCCEnd)
      Me.grbDetail.Controls.Add(Me.btnToCCEnd)
      Me.grbDetail.Controls.Add(Me.lblFromCCEnd)
      Me.grbDetail.Controls.Add(Me.lblToCCEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(528, 120)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnLcistart
      '
      Me.btnLcistart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLcistart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLcistart.Image = CType(resources.GetObject("btnLcistart.Image"), System.Drawing.Image)
      Me.btnLcistart.Location = New System.Drawing.Point(488, 16)
      Me.btnLcistart.Name = "btnLcistart"
      Me.btnLcistart.Size = New System.Drawing.Size(24, 22)
      Me.btnLcistart.TabIndex = 22
      Me.btnLcistart.TabStop = False
      Me.btnLcistart.ThemedImage = CType(resources.GetObject("btnLcistart.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblnameCode
      '
      Me.lblnameCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblnameCode.ForeColor = System.Drawing.Color.Black
      Me.lblnameCode.Location = New System.Drawing.Point(16, 16)
      Me.lblnameCode.Name = "lblnameCode"
      Me.lblnameCode.Size = New System.Drawing.Size(200, 18)
      Me.lblnameCode.TabIndex = 21
      Me.lblnameCode.Text = "วัสดุ"
      Me.lblnameCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtnameCode
      '
      Me.Validator.SetDataType(Me.txtnameCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtnameCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtnameCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtnameCode, System.Drawing.Color.Empty)
      Me.txtnameCode.Location = New System.Drawing.Point(232, 16)
      Me.Validator.SetMaxValue(Me.txtnameCode, "")
      Me.Validator.SetMinValue(Me.txtnameCode, "")
      Me.txtnameCode.Name = "txtnameCode"
      Me.Validator.SetRegularExpression(Me.txtnameCode, "")
      Me.Validator.SetRequired(Me.txtnameCode, False)
      Me.txtnameCode.Size = New System.Drawing.Size(256, 21)
      Me.txtnameCode.TabIndex = 0
      Me.txtnameCode.Text = ""
      '
      'btnToCCStart
      '
      Me.btnToCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCCStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToCCStart.Image = CType(resources.GetObject("btnToCCStart.Image"), System.Drawing.Image)
      Me.btnToCCStart.Location = New System.Drawing.Point(328, 88)
      Me.btnToCCStart.Name = "btnToCCStart"
      Me.btnToCCStart.Size = New System.Drawing.Size(24, 22)
      Me.btnToCCStart.TabIndex = 11
      Me.btnToCCStart.TabStop = False
      Me.btnToCCStart.ThemedImage = CType(resources.GetObject("btnToCCStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCCStart
      '
      Me.Validator.SetDataType(Me.txtToCCStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCStart, "")
      Me.txtToCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToCCStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToCCStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToCCStart, System.Drawing.Color.Empty)
      Me.txtToCCStart.Location = New System.Drawing.Point(232, 88)
      Me.Validator.SetMaxValue(Me.txtToCCStart, "")
      Me.Validator.SetMinValue(Me.txtToCCStart, "")
      Me.txtToCCStart.Name = "txtToCCStart"
      Me.Validator.SetRegularExpression(Me.txtToCCStart, "")
      Me.Validator.SetRequired(Me.txtToCCStart, False)
      Me.txtToCCStart.Size = New System.Drawing.Size(96, 21)
      Me.txtToCCStart.TabIndex = 5
      Me.txtToCCStart.Text = ""
      '
      'lblToCCStart
      '
      Me.lblToCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblToCCStart.Location = New System.Drawing.Point(8, 88)
      Me.lblToCCStart.Name = "lblToCCStart"
      Me.lblToCCStart.Size = New System.Drawing.Size(208, 18)
      Me.lblToCCStart.TabIndex = 9
      Me.lblToCCStart.Text = "Cost Center ที่ขอเบิก"
      Me.lblToCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnFromCCstart
      '
      Me.btnFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCCstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFromCCstart.Image = CType(resources.GetObject("btnFromCCstart.Image"), System.Drawing.Image)
      Me.btnFromCCstart.Location = New System.Drawing.Point(328, 64)
      Me.btnFromCCstart.Name = "btnFromCCstart"
      Me.btnFromCCstart.Size = New System.Drawing.Size(24, 22)
      Me.btnFromCCstart.TabIndex = 8
      Me.btnFromCCstart.TabStop = False
      Me.btnFromCCstart.ThemedImage = CType(resources.GetObject("btnFromCCstart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtFromCCstart
      '
      Me.Validator.SetDataType(Me.txtFromCCstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCstart, "")
      Me.txtFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCstart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtFromCCstart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCstart, System.Drawing.Color.Empty)
      Me.txtFromCCstart.Location = New System.Drawing.Point(232, 64)
      Me.Validator.SetMaxValue(Me.txtFromCCstart, "")
      Me.Validator.SetMinValue(Me.txtFromCCstart, "")
      Me.txtFromCCstart.Name = "txtFromCCstart"
      Me.Validator.SetRegularExpression(Me.txtFromCCstart, "")
      Me.Validator.SetRequired(Me.txtFromCCstart, False)
      Me.txtFromCCstart.Size = New System.Drawing.Size(96, 21)
      Me.txtFromCCstart.TabIndex = 3
      Me.txtFromCCstart.Text = ""
      '
      'lblFromCCstart
      '
      Me.lblFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCstart.ForeColor = System.Drawing.Color.Black
      Me.lblFromCCstart.Location = New System.Drawing.Point(8, 64)
      Me.lblFromCCstart.Name = "lblFromCCstart"
      Me.lblFromCCstart.Size = New System.Drawing.Size(208, 18)
      Me.lblFromCCstart.TabIndex = 6
      Me.lblFromCCstart.Text = "Cost Center ที่ให้เบิก"
      Me.lblFromCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(392, 40)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 2
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(232, 40)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(232, 40)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(392, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 40)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(208, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(360, 40)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtFromCCEnd
      '
      Me.Validator.SetDataType(Me.txtFromCCEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCEnd, "")
      Me.txtFromCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtFromCCEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCEnd, System.Drawing.Color.Empty)
      Me.txtFromCCEnd.Location = New System.Drawing.Point(392, 64)
      Me.Validator.SetMaxValue(Me.txtFromCCEnd, "")
      Me.Validator.SetMinValue(Me.txtFromCCEnd, "")
      Me.txtFromCCEnd.Name = "txtFromCCEnd"
      Me.Validator.SetRegularExpression(Me.txtFromCCEnd, "")
      Me.Validator.SetRequired(Me.txtFromCCEnd, False)
      Me.txtFromCCEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtFromCCEnd.TabIndex = 4
      Me.txtFromCCEnd.Text = ""
      '
      'btnFromCCEnd
      '
      Me.btnFromCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCCEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFromCCEnd.Image = CType(resources.GetObject("btnFromCCEnd.Image"), System.Drawing.Image)
      Me.btnFromCCEnd.Location = New System.Drawing.Point(488, 64)
      Me.btnFromCCEnd.Name = "btnFromCCEnd"
      Me.btnFromCCEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnFromCCEnd.TabIndex = 8
      Me.btnFromCCEnd.TabStop = False
      Me.btnFromCCEnd.ThemedImage = CType(resources.GetObject("btnFromCCEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCCEnd
      '
      Me.Validator.SetDataType(Me.txtToCCEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCEnd, "")
      Me.txtToCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToCCEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToCCEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToCCEnd, System.Drawing.Color.Empty)
      Me.txtToCCEnd.Location = New System.Drawing.Point(392, 88)
      Me.Validator.SetMaxValue(Me.txtToCCEnd, "")
      Me.Validator.SetMinValue(Me.txtToCCEnd, "")
      Me.txtToCCEnd.Name = "txtToCCEnd"
      Me.Validator.SetRegularExpression(Me.txtToCCEnd, "")
      Me.Validator.SetRequired(Me.txtToCCEnd, False)
      Me.txtToCCEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtToCCEnd.TabIndex = 6
      Me.txtToCCEnd.Text = ""
      '
      'btnToCCEnd
      '
      Me.btnToCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCCEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToCCEnd.Image = CType(resources.GetObject("btnToCCEnd.Image"), System.Drawing.Image)
      Me.btnToCCEnd.Location = New System.Drawing.Point(488, 88)
      Me.btnToCCEnd.Name = "btnToCCEnd"
      Me.btnToCCEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnToCCEnd.TabIndex = 11
      Me.btnToCCEnd.TabStop = False
      Me.btnToCCEnd.ThemedImage = CType(resources.GetObject("btnToCCEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblFromCCEnd
      '
      Me.lblFromCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblFromCCEnd.Location = New System.Drawing.Point(360, 64)
      Me.lblFromCCEnd.Name = "lblFromCCEnd"
      Me.lblFromCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblFromCCEnd.TabIndex = 3
      Me.lblFromCCEnd.Text = "ถึง"
      Me.lblFromCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblToCCEnd
      '
      Me.lblToCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblToCCEnd.Location = New System.Drawing.Point(360, 88)
      Me.lblToCCEnd.Name = "lblToCCEnd"
      Me.lblToCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblToCCEnd.TabIndex = 3
      Me.lblToCCEnd.Text = "ถึง"
      Me.lblToCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(464, 144)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(384, 144)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
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
      'RptMatWithdrawByCCFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptMatWithdrawByCCFilterSubPanel"
      Me.Size = New System.Drawing.Size(576, 192)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblFromCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.lblFromCCstart}")
      Me.Validator.SetDisplayName(txtFromCCstart, lblFromCCstart.Text)
      ' Global {ถึง}
      Me.lblFromCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtFromCCEnd, lblFromCCEnd.Text)

      Me.lblnameCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.lblnameCode}")
      Me.Validator.SetDisplayName(txtnameCode, lblnameCode.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblToCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.lblToCCStart}")
      Me.Validator.SetDisplayName(txtToCCStart, lblToCCStart.Text)
      ' Global {ถึง}
      Me.lblToCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToCCEnd, lblToCCEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatWithdrawByCCFilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
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

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
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
      Dim arr(7) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("FromCCCodeStart", IIf(txtFromCCstart.TextLength > 0, txtFromCCstart.Text, DBNull.Value))
      arr(3) = New Filter("FromCCCodeEnd", IIf(txtFromCCEnd.TextLength > 0, txtFromCCEnd.Text, DBNull.Value))
      arr(4) = New Filter("ToCCCodeStart", IIf(txtToCCStart.TextLength > 0, txtToCCStart.Text, DBNull.Value))
      arr(5) = New Filter("ToCCCodeEnd", IIf(txtToCCEnd.TextLength > 0, txtToCCEnd.Text, DBNull.Value))
      arr(6) = New Filter("lci", IIf(txtnameCode.TextLength > 0, txtnameCode.Text, DBNull.Value))
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

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'docudate start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'docudate end
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'fromcc start
      dpi = New DocPrintingItem
      dpi.Mapping = "fromCCstart"
      dpi.Value = Me.txtFromCCstart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'fromcc end
      dpi = New DocPrintingItem
      dpi.Mapping = "fromCCend"
      dpi.Value = Me.txtFromCCend.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'LCI
      dpi = New DocPrintingItem
      dpi.Mapping = "LCI"
      dpi.Value = Me.txtnameCode.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnFromCCstart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler btnToCCStart.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler txtFromCCstart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnFromCCEnd.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler btnToCCEnd.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler txtFromCCEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnLcistart.Click, AddressOf Me.btnLCIFind_Click
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtfromccstart"
          CostCenter.GetCostCenter(txtFromCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtfromccend"
          CostCenter.GetCostCenter(txtFromCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtfromccstart", "txtfromccend"
                Return True
              Case "txttoccstart", "txttoccend"
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
            Case "txtfromccstart"
              Me.SetFromCCStartDialog(entity)

            Case "txtfromccend"
              Me.SetFromCCEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    ' LCI item ..
    Private Sub btnLCIFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnlcistart"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIStartDialog)
      End Select
    End Sub
    Private Sub SetLCIStartDialog(ByVal e As ISimpleEntity)
      Me.txtnameCode.Text = e.Code
    End Sub
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnfromccstart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCStartDialog)

        Case "btntoccstart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCStartDialog)

        Case "btnfromccend"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCEndDialog)

        Case "btntoccend"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCEndDialog)

      End Select
    End Sub
    Private tempTxt As New TextBox
    Private tempCC1 As New CostCenter
    Private tempCC2 As New CostCenter
    Private Sub SetFromCCStartDialog(ByVal e As ISimpleEntity)
      Me.txtFromCCstart.Text = e.Code
      CostCenter.GetCostCenter(txtFromCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetToCCStartDialog(ByVal e As ISimpleEntity)
      Me.txtToCCStart.Text = e.Code
      CostCenter.GetCostCenter(txtToCCStart, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetFromCCEndDialog(ByVal e As ISimpleEntity)
      Me.txtFromCCEnd.Text = e.Code
      CostCenter.GetCostCenter(txtFromCCEnd, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetToCCEndDialog(ByVal e As ISimpleEntity)
      Me.txtToCCEnd.Text = e.Code
      CostCenter.GetCostCenter(txtToCCEnd, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class
End Namespace

