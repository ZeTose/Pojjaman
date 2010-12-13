Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class WBSAdjustFilterSubPanel
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
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtAdjustPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustPersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblAdjustPerson As System.Windows.Forms.Label
    Friend WithEvents btnAdjustPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAdjustPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbAdjustDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtAdjustDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAdjustDateStart As System.Windows.Forms.Label
    Friend WithEvents lblAdjustDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAdjustDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBSAdjustFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbAdjustDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtAdjustDateStart = New System.Windows.Forms.TextBox()
      Me.txtAdjustDateEnd = New System.Windows.Forms.TextBox()
      Me.lblAdjustDateStart = New System.Windows.Forms.Label()
      Me.lblAdjustDateEnd = New System.Windows.Forms.Label()
      Me.dtpAdjustDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpAdjustDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblItemName = New System.Windows.Forms.Label()
      Me.txtReason = New System.Windows.Forms.TextBox()
      Me.txtItemName = New System.Windows.Forms.TextBox()
      Me.lblReason = New System.Windows.Forms.Label()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtAdjustPersonCode = New System.Windows.Forms.TextBox()
      Me.txtAdjustPersonName = New System.Windows.Forms.TextBox()
      Me.lblAdjustPerson = New System.Windows.Forms.Label()
      Me.btnAdjustPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAdjustPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbAdjustDate.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 0
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
      Me.txtCode.Location = New System.Drawing.Point(95, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(278, 21)
      Me.txtCode.TabIndex = 1
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbAdjustDate)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(664, 189)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbAdjustDate
      '
      Me.grbAdjustDate.Controls.Add(Me.txtAdjustDateStart)
      Me.grbAdjustDate.Controls.Add(Me.txtAdjustDateEnd)
      Me.grbAdjustDate.Controls.Add(Me.lblAdjustDateStart)
      Me.grbAdjustDate.Controls.Add(Me.lblAdjustDateEnd)
      Me.grbAdjustDate.Controls.Add(Me.dtpAdjustDateStart)
      Me.grbAdjustDate.Controls.Add(Me.dtpAdjustDateEnd)
      Me.grbAdjustDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbAdjustDate.Location = New System.Drawing.Point(399, 82)
      Me.grbAdjustDate.Name = "grbAdjustDate"
      Me.grbAdjustDate.Size = New System.Drawing.Size(257, 72)
      Me.grbAdjustDate.TabIndex = 3
      Me.grbAdjustDate.TabStop = False
      Me.grbAdjustDate.Text = "วันที่เอกสาร"
      '
      'txtAdjustDateStart
      '
      Me.txtAdjustDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAdjustDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtAdjustDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustDateStart, System.Drawing.Color.Empty)
      Me.txtAdjustDateStart.Location = New System.Drawing.Point(103, 14)
      Me.Validator.SetMinValue(Me.txtAdjustDateStart, "")
      Me.txtAdjustDateStart.Name = "txtAdjustDateStart"
      Me.Validator.SetRegularExpression(Me.txtAdjustDateStart, "")
      Me.Validator.SetRequired(Me.txtAdjustDateStart, False)
      Me.txtAdjustDateStart.Size = New System.Drawing.Size(114, 20)
      Me.txtAdjustDateStart.TabIndex = 1
      '
      'txtAdjustDateEnd
      '
      Me.txtAdjustDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAdjustDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtAdjustDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustDateEnd, System.Drawing.Color.Empty)
      Me.txtAdjustDateEnd.Location = New System.Drawing.Point(103, 40)
      Me.Validator.SetMinValue(Me.txtAdjustDateEnd, "")
      Me.txtAdjustDateEnd.Name = "txtAdjustDateEnd"
      Me.Validator.SetRegularExpression(Me.txtAdjustDateEnd, "")
      Me.Validator.SetRequired(Me.txtAdjustDateEnd, False)
      Me.txtAdjustDateEnd.Size = New System.Drawing.Size(114, 20)
      Me.txtAdjustDateEnd.TabIndex = 2
      '
      'lblAdjustDateStart
      '
      Me.lblAdjustDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdjustDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblAdjustDateStart.Location = New System.Drawing.Point(16, 15)
      Me.lblAdjustDateStart.Name = "lblAdjustDateStart"
      Me.lblAdjustDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAdjustDateStart.TabIndex = 8
      Me.lblAdjustDateStart.Text = "ตั้งแต่:"
      Me.lblAdjustDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdjustDateEnd
      '
      Me.lblAdjustDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdjustDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAdjustDateEnd.Location = New System.Drawing.Point(16, 39)
      Me.lblAdjustDateEnd.Name = "lblAdjustDateEnd"
      Me.lblAdjustDateEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblAdjustDateEnd.TabIndex = 9
      Me.lblAdjustDateEnd.Text = "ถึง:"
      Me.lblAdjustDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpAdjustDateStart
      '
      Me.dtpAdjustDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpAdjustDateStart.Location = New System.Drawing.Point(104, 14)
      Me.dtpAdjustDateStart.Name = "dtpAdjustDateStart"
      Me.dtpAdjustDateStart.Size = New System.Drawing.Size(137, 20)
      Me.dtpAdjustDateStart.TabIndex = 4
      Me.dtpAdjustDateStart.TabStop = False
      '
      'dtpAdjustDateEnd
      '
      Me.dtpAdjustDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpAdjustDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpAdjustDateEnd.Name = "dtpAdjustDateEnd"
      Me.dtpAdjustDateEnd.Size = New System.Drawing.Size(137, 20)
      Me.dtpAdjustDateEnd.TabIndex = 5
      Me.dtpAdjustDateEnd.TabStop = False
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
      Me.grbDocDate.Location = New System.Drawing.Point(399, 10)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(257, 70)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(112, 20)
      Me.txtDocDateStart.TabIndex = 1
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(112, 20)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(27, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(78, 18)
      Me.lblDocDateStart.TabIndex = 8
      Me.lblDocDateStart.Text = "ตั้งแต่:"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(27, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(78, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "ถึง:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 4
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 4
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(582, 159)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 1
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(501, 159)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.lblItemName)
      Me.grbMainDetail.Controls.Add(Me.txtReason)
      Me.grbMainDetail.Controls.Add(Me.txtItemName)
      Me.grbMainDetail.Controls.Add(Me.lblReason)
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtAdjustPersonCode)
      Me.grbMainDetail.Controls.Add(Me.txtAdjustPersonName)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblAdjustPerson)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnAdjustPersonPanel)
      Me.grbMainDetail.Controls.Add(Me.btnAdjustPersonDialog)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 10)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 144)
      Me.grbMainDetail.TabIndex = 1
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'lblItemName
      '
      Me.lblItemName.BackColor = System.Drawing.Color.Transparent
      Me.lblItemName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemName.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblItemName.Location = New System.Drawing.Point(7, 113)
      Me.lblItemName.Name = "lblItemName"
      Me.lblItemName.Size = New System.Drawing.Size(88, 18)
      Me.lblItemName.TabIndex = 208
      Me.lblItemName.Text = "รายการ:"
      Me.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtReason
      '
      Me.Validator.SetDataType(Me.txtReason, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReason, "")
      Me.txtReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtReason, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReason, System.Drawing.Color.Empty)
      Me.txtReason.Location = New System.Drawing.Point(95, 89)
      Me.Validator.SetMinValue(Me.txtReason, "")
      Me.txtReason.Name = "txtReason"
      Me.Validator.SetRegularExpression(Me.txtReason, "")
      Me.Validator.SetRequired(Me.txtReason, False)
      Me.txtReason.Size = New System.Drawing.Size(278, 21)
      Me.txtReason.TabIndex = 4
      '
      'txtItemName
      '
      Me.Validator.SetDataType(Me.txtItemName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.txtItemName.Location = New System.Drawing.Point(95, 113)
      Me.Validator.SetMinValue(Me.txtItemName, "")
      Me.txtItemName.Name = "txtItemName"
      Me.Validator.SetRegularExpression(Me.txtItemName, "")
      Me.Validator.SetRequired(Me.txtItemName, False)
      Me.txtItemName.Size = New System.Drawing.Size(278, 20)
      Me.txtItemName.TabIndex = 5
      '
      'lblReason
      '
      Me.lblReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReason.ForeColor = System.Drawing.Color.Black
      Me.lblReason.Location = New System.Drawing.Point(16, 89)
      Me.lblReason.Name = "lblReason"
      Me.lblReason.Size = New System.Drawing.Size(80, 18)
      Me.lblReason.TabIndex = 21
      Me.lblReason.Text = "เหตุผล:"
      Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(95, 64)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(230, 21)
      Me.cmbStatus.TabIndex = 3
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(16, 64)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(80, 18)
      Me.lblStatus.TabIndex = 12
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAdjustPersonCode
      '
      Me.Validator.SetDataType(Me.txtAdjustPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdjustPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustPersonCode, System.Drawing.Color.Empty)
      Me.txtAdjustPersonCode.Location = New System.Drawing.Point(95, 40)
      Me.Validator.SetMinValue(Me.txtAdjustPersonCode, "")
      Me.txtAdjustPersonCode.Name = "txtAdjustPersonCode"
      Me.Validator.SetRegularExpression(Me.txtAdjustPersonCode, "")
      Me.Validator.SetRequired(Me.txtAdjustPersonCode, False)
      Me.txtAdjustPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtAdjustPersonCode.TabIndex = 2
      '
      'txtAdjustPersonName
      '
      Me.Validator.SetDataType(Me.txtAdjustPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdjustPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustPersonName, System.Drawing.Color.Empty)
      Me.txtAdjustPersonName.Location = New System.Drawing.Point(175, 40)
      Me.Validator.SetMinValue(Me.txtAdjustPersonName, "")
      Me.txtAdjustPersonName.Name = "txtAdjustPersonName"
      Me.txtAdjustPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdjustPersonName, "")
      Me.Validator.SetRequired(Me.txtAdjustPersonName, False)
      Me.txtAdjustPersonName.Size = New System.Drawing.Size(150, 20)
      Me.txtAdjustPersonName.TabIndex = 4
      Me.txtAdjustPersonName.TabStop = False
      '
      'lblAdjustPerson
      '
      Me.lblAdjustPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblAdjustPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdjustPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAdjustPerson.Location = New System.Drawing.Point(16, 40)
      Me.lblAdjustPerson.Name = "lblAdjustPerson"
      Me.lblAdjustPerson.Size = New System.Drawing.Size(80, 24)
      Me.lblAdjustPerson.TabIndex = 2
      Me.lblAdjustPerson.Text = "ผู้ปรับปรุง:"
      Me.lblAdjustPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAdjustPersonPanel
      '
      Me.btnAdjustPersonPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdjustPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdjustPersonPanel.Location = New System.Drawing.Point(349, 40)
      Me.btnAdjustPersonPanel.Name = "btnAdjustPersonPanel"
      Me.btnAdjustPersonPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnAdjustPersonPanel.TabIndex = 6
      Me.btnAdjustPersonPanel.TabStop = False
      Me.btnAdjustPersonPanel.ThemedImage = CType(resources.GetObject("btnAdjustPersonPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAdjustPersonDialog
      '
      Me.btnAdjustPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdjustPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdjustPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdjustPersonDialog.Location = New System.Drawing.Point(325, 40)
      Me.btnAdjustPersonDialog.Name = "btnAdjustPersonDialog"
      Me.btnAdjustPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnAdjustPersonDialog.TabIndex = 5
      Me.btnAdjustPersonDialog.TabStop = False
      Me.btnAdjustPersonDialog.ThemedImage = CType(resources.GetObject("btnAdjustPersonDialog.ThemedImage"), System.Drawing.Bitmap)
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'WBSAdjustFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "WBSAdjustFilterSubPanel"
      Me.Size = New System.Drawing.Size(678, 199)
      Me.grbDetail.ResumeLayout(False)
      Me.grbAdjustDate.ResumeLayout(False)
      Me.grbAdjustDate.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
    'Private m_toccperson As Employee
    'Private m_tocc As CostCenter
    'Private m_lci As LCIItem
    'Private m_tool As Tool
    'Private m_supplier As Supplier
    'Private m_adjustPerson As Employee
    'Private docDateStart As Date
    'Private docDateEnd As Date
    'Private adjustDateStart As Date
    'Private adjustDateEnd As Date
    'Private receivingDateStart As Date
    'Private receivingDateEnd As Date
    'Private m_dummyCC As CostCenter
    'Private m_dummyLCI As LCIItem

    'Private m_asset As Asset
    'Private m_user As New User
#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtAdjustDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpAdjustDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtAdjustDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpAdjustDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtAdjustPersonCode.Validated, AddressOf Me.ChangeProperty

      PopulateStatus()
      ClearCriterias()
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtAdjustPersonCode".ToLower
          Employee.GetEmployee(txtAdjustPersonCode, txtAdjustPersonName, Me.AdjustPerson)
        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpadjustdatestart"
          If Not Me.AdjustDateStart.Equals(dtpAdjustDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtAdjustDateStart.Text = MinDateToNull(dtpAdjustDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.AdjustDateStart = dtpAdjustDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtadjustdatestart"
          m_dateSetting = True
          If Not Me.txtAdjustDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtAdjustDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtAdjustDateStart.Text)
            If Not Me.AdjustDateStart.Equals(theDate) Then
              dtpAdjustDateStart.Value = theDate
              Me.AdjustDateStart = dtpAdjustDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpAdjustDateStart.Value = Date.Now
            Me.AdjustDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpadjustdateend"
          If Not Me.AdjustDateEnd.Equals(dtpAdjustDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtAdjustDateEnd.Text = MinDateToNull(dtpAdjustDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.AdjustDateEnd = dtpAdjustDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtadjustdateend"
          m_dateSetting = True
          If Not Me.txtAdjustDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtAdjustDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtAdjustDateEnd.Text)
            If Not Me.AdjustDateEnd.Equals(theDate) Then
              dtpAdjustDateEnd.Value = theDate
              Me.AdjustDateEnd = dtpAdjustDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpAdjustDateEnd.Value = Date.Now
            Me.AdjustDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      'Me.m_asset = New Asset

      Me.txtCode.Text = ""
      'Me.m_tocc = New CostCenter

      Me.txtAdjustPersonCode.Text = ""
      Me.txtAdjustPersonName.Text = ""
      'Me.m_toccperson = New Employee

      'Me.m_supplier = New Supplier

      'Me.txtLCI.Text = ""
      'Me.txtLCIName.Text = ""
      'Me.m_lci = New LCIItem

      'Me.txtTool.Text = ""
      'Me.txtToolName.Text = ""
      'Me.m_tool = New Tool

      Me.txtItemName.Text = ""

      Dim grDocDateStartBeforeToday As Long = Configuration.GetConfig("GRDocDateStartBeforeToday")
      Dim grDocDateEndAfterToday As Long = Configuration.GetConfig("GRDocDateEndAfterToday")
      Dim grDueDateStartBeforeToday As Long = Configuration.GetConfig("GRDueDateStartBeforeToday")
      Dim grDueDateEndAfterToday As Long = Configuration.GetConfig("GRDueDateEndAfterToday")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date), "")

      Me.docDateStart = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.docDateEnd = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.dtpAdjustDateStart.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, grDueDateStartBeforeToday, Now.Date), "")
      Me.dtpAdjustDateEnd.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, grDueDateEndAfterToday, Now.Date), "")

      Me.txtAdjustDateStart.Text = ""
      Me.txtAdjustDateEnd.Text = ""

      Me.AdjustDateStart = Date.MinValue
      Me.AdjustDateEnd = Date.MinValue

      cmbStatus.SelectedIndex = 0

      Me.AdjustPerson = New Employee

      'Me.m_user = New User

      EntityRefresh()
    End Sub
    Private Sub PopulateStatus()
      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "wbsadj_status", True)

      'Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ''Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
      'Dim waitLVSApprove As String = Me.StringParserService.Parse("${res:Global.WaitForOtherLevelApprove}")
      'Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
      'Dim maxGRApproveLevel As Integer = CType(Configuration.GetConfig("MaxLevelApproveDO"), Integer)

      'Dim dt1 As DataTable

      'CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodsreceipt_status", True)
      'dt1 = CodeDescription.GetCodeList("reference_status")
      'For Each row As DataRow In dt1.Rows
      '  Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '  cmbStatus.Items.Add(item)
      'Next

      'dt1 = CodeDescription.GetCodeList("approve_status")
      'Dim itemApprove1 As IdValuePair = Nothing
      'Dim itemApprove2 As IdValuePair = Nothing
      'Dim itemApprove3 As IdValuePair = Nothing

      'For Each row As DataRow In dt1.Rows
      '  If Not row.IsNull("code_value") Then
      '    If CInt(row("code_value")) = 201 Then
      '      itemApprove1 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '    End If
      '    'If CInt(row("code_value")) = "202" Then
      '    '  itemApprove2 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '    'End If
      '    If CInt(row("code_value")) = 203 Then
      '      itemApprove3 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '    End If
      '  End If
      'Next

    End Sub
    Public Sub SetLabelText()
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.grbAdjustDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.grbAdjustDate}")
      Me.lblAdjustDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblAdjustDateStart}")
      Me.lblAdjustDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblAdjustPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblAdjustPerson}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblStatus}")
      Me.lblReason.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblReason}")
      'Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.grbItem}")
      'Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblLCI}")
      'Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblTool}")
      Me.lblItemName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.lblItemName}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustFilterSubPanel.grbMainDetail}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("adjustPerson", ValidIdOrDBNull(Me.AdjustPerson))
      arr(2) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(3) = New Filter("reason", IIf(Me.txtReason.Text.Length = 0, DBNull.Value, Me.txtReason.Text))
      arr(4) = New Filter("itemName", IIf(Me.txtItemName.Text.Length = 0, DBNull.Value, Me.txtItemName.Text))
      arr(5) = New Filter("docdatestart", ValidDateOrDBNull(DocDateStart))
      arr(6) = New Filter("docdateend", ValidDateOrDBNull(DocDateEnd))
      arr(7) = New Filter("adjustdatestart", ValidDateOrDBNull(AdjustDateStart))
      arr(8) = New Filter("adjustdateend", ValidDateOrDBNull(AdjustDateEnd))
      arr(9) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtToCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjustPersonCode.Validated
      Employee.GetEmployee(txtAdjustPersonCode, txtAdjustPersonName, Me.AdjustPerson)
    End Sub
    'Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(DummyLCI)
    'End Sub

    'Private Sub ibtnShowTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Tool)
    'End Sub
    'Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    'End Sub
    'Private Sub SetLCi(ByVal e As ISimpleEntity)
    '  Me.txtLCI.Text = e.Code
    '  LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    'End Sub
    'Private Sub txtTool_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    'End Sub
    'Private Sub SetTool(ByVal e As ISimpleEntity)
    '  Me.txtTool.Text = e.Code
    '  Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    'End Sub
    'Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
    'End Sub
    'Private Sub ibtnShowToolDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Tool, AddressOf SetTool)
    'End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    Private Sub btnToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
    End Sub
    Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
      Me.txtAdjustPersonCode.Text = e.Code
      Employee.GetEmployee(txtAdjustPersonCode, txtAdjustPersonName, Me.AdjustPerson)
    End Sub
    Private Sub btnToCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustPersonPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    'Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
    'End Sub
    'Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(DummyCC)
    'End Sub
    'Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    'End Sub
    Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    'Private Sub btnPVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVStartDialog)
    'End Sub
    'Private Sub btnPVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVEndDialog)
    'End Sub
    'Private Sub ibtnShowEquipmentDiaog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAsset)
    'End Sub
    Private Sub ibtnShowEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Asset)
    End Sub
#End Region

#Region "Properties"
    Public Property AdjustPerson As Employee
    Public Property DocDateStart As Date
    Public Property DocDateEnd As Date
    Public Property AdjustDateStart As Date
    Public Property AdjustDateEnd As Date
    Public Property Status As WBSAdjustStatus

    '    Public ReadOnly Property DummyCC() As CostCenter    '      Get    '        If m_dummyCC Is Nothing Then    '          m_dummyCC = New CostCenter
    '        End If    '        Return m_dummyCC    '      End Get    '    End Property
    '    Public ReadOnly Property DummyLCI() As LCIItem    '      Get    '        If m_dummyLCI Is Nothing Then    '          m_dummyLCI = New LCIItem
    '        End If    '        Return m_dummyLCI    '      End Get    '    End Property#End Region

#Region "IClipboardHandler Overrides"         'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        'If data.GetDataPresent((DummyCC).FullClassName) Then
        '  Select Case Me.ActiveControl.Name.ToLower
        '    Case "txttocostcentercode", "txttocostcentername"
        '      Return True
        '  End Select
        'End If
        'If data.GetDataPresent((New Employee).FullClassName) Then
        '  Select Case Me.ActiveControl.Name.ToLower
        '    Case "txttoccpersoncode", "txttoccpersonname"
        '      Return True
        '  End Select
        'End If
        'If data.GetDataPresent((DummyLCI).FullClassName) Then
        '  Select Case Me.ActiveControl.Name.ToLower
        '    Case "txtlci", "txtlciname"
        '      Return True
        '  End Select
        'End If
        'If data.GetDataPresent((New Tool).FullClassName) Then
        '  Select Case Me.ActiveControl.Name.ToLower
        '    Case "txttool", "txttoolname"
        '      Return True
        '  End Select
        'End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      'If data.GetDataPresent((DummyCC).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((DummyCC).FullClassName))
      '  Dim entity As New CostCenter(id)
      '  'Select Case Me.ActiveControl.Name.ToLower
      '  '  Case "txttocostcentercode", "txttocostcentername"
      '  '    Me.SetToCostCenter(entity)
      '  'End Select
      'End If
      'If data.GetDataPresent((New Employee).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
      '  Dim entity As New Employee(id)
      '  Select Case Me.ActiveControl.Name.ToLower
      '    Case "txttoccpersoncode", "txttoccpersonname"
      '      Me.SetToCCPerson(entity)
      '  End Select
      'End If
      'If data.GetDataPresent((DummyLCI).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((DummyLCI).FullClassName))
      '  Dim entity As New LCIItem(id)
      '  Select Case Me.ActiveControl.Name.ToLower
      '    Case "txtlci", "txtlciname"
      '      Me.SetLCi(entity)
      '  End Select
      'End If
      'If data.GetDataPresent((New Tool).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New Tool).FullClassName))
      '  Dim entity As New Tool(id)
      '  Select Case Me.ActiveControl.Name.ToLower
      '    Case "txttool", "txttoolname"
      '      Me.SetTool(entity)
      '  End Select
      'End If
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

        If TypeOf entity Is GoodsReceipt Then
          Dim obj As GoodsReceipt
          obj = CType(entity, GoodsReceipt)
          ' Supplier ...
          If obj.Supplier.Originated Then
            'Me.SetSupplier(obj.Supplier)
          End If
          If entity.Status.Value <> -1 Then
            CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
            Me.cmbStatus.Enabled = False
          End If
        End If
        If TypeOf entity Is Supplier Then
          'Me.SetSupplier(entity)
        End If
      Next
    End Sub

  End Class
End Namespace

