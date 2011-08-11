Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.IO
Imports Syncfusion.XlsIO
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptJournalEntryFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel, IExcellExportAble
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
    Friend WithEvents btnAcctEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlyPosted As System.Windows.Forms.CheckBox
    Friend WithEvents btnAcctBookEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookStart As System.Windows.Forms.Label
    Friend WithEvents txtOpenningDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpOpenningDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOpenningDocDateStart As System.Windows.Forms.Label
    Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPVEnd As System.Windows.Forms.Label
    Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPVStart As System.Windows.Forms.Label
    Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblRVStart As System.Windows.Forms.Label
    Friend WithEvents btnRVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblRVEnd As System.Windows.Forms.Label
    Friend WithEvents txtRVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnRVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbOptions As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkShowSumEachAcct As System.Windows.Forms.CheckBox
    Friend WithEvents chkComputeDrCr As System.Windows.Forms.CheckBox
    Friend WithEvents lblGlCode As System.Windows.Forms.Label
    Friend WithEvents lblRefCode As System.Windows.Forms.Label
    Friend WithEvents txtAcctBookCodeprefix As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSaveAsExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRefDocCodePrefix As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptJournalEntryFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblRefCode = New System.Windows.Forms.Label()
      Me.lblGlCode = New System.Windows.Forms.Label()
      Me.txtRefDocCodePrefix = New System.Windows.Forms.TextBox()
      Me.txtAcctBookCodeprefix = New System.Windows.Forms.TextBox()
      Me.grbOptions = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkOnlyPosted = New System.Windows.Forms.CheckBox()
      Me.cmbFormat = New System.Windows.Forms.ComboBox()
      Me.lblFormat = New System.Windows.Forms.Label()
      Me.chkShowSumEachAcct = New System.Windows.Forms.CheckBox()
      Me.chkComputeDrCr = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnAcctBookEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookEnd = New System.Windows.Forms.TextBox()
      Me.lblAcctBookEnd = New System.Windows.Forms.Label()
      Me.btnAcctBookStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookStart = New System.Windows.Forms.TextBox()
      Me.lblAcctBookStart = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnAcctEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAccountEnd = New System.Windows.Forms.Label()
      Me.btnAcctStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAccountStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtOpenningDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpOpenningDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.lblOpenningDocDateStart = New System.Windows.Forms.Label()
      Me.txtPVCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblPVEnd = New System.Windows.Forms.Label()
      Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtPVCodeStart = New System.Windows.Forms.TextBox()
      Me.lblPVStart = New System.Windows.Forms.Label()
      Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtRVCodeStart = New System.Windows.Forms.TextBox()
      Me.lblRVStart = New System.Windows.Forms.Label()
      Me.btnRVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblRVEnd = New System.Windows.Forms.Label()
      Me.txtRVCodeEnd = New System.Windows.Forms.TextBox()
      Me.btnRVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ibtnSaveAsExcel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMaster.SuspendLayout()
      Me.grbOptions.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.ibtnSaveAsExcel)
      Me.grbMaster.Controls.Add(Me.lblRefCode)
      Me.grbMaster.Controls.Add(Me.lblGlCode)
      Me.grbMaster.Controls.Add(Me.txtRefDocCodePrefix)
      Me.grbMaster.Controls.Add(Me.txtAcctBookCodeprefix)
      Me.grbMaster.Controls.Add(Me.grbOptions)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(664, 256)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'lblRefCode
      '
      Me.lblRefCode.Location = New System.Drawing.Point(448, 192)
      Me.lblRefCode.Name = "lblRefCode"
      Me.lblRefCode.Size = New System.Drawing.Size(56, 16)
      Me.lblRefCode.TabIndex = 7
      Me.lblRefCode.Text = "RefCode"
      Me.lblRefCode.Visible = False
      '
      'lblGlCode
      '
      Me.lblGlCode.Location = New System.Drawing.Point(448, 168)
      Me.lblGlCode.Name = "lblGlCode"
      Me.lblGlCode.Size = New System.Drawing.Size(56, 16)
      Me.lblGlCode.TabIndex = 6
      Me.lblGlCode.Text = "GLCode"
      Me.lblGlCode.Visible = False
      '
      'txtRefDocCodePrefix
      '
      Me.Validator.SetDataType(Me.txtRefDocCodePrefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.txtRefDocCodePrefix.Location = New System.Drawing.Point(512, 192)
      Me.Validator.SetMinValue(Me.txtRefDocCodePrefix, "")
      Me.txtRefDocCodePrefix.Name = "txtRefDocCodePrefix"
      Me.Validator.SetRegularExpression(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetRequired(Me.txtRefDocCodePrefix, False)
      Me.txtRefDocCodePrefix.Size = New System.Drawing.Size(100, 21)
      Me.txtRefDocCodePrefix.TabIndex = 5
      Me.txtRefDocCodePrefix.Visible = False
      '
      'txtAcctBookCodeprefix
      '
      Me.Validator.SetDataType(Me.txtAcctBookCodeprefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookCodeprefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookCodeprefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookCodeprefix, System.Drawing.Color.Empty)
      Me.txtAcctBookCodeprefix.Location = New System.Drawing.Point(512, 168)
      Me.Validator.SetMinValue(Me.txtAcctBookCodeprefix, "")
      Me.txtAcctBookCodeprefix.Name = "txtAcctBookCodeprefix"
      Me.Validator.SetRegularExpression(Me.txtAcctBookCodeprefix, "")
      Me.Validator.SetRequired(Me.txtAcctBookCodeprefix, False)
      Me.txtAcctBookCodeprefix.Size = New System.Drawing.Size(100, 21)
      Me.txtAcctBookCodeprefix.TabIndex = 4
      Me.txtAcctBookCodeprefix.Visible = False
      '
      'grbOptions
      '
      Me.grbOptions.Controls.Add(Me.chkOnlyPosted)
      Me.grbOptions.Controls.Add(Me.cmbFormat)
      Me.grbOptions.Controls.Add(Me.lblFormat)
      Me.grbOptions.Controls.Add(Me.chkShowSumEachAcct)
      Me.grbOptions.Controls.Add(Me.chkComputeDrCr)
      Me.grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbOptions.Location = New System.Drawing.Point(432, 16)
      Me.grbOptions.Name = "grbOptions"
      Me.grbOptions.Size = New System.Drawing.Size(224, 144)
      Me.grbOptions.TabIndex = 3
      Me.grbOptions.TabStop = False
      Me.grbOptions.Text = "ตัวเลือกการแสดงผล"
      '
      'chkOnlyPosted
      '
      Me.chkOnlyPosted.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOnlyPosted.Location = New System.Drawing.Point(16, 24)
      Me.chkOnlyPosted.Name = "chkOnlyPosted"
      Me.chkOnlyPosted.Size = New System.Drawing.Size(144, 24)
      Me.chkOnlyPosted.TabIndex = 10
      Me.chkOnlyPosted.Text = "เฉพาะรายการที่ Post แล้ว"
      '
      'cmbFormat
      '
      Me.cmbFormat.Location = New System.Drawing.Point(80, 104)
      Me.cmbFormat.Name = "cmbFormat"
      Me.cmbFormat.Size = New System.Drawing.Size(121, 21)
      Me.cmbFormat.TabIndex = 9
      '
      'lblFormat
      '
      Me.lblFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFormat.ForeColor = System.Drawing.Color.Black
      Me.lblFormat.Location = New System.Drawing.Point(16, 104)
      Me.lblFormat.Name = "lblFormat"
      Me.lblFormat.Size = New System.Drawing.Size(56, 18)
      Me.lblFormat.TabIndex = 6
      Me.lblFormat.Text = "รูปแบบ"
      Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkShowSumEachAcct
      '
      Me.chkShowSumEachAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowSumEachAcct.Location = New System.Drawing.Point(16, 48)
      Me.chkShowSumEachAcct.Name = "chkShowSumEachAcct"
      Me.chkShowSumEachAcct.Size = New System.Drawing.Size(200, 24)
      Me.chkShowSumEachAcct.TabIndex = 10
      Me.chkShowSumEachAcct.Text = "แสดงผลรวมแต่ละหมวดผังบัญชี"
      '
      'chkComputeDrCr
      '
      Me.chkComputeDrCr.Checked = True
      Me.chkComputeDrCr.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkComputeDrCr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkComputeDrCr.Location = New System.Drawing.Point(16, 72)
      Me.chkComputeDrCr.Name = "chkComputeDrCr"
      Me.chkComputeDrCr.Size = New System.Drawing.Size(192, 24)
      Me.chkComputeDrCr.TabIndex = 10
      Me.chkComputeDrCr.Text = "คำนวณผลลัพธ์ยอดเดบิต-เครดิต"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnAcctBookEndFind)
      Me.grbDetail.Controls.Add(Me.txtAcctBookEnd)
      Me.grbDetail.Controls.Add(Me.lblAcctBookEnd)
      Me.grbDetail.Controls.Add(Me.btnAcctBookStartFind)
      Me.grbDetail.Controls.Add(Me.txtAcctBookStart)
      Me.grbDetail.Controls.Add(Me.lblAcctBookStart)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnAcctEndFind)
      Me.grbDetail.Controls.Add(Me.txtAcctCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAccountEnd)
      Me.grbDetail.Controls.Add(Me.btnAcctStartFind)
      Me.grbDetail.Controls.Add(Me.txtAcctCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAccountStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.txtOpenningDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpOpenningDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblOpenningDocDateStart)
      Me.grbDetail.Controls.Add(Me.txtPVCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblPVEnd)
      Me.grbDetail.Controls.Add(Me.btnPVStartFind)
      Me.grbDetail.Controls.Add(Me.txtPVCodeStart)
      Me.grbDetail.Controls.Add(Me.lblPVStart)
      Me.grbDetail.Controls.Add(Me.btnPVEndFind)
      Me.grbDetail.Controls.Add(Me.txtRVCodeStart)
      Me.grbDetail.Controls.Add(Me.lblRVStart)
      Me.grbDetail.Controls.Add(Me.btnRVEndFind)
      Me.grbDetail.Controls.Add(Me.lblRVEnd)
      Me.grbDetail.Controls.Add(Me.txtRVCodeEnd)
      Me.grbDetail.Controls.Add(Me.btnRVStartFind)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(416, 232)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnAcctBookEndFind
      '
      Me.btnAcctBookEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookEndFind.Location = New System.Drawing.Point(376, 96)
      Me.btnAcctBookEndFind.Name = "btnAcctBookEndFind"
      Me.btnAcctBookEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookEndFind.TabIndex = 36
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
      Me.txtAcctBookEnd.Location = New System.Drawing.Point(280, 96)
      Me.Validator.SetMinValue(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Name = "txtAcctBookEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctBookEnd, "")
      Me.Validator.SetRequired(Me.txtAcctBookEnd, False)
      Me.txtAcctBookEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookEnd.TabIndex = 6
      '
      'lblAcctBookEnd
      '
      Me.lblAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookEnd.Location = New System.Drawing.Point(248, 96)
      Me.lblAcctBookEnd.Name = "lblAcctBookEnd"
      Me.lblAcctBookEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAcctBookEnd.TabIndex = 34
      Me.lblAcctBookEnd.Text = "ถึง"
      Me.lblAcctBookEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctBookStartFind
      '
      Me.btnAcctBookStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookStartFind.Location = New System.Drawing.Point(216, 96)
      Me.btnAcctBookStartFind.Name = "btnAcctBookStartFind"
      Me.btnAcctBookStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookStartFind.TabIndex = 33
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
      Me.txtAcctBookStart.Location = New System.Drawing.Point(120, 96)
      Me.Validator.SetMinValue(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Name = "txtAcctBookStart"
      Me.Validator.SetRegularExpression(Me.txtAcctBookStart, "")
      Me.Validator.SetRequired(Me.txtAcctBookStart, False)
      Me.txtAcctBookStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookStart.TabIndex = 5
      '
      'lblAcctBookStart
      '
      Me.lblAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookStart.Location = New System.Drawing.Point(24, 96)
      Me.lblAcctBookStart.Name = "lblAcctBookStart"
      Me.lblAcctBookStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAcctBookStart.TabIndex = 31
      Me.lblAcctBookStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAcctBookStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(64, 192)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(144, 24)
      Me.chkIncludeChildren.TabIndex = 8
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnAcctEndFind
      '
      Me.btnAcctEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctEndFind.Location = New System.Drawing.Point(376, 72)
      Me.btnAcctEndFind.Name = "btnAcctEndFind"
      Me.btnAcctEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctEndFind.TabIndex = 11
      Me.btnAcctEndFind.TabStop = False
      Me.btnAcctEndFind.ThemedImage = CType(resources.GetObject("btnAcctEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctCodeEnd, "")
      Me.txtAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
      Me.txtAcctCodeEnd.Location = New System.Drawing.Point(280, 72)
      Me.txtAcctCodeEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtAcctCodeEnd, "")
      Me.txtAcctCodeEnd.Name = "txtAcctCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAcctCodeEnd, False)
      Me.txtAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctCodeEnd.TabIndex = 4
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(248, 72)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAccountEnd.TabIndex = 9
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctStartFind
      '
      Me.btnAcctStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctStartFind.Location = New System.Drawing.Point(216, 72)
      Me.btnAcctStartFind.Name = "btnAcctStartFind"
      Me.btnAcctStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctStartFind.TabIndex = 8
      Me.btnAcctStartFind.TabStop = False
      Me.btnAcctStartFind.ThemedImage = CType(resources.GetObject("btnAcctStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctCodeStart
      '
      Me.Validator.SetDataType(Me.txtAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctCodeStart, "")
      Me.txtAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
      Me.txtAcctCodeStart.Location = New System.Drawing.Point(120, 72)
      Me.txtAcctCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtAcctCodeStart, "")
      Me.txtAcctCodeStart.Name = "txtAcctCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAcctCodeStart, "")
      Me.Validator.SetRequired(Me.txtAcctCodeStart, False)
      Me.txtAcctCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctCodeStart.TabIndex = 3
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(24, 72)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAccountStart.TabIndex = 6
      Me.lblAccountStart.Text = "ตั้งแต่รหัสบัญชี"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 48)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 48)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 48)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 48)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(24, 48)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 48)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 168)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 8
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 168)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 7
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(32, 168)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(80, 18)
      Me.lblCCStart.TabIndex = 6
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(240, 168)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 7
      '
      'txtOpenningDocDateStart
      '
      Me.Validator.SetDataType(Me.txtOpenningDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtOpenningDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtOpenningDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtOpenningDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtOpenningDocDateStart, System.Drawing.Color.Empty)
      Me.txtOpenningDocDateStart.Location = New System.Drawing.Point(120, 24)
      Me.txtOpenningDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtOpenningDocDateStart, "")
      Me.txtOpenningDocDateStart.Name = "txtOpenningDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtOpenningDocDateStart, "")
      Me.Validator.SetRequired(Me.txtOpenningDocDateStart, False)
      Me.txtOpenningDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtOpenningDocDateStart.TabIndex = 0
      '
      'dtpOpenningDocDateStart
      '
      Me.dtpOpenningDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpOpenningDocDateStart.Location = New System.Drawing.Point(120, 24)
      Me.dtpOpenningDocDateStart.Name = "dtpOpenningDocDateStart"
      Me.dtpOpenningDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpOpenningDocDateStart.TabIndex = 2
      Me.dtpOpenningDocDateStart.TabStop = False
      '
      'lblOpenningDocDateStart
      '
      Me.lblOpenningDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOpenningDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblOpenningDocDateStart.Location = New System.Drawing.Point(8, 24)
      Me.lblOpenningDocDateStart.Name = "lblOpenningDocDateStart"
      Me.lblOpenningDocDateStart.Size = New System.Drawing.Size(104, 18)
      Me.lblOpenningDocDateStart.TabIndex = 0
      Me.lblOpenningDocDateStart.Text = "วันที่เริ่มนับยอดยกมา"
      Me.lblOpenningDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.txtPVCodeEnd.Location = New System.Drawing.Point(280, 120)
      Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
      Me.txtPVCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtPVCodeEnd.TabIndex = 6
      '
      'lblPVEnd
      '
      Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPVEnd.Location = New System.Drawing.Point(248, 120)
      Me.lblPVEnd.Name = "lblPVEnd"
      Me.lblPVEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblPVEnd.TabIndex = 34
      Me.lblPVEnd.Text = "ถึง"
      Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnPVStartFind
      '
      Me.btnPVStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVStartFind.Location = New System.Drawing.Point(216, 120)
      Me.btnPVStartFind.Name = "btnPVStartFind"
      Me.btnPVStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnPVStartFind.TabIndex = 33
      Me.btnPVStartFind.TabStop = False
      Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPVCodeStart
      '
      Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.txtPVCodeStart.Location = New System.Drawing.Point(120, 120)
      Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Name = "txtPVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
      Me.Validator.SetRequired(Me.txtPVCodeStart, False)
      Me.txtPVCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtPVCodeStart.TabIndex = 5
      '
      'lblPVStart
      '
      Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVStart.ForeColor = System.Drawing.Color.Black
      Me.lblPVStart.Location = New System.Drawing.Point(8, 120)
      Me.lblPVStart.Name = "lblPVStart"
      Me.lblPVStart.Size = New System.Drawing.Size(104, 18)
      Me.lblPVStart.TabIndex = 31
      Me.lblPVStart.Text = "ตั้งแต่ใบสำคัญจ่าย"
      Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnPVEndFind
      '
      Me.btnPVEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVEndFind.Location = New System.Drawing.Point(376, 120)
      Me.btnPVEndFind.Name = "btnPVEndFind"
      Me.btnPVEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnPVEndFind.TabIndex = 36
      Me.btnPVEndFind.TabStop = False
      Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtRVCodeStart
      '
      Me.Validator.SetDataType(Me.txtRVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRVCodeStart, "")
      Me.txtRVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRVCodeStart, System.Drawing.Color.Empty)
      Me.txtRVCodeStart.Location = New System.Drawing.Point(120, 144)
      Me.Validator.SetMinValue(Me.txtRVCodeStart, "")
      Me.txtRVCodeStart.Name = "txtRVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtRVCodeStart, "")
      Me.Validator.SetRequired(Me.txtRVCodeStart, False)
      Me.txtRVCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtRVCodeStart.TabIndex = 5
      '
      'lblRVStart
      '
      Me.lblRVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRVStart.ForeColor = System.Drawing.Color.Black
      Me.lblRVStart.Location = New System.Drawing.Point(24, 144)
      Me.lblRVStart.Name = "lblRVStart"
      Me.lblRVStart.Size = New System.Drawing.Size(88, 18)
      Me.lblRVStart.TabIndex = 31
      Me.lblRVStart.Text = "ตั้งแต่ใบสำคัญรับ"
      Me.lblRVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnRVEndFind
      '
      Me.btnRVEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRVEndFind.Location = New System.Drawing.Point(376, 144)
      Me.btnRVEndFind.Name = "btnRVEndFind"
      Me.btnRVEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnRVEndFind.TabIndex = 36
      Me.btnRVEndFind.TabStop = False
      Me.btnRVEndFind.ThemedImage = CType(resources.GetObject("btnRVEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblRVEnd
      '
      Me.lblRVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblRVEnd.Location = New System.Drawing.Point(248, 144)
      Me.lblRVEnd.Name = "lblRVEnd"
      Me.lblRVEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblRVEnd.TabIndex = 34
      Me.lblRVEnd.Text = "ถึง"
      Me.lblRVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtRVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtRVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRVCodeEnd, "")
      Me.txtRVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRVCodeEnd, System.Drawing.Color.Empty)
      Me.txtRVCodeEnd.Location = New System.Drawing.Point(280, 144)
      Me.Validator.SetMinValue(Me.txtRVCodeEnd, "")
      Me.txtRVCodeEnd.Name = "txtRVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtRVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtRVCodeEnd, False)
      Me.txtRVCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtRVCodeEnd.TabIndex = 6
      '
      'btnRVStartFind
      '
      Me.btnRVStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnRVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnRVStartFind.Location = New System.Drawing.Point(216, 144)
      Me.btnRVStartFind.Name = "btnRVStartFind"
      Me.btnRVStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnRVStartFind.TabIndex = 33
      Me.btnRVStartFind.TabStop = False
      Me.btnRVStartFind.ThemedImage = CType(resources.GetObject("btnRVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(572, 224)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(492, 224)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
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
      'ibtnSaveAsExcel
      '
      Me.ibtnSaveAsExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSaveAsExcel.Location = New System.Drawing.Point(448, 223)
      Me.ibtnSaveAsExcel.Name = "ibtnSaveAsExcel"
      Me.ibtnSaveAsExcel.Size = New System.Drawing.Size(24, 24)
      Me.ibtnSaveAsExcel.TabIndex = 18
      Me.ibtnSaveAsExcel.TabStop = False
      Me.ibtnSaveAsExcel.ThemedImage = CType(resources.GetObject("ibtnSaveAsExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'RptJournalEntryFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptJournalEntryFilterSubPanel"
      Me.Size = New System.Drawing.Size(758, 272)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbOptions.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblAccountStart}")
      Me.Validator.SetDisplayName(txtAcctCodeStart, lblAccountStart.Text)

      Me.lblAcctBookStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblAcctBookStart}")
      Me.Validator.SetDisplayName(txtAcctBookStart, lblAcctBookStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblOpenningDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblOpenningDocDateStart}")
      Me.Validator.SetDisplayName(txtOpenningDocDateStart, lblOpenningDocDateStart.Text)

      Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblPVStart}")
      Me.Validator.SetDisplayName(txtPVCodeStart, lblPVStart.Text)

      Me.lblRVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblRVStart}")
      Me.Validator.SetDisplayName(txtRVCodeStart, lblRVStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkIncludeChildren}")
      ' Global {ถึง}
      Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAcctCodeEnd, lblAccountEnd.Text)

      Me.lblAcctBookEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAcctBookEnd, lblAcctBookEnd.Text)

      Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtPVCodeEnd, lblPVEnd.Text)

      Me.lblRVEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtRVCodeEnd, lblRVEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbDetail}")
      Me.grbOptions.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.grbOptions}")

      Me.lblFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.lblFormat}")
      'Checkbox
      Me.chkOnlyPosted.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkOnlyPosted}")
      Me.chkShowSumEachAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkShowSumEachAcct}")
      Me.chkComputeDrCr.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryFilterSubPanel.chkComputeDrCr}")
    End Sub
#End Region

#Region "Member"
    Private m_format As JournalEntryFilterOrderBy

    Private m_OpenningDocDateStart As Date
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      m_cc = New CostCenter
      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Private Property Format() As CodeDescription
      Get
        Return m_format
      End Get
      Set(ByVal Value As CodeDescription)
        m_format = CType(Value, JournalEntryFilterOrderBy)
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property OpenningDocDateStart() As Date      Get        Return m_OpenningDocDateStart      End Get      Set(ByVal Value As Date)        m_OpenningDocDateStart = Value      End Set    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' รูปแบบ
      JournalEntryFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbFormat, "rpt_journalentryfilter")
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

      Dim dtOpenningDocDateStart As Date = DateAdd(DateInterval.Year, DateDiff(DateInterval.Year, Date.MinValue, Today()), Date.MinValue)
      Me.OpenningDocDateStart = dtOpenningDocDateStart
      Me.txtOpenningDocDateStart.Text = MinDateToNull(Me.OpenningDocDateStart, "")
      Me.dtpOpenningDocDateStart.Value = Me.OpenningDocDateStart

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.cmbFormat.SelectedIndex = 0

      Me.chkShowSumEachAcct.Checked = False
      Me.chkComputeDrCr.Checked = True
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(19) As Filter
      arr(0) = New Filter("OpenningDocDateStart", IIf(Me.OpenningDocDateStart.Equals(Date.MinValue), DBNull.Value, Me.OpenningDocDateStart))
      arr(1) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(3) = New Filter("AcctCodeStart", IIf(txtAcctCodeStart.TextLength > 0, txtAcctCodeStart.Text, DBNull.Value))
      arr(4) = New Filter("AcctCodeEnd", IIf(txtAcctCodeEnd.TextLength > 0, txtAcctCodeEnd.Text, DBNull.Value))
      arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(6) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(7) = New Filter("Format", JournalEntryFilterOrderBy.GetValue("rpt_journalentryfilter", cmbFormat.Text))
      arr(8) = New Filter("OnlyPosted", Me.chkOnlyPosted.Checked)
      arr(9) = New Filter("AcctBookCodeStart", IIf(txtAcctBookStart.TextLength > 0, txtAcctBookStart.Text, DBNull.Value))
      arr(10) = New Filter("AcctBookCodeEnd", IIf(txtAcctBookEnd.TextLength > 0, txtAcctBookEnd.Text, DBNull.Value))
      arr(11) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
      arr(12) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
      arr(13) = New Filter("RVCodeStart", IIf(txtRVCodeStart.TextLength > 0, txtRVCodeStart.Text, DBNull.Value))
      arr(14) = New Filter("RVCodeEnd", IIf(txtRVCodeEnd.TextLength > 0, txtRVCodeEnd.Text, DBNull.Value))
      arr(15) = New Filter("ShowSumEachAcct", Me.chkShowSumEachAcct.Checked)
      arr(16) = New Filter("ComputeDrCr", Me.chkComputeDrCr.Checked)
      arr(17) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(18) = New Filter("AcctBookCodeprefix", IIf(txtAcctBookCodeprefix.TextLength > 0, txtAcctBookCodeprefix.Text, DBNull.Value))
      arr(19) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))
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

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = "" ' Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = "" 'Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'format
      dpi = New DocPrintingItem
      dpi.Mapping = "format"
      dpi.Value = Me.cmbFormat.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'OpenningDocdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "openningdocdatestart"
      dpi.Value = Me.txtOpenningDocDateStart.Text
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

      'account start
      dpi = New DocPrintingItem
      dpi.Mapping = "accountstart"
      dpi.Value = Me.txtAcctCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'account end
      dpi = New DocPrintingItem
      dpi.Mapping = "accountend"
      dpi.Value = Me.txtAcctCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountBookStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookStart"
      dpi.Value = Me.txtAcctBookStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountBookEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookEnd"
      dpi.Value = Me.txtAcctBookEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PVStart
      dpi = New DocPrintingItem
      dpi.Mapping = "PVStart"
      dpi.Value = Me.txtPVCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PVEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "PVEnd"
      dpi.Value = Me.txtPVCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RVStart
      dpi = New DocPrintingItem
      dpi.Mapping = "RVStart"
      dpi.Value = Me.txtRVCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RVEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "RVEnd"
      dpi.Value = Me.txtRVCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'costcenter start
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterstart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AcctBookCodeprefix
      dpi = New DocPrintingItem
      dpi.Mapping = "AcctBookCodeprefix"
      dpi.Value = Me.txtAcctBookCodeprefix.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'RefDocCodePrefix 
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDocCodePrefix"
      dpi.Value = Me.txtRefDocCodePrefix.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Me.chkIncludeChildren.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childincluded"
        dpi.Value = "(รวมในสังกัด)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If
      ''costcenter end
      'dpi = New DocPrintingItem
      'dpi.Mapping = "costcenterend"
      'dpi.Value = Me.txtCCCodeEnd.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnAcctStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler btnAcctEndFind.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAcctBookStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnAcctBookEndFind.Click, AddressOf Me.btnAccountBookFind_Click

      AddHandler btnPVStartFind.Click, AddressOf Me.btnPVFind_Click
      AddHandler btnPVEndFind.Click, AddressOf Me.btnPVFind_Click

      AddHandler btnRVStartFind.Click, AddressOf Me.btnRVFind_Click
      AddHandler btnRVEndFind.Click, AddressOf Me.btnRVFind_Click

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtOpenningDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpOpenningDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          CostCenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "dtpopenningdocdatestart"
          If Not Me.OpenningDocDateStart.Equals(dtpOpenningDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtOpenningDocDateStart.Text = MinDateToNull(dtpOpenningDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.OpenningDocDateStart = dtpOpenningDocDateStart.Value
            End If
          End If
        Case "txtopenningdocdatestart"
          m_dateSetting = True
          If Not Me.txtOpenningDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtOpenningDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtOpenningDocDateStart.Text)
            If Not Me.OpenningDocDateStart.Equals(theDate) Then
              dtpOpenningDocDateStart.Value = theDate
              Me.OpenningDocDateStart = dtpOpenningDocDateStart.Value
            End If
          Else
            Me.dtpOpenningDocDateStart.Value = Date.Now
            Me.OpenningDocDateStart = Date.MinValue
          End If
          m_dateSetting = False
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

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Account
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtacctcodestart", "txtacctcodeend"
                Return True
            End Select
          End If
        End If
        'AccountBook
        If data.GetDataPresent((New AccountBook).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtacctbookstart", "txtacctbookend"
                Return True
            End Select
          End If
        End If
        ' costcenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart", "txtcccodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' account
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtacctcodestart"
              Me.SetAccountStartDialog(entity)

            Case "txtacctcodeend"
              Me.SetAccountEndDialog(entity)

          End Select
        End If
      End If
      ' account book
      If data.GetDataPresent((New AccountBook).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AccountBook).FullClassName))
        Dim entity As New AccountBook(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtacctbookstart"
              Me.SetAccountBookStartDialog(entity)

            Case "txtacctbookend"
              Me.SetAccountBookEndDialog(entity)

          End Select
        End If
      End If
      ' costcenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCostcenterStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    ' account
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctstartfind"
          myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountStartDialog)

        Case "btnacctendfind"
          myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountEndDialog)

      End Select
    End Sub
    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctbookstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookStartDialog)

        Case "btnacctbookendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookEndDialog)

      End Select
    End Sub
    Private Sub btnPVFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnpvstartfind"
          myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVStartDialog)

        Case "btnpvendfind"
          myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVEndDialog)

      End Select
    End Sub
    Private Sub btnRVFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnrvstartfind"
          myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVStartDialog)

        Case "btnrvendfind"
          myEntityPanelService.OpenListDialog(New Receive, AddressOf SetRVEndDialog)

      End Select
    End Sub
    Private Sub SetAccountStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctCodeStart.Text = e.Code
    End Sub
    Private Sub SetAccountEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctCodeEnd.Text = e.Code
    End Sub
    Private Sub SetAccountBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookStart.Text = e.Code
    End Sub
    Private Sub SetAccountBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookEnd.Text = e.Code
    End Sub
    Private Sub SetPVStartDialog(ByVal e As ISimpleEntity)
      Me.txtPVCodeStart.Text = e.Code
    End Sub
    Private Sub SetPVEndDialog(ByVal e As ISimpleEntity)
      Me.txtPVCodeEnd.Text = e.Code
    End Sub
    Private Sub SetRVStartDialog(ByVal e As ISimpleEntity)
      Me.txtRVCodeStart.Text = e.Code
    End Sub
    Private Sub SetRVEndDialog(ByVal e As ISimpleEntity)
      Me.txtRVCodeEnd.Text = e.Code
    End Sub
    ' costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterStartDialog)
    End Sub
    Private Sub SetCostcenterStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

#Region "Export Excel"

    Private m_tgItem As LKGrid
    Public Property tgItem As Components.LKGrid Implements IExcellExportAble.tgItem
      Get
        Return m_tgItem
      End Get
      Set(ByVal value As Components.LKGrid)
        m_tgItem = value
      End Set
    End Property
    Public Sub xlsexport()
      Dim xl As ExcelEngine = New ExcelEngine()
      Dim dialog1 As SaveFileDialog = New SaveFileDialog
      Dim ctime As Date

      ctime = IIf(Me.DocDateEnd.Equals(Date.MinValue), Date.Now, Me.DocDateEnd)
      Dim filename As String = "Export " & "RptJournalEntry" & ctime.ToString("yyyyMMdd") & ".xls"
      dialog1.OverwritePrompt = True
      dialog1.AddExtension = True
      dialog1.Filter = "Microsoft Excel (*.xls)|*.xls|All files|*.*"
      dialog1.FileName = filename
      If dialog1.ShowDialog = DialogResult.OK Then
        filename = dialog1.FileName
      Else
        Return
      End If

      Using xl
        'instantiate excel application object
        Dim xlApp As IApplication = xl.Excel


        'create a new workbook with 2 worksheets
        Dim wkbk As IWorkbook = xl.Excel.Workbooks.Create(1)


        'get a reference to both worksheets
        Dim sht1 As IWorksheet = wkbk.Worksheets(0)
     

        wkbk.Worksheets(0).Name = "RptJournalEntry"
       

        'add data to the first cell of each worksheet
        'sht1.Range("A1").Text = "Hello World"
        'sht2.Range("A1").Text = "Hello World 2"

        For i As Integer = 2 To tgItem.RowCount
          For j As Integer = 1 To tgItem.ColCount
            If tgItem(i, j).Text.Length > 0 AndAlso Configuration.IsFormatString(tgItem(i, j).Text, DigitConfig.Price) Then
              Replace(tgItem(i, j).Text, "(", "")
              Replace(tgItem(i, j).Text, ")", "")
              sht1.Range(i, j).Value = CDec(tgItem(i, j).Text)
            Else
              sht1.Range(i, j).Text = tgItem(i, j).Text

            End If
          Next
        Next

        'For i As Integer = 2 To m_GridList(1).RowCount
        '  For j As Integer = 1 To m_GridList(1).ColCount
        '    sht2.Range(i, j).Text = m_GridList(1)(i, j).Text
        '  Next
        'Next

        'For i As Integer = 2 To m_GridList(2).RowCount
        '  For j As Integer = 1 To m_GridList(2).ColCount
        '    sht3.Range(i, j).Text = m_GridList(2)(i, j).Text
        '  Next
        'Next

        'For i As Integer = 2 To m_GridList(3).RowCount
        '  For j As Integer = 1 To m_GridList(3).ColCount
        '    sht4.Range(i, j).Text = m_GridList(3)(i, j).Text
        '  Next
        'Next

        wkbk.SaveAs(filename)
        wkbk.Close()
      End Using
      MessageBox.Show("Finish!")

    End Sub
    Private Sub ibtnSaveAsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSaveAsExcel.Click
      Try
        xlsexport()

        '  Dim Excel As Object = CreateObject("Excel.Application")
        '  If Excel Is Nothing Then
        '    MessageBox.Show("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.")
        '    Return
        '  End If
        '  Dim locale As String = "en-US"
        '  Dim obj As Object = Configuration.GetConfig("ExcelLocale")
        '  If IsDBNull(obj) AndAlso obj <> Nothing Then
        '    locale = obj.ToString()
        '  End If
        '  Dim oldCI As System.Globalization.CultureInfo = _
        '  System.Threading.Thread.CurrentThread.CurrentCulture
        '  System.Threading.Thread.CurrentThread.CurrentCulture = _
        '      New System.Globalization.CultureInfo(locale)

        '  Dim ext As String = ".xlsx"
        '  If CInt(Excel.Version) < 12 Then
        '    ext = ".xls"
        '  End If

        '  Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        '  Dim thePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQItems" & ext
        '  thePath = Microsoft.VisualBasic.InputBox("เลือก path", "เลือก path", thePath)
        '  If thePath.Length = 0 Then
        '    thePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQItems" & ext
        '  End If

        '  With Excel
        '    .SheetsInNewWorkbook = 1
        '    Dim oDoc As Object = .Workbooks.Add()
        '    .Worksheets(1).Select()

        '    Dim i As Integer = 1
        '    For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '      .cells(1, i).value = col.HeaderText.Replace("@", "UnitPrice")
        '      .cells(1, i).EntireRow.Font.Bold = True
        '      i += 1
        '    Next
        '    i = 2
        '    For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        '      Dim j As Integer = 1
        '      For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '        If Not row.IsNull(col.MappingName) Then
        '          If TypeOf col Is DataGridComboColumn Then
        '            .Cells(i, j).Value = New BOQItemType(row(col.MappingName)).Description
        '          Else
        '            .Cells(i, j).Value = row(col.MappingName).ToString()
        '          End If
        '        End If
        '        j += 1
        '      Next
        '      i += 1
        '    Next
        '    .ActiveCell.Worksheet.SaveAs(thePath)

        '    oDoc.Close()
        '    .Quit()
        '    oDoc = Nothing
        '    Excel = Nothing
        '  End With


        '  MessageBox.Show("Items are exported to Excel Succesfully in '" & thePath & "'")
        '  System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

      ' '' The excel is created and opened for insert value. We most close this excel using this system
      ''Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
      ''For Each i As Process In pro
      ''  i.Kill()
      ''Next

    End Sub
#End Region

   

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If tgItem Is Nothing Then
        Return
      End If
      Dim c As Integer = tgItem.ColCount
      MessageBox.Show(c.ToString)
    End Sub
  End Class

  ' เรียงตาม 
  Public Class JournalEntryFilterOrderBy
    Inherits CodeDescription

#Region "Construtors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "rpt_journalentryfilter"
      End Get
    End Property
#End Region

  End Class
End Namespace

