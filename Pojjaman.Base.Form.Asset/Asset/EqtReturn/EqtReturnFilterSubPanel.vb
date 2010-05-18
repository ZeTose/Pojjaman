Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EqtReturnFilterSubPanel
    Inherits AbstractFilterSubPanel

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
    Friend WithEvents grbReturn As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnReturnPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtReturnPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnPersonName As System.Windows.Forms.TextBox
    Friend WithEvents btnReturnPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblReturnPerson As System.Windows.Forms.Label
    Friend WithEvents btnReturnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtReturnCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnCCName As System.Windows.Forms.TextBox
    Friend WithEvents btnReturnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblReturnCC As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblStoreCC As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EqtReturnFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblCode = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.grbStock = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnStorePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnStorePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblStorePerson = New System.Windows.Forms.Label
      Me.txtStorePersonCode = New System.Windows.Forms.TextBox
      Me.txtStorePersonName = New System.Windows.Forms.TextBox
      Me.txtStoreCCName = New System.Windows.Forms.TextBox
      Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblStoreCC = New System.Windows.Forms.Label
      Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtStoreCCCode = New System.Windows.Forms.TextBox
      Me.grbReturn = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnReturnPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtReturnPersonCode = New System.Windows.Forms.TextBox
      Me.txtReturnPersonName = New System.Windows.Forms.TextBox
      Me.btnReturnPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblReturnPerson = New System.Windows.Forms.Label
      Me.btnReturnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtReturnCCCode = New System.Windows.Forms.TextBox
      Me.txtReturnCCName = New System.Windows.Forms.TextBox
      Me.btnReturnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblReturnCC = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbGeneral.SuspendLayout()
      Me.grbStock.SuspendLayout()
      Me.grbReturn.SuspendLayout()
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
      Me.grbDetail.Controls.Add(Me.grbReturn)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(784, 200)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.lblDocDateStart)
      Me.grbGeneral.Controls.Add(Me.lblDocDateEnd)
      Me.grbGeneral.Controls.Add(Me.dtpDocDateStart)
      Me.grbGeneral.Controls.Add(Me.dtpDocDateEnd)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 10)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(768, 72)
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
      Me.txtCode.Location = New System.Drawing.Point(112, 16)
      Me.txtCode.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(352, 21)
      Me.txtCode.TabIndex = 1
      Me.txtCode.Text = ""
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 40)
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
      Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDateEnd.TabIndex = 4
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 40)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 3
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(328, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(704, 168)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(624, 168)
      Me.btnReset.Name = "btnReset"
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
      Me.grbStock.Location = New System.Drawing.Point(400, 88)
      Me.grbStock.Name = "grbStock"
      Me.grbStock.Size = New System.Drawing.Size(376, 72)
      Me.grbStock.TabIndex = 2
      Me.grbStock.TabStop = False
      Me.grbStock.Text = "ผู้ให้เบิก"
      '
      'btnStorePersonFind
      '
      Me.btnStorePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorePersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStorePersonFind.Image = CType(resources.GetObject("btnStorePersonFind.Image"), System.Drawing.Image)
      Me.btnStorePersonFind.Location = New System.Drawing.Point(320, 40)
      Me.btnStorePersonFind.Name = "btnStorePersonFind"
      Me.btnStorePersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStorePersonFind.TabIndex = 8
      Me.btnStorePersonFind.TabStop = False
      Me.btnStorePersonFind.ThemedImage = CType(resources.GetObject("btnStorePersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnStorePersonEdit
      '
      Me.btnStorePersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorePersonEdit.Image = CType(resources.GetObject("btnStorePersonEdit.Image"), System.Drawing.Image)
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
      Me.Validator.SetMaxValue(Me.txtStorePersonCode, "")
      Me.Validator.SetMinValue(Me.txtStorePersonCode, "")
      Me.txtStorePersonCode.Name = "txtStorePersonCode"
      Me.Validator.SetRegularExpression(Me.txtStorePersonCode, "")
      Me.Validator.SetRequired(Me.txtStorePersonCode, False)
      Me.txtStorePersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtStorePersonCode.TabIndex = 6
      Me.txtStorePersonCode.Text = ""
      '
      'txtStorePersonName
      '
      Me.Validator.SetDataType(Me.txtStorePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStorePersonName, System.Drawing.Color.Empty)
      Me.txtStorePersonName.Location = New System.Drawing.Point(224, 40)
      Me.Validator.SetMaxValue(Me.txtStorePersonName, "")
      Me.Validator.SetMinValue(Me.txtStorePersonName, "")
      Me.txtStorePersonName.Name = "txtStorePersonName"
      Me.txtStorePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStorePersonName, "")
      Me.Validator.SetRequired(Me.txtStorePersonName, False)
      Me.txtStorePersonName.Size = New System.Drawing.Size(96, 20)
      Me.txtStorePersonName.TabIndex = 0
      Me.txtStorePersonName.TabStop = False
      Me.txtStorePersonName.Text = ""
      '
      'txtStoreCCName
      '
      Me.Validator.SetDataType(Me.txtStoreCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.txtStoreCCName.Location = New System.Drawing.Point(224, 16)
      Me.Validator.SetMaxValue(Me.txtStoreCCName, "")
      Me.Validator.SetMinValue(Me.txtStoreCCName, "")
      Me.txtStoreCCName.Name = "txtStoreCCName"
      Me.txtStoreCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
      Me.Validator.SetRequired(Me.txtStoreCCName, False)
      Me.txtStoreCCName.Size = New System.Drawing.Size(96, 20)
      Me.txtStoreCCName.TabIndex = 0
      Me.txtStoreCCName.TabStop = False
      Me.txtStoreCCName.Text = ""
      '
      'btnStoreCCEdit
      '
      Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCEdit.Image = CType(resources.GetObject("btnStoreCCEdit.Image"), System.Drawing.Image)
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
      Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStoreCCFind.Image = CType(resources.GetObject("btnStoreCCFind.Image"), System.Drawing.Image)
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
      Me.Validator.SetMaxValue(Me.txtStoreCCCode, "")
      Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
      Me.txtStoreCCCode.Name = "txtStoreCCCode"
      Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
      Me.Validator.SetRequired(Me.txtStoreCCCode, False)
      Me.txtStoreCCCode.Size = New System.Drawing.Size(80, 20)
      Me.txtStoreCCCode.TabIndex = 1
      Me.txtStoreCCCode.Text = ""
      '
      'grbReturn
      '
      Me.grbReturn.Controls.Add(Me.btnReturnPersonEdit)
      Me.grbReturn.Controls.Add(Me.txtReturnPersonCode)
      Me.grbReturn.Controls.Add(Me.txtReturnPersonName)
      Me.grbReturn.Controls.Add(Me.btnReturnPersonFind)
      Me.grbReturn.Controls.Add(Me.lblReturnPerson)
      Me.grbReturn.Controls.Add(Me.btnReturnCCEdit)
      Me.grbReturn.Controls.Add(Me.txtReturnCCCode)
      Me.grbReturn.Controls.Add(Me.txtReturnCCName)
      Me.grbReturn.Controls.Add(Me.btnReturnCCFind)
      Me.grbReturn.Controls.Add(Me.lblReturnCC)
      Me.grbReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbReturn.Location = New System.Drawing.Point(8, 88)
      Me.grbReturn.Name = "grbReturn"
      Me.grbReturn.Size = New System.Drawing.Size(384, 72)
      Me.grbReturn.TabIndex = 1
      Me.grbReturn.TabStop = False
      Me.grbReturn.Text = "ผู้ขอเบิก"
      '
      'btnReturnPersonEdit
      '
      Me.btnReturnPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnReturnPersonEdit.Image = CType(resources.GetObject("btnReturnPersonEdit.Image"), System.Drawing.Image)
      Me.btnReturnPersonEdit.Location = New System.Drawing.Point(352, 40)
      Me.btnReturnPersonEdit.Name = "btnReturnPersonEdit"
      Me.btnReturnPersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnReturnPersonEdit.TabIndex = 9
      Me.btnReturnPersonEdit.TabStop = False
      Me.btnReturnPersonEdit.ThemedImage = CType(resources.GetObject("btnReturnPersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtReturnPersonCode
      '
      Me.Validator.SetDataType(Me.txtReturnPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReturnPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReturnPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReturnPersonCode, System.Drawing.Color.Empty)
      Me.txtReturnPersonCode.Location = New System.Drawing.Point(152, 40)
      Me.txtReturnPersonCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtReturnPersonCode, "")
      Me.Validator.SetMinValue(Me.txtReturnPersonCode, "")
      Me.txtReturnPersonCode.Name = "txtReturnPersonCode"
      Me.Validator.SetRegularExpression(Me.txtReturnPersonCode, "")
      Me.Validator.SetRequired(Me.txtReturnPersonCode, False)
      Me.txtReturnPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtReturnPersonCode.TabIndex = 6
      Me.txtReturnPersonCode.Text = ""
      '
      'txtReturnPersonName
      '
      Me.Validator.SetDataType(Me.txtReturnPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReturnPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
      Me.txtReturnPersonName.Location = New System.Drawing.Point(232, 40)
      Me.Validator.SetMaxValue(Me.txtReturnPersonName, "")
      Me.Validator.SetMinValue(Me.txtReturnPersonName, "")
      Me.txtReturnPersonName.Name = "txtReturnPersonName"
      Me.txtReturnPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtReturnPersonName, "")
      Me.Validator.SetRequired(Me.txtReturnPersonName, False)
      Me.txtReturnPersonName.Size = New System.Drawing.Size(96, 20)
      Me.txtReturnPersonName.TabIndex = 0
      Me.txtReturnPersonName.TabStop = False
      Me.txtReturnPersonName.Text = ""
      '
      'btnReturnPersonFind
      '
      Me.btnReturnPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnReturnPersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnReturnPersonFind.Image = CType(resources.GetObject("btnReturnPersonFind.Image"), System.Drawing.Image)
      Me.btnReturnPersonFind.Location = New System.Drawing.Point(328, 40)
      Me.btnReturnPersonFind.Name = "btnReturnPersonFind"
      Me.btnReturnPersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnReturnPersonFind.TabIndex = 8
      Me.btnReturnPersonFind.TabStop = False
      Me.btnReturnPersonFind.ThemedImage = CType(resources.GetObject("btnReturnPersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblReturnPerson
      '
      Me.lblReturnPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblReturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReturnPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblReturnPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblReturnPerson.Name = "lblReturnPerson"
      Me.lblReturnPerson.Size = New System.Drawing.Size(136, 18)
      Me.lblReturnPerson.TabIndex = 5
      Me.lblReturnPerson.Text = "ผู้ขอเบิก"
      Me.lblReturnPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnReturnCCEdit
      '
      Me.btnReturnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnReturnCCEdit.Image = CType(resources.GetObject("btnReturnCCEdit.Image"), System.Drawing.Image)
      Me.btnReturnCCEdit.Location = New System.Drawing.Point(352, 16)
      Me.btnReturnCCEdit.Name = "btnReturnCCEdit"
      Me.btnReturnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnReturnCCEdit.TabIndex = 4
      Me.btnReturnCCEdit.TabStop = False
      Me.btnReturnCCEdit.ThemedImage = CType(resources.GetObject("btnReturnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtReturnCCCode
      '
      Me.Validator.SetDataType(Me.txtReturnCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReturnCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReturnCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReturnCCCode, System.Drawing.Color.Empty)
      Me.txtReturnCCCode.Location = New System.Drawing.Point(152, 16)
      Me.txtReturnCCCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtReturnCCCode, "")
      Me.Validator.SetMinValue(Me.txtReturnCCCode, "")
      Me.txtReturnCCCode.Name = "txtReturnCCCode"
      Me.Validator.SetRegularExpression(Me.txtReturnCCCode, "")
      Me.Validator.SetRequired(Me.txtReturnCCCode, False)
      Me.txtReturnCCCode.Size = New System.Drawing.Size(80, 20)
      Me.txtReturnCCCode.TabIndex = 1
      Me.txtReturnCCCode.Text = ""
      '
      'txtReturnCCName
      '
      Me.Validator.SetDataType(Me.txtReturnCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReturnCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReturnCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReturnCCName, System.Drawing.Color.Empty)
      Me.txtReturnCCName.Location = New System.Drawing.Point(232, 16)
      Me.Validator.SetMaxValue(Me.txtReturnCCName, "")
      Me.Validator.SetMinValue(Me.txtReturnCCName, "")
      Me.txtReturnCCName.Name = "txtReturnCCName"
      Me.txtReturnCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtReturnCCName, "")
      Me.Validator.SetRequired(Me.txtReturnCCName, False)
      Me.txtReturnCCName.Size = New System.Drawing.Size(96, 20)
      Me.txtReturnCCName.TabIndex = 0
      Me.txtReturnCCName.TabStop = False
      Me.txtReturnCCName.Text = ""
      '
      'btnReturnCCFind
      '
      Me.btnReturnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnReturnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnReturnCCFind.Image = CType(resources.GetObject("btnReturnCCFind.Image"), System.Drawing.Image)
      Me.btnReturnCCFind.Location = New System.Drawing.Point(328, 16)
      Me.btnReturnCCFind.Name = "btnReturnCCFind"
      Me.btnReturnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnReturnCCFind.TabIndex = 3
      Me.btnReturnCCFind.TabStop = False
      Me.btnReturnCCFind.ThemedImage = CType(resources.GetObject("btnReturnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblReturnCC
      '
      Me.lblReturnCC.BackColor = System.Drawing.Color.Transparent
      Me.lblReturnCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReturnCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblReturnCC.Location = New System.Drawing.Point(8, 16)
      Me.lblReturnCC.Name = "lblReturnCC"
      Me.lblReturnCC.Size = New System.Drawing.Size(136, 18)
      Me.lblReturnCC.TabIndex = 0
      Me.lblReturnCC.Text = "Cost Center ขอคืน"
      Me.lblReturnCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'EqtReturnFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "EqtReturnFilterSubPanel"
      Me.Size = New System.Drawing.Size(792, 208)
      Me.grbDetail.ResumeLayout(False)
      Me.grbGeneral.ResumeLayout(False)
      Me.grbStock.ResumeLayout(False)
      Me.grbReturn.ResumeLayout(False)
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
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblDocDateEnd}")
      Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblStoreCC}")
      Me.lblStorePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblStorePerson}")
      Me.lblReturnPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblReturnPerson}")
      Me.lblReturnCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblReturnCC}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.lblCode}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.grbGeneral}")
      Me.grbReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.grbReturn}")
      Me.grbStock.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtFilterSubPanel.grbStock}")
    End Sub
#End Region

#Region "Members"
    Private m_returnperson As Employee
    Private m_returncc As CostCenter
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
#End Region

#Region "Methods"
    Public Sub Initialize()
      PopulateStatus()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.txtStorePersonCode.Text = ""
      Me.txtStorePersonName.Text = ""
      Me.m_storeperson = New Employee


      Me.txtStoreCCCode.Text = ""
      Me.txtStoreCCName.Text = ""
      Me.m_storecc = New CostCenter

      Me.txtReturnPersonCode.Text = ""
      Me.txtReturnPersonName.Text = ""
      Me.m_returnperson = New Employee

      Me.txtReturnCCCode.Text = ""
      Me.txtReturnCCName.Text = ""
      Me.m_returncc = New CostCenter

      Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.dtpDocDateEnd.Value = Now.Date

    End Sub
    Private Sub PopulateStatus()

    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(7) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("returnperson", IIf(Me.m_returnperson.Originated, Me.m_returnperson.Id, DBNull.Value))
      arr(2) = New Filter("returncc", IIf(Me.m_returncc.Originated, Me.m_returncc.Id, DBNull.Value))
      arr(3) = New Filter("storeperson", IIf(Me.m_storeperson.Originated, Me.m_storeperson.Id, DBNull.Value))
      arr(4) = New Filter("storecc", IIf(Me.m_storecc.Originated, Me.m_storecc.Id, DBNull.Value))
      arr(5) = New Filter("startdate", Me.dtpDocDateStart.Value.Date)
      arr(6) = New Filter("enddate", Me.dtpDocDateEnd.Value.Date)
      arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    ' Return Person ...
    Private Sub txtReturnPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnPersonCode.Validated
      Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, Me.m_returnperson)
    End Sub
    Private Sub btnReturnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnReturnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetReturnPerson)
    End Sub
    Private Sub SetReturnPerson(ByVal e As ISimpleEntity)
      Me.txtReturnPersonCode.Text = e.Code
      Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, Me.m_returnperson)
    End Sub
    ' Return Costcenter ...
    Private Sub txtReturnCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnCCCode.Validated
      CostCenter.GetCostCenterWithoutRight(txtReturnCCCode, txtReturnCCName, Me.m_returncc)
    End Sub
    Private Sub btnReturnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnReturnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetReturnCC, New Filter() {New Filter("checkright", False)})
    End Sub
    Private Sub SetReturnCC(ByVal e As ISimpleEntity)
      Me.txtReturnCCCode.Text = e.Code
      CostCenter.GetCostCenterWithoutRight(txtReturnCCCode, txtReturnCCName, Me.m_returncc)
    End Sub
    ' Store Person ...
    Private Sub txtStorePersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStorePersonCode.Validated
      Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.m_storeperson)
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
      Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.m_storeperson)
    End Sub
    ' Store Costcenter ...
    Private Sub txtStoreCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoreCCCode.Validated
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_storecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_storecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' Reset Button ...
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub

#End Region

#Region "IClipboardHandler Overrides" 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Return person ...
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtReturnpersoncode", "txtReturnpersonname"
              Return True
          End Select
        End If
        ' store person ...
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtstorepersoncode", "txtstorepersonname"
              Return True
          End Select
        End If
        ' Return costcenter ...
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtReturncccode", "txtReturnccname"
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
      ' Return person ...
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtReturnpersoncode", "txtReturnpersonname"
            Me.SetReturnPerson(entity)
        End Select
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
          Case "txtReturncccode", "txtReturnccname"
            Me.SetReturnCC(entity)
          Case "txtstorecccode", "txtstoreccname"
            Me.SetStoreCC(entity)
        End Select
      End If
    End Sub
#End Region

    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        For Each entity As ISimpleEntity In Value
          If TypeOf entity Is EquipmentToolReturn Then
            Dim obj As EquipmentToolReturn = CType(entity, EquipmentToolReturn)
            If obj.ReturnPerson.Originated Then
              Me.SetReturnPerson(obj.ReturnPerson)
              Me.txtReturnPersonCode.Enabled = False
              Me.txtReturnPersonName.Enabled = False
              Me.btnReturnPersonEdit.Enabled = False
              Me.btnReturnPersonFind.Enabled = False
            End If

            If obj.ReturnCostcenter.Originated Then
              Me.SetReturnCC(obj.ReturnCostcenter)
              Me.txtReturnCCCode.Enabled = False
              Me.txtReturnCCName.Enabled = False
              Me.btnReturnCCEdit.Enabled = False
              Me.btnReturnCCFind.Enabled = False
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


  End Class
End Namespace

