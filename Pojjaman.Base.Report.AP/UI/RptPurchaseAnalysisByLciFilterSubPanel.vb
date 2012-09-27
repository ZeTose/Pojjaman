Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPurchaseAnalysisByLciFilterSubPanel
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
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblLciEnd As System.Windows.Forms.Label
        Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblLciStart As System.Windows.Forms.Label
        Friend WithEvents btnToolend As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToolend As System.Windows.Forms.TextBox
        Friend WithEvents lblToolend As System.Windows.Forms.Label
        Friend WithEvents btnToolstart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToolstart As System.Windows.Forms.TextBox
        Friend WithEvents lblToolStart As System.Windows.Forms.Label
        Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbTypeDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkAssets As System.Windows.Forms.CheckBox
        Friend WithEvents chkEtc As System.Windows.Forms.CheckBox
        Friend WithEvents chkMechine As System.Windows.Forms.CheckBox
        Friend WithEvents chkWage As System.Windows.Forms.CheckBox
        Friend WithEvents chkLCI As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptPurchaseAnalysisByLciFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnToolend = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToolend = New System.Windows.Forms.TextBox()
      Me.lblToolend = New System.Windows.Forms.Label()
      Me.btnToolstart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToolstart = New System.Windows.Forms.TextBox()
      Me.lblToolStart = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtLciCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblLciEnd = New System.Windows.Forms.Label()
      Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtLciCodeStart = New System.Windows.Forms.TextBox()
      Me.lblLciStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbTypeDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAssets = New System.Windows.Forms.CheckBox()
      Me.chkEtc = New System.Windows.Forms.CheckBox()
      Me.chkMechine = New System.Windows.Forms.CheckBox()
      Me.chkWage = New System.Windows.Forms.CheckBox()
      Me.chkLCI = New System.Windows.Forms.CheckBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.grbDisplay.SuspendLayout()
      Me.grbTypeDisplay.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.grbMaster.Controls.Add(Me.grbDisplay)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(728, 224)
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
      Me.txtTemp.Location = New System.Drawing.Point(760, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnToolend)
      Me.grbDetail.Controls.Add(Me.txtToolend)
      Me.grbDetail.Controls.Add(Me.lblToolend)
      Me.grbDetail.Controls.Add(Me.btnToolstart)
      Me.grbDetail.Controls.Add(Me.txtToolstart)
      Me.grbDetail.Controls.Add(Me.lblToolStart)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnLciEndFind)
      Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblLciEnd)
      Me.grbDetail.Controls.Add(Me.btnLciStartFind)
      Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
      Me.grbDetail.Controls.Add(Me.lblLciStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(408, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnToolend
      '
      Me.btnToolend.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolend.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolend.Location = New System.Drawing.Point(368, 64)
      Me.btnToolend.Name = "btnToolend"
      Me.btnToolend.Size = New System.Drawing.Size(24, 22)
      Me.btnToolend.TabIndex = 35
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
      Me.txtToolend.Location = New System.Drawing.Point(272, 64)
      Me.Validator.SetMinValue(Me.txtToolend, "")
      Me.txtToolend.Name = "txtToolend"
      Me.Validator.SetRegularExpression(Me.txtToolend, "")
      Me.Validator.SetRequired(Me.txtToolend, False)
      Me.txtToolend.Size = New System.Drawing.Size(96, 21)
      Me.txtToolend.TabIndex = 34
      '
      'lblToolend
      '
      Me.lblToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolend.ForeColor = System.Drawing.Color.Black
      Me.lblToolend.Location = New System.Drawing.Point(240, 64)
      Me.lblToolend.Name = "lblToolend"
      Me.lblToolend.Size = New System.Drawing.Size(24, 18)
      Me.lblToolend.TabIndex = 33
      Me.lblToolend.Text = "ถึง"
      Me.lblToolend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnToolstart
      '
      Me.btnToolstart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolstart.Location = New System.Drawing.Point(208, 64)
      Me.btnToolstart.Name = "btnToolstart"
      Me.btnToolstart.Size = New System.Drawing.Size(24, 22)
      Me.btnToolstart.TabIndex = 32
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
      Me.txtToolstart.Location = New System.Drawing.Point(112, 64)
      Me.Validator.SetMinValue(Me.txtToolstart, "")
      Me.txtToolstart.Name = "txtToolstart"
      Me.Validator.SetRegularExpression(Me.txtToolstart, "")
      Me.Validator.SetRequired(Me.txtToolstart, False)
      Me.txtToolstart.Size = New System.Drawing.Size(96, 21)
      Me.txtToolstart.TabIndex = 31
      '
      'lblToolStart
      '
      Me.lblToolStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolStart.ForeColor = System.Drawing.Color.Black
      Me.lblToolStart.Location = New System.Drawing.Point(8, 64)
      Me.lblToolStart.Name = "lblToolStart"
      Me.lblToolStart.Size = New System.Drawing.Size(97, 16)
      Me.lblToolStart.TabIndex = 30
      Me.lblToolStart.Text = "ตั้งแต่รหัสเครื่องมือ"
      Me.lblToolStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(112, 112)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 28
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(208, 88)
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 88)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 26
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(32, 88)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 88)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 25
      '
      'btnLciEndFind
      '
      Me.btnLciEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciEndFind.Location = New System.Drawing.Point(368, 40)
      Me.btnLciEndFind.Name = "btnLciEndFind"
      Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciEndFind.TabIndex = 11
      Me.btnLciEndFind.TabStop = False
      Me.btnLciEndFind.ThemedImage = CType(resources.GetObject("btnLciEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLciCodeEnd
      '
      Me.Validator.SetDataType(Me.txtLciCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.txtLciCodeEnd.Location = New System.Drawing.Point(272, 40)
      Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
      Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
      Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeEnd.TabIndex = 10
      '
      'lblLciEnd
      '
      Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
      Me.lblLciEnd.Location = New System.Drawing.Point(240, 40)
      Me.lblLciEnd.Name = "lblLciEnd"
      Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblLciEnd.TabIndex = 9
      Me.lblLciEnd.Text = "ถึง"
      Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLciStartFind
      '
      Me.btnLciStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciStartFind.Location = New System.Drawing.Point(208, 40)
      Me.btnLciStartFind.Name = "btnLciStartFind"
      Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciStartFind.TabIndex = 8
      Me.btnLciStartFind.TabStop = False
      Me.btnLciStartFind.ThemedImage = CType(resources.GetObject("btnLciStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLciCodeStart
      '
      Me.Validator.SetDataType(Me.txtLciCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.txtLciCodeStart.Location = New System.Drawing.Point(112, 40)
      Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Name = "txtLciCodeStart"
      Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
      Me.Validator.SetRequired(Me.txtLciCodeStart, False)
      Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeStart.TabIndex = 7
      '
      'lblLciStart
      '
      Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciStart.ForeColor = System.Drawing.Color.Black
      Me.lblLciStart.Location = New System.Drawing.Point(16, 40)
      Me.lblLciStart.Name = "lblLciStart"
      Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
      Me.lblLciStart.TabIndex = 6
      Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
      Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(272, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(85, 21)
      Me.txtDocDateEnd.TabIndex = 4
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(88, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(272, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(648, 184)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(568, 184)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'grbDisplay
      '
      Me.grbDisplay.Controls.Add(Me.grbTypeDisplay)
      Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDisplay.Location = New System.Drawing.Point(416, 16)
      Me.grbDisplay.Name = "grbDisplay"
      Me.grbDisplay.Size = New System.Drawing.Size(304, 160)
      Me.grbDisplay.TabIndex = 38
      Me.grbDisplay.TabStop = False
      Me.grbDisplay.Text = "รูปแบบการแสดงผล"
      '
      'grbTypeDisplay
      '
      Me.grbTypeDisplay.Controls.Add(Me.chkAssets)
      Me.grbTypeDisplay.Controls.Add(Me.chkEtc)
      Me.grbTypeDisplay.Controls.Add(Me.chkMechine)
      Me.grbTypeDisplay.Controls.Add(Me.chkWage)
      Me.grbTypeDisplay.Controls.Add(Me.chkLCI)
      Me.grbTypeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTypeDisplay.Location = New System.Drawing.Point(24, 16)
      Me.grbTypeDisplay.Name = "grbTypeDisplay"
      Me.grbTypeDisplay.Size = New System.Drawing.Size(240, 120)
      Me.grbTypeDisplay.TabIndex = 7
      Me.grbTypeDisplay.TabStop = False
      Me.grbTypeDisplay.Text = "การแสดงผลตามประเภท"
      '
      'chkAssets
      '
      Me.chkAssets.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAssets.Location = New System.Drawing.Point(64, 91)
      Me.chkAssets.Name = "chkAssets"
      Me.chkAssets.Size = New System.Drawing.Size(88, 16)
      Me.chkAssets.TabIndex = 16
      Me.chkAssets.Text = "สินทรัพย์"
      '
      'chkEtc
      '
      Me.chkEtc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEtc.Location = New System.Drawing.Point(64, 43)
      Me.chkEtc.Name = "chkEtc"
      Me.chkEtc.Size = New System.Drawing.Size(128, 16)
      Me.chkEtc.TabIndex = 17
      Me.chkEtc.Text = "อื่น ๆ"
      '
      'chkMechine
      '
      Me.chkMechine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkMechine.Location = New System.Drawing.Point(64, 75)
      Me.chkMechine.Name = "chkMechine"
      Me.chkMechine.Size = New System.Drawing.Size(96, 16)
      Me.chkMechine.TabIndex = 15
      Me.chkMechine.Text = "ค่าเช่าเครื่องจักร "
      '
      'chkWage
      '
      Me.chkWage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkWage.Location = New System.Drawing.Point(64, 59)
      Me.chkWage.Name = "chkWage"
      Me.chkWage.Size = New System.Drawing.Size(128, 16)
      Me.chkWage.TabIndex = 14
      Me.chkWage.Text = "ค่าแรง"
      '
      'chkLCI
      '
      Me.chkLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkLCI.Location = New System.Drawing.Point(64, 27)
      Me.chkLCI.Name = "chkLCI"
      Me.chkLCI.Size = New System.Drawing.Size(128, 16)
      Me.chkLCI.TabIndex = 13
      Me.chkLCI.Text = "วัสดุ"
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
      'RptPurchaseAnalysisByLciFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptPurchaseAnalysisByLciFilterSubPanel"
      Me.Size = New System.Drawing.Size(744, 240)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbDisplay.ResumeLayout(False)
      Me.grbTypeDisplay.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.lblLciStart}")
            Me.Validator.SetDisplayName(txtLciCodeStart, lblLciStart.Text)

            Me.lblToolStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.lblToolStart}")
            Me.Validator.SetDisplayName(txtToolstart, lblToolStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Global {ถึง}
            Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

            Me.lblToolend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtToolend, lblToolend.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.grbDetail}")

            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkIncludeChildren}")

            'Me.lblFillterType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.lblFillterType}")


            Me.grbTypeDisplay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.grbTypeDisplay}") 'การแสดงผลตามประเภท
            Me.chkLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkLCI}") 'วัสดุ
            Me.chkEtc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkEtc}") 'อื่น ๆ
            Me.chkWage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkWage}") 'ค่าแรง
            Me.chkMechine.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkMechine}") 'ค่าเช่าเครื่องจักร 
            Me.chkAssets.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseAnalysisByLciFilterSubPanel.chkAssets}") 'สินทรัพย์
            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")

        End Sub
#End Region

#Region "Member"
        Private m_lcistart As LCIItem
        Private m_lciend As LCIItem
        Private m_toolstart As Tool
        Private m_toolend As Tool

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_cc As Costcenter
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
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            ' RegisterDropdown()
            ClearCriterias()
        End Sub

        'Private Sub RegisterDropdown()
        '    ' ประเภทการจ่าย
        '    cmbFillTerType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByLci.cmbFillTerTypeLci&ToolCode}"))
        '    cmbFillTerType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByLci.cmbFillTerTypeLciCode}"))
        '    cmbFillTerType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByLci.cmbFillTerTypeToolCode}"))
        '    cmbFillTerType.SelectedIndex = 0
        'End Sub

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
            Dim arr(9) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("ToolCodeStart", IIf(txtToolstart.TextLength > 0, txtToolstart.Text, DBNull.Value))
            arr(5) = New Filter("ToolCodeEnd", IIf(txtToolend.TextLength > 0, txtToolend.Text, DBNull.Value))
            arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            'arr(8) = New Filter("PreviewType", cmbFillTerType.SelectedIndex)
            arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(9) = New Filter("Type", GetChekType())
            Return arr
        End Function
        Private Function GetChekType() As String
            Dim type As String = ""
            If Me.chkLCI.Checked = False And Me.chkEtc.Checked = False And Me.chkWage.Checked = False And Me.chkMechine.Checked = False And Me.chkAssets.Checked = False Then
                type &= "42"
            Else

                If Me.chkLCI.Checked Then
                    type &= "42"
                End If
                If Me.chkEtc.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "0"
                End If

                If Me.chkWage.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "88"
                End If
                If Me.chkMechine.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "89"
                End If
                If Me.chkAssets.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "28"
                End If
            End If
            Return type
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
            dpi.Value = "" 'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docdate start
            dpi = New DocPrintingItem
            dpi.Mapping = "docdatestart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docdate end
            dpi = New DocPrintingItem
            dpi.Mapping = "docdateend"
            dpi.Value = Me.txtDocDateEnd.Text
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

            'CheckBox LCI
            If Me.chkLCI.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "chkLCI"
                dpi.Value = "(แสดงประเภทวัสดุ)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Etc
            If Me.chkEtc.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "chkEtc"
                dpi.Value = "(แสดงประเภทอื่นๆ)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Wage
            If Me.chkWage.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "chkWage"
                dpi.Value = "(แสดงประเภทค่าแรง)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Mechine
            If Me.chkMechine.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "chkMechine"
                dpi.Value = "(แสดงประเภทค่าเชาเครื่องจักร)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Assets
            If Me.chkAssets.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "chkAssets"
                dpi.Value = "(แสดงประเภทค่าเชาเครื่องจักร)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
            AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click

            AddHandler btnToolstart.Click, AddressOf Me.btnToolFind_Click
            AddHandler btnToolend.Click, AddressOf Me.btnToolFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
                If data.GetDataPresent((New LCIItem).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtlcicodestart", "txtlcicodeEnd"
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
            If data.GetDataPresent((New LCIItem).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
                Dim entity As New LCIItem(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtlcicodestart"
                            Me.SetLciStartDialog(entity)

                        Case "txtlcicodeEnd"
                            Me.SetLciEndDialog(entity)

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
        Private Sub btnLciFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnlcistartfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciStartDialog)

                Case "btnlciendfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciEndDialog)

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
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

    End Class
End Namespace

