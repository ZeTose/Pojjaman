Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class OpenningBalanceDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtSumDebit As System.Windows.Forms.TextBox
    Friend WithEvents lblSumDebit As System.Windows.Forms.Label
    Friend WithEvents lblSumCredit As System.Windows.Forms.Label
    Friend WithEvents txtSumCredit As System.Windows.Forms.TextBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As FixedGroupBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSumary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblProfit As System.Windows.Forms.Label
    Friend WithEvents txtProfit As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenningBalanceDetail))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtSumDebit = New System.Windows.Forms.TextBox()
      Me.lblSumDebit = New System.Windows.Forms.Label()
      Me.lblSumCredit = New System.Windows.Forms.Label()
      Me.txtSumCredit = New System.Windows.Forms.TextBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.txtProfit = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.grbSumary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblProfit = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbDetail.SuspendLayout()
      Me.grbSumary.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(48, 17)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(72, 18)
      Me.lblCode.TabIndex = 178
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(304, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDate.TabIndex = 177
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 48)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(104, 18)
      Me.lblItem.TabIndex = 195
      Me.lblItem.Text = "รายการรายวัน:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(152, 376)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(488, 21)
      Me.txtNote.TabIndex = 7
      Me.txtNote.TabStop = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(48, 377)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(104, 18)
      Me.lblNote.TabIndex = 178
      Me.lblNote.Text = "คำอธิบาย:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumDebit
      '
      Me.txtSumDebit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSumDebit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSumDebit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSumDebit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSumDebit, System.Drawing.Color.Empty)
      Me.txtSumDebit.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtSumDebit, "")
      Me.txtSumDebit.Name = "txtSumDebit"
      Me.txtSumDebit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumDebit, "")
      Me.Validator.SetRequired(Me.txtSumDebit, False)
      Me.txtSumDebit.Size = New System.Drawing.Size(96, 20)
      Me.txtSumDebit.TabIndex = 8
      Me.txtSumDebit.TabStop = False
      '
      'lblSumDebit
      '
      Me.lblSumDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumDebit.ForeColor = System.Drawing.Color.Black
      Me.lblSumDebit.Location = New System.Drawing.Point(8, 17)
      Me.lblSumDebit.Name = "lblSumDebit"
      Me.lblSumDebit.Size = New System.Drawing.Size(88, 18)
      Me.lblSumDebit.TabIndex = 201
      Me.lblSumDebit.Text = "Total Debit="
      Me.lblSumDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSumCredit
      '
      Me.lblSumCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumCredit.ForeColor = System.Drawing.Color.Black
      Me.lblSumCredit.Location = New System.Drawing.Point(208, 17)
      Me.lblSumCredit.Name = "lblSumCredit"
      Me.lblSumCredit.Size = New System.Drawing.Size(80, 18)
      Me.lblSumCredit.TabIndex = 200
      Me.lblSumCredit.Text = "Total Credit="
      Me.lblSumCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumCredit
      '
      Me.txtSumCredit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSumCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSumCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSumCredit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSumCredit, System.Drawing.Color.Empty)
      Me.txtSumCredit.Location = New System.Drawing.Point(288, 16)
      Me.Validator.SetMinValue(Me.txtSumCredit, "")
      Me.txtSumCredit.Name = "txtSumCredit"
      Me.txtSumCredit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumCredit, "")
      Me.Validator.SetRequired(Me.txtSumCredit, False)
      Me.txtSumCredit.Size = New System.Drawing.Size(96, 20)
      Me.txtSumCredit.TabIndex = 9
      Me.txtSumCredit.TabStop = False
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(400, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(400, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 205
      Me.dtpDocDate.TabStop = False
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
      'txtProfit
      '
      Me.txtProfit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProfit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProfit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProfit, System.Drawing.Color.Empty)
      Me.txtProfit.Location = New System.Drawing.Point(512, 16)
      Me.Validator.SetMinValue(Me.txtProfit, "")
      Me.txtProfit.Name = "txtProfit"
      Me.txtProfit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProfit, "")
      Me.Validator.SetRequired(Me.txtProfit, False)
      Me.txtProfit.Size = New System.Drawing.Size(96, 20)
      Me.txtProfit.TabIndex = 204
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.grbSumary)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(656, 408)
      Me.grbDetail.TabIndex = 216
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด:"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(240, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 321
      '
      'grbSumary
      '
      Me.grbSumary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSumary.Controls.Add(Me.lblProfit)
      Me.grbSumary.Controls.Add(Me.txtProfit)
      Me.grbSumary.Controls.Add(Me.lblSumCredit)
      Me.grbSumary.Controls.Add(Me.txtSumDebit)
      Me.grbSumary.Controls.Add(Me.lblSumDebit)
      Me.grbSumary.Controls.Add(Me.txtSumCredit)
      Me.grbSumary.Location = New System.Drawing.Point(24, 320)
      Me.grbSumary.Name = "grbSumary"
      Me.grbSumary.Size = New System.Drawing.Size(616, 48)
      Me.grbSumary.TabIndex = 223
      Me.grbSumary.TabStop = False
      Me.grbSumary.Text = "grbSumary"
      '
      'lblProfit
      '
      Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProfit.ForeColor = System.Drawing.Color.Black
      Me.lblProfit.Location = New System.Drawing.Point(392, 16)
      Me.lblProfit.Name = "lblProfit"
      Me.lblProfit.Size = New System.Drawing.Size(120, 18)
      Me.lblProfit.TabIndex = 203
      Me.lblProfit.Text = "กำไร/ขาดทุนสะสม="
      Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(112, 40)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 222
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(136, 40)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 221
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 64)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(632, 248)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 217
      Me.tgItem.TreeManager = Nothing
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(119, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 369
      '
      'OpenningBalanceDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "OpenningBalanceDetail"
      Me.Size = New System.Drawing.Size(672, 424)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbSumary.ResumeLayout(False)
      Me.grbSumary.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As OpenningBalance
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = OpenningBalance.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()

    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "OpenningBalance"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "opbi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "opbi_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      csButton.ButtonColor = Color.Lavender

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csDebitAmount As New TreeTextColumn
      csDebitAmount.MappingName = "DebitAmount"
      csDebitAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.DebitAmountHeaderText}")
      csDebitAmount.NullText = ""
      csDebitAmount.DataAlignment = HorizontalAlignment.Right
      csDebitAmount.Format = "#,###.##"
      csDebitAmount.TextBox.Name = "DebitAmount"
      csDebitAmount.Width = 60

      Dim csCreditAmount As New TreeTextColumn
      csCreditAmount.MappingName = "CreditAmount"
      csCreditAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.CreditAmountHeaderText}")
      csCreditAmount.NullText = ""
      csCreditAmount.DataAlignment = HorizontalAlignment.Right
      csCreditAmount.Format = "#,###.##"
      csCreditAmount.TextBox.Name = "CreditAmount"
      csCreditAmount.Width = 60

      Dim csCCCode As New TreeTextColumn
      csCCCode.MappingName = "CCCode"
      csCCCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.CCCodeHeaderText}")
      csCCCode.NullText = ""
      csCCCode.TextBox.Name = "CCCode"
      csCCCode.Width = 60
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""
      AddHandler csCCButton.Click, AddressOf CCClicked

      Dim csCCName As New TreeTextColumn
      csCCName.MappingName = "CCName"
      csCCName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.CCNameHeaderText}")
      csCCName.NullText = ""
      csCCName.TextBox.Name = "CCName"
      csCCName.ReadOnly = True
      csCCName.Width = 100

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "opbi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.TextBox.Name = "opbi_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csDebitAmount)
      dst.GridColumnStyles.Add(csCreditAmount)
      dst.GridColumnStyles.Add(csCCCode)
      dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csCCName)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Sub CCClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        AcctButtonClick(e)
      Else
        CCButtonClick(e)
      End If
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = True
        Next
      End If
    End Sub

    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.lblCode}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.lblItem}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblSumDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.lblSumDebit}")
      Me.lblSumCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.lblSumCredit}")
      Me.grbSumary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OpenningBalanceDetail.grbSumary}")
      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtNote.Text = m_entity.Note
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      UpdateAmount(True)

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshGross()
      End If
      Me.txtSumCredit.Text = Configuration.FormatToString(Me.m_entity.CreditAmount, DigitConfig.Price)
      Me.txtSumDebit.Text = Configuration.FormatToString(Me.m_entity.DebitAmount, DigitConfig.Price)
      Me.txtProfit.Text = Configuration.FormatToString(Me.m_entity.Profit, DigitConfig.Price)
      m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount(True)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            m_entity.Code = m_entity.AutoCodeFormat.Format
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
          End If
          m_dateSetting = False
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, OpenningBalance)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub


#End Region

#Region "Buttons Event"
#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
            m_entity.Code = m_entity.AutoCodeFormat.Format
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.AutoGen = True
      Else
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts)
    End Sub
    Private Sub SetAccts(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim acct As New Account(item.Id)
        If acct.Originated AndAlso Not acct.IsControlGroup Then
          Dim myItem As New OpenningBalanceItem
          myItem.Account = acct
          If i = items.Count - 1 Then
            If Me.m_entity.ItemTable.Childs.Count = 0 Then
              Me.m_entity.Add(myItem)
            Else
              'myItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("opbi_linenumber"))
              'myItem.OpenningBalance = Me.m_entity
              'myItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
              Me.m_treeManager.SelectedRow("Code") = acct.Code
            End If
          Else
            Me.m_entity.Insert(index, myItem)
          End If
          Me.m_entity.ItemTable.AcceptChanges()
        End If
      Next
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Public Sub CCButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCC)
    End Sub
    Private Sub SetCC(ByVal cc As ISimpleEntity)
      Me.m_treeManager.SelectedRow("CCCode") = cc.Code
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim myItem As New OpenningBalanceItem
      myItem.Account = New Account
      Me.m_entity.Insert(index, myItem)
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New OpenningBalance).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_entity.ItemTable.Childs.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop

      'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

      If Me.m_entity.MaxRowIndex = Me.m_entity.ItemTable.Childs.Count - 1 Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_entity.AddBlankRow(1)
      End If
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace