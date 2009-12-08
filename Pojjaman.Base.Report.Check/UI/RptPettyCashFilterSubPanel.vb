Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptPettyCashFilterSubPanel
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
    Friend WithEvents btnPCEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPCCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPCEnd As System.Windows.Forms.Label
    Friend WithEvents btnPCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPCStart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents btnEmpEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmpStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEmpCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCustEnd As System.Windows.Forms.Label
    Friend WithEvents txtEmpCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCustStart As System.Windows.Forms.Label
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents btnCCCodeEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCCEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptPettyCashFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox
      Me.lblCCStart = New System.Windows.Forms.Label
      Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox
      Me.lblAccountEnd = New System.Windows.Forms.Label
      Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAccountCodeStart = New System.Windows.Forms.TextBox
      Me.lblAccountStart = New System.Windows.Forms.Label
      Me.btnEmpEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnEmpStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmpCodeEnd = New System.Windows.Forms.TextBox
      Me.lblCustEnd = New System.Windows.Forms.Label
      Me.txtEmpCodeStart = New System.Windows.Forms.TextBox
      Me.lblCustStart = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.btnPCEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtPCCodeEnd = New System.Windows.Forms.TextBox
      Me.lblPCEnd = New System.Windows.Forms.Label
      Me.btnPCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtPCCodeStart = New System.Windows.Forms.TextBox
      Me.lblPCStart = New System.Windows.Forms.Label
      Me.btnCCCodeEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeEnd = New System.Windows.Forms.TextBox
      Me.lblCCEnd = New System.Windows.Forms.Label
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
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 0)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(528, 200)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
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
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
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
      Me.grbDetail.Controls.Add(Me.btnPCEndFind)
      Me.grbDetail.Controls.Add(Me.txtPCCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblPCEnd)
      Me.grbDetail.Controls.Add(Me.btnPCStartFind)
      Me.grbDetail.Controls.Add(Me.txtPCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblPCStart)
      Me.grbDetail.Controls.Add(Me.btnCCCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtCCCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCCEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(488, 144)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
      Me.btnCCCodeStart.Location = New System.Drawing.Point(264, 88)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 58
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(168, 88)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 6
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(56, 88)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCCStart.TabIndex = 55
      Me.lblCCStart.Text = "ตั้งแต่ Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAccountEndFind
      '
      Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountEndFind.Image = CType(resources.GetObject("btnAccountEndFind.Image"), System.Drawing.Image)
      Me.btnAccountEndFind.Location = New System.Drawing.Point(424, 112)
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
      Me.txtAccountCodeEnd.Location = New System.Drawing.Point(328, 112)
      Me.Validator.SetMaxValue(Me.txtAccountCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
      Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeEnd.TabIndex = 9
      Me.txtAccountCodeEnd.Text = ""
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(296, 112)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAccountEnd.TabIndex = 54
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountStartFind
      '
      Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountStartFind.Image = CType(resources.GetObject("btnAccountStartFind.Image"), System.Drawing.Image)
      Me.btnAccountStartFind.Location = New System.Drawing.Point(264, 112)
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
      Me.txtAccountCodeStart.Location = New System.Drawing.Point(168, 112)
      Me.Validator.SetMaxValue(Me.txtAccountCodeStart, "")
      Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
      Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
      Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeStart.TabIndex = 8
      Me.txtAccountCodeStart.Text = ""
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(72, 112)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAccountStart.TabIndex = 53
      Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnEmpEndFind
      '
      Me.btnEmpEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpEndFind.Image = CType(resources.GetObject("btnEmpEndFind.Image"), System.Drawing.Image)
      Me.btnEmpEndFind.Location = New System.Drawing.Point(424, 64)
      Me.btnEmpEndFind.Name = "btnEmpEndFind"
      Me.btnEmpEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpEndFind.TabIndex = 29
      Me.btnEmpEndFind.TabStop = False
      Me.btnEmpEndFind.ThemedImage = CType(resources.GetObject("btnEmpEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEmpStartFind
      '
      Me.btnEmpStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpStartFind.Image = CType(resources.GetObject("btnEmpStartFind.Image"), System.Drawing.Image)
      Me.btnEmpStartFind.Location = New System.Drawing.Point(264, 64)
      Me.btnEmpStartFind.Name = "btnEmpStartFind"
      Me.btnEmpStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpStartFind.TabIndex = 28
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
      Me.txtEmpCodeEnd.Location = New System.Drawing.Point(328, 64)
      Me.Validator.SetMaxValue(Me.txtEmpCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Name = "txtEmpCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeEnd, "")
      Me.Validator.SetRequired(Me.txtEmpCodeEnd, False)
      Me.txtEmpCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeEnd.TabIndex = 5
      Me.txtEmpCodeEnd.Text = ""
      '
      'lblCustEnd
      '
      Me.lblCustEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCustEnd.Location = New System.Drawing.Point(296, 64)
      Me.lblCustEnd.Name = "lblCustEnd"
      Me.lblCustEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCustEnd.TabIndex = 26
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
      Me.txtEmpCodeStart.Location = New System.Drawing.Point(168, 64)
      Me.Validator.SetMaxValue(Me.txtEmpCodeStart, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Name = "txtEmpCodeStart"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeStart, "")
      Me.Validator.SetRequired(Me.txtEmpCodeStart, False)
      Me.txtEmpCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeStart.TabIndex = 4
      Me.txtEmpCodeStart.Text = ""
      '
      'lblCustStart
      '
      Me.lblCustStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustStart.ForeColor = System.Drawing.Color.Black
      Me.lblCustStart.Location = New System.Drawing.Point(72, 64)
      Me.lblCustStart.Name = "lblCustStart"
      Me.lblCustStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCustStart.TabIndex = 24
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(328, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateEnd.TabIndex = 1
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(168, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(168, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 4
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 6
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(72, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 18
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(296, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 21
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnPCEndFind
      '
      Me.btnPCEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPCEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPCEndFind.Image = CType(resources.GetObject("btnPCEndFind.Image"), System.Drawing.Image)
      Me.btnPCEndFind.Location = New System.Drawing.Point(424, 40)
      Me.btnPCEndFind.Name = "btnPCEndFind"
      Me.btnPCEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnPCEndFind.TabIndex = 17
      Me.btnPCEndFind.TabStop = False
      Me.btnPCEndFind.ThemedImage = CType(resources.GetObject("btnPCEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPCCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPCCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCCodeEnd, "")
      Me.txtPCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCCodeEnd, System.Drawing.Color.Empty)
      Me.txtPCCodeEnd.Location = New System.Drawing.Point(328, 40)
      Me.Validator.SetMaxValue(Me.txtPCCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtPCCodeEnd, "")
      Me.txtPCCodeEnd.Name = "txtPCCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPCCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPCCodeEnd, False)
      Me.txtPCCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtPCCodeEnd.TabIndex = 3
      Me.txtPCCodeEnd.Text = ""
      '
      'lblPCEnd
      '
      Me.lblPCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPCEnd.Location = New System.Drawing.Point(296, 40)
      Me.lblPCEnd.Name = "lblPCEnd"
      Me.lblPCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblPCEnd.TabIndex = 15
      Me.lblPCEnd.Text = "ถึง"
      Me.lblPCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnPCStartFind
      '
      Me.btnPCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPCStartFind.Image = CType(resources.GetObject("btnPCStartFind.Image"), System.Drawing.Image)
      Me.btnPCStartFind.Location = New System.Drawing.Point(264, 40)
      Me.btnPCStartFind.Name = "btnPCStartFind"
      Me.btnPCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnPCStartFind.TabIndex = 14
      Me.btnPCStartFind.TabStop = False
      Me.btnPCStartFind.ThemedImage = CType(resources.GetObject("btnPCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPCCodeStart
      '
      Me.Validator.SetDataType(Me.txtPCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCCodeStart, "")
      Me.txtPCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCCodeStart, System.Drawing.Color.Empty)
      Me.txtPCCodeStart.Location = New System.Drawing.Point(168, 40)
      Me.Validator.SetMaxValue(Me.txtPCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtPCCodeStart, "")
      Me.txtPCCodeStart.Name = "txtPCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtPCCodeStart, "")
      Me.Validator.SetRequired(Me.txtPCCodeStart, False)
      Me.txtPCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtPCCodeStart.TabIndex = 2
      Me.txtPCCodeStart.Text = ""
      '
      'lblPCStart
      '
      Me.lblPCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPCStart.ForeColor = System.Drawing.Color.Black
      Me.lblPCStart.Location = New System.Drawing.Point(72, 40)
      Me.lblPCStart.Name = "lblPCStart"
      Me.lblPCStart.Size = New System.Drawing.Size(88, 18)
      Me.lblPCStart.TabIndex = 12
      Me.lblPCStart.Text = "รหัสเงินสดย่อย"
      Me.lblPCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCCodeEnd
      '
      Me.btnCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeEnd.Image = CType(resources.GetObject("btnCCCodeEnd.Image"), System.Drawing.Image)
      Me.btnCCCodeEnd.Location = New System.Drawing.Point(424, 88)
      Me.btnCCCodeEnd.Name = "btnCCCodeEnd"
      Me.btnCCCodeEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeEnd.TabIndex = 58
      Me.btnCCCodeEnd.TabStop = False
      Me.btnCCCodeEnd.ThemedImage = CType(resources.GetObject("btnCCCodeEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeEnd
      '
      Me.Validator.SetDataType(Me.txtCCCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.txtCCCodeEnd.Location = New System.Drawing.Point(328, 88)
      Me.txtCCCodeEnd.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Name = "txtCCCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtCCCodeEnd, "")
      Me.Validator.SetRequired(Me.txtCCCodeEnd, False)
      Me.txtCCCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeEnd.TabIndex = 7
      Me.txtCCCodeEnd.Text = ""
      '
      'lblCCEnd
      '
      Me.lblCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCCEnd.Location = New System.Drawing.Point(296, 88)
      Me.lblCCEnd.Name = "lblCCEnd"
      Me.lblCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCCEnd.TabIndex = 54
      Me.lblCCEnd.Text = "ถึง"
      Me.lblCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(440, 168)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(360, 168)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 2
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
      'RptPettyCashFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptPettyCashFilterSubPanel"
      Me.Size = New System.Drawing.Size(544, 208)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblPCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.lblPCStart}")
      Me.Validator.SetDisplayName(txtPCCodeStart, lblPCStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Global {ถึง}
      Me.lblPCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtPCCodeStart, lblPCStart.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.lblAccountStart}")

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.lblCCStart}")
      Me.lblCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPettyCashFilterSubPanel.grbDetail}")

    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_pc As PettyCash
    Private m_EmployeeStart As Employee
    Private m_EmployeeEnd As Employee
    Private m_AccountBookStart As AccountBook
    Private m_AccountBookEnd As AccountBook
    Private m_fromcc As CostCenter
    Private m_tocc As CostCenter
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property PettyCash() As PettyCash
      Get
        Return m_pc
      End Get
      Set(ByVal Value As PettyCash)
        m_pc = Value
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
    Public Property FromCostcenter() As CostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        m_fromcc = Value
      End Set
    End Property
    Public Property ToCostcenter() As CostCenter
      Get
        Return m_tocc
      End Get
      Set(ByVal Value As CostCenter)
        m_tocc = Value
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

      Me.PettyCash = New PettyCash
      Me.EmployeeStart = New Employee
      Me.EmployeeEnd = New Employee
      Me.ToCostcenter = New CostCenter
      Me.FromCostcenter = New CostCenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.AccountBookStart = New AccountBook
      Me.AccountBookEnd = New AccountBook

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("PCCodeStart", IIf(txtPCCodeStart.TextLength > 0, txtPCCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("PCCodeEnd", IIf(txtPCCodeEnd.TextLength > 0, txtPCCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("EmpCodeStart", IIf(txtEmpCodeStart.TextLength > 0, txtEmpCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("EmpCodeEnd", IIf(txtEmpCodeEnd.TextLength > 0, txtEmpCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("AccountbookStart", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
      arr(7) = New Filter("Accountbookend", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
      arr(8) = New Filter("fromcc", Me.ValidIdOrDBNull(m_fromcc))
      arr(9) = New Filter("tocc", Me.ValidIdOrDBNull(m_tocc))

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

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = "" ' Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = "" 'Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PettyCash Start
      dpi = New DocPrintingItem
      dpi.Mapping = "PettyCashStart"
      dpi.Value = Me.txtPCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PettyCash End
      dpi = New DocPrintingItem
      dpi.Mapping = "PettyCashEnd"
      dpi.Value = Me.txtPCCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PettyCash Start
      dpi = New DocPrintingItem
      dpi.Mapping = "PettyCashNameStart"
      Dim pcs As PettyCash = New PettyCash(Me.txtPCCodeStart.Text)
      dpi.Value = pcs.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PettyCash End
      dpi = New DocPrintingItem
      dpi.Mapping = "PettyCashNameEnd"
      Dim pce As PettyCash = New PettyCash(Me.txtPCCodeEnd.Text)
      dpi.Value = pce.Name
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

      'EmpCodeStart
      dpi = New DocPrintingItem
      dpi.Mapping = "EmpCodeStart"
      dpi.Value = Me.txtEmpCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'EmpCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "EmpCodeEnd"
      dpi.Value = Me.txtEmpCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Accountbookfrom
      dpi = New DocPrintingItem
      dpi.Mapping = "Accountbookfrom"
      dpi.Value = Me.txtAccountCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountbookEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountbookEnd"
      dpi.Value = Me.txtAccountCodeEnd.Text
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

      AddHandler btnPCStartFind.Click, AddressOf Me.btnPCFind_Click
      AddHandler btnPCEndFind.Click, AddressOf Me.btnPCFind_Click
      AddHandler btnEmpStartFind.Click, AddressOf Me.btnPCFind_Click
      AddHandler btnEmpEndFind.Click, AddressOf Me.btnPCFind_Click

      AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeEnd.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Dim txtAcctbookname As New TextBox
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
          AccountBook.GetAccountBook(txtAccountCodeStart, txtAcctbookname, Me.m_AccountBookStart)
        Case "txtaccountcodeend"
          AccountBook.GetAccountBook(txtAccountCodeEnd, txtAcctbookname, Me.m_AccountBookEnd)
        Case "txtcccodestart"
          Dim txt As New TextBox
          CostCenter.GetCostCenter(txtCCCodeStart, txt, m_fromcc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtcccodeend"
          Dim txt As New TextBox
          CostCenter.GetCostCenter(txtCCCodeEnd, txt, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' PettyCash
        If data.GetDataPresent((New PettyCash).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtpccodestart", "txtpccodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' PettyCash
      If data.GetDataPresent((New PettyCash).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New PettyCash).FullClassName))
        Dim entity As New PettyCash(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpccodestart"
              Me.SetPettyCashStartDialog(entity)

            Case "txtpccodeend"
              Me.SetPettyCashEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'PettyCash
    Private Sub btnPCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnpcstartfind"
          myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetPettyCashStartDialog)
        Case "btnpcendfind"
          myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetPettyCashEndDialog)
        Case "btnempstartfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpStartDialog)
        Case "btnempendfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpEndDialog)
      End Select
    End Sub
    Private Sub SetPettyCashStartDialog(ByVal e As ISimpleEntity)
      Me.txtPCCodeStart.Text = CType(e, PettyCash).Code
    End Sub
    Private Sub SetPettyCashEndDialog(ByVal e As ISimpleEntity)
      Me.txtPCCodeEnd.Text = CType(e, PettyCash).Code
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
      AccountBook.GetAccountBook(txtAccountCodeStart, txtAcctbookname, Me.m_AccountBookStart)
    End Sub
    Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeEnd.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeEnd, txtAcctbookname, Me.m_AccountBookEnd)
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
        Case "btncccodeend"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Dim txt As New TextBox
      CostCenter.GetCostCenter(txtCCCodeStart, txt, m_fromcc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeEnd.Text = e.Code
      Dim txt As New TextBox
      CostCenter.GetCostCenter(txtCCCodeStart, txt, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class

End Namespace

