Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GoodsReceiptForVatFilterSubPanel
    Inherits AbstractFilterSubPanel
    'Inherits UserControl
    
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
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents btnToCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblToCC As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents grbPV As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPVStart As System.Windows.Forms.Label
    Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPVEnd As System.Windows.Forms.Label
    Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsReceiptForVatFilterSubPanel))
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
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.btnToCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblToCC = New System.Windows.Forms.Label()
      Me.grbPV = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtPVCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblPVEnd = New System.Windows.Forms.Label()
      Me.txtPVCodeStart = New System.Windows.Forms.TextBox()
      Me.lblPVStart = New System.Windows.Forms.Label()
      Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.grbPV.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 18)
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
      Me.txtCode.Location = New System.Drawing.Point(144, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(224, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.Controls.Add(Me.grbPV)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(678, 198)
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
      Me.grbDocDate.Location = New System.Drawing.Point(390, 93)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(280, 72)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(96, 19)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(152, 20)
      Me.txtDocDateStart.TabIndex = 18
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(96, 43)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(152, 20)
      Me.txtDocDateEnd.TabIndex = 19
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(6, 20)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(90, 18)
      Me.lblDocDateStart.TabIndex = 8
      Me.lblDocDateStart.Text = "ตั้งแต่:"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(6, 44)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(90, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "ถึง:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(96, 19)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(170, 20)
      Me.dtpDocDateStart.TabIndex = 10
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(96, 43)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(170, 20)
      Me.dtpDocDateEnd.TabIndex = 11
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(595, 169)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 22
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(514, 169)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 23
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
      Me.grbMainDetail.Controls.Add(Me.lblSupplier)
      Me.grbMainDetail.Controls.Add(Me.btnToCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtToCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtToCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnToCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.lblToCC)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(376, 149)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'btnSupplierPanel
      '
      Me.btnSupplierPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierPanel.Location = New System.Drawing.Point(344, 64)
      Me.btnSupplierPanel.Name = "btnSupplierPanel"
      Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierPanel.TabIndex = 206
      Me.btnSupplierPanel.TabStop = False
      Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(144, 65)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
      Me.txtSupplierCode.TabIndex = 6
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(224, 65)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(96, 20)
      Me.txtSupplierName.TabIndex = 205
      Me.txtSupplierName.TabStop = False
      '
      'btnSupplierDialog
      '
      Me.btnSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierDialog.Location = New System.Drawing.Point(320, 64)
      Me.btnSupplierDialog.Name = "btnSupplierDialog"
      Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierDialog.TabIndex = 7
      Me.btnSupplierDialog.TabStop = False
      Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSupplier.Location = New System.Drawing.Point(16, 65)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(128, 18)
      Me.lblSupplier.TabIndex = 204
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnToCostCenterPanel
      '
      Me.btnToCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCostCenterPanel.Location = New System.Drawing.Point(344, 40)
      Me.btnToCostCenterPanel.Name = "btnToCostCenterPanel"
      Me.btnToCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnToCostCenterPanel.TabIndex = 199
      Me.btnToCostCenterPanel.TabStop = False
      Me.btnToCostCenterPanel.ThemedImage = CType(resources.GetObject("btnToCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(144, 41)
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtToCostCenterCode.TabIndex = 3
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(224, 41)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(96, 20)
      Me.txtToCostCenterName.TabIndex = 196
      Me.txtToCostCenterName.TabStop = False
      '
      'btnToCostCenterDialog
      '
      Me.btnToCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToCostCenterDialog.Location = New System.Drawing.Point(320, 40)
      Me.btnToCostCenterDialog.Name = "btnToCostCenterDialog"
      Me.btnToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnToCostCenterDialog.TabIndex = 4
      Me.btnToCostCenterDialog.TabStop = False
      Me.btnToCostCenterDialog.ThemedImage = CType(resources.GetObject("btnToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblToCC
      '
      Me.lblToCC.BackColor = System.Drawing.Color.Transparent
      Me.lblToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblToCC.Location = New System.Drawing.Point(16, 40)
      Me.lblToCC.Name = "lblToCC"
      Me.lblToCC.Size = New System.Drawing.Size(128, 22)
      Me.lblToCC.TabIndex = 192
      Me.lblToCC.Text = "CostCenter รับ:"
      Me.lblToCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbPV
      '
      Me.grbPV.Controls.Add(Me.txtPVCodeEnd)
      Me.grbPV.Controls.Add(Me.lblPVEnd)
      Me.grbPV.Controls.Add(Me.txtPVCodeStart)
      Me.grbPV.Controls.Add(Me.lblPVStart)
      Me.grbPV.Controls.Add(Me.btnPVStartFind)
      Me.grbPV.Controls.Add(Me.btnPVEndFind)
      Me.grbPV.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPV.Location = New System.Drawing.Point(390, 19)
      Me.grbPV.Name = "grbPV"
      Me.grbPV.Size = New System.Drawing.Size(280, 72)
      Me.grbPV.TabIndex = 2
      Me.grbPV.TabStop = False
      Me.grbPV.Text = "เลขที่ใบสำคัญจ่าย"
      '
      'txtPVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.txtPVCodeEnd.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
      Me.txtPVCodeEnd.Size = New System.Drawing.Size(146, 21)
      Me.txtPVCodeEnd.TabIndex = 16
      '
      'lblPVEnd
      '
      Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPVEnd.Location = New System.Drawing.Point(8, 40)
      Me.lblPVEnd.Name = "lblPVEnd"
      Me.lblPVEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblPVEnd.TabIndex = 209
      Me.lblPVEnd.Text = "ถึง:"
      Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPVCodeStart
      '
      Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.txtPVCodeStart.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Name = "txtPVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
      Me.Validator.SetRequired(Me.txtPVCodeStart, False)
      Me.txtPVCodeStart.Size = New System.Drawing.Size(146, 21)
      Me.txtPVCodeStart.TabIndex = 14
      '
      'lblPVStart
      '
      Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVStart.ForeColor = System.Drawing.Color.Black
      Me.lblPVStart.Location = New System.Drawing.Point(8, 16)
      Me.lblPVStart.Name = "lblPVStart"
      Me.lblPVStart.Size = New System.Drawing.Size(88, 18)
      Me.lblPVStart.TabIndex = 33
      Me.lblPVStart.Text = "ตั้งแต่:"
      Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnPVStartFind
      '
      Me.btnPVStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVStartFind.Location = New System.Drawing.Point(241, 15)
      Me.btnPVStartFind.Name = "btnPVStartFind"
      Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVStartFind.TabIndex = 15
      Me.btnPVStartFind.TabStop = False
      Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnPVEndFind
      '
      Me.btnPVEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVEndFind.Location = New System.Drawing.Point(241, 40)
      Me.btnPVEndFind.Name = "btnPVEndFind"
      Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVEndFind.TabIndex = 17
      Me.btnPVEndFind.TabStop = False
      Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
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
      'GoodsReceiptForVatFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "GoodsReceiptForVatFilterSubPanel"
      Me.Size = New System.Drawing.Size(693, 214)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      Me.grbPV.ResumeLayout(False)
      Me.grbPV.PerformLayout()
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
    Private m_toccperson As Employee
    Private m_tocc As CostCenter
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private m_supplier As Supplier
    Private docDateStart As Date
    Private docDateEnd As Date
    Private dueDateStart As Date
    Private dueDateEnd As Date
    Private receivingDateStart As Date
    Private receivingDateEnd As Date
    Private m_dummyCC As CostCenter
    Private m_dummyLCI As LCIItem

    Private m_asset As Asset
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
      Me.txtToCostCenterCode.Text = ""
      Me.txtToCostCenterName.Text = ""
      Me.m_tocc = New CostCenter

      Me.m_toccperson = New Employee

      Me.txtSupplierCode.Text = ""
      Me.txtSupplierName.Text = ""
      Me.m_supplier = New Supplier

      Me.m_lci = New LCIItem

      Me.m_tool = New Tool

      'Dim grDocDateStartBeforeToday As Long = Configuration.GetConfig("GRDocDateStartBeforeToday")
      'Dim grDocDateEndAfterToday As Long = Configuration.GetConfig("GRDocDateEndAfterToday")
      'Dim grDueDateStartBeforeToday As Long = Configuration.GetConfig("GRDueDateStartBeforeToday")
      'Dim grDueDateEndAfterToday As Long = Configuration.GetConfig("GRDueDateEndAfterToday")
      Dim grDocDateStartBeforeToday As Long = -15
      Dim grDocDateEndAfterToday As Long = 0
      Dim grDueDateStartBeforeToday As Long = -15
      Dim grDueDateEndAfterToday As Long = 15

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date), "")

      Me.docDateStart = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.docDateEnd = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.txtPVCodeStart.Text = ""
      Me.txtPVCodeEnd.Text = ""

      Me.dueDateStart = Date.MinValue
      Me.dueDateEnd = Date.MinValue

      EntityRefresh()
    End Sub
    Private Sub PopulateStatus()
      'CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodsreceipt_status", True)
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblDocDateEnd}")
      Me.lblToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblToCC}")
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblSupplier}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbMainDetail}")
      Me.grbPV.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbPV}")
      Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblPVStart}")
      Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblPVEnd}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(7) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("tocc_id", IIf(Me.m_tocc.Originated, Me.m_tocc.Id, DBNull.Value))
      arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(4) = New Filter("supplier_id", IIf(Me.m_supplier.Originated, Me.m_supplier.Id, DBNull.Value))
      arr(5) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
      arr(6) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
      arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
        Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCostCenterCode.Validated
      CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(DummyLCI)
    End Sub

    Private Sub ibtnShowTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Tool)
    End Sub
       Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(DummyCC)
    End Sub
    Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
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

#Region "Properties"
    Public ReadOnly Property DummyCC() As CostCenter      Get        If m_dummyCC Is Nothing Then          m_dummyCC = New CostCenter
        End If        Return m_dummyCC      End Get    End Property
    Public ReadOnly Property DummyLCI() As LCIItem      Get        If m_dummyLCI Is Nothing Then          m_dummyLCI = New LCIItem
        End If        Return m_dummyLCI      End Get    End Property#End Region

#Region "IClipboardHandler Overrides"         'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        If data.GetDataPresent((DummyCC).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttocostcentercode", "txttocostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttoccpersoncode", "txttoccpersonname"
              Return True
          End Select
        End If
        If data.GetDataPresent((DummyLCI).FullClassName) Then
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
      If data.GetDataPresent((DummyCC).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((DummyCC).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttocostcentercode", "txttocostcentername"
            Me.SetToCostCenter(entity)
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

        If TypeOf entity Is GoodsReceipt Then
          Dim obj As GoodsReceipt
          obj = CType(entity, GoodsReceipt)
          ' Supplier ...
          If obj.Supplier.Originated Then
            Me.SetSupplier(obj.Supplier)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierDialog.Enabled = False
            Me.btnSupplierPanel.Enabled = False
          End If
        End If
        If TypeOf entity Is APOpeningBalance Then
          Dim obj As APOpeningBalance
          obj = CType(entity, APOpeningBalance)
          ' Supplier ...
          If obj.Supplier.Originated Then
            Me.SetSupplier(obj.Supplier)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierDialog.Enabled = False
            Me.btnSupplierPanel.Enabled = False
          End If
        End If
        If TypeOf entity Is AdvancePay Then
          Dim obj As AdvancePay
          obj = CType(entity, AdvancePay)
          ' Supplier ...
          If obj.Supplier.Originated Then
            Me.SetSupplier(obj.Supplier)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierDialog.Enabled = False
            Me.btnSupplierPanel.Enabled = False
          End If
        End If
        If TypeOf entity Is Supplier Then
          Me.SetSupplier(entity)
          Me.txtSupplierCode.Enabled = False
          Me.txtSupplierName.Enabled = False
          Me.btnSupplierDialog.Enabled = False
          Me.btnSupplierPanel.Enabled = False
        End If
      Next
    End Sub
  End Class
End Namespace

