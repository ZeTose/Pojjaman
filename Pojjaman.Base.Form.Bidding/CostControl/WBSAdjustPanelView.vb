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
  Public Class WBSAdjustPanelView
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
    Friend WithEvents dtpAdjustDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAdjustDate As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblAdjustPerson As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtAdjustPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustPersonName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustDate As System.Windows.Forms.TextBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents btnAdjustPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAdjustPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbReason As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAllocateType As System.Windows.Forms.ComboBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents lblAllocateType As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBSAdjustPanelView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbReason = New System.Windows.Forms.ComboBox()
      Me.cmbAllocateType = New System.Windows.Forms.ComboBox()
      Me.btnAdjustPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAdjustPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtAdjustDate = New System.Windows.Forms.TextBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtAdjustPersonName = New System.Windows.Forms.TextBox()
      Me.txtAdjustPersonCode = New System.Windows.Forms.TextBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.dtpAdjustDate = New System.Windows.Forms.DateTimePicker()
      Me.lblReason = New System.Windows.Forms.Label()
      Me.lblAllocateType = New System.Windows.Forms.Label()
      Me.lblAdjustDate = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblAdjustPerson = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbReason)
      Me.grbDetail.Controls.Add(Me.cmbAllocateType)
      Me.grbDetail.Controls.Add(Me.btnAdjustPersonEdit)
      Me.grbDetail.Controls.Add(Me.btnAdjustPersonFind)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtAdjustDate)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtAdjustPersonName)
      Me.grbDetail.Controls.Add(Me.txtAdjustPersonCode)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.dtpAdjustDate)
      Me.grbDetail.Controls.Add(Me.lblReason)
      Me.grbDetail.Controls.Add(Me.lblAllocateType)
      Me.grbDetail.Controls.Add(Me.lblAdjustDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblAdjustPerson)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
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
      'cmbReason
      '
      Me.cmbReason.Location = New System.Drawing.Point(120, 88)
      Me.cmbReason.Name = "cmbReason"
      Me.cmbReason.Size = New System.Drawing.Size(418, 21)
      Me.cmbReason.TabIndex = 7
      '
      'cmbAllocateType
      '
      Me.cmbAllocateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAllocateType.Location = New System.Drawing.Point(120, 64)
      Me.cmbAllocateType.Name = "cmbAllocateType"
      Me.cmbAllocateType.Size = New System.Drawing.Size(120, 21)
      Me.cmbAllocateType.TabIndex = 6
      '
      'btnAdjustPersonEdit
      '
      Me.btnAdjustPersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdjustPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdjustPersonEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdjustPersonEdit.Location = New System.Drawing.Point(514, 111)
      Me.btnAdjustPersonEdit.Name = "btnAdjustPersonEdit"
      Me.btnAdjustPersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAdjustPersonEdit.TabIndex = 334
      Me.btnAdjustPersonEdit.TabStop = False
      Me.btnAdjustPersonEdit.ThemedImage = CType(resources.GetObject("btnAdjustPersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAdjustPersonFind
      '
      Me.btnAdjustPersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdjustPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdjustPersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdjustPersonFind.Location = New System.Drawing.Point(490, 111)
      Me.btnAdjustPersonFind.Name = "btnAdjustPersonFind"
      Me.btnAdjustPersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAdjustPersonFind.TabIndex = 333
      Me.btnAdjustPersonFind.TabStop = False
      Me.btnAdjustPersonFind.ThemedImage = CType(resources.GetObject("btnAdjustPersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(120, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(157, 21)
      Me.cmbCode.TabIndex = 1
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
      Me.ibtnCopyMe.Location = New System.Drawing.Point(298, 15)
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
      Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(173, 179)
      Me.ibtnGetFromBOQ.Name = "ibtnGetFromBOQ"
      Me.ibtnGetFromBOQ.Size = New System.Drawing.Size(48, 24)
      Me.ibtnGetFromBOQ.TabIndex = 325
      Me.ibtnGetFromBOQ.TabStop = False
      Me.ibtnGetFromBOQ.Text = "BOQ"
      Me.ibtnGetFromBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnGetFromBOQ.ThemedImage = CType(resources.GetObject("ibtnGetFromBOQ.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnGetFromBOQ, "BOQ")
      Me.ibtnGetFromBOQ.Visible = False
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(277, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 320
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'txtAdjustDate
      '
      Me.Validator.SetDataType(Me.txtAdjustDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtAdjustDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAdjustDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustDate, System.Drawing.Color.Empty)
      Me.txtAdjustDate.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMinValue(Me.txtAdjustDate, "")
      Me.txtAdjustDate.Name = "txtAdjustDate"
      Me.Validator.SetRegularExpression(Me.txtAdjustDate, "")
      Me.Validator.SetRequired(Me.txtAdjustDate, True)
      Me.txtAdjustDate.Size = New System.Drawing.Size(100, 21)
      Me.txtAdjustDate.TabIndex = 4
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(416, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(100, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'txtAdjustPersonName
      '
      Me.txtAdjustPersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdjustPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdjustPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustPersonName, System.Drawing.Color.Empty)
      Me.txtAdjustPersonName.Location = New System.Drawing.Point(240, 112)
      Me.Validator.SetMinValue(Me.txtAdjustPersonName, "")
      Me.txtAdjustPersonName.Name = "txtAdjustPersonName"
      Me.txtAdjustPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdjustPersonName, "")
      Me.Validator.SetRequired(Me.txtAdjustPersonName, False)
      Me.txtAdjustPersonName.Size = New System.Drawing.Size(250, 21)
      Me.txtAdjustPersonName.TabIndex = 199
      Me.txtAdjustPersonName.TabStop = False
      '
      'txtAdjustPersonCode
      '
      Me.Validator.SetDataType(Me.txtAdjustPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdjustPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdjustPersonCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAdjustPersonCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAdjustPersonCode, System.Drawing.Color.Empty)
      Me.txtAdjustPersonCode.Location = New System.Drawing.Point(120, 112)
      Me.Validator.SetMinValue(Me.txtAdjustPersonCode, "")
      Me.txtAdjustPersonCode.Name = "txtAdjustPersonCode"
      Me.Validator.SetRegularExpression(Me.txtAdjustPersonCode, "")
      Me.Validator.SetRequired(Me.txtAdjustPersonCode, False)
      Me.txtAdjustPersonCode.Size = New System.Drawing.Size(120, 21)
      Me.txtAdjustPersonCode.TabIndex = 8
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
      Me.tgItem.Location = New System.Drawing.Point(11, 206)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(895, 269)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'dtpAdjustDate
      '
      Me.dtpAdjustDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpAdjustDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpAdjustDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpAdjustDate.Location = New System.Drawing.Point(120, 40)
      Me.dtpAdjustDate.Name = "dtpAdjustDate"
      Me.dtpAdjustDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpAdjustDate.TabIndex = 5
      Me.dtpAdjustDate.TabStop = False
      '
      'lblReason
      '
      Me.lblReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReason.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblReason.Location = New System.Drawing.Point(5, 88)
      Me.lblReason.Name = "lblReason"
      Me.lblReason.Size = New System.Drawing.Size(112, 18)
      Me.lblReason.TabIndex = 173
      Me.lblReason.Text = "เหตุผล"
      Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAllocateType
      '
      Me.lblAllocateType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAllocateType.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAllocateType.Location = New System.Drawing.Point(6, 64)
      Me.lblAllocateType.Name = "lblAllocateType"
      Me.lblAllocateType.Size = New System.Drawing.Size(112, 18)
      Me.lblAllocateType.TabIndex = 173
      Me.lblAllocateType.Text = "มุมมองการจัดสรร"
      Me.lblAllocateType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdjustDate
      '
      Me.lblAdjustDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdjustDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAdjustDate.Location = New System.Drawing.Point(7, 40)
      Me.lblAdjustDate.Name = "lblAdjustDate"
      Me.lblAdjustDate.Size = New System.Drawing.Size(112, 18)
      Me.lblAdjustDate.TabIndex = 173
      Me.lblAdjustDate.Text = "วันรับของ"
      Me.lblAdjustDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDocDate.Location = New System.Drawing.Point(357, 17)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(59, 18)
      Me.lblDocDate.TabIndex = 172
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCode.Location = New System.Drawing.Point(7, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(112, 18)
      Me.lblCode.TabIndex = 171
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdjustPerson
      '
      Me.lblAdjustPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblAdjustPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdjustPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAdjustPerson.Location = New System.Drawing.Point(7, 112)
      Me.lblAdjustPerson.Name = "lblAdjustPerson"
      Me.lblAdjustPerson.Size = New System.Drawing.Size(112, 18)
      Me.lblAdjustPerson.TabIndex = 174
      Me.lblAdjustPerson.Text = "ผู้ขอ:"
      Me.lblAdjustPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(120, 136)
      Me.txtNote.MaxLength = 250
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(418, 39)
      Me.txtNote.TabIndex = 9
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNote.Location = New System.Drawing.Point(7, 136)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(112, 18)
      Me.lblNote.TabIndex = 176
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblItem.Location = New System.Drawing.Point(24, 178)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(88, 24)
      Me.lblItem.TabIndex = 173
      Me.lblItem.Text = "รายการขอซื้อ"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(119, 179)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 14
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(416, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDate.TabIndex = 3
      Me.dtpDocDate.TabStop = False
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(143, 179)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 15
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
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
      'WBSAdjustPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "WBSAdjustPanelView"
      Me.Size = New System.Drawing.Size(930, 520)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As WBSAdjust
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private dummyCC As New CostCenter
    Private dummyEmployee As New Employee

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable

    'Private m_treeManager2 As TreeManager
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

      SaveEnableState()

      Dim dt As TreeTable = WBSAdjust.GetSchemaTable()
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
      'SetCCCodeBlankFlag()
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
      dst.MappingName = "WBSAdjust"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 25
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("entityType" _
      , CodeDescription.GetCodeList("AdjustAllocateType") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.TypeHeaderText}")
      csType.Width = 140
      csType.NullText = String.Empty

      'Dim csCode As New TreeTextColumn
      'csCode.MappingName = "Code"
      'csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.CodeHeaderText}")
      'csCode.NullText = ""
      'csCode.Width = 100
      ''csCode.ReadOnly = True
      'csCode.TextBox.Name = "Code"

      'Dim csButton As New DataGridButtonColumn
      'csButton.MappingName = "Button"
      'csButton.HeaderText = ""
      'csButton.NullText = ""

      Dim cspri_itemName As New TreeTextColumn
      cspri_itemName.MappingName = "itemName"
      cspri_itemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.DescriptionHeaderText}")
      cspri_itemName.NullText = ""
      cspri_itemName.Width = 180
      cspri_itemName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      'Dim csUnit As New TreeTextColumn
      'csUnit.MappingName = "Unit"
      'csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.UnitHeaderText}")
      'csUnit.NullText = ""
      'csUnit.TextBox.Name = "Unit"
      ''AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      ''csUnit.DataAlignment = HorizontalAlignment.Center

      'Dim csUnitButton As New DataGridButtonColumn
      'csUnitButton.MappingName = "UnitButton"
      'csUnitButton.HeaderText = ""
      'csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf ButtonClicked

      'Dim csQty As New TreeTextColumn
      'csQty.MappingName = "pri_qty"
      'csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.QtyHeaderText}")
      'csQty.NullText = ""
      'csQty.DataAlignment = HorizontalAlignment.Right
      'csQty.Format = "#,###.##"
      'csQty.TextBox.Name = "Qty"
      ''AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      'Dim csOQty As New TreeTextColumn
      'csOQty.MappingName = "pri_originqty"
      'csOQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.OQtyHeaderText}")
      'csOQty.NullText = ""
      'csOQty.DataAlignment = HorizontalAlignment.Right
      'csOQty.Format = "#,###.##"
      'csOQty.TextBox.Name = "OQty"

      'Dim csOrderedQty As New TreeTextColumn
      'csOrderedQty.MappingName = "OrderedQty"
      'csOrderedQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.OrderedQtyHeaderText}")
      'csOrderedQty.NullText = ""
      'csOrderedQty.DataAlignment = HorizontalAlignment.Right
      'csOrderedQty.Format = "#,###.##"
      'csOrderedQty.ReadOnly = True

      Dim csCost As New TreeTextColumn
      csCost.MappingName = "cost"
      csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.CostHeaderText}")
      csCost.NullText = ""
      csCost.TextBox.Name = "cost"
      csCost.Width = 100
      csCost.DataAlignment = HorizontalAlignment.Right

      Dim csCostCenter As New TreeTextColumn
      csCostCenter.MappingName = "costcenter"
      csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.CostCenterHeaderText}")
      csCostCenter.NullText = ""
      csCostCenter.Width = 120
      csCostCenter.TextBox.Name = "costcenter"

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""
      AddHandler csCCButton.Click, AddressOf ButtonClicked

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "note"

      'Dim csUnitPRice As New TreeTextColumn
      'csUnitPRice.MappingName = "pri_unitprice"
      'csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.UnitpriceHeaderText}")
      'csUnitPRice.NullText = ""
      'csUnitPRice.TextBox.Name = "pri_unitprice"
      'csUnitPRice.DataAlignment = HorizontalAlignment.Right

      'Dim csAmount As New TreeTextColumn
      'csAmount.MappingName = "Amount"
      'csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.AmountHeaderText}")
      'csAmount.NullText = ""
      'csAmount.TextBox.Name = "Amount"
      'csAmount.ReadOnly = True
      'csAmount.Format = "#,###.##"
      'csAmount.DataAlignment = HorizontalAlignment.Right

      'Dim csOAmount As New TreeTextColumn
      'csOAmount.MappingName = "pri_originamt"
      'csOAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.OAmountHeaderText}")
      'csOAmount.NullText = ""
      'csOAmount.TextBox.Name = "OAmount"
      'csOAmount.ReadOnly = True
      'csOAmount.Format = "#,###.##"
      'csOAmount.DataAlignment = HorizontalAlignment.Right

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      'dst.GridColumnStyles.Add(csCode)
      'dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(cspri_itemName)
      'dst.GridColumnStyles.Add(csUnit)
      'dst.GridColumnStyles.Add(csUnitButton)
      'dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csOQty)
      'dst.GridColumnStyles.Add(csOrderedQty)
      'dst.GridColumnStyles.Add(csUnitPRice)
      'dst.GridColumnStyles.Add(csAmount)
      'dst.GridColumnStyles.Add(csOAmount)
      dst.GridColumnStyles.Add(csCost)
      'dst.GridColumnStyles.Add(csCostCenter)
      'dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 5 Then
        'Me.ItemButtonClick(e)
        Me.ItemCCButtonClick(e)
      Else
        'Me.UnitButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As WBSAdjustItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is WBSAdjustItem Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSAdjustItem)
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
      Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
      If doc Is Nothing Then
        doc = New WBSAdjustItem
        doc.WBSAdjust = m_entity
        doc.ItemType = New AdjustAllocateType(0)
        Me.m_entity.ItemList.Add(doc)
        Me.m_entity.CurrentItem = doc

        Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
        Dim wbsd As New WBSDistribute
        wbsd.CostCenter = Me.m_entity.ToCostCenter
        wbsd.Percent = 100 '- wsdColl.GetSumPercent
        wsdColl.Add(wbsd)
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          'Case "code"
          '  If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
          '    e.ProposedValue = ""
          '  End If
          '  doc.SetItemCode(CStr(e.ProposedValue))
          Case "itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
            'Case "unit"
            '  If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
            '    e.ProposedValue = ""
            '  End If
            '  Dim myUnit As New Unit(e.ProposedValue.ToString)
            '  doc.Unit = myUnit
            'Case "pri_qty"
            '  If IsDBNull(e.ProposedValue) Then
            '    e.ProposedValue = ""
            '  End If
            '  Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            '  If Not e.ProposedValue = "" Then
            '    If IsNumeric(e.ProposedValue.ToString) Then
            '      value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            '    End If
            '  End If
            '  doc.Qty = value
            'doc.OriginQty = doc.Qty
          Case "entitytype"
            Dim value As AdjustAllocateType
            If IsNumeric(e.ProposedValue) Then
              value = New AdjustAllocateType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "cost"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue.ToString) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Cost = value
          Case "note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "costcenter"
            SetCostCenterCode(e)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private m_wbsUpdating As Boolean = False
    Public Sub SetCostCenterCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_wbsUpdating Then
        Return
      End If
      m_wbsUpdating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim doc As WBSAdjustItem = Me.CurrentTagItem
      If doc Is Nothing Then
        Return
      End If

      If Not IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length > 0 Then
        Dim cccodename As String = e.ProposedValue.ToString
        Dim cccode As String() = cccodename.Split(":"c)

        Dim cc As CostCenter = CostCenter.GetCostCenter(cccode(0).Trim)
        If cc Is Nothing Then
          msgServ.ShowMessageFormatted("${res:Global.Error.CostCenterCodeNameMissMatch}", New String() {cccode(0).Trim})
          Return
        End If

        doc.CostCenter = cc
      End If

      m_wbsUpdating = False
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

      'Me.lblStoreApprove.Visible = False
      'Me.btnApproveStore.Visible = False

      'Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.btnApprove}")
      'Me.btnApprove.Visible = True

      'If Me.m_entity.Closed Then
      '  Me.chkClosed.Checked = True
      '  Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.chkClosedCancel}")
      '  m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 100
      '  m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 110
      'Else
      '  Me.chkClosed.Checked = False
      '  Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.chkClosed}")
      '  m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 0
      '  m_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 0
      'End If

      'จากการอนุมัติเอกสาร
      'If CBool(Configuration.GetConfig("ApprovePR")) Then
      '  Me.btnApprove.Visible = True

      '  '------------------Store Approve----------------------------
      '  If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) Then
      '    CheckApproveStore()
      '  End If
      '  '------------------End Store Approve----------------------------

      '  'ถ้าใช้การอนุมัติแบบใหม่ PJMModule
      '  If m_ApproveDocModule.Activated Then


      '    'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      '    'Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser)					'ระดับสิทธิแต่ละผู้ใช้
      '    Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity)         'ระดับสิทธิที่ได้ทำการ approve
      '    If ApproveDocColl.MaxLevel > 0 Then       '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
      '      '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
      '      For Each ctrl As Control In grbDetail.Controls
      '        If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso _
      '           Not ctrl.Name = "btnApproveStore" AndAlso Not ctrl.Name = "chkClosed" Then
      '          ctrl.Enabled = False
      '        End If
      '      Next
      '      tgItem.Enabled = True
      '      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '        colStyle.ReadOnly = True
      '      Next
      '      Me.btnApprove.Enabled = True
      '      CheckWBSRight()
      '      GoTo FinalLine
      '    Else
      '      For Each ctrl As Control In grbDetail.Controls
      '        ctrl.Enabled = CBool(m_enableState(ctrl))
      '      Next
      '      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '        colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '      Next
      '    End If

      '    '--------------End แบบใหม่----------

      '  Else
      '    '------------ถ้าใช้การอนุมัติแบบเก่า
      '    If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then          'ถ้ามีการอนุมัติและไม่ใช่คนอนุมัติ
      '      For Each ctrl As Control In grbDetail.Controls
      '        If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso _
      '           Not ctrl.Name = "btnApproveStore" AndAlso Not ctrl.Name = "chkClosed" Then
      '          ctrl.Enabled = False
      '        End If
      '      Next
      '      tgItem.Enabled = True
      '      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '        colStyle.ReadOnly = True
      '      Next
      '      Me.btnApprove.Enabled = True
      '      CheckWBSRight()
      '      GoTo FinalLine
      '    Else
      '      For Each ctrl As Control In grbDetail.Controls
      '        ctrl.Enabled = CBool(m_enableState(ctrl))
      '      Next
      '      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '        colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '      Next
      '    End If
      '    '------------End แบบเก่า--------------------------
      '  End If
      'Else
      '  Me.btnApprove.Visible = False
      '  CheckApproveStore()
      'End If


      'จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 Then     'Or Me.m_entity.Status.Value >= 3 Or Me.m_entity.IsReferenced Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
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
      'Me.btnApprove.Enabled = True

      CheckWBSRight()
FinalLine:
      CheckForm = False
    End Sub

    Private Sub CheckApproveStore()
      'If Me.m_entity.HasLCIItem() Then
      '  If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
      '    If Me.m_entity.ApproveStoreDate.Equals(Date.MinValue) Then
      '      storeFlag = True
      '      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      '      Dim level As Integer = secSrv.GetAccess(290)            'ตรวจสอบ สิทธิอนุมัติโดยคลัง
      '      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      '      checkString = BinaryHelper.RevertString(checkString)
      '      If Not CBool(checkString.Substring(0, 1)) Then
      '        Me.btnApproveStore.Visible = False
      '      Else
      '        Me.btnApproveStore.Visible = True
      '      End If
      '      Me.lblStoreApprove.Visible = False
      '    Else
      '      Me.btnApproveStore.Visible = False
      '      Me.lblStoreApprove.Visible = True
      '    End If
      '  Else
      '    Me.btnApproveStore.Visible = False
      '    Me.lblStoreApprove.Visible = False
      '  End If
      'Else
      '  Me.btnApproveStore.Visible = False
      '  Me.lblStoreApprove.Visible = False
      'End If
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
      'lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      Me.dtpAdjustDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.grbDetail}")

      Me.lblAdjustDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblAdjustDate}")
      Me.Validator.SetDisplayName(Me.txtAdjustDate, StringHelper.GetRidOfAtEnd(Me.lblAdjustDate.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblAdjustPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblAdjustPerson}")
      Me.Validator.SetDisplayName(Me.txtAdjustPersonCode, StringHelper.GetRidOfAtEnd(Me.lblAdjustPerson.Text, ":"))

      'Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblCostCenter}")
      'Me.Validator.SetDisplayName(Me.txtCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostCenter.Text, ":"))

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblNote}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblCode}")

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblItem}")

      Me.lblAllocateType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblAllocateType}")
      Me.lblReason.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblReason}")

      'Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.btnApprove}")

      'Me.btnApproveStore.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.btnStoreApprove}")
      'Me.lblStoreApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.lblStoreApprove}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler cmbReason.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbReason.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtAdjustDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpAdjustDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtAdjustPersonCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAdjustPersonCode.TextChanged, AddressOf TextHandler
      'AddHandler txtCostCenterCode.TextChanged, AddressOf TextHandler

      AddHandler cmbAllocateType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      ''==============CURRENCY=================================
      'AddHandler txtRate.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtRate.Validated, AddressOf Me.TextHandler
      'AddHandler txtUnit1.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtUnit2.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtLanguage.TextChanged, AddressOf Me.ChangeProperty
      ''==============CURRENCY=================================
    End Sub
    Private AdjustPersonCodeChanged As Boolean = False
    Private isCostCenterCodeBlank As Boolean = True
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      'If Me.txtCostCenterCode.Text.Length = 0 Then
      '  isCostCenterCodeBlank = True
      'Else
      '  isCostCenterCodeBlank = False
      'End If
      Select Case CType(sender, Control).Name.ToLower
        ''==============CURRENCY=================================
        'Case "txtrate"
        '  Dim txt As String = Me.txtRate.Text
        '  txt = txt.Replace(",", "")
        '  If txt.Length = 0 Then
        '    Me.m_entity.Currency.Conversion = 0
        '  Else
        '    Try
        '      Me.m_entity.Currency.Conversion = CDec(TextParser.Evaluate(txt))
        '    Catch ex As Exception
        '      Me.m_entity.Currency.Conversion = 0
        '    End Try
        '  End If
        '  Me.txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
        '  '==============CURRENCY=================================
        Case "txtadjustpersoncode"
          AdjustPersonCodeChanged = True
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
      'oldCCId = Me.m_entity.CostCenter.Id
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      'txtCostCenterCode.Text = m_entity.CostCenter.Code
      'txtCostCenterName.Text = m_entity.CostCenter.Name
      'txtAdjustPersonCode.Text = m_entity.AdjustPerson.Code
      'txtAdjustPersonName.Text = m_entity.AdjustPerson.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtAdjustDate.Text = MinDateToNull(Me.m_entity.AdjustDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpAdjustDate.Value = MinDateToNow(Me.m_entity.AdjustDate)

      Me.txtAdjustPersonCode.Text = Me.m_entity.AdjustPerson.Code
      Me.txtAdjustPersonName.Text = Me.m_entity.AdjustPerson.Name

      For Each item As IdValuePair In Me.cmbAllocateType.Items
        If Me.m_entity.AllocationType = item.Id Then
          Me.cmbAllocateType.SelectedItem = item
        End If
      Next

      Me.cmbReason.Text = Me.m_entity.Reason

      ''==============CURRENCY=================================
      'txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
      'txtLanguage.Text = Me.m_entity.Currency.Language
      'txtUnit1.Text = Me.m_entity.Currency.Unit
      'txtUnit2.Text = Me.m_entity.Currency.SubUnit
      ''==============CURRENCY=================================

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
      Me.m_entity.Populate(m_treeManager.Treetable)
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
      'If Me.txtCostCenterCode.Text.Length = 0 Then
      '  CCCodeBlankFlag = True
      'Else
      '  CCCodeBlankFlag = False
      'End If
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        ''==============CURRENCY=================================
        'Case "txtrate"
        '  dirtyFlag = True
        'Case "txtlanguage"
        '  Me.m_entity.Currency.Language = txtLanguage.Text
        '  dirtyFlag = True
        'Case "txtunit1"
        '  Me.m_entity.Currency.Unit = txtUnit1.Text
        '  dirtyFlag = True
        'Case "txtunit2"
        '  Me.m_entity.Currency.SubUnit = txtUnit2.Text
        '  dirtyFlag = True
        '  '==============CURRENCY=================================
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
        Case "cmbreason"
          Me.m_entity.Reason = cmbReason.Text
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
        Case "dtpadjustdate"
          If Not Me.m_entity.AdjustDate.Equals(dtpAdjustDate.Value) Then
            If Not m_dateSetting Then
              Me.txtAdjustDate.Text = MinDateToNull(dtpAdjustDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.AdjustDate = dtpAdjustDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtadjustdate"
          m_dateSetting = True
          If Not Me.txtAdjustDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtAdjustDate) = "" Then
            Dim theDate As Date = CDate(Me.txtAdjustDate.Text)
            If Not Me.m_entity.AdjustDate.Equals(theDate) Then
              dtpAdjustDate.Value = theDate
              Me.m_entity.AdjustDate = dtpAdjustDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.AdjustDate = Date.Now
            Me.m_entity.AdjustDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtadjustpersoncode"
          If AdjustPersonCodeChanged Then
            If txtAdjustPersonCode.Text.Length > 0 Then
              dirtyFlag = RunningEmployee.GetEmployee(txtAdjustPersonCode, txtAdjustPersonName, Me.m_entity.AdjustPerson)
            End If
            AdjustPersonCodeChanged = False
          End If
        Case "cmballocatetype"
          Dim key As IdValuePair = cmbAllocateType.SelectedItem
          Me.m_entity.AllocationType = key.Id
          dirtyFlag = True
        Case "txtcostcentercode"
          'If toCCCodeChanged Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          '  If Not CCCodeBlankFlag Then
          '    If Me.txtCostCenterCode.Text.ToLower <> Me.m_entity.CostCenter.Code.ToLower Then
          '      If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          '        If Me.txtCostCenterCode.TextLength <> 0 Then
          '          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '          If dirtyFlag Then
          '            UpdateDestAdmin()
          '          End If
          '        Else
          '          Me.m_entity.CostCenter = New CostCenter
          '          txtCostCenterName.Text = ""
          '        End If
          '        Try
          '          If oldCCId <> Me.m_entity.CostCenter.Id Then
          '            Me.WorkbenchWindow.ViewContent.IsDirty = True
          '            oldCCId = Me.m_entity.CostCenter.Id
          '            ChangeCC()
          '          End If
          '        Catch ex As Exception

          '        End Try
          '        toCCCodeChanged = False
          '      Else
          '        Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          '        toCCCodeChanged = False
          '      End If
          '    End If
          '  Else
          '    If Me.txtCostCenterCode.TextLength <> 0 Then
          '      dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '      If dirtyFlag Then
          '        If Me.txtAdjustPersonName.TextLength = 0 Then
          '          UpdateDestAdmin()
          '        End If
          '      End If
          '    Else
          '      Me.m_entity.CostCenter = New CostCenter
          '      txtCostCenterName.Text = ""
          '    End If
          '    Try
          '      If oldCCId <> Me.m_entity.CostCenter.Id Then
          '        Me.WorkbenchWindow.ViewContent.IsDirty = True
          '        oldCCId = Me.m_entity.CostCenter.Id
          '        ChangeCC()
          '      End If
          '    Catch ex As Exception

          '    End Try
          '    toCCCodeChanged = False
          '  End If
          'End If
          'If toCCCodeChanged Then
          '  dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '  If Me.txtAdjustPersonName.TextLength = 0 Then
          '    UpdateDestAdmin()
          '  End If
          '  toCCCodeChanged = False
          'End If

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
        Me.m_entity = CType(Value, WBSAdjust)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
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
      'PopulateAdjustPerson()
      'PopulateCostCenter()
      PopulateAllocateType()
    End Sub
    Private Sub PopulateAllocateType()
      Me.cmbAllocateType.Items.Clear()

      '    ('Global.AllocationType.PR','ขอซื้อ'),   
      '('Global.AllocationType.PO','สั่งซื้อ'),   
      '('Global.AllocationType.GR','รับของ'),   
      '('Global.AllocationType.MR','เบิกของ')   

      Dim idp As IdValuePair
      idp = New IdValuePair(7, Me.StringParserService.Parse("${res:Global.AllocationType.PR}"))
      Me.cmbAllocateType.Items.Add(idp)
      idp = New IdValuePair(6, Me.StringParserService.Parse("${res:Global.AllocationType.PO}"))
      Me.cmbAllocateType.Items.Add(idp)
      idp = New IdValuePair(45, Me.StringParserService.Parse("${res:Global.AllocationType.GR}"))
      Me.cmbAllocateType.Items.Add(idp)
      idp = New IdValuePair(31, Me.StringParserService.Parse("${res:Global.AllocationType.MR}"))
      Me.cmbAllocateType.Items.Add(idp)

      Me.cmbAllocateType.SelectedIndex = -1
    End Sub

#End Region

#Region "Event Handlers"
    'Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If
    '  Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
    '  If doc Is Nothing Then
    '    Return
    '  End If
    '  Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '  dt.Clear()
    '  Dim view As Integer = 7
    '  Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '  If wsdColl.GetSumPercent >= 100 Then
    '    msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '  ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
    '    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
    '  Else
    '    Dim wbsd As New WBSDistribute
    '    wbsd.CostCenter = Me.m_entity.CostCenter
    '    wbsd.Percent = 100 - wsdColl.GetSumPercent
    '    wsdColl.Add(wbsd)
    '  End If
    '  m_wbsdInitialized = False
    '  wsdColl.Populate(dt, doc, view)
    '  m_wbsdInitialized = True
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
    'Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '  dt.Clear()
    '  Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
    '  If doc Is Nothing Then
    '    Return
    '  End If
    '  Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '  If wsdColl.Count > 0 Then
    '    wsdColl.Remove(wsdColl.Count - 1)
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  End If
    '  Dim view As Integer = 7
    '  m_wbsdInitialized = False
    '  wsdColl.Populate(dt, doc, view)
    '  m_wbsdInitialized = True
    'End Sub
    Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY OrElse currentY = 0 OrElse currentY = -1 Then
        Me.m_entity.CurrentItem = Me.CurrentTagItem
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
      'Dim filters(0) As Filter
      'Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '  doc = New PRItem
      '  doc.ItemType = New ItemType(0)
      '  Me.m_entity.ItemCollection.Add(doc)
      '  Me.m_entity.ItemCollection.CurrentItem = doc
      'End If
      'Dim includeFilter As Boolean = False
      'If TypeOf doc.Entity Is Tool Then
      '  Dim mytool As Tool = CType(doc.Entity, Tool)
      '  If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
      '    filters(0) = New Filter("includedId", mytool.Unit.Id)
      '    includeFilter = True
      '  End If
      'ElseIf TypeOf doc.Entity Is LCIItem Then
      '  Dim idList As String = CType(doc.Entity, LCIItem).GetUnitIdList
      '  If idList.Length > 0 Then
      '    filters(0) = New Filter("includedId", idList)
      '    includeFilter = True
      '  End If
      'End If
      'If includeFilter Then
      '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
      'Else
      '  myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
      'End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      'Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        doc = New WBSAdjustItem
        doc.WBSAdjust = m_entity
        doc.ItemType = New AdjustAllocateType(0)
        Me.m_entity.ItemList.Add(doc)
        Me.m_entity.CurrentItem = doc
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
      Me.m_entity.SetItems(items, m_targetType)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Public Sub ItemCCButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
      If doc Is Nothing Then
        Return
      End If

      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog)

    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemList.Count - 1 Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim doc As New WBSAdjustItem
      doc.WBSAdjust = m_entity
      doc.Entity = newItem
      doc.ItemType = New AdjustAllocateType(0)
      'prItem.Qty = 0
      Me.m_entity.ItemList.Insert(index, doc)
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
            If TypeOf row.Tag Is WBSAdjustItem Then
              Dim doc As WBSAdjustItem = CType(row.Tag, WBSAdjustItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemList.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemList.Remove(doc)
      End If

      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("linenumber") = i + 1
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
        Return (New WBSAdjust).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      'arr.Add(Me.m_entity.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    End Sub
    ' AdjustPerson
    Private Sub btnAdjustPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustPersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub btnAdjustPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustPersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtAdjustPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
        Me.WorkbenchWindow.ViewContent.IsDirty _
        Or Employee.GetEmployee(txtAdjustPersonCode, txtAdjustPersonName, Me.m_entity.AdjustPerson)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)

      Dim doc As WBSAdjustItem = Me.m_entity.CurrentItem
      If doc Is Nothing Then
        Return
      End If

      doc.CostCenter = CType(e, CostCenter)
      RefreshDocs()
      'If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
      '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '  If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
      '    'If Me.txtCostCenterCode.TextLength = 0 Then
      '    '    Me.m_entity.CostCenter = New CostCenter
      '    'End If
      '    Me.txtCostCenterCode.Text = e.Code
      '    dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      '    If dirtyFlag Then
      '      UpdateDestAdmin()
      '    End If
      '    Try
      '      If oldCCId <> Me.m_entity.CostCenter.Id Then
      '        Me.WorkbenchWindow.ViewContent.IsDirty = True
      '        oldCCId = Me.m_entity.CostCenter.Id
      '        ChangeCC()
      '      End If
      '    Catch ex As Exception
      '    End Try
      '    toCCCodeChanged = False
      '  Else
      '    Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
      '    toCCCodeChanged = False
      '  End If
      'ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
      '  Me.txtCostCenterCode.Text = e.Code
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      '  dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      '  If dirtyFlag Then
      '    UpdateDestAdmin()
      '  End If
      'End If
      'SetCCCodeBlankFlag()
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
    'Private Sub ChangeCC()
    '  oldCCId = Me.m_entity.CostCenter.Id
    '  For Each item As PRItem In Me.m_entity.ItemCollection
    '    item.WBSDistributeCollection.Clear()
    '  Next
    '  If Not Me.m_entity.CostCenter Is Nothing Then
    '  End If
    '  RefreshDocs()
    '  'RefreshWBS()
    'End Sub
    'Private Sub UpdateDestAdmin()
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If
    '  Dim flag As Boolean = Me.m_isInitialized
    '  Me.m_isInitialized = False
    '  Try
    '    Me.m_entity.AdjustPerson = Me.m_entity.CostCenter.Admin
    '    Me.txtAdjustPersonCode.Text = m_entity.AdjustPerson.Code
    '    txtAdjustPersonName.Text = m_entity.AdjustPerson.Name
    '  Catch ex As Exception
    '  Finally
    '    Me.m_isInitialized = flag
    '  End Try
    'End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyCC)
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim x As Form
      'If m_ApproveDocModule.Activated Then
      '  x = New AdvanceApprovalCommentForm(Me.Entity)
      'Else
      '  x = New ApprovalCommentForm(Me.Entity)
      'End If
      'x.ShowDialog()
      'CheckFormEnable()
      ''ReloadEntity()
    End Sub
    'Private Sub btnApproveStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.Message.StoreApprove}", "${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.Caption.StoreApprove}") Then
    '    Dim theTime As Date = Now
    '    Dim approveError As SaveErrorException = Me.m_entity.ApproveStoreData(Me.m_entity.Id, SecurityService.CurrentUser.Id, theTime)
    '    If IsNumeric(approveError.Message) Then
    '      Me.m_entity.ApproveStoreDate = theTime
    '      Me.m_entity.ApproveStorePerson = SecurityService.CurrentUser
    '    Else
    '      MessageBox.Show(approveError.Message)
    '    End If
    '  End If
    '  CheckFormEnable()
    'End Sub

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((dummyEmployee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtAdjustPersoncode", "txtAdjustPersonname"
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
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((dummyEmployee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((dummyEmployee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtAdjustPersoncode", "txtAdjustPersonname"
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

      If Me.m_entity.ItemList.Count = Me.m_treeManager.Treetable.Childs.Count Then
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

    'Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  If Not m_isInitialized Then
    '    Return
    '  End If
    '  If Me.CheckForm = False Then

    '    CType(Me.Entity, PR).Closed = Me.chkClosed.Checked
    '    If CType(Me.Entity, PR).Closed Then
    '      Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.chkClosedCancel}")
    '      'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 100
    '      'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 110
    '    Else
    '      Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.chkClosed}")
    '      'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(8).Width = 0
    '      'm_treeManager.Treegrid.TableStyles(0).GridColumnStyles(12).Width = 0
    '    End If
    '    'Me.RefreshWBS()
    '    'Me.WorkbenchWindow.ViewContent.Save()
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  End If
    'End Sub
  End Class
End Namespace
