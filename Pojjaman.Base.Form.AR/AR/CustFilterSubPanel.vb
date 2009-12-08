Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CustFilterSubPanel
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
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblProvince As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents btnCustGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CustFilterSubPanel))
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblGroup = New System.Windows.Forms.Label
            Me.txtGroupCode = New System.Windows.Forms.TextBox
            Me.lblAddress = New System.Windows.Forms.Label
            Me.txtAddress = New System.Windows.Forms.TextBox
            Me.lblPhone = New System.Windows.Forms.Label
            Me.txtPhone = New System.Windows.Forms.TextBox
            Me.lblProvince = New System.Windows.Forms.Label
            Me.cmbProvince = New System.Windows.Forms.ComboBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnCustGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.txtGroupName = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 49)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(120, 18)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "Name/Other Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(128, 48)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(208, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.Text = ""
            '
            'lblGroup
            '
            Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Black
            Me.lblGroup.Location = New System.Drawing.Point(360, 72)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(112, 18)
            Me.lblGroup.TabIndex = 10
            Me.lblGroup.Text = "Customer Group:"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGroupCode
            '
            Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupCode, "")
            Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGroupCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.txtGroupCode.Location = New System.Drawing.Point(472, 72)
            Me.txtGroupCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtGroupCode, "")
            Me.Validator.SetMinValue(Me.txtGroupCode, "")
            Me.txtGroupCode.Name = "txtGroupCode"
            Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
            Me.Validator.SetRequired(Me.txtGroupCode, False)
            Me.txtGroupCode.Size = New System.Drawing.Size(88, 21)
            Me.txtGroupCode.TabIndex = 6
            Me.txtGroupCode.Text = ""
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(24, 73)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(104, 18)
            Me.lblAddress.TabIndex = 8
            Me.lblAddress.Text = "Address:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddress
            '
            Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddress, "")
            Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAddress, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.txtAddress.Location = New System.Drawing.Point(128, 72)
            Me.txtAddress.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtAddress, "")
            Me.Validator.SetMinValue(Me.txtAddress, "")
            Me.txtAddress.Name = "txtAddress"
            Me.Validator.SetRegularExpression(Me.txtAddress, "")
            Me.Validator.SetRequired(Me.txtAddress, False)
            Me.txtAddress.Size = New System.Drawing.Size(208, 21)
            Me.txtAddress.TabIndex = 3
            Me.txtAddress.Text = ""
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(360, 48)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(112, 18)
            Me.lblPhone.TabIndex = 6
            Me.lblPhone.Text = "Telephone/Fax:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhone
            '
            Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhone, "")
            Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPhone, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(472, 48)
            Me.txtPhone.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtPhone, "")
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(240, 21)
            Me.txtPhone.TabIndex = 5
            Me.txtPhone.Text = ""
            '
            'lblProvince
            '
            Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProvince.ForeColor = System.Drawing.Color.Black
            Me.lblProvince.Location = New System.Drawing.Point(360, 24)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(112, 18)
            Me.lblProvince.TabIndex = 2
            Me.lblProvince.Text = "จังหวัด:"
            Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbProvince
            '
            Me.ErrorProvider1.SetIconPadding(Me.cmbProvince, -15)
            Me.cmbProvince.Location = New System.Drawing.Point(472, 24)
            Me.cmbProvince.MaxLength = 255
            Me.cmbProvince.Name = "cmbProvince"
            Me.cmbProvince.Size = New System.Drawing.Size(240, 21)
            Me.cmbProvince.TabIndex = 4
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(24, 25)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 24)
            Me.txtCode.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(208, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.btnCustGroupEdit)
            Me.grbDetail.Controls.Add(Me.btnCustGroupFind)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.txtGroupCode)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.txtAddress)
            Me.grbDetail.Controls.Add(Me.cmbProvince)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.txtPhone)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblPhone)
            Me.grbDetail.Controls.Add(Me.lblGroup)
            Me.grbDetail.Controls.Add(Me.lblProvince)
            Me.grbDetail.Controls.Add(Me.lblAddress)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.txtGroupName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 136)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลลูกค้า"
            '
            'btnCustGroupEdit
            '
            Me.btnCustGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustGroupEdit.Image = CType(resources.GetObject("btnCustGroupEdit.Image"), System.Drawing.Image)
            Me.btnCustGroupEdit.Location = New System.Drawing.Point(688, 72)
            Me.btnCustGroupEdit.Name = "btnCustGroupEdit"
            Me.btnCustGroupEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCustGroupEdit.TabIndex = 14
            Me.btnCustGroupEdit.TabStop = False
            Me.btnCustGroupEdit.ThemedImage = CType(resources.GetObject("btnCustGroupEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustGroupFind
            '
            Me.btnCustGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustGroupFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustGroupFind.Image = CType(resources.GetObject("btnCustGroupFind.Image"), System.Drawing.Image)
            Me.btnCustGroupFind.Location = New System.Drawing.Point(664, 72)
            Me.btnCustGroupFind.Name = "btnCustGroupFind"
            Me.btnCustGroupFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCustGroupFind.TabIndex = 13
            Me.btnCustGroupFind.TabStop = False
            Me.btnCustGroupFind.ThemedImage = CType(resources.GetObject("btnCustGroupFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(640, 104)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 16
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(560, 104)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 15
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "Reset"
            '
            'txtGroupName
            '
            Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupName, "")
            Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.txtGroupName.Location = New System.Drawing.Point(560, 72)
            Me.Validator.SetMaxValue(Me.txtGroupName, "")
            Me.Validator.SetMinValue(Me.txtGroupName, "")
            Me.txtGroupName.Name = "txtGroupName"
            Me.txtGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupName, "")
            Me.Validator.SetRequired(Me.txtGroupName, False)
            Me.txtGroupName.Size = New System.Drawing.Size(104, 21)
            Me.txtGroupName.TabIndex = 7
            Me.txtGroupName.TabStop = False
            Me.txtGroupName.Text = ""
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
            'CustFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "CustFilterSubPanel"
            Me.Size = New System.Drawing.Size(752, 152)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Dim m_custGroup As New CustomerGroup
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            LoopControl(Me)

        End Sub
#End Region

#Region "Properties"
        Private Property CustGroup() As CustomerGroup
            Get
                Return m_custGroup
            End Get
            Set(ByVal Value As CustomerGroup)
                m_custGroup = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            Province.ListProvinceInComboBox(Me.cmbProvince)
        End Sub

        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtName.Text = ""
            Me.txtAddress.Text = ""
            Me.txtPhone.Text = ""
            Me.txtGroupCode.Text = ""
            Me.txtGroupName.Text = ""
            Me.CustGroup = New CustomerGroup
            Me.cmbProvince.SelectedIndex = -1
            Me.cmbProvince.SelectedIndex = -1
        End Sub

        Public Sub SetLabelText()
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblName}")
            Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblGroup}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.grbDetail}")
            Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblAddress}")
            Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblPhone}")
            Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblProvince}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(5) As Filter
            arr(0) = New Filter("addressBillingAddress", IIf(Me.txtAddress.Text.Length = 0, DBNull.Value, Me.txtAddress.Text))
            arr(1) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(2) = New Filter("csg_id", IIf(Me.CustGroup.Valid, Me.CustGroup.Id, DBNull.Value))
            arr(3) = New Filter("nameAltName", IIf(Me.txtName.Text.Length = 0, DBNull.Value, Me.txtName.Text))
            arr(4) = New Filter("phoneFax", IIf(Me.txtPhone.Text.Length = 0, DBNull.Value, Me.txtPhone.Text))
            arr(5) = New Filter("province", IIf(Me.cmbProvince.Text.Length <= 0, DBNull.Value, Me.cmbProvince.Text))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
            CustomerGroup.GetCustomerGroup(txtGroupCode, txtGroupName, Me.CustGroup)
        End Sub
        Private Sub ibtnShowAccountDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustGroupFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CustomerGroup, AddressOf SetCustomerGroup)
        End Sub
        Private Sub SetCustomerGroup(ByVal e As ISimpleEntity)
            Me.txtGroupCode.Text = e.Code
            CustomerGroup.GetCustomerGroup(txtGroupCode, txtGroupName, Me.CustGroup)
        End Sub
        Private Sub ibtnShowAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustGroupEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CustomerGroup)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New CustomerGroup).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtgroupcode", "txtgroupname"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CustomerGroup).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
                Dim entity As New CustomerGroup(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtgroupcode", "txtgroupname"
                            Me.SetCustomerGroup(entity)
                    End Select
                End If
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

                    If TypeOf entity Is Customer Then
                        Dim obj As Customer
                        obj = CType(entity, Customer)
                        ' Account ...
                        If obj.Group.Originated Then
                            Me.SetCustomerGroup(obj.Group)
                            Me.txtGroupCode.Enabled = False
                            Me.txtGroupName.Enabled = False
                            Me.btnCustGroupEdit.Enabled = False
                            Me.btnCustGroupFind.Enabled = False
                        End If
                    End If
                Next
            End Set
        End Property


    End Class
End Namespace

