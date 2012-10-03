Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class Rpt265FilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ChkNonRent As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOpb As System.Windows.Forms.CheckBox
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnCCEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCCEnd As System.Windows.Forms.Label
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents btnAssetStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAssetCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetStart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetTypeCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnAssetTypeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetTypeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAssetTypeEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetTypeCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents btnCCRequestEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCRequestEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCCEnd2 As System.Windows.Forms.Label
    Friend WithEvents btnCCRequestStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCRequestFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblCCRequestFrom As System.Windows.Forms.Label
    Friend WithEvents lblAssetTypeStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt265FilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCCRequestEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCRequestEnd = New System.Windows.Forms.TextBox()
      Me.lblCCEnd2 = New System.Windows.Forms.Label()
      Me.txtCCCodeEnd = New System.Windows.Forms.TextBox()
      Me.btnCCRequestStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCCEnd = New System.Windows.Forms.Label()
      Me.txtCCRequestFrom = New System.Windows.Forms.TextBox()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCCRequestFrom = New System.Windows.Forms.Label()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.btnAssetStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAssetEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAssetCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAssetEnd = New System.Windows.Forms.Label()
      Me.txtAssetCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAssetStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.txtAssetTypeCodeEnd = New System.Windows.Forms.TextBox()
      Me.btnAssetTypeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAssetTypeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAssetTypeEnd = New System.Windows.Forms.Label()
      Me.txtAssetTypeCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAssetTypeStart = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.ChkNonRent = New System.Windows.Forms.CheckBox()
      Me.ChkOpb = New System.Windows.Forms.CheckBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
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
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.ChkNonRent)
      Me.grbMaster.Controls.Add(Me.ChkOpb)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(487, 229)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnCCRequestEndFind)
      Me.grbDetail.Controls.Add(Me.btnCCEndFind)
      Me.grbDetail.Controls.Add(Me.txtCCRequestEnd)
      Me.grbDetail.Controls.Add(Me.lblCCEnd2)
      Me.grbDetail.Controls.Add(Me.txtCCCodeEnd)
      Me.grbDetail.Controls.Add(Me.btnCCRequestStartFind)
      Me.grbDetail.Controls.Add(Me.lblCCEnd)
      Me.grbDetail.Controls.Add(Me.txtCCRequestFrom)
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.lblCCRequestFrom)
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
      Me.grbDetail.Size = New System.Drawing.Size(458, 144)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnCCRequestEndFind
      '
      Me.btnCCRequestEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCRequestEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCRequestEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCRequestEndFind.Location = New System.Drawing.Point(403, 113)
      Me.btnCCRequestEndFind.Name = "btnCCRequestEndFind"
      Me.btnCCRequestEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCRequestEndFind.TabIndex = 31
      Me.btnCCRequestEndFind.TabStop = False
      Me.btnCCRequestEndFind.ThemedImage = CType(resources.GetObject("btnCCRequestEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCEndFind
      '
      Me.btnCCEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEndFind.Location = New System.Drawing.Point(403, 88)
      Me.btnCCEndFind.Name = "btnCCEndFind"
      Me.btnCCEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCEndFind.TabIndex = 31
      Me.btnCCEndFind.TabStop = False
      Me.btnCCEndFind.ThemedImage = CType(resources.GetObject("btnCCEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCRequestEnd
      '
      Me.Validator.SetDataType(Me.txtCCRequestEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCRequestEnd, "")
      Me.txtCCRequestEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCRequestEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCRequestEnd, System.Drawing.Color.Empty)
      Me.txtCCRequestEnd.Location = New System.Drawing.Point(307, 113)
      Me.Validator.SetMinValue(Me.txtCCRequestEnd, "")
      Me.txtCCRequestEnd.Name = "txtCCRequestEnd"
      Me.Validator.SetRegularExpression(Me.txtCCRequestEnd, "")
      Me.Validator.SetRequired(Me.txtCCRequestEnd, False)
      Me.txtCCRequestEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtCCRequestEnd.TabIndex = 10
      '
      'lblCCEnd2
      '
      Me.lblCCEnd2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCEnd2.ForeColor = System.Drawing.Color.Black
      Me.lblCCEnd2.Location = New System.Drawing.Point(275, 113)
      Me.lblCCEnd2.Name = "lblCCEnd2"
      Me.lblCCEnd2.Size = New System.Drawing.Size(24, 18)
      Me.lblCCEnd2.TabIndex = 29
      Me.lblCCEnd2.Text = "ถึง"
      Me.lblCCEnd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtCCCodeEnd
      '
      Me.Validator.SetDataType(Me.txtCCCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
      Me.txtCCCodeEnd.Location = New System.Drawing.Point(307, 88)
      Me.Validator.SetMinValue(Me.txtCCCodeEnd, "")
      Me.txtCCCodeEnd.Name = "txtCCCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtCCCodeEnd, "")
      Me.Validator.SetRequired(Me.txtCCCodeEnd, False)
      Me.txtCCCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeEnd.TabIndex = 8
      '
      'btnCCRequestStartFind
      '
      Me.btnCCRequestStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCRequestStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCRequestStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCRequestStartFind.Location = New System.Drawing.Point(243, 113)
      Me.btnCCRequestStartFind.Name = "btnCCRequestStartFind"
      Me.btnCCRequestStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCRequestStartFind.TabIndex = 28
      Me.btnCCRequestStartFind.TabStop = False
      Me.btnCCRequestStartFind.ThemedImage = CType(resources.GetObject("btnCCRequestStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCCEnd
      '
      Me.lblCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCCEnd.Location = New System.Drawing.Point(275, 88)
      Me.lblCCEnd.Name = "lblCCEnd"
      Me.lblCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCCEnd.TabIndex = 29
      Me.lblCCEnd.Text = "ถึง"
      Me.lblCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtCCRequestFrom
      '
      Me.Validator.SetDataType(Me.txtCCRequestFrom, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCRequestFrom, "")
      Me.txtCCRequestFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCRequestFrom, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCRequestFrom, System.Drawing.Color.Empty)
      Me.txtCCRequestFrom.Location = New System.Drawing.Point(147, 113)
      Me.Validator.SetMinValue(Me.txtCCRequestFrom, "")
      Me.txtCCRequestFrom.Name = "txtCCRequestFrom"
      Me.Validator.SetRegularExpression(Me.txtCCRequestFrom, "")
      Me.Validator.SetRequired(Me.txtCCRequestFrom, False)
      Me.txtCCRequestFrom.Size = New System.Drawing.Size(96, 21)
      Me.txtCCRequestFrom.TabIndex = 9
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(243, 88)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 28
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCCRequestFrom
      '
      Me.lblCCRequestFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCRequestFrom.ForeColor = System.Drawing.Color.Black
      Me.lblCCRequestFrom.Location = New System.Drawing.Point(11, 113)
      Me.lblCCRequestFrom.Name = "lblCCRequestFrom"
      Me.lblCCRequestFrom.Size = New System.Drawing.Size(128, 18)
      Me.lblCCRequestFrom.TabIndex = 26
      Me.lblCCRequestFrom.Text = "CostCenter ที่ขอเลิก"
      Me.lblCCRequestFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(147, 88)
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
      Me.lblCCStart.Location = New System.Drawing.Point(11, 88)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(128, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "CostCenter ที่ให้เบิก"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAssetStartFind
      '
      Me.btnAssetStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetStartFind.Location = New System.Drawing.Point(243, 64)
      Me.btnAssetStartFind.Name = "btnAssetStartFind"
      Me.btnAssetStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetStartFind.TabIndex = 24
      Me.btnAssetStartFind.TabStop = False
      Me.btnAssetStartFind.ThemedImage = CType(resources.GetObject("btnAssetStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetEndFind
      '
      Me.btnAssetEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetEndFind.Location = New System.Drawing.Point(403, 64)
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
      Me.txtAssetCodeEnd.Location = New System.Drawing.Point(307, 64)
      Me.Validator.SetMinValue(Me.txtAssetCodeEnd, "")
      Me.txtAssetCodeEnd.Name = "txtAssetCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetCodeEnd, False)
      Me.txtAssetCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeEnd.TabIndex = 6
      '
      'lblAssetEnd
      '
      Me.lblAssetEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetEnd.Location = New System.Drawing.Point(275, 64)
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
      Me.txtAssetCodeStart.Location = New System.Drawing.Point(147, 64)
      Me.Validator.SetMinValue(Me.txtAssetCodeStart, "")
      Me.txtAssetCodeStart.Name = "txtAssetCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetCodeStart, False)
      Me.txtAssetCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeStart.TabIndex = 5
      '
      'lblAssetStart
      '
      Me.lblAssetStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetStart.Location = New System.Drawing.Point(14, 64)
      Me.lblAssetStart.Name = "lblAssetStart"
      Me.lblAssetStart.Size = New System.Drawing.Size(125, 18)
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(307, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(88, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(147, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(84, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(147, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(307, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(14, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(125, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(275, 16)
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
      Me.txtAssetTypeCodeEnd.Location = New System.Drawing.Point(307, 40)
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeEnd, "")
      Me.txtAssetTypeCodeEnd.Name = "txtAssetTypeCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeEnd, False)
      Me.txtAssetTypeCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeEnd.TabIndex = 4
      '
      'btnAssetTypeEndFind
      '
      Me.btnAssetTypeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetTypeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeEndFind.Location = New System.Drawing.Point(403, 40)
      Me.btnAssetTypeEndFind.Name = "btnAssetTypeEndFind"
      Me.btnAssetTypeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetTypeEndFind.TabIndex = 23
      Me.btnAssetTypeEndFind.TabStop = False
      Me.btnAssetTypeEndFind.ThemedImage = CType(resources.GetObject("btnAssetTypeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetTypeStartFind
      '
      Me.btnAssetTypeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetTypeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeStartFind.Location = New System.Drawing.Point(243, 40)
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
      Me.lblAssetTypeEnd.Location = New System.Drawing.Point(275, 40)
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
      Me.txtAssetTypeCodeStart.Location = New System.Drawing.Point(147, 40)
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeStart, "")
      Me.txtAssetTypeCodeStart.Name = "txtAssetTypeCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeStart, False)
      Me.txtAssetTypeCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeStart.TabIndex = 3
      '
      'lblAssetTypeStart
      '
      Me.lblAssetTypeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeStart.Location = New System.Drawing.Point(14, 40)
      Me.lblAssetTypeStart.Name = "lblAssetTypeStart"
      Me.lblAssetTypeStart.Size = New System.Drawing.Size(125, 18)
      Me.lblAssetTypeStart.TabIndex = 6
      Me.lblAssetTypeStart.Text = "ประเภทสินทรัพย์:"
      Me.lblAssetTypeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(399, 197)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(311, 197)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 3
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'ChkNonRent
      '
      Me.ChkNonRent.Location = New System.Drawing.Point(128, 166)
      Me.ChkNonRent.Name = "ChkNonRent"
      Me.ChkNonRent.Size = New System.Drawing.Size(248, 24)
      Me.ChkNonRent.TabIndex = 2
      Me.ChkNonRent.Text = "แสดงสินทรัพย์ที่ไม่มีการเช่าในช่วงเวลาค้นหา"
      '
      'ChkOpb
      '
      Me.ChkOpb.Location = New System.Drawing.Point(16, 166)
      Me.ChkOpb.Name = "ChkOpb"
      Me.ChkOpb.Size = New System.Drawing.Size(104, 24)
      Me.ChkOpb.TabIndex = 1
      Me.ChkOpb.Text = "แสดงยอดยกมา"
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
      'Rpt265FilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "Rpt265FilterSubPanel"
      Me.Size = New System.Drawing.Size(503, 253)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblAssetStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblAssetStart}")
      Me.Validator.SetDisplayName(txtAssetCodeStart, lblAssetStart.Text)

      Me.lblAssetTypeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblAssetTypeStart}")
      Me.Validator.SetDisplayName(txtAssetTypeCodeStart, lblAssetTypeStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblCCRequestFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.lblCCRequestFrom}")
      'Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblAssetEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAssetCodeEnd, lblAssetEnd.Text)

      Me.lblAssetTypeEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtAssetTypeCodeEnd, lblAssetTypeEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtCCCodeEnd, lblCCEnd.Text)

      Me.lblCCEnd2.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.grbDetail}")
            Me.ChkOpb.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.ChkOpb}")
            Me.ChkNonRent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt265FilterSubPanel.ChkNonRent}")


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


      Me.ChkOpb.Checked = False
      Me.ChkNonRent.Checked = False

    End Sub
    Public Overrides Function GetFilterString() As String


    End Function

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(12) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("AssetCodeStart", IIf(txtAssetCodeStart.TextLength > 0, txtAssetCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("AssetCodeEnd", IIf(txtAssetCodeEnd.TextLength > 0, txtAssetCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("AssetTypeCodeStart", IIf(txtAssetTypeCodeStart.TextLength > 0, txtAssetTypeCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("AssetTypeCodeEnd", IIf(txtAssetTypeCodeEnd.TextLength > 0, txtAssetTypeCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("CostCenterCodeStart", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      arr(7) = New Filter("CostCenterCodeEnd", IIf(txtCCCodeEnd.TextLength > 0, txtCCCodeEnd.Text, DBNull.Value))
      arr(8) = New Filter("CostCenterRequestCodeStart", IIf(txtCCRequestFrom.TextLength > 0, txtCCRequestFrom.Text, DBNull.Value))
      arr(9) = New Filter("CostCenterRequestCodeEnd", IIf(txtCCRequestEnd.TextLength > 0, txtCCRequestEnd.Text, DBNull.Value))
      arr(10) = New Filter("ChkOpb", ChkOpb.Checked)
      arr(11) = New Filter("ChkNoneRent", ChkNonRent.Checked)
      arr(12) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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


      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd


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

      AddHandler btnCCRequestStartFind.Click, AddressOf Me.btnCCFind_Click
      AddHandler btnCCRequestEndFind.Click, AddressOf Me.btnCCFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCRequestFrom.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCCRequestEnd.Validated, AddressOf Me.ChangeProperty

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

        Case "txtccrequestfrom"
          CostCenter.GetCostCenter(txtCCRequestFrom, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtccrequestend"
          CostCenter.GetCostCenter(txtCCRequestEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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

        Case "btnccrequeststartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeRequestStartDialog)

        Case "btnccrequestendfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeRequestEndDialog)

      End Select
    End Sub
    Private txtTemp As New TextBox
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
    Private Sub SetCCCodeRequestStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCRequestFrom.Text = e.Code
      CostCenter.GetCostCenter(txtCCRequestFrom, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCCCodeRequestEndDialog(ByVal e As ISimpleEntity)
      Me.txtCCRequestEnd.Text = e.Code
      CostCenter.GetCostCenter(txtCCRequestEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub

#End Region

  End Class
End Namespace

