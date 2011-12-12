Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EqWithdrawFilterSubPanel
    Inherits AbstractFilterSubPanel
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbStock As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnStorePersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStorePersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblStorePerson As System.Windows.Forms.Label
    Friend WithEvents txtStorePersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtStorePersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreCCName As System.Windows.Forms.TextBox
    Friend WithEvents btnStoreCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStoreCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtStoreCCCode As System.Windows.Forms.TextBox
    Friend WithEvents grbWithdraw As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnWithdrawPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtWithdrawPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawPersonName As System.Windows.Forms.TextBox
    Friend WithEvents btnWithdrawPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblWithdrawPerson As System.Windows.Forms.Label
    Friend WithEvents btnWithdrawCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtWithdrawCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawCCName As System.Windows.Forms.TextBox
    Friend WithEvents btnWithdrawCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblWithdrawCC As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents chkIsExternal As System.Windows.Forms.CheckBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents lblStoreCC As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EqWithdrawFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbStock = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnStorePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnStorePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStorePerson = New System.Windows.Forms.Label()
      Me.txtStorePersonCode = New System.Windows.Forms.TextBox()
      Me.txtStorePersonName = New System.Windows.Forms.TextBox()
      Me.txtStoreCCName = New System.Windows.Forms.TextBox()
      Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStoreCC = New System.Windows.Forms.Label()
      Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtStoreCCCode = New System.Windows.Forms.TextBox()
      Me.grbWithdraw = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnWithdrawPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWithdrawPersonCode = New System.Windows.Forms.TextBox()
      Me.txtWithdrawPersonName = New System.Windows.Forms.TextBox()
      Me.btnWithdrawPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWithdrawPerson = New System.Windows.Forms.Label()
      Me.btnWithdrawCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWithdrawCCCode = New System.Windows.Forms.TextBox()
      Me.txtWithdrawCCName = New System.Windows.Forms.TextBox()
      Me.btnWithdrawCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWithdrawCC = New System.Windows.Forms.Label()
      Me.chkIsExternal = New System.Windows.Forms.CheckBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.grbDetail.SuspendLayout()
      Me.grbGeneral.SuspendLayout()
      Me.grbStock.SuspendLayout()
      Me.grbWithdraw.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbGeneral)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbStock)
      Me.grbDetail.Controls.Add(Me.grbWithdraw)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 200)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.txtDocDateEnd)
      Me.grbGeneral.Controls.Add(Me.txtDocDateStart)
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.lblDocDateStart)
      Me.grbGeneral.Controls.Add(Me.lblDocDateEnd)
      Me.grbGeneral.Controls.Add(Me.dtpDocDateStart)
      Me.grbGeneral.Controls.Add(Me.dtpDocDateEnd)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 10)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(760, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      Me.grbGeneral.Text = "วันที่เอกสาร"
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 16)
      Me.txtCode.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(344, 21)
      Me.txtCode.TabIndex = 1
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 41)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDateStart.TabIndex = 2
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(259, 42)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(64, 18)
      Me.lblDocDateEnd.TabIndex = 4
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 41)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 3
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 41)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 0
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(688, 168)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(608, 168)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 3
      Me.btnReset.Text = "Reset"
      '
      'grbStock
      '
      Me.grbStock.Controls.Add(Me.btnStorePersonFind)
      Me.grbStock.Controls.Add(Me.btnStorePersonEdit)
      Me.grbStock.Controls.Add(Me.lblStorePerson)
      Me.grbStock.Controls.Add(Me.txtStorePersonCode)
      Me.grbStock.Controls.Add(Me.txtStorePersonName)
      Me.grbStock.Controls.Add(Me.txtStoreCCName)
      Me.grbStock.Controls.Add(Me.btnStoreCCEdit)
      Me.grbStock.Controls.Add(Me.lblStoreCC)
      Me.grbStock.Controls.Add(Me.btnStoreCCFind)
      Me.grbStock.Controls.Add(Me.txtStoreCCCode)
      Me.grbStock.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbStock.Location = New System.Drawing.Point(392, 88)
      Me.grbStock.Name = "grbStock"
      Me.grbStock.Size = New System.Drawing.Size(376, 72)
      Me.grbStock.TabIndex = 2
      Me.grbStock.TabStop = False
      Me.grbStock.Text = "ผู้ให้เบิก"
      '
      'btnStorePersonFind
      '
      Me.btnStorePersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStorePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorePersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStorePersonFind.Location = New System.Drawing.Point(320, 40)
      Me.btnStorePersonFind.Name = "btnStorePersonFind"
      Me.btnStorePersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStorePersonFind.TabIndex = 8
      Me.btnStorePersonFind.TabStop = False
      Me.btnStorePersonFind.ThemedImage = CType(resources.GetObject("btnStorePersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnStorePersonEdit
      '
      Me.btnStorePersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStorePersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorePersonEdit.Location = New System.Drawing.Point(344, 40)
      Me.btnStorePersonEdit.Name = "btnStorePersonEdit"
      Me.btnStorePersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnStorePersonEdit.TabIndex = 9
      Me.btnStorePersonEdit.TabStop = False
      Me.btnStorePersonEdit.ThemedImage = CType(resources.GetObject("btnStorePersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStorePerson
      '
      Me.lblStorePerson.BackColor = System.Drawing.Color.Transparent
      Me.lblStorePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStorePerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStorePerson.Location = New System.Drawing.Point(8, 40)
      Me.lblStorePerson.Name = "lblStorePerson"
      Me.lblStorePerson.Size = New System.Drawing.Size(128, 18)
      Me.lblStorePerson.TabIndex = 5
      Me.lblStorePerson.Text = "ผู้ให้เบิก"
      Me.lblStorePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtStorePersonCode
      '
      Me.Validator.SetDataType(Me.txtStorePersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorePersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorePersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStorePersonCode, System.Drawing.Color.Empty)
      Me.txtStorePersonCode.Location = New System.Drawing.Point(144, 40)
      Me.txtStorePersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStorePersonCode, "")
      Me.txtStorePersonCode.Name = "txtStorePersonCode"
      Me.Validator.SetRegularExpression(Me.txtStorePersonCode, "")
      Me.Validator.SetRequired(Me.txtStorePersonCode, False)
      Me.txtStorePersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtStorePersonCode.TabIndex = 6
      '
      'txtStorePersonName
      '
      Me.Validator.SetDataType(Me.txtStorePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.txtStorePersonName.Location = New System.Drawing.Point(224, 40)
      Me.Validator.SetMinValue(Me.txtStorePersonName, "")
      Me.txtStorePersonName.Name = "txtStorePersonName"
      Me.txtStorePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStorePersonName, "")
      Me.Validator.SetRequired(Me.txtStorePersonName, False)
      Me.txtStorePersonName.Size = New System.Drawing.Size(96, 20)
      Me.txtStorePersonName.TabIndex = 7
      Me.txtStorePersonName.TabStop = False
      '
      'txtStoreCCName
      '
      Me.Validator.SetDataType(Me.txtStoreCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.txtStoreCCName.Location = New System.Drawing.Point(224, 16)
      Me.Validator.SetMinValue(Me.txtStoreCCName, "")
      Me.txtStoreCCName.Name = "txtStoreCCName"
      Me.txtStoreCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
      Me.Validator.SetRequired(Me.txtStoreCCName, False)
      Me.txtStoreCCName.Size = New System.Drawing.Size(96, 20)
      Me.txtStoreCCName.TabIndex = 2
      Me.txtStoreCCName.TabStop = False
      '
      'btnStoreCCEdit
      '
      Me.btnStoreCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCEdit.Location = New System.Drawing.Point(344, 16)
      Me.btnStoreCCEdit.Name = "btnStoreCCEdit"
      Me.btnStoreCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCEdit.TabIndex = 4
      Me.btnStoreCCEdit.TabStop = False
      Me.btnStoreCCEdit.ThemedImage = CType(resources.GetObject("btnStoreCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStoreCC
      '
      Me.lblStoreCC.BackColor = System.Drawing.Color.Transparent
      Me.lblStoreCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStoreCC.Location = New System.Drawing.Point(8, 16)
      Me.lblStoreCC.Name = "lblStoreCC"
      Me.lblStoreCC.Size = New System.Drawing.Size(128, 18)
      Me.lblStoreCC.TabIndex = 0
      Me.lblStoreCC.Text = "Cost Center ให้เบิก"
      Me.lblStoreCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnStoreCCFind
      '
      Me.btnStoreCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStoreCCFind.Location = New System.Drawing.Point(320, 16)
      Me.btnStoreCCFind.Name = "btnStoreCCFind"
      Me.btnStoreCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCFind.TabIndex = 3
      Me.btnStoreCCFind.TabStop = False
      Me.btnStoreCCFind.ThemedImage = CType(resources.GetObject("btnStoreCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtStoreCCCode
      '
      Me.Validator.SetDataType(Me.txtStoreCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.txtStoreCCCode.Location = New System.Drawing.Point(144, 16)
      Me.txtStoreCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
      Me.txtStoreCCCode.Name = "txtStoreCCCode"
      Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
      Me.Validator.SetRequired(Me.txtStoreCCCode, False)
      Me.txtStoreCCCode.Size = New System.Drawing.Size(80, 20)
      Me.txtStoreCCCode.TabIndex = 1
      '
      'grbWithdraw
      '
      Me.grbWithdraw.Controls.Add(Me.btnWithdrawPersonEdit)
      Me.grbWithdraw.Controls.Add(Me.txtWithdrawPersonCode)
      Me.grbWithdraw.Controls.Add(Me.txtWithdrawPersonName)
      Me.grbWithdraw.Controls.Add(Me.btnWithdrawPersonFind)
      Me.grbWithdraw.Controls.Add(Me.lblWithdrawPerson)
      Me.grbWithdraw.Controls.Add(Me.btnWithdrawCCEdit)
      Me.grbWithdraw.Controls.Add(Me.txtWithdrawCCCode)
      Me.grbWithdraw.Controls.Add(Me.txtWithdrawCCName)
      Me.grbWithdraw.Controls.Add(Me.btnWithdrawCCFind)
      Me.grbWithdraw.Controls.Add(Me.lblWithdrawCC)
      Me.grbWithdraw.Controls.Add(Me.chkIsExternal)
      Me.grbWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbWithdraw.Location = New System.Drawing.Point(8, 88)
      Me.grbWithdraw.Name = "grbWithdraw"
      Me.grbWithdraw.Size = New System.Drawing.Size(376, 72)
      Me.grbWithdraw.TabIndex = 1
      Me.grbWithdraw.TabStop = False
      Me.grbWithdraw.Text = "ผู้ขอเบิก"
      '
      'btnWithdrawPersonEdit
      '
      Me.btnWithdrawPersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawPersonEdit.Location = New System.Drawing.Point(344, 40)
      Me.btnWithdrawPersonEdit.Name = "btnWithdrawPersonEdit"
      Me.btnWithdrawPersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnWithdrawPersonEdit.TabIndex = 10
      Me.btnWithdrawPersonEdit.TabStop = False
      Me.btnWithdrawPersonEdit.ThemedImage = CType(resources.GetObject("btnWithdrawPersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWithdrawPersonCode
      '
      Me.Validator.SetDataType(Me.txtWithdrawPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
      Me.txtWithdrawPersonCode.Location = New System.Drawing.Point(144, 40)
      Me.txtWithdrawPersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWithdrawPersonCode, "")
      Me.txtWithdrawPersonCode.Name = "txtWithdrawPersonCode"
      Me.Validator.SetRegularExpression(Me.txtWithdrawPersonCode, "")
      Me.Validator.SetRequired(Me.txtWithdrawPersonCode, False)
      Me.txtWithdrawPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtWithdrawPersonCode.TabIndex = 7
      '
      'txtWithdrawPersonName
      '
      Me.Validator.SetDataType(Me.txtWithdrawPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
      Me.txtWithdrawPersonName.Location = New System.Drawing.Point(224, 40)
      Me.Validator.SetMinValue(Me.txtWithdrawPersonName, "")
      Me.txtWithdrawPersonName.Name = "txtWithdrawPersonName"
      Me.txtWithdrawPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWithdrawPersonName, "")
      Me.Validator.SetRequired(Me.txtWithdrawPersonName, False)
      Me.txtWithdrawPersonName.Size = New System.Drawing.Size(96, 20)
      Me.txtWithdrawPersonName.TabIndex = 8
      Me.txtWithdrawPersonName.TabStop = False
      '
      'btnWithdrawPersonFind
      '
      Me.btnWithdrawPersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawPersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWithdrawPersonFind.Location = New System.Drawing.Point(320, 40)
      Me.btnWithdrawPersonFind.Name = "btnWithdrawPersonFind"
      Me.btnWithdrawPersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnWithdrawPersonFind.TabIndex = 9
      Me.btnWithdrawPersonFind.TabStop = False
      Me.btnWithdrawPersonFind.ThemedImage = CType(resources.GetObject("btnWithdrawPersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWithdrawPerson
      '
      Me.lblWithdrawPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblWithdrawPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWithdrawPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblWithdrawPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblWithdrawPerson.Name = "lblWithdrawPerson"
      Me.lblWithdrawPerson.Size = New System.Drawing.Size(128, 18)
      Me.lblWithdrawPerson.TabIndex = 6
      Me.lblWithdrawPerson.Text = "ผู้ขอเบิก"
      Me.lblWithdrawPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnWithdrawCCEdit
      '
      Me.btnWithdrawCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawCCEdit.Location = New System.Drawing.Point(344, 16)
      Me.btnWithdrawCCEdit.Name = "btnWithdrawCCEdit"
      Me.btnWithdrawCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnWithdrawCCEdit.TabIndex = 5
      Me.btnWithdrawCCEdit.TabStop = False
      Me.btnWithdrawCCEdit.ThemedImage = CType(resources.GetObject("btnWithdrawCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWithdrawCCCode
      '
      Me.Validator.SetDataType(Me.txtWithdrawCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
      Me.txtWithdrawCCCode.Location = New System.Drawing.Point(144, 16)
      Me.txtWithdrawCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWithdrawCCCode, "")
      Me.txtWithdrawCCCode.Name = "txtWithdrawCCCode"
      Me.Validator.SetRegularExpression(Me.txtWithdrawCCCode, "")
      Me.Validator.SetRequired(Me.txtWithdrawCCCode, False)
      Me.txtWithdrawCCCode.Size = New System.Drawing.Size(80, 20)
      Me.txtWithdrawCCCode.TabIndex = 2
      '
      'txtWithdrawCCName
      '
      Me.Validator.SetDataType(Me.txtWithdrawCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
      Me.txtWithdrawCCName.Location = New System.Drawing.Point(224, 16)
      Me.Validator.SetMinValue(Me.txtWithdrawCCName, "")
      Me.txtWithdrawCCName.Name = "txtWithdrawCCName"
      Me.txtWithdrawCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWithdrawCCName, "")
      Me.Validator.SetRequired(Me.txtWithdrawCCName, False)
      Me.txtWithdrawCCName.Size = New System.Drawing.Size(96, 20)
      Me.txtWithdrawCCName.TabIndex = 3
      Me.txtWithdrawCCName.TabStop = False
      '
      'btnWithdrawCCFind
      '
      Me.btnWithdrawCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWithdrawCCFind.Location = New System.Drawing.Point(320, 16)
      Me.btnWithdrawCCFind.Name = "btnWithdrawCCFind"
      Me.btnWithdrawCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnWithdrawCCFind.TabIndex = 4
      Me.btnWithdrawCCFind.TabStop = False
      Me.btnWithdrawCCFind.ThemedImage = CType(resources.GetObject("btnWithdrawCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWithdrawCC
      '
      Me.lblWithdrawCC.BackColor = System.Drawing.Color.Transparent
      Me.lblWithdrawCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWithdrawCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblWithdrawCC.Location = New System.Drawing.Point(8, 16)
      Me.lblWithdrawCC.Name = "lblWithdrawCC"
      Me.lblWithdrawCC.Size = New System.Drawing.Size(128, 18)
      Me.lblWithdrawCC.TabIndex = 1
      Me.lblWithdrawCC.Text = "Cost Center ขอเบิก"
      Me.lblWithdrawCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIsExternal
      '
      Me.chkIsExternal.Location = New System.Drawing.Point(144, 72)
      Me.chkIsExternal.Name = "chkIsExternal"
      Me.chkIsExternal.Size = New System.Drawing.Size(216, 24)
      Me.chkIsExternal.TabIndex = 0
      Me.chkIsExternal.Text = "เบิกไปใช้โครงการนอก"
      Me.chkIsExternal.Visible = False
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
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(329, 41)
      Me.txtDocDateEnd.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(107, 20)
      Me.txtDocDateEnd.TabIndex = 8
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 41)
      Me.txtDocDateStart.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(107, 20)
      Me.txtDocDateStart.TabIndex = 7
      '
      'EqWithdrawFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "EqWithdrawFilterSubPanel"
      Me.Size = New System.Drawing.Size(808, 208)
      Me.grbDetail.ResumeLayout(False)
      Me.grbGeneral.ResumeLayout(False)
      Me.grbGeneral.PerformLayout()
      Me.grbStock.ResumeLayout(False)
      Me.grbStock.PerformLayout()
      Me.grbWithdraw.ResumeLayout(False)
      Me.grbWithdraw.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      Me.LoopControl(Me)
    End Sub
#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblDocDateEnd}")
      Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblStoreCC}")
      Me.lblStorePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblStorePerson}")
      Me.lblWithdrawPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblWithdrawPerson}")
      Me.lblWithdrawCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblWithdrawCC}")
      Me.chkIsExternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.chkIsExternal}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.lblCode}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.grbGeneral}")
      Me.grbWithdraw.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.grbWithdraw}")
      Me.grbStock.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqWithdrawFilterSubPanel.grbStock}")
    End Sub
#End Region

#Region "Members"
    Private m_withdrawperson As SimpleBusinessEntityBase
    Private m_withdrawcc As CostCenter
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      PopulateStatus()
      ClearCriterias()
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdatestart"
          If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateStart = dtpDocDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.docDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.docDateStart = dtpDocDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.docDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdocdateend"
          If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateEnd = dtpDocDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.docDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.docDateEnd = dtpDocDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.docDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.chkIsExternal.Checked = False

      Me.txtStorePersonCode.Text = ""
      Me.txtStorePersonName.Text = ""
      Me.m_storeperson = New Employee


      Me.txtStoreCCCode.Text = ""
      Me.txtStoreCCName.Text = ""
      Me.m_storecc = New CostCenter

      Me.txtWithdrawPersonCode.Text = ""
      Me.txtWithdrawPersonName.Text = ""
      Me.m_withdrawperson = New Employee

      Me.txtWithdrawCCCode.Text = ""
      Me.txtWithdrawCCName.Text = ""
      Me.m_withdrawcc = New CostCenter

      'Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
      'Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Month, 0, Now.Date), "")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Month, 0, Now.Date)

      Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.docDateEnd = DateAdd(DateInterval.Month, 0, Now.Date)

    End Sub
    Private Sub PopulateStatus()

    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(7) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("withdrawperson", IIf(Me.WithdrawPerson.Originated, Me.WithdrawPerson.Id, DBNull.Value))
      arr(2) = New Filter("withdrawcc", IIf(Me.WithdrawCC.Originated, Me.WithdrawCC.Id, DBNull.Value))
      arr(3) = New Filter("storeperson", IIf(Me.StorePerson.Originated, Me.StorePerson.Id, DBNull.Value))
      arr(4) = New Filter("storecc", IIf(Me.StoreCC.Originated, Me.StoreCC.Id, DBNull.Value))
      arr(5) = New Filter("startdate", ValidDateOrDBNull(docDateStart))
      arr(6) = New Filter("enddate", ValidDateOrDBNull(docDateEnd))
      arr(7) = New Filter("isexternal", IIf(Me.chkIsExternal.Checked, True, DBNull.Value))
      Return arr
    End Function
    ' Searce Button ...
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
    ' Reset Button ...
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
#End Region

#Region " Properties "
    Private Property docDateStart As Date
    Private Property docDateEnd As Date
    Public Property WithdrawPerson() As SimpleBusinessEntityBase      Get        If chkIsExternal.Checked Then          If m_withdrawperson Is Nothing Then            m_withdrawperson = New Customer
          End If        Else          If m_withdrawperson Is Nothing Then            m_withdrawperson = New Employee
          End If        End If        Return m_withdrawperson      End Get      Set(ByVal Value As SimpleBusinessEntityBase)        If chkIsExternal.Checked Then          If m_withdrawperson Is Nothing Then            m_withdrawperson = New Customer
          End If        Else          If m_withdrawperson Is Nothing Then            m_withdrawperson = New Employee
          End If        End If        m_withdrawperson = Value      End Set    End Property    Public Property WithdrawCC() As CostCenter      Get        Return m_withdrawcc      End Get      Set(ByVal Value As CostCenter)        If m_withdrawcc Is Nothing Then          m_withdrawcc = New CostCenter
        End If        m_withdrawcc = Value      End Set    End Property    Public Property StorePerson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        If m_storeperson Is Nothing Then          m_storeperson = New Employee
        End If        m_storeperson = Value      End Set    End Property    Public Property StoreCC() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        If m_storecc Is Nothing Then          m_storecc = New CostCenter
        End If        m_storecc = Value      End Set    End Property
#End Region

#Region " Event Handlers "
    ' Withdraw Person ...
    Private Sub txtWithdrawPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawPersonCode.Validated
      If chkIsExternal.Checked Then
        Dim cust As New Customer
        Customer.GetCustomer(txtWithdrawPersonCode, txtWithdrawPersonName, cust)
        Me.WithdrawPerson = cust
      Else
        Dim emp As New Employee
        Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, emp)
        Me.WithdrawPerson = emp
      End If
    End Sub
    Private Sub btnWithdrawPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If chkIsExternal.Checked Then
        myEntityPanelService.OpenPanel(New Customer)
      Else
        myEntityPanelService.OpenPanel(New Employee)
      End If
    End Sub
    Private Sub btnWithdrawPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If chkIsExternal.Checked Then
        myEntityPanelService.OpenListDialog(New Customer, AddressOf SetWithdrawPerson)
      Else
        myEntityPanelService.OpenListDialog(New Employee, AddressOf SetWithdrawPerson)
      End If
    End Sub
    Private Sub SetWithdrawPerson(ByVal e As ISimpleEntity)
      Me.txtWithdrawPersonCode.Text = e.Code
      If chkIsExternal.Checked Then
        Dim cust As New Customer
        Customer.GetCustomer(txtWithdrawPersonCode, txtWithdrawPersonName, cust)
        Me.WithdrawPerson = cust
      Else
        Dim emp As New Employee
        Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, emp)
        Me.WithdrawPerson = emp
      End If
    End Sub
    ' Withdraw Costcenter ...
    Private Sub txtWithdrawCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWithdrawCCCode.Validated
      CostCenter.GetCostCenter(txtWithdrawCCCode, txtWithdrawCCName, Me.WithdrawCC)
    End Sub
    Private Sub btnWithdrawCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnWithdrawCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetWithdrawCC)
    End Sub
    Private Sub SetWithdrawCC(ByVal e As ISimpleEntity)
      Me.txtWithdrawCCCode.Text = e.Code
      CostCenter.GetCostCenter(txtWithdrawCCCode, txtWithdrawCCName, Me.WithdrawCC)
    End Sub
    ' Store Person ...
    Private Sub txtStorePersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStorePersonCode.Validated
      Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.StorePerson)
    End Sub
    Private Sub btnStorePersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStorePersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnStorePersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStorePersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetStorePerson)
    End Sub
    Private Sub SetStorePerson(ByVal e As ISimpleEntity)
      Me.txtStorePersonCode.Text = e.Code
      Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.StorePerson)
    End Sub
    ' Store Costcenter ...
    Private Sub txtStoreCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoreCCCode.Validated
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.StoreCC)
    End Sub
    Private Sub btnStoreCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnStoreCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStoreCC)
    End Sub
    Private Sub SetStoreCC(ByVal e As ISimpleEntity)
      Me.txtStoreCCCode.Text = e.Code
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.StoreCC)
    End Sub

    ' CheckBox ...
    Private Sub chkIsExternal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsExternal.CheckedChanged
      Dim Flag As Boolean = CType(sender, CheckBox).Checked
      If Flag Then
        txtWithdrawCCCode.Text = ""
        txtWithdrawCCName.Text = ""
        m_withdrawcc = New CostCenter
      End If
      txtWithdrawCCCode.Enabled = Not Flag
      txtWithdrawCCName.Enabled = Not Flag
      btnWithdrawCCEdit.Enabled = Not Flag
      btnWithdrawCCFind.Enabled = Not Flag
    End Sub

#End Region

#Region " IClipboardHandler Overrides " 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject
        ' withdraw person ...
        If chkIsExternal.Checked Then
          If data.GetDataPresent((New Customer).FullClassName) Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
                Return True
            End Select
          End If
        Else
          If data.GetDataPresent((New Employee).FullClassName) Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
                Return True
            End Select
          End If
        End If
        ' store person ...
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtstorepersoncode", "txtstorepersonname"
              Return True
          End Select
        End If
        ' withdraw costcenter ...
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtwithdrawcccode", "txtwithdrawccname"
              Return True
            Case "txtstorecccode", "txtstoreccname"
              Return True
          End Select
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Withdraw person ...
      If chkIsExternal.Checked Then
        If data.GetDataPresent((New Customer).FullClassName) Then
          Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
          Dim entity As New Customer(id)
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
              Me.SetWithdrawPerson(entity)
          End Select
        End If
      Else
        If data.GetDataPresent((New Employee).FullClassName) Then
          Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
          Dim entity As New Employee(id)
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
              Me.SetWithdrawPerson(entity)
          End Select
        End If
      End If
      ' Store Person ...
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtstorepersoncode", "txtstorepersonname"
            Me.SetStorePerson(entity)
        End Select
      End If
      ' Costcenter ...
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtwithdrawcccode", "txtwithdrawccname"
            Me.SetWithdrawCC(entity)
          Case "txtstorecccode", "txtstoreccname"
            Me.SetStoreCC(entity)
        End Select
      End If
    End Sub
#End Region

#Region " Set Entities Filter "
    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        For Each entity As ISimpleEntity In Value
          If TypeOf entity Is AssetWithdraw Then
            Dim obj As AssetWithdraw = CType(entity, AssetWithdraw)

            If obj.IsExternal Then
              Me.chkIsExternal.Checked = True
              Me.chkIsExternal.Enabled = False
            End If

            Dim person As SimpleBusinessEntityBase
            If TypeOf obj.Withdrawperson Is SimpleBusinessEntityBase Then
              person = CType(obj.Withdrawperson, SimpleBusinessEntityBase)
            End If
            If Not person Is Nothing AndAlso person.Originated Then
              Me.SetWithdrawPerson(obj.Withdrawperson)
              Me.txtWithdrawPersonCode.Enabled = False
              Me.txtWithdrawPersonName.Enabled = False
              Me.btnWithdrawPersonEdit.Enabled = False
              Me.btnWithdrawPersonFind.Enabled = False
            End If

            If obj.WithdrawCostcenter.Originated Then
              Me.SetWithdrawCC(obj.WithdrawCostcenter)
              Me.txtWithdrawCCCode.Enabled = False
              Me.txtWithdrawCCName.Enabled = False
              Me.btnWithdrawCCEdit.Enabled = False
              Me.btnWithdrawCCFind.Enabled = False
            End If

            If obj.Storeperson.Originated Then
              Me.SetStorePerson(obj.Storeperson)
              Me.txtStorePersonCode.Enabled = False
              Me.txtStorePersonName.Enabled = False
              Me.btnStorePersonEdit.Enabled = False
              Me.btnStorePersonFind.Enabled = False
            End If

            If obj.StoreCostcenter.Originated Then
              Me.SetStoreCC(obj.StoreCostcenter)
              Me.txtStoreCCCode.Enabled = False
              Me.txtStoreCCName.Enabled = False
              Me.btnStoreCCEdit.Enabled = False
              Me.btnStoreCCFind.Enabled = False
            End If

          End If
        Next
      End Set
    End Property
#End Region
  End Class
End Namespace

