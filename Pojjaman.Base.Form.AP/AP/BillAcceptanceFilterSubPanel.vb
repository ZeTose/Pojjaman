Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BillAcceptanceFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblBillIssue As System.Windows.Forms.Label
        Friend WithEvents txtBillIssueCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents grbDueDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BillAcceptanceFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSupplierCode = New System.Windows.Forms.TextBox
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.txtBillIssueCode = New System.Windows.Forms.TextBox
            Me.lblBillIssue = New System.Windows.Forms.Label
            Me.grbDueDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDueDateStart = New System.Windows.Forms.TextBox
            Me.txtDueDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDueDateStart = New System.Windows.Forms.Label
            Me.lblDueDateEnd = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.grbDueDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(224, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.Controls.Add(Me.grbDueDate)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(752, 184)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ค้นหา"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(368, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(264, 72)
            Me.grbDocDate.TabIndex = 2
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(104, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(117, 20)
            Me.txtDocDateStart.TabIndex = 12
            Me.txtDocDateStart.Text = ""
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(104, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(117, 20)
            Me.txtDocDateEnd.TabIndex = 13
            Me.txtDocDateEnd.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpDocDateStart.TabIndex = 14
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(104, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateEnd.TabIndex = 15
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(16, 17)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(80, 18)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "Start Date:"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(16, 41)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(80, 18)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "End Date:"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(664, 136)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(664, 96)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
            Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
            Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
            Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
            Me.grbMainDetail.Controls.Add(Me.lblSupplier)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.txtBillIssueCode)
            Me.grbMainDetail.Controls.Add(Me.lblBillIssue)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(352, 144)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'btnSupplierPanel
            '
            Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierPanel.Image = CType(resources.GetObject("btnSupplierPanel.Image"), System.Drawing.Image)
            Me.btnSupplierPanel.Location = New System.Drawing.Point(312, 64)
            Me.btnSupplierPanel.Name = "btnSupplierPanel"
            Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierPanel.TabIndex = 212
            Me.btnSupplierPanel.TabStop = False
            Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, False)
            Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
            Me.txtSupplierCode.TabIndex = 3
            Me.txtSupplierCode.Text = ""
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(192, 64)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(96, 20)
            Me.txtSupplierName.TabIndex = 211
            Me.txtSupplierName.TabStop = False
            Me.txtSupplierName.Text = ""
            '
            'btnSupplierDialog
            '
            Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierDialog.Image = CType(resources.GetObject("btnSupplierDialog.Image"), System.Drawing.Image)
            Me.btnSupplierDialog.Location = New System.Drawing.Point(288, 64)
            Me.btnSupplierDialog.Name = "btnSupplierDialog"
            Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierDialog.TabIndex = 4
            Me.btnSupplierDialog.TabStop = False
            Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSupplier
            '
            Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblSupplier.Location = New System.Drawing.Point(8, 64)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(104, 18)
            Me.lblSupplier.TabIndex = 210
            Me.lblSupplier.Text = "Supplier:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(112, 87)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(224, 21)
            Me.cmbStatus.TabIndex = 5
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 88)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBillIssueCode
            '
            Me.Validator.SetDataType(Me.txtBillIssueCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillIssueCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtBillIssueCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBillIssueCode, System.Drawing.Color.Empty)
            Me.txtBillIssueCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtBillIssueCode, "")
            Me.Validator.SetMinValue(Me.txtBillIssueCode, "")
            Me.txtBillIssueCode.Name = "txtBillIssueCode"
            Me.Validator.SetRegularExpression(Me.txtBillIssueCode, "")
            Me.Validator.SetRequired(Me.txtBillIssueCode, False)
            Me.txtBillIssueCode.Size = New System.Drawing.Size(224, 20)
            Me.txtBillIssueCode.TabIndex = 2
            Me.txtBillIssueCode.Text = ""
            '
            'lblBillIssue
            '
            Me.lblBillIssue.BackColor = System.Drawing.Color.Transparent
            Me.lblBillIssue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillIssue.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblBillIssue.Location = New System.Drawing.Point(8, 40)
            Me.lblBillIssue.Name = "lblBillIssue"
            Me.lblBillIssue.Size = New System.Drawing.Size(104, 18)
            Me.lblBillIssue.TabIndex = 208
            Me.lblBillIssue.Text = "เลขที่ใบวางบิลผู้ขาย:"
            Me.lblBillIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDueDate
            '
            Me.grbDueDate.Controls.Add(Me.txtDueDateStart)
            Me.grbDueDate.Controls.Add(Me.txtDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateStart)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.lblDueDateStart)
            Me.grbDueDate.Controls.Add(Me.lblDueDateEnd)
            Me.grbDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDueDate.Location = New System.Drawing.Point(368, 88)
            Me.grbDueDate.Name = "grbDueDate"
            Me.grbDueDate.Size = New System.Drawing.Size(264, 72)
            Me.grbDueDate.TabIndex = 2
            Me.grbDueDate.TabStop = False
            Me.grbDueDate.Text = "วันที่ครบกำหนด"
            '
            'txtDueDateStart
            '
            Me.txtDueDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.txtDueDateStart.Location = New System.Drawing.Point(104, 14)
            Me.Validator.SetMaxValue(Me.txtDueDateStart, "")
            Me.Validator.SetMinValue(Me.txtDueDateStart, "")
            Me.txtDueDateStart.Name = "txtDueDateStart"
            Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
            Me.Validator.SetRequired(Me.txtDueDateStart, False)
            Me.txtDueDateStart.Size = New System.Drawing.Size(117, 20)
            Me.txtDueDateStart.TabIndex = 14
            Me.txtDueDateStart.Text = ""
            '
            'txtDueDateEnd
            '
            Me.txtDueDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.txtDueDateEnd.Location = New System.Drawing.Point(104, 38)
            Me.Validator.SetMaxValue(Me.txtDueDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
            Me.txtDueDateEnd.Name = "txtDueDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
            Me.Validator.SetRequired(Me.txtDueDateEnd, False)
            Me.txtDueDateEnd.Size = New System.Drawing.Size(117, 20)
            Me.txtDueDateEnd.TabIndex = 15
            Me.txtDueDateEnd.Text = ""
            '
            'dtpDueDateStart
            '
            Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateStart.Location = New System.Drawing.Point(112, 14)
            Me.dtpDueDateStart.Name = "dtpDueDateStart"
            Me.dtpDueDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpDueDateStart.TabIndex = 14
            Me.dtpDueDateStart.TabStop = False
            '
            'dtpDueDateEnd
            '
            Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateEnd.Location = New System.Drawing.Point(104, 38)
            Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
            Me.dtpDueDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDueDateEnd.TabIndex = 15
            Me.dtpDueDateEnd.TabStop = False
            '
            'lblDueDateStart
            '
            Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateStart.Location = New System.Drawing.Point(16, 17)
            Me.lblDueDateStart.Name = "lblDueDateStart"
            Me.lblDueDateStart.Size = New System.Drawing.Size(80, 18)
            Me.lblDueDateStart.TabIndex = 11
            Me.lblDueDateStart.Text = "Start Date:"
            Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDateEnd
            '
            Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateEnd.Location = New System.Drawing.Point(16, 41)
            Me.lblDueDateEnd.Name = "lblDueDateEnd"
            Me.lblDueDateEnd.Size = New System.Drawing.Size(80, 18)
            Me.lblDueDateEnd.TabIndex = 11
            Me.lblDueDateEnd.Text = "End Date:"
            Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'BillAcceptanceFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "BillAcceptanceFilterSubPanel"
            Me.Size = New System.Drawing.Size(784, 224)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbDueDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region "Members"
        Private m_supplier As Supplier
        Private docDateStart As Date
        Private docDateEnd As Date
        Private dueDateStart As Date
        Private dueDateEnd As Date
#End Region

#Region "Methods"
        Public Sub Initialize()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            PopulateStatus()
            ClearCriterias()
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.docDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.docDateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.docDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.docDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.docDateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.docDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "dtpduedatestart"
                    If Not Me.dueDateStart.Equals(dtpDueDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateStart = dtpDueDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedatestart"
                    m_dateSetting = True
                    If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
                        If Not Me.dueDateStart.Equals(theDate) Then
                            dtpDueDateStart.Value = theDate
                            Me.dueDateStart = dtpDueDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateStart.Value = Date.Now
                        Me.dueDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpduedateend"
                    If Not Me.dueDateEnd.Equals(dtpDueDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateEnd = dtpDueDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedateend"
                    m_dateSetting = True
                    If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateEnd.Text)
                        If Not Me.dueDateEnd.Equals(theDate) Then
                            dtpDueDateEnd.Value = theDate
                            Me.dueDateEnd = dtpDueDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateEnd.Value = Date.Now
                        Me.dueDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""

            Me.txtSupplierCode.Text = ""
            Me.txtSupplierName.Text = ""
            Me.m_supplier = New Supplier

            Me.txtBillIssueCode.Text = ""

            Me.dtpDocDateStart.Value = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

            Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.docDateEnd = Now.Date

            Me.dtpDueDateStart.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.dtpDueDateEnd.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, 1, Now.Date), "")

            Me.txtDueDateStart.Text = ""
            Me.txtDueDateEnd.Text = ""

            Me.dueDateStart = Date.MinValue
            Me.dueDateEnd = Date.MinValue

            cmbStatus.SelectedIndex = 0
        End Sub
        Private Sub PopulateStatus()
            CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "billa_status", True)
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblDocDateEnd}")
            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblSupplier}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblStatus}")
            Me.lblBillIssue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblBillIssue}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.grbMainDetail}")
            Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblDueDateStart}")
            Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceFilterSubPanel.lblDueDateEnd}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(7) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("supplier_id", IIf(Me.m_supplier.Originated, Me.m_supplier.Id, DBNull.Value))
            arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
            arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
            arr(4) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
            arr(5) = New Filter("billa_billissueCode", IIf(Me.txtBillIssueCode.Text.Length = 0, DBNull.Value, Me.txtBillIssueCode.Text))
            arr(6) = New Filter("duedatestart", ValidDateOrDBNull(dueDateStart))
            arr(7) = New Filter("duedateend", ValidDateOrDBNull(dueDateEnd))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
        End Sub
        Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub
        Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
        End Sub
        Private Sub SetSupplier(ByVal e As ISimpleEntity)
            Me.txtSupplierCode.Text = e.Code
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsuppliercode", "txtsuppliername"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtsuppliercode", "txtsuppliername"
                        Me.SetSupplier(entity)
                End Select
            End If
        End Sub
#End Region

#Region "Entities"
        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                For Each entity As ISimpleEntity In Value

                    If TypeOf entity Is BillAcceptance Then
                        Dim obj As BillAcceptance
                        obj = CType(entity, BillAcceptance)
                        If obj.Supplier.Originated Then
                            Me.SetSupplier(obj.Supplier)
                            Me.txtSupplierCode.Enabled = False
                            Me.txtSupplierName.Enabled = False
                            Me.btnSupplierDialog.Enabled = False
                            Me.btnSupplierPanel.Enabled = False
                        End If
                    End If
                    If TypeOf entity Is Supplier Then
                        Me.SetSupplier(entity)
                        Me.txtSupplierCode.Enabled = False
                        Me.txtSupplierName.Enabled = False
                        Me.btnSupplierDialog.Enabled = False
                        Me.btnSupplierPanel.Enabled = False
                    End If
                Next
            End Set
        End Property
#End Region

        Private Sub lblDocDateStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDocDateStart.Click

        End Sub
    End Class
End Namespace

