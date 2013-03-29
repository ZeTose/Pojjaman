Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AssetDetailFilterSubPanel
    'Inherits UserControl
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents cmbCalcType As System.Windows.Forms.ComboBox
    Friend WithEvents lblCalcType As System.Windows.Forms.Label
    Friend WithEvents grbGroup As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitName As System.Windows.Forms.TextBox
    Friend WithEvents btnUnitEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents btnUnitFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtUnitCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAssettypeName As System.Windows.Forms.TextBox
    Friend WithEvents txtCostcenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCostcenterEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostcenter As System.Windows.Forms.Label
    Friend WithEvents btnCostcenterFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostcenterCode As System.Windows.Forms.TextBox
    Friend WithEvents btnAssettypeFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssettypeEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAssettype As System.Windows.Forms.Label
    Friend WithEvents txtAssettypeCode As System.Windows.Forms.TextBox
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkOnlyCalcEndedStillRemaining As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowRemainingOnly As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssetDetailFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkOnlyCalcEndedStillRemaining = New System.Windows.Forms.CheckBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbGroup = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.txtAccountName = New System.Windows.Forms.TextBox()
      Me.txtUnitName = New System.Windows.Forms.TextBox()
      Me.btnUnitEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblUnit = New System.Windows.Forms.Label()
      Me.btnUnitFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtUnitCode = New System.Windows.Forms.TextBox()
      Me.txtAssettypeName = New System.Windows.Forms.TextBox()
      Me.txtCostcenterName = New System.Windows.Forms.TextBox()
      Me.btnCostcenterEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostcenter = New System.Windows.Forms.Label()
      Me.btnCostcenterFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostcenterCode = New System.Windows.Forms.TextBox()
      Me.btnAssettypeFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAssettypeEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAssettype = New System.Windows.Forms.Label()
      Me.txtAssettypeCode = New System.Windows.Forms.TextBox()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbCalcType = New System.Windows.Forms.ComboBox()
      Me.lblCalcType = New System.Windows.Forms.Label()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.chkShowRemainingOnly = New System.Windows.Forms.CheckBox()
      Me.grbDetail.SuspendLayout()
      Me.grbGroup.SuspendLayout()
      Me.grbGeneral.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 6
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 16)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.chkOnlyCalcEndedStillRemaining)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbGroup)
      Me.grbDetail.Controls.Add(Me.grbGeneral)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(712, 202)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'chkOnlyCalcEndedStillRemaining
      '
      Me.chkOnlyCalcEndedStillRemaining.AutoSize = True
      Me.chkOnlyCalcEndedStillRemaining.Location = New System.Drawing.Point(8, 173)
      Me.chkOnlyCalcEndedStillRemaining.Name = "chkOnlyCalcEndedStillRemaining"
      Me.chkOnlyCalcEndedStillRemaining.Size = New System.Drawing.Size(290, 17)
      Me.chkOnlyCalcEndedStillRemaining.TabIndex = 6
      Me.chkOnlyCalcEndedStillRemaining.Text = "เฉพาะสินทรัพย์มูลค่ายังคงเหลือ แต่สิ้นสุดอายุคำนวณแล้ว"
      Me.chkOnlyCalcEndedStillRemaining.UseVisualStyleBackColor = True
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(624, 173)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(543, 173)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbGroup
      '
      Me.grbGroup.Controls.Add(Me.btnAccountFind)
      Me.grbGroup.Controls.Add(Me.btnAccountEdit)
      Me.grbGroup.Controls.Add(Me.lblAccount)
      Me.grbGroup.Controls.Add(Me.txtAccountCode)
      Me.grbGroup.Controls.Add(Me.txtAccountName)
      Me.grbGroup.Controls.Add(Me.txtUnitName)
      Me.grbGroup.Controls.Add(Me.btnUnitEdit)
      Me.grbGroup.Controls.Add(Me.lblUnit)
      Me.grbGroup.Controls.Add(Me.btnUnitFind)
      Me.grbGroup.Controls.Add(Me.txtUnitCode)
      Me.grbGroup.Controls.Add(Me.txtAssettypeName)
      Me.grbGroup.Controls.Add(Me.txtCostcenterName)
      Me.grbGroup.Controls.Add(Me.btnCostcenterEdit)
      Me.grbGroup.Controls.Add(Me.lblCostcenter)
      Me.grbGroup.Controls.Add(Me.btnCostcenterFind)
      Me.grbGroup.Controls.Add(Me.txtCostcenterCode)
      Me.grbGroup.Controls.Add(Me.btnAssettypeFind)
      Me.grbGroup.Controls.Add(Me.btnAssettypeEdit)
      Me.grbGroup.Controls.Add(Me.lblAssettype)
      Me.grbGroup.Controls.Add(Me.txtAssettypeCode)
      Me.grbGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGroup.Location = New System.Drawing.Point(8, 92)
      Me.grbGroup.Name = "grbGroup"
      Me.grbGroup.Size = New System.Drawing.Size(691, 72)
      Me.grbGroup.TabIndex = 1
      Me.grbGroup.TabStop = False
      Me.grbGroup.Text = "สิ่งที่สั่งซื้อ"
      '
      'btnAccountFind
      '
      Me.btnAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountFind.Location = New System.Drawing.Point(300, 16)
      Me.btnAccountFind.Name = "btnAccountFind"
      Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountFind.TabIndex = 206
      Me.btnAccountFind.TabStop = False
      Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAccountEdit
      '
      Me.btnAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEdit.Location = New System.Drawing.Point(324, 16)
      Me.btnAccountEdit.Name = "btnAccountEdit"
      Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountEdit.TabIndex = 205
      Me.btnAccountEdit.TabStop = False
      Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAccount
      '
      Me.lblAccount.BackColor = System.Drawing.Color.Transparent
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAccount.Location = New System.Drawing.Point(8, 16)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(104, 18)
      Me.lblAccount.TabIndex = 203
      Me.lblAccount.Text = "ผังบัญชี"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(112, 16)
      Me.Validator.SetMaxValue(Me.txtAccountCode, "")
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(80, 20)
      Me.txtAccountCode.TabIndex = 0
      '
      'txtAccountName
      '
      Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.txtAccountName.Location = New System.Drawing.Point(192, 16)
      Me.Validator.SetMaxValue(Me.txtAccountName, "")
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(111, 20)
      Me.txtAccountName.TabIndex = 204
      Me.txtAccountName.TabStop = False
      '
      'txtUnitName
      '
      Me.Validator.SetDataType(Me.txtUnitName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
      Me.txtUnitName.Location = New System.Drawing.Point(192, 40)
      Me.Validator.SetMaxValue(Me.txtUnitName, "")
      Me.Validator.SetMinValue(Me.txtUnitName, "")
      Me.txtUnitName.Name = "txtUnitName"
      Me.txtUnitName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtUnitName, "")
      Me.Validator.SetRequired(Me.txtUnitName, False)
      Me.txtUnitName.Size = New System.Drawing.Size(111, 20)
      Me.txtUnitName.TabIndex = 204
      Me.txtUnitName.TabStop = False
      '
      'btnUnitEdit
      '
      Me.btnUnitEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnUnitEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnUnitEdit.Location = New System.Drawing.Point(324, 40)
      Me.btnUnitEdit.Name = "btnUnitEdit"
      Me.btnUnitEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnUnitEdit.TabIndex = 205
      Me.btnUnitEdit.TabStop = False
      Me.btnUnitEdit.ThemedImage = CType(resources.GetObject("btnUnitEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblUnit
      '
      Me.lblUnit.BackColor = System.Drawing.Color.Transparent
      Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnit.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblUnit.Location = New System.Drawing.Point(8, 40)
      Me.lblUnit.Name = "lblUnit"
      Me.lblUnit.Size = New System.Drawing.Size(104, 18)
      Me.lblUnit.TabIndex = 203
      Me.lblUnit.Text = "หน่วยนับ"
      Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnUnitFind
      '
      Me.btnUnitFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnUnitFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnUnitFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnUnitFind.Location = New System.Drawing.Point(300, 40)
      Me.btnUnitFind.Name = "btnUnitFind"
      Me.btnUnitFind.Size = New System.Drawing.Size(24, 23)
      Me.btnUnitFind.TabIndex = 206
      Me.btnUnitFind.TabStop = False
      Me.btnUnitFind.ThemedImage = CType(resources.GetObject("btnUnitFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtUnitCode
      '
      Me.Validator.SetDataType(Me.txtUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtUnitCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
      Me.txtUnitCode.Location = New System.Drawing.Point(112, 40)
      Me.Validator.SetMaxValue(Me.txtUnitCode, "")
      Me.Validator.SetMinValue(Me.txtUnitCode, "")
      Me.txtUnitCode.Name = "txtUnitCode"
      Me.Validator.SetRegularExpression(Me.txtUnitCode, "")
      Me.Validator.SetRequired(Me.txtUnitCode, False)
      Me.txtUnitCode.Size = New System.Drawing.Size(80, 20)
      Me.txtUnitCode.TabIndex = 1
      '
      'txtAssettypeName
      '
      Me.Validator.SetDataType(Me.txtAssettypeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssettypeName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAssettypeName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssettypeName, System.Drawing.Color.Empty)
      Me.txtAssettypeName.Location = New System.Drawing.Point(528, 16)
      Me.Validator.SetMaxValue(Me.txtAssettypeName, "")
      Me.Validator.SetMinValue(Me.txtAssettypeName, "")
      Me.txtAssettypeName.Name = "txtAssettypeName"
      Me.txtAssettypeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssettypeName, "")
      Me.Validator.SetRequired(Me.txtAssettypeName, False)
      Me.txtAssettypeName.Size = New System.Drawing.Size(111, 20)
      Me.txtAssettypeName.TabIndex = 204
      Me.txtAssettypeName.TabStop = False
      '
      'txtCostcenterName
      '
      Me.Validator.SetDataType(Me.txtCostcenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostcenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostcenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostcenterName, System.Drawing.Color.Empty)
      Me.txtCostcenterName.Location = New System.Drawing.Point(528, 40)
      Me.Validator.SetMaxValue(Me.txtCostcenterName, "")
      Me.Validator.SetMinValue(Me.txtCostcenterName, "")
      Me.txtCostcenterName.Name = "txtCostcenterName"
      Me.txtCostcenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostcenterName, "")
      Me.Validator.SetRequired(Me.txtCostcenterName, False)
      Me.txtCostcenterName.Size = New System.Drawing.Size(111, 20)
      Me.txtCostcenterName.TabIndex = 204
      Me.txtCostcenterName.TabStop = False
      '
      'btnCostcenterEdit
      '
      Me.btnCostcenterEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterEdit.Location = New System.Drawing.Point(661, 40)
      Me.btnCostcenterEdit.Name = "btnCostcenterEdit"
      Me.btnCostcenterEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCostcenterEdit.TabIndex = 205
      Me.btnCostcenterEdit.TabStop = False
      Me.btnCostcenterEdit.ThemedImage = CType(resources.GetObject("btnCostcenterEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostcenter
      '
      Me.lblCostcenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostcenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostcenter.Location = New System.Drawing.Point(344, 40)
      Me.lblCostcenter.Name = "lblCostcenter"
      Me.lblCostcenter.Size = New System.Drawing.Size(104, 18)
      Me.lblCostcenter.TabIndex = 203
      Me.lblCostcenter.Text = "Cost Center"
      Me.lblCostcenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCostcenterFind
      '
      Me.btnCostcenterFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostcenterFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterFind.Location = New System.Drawing.Point(637, 40)
      Me.btnCostcenterFind.Name = "btnCostcenterFind"
      Me.btnCostcenterFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCostcenterFind.TabIndex = 206
      Me.btnCostcenterFind.TabStop = False
      Me.btnCostcenterFind.ThemedImage = CType(resources.GetObject("btnCostcenterFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostcenterCode
      '
      Me.Validator.SetDataType(Me.txtCostcenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostcenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostcenterCode, System.Drawing.Color.Empty)
      Me.txtCostcenterCode.Location = New System.Drawing.Point(448, 40)
      Me.Validator.SetMaxValue(Me.txtCostcenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostcenterCode, "")
      Me.txtCostcenterCode.Name = "txtCostcenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostcenterCode, "")
      Me.Validator.SetRequired(Me.txtCostcenterCode, False)
      Me.txtCostcenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtCostcenterCode.TabIndex = 1
      '
      'btnAssettypeFind
      '
      Me.btnAssettypeFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssettypeFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssettypeFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssettypeFind.Location = New System.Drawing.Point(637, 16)
      Me.btnAssettypeFind.Name = "btnAssettypeFind"
      Me.btnAssettypeFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAssettypeFind.TabIndex = 206
      Me.btnAssettypeFind.TabStop = False
      Me.btnAssettypeFind.ThemedImage = CType(resources.GetObject("btnAssettypeFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssettypeEdit
      '
      Me.btnAssettypeEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssettypeEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssettypeEdit.Location = New System.Drawing.Point(661, 16)
      Me.btnAssettypeEdit.Name = "btnAssettypeEdit"
      Me.btnAssettypeEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAssettypeEdit.TabIndex = 205
      Me.btnAssettypeEdit.TabStop = False
      Me.btnAssettypeEdit.ThemedImage = CType(resources.GetObject("btnAssettypeEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAssettype
      '
      Me.lblAssettype.BackColor = System.Drawing.Color.Transparent
      Me.lblAssettype.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssettype.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAssettype.Location = New System.Drawing.Point(344, 16)
      Me.lblAssettype.Name = "lblAssettype"
      Me.lblAssettype.Size = New System.Drawing.Size(104, 18)
      Me.lblAssettype.TabIndex = 203
      Me.lblAssettype.Text = "ประเภทสินทรัพย์"
      Me.lblAssettype.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAssettypeCode
      '
      Me.Validator.SetDataType(Me.txtAssettypeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssettypeCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAssettypeCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssettypeCode, System.Drawing.Color.Empty)
      Me.txtAssettypeCode.Location = New System.Drawing.Point(448, 16)
      Me.Validator.SetMaxValue(Me.txtAssettypeCode, "")
      Me.Validator.SetMinValue(Me.txtAssettypeCode, "")
      Me.txtAssettypeCode.Name = "txtAssettypeCode"
      Me.Validator.SetRegularExpression(Me.txtAssettypeCode, "")
      Me.Validator.SetRequired(Me.txtAssettypeCode, False)
      Me.txtAssettypeCode.Size = New System.Drawing.Size(80, 20)
      Me.txtAssettypeCode.TabIndex = 0
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.chkShowRemainingOnly)
      Me.grbGeneral.Controls.Add(Me.cmbCalcType)
      Me.grbGeneral.Controls.Add(Me.lblCalcType)
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.Controls.Add(Me.cmbStatus)
      Me.grbGeneral.Controls.Add(Me.lblStatus)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(691, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      Me.grbGeneral.Text = "รายละเอียดทั่วไป"
      '
      'cmbCalcType
      '
      Me.cmbCalcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCalcType.Location = New System.Drawing.Point(111, 41)
      Me.cmbCalcType.Name = "cmbCalcType"
      Me.cmbCalcType.Size = New System.Drawing.Size(144, 21)
      Me.cmbCalcType.TabIndex = 3
      '
      'lblCalcType
      '
      Me.lblCalcType.BackColor = System.Drawing.Color.Transparent
      Me.lblCalcType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCalcType.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCalcType.Location = New System.Drawing.Point(8, 41)
      Me.lblCalcType.Name = "lblCalcType"
      Me.lblCalcType.Size = New System.Drawing.Size(104, 18)
      Me.lblCalcType.TabIndex = 197
      Me.lblCalcType.Text = "ประเภทการคำนวณ:"
      Me.lblCalcType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(336, 16)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(144, 21)
      Me.cmbStatus.TabIndex = 198
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(264, 16)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(64, 18)
      Me.lblStatus.TabIndex = 199
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'chkShowRemainingOnly
      '
      Me.chkShowRemainingOnly.AutoSize = True
      Me.chkShowRemainingOnly.Location = New System.Drawing.Point(336, 45)
      Me.chkShowRemainingOnly.Name = "chkShowRemainingOnly"
      Me.chkShowRemainingOnly.Size = New System.Drawing.Size(200, 17)
      Me.chkShowRemainingOnly.TabIndex = 6
      Me.chkShowRemainingOnly.Text = "แสดงเฉพาะสินทรัพย์ที่มีมูลค่าคงเหลือ"
      Me.chkShowRemainingOnly.UseVisualStyleBackColor = True
      '
      'AssetDetailFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "AssetDetailFilterSubPanel"
      Me.Size = New System.Drawing.Size(728, 218)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbGroup.ResumeLayout(False)
      Me.grbGroup.PerformLayout()
      Me.grbGeneral.ResumeLayout(False)
      Me.grbGeneral.PerformLayout()
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

#Region "Members"

    Private m_account As Account
    Private m_unit As Unit
    Private m_assettype As AssetType
    Private m_cc As CostCenter
    Private m_calctype As AssetCalcType

#End Region

#Region "Methods"
    Public Sub Initialize()
      Me.chkOnlyCalcEndedStillRemaining.Visible = Not CBool(Configuration.GetConfig("HideChkOnlyCalcEndedStillRemaining"))
      Me.chkShowRemainingOnly.Enabled = Not Me.chkOnlyCalcEndedStillRemaining.Visible

      PupolateCalctype()
      ClearCriterias()
    End Sub
    Private Sub PupolateCalctype()
      CodeDescription.ListCodeDescriptionInComboBox(cmbCalcType, "asset_calctype")
      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "asset_status", True)
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.cmbCalcType.SelectedIndex = -1

      Me.cmbStatus.SelectedIndex = 0 'All

      Me.txtAccountCode.Text = ""
      Me.txtAccountName.Text = ""
      Me.m_account = New Account

      Me.txtUnitCode.Text = ""
      Me.txtUnitName.Text = ""
      Me.m_unit = New Unit

      Me.txtAssettypeCode.Text = ""
      Me.txtAssettypeName.Text = ""
      Me.m_assettype = New AssetType

      Me.txtCostcenterCode.Text = ""
      Me.txtCostcenterName.Text = ""
      Me.m_cc = New CostCenter

      Me.chkOnlyCalcEndedStillRemaining.Checked = False

      EntityRefresh()
    End Sub

    Public Sub SetLabelText()
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblCode}")
      Me.lblCalcType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblCalcType}")
      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblAccount}")
      Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblUnit}")
      Me.lblCostcenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblCostcenter}")
      Me.lblAssettype.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblAssettype}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.grbGeneral}")
      Me.grbGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.grbGroup}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.lblStatus}")
      Me.chkOnlyCalcEndedStillRemaining.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.chkOnlyCalcEndedStillRemaining}") 'เฉพาะสินทรัพย์มูลค่ายังคงเหลือ แต่สิ้นสุดอายุคำนวณแล้ว
            Me.chkShowRemainingOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailFilterSubPanel.chkShowRemainingOnly}") 'แสดงเฉพาะสินทรัพย์ที่มีมูลค่าคงเหลือ และยังไม่หมดอายุ
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(8) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(2) = New Filter("account", IIf(Me.m_account.Originated, Me.m_account.Id, DBNull.Value))
      arr(3) = New Filter("unit", IIf(Me.m_unit.Originated, Me.m_unit.Id, DBNull.Value))
      arr(4) = New Filter("assettype", IIf(Me.m_assettype.Originated, Me.m_assettype.Id, DBNull.Value))
      arr(5) = New Filter("costcenter ", IIf(Me.m_cc.Originated, Me.m_cc.Id, DBNull.Value))
      arr(6) = New Filter("calctype", IIf(Me.cmbCalcType.SelectedIndex = -1, DBNull.Value, Me.cmbCalcType.SelectedIndex))
      arr(7) = New Filter("isCalEndedStillRemaining", IIf(Me.chkOnlyCalcEndedStillRemaining.Checked, 1, DBNull.Value))
      arr(8) = New Filter("showRemainingOnly", IIf(Me.chkShowRemainingOnly.Checked, 1, DBNull.Value))
      Return arr
    End Function

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub

    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    ' Account ...
    Private Sub txtAccountCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Validated
      Account.GetAccount(txtAccountCode, txtAccountName, Me.m_account)
    End Sub
    Private Sub btnAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccount)
    End Sub
    Private Sub SetAccount(ByVal e As ISimpleEntity)
      Me.txtAccountCode.Text = e.Code
      Account.GetAccount(txtAccountCode, txtAccountName, Me.m_account)
    End Sub
    ' Unit ...
    Private Sub txtUnitCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCode.Validated
      Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_unit)
    End Sub
    Private Sub btnUnitEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Unit)
    End Sub
    Private Sub btnUnitFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
    End Sub
    Private Sub SetUnit(ByVal e As ISimpleEntity)
      Me.txtUnitCode.Text = e.Code
      Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_unit)
    End Sub
    ' Asset type ...
    Private Sub txtAssettypeCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAssettypeCode.Validated
      AssetType.GetAssetType(txtAssettypeCode, txtAssettypeName, Me.m_assettype)
    End Sub
    Private Sub btnAssettypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssettypeEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New AssetType)
    End Sub
    Private Sub btnAssettypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssettypeFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssettype)
    End Sub
    Private Sub SetAssettype(ByVal e As ISimpleEntity)
      Me.txtAssettypeCode.Text = e.Code
      AssetType.GetAssetType(txtAssettypeCode, txtAssettypeName, Me.m_assettype)
    End Sub
    ' Costcenter ...
    Private Sub txtCostcenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostcenterCode.Validated
      CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_cc)
    End Sub
    Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostcenterEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostcenterFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenter)
    End Sub
    Private Sub SetCostcenter(ByVal e As ISimpleEntity)
      Me.txtCostcenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_cc)
    End Sub

#End Region

#Region "IClipboardHandler Overrides"   'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Account ...
        If data.GetDataPresent((New Account).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtaccountcode", "txtaccountname"
              Return True
          End Select
        End If
        ' Unit
        If data.GetDataPresent((New Unit).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtunitcode", "txtunitname"
              Return True
          End Select
        End If
        ' Asset type ...
        If data.GetDataPresent((New AssetType).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtassettypecode", "txtassettypename"
              Return True
          End Select
        End If
        ' Costcenter ...
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercode", "txtcostcentername"
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
      ' Account ...
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtaccountcode", "txtaccountname"
            Me.SetAccount(entity)
        End Select
      End If
      ' unit ...
      If data.GetDataPresent((New Unit).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Unit).FullClassName))
        Dim entity As New Unit(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtunitcode", "txtunitname"
            Me.SetUnit(entity)
        End Select
      End If
      ' Asset type ...
      If data.GetDataPresent((New AssetType).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AssetType).FullClassName))
        Dim entity As New AssetType(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtassettypecode", "txtassettypename"
            Me.SetAssettype(entity)
        End Select
      End If
      ' costcenter 
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtcostcentercode", "txtcostcentername"
            Me.SetCostcenter(entity)
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
        EntityRefresh()
      End Set
    End Property
    Private Sub EntityRefresh()
      If Entities Is Nothing Then
        Return
      End If
      For Each entity As Object In Entities

        If TypeOf entity Is ISimpleEntity AndAlso TypeOf entity Is Asset Then
          Dim obj As Asset
          obj = CType(entity, Asset)
          ' Account ...
          If obj.Account.Originated Then
            Me.SetAccount(obj.Account)
            Me.txtAccountCode.Enabled = False
            Me.txtAccountName.Enabled = False
            Me.btnAccountEdit.Enabled = False
            Me.btnAccountFind.Enabled = False
          End If
          '' DepreAccount ...
          'If obj.DepreAccount.Originated Then
          '    Me.SetCostcenter(obj.Costcenter)
          '    Me.txtCostcenterCode.Enabled = False
          '    Me.txtCostcenterName.Enabled = False
          '    Me.btnCostcenterEdit.Enabled = False
          '    Me.btnCostcenterFind.Enabled = False
          'End If
          ' unit ...
          If obj.Unit.Originated Then
            Me.SetUnit(obj.Unit)
            Me.txtUnitCode.Enabled = False
            Me.txtUnitName.Enabled = False
            Me.btnUnitEdit.Enabled = False
            Me.btnUnitFind.Enabled = False
          End If
          ' Asset type ...
          If obj.Type.Originated Then
            Me.SetAssettype(obj.Type)
            Me.txtAssettypeCode.Enabled = False
            Me.txtAssettypeName.Enabled = False
            Me.btnAssettypeEdit.Enabled = False
            Me.btnAssettypeFind.Enabled = False
          End If
          If obj.Status.Value <> -1 Then
            CodeDescription.ComboSelect(Me.cmbStatus, obj.Status)
            Me.cmbStatus.Enabled = False
          End If
          ' Costcenter ...
          If obj.Costcenter.Originated Then
            Me.SetCostcenter(obj.Costcenter)
            Me.txtCostcenterCode.Enabled = False
            Me.txtCostcenterName.Enabled = False
            Me.btnCostcenterEdit.Enabled = False
            Me.btnCostcenterFind.Enabled = False
          End If

        ElseIf TypeOf entity Is CheckBox Then
          Me.chkShowRemainingOnly.Checked = CType(entity, CheckBox).Checked
          'Me.chkShowRemainingOnly.Enabled = False
        End If

      Next
    End Sub

    Private Sub chkOnlyCalcEndedStillRemaining_CheckedChanged(sender As Object, e As EventArgs) Handles chkOnlyCalcEndedStillRemaining.CheckedChanged
      'If chkOnlyCalcEndedStillRemaining.Checked Then
      chkShowRemainingOnly.Checked = Not chkOnlyCalcEndedStillRemaining.Checked
      'End If
    End Sub
  End Class
End Namespace

