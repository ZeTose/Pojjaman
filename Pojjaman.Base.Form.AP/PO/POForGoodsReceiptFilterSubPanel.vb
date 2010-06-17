Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class POForGoodsReceiptFilterSubPanel
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
    Friend WithEvents grbReceivingDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
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
    Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtReceivingDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivingdateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCC As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POForGoodsReceiptFilterSubPanel))
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
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCC = New System.Windows.Forms.Label()
      Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbReceivingDate.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.txtCode.Size = New System.Drawing.Size(276, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbReceivingDate)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbItem)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 1)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(652, 209)
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
      Me.grbReceivingDate.Size = New System.Drawing.Size(243, 72)
      Me.grbReceivingDate.TabIndex = 3
      Me.grbReceivingDate.TabStop = False
      Me.grbReceivingDate.Text = "กำหนดส่งของ"
      '
      'txtReceivingdateEnd
      '
      Me.txtReceivingdateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceivingdateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtReceivingdateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivingdateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReceivingdateEnd, System.Drawing.Color.Empty)
      Me.txtReceivingdateEnd.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtReceivingdateEnd, "")
      Me.txtReceivingdateEnd.Name = "txtReceivingdateEnd"
      Me.Validator.SetRegularExpression(Me.txtReceivingdateEnd, "")
      Me.Validator.SetRequired(Me.txtReceivingdateEnd, False)
      Me.txtReceivingdateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtReceivingdateEnd.TabIndex = 1
      '
      'txtReceivingDateStart
      '
      Me.txtReceivingDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceivingDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtReceivingDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
      Me.txtReceivingDateStart.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtReceivingDateStart, "")
      Me.txtReceivingDateStart.Name = "txtReceivingDateStart"
      Me.Validator.SetRegularExpression(Me.txtReceivingDateStart, "")
      Me.Validator.SetRequired(Me.txtReceivingDateStart, False)
      Me.txtReceivingDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtReceivingDateStart.TabIndex = 0
      '
      'lblReceivingDateStart
      '
      Me.lblReceivingDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceivingDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblReceivingDateStart.Location = New System.Drawing.Point(32, 17)
      Me.lblReceivingDateStart.Name = "lblReceivingDateStart"
      Me.lblReceivingDateStart.Size = New System.Drawing.Size(64, 18)
      Me.lblReceivingDateStart.TabIndex = 2
      Me.lblReceivingDateStart.Text = "ตั้งแต่"
      Me.lblReceivingDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblReceivingDateEnd
      '
      Me.lblReceivingDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceivingDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblReceivingDateEnd.Location = New System.Drawing.Point(32, 41)
      Me.lblReceivingDateEnd.Name = "lblReceivingDateEnd"
      Me.lblReceivingDateEnd.Size = New System.Drawing.Size(64, 18)
      Me.lblReceivingDateEnd.TabIndex = 3
      Me.lblReceivingDateEnd.Text = "ถึง"
      Me.lblReceivingDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpReceivingDateStart
      '
      Me.dtpReceivingDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpReceivingDateStart.Location = New System.Drawing.Point(96, 16)
      Me.dtpReceivingDateStart.Name = "dtpReceivingDateStart"
      Me.dtpReceivingDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpReceivingDateStart.TabIndex = 4
      Me.dtpReceivingDateStart.TabStop = False
      '
      'dtpReceivingDateEnd
      '
      Me.dtpReceivingDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpReceivingDateEnd.Location = New System.Drawing.Point(96, 40)
      Me.dtpReceivingDateEnd.Name = "dtpReceivingDateEnd"
      Me.dtpReceivingDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpReceivingDateEnd.TabIndex = 5
      Me.dtpReceivingDateEnd.TabStop = False
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
      Me.grbDocDate.Location = New System.Drawing.Point(399, 13)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(243, 72)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(96, 16)
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(96, 40)
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
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
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
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(96, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 4
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(96, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(572, 177)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(492, 177)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 5
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
      Me.grbItem.Location = New System.Drawing.Point(8, 109)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(385, 93)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "สิ่งที่สั่งซื้อ"
      '
      'lblBlank
      '
      Me.lblBlank.BackColor = System.Drawing.Color.Transparent
      Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBlank.Location = New System.Drawing.Point(32, 64)
      Me.lblBlank.Name = "lblBlank"
      Me.lblBlank.Size = New System.Drawing.Size(64, 18)
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
      Me.txtBlank.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMinValue(Me.txtBlank, "")
      Me.txtBlank.Name = "txtBlank"
      Me.Validator.SetRegularExpression(Me.txtBlank, "")
      Me.Validator.SetRequired(Me.txtBlank, False)
      Me.txtBlank.Size = New System.Drawing.Size(280, 20)
      Me.txtBlank.TabIndex = 2
      '
      'ibtnShowLCIDialog
      '
      Me.ibtnShowLCIDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(327, 16)
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
      Me.ibtnShowLCI.Location = New System.Drawing.Point(351, 16)
      Me.ibtnShowLCI.Name = "ibtnShowLCI"
      Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCI.TabIndex = 9
      Me.ibtnShowLCI.TabStop = False
      Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblLCI
      '
      Me.lblLCI.BackColor = System.Drawing.Color.Transparent
      Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLCI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblLCI.Location = New System.Drawing.Point(32, 16)
      Me.lblLCI.Name = "lblLCI"
      Me.lblLCI.Size = New System.Drawing.Size(64, 18)
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
      Me.txtLCI.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtLCI, "")
      Me.txtLCI.Name = "txtLCI"
      Me.Validator.SetRegularExpression(Me.txtLCI, "")
      Me.Validator.SetRequired(Me.txtLCI, False)
      Me.txtLCI.Size = New System.Drawing.Size(80, 20)
      Me.txtLCI.TabIndex = 0
      '
      'txtLCIName
      '
      Me.Validator.SetDataType(Me.txtLCIName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCIName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.txtLCIName.Location = New System.Drawing.Point(176, 16)
      Me.Validator.SetMinValue(Me.txtLCIName, "")
      Me.txtLCIName.Name = "txtLCIName"
      Me.txtLCIName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLCIName, "")
      Me.Validator.SetRequired(Me.txtLCIName, False)
      Me.txtLCIName.Size = New System.Drawing.Size(152, 20)
      Me.txtLCIName.TabIndex = 6
      Me.txtLCIName.TabStop = False
      '
      'txtToolName
      '
      Me.Validator.SetDataType(Me.txtToolName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.txtToolName.Location = New System.Drawing.Point(176, 40)
      Me.Validator.SetMinValue(Me.txtToolName, "")
      Me.txtToolName.Name = "txtToolName"
      Me.txtToolName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToolName, "")
      Me.Validator.SetRequired(Me.txtToolName, False)
      Me.txtToolName.Size = New System.Drawing.Size(152, 20)
      Me.txtToolName.TabIndex = 7
      Me.txtToolName.TabStop = False
      '
      'ibtnShowTool
      '
      Me.ibtnShowTool.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowTool.Location = New System.Drawing.Point(351, 40)
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
      Me.lblTool.Location = New System.Drawing.Point(32, 40)
      Me.lblTool.Name = "lblTool"
      Me.lblTool.Size = New System.Drawing.Size(64, 18)
      Me.lblTool.TabIndex = 4
      Me.lblTool.Text = "Tool:"
      Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToolDialog
      '
      Me.ibtnShowToolDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToolDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToolDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToolDialog.Location = New System.Drawing.Point(327, 40)
      Me.ibtnShowToolDialog.Name = "ibtnShowToolDialog"
      Me.ibtnShowToolDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToolDialog.TabIndex = 10
      Me.ibtnShowToolDialog.TabStop = False
      Me.ibtnShowToolDialog.ThemedImage = CType(resources.GetObject("ibtnShowToolDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTool
      '
      Me.Validator.SetDataType(Me.txtTool, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTool, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.txtTool.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtTool, "")
      Me.txtTool.Name = "txtTool"
      Me.Validator.SetRegularExpression(Me.txtTool, "")
      Me.Validator.SetRequired(Me.txtTool, False)
      Me.txtTool.Size = New System.Drawing.Size(80, 20)
      Me.txtTool.TabIndex = 1
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.lblCC)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
      Me.grbMainDetail.Controls.Add(Me.lblSupplier)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 13)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 95)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'btnCostCenterPanel
      '
      Me.btnCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterPanel.Location = New System.Drawing.Point(350, 64)
      Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
      Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterPanel.TabIndex = 18
      Me.btnCostCenterPanel.TabStop = False
      Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 64)
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(176, 64)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(152, 20)
      Me.txtCostCenterName.TabIndex = 16
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
      Me.btnCostCenterDialog.TabIndex = 17
      Me.btnCostCenterDialog.TabStop = False
      Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCC
      '
      Me.lblCC.BackColor = System.Drawing.Color.Transparent
      Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCC.Location = New System.Drawing.Point(8, 64)
      Me.lblCC.Name = "lblCC"
      Me.lblCC.Size = New System.Drawing.Size(88, 18)
      Me.lblCC.TabIndex = 15
      Me.lblCC.Text = "CostCenter:"
      Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierPanel
      '
      Me.btnSupplierPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierPanel.Location = New System.Drawing.Point(350, 40)
      Me.btnSupplierPanel.Name = "btnSupplierPanel"
      Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierPanel.TabIndex = 8
      Me.btnSupplierPanel.TabStop = False
      Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
      Me.txtSupplierCode.TabIndex = 1
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(176, 40)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(152, 20)
      Me.txtSupplierName.TabIndex = 6
      Me.txtSupplierName.TabStop = False
      '
      'btnSupplierDialog
      '
      Me.btnSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierDialog.Location = New System.Drawing.Point(326, 40)
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
      Me.lblSupplier.Location = New System.Drawing.Point(8, 40)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(88, 18)
      Me.lblSupplier.TabIndex = 4
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'POForGoodsReceiptFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "POForGoodsReceiptFilterSubPanel"
      Me.Size = New System.Drawing.Size(666, 220)
      Me.grbDetail.ResumeLayout(False)
      Me.grbReceivingDate.ResumeLayout(False)
      Me.grbReceivingDate.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbItem.ResumeLayout(False)
      Me.grbItem.PerformLayout()
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
    Private m_supplier As Supplier
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private dummyCC As New CostCenter
    Private m_cc As CostCenter
    'Private m_Approver As Employee
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

      'PopulateStatus()
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

      Me.txtSupplierCode.Text = ""
      Me.txtSupplierName.Text = ""
      Me.m_supplier = New Supplier

      'Me.m_Approver = New Employee

      Me.txtLCI.Text = ""
      Me.txtLCIName.Text = ""
      Me.m_lci = New LCIItem

      Me.txtTool.Text = ""
      Me.txtToolName.Text = ""
      Me.m_tool = New Tool

      Me.txtBlank.Text = ""

      Dim poDocDateStartBeforeToday As Long = Configuration.GetConfig("PODocDateStartBeforeToday")
      Dim poDocDateEndAfterToday As Long = Configuration.GetConfig("PODocDateEndAfterToday")
      Dim poReceiveDateStartBeforeToday As Long = Configuration.GetConfig("POReceiveDateStartBeforeToday")
      Dim poReceiveDateEndAfterToday As Long = Configuration.GetConfig("POReceiveDateEndAfterToday")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, poDocDateEndAfterToday, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, poReceiveDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, poDocDateStartBeforeToday, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, poDocDateEndAfterToday, Now.Date), "")

      Me.docDateStart = DateAdd(DateInterval.Day, poDocDateStartBeforeToday, Now.Date)
      Me.docDateEnd = DateAdd(DateInterval.Day, poDocDateEndAfterToday, Now.Date)

      Me.dtpReceivingDateStart.Value = DateAdd(DateInterval.Day, poReceiveDateStartBeforeToday, Now.Date)
      Me.dtpReceivingDateEnd.Value = DateAdd(DateInterval.Day, poReceiveDateEndAfterToday, Now.Date)

      Me.txtReceivingDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, poReceiveDateStartBeforeToday, Now.Date), "")
      Me.txtReceivingdateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, poReceiveDateEndAfterToday, Now.Date), "")

      Me.receivingDateStart = DateAdd(DateInterval.Day, poReceiveDateStartBeforeToday, Now.Date)
      Me.receivingDateEnd = DateAdd(DateInterval.Day, poReceiveDateEndAfterToday, Now.Date)

      'cmbStatus.SelectedIndex = 0
      'Me.cmbApproveLevel.SelectedIndex = 0

      'Me.txtApprovePerson.Text = ""
      'Me.txtApprovePersonName.Text = ""
      Me.m_user = New User
    End Sub
    'Private Sub PopulateStatus()
    '  Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    '  Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
    '  Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
    '  Dim dt1 As DataTable

    '  CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "po_status", True)
    '  dt1 = CodeDescription.GetCodeList("reference_status")
    '  For Each row As DataRow In dt1.Rows
    '    Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
    '    cmbStatus.Items.Add(item)
    '  Next
    '  dt1 = CodeDescription.GetCodeList("approve_status")
    '  For Each row As DataRow In dt1.Rows
    '    Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
    '    cmbStatus.Items.Add(item)
    '  Next
    '  dt1 = CodeDescription.GetCodeList("close_status")
    '  For Each row As DataRow In dt1.Rows
    '    Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
    '    cmbStatus.Items.Add(item)
    '  Next

    '  cmbApproveLevel.Items.Clear()
    '  cmbApproveLevel.Items.Insert(0, New IdValuePair(-1, notAppear))
    '  For i As Integer = 0 To User.MaxLevel
    '    Dim item As New IdValuePair(i, lvString & Space(1) & i.ToString)
    '    cmbApproveLevel.Items.Add(item)
    '  Next
    'End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblDocDateEnd}")
      Me.lblReceivingDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblReceivingDateStart}")
      Me.lblReceivingDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblReceivingDateEnd}")
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblSupplier}")
      Me.grbReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbReceivingDate}")
      Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblCC}")
      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbItem}")
      Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblLCI}")
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblTool}")
      Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.lblBlank}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POFilterSubPanel.grbMainDetail}")

    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(10) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("supplier_id", IIf(Me.m_supplier.Valid, Me.m_supplier.Id, DBNull.Value))
      arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(4) = New Filter("receivingdatestart", ValidDateOrDBNull(receivingDateStart))
      arr(5) = New Filter("receivingdateend", ValidDateOrDBNull(receivingDateEnd))
      arr(6) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
      arr(7) = New Filter("tool_id", IIf(Me.m_tool.Valid, Me.m_tool.Id, DBNull.Value))
      arr(8) = New Filter("poi_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      arr(9) = New Filter("cc_id", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
      arr(10) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    'Private Sub txtApprovePerson_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '  User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    'End Sub
    Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
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
    'Private Sub SetUser(ByVal e As ISimpleEntity)
    '  Me.txtApprovePerson.Text = e.Code
    '  User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    'End Sub
    'Private Sub btnFineApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New User, AddressOf SetUser)
    'End Sub
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
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
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
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"   'Undone
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
            Case "txtapprovercode", "txtapprovername"
              Return True
          End Select
        End If
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
      If data.GetDataPresent((dummyCC).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtcostcentercode", "txtcostcentername"
            Me.SetCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtsuppliercode", "txtsuppliername"
            Me.SetSupplier(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtapprovercode", "txtapprovername"
            'Me.SetToCCPerson(entity)
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

#Region "Properties"
    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        For Each entity As ISimpleEntity In Value
          If TypeOf entity Is Supplier Then
            Me.SetSupplier(entity)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierDialog.Enabled = False
            Me.btnSupplierPanel.Enabled = False
          End If
          'If TypeOf entity Is PO Then
          '  If entity.Status.Value <> -1 Then
          '    CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
          '    Me.cmbStatus.Enabled = False
          '  End If
          'End If
          If TypeOf entity Is CostCenter Then
            Me.SetCostCenter(CType(entity, CostCenter))
            Me.txtCostCenterCode.Enabled = False
            Me.txtCostCenterName.Enabled = False
            Me.btnCostCenterDialog.Enabled = False
            Me.btnCostCenterPanel.Enabled = False
          End If
        Next
      End Set
    End Property
#End Region

  End Class
End Namespace

