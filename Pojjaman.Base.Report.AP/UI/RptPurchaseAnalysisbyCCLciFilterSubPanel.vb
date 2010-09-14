Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPurchaseAnalysisbyCCLciFilterSubPanel
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
    Friend WithEvents btnCostcenterCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents TxtCostcenterCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblCostcenterEnd As System.Windows.Forms.Label
        Friend WithEvents btnCostcenterCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents TxtCostcenterCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblLciEnd As System.Windows.Forms.Label
    Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblLciStart As System.Windows.Forms.Label
    Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents grbTypeDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAssets As System.Windows.Forms.CheckBox
    Friend WithEvents chkEtc As System.Windows.Forms.CheckBox
    Friend WithEvents chkMechine As System.Windows.Forms.CheckBox
    Friend WithEvents chkWage As System.Windows.Forms.CheckBox
    Friend WithEvents chkLCI As System.Windows.Forms.CheckBox
    Friend WithEvents btnToolend As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToolend As System.Windows.Forms.TextBox
    Friend WithEvents lblToolend As System.Windows.Forms.Label
    Friend WithEvents btnToolstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToolstart As System.Windows.Forms.TextBox
    Friend WithEvents lblToolStart As System.Windows.Forms.Label
    Friend WithEvents chkTool As System.Windows.Forms.CheckBox
    Friend WithEvents lblCostcenterStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptPurchaseAnalysisbyCCLciFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbTypeDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAssets = New System.Windows.Forms.CheckBox()
      Me.chkEtc = New System.Windows.Forms.CheckBox()
      Me.chkMechine = New System.Windows.Forms.CheckBox()
      Me.chkWage = New System.Windows.Forms.CheckBox()
      Me.chkLCI = New System.Windows.Forms.CheckBox()
      Me.txtLciCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblLciEnd = New System.Windows.Forms.Label()
      Me.txtLciCodeStart = New System.Windows.Forms.TextBox()
      Me.lblLciStart = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnToolend = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToolend = New System.Windows.Forms.TextBox()
      Me.lblToolend = New System.Windows.Forms.Label()
      Me.btnToolstart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToolstart = New System.Windows.Forms.TextBox()
      Me.lblToolStart = New System.Windows.Forms.Label()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCostcenterCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.TxtCostcenterCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblCostcenterEnd = New System.Windows.Forms.Label()
      Me.btnCostcenterCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.TxtCostcenterCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCostcenterStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.chkTool = New System.Windows.Forms.CheckBox()
      Me.grbMaster.SuspendLayout()
      Me.grbTypeDisplay.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.grbTypeDisplay)
      Me.grbMaster.Controls.Add(Me.txtLciCodeEnd)
      Me.grbMaster.Controls.Add(Me.lblLciEnd)
      Me.grbMaster.Controls.Add(Me.txtLciCodeStart)
      Me.grbMaster.Controls.Add(Me.lblLciStart)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(609, 197)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbTypeDisplay
      '
      Me.grbTypeDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbTypeDisplay.Controls.Add(Me.chkAssets)
      Me.grbTypeDisplay.Controls.Add(Me.chkTool)
      Me.grbTypeDisplay.Controls.Add(Me.chkEtc)
      Me.grbTypeDisplay.Controls.Add(Me.chkMechine)
      Me.grbTypeDisplay.Controls.Add(Me.chkWage)
      Me.grbTypeDisplay.Controls.Add(Me.chkLCI)
      Me.grbTypeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTypeDisplay.Location = New System.Drawing.Point(446, 16)
      Me.grbTypeDisplay.Name = "grbTypeDisplay"
      Me.grbTypeDisplay.Size = New System.Drawing.Size(150, 145)
      Me.grbTypeDisplay.TabIndex = 7
      Me.grbTypeDisplay.TabStop = False
      Me.grbTypeDisplay.Text = "การแสดงผลตามประเภท"
      '
      'chkAssets
      '
      Me.chkAssets.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAssets.Location = New System.Drawing.Point(15, 109)
      Me.chkAssets.Name = "chkAssets"
      Me.chkAssets.Size = New System.Drawing.Size(88, 16)
      Me.chkAssets.TabIndex = 16
      Me.chkAssets.Text = "สินทรัพย์"
      '
      'chkEtc
      '
      Me.chkEtc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEtc.Location = New System.Drawing.Point(15, 61)
      Me.chkEtc.Name = "chkEtc"
      Me.chkEtc.Size = New System.Drawing.Size(128, 16)
      Me.chkEtc.TabIndex = 17
      Me.chkEtc.Text = "อื่น ๆ"
      '
      'chkMechine
      '
      Me.chkMechine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkMechine.Location = New System.Drawing.Point(15, 93)
      Me.chkMechine.Name = "chkMechine"
      Me.chkMechine.Size = New System.Drawing.Size(96, 16)
      Me.chkMechine.TabIndex = 15
      Me.chkMechine.Text = "ค่าเช่าเครื่องจักร "
      '
      'chkWage
      '
      Me.chkWage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkWage.Location = New System.Drawing.Point(15, 77)
      Me.chkWage.Name = "chkWage"
      Me.chkWage.Size = New System.Drawing.Size(128, 16)
      Me.chkWage.TabIndex = 14
      Me.chkWage.Text = "ค่าแรง"
      '
      'chkLCI
      '
      Me.chkLCI.Checked = True
      Me.chkLCI.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkLCI.Location = New System.Drawing.Point(15, 29)
      Me.chkLCI.Name = "chkLCI"
      Me.chkLCI.Size = New System.Drawing.Size(128, 16)
      Me.chkLCI.TabIndex = 13
      Me.chkLCI.Text = "วัสดุ"
      '
      'txtLciCodeEnd
      '
      Me.Validator.SetDataType(Me.txtLciCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.txtLciCodeEnd.Location = New System.Drawing.Point(304, 105)
      Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
      Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
      Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeEnd.TabIndex = 14
      '
      'lblLciEnd
      '
      Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
      Me.lblLciEnd.Location = New System.Drawing.Point(272, 105)
      Me.lblLciEnd.Name = "lblLciEnd"
      Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblLciEnd.TabIndex = 13
      Me.lblLciEnd.Text = "ถึง"
      Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtLciCodeStart
      '
      Me.Validator.SetDataType(Me.txtLciCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.txtLciCodeStart.Location = New System.Drawing.Point(144, 105)
      Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Name = "txtLciCodeStart"
      Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
      Me.Validator.SetRequired(Me.txtLciCodeStart, False)
      Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeStart.TabIndex = 12
      '
      'lblLciStart
      '
      Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciStart.ForeColor = System.Drawing.Color.Black
      Me.lblLciStart.Location = New System.Drawing.Point(48, 105)
      Me.lblLciStart.Name = "lblLciStart"
      Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
      Me.lblLciStart.TabIndex = 11
      Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
      Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnToolend)
      Me.grbDetail.Controls.Add(Me.txtToolend)
      Me.grbDetail.Controls.Add(Me.lblToolend)
      Me.grbDetail.Controls.Add(Me.btnToolstart)
      Me.grbDetail.Controls.Add(Me.txtToolstart)
      Me.grbDetail.Controls.Add(Me.lblToolStart)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSuppliStart)
      Me.grbDetail.Controls.Add(Me.btnLciEndFind)
      Me.grbDetail.Controls.Add(Me.btnLciStartFind)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeEndFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCostcenterEnd)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeStartFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCostcenterStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(424, 146)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnToolend
      '
      Me.btnToolend.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolend.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolend.Location = New System.Drawing.Point(384, 113)
      Me.btnToolend.Name = "btnToolend"
      Me.btnToolend.Size = New System.Drawing.Size(24, 22)
      Me.btnToolend.TabIndex = 41
      Me.btnToolend.TabStop = False
      Me.btnToolend.ThemedImage = CType(resources.GetObject("btnToolend.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToolend
      '
      Me.Validator.SetDataType(Me.txtToolend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolend, "")
      Me.txtToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolend, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolend, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolend, System.Drawing.Color.Empty)
      Me.txtToolend.Location = New System.Drawing.Point(288, 113)
      Me.Validator.SetMinValue(Me.txtToolend, "")
      Me.txtToolend.Name = "txtToolend"
      Me.Validator.SetRegularExpression(Me.txtToolend, "")
      Me.Validator.SetRequired(Me.txtToolend, False)
      Me.txtToolend.Size = New System.Drawing.Size(96, 21)
      Me.txtToolend.TabIndex = 40
      '
      'lblToolend
      '
      Me.lblToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolend.ForeColor = System.Drawing.Color.Black
      Me.lblToolend.Location = New System.Drawing.Point(256, 113)
      Me.lblToolend.Name = "lblToolend"
      Me.lblToolend.Size = New System.Drawing.Size(24, 18)
      Me.lblToolend.TabIndex = 39
      Me.lblToolend.Text = "ถึง"
      Me.lblToolend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnToolstart
      '
      Me.btnToolstart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolstart.Location = New System.Drawing.Point(224, 113)
      Me.btnToolstart.Name = "btnToolstart"
      Me.btnToolstart.Size = New System.Drawing.Size(24, 22)
      Me.btnToolstart.TabIndex = 38
      Me.btnToolstart.TabStop = False
      Me.btnToolstart.ThemedImage = CType(resources.GetObject("btnToolstart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToolstart
      '
      Me.Validator.SetDataType(Me.txtToolstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolstart, "")
      Me.txtToolstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolstart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolstart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolstart, System.Drawing.Color.Empty)
      Me.txtToolstart.Location = New System.Drawing.Point(128, 113)
      Me.Validator.SetMinValue(Me.txtToolstart, "")
      Me.txtToolstart.Name = "txtToolstart"
      Me.Validator.SetRegularExpression(Me.txtToolstart, "")
      Me.Validator.SetRequired(Me.txtToolstart, False)
      Me.txtToolstart.Size = New System.Drawing.Size(96, 21)
      Me.txtToolstart.TabIndex = 37
      '
      'lblToolStart
      '
      Me.lblToolStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolStart.ForeColor = System.Drawing.Color.Black
      Me.lblToolStart.Location = New System.Drawing.Point(24, 113)
      Me.lblToolStart.Name = "lblToolStart"
      Me.lblToolStart.Size = New System.Drawing.Size(97, 16)
      Me.lblToolStart.TabIndex = 36
      Me.lblToolStart.Text = "ตั้งแต่รหัสเครื่องมือ"
      Me.lblToolStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(384, 64)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 25
      Me.btnSuppliEndFind.TabStop = False
      Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(288, 64)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 21
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(256, 64)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 23
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(224, 64)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 24
      Me.btnSuppliStartFind.TabStop = False
      Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(128, 64)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 20
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(32, 64)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(96, 18)
      Me.lblSuppliStart.TabIndex = 22
      Me.lblSuppliStart.Text = "Start Supplier:"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnLciEndFind
      '
      Me.btnLciEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciEndFind.Location = New System.Drawing.Point(384, 88)
      Me.btnLciEndFind.Name = "btnLciEndFind"
      Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciEndFind.TabIndex = 19
      Me.btnLciEndFind.TabStop = False
      Me.btnLciEndFind.ThemedImage = CType(resources.GetObject("btnLciEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnLciStartFind
      '
      Me.btnLciStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciStartFind.Location = New System.Drawing.Point(224, 88)
      Me.btnLciStartFind.Name = "btnLciStartFind"
      Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciStartFind.TabIndex = 18
      Me.btnLciStartFind.TabStop = False
      Me.btnLciStartFind.ThemedImage = CType(resources.GetObject("btnLciStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCostcenterCodeEndFind
      '
      Me.btnCostcenterCodeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeEndFind.Location = New System.Drawing.Point(384, 40)
      Me.btnCostcenterCodeEndFind.Name = "btnCostcenterCodeEndFind"
      Me.btnCostcenterCodeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeEndFind.TabIndex = 17
      Me.btnCostcenterCodeEndFind.TabStop = False
      Me.btnCostcenterCodeEndFind.ThemedImage = CType(resources.GetObject("btnCostcenterCodeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'TxtCostcenterCodeEnd
      '
      Me.Validator.SetDataType(Me.TxtCostcenterCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtCostcenterCodeEnd, "")
      Me.TxtCostcenterCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtCostcenterCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtCostcenterCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtCostcenterCodeEnd, System.Drawing.Color.Empty)
      Me.TxtCostcenterCodeEnd.Location = New System.Drawing.Point(288, 40)
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeEnd, "")
      Me.TxtCostcenterCodeEnd.Name = "TxtCostcenterCodeEnd"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeEnd, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeEnd, False)
      Me.TxtCostcenterCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeEnd.TabIndex = 16
      '
      'lblCostcenterEnd
      '
      Me.lblCostcenterEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterEnd.Location = New System.Drawing.Point(256, 40)
      Me.lblCostcenterEnd.Name = "lblCostcenterEnd"
      Me.lblCostcenterEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCostcenterEnd.TabIndex = 15
      Me.lblCostcenterEnd.Text = "ถึง"
      Me.lblCostcenterEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCostcenterCodeStartFind
      '
      Me.btnCostcenterCodeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeStartFind.Location = New System.Drawing.Point(224, 40)
      Me.btnCostcenterCodeStartFind.Name = "btnCostcenterCodeStartFind"
      Me.btnCostcenterCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeStartFind.TabIndex = 14
      Me.btnCostcenterCodeStartFind.TabStop = False
      Me.btnCostcenterCodeStartFind.ThemedImage = CType(resources.GetObject("btnCostcenterCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'TxtCostcenterCodeStart
      '
      Me.Validator.SetDataType(Me.TxtCostcenterCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtCostcenterCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.TxtCostcenterCodeStart.Location = New System.Drawing.Point(128, 40)
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Name = "TxtCostcenterCodeStart"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeStart, False)
      Me.TxtCostcenterCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeStart.TabIndex = 13
      '
      'lblCostcenterStart
      '
      Me.lblCostcenterStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterStart.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterStart.Location = New System.Drawing.Point(8, 40)
      Me.lblCostcenterStart.Name = "lblCostcenterStart"
      Me.lblCostcenterStart.Size = New System.Drawing.Size(112, 18)
      Me.lblCostcenterStart.TabIndex = 12
      Me.lblCostcenterStart.Text = "ตั้งแต่ Cost Center"
      Me.lblCostcenterStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(288, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 4
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(128, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(288, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(256, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(521, 165)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(441, 165)
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
      'chkTool
      '
      Me.chkTool.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkTool.Location = New System.Drawing.Point(15, 45)
      Me.chkTool.Name = "chkTool"
      Me.chkTool.Size = New System.Drawing.Size(128, 16)
      Me.chkTool.TabIndex = 17
      Me.chkTool.Text = "อื่น ๆ"
      '
      'RptPurchaseAnalysisbyCCLciFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptPurchaseAnalysisbyCCLciFilterSubPanel"
      Me.Size = New System.Drawing.Size(628, 212)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbTypeDisplay.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCostcenterStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisbyCCLciFilterSubPanel.lblCostcenterStart}")
      Me.Validator.SetDisplayName(TxtCostcenterCodeStart, lblCostcenterStart.Text)

      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisFilterSubPanel.lblSuppliStart}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisbyCCLciFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

      Me.lblToolend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToolend, lblToolend.Text)

      ' Global {ถึง}
      Me.lblCostcenterEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(TxtCostcenterCodeEnd, lblCostcenterEnd.Text)

      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

      Me.lblToolend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToolend, lblToolend.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisbyCCLciFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisbyCCLciFilterSubPanel.grbDetail}")

      'Check Type
      Me.chkTool.Text = "เครื่องมือ"
    End Sub
#End Region

#Region "Member"
    Private m_ccFrom As CostCenter
    Private m_ccEnd As CostCenter

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_supplierstart As Supplier
    Private m_supplierend As Supplier

    Private m_lcistart As LCIItem
    Private m_lciend As LCIItem
    Private m_toolstart As Tool
    Private m_toolend As Tool
    Dim txtTemp As New TextBox

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
    Public Property CostcenterStart() As CostCenter
      Get
        Return m_ccFrom
      End Get
      Set(ByVal Value As CostCenter)
        m_ccFrom = Value
      End Set
    End Property
    Public Property CostcenterEnd() As CostCenter
      Get
        Return m_ccEnd
      End Get
      Set(ByVal Value As CostCenter)
        m_ccEnd = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property SupplierStart() As Supplier
      Get
        Return m_supplierstart
      End Get
      Set(ByVal Value As Supplier)
        m_supplierstart = Value
      End Set
    End Property
    Public Property SupplierEnd() As Supplier
      Get
        Return m_supplierend
      End Get
      Set(ByVal Value As Supplier)
        m_supplierend = Value
      End Set
    End Property
    Public Property LciStart() As LCIItem
      Get
        Return m_lcistart
      End Get
      Set(ByVal Value As LCIItem)
        m_lcistart = Value
      End Set
    End Property
    Public Property LciEnd() As LCIItem
      Get
        Return m_lciend
      End Get
      Set(ByVal Value As LCIItem)
        m_lciend = Value
      End Set
    End Property
    Public Property ToolStart() As Tool
      Get
        Return m_toolstart
      End Get
      Set(ByVal Value As Tool)
        m_toolstart = Value
      End Set
    End Property
    Public Property ToolEnd() As Tool
      Get
        Return m_toolend
      End Get
      Set(ByVal Value As Tool)
        m_toolend = Value
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
            ElseIf TypeOf Ctrl Is CheckBox Then
              CType(Ctrl, CheckBox).Checked = False
            End If
          Next
        End If
      Next

      Me.txtLciCodeStart.Text = ""
      Me.txtLciCodeEnd.Text = ""

      Me.chkLCI.Checked = True

      Me.CostcenterStart = New CostCenter
      Me.CostcenterEnd = New CostCenter

      Me.SupplierStart = New Supplier
      Me.SupplierEnd = New Supplier

      Me.LciStart = New LCIItem
      Me.LciEnd = New LCIItem
      Me.ToolStart = New Tool
      Me.ToolEnd = New Tool

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
      Dim arr(11) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      'arr(2) = New Filter("CostcenterCodeStart", IIf(TxtCostcenterCodeStart.TextLength > 0, TxtCostcenterCodeStart.Text, DBNull.Value))
      'arr(3) = New Filter("CostcenterCodeEnd", IIf(TxtCostcenterCodeEnd.TextLength > 0, TxtCostcenterCodeEnd.Text, DBNull.Value))
      'arr(4) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      'arr(5) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      'arr(6) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
      'arr(7) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
      'arr(8) = New Filter("ToolCodeStart", IIf(txtToolstart.TextLength > 0, txtToolstart.Text, DBNull.Value))
      'arr(9) = New Filter("ToolCodeEnd", IIf(txtToolend.TextLength > 0, txtToolend.Text, DBNull.Value))
      arr(2) = New Filter("CostcenterCodeStart", Me.ValidCodeOrDBNull(CostcenterStart))
      arr(3) = New Filter("CostcenterCodeEnd", Me.ValidCodeOrDBNull(CostcenterEnd))
      arr(4) = New Filter("SuppliCodeStart", Me.ValidCodeOrDBNull(Me.SupplierStart))
      arr(5) = New Filter("SuppliCodeEnd", Me.ValidCodeOrDBNull(Me.SupplierEnd))
      arr(6) = New Filter("LciCodeStart", Me.ValidCodeOrDBNull(Me.LciStart))
      arr(7) = New Filter("LciCodeEnd", Me.ValidCodeOrDBNull(Me.LciEnd))
      arr(8) = New Filter("ToolCodeStart", Me.ValidCodeOrDBNull(Me.ToolStart))
      arr(9) = New Filter("ToolCodeEnd", Me.ValidCodeOrDBNull(Me.ToolEnd))
      arr(10) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(11) = New Filter("Type", GetChekType())

      Return arr
    End Function
    Private Function GetChekType() As String
      Dim arrListType As New ArrayList

      If Me.chkLCI.Checked Then
        arrListType.Add("42")
      End If
      If Me.chkTool.Checked Then
        arrListType.Add("19")
      End If
      If Me.chkEtc.Checked Then
        arrListType.Add("0")
      End If
      If Me.chkWage.Checked Then
        arrListType.Add("88")
      End If
      If Me.chkMechine.Checked Then
        arrListType.Add("89")
      End If
      If Me.chkAssets.Checked Then
        arrListType.Add("28")
      End If

      'Dim type As String = ""
      'If Me.chkLCI.Checked = False And Me.chkEtc.Checked = False And Me.chkWage.Checked = False And Me.chkMechine.Checked = False And Me.chkAssets.Checked = False Then
      '  type &= "42"
      'Else

      '  If Me.chkLCI.Checked Then
      '    type &= "42"
      '  End If
      '  If Me.chkTool.Checked Then
      '    type &= "19"
      '  End If
      '  If Me.chkEtc.Checked Then
      '    If Len(type) > 0 Then
      '      type &= ","
      '    End If
      '    type &= "0"
      '  End If
      '  If Me.chkWage.Checked Then
      '    If Len(type) > 0 Then
      '      type &= ","
      '    End If
      '    type &= "88"
      '  End If
      '  If Me.chkMechine.Checked Then
      '    If Len(type) > 0 Then
      '      type &= ","
      '    End If
      '    type &= "89"
      '  End If
      '  If Me.chkAssets.Checked Then
      '    If Len(type) > 0 Then
      '      type &= ","
      '    End If
      '    type &= "28"
      '  End If

      'End If
      Return String.Join(",", arrListType.ToArray)
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

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.TxtCostcenterCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterEnd"
      dpi.Value = Me.TxtCostcenterCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier start
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierstart"
      dpi.Value = Me.txtSuppliCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier end
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierend"
      dpi.Value = Me.txtSuppliCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'lci start
      dpi = New DocPrintingItem
      dpi.Mapping = "lcistart"
      dpi.Value = Me.txtLciCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'lci end
      dpi = New DocPrintingItem
      dpi.Mapping = "lciend"
      dpi.Value = Me.txtLciCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ToolCodeStart
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeStart"
      dpi.Value = txtToolstart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ToolCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeEnd"
      dpi.Value = txtToolend.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnCostcenterCodeStartFind.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler btnCostcenterCodeEndFind.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler TxtCostcenterCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler TxtCostcenterCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtLciCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtLciCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtToolstart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToolend.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
      AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click

      AddHandler btnToolstart.Click, AddressOf Me.btnToolFind_Click
      AddHandler btnToolend.Click, AddressOf Me.btnToolFind_Click


    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtLciCodeStart".ToLower
          LCIItem.GetLciitem(txtLciCodeStart, txtTemp, Me.LciStart)
        Case "txtLciCodeEnd".ToLower
          LCIItem.GetLciitem(txtLciCodeEnd, txtTemp, Me.LciEnd)

        Case "txtToolstart".ToLower
          Tool.GetTool(txtToolstart, txtTemp, Me.ToolStart)
        Case "txtToolend".ToLower
          Tool.GetTool(txtToolend, txtTemp, Me.ToolEnd)

        Case "txtsupplicodestart"
          Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
        Case "txtsupplicodeend"
          Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)

        Case "txtcostcentercodestart"
          CostCenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.CostcenterStart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtcostcentercodeend"
          CostCenter.GetCostCenter(TxtCostcenterCodeEnd, txtTemp, Me.CostcenterEnd, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
    Private Sub btnLciFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnlcistartfind"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciStartDialog)

        Case "btnlciendfind"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciEndDialog)

      End Select
    End Sub
    
    Private Sub btnToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btntoolstart"
          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolStartDialog)

        Case "btntoolend"
          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolEndDialog)

      End Select
    End Sub
    Private Sub SetLciStartDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeStart.Text = e.Code

      LCIItem.GetLCIItem(txtLciCodeStart, txtTemp, Me.LciStart)
    End Sub
    Private Sub SetLciEndDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeEnd.Text = e.Code

      LCIItem.GetLCIItem(txtLciCodeEnd, txtTemp, Me.LciEnd)
    End Sub
    Private Sub SetToolStartDialog(ByVal e As ISimpleEntity)
      Me.txtToolstart.Text = e.Code

      Tool.GetTool(txtToolstart, txtTemp, Me.ToolStart)
    End Sub
    Private Sub SetToolEndDialog(ByVal e As ISimpleEntity)
      Me.txtToolend.Text = e.Code

      Tool.GetTool(txtToolend, txtTemp, Me.ToolEnd)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Costcenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcostcentercodestart", "txtcostcentercodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtsupplicodestart", "txtsupplicodeend"
            'Return True
          End Select
        End If
      End If
      If data.GetDataPresent((New LCIItem).FullClassName) Then
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtlcicodestart", "txtlcicodeEnd"
            'Return True
          End Select
        End If
      End If
      ' Costcenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercodestart"
              Me.SetCostcenterStartDialog(entity)

            Case "txtcostcentercodeend"
              Me.SetCostcenterStartDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
       Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeStart.Text = e.Code

      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code

      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncostcentercodestartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterStartDialog)

        Case "btncostcentercodeendfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterEndDialog)

      End Select
    End Sub
    Private Sub SetCostcenterStartDialog(ByVal e As ISimpleEntity)
      Me.TxtCostcenterCodeStart.Text = e.Code

      CostCenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.CostcenterStart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCostcenterEndDialog(ByVal e As ISimpleEntity)
      Me.TxtCostcenterCodeEnd.Text = e.Code

      CostCenter.GetCostCenter(TxtCostcenterCodeEnd, txtTemp, Me.CostcenterEnd, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

    Private Sub grbMaster_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbMaster.Enter

    End Sub
  End Class
End Namespace

