Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BillIssueFilterSubPanel
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnCustomerPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents lblDoc As System.Windows.Forms.Label
        Friend WithEvents txtDoc As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BillIssueFilterSubPanel))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnCustomerPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.lblDoc = New System.Windows.Forms.Label
            Me.txtDoc = New System.Windows.Forms.TextBox
            Me.grbMainDetail.SuspendLayout()
            Me.SuspendLayout()
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
            'txtCustomerCode
            '
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, False)
            Me.txtCustomerCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCustomerCode.TabIndex = 0
            Me.txtCustomerCode.Text = ""
            '
            'txtCustomerName
            '
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(336, 20)
            Me.txtCustomerName.TabIndex = 10
            Me.txtCustomerName.TabStop = False
            Me.txtCustomerName.Text = ""
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, False)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCostCenterCode.TabIndex = 1
            Me.txtCostCenterCode.Text = ""
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(192, 64)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(336, 20)
            Me.txtCostCenterName.TabIndex = 11
            Me.txtCostCenterName.TabStop = False
            Me.txtCostCenterName.Text = ""
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.btnCustomerPanel)
            Me.grbMainDetail.Controls.Add(Me.txtCustomerCode)
            Me.grbMainDetail.Controls.Add(Me.txtCustomerName)
            Me.grbMainDetail.Controls.Add(Me.btnCustomerDialog)
            Me.grbMainDetail.Controls.Add(Me.lblCustomer)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.lblCC)
            Me.grbMainDetail.Controls.Add(Me.btnSearch)
            Me.grbMainDetail.Controls.Add(Me.btnReset)
            Me.grbMainDetail.Controls.Add(Me.lblDoc)
            Me.grbMainDetail.Controls.Add(Me.txtDoc)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(584, 136)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'btnCustomerPanel
            '
            Me.btnCustomerPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerPanel.Image = CType(resources.GetObject("btnCustomerPanel.Image"), System.Drawing.Image)
            Me.btnCustomerPanel.Location = New System.Drawing.Point(552, 40)
            Me.btnCustomerPanel.Name = "btnCustomerPanel"
            Me.btnCustomerPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerPanel.TabIndex = 8
            Me.btnCustomerPanel.TabStop = False
            Me.btnCustomerPanel.ThemedImage = CType(resources.GetObject("btnCustomerPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustomerDialog
            '
            Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerDialog.Image = CType(resources.GetObject("btnCustomerDialog.Image"), System.Drawing.Image)
            Me.btnCustomerDialog.Location = New System.Drawing.Point(528, 40)
            Me.btnCustomerDialog.Name = "btnCustomerDialog"
            Me.btnCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerDialog.TabIndex = 6
            Me.btnCustomerDialog.TabStop = False
            Me.btnCustomerDialog.ThemedImage = CType(resources.GetObject("btnCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCustomer.Location = New System.Drawing.Point(8, 40)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(104, 18)
            Me.lblCustomer.TabIndex = 12
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.ItemHeight = 13
            Me.cmbStatus.Location = New System.Drawing.Point(112, 88)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(144, 21)
            Me.cmbStatus.TabIndex = 3
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 88)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblStatus.TabIndex = 15
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCostCenterPanel
            '
            Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterPanel.Image = CType(resources.GetObject("btnCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnCostCenterPanel.Location = New System.Drawing.Point(552, 64)
            Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
            Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterPanel.TabIndex = 9
            Me.btnCostCenterPanel.TabStop = False
            Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCostCenterDialog
            '
            Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCostCenterDialog.Image = CType(resources.GetObject("btnCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnCostCenterDialog.Location = New System.Drawing.Point(528, 64)
            Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
            Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterDialog.TabIndex = 7
            Me.btnCostCenterDialog.TabStop = False
            Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.BackColor = System.Drawing.Color.Transparent
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCC.Location = New System.Drawing.Point(8, 64)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 13
            Me.lblCC.Text = "โครงการก่อสร้าง:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(496, 104)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(416, 104)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'lblDoc
            '
            Me.lblDoc.BackColor = System.Drawing.Color.Transparent
            Me.lblDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDoc.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblDoc.Location = New System.Drawing.Point(8, 16)
            Me.lblDoc.Name = "lblDoc"
            Me.lblDoc.Size = New System.Drawing.Size(104, 18)
            Me.lblDoc.TabIndex = 14
            Me.lblDoc.Text = "เลขที่เอกสาร:"
            Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDoc
            '
            Me.Validator.SetDataType(Me.txtDoc, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDoc, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDoc, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDoc, System.Drawing.Color.Empty)
            Me.txtDoc.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtDoc, "")
            Me.Validator.SetMinValue(Me.txtDoc, "")
            Me.txtDoc.Name = "txtDoc"
            Me.Validator.SetRegularExpression(Me.txtDoc, "")
            Me.Validator.SetRequired(Me.txtDoc, False)
            Me.txtDoc.Size = New System.Drawing.Size(144, 20)
            Me.txtDoc.TabIndex = 2
            Me.txtDoc.Text = ""
            '
            'BillIssueFilterSubPanel
            '
            Me.Controls.Add(Me.grbMainDetail)
            Me.Name = "BillIssueFilterSubPanel"
            Me.Size = New System.Drawing.Size(600, 152)
            Me.grbMainDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_cc As CostCenter
		Private m_customer As Customer
		Private m_fromSelection As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
			m_fromSelection = False
            InitializeComponent()
            Initialize()
            SetLabelText()
		End Sub
		Public Sub New(ByVal fromSelection As Boolean)
			MyBase.New()
			m_fromSelection = False
			m_fromSelection = fromSelection
			InitializeComponent()
			Initialize()
			SetLabelText()
		End Sub
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            Me.txtCostCenterCode.Text = ""
            Me.txtCostCenterName.Text = ""
            Me.m_cc = New CostCenter

            Me.txtCustomerCode.Text = ""
            Me.txtCustomerName.Text = ""
            Me.txtDoc.Text = ""
            Me.m_customer = New Customer

			cmbStatus.SelectedIndex = 1
            EntityRefresh()
        End Sub
		Private Sub PopulateStatus()
			If m_fromSelection Then
				CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodssold_status", False, True)
			Else
				CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodssold_status", True)
			End If
		End Sub
		Public Sub SetLabelText()
			Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
			Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
			Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueFilterSubPanel.lblCC}")
			Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueFilterSubPanel.lblStatus}")
			Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueFilterSubPanel.grbMainDetail}")
			Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueFilterSubPanel.lblCustomer}")
			Me.lblDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueFilterSubPanel.lbldoc}")
		End Sub
		Public Overrides Function GetFilterArray() As Filter()
			Dim arr(3) As Filter
			arr(0) = New Filter("cc_id", IIf(Me.m_cc.Originated, Me.m_cc.Id, DBNull.Value))
			arr(1) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
			arr(2) = New Filter("cust_id", IIf(Me.m_customer.Originated, Me.m_customer.Id, DBNull.Value))
			arr(3) = New Filter("code", txtDoc.Text)
			Return arr
		End Function
		Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
			Get
				Return Me.btnSearch
			End Get
		End Property
#End Region

#Region "Event Handlers"
        Private Sub txtCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim cc As New CostCenter
            cc.Type.Value = 2
            Dim entities As New ArrayList
            entities.Add(cc)
            Dim filters(0) As Filter
            filters(0) = New Filter("IDlist", "")
            myEntityPanelService.OpenTreeDialog(cc, AddressOf SetCostCenter, filters, entities)
        End Sub
        Private Sub SetCostCenter(ByVal e As ISimpleEntity)
            Me.txtCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
        End Sub
        Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub btnCustomerPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
        End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent(m_cc.FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtCostCenterCode", "txtCostCenterName"
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
            If data.GetDataPresent(m_cc.FullClassName) Then
                Dim id As Integer = CInt(data.GetData(m_cc.FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtcostcentercode", "txtcostcentername"
                        Me.SetCostCenter(entity)
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
            For Each entity As ISimpleEntity In Entities

                If TypeOf entity Is BillIssue Then
                    Dim obj As BillIssue
                    obj = CType(entity, BillIssue)
                    ' Customer ...
                    If obj.Customer.Originated Then
                        Me.SetCustomer(obj.Customer)
                        Me.txtCustomerCode.Enabled = False
                        Me.txtCustomerName.Enabled = False
                        Me.btnCustomerDialog.Enabled = False
                        Me.btnCustomerPanel.Enabled = False
                    End If
                End If
                If TypeOf entity Is Customer Then
                    Me.SetCustomer(entity)
                    Me.txtCustomerCode.Enabled = False
                    Me.txtCustomerName.Enabled = False
                    Me.btnCustomerDialog.Enabled = False
                    Me.btnCustomerPanel.Enabled = False
                End If
            Next
        End Sub
    End Class
End Namespace

