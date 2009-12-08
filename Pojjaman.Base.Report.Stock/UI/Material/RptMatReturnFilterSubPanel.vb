Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptMatReturnFilterSubPanel
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
        Friend WithEvents btnFromCCend As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtFromCCend As System.Windows.Forms.TextBox
        Friend WithEvents lblFromCCend As System.Windows.Forms.Label
        Friend WithEvents btnFromCCstart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtFromCCstart As System.Windows.Forms.TextBox
        Friend WithEvents lblFromCCstart As System.Windows.Forms.Label
        Friend WithEvents btnToCCend As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToCCend As System.Windows.Forms.TextBox
        Friend WithEvents lblToCCend As System.Windows.Forms.Label
        Friend WithEvents btnToCCstart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToCCstart As System.Windows.Forms.TextBox
        Friend WithEvents lblToCCstart As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptMatReturnFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnToCCend = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCCend = New System.Windows.Forms.TextBox
            Me.lblToCCend = New System.Windows.Forms.Label
            Me.btnToCCstart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCCstart = New System.Windows.Forms.TextBox
            Me.lblToCCstart = New System.Windows.Forms.Label
            Me.btnFromCCend = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtFromCCend = New System.Windows.Forms.TextBox
            Me.lblFromCCend = New System.Windows.Forms.Label
            Me.btnFromCCstart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtFromCCstart = New System.Windows.Forms.TextBox
            Me.lblFromCCstart = New System.Windows.Forms.Label
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
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
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
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(488, 152)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnToCCend)
            Me.grbDetail.Controls.Add(Me.txtToCCend)
            Me.grbDetail.Controls.Add(Me.lblToCCend)
            Me.grbDetail.Controls.Add(Me.btnToCCstart)
            Me.grbDetail.Controls.Add(Me.txtToCCstart)
            Me.grbDetail.Controls.Add(Me.lblToCCstart)
            Me.grbDetail.Controls.Add(Me.btnFromCCend)
            Me.grbDetail.Controls.Add(Me.txtFromCCend)
            Me.grbDetail.Controls.Add(Me.lblFromCCend)
            Me.grbDetail.Controls.Add(Me.btnFromCCstart)
            Me.grbDetail.Controls.Add(Me.txtFromCCstart)
            Me.grbDetail.Controls.Add(Me.lblFromCCstart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(448, 96)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnToCCend
            '
            Me.btnToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCend.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCend.Image = CType(resources.GetObject("btnToCCend.Image"), System.Drawing.Image)
            Me.btnToCCend.Location = New System.Drawing.Point(408, 64)
            Me.btnToCCend.Name = "btnToCCend"
            Me.btnToCCend.Size = New System.Drawing.Size(24, 22)
            Me.btnToCCend.TabIndex = 19
            Me.btnToCCend.TabStop = False
            Me.btnToCCend.ThemedImage = CType(resources.GetObject("btnToCCend.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCCend
            '
            Me.Validator.SetDataType(Me.txtToCCend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCend, "")
            Me.txtToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtToCCend, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToCCend, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToCCend, System.Drawing.Color.Empty)
            Me.txtToCCend.Location = New System.Drawing.Point(312, 64)
            Me.Validator.SetMaxValue(Me.txtToCCend, "")
            Me.Validator.SetMinValue(Me.txtToCCend, "")
            Me.txtToCCend.Name = "txtToCCend"
            Me.Validator.SetRegularExpression(Me.txtToCCend, "")
            Me.Validator.SetRequired(Me.txtToCCend, False)
            Me.txtToCCend.Size = New System.Drawing.Size(96, 21)
            Me.txtToCCend.TabIndex = 18
            Me.txtToCCend.Text = ""
            '
            'lblToCCend
            '
            Me.lblToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCend.ForeColor = System.Drawing.Color.Black
            Me.lblToCCend.Location = New System.Drawing.Point(280, 64)
            Me.lblToCCend.Name = "lblToCCend"
            Me.lblToCCend.Size = New System.Drawing.Size(24, 18)
            Me.lblToCCend.TabIndex = 17
            Me.lblToCCend.Text = "ถึง"
            Me.lblToCCend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnToCCstart
            '
            Me.btnToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCstart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCstart.Image = CType(resources.GetObject("btnToCCstart.Image"), System.Drawing.Image)
            Me.btnToCCstart.Location = New System.Drawing.Point(248, 64)
            Me.btnToCCstart.Name = "btnToCCstart"
            Me.btnToCCstart.Size = New System.Drawing.Size(24, 22)
            Me.btnToCCstart.TabIndex = 16
            Me.btnToCCstart.TabStop = False
            Me.btnToCCstart.ThemedImage = CType(resources.GetObject("btnToCCstart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCCstart
            '
            Me.Validator.SetDataType(Me.txtToCCstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCstart, "")
            Me.txtToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtToCCstart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToCCstart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToCCstart, System.Drawing.Color.Empty)
            Me.txtToCCstart.Location = New System.Drawing.Point(152, 64)
            Me.Validator.SetMaxValue(Me.txtToCCstart, "")
            Me.Validator.SetMinValue(Me.txtToCCstart, "")
            Me.txtToCCstart.Name = "txtToCCstart"
            Me.Validator.SetRegularExpression(Me.txtToCCstart, "")
            Me.Validator.SetRequired(Me.txtToCCstart, False)
            Me.txtToCCstart.Size = New System.Drawing.Size(96, 21)
            Me.txtToCCstart.TabIndex = 15
            Me.txtToCCstart.Text = ""
            '
            'lblToCCstart
            '
            Me.lblToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCstart.ForeColor = System.Drawing.Color.Black
            Me.lblToCCstart.Location = New System.Drawing.Point(8, 64)
            Me.lblToCCstart.Name = "lblToCCstart"
            Me.lblToCCstart.Size = New System.Drawing.Size(136, 18)
            Me.lblToCCstart.TabIndex = 14
            Me.lblToCCstart.Text = "ตั้งแต่ Cost Center ขอเบิก"
            Me.lblToCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnFromCCend
            '
            Me.btnFromCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnFromCCend.ForeColor = System.Drawing.SystemColors.Control
            Me.btnFromCCend.Image = CType(resources.GetObject("btnFromCCend.Image"), System.Drawing.Image)
            Me.btnFromCCend.Location = New System.Drawing.Point(408, 40)
            Me.btnFromCCend.Name = "btnFromCCend"
            Me.btnFromCCend.Size = New System.Drawing.Size(24, 22)
            Me.btnFromCCend.TabIndex = 11
            Me.btnFromCCend.TabStop = False
            Me.btnFromCCend.ThemedImage = CType(resources.GetObject("btnFromCCend.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtFromCCend
            '
            Me.Validator.SetDataType(Me.txtFromCCend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCCend, "")
            Me.txtFromCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFromCCend, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtFromCCend, -15)
            Me.Validator.SetInvalidBackColor(Me.txtFromCCend, System.Drawing.Color.Empty)
            Me.txtFromCCend.Location = New System.Drawing.Point(312, 40)
            Me.Validator.SetMaxValue(Me.txtFromCCend, "")
            Me.Validator.SetMinValue(Me.txtFromCCend, "")
            Me.txtFromCCend.Name = "txtFromCCend"
            Me.Validator.SetRegularExpression(Me.txtFromCCend, "")
            Me.Validator.SetRequired(Me.txtFromCCend, False)
            Me.txtFromCCend.Size = New System.Drawing.Size(96, 21)
            Me.txtFromCCend.TabIndex = 10
            Me.txtFromCCend.Text = ""
            '
            'lblFromCCend
            '
            Me.lblFromCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCCend.ForeColor = System.Drawing.Color.Black
            Me.lblFromCCend.Location = New System.Drawing.Point(280, 40)
            Me.lblFromCCend.Name = "lblFromCCend"
            Me.lblFromCCend.Size = New System.Drawing.Size(24, 18)
            Me.lblFromCCend.TabIndex = 9
            Me.lblFromCCend.Text = "ถึง"
            Me.lblFromCCend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnFromCCstart
            '
            Me.btnFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnFromCCstart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnFromCCstart.Image = CType(resources.GetObject("btnFromCCstart.Image"), System.Drawing.Image)
            Me.btnFromCCstart.Location = New System.Drawing.Point(248, 40)
            Me.btnFromCCstart.Name = "btnFromCCstart"
            Me.btnFromCCstart.Size = New System.Drawing.Size(24, 22)
            Me.btnFromCCstart.TabIndex = 8
            Me.btnFromCCstart.TabStop = False
            Me.btnFromCCstart.ThemedImage = CType(resources.GetObject("btnFromCCstart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtFromCCstart
            '
            Me.Validator.SetDataType(Me.txtFromCCstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCCstart, "")
            Me.txtFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFromCCstart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtFromCCstart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtFromCCstart, System.Drawing.Color.Empty)
            Me.txtFromCCstart.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.txtFromCCstart, "")
            Me.Validator.SetMinValue(Me.txtFromCCstart, "")
            Me.txtFromCCstart.Name = "txtFromCCstart"
            Me.Validator.SetRegularExpression(Me.txtFromCCstart, "")
            Me.Validator.SetRequired(Me.txtFromCCstart, False)
            Me.txtFromCCstart.Size = New System.Drawing.Size(96, 21)
            Me.txtFromCCstart.TabIndex = 7
            Me.txtFromCCstart.Text = ""
            '
            'lblFromCCstart
            '
            Me.lblFromCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCCstart.ForeColor = System.Drawing.Color.Black
            Me.lblFromCCstart.Location = New System.Drawing.Point(8, 40)
            Me.lblFromCCstart.Name = "lblFromCCstart"
            Me.lblFromCCstart.Size = New System.Drawing.Size(136, 18)
            Me.lblFromCCstart.TabIndex = 6
            Me.lblFromCCstart.Text = "ตั้งแต่ Cost Center ให้เบิก"
            Me.lblFromCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(312, 16)
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
            Me.txtDocDateStart.Location = New System.Drawing.Point(152, 16)
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(152, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(312, 16)
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
            Me.lblDocDateStart.Size = New System.Drawing.Size(136, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(280, 16)
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
            Me.btnSearch.Location = New System.Drawing.Point(392, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(312, 120)
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
            'RptMatReturnFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptMatReturnFilterSubPanel"
            Me.Size = New System.Drawing.Size(512, 168)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatReturnFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblFromCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatReturnFilterSubPanel.lblFromCCstart}")
            Me.Validator.SetDisplayName(txtFromCCstart, lblFromCCstart.Text)

            Me.lblToCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatReturnFilterSubPanel.lblToCCstart}")
            Me.Validator.SetDisplayName(txtToCCstart, lblToCCstart.Text)

            ' Global {ถึง}
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblFromCCend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtFromCCend, lblFromCCend.Text)

            Me.lblToCCend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtToCCend, lblToCCend.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatReturnFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatReturnFilterSubPanel.grbDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
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

        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
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
            Dim arr(6) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("FromCCCodeStart", IIf(txtFromCCstart.TextLength > 0, txtFromCCstart.Text, DBNull.Value))
            arr(3) = New Filter("FromCCCodeEnd", IIf(txtFromCCend.TextLength > 0, txtFromCCend.Text, DBNull.Value))
            arr(4) = New Filter("ToCCCodeStart", IIf(txtToCCstart.TextLength > 0, txtToCCstart.Text, DBNull.Value))
            arr(5) = New Filter("ToCCCodeEnd", IIf(txtToCCend.TextLength > 0, txtToCCend.Text, DBNull.Value))
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

            'docudate start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docudate end
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateEnd"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'fromcc start
            dpi = New DocPrintingItem
            dpi.Mapping = "fromCCstart"
            dpi.Value = Me.txtFromCCstart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'fromcc end
            dpi = New DocPrintingItem
            dpi.Mapping = "fromCCend"
            dpi.Value = Me.txtFromCCend.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'tocc start
            dpi = New DocPrintingItem
            dpi.Mapping = "toCCstart"
            dpi.Value = Me.txtToCCstart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'tocc end
            dpi = New DocPrintingItem
            dpi.Mapping = "toCCend"
            dpi.Value = Me.txtToCCend.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'today
            dpi = New DocPrintingItem
            dpi.Mapping = "today"
            dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnFromCCstart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler btnFromCCend.Click, AddressOf Me.btnCostcenterFind_Click

            AddHandler btnToCCstart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler btnToCCend.Click, AddressOf Me.btnCostcenterFind_Click

            AddHandler txtFromCCstart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtFromCCend.Validated, AddressOf Me.ChangeProperty

            AddHandler txtToCCstart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtToCCend.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtfromccstart"
                    CostCenter.GetCostCenterWithoutRight(txtFromCCstart, tempTxt, tempCC1)
                Case "txtfromccend"
                    CostCenter.GetCostCenterWithoutRight(txtFromCCend, tempTxt, tempCC2)
                Case "txttoccstart"
                    CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC3, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txttoccend"
                    CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC4, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtfromccstart", "txtfromccend"
                                Return True
                            Case "txttoccstart", "txttoccend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtfromccstart"
                            Me.SetFromCCStartDialog(entity)

                        Case "txtfromccend"
                            Me.SetFromCCEndDialog(entity)

                        Case "txttoccstart"
                            Me.SetToCCStartDialog(entity)

                        Case "txttoccend"
                            Me.SetToCCEndDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnfromccstart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCStartDialog, New Filter() {New Filter("checkright", False)})

                Case "btnfromccend"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCEndDialog, New Filter() {New Filter("checkright", False)})

                Case "btntoccstart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCStartDialog)

                Case "btntoccend"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCEndDialog)

            End Select
        End Sub
        Private tempTxt As New TextBox
        Private tempCC1 As New CostCenter
        Private tempCC2 As New CostCenter
        Private tempCC3 As New CostCenter
        Private tempCC4 As New CostCenter
        Private Sub SetFromCCStartDialog(ByVal e As ISimpleEntity)
            Me.txtFromCCstart.Text = e.Code
            CostCenter.GetCostCenterWithoutRight(txtFromCCstart, tempTxt, tempCC1)
        End Sub
        Private Sub SetFromCCEndDialog(ByVal e As ISimpleEntity)
            Me.txtFromCCend.Text = e.Code
            CostCenter.GetCostCenterWithoutRight(txtFromCCend, tempTxt, tempCC2)
        End Sub
        Private Sub SetToCCStartDialog(ByVal e As ISimpleEntity)
            Me.txtToCCstart.Text = e.Code
            CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC3, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub SetToCCEndDialog(ByVal e As ISimpleEntity)
            Me.txtToCCend.Text = e.Code
            CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC4, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

    End Class

End Namespace

