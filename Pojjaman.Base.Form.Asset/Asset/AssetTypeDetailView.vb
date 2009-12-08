Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AssetTypeDetailView
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
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblParent As System.Windows.Forms.Label
        Friend WithEvents txtParent As System.Windows.Forms.TextBox
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtUnitCode As System.Windows.Forms.TextBox
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        Friend WithEvents btnUnitEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnUnitFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtUnitName As System.Windows.Forms.TextBox
        Friend WithEvents lblDepreOpeningAcct As System.Windows.Forms.Label
        Friend WithEvents btnGLFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtGLCode As System.Windows.Forms.TextBox
        Friend WithEvents lblGl As System.Windows.Forms.Label
        Friend WithEvents btnGLEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtGLName As System.Windows.Forms.TextBox
        Friend WithEvents btnDepreAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblDepreAcct As System.Windows.Forms.Label
        Friend WithEvents btnDepreAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreAcctName As System.Windows.Forms.TextBox
        Friend WithEvents btnDepreOpeningAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreOpeningAcctName As System.Windows.Forms.TextBox
        Friend WithEvents btnDepreOpeningAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDepreOpeningAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblRent As System.Windows.Forms.Label
        Friend WithEvents txtRent As System.Windows.Forms.TextBox
        Friend WithEvents lblDateInval As System.Windows.Forms.Label
        Friend WithEvents chkCanbeRented As System.Windows.Forms.CheckBox
        Friend WithEvents chkDepreAble As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetTypeDetailView))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtUnitName = New System.Windows.Forms.TextBox
            Me.txtUnitCode = New System.Windows.Forms.TextBox
            Me.txtGLCode = New System.Windows.Forms.TextBox
            Me.txtGLName = New System.Windows.Forms.TextBox
            Me.txtDepreAcctCode = New System.Windows.Forms.TextBox
            Me.txtDepreAcctName = New System.Windows.Forms.TextBox
            Me.txtDepreOpeningAcctName = New System.Windows.Forms.TextBox
            Me.txtDepreOpeningAcctCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtParent = New System.Windows.Forms.TextBox
            Me.txtAltName = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblAltName = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblDepreOpeningAcct = New System.Windows.Forms.Label
            Me.btnGLFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblGl = New System.Windows.Forms.Label
            Me.btnGLEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnDepreAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblDepreAcct = New System.Windows.Forms.Label
            Me.btnDepreAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnDepreOpeningAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnDepreOpeningAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnUnitEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnUnitFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.lblParent = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.chkDepreAble = New System.Windows.Forms.CheckBox
            Me.lblUnit = New System.Windows.Forms.Label
            Me.lblRent = New System.Windows.Forms.Label
            Me.txtRent = New System.Windows.Forms.TextBox
            Me.lblDateInval = New System.Windows.Forms.Label
            Me.chkCanbeRented = New System.Windows.Forms.CheckBox
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(152, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(84, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'txtUnitName
            '
            Me.Validator.SetDataType(Me.txtUnitName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnitName, "")
            Me.txtUnitName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtUnitName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtUnitName, System.Drawing.Color.Empty)
            Me.txtUnitName.Location = New System.Drawing.Point(232, 96)
            Me.Validator.SetMaxValue(Me.txtUnitName, "")
            Me.Validator.SetMinValue(Me.txtUnitName, "")
            Me.txtUnitName.Name = "txtUnitName"
            Me.txtUnitName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtUnitName, "")
            Me.Validator.SetRequired(Me.txtUnitName, False)
            Me.txtUnitName.Size = New System.Drawing.Size(120, 21)
            Me.txtUnitName.TabIndex = 15
            Me.txtUnitName.TabStop = False
            Me.txtUnitName.Text = ""
            '
            'txtUnitCode
            '
            Me.txtUnitCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtUnitCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnitCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtUnitCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtUnitCode, System.Drawing.Color.Empty)
            Me.txtUnitCode.Location = New System.Drawing.Point(152, 96)
            Me.Validator.SetMaxValue(Me.txtUnitCode, "")
            Me.Validator.SetMinValue(Me.txtUnitCode, "")
            Me.txtUnitCode.Name = "txtUnitCode"
            Me.Validator.SetRegularExpression(Me.txtUnitCode, "")
            Me.Validator.SetRequired(Me.txtUnitCode, True)
            Me.txtUnitCode.Size = New System.Drawing.Size(84, 21)
            Me.txtUnitCode.TabIndex = 3
            Me.txtUnitCode.Text = ""
            '
            'txtGLCode
            '
            Me.Validator.SetDataType(Me.txtGLCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGLCode, "")
            Me.txtGLCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGLCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGLCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGLCode, System.Drawing.Color.Empty)
            Me.txtGLCode.Location = New System.Drawing.Point(152, 152)
            Me.txtGLCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtGLCode, "")
            Me.Validator.SetMinValue(Me.txtGLCode, "")
            Me.txtGLCode.Name = "txtGLCode"
            Me.Validator.SetRegularExpression(Me.txtGLCode, "")
            Me.Validator.SetRequired(Me.txtGLCode, True)
            Me.txtGLCode.Size = New System.Drawing.Size(112, 21)
            Me.txtGLCode.TabIndex = 5
            Me.txtGLCode.Text = ""
            '
            'txtGLName
            '
            Me.Validator.SetDataType(Me.txtGLName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGLName, "")
            Me.txtGLName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGLName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGLName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGLName, System.Drawing.Color.Empty)
            Me.txtGLName.Location = New System.Drawing.Point(264, 152)
            Me.Validator.SetMaxValue(Me.txtGLName, "")
            Me.Validator.SetMinValue(Me.txtGLName, "")
            Me.txtGLName.Name = "txtGLName"
            Me.txtGLName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGLName, "")
            Me.Validator.SetRequired(Me.txtGLName, False)
            Me.txtGLName.Size = New System.Drawing.Size(208, 21)
            Me.txtGLName.TabIndex = 23
            Me.txtGLName.TabStop = False
            Me.txtGLName.Text = ""
            '
            'txtDepreAcctCode
            '
            Me.Validator.SetDataType(Me.txtDepreAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepreAcctCode, "")
            Me.txtDepreAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepreAcctCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDepreAcctCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDepreAcctCode, System.Drawing.Color.Empty)
            Me.txtDepreAcctCode.Location = New System.Drawing.Point(152, 200)
            Me.txtDepreAcctCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtDepreAcctCode, "")
            Me.Validator.SetMinValue(Me.txtDepreAcctCode, "")
            Me.txtDepreAcctCode.Name = "txtDepreAcctCode"
            Me.Validator.SetRegularExpression(Me.txtDepreAcctCode, "")
            Me.Validator.SetRequired(Me.txtDepreAcctCode, True)
            Me.txtDepreAcctCode.Size = New System.Drawing.Size(112, 21)
            Me.txtDepreAcctCode.TabIndex = 7
            Me.txtDepreAcctCode.Text = ""
            '
            'txtDepreAcctName
            '
            Me.Validator.SetDataType(Me.txtDepreAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepreAcctName, "")
            Me.txtDepreAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepreAcctName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDepreAcctName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDepreAcctName, System.Drawing.Color.Empty)
            Me.txtDepreAcctName.Location = New System.Drawing.Point(264, 200)
            Me.Validator.SetMaxValue(Me.txtDepreAcctName, "")
            Me.Validator.SetMinValue(Me.txtDepreAcctName, "")
            Me.txtDepreAcctName.Name = "txtDepreAcctName"
            Me.txtDepreAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDepreAcctName, "")
            Me.Validator.SetRequired(Me.txtDepreAcctName, False)
            Me.txtDepreAcctName.Size = New System.Drawing.Size(208, 21)
            Me.txtDepreAcctName.TabIndex = 25
            Me.txtDepreAcctName.TabStop = False
            Me.txtDepreAcctName.Text = ""
            '
            'txtDepreOpeningAcctName
            '
            Me.Validator.SetDataType(Me.txtDepreOpeningAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctName, "")
            Me.txtDepreOpeningAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepreOpeningAcctName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDepreOpeningAcctName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDepreOpeningAcctName, System.Drawing.Color.Empty)
            Me.txtDepreOpeningAcctName.Location = New System.Drawing.Point(264, 176)
            Me.Validator.SetMaxValue(Me.txtDepreOpeningAcctName, "")
            Me.Validator.SetMinValue(Me.txtDepreOpeningAcctName, "")
            Me.txtDepreOpeningAcctName.Name = "txtDepreOpeningAcctName"
            Me.txtDepreOpeningAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDepreOpeningAcctName, "")
            Me.Validator.SetRequired(Me.txtDepreOpeningAcctName, False)
            Me.txtDepreOpeningAcctName.Size = New System.Drawing.Size(208, 21)
            Me.txtDepreOpeningAcctName.TabIndex = 24
            Me.txtDepreOpeningAcctName.TabStop = False
            Me.txtDepreOpeningAcctName.Text = ""
            '
            'txtDepreOpeningAcctCode
            '
            Me.Validator.SetDataType(Me.txtDepreOpeningAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctCode, "")
            Me.txtDepreOpeningAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepreOpeningAcctCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDepreOpeningAcctCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDepreOpeningAcctCode, System.Drawing.Color.Empty)
            Me.txtDepreOpeningAcctCode.Location = New System.Drawing.Point(152, 176)
            Me.txtDepreOpeningAcctCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtDepreOpeningAcctCode, "")
            Me.Validator.SetMinValue(Me.txtDepreOpeningAcctCode, "")
            Me.txtDepreOpeningAcctCode.Name = "txtDepreOpeningAcctCode"
            Me.Validator.SetRegularExpression(Me.txtDepreOpeningAcctCode, "")
            Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, True)
            Me.txtDepreOpeningAcctCode.Size = New System.Drawing.Size(112, 21)
            Me.txtDepreOpeningAcctCode.TabIndex = 6
            Me.txtDepreOpeningAcctCode.Text = ""
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'txtParent
            '
            Me.txtParent.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtParent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtParent, "")
            Me.Validator.SetGotFocusBackColor(Me.txtParent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtParent, System.Drawing.Color.Empty)
            Me.txtParent.Location = New System.Drawing.Point(152, 120)
            Me.Validator.SetMaxValue(Me.txtParent, "")
            Me.Validator.SetMinValue(Me.txtParent, "")
            Me.txtParent.Name = "txtParent"
            Me.txtParent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtParent, "")
            Me.Validator.SetRequired(Me.txtParent, False)
            Me.txtParent.Size = New System.Drawing.Size(248, 21)
            Me.txtParent.TabIndex = 4
            Me.txtParent.Text = ""
            '
            'txtAltName
            '
            Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(152, 72)
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(248, 21)
            Me.txtAltName.TabIndex = 2
            Me.txtAltName.Text = ""
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(152, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(248, 21)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.Location = New System.Drawing.Point(64, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(88, 20)
            Me.lblAltName.TabIndex = 13
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblRent)
            Me.grbDetail.Controls.Add(Me.txtRent)
            Me.grbDetail.Controls.Add(Me.lblDateInval)
            Me.grbDetail.Controls.Add(Me.lblDepreOpeningAcct)
            Me.grbDetail.Controls.Add(Me.btnGLFind)
            Me.grbDetail.Controls.Add(Me.txtGLCode)
            Me.grbDetail.Controls.Add(Me.lblGl)
            Me.grbDetail.Controls.Add(Me.btnGLEdit)
            Me.grbDetail.Controls.Add(Me.txtGLName)
            Me.grbDetail.Controls.Add(Me.btnDepreAcctFind)
            Me.grbDetail.Controls.Add(Me.txtDepreAcctCode)
            Me.grbDetail.Controls.Add(Me.lblDepreAcct)
            Me.grbDetail.Controls.Add(Me.btnDepreAcctEdit)
            Me.grbDetail.Controls.Add(Me.txtDepreAcctName)
            Me.grbDetail.Controls.Add(Me.btnDepreOpeningAcctEdit)
            Me.grbDetail.Controls.Add(Me.txtDepreOpeningAcctName)
            Me.grbDetail.Controls.Add(Me.btnDepreOpeningAcctFind)
            Me.grbDetail.Controls.Add(Me.txtDepreOpeningAcctCode)
            Me.grbDetail.Controls.Add(Me.txtUnitName)
            Me.grbDetail.Controls.Add(Me.btnUnitEdit)
            Me.grbDetail.Controls.Add(Me.btnUnitFind)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.lblParent)
            Me.grbDetail.Controls.Add(Me.txtParent)
            Me.grbDetail.Controls.Add(Me.lblAltName)
            Me.grbDetail.Controls.Add(Me.txtAltName)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.chkDepreAble)
            Me.grbDetail.Controls.Add(Me.txtUnitCode)
            Me.grbDetail.Controls.Add(Me.lblUnit)
            Me.grbDetail.Controls.Add(Me.chkCanbeRented)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(8, 24)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(584, 256)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'lblDepreOpeningAcct
            '
            Me.lblDepreOpeningAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDepreOpeningAcct.ForeColor = System.Drawing.Color.Black
            Me.lblDepreOpeningAcct.Location = New System.Drawing.Point(24, 176)
            Me.lblDepreOpeningAcct.Name = "lblDepreOpeningAcct"
            Me.lblDepreOpeningAcct.Size = New System.Drawing.Size(128, 32)
            Me.lblDepreOpeningAcct.TabIndex = 20
            Me.lblDepreOpeningAcct.Text = "Accumulated Depreciation Acc."
            Me.lblDepreOpeningAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnGLFind
            '
            Me.btnGLFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGLFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnGLFind.Image = CType(resources.GetObject("btnGLFind.Image"), System.Drawing.Image)
            Me.btnGLFind.Location = New System.Drawing.Point(472, 152)
            Me.btnGLFind.Name = "btnGLFind"
            Me.btnGLFind.Size = New System.Drawing.Size(24, 23)
            Me.btnGLFind.TabIndex = 27
            Me.btnGLFind.TabStop = False
            Me.btnGLFind.ThemedImage = CType(resources.GetObject("btnGLFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblGl
            '
            Me.lblGl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGl.ForeColor = System.Drawing.Color.Black
            Me.lblGl.Location = New System.Drawing.Point(24, 152)
            Me.lblGl.Name = "lblGl"
            Me.lblGl.Size = New System.Drawing.Size(128, 18)
            Me.lblGl.TabIndex = 19
            Me.lblGl.Text = "ผังบัญชี :"
            Me.lblGl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnGLEdit
            '
            Me.btnGLEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGLEdit.Image = CType(resources.GetObject("btnGLEdit.Image"), System.Drawing.Image)
            Me.btnGLEdit.Location = New System.Drawing.Point(496, 152)
            Me.btnGLEdit.Name = "btnGLEdit"
            Me.btnGLEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnGLEdit.TabIndex = 28
            Me.btnGLEdit.TabStop = False
            Me.btnGLEdit.ThemedImage = CType(resources.GetObject("btnGLEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnDepreAcctFind
            '
            Me.btnDepreAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnDepreAcctFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnDepreAcctFind.Image = CType(resources.GetObject("btnDepreAcctFind.Image"), System.Drawing.Image)
            Me.btnDepreAcctFind.Location = New System.Drawing.Point(472, 200)
            Me.btnDepreAcctFind.Name = "btnDepreAcctFind"
            Me.btnDepreAcctFind.Size = New System.Drawing.Size(24, 23)
            Me.btnDepreAcctFind.TabIndex = 31
            Me.btnDepreAcctFind.TabStop = False
            Me.btnDepreAcctFind.ThemedImage = CType(resources.GetObject("btnDepreAcctFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblDepreAcct
            '
            Me.lblDepreAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDepreAcct.ForeColor = System.Drawing.Color.Black
            Me.lblDepreAcct.Location = New System.Drawing.Point(24, 200)
            Me.lblDepreAcct.Name = "lblDepreAcct"
            Me.lblDepreAcct.Size = New System.Drawing.Size(128, 32)
            Me.lblDepreAcct.TabIndex = 21
            Me.lblDepreAcct.Text = "ผังบัญชี ค่าเสื่อมราคา:"
            Me.lblDepreAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnDepreAcctEdit
            '
            Me.btnDepreAcctEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnDepreAcctEdit.Image = CType(resources.GetObject("btnDepreAcctEdit.Image"), System.Drawing.Image)
            Me.btnDepreAcctEdit.Location = New System.Drawing.Point(496, 200)
            Me.btnDepreAcctEdit.Name = "btnDepreAcctEdit"
            Me.btnDepreAcctEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnDepreAcctEdit.TabIndex = 32
            Me.btnDepreAcctEdit.TabStop = False
            Me.btnDepreAcctEdit.ThemedImage = CType(resources.GetObject("btnDepreAcctEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnDepreOpeningAcctEdit
            '
            Me.btnDepreOpeningAcctEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnDepreOpeningAcctEdit.Image = CType(resources.GetObject("btnDepreOpeningAcctEdit.Image"), System.Drawing.Image)
            Me.btnDepreOpeningAcctEdit.Location = New System.Drawing.Point(496, 176)
            Me.btnDepreOpeningAcctEdit.Name = "btnDepreOpeningAcctEdit"
            Me.btnDepreOpeningAcctEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnDepreOpeningAcctEdit.TabIndex = 30
            Me.btnDepreOpeningAcctEdit.TabStop = False
            Me.btnDepreOpeningAcctEdit.ThemedImage = CType(resources.GetObject("btnDepreOpeningAcctEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnDepreOpeningAcctFind
            '
            Me.btnDepreOpeningAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnDepreOpeningAcctFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnDepreOpeningAcctFind.Image = CType(resources.GetObject("btnDepreOpeningAcctFind.Image"), System.Drawing.Image)
            Me.btnDepreOpeningAcctFind.Location = New System.Drawing.Point(472, 176)
            Me.btnDepreOpeningAcctFind.Name = "btnDepreOpeningAcctFind"
            Me.btnDepreOpeningAcctFind.Size = New System.Drawing.Size(24, 23)
            Me.btnDepreOpeningAcctFind.TabIndex = 29
            Me.btnDepreOpeningAcctFind.TabStop = False
            Me.btnDepreOpeningAcctFind.ThemedImage = CType(resources.GetObject("btnDepreOpeningAcctFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnUnitEdit
            '
            Me.btnUnitEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnUnitEdit.Image = CType(resources.GetObject("btnUnitEdit.Image"), System.Drawing.Image)
            Me.btnUnitEdit.Location = New System.Drawing.Point(376, 96)
            Me.btnUnitEdit.Name = "btnUnitEdit"
            Me.btnUnitEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnUnitEdit.TabIndex = 17
            Me.btnUnitEdit.TabStop = False
            Me.btnUnitEdit.ThemedImage = CType(resources.GetObject("btnUnitEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnUnitFind
            '
            Me.btnUnitFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnUnitFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnUnitFind.Image = CType(resources.GetObject("btnUnitFind.Image"), System.Drawing.Image)
            Me.btnUnitFind.Location = New System.Drawing.Point(352, 96)
            Me.btnUnitFind.Name = "btnUnitFind"
            Me.btnUnitFind.Size = New System.Drawing.Size(24, 23)
            Me.btnUnitFind.TabIndex = 16
            Me.btnUnitFind.TabStop = False
            Me.btnUnitFind.ThemedImage = CType(resources.GetObject("btnUnitFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 10
            '
            'lblParent
            '
            Me.lblParent.Location = New System.Drawing.Point(48, 120)
            Me.lblParent.Name = "lblParent"
            Me.lblParent.Size = New System.Drawing.Size(104, 20)
            Me.lblParent.TabIndex = 18
            Me.lblParent.Text = "อยู่ภายใต้กลุ่มแม่:"
            Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(64, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 20)
            Me.lblCode.TabIndex = 9
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Location = New System.Drawing.Point(64, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(88, 20)
            Me.lblName.TabIndex = 12
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkDepreAble
            '
            Me.chkDepreAble.Location = New System.Drawing.Point(408, 72)
            Me.chkDepreAble.Name = "chkDepreAble"
            Me.chkDepreAble.Size = New System.Drawing.Size(144, 24)
            Me.chkDepreAble.TabIndex = 11
            Me.chkDepreAble.Text = "คิดค่าเสื่อม"
            '
            'lblUnit
            '
            Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit.Location = New System.Drawing.Point(64, 96)
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Size = New System.Drawing.Size(88, 20)
            Me.lblUnit.TabIndex = 14
            Me.lblUnit.Text = "หน่วยนับ:"
            Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRent
            '
            Me.lblRent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRent.ForeColor = System.Drawing.Color.Black
            Me.lblRent.Location = New System.Drawing.Point(24, 224)
            Me.lblRent.Name = "lblRent"
            Me.lblRent.Size = New System.Drawing.Size(128, 18)
            Me.lblRent.TabIndex = 22
            Me.lblRent.Text = "ค่าเช่าพื้นฐาน:"
            Me.lblRent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRent
            '
            Me.Validator.SetDataType(Me.txtRent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtRent, "")
            Me.txtRent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRent, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRent, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRent, System.Drawing.Color.Empty)
            Me.txtRent.Location = New System.Drawing.Point(152, 224)
            Me.Validator.SetMaxValue(Me.txtRent, "")
            Me.Validator.SetMinValue(Me.txtRent, "")
            Me.txtRent.Name = "txtRent"
            Me.Validator.SetRegularExpression(Me.txtRent, "")
            Me.Validator.SetRequired(Me.txtRent, False)
            Me.txtRent.Size = New System.Drawing.Size(112, 21)
            Me.txtRent.TabIndex = 8
            Me.txtRent.Text = ""
            Me.txtRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDateInval
            '
            Me.lblDateInval.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDateInval.ForeColor = System.Drawing.Color.Black
            Me.lblDateInval.Location = New System.Drawing.Point(272, 224)
            Me.lblDateInval.Name = "lblDateInval"
            Me.lblDateInval.Size = New System.Drawing.Size(96, 18)
            Me.lblDateInval.TabIndex = 26
            Me.lblDateInval.Text = "บาทต่อวัน"
            Me.lblDateInval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkCanbeRented
            '
            Me.chkCanbeRented.Location = New System.Drawing.Point(408, 48)
            Me.chkCanbeRented.Name = "chkCanbeRented"
            Me.chkCanbeRented.Size = New System.Drawing.Size(144, 24)
            Me.chkCanbeRented.TabIndex = 11
            Me.chkCanbeRented.Text = "เบิกได้"
            '
            'AssetTypeDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "AssetTypeDetailView"
            Me.Size = New System.Drawing.Size(600, 288)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not Me.m_entity Is Nothing Then
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            End If
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text.TrimEnd(":".ToCharArray))
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text.TrimEnd(":".ToCharArray))
            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblAltName}")
            Me.Validator.SetDisplayName(Me.txtAltName, Me.lblAltName.Text.TrimEnd(":".ToCharArray))
            Me.lblParent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblParent}")
            Me.Validator.SetDisplayName(Me.txtParent, Me.lblParent.Text.TrimEnd(":".ToCharArray))

            Me.chkCanbeRented.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.chkCanbeRented}")
            Me.chkDepreAble.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.chkDepreAble}")

            Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetTypeDetailView.lblUnit}")
            Me.Validator.SetDisplayName(Me.txtUnitCode, Me.lblUnit.Text.TrimEnd(":".ToCharArray))

            ' 
            Me.lblGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblGl}")
            Me.Validator.SetDisplayName(Me.txtGLCode, StringHelper.GetRidOfAtEnd(Me.lblGl.Text, ":"))


            Me.lblDepreOpeningAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreOpeningAcct}")
            Me.Validator.SetDisplayName(Me.txtDepreOpeningAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreOpeningAcct.Text, ":"))

            Me.lblDepreAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDepreAcct}")
            Me.Validator.SetDisplayName(Me.txtDepreAcctCode, StringHelper.GetRidOfAtEnd(Me.lblDepreAcct.Text, ":"))

            Me.lblRent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblRent}")
            Me.Validator.SetDisplayName(txtRent, lblRent.Text)
            Me.lblDateInval.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblDateInval}")

        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Members"
        Private m_entity As AssetType
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, TreeBaseEntity)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property


        Public Overrides Sub ClearDetail()
            txtCode.Text = ""
            txtName.Text = ""
            txtAltName.Text = ""

            For Each ctrl As Control In Me.grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next
        End Sub
        Public Overrides Sub Initialize()

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkDepreAble.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler chkCanbeRented.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler txtUnitCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtGLCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDepreOpeningAcctCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDepreAcctCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtRent.Validated, AddressOf Me.NumerberTextBoxChange
            AddHandler txtRent.TextChanged, AddressOf Me.ChangeProperty
        End Sub
        Public Sub NumerberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtrent"
                    txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Price)
                Case "txtfairprice"
                    'txtFairPrice.Text = Configuration.FormatToString(Me.m_entity.FairPrice, DigitConfig.Price)
            End Select
        End Sub
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name
            txtAltName.Text = m_entity.AlternateName
            If Not m_entity.Parent Is Nothing AndAlso m_entity.Parent.Originated Then
                Me.txtParent.Text = m_entity.Parent.Name
            Else
                Me.txtParent.Text = "Root" 'Todo
            End If

            Me.chkDepreAble.Checked = m_entity.DepreAble
            If Me.m_entity.DepreAble Then
                Me.Validator.SetRequired(Me.txtDepreAcctCode, True)
                Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, True)
            Else
                Me.Validator.SetRequired(Me.txtDepreAcctCode, False)
                Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, False)

                Me.ErrorProvider1.SetError(Me.txtDepreAcctCode, "")
                Me.ErrorProvider1.SetError(Me.txtDepreOpeningAcctCode, "")
            End If
            Me.chkCanbeRented.Checked = m_entity.CanBeRented

            If Not Me.m_entity.Unit Is Nothing Then
                txtUnitCode.Text = Me.m_entity.Unit.Code
                txtUnitName.Text = Me.m_entity.Unit.Name
            End If

            If Not Me.m_entity.Account Is Nothing Then
                txtGLCode.Text = Me.m_entity.Account.Code
                txtGLName.Text = Me.m_entity.Account.Name
            End If
            If Not Me.m_entity.DepreOpeningAccount Is Nothing Then
                txtDepreOpeningAcctCode.Text = Me.m_entity.DepreOpeningAccount.Code
                txtDepreOpeningAcctName.Text = Me.m_entity.DepreOpeningAccount.Name
            End If
            If Not Me.m_entity.DepreAccount Is Nothing Then
                txtDepreAcctCode.Text = Me.m_entity.DepreAccount.Code
                txtDepreAcctName.Text = Me.m_entity.DepreAccount.Name
            End If
            txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Qty)
            'txtFairPrice.Text = Configuration.FormatToString(Me.m_entity.FairPrice, DigitConfig.Qty)
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            'Todo: Remove this line
            Me.StatusBarService.SetMessage(Me.m_entity.Level.ToString)
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtrent"
                    If txtRent.TextLength > 0 Then
                        Me.m_entity.RentalRate = CDec(txtRent.Text)
                    Else
                        Me.m_entity.RentalRate = Nothing
                    End If
                    dirtyFlag = True
                    'Case "txtfairprice"
                    '    If txtFairPrice.TextLength > 0 Then
                    '        Me.m_entity.FairPrice = CDec(txtFairPrice.Text)
                    '    Else
                    '        Me.m_entity.FairPrice = Nothing
                    '    End If
                    '    dirtyFlag = True

                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True
                Case "txtaltname"
                    Me.m_entity.AlternateName = txtAltName.Text
                    dirtyFlag = True
                Case "chkcanberented"
                    Me.m_entity.CanBeRented = chkCanbeRented.Checked
                    dirtyFlag = True
                Case "chkdepreable"
                    Me.m_entity.DepreAble = chkDepreAble.Checked
                    If Me.m_entity.DepreAble Then
                        Me.Validator.SetRequired(Me.txtDepreAcctCode, True)
                        Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, True)
                    Else
                        Me.Validator.SetRequired(Me.txtDepreAcctCode, False)
                        Me.Validator.SetRequired(Me.txtDepreOpeningAcctCode, False)

                        Me.ErrorProvider1.SetError(Me.txtDepreAcctCode, "")
                        Me.ErrorProvider1.SetError(Me.txtDepreOpeningAcctCode, "")
                    End If
                    dirtyFlag = True
                Case "txtunitcode"
                    dirtyFlag = Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.Unit)

                Case "txtglcode"
                    dirtyFlag = Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
                Case "txtdepreopeningacctcode"
                    dirtyFlag = Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
                Case "txtdepreacctcode"
                    dirtyFlag = Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            CheckFormEnable()
        End Sub
#End Region

#Region "Event"
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

        ' Unit button
        Private Sub btnUnitEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Unit)
        End Sub
        Private Sub btnUnitFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnitDialog)
        End Sub
        Private Sub SetUnitDialog(ByVal e As ISimpleEntity)
            Me.txtUnitCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Unit.GetUnit(txtUnitCode, txtUnitName, Me.m_entity.Unit)
        End Sub

        Private Sub btnGLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGLEdit.Click, btnDepreAcctEdit.Click, btnDepreOpeningAcctEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Account)
        End Sub
        Private Sub btnGLFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGLFind.Click, btnDepreAcctFind.Click, btnDepreOpeningAcctFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnglfind"
                    myentitypanelservice.opentreedialog(New Account, AddressOf setaccountdialog)
                Case "btndepreopeningacctfind"
                    myentitypanelservice.opentreedialog(New Account, AddressOf setdepreopeningaccountdialog)
                Case "btndepreacctfind"
                    myentitypanelservice.opentreedialog(New Account, AddressOf setdepreaccountdialog)
            End Select
        End Sub
        Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
            Me.txtGLCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
        End Sub
        Private Sub SetDepreOpeningAccountDialog(ByVal e As ISimpleEntity)
            Me.txtDepreOpeningAcctCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
        End Sub
        Private Sub SetDepreAccountDialog(ByVal e As ISimpleEntity)
            Me.txtDepreAcctCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
        End Sub
#End Region

        Private Sub GroupDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            Dim myListPanelView As GroupPanelView = CType(Me.WorkbenchWindow.SubViewContents(0), GroupPanelView)
            AddHandler myListPanelView.Saved, AddressOf EntitySaved
        End Sub
        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

        End Sub

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

    End Class

End Namespace
