Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class JournalEntryUpdateFilterSubPanel
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
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowAccount As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents ibtnShowAccountDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents grbRefDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
        Friend WithEvents lblRefDoc As System.Windows.Forms.Label
        Friend WithEvents dtpRefDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblRefDateStart As System.Windows.Forms.Label
        Friend WithEvents lblRefDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpRefDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents txtLastEditorCode As System.Windows.Forms.TextBox
        Friend WithEvents txtLastEditorName As System.Windows.Forms.TextBox
        Friend WithEvents btnLastEditorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblLastEditor As System.Windows.Forms.Label
        Friend WithEvents lblMode As System.Windows.Forms.Label
        Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalEntryUpdateFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtAccountName = New System.Windows.Forms.TextBox
            Me.ibtnShowAccount = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblAccount = New System.Windows.Forms.Label
            Me.ibtnShowAccountDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountCode = New System.Windows.Forms.TextBox
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtLastEditorCode = New System.Windows.Forms.TextBox
            Me.txtLastEditorName = New System.Windows.Forms.TextBox
            Me.lblLastEditor = New System.Windows.Forms.Label
            Me.btnLastEditorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.lblType = New System.Windows.Forms.Label
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblMode = New System.Windows.Forms.Label
            Me.cmbMode = New System.Windows.Forms.ComboBox
            Me.grbRefDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtRefCode = New System.Windows.Forms.TextBox
            Me.lblRefDoc = New System.Windows.Forms.Label
            Me.dtpRefDateStart = New System.Windows.Forms.DateTimePicker
            Me.lblRefDateStart = New System.Windows.Forms.Label
            Me.lblRefDateEnd = New System.Windows.Forms.Label
            Me.dtpRefDateEnd = New System.Windows.Forms.DateTimePicker
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.grbRefDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 17)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(120, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(216, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbItem)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.Controls.Add(Me.grbRefDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 240)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(648, 208)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(568, 208)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.txtAccountName)
            Me.grbItem.Controls.Add(Me.ibtnShowAccount)
            Me.grbItem.Controls.Add(Me.lblAccount)
            Me.grbItem.Controls.Add(Me.ibtnShowAccountDialog)
            Me.grbItem.Controls.Add(Me.txtAccountCode)
            Me.grbItem.Controls.Add(Me.txtCostCenterCode)
            Me.grbItem.Controls.Add(Me.txtCostCenterName)
            Me.grbItem.Controls.Add(Me.btnCostCenterDialog)
            Me.grbItem.Controls.Add(Me.lblCC)
            Me.grbItem.Controls.Add(Me.btnCostCenterPanel)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(368, 128)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(352, 72)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายการ"
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(192, 16)
            Me.Validator.SetMaxValue(Me.txtAccountName, "")
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(96, 20)
            Me.txtAccountName.TabIndex = 204
            Me.txtAccountName.TabStop = False
            Me.txtAccountName.Text = ""
            '
            'ibtnShowAccount
            '
            Me.ibtnShowAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccount.Image = CType(resources.GetObject("ibtnShowAccount.Image"), System.Drawing.Image)
            Me.ibtnShowAccount.Location = New System.Drawing.Point(312, 16)
            Me.ibtnShowAccount.Name = "ibtnShowAccount"
            Me.ibtnShowAccount.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccount.TabIndex = 205
            Me.ibtnShowAccount.TabStop = False
            Me.ibtnShowAccount.ThemedImage = CType(resources.GetObject("ibtnShowAccount.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblAccount
            '
            Me.lblAccount.BackColor = System.Drawing.Color.Transparent
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblAccount.Location = New System.Drawing.Point(8, 16)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(104, 18)
            Me.lblAccount.TabIndex = 203
            Me.lblAccount.Text = "ผังบัญชี:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowAccountDialog
            '
            Me.ibtnShowAccountDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccountDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowAccountDialog.Image = CType(resources.GetObject("ibtnShowAccountDialog.Image"), System.Drawing.Image)
            Me.ibtnShowAccountDialog.Location = New System.Drawing.Point(288, 16)
            Me.ibtnShowAccountDialog.Name = "ibtnShowAccountDialog"
            Me.ibtnShowAccountDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccountDialog.TabIndex = 206
            Me.ibtnShowAccountDialog.TabStop = False
            Me.ibtnShowAccountDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCode
            '
            Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.txtAccountCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtAccountCode, "")
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, False)
            Me.txtAccountCode.Size = New System.Drawing.Size(80, 20)
            Me.txtAccountCode.TabIndex = 1
            Me.txtAccountCode.Text = ""
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, False)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCostCenterCode.TabIndex = 2
            Me.txtCostCenterCode.Text = ""
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtCostCenterName.TabIndex = 196
            Me.txtCostCenterName.TabStop = False
            Me.txtCostCenterName.Text = ""
            '
            'btnCostCenterDialog
            '
            Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCostCenterDialog.Image = CType(resources.GetObject("btnCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnCostCenterDialog.Location = New System.Drawing.Point(288, 40)
            Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
            Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterDialog.TabIndex = 201
            Me.btnCostCenterDialog.TabStop = False
            Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.BackColor = System.Drawing.Color.Transparent
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCC.Location = New System.Drawing.Point(8, 40)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 192
            Me.lblCC.Text = "CostCenter:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCostCenterPanel
            '
            Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterPanel.Image = CType(resources.GetObject("btnCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnCostCenterPanel.Location = New System.Drawing.Point(312, 40)
            Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
            Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterPanel.TabIndex = 199
            Me.btnCostCenterPanel.TabStop = False
            Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.txtLastEditorCode)
            Me.grbMainDetail.Controls.Add(Me.txtLastEditorName)
            Me.grbMainDetail.Controls.Add(Me.lblLastEditor)
            Me.grbMainDetail.Controls.Add(Me.btnLastEditorDialog)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.cmbType)
            Me.grbMainDetail.Controls.Add(Me.lblType)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.lblMode)
            Me.grbMainDetail.Controls.Add(Me.cmbMode)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(352, 192)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'txtLastEditorCode
            '
            Me.Validator.SetDataType(Me.txtLastEditorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLastEditorCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLastEditorCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLastEditorCode, System.Drawing.Color.Empty)
            Me.txtLastEditorCode.Location = New System.Drawing.Point(128, 136)
            Me.Validator.SetMaxValue(Me.txtLastEditorCode, "")
            Me.Validator.SetMinValue(Me.txtLastEditorCode, "")
            Me.txtLastEditorCode.Name = "txtLastEditorCode"
            Me.Validator.SetRegularExpression(Me.txtLastEditorCode, "")
            Me.Validator.SetRequired(Me.txtLastEditorCode, False)
            Me.txtLastEditorCode.Size = New System.Drawing.Size(80, 20)
            Me.txtLastEditorCode.TabIndex = 200
            Me.txtLastEditorCode.Text = ""
            '
            'txtLastEditorName
            '
            Me.Validator.SetDataType(Me.txtLastEditorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLastEditorName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLastEditorName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLastEditorName, System.Drawing.Color.Empty)
            Me.txtLastEditorName.Location = New System.Drawing.Point(208, 136)
            Me.Validator.SetMaxValue(Me.txtLastEditorName, "")
            Me.Validator.SetMinValue(Me.txtLastEditorName, "")
            Me.txtLastEditorName.Name = "txtLastEditorName"
            Me.txtLastEditorName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLastEditorName, "")
            Me.Validator.SetRequired(Me.txtLastEditorName, False)
            Me.txtLastEditorName.Size = New System.Drawing.Size(96, 20)
            Me.txtLastEditorName.TabIndex = 202
            Me.txtLastEditorName.TabStop = False
            Me.txtLastEditorName.Text = ""
            '
            'lblLastEditor
            '
            Me.lblLastEditor.BackColor = System.Drawing.Color.Transparent
            Me.lblLastEditor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLastEditor.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLastEditor.Location = New System.Drawing.Point(24, 136)
            Me.lblLastEditor.Name = "lblLastEditor"
            Me.lblLastEditor.Size = New System.Drawing.Size(104, 18)
            Me.lblLastEditor.TabIndex = 201
            Me.lblLastEditor.Text = "ผู้บันทึก:"
            Me.lblLastEditor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnLastEditorDialog
            '
            Me.btnLastEditorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLastEditorDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLastEditorDialog.Image = CType(resources.GetObject("btnLastEditorDialog.Image"), System.Drawing.Image)
            Me.btnLastEditorDialog.Location = New System.Drawing.Point(304, 134)
            Me.btnLastEditorDialog.Name = "btnLastEditorDialog"
            Me.btnLastEditorDialog.Size = New System.Drawing.Size(24, 24)
            Me.btnLastEditorDialog.TabIndex = 203
            Me.btnLastEditorDialog.TabStop = False
            Me.btnLastEditorDialog.ThemedImage = CType(resources.GetObject("btnLastEditorDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 88)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Location = New System.Drawing.Point(128, 40)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(216, 21)
            Me.cmbType.TabIndex = 198
            '
            'lblType
            '
            Me.lblType.BackColor = System.Drawing.Color.Transparent
            Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblType.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblType.Location = New System.Drawing.Point(8, 41)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(120, 18)
            Me.lblType.TabIndex = 199
            Me.lblType.Text = "ประเภท:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Enabled = False
            Me.cmbStatus.Location = New System.Drawing.Point(128, 64)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(216, 21)
            Me.cmbStatus.TabIndex = 3
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 65)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(120, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 112)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 88)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpDocDateStart.TabIndex = 0
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(128, 112)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(128, 20)
            Me.dtpDocDateEnd.TabIndex = 1
            '
            'lblMode
            '
            Me.lblMode.BackColor = System.Drawing.Color.Transparent
            Me.lblMode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMode.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblMode.Location = New System.Drawing.Point(16, 162)
            Me.lblMode.Name = "lblMode"
            Me.lblMode.Size = New System.Drawing.Size(112, 18)
            Me.lblMode.TabIndex = 201
            Me.lblMode.Text = "โหมดการทำงาน:"
            Me.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbMode
            '
            Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMode.Location = New System.Drawing.Point(128, 163)
            Me.cmbMode.Name = "cmbMode"
            Me.cmbMode.Size = New System.Drawing.Size(216, 21)
            Me.cmbMode.TabIndex = 3
            '
            'grbRefDetail
            '
            Me.grbRefDetail.Controls.Add(Me.txtRefCode)
            Me.grbRefDetail.Controls.Add(Me.lblRefDoc)
            Me.grbRefDetail.Controls.Add(Me.dtpRefDateStart)
            Me.grbRefDetail.Controls.Add(Me.lblRefDateStart)
            Me.grbRefDetail.Controls.Add(Me.lblRefDateEnd)
            Me.grbRefDetail.Controls.Add(Me.dtpRefDateEnd)
            Me.grbRefDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRefDetail.Location = New System.Drawing.Point(368, 24)
            Me.grbRefDetail.Name = "grbRefDetail"
            Me.grbRefDetail.Size = New System.Drawing.Size(352, 96)
            Me.grbRefDetail.TabIndex = 0
            Me.grbRefDetail.TabStop = False
            Me.grbRefDetail.Text = "รายละเอียดทั่วไป"
            '
            'txtRefCode
            '
            Me.Validator.SetDataType(Me.txtRefCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRefCode, "")
            Me.txtRefCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
            Me.txtRefCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtRefCode, "")
            Me.Validator.SetMinValue(Me.txtRefCode, "")
            Me.txtRefCode.Name = "txtRefCode"
            Me.Validator.SetRegularExpression(Me.txtRefCode, "")
            Me.Validator.SetRequired(Me.txtRefCode, False)
            Me.txtRefCode.Size = New System.Drawing.Size(224, 21)
            Me.txtRefCode.TabIndex = 0
            Me.txtRefCode.Text = ""
            '
            'lblRefDoc
            '
            Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDoc.ForeColor = System.Drawing.Color.Black
            Me.lblRefDoc.Location = New System.Drawing.Point(8, 17)
            Me.lblRefDoc.Name = "lblRefDoc"
            Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDoc.TabIndex = 6
            Me.lblRefDoc.Text = "รหัส:"
            Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpRefDateStart
            '
            Me.dtpRefDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpRefDateStart.Location = New System.Drawing.Point(112, 40)
            Me.dtpRefDateStart.Name = "dtpRefDateStart"
            Me.dtpRefDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpRefDateStart.TabIndex = 0
            '
            'lblRefDateStart
            '
            Me.lblRefDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblRefDateStart.Location = New System.Drawing.Point(8, 41)
            Me.lblRefDateStart.Name = "lblRefDateStart"
            Me.lblRefDateStart.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDateStart.TabIndex = 11
            Me.lblRefDateStart.Text = "ตั้งแต่"
            Me.lblRefDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDateEnd
            '
            Me.lblRefDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblRefDateEnd.Location = New System.Drawing.Point(8, 65)
            Me.lblRefDateEnd.Name = "lblRefDateEnd"
            Me.lblRefDateEnd.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDateEnd.TabIndex = 11
            Me.lblRefDateEnd.Text = "ถึง"
            Me.lblRefDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpRefDateEnd
            '
            Me.dtpRefDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpRefDateEnd.Location = New System.Drawing.Point(112, 64)
            Me.dtpRefDateEnd.Name = "dtpRefDateEnd"
            Me.dtpRefDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpRefDateEnd.TabIndex = 1
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
            'JournalEntryUpdateFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "JournalEntryUpdateFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 256)
            Me.grbDetail.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbRefDetail.ResumeLayout(False)
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
        Private m_cc As CostCenter
        Private m_acct As Account
        Private m_employee As Employee
        Private m_entity As ISimpleEntity
#End Region

#Region "Methods"
        Public Sub Initialize()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "gl_type", True)
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbStatus, "gl_status", True)
            With cmbMode.Items
                .Add("ผ่านรายการ")
                .Add("ยกเลิกการผ่านรายการ")
            End With
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtRefCode.Text = ""

            Me.txtCostCenterCode.Text = ""
            Me.txtCostCenterName.Text = ""
            Me.m_cc = New CostCenter

            Me.txtAccountCode.Text = ""
            Me.txtAccountName.Text = ""
            Me.m_acct = New Account

            Me.txtLastEditorCode.Text = ""
            Me.txtLastEditorName.Text = ""
            Me.m_employee = New Employee

            Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Now.Date
            Me.dtpRefDateEnd.Value = Now.Date
            Me.dtpRefDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.cmbType.SelectedIndex = 0
            Me.cmbStatus.SelectedIndex = 0
            Me.cmbMode.SelectedIndex = 0
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblDocDateEnd}")
            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblCC}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblStatus}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.grbItem}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.grbMainDetail}")
            Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblAccount}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblType}")
            Me.grbRefDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.grbRefDetail}")
            Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblRefDoc}")
            Me.lblRefDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblRefDateStart}")
            Me.lblRefDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblRefDateEnd}")
            Me.lblLastEditor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryUpdateFilterSubPanel.lblLastEditor}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(10) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("refcode", IIf(Me.txtRefCode.Text.Length = 0, DBNull.Value, Me.txtRefCode.Text))
            arr(2) = New Filter("cc_id", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
            arr(3) = New Filter("docdatestart", Me.dtpDocDateStart.Value.Date)
            arr(4) = New Filter("docdateend", Me.dtpDocDateEnd.Value.Date)
            arr(5) = New Filter("refdatestart", Me.dtpRefDateStart.Value.Date)
            arr(6) = New Filter("refdateend", Me.dtpRefDateEnd.Value.Date)
            arr(7) = New Filter("acct_id", IIf(Me.m_acct.Valid, Me.m_acct.Id, DBNull.Value))
            If Not cmbStatus.SelectedItem Is Nothing Then
                Dim item As IdValuePair = CType(cmbStatus.SelectedItem, IdValuePair)
                If item.Id = -1 Then
                    arr(8) = New Filter("status", DBNull.Value)
                Else
                    arr(8) = New Filter("status", item.Id)
                End If
            Else
                arr(8) = New Filter("status", DBNull.Value)
            End If
            If Not cmbType.SelectedItem Is Nothing Then
                Dim item As IdValuePair = CType(cmbType.SelectedItem, IdValuePair)
                If item.Id = -1 Then
                    arr(9) = New Filter("type", DBNull.Value)
                Else
                    arr(9) = New Filter("type", item.Id)
                End If
            Else
                arr(9) = New Filter("type", DBNull.Value)
            End If
            If Not cmbMode.SelectedItem Is Nothing Then
                If cmbMode.SelectedItem = 0 Then
                    arr(10) = New Filter("postmode", 0)
                ElseIf cmbMode.SelectedItem = 1 Then
                    arr(10) = New Filter("postmode", 1)
                End If
            End If
            arr(11) = New Filter("employee_id", IIf(Me.m_employee.Valid, Me.m_employee.Id, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtAccountCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Validated
            Account.GetAccount(txtAccountCode, txtAccountName, Me.m_acct)
        End Sub
        Private Sub txtCostCenterCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub txtEmployeeCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLastEditorCode.Validated
            Employee.GetEmployee(txtLastEditorCode, txtLastEditorName, Me.m_employee)
        End Sub
        Private Sub ibtnShowAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccount.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Account)
        End Sub
        Private Sub ibtnShowAccountDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccount)
        End Sub
        Private Sub ibtnShowEmployeeDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastEditorDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
        End Sub
        Private Sub SetAccount(ByVal e As ISimpleEntity)
            Me.txtAccountCode.Text = e.Code
            Account.GetAccount(txtAccountCode, txtAccountName, Me.m_acct)
        End Sub
        Private Sub SetEmployee(ByVal e As ISimpleEntity)
            Me.txtLastEditorCode.Text = e.Code
            Employee.GetEmployee(txtLastEditorCode, txtLastEditorName, Me.m_employee)
        End Sub
        Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
        End Sub
        Private Sub SetCostCenter(ByVal e As ISimpleEntity)
            Me.txtCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "Fixed Filters"

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            If Entities Is Nothing Then
                Return
            End If
            'For Each entity As Object In Entities

            'Next
        End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject

                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercode", "txtcostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Account).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountcode", "txtaccountname"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtlasteditorcode", "txtlasteditorname"
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
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtcostcentercode", "txtcostcentername"
                        Me.SetCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New Account).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
                Dim entity As New Account(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtaccountcode", "txtaccountname"
                        Me.SetAccount(entity)
                End Select
            End If
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtemployeecode", "txtemployeename"
                        Me.SetEmployee(entity)
                End Select
            End If
        End Sub
#End Region

    End Class
End Namespace

