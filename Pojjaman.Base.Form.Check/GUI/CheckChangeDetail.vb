Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CheckChangeDetail
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblTotalCancel As System.Windows.Forms.Label
    Friend WithEvents lblOtherRevenue As System.Windows.Forms.Label
    Friend WithEvents txtTotalCancel As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherRevenue As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalReplace As System.Windows.Forms.Label
    Friend WithEvents txtOtherExpense As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalReplace As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherExpense As System.Windows.Forms.Label
    Friend WithEvents lblCash As System.Windows.Forms.Label
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtIssuedate As System.Windows.Forms.TextBox
    Friend WithEvents lblNewItem As System.Windows.Forms.Label
    Friend WithEvents lblOldItem As System.Windows.Forms.Label
    Friend WithEvents btnCustFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents btnCustEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustCode As System.Windows.Forms.TextBox
    Friend WithEvents lblIssuedate As System.Windows.Forms.Label
    Friend WithEvents tgChange As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnBankreplace As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDeletereplace As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrency5 As System.Windows.Forms.Label
    Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
    Friend WithEvents lblCurrency4 As System.Windows.Forms.Label
    Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
    Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckChangeDetail))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtIssuedate = New System.Windows.Forms.TextBox
      Me.ibtnBankreplace = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDeletereplace = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCurrency5 = New System.Windows.Forms.Label
      Me.lblTotalReplace = New System.Windows.Forms.Label
      Me.lblCurrency3 = New System.Windows.Forms.Label
      Me.txtOtherExpense = New System.Windows.Forms.TextBox
      Me.txtTotalReplace = New System.Windows.Forms.TextBox
      Me.lblOtherExpense = New System.Windows.Forms.Label
      Me.lblCash = New System.Windows.Forms.Label
      Me.txtCash = New System.Windows.Forms.TextBox
      Me.lblCurrency4 = New System.Windows.Forms.Label
      Me.tgChange = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblNewItem = New System.Windows.Forms.Label
      Me.lblTotalCancel = New System.Windows.Forms.Label
      Me.lblCurrency2 = New System.Windows.Forms.Label
      Me.lblOtherRevenue = New System.Windows.Forms.Label
      Me.txtTotalCancel = New System.Windows.Forms.TextBox
      Me.lblCurrency1 = New System.Windows.Forms.Label
      Me.txtOtherRevenue = New System.Windows.Forms.TextBox
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblOldItem = New System.Windows.Forms.Label
      Me.lblStatus = New System.Windows.Forms.Label
      Me.btnCustFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCustName = New System.Windows.Forms.TextBox
      Me.lblCust = New System.Windows.Forms.Label
      Me.btnCustEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCustCode = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker
      Me.lblIssuedate = New System.Windows.Forms.Label
      Me.lblNote = New System.Windows.Forms.Label
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbMaster.SuspendLayout()
      CType(Me.tgChange, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.chkAutorun)
      Me.grbMaster.Controls.Add(Me.txtIssuedate)
      Me.grbMaster.Controls.Add(Me.ibtnBankreplace)
      Me.grbMaster.Controls.Add(Me.ibtnDeletereplace)
      Me.grbMaster.Controls.Add(Me.ibtnBlank)
      Me.grbMaster.Controls.Add(Me.ibtnDelRow)
      Me.grbMaster.Controls.Add(Me.lblCurrency5)
      Me.grbMaster.Controls.Add(Me.lblTotalReplace)
      Me.grbMaster.Controls.Add(Me.lblCurrency3)
      Me.grbMaster.Controls.Add(Me.txtOtherExpense)
      Me.grbMaster.Controls.Add(Me.txtTotalReplace)
      Me.grbMaster.Controls.Add(Me.lblOtherExpense)
      Me.grbMaster.Controls.Add(Me.lblCash)
      Me.grbMaster.Controls.Add(Me.txtCash)
      Me.grbMaster.Controls.Add(Me.lblCurrency4)
      Me.grbMaster.Controls.Add(Me.tgChange)
      Me.grbMaster.Controls.Add(Me.lblNewItem)
      Me.grbMaster.Controls.Add(Me.lblTotalCancel)
      Me.grbMaster.Controls.Add(Me.lblCurrency2)
      Me.grbMaster.Controls.Add(Me.lblOtherRevenue)
      Me.grbMaster.Controls.Add(Me.txtTotalCancel)
      Me.grbMaster.Controls.Add(Me.lblCurrency1)
      Me.grbMaster.Controls.Add(Me.txtOtherRevenue)
      Me.grbMaster.Controls.Add(Me.tgItem)
      Me.grbMaster.Controls.Add(Me.lblOldItem)
      Me.grbMaster.Controls.Add(Me.lblStatus)
      Me.grbMaster.Controls.Add(Me.btnCustFind)
      Me.grbMaster.Controls.Add(Me.txtCustName)
      Me.grbMaster.Controls.Add(Me.lblCust)
      Me.grbMaster.Controls.Add(Me.btnCustEdit)
      Me.grbMaster.Controls.Add(Me.txtCustCode)
      Me.grbMaster.Controls.Add(Me.txtCode)
      Me.grbMaster.Controls.Add(Me.lblCode)
      Me.grbMaster.Controls.Add(Me.dtpIssueDate)
      Me.grbMaster.Controls.Add(Me.lblIssuedate)
      Me.grbMaster.Controls.Add(Me.lblNote)
      Me.grbMaster.Controls.Add(Me.txtNote)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.ForeColor = System.Drawing.Color.Blue
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(704, 480)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เปลี่ยนเช็ครับ : "
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(288, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 3
      Me.chkAutorun.TabStop = False
      '
      'txtIssuedate
      '
      Me.Validator.SetDataType(Me.txtIssuedate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtIssuedate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtIssuedate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
      Me.txtIssuedate.Location = New System.Drawing.Point(448, 16)
      Me.txtIssuedate.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtIssuedate, "")
      Me.Validator.SetMinValue(Me.txtIssuedate, "")
      Me.txtIssuedate.Name = "txtIssuedate"
      Me.Validator.SetRegularExpression(Me.txtIssuedate, "")
      Me.Validator.SetRequired(Me.txtIssuedate, True)
      Me.txtIssuedate.Size = New System.Drawing.Size(123, 21)
      Me.txtIssuedate.TabIndex = 5
      Me.txtIssuedate.Text = ""
      '
      'ibtnBankreplace
      '
      Me.ibtnBankreplace.Image = CType(resources.GetObject("ibtnBankreplace.Image"), System.Drawing.Image)
      Me.ibtnBankreplace.Location = New System.Drawing.Point(248, 264)
      Me.ibtnBankreplace.Name = "ibtnBankreplace"
      Me.ibtnBankreplace.Size = New System.Drawing.Size(32, 32)
      Me.ibtnBankreplace.TabIndex = 25
      Me.ibtnBankreplace.TabStop = False
      Me.ibtnBankreplace.ThemedImage = CType(resources.GetObject("ibtnBankreplace.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDeletereplace
      '
      Me.ibtnDeletereplace.Image = CType(resources.GetObject("ibtnDeletereplace.Image"), System.Drawing.Image)
      Me.ibtnDeletereplace.Location = New System.Drawing.Point(280, 264)
      Me.ibtnDeletereplace.Name = "ibtnDeletereplace"
      Me.ibtnDeletereplace.Size = New System.Drawing.Size(32, 32)
      Me.ibtnDeletereplace.TabIndex = 26
      Me.ibtnDeletereplace.TabStop = False
      Me.ibtnDeletereplace.ThemedImage = CType(resources.GetObject("ibtnDeletereplace.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(248, 88)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
      Me.ibtnBlank.TabIndex = 15
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(280, 88)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
      Me.ibtnDelRow.TabIndex = 16
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCurrency5
      '
      Me.lblCurrency5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency5.AutoSize = True
      Me.lblCurrency5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency5.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency5.Location = New System.Drawing.Point(656, 432)
      Me.lblCurrency5.Name = "lblCurrency5"
      Me.lblCurrency5.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency5.TabIndex = 36
      Me.lblCurrency5.Text = "บาท"
      Me.lblCurrency5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotalReplace
      '
      Me.lblTotalReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalReplace.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalReplace.ForeColor = System.Drawing.Color.Black
      Me.lblTotalReplace.Location = New System.Drawing.Point(296, 432)
      Me.lblTotalReplace.Name = "lblTotalReplace"
      Me.lblTotalReplace.Size = New System.Drawing.Size(232, 18)
      Me.lblTotalReplace.TabIndex = 34
      Me.lblTotalReplace.Text = "Total Check Change Amount:"
      Me.lblTotalReplace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency3
      '
      Me.lblCurrency3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency3.AutoSize = True
      Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency3.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency3.Location = New System.Drawing.Point(368, 408)
      Me.lblCurrency3.Name = "lblCurrency3"
      Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency3.TabIndex = 30
      Me.lblCurrency3.Text = "บาท"
      Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtOtherExpense
      '
      Me.txtOtherExpense.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtOtherExpense, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtOtherExpense, -15)
      Me.Validator.SetInvalidBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.txtOtherExpense.Location = New System.Drawing.Point(536, 408)
      Me.txtOtherExpense.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtOtherExpense, "")
      Me.Validator.SetMinValue(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Name = "txtOtherExpense"
      Me.Validator.SetRegularExpression(Me.txtOtherExpense, "")
      Me.Validator.SetRequired(Me.txtOtherExpense, False)
      Me.txtOtherExpense.Size = New System.Drawing.Size(112, 21)
      Me.txtOtherExpense.TabIndex = 32
      Me.txtOtherExpense.Text = ""
      Me.txtOtherExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalReplace
      '
      Me.txtTotalReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtTotalReplace, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTotalReplace, "")
      Me.txtTotalReplace.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTotalReplace, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTotalReplace, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTotalReplace, System.Drawing.Color.Empty)
      Me.txtTotalReplace.Location = New System.Drawing.Point(536, 432)
      Me.txtTotalReplace.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtTotalReplace, "")
      Me.Validator.SetMinValue(Me.txtTotalReplace, "")
      Me.txtTotalReplace.Name = "txtTotalReplace"
      Me.txtTotalReplace.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalReplace, "")
      Me.Validator.SetRequired(Me.txtTotalReplace, False)
      Me.txtTotalReplace.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalReplace.TabIndex = 35
      Me.txtTotalReplace.TabStop = False
      Me.txtTotalReplace.Text = ""
      Me.txtTotalReplace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOtherExpense
      '
      Me.lblOtherExpense.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherExpense.ForeColor = System.Drawing.Color.Black
      Me.lblOtherExpense.Location = New System.Drawing.Point(400, 408)
      Me.lblOtherExpense.Name = "lblOtherExpense"
      Me.lblOtherExpense.Size = New System.Drawing.Size(128, 18)
      Me.lblOtherExpense.TabIndex = 31
      Me.lblOtherExpense.Text = "ค่าใช้จ่ายอื่น:"
      Me.lblOtherExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCash
      '
      Me.lblCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCash.ForeColor = System.Drawing.Color.Black
      Me.lblCash.Location = New System.Drawing.Point(120, 408)
      Me.lblCash.Name = "lblCash"
      Me.lblCash.Size = New System.Drawing.Size(120, 18)
      Me.lblCash.TabIndex = 28
      Me.lblCash.Text = "เงินสด:"
      Me.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCash
      '
      Me.txtCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtCash, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtCash, "")
      Me.txtCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCash, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCash, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCash, System.Drawing.Color.Empty)
      Me.txtCash.Location = New System.Drawing.Point(248, 408)
      Me.txtCash.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtCash, "")
      Me.Validator.SetMinValue(Me.txtCash, "")
      Me.txtCash.Name = "txtCash"
      Me.Validator.SetRegularExpression(Me.txtCash, "")
      Me.Validator.SetRequired(Me.txtCash, False)
      Me.txtCash.Size = New System.Drawing.Size(112, 21)
      Me.txtCash.TabIndex = 29
      Me.txtCash.Text = ""
      Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrency4
      '
      Me.lblCurrency4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency4.AutoSize = True
      Me.lblCurrency4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency4.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency4.Location = New System.Drawing.Point(656, 408)
      Me.lblCurrency4.Name = "lblCurrency4"
      Me.lblCurrency4.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency4.TabIndex = 33
      Me.lblCurrency4.Text = "บาท"
      Me.lblCurrency4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgChange
      '
      Me.tgChange.AllowNew = True
      Me.tgChange.AllowSorting = False
      Me.tgChange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgChange.AutoColumnResize = True
      Me.tgChange.CaptionVisible = False
      Me.tgChange.Cellchanged = False
      Me.tgChange.DataMember = ""
      Me.tgChange.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgChange.Location = New System.Drawing.Point(8, 296)
      Me.tgChange.Name = "tgChange"
      Me.tgChange.Size = New System.Drawing.Size(688, 112)
      Me.tgChange.SortingArrowColor = System.Drawing.Color.Red
      Me.tgChange.TabIndex = 27
      Me.tgChange.TreeManager = Nothing
      '
      'lblNewItem
      '
      Me.lblNewItem.AutoSize = True
      Me.lblNewItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNewItem.ForeColor = System.Drawing.Color.Black
      Me.lblNewItem.Location = New System.Drawing.Point(8, 272)
      Me.lblNewItem.Name = "lblNewItem"
      Me.lblNewItem.Size = New System.Drawing.Size(153, 19)
      Me.lblNewItem.TabIndex = 24
      Me.lblNewItem.Text = "รายการเช็คใหม่ที่ใช้แทน"
      Me.lblNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotalCancel
      '
      Me.lblTotalCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalCancel.ForeColor = System.Drawing.Color.Black
      Me.lblTotalCancel.Location = New System.Drawing.Point(352, 256)
      Me.lblTotalCancel.Name = "lblTotalCancel"
      Me.lblTotalCancel.Size = New System.Drawing.Size(176, 18)
      Me.lblTotalCancel.TabIndex = 21
      Me.lblTotalCancel.Text = "Total Check Change Amount:"
      Me.lblTotalCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency2
      '
      Me.lblCurrency2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency2.AutoSize = True
      Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency2.Location = New System.Drawing.Point(656, 256)
      Me.lblCurrency2.Name = "lblCurrency2"
      Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency2.TabIndex = 23
      Me.lblCurrency2.Text = "บาท"
      Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblOtherRevenue
      '
      Me.lblOtherRevenue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOtherRevenue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherRevenue.ForeColor = System.Drawing.Color.Black
      Me.lblOtherRevenue.Location = New System.Drawing.Point(360, 232)
      Me.lblOtherRevenue.Name = "lblOtherRevenue"
      Me.lblOtherRevenue.Size = New System.Drawing.Size(168, 18)
      Me.lblOtherRevenue.TabIndex = 18
      Me.lblOtherRevenue.Text = "รายได้อื่น:"
      Me.lblOtherRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTotalCancel
      '
      Me.txtTotalCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtTotalCancel, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTotalCancel, "")
      Me.txtTotalCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTotalCancel, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTotalCancel, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTotalCancel, System.Drawing.Color.Empty)
      Me.txtTotalCancel.Location = New System.Drawing.Point(536, 256)
      Me.txtTotalCancel.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtTotalCancel, "")
      Me.Validator.SetMinValue(Me.txtTotalCancel, "")
      Me.txtTotalCancel.Name = "txtTotalCancel"
      Me.txtTotalCancel.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalCancel, "")
      Me.Validator.SetRequired(Me.txtTotalCancel, False)
      Me.txtTotalCancel.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalCancel.TabIndex = 22
      Me.txtTotalCancel.TabStop = False
      Me.txtTotalCancel.Text = ""
      Me.txtTotalCancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrency1
      '
      Me.lblCurrency1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency1.AutoSize = True
      Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency1.Location = New System.Drawing.Point(656, 232)
      Me.lblCurrency1.Name = "lblCurrency1"
      Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrency1.TabIndex = 20
      Me.lblCurrency1.Text = "บาท"
      Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtOtherRevenue
      '
      Me.txtOtherRevenue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtOtherRevenue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtOtherRevenue, -15)
      Me.Validator.SetInvalidBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.txtOtherRevenue.Location = New System.Drawing.Point(536, 232)
      Me.txtOtherRevenue.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtOtherRevenue, "")
      Me.Validator.SetMinValue(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Name = "txtOtherRevenue"
      Me.Validator.SetRegularExpression(Me.txtOtherRevenue, "")
      Me.Validator.SetRequired(Me.txtOtherRevenue, False)
      Me.txtOtherRevenue.Size = New System.Drawing.Size(112, 21)
      Me.txtOtherRevenue.TabIndex = 19
      Me.txtOtherRevenue.Text = ""
      Me.txtOtherRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 120)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(688, 112)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 17
      Me.tgItem.TreeManager = Nothing
      '
      'lblOldItem
      '
      Me.lblOldItem.AutoSize = True
      Me.lblOldItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOldItem.ForeColor = System.Drawing.Color.Black
      Me.lblOldItem.Location = New System.Drawing.Point(8, 96)
      Me.lblOldItem.Name = "lblOldItem"
      Me.lblOldItem.Size = New System.Drawing.Size(218, 19)
      Me.lblOldItem.TabIndex = 14
      Me.lblOldItem.Text = "รายการเช็คยกเลิกที่ต้องการเปลี่ยน:"
      Me.lblOldItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(8, 456)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(21, 17)
      Me.lblStatus.TabIndex = 0
      Me.lblStatus.Text = "xxx"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCustFind
      '
      Me.btnCustFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustFind.Image = CType(resources.GetObject("btnCustFind.Image"), System.Drawing.Image)
      Me.btnCustFind.Location = New System.Drawing.Point(544, 40)
      Me.btnCustFind.Name = "btnCustFind"
      Me.btnCustFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCustFind.TabIndex = 10
      Me.btnCustFind.TabStop = False
      Me.btnCustFind.ThemedImage = CType(resources.GetObject("btnCustFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustName
      '
      Me.txtCustName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustName, "")
      Me.txtCustName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtCustName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustName, System.Drawing.Color.Empty)
      Me.txtCustName.Location = New System.Drawing.Point(288, 40)
      Me.txtCustName.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtCustName, "")
      Me.Validator.SetMinValue(Me.txtCustName, "")
      Me.txtCustName.Name = "txtCustName"
      Me.txtCustName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustName, "")
      Me.Validator.SetRequired(Me.txtCustName, False)
      Me.txtCustName.Size = New System.Drawing.Size(256, 21)
      Me.txtCustName.TabIndex = 9
      Me.txtCustName.TabStop = False
      Me.txtCustName.Text = ""
      '
      'lblCust
      '
      Me.lblCust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCust.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCust.Location = New System.Drawing.Point(8, 40)
      Me.lblCust.Name = "lblCust"
      Me.lblCust.Size = New System.Drawing.Size(128, 18)
      Me.lblCust.TabIndex = 7
      Me.lblCust.Text = "ลูกค้า:"
      Me.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCustEdit
      '
      Me.btnCustEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustEdit.Image = CType(resources.GetObject("btnCustEdit.Image"), System.Drawing.Image)
      Me.btnCustEdit.Location = New System.Drawing.Point(568, 40)
      Me.btnCustEdit.Name = "btnCustEdit"
      Me.btnCustEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCustEdit.TabIndex = 11
      Me.btnCustEdit.TabStop = False
      Me.btnCustEdit.ThemedImage = CType(resources.GetObject("btnCustEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustCode
      '
      Me.txtCustCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustCode, System.Drawing.Color.Empty)
      Me.txtCustCode.Location = New System.Drawing.Point(144, 40)
      Me.txtCustCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCustCode, "")
      Me.Validator.SetMinValue(Me.txtCustCode, "")
      Me.txtCustCode.Name = "txtCustCode"
      Me.Validator.SetRegularExpression(Me.txtCustCode, "")
      Me.Validator.SetRequired(Me.txtCustCode, True)
      Me.txtCustCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCustCode.TabIndex = 8
      Me.txtCustCode.Text = ""
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(144, 16)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCode.TabIndex = 2
      Me.txtCode.Text = ""
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 18)
      Me.lblCode.TabIndex = 1
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpIssueDate
      '
      Me.dtpIssueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpIssueDate.Location = New System.Drawing.Point(448, 16)
      Me.dtpIssueDate.Name = "dtpIssueDate"
      Me.dtpIssueDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpIssueDate.TabIndex = 6
      Me.dtpIssueDate.TabStop = False
      '
      'lblIssuedate
      '
      Me.lblIssuedate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIssuedate.ForeColor = System.Drawing.Color.Black
      Me.lblIssuedate.Location = New System.Drawing.Point(312, 16)
      Me.lblIssuedate.Name = "lblIssuedate"
      Me.lblIssuedate.Size = New System.Drawing.Size(128, 18)
      Me.lblIssuedate.TabIndex = 4
      Me.lblIssuedate.Text = "Document Date:"
      Me.lblIssuedate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 64)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(128, 18)
      Me.lblNote.TabIndex = 12
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(144, 64)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(448, 21)
      Me.txtNote.TabIndex = 13
      Me.txtNote.Text = ""
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'CheckChangeDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "CheckChangeDetail"
      Me.Size = New System.Drawing.Size(720, 496)
      Me.grbMaster.ResumeLayout(False)
      CType(Me.tgChange, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblNote}")
      Me.Validator.SetDisplayName(Me.txtNote, StringHelper.GetRidOfAtEnd(Me.lblNote.Text, ":"))

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblCust.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblCustCode}")
      Me.Validator.SetDisplayName(Me.txtCustCode, StringHelper.GetRidOfAtEnd(Me.lblCust.Text, ":"))

      Me.lblTotalCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblTotalCancel}")
      Me.Validator.SetDisplayName(Me.txtTotalCancel, StringHelper.GetRidOfAtEnd(Me.lblTotalCancel.Text, ":"))

      Me.lblOtherRevenue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblOtherRevenue}")
      Me.Validator.SetDisplayName(Me.txtOtherRevenue, StringHelper.GetRidOfAtEnd(Me.lblOtherRevenue.Text, ":"))

      Me.lblTotalReplace.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblTotalReplace}")
      Me.Validator.SetDisplayName(Me.txtTotalReplace, StringHelper.GetRidOfAtEnd(Me.lblTotalReplace.Text, ":"))

      Me.lblOtherExpense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckChangeDetail.lblOtherExpense}")
      Me.Validator.SetDisplayName(Me.txtOtherExpense, StringHelper.GetRidOfAtEnd(Me.lblOtherExpense.Text, ":"))

      Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCurrency4.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCurrency5.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub

#End Region

#Region "Member"
    Private m_entity As CheckChange
    Private m_treeManager As TreeManager
    Private m_replaceTreeManager As TreeManager
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.SetLabelText()

      ' Item ...
      Dim dt As TreeTable = CheckChange.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      ' Change ...
      dt = CheckChange.GetSchemaReplaceTable
      dst = Me.CreateReplaceTableStyle
      m_replaceTreeManager = New TreeManager(dt, tgChange)
      m_replaceTreeManager.SetTableStyle(dst)
      m_replaceTreeManager.AllowSorting = False
      m_replaceTreeManager.AllowDelete = False
      tgChange.AllowNew = False

      EventWiring()
    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As CheckChangeItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Dim doc As New CheckChangeItem
        doc.CopyFromDataRow(row)
        If doc Is Nothing Then
          Return Nothing
        End If
        Return doc
      End Get
    End Property
#End Region

#Region " Style "
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CheckUpdate"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' line number ...
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"
      ' document code ...
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "check_code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 70
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "check_code"
      ' Check Find button ...
      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "btnCheck"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf CheckButtonClick
      ' check docudate ...
      Dim csReceiveDate As New TreeTextColumn
      csReceiveDate.MappingName = "check_receivedate"
      csReceiveDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
      csReceiveDate.NullText = ""
      csReceiveDate.Width = 120
      csReceiveDate.Alignment = HorizontalAlignment.Center
      csReceiveDate.DataAlignment = HorizontalAlignment.Center
      csReceiveDate.ReadOnly = True
      csReceiveDate.Format = "dd/MM/yyyy"
      csReceiveDate.TextBox.Name = "check_receivedate"
      ' CqCode ...
      Dim csCqcode As New TreeTextColumn
      csCqcode.MappingName = "check_cqcode"
      csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
      csCqcode.NullText = ""
      csCqcode.Width = 100
      csCqcode.Alignment = HorizontalAlignment.Center
      csCqcode.DataAlignment = HorizontalAlignment.Left
      csCqcode.ReadOnly = True
      csCqcode.TextBox.Name = "check_cqcode"
      ' recievepient ...
      Dim csRecipient As New TreeTextColumn
      csRecipient.MappingName = "receivepersonName"
      csRecipient.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.recipientHeaderText}")
      csRecipient.NullText = ""
      csRecipient.Alignment = HorizontalAlignment.Center
      csRecipient.DataAlignment = HorizontalAlignment.Left
      csRecipient.Width = 150
      csRecipient.ReadOnly = True
      csRecipient.TextBox.Name = "receivepersonName"

      ' Bank name ...
      Dim csBankName As New TreeTextColumn
      csBankName.MappingName = "bankName"
      csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
      csBankName.NullText = ""
      csBankName.Alignment = HorizontalAlignment.Center
      csBankName.DataAlignment = HorizontalAlignment.Left
      csBankName.Width = 150
      csBankName.ReadOnly = True
      csBankName.TextBox.Name = "bankName"
      ' Check amount ...
      Dim csCheckAmnt As New TreeTextColumn
      csCheckAmnt.MappingName = "check_amt"
      csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CheckAmountHeaderText}")
      csCheckAmnt.NullText = ""
      csCheckAmnt.Width = 80
      csCheckAmnt.Alignment = HorizontalAlignment.Center
      csCheckAmnt.DataAlignment = HorizontalAlignment.Right
      csCheckAmnt.ReadOnly = True
      csCheckAmnt.Format = "#,##0.00"
      csCheckAmnt.TextBox.Name = "check_amt"

      ' Add column style ...
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csCqcode)
      dst.GridColumnStyles.Add(csReceiveDate)
      dst.GridColumnStyles.Add(csRecipient)
      dst.GridColumnStyles.Add(csBankName)
      dst.GridColumnStyles.Add(csCheckAmnt)

      Return dst
    End Function
    ' รายการเปลี่ยนแทน
    Public Function CreateReplaceTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CheckUpdate"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' line number ...
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"
      ' document code ...
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "check_code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 75
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = True
      csCode.TextBox.Name = "check_code"

      ' CqCode ...
      Dim csCqcode As New TreeTextColumn
      csCqcode.MappingName = "check_cqcode"
      csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
      csCqcode.NullText = ""
      csCqcode.Width = 75
      csCqcode.Alignment = HorizontalAlignment.Center
      csCqcode.DataAlignment = HorizontalAlignment.Left
      csCqcode.ReadOnly = False
      csCqcode.TextBox.Name = "check_cqcode"

      ' check receive date ...
      Dim csReceiveDate As New DataGridTimePickerColumn
      csReceiveDate.MappingName = "check_receivedate"
      csReceiveDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.ReceiveDateHeaderText}")
      csReceiveDate.NullText = ""
      csReceiveDate.Width = 100

      ' check due date ...
      Dim csDueDate As New DataGridTimePickerColumn
      csDueDate.MappingName = "check_duedate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.Width = 100

      ' recieve personname ...
      Dim csReceivePerson As New TreeTextColumn
      csReceivePerson.MappingName = "receivepersonName"
      csReceivePerson.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.ReceivePersonHeaderText}")
      csReceivePerson.NullText = ""
      csReceivePerson.Alignment = HorizontalAlignment.Center
      csReceivePerson.DataAlignment = HorizontalAlignment.Left
      csReceivePerson.Width = 100
      csReceivePerson.ReadOnly = False
      csReceivePerson.TextBox.Name = "receivepersonName"
      ' Check Find button ...
      Dim csBtnReceivePerson As New DataGridButtonColumn
      csBtnReceivePerson.MappingName = "btnReceiveperson"
      csBtnReceivePerson.HeaderText = ""
      csBtnReceivePerson.NullText = ""
      'AddHandler csBtnReceivePerson.Click, AddressOf ReplaceCheckClicked

      ' Bank name ...
      Dim csBankName As New TreeTextColumn
      csBankName.MappingName = "bankName"
      csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
      csBankName.NullText = ""
      csBankName.Alignment = HorizontalAlignment.Center
      csBankName.DataAlignment = HorizontalAlignment.Left
      csBankName.Width = 100
      csBankName.ReadOnly = False
      csBankName.TextBox.Name = "bankName"

      ' Check Find button ...
      Dim csBtnBank As New DataGridButtonColumn
      csBtnBank.MappingName = "btnBank"
      csBtnBank.HeaderText = ""
      csBtnBank.NullText = ""
      AddHandler csBtnBank.Click, AddressOf ReplaceButtonClick

      ' Check amount ...
      Dim csCheckAmnt As New TreeTextColumn
      csCheckAmnt.MappingName = "check_amt"
      csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.CheckAmountHeaderText}")
      csCheckAmnt.NullText = ""
      csCheckAmnt.Width = 70
      csCheckAmnt.Alignment = HorizontalAlignment.Center
      csCheckAmnt.DataAlignment = HorizontalAlignment.Right
      csCheckAmnt.ReadOnly = False
      csCheckAmnt.Format = "#,##0.00"
      csCheckAmnt.TextBox.Name = "check_amt"

      ' Note ...
      Dim csNote As New TreeTextColumn
      csNote.MappingName = "check_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Right
      csNote.ReadOnly = False
      csNote.TextBox.Name = "check_note"

      ' Add column style ...
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csCqcode)
      dst.GridColumnStyles.Add(csReceiveDate)
      dst.GridColumnStyles.Add(csDueDate)

      dst.GridColumnStyles.Add(csReceivePerson)
      dst.GridColumnStyles.Add(csBtnReceivePerson)

      dst.GridColumnStyles.Add(csBankName)
      dst.GridColumnStyles.Add(csBtnBank)

      dst.GridColumnStyles.Add(csCheckAmnt)
      dst.GridColumnStyles.Add(csNote)
      Return dst
    End Function

#End Region

#Region "IListDetail"
    Public Overrides Sub Initialize()

    End Sub

    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 Then
        For Each ctrl As Control In grbMaster.Controls
          ctrl.Enabled = False
        Next
      Else
        For Each ctrl As Control In grbMaster.Controls
          ctrl.Enabled = True
        Next
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each grb As Control In Me.Controls
        If TypeOf grb Is FixedGroupBox Then
          For Each crlt As Control In grb.Controls
            If TypeOf crlt Is TextBox Then
              crlt.Text = ""
            End If
          Next
        End If
      Next

      Me.dtpIssueDate.Value = Now
      txtIssuedate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

    End Sub

    Protected Overrides Sub EventWiring()

      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtIssuedate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCustCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtOtherRevenue.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtOtherRevenue.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler txtOtherExpense.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtOtherExpense.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler txtCash.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCash.Validated, AddressOf Me.NumberTextBoxChange
      AddHandler tgItem.DoubleClick, AddressOf CellDblClick
      'AddHandler tgChange.DoubleClick, AddressOf CellDblClick
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      ' autogencode
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtIssuedate.Text = MinDateToNull(Me.m_entity.IssueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpIssueDate.Value = MinDateToNow(Me.m_entity.IssueDate)

      txtOtherRevenue.Text = Configuration.FormatToString(Me.m_entity.OtherRevenue, DigitConfig.Price)
      txtTotalCancel.Text = Configuration.FormatToString(Me.m_entity.TotalCancel, DigitConfig.Price)

      txtCash.Text = Configuration.FormatToString(Me.m_entity.Cash, DigitConfig.Price)
      txtOtherExpense.Text = Configuration.FormatToString(Me.m_entity.OtherExpense, DigitConfig.Price)
      txtTotalReplace.Text = Configuration.FormatToString(Me.m_entity.TotalReplace, DigitConfig.Price)

      If Not Me.m_entity.Customer Is Nothing Then
        txtCustCode.Text = Me.m_entity.Customer.Code
        txtCustName.Text = Me.m_entity.Customer.Name
      End If

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      'Load Change**********************************************************
      Me.m_replaceTreeManager.Treetable = Me.m_entity.ItemReplaceTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_replaceTreeManager.Treetable
      '********************************************************************
      RefreshBlankGrid()

      SetStatus()
      CheckFormEnable()
      SetLabelText()

      ' กันพลาด
      SetSumTotalCancel()
      SetSumTotalReplace()

      m_isInitialized = True
    End Sub

    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      SetSumTotalCancel()
      SetSumTotalReplace()
    End Sub

    Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtotherrevenue"
          txtOtherRevenue.Text = Configuration.FormatToString(Me.m_entity.OtherRevenue, DigitConfig.Price)
        Case "txtotherexpense"
          txtOtherExpense.Text = Configuration.FormatToString(Me.m_entity.OtherExpense, DigitConfig.Price)
        Case "txtcash"
          txtCash.Text = Configuration.FormatToString(Me.m_entity.Cash, DigitConfig.Price)
      End Select
    End Sub

    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True

        Case "dtpissuedate"
          txtIssuedate.Text = MinDateToNull(dtpIssueDate.Value, "")
          Me.m_entity.IssueDate = dtpIssueDate.Value
          dirtyFlag = True

        Case "txtissuedate"
          Dim dt As Date = StringToDate(txtIssuedate, dtpIssueDate)
          Me.m_entity.IssueDate = dt
          dirtyFlag = True

        Case "txtcustcode"
          Dim oldcust As String = Me.m_entity.Customer.Code

          dirtyFlag = Customer.GetCustomer(txtCustCode, txtCustName, Me.m_entity.Customer)

          If oldcust <> Me.m_entity.Customer.Code Then
            Me.m_entity.ItemTable.Clear()
            Me.m_entity.ItemReplaceTable.Clear()
            RefreshBlankGrid()
          End If

        Case "txtotherrevenue"
          dirtyFlag = True
          If txtOtherRevenue.TextLength > 0 Then
            Me.m_entity.OtherRevenue = Configuration.Format(CDec(txtOtherRevenue.Text), DigitConfig.Price)
          Else
            Me.m_entity.OtherRevenue = Nothing
          End If
          SetSumTotalCancel()

        Case "txtotherexpense"
          dirtyFlag = True
          If txtOtherExpense.TextLength > 0 Then
            Me.m_entity.OtherExpense = Configuration.Format(CDec(txtOtherExpense.Text), DigitConfig.Price)
          Else
            Me.m_entity.OtherExpense = Nothing
          End If
          SetSumTotalReplace()

        Case "txtcash"
          dirtyFlag = True
          If txtCash.TextLength > 0 Then
            Me.m_entity.Cash = Configuration.Format(CDec(txtCash.Text), DigitConfig.Price)
          Else
            Me.m_entity.Cash = Nothing
          End If
          SetSumTotalReplace()


      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()
      SetStatus()

    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
      'If m_entity.Canceled Then
      '  lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '  " " & m_entity.CancelDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf m_entity.Edited Then
      '  lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '  " " & m_entity.LastEditDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.LastEditor.Name
      'ElseIf m_entity.Originated Then
      '  lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '  " " & m_entity.OriginDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.Originator.Name
      'Else
      '  lblStatus.Text = "ยังไม่ได้บันทึก"
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Me.m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          RemoveHandler Me.m_entity.CheckButtonClick, AddressOf CheckButtonClick

          RemoveHandler Me.m_entity.ReplaceButtonClick, AddressOf ReplaceButtonClick
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, CheckChange)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region "Event Handlers"
    Public Sub btnReceivePerson_Clicked(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetCheckItems)
    End Sub

    Public Sub btnBank_Clicked(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Bank, AddressOf SetCheckItems)
    End Sub

    Public Sub ReplaceButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case e.Column
        Case 6
          Dim newEmp As New Employee
          myEntityPanelService.OpenListDialog(newEmp, AddressOf SetReceivePerson)
        Case 8
          Dim newBank As New Bank
          myEntityPanelService.OpenListDialog(newBank, AddressOf SetBank)
      End Select

    End Sub

    Public Sub CheckButtonClick(ByVal e As ButtonColumnEventArgs)
      If Not Me.m_entity.Customer.Originated Then
        Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        myMessageService.ShowWarningFormatted("${res:Global.MustDefine}", lblCust.Text)
        txtCustCode.Focus()
        Return
      End If

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim obj As New IncomingCheck

      obj.Customer = Me.m_entity.Customer
      obj.DocStatus = New IncomingCheckDocStatus(0)  ' แสดง ยกเลิก เท่านั้น ...
      entities.Add(obj)

      Dim filters(0) As Filter
      filters(0) = New Filter("IDList", GenIDListFromDataTable())

      myEntityPanelService.OpenListDialog(New IncomingCheck, AddressOf SetCheckItems, filters, entities)
    End Sub
    Private Function GenIDListFromDataTable() As String
      Dim idlist As String = ""
      For Each row As TreeRow In Me.m_entity.ItemTable.Rows
        If Not IsDBNull(row("check_id")) Then
          idlist &= CStr(row("check_id")) & ","
        End If
      Next
      For Each row As TreeRow In Me.m_entity.ItemReplaceTable.Rows
        If Not IsDBNull(row("check_id")) Then
          idlist &= CStr(row("check_id")) & ","
        End If
      Next
      Return idlist
    End Function

    Private Sub SetEntityValue(ByVal check As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Code") = check.Code
      SetSumTotalReplace()

    End Sub

    Private Sub SetReceivePerson(ByVal emp As ISimpleEntity)
      Me.m_replaceTreeManager.SelectedRow("receivepersonName") = emp.Code
    End Sub
    Private Sub SetBank(ByVal bankitem As ISimpleEntity)
      Me.m_replaceTreeManager.SelectedRow("bankName") = bankitem.Code
    End Sub

    Private Sub SetCheckItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex

      For i As Integer = items.Count - 1 To 0 Step -1
        Dim newItem As New IncomingCheck(CType(items(i), BasketItem).Id)

        Dim cqtype As New CheckType(newItem.EntityId)

        Dim mtwItem As New CheckChangeItem

        mtwItem.Entity = newItem

        Me.m_entity.ItemTable.AcceptChanges()

        If i = items.Count - 1 Then
          If Me.m_entity.ItemTable.Childs.Count = 0 Then
            Me.m_entity.Add(mtwItem)
          Else
            mtwItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("linenumber"))
            mtwItem.CheckChange = Me.m_entity
            mtwItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
          End If
        Else
          Me.m_entity.Insert(index, mtwItem)
        End If
        Me.m_entity.ItemTable.AcceptChanges()
      Next
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      ' Summary ...
      SetSumTotalCancel()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub CellDblClick(ByVal sender As Object, ByVal e As System.EventArgs)

      Dim doc As CheckChangeItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If

      Dim docId As Integer
      Dim docType As Integer

      docId = doc.Entity.Id
      docType = 27 'doc.EntityType.Value

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If

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
        Return (New CheckChange).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Rows Manager Button"
    ' Add Item ...
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim checkItem As New CheckChangeItem

      'checkItem.Entity = CType(newItem, ISimpleEntity)

      Me.m_entity.Insert(index, checkItem)
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    ' Delete Item ...
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    ' Replace item
    ' Add Item ...
    Private Sub ibtnBankreplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBankreplace.Click
      Dim index As Integer = tgChange.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim ReplaceItem As New CheckReplaceItem

      'checkItem.Entity = CType(newItem, ISimpleEntity)

      Me.m_entity.Insert(index, ReplaceItem)
      Me.m_entity.ItemReplaceTable.AcceptChanges()
      tgChange.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    ' Delete Item ...
    Private Sub ibtnDeletereplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDeletereplace.Click
      Dim index As Integer = Me.tgChange.CurrentRowIndex
      Me.m_entity.RemoveReplace(index)
      Me.tgChange.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub

    Private Sub tgChange_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgChange.Resize
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
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop
      If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
        If Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1 Then
          'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          Me.m_entity.AddBlankRow(1)
        End If
      End If
      'Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    MessageBox.Show(Me.m_entity.ItemTable.Childs.Count.ToString & ":" & maxVisibleCount.ToString & ":" & Me.m_entity.MaxRowIndex.ToString)
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
      'Loop
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      '' ++++++++++++++++++++++++++++++++
      index = tgChange.CurrentRowIndex
      maxVisibleCount = CInt(Math.Floor((Me.tgChange.Height - tgRowHeight) / tgRowHeight))

      Do While Me.m_entity.ItemReplaceTable.Childs.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddReplaceBlankRow(1)
      Loop
      If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
        If Me.m_entity.ItemReplaceTable.Childs.Count < maxVisibleCount - 1 Then
          'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          Me.m_entity.AddReplaceBlankRow(1)
        End If
      End If
      'Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    MessageBox.Show(Me.m_entity.ItemTable.Childs.Count.ToString & ":" & maxVisibleCount.ToString & ":" & Me.m_entity.MaxRowIndex.ToString)
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
      'Loop
      Me.m_entity.ItemReplaceTable.AcceptChanges()
      tgChange.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      ' set summary 
      SetSumTotalCancel()
      SetSumTotalReplace()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetSumTotalCancel()
      Dim item As Integer = 0
      Dim totalcancel As Decimal = 0
      Dim sumamnt As Decimal = 0
      Dim OtherRevenue As Decimal = 0

      For Each row As TreeRow In Me.m_entity.ItemTable.Rows
        If Me.m_entity.ValidateRow(row) Then
          item += 1
          If Not row.IsNull("check_amt") Then
            sumamnt += CDec(row("check_amt"))
          End If
        End If
      Next

      If txtOtherRevenue.TextLength > 0 Then
        OtherRevenue = Configuration.Format(CDec(txtOtherRevenue.Text), DigitConfig.Price)
        Me.m_entity.OtherRevenue = Configuration.Format(OtherRevenue, DigitConfig.Price)
      Else
        OtherRevenue = 0
        Me.m_entity.OtherRevenue = Nothing
        txtOtherRevenue.Text = ""
      End If

      totalcancel = sumamnt + OtherRevenue

      Me.m_entity.TotalCancel = Configuration.Format(totalcancel, DigitConfig.Price)

      txtTotalCancel.Text = Configuration.FormatToString(Me.m_entity.TotalCancel, DigitConfig.Price)
    End Sub
    Private Sub SetSumTotalReplace()
      Dim item As Integer = 0
      Dim sumamnt As Decimal = 0
      Dim totalreplace As Decimal = 0
      Dim cash As Decimal = 0
      Dim otherexpense As Decimal = 0
      For Each row As TreeRow In Me.m_entity.ItemReplaceTable.Rows
        If Not row.IsNull("check_code") Then
          item += 1
          If Not row.IsNull("check_amt") Then
            sumamnt += CDec(row("check_amt"))
          End If
        End If
      Next
      If txtCash.TextLength > 0 Then
        cash = CDec(txtCash.Text)
        Me.m_entity.Cash = Configuration.Format(cash, DigitConfig.Price)
      Else
        cash = 0
        Me.m_entity.Cash = Nothing
        txtCash.Text = ""
      End If
      If txtOtherExpense.TextLength > 0 Then
        otherexpense = CDec(txtOtherExpense.Text)
        Me.m_entity.OtherExpense = Configuration.Format(otherexpense, DigitConfig.Price)
      Else
        otherexpense = 0
        Me.m_entity.OtherExpense = Nothing
        txtOtherExpense.Text = ""
      End If

      totalreplace = (sumamnt + otherexpense + cash)

      Me.m_entity.TotalReplace = Configuration.Format(totalreplace, DigitConfig.Price)

      txtTotalReplace.Text = Configuration.FormatToString(Me.m_entity.TotalReplace, DigitConfig.Price)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Customer).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcustcode", "txtcustname"
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
            Case "txtcustcode", "txtcustname"
              Me.SetCustomerDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Event of button controls"
    ' Customer 
    Private Sub btnCustEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub btnCustFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
    End Sub
    Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
      Dim oldcode As String = txtCustCode.Text
      Me.txtCustCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Customer.GetCustomer(txtCustCode, txtCustName, Me.m_entity.Customer)
      If oldcode <> e.Code Then
        Me.m_entity.ItemTable.Clear()
        Me.m_entity.ItemReplaceTable.Clear()
        RefreshBlankGrid()
      End If
    End Sub
    Private Sub SetBankBranchName()

    End Sub
#End Region

#Region " Auto Gen Code "
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region


  End Class

End Namespace
