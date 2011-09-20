Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptEQTMaintenanceFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents btnToolEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnToolStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblToolCode As System.Windows.Forms.Label
    Friend WithEvents lblEQCode As System.Windows.Forms.Label
    Friend WithEvents txtToolCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblToolEnd As System.Windows.Forms.Label
    Friend WithEvents txtToolCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeTGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents ChkCancel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptEQTMaintenanceFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ChkCancel = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnToolEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnToolStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToolCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblToolEnd = New System.Windows.Forms.Label()
      Me.txtToolCodeStart = New System.Windows.Forms.TextBox()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.chkIncludeTGChildren = New System.Windows.Forms.CheckBox()
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtGroupCode = New System.Windows.Forms.TextBox()
      Me.lblGroup = New System.Windows.Forms.Label()
      Me.txtGroupName = New System.Windows.Forms.TextBox()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.ChkCancel)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 4)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(460, 190)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'ChkCancel
      '
      Me.ChkCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ChkCancel.Location = New System.Drawing.Point(16, 163)
      Me.ChkCancel.Name = "ChkCancel"
      Me.ChkCancel.Size = New System.Drawing.Size(240, 24)
      Me.ChkCancel.TabIndex = 4
      Me.ChkCancel.Text = "แสดงสินทรัพย์ยกเลิกสถานะ และ Write off"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkIncludeTGChildren)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.btnToolEndFind)
      Me.grbDetail.Controls.Add(Me.btnToolStartFind)
      Me.grbDetail.Controls.Add(Me.txtToolCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblToolEnd)
      Me.grbDetail.Controls.Add(Me.txtToolCodeStart)
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(431, 142)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(37, 42)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(88, 18)
      Me.Label1.TabIndex = 37
      Me.Label1.Text = "ข้อมูลเครื่องมือ"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnToolEndFind
      '
      Me.btnToolEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolEndFind.Location = New System.Drawing.Point(392, 42)
      Me.btnToolEndFind.Name = "btnToolEndFind"
      Me.btnToolEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolEndFind.TabIndex = 36
      Me.btnToolEndFind.TabStop = False
      Me.btnToolEndFind.ThemedImage = CType(resources.GetObject("btnToolEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnToolStartFind
      '
      Me.btnToolStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolStartFind.Location = New System.Drawing.Point(227, 40)
      Me.btnToolStartFind.Name = "btnToolStartFind"
      Me.btnToolStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolStartFind.TabIndex = 35
      Me.btnToolStartFind.TabStop = False
      Me.btnToolStartFind.ThemedImage = CType(resources.GetObject("btnToolStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToolCodeEnd
      '
      Me.Validator.SetDataType(Me.txtToolCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.txtToolCodeEnd.Location = New System.Drawing.Point(289, 42)
      Me.Validator.SetMinValue(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Name = "txtToolCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtToolCodeEnd, "")
      Me.Validator.SetRequired(Me.txtToolCodeEnd, False)
      Me.txtToolCodeEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtToolCodeEnd.TabIndex = 32
      '
      'lblToolEnd
      '
      Me.lblToolEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolEnd.ForeColor = System.Drawing.Color.Black
      Me.lblToolEnd.Location = New System.Drawing.Point(259, 42)
      Me.lblToolEnd.Name = "lblToolEnd"
      Me.lblToolEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblToolEnd.TabIndex = 34
      Me.lblToolEnd.Text = "ถึง"
      Me.lblToolEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtToolCodeStart
      '
      Me.Validator.SetDataType(Me.txtToolCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.txtToolCodeStart.Location = New System.Drawing.Point(131, 40)
      Me.Validator.SetMinValue(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Name = "txtToolCodeStart"
      Me.Validator.SetRegularExpression(Me.txtToolCodeStart, "")
      Me.Validator.SetRequired(Me.txtToolCodeStart, False)
      Me.txtToolCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtToolCodeStart.TabIndex = 31
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(227, 112)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 28
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(131, 112)
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 6
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(29, 112)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(96, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "CostCenter"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(289, 18)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(131, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(131, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(289, 18)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(130, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(37, 18)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(259, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(372, 161)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(292, 161)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(474, 36)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Visible = False
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
      'chkIncludeTGChildren
      '
      Me.chkIncludeTGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeTGChildren.Location = New System.Drawing.Point(131, 90)
      Me.chkIncludeTGChildren.Name = "chkIncludeTGChildren"
      Me.chkIncludeTGChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeTGChildren.TabIndex = 65
      Me.chkIncludeTGChildren.Text = "รวมกลุ่มเครื่องมือ"
      '
      'btnGroupFind
      '
      Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Location = New System.Drawing.Point(371, 64)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 64
      Me.btnGroupFind.TabStop = False
      Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGroupCode
      '
      Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupCode, "")
      Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.txtGroupCode.Location = New System.Drawing.Point(131, 64)
      Me.txtGroupCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtGroupCode, "")
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
      Me.Validator.SetRequired(Me.txtGroupCode, False)
      Me.txtGroupCode.Size = New System.Drawing.Size(96, 21)
      Me.txtGroupCode.TabIndex = 62
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(51, 64)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(72, 18)
      Me.lblGroup.TabIndex = 61
      Me.lblGroup.Text = "กลุ่มเครื่องมือ:"
      Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGroupName
      '
      Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupName, "")
      Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.txtGroupName.Location = New System.Drawing.Point(227, 64)
      Me.Validator.SetMinValue(Me.txtGroupName, "")
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGroupName, "")
      Me.Validator.SetRequired(Me.txtGroupName, False)
      Me.txtGroupName.Size = New System.Drawing.Size(144, 21)
      Me.txtGroupName.TabIndex = 63
      Me.txtGroupName.TabStop = False
      '
      'RptEQTMaintenanceFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Controls.Add(Me.txtTemp)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptEQTMaintenanceFilterSubPanel"
      Me.Size = New System.Drawing.Size(476, 201)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      'Me.chkTool.checkbox = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolStatusFilterSubPanel.lblToolCode}")
      'Me.Validator.SetDisplayName(txtToolCodeStart, lblToolCode.Text)

      'Me.lblEQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptEquipmentStatusFilterSubPanel.lblEQCode}")
      'Me.Validator.SetDisplayName(txtEQCodeStart, lblEQCode.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblToolEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToolCodeEnd, lblToolEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_equipmentstart As Equipment
    Private m_equipmentend As Equipment

    Private m_toolstart As Tool
    Private m_toolend As Tool

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter
    Dim m_toolgroup As New ToolGroup
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property equipmentstart() As Equipment
      Get
        Return m_equipmentstart
      End Get
      Set(ByVal Value As Equipment)
        m_equipmentstart = Value
      End Set
    End Property
    Public Property EquipmentEnd() As Equipment
      Get
        Return m_equipmentend
      End Get
      Set(ByVal Value As Equipment)
        m_equipmentend = Value
      End Set
    End Property
    Public Property Toolstart() As Tool
      Get
        Return m_toolstart
      End Get
      Set(ByVal Value As Tool)
        m_toolstart = Value
      End Set
    End Property
    Public Property ToolEnd() As Tool
      Get
        Return m_toolend
      End Get
      Set(ByVal Value As Tool)
        m_toolend = Value
      End Set
    End Property
    Private Property Group() As ToolGroup
      Get
        Return m_toolgroup
      End Get
      Set(ByVal Value As ToolGroup)
        m_toolgroup = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
#End Region

#Region "Methods"

    Private Sub Initialize()
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

      Me.CostCenter = New CostCenter

      Me.equipmentstart = New Equipment
      Me.EquipmentEnd = New Equipment

      Me.Toolstart = New Tool
      Me.ToolEnd = New Tool

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.ChkCancel.Checked = False
      Me.Group = New ToolGroup
      Me.chkIncludeTGChildren.Checked = False
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(7) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("ToolCodeStart", IIf(txtToolCodeStart.TextLength > 0, txtToolCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("ToolCodeEnd", IIf(txtToolCodeEnd.TextLength > 0, txtToolCodeEnd.Text, DBNull.Value))
      'arr(4) = New Filter("EquipmentCodeStart", IIf(txtEQCodeStart.TextLength > 0, txtEQCodeStart.Text, DBNull.Value))
      'arr(5) = New Filter("EquipmentCodeEnd", IIf(txtEQCodeEnd.TextLength > 0, txtEQCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("CostCenter", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      'arr(7) = New Filter("ChkCancel", IIf(ChkCancel.Checked, 1, 0))
      arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'arr(6) = New Filter("ChkTool", IIf(chkTool.Checked, 1, 0))
      'arr(9) = New Filter("ChkEquipment", IIf(chkEquipment.Checked, 1, 0))
      arr(6) = New Filter("ToolGroup", IIf(Me.Group.Valid, Me.Group.Id, DBNull.Value))
      arr(7) = New Filter("includeChildtg", Me.chkIncludeTGChildren.Checked)
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

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Tool Start
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeStart"
      dpi.Value = Me.txtToolCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Tool End
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeEnd"
      dpi.Value = Me.txtToolCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''EquipmentCodeStart 
      'dpi = New DocPrintingItem
      'dpi.Mapping = "EquipmentCodeStart"
      'dpi.Value = Me.txtEQCodeStart.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''EquipmentCodeEnd
      'dpi = New DocPrintingItem
      'dpi.Mapping = "EquipmentCodeEnd"
      'dpi.Value = Me.txtEQCodeEnd.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      'AddHandler btnEQStartFind.Click, AddressOf Me.btnEQFind_Click
      'AddHandler btnEQEndFind.Click, AddressOf Me.btnEQFind_Click

      AddHandler btnToolStartFind.Click, AddressOf Me.btnToolFind_Click
      AddHandler btnToolEndFind.Click, AddressOf Me.btnToolFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtassetcodestart", "txtassetcodeend"
                Return True
            End Select
          End If
        End If
        ' CostCenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      'Equipment
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtEQcodestart"
              'Me.SetEQStartDialog(entity)

            Case "txtEQcodeend"
              'Me.SetEQEndDialog(entity)

          End Select
        End If
      End If
      'Tool
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtToolcodestart"
              Me.SetToolStartDialog(entity)

            Case "txtToolcodeend"
              Me.SetToolEndDialog(entity)

          End Select
        End If
      End If
      ' CostCenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'Private Sub btnEQFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btneqstartfind"
    '      myEntityPanelService.OpenListDialog(New Equipment, AddressOf SetEQStartDialog)

    '    Case "btneqendfind"
    '      myEntityPanelService.OpenListDialog(New Equipment, AddressOf SetEQEndDialog)
    '  End Select
    'End Sub
    Private Sub btnToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btntoolstartfind"

          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolStartDialog)

        Case "btntoolendfind"
          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolEndDialog)
      End Select
    End Sub
    ' CostCenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCStartFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    'Private Sub SetEQStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtEQCodeStart.Text = e.Code
    '  Equipment.GetEquipment(txtEQCodeStart, txtTemp, Me.equipmentstart)
    'End Sub

    'Private Sub SetEQEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtEQCodeEnd.Text = e.Code
    '  Equipment.GetEquipment(txtEQCodeEnd, txtTemp, Me.EquipmentEnd)
    'End Sub
    Private Sub SetToolStartDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeStart.Text = e.Code
      Tool.GetTool(txtToolCodeStart, txtTemp, Me.Toolstart)
    End Sub
    Private Sub SetToolEndDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeEnd.Text = e.Code
      Tool.GetTool(txtToolCodeEnd, txtTemp, Me.ToolEnd)
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
      ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
    End Sub

    Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroup)
    End Sub
    Private Sub SetToolGroup(ByVal e As ISimpleEntity)
      Me.txtGroupCode.Text = e.Code
      ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
    End Sub
#End Region

    Private Sub chkTool_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
  End Class
End Namespace

