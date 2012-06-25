Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ReceiveSelectionDetail
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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbCustomer As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblRemaining As System.Windows.Forms.Label
    Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
    Friend WithEvents lblRemainingUnit As System.Windows.Forms.Label
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents chkSingleVat As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceiveSelectionDetail))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.txtRemaining = New System.Windows.Forms.TextBox()
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbCustomer = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblRemaining = New System.Windows.Forms.Label()
      Me.lblRemainingUnit = New System.Windows.Forms.Label()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.lblGrossUnit = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.chkSingleVat = New System.Windows.Forms.CheckBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.chkShowDetail = New System.Windows.Forms.CheckBox()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCustomer.SuspendLayout()
      Me.grbSummary.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
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
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(188, 20)
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(184, 20)
      Me.txtCustomerName.TabIndex = 5
      Me.txtCustomerName.TabStop = False
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(88, 20)
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(100, 20)
      Me.txtCustomerCode.TabIndex = 0
      '
      'txtRemaining
      '
      Me.txtRemaining.BackColor = System.Drawing.SystemColors.Control
      Me.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRemaining, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
      Me.txtRemaining.Location = New System.Drawing.Point(544, 21)
      Me.Validator.SetMaxValue(Me.txtRemaining, "")
      Me.Validator.SetMinValue(Me.txtRemaining, "")
      Me.txtRemaining.Name = "txtRemaining"
      Me.txtRemaining.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRemaining, "")
      Me.Validator.SetRequired(Me.txtRemaining, False)
      Me.txtRemaining.Size = New System.Drawing.Size(120, 20)
      Me.txtRemaining.TabIndex = 7
      Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtItemCount
      '
      Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(104, 21)
      Me.Validator.SetMaxValue(Me.txtItemCount, "")
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(58, 20)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtGross
      '
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.txtGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(315, 21)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(120, 20)
      Me.txtGross.TabIndex = 4
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(376, 58)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(424, 20)
      Me.txtNote.TabIndex = 4
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(272, 16)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, False)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(144, 77)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 12
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbCustomer
      '
      Me.grbCustomer.Controls.Add(Me.ibtnShowCustomer)
      Me.grbCustomer.Controls.Add(Me.txtCustomerName)
      Me.grbCustomer.Controls.Add(Me.txtCustomerCode)
      Me.grbCustomer.Controls.Add(Me.ibtnShowCustomerDialog)
      Me.grbCustomer.Controls.Add(Me.lblCustomer)
      Me.grbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCustomer.Location = New System.Drawing.Point(376, 0)
      Me.grbCustomer.Name = "grbCustomer"
      Me.grbCustomer.Size = New System.Drawing.Size(424, 54)
      Me.grbCustomer.TabIndex = 2
      Me.grbCustomer.TabStop = False
      Me.grbCustomer.Text = "Custumer"
      '
      'ibtnShowCustomer
      '
      Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomer.Location = New System.Drawing.Point(395, 20)
      Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
      Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomer.TabIndex = 4
      Me.ibtnShowCustomer.TabStop = False
      Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCustomerDialog
      '
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(372, 20)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 3
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(16, 20)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(72, 18)
      Me.lblCustomer.TabIndex = 9
      Me.lblCustomer.Text = "Custumer:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(216, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 7
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(272, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 9
      Me.dtpDocDate.TabStop = False
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.lblRemaining)
      Me.grbSummary.Controls.Add(Me.txtRemaining)
      Me.grbSummary.Controls.Add(Me.lblRemainingUnit)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.Controls.Add(Me.lblGrossUnit)
      Me.grbSummary.Controls.Add(Me.txtGross)
      Me.grbSummary.Controls.Add(Me.lblGross)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Location = New System.Drawing.Point(96, 344)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(704, 53)
      Me.grbSummary.TabIndex = 5
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปรายการรับวางบิล"
      '
      'lblRemaining
      '
      Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemaining.Location = New System.Drawing.Point(469, 21)
      Me.lblRemaining.Name = "lblRemaining"
      Me.lblRemaining.Size = New System.Drawing.Size(72, 18)
      Me.lblRemaining.TabIndex = 6
      Me.lblRemaining.Text = "ยอดค้างชำระ"
      Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemainingUnit
      '
      Me.lblRemainingUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemainingUnit.Location = New System.Drawing.Point(664, 21)
      Me.lblRemainingUnit.Name = "lblRemainingUnit"
      Me.lblRemainingUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRemainingUnit.TabIndex = 8
      Me.lblRemainingUnit.Text = "บาท"
      Me.lblRemainingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblItemCount
      '
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(20, 21)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(80, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการ"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(165, 21)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblGrossUnit
      '
      Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGrossUnit.Location = New System.Drawing.Point(437, 21)
      Me.lblGrossUnit.Name = "lblGrossUnit"
      Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblGrossUnit.TabIndex = 5
      Me.lblGrossUnit.Text = "บาท"
      Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblGross
      '
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(219, 21)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(96, 18)
      Me.lblGross.TabIndex = 3
      Me.lblGross.Text = "รวมมูลค่ารับวางบิล"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 6
      Me.lblCode.Text = "Document No.:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(232, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 8
      Me.lblDocDate.Text = "Date:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 81)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 10
      Me.lblItem.Text = "Pay Selection:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 102)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(792, 240)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 14
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(120, 77)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 11
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(278, 58)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 13
      Me.lblNote.Text = "Remark:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkSingleVat
      '
      Me.chkSingleVat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSingleVat.Location = New System.Drawing.Point(96, 46)
      Me.chkSingleVat.Name = "chkSingleVat"
      Me.chkSingleVat.Size = New System.Drawing.Size(176, 24)
      Me.chkSingleVat.TabIndex = 3
      Me.chkSingleVat.Text = "One Tax Invoice"
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 15
      '
      'chkShowDetail
      '
      Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chkShowDetail.Location = New System.Drawing.Point(184, 77)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.chkShowDetail.Size = New System.Drawing.Size(160, 24)
      Me.chkShowDetail.TabIndex = 16
      Me.chkShowDetail.Text = "Show Milestone Detail"
      '
      'ReceiveSelectionDetail
      '
      Me.Controls.Add(Me.chkShowDetail)
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.chkSingleVat)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.grbCustomer)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "ReceiveSelectionDetail"
      Me.Size = New System.Drawing.Size(808, 400)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCustomer.ResumeLayout(False)
      Me.grbCustomer.PerformLayout()
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As ReceiveSelection
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = ReceiveSelection.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbCustomer.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbSummary.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "ReceiveSelection"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "receivesi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "receivesi_linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("receivesi_entityType", CodeDescription.GetCodeList("receivesi_entityType", "code_value not in (49)"), "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty
      csType.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"
      csCode.Width = 150
      csCode.ReadOnly = True

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf ItemButtonClick

      Dim csDocDate As New DataGridTimePickerColumn
      csDocDate.MappingName = "DocDate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      csDocDate.ReadOnly = True

      Dim csDueDate As New DataGridTimePickerColumn
      csDueDate.MappingName = "DueDate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.ReadOnly = True

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.Format = "#,###.##"
      csRealAmount.ReadOnly = True
      csRealAmount.TextBox.Name = "RealAmount"

      Dim csRetentionAmount As New TreeTextColumn
      csRetentionAmount.MappingName = "RetentionAmount"
      csRetentionAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.RetentionAmountHeaderText}")
      csRetentionAmount.NullText = ""
      csRetentionAmount.DataAlignment = HorizontalAlignment.Right
      csRetentionAmount.Format = "#,###.##"
      'csRetentionAmount.ReadOnly = True
      csRetentionAmount.TextBox.Name = "RetentionAmount"

      Dim csUnreceivedAmount As New TreeTextColumn
      csUnreceivedAmount.MappingName = "UnreceivedAmount"
      csUnreceivedAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.UnreceivedAmountHeaderText}")
      csUnreceivedAmount.NullText = ""
      csUnreceivedAmount.DataAlignment = HorizontalAlignment.Right
      csUnreceivedAmount.Format = "#,###.##"
      csUnreceivedAmount.ReadOnly = True
      csUnreceivedAmount.TextBox.Name = "UnreceivedAmount"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "receivesi_amt"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "receivesi_amt"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "receivesi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "receivesi_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csDocDate)
      dst.GridColumnStyles.Add(csDueDate)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csRetentionAmount)
      dst.GridColumnStyles.Add(csUnreceivedAmount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentWorkingDoc() As ISimpleEntity
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If TypeOf row.Tag Is SaleBillIssueItem Then
          Dim parRow As TreeRow = CType(row.Parent, TreeRow)
          Dim id As Integer = CInt(parRow("receivesi_parentEntity"))
          Dim code As String = CStr(parRow("Code"))
          Dim si As New SaleBillIssue
          si.Id = id
          si.Code = code
        End If
        If TypeOf row.Tag Is SaleBillIssue Then
          Return CType(row.Tag, SaleBillIssue)
        End If
        Return Nothing
      End Get
    End Property
    Private ReadOnly Property CurrentItem() As SaleBillIssueItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is SaleBillIssueItem Then
          Return Nothing
        End If
        Return CType(row.Tag, SaleBillIssueItem)
      End Get
    End Property
    Private ReadOnly Property CurrentParItem() As IHasIBillablePerson
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is IHasIBillablePerson Then
          Return Nothing
        End If
        Return CType(row.Tag, IHasIBillablePerson)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Level = 0 Then
        Return
      End If
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.UpdateAmount()
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
			RefreshDocs()
			UpdateVat(True)
			tgItem.CurrentRowIndex = index
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Level = 0 Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If Me.CurrentItem Is Nothing Then
        Dim doc As New SaleBillIssueItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "receivesi_entitytype"
            SetEntityType(e)
          Case "duedate"
            SetDueDate(e)
          Case "docdate"
            SetDate(e)
          Case "realamount"
            SetRealAmount(e)
          Case "receivesi_amt"
            If IsNumeric(e.ProposedValue) Then
              SetAmount(e)
            End If
          Case "retentionamount"
            If IsNumeric(e.ProposedValue) Then
              SetRetentionAmount(e)
            End If
          Case "receivesi_note"
              SetNote(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim receivesi_entitytype As Object = e.Row("receivesi_entitytype")
      Dim receivesi_amt As Object = e.Row("receivesi_amt")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "receivesi_entitytype"
          receivesi_entitytype = e.ProposedValue
        Case "receivesi_amt"
          receivesi_amt = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(receivesi_entitytype) Then
        isBlankRow = True
      End If
      If Not isBlankRow Then
        Select Case CInt(receivesi_entitytype)
          Case 83 'ขายของ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsSoldCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 124 'ขายสินทรัพย์
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AssetSoldCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 56 'คืนเครื่องจักร
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AssetReturnCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 48 'ลดหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.SaleCNCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 49 'เพิ่มหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.SaleDNCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 24 'ลูกหนี้ยกมา
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AROpeningBalanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case Else
            Return
        End Select
        If IsDBNull(receivesi_amt) OrElse Not IsNumeric(receivesi_amt) OrElse CDec(receivesi_amt) <= 0 Then
          If IsNumeric(receivesi_amt) Then
            e.Row.SetColumnError("receivesi_amt", Me.StringParserService.Parse("${res:Global.Error.SaleBillIssueAmountMissing}"))
          End If
        Else
          e.Row.SetColumnError("receivesi_amt", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.Tag Is Nothing Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      m_updating = True
      doc.Note = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim remain As Decimal = doc.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
      remain = Math.Min(doc.BilledAmount, remain)
      Dim remain2 As Decimal = Me.m_entity.ItemCollection.GetRemainFromOtherDocs(doc)
      remain = Math.Min(remain, remain2)

      m_updating = True
      If doc.UnreceivedAmount <> remain Then
        doc.UnreceivedAmount = remain
        e.Row("UnreceivedAmount") = Configuration.FormatToString(doc.UnreceivedAmount, DigitConfig.Price)
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivesi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveSEntityType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If Configuration.Compare(remain, value, DigitConfig.Price) < 0 Then
        msgServ.ShowMessageFormatted("${res:Global.Error.ReceiveSRemainingAmountLessThanAmount}", _
        New String() { _
        Configuration.FormatToString(remain, DigitConfig.Price) _
        , Configuration.FormatToString(value, DigitConfig.Price) _
        })

        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      doc.Amount = value
      If doc.ParentType = 81 Then
        If doc.BilledAmount <> 0 Then
          Dim docRet As Decimal = doc.GetMilestoneRetention
          e.ProposedValue = value / (doc.BilledAmount - docRet) * docRet
        Else
          e.ProposedValue = 0
        End If
        m_updating = False
        SetRetentionAmount(e.ProposedValue)
      Else
        UpdateVat(True)
      End If
      m_updating = False
    End Sub
    Public Sub SetRetentionAmount(ByVal value As Decimal)
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If doc.ParentType <> 81 Then
        value = 0
      End If
      If doc.ParentType = 81 Then
        Dim remain As Decimal = doc.GetRemainingRetention(Me.m_entity.Id)

        Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
        Dim apRetentionPoint As Integer = 0
        If IsNumeric(tmp) Then
          apRetentionPoint = CInt(tmp)
        End If
        Dim atBill As Boolean = (apRetentionPoint = 0)
        If atBill Then
          If doc.UnreceivedAmount = doc.Amount Then
            value = remain
          End If
        Else
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          If Configuration.Compare(remain, value, DigitConfig.Price) < 0 Then
            msgServ.ShowMessageFormatted("${res:Global.Error.ReceiveSRemainingAmountLessThanAmount}", _
            New String() { _
            Configuration.FormatToString(remain, DigitConfig.Price) _
            , Configuration.FormatToString(value, DigitConfig.Price) _
            })

            Return
          End If
        End If
      End If
      doc.ARretention = value
      UpdateVat(True)
    End Sub
    Public Sub SetRetentionAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 OrElse doc.ParentType <> 81 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      If doc.ParentType = 81 Then
        Dim remain As Decimal = doc.GetRemainingRetention(Me.m_entity.Id)
        'remain = Math.Min(doc.Retention, remain)


        m_updating = True
        'If doc.UnreceivedAmount <> remain Then
        '  doc.UnreceivedAmount = remain
        '  e.Row("UnreceivedAmount") = Configuration.FormatToString(doc.UnreceivedAmount, DigitConfig.Price)
        'End If
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If e.Row.IsNull("receivesi_entityType") Then
          msgServ.ShowMessage("${res:Global.Error.NoReceiveSEntityType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        End If

        Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
        Dim apRetentionPoint As Integer = 0
        If IsNumeric(tmp) Then
          apRetentionPoint = CInt(tmp)
        End If
        Dim atBill As Boolean = (apRetentionPoint = 0)
        If atBill Then
          If doc.UnreceivedAmount = doc.Amount Then
            value = remain
          End If
        Else
          If Configuration.Compare(remain, value, DigitConfig.Price) < 0 Then
            msgServ.ShowMessageFormatted("${res:Global.Error.ReceiveSRemainingAmountLessThanAmount}", _
            New String() { _
            Configuration.FormatToString(remain, DigitConfig.Price) _
            , Configuration.FormatToString(value, DigitConfig.Price) _
            })
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          End If
        End If
      End If
      doc.ARretention = value
      UpdateVat(True)
      m_updating = False
    End Sub
    Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeRealAmount}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDueDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull(e.Column) Then
        m_updating = False
        Return
      End If

      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        'ผ่านโลด
        m_updating = False
        Return
      End If
      If msgServ.AskQuestion("${res:Global.Question.ChangeReceiveSEntityType}") Then
        e.Row("receivesi_entity") = DBNull.Value
        e.Row("code") = DBNull.Value
        e.Row("RealAmount") = DBNull.Value
        e.Row("receivesi_amt") = DBNull.Value
        e.Row("UnreceivedAmount") = DBNull.Value
        e.Row("DueDate") = Date.MinValue
        e.Row("DocDate") = Date.MinValue
        doc.Clear()
      Else
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("receivesi_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      For Each item As SaleBillIssueItem In Me.m_entity.ItemCollection
        If Not doc Is item Then
          If item.EntityId = CInt(e.Row("receivesi_entityType")) Then
            If e.ProposedValue.ToString.ToLower = item.Code.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If doc Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivesi_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveSEntityType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {BusinessLogic.Entity.GetFullClassName(doc.EntityId), e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivesi_entityType"))
        Case 83 'ขายของ
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsSoldDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("receivesi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnreceivedAmount") = DBNull.Value
                e.Row("receivesi_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim gs As New GoodsSold(e.ProposedValue.ToString)
          If Not gs.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsSold}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If gs.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.GoodsSoldIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = gs.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessGoodsSoldAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("receivesi_entity") = gs.Id
            e.ProposedValue = gs.Code
            e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
            e.Row("receivesi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = gs.DueDate
            e.Row("DocDate") = gs.DocDate
            doc.Id = gs.Id
            doc.RealAmount = gs.Receive.Amount
            doc.UnreceivedAmount = remain
            doc.Amount = remain
            doc.Code = gs.Code
            doc.Date = gs.DocDate
            doc.CreditPeriod = gs.CreditPeriod
            doc.SetType(83)
          End If
        Case 56 'คืนเครื่องจักร
          'If e.ProposedValue.ToString.Length = 0 Then
          '    If e.Row(e.Column).ToString.Length <> 0 Then
          '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetReturnDetail}", New String() {e.Row(e.Column).ToString}) Then
          '            e.Row("salebillii_entity") = DBNull.Value
          '            e.Row("RealAmount") = DBNull.Value
          '            e.Row("UnreceivedAmount") = DBNull.Value
          '            e.Row("salebillii_amt") = DBNull.Value
          '            e.Row("DueDate") = Date.MinValue
          '            e.Row("DocDate") = Date.MinValue
          '            doc.Clear()
          '        Else
          '            e.ProposedValue = e.Row(e.Column)
          '        End If
          '    End If
          '    m_updating = False
          '    Return
          'End If
          'Dim gs As New AssetReturn(e.ProposedValue.ToString)
          'If Not gs.Originated Then
          '    msgServ.ShowMessageFormatted("${res:Global.Error.NoAssetReturn}", New String() {e.ProposedValue.ToString})
          '    e.ProposedValue = e.Row(e.Column)
          '    m_updating = False
          '    Return
          'Else
          '    If gs.Status.Value = 0 Then
          '        msgServ.ShowMessageFormatted("${res:Global.Error.AssetReturnIsCanceled}", New String() {e.ProposedValue.ToString})
          '        e.ProposedValue = e.Row(e.Column)
          '        m_updating = False
          '        Return
          '    End If
          '    Dim remain As Decimal = gs.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
          '    If remain <= 0 Then
          '        msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAssetReturnAmount}", New String() {e.ProposedValue.ToString})
          '        e.ProposedValue = e.Row(e.Column)
          '        m_updating = False
          '        Return
          '    End If
          '    e.Row("salebillii_entity") = gs.Id
          '    e.ProposedValue = gs.Code
          '    e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
          '    e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
          '    e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
          '    e.Row("DueDate") = gs.DueDate
          '    e.Row("DocDate") = gs.DocDate
          '    doc.Id = gs.Id
          '    doc.RealAmount = gs.Receive.Amount
          '    doc.UnreceivedAmount = remain
          '    doc.Amount = remain
          '    doc.Code = gs.Code
          '    doc.Date = gs.DocDate
          '    doc.CreditPeriod = gs.CreditPeriod
          '    doc.SetType(83)
          'End If
        Case 124 'ขายสินทรัพย์
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetSoldDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("salebillii_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnreceivedAmount") = DBNull.Value
                e.Row("salebillii_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim gs As New AssetSold(e.ProposedValue.ToString)
          If Not gs.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAssetSold}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If gs.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.AssetSoldIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = gs.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAssetSoldAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("salebillii_entity") = gs.Id
            e.ProposedValue = gs.Code
            e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
            e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = gs.DueDate
            e.Row("DocDate") = gs.DocDate
            doc.Id = gs.Id
            doc.RealAmount = gs.Receive.Amount
            doc.UnreceivedAmount = remain
            doc.Amount = remain
            doc.Code = gs.Code
            doc.Date = gs.DocDate
            doc.CreditPeriod = gs.CreditPeriod
            doc.SetType(83)
          End If
          'Case 48 'ลดหนี้
          '    If e.ProposedValue.ToString.Length = 0 Then
          '        If e.Row(e.Column).ToString.Length <> 0 Then
          '            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteSaleCNDetail}", New String() {e.Row(e.Column).ToString}) Then
          '                e.Row("receivesi_entity") = DBNull.Value
          '                e.Row("RealAmount") = DBNull.Value
          '                e.Row("UnreceivedAmount") = DBNull.Value
          '                e.Row("receivesi_amt") = DBNull.Value
          '                e.Row("DueDate") = Date.MinValue
          '                e.Row("DocDate") = Date.MinValue
          '                doc.Clear()
          '            Else
          '                e.ProposedValue = e.Row(e.Column)
          '            End If
          '        End If
          '        m_updating = False
          '        Return
          '    End If
          '    Dim scn As New SaleCN(e.ProposedValue.ToString)
          '    If Not scn.Originated Then
          '        msgServ.ShowMessageFormatted("${res:Global.Error.NoSaleCN}", New String() {e.ProposedValue.ToString})
          '        e.ProposedValue = e.Row(e.Column)
          '        m_updating = False
          '        Return
          '    Else
          '        If scn.Status.Value = 0 Then
          '            msgServ.ShowMessageFormatted("${res:Global.Error.SaleCNIsCanceled}", New String() {e.ProposedValue.ToString})
          '            e.ProposedValue = e.Row(e.Column)
          '            m_updating = False
          '            Return
          '        End If
          '        Dim remain As Decimal = scn.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
          '        If remain <= 0 Then
          '            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessSaleCNAmount}", New String() {e.ProposedValue.ToString})
          '            e.ProposedValue = e.Row(e.Column)
          '            m_updating = False
          '            Return
          '        End If
          '        e.Row("receivesi_entity") = scn.Id
          '        e.ProposedValue = scn.Code
          '        e.Row("RealAmount") = Configuration.FormatToString(scn.Receive.Amount, DigitConfig.Price)
          '        e.Row("receivesi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
          '        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
          '        e.Row("DueDate") = scn.DueDate
          '        e.Row("DocDate") = scn.DocDate
          '        doc.Id = scn.Id
          '        doc.RealAmount = scn.Receive.Amount
          '        doc.UnreceivedAmount = remain
          '        doc.Amount = remain
          '        doc.Code = scn.Code
          '        doc.Date = scn.DocDate
          '        doc.CreditPeriod = scn.CreditPeriod
          '        doc.SetType(46)
          '    End If
          'Case 49 'เพิ่มหนี้
          '    If e.ProposedValue.ToString.Length = 0 Then
          '        If e.Row(e.Column).ToString.Length <> 0 Then
          '            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteSaleDNDetail}", New String() {e.Row(e.Column).ToString}) Then
          '                e.Row("receivesi_entity") = DBNull.Value
          '                e.Row("RealAmount") = DBNull.Value
          '                e.Row("UnreceivedAmount") = DBNull.Value
          '                e.Row("receivesi_amt") = DBNull.Value
          '                e.Row("DueDate") = Date.MinValue
          '                e.Row("DocDate") = Date.MinValue
          '                doc.Clear()
          '            Else
          '                e.ProposedValue = e.Row(e.Column)
          '            End If
          '        End If
          '        m_updating = False
          '        Return
          '    End If
          '    Dim sdn As New SaleDN(e.ProposedValue.ToString)
          '    If Not sdn.Originated Then
          '        msgServ.ShowMessageFormatted("${res:Global.Error.NoSaleDN}", New String() {e.ProposedValue.ToString})
          '        e.ProposedValue = e.Row(e.Column)
          '        m_updating = False
          '        Return
          '    Else
          '        If sdn.Status.Value = 0 Then
          '            msgServ.ShowMessageFormatted("${res:Global.Error.SaleDNIsCanceled}", New String() {e.ProposedValue.ToString})
          '            e.ProposedValue = e.Row(e.Column)
          '            m_updating = False
          '            Return
          '        End If
          '        Dim remain As Decimal = sdn.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
          '        If remain <= 0 Then
          '            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessSaleDNAmount}", New String() {e.ProposedValue.ToString})
          '            e.ProposedValue = e.Row(e.Column)
          '            m_updating = False
          '            Return
          '        End If
          '        e.Row("receivesi_entity") = sdn.Id
          '        e.ProposedValue = sdn.Code
          '        e.Row("RealAmount") = Configuration.FormatToString(sdn.Receive.Amount, DigitConfig.Price)
          '        e.Row("receivesi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
          '        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
          '        e.Row("DueDate") = sdn.DueDate
          '        e.Row("DocDate") = sdn.DocDate
          '        doc.Id = sdn.Id
          '        doc.RealAmount = sdn.Receive.Amount
          '        doc.UnreceivedAmount = remain
          '        doc.Amount = remain
          '        doc.Code = sdn.Code
          '        doc.Date = sdn.DocDate
          '        doc.CreditPeriod = sdn.CreditPeriod
          '        doc.SetType(46)
          '    End If
        Case 24 'ลูกหนี้ยกมา
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAROpeningBalanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("receivesi_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("receivesi_amt") = DBNull.Value
                e.Row("UnreceivedAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim apo As New AROpeningBalance(e.ProposedValue.ToString)
          If Not apo.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAROpeningBalance}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If apo.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.AROpeningBalanceIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = apo.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAROpeningBalanceAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("receivesi_entity") = apo.Id
            e.ProposedValue = apo.Code
            e.Row("RealAmount") = Configuration.FormatToString(apo.Receive.Amount, DigitConfig.Price)
            e.Row("receivesi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = apo.DueDate
            e.Row("DocDate") = apo.DocDate
            doc.Id = apo.Id
            doc.RealAmount = apo.Receive.Amount
            doc.UnreceivedAmount = remain
            doc.Amount = remain
            doc.Code = apo.Code
            doc.Date = apo.DocDate
            doc.CreditPeriod = apo.CreditPeriod
            doc.SetType(46)
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoSaleBillIssueEntityType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 Or Me.m_entity.Status.Value >= 3 OrElse m_entityRefed = 1 Then
        'Me.Enabled = False
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = True
        Next
      Else
        'Me.Enabled = True
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = False
        Next
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In grbCustomer.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In grbSummary.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next

      Me.dtpDocDate.Value = Now

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, Me.lblDocDate.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.txtDocDate, Me.lblDocDate.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblItem}")
      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.grbSummary}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblItemCount}")
      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Global.ItemCountUnitText}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.grbCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.grbCustomer}")
      Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.txtCustomerCodeAlert}"))
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblCustomer}")
      Me.lblRemainingUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.lblGross}")
      Me.chkShowDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.chkShowDetail}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtDocDate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler chkSingleVat.CheckedChanged, AddressOf Me.ChangeProperty


      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextHandler

      RemoveHandler tgItem.DoubleClick, AddressOf CellDblClick
      AddHandler tgItem.DoubleClick, AddressOf CellDblClick
    End Sub
    Private customerCodeChanged As Boolean = False
    Private txtCreditPeriodChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcustomercode"
          customerCodeChanged = True
        Case "txtcreditperiod"
          txtCreditPeriodChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldCustId = Me.m_entity.Customer.Id

      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code

      txtNote.Text = m_entity.Note
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtCustomerCode.Text = m_entity.Customer.Code
      txtCustomerName.Text = m_entity.Customer.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      RefreshDocs()
			UpdateVat(False)

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
		Private Sub UpdateVat(ByVal force As Boolean)
			'Vat
			Me.m_entity.RefreshTaxBase()

			If force AndAlso Configuration.Compare(Me.m_entity.Vat.TaxBase, Me.m_entity.GetMaximumTaxBase, DigitConfig.Price) <> 0 Then
				If Me.m_entity.SingleVat Then
					Me.m_entity.GenSingleVatItem()
				Else
					Me.m_entity.GenVatItems()
				End If
			ElseIf force Then
        If Me.m_entity.ItemCollection.Count = 1 AndAlso Me.m_entity.ItemCollection.Amount <> 0 Then
          Me.m_entity.GenVatItems()
        End If
			End If
			Dim flag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
			Me.WorkbenchWindow.ViewContent.IsDirty = False
			If Me.m_entity.NoVat Then
				Me.chkSingleVat.Enabled = False
				Me.m_entity.Vat.ItemCollection.Clear()
			Else
				Me.chkSingleVat.Enabled = True
				Me.chkSingleVat.Checked = Me.m_entity.SingleVat
			End If
			Me.WorkbenchWindow.ViewContent.IsDirty = flag
		End Sub
		Private Sub RefreshDocs()
			Me.m_isInitialized = False
			Me.m_entity.ItemCollection.PopulateReceiveSelectionItem(m_treeManager.Treetable)
			RefreshBlankGrid()
			ReIndex()
			Me.m_treeManager.Treetable.AcceptChanges()
			Me.m_isInitialized = True
		End Sub
		Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
			If e.Name = "ItemChanged" Then
				Me.WorkbenchWindow.ViewContent.IsDirty = True
			End If
		End Sub
		Private m_dateSetting As Boolean = False
		Private oldCustId As Integer
		Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
			If Me.m_entity Is Nothing Or Not m_isInitialized Then
				Return
			End If
			Dim dirtyFlag As Boolean = False
			Select Case CType(sender, Control).Name.ToLower
        Case "chksinglevat"
          If (Not isfirstset AndAlso m_entity.Originated) OrElse m_entity.SingleVat <> Me.chkSingleVat.Checked Then
            If Not Me.m_entity.NoVat Then
              If chkSingleVat.Checked Then
                Me.m_entity.GenSingleVatItem()
              Else
                Me.m_entity.GenVatItems()
              End If
              Me.m_entity.SingleVat = Me.chkSingleVat.Checked
            End If
            dirtyFlag = True
          End If
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          Me.m_entity.Receive.Note = txtNote.Text
          Me.m_entity.JournalEntry.Note = txtNote.Text
          dirtyFlag = True
        Case "txtcustomercode"
          If customerCodeChanged Then
            customerCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.txtCustomerCode.TextLength <> 0 Then
              Dim oldCustomer As Customer = Me.m_entity.Customer
              ContactCustomer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
              Try
                If oldCustId <> Me.m_entity.Customer.Id Then
                  If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.Message.ChangeCustomer}", "${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.Caption.ChangeCustomer}") Then
                    oldCustId = Me.m_entity.Customer.Id
                    dirtyFlag = True
                    ChangeCustomer()
                  Else
                    dirtyFlag = False
                    Me.m_entity.Customer = oldCustomer
                    Me.txtCustomerCode.Text = oldCustomer.Code
                    Me.txtCustomerName.Text = oldCustomer.Name
                    customerCodeChanged = False
                  End If
                End If
              Catch ex As Exception

              End Try
            End If
          End If

        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.m_entity.Receive.DocDate = dtpDocDate.Value
              Me.m_entity.JournalEntry.DocDate = dtpDocDate.Value
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
              For Each wht As WitholdingTax In Me.m_entity.WitholdingTaxCollection
                wht.DocDate = Me.m_entity.DocDate
              Next
              Me.m_entity.Receive.DocDate = dtpDocDate.Value
              Me.m_entity.JournalEntry.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
      End Select
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
			CheckFormEnable()
		End Sub
		Private Sub ChangeCustomer()
			oldCustId = Me.m_entity.Customer.Id
			Me.m_entity.ItemCollection.Clear()
			RefreshDocs()
			UpdateVat(True)
			UpdateAmount()
			customerCodeChanged = False
			Me.m_entity.CreditPeriod = Me.m_entity.Customer.CreditPeriod
			txtCreditPeriodChanged = False
		End Sub
		Private Sub UpdateAmount()
			m_isInitialized = False
			txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
			Me.txtItemCount.Text = Configuration.FormatToString(m_entity.ItemCount, DigitConfig.Int)
			Me.txtRemaining.Text = Configuration.FormatToString(m_entity.RemainingAmountAfter, DigitConfig.Price)
			m_isInitialized = True
		End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Dim isfirstset As Boolean = False
    Dim m_entityRefed As Integer
		Public Overrides Property Entity() As ISimpleEntity
			Get
				Return Me.m_entity
			End Get
			Set(ByVal Value As ISimpleEntity)
				If Not m_entity Is Nothing Then
					RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
					Me.m_entity = Nothing
				End If
        Me.m_entity = CType(Value, ReceiveSelection)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
				'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        isfirstset = True
				UpdateEntityProperties()
			End Set
		End Property

		Public Overrides Sub Initialize()
			'PopulateRequestor()
			'PopulateCostCenter()
		End Sub


#End Region

#Region "Event Handlers"
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As System.EventArgs)

      Dim doc As SaleBillIssueItem = Me.CurrentItem

      Dim dpar As IHasIBillablePerson = Me.CurrentParItem

      Dim docId As Integer
      Dim docType As Integer

      If doc Is Nothing AndAlso dpar Is Nothing Then
        Return
      ElseIf Not dpar Is Nothing Then
        If TypeOf dpar Is SaleBillIssue Then
          docId = CType(dpar, SaleBillIssue).Id
          docType = 125
        ElseIf TypeOf dpar Is BillIssue Then
          docId = CType(dpar, BillIssue).Id
          docType = 81
        End If
      Else
        docId = doc.Id
        docType = doc.EntityId
      End If

      If docType = 75 OrElse docType = 77 OrElse docType = 78 OrElse docType = 79 OrElse docType = 86 Then 'รับวางบิล Retention
        Dim mi As New Milestone(docId)
        docId = mi.PMAId
        docType = 76
      End If

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If

    End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
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
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim row As DataRow = Me.m_treeManager.Treetable.Rows(index)
      'If row.IsNull("receivesi_entityType") And row.IsNull("Code") Then
      '  Return
      'End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filterEntities(7) As ArrayList
      For i As Integer = 0 To 7
        If i <> 2 Then
          filterEntities(i) = New ArrayList
          filterEntities(i).Add(Me.m_entity.Customer)
        Else
          Dim eqr As New AssetReturn
          eqr.IsExternal = True
          eqr.ReturnPerson = Me.m_entity.Customer
          filterEntities(i) = New ArrayList
          filterEntities(i).Add(eqr)
        End If
      Next
      Dim filters(7)() As Filter
      Dim entities(7) As ISimpleEntity

      filters(0) = New Filter() {New Filter("IDList", GetItemIDList(83)), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id)}
      entities(0) = New GoodsSold

      filters(1) = New Filter() {New Filter("IDList", GetItemIDList(24)), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id)}
      entities(1) = New AROpeningBalance

      filters(2) = New Filter() {New Filter("IDList", GetItemIDList(56)), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id)}
      entities(2) = New AssetReturn

      filters(3) = New Filter() {New Filter("IDList", GetItemIDList(124)), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id)}
      entities(3) = New AssetSold

      filters(4) = New Filter() {New Filter("ExcludeIdList", GetSBIExcludeList), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id), _
      New Filter("Id", Me.m_entity.Id)}
      entities(4) = New SaleBillIssueItem

      filters(5) = New Filter() {New Filter("ExcludeIdList", GetSBIExcludeList), _
      New Filter("remainMustValid", True), _
      New Filter("receives_id", Me.m_entity.Id), _
      New Filter("Id", Me.m_entity.Id)}
      entities(5) = New Milestone

      filters(6) = New Filter() {New Filter("IDList", GetItemIDList(48)), _
      New Filter("remainMustValid", True), _
      New Filter("nocancel", True)}
      entities(6) = New SaleCN

      Dim cust As Object = DBNull.Value
      If Not Me.m_entity.Customer Is Nothing Then
        cust = Me.m_entity.Customer.Id
      End If
      filters(7) = New Filter() {New Filter("IDList", GetItemIDList(366)), _
      New Filter("receives_id", Me.m_entity.Id),
      New Filter("cust_id", cust)}
      entities(7) = New AssetWriteOffSelectionForReceiveSelection

      myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
    End Sub
    Private Function GetItemIDList(ByVal type As Integer) As String
      Dim ret As String = ""
      For Each item As SaleBillIssueItem In Me.m_entity.ItemCollection
        If item.Originated AndAlso item.EntityId = type Then
          ret &= item.Id.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, ret.Length - 1)
      End If
      Return ret
    End Function
    Private Function GetSBIExcludeList() As String
      Dim ret As String = ""
      For Each item As SaleBillIssueItem In Me.m_entity.ItemCollection
        If item.ParentId <> 0 Then
          ret &= "|" & item.ParentId.ToString & ":" & item.Linenumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If items.Count = 0 Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim insertIndex As Integer
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim newItem As SaleBillIssueItem
        If TypeOf items(i) Is StockBasketItem Then
          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          Select Case item.FullClassName
            Case "Longkong.Pojjaman.BusinessLogic.SaleBillIssueItem"
              'เลือกมาจากใบวางบิลขาย
              newItem = CType(item.Tag, SaleBillIssueItem)
            Case "Longkong.Pojjaman.BusinessLogic.Milestone"
              'เลือกมาจากใบวางบิลงวด
              newItem = CType(item.Tag, SaleBillIssueItem)
              Dim remain As Decimal = newItem.GetRemainingAmountReceiveSelection(Me.m_entity.Id)
              remain = Math.Min(newItem.BilledAmount, remain)
              Dim remain2 As Decimal = Me.m_entity.ItemCollection.GetRemainFromOtherDocs(newItem)
              remain = Math.Min(remain, remain2)
              If newItem.UnreceivedAmount <> remain Then
                newItem.UnreceivedAmount = remain
              End If
              'newItem.UnreceivedAmount = Math.Min(newItem.UnreceivedAmount, newItem.BilledAmount)
          End Select
        Else
          Dim item As BasketItem = CType(items(i), BasketItem)
          If TypeOf item.Tag Is DataRow Then
            newItem = New SaleBillIssueItem(CType(item.Tag, DataRow), "", Me.m_entity)
          Else
            Select Case item.FullClassName.ToLower
              Case "longkong.pojjaman.businesslogic.goodssold"
                newItem = New SaleBillIssueItem(New GoodsSold(item.Id), Me.m_entity)
              Case "longkong.pojjaman.businesslogic.salecn"
                newItem = New SaleBillIssueItem(New SaleCN(item.Id), Me.m_entity)
            End Select
          End If
        End If
        If Not newItem Is Nothing Then
          If Not Me.m_entity.ValidateReferenceDocDate(newItem) Then
            msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.Message.DocDateLessThanRefDocDae}", New String() {newItem.Date.ToShortDateString, Me.m_entity.DocDate.ToShortDateString})
            Return
          End If
          newItem.Amount = Math.Min(newItem.UnreceivedAmount, newItem.BilledAmount)
          newItem.DeductedTaxBase = Nothing
          If newItem.EntityId = 366 OrElse newItem.EntityId = 83 Then
            newItem.ARretention = 0
          Else
            newItem.ARretention = newItem.getARretention()
          End If
          If i = items.Count - 1 Then
            'ตัวแรก -- update old item                       
            If Me.m_entity.ItemCollection.Count = 0 Then
              Me.m_entity.ItemCollection.Add(newItem)
            Else
              Dim theDoc As SaleBillIssueItem = Me.CurrentItem
              If theDoc Is Nothing Then
                If index > Me.m_entity.ItemCollection.Count - 1 Then
                  Me.m_entity.ItemCollection.Add(newItem)
                  theDoc = newItem
                  insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
                Else
                  Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                  theDoc = Me.m_entity.ItemCollection(insertIndex)
                End If
              End If
              theDoc.Id = newItem.Id
              theDoc.Code = newItem.Code
              theDoc.AfterTax = newItem.AfterTax
              theDoc.Amount = newItem.Amount 'Math.Min(newItem.UnreceivedAmount, newItem.BilledAmount) 'newItem.Amount ยอด 0
              theDoc.UnreceivedAmount = newItem.UnreceivedAmount
              theDoc.SetType(newItem.EntityId)
              theDoc.CreditPeriod = newItem.CreditPeriod
              theDoc.Date = newItem.Date
              theDoc.DeductedTaxBase = Nothing
            End If
          Else
            If Not Me.m_entity.ValidateReferenceDocDate(newItem) Then
              msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.Message.DocDateLessThanRefDocDae}", New String() {newItem.Date.ToShortDateString, Me.m_entity.DocDate.ToShortDateString})
              Return
            End If
            Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
          End If
        End If
      Next
      RefreshDocs()
      UpdateVat(True)
      tgItem.CurrentRowIndex = index
      UpdateAmount()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count Then
        Return
      End If
      Me.m_entity.ItemCollection.Insert(index, New SaleBillIssueItem)
      RefreshDocs()
      UpdateVat(True)
      tgItem.CurrentRowIndex = index
      Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
  , Me.m_treeManager.Treetable.Columns("receivesi_amt") _
  , Me.CurrentItem.Amount)
      Me.ValidateRow(re)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim doc As SaleBillIssueItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      If doc.Originated Then
        UpdateVat(True)
      End If
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        If Not row.IsNull("receivesi_entityType") Then
          row("receivesi_linenumber") = i + 1
          i += 1
        End If
      Next
    End Sub
    Private Sub chkShowDetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowDetail.CheckedChanged
      Me.m_entity.ItemCollection.ShowDetail = chkShowDetail.Checked
      Me.RefreshDocs()
      UpdateVat(False)
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
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '    If Not successful Then
    '        Return
    '    End If
    '    Me.Entity = New PR(Me.Entity.Id)
    '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
    '    listPanel.SelectedEntity = Me.Entity
    'End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New ReceiveSelection).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New ContactCustomer, AddressOf SetCustomer)
    End Sub
    Private Sub SetCustomer(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.ChangeProperty(txtCustomerCode, Nothing)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Customer).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcustomercode", "txtcustomername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Customer).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
        Dim entity As New Customer(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcustomercode", "txtcustomername"
              Me.SetCustomer(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '  Return
      'End If
      'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.BlankParentText}")
      'Dim parRow As TreeRow = SaleBillIssueItemCollection.FindRow(Me.m_treeManager.Treetable, 0, noParentText, 0)
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim maxVisibleCount As Integer
      'Dim tgRowHeight As Integer = 17
      'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      'Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
      '  'เพิ่มแถวจนเต็ม
      '  parRow.Childs.Add()
      'Loop
      'parRow.Childs.Add() 'add เพิ่มอันนึงเผื่อไว้แก้ปัญหา
      ''If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      ''    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      ''        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      ''        parRow.Childs.Add()
      ''    End If
      ''End If
      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      Dim rowCount As Integer = 0
      For Each child As TreeRow In Me.m_treeManager.Treetable.Childs
        rowCount += child.Childs.Count
      Next
      If Me.m_entity.ItemCollection.Count = rowCount Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace