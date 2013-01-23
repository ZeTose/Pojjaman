Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PRPanelView
        'Inherits UserControl
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          'Clear the memory
          Me.m_entity = Nothing
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents dtpReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivingDate As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivingDate As System.Windows.Forms.TextBox
    Friend WithEvents btnRequestorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnRequestorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblStoreApprove As System.Windows.Forms.Label
    Friend WithEvents btnApproveStore As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit2 As System.Windows.Forms.Label
    Friend WithEvents txtUnit1 As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit1 As System.Windows.Forms.Label
    Friend WithEvents txtUnit2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLanguage As System.Windows.Forms.TextBox
    Friend WithEvents imAttachment As System.Windows.Forms.PictureBox
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRPanelView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblRate = New System.Windows.Forms.Label()
            Me.lblLanguage = New System.Windows.Forms.Label()
            Me.txtRate = New System.Windows.Forms.TextBox()
            Me.lblUnit2 = New System.Windows.Forms.Label()
            Me.txtUnit1 = New System.Windows.Forms.TextBox()
            Me.lblUnit1 = New System.Windows.Forms.Label()
            Me.txtUnit2 = New System.Windows.Forms.TextBox()
            Me.txtLanguage = New System.Windows.Forms.TextBox()
            Me.chkClosed = New System.Windows.Forms.CheckBox()
            Me.btnApproveStore = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblStoreApprove = New System.Windows.Forms.Label()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblGross = New System.Windows.Forms.Label()
            Me.txtGross = New System.Windows.Forms.TextBox()
            Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.txtReceivingDate = New System.Windows.Forms.TextBox()
            Me.txtDocDate = New System.Windows.Forms.TextBox()
            Me.btnRequestorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnRequestorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtRequestorName = New System.Windows.Forms.TextBox()
            Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtRequestorCode = New System.Windows.Forms.TextBox()
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.dtpReceivingDate = New System.Windows.Forms.DateTimePicker()
            Me.lblReceivingDate = New System.Windows.Forms.Label()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.lblRequestor = New System.Windows.Forms.Label()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.imAttachment = New System.Windows.Forms.PictureBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.FixedGroupBox1.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.imAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.FixedGroupBox1)
            Me.grbDetail.Controls.Add(Me.chkClosed)
            Me.grbDetail.Controls.Add(Me.btnApproveStore)
            Me.grbDetail.Controls.Add(Me.lblStoreApprove)
            Me.grbDetail.Controls.Add(Me.cmbCode)
            Me.grbDetail.Controls.Add(Me.btnApprove)
            Me.grbDetail.Controls.Add(Me.lblGross)
            Me.grbDetail.Controls.Add(Me.txtGross)
            Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
            Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.lblStatus)
            Me.grbDetail.Controls.Add(Me.txtReceivingDate)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.btnRequestorEdit)
            Me.grbDetail.Controls.Add(Me.btnRequestorFind)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtRequestorName)
            Me.grbDetail.Controls.Add(Me.btnCCEdit)
            Me.grbDetail.Controls.Add(Me.btnCCFind)
            Me.grbDetail.Controls.Add(Me.txtRequestorCode)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.Controls.Add(Me.dtpReceivingDate)
            Me.grbDetail.Controls.Add(Me.lblReceivingDate)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblRequestor)
            Me.grbDetail.Controls.Add(Me.lblCostCenter)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
            Me.grbDetail.Controls.Add(Me.lblItem)
            Me.grbDetail.Controls.Add(Me.ibtnBlank)
            Me.grbDetail.Controls.Add(Me.dtpDocDate)
            Me.grbDetail.Controls.Add(Me.ibtnDelRow)
            Me.grbDetail.Controls.Add(Me.imAttachment)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 4)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(914, 509)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด:"
            '
            'FixedGroupBox1
            '
            Me.FixedGroupBox1.Controls.Add(Me.lblRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblLanguage)
            Me.FixedGroupBox1.Controls.Add(Me.txtRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtLanguage)
            Me.FixedGroupBox1.Location = New System.Drawing.Point(605, 90)
            Me.FixedGroupBox1.Name = "FixedGroupBox1"
            Me.FixedGroupBox1.Size = New System.Drawing.Size(280, 64)
            Me.FixedGroupBox1.TabIndex = 344
            Me.FixedGroupBox1.TabStop = False
            Me.FixedGroupBox1.Text = "Currency"
            Me.FixedGroupBox1.Visible = False
            '
            'lblRate
            '
            Me.lblRate.BackColor = System.Drawing.Color.Transparent
            Me.lblRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRate.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRate.Location = New System.Drawing.Point(6, 14)
            Me.lblRate.Name = "lblRate"
            Me.lblRate.Size = New System.Drawing.Size(62, 18)
            Me.lblRate.TabIndex = 342
            Me.lblRate.Text = "Rate"
            Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLanguage
            '
            Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
            Me.lblLanguage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLanguage.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLanguage.Location = New System.Drawing.Point(210, 15)
            Me.lblLanguage.Name = "lblLanguage"
            Me.lblLanguage.Size = New System.Drawing.Size(62, 18)
            Me.lblLanguage.TabIndex = 342
            Me.lblLanguage.Text = "Language"
            Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtRate
            '
            Me.Validator.SetDataType(Me.txtRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.txtRate.Location = New System.Drawing.Point(6, 35)
            Me.Validator.SetMinValue(Me.txtRate, "")
            Me.txtRate.Name = "txtRate"
            Me.Validator.SetRegularExpression(Me.txtRate, "")
            Me.Validator.SetRequired(Me.txtRate, False)
            Me.txtRate.Size = New System.Drawing.Size(62, 21)
            Me.txtRate.TabIndex = 341
            Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblUnit2
            '
            Me.lblUnit2.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit2.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit2.Location = New System.Drawing.Point(142, 15)
            Me.lblUnit2.Name = "lblUnit2"
            Me.lblUnit2.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit2.TabIndex = 342
            Me.lblUnit2.Text = "Unit2"
            Me.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtUnit1
            '
            Me.Validator.SetDataType(Me.txtUnit1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit1, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.txtUnit1.Location = New System.Drawing.Point(74, 35)
            Me.Validator.SetMinValue(Me.txtUnit1, "")
            Me.txtUnit1.Name = "txtUnit1"
            Me.Validator.SetRegularExpression(Me.txtUnit1, "")
            Me.Validator.SetRequired(Me.txtUnit1, False)
            Me.txtUnit1.Size = New System.Drawing.Size(62, 21)
            Me.txtUnit1.TabIndex = 341
            '
            'lblUnit1
            '
            Me.lblUnit1.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit1.Location = New System.Drawing.Point(74, 15)
            Me.lblUnit1.Name = "lblUnit1"
            Me.lblUnit1.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit1.TabIndex = 342
            Me.lblUnit1.Text = "Unit1"
            Me.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtUnit2
            '
            Me.Validator.SetDataType(Me.txtUnit2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit2, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.txtUnit2.Location = New System.Drawing.Point(142, 35)
            Me.Validator.SetMinValue(Me.txtUnit2, "")
            Me.txtUnit2.Name = "txtUnit2"
            Me.Validator.SetRegularExpression(Me.txtUnit2, "")
            Me.Validator.SetRequired(Me.txtUnit2, False)
            Me.txtUnit2.Size = New System.Drawing.Size(62, 21)
            Me.txtUnit2.TabIndex = 341
            '
            'txtLanguage
            '
            Me.Validator.SetDataType(Me.txtLanguage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLanguage, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.txtLanguage.Location = New System.Drawing.Point(210, 35)
            Me.Validator.SetMinValue(Me.txtLanguage, "")
            Me.txtLanguage.Name = "txtLanguage"
            Me.Validator.SetRegularExpression(Me.txtLanguage, "")
            Me.Validator.SetRequired(Me.txtLanguage, False)
            Me.txtLanguage.Size = New System.Drawing.Size(62, 21)
            Me.txtLanguage.TabIndex = 341
            '
            'chkClosed
            '
            Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkClosed.Location = New System.Drawing.Point(544, 16)
            Me.chkClosed.Name = "chkClosed"
            Me.chkClosed.Size = New System.Drawing.Size(80, 24)
            Me.chkClosed.TabIndex = 335
            Me.chkClosed.Text = "ปิด PR"
            Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnApproveStore
            '
            Me.btnApproveStore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnApproveStore.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnApproveStore.ForeColor = System.Drawing.Color.Black
            Me.btnApproveStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnApproveStore.Location = New System.Drawing.Point(786, 56)
            Me.btnApproveStore.Name = "btnApproveStore"
            Me.btnApproveStore.Size = New System.Drawing.Size(120, 24)
            Me.btnApproveStore.TabIndex = 334
            Me.btnApproveStore.Text = "ตรวจสอบโดยคลัง"
            Me.btnApproveStore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnApproveStore.ThemedImage = CType(resources.GetObject("btnApproveStore.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblStoreApprove
            '
            Me.lblStoreApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStoreApprove.Location = New System.Drawing.Point(786, 56)
            Me.lblStoreApprove.Name = "lblStoreApprove"
            Me.lblStoreApprove.Size = New System.Drawing.Size(120, 40)
            Me.lblStoreApprove.TabIndex = 333
            Me.lblStoreApprove.Text = "Store Approve แล้ว จริงๆนะ"
            Me.lblStoreApprove.Visible = False
            '
            'cmbCode
            '
            Me.cmbCode.Location = New System.Drawing.Point(120, 16)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(120, 21)
            Me.cmbCode.TabIndex = 332
            '
            'btnApprove
            '
            Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnApprove.ForeColor = System.Drawing.Color.Black
            Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnApprove.Location = New System.Drawing.Point(786, 16)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(120, 24)
            Me.btnApprove.TabIndex = 331
            Me.btnApprove.Text = "อนุมัติเอกสาร"
            Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblGross
            '
            Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGross.BackColor = System.Drawing.Color.Transparent
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblGross.Location = New System.Drawing.Point(688, 481)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(80, 18)
            Me.lblGross.TabIndex = 329
            Me.lblGross.Text = "ยอดเงินรวม :"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGross
            '
            Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtGross.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(770, 481)
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(136, 21)
            Me.txtGross.TabIndex = 328
            Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'ibtnCopyMe
            '
            Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCopyMe.Location = New System.Drawing.Point(264, 16)
            Me.ibtnCopyMe.Name = "ibtnCopyMe"
            Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCopyMe.TabIndex = 326
            Me.ibtnCopyMe.TabStop = False
            Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnGetFromBOQ
            '
            Me.ibtnGetFromBOQ.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnGetFromBOQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(120, 157)
            Me.ibtnGetFromBOQ.Name = "ibtnGetFromBOQ"
            Me.ibtnGetFromBOQ.Size = New System.Drawing.Size(48, 24)
            Me.ibtnGetFromBOQ.TabIndex = 325
            Me.ibtnGetFromBOQ.TabStop = False
            Me.ibtnGetFromBOQ.Text = "BOQ"
            Me.ibtnGetFromBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ibtnGetFromBOQ.ThemedImage = CType(resources.GetObject("ibtnGetFromBOQ.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnGetFromBOQ, "BOQ")
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 320
            Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblStatus.Location = New System.Drawing.Point(264, 160)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(38, 13)
            Me.lblStatus.TabIndex = 205
            Me.lblStatus.Text = "Status"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtReceivingDate
            '
            Me.Validator.SetDataType(Me.txtReceivingDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceivingDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceivingDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceivingDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceivingDate, System.Drawing.Color.Empty)
            Me.txtReceivingDate.Location = New System.Drawing.Point(120, 40)
            Me.Validator.SetMinValue(Me.txtReceivingDate, "")
            Me.txtReceivingDate.Name = "txtReceivingDate"
            Me.Validator.SetRegularExpression(Me.txtReceivingDate, "")
            Me.Validator.SetRequired(Me.txtReceivingDate, True)
            Me.txtReceivingDate.Size = New System.Drawing.Size(120, 21)
            Me.txtReceivingDate.TabIndex = 2
            '
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(392, 16)
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(115, 21)
            Me.txtDocDate.TabIndex = 1
            '
            'btnRequestorEdit
            '
            Me.btnRequestorEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnRequestorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRequestorEdit.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRequestorEdit.Location = New System.Drawing.Point(560, 88)
            Me.btnRequestorEdit.Name = "btnRequestorEdit"
            Me.btnRequestorEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRequestorEdit.TabIndex = 203
            Me.btnRequestorEdit.TabStop = False
            Me.btnRequestorEdit.ThemedImage = CType(resources.GetObject("btnRequestorEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRequestorFind
            '
            Me.btnRequestorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnRequestorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRequestorFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRequestorFind.Location = New System.Drawing.Point(536, 88)
            Me.btnRequestorFind.Name = "btnRequestorFind"
            Me.btnRequestorFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRequestorFind.TabIndex = 201
            Me.btnRequestorFind.TabStop = False
            Me.btnRequestorFind.ThemedImage = CType(resources.GetObject("btnRequestorFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCostCenterName
            '
            Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(264, 64)
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(272, 21)
            Me.txtCostCenterName.TabIndex = 198
            Me.txtCostCenterName.TabStop = False
            '
            'txtRequestorName
            '
            Me.txtRequestorName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtRequestorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.txtRequestorName.Location = New System.Drawing.Point(264, 88)
            Me.Validator.SetMinValue(Me.txtRequestorName, "")
            Me.txtRequestorName.Name = "txtRequestorName"
            Me.txtRequestorName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
            Me.Validator.SetRequired(Me.txtRequestorName, False)
            Me.txtRequestorName.Size = New System.Drawing.Size(272, 21)
            Me.txtRequestorName.TabIndex = 199
            Me.txtRequestorName.TabStop = False
            '
            'btnCCEdit
            '
            Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCEdit.Location = New System.Drawing.Point(560, 64)
            Me.btnCCEdit.Name = "btnCCEdit"
            Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCCEdit.TabIndex = 202
            Me.btnCCEdit.TabStop = False
            Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCCFind
            '
            Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCFind.Location = New System.Drawing.Point(536, 64)
            Me.btnCCFind.Name = "btnCCFind"
            Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCCFind.TabIndex = 200
            Me.btnCCFind.TabStop = False
            Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtRequestorCode
            '
            Me.Validator.SetDataType(Me.txtRequestorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRequestorCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.txtRequestorCode.Location = New System.Drawing.Point(120, 88)
            Me.Validator.SetMinValue(Me.txtRequestorCode, "")
            Me.txtRequestorCode.Name = "txtRequestorCode"
            Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
            Me.Validator.SetRequired(Me.txtRequestorCode, False)
            Me.txtRequestorCode.Size = New System.Drawing.Size(144, 21)
            Me.txtRequestorCode.TabIndex = 4
            '
            'tgItem
            '
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(11, 184)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(895, 291)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 6
            Me.tgItem.TreeManager = Nothing
            '
            'dtpReceivingDate
            '
            Me.dtpReceivingDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpReceivingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpReceivingDate.Location = New System.Drawing.Point(120, 40)
            Me.dtpReceivingDate.Name = "dtpReceivingDate"
            Me.dtpReceivingDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpReceivingDate.TabIndex = 165
            Me.dtpReceivingDate.TabStop = False
            '
            'lblReceivingDate
            '
            Me.lblReceivingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceivingDate.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblReceivingDate.Location = New System.Drawing.Point(8, 40)
            Me.lblReceivingDate.Name = "lblReceivingDate"
            Me.lblReceivingDate.Size = New System.Drawing.Size(112, 18)
            Me.lblReceivingDate.TabIndex = 173
            Me.lblReceivingDate.Text = "วันรับของ"
            Me.lblReceivingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblDocDate.Location = New System.Drawing.Point(296, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDate.TabIndex = 172
            Me.lblDocDate.Text = "วันที่:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 18)
            Me.lblCode.TabIndex = 171
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRequestor
            '
            Me.lblRequestor.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRequestor.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRequestor.Location = New System.Drawing.Point(8, 88)
            Me.lblRequestor.Name = "lblRequestor"
            Me.lblRequestor.Size = New System.Drawing.Size(112, 18)
            Me.lblRequestor.TabIndex = 174
            Me.lblRequestor.Text = "ผู้ขอ:"
            Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCostCenter.Location = New System.Drawing.Point(8, 64)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(112, 18)
            Me.lblCostCenter.TabIndex = 175
            Me.lblCostCenter.Text = "CostCenter:"
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(120, 112)
            Me.txtNote.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtNote.Size = New System.Drawing.Size(464, 42)
            Me.txtNote.TabIndex = 5
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblNote.Location = New System.Drawing.Point(8, 112)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(112, 18)
            Me.lblNote.TabIndex = 176
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(120, 64)
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, False)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(144, 21)
            Me.txtCostCenterCode.TabIndex = 3
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblItem.Location = New System.Drawing.Point(24, 156)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(88, 24)
            Me.lblItem.TabIndex = 173
            Me.lblItem.Text = "รายการขอซื้อ"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(192, 157)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 204
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(392, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 164
            Me.dtpDocDate.TabStop = False
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 157)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 204
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
            '
            'imAttachment
            '
            Me.imAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imAttachment.Location = New System.Drawing.Point(750, 16)
            Me.imAttachment.Name = "imAttachment"
            Me.imAttachment.Size = New System.Drawing.Size(29, 31)
            Me.imAttachment.TabIndex = 345
            Me.imAttachment.TabStop = False
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
            'PRPanelView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "PRPanelView"
            Me.Size = New System.Drawing.Size(930, 520)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            Me.FixedGroupBox1.ResumeLayout(False)
            Me.FixedGroupBox1.PerformLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.imAttachment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
    Private m_entity As PR
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private dummyCC As New CostCenter
    Private dummyEmployee As New Employee

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")

      Me.imAttachment.Image = My.Resources.Attachment_24

      SaveEnableState()

      Dim dt As TreeTable = PR.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf PRItemDelete

      EventWiring()
      SetCCCodeBlankFlag()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PR"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "pri_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "pri_linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("pri_entityType" _
      , CodeDescription.GetCodeList("stocki_enitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.TypeHeaderText}")
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim cspri_itemName As New TreeTextColumn
      cspri_itemName.MappingName = "pri_itemName"
      cspri_itemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.DescriptionHeaderText}")
      cspri_itemName.NullText = ""
      cspri_itemName.Width = 180
      cspri_itemName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "pri_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csOQty As New TreeTextColumn
      csOQty.MappingName = "pri_originqty"
      csOQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.OQtyHeaderText}")
      csOQty.NullText = ""
      csOQty.DataAlignment = HorizontalAlignment.Right
      csOQty.Format = "#,###.##"
      csOQty.TextBox.Name = "OQty"

      Dim csOrderedQty As New TreeTextColumn
      csOrderedQty.MappingName = "OrderedQty"
      csOrderedQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.OrderedQtyHeaderText}")
      csOrderedQty.NullText = ""
      csOrderedQty.DataAlignment = HorizontalAlignment.Right
      csOrderedQty.Format = "#,###.##"
      csOrderedQty.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "pri_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "pri_note"

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "pri_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "pri_unitprice"
      csUnitPRice.DataAlignment = HorizontalAlignment.Right

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      csAmount.DataAlignment = HorizontalAlignment.Right

      Dim csOAmount As New TreeTextColumn
      csOAmount.MappingName = "pri_originamt"
      csOAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.OAmountHeaderText}")
      csOAmount.NullText = ""
      csOAmount.TextBox.Name = "OAmount"
      csOAmount.ReadOnly = True
      csOAmount.Format = "#,###.##"
      csOAmount.DataAlignment = HorizontalAlignment.Right

      Dim csReceivingDate As New DataGridTimePickerColumn
      csReceivingDate.MappingName = "pri_receivingDate"
      csReceivingDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.ReceivingDateHeaderText}")
      csReceivingDate.NullText = ""


      

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(cspri_itemName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csOQty)
      dst.GridColumnStyles.Add(csOrderedQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csOAmount)
      dst.GridColumnStyles.Add(csNote)
      dst.GridColumnStyles.Add(csReceivingDate)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 6 Then
        Me.UnitButtonClick(e)
      Else
        Me.ItemButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As PRItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is PRItem Then
          Return Nothing
        End If
        Return CType(row.Tag, PRItem)
      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New PRItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "pri_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "pri_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue.ToString) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Qty = value
            'doc.OriginQty = doc.Qty
          Case "pri_entitytype"
            Dim value As ItemType
            If IsNumeric(e.ProposedValue) Then
              value = New ItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "pri_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue.ToString) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
          Case "pri_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "pri_receivingdate"
            If Not IsDate(e.ProposedValue) Then
              e.ProposedValue = Date.MinValue
            End If
            doc.ReceivingDate = CDate(e.ProposedValue)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub PRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
    
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
#End Region

#Region "IListDetail"
    Private CheckForm As Boolean = False
    Public Overrides Sub CheckFormEnable()
      CheckForm = True
      If Me.m_entity Is Nothing Then
        Return
      End If

      Me.lblStoreApprove.Visible = False
      Me.btnApproveStore.Visible = False

      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.btnApprove}")
      Me.btnApprove.Visible = True

      If Me.m_entity.Closed Then
        Me.chkClosed.Checked = True
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.chkClosedCancel}")
        m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 100
        m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 110
      Else
        Me.chkClosed.Checked = False
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.chkClosed}")
        m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 0
        m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 0
      End If

      'จากการอนุมัติเอกสาร

      '------------------ เช็คสิทธิการมองเห็นปุ่มปิดเอกสาร ---------------------
      CType(Me.Entity, PR).Closed = Me.chkClosed.Checked
      If CType(Me.Entity, PR).Closed Then
        CheckCancelClosed()
      Else
        CheckClosed()
      End If




      If CBool(Configuration.GetConfig("ApprovePR")) Then
        Me.btnApprove.Visible = True
        '------------------Store Approve----------------------------
        If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) Then
          CheckApproveStore()
        End If
        '------------------End Store Approve----------------------------

        'ถ้าใช้การอนุมัติแบบใหม่ PJMModule
        If m_ApproveDocModule.Activated Then


          'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          'Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser)					'ระดับสิทธิแต่ละผู้ใช้
          Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity)         'ระดับสิทธิที่ได้ทำการ approve
          If ApproveDocColl.MaxLevel > 0 Then       '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
            '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso _
                 Not ctrl.Name = "btnApproveStore" AndAlso Not ctrl.Name = "chkClosed" Then
                ctrl.Enabled = False
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            Me.btnApprove.Enabled = True
            CheckWBSRight()
            GoTo FinalLine
          Else
            For Each ctrl As Control In grbDetail.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If

          '--------------End แบบใหม่----------

        Else
          '------------ถ้าใช้การอนุมัติแบบเก่า
          If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then          'ถ้ามีการอนุมัติและไม่ใช่คนอนุมัติ
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso _
                 Not ctrl.Name = "btnApproveStore" AndAlso Not ctrl.Name = "chkClosed" Then
                ctrl.Enabled = False
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            Me.btnApprove.Enabled = True
            CheckWBSRight()
            GoTo FinalLine
          Else
            For Each ctrl As Control In grbDetail.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
          '------------End แบบเก่า--------------------------
        End If
      Else
        Me.btnApprove.Visible = False
        CheckApproveStore()
      End If
      'จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 Or m_entityRefed = 1 Or Me.m_entity.Closed Then     'Or Me.m_entity.Status.Value >= 3 Or Me.m_entity.IsReferenced Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
            ctrl.Enabled = False
          ElseIf ctrl.Name = "chkClosed" Then
            If Me.m_entity.Status.Value = 0 Then
              chkClosed.Enabled = False
            End If
          End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      Me.ibtnCopyMe.Enabled = True
      Me.btnApprove.Enabled = True



      CheckWBSRight()
FinalLine:
      CheckForm = False

      '---Check Attachment ----
      If CType(Configuration.GetConfig("UseAttachment"), Boolean) AndAlso Me.m_entity.hasAttachment Then
        Me.imAttachment.Visible = True
        Me.imAttachment.Enabled = True
      Else
        Me.imAttachment.Visible = False
      End If
    End Sub

    Private Sub CheckApproveStore()
      If Me.m_entity.HasLCIItem() Then
        If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
          If Me.m_entity.ApproveStoreDate.Equals(Date.MinValue) Then
            'storeFlag = True
            Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim level As Integer = secSrv.GetAccess(290)            'ตรวจสอบ สิทธิอนุมัติโดยคลัง
            Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
            checkString = BinaryHelper.RevertString(checkString)
            If Not CBool(checkString.Substring(0, 1)) Then
              Me.btnApproveStore.Visible = False
            Else
              Me.btnApproveStore.Visible = True
            End If
            Me.lblStoreApprove.Visible = False
          Else
            Me.btnApproveStore.Visible = False
            Me.lblStoreApprove.Visible = True
          End If
        Else
          Me.btnApproveStore.Visible = False
          Me.lblStoreApprove.Visible = False
        End If
      Else
        Me.btnApproveStore.Visible = False
        Me.lblStoreApprove.Visible = False
      End If
    End Sub
    Private Sub CheckClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(371)            'ตรวจสอบ สิทธิการปิดPR
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub
    Private Sub CheckCancelClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(372)            'ตรวจสอบ สิทธิการปิดPR
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub

    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      'If Not CBool(checkString.Substring(0, 1)) Then
      '  'ห้ามเห็น
      '  Me.lblWBS.Visible = False
      '  Me.tgWBS.Visible = False
      '  Me.ibtnAddWBS.Visible = False
      '  Me.ibtnDelWBS.Visible = False
      'ElseIf Not CBool(checkString.Substring(1, 1)) Then
      '  'ห้ามแก้
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = False
      '  Me.ibtnAddWBS.Enabled = False
      '  Me.ibtnDelWBS.Enabled = False
      'Else
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = True
      '  Me.ibtnAddWBS.Enabled = True
      '  Me.ibtnDelWBS.Enabled = True
      'End If
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      Me.dtpReceivingDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.grbDetail}")

      Me.lblReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblReceivingDate}")
      Me.Validator.SetDisplayName(Me.txtReceivingDate, StringHelper.GetRidOfAtEnd(Me.lblReceivingDate.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblRequestor}")
      Me.Validator.SetDisplayName(Me.txtRequestorCode, StringHelper.GetRidOfAtEnd(Me.lblRequestor.Text, ":"))

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblCostCenter}")
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostCenter.Text, ":"))

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblNote}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblCode}")

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblItem}")

      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.btnApprove}")

      Me.btnApproveStore.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.btnStoreApprove}")
      Me.lblStoreApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.lblStoreApprove}")

            Me.lblGross.Text = Me.StringParserService.Parse("${res:Global.Gross}")
        End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtReceivingDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpReceivingDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtRequestorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtRequestorCode.TextChanged, AddressOf TextHandler
      AddHandler txtCostCenterCode.TextChanged, AddressOf TextHandler

      '==============CURRENCY=================================
      AddHandler txtRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRate.Validated, AddressOf Me.TextHandler
      AddHandler txtUnit1.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtUnit2.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtLanguage.TextChanged, AddressOf Me.ChangeProperty
      '==============CURRENCY=================================
    End Sub
    Private requestorCodeChanged As Boolean = False
    Private isCostCenterCodeBlank As Boolean = True
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      If Me.txtCostCenterCode.Text.Length = 0 Then
        isCostCenterCodeBlank = True
      Else
        isCostCenterCodeBlank = False
      End If
      Select Case CType(sender, Control).Name.ToLower
        '==============CURRENCY=================================
        Case "txtrate"
          Dim txt As String = Me.txtRate.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Currency.Conversion = 0
          Else
            Try
              Me.m_entity.Currency.Conversion = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Currency.Conversion = 0
            End Try
          End If
          Me.txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
          '==============CURRENCY=================================
        Case "txtrequestorcode"
          requestorCodeChanged = True
        Case "txtcostcentercode"
          toCCCodeChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      oldCCId = Me.m_entity.CostCenter.Id
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtCostCenterCode.Text = m_entity.CostCenter.Code
      txtCostCenterName.Text = m_entity.CostCenter.Name
      txtRequestorCode.Text = m_entity.Requestor.Code
      txtRequestorName.Text = m_entity.Requestor.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtReceivingDate.Text = MinDateToNull(Me.m_entity.ReceivingDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpReceivingDate.Value = MinDateToNow(Me.m_entity.ReceivingDate)

      '==============CURRENCY=================================
      txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
      txtLanguage.Text = Me.m_entity.Currency.Language
      txtUnit1.Text = Me.m_entity.Currency.Unit
      txtUnit2.Text = Me.m_entity.Currency.SubUnit
      '==============CURRENCY=================================

      RefreshDocs()

      'UpdateAmount()

      'RefreshWBS()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
    End Sub
    Private m_dateSetting As Boolean = False
    Private toCCCodeChanged As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False
    Private Sub SetCCCodeBlankFlag()
      If Me.txtCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        '==============CURRENCY=================================
        Case "txtrate"
          dirtyFlag = True
        Case "txtlanguage"
          Me.m_entity.Currency.Language = txtLanguage.Text
          dirtyFlag = True
        Case "txtunit1"
          Me.m_entity.Currency.Unit = txtUnit1.Text
          dirtyFlag = True
        Case "txtunit2"
          Me.m_entity.Currency.SubUnit = txtUnit2.Text
          dirtyFlag = True
          '==============CURRENCY=================================
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
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
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpreceivingdate"
          If Not Me.m_entity.ReceivingDate.Equals(dtpReceivingDate.Value) Then
            If Not m_dateSetting Then
              Me.txtReceivingDate.Text = MinDateToNull(dtpReceivingDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.ReceivingDate = dtpReceivingDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtreceivingdate"
          m_dateSetting = True
          If Not Me.txtReceivingDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDate) = "" Then
            Dim theDate As Date = CDate(Me.txtReceivingDate.Text)
            If Not Me.m_entity.ReceivingDate.Equals(theDate) Then
              dtpReceivingDate.Value = theDate
              Me.m_entity.ReceivingDate = dtpReceivingDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.ReceivingDate = Date.Now
            Me.m_entity.ReceivingDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtrequestorcode"
          If requestorCodeChanged Then
            If txtRequestorCode.Text.Length > 0 Then
              dirtyFlag = RunningEmployee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
            End If
            requestorCodeChanged = False
          End If
        Case "txtcostcentercode"
          If toCCCodeChanged Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Not CCCodeBlankFlag Then
              If Me.txtCostCenterCode.Text.ToLower <> Me.m_entity.CostCenter.Code.ToLower Then
                If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
                  If Me.txtCostCenterCode.TextLength <> 0 Then
                    dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                    If dirtyFlag Then
                      UpdateDestAdmin()
                    End If
                  Else
                    Me.m_entity.CostCenter = New CostCenter
                    txtCostCenterName.Text = ""
                  End If
                  Try
                    If oldCCId <> Me.m_entity.CostCenter.Id Then
                      Me.WorkbenchWindow.ViewContent.IsDirty = True
                      oldCCId = Me.m_entity.CostCenter.Id
                      ChangeCC()
                    End If
                  Catch ex As Exception

                  End Try
                  toCCCodeChanged = False
                Else
                  Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
                  toCCCodeChanged = False
                End If
              End If
            Else
              If Me.txtCostCenterCode.TextLength <> 0 Then
                dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                If dirtyFlag Then
                  If Me.txtRequestorName.TextLength = 0 Then
                    UpdateDestAdmin()
                  End If
                End If
              Else
                Me.m_entity.CostCenter = New CostCenter
                txtCostCenterName.Text = ""
              End If
              Try
                If oldCCId <> Me.m_entity.CostCenter.Id Then
                  Me.WorkbenchWindow.ViewContent.IsDirty = True
                  oldCCId = Me.m_entity.CostCenter.Id
                  ChangeCC()
                End If
              Catch ex As Exception

              End Try
              toCCCodeChanged = False
            End If
          End If
          If toCCCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            If Me.txtRequestorName.TextLength = 0 Then
              UpdateDestAdmin()
            End If
            toCCCodeChanged = False
          End If

      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      SetCCCodeBlankFlag()
    End Sub
    Private Sub UpdateAmount()
      m_isInitialized = False
      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      m_isInitialized = True
      'RefreshWBS()
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, PR)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        AddHandler m_entity.AttachIsChanges, AddressOf CheckFormEnable
        UpdateEntityProperties()
      End Set
    End Property
    'Public Sub ReloadEntity()
    '	Dim newEntity As PR
    '	newEntity = New PR(Me.Entity.Id)
    '	newEntity.Closed = CType(Me.Entity, PR).Closed
    '	Me.Entity = newEntity
    'End Sub
    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub


#End Region

#Region "Event Handlers"

    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim view As Integer = 7
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.GetSumPercent >= 100 Then
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
        msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
      Else
        Dim wbsd As New WBSDistribute
        wbsd.CostCenter = Me.m_entity.CostCenter
        wbsd.Percent = 100 - wsdColl.GetSumPercent
        wsdColl.Add(wbsd)
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.Count > 0 Then
        wsdColl.Remove(wsdColl.Count - 1)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Dim view As Integer = 7
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
    End Sub
    Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY OrElse currentY = 0 OrElse currentY = -1 Then
        Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
        'RefreshWBS()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
    'Private Sub RefreshWBS()
    '  Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '  dt.Clear()
    '  Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  If Me.m_entity.ItemCollection.CurrentItem Is Nothing Then
    '    Return
    '  End If
    '  Dim item As PRItem = Me.m_entity.ItemCollection.CurrentItem
    '  Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '  Dim view As Integer = 7
    '  m_wbsdInitialized = False
    '  wsdColl.Populate(dt, item, view)
    '  m_wbsdInitialized = True
    'End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
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
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New PRItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      Dim includeFilter As Boolean = False
      If TypeOf doc.Entity Is Tool Then
        Dim mytool As Tool = CType(doc.Entity, Tool)
        If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
          filters(0) = New Filter("includedId", mytool.Unit.Id)
          includeFilter = True
        End If
      ElseIf TypeOf doc.Entity Is LCIItem Then
        Dim idList As String = CType(doc.Entity, LCIItem).GetUnitIdList
        If idList.Length > 0 Then
          filters(0) = New Filter("includedId", idList)
          includeFilter = True
        End If
      End If
      If includeFilter Then
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
      Else
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        doc = New PRItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(2) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New LCIForList
        entities(2) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 2
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      ' Comment : สามารถเก็บ Material Level อื่นได้
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim prItem As New PRItem
      prItem.Entity = newItem
      prItem.ItemType = New ItemType(0)
      prItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(index, prItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'If index > Me.m_entity.ItemCollection.Count - 1 Then
      '  Return
      'End If
      'Me.m_entity.ItemCollection.Remove(index)

      ''me.tgItem
      'Me.tgItem.CurrentRowIndex = index

      Dim rowsCount As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If TypeOf row.Tag Is PRItem Then
              Dim doc As PRItem = CType(row.Tag, PRItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemCollection.Remove(doc)
      End If

      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("pri_linenumber") = i + 1
        i += 1
      Next
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
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
        Return (New PR).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      arr.Add(Me.m_entity.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    End Sub
    ' Requestor
    Private Sub btnRequestorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtRequestorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
        Me.WorkbenchWindow.ViewContent.IsDirty _
        Or Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          'If Me.txtCostCenterCode.TextLength = 0 Then
          '    Me.m_entity.CostCenter = New CostCenter
          'End If
          Me.txtCostCenterCode.Text = e.Code
          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          If dirtyFlag Then
            UpdateDestAdmin()
          End If
          Try
            If oldCCId <> Me.m_entity.CostCenter.Id Then
              Me.WorkbenchWindow.ViewContent.IsDirty = True
              oldCCId = Me.m_entity.CostCenter.Id
              ChangeCC()
            End If
          Catch ex As Exception
          End Try
          toCCCodeChanged = False
        Else
          Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          toCCCodeChanged = False
        End If
      ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
        Me.txtCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        If dirtyFlag Then
          UpdateDestAdmin()
        End If
      End If
      SetCCCodeBlankFlag()
      'Me.txtCostCenterCode.Text = e.Code
      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      '    Me.WorkbenchWindow.ViewContent.IsDirty _
      '    Or CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter)
      'UpdateDestAdmin()
      'Try
      '    If oldCCId <> Me.m_entity.CostCenter.Id Then
      '        Me.WorkbenchWindow.ViewContent.IsDirty = True
      '        oldCCId = Me.m_entity.CostCenter.Id
      '        ChangeCC()
      '    End If
      'Catch ex As Exception
      'End Try
      'toCCCodeChanged = False
    End Sub
    Private Sub ChangeCC()
      oldCCId = Me.m_entity.CostCenter.Id
      For Each item As PRItem In Me.m_entity.ItemCollection
        item.WBSDistributeCollection.Clear()
      Next
      If Not Me.m_entity.CostCenter Is Nothing Then
      End If
      RefreshDocs()
      'RefreshWBS()
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Try
        Me.m_entity.Requestor = Me.m_entity.CostCenter.Admin
        Me.txtRequestorCode.Text = m_entity.Requestor.Code
        txtRequestorName.Text = m_entity.Requestor.Name
      Catch ex As Exception
      Finally
        Me.m_isInitialized = flag
      End Try
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyCC)
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      Dim x As Form
      If m_ApproveDocModule.Activated Then
        x = New AdvanceApprovalCommentForm(Me.Entity)
      Else
        x = New ApprovalCommentForm(Me.Entity)
      End If
      x.ShowDialog()
      CheckFormEnable()
      'ReloadEntity()
    End Sub
    Private Sub btnApproveStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproveStore.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.Message.StoreApprove}", "${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.Caption.StoreApprove}") Then
        Dim theTime As Date = Now
        Dim approveError As SaveErrorException = Me.m_entity.ApproveStoreData(Me.m_entity.Id, SecurityService.CurrentUser.Id, theTime)
        If IsNumeric(approveError.Message) Then
          Me.m_entity.ApproveStoreDate = theTime
          Me.m_entity.ApproveStorePerson = SecurityService.CurrentUser
        Else
          MessageBox.Show(approveError.Message)
        End If
      End If
      CheckFormEnable()
    End Sub

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Try
          Dim data As IDataObject = Clipboard.GetDataObject
          If data.GetDataPresent((dummyEmployee).FullClassName) Then
            If Not Me.ActiveControl Is Nothing Then
              Select Case Me.ActiveControl.Name.ToLower
                Case "txtrequestorcode", "txtrequestorname"
                  Return True
              End Select
            End If
          End If
          If data.GetDataPresent((dummyCC).FullClassName) Then
            If Not Me.ActiveControl Is Nothing Then
              Select Case Me.ActiveControl.Name.ToLower
                Case "txtcostcentercode", "txtcostcentername"
                  Return True
              End Select
            End If
          End If
        Catch ex As Exception

        End Try

        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((dummyEmployee).FullClassName) Then
          Dim id As Integer = CInt(data.GetData((dummyEmployee).FullClassName))
          Dim entity As New Employee(id)
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtrequestorcode", "txtrequestorname"
                Me.SetEmployeeDialog(entity)
            End Select
          End If
        End If
        If data.GetDataPresent((dummyCC).FullClassName) Then
          Dim id As Integer = CInt(data.GetData((dummyCC).FullClassName))
          Dim entity As New CostCenter(id)
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcostcentercode", "txtcostcentername"
                Me.SetCostCenterDialog(entity)
            End Select
          End If
        End If
      Catch ex As Exception

      End Try
    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Keys.Enter
            If TypeOf Me.ActiveControl Is TextBox Then
              If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
                If CType(Me.ActiveControl, TextBox).Multiline Then
                  Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
                  CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
                  CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
                  Return True
                End If
              End If
            End If
            SendKeys.Send("{tab}")
            Return True
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
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
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClosed.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      If Me.CheckForm = False Then

        CType(Me.Entity, PR).Closed = Me.chkClosed.Checked
        If CType(Me.Entity, PR).Closed Then
          Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.chkClosedCancel}")
          'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 100
          'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 110
        Else
          Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.chkClosed}")
          'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 0
          'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 0
        End If
        'Me.RefreshWBS()
        'Me.WorkbenchWindow.ViewContent.Save()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub

   

    Private Sub imAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imAttachment.Click
      If m_entity Is Nothing OrElse Not m_entity.Originated Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim frm As New AttachmentForm(Me.m_entity)
      Select Case frm.ShowDialog
        Case DialogResult.OK
          If Not frm.AttachmentColl Is Nothing Then
            frm.AttachmentColl.Save()
          End If
        Case Else

      End Select
      Dim tmp As Boolean = Me.m_entity.hasAttachment(True)
      'CheckFormEnable()
    End Sub
  End Class
End Namespace
