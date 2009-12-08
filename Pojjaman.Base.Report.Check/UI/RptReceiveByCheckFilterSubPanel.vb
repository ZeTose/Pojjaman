Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptReceiveByCheckFilterSubPanel
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
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbChkStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblChkStatus As System.Windows.Forms.Label
        Friend WithEvents btnCheckCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCheckCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCheckCodeStart As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustomerStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomerStart As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptReceiveByCheckFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.cmbChkStatus = New System.Windows.Forms.ComboBox
            Me.lblChkStatus = New System.Windows.Forms.Label
            Me.btnCheckCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCheckCodeStart = New System.Windows.Forms.TextBox
            Me.lblCheckCodeStart = New System.Windows.Forms.Label
            Me.btnCustomerStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerCodeStart = New System.Windows.Forms.TextBox
            Me.lblCustomerStart = New System.Windows.Forms.Label
            Me.txtTemp = New System.Windows.Forms.TextBox
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
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(680, 160)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.cmbChkStatus)
            Me.grbDetail.Controls.Add(Me.lblChkStatus)
            Me.grbDetail.Controls.Add(Me.btnCheckCodeStartFind)
            Me.grbDetail.Controls.Add(Me.txtCheckCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCheckCodeStart)
            Me.grbDetail.Controls.Add(Me.btnCustomerStartFind)
            Me.grbDetail.Controls.Add(Me.txtCustomerCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCustomerStart)
            Me.grbDetail.Controls.Add(Me.txtTemp)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(656, 104)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(456, 28)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 24
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(360, 52)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 23
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(360, 28)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 21
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(280, 28)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
            Me.lblCCStart.TabIndex = 19
            Me.lblCCStart.Text = "Cost Center"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(480, 28)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 20
            Me.txtCostCenterName.Text = ""
            '
            'cmbChkStatus
            '
            Me.cmbChkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbChkStatus.Location = New System.Drawing.Point(144, 72)
            Me.cmbChkStatus.Name = "cmbChkStatus"
            Me.cmbChkStatus.TabIndex = 14
            '
            'lblChkStatus
            '
            Me.lblChkStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblChkStatus.ForeColor = System.Drawing.Color.Black
            Me.lblChkStatus.Location = New System.Drawing.Point(8, 72)
            Me.lblChkStatus.Name = "lblChkStatus"
            Me.lblChkStatus.Size = New System.Drawing.Size(128, 18)
            Me.lblChkStatus.TabIndex = 13
            Me.lblChkStatus.Text = "สถานะเช็ค"
            Me.lblChkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCheckCodeStartFind
            '
            Me.btnCheckCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCheckCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCheckCodeStartFind.Image = CType(resources.GetObject("btnCheckCodeStartFind.Image"), System.Drawing.Image)
            Me.btnCheckCodeStartFind.Location = New System.Drawing.Point(240, 24)
            Me.btnCheckCodeStartFind.Name = "btnCheckCodeStartFind"
            Me.btnCheckCodeStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCheckCodeStartFind.TabIndex = 8
            Me.btnCheckCodeStartFind.TabStop = False
            Me.btnCheckCodeStartFind.ThemedImage = CType(resources.GetObject("btnCheckCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCheckCodeStart
            '
            Me.Validator.SetDataType(Me.txtCheckCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCheckCodeStart, "")
            Me.txtCheckCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCheckCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckCodeStart, System.Drawing.Color.Empty)
            Me.txtCheckCodeStart.Location = New System.Drawing.Point(144, 24)
            Me.txtCheckCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCheckCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCheckCodeStart, "")
            Me.txtCheckCodeStart.Name = "txtCheckCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCheckCodeStart, "")
            Me.Validator.SetRequired(Me.txtCheckCodeStart, False)
            Me.txtCheckCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCheckCodeStart.TabIndex = 7
            Me.txtCheckCodeStart.Text = ""
            '
            'lblCheckCodeStart
            '
            Me.lblCheckCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckCodeStart.ForeColor = System.Drawing.Color.Black
            Me.lblCheckCodeStart.Location = New System.Drawing.Point(8, 24)
            Me.lblCheckCodeStart.Name = "lblCheckCodeStart"
            Me.lblCheckCodeStart.Size = New System.Drawing.Size(128, 18)
            Me.lblCheckCodeStart.TabIndex = 6
            Me.lblCheckCodeStart.Text = "เลขที่เช็ค"
            Me.lblCheckCodeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCustomerStartFind
            '
            Me.btnCustomerStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerStartFind.Image = CType(resources.GetObject("btnCustomerStartFind.Image"), System.Drawing.Image)
            Me.btnCustomerStartFind.Location = New System.Drawing.Point(240, 48)
            Me.btnCustomerStartFind.Name = "btnCustomerStartFind"
            Me.btnCustomerStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCustomerStartFind.TabIndex = 8
            Me.btnCustomerStartFind.TabStop = False
            Me.btnCustomerStartFind.ThemedImage = CType(resources.GetObject("btnCustomerStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerCodeStart
            '
            Me.Validator.SetDataType(Me.txtCustomerCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCodeStart, "")
            Me.txtCustomerCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCustomerCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCodeStart, System.Drawing.Color.Empty)
            Me.txtCustomerCodeStart.Location = New System.Drawing.Point(144, 48)
            Me.txtCustomerCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCustomerCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCustomerCodeStart, "")
            Me.txtCustomerCodeStart.Name = "txtCustomerCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCustomerCodeStart, "")
            Me.Validator.SetRequired(Me.txtCustomerCodeStart, False)
            Me.txtCustomerCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCustomerCodeStart.TabIndex = 7
            Me.txtCustomerCodeStart.Text = ""
            '
            'lblCustomerStart
            '
            Me.lblCustomerStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomerStart.ForeColor = System.Drawing.Color.Black
            Me.lblCustomerStart.Location = New System.Drawing.Point(8, 48)
            Me.lblCustomerStart.Name = "lblCustomerStart"
            Me.lblCustomerStart.Size = New System.Drawing.Size(128, 18)
            Me.lblCustomerStart.TabIndex = 6
            Me.lblCustomerStart.Text = "ลูกค้า"
            Me.lblCustomerStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(656, 72)
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
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(592, 128)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(512, 128)
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
            'RptReceiveByCheckFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptReceiveByCheckFilterSubPanel"
            Me.Size = New System.Drawing.Size(728, 176)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblCheckCodeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.lblCheckCodeStart}")
            Me.Validator.SetDisplayName(txtCheckCodeStart, lblCheckCodeStart.Text)

            Me.lblCustomerStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.lblCustomerStart}")
            Me.Validator.SetDisplayName(txtCustomerCodeStart, lblCustomerStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.grbDetail}")

            Me.lblChkStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.lblChkStatus}")
            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptReceiveByCheckFilterSubPanel.chkIncludeChildren}")
        End Sub
#End Region

#Region "Member"
        Private m_checkcodestart As IncomingCheck
        Private m_customerstart As Customer

        Private m_chkstatus As IncomingCheckDocStatus
        Private m_cc As Costcenter
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
        Private Property ChkStatus() As CodeDescription
            Get
                Return m_chkstatus
            End Get
            Set(ByVal Value As CodeDescription)
                m_chkstatus = CType(Value, IncomingCheckDocStatus)
            End Set
        End Property
        Public Property CustomerStart() As Customer
            Get
                Return m_Customerstart
            End Get
            Set(ByVal Value As Customer)
                m_Customerstart = Value
            End Set
        End Property
        Public Property CheckCodeStart() As IncomingCheck
            Get
                Return m_checkcodestart
            End Get
            Set(ByVal Value As IncomingCheck)
                m_checkcodestart = Value
            End Set
        End Property
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            ' รูปแบบ
            IncomingCheckDocStatus.ListCodeDescriptionInComboBox(Me.cmbChkStatus, "IncomingCheck_docstatus", True)
        End Sub
        Private Sub Initialize()
            RegisterDropdown()
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

            Me.Costcenter = New Costcenter

            Me.CustomerStart = New Customer
            Me.CheckCodeStart = New IncomingCheck

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.cmbChkStatus.SelectedIndex = 0
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(5) As Filter
            arr(0) = New Filter("CustomerCodeStart", IIf(txtCustomerCodeStart.TextLength > 0, txtCustomerCodeStart.Text, DBNull.Value))
            arr(1) = New Filter("CheckCodeStart", IIf(txtCheckCodeStart.TextLength > 0, txtCheckCodeStart.Text, DBNull.Value))
            arr(2) = New Filter("CheckStatus", IIf(cmbChkStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbChkStatus.SelectedItem, IdValuePair).Id))
            arr(3) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(4) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

            'CheckCode start
            dpi = New DocPrintingItem
            dpi.Mapping = "checkcodestart"
            dpi.Value = Me.txtCheckCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Customer start
            dpi = New DocPrintingItem
            dpi.Mapping = "customercodestart"
            dpi.Value = Me.txtCustomerCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Checkstatus
            dpi = New DocPrintingItem
            dpi.Mapping = "Checkstatus"
            dpi.Value = Me.cmbChkStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterStart"
            dpi.Value = txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnCheckCodeStartFind.Click, AddressOf Me.btnCheckCodeFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnCustomerStartFind.Click, AddressOf Me.btnCustomerFind_Click
            AddHandler txtCustomerCodeStart.Validated, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case Else
            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' CheckCode
                If data.GetDataPresent((New IncomingCheck).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcheckcodestart", "txtcheckcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Customer
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtCustomercodestart", "txtCustomercodeend"
                                Return True
                        End Select
                    End If
                End If
                'CostCenter
                If data.GetDataPresent((New Costcenter).FullClassName) Then
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
            ' checkcode
            If data.GetDataPresent((New IncomingCheck).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New IncomingCheck).FullClassName))
                Dim entity As New IncomingCheck(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcheckcodestart"
                            Me.SetCheckCodeStartDialog(entity)
                    End Select
                End If
            End If
            ' Customer
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtCustomercodestart"
                            Me.SetCustomerStartDialog(entity)
                    End Select
                End If
            End If
            ' Costcenter
            If data.GetDataPresent((New Costcenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
                Dim entity As New Costcenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        'CheckCode
        Private Sub btnCheckCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncheckcodestartfind"
                    myEntityPanelService.OpenListDialog(New IncomingCheck, AddressOf SetCheckCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCheckCodeStartDialog(ByVal e As ISimpleEntity)
            Dim chkcode As IncomingCheck = CType(e, IncomingCheck)
            Me.txtCheckCodeStart.Text = chkcode.CqCode
        End Sub
        'Customer
        Private Sub btnCustomerFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncustomerstartfind"
                    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerStartDialog)
            End Select
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCustomerStartDialog(ByVal e As ISimpleEntity)
            Me.txtCustomerCodeStart.Text = e.Code
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

    End Class

End Namespace

