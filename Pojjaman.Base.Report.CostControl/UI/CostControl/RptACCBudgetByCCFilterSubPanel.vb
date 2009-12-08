Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptACCBudgetByCCFilterSubPanel
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
        Friend WithEvents lblBudget As System.Windows.Forms.Label
        Friend WithEvents cmbBudget As System.Windows.Forms.ComboBox
        Friend WithEvents txtToDate As System.Windows.Forms.TextBox
        Friend WithEvents txtFromDate As System.Windows.Forms.TextBox
        Friend WithEvents lblBudgetStart As System.Windows.Forms.Label
        Friend WithEvents lblBudgetEnd As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents grbOptions As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkOnlyPosted As System.Windows.Forms.CheckBox
        Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
        Friend WithEvents lblFormat As System.Windows.Forms.Label
        Friend WithEvents chkShowSumEachAcct As System.Windows.Forms.CheckBox
        Friend WithEvents chkComputeDrCr As System.Windows.Forms.CheckBox
        Friend WithEvents btnAcctEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAcctCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
        Friend WithEvents btnAcctStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAcctCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAccountStart As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptACCBudgetByCCFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbOptions = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkOnlyPosted = New System.Windows.Forms.CheckBox
            Me.cmbFormat = New System.Windows.Forms.ComboBox
            Me.lblFormat = New System.Windows.Forms.Label
            Me.chkShowSumEachAcct = New System.Windows.Forms.CheckBox
            Me.chkComputeDrCr = New System.Windows.Forms.CheckBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnAcctEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAcctCodeEnd = New System.Windows.Forms.TextBox
            Me.lblAccountEnd = New System.Windows.Forms.Label
            Me.btnAcctStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAcctCodeStart = New System.Windows.Forms.TextBox
            Me.lblAccountStart = New System.Windows.Forms.Label
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.lblBudget = New System.Windows.Forms.Label
            Me.cmbBudget = New System.Windows.Forms.ComboBox
            Me.txtFromDate = New System.Windows.Forms.TextBox
            Me.lblBudgetStart = New System.Windows.Forms.Label
            Me.lblBudgetEnd = New System.Windows.Forms.Label
            Me.txtToDate = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbOptions.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbOptions)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(712, 208)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'grbOptions
            '
            Me.grbOptions.Controls.Add(Me.chkOnlyPosted)
            Me.grbOptions.Controls.Add(Me.cmbFormat)
            Me.grbOptions.Controls.Add(Me.lblFormat)
            Me.grbOptions.Controls.Add(Me.chkShowSumEachAcct)
            Me.grbOptions.Controls.Add(Me.chkComputeDrCr)
            Me.grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbOptions.Location = New System.Drawing.Point(480, 16)
            Me.grbOptions.Name = "grbOptions"
            Me.grbOptions.Size = New System.Drawing.Size(224, 144)
            Me.grbOptions.TabIndex = 1
            Me.grbOptions.TabStop = False
            Me.grbOptions.Text = "ตัวเลือกการแสดงผล"
            '
            'chkOnlyPosted
            '
            Me.chkOnlyPosted.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkOnlyPosted.Location = New System.Drawing.Point(16, 24)
            Me.chkOnlyPosted.Name = "chkOnlyPosted"
            Me.chkOnlyPosted.Size = New System.Drawing.Size(144, 24)
            Me.chkOnlyPosted.TabIndex = 0
            Me.chkOnlyPosted.Text = "เฉพาะรายการที่ Post แล้ว"
            '
            'cmbFormat
            '
            Me.cmbFormat.Location = New System.Drawing.Point(80, 104)
            Me.cmbFormat.Name = "cmbFormat"
            Me.cmbFormat.TabIndex = 4
            Me.cmbFormat.Visible = False
            '
            'lblFormat
            '
            Me.lblFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFormat.ForeColor = System.Drawing.Color.Black
            Me.lblFormat.Location = New System.Drawing.Point(16, 104)
            Me.lblFormat.Name = "lblFormat"
            Me.lblFormat.Size = New System.Drawing.Size(56, 18)
            Me.lblFormat.TabIndex = 3
            Me.lblFormat.Text = "รูปแบบ"
            Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblFormat.Visible = False
            '
            'chkShowSumEachAcct
            '
            Me.chkShowSumEachAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowSumEachAcct.Location = New System.Drawing.Point(16, 48)
            Me.chkShowSumEachAcct.Name = "chkShowSumEachAcct"
            Me.chkShowSumEachAcct.Size = New System.Drawing.Size(200, 24)
            Me.chkShowSumEachAcct.TabIndex = 1
            Me.chkShowSumEachAcct.Text = "แสดงผลรวมแต่ละหมวดผังบัญชี"
            '
            'chkComputeDrCr
            '
            Me.chkComputeDrCr.Checked = True
            Me.chkComputeDrCr.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkComputeDrCr.Enabled = False
            Me.chkComputeDrCr.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkComputeDrCr.Location = New System.Drawing.Point(16, 72)
            Me.chkComputeDrCr.Name = "chkComputeDrCr"
            Me.chkComputeDrCr.Size = New System.Drawing.Size(192, 24)
            Me.chkComputeDrCr.TabIndex = 2
            Me.chkComputeDrCr.Text = "คำนวณผลลัพธ์ยอดเดบิต-เครดิต"
            Me.chkComputeDrCr.Visible = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnAcctEndFind)
            Me.grbDetail.Controls.Add(Me.txtAcctCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblAccountEnd)
            Me.grbDetail.Controls.Add(Me.btnAcctStartFind)
            Me.grbDetail.Controls.Add(Me.txtAcctCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAccountStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.lblBudget)
            Me.grbDetail.Controls.Add(Me.cmbBudget)
            Me.grbDetail.Controls.Add(Me.txtFromDate)
            Me.grbDetail.Controls.Add(Me.lblBudgetStart)
            Me.grbDetail.Controls.Add(Me.lblBudgetEnd)
            Me.grbDetail.Controls.Add(Me.txtToDate)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(448, 160)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnAcctEndFind
            '
            Me.btnAcctEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAcctEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAcctEndFind.Image = CType(resources.GetObject("btnAcctEndFind.Image"), System.Drawing.Image)
            Me.btnAcctEndFind.Location = New System.Drawing.Point(392, 77)
            Me.btnAcctEndFind.Name = "btnAcctEndFind"
            Me.btnAcctEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAcctEndFind.TabIndex = 11
            Me.btnAcctEndFind.TabStop = False
            Me.btnAcctEndFind.ThemedImage = CType(resources.GetObject("btnAcctEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAcctCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAcctCodeEnd, "")
            Me.txtAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
            Me.txtAcctCodeEnd.Location = New System.Drawing.Point(296, 77)
            Me.txtAcctCodeEnd.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtAcctCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtAcctCodeEnd, "")
            Me.txtAcctCodeEnd.Name = "txtAcctCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAcctCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAcctCodeEnd, False)
            Me.txtAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAcctCodeEnd.TabIndex = 10
            Me.txtAcctCodeEnd.Text = ""
            '
            'lblAccountEnd
            '
            Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAccountEnd.Location = New System.Drawing.Point(264, 77)
            Me.lblAccountEnd.Name = "lblAccountEnd"
            Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAccountEnd.TabIndex = 9
            Me.lblAccountEnd.Text = "ถึง"
            Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAcctStartFind
            '
            Me.btnAcctStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAcctStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAcctStartFind.Image = CType(resources.GetObject("btnAcctStartFind.Image"), System.Drawing.Image)
            Me.btnAcctStartFind.Location = New System.Drawing.Point(232, 77)
            Me.btnAcctStartFind.Name = "btnAcctStartFind"
            Me.btnAcctStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAcctStartFind.TabIndex = 8
            Me.btnAcctStartFind.TabStop = False
            Me.btnAcctStartFind.ThemedImage = CType(resources.GetObject("btnAcctStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAcctCodeStart
            '
            Me.Validator.SetDataType(Me.txtAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAcctCodeStart, "")
            Me.txtAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
            Me.txtAcctCodeStart.Location = New System.Drawing.Point(136, 77)
            Me.txtAcctCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtAcctCodeStart, "")
            Me.Validator.SetMinValue(Me.txtAcctCodeStart, "")
            Me.txtAcctCodeStart.Name = "txtAcctCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAcctCodeStart, "")
            Me.Validator.SetRequired(Me.txtAcctCodeStart, False)
            Me.txtAcctCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAcctCodeStart.TabIndex = 7
            Me.txtAcctCodeStart.Text = ""
            '
            'lblAccountStart
            '
            Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
            Me.lblAccountStart.Location = New System.Drawing.Point(40, 77)
            Me.lblAccountStart.Name = "lblAccountStart"
            Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAccountStart.TabIndex = 6
            Me.lblAccountStart.Text = "ตั้งแต่รหัสบัญชี"
            Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(136, 128)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(144, 24)
            Me.chkIncludeChildren.TabIndex = 16
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(232, 104)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 14
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(136, 104)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 13
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(48, 104)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(80, 18)
            Me.lblCCStart.TabIndex = 12
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(256, 104)
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
            'lblBudget
            '
            Me.lblBudget.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBudget.ForeColor = System.Drawing.Color.Black
            Me.lblBudget.Location = New System.Drawing.Point(8, 24)
            Me.lblBudget.Name = "lblBudget"
            Me.lblBudget.Size = New System.Drawing.Size(128, 18)
            Me.lblBudget.TabIndex = 0
            Me.lblBudget.Text = "Budget:"
            Me.lblBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbBudget
            '
            Me.cmbBudget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBudget.Location = New System.Drawing.Point(136, 24)
            Me.cmbBudget.Name = "cmbBudget"
            Me.cmbBudget.Size = New System.Drawing.Size(240, 21)
            Me.cmbBudget.TabIndex = 1
            '
            'txtFromDate
            '
            Me.Validator.SetDataType(Me.txtFromDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtFromDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtFromDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtFromDate, System.Drawing.Color.Empty)
            Me.txtFromDate.Location = New System.Drawing.Point(136, 48)
            Me.txtFromDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtFromDate, "")
            Me.Validator.SetMinValue(Me.txtFromDate, "")
            Me.txtFromDate.Name = "txtFromDate"
            Me.txtFromDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtFromDate, "")
            Me.Validator.SetRequired(Me.txtFromDate, False)
            Me.txtFromDate.Size = New System.Drawing.Size(99, 21)
            Me.txtFromDate.TabIndex = 3
            Me.txtFromDate.Text = ""
            '
            'lblBudgetStart
            '
            Me.lblBudgetStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBudgetStart.ForeColor = System.Drawing.Color.Black
            Me.lblBudgetStart.Location = New System.Drawing.Point(8, 49)
            Me.lblBudgetStart.Name = "lblBudgetStart"
            Me.lblBudgetStart.Size = New System.Drawing.Size(128, 18)
            Me.lblBudgetStart.TabIndex = 2
            Me.lblBudgetStart.Text = "From Date:"
            Me.lblBudgetStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBudgetEnd
            '
            Me.lblBudgetEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBudgetEnd.ForeColor = System.Drawing.Color.Black
            Me.lblBudgetEnd.Location = New System.Drawing.Point(256, 49)
            Me.lblBudgetEnd.Name = "lblBudgetEnd"
            Me.lblBudgetEnd.Size = New System.Drawing.Size(32, 18)
            Me.lblBudgetEnd.TabIndex = 4
            Me.lblBudgetEnd.Text = "to:"
            Me.lblBudgetEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtToDate
            '
            Me.Validator.SetDataType(Me.txtToDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtToDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToDate, System.Drawing.Color.Empty)
            Me.txtToDate.Location = New System.Drawing.Point(296, 48)
            Me.txtToDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtToDate, "")
            Me.Validator.SetMinValue(Me.txtToDate, "")
            Me.txtToDate.Name = "txtToDate"
            Me.txtToDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToDate, "")
            Me.Validator.SetRequired(Me.txtToDate, False)
            Me.txtToDate.Size = New System.Drawing.Size(99, 21)
            Me.txtToDate.TabIndex = 5
            Me.txtToDate.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(620, 176)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(540, 176)
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
            'RptACCBudgetByCCFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptACCBudgetByCCFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 224)
            Me.grbMaster.ResumeLayout(False)
            Me.grbOptions.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblAccountStart}")
            Me.Validator.SetDisplayName(txtAcctCodeStart, lblAccountStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkIncludeChildren}")
            ' Global {ถึง}
            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAcctCodeEnd, lblAccountEnd.Text)


            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbDetail}")
            Me.grbOptions.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbOptions}")

            Me.lblFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblFormat}")
            'Checkbox
            Me.chkOnlyPosted.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkOnlyPosted}")
            Me.chkShowSumEachAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkShowSumEachAcct}")
            Me.chkComputeDrCr.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkComputeDrCr}")

            Me.lblBudget.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptACCBudgetByCCFilterSubPanel.lblBudget}")

            Me.lblBudgetStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptACCBudgetByCCFilterSubPanel.lblBudgetStart}")
            ' Global {ถึง}
            Me.lblBudgetEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

        End Sub
#End Region

#Region "Member"
        Private m_format As JournalEntryFilterOrderBy
        Private m_cc As CostCenter
        Private m_selectedItem As BudgetItem
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            m_cc = New CostCenter

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
#End Region

#Region "Methods"
        Private Function GetBudgetDataSet() As DataSet
            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString()
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
                        , CommandType.StoredProcedure _
                        , "GetACCBudgetDistinctList" _
                        )
            Return ds
        End Function
        Private Sub LoadCombo()
            Dim dt As DataTable = GetBudgetDataSet.Tables(0)
            Me.cmbBudget.Items.Clear()
            Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            For Each row As DataRow In dt.Rows
                Dim item As New BudgetItem
                If Not row.IsNull("accb_name") Then
                    item.Name = row("accb_name").ToString
                End If
                If IsDate(row("startdate")) Then
                    item.StartDate = CDate(row("startdate"))
                End If
                If IsDate(row("enddate")) Then
                    item.EndDate = CDate(row("enddate"))
                End If
                Me.cmbBudget.Items.Add(item)
            Next
            JournalEntryFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbFormat, "rpt_journalentryfilter")
        End Sub
        Private Sub cmbBudget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBudget.SelectedIndexChanged
            If TypeOf Me.cmbBudget.SelectedItem Is BudgetItem Then
                m_selectedItem = CType(Me.cmbBudget.SelectedItem, BudgetItem)
                Me.txtFromDate.Text = m_selectedItem.StartDate
                Me.txtToDate.Text = m_selectedItem.EndDate
            End If
        End Sub
        Private Sub Initialize()
            LoadCombo()
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

            If Me.cmbFormat.Items.Count > 0 Then
                Me.cmbFormat.SelectedIndex = 0
            End If
            If Me.cmbBudget.Items.Count > 0 Then
                Me.cmbBudget.SelectedIndex = 0
            End If
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(11) As Filter
            arr(0) = New Filter("AcctCodeStart", IIf(txtAcctCodeStart.TextLength > 0, txtAcctCodeStart.Text, DBNull.Value))
            arr(1) = New Filter("AcctCodeEnd", IIf(txtAcctCodeEnd.TextLength > 0, txtAcctCodeEnd.Text, DBNull.Value))
            arr(2) = New Filter("DocDateStart", IIf(Me.m_selectedItem.StartDate.Equals(Date.MinValue), DBNull.Value, Me.m_selectedItem.StartDate))
            arr(3) = New Filter("DocDateEnd", IIf(Me.m_selectedItem.EndDate.Equals(Date.MinValue), DBNull.Value, Me.m_selectedItem.EndDate))
            arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("Format", JournalEntryFilterOrderBy.GetValue("rpt_journalentryfilter", cmbFormat.Text))
            arr(7) = New Filter("OnlyPosted", Me.chkOnlyPosted.Checked)
            arr(8) = New Filter("ShowSumEachAcct", Me.chkShowSumEachAcct.Checked)
            arr(9) = New Filter("ComputeDrCr", Me.chkComputeDrCr.Checked)
            arr(10) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(11) = New Filter("budgetname", IIf(Me.m_selectedItem.Name.Length > 0, Me.m_selectedItem.Name, DBNull.Value))
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

        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnAcctStartFind.Click, AddressOf Me.btnAccountFind_Click
            AddHandler btnAcctEndFind.Click, AddressOf Me.btnAccountFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent(m_cc.FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower

                            Case "txttoccstart", "txttoccend"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent(m_cc.FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower

                            Case "txttoccstart", "txttoccend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(m_cc.FullClassName) Then
                Dim id As Integer = CInt(data.GetData(m_cc.FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower

                        Case "txttoccstart"
                            Me.SetCostcenterStartDialog(entity)


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
                Case "btnacctstartfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountStartDialog)

                Case "btnacctendfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountEndDialog)

            End Select
        End Sub
        Private Sub SetAccountStartDialog(ByVal e As ISimpleEntity)
            Me.txtAcctCodeStart.Text = e.Code
        End Sub
        Private Sub SetAccountEndDialog(ByVal e As ISimpleEntity)
            Me.txtAcctCodeEnd.Text = e.Code
        End Sub
        ' costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterStartDialog)
        End Sub
        Private Sub SetCostcenterStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            CostCenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region


        Private Class BudgetItem
            Public Name As String
            Public StartDate As Date
            Public EndDate As Date
            Public Overrides Function ToString() As String
                Return Me.Name
            End Function
        End Class
        ' เรียงตาม 
        Private Class JournalEntryFilterOrderBy
            Inherits CodeDescription

#Region "Construtors"
            Public Sub New(ByVal value As Integer)
                MyBase.New(value)
            End Sub
#End Region

#Region "Properties"
            Public Overrides ReadOnly Property CodeName() As String
                Get
                    Return "rpt_journalentryfilter"
                End Get
            End Property
#End Region

        End Class
    End Class
End Namespace

