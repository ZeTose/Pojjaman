Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.IO

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptIncomingWhtPNDFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel, IExcellExportAble

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
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnSupplierEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierEnd As System.Windows.Forms.Label
    Friend WithEvents btnSupplierStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierStart As System.Windows.Forms.Label
    Friend WithEvents cmbWhtType As System.Windows.Forms.ComboBox
    Friend WithEvents lblWhtType As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSpgStart As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lbPaymentName As System.Windows.Forms.Label
    Friend WithEvents lbPositionName As System.Windows.Forms.Label
    Friend WithEvents lbDate As System.Windows.Forms.Label
    Friend WithEvents grbPayment As System.Windows.Forms.GroupBox
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentName As System.Windows.Forms.TextBox
    Friend WithEvents btnAcctBookEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookStart As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents rdMoreSubmit As System.Windows.Forms.RadioButton
    Friend WithEvents rdNormalSubmit As System.Windows.Forms.RadioButton
    Friend WithEvents lblSubmitType As System.Windows.Forms.Label
    Friend WithEvents grbSubmit As System.Windows.Forms.GroupBox
    Friend WithEvents chkType3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkType2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkType1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnRequestorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptIncomingWhtPNDFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.rdMoreSubmit = New System.Windows.Forms.RadioButton()
      Me.rdNormalSubmit = New System.Windows.Forms.RadioButton()
      Me.btnAcctBookEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookEnd = New System.Windows.Forms.TextBox()
      Me.lblAcctBookEnd = New System.Windows.Forms.Label()
      Me.btnAcctBookStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookStart = New System.Windows.Forms.TextBox()
      Me.lblSubmitType = New System.Windows.Forms.Label()
      Me.lblAcctBookStart = New System.Windows.Forms.Label()
      Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox()
      Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSpgCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSpgStart = New System.Windows.Forms.Label()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.cmbWhtType = New System.Windows.Forms.ComboBox()
      Me.lblWhtType = New System.Windows.Forms.Label()
      Me.btnSupplierEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSupplierEnd = New System.Windows.Forms.Label()
      Me.btnSupplierStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSupplierStart = New System.Windows.Forms.Label()
      Me.cmbYear = New System.Windows.Forms.ComboBox()
      Me.cmbMonth = New System.Windows.Forms.ComboBox()
      Me.lblMonth = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblYear = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtPaymentCode = New System.Windows.Forms.TextBox()
      Me.txtPosition = New System.Windows.Forms.TextBox()
      Me.txtDate = New System.Windows.Forms.TextBox()
      Me.txtPaymentName = New System.Windows.Forms.TextBox()
      Me.grbPayment = New System.Windows.Forms.GroupBox()
      Me.btnRequestorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lbPaymentName = New System.Windows.Forms.Label()
      Me.lbPositionName = New System.Windows.Forms.Label()
      Me.lbDate = New System.Windows.Forms.Label()
      Me.dtpDate = New System.Windows.Forms.DateTimePicker()
      Me.btnExport = New System.Windows.Forms.Button()
      Me.grbSubmit = New System.Windows.Forms.GroupBox()
      Me.chkType1 = New System.Windows.Forms.CheckBox()
      Me.chkType2 = New System.Windows.Forms.CheckBox()
      Me.chkType3 = New System.Windows.Forms.CheckBox()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbPayment.SuspendLayout()
      Me.grbSubmit.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(474, 270)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Find"
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.rdMoreSubmit)
      Me.grbDocDate.Controls.Add(Me.rdNormalSubmit)
      Me.grbDocDate.Controls.Add(Me.btnAcctBookEndFind)
      Me.grbDocDate.Controls.Add(Me.txtAcctBookEnd)
      Me.grbDocDate.Controls.Add(Me.lblAcctBookEnd)
      Me.grbDocDate.Controls.Add(Me.btnAcctBookStartFind)
      Me.grbDocDate.Controls.Add(Me.txtAcctBookStart)
      Me.grbDocDate.Controls.Add(Me.lblSubmitType)
      Me.grbDocDate.Controls.Add(Me.lblAcctBookStart)
      Me.grbDocDate.Controls.Add(Me.chkIncludeChildSupplierGroup)
      Me.grbDocDate.Controls.Add(Me.btnSpgCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtSpgCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblSpgStart)
      Me.grbDocDate.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDocDate.Controls.Add(Me.cmbWhtType)
      Me.grbDocDate.Controls.Add(Me.lblWhtType)
      Me.grbDocDate.Controls.Add(Me.btnSupplierEnd)
      Me.grbDocDate.Controls.Add(Me.txtSupplierCodeEnd)
      Me.grbDocDate.Controls.Add(Me.lblSupplierEnd)
      Me.grbDocDate.Controls.Add(Me.btnSupplierStart)
      Me.grbDocDate.Controls.Add(Me.txtSupplierCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblSupplierStart)
      Me.grbDocDate.Controls.Add(Me.cmbYear)
      Me.grbDocDate.Controls.Add(Me.cmbMonth)
      Me.grbDocDate.Controls.Add(Me.lblMonth)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.lblYear)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(13, 16)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(448, 216)
      Me.grbDocDate.TabIndex = 0
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "Date"
      '
      'rdMoreSubmit
      '
      Me.rdMoreSubmit.AutoSize = True
      Me.rdMoreSubmit.Location = New System.Drawing.Point(186, 189)
      Me.rdMoreSubmit.Name = "rdMoreSubmit"
      Me.rdMoreSubmit.Size = New System.Drawing.Size(79, 17)
      Me.rdMoreSubmit.TabIndex = 58
      Me.rdMoreSubmit.Text = "ยื่นเพิ่มเติม"
      Me.rdMoreSubmit.UseVisualStyleBackColor = True
      '
      'rdNormalSubmit
      '
      Me.rdNormalSubmit.AutoSize = True
      Me.rdNormalSubmit.Checked = True
      Me.rdNormalSubmit.Location = New System.Drawing.Point(119, 189)
      Me.rdNormalSubmit.Name = "rdNormalSubmit"
      Me.rdNormalSubmit.Size = New System.Drawing.Size(61, 17)
      Me.rdNormalSubmit.TabIndex = 58
      Me.rdNormalSubmit.TabStop = True
      Me.rdNormalSubmit.Text = "ยื่นปกติ"
      Me.rdNormalSubmit.UseVisualStyleBackColor = True
      '
      'btnAcctBookEndFind
      '
      Me.btnAcctBookEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookEndFind.Location = New System.Drawing.Point(399, 159)
      Me.btnAcctBookEndFind.Name = "btnAcctBookEndFind"
      Me.btnAcctBookEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookEndFind.TabIndex = 57
      Me.btnAcctBookEndFind.TabStop = False
      Me.btnAcctBookEndFind.ThemedImage = CType(resources.GetObject("btnAcctBookEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookEnd
      '
      Me.Validator.SetDataType(Me.txtAcctBookEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.txtAcctBookEnd.Location = New System.Drawing.Point(304, 159)
      Me.Validator.SetMinValue(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Name = "txtAcctBookEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctBookEnd, "")
      Me.Validator.SetRequired(Me.txtAcctBookEnd, False)
      Me.txtAcctBookEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookEnd.TabIndex = 53
      '
      'lblAcctBookEnd
      '
      Me.lblAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookEnd.Location = New System.Drawing.Point(273, 159)
      Me.lblAcctBookEnd.Name = "lblAcctBookEnd"
      Me.lblAcctBookEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAcctBookEnd.TabIndex = 56
      Me.lblAcctBookEnd.Text = "ถึง"
      Me.lblAcctBookEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctBookStartFind
      '
      Me.btnAcctBookStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookStartFind.Location = New System.Drawing.Point(216, 159)
      Me.btnAcctBookStartFind.Name = "btnAcctBookStartFind"
      Me.btnAcctBookStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookStartFind.TabIndex = 55
      Me.btnAcctBookStartFind.TabStop = False
      Me.btnAcctBookStartFind.ThemedImage = CType(resources.GetObject("btnAcctBookStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookStart
      '
      Me.Validator.SetDataType(Me.txtAcctBookStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.txtAcctBookStart.Location = New System.Drawing.Point(120, 159)
      Me.Validator.SetMinValue(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Name = "txtAcctBookStart"
      Me.Validator.SetRegularExpression(Me.txtAcctBookStart, "")
      Me.Validator.SetRequired(Me.txtAcctBookStart, False)
      Me.txtAcctBookStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookStart.TabIndex = 52
      '
      'lblSubmitType
      '
      Me.lblSubmitType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubmitType.ForeColor = System.Drawing.Color.Black
      Me.lblSubmitType.Location = New System.Drawing.Point(24, 187)
      Me.lblSubmitType.Name = "lblSubmitType"
      Me.lblSubmitType.Size = New System.Drawing.Size(88, 18)
      Me.lblSubmitType.TabIndex = 54
      Me.lblSubmitType.Text = "ลักษณะการยื่น"
      Me.lblSubmitType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAcctBookStart
      '
      Me.lblAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookStart.Location = New System.Drawing.Point(24, 159)
      Me.lblAcctBookStart.Name = "lblAcctBookStart"
      Me.lblAcctBookStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAcctBookStart.TabIndex = 54
      Me.lblAcctBookStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAcctBookStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildSupplierGroup
      '
      Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(120, 111)
      Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
      Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildSupplierGroup.TabIndex = 9
      Me.chkIncludeChildSupplierGroup.Text = "Included Child Supplier"
      '
      'btnSpgCodeStart
      '
      Me.btnSpgCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSpgCodeStart.Location = New System.Drawing.Point(216, 87)
      Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
      Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSpgCodeStart.TabIndex = 10
      Me.btnSpgCodeStart.TabStop = False
      Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSpgCodeStart
      '
      Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.txtSpgCodeStart.Location = New System.Drawing.Point(120, 87)
      Me.txtSpgCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
      Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
      Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSpgCodeStart.TabIndex = 6
      '
      'lblSpgStart
      '
      Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
      Me.lblSpgStart.Location = New System.Drawing.Point(24, 87)
      Me.lblSpgStart.Name = "lblSpgStart"
      Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSpgStart.TabIndex = 50
      Me.lblSpgStart.Text = "Supplier Group"
      Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(240, 87)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(183, 21)
      Me.txtSupplierGroupName.TabIndex = 51
      '
      'cmbWhtType
      '
      Me.cmbWhtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbWhtType.Location = New System.Drawing.Point(120, 16)
      Me.cmbWhtType.Name = "cmbWhtType"
      Me.cmbWhtType.Size = New System.Drawing.Size(120, 21)
      Me.cmbWhtType.TabIndex = 1
      '
      'lblWhtType
      '
      Me.lblWhtType.BackColor = System.Drawing.Color.Transparent
      Me.lblWhtType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWhtType.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblWhtType.Location = New System.Drawing.Point(8, 16)
      Me.lblWhtType.Name = "lblWhtType"
      Me.lblWhtType.Size = New System.Drawing.Size(104, 18)
      Me.lblWhtType.TabIndex = 29
      Me.lblWhtType.Text = "Type of Tax"
      Me.lblWhtType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierEnd
      '
      Me.btnSupplierEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierEnd.Location = New System.Drawing.Point(400, 135)
      Me.btnSupplierEnd.Name = "btnSupplierEnd"
      Me.btnSupplierEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierEnd.TabIndex = 12
      Me.btnSupplierEnd.TabStop = False
      Me.btnSupplierEnd.ThemedImage = CType(resources.GetObject("btnSupplierEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSupplierCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCodeEnd, "")
      Me.txtSupplierCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeEnd, System.Drawing.Color.Empty)
      Me.txtSupplierCodeEnd.Location = New System.Drawing.Point(304, 135)
      Me.txtSupplierCodeEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierCodeEnd, "")
      Me.txtSupplierCodeEnd.Name = "txtSupplierCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSupplierCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSupplierCodeEnd, False)
      Me.txtSupplierCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierCodeEnd.TabIndex = 8
      '
      'lblSupplierEnd
      '
      Me.lblSupplierEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierEnd.Location = New System.Drawing.Point(264, 135)
      Me.lblSupplierEnd.Name = "lblSupplierEnd"
      Me.lblSupplierEnd.Size = New System.Drawing.Size(32, 18)
      Me.lblSupplierEnd.TabIndex = 13
      Me.lblSupplierEnd.Text = "To"
      Me.lblSupplierEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierStart
      '
      Me.btnSupplierStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierStart.Location = New System.Drawing.Point(216, 135)
      Me.btnSupplierStart.Name = "btnSupplierStart"
      Me.btnSupplierStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierStart.TabIndex = 11
      Me.btnSupplierStart.TabStop = False
      Me.btnSupplierStart.ThemedImage = CType(resources.GetObject("btnSupplierStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCodeStart
      '
      Me.Validator.SetDataType(Me.txtSupplierCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.txtSupplierCodeStart.Location = New System.Drawing.Point(120, 135)
      Me.txtSupplierCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Name = "txtSupplierCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierCodeStart, "")
      Me.Validator.SetRequired(Me.txtSupplierCodeStart, False)
      Me.txtSupplierCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierCodeStart.TabIndex = 7
      '
      'lblSupplierStart
      '
      Me.lblSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierStart.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierStart.Location = New System.Drawing.Point(8, 135)
      Me.lblSupplierStart.Name = "lblSupplierStart"
      Me.lblSupplierStart.Size = New System.Drawing.Size(104, 18)
      Me.lblSupplierStart.TabIndex = 10
      Me.lblSupplierStart.Text = "Start Supplier"
      Me.lblSupplierStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.Location = New System.Drawing.Point(304, 40)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(120, 21)
      Me.cmbYear.TabIndex = 3
      '
      'cmbMonth
      '
      Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonth.Location = New System.Drawing.Point(120, 40)
      Me.cmbMonth.Name = "cmbMonth"
      Me.cmbMonth.Size = New System.Drawing.Size(120, 21)
      Me.cmbMonth.TabIndex = 2
      '
      'lblMonth
      '
      Me.lblMonth.BackColor = System.Drawing.Color.Transparent
      Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMonth.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMonth.Location = New System.Drawing.Point(8, 41)
      Me.lblMonth.Name = "lblMonth"
      Me.lblMonth.Size = New System.Drawing.Size(104, 18)
      Me.lblMonth.TabIndex = 0
      Me.lblMonth.Text = "Tax Month"
      Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(304, 64)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateEnd.TabIndex = 5
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 64)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateStart.TabIndex = 4
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 64)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDateStart.TabIndex = 4
      Me.lblDocDateStart.Text = "Start Date"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 62)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 24)
      Me.lblDocDateEnd.TabIndex = 7
      Me.lblDocDateEnd.Text = "End Date"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 64)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateStart.TabIndex = 6
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(304, 64)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateEnd.TabIndex = 9
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblYear
      '
      Me.lblYear.BackColor = System.Drawing.Color.Transparent
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblYear.Location = New System.Drawing.Point(240, 41)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(56, 18)
      Me.lblYear.TabIndex = 2
      Me.lblYear.Text = "Year Tax:"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(389, 238)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "Find"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(301, 238)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.Text = "Reset"
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
      'txtPaymentCode
      '
      Me.Validator.SetDataType(Me.txtPaymentCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPaymentCode, "")
      Me.txtPaymentCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPaymentCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPaymentCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPaymentCode, System.Drawing.Color.Empty)
      Me.txtPaymentCode.Location = New System.Drawing.Point(88, 22)
      Me.txtPaymentCode.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtPaymentCode, "")
      Me.txtPaymentCode.Name = "txtPaymentCode"
      Me.Validator.SetRegularExpression(Me.txtPaymentCode, "")
      Me.Validator.SetRequired(Me.txtPaymentCode, False)
      Me.txtPaymentCode.Size = New System.Drawing.Size(120, 21)
      Me.txtPaymentCode.TabIndex = 7
      '
      'txtPosition
      '
      Me.Validator.SetDataType(Me.txtPosition, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPosition, "")
      Me.txtPosition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPosition, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPosition, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPosition, System.Drawing.Color.Empty)
      Me.txtPosition.Location = New System.Drawing.Point(88, 46)
      Me.txtPosition.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtPosition, "")
      Me.txtPosition.Name = "txtPosition"
      Me.Validator.SetRegularExpression(Me.txtPosition, "")
      Me.Validator.SetRequired(Me.txtPosition, False)
      Me.txtPosition.Size = New System.Drawing.Size(276, 21)
      Me.txtPosition.TabIndex = 7
      '
      'txtDate
      '
      Me.Validator.SetDataType(Me.txtDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDate, System.Drawing.Color.Empty)
      Me.txtDate.Location = New System.Drawing.Point(88, 70)
      Me.txtDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDate, "")
      Me.txtDate.Name = "txtDate"
      Me.Validator.SetRegularExpression(Me.txtDate, "")
      Me.Validator.SetRequired(Me.txtDate, False)
      Me.txtDate.Size = New System.Drawing.Size(99, 20)
      Me.txtDate.TabIndex = 52
      '
      'txtPaymentName
      '
      Me.txtPaymentName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPaymentName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPaymentName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPaymentName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPaymentName, System.Drawing.Color.Empty)
      Me.txtPaymentName.Location = New System.Drawing.Point(208, 22)
      Me.Validator.SetMinValue(Me.txtPaymentName, "")
      Me.txtPaymentName.Name = "txtPaymentName"
      Me.txtPaymentName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPaymentName, "")
      Me.Validator.SetRequired(Me.txtPaymentName, False)
      Me.txtPaymentName.Size = New System.Drawing.Size(156, 20)
      Me.txtPaymentName.TabIndex = 27
      Me.txtPaymentName.TabStop = False
      '
      'grbPayment
      '
      Me.grbPayment.Controls.Add(Me.btnRequestorFind)
      Me.grbPayment.Controls.Add(Me.lbPaymentName)
      Me.grbPayment.Controls.Add(Me.lbPositionName)
      Me.grbPayment.Controls.Add(Me.txtPaymentCode)
      Me.grbPayment.Controls.Add(Me.txtPosition)
      Me.grbPayment.Controls.Add(Me.lbDate)
      Me.grbPayment.Controls.Add(Me.txtDate)
      Me.grbPayment.Controls.Add(Me.dtpDate)
      Me.grbPayment.Controls.Add(Me.txtPaymentName)
      Me.grbPayment.Location = New System.Drawing.Point(491, 8)
      Me.grbPayment.Name = "grbPayment"
      Me.grbPayment.Size = New System.Drawing.Size(403, 102)
      Me.grbPayment.TabIndex = 1
      Me.grbPayment.TabStop = False
      Me.grbPayment.Text = "รายละเอียดผู้จ่าย"
      '
      'btnRequestorFind
      '
      Me.btnRequestorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRequestorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRequestorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRequestorFind.Location = New System.Drawing.Point(364, 21)
      Me.btnRequestorFind.Name = "btnRequestorFind"
      Me.btnRequestorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnRequestorFind.TabIndex = 53
      Me.btnRequestorFind.TabStop = False
      Me.btnRequestorFind.ThemedImage = CType(resources.GetObject("btnRequestorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lbPaymentName
      '
      Me.lbPaymentName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbPaymentName.ForeColor = System.Drawing.Color.Black
      Me.lbPaymentName.Location = New System.Drawing.Point(16, 22)
      Me.lbPaymentName.Name = "lbPaymentName"
      Me.lbPaymentName.Size = New System.Drawing.Size(64, 18)
      Me.lbPaymentName.TabIndex = 11
      Me.lbPaymentName.Text = "ชื่อผู้จ่าย"
      Me.lbPaymentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbPositionName
      '
      Me.lbPositionName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbPositionName.ForeColor = System.Drawing.Color.Black
      Me.lbPositionName.Location = New System.Drawing.Point(16, 46)
      Me.lbPositionName.Name = "lbPositionName"
      Me.lbPositionName.Size = New System.Drawing.Size(64, 18)
      Me.lbPositionName.TabIndex = 11
      Me.lbPositionName.Text = "ตำแหน่ง"
      Me.lbPositionName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbDate
      '
      Me.lbDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbDate.ForeColor = System.Drawing.Color.Black
      Me.lbDate.Location = New System.Drawing.Point(16, 70)
      Me.lbDate.Name = "lbDate"
      Me.lbDate.Size = New System.Drawing.Size(64, 18)
      Me.lbDate.TabIndex = 11
      Me.lbDate.Text = "วันที่ยื่น"
      Me.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDate
      '
      Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDate.Location = New System.Drawing.Point(88, 70)
      Me.dtpDate.Name = "dtpDate"
      Me.dtpDate.Size = New System.Drawing.Size(120, 20)
      Me.dtpDate.TabIndex = 52
      Me.dtpDate.TabStop = False
      '
      'btnExport
      '
      Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnExport.Location = New System.Drawing.Point(900, 14)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(92, 46)
      Me.btnExport.TabIndex = 1
      Me.btnExport.Text = "Export"
      '
      'grbSubmit
      '
      Me.grbSubmit.Controls.Add(Me.chkType3)
      Me.grbSubmit.Controls.Add(Me.chkType2)
      Me.grbSubmit.Controls.Add(Me.chkType1)
      Me.grbSubmit.Location = New System.Drawing.Point(491, 116)
      Me.grbSubmit.Name = "grbSubmit"
      Me.grbSubmit.Size = New System.Drawing.Size(403, 89)
      Me.grbSubmit.TabIndex = 1
      Me.grbSubmit.TabStop = False
      Me.grbSubmit.Text = "รายละเอียดการยื่นภาษีเงินได้"
      '
      'chkType1
      '
      Me.chkType1.AutoSize = True
      Me.chkType1.Location = New System.Drawing.Point(88, 19)
      Me.chkType1.Name = "chkType1"
      Me.chkType1.Size = New System.Drawing.Size(155, 17)
      Me.chkType1.TabIndex = 0
      Me.chkType1.Text = "นำส่งภาษีตามมาตรา 3 เตรส"
      Me.chkType1.UseVisualStyleBackColor = True
      '
      'chkType2
      '
      Me.chkType2.AutoSize = True
      Me.chkType2.Location = New System.Drawing.Point(88, 42)
      Me.chkType2.Name = "chkType2"
      Me.chkType2.Size = New System.Drawing.Size(150, 17)
      Me.chkType2.TabIndex = 0
      Me.chkType2.Text = "นำส่งภาษีตามมาตรา 48 ทวิ"
      Me.chkType2.UseVisualStyleBackColor = True
      '
      'chkType3
      '
      Me.chkType3.AutoSize = True
      Me.chkType3.Location = New System.Drawing.Point(88, 65)
      Me.chkType3.Name = "chkType3"
      Me.chkType3.Size = New System.Drawing.Size(173, 17)
      Me.chkType3.TabIndex = 0
      Me.chkType3.Text = "นำส่งภาษีตามมาตรา 50 (3)(4)(5)"
      Me.chkType3.UseVisualStyleBackColor = True
      '
      'RptIncomingWhtPNDFilterSubPanel
      '
      Me.Controls.Add(Me.grbSubmit)
      Me.Controls.Add(Me.grbPayment)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.btnExport)
      Me.Name = "RptIncomingWhtPNDFilterSubPanel"
      Me.Size = New System.Drawing.Size(1005, 281)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbPayment.ResumeLayout(False)
      Me.grbPayment.PerformLayout()
      Me.grbSubmit.ResumeLayout(False)
      Me.grbSubmit.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblSupplierStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblSupplierStart}")
      Me.Validator.SetDisplayName(txtSupplierCodeStart, lblSupplierStart.Text)

      Me.lblWhtType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblWhtType}")
      Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblYear}")
      Me.lblMonth.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblMonth}")

      ' Global
      Me.lblSupplierEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSupplierCodeEnd, lblSupplierEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      ' Group box
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.grbDetail}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.grbDocDate}")
      Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblSpgStart}")
      Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.chkIncludeChildSupplierGroup}")

      Me.grbPayment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.grbpayment}")
      Me.lbPaymentName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lbPaymentName}")
      Me.lbPositionName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lbPosition}")
      Me.lbDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lbDate}")
      Me.lblSubmitType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.lblSubmitType}")
      Me.rdNormalSubmit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.rdNormalSubmit}")
      Me.rdMoreSubmit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.rdMoreSubmit}")

      Me.grbSubmit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.grbSubmit}")
      Me.chkType1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.chkType1}")
      Me.chkType2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.chkType2}")
      Me.chkType3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.chkType3}")

    End Sub
#End Region

#Region " Member "
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_suppliergroup As SupplierGroup
    Private m_DocDate As Date
    Private dummyEmployee As New Employee

#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region " Properties "
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property DocDate() As Date      Get        Return m_DocDate      End Get      Set(ByVal Value As Date)        m_DocDate = Value      End Set    End Property
    Public Property SupplierGroup() As SupplierGroup
      Get
        Return m_suppliergroup
      End Get
      Set(ByVal Value As SupplierGroup)
        m_suppliergroup = Value
      End Set
    End Property
#End Region

#Region " Methods "
    Private Sub RegisterDropdown()
      'ประเภทภาษีหัก ณ ที่จ่าย
      WitholdingTaxType.ListCodeDescriptionInComboBox(Me.cmbWhtType, "wht_type", True)
      cmbWhtType.SelectedIndex = 0
    End Sub
    Private Sub PopulateStatus()
      Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = DateAdd(DateInterval.Year, i, baseDate)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
      myDateTimeService.ListMonthsInComboBoxWithIdValue(Me.cmbMonth, False, , False)
    End Sub
    Private Sub Initialize()
      PopulateStatus()
      RegisterDropdown()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbDetail.Controls
        If TypeOf grbCtrl Is Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDocDateStart.Value = dtStart
      Me.DocDateStart = dtStart

      Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDocDateEnd.Value = Date.Now
      Me.DocDateEnd = Date.Now

      Me.cmbYear.SelectedIndex = (Date.Now.Year - AccountBaseDate.GetBaseDateFromDB().Year) 'CDate(Configuration.GetConfig("BaseDate")).Year)
      Me.cmbMonth.SelectedIndex = Date.Now.Month - 1
      Me.SupplierGroup = New SupplierGroup

      Me.rdNormalSubmit.Checked = True

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SupplierCodeStart", IIf(Me.txtSupplierCodeStart.TextLength > 0, Me.txtSupplierCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SupplierCodeEnd", IIf(Me.txtSupplierCodeEnd.TextLength > 0, Me.txtSupplierCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("WhtType", IIf(cmbWhtType.SelectedItem Is Nothing, DBNull.Value, CType(cmbWhtType.SelectedItem, IdValuePair).Id))
      arr(5) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
      arr(6) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
      arr(7) = New Filter("AcctBookCodeStart", IIf(txtAcctBookStart.TextLength > 0, txtAcctBookStart.Text, DBNull.Value))
      arr(8) = New Filter("AcctBookCodeEnd", IIf(txtAcctBookEnd.TextLength > 0, txtAcctBookEnd.Text, DBNull.Value))
      arr(9) = New Filter("IsNormalSubmit", IIf(rdNormalSubmit.Checked, 1, 2))
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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      Me.Export()
    End Sub

    Private Function Export() As Boolean
      If m_tgItem Is Nothing Then
        Return False
      End If
      Dim ds As DataSet = CType(m_tgItem.Tag, DataSet)
      If ds Is Nothing OrElse ds.Tables(0) Is Nothing Then
        Return False
      End If

      Dim taxYear As String = Me.cmbYear.Text
      Dim taxMonth As String = CType(Me.cmbMonth.SelectedItem, IdValuePair).Id.ToString("00")
      Dim sendType As String
      Dim sendArr As New ArrayList
      If chkType1.Checked Then
        sendArr.Add("1")
      Else
        sendArr.Add("0")
      End If
      If chkType2.Checked Then
        sendArr.Add("1")
      Else
        sendArr.Add("0")
      End If
      If chkType3.Checked Then
        sendArr.Add("1")
      Else
        sendArr.Add("0")
      End If
      sendType = String.Join("|", sendArr.ToArray)

      Dim exp As New ExportVat(taxYear, taxMonth, sendType, ds)

      If Not exp Is Nothing Then
        'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        'If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
        '  msgServ.ShowMessage(Validator.ValidationSummary)
        '  Return
        'End If

        'Dim culture As New CultureInfo("th-TH", True)
        Dim myOpb As New SaveFileDialog
        myOpb.Filter = "All Files|*.*|Text File (*.txt)|*.txt"
        myOpb.FilterIndex = 2
        myOpb.FileName = "WHT_" & taxYear.ToString & taxMonth.ToString & "_" & Now.ToString("hhmm") & ".txt"
        If myOpb.ShowDialog() = DialogResult.OK Then
          Dim fileName As String = Path.GetDirectoryName(myOpb.FileName) & Path.DirectorySeparatorChar & Path.GetFileName(myOpb.FileName)
          Dim writer As New IO.StreamWriter(fileName, False, System.Text.Encoding.Default)

          Try
            exp.Export(writer)
            MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ExportCompleted}"))

            Dim saveerr As SaveErrorException = exp.Save()
            If Not IsNumeric(saveerr.Message) Then
              MessageBox.Show(saveerr.Message)
            Else
              Me.btnSearch.PerformClick()
            End If

          Catch ex As Exception
            MessageBox.Show("Error:" & ex.ToString)
          Finally
            writer.Close()
          End Try

        End If
      End If


    End Function
#End Region

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'WhtType
      dpi = New DocPrintingItem
      dpi.Mapping = "WhtType"
      dpi.Value = Me.cmbWhtType.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStart"
      dpi.Value = Me.txtSupplierCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier End
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierEnd"
      dpi.Value = Me.txtSupplierCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierGroup Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroupCodeStart"
      dpi.Value = Me.txtSpgCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PaymentName
      dpi = New DocPrintingItem
      dpi.Mapping = "PaymentName"
      dpi.Value = Me.txtPaymentName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Position
      dpi = New DocPrintingItem
      dpi.Mapping = "Position"
      dpi.Value = Me.txtPosition.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'IssueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "IssueDate"
      dpi.Value = Me.dtpDate.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildSupplierGroupInclude
      If Me.chkIncludeChildSupplierGroup.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childSupplierGroupincluded"
        dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtPNDFilterSubPanel.childSupplierGroupincluded}")
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty Methods "
    Private Sub EventWiring()
      AddHandler btnSupplierStart.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSupplierEnd.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnAcctBookStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnAcctBookEndFind.Click, AddressOf Me.btnAccountBookFind_Click

      AddHandler dtpDocDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateStart.Validated, AddressOf ChangeProperty

      AddHandler dtpDate.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDate.Validated, AddressOf ChangeProperty

      AddHandler dtpDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf ChangeProperty
      AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(dummyEmployee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtPaymentCode.Text = e.Code
      Employee.GetEmployee(txtPaymentCode, txtPaymentName, dummyEmployee)
    End Sub

    Private m_dateSetting As Boolean

    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

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
        Case "dtpdate"
          If Not Me.DocDate.Equals(dtpDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDate.Text = MinDateToNull(dtpDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDate = dtpDate.Value
            End If
          End If
        Case "txtdate"
          m_dateSetting = True
          If Not Me.txtDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDate.Equals(theDate) Then
              dtpDate.Value = theDate
              Me.DocDate = dtpDate.Value
            End If
          Else
            Me.dtpDate.Value = Date.Now
            Me.DocDate = Date.MinValue
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
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsuppliercodeend"
              Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctbookstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookStartDialog)

        Case "btnacctbookendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookEndDialog)

      End Select
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplierstart"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsupplierend"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCodeStart.Text = e.Code
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCodeEnd.Text = e.Code
    End Sub
    ' SupplierGroup
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnspgcodestart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
      End Select
    End Sub
    Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtSpgCodeStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_suppliergroup, True)
    End Sub
    Private Sub SetAccountBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookStart.Text = e.Code
    End Sub
    Private Sub SetAccountBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookEnd.Text = e.Code
    End Sub
#End Region

    Private m_tgItem As LKGrid
    Public Property tgItem As Components.LKGrid Implements IExcellExportAble.tgItem
      Get
        Return m_tgItem
      End Get
      Set(ByVal value As Components.LKGrid)
        m_tgItem = value
      End Set
    End Property
  End Class
End Namespace

