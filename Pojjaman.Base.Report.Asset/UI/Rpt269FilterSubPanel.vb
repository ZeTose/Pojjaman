Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class Rpt269FilterSubPanel
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
    Friend WithEvents btnCCEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCCEnd As System.Windows.Forms.Label
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtAssetCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetStart As System.Windows.Forms.Label
    Friend WithEvents btnAssetEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAssetTypeCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnAssetTypeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetTypeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAssetTypeEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetTypeCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetTypeStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Rpt269FilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnCCEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeEnd = New System.Windows.Forms.TextBox
      Me.lblCCEnd = New System.Windows.Forms.Label
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox
      Me.lblCCStart = New System.Windows.Forms.Label
      Me.btnAssetStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnAssetEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAssetCodeEnd = New System.Windows.Forms.TextBox
      Me.lblAssetEnd = New System.Windows.Forms.Label
      Me.txtAssetCodeStart = New System.Windows.Forms.TextBox
      Me.lblAssetStart = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.txtAssetTypeCodeEnd = New System.Windows.Forms.TextBox
      Me.btnAssetTypeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnAssetTypeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblAssetTypeEnd = New System.Windows.Forms.Label
      Me.txtAssetTypeCodeStart = New System.Windows.Forms.TextBox
      Me.lblAssetTypeStart = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(440, 176)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(448, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnCCEndFind)
      Me.grbDetail.Controls.Add(Me.txtCCCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCCEnd)
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.btnAssetStartFind)
      Me.grbDetail.Controls.Add(Me.btnAssetEndFind)
      Me.grbDetail.Controls.Add(Me.txtAssetCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAssetEnd)
      Me.grbDetail.Controls.Add(Me.txtAssetCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAssetStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeEnd)
      Me.grbDetail.Controls.Add(Me.btnAssetTypeEndFind)
      Me.grbDetail.Controls.Add(Me.btnAssetTypeStartFind)
      Me.grbDetail.Controls.Add(Me.lblAssetTypeEnd)
      Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAssetTypeStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(408, 120)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnCCEndFind
      '
      Me.btnCCEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEndFind.Image = CType(resources.GetObject("btnCCEndFind.Image"), System.Drawing.Image)
      Me.btnCCEndFind.Location = New System.Drawing.Point(368, 88)
      Me.btnCCEndFind.Name = "btnCCEndFind"
      Me.btnCCEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCEndFind.TabIndex = 31
      Me.btnCCEndFind.TabStop = False
      Me.btnCCEndFind.ThemedImage = CType(resources.GetObject("btnCCEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeEnd
      '
      Me.Validator.SetDataType(Me.txtCCCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.txtCCCodeEnd.Location = New System.Drawing.Point(272, 88)
      Me.Validator.SetMaxValue(Me.txtCCCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Name = "txtCCCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtCCCodeEnd, "")
      Me.Validator.SetRequired(Me.txtCCCodeEnd, False)
      Me.txtCCCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeEnd.TabIndex = 7
      Me.txtCCCodeEnd.Text = ""
      '
      'lblCCEnd
      '
      Me.lblCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCCEnd.Location = New System.Drawing.Point(240, 88)
      Me.lblCCEnd.Name = "lblCCEnd"
      Me.lblCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCCEnd.TabIndex = 29
      Me.lblCCEnd.Text = "ถึง"
      Me.lblCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Image = CType(resources.GetObject("btnCCStartFind.Image"), System.Drawing.Image)
      Me.btnCCStartFind.Location = New System.Drawing.Point(208, 88)
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 88)
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 6
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(8, 88)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(96, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "ตั้งแต่ CostCenter"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAssetStartFind
      '
      Me.btnAssetStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetStartFind.Image = CType(resources.GetObject("btnAssetStartFind.Image"), System.Drawing.Image)
      Me.btnAssetStartFind.Location = New System.Drawing.Point(208, 64)
      Me.btnAssetStartFind.Name = "btnAssetStartFind"
      Me.btnAssetStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetStartFind.TabIndex = 24
      Me.btnAssetStartFind.TabStop = False
      Me.btnAssetStartFind.ThemedImage = CType(resources.GetObject("btnAssetStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetEndFind
      '
      Me.btnAssetEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetEndFind.Image = CType(resources.GetObject("btnAssetEndFind.Image"), System.Drawing.Image)
      Me.btnAssetEndFind.Location = New System.Drawing.Point(368, 64)
      Me.btnAssetEndFind.Name = "btnAssetEndFind"
      Me.btnAssetEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetEndFind.TabIndex = 23
      Me.btnAssetEndFind.TabStop = False
      Me.btnAssetEndFind.ThemedImage = CType(resources.GetObject("btnAssetEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAssetCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAssetCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCodeEnd, "")
      Me.txtAssetCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
      Me.txtAssetCodeEnd.Location = New System.Drawing.Point(272, 64)
      Me.Validator.SetMaxValue(Me.txtAssetCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtAssetCodeEnd, "")
      Me.txtAssetCodeEnd.Name = "txtAssetCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetCodeEnd, False)
      Me.txtAssetCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeEnd.TabIndex = 5
      Me.txtAssetCodeEnd.Text = ""
      '
      'lblAssetEnd
      '
      Me.lblAssetEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetEnd.Location = New System.Drawing.Point(240, 64)
      Me.lblAssetEnd.Name = "lblAssetEnd"
      Me.lblAssetEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAssetEnd.TabIndex = 9
      Me.lblAssetEnd.Text = "ถึง"
      Me.lblAssetEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtAssetCodeStart
      '
      Me.Validator.SetDataType(Me.txtAssetCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCodeStart, "")
      Me.txtAssetCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
      Me.txtAssetCodeStart.Location = New System.Drawing.Point(112, 64)
      Me.Validator.SetMaxValue(Me.txtAssetCodeStart, "")
      Me.Validator.SetMinValue(Me.txtAssetCodeStart, "")
      Me.txtAssetCodeStart.Name = "txtAssetCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetCodeStart, False)
      Me.txtAssetCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeStart.TabIndex = 4
      Me.txtAssetCodeStart.Text = ""
      '
      'lblAssetStart
      '
      Me.lblAssetStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetStart.Location = New System.Drawing.Point(16, 64)
      Me.lblAssetStart.Name = "lblAssetStart"
      Me.lblAssetStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAssetStart.TabIndex = 6
      Me.lblAssetStart.Text = "รหัสสินทรัพย์:"
      Me.lblAssetStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(272, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 1
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 0
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(272, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
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
      Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtAssetTypeCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAssetTypeCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetTypeCodeEnd, "")
      Me.txtAssetTypeCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
      Me.txtAssetTypeCodeEnd.Location = New System.Drawing.Point(272, 40)
      Me.Validator.SetMaxValue(Me.txtAssetTypeCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeEnd, "")
      Me.txtAssetTypeCodeEnd.Name = "txtAssetTypeCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeEnd, False)
      Me.txtAssetTypeCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeEnd.TabIndex = 3
      Me.txtAssetTypeCodeEnd.Text = ""
      '
      'btnAssetTypeEndFind
      '
      Me.btnAssetTypeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeEndFind.Image = CType(resources.GetObject("btnAssetTypeEndFind.Image"), System.Drawing.Image)
      Me.btnAssetTypeEndFind.Location = New System.Drawing.Point(368, 40)
      Me.btnAssetTypeEndFind.Name = "btnAssetTypeEndFind"
      Me.btnAssetTypeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetTypeEndFind.TabIndex = 23
      Me.btnAssetTypeEndFind.TabStop = False
      Me.btnAssetTypeEndFind.ThemedImage = CType(resources.GetObject("btnAssetTypeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetTypeStartFind
      '
      Me.btnAssetTypeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeStartFind.Image = CType(resources.GetObject("btnAssetTypeStartFind.Image"), System.Drawing.Image)
      Me.btnAssetTypeStartFind.Location = New System.Drawing.Point(208, 40)
      Me.btnAssetTypeStartFind.Name = "btnAssetTypeStartFind"
      Me.btnAssetTypeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetTypeStartFind.TabIndex = 24
      Me.btnAssetTypeStartFind.TabStop = False
      Me.btnAssetTypeStartFind.ThemedImage = CType(resources.GetObject("btnAssetTypeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAssetTypeEnd
      '
      Me.lblAssetTypeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeEnd.Location = New System.Drawing.Point(240, 40)
      Me.lblAssetTypeEnd.Name = "lblAssetTypeEnd"
      Me.lblAssetTypeEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAssetTypeEnd.TabIndex = 9
      Me.lblAssetTypeEnd.Text = "ถึง"
      Me.lblAssetTypeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtAssetTypeCodeStart
      '
      Me.Validator.SetDataType(Me.txtAssetTypeCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetTypeCodeStart, "")
      Me.txtAssetTypeCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
      Me.txtAssetTypeCodeStart.Location = New System.Drawing.Point(112, 40)
      Me.Validator.SetMaxValue(Me.txtAssetTypeCodeStart, "")
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeStart, "")
      Me.txtAssetTypeCodeStart.Name = "txtAssetTypeCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeStart, False)
      Me.txtAssetTypeCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeStart.TabIndex = 2
      Me.txtAssetTypeCodeStart.Text = ""
      '
      'lblAssetTypeStart
      '
      Me.lblAssetTypeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeStart.Location = New System.Drawing.Point(16, 40)
      Me.lblAssetTypeStart.Name = "lblAssetTypeStart"
      Me.lblAssetTypeStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAssetTypeStart.TabIndex = 6
      Me.lblAssetTypeStart.Text = "ประเภทสินทรัพย์:"
      Me.lblAssetTypeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(352, 144)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(272, 144)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RptAssetByTypeFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "Rpt269FilterSubPanel"
      Me.Size = New System.Drawing.Size(456, 192)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblAssetStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.lblAssetStart}")
      Me.Validator.SetDisplayName(txtAssetCodeStart, lblAssetStart.Text)

      Me.lblAssetTypeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.lblAssetTypeStart}")
      Me.Validator.SetDisplayName(txtAssetTypeCodeStart, lblAssetTypeStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblAssetEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAssetCodeEnd, lblAssetEnd.Text)

      Me.lblAssetTypeEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAssetTypeCodeEnd, lblAssetTypeEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtCCCodeEnd, lblCCEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt269FilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_assetstart As Asset
    Private m_assetend As Asset

    Private m_assettypestart As AssetType
    Private m_assettypeend As AssetType

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

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property AssetStart() As Asset
      Get
        Return m_assetstart
      End Get
      Set(ByVal Value As Asset)
        m_assetstart = Value
      End Set
    End Property
    Public Property AssetEnd() As Asset
      Get
        Return m_assetend
      End Get
      Set(ByVal Value As Asset)
        m_assetend = Value
      End Set
    End Property
    Public Property AssetTypeStart() As AssetType
      Get
        Return m_assettypestart
      End Get
      Set(ByVal Value As AssetType)
        m_assettypestart = Value
      End Set
    End Property
    Public Property AssetTypeEnd() As AssetType
      Get
        Return m_assettypeend
      End Get
      Set(ByVal Value As AssetType)
        m_assettypeend = Value
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

      Me.AssetStart = New Asset
      Me.AssetEnd = New Asset
      Me.AssetTypeStart = New AssetType
      Me.AssetTypeEnd = New AssetType

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(8) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("AssetCodeStart", IIf(txtAssetCodeStart.TextLength > 0, txtAssetCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("AssetCodeEnd", IIf(txtAssetCodeEnd.TextLength > 0, txtAssetCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("AssetTypeCodeStart", IIf(txtAssetTypeCodeStart.TextLength > 0, txtAssetTypeCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("AssetTypeCodeEnd", IIf(txtAssetTypeCodeEnd.TextLength > 0, txtAssetTypeCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("CostCenterCodeStart", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      arr(7) = New Filter("CostCenterCodeEnd", IIf(txtCCCodeEnd.TextLength > 0, txtCCCodeEnd.Text, DBNull.Value))
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

      'Asset Start
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetStart"
      dpi.Value = Me.txtAssetCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Asset End
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetEnd"
      dpi.Value = Me.txtAssetCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetType Start
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetTypeStart"
      dpi.Value = Me.txtAssetTypeCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetType End
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetTypeEnd"
      dpi.Value = Me.txtAssetTypeCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterEnd"
      dpi.Value = Me.txtCCCodeEnd.Text
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
      AddHandler btnAssetStartFind.Click, AddressOf Me.btnAssetFind_Click
      AddHandler btnAssetEndFind.Click, AddressOf Me.btnAssetFind_Click

      AddHandler btnAssetTypeStartFind.Click, AddressOf Me.btnAssetTypeFind_Click
      AddHandler btnAssetTypeEndFind.Click, AddressOf Me.btnAssetTypeFind_Click

      AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
      AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtcccodeend"
          CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
              Case "txtcccodestart", "txtcccodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtassetcodestart"
              Me.SetAssetStartDialog(entity)

            Case "txtassetcodeend"
              Me.SetAssetEndDialog(entity)

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
    Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnassetstartfind"
          myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetStartDialog)

        Case "btnassetendfind"
          myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetEndDialog)
      End Select
    End Sub
    Private Sub btnAssetTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnassettypestartfind"
          myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeStartDialog)

        Case "btnassettypeendfind"
          myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeEndDialog)
      End Select
    End Sub
    ' CostCenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

        Case "btnccendfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
      End Select
    End Sub
    Private Sub SetAssetStartDialog(ByVal e As ISimpleEntity)
      Me.txtAssetCodeStart.Text = e.Code
      Asset.GetAsset(txtAssetCodeStart, txtTemp, Me.AssetStart)
    End Sub
    Private Sub SetAssetEndDialog(ByVal e As ISimpleEntity)
      Me.txtAssetCodeEnd.Text = e.Code
      Asset.GetAsset(txtAssetCodeEnd, txtTemp, Me.AssetEnd)
    End Sub
    Private Sub SetAssetTypeStartDialog(ByVal e As ISimpleEntity)
      Me.txtAssetTypeCodeStart.Text = e.Code
      AssetType.GetAssetType(txtAssetTypeCodeStart, txtTemp, Me.AssetTypeStart)
    End Sub
    Private Sub SetAssetTypeEndDialog(ByVal e As ISimpleEntity)
      Me.txtAssetTypeCodeEnd.Text = e.Code
      AssetType.GetAssetType(txtAssetTypeCodeEnd, txtTemp, Me.AssetTypeEnd)
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeEnd.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class
End Namespace

