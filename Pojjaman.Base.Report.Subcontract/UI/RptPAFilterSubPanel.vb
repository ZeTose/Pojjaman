Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPAFilterSubPanel
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
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblSubcontractorStart As System.Windows.Forms.Label
        Friend WithEvents lbltoCCStart As System.Windows.Forms.Label
        Friend WithEvents txttoCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btntoCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSubcontractStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuContractCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSubcontractEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuContractCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptPAFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txttoCCCodeStart = New System.Windows.Forms.TextBox()
            Me.cmbStatus = New System.Windows.Forms.ComboBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.lbltoCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btntoCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.btnSubcontractStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuContractCodeStart = New System.Windows.Forms.TextBox()
            Me.lblSubcontractorStart = New System.Windows.Forms.Label()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
            Me.btnSubcontractEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuContractCodeEnd = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.grbMaster.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.KeepKeyCombo1)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.grbMainDetail)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(452, 224)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ใบรับงาน"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(364, 192)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnReset.Location = New System.Drawing.Point(284, 192)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 2
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.Label1)
            Me.grbMainDetail.Controls.Add(Me.btnSubcontractEndFind)
            Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeEnd)
            Me.grbMainDetail.Controls.Add(Me.txttoCCCodeStart)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.lbltoCCStart)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbMainDetail.Controls.Add(Me.btntoCCCodeStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.btnSubcontractStartFind)
            Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeStart)
            Me.grbMainDetail.Controls.Add(Me.lblSubcontractorStart)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 24)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(431, 160)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'txttoCCCodeStart
            '
            Me.Validator.SetDataType(Me.txttoCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txttoCCCodeStart, "")
            Me.txttoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txttoCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
            Me.txttoCCCodeStart.Location = New System.Drawing.Point(128, 80)
            Me.txttoCCCodeStart.MaxLength = 50
            Me.Validator.SetMinValue(Me.txttoCCCodeStart, "")
            Me.txttoCCCodeStart.Name = "txttoCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txttoCCCodeStart, "")
            Me.Validator.SetRequired(Me.txttoCCCodeStart, False)
            Me.txttoCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txttoCCCodeStart.TabIndex = 7
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(128, 128)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(120, 21)
            Me.cmbStatus.TabIndex = 38
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(80, 128)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(40, 18)
            Me.lblStatus.TabIndex = 37
            Me.lblStatus.Text = "สถานะ"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblStatus.Visible = False
            '
            'lbltoCCStart
            '
            Me.lbltoCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lbltoCCStart.ForeColor = System.Drawing.Color.Black
            Me.lbltoCCStart.Location = New System.Drawing.Point(48, 80)
            Me.lbltoCCStart.Name = "lbltoCCStart"
            Me.lbltoCCStart.Size = New System.Drawing.Size(72, 18)
            Me.lbltoCCStart.TabIndex = 14
            Me.lbltoCCStart.Text = "Cost Center"
            Me.lbltoCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(224, 80)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(151, 21)
            Me.txtCostCenterName.TabIndex = 15
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 32)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(95, 21)
            Me.txtDocDateEnd.TabIndex = 2
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(64, 32)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(281, 32)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(124, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(256, 32)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(128, 32)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
            Me.txtDocDateStart.TabIndex = 1
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(128, 104)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 12
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btntoCCCodeStart
            '
            Me.btntoCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btntoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btntoCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btntoCCCodeStart.Location = New System.Drawing.Point(376, 78)
            Me.btntoCCCodeStart.Name = "btntoCCCodeStart"
            Me.btntoCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btntoCCCodeStart.TabIndex = 22
            Me.btntoCCCodeStart.TabStop = False
            Me.btntoCCCodeStart.ThemedImage = CType(resources.GetObject("btntoCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 32)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(125, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'btnSubcontractStartFind
            '
            Me.btnSubcontractStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSubcontractStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSubcontractStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSubcontractStartFind.Location = New System.Drawing.Point(225, 56)
            Me.btnSubcontractStartFind.Name = "btnSubcontractStartFind"
            Me.btnSubcontractStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSubcontractStartFind.TabIndex = 9
            Me.btnSubcontractStartFind.TabStop = False
            Me.btnSubcontractStartFind.ThemedImage = CType(resources.GetObject("btnSubcontractStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuContractCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuContractCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuContractCodeStart, "")
            Me.txtSuContractCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
            Me.txtSuContractCodeStart.Location = New System.Drawing.Point(128, 56)
            Me.Validator.SetMinValue(Me.txtSuContractCodeStart, "")
            Me.txtSuContractCodeStart.Name = "txtSuContractCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuContractCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuContractCodeStart, False)
            Me.txtSuContractCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSuContractCodeStart.TabIndex = 4
            '
            'lblSubcontractorStart
            '
            Me.lblSubcontractorStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubcontractorStart.ForeColor = System.Drawing.Color.Black
            Me.lblSubcontractorStart.Location = New System.Drawing.Point(48, 56)
            Me.lblSubcontractorStart.Name = "lblSubcontractorStart"
            Me.lblSubcontractorStart.Size = New System.Drawing.Size(72, 18)
            Me.lblSubcontractorStart.TabIndex = 19
            Me.lblSubcontractorStart.Text = "ผู้รับเหมา"
            Me.lblSubcontractorStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'KeepKeyCombo1
            '
            Me.KeepKeyCombo1.FormattingEnabled = True
            Me.KeepKeyCombo1.Location = New System.Drawing.Point(610, 150)
            Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
            Me.KeepKeyCombo1.Size = New System.Drawing.Size(121, 21)
            Me.KeepKeyCombo1.TabIndex = 4
            '
            'btnSubcontractEndFind
            '
            Me.btnSubcontractEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSubcontractEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSubcontractEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSubcontractEndFind.Location = New System.Drawing.Point(376, 56)
            Me.btnSubcontractEndFind.Name = "btnSubcontractEndFind"
            Me.btnSubcontractEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSubcontractEndFind.TabIndex = 40
            Me.btnSubcontractEndFind.TabStop = False
            Me.btnSubcontractEndFind.ThemedImage = CType(resources.GetObject("btnSubcontractEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuContractCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuContractCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuContractCodeEnd, "")
            Me.txtSuContractCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuContractCodeEnd.Location = New System.Drawing.Point(279, 56)
            Me.Validator.SetMinValue(Me.txtSuContractCodeEnd, "")
            Me.txtSuContractCodeEnd.Name = "txtSuContractCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuContractCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuContractCodeEnd, False)
            Me.txtSuContractCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuContractCodeEnd.TabIndex = 39
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(255, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(24, 18)
            Me.Label1.TabIndex = 42
            Me.Label1.Text = "ถึง"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'RptPAFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptPAFilterSubPanel"
            Me.Size = New System.Drawing.Size(476, 248)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbMainDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()

            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.grbMaster}") '"ใบรับงาน"
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.grbMainDetail}") '""
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.lblDocDateStart}") '"ตั้งแต่วันที่"
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblSubcontractorStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.lblSubcontractorStart}") '"ผู้รับเหมา"
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.chkIncludeChilPAen}") '"รวม Cost Center ลูก"
            Me.lblStatus.Text = StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.lblStatus}") '"สถานะ"

            'Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.grbItem}")
            'Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.lblFromCostCenter}") '"Cost Center ที่ให้เบิก"

            ''If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lbltoCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPAFilterSubPanel.lbltoCCStart}")
            Me.Validator.SetDisplayName(txttoCCCodeStart, lbltoCCStart.Text)

            Me.Validator.SetDisplayName(txtSuContractCodeStart, lblSubcontractorStart.Text)

            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            'Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCFilterSubPanel.lblEmployee}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")


        End Sub
#End Region

#Region "Member"
        Private m_cc As CostCenter
        'Private m_fromcc As CostCenter
        Private m_subcontractor As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        'Private m_DueDateEnd As Date
        'Private m_DueDateStart As Date
        Private m_subcontractorgroup As SupplierGroup
        Private m_frompersone As Employee
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
        'Public Property fromCostcenter() As CostCenter
        '    Get
        '        Return m_fromcc
        '    End Get
        '    Set(ByVal Value As CostCenter)
        '        m_fromcc = Value
        '    End Set
        'End Property
        Public Property Subcontractor() As Supplier
            Get
                Return m_subcontractor
            End Get
            Set(ByVal Value As Supplier)
                m_subcontractor = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        'Public Property DueDateEnd() As Date        '    Get        '        Return m_DocDateEnd        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateEnd = Value        '    End Set        'End Property        'Public Property DueDateStart() As Date        '    Get        '        Return m_DocDateStart        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateStart = Value        '    End Set        'End Property
        Public Property SubcontractorGroup() As SupplierGroup
            Get
                Return m_subcontractorgroup
            End Get
            Set(ByVal Value As SupplierGroup)
                m_subcontractorgroup = Value
            End Set
        End Property
        Public Property frompersone() As Employee
            Get
                Return m_frompersone
            End Get
            Set(ByVal Value As Employee)
                m_frompersone = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbStatus, "pa_status", True)
            cmbStatus.SelectedIndex = 0
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

            Me.Subcontractor = New Supplier
            Me.Costcenter = New CostCenter
            'Me.fromCostcenter = New CostCenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.SubcontractorGroup = New SupplierGroup
            Me.frompersone = New Employee
            If chkIncludeChildren.Checked Then
                chkIncludeChildren.Checked = False
            End If

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(7) As Filter
            arr(0) = New Filter("docdatestart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("docdateend", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("SubcontractorCodeStart", IIf(txtSuContractCodeStart.TextLength > 0, txtSuContractCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SubcontractorCodeEnd", IIf(txtSuContractCodeEnd.TextLength > 0, txtSuContractCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("CC", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("status", cmbStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

            'arr(8) = New Filter("SubcontractorGroupID", Me.ValidIdOrDBNull(m_subcontractorgroup))
            'arr(9) = New Filter("IncludeChildSubcontractorGroup", Me.chkIncludeChildSupplierGroup.Checked)
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

            'Subcontractor Code
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractorCode"
            dpi.Value = Me.txtSuContractCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Subcontractor Name
            'dpi = New DocPrintingItem
            'dpi.Mapping = "SubcontractorName"
            'dpi.Value = Me.txtSubcontractName.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'CostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterCode"
            dpi.Value = Me.txttoCCCodeStart.Text
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
            dpi.Value = Me.txttoCCCodeStart.Text & ":" & Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Include CCChildren
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludeCCChildren"
                dpi.Value = "(รวมในสังกัด)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'Status
            dpi = New DocPrintingItem
            dpi.Mapping = "Status"
            dpi.Value = Me.cmbStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)


            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSubcontractStartFind.Click, AddressOf Me.btnSubcontractStartFind_Click
            AddHandler txtSuContractCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnSubcontractEndFind.Click, AddressOf Me.btnSubcontractEndFind_Click
            AddHandler txtSuContractCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler btntoCCCodeStart.Click, AddressOf Me.btntoCCCodeStart_Click
            AddHandler txttoCCCodeStart.Validated, AddressOf Me.ChangeProperty

            'AddHandler btnfromCCCodeStart.Click, AddressOf Me.btnfromCCCodeStart_Click
            'AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            'AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txttocccodestart"
                    Costcenter.GetCostCenter(txttoCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                    'Case "txtemployee"
                    '    Employee.GetEmployee(txtEmployee, Me.txtEmployeeName, Director)
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
                ' Supplier
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
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
            ' Supplier
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                'If Not Me.ActiveControl Is Nothing Then
                '    Select Case Me.ActiveControl.Name.ToLower
                '        Case "txtsupplicodestart"
                '            Me.SetSupplierStartDialog(entity)

                '        Case "txtsupplicodeend"
                '            Me.SetSupplierEndDialog(entity)

                '    End Select
                'End If
            End If
            ' Costcenter
            'If data.GetDataPresent((New Costcenter).FullClassName) Then
            '    Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
            '    Dim entity As New Costcenter(id)
            '    If Not Me.ActiveControl Is Nothing Then
            '        Select Case Me.ActiveControl.Name.ToLower
            '            Case "txtcostcentercodestart"
            '                Me.SetCCCodeStartDialog(entity)

            '            Case "txtcostcentercodeend"
            '                Me.SetCCCodeStartDialog(entity)

            '        End Select
            '    End If
            'End If
        End Sub
#End Region

#Region " Event Handlers "
        ' Subcontractor
        Private Sub btnSubcontractStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsubcontractstartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSubcontractStartDialog)

            End Select
        End Sub
        Private Sub btnSubcontractEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsubcontractendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSubcontractEndDialog)

            End Select
        End Sub
        Private Sub SetSubcontractStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuContractCodeStart.Text = e.Code
            'Supplier.GetSupplier(txtSuContractCodeStart, txtSubcontractName, Me.Subcontractor)
        End Sub
        Private Sub SetSubcontractEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuContractCodeEnd.Text = e.Code
            'Supplier.GetSupplier(txtSuContractCodeStart, txtSubcontractName, Me.Subcontractor)
        End Sub
        'Private Sub btnSubcontractEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        'Case "btnsubcontractendfind"
        '        '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        '    Case "btnsubcontractendfind"
        '            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

        '    End Select
        'End Sub
        'Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
        '    Me.txtSuContractCodeEnd.Text = e.Code
        '    Supplier.GetSupplier(txtSuContractCodeEnd, txtTemp, Me.Subcontractor)
        'End Sub
        ' To Costcenter
        Private Sub btntoCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btntocccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetToCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txttoCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txttoCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' From Cost Center
        'Private Sub btnfromCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnfromcccodestart"
        '            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCCodeStartDialog)
        '    End Select
        'End Sub
        'Private Sub SetFromCCCodeStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtFromCostCenterCode.Text = e.Code
        '    CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        'End Sub
        ' From Persone
        'Private Sub btnfromCCPersoneStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnfromccpersonestart"
        '            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetfromCCPersoneStartDialog)

        '    End Select
        'End Sub
        'Private Sub SetfromCCPersoneStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtFromCCPersonCode.Text = e.Code
        '    Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.frompersone)
        'End Sub


#End Region

        Private Sub grbMainDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbMainDetail.Enter

        End Sub
    End Class
End Namespace

