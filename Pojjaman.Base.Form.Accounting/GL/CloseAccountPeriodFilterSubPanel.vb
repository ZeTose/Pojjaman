Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CloseAccountPeriodFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
        Friend WithEvents lblYear As System.Windows.Forms.Label
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblAccountBook As System.Windows.Forms.Label
    Friend WithEvents txtAccountBookName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountBookCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowAccountBookDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtEditDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtEditDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblEditDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblEditDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpEditDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEditDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloseAccountPeriodFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtEditDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtEditDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblEditDocDateStart = New System.Windows.Forms.Label()
      Me.lblEditDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpEditDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpEditDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblAccountBook = New System.Windows.Forms.Label()
      Me.txtAccountBookName = New System.Windows.Forms.TextBox()
      Me.txtAccountBookCode = New System.Windows.Forms.TextBox()
      Me.ibtnShowAccountBookDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.cmbYear = New System.Windows.Forms.ComboBox()
      Me.lblYear = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.FixedGroupBox1.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.FixedGroupBox1)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblAccountBook)
      Me.grbDetail.Controls.Add(Me.txtAccountBookName)
      Me.grbDetail.Controls.Add(Me.txtAccountBookCode)
      Me.grbDetail.Controls.Add(Me.ibtnShowAccountBookDialog)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.cmbYear)
      Me.grbDetail.Controls.Add(Me.lblYear)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(749, 168)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Controls.Add(Me.txtEditDocDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.txtEditDocDateEnd)
      Me.FixedGroupBox1.Controls.Add(Me.lblEditDocDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.lblEditDocDateEnd)
      Me.FixedGroupBox1.Controls.Add(Me.dtpEditDocDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.dtpEditDocDateEnd)
      Me.FixedGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.FixedGroupBox1.Location = New System.Drawing.Point(282, 56)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(254, 72)
      Me.FixedGroupBox1.TabIndex = 230
      Me.FixedGroupBox1.TabStop = False
      Me.FixedGroupBox1.Text = "วันที่ปรับปรุงเอกสาร"
      '
      'txtEditDocDateStart
      '
      Me.txtEditDocDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEditDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEditDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEditDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEditDocDateStart, System.Drawing.Color.Empty)
      Me.txtEditDocDateStart.Location = New System.Drawing.Point(80, 14)
      Me.Validator.SetMinValue(Me.txtEditDocDateStart, "")
      Me.txtEditDocDateStart.Name = "txtEditDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtEditDocDateStart, "")
      Me.Validator.SetRequired(Me.txtEditDocDateStart, False)
      Me.txtEditDocDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtEditDocDateStart.TabIndex = 0
      '
      'txtEditDocDateEnd
      '
      Me.txtEditDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEditDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEditDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEditDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEditDocDateEnd, System.Drawing.Color.Empty)
      Me.txtEditDocDateEnd.Location = New System.Drawing.Point(80, 38)
      Me.Validator.SetMinValue(Me.txtEditDocDateEnd, "")
      Me.txtEditDocDateEnd.Name = "txtEditDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtEditDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtEditDocDateEnd, False)
      Me.txtEditDocDateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtEditDocDateEnd.TabIndex = 1
      '
      'lblEditDocDateStart
      '
      Me.lblEditDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEditDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblEditDocDateStart.Location = New System.Drawing.Point(8, 15)
      Me.lblEditDocDateStart.Name = "lblEditDocDateStart"
      Me.lblEditDocDateStart.Size = New System.Drawing.Size(72, 18)
      Me.lblEditDocDateStart.TabIndex = 4
      Me.lblEditDocDateStart.Text = "ตั้งแต่"
      Me.lblEditDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblEditDocDateEnd
      '
      Me.lblEditDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEditDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblEditDocDateEnd.Location = New System.Drawing.Point(8, 39)
      Me.lblEditDocDateEnd.Name = "lblEditDocDateEnd"
      Me.lblEditDocDateEnd.Size = New System.Drawing.Size(72, 18)
      Me.lblEditDocDateEnd.TabIndex = 5
      Me.lblEditDocDateEnd.Text = "ถึง"
      Me.lblEditDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpEditDocDateStart
      '
      Me.dtpEditDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpEditDocDateStart.Location = New System.Drawing.Point(80, 14)
      Me.dtpEditDocDateStart.Name = "dtpEditDocDateStart"
      Me.dtpEditDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpEditDocDateStart.TabIndex = 2
      Me.dtpEditDocDateStart.TabStop = False
      '
      'dtpEditDocDateEnd
      '
      Me.dtpEditDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpEditDocDateEnd.Location = New System.Drawing.Point(80, 38)
      Me.dtpEditDocDateEnd.Name = "dtpEditDocDateEnd"
      Me.dtpEditDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpEditDocDateEnd.TabIndex = 3
      Me.dtpEditDocDateEnd.TabStop = False
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(47, 25)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(216, 21)
      Me.txtCode.TabIndex = 228
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(14, 26)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(33, 18)
      Me.lblCode.TabIndex = 229
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAccountBook
      '
      Me.lblAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountBook.ForeColor = System.Drawing.Color.Black
      Me.lblAccountBook.Location = New System.Drawing.Point(6, 141)
      Me.lblAccountBook.Name = "lblAccountBook"
      Me.lblAccountBook.Size = New System.Drawing.Size(65, 18)
      Me.lblAccountBook.TabIndex = 225
      Me.lblAccountBook.Text = "สมุดรายวัน:"
      Me.lblAccountBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountBookName
      '
      Me.txtAccountBookName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAccountBookName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.txtAccountBookName.Location = New System.Drawing.Point(119, 141)
      Me.Validator.SetMinValue(Me.txtAccountBookName, "")
      Me.txtAccountBookName.Name = "txtAccountBookName"
      Me.txtAccountBookName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountBookName, "")
      Me.Validator.SetRequired(Me.txtAccountBookName, False)
      Me.txtAccountBookName.Size = New System.Drawing.Size(144, 20)
      Me.txtAccountBookName.TabIndex = 226
      Me.txtAccountBookName.TabStop = False
      '
      'txtAccountBookCode
      '
      Me.Validator.SetDataType(Me.txtAccountBookCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.txtAccountBookCode.Location = New System.Drawing.Point(71, 141)
      Me.Validator.SetMinValue(Me.txtAccountBookCode, "")
      Me.txtAccountBookCode.Name = "txtAccountBookCode"
      Me.Validator.SetRegularExpression(Me.txtAccountBookCode, "")
      Me.Validator.SetRequired(Me.txtAccountBookCode, False)
      Me.txtAccountBookCode.Size = New System.Drawing.Size(48, 20)
      Me.txtAccountBookCode.TabIndex = 224
      '
      'ibtnShowAccountBookDialog
      '
      Me.ibtnShowAccountBookDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAccountBookDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountBookDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountBookDialog.Location = New System.Drawing.Point(265, 138)
      Me.ibtnShowAccountBookDialog.Name = "ibtnShowAccountBookDialog"
      Me.ibtnShowAccountBookDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountBookDialog.TabIndex = 227
      Me.ibtnShowAccountBookDialog.TabStop = False
      Me.ibtnShowAccountBookDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountBookDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(385, 134)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 5
      Me.btnReset.Text = "Reset"
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
      Me.grbDocDate.Location = New System.Drawing.Point(9, 56)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(254, 72)
      Me.grbDocDate.TabIndex = 0
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(80, 38)
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
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateStart.TabIndex = 4
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 39)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateEnd.TabIndex = 5
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(80, 14)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(80, 38)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 3
      Me.dtpDocDateEnd.TabStop = False
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.Location = New System.Drawing.Point(344, 24)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(104, 21)
      Me.cmbYear.TabIndex = 1
      '
      'lblYear
      '
      Me.lblYear.BackColor = System.Drawing.Color.Transparent
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblYear.Location = New System.Drawing.Point(240, 25)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(104, 18)
      Me.lblYear.TabIndex = 3
      Me.lblYear.Text = "ปีภาษี:"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(465, 134)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(72, 24)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.TabStop = False
      Me.btnSearch.Text = "Search"
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
      'CloseAccountPeriodFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CloseAccountPeriodFilterSubPanel"
      Me.Size = New System.Drawing.Size(772, 189)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.FixedGroupBox1.ResumeLayout(False)
      Me.FixedGroupBox1.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
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

    End Sub
#End Region

#Region "Members"
    Private docDateStart As Date
    Private docDateEnd As Date
    Private editdocDateStart As Date
    Private editdocDateEnd As Date

    Private m_acctbook As AccountBook

#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      '------------------------------------------------------------------
      AddHandler txtEditDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEditDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtEditDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEditDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

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
          '---------------------------------------------------------------------------------------------------------------
        Case "dtpeditdocdatestart"
          If Not Me.editdocDateStart.Equals(dtpEditDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtEditDocDateStart.Text = MinDateToNull(dtpEditDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.editdocDateStart = dtpEditDocDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txteditdocdatestart"
          m_dateSetting = True
          If Not Me.txtEditDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtEditDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtEditDocDateStart.Text)
            If Not Me.editdocDateStart.Equals(theDate) Then
              dtpEditDocDateStart.Value = theDate
              Me.editdocDateStart = dtpEditDocDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpEditDocDateStart.Value = Date.Now
            Me.editdocDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpeditdocdateend"
          If Not Me.editdocDateEnd.Equals(dtpEditDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtEditDocDateEnd.Text = MinDateToNull(dtpEditDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.editdocDateEnd = dtpEditDocDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txteditdocdateend"
          m_dateSetting = True
          If Not Me.txtEditDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtEditDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtEditDocDateEnd.Text)
            If Not Me.editdocDateEnd.Equals(theDate) Then
              dtpEditDocDateEnd.Value = theDate
              Me.editdocDateEnd = dtpEditDocDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpEditDocDateEnd.Value = Date.Now
            Me.editdocDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.dtpDocDateStart.Value = Now.Date
      Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = ""
      Me.txtDocDateEnd.Text = ""

      Me.docDateStart = Date.MinValue
      Me.docDateEnd = Date.MinValue
      '-----------------------------------------------
      Me.dtpEditDocDateStart.Value = Now.Date
      Me.dtpEditDocDateEnd.Value = Now.Date

      Me.txtEditDocDateStart.Text = ""
      Me.txtEditDocDateEnd.Text = ""

      Me.editdocDateStart = Date.MinValue
      Me.editdocDateEnd = Date.MinValue

      txtCode.Text = ""
      Me.cmbYear.SelectedIndex = 0

      Me.m_acctbook = New AccountBook

    End Sub
    Private Sub PopulateStatus()
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = New Date(2005 + i, 1, 1)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      DateTimeService.ListYearsInComboBox(Me.cmbYear, years)
    End Sub
    Public Sub SetLabelText()

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblCode}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.grbDetail}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.lblYear}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.grbDocDate}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.lblDocDateEnd}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.lblDocDateStart}")
      Me.lblEditDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.lblDocDateEnd}")
      Me.lblEditDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodFilterSubPanel.lblDocDateStart}")
      Me.lblAccountBook.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblAccountBook}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      arr(0) = New Filter("year", IIf(CDate(cmbYear.SelectedValue).Equals(Date.MinValue), DBNull.Value, Me.cmbYear.SelectedValue))
      arr(1) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(2) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))

      arr(3) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(4) = New Filter("editdocdatestart", ValidDateOrDBNull(editdocDateStart))
      arr(5) = New Filter("editdocdateend", ValidDateOrDBNull(editdocDateEnd))
      arr(6) = New Filter("acctbookid", IIf(Me.txtAccountBookCode.Text.Length > 0, Me.m_acctbook.Id, DBNull.Value))

      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
      OnSearch(e)
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
#End Region

    Private Sub ibtnShowAccountBookDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBookDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBook)
    End Sub
    Private Sub SetAccountBook(ByVal e As ISimpleEntity)
      Me.txtAccountBookCode.Text = e.Code
      AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_acctbook)
    End Sub

    Private Sub txtAccountBookCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountBookCode.Validated
      AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_acctbook)
    End Sub
  End Class
End Namespace

