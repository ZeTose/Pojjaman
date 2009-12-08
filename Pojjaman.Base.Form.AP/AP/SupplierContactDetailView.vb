Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SupplierContactDetailView
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
        Friend WithEvents primaryDetailGroupBox As FixedGroupBox
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents chkprimary As System.Windows.Forms.CheckBox
        Friend WithEvents btnSupplierFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSupplierEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents txtTitle As System.Windows.Forms.TextBox
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupplierContactDetailView))
            Me.primaryDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSupplierFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnSupplierEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.txtSupplierCode = New System.Windows.Forms.TextBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.chkprimary = New System.Windows.Forms.CheckBox
            Me.txtEmail = New System.Windows.Forms.TextBox
            Me.lblEmail = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtPhone = New System.Windows.Forms.TextBox
            Me.lblPhone = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtTitle = New System.Windows.Forms.TextBox
            Me.lblTitle = New System.Windows.Forms.Label
            Me.primaryDetailGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'primaryDetailGroupBox
            '
            Me.primaryDetailGroupBox.Controls.Add(Me.btnSupplierFind)
            Me.primaryDetailGroupBox.Controls.Add(Me.btnSupplierEdit)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblSupplier)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtSupplierName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtSupplierCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkAutorun)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkprimary)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtTitle)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblTitle)
            Me.primaryDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.primaryDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.primaryDetailGroupBox.Location = New System.Drawing.Point(8, 0)
            Me.primaryDetailGroupBox.Name = "primaryDetailGroupBox"
            Me.primaryDetailGroupBox.Size = New System.Drawing.Size(384, 176)
            Me.primaryDetailGroupBox.TabIndex = 0
            Me.primaryDetailGroupBox.TabStop = False
            Me.primaryDetailGroupBox.Text = "ข้อมูลเบื้องต้น : "
            '
            'btnSupplierFind
            '
            Me.btnSupplierFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierFind.Image = CType(resources.GetObject("btnSupplierFind.Image"), System.Drawing.Image)
            Me.btnSupplierFind.Location = New System.Drawing.Point(320, 144)
            Me.btnSupplierFind.Name = "btnSupplierFind"
            Me.btnSupplierFind.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierFind.TabIndex = 25
            Me.btnSupplierFind.TabStop = False
            Me.btnSupplierFind.ThemedImage = CType(resources.GetObject("btnSupplierFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSupplierEdit
            '
            Me.btnSupplierEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierEdit.Image = CType(resources.GetObject("btnSupplierEdit.Image"), System.Drawing.Image)
            Me.btnSupplierEdit.Location = New System.Drawing.Point(344, 144)
            Me.btnSupplierEdit.Name = "btnSupplierEdit"
            Me.btnSupplierEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierEdit.TabIndex = 26
            Me.btnSupplierEdit.TabStop = False
            Me.btnSupplierEdit.ThemedImage = CType(resources.GetObject("btnSupplierEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSupplier
            '
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.ForeColor = System.Drawing.Color.Black
            Me.lblSupplier.Location = New System.Drawing.Point(40, 144)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
            Me.lblSupplier.TabIndex = 23
            Me.lblSupplier.Text = "Supplier :"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.txtSupplierName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(200, 144)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(120, 21)
            Me.txtSupplierName.TabIndex = 24
            Me.txtSupplierName.TabStop = False
            Me.txtSupplierName.Text = ""
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(120, 144)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, True)
            Me.txtSupplierCode.Size = New System.Drawing.Size(80, 21)
            Me.txtSupplierCode.TabIndex = 22
            Me.txtSupplierCode.Text = ""
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(232, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 20
            Me.chkAutorun.TabStop = False
            '
            'chkprimary
            '
            Me.chkprimary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkprimary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkprimary.ForeColor = System.Drawing.Color.Black
            Me.chkprimary.Location = New System.Drawing.Point(264, 24)
            Me.chkprimary.Name = "chkprimary"
            Me.chkprimary.Size = New System.Drawing.Size(80, 20)
            Me.chkprimary.TabIndex = 21
            Me.chkprimary.TabStop = False
            Me.chkprimary.Text = "ผู้ติดต่อหลัก"
            '
            'txtEmail
            '
            Me.Validator.SetDataType(Me.txtEmail, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmail, "")
            Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmail, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.txtEmail.Location = New System.Drawing.Point(120, 120)
            Me.txtEmail.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtEmail, "")
            Me.Validator.SetMinValue(Me.txtEmail, "")
            Me.txtEmail.Name = "txtEmail"
            Me.Validator.SetRegularExpression(Me.txtEmail, "")
            Me.Validator.SetRequired(Me.txtEmail, False)
            Me.txtEmail.Size = New System.Drawing.Size(224, 21)
            Me.txtEmail.TabIndex = 9
            Me.txtEmail.Text = ""
            '
            'lblEmail
            '
            Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(32, 120)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(88, 18)
            Me.lblEmail.TabIndex = 19
            Me.lblEmail.Text = "อีเมล์:"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(120, 48)
            Me.txtName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(224, 21)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(32, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(88, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(112, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(32, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 18)
            Me.lblCode.TabIndex = 10
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhone
            '
            Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhone, "")
            Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPhone, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(120, 96)
            Me.txtPhone.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtPhone, "")
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(224, 21)
            Me.txtPhone.TabIndex = 6
            Me.txtPhone.Text = ""
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(32, 96)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(88, 18)
            Me.lblPhone.TabIndex = 16
            Me.lblPhone.Text = "โทรศัพท์:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'txtTitle
            '
            Me.Validator.SetDataType(Me.txtTitle, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTitle, "")
            Me.txtTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTitle, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtTitle, -15)
            Me.Validator.SetInvalidBackColor(Me.txtTitle, System.Drawing.Color.Empty)
            Me.txtTitle.Location = New System.Drawing.Point(120, 72)
            Me.txtTitle.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtTitle, "")
            Me.Validator.SetMinValue(Me.txtTitle, "")
            Me.txtTitle.Name = "txtTitle"
            Me.Validator.SetRegularExpression(Me.txtTitle, "")
            Me.Validator.SetRequired(Me.txtTitle, False)
            Me.txtTitle.Size = New System.Drawing.Size(224, 21)
            Me.txtTitle.TabIndex = 1
            Me.txtTitle.Text = ""
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Black
            Me.lblTitle.Location = New System.Drawing.Point(32, 72)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(88, 18)
            Me.lblTitle.TabIndex = 11
            Me.lblTitle.Text = "ตำแหน่ง:"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'SupplierContactDetailView
            '
            Me.Controls.Add(Me.primaryDetailGroupBox)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "SupplierContactDetailView"
            Me.Size = New System.Drawing.Size(400, 184)
            Me.primaryDetailGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, lblCode.Text)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, lblName.Text)

            Me.lblTitle.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblTitle}")
            Me.Validator.SetDisplayName(Me.txtTitle, lblTitle.Text)

            Me.lblEmail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblEmail}")
            Me.Validator.SetDisplayName(Me.txtEmail, lblEmail.Text)

            Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblPhone}")
            Me.Validator.SetDisplayName(Me.txtPhone, lblPhone.Text)

            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.lblSupplier}")
            Me.Validator.SetDisplayName(Me.txtSupplierCode, lblSupplier.Text)

            Me.chkprimary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierContactDetailView.chkprimary}")

        End Sub
#End Region

#Region " Member "
        Private m_entity As SupplierContact
        Private m_isInitialized As Boolean = False
#End Region

#Region " Constructor "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Me.Initialize()
            Me.EventWiring()
        End Sub
#End Region

#Region " IListDetail "
        Public Overrides Sub Initialize()

        End Sub

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled Then
                For Each ctrl As Control In primaryDetailGroupBox.Controls
                    ctrl.Enabled = False
                Next
            Else
                For Each ctrl As Control In primaryDetailGroupBox.Controls
                    ctrl.Enabled = True
                Next
            End If
        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In primaryDetailGroupBox.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            chkprimary.Checked = False

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtTitle.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkprimary.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtPhone.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtEmail.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty


        End Sub
        Private txtSupplierCodeChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtsuppliercode"
                    txtSupplierCodeChanged = True
            End Select
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name
            txtTitle.Text = m_entity.Title

            ' AutoRun 
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtPhone.Text = m_entity.Phone
            txtEmail.Text = m_entity.Email

            txtSupplierCode.Text = m_entity.Supplier.Code
            txtSupplierName.Text = m_entity.Supplier.Name

            If Me.m_entity.IsPrimary Then
                chkprimary.Checked = True
            Else
                chkprimary.Checked = False
            End If

            SetStatus()
            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Dim dirtyFlag As Boolean
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True

                Case "chkprimary"
                    Me.m_entity.IsPrimary = chkprimary.Checked
                    dirtyFlag = True

                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True

                Case "txttitle"
                    Me.m_entity.Title = txtTitle.Text
                    dirtyFlag = True

                Case "txtphone"
                    Me.m_entity.Phone = txtPhone.Text
                    dirtyFlag = True

                Case "txtemail"
                    Me.m_entity.Email = txtEmail.Text
                    dirtyFlag = True

                Case "txtsuppliercode"
                    If txtSupplierCodeChanged Then
                        dirtyFlag = Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier)
                        txtSupplierCodeChanged = False
                    End If

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
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, SupplierContact)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

        '#Region "IClipboardHandler Overrides"
        '        Public Overrides ReadOnly Property EnablePaste() As Boolean
        '            Get
        '                Dim data As IDataObject = Clipboard.GetDataObject
        '                If data.GetDataPresent((New SupplierGroup).FullClassName) Then
        '                    If Not Me.ActiveControl Is Nothing Then
        '                        Select Case Me.ActiveControl.Name.ToLower
        '                            Case "txtgroupcode", "txtgroupname"
        '                                Return True
        '                        End Select
        '                    End If
        '                End If
        '                If data.GetDataPresent((New Account).FullClassName) Then
        '                    If Not Me.ActiveControl Is Nothing Then
        '                        Select Case Me.ActiveControl.Name.ToLower
        '                            Case "txtaccountcode", "txtaccountname"
        '                                Return True
        '                        End Select
        '                    End If
        '                End If
        '                Return False
        '            End Get
        '        End Property
        '        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '            Dim data As IDataObject = Clipboard.GetDataObject
        '            If data.GetDataPresent((New SupplierGroup).FullClassName) Then
        '                Dim id As Integer = CInt(data.GetData((New SupplierGroup).FullClassName))
        '                Dim entity As New SupplierGroup(id)
        '                If Not Me.ActiveControl Is Nothing Then
        '                    Select Case Me.ActiveControl.Name.ToLower
        '                        Case "txtgroupcode", "txtgroupname"
        '                            Me.SetSupplierGroupDialog(entity)
        '                    End Select
        '                End If
        '            End If
        '            If data.GetDataPresent((New Account).FullClassName) Then
        '                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        '                Dim entity As New Account(id)
        '                If Not Me.ActiveControl Is Nothing Then
        '                    Select Case Me.ActiveControl.Name.ToLower
        '                        Case "txtaccountcode", "txtaccountname"
        '                            Me.SetAccountDialog(entity)
        '                    End Select
        '                End If
        '            End If
        '        End Sub
        '#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Event of Button Controls"
        ' Open Entity panels
        Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub

        ' Supplier
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
        End Sub
        Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
            Me.txtSupplierCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier)
        End Sub
#End Region

#Region " AutoGenCode "
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

    End Class

End Namespace
