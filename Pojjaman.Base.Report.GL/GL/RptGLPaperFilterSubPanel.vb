Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptGLPaperFilterSubPanel
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
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodstart As System.Windows.Forms.ComboBox
    Friend WithEvents btnAccountend As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriodstart As System.Windows.Forms.Label
    Friend WithEvents cmbYearacct As System.Windows.Forms.ComboBox
    Friend WithEvents lblYearacct As System.Windows.Forms.Label
    Friend WithEvents lblPeriodend As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodend As System.Windows.Forms.ComboBox
    Friend WithEvents chkOption As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents chkOnlyPosted As System.Windows.Forms.CheckBox
    Friend WithEvents btnAcctBookEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptGLPaperFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnAcctBookEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAcctBookEnd = New System.Windows.Forms.TextBox
      Me.lblAcctBookEnd = New System.Windows.Forms.Label
      Me.btnAcctBookStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAcctBookStart = New System.Windows.Forms.TextBox
      Me.lblAcctBookStart = New System.Windows.Forms.Label
      Me.chkOnlyPosted = New System.Windows.Forms.CheckBox
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox
      Me.lblCCStart = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.chkOption = New System.Windows.Forms.CheckBox
      Me.cmbPeriodend = New System.Windows.Forms.ComboBox
      Me.lblPeriodend = New System.Windows.Forms.Label
      Me.cmbYearacct = New System.Windows.Forms.ComboBox
      Me.lblYearacct = New System.Windows.Forms.Label
      Me.cmbPeriodstart = New System.Windows.Forms.ComboBox
      Me.btnAccountend = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAccountEnd = New System.Windows.Forms.TextBox
      Me.lblAccountEnd = New System.Windows.Forms.Label
      Me.btnAccountstart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAccountStart = New System.Windows.Forms.TextBox
      Me.lblAccountStart = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.lblPeriodstart = New System.Windows.Forms.Label
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
      Me.grbMaster.Size = New System.Drawing.Size(544, 248)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnAcctBookEndFind)
      Me.grbDetail.Controls.Add(Me.txtAcctBookEnd)
      Me.grbDetail.Controls.Add(Me.lblAcctBookEnd)
      Me.grbDetail.Controls.Add(Me.btnAcctBookStartFind)
      Me.grbDetail.Controls.Add(Me.txtAcctBookStart)
      Me.grbDetail.Controls.Add(Me.lblAcctBookStart)
      Me.grbDetail.Controls.Add(Me.chkOnlyPosted)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.chkOption)
      Me.grbDetail.Controls.Add(Me.cmbPeriodend)
      Me.grbDetail.Controls.Add(Me.lblPeriodend)
      Me.grbDetail.Controls.Add(Me.cmbYearacct)
      Me.grbDetail.Controls.Add(Me.lblYearacct)
      Me.grbDetail.Controls.Add(Me.cmbPeriodstart)
      Me.grbDetail.Controls.Add(Me.btnAccountend)
      Me.grbDetail.Controls.Add(Me.txtAccountEnd)
      Me.grbDetail.Controls.Add(Me.lblAccountEnd)
      Me.grbDetail.Controls.Add(Me.btnAccountstart)
      Me.grbDetail.Controls.Add(Me.txtAccountStart)
      Me.grbDetail.Controls.Add(Me.lblAccountStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblPeriodstart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(520, 192)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnAcctBookEndFind
      '
      Me.btnAcctBookEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookEndFind.Image = CType(resources.GetObject("btnAcctBookEndFind.Image"), System.Drawing.Image)
      Me.btnAcctBookEndFind.Location = New System.Drawing.Point(424, 112)
      Me.btnAcctBookEndFind.Name = "btnAcctBookEndFind"
      Me.btnAcctBookEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookEndFind.TabIndex = 42
      Me.btnAcctBookEndFind.TabStop = False
      Me.btnAcctBookEndFind.ThemedImage = CType(resources.GetObject("btnAcctBookEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookEnd
      '
      Me.Validator.SetDataType(Me.txtAcctBookEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.txtAcctBookEnd.Location = New System.Drawing.Point(328, 112)
      Me.Validator.SetMaxValue(Me.txtAcctBookEnd, "")
      Me.Validator.SetMinValue(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Name = "txtAcctBookEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctBookEnd, "")
      Me.Validator.SetRequired(Me.txtAcctBookEnd, False)
      Me.txtAcctBookEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookEnd.TabIndex = 41
      Me.txtAcctBookEnd.Text = ""
      '
      'lblAcctBookEnd
      '
      Me.lblAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookEnd.Location = New System.Drawing.Point(296, 112)
      Me.lblAcctBookEnd.Name = "lblAcctBookEnd"
      Me.lblAcctBookEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAcctBookEnd.TabIndex = 40
      Me.lblAcctBookEnd.Text = "ถึง"
      Me.lblAcctBookEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctBookStartFind
      '
      Me.btnAcctBookStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookStartFind.Image = CType(resources.GetObject("btnAcctBookStartFind.Image"), System.Drawing.Image)
      Me.btnAcctBookStartFind.Location = New System.Drawing.Point(264, 112)
      Me.btnAcctBookStartFind.Name = "btnAcctBookStartFind"
      Me.btnAcctBookStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookStartFind.TabIndex = 39
      Me.btnAcctBookStartFind.TabStop = False
      Me.btnAcctBookStartFind.ThemedImage = CType(resources.GetObject("btnAcctBookStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookStart
      '
      Me.Validator.SetDataType(Me.txtAcctBookStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.txtAcctBookStart.Location = New System.Drawing.Point(168, 112)
      Me.Validator.SetMaxValue(Me.txtAcctBookStart, "")
      Me.Validator.SetMinValue(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Name = "txtAcctBookStart"
      Me.Validator.SetRegularExpression(Me.txtAcctBookStart, "")
      Me.Validator.SetRequired(Me.txtAcctBookStart, False)
      Me.txtAcctBookStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookStart.TabIndex = 38
      Me.txtAcctBookStart.Text = ""
      '
      'lblAcctBookStart
      '
      Me.lblAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookStart.Location = New System.Drawing.Point(8, 112)
      Me.lblAcctBookStart.Name = "lblAcctBookStart"
      Me.lblAcctBookStart.Size = New System.Drawing.Size(152, 18)
      Me.lblAcctBookStart.TabIndex = 37
      Me.lblAcctBookStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAcctBookStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkOnlyPosted
      '
      Me.chkOnlyPosted.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOnlyPosted.Location = New System.Drawing.Point(328, 160)
      Me.chkOnlyPosted.Name = "chkOnlyPosted"
      Me.chkOnlyPosted.Size = New System.Drawing.Size(136, 24)
      Me.chkOnlyPosted.TabIndex = 32
      Me.chkOnlyPosted.Text = "เฉพาะรายการที่ Post แล้ว"
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(168, 160)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 28
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
      Me.btnCCCodeStart.Location = New System.Drawing.Point(264, 136)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 27
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(168, 136)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 26
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(8, 136)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(152, 18)
      Me.lblCCStart.TabIndex = 24
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(288, 136)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.Text = ""
      '
      'chkOption
      '
      Me.chkOption.Checked = True
      Me.chkOption.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkOption.Location = New System.Drawing.Point(312, 16)
      Me.chkOption.Name = "chkOption"
      Me.chkOption.Size = New System.Drawing.Size(192, 24)
      Me.chkOption.TabIndex = 2
      Me.chkOption.Text = "กำหนดตามงวดบัญชี"
      '
      'cmbPeriodend
      '
      Me.cmbPeriodend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPeriodend.Location = New System.Drawing.Point(328, 40)
      Me.cmbPeriodend.Name = "cmbPeriodend"
      Me.cmbPeriodend.TabIndex = 6
      '
      'lblPeriodend
      '
      Me.lblPeriodend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriodend.ForeColor = System.Drawing.Color.Black
      Me.lblPeriodend.Location = New System.Drawing.Point(296, 40)
      Me.lblPeriodend.Name = "lblPeriodend"
      Me.lblPeriodend.Size = New System.Drawing.Size(24, 18)
      Me.lblPeriodend.TabIndex = 5
      Me.lblPeriodend.Text = "ถึง"
      Me.lblPeriodend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'cmbYearacct
      '
      Me.cmbYearacct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYearacct.Location = New System.Drawing.Point(168, 16)
      Me.cmbYearacct.Name = "cmbYearacct"
      Me.cmbYearacct.TabIndex = 1
      '
      'lblYearacct
      '
      Me.lblYearacct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYearacct.ForeColor = System.Drawing.Color.Black
      Me.lblYearacct.Location = New System.Drawing.Point(8, 16)
      Me.lblYearacct.Name = "lblYearacct"
      Me.lblYearacct.Size = New System.Drawing.Size(152, 18)
      Me.lblYearacct.TabIndex = 0
      Me.lblYearacct.Text = "ปีภาษี"
      Me.lblYearacct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbPeriodstart
      '
      Me.cmbPeriodstart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPeriodstart.Location = New System.Drawing.Point(168, 40)
      Me.cmbPeriodstart.Name = "cmbPeriodstart"
      Me.cmbPeriodstart.TabIndex = 4
      '
      'btnAccountend
      '
      Me.btnAccountend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountend.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountend.Image = CType(resources.GetObject("btnAccountend.Image"), System.Drawing.Image)
      Me.btnAccountend.Location = New System.Drawing.Point(424, 88)
      Me.btnAccountend.Name = "btnAccountend"
      Me.btnAccountend.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountend.TabIndex = 18
      Me.btnAccountend.TabStop = False
      Me.btnAccountend.ThemedImage = CType(resources.GetObject("btnAccountend.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountEnd
      '
      Me.Validator.SetDataType(Me.txtAccountEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountEnd, "")
      Me.txtAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountEnd, System.Drawing.Color.Empty)
      Me.txtAccountEnd.Location = New System.Drawing.Point(328, 88)
      Me.txtAccountEnd.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtAccountEnd, "")
      Me.Validator.SetMinValue(Me.txtAccountEnd, "")
      Me.txtAccountEnd.Name = "txtAccountEnd"
      Me.Validator.SetRegularExpression(Me.txtAccountEnd, "")
      Me.Validator.SetRequired(Me.txtAccountEnd, False)
      Me.txtAccountEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountEnd.TabIndex = 17
      Me.txtAccountEnd.Text = ""
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(296, 88)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAccountEnd.TabIndex = 16
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountstart
      '
      Me.btnAccountstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountstart.Image = CType(resources.GetObject("btnAccountstart.Image"), System.Drawing.Image)
      Me.btnAccountstart.Location = New System.Drawing.Point(264, 88)
      Me.btnAccountstart.Name = "btnAccountstart"
      Me.btnAccountstart.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountstart.TabIndex = 15
      Me.btnAccountstart.TabStop = False
      Me.btnAccountstart.ThemedImage = CType(resources.GetObject("btnAccountstart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountStart
      '
      Me.Validator.SetDataType(Me.txtAccountStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountStart, "")
      Me.txtAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountStart, System.Drawing.Color.Empty)
      Me.txtAccountStart.Location = New System.Drawing.Point(168, 88)
      Me.txtAccountStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtAccountStart, "")
      Me.Validator.SetMinValue(Me.txtAccountStart, "")
      Me.txtAccountStart.Name = "txtAccountStart"
      Me.Validator.SetRegularExpression(Me.txtAccountStart, "")
      Me.Validator.SetRequired(Me.txtAccountStart, False)
      Me.txtAccountStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountStart.TabIndex = 14
      Me.txtAccountStart.Text = ""
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(8, 88)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(152, 18)
      Me.lblAccountStart.TabIndex = 13
      Me.lblAccountStart.Text = "ตั้งแต่รหัสบัญชี"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(328, 64)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 11
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(168, 64)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 8
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Enabled = False
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(168, 64)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 9
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Enabled = False
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 64)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 12
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 64)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(152, 18)
      Me.lblDocDateStart.TabIndex = 7
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(296, 64)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 10
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblPeriodstart
      '
      Me.lblPeriodstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriodstart.ForeColor = System.Drawing.Color.Black
      Me.lblPeriodstart.Location = New System.Drawing.Point(8, 40)
      Me.lblPeriodstart.Name = "lblPeriodstart"
      Me.lblPeriodstart.Size = New System.Drawing.Size(152, 18)
      Me.lblPeriodstart.TabIndex = 3
      Me.lblPeriodstart.Text = "งวดบัญชี"
      Me.lblPeriodstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(456, 216)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(376, 216)
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
      'RptGLPaperFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptGLPaperFilterSubPanel"
      Me.Size = New System.Drawing.Size(608, 264)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblAcctBookStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblAcctBookStart}")
      Me.Validator.SetDisplayName(txtAcctBookStart, lblAcctBookStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblPeriodstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblPeriodstart}")

      Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblAccountStart}")
      Me.Validator.SetDisplayName(txtAccountStart, lblAccountStart.Text)

      ' Global {ถึง}
      Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAccountEnd, lblAccountEnd.Text)

      Me.lblAcctBookEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAcctBookEnd, lblAcctBookEnd.Text)

      Me.lblPeriodend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.grbDetail}")

      Me.lblYearacct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.lblYearacct}")
      Me.chkOption.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.chkOption}")

      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.chkIncludeChildren}")
      Me.chkOnlyPosted.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLPaperFilterSubPanel.chkOnlyPosted}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter
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

    Public Property Costcenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' ปี
      Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = DateAdd(DateInterval.Year, i, baseDate)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      myDateTimeService.ListYearsInComboBox(Me.cmbYearacct, years)

      ' งวดบัญชี
      Me.cmbPeriodstart.Items.Clear()
      Me.cmbPeriodend.Items.Clear()
      Dim period As String
      For i As Integer = 1 To 12
        period = i.ToString("0#")
        Me.cmbPeriodstart.Items.Add(period)
        Me.cmbPeriodend.Items.Add(period)
      Next
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
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

      Me.Costcenter = New Costcenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.cmbYearacct.SelectedIndex = 0
      Me.cmbPeriodstart.SelectedIndex = 0
      Me.cmbPeriodend.SelectedIndex = 0

      Me.chkOption.Checked = True
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(12) As Filter
      arr(0) = New Filter("YearAcct", Me.cmbYearacct.SelectedValue)
      arr(1) = New Filter("periodStart", IIf(Me.cmbPeriodstart.Text.Length > 0, Me.cmbPeriodstart.Text, DBNull.Value))
      arr(2) = New Filter("periodEnd", IIf(Me.cmbPeriodend.Text.Length > 0, Me.cmbPeriodend.Text, DBNull.Value))
      arr(3) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(4) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(5) = New Filter("acctCodeStart", IIf(txtAccountStart.TextLength > 0, txtAccountStart.Text, DBNull.Value))
      arr(6) = New Filter("acctCodeEnd", IIf(txtAccountEnd.TextLength > 0, txtAccountEnd.Text, DBNull.Value))
      arr(7) = New Filter("isByPeriod", IIf(chkOption.Checked, 1, 0))
      arr(8) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(9) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(10) = New Filter("OnlyPosted", Me.chkOnlyPosted.Checked)
      arr(11) = New Filter("AcctBookCodeStart", IIf(txtAcctBookStart.TextLength > 0, txtAcctBookStart.Text, DBNull.Value))
      arr(12) = New Filter("AcctBookCodeEnd", IIf(txtAcctBookEnd.TextLength > 0, txtAcctBookEnd.Text, DBNull.Value))
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

      If chkOption.Checked Then
        'year
        dpi = New DocPrintingItem
        dpi.Mapping = "year"
        dpi.Value = Me.cmbYearacct.Text
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        ' period start
        dpi = New DocPrintingItem
        dpi.Mapping = "periodstart"
        dpi.Value = cmbPeriodstart.Text
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        ' period end
        dpi = New DocPrintingItem
        dpi.Mapping = "periodend"
        dpi.Value = cmbPeriodend.Text
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Else
        'DocDateStart
        dpi = New DocPrintingItem
        dpi.Mapping = "DocDateStart"
        dpi.Value = Me.txtDocDateStart.Text
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'DocDateEnd
        dpi = New DocPrintingItem
        dpi.Mapping = "DocDateEnd"
        dpi.Value = Me.txtDocDateEnd.Text
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'account start
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountStart"
      dpi.Value = Me.txtAccountStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'account end
      dpi = New DocPrintingItem
      dpi.Mapping = "Accountend"
      dpi.Value = Me.txtAccountEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountBookStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookStart"
      dpi.Value = Me.txtAcctBookStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountBookEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookEnd"
      dpi.Value = Me.txtAcctBookEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ' EndDate
      If chkOption.Checked Then
        If TypeOf cmbYearacct.SelectedItem Is ValueDisplayPair Then
          Dim code As String = cmbYearacct.SelectedText
          Dim myItem As ValueDisplayPair = CType(cmbYearacct.SelectedItem, ValueDisplayPair)
          Dim dt As Date = CType(myItem.Value, Date)
          Dim period As AccountPeriod = AccountPeriod.GetAccountPeriod(dt, code)
          If period Is Nothing Then
            Dim acctPeriodcoll As AccountPeriodCollection = AccountPeriod.GetLastestAccountPeriod()
            period = acctPeriodcoll.Item(acctPeriodcoll.Count - 1)
          End If

          ' EndDateShort
          dpi = New DocPrintingItem
          dpi.Mapping = "enddateshort"
          dpi.Value = period.EndDate.ToShortDateString
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          ' EndDateFull
          dpi = New DocPrintingItem
          dpi.Mapping = "enddatefull"
          dpi.Value = period.EndDate.ToLongDateString
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

        End If
      Else
        ' EndDateShort
        dpi = New DocPrintingItem
        dpi.Mapping = "enddateshort"
        dpi.Value = DocDateStart.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        ' EndDateFull
        dpi = New DocPrintingItem
        dpi.Mapping = "enddatefull"
        dpi.Value = DocDateStart.ToLongDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.txtCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildInclude
      If Me.chkIncludeChildren.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childincluded"
        dpi.Value = "(รวมในสังกัด)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnAccountstart.Click, AddressOf Me.btnAccountFind_Click
      AddHandler btnAccountend.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAcctBookStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnAcctBookEndFind.Click, AddressOf Me.btnAccountBookFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler chkOption.CheckedChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "chkoption"
          If chkOption.Checked Then
            txtDocDateStart.Enabled = False
            txtDocDateEnd.Enabled = False
            dtpDocDateStart.Enabled = False
            dtpDocDateEnd.Enabled = False

            cmbPeriodstart.Enabled = True
            cmbPeriodend.Enabled = True
            cmbYearacct.Enabled = True
          Else
            txtDocDateStart.Enabled = True
            txtDocDateEnd.Enabled = True
            dtpDocDateStart.Enabled = True
            dtpDocDateEnd.Enabled = True

            cmbPeriodstart.Enabled = False
            cmbPeriodend.Enabled = False
            cmbYearacct.Enabled = False
          End If

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
        ' Account
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtaccountstart", "txtaccountend"
                Return True
            End Select
          End If
        End If
        'AccountBook
        If data.GetDataPresent((New AccountBook).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtacctbookstart", "txtacctbookend"
                Return True
            End Select
          End If
        End If
        ' Costcenter
        If data.GetDataPresent((New Costcenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart", "txtcccodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' account
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtaccountstart"
              Me.setaccountstartdialog(entity)

            Case "txtaccountend"
              Me.setaccountenddialog(entity)

          End Select
        End If
      End If
      ' account book
      If data.GetDataPresent((New AccountBook).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AccountBook).FullClassName))
        Dim entity As New AccountBook(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtacctbookstart"
              Me.SetAccountBookStartDialog(entity)

            Case "txtacctbookend"
              Me.SetAccountBookEndDialog(entity)

          End Select
        End If
      End If
      ' Costcenter
      If data.GetDataPresent((New Costcenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
        Dim entity As New Costcenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcostcentercodeend"
              Me.SetCCCodeStartDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    ' account
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnaccountstart"
          myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountStartDialog)

        Case "btnaccountend"
          myentitypanelservice.OpenTreeDialog(New Account, AddressOf SetAccountEndDialog)

      End Select
    End Sub
    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctbookstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookStartDialog)

        Case "btnacctbookendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookEndDialog)

      End Select
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetAccountStartDialog(ByVal e As ISimpleEntity)
      Me.txtAccountStart.Text = e.Code
    End Sub
    Private Sub SetAccountEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountEnd.Text = e.Code
    End Sub
    Private Sub SetAccountBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookStart.Text = e.Code
    End Sub
    Private Sub SetAccountBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookEnd.Text = e.Code
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc)
    End Sub
#End Region

  End Class

End Namespace

