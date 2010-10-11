Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PaySelectionFilterSubPanel
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
    Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPVEnd As System.Windows.Forms.Label
    Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPVStart As System.Windows.Forms.Label
    Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaySelectionFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtPVCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblPVEnd = New System.Windows.Forms.Label()
      Me.txtPVCodeStart = New System.Windows.Forms.TextBox()
      Me.lblPVStart = New System.Windows.Forms.Label()
      Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
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
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 6
      Me.lblCode.Text = "เลขที่เอกสาร:"
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
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(264, 21)
      Me.txtCode.TabIndex = 1
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(632, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(408, 16)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(200, 72)
      Me.grbDocDate.TabIndex = 2
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่เอกสาร"
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateStart.TabIndex = 11
      Me.lblDocDateStart.Text = "Start Date:"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateEnd.TabIndex = 11
      Me.lblDocDateEnd.Text = "End Date:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(80, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(114, 20)
      Me.dtpDocDateStart.TabIndex = 0
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(80, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(114, 20)
      Me.dtpDocDateEnd.TabIndex = 1
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(544, 128)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(464, 128)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.txtPVCodeEnd)
      Me.grbMainDetail.Controls.Add(Me.lblPVEnd)
      Me.grbMainDetail.Controls.Add(Me.txtPVCodeStart)
      Me.grbMainDetail.Controls.Add(Me.lblPVStart)
      Me.grbMainDetail.Controls.Add(Me.btnPVStartFind)
      Me.grbMainDetail.Controls.Add(Me.btnPVEndFind)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
      Me.grbMainDetail.Controls.Add(Me.lblSupplier)
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(392, 120)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'txtPVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.txtPVCodeEnd.Location = New System.Drawing.Point(259, 64)
      Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
      Me.txtPVCodeEnd.Size = New System.Drawing.Size(92, 21)
      Me.txtPVCodeEnd.TabIndex = 218
      '
      'lblPVEnd
      '
      Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPVEnd.Location = New System.Drawing.Point(238, 64)
      Me.lblPVEnd.Name = "lblPVEnd"
      Me.lblPVEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblPVEnd.TabIndex = 219
      Me.lblPVEnd.Text = "ถึง:"
      Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtPVCodeStart
      '
      Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.txtPVCodeStart.Location = New System.Drawing.Point(112, 64)
      Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Name = "txtPVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
      Me.Validator.SetRequired(Me.txtPVCodeStart, False)
      Me.txtPVCodeStart.Size = New System.Drawing.Size(92, 21)
      Me.txtPVCodeStart.TabIndex = 3
      '
      'lblPVStart
      '
      Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVStart.ForeColor = System.Drawing.Color.Black
      Me.lblPVStart.Location = New System.Drawing.Point(16, 64)
      Me.lblPVStart.Name = "lblPVStart"
      Me.lblPVStart.Size = New System.Drawing.Size(94, 18)
      Me.lblPVStart.TabIndex = 217
      Me.lblPVStart.Text = "ตั้งแต่ใบสำคัญจ่าย:"
      Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnPVStartFind
      '
      Me.btnPVStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVStartFind.Location = New System.Drawing.Point(204, 64)
      Me.btnPVStartFind.Name = "btnPVStartFind"
      Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVStartFind.TabIndex = 214
      Me.btnPVStartFind.TabStop = False
      Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnPVEndFind
      '
      Me.btnPVEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVEndFind.Location = New System.Drawing.Point(352, 64)
      Me.btnPVEndFind.Name = "btnPVEndFind"
      Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVEndFind.TabIndex = 215
      Me.btnPVEndFind.TabStop = False
      Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSupplierPanel
      '
      Me.btnSupplierPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierPanel.Location = New System.Drawing.Point(352, 40)
      Me.btnSupplierPanel.Name = "btnSupplierPanel"
      Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierPanel.TabIndex = 212
      Me.btnSupplierPanel.TabStop = False
      Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(112, 40)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
      Me.txtSupplierCode.TabIndex = 2
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(192, 40)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(136, 20)
      Me.txtSupplierName.TabIndex = 211
      Me.txtSupplierName.TabStop = False
      '
      'btnSupplierDialog
      '
      Me.btnSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierDialog.Location = New System.Drawing.Point(328, 40)
      Me.btnSupplierDialog.Name = "btnSupplierDialog"
      Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierDialog.TabIndex = 213
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
      Me.lblSupplier.Size = New System.Drawing.Size(104, 18)
      Me.lblSupplier.TabIndex = 210
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(112, 88)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(264, 21)
      Me.cmbStatus.TabIndex = 4
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
      'txtDocDateStart
      '
      Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(80, 16)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 20)
      Me.txtDocDateStart.TabIndex = 1
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(80, 40)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 20)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'PaySelectionFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "PaySelectionFilterSubPanel"
      Me.Size = New System.Drawing.Size(656, 176)
      Me.grbDetail.ResumeLayout(False)
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
    Private m_supplier As Supplier
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

      Me.txtSupplierCode.Text = ""
      Me.txtSupplierName.Text = ""
      Me.m_supplier = New Supplier

      Me.txtPVCodeStart.Text = ""
      Me.txtPVCodeEnd.Text = ""

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, -7, Now.Date)
      Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -7, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

      Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.docDateEnd = Now.Date

      'Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
      'Me.dtpDocDateEnd.Value = Now.Date

      cmbStatus.SelectedIndex = 0
    End Sub
    Private Sub PopulateStatus()
      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "pays_status", True)
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblDocDateEnd}")
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblSupplier}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblStatus}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.grbMainDetail}")
      Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblPVStart}")
      Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionFilterSubPanel.lblPVEnd}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("supplier_id", IIf(Me.m_supplier.Originated, Me.m_supplier.Id, DBNull.Value))
      arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(4) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(5) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
      arr(6) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
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

#Region "IClipboardHandler Overrides" 'Undone
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
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtsuppliercode", "txtsuppliername"
            Me.SetSupplier(entity)
        End Select
      End If
    End Sub
#End Region

  End Class
End Namespace

