Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class PettyCashClaimFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblPVEnd As System.Windows.Forms.Label
        Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPVStart As System.Windows.Forms.Label
        Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnPettyCashFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPettyCashCode As System.Windows.Forms.TextBox
        Friend WithEvents lblPettyCash As System.Windows.Forms.Label
        Friend WithEvents txtPettyCashName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashClaimFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtPVCodeEnd = New System.Windows.Forms.TextBox
            Me.lblPVEnd = New System.Windows.Forms.Label
            Me.txtPVCodeStart = New System.Windows.Forms.TextBox
            Me.lblPVStart = New System.Windows.Forms.Label
            Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnPettyCashFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPettyCashCode = New System.Windows.Forms.TextBox
            Me.lblPettyCash = New System.Windows.Forms.Label
            Me.txtPettyCashName = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.grbGeneral)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(624, 128)
            Me.grbDetail.TabIndex = 9
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "มัดจำจ่าย"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(416, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(200, 72)
            Me.grbDocDate.TabIndex = 182
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(96, 20)
            Me.txtDocDateStart.TabIndex = 6
            Me.txtDocDateStart.Text = ""
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 20)
            Me.txtDocDateEnd.TabIndex = 7
            Me.txtDocDateEnd.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 8
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 39)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateEnd.TabIndex = 9
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateStart.TabIndex = 10
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateEnd.TabIndex = 11
            Me.dtpDocDateEnd.TabStop = False
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.txtPVCodeEnd)
            Me.grbGeneral.Controls.Add(Me.lblPVEnd)
            Me.grbGeneral.Controls.Add(Me.txtPVCodeStart)
            Me.grbGeneral.Controls.Add(Me.lblPVStart)
            Me.grbGeneral.Controls.Add(Me.btnPVStartFind)
            Me.grbGeneral.Controls.Add(Me.btnPVEndFind)
            Me.grbGeneral.Controls.Add(Me.btnPettyCashFind)
            Me.grbGeneral.Controls.Add(Me.txtPettyCashCode)
            Me.grbGeneral.Controls.Add(Me.lblPettyCash)
            Me.grbGeneral.Controls.Add(Me.txtPettyCashName)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(400, 96)
            Me.grbGeneral.TabIndex = 181
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "รายละเอียดทั่วไป"
            '
            'txtPVCodeEnd
            '
            Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
            Me.txtPVCodeEnd.Location = New System.Drawing.Point(266, 63)
            Me.Validator.SetMaxValue(Me.txtPVCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
            Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
            Me.txtPVCodeEnd.Size = New System.Drawing.Size(92, 21)
            Me.txtPVCodeEnd.TabIndex = 224
            Me.txtPVCodeEnd.Text = ""
            '
            'lblPVEnd
            '
            Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPVEnd.Location = New System.Drawing.Point(243, 63)
            Me.lblPVEnd.Name = "lblPVEnd"
            Me.lblPVEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPVEnd.TabIndex = 225
            Me.lblPVEnd.Text = "ถึง:"
            Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtPVCodeStart
            '
            Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
            Me.txtPVCodeStart.Location = New System.Drawing.Point(104, 63)
            Me.Validator.SetMaxValue(Me.txtPVCodeStart, "")
            Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
            Me.txtPVCodeStart.Name = "txtPVCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
            Me.Validator.SetRequired(Me.txtPVCodeStart, False)
            Me.txtPVCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPVCodeStart.TabIndex = 222
            Me.txtPVCodeStart.Text = ""
            '
            'lblPVStart
            '
            Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPVStart.ForeColor = System.Drawing.Color.Black
            Me.lblPVStart.Location = New System.Drawing.Point(8, 63)
            Me.lblPVStart.Name = "lblPVStart"
            Me.lblPVStart.Size = New System.Drawing.Size(94, 18)
            Me.lblPVStart.TabIndex = 223
            Me.lblPVStart.Text = "ตั้งแต่ใบสำคัญจ่าย:"
            Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPVStartFind
            '
            Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVStartFind.Image = CType(resources.GetObject("btnPVStartFind.Image"), System.Drawing.Image)
            Me.btnPVStartFind.Location = New System.Drawing.Point(200, 63)
            Me.btnPVStartFind.Name = "btnPVStartFind"
            Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVStartFind.TabIndex = 220
            Me.btnPVStartFind.TabStop = False
            Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnPVEndFind
            '
            Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPVEndFind.Image = CType(resources.GetObject("btnPVEndFind.Image"), System.Drawing.Image)
            Me.btnPVEndFind.Location = New System.Drawing.Point(360, 63)
            Me.btnPVEndFind.Name = "btnPVEndFind"
            Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPVEndFind.TabIndex = 221
            Me.btnPVEndFind.TabStop = False
            Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnPettyCashFind
            '
            Me.btnPettyCashFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPettyCashFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPettyCashFind.Image = CType(resources.GetObject("btnPettyCashFind.Image"), System.Drawing.Image)
            Me.btnPettyCashFind.Location = New System.Drawing.Point(360, 40)
            Me.btnPettyCashFind.Name = "btnPettyCashFind"
            Me.btnPettyCashFind.Size = New System.Drawing.Size(24, 23)
            Me.btnPettyCashFind.TabIndex = 192
            Me.btnPettyCashFind.TabStop = False
            Me.btnPettyCashFind.ThemedImage = CType(resources.GetObject("btnPettyCashFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPettyCashCode
            '
            Me.Validator.SetDataType(Me.txtPettyCashCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPettyCashCode, "")
            Me.txtPettyCashCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPettyCashCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPettyCashCode, System.Drawing.Color.Empty)
            Me.txtPettyCashCode.Location = New System.Drawing.Point(104, 40)
            Me.txtPettyCashCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtPettyCashCode, "")
            Me.Validator.SetMinValue(Me.txtPettyCashCode, "")
            Me.txtPettyCashCode.Name = "txtPettyCashCode"
            Me.Validator.SetRegularExpression(Me.txtPettyCashCode, "")
            Me.Validator.SetRequired(Me.txtPettyCashCode, False)
            Me.txtPettyCashCode.Size = New System.Drawing.Size(88, 21)
            Me.txtPettyCashCode.TabIndex = 188
            Me.txtPettyCashCode.Text = ""
            '
            'lblPettyCash
            '
            Me.lblPettyCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPettyCash.ForeColor = System.Drawing.Color.Black
            Me.lblPettyCash.Location = New System.Drawing.Point(16, 40)
            Me.lblPettyCash.Name = "lblPettyCash"
            Me.lblPettyCash.Size = New System.Drawing.Size(80, 18)
            Me.lblPettyCash.TabIndex = 181
            Me.lblPettyCash.Text = "เงินสดย่อย:"
            Me.lblPettyCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPettyCashName
            '
            Me.txtPettyCashName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtPettyCashName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPettyCashName, "")
            Me.txtPettyCashName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPettyCashName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPettyCashName, System.Drawing.Color.Empty)
            Me.txtPettyCashName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtPettyCashName, "")
            Me.Validator.SetMinValue(Me.txtPettyCashName, "")
            Me.txtPettyCashName.Name = "txtPettyCashName"
            Me.txtPettyCashName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtPettyCashName, "")
            Me.Validator.SetRequired(Me.txtPettyCashName, False)
            Me.txtPettyCashName.Size = New System.Drawing.Size(168, 21)
            Me.txtPettyCashName.TabIndex = 186
            Me.txtPettyCashName.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(152, 21)
            Me.txtCode.TabIndex = 7
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 13
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(528, 96)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(448, 96)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 7
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
            'PettyCashClaimFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "PettyCashClaimFilterSubPanel"
            Me.Size = New System.Drawing.Size(640, 144)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.grbDetail}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.grbGeneral}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.grbDocDate}")

            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblCode}")

            Me.lblPettyCash.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblPettyCash}")

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblDocDateEnd}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblPVStart}")
            Me.Validator.SetDisplayName(txtPVCodeStart, lblPVStart.Text)

            Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimFilterSubPanel.lblPVEnd}")
            Me.Validator.SetDisplayName(txtPVCodeEnd, lblPVEnd.Text)
        End Sub
#End Region

#Region "Member"
        Private m_pettycash As New PettyCash
        Private m_docdatestart As Date
        Private m_docdateend As Date
        Private m_status As PettyCashClaimStatus
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Private Property PettyCash() As PettyCash
            Get
                Return m_pettycash
            End Get
            Set(ByVal Value As PettyCash)
                m_pettycash = Value
            End Set
        End Property
        Private Property DocdateStart() As Date
            Get
                Return m_docdatestart
            End Get
            Set(ByVal Value As Date)
                m_docdatestart = Value
            End Set
        End Property
        Private Property DocdateEnd() As Date
            Get
                Return m_docdateend
            End Get
            Set(ByVal Value As Date)
                m_docdateend = Value
            End Set
        End Property
        Private Property Status() As CodeDescription
            Get
                Return m_status
            End Get
            Set(ByVal Value As CodeDescription)
                m_status = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            ClearCriterias()

        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.DocdateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocdateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocdateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocdateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.DocdateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocdateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocdateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocdateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            For Each ctrl As Control In grbGeneral.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.PettyCash = New PettyCash

            Me.dtpDocDateStart.Value = Now.Date
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = ""
            Me.txtDocDateEnd.Text = ""

            Me.DocdateStart = Date.MinValue
            Me.DocdateEnd = Date.MinValue

            EntityRefresh()
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim isclosed As Object
            Dim status As Object

            Dim arr(5) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.TextLength = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("pc_id", Me.ValidIdOrDBNull(Me.PettyCash))
            arr(2) = New Filter("docdatestart", Me.ValidDateOrDBNull(Me.DocdateStart))
            arr(3) = New Filter("docdateend", Me.ValidDateOrDBNull(Me.DocdateEnd))
            arr(4) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
            arr(5) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
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

#Region "TextBox Validated"
        Private Sub txtEmployeeCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPettyCashCode.Validated
            PettyCash.GetPettyCash(txtPettyCashCode, txtPettyCashName, Me.PettyCash)
        End Sub
#End Region

#Region "Event of Button Handlers"
        ' PettyCash
        Private Sub btnPettyCashFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPettyCashFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetPettyCash)
        End Sub
        Private Sub SetPettyCash(ByVal e As ISimpleEntity)
            Me.txtPettyCashCode.Text = e.Code
            PettyCash.GetPettyCash(txtPettyCashCode, txtPettyCashName, Me.PettyCash)
        End Sub
        Private Sub btnPVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVStartFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVStartDialog)
        End Sub
        Private Sub btnPVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVEndFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVEndDialog)
        End Sub
        Private Sub SetPVStartDialog(ByVal e As ISimpleEntity)
            Me.txtPVCodeStart.Text = e.Code
        End Sub
        Private Sub SetPVEndDialog(ByVal e As ISimpleEntity)
            Me.txtPVCodeEnd.Text = e.Code
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' PettyCash
                If data.GetDataPresent((New PettyCash).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtpettycashcode", "txtpettycashname"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New PettyCash).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New PettyCash).FullClassName))
                Dim entity As New PettyCash(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtpettycashcode", "txtpettycashname"
                            Me.SetPettyCash(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

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

            For Each entity As ISimpleEntity In Entities
                If TypeOf entity Is PettyCashClaim Then
                    Dim obj As PettyCashClaim = CType(entity, PettyCashClaim)
                    ' PettyCash
                    If obj.PettyCash.Originated Then
                        Me.SetPettyCash(obj.PettyCash)
                        Me.txtPettyCashCode.Enabled = False
                        Me.txtPettyCashName.Enabled = False
                        Me.btnPettyCashFind.Enabled = False
                    End If
                End If
                If TypeOf entity Is PettyCash Then
                    Me.SetPettyCash(CType(entity, PettyCash))
                    Me.txtPettyCashCode.Enabled = False
                    Me.txtPettyCashName.Enabled = False
                    Me.btnPettyCashFind.Enabled = False
                End If
            Next
        End Sub

    End Class
End Namespace

