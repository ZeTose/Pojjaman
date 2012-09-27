Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptCCPRSummaryFilterSubPanel
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
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents btnCostcenterCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents TxtCostcenterCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblCostcenterEnd As System.Windows.Forms.Label
        Friend WithEvents btnCostcenterCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents TxtCostcenterCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCostcenterStart As System.Windows.Forms.Label
        Friend WithEvents btnEmpEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmpCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblEmpEnd As System.Windows.Forms.Label
        Friend WithEvents btnEmpStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmpCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblEmpStart As System.Windows.Forms.Label
    Friend WithEvents cmbDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblLciEnd As System.Windows.Forms.Label
    Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblLciStart As System.Windows.Forms.Label
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptCCPRSummaryFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnCostcenterCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.TxtCostcenterCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblCostcenterEnd = New System.Windows.Forms.Label()
      Me.btnCostcenterCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.TxtCostcenterCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCostcenterStart = New System.Windows.Forms.Label()
      Me.btnEmpEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEmpCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblEmpEnd = New System.Windows.Forms.Label()
      Me.btnEmpStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEmpCodeStart = New System.Windows.Forms.TextBox()
      Me.lblEmpStart = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbDocStatus = New System.Windows.Forms.ComboBox()
      Me.lblDocStatus = New System.Windows.Forms.Label()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtLciCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblLciEnd = New System.Windows.Forms.Label()
      Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtLciCodeStart = New System.Windows.Forms.TextBox()
      Me.lblLciStart = New System.Windows.Forms.Label()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.grbDisplay.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.grbMaster.Controls.Add(Me.grbDisplay)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 0)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(718, 152)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnLciEndFind)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblLciEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.btnLciStartFind)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblLciStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeEndFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCostcenterEnd)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeStartFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCostcenterStart)
      Me.grbDetail.Controls.Add(Me.btnEmpEndFind)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblEmpEnd)
      Me.grbDetail.Controls.Add(Me.btnEmpStartFind)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeStart)
      Me.grbDetail.Controls.Add(Me.lblEmpStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(429, 120)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(293, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(86, 21)
      Me.txtDocDateEnd.TabIndex = 47
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(133, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(87, 21)
      Me.txtDocDateStart.TabIndex = 44
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(133, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 45
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(293, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 48
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(53, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateStart.TabIndex = 43
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(261, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 46
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCostcenterCodeEndFind
      '
      Me.btnCostcenterCodeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeEndFind.Location = New System.Drawing.Point(389, 64)
      Me.btnCostcenterCodeEndFind.Name = "btnCostcenterCodeEndFind"
      Me.btnCostcenterCodeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeEndFind.TabIndex = 41
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
      Me.TxtCostcenterCodeEnd.Location = New System.Drawing.Point(293, 64)
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeEnd, "")
      Me.TxtCostcenterCodeEnd.Name = "TxtCostcenterCodeEnd"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeEnd, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeEnd, False)
      Me.TxtCostcenterCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeEnd.TabIndex = 28
      '
      'lblCostcenterEnd
      '
      Me.lblCostcenterEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterEnd.Location = New System.Drawing.Point(261, 64)
      Me.lblCostcenterEnd.Name = "lblCostcenterEnd"
      Me.lblCostcenterEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCostcenterEnd.TabIndex = 38
      Me.lblCostcenterEnd.Text = "ถึง"
      Me.lblCostcenterEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCostcenterCodeStartFind
      '
      Me.btnCostcenterCodeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeStartFind.Location = New System.Drawing.Point(229, 64)
      Me.btnCostcenterCodeStartFind.Name = "btnCostcenterCodeStartFind"
      Me.btnCostcenterCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeStartFind.TabIndex = 35
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
      Me.TxtCostcenterCodeStart.Location = New System.Drawing.Point(133, 64)
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Name = "TxtCostcenterCodeStart"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeStart, False)
      Me.TxtCostcenterCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeStart.TabIndex = 27
      '
      'lblCostcenterStart
      '
      Me.lblCostcenterStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterStart.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterStart.Location = New System.Drawing.Point(13, 64)
      Me.lblCostcenterStart.Name = "lblCostcenterStart"
      Me.lblCostcenterStart.Size = New System.Drawing.Size(112, 18)
      Me.lblCostcenterStart.TabIndex = 32
      Me.lblCostcenterStart.Text = "ตั้งแต่ Cost Center"
      Me.lblCostcenterStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnEmpEndFind
      '
      Me.btnEmpEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnEmpEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpEndFind.Location = New System.Drawing.Point(389, 40)
      Me.btnEmpEndFind.Name = "btnEmpEndFind"
      Me.btnEmpEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpEndFind.TabIndex = 40
      Me.btnEmpEndFind.TabStop = False
      Me.btnEmpEndFind.ThemedImage = CType(resources.GetObject("btnEmpEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmpCodeEnd
      '
      Me.Validator.SetDataType(Me.txtEmpCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.txtEmpCodeEnd.Location = New System.Drawing.Point(293, 40)
      Me.Validator.SetMinValue(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Name = "txtEmpCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeEnd, "")
      Me.Validator.SetRequired(Me.txtEmpCodeEnd, False)
      Me.txtEmpCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeEnd.TabIndex = 26
      '
      'lblEmpEnd
      '
      Me.lblEmpEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmpEnd.ForeColor = System.Drawing.Color.Black
      Me.lblEmpEnd.Location = New System.Drawing.Point(261, 40)
      Me.lblEmpEnd.Name = "lblEmpEnd"
      Me.lblEmpEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblEmpEnd.TabIndex = 37
      Me.lblEmpEnd.Text = "ถึง"
      Me.lblEmpEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnEmpStartFind
      '
      Me.btnEmpStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnEmpStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpStartFind.Location = New System.Drawing.Point(229, 40)
      Me.btnEmpStartFind.Name = "btnEmpStartFind"
      Me.btnEmpStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpStartFind.TabIndex = 34
      Me.btnEmpStartFind.TabStop = False
      Me.btnEmpStartFind.ThemedImage = CType(resources.GetObject("btnEmpStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmpCodeStart
      '
      Me.Validator.SetDataType(Me.txtEmpCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.txtEmpCodeStart.Location = New System.Drawing.Point(133, 40)
      Me.Validator.SetMinValue(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Name = "txtEmpCodeStart"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeStart, "")
      Me.Validator.SetRequired(Me.txtEmpCodeStart, False)
      Me.txtEmpCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeStart.TabIndex = 25
      '
      'lblEmpStart
      '
      Me.lblEmpStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmpStart.ForeColor = System.Drawing.Color.Black
      Me.lblEmpStart.Location = New System.Drawing.Point(13, 40)
      Me.lblEmpStart.Name = "lblEmpStart"
      Me.lblEmpStart.Size = New System.Drawing.Size(112, 18)
      Me.lblEmpStart.TabIndex = 31
      Me.lblEmpStart.Text = "Empployees:"
      Me.lblEmpStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(632, 113)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(552, 113)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 2
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'grbDisplay
      '
      Me.grbDisplay.Controls.Add(Me.cmbDocStatus)
      Me.grbDisplay.Controls.Add(Me.lblDocStatus)
      Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDisplay.Location = New System.Drawing.Point(451, 16)
      Me.grbDisplay.Name = "grbDisplay"
      Me.grbDisplay.Size = New System.Drawing.Size(256, 80)
      Me.grbDisplay.TabIndex = 1
      Me.grbDisplay.TabStop = False
      Me.grbDisplay.Text = "รูปแบบการแสดงผล"
      '
      'cmbDocStatus
      '
      Me.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocStatus.Location = New System.Drawing.Point(72, 34)
      Me.cmbDocStatus.Name = "cmbDocStatus"
      Me.cmbDocStatus.Size = New System.Drawing.Size(168, 21)
      Me.cmbDocStatus.TabIndex = 1
      '
      'lblDocStatus
      '
      Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
      Me.lblDocStatus.Location = New System.Drawing.Point(8, 34)
      Me.lblDocStatus.Name = "lblDocStatus"
      Me.lblDocStatus.Size = New System.Drawing.Size(56, 18)
      Me.lblDocStatus.TabIndex = 0
      Me.lblDocStatus.Text = "สถานะ"
      Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(528, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 4
      Me.txtTemp.Visible = False
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
      'btnLciEndFind
      '
      Me.btnLciEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciEndFind.Location = New System.Drawing.Point(389, 88)
      Me.btnLciEndFind.Name = "btnLciEndFind"
      Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciEndFind.TabIndex = 17
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
      Me.txtLciCodeEnd.Location = New System.Drawing.Point(293, 88)
      Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
      Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
      Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeEnd.TabIndex = 16
      '
      'lblLciEnd
      '
      Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
      Me.lblLciEnd.Location = New System.Drawing.Point(261, 88)
      Me.lblLciEnd.Name = "lblLciEnd"
      Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblLciEnd.TabIndex = 15
      Me.lblLciEnd.Text = "ถึง"
      Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLciStartFind
      '
      Me.btnLciStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciStartFind.Location = New System.Drawing.Point(229, 88)
      Me.btnLciStartFind.Name = "btnLciStartFind"
      Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciStartFind.TabIndex = 14
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
      Me.txtLciCodeStart.Location = New System.Drawing.Point(133, 88)
      Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Name = "txtLciCodeStart"
      Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
      Me.Validator.SetRequired(Me.txtLciCodeStart, False)
      Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeStart.TabIndex = 13
      '
      'lblLciStart
      '
      Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciStart.ForeColor = System.Drawing.Color.Black
      Me.lblLciStart.Location = New System.Drawing.Point(37, 88)
      Me.lblLciStart.Name = "lblLciStart"
      Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
      Me.lblLciStart.TabIndex = 12
      Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
      Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptCCPRSummaryFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptCCPRSummaryFilterSubPanel"
      Me.Size = New System.Drawing.Size(734, 168)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbDisplay.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region


#Region " SetLabelText "
        Public Sub SetLabelText()
            'PR************
            'ตั้งแต่
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)
            'ถึง
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            'PR************

            'Employee******
            Me.lblEmpStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.lblEmpStart}")
            Me.Validator.SetDisplayName(txtEmpCodeStart, lblEmpStart.Text)
            'ถึง
            Me.lblEmpEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtEmpCodeEnd, lblEmpEnd.Text)
            'Employee******

            'Coscenter
            Me.lblCostcenterStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(TxtCostcenterCodeStart, lblCostcenterStart.Text)
            'ถึง
            Me.lblCostcenterEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(TxtCostcenterCodeEnd, lblCostcenterEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' ค้นหา
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.grbMaster}")
            ' ข้อมูลทั่วไป
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.grbDetail}")
            'สถานะ
            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.lblDocStatus}")
            'ComboBox
            Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.cmbDocAll}")) 'เอกสารขอซื้อทั้งหมด
            Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.cmbDocApprove}")) 'เอกสารขอซื้อที่อนุมัติแล้ว
            Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPRSummaryFilterSubPanel.cmbDocNoApprove}")) 'เอกสารขอซื้อที่ยังไม่อนุมัติ
            Me.cmbDocStatus.SelectedIndex = 0

      Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.lblLciStart}")
            Me.Validator.SetDisplayName(txtLciCodeStart, lblLciStart.Text)

            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")
        End Sub
#End Region

#Region "Member"
        Private m_cc As CostCenter
        Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_lcistart As LCIItem
    Private m_lciend As LCIItem
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
        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set    End Property
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

      Me.Costcenter = New CostCenter

      Me.LciStart = New LCIItem
      Me.LciEnd = New LCIItem

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
            arr(2) = New Filter("EmployeeCodeStart", IIf(txtEmpCodeStart.TextLength > 0, txtEmpCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("EmployeeCodeEnd", IIf(txtEmpCodeEnd.TextLength > 0, txtEmpCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("CostcenterStart", IIf(TxtCostcenterCodeStart.TextLength > 0, TxtCostcenterCodeStart.Text, DBNull.Value))
            arr(5) = New Filter("CostcenterEnd", IIf(TxtCostcenterCodeEnd.TextLength > 0, TxtCostcenterCodeEnd.Text, DBNull.Value))
            arr(6) = New Filter("DocStatus", Me.cmbDocStatus.SelectedIndex)
      arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(8) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
      arr(9) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
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

            'EmpSatrt
            dpi = New DocPrintingItem
            dpi.Mapping = "EmpSatrt"
            dpi.Value = Me.txtEmpCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'EmpEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "EmpEnd"
            dpi.Value = Me.txtEmpCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CCStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CCStart"
            dpi.Value = Me.TxtCostcenterCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CCEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "CCEnd"
            dpi.Value = Me.TxtCostcenterCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'DocStatus
            dpi = New DocPrintingItem
            dpi.Mapping = "DocStatus"
            dpi.Value = Me.cmbDocStatus.Text
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

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnEmpStartFind.Click, AddressOf Me.btnEmpFind_Click
            AddHandler btnEmpEndFind.Click, AddressOf Me.btnEmpFind_Click

            AddHandler btnCostcenterCodeStartFind.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler btnCostcenterCodeEndFind.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
      AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click
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

                Case Else

            End Select
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
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
        End If
        'Lci
        If data.GetDataPresent((New LCIItem).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtlcicodestart", "txtlcicodeEnd"
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
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
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

    ' Employee
    Private Sub btnEmpFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnempstartfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeStartDialog)

        Case "btnempendfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeEndDialog)
      End Select
    End Sub
    ' Cost Center
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncostcentercodestartfind"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

        Case "btncostcentercodeendfind"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
      End Select
    End Sub
    Private Sub SetEmployeeStartDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeStart.Text = e.Code
    End Sub
    Private Sub SetEmployeeEndDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeEnd.Text = e.Code
    End Sub

    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.TxtCostcenterCodeStart.Text = e.Code
    End Sub
    Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
      Me.TxtCostcenterCodeEnd.Text = e.Code
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
    Private Sub SetLciStartDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeStart.Text = e.Code
      LCIItem.GetLCIItem(txtLciCodeStart, txtTemp, Me.LciStart)
    End Sub
    Private Sub SetLciEndDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeEnd.Text = e.Code
      LCIItem.GetLCIItem(txtLciCodeEnd, txtTemp, Me.LciEnd)
    End Sub
#End Region

  End Class
End Namespace

