Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class DepreciationCalDetail
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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label  '*****************
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDepreDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDepreDate As System.Windows.Forms.Label
    Friend WithEvents dtpDepreDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblItemCount2 As System.Windows.Forms.Label
    Friend WithEvents lblItemCount3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCount2 As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCount3 As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount4 As System.Windows.Forms.Label
    Friend WithEvents txtItemCount4 As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount5 As System.Windows.Forms.Label
    Friend WithEvents lblTransferData As System.Windows.Forms.Label
    Friend WithEvents btnTransferCC As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtItemCount5 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepreciationCalDetail))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.txtDepreDate = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtItemCount2 = New System.Windows.Forms.TextBox()
      Me.txtItemCount3 = New System.Windows.Forms.TextBox()
      Me.txtItemCount4 = New System.Windows.Forms.TextBox()
      Me.txtItemCount5 = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblTransferData = New System.Windows.Forms.Label()
      Me.btnTransferCC = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDepreDate = New System.Windows.Forms.Label()
      Me.dtpDepreDate = New System.Windows.Forms.DateTimePicker()
      Me.lblItemCount2 = New System.Windows.Forms.Label()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCount4 = New System.Windows.Forms.Label()
      Me.lblItemCount3 = New System.Windows.Forms.Label()
      Me.lblItemCount5 = New System.Windows.Forms.Label()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbMaster.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.txtDocDate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(384, 16)
      Me.txtDocDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(120, 20)
      Me.txtDocDate.TabIndex = 0
      '
      'txtItemCount
      '
      Me.txtItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.txtItemCount.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(697, 416)
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(96, 20)
      Me.txtItemCount.TabIndex = 19
      Me.txtItemCount.TabStop = False
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtDepreDate
      '
      Me.txtDepreDate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDepreDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDepreDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDepreDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDepreDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDepreDate, System.Drawing.Color.Empty)
      Me.txtDepreDate.Location = New System.Drawing.Point(136, 40)
      Me.txtDepreDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDepreDate, "")
      Me.txtDepreDate.Name = "txtDepreDate"
      Me.Validator.SetRegularExpression(Me.txtDepreDate, "")
      Me.Validator.SetRequired(Me.txtDepreDate, True)
      Me.txtDepreDate.Size = New System.Drawing.Size(120, 20)
      Me.txtDepreDate.TabIndex = 2
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(136, 67)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(384, 20)
      Me.txtNote.TabIndex = 6
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(136, 16)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(120, 20)
      Me.txtCode.TabIndex = 4
      '
      'txtItemCount2
      '
      Me.txtItemCount2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtItemCount2.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount2, "")
      Me.txtItemCount2.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount2, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount2, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount2, System.Drawing.Color.Empty)
      Me.txtItemCount2.Location = New System.Drawing.Point(697, 388)
      Me.Validator.SetMinValue(Me.txtItemCount2, "")
      Me.txtItemCount2.Name = "txtItemCount2"
      Me.txtItemCount2.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount2, "")
      Me.Validator.SetRequired(Me.txtItemCount2, False)
      Me.txtItemCount2.Size = New System.Drawing.Size(96, 20)
      Me.txtItemCount2.TabIndex = 19
      Me.txtItemCount2.TabStop = False
      Me.txtItemCount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtItemCount3
      '
      Me.txtItemCount3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtItemCount3.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount3, "")
      Me.txtItemCount3.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount3, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount3, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount3, System.Drawing.Color.Empty)
      Me.txtItemCount3.Location = New System.Drawing.Point(497, 388)
      Me.Validator.SetMinValue(Me.txtItemCount3, "")
      Me.txtItemCount3.Name = "txtItemCount3"
      Me.txtItemCount3.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount3, "")
      Me.Validator.SetRequired(Me.txtItemCount3, False)
      Me.txtItemCount3.Size = New System.Drawing.Size(96, 20)
      Me.txtItemCount3.TabIndex = 19
      Me.txtItemCount3.TabStop = False
      Me.txtItemCount3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtItemCount4
      '
      Me.txtItemCount4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtItemCount4.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount4, "")
      Me.txtItemCount4.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount4, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount4, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount4, System.Drawing.Color.Empty)
      Me.txtItemCount4.Location = New System.Drawing.Point(345, 388)
      Me.Validator.SetMinValue(Me.txtItemCount4, "")
      Me.txtItemCount4.Name = "txtItemCount4"
      Me.txtItemCount4.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount4, "")
      Me.Validator.SetRequired(Me.txtItemCount4, False)
      Me.txtItemCount4.Size = New System.Drawing.Size(96, 20)
      Me.txtItemCount4.TabIndex = 19
      Me.txtItemCount4.TabStop = False
      Me.txtItemCount4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtItemCount5
      '
      Me.txtItemCount5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtItemCount5.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount5, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount5, "")
      Me.txtItemCount5.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount5, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount5, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount5, System.Drawing.Color.Empty)
      Me.txtItemCount5.Location = New System.Drawing.Point(137, 388)
      Me.Validator.SetMinValue(Me.txtItemCount5, "")
      Me.txtItemCount5.Name = "txtItemCount5"
      Me.txtItemCount5.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount5, "")
      Me.Validator.SetRequired(Me.txtItemCount5, False)
      Me.txtItemCount5.Size = New System.Drawing.Size(96, 20)
      Me.txtItemCount5.TabIndex = 19
      Me.txtItemCount5.TabStop = False
      Me.txtItemCount5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.lblTransferData)
      Me.grbMaster.Controls.Add(Me.btnTransferCC)
      Me.grbMaster.Controls.Add(Me.txtItemCount3)
      Me.grbMaster.Controls.Add(Me.ibtnBlank)
      Me.grbMaster.Controls.Add(Me.ibtnDelRow)
      Me.grbMaster.Controls.Add(Me.lblStatus)
      Me.grbMaster.Controls.Add(Me.txtItemCount)
      Me.grbMaster.Controls.Add(Me.lblItemCountUnit)
      Me.grbMaster.Controls.Add(Me.tgItem)
      Me.grbMaster.Controls.Add(Me.lblItem)
      Me.grbMaster.Controls.Add(Me.chkAutorun)
      Me.grbMaster.Controls.Add(Me.txtNote)
      Me.grbMaster.Controls.Add(Me.lblNote)
      Me.grbMaster.Controls.Add(Me.lblDocDate)
      Me.grbMaster.Controls.Add(Me.lblCode)
      Me.grbMaster.Controls.Add(Me.txtCode)
      Me.grbMaster.Controls.Add(Me.txtDocDate)
      Me.grbMaster.Controls.Add(Me.dtpDocDate)
      Me.grbMaster.Controls.Add(Me.lblDepreDate)
      Me.grbMaster.Controls.Add(Me.txtDepreDate)
      Me.grbMaster.Controls.Add(Me.dtpDepreDate)
      Me.grbMaster.Controls.Add(Me.lblItemCount2)
      Me.grbMaster.Controls.Add(Me.txtItemCount2)
      Me.grbMaster.Controls.Add(Me.lblItemCount)
      Me.grbMaster.Controls.Add(Me.lblItemCount4)
      Me.grbMaster.Controls.Add(Me.txtItemCount4)
      Me.grbMaster.Controls.Add(Me.lblItemCount3)
      Me.grbMaster.Controls.Add(Me.lblItemCount5)
      Me.grbMaster.Controls.Add(Me.txtItemCount5)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(857, 448)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "grbMaster"
      '
      'lblTransferData
      '
      Me.lblTransferData.AutoSize = True
      Me.lblTransferData.Location = New System.Drawing.Point(240, 99)
      Me.lblTransferData.Name = "lblTransferData"
      Me.lblTransferData.Size = New System.Drawing.Size(69, 13)
      Me.lblTransferData.TabIndex = 23
      Me.lblTransferData.Text = "ข้อมูลการโอน"
      Me.lblTransferData.Visible = False
      '
      'btnTransferCC
      '
      Me.btnTransferCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnTransferCC.Location = New System.Drawing.Point(210, 93)
      Me.btnTransferCC.Margin = New System.Windows.Forms.Padding(0)
      Me.btnTransferCC.Name = "btnTransferCC"
      Me.btnTransferCC.Size = New System.Drawing.Size(24, 24)
      Me.btnTransferCC.TabIndex = 10
      Me.btnTransferCC.TabStop = False
      Me.btnTransferCC.ThemedImage = CType(resources.GetObject("btnTransferCC.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(156, 93)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 8
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(180, 93)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 9
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(8, 420)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(22, 13)
      Me.lblStatus.TabIndex = 21
      Me.lblStatus.Text = "xxx"
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCountUnit.AutoSize = True
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(801, 416)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 13)
      Me.lblItemCountUnit.TabIndex = 20
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.Location = New System.Drawing.Point(8, 123)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(833, 261)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(12, 101)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(106, 16)
      Me.lblItem.TabIndex = 14
      Me.lblItem.Text = "รายการสินทรัพย์"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(256, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 5
      Me.chkAutorun.TabStop = False
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 67)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(128, 16)
      Me.lblNote.TabIndex = 12
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(296, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(80, 16)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 16)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(384, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(141, 20)
      Me.dtpDocDate.TabIndex = 1
      Me.dtpDocDate.TabStop = False
      '
      'lblDepreDate
      '
      Me.lblDepreDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDepreDate.Location = New System.Drawing.Point(8, 40)
      Me.lblDepreDate.Name = "lblDepreDate"
      Me.lblDepreDate.Size = New System.Drawing.Size(120, 16)
      Me.lblDepreDate.TabIndex = 7
      Me.lblDepreDate.Text = "วันที่คิดค่าเสื่อม"
      Me.lblDepreDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDepreDate
      '
      Me.dtpDepreDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDepreDate.Location = New System.Drawing.Point(136, 40)
      Me.dtpDepreDate.Name = "dtpDepreDate"
      Me.dtpDepreDate.Size = New System.Drawing.Size(141, 20)
      Me.dtpDepreDate.TabIndex = 3
      Me.dtpDepreDate.TabStop = False
      '
      'lblItemCount2
      '
      Me.lblItemCount2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCount2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount2.Location = New System.Drawing.Point(593, 388)
      Me.lblItemCount2.Name = "lblItemCount2"
      Me.lblItemCount2.Size = New System.Drawing.Size(104, 18)
      Me.lblItemCount2.TabIndex = 18
      Me.lblItemCount2.Text = "รวมค่าเสื่อมสะสมเพิ่ม"
      Me.lblItemCount2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCount
      '
      Me.lblItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(537, 416)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(160, 18)
      Me.lblItemCount.TabIndex = 18
      Me.lblItemCount.Text = "จำนวนรายการทั้งหมด"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCount4
      '
      Me.lblItemCount4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCount4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount4.Location = New System.Drawing.Point(233, 388)
      Me.lblItemCount4.Name = "lblItemCount4"
      Me.lblItemCount4.Size = New System.Drawing.Size(112, 18)
      Me.lblItemCount4.TabIndex = 18
      Me.lblItemCount4.Text = "รวมค่าเสื่อมสะสมยกมา"
      Me.lblItemCount4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCount3
      '
      Me.lblItemCount3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCount3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount3.Location = New System.Drawing.Point(425, 388)
      Me.lblItemCount3.Name = "lblItemCount3"
      Me.lblItemCount3.Size = New System.Drawing.Size(72, 18)
      Me.lblItemCount3.TabIndex = 18
      Me.lblItemCount3.Text = "รวมค่าซาก"
      Me.lblItemCount3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCount5
      '
      Me.lblItemCount5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblItemCount5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount5.Location = New System.Drawing.Point(65, 388)
      Me.lblItemCount5.Name = "lblItemCount5"
      Me.lblItemCount5.Size = New System.Drawing.Size(72, 18)
      Me.lblItemCount5.TabIndex = 18
      Me.lblItemCount5.Text = "รวมราคาซื้อ"
      Me.lblItemCount5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'DepreciationCalDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "DepreciationCalDetail"
      Me.Size = New System.Drawing.Size(873, 456)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblDepreDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblDepreDate}")
      Me.Validator.SetDisplayName(txtDepreDate, lblDepreDate.Text)

      

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCountUnit}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCount}")
      Me.Validator.SetDisplayName(txtItemCount, lblItemCount.Text)
      Me.lblItemCount2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCount2}")
      Me.Validator.SetDisplayName(txtItemCount2, lblItemCount2.Text)

      Me.lblItemCount3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCount3}")
      Me.Validator.SetDisplayName(txtItemCount3, lblItemCount3.Text)

      Me.lblItemCount4.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCount4}")
      Me.Validator.SetDisplayName(txtItemCount4, lblItemCount4.Text)

      Me.lblItemCount5.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItemCount5}")
      Me.Validator.SetDisplayName(txtItemCount5, lblItemCount5.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblItem}")

      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.grbMaster}")
      

    End Sub
#End Region

#Region "Members"
    Private m_entity As DepreciationCal

    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable

    Private CCOutText As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblCCOut}")
    Private CCInText As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblCCIn}")
#End Region


#Region "Properties"
    Private ReadOnly Property CurrentItem() As DepreciationCalItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is DepreciationCalItem Then
          Return Nothing
        End If
        Return CType(row.Tag, DepreciationCalItem)
      End Get
    End Property
#End Region

#Region " Style "
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "DepreciationCal"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' Line number
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "lineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "lineNumber"

      ' Asset code
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "asset_code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 60
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "asset_code"

      ' Asset button find
      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "btnAsset"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf GridButton_Click

      ' Asset name
      Dim csName As New TreeTextColumn
      csName.MappingName = "asset_name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Alignment = HorizontalAlignment.Center
      csName.DataAlignment = HorizontalAlignment.Left
      csName.Width = 150
      csName.ReadOnly = True
      csName.TextBox.Name = "asset_name"

      ' อายุค่าเสื่อม
      Dim csAge As New TreeTextColumn
      csAge.MappingName = "deprei_age"
      csAge.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.AgeHeaderText}")
      csAge.NullText = ""
      csAge.Alignment = HorizontalAlignment.Center
      csAge.DataAlignment = HorizontalAlignment.Center
      csAge.Width = 60
      csAge.Format = "#,###"
      csAge.ReadOnly = True
      csAge.TextBox.Name = "deprei_age"

      ' วันที่เริ่มคำนวณค่าเสื่อมราคา
      Dim csStartCalcDate As New TreeTextColumn
      csStartCalcDate.MappingName = "asset_startCalcDate"
      csStartCalcDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.StartCalcDateHeaderText}")
      csStartCalcDate.NullText = ""
      csStartCalcDate.Alignment = HorizontalAlignment.Center
      csStartCalcDate.DataAlignment = HorizontalAlignment.Center
      csStartCalcDate.Width = 70
      csStartCalcDate.Format = "dd/MM/yyyy"
      csStartCalcDate.ReadOnly = True
      csStartCalcDate.TextBox.Name = "asset_startCalcDate"

      ' ต้นทุน
      Dim csPrice As New TreeTextColumn
      csPrice.MappingName = "deprei_price"
      csPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.BuyPriceHeaderText}")
      csPrice.NullText = ""
      csPrice.Alignment = HorizontalAlignment.Center
      csPrice.DataAlignment = HorizontalAlignment.Right
      csPrice.Width = 80
      csPrice.Format = "#,##0.00"
      csPrice.ReadOnly = True
      csPrice.TextBox.Name = "deprei_price"

      ' ค่าเสื่อมยกมา
      Dim csDepreOpening As New TreeTextColumn
      csDepreOpening.MappingName = "deprei_depreopening"
      csDepreOpening.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.DepreOpeningHeaderText}")
      csDepreOpening.NullText = ""
      csDepreOpening.Alignment = HorizontalAlignment.Center
      csDepreOpening.DataAlignment = HorizontalAlignment.Right
      csDepreOpening.Width = 90
      csDepreOpening.Format = "#,##0.00"
      csDepreOpening.ReadOnly = True
      csDepreOpening.MappingName = "deprei_depreopening"

      ' ค่าซาก
      Dim csSalvage As New TreeTextColumn
      csSalvage.MappingName = "deprei_salvage"
      csSalvage.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.SalvageHeaderText}")
      csSalvage.NullText = ""
      csSalvage.Alignment = HorizontalAlignment.Center
      csSalvage.DataAlignment = HorizontalAlignment.Right
      csSalvage.Width = 80
      csSalvage.Format = "#,##0.00"
      csSalvage.ReadOnly = True
      csSalvage.TextBox.Name = "deprei_salvage"

      ' ค่าเสื่อมเพิ่มเฉลี่ยต่อวัน
      Dim csAddDepre As New TreeTextColumn
      csAddDepre.MappingName = "deprei_depreamnt"
      csAddDepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.DepreCalcHeaderText}")
      csAddDepre.NullText = ""
      csAddDepre.Alignment = HorizontalAlignment.Center
      csAddDepre.DataAlignment = HorizontalAlignment.Right
      csAddDepre.Width = 90
      csAddDepre.Format = "#,##0.00"
      csAddDepre.ReadOnly = True
      csAddDepre.TextBox.Name = "deprei_depreamnt"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "deprei_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.NoteHeaderText}")
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Right
      csNote.Width = 150
      csNote.ReadOnly = False
      csNote.TextBox.Name = "deprei_note"
      csNote.NullText = ""

      ' Fill Column Style 
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csAge)
      dst.GridColumnStyles.Add(csStartCalcDate)
      dst.GridColumnStyles.Add(csPrice)
      dst.GridColumnStyles.Add(csDepreOpening)
      dst.GridColumnStyles.Add(csSalvage)
      dst.GridColumnStyles.Add(csAddDepre)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function

#End Region

#Region " Constructure "
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()

      ' มาแก้ต่อด้วย
      Dim dt As TreeTable = DepreciationCal.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf DPItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbMaster.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
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
      Dim doc As DepreciationCalItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New DepreciationCalItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "asset_code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetEntityCode(CStr(e.ProposedValue))
          Case "deprei_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      'Dim proposedCode As Object = e.Row("asset_code")
      'Select Case e.Column.ColumnName.ToLower
      '    Case "asset_code"
      '        proposedCode = e.ProposedValue
      'End Select
      'If IsDBNull(proposedCode) Then
      '    e.Row.SetColumnError("asset_code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
      'Else
      '    e.Row.SetColumnError("asset_code", "")
      'End If
    End Sub
    Private Sub DPItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region " IListDetail "
    Public Overrides Sub Initialize()

    End Sub

    ' Check Enable 
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.Canceled _
      OrElse m_entityRefed = 1 _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 Then
        For Each ctrl As Control In Me.grbMaster.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.grbMaster.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next

        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

    End Sub
    ' Clear Detail
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.grbMaster.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
        If TypeOf crlt Is FixedGroupBox Then
          For Each grbctlt As Control In crlt.Controls
            If TypeOf grbctlt Is TextBox Then
              grbctlt.Text = ""
            End If
          Next
        End If
      Next

      Me.dtpDocDate.Value = Date.Now
      txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      Me.dtpDepreDate.Value = Date.Now
      txtDepreDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      Me.m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = Me.m_entity.Code
      txtNote.Text = Me.m_entity.Note
      ' autogencode
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      ' วันที่เอกสาร
      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      ' วันที่โอน
      txtDepreDate.Text = MinDateToNull(Me.m_entity.DepreDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDepreDate.Value = MinDateToNow(Me.m_entity.DepreDate)
      ' Transfer Out
      'If Me.m_entity.FromCostcenter.Originated Then
      '  txtCCOutCode.Text = Me.m_entity.FromCostcenter.Code
      '  txtCCOutName.Text = Me.m_entity.FromCostcenter.Name
      'End If
      'If Me.m_entity.FromPerson.Originated Then
      '  txtPersonOutCode.Text = Me.m_entity.FromPerson.Code
      '  txtPersonOutName.Text = Me.m_entity.FromPerson.Name
      'End If

      '' Transfer IN
      'If Me.m_entity.ToCostcenter.Originated Then
      '  txtCCInCode.Text = Me.m_entity.ToCostcenter.Code
      '  txtCCInName.Text = Me.m_entity.ToCostcenter.Name
      'End If
      'If Me.m_entity.ToPerson.Originated Then
      '  txtPersonInCode.Text = Me.m_entity.ToPerson.Code
      '  txtPersonInName.Text = Me.m_entity.ToPerson.Name
      'End If
      lblTransferData.Visible = False
      If m_entity.IsTransfer AndAlso m_entity.FromCostcenter IsNot Nothing AndAlso m_entity.ToCostcenter IsNot Nothing Then
        lblTransferData.Text = CCOutText + " " + m_entity.FromCostcenter.Code + ":" + m_entity.FromCostcenter.Name + " " + CCInText + " " + m_entity.ToCostcenter.Code + m_entity.ToCostcenter.Name
        lblTransferData.Visible = True
      End If

      RefreshDocs()

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()

      CheckFormEnable()

      Me.m_isInitialized = True
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

    ' Addhandler events
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtCCInCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtPersonInCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtCCOutCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtPersonOutCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDepreDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDepreDate.ValueChanged, AddressOf Me.ChangeProperty
      ' คำนวณวันค่าใหม่ เมื่อเปลี่ยนวัน
      AddHandler txtDepreDate.Validated, AddressOf Me.DepredateChanged
      AddHandler dtpDepreDate.ValueChanged, AddressOf Me.DepredateChanged

    End Sub
    ' คำนวณค่าใหม่เมื่อเปลี่ยนวันที่
    Public Sub DepredateChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not (Me.m_isInitialized) Then
        Return
      End If
      Dim flag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Me.m_entity.ReCalculationAll()
      Dim index As Integer = tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = flag
      RefreshBlankGrid()
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

          'Case "txtccincode"
          '  dirtyFlag = CostCenter.GetCostCenter(txtCCInCode, txtCCInName, Me.m_entity.ToCostcenter)

          'Case "txtpersonincode"
          '  dirtyFlag = Employee.GetEmployee(txtPersonInCode, txtPersonInName, Me.m_entity.ToPerson)

          'Case "txtccoutcode"
          '  dirtyFlag = CostCenter.GetCostCenter(txtCCOutCode, txtCCOutName, Me.m_entity.FromCostcenter)
          '  If dirtyFlag Then
          '    Me.m_entity.ItemCollection.Clear()
          '    RefreshBlankGrid()
          '  End If

          'Case "txtpersonoutcode"
          '  dirtyFlag = Employee.GetEmployee(txtPersonOutCode, txtPersonOutName, Me.m_entity.FromPerson)

        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
            End If
            dirtyFlag = True
          End If

        Case "txtdepredate"
          m_dateSetting = True
          If Not Me.txtDepreDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDepreDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDepreDate.Text)
            If Not Me.m_entity.DepreDate.Equals(theDate) Then
              dtpDepreDate.Value = theDate
              Me.m_entity.DepreDate = dtpDepreDate.Value
              Me.dtpDepreDate.Value = MaxDtpDate(Me.m_entity.DepreDate)
              dirtyFlag = True
            End If
          Else
            dtpDepreDate.Value = Date.Now
            Me.m_entity.DepreDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "dtpdepredate"
          If Not Me.m_entity.DepreDate.Equals(dtpDepreDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDepreDate.Text = MinDateToNull(dtpDepreDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DepreDate = dtpDepreDate.Value
              Me.dtpDepreDate.Value = MaxDtpDate(Me.m_entity.DepreDate)
            End If
            dirtyFlag = True
          End If

      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()

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
        lblStatus.Text = "ยังไม่บันทึก"
      End If
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
        Me.m_entity = CType(Value, DepreciationCal)
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

#End Region

#Region " Event Handlers "
    Private Function GenIDListFromDataTable() As String
      Dim idlist As String = ""
      For Each item As DepreciationCalItem In Me.m_entity.ItemCollection
        If Not item.Entity Is Nothing AndAlso item.Entity.Originated Then
          idlist &= "|" & CStr(item.Entity.Id) & "|"
        End If
      Next
      Return idlist
    End Function

    Public Sub GridButton_Click(ByVal e As ButtonColumnEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      ' ต้องการหนดวันที่คิดค่าเสื่อมก่อน ...
      If Me.m_entity.DepreDate.Equals(Date.MinValue) OrElse txtDepreDate.TextLength = 0 Then
        msgServ.ShowWarningFormatted("${res:Global.MustDefine}", lblDepreDate.Text)
        txtDepreDate.Focus()
        Return
      End If
      'ไม่ต้องใส่ costcenter ก็ได้
      '' ต้องกำหนด Cost center โอนออกก่อน ...
      'If Not Me.m_entity.FromCostcenter.Originated Then
      '  msgServ.ShowWarningFormatted("${res:Global.MustDefine}", lblCCOut.Text)
      '  txtCCOutCode.Focus()
      '  Return
      'End If
      ' ไม่แสดงรายการใน list ของ detail
      Dim arr(1) As Filter
      arr(0) = New Filter("IDList", GenIDListFromDataTable)
      arr(1) = New Filter("asset_lastdepredate", DepreciationCal.ValidDateOrDBNull(Me.m_entity.DepreDate))
      ' Filter ของ Entity find view
      Dim entities As New ArrayList
      Dim obj As New Asset
      If m_entity.IsTransfer Then
        obj.Costcenter = Me.m_entity.FromCostcenter
      End If
      entities.Add(obj)

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetItems, arr, entities)
    End Sub
    Private Sub SetAssetItems(ByVal items As BasketItemCollection)
      ' Comment : สามารถเก็บ Material Level อื่นได้
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      'ถ้าเลือกมาแล้วตอนที่ยังไม่ได้ set costcenter ก็ห้ามกดอีก
        btnTransferCC.Enabled = m_entity.IsTransfer
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Dim newAsset As New Asset
      Dim newItem As New DepreciationCalItem
      newItem.Entity = newAsset
      Me.m_entity.ItemCollection.Insert(index, newItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim rowsCount As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If TypeOf row.Tag Is DepreciationCalItem Then
              Dim doc As DepreciationCalItem = CType(row.Tag, DepreciationCalItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As DepreciationCalItem = Me.m_entity.ItemCollection.CurrentItem
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
        row("lineNumber") = i + 1
        i += 1
      Next
    End Sub
#End Region

#Region " IValidatable "
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Overrides "
    Public Overrides Sub NotifyBeforeSave()

    End Sub

    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New AssetReturn).DetailPanelIcon
      End Get
    End Property
#End Region

#Region " Event of Button controls "
    '' Person
    'Private Sub btnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Employee)
    'End Sub
    'Private Sub btnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = _
    '        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnpersonoutfind"
    '      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetPersonOutDialog)
    '    Case "btnpersoninfind"
    '      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetPersonINDialog)
    '  End Select
    'End Sub

    'Private Sub SetPersonINDialog(ByVal e As ISimpleEntity)
    '  Me.txtPersonInCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '   Me.WorkbenchWindow.ViewContent.IsDirty _
    '   Or Employee.GetEmployee(txtPersonInCode, txtPersonInName, Me.m_entity.ToPerson)
    'End Sub
    'Private Sub SetPersonOutDialog(ByVal e As ISimpleEntity)
    '  Me.txtPersonOutCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '   Me.WorkbenchWindow.ViewContent.IsDirty _
    '   Or Employee.GetEmployee(txtPersonOutCode, txtPersonOutName, Me.m_entity.FromPerson)
    'End Sub
    '' Costcenter
    'Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New CostCenter)
    'End Sub
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = _
    '     CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnccoutfind"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterOutDialog)
    '    Case "btnccinfind"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterINDialog)
    '  End Select
    'End Sub
    'Private Sub SetCostCenterINDialog(ByVal e As ISimpleEntity)
    '  Me.txtCCInCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '   Me.WorkbenchWindow.ViewContent.IsDirty _
    '   Or CostCenter.GetCostCenter(txtCCInCode, txtCCInName, Me.m_entity.ToCostcenter)
    'End Sub
    'Private Sub SetCostCenterOutDialog(ByVal e As ISimpleEntity)
    '  Me.txtCCOutCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '   Me.WorkbenchWindow.ViewContent.IsDirty _
    '   Or CostCenter.GetCostCenter(txtCCOutCode, txtCCOutName, Me.m_entity.FromCostcenter)
    'End Sub


#End Region

    'ไปอยู่ที่ dpretransfer
    '#Region " IClipboardHandler Overrides "
    '    Public Overrides ReadOnly Property EnablePaste() As Boolean
    '      Get
    '        ' Person
    '        Dim data As IDataObject = Clipboard.GetDataObject
    '        If data.GetDataPresent((New Employee).FullClassName) Then
    '          If Not Me.ActiveControl Is Nothing Then
    '            Select Case Me.ActiveControl.Name.ToLower
    '              Case "txtpersonincode", "txtpersoninname"
    '                Return True
    '              Case "txtpersonoutcode", "txtpersonoutname"
    '                Return True
    '            End Select
    '          End If
    '        End If
    '        ' Cost center
    '        If data.GetDataPresent((New CostCenter).FullClassName) Then
    '          If Not Me.ActiveControl Is Nothing Then
    '            Select Case Me.ActiveControl.Name.ToLower
    '              Case "txtccincode", "txtccinname"
    '                Return True
    '              Case "txtccoutcode", "txtccoutname"
    '                Return True
    '            End Select
    '          End If
    '        End If
    '        Return False
    '      End Get
    '    End Property
    '    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
    '      Dim data As IDataObject = Clipboard.GetDataObject
    '      ' Person
    '      If data.GetDataPresent((New Employee).FullClassName) Then
    '        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
    '        Dim entity As New Employee(id)
    '        If Not Me.ActiveControl Is Nothing Then
    '          Select Case Me.ActiveControl.Name.ToLower
    '            Case "txtpersonincode", "txtpersoninname"
    '              Me.SetPersonINDialog(entity)
    '            Case "txtpersonoutcode", "txtpersonoutname"
    '              Me.SetPersonOutDialog(entity)
    '          End Select
    '        End If
    '      End If
    '      ' Cost center
    '      If data.GetDataPresent((New CostCenter).FullClassName) Then
    '        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
    '        Dim entity As New CostCenter(id)
    '        If Not Me.ActiveControl Is Nothing Then
    '          Select Case Me.ActiveControl.Name.ToLower
    '            Case "txtccincode", "txtccinname"
    '              Me.SetCostCenterINDialog(entity)
    '            Case "txtccoutcode", "txtccoutname"
    '              Me.SetCostCenterOutDialog(entity)
    '          End Select
    '        End If
    '      End If
    '    End Sub
    '#End Region

#Region " IPrintable "
    'Public Overrides ReadOnly Property PrintDocument() As PrintDocument
    '    Get
    '        Dim pd As New PrintDocument
    '        AddHandler pd.PrintPage, AddressOf PrintPage_Handler
    '        Return pd
    '    End Get
    'End Property
    'Private Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
    '    Dim df As New DocumentForm("C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm") '"C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm")
    '    For Each entry As DictionaryEntry In df.ControlDictionary.Hashtable
    '        If TypeOf entry.Value Is IDrawable Then
    '            If Not TypeOf entry.Value Is FormTable.FormTable Then
    '                CType(entry.Value, IDrawable).Draw(pe.Graphics, CType(entry.Value, Control).Location)
    '            Else
    '                Dim ft As FormTable.FormTable = CType(df.ControlDictionary("formTable"), FormTable.FormTable)
    '                ft.Draw(pe.Graphics, ft.Location)
    '                Dim colOffset As Integer = 0
    '                Dim verticalInterval As Integer = 5
    '                Dim horizontalInterval As Integer = 5
    '                For Each col As FormTable.Column In ft.Columns
    '                    colOffset = col.Width + colOffset
    '                    If Me.m_entity.ItemTable.Childs.Count > 0 Then
    '                        For i As Integer = 0 To ft.RowsPerPage - 1
    '                            If i > Me.m_entity.ItemTable.Childs.Count - 1 Then
    '                                Exit For
    '                            End If
    '                            Dim row As TreeRow = Me.m_entity.ItemTable.Childs(i)
    '                            If Not IsDBNull(row(col.ReportField)) Then
    '                                Dim data As String = row(col.ReportField).ToString
    '                                Dim textSize As SizeF = pe.Graphics.MeasureString(data, ft.Font)
    '                                Dim startPoint As Integer
    '                                Select Case col.Alignment
    '                                    Case HorizontalAlignment.Center
    '                                        startPoint = CInt((col.Width / 2) - (textSize.Width / 2)) + colOffset - col.Width
    '                                    Case HorizontalAlignment.Left
    '                                        startPoint = colOffset - col.Width + horizontalInterval
    '                                    Case HorizontalAlignment.Right
    '                                        startPoint = CInt(colOffset - textSize.Width - horizontalInterval)
    '                                End Select
    '                                pe.Graphics.DrawString(data, ft.Font, New SolidBrush(ft.ForeColor), ft.Location.X + startPoint, ft.HeaderHeight + ft.Location.Y + i * ft.RowHeight + verticalInterval)
    '                            End If
    '                        Next
    '                    End If
    '                Next
    '            End If
    '        End If
    '    Next
    'End Sub
#End Region

#Region " Grid Resizing "
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

#Region " Private Methods "
    Private Sub UpdateAmount()
      txtItemCount5.Text = Configuration.FormatToString(Me.m_entity.TotalBuyPrice, DigitConfig.Price)
      txtItemCount4.Text = Configuration.FormatToString(Me.m_entity.TotalOPB, DigitConfig.Price)
      txtItemCount3.Text = Configuration.FormatToString(Me.m_entity.TotalSalvage, DigitConfig.Price)
      txtItemCount2.Text = Configuration.FormatToString(Me.m_entity.TotalDepre, DigitConfig.Price)
      txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
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

    Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        Me.m_entity.ItemCollection.CurrentItem = Me.CurrentItem
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub

    Private Sub btnTransferCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferCC.Click
      Dim myTransferCCPanel As New Longkong.Pojjaman.Gui.Panels.DepreTransferDetail
      myTransferCCPanel.Entity = Me.m_entity
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myTransferCCPanel)
      If myDialog.ShowDialog() = DialogResult.Cancel Then
        Me.WorkbenchWindow.ViewContent.IsDirty = False
      End If
      If myDialog.ShowDialog = DialogResult.OK Then
        If Len(myTransferCCPanel.DepreciationCal.ToCostcenter.Code) > 0 AndAlso Len(myTransferCCPanel.DepreciationCal.FromCostcenter.Code) > 0 Then
          Me.WorkbenchWindow.ViewContent.IsDirty = True
          Me.m_entity.IsTransfer = True
          Me.m_entity.FromCostcenter = myTransferCCPanel.DepreciationCal.FromCostcenter
          Me.m_entity.ToCostcenter = myTransferCCPanel.DepreciationCal.ToCostcenter
          Me.m_entity.FromPerson = myTransferCCPanel.DepreciationCal.FromPerson
          Me.m_entity.ToPerson = myTransferCCPanel.DepreciationCal.ToPerson

          UpdateEntityProperties()

        End If
      End If
    End Sub
  End Class
End Namespace