Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAdvanceMoneyFilterSubPanel
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
    Friend WithEvents btnAdvmEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAdvmCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvmEnd As System.Windows.Forms.Label
    Friend WithEvents btnAdvmStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAdvmCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvmStart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmpStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEmpCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCustEnd As System.Windows.Forms.Label
    Friend WithEvents txtEmpCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCustStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptAdvanceMoneyFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.btnAdvmEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAdvmCodeEnd = New System.Windows.Forms.TextBox
      Me.lblAdvmEnd = New System.Windows.Forms.Label
      Me.btnAdvmStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAdvmCodeStart = New System.Windows.Forms.TextBox
      Me.lblAdvmStart = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.btnEmpEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnEmpStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmpCodeEnd = New System.Windows.Forms.TextBox
      Me.lblCustEnd = New System.Windows.Forms.Label
      Me.txtEmpCodeStart = New System.Windows.Forms.TextBox
      Me.lblCustStart = New System.Windows.Forms.Label
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
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(520, 168)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnEmpEndFind)
      Me.grbDetail.Controls.Add(Me.btnEmpStartFind)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCustEnd)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCustStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnAdvmEndFind)
      Me.grbDetail.Controls.Add(Me.txtAdvmCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAdvmEnd)
      Me.grbDetail.Controls.Add(Me.btnAdvmStartFind)
      Me.grbDetail.Controls.Add(Me.txtAdvmCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAdvmStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(488, 112)
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(328, 24)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateEnd.TabIndex = 1
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(168, 24)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(168, 24)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 27
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 24)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 29
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(64, 24)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 26
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(296, 24)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 28
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAdvmEndFind
      '
      Me.btnAdvmEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdvmEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdvmEndFind.Image = CType(resources.GetObject("btnAdvmEndFind.Image"), System.Drawing.Image)
      Me.btnAdvmEndFind.Location = New System.Drawing.Point(424, 48)
      Me.btnAdvmEndFind.Name = "btnAdvmEndFind"
      Me.btnAdvmEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAdvmEndFind.TabIndex = 17
      Me.btnAdvmEndFind.TabStop = False
      Me.btnAdvmEndFind.ThemedImage = CType(resources.GetObject("btnAdvmEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAdvmCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAdvmCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvmCodeEnd, "")
      Me.txtAdvmCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAdvmCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAdvmCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAdvmCodeEnd, System.Drawing.Color.Empty)
      Me.txtAdvmCodeEnd.Location = New System.Drawing.Point(328, 48)
      Me.Validator.SetMaxValue(Me.txtAdvmCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtAdvmCodeEnd, "")
      Me.txtAdvmCodeEnd.Name = "txtAdvmCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAdvmCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAdvmCodeEnd, False)
      Me.txtAdvmCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAdvmCodeEnd.TabIndex = 3
      Me.txtAdvmCodeEnd.Text = ""
      '
      'lblAdvmEnd
      '
      Me.lblAdvmEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvmEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAdvmEnd.Location = New System.Drawing.Point(296, 48)
      Me.lblAdvmEnd.Name = "lblAdvmEnd"
      Me.lblAdvmEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAdvmEnd.TabIndex = 15
      Me.lblAdvmEnd.Text = "ถึง"
      Me.lblAdvmEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAdvmStartFind
      '
      Me.btnAdvmStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdvmStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdvmStartFind.Image = CType(resources.GetObject("btnAdvmStartFind.Image"), System.Drawing.Image)
      Me.btnAdvmStartFind.Location = New System.Drawing.Point(264, 48)
      Me.btnAdvmStartFind.Name = "btnAdvmStartFind"
      Me.btnAdvmStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAdvmStartFind.TabIndex = 14
      Me.btnAdvmStartFind.TabStop = False
      Me.btnAdvmStartFind.ThemedImage = CType(resources.GetObject("btnAdvmStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAdvmCodeStart
      '
      Me.Validator.SetDataType(Me.txtAdvmCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvmCodeStart, "")
      Me.txtAdvmCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAdvmCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAdvmCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAdvmCodeStart, System.Drawing.Color.Empty)
      Me.txtAdvmCodeStart.Location = New System.Drawing.Point(168, 48)
      Me.Validator.SetMaxValue(Me.txtAdvmCodeStart, "")
      Me.Validator.SetMinValue(Me.txtAdvmCodeStart, "")
      Me.txtAdvmCodeStart.Name = "txtAdvmCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAdvmCodeStart, "")
      Me.Validator.SetRequired(Me.txtAdvmCodeStart, False)
      Me.txtAdvmCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAdvmCodeStart.TabIndex = 2
      Me.txtAdvmCodeStart.Text = ""
      '
      'lblAdvmStart
      '
      Me.lblAdvmStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvmStart.ForeColor = System.Drawing.Color.Black
      Me.lblAdvmStart.Location = New System.Drawing.Point(32, 48)
      Me.lblAdvmStart.Name = "lblAdvmStart"
      Me.lblAdvmStart.Size = New System.Drawing.Size(120, 18)
      Me.lblAdvmStart.TabIndex = 12
      Me.lblAdvmStart.Text = "รหัสเงินทดรองจ่าย"
      Me.lblAdvmStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(432, 136)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(352, 136)
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
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(532, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 4
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'btnEmpEndFind
      '
      Me.btnEmpEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpEndFind.Image = CType(resources.GetObject("btnEmpEndFind.Image"), System.Drawing.Image)
      Me.btnEmpEndFind.Location = New System.Drawing.Point(424, 72)
      Me.btnEmpEndFind.Name = "btnEmpEndFind"
      Me.btnEmpEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpEndFind.TabIndex = 35
      Me.btnEmpEndFind.TabStop = False
      Me.btnEmpEndFind.ThemedImage = CType(resources.GetObject("btnEmpEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEmpStartFind
      '
      Me.btnEmpStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpStartFind.Image = CType(resources.GetObject("btnEmpStartFind.Image"), System.Drawing.Image)
      Me.btnEmpStartFind.Location = New System.Drawing.Point(264, 72)
      Me.btnEmpStartFind.Name = "btnEmpStartFind"
      Me.btnEmpStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpStartFind.TabIndex = 34
      Me.btnEmpStartFind.TabStop = False
      Me.btnEmpStartFind.ThemedImage = CType(resources.GetObject("btnEmpStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmpCodeEnd
      '
      Me.Validator.SetDataType(Me.txtEmpCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.txtEmpCodeEnd.Location = New System.Drawing.Point(328, 72)
      Me.Validator.SetMaxValue(Me.txtEmpCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Name = "txtEmpCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeEnd, "")
      Me.Validator.SetRequired(Me.txtEmpCodeEnd, False)
      Me.txtEmpCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeEnd.TabIndex = 33
      Me.txtEmpCodeEnd.Text = ""
      '
      'lblCustEnd
      '
      Me.lblCustEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCustEnd.Location = New System.Drawing.Point(296, 72)
      Me.lblCustEnd.Name = "lblCustEnd"
      Me.lblCustEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCustEnd.TabIndex = 32
      Me.lblCustEnd.Text = "ถึง"
      Me.lblCustEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtEmpCodeStart
      '
      Me.Validator.SetDataType(Me.txtEmpCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.txtEmpCodeStart.Location = New System.Drawing.Point(168, 72)
      Me.Validator.SetMaxValue(Me.txtEmpCodeStart, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Name = "txtEmpCodeStart"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeStart, "")
      Me.Validator.SetRequired(Me.txtEmpCodeStart, False)
      Me.txtEmpCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeStart.TabIndex = 31
      Me.txtEmpCodeStart.Text = ""
      '
      'lblCustStart
      '
      Me.lblCustStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustStart.ForeColor = System.Drawing.Color.Black
      Me.lblCustStart.Location = New System.Drawing.Point(72, 72)
      Me.lblCustStart.Name = "lblCustStart"
      Me.lblCustStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCustStart.TabIndex = 30
      Me.lblCustStart.Text = "ตั้งแต่พนักงาน:"
      Me.lblCustStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptAdvanceMoneyFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAdvanceMoneyFilterSubPanel"
      Me.Size = New System.Drawing.Size(536, 192)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblAdvmStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.lblAdvmStart}")
      Me.Validator.SetDisplayName(txtAdvmCodeStart, lblAdvmStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Global {ถึง}
      Me.lblAdvmEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAdvmCodeStart, lblAdvmStart.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAdvanceMoneyFilterSubPanel.grbDetail}")

    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_advm As AdvanceMoney
    Private m_EmployeeStart As Employee
    Private m_EmployeeEnd As Employee
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property AdvanceMoney() As AdvanceMoney
      Get
        Return m_advm
      End Get
      Set(ByVal Value As AdvanceMoney)
        m_advm = Value
      End Set
    End Property
    Public Property EmployeeStart() As Employee
      Get
        Return m_EmployeeStart
      End Get
      Set(ByVal Value As Employee)
        m_EmployeeStart = Value
      End Set
    End Property
    Public Property EmployeeEnd() As Employee
      Get
        Return m_EmployeeEnd
      End Get
      Set(ByVal Value As Employee)
        m_EmployeeEnd = Value
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

      Me.AdvanceMoney = New AdvanceMoney
      Me.EmployeeStart = New Employee
      Me.EmployeeEnd = New Employee
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
      Dim arr(5) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("AdvmCodeStart", IIf(txtAdvmCodeStart.TextLength > 0, txtAdvmCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("AdvmCodeEnd", IIf(txtAdvmCodeEnd.TextLength > 0, txtAdvmCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("EmpCodeStart", IIf(txtEmpCodeStart.TextLength > 0, txtEmpCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("EmpCodeEnd", IIf(txtEmpCodeEnd.TextLength > 0, txtEmpCodeEnd.Text, DBNull.Value))

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

      'AdvanceMoneyStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceMoneyStart"
      dpi.Value = Me.txtAdvmCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AdvanceMoneyEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceMoneyEnd"
      dpi.Value = Me.txtAdvmCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocdateStart
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocdateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
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

      AddHandler btnAdvmStartFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnAdvmEndFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnEmpStartFind.Click, AddressOf Me.btnAdvmFind_Click
      AddHandler btnEmpEndFind.Click, AddressOf Me.btnAdvmFind_Click

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
        ' AdvanceMoney
        If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtadvmcodestart", "txtadvmcodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' AdvanceMoney
      If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AdvanceMoney).FullClassName))
        Dim entity As New AdvanceMoney(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtadvmcodestart"
              Me.SetAdvanceMoneyStartDialog(entity)

            Case "txtadvmcodeend"
              Me.SetAdvanceMoneyEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'AdvanceMoney
    Private Sub btnAdvmFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnadvmstartfind"
          myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetAdvanceMoneyStartDialog)
        Case "btnadvmendfind"
          myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetAdvanceMoneyEndDialog)
        Case "btnempstartfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpStartDialog)
        Case "btnempendfind"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmpEndDialog)

      End Select
    End Sub
    Private Sub SetAdvanceMoneyStartDialog(ByVal e As ISimpleEntity)
      Me.txtAdvmCodeStart.Text = CType(e, AdvanceMoney).Code
    End Sub
    Private Sub SetAdvanceMoneyEndDialog(ByVal e As ISimpleEntity)
      Me.txtAdvmCodeEnd.Text = CType(e, AdvanceMoney).Code
    End Sub
    Private Sub SetEmpStartDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeStart.Text = e.Code
      Employee.GetEmployee(Me.txtEmpCodeStart, txtTemp, Me.EmployeeStart)
    End Sub
    Private Sub SetEmpEndDialog(ByVal e As ISimpleEntity)
      Me.txtEmpCodeEnd.Text = e.Code
      Employee.GetEmployee(Me.txtEmpCodeEnd, txtTemp, Me.EmployeeEnd)
    End Sub
#End Region

  End Class

End Namespace

