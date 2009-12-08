Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class GLYearEndView
        Inherits AbstractEntityDetailPanelView
#Region "Members"
        Private m_entity As GLyearend
#End Region
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents btnCompile As System.Windows.Forms.Button
        Friend WithEvents grbSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtProfit As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalProfit As System.Windows.Forms.TextBox
        Friend WithEvents lblProfit As System.Windows.Forms.Label
        Friend WithEvents lblTotalProfit As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblBaht1 As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblGl As System.Windows.Forms.Label
        Friend WithEvents lblTotalGl As System.Windows.Forms.Label
        Friend WithEvents txtGl As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalGl As System.Windows.Forms.TextBox
        Friend WithEvents dtpYear As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblYear As System.Windows.Forms.Label
        Friend WithEvents ChkNewAccPeriod As System.Windows.Forms.CheckBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblName1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtProfit = New System.Windows.Forms.TextBox
            Me.txtTotalProfit = New System.Windows.Forms.TextBox
            Me.txtGl = New System.Windows.Forms.TextBox
            Me.txtTotalGl = New System.Windows.Forms.TextBox
            Me.btnCompile = New System.Windows.Forms.Button
            Me.grbSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblProfit = New System.Windows.Forms.Label
            Me.lblTotalProfit = New System.Windows.Forms.Label
            Me.lblBaht = New System.Windows.Forms.Label
            Me.lblBaht1 = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ChkNewAccPeriod = New System.Windows.Forms.CheckBox
            Me.dtpYear = New System.Windows.Forms.DateTimePicker
            Me.lblYear = New System.Windows.Forms.Label
            Me.lblGl = New System.Windows.Forms.Label
            Me.lblTotalGl = New System.Windows.Forms.Label
            Me.btnClose = New System.Windows.Forms.Button
            Me.btnSave = New System.Windows.Forms.Button
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.lblName1 = New System.Windows.Forms.Label
            Me.grbSum.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
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
            'txtProfit
            '
            Me.Validator.SetDataType(Me.txtProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProfit, "")
            Me.txtProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProfit, System.Drawing.Color.Empty)
            Me.txtProfit.Location = New System.Drawing.Point(144, 16)
            Me.Validator.SetMaxValue(Me.txtProfit, "")
            Me.Validator.SetMinValue(Me.txtProfit, "")
            Me.txtProfit.Name = "txtProfit"
            Me.Validator.SetRegularExpression(Me.txtProfit, "")
            Me.Validator.SetRequired(Me.txtProfit, False)
            Me.txtProfit.Size = New System.Drawing.Size(136, 21)
            Me.txtProfit.TabIndex = 182
            Me.txtProfit.TabStop = False
            Me.txtProfit.Text = ""
            '
            'txtTotalProfit
            '
            Me.Validator.SetDataType(Me.txtTotalProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalProfit, "")
            Me.txtTotalProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
            Me.txtTotalProfit.Location = New System.Drawing.Point(448, 16)
            Me.Validator.SetMaxValue(Me.txtTotalProfit, "")
            Me.Validator.SetMinValue(Me.txtTotalProfit, "")
            Me.txtTotalProfit.Name = "txtTotalProfit"
            Me.Validator.SetRegularExpression(Me.txtTotalProfit, "")
            Me.Validator.SetRequired(Me.txtTotalProfit, False)
            Me.txtTotalProfit.Size = New System.Drawing.Size(128, 21)
            Me.txtTotalProfit.TabIndex = 182
            Me.txtTotalProfit.TabStop = False
            Me.txtTotalProfit.Text = ""
            '
            'txtGl
            '
            Me.Validator.SetDataType(Me.txtGl, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGl, "")
            Me.txtGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGl, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGl, System.Drawing.Color.Empty)
            Me.txtGl.Location = New System.Drawing.Point(144, 40)
            Me.Validator.SetMaxValue(Me.txtGl, "")
            Me.Validator.SetMinValue(Me.txtGl, "")
            Me.txtGl.Name = "txtGl"
            Me.Validator.SetRegularExpression(Me.txtGl, "")
            Me.Validator.SetRequired(Me.txtGl, False)
            Me.txtGl.Size = New System.Drawing.Size(136, 21)
            Me.txtGl.TabIndex = 182
            Me.txtGl.TabStop = False
            Me.txtGl.Text = ""
            '
            'txtTotalGl
            '
            Me.Validator.SetDataType(Me.txtTotalGl, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalGl, "")
            Me.txtTotalGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalGl, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalGl, System.Drawing.Color.Empty)
            Me.txtTotalGl.Location = New System.Drawing.Point(440, 40)
            Me.Validator.SetMaxValue(Me.txtTotalGl, "")
            Me.Validator.SetMinValue(Me.txtTotalGl, "")
            Me.txtTotalGl.Name = "txtTotalGl"
            Me.Validator.SetRegularExpression(Me.txtTotalGl, "")
            Me.Validator.SetRequired(Me.txtTotalGl, False)
            Me.txtTotalGl.Size = New System.Drawing.Size(136, 21)
            Me.txtTotalGl.TabIndex = 182
            Me.txtTotalGl.TabStop = False
            Me.txtTotalGl.Text = ""
            '
            'btnCompile
            '
            Me.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCompile.Location = New System.Drawing.Point(160, 184)
            Me.btnCompile.Name = "btnCompile"
            Me.btnCompile.Size = New System.Drawing.Size(96, 23)
            Me.btnCompile.TabIndex = 213
            Me.btnCompile.Text = "ประมวลผล"
            '
            'grbSum
            '
            Me.grbSum.Controls.Add(Me.txtProfit)
            Me.grbSum.Controls.Add(Me.txtTotalProfit)
            Me.grbSum.Controls.Add(Me.lblProfit)
            Me.grbSum.Controls.Add(Me.lblTotalProfit)
            Me.grbSum.Controls.Add(Me.lblBaht)
            Me.grbSum.Controls.Add(Me.lblBaht1)
            Me.grbSum.Location = New System.Drawing.Point(8, 136)
            Me.grbSum.Name = "grbSum"
            Me.grbSum.Size = New System.Drawing.Size(656, 48)
            Me.grbSum.TabIndex = 210
            Me.grbSum.TabStop = False
            Me.grbSum.Text = "สรุปกำไรขาดทุนสิ้นปี"
            '
            'lblProfit
            '
            Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProfit.Location = New System.Drawing.Point(40, 16)
            Me.lblProfit.Name = "lblProfit"
            Me.lblProfit.Size = New System.Drawing.Size(104, 18)
            Me.lblProfit.TabIndex = 196
            Me.lblProfit.Text = "กำไร(ขาดทุน)สุทธิ:"
            Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalProfit
            '
            Me.lblTotalProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalProfit.Location = New System.Drawing.Point(344, 16)
            Me.lblTotalProfit.Name = "lblTotalProfit"
            Me.lblTotalProfit.Size = New System.Drawing.Size(96, 18)
            Me.lblTotalProfit.TabIndex = 196
            Me.lblTotalProfit.Text = "กำไร(ขาดทุน)สะสม"
            Me.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(288, 16)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht.TabIndex = 205
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBaht1
            '
            Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht1.Location = New System.Drawing.Point(576, 16)
            Me.lblBaht1.Name = "lblBaht1"
            Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht1.TabIndex = 205
            Me.lblBaht1.Text = "บาท"
            Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.ChkNewAccPeriod)
            Me.grbDetail.Controls.Add(Me.dtpYear)
            Me.grbDetail.Controls.Add(Me.lblYear)
            Me.grbDetail.Controls.Add(Me.lblGl)
            Me.grbDetail.Controls.Add(Me.lblTotalGl)
            Me.grbDetail.Controls.Add(Me.txtGl)
            Me.grbDetail.Controls.Add(Me.txtTotalGl)
            Me.grbDetail.Location = New System.Drawing.Point(8, 64)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(656, 72)
            Me.grbDetail.TabIndex = 211
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลการปิดงวดบัญชี"
            '
            'ChkNewAccPeriod
            '
            Me.ChkNewAccPeriod.BackColor = System.Drawing.Color.Transparent
            Me.ChkNewAccPeriod.Location = New System.Drawing.Point(336, 8)
            Me.ChkNewAccPeriod.Name = "ChkNewAccPeriod"
            Me.ChkNewAccPeriod.Size = New System.Drawing.Size(152, 24)
            Me.ChkNewAccPeriod.TabIndex = 197
            Me.ChkNewAccPeriod.Text = "กำหนดงวดปัญชีใหม่"
            '
            'dtpYear
            '
            Me.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpYear.Location = New System.Drawing.Point(144, 16)
            Me.dtpYear.Name = "dtpYear"
            Me.dtpYear.Size = New System.Drawing.Size(104, 20)
            Me.dtpYear.TabIndex = 195
            '
            'lblYear
            '
            Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYear.ForeColor = System.Drawing.Color.Black
            Me.lblYear.Location = New System.Drawing.Point(72, 16)
            Me.lblYear.Name = "lblYear"
            Me.lblYear.Size = New System.Drawing.Size(72, 18)
            Me.lblYear.TabIndex = 194
            Me.lblYear.Text = "ปิดสิ้นปี:"
            Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGl
            '
            Me.lblGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGl.Location = New System.Drawing.Point(8, 40)
            Me.lblGl.Name = "lblGl"
            Me.lblGl.Size = New System.Drawing.Size(136, 18)
            Me.lblGl.TabIndex = 196
            Me.lblGl.Text = "ผังบัญชีกำไร(ขาดทุน)สุทธิ:"
            Me.lblGl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalGl
            '
            Me.lblTotalGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalGl.Location = New System.Drawing.Point(304, 40)
            Me.lblTotalGl.Name = "lblTotalGl"
            Me.lblTotalGl.Size = New System.Drawing.Size(136, 18)
            Me.lblTotalGl.TabIndex = 196
            Me.lblTotalGl.Text = "ผังบัญชีกำไร(ขาดทุน)สะสม"
            Me.lblTotalGl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClose
            '
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnClose.Location = New System.Drawing.Point(368, 184)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(96, 23)
            Me.btnClose.TabIndex = 213
            Me.btnClose.Text = "ปิดบัญชี"
            '
            'btnSave
            '
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSave.Location = New System.Drawing.Point(264, 184)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(96, 23)
            Me.btnSave.TabIndex = 213
            Me.btnSave.Text = "บันทึกปิดสิ้นปี"
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.Location = New System.Drawing.Point(544, 184)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(56, 18)
            Me.lblStatus.TabIndex = 205
            Me.lblStatus.Text = "Status"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblName
            '
            Me.lblName.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblName.Font = New System.Drawing.Font("BrowalliaUPC", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.Location = New System.Drawing.Point(24, 8)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(464, 24)
            Me.lblName.TabIndex = 205
            Me.lblName.Text = "การปิดบัญชีสิ้นปีจะต้องทำการปิดงวดบัญชีทั้งหมดของปีก่อน"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblName1
            '
            Me.lblName1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblName1.Font = New System.Drawing.Font("BrowalliaUPC", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName1.Location = New System.Drawing.Point(24, 32)
            Me.lblName1.Name = "lblName1"
            Me.lblName1.Size = New System.Drawing.Size(464, 24)
            Me.lblName1.TabIndex = 205
            Me.lblName1.Text = "เมื่อปิดสิ้นปีแล้วจะไม่สามารถทำรายการใดในปีนั้นได้อีก"
            Me.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'GLYearEndView
            '
            Me.Controls.Add(Me.btnCompile)
            Me.Controls.Add(Me.grbSum)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.lblName1)
            Me.Name = "GLYearEndView"
            Me.Size = New System.Drawing.Size(672, 208)
            Me.grbSum.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.btnCompile.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.btnCompile}")
            Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.grbSum}")
            Me.lblProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblProfit}")
            Me.lblTotalProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblTotalProfit}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.grbDetail}")
            Me.lblGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblGl}")
            Me.lblTotalGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblTotalGl}")
            Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblYear}")
            Me.ChkNewAccPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.ChkNewAccPeriod}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblStatus}")
            Me.btnClose.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.btnClose}")
            Me.btnSave.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.btnSave}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblName}")
            Me.lblName1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLYearEndView.lblName1}")


        End Sub

        Private Sub txtStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub lblProfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProfit.Click

        End Sub
    End Class
End Namespace