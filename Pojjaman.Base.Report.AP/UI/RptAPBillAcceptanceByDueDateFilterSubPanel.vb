Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAPBillAcceptanceByDueDateFilterSubPanel
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
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents lblBillDocEnd As System.Windows.Forms.Label
    Friend WithEvents lblBillDocStart As System.Windows.Forms.Label
    Friend WithEvents btnBillEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBillEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnBillStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ChkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtBillStart As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAPBillAcceptanceByDueDateFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnBillEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtBillEnd = New System.Windows.Forms.TextBox()
            Me.lblBillDocEnd = New System.Windows.Forms.Label()
            Me.btnBillStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtBillStart = New System.Windows.Forms.TextBox()
            Me.lblBillDocStart = New System.Windows.Forms.Label()
            Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
            Me.lblSupplierGroup = New System.Windows.Forms.Label()
            Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox()
            Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtDueDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDueDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDueDateStart = New System.Windows.Forms.Label()
            Me.lblDueDateEnd = New System.Windows.Forms.Label()
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblSuppliEnd = New System.Windows.Forms.Label()
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
            Me.lblSuppliStart = New System.Windows.Forms.Label()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.ChkShowAll = New System.Windows.Forms.CheckBox()
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
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(805, 224)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(724, 192)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(64, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(654, 192)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(64, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(832, 32)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
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
            Me.grbDetail.Controls.Add(Me.ChkShowAll)
            Me.grbDetail.Controls.Add(Me.btnBillEndFind)
            Me.grbDetail.Controls.Add(Me.txtBillEnd)
            Me.grbDetail.Controls.Add(Me.lblBillDocEnd)
            Me.grbDetail.Controls.Add(Me.btnBillStartFind)
            Me.grbDetail.Controls.Add(Me.txtBillStart)
            Me.grbDetail.Controls.Add(Me.lblBillDocStart)
            Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
            Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
            Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
            Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtDueDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDueDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDueDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDueDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDueDateStart)
            Me.grbDetail.Controls.Add(Me.lblDueDateEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(787, 170)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnBillEndFind
            '
            Me.btnBillEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnBillEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBillEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBillEndFind.Location = New System.Drawing.Point(376, 40)
            Me.btnBillEndFind.Name = "btnBillEndFind"
            Me.btnBillEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnBillEndFind.TabIndex = 20
            Me.btnBillEndFind.TabStop = False
            Me.btnBillEndFind.ThemedImage = CType(resources.GetObject("btnBillEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBillEnd
            '
            Me.Validator.SetDataType(Me.txtBillEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillEnd, "")
            Me.txtBillEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillEnd, System.Drawing.Color.Empty)
            Me.txtBillEnd.Location = New System.Drawing.Point(280, 40)
            Me.Validator.SetMaxValue(Me.txtBillEnd, "")
            Me.Validator.SetMinValue(Me.txtBillEnd, "")
            Me.txtBillEnd.Name = "txtBillEnd"
            Me.Validator.SetRegularExpression(Me.txtBillEnd, "")
            Me.Validator.SetRequired(Me.txtBillEnd, False)
            Me.txtBillEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtBillEnd.TabIndex = 6
            '
            'lblBillDocEnd
            '
            Me.lblBillDocEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillDocEnd.ForeColor = System.Drawing.Color.Black
            Me.lblBillDocEnd.Location = New System.Drawing.Point(248, 40)
            Me.lblBillDocEnd.Name = "lblBillDocEnd"
            Me.lblBillDocEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblBillDocEnd.TabIndex = 58
            Me.lblBillDocEnd.Text = "ถึง"
            Me.lblBillDocEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnBillStartFind
            '
            Me.btnBillStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnBillStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBillStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBillStartFind.Location = New System.Drawing.Point(216, 40)
            Me.btnBillStartFind.Name = "btnBillStartFind"
            Me.btnBillStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnBillStartFind.TabIndex = 19
            Me.btnBillStartFind.TabStop = False
            Me.btnBillStartFind.ThemedImage = CType(resources.GetObject("btnBillStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBillStart
            '
            Me.Validator.SetDataType(Me.txtBillStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillStart, "")
            Me.txtBillStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillStart, System.Drawing.Color.Empty)
            Me.txtBillStart.Location = New System.Drawing.Point(120, 40)
            Me.Validator.SetMaxValue(Me.txtBillStart, "")
            Me.Validator.SetMinValue(Me.txtBillStart, "")
            Me.txtBillStart.Name = "txtBillStart"
            Me.Validator.SetRegularExpression(Me.txtBillStart, "")
            Me.Validator.SetRequired(Me.txtBillStart, False)
            Me.txtBillStart.Size = New System.Drawing.Size(96, 21)
            Me.txtBillStart.TabIndex = 5
            '
            'lblBillDocStart
            '
            Me.lblBillDocStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillDocStart.ForeColor = System.Drawing.Color.Black
            Me.lblBillDocStart.Location = New System.Drawing.Point(32, 40)
            Me.lblBillDocStart.Name = "lblBillDocStart"
            Me.lblBillDocStart.Size = New System.Drawing.Size(80, 18)
            Me.lblBillDocStart.TabIndex = 55
            Me.lblBillDocStart.Text = "ใบรับวางบิล"
            Me.lblBillDocStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierGroupName
            '
            Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.txtSupplierGroupName.Location = New System.Drawing.Point(624, 16)
            Me.txtSupplierGroupName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
            Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
            Me.txtSupplierGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
            Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
            Me.txtSupplierGroupName.Size = New System.Drawing.Size(144, 21)
            Me.txtSupplierGroupName.TabIndex = 51
            '
            'lblSupplierGroup
            '
            Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
            Me.lblSupplierGroup.Location = New System.Drawing.Point(408, 16)
            Me.lblSupplierGroup.Name = "lblSupplierGroup"
            Me.lblSupplierGroup.Size = New System.Drawing.Size(88, 18)
            Me.lblSupplierGroup.TabIndex = 50
            Me.lblSupplierGroup.Text = "กลุ่มผู้ขาย:"
            Me.lblSupplierGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierGroupStart
            '
            Me.Validator.SetDataType(Me.txtSupplierGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierGroupStart, "")
            Me.txtSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
            Me.txtSupplierGroupStart.Location = New System.Drawing.Point(504, 16)
            Me.txtSupplierGroupStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierGroupStart, "")
            Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
            Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
            Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
            Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
            Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSupplierGroupStart.TabIndex = 12
            '
            'btnSupplierGroupStart
            '
            Me.btnSupplierGroupStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierGroupStart.Location = New System.Drawing.Point(600, 16)
            Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
            Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
            Me.btnSupplierGroupStart.TabIndex = 22
            Me.btnSupplierGroupStart.TabStop = False
            Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeSGChildren
            '
            Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeSGChildren.Location = New System.Drawing.Point(504, 40)
            Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
            Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeSGChildren.TabIndex = 54
            Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 115)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 39
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 88)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 21
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 88)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 11
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(8, 88)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
            Me.lblCCStart.TabIndex = 35
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(240, 88)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 36
            '
            'txtDueDateEnd
            '
            Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.txtDueDateEnd.Location = New System.Drawing.Point(280, 64)
            Me.txtDueDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDueDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
            Me.txtDueDateEnd.Name = "txtDueDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
            Me.Validator.SetRequired(Me.txtDueDateEnd, False)
            Me.txtDueDateEnd.Size = New System.Drawing.Size(101, 21)
            Me.txtDueDateEnd.TabIndex = 9
            '
            'txtDueDateStart
            '
            Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.txtDueDateStart.Location = New System.Drawing.Point(120, 64)
            Me.txtDueDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDueDateStart, "")
            Me.Validator.SetMinValue(Me.txtDueDateStart, "")
            Me.txtDueDateStart.Name = "txtDueDateStart"
            Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
            Me.Validator.SetRequired(Me.txtDueDateStart, False)
            Me.txtDueDateStart.Size = New System.Drawing.Size(101, 21)
            Me.txtDueDateStart.TabIndex = 7
            '
            'dtpDueDateStart
            '
            Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDueDateStart.Location = New System.Drawing.Point(120, 64)
            Me.dtpDueDateStart.Name = "dtpDueDateStart"
            Me.dtpDueDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDueDateStart.TabIndex = 8
            Me.dtpDueDateStart.TabStop = False
            '
            'dtpDueDateEnd
            '
            Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDueDateEnd.Location = New System.Drawing.Point(280, 64)
            Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
            Me.dtpDueDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDueDateEnd.TabIndex = 10
            Me.dtpDueDateEnd.TabStop = False
            '
            'lblDueDateStart
            '
            Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateStart.Location = New System.Drawing.Point(8, 64)
            Me.lblDueDateStart.Name = "lblDueDateStart"
            Me.lblDueDateStart.Size = New System.Drawing.Size(104, 18)
            Me.lblDueDateStart.TabIndex = 12
            Me.lblDueDateStart.Text = "ตั้งแต่วันที่ครบกำหนด"
            Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDateEnd
            '
            Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateEnd.Location = New System.Drawing.Point(248, 64)
            Me.lblDueDateEnd.Name = "lblDueDateEnd"
            Me.lblDueDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDueDateEnd.TabIndex = 15
            Me.lblDueDateEnd.Text = "ถึง"
            Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(744, 64)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 24
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
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(648, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeEnd.TabIndex = 14
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(624, 64)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 9
            Me.lblSuppliEnd.Text = "ถึง"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(600, 64)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 23
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
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(504, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeStart.TabIndex = 13
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(416, 64)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(80, 18)
            Me.lblSuppliStart.TabIndex = 6
            Me.lblSuppliStart.Text = "Supplier:"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(101, 21)
            Me.txtDocDateEnd.TabIndex = 3
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(101, 21)
            Me.txtDocDateStart.TabIndex = 1
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 4
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(24, 16)
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
            Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            'ChkShowAll
            '
            Me.ChkShowAll.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ChkShowAll.Location = New System.Drawing.Point(504, 92)
            Me.ChkShowAll.Name = "ChkShowAll"
            Me.ChkShowAll.Size = New System.Drawing.Size(128, 24)
            Me.ChkShowAll.TabIndex = 59
            Me.ChkShowAll.Text = "แสดงทุกเอกสาร"
            '
            'RptAPBillAcceptanceByDueDateFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptAPBillAcceptanceByDueDateFilterSubPanel"
            Me.Size = New System.Drawing.Size(821, 240)
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
      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblSuppliStart}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      'SupplierGroup
      Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblSupplierGroup}")
      Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
      Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.chkIncludeSGChildren}")

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblDueDateStart}")
      Me.Validator.SetDisplayName(txtDueDateStart, lblDueDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDueDateEnd, lblDueDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.grbDetail}")

      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.chkIncludeChildren}")

      Me.lblBillDocStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPBillAcceptanceByDueDateFilterSubPanel.lblBillDocStart}")
      Me.Validator.SetDisplayName(txtBillStart, lblBillDocStart.Text)
      Me.lblBillDocEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtBillEnd, lblBillDocEnd.Text)

            Me.ChkShowAll.Text = Me.StringParserService.Parse("${res:Global.ChkShowAll}")

    End Sub
#End Region

#Region "Member"
    Private m_supplierstart As Supplier
    Private m_supplierend As Supplier
    Private m_sg As SupplierGroup

    Private m_cc As CostCenter

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_DueDateEnd As Date
    Private m_DueDateStart As Date
    Private m_BillStart As BillAcceptance
    Private m_BillEnd As BillAcceptance
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
    Public Property SupplierGroup() As SupplierGroup
      Get
        Return m_sg
      End Get
      Set(ByVal Value As SupplierGroup)
        m_sg = Value
      End Set
    End Property
    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property DueDateEnd() As Date      Get        Return m_DueDateEnd      End Get      Set(ByVal Value As Date)        m_DueDateEnd = Value      End Set    End Property    Public Property DueDateStart() As Date      Get        Return m_DueDateStart      End Get      Set(ByVal Value As Date)        m_DueDateStart = Value      End Set    End Property
    Public Property BillStart() As BillAcceptance
      Get
        Return m_BillStart
      End Get
      Set(ByVal Value As BillAcceptance)
        m_BillStart = Value
      End Set
    End Property
    Public Property BillEnd() As BillAcceptance
      Get
        Return m_BillEnd
      End Get
      Set(ByVal Value As BillAcceptance)
        m_BillEnd = Value
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

      Me.SupplierStart = New Supplier
      Me.SupplierEnd = New Supplier
      Me.SupplierGroup = New SupplierGroup

      Me.CostCenter = New CostCenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = MinDateToNow(Me.DocDateStart)

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = MinDateToNow(Me.DocDateEnd)

      Me.DueDateStart = dtStart
      Me.txtDueDateStart.Text = MinDateToNull(Me.DueDateStart, "")
      Me.dtpDueDateStart.Value = MinDateToNow(Me.DueDateStart)

      Me.DueDateEnd = Date.Now
      Me.txtDueDateEnd.Text = MinDateToNull(Me.DueDateEnd, "")
      Me.dtpDueDateEnd.Value = MinDateToNow(Me.DueDateEnd)

      Me.BillStart = New BillAcceptance
      Me.BillEnd = New BillAcceptance
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
            Dim arr(13) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(4) = New Filter("DueDateStart", IIf(Me.DueDateStart.Equals(Date.MinValue), DBNull.Value, Me.DueDateStart))
      arr(5) = New Filter("DueDateEnd", IIf(Me.DueDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DueDateEnd))
      arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
      arr(7) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
      arr(8) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(9) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(10) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(11) = New Filter("BillStart", Me.ValidIdOrDBNull(BillStart))
            arr(12) = New Filter("BillEnd", Me.ValidIdOrDBNull(BillEnd))
            arr(13) = New Filter("ShowAll", Me.ChkShowAll.Checked)
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

      'duedate start
      dpi = New DocPrintingItem
      dpi.Mapping = "duedatestart"
      dpi.Value = Me.txtDueDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'duedate end
      dpi = New DocPrintingItem
      dpi.Mapping = "duedateend"
      dpi.Value = Me.txtDueDateEnd.Text
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

      'SupplierGroup
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroup"
      dpi.Value = Me.txtSupplierGroupName.Text
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

      'BillStart
      dpi = New DocPrintingItem
      dpi.Mapping = "BillStart"
      dpi.Value = Me.txtBillStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BillEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "BillEnd"
      dpi.Value = Me.txtBillEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
      AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBillStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBillEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler btnBillStartFind.Click, AddressOf Me.btnBillFind_Click
      AddHandler btnBillEndFind.Click, AddressOf Me.btnBillFind_Click
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        'Case "txtsupplicodestart"
        '    Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)

        'Case "txtsupplicodeend"
        '    Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)

      Case "txtcccodestart"
          CostCenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtsuppliergroupstart"
          SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, Me.txtSupplierGroupName, m_sg)

        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          If Not m_dateSetting Then
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
          End If

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          If Not m_dateSetting Then
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
          End If

        Case "dtpduedatestart"
          If Not Me.DueDateStart.Equals(dtpDueDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDateStart = dtpDueDateStart.Value
            End If
          End If
        Case "txtduedatestart"
          If Not m_dateSetting Then
            m_dateSetting = True
            If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
              Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
              If Not Me.DueDateStart.Equals(theDate) Then
                dtpDueDateStart.Value = theDate
                Me.DueDateStart = dtpDueDateStart.Value
              End If
            Else
              Me.dtpDueDateStart.Value = Date.Now
              Me.DueDateStart = Date.MinValue
            End If
            m_dateSetting = False
          End If

        Case "dtpduedateend"
          If Not Me.DueDateEnd.Equals(dtpDueDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDateEnd = dtpDueDateEnd.Value
            End If
          End If
        Case "txtduedateend"
          If Not m_dateSetting Then
            m_dateSetting = True
            If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
              Dim theDate As Date = CDate(Me.txtDueDateEnd.Text)
              If Not Me.DueDateEnd.Equals(theDate) Then
                dtpDueDateEnd.Value = theDate
                Me.DueDateEnd = dtpDueDateEnd.Value
              End If
            Else
              Me.dtpDueDateEnd.Value = Date.Now
              Me.DueDateEnd = Date.MinValue
            End If
            m_dateSetting = False
          End If

        Case "txtbillstart"
          BillAcceptance.GetBillAcceptance(txtBillStart, BillStart)

        Case "txtbillend"
          BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd)

        Case Else
      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsupplicodestart", "txtsupplicodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsupplicodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsupplicodeend"
              Me.SetSupplierEndDialog(entity)

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

    Dim oldBAStart As BillAcceptance
    Dim oldBAEnd As BillAcceptance
    Private Sub btnBillFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnbillstartfind"
          myEntityPanelService.OpenListDialog(New BillAcceptance, AddressOf SetbtnBillStartDialog)

        Case "btnbillendfind"
          myEntityPanelService.OpenListDialog(New BillAcceptance, AddressOf SetbtnBillEndDialog)

      End Select
    End Sub
    Private Sub SetbtnBillStartDialog(ByVal e As ISimpleEntity)
      Me.txtBillStart.Text = e.Code
      BillAcceptance.GetBillAcceptance(txtBillStart, BillStart)
      'If BillAcceptance.GetBillAcceptance(txtBillStart, BillStart) Then
      '    oldBAStart = New BillAcceptance(e.Code)
      'End If
    End Sub
    Private Sub SetbtnBillEndDialog(ByVal e As ISimpleEntity)
      Me.txtBillEnd.Text = e.Code
      BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd)
      'If BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd) Then
      '    oldBAEnd = New BillAcceptance(e.Code)
      'End If
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsuppliergroupstart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
      End Select
    End Sub
    Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierGroupStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
    End Sub
#End Region

  End Class
End Namespace

