Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class UpdateIncomingCheckDetail
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
        Friend WithEvents grbSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSumCheck As System.Windows.Forms.TextBox
        Friend WithEvents TxtSumTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblSumCheck As System.Windows.Forms.Label
        Friend WithEvents lblSumTotal As System.Windows.Forms.Label
        Friend WithEvents lblSumCheckUnit As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtIssueDate As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblUpdateStatus As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblIssueDate As System.Windows.Forms.Label
        Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
        Friend WithEvents lblBankcharge As System.Windows.Forms.Label
        Friend WithEvents txtBankcharge As System.Windows.Forms.TextBox
        Friend WithEvents lblWht As System.Windows.Forms.Label
        Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
        Friend WithEvents txtWht As System.Windows.Forms.TextBox
        Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdateIncomingCheckDetail))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtIssueDate = New System.Windows.Forms.TextBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker
            Me.lblIssueDate = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblUpdateStatus = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblStatus = New System.Windows.Forms.Label
            Me.grbSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtSumCheck = New System.Windows.Forms.TextBox
            Me.TxtSumTotal = New System.Windows.Forms.TextBox
            Me.lblSumCheck = New System.Windows.Forms.Label
            Me.lblSumTotal = New System.Windows.Forms.Label
            Me.lblSumCheckUnit = New System.Windows.Forms.Label
            Me.lblCurrency3 = New System.Windows.Forms.Label
            Me.lblBankcharge = New System.Windows.Forms.Label
            Me.txtBankcharge = New System.Windows.Forms.TextBox
            Me.lblWht = New System.Windows.Forms.Label
            Me.lblCurrency1 = New System.Windows.Forms.Label
            Me.txtWht = New System.Windows.Forms.TextBox
            Me.lblCurrency2 = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbMaster.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbSum.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.chkAutorun)
            Me.grbMaster.Controls.Add(Me.txtCode)
            Me.grbMaster.Controls.Add(Me.ibtnBlank)
            Me.grbMaster.Controls.Add(Me.ibtnDelRow)
            Me.grbMaster.Controls.Add(Me.lblCode)
            Me.grbMaster.Controls.Add(Me.txtIssueDate)
            Me.grbMaster.Controls.Add(Me.cmbStatus)
            Me.grbMaster.Controls.Add(Me.dtpIssueDate)
            Me.grbMaster.Controls.Add(Me.lblIssueDate)
            Me.grbMaster.Controls.Add(Me.lblNote)
            Me.grbMaster.Controls.Add(Me.txtNote)
            Me.grbMaster.Controls.Add(Me.lblUpdateStatus)
            Me.grbMaster.Controls.Add(Me.tgItem)
            Me.grbMaster.Controls.Add(Me.lblStatus)
            Me.grbMaster.Controls.Add(Me.grbSum)
            Me.grbMaster.Controls.Add(Me.lblItem)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(704, 336)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ปรับปรุงสถานะเช็ค : "
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(288, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(144, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(144, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(224, 96)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 12
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(248, 96)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 13
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCode
            '
            Me.lblCode.Cursor = System.Windows.Forms.Cursors.Default
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(128, 16)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลือกประเภทเช็ค:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIssueDate
            '
            Me.Validator.SetDataType(Me.txtIssueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtIssueDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtIssueDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
            Me.txtIssueDate.Location = New System.Drawing.Point(432, 24)
            Me.Validator.SetMaxValue(Me.txtIssueDate, "")
            Me.Validator.SetMinValue(Me.txtIssueDate, "")
            Me.txtIssueDate.Name = "txtIssueDate"
            Me.Validator.SetRegularExpression(Me.txtIssueDate, "")
            Me.Validator.SetRequired(Me.txtIssueDate, True)
            Me.txtIssueDate.Size = New System.Drawing.Size(125, 20)
            Me.txtIssueDate.TabIndex = 4
            Me.txtIssueDate.Text = ""
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ErrorProvider1.SetIconPadding(Me.cmbStatus, -15)
            Me.cmbStatus.Location = New System.Drawing.Point(144, 48)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(168, 21)
            Me.cmbStatus.TabIndex = 7
            '
            'dtpIssueDate
            '
            Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpIssueDate.Location = New System.Drawing.Point(432, 24)
            Me.dtpIssueDate.Name = "dtpIssueDate"
            Me.dtpIssueDate.Size = New System.Drawing.Size(144, 20)
            Me.dtpIssueDate.TabIndex = 5
            Me.dtpIssueDate.TabStop = False
            '
            'lblIssueDate
            '
            Me.lblIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIssueDate.ForeColor = System.Drawing.Color.Black
            Me.lblIssueDate.Location = New System.Drawing.Point(312, 24)
            Me.lblIssueDate.Name = "lblIssueDate"
            Me.lblIssueDate.Size = New System.Drawing.Size(112, 18)
            Me.lblIssueDate.TabIndex = 3
            Me.lblIssueDate.Text = "วันที่เอกสาร:"
            Me.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 72)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(128, 16)
            Me.lblNote.TabIndex = 8
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
            Me.txtNote.Location = New System.Drawing.Point(144, 72)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(432, 21)
            Me.txtNote.TabIndex = 9
            Me.txtNote.Text = ""
            '
            'lblUpdateStatus
            '
            Me.lblUpdateStatus.Cursor = System.Windows.Forms.Cursors.Default
            Me.lblUpdateStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUpdateStatus.ForeColor = System.Drawing.Color.Black
            Me.lblUpdateStatus.Location = New System.Drawing.Point(8, 48)
            Me.lblUpdateStatus.Name = "lblUpdateStatus"
            Me.lblUpdateStatus.Size = New System.Drawing.Size(128, 16)
            Me.lblUpdateStatus.TabIndex = 6
            Me.lblUpdateStatus.Text = "ปรับปรุงสถานะเป็น:"
            Me.lblUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.tgItem.Location = New System.Drawing.Point(8, 120)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(688, 112)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 11
            Me.tgItem.TreeManager = Nothing
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(8, 312)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 15
            Me.lblStatus.Text = "lblStatus"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbSum
            '
            Me.grbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbSum.Controls.Add(Me.txtSumCheck)
            Me.grbSum.Controls.Add(Me.TxtSumTotal)
            Me.grbSum.Controls.Add(Me.lblSumCheck)
            Me.grbSum.Controls.Add(Me.lblSumTotal)
            Me.grbSum.Controls.Add(Me.lblSumCheckUnit)
            Me.grbSum.Controls.Add(Me.lblCurrency3)
            Me.grbSum.Controls.Add(Me.lblBankcharge)
            Me.grbSum.Controls.Add(Me.txtBankcharge)
            Me.grbSum.Controls.Add(Me.lblWht)
            Me.grbSum.Controls.Add(Me.lblCurrency1)
            Me.grbSum.Controls.Add(Me.txtWht)
            Me.grbSum.Controls.Add(Me.lblCurrency2)
            Me.grbSum.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSum.Location = New System.Drawing.Point(88, 240)
            Me.grbSum.Name = "grbSum"
            Me.grbSum.Size = New System.Drawing.Size(608, 72)
            Me.grbSum.TabIndex = 14
            Me.grbSum.TabStop = False
            Me.grbSum.Text = "สรุปรายการเช็ค"
            '
            'txtSumCheck
            '
            Me.txtSumCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtSumCheck, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int64Type)
            Me.Validator.SetDisplayName(Me.txtSumCheck, "")
            Me.txtSumCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSumCheck, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
            Me.txtSumCheck.Location = New System.Drawing.Point(440, 16)
            Me.Validator.SetMaxValue(Me.txtSumCheck, "")
            Me.Validator.SetMinValue(Me.txtSumCheck, "")
            Me.txtSumCheck.Name = "txtSumCheck"
            Me.txtSumCheck.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSumCheck, "")
            Me.Validator.SetRequired(Me.txtSumCheck, False)
            Me.txtSumCheck.Size = New System.Drawing.Size(104, 21)
            Me.txtSumCheck.TabIndex = 7
            Me.txtSumCheck.TabStop = False
            Me.txtSumCheck.Text = ""
            Me.txtSumCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TxtSumTotal
            '
            Me.TxtSumTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.TxtSumTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TxtSumTotal, -15)
            Me.Validator.SetInvalidBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.TxtSumTotal.Location = New System.Drawing.Point(440, 40)
            Me.Validator.SetMaxValue(Me.TxtSumTotal, "")
            Me.Validator.SetMinValue(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Name = "TxtSumTotal"
            Me.TxtSumTotal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.TxtSumTotal, "")
            Me.Validator.SetRequired(Me.TxtSumTotal, False)
            Me.TxtSumTotal.Size = New System.Drawing.Size(104, 21)
            Me.TxtSumTotal.TabIndex = 10
            Me.TxtSumTotal.TabStop = False
            Me.TxtSumTotal.Text = ""
            Me.TxtSumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblSumCheck
            '
            Me.lblSumCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumCheck.ForeColor = System.Drawing.Color.Black
            Me.lblSumCheck.Location = New System.Drawing.Point(288, 16)
            Me.lblSumCheck.Name = "lblSumCheck"
            Me.lblSumCheck.Size = New System.Drawing.Size(144, 18)
            Me.lblSumCheck.TabIndex = 6
            Me.lblSumCheck.Text = "จำนวนเช็คที่จะฝาก:"
            Me.lblSumCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSumTotal
            '
            Me.lblSumTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumTotal.ForeColor = System.Drawing.Color.Black
            Me.lblSumTotal.Location = New System.Drawing.Point(288, 40)
            Me.lblSumTotal.Name = "lblSumTotal"
            Me.lblSumTotal.Size = New System.Drawing.Size(144, 18)
            Me.lblSumTotal.TabIndex = 9
            Me.lblSumTotal.Text = "จำนวนเงินรวม:"
            Me.lblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSumCheckUnit
            '
            Me.lblSumCheckUnit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumCheckUnit.AutoSize = True
            Me.lblSumCheckUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumCheckUnit.ForeColor = System.Drawing.Color.Black
            Me.lblSumCheckUnit.Location = New System.Drawing.Point(552, 16)
            Me.lblSumCheckUnit.Name = "lblSumCheckUnit"
            Me.lblSumCheckUnit.Size = New System.Drawing.Size(38, 17)
            Me.lblSumCheckUnit.TabIndex = 8
            Me.lblSumCheckUnit.Text = "รายการ"
            Me.lblSumCheckUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency3
            '
            Me.lblCurrency3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency3.AutoSize = True
            Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency3.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency3.Location = New System.Drawing.Point(552, 40)
            Me.lblCurrency3.Name = "lblCurrency3"
            Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency3.TabIndex = 11
            Me.lblCurrency3.Text = "บาท"
            Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBankcharge
            '
            Me.lblBankcharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBankcharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankcharge.ForeColor = System.Drawing.Color.Black
            Me.lblBankcharge.Location = New System.Drawing.Point(8, 16)
            Me.lblBankcharge.Name = "lblBankcharge"
            Me.lblBankcharge.Size = New System.Drawing.Size(120, 18)
            Me.lblBankcharge.TabIndex = 0
            Me.lblBankcharge.Text = "ค่าธรรมเนียมธนาคาร"
            Me.lblBankcharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankcharge
            '
            Me.txtBankcharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtBankcharge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtBankcharge, "")
            Me.txtBankcharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankcharge, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankcharge, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankcharge, System.Drawing.Color.Empty)
            Me.txtBankcharge.Location = New System.Drawing.Point(136, 16)
            Me.Validator.SetMaxValue(Me.txtBankcharge, "")
            Me.Validator.SetMinValue(Me.txtBankcharge, "")
            Me.txtBankcharge.Name = "txtBankcharge"
            Me.txtBankcharge.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankcharge, "")
            Me.Validator.SetRequired(Me.txtBankcharge, False)
            Me.txtBankcharge.Size = New System.Drawing.Size(104, 21)
            Me.txtBankcharge.TabIndex = 1
            Me.txtBankcharge.TabStop = False
            Me.txtBankcharge.Text = ""
            Me.txtBankcharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblWht
            '
            Me.lblWht.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWht.ForeColor = System.Drawing.Color.Black
            Me.lblWht.Location = New System.Drawing.Point(8, 40)
            Me.lblWht.Name = "lblWht"
            Me.lblWht.Size = New System.Drawing.Size(120, 18)
            Me.lblWht.TabIndex = 3
            Me.lblWht.Text = "ภาษีหัก ณ ที่จ่าย"
            Me.lblWht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency1
            '
            Me.lblCurrency1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency1.AutoSize = True
            Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency1.Location = New System.Drawing.Point(248, 16)
            Me.lblCurrency1.Name = "lblCurrency1"
            Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency1.TabIndex = 2
            Me.lblCurrency1.Text = "บาท"
            Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWht
            '
            Me.txtWht.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtWht, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtWht, "")
            Me.txtWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtWht, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtWht, -15)
            Me.Validator.SetInvalidBackColor(Me.txtWht, System.Drawing.Color.Empty)
            Me.txtWht.Location = New System.Drawing.Point(136, 40)
            Me.Validator.SetMaxValue(Me.txtWht, "")
            Me.Validator.SetMinValue(Me.txtWht, "")
            Me.txtWht.Name = "txtWht"
            Me.txtWht.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtWht, "")
            Me.Validator.SetRequired(Me.txtWht, False)
            Me.txtWht.Size = New System.Drawing.Size(104, 21)
            Me.txtWht.TabIndex = 4
            Me.txtWht.TabStop = False
            Me.txtWht.Text = ""
            Me.txtWht.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblCurrency2
            '
            Me.lblCurrency2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency2.AutoSize = True
            Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency2.Location = New System.Drawing.Point(248, 40)
            Me.lblCurrency2.Name = "lblCurrency2"
            Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency2.TabIndex = 5
            Me.lblCurrency2.Text = "บาท"
            Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(16, 104)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(213, 19)
            Me.lblItem.TabIndex = 10
            Me.lblItem.Text = "รายการเช็คที่ต้องการเปลี่ยนสถานะ"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'UpdateIncomingCheckDetail
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Name = "UpdateIncomingCheckDetail"
            Me.Size = New System.Drawing.Size(728, 352)
            Me.grbMaster.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbSum.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblSumCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblSumCheck}")
            Me.Validator.SetDisplayName(txtSumCheck, lblSumCheck.Text)

            Me.lblSumTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblSumTotal}")
            Me.Validator.SetDisplayName(TxtSumTotal, lblSumTotal.Text)

            Me.lblIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblIssueDate}")
            Me.Validator.SetDisplayName(txtIssueDate, lblIssueDate.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblBankcharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblBankcharge}")
            Me.Validator.SetDisplayName(txtBankcharge, lblBankcharge.Text)

            Me.lblWht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblWht}")
            Me.Validator.SetDisplayName(txtWht, lblWht.Text)

            Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblItem}")
            Me.lblSumCheckUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblSumCheckUnit}")
            Me.lblUpdateStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.lblUpdateStatus}")

            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.grbMaster}")
            Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateIncomingCheckDetail.grbSum}")

            Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
        End Sub
#End Region

#Region "Member"
        Private m_entity As UpdateCheckReceive

        Private m_treeManager As TreeManager
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.Initialize()
            Me.SetLabelText()

            Dim dt As TreeTable = UpdateCheckReceive.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
        End Sub
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
            csCode.MappingName = "code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 80
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "code"
            ' Check Find button ...
            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf CheckButtonClick
            ' check docudate ...
            Dim csDocDate As New TreeTextColumn
            csDocDate.MappingName = "docdate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
            csDocDate.NullText = ""
            csDocDate.Width = 80
            csDocDate.Alignment = HorizontalAlignment.Center
            csDocDate.DataAlignment = HorizontalAlignment.Center
            csDocDate.ReadOnly = True
            csDocDate.Format = "dd/MM/yyyy"
            csDocDate.TextBox.Name = "docdate"
            ' CqCode ...
            Dim csCqcode As New TreeTextColumn
            csCqcode.MappingName = "cqcode"
            csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
            csCqcode.NullText = ""
            csCqcode.Width = 80
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
            csRecipient.Width = 120
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
            csBankName.Width = 120
            csBankName.ReadOnly = True
            csBankName.TextBox.Name = "bank_name"
            ' Check amount ...
            Dim csCheckAmnt As New TreeTextColumn
            csCheckAmnt.MappingName = "check_amount"
            csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CheckAmountHeaderText}")
            csCheckAmnt.NullText = ""
            csCheckAmnt.Width = 80
            csCheckAmnt.Alignment = HorizontalAlignment.Center
            csCheckAmnt.DataAlignment = HorizontalAlignment.Right
            csCheckAmnt.ReadOnly = True
            csCheckAmnt.Format = "#,##0.00"
            csCheckAmnt.TextBox.Name = "check_amount"
            ' Check amount ...
            Dim csBankCharge As New TreeTextColumn
            csBankCharge.MappingName = "check_bankcharge"
            csBankCharge.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.BankChargeHeaderText}")
            csBankCharge.NullText = ""
            csBankCharge.Width = 100
            csBankCharge.Alignment = HorizontalAlignment.Center
            csBankCharge.DataAlignment = HorizontalAlignment.Right
            csBankCharge.ReadOnly = False
            csBankCharge.Format = "#,##0.00"
            csBankCharge.TextBox.Name = "check_bankcharge"
            ' Check amount ...
            Dim csWht As New TreeTextColumn
            csWht.MappingName = "check_wht"
            csWht.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.WhtHeaderText}")
            csWht.NullText = ""
            csWht.Width = 80
            csWht.Alignment = HorizontalAlignment.Center
            csWht.DataAlignment = HorizontalAlignment.Right
            csWht.ReadOnly = False
            csWht.Format = "#,##0.00"
            csWht.TextBox.Name = "check_wht"

            ' Lastest Docstatus
            Dim csLastestStatus As New TreeTextColumn
            csLastestStatus.MappingName = "check_lastestdocstatus"
            csLastestStatus.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.IncomingCheckLastestStatus}")
            csLastestStatus.NullText = ""
            csLastestStatus.Alignment = HorizontalAlignment.Center
            csLastestStatus.DataAlignment = HorizontalAlignment.Left
            csLastestStatus.Width = 70
            csLastestStatus.ReadOnly = True
            csLastestStatus.TextBox.Name = "check_lastestdocstatus"

            ' Add column style ...
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csCqcode)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csRecipient)
            'dst.GridColumnStyles.Add(csBankacctCode)
            dst.GridColumnStyles.Add(csBankacctName)
            dst.GridColumnStyles.Add(csBankName)
            dst.GridColumnStyles.Add(csLastestStatus)
            dst.GridColumnStyles.Add(csCheckAmnt)
            dst.GridColumnStyles.Add(csBankCharge)
            dst.GridColumnStyles.Add(csWht)
           
            Return dst
        End Function

#End Region

#Region "IListDetail"
        Public Overrides Sub Initialize()
            IncomingCheckDocStatus.ListCodeDescriptionInComboBox(cmbStatus, "Incomingcheck_update")
        End Sub

        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled _
            OrElse Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 Then
                For Each ctrl As Control In grbMaster.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In grbSum.Controls
                    ctrl.Enabled = False
                Next
            Else
                For Each ctrl As Control In grbMaster.Controls
                    ctrl.Enabled = True
                Next
                For Each ctrl As Control In grbSum.Controls
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
            Me.txtIssueDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            Me.cmbStatus.SelectedIndex = -1
            Me.cmbStatus.SelectedIndex = -1

        End Sub

        Protected Overrides Sub EventWiring()

            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtIssueDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler cmbStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtBankcharge.Validated, AddressOf Me.NumberTextBoxChange
            AddHandler txtWht.Validated, AddressOf Me.NumberTextBoxChange

            AddHandler txtBankcharge.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtWht.TextChanged, AddressOf Me.ChangeProperty
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
            'autogencode
            Me.m_oldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtIssueDate.Text = MinDateToNull(Me.m_entity.IssueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpIssueDate.Value = MinDateToNow(Me.m_entity.IssueDate)

            txtBankcharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)
            txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)

            Dim index As Integer = -1
            If Not Me.m_entity.UpdatedStatus Is Nothing Then
                index = cmbStatus.FindStringExact(Me.m_entity.UpdatedStatus.Description)
            End If
            If index = -1 Then
                cmbStatus.SelectedIndex = -1
            Else
                cmbStatus.SelectedIndex = index
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

        Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtbankcharge"
                    txtBankcharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)
                Case "txtwht"
                    txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)
            End Select
        End Sub

        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
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
                    txtIssueDate.Text = MinDateToNull(dtpIssueDate.Value, "")
                    Me.m_entity.IssueDate = dtpIssueDate.Value
                    dirtyFlag = True

                Case "txtissuedate"
                    Dim dt As Date = StringToDate(txtIssueDate, dtpIssueDate)
                    Me.m_entity.IssueDate = dt
                    dirtyFlag = True

                Case "cmbstatus"
                    Me.m_entity.ItemTable.Clear()
                    RefreshBlankGrid()

                    Me.m_entity.UpdatedStatus = New IncomingCheckDocStatus(cmbStatus.Text)
                    dirtyFlag = True

                Case "cmbchecktype"
                    'registerentitybase()
                    dirtyFlag = True

                Case "txtbankcharge"
                    If txtBankcharge.TextLength > 0 Then
                        Me.m_entity.BankCharge = CDec(txtBankcharge.Text)
                    Else
                        Me.m_entity.BankCharge = Nothing
                    End If
                    dirtyFlag = True

                Case "txtwht"
                    If txtWht.TextLength > 0 Then
                        Me.m_entity.WHT = CDec(txtWht.Text)
                    Else
                        Me.m_entity.WHT = Nothing
                    End If
                    dirtyFlag = True
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()
            SetStatus()

        End Sub
        Public Sub SetStatus()
            If m_entity.Canceled Then
                lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
                " " & m_entity.CancelDate.ToShortTimeString & _
                "  โดย:" & m_entity.CancelPerson.Name
            ElseIf m_entity.Edited Then
                lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
                " " & m_entity.LastEditDate.ToShortTimeString & _
                "  โดย:" & m_entity.LastEditor.Name
            ElseIf m_entity.Originated Then
                lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
                " " & m_entity.OriginDate.ToShortTimeString & _
                "  โดย:" & m_entity.Originator.Name
            Else
                lblStatus.Text = "ยังไม่ได้บันทึก"
            End If
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
                Me.m_entity = CType(Value, UpdateCheckReceive)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

#Region "Event Handlers"
        Public Sub CheckButtonClick(ByVal e As ButtonColumnEventArgs)
            If Me.cmbStatus.SelectedIndex = -1 Then
                Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMessageService.ShowWarningFormatted("${res:Global.MustDefine}", lblUpdateStatus.Text)
                cmbStatus.Focus()
                Return
            End If

            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim obj As New IncomingCheck

            Dim checkValue As Integer
            If TypeOf cmbStatus.SelectedItem Is IdValuePair Then
                checkValue = CType(cmbStatus.SelectedItem, IdValuePair).Id
            End If
            Dim index As Integer = FindStatusFilter(checkValue)
            obj.DocStatus = New IncomingCheckDocStatus(index)

            entities.Add(obj)

            Dim filters(1) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable())
            filters(1) = New Filter("spacial_status", IIf(cmbStatus.SelectedIndex = 0, 0, DBNull.Value))

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

                Dim mtwItem As New UpdateCheckReceiveItem

                mtwItem.Entity = newItem
                mtwItem.BeforeStatus = newItem.DocStatus

                Me.m_entity.ItemTable.AcceptChanges()

                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.Add(mtwItem)
                    Else
                        mtwItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("linenumber"))
                        mtwItem.UpdateCheckReceive = Me.m_entity
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
            SetSummaryText()
        End Sub

        Private Function FindStatusFilter(ByVal value As Integer) As Integer
            Dim filter As Integer
            Select Case value
                Case 0  ' ยกเลิก
                    filter = 99  ' กำหนด filter spacial
                Case 1  ' เช็คในมือ
                    filter = 3
                Case 2  ' เช็คผ่าน
                    filter = 3
                Case 3  ' เช็คฝากธนาคาร
                    filter = -1
                Case 4  ' ขายลดเช็ค
                    filter = -1
                Case 5  ' เช็คคืน
                    filter = -1
                Case 6  ' เปลี่ยนเช็ครับ
                    filter = -1
            End Select

            Return filter
        End Function

        Private Sub PRPanelView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
        End Sub
        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

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
                Return (New UpdateCheckReceive).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Rows Manager Button"
        ' Add Item ...
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim newItem As New BlankItem("")
            Dim checkItem As New UpdateCheckReceiveItem

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
            Dim item As Integer = 0
            Dim amount As Decimal = 0
            For Each row As TreeRow In Me.m_entity.ItemTable.Rows
                If Not row.IsNull("code") Then
                    item += 1
                    If Not row.IsNull("check_amount") Then
                        amount += CDec(row("check_amount"))
                    End If
                End If
            Next

            txtSumCheck.Text = Configuration.FormatToString(item, DigitConfig.Int)
            TxtSumTotal.Text = Configuration.FormatToString(amount, DigitConfig.Price)
            txtBankcharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)
            txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)

            Me.m_entity.TotalAmount = Configuration.Format(amount, DigitConfig.Price)
        End Sub
#End Region

#Region " Autogencode "
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
                'Hack: set Code ???? "" ??
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
