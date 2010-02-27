Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PRFilterSubPanel
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
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivingDateStart As System.Windows.Forms.Label
    Friend WithEvents lblReceivingDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpReceivingDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReceivingDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents grbReceivingDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnRequestorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnRequestorPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblLCI As System.Windows.Forms.Label
    Friend WithEvents txtLCI As System.Windows.Forms.TextBox
    Friend WithEvents txtLCIName As System.Windows.Forms.TextBox
    Friend WithEvents txtToolName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowTool As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblTool As System.Windows.Forms.Label
    Friend WithEvents ibtnShowToolDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTool As System.Windows.Forms.TextBox
    Friend WithEvents lblBlank As System.Windows.Forms.Label
    Friend WithEvents txtBlank As System.Windows.Forms.TextBox
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivingdateEnd As System.Windows.Forms.TextBox
    Friend WithEvents grbApprove As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbApproveLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproveLevel As System.Windows.Forms.Label
    Friend WithEvents txtApprovePerson As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovePersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovePerson As System.Windows.Forms.Label
    Friend WithEvents btnFineApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtReceivingDateStart As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbReceivingDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtReceivingdateEnd = New System.Windows.Forms.TextBox()
      Me.txtReceivingDateStart = New System.Windows.Forms.TextBox()
      Me.lblReceivingDateStart = New System.Windows.Forms.Label()
      Me.lblReceivingDateEnd = New System.Windows.Forms.Label()
      Me.dtpReceivingDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpReceivingDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBlank = New System.Windows.Forms.Label()
      Me.txtBlank = New System.Windows.Forms.TextBox()
      Me.ibtnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblLCI = New System.Windows.Forms.Label()
      Me.txtLCI = New System.Windows.Forms.TextBox()
      Me.txtLCIName = New System.Windows.Forms.TextBox()
      Me.txtToolName = New System.Windows.Forms.TextBox()
      Me.ibtnShowTool = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTool = New System.Windows.Forms.Label()
      Me.ibtnShowToolDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtTool = New System.Windows.Forms.TextBox()
      Me.grbApprove = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbApproveLevel = New System.Windows.Forms.ComboBox()
      Me.lblApproveLevel = New System.Windows.Forms.Label()
      Me.txtApprovePerson = New System.Windows.Forms.TextBox()
      Me.txtApprovePersonName = New System.Windows.Forms.TextBox()
      Me.lblApprovePerson = New System.Windows.Forms.Label()
      Me.btnFineApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtRequestorCode = New System.Windows.Forms.TextBox()
      Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtRequestorName = New System.Windows.Forms.TextBox()
      Me.lblRequestor = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnRequestorPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCC = New System.Windows.Forms.Label()
      Me.btnRequestorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.grbDetail.SuspendLayout()
      Me.grbReceivingDate.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.grbApprove.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 4
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
      Me.txtCode.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(271, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbReceivingDate)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbItem)
      Me.grbDetail.Controls.Add(Me.grbApprove)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(7, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(662, 304)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbReceivingDate
      '
      Me.grbReceivingDate.Controls.Add(Me.txtReceivingdateEnd)
      Me.grbReceivingDate.Controls.Add(Me.txtReceivingDateStart)
      Me.grbReceivingDate.Controls.Add(Me.lblReceivingDateStart)
      Me.grbReceivingDate.Controls.Add(Me.lblReceivingDateEnd)
      Me.grbReceivingDate.Controls.Add(Me.dtpReceivingDateStart)
      Me.grbReceivingDate.Controls.Add(Me.dtpReceivingDateEnd)
      Me.grbReceivingDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbReceivingDate.Location = New System.Drawing.Point(399, 85)
      Me.grbReceivingDate.Name = "grbReceivingDate"
      Me.grbReceivingDate.Size = New System.Drawing.Size(254, 68)
      Me.grbReceivingDate.TabIndex = 4
      Me.grbReceivingDate.TabStop = False
      Me.grbReceivingDate.Text = "วันที่ต้องการรับของ"
      '
      'txtReceivingdateEnd
      '
      Me.txtReceivingdateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceivingdateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtReceivingdateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivingdateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReceivingdateEnd, System.Drawing.Color.Empty)
      Me.txtReceivingdateEnd.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMinValue(Me.txtReceivingdateEnd, "")
      Me.txtReceivingdateEnd.Name = "txtReceivingdateEnd"
      Me.Validator.SetRegularExpression(Me.txtReceivingdateEnd, "")
      Me.Validator.SetRequired(Me.txtReceivingdateEnd, False)
      Me.txtReceivingdateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtReceivingdateEnd.TabIndex = 2
      '
      'txtReceivingDateStart
      '
      Me.txtReceivingDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceivingDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtReceivingDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
      Me.txtReceivingDateStart.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtReceivingDateStart, "")
      Me.txtReceivingDateStart.Name = "txtReceivingDateStart"
      Me.Validator.SetRegularExpression(Me.txtReceivingDateStart, "")
      Me.Validator.SetRequired(Me.txtReceivingDateStart, False)
      Me.txtReceivingDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtReceivingDateStart.TabIndex = 1
      '
      'lblReceivingDateStart
      '
      Me.lblReceivingDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceivingDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblReceivingDateStart.Location = New System.Drawing.Point(16, 17)
      Me.lblReceivingDateStart.Name = "lblReceivingDateStart"
      Me.lblReceivingDateStart.Size = New System.Drawing.Size(80, 18)
      Me.lblReceivingDateStart.TabIndex = 2
      Me.lblReceivingDateStart.Text = "ตั้งแต่"
      Me.lblReceivingDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblReceivingDateEnd
      '
      Me.lblReceivingDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceivingDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblReceivingDateEnd.Location = New System.Drawing.Point(16, 41)
      Me.lblReceivingDateEnd.Name = "lblReceivingDateEnd"
      Me.lblReceivingDateEnd.Size = New System.Drawing.Size(80, 18)
      Me.lblReceivingDateEnd.TabIndex = 3
      Me.lblReceivingDateEnd.Text = "ถึง"
      Me.lblReceivingDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpReceivingDateStart
      '
      Me.dtpReceivingDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpReceivingDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpReceivingDateStart.Name = "dtpReceivingDateStart"
      Me.dtpReceivingDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpReceivingDateStart.TabIndex = 4
      '
      'dtpReceivingDateEnd
      '
      Me.dtpReceivingDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpReceivingDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpReceivingDateEnd.Name = "dtpReceivingDateEnd"
      Me.dtpReceivingDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpReceivingDateEnd.TabIndex = 5
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
      Me.grbDocDate.Location = New System.Drawing.Point(399, 16)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(254, 68)
      Me.grbDocDate.TabIndex = 3
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
      Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
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
      Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 2
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(16, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 4
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(582, 272)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(501, 272)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.lblBlank)
      Me.grbItem.Controls.Add(Me.txtBlank)
      Me.grbItem.Controls.Add(Me.ibtnShowLCIDialog)
      Me.grbItem.Controls.Add(Me.ibtnShowLCI)
      Me.grbItem.Controls.Add(Me.lblLCI)
      Me.grbItem.Controls.Add(Me.txtLCI)
      Me.grbItem.Controls.Add(Me.txtLCIName)
      Me.grbItem.Controls.Add(Me.txtToolName)
      Me.grbItem.Controls.Add(Me.ibtnShowTool)
      Me.grbItem.Controls.Add(Me.lblTool)
      Me.grbItem.Controls.Add(Me.ibtnShowToolDialog)
      Me.grbItem.Controls.Add(Me.txtTool)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(8, 134)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(385, 93)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "สิ่งที่ซื้อ"
      '
      'lblBlank
      '
      Me.lblBlank.BackColor = System.Drawing.Color.Transparent
      Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBlank.Location = New System.Drawing.Point(25, 64)
      Me.lblBlank.Name = "lblBlank"
      Me.lblBlank.Size = New System.Drawing.Size(78, 18)
      Me.lblBlank.TabIndex = 5
      Me.lblBlank.Text = "Blank:"
      Me.lblBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBlank
      '
      Me.Validator.SetDataType(Me.txtBlank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBlank, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.txtBlank.Location = New System.Drawing.Point(104, 64)
      Me.Validator.SetMinValue(Me.txtBlank, "")
      Me.txtBlank.Name = "txtBlank"
      Me.Validator.SetRegularExpression(Me.txtBlank, "")
      Me.Validator.SetRequired(Me.txtBlank, False)
      Me.txtBlank.Size = New System.Drawing.Size(272, 20)
      Me.txtBlank.TabIndex = 6
      '
      'ibtnShowLCIDialog
      '
      Me.ibtnShowLCIDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowLCIDialog.Name = "ibtnShowLCIDialog"
      Me.ibtnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCIDialog.TabIndex = 8
      Me.ibtnShowLCIDialog.TabStop = False
      Me.ibtnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibtnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowLCI
      '
      Me.ibtnShowLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCI.Location = New System.Drawing.Point(352, 16)
      Me.ibtnShowLCI.Name = "ibtnShowLCI"
      Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCI.TabIndex = 10
      Me.ibtnShowLCI.TabStop = False
      Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblLCI
      '
      Me.lblLCI.BackColor = System.Drawing.Color.Transparent
      Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLCI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblLCI.Location = New System.Drawing.Point(25, 16)
      Me.lblLCI.Name = "lblLCI"
      Me.lblLCI.Size = New System.Drawing.Size(78, 18)
      Me.lblLCI.TabIndex = 3
      Me.lblLCI.Text = "LCI:"
      Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLCI
      '
      Me.Validator.SetDataType(Me.txtLCI, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCI, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.txtLCI.Location = New System.Drawing.Point(103, 16)
      Me.Validator.SetMinValue(Me.txtLCI, "")
      Me.txtLCI.Name = "txtLCI"
      Me.Validator.SetRegularExpression(Me.txtLCI, "")
      Me.Validator.SetRequired(Me.txtLCI, False)
      Me.txtLCI.Size = New System.Drawing.Size(80, 20)
      Me.txtLCI.TabIndex = 4
      '
      'txtLCIName
      '
      Me.Validator.SetDataType(Me.txtLCIName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCIName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.txtLCIName.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMinValue(Me.txtLCIName, "")
      Me.txtLCIName.Name = "txtLCIName"
      Me.txtLCIName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLCIName, "")
      Me.Validator.SetRequired(Me.txtLCIName, False)
      Me.txtLCIName.Size = New System.Drawing.Size(144, 20)
      Me.txtLCIName.TabIndex = 6
      Me.txtLCIName.TabStop = False
      '
      'txtToolName
      '
      Me.Validator.SetDataType(Me.txtToolName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.txtToolName.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMinValue(Me.txtToolName, "")
      Me.txtToolName.Name = "txtToolName"
      Me.txtToolName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToolName, "")
      Me.Validator.SetRequired(Me.txtToolName, False)
      Me.txtToolName.Size = New System.Drawing.Size(144, 20)
      Me.txtToolName.TabIndex = 7
      Me.txtToolName.TabStop = False
      '
      'ibtnShowTool
      '
      Me.ibtnShowTool.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowTool.Location = New System.Drawing.Point(352, 40)
      Me.ibtnShowTool.Name = "ibtnShowTool"
      Me.ibtnShowTool.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowTool.TabIndex = 11
      Me.ibtnShowTool.TabStop = False
      Me.ibtnShowTool.ThemedImage = CType(resources.GetObject("ibtnShowTool.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTool
      '
      Me.lblTool.BackColor = System.Drawing.Color.Transparent
      Me.lblTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTool.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTool.Location = New System.Drawing.Point(25, 40)
      Me.lblTool.Name = "lblTool"
      Me.lblTool.Size = New System.Drawing.Size(78, 18)
      Me.lblTool.TabIndex = 4
      Me.lblTool.Text = "Tool:"
      Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToolDialog
      '
      Me.ibtnShowToolDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToolDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToolDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToolDialog.Location = New System.Drawing.Point(328, 40)
      Me.ibtnShowToolDialog.Name = "ibtnShowToolDialog"
      Me.ibtnShowToolDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToolDialog.TabIndex = 9
      Me.ibtnShowToolDialog.TabStop = False
      Me.ibtnShowToolDialog.ThemedImage = CType(resources.GetObject("ibtnShowToolDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTool
      '
      Me.Validator.SetDataType(Me.txtTool, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTool, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.txtTool.Location = New System.Drawing.Point(103, 40)
      Me.Validator.SetMinValue(Me.txtTool, "")
      Me.txtTool.Name = "txtTool"
      Me.Validator.SetRegularExpression(Me.txtTool, "")
      Me.Validator.SetRequired(Me.txtTool, False)
      Me.txtTool.Size = New System.Drawing.Size(80, 20)
      Me.txtTool.TabIndex = 5
      '
      'grbApprove
      '
      Me.grbApprove.Controls.Add(Me.cmbApproveLevel)
      Me.grbApprove.Controls.Add(Me.lblApproveLevel)
      Me.grbApprove.Controls.Add(Me.txtApprovePerson)
      Me.grbApprove.Controls.Add(Me.txtApprovePersonName)
      Me.grbApprove.Controls.Add(Me.lblApprovePerson)
      Me.grbApprove.Controls.Add(Me.btnFineApprove)
      Me.grbApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbApprove.Location = New System.Drawing.Point(8, 228)
      Me.grbApprove.Name = "grbApprove"
      Me.grbApprove.Size = New System.Drawing.Size(385, 68)
      Me.grbApprove.TabIndex = 2
      Me.grbApprove.TabStop = False
      Me.grbApprove.Text = "การอนุมัติ"
      '
      'cmbApproveLevel
      '
      Me.cmbApproveLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApproveLevel.Location = New System.Drawing.Point(103, 38)
      Me.cmbApproveLevel.Name = "cmbApproveLevel"
      Me.cmbApproveLevel.Size = New System.Drawing.Size(225, 21)
      Me.cmbApproveLevel.TabIndex = 12
      '
      'lblApproveLevel
      '
      Me.lblApproveLevel.BackColor = System.Drawing.Color.Transparent
      Me.lblApproveLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApproveLevel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApproveLevel.Location = New System.Drawing.Point(7, 38)
      Me.lblApproveLevel.Name = "lblApproveLevel"
      Me.lblApproveLevel.Size = New System.Drawing.Size(96, 18)
      Me.lblApproveLevel.TabIndex = 13
      Me.lblApproveLevel.Text = "ระดับการอนุมัติ:"
      Me.lblApproveLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtApprovePerson
      '
      Me.Validator.SetDataType(Me.txtApprovePerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtApprovePerson, "")
      Me.Validator.SetGotFocusBackColor(Me.txtApprovePerson, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtApprovePerson, System.Drawing.Color.Empty)
      Me.txtApprovePerson.Location = New System.Drawing.Point(103, 15)
      Me.Validator.SetMinValue(Me.txtApprovePerson, "")
      Me.txtApprovePerson.Name = "txtApprovePerson"
      Me.Validator.SetRegularExpression(Me.txtApprovePerson, "")
      Me.Validator.SetRequired(Me.txtApprovePerson, False)
      Me.txtApprovePerson.Size = New System.Drawing.Size(80, 20)
      Me.txtApprovePerson.TabIndex = 1
      '
      'txtApprovePersonName
      '
      Me.Validator.SetDataType(Me.txtApprovePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtApprovePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtApprovePersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtApprovePersonName, System.Drawing.Color.Empty)
      Me.txtApprovePersonName.Location = New System.Drawing.Point(184, 15)
      Me.Validator.SetMinValue(Me.txtApprovePersonName, "")
      Me.txtApprovePersonName.Name = "txtApprovePersonName"
      Me.txtApprovePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtApprovePersonName, "")
      Me.Validator.SetRequired(Me.txtApprovePersonName, False)
      Me.txtApprovePersonName.Size = New System.Drawing.Size(143, 20)
      Me.txtApprovePersonName.TabIndex = 8
      Me.txtApprovePersonName.TabStop = False
      '
      'lblApprovePerson
      '
      Me.lblApprovePerson.BackColor = System.Drawing.Color.Transparent
      Me.lblApprovePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApprovePerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApprovePerson.Location = New System.Drawing.Point(6, 15)
      Me.lblApprovePerson.Name = "lblApprovePerson"
      Me.lblApprovePerson.Size = New System.Drawing.Size(99, 18)
      Me.lblApprovePerson.TabIndex = 5
      Me.lblApprovePerson.Text = "ผู้อนุมัติ:"
      Me.lblApprovePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnFineApprove
      '
      Me.btnFineApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFineApprove.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFineApprove.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFineApprove.Location = New System.Drawing.Point(327, 15)
      Me.btnFineApprove.Name = "btnFineApprove"
      Me.btnFineApprove.Size = New System.Drawing.Size(24, 23)
      Me.btnFineApprove.TabIndex = 10
      Me.btnFineApprove.TabStop = False
      Me.btnFineApprove.ThemedImage = CType(resources.GetObject("btnFineApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtRequestorCode)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtRequestorName)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblRequestor)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.btnRequestorPanel)
      Me.grbMainDetail.Controls.Add(Me.lblCC)
      Me.grbMainDetail.Controls.Add(Me.btnRequestorDialog)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 117)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(104, 88)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(224, 21)
      Me.cmbStatus.TabIndex = 3
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(8, 88)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(96, 18)
      Me.lblStatus.TabIndex = 7
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRequestorCode
      '
      Me.Validator.SetDataType(Me.txtRequestorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRequestorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
      Me.txtRequestorCode.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMinValue(Me.txtRequestorCode, "")
      Me.txtRequestorCode.Name = "txtRequestorCode"
      Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
      Me.Validator.SetRequired(Me.txtRequestorCode, False)
      Me.txtRequestorCode.Size = New System.Drawing.Size(80, 20)
      Me.txtRequestorCode.TabIndex = 1
      '
      'btnCostCenterPanel
      '
      Me.btnCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterPanel.Location = New System.Drawing.Point(350, 64)
      Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
      Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterPanel.TabIndex = 13
      Me.btnCostCenterPanel.TabStop = False
      Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(104, 64)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtCostCenterCode.TabIndex = 2
      '
      'txtRequestorName
      '
      Me.Validator.SetDataType(Me.txtRequestorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRequestorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
      Me.txtRequestorName.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMinValue(Me.txtRequestorName, "")
      Me.txtRequestorName.Name = "txtRequestorName"
      Me.txtRequestorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
      Me.Validator.SetRequired(Me.txtRequestorName, False)
      Me.txtRequestorName.Size = New System.Drawing.Size(143, 20)
      Me.txtRequestorName.TabIndex = 8
      Me.txtRequestorName.TabStop = False
      '
      'lblRequestor
      '
      Me.lblRequestor.BackColor = System.Drawing.Color.Transparent
      Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRequestor.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRequestor.Location = New System.Drawing.Point(8, 40)
      Me.lblRequestor.Name = "lblRequestor"
      Me.lblRequestor.Size = New System.Drawing.Size(96, 18)
      Me.lblRequestor.TabIndex = 5
      Me.lblRequestor.Text = "ผู้ขอ:"
      Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(184, 64)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(143, 20)
      Me.txtCostCenterName.TabIndex = 9
      Me.txtCostCenterName.TabStop = False
      '
      'btnCostCenterDialog
      '
      Me.btnCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostCenterDialog.Location = New System.Drawing.Point(326, 64)
      Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
      Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterDialog.TabIndex = 12
      Me.btnCostCenterDialog.TabStop = False
      Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnRequestorPanel
      '
      Me.btnRequestorPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRequestorPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRequestorPanel.Location = New System.Drawing.Point(350, 40)
      Me.btnRequestorPanel.Name = "btnRequestorPanel"
      Me.btnRequestorPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnRequestorPanel.TabIndex = 11
      Me.btnRequestorPanel.TabStop = False
      Me.btnRequestorPanel.ThemedImage = CType(resources.GetObject("btnRequestorPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCC
      '
      Me.lblCC.BackColor = System.Drawing.Color.Transparent
      Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCC.Location = New System.Drawing.Point(8, 64)
      Me.lblCC.Name = "lblCC"
      Me.lblCC.Size = New System.Drawing.Size(96, 18)
      Me.lblCC.TabIndex = 6
      Me.lblCC.Text = "CostCenter:"
      Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnRequestorDialog
      '
      Me.btnRequestorDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRequestorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRequestorDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRequestorDialog.Location = New System.Drawing.Point(326, 40)
      Me.btnRequestorDialog.Name = "btnRequestorDialog"
      Me.btnRequestorDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnRequestorDialog.TabIndex = 10
      Me.btnRequestorDialog.TabStop = False
      Me.btnRequestorDialog.ThemedImage = CType(resources.GetObject("btnRequestorDialog.ThemedImage"), System.Drawing.Bitmap)
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
      'PRFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "PRFilterSubPanel"
      Me.Size = New System.Drawing.Size(679, 312)
      Me.grbDetail.ResumeLayout(False)
      Me.grbReceivingDate.ResumeLayout(False)
      Me.grbReceivingDate.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbItem.ResumeLayout(False)
      Me.grbItem.PerformLayout()
      Me.grbApprove.ResumeLayout(False)
      Me.grbApprove.PerformLayout()
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
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
    Private m_requestor As Employee
    Private m_cc As CostCenter
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private dummyCC As New CostCenter
    Private dummyLci As New LCIItem
    Private docDateStart As Date
    Private docDateEnd As Date
    Private receivingDateStart As Date
    Private receivingDateEnd As Date
    Private m_user As New User
#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtReceivingDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpReceivingDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtReceivingdateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpReceivingDateEnd.ValueChanged, AddressOf Me.ChangeProperty

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

        Case "dtpreceivingdatestart"
          If Not Me.receivingDateStart.Equals(dtpReceivingDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtReceivingDateStart.Text = MinDateToNull(dtpReceivingDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.receivingDateStart = dtpReceivingDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtreceivingdatestart"
          m_dateSetting = True
          If Not Me.txtReceivingDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtReceivingDateStart.Text)
            If Not Me.receivingDateStart.Equals(theDate) Then
              dtpReceivingDateStart.Value = theDate
              Me.receivingDateStart = dtpReceivingDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpReceivingDateStart.Value = Date.Now
            Me.receivingDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpreceivingdateend"
          If Not Me.receivingDateEnd.Equals(dtpReceivingDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtReceivingdateEnd.Text = MinDateToNull(dtpReceivingDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.receivingDateEnd = dtpReceivingDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtreceivingdateend"
          m_dateSetting = True
          If Not Me.txtReceivingdateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingdateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtReceivingdateEnd.Text)
            If Not Me.receivingDateEnd.Equals(theDate) Then
              dtpReceivingDateEnd.Value = theDate
              Me.receivingDateEnd = dtpReceivingDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpReceivingDateEnd.Value = Date.Now
            Me.receivingDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.txtCostCenterCode.Text = ""
      Me.txtCostCenterName.Text = ""
      Me.m_cc = New CostCenter

      Me.txtRequestorCode.Text = ""
      Me.txtRequestorName.Text = ""
      Me.m_requestor = New Employee

      Me.txtLCI.Text = ""
      Me.txtLCIName.Text = ""
      Me.m_lci = New LCIItem

      Me.txtTool.Text = ""
      Me.txtToolName.Text = ""
      Me.m_tool = New Tool

      Me.txtBlank.Text = ""

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, -14, Now.Date)
      Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -14, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

      Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.docDateEnd = Now.Date

      Me.dtpReceivingDateStart.Value = DateAdd(DateInterval.Day, -14, Now.Date)
      Me.dtpReceivingDateEnd.Value = Now.Date

      Me.txtReceivingDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -14, Now.Date), "")
      Me.txtReceivingdateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, 14, Now.Date), "")

      Me.receivingDateStart = DateAdd(DateInterval.Day, -14, Now.Date)
      Me.receivingDateEnd = DateAdd(DateInterval.Day, 14, Now.Date)

      Me.cmbStatus.SelectedIndex = 0
      Me.cmbApproveLevel.SelectedIndex = 0

      Me.txtApprovePerson.Text = ""
      Me.txtApprovePersonName.Text = ""
      Me.m_user = New User

    End Sub
    Private Sub PopulateStatus()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
      Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
      Dim dt1 As DataTable

      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "pr_status", True)
      dt1 = CodeDescription.GetCodeList("reference_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next
      dt1 = CodeDescription.GetCodeList("approve_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next
      dt1 = CodeDescription.GetCodeList("close_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next

      cmbApproveLevel.Items.Clear()
      cmbApproveLevel.Items.Insert(0, New IdValuePair(-1, notAppear))
      For i As Integer = 0 To User.MaxLevel
        Dim item As New IdValuePair(i, lvString & Space(1) & i.ToString)
        cmbApproveLevel.Items.Add(item)
      Next
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnSearch}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnReset}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateEnd}")
      Me.lblReceivingDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateStart}")
      Me.lblReceivingDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateEnd}")
      Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblRequestor}")
      Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCC}")
      Me.grbReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbReceivingDate}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblStatus}")
      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbItem}")
      Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblLCI}")
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblTool}")
      Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblBlank}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbMainDetail}")

      Me.grbApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbApprove}")
      Me.lblApprovePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblApprovePerson}")
      Me.lblApproveLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblApproveLevel}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(13) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("requestor", IIf(Me.m_requestor.Valid, Me.m_requestor.Id, DBNull.Value))
      arr(2) = New Filter("cc_id", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
      arr(3) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(4) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(5) = New Filter("receivingdatestart", ValidDateOrDBNull(receivingDateStart))
      arr(6) = New Filter("receivingdateend", ValidDateOrDBNull(receivingDateEnd))
      arr(7) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(8) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
      arr(9) = New Filter("tool_id", IIf(Me.m_tool.Valid, Me.m_tool.Id, DBNull.Value))
      arr(10) = New Filter("pri_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      arr(11) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(12) = New Filter("ApprovePerson", ValidIdOrDBNull(m_user))
      arr(13) = New Filter("ApproveLevel", IIf(cmbApproveLevel.SelectedItem Is Nothing, DBNull.Value, CType(cmbApproveLevel.SelectedItem, IdValuePair).Id))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtApprovePerson_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprovePerson.Validated
      User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    End Sub
    Private Sub txtRequestorCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequestorCode.Validated
      Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
    Private Sub txtCostCenterCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCI.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New LCIItem)
    End Sub

    Private Sub ibtnShowTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowTool.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Tool)
    End Sub
    Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLCI.Validated
      LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub SetLCi(ByVal e As ISimpleEntity)
      Me.txtLCI.Text = e.Code
      LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub txtTool_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTool.Validated
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    End Sub
    Private Sub SetTool(ByVal e As ISimpleEntity)
      Me.txtTool.Text = e.Code
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    End Sub
    Private Sub SetUser(ByVal e As ISimpleEntity)
      Me.txtApprovePerson.Text = e.Code
      User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    End Sub
    Private Sub btnFineApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFineApprove.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New User, AddressOf SetUser)
    End Sub
    Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCIDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
    End Sub
    Private Sub ibtnShowToolDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToolDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Tool, AddressOf SetTool)
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    Private Sub btnRequestorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRequestor)
    End Sub
    Private Sub SetRequestor(ByVal e As ISimpleEntity)
      Me.txtRequestorCode.Text = e.Code
      Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
    Private Sub btnRequestorPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        If data.GetDataPresent((dummyCC).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercode", "txtcostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtrequestorcode", "txtrequestorname"
              Return True
          End Select
        End If
        If data.GetDataPresent((dummyLci).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtlci", "txtlciname"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Tool).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttool", "txttoolname"
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
      If data.GetDataPresent((dummyCC).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtcostcentercode", "txtcostcentername"
            Me.SetCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtrequestorcode", "txtrequestorname"
            Me.SetRequestor(entity)
        End Select
      End If
      If data.GetDataPresent((dummyLci).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
        Dim entity As New LCIItem(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtlci", "txtlciname"
            Me.SetLCi(entity)
        End Select
      End If
      If data.GetDataPresent((New Tool).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Tool).FullClassName))
        Dim entity As New Tool(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttool", "txttoolname"
            Me.SetTool(entity)
        End Select
      End If
    End Sub
#End Region

#Region " Fixed Filters "
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

        If TypeOf entity Is PR Then
          If entity.Status.Value <> -1 Then
            CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
            Me.cmbStatus.Enabled = False
          End If
        End If
        If TypeOf entity Is CostCenter Then
          Me.SetCostCenter(CType(entity, CostCenter))
          Me.txtCostCenterCode.Enabled = False
          Me.txtCostCenterName.Enabled = False
          Me.btnCostCenterDialog.Enabled = False
          Me.btnCostCenterPanel.Enabled = False
        End If
      Next
    End Sub
#End Region

  End Class
End Namespace

