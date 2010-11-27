Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class UpdateDepositCheckDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents grbSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtSumCheck As System.Windows.Forms.TextBox
    Friend WithEvents TxtSumTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblSumCheck As System.Windows.Forms.Label
    Friend WithEvents lblSumTotal As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents lblBankname As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAcctName As System.Windows.Forms.TextBox
    Friend WithEvents txtIssuedate As System.Windows.Forms.TextBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnBankAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBankAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
    Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateDepositCheckDetail))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtIssuedate = New System.Windows.Forms.TextBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.grbSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCurrency1 = New System.Windows.Forms.Label()
      Me.txtSumCheck = New System.Windows.Forms.TextBox()
      Me.TxtSumTotal = New System.Windows.Forms.TextBox()
      Me.lblSumCheck = New System.Windows.Forms.Label()
      Me.lblSumTotal = New System.Windows.Forms.Label()
      Me.lblCurrency2 = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtBankAcctCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblIssueDate = New System.Windows.Forms.Label()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.btnBankAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblBankname = New System.Windows.Forms.Label()
      Me.txtBankName = New System.Windows.Forms.TextBox()
      Me.btnBankAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAcctName = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbMaster.SuspendLayout()
      Me.grbSum.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.cmbCode)
      Me.grbMaster.Controls.Add(Me.chkAutorun)
      Me.grbMaster.Controls.Add(Me.txtIssuedate)
      Me.grbMaster.Controls.Add(Me.ibtnBlank)
      Me.grbMaster.Controls.Add(Me.ibtnDelRow)
      Me.grbMaster.Controls.Add(Me.lblStatus)
      Me.grbMaster.Controls.Add(Me.grbSum)
      Me.grbMaster.Controls.Add(Me.tgItem)
      Me.grbMaster.Controls.Add(Me.lblItem)
      Me.grbMaster.Controls.Add(Me.txtBankAcctCode)
      Me.grbMaster.Controls.Add(Me.lblCode)
      Me.grbMaster.Controls.Add(Me.dtpIssueDate)
      Me.grbMaster.Controls.Add(Me.lblIssueDate)
      Me.grbMaster.Controls.Add(Me.lblBankAccount)
      Me.grbMaster.Controls.Add(Me.lblNote)
      Me.grbMaster.Controls.Add(Me.txtNote)
      Me.grbMaster.Controls.Add(Me.btnBankAcctEdit)
      Me.grbMaster.Controls.Add(Me.lblBankname)
      Me.grbMaster.Controls.Add(Me.txtBankName)
      Me.grbMaster.Controls.Add(Me.btnBankAcctFind)
      Me.grbMaster.Controls.Add(Me.txtBankAcctName)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.ForeColor = System.Drawing.Color.Blue
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(712, 360)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "นำฝากเช็ค : "
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(296, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'txtIssuedate
      '
      Me.Validator.SetDataType(Me.txtIssuedate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtIssuedate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtIssuedate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
      Me.txtIssuedate.Location = New System.Drawing.Point(424, 24)
      Me.txtIssuedate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtIssuedate, "")
      Me.txtIssuedate.Name = "txtIssuedate"
      Me.Validator.SetRegularExpression(Me.txtIssuedate, "")
      Me.Validator.SetRequired(Me.txtIssuedate, True)
      Me.txtIssuedate.Size = New System.Drawing.Size(123, 21)
      Me.txtIssuedate.TabIndex = 1
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(8, 256)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
      Me.ibtnBlank.TabIndex = 17
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(40, 256)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
      Me.ibtnDelRow.TabIndex = 18
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(8, 336)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(25, 13)
      Me.lblStatus.TabIndex = 20
      Me.lblStatus.Text = "xxx"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSum
      '
      Me.grbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSum.Controls.Add(Me.lblCurrency1)
      Me.grbSum.Controls.Add(Me.txtSumCheck)
      Me.grbSum.Controls.Add(Me.TxtSumTotal)
      Me.grbSum.Controls.Add(Me.lblSumCheck)
      Me.grbSum.Controls.Add(Me.lblSumTotal)
      Me.grbSum.Controls.Add(Me.lblCurrency2)
      Me.grbSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSum.Location = New System.Drawing.Point(312, 264)
      Me.grbSum.Name = "grbSum"
      Me.grbSum.Size = New System.Drawing.Size(384, 72)
      Me.grbSum.TabIndex = 19
      Me.grbSum.TabStop = False
      Me.grbSum.Text = "สรุปรายการนำฝากเช็ค"
      '
      'lblCurrency1
      '
      Me.lblCurrency1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency1.AutoSize = True
      Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency1.Location = New System.Drawing.Point(328, 16)
      Me.lblCurrency1.Name = "lblCurrency1"
      Me.lblCurrency1.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrency1.TabIndex = 2
      Me.lblCurrency1.Text = "บาท"
      Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumCheck
      '
      Me.txtSumCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtSumCheck, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int32Type)
      Me.Validator.SetDisplayName(Me.txtSumCheck, "")
      Me.txtSumCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSumCheck, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
      Me.txtSumCheck.Location = New System.Drawing.Point(184, 16)
      Me.txtSumCheck.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtSumCheck, "")
      Me.txtSumCheck.Name = "txtSumCheck"
      Me.txtSumCheck.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumCheck, "")
      Me.Validator.SetRequired(Me.txtSumCheck, False)
      Me.txtSumCheck.Size = New System.Drawing.Size(136, 21)
      Me.txtSumCheck.TabIndex = 1
      Me.txtSumCheck.TabStop = False
      Me.txtSumCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TxtSumTotal
      '
      Me.TxtSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.TxtSumTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.TxtSumTotal, "")
      Me.TxtSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtSumTotal, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
      Me.TxtSumTotal.Location = New System.Drawing.Point(184, 40)
      Me.TxtSumTotal.MaxLength = 13
      Me.Validator.SetMinValue(Me.TxtSumTotal, "")
      Me.TxtSumTotal.Name = "TxtSumTotal"
      Me.TxtSumTotal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.TxtSumTotal, "")
      Me.Validator.SetRequired(Me.TxtSumTotal, False)
      Me.TxtSumTotal.Size = New System.Drawing.Size(136, 21)
      Me.TxtSumTotal.TabIndex = 4
      Me.TxtSumTotal.TabStop = False
      Me.TxtSumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblSumCheck
      '
      Me.lblSumCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSumCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumCheck.ForeColor = System.Drawing.Color.Black
      Me.lblSumCheck.Location = New System.Drawing.Point(16, 16)
      Me.lblSumCheck.Name = "lblSumCheck"
      Me.lblSumCheck.Size = New System.Drawing.Size(160, 18)
      Me.lblSumCheck.TabIndex = 0
      Me.lblSumCheck.Text = "จำนวนเช็คที่จะฝาก:"
      Me.lblSumCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSumTotal
      '
      Me.lblSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumTotal.ForeColor = System.Drawing.Color.Black
      Me.lblSumTotal.Location = New System.Drawing.Point(8, 40)
      Me.lblSumTotal.Name = "lblSumTotal"
      Me.lblSumTotal.Size = New System.Drawing.Size(168, 18)
      Me.lblSumTotal.TabIndex = 3
      Me.lblSumTotal.Text = "จำนวนเงินรวม:"
      Me.lblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency2
      '
      Me.lblCurrency2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency2.AutoSize = True
      Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency2.Location = New System.Drawing.Point(328, 40)
      Me.lblCurrency2.Name = "lblCurrency2"
      Me.lblCurrency2.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrency2.TabIndex = 5
      Me.lblCurrency2.Text = "บาท"
      Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 152)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(696, 104)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 16
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 128)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(179, 16)
      Me.lblItem.TabIndex = 15
      Me.lblItem.Text = "รายการเช็คที่ต้องการนำฝาก:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtBankAcctCode
      '
      Me.Validator.SetDataType(Me.txtBankAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.txtBankAcctCode.Location = New System.Drawing.Point(152, 48)
      Me.txtBankAcctCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Name = "txtBankAcctCode"
      Me.Validator.SetRegularExpression(Me.txtBankAcctCode, "")
      Me.Validator.SetRequired(Me.txtBankAcctCode, True)
      Me.txtBankAcctCode.Size = New System.Drawing.Size(144, 21)
      Me.txtBankAcctCode.TabIndex = 2
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(136, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpIssueDate
      '
      Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpIssueDate.Location = New System.Drawing.Point(424, 24)
      Me.dtpIssueDate.Name = "dtpIssueDate"
      Me.dtpIssueDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpIssueDate.TabIndex = 5
      Me.dtpIssueDate.TabStop = False
      '
      'lblIssueDate
      '
      Me.lblIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIssueDate.ForeColor = System.Drawing.Color.Black
      Me.lblIssueDate.Location = New System.Drawing.Point(328, 24)
      Me.lblIssueDate.Name = "lblIssueDate"
      Me.lblIssueDate.Size = New System.Drawing.Size(96, 18)
      Me.lblIssueDate.TabIndex = 3
      Me.lblIssueDate.Text = "Document Date:"
      Me.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(8, 48)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(136, 18)
      Me.lblBankAccount.TabIndex = 6
      Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 96)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(136, 18)
      Me.lblNote.TabIndex = 13
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
      Me.txtNote.Location = New System.Drawing.Point(152, 96)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(416, 24)
      Me.txtNote.TabIndex = 4
      '
      'btnBankAcctEdit
      '
      Me.btnBankAcctEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAcctEdit.Location = New System.Drawing.Point(544, 48)
      Me.btnBankAcctEdit.Name = "btnBankAcctEdit"
      Me.btnBankAcctEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAcctEdit.TabIndex = 10
      Me.btnBankAcctEdit.TabStop = False
      Me.btnBankAcctEdit.ThemedImage = CType(resources.GetObject("btnBankAcctEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBankname
      '
      Me.lblBankname.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankname.ForeColor = System.Drawing.Color.Black
      Me.lblBankname.Location = New System.Drawing.Point(8, 72)
      Me.lblBankname.Name = "lblBankname"
      Me.lblBankname.Size = New System.Drawing.Size(136, 18)
      Me.lblBankname.TabIndex = 11
      Me.lblBankname.Text = "ธนาคาร/สาขา:"
      Me.lblBankname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankName
      '
      Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankName, "")
      Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.txtBankName.Location = New System.Drawing.Point(152, 72)
      Me.Validator.SetMinValue(Me.txtBankName, "")
      Me.txtBankName.Name = "txtBankName"
      Me.txtBankName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankName, "")
      Me.Validator.SetRequired(Me.txtBankName, False)
      Me.txtBankName.Size = New System.Drawing.Size(416, 21)
      Me.txtBankName.TabIndex = 12
      Me.txtBankName.TabStop = False
      '
      'btnBankAcctFind
      '
      Me.btnBankAcctFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcctFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAcctFind.Location = New System.Drawing.Point(520, 48)
      Me.btnBankAcctFind.Name = "btnBankAcctFind"
      Me.btnBankAcctFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAcctFind.TabIndex = 9
      Me.btnBankAcctFind.TabStop = False
      Me.btnBankAcctFind.ThemedImage = CType(resources.GetObject("btnBankAcctFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAcctName
      '
      Me.Validator.SetDataType(Me.txtBankAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctName, "")
      Me.txtBankAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
      Me.txtBankAcctName.Location = New System.Drawing.Point(296, 48)
      Me.Validator.SetMinValue(Me.txtBankAcctName, "")
      Me.txtBankAcctName.Name = "txtBankAcctName"
      Me.Validator.SetRegularExpression(Me.txtBankAcctName, "")
      Me.Validator.SetRequired(Me.txtBankAcctName, False)
      Me.txtBankAcctName.Size = New System.Drawing.Size(224, 21)
      Me.txtBankAcctName.TabIndex = 3
      Me.txtBankAcctName.TabStop = False
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
      'cmbCode
      '
      Me.cmbCode.FormattingEnabled = True
      Me.cmbCode.Location = New System.Drawing.Point(152, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(145, 21)
      Me.cmbCode.TabIndex = 0
      '
      'UpdateDepositCheckDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "UpdateDepositCheckDetail"
      Me.Size = New System.Drawing.Size(728, 376)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbSum.ResumeLayout(False)
      Me.grbSum.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblCode}")
      Me.Validator.SetDisplayName(cmbCode, lblCode.Text)

      Me.lblIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblIssueDate}")
      Me.Validator.SetDisplayName(txtIssuedate, lblIssueDate.Text)

      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblBankAccount}")
      Me.lblBankname.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblBankname}")
      Me.Validator.SetDisplayName(txtBankAcctCode, lblBankAccount.Text)

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblItem}")
      Me.lblSumCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblSumCheck}")
      Me.Validator.SetDisplayName(txtSumCheck, lblSumCheck.Text)

      Me.lblSumTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblSumTotal}")
      Me.Validator.SetDisplayName(TxtSumTotal, lblSumTotal.Text)

      Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.lblSumUnit}")
      Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.grbMaster}")
      Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckDetail.grbSum}")
      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub
#End Region

#Region "Member"
    Private m_entity As UpdateCheckDeposit

    Private m_treeManager As TreeManager
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.SetLabelText()

      Dim dt As TreeTable = UpdateCheckDeposit.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      'Dim dst As DataGridTableStyle = UpdateCheckDeposit.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As UpdateCheckDepositItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Dim doc As New UpdateCheckDepositItem
        doc.CopyFromDataRow(row)
        If doc Is Nothing Then
          Return Nothing
        End If
        Return doc
      End Get
    End Property
#End Region

#Region " Styles "
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
      csCode.MappingName = "code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 70
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "code"
      ' Check Find button ...
      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf CheckClicked
      ' check docudate ...
      Dim csDocDate As New TreeTextColumn
      csDocDate.MappingName = "docdate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      csDocDate.Width = 120
      csDocDate.Alignment = HorizontalAlignment.Center
      csDocDate.DataAlignment = HorizontalAlignment.Center
      csDocDate.ReadOnly = True
      csDocDate.TextBox.Name = "docdate"
      ' CqCode ...
      Dim csCqcode As New TreeTextColumn
      csCqcode.MappingName = "cqcode"
      csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
      csCqcode.NullText = ""
      csCqcode.Width = 100
      csCqcode.Alignment = HorizontalAlignment.Center
      csCqcode.DataAlignment = HorizontalAlignment.Left
      csCqcode.ReadOnly = True
      csCqcode.TextBox.Name = "cqcode"
      ' recievepient ...
      Dim csRecipient As New TreeTextColumn
      csRecipient.MappingName = "recipient"
      csRecipient.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.recipientHeaderText}")
      csRecipient.NullText = ""
      csRecipient.Alignment = HorizontalAlignment.Center
      csRecipient.DataAlignment = HorizontalAlignment.Left
      csRecipient.Width = 150
      csRecipient.ReadOnly = True
      csRecipient.TextBox.Name = "recipient"
      ' Bank account code ...
      Dim csBankacctCode As New TreeTextColumn
      csBankacctCode.MappingName = "bankacct_code"
      csBankacctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankacctCodeCheckDetail.BankAcctcodeHeaderText}")
      csBankacctCode.NullText = ""
      csBankacctCode.Alignment = HorizontalAlignment.Center
      csBankacctCode.DataAlignment = HorizontalAlignment.Left
      csBankacctCode.Width = 100
      csBankacctCode.ReadOnly = True
      csBankacctCode.TextBox.Name = "bankacct_code"
      ' Bank account name ...
      Dim csBankacctName As New TreeTextColumn
      csBankacctName.MappingName = "bankacct_name"
      csBankacctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankacctNameHeaderText}")
      csBankacctName.NullText = ""
      csBankacctName.Alignment = HorizontalAlignment.Center
      csBankacctName.DataAlignment = HorizontalAlignment.Left
      csBankacctName.Width = 120
      csBankacctName.ReadOnly = True
      csBankacctName.TextBox.Name = "bankacct_name"
      ' Bank name ...
      Dim csBankName As New TreeTextColumn
      csBankName.MappingName = "bank_name"
      csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
      csBankName.NullText = ""
      csBankName.Alignment = HorizontalAlignment.Center
      csBankName.DataAlignment = HorizontalAlignment.Left
      csBankName.Width = 150
      csBankName.ReadOnly = True
      csBankName.TextBox.Name = "bank_name"

      ' Lastest Docstatus
      Dim csLastestStatus As New TreeTextColumn
      csLastestStatus.MappingName = "check_lastestdocstatus"
      csLastestStatus.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.IncomingCheckLastestStatus}")
      csLastestStatus.NullText = ""
      csLastestStatus.Alignment = HorizontalAlignment.Center
      csLastestStatus.DataAlignment = HorizontalAlignment.Left
      csLastestStatus.Width = 100
      csLastestStatus.ReadOnly = True
      csLastestStatus.TextBox.Name = "check_lastestdocstatus"

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
      dst.GridColumnStyles.Add(csDocDate)
      dst.GridColumnStyles.Add(csRecipient)
      'dst.GridColumnStyles.Add(csBankacctCode)
      'dst.GridColumnStyles.Add(csBankacctName)
      dst.GridColumnStyles.Add(csBankName)
      dst.GridColumnStyles.Add(csLastestStatus)
      dst.GridColumnStyles.Add(csCheckAmnt)

      Return dst
    End Function

    Public Sub CheckClicked(ByVal e As ButtonColumnEventArgs)
      CheckButtonClick(e)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub Initialize()

    End Sub
    Public Overrides Sub CheckFormEnable()
      Dim HasChildsRefed As Boolean = False
      If Me.m_entity.Originated Then
        If Me.m_entity.GetIsChildsReferenced.Length > 0 Then
          HasChildsRefed = True
        End If
      End If
      'HasChildsRefed = Me.m_entity.GetIsChildsReferenced
      If Me.m_entity.Canceled _
         OrElse Me.m_entity.Status.Value = 0 _
         OrElse Me.m_entity.Status.Value >= 3 _
         OrElse HasChildsRefed Then
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
      lblStatus.Text = ""
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

      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtIssuedate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBankAcctCode.Validated, AddressOf Me.ChangeProperty
      AddHandler tgItem.DoubleClick, AddressOf CellDblClick
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'cmbCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      ' autogencode 
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtIssuedate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpIssueDate.Value = MinDateToNow(Me.m_entity.DocDate)

      If Not Me.m_entity.BankAccount Is Nothing Then
        txtBankAcctCode.Text = Me.m_entity.BankAccount.Code
        txtBankAcctName.Text = Me.m_entity.BankAccount.Name
        SetBankBranchName()
      End If
      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************
      RefreshBlankGrid()

      SetStatus()
      SetLabelText()

      SetSummaryText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub

    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      SetSummaryText()
    End Sub

    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          'Me.m_entity.Code = cmbCode.Text
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True

        Case "dtpissuedate"
          txtIssuedate.Text = MinDateToNull(dtpIssueDate.Value, "")
          Me.m_entity.DocDate = dtpIssueDate.Value
          dirtyFlag = True
        Case "txtissuedate"
          Dim dt As Date = StringToDate(txtIssuedate, dtpIssueDate)
          Me.m_entity.DocDate = dt
          dirtyFlag = True

        Case "cmbstatus"
          Me.m_entity.ItemTable.Clear()
          RefreshBlankGrid()

          dirtyFlag = True

        Case "cmbchecktype"
          'registerentitybase()
          dirtyFlag = True

        Case "txtbankacctcode"
          dirtyFlag = BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.m_entity.BankAccount)
          SetBankBranchName()

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
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, UpdateCheckDeposit)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region "Event Handlers"
    Public Sub CheckButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim obj As New IncomingCheck
      obj.DocStatus = New IncomingCheckDocStatus(1)   ' แสดง เช็คในมือ เท่านั้น ...
      entities.Add(obj)

      Dim filters(1) As Filter
      filters(0) = New Filter("IDList", GenIDListFromDataTable())
      filters(1) = New Filter("cqupdate_id", Me.m_entity.Id)

      myEntityPanelService.OpenListDialog(New IncomingCheck, AddressOf SetCheckItems, filters, entities)
    End Sub
    Private Function GenIDListFromDataTable() As String
      Dim idlist As String = ""
      For Each row As TreeRow In Me.m_entity.ItemTable.Rows
        If Not IsDBNull(row("cqupdatei_entity")) Then
          idlist &= CStr(row("cqupdatei_entity")) & ","
        End If
      Next
      Return idlist
    End Function

    Private Sub SetEntityValue(ByVal check As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Code") = check.Code
      SetSummaryText()
    End Sub
    Private Sub SetCheckItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex

      For i As Integer = items.Count - 1 To 0 Step -1
        Dim newItem As New IncomingCheck(CType(items(i), BasketItem).Id)

        Dim cqtype As New CheckType(newItem.EntityId)

        Dim mtwItem As New UpdateCheckDepositItem

        mtwItem.Entity = newItem

        Me.m_entity.ItemTable.AcceptChanges()

        If i = items.Count - 1 Then
          If Me.m_entity.ItemTable.Childs.Count = 0 Then
            Me.m_entity.Add(mtwItem)
          Else
            mtwItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("linenumber"))
            mtwItem.UpdateCheckDeposit = Me.m_entity
            mtwItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
          End If
        Else
          Me.m_entity.Insert(index, mtwItem)
        End If
        Me.m_entity.ItemTable.AcceptChanges()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      Next

      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      ' Summary ...
      SetSummaryText()
    End Sub

    Private Sub PRPanelView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
      AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
    End Sub
    Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As System.EventArgs)

      Dim doc As UpdateCheckDepositItem = Me.CurrentItem
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
        Return (New UpdateCheckDeposit).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Rows Manager Button"
    ' Add Item ...
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim checkItem As New UpdateCheckDepositItem

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
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
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
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetSummaryText()
      Dim totalamount As Decimal = Me.m_entity.IncomingCheckTotalAmount
      txtSumCheck.Text = Configuration.FormatToString(Me.m_entity.IncomingCheckItem, DigitConfig.Int)
      TxtSumTotal.Text = Configuration.FormatToString(totalamount, DigitConfig.Price)
      Me.m_entity.TotalAmount = totalamount
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankacctcode", "txtbankacctname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New BankAccount).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
        Dim entity As New BankAccount(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtbankacctcode", "txtbankacctname"
              Me.SetBankAccountDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Event of button controls"
    ' Bank Account 
    Private Sub btnBankAcctEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnBankAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
    End Sub
    Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
      Me.txtBankAcctCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.m_entity.BankAccount)
      SetBankBranchName()
    End Sub
    Private Sub SetBankBranchName()
      Dim oldstatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      If Not Me.m_entity.BankAccount Is Nothing AndAlso Me.m_entity.BankAccount.Originated Then
        txtBankName.Text = Me.m_entity.BankAccount.BankBranch.Bank.Name & " / " & _
                            Me.m_entity.BankAccount.BankBranch.Name
      Else
        txtBankName.Text = ""
      End If
      Me.m_isInitialized = oldstatus
    End Sub
#End Region

#Region " Autogencode "
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
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        'Me.cmbCode.Text = m_oldCode
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = Me.m_entity.Code
        Me.m_entity.AutoGen = False
      End If



    End Sub
#End Region

  End Class

End Namespace
