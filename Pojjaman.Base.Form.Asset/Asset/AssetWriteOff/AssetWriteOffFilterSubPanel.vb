Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AssetWriteoffFilterSubPanel
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
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
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
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCC As System.Windows.Forms.Label
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents btnCustomerPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFromCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFromCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblLci As System.Windows.Forms.Label
    Friend WithEvents txtRVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblRVEnd As System.Windows.Forms.Label
    Friend WithEvents txtRVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblRVStart As System.Windows.Forms.Label
    Friend WithEvents btnRVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnRVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetWriteoffFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblLci = New System.Windows.Forms.Label
      Me.lblBlank = New System.Windows.Forms.Label
      Me.txtBlank = New System.Windows.Forms.TextBox
      Me.ibtnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtLCI = New System.Windows.Forms.TextBox
      Me.txtLCIName = New System.Windows.Forms.TextBox
      Me.txtToolName = New System.Windows.Forms.TextBox
      Me.ibtnShowTool = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblTool = New System.Windows.Forms.Label
      Me.ibtnShowToolDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtTool = New System.Windows.Forms.TextBox
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnCustomerPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCustomerCode = New System.Windows.Forms.TextBox
      Me.txtCustomerName = New System.Windows.Forms.TextBox
      Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCustomer = New System.Windows.Forms.Label
      Me.cmbStatus = New System.Windows.Forms.ComboBox
      Me.lblStatus = New System.Windows.Forms.Label
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
      Me.btnFromCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
      Me.lblFromCCPerson = New System.Windows.Forms.Label
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
      Me.btnFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnFromCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblFromCC = New System.Windows.Forms.Label
      Me.btnFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtRVCodeEnd = New System.Windows.Forms.TextBox
      Me.lblRVEnd = New System.Windows.Forms.Label
      Me.txtRVCodeStart = New System.Windows.Forms.TextBox
      Me.lblRVStart = New System.Windows.Forms.Label
      Me.btnRVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnRVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
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
      Me.txtCode.Location = New System.Drawing.Point(112, 16)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(232, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbItem)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(760, 224)
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
      Me.grbDocDate.Location = New System.Drawing.Point(416, 112)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(224, 72)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(80, 14)
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateStart.TabIndex = 6
      Me.txtDocDateStart.Text = ""
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(80, 38)
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateEnd.TabIndex = 7
      Me.txtDocDateEnd.Text = ""
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(24, 15)
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
      Me.lblDocDateEnd.Location = New System.Drawing.Point(24, 39)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(80, 14)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 10
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(80, 38)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 11
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(680, 192)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(600, 192)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.lblLci)
      Me.grbItem.Controls.Add(Me.lblBlank)
      Me.grbItem.Controls.Add(Me.txtBlank)
      Me.grbItem.Controls.Add(Me.ibtnShowLCIDialog)
      Me.grbItem.Controls.Add(Me.ibtnShowLCI)
      Me.grbItem.Controls.Add(Me.txtLCI)
      Me.grbItem.Controls.Add(Me.txtLCIName)
      Me.grbItem.Controls.Add(Me.txtToolName)
      Me.grbItem.Controls.Add(Me.ibtnShowTool)
      Me.grbItem.Controls.Add(Me.lblTool)
      Me.grbItem.Controls.Add(Me.ibtnShowToolDialog)
      Me.grbItem.Controls.Add(Me.txtTool)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(416, 16)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(336, 96)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "สิ่งที่ขาย"
      '
      'lblLci
      '
      Me.lblLci.Location = New System.Drawing.Point(8, 16)
      Me.lblLci.Name = "lblLci"
      Me.lblLci.Size = New System.Drawing.Size(72, 23)
      Me.lblLci.TabIndex = 210
      Me.lblLci.Text = "วัสดุ:"
      Me.lblLci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBlank
      '
      Me.lblBlank.BackColor = System.Drawing.Color.Transparent
      Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBlank.Location = New System.Drawing.Point(8, 64)
      Me.lblBlank.Name = "lblBlank"
      Me.lblBlank.Size = New System.Drawing.Size(72, 18)
      Me.lblBlank.TabIndex = 208
      Me.lblBlank.Text = "Blank:"
      Me.lblBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBlank
      '
      Me.Validator.SetDataType(Me.txtBlank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBlank, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.txtBlank.Location = New System.Drawing.Point(80, 64)
      Me.Validator.SetMaxValue(Me.txtBlank, "")
      Me.Validator.SetMinValue(Me.txtBlank, "")
      Me.txtBlank.Name = "txtBlank"
      Me.Validator.SetRegularExpression(Me.txtBlank, "")
      Me.Validator.SetRequired(Me.txtBlank, False)
      Me.txtBlank.Size = New System.Drawing.Size(248, 20)
      Me.txtBlank.TabIndex = 2
      Me.txtBlank.Text = ""
      '
      'ibtnShowLCIDialog
      '
      Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowLCIDialog.Image = CType(resources.GetObject("ibtnShowLCIDialog.Image"), System.Drawing.Image)
      Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(280, 16)
      Me.ibtnShowLCIDialog.Name = "ibtnShowLCIDialog"
      Me.ibtnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCIDialog.TabIndex = 206
      Me.ibtnShowLCIDialog.TabStop = False
      Me.ibtnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibtnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowLCI
      '
      Me.ibtnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCI.Image = CType(resources.GetObject("ibtnShowLCI.Image"), System.Drawing.Image)
      Me.ibtnShowLCI.Location = New System.Drawing.Point(304, 16)
      Me.ibtnShowLCI.Name = "ibtnShowLCI"
      Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCI.TabIndex = 205
      Me.ibtnShowLCI.TabStop = False
      Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLCI
      '
      Me.Validator.SetDataType(Me.txtLCI, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCI, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.txtLCI.Location = New System.Drawing.Point(80, 16)
      Me.Validator.SetMaxValue(Me.txtLCI, "")
      Me.Validator.SetMinValue(Me.txtLCI, "")
      Me.txtLCI.Name = "txtLCI"
      Me.Validator.SetRegularExpression(Me.txtLCI, "")
      Me.Validator.SetRequired(Me.txtLCI, False)
      Me.txtLCI.Size = New System.Drawing.Size(80, 20)
      Me.txtLCI.TabIndex = 0
      Me.txtLCI.Text = ""
      '
      'txtLCIName
      '
      Me.Validator.SetDataType(Me.txtLCIName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCIName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.txtLCIName.Location = New System.Drawing.Point(160, 16)
      Me.Validator.SetMaxValue(Me.txtLCIName, "")
      Me.Validator.SetMinValue(Me.txtLCIName, "")
      Me.txtLCIName.Name = "txtLCIName"
      Me.txtLCIName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLCIName, "")
      Me.Validator.SetRequired(Me.txtLCIName, False)
      Me.txtLCIName.Size = New System.Drawing.Size(120, 20)
      Me.txtLCIName.TabIndex = 204
      Me.txtLCIName.TabStop = False
      Me.txtLCIName.Text = ""
      '
      'txtToolName
      '
      Me.Validator.SetDataType(Me.txtToolName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.txtToolName.Location = New System.Drawing.Point(160, 40)
      Me.Validator.SetMaxValue(Me.txtToolName, "")
      Me.Validator.SetMinValue(Me.txtToolName, "")
      Me.txtToolName.Name = "txtToolName"
      Me.txtToolName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToolName, "")
      Me.Validator.SetRequired(Me.txtToolName, False)
      Me.txtToolName.Size = New System.Drawing.Size(120, 20)
      Me.txtToolName.TabIndex = 204
      Me.txtToolName.TabStop = False
      Me.txtToolName.Text = ""
      '
      'ibtnShowTool
      '
      Me.ibtnShowTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowTool.Image = CType(resources.GetObject("ibtnShowTool.Image"), System.Drawing.Image)
      Me.ibtnShowTool.Location = New System.Drawing.Point(304, 40)
      Me.ibtnShowTool.Name = "ibtnShowTool"
      Me.ibtnShowTool.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowTool.TabIndex = 205
      Me.ibtnShowTool.TabStop = False
      Me.ibtnShowTool.ThemedImage = CType(resources.GetObject("ibtnShowTool.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTool
      '
      Me.lblTool.Location = New System.Drawing.Point(8, 40)
      Me.lblTool.Name = "lblTool"
      Me.lblTool.Size = New System.Drawing.Size(72, 23)
      Me.lblTool.TabIndex = 209
      Me.lblTool.Text = "เครื่องมือ:"
      Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToolDialog
      '
      Me.ibtnShowToolDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToolDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToolDialog.Image = CType(resources.GetObject("ibtnShowToolDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToolDialog.Location = New System.Drawing.Point(280, 40)
      Me.ibtnShowToolDialog.Name = "ibtnShowToolDialog"
      Me.ibtnShowToolDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToolDialog.TabIndex = 206
      Me.ibtnShowToolDialog.TabStop = False
      Me.ibtnShowToolDialog.ThemedImage = CType(resources.GetObject("ibtnShowToolDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTool
      '
      Me.Validator.SetDataType(Me.txtTool, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTool, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.txtTool.Location = New System.Drawing.Point(80, 40)
      Me.Validator.SetMaxValue(Me.txtTool, "")
      Me.Validator.SetMinValue(Me.txtTool, "")
      Me.txtTool.Name = "txtTool"
      Me.Validator.SetRegularExpression(Me.txtTool, "")
      Me.Validator.SetRequired(Me.txtTool, False)
      Me.txtTool.Size = New System.Drawing.Size(80, 20)
      Me.txtTool.TabIndex = 1
      Me.txtTool.Text = ""
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.txtRVCodeEnd)
      Me.grbMainDetail.Controls.Add(Me.lblRVEnd)
      Me.grbMainDetail.Controls.Add(Me.txtRVCodeStart)
      Me.grbMainDetail.Controls.Add(Me.lblRVStart)
      Me.grbMainDetail.Controls.Add(Me.btnRVStartFind)
      Me.grbMainDetail.Controls.Add(Me.btnRVEndFind)
      Me.grbMainDetail.Controls.Add(Me.btnCustomerPanel)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerCode)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerName)
      Me.grbMainDetail.Controls.Add(Me.btnCustomerDialog)
      Me.grbMainDetail.Controls.Add(Me.lblCustomer)
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbMainDetail.Controls.Add(Me.btnFromCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonName)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblFromCCPerson)
      Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnFromCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.btnFromCCPersonPanel)
      Me.grbMainDetail.Controls.Add(Me.lblFromCC)
      Me.grbMainDetail.Controls.Add(Me.btnFromCCPersonDialog)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(400, 168)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'btnCustomerPanel
      '
      Me.btnCustomerPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerPanel.Image = CType(resources.GetObject("btnCustomerPanel.Image"), System.Drawing.Image)
      Me.btnCustomerPanel.Location = New System.Drawing.Point(368, 110)
      Me.btnCustomerPanel.Name = "btnCustomerPanel"
      Me.btnCustomerPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerPanel.TabIndex = 206
      Me.btnCustomerPanel.TabStop = False
      Me.btnCustomerPanel.ThemedImage = CType(resources.GetObject("btnCustomerPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustomerCode
      '
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(112, 112)
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(80, 20)
      Me.txtCustomerCode.TabIndex = 4
      Me.txtCustomerCode.Text = ""
      '
      'txtCustomerName
      '
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(192, 111)
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(152, 20)
      Me.txtCustomerName.TabIndex = 205
      Me.txtCustomerName.TabStop = False
      Me.txtCustomerName.Text = ""
      '
      'btnCustomerDialog
      '
      Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustomerDialog.Image = CType(resources.GetObject("btnCustomerDialog.Image"), System.Drawing.Image)
      Me.btnCustomerDialog.Location = New System.Drawing.Point(344, 110)
      Me.btnCustomerDialog.Name = "btnCustomerDialog"
      Me.btnCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerDialog.TabIndex = 207
      Me.btnCustomerDialog.TabStop = False
      Me.btnCustomerDialog.ThemedImage = CType(resources.GetObject("btnCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustomer
      '
      Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCustomer.Location = New System.Drawing.Point(8, 112)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(104, 18)
      Me.lblCustomer.TabIndex = 204
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(112, 88)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(280, 21)
      Me.cmbStatus.TabIndex = 3
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(8, 88)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(104, 18)
      Me.lblStatus.TabIndex = 197
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(112, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, False)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtFromCCPersonCode.TabIndex = 1
      Me.txtFromCCPersonCode.Text = ""
      '
      'btnFromCostCenterPanel
      '
      Me.btnFromCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCostCenterPanel.Image = CType(resources.GetObject("btnFromCostCenterPanel.Image"), System.Drawing.Image)
      Me.btnFromCostCenterPanel.Location = New System.Drawing.Point(368, 64)
      Me.btnFromCostCenterPanel.Name = "btnFromCostCenterPanel"
      Me.btnFromCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnFromCostCenterPanel.TabIndex = 199
      Me.btnFromCostCenterPanel.TabStop = False
      Me.btnFromCostCenterPanel.ThemedImage = CType(resources.GetObject("btnFromCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtFromCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(112, 64)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, False)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtFromCostCenterCode.TabIndex = 2
      Me.txtFromCostCenterCode.Text = ""
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(192, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(152, 20)
      Me.txtFromCCPersonName.TabIndex = 196
      Me.txtFromCCPersonName.TabStop = False
      Me.txtFromCCPersonName.Text = ""
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(104, 18)
      Me.lblFromCCPerson.TabIndex = 191
      Me.lblFromCCPerson.Text = "ผู้รับ:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(192, 64)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(152, 20)
      Me.txtFromCostCenterName.TabIndex = 196
      Me.txtFromCostCenterName.TabStop = False
      Me.txtFromCostCenterName.Text = ""
      '
      'btnFromCostCenterDialog
      '
      Me.btnFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFromCostCenterDialog.Image = CType(resources.GetObject("btnFromCostCenterDialog.Image"), System.Drawing.Image)
      Me.btnFromCostCenterDialog.Location = New System.Drawing.Point(344, 64)
      Me.btnFromCostCenterDialog.Name = "btnFromCostCenterDialog"
      Me.btnFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnFromCostCenterDialog.TabIndex = 201
      Me.btnFromCostCenterDialog.TabStop = False
      Me.btnFromCostCenterDialog.ThemedImage = CType(resources.GetObject("btnFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnFromCCPersonPanel
      '
      Me.btnFromCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCCPersonPanel.Image = CType(resources.GetObject("btnFromCCPersonPanel.Image"), System.Drawing.Image)
      Me.btnFromCCPersonPanel.Location = New System.Drawing.Point(368, 40)
      Me.btnFromCCPersonPanel.Name = "btnFromCCPersonPanel"
      Me.btnFromCCPersonPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnFromCCPersonPanel.TabIndex = 200
      Me.btnFromCCPersonPanel.TabStop = False
      Me.btnFromCCPersonPanel.ThemedImage = CType(resources.GetObject("btnFromCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblFromCC
      '
      Me.lblFromCC.BackColor = System.Drawing.Color.Transparent
      Me.lblFromCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFromCC.Location = New System.Drawing.Point(8, 64)
      Me.lblFromCC.Name = "lblFromCC"
      Me.lblFromCC.Size = New System.Drawing.Size(104, 18)
      Me.lblFromCC.TabIndex = 192
      Me.lblFromCC.Text = "CostCenter:"
      Me.lblFromCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnFromCCPersonDialog
      '
      Me.btnFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFromCCPersonDialog.Image = CType(resources.GetObject("btnFromCCPersonDialog.Image"), System.Drawing.Image)
      Me.btnFromCCPersonDialog.Location = New System.Drawing.Point(344, 40)
      Me.btnFromCCPersonDialog.Name = "btnFromCCPersonDialog"
      Me.btnFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnFromCCPersonDialog.TabIndex = 202
      Me.btnFromCCPersonDialog.TabStop = False
      Me.btnFromCCPersonDialog.ThemedImage = CType(resources.GetObject("btnFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
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
      'txtRVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtRVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRVCodeEnd, "")
      Me.txtRVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
      Me.txtRVCodeEnd.Location = New System.Drawing.Point(272, 135)
      Me.Validator.SetMaxValue(Me.txtRVCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtRVCodeEnd, "")
      Me.txtRVCodeEnd.Name = "txtRVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtRVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtRVCodeEnd, False)
      Me.txtRVCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtRVCodeEnd.TabIndex = 219
      Me.txtRVCodeEnd.Text = ""
      '
      'lblRVEnd
      '
      Me.lblRVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblRVEnd.Location = New System.Drawing.Point(248, 135)
      Me.lblRVEnd.Name = "lblRVEnd"
      Me.lblRVEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblRVEnd.TabIndex = 223
      Me.lblRVEnd.Text = "ถึง:"
      Me.lblRVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtRVCodeStart
      '
      Me.Validator.SetDataType(Me.txtRVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRVCodeStart, "")
      Me.txtRVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
      Me.txtRVCodeStart.Location = New System.Drawing.Point(112, 135)
      Me.Validator.SetMaxValue(Me.txtRVCodeStart, "")
      Me.Validator.SetMinValue(Me.txtRVCodeStart, "")
      Me.txtRVCodeStart.Name = "txtRVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtRVCodeStart, "")
      Me.Validator.SetRequired(Me.txtRVCodeStart, False)
      Me.txtRVCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtRVCodeStart.TabIndex = 218
      Me.txtRVCodeStart.Text = ""
      '
      'lblRVStart
      '
      Me.lblRVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRVStart.ForeColor = System.Drawing.Color.Black
      Me.lblRVStart.Location = New System.Drawing.Point(16, 135)
      Me.lblRVStart.Name = "lblRVStart"
      Me.lblRVStart.Size = New System.Drawing.Size(94, 18)
      Me.lblRVStart.TabIndex = 222
      Me.lblRVStart.Text = "ตั้งแต่ใบสำคัญรับ:"
      Me.lblRVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnRVStartFind
      '
      Me.btnRVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRVStartFind.Image = CType(resources.GetObject("btnRVStartFind.Image"), System.Drawing.Image)
      Me.btnRVStartFind.Location = New System.Drawing.Point(208, 135)
      Me.btnRVStartFind.Name = "btnRVStartFind"
      Me.btnRVStartFind.Size = New System.Drawing.Size(24, 23)
      Me.btnRVStartFind.TabIndex = 220
      Me.btnRVStartFind.TabStop = False
      Me.btnRVStartFind.ThemedImage = CType(resources.GetObject("btnRVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnRVEndFind
      '
      Me.btnRVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRVEndFind.Image = CType(resources.GetObject("btnRVEndFind.Image"), System.Drawing.Image)
      Me.btnRVEndFind.Location = New System.Drawing.Point(368, 135)
      Me.btnRVEndFind.Name = "btnRVEndFind"
      Me.btnRVEndFind.Size = New System.Drawing.Size(24, 23)
      Me.btnRVEndFind.TabIndex = 221
      Me.btnRVEndFind.TabStop = False
      Me.btnRVEndFind.ThemedImage = CType(resources.GetObject("btnRVEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'AssetWriteoffFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "AssetWriteoffFilterSubPanel"
      Me.Size = New System.Drawing.Size(784, 240)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbItem.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
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

#Region " SetLabelText "
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteoffFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblDocDateEnd}")
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblFromCCPerson}")
      Me.lblFromCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblFromCC}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblStatus}")
      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.grbItem}")
      Me.lblLci.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblLci}")
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblTool}")
      Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblBlank}")
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblCustomer}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.grbMainDetail}")
      Me.lblRVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblRVStart}")
      Me.lblRVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldFilterSubPanel.lblRVEnd}")
    End Sub
#End Region

#Region "Members"
    Private m_fromccperson As Employee
    Private m_fromcc As CostCenter
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private m_customer As Customer
    Private docDateStart As Date
    Private docDateEnd As Date
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
      Me.txtFromCostCenterCode.Text = ""
      Me.txtFromCostCenterName.Text = ""
      Me.m_fromcc = New CostCenter

      Me.txtFromCCPersonCode.Text = ""
      Me.txtFromCCPersonName.Text = ""
      Me.m_fromccperson = New Employee

      Me.txtCustomerCode.Text = ""
      Me.txtCustomerName.Text = ""
      Me.m_customer = New Customer

      Me.txtLCI.Text = ""
      Me.txtLCIName.Text = ""
      Me.m_lci = New LCIItem

      Me.txtTool.Text = ""
      Me.txtToolName.Text = ""
      Me.m_tool = New Tool

      Me.txtBlank.Text = ""

      Me.dtpDocDateStart.Value = Now.Date
      Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = ""
      Me.txtDocDateEnd.Text = ""

      Me.docDateStart = Date.MinValue
      Me.docDateEnd = Date.MinValue

      Me.txtRVCodeStart.Text = ""
      Me.txtRVCodeEnd.Text = ""

      cmbStatus.SelectedIndex = 0
      EntityRefresh()
    End Sub
    Private Sub PopulateStatus()
      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodssold_status", True)
    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(11) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("fromccperson_id", IIf(Me.m_fromccperson.Originated, Me.m_fromccperson.Id, DBNull.Value))
      arr(2) = New Filter("fromcc_id", IIf(Me.m_fromcc.Originated, Me.m_fromcc.Id, DBNull.Value))
      arr(3) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(4) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(5) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(6) = New Filter("lci_id", IIf(Me.m_lci.Originated, Me.m_lci.Id, DBNull.Value))
      arr(7) = New Filter("tool_id", IIf(Me.m_tool.Originated, Me.m_tool.Id, DBNull.Value))
      arr(8) = New Filter("stocki_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      arr(9) = New Filter("cust_id", IIf(Me.m_customer.Originated, Me.m_customer.Id, DBNull.Value))
      arr(10) = New Filter("RVCodeStart", IIf(txtRVCodeStart.TextLength > 0, txtRVCodeStart.Text, DBNull.Value))
      arr(11) = New Filter("RVCodeEnd", IIf(txtRVCodeEnd.TextLength > 0, txtRVCodeEnd.Text, DBNull.Value))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtFromCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCCPersonCode.Validated
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromccperson)
    End Sub
    Private Sub txtFromCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCostCenterCode.Validated
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromcc)
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
      LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub SetLCi(ByVal e As ISimpleEntity)
      Me.txtLCI.Text = e.Code
      LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub txtTool_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTool.Validated
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    End Sub
    Private Sub SetTool(ByVal e As ISimpleEntity)
      Me.txtTool.Text = e.Code
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
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
    Private Sub btnFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromCCPerson)
    End Sub
    Private Sub SetFromCCPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromccperson)
    End Sub
    Private Sub btnFromCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromCCPersonPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromcc)
    End Sub
    Private Sub btnFromCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
      Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
    End Sub
    Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
    End Sub
    Private Sub btnCustomerPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub SetCustomer(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
    End Sub
    Private Sub btnRVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRVStartFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVStartDialog)
    End Sub
    Private Sub btnRVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRVEndFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVEndDialog)
    End Sub
    Private Sub SetRVStartDialog(ByVal e As ISimpleEntity)
      Me.txtRVCodeStart.Text = e.Code
    End Sub
    Private Sub SetRVEndDialog(ByVal e As ISimpleEntity)
      Me.txtRVCodeEnd.Text = e.Code
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
            Case "txtfromcostcentercode", "txtfromcostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtfromccpersoncode", "txtfromccpersonname"
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
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtfromcostcentercode", "txtfromcostcentername"
            Me.SetFromCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtfromccpersoncode", "txtfromccpersonname"
            Me.SetFromCCPerson(entity)
        End Select
      End If
      If data.GetDataPresent((New LCIItem).FullClassName) Then
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

        If TypeOf entity Is AssetWriteOff Then
          Dim obj As AssetWriteOff
          obj = CType(entity, AssetWriteOff)
          ' Customer ...
          If obj.Customer.Originated Then
            Me.SetCustomer(obj.Customer)
            Me.txtCustomerCode.Enabled = False
            Me.txtCustomerName.Enabled = False
            Me.btnCustomerDialog.Enabled = False
            Me.btnCustomerPanel.Enabled = False
          End If
        End If
        If TypeOf entity Is Customer Then
          Me.SetCustomer(entity)
          Me.txtCustomerCode.Enabled = False
          Me.txtCustomerName.Enabled = False
          Me.btnCustomerDialog.Enabled = False
          Me.btnCustomerPanel.Enabled = False
        End If
      Next
    End Sub



  End Class
End Namespace

