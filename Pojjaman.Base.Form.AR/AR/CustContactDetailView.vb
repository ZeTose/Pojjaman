Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CustContactDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    'Clear the memory
                    Me.m_entity = Nothing
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
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents primaryDetailGroupBox As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents chkisPrimary As System.Windows.Forms.CheckBox
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents txtTitle As System.Windows.Forms.TextBox
        Friend WithEvents btnCustEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCust As System.Windows.Forms.Label
        Friend WithEvents txtCustName As System.Windows.Forms.TextBox
        Friend WithEvents txtCustCode As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CustContactDetailView))
            Me.primaryDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtCustCode = New System.Windows.Forms.TextBox
            Me.btnCustEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCust = New System.Windows.Forms.Label
            Me.txtCustName = New System.Windows.Forms.TextBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.chkisPrimary = New System.Windows.Forms.CheckBox
            Me.txtEmail = New System.Windows.Forms.TextBox
            Me.lblEmail = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtPhone = New System.Windows.Forms.TextBox
            Me.lblPhone = New System.Windows.Forms.Label
            Me.lblTitle = New System.Windows.Forms.Label
            Me.txtTitle = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.primaryDetailGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'primaryDetailGroupBox
            '
            Me.primaryDetailGroupBox.Controls.Add(Me.txtCustCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.btnCustEdit)
            Me.primaryDetailGroupBox.Controls.Add(Me.btnCustFind)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblCust)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtCustName)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkAutorun)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkisPrimary)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblTitle)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtTitle)
            Me.primaryDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.primaryDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.primaryDetailGroupBox.Location = New System.Drawing.Point(8, 8)
            Me.primaryDetailGroupBox.Name = "primaryDetailGroupBox"
            Me.primaryDetailGroupBox.Size = New System.Drawing.Size(384, 176)
            Me.primaryDetailGroupBox.TabIndex = 0
            Me.primaryDetailGroupBox.TabStop = False
            Me.primaryDetailGroupBox.Text = "ข้อมูลเบื้องต้น:"
            '
            'txtCustCode
            '
            Me.Validator.SetDataType(Me.txtCustCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustCode, "")
            Me.txtCustCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCustCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCustCode, System.Drawing.Color.Empty)
            Me.txtCustCode.Location = New System.Drawing.Point(104, 144)
            Me.txtCustCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCustCode, "")
            Me.Validator.SetMinValue(Me.txtCustCode, "")
            Me.txtCustCode.Name = "txtCustCode"
            Me.Validator.SetRegularExpression(Me.txtCustCode, "")
            Me.Validator.SetRequired(Me.txtCustCode, True)
            Me.txtCustCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCustCode.TabIndex = 23
            Me.txtCustCode.Text = ""
            '
            'btnCustEdit
            '
            Me.btnCustEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustEdit.Image = CType(resources.GetObject("btnCustEdit.Image"), System.Drawing.Image)
            Me.btnCustEdit.Location = New System.Drawing.Point(344, 144)
            Me.btnCustEdit.Name = "btnCustEdit"
            Me.btnCustEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCustEdit.TabIndex = 27
            Me.btnCustEdit.TabStop = False
            Me.btnCustEdit.ThemedImage = CType(resources.GetObject("btnCustEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustFind
            '
            Me.btnCustFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustFind.Image = CType(resources.GetObject("btnCustFind.Image"), System.Drawing.Image)
            Me.btnCustFind.Location = New System.Drawing.Point(320, 144)
            Me.btnCustFind.Name = "btnCustFind"
            Me.btnCustFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCustFind.TabIndex = 26
            Me.btnCustFind.TabStop = False
            Me.btnCustFind.ThemedImage = CType(resources.GetObject("btnCustFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCust
            '
            Me.lblCust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCust.ForeColor = System.Drawing.Color.Black
            Me.lblCust.Location = New System.Drawing.Point(16, 144)
            Me.lblCust.Name = "lblCust"
            Me.lblCust.Size = New System.Drawing.Size(80, 18)
            Me.lblCust.TabIndex = 24
            Me.lblCust.Text = "ชื่อลูกค้า:"
            Me.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustName
            '
            Me.Validator.SetDataType(Me.txtCustName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustName, "")
            Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustName, System.Drawing.Color.Empty)
            Me.txtCustName.Location = New System.Drawing.Point(192, 144)
            Me.Validator.SetMaxValue(Me.txtCustName, "")
            Me.Validator.SetMinValue(Me.txtCustName, "")
            Me.txtCustName.Name = "txtCustName"
            Me.txtCustName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustName, "")
            Me.Validator.SetRequired(Me.txtCustName, False)
            Me.txtCustName.Size = New System.Drawing.Size(128, 21)
            Me.txtCustName.TabIndex = 25
            Me.txtCustName.Text = ""
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(208, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 20
            '
            'chkisPrimary
            '
            Me.chkisPrimary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkisPrimary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkisPrimary.ForeColor = System.Drawing.Color.Black
            Me.chkisPrimary.Location = New System.Drawing.Point(256, 25)
            Me.chkisPrimary.Name = "chkisPrimary"
            Me.chkisPrimary.Size = New System.Drawing.Size(80, 20)
            Me.chkisPrimary.TabIndex = 21
            Me.chkisPrimary.TabStop = False
            Me.chkisPrimary.Text = "ผู้ติดต่อหลัก"
            '
            'txtEmail
            '
            Me.Validator.SetDataType(Me.txtEmail, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmail, "")
            Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.txtEmail.Location = New System.Drawing.Point(104, 120)
            Me.txtEmail.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtEmail, "")
            Me.Validator.SetMinValue(Me.txtEmail, "")
            Me.txtEmail.Name = "txtEmail"
            Me.Validator.SetRegularExpression(Me.txtEmail, "")
            Me.Validator.SetRequired(Me.txtEmail, False)
            Me.txtEmail.Size = New System.Drawing.Size(216, 21)
            Me.txtEmail.TabIndex = 9
            Me.txtEmail.Text = ""
            '
            'lblEmail
            '
            Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(8, 120)
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
            Me.txtName.Location = New System.Drawing.Point(104, 48)
            Me.txtName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(216, 21)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
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
            Me.txtCode.Location = New System.Drawing.Point(104, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(104, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
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
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(104, 96)
            Me.txtPhone.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtPhone, "")
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(216, 21)
            Me.txtPhone.TabIndex = 6
            Me.txtPhone.Text = ""
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(8, 96)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(88, 18)
            Me.lblPhone.TabIndex = 16
            Me.lblPhone.Text = "โทรศัพท์:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Black
            Me.lblTitle.Location = New System.Drawing.Point(8, 72)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(88, 18)
            Me.lblTitle.TabIndex = 16
            Me.lblTitle.Text = "ตำแหน่ง:"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTitle
            '
            Me.Validator.SetDataType(Me.txtTitle, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTitle, "")
            Me.txtTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTitle, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTitle, System.Drawing.Color.Empty)
            Me.txtTitle.Location = New System.Drawing.Point(104, 72)
            Me.txtTitle.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtTitle, "")
            Me.Validator.SetMinValue(Me.txtTitle, "")
            Me.txtTitle.Name = "txtTitle"
            Me.Validator.SetRegularExpression(Me.txtTitle, "")
            Me.Validator.SetRequired(Me.txtTitle, False)
            Me.txtTitle.Size = New System.Drawing.Size(216, 21)
            Me.txtTitle.TabIndex = 2
            Me.txtTitle.Text = ""
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'CustContactDetailView
            '
            Me.Controls.Add(Me.primaryDetailGroupBox)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "CustContactDetailView"
            Me.Size = New System.Drawing.Size(400, 192)
            Me.primaryDetailGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            Me.Validator.SetDisplayName(txtName, lblName.Text)

            Me.chkisPrimary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.chkisPrimary}")

            Me.lblTitle.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.lblTitle}")
            Me.Validator.SetDisplayName(txtTitle, lblTitle.Text)

            Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.lblPhone}")
            Me.Validator.SetDisplayName(txtPhone, lblPhone.Text)

            Me.lblEmail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.lblEmail}")
            Me.Validator.SetDisplayName(txtEmail, lblEmail.Text)

            Me.lblCust.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustContactDetailView.lblCust}")
            Me.Validator.SetDisplayName(txtCustCode, lblCust.Text)
        End Sub
#End Region

#Region "Member"
        Private m_entity As CustomerContact
        Private m_isInitialized As Boolean = False
#End Region

#Region "Property"

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

#Region "IListDetail"
        Public Overrides Sub Initialize()

        End Sub
        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.IsPrimary Then
                For Each ctrl As Control In primaryDetailGroupBox.Controls
                    ctrl.Enabled = True
                Next
            Else
                For Each ctrl As Control In primaryDetailGroupBox.Controls
                    ctrl.Enabled = True
                Next
            End If
        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            'For Each crtl As Control In grbDetail.Controls
            '    If TypeOf crtl Is TextBox Then
            '        crtl.Text = ""
            '    End If
            'Next

            chkisPrimary.Checked = False
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

            AddHandler chkisPrimary.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtTitle.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtPhone.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtEmail.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtCustCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtCustCode.Validated, AddressOf Me.ChangeProperty

        End Sub
        Private txtCustCodeChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustcode"
                    txtCustCodeChanged = True
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

            Me.m_genoldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtName.Text = m_entity.Name
            txtTitle.Text = m_entity.Title
            txtPhone.Text = m_entity.Phone
            txtEmail.Text = m_entity.Email

            If Me.m_entity.isPrimary Then
                chkisPrimary.Checked = True
            Else
                chkisPrimary.Checked = False
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

            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True

                Case "chkisprimary"
                    Me.m_entity.Canceled = chkisPrimary.Checked
                    dirtyFlag = True

                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True

                Case "txttitle"
                    Me.m_entity.Phone = txtTitle.Text
                    dirtyFlag = True

                Case "txtphone"
                    Me.m_entity.Phone = txtPhone.Text
                    dirtyFlag = True

                Case "txtemail"
                    Me.m_entity.Email = txtEmail.Text
                    dirtyFlag = True

                Case "txtcustcode"
                    If txtCustCodeChanged Then
                        dirtyFlag = Customer.GetCustomer(txtCustCode, txtCustName, Me.m_entity.Customer)
                        txtCustCodeChanged = False
                    End If
                    dirtyFlag = True


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
                Me.m_entity = CType(Value, CustomerContact)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

#Region " AutoGenCode "
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_genoldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_genoldCode = Me.txtCode.Text
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.m_entity.Code = ""
                Me.m_entity.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_genoldCode
                Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
        Private Sub btnAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.CustAuxDetailView
            myAuxPanel.Entity = Me.m_entity
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
            If myDialog.ShowDialog() = DialogResult.Cancel Then
                'Me.WorkbenchWindow.ViewContent.IsDirty = True    'neng :ไม่งั้นจะ IsDirty เสมอเมื่อคลิก Cancel
            End If
        End Sub
        Private Sub btnCustEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
            Me.txtCustCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Customer.GetCustomer(txtCustCode, txtCustName, Me.m_entity.Customer)
        End Sub

        Private Sub btnCustFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
        End Sub

#End Region

        '#Region "IClipboardHandler Overrides"
        '        Public Overrides ReadOnly Property EnablePaste() As Boolean
        '            Get
        '                Dim data As IDataObject = Clipboard.GetDataObject
        '                If data.GetDataPresent((New CustomerGroup).FullClassName) Then
        '                    If Not Me.ActiveControl Is Nothing Then
        '                        Select Case Me.ActiveControl.Name.ToLower
        '                            Case "txtgroup", "txtgroupname"
        '                                Return True
        '                        End Select
        '                    End If
        '                End If
        '                If data.GetDataPresent((New Account).FullClassName) Then
        '                    If Not Me.ActiveControl Is Nothing Then
        '                        Select Case Me.ActiveControl.Name.ToLower
        '                            Case "txtaccount", "txtaccountname"
        '                                Return True
        '                        End Select
        '                    End If
        '                End If
        '                Return False
        '            End Get
        '        End Property
        '        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '            Dim data As IDataObject = Clipboard.GetDataObject
        '            If data.GetDataPresent((New CustomerGroup).FullClassName) Then
        '                Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
        '                Dim entity As New CustomerGroup(id)
        '                If Not Me.ActiveControl Is Nothing Then
        '                    Select Case Me.ActiveControl.Name.ToLower
        '                        Case "txtgroup", "txtgroupname"
        '                            Me.SetCustomerGroupDialog(entity)
        '                    End Select
        '                End If
        '            End If
        '            If data.GetDataPresent((New Account).FullClassName) Then
        '                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        '                Dim entity As New Account(id)
        '                If Not Me.ActiveControl Is Nothing Then
        '                    Select Case Me.ActiveControl.Name.ToLower
        '                        Case "txtaccount", "txtaccountname"
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

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New Customer).DetailPanelIcon
            End Get
        End Property
#End Region

    End Class

End Namespace
