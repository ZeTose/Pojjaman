Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptOutgoingCheckEnumerateFilterSubPanel
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
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSupplierStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierStart As System.Windows.Forms.Label
    Friend WithEvents btnBankAcctStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAcctCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblBankAcctStart As System.Windows.Forms.Label
    Friend WithEvents cmbChkStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblChkStatus As System.Windows.Forms.Label
    Friend WithEvents btnBankAcctEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAcctCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblBankAcctEnd As System.Windows.Forms.Label
    Friend WithEvents txtBankAcctNameEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAcctNameStart As System.Windows.Forms.TextBox
    Friend WithEvents grbBankAcctBook As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtCheckDueDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpCheckDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCheckDueDateStart As System.Windows.Forms.Label
    Friend WithEvents dtpCheckDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCheckDueDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtCheckDueDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckPassDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpCheckPassDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCheckPassDateStart As System.Windows.Forms.Label
    Friend WithEvents lblCheckPassDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpCheckPassDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCheckPassDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSort As System.Windows.Forms.Label
    Friend WithEvents cmbSort As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptOutgoingCheckEnumerateFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbBankAcctBook = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtBankAcctNameStart = New System.Windows.Forms.TextBox
      Me.txtBankAcctCodeEnd = New System.Windows.Forms.TextBox
      Me.lblBankAcctEnd = New System.Windows.Forms.Label
      Me.txtBankAcctNameEnd = New System.Windows.Forms.TextBox
      Me.btnBankAcctEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnBankAcctStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBankAcctCodeStart = New System.Windows.Forms.TextBox
      Me.lblBankAcctStart = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblSort = New System.Windows.Forms.Label
      Me.cmbSort = New System.Windows.Forms.ComboBox
      Me.txtCheckDueDateEnd = New System.Windows.Forms.TextBox
      Me.lblChkStatus = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.btnSupplierStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSupplierCodeStart = New System.Windows.Forms.TextBox
      Me.lblSupplierStart = New System.Windows.Forms.Label
      Me.txtCheckDueDateStart = New System.Windows.Forms.TextBox
      Me.dtpCheckDueDateStart = New System.Windows.Forms.DateTimePicker
      Me.lblCheckDueDateStart = New System.Windows.Forms.Label
      Me.lblCheckDueDateEnd = New System.Windows.Forms.Label
      Me.dtpCheckDueDateEnd = New System.Windows.Forms.DateTimePicker
      Me.txtCheckPassDateStart = New System.Windows.Forms.TextBox
      Me.dtpCheckPassDateStart = New System.Windows.Forms.DateTimePicker
      Me.lblCheckPassDateStart = New System.Windows.Forms.Label
      Me.lblCheckPassDateEnd = New System.Windows.Forms.Label
      Me.txtCheckPassDateEnd = New System.Windows.Forms.TextBox
      Me.cmbChkStatus = New System.Windows.Forms.ComboBox
      Me.dtpCheckPassDateEnd = New System.Windows.Forms.DateTimePicker
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbMaster.SuspendLayout()
      Me.grbBankAcctBook.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbBankAcctBook)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(768, 176)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbBankAcctBook
      '
      Me.grbBankAcctBook.Controls.Add(Me.txtBankAcctNameStart)
      Me.grbBankAcctBook.Controls.Add(Me.txtBankAcctCodeEnd)
      Me.grbBankAcctBook.Controls.Add(Me.lblBankAcctEnd)
      Me.grbBankAcctBook.Controls.Add(Me.txtBankAcctNameEnd)
      Me.grbBankAcctBook.Controls.Add(Me.btnBankAcctEndFind)
      Me.grbBankAcctBook.Controls.Add(Me.btnBankAcctStartFind)
      Me.grbBankAcctBook.Controls.Add(Me.txtBankAcctCodeStart)
      Me.grbBankAcctBook.Controls.Add(Me.lblBankAcctStart)
      Me.grbBankAcctBook.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBankAcctBook.Location = New System.Drawing.Point(448, 16)
      Me.grbBankAcctBook.Name = "grbBankAcctBook"
      Me.grbBankAcctBook.Size = New System.Drawing.Size(312, 96)
      Me.grbBankAcctBook.TabIndex = 3
      Me.grbBankAcctBook.TabStop = False
      Me.grbBankAcctBook.Text = "ข้อมูลสมุดบัญชี"
      '
      'txtBankAcctNameStart
      '
      Me.Validator.SetDataType(Me.txtBankAcctNameStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctNameStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctNameStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctNameStart, System.Drawing.Color.Empty)
      Me.txtBankAcctNameStart.Location = New System.Drawing.Point(200, 24)
      Me.txtBankAcctNameStart.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtBankAcctNameStart, "")
      Me.Validator.SetMinValue(Me.txtBankAcctNameStart, "")
      Me.txtBankAcctNameStart.Name = "txtBankAcctNameStart"
      Me.txtBankAcctNameStart.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAcctNameStart, "")
      Me.Validator.SetRequired(Me.txtBankAcctNameStart, False)
      Me.txtBankAcctNameStart.Size = New System.Drawing.Size(104, 21)
      Me.txtBankAcctNameStart.TabIndex = 3
      Me.txtBankAcctNameStart.Text = ""
      '
      'txtBankAcctCodeEnd
      '
      Me.Validator.SetDataType(Me.txtBankAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctCodeEnd, "")
      Me.txtBankAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctCodeEnd, System.Drawing.Color.Empty)
      Me.txtBankAcctCodeEnd.Location = New System.Drawing.Point(80, 48)
      Me.txtBankAcctCodeEnd.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtBankAcctCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtBankAcctCodeEnd, "")
      Me.txtBankAcctCodeEnd.Name = "txtBankAcctCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtBankAcctCodeEnd, "")
      Me.Validator.SetRequired(Me.txtBankAcctCodeEnd, False)
      Me.txtBankAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtBankAcctCodeEnd.TabIndex = 1
      Me.txtBankAcctCodeEnd.Text = ""
      '
      'lblBankAcctEnd
      '
      Me.lblBankAcctEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAcctEnd.ForeColor = System.Drawing.Color.Black
      Me.lblBankAcctEnd.Location = New System.Drawing.Point(56, 48)
      Me.lblBankAcctEnd.Name = "lblBankAcctEnd"
      Me.lblBankAcctEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblBankAcctEnd.TabIndex = 3
      Me.lblBankAcctEnd.Text = "ถึง"
      Me.lblBankAcctEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtBankAcctNameEnd
      '
      Me.Validator.SetDataType(Me.txtBankAcctNameEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctNameEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctNameEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctNameEnd, System.Drawing.Color.Empty)
      Me.txtBankAcctNameEnd.Location = New System.Drawing.Point(200, 48)
      Me.txtBankAcctNameEnd.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtBankAcctNameEnd, "")
      Me.Validator.SetMinValue(Me.txtBankAcctNameEnd, "")
      Me.txtBankAcctNameEnd.Name = "txtBankAcctNameEnd"
      Me.txtBankAcctNameEnd.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAcctNameEnd, "")
      Me.Validator.SetRequired(Me.txtBankAcctNameEnd, False)
      Me.txtBankAcctNameEnd.Size = New System.Drawing.Size(104, 21)
      Me.txtBankAcctNameEnd.TabIndex = 3
      Me.txtBankAcctNameEnd.Text = ""
      '
      'btnBankAcctEndFind
      '
      Me.btnBankAcctEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcctEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAcctEndFind.Image = CType(resources.GetObject("btnBankAcctEndFind.Image"), System.Drawing.Image)
      Me.btnBankAcctEndFind.Location = New System.Drawing.Point(176, 48)
      Me.btnBankAcctEndFind.Name = "btnBankAcctEndFind"
      Me.btnBankAcctEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnBankAcctEndFind.TabIndex = 8
      Me.btnBankAcctEndFind.TabStop = False
      Me.btnBankAcctEndFind.ThemedImage = CType(resources.GetObject("btnBankAcctEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnBankAcctStartFind
      '
      Me.btnBankAcctStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcctStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAcctStartFind.Image = CType(resources.GetObject("btnBankAcctStartFind.Image"), System.Drawing.Image)
      Me.btnBankAcctStartFind.Location = New System.Drawing.Point(176, 24)
      Me.btnBankAcctStartFind.Name = "btnBankAcctStartFind"
      Me.btnBankAcctStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnBankAcctStartFind.TabIndex = 8
      Me.btnBankAcctStartFind.TabStop = False
      Me.btnBankAcctStartFind.ThemedImage = CType(resources.GetObject("btnBankAcctStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAcctCodeStart
      '
      Me.Validator.SetDataType(Me.txtBankAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctCodeStart, "")
      Me.txtBankAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctCodeStart, System.Drawing.Color.Empty)
      Me.txtBankAcctCodeStart.Location = New System.Drawing.Point(80, 24)
      Me.txtBankAcctCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtBankAcctCodeStart, "")
      Me.Validator.SetMinValue(Me.txtBankAcctCodeStart, "")
      Me.txtBankAcctCodeStart.Name = "txtBankAcctCodeStart"
      Me.Validator.SetRegularExpression(Me.txtBankAcctCodeStart, "")
      Me.Validator.SetRequired(Me.txtBankAcctCodeStart, False)
      Me.txtBankAcctCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtBankAcctCodeStart.TabIndex = 0
      Me.txtBankAcctCodeStart.Text = ""
      '
      'lblBankAcctStart
      '
      Me.lblBankAcctStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAcctStart.ForeColor = System.Drawing.Color.Black
      Me.lblBankAcctStart.Location = New System.Drawing.Point(8, 24)
      Me.lblBankAcctStart.Name = "lblBankAcctStart"
      Me.lblBankAcctStart.Size = New System.Drawing.Size(64, 18)
      Me.lblBankAcctStart.TabIndex = 6
      Me.lblBankAcctStart.Text = "สมุดบัญชี"
      Me.lblBankAcctStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.lblSort)
      Me.grbDetail.Controls.Add(Me.cmbSort)
      Me.grbDetail.Controls.Add(Me.txtCheckDueDateEnd)
      Me.grbDetail.Controls.Add(Me.lblChkStatus)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnSupplierStartFind)
      Me.grbDetail.Controls.Add(Me.txtSupplierCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSupplierStart)
      Me.grbDetail.Controls.Add(Me.txtCheckDueDateStart)
      Me.grbDetail.Controls.Add(Me.dtpCheckDueDateStart)
      Me.grbDetail.Controls.Add(Me.lblCheckDueDateStart)
      Me.grbDetail.Controls.Add(Me.lblCheckDueDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpCheckDueDateEnd)
      Me.grbDetail.Controls.Add(Me.txtCheckPassDateStart)
      Me.grbDetail.Controls.Add(Me.dtpCheckPassDateStart)
      Me.grbDetail.Controls.Add(Me.lblCheckPassDateStart)
      Me.grbDetail.Controls.Add(Me.lblCheckPassDateEnd)
      Me.grbDetail.Controls.Add(Me.txtCheckPassDateEnd)
      Me.grbDetail.Controls.Add(Me.cmbChkStatus)
      Me.grbDetail.Controls.Add(Me.dtpCheckPassDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(432, 152)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'lblSort
      '
      Me.lblSort.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSort.ForeColor = System.Drawing.Color.Black
      Me.lblSort.Location = New System.Drawing.Point(8, 120)
      Me.lblSort.Name = "lblSort"
      Me.lblSort.Size = New System.Drawing.Size(88, 18)
      Me.lblSort.TabIndex = 15
      Me.lblSort.Text = "เรียงข้อมูลตาม"
      Me.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbSort
      '
      Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSort.Location = New System.Drawing.Point(104, 120)
      Me.cmbSort.Name = "cmbSort"
      Me.cmbSort.TabIndex = 16
      '
      'txtCheckDueDateEnd
      '
      Me.Validator.SetDataType(Me.txtCheckDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCheckDueDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCheckDueDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCheckDueDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCheckDueDateEnd, System.Drawing.Color.Empty)
      Me.txtCheckDueDateEnd.Location = New System.Drawing.Point(296, 48)
      Me.txtCheckDueDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtCheckDueDateEnd, "")
      Me.Validator.SetMinValue(Me.txtCheckDueDateEnd, "")
      Me.txtCheckDueDateEnd.Name = "txtCheckDueDateEnd"
      Me.Validator.SetRegularExpression(Me.txtCheckDueDateEnd, "")
      Me.Validator.SetRequired(Me.txtCheckDueDateEnd, False)
      Me.txtCheckDueDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtCheckDueDateEnd.TabIndex = 3
      Me.txtCheckDueDateEnd.Text = ""
      '
      'lblChkStatus
      '
      Me.lblChkStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblChkStatus.ForeColor = System.Drawing.Color.Black
      Me.lblChkStatus.Location = New System.Drawing.Point(232, 96)
      Me.lblChkStatus.Name = "lblChkStatus"
      Me.lblChkStatus.Size = New System.Drawing.Size(56, 18)
      Me.lblChkStatus.TabIndex = 13
      Me.lblChkStatus.Text = "สถานะเช็ค"
      Me.lblChkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 24)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(104, 24)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 0
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 24)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 24)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 24)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่เอกสาร"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 24)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierStartFind
      '
      Me.btnSupplierStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierStartFind.Image = CType(resources.GetObject("btnSupplierStartFind.Image"), System.Drawing.Image)
      Me.btnSupplierStartFind.Location = New System.Drawing.Point(200, 96)
      Me.btnSupplierStartFind.Name = "btnSupplierStartFind"
      Me.btnSupplierStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierStartFind.TabIndex = 8
      Me.btnSupplierStartFind.TabStop = False
      Me.btnSupplierStartFind.ThemedImage = CType(resources.GetObject("btnSupplierStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCodeStart
      '
      Me.Validator.SetDataType(Me.txtSupplierCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.txtSupplierCodeStart.Location = New System.Drawing.Point(104, 96)
      Me.txtSupplierCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtSupplierCodeStart, "")
      Me.Validator.SetMinValue(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Name = "txtSupplierCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierCodeStart, "")
      Me.Validator.SetRequired(Me.txtSupplierCodeStart, False)
      Me.txtSupplierCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierCodeStart.TabIndex = 6
      Me.txtSupplierCodeStart.Text = ""
      '
      'lblSupplierStart
      '
      Me.lblSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierStart.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierStart.Location = New System.Drawing.Point(8, 96)
      Me.lblSupplierStart.Name = "lblSupplierStart"
      Me.lblSupplierStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSupplierStart.TabIndex = 6
      Me.lblSupplierStart.Text = "ผู้ขาย"
      Me.lblSupplierStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCheckDueDateStart
      '
      Me.Validator.SetDataType(Me.txtCheckDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCheckDueDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCheckDueDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCheckDueDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCheckDueDateStart, System.Drawing.Color.Empty)
      Me.txtCheckDueDateStart.Location = New System.Drawing.Point(104, 48)
      Me.txtCheckDueDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtCheckDueDateStart, "")
      Me.Validator.SetMinValue(Me.txtCheckDueDateStart, "")
      Me.txtCheckDueDateStart.Name = "txtCheckDueDateStart"
      Me.Validator.SetRegularExpression(Me.txtCheckDueDateStart, "")
      Me.Validator.SetRequired(Me.txtCheckDueDateStart, False)
      Me.txtCheckDueDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtCheckDueDateStart.TabIndex = 2
      Me.txtCheckDueDateStart.Text = ""
      '
      'dtpCheckDueDateStart
      '
      Me.dtpCheckDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpCheckDueDateStart.Location = New System.Drawing.Point(104, 48)
      Me.dtpCheckDueDateStart.Name = "dtpCheckDueDateStart"
      Me.dtpCheckDueDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpCheckDueDateStart.TabIndex = 2
      Me.dtpCheckDueDateStart.TabStop = False
      '
      'lblCheckDueDateStart
      '
      Me.lblCheckDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckDueDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblCheckDueDateStart.Location = New System.Drawing.Point(8, 48)
      Me.lblCheckDueDateStart.Name = "lblCheckDueDateStart"
      Me.lblCheckDueDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCheckDueDateStart.TabIndex = 0
      Me.lblCheckDueDateStart.Text = "ตั้งแต่วันที่บนเช็ค"
      Me.lblCheckDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCheckDueDateEnd
      '
      Me.lblCheckDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckDueDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCheckDueDateEnd.Location = New System.Drawing.Point(248, 48)
      Me.lblCheckDueDateEnd.Name = "lblCheckDueDateEnd"
      Me.lblCheckDueDateEnd.Size = New System.Drawing.Size(40, 18)
      Me.lblCheckDueDateEnd.TabIndex = 3
      Me.lblCheckDueDateEnd.Text = "ถึง"
      Me.lblCheckDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpCheckDueDateEnd
      '
      Me.dtpCheckDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpCheckDueDateEnd.Location = New System.Drawing.Point(296, 48)
      Me.dtpCheckDueDateEnd.Name = "dtpCheckDueDateEnd"
      Me.dtpCheckDueDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpCheckDueDateEnd.TabIndex = 5
      Me.dtpCheckDueDateEnd.TabStop = False
      '
      'txtCheckPassDateStart
      '
      Me.Validator.SetDataType(Me.txtCheckPassDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCheckPassDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCheckPassDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCheckPassDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCheckPassDateStart, System.Drawing.Color.Empty)
      Me.txtCheckPassDateStart.Location = New System.Drawing.Point(104, 72)
      Me.txtCheckPassDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtCheckPassDateStart, "")
      Me.Validator.SetMinValue(Me.txtCheckPassDateStart, "")
      Me.txtCheckPassDateStart.Name = "txtCheckPassDateStart"
      Me.Validator.SetRegularExpression(Me.txtCheckPassDateStart, "")
      Me.Validator.SetRequired(Me.txtCheckPassDateStart, False)
      Me.txtCheckPassDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtCheckPassDateStart.TabIndex = 4
      Me.txtCheckPassDateStart.Text = ""
      '
      'dtpCheckPassDateStart
      '
      Me.dtpCheckPassDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpCheckPassDateStart.Location = New System.Drawing.Point(104, 72)
      Me.dtpCheckPassDateStart.Name = "dtpCheckPassDateStart"
      Me.dtpCheckPassDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpCheckPassDateStart.TabIndex = 2
      Me.dtpCheckPassDateStart.TabStop = False
      '
      'lblCheckPassDateStart
      '
      Me.lblCheckPassDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckPassDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblCheckPassDateStart.Location = New System.Drawing.Point(8, 72)
      Me.lblCheckPassDateStart.Name = "lblCheckPassDateStart"
      Me.lblCheckPassDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCheckPassDateStart.TabIndex = 0
      Me.lblCheckPassDateStart.Text = "ตั้งแต่วันที่เช็คผ่าน"
      Me.lblCheckPassDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCheckPassDateEnd
      '
      Me.lblCheckPassDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckPassDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCheckPassDateEnd.Location = New System.Drawing.Point(248, 72)
      Me.lblCheckPassDateEnd.Name = "lblCheckPassDateEnd"
      Me.lblCheckPassDateEnd.Size = New System.Drawing.Size(40, 18)
      Me.lblCheckPassDateEnd.TabIndex = 3
      Me.lblCheckPassDateEnd.Text = "ถึง"
      Me.lblCheckPassDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCheckPassDateEnd
      '
      Me.Validator.SetDataType(Me.txtCheckPassDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCheckPassDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCheckPassDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCheckPassDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCheckPassDateEnd, System.Drawing.Color.Empty)
      Me.txtCheckPassDateEnd.Location = New System.Drawing.Point(296, 72)
      Me.txtCheckPassDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtCheckPassDateEnd, "")
      Me.Validator.SetMinValue(Me.txtCheckPassDateEnd, "")
      Me.txtCheckPassDateEnd.Name = "txtCheckPassDateEnd"
      Me.Validator.SetRegularExpression(Me.txtCheckPassDateEnd, "")
      Me.Validator.SetRequired(Me.txtCheckPassDateEnd, False)
      Me.txtCheckPassDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtCheckPassDateEnd.TabIndex = 5
      Me.txtCheckPassDateEnd.Text = ""
      '
      'cmbChkStatus
      '
      Me.cmbChkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbChkStatus.Location = New System.Drawing.Point(296, 96)
      Me.cmbChkStatus.Name = "cmbChkStatus"
      Me.cmbChkStatus.TabIndex = 7
      '
      'dtpCheckPassDateEnd
      '
      Me.dtpCheckPassDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpCheckPassDateEnd.Location = New System.Drawing.Point(296, 72)
      Me.dtpCheckPassDateEnd.Name = "dtpCheckPassDateEnd"
      Me.dtpCheckPassDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpCheckPassDateEnd.TabIndex = 5
      Me.dtpCheckPassDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(680, 144)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(600, 144)
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
      'RptOutgoingCheckEnumerateFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptOutgoingCheckEnumerateFilterSubPanel"
      Me.Size = New System.Drawing.Size(784, 192)
      Me.grbMaster.ResumeLayout(False)
      Me.grbBankAcctBook.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCheckDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblCheckDueDateStart}")
      Me.Validator.SetDisplayName(txtCheckDueDateStart, lblCheckDueDateStart.Text)

      Me.lblCheckPassDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblCheckPassDateStart}")
      Me.Validator.SetDisplayName(txtCheckPassDateStart, lblCheckPassDateStart.Text)

      Me.lblBankAcctStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblBankAcctStart}")
      Me.Validator.SetDisplayName(txtBankAcctCodeStart, lblBankAcctStart.Text)

      Me.lblSupplierStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblSupplierStart}")
      Me.Validator.SetDisplayName(txtSupplierCodeStart, lblSupplierStart.Text)

      ' Global {ถึง}

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblCheckDueDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtCheckDueDateEnd, lblCheckDueDateEnd.Text)

      Me.lblCheckPassDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtCheckPassDateEnd, lblCheckPassDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.grbDetail}")

      Me.lblChkStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblChkStatus}")
      Me.lblSort.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptOutgoingCheckEnumerateFilterSubPanel.lblSort}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_CheckDueDateEnd As Date
    Private m_CheckDueDateStart As Date

    Private m_CheckPassDateEnd As Date
    Private m_CheckPassDateStart As Date

    Private m_bankacctstart As BankAccount
    Private m_supplierstart As Supplier

    Private m_chkstatus As OutgoingCheckDocStatus
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
    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property
    Public Property CheckDueDateStart() As Date      Get        Return m_CheckDueDateStart      End Get      Set(ByVal Value As Date)        m_CheckDueDateStart = Value      End Set    End Property
    Public Property CheckDueDateEnd() As Date      Get        Return m_CheckDueDateEnd      End Get      Set(ByVal Value As Date)        m_CheckDueDateEnd = Value      End Set    End Property
    Public Property CheckPassDateStart() As Date      Get        Return m_CheckPassDateStart      End Get      Set(ByVal Value As Date)        m_CheckPassDateStart = Value      End Set    End Property
    Public Property CheckPassDateEnd() As Date      Get        Return m_CheckPassDateEnd      End Get      Set(ByVal Value As Date)        m_CheckPassDateEnd = Value      End Set    End Property
    Private Property ChkStatus() As CodeDescription
      Get
        Return m_chkstatus
      End Get
      Set(ByVal Value As CodeDescription)
        m_chkstatus = CType(Value, OutgoingCheckDocStatus)
      End Set
    End Property
    Public Property SupplierStart() As Supplier
      Get
        Return m_supplierstart
      End Get
      Set(ByVal Value As Supplier)
        m_supplierstart = Value
      End Set
    End Property
    Public Property BankAcctStart() As BankAccount
      Get
        Return m_bankacctstart
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacctstart = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' รูปแบบ
      OutgoingCheckDocStatus.ListCodeDescriptionInComboBox(Me.cmbChkStatus, "outgoingcheck_docstatus", True)

      Me.cmbSort.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerateFilterSubPanel.CheckDate}"))  ' "วันที่บนเช็ค"
      Me.cmbSort.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerateFilterSubPanel.DocDate}"))  ' "วันที่เอกสาร"
      Me.cmbSort.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckEnumerateFilterSubPanel.AccNumber}"))  ' "เลขที่บัญชี"
      Me.cmbSort.SelectedIndex = 0
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
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

      Me.SupplierStart = New Supplier
      Me.BankAcctStart = New BankAccount

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.CheckDueDateStart = dtStart
      Me.txtCheckDueDateStart.Text = MinDateToNull(Me.CheckDueDateStart, "")
      Me.dtpCheckDueDateStart.Value = Me.CheckDueDateStart

      Me.CheckDueDateEnd = Date.Now
      Me.txtCheckDueDateEnd.Text = MinDateToNull(Me.CheckDueDateEnd, "")
      Me.dtpCheckDueDateEnd.Value = Me.CheckDueDateEnd

      'Me.CheckPassDateStart = dtStart
      Me.CheckPassDateStart = Date.MinValue
      'Me.txtCheckPassDateStart.Text = MinDateToNull(Me.CheckPassDateStart, "")
      'Me.dtpCheckPassDateStart.Value = Me.CheckPassDateStart

      'Me.CheckPassDateEnd = Date.Now
      Me.CheckPassDateEnd = Date.MinValue
      'Me.txtCheckPassDateEnd.Text = MinDateToNull(Me.CheckPassDateEnd, "")
      'Me.dtpCheckPassDateEnd.Value = Me.CheckPassDateEnd

      Me.cmbChkStatus.SelectedIndex = 0
      Me.cmbSort.SelectedIndex = 0
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(10) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SuppliCodeStart", IIf(txtSupplierCodeStart.TextLength > 0, txtSupplierCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("BankAcctCodeStart", IIf(txtBankAcctCodeStart.TextLength > 0, txtBankAcctCodeStart.Text, DBNull.Value))
      arr(4) = New Filter("BankAcctCodeEnd", IIf(txtBankAcctCodeEnd.TextLength > 0, txtBankAcctCodeEnd.Text, DBNull.Value))
      arr(5) = New Filter("CheckStatus", IIf(cmbChkStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbChkStatus.SelectedItem, IdValuePair).Id))
      arr(6) = New Filter("CheckDueDateStart", IIf(Me.CheckDueDateStart.Equals(Date.MinValue), DBNull.Value, Me.CheckDueDateStart))
      arr(7) = New Filter("CheckDueDateEnd", IIf(Me.CheckDueDateEnd.Equals(Date.MinValue), DBNull.Value, Me.CheckDueDateEnd))
      arr(8) = New Filter("CheckPassDateStart", IIf(Me.CheckPassDateStart.Equals(Date.MinValue), DBNull.Value, Me.CheckPassDateStart))
      arr(9) = New Filter("CheckPassDateEnd", IIf(Me.CheckPassDateEnd.Equals(Date.MinValue), DBNull.Value, Me.CheckPassDateEnd))
      arr(10) = New Filter("SortBy", cmbSort.SelectedIndex)
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

      ''Month
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Month"
      'dpi.Value = "" ' Me.cmbMonth.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''Year
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Year"
      'dpi.Value = "" 'Me.cmbYear.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'Checkstatus
      dpi = New DocPrintingItem
      dpi.Mapping = "Checkstatus"
      dpi.Value = Me.cmbChkStatus.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "docdatestart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate end
      dpi = New DocPrintingItem
      dpi.Mapping = "docdateend"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckDueDateStart
      dpi = New DocPrintingItem
      dpi.Mapping = "checkduedatestart"
      dpi.Value = Me.txtCheckDueDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckDueDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "checkduedateend"
      dpi.Value = Me.txtCheckDueDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckPassDateStart
      dpi = New DocPrintingItem
      dpi.Mapping = "checkpassdatestart"
      dpi.Value = Me.txtCheckPassDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckPassDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "checkpassdateend"
      dpi.Value = Me.txtCheckPassDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Bankaccount start
      dpi = New DocPrintingItem
      dpi.Mapping = "accountstart"
      dpi.Value = Me.txtBankAcctCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Bankaccount end
      dpi = New DocPrintingItem
      dpi.Mapping = "accountend"
      dpi.Value = Me.txtBankAcctCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier start
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierstart"
      dpi.Value = Me.txtSupplierCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Sort By
      dpi = New DocPrintingItem
      dpi.Mapping = "SortBy"
      dpi.Value = Me.cmbSort.SelectedItem
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnBankAcctStartFind.Click, AddressOf Me.btnBankAccountFind_Click
      AddHandler btnBankAcctEndFind.Click, AddressOf Me.btnBankAccountFind_Click

      AddHandler txtBankAcctCodeStart.TextChanged, AddressOf Me.TextHandler
      AddHandler txtBankAcctCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBankAcctCodeEnd.TextChanged, AddressOf Me.TextHandler
      AddHandler txtBankAcctCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSupplierStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler txtSupplierCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCheckDueDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCheckDueDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpCheckDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpCheckDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCheckPassDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCheckPassDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpCheckPassDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpCheckPassDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private txtBankAcctCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      Select Case CType(sender, Control).Name.ToLower
        Case "txtbankacctcodestart"
          txtBankAcctCodeChanged = True
        Case "txtbankacctcodeend"
          txtBankAcctCodeChanged = True
      End Select
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
        Case "dtpcheckduedatestart"
          If Not Me.CheckDueDateStart.Equals(dtpCheckDueDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtCheckDueDateStart.Text = MinDateToNull(dtpCheckDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.CheckDueDateStart = dtpCheckDueDateStart.Value
            End If
          End If
        Case "txtcheckduedatestart"
          m_dateSetting = True
          If Not Me.txtCheckDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckDueDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtCheckDueDateStart.Text)
            If Not Me.CheckDueDateStart.Equals(theDate) Then
              dtpCheckDueDateStart.Value = theDate
              Me.CheckDueDateStart = dtpCheckDueDateStart.Value
            End If
          Else
            Me.dtpCheckDueDateStart.Value = Date.Now
            Me.CheckDueDateStart = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpcheckduedateend"
          If Not Me.CheckDueDateEnd.Equals(dtpCheckDueDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtCheckDueDateEnd.Text = MinDateToNull(dtpCheckDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.CheckDueDateEnd = dtpCheckDueDateEnd.Value
            End If
          End If
        Case "txtcheckduedateend"
          m_dateSetting = True
          If Not Me.txtCheckDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckDueDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtCheckDueDateEnd.Text)
            If Not Me.CheckDueDateEnd.Equals(theDate) Then
              dtpCheckDueDateEnd.Value = theDate
              Me.CheckDueDateEnd = dtpCheckDueDateEnd.Value
            End If
          Else
            Me.dtpCheckDueDateEnd.Value = Date.Now
            Me.CheckDueDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpcheckpassdatestart"
          If Not Me.CheckPassDateStart.Equals(dtpCheckPassDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtCheckPassDateStart.Text = MinDateToNull(dtpCheckPassDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.CheckPassDateStart = dtpCheckPassDateStart.Value
            End If
          End If
        Case "txtcheckpassdatestart"
          m_dateSetting = True
          If Not Me.txtCheckPassDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckPassDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtCheckPassDateStart.Text)
            If Not Me.CheckPassDateStart.Equals(theDate) Then
              dtpCheckPassDateStart.Value = theDate
              Me.CheckPassDateStart = dtpCheckPassDateStart.Value
            End If
          Else
            Me.dtpCheckPassDateStart.Value = Date.Now
            Me.CheckPassDateStart = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpcheckpassdateend"
          If Not Me.CheckPassDateEnd.Equals(dtpCheckPassDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtCheckPassDateEnd.Text = MinDateToNull(dtpCheckPassDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.CheckPassDateEnd = dtpCheckPassDateEnd.Value
            End If
          End If
        Case "txtcheckpassdateend"
          m_dateSetting = True
          If Not Me.txtCheckPassDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckPassDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtCheckPassDateEnd.Text)
            If Not Me.CheckPassDateEnd.Equals(theDate) Then
              dtpCheckPassDateEnd.Value = theDate
              Me.CheckPassDateEnd = dtpCheckPassDateEnd.Value
            End If
          Else
            Me.dtpCheckPassDateEnd.Value = Date.Now
            Me.CheckPassDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case "txtbankacctcodestart"
          If txtBankAcctCodeChanged Then
            BankAccount.GetBankAccount(txtBankAcctCodeStart, txtBankAcctNameStart, Me.m_bankacctstart)
            txtBankAcctNameStart.Text = Me.m_bankacctstart.BankCode
            txtBankAcctCodeChanged = False
          End If
        Case "txtbankacctcodeend"
          If txtBankAcctCodeChanged Then
            BankAccount.GetBankAccountBankCode(txtBankAcctCodeEnd, txtBankAcctNameEnd, Me.m_bankacctstart)
            txtBankAcctCodeChanged = False
          End If
        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Bank Account
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankacctcodestart", "txtbankacctcodeend"
                Return True
            End Select
          End If
        End If
        ' Supplier
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercodestart", "txtsuppliercodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' bankaccount
      If data.GetDataPresent((New BankAccount).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
        Dim entity As New BankAccount(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtbankacctcodestart"
              Me.SetBankAccountStartDialog(entity)
          End Select
        End If
      End If
      ' Supplier
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercodestart"
              Me.SetSupplierStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'BankAccount
    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnbankacctstartfind"
          myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountStartDialog)
        Case "btnbankacctendfind"
          myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountEndDialog)
      End Select
    End Sub
    Private Sub SetBankAccountStartDialog(ByVal e As ISimpleEntity)
      Me.txtBankAcctCodeStart.Text = CType(e, BankAccount).Code
      Me.txtBankAcctNameStart.Text = CType(e, BankAccount).BankCode
    End Sub
    Private Sub SetBankAccountEndDialog(ByVal e As ISimpleEntity)
      Me.txtBankAcctCodeEnd.Text = CType(e, BankAccount).Code
      Me.txtBankAcctNameEnd.Text = CType(e, BankAccount).BankCode
    End Sub
    'Supplier
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplierstartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)
      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCodeStart.Text = e.Code
      Dim txttmp As New TextBox
      Supplier.GetSupplier(txtSupplierCodeStart, txttmp, m_supplierstart)
    End Sub
#End Region

  End Class

End Namespace

