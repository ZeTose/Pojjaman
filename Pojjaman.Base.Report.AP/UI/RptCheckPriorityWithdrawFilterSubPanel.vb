Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptCheckPriorityWithdrawFilterSubPanel
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
        Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
        Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
        Friend WithEvents lblRequestor As System.Windows.Forms.Label
        Friend WithEvents btnRequestorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptCheckPriorityWithdrawFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtLciCodeEnd = New System.Windows.Forms.TextBox
            Me.lblLciEnd = New System.Windows.Forms.Label
            Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtLciCodeStart = New System.Windows.Forms.TextBox
            Me.lblLciStart = New System.Windows.Forms.Label
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtRequestorCode = New System.Windows.Forms.TextBox
            Me.txtRequestorName = New System.Windows.Forms.TextBox
            Me.lblRequestor = New System.Windows.Forms.Label
            Me.btnRequestorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
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
            Me.grbMaster.Size = New System.Drawing.Size(480, 176)
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
            Me.txtTemp.Location = New System.Drawing.Point(512, 32)
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
            Me.grbDetail.Controls.Add(Me.txtRequestorCode)
            Me.grbDetail.Controls.Add(Me.txtRequestorName)
            Me.grbDetail.Controls.Add(Me.lblRequestor)
            Me.grbDetail.Controls.Add(Me.btnRequestorDialog)
            Me.grbDetail.Controls.Add(Me.btnLciEndFind)
            Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblLciEnd)
            Me.grbDetail.Controls.Add(Me.btnLciStartFind)
            Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
            Me.grbDetail.Controls.Add(Me.lblLciStart)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(448, 120)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnLciEndFind
            '
            Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciEndFind.Image = CType(resources.GetObject("btnLciEndFind.Image"), System.Drawing.Image)
            Me.btnLciEndFind.Location = New System.Drawing.Point(392, 40)
            Me.btnLciEndFind.Name = "btnLciEndFind"
            Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciEndFind.TabIndex = 29
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
            Me.txtLciCodeEnd.Location = New System.Drawing.Point(296, 40)
            Me.Validator.SetMaxValue(Me.txtLciCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
            Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
            Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
            Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtLciCodeEnd.TabIndex = 28
            Me.txtLciCodeEnd.Text = ""
            '
            'lblLciEnd
            '
            Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
            Me.lblLciEnd.Location = New System.Drawing.Point(264, 40)
            Me.lblLciEnd.Name = "lblLciEnd"
            Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblLciEnd.TabIndex = 27
            Me.lblLciEnd.Text = "ถึง"
            Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnLciStartFind
            '
            Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciStartFind.Image = CType(resources.GetObject("btnLciStartFind.Image"), System.Drawing.Image)
            Me.btnLciStartFind.Location = New System.Drawing.Point(232, 40)
            Me.btnLciStartFind.Name = "btnLciStartFind"
            Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciStartFind.TabIndex = 26
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
            Me.txtLciCodeStart.Location = New System.Drawing.Point(136, 40)
            Me.Validator.SetMaxValue(Me.txtLciCodeStart, "")
            Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
            Me.txtLciCodeStart.Name = "txtLciCodeStart"
            Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
            Me.Validator.SetRequired(Me.txtLciCodeStart, False)
            Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtLciCodeStart.TabIndex = 25
            Me.txtLciCodeStart.Text = ""
            '
            'lblLciStart
            '
            Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciStart.ForeColor = System.Drawing.Color.Black
            Me.lblLciStart.Location = New System.Drawing.Point(40, 40)
            Me.lblLciStart.Name = "lblLciStart"
            Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
            Me.lblLciStart.TabIndex = 24
            Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
            Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(232, 64)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 22
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(136, 64)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 11
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(16, 64)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(112, 18)
            Me.lblCCStart.TabIndex = 14
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(256, 64)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 15
            Me.txtCostCenterName.Text = ""
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 4
            Me.txtDocDateEnd.Text = ""
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(136, 16)
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(136, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 16)
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
            Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(264, 16)
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
            Me.btnSearch.Location = New System.Drawing.Point(388, 144)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(308, 144)
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
            'txtRequestorCode
            '
            Me.Validator.SetDataType(Me.txtRequestorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.txtRequestorCode.Location = New System.Drawing.Point(136, 88)
            Me.Validator.SetMaxValue(Me.txtRequestorCode, "")
            Me.Validator.SetMinValue(Me.txtRequestorCode, "")
            Me.txtRequestorCode.Name = "txtRequestorCode"
            Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
            Me.Validator.SetRequired(Me.txtRequestorCode, False)
            Me.txtRequestorCode.Size = New System.Drawing.Size(96, 21)
            Me.txtRequestorCode.TabIndex = 30
            Me.txtRequestorCode.Text = ""
            '
            'txtRequestorName
            '
            Me.Validator.SetDataType(Me.txtRequestorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.txtRequestorName.Location = New System.Drawing.Point(256, 88)
            Me.Validator.SetMaxValue(Me.txtRequestorName, "")
            Me.Validator.SetMinValue(Me.txtRequestorName, "")
            Me.txtRequestorName.Name = "txtRequestorName"
            Me.txtRequestorName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
            Me.Validator.SetRequired(Me.txtRequestorName, False)
            Me.txtRequestorName.Size = New System.Drawing.Size(160, 21)
            Me.txtRequestorName.TabIndex = 32
            Me.txtRequestorName.TabStop = False
            Me.txtRequestorName.Text = ""
            '
            'lblRequestor
            '
            Me.lblRequestor.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRequestor.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRequestor.Location = New System.Drawing.Point(32, 88)
            Me.lblRequestor.Name = "lblRequestor"
            Me.lblRequestor.Size = New System.Drawing.Size(96, 18)
            Me.lblRequestor.TabIndex = 31
            Me.lblRequestor.Text = "ผู้ขอ:"
            Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRequestorDialog
            '
            Me.btnRequestorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRequestorDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRequestorDialog.Image = CType(resources.GetObject("btnRequestorDialog.Image"), System.Drawing.Image)
            Me.btnRequestorDialog.Location = New System.Drawing.Point(232, 88)
            Me.btnRequestorDialog.Name = "btnRequestorDialog"
            Me.btnRequestorDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnRequestorDialog.TabIndex = 33
            Me.btnRequestorDialog.TabStop = False
            Me.btnRequestorDialog.ThemedImage = CType(resources.GetObject("btnRequestorDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'RptCheckPriorityWithdraw
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptCheckPriorityWithdrawFilterSubPanel"
            Me.Size = New System.Drawing.Size(496, 184)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCashPurchaseFilterSubPanel.lblCCStart}") 'CostCenter
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCheckPriorityWithdrawFilterSubPanel.lblDocDateStart}") 'ตั้งแต่วันที่
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCheckPriorityWithdrawFilterSubPanel.lblLciStart}") 'ตั้งแต่รหัสวัสดุ
            Me.Validator.SetDisplayName(txtLciCodeStart, lblLciStart.Text)

            Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

            Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCheckPriorityWithdrawFilterSubPanel.lblRequestor}") 'ผู้ขอซื้อ
            Me.Validator.SetDisplayName(txtRequestorCode, lblRequestor.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.grbDetail}")


        End Sub
#End Region

#Region "Member"
        Private m_cc As CostCenter
        'Private m_supplier As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        'Private m_DueDateEnd As Date
        'Private m_DueDateStart As Date
        'Private m_suppliergroup As SupplierGroup
        Private m_requestor As Employee
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

        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        'Public Property DueDateEnd() As Date        '    Get        '        Return m_DocDateEnd        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateEnd = Value        '    End Set        'End Property        'Public Property DueDateStart() As Date        '    Get        '        Return m_DocDateStart        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateStart = Value        '    End Set        'End Property
        Public Property Requestor() As Employee            Get                Return m_requestor            End Get            Set(ByVal Value As Employee)                m_requestor = Value            End Set        End Property
        Public Property LCIStart() As LCIItem
            Get
                Return m_lcistart
            End Get
            Set(ByVal Value As LCIItem)
                m_lcistart = Value
            End Set
        End Property
        Public Property LCIEnd() As LCIItem
            Get
                Return m_lciend
            End Get
            Set(ByVal Value As LCIItem)
                m_lciend = Value
            End Set
        End Property

#End Region

#Region "Methods"
        'Private Sub RegisterDropdown()
        '  CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "goodsreceipt_status", True)
        '  cmbDocStatus.SelectedIndex = 0
        'End Sub
        Private Sub Initialize()
            'RegisterDropdown()
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

            Me.txtRequestorCode.Text = ""
            Me.txtRequestorName.Text = ""
            Me.m_requestor = New Employee

            Me.LCIStart = New LCIItem
            Me.LCIEnd = New LCIItem

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(6) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(3) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
            arr(4) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
            arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(6) = New Filter("requestor", IIf(Me.m_requestor.Valid, Me.m_requestor.Id, DBNull.Value))
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

            'LciCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeStart"
            dpi.Value = Me.txtLciCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'LciCodeEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeEnd"
            dpi.Value = Me.txtLciCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterCode"
            dpi.Value = Me.txtCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterInfo"
            dpi.Value = Me.txtCCCodeStart.Text & " : " & Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'RequestorCode
            dpi = New DocPrintingItem
            dpi.Mapping = "RequestorCode"
            dpi.Value = Me.txtRequestorCode.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'RequestorName
            dpi = New DocPrintingItem
            dpi.Mapping = "RequestorName"
            dpi.Value = Me.txtRequestorName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnLciStartFind.Click, AddressOf Me.btnLCIFind_Click
            'AddHandler txtLciCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnLciEndFind.Click, AddressOf Me.btnLCIFind_Click
            'AddHandler txtLciCodeEnd.Validated, AddressOf Me.ChangeProperty

            'AddHandler btnRequestorDialog.Click, AddressOf Me.
            'AddHandler txtRequestorCode.Validated, AddressOf Me.ChangeProperty


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
        'Public Overrides ReadOnly Property EnablePaste() As Boolean
        '    Get
        '        Dim data As IDataObject = Clipboard.GetDataObject
        '        ' Costcenter
        '        If data.GetDataPresent((New CostCenter).FullClassName) Then
        '            If Not Me.ActiveControl Is Nothing Then
        '                Select Case Me.ActiveControl.Name.ToLower
        '                    Case "txtcccodestart", "txtcccodeend"
        '                        Return True
        '                End Select
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim data As IDataObject = Clipboard.GetDataObject
        '    ' Supplier

        '    ' Costcenter
        '    If data.GetDataPresent((New CostCenter).FullClassName) Then
        '        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        '        Dim entity As New CostCenter(id)
        '        If Not Me.ActiveControl Is Nothing Then
        '            Select Case Me.ActiveControl.Name.ToLower
        '                Case "txtcostcentercodestart"
        '                    Me.SetCCCodeStartDialog(entity)

        '                Case "txtcostcentercodeend"
        '                    Me.SetCCCodeStartDialog(entity)

        '            End Select
        '        End If
        '    End If
        'End Sub
#End Region

#Region " Event Handlers "
        '' Supplier
        'Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '    End Select
        'End Sub

        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnLCIFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnlcistartfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIStartDialog)

                Case "btnlciendfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIEndDialog)

            End Select
        End Sub
        Private Sub SetLCIStartDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeStart.Text = e.Code
            LCIItem.GetLCIItem(txtLciCodeStart, txtTemp, Me.LCIStart)
        End Sub
        Private Sub SetLCIEndDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeEnd.Text = e.Code
            LCIItem.GetLCIItem(txtLciCodeEnd, txtTemp, Me.LCIStart)
        End Sub

        Private Sub btnRequestorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRequestor)
        End Sub
        Private Sub SetRequestor(ByVal e As ISimpleEntity)
            Me.txtRequestorCode.Text = e.Code
            Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
        End Sub
        Private Sub txtRequestorCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequestorCode.Validated
            Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
        End Sub

#End Region

    End Class
End Namespace

