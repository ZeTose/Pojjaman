Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class DRFilterSubPanel
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
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubcontractCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubcontractName As System.Windows.Forms.TextBox
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSupcontrator As System.Windows.Forms.Label
    Friend WithEvents btnSubcontractDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbApprove As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbApproveLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproveLevel As System.Windows.Forms.Label
    Friend WithEvents txtApprovePerson As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovePersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovePerson As System.Windows.Forms.Label
    Friend WithEvents btnFineApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DRFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
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
      Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.ibtnShowFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtSubcontractCode = New System.Windows.Forms.TextBox()
      Me.txtSubcontractName = New System.Windows.Forms.TextBox()
      Me.btnSubcontractDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupcontrator = New System.Windows.Forms.Label()
      Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSCCode = New System.Windows.Forms.TextBox()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCC = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.grbApprove = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbApproveLevel = New System.Windows.Forms.ComboBox()
      Me.lblApproveLevel = New System.Windows.Forms.Label()
      Me.txtApprovePerson = New System.Windows.Forms.TextBox()
      Me.txtApprovePersonName = New System.Windows.Forms.TextBox()
      Me.lblApprovePerson = New System.Windows.Forms.Label()
      Me.btnFineApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.grbApprove.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 3
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
      Me.txtCode.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(231, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbApprove)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbItem)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(5, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 232)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
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
      Me.grbDocDate.Location = New System.Drawing.Point(383, 12)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(384, 69)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateStart.TabIndex = 0
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(11, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(109, 18)
      Me.lblDocDateStart.TabIndex = 2
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(11, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(109, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 4
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(120, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(696, 200)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(616, 200)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 5
      Me.btnReset.Text = "Reset"
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.ibtnShowFromCostCenterDialog)
      Me.grbItem.Controls.Add(Me.lblFromCostCenter)
      Me.grbItem.Controls.Add(Me.lblFromCCPerson)
      Me.grbItem.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbItem.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbItem.Controls.Add(Me.txtFromCCPersonName)
      Me.grbItem.Controls.Add(Me.txtFromCostCenterName)
      Me.grbItem.Controls.Add(Me.ibtnShowFromCCPersonDialog)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(383, 81)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(384, 74)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "ข้อมูลผู้ให้เบิก"
      '
      'ibtnShowFromCostCenterDialog
      '
      Me.ibtnShowFromCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(344, 16)
      Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
      Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenterDialog.TabIndex = 14
      Me.ibtnShowFromCostCenterDialog.TabStop = False
      Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(112, 18)
      Me.lblFromCostCenter.TabIndex = 18
      Me.lblFromCostCenter.Text = "Cost Center ที่ให้เบิก:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(56, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(64, 18)
      Me.lblFromCCPerson.TabIndex = 19
      Me.lblFromCCPerson.Text = "ผู้ให้เบิก:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(120, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, False)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(72, 20)
      Me.txtFromCostCenterCode.TabIndex = 10
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, False)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(72, 20)
      Me.txtFromCCPersonCode.TabIndex = 11
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(192, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(152, 20)
      Me.txtFromCCPersonName.TabIndex = 13
      Me.txtFromCCPersonName.TabStop = False
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(192, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(152, 20)
      Me.txtFromCostCenterName.TabIndex = 12
      Me.txtFromCostCenterName.TabStop = False
      '
      'ibtnShowFromCCPersonDialog
      '
      Me.ibtnShowFromCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCCPersonDialog.Location = New System.Drawing.Point(344, 40)
      Me.ibtnShowFromCCPersonDialog.Name = "ibtnShowFromCCPersonDialog"
      Me.ibtnShowFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPersonDialog.TabIndex = 15
      Me.ibtnShowFromCCPersonDialog.TabStop = False
      Me.ibtnShowFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtSubcontractCode)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtSubcontractName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnSubcontractDialog)
      Me.grbMainDetail.Controls.Add(Me.lblSupcontrator)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowSCDialog)
      Me.grbMainDetail.Controls.Add(Me.txtSCCode)
      Me.grbMainDetail.Controls.Add(Me.lblSCCode)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.lblCC)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(7, 12)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(368, 144)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(96, 112)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(231, 21)
      Me.cmbStatus.TabIndex = 2
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(24, 112)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(72, 18)
      Me.lblStatus.TabIndex = 5
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubcontractCode
      '
      Me.Validator.SetDataType(Me.txtSubcontractCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubcontractCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubcontractCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubcontractCode, System.Drawing.Color.Empty)
      Me.txtSubcontractCode.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMinValue(Me.txtSubcontractCode, "")
      Me.txtSubcontractCode.Name = "txtSubcontractCode"
      Me.Validator.SetRegularExpression(Me.txtSubcontractCode, "")
      Me.Validator.SetRequired(Me.txtSubcontractCode, False)
      Me.txtSubcontractCode.Size = New System.Drawing.Size(80, 20)
      Me.txtSubcontractCode.TabIndex = 1
      '
      'txtSubcontractName
      '
      Me.Validator.SetDataType(Me.txtSubcontractName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubcontractName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubcontractName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubcontractName, System.Drawing.Color.Empty)
      Me.txtSubcontractName.Location = New System.Drawing.Point(176, 64)
      Me.Validator.SetMinValue(Me.txtSubcontractName, "")
      Me.txtSubcontractName.Name = "txtSubcontractName"
      Me.txtSubcontractName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubcontractName, "")
      Me.Validator.SetRequired(Me.txtSubcontractName, False)
      Me.txtSubcontractName.Size = New System.Drawing.Size(151, 20)
      Me.txtSubcontractName.TabIndex = 6
      Me.txtSubcontractName.TabStop = False
      '
      'btnSubcontractDialog
      '
      Me.btnSubcontractDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubcontractDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubcontractDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubcontractDialog.Location = New System.Drawing.Point(326, 64)
      Me.btnSubcontractDialog.Name = "btnSubcontractDialog"
      Me.btnSubcontractDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSubcontractDialog.TabIndex = 7
      Me.btnSubcontractDialog.TabStop = False
      Me.btnSubcontractDialog.ThemedImage = CType(resources.GetObject("btnSubcontractDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupcontrator
      '
      Me.lblSupcontrator.BackColor = System.Drawing.Color.Transparent
      Me.lblSupcontrator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupcontrator.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSupcontrator.Location = New System.Drawing.Point(8, 64)
      Me.lblSupcontrator.Name = "lblSupcontrator"
      Me.lblSupcontrator.Size = New System.Drawing.Size(88, 18)
      Me.lblSupcontrator.TabIndex = 4
      Me.lblSupcontrator.Text = "ผู้รับเหมา:"
      Me.lblSupcontrator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSCDialog
      '
      Me.ibtnShowSCDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSCDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSCDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSCDialog.Location = New System.Drawing.Point(326, 40)
      Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
      Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSCDialog.TabIndex = 339
      Me.ibtnShowSCDialog.TabStop = False
      Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, False)
      Me.txtSCCode.Size = New System.Drawing.Size(231, 21)
      Me.txtSCCode.TabIndex = 337
      Me.txtSCCode.TabStop = False
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(40, 40)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(56, 18)
      Me.lblSCCode.TabIndex = 338
      Me.lblSCCode.Text = "เลขที่ SC:"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtCostCenterCode.TabIndex = 14
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(176, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(151, 20)
      Me.txtCostCenterName.TabIndex = 16
      Me.txtCostCenterName.TabStop = False
      '
      'btnCostCenterDialog
      '
      Me.btnCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostCenterDialog.Location = New System.Drawing.Point(326, 88)
      Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
      Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterDialog.TabIndex = 17
      Me.btnCostCenterDialog.TabStop = False
      Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCC
      '
      Me.lblCC.BackColor = System.Drawing.Color.Transparent
      Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCC.Location = New System.Drawing.Point(8, 88)
      Me.lblCC.Name = "lblCC"
      Me.lblCC.Size = New System.Drawing.Size(88, 18)
      Me.lblCC.TabIndex = 15
      Me.lblCC.Text = "CostCenter เบิก:"
      Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'grbApprove
      '
      Me.grbApprove.Controls.Add(Me.cmbApproveLevel)
      Me.grbApprove.Controls.Add(Me.lblApproveLevel)
      Me.grbApprove.Controls.Add(Me.txtApprovePerson)
      Me.grbApprove.Controls.Add(Me.txtApprovePersonName)
      Me.grbApprove.Controls.Add(Me.lblApprovePerson)
      Me.grbApprove.Controls.Add(Me.btnFineApprove)
      Me.grbApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbApprove.Location = New System.Drawing.Point(7, 156)
      Me.grbApprove.Name = "grbApprove"
      Me.grbApprove.Size = New System.Drawing.Size(368, 68)
      Me.grbApprove.TabIndex = 9
      Me.grbApprove.TabStop = False
      Me.grbApprove.Text = "การอนุมัติ"
      '
      'cmbApproveLevel
      '
      Me.cmbApproveLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApproveLevel.Location = New System.Drawing.Point(95, 38)
      Me.cmbApproveLevel.Name = "cmbApproveLevel"
      Me.cmbApproveLevel.Size = New System.Drawing.Size(232, 21)
      Me.cmbApproveLevel.TabIndex = 12
      '
      'lblApproveLevel
      '
      Me.lblApproveLevel.BackColor = System.Drawing.Color.Transparent
      Me.lblApproveLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApproveLevel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApproveLevel.Location = New System.Drawing.Point(4, 38)
      Me.lblApproveLevel.Name = "lblApproveLevel"
      Me.lblApproveLevel.Size = New System.Drawing.Size(91, 18)
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
      Me.txtApprovePerson.Location = New System.Drawing.Point(95, 15)
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
      Me.txtApprovePersonName.Location = New System.Drawing.Point(175, 15)
      Me.Validator.SetMinValue(Me.txtApprovePersonName, "")
      Me.txtApprovePersonName.Name = "txtApprovePersonName"
      Me.txtApprovePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtApprovePersonName, "")
      Me.Validator.SetRequired(Me.txtApprovePersonName, False)
      Me.txtApprovePersonName.Size = New System.Drawing.Size(152, 20)
      Me.txtApprovePersonName.TabIndex = 8
      Me.txtApprovePersonName.TabStop = False
      '
      'lblApprovePerson
      '
      Me.lblApprovePerson.BackColor = System.Drawing.Color.Transparent
      Me.lblApprovePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApprovePerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApprovePerson.Location = New System.Drawing.Point(3, 15)
      Me.lblApprovePerson.Name = "lblApprovePerson"
      Me.lblApprovePerson.Size = New System.Drawing.Size(94, 18)
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
      'DRFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "DRFilterSubPanel"
      Me.Size = New System.Drawing.Size(791, 244)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbItem.ResumeLayout(False)
      Me.grbItem.PerformLayout()
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      Me.grbApprove.ResumeLayout(False)
      Me.grbApprove.PerformLayout()
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
    Private m_supcontractor As Supplier
    Private m_sc As SC
    'Private m_lci As LCIItem
    'Private m_tool As Tool
    Private m_fromCC As New CostCenter
    Private m_toCC As CostCenter
    Private m_employee As Employee
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

        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.m_supcontractor = New Supplier
      Me.txtSubcontractCode.Text = ""
      Me.txtSubcontractName.Text = ""
      Me.txtCostCenterCode.Text = ""
      Me.txtCostCenterName.Text = ""
      Me.txtFromCostCenterCode.Text = ""
      Me.txtFromCostCenterName.Text = ""
      Me.txtFromCCPersonCode.Text = ""
      Me.txtFromCCPersonName.Text = ""
      Me.txtSCCode.Text = ""
      Me.txtApprovePerson.Text = ""
      Me.txtApprovePersonName.Text = ""

      Me.m_fromCC = New CostCenter
      Me.m_toCC = New CostCenter
      Me.m_employee = New Employee
      Me.m_sc = New SC
      Me.m_user = New User

      Dim drDocDateStartBeforeToday As Long = Configuration.GetConfig("DRDocDateStartBeforeToday")
      Dim drDocDateEndAfterToday As Long = Configuration.GetConfig("DRDocDateEndAfterToday")
      Dim drReceiveDateStartBeforeToday As Long = Configuration.GetConfig("DRReceiveDateStartBeforeToday")
      Dim drReceiveDateEndAfterToday As Long = Configuration.GetConfig("DRReceiveDateEndAfterToday")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, drDocDateEndAfterToday, Now.Subtract(New TimeSpan(7, 0, 0, 0)))
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, drReceiveDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, drDocDateStartBeforeToday, Now.Subtract(New TimeSpan(7, 0, 0, 0))), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, drDocDateEndAfterToday, Now.Date), "")
      Me.docDateStart = DateAdd(DateInterval.Day, drDocDateStartBeforeToday, Now.Subtract(New TimeSpan(7, 0, 0, 0)))
      Me.docDateEnd = DateAdd(DateInterval.Day, drDocDateEndAfterToday, Now.Date)
      cmbStatus.SelectedIndex = 0
      Me.cmbApproveLevel.SelectedIndex = 0

    End Sub
    Private Sub PopulateStatus()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
      Dim waitLVSApprove As String = Me.StringParserService.Parse("${res:Global.WaitForOtherLevelApprove}")
      Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
      Dim maxGRApproveLevel As Integer = CType(Configuration.GetConfig("MaxLevelApproveDR"), Integer)

      Dim dt1 As DataTable

      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "pa_status", True)
      dt1 = CodeDescription.GetCodeList("reference_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next

      dt1 = CodeDescription.GetCodeList("approve_status")
      Dim itemApprove1 As IdValuePair = Nothing
      Dim itemApprove2 As IdValuePair = Nothing
      Dim itemApprove3 As IdValuePair = Nothing

      For Each row As DataRow In dt1.Rows
        If Not row.IsNull("code_value") Then
          If CInt(row("code_value")) = 201 Then
            itemApprove1 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          End If
          'If CInt(row("code_value")) = "202" Then
          '  itemApprove2 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          'End If
          If CInt(row("code_value")) = 203 Then
            itemApprove3 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          End If
        End If
      Next

      dt1 = CodeDescription.GetCodeList("close_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next

      cmbApproveLevel.Items.Clear()
      cmbApproveLevel.Items.Insert(0, New IdValuePair(-1, notAppear))
      For i As Integer = 1 To maxGRApproveLevel 'User.MaxLevel
        Dim item As New IdValuePair(i - 1, String.Format(waitLVSApprove, i))
        cmbApproveLevel.Items.Add(item)
      Next
      If Not itemApprove1 Is Nothing Then
        cmbApproveLevel.Items.Insert(maxGRApproveLevel + 1, itemApprove1)
      End If
      If Not itemApprove3 Is Nothing Then
        cmbApproveLevel.Items.Insert(maxGRApproveLevel + 2, itemApprove3)
      End If
    End Sub
    Public Sub SetLabelText()
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.grbDetail}") '"รายละเอียดทั่วไป"
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblCode}") '"รหัส:"
      Me.lblSupcontrator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblSupcontractor}") '"ผู้รับเหมา:"
      Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblCC}") '"Cost Center เบิก:"
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblStatus}") '"สถานะ"
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.grbDocDate}") '"วันที่เอกสาร"
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblDocDateEnd}") '"ถึง"
      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.grbItem}") '"ข้อมูลผู้ให้เบิก"
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbMainDetail}")
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblFromCostCenter}") '"Cost Center ที่ให้เบิก:"
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblFromCCPerson}")
      'Me.lblSupcontrator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRFilterSubPanel.lblSupcontrator}")

      Me.grbApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbApprove}")
      Me.lblApprovePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblApprovePerson}")
      Me.lblApproveLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblApproveLevel}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(11) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("subcontractor", IIf(Me.m_supcontractor.Valid, Me.m_supcontractor.Id, DBNull.Value))
      arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(4) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(5) = New Filter("tocc", IIf(Me.m_toCC.Valid, Me.m_toCC.Id, DBNull.Value))
      arr(6) = New Filter("employee", IIf(Me.m_employee.Valid, Me.m_employee.Id, DBNull.Value))
      arr(7) = New Filter("fromcc", IIf(Me.m_fromCC.Valid, Me.m_fromCC.Id, DBNull.Value))
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(9) = New Filter("ApprovePerson", ValidIdOrDBNull(m_user))
      arr(10) = New Filter("ApproveLevel", IIf(cmbApproveLevel.SelectedItem Is Nothing, DBNull.Value, CType(cmbApproveLevel.SelectedItem, IdValuePair).Id))
      arr(11) = New Filter("sc_code", IIf(Me.m_sc.Valid, Me.m_sc.Code, DBNull.Value))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtApprovePerson_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprovePerson.Validated, _
      txtSCCode.Validated, _
      txtSubcontractCode.Validated, _
      txtCostCenterCode.Validated, _
      txtFromCostCenterCode.Validated, _
      txtFromCCPersonCode.Validated
      Select Case CType(sender, TextBox).Name.ToLower
        Case txtSCCode.Name.ToLower
          If txtSCCode.Text.Trim.Length = 0 Then
            Me.m_sc = New SC
          Else
            SC.GetSC(txtSCCode, Me.m_sc)
          End If
        Case txtApprovePerson.Name.ToLower
          User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
        Case txtSubcontractCode.Name.ToLower
          Supplier.GetSupplier(txtSubcontractCode, txtSubcontractName, Me.m_supcontractor)
        Case txtCostCenterCode.Name.ToLower
          CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_toCC)
        Case txtFromCostCenterCode.Name.ToLower
          CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC)
        Case txtFromCCPersonCode.Name.ToLower
          Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_employee)
      End Select
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    'Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
    'End Sub
    'Private Sub btnCostCenter2Dialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenter2Dialog.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter2)
    'End Sub
    Private Sub btnSubcontractDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubcontractDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSubcontractCode.Text = e.Code
      Supplier.GetSupplier(txtSubcontractCode, txtSubcontractName, Me.m_supcontractor)
    End Sub
    Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SettoCC)
    End Sub
    Private Sub SettoCC(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_toCC)
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetfromCC)
    End Sub
    Private Sub SetfromCC(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC)
    End Sub
    Private Sub ibtnShowFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
    End Sub
    Private Sub SetEmployee(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_employee)
    End Sub
    Private Sub SetUser(ByVal e As ISimpleEntity)
      Me.txtApprovePerson.Text = e.Code
      User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    End Sub
    Private Sub btnFineApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFineApprove.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New User, AddressOf SetUser)
    End Sub
    Private Sub ibtnShowSCDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowSCDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New SC, AddressOf SetSC)
    End Sub
    Private Sub SetSC(ByVal e As ISimpleEntity)
      Me.txtSCCode.Text = e.Code
      SC.GetSC(txtSCCode, Me.m_sc)
    End Sub
    'ibtnShowFromCCPersonDialog
#End Region

#Region "IClipboardHandler Overrides"   'Undone
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
        If data.GetDataPresent((New LCIItem).FullClassName) Then
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
      'If data.GetDataPresent((dummyCC).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
      '    Dim entity As New CostCenter(id)
      '    Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtcostcentercode", "txtcostcentername"
      '            Me.SetCostCenter(entity)
      '    End Select
      'End If
      'If data.GetDataPresent((New Supplier).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
      '    Dim entity As New Supplier(id)
      '    Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtsuppliercode", "txtsuppliername"
      '            Me.SetSupplier(entity)
      '    End Select
      'End If
      'If data.GetDataPresent((New LCIItem).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
      '    Dim entity As New LCIItem(id)
      '    Select Case Me.ActiveControl.Name.ToLower
      '        Case "txtlci", "txtlciname"
      '            Me.SetLCi(entity)
      '    End Select
      'End If
      'If data.GetDataPresent((New Tool).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New Tool).FullClassName))
      '    Dim entity As New Tool(id)
      '    Select Case Me.ActiveControl.Name.ToLower
      '        Case "txttool", "txttoolname"
      '            Me.SetTool(entity)
      '    End Select
      'End If
    End Sub
#End Region

#Region "Properties"
    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        For Each entity As ISimpleEntity In Value
          If TypeOf entity Is Supplier Then
            'Me.SetSupplier(entity)
            Me.txtSubcontractCode.Enabled = False
            Me.txtSubcontractName.Enabled = False
            Me.btnSubcontractDialog.Enabled = False
          End If
          If TypeOf entity Is DR Then
            If entity.Status.Value <> -1 Then
              CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
              Me.cmbStatus.Enabled = False
            End If
          End If
          If TypeOf entity Is CostCenter Then
            'Me.SetCostCenter(CType(entity, CostCenter))
            Me.txtCostCenterCode.Enabled = False
            Me.txtCostCenterName.Enabled = False
            Me.btnCostCenterDialog.Enabled = False
          End If
        Next
      End Set
    End Property
#End Region

  End Class
End Namespace

