Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CostCenterBudgetDetailView
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
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ImagebtnProjectSetUp As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ImagebtnWBSSetUp As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblItem As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostCenterBudgetDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(848, 536)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลหลัก :"
      Me.ToolTip1.SetToolTip(Me.grbDetail, "ข้อมูลไซต์งาน:")
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(808, 127)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 212
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(808, 151)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 211
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.lblCustomer)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerName)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.lblName)
      Me.grbMainDetail.Controls.Add(Me.txtName)
      Me.grbMainDetail.Controls.Add(Me.txtCustomerCode)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(832, 81)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียด Cost Center:"
      Me.ToolTip1.SetToolTip(Me.grbMainDetail, "ข้อมูลทั่วไป:")
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCustomer.Location = New System.Drawing.Point(264, 25)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(48, 20)
      Me.lblCustomer.TabIndex = 25
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(429, 24)
      Me.txtCustomerName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(395, 21)
      Me.txtCustomerName.TabIndex = 27
      Me.txtCustomerName.TabStop = False
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.txtCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(148, 21)
      Me.txtCode.TabIndex = 0
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCode.Location = New System.Drawing.Point(16, 26)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 16
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblCode, "รหัส:")
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblName.Location = New System.Drawing.Point(16, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(104, 18)
      Me.lblName.TabIndex = 17
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ToolTip1.SetToolTip(Me.lblName, "ชื่อ :")
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(120, 48)
      Me.txtName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.txtName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(704, 22)
      Me.txtName.TabIndex = 1
      '
      'txtCustomerCode
      '
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(312, 24)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.txtCustomerCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(111, 22)
      Me.txtCustomerCode.TabIndex = 26
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(11, 126)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(791, 404)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 167
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblItem.Location = New System.Drawing.Point(8, 105)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 168
      Me.lblItem.Text = "ผู้มีสิทธิ์ใช้งาน:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'CostCenterBudgetDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CostCenterBudgetDetailView"
      Me.Size = New System.Drawing.Size(864, 544)
      Me.grbDetail.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As New CostCenter
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = CostCenterBudgetDetailView.GetSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged

      UpdateEntityProperties()
      EventWiring()
      LoopControl(Me)
    End Sub
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Originated Then
        If Me.m_entity.HaveAccess(CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
          Me.grbDetail.Enabled = True
        Else
          If Me.m_entity.Originator.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            Me.grbDetail.Enabled = True
          Else
            Me.grbDetail.Enabled = False
          End If
        End If
      Else
        Me.grbDetail.Enabled = True
      End If
    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      With Me
        .txtCode.Text = ""
        .txtName.Text = ""

        .m_treeManager.Treetable.Clear()

      End With

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostcenterDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblCustomer}")

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.lblBudget2}")

            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.TabgrbDetail}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.TabgrbMainDetail}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      Application.DoEvents()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      ' ทำการผูก Property ต่าง ๆ เข้ากับ control
      With Me
        .txtCode.Text = .m_entity.Code
        .txtName.Text = .m_entity.Name

        Dim cust As Customer = .m_entity.Customer
        If Not cust Is Nothing Then
          Me.txtCustomerCode.Text = cust.Code
          Me.txtCustomerName.Text = cust.Name
        Else
          Me.txtCustomerCode.Text = ""
          Me.txtCustomerName.Text = ""
        End If

      End With

      Me.RefreshBoq(0)

      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, CostCenter)

        'Me.m_entity.CostCenterUserAccessCollection = New CostCenterUserAccessCollection(Me.m_entity)

        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If

      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

    End Sub

#End Region

#Region "CostCenterUserAccess"
#Region "ItemTreeTable Handlers"
    Private ReadOnly Property CurrentItem() As BudgetForCC
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is BudgetForCC Then
          Return Nothing
        End If
        Return CType(row.Tag, BudgetForCC)
      End Get
    End Property
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshBoq(index)
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As BudgetForCC = Me.CurrentItem
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "type"
            doc.Type = e.ProposedValue.ToString
          Case "iscontrolled"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim controlled As Boolean  = CBool(e.ProposedValue)
            If controlled Then
              Me.m_entity.BoqId = doc.Id
            End If
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
#End Region
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Budgets")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Iscontrolled", GetType(Boolean)))
      Return myDatatable
    End Function

    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Budgets"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterBudgetDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Type"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterBudgetDetailView.TypeHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Type"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Iscontrolled"
      csSelected.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterBudgetDetailView.ControlHeaderText}")

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csSelected)
      Return dst
    End Function
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index < 0 Then
        index = 0
      End If

      Dim filters() As Filter
      filters = New Filter() {}

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQ, AddressOf SetItems, filters)

      Me.RefreshBoq(index)
    End Sub
    Private Function GetItemIDList() As String
      Dim ret As String = ""
      For Each item As CostCenterUserAccess In Me.m_entity.CostCenterUserAccessCollection
        ret &= item.UserId.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, ret.Length - 1)
      End If
      Return ret
    End Function
    Private Sub RefreshBoq(ByVal index As Integer)
      Dim oldFlag As Boolean = m_isInitialized
      m_isInitialized = False
      If Not Me.m_entity.BudgetCollectionForCC Is Nothing Then
        Dim dt As TreeTable = m_treeManager.Treetable
        dt.Clear()
        Dim i As Integer = 0
        For Each bg As BudgetForCC In Me.m_entity.BudgetCollectionForCC.Budgets
          i += 1
          Dim newRow As TreeRow = dt.Childs.Add()
          newRow.Item("LineNumber") = i.ToString
          newRow.Item("Code") = bg.Code
          newRow.Item("Type") = bg.Type
          newRow.Item("IsControlled") = bg.IsControlled
          newRow.Tag = bg
        Next
        dt.AcceptChanges()
      End If
      tgItem.CurrentRowIndex = index
      m_isInitialized = oldFlag
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)

        Dim doc As New BudgetForCC
        doc.Code = item.Code
        doc.Id = item.Id
        doc.CostCenter = Me.m_entity
        doc.Type = ""

        Me.m_entity.BudgetCollectionForCC.Budgets.Add(doc)
        'End If
      Next
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim currentRow As TreeRow = m_treeManager.SelectedRow
      If currentRow Is Nothing Then
        Return
      End If
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.BudgetCollectionForCC.Budgets.Remove(CType(currentRow.Tag, BudgetForCC))
      Me.RefreshBoq(index)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "Function"

#End Region

#Region "Getting Properties from dialog"
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtmanager", "txtmanagername", "txtadmin", "txtadminname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtstoreacctcode", "txtstoreacctname" _
                  , "txtwipacctcode", "txtwipacctname" _
                  , "txtexpenseacctcode", "txtexpenseacctname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtmanager", "txtmanagername"
            Case "txtadmin", "txtadminname"
          End Select
        End If
      End If
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtstoreacctcode", "txtstoreacctname"
            Case "txtwipacctcode", "txtwipacctname"
            Case "txtexpenseacctcode", "txtexpenseacctname"
          End Select
        End If
      End If
    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

  End Class

End Namespace
