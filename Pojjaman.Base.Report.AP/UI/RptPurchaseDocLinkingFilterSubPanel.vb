Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptPurchaseDocLinkingFilterSubPanel
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
    Friend WithEvents lblprDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtprDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtprDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpprDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpprDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocCode As System.Windows.Forms.TextBox
    Friend WithEvents txtgrDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtgrDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpgrDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpgrDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtpoDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtpoDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtppoDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtppoDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDocCode As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocCode = New System.Windows.Forms.TextBox()
      Me.lblDocCode = New System.Windows.Forms.Label()
      Me.txtprDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtprDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpprDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpprDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblprDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtpoDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtpoDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtppoDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtppoDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtgrDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtgrDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpgrDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpgrDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
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
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(540, 172)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtgrDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtgrDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpgrDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpgrDocDateEnd)
      Me.grbDetail.Controls.Add(Me.Label3)
      Me.grbDetail.Controls.Add(Me.Label4)
      Me.grbDetail.Controls.Add(Me.txtpoDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtpoDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtppoDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtppoDocDateEnd)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.txtDocCode)
      Me.grbDetail.Controls.Add(Me.lblDocCode)
      Me.grbDetail.Controls.Add(Me.txtprDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtprDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpprDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpprDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblprDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(511, 118)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'txtDocCode
      '
      Me.Validator.SetDataType(Me.txtDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocCode, "")
      Me.txtDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocCode, System.Drawing.Color.Empty)
      Me.txtDocCode.Location = New System.Drawing.Point(104, 88)
      Me.Validator.SetMinValue(Me.txtDocCode, "")
      Me.txtDocCode.Name = "txtDocCode"
      Me.Validator.SetRegularExpression(Me.txtDocCode, "")
      Me.Validator.SetRequired(Me.txtDocCode, False)
      Me.txtDocCode.Size = New System.Drawing.Size(280, 21)
      Me.txtDocCode.TabIndex = 7
      '
      'lblDocCode
      '
      Me.lblDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocCode.ForeColor = System.Drawing.Color.Black
      Me.lblDocCode.Location = New System.Drawing.Point(8, 88)
      Me.lblDocCode.Name = "lblDocCode"
      Me.lblDocCode.Size = New System.Drawing.Size(88, 18)
      Me.lblDocCode.TabIndex = 6
      Me.lblDocCode.Text = "เลขที่เอกสาร:"
      Me.lblDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtprDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtprDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtprDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtprDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtprDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtprDocDateEnd, System.Drawing.Color.Empty)
      Me.txtprDocDateEnd.Location = New System.Drawing.Point(264, 16)
      Me.txtprDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtprDocDateEnd, "")
      Me.txtprDocDateEnd.Name = "txtprDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtprDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtprDocDateEnd, False)
      Me.txtprDocDateEnd.Size = New System.Drawing.Size(92, 21)
      Me.txtprDocDateEnd.TabIndex = 4
      '
      'txtprDocDateStart
      '
      Me.Validator.SetDataType(Me.txtprDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtprDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtprDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtprDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtprDocDateStart, System.Drawing.Color.Empty)
      Me.txtprDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.txtprDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtprDocDateStart, "")
      Me.txtprDocDateStart.Name = "txtprDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtprDocDateStart, "")
      Me.Validator.SetRequired(Me.txtprDocDateStart, False)
      Me.txtprDocDateStart.Size = New System.Drawing.Size(92, 21)
      Me.txtprDocDateStart.TabIndex = 1
      '
      'dtpprDocDateStart
      '
      Me.dtpprDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpprDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpprDocDateStart.Name = "dtpprDocDateStart"
      Me.dtpprDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpprDocDateStart.TabIndex = 2
      Me.dtpprDocDateStart.TabStop = False
      '
      'dtpprDocDateEnd
      '
      Me.dtpprDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpprDocDateEnd.Location = New System.Drawing.Point(264, 16)
      Me.dtpprDocDateEnd.Name = "dtpprDocDateEnd"
      Me.dtpprDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpprDocDateEnd.TabIndex = 5
      Me.dtpprDocDateEnd.TabStop = False
      '
      'lblprDocDateStart
      '
      Me.lblprDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblprDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblprDocDateStart.Location = New System.Drawing.Point(8, 16)
      Me.lblprDocDateStart.Name = "lblprDocDateStart"
      Me.lblprDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblprDocDateStart.TabIndex = 0
      Me.lblprDocDateStart.Text = "ใบขอซื้อวันที่"
      Me.lblprDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(232, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(452, 140)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(372, 140)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
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
      'txtpoDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtpoDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtpoDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtpoDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtpoDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtpoDocDateEnd, System.Drawing.Color.Empty)
      Me.txtpoDocDateEnd.Location = New System.Drawing.Point(264, 40)
      Me.txtpoDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtpoDocDateEnd, "")
      Me.txtpoDocDateEnd.Name = "txtpoDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtpoDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtpoDocDateEnd, False)
      Me.txtpoDocDateEnd.Size = New System.Drawing.Size(92, 21)
      Me.txtpoDocDateEnd.TabIndex = 12
      '
      'txtpoDocDateStart
      '
      Me.Validator.SetDataType(Me.txtpoDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtpoDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtpoDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtpoDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtpoDocDateStart, System.Drawing.Color.Empty)
      Me.txtpoDocDateStart.Location = New System.Drawing.Point(104, 40)
      Me.txtpoDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtpoDocDateStart, "")
      Me.txtpoDocDateStart.Name = "txtpoDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtpoDocDateStart, "")
      Me.Validator.SetRequired(Me.txtpoDocDateStart, False)
      Me.txtpoDocDateStart.Size = New System.Drawing.Size(92, 21)
      Me.txtpoDocDateStart.TabIndex = 9
      '
      'dtppoDocDateStart
      '
      Me.dtppoDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtppoDocDateStart.Location = New System.Drawing.Point(104, 40)
      Me.dtppoDocDateStart.Name = "dtppoDocDateStart"
      Me.dtppoDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtppoDocDateStart.TabIndex = 10
      Me.dtppoDocDateStart.TabStop = False
      '
      'dtppoDocDateEnd
      '
      Me.dtppoDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtppoDocDateEnd.Location = New System.Drawing.Point(264, 40)
      Me.dtppoDocDateEnd.Name = "dtppoDocDateEnd"
      Me.dtppoDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtppoDocDateEnd.TabIndex = 13
      Me.dtppoDocDateEnd.TabStop = False
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(88, 18)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "ใบสั่งซื้อวันที่"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(232, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(24, 18)
      Me.Label2.TabIndex = 11
      Me.Label2.Text = "ถึง"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtgrDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtgrDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtgrDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtgrDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtgrDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtgrDocDateEnd, System.Drawing.Color.Empty)
      Me.txtgrDocDateEnd.Location = New System.Drawing.Point(264, 64)
      Me.txtgrDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtgrDocDateEnd, "")
      Me.txtgrDocDateEnd.Name = "txtgrDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtgrDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtgrDocDateEnd, False)
      Me.txtgrDocDateEnd.Size = New System.Drawing.Size(92, 21)
      Me.txtgrDocDateEnd.TabIndex = 18
      '
      'txtgrDocDateStart
      '
      Me.Validator.SetDataType(Me.txtgrDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtgrDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtgrDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtgrDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtgrDocDateStart, System.Drawing.Color.Empty)
      Me.txtgrDocDateStart.Location = New System.Drawing.Point(104, 64)
      Me.txtgrDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtgrDocDateStart, "")
      Me.txtgrDocDateStart.Name = "txtgrDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtgrDocDateStart, "")
      Me.Validator.SetRequired(Me.txtgrDocDateStart, False)
      Me.txtgrDocDateStart.Size = New System.Drawing.Size(92, 21)
      Me.txtgrDocDateStart.TabIndex = 15
      '
      'dtpgrDocDateStart
      '
      Me.dtpgrDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpgrDocDateStart.Location = New System.Drawing.Point(104, 64)
      Me.dtpgrDocDateStart.Name = "dtpgrDocDateStart"
      Me.dtpgrDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpgrDocDateStart.TabIndex = 16
      Me.dtpgrDocDateStart.TabStop = False
      '
      'dtpgrDocDateEnd
      '
      Me.dtpgrDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpgrDocDateEnd.Location = New System.Drawing.Point(264, 64)
      Me.dtpgrDocDateEnd.Name = "dtpgrDocDateEnd"
      Me.dtpgrDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpgrDocDateEnd.TabIndex = 19
      Me.dtpgrDocDateEnd.TabStop = False
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(8, 64)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(88, 18)
      Me.Label3.TabIndex = 14
      Me.Label3.Text = "ใบรับของวันที่"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(232, 64)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(24, 18)
      Me.Label4.TabIndex = 17
      Me.Label4.Text = "ถึง"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'RptPurchaseDocLinkingFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptPurchaseDocLinkingFilterSubPanel"
      Me.Size = New System.Drawing.Size(556, 193)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.lblDocCode}")
      Me.Validator.SetDisplayName(txtDocCode, lblDocCode.Text)

      Me.lblprDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtprDocDateStart, lblprDocDateStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtprDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.grbDetail}")

            Me.Label1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.Label1}")
            Me.Label3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPurchaseDocLinkingFilterSubPanel.Label3}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Label2.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Label4.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_poDocDateEnd As Date
    Private m_poDocDateStart As Date
    Private m_grDocDateEnd As Date
    Private m_grDocDateStart As Date
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value        If m_DocDateStart < m_poDocDateStart Then          m_poDocDateStart = m_DocDateStart
        End If        If m_DocDateStart < m_grDocDateStart Then          m_grDocDateStart = m_DocDateStart
        End If      End Set    End Property

    Public Property PoDocDateStart() As Date      Get        Return m_poDocDateStart      End Get      Set(ByVal Value As Date)        m_poDocDateStart = Value      End Set    End Property

    Public Property PoDocDateEnd() As Date      Get        Return m_poDocDateEnd      End Get      Set(ByVal Value As Date)        m_poDocDateEnd = Value      End Set    End Property

    Public Property GrDocDateStart() As Date      Get        Return m_grDocDateStart      End Get      Set(ByVal Value As Date)        m_grDocDateStart = Value      End Set    End Property

    Public Property GrDocDateEnd() As Date      Get        Return m_grDocDateEnd      End Get      Set(ByVal Value As Date)        m_grDocDateEnd = Value      End Set    End Property
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
      Me.PoDocDateStart = dtStart
      Me.GrDocDateStart = dtStart
      Me.txtprDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpprDocDateStart.Value = Me.DocDateStart

      Me.txtpoDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtppoDocDateStart.Value = Me.DocDateStart

      Me.txtgrDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpgrDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.PoDocDateEnd = Date.Now
      Me.GrDocDateEnd = Date.Now

      Me.txtprDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpprDocDateEnd.Value = Me.DocDateEnd

      Me.txtpoDocDateEnd.Text = MinDateToNull(Me.PoDocDateEnd, "")
      Me.dtppoDocDateEnd.Value = Me.PoDocDateEnd

      Me.txtgrDocDateEnd.Text = MinDateToNull(Me.GrDocDateEnd, "")
      Me.dtpgrDocDateEnd.Value = Me.GrDocDateEnd
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      arr(0) = New Filter("prDocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("prDocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("poDocDateStart", IIf(Me.PoDocDateStart.Equals(Date.MinValue), DBNull.Value, Me.PoDocDateStart))
      arr(3) = New Filter("poDocDateEnd", IIf(Me.PoDocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.PoDocDateEnd))
      arr(4) = New Filter("grDocDateStart", IIf(Me.GrDocDateStart.Equals(Date.MinValue), DBNull.Value, Me.GrDocDateStart))
      arr(5) = New Filter("grDocDateEnd", IIf(Me.GrDocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.GrDocDateEnd))
      arr(6) = New Filter("DocCode", IIf(txtDocCode.TextLength > 0, txtDocCode.Text, DBNull.Value))
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
      dpi.Value = Me.txtprDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtprDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocCodeStart
      dpi = New DocPrintingItem
      dpi.Mapping = "DocCodeStart"
      dpi.Value = Me.txtDocCode.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtprDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtprDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtpoDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtpoDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtgrDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtgrDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpprDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpprDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtppoDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtppoDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpgrDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpgrDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        'prdocdate
        Case "dtpprdocdatestart"
          If Not Me.DocDateStart.Equals(dtpprDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtprDocDateStart.Text = MinDateToNull(dtpprDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpprDocDateStart.Value
            End If
          End If
        Case "txtprdocdatestart"
          m_dateSetting = True
          If Not Me.txtprDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtprDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtprDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpprDocDateStart.Value = theDate
              Me.DocDateStart = dtpprDocDateStart.Value
            End If
          Else
            Me.dtpprDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpprdocdateend"
          If Not Me.DocDateEnd.Equals(dtpprDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtprDocDateEnd.Text = MinDateToNull(dtpprDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpprDocDateEnd.Value
            End If
          End If
        Case "txtprdocdateend"
          m_dateSetting = True
          If Not Me.txtprDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtprDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtprDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpprDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpprDocDateEnd.Value
            End If
          Else
            Me.dtpprDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
          'podocdate
        Case "dtppodocdatestart"
          If Not Me.PoDocDateStart.Equals(dtppoDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtpoDocDateStart.Text = MinDateToNull(dtppoDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.PoDocDateStart = dtppoDocDateStart.Value
            End If
          End If
        Case "txtpodocdatestart"
          m_dateSetting = True
          If Not Me.txtpoDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtpoDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtpoDocDateStart.Text)
            If Not Me.PoDocDateStart.Equals(theDate) Then
              dtppoDocDateStart.Value = theDate
              Me.PoDocDateStart = dtppoDocDateStart.Value
            End If
          Else
            Me.dtppoDocDateStart.Value = Date.Now
            Me.PoDocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtppodocdateend"
          If Not Me.PoDocDateEnd.Equals(dtppoDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtpoDocDateEnd.Text = MinDateToNull(dtppoDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.PoDocDateEnd = dtppoDocDateEnd.Value
            End If
          End If
        Case "txtpodocdateend"
          m_dateSetting = True
          If Not Me.txtpoDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtpoDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtpoDocDateEnd.Text)
            If Not Me.PoDocDateEnd.Equals(theDate) Then
              dtppoDocDateEnd.Value = theDate
              Me.PoDocDateEnd = dtppoDocDateEnd.Value
            End If
          Else
            Me.dtppoDocDateEnd.Value = Date.Now
            Me.PoDocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
          'grdocdate
        Case "dtpgrdocdatestart"
          If Not Me.GrDocDateStart.Equals(dtpgrDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtgrDocDateStart.Text = MinDateToNull(dtpgrDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.GrDocDateStart = dtpgrDocDateStart.Value
            End If
          End If
        Case "txtgrdocdatestart"
          m_dateSetting = True
          If Not Me.txtgrDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtgrDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtgrDocDateStart.Text)
            If Not Me.GrDocDateStart.Equals(theDate) Then
              dtpgrDocDateStart.Value = theDate
              Me.GrDocDateStart = dtpgrDocDateStart.Value
            End If
          Else
            Me.dtpgrDocDateStart.Value = Date.Now
            Me.GrDocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpgrdocdateend"
          If Not Me.GrDocDateEnd.Equals(dtpgrDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtgrDocDateEnd.Text = MinDateToNull(dtpgrDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.GrDocDateEnd = dtpgrDocDateEnd.Value
            End If
          End If
        Case "txtgrdocdateend"
          m_dateSetting = True
          If Not Me.txtgrDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtgrDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtgrDocDateEnd.Text)
            If Not Me.GrDocDateEnd.Equals(theDate) Then
              dtpgrDocDateEnd.Value = theDate
              Me.GrDocDateEnd = dtpgrDocDateEnd.Value
            End If
          Else
            Me.dtpgrDocDateEnd.Value = Date.Now
            Me.GrDocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Return False
      End Get
    End Property
#End Region

#Region " Event Handlers "
#End Region

  End Class
End Namespace

