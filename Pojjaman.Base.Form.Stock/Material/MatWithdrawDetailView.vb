Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class MatWithdrawDetailView
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
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbFromCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents grbToCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
    Friend WithEvents lbltoCC As System.Windows.Forms.Label
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocType As System.Windows.Forms.Label
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkShowCost As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnShowFromCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    Friend WithEvents cmbInOut As System.Windows.Forms.ComboBox
    Friend WithEvents ibtnShowPR As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowEquipment As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEquipmentDiaog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaht2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTransferAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalTransferAmount As System.Windows.Forms.Label
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDiffAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDiffAmount As System.Windows.Forms.Label

    Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatWithdrawDetailView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ibtnShowPR = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbFromCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblFromCCPerson = New System.Windows.Forms.Label
      Me.lblFromCostCenter = New System.Windows.Forms.Label
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
      Me.ibtnShowFromCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbToCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnShowEquipment = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEquipmentName = New System.Windows.Forms.TextBox
      Me.ibtnShowEquipmentDiaog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEquipmentCode = New System.Windows.Forms.TextBox
      Me.lblEquipment = New System.Windows.Forms.Label
      Me.ibtnShowToCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
      Me.lblToCCPerson = New System.Windows.Forms.Label
      Me.lbltoCC = New System.Windows.Forms.Label
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox
      Me.cmbDocType = New System.Windows.Forms.ComboBox
      Me.lblDocType = New System.Windows.Forms.Label
      Me.txtAccount = New System.Windows.Forms.TextBox
      Me.lblAccount = New System.Windows.Forms.Label
      Me.txtAccountCode = New System.Windows.Forms.TextBox
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblBaht3 = New System.Windows.Forms.Label
      Me.txtTotalDiffAmount = New System.Windows.Forms.TextBox
      Me.lblTotalDiffAmount = New System.Windows.Forms.Label
      Me.lblBaht2 = New System.Windows.Forms.Label
      Me.txtTotalTransferAmount = New System.Windows.Forms.TextBox
      Me.lblTotalTransferAmount = New System.Windows.Forms.Label
      Me.txtItemCount = New System.Windows.Forms.TextBox
      Me.lblItemCount = New System.Windows.Forms.Label
      Me.lblItemCountUnit = New System.Windows.Forms.Label
      Me.lblBaht = New System.Windows.Forms.Label
      Me.txtTotalAmount = New System.Windows.Forms.TextBox
      Me.lblTotalAmount = New System.Windows.Forms.Label
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.lblStatus = New System.Windows.Forms.Label
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkShowCost = New System.Windows.Forms.CheckBox
      Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblWBS = New System.Windows.Forms.Label
      Me.cmbInOut = New System.Windows.Forms.ComboBox
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.grbFromCC.SuspendLayout()
      Me.grbToCC.SuspendLayout()
      Me.grbSummary.SuspendLayout()
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(210, Byte), CType(200, Byte), CType(120, Byte))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(8, 224)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(764, 160)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 3
      Me.tgItem.TreeManager = Nothing
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(696, 72)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ทั่วไป"
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 8
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(216, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 5
      Me.chkAutorun.TabStop = False
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(344, 15)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
      Me.txtDocDate.TabIndex = 1
      Me.txtDocDate.Text = ""
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDocDate.Location = New System.Drawing.Point(248, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDate.TabIndex = 6
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(344, 15)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 7
      Me.dtpDocDate.TabStop = False
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(592, 21)
      Me.txtNote.TabIndex = 2
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 40)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(80, 18)
      Me.lblNote.TabIndex = 4
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 3
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(24, 192)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(104, 19)
      Me.lblItem.TabIndex = 4
      Me.lblItem.Text = "รายการเบิกวัสดุ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowPR
      '
      Me.ibtnShowPR.Image = CType(resources.GetObject("ibtnShowPR.Image"), System.Drawing.Image)
      Me.ibtnShowPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnShowPR.Location = New System.Drawing.Point(136, 192)
      Me.ibtnShowPR.Name = "ibtnShowPR"
      Me.ibtnShowPR.Size = New System.Drawing.Size(40, 24)
      Me.ibtnShowPR.TabIndex = 43
      Me.ibtnShowPR.TabStop = False
      Me.ibtnShowPR.Text = "PR"
      Me.ibtnShowPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnShowPR.ThemedImage = CType(resources.GetObject("ibtnShowPR.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnShowPR, "PR")
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'grbFromCC
      '
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbFromCC.Controls.Add(Me.lblFromCCPerson)
      Me.grbFromCC.Controls.Add(Me.lblFromCostCenter)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonName)
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterName)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCostCenter)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCostCenterDialog)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCCPerson)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCCPersonDialog)
      Me.grbFromCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFromCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbFromCC.Location = New System.Drawing.Point(8, 80)
      Me.grbFromCC.Name = "grbFromCC"
      Me.grbFromCC.Size = New System.Drawing.Size(368, 72)
      Me.grbFromCC.TabIndex = 1
      Me.grbFromCC.TabStop = False
      Me.grbFromCC.Text = "ผู้ให้เบิก"
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(120, 16)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCostCenterCode.TabIndex = 0
      Me.txtFromCostCenterCode.Text = ""
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(104, 18)
      Me.lblFromCCPerson.TabIndex = 9
      Me.lblFromCCPerson.Text = "ผู้จ่าย:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(104, 18)
      Me.lblFromCostCenter.TabIndex = 8
      Me.lblFromCostCenter.Text = "จาก Cost Center:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCCPersonCode.TabIndex = 1
      Me.txtFromCCPersonCode.Text = ""
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(120, 21)
      Me.txtFromCCPersonName.TabIndex = 3
      Me.txtFromCCPersonName.TabStop = False
      Me.txtFromCCPersonName.Text = ""
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(120, 21)
      Me.txtFromCostCenterName.TabIndex = 2
      Me.txtFromCostCenterName.TabStop = False
      Me.txtFromCostCenterName.Text = ""
      '
      'ibtnShowFromCostCenter
      '
      Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenter.Image = CType(resources.GetObject("ibtnShowFromCostCenter.Image"), System.Drawing.Image)
      Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowFromCostCenter.Name = "ibtnShowFromCostCenter"
      Me.ibtnShowFromCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenter.TabIndex = 7
      Me.ibtnShowFromCostCenter.TabStop = False
      Me.ibtnShowFromCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCostCenterDialog
      '
      Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCostCenterDialog.Image = CType(resources.GetObject("ibtnShowFromCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(304, 16)
      Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
      Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenterDialog.TabIndex = 4
      Me.ibtnShowFromCostCenterDialog.TabStop = False
      Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCCPerson
      '
      Me.ibtnShowFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPerson.Image = CType(resources.GetObject("ibtnShowFromCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowFromCCPerson.Location = New System.Drawing.Point(328, 40)
      Me.ibtnShowFromCCPerson.Name = "ibtnShowFromCCPerson"
      Me.ibtnShowFromCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPerson.TabIndex = 6
      Me.ibtnShowFromCCPerson.TabStop = False
      Me.ibtnShowFromCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCCPersonDialog
      '
      Me.ibtnShowFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCCPersonDialog.Image = CType(resources.GetObject("ibtnShowFromCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowFromCCPersonDialog.Location = New System.Drawing.Point(304, 40)
      Me.ibtnShowFromCCPersonDialog.Name = "ibtnShowFromCCPersonDialog"
      Me.ibtnShowFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPersonDialog.TabIndex = 5
      Me.ibtnShowFromCCPersonDialog.TabStop = False
      Me.ibtnShowFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbToCC
      '
      Me.grbToCC.Controls.Add(Me.ibtnShowEquipment)
      Me.grbToCC.Controls.Add(Me.txtEquipmentName)
      Me.grbToCC.Controls.Add(Me.ibtnShowEquipmentDiaog)
      Me.grbToCC.Controls.Add(Me.txtEquipmentCode)
      Me.grbToCC.Controls.Add(Me.lblEquipment)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCCPerson)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCCPersonDialog)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCostCenter)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCostCenterDialog)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonCode)
      Me.grbToCC.Controls.Add(Me.lblToCCPerson)
      Me.grbToCC.Controls.Add(Me.lbltoCC)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterCode)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonName)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterName)
      Me.grbToCC.Controls.Add(Me.cmbDocType)
      Me.grbToCC.Controls.Add(Me.lblDocType)
      Me.grbToCC.Controls.Add(Me.txtAccount)
      Me.grbToCC.Controls.Add(Me.lblAccount)
      Me.grbToCC.Controls.Add(Me.txtAccountCode)
      Me.grbToCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbToCC.Location = New System.Drawing.Point(384, 80)
      Me.grbToCC.Name = "grbToCC"
      Me.grbToCC.Size = New System.Drawing.Size(384, 144)
      Me.grbToCC.TabIndex = 2
      Me.grbToCC.TabStop = False
      Me.grbToCC.Text = "ผู้ขอเบิก"
      '
      'ibtnShowEquipment
      '
      Me.ibtnShowEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipment.Image = CType(resources.GetObject("ibtnShowEquipment.Image"), System.Drawing.Image)
      Me.ibtnShowEquipment.Location = New System.Drawing.Point(352, 112)
      Me.ibtnShowEquipment.Name = "ibtnShowEquipment"
      Me.ibtnShowEquipment.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipment.TabIndex = 283
      Me.ibtnShowEquipment.TabStop = False
      Me.ibtnShowEquipment.ThemedImage = CType(resources.GetObject("ibtnShowEquipment.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEquipmentName
      '
      Me.txtEquipmentName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEquipmentName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEquipmentName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
      Me.txtEquipmentName.Location = New System.Drawing.Point(208, 112)
      Me.Validator.SetMaxValue(Me.txtEquipmentName, "")
      Me.Validator.SetMinValue(Me.txtEquipmentName, "")
      Me.txtEquipmentName.Name = "txtEquipmentName"
      Me.txtEquipmentName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEquipmentName, "")
      Me.Validator.SetRequired(Me.txtEquipmentName, False)
      Me.txtEquipmentName.Size = New System.Drawing.Size(120, 21)
      Me.txtEquipmentName.TabIndex = 285
      Me.txtEquipmentName.TabStop = False
      Me.txtEquipmentName.Text = ""
      '
      'ibtnShowEquipmentDiaog
      '
      Me.ibtnShowEquipmentDiaog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipmentDiaog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEquipmentDiaog.Image = CType(resources.GetObject("ibtnShowEquipmentDiaog.Image"), System.Drawing.Image)
      Me.ibtnShowEquipmentDiaog.Location = New System.Drawing.Point(328, 112)
      Me.ibtnShowEquipmentDiaog.Name = "ibtnShowEquipmentDiaog"
      Me.ibtnShowEquipmentDiaog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipmentDiaog.TabIndex = 282
      Me.ibtnShowEquipmentDiaog.TabStop = False
      Me.ibtnShowEquipmentDiaog.ThemedImage = CType(resources.GetObject("ibtnShowEquipmentDiaog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEquipmentCode
      '
      Me.txtEquipmentCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEquipmentCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEquipmentCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
      Me.txtEquipmentCode.Location = New System.Drawing.Point(144, 112)
      Me.Validator.SetMaxValue(Me.txtEquipmentCode, "")
      Me.Validator.SetMinValue(Me.txtEquipmentCode, "")
      Me.txtEquipmentCode.Name = "txtEquipmentCode"
      Me.Validator.SetRegularExpression(Me.txtEquipmentCode, "")
      Me.Validator.SetRequired(Me.txtEquipmentCode, False)
      Me.txtEquipmentCode.Size = New System.Drawing.Size(64, 21)
      Me.txtEquipmentCode.TabIndex = 281
      Me.txtEquipmentCode.Text = ""
      '
      'lblEquipment
      '
      Me.lblEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquipment.Location = New System.Drawing.Point(32, 112)
      Me.lblEquipment.Name = "lblEquipment"
      Me.lblEquipment.Size = New System.Drawing.Size(96, 18)
      Me.lblEquipment.TabIndex = 284
      Me.lblEquipment.Text = "เครื่องจักร:"
      Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToCCPerson
      '
      Me.ibtnShowToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPerson.Image = CType(resources.GetObject("ibtnShowToCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPerson.Location = New System.Drawing.Point(352, 40)
      Me.ibtnShowToCCPerson.Name = "ibtnShowToCCPerson"
      Me.ibtnShowToCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPerson.TabIndex = 16
      Me.ibtnShowToCCPerson.TabStop = False
      Me.ibtnShowToCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowToCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCCPersonDialog
      '
      Me.ibtnShowToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCCPersonDialog.Image = CType(resources.GetObject("ibtnShowToCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPersonDialog.Location = New System.Drawing.Point(328, 40)
      Me.ibtnShowToCCPersonDialog.Name = "ibtnShowToCCPersonDialog"
      Me.ibtnShowToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPersonDialog.TabIndex = 15
      Me.ibtnShowToCCPersonDialog.TabStop = False
      Me.ibtnShowToCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCostCenter
      '
      Me.ibtnShowToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenter.Image = CType(resources.GetObject("ibtnShowToCostCenter.Image"), System.Drawing.Image)
      Me.ibtnShowToCostCenter.Location = New System.Drawing.Point(352, 16)
      Me.ibtnShowToCostCenter.Name = "ibtnShowToCostCenter"
      Me.ibtnShowToCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenter.TabIndex = 14
      Me.ibtnShowToCostCenter.TabStop = False
      Me.ibtnShowToCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCostCenterDialog
      '
      Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCostCenterDialog.Image = CType(resources.GetObject("ibtnShowToCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
      Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenterDialog.TabIndex = 13
      Me.ibtnShowToCostCenterDialog.TabStop = False
      Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCCPersonCode
      '
      Me.txtToCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(144, 40)
      Me.Validator.SetMaxValue(Me.txtToCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, True)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtToCCPersonCode.TabIndex = 1
      Me.txtToCCPersonCode.Text = ""
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(16, 40)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(112, 18)
      Me.lblToCCPerson.TabIndex = 5
      Me.lblToCCPerson.Text = "ผู้เบิก:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbltoCC
      '
      Me.lbltoCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltoCC.Location = New System.Drawing.Point(16, 16)
      Me.lbltoCC.Name = "lbltoCC"
      Me.lbltoCC.Size = New System.Drawing.Size(112, 18)
      Me.lbltoCC.TabIndex = 4
      Me.lbltoCC.Text = "เบิกเข้า Cost Center:"
      Me.lbltoCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCostCenterCode
      '
      Me.txtToCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(144, 16)
      Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(64, 21)
      Me.txtToCostCenterCode.TabIndex = 0
      Me.txtToCostCenterCode.Text = ""
      '
      'txtToCCPersonName
      '
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(208, 40)
      Me.Validator.SetMaxValue(Me.txtToCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(120, 21)
      Me.txtToCCPersonName.TabIndex = 11
      Me.txtToCCPersonName.TabStop = False
      Me.txtToCCPersonName.Text = ""
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(208, 16)
      Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(120, 21)
      Me.txtToCostCenterName.TabIndex = 12
      Me.txtToCostCenterName.TabStop = False
      Me.txtToCostCenterName.Text = ""
      '
      'cmbDocType
      '
      Me.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocType.Location = New System.Drawing.Point(144, 64)
      Me.cmbDocType.Name = "cmbDocType"
      Me.cmbDocType.Size = New System.Drawing.Size(232, 21)
      Me.cmbDocType.TabIndex = 2
      '
      'lblDocType
      '
      Me.lblDocType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocType.Location = New System.Drawing.Point(16, 64)
      Me.lblDocType.Name = "lblDocType"
      Me.lblDocType.Size = New System.Drawing.Size(112, 18)
      Me.lblDocType.TabIndex = 6
      Me.lblDocType.Text = "จุดประสงค์การเบิก:"
      Me.lblDocType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccount
      '
      Me.Validator.SetDataType(Me.txtAccount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccount, "")
      Me.txtAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.txtAccount.Location = New System.Drawing.Point(208, 88)
      Me.Validator.SetMaxValue(Me.txtAccount, "")
      Me.Validator.SetMinValue(Me.txtAccount, "")
      Me.txtAccount.Name = "txtAccount"
      Me.txtAccount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccount, "")
      Me.Validator.SetRequired(Me.txtAccount, False)
      Me.txtAccount.Size = New System.Drawing.Size(168, 21)
      Me.txtAccount.TabIndex = 10
      Me.txtAccount.TabStop = False
      Me.txtAccount.Text = ""
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(16, 88)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(112, 18)
      Me.lblAccount.TabIndex = 7
      Me.lblAccount.Text = "ผังบัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(144, 88)
      Me.Validator.SetMaxValue(Me.txtAccountCode, "")
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.txtAccountCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(64, 21)
      Me.txtAccountCode.TabIndex = 9
      Me.txtAccountCode.TabStop = False
      Me.txtAccountCode.Text = ""
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.lblBaht3)
      Me.grbSummary.Controls.Add(Me.txtTotalDiffAmount)
      Me.grbSummary.Controls.Add(Me.lblTotalDiffAmount)
      Me.grbSummary.Controls.Add(Me.lblBaht2)
      Me.grbSummary.Controls.Add(Me.txtTotalTransferAmount)
      Me.grbSummary.Controls.Add(Me.lblTotalTransferAmount)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.Controls.Add(Me.lblBaht)
      Me.grbSummary.Controls.Add(Me.txtTotalAmount)
      Me.grbSummary.Controls.Add(Me.lblTotalAmount)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbSummary.Location = New System.Drawing.Point(408, 402)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(360, 117)
      Me.grbSummary.TabIndex = 9
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปยอดเบิกวัสดุ"
      '
      'lblBaht3
      '
      Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht3.Location = New System.Drawing.Point(304, 88)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht3.TabIndex = 11
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.lblBaht3.Visible = False
      '
      'txtTotalDiffAmount
      '
      Me.txtTotalDiffAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalDiffAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalDiffAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalDiffAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalDiffAmount, System.Drawing.Color.Empty)
      Me.txtTotalDiffAmount.Location = New System.Drawing.Point(184, 88)
      Me.Validator.SetMaxValue(Me.txtTotalDiffAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalDiffAmount, "")
      Me.txtTotalDiffAmount.Name = "txtTotalDiffAmount"
      Me.txtTotalDiffAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalDiffAmount, "")
      Me.Validator.SetRequired(Me.txtTotalDiffAmount, False)
      Me.txtTotalDiffAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalDiffAmount.TabIndex = 10
      Me.txtTotalDiffAmount.TabStop = False
      Me.txtTotalDiffAmount.Text = ""
      Me.txtTotalDiffAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtTotalDiffAmount.Visible = False
      '
      'lblTotalDiffAmount
      '
      Me.lblTotalDiffAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalDiffAmount.Location = New System.Drawing.Point(8, 88)
      Me.lblTotalDiffAmount.Name = "lblTotalDiffAmount"
      Me.lblTotalDiffAmount.Size = New System.Drawing.Size(168, 18)
      Me.lblTotalDiffAmount.TabIndex = 9
      Me.lblTotalDiffAmount.Text = "มูลค่าสินค้าที่เบิก"
      Me.lblTotalDiffAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblTotalDiffAmount.Visible = False
      '
      'lblBaht2
      '
      Me.lblBaht2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht2.Location = New System.Drawing.Point(304, 64)
      Me.lblBaht2.Name = "lblBaht2"
      Me.lblBaht2.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht2.TabIndex = 8
      Me.lblBaht2.Text = "บาท"
      Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.lblBaht2.Visible = False
      '
      'txtTotalTransferAmount
      '
      Me.txtTotalTransferAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalTransferAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalTransferAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalTransferAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalTransferAmount, System.Drawing.Color.Empty)
      Me.txtTotalTransferAmount.Location = New System.Drawing.Point(184, 64)
      Me.Validator.SetMaxValue(Me.txtTotalTransferAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalTransferAmount, "")
      Me.txtTotalTransferAmount.Name = "txtTotalTransferAmount"
      Me.txtTotalTransferAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalTransferAmount, "")
      Me.Validator.SetRequired(Me.txtTotalTransferAmount, False)
      Me.txtTotalTransferAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalTransferAmount.TabIndex = 7
      Me.txtTotalTransferAmount.TabStop = False
      Me.txtTotalTransferAmount.Text = ""
      Me.txtTotalTransferAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtTotalTransferAmount.Visible = False
      '
      'lblTotalTransferAmount
      '
      Me.lblTotalTransferAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalTransferAmount.Location = New System.Drawing.Point(8, 64)
      Me.lblTotalTransferAmount.Name = "lblTotalTransferAmount"
      Me.lblTotalTransferAmount.Size = New System.Drawing.Size(168, 18)
      Me.lblTotalTransferAmount.TabIndex = 6
      Me.lblTotalTransferAmount.Text = "มูลค่าสินค้าที่เบิก"
      Me.lblTotalTransferAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblTotalTransferAmount.Visible = False
      '
      'txtItemCount
      '
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMaxValue(Me.txtItemCount, "")
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(112, 21)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.TabStop = False
      Me.txtItemCount.Text = ""
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItemCount
      '
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(168, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการสินค้า"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(304, 16)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(304, 40)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht.TabIndex = 5
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtTotalAmount
      '
      Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.txtTotalAmount.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMaxValue(Me.txtTotalAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Name = "txtTotalAmount"
      Me.txtTotalAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
      Me.Validator.SetRequired(Me.txtTotalAmount, False)
      Me.txtTotalAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalAmount.TabIndex = 4
      Me.txtTotalAmount.TabStop = False
      Me.txtTotalAmount.Text = ""
      Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalAmount
      '
      Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalAmount.Location = New System.Drawing.Point(8, 40)
      Me.lblTotalAmount.Name = "lblTotalAmount"
      Me.lblTotalAmount.Size = New System.Drawing.Size(168, 18)
      Me.lblTotalAmount.TabIndex = 3
      Me.lblTotalAmount.Text = "มูลค่าสินค้าที่เบิก"
      Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStatus.Location = New System.Drawing.Point(16, 160)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 8
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(192, 192)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 6
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(216, 192)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 7
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkShowCost
      '
      Me.chkShowCost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowCost.Location = New System.Drawing.Point(272, 192)
      Me.chkShowCost.Name = "chkShowCost"
      Me.chkShowCost.TabIndex = 5
      Me.chkShowCost.Text = "chkShowCost"
      '
      'tgWBS
      '
      Me.tgWBS.AllowNew = False
      Me.tgWBS.AllowSorting = False
      Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgWBS.AutoColumnResize = True
      Me.tgWBS.CaptionVisible = False
      Me.tgWBS.Cellchanged = False
      Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
      Me.tgWBS.DataMember = ""
      Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgWBS.Location = New System.Drawing.Point(8, 408)
      Me.tgWBS.Name = "tgWBS"
      Me.tgWBS.Size = New System.Drawing.Size(312, 112)
      Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
      Me.tgWBS.TabIndex = 32
      Me.tgWBS.TreeManager = Nothing
      '
      'ibtnAddWBS
      '
      Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
      Me.ibtnAddWBS.Location = New System.Drawing.Point(320, 408)
      Me.ibtnAddWBS.Name = "ibtnAddWBS"
      Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddWBS.TabIndex = 34
      Me.ibtnAddWBS.TabStop = False
      Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelWBS
      '
      Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
      Me.ibtnDelWBS.Location = New System.Drawing.Point(344, 408)
      Me.ibtnDelWBS.Name = "ibtnDelWBS"
      Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelWBS.TabIndex = 35
      Me.ibtnDelWBS.TabStop = False
      Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWBS
      '
      Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWBS.ForeColor = System.Drawing.Color.Black
      Me.lblWBS.Location = New System.Drawing.Point(8, 392)
      Me.lblWBS.Name = "lblWBS"
      Me.lblWBS.Size = New System.Drawing.Size(104, 18)
      Me.lblWBS.TabIndex = 33
      Me.lblWBS.Text = "จัดสรร WBS:"
      Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmbInOut
      '
      Me.cmbInOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmbInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbInOut.Location = New System.Drawing.Point(104, 384)
      Me.cmbInOut.Name = "cmbInOut"
      Me.cmbInOut.TabIndex = 36
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(672, 16)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(104, 23)
      Me.btnApprove.TabIndex = 332
      Me.btnApprove.Text = "อนุมัติเอกสาร"
      Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnApprove.ThemedImage = Nothing
      '
      'MatWithdrawDetailView
      '
      Me.Controls.Add(Me.btnApprove)
      Me.Controls.Add(Me.ibtnShowPR)
      Me.Controls.Add(Me.cmbInOut)
      Me.Controls.Add(Me.tgWBS)
      Me.Controls.Add(Me.ibtnAddWBS)
      Me.Controls.Add(Me.ibtnDelWBS)
      Me.Controls.Add(Me.lblWBS)
      Me.Controls.Add(Me.chkShowCost)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblStatus)
      Me.Controls.Add(Me.grbFromCC)
      Me.Controls.Add(Me.grbToCC)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "MatWithdrawDetailView"
      Me.Size = New System.Drawing.Size(780, 528)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbFromCC.ResumeLayout(False)
      Me.grbToCC.ResumeLayout(False)
      Me.grbSummary.ResumeLayout(False)
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
#End Region

#Region "Members"
    Private m_entity As MatWithdraw
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean
    Private m_combocodeindex As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = MatWithdraw.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf MWItemDelete

      Dim dt2 As TreeTable = WBSDistribute.GetSchemaTable()
      Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
      m_treeManager2 = New TreeManager(dt2, tgWBS)
      m_treeManager2.SetTableStyle(dst2)
      m_treeManager2.AllowSorting = False
      m_treeManager2.AllowDelete = False

      AddHandler dt2.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt2.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt2.RowDeleted, AddressOf ItemDelete

      EventWiring()
      SetFormVisible()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbFromCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbSummary.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbToCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
    Private Sub SetFormVisible()
      Dim config As Object = Configuration.GetConfig("DisableTransferUnitCost")
      If config Then
        lblTotalTransferAmount.Visible = False
        txtTotalTransferAmount.Visible = False
        lblBaht2.Visible = False
        lblTotalDiffAmount.Visible = False
        txtTotalDiffAmount.Visible = False
        lblBaht3.Visible = False
      End If
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "WBS"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csCostCenter As New TreeTextColumn
      csCostCenter.MappingName = "CostCenter"
      csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CCHeaderText}")
      csCostCenter.NullText = ""
      csCostCenter.Width = 100
      csCostCenter.ReadOnly = True
      csCostCenter.TextBox.Name = "CostCenter"

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""

      Dim csWBS As New TreeTextColumn
      csWBS.MappingName = "WBS"
      csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
      csWBS.NullText = ""
      csWBS.Width = 100
      csWBS.ReadOnly = True
      csWBS.TextBox.Name = "WBS"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf WBStgButtonClicked

      Dim csPercent As New TreeTextColumn
      csPercent.MappingName = "Percent"
      csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
      csPercent.NullText = ""
      csPercent.DataAlignment = HorizontalAlignment.Right
      csPercent.Format = "#,###.##"
      csPercent.Width = 70
      csPercent.TextBox.Name = "Percent"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      'csAmount.ReadOnly = True

      Dim csBudgetRemain As New TreeTextColumn
      csBudgetRemain.MappingName = "BudgetRemain"
      csBudgetRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.BudgetRemainHeaderText}")
      csBudgetRemain.NullText = ""
      csBudgetRemain.Alignment = HorizontalAlignment.Right
      csBudgetRemain.DataAlignment = HorizontalAlignment.Right
      csBudgetRemain.Format = "#,###.##"
      csBudgetRemain.TextBox.Name = "BudgetRemain"
      csBudgetRemain.ReadOnly = True

      Dim csQtyRemain As New TreeTextColumn
      csQtyRemain.MappingName = "QtyRemain"
      csQtyRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyRemainHeaderText}")
      csQtyRemain.NullText = ""
      csQtyRemain.Alignment = HorizontalAlignment.Right
      csQtyRemain.DataAlignment = HorizontalAlignment.Right
      csQtyRemain.Format = "#,###.##"
      csQtyRemain.TextBox.Name = "QtyRemain"
      csQtyRemain.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCostCenter)
      dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csWBS)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csPercent)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBudgetRemain)
      dst.GridColumnStyles.Add(csQtyRemain)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Public Sub WBStgButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 4 Then
        Me.WBSButtonClicked(e)
      Else
        Me.CCButtonClicked(e)
      End If
    End Sub
    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CostCenter
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      Dim wsdColl As WBSDistributeCollection
      Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      If TypeOf myEntity Is CostCenter Then
        CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter) 'Me.m_entity.ToCostCenter
        CType(row.Tag, WBSDistribute).WBS = New WBS
      End If
      Dim view As Integer = 45
      If IsOut() Then
        view = 45
      Else
        view = 31
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view, IsOut)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim cc As CostCenter
      If Not IsOut() Then
        cc = Me.m_entity.ToCostCenter
      Else
        cc = Me.m_entity.FromCostCenter
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New WBS
      Dim filters() As Filter
      Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      Dim myBOQId As Integer
      If Not CType(row.Tag, WBSDistribute).CostCenter Is Nothing AndAlso CType(row.Tag, WBSDistribute).CostCenter.BoqId > 0 Then
        myBOQId = CType(row.Tag, WBSDistribute).CostCenter.BoqId
      Else
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If cc Is Nothing Then
          msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
          Return
        End If
        If cc.BoqId = 0 Then
          msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
          Return
        End If
        myBOQId = cc.BoqId
        CType(row.Tag, WBSDistribute).CostCenter = cc
      End If
      If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> myBOQId Then
        m_wbsColl = New WBSCollection(myBOQId)
      End If
      If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> myBOQId Then
        m_mrkColl = New MarkupCollection(myBOQId)
      End If
      filters = New Filter() {New Filter("mrkColl", m_mrkColl) _
                              , New Filter("wbsColl", m_wbsColl)}
      Dim entities As New ArrayList
      entities.Add(entity)
      myEntityPanelService.OpenListDialog(entity, AddressOf SetWBS, filters, entities)
    End Sub
    Private Sub SetWBS(ByVal myEntity As ISimpleEntity)
      Dim view As Integer = 31
      If IsOut() Then
        view = 45
      Else
        view = 31
      End If
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      If TypeOf myEntity Is WBS Then
        CType(row.Tag, WBSDistribute).WBS = CType(myEntity, WBS)
        CType(row.Tag, WBSDistribute).IsMarkup = False
      ElseIf TypeOf myEntity Is Markup Then
        Dim newWBS As New WBS
        Dim myMarkup As Markup = CType(myEntity, Markup)
        newWBS.Id = myMarkup.Id
        newWBS.Code = myMarkup.Code
        newWBS.Name = myMarkup.Name
        CType(row.Tag, WBSDistribute).WBS = newWBS
        CType(row.Tag, WBSDistribute).IsMarkup = True
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view, IsOut)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private ReadOnly Property CurrentWsbsd() As WBSDistribute
      Get
        Dim row As TreeRow = Me.m_treeManager2.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSDistribute)
      End Get
    End Property
    Public Function CreateTableStyle() As DataGridTableStyle
      Return CreateTableStyle(True)
    End Function
    Public Function CreateTableStyle(ByVal group As Boolean) As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "MatWithdraw"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csPRItemCode As New TreeTextColumn
      csPRItemCode.MappingName = "PRItemCode"
      csPRItemCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemCodeHeaderText}")
      csPRItemCode.NullText = ""
      csPRItemCode.ReadOnly = True
      csPRItemCode.TextBox.Name = "PRItemCode"

      Dim csPRItemName As New TreeTextColumn
      csPRItemName.MappingName = "PRItemName"
      csPRItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemNameHeaderText}")
      csPRItemName.NullText = ""
      csPRItemName.ReadOnly = True
      csPRItemName.TextBox.Name = "PRItemName"

      Dim csPRItemUnit As New TreeTextColumn
      csPRItemUnit.MappingName = "PRItemUnit"
      csPRItemUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemUnitHeaderText}")
      csPRItemUnit.NullText = ""
      csPRItemUnit.ReadOnly = True
      csPRItemUnit.Width = 50
      csPRItemUnit.TextBox.Name = "PRItemUnit"

      Dim csPRItemQty As New TreeTextColumn
      csPRItemQty.MappingName = "pri_qty"
      csPRItemQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemQtyHeaderText}")
      csPRItemQty.NullText = ""
      csPRItemQty.ReadOnly = True
      csPRItemQty.TextBox.Name = "pri_qty"

      Dim csPRItemRemainingQty As New TreeTextColumn
      csPRItemRemainingQty.MappingName = "PRItemRemainingQty"
      csPRItemRemainingQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemRemainingQtyHeaderText}")
      csPRItemRemainingQty.NullText = ""
      csPRItemRemainingQty.DataAlignment = HorizontalAlignment.Right
      csPRItemRemainingQty.Format = "#,###.##"
      csPRItemRemainingQty.TextBox.Name = "PRItemRemainingQty"

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csBarrier As New DataGridBarrierColumn
      csBarrier.MappingName = "Barrier"
      csBarrier.HeaderText = ""
      csBarrier.NullText = ""
      csBarrier.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 70
      csCode.ReadOnly = Not group
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""


      Dim csstocki_itemName As New TreeTextColumn
      csstocki_itemName.MappingName = "stocki_itemName"
      csstocki_itemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.DescriptionHeaderText}")
      csstocki_itemName.NullText = ""
      csstocki_itemName.Width = 180
      csstocki_itemName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csstocki_itemName.ReadOnly = True

      Dim csDefaultUnit As New TreeTextColumn
      csDefaultUnit.MappingName = "DefaultUnit"
      csDefaultUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.DefaultUnitHeaderText}")
      csDefaultUnit.NullText = ""
      csDefaultUnit.ReadOnly = True
      If group Then
        csDefaultUnit.Width = 0
      Else
        csDefaultUnit.Width = 90
      End If

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      csUnit.Width = 50
      csUnit.ReadOnly = Not group

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.Width = 60
      csQty.ReadOnly = Not group

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.DataAlignment = HorizontalAlignment.Right
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True
      If group Then
        csStockQty.Width = 0
      Else
        csStockQty.Width = 90
      End If

      Dim csTransferUnitPrice As New TreeTextColumn
      csTransferUnitPrice.MappingName = "stocki_transferunitprice"
      csTransferUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.TransferUnitPriceHeaderText}")
      csTransferUnitPrice.NullText = ""
      csTransferUnitPrice.DataAlignment = HorizontalAlignment.Right
      csTransferUnitPrice.Format = "#,###.##"
      csTransferUnitPrice.ReadOnly = Not group
      'Dim config As Object = Configuration.GetConfig("DisableTransferUnitCost")
      'If config Then
        csTransferUnitPrice.Width = 0
      'End If

      Dim csTransferAmount As New TreeTextColumn
      csTransferAmount.MappingName = "stocki_transferamt"
      csTransferAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.TransferAmountHeaderText}")
      csTransferAmount.NullText = ""
      csTransferAmount.DataAlignment = HorizontalAlignment.Right
      csTransferAmount.Format = "#,###.##"
      csTransferAmount.Width = 60
      csTransferAmount.ReadOnly = True

      Dim csUnitCost As New TreeTextColumn
      csUnitCost.MappingName = "stocki_unitcost"
      csUnitCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.UnitCostHeaderText}")
      csUnitCost.NullText = ""
      csUnitCost.TextBox.Name = "stocki_unitcost"
      csUnitCost.DataAlignment = HorizontalAlignment.Right
      csUnitCost.ReadOnly = True
      If group Then
        csUnitCost.Width = 0
      Else
        csUnitCost.Width = 90
      End If

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 150
      csNote.TextBox.Name = "stocki_note"
      csNote.ReadOnly = Not group

      dst.GridColumnStyles.Add(csPRItemCode)
      dst.GridColumnStyles.Add(csPRItemName)
      dst.GridColumnStyles.Add(csPRItemUnit)
      'dst.GridColumnStyles.Add(csPRItemQty)
      'dst.GridColumnStyles.Add(csPRItemRemainingQty)

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csBarrier)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csstocki_itemName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csDefaultUnit)
      dst.GridColumnStyles.Add(csStockQty)
      dst.GridColumnStyles.Add(csUnitCost)
      dst.GridColumnStyles.Add(csTransferUnitPrice)
      dst.GridColumnStyles.Add(csTransferAmount)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ToggleStyle(ByVal dst As DataGridTableStyle)
      For Each col As DataGridColumnStyle In dst.GridColumnStyles
        Select Case col.MappingName.ToLower
          Case "code", "unit", "stocki_qty", "stocki_note"
            If Me.m_entity.Grouping Then
              col.ReadOnly = CBool(Me.m_tableStyleEnable(col))
            Else
              col.ReadOnly = True
            End If
          Case "stocki_unitcost", "defaultunit", "stockqty"
            If Me.m_entity.Grouping Then
              col.Width = 0
            Else
              col.Width = 90
            End If
        End Select
      Next
    End Sub
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 8 Then
        Me.UnitClicked(e)
      ElseIf e.Column = 5 Then
        Me.LCIClicked(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As MatWithdrawItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is MatWithdrawItem Then
          Return Nothing
        End If
        Return CType(row.Tag, MatWithdrawItem)
      End Get
    End Property

    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
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
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatWithdrawItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue), Me.m_entity.FromCC.Id)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "stocki_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If IsNumeric(e.ProposedValue.ToString) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              Dim remaining As Decimal = 0

              If Not (doc.Pritem Is Nothing) Then
                remaining = doc.AllowWithdrawFromPR
              Else
                remaining = doc.GetAmountFromSproc(doc.Entity.Id, Me.m_entity.FromCC.Id)
              End If

              Dim xCompare As String = Configuration.FormatToString(value, DigitConfig.Price)
              Dim yCompare As String = Configuration.FormatToString((remaining / doc.Conversion), DigitConfig.Price)
              'MessageBox.Show(doc.OldRemainingQty.ToString & vbCrLf & doc.Conversion.ToString)
              If value > (remaining / doc.Conversion) Then
                If Not msgServ.AskQuestionFormatted("", "${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.InvalidQty}", New String() {xCompare, yCompare}) Then
                  e.ProposedValue = (remaining / doc.Conversion)
                  doc.Qty = e.ProposedValue
                  Return
                End If
              End If
              'If (value * doc.Conversion) > (doc.OldQty Or doc.OldQty2) Then
              '  If doc.OldQty > 0 Then
              '    'เทจากตะกร้า
              '    msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Error.MatReturnDetailView.Remain}", New String() {(doc.OldQty / doc.Conversion).ToString})
              '  Else
              '    'คีย์โค้ดเองแล้ว enter
              '    msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Error.MatReturnDetailView.Remain}", New String() {(doc.OldQty2 / doc.Conversion).ToString})
              '  End If
              '  Return
              'End If

              'If Not (doc.Pritem Is Nothing) Then
              'If value > (((doc.Pritem.Qty - doc.Pritem.WithdrawnQty) * doc.Pritem.Conversion) / doc.Conversion) Then
              'doc.Qty = ((doc.Pritem.Qty - doc.Pritem.WithdrawnQty) * doc.Pritem.Conversion) / doc.Conversion
              'Else
              'doc.Qty = value
              'End If
              'Else
              doc.Qty = value
              'End If
            End If
          Case "stocki_transferunitprice"
            'If IsDBNull(e.ProposedValue) Then
            '  e.ProposedValue = ""
            'End If
            'If IsNumeric(e.ProposedValue.ToString) Then
            '  Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            '  doc.TransferUnitPrice = value
            'End If
          Case "stocki_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub MWItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsdInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_treeManager2.Treetable.AcceptChanges()
      End If
      RefreshWBS()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsdInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "wbs"
            SetCode(e)
          Case "percent"
            SetPercent(e)
          Case "amount"
            SetAmount(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim wbs As Object = e.Row("wbs")
      Dim percent As Object = e.Row("percent")

      Select Case e.Column.ColumnName.ToLower
        Case "wbs"
          wbs = e.ProposedValue
        Case "percent"
          percent = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(wbs) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
          e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
        Else
          e.Row.SetColumnError("percent", "")
        End If
        If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
          e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
        Else
          e.Row.SetColumnError("wbs", "")
        End If
      End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("WBS") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As WBSDistribute = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      If wsdColl.GetSumPercent - oldvalue + value > 100 Then
        e.ProposedValue = e.Row(e.Column)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        Return
      End If

      m_updating = True
      item.Percent = value
      m_updating = False
    End Sub
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As WBSDistribute = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If

      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      If wsdColl.GetSumPercent - oldvalue + value > 100 Then
        e.ProposedValue = e.Row(e.Column)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        Return
      End If

      m_updating = True
      item.Amount = value
      m_updating = False
    End Sub
    'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '    If e.Row.IsNull("stocki_entityType") Then
    '        Return False
    '    End If
    '    If IsDBNull(e.ProposedValue) Then
    '        Return False
    '    End If
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '        If Not row Is e.Row Then
    '            If Not row.IsNull("stocki_entityType") Then
    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '                    If Not row.IsNull("code") Then
    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '                            Return True
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    Return False
    'End Function
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_updating Then
      '    Return
      'End If
      'm_updating = True
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If e.Row.IsNull("stocki_entityType") Then
      '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      'If DupCode(e) Then
      '    Dim item As New MatwithdrawItem
      '    item.CopyFromDataRow(CType(e.Row, TreeRow))
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      'Select Case CInt(e.Row("stocki_entityType"))
      '    Case 0 'Blank
      '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      '    Case 28 'F/A
      '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      '    Case 19 'Tool
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_updating = False
      '            Return
      '        End If
      '        Dim myTool As New Tool(e.ProposedValue.ToString)
      '        If Not myTool.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_updating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = myTool.Unit
      '            e.Row("stocki_entity") = myTool.Id
      '            e.ProposedValue = myTool.Code
      '            e.Row("stocki_itemName") = myTool.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
      '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
      '                e.Row("stocki_acct") = ga.Account.Id
      '                e.Row("AccountCode") = ga.Account.Code
      '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case 42 'LCI
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_updating = False
      '            Return
      '        End If
      '        Dim lci As New LCIItem(e.ProposedValue.ToString)
      '        If Not lci.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_updating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = lci.DefaultUnit
      '            e.Row("stocki_entity") = lci.Id
      '            e.ProposedValue = lci.Code
      '            e.Row("stocki_itemName") = lci.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
      '                e.Row("stocki_acct") = lci.Account.Id
      '                e.Row("AccountCode") = lci.Account.Code
      '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case Else
      '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      'End Select
      'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'm_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      CheckApproveStore()
      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      Then
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbFromCC.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbSummary.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbToCC.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
        'ปลด lock WBS
        Me.tgWBS.Enabled = True
        Me.ibtnAddWBS.Enabled = True
        Me.ibtnDelWBS.Enabled = True
        Me.cmbInOut.Enabled = True
        'For Each colStyle As DataGridColumnStyle In Me.m_treeManager2.GridTableStyle.GridColumnStyles
        '    colStyle.ReadOnly = True
        'Next
      Else
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbFromCC.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbSummary.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbToCC.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next

        If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
          Me.btnApprove.Visible = True
        End If

        'For Each colStyle As DataGridColumnStyle In Me.m_treeManager2.GridTableStyle.GridColumnStyles
        '    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        'Next
      End If
      ToggleStyle(Me.m_treeManager.GridTableStyle)
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      CheckWBSRight()
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        'ห้ามเห็น
        Me.lblWBS.Visible = False
        Me.tgWBS.Visible = False
        Me.ibtnAddWBS.Visible = False
        Me.ibtnDelWBS.Visible = False
      ElseIf Not CBool(checkString.Substring(1, 1)) Then
        'ห้ามแก้
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = False
        Me.ibtnAddWBS.Enabled = False
        Me.ibtnDelWBS.Enabled = False
      Else
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = True
        Me.ibtnAddWBS.Enabled = True
        Me.ibtnDelWBS.Enabled = True
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
        ElseIf TypeOf grb Is TextBox Then
          grb.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbDetail}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblNote}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItem}")
      Me.grbFromCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbFromCC}")

      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblFromCCPerson}")
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCCPerson.Text, ":"))

      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblFromCostCenter}")
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCostCenter.Text, ":"))

      Me.grbToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbToCC}")
      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblToCCPerson}")
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lbltoCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lbltoCC}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lbltoCC.Text, ":"))

      Me.lblDocType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblDocType}")
      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblAccount}")
      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbSummary}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItemCount}")
      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItemCountUnit}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblTotalAmount}")
      Me.chkShowCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.chkShowCost}")
      Me.lblWBS.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblWBS}")

      Me.lblTotalTransferAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblTotalTransferAmount}")
      Me.lblTotalDiffAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblTotalDiffAmount}")
      Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblBaht3.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtEquipmentCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtToCCPersonCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtFromCostCenterCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtFromCCPersonCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtEquipmentCode.TextChanged, AddressOf Me.TextHandler

      AddHandler cmbDocType.SelectedIndexChanged, AddressOf Me.ChangeProperty
    End Sub

    Private toCCCodeChanged As Boolean = False
    Private toCCPersonCodeChanged As Boolean = False
    Private fromCCCodeChanged As Boolean = False
    Private fromCCPersonCodeChanged As Boolean = False
    Private toAssetCodeChanged As Boolean = False

    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txttoccpersoncode"
          toCCPersonCodeChanged = True
        Case "txttocostcentercode"
          toCCCodeChanged = True
        Case "txtfromccpersoncode"
          fromCCPersonCodeChanged = True
        Case "txtfromcostcentercode"
          fromCCCodeChanged = True
        Case "txtequipmentcode"
          toAssetCodeChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldCCId = Me.m_entity.ToCostCenter.Id
      ' txtCode.Text = m_entity.Code


      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code
      'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      m_oldCode = m_entity.Code
      'UpdateAutogen ทำแทนแล้ว
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtNote.Text = Me.m_entity.Note


      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
      txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name
      'Me.chkShowCost.Checked = Me.m_entity.Grouping
      txtEquipmentCode.Text = m_entity.Asset.Code
      txtEquipmentName.Text = m_entity.Asset.Name
      UpdateAccount()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      CodeDescription.ComboSelect(Me.cmbDocType, Me.m_entity.Type)

      Me.chkShowCost.Checked = Not Me.m_entity.Grouping

      RefreshDocs()

      RefreshWBS()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateAccount()
      If m_entity.ToAccount Is Nothing Then
        Return
      End If
      Me.txtAccountCode.Text = m_entity.ToAccount.Code
      Me.txtAccount.Text = m_entity.ToAccount.Name
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub StoreApprove(ByVal sender As Object, ByVal e As MatWithdrawItemCollection.StoreApproveEventArgs)
      Dim approvehash As Hashtable = e.ApproveHash
      Dim str As String
      Dim ApprovePr As New StoreApprovePR
      ApprovePr.Person = Me.SecurityService.CurrentUser.Id
      For Each oPr As PR In approvehash.Values
        ApprovePr.lstvPR.Items.Add(oPr.Code).Tag = oPr
      Next
      If ApprovePr.lstvPR.Items.Count > 0 Then
        ApprovePr.ShowDialog()
      Else
        ApprovePr.Dispose()
        ApprovePr = Nothing
      End If
    End Sub
    Private Sub UpdateAmount()
      Me.txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
      Me.txtTotalAmount.Text = Configuration.FormatToString(Me.m_entity.Gross, DigitConfig.Price)
      Me.txtTotalTransferAmount.Text = Configuration.FormatToString(Me.m_entity.TransferGross, DigitConfig.Price)
      Me.txtTotalDiffAmount.Text = Configuration.FormatToString(Me.m_entity.Gross - Me.m_entity.TransferGross, DigitConfig.Price)
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("stocki_linenumber") = i + 1
        i += 1
      Next
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
            Me.m_entity.Code = Me.m_entity.AutoCodeFormat.Format
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
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "txttoccpersoncode"
          If toCCPersonCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
            toCCPersonCodeChanged = False
          End If
        Case "txttocostcentercode"
          If toCCCodeChanged Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.txtToCostCenterCode.TextLength <> 0 Then
              If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Caption.ChangeCC}") Then
                dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
                UpdateDestAdmin()
                UpdateAccount()
                Try
                  If oldCCId <> Me.m_entity.ToCostCenter.Id Then
                    oldCCId = Me.m_entity.ToCostCenter.Id
                    ChangeCC()
                  End If
                Catch ex As Exception

                End Try
                toCCCodeChanged = False
              Else
                Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
                toCCCodeChanged = False
              End If
            Else
              Me.m_entity.ToCostCenter = New CostCenter
              txtToCostCenterName.Text = ""
              If oldCCId <> Me.m_entity.ToCostCenter.Id Then
                oldCCId = Me.m_entity.ToCostCenter.Id
                ChangeCC()
              End If
            End If
          End If
        Case "txtfromccpersoncode"
          If fromCCPersonCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
            fromCCPersonCodeChanged = False
          End If
        Case "txtfromcostcentercode"
          If fromCCCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            UpdateOriginAdmin()
            ListType()
            fromCCCodeChanged = False
          End If
        Case "cmbdoctype"
          Dim item As IdValuePair = CType(Me.cmbDocType.SelectedItem, IdValuePair)
          Me.m_entity.Type.Value = item.Id
          dirtyFlag = True
          UpdateAccount()
        Case "txtequipmentcode"
          If toAssetCodeChanged Then
            dirtyFlag = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Asset)
            toAssetCodeChanged = False
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      CheckFormEnable()
    End Sub
    Private oldCCId As Integer
    Private Sub ChangeCC()
      oldCCId = Me.m_entity.ToCostCenter.Id
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.ToCostCenterPerson = Me.m_entity.ToCostCenter.Admin
      Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateOriginAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      'If Me.m_entity.FromCostCenterPerson.Originated Then
      '    Me.m_isInitialized = flag
      '    Return
      'End If
      Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name
      Me.m_isInitialized = flag
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
        lblStatus.Text = ""
      End If
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          RemoveHandler Me.m_entity.ItemCollection.StoreApprove, AddressOf StoreApprove
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, MatWithdraw)
        AddHandler Me.m_entity.ItemCollection.StoreApprove, AddressOf StoreApprove

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
    Public Overrides Sub Initialize()
      ListType()
      PopulateInout()
      Me.cmbInOut.SelectedIndex = 0
    End Sub
    Private Sub PopulateInout()
      Me.cmbInOut.Items.AddRange(New Object() { _
      Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.WBSIn}") _
      , Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.WBSOut}") _
      })
    End Sub
    Private Sub ListType()
      Dim oldType As New MatWithdrawType(-1)
      If Not Me.m_entity Is Nothing Then
        oldType = Me.m_entity.Type()
        If Me.m_entity.ToCostCenter.Originated Then
          If Me.m_entity.FromCostCenter.Originated Then
            If Me.m_entity.ToCostCenter.Id = Me.m_entity.FromCostCenter.Id Then
              'CostCenter เดียวกัน เป็นได้เฉพาะเบิกเข้า WIP หรือเป็น Expense
              CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocType, "matwithdraw_type", "code_value <> 3")
              If oldType.Value = 3 Then
                oldType.Value = 1
              End If
              CodeDescription.ComboSelect(Me.cmbDocType, oldType)
              Return
            End If
          End If
        End If
      End If
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocType, "matwithdraw_type")
      If oldType.Value = -1 Then
        oldType.Value = 1
      End If
      CodeDescription.ComboSelect(Me.cmbDocType, oldType)
    End Sub
#End Region

#Region "Event Handlers"
    Private Function IsOut() As Boolean
      Return CBool(Me.cmbInOut.SelectedIndex)
    End Function
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim view As Integer = 31
      If IsOut() Then
        view = 45
      Else
        view = 31
      End If
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      Dim sumPercent As Decimal = wsdColl.GetSumPercent
      If sumPercent >= 100 Then
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      Else
        Dim wbsd As New WBSDistribute
        If Not IsOut() Then
          wbsd.CostCenter = Me.m_entity.ToCostCenter
        Else
          wbsd.CostCenter = Me.m_entity.FromCostCenter
        End If
        wbsd.Percent = 100 - sumPercent
        wsdColl.Add(wbsd)
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view, IsOut)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      If wsdColl.Count > 0 Then
        wsdColl.Remove(wsdColl.Count - 1)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Dim view As Integer = 31
      If IsOut() Then
        view = 45
      Else
        view = 31
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view, IsOut)
      m_wbsdInitialized = True
    End Sub
    Private Sub cmbInOut_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbInOut.SelectedIndexChanged
      If Not Me.m_isInitialized Then
        Return
      End If
      RefreshWBS()
    End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      RefreshWBS()
    End Sub
    Private Sub RefreshWBS()

      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()

      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If

      Dim wsdColl As WBSDistributeCollection
      If Not IsOut() Then
        wsdColl = doc.InWbsdColl
      Else
        wsdColl = doc.OutWbsdColl
      End If
      Dim view As Integer = 31
      If IsOut() Then
        view = 45
      Else
        view = 31
      End If
      If wsdColl Is Nothing Then
        Return
      End If

      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view, IsOut)
      m_wbsdInitialized = True
    End Sub
    Public Sub LCIClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.Message.InputFromCC}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New LCIForSelection
      entity.CC = Me.m_entity.FromCostCenter
      entity.FromWip = False
      entity.refEntityId = Me.Entity.EntityId
      myEntityPanelService.OpenListDialog(entity, AddressOf SetLCIItems)
    End Sub
    Private Sub SetLCIItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = 0 To items.Count - 1 Step 1
        Dim itemEntityLevel As Integer
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            newType = 42
            itemEntityLevel = CType(newItem, LCIItem).Level
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
            itemEntityLevel = 5
        End Select
        If itemEntityLevel = 5 Then
          'If i = items.Count - 1 Then
          If Me.m_entity.ItemCollection.Count = 0 Then
            Dim doc As New MatWithdrawItem
            'doc.Qty = Me.m_entity.GetRemainLCIItem(newItem.Id) / doc.Conversion
            Me.m_entity.ItemCollection.Add(doc)
            If newType = 42 Then
              doc.Qty = doc.GetAmountFromSproc(item.Id, Me.m_entity.FromCC.Id)
              doc.OldQty = doc.Qty
            End If
            doc.Entity = newItem
          Else
            Dim doc As New MatWithdrawItem
            If Not Me.CurrentItem Is Nothing Then
              doc = Me.CurrentItem
            Else
              'doc.Qty = Me.m_entity.GetRemainLCIItem(newItem.Id) / doc.Conversion
              Me.m_entity.ItemCollection.Add(doc)
            End If
            If newType = 42 Then
              doc.Qty = doc.GetAmountFromSproc(item.Id, Me.m_entity.FromCC.Id)
              doc.OldQty = doc.Qty
            End If
            doc.Entity = newItem

          End If
          'Else
          '  Dim doc As New MatWithdrawItem
          '  Me.m_entity.ItemCollection.Insert(index, doc)
          '  doc.Entity = newItem
          'End If
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Public Sub UnitClicked(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatWithdrawItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
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
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As MatWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New MatWithdrawItem
      theItem.Entity = newItem
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim doc As MatWithdrawItem = Me.CurrentItem
      Dim index As Integer = tgItem.CurrentRowIndex
      If doc Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      tgItem.CurrentRowIndex = index - 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Button Events"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.txtCode.ReadOnly = True
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
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub chkShowCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowCost.CheckedChanged
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Not Me.m_isInitialized Then
        Return
      End If
      Me.m_entity.Grouping = Not Me.chkShowCost.Checked
      Me.m_entity.ItemCollection = New MatWithdrawItemCollection(Me.m_entity, Me.m_entity.Grouping)
      Me.ToggleStyle(Me.tgItem.TableStyles(0))
      RefreshDocs()
      'tgItem.Width += 1
      'tgItem.Width -= 1
      Me.Entity = m_entity
    End Sub
    Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPR.Click
			If Me.m_entity.ValidIdOrDBNull(Me.m_entity.ToCostCenter) Is DBNull.Value Then			'_
				'OrElse Me.m_entity.ValidIdOrDBNull(Me.m_entity.FromCostCenter) Is DBNull.Value Then
				Return
			End If
			Dim dlg As New BasketDialog
			AddHandler dlg.EmptyBasket, AddressOf SetItems

			Dim filters(5) As Filter
			Dim excludeList As Object = ""
			excludeList = GetPRExcludeList()
			If excludeList.ToString.Length = 0 Then
				excludeList = DBNull.Value
			End If
			Dim prNeedsApproval As Boolean = False
			Dim prNeedsStoreApproval As Boolean = False

			Dim tmp As Object
			Dim tmp2 As Object
			tmp = Configuration.GetConfig("MWPRFull")
			tmp2 = Configuration.GetConfig("MWPRremainPO")

			prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
			'prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
			filters(0) = New Filter("excludeList", excludeList)
			filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
			filters(2) = New Filter("excludeCanceled", True)
			filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
			filters(4) = New Filter("formEntity", Me.m_entity.EntityId)
			If CBool(tmp) Then
				filters(5) = New Filter("MWPRMode", 1)
			ElseIf CBool(tmp2) Then
				filters(5) = New Filter("MWPRMode", 2)
			Else
				filters(5) = New Filter("MWPRMode", 0)
			End If
			Dim Entities As New ArrayList
			If Not Me.m_entity.ToCostCenter Is Nothing AndAlso Me.m_entity.ToCostCenter.Originated Then
				Entities.Add(Me.m_entity.ToCostCenter)
			End If

			Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
			dlg.Lists.Add(view)
			Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
			myDialog.ShowDialog()
    End Sub
    Private Function GetPRExcludeList() As String
      Dim ret As String = ""
      For Each item As MatWithdrawItem In Me.m_entity.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenterDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.ToCostCenter Is Nothing OrElse Not Me.m_entity.ToCostCenter.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Caption.ChangeCC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
                    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter, New Filter() {New Filter("checkright", False)})
      End If
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
      ListType()
      UpdateDestAdmin()
      Try
        If oldCCId <> Me.m_entity.ToCostCenter.Id Then
          oldCCId = Me.m_entity.ToCostCenter.Id
          ChangeCC()
        End If
      Catch ex As Exception

      End Try
      Me.toCCCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToPerson)
    End Sub
    Private Sub SetToPerson(ByVal e As ISimpleEntity)
      Me.txtToCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
      toCCPersonCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      ListType()
      UpdateAccount()
      UpdateOriginAdmin()
      fromCCCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromPerson)
    End Sub
    Private Sub SetFromPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
      fromCCPersonCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenter.Click, ibtnShowFromCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub ShowCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPerson.Click, ibtnShowFromCCPerson.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowAssetDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipmentDiaog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim eq As New Asset
      entities.Add(eq)
      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAsset, entities)
    End Sub
    Private Sub SetAsset(ByVal e As ISimpleEntity)
      Me.txtEquipmentCode.Text = e.Code
      Dim flag As Boolean = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Asset)
      If flag Then
        Me.ChangeEq()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or flag
    End Sub
    Private Sub ChangeEq()

      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
      Me.m_isInitialized = flag
    End Sub

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New MatWithdraw).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
    End Sub
#End Region

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      Me.m_entity.ItemCollection.CheckPRForStoreApprove()
    End Sub

    Private Sub CheckApproveStore()
      If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
        Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        Dim level As Integer = secSrv.GetAccess(290)
        Dim checkString As String = BinaryHelper.DecToBin(level, 5)
        checkString = BinaryHelper.RevertString(checkString)
        If Not CBool(checkString.Substring(0, 1)) Then
          'ห้ามเห็น
          Me.btnApprove.Visible = False
        Else
          Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.btnStoreApprove}")
          Me.btnApprove.Visible = True
        End If
      Else
        Me.btnApprove.Visible = False
      End If
    End Sub



  End Class


End Namespace

