Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class WBSDetail
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblBOQCode As System.Windows.Forms.Label
    Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents tvWbs As System.Windows.Forms.TreeView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbSummarize As System.Windows.Forms.GroupBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnInsert As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFinishDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpFinishDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblFinishDate As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents tgProgress As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlankWBSProgress As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLockBoq As System.Windows.Forms.Button
    Friend WithEvents txtCBS As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowCBSDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRowWBSProgress As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBSDetail))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowCBSDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCBS = New System.Windows.Forms.TextBox()
      Me.txtFinishDate = New System.Windows.Forms.TextBox()
      Me.lblFinishDate = New System.Windows.Forms.Label()
      Me.dtpFinishDate = New System.Windows.Forms.DateTimePicker()
      Me.txtStartDate = New System.Windows.Forms.TextBox()
      Me.lblStartDate = New System.Windows.Forms.Label()
      Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.tgProgress = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblProgress = New System.Windows.Forms.Label()
      Me.ibtnBlankWBSProgress = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRowWBSProgress = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tvWbs = New System.Windows.Forms.TreeView()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.lblBOQCode = New System.Windows.Forms.Label()
      Me.txtBOQCode = New System.Windows.Forms.TextBox()
      Me.txtProjectName = New System.Windows.Forms.TextBox()
      Me.lblProject = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtProjectCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbSummarize = New System.Windows.Forms.GroupBox()
      Me.lblLevel = New System.Windows.Forms.Label()
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnInsert = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLockBoq = New System.Windows.Forms.Button()
      Me.grbDetail.SuspendLayout()
      CType(Me.tgProgress, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSummarize.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnShowCBSDialog)
      Me.grbDetail.Controls.Add(Me.txtCBS)
      Me.grbDetail.Controls.Add(Me.txtFinishDate)
      Me.grbDetail.Controls.Add(Me.lblFinishDate)
      Me.grbDetail.Controls.Add(Me.dtpFinishDate)
      Me.grbDetail.Controls.Add(Me.txtStartDate)
      Me.grbDetail.Controls.Add(Me.lblStartDate)
      Me.grbDetail.Controls.Add(Me.dtpStartDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.tgProgress)
      Me.grbDetail.Controls.Add(Me.lblProgress)
      Me.grbDetail.Controls.Add(Me.ibtnBlankWBSProgress)
      Me.grbDetail.Controls.Add(Me.ibtnDelRowWBSProgress)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 352)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(872, 144)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียดหมวดงาน"
      '
      'ibtnShowCBSDialog
      '
      Me.ibtnShowCBSDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCBSDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCBSDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCBSDialog.Location = New System.Drawing.Point(445, 17)
      Me.ibtnShowCBSDialog.Name = "ibtnShowCBSDialog"
      Me.ibtnShowCBSDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCBSDialog.TabIndex = 217
      Me.ibtnShowCBSDialog.TabStop = False
      Me.ibtnShowCBSDialog.ThemedImage = CType(resources.GetObject("ibtnShowCBSDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCBS
      '
      Me.Validator.SetDataType(Me.txtCBS, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCBS, "")
      Me.txtCBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCBS, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCBS, System.Drawing.Color.Empty)
      Me.txtCBS.Location = New System.Drawing.Point(276, 17)
      Me.Validator.SetMinValue(Me.txtCBS, "")
      Me.txtCBS.Name = "txtCBS"
      Me.Validator.SetRegularExpression(Me.txtCBS, "")
      Me.Validator.SetRequired(Me.txtCBS, False)
      Me.txtCBS.Size = New System.Drawing.Size(166, 22)
      Me.txtCBS.TabIndex = 216
      '
      'txtFinishDate
      '
      Me.Validator.SetDataType(Me.txtFinishDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtFinishDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFinishDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtFinishDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtFinishDate, System.Drawing.Color.Empty)
      Me.txtFinishDate.Location = New System.Drawing.Point(336, 64)
      Me.Validator.SetMinValue(Me.txtFinishDate, "")
      Me.txtFinishDate.Name = "txtFinishDate"
      Me.Validator.SetRegularExpression(Me.txtFinishDate, "")
      Me.Validator.SetRequired(Me.txtFinishDate, False)
      Me.txtFinishDate.Size = New System.Drawing.Size(116, 21)
      Me.txtFinishDate.TabIndex = 3
      '
      'lblFinishDate
      '
      Me.lblFinishDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFinishDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFinishDate.Location = New System.Drawing.Point(240, 64)
      Me.lblFinishDate.Name = "lblFinishDate"
      Me.lblFinishDate.Size = New System.Drawing.Size(96, 18)
      Me.lblFinishDate.TabIndex = 44
      Me.lblFinishDate.Text = "Finish date:"
      Me.lblFinishDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpFinishDate
      '
      Me.dtpFinishDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpFinishDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFinishDate.Location = New System.Drawing.Point(336, 64)
      Me.dtpFinishDate.Name = "dtpFinishDate"
      Me.dtpFinishDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpFinishDate.TabIndex = 45
      Me.dtpFinishDate.TabStop = False
      '
      'txtStartDate
      '
      Me.Validator.SetDataType(Me.txtStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartDate, 23)
      Me.Validator.SetInvalidBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.txtStartDate.Location = New System.Drawing.Point(104, 64)
      Me.Validator.SetMinValue(Me.txtStartDate, "")
      Me.txtStartDate.Name = "txtStartDate"
      Me.Validator.SetRegularExpression(Me.txtStartDate, "")
      Me.Validator.SetRequired(Me.txtStartDate, False)
      Me.txtStartDate.Size = New System.Drawing.Size(116, 21)
      Me.txtStartDate.TabIndex = 2
      '
      'lblStartDate
      '
      Me.lblStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStartDate.Location = New System.Drawing.Point(8, 64)
      Me.lblStartDate.Name = "lblStartDate"
      Me.lblStartDate.Size = New System.Drawing.Size(96, 18)
      Me.lblStartDate.TabIndex = 41
      Me.lblStartDate.Text = "Start date:"
      Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpStartDate
      '
      Me.dtpStartDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpStartDate.Location = New System.Drawing.Point(104, 64)
      Me.dtpStartDate.Name = "dtpStartDate"
      Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpStartDate.TabIndex = 42
      Me.dtpStartDate.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 5
      Me.lblCode.Text = "Code:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(96, 22)
      Me.txtCode.TabIndex = 0
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, False)
      Me.txtName.Size = New System.Drawing.Size(456, 22)
      Me.txtName.TabIndex = 1
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 40)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(96, 18)
      Me.lblName.TabIndex = 4
      Me.lblName.Text = "Name:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(104, 87)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(456, 22)
      Me.txtNote.TabIndex = 4
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 87)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 3
      Me.lblNote.Text = "Remark:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgProgress
      '
      Me.tgProgress.AllowNew = False
      Me.tgProgress.AllowSorting = False
      Me.tgProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgProgress.AutoColumnResize = True
      Me.tgProgress.CaptionVisible = False
      Me.tgProgress.Cellchanged = False
      Me.tgProgress.DataMember = ""
      Me.tgProgress.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgProgress.Location = New System.Drawing.Point(584, 42)
      Me.tgProgress.Name = "tgProgress"
      Me.tgProgress.Size = New System.Drawing.Size(280, 93)
      Me.tgProgress.SortingArrowColor = System.Drawing.Color.Red
      Me.tgProgress.TabIndex = 215
      Me.tgProgress.TreeManager = Nothing
      '
      'lblProgress
      '
      Me.lblProgress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProgress.ForeColor = System.Drawing.Color.Black
      Me.lblProgress.Location = New System.Drawing.Point(584, 16)
      Me.lblProgress.Name = "lblProgress"
      Me.lblProgress.Size = New System.Drawing.Size(96, 18)
      Me.lblProgress.TabIndex = 5
      Me.lblProgress.Text = "Progress:"
      Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnBlankWBSProgress
      '
      Me.ibtnBlankWBSProgress.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlankWBSProgress.Location = New System.Drawing.Point(816, 16)
      Me.ibtnBlankWBSProgress.Name = "ibtnBlankWBSProgress"
      Me.ibtnBlankWBSProgress.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankWBSProgress.TabIndex = 2
      Me.ibtnBlankWBSProgress.TabStop = False
      Me.ibtnBlankWBSProgress.ThemedImage = CType(resources.GetObject("ibtnBlankWBSProgress.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRowWBSProgress
      '
      Me.ibtnDelRowWBSProgress.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRowWBSProgress.Location = New System.Drawing.Point(840, 16)
      Me.ibtnDelRowWBSProgress.Name = "ibtnDelRowWBSProgress"
      Me.ibtnDelRowWBSProgress.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRowWBSProgress.TabIndex = 3
      Me.ibtnDelRowWBSProgress.TabStop = False
      Me.ibtnDelRowWBSProgress.ThemedImage = CType(resources.GetObject("ibtnDelRowWBSProgress.ThemedImage"), System.Drawing.Bitmap)
      '
      'tvWbs
      '
      Me.tvWbs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tvWbs.FullRowSelect = True
      Me.tvWbs.HideSelection = False
      Me.tvWbs.Location = New System.Drawing.Point(8, 80)
      Me.tvWbs.Name = "tvWbs"
      Me.tvWbs.Size = New System.Drawing.Size(872, 265)
      Me.tvWbs.TabIndex = 1
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 64)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(208, 23)
      Me.lblItem.TabIndex = 9
      Me.lblItem.Text = "BOQ Work Breakdown Structure"
      '
      'lblBOQCode
      '
      Me.lblBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBOQCode.ForeColor = System.Drawing.Color.Black
      Me.lblBOQCode.Location = New System.Drawing.Point(8, 8)
      Me.lblBOQCode.Name = "lblBOQCode"
      Me.lblBOQCode.Size = New System.Drawing.Size(88, 18)
      Me.lblBOQCode.TabIndex = 8
      Me.lblBOQCode.Text = "รหัสBOQ:"
      Me.lblBOQCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBOQCode
      '
      Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBOQCode, "")
      Me.txtBOQCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.txtBOQCode.Location = New System.Drawing.Point(96, 8)
      Me.Validator.SetMinValue(Me.txtBOQCode, "")
      Me.txtBOQCode.Name = "txtBOQCode"
      Me.txtBOQCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
      Me.Validator.SetRequired(Me.txtBOQCode, False)
      Me.txtBOQCode.Size = New System.Drawing.Size(440, 22)
      Me.txtBOQCode.TabIndex = 7
      Me.txtBOQCode.TabStop = False
      '
      'txtProjectName
      '
      Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectName, "")
      Me.txtProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.txtProjectName.Location = New System.Drawing.Point(192, 30)
      Me.Validator.SetMinValue(Me.txtProjectName, "")
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectName, "")
      Me.Validator.SetRequired(Me.txtProjectName, False)
      Me.txtProjectName.Size = New System.Drawing.Size(344, 22)
      Me.txtProjectName.TabIndex = 6
      Me.txtProjectName.TabStop = False
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.Color.Black
      Me.lblProject.Location = New System.Drawing.Point(16, 32)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(80, 18)
      Me.lblProject.TabIndex = 4
      Me.lblProject.Text = "โครงการ:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(248, 56)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 2
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(296, 56)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 3
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtProjectCode
      '
      Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectCode, "")
      Me.txtProjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.txtProjectCode.Location = New System.Drawing.Point(96, 30)
      Me.Validator.SetMinValue(Me.txtProjectCode, "")
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.txtProjectCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
      Me.Validator.SetRequired(Me.txtProjectCode, False)
      Me.txtProjectCode.Size = New System.Drawing.Size(96, 22)
      Me.txtProjectCode.TabIndex = 5
      Me.txtProjectCode.TabStop = False
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
      'grbSummarize
      '
      Me.grbSummarize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummarize.Controls.Add(Me.lblLevel)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomOut)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomIn)
      Me.grbSummarize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummarize.Location = New System.Drawing.Point(752, 24)
      Me.grbSummarize.Name = "grbSummarize"
      Me.grbSummarize.Size = New System.Drawing.Size(128, 48)
      Me.grbSummarize.TabIndex = 15
      Me.grbSummarize.TabStop = False
      Me.grbSummarize.Text = "Summarize"
      '
      'lblLevel
      '
      Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel.Location = New System.Drawing.Point(64, 16)
      Me.lblLevel.Name = "lblLevel"
      Me.lblLevel.Size = New System.Drawing.Size(40, 23)
      Me.lblLevel.TabIndex = 13
      Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomOut.Location = New System.Drawing.Point(16, 16)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 12
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomIn.Location = New System.Drawing.Point(40, 16)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 11
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnInsert
      '
      Me.ibtnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnInsert.Location = New System.Drawing.Point(272, 56)
      Me.ibtnInsert.Name = "ibtnInsert"
      Me.ibtnInsert.Size = New System.Drawing.Size(24, 24)
      Me.ibtnInsert.TabIndex = 2
      Me.ibtnInsert.TabStop = False
      Me.ibtnInsert.ThemedImage = CType(resources.GetObject("ibtnInsert.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnLockBoq
      '
      Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
      Me.btnLockBoq.Location = New System.Drawing.Point(684, 30)
      Me.btnLockBoq.Name = "btnLockBoq"
      Me.btnLockBoq.Size = New System.Drawing.Size(38, 40)
      Me.btnLockBoq.TabIndex = 18
      Me.btnLockBoq.UseVisualStyleBackColor = True
      '
      'WBSDetail
      '
      Me.Controls.Add(Me.btnLockBoq)
      Me.Controls.Add(Me.grbSummarize)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.tvWbs)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblBOQCode)
      Me.Controls.Add(Me.txtBOQCode)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.lblProject)
      Me.Controls.Add(Me.txtProjectCode)
      Me.Controls.Add(Me.ibtnInsert)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "WBSDetail"
      Me.Size = New System.Drawing.Size(888, 504)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.tgProgress, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSummarize.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_wbs As WBS
    Private m_entity As BOQ
    Private m_isInitialized As Boolean
    Private m_TreeManager As TreeManager
    Private m_wbsInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()

      Dim dt As TreeTable = Me.GetSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle2
      m_TreeManager = New TreeManager(dt, tgProgress)
      m_TreeManager.SetTableStyle(dst)
      m_TreeManager.AllowSorting = False
      m_TreeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
#End Region

#Region "Table Style Access"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("WBSProgress")
      'myDatatable.Columns.Add(New DataColumn("selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("wbsp_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("wbsp_wbs", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("wbsp_progressdate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("wbsp_progress", GetType(Decimal)))
      Return myDatatable
    End Function

    Public Function CreateTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "WBSProgress"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "wbsp_linenumber"
      csLineNumber.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 50
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "wbsp_linenumber"

      Dim csProgressDate As New DataGridTimePickerColumn
      csProgressDate.MappingName = "wbsp_progressdate"
      csProgressDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.ProgressDateHeaderText}")
      csProgressDate.NullText = ""
      csProgressDate.Width = 90
      csProgressDate.ReadOnly = False

      Dim csProgress As New TreeTextColumn
      csProgress.MappingName = "wbsp_progress"
      csProgress.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.ProgressHeaderText}")
      csProgress.NullText = ""
      csProgress.Width = 75
      csProgress.DataAlignment = HorizontalAlignment.Right
      csProgress.Alignment = HorizontalAlignment.Right
      csProgress.TextBox.Name = "wbsp_progress"
      csProgress.ReadOnly = False

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csProgressDate)
      dst.GridColumnStyles.Add(csProgress)

      Return dst
    End Function

    Private Sub RefreshWBSProgress(ByVal wbsid As Integer)

      Dim dt As TreeTable = Me.m_TreeManager.Treetable
      dt.Clear()
      m_wbsInitialized = False
      Me.WBSProgressColl.Populate(dt, m_wbs.Id)
      m_wbsInitialized = True
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property WBSProgressColl() As WBSProgressCollection
      Get
        For Each ext As IExtender In m_entity.Extenders
          If TypeOf ext Is WBSProgressCollection Then
            Return CType(ext, WBSProgressCollection)
          End If
        Next
        Return New WBSProgressCollection(Me.m_entity)
      End Get
    End Property
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      '-------- ให้เห็น ปุ่ม lock
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(349)       'ตรวจสอบ สิทธิปลดล๊อคใบรับของ
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)      'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)

      btnLockBoq.Visible = True
      If Not CBool(checkString.Substring(0, 1)) Then
        btnLockBoq.Visible = False
      End If
      '----------
      If Me.m_entity.Status.Value = 0 OrElse _
      Me.m_entity.Status.Value >= 3 Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
        Me.ibtnBlank.Enabled = False
        Me.ibtnDelRow.Enabled = False
        Me.ibtnInsert.Enabled = False
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = True
        Next
        Me.ibtnBlank.Enabled = True
        Me.ibtnDelRow.Enabled = True
        Me.ibtnInsert.Enabled = True
      End If
      If Not m_entity.Originated Then
        btnLockBoq.Visible = False
        ibtnDelRow.Enabled = True
        ibtnBlank.Enabled = True
        ibtnInsert.Enabled = True
      ElseIf m_entity.Locked Then
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
        'btnLockBoq.Text = "UnLock"
        ibtnDelRow.Enabled = False
        ibtnBlank.Enabled = False
        ibtnInsert.Enabled = False
      Else
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_unlocked
        'btnLockBoq.Text = "Lock"
        ibtnDelRow.Enabled = True
        ibtnBlank.Enabled = True
        ibtnInsert.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_wbs Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_wbs.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblCode}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblItem}")
      Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblBOQCode}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblProject}")

      Me.lblStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblStartDate}")
      Me.Validator.SetDisplayName(txtStartDate, lblStartDate.Text)
      Me.lblFinishDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblFinishDate}")
      Me.Validator.SetDisplayName(txtFinishDate, lblFinishDate.Text)
      Me.lblProgress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSDetail.lblProgress}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf TextHandler
      AddHandler txtCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCBS.Validated, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtFinishDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpFinishDate.ValueChanged, AddressOf Me.ChangeProperty
    End Sub
    Private txtCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          txtCodeChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของ WBS ลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.WBSCollection.Count = 0 Then
        Dim newWbs As New WBS
        newWbs.Parent = newWbs
        newWbs.Code = Me.m_entity.Project.Code
        newWbs.Name = Me.m_entity.Project.Name
        newWbs.Note = "<Default>"
        m_entity.WBSCollection.Add(newWbs)
      End If
      m_entity.WBSCollection.Populate(Me.tvWbs)
      Me.tvWbs.ExpandAll()
      If Me.tvWbs.Nodes.Count > 0 Then
        Me.tvWbs.SelectedNode = Me.tvWbs.Nodes(0)
      End If



      UpdateRefDoc()

      RefreshWBSProgress(m_wbs.Id)

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateRefDoc()
      txtBOQCode.Text = m_entity.Code
      If Not m_entity.Project Is Nothing Then
        txtProjectCode.Text = m_entity.Project.Code
        txtProjectName.Text = m_entity.Project.Name
      End If
    End Sub
    Private Sub UpdateWBS()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      txtCode.Text = m_wbs.Code
      txtName.Text = m_wbs.Name
      txtNote.Text = m_wbs.Note
      txtStartDate.Text = m_wbs.StartDate.ToShortDateString
      txtFinishDate.Text = m_wbs.FinishDate.ToShortDateString
      If m_wbs.MatCBS Is Nothing Then
        txtCBS.Text = ""
      Else
        txtCBS.Text = m_wbs.MatCBS.Code & ":" & m_wbs.MatCBS.Name
      End If
      'If Me.m_wbs.Level = 0 Then
      '    Me.grbDetail.Enabled = False
      'Else
      '    Me.grbDetail.Enabled = True
      'End If

      Me.RefreshWBSProgress(m_wbs.Id)

      Me.txtCodeChanged = False
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateNode()
      Me.tvWbs.SelectedNode.Text = m_wbs.ToString
    End Sub
    Private Sub ClearWBS()
      txtCode.Text = ""
      txtCBS.Text = ""
      txtName.Text = ""
      txtNote.Text = ""
      txtStartDate.Text = ""
      txtFinishDate.Text = ""
    End Sub
    Private Function DupCode(ByVal txt As TextBox) As Boolean
      For Each myWBS As WBS In Me.m_entity.WBSCollection
        If Not Me.m_wbs Is myWBS And myWBS.Code = txt.Text Then
          Return True
        End If
      Next
      Return False
    End Function
    Private m_stdateSetting As Boolean = False
    Private m_fidateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_wbs Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          If txtCodeChanged Then
            txtCodeChanged = False
            If Not DupCode(txtCode) Then
              Me.m_wbs.Code = txtCode.Text
              UpdateNode()
              dirtyFlag = True
            Else
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeDup}", New String() {txtCode.Text})
              txtCode.Text = Me.m_wbs.Code
              dirtyFlag = True
            End If
          End If
        Case "txtCBS"
          UpdateNode()
          'If txtCodeChanged Then
          '  txtCodeChanged = False
          '  If Not DupCode(txtCode) Then
          '    Me.m_wbs.Code = txtCode.Text
          '    UpdateNode()
          '    dirtyFlag = True
          '  Else
          '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          '    msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeDup}", New String() {txtCode.Text})
          '    txtCode.Text = Me.m_wbs.Code
          '    dirtyFlag = True
          '  End If
          'End If
        Case "txtname"
          Me.m_wbs.Name = txtName.Text
          UpdateNode()
          dirtyFlag = True
        Case "txtnote"
          Me.m_wbs.Note = txtNote.Text
          UpdateNode()
          dirtyFlag = True
        Case "dtpstartdate"
          If Not Me.m_wbs.StartDate.Equals(dtpStartDate.Value) Then
            If Not m_stdateSetting Then
              Me.txtStartDate.Text = MinDateToNull(dtpStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_wbs.StartDate = dtpStartDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtstartdate"
          m_stdateSetting = True
          If Not Me.txtStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtStartDate.Text)
            If Not Me.m_wbs.StartDate.Equals(theDate) Then
              dtpStartDate.Value = theDate
              Me.m_wbs.StartDate = dtpStartDate.Value
              dirtyFlag = True
            End If
          Else
            dtpStartDate.Value = Date.Now
            Me.m_wbs.StartDate = Date.MinValue
            dirtyFlag = True
          End If
          m_stdateSetting = False

        Case "dtpfinishdate"
          If Not Me.m_wbs.FinishDate.Equals(dtpFinishDate.Value) Then
            If Not m_fidateSetting Then
              Me.txtFinishDate.Text = MinDateToNull(dtpFinishDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_wbs.FinishDate = dtpFinishDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtfinishdate"
          m_fidateSetting = True
          If Not Me.txtFinishDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtFinishDate) = "" Then
            Dim theDate As Date = CDate(Me.txtFinishDate.Text)
            If Not Me.m_wbs.FinishDate.Equals(theDate) Then
              dtpFinishDate.Value = theDate
              Me.m_wbs.FinishDate = dtpFinishDate.Value
              dirtyFlag = True
            End If
          Else
            dtpFinishDate.Value = Date.Now
            Me.m_wbs.FinishDate = Date.MinValue
            dirtyFlag = True
          End If
          m_fidateSetting = False
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.Dispose()
            Me.m_entity = Nothing
          End If
          Me.m_entity = CType(Value, BOQ)
        End If
        If Me.WorkbenchWindow.ActiveViewContent Is Me Then
          UpdateEntityProperties()
        End If
      End Set
    End Property
    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub tvWbs_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvWbs.BeforeSelect
      'If Me.IsDirty Then
      '    Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      '    Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
      '    Select Case dr
      '        Case DialogResult.Yes
      '            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
      '            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.Save), CType(Me, ISimpleListPanel).SelectedEntity)
      '        Case DialogResult.No
      '            Me.IsDirty = False
      '        Case DialogResult.Cancel
      '            e.Cancel = True
      '            Return
      '    End Select
      'End If
      'If Me.tvWbs.SelectedNode Is Nothing OrElse Not TypeOf Me.tvWbs.SelectedNode.Tag Is IdValuePair Then
      '    Return
      'End If
      'Dim item As IdValuePair = CType(Me.tvWbs.SelectedNode.Tag, IdValuePair)
      'If item.Value = "glformat" And item.Id = 0 Then
      '    Me.tvWbs.SelectedNode.Remove()
      'End If
    End Sub
    Private Sub tvWbs_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvWbs.AfterSelect
      If TypeOf e.Node.Tag Is WBS Then
        Dim myWbs As WBS = CType(e.Node.Tag, WBS)
        Me.m_wbs = myWbs
        UpdateWBS()
      Else
        ClearWBS()
      End If
      WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim node As TreeNode = Me.tvWbs.SelectedNode
      If node Is Nothing Then
        Return
      End If
      If TypeOf node.Tag Is WBS Then
        Dim parentWbs As WBS = CType(node.Tag, WBS)
        Dim newWbs As New WBS(parentWbs)
        newWbs.StartDate = Now.ToShortDateString
        newWbs.FinishDate = Now.ToShortDateString
        Dim newNode As TreeNode = node.Nodes.Add("<NEW>")
        newNode.Tag = newWbs
        Me.m_wbs = newWbs
        Me.m_entity.WBSCollection.Add(newWbs)
        Me.tvWbs.SelectedNode = newNode

        parentWbs.Childs = Me.m_entity.WBSCollection.GetChildsOf(parentWbs)
        If Me.txtCode.CanFocus Then
          Me.txtCode.Focus()
        End If

        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnInsert.Click
      Dim node As TreeNode = Me.tvWbs.SelectedNode
      If node Is Nothing Then
        Return
      End If
      If TypeOf node.Tag Is WBS Then
        Dim friendWbs As WBS = CType(node.Tag, WBS)
        If friendWbs.Parent Is Nothing Then
          Return
        End If
        If node.Parent Is Nothing Then
          Return
        End If
        If Not TypeOf node.Parent.Tag Is WBS Then
          Return
        End If
        Dim parentWbs As WBS = CType(node.Parent.Tag, WBS)
        Dim newWbs As New WBS(parentWbs)
        Dim newNode As New TreeNode("<NEW>")
        node.Parent.Nodes.Insert(node.Parent.Nodes.IndexOf(node), newNode)
        newNode.Tag = newWbs
        Me.m_wbs = newWbs
        Me.m_wbs.StartDate = Now.ToShortDateString
        Me.m_wbs.FinishDate = Now.ToShortDateString
        Me.m_entity.WBSCollection.Insert(Me.m_entity.WBSCollection.IndexOf(friendWbs), newWbs)
        Me.tvWbs.SelectedNode = newNode

        parentWbs.Childs = Me.m_entity.WBSCollection.GetChildsOf(parentWbs)
        If Me.txtCode.CanFocus Then
          Me.txtCode.Focus()
        End If

        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      If m_wbs Is Nothing Then
        Return
      End If
      If m_wbs.Status.Value >= 3 Or m_wbs.IsReferenced Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessageFormatted("${res:Global.Error.WBSWasRefCannotDelete}", New String() {m_wbs.ToString})
        Return
      End If
      Dim node As TreeNode = Me.tvWbs.SelectedNode
      If node Is Nothing OrElse node Is Me.tvWbs.Nodes(0) Then
        Return
      End If
      nodeWasRef = False
      TreeViewHelper.TraverseNodeBackward(node, AddressOf CheckNodeStatus)
      If nodeWasRef Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessageFormatted("${res:Global.Error.ChildWBSWasRefCannotDelete}", New String() {m_wbs.ToString})
        Return
      End If
      TreeViewHelper.TraverseNodeBackward(node, AddressOf DeleteNode)
      Me.tvWbs.SelectedNode.Remove()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private nodeWasRef As Boolean = False
    Private Sub CheckNodeStatus(ByVal n As TreeNode)
      If TypeOf n.Tag Is WBS Then
        Dim myWbs As WBS = CType(n.Tag, WBS)
        If myWbs.Status.Value >= 3 Or myWbs.Referenced Then
          nodeWasRef = True
        End If
        'If GetChildReferenced(myWbs) Then
        '  nodeWasRef = True
        'End If
      End If
    End Sub
    'Private Function GetChildReferenced(ByVal nwbs As WBS) As Boolean
    '  For Each child As WBS In nwbs.Childs
    '    If child.Referenced Then
    '      Return True
    '    End If
    '    If GetChildReferenced(child) Then
    '      Return True
    '    End If
    '  Next
    'End Function
    Private Sub DeleteNode(ByVal n As TreeNode)
      If TypeOf n.Tag Is WBS Then
        Dim wbsp As WBS = CType(n.Tag, WBS).Parent
        wbsp.Childs.Remove(CType(n.Tag, WBS))
        Me.m_entity.WBSCollection.Remove(CType(n.Tag, WBS))
      End If
    End Sub
    Private Sub ibtnBlankWBSProgress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankWBSProgress.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim wbsp As New WBSProgress
      wbsp.WBSId = m_wbs.Id
      wbsp.ProgressDate = Now
      Me.WBSProgressColl.Add(wbsp)
      RefreshWBSProgress(m_wbs.Id)
      Me.tgProgress.CurrentRowIndex = Me.WBSProgressColl.RowCount - 1 'Me.WBSProgressColl.Count - 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRowWBSProgress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRowWBSProgress.Click
      If Me.m_entity.WBSCollection.Count <= 0 Then
        Return
      End If

      'Dim index As Integer = Me.tgProgress.CurrentRowIndex

      Me.WBSProgressColl.Remove(CurrentWBSProgress)

      'Me.m_entity.WBSCollection.Remove(index)
      Me.RefreshWBSProgress(m_wbs.Id)

      Me.WorkbenchWindow.ViewContent.IsDirty = True
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
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New WBS).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        Return Me.tvWbs.Focused AndAlso Not Me.tvWbs.SelectedNode Is Nothing
      End Get
    End Property
    Public Overrides ReadOnly Property EnableCut() As Boolean
      Get
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Return Me.tvWbs.Focused AndAlso Not Me.tvWbs.SelectedNode Is Nothing AndAlso Not m_copiedNode Is Nothing
      End Get
    End Property
    Private m_copiedNode As TreeNode
    Private m_copiedBOQ As BOQ
    Public Shared CopiedBOQ As BOQ
    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      m_copiedNode = CType(Me.tvWbs.SelectedNode.Clone, TreeNode)
      m_copiedBOQ = m_entity
      CopiedBOQ = m_entity
      WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Private copyboq As BOQ
    Private Sub CopyNode(ByVal n As TreeNode, ByVal o As Object)

      If copyboq Is Nothing OrElse copyboq.Id <> CType(o, BOQ).Id Then
        copyboq = New BOQ(CType(o, BOQ).Id)
      End If

      If TypeOf n.Tag Is WBS Then
        Dim myWbs As WBS = CType(n.Tag, WBS)
        Dim newWbs As New WBS
        newWbs.Boq = copyboq
        newWbs.Code = myWbs.Code & "*"
        newWbs.Name = myWbs.Name
        newWbs.Note = myWbs.Note
        newWbs.AlternateName = myWbs.AlternateName
        n.Tag = newWbs
        n.Text = newWbs.ToString
        If Not n.Parent Is Nothing Then
          If TypeOf n.Parent.Tag Is WBS Then
            newWbs.Parent = CType(n.Parent.Tag, WBS)
            newWbs.Level = newWbs.Parent.Level + 1
          End If
        ElseIf Not Me.tvWbs.SelectedNode Is Nothing Then
          If TypeOf Me.tvWbs.SelectedNode.Tag Is WBS Then
            newWbs.Parent = CType(Me.tvWbs.SelectedNode.Tag, WBS)
            newWbs.Level = newWbs.Parent.Level + 1
          End If
        End If
        CType(Me.tvWbs.SelectedNode.Tag, WBS).Childs.Add(newWbs)
        Me.m_entity.WBSCollection.Add(newWbs)

        'For Each item As BoqItem In Me.m_entity.ItemCollection.GetCollectionForWBS(myWbs)
        For Each item As BoqItem In copyboq.ItemCollection.GetCollectionForWBS(myWbs) 'CType(o, BOQ).ItemCollection.GetCollectionForWBS(myWbs)
          Dim newItem As New BoqItem
          newItem.WBS = newWbs

          newItem.Entity = item.Entity
          newItem.EntityName = item.EntityName
          newItem.ItemType = item.ItemType
          newItem.Note = item.Note
          newItem.Qty = item.Qty
          newItem.UEC = item.UEC
          newItem.ULC = item.ULC
          newItem.UMC = item.UMC
          newItem.Unit = item.Unit

          Me.m_entity.ItemCollection.Add(newItem)
        Next
      End If
    End Sub
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      TreeViewHelper.TraverseNodeWithObject(m_copiedNode, m_copiedBOQ, AddressOf CopyNode)
      Me.tvWbs.SelectedNode.Nodes.Add(m_copiedNode)
      m_copiedNode = CType(m_copiedNode.Clone, TreeNode)
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Select Case keyPressed
        Case Keys.Insert
          ibtnBlank_Click(Nothing, Nothing)
          Return True
        Case Keys.Delete
          If Me.tvWbs.Focused Then
            ibtnDelRow_Click(Nothing, Nothing)
            Return True
          Else
            Return False
          End If
        Case Else
          Return False
      End Select
    End Function
#End Region

#Region "Summarize"
    Private m_level As Integer
    Private m_affected As Boolean
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      If m_level > 0 Then
        m_level -= 1
      End If
      TreeViewHelper.TraverseNode(Me.tvWbs.Nodes(0), AddressOf Summarize, m_level)
      Me.lblLevel.Text = m_level.ToString()
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      m_level += 1
      m_affected = False
      TreeViewHelper.TraverseNode(Me.tvWbs.Nodes(0), AddressOf Summarize, m_level)
      If Not m_affected Then
        m_level -= 1
      End If
      Me.lblLevel.Text = m_level.ToString()
    End Sub
    Private Sub Summarize(ByVal n As TreeNode)
      If Not m_affected Then
        m_affected = True
      End If
      n.Collapse()
      n.EnsureVisible()
    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "TreeTable Handlers"
    Dim oldPercentAmount As Decimal
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsInitialized Then
        Return
      End If

      Dim index As Integer = Me.m_TreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_TreeManager.Treetable.AcceptChanges()
      End If
      oldPercentAmount = e.ProposedValue
      Dim currIndex As Integer = Me.tgProgress.CurrentRowIndex
      RefreshWBSProgress(m_wbs.Id)
      tgProgress.CurrentRowIndex = currIndex
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsInitialized Then
        Return
      End If
      oldPercentAmount = Me.CurrentWBSProgress.Progress

      Try

        Select Case e.Column.ColumnName.ToLower
          Case "wbsp_progressdate"
            If Not IsDBNull(e.ProposedValue) Then
              SetProgressDate(e)
            End If
          Case "wbsp_progress"
            SetProgress(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)

      Dim progressdate As Object = e.Row("wbsp_progressdate")
      Dim progress As Object = e.Row("wbsp_progress")

      Select Case e.Column.ColumnName.ToLower
        Case "wbsp_progressdate"
          progressdate = e.ProposedValue
        Case "wbsp_progress"
          progress = e.ProposedValue
        Case Else
          Return
      End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(name) Then
      '    isBlankRow = True
      'End If

      'If Not isBlankRow Then
      If IsDBNull(progressdate) Then
        e.Row.SetColumnError("wbsp_progressdate", "")
      End If

      'If IsDBNull(progress) Then
      '    e.Row.SetColumnError("wbsp_progress", "")
      'End If

      'End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("wbsp_progressdate") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetProgressDate(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As WBSProgress = Me.CurrentWBSProgress
      If item Is Nothing Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      item.ProgressDate = CDate(e.ProposedValue).ToShortDateString
      m_updating = False
    End Sub
    Public Sub SetProgress(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As WBSProgress = Me.CurrentWBSProgress
      If item Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim progress As Object = e.ProposedValue  'e.Row("wbsp_progress")
      Dim sumPercent As Decimal = 0
      For Each row As TreeRow In Me.m_TreeManager.Treetable.Rows
        If Not row.IsNull("wbsp_progress") Then
          If m_wbs.Id.Equals(row("wbsp_wbs")) Then
            sumPercent += CDec(row("wbsp_progress"))
          End If
        End If
      Next
      If (sumPercent + progress) - oldPercentAmount > 100 Then
        e.ProposedValue = e.Row(e.Column)
        msgServ.ShowMessage("${res:Global.Error.PercentSuccessMissing}")
        'e.Row.SetColumnError("wbsp_progress", Me.StringParserService.Parse("${res:Global.Error.PercentSuccessMissing}"))
        Return
      End If

      m_updating = True
      item.Progress = Configuration.FormatToString(e.ProposedValue, DigitConfig.Price)
      m_updating = False
    End Sub
    Private ReadOnly Property CurrentWBSProgress() As WBSProgress
      Get
        Dim row As TreeRow = Me.m_TreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSProgress)
      End Get
    End Property
#End Region

    Private Sub btnLockBoq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockBoq.Click
      If m_entity.Locked Then
        m_entity.Locked = False

      Else
        m_entity.Locked = True

      End If
      UpdateEntityProperties()
    End Sub

    Private Sub btnLockBoq_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockBoq.MouseHover, btnLockBoq.GotFocus
      If Not m_entity.Originated Then
        btnLockBoq.Visible = False
      ElseIf m_entity.Locked Then
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_unlocked
      Else
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
      End If

    End Sub

    Private Sub SetCBS(ByVal myEntity As ISimpleEntity)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      If m_wbs Is Nothing Then
        Return
      End If
      
      If TypeOf myEntity Is CBS Then
        m_wbs.MatCBS = CType(myEntity, CBS)
      End If
      
      If m_wbs.MatCBS Is Nothing Then
        txtCBS.Text = ""
      Else
        txtCBS.Text = m_wbs.MatCBS.Code & ":" & m_wbs.MatCBS.Name
      End If
            UpdateNode()

      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True

    End Sub
    Private Sub ibtnShowCBSDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCBSDialog.Click
      If Me.m_entity Is Nothing Then
        Return
      End If

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CBS
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCBS)
    End Sub

    Private Sub btnLockBoq_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockBoq.MouseLeave
      If Not m_entity.Originated Then
        btnLockBoq.Visible = False
      ElseIf m_entity.Locked Then
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_locked
      Else
        Me.btnLockBoq.Image = Global.My.Resources.Resources.padlock_unlocked
      End If
    End Sub
  End Class
End Namespace